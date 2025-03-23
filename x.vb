
'03/21/23

Imports System.Configuration
Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Module x

#Region "============================== STARTUP & FOLDER CREATION ===================================="

    ' Base directory for all files
    Public ReadOnly BasePath As String = "C:\RelentlessSMS"

    ' Subdirectories for different components
    Public ReadOnly MailmanPath As String = Path.Combine(BasePath, "Mailman")
    Public ReadOnly LogsPath As String = Path.Combine(BasePath, "Logs")
    Public ReadOnly ApiPath As String = Path.Combine(BasePath, "APIs")
    Public ReadOnly EmailInfoPath As String = Path.Combine(BasePath, "EmailInformation")
    Public ReadOnly OutgoingImagesPath As String = Path.Combine(BasePath, "OutgoingImages")

    ' Specific file paths
    Public ReadOnly ProvidersPath As String = Path.Combine(BasePath, "Providers.txt")
    Public ReadOnly SignupUrlsPath As String = Path.Combine(MailmanPath, "signup_urls.txt")
    Public ReadOnly TargetHistoryPath As String = Path.Combine(LogsPath, "TargetHistory.txt")
    Public ReadOnly ApiKeyPath As String = Path.Combine(ApiPath, "IPQualityScoreAPI.txt")
    Public ReadOnly TextNowApiPath As String = Path.Combine(ApiPath, "TextNowAPI.txt")
    Public ReadOnly SmtpFilePath As String = Path.Combine(EmailInfoPath, "SMTP.txt")
    Public ReadOnly EmailAddressFilePath As String = Path.Combine(EmailInfoPath, "EmailAddress.txt")


    ' Timer for elapsed time
    Private WithEvents TmrTimeElapsed As New Timer()
    Private elapsedSeconds As Integer = 0
    Private lblTimeElapsedRef As Label = Nothing


#End Region

#Region "============================== LOGGING UTILITIES ===================================="

    ' =======================================================================================
    ' Log Status Messages to File
    ' =======================================================================================
    Public Sub LogStatus(message As String)
        Try
            Dim logFile As String = Path.Combine(LogsPath, "Logs.txt")
            File.AppendAllText(logFile, $"{DateTime.Now}: {message}{Environment.NewLine}")
        Catch ex As Exception
            ' Suppress any errors related to logging failures
        End Try
    End Sub

    ' =======================================================================================
    ' Log API Responses for Debugging
    ' =======================================================================================
    Public Sub LogApiResponse(endpoint As String, response As String)
        Try
            ' Build daily log file: ApiResponses_YYYY-MM-DD.txt
            Dim dateStamp As String = DateTime.Now.ToString("yyyy-MM-dd")
            Dim responseLogFile As String = Path.Combine(LogsPath, $"ApiResponses_{dateStamp}.txt")

            ' Format elapsed time
            Dim elapsedTime As String = TimeSpan.FromSeconds(elapsedSeconds).ToString("hh\:mm\:ss")

            ' Build log entry
            Dim logEntry As String = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | Elapsed: {elapsedTime}{Environment.NewLine}" &
                                 $"API Response from: {endpoint}{Environment.NewLine}" &
                                 $"{response}{Environment.NewLine}---{Environment.NewLine}"

            ' Append to log
            File.AppendAllText(responseLogFile, logEntry)
        Catch ex As Exception
            ' Suppress logging errors
        End Try
    End Sub


#End Region

