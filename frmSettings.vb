Imports System.IO

Public Class frmSettings

    ' =======================================================================================
    ' Form Load — Initializes all fields and loads saved API key data from file
    ' =======================================================================================
    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.BringToFront() ' Brings settings form in front of main window

        LoadIPQualityScoreAPI()
        LoadTextNowAPI()

        ' Load Mailman-related API keys from saved file
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

    ' =======================================================================================
    ' Save a new TextNow API key (if unique) into the file
    ' =======================================================================================
    Private Sub btnAddTextNowAPI_Click(sender As Object, e As EventArgs) Handles btnAddTextNowAPI.Click
        Dim filePath As String = "C:\RelentlessSMS\APIs\TextNowAPI.txt"
        Dim new_api As String = txtTextNowAPI.Text.Trim()

        If String.IsNullOrEmpty(new_api) Then
            MessageBox.Show("Please enter an API key.")
            Return
        End If

        Dim apis As List(Of String) = File.ReadAllLines(filePath).ToList()
        If Not apis.Contains(new_api) Then
            apis.Add(new_api)
            File.WriteAllLines(filePath, apis)
            MessageBox.Show("✅ API saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("API already exists in the list.")
        End If
    End Sub

    ' =======================================================================================
    ' Save IPQualityScore API key (overwrite with latest input)
    ' =======================================================================================
    Private Sub btnIPQualityScore_Click(sender As Object, e As EventArgs) Handles btnIPQualityScore.Click
        Dim new_api As String = txtIPQualityScore.Text.Trim()
        Dim path As String = "C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt"

        If String.IsNullOrEmpty(new_api) Then
            MessageBox.Show("Please enter the IPQualityScore API key.")
            Return
        End If

        File.WriteAllText(path, new_api)
        MessageBox.Show("✅ IPQualityScore API key saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' =======================================================================================
    ' Load the IPQualityScore API key from file and display it
    ' =======================================================================================
    Private Sub LoadIPQualityScoreAPI()
        Dim path As String = "C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt"
        If File.Exists(path) Then
            txtIPQualityScore.Text = File.ReadAllText(path).Trim()
        End If
    End Sub

    ' =======================================================================================
    ' Load all saved TextNow API keys into the textbox
    ' =======================================================================================
    Private Sub LoadTextNowAPI()
        Dim path As String = "C:\RelentlessSMS\APIs\TextNowAPI.txt"
        If File.Exists(path) Then
            txtTextNowAPI.Clear()
            For Each line In File.ReadLines(path)
                txtTextNowAPI.AppendText(line & vbCrLf)
            Next
        End If
    End Sub

    ' =======================================================================================
    ' Save all 4 Mailman API keys to file (one per line)
    ' =======================================================================================
    Private Sub btnSaveAPIs_Click(sender As Object, e As EventArgs) Handles btnSaveAPIs.Click
        Try
            Dim apiPath As String = "C:\RelentlessSMS\APIs\MailmanAPIs.txt"
            Dim apiLines As New List(Of String) From {
                tbShodanAPI.Text.Trim(),
                tbZoomEyeAPI.Text.Trim(),
                tbSecurityTrailsAPI.Text.Trim(),
                tbSerpAPI.Text.Trim()
            }

            File.WriteAllLines(apiPath, apiLines)
            MessageBox.Show("✅ Mailman API keys saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("❌ Failed to save Mailman API keys: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =======================================================================================
    ' Launch the scraper and show live output in frmScraperConsole
    ' =======================================================================================
    Private Async Sub btnRunScraper_Click(sender As Object, e As EventArgs) Handles btnRunScraper.Click
        Try
            Dim console As New frmScraperConsole()
            console.Show()

            Await x.DiscoverMailmanProvidersAsync(
                tbShodanAPI.Text.Trim(),
                tbZoomEyeAPI.Text.Trim(),
                tbSecurityTrailsAPI.Text.Trim(),
                tbSerpAPI.Text.Trim(),
                "C:\RelentlessSMS\Mailman\signup_urls.txt",
                console
            )
        Catch ex As Exception
            MessageBox.Show("❌ Error running scraper: " & ex.Message)
        End Try
    End Sub

    ' =======================================================================================
    ' Save SMTP server info to file for outbound emails
    ' =======================================================================================
    Private Sub btnAddSMTP_Click(sender As Object, e As EventArgs) Handles btnAddSMTP.Click
        If String.IsNullOrWhiteSpace(txtSMTPbox.Text) OrElse
           String.IsNullOrWhiteSpace(txtPort.Text) OrElse
           Not Integer.TryParse(txtPort.Text, Nothing) Then

            MessageBox.Show("Please enter valid SMTP server and port.")
            Return
        End If

        Dim enableSSL As String = If(cbEnableSSL.SelectedIndex = 1, "True", "False")
        Dim path As String = "C:\RelentlessSMS\EmailInformation\SMTP.txt"
        Dim content As String = $"{txtSMTPbox.Text.Trim()}{vbCrLf}{txtPort.Text.Trim()}{vbCrLf}{enableSSL}"

        File.WriteAllText(path, content)
        MessageBox.Show("✅ SMTP settings saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' =======================================================================================
    ' Save email address + password to EmailAddress.txt
    ' =======================================================================================
    Private Sub btnAddEmailPass_Click(sender As Object, e As EventArgs) Handles btnAddEmailPass.Click
        If String.IsNullOrWhiteSpace(txtEmailAddresses.Text) OrElse
           String.IsNullOrWhiteSpace(txtEmailPassword.Text) Then
            MessageBox.Show("Please enter both email address and password.")
            Return
        End If

        If Not IsValidEmail(txtEmailAddresses.Text.Trim()) Then
            MessageBox.Show("Invalid email address.")
            Return
        End If

        Dim path As String = "C:\RelentlessSMS\EmailInformation\EmailAddresses.txt"
        Dim entry As String = $"{txtEmailAddresses.Text.Trim()} {txtEmailPassword.Text.Trim()}"
        File.AppendAllText(path, entry & Environment.NewLine)

        txtEmailAddresses.Clear()
        txtEmailPassword.Clear()

        MessageBox.Show("✅ Email and password saved.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ' =======================================================================================
    ' Validate email formatting
    ' =======================================================================================
    Public Function IsValidEmail(email As String) As Boolean
        Try
            Dim addr = New System.Net.Mail.MailAddress(email)
            Return addr.Address = email
        Catch
            Return False
        End Try
    End Function

    ' =======================================================================================
    ' Opens relevant website for API signup based on which link was clicked
    ' =======================================================================================
    Private Sub LinkLabel_Click(sender As Object, e As LinkLabelLinkClickedEventArgs) _
        Handles lblIPQuality.LinkClicked, lblTEXTBELT.LinkClicked, lblShodan.LinkClicked,
                lblZoomeye.LinkClicked, lblSecurityTrails.LinkClicked, lblSerpAPI.LinkClicked

        Dim url As String = ""
        Select Case CType(sender, LinkLabel).Name
            Case "lblIPQuality"
                url = "https://www.ipqualityscore.com/phone-number-validator"
            Case "lblTEXTBELT"
                url = "https://textbelt.com/purchase/?generateKey=1"
            Case "lblShodan"
                url = "https://account.shodan.io/register"
            Case "lblZoomeye"
                url = "https://www.zoomeye.org/login"
            Case "lblSecurityTrails"
                url = "https://securitytrails.com/app/account"
            Case "lblSerpAPI"
                url = "https://serpapi.com/users/sign_up"
        End Select

        If Not String.IsNullOrEmpty(url) Then
            Process.Start(New ProcessStartInfo With {.FileName = url, .UseShellExecute = True})
        End If
    End Sub

    ' =======================================================================================
    ' Close the Settings form
    ' =======================================================================================
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

End Class
