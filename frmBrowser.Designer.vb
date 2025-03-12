<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBrowser
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBrowser))
        TabControl1 = New TabControl()
        StatusStrip = New StatusStrip()
        StatusStripProgressBar = New ToolStripProgressBar()
        StatusStripStatusText = New ToolStripStatusLabel()
        WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        MenuStrip1 = New MenuStrip()
        FileToolStripMenuItem = New ToolStripMenuItem()
        CloseToolStripMenuItem = New ToolStripMenuItem()
        ToolStripURL = New ToolStripComboBox()
        ToolStrip1 = New ToolStrip()
        StatusStrip.SuspendLayout()
        CType(WebView21, ComponentModel.ISupportInitialize).BeginInit()
        MenuStrip1.SuspendLayout()
        ToolStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' TabControl1
        ' 
        TabControl1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        TabControl1.Location = New Point(0, 27)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(866, 474)
        TabControl1.TabIndex = 0
        ' 
        ' StatusStrip
        ' 
        StatusStrip.Items.AddRange(New ToolStripItem() {StatusStripProgressBar, StatusStripStatusText})
        StatusStrip.Location = New Point(0, 504)
        StatusStrip.Name = "StatusStrip"
        StatusStrip.Padding = New Padding(1, 0, 16, 0)
        StatusStrip.Size = New Size(866, 22)
        StatusStrip.TabIndex = 1
        StatusStrip.Text = "StatusStrip1"
        ' 
        ' StatusStripProgressBar
        ' 
        StatusStripProgressBar.Name = "StatusStripProgressBar"
        StatusStripProgressBar.Size = New Size(150, 16)
        ' 
        ' StatusStripStatusText
        ' 
        StatusStripStatusText.Name = "StatusStripStatusText"
        StatusStripStatusText.Size = New Size(648, 17)
        StatusStripStatusText.Text = "Minimize, but don't close this window. The more tabs, the better. 50 tabs for 24 hours is good. 75 tabs for 72 hours is ideal."
        ' 
        ' WebView21
        ' 
        WebView21.AllowExternalDrop = True
        WebView21.CreationProperties = Nothing
        WebView21.DefaultBackgroundColor = Color.White
        WebView21.Location = New Point(0, 76)
        WebView21.Name = "WebView21"
        WebView21.Size = New Size(826, 47)
        WebView21.TabIndex = 3
        WebView21.ZoomFactor = 1R
        ' 
        ' MenuStrip1
        ' 
        MenuStrip1.Items.AddRange(New ToolStripItem() {FileToolStripMenuItem, CloseToolStripMenuItem})
        MenuStrip1.Location = New Point(0, 0)
        MenuStrip1.Name = "MenuStrip1"
        MenuStrip1.Size = New Size(866, 24)
        MenuStrip1.TabIndex = 4
        MenuStrip1.Text = "MenuStrip1"
        ' 
        ' FileToolStripMenuItem
        ' 
        FileToolStripMenuItem.Enabled = False
        FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        FileToolStripMenuItem.Size = New Size(37, 20)
        FileToolStripMenuItem.Text = "File"
        ' 
        ' CloseToolStripMenuItem
        ' 
        CloseToolStripMenuItem.Name = "CloseToolStripMenuItem"
        CloseToolStripMenuItem.Size = New Size(48, 20)
        CloseToolStripMenuItem.Text = "Close"
        ' 
        ' ToolStripURL
        ' 
        ToolStripURL.BackColor = SystemColors.AppWorkspace
        ToolStripURL.Name = "ToolStripURL"
        ToolStripURL.Size = New Size(500, 25)
        ToolStripURL.Text = "http://mailbait.info"
        ToolStripURL.Visible = False
        ' 
        ' ToolStrip1
        ' 
        ToolStrip1.Items.AddRange(New ToolStripItem() {ToolStripURL})
        ToolStrip1.Location = New Point(0, 24)
        ToolStrip1.Name = "ToolStrip1"
        ToolStrip1.Size = New Size(866, 25)
        ToolStrip1.TabIndex = 5
        ToolStrip1.Text = "ToolStrip1"
        ToolStrip1.Visible = False
        ' 
        ' frmBrowser
        ' 
        AutoScaleDimensions = New SizeF(8F, 16F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(866, 526)
        Controls.Add(TabControl1)
        Controls.Add(ToolStrip1)
        Controls.Add(StatusStrip)
        Controls.Add(MenuStrip1)
        Controls.Add(WebView21)
        Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MainMenuStrip = MenuStrip1
        Name = "frmBrowser"
        StartPosition = FormStartPosition.CenterScreen
        StatusStrip.ResumeLayout(False)
        StatusStrip.PerformLayout()
        CType(WebView21, ComponentModel.ISupportInitialize).EndInit()
        MenuStrip1.ResumeLayout(False)
        MenuStrip1.PerformLayout()
        ToolStrip1.ResumeLayout(False)
        ToolStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents StatusStrip As StatusStrip
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
    Friend WithEvents StatusStripProgressBar As ToolStripProgressBar
    Friend WithEvents StatusStripStatusText As ToolStripStatusLabel
    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents CloseToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ToolStripURL As ToolStripComboBox
    Friend WithEvents ToolStrip1 As ToolStrip
End Class