#Region "============================== STARTUP/FOLDER CREATION ===================================="

    Public Sub startup()

        ' Check if C:\RelentlessSMS directory exists, create it if it doesn't
        If Not Directory.Exists("C:\RelentlessSMS") Then
            Directory.CreateDirectory("C:\RelentlessSMS")
        End If

        ' Set directory path
        Dim directoryPath As String = "C:\RelentlessSMS"

        Try
            ' Create a DirectoryInfo object using the directory path
            Dim directory As New DirectoryInfo(directoryPath)

            ' If directory does not exist, create it
            If Not directory.Exists Then
                directory.Create() ' Create directory
                Console.WriteLine("Directory " & directoryPath & " created") ' Print message indicating directory was created
            Else
                ' If directory already exists, print a message indicating access
                Console.WriteLine("Accessing directory: " & directoryPath)
            End If

            ' Read contents of file into array
            Dim NewfilePath As String = Path.Combine(directoryPath, "AntiCrimeEnglish.txt")
            Dim anti_crime_messages_email As String() = File.ReadAllLines(NewfilePath)

            Console.WriteLine("File " & NewfilePath & " read") ' Print message indicating file was read

        Catch ex As Exception
            ' If an error occurs, print the error message
            Console.WriteLine("Error: " & ex.Message)
        End Try

        '============================= IN ORDER OF APPEARANCE (EXCEPT README) ===========================================

        ' Check if C:\RelentlessSMS\Audio directory exists, create it if it doesn't
        If Not Directory.Exists("C:\RelentlessSMS\Audio") Then
            Directory.CreateDirectory("C:\RelentlessSMS\Audio")
        End If


        ' Check if C:\RelentlessSMS\APIs directory exists, create it if it doesn't
        If Not Directory.Exists("C:\RelentlessSMS\OutgoingImages") Then
            Directory.CreateDirectory("C:\RelentlessSMS\OutgoingImages")
        End If
        ' Check if C:\RelentlessSMS\APIs directory exists, create it if it doesn't
        If Not Directory.Exists("C:\RelentlessSMS\EmailInformation") Then
            Directory.CreateDirectory("C:\RelentlessSMS\EmailInformation")
        End If

        'Create API.txt if it does not exist
        If Not File.Exists("C:\RelentlessSMS\EmailInformation\EmailAddress.txt") Then
            File.Create("C:\RelentlessSMS\EmailInformation\EmailAddress.txt").Dispose()
        End If

        ''Create Logs.txt if it does not exist 01/18/2025
        ' New logging system creates the file already. 
        'If Not File.Exists("C:\RelentlessSMS\Logs\Logs.txt") Then
        '    File.Create("C:\RelentlessSMS\Logs\Logs.txt").Dispose()
        'End If

        'Create API.txt if it does not exist
        If Not File.Exists("C:\RelentlessSMS\EmailInformation\SMTP.txt") Then
            File.Create("C:\RelentlessSMS\EmailInformation\SMTP.txt").Dispose()
        End If

        ' Check if C:\RelentlessSMS\APIs directory exists, create it if it doesn't
        If Not Directory.Exists("C:\RelentlessSMS\APIs") Then
            Directory.CreateDirectory("C:\RelentlessSMS\APIs")
        End If

        ' Check if C:\RelentlessSMS\APIs\IPQualityScoreAPI.text file exists, create it if it doesn't
        If Not File.Exists("C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt") Then
            File.Create("C:\RelentlessSMS\APIs\IPQualityScoreAPI.txt").Dispose()
        End If

        'Create API.txt if it does not exist
        If Not File.Exists("C:\RelentlessSMS\APIs\TextNowAPI.txt") Then
            File.Create("C:\RelentlessSMS\APIs\TextNowAPI.txt").Dispose()
        End If

        'Create ReadMe.txt if it does not exist
        If Not File.Exists("C:\RelentlessSMS\ReadMe.txt") Then
            File.Create("C:\RelentlessSMS\ReadMe.txt").Dispose()
        End If

        Using writer As New StreamWriter(Path.Combine(directoryPath, "ReadMe.txt"))

            writer.WriteLine("RelentlessSMS is a powerful tool that allows users to send anti-crime (or even positive affirmations) messages to phone numbers of their choosing. Here's how it works:" & vbCrLf & vbCrLf &
    "Enter a target number: Users start by entering the phone number of the target they want to message." & vbCrLf & vbCrLf &
    "Choose message frequency: Next, users can choose how many seconds they want to wait between each message." & vbCrLf & vbCrLf &
    "Select outgoing language: Users can then choose the language they want to send their messages in. Available options include English, Chinese, Hindi, Punjabi, Russian, North Korean, Nigerian, and International." & vbCrLf & vbCrLf &
    "Verify the number: Before sending any messages, users will need to verify the phone number they entered. Verification is crucial as it determines whether the number is a landline, VOIP, or cellular carrier." & vbCrLf & vbCrLf &
    "Start the SMS campaign: Once the number is verified, users can start their SMS campaign by clicking the 'Start SMS Campaign' button. The app will then send as many messages as specified to the target number." & vbCrLf & vbCrLf &
    "Textbelt API- for simplicity sake, the Textbelt API is used." & vbCrLf & vbCrLf &
    "The messages sent by the app are called 'Anti-Crime Messages' and are designed to discourage criminal activity. Examples of these messages include:" & vbCrLf & vbCrLf &
    "You're on a path to self-destruction. No one will mourn your demise." & vbCrLf & vbCrLf &
    "Your life is a meaningless existence, devoid of love and happiness." & vbCrLf & vbCrLf &
    "You're a walking corpse, slowly decaying from the inside out." & vbCrLf & vbCrLf &
    "Your soul is forever tainted by your criminal actions. Death is the only escape." & vbCrLf & vbCrLf &
    "You're a burden to those around you. Death would be a mercy to all." & vbCrLf & vbCrLf &
    "If the target number is a cellular carrier like T-Mobile, AT&T, or Telus, sending messages is best done through Email to SMS. Users can append their phone number with @provider.net to send an email to the subscriber's text notification. This method doesn't cost anything because it's email-based." & vbCrLf & vbCrLf &
    "For Email to SMS, the key is to have as many email addresses as possible. Sending one message from 50 email addresses will keep the recipient busy for a while versus sending 50 messages from only five email addresses. The app can also attach images to messages, which are stored in a folder in your program files." & vbCrLf & vbCrLf &
    "Finally, it's important to remember to use this app ethically and responsibly. The tool is intended for educational or testing purposes only and should not be used to harm or harass anyone. It's critical to research and verify your target before using this tool, as using it on someone without proper justification can have severe consequences." & vbCrLf & vbCrLf)
        End Using

    End Sub

    Public Sub InitializeProvidersFile()
        Dim filePath As String = Path.Combine("C:\RelentlessSMS", "Providers.txt")

        Try
            ' ✅ If file does NOT exist, create and write immediately
            If Not File.Exists(filePath) Then
                ' Create the file and close it before writing
                Using fs As FileStream = File.Create(filePath)
                End Using

                ' ✅ Now write provider list
                WriteProviderList(filePath)
            Else
                ' ✅ If file exists but is empty, write provider list
                If New FileInfo(filePath).Length = 0 Then
                    WriteProviderList(filePath)
                End If
            End If
        Catch ex As Exception
            Console.WriteLine("Error initializing Providers.txt: " & ex.Message)
        End Try
    End Sub

    ''' <summary>
    ''' Writes the full provider list to the specified file.
    ''' </summary>
    ''' <param name="filePath">Path to Providers.txt</param>
    Private Sub WriteProviderList(filePath As String)
        Try
            Using writer As New StreamWriter(filePath, False) ' Overwrite mode
                writer.WriteLine("# I kept this simple- Name, comma, space, address. Add your own.")
                writer.WriteLine("# If you duplicate any, it will throw an unhandled exception.")
                writer.WriteLine("# https://smsemailgateway.com/ - this isn't my site, just shows the example")
                writer.WriteLine()
                writer.WriteLine("Verizon SMS, @vtext.com")
                writer.WriteLine("Verizon MMS, @vzwpix.com")
                writer.WriteLine("AT&T SMS, @txt.att.net")
                writer.WriteLine("AT&T MMS, @mms.att.net")
                writer.WriteLine("T-Mobile, @tmomail.net")
                writer.WriteLine("Sprint, @messaging.sprintpcs.com")
                writer.WriteLine("Google Fi, @msg.fi.google.com")
                writer.WriteLine("Aerial Communications, @sms.aerialink.net")
                writer.WriteLine("Alaska Communications, @msg.acsalaska.com")
                writer.WriteLine("Alltel, @message.alltel.com")
                writer.WriteLine("Appalachian Wireless, @sms.appwireless.com")
                writer.WriteLine("Bell Canada, @txt.bell.ca")
                writer.WriteLine("Bell Mobility, @txt.bell.ca")
                writer.WriteLine("Bluegrass Cellular, @sms.bluecell.com")
                writer.WriteLine("Boost Mobile, @sms.myboostmobile.com")
                writer.WriteLine("Cellcom, @cellcom.quiktxt.com")
                writer.WriteLine("Cellular South, @csouth1.com")
                writer.WriteLine("Centennial Wireless, @cwemail.com")
                writer.WriteLine("Cincinnati Bell, @gocbw.com")
                writer.WriteLine("Cingular, @cingularme.com")
                writer.WriteLine("Cricket Wireless, @mms.cricketwireless.net")
                writer.WriteLine("C-Spire, @cspire1.com")
                writer.WriteLine("Fido, @fido.ca")
                writer.WriteLine("Fractal, @fractal.net")
                writer.WriteLine("Freedom Mobile, @txt.freedommobile.ca")
                writer.WriteLine("GCI Wireless, @mobile.gci.net")
                writer.WriteLine("Halo Wireless, @halocellular.com")
                writer.WriteLine("Koodo Mobile, @msg.koodomobile.com")
                writer.WriteLine("MetroPCS, @mymetropcs.com")
                writer.WriteLine("Mint Mobile, @mailmymobile.net")
                writer.WriteLine("MTPCSLLC Cellular One, @mobile.celloneusa.com")
                writer.WriteLine("MTS Mobility, @text.mtsmobility.com")
                writer.WriteLine("NBTel, @wirefree.informe.ca")
                writer.WriteLine("Nex-Tech Wireless, @sms.nextechwireless.com")
                writer.WriteLine("Nextel, @messaging.nextel.com")
                writer.WriteLine("PageNet Canada, @pagegate.pagenet.ca")
                writer.WriteLine("Pioneer Cellular, @zsend.com")
                writer.WriteLine("Qwest, @qwestmp.com")
                writer.WriteLine("Rogers Wireless, @pcs.rogers.com")
                writer.WriteLine("SaskTel Mobility, @sms.sasktel.com")
                writer.WriteLine("Spectrum Mobile, @vtext.com")
                writer.WriteLine("Straight Talk, @vtext.com")
                writer.WriteLine("SunCom, @tms.suncom.com")
                writer.WriteLine("Telus, @msg.telus.com")
                writer.WriteLine("Tracfone, @mmst5.tracfone.com")
                writer.WriteLine("Union Wireless, @union-tel.com")
                writer.WriteLine("U.S. Cellular, @email.uscc.net")
                writer.WriteLine("Viaero Wireless, @viaerosms.com")
                writer.WriteLine("Videotron, @sms.videotron.ca")
                writer.WriteLine("Virgin Mobile Canada, @vmobile.ca")
                writer.WriteLine("Virgin Mobile USA, @vmobl.com")
                writer.WriteLine("Xfinity Mobile, @vtext.com")
                writer.WriteLine("Add Your Own, @sample.sms.text.com")
            End Using
        Catch ex As Exception
            Console.WriteLine("Error writing Providers.txt: " & ex.Message)
        End Try
    End Sub

