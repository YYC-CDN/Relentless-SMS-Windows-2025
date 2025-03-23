'03/21/2023


Module SendSMS

    Public Sub SendSMS()

        ' Prompt the user to confirm the target number and number of messages
        Dim confirmDialog As DialogResult = MessageBox.Show("Is " & frmMain.txtTargetNumber.Text & " the correct target number with " & frmMain.txtNumberofMessages.Text & " messages?" & vbCrLf & vbCrLf, "Confirm Target Number and Number of Messages", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation)

        ' Set the minimum and maximum values of the progress bar
        Dim num_of_messages As Integer = CInt(frmMain.txtNumberofMessages.Text)
        frmMain.pbAllFunctions.Minimum = 0
        frmMain.pbAllFunctions.Maximum = num_of_messages

        ' Get the number of messages to send and the time to wait between each message
        Dim messages_to_send As Integer
        Dim wait_time As Integer

        Try
            messages_to_send = Integer.Parse(frmMain.txtNumberofMessages.Text)
        Catch ex As Exception
            MessageBox.Show("Invalid number of messages to send. Please enter a valid number.")
            Return
        End Try

        Try
            wait_time = Integer.Parse(frmMain.txtSecondsBetween.Text)
        Catch ex As Exception
            MessageBox.Show("Invalid seconds between messages. Please enter a valid number.")
            Return
        End Try

        ' Define messages array
        Dim messages As String()

        ' Set the API keys
        Dim api_keys As String() = System.IO.File.ReadAllLines("C:\RelentlessSMS\APIs\TextNowAPI.txt")

        ' Set the URL for the API request
        Dim url As String = "https://textbelt.com/text"

        ' Set the message file path based on selected language
        Dim message_file_path As String
        Select Case frmMain.dbOutgoingLanguage.Text
            Case "English (Default)"
                message_file_path = "C:\RelentlessSMS\AntiCrimeMessages\AntiCrimeEnglish.txt"
            Case "Chinese"
                message_file_path = "C:\RelentlessSMS\AntiCrimeMessages\AntiCrimeChinese.txt"
            Case "Hindi"
                message_file_path = "C:\RelentlessSMS\AntiCrimeMessages\AntiCrimeHindi.txt"
            Case Else
                MessageBox.Show("Invalid language selected.")
                Return
        End Select

        ' Read messages from the message file
        messages = System.IO.File.ReadAllLines(message_file_path)
        If messages.Length > 0 Then
            frmMain.txtOutgoingMessages.Text = messages(0)
        End If

        ' Declare a variable to keep track of the number of messages sent
        Dim numMessagesSent As Integer = 0

        ' Create a new WebClient instance
        Dim client As New System.Net.WebClient()

        ' Determine which API key to use based on the number of messages sent
        Dim api_key_index As Integer
        If messages_to_send = 1 Then
            api_key_index = 0
        Else
            api_key_index = numMessagesSent Mod api_keys.Length
        End If

        ' Set the API key
        Dim current_api_key = api_keys(api_key_index).Trim()

        ' Send messages using the current API key
        For i As Integer = 1 To messages_to_send
            ' Get a random message from the array
            Dim iMessage As String = messages(New Random().Next(0, messages.Length))

            ' Set the phone number to send the message to
            Dim phone_number As String = frmMain.txtTargetNumber.Text

            ' Add parameters to the API request
            Dim parameters As New System.Collections.Specialized.NameValueCollection()
            parameters.Add("phone", phone_number)
            parameters.Add("message", iMessage)
            parameters.Add("key", current_api_key)

            ' Send the message
            Dim response_bytes As Byte() = client.UploadValues(url, "POST", parameters)
            Dim response As String = System.Text.Encoding.ASCII.GetString(response_bytes)

            ' Output the response to the user
            frmMain.txtOutgoingMessages.AppendText(iMessage & vbCrLf)

            ' Update the progress bar value
            frmMain.pbAllFunctions.Value = i

            ' Clear messages
            frmMain.txtOutgoingMessages.Clear()

            ' Increment the number of messages sent
            numMessagesSent += 1

            ' If sending more than one message, update the API key if necessary
            If messages_to_send > 1 AndAlso numMessagesSent Mod api_keys.Length = 0 Then
                api_key_index = 0
                current_api_key = api_keys(api_key_index).Trim()
            Else
                api_key_index += 1
                current_api_key = api_keys(api_key_index).Trim()
            End If

            ' Wait for the specified time before sending the next message
            Threading.Thread.Sleep(wait_time * 250)
        Next

    End Sub

End Module
