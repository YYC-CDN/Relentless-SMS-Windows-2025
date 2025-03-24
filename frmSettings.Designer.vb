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
        Label6 = New Label()
        btnAddTextNowAPI = New Button()
        lblLinkHome = New LinkLabel()
        Label2 = New Label()
        Label3 = New Label()
        cbShowBrowser = New CheckBox()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        btnSaveAPIs = New Button()
        btnRunScraper = New Button()
        Label14 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label10 = New Label()
        tbSerpAPI = New TextBox()
        tbSecurityTrailsAPI = New TextBox()
        tbShodanAPI = New TextBox()
        tbZoomEyeAPI = New TextBox()
        btnAddSMTP = New Button()
        txtPort = New TextBox()
        Label9 = New Label()
        Label11 = New Label()
        cbEnableSSL = New ComboBox()
        txtEmailPassword = New TextBox()
        Label8 = New Label()
        Label7 = New Label()
        btnAddEmailPass = New Button()
        txtEmailAddresses = New TextBox()
        txtSMTPbox = New TextBox()
        txtIPQualityScore = New TextBox()
        btnAPIcredit = New Button()
        Label4 = New Label()
        LinkLabel1 = New LinkLabel()
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
        txtTextNowAPI.Location = New Point(213, 14)
        txtTextNowAPI.Name = "txtTextNowAPI"
        txtTextNowAPI.PlaceholderText = "4c04870a460a4ea485d939c338e3be279f80573dfeRCuqYAOiMYnmD1E_EXAMPLE"
        txtTextNowAPI.Size = New Size(531, 23)
        txtTextNowAPI.TabIndex = 0
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label6.Location = New Point(7, 17)
        Label6.Name = "Label6"
        Label6.Size = New Size(200, 16)
        Label6.TabIndex = 100
        Label6.Text = "TEXTBELT Message Send API"
        ' 
        ' btnAddTextNowAPI
        ' 
        btnAddTextNowAPI.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddTextNowAPI.Location = New Point(773, 11)
        btnAddTextNowAPI.Name = "btnAddTextNowAPI"
        btnAddTextNowAPI.Size = New Size(181, 29)
        btnAddTextNowAPI.TabIndex = 1
        btnAddTextNowAPI.Text = "Add Text Message API"
        btnAddTextNowAPI.UseVisualStyleBackColor = True
        ' 
        ' lblLinkHome
        ' 
        lblLinkHome.AutoSize = True
        lblLinkHome.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        lblLinkHome.LinkColor = Color.DarkViolet
        lblLinkHome.Location = New Point(7, 33)
        lblLinkHome.Name = "lblLinkHome"
        lblLinkHome.Size = New Size(118, 16)
        lblLinkHome.TabIndex = 100
        lblLinkHome.TabStop = True
        lblLinkHome.Text = "Get the API here"
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
        TabControl1.Location = New Point(7, 12)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(1013, 466)
        TabControl1.TabIndex = 104
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(btnSaveAPIs)
        TabPage1.Controls.Add(btnRunScraper)
        TabPage1.Controls.Add(Label14)
        TabPage1.Controls.Add(Label13)
        TabPage1.Controls.Add(Label12)
        TabPage1.Controls.Add(Label10)
        TabPage1.Controls.Add(tbSerpAPI)
        TabPage1.Controls.Add(tbSecurityTrailsAPI)
        TabPage1.Controls.Add(tbShodanAPI)
        TabPage1.Controls.Add(tbZoomEyeAPI)
        TabPage1.Controls.Add(btnAddSMTP)
        TabPage1.Controls.Add(txtPort)
        TabPage1.Controls.Add(Label9)
        TabPage1.Controls.Add(Label11)
        TabPage1.Controls.Add(cbEnableSSL)
        TabPage1.Controls.Add(txtEmailPassword)
        TabPage1.Controls.Add(Label8)
        TabPage1.Controls.Add(Label7)
        TabPage1.Controls.Add(btnAddEmailPass)
        TabPage1.Controls.Add(txtEmailAddresses)
        TabPage1.Controls.Add(txtSMTPbox)
        TabPage1.Controls.Add(txtIPQualityScore)
        TabPage1.Controls.Add(btnAPIcredit)
        TabPage1.Controls.Add(Label4)
        TabPage1.Controls.Add(LinkLabel1)
        TabPage1.Controls.Add(btnIPQualityScore)
        TabPage1.Controls.Add(txtTextNowAPI)
        TabPage1.Controls.Add(Label6)
        TabPage1.Controls.Add(btnAddTextNowAPI)
        TabPage1.Controls.Add(lblLinkHome)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(1005, 438)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Textbelt API"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' btnSaveAPIs
        ' 
        btnSaveAPIs.Location = New Point(669, 344)
        btnSaveAPIs.Name = "btnSaveAPIs"
        btnSaveAPIs.Size = New Size(117, 68)
        btnSaveAPIs.TabIndex = 129
        btnSaveAPIs.Text = "Save API's"
        btnSaveAPIs.UseVisualStyleBackColor = True
        ' 
        ' btnRunScraper
        ' 
        btnRunScraper.Location = New Point(669, 262)
        btnRunScraper.Name = "btnRunScraper"
        btnRunScraper.Size = New Size(117, 76)
        btnRunScraper.TabIndex = 128
        btnRunScraper.Text = "Run Scraper"
        btnRunScraper.UseVisualStyleBackColor = True
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(35, 384)
        Label14.Name = "Label14"
        Label14.RightToLeft = RightToLeft.Yes
        Label14.Size = New Size(51, 15)
        Label14.TabIndex = 127
        Label14.Text = "Serp API"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(35, 350)
        Label13.Name = "Label13"
        Label13.Size = New Size(78, 15)
        Label13.TabIndex = 126
        Label13.Text = "Security Trails"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(35, 305)
        Label12.Name = "Label12"
        Label12.Size = New Size(57, 15)
        Label12.TabIndex = 125
        Label12.Text = "Zoomeye"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(35, 277)
        Label10.Name = "Label10"
        Label10.Size = New Size(47, 15)
        Label10.TabIndex = 124
        Label10.Text = "Shodan"
        ' 
        ' tbSerpAPI
        ' 
        tbSerpAPI.Location = New Point(120, 380)
        tbSerpAPI.Name = "tbSerpAPI"
        tbSerpAPI.Size = New Size(512, 23)
        tbSerpAPI.TabIndex = 123
        ' 
        ' tbSecurityTrailsAPI
        ' 
        tbSecurityTrailsAPI.Location = New Point(120, 346)
        tbSecurityTrailsAPI.Name = "tbSecurityTrailsAPI"
        tbSecurityTrailsAPI.Size = New Size(512, 23)
        tbSecurityTrailsAPI.TabIndex = 122
        ' 
        ' tbShodanAPI
        ' 
        tbShodanAPI.Location = New Point(120, 269)
        tbShodanAPI.Name = "tbShodanAPI"
        tbShodanAPI.Size = New Size(512, 23)
        tbShodanAPI.TabIndex = 121
        ' 
        ' tbZoomEyeAPI
        ' 
        tbZoomEyeAPI.Location = New Point(120, 306)
        tbZoomEyeAPI.Name = "tbZoomEyeAPI"
        tbZoomEyeAPI.Size = New Size(512, 23)
        tbZoomEyeAPI.TabIndex = 120
        ' 
        ' btnAddSMTP
        ' 
        btnAddSMTP.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddSMTP.Location = New Point(600, 161)
        btnAddSMTP.Name = "btnAddSMTP"
        btnAddSMTP.Size = New Size(145, 30)
        btnAddSMTP.TabIndex = 112
        btnAddSMTP.Text = "Save SMTP Details"
        btnAddSMTP.UseVisualStyleBackColor = True
        ' 
        ' txtPort
        ' 
        txtPort.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtPort.Location = New Point(299, 164)
        txtPort.Name = "txtPort"
        txtPort.PlaceholderText = "587"
        txtPort.Size = New Size(58, 23)
        txtPort.TabIndex = 110
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(399, 168)
        Label9.Name = "Label9"
        Label9.Size = New Size(75, 16)
        Label9.TabIndex = 116
        Label9.Text = "EnableSSL"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.Location = New Point(329, 126)
        Label11.Name = "Label11"
        Label11.Size = New Size(604, 32)
        Label11.TabIndex = 119
        Label11.Text = "Enter SMTP once and save, then as many email addresses as you can, they will be added" & vbCrLf & "to the list it will email from in sequential order"
        ' 
        ' cbEnableSSL
        ' 
        cbEnableSSL.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        cbEnableSSL.FormattingEnabled = True
        cbEnableSSL.Items.AddRange(New Object() {"Please Select", "True", "False"})
        cbEnableSSL.Location = New Point(478, 164)
        cbEnableSSL.Name = "cbEnableSSL"
        cbEnableSSL.Size = New Size(118, 24)
        cbEnableSSL.TabIndex = 111
        cbEnableSSL.Text = "Please Select"
        ' 
        ' txtEmailPassword
        ' 
        txtEmailPassword.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmailPassword.Location = New Point(377, 210)
        txtEmailPassword.Name = "txtEmailPassword"
        txtEmailPassword.PlaceholderText = "iD1dnTd01T"
        txtEmailPassword.Size = New Size(105, 23)
        txtEmailPassword.TabIndex = 114
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Location = New Point(258, 168)
        Label8.Name = "Label8"
        Label8.Size = New Size(34, 16)
        Label8.TabIndex = 117
        Label8.Text = "Port"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(9, 168)
        Label7.Name = "Label7"
        Label7.Size = New Size(44, 16)
        Label7.TabIndex = 118
        Label7.Text = "SMTP"
        ' 
        ' btnAddEmailPass
        ' 
        btnAddEmailPass.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddEmailPass.Location = New Point(506, 207)
        btnAddEmailPass.Name = "btnAddEmailPass"
        btnAddEmailPass.Size = New Size(189, 30)
        btnAddEmailPass.TabIndex = 115
        btnAddEmailPass.Text = "Add Email and Password"
        btnAddEmailPass.UseVisualStyleBackColor = True
        ' 
        ' txtEmailAddresses
        ' 
        txtEmailAddresses.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmailAddresses.Location = New Point(9, 210)
        txtEmailAddresses.Name = "txtEmailAddresses"
        txtEmailAddresses.PlaceholderText = "oj.simpson@domain.com"
        txtEmailAddresses.Size = New Size(328, 23)
        txtEmailAddresses.TabIndex = 113
        ' 
        ' txtSMTPbox
        ' 
        txtSMTPbox.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtSMTPbox.Location = New Point(58, 164)
        txtSMTPbox.Name = "txtSMTPbox"
        txtSMTPbox.PlaceholderText = "smtp.yourdomain.com"
        txtSMTPbox.Size = New Size(193, 23)
        txtSMTPbox.TabIndex = 109
        ' 
        ' txtIPQualityScore
        ' 
        txtIPQualityScore.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtIPQualityScore.Location = New Point(155, 85)
        txtIPQualityScore.Name = "txtIPQualityScore"
        txtIPQualityScore.PlaceholderText = "ZWm5zjhIU3aV18lRwnDxe6WKlYAxsCrX_EXAMPLE"
        txtIPQualityScore.Size = New Size(362, 23)
        txtIPQualityScore.TabIndex = 103
        ' 
        ' btnAPIcredit
        ' 
        btnAPIcredit.Enabled = False
        btnAPIcredit.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAPIcredit.Location = New Point(535, 85)
        btnAPIcredit.Name = "btnAPIcredit"
        btnAPIcredit.Size = New Size(131, 25)
        btnAPIcredit.TabIndex = 108
        btnAPIcredit.Text = "Check API Credit Usage"
        btnAPIcredit.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(8, 85)
        Label4.Name = "Label4"
        Label4.Size = New Size(141, 16)
        Label4.TabIndex = 106
        Label4.Text = "IP Quality Score API"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LinkLabel1.LinkColor = Color.DarkViolet
        LinkLabel1.Location = New Point(8, 111)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(230, 16)
        LinkLabel1.TabIndex = 107
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Get the IP Quality Score API here"
        ' 
        ' btnIPQualityScore
        ' 
        btnIPQualityScore.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnIPQualityScore.Location = New Point(672, 85)
        btnIPQualityScore.Name = "btnIPQualityScore"
        btnIPQualityScore.Size = New Size(212, 25)
        btnIPQualityScore.TabIndex = 104
        btnIPQualityScore.Text = "Add API for Number and Email Verification"
        btnIPQualityScore.UseVisualStyleBackColor = True
        ' 
        ' frmSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1022, 533)
        ControlBox = False
        Controls.Add(TabControl1)
        Controls.Add(cbShowBrowser)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(btnClose)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
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
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAddTextNowAPI As Button
    Friend WithEvents lblLinkHome As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents cbShowBrowser As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents txtIPQualityScore As TextBox
    Friend WithEvents btnAPIcredit As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents btnIPQualityScore As Button
    Friend WithEvents btnSaveAPIs As Button
    Friend WithEvents btnRunScraper As Button
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents tbSerpAPI As TextBox
    Friend WithEvents tbSecurityTrailsAPI As TextBox
    Friend WithEvents tbShodanAPI As TextBox
    Friend WithEvents tbZoomEyeAPI As TextBox
    Friend WithEvents btnAddSMTP As Button
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents cbEnableSSL As ComboBox
    Friend WithEvents txtEmailPassword As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents btnAddEmailPass As Button
    Friend WithEvents txtEmailAddresses As TextBox
    Friend WithEvents txtSMTPbox As TextBox
End Class
