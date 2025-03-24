<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScraperConsole
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txtScraperLog = New TextBox()
        SuspendLayout()
        ' 
        ' txtScraperLog
        ' 
        txtScraperLog.BackColor = Color.Black
        txtScraperLog.Dock = DockStyle.Fill
        txtScraperLog.Font = New Font("Consolas", 10F, FontStyle.Regular, GraphicsUnit.Point)
        txtScraperLog.ForeColor = Color.LightGreen
        txtScraperLog.Location = New Point(0, 0)
        txtScraperLog.Multiline = True
        txtScraperLog.Name = "txtScraperLog"
        txtScraperLog.ScrollBars = ScrollBars.Vertical
        txtScraperLog.Size = New Size(800, 450)
        txtScraperLog.TabIndex = 0
        ' 
        ' frmScraperConsole
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(txtScraperLog)
        Name = "frmScraperConsole"
        ShowIcon = False
        StartPosition = FormStartPosition.CenterScreen
        Text = "frmScraperConsole"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtScraperLog As TextBox
End Class
