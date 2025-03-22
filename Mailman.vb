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

            Dim urls As String() = IO.File.ReadAllLines(signupUrlsPath)
            Dim httpClient As New HttpClient()

            For Each url As String In urls
                ' 🔴 Immediate exit if user requested stop (no logs, no delay)
                If cancelToken.IsCancellationRequested Then Exit Function

                Try
                    Dim response As HttpResponseMessage = Await httpClient.GetAsync(url)
                    Dim html As String = Await response.Content.ReadAsStringAsync()

                    ' Stop again in case delay occurred
                    If cancelToken.IsCancellationRequested Then Exit Function

                    Dim htmlDoc As New HtmlDocument()
                    htmlDoc.LoadHtml(html)

                    Dim form = htmlDoc.DocumentNode.SelectSingleNode("//form[contains(@action, 'subscribe') or contains(@action, 'mailman')]")
                    If form Is Nothing Then
                        If Not cancelToken.IsCancellationRequested Then
                            updateUI($"⚠ No subscription form found on {url}", False)
                        End If
                        Continue For
                    End If

                    Dim action As String = form.GetAttributeValue("action", "")
                    If String.IsNullOrEmpty(action) Then
                        If Not cancelToken.IsCancellationRequested Then
                            updateUI($"⚠ Form has no action URL at {url}", False)
                        End If
                        Continue For
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
                    Dim postResponse As HttpResponseMessage = Await httpClient.PostAsync(formUrl, content)
                    Dim postText As String = Await postResponse.Content.ReadAsStringAsync()

                    If cancelToken.IsCancellationRequested Then Exit Function

                    Dim isSuccess As Boolean = postText.ToLower().Contains("confirmation") OrElse
                                                   postText.ToLower().Contains("already subscribed") OrElse
                                                   postText.ToLower().Contains("success")

                    If Not cancelToken.IsCancellationRequested Then
                        updateUI($"📤 Submitted to {formUrl}", isSuccess)
                    End If

                Catch ex As Exception
                    If Not cancelToken.IsCancellationRequested Then
                        updateUI($"❌ Error with {url}: {ex.Message}", False)
                    End If
                End Try

                ' Delay only if not canceled
                For i As Integer = 1 To 10
                    If cancelToken.IsCancellationRequested Then Exit Function
                    Await Task.Delay(50) ' 10 x 50ms = 500ms throttle total
                Next
            Next

            ' Final status message only if still active
            If Not cancelToken.IsCancellationRequested Then
                updateUI("✅ Submission process completed.", Nothing)
            End If
        End Function

    End Class


