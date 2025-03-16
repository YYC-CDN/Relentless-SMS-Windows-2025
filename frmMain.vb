' 3/1/2023
' Made by ░▒▓█│【MrBungle】│█▓▒░

'  https://www.ipqualityscore.com/user/search
' https://www.ipqualityscore.com/user/phone-number-validation-api

Option Explicit On
Imports System.IO
Imports System
Imports System.Net
Imports System.Net.Http
Imports System.Text
Imports System.Text.RegularExpressions
Imports Newtonsoft.Json.Linq
Imports SHDocVw
Imports Microsoft.Web.WebView2.Core
Imports Microsoft.Web
Imports System.Threading
Imports Microsoft.Web.WebView2.WinForms
Imports System.Diagnostics.Metrics
Imports Newtonsoft.Json.Serialization
Imports System.Diagnostics
Imports HtmlAgilityPack
Imports System.Threading.Tasks

Public Class frmMain
    Private imageFiles As String()
    Private random As New Random()
    Private provider_options As Dictionary(Of String, List(Of String))
    Private fileSaveDate As DateTime
    Private cancelTokenSource As CancellationTokenSource
    Private httpClient As New HttpClient()
    Private targetHistory As New AutoCompleteStringCollection()


    ' =======================================================================================
    ' Form Load - Start Timer and Initial Fetch
    ' =======================================================================================
    Private Sub FrmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Set the form's title with the version and government use disclaimer
        Me.Text = $"Version 031525-01 |  FOR OFFICIAL USE ONLY (FOUO) | Protected Critical Infrastructure Information (PCII): "

        ' Initialize startup tasks
        x.startup()
        x.buildfiles() ' Initialize files if needed
        x.InitializeProvidersFile()

        LoadTargetHistory() ' Load history at startup

        txtTargetNumber.ReadOnly = False
        cbImagesCheckbox.Checked = False
        txtVerificationResults.Clear()

        Dim default_api As String = LoadAPI()
        Dim apiProxy As String = LoadProxyDetectionAPI()

        dbOutgoingLanguage.Text = "English (Default)"
        For Each language In language_options
            dbOutgoingLanguage.Items.Add(language.Key)
        Next

        txtTargetNumber.ForeColor = Color.FromArgb(209, 219, 221)
        txtNumberofMessages.ForeColor = Color.FromArgb(209, 219, 221)
        txtSecondsBetween.ForeColor = Color.FromArgb(209, 219, 221)

        ' Initialize AutoComplete
        txtTargetNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend
        txtTargetNumber.AutoCompleteSource = AutoCompleteSource.CustomSource
        LoadTargetHistory()

        Try
            FetchProxyDetails()
        Catch ex As Exception
            ' Ignore fetch errors
        End Try

        VPN_Timer.Interval = 10000
        VPN_Timer.Start()
        FetchProxyDetails()

        ' Set directory path for storing files
        Dim directoryPath As String = "C:\RelentlessSMS"

        ' Enable the target number textbox for user input
        txtTargetNumber.ReadOnly = False

        ' Uncheck the checkbox for images on startup
        cbImagesCheckbox.Checked = False

        ' Clear any previous content in the verification results textbox on load
        txtVerificationResults.Clear()


        ' Set the default language for the dropdown box
        dbOutgoingLanguage.Text = "English (Default)"

        ' Populate the language dropdown box with available languages
        For Each language In language_options
            dbOutgoingLanguage.Items.Add(language.Key)
        Next

        ' Set the font color of textboxes for consistency
        txtTargetNumber.ForeColor = Color.FromArgb(209, 219, 221)
        txtNumberofMessages.ForeColor = Color.FromArgb(209, 219, 221)
        txtSecondsBetween.ForeColor = Color.FromArgb(209, 219, 221)

        ' Set the informational message with increased font size
        txtVerificationResults.SelectionStart = txtVerificationResults.TextLength
        txtVerificationResults.SelectionFont = New Font(txtVerificationResults.Font.FontFamily, txtVerificationResults.Font.Size + 3, FontStyle.Bold)
        txtVerificationResults.AppendText("We want to emphasize that using this tool ethically and responsibly is of utmost importance. It is critical to research and verify your target before using this tool, as using it on someone without proper justification can have severe consequences. This tool is intended for educational or testing purposes only and should not be used to harm or harass anyone. This service is provided 'as is' and with no express or implied warranties, endorsements, or associations. We assume no responsibility for any damages or losses resulting from your use of this service. Let's always use technology with integrity and responsibility." & vbCrLf)
        txtVerificationResults.SelectionFont = New Font(txtVerificationResults.Font.FontFamily, txtVerificationResults.Font.Size, FontStyle.Regular)

        ' Set default number of open tabs for MailBait tool
        txtOpenTabs.Text = "50"

        ' Initialize the provider options dictionary
        provider_options = New Dictionary(Of String, List(Of String))()

        ' Load provider options from the file line by line
        For Each line As String In File.ReadLines("C:\RelentlessSMS\Providers.txt")
            If Not line.StartsWith("#") AndAlso Not String.IsNullOrWhiteSpace(line) Then  ' Ignore commented or empty lines
                Dim parts As String() = line.Split(","c)   ' Split the line into provider name and email domain
                If parts.Length = 2 Then
                    Dim provider As String = parts(0).Trim() ' Trim leading/trailing whitespaces from provider
                    Dim emailDomain As String = parts(1).Trim() ' Trim whitespaces from email domain

                    ' Add email domains to the provider options dictionary
                    If provider_options.ContainsKey(provider) Then
                        provider_options(provider).Add(emailDomain) ' Add domain if provider already exists
                    Else
                        provider_options.Add(provider, New List(Of String) From {emailDomain}) ' Create new list if provider doesn't exist
                    End If
                End If
            End If
        Next

        ' Populate the ComboBox with available provider keys
        dbSelectCellProvider.Items.AddRange(provider_options.Keys.ToArray())

        ' Fetch and display proxy details from API
        Try
            FetchProxyDetails()
        Catch ex As Exception
            ' Handle any errors when fetching proxy details (no UI message shown here)
        End Try

        ' Initialize VPN Update Timer to trigger every 10 seconds
        VPN_Timer.Interval = 10000 ' Set interval (10 seconds) for regular VPN status updates
        VPN_Timer.Start() ' Start the timer

        ' Perform initial fetch for proxy details
        FetchProxyDetails()

    End Sub

    ' =======================================================================================
    ' Load Provider Options
    ' =======================================================================================
    Private Sub LoadProviderOptions()
        provider_options = New Dictionary(Of String, List(Of String))()

        If File.Exists(x.ProvidersPath) Then
            For Each line As String In File.ReadLines(x.ProvidersPath)
                If Not line.StartsWith("#") AndAlso Not String.IsNullOrWhiteSpace(line) Then
                    Dim parts As String() = line.Split(","c)
                    If parts.Length = 2 Then
                        Dim provider As String = parts(0).Trim()
                        Dim emailDomain As String = parts(1).Trim()

                        If provider_options.ContainsKey(provider) Then
                            provider_options(provider).Add(emailDomain)
                        Else
                            provider_options.Add(provider, New List(Of String) From {emailDomain})
                        End If
                    End If
                End If
            Next
        End If

        dbSelectCellProvider.Items.AddRange(provider_options.Keys.ToArray())
    End Sub




    ' =======================================================================================
    ' Fetch Proxy, VPN, and Region Details
    ' =======================================================================================

    Private Async Sub FetchProxyDetails()
        Try
            If Not File.Exists(x.ApiKeyPath) Then Exit Sub

            Dim apiKey As String = File.ReadAllText(x.ApiKeyPath).Trim()
            Dim ipAddress As String = Await GetIPAddressAsync()
            Dim apiUrl As String = $"https://www.ipqualityscore.com/api/json/ip/{apiKey}/{ipAddress}"

            ' Use TLS 1.2+
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            ' Send API request
            Using client As New HttpClient()
                Dim responseJson As String = Await client.GetStringAsync(apiUrl).ConfigureAwait(False)
                Dim responseObj As JObject = JObject.Parse(responseJson)

                ' Extract Proxy & VPN Data
                Dim proxyValue As String = responseObj("proxy")?.ToString()
                Dim regionValue As String = responseObj("region")?.ToString()
                Dim vpnValue As String = responseObj("vpn")?.ToString()

                ' Update UI
                lblVPN.Text = "VPN: " & If(Not String.IsNullOrEmpty(vpnValue), vpnValue, "Not Available")
                lblRegion.Text = "Region: " & If(Not String.IsNullOrEmpty(regionValue), regionValue, "Not Available")
                lblProxy.Text = "Proxy: " & If(Not String.IsNullOrEmpty(proxyValue), proxyValue, "Not Available")
            End Using

        Catch ex As Exception
            ' Suppressed errors
        End Try




        Try
            ' Read API key from file
            Dim apiKeyFilePath As String = "C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt"
            If Not File.Exists(apiKeyFilePath) Then
                'MessageBox.Show("API key file not found. Please add one in Settings.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            Dim apiKey As String = File.ReadAllText(apiKeyFilePath).Trim()

            ' Get Public IP Address
            Dim ipAddress As String = Await GetIPAddressAsync()
            Dim apiUrl As String = $"https://www.ipqualityscore.com/api/json/ip/{apiKey}/{ipAddress}"

            ' Force the application to use TLS 1.2+
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12

            ' Send API request
            Using client As New HttpClient()
                Dim responseJson As String = Await client.GetStringAsync(apiUrl).ConfigureAwait(False)
                Dim responseObj As JObject = JObject.Parse(responseJson)

                ' Extract Proxy & VPN Data
                Dim proxyValue As String = responseObj("proxy")?.ToString()
                Dim countryCodeValue As String = responseObj("country_code")?.ToString()
                Dim regionValue As String = responseObj("region")?.ToString()
                Dim vpnValue As String = responseObj("vpn")?.ToString()

                ' Update UI Labels Safely
                If lblVPN.InvokeRequired Then
                    lblVPN.Invoke(Sub() lblVPN.Text = "VPN: " & If(Not String.IsNullOrEmpty(vpnValue), vpnValue, "Not Available"))
                    lblRegion.Invoke(Sub() lblRegion.Text = "Region: " & If(Not String.IsNullOrEmpty(regionValue), regionValue, "Not Available"))
                    lblProxy.Invoke(Sub() lblProxy.Text = "Proxy: " & If(Not String.IsNullOrEmpty(proxyValue), proxyValue, "Not Available"))
                    lblCountryCode.Invoke(Sub() lblCountryCode.Text = "Country Code: " & If(Not String.IsNullOrEmpty(countryCodeValue), countryCodeValue, "Not Available"))
                Else
                    lblVPN.Text = "VPN: " & If(Not String.IsNullOrEmpty(vpnValue), vpnValue, "Not Available")
                    lblRegion.Text = "Region: " & If(Not String.IsNullOrEmpty(regionValue), regionValue, "Not Available")
                    lblProxy.Text = "Proxy: " & If(Not String.IsNullOrEmpty(proxyValue), proxyValue, "Not Available")
                    lblCountryCode.Text = "Country Code: " & If(Not String.IsNullOrEmpty(countryCodeValue), countryCodeValue, "Not Available")
                End If
            End Using

        Catch ex As HttpRequestException
            'MessageBox.Show("Error fetching VPN data: Network issue - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As TaskCanceledException
            'MessageBox.Show("Error fetching VPN data: Request timed out - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As WebException
            'MessageBox.Show("Error fetching VPN data: Web error - " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Catch ex As Exception
            'MessageBox.Show("Error fetching VPN data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub



    ' =======================================================================================
    ' Fetch Public IP Address
    ' =======================================================================================
    Private Async Function GetIPAddressAsync() As Task(Of String)
        Try
            Using client As New HttpClient()
                Return Await client.GetStringAsync("https://api.ipify.org").ConfigureAwait(False)
            End Using
        Catch ex As Exception
            Return "Unknown"
        End Try
    End Function


    ' =======================================================================================
    ' Declare Auto-Complete Collection
    ' =======================================================================================
    Private AutoCompleteCollection As New AutoCompleteStringCollection()

    ' =======================================================================================
    ' Load Target History for Auto-Complete
    ' =======================================================================================
    Private Sub LoadTargetHistory()
        ' Check if the history file exists before reading
        If File.Exists(x.TargetHistoryPath) Then
            ' Read all lines from history file
            Dim history As String() = File.ReadAllLines(x.TargetHistoryPath)

            ' Clear and update the AutoComplete source
            AutoCompleteCollection.Clear()
            AutoCompleteCollection.AddRange(history)

            ' Apply AutoComplete settings to txtTargetNumber
            txtTargetNumber.AutoCompleteMode = AutoCompleteMode.SuggestAppend
            txtTargetNumber.AutoCompleteSource = AutoCompleteSource.CustomSource
            txtTargetNumber.AutoCompleteCustomSource = AutoCompleteCollection
        End If
    End Sub

    ' =======================================================================================
    ' Save Target Entry to History
    ' =======================================================================================
    Private Sub SaveToTargetHistory(target As String)
        ' Ensure target is valid before saving
        If Not String.IsNullOrWhiteSpace(target) AndAlso Not AutoCompleteCollection.Contains(target) Then
            ' Add the target to AutoComplete collection
            AutoCompleteCollection.Add(target)

            ' Append the new target to the history file
            File.AppendAllText(x.TargetHistoryPath, target & Environment.NewLine)

            ' Reapply AutoComplete settings
            txtTargetNumber.AutoCompleteCustomSource = AutoCompleteCollection
        End If
    End Sub








    ' =======================================================================================
    ' Timer Tick Event - Refresh Data Every Interval
    ' =======================================================================================
    Private Sub VPN_Timer_Tick(sender As Object, e As EventArgs) Handles VPN_Timer.Tick
        FetchProxyDetails()
    End Sub


    ' =======================================================================================
    ' Load API Keys from Files
    ' =======================================================================================
    Private Function LoadAPI() As String
        Try
            Return File.ReadAllText("C:\RelentlessSMS\APIs\TextNowAPI.txt").Trim()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function

    Private Function LoadProxyDetectionAPI() As String
        Try
            Return File.ReadAllText("C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt").Trim()
        Catch ex As Exception
            Return String.Empty
        End Try
    End Function


    Private Sub txtTargetNumber_TextChanged(sender As Object, e As EventArgs) Handles txtTargetNumber.TextChanged


        Dim targetNumber As String = txtTargetNumber.Text.Trim()
        Dim hasAtSymbol As Boolean = targetNumber.Contains("@")
        Dim numericInput As String = New String(targetNumber.Where(Function(c) Char.IsDigit(c)).ToArray())
        Dim hasTenDigits As Boolean = numericInput.Length >= 10

        ' Enable or disable buttons
        btnSendSMS.Enabled = Not hasAtSymbol AndAlso hasTenDigits
        btnEmailToSMS.Enabled = hasAtSymbol
        btnMailbaitSubmit.Enabled = hasAtSymbol
        btnMailman.Enabled = hasAtSymbol

        ' Save valid input to history
        If (hasAtSymbol OrElse hasTenDigits) AndAlso Not String.IsNullOrWhiteSpace(targetNumber) Then
            SaveToTargetHistory(targetNumber)
        End If


        ' List of characters to remove ( (, ), and space )
        Dim charsToRemove As Char() = {"(", ")", " "}

        ' Remove unwanted characters ( (, ), and spaces)
        For Each c As Char In charsToRemove
            targetNumber = targetNumber.Replace(c, "")
        Next


        ' Enable or disable buttons based on the presence of the "@" symbol
        btnSendSMS.Enabled = Not hasAtSymbol
        btnEmailToSMS.Enabled = Not (hasAtSymbol OrElse targetNumber.StartsWith("@"))
        btnMailbaitSubmit.Enabled = hasAtSymbol
        btnMailman.Enabled = hasAtSymbol



        ' Enable or disable SMS-related buttons based on the number of digits
        btnSendSMS.Enabled = btnSendSMS.Enabled AndAlso hasTenDigits
        btnEmailToSMS.Enabled = btnEmailToSMS.Enabled AndAlso hasTenDigits

        ' Check if the input contains a valid email address
        Dim isValidEmail As Boolean = IsValidEmailAddress(targetNumber)

        ' Enable or disable buttons based on whether the input is a phone number or an email
        If isValidEmail Then
            btnVerifyNumber.Enabled = False
            btnSendSMS.Enabled = False
            btnEmailValidation.Enabled = True
            btnMailbaitSubmit.Enabled = True
            btnEmailToSMS.Enabled = True
            btnMailman.Enabled = True
        Else
            btnVerifyNumber.Enabled = True
            btnEmailValidation.Enabled = False
            btnMailbaitSubmit.Enabled = False
            btnMailman.Enabled = False
        End If

        ' =======================================================================================
        ' Detect Email or Number, Save to History & Enable Auto-Complete
        ' =======================================================================================
        btnSendSMS.Enabled = Not hasAtSymbol AndAlso hasTenDigits
        btnEmailToSMS.Enabled = hasAtSymbol
        btnMailbaitSubmit.Enabled = hasAtSymbol
        btnMailman.Enabled = hasAtSymbol

        ' ✅ Save to Target History if it's a valid input
        If (hasAtSymbol OrElse hasTenDigits) AndAlso Not String.IsNullOrWhiteSpace(targetNumber) Then
            SaveToTargetHistory(targetNumber)
        End If
    End Sub

    ' =======================================================================================
    ' Validate Email Address
    ' =======================================================================================
    Private Function IsValidEmailAddress(email As String) As Boolean
        Return email.Contains("@") AndAlso email.Contains(".") AndAlso Not email.StartsWith("@") AndAlso Not email.EndsWith("@") AndAlso Not email.StartsWith(".") AndAlso Not email.EndsWith(".")
    End Function



    Private Sub cbImagesCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles cbImagesCheckbox.CheckedChanged
        Dim isCheckboxChecked As Boolean = cbImagesCheckbox.Checked

        btnEmailToSMS.Enabled = Not isCheckboxChecked
        btnSendSMS.Enabled = Not isCheckboxChecked
        btnMailbaitSubmit.Enabled = Not isCheckboxChecked
        btnVerifyNumber.Enabled = Not isCheckboxChecked
        btnEmailValidation.Enabled = Not isCheckboxChecked
        ' ... disable other buttons as needed
    End Sub

    Private Function ValidateNumber(number As String) As Boolean
        ' Add "+1" to the beginning of the number
        number = "+1" & number
        ' all the current and reserved toll-free area codes in the USA and Canada.
        Dim toll_free_pattern As String = "^\+1(800|822|833|844|855|866|877|880|881|882|883|884|885|886|887|888)[0-9]{7}$"

        If Regex.IsMatch(number, toll_free_pattern) Then
            ' Show error message if the phone number is a toll-free number
            MessageBox.Show("Cannot send SMS to toll-free numbers, you silly goose. ")
            Return False
        End If
        Return True
    End Function

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Application.Exit()
    End Sub

    Private Sub btnEmailToSMS_Click(sender As Object, e As EventArgs) Handles btnEmailToSMS.Click


        ' =======================================================================================
        ' Validate Target Input and Display Robust VPN Warning
        ' =======================================================================================
        Dim vpnStatus As String = lblVPN.Text
        Dim regionStatus As String = lblRegion.Text

        ' Check if the input is empty or not a valid email format
        If String.IsNullOrEmpty(txtTargetNumber.Text) OrElse Not txtTargetNumber.Text.Contains("@") Then
            MessageBox.Show("Please enter a valid target email address OR cellular provider address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ' =======================================================================================
        ' Display VPN Warning Before Proceeding
        ' =======================================================================================
        Dim warningMessage As String = "⚠ IMPORTANT: Check your VPN before proceeding! ⚠" & vbCrLf & vbCrLf &
                               $"🔹 VPN Status: {vpnStatus}" & vbCrLf &
                               $"🔹 Region: {regionStatus}" & vbCrLf & vbCrLf &
                               "Your IP address may be exposed if your VPN is not properly enabled." & vbCrLf &
                               "Ensure you are connected before proceeding to avoid detection." & vbCrLf & vbCrLf &
                               "🔹 Click 'Yes' to proceed." & vbCrLf &
                               "🔹 Click 'No' to cancel this operation."

        Dim result As DialogResult = MessageBox.Show(warningMessage, "⚠ VPN Warning - Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        If result = DialogResult.No Then
            MessageBox.Show("Operation canceled by user.", "Submission Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return
        End If

        If dbSelectCellProvider.SelectedItem IsNot Nothing Then ' Check if a cellular provider has been selected.
            ' Check if a target number has been entered.
            If txtTargetNumber.Text.Trim() <> "" Then
                ' Ask the user to verify the target number and number of messages.
                Dim verifyTargetNumber As DialogResult = MessageBox.Show("Is " & txtTargetNumber.Text & " the correct target number with " & txtNumberofMessages.Text & " messages?", "Confirm Target Number and Number of Messages", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)
                If verifyTargetNumber = DialogResult.Yes Then
                    ' Send the email message as SMS.
                    Dim selected_provider As String = dbSelectCellProvider.SelectedItem.ToString()
                    SendEmailToSMS.sendemailtosms()
                    'Task.Run(Sub() SendEmailToSMS())
                End If
            Else
                ' Notify the user to enter a target number.
                MessageBox.Show("Please enter a target number.")
            End If
        Else
            ' Notify the user to select a cellular provider.
            MessageBox.Show("Please select a cellular provider.")
        End If


        ' Hide the spinning wheel cursor and re-enable the button
        'Me.UseWaitCursor = False

    End Sub






    Private Sub DbSelectCellProvider_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dbSelectCellProvider.SelectedIndexChanged
        ' Get the selected provider option
        Dim selected_provider As String = dbSelectCellProvider.SelectedItem.ToString()
        ' Get the corresponding email domains list from the provider options dictionary
        Dim email_domains As List(Of String) = provider_options(selected_provider)

        ' Select the first email domain from the list
        Dim email_domain As String = email_domains(0)

        ' Update the txtTargetNumber field with the email domain, if applicable
        If txtTargetNumber.Text.Contains("@") Then
            ' Replace the domain
            txtTargetNumber.Text = Regex.Replace(txtTargetNumber.Text, "@.*\.", email_domain & ".")
        Else
            ' Append the domain
            txtTargetNumber.Text = txtTargetNumber.Text & email_domain
        End If
    End Sub



    ' Define the provider options dictionary
    Dim language_options As New Dictionary(Of String, String) From {
    {"English (Default)", "en"},
    {"Chinese", "zh"},
    {"Hindi", "hi"}
    }
    '{"Punjabi", "pa"},
    '{"Russian", "ru"},
    '{"North Korean", "ko"},
    '{"Nigerian", "yo"},
    '{"International", "auto"}

    Private Sub btnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        Dim settingsForm As New frmSettings()
        settingsForm.Show()
    End Sub

    Private Sub txtTargetNumber_Click(sender As Object, e As EventArgs) Handles txtTargetNumber.Click

        ' Set the text color to 209, 219, 221- the off white color
        'txtTargetNumber.ForeColor = Color.FromArgb(209, 219, 221)

    End Sub

    Private Sub btnSendSMS_Click(sender As Object, e As EventArgs) Handles btnSendSMS.Click
        ' Show the spinning wheel cursor
        'Me.UseWaitCursor = True
        ' Check if the target number textbox is empty
        If String.IsNullOrEmpty(txtTargetNumber.Text.Trim()) Then
            MessageBox.Show("Please enter a target number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            Return
        End If

        ' Ask for confirmation of the number of messages to be sent
        Dim numberOfMessages As Integer
        Dim vpnStatus As String = lblVPN.Text
        Dim regionStatus As String = lblRegion.Text

        Dim confirmDialog As DialogResult = If(Integer.TryParse(txtNumberofMessages.Text, numberOfMessages),
            MessageBox.Show(
                $"WARNING: Please check your VPN before proceeding!" & vbCrLf &
                $"VPN Status: {vpnStatus}" & vbCrLf &
                $"Region: {regionStatus}" & vbCrLf & vbCrLf &
                $"Are you sure you want to send {numberOfMessages} messages to {txtTargetNumber.Text}?",
                "Confirm Message Sending - VPN Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation),
            DialogResult.No)

        If confirmDialog = DialogResult.Yes Then
            ' Proceed with sending SMS
            SendSMS.SendSMS()
        End If

        'End If
        'Else
        'MessageBox.Show("Invalid number of messages.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        '  End If
        ' Hide the spinning wheel cursor and re-enable the button
        'Me.UseWaitCursor = False
    End Sub


    Private Sub btnVerifyNumber_Click(sender As Object, e As EventArgs) Handles btnVerifyNumber.Click

        Try

            Dim apiKeyFilePath As String = "C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt" ' Read the API key from the text file.
            Dim apiKey As String = ""

            If Not System.IO.File.Exists(apiKeyFilePath) Then
                MessageBox.Show("API key file not found. Please go to Settings and add one. Basic use keys are no cost. ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            apiKey = System.IO.File.ReadAllText(apiKeyFilePath).Trim()


            Dim countryCode As String = "1" ' Set the default country code to +1 or USA/Canada.


            Dim phoneNumber As String = txtTargetNumber.Text.Trim() ' Append country code to phone number if not already present.
            If Not phoneNumber.StartsWith("+") Then
                phoneNumber = "+" & countryCode & phoneNumber
            End If

            ' Build the API request URL.
            Dim apiUrl As String = "https://www.ipqualityscore.com/api/json/phone/" & apiKey & "/" & phoneNumber & "?strictness=1"

            ' Send the API request.
            Dim client As New WebClient()
            Dim responseJson As String = client.DownloadString(apiUrl)

            ' Parse the API response.
            Dim responseObj As JObject = JObject.Parse(responseJson)

            ' Display the verification results.
            txtVerificationResults.Text = "Active: " & responseObj("active").ToString() & vbCrLf
            txtVerificationResults.Text += "Fraud Score: " + responseObj("fraud_score").ToString() + vbCrLf
            txtVerificationResults.Text += "Recent Abuse: " + responseObj("recent_abuse").ToString() + vbCrLf
            txtVerificationResults.Text += "VOIP: " + responseObj("VOIP").ToString() + vbCrLf
            txtVerificationResults.Text += "Prepaid: " + responseObj("prepaid").ToString() + vbCrLf
            txtVerificationResults.Text += "Dialing Code: " + responseObj("dialing_code").ToString() + vbCrLf
            txtVerificationResults.Text += "Local Format: " + responseObj("local_format").ToString() + vbCrLf
            txtVerificationResults.Text += "Risky: " + responseObj("risky").ToString() + vbCrLf
            txtVerificationResults.Text += "Name: " + responseObj("name").ToString() + vbCrLf
            txtVerificationResults.Text += "**Carrier:**  " + responseObj("carrier").ToString() + vbCrLf
            txtVerificationResults.Text += "Line Type: " + responseObj("line_type").ToString() + vbCrLf
            txtVerificationResults.Text += "Region: " + responseObj("region").ToString() + vbCrLf
            txtVerificationResults.Text += "City: " + responseObj("city").ToString() + vbCrLf
            txtVerificationResults.Text += "Zip Code: " + responseObj("zip_code").ToString() + vbCrLf
            txtVerificationResults.Text += "Leaked: " + responseObj("leaked").ToString() + vbCrLf
            txtVerificationResults.Text += "Spammer: " + responseObj("spammer").ToString() + vbCrLf
            txtVerificationResults.Text += "Do Not Call: " + responseObj("do_not_call").ToString() + vbCrLf
            txtVerificationResults.Text += "User Activity: " + responseObj("user_activity").ToString() + vbCrLf
            txtVerificationResults.Text += "Message: " + responseObj("message").ToString() + vbCrLf
            txtVerificationResults.Text += "Errors: " + responseObj("errors").ToString() + vbCrLf
            txtVerificationResults.Text += "Associated emails found: " + responseObj("associated_email_addresses").ToString() + vbCrLf
            txtVerificationResults.Text += "END " + vbCrLf

        Catch ex As WebException
            Dim response As HttpWebResponse = CType(ex.Response, HttpWebResponse)
            Dim responseContent As String = New StreamReader(response.GetResponseStream()).ReadToEnd()
            MessageBox.Show("API Error: " + responseContent)

        Catch ex As Exception
            'MessageBox.Show("Error: " + ex.Message)
        End Try

    End Sub

    Private counter As Integer = 0
    Private tabsToOpen As Integer = 0

    ' =======================================================================================
    ' Handles Mailbait Submission Process
    ' =======================================================================================
    Private Async Sub btnMailbaitSubmit_Click(sender As Object, e As EventArgs) Handles btnMailbaitSubmit.Click
        Try
            ' Validate the number of open tabs input
            Dim openTabsCount As Integer = 0
            If Not Integer.TryParse(txtOpenTabs.Text, openTabsCount) Then
                MessageBox.Show("Please enter a valid number of tabs to open.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' =======================================================================================
            ' Display Warning Prompt Before Execution (With VPN & Region Status)
            ' =======================================================================================
            Dim vpnStatus As String = lblVPN.Text
            Dim regionStatus As String = lblRegion.Text

            Dim message As String = "⚠ IMPORTANT: Activate your VPN before proceeding! ⚠" & vbCrLf & vbCrLf &
                        $"🔹 VPN Status: {vpnStatus}" & vbCrLf &
                        $"🔹 Region: {regionStatus}" & vbCrLf & vbCrLf &
                        "If you don't, your IP address will be exposed to the target." & vbCrLf & vbCrLf &
                        $"You have selected to open {openTabsCount} session(s) to multiple spam outlets." & vbCrLf &
                        "To maximize impact, consider running a significant number of sessions (50-75) over 48-72 hours." & vbCrLf & vbCrLf &
                        "🔹 Click 'Yes' to proceed." & vbCrLf &
                        "🔹 Click 'No' to cancel this operation."

            ' Show warning prompt
            Dim result As DialogResult = MessageBox.Show(message, "⚠ VPN Reminder - Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

            ' Exit if user cancels
            If result = DialogResult.No Then
                MessageBox.Show("Operation canceled by user.", "Submission Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

            ' Start progress bar animation
            pbAllFunctions.Style = ProgressBarStyle.Marquee
            pbAllFunctions.MarqueeAnimationSpeed = 50
            txtOutgoingMessages.Text = "🔄 Submitting target information to multiple spam outlets. Do not close."

            ' Initialize browser form
            Dim frmBrowser As New frmBrowser()
            frmBrowser.Visible = True

            ' Validate target email input
            If String.IsNullOrEmpty(txtTargetNumber.Text) OrElse Not txtTargetNumber.Text.Contains("@") Then
                MessageBox.Show("Please enter a valid target email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                Exit Sub
            End If

            ' Loop to open multiple WebView tabs
            For i As Integer = 1 To openTabsCount
                ' Define Mailbait URL
                Dim url As String = "http://mailbait.info/run"

                ' Create new tab and WebView2 instance
                Dim tabPage As New TabPage("Tab " & i)
                Dim webView As New WebView2()
                tabPage.Controls.Add(webView)
                webView.Dock = DockStyle.Fill
                frmBrowser.TabControl1.TabPages.Add(tabPage)

                ' Initialize WebView2 and navigate to URL
                AddHandler webView.CoreWebView2InitializationCompleted,
                Async Sub(sender2 As Object, e2 As CoreWebView2InitializationCompletedEventArgs)
                    Await webView.EnsureCoreWebView2Async(Nothing)
                    webView.CoreWebView2.Navigate(url)

                    ' Wait for page to load, then execute submission
                    AddHandler webView.CoreWebView2.NavigationCompleted,
                        Sub(sender3 As Object, e3 As CoreWebView2NavigationCompletedEventArgs)
                            ' Fill the email field
                            Dim emailAddress As String = txtTargetNumber.Text.Trim()
                            webView.CoreWebView2.ExecuteScriptAsync($"document.getElementById('.mbe').value = '{emailAddress}'")

                            ' Click "Run MailBait" button and uncheck categories checkbox
                            webView.CoreWebView2.ExecuteScriptAsync(
                                "var button = document.querySelector('input[value=""Run MailBait""]');" &
                                "if (button) { button.click(); }" &
                                "var checkbox = document.getElementById('categories1');" &
                                "if (checkbox && checkbox.checked) { checkbox.click(); }")

                            ' Track progress
                            counter += 1
                        End Sub
                End Sub

                Await webView.EnsureCoreWebView2Async(Nothing)
            Next

        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    ' =======================================================================================
    ' Handles the Email Validation Process
    ' This function retrieves email verification details using the IPQualityScore API.
    ' =======================================================================================
    Private Sub btnEmailValidation_Click(sender As Object, e As EventArgs) Handles btnEmailValidation.Click
        Try
            ' =======================================================================================
            ' Read the API key from the text file
            ' =======================================================================================
            Dim apiKeyFilePath As String = "C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt"
            Dim apiKey As String = ""

            ' Check if the API key file exists, otherwise show a warning and exit
            If Not File.Exists(apiKeyFilePath) Then
                MessageBox.Show("API key file not found. Please go to Settings and add one.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If

            ' Read the API key from the file and remove any trailing spaces
            apiKey = File.ReadAllText(apiKeyFilePath).Trim()

            ' =======================================================================================
            ' Get the email address to verify
            ' =======================================================================================
            Dim emailAddress As String = txtTargetNumber.Text.Trim()

            ' =======================================================================================
            ' Build the API request URL with the email address
            ' =======================================================================================
            Dim apiUrl As String = $"https://www.ipqualityscore.com/api/json/email/{apiKey}/{emailAddress}"

            ' =======================================================================================
            ' Send the API request
            ' =======================================================================================
            Dim client As New WebClient()
            Dim responseJson As String = client.DownloadString(apiUrl)

            ' =======================================================================================
            ' Parse the JSON response from the API
            ' =======================================================================================
            Dim responseObj As JObject = JObject.Parse(responseJson)

            ' =======================================================================================
            ' Display the email verification results in txtVerificationResults
            ' =======================================================================================
            txtVerificationResults.Text = "Valid: " & responseObj("valid").ToString() & vbCrLf
            txtVerificationResults.Text += "Disposable: " & responseObj("disposable").ToString() & vbCrLf
            txtVerificationResults.Text += "Deliverability: " & responseObj("deliverability").ToString() & vbCrLf
            txtVerificationResults.Text += "Catch All: " & responseObj("catch_all").ToString() & vbCrLf
            txtVerificationResults.Text += "Leaked: " & responseObj("leaked").ToString() & vbCrLf
            txtVerificationResults.Text += "Suspect: " & responseObj("suspect").ToString() & vbCrLf
            txtVerificationResults.Text += "SMTP Score: " & responseObj("smtp_score").ToString() & vbCrLf
            txtVerificationResults.Text += "Overall Score: " & responseObj("overall_score").ToString() & vbCrLf
            txtVerificationResults.Text += "First Name: " & responseObj("first_name").ToString() & vbCrLf
            txtVerificationResults.Text += "Common: " & responseObj("common").ToString() & vbCrLf
            txtVerificationResults.Text += "Generic: " & responseObj("generic").ToString() & vbCrLf
            txtVerificationResults.Text += "DNS Valid: " & responseObj("dns_valid").ToString() & vbCrLf
            txtVerificationResults.Text += "Honeypot: " & responseObj("honeypot").ToString() & vbCrLf
            txtVerificationResults.Text += "Spam Trap Score: " & responseObj("spam_trap_score").ToString() & vbCrLf
            txtVerificationResults.Text += "Fraud Score: " & responseObj("fraud_score").ToString() & vbCrLf
            txtVerificationResults.Text += "Recent Abuse: " & responseObj("recent_abuse").ToString() & vbCrLf
            txtVerificationResults.Text += "Frequent Complainer: " & responseObj("frequent_complainer").ToString() & vbCrLf
            txtVerificationResults.Text += "Sanitized Email: " & responseObj("sanitized_email").ToString() & vbCrLf
            txtVerificationResults.Text += "User Activity: " & responseObj("user_activity").ToString() & vbCrLf
            txtVerificationResults.Text += "Domain Velocity: " & responseObj("domain_velocity").ToString() & vbCrLf
            ' txtVerificationResults.Text += "Associated Names: " & responseObj("associated_names").ToString() & vbCrLf
            ' txtVerificationResults.Text += "Associated Phone Numbers: " & responseObj("associated_phone_numbers").ToString() & vbCrLf
            txtVerificationResults.Text += "END " + vbCrLf

            ' =======================================================================================
            ' Handle API request errors
            ' =======================================================================================
        Catch ex As WebException
            ' If there is a response, read the error message and display it
            Dim response As HttpWebResponse = CType(ex.Response, HttpWebResponse)
            Dim responseContent As String = New StreamReader(response.GetResponseStream()).ReadToEnd()
            MessageBox.Show("API Error: " + responseContent)

        Catch ex As Exception
            ' Handle other generic exceptions (commented out to prevent unnecessary pop-ups)
            ' MessageBox.Show("Error: " + ex.Message)
        End Try
    End Sub
    ' =======================================================================================
    ' Submit an Email to Mailing List Servers
    ' This function reads nodes and providers from text files, constructs valid submission URLs, 
    ' and attempts to submit the target email to multiple Mailman servers.
    ' =======================================================================================
    Private Async Function SubmitEmail(targetEmail As String, submissionUrl As String) As Task
        ' Counters for success and failure tracking
        Dim successfulCount As Integer = 0
        Dim failedCount As Integer = 0

        ' Open the nodes file and iterate through each node
        Using nodesReader As New StreamReader("C:\RelentlessSMS\Mailman\nodes.txt")
            While Not nodesReader.EndOfStream
                Dim node = nodesReader.ReadLine()?.Trim()
                If String.IsNullOrWhiteSpace(node) Then Continue While ' Skip empty lines

                ' Open the providers file and iterate through each provider
                Using providersReader As New StreamReader("C:\RelentlessSMS\Mailman\providers.txt")
                    While Not providersReader.EndOfStream
                        Dim provider = providersReader.ReadLine()?.Trim()
                        If String.IsNullOrWhiteSpace(provider) Then Continue While ' Skip empty lines

                        Try
                            ' Ensure both node and provider are not empty before proceeding
                            If Not String.IsNullOrEmpty(node) AndAlso Not String.IsNullOrEmpty(provider) Then
                                ' Construct the submission URL
                                submissionUrl = $"{node}{provider}"

                                ' Attempt to submit the email to the constructed URL
                                Await SubmitEmail(targetEmail, submissionUrl)

                                ' Update success count and UI
                                successfulCount += 1
                                txtSuccessful.Text = successfulCount.ToString()
                            End If
                        Catch ex As Exception
                            ' Update failure count and UI in case of an exception
                            failedCount += 1
                            txtFailed.Text = failedCount.ToString()
                        End Try

                        ' =======================================================================================
                        ' Throttle requests to avoid overloading servers
                        ' Future improvement: Convert this delay into a configurable setting via a textbox
                        ' =======================================================================================
                        Await Task.Delay(500) ' Delay of 500ms between requests
                    End While
                End Using
            End While
        End Using
    End Function

    ' =======================================================================================
    ' Control Process Execution and Stopping
    ' =======================================================================================
    Private isProcessRunning As Boolean = False

    ' =======================================================================================
    ' Stop All Ongoing Processes
    ' This function stops all running submission processes, resets UI elements, and cancels 
    ' any pending asynchronous tasks.
    ' =======================================================================================
    Private Sub btnStopAll_Click(sender As Object, e As EventArgs) Handles btnStopAll.Click
        ' Run this process asynchronously on a separate thread
        Task.Run(Sub()
                     ' Check if a process is running before attempting to stop
                     If isProcessRunning Then
                         ' Reset the progress bar and stop any animations
                         pbAllFunctions.Style = ProgressBarStyle.Blocks
                         pbAllFunctions.Value = 0
                         pbAllFunctions.MarqueeAnimationSpeed = 0

                         ' Stop all processes
                         isProcessRunning = False ' Mark process as stopped
                         KillAllProcesses()

                         ' Clear the UI display
                         pbAllFunctions.Style = ProgressBarStyle.Blocks
                         pbAllFunctions.Value = 0
                         txtOutgoingMessages.Text = "" ' Reset message log
                     End If
                 End Sub)

        ' If the cancellation token exists, signal the cancellation
        If cancelTokenSource IsNot Nothing Then
            cancelTokenSource.Cancel()
            txtOutgoingMessages.AppendText("Stopping process... Please wait." & Environment.NewLine)
        End If
    End Sub

    ' =======================================================================================
    ' Kill All Running Processes
    ' This function forcefully terminates any processes related to the application.
    ' =======================================================================================
    Private Sub KillAllProcesses()
        ' Get the current running process instance
        Dim currentProcess As Process = Process.GetCurrentProcess()

        ' Retrieve all processes with the same name as the current process
        Dim processes As Process() = Process.GetProcessesByName(currentProcess.ProcessName)

        ' Iterate through each process and terminate if it's not the current instance
        For Each process As Process In processes
            If process.Id <> currentProcess.Id Then
                process.Kill()
            End If
        Next
    End Sub


    ' =======================================================================================
    ' Handles the button click event to start email submission
    ' =======================================================================================
    Private Async Sub btnMailman_Click(sender As Object, e As EventArgs) Handles btnMailman.Click

        ' =======================================================================================
        ' Display Warning Prompt Before Execution (With VPN & Region Status)
        ' =======================================================================================
        Dim vpnStatus As String = lblVPN.Text
        Dim regionStatus As String = lblRegion.Text

        Dim message As String = "⚠ IMPORTANT: Activate your VPN before proceeding! ⚠" & vbCrLf & vbCrLf &
                        $"🔹 VPN Status: {vpnStatus}" & vbCrLf &
                        $"🔹 Region: {regionStatus}" & vbCrLf & vbCrLf &
                        "If you don't, your IP address will be exposed to the target." & vbCrLf & vbCrLf &
                        "You are about to send the target email address for submission." & vbCrLf &
                        "This process may have lasting effects on your target's email system." & vbCrLf & vbCrLf &
                        "🔹 Click 'Yes' to proceed." & vbCrLf &
                        "🔹 Click 'No' to cancel this operation."

        ' Show warning prompt
        Dim result As DialogResult = MessageBox.Show(message, "⚠ VPN Reminder - Confirm Submission", MessageBoxButtons.YesNo, MessageBoxIcon.Warning)

        ' Exit if the user cancels the operation
        If result = DialogResult.No Then
            MessageBox.Show("Operation canceled by user.", "Submission Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Exit Sub
        End If

        ' =======================================================================================
        ' Disable UI Elements to Prevent Multiple Submissions
        ' =======================================================================================
        btnMailman.Enabled = False
        btnStopAll.Enabled = True

        ' =======================================================================================
        ' Validate Target Email Input
        ' =======================================================================================
        Dim targetEmail As String = txtTargetNumber.Text.Trim()
        If String.IsNullOrWhiteSpace(targetEmail) OrElse Not targetEmail.Contains("@") Then
            MessageBox.Show("Please enter a valid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            btnMailman.Enabled = True
            Exit Sub
        End If

        ' =======================================================================================
        ' Clear UI and Reset Counters Before Submission
        ' =======================================================================================
        txtOutgoingMessages.Clear()
        txtSuccessful.Text = "0"
        txtFailed.Text = "0"
        pbAllFunctions.Style = ProgressBarStyle.Marquee
        pbAllFunctions.MarqueeAnimationSpeed = 50
        txtOutgoingMessages.AppendText("🔄 Starting email submissions... " & Environment.NewLine)

        ' Log the start of the process
        LogStatus("🔄 Starting email submissions... ")

        ' =======================================================================================
        ' Initialize Mailman Class and Start Submission Process
        ' =======================================================================================
        Dim mailman As New Mailman()
        Try
            ' Execute email submission asynchronously
            Await mailman.SubmitEmails(targetEmail, AddressOf UpdateUIStatus)

            ' Display and log completion message
            txtOutgoingMessages.AppendText("✅ Submission process completed." & Environment.NewLine)
            LogStatus("✅ Submission process completed.")
        Catch ex As OperationCanceledException
            ' Handle process cancellation
            txtOutgoingMessages.AppendText("⚠ Process was canceled by the user." & Environment.NewLine)
            LogStatus("⚠ Process was canceled by the user.")
        Catch ex As Exception
            ' Handle any other unexpected errors
            txtOutgoingMessages.AppendText($"❌ Error during submission: {ex.Message}" & Environment.NewLine)
            LogStatus($"❌ Error during submission: {ex.Message}")
        Finally
            ' =======================================================================================
            ' Reset UI and Enable Controls After Submission
            ' =======================================================================================
            pbAllFunctions.Style = ProgressBarStyle.Blocks
            pbAllFunctions.Value = 0
            btnMailman.Enabled = True
            btnStopAll.Enabled = False
        End Try
    End Sub

    ' =======================================================================================
    ' Update the UI with Real-Time Submission Progress
    ' =======================================================================================
    Private Sub UpdateUIStatus(message As String, Optional isSuccess As Boolean? = Nothing)
        If InvokeRequired Then
            ' Ensure the update is executed on the UI thread
            Invoke(New Action(Of String, Boolean?)(AddressOf UpdateUIStatus), message, isSuccess)
        Else
            ' Append status message to the UI
            txtOutgoingMessages.AppendText($"{DateTime.Now}: {message}{Environment.NewLine}")

            ' Log the message
            LogStatus(message)

            ' Update success or failure counters
            If isSuccess.HasValue Then
                If isSuccess.Value Then
                    txtSuccessful.Text = (Integer.Parse(txtSuccessful.Text) + 1).ToString()
                Else
                    txtFailed.Text = (Integer.Parse(txtFailed.Text) + 1).ToString()
                End If
            End If
        End If
    End Sub

    ' =======================================================================================
    ' Submit the Email to the Extracted Form
    ' =======================================================================================
    Private Async Function SubmitToSignupPage(formUrl As String, targetEmail As String, hiddenToken As String) As Task(Of Boolean)
        Try
            ' =======================================================================================
            ' Prepare POST Data with the Extracted Hidden Token
            ' =======================================================================================
            Dim postData As New Dictionary(Of String, String) From {
            {"email", targetEmail},
            {"email-button", "Subscribe"}
        }

            ' Include hidden token if required
            If Not String.IsNullOrWhiteSpace(hiddenToken) Then
                postData.Add("sub_form_token", hiddenToken)
            End If

            ' Convert post data into URL-encoded format
            Dim content As New FormUrlEncodedContent(postData)

            ' =======================================================================================
            ' Send the HTTP POST Request
            ' =======================================================================================
            Dim response As HttpResponseMessage = Await httpClient.PostAsync(formUrl, content)

            ' Read full response for better success detection
            Dim responseText As String = Await response.Content.ReadAsStringAsync()
            LogStatus($"🔍 Response from {formUrl}: {responseText}")

            ' =======================================================================================
            ' Detect Success by Checking for Confirmation Messages in the Response
            ' =======================================================================================
            If response.IsSuccessStatusCode OrElse
           responseText.Contains("confirmation") OrElse
           responseText.Contains("successful") OrElse
           responseText.Contains("already subscribed") Then
                Return True ' Mark as success
            Else
                Return False ' Otherwise, mark as failure
            End If
        Catch ex As Exception
            ' Log any errors encountered during submission
            LogStatus($"❌ Error submitting to {formUrl}: {ex.Message}")
            Return False
        End Try
    End Function

    ' =======================================================================================
    ' Log Status Messages to File
    ' =======================================================================================
    Private Sub LogStatus(message As String)
        Try
            ' Append log entry with timestamp to the log file
            File.AppendAllText("C:\RelentlessSMS\Logs\Logs.txt", $"{DateTime.Now}: {message}{Environment.NewLine}")
        Catch ex As Exception
            ' Prevent application crashes due to logging failures
        End Try
    End Sub

    Private Sub btnChangeName_Click(sender As Object, e As EventArgs) Handles btnChangeName.Click
        x.ScheduleDeviceNameChange()
    End Sub
End Class

' =======================================------
