'03/03/2023

Imports System.IO

Public Class frmSettings

    Private Sub txtTextNowAPI_GotFocus(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Clear the contents of the textbox
        txtTextNowAPI.Clear()
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BringToFront()

        ' Load IPQualityScore API key from file
        LoadIPQualityScoreAPI()

        ' Load Mailman API keys from MailmanAPIs.txt
        Try
            Dim apiPath As String = "C:\RelentlessSMS\APIs\MailmanAPIs.txt"
            If File.Exists(apiPath) Then
                Dim keys() As String = File.ReadAllLines(apiPath)
                If keys.Length >= 4 Then
                    tbShodanAPI.Text = keys(0)
                    tbZoomEyeAPI.Text = keys(1)
                    tbSecurityTrailsAPI.Text = keys(2)
                    tbSerpAPI.Text = keys(3)
                End If
            End If
        Catch ex As Exception
            MessageBox.Show("⚠ Could not load Mailman API keys: " & ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try


    End Sub




    Private Sub btnAddTextNowAPI_Click(sender As Object, e As EventArgs) Handles btnAddTextNowAPI.Click


        ' Get the current list of APIs from the file
        Dim apis As String() = System.IO.File.ReadAllLines("C:\RelentlessSMS\APIs\TextNowAPI.txt")

        ' Add the new API to the list
        Dim new_api As String = txtTextNowAPI.Text.Trim()
        If new_api <> "" Then
            ' Check if the API already exists in the list
            If Not apis.Contains(new_api) Then
                ' Add the new API to the array
                apis = apis.Where(Function(x) x.Trim() <> "").ToArray() ' Skip empty strings
                Array.Resize(apis, apis.Length + 1)
                apis(apis.Length - 1) = new_api
            Else
                MessageBox.Show("API already exists in the list.")
                Return
            End If
        End If

        ' Write the updated list of APIs to the file
        System.IO.File.WriteAllLines("C:\RelentlessSMS\APIs\TextNowAPI.txt", apis)

        ' Show a message to confirm that the API has been saved
        MessageBox.Show("API saved successfully               ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LoadTextNowAPI()
        ' Set the path for the API file
        Dim api_file_path As String = "C:\RelentlessSMS\APIs\TextNowAPI.txt"

        ' Check if the API file exists
        If File.Exists(api_file_path) Then
            ' Clear the txtTextNowAPI control
            txtTextNowAPI.Clear()

            ' Read the contents of the API file line by line
            Using reader As New StreamReader(api_file_path)
                While Not reader.EndOfStream
                    Dim line As String = reader.ReadLine()
                    txtTextNowAPI.AppendText(line & vbCrLf)
                End While
            End Using
        Else
            ' Set the default API in the txtAPI textbox
            txtTextNowAPI.Text = "Default API value"
        End If
    End Sub

    Private Sub btnIPQualityScore_Click(sender As Object, e As EventArgs)

        ' Get the current list of APIs from the file
        Dim apis = File.ReadAllLines("C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt")

        ' Add the new API to the list
        Dim new_api = txtIPQualityScore.Text.Trim
        If new_api <> "" Then
            ' Check if the API already exists in the list
            If Not apis.Contains(new_api) Then
                ' Add the new API to the array
                apis = apis.Where(Function(x) x.Trim <> "").ToArray ' Skip empty strings
                Array.Resize(apis, apis.Length + 1)
                apis(apis.Length - 1) = new_api
            Else
                MessageBox.Show("IP Quality Score API already exists in the list.")
                Return
            End If
        End If

        ' Write the updated list of APIs to the file
        File.WriteAllLines("C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt", apis)

        ' Show a message to confirm that the API has been saved
        MessageBox.Show("IP Quality Score API saved successfully               ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub LoadIPQualityScoreAPI()
        ' Set the default API value
        ' Set the path for the API file
        Dim api_file_path As String = "C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt"

        ' Read the contents of the API file and set it as the default API
        Dim default_api As String = System.IO.File.ReadAllText(api_file_path)

        ' Set the default API in the txtAPI textbox
        txtIPQualityScore.Text = default_api

        ' Get the path to the API file
        Dim api_path As String = "C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt"

        ' Check if the API file exists
        If File.Exists(api_path) Then
            ' Read the API value from the file
            Dim api_value As String = File.ReadAllText(api_path)

            ' Update the API textbox with the saved API value
            txtIPQualityScore.Text = api_value
        Else
            ' Update the API textbox with the default API value
            txtIPQualityScore.Text = default_api
        End If
    End Sub


    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click




        Me.Close()
    End Sub


    Private Sub btnAddSMTP_Click(sender As Object, e As EventArgs)
        ' Validate the input
        If String.IsNullOrWhiteSpace(txtSMTPbox.Text) Then
            MessageBox.Show("SMTP address is required", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If String.IsNullOrWhiteSpace(txtPort.Text) OrElse Not Integer.TryParse(txtPort.Text, Nothing) Then
            MessageBox.Show("Port number is required and must be an integer", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        If cbEnableSSL.SelectedIndex = 0 Then
            MessageBox.Show("Please select a value for Enable SSL", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Write the SMTP settings to file
        Dim smtpFilePath = "C:\RelentlessSMS\EmailInformation\SMTP.txt"
        Dim sslValue = ""

        If cbEnableSSL.SelectedIndex = 1 Then
            sslValue = "True"
        ElseIf cbEnableSSL.SelectedIndex = 2 Then
            sslValue = "False"
        End If

        Dim smtpSettings = String.Format("{0}{1}{2}{3}{4}",
                                                    txtSMTPbox.Text.Trim, vbCrLf,
                                                    txtPort.Text.Trim, vbCrLf,
                                                    sslValue)

        File.WriteAllText(smtpFilePath, smtpSettings)

        MessageBox.Show("SMTP settings saved successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnAddEmailPass_Click(sender As Object, e As EventArgs)
        ' Check if both email and password are provided
        If txtEmailAddresses.Text.Trim = "" Or txtEmailPassword.Text.Trim = "" Then
            MessageBox.Show("Please enter email address and password.")
            Return
        End If

        ' Check if email address is valid
        If Not IsValidEmail(txtEmailAddresses.Text.Trim) Then
            MessageBox.Show("Invalid email address.")
            Return
        End If

        ' Append email address and password to the file
        Dim filePath = "C:\RelentlessSMS\EmailInformation\EmailAddresses.txt"
        Dim emailLine = $"{txtEmailAddresses.Text.Trim} {txtEmailPassword.Text.Trim}"
        File.AppendAllText(filePath, $"{emailLine}{Environment.NewLine}")

        ' Clear the text boxes
        txtEmailAddresses.Clear()
        txtEmailPassword.Clear()

        ' Show success message
        MessageBox.Show("Email address and password added successfully.")
    End Sub

    Public Function IsValidEmail(email As String) As Boolean

        Try
            Dim mailAddress = New System.Net.Mail.MailAddress(email)
            Return mailAddress.Address = email
        Catch ex As Exception
            Return False
        End Try

    End Function

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)

        Dim path = "C:\RelentlessSMS\APIs"
        Process.Start("explorer.exe", path)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        ' Launch the default browser and navigate to the webpage URL
        Dim url = "https://www.ipqualityscore.com/phone-number-validator"
        Process.Start(New ProcessStartInfo With {.FileName = url, .UseShellExecute = True})
    End Sub

    Private Sub lblLinkHome_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lblLinkHome.LinkClicked
        ' Launch the default browser and navigate to the webpage URL
        Dim url As String = "https://textbelt.com/purchase/?generateKey=1"
        Process.Start(New ProcessStartInfo With {.FileName = url, .UseShellExecute = True})
    End Sub



    Private Async Sub btnRunScraper_Click(sender As Object, e As EventArgs)
        Try
            If String.IsNullOrWhiteSpace(tbShodanAPI.Text) OrElse
           String.IsNullOrWhiteSpace(tbZoomEyeAPI.Text) OrElse
           String.IsNullOrWhiteSpace(tbSecurityTrailsAPI.Text) OrElse
           String.IsNullOrWhiteSpace(tbSerpAPI.Text) Then

                MessageBox.Show("All four API keys are required.", "Missing Keys", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Open scraper console
            Dim console As New frmScraperConsole
            console.Show()

            ' Run scraper with live output
            Await DiscoverMailmanProvidersAsync(
            tbShodanAPI.Text.Trim,
            tbZoomEyeAPI.Text.Trim,
            tbSecurityTrailsAPI.Text.Trim,
            tbSerpAPI.Text.Trim,
            "C:\RelentlessSMS\Mailman\signup_urls.txt",
            console
        )

        Catch ex As Exception
            MessageBox.Show("❌ Scraper failed: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    Private Sub btnSaveAPIs_Click(sender As Object, e As EventArgs)
        Try
            Dim apiPath = "C:\RelentlessSMS\APIs\MailmanAPIs.txt"

            Dim apiLines As New List(Of String) From {
            tbShodanAPI.Text.Trim,
            tbZoomEyeAPI.Text.Trim,
            tbSecurityTrailsAPI.Text.Trim,
            tbSerpAPI.Text.Trim
        }

            File.WriteAllLines(apiPath, apiLines)
            MessageBox.Show("✅ Mailman API keys saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)

        Catch ex As Exception
            MessageBox.Show("❌ Failed to save Mailman API keys: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

End Class