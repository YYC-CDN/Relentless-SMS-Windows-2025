' 3/28/23
' 1/16/25
' Made by ░▒▓█│【MrBungle】│█▓▒░

Imports System.Threading

Public Class FrmBrowser

    Private Sub FrmBrowser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        StatusStripProgressBar.Style = ProgressBarStyle.Marquee
        StatusStripProgressBar.MarqueeAnimationSpeed = 75

        Me.Text = $"RSMS BROWSER WINDOW| FOR GOVERNMENT USE ONLY | NOT ALL MESSAGES WILL BE DELIVERED "

    End Sub

    Private Sub StatusTextChanged()
        StatusStripStatusText.Text = DirectCast(TabControl1.SelectedTab.Controls.Item(0), WebBrowser).StatusText
    End Sub

    Private Sub CloseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub ProgressChanged(sender As Object, e As Windows.Forms.WebBrowserProgressChangedEventArgs)
        Dim webBrowser = DirectCast(TabControl1.SelectedTab.Controls.Item(0), WebBrowser)
        StatusStripProgressBar.Value = (e.CurrentProgress / e.MaximumProgress) * 100
        ' If Not ToolStripURL.Focused Then
        'ToolStripURL.Text = webBrowser.Url.ToString()
        ' End If
    End Sub

    Private Sub FrmBrowser_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        frmMain.txtOutgoingMessages.Text = ""

        ' Delay for 5 seconds
        Thread.Sleep(5000)

        ' Stop the marquee animation on pbAllFunctions
        frmMain.Invoke(Sub() frmMain.pbAllFunctions.Style = ProgressBarStyle.Continuous)

        ' Show the progress bar
        frmMain.Invoke(Sub() frmMain.pbAllFunctions.Show())
    End Sub


End Class





