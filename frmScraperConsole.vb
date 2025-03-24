' 03/23/2025
' Scraper Console for Live Logging

Public Class frmScraperConsole

    Public Sub AppendLog(message As String)
        If Me.InvokeRequired Then
            Me.Invoke(Sub() AppendLog(message))
        Else
            txtScraperLog.AppendText($"{DateTime.Now:HH:mm:ss}  {message}{Environment.NewLine}")
            txtScraperLog.SelectionStart = txtScraperLog.Text.Length
            txtScraperLog.ScrollToCaret()
        End If
    End Sub

    Private Sub frmScraperConsole_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "📡 Mailman Scraper Console"
        txtScraperLog.Clear()
        txtScraperLog.Font = New Font("Consolas", 10)
        txtScraperLog.BackColor = Color.Black
        txtScraperLog.ForeColor = Color.LightGreen
    End Sub

    Private Sub txtScraperLog_TextChanged(sender As Object, e As EventArgs) Handles txtScraperLog.TextChanged

    End Sub
End Class
