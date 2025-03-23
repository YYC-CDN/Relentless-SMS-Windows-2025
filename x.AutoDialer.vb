'03/15/25
' Made by ░▒▓█│【MrBungle】│█▓▒░
' Call the number and play the message then hang up and redial again



Imports System.Diagnostics
Imports System.IO
Imports System.Threading

Module x_AutoDialer

    ' Function to start auto-dialing using Linphone
    Public Sub StartAutoDialer(targetNumber As String, wavFilePath As String, repeatCount As Integer)
        If String.IsNullOrEmpty(targetNumber) Then
            MessageBox.Show("Please enter a valid phone number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        If Not File.Exists(wavFilePath) Then
            MessageBox.Show("The specified .wav file does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim linphonePath As String = "C:\Program Files\Linphone\linphonec.exe" ' Path to Linphone CLI

        If Not File.Exists(linphonePath) Then
            MessageBox.Show("Linphone CLI not found. Please ensure Linphone is installed.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        For i As Integer = 1 To repeatCount
            Try
                ' Start Linphone and initiate the call
                Dim startInfo As New ProcessStartInfo With {
                    .FileName = linphonePath,
                    .Arguments = $"-c linphone-config.cfg -s sip:{targetNumber}@sip.linphone.org",
                    .UseShellExecute = False,
                    .RedirectStandardOutput = True,
                    .CreateNoWindow = True
                }

                Dim process As Process = Process.Start(startInfo)
                Thread.Sleep(5000) ' Wait for call to initiate

                ' Play the audio message
                Using player As New System.Media.SoundPlayer(wavFilePath)
                    player.PlaySync()
                End Using

                ' End the call
                process.StandardInput.WriteLine("terminate")
                process.WaitForExit()

                ' Optional: Wait before redialing
                Thread.Sleep(5000)

            Catch ex As Exception
                MessageBox.Show("Error during dialing: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        Next

        MessageBox.Show("Auto-dialing sequence completed.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

End Module
