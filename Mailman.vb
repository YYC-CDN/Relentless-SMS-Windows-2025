Imports System.Net.Http
Imports System.Threading
Imports HtmlAgilityPack

Public Class Mailman

    Public Async Function SubmitEmails(targetEmail As String, updateUI As Action(Of String, Boolean?), cancelToken As CancellationToken) As Task
        Dim signupUrlsPath As String = "C:\RelentlessSMS\Mailman\signup_urls.txt"
        If Not IO.File.Exists(signupUrlsPath) Then
            updateUI("❌ signup_urls.txt not found.", False)
            Return
        End If

        Dim urls As List(Of String) = IO.File.ReadAllLines(signupUrlsPath).ToList()
        Dim rnd As New Random()
        urls = urls.OrderBy(Function(x) rnd.Next()).ToList()

        Dim httpClient As New HttpClient()
        Dim currentIndex As Integer = 0
        Dim activeTasks As New List(Of Task)
        Dim taskLock As New Object()

        While currentIndex < urls.Count AndAlso Not cancelToken.IsCancellationRequested
            ' Count number of tasks still running
            Dim runningCount As Integer = 0
            SyncLock taskLock
                For Each t In activeTasks
                    If Not t.IsCompleted Then runningCount += 1
                Next
            End SyncLock

            ' Check current max concurrency
            Dim currentConcurrency As Integer = Math.Max(1, frmMain.tbConcurrent.Value)

            If runningCount < currentConcurrency Then
                Dim url As String = urls(currentIndex)
                currentIndex += 1

                Dim task As Task = Task.Run(Async Function()
                                                Try
                                                    If cancelToken.IsCancellationRequested Then Return

                                                    Dim response As HttpResponseMessage = Await httpClient.GetAsync(url, cancelToken)
                                                    Dim html As String = Await response.Content.ReadAsStringAsync()

                                                    If cancelToken.IsCancellationRequested Then Return

                                                    Dim htmlDoc As New HtmlDocument()
                                                    htmlDoc.LoadHtml(html)

                                                    Dim form = htmlDoc.DocumentNode.SelectSingleNode("//form[contains(@action, 'subscribe') or contains(@action, 'mailman')]")
                                                    If form Is Nothing Then
                                                        updateUI($"⚠ No subscription form found on {url}", False)
                                                        Return
                                                    End If

                                                    Dim action As String = form.GetAttributeValue("action", "")
                                                    If String.IsNullOrEmpty(action) Then
                                                        updateUI($"⚠ Form has no action URL at {url}", False)
                                                        Return
                                                    End If

                                                    Dim formUrl As String = If(action.StartsWith("http"), action, New Uri(New Uri(url), action).ToString())
                                                    Dim tokenInput = form.SelectSingleNode(".//input[@name='sub_form_token']")
                                                    Dim hiddenToken As String = If(tokenInput IsNot Nothing, tokenInput.GetAttributeValue("value", ""), "")

                                                    Dim postData As New Dictionary(Of String, String) From {
                                                        {"email", targetEmail},
                                                        {"email-button", "Subscribe"}
                                                    }
                                                    If Not String.IsNullOrEmpty(hiddenToken) Then
                                                        postData.Add("sub_form_token", hiddenToken)
                                                    End If

                                                    Dim content As New FormUrlEncodedContent(postData)
                                                    Dim postResponse As HttpResponseMessage = Await httpClient.PostAsync(formUrl, content, cancelToken)
                                                    Dim postText As String = Await postResponse.Content.ReadAsStringAsync()

                                                    x.LogApiResponse(formUrl, postText)
                                                    updateUI($"📤 Submitted to {formUrl}", True)

                                                    ' Respect throttle setting
                                                    Dim delay As Integer = frmMain.tbThrottle.Value
                                                    If delay > 0 Then Await Task.Delay(delay, cancelToken)

                                                Catch ex As Exception
                                                    If Not cancelToken.IsCancellationRequested Then
                                                        updateUI($"❌ Error with {url}: {ex.Message}", False)
                                                    End If
                                                End Try
                                            End Function)

                SyncLock taskLock
                    activeTasks.Add(task)
                End SyncLock
            Else
                Await Task.Delay(100, cancelToken)
            End If
        End While

        ' Wait for all remaining tasks to finish
        Await Task.WhenAll(activeTasks)

        If Not cancelToken.IsCancellationRequested Then
            updateUI("✅ Submission process completed.", Nothing)
        End If
    End Function

End Class
