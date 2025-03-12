'  06/28/23 
Imports System.Net
Imports System.Text
Imports System.IO
Imports System.Configuration

Module InternalMaillistSubscriber

    Sub EmailSend()
        Dim email As String = frmMain.txtTargetNumber.Text.Trim()
        If String.IsNullOrEmpty(email) Then
            MessageBox.Show("Please enter a target email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim providerUrls As String() = GetProviderUrls()
        If providerUrls.Length = 0 Then
            MessageBox.Show("No provider URLs found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim totalSubscribed As Integer = 0
        Dim successCount As Integer = 0
        Dim failureCount As Integer = 0

        For Each url As String In providerUrls
            totalSubscribed += 1 ' Move the increment statement to the beginning of the loop
            Dim subscribeUrl As String = url & "/subscribe/" & GetListName(url)
            Dim response As String = SubscribeEmail(subscribeUrl, email)

            If response.Contains("successfully subscribed") Then
                successCount += 1
            Else
                failureCount += 1
            End If
        Next

        'frmMain.lblTotalSubscribed.Text = successCount.ToString()
        'frmMain.lblTotalFailed.Text = failureCount.ToString()

        Dim message As String = "Total Subscribed: " & successCount & vbCrLf & "Total Failed: " & failureCount
        MessageBox.Show(message, "Subscription Results", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub


    Private Function GetProviderUrls() As String()
        Dim providerFile As String = "C:\RelentlessSMS\EmailInformation\emaillistproviders.txt"
        If Not File.Exists(providerFile) Then
            MessageBox.Show("Provider file not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return New String() {}
        End If

        Return File.ReadAllLines(providerFile)
    End Function

    Private Function GetListName(url As String) As String
        ' Extract the list name from the provider URL.
        ' Customize this logic based on the structure of the URLs.
        ' This implementation assumes the list name comes after the last "/" in the URL.
        Dim parts As String() = url.Split("/"c)
        Return parts(parts.Length - 1)
    End Function

    Private Function SubscribeEmail(subscribeUrl As String, email As String) As String
        Try
            Dim client As New WebClient()
            Dim postData As String = "email=" & Uri.EscapeDataString(email)
            Dim responseBytes As Byte() = client.UploadData(subscribeUrl, Encoding.UTF8.GetBytes(postData))
            Return Encoding.UTF8.GetString(responseBytes)
        Catch ex As Exception
            Console.WriteLine("Error subscribing email: " & ex.Message)
            Return String.Empty
        End Try
    End Function



End Module

