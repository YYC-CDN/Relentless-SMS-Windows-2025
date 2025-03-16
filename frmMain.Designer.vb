<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmMain))
        cbImagesCheckbox = New CheckBox()
        phone_number_label = New Label()
        SplitContainer1 = New SplitContainer()
        LinkLabel1 = New LinkLabel()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        btnEmailToSMS = New Button()
        dbSelectCellProvider = New ComboBox()
        txtSecondsBetween = New TextBox()
        lblOutgoingLanguage = New Label()
        lblSecondsBetween = New Label()
        dbOutgoingLanguage = New ComboBox()
        txtNumberofMessages = New TextBox()
        number_of_messages_label = New Label()
        btnSendSMS = New Button()
        txtOutgoingMessages = New TextBox()
        pbAllFunctions = New ProgressBar()
        txtTargetNumber = New TextBox()
        btnSettings = New Button()
        btnClose = New Button()
        tmrMessagesRemaining = New Timer(components)
        ToolTip1 = New ToolTip(components)
        btnVerifyNumber = New Button()
        btnMailbaitSubmit = New Button()
        Label1 = New Label()
        txtOpenTabs = New TextBox()
        btnEmailValidation = New Button()
        lblRegion = New Label()
        Label3 = New Label()
        btnMailman = New Button()
        btnStopAll = New Button()
        Label5 = New Label()
        Label7 = New Label()
        txtSuccessful = New TextBox()
        txtFailed = New TextBox()
        btnChangeName = New Button()
        TextBox1 = New TextBox()
        Label4 = New Label()
        lblProxy = New Label()
        lblCountryCode = New Label()
        lblVPN = New Label()
        VPN_Timer = New Timer(components)
        txtVerificationResults = New RichTextBox()
        btnAutoDialer = New Button()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' cbImagesCheckbox
        ' 
        cbImagesCheckbox.AutoSize = True
        cbImagesCheckbox.Checked = True
        cbImagesCheckbox.CheckState = CheckState.Checked
        cbImagesCheckbox.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        cbImagesCheckbox.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        cbImagesCheckbox.Location = New Point(235, 313)
        cbImagesCheckbox.Name = "cbImagesCheckbox"
        cbImagesCheckbox.Size = New Size(411, 25)
        cbImagesCheckbox.TabIndex = 1
        cbImagesCheckbox.Text = "Check to send Images with Email to SMS E2SMS (only)"
        ToolTip1.SetToolTip(cbImagesCheckbox, resources.GetString("cbImagesCheckbox.ToolTip"))
        cbImagesCheckbox.UseVisualStyleBackColor = True
        ' 
        ' phone_number_label
        ' 
        phone_number_label.AutoSize = True
        phone_number_label.Font = New Font("Segoe UI Variable Display", 21.75F, FontStyle.Bold, GraphicsUnit.Point)
        phone_number_label.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        phone_number_label.Location = New Point(488, 24)
        phone_number_label.Name = "phone_number_label"
        phone_number_label.Size = New Size(348, 38)
        phone_number_label.TabIndex = 3
        phone_number_label.Text = "Target Number or Email:"
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Location = New Point(1, 60)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.BackColor = Color.Gainsboro
        SplitContainer1.Panel1.BackgroundImageLayout = ImageLayout.Center
        SplitContainer1.Panel1.Controls.Add(LinkLabel1)
        SplitContainer1.Panel1.Controls.Add(Label2)
        SplitContainer1.Size = New Size(54, 79)
        SplitContainer1.SplitterDistance = 25
        SplitContainer1.TabIndex = 4
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.AutoSize = True
        LinkLabel1.BackColor = Color.Transparent
        LinkLabel1.Font = New Font("Verdana", 12F, FontStyle.Bold, GraphicsUnit.Point)
        LinkLabel1.LinkColor = Color.White
        LinkLabel1.Location = New Point(121, 609)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(0, 18)
        LinkLabel1.TabIndex = 17
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Verdana", 14.25F, FontStyle.Regular, GraphicsUnit.Point)
        Label2.ForeColor = SystemColors.ControlLightLight
        Label2.Location = New Point(-3321, 274)
        Label2.Name = "Label2"
        Label2.Size = New Size(732, 161)
        Label2.TabIndex = 2
        Label2.Text = resources.GetString("Label2.Text")
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), Image)
        PictureBox1.Location = New Point(0, 0)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(211, 631)
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' btnEmailToSMS
        ' 
        btnEmailToSMS.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnEmailToSMS.BackgroundImageLayout = ImageLayout.Center
        btnEmailToSMS.Cursor = Cursors.Hand
        btnEmailToSMS.FlatAppearance.BorderColor = Color.Black
        btnEmailToSMS.Font = New Font("Segoe UI Variable Display", 9F, FontStyle.Bold, GraphicsUnit.Point)
        btnEmailToSMS.ForeColor = SystemColors.ControlLightLight
        btnEmailToSMS.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnEmailToSMS.Location = New Point(11, 172)
        btnEmailToSMS.Name = "btnEmailToSMS"
        btnEmailToSMS.Size = New Size(190, 37)
        btnEmailToSMS.TabIndex = 8
        btnEmailToSMS.Text = "Start Email to SMS Campaign"
        ToolTip1.SetToolTip(btnEmailToSMS, "Use your internal email address to send messages to the target, the ones you added in Settings.")
        btnEmailToSMS.UseVisualStyleBackColor = False
        ' 
        ' dbSelectCellProvider
        ' 
        dbSelectCellProvider.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        dbSelectCellProvider.FlatStyle = FlatStyle.Flat
        dbSelectCellProvider.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dbSelectCellProvider.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        dbSelectCellProvider.FormattingEnabled = True
        dbSelectCellProvider.ItemHeight = 17
        dbSelectCellProvider.Location = New Point(430, 267)
        dbSelectCellProvider.MaxDropDownItems = 15
        dbSelectCellProvider.Name = "dbSelectCellProvider"
        dbSelectCellProvider.Size = New Size(263, 25)
        dbSelectCellProvider.TabIndex = 3
        dbSelectCellProvider.Text = "Please Select"
        ToolTip1.SetToolTip(dbSelectCellProvider, "This is a list of carriers providing Short Message Service (SMS) transit via SMS gateways." & vbCrLf & "You can modify this file here- C:\RelentlessSMS\Providers.txt")
        ' 
        ' txtSecondsBetween
        ' 
        txtSecondsBetween.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        txtSecondsBetween.BorderStyle = BorderStyle.None
        txtSecondsBetween.Font = New Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtSecondsBetween.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        txtSecondsBetween.Location = New Point(654, 182)
        txtSecondsBetween.Name = "txtSecondsBetween"
        txtSecondsBetween.Size = New Size(32, 20)
        txtSecondsBetween.TabIndex = 3
        txtSecondsBetween.Text = "1"
        ToolTip1.SetToolTip(txtSecondsBetween, "How many seconds between messages sent")
        ' 
        ' lblOutgoingLanguage
        ' 
        lblOutgoingLanguage.AutoSize = True
        lblOutgoingLanguage.Font = New Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        lblOutgoingLanguage.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        lblOutgoingLanguage.Location = New Point(235, 224)
        lblOutgoingLanguage.Name = "lblOutgoingLanguage"
        lblOutgoingLanguage.Size = New Size(294, 20)
        lblOutgoingLanguage.TabIndex = 8
        lblOutgoingLanguage.Text = "Select an Outgoing Language (E2SMS Only):"
        ToolTip1.SetToolTip(lblOutgoingLanguage, "Pick an outgoing language- this only works with" & vbCrLf & "a standard SMS campaign. Using this with Email to SMS" & vbCrLf & "sends random jibberish. Email to SMS is English only.")
        ' 
        ' lblSecondsBetween
        ' 
        lblSecondsBetween.AutoSize = True
        lblSecondsBetween.Font = New Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        lblSecondsBetween.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        lblSecondsBetween.Location = New Point(235, 181)
        lblSecondsBetween.Name = "lblSecondsBetween"
        lblSecondsBetween.Size = New Size(412, 20)
        lblSecondsBetween.TabIndex = 6
        lblSecondsBetween.Text = "Seconds between TEXTBELT or E2SMS messages (default is 1):"
        ToolTip1.SetToolTip(lblSecondsBetween, resources.GetString("lblSecondsBetween.ToolTip"))
        ' 
        ' dbOutgoingLanguage
        ' 
        dbOutgoingLanguage.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        dbOutgoingLanguage.FlatStyle = FlatStyle.Flat
        dbOutgoingLanguage.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        dbOutgoingLanguage.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        dbOutgoingLanguage.FormattingEnabled = True
        dbOutgoingLanguage.ItemHeight = 17
        dbOutgoingLanguage.Location = New Point(535, 221)
        dbOutgoingLanguage.Name = "dbOutgoingLanguage"
        dbOutgoingLanguage.Size = New Size(158, 25)
        dbOutgoingLanguage.TabIndex = 9
        ToolTip1.SetToolTip(dbOutgoingLanguage, "Select an outgoing language. Messages will send in that language")
        ' 
        ' txtNumberofMessages
        ' 
        txtNumberofMessages.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        txtNumberofMessages.BorderStyle = BorderStyle.None
        txtNumberofMessages.Font = New Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        txtNumberofMessages.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        txtNumberofMessages.Location = New Point(630, 141)
        txtNumberofMessages.Name = "txtNumberofMessages"
        txtNumberofMessages.Size = New Size(37, 20)
        txtNumberofMessages.TabIndex = 2
        txtNumberofMessages.Text = "1"
        ToolTip1.SetToolTip(txtNumberofMessages, "The number of total outgoing messages")
        ' 
        ' number_of_messages_label
        ' 
        number_of_messages_label.AutoSize = True
        number_of_messages_label.Font = New Font("Segoe UI Variable Display", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        number_of_messages_label.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        number_of_messages_label.Location = New Point(235, 140)
        number_of_messages_label.Name = "number_of_messages_label"
        number_of_messages_label.Size = New Size(392, 20)
        number_of_messages_label.TabIndex = 4
        number_of_messages_label.Text = "Number of overall TEXTBELT or E2SMS messages to target:"
        ' 
        ' btnSendSMS
        ' 
        btnSendSMS.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnSendSMS.BackgroundImageLayout = ImageLayout.Center
        btnSendSMS.Cursor = Cursors.Hand
        btnSendSMS.FlatAppearance.BorderColor = Color.Black
        btnSendSMS.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        btnSendSMS.ForeColor = SystemColors.ControlLightLight
        btnSendSMS.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnSendSMS.Location = New Point(11, 135)
        btnSendSMS.Name = "btnSendSMS"
        btnSendSMS.Size = New Size(190, 37)
        btnSendSMS.TabIndex = 7
        btnSendSMS.Text = "TEXTBELT SMS Campaign"
        ToolTip1.SetToolTip(btnSendSMS, "TEXTBELT | Starts the SMS/Text Message Campaign against a regular cellular number" & vbCrLf & "that recieves regular text messages, or SMS messages.")
        btnSendSMS.UseVisualStyleBackColor = False
        ' 
        ' txtOutgoingMessages
        ' 
        txtOutgoingMessages.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        txtOutgoingMessages.BorderStyle = BorderStyle.None
        txtOutgoingMessages.Font = New Font("Segoe UI Variable Display Semib", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        txtOutgoingMessages.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        txtOutgoingMessages.Location = New Point(231, 497)
        txtOutgoingMessages.Multiline = True
        txtOutgoingMessages.Name = "txtOutgoingMessages"
        txtOutgoingMessages.PlaceholderText = "Preview of Target Screen"
        txtOutgoingMessages.ReadOnly = True
        txtOutgoingMessages.Size = New Size(861, 87)
        txtOutgoingMessages.TabIndex = 99
        txtOutgoingMessages.TextAlign = HorizontalAlignment.Center
        ' 
        ' pbAllFunctions
        ' 
        pbAllFunctions.BackColor = Color.FromArgb(CByte(34), CByte(39), CByte(42))
        pbAllFunctions.ForeColor = Color.FromArgb(CByte(34), CByte(39), CByte(42))
        pbAllFunctions.Location = New Point(232, 593)
        pbAllFunctions.MarqueeAnimationSpeed = 200
        pbAllFunctions.Maximum = 500
        pbAllFunctions.Name = "pbAllFunctions"
        pbAllFunctions.Size = New Size(664, 25)
        pbAllFunctions.TabIndex = 11
        ' 
        ' txtTargetNumber
        ' 
        txtTargetNumber.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        txtTargetNumber.BorderStyle = BorderStyle.None
        txtTargetNumber.Font = New Font("Segoe UI Variable Display", 15.75F, FontStyle.Bold, GraphicsUnit.Point)
        txtTargetNumber.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        txtTargetNumber.Location = New Point(237, 76)
        txtTargetNumber.MaxLength = 45
        txtTargetNumber.Name = "txtTargetNumber"
        txtTargetNumber.PlaceholderText = "202456TEST or example@domain.ca"
        txtTargetNumber.Size = New Size(856, 28)
        txtTargetNumber.TabIndex = 1
        txtTargetNumber.TextAlign = HorizontalAlignment.Center
        ToolTip1.SetToolTip(txtTargetNumber, "This is your TARGET NUMBER or EMAIL. Be very, very sure this is the" & vbCrLf & "number you want to influence. Don't harass innocent people. ")
        txtTargetNumber.WordWrap = False
        ' 
        ' btnSettings
        ' 
        btnSettings.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnSettings.BackgroundImageLayout = ImageLayout.Center
        btnSettings.Cursor = Cursors.Hand
        btnSettings.FlatAppearance.BorderColor = Color.Black
        btnSettings.Font = New Font("Segoe UI Variable Display", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        btnSettings.ForeColor = SystemColors.ControlLightLight
        btnSettings.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnSettings.Location = New Point(11, 437)
        btnSettings.Name = "btnSettings"
        btnSettings.Size = New Size(190, 37)
        btnSettings.TabIndex = 11
        btnSettings.Text = "Settings"
        ToolTip1.SetToolTip(btnSettings, "Program Settings")
        btnSettings.UseVisualStyleBackColor = False
        ' 
        ' btnClose
        ' 
        btnClose.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnClose.BackgroundImageLayout = ImageLayout.Center
        btnClose.Cursor = Cursors.Hand
        btnClose.FlatAppearance.BorderColor = Color.Black
        btnClose.Font = New Font("Segoe UI Variable Display", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        btnClose.ForeColor = SystemColors.ControlLightLight
        btnClose.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnClose.Location = New Point(11, 476)
        btnClose.Name = "btnClose"
        btnClose.Size = New Size(190, 37)
        btnClose.TabIndex = 12
        btnClose.Text = "Close"
        ToolTip1.SetToolTip(btnClose, "Close Relentless SMS")
        btnClose.UseVisualStyleBackColor = False
        ' 
        ' tmrMessagesRemaining
        ' 
        tmrMessagesRemaining.Enabled = True
        tmrMessagesRemaining.Interval = 5000
        ' 
        ' btnVerifyNumber
        ' 
        btnVerifyNumber.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnVerifyNumber.Cursor = Cursors.Hand
        btnVerifyNumber.FlatAppearance.BorderColor = Color.Black
        btnVerifyNumber.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point)
        btnVerifyNumber.ForeColor = Color.LimeGreen
        btnVerifyNumber.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnVerifyNumber.Location = New Point(11, 323)
        btnVerifyNumber.Name = "btnVerifyNumber"
        btnVerifyNumber.Size = New Size(190, 37)
        btnVerifyNumber.TabIndex = 10
        btnVerifyNumber.Text = "Number Validation"
        ToolTip1.SetToolTip(btnVerifyNumber, "Phone number validation tool")
        btnVerifyNumber.UseVisualStyleBackColor = False
        ' 
        ' btnMailbaitSubmit
        ' 
        btnMailbaitSubmit.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnMailbaitSubmit.Cursor = Cursors.Hand
        btnMailbaitSubmit.FlatAppearance.BorderColor = Color.Black
        btnMailbaitSubmit.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        btnMailbaitSubmit.ForeColor = SystemColors.ControlLight
        btnMailbaitSubmit.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnMailbaitSubmit.Location = New Point(11, 210)
        btnMailbaitSubmit.Name = "btnMailbaitSubmit"
        btnMailbaitSubmit.Size = New Size(190, 37)
        btnMailbaitSubmit.TabIndex = 9
        btnMailbaitSubmit.Text = "MAILBAIT Campaign"
        ToolTip1.SetToolTip(btnMailbaitSubmit, "MAILBAIT  | SpamSend V1, uses mailbait.info to submit" & vbCrLf & "the senders email to the mailman mail servers. Keep it open" & vbCrLf & "as long as possible. Don't close this. EVER." & vbCrLf)
        btnMailbaitSubmit.UseVisualStyleBackColor = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label1.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        Label1.Location = New Point(235, 357)
        Label1.Name = "Label1"
        Label1.Size = New Size(293, 21)
        Label1.TabIndex = 22
        Label1.Text = "Number of MAILBAIT tabs (50 is default):"
        ToolTip1.SetToolTip(Label1, resources.GetString("Label1.ToolTip"))
        ' 
        ' txtOpenTabs
        ' 
        txtOpenTabs.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        txtOpenTabs.BorderStyle = BorderStyle.None
        txtOpenTabs.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtOpenTabs.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        txtOpenTabs.Location = New Point(554, 357)
        txtOpenTabs.Name = "txtOpenTabs"
        txtOpenTabs.PlaceholderText = "25"
        txtOpenTabs.Size = New Size(40, 22)
        txtOpenTabs.TabIndex = 6
        ToolTip1.SetToolTip(txtOpenTabs, "The more, the better. Don't ever close this window. 50 for 24 hours is great. 75 tabs for 72 hours is brutal. ")
        ' 
        ' btnEmailValidation
        ' 
        btnEmailValidation.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnEmailValidation.Cursor = Cursors.Hand
        btnEmailValidation.FlatAppearance.BorderColor = Color.Black
        btnEmailValidation.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point)
        btnEmailValidation.ForeColor = Color.LimeGreen
        btnEmailValidation.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnEmailValidation.Location = New Point(11, 360)
        btnEmailValidation.Name = "btnEmailValidation"
        btnEmailValidation.Size = New Size(190, 37)
        btnEmailValidation.TabIndex = 101
        btnEmailValidation.Text = "Email Validation"
        ToolTip1.SetToolTip(btnEmailValidation, "Phone number validation tool")
        btnEmailValidation.UseVisualStyleBackColor = False
        ' 
        ' lblRegion
        ' 
        lblRegion.AutoSize = True
        lblRegion.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        lblRegion.ForeColor = SystemColors.ControlLightLight
        lblRegion.Location = New Point(12, 568)
        lblRegion.Name = "lblRegion"
        lblRegion.Size = New Size(98, 15)
        lblRegion.TabIndex = 104
        lblRegion.Text = "Region: waiting..."
        lblRegion.TextAlign = Drawing.ContentAlignment.MiddleCenter
        ToolTip1.SetToolTip(lblRegion, "ON or OFF. Make sure it's ON ")
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        Label3.Cursor = Cursors.Hand
        Label3.Font = New Font("Segoe UI Variable Display Semib", 9F, FontStyle.Bold, GraphicsUnit.Point)
        Label3.ForeColor = SystemColors.ControlLightLight
        Label3.Location = New Point(12, 529)
        Label3.Name = "Label3"
        Label3.Size = New Size(137, 16)
        Label3.TabIndex = 110
        Label3.Text = "YOUR IP INFORMATION:"
        Label3.TextAlign = Drawing.ContentAlignment.MiddleCenter
        ToolTip1.SetToolTip(Label3, "This is YOUR IP information- know before you send!")
        ' 
        ' btnMailman
        ' 
        btnMailman.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnMailman.Cursor = Cursors.Hand
        btnMailman.FlatAppearance.BorderColor = Color.Black
        btnMailman.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Bold, GraphicsUnit.Point)
        btnMailman.ForeColor = SystemColors.ControlLight
        btnMailman.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnMailman.Location = New Point(11, 247)
        btnMailman.Name = "btnMailman"
        btnMailman.Size = New Size(190, 37)
        btnMailman.TabIndex = 111
        btnMailman.Text = "MAILMAN Campaign"
        ToolTip1.SetToolTip(btnMailman, "Under Construction")
        btnMailman.UseVisualStyleBackColor = False
        ' 
        ' btnStopAll
        ' 
        btnStopAll.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnStopAll.BackgroundImageLayout = ImageLayout.Center
        btnStopAll.Cursor = Cursors.Hand
        btnStopAll.FlatAppearance.BorderColor = Color.Black
        btnStopAll.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Bold, GraphicsUnit.Point)
        btnStopAll.ForeColor = Color.Red
        btnStopAll.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnStopAll.Location = New Point(11, 397)
        btnStopAll.Name = "btnStopAll"
        btnStopAll.Size = New Size(190, 37)
        btnStopAll.TabIndex = 112
        btnStopAll.Text = "Stop All"
        ToolTip1.SetToolTip(btnStopAll, "Stop ALL Attacks")
        btnStopAll.UseVisualStyleBackColor = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label5.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        Label5.Location = New Point(234, 398)
        Label5.Name = "Label5"
        Label5.Size = New Size(249, 21)
        Label5.TabIndex = 115
        Label5.Text = "MAILMAN Submissions Complete:"
        ToolTip1.SetToolTip(Label5, "MAILMAN Campaign Stats")
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label7.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        Label7.Location = New Point(560, 398)
        Label7.Name = "Label7"
        Label7.Size = New Size(53, 21)
        Label7.TabIndex = 118
        Label7.Text = "Failed:"
        ToolTip1.SetToolTip(Label7, "MAILMAN Campaign Stats")
        ' 
        ' txtSuccessful
        ' 
        txtSuccessful.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        txtSuccessful.BorderStyle = BorderStyle.None
        txtSuccessful.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtSuccessful.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        txtSuccessful.Location = New Point(491, 398)
        txtSuccessful.Name = "txtSuccessful"
        txtSuccessful.PlaceholderText = "00000"
        txtSuccessful.Size = New Size(64, 22)
        txtSuccessful.TabIndex = 114
        txtSuccessful.TextAlign = HorizontalAlignment.Center
        ToolTip1.SetToolTip(txtSuccessful, "MAILMAN Campaign Stats")
        ' 
        ' txtFailed
        ' 
        txtFailed.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        txtFailed.BorderStyle = BorderStyle.None
        txtFailed.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        txtFailed.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        txtFailed.Location = New Point(612, 398)
        txtFailed.Name = "txtFailed"
        txtFailed.PlaceholderText = "00000"
        txtFailed.Size = New Size(62, 22)
        txtFailed.TabIndex = 117
        txtFailed.TextAlign = HorizontalAlignment.Center
        ToolTip1.SetToolTip(txtFailed, "MAILMAN Campaign Stats")
        ' 
        ' btnChangeName
        ' 
        btnChangeName.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnChangeName.BackgroundImageLayout = ImageLayout.Center
        btnChangeName.Cursor = Cursors.Hand
        btnChangeName.FlatAppearance.BorderColor = Color.Black
        btnChangeName.Font = New Font("Segoe UI Variable Display Light", 11.25F, FontStyle.Regular, GraphicsUnit.Point)
        btnChangeName.ForeColor = SystemColors.ControlLightLight
        btnChangeName.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnChangeName.Location = New Point(1071, 593)
        btnChangeName.Name = "btnChangeName"
        btnChangeName.Size = New Size(25, 25)
        btnChangeName.TabIndex = 121
        ToolTip1.SetToolTip(btnChangeName, "Change Machine Name on next startup to a random value")
        btnChangeName.UseVisualStyleBackColor = False
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        TextBox1.CharacterCasing = CharacterCasing.Upper
        TextBox1.Font = New Font("Segoe UI Variable Display", 9.75F, FontStyle.Regular, GraphicsUnit.Point)
        TextBox1.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        TextBox1.Location = New Point(902, 594)
        TextBox1.MaxLength = 30
        TextBox1.Name = "TextBox1"
        TextBox1.PlaceholderText = "REFERENCE:"
        TextBox1.Size = New Size(166, 25)
        TextBox1.TabIndex = 122
        ToolTip1.SetToolTip(TextBox1, "Add reference info here. It is volitile memory.")
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point)
        Label4.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        Label4.Location = New Point(235, 270)
        Label4.Name = "Label4"
        Label4.Size = New Size(189, 21)
        Label4.TabIndex = 103
        Label4.Text = "Select a Cellular Provider:"
        ' 
        ' lblProxy
        ' 
        lblProxy.AutoSize = True
        lblProxy.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        lblProxy.ForeColor = SystemColors.ControlLightLight
        lblProxy.Location = New Point(12, 587)
        lblProxy.Name = "lblProxy"
        lblProxy.Size = New Size(91, 15)
        lblProxy.TabIndex = 107
        lblProxy.Text = "Proxy: waiting..."
        lblProxy.TextAlign = Drawing.ContentAlignment.MiddleCenter
        ' 
        ' lblCountryCode
        ' 
        lblCountryCode.AutoSize = True
        lblCountryCode.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        lblCountryCode.ForeColor = SystemColors.ControlLightLight
        lblCountryCode.Location = New Point(12, 606)
        lblCountryCode.Name = "lblCountryCode"
        lblCountryCode.Size = New Size(104, 15)
        lblCountryCode.TabIndex = 108
        lblCountryCode.Text = "Country: waiting..."
        lblCountryCode.TextAlign = Drawing.ContentAlignment.MiddleCenter
        ' 
        ' lblVPN
        ' 
        lblVPN.AutoSize = True
        lblVPN.BackColor = Color.FromArgb(CByte(18), CByte(18), CByte(18))
        lblVPN.ForeColor = SystemColors.ControlLightLight
        lblVPN.Location = New Point(12, 550)
        lblVPN.Name = "lblVPN"
        lblVPN.Size = New Size(84, 15)
        lblVPN.TabIndex = 109
        lblVPN.Text = "VPN: waiting..."
        lblVPN.TextAlign = Drawing.ContentAlignment.MiddleCenter
        ' 
        ' VPN_Timer
        ' 
        VPN_Timer.Enabled = True
        VPN_Timer.Interval = 250
        ' 
        ' txtVerificationResults
        ' 
        txtVerificationResults.BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        txtVerificationResults.BorderStyle = BorderStyle.None
        txtVerificationResults.Font = New Font("Segoe UI Variable Display", 9F, FontStyle.Regular, GraphicsUnit.Point)
        txtVerificationResults.ForeColor = Color.FromArgb(CByte(209), CByte(219), CByte(221))
        txtVerificationResults.Location = New Point(729, 138)
        txtVerificationResults.Name = "txtVerificationResults"
        txtVerificationResults.ReadOnly = True
        txtVerificationResults.ScrollBars = RichTextBoxScrollBars.None
        txtVerificationResults.Size = New Size(364, 357)
        txtVerificationResults.TabIndex = 119
        txtVerificationResults.Text = resources.GetString("txtVerificationResults.Text")
        ' 
        ' btnAutoDialer
        ' 
        btnAutoDialer.BackColor = Color.FromArgb(CByte(64), CByte(64), CByte(64))
        btnAutoDialer.BackgroundImageLayout = ImageLayout.Center
        btnAutoDialer.Cursor = Cursors.Hand
        btnAutoDialer.FlatAppearance.BorderColor = Color.Black
        btnAutoDialer.Font = New Font("Segoe UI Variable Display", 11.25F, FontStyle.Bold, GraphicsUnit.Point)
        btnAutoDialer.ForeColor = SystemColors.ControlLightLight
        btnAutoDialer.ImageAlign = Drawing.ContentAlignment.MiddleLeft
        btnAutoDialer.Location = New Point(11, 285)
        btnAutoDialer.Name = "btnAutoDialer"
        btnAutoDialer.Size = New Size(190, 37)
        btnAutoDialer.TabIndex = 123
        btnAutoDialer.Text = "Auto Dialer"
        ToolTip1.SetToolTip(btnAutoDialer, "Close Relentless SMS")
        btnAutoDialer.UseVisualStyleBackColor = False
        ' 
        ' frmMain
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(30), CByte(30), CByte(30))
        ClientSize = New Size(1108, 630)
        Controls.Add(btnAutoDialer)
        Controls.Add(TextBox1)
        Controls.Add(btnChangeName)
        Controls.Add(txtVerificationResults)
        Controls.Add(Label7)
        Controls.Add(txtFailed)
        Controls.Add(Label5)
        Controls.Add(txtSuccessful)
        Controls.Add(btnStopAll)
        Controls.Add(btnMailman)
        Controls.Add(Label3)
        Controls.Add(lblVPN)
        Controls.Add(lblRegion)
        Controls.Add(Label4)
        Controls.Add(lblCountryCode)
        Controls.Add(lblProxy)
        Controls.Add(btnEmailValidation)
        Controls.Add(txtOutgoingMessages)
        Controls.Add(btnClose)
        Controls.Add(Label1)
        Controls.Add(btnEmailToSMS)
        Controls.Add(btnMailbaitSubmit)
        Controls.Add(txtOpenTabs)
        Controls.Add(lblOutgoingLanguage)
        Controls.Add(cbImagesCheckbox)
        Controls.Add(btnSendSMS)
        Controls.Add(dbSelectCellProvider)
        Controls.Add(dbOutgoingLanguage)
        Controls.Add(number_of_messages_label)
        Controls.Add(lblSecondsBetween)
        Controls.Add(txtSecondsBetween)
        Controls.Add(txtNumberofMessages)
        Controls.Add(btnSettings)
        Controls.Add(btnVerifyNumber)
        Controls.Add(PictureBox1)
        Controls.Add(txtTargetNumber)
        Controls.Add(phone_number_label)
        Controls.Add(pbAllFunctions)
        Controls.Add(SplitContainer1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MaximizeBox = False
        Name = "frmMain"
        Opacity = 0.99R
        StartPosition = FormStartPosition.CenterScreen
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents cbImagesCheckbox As CheckBox
    Friend WithEvents phone_number_label As Label
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label2 As Label
    Friend WithEvents txtTargetNumber As TextBox
    Friend WithEvents dbOutgoingLanguage As ComboBox
    Friend WithEvents lblOutgoingLanguage As Label
    Friend WithEvents txtSecondsBetween As TextBox
    Friend WithEvents lblSecondsBetween As Label
    Friend WithEvents txtNumberofMessages As TextBox
    Friend WithEvents number_of_messages_label As Label
    Friend WithEvents pbAllFunctions As ProgressBar
    Friend WithEvents btnSendSMS As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnEmailToSMS As Button
    Friend WithEvents dbSelectCellProvider As ComboBox
    Friend WithEvents txtOutgoingMessages As TextBox
    Friend WithEvents btnSettings As Button
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents LinkLabel1 As LinkLabel
    Friend WithEvents tmrMessagesRemaining As Timer
    Friend WithEvents ToolTip1 As ToolTip
    Friend WithEvents btnVerifyNumber As Button
    Friend WithEvents btnMailbaitSubmit As Button
    Friend WithEvents txtOpenTabs As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnEmailValidation As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents lblRegion As Label
    Friend WithEvents lblProxy As Label
    Friend WithEvents lblCountryCode As Label
    Friend WithEvents lblVPN As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btnMailman As Button
    Friend WithEvents btnStopAll As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents txtSuccessful As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtFailed As TextBox
    Friend WithEvents VPN_Timer As Timer
    Friend WithEvents txtVerificationResults As RichTextBox
    Friend WithEvents btnChangeName As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents btnAutoDialer As Button
End Class