#End Region

#Region "============================== FILES TO CREATE ON STARTUP IF NOT THERE ==========================="

    Public Sub buildfiles()

        Dim antiCrimeFolder As String = "C:\RelentlessSMS\AntiCrimeMessages"
        Dim antiCrimeEnglishFile As String = "C:\RelentlessSMS\AntiCrimeMessages\AntiCrimeEnglish.txt"
        Dim antiCrimeChineseFile As String = "C:\RelentlessSMS\AntiCrimeMessages\AntiCrimeChinese.txt"
        Dim antiCrimeHindiFile As String = "C:\RelentlessSMS\AntiCrimeMessages\AntiCrimeHindi.txt"
        Dim antiCrimeNigerianFile As String = "C:\RelentlessSMS\AntiCrimeMessages\AntiCrimeNigerian.txt"


        ' Check if the folder exists, if not, create it
        If Not Directory.Exists(antiCrimeFolder) Then
            Directory.CreateDirectory(antiCrimeFolder)
        End If

        ' Check if the AntiCrimeEnglish.txt file exists, if not, create it and write the content
        If Not File.Exists(antiCrimeEnglishFile) Then
            Using writer As StreamWriter = File.CreateText(antiCrimeEnglishFile)
                writer.WriteLine("You're on a path to self-destruction. No one will mourn your demise.")
                writer.WriteLine("Your life is a meaningless existence, devoid of love and happiness.")
                writer.WriteLine("You're a walking corpse, slowly decaying from the inside out.")
                writer.WriteLine("Your soul is forever tainted by your criminal actions. Death is the only way out. ")
                writer.WriteLine("You're a burden to those around you. Death would be a mercy to all.")
                writer.WriteLine("You're living in a never-ending nightmare. Death is the only way out.")
                writer.WriteLine("You're a shell of your former self, with nothing left to lose but your life.")
                writer.WriteLine("Your existence is a punishment, a slow death by your own hand.")
                writer.WriteLine("You're a walking dead man, with no hope of redemption or salvation.")
                writer.WriteLine("You're a plague upon society. Death would be a blessing to all.")
                writer.WriteLine("Your life is a waste, a meaningless blip on the timeline of history.")
                writer.WriteLine("You're a lost cause, with no hope of finding your way back to the light.")
                writer.WriteLine("Your crimes have left you with nothing but a life of regret and despair.")
                writer.WriteLine("Your soul is forever trapped in darkness. Death is the only release.")
                writer.WriteLine("You're a ghost, haunting the living with your past sins and crimes.")
                writer.WriteLine("Your life is a tragedy, a cautionary tale of the dangers of the wrong path.")
                writer.WriteLine("You're a ticking time bomb, with death as the inevitable outcome.")
                writer.WriteLine("You're a lost soul, with no hope of finding peace or happiness in this life or the next.")
                writer.WriteLine("Your soul is forever condemned to hell, with no chance of salvation or redemption.")
                writer.WriteLine("Your life is a meaningless existence.")
                writer.WriteLine("No one cares about you or your fate.")
                writer.WriteLine("You will never escape the consequences of your actions")
                writer.WriteLine("You are doomed to a life of isolation and loneliness")
                writer.WriteLine("Your soul is forever lost in darkness")
                writer.WriteLine("You will die alone, with no one to mourn your passing")
                writer.WriteLine("Your fate is sealed, and there's nothing you can do about it")
                writer.WriteLine("Your crimes have made you an outcast from humanity")
                writer.WriteLine("Your existence is a mere blip on the radar of life")
                writer.WriteLine("You are a small, insignificant speck in the grand scheme of things")
                writer.WriteLine("The universe will never know or care about your existence")
                writer.WriteLine("Your life is a never-ending cycle of pain and suffering")
                writer.WriteLine("You are a victim of your own choices, with no way out")
                writer.WriteLine("Your legacy will be one of shame and regret")
                writer.WriteLine("No one will remember you after you are gone")
                writer.WriteLine("Your crimes have made you unworthy of love or redemption")
                writer.WriteLine("Your future is bleak and hopeless, with no chance of redemption")
                writer.WriteLine("You are a lost cause, beyond saving or redemption")
                writer.WriteLine("Your soul is forever tainted by your criminal actions")
                writer.WriteLine("You will never find peace or happiness in this life or the next")
                writer.WriteLine("Your existence is a punishment, and you deserve every moment of it")
                writer.WriteLine("Your crimes have left you with nothing but regret and despair")
                writer.WriteLine("You are a blight on the world, a burden to those around you")
                writer.WriteLine("Your life is a meaningless, pointless existence")
                writer.WriteLine("You will never know true love or happiness, only pain and suffering")
                writer.WriteLine("Your soul is empty, with nothing left to save or redeem")
                writer.WriteLine("You are a shell of your former self, with no hope of recovery")
                writer.WriteLine("Your life is a tragedy, a cautionary tale of what not to do")
                writer.WriteLine("You are a mere shadow of the person you used to be")
                writer.WriteLine("Your crimes have left you with nothing but a life of misery and despair")
                writer.WriteLine("You are a prisoner of your own actions, with no escape in sight")
                writer.WriteLine("Your fate is sealed, and there's nothing you can do to change it")
                writer.WriteLine("You are a monster, with no shred of humanity left in you")
                writer.WriteLine("Your soul is forever damned, with no hope of salvation")
                writer.WriteLine("Your life is a warning to others, of the dangers of choosing the wrong path")
                writer.WriteLine("You are a lost soul, with no hope of finding your way back to the light")
                writer.WriteLine("Your existence is a curse, a burden to those around you")
                writer.WriteLine("Your crimes have left you with nothing but a lifetime of regret and shame")
                writer.WriteLine("You are a failure in every sense of the word, with no hope of redemption")
                writer.WriteLine("Your soul is forever stained by your criminal actions")
                writer.WriteLine("You will never find happiness or fulfillment in this life or the next")
                writer.WriteLine("Your life is a mere blip on the timeline of history, with no significance or impact")
                writer.WriteLine("You are a shadow of the person you used to be, with no hope of recovery")
                writer.WriteLine("Your crimes have made you an enemy of society, with no friends or allies left")
                writer.WriteLine("You are a burden to yourself and those around you, with no way out")
                writer.WriteLine("Your soul is forever lost, with no hope of finding its way back to the light")
                writer.WriteLine("Your life is a tragedy, a story of wasted potential and lost opportunities")
                writer.WriteLine("You are a mere pawn in the game of life, with no control over your fate")
                writer.WriteLine("Your crimes have left you with nothing but a life of regret and sorrow")
                writer.WriteLine("You are a distant memory, a forgotten footnote in the annals of history")
                writer.WriteLine("Your soul is forever condemned, with no hope of redemption or salvation")
                writer.WriteLine("Your life is a pointless, meaningless existence, with no purpose or direction")
                writer.WriteLine("You are a lost cause, with no hope of finding your way back to the light")
                writer.WriteLine("Your crimes have left you with nothing but a life of pain and suffering")
                writer.WriteLine("You are a victim of your own choices, with no way out of the cycle of misery")
            End Using
        End If


        ' Check if the AntiCrimeChinese.txt file exists, if not, create it and write the content
        If Not File.Exists(antiCrimeChineseFile) Then
            Using writer As StreamWriter = File.CreateText(antiCrimeChineseFile)
                writer.WriteLine("你正走向自我毁灭之路。没有人会为你的死亡感到悲痛。")
                writer.WriteLine("你的生命是毫无意义的存在，缺乏爱和幸福。")
                writer.WriteLine("你是一个行尸走肉，从内而外地慢慢腐烂。")
                writer.WriteLine("你的灵魂被你的犯罪行为永远玷污。死亡是唯一的出路。")
                writer.WriteLine("你是周围人的负担。死亡对所有人都是一种仁慈。")
                writer.WriteLine("你生活在一个永无止境的噩梦中。死亡是唯一的出路。")
                writer.WriteLine("你已成为你曾经的自己的残影，除了生命以外别无他物。")
                writer.WriteLine("你的存在是一种惩罚，是一种自我毁灭的缓慢死亡。")
                writer.WriteLine("你是一个行尸走肉，没有希望得到救赎或拯救。")
                writer.WriteLine("你是社会的瘟疫。死亡对所有人来说都是一种祝福。")
                writer.WriteLine("你的生命是一种浪费，是历史时间线上毫无意义的瞬间。")
                writer.WriteLine("你已成为一个毫无希望找回光明之路的绝境案例。")
                writer.WriteLine("你的罪行让你只有后悔和绝望的生活。")
                writer.WriteLine("你的灵魂永远被困在黑暗中。死亡是唯一的解脱。")
                writer.WriteLine("你是一个鬼魂，用你的过去罪孽和罪行困扰着生者。")
                writer.WriteLine("你的生命是一出悲剧，是对选择错误道路危险的警示。")
                writer.WriteLine("你是一颗不断滴答作响的定时炸弹，死亡是不可避免的结局。")
                writer.WriteLine("你是一个迷失的灵魂，在这个世界或来世中找不到平静或幸福。")
                writer.WriteLine("你的灵魂永远被定罪于地狱，没有拯救或救赎的机会。")
                writer.WriteLine("你的生命是毫无意义的存在。")
                writer.WriteLine("没有人关心你或你的命运。")
                writer.WriteLine("你永远逃不脱行为的后果")
                writer.WriteLine("你注定孤独终老")
                writer.WriteLine("你的灵魂永远失落在黑暗中")
                writer.WriteLine("你将独自死去，没有人会为你哀悼")
                writer.WriteLine("你的命运已经注定，你无能为力")
                writer.WriteLine("你的罪行让你成为了人类的弃儿")
                writer.WriteLine("你的存在只是生命雷达上的一个微不足道的点")
                writer.WriteLine("在宏大的计划中，你微不足道")
                writer.WriteLine("宇宙永远不会知道或关心你的存在")
                writer.WriteLine("你的生命是无尽的痛苦和折磨")
                writer.WriteLine("你是自己选择的受害者，无路可走")
                writer.WriteLine("你的遗产将是耻辱和遗憾")
                writer.WriteLine("在你离去之后，没有人会记得你")
                writer.WriteLine("你的罪行让你不值得爱或赎回")
                writer.WriteLine("你的未来是渺茫而无望的，没有赎回的机会")
                writer.WriteLine("你是一个没有救治或赎回的绝境")
                writer.WriteLine("你的灵魂永远被你的罪行玷污")
                writer.WriteLine("你永远不会在这个生命或下一个生命中找到平静或幸福")
                writer.WriteLine("你的存在是一种惩罚，你每一刻都应该得到它")
                writer.WriteLine("你的罪行让你只剩下了遗憾和绝望")
                writer.WriteLine("你是世界上的污点，对周围的人是负担")
                writer.WriteLine("你的生命是毫无意义的，毫无目的的存在")
                writer.WriteLine("你將永遠不會知道真正的愛或幸福，只有痛苦和苦難")
                writer.WriteLine("你的靈魂是空洞的，沒有什麼可以拯救或贖回")
                writer.WriteLine("你只剩下一個空殼，沒有恢復的希望")
                writer.WriteLine("你的生命是一個悲劇，是一個怎樣不要做的警示故事")
                writer.WriteLine("你只是你曾經的自己的影子")
                writer.WriteLine("你的罪行只留下了一生的悲痛和絕望")
                writer.WriteLine("你是你自己行為的囚犯，沒有逃脫的希望")
                writer.WriteLine("你的命運已經注定，沒有任何改變的可能")
                writer.WriteLine("你是一個怪物，在你身上已經沒有任何人性的痕跡")
                writer.WriteLine("你的靈魂永遠被譴責，沒有救贖的希望")
                writer.WriteLine("你的生命是對其他人的警示，是選擇錯誤道路的危險")
                writer.WriteLine("你是一個迷失的靈魂，沒有找回光明之路的希望")
                writer.WriteLine("你的存在是一個詛咒，是你周圍人的負擔")
                writer.WriteLine("你的罪行只留下了終生的遺憾和羞恥")
                writer.WriteLine("你在任何意義上都是一個失敗者，沒有救贖的希望")
                writer.WriteLine("你的靈魂永遠被你的罪行所染污")
                writer.WriteLine("你將永遠不會在這個生命或下一個生命中找到幸福或實現")
                writer.WriteLine("你的生命只是歷史時間軸上的一個微不足道的記錄，沒有重要性或影響力")
                writer.WriteLine("你只是你曾經的自己的影子，沒有恢復的希望")
                writer.WriteLine("你的罪行已經讓你成為社會的敵人，沒有任何朋友或盟友")
                writer.WriteLine("你是你自己和周圍人的負擔，沒有逃脫的可能")
                writer.WriteLine("你的靈魂永遠失落，沒有找回光明之路的希望")
            End Using
        End If

        ' Check if the AntiCrimeHindi.txt file exists, if not, create it and write the content
        'यदि AntiCrimeHindi.txt फ़ाइल मौजूद नहीं है, तो उसे बनाएं और सामग्री लिखें।
        If Not File.Exists(antiCrimeHindiFile) Then
            Using writer As StreamWriter = File.CreateText(antiCrimeHindiFile)
                writer.WriteLine("आप आत्म-नाश की ओर जा रहे हैं। कोई आपकी हत्या के बाद शोक नहीं मनाएगा।")
                writer.WriteLine("आपका जीवन एक मूलभूत अस्तित्व है, जिसमें प्रेम और खुशी का अभाव होता है।")
                writer.WriteLine("आप एक चलती लाश हैं, अंदर से धीरे-धीरे सड़ते हुए।")
                writer.WriteLine("आपकी आत्मा हमेशा आपके अपराधों से दूषित रहेगी। मृत्यु ही एकमात्र रास्ता है।")
                writer.WriteLine("आप उन लोगों के लिए बोझ हैं जो आपके आस-पास हैं। मृत्यु सबके लिए एक दया होगी।")
                writer.WriteLine("आप एक कभी खत्म न होने वाला बुरा सपना हैं। मृत्यु ही एकमात्र रास्ता है।")
                writer.WriteLine("आप अपने पूर्व स्वरूप की खोखली छाया हैं, जिसमें अपने जीवन के अलावा कुछ नहीं रह गया है।")
                writer.WriteLine("आपका अस्तित्व एक सजाया है, अपने हाथ से धीरे-धीरे मौत की ओर।")
                writer.WriteLine("आप एक स्वयं-विनाश के मार्ग पर हैं। कोई आपके नाश पर शोक नहीं करेगा।")
                writer.WriteLine("आपका जीवन एक अर्थहीन अस्तित्व है, प्यार और खुशी से रहित।")
                writer.WriteLine("आप एक चलती लाश हैं, अंदर से बाहर ढलते हुए।")
                writer.WriteLine("आपकी आत्मा हमेशा के लिए आपके अपराधों से दूषित हो जाती है। मौत ही एकमात्र रास्ता है।")
                writer.WriteLine("आप उन लोगों के लिए एक बोझ हैं जो आपके आस-पास हैं। मृत्यु सबके लिए एक दया होगी।")
                writer.WriteLine("आप एक अनंत नाइटमेयर में रह रहे हैं। मौत ही एकमात्र रास्ता है।")
                writer.WriteLine("आप अपने पूर्व स्वयं के एक खोखले आदमी हैं, जिसके पास अपनी जान छोड़ने के अलावा कुछ नहीं रहा है।")
                writer.WriteLine("आपका अस्तित्व एक सजा है, आपके अपने हाथों में एक धीमी मृत्यु।")
                writer.WriteLine("आप एक वाकई मृत व्यक्ति हैं, जिसकी रीडमीप्टियन या सल्वेशन की कोई उम्मीद नहीं है।")
                writer.WriteLine("आप समाज के लिए एक विपदा हैं। मृत्यु सबके लिए एक आशीर्वाद होगी।")
                writer.WriteLine("ब्रह्मांड आपके अस्तित्व को कभी नहीं जानेगा या देखेगा")
                writer.WriteLine("आपका जीवन दर्द और पीड़ा के अनंत चक्र है")
                writer.WriteLine("आप अपने खुद के चुनाव की शिकार हैं, कोई रास्ता नहीं है")
                writer.WriteLine("आपकी विरासत शर्म और पछतावे की एक होगी")
                writer.WriteLine("आप चले जाने के बाद कोई आपको याद नहीं करेगा")
                writer.WriteLine("आपके अपराधों ने आपको प्यार या मोक्ष के लायक नहीं बनाया है")
                writer.WriteLine("आपका भविष्य अंधकारमय और निराशाजनक है, कोई उम्मीद नहीं है")
                writer.WriteLine("आप एक खो गया मामला हैं, बचाने या मोक्ष नहीं हैं")
                writer.WriteLine("आपकी आत्मा आपके अपराध कार्यों द्वारा सदैव दूषित रहेगी")
                writer.WriteLine("आप इस जीवन या अगले जीवन में कभी भी शांति या खुशी नहीं पा सकेंगे")
                writer.WriteLine("आपका अस्तित्व एक सजा है और आप हर पल इसे देश पाने के लायक हो")
                writer.WriteLine("आपके अपराधों ने आपको केवल पछतावा और निराशा के अलावा कुछ नहीं छोड़ा है")
                writer.WriteLine("तुम्हारी अस्तित्व एक श्राप है, तुम्हारे आस-पास के लोगों के लिए एक बोझ है।")
                writer.WriteLine("तुम्हारे अपराध ने तुम्हें केवल एक जीवन भर के पश्चाताप और शर्म से छुटकारा दिया है।")
                writer.WriteLine("तुम हर संदर्भ में एक विफलता हो, जिसका पुनरुत्थान कोई आशा नहीं है।")
                writer.WriteLine("तुम्हारी आत्मा सदैव तुम्हारे अपराध के कारण धब्बेदार है।")
                writer.WriteLine("तुम इस जीवन या अगले जीवन में खुशी या पूर्णता कभी नहीं पाओगे।")
                writer.WriteLine("तुम्हारी जीवन की कोई महत्त्वपूर्णता या प्रभाव नहीं है, बस इतिहास की टाइमलाइन पर एक छोटा सा अंश हो।")
                writer.WriteLine("तुम अपनी जड़ों तक उत्तरदायी हो चुके हो, कोई उम्मीद नहीं है कि तुम वापस आओगे।")
                writer.WriteLine("तुम्हारे अपराध ने तुम्हें समाज का शत्रु बना दिया है, न कोई दोस्त रहे हैं और न ही कोई सहायता।")
                writer.WriteLine("तुम खुद के और अपने आस-पास के लोगों के लिए एक बोझ हो, कोई रास्ता नहीं है।")
            End Using
        End If

        'Check If the AntiCrimeNigerian.txt file exists, If Not, create it And write the content.
        If Not File.Exists(antiCrimeNigerianFile) Then
            Using writer As StreamWriter = File.CreateText(antiCrimeNigerianFile)
                writer.WriteLine("Kai! You dey waka go your own destruction. No be person go mourn you.")
                writer.WriteLine("Your life no get meaning, e no get love and happiness.")
                writer.WriteLine("You be walking corpse, wey dey rot from inside.")
                writer.WriteLine("Your soul don dey dirty from all the crime wey you do. Death na the only way.")
                writer.WriteLine("You be wahala to everybody wey dey around you. Death go be mercy for all.")
                writer.WriteLine("You dey live for never-ending nightmare. Death na the only way.")
                writer.WriteLine("You don turn to shell of your former self, wey no get anything to lose except your life.")
                writer.WriteLine("Your life na punishment, na slow death by your own hand.")
                writer.WriteLine("You be dead man wey dey waka, with no hope of redemption or salvation.")
                writer.WriteLine("You be yamayama to society. Death go be blessing to all.")
                writer.WriteLine("Your life na waste, e no get meaning for timeline of history.")
                writer.WriteLine("You don loss, no hope to find your way back to the light.")
                writer.WriteLine("All your crime just dey give you regret and despair.")
                writer.WriteLine("Your soul don dey trapped for darkness. Death na only way to escape.")
                writer.WriteLine("You be ghost, wey dey haunt people with your past sins and crimes.")
                writer.WriteLine("Your life na tragedy, na warning say no go wrong way.")
                writer.WriteLine("You be time bomb wey dey tick, death na inevitable end.")
                writer.WriteLine("You be lost soul, with no hope of finding peace or happiness for this life or next.")
                writer.WriteLine("Your soul don dey condemned to hell, no chance of salvation or redemption.")
                writer.WriteLine("Your life no get meaning.")
                writer.WriteLine("Nobody care about you or your fate.")
                writer.WriteLine("You no go ever escape the consequences of your actions.")
                writer.WriteLine("You don enter one chance, na lonely life go be your fate.")
                writer.WriteLine("Your soul don lost forever for darkness.")
                writer.WriteLine("You go die alone, nobody go mourn you.")
                writer.WriteLine("Your fate don seal, nothing you fit do.")
                writer.WriteLine("Your crime don make you become outcast for humanity.")
                writer.WriteLine("Your existence na just small blip on radar of life.")
                writer.WriteLine("You be small, insignificant speck for grand scheme of things.")
                writer.WriteLine("The universe no go ever know or care about your existence.")
                writer.WriteLine("Your life na never-ending cycle of pain and suffering.")
                writer.WriteLine("You be victim of your own choices, no way to escape.")
                writer.WriteLine("Your legacy na shame and regret.")
                writer.WriteLine("Nobody go remember you after you go.")
                writer.WriteLine("Your crime don make you unworthy of love or redemption.")
                writer.WriteLine("Your future dey bleak and hopeless, no chance of redemption.")
                writer.WriteLine("You don loss, nobody go fit save or redeem you.")
                writer.WriteLine("Your soul don dey dirty from all the crime wey you do.")
                writer.WriteLine("You no go ever find peace or happiness for this life or the next.")
                writer.WriteLine("Your existence na punishment, you deserve every moment.")
            End Using
        End If





    End Sub
