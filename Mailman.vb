' 03/24/25 - Mailman.vb
' This module handles concurrent email submissions to Mailman signup pages.
' It uses live slider input for both concurrency (number of parallel threads)
' and throttle (delay between submissions, globally enforced).
' The global throttle ensures NO more than one email is submitted every X seconds total.

Imports System.Net.Http
Imports System.Threading
Imports HtmlAgilityPack
Imports System.Net


Public Class Mailman
    Private Shared confirmedSet As New HashSet(Of String)
    Private Shared rndGlobal As New Random()
    Private Shared confirmedUrls As New HashSet(Of String)()

    ' Shared timestamp for global throttle enforcement
    Private Shared LastSubmissionTime As DateTime = DateTime.MinValue
    Private Shared ReadOnly ThrottleLock As New Object()

    ' Entry point: runs submission loop and launches concurrent tasks
    Public Async Function SubmitEmails(targetEmail As String, updateUI As Action(Of String, Boolean?), cancelToken As CancellationToken) As Task
        Dim signupUrlsPath As String = "C:\RelentlessSMS\Mailman\signup_urls.txt"
        If Not IO.File.Exists(signupUrlsPath) Then
            updateUI("❌ signup_urls.txt not found.", False)
            Return
        End If

        Dim urls As List(Of String) = IO.File.ReadAllLines(signupUrlsPath).ToList()
        If frmMain.cbHumanMode.Checked Then
            Dim rndGlobal As New Random()
            urls = urls.OrderBy(Function(x) rndGlobal.Next()).ToList()
        End If
        Dim rnd As New Random()
        urls = urls.OrderBy(Function(x) rndGlobal.Next()).ToList()

        Dim httpClient As New HttpClient()
        Dim currentIndex As Integer = 0
        Dim activeTasks As New List(Of Task)
        Dim taskLock As New Object()

        Dim submissionCount As Integer = 0
        While currentIndex < urls.Count AndAlso Not cancelToken.IsCancellationRequested
            Dim runningCount As Integer = 0

            ' Count running tasks manually (avoid LINQ to fix BC32106)
            SyncLock taskLock
                For Each t In activeTasks
                    If Not t.IsCompleted Then runningCount += 1
                Next
            End SyncLock

            ' Read current slider value for concurrency (live)
            Dim currentConcurrency As Integer = Math.Max(1, frmMain.tbConcurrent.Value)

            If runningCount < currentConcurrency Then
                Dim url As String = urls(currentIndex)
                currentIndex += 1

                Dim task As Task = SubmitToSignupAsync(url, targetEmail, httpClient, updateUI, cancelToken)

                SyncLock taskLock
                    activeTasks.Add(task)
                    submissionCount += 1
                End SyncLock
            Else
                Await Task.Delay(100, cancelToken)
            End If
        End While

        Await Task.WhenAll(activeTasks)

        If Not cancelToken.IsCancellationRequested Then
            updateUI("✅ Submission process completed.", Nothing)
        End If
    End Function

    Private Async Function SubmitToSignupAsync(url As String, targetEmail As String, httpClient As HttpClient, updateUI As Action(Of String, Boolean?), cancelToken As CancellationToken) As Task
        Try
            If cancelToken.IsCancellationRequested Then Return

            Dim response As HttpResponseMessage = Await httpClient.GetAsync(url, cancelToken)
            Dim html As String = Await response.Content.ReadAsStringAsync()

            If cancelToken.IsCancellationRequested Then Return

            Dim htmlDoc As New HtmlDocument()
            htmlDoc.LoadHtml(html)

            ' Try to find the subscription form
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

            ' Build full submission URL
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

            ' === GLOBAL THROTTLE ENFORCEMENT ===
            Dim sliderValue As Integer = frmMain.tbThrottle.Value
            Dim delayMs As Integer = CInt(60000 - (sliderValue * 5990))
            Dim waitTime As Integer = 0

            SyncLock ThrottleLock
                Dim now As DateTime = DateTime.UtcNow
                Dim elapsed = (now - LastSubmissionTime).TotalMilliseconds
                If elapsed < delayMs Then waitTime = CInt(delayMs - elapsed)
            End SyncLock

            If waitTime > 0 Then Await Task.Delay(waitTime, cancelToken)

            ' === SEND FORM SUBMISSION ===
            Dim content As New FormUrlEncodedContent(postData)
            Dim postResponse As HttpResponseMessage = Await httpClient.PostAsync(formUrl, content, cancelToken)
            Dim postText As String = Await postResponse.Content.ReadAsStringAsync()
            Dim lowerText As String = postText.ToLower()

            ' === Confidence scoring ===
            Dim score As Integer = 0
            If lowerText.Contains("check your email") Then score += 3
            If lowerText.Contains("you have been subscribed") Then score += 4
            If lowerText.Contains("already subscribed") Then score += 2
            If lowerText.Contains("subscription request has been received") Then score += 3
            If lowerText.Contains("confirmation email has been sent") Then score += 3
            If lowerText.Contains("mailman") Then score += 1
            If lowerText.Contains("confirmation") Then score += 1
            If lowerText.Contains("email sent") Then score += 1
            If postResponse.StatusCode = HttpStatusCode.OK Then score += 2

            Dim isConfirmed As Boolean = (score >= 4)
            IO.File.AppendAllText("C:\RelentlessSMS\Mailman\confidence_log.txt", $"[{DateTime.Now}] {formUrl} | Score: {score}" & Environment.NewLine)
            x.LogApiResponse(formUrl, postText)

            ' === Only confirmed go to txtConfirm ===
            If isConfirmed Then
                frmMain.Invoke(Sub()
                                   Dim timestamp As String = DateTime.Now.ToString("HH:mm:ss")
                                   If frmMain.allowConfirmLogging Then
                                       frmMain.txtConfirm.AppendText(timestamp & ": ✅ Confirmed: " & formUrl & Environment.NewLine)

                                       ' Safely increment confirmed count
                                       Dim currentCount As Integer = 0
                                       If Not Integer.TryParse(frmMain.txtConfirmed.Text.Trim(), currentCount) Then
                                           currentCount = 0
                                       End If
                                       frmMain.txtConfirmed.Text = (currentCount + 1).ToString()

                                       frmMain.txtConfirm.SelectionStart = frmMain.txtConfirm.TextLength
                                       frmMain.txtConfirm.ScrollToCaret()
                                   End If
                               End Sub)

                IO.File.AppendAllText("C:\RelentlessSMS\Mailman\confirmed_urls.txt", formUrl & Environment.NewLine)
                IO.File.AppendAllText("C:\RelentlessSMS\Mailman\confirmed_html_log.txt", "[" & DateTime.Now.ToString() & "] " & formUrl & Environment.NewLine & postText & Environment.NewLine & "---" & Environment.NewLine)
            End If

            ' Always log outcome to OutgoingMessages, mark isSuccess as TRUE for ANY submission
            updateUI("📤 Submitted to " & formUrl & " | Score=" & score.ToString(), True)


            ' === Update global throttle timestamp ===
            SyncLock ThrottleLock
                LastSubmissionTime = DateTime.UtcNow
            End SyncLock

        Catch ex As Exception
            If Not cancelToken.IsCancellationRequested Then
                updateUI($"❌ Error with {url}: {ex.Message}", False)
            End If
        End Try
    End Function



End Class
