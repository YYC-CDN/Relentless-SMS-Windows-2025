<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        btnClose = New Button()
        txtTextNowAPI = New TextBox()
        btnAddTextNowAPI = New Button()
        lblTEXTBELT = New LinkLabel()
        Label2 = New Label()
        Label3 = New Label()
        cbShowBrowser = New CheckBox()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        lblSerpAPI = New LinkLabel()
        lblSecurityTrails = New LinkLabel()
        lblZoomeye = New LinkLabel()
        lblShodan = New LinkLabel()
        btnSaveAPIs = New Button()
        btnRunScraper = New Button()
        tbSerpAPI = New TextBox()
        tbSecurityTrailsAPI = New TextBox()
        tbShodanAPI = New TextBox()
        tbZoomEyeAPI = New TextBox()
        btnAddSMTP = New Button()
        txtPort = New TextBox()
        Label9 = New Label()
        cbEnableSSL = New ComboBox()
        txtEmailPassword = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        btnAddEmailPass = New Button()
        txtEmailAddresses = New TextBox()
        txtSMTPbox = New TextBox()
        txtIPQualityScore = New TextBox()
        btnAPIcredit = New Button()
        lblIPQuality = New LinkLabel()
        btnIPQualityScore = New Button()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnClose
        ' 
        btnClose.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnClose.Location = New Point(830, 484)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(168, 37)
        btnClose.TabIndex = 15
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' txtTextNowAPI
        ' 
        txtTextNowAPI.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtTextNowAPI.Location = New Point(163, 50)
        txtTextNowAPI.Name = "txtTextNowAPI"
        txtTextNowAPI.PlaceholderText = "4c04870a460a4ea485d939c338e3be279f80573dfeRCuqYAOiMYnmD1E_EXAMPLE"
        txtTextNowAPI.Size = New Size(531, 23)
        txtTextNowAPI.TabIndex = 0
        ' 
        ' btnAddTextNowAPI
        ' 
        btnAddTextNowAPI.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddTextNowAPI.Location = New Point(701, 50)
        btnAddTextNowAPI.Name = "btnAddTextNowAPI"
        btnAddTextNowAPI.Size = New Size(224, 21)
        btnAddTextNowAPI.TabIndex = 1
        btnAddTextNowAPI.Text = "Add Text Message API"
        btnAddTextNowAPI.UseVisualStyleBackColor = True
        ' 
        ' lblTEXTBELT
        ' 
        lblTEXTBELT.AutoSize = True
        lblTEXTBELT.Cursor = Cursors.Hand
        lblTEXTBELT.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        lblTEXTBELT.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        lblTEXTBELT.LinkColor = Color.DarkViolet
        lblTEXTBELT.Location = New Point(22, 52)
        lblTEXTBELT.Name = "lblTEXTBELT"
        lblTEXTBELT.Size = New Size(130, 21)
        lblTEXTBELT.TabIndex = 100
        lblTEXTBELT.TabStop = True
        lblTEXTBELT.Text = "TEXTBELT API Key"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.Location = New Point(205, 121)
        Label2.Name = "Label2"
        Label2.Size = New Size(0, 16)
        Label2.TabIndex = 17
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label3.Location = New Point(277, 102)
        Label3.Name = "Label3"
        Label3.Size = New Size(0, 16)
        Label3.TabIndex = 18
        ' 
        ' cbShowBrowser
        ' 
        cbShowBrowser.AutoSize = True
        cbShowBrowser.Enabled = False
        cbShowBrowser.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        cbShowBrowser.Location = New Point(18, 501)
        cbShowBrowser.Name = "cbShowBrowser"
        cbShowBrowser.Size = New Size(142, 20)
        cbShowBrowser.TabIndex = 103
        cbShowBrowser.Text = "Leave Unchecked"
        cbShowBrowser.UseVisualStyleBackColor = True
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Dock = DockStyle.Fill
        TabControl1.Location = New Point(0, 0)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(962, 426)
        TabControl1.TabIndex = 104
        ' 
        ' TabPage1
        ' 
        TabPage1.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        TabPage1.Controls.Add(lblSerpAPI)
        TabPage1.Controls.Add(lblSecurityTrails)
        TabPage1.Controls.Add(lblZoomeye)
        TabPage1.Controls.Add(lblShodan)
        TabPage1.Controls.Add(btnSaveAPIs)
        TabPage1.Controls.Add(btnRunScraper)
        TabPage1.Controls.Add(tbSerpAPI)
        TabPage1.Controls.Add(tbSecurityTrailsAPI)
        TabPage1.Controls.Add(tbShodanAPI)
        TabPage1.Controls.Add(tbZoomEyeAPI)
        TabPage1.Controls.Add(btnAddSMTP)
        TabPage1.Controls.Add(txtPort)
        TabPage1.Controls.Add(Label9)
        TabPage1.Controls.Add(cbEnableSSL)
        TabPage1.Controls.Add(txtEmailPassword)
        TabPage1.Controls.Add(Label8)
        TabPage1.Controls.Add(Label7)
        TabPage1.Controls.Add(btnAddEmailPass)
        TabPage1.Controls.Add(txtEmailAddresses)
        TabPage1.Controls.Add(txtSMTPbox)
        TabPage1.Controls.Add(txtIPQualityScore)
        TabPage1.Controls.Add(btnAPIcredit)
        TabPage1.Controls.Add(lblIPQuality)
        TabPage1.Controls.Add(btnIPQualityScore)
        TabPage1.Controls.Add(txtTextNowAPI)
        TabPage1.Controls.Add(btnAddTextNowAPI)
        TabPage1.Controls.Add(lblTEXTBELT)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(954, 398)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Textbelt API"
        ' 
        ' lblSerpAPI
        ' 
        lblSerpAPI.AutoSize = True
        lblSerpAPI.Cursor = Cursors.Hand
        lblSerpAPI.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        lblSerpAPI.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        lblSerpAPI.LinkColor = Color.DarkViolet
        lblSerpAPI.Location = New Point(22, 203)
        lblSerpAPI.Name = "lblSerpAPI"
        lblSerpAPI.Size = New Size(221, 21)
        lblSerpAPI.TabIndex = 134
        lblSerpAPI.TabStop = True
        lblSerpAPI.Text = "SerpAPI (Google Dorking) Key:"
        ' 
        ' lblSecurityTrails
        ' 
        lblSecurityTrails.AutoSize = True
        lblSecurityTrails.Cursor = Cursors.Hand
        lblSecurityTrails.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        lblSecurityTrails.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        lblSecurityTrails.LinkColor = Color.DarkViolet
        lblSecurityTrails.Location = New Point(22, 176)
        lblSecurityTrails.Name = "lblSecurityTrails"
        lblSecurityTrails.Size = New Size(163, 21)
        lblSecurityTrails.TabIndex = 133
        lblSecurityTrails.TabStop = True
        lblSecurityTrails.Text = "SecurityTrails API Key:"
        ' 
        ' lblZoomeye
        ' 
        lblZoomeye.AutoSize = True
        lblZoomeye.Cursor = Cursors.Hand
        lblZoomeye.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        lblZoomeye.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        lblZoomeye.LinkColor = Color.DarkViolet
        lblZoomeye.Location = New Point(22, 144)
        lblZoomeye.Name = "lblZoomeye"
        lblZoomeye.Size = New Size(134, 21)
        lblZoomeye.TabIndex = 132
        lblZoomeye.TabStop = True
        lblZoomeye.Text = "ZoomEye API Key:"
        ' 
        ' lblShodan
        ' 
        lblShodan.AutoSize = True
        lblShodan.Cursor = Cursors.Hand
        lblShodan.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        lblShodan.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        lblShodan.LinkColor = Color.DarkViolet
        lblShodan.Location = New Point(22, 115)
        lblShodan.Name = "lblShodan"
        lblShodan.Size = New Size(122, 21)
        lblShodan.TabIndex = 130
        lblShodan.TabStop = True
        lblShodan.Text = "Shodan API Key:"
        ' 
        ' btnSaveAPIs
        ' 
        btnSaveAPIs.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnSaveAPIs.Location = New Point(701, 112)
        btnSaveAPIs.Name = "btnSaveAPIs"
        btnSaveAPIs.Size = New Size(98, 116)
        btnSaveAPIs.TabIndex = 129
        btnSaveAPIs.Text = "Save API's"
        btnSaveAPIs.UseVisualStyleBackColor = True
        ' 
        ' btnRunScraper
        ' 
        btnRunScraper.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnRunScraper.Location = New Point(805, 111)
        btnRunScraper.Name = "btnRunScraper"
        btnRunScraper.Size = New Size(120, 117)
        btnRunScraper.TabIndex = 128
        btnRunScraper.Text = "Run Scraper"
        btnRunScraper.UseVisualStyleBackColor = True
        ' 
        ' tbSerpAPI
        ' 
        tbSerpAPI.Location = New Point(246, 205)
        tbSerpAPI.Name = "tbSerpAPI"
        tbSerpAPI.Size = New Size(448, 23)
        tbSerpAPI.TabIndex = 123
        ' 
        ' tbSecurityTrailsAPI
        ' 
        tbSecurityTrailsAPI.Location = New Point(207, 174)
        tbSecurityTrailsAPI.Name = "tbSecurityTrailsAPI"
        tbSecurityTrailsAPI.Size = New Size(487, 23)
        tbSecurityTrailsAPI.TabIndex = 122
        ' 
        ' tbShodanAPI
        ' 
        tbShodanAPI.Location = New Point(163, 114)
        tbShodanAPI.Name = "tbShodanAPI"
        tbShodanAPI.Size = New Size(531, 23)
        tbShodanAPI.TabIndex = 121
        ' 
        ' tbZoomEyeAPI
        ' 
        tbZoomEyeAPI.Location = New Point(163, 144)
        tbZoomEyeAPI.Name = "tbZoomEyeAPI"
        tbZoomEyeAPI.Size = New Size(531, 23)
        tbZoomEyeAPI.TabIndex = 120
        ' 
        ' btnAddSMTP
        ' 
        btnAddSMTP.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddSMTP.Location = New Point(624, 281)
        btnAddSMTP.Name = "btnAddSMTP"
        btnAddSMTP.Size = New Size(145, 30)
        btnAddSMTP.TabIndex = 112
        btnAddSMTP.Text = "Save SMTP Details"
        btnAddSMTP.UseVisualStyleBackColor = True
        ' 
        ' txtPort
        ' 
        txtPort.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtPort.Location = New Point(323, 284)
        txtPort.Name = "txtPort"
        txtPort.PlaceholderText = "587"
        txtPort.Size = New Size(58, 23)
        txtPort.TabIndex = 110
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        Label9.Location = New Point(423, 288)
        Label9.Name = "Label9"
        Label9.Size = New Size(81, 21)
        Label9.TabIndex = 116
        Label9.Text = "EnableSSL"
        ' 
        ' cbEnableSSL
        ' 
        cbEnableSSL.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        cbEnableSSL.FormattingEnabled = True
        cbEnableSSL.Items.AddRange(New Object() {"Please Select", "True", "False"})
        cbEnableSSL.Location = New Point(502, 284)
        cbEnableSSL.Name = "cbEnableSSL"
        cbEnableSSL.Size = New Size(118, 24)
        cbEnableSSL.TabIndex = 111
        cbEnableSSL.Text = "Please Select"
        ' 
        ' txtEmailPassword
        ' 
        txtEmailPassword.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmailPassword.Location = New Point(401, 330)
        txtEmailPassword.Name = "txtEmailPassword"
        txtEmailPassword.PlaceholderText = "password"
        txtEmailPassword.Size = New Size(105, 23)
        txtEmailPassword.TabIndex = 114
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        Label8.Location = New Point(282, 288)
        Label8.Name = "Label8"
        Label8.Size = New Size(39, 21)
        Label8.TabIndex = 117
        Label8.Text = "Port"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        Label7.Location = New Point(33, 288)
        Label7.Name = "Label7"
        Label7.Size = New Size(50, 21)
        Label7.TabIndex = 118
        Label7.Text = "SMTP"
        ' 
        ' btnAddEmailPass
        ' 
        btnAddEmailPass.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddEmailPass.Location = New Point(530, 327)
        btnAddEmailPass.Name = "btnAddEmailPass"
        btnAddEmailPass.Size = New Size(269, 30)
        btnAddEmailPass.TabIndex = 115
        btnAddEmailPass.Text = "Add Email and the MASTER Password"
        btnAddEmailPass.UseVisualStyleBackColor = True
        ' 
        ' txtEmailAddresses
        ' 
        txtEmailAddresses.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmailAddresses.Location = New Point(33, 330)
        txtEmailAddresses.Name = "txtEmailAddresses"
        txtEmailAddresses.PlaceholderText = "sample@domain.com"
        txtEmailAddresses.Size = New Size(328, 23)
        txtEmailAddresses.TabIndex = 113
        ' 
        ' txtSMTPbox
        ' 
        txtSMTPbox.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtSMTPbox.Location = New Point(82, 284)
        txtSMTPbox.Name = "txtSMTPbox"
        txtSMTPbox.PlaceholderText = "smtp.yourdomain.com"
        txtSMTPbox.Size = New Size(193, 23)
        txtSMTPbox.TabIndex = 109
        ' 
        ' txtIPQualityScore
        ' 
        txtIPQualityScore.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtIPQualityScore.Location = New Point(207, 82)
        txtIPQualityScore.Name = "txtIPQualityScore"
        txtIPQualityScore.PlaceholderText = "ZWm5zjhIU3aV18lRwnDxe6WKlYAxsCrX_EXAMPLE"
        txtIPQualityScore.Size = New Size(362, 23)
        txtIPQualityScore.TabIndex = 103
        ' 
        ' btnAPIcredit
        ' 
        btnAPIcredit.Enabled = False
        btnAPIcredit.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAPIcredit.Location = New Point(576, 82)
        btnAPIcredit.Name = "btnAPIcredit"
        btnAPIcredit.Size = New Size(129, 21)
        btnAPIcredit.TabIndex = 108
        btnAPIcredit.Text = "Check API Credit Usage"
        btnAPIcredit.UseVisualStyleBackColor = True
        ' 
        ' lblIPQuality
        ' 
        lblIPQuality.AutoSize = True
        lblIPQuality.Cursor = Cursors.Hand
        lblIPQuality.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        lblIPQuality.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        lblIPQuality.LinkColor = Color.DarkViolet
        lblIPQuality.Location = New Point(22, 83)
        lblIPQuality.Name = "lblIPQuality"
        lblIPQuality.Size = New Size(178, 21)
        lblIPQuality.TabIndex = 107
        lblIPQuality.TabStop = True
        lblIPQuality.Text = "IP Quality Score API Key"
        ' 
        ' btnIPQualityScore
        ' 
        btnIPQualityScore.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnIPQualityScore.Location = New Point(713, 82)
        btnIPQualityScore.Name = "btnIPQualityScore"
        btnIPQualityScore.Size = New Size(212, 21)
        btnIPQualityScore.TabIndex = 104
        btnIPQualityScore.Text = "Add API for Number and Email Verification"
        btnIPQualityScore.UseVisualStyleBackColor = True
        ' 
        ' frmSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        ClientSize = New Size(962, 426)
        Controls.Add(TabControl1)
        Controls.Add(cbShowBrowser)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(btnClose)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "frmSettings"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Relentless SMS Settings"
        TabControl1.ResumeLayout(False)
        TabPage1.ResumeLayout(False)
        TabPage1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents txtTextNowAPI As TextBox
    Friend WithEvents btnAddTextNowAPI As Button
    Friend WithEvents lblTEXTBELT As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbShowBrowser As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtIPQualityScore As TextBox
    Friend WithEvents btnAPIcredit As Button
    Friend WithEvents lblIPQuality As LinkLabel
    Friend WithEvents btnIPQualityScore As Button
    Friend WithEvents btnSaveAPIs As Button
    Friend WithEvents btnRunScraper As Button
    Friend WithEvents tbSerpAPI As TextBox
    Friend WithEvents tbSecurityTrailsAPI As TextBox
    Friend WithEvents tbShodanAPI As TextBox
    Friend WithEvents tbZoomEyeAPI As TextBox
    Friend WithEvents btnAddSMTP As Button
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents cbEnableSSL As ComboBox
    Friend WithEvents txtEmailPassword As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnAddEmailPass As Button
    Friend WithEvents txtEmailAddresses As TextBox
    Friend WithEvents txtSMTPbox As TextBox
    Friend WithEvents lblShodan As LinkLabel
    Friend WithEvents lblSerpAPI As LinkLabel
    Friend WithEvents lblSecurityTrails As LinkLabel
    Friend WithEvents lblZoomeye As LinkLabel
End Class
