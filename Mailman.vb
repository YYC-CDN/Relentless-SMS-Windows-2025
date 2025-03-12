Imports System.IO
Imports System.Net.Http
Imports System.Threading.Tasks

Public Class Mailman
    Private httpClient As New HttpClient()

    ' Submit emails to all signup URLs
    Public Async Function SubmitEmails(targetEmail As String, updateStatus As Action(Of String, Boolean?)) As Task
        Dim successfulUrls As New List(Of String)()
        Dim failedUrls As New List(Of String)()
        Dim allUrls As List(Of String) = File.ReadAllLines(x.SignupUrlsPath).ToList()

        For Each signupUrl In allUrls
            signupUrl = signupUrl.Trim()
            If String.IsNullOrWhiteSpace(signupUrl) Then Continue For

            updateStatus($"Processing: {signupUrl}", Nothing)
            LogStatus($"Processing: {signupUrl}")

            ' Ensure we are submitting to the correct subscription page
            Dim subscriptionUrl As String = signupUrl.Replace("listinfo", "subscribe")
            Dim success As Boolean = Await SubmitToSignupPage(subscriptionUrl, targetEmail)

            If success Then
                successfulUrls.Add(signupUrl)
                updateStatus($"✅ Success: {targetEmail} submitted to {subscriptionUrl}", True)
                LogStatus($"✅ Success: {targetEmail} submitted to {subscriptionUrl}")
            Else
                failedUrls.Add(signupUrl)
                updateStatus($"❌ Failed: {targetEmail} to {subscriptionUrl}", False)
                LogStatus($"❌ Failed: {targetEmail} to {subscriptionUrl}")
            End If
        Next

        ' Overwrite the master list with only successful URLs
        File.WriteAllLines(x.SignupUrlsPath, successfulUrls)

        ' Optional: Log removed failed URLs for debugging
        File.WriteAllLines(Path.Combine(x.MailmanPath, "failed_urls.txt"), failedUrls)

        updateStatus($"✅ {successfulUrls.Count} URLs kept. ❌ {failedUrls.Count} URLs removed.", Nothing)
        LogStatus($"✅ {successfulUrls.Count} URLs kept. ❌ {failedUrls.Count} URLs removed.")
    End Function

    ' Submit to the actual signup page
    Private Async Function SubmitToSignupPage(subscriptionUrl As String, targetEmail As String) As Task(Of Boolean)
        Try
            Dim postData As New FormUrlEncodedContent(New Dictionary(Of String, String) From {
                {"email", targetEmail},
                {"email-button", "Subscribe"}
            })

            Dim response As HttpResponseMessage = Await httpClient.PostAsync(subscriptionUrl, postData)
            Dim responseContent As String = Await response.Content.ReadAsStringAsync()

            ' Log the full response for debugging
            LogResponse(subscriptionUrl, responseContent)

            Return response.IsSuccessStatusCode
        Catch ex As Exception
            LogStatus($"❌ Error submitting to {subscriptionUrl}: {ex.Message}")
            Return False
        End Try
    End Function

    ' Shared method to log status messages
    Public Shared Sub LogStatus(message As String)
        Try
            File.AppendAllText(Path.Combine(x.LogsPath, "Logs.txt"), $"{DateTime.Now}: {message}{Environment.NewLine}")
        Catch ex As Exception
            ' Ignore logging errors to prevent crashes
        End Try
    End Sub

    ' Shared method to log responses from servers
    Public Shared Sub LogResponse(url As String, response As String)
        Try
            File.AppendAllText(Path.Combine(x.LogsPath, "ResponseLogs.txt"), $"{DateTime.Now}: Response from {url}{Environment.NewLine}{response}{Environment.NewLine}---{Environment.NewLine}")
        Catch ex As Exception
            ' Ignore logging errors to prevent crashes
        End Try
    End Sub
End Class
