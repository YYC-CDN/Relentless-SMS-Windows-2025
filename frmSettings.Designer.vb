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
        Label1 = New Label()
        txtTextNowAPI = New TextBox()
        Label6 = New Label()
        btnAddTextNowAPI = New Button()
        lblLinkHome = New LinkLabel()
        Label2 = New Label()
        Label3 = New Label()
        RichTextBox2 = New RichTextBox()
        btnIPQualityScore = New Button()
        Label4 = New Label()
        txtIPQualityScore = New TextBox()
        Label5 = New Label()
        LinkLabel1 = New LinkLabel()
        Label7 = New Label()
        txtSMTPbox = New TextBox()
        txtPort = New TextBox()
        Label8 = New Label()
        Label9 = New Label()
        LinkLabel2 = New LinkLabel()
        cbEnableSSL = New ComboBox()
        btnAddSMTP = New Button()
        btnAddEmailPass = New Button()
        txtEmailAddresses = New TextBox()
        txtEmailPassword = New TextBox()
        Label11 = New Label()
        btnAPIcredit = New Button()
        cbShowBrowser = New CheckBox()
        TabControl1 = New TabControl()
        TabPage1 = New TabPage()
        TabPage2 = New TabPage()
        TabPage3 = New TabPage()
        TabControl1.SuspendLayout()
        TabPage1.SuspendLayout()
        TabPage2.SuspendLayout()
        TabPage3.SuspendLayout()
        SuspendLayout()
        ' 
        ' btnClose
        ' 
        btnClose.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnClose.Location = New Point(676, 208)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(107, 37)
        btnClose.TabIndex = 15
        btnClose.Text = "Close"
        btnClose.UseVisualStyleBackColor = True
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.Location = New Point(7, 49)
        Label1.Name = "Label1"
        Label1.Size = New Size(35, 16)
        Label1.TabIndex = 100
        Label1.Text = "API:"
        ' 
        ' txtTextNowAPI
        ' 
        txtTextNowAPI.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtTextNowAPI.Location = New Point(44, 46)
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
        btnAddTextNowAPI.Location = New Point(582, 44)
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
        lblLinkHome.Location = New Point(214, 17)
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
        ' RichTextBox2
        ' 
        RichTextBox2.BackColor = SystemColors.Control
        RichTextBox2.BorderStyle = BorderStyle.None
        RichTextBox2.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        RichTextBox2.Location = New Point(22, 81)
        RichTextBox2.Name = "RichTextBox2"
        RichTextBox2.Size = New Size(721, 33)
        RichTextBox2.TabIndex = 100
        RichTextBox2.Text = "To add an API, enter it in the textbox and click ""Add API"". The API will be added to the list, which will be cycled through when sending messages. You can enter the file by"
        ' 
        ' btnIPQualityScore
        ' 
        btnIPQualityScore.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnIPQualityScore.Location = New Point(510, 59)
        btnIPQualityScore.Name = "btnIPQualityScore"
        btnIPQualityScore.Size = New Size(212, 25)
        btnIPQualityScore.TabIndex = 3
        btnIPQualityScore.Text = "Add API for Number and Email Verification"
        btnIPQualityScore.UseVisualStyleBackColor = True
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.Location = New Point(21, 27)
        Label4.Name = "Label4"
        Label4.Size = New Size(568, 16)
        Label4.TabIndex = 100
        Label4.Text = "API for IP Quality Score to retrieve and validate phone numbers and email addresses"
        ' 
        ' txtIPQualityScore
        ' 
        txtIPQualityScore.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtIPQualityScore.Location = New Point(65, 60)
        txtIPQualityScore.Name = "txtIPQualityScore"
        txtIPQualityScore.PlaceholderText = "ZWm5zjhIU3aV18lRwnDxe6WKlYAxsCrX_EXAMPLE"
        txtIPQualityScore.Size = New Size(298, 23)
        txtIPQualityScore.TabIndex = 2
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.Location = New Point(21, 63)
        Label5.Name = "Label5"
        Label5.Size = New Size(35, 16)
        Label5.TabIndex = 100
        Label5.Text = "API:"
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LinkLabel1.LinkColor = Color.DarkViolet
        LinkLabel1.Location = New Point(492, 109)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(230, 16)
        LinkLabel1.TabIndex = 100
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Get the IP Quality Score API here"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.Location = New Point(11, 27)
        Label7.Name = "Label7"
        Label7.Size = New Size(44, 16)
        Label7.TabIndex = 100
        Label7.Text = "SMTP"
        ' 
        ' txtSMTPbox
        ' 
        txtSMTPbox.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtSMTPbox.Location = New Point(60, 23)
        txtSMTPbox.Name = "txtSMTPbox"
        txtSMTPbox.PlaceholderText = "smtp.yourdomain.com"
        txtSMTPbox.Size = New Size(193, 23)
        txtSMTPbox.TabIndex = 4
        ' 
        ' txtPort
        ' 
        txtPort.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtPort.Location = New Point(301, 23)
        txtPort.Name = "txtPort"
        txtPort.PlaceholderText = "587"
        txtPort.Size = New Size(58, 23)
        txtPort.TabIndex = 5
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label8.Location = New Point(260, 27)
        Label8.Name = "Label8"
        Label8.Size = New Size(34, 16)
        Label8.TabIndex = 100
        Label8.Text = "Port"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label9.Location = New Point(401, 27)
        Label9.Name = "Label9"
        Label9.Size = New Size(75, 16)
        Label9.TabIndex = 100
        Label9.Text = "EnableSSL"
        ' 
        ' LinkLabel2
        ' 
        LinkLabel2.AutoSize = True
        LinkLabel2.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        LinkLabel2.LinkColor = Color.DarkViolet
        LinkLabel2.Location = New Point(463, 97)
        LinkLabel2.Name = "LinkLabel2"
        LinkLabel2.Size = New Size(89, 16)
        LinkLabel2.TabIndex = 100
        LinkLabel2.TabStop = True
        LinkLabel2.Text = "clicking here"
        ' 
        ' cbEnableSSL
        ' 
        cbEnableSSL.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        cbEnableSSL.FormattingEnabled = True
        cbEnableSSL.Items.AddRange(New Object() {"Please Select", "True", "False"})
        cbEnableSSL.Location = New Point(480, 23)
        cbEnableSSL.Name = "cbEnableSSL"
        cbEnableSSL.Size = New Size(118, 24)
        cbEnableSSL.TabIndex = 6
        cbEnableSSL.Text = "Please Select"
        ' 
        ' btnAddSMTP
        ' 
        btnAddSMTP.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddSMTP.Location = New Point(602, 20)
        btnAddSMTP.Name = "btnAddSMTP"
        btnAddSMTP.Size = New Size(145, 30)
        btnAddSMTP.TabIndex = 7
        btnAddSMTP.Text = "Save SMTP Details"
        btnAddSMTP.UseVisualStyleBackColor = True
        ' 
        ' btnAddEmailPass
        ' 
        btnAddEmailPass.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAddEmailPass.Location = New Point(508, 66)
        btnAddEmailPass.Name = "btnAddEmailPass"
        btnAddEmailPass.Size = New Size(189, 30)
        btnAddEmailPass.TabIndex = 11
        btnAddEmailPass.Text = "Add Email and Password"
        btnAddEmailPass.UseVisualStyleBackColor = True
        ' 
        ' txtEmailAddresses
        ' 
        txtEmailAddresses.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmailAddresses.Location = New Point(11, 69)
        txtEmailAddresses.Name = "txtEmailAddresses"
        txtEmailAddresses.PlaceholderText = "oj.simpson@domain.com"
        txtEmailAddresses.Size = New Size(328, 23)
        txtEmailAddresses.TabIndex = 9
        ' 
        ' txtEmailPassword
        ' 
        txtEmailPassword.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        txtEmailPassword.Location = New Point(379, 69)
        txtEmailPassword.Name = "txtEmailPassword"
        txtEmailPassword.PlaceholderText = "iD1dnTd01T"
        txtEmailPassword.Size = New Size(105, 23)
        txtEmailPassword.TabIndex = 10
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        Label11.Location = New Point(11, 112)
        Label11.Name = "Label11"
        Label11.Size = New Size(604, 32)
        Label11.TabIndex = 101
        Label11.Text = "Enter SMTP once and save, then as many email addresses as you can, they will be added" & vbCrLf & "to the list it will email from in sequential order"
        ' 
        ' btnAPIcredit
        ' 
        btnAPIcredit.Enabled = False
        btnAPIcredit.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        btnAPIcredit.Location = New Point(372, 59)
        btnAPIcredit.Name = "btnAPIcredit"
        btnAPIcredit.Size = New Size(131, 25)
        btnAPIcredit.TabIndex = 102
        btnAPIcredit.Text = "Check API Credit Usage"
        btnAPIcredit.UseVisualStyleBackColor = True
        ' 
        ' cbShowBrowser
        ' 
        cbShowBrowser.AutoSize = True
        cbShowBrowser.Enabled = False
        cbShowBrowser.Font = New Font("Verdana", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        cbShowBrowser.Location = New Point(12, 215)
        cbShowBrowser.Name = "cbShowBrowser"
        cbShowBrowser.Size = New Size(142, 20)
        cbShowBrowser.TabIndex = 103
        cbShowBrowser.Text = "Leave Unchecked"
        cbShowBrowser.UseVisualStyleBackColor = True
        ' 
        ' TabControl1
        ' 
        TabControl1.Controls.Add(TabPage1)
        TabControl1.Controls.Add(TabPage2)
        TabControl1.Controls.Add(TabPage3)
        TabControl1.Location = New Point(7, 12)
        TabControl1.Name = "TabControl1"
        TabControl1.SelectedIndex = 0
        TabControl1.Size = New Size(780, 190)
        TabControl1.TabIndex = 104
        ' 
        ' TabPage1
        ' 
        TabPage1.Controls.Add(LinkLabel2)
        TabPage1.Controls.Add(RichTextBox2)
        TabPage1.Controls.Add(Label1)
        TabPage1.Controls.Add(txtTextNowAPI)
        TabPage1.Controls.Add(Label6)
        TabPage1.Controls.Add(btnAddTextNowAPI)
        TabPage1.Controls.Add(lblLinkHome)
        TabPage1.Location = New Point(4, 24)
        TabPage1.Name = "TabPage1"
        TabPage1.Padding = New Padding(3)
        TabPage1.Size = New Size(772, 162)
        TabPage1.TabIndex = 0
        TabPage1.Text = "Textbelt API"
        TabPage1.UseVisualStyleBackColor = True
        ' 
        ' TabPage2
        ' 
        TabPage2.Controls.Add(txtIPQualityScore)
        TabPage2.Controls.Add(Label5)
        TabPage2.Controls.Add(btnAPIcredit)
        TabPage2.Controls.Add(Label4)
        TabPage2.Controls.Add(LinkLabel1)
        TabPage2.Controls.Add(btnIPQualityScore)
        TabPage2.Location = New Point(4, 24)
        TabPage2.Name = "TabPage2"
        TabPage2.Padding = New Padding(3)
        TabPage2.Size = New Size(772, 162)
        TabPage2.TabIndex = 1
        TabPage2.Text = "IP Quality Score API"
        TabPage2.UseVisualStyleBackColor = True
        ' 
        ' TabPage3
        ' 
        TabPage3.Controls.Add(btnAddSMTP)
        TabPage3.Controls.Add(txtPort)
        TabPage3.Controls.Add(Label9)
        TabPage3.Controls.Add(Label11)
        TabPage3.Controls.Add(cbEnableSSL)
        TabPage3.Controls.Add(txtEmailPassword)
        TabPage3.Controls.Add(Label8)
        TabPage3.Controls.Add(Label7)
        TabPage3.Controls.Add(btnAddEmailPass)
        TabPage3.Controls.Add(txtEmailAddresses)
        TabPage3.Controls.Add(txtSMTPbox)
        TabPage3.Location = New Point(4, 24)
        TabPage3.Name = "TabPage3"
        TabPage3.Padding = New Padding(3)
        TabPage3.Size = New Size(772, 162)
        TabPage3.TabIndex = 2
        TabPage3.Text = "SMTP Details"
        TabPage3.UseVisualStyleBackColor = True
        ' 
        ' frmSettings
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(792, 250)
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
        TabPage2.ResumeLayout(False)
        TabPage2.PerformLayout()
        TabPage3.ResumeLayout(False)
        TabPage3.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents btnClose As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents txtTextNowAPI As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents btnAddTextNowAPI As Button
    Friend WithEvents lblLinkHome As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RichTextBox2 As RichTextBox
    Friend WithEvents btnIPQualityScore As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents txtIPQualityScore As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents Label7 As Label
    Friend WithEvents txtSMTPbox As TextBox
    Friend WithEvents txtPort As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents LinkLabel2 As LinkLabel
    Friend WithEvents cbEnableSSL As ComboBox
    Friend WithEvents btnAddSMTP As Button
    Friend WithEvents btnAddEmailPass As Button
    Friend WithEvents txtEmailAddresses As TextBox
    Friend WithEvents txtEmailPassword As TextBox
    Friend WithEvents Label11 As Label
    Friend WithEvents btnAPIcredit As Button
    Friend WithEvents cbShowBrowser As CheckBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents TabPage3 As TabPage
End Class