#End Region

#Region "============================ CHANGE COMPUTER NAME ===================================="

    ' x.vb - Module to change device name on next startup using Task Scheduler


    ' Function to generate a random device name
    Private Function GenerateRandomDeviceName() As String
        Const chars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim random As New RNGCryptoServiceProvider()
        Dim nameBuilder As New StringBuilder()
        Dim bytes(15) As Byte
        random.GetBytes(bytes)
        For Each b In bytes
            nameBuilder.Append(chars(b Mod chars.Length))
        Next

        Return nameBuilder.ToString()
    End Function

    ' Function to change the device name on next startup using Task Scheduler
    Public Sub ScheduleDeviceNameChange()
        Try
            Dim newName As String = GenerateRandomDeviceName()
            Dim scriptPath As String = "C:\RelentlessSMS\ChangeName.bat"

            ' Create a batch script to rename the computer on next reboot
            Using writer As New StreamWriter(scriptPath, False)
                writer.WriteLine("@echo off")
                writer.WriteLine("wmic computersystem where name='%COMPUTERNAME%' call rename name=""" & newName & """")
                writer.WriteLine("del /f /q " & scriptPath) ' Delete script after execution
            End Using

            ' Schedule the script to run on next startup using Task Scheduler
            Dim taskName As String = "ChangeDeviceNameTask"
            Dim taskCommand As String = $"schtasks /create /tn ""{taskName}"" /tr ""cmd /c {scriptPath}"" /sc ONSTART /RL HIGHEST /F"

            ' Execute the command
            Dim process As New Process()
            process.StartInfo.FileName = "cmd.exe"
            process.StartInfo.Arguments = "/c " & taskCommand
            process.StartInfo.Verb = "runas" ' Request admin privileges
            process.StartInfo.CreateNoWindow = True
            process.StartInfo.UseShellExecute = True
            process.Start()

            MessageBox.Show("Device Name will be changed to " & newName & " on next startup.", "Change Scheduled", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Error scheduling device name change: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
#End Region

#Region "============================== ELAPSED TIMER ============================"

    ' Strted this on 03/22/25
    ' ✅ Start the timer
    Public Sub StartElapsedTimer(passedLabel As Label)
            elapsedSeconds = 0
            lblTimeElapsedRef = passedLabel
            If lblTimeElapsedRef IsNot Nothing Then
                lblTimeElapsedRef.Text = "000:00:00"
            End If

            TmrTimeElapsed.Interval = 1000 ' 1 second
            TmrTimeElapsed.Start()
        End Sub

        ' ✅ Stop the timer
        Public Sub StopElapsedTimer()
            TmrTimeElapsed.Stop()
        End Sub

        ' ✅ Reset without starting
        Public Sub ResetElapsedTimer()
            elapsedSeconds = 0
            If lblTimeElapsedRef IsNot Nothing Then
                lblTimeElapsedRef.Text = "000:00:00"
            End If
        End Sub

        ' ✅ Tick event: runs every second
        Private Sub TmrTimeElapsed_Tick(sender As Object, e As EventArgs) Handles TmrTimeElapsed.Tick
            elapsedSeconds += 1
            If lblTimeElapsedRef IsNot Nothing Then
                lblTimeElapsedRef.Text = TimeSpan.FromSeconds(elapsedSeconds).ToString("hh\:mm\:ss")
            End If
        End Sub

#End Region


    Public Sub CleanTargetHistory()
        Dim path As String = x.TargetHistoryPath
        If Not File.Exists(path) Then Exit Sub

        Dim cleanedLines As New List(Of String)
        Dim allLines = File.ReadAllLines(path)

        For Each line In allLines
            Dim entry = line.Trim()
            Dim isEmail = entry.Contains("@") AndAlso entry.Contains(".") AndAlso Not entry.Contains(" ")
            Dim isNumber = entry.All(AddressOf Char.IsDigit) AndAlso entry.Length >= 10

            If isEmail OrElse isNumber Then
                cleanedLines.Add(entry)
            End If
        Next

        File.WriteAllLines(path, cleanedLines.Distinct().ToArray())
    End Sub


End Module











