Public Class Project
    Public ini(20) As String 'Массив файла .ini
    Public FileNameQ As String 'Путь и имя файла базы вопросов
    Public questionText As String 'Текст выбранного вопроса
    Dim currentBlock0(,) As String 'Временный массив
    Public currentBlock1(150, 8) As String 'Массив русификации
    Public currentBlock2(,) As String 'Массив вопросов
    Dim rightAnswerNumber As Integer 'Номер правильного ответа (1-4) РЕЖИССЁРУ (см. QuestionListBox; numberRightAnswer то же самое ДЛЯ ВСЕХ)
    Public rightAnswerText As String 'Текст правильного ответа РЕЖИССЁРУ
    Public textAnswerA As String 'Текст ответа A ИГРОКУ/ВЕДУЩЕМУ
    Public textAnswerB As String 'Текст ответа B ИГРОКУ/ВЕДУЩЕМУ
    Public textAnswerC As String 'Текст ответа C ИГРОКУ/ВЕДУЩЕМУ
    Public textAnswerD As String 'Текст ответа D ИГРОКУ/ВЕДУЩЕМУ
    Public playerAnswerNumber As Integer 'Номер принятого ответа игрока
    Public numberRightAnswer As Integer 'Номер правильного ответа ИГРОКУ/ВЕДУЩЕМУ
    Public questionNumber As Integer 'Номер текущего вопроса
    Public batFileName As String 'Имя музыкального файла для *.bat
    Public sourcePath As String 'Путь ресурсной папки
    Public langSource As String 'Путь ресурсов локализации
    Public winampOn As Integer 'Состояние работы внешнего проигрывателя
    Public winNumber As Integer 'Кол-во выигранных вопросов
    Public activ50 As String 'Состояние блокировки 50-50
    Public activPAF As String 'Состояние блокировки Звонка другу
    Public activATA As String 'Состояние блокировки Помощи зала
    Dim timer4_coef As Decimal 'Коэффициент таймера анимации панели подсказок
    Dim commentShow As Boolean 'Показ комментария
    Public splashOn As Boolean = False 'Видна ли полноэкранная картинка
    Public maxCow As Integer = 15 'Максимальное кол-во колоннок в файле вопросов
    REM Переменные сетевого обеспечения
    Private WithEvents Server As New Server
    Private WithEvents Client As New Client
    Public hostPort As Integer
    Dim hostIP As String 'IP сервера
    Dim port As String 'Порт соединения

    Private Sub Project_Click(sender As Object, e As EventArgs) Handles Me.Click
        Me.Focus()
    End Sub

    Private Sub Project_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Audience.FffAnswer1Label.Visible = False
        Audience.FffResultName5Label.Visible = False
        Audience.FffResultTime5Label.Visible = False
        HostScreenXNumericUpDown.Value = FormStart.HostScreenXNumericUpDown.Value
        HostScreenYNumericUpDown.Value = FormStart.HostScreenYNumericUpDown.Value
        PlayerScreenXNumericUpDown.Value = FormStart.PlayerScreenXNumericUpDown.Value
        PlayerScreenYNumericUpDown.Value = FormStart.PlayerScreenYNumericUpDown.Value
        AudienceScreenXNumericUpDown.Value = FormStart.AudienceScreenXNumericUpDown.Value
        AudienceScreenYNumericUpDown.Value = FormStart.AudienceScreenYNumericUpDown.Value
        Me.MaximizeBox = False
        Host.Show()
        Player.Show()
        Audience.Show()
        If FormStart.HostScreenCheckBox.Checked = False Then
            Host.Hide()
            HostVisibleCheckBox.Checked = False
        End If
        If FormStart.PlayerScreenCheckBox.Checked = False Then
            Player.Hide()
            PlayerVisibleCheckBox.Checked = False
        End If
        If FormStart.AudienceScreenCheckBox.Checked = False Then
            Audience.Hide()
            AudienceVisibleCheckBox.Checked = False
        End If
        Host.Location = New Point(HostScreenXNumericUpDown.Value, HostScreenYNumericUpDown.Value)
        Player.Location = New Point(PlayerScreenXNumericUpDown.Value, PlayerScreenYNumericUpDown.Value)
        Audience.Location = New Point(AudienceScreenXNumericUpDown.Value, AudienceScreenYNumericUpDown.Value)
        FormStart.Close()
        Host.LogoPictureBox.Size = New System.Drawing.Size(1024, 768)
        Player.LogoPictureBox.Size = New System.Drawing.Size(1024, 768)
        Audience.LogoPictureBox.Size = New System.Drawing.Size(1024, 768)
        sourcePath = CurDir() & "\Source" 'Задание пути ресурсной папки
        langSource = CurDir() & currentBlock1(3, 3)
        ServerIpTextBox.Text = ini(12)
        ServerPortTextBox.Text = ini(13)
        'Подсвечивание кнопок-подсказок
        ToggleLogoButton.BackColor = Color.FromArgb(255, 128, 128)
        OpeningTitlesButton.BackColor = Color.FromArgb(255, 128, 128)
        ClearFormsButton.BackColor = Color.FromArgb(255, 128, 128)
        StartTheGameButton.BackColor = Color.Green
        'Перевод "B" Project
        Text = currentBlock1(21, 3) '0
        ConnectSettingsLabel.Text = currentBlock1(22, 3) '1
        QuestionsLabel.Text = currentBlock1(23, 3) '2
        OpenQuestionBaseButton.Text = currentBlock1(24, 3) '3
        AskQuestionButton.Text = currentBlock1(25, 3) '4
        EnableAnswersLabel.Text = currentBlock1(26, 3) '5
        EnableAnswerAButton.Text = currentBlock1(27, 3) '6
        EnableAnswerBButton.Text = currentBlock1(28, 3) '7
        EnableAnswerCButton.Text = currentBlock1(29, 3) '8
        EnableAnswerDButton.Text = currentBlock1(30, 3) '9
        EnableAllAnswersButton.Text = currentBlock1(31, 3) '10
        FullQuestionTextLabel.Text = currentBlock1(32, 3) '11
        ConnectButton.Text = currentBlock1(33, 3) '12
        AnswersLabel.Text = currentBlock1(34, 3) '13
        ReceiveAnswerAButton.Text = currentBlock1(35, 3) '14
        ReceiveAnswerBButton.Text = currentBlock1(36, 3) '15
        ReceiveAnswerCButton.Text = currentBlock1(37, 3) '16
        ReceiveAnswerDButton.Text = currentBlock1(38, 3) '17
        AnswerIndicatorLabel.Text = currentBlock1(39, 3) '18 |Right Answer|Wrong Answer|
        RevealCorrectAnswerButton.Text = currentBlock1(40, 3) '19
        LightsDownButton.Text = currentBlock1(41, 3) '20
        ToggleHintButton.Text = currentBlock1(42, 3) '21 |Hide Hint|
        HostMessageLabel.Text = currentBlock1(43, 3) '22
        SendHostMessageButton.Text = currentBlock1(44, 3) '23
        ToggleLogoButton.Text = currentBlock1(45, 3) '24 |Hide logo|
        LifelinesLabel.Text = currentBlock1(46, 3) '25
        FiftyFiftyButton.Text = currentBlock1(47, 3) '26
        PhoneAFriendButton.Text = currentBlock1(48, 3) '27
        AskTheAudienceButton.Text = currentBlock1(49, 3) '28
        FiftyFiftyAvailableCheckBox.Text = currentBlock1(50, 3) '29
        PhoneAFriendAvailableCheckBox.Text = currentBlock1(51, 3) '30
        AskTheAudienceAvailableCheckBox.Text = currentBlock1(52, 3) '31
        ToggleLifelinesPanelButton.Text = currentBlock1(53, 3) '32 |Hide panel|
        ClearHostMessageButton.Text = currentBlock1(54, 3) '33
        ClearFormsButton.Text = currentBlock1(55, 3) '34
        MoneyLabel.Text = currentBlock1(56, 3) '35
        TakeTheMoneyButton.Text = currentBlock1(57, 3) '36
        LittleQuitButton.Text = currentBlock1(58, 3) '37
        BigQuitButton.Text = currentBlock1(59, 3) '38
        MoneyTakenCheckBox.Text = currentBlock1(60, 3) '39
        MoneyTreeUpButton.Text = currentBlock1(61, 3) '40
        MoneyTreeDownButton.Text = currentBlock1(62, 3) '41
        MusicLabel.Text = currentBlock1(63, 3) '42
        OpeningTitlesButton.Text = currentBlock1(64, 3) '43
        HostEntranceButton.Text = currentBlock1(65, 3) '44
        LetsPlayButton.Text = currentBlock1(66, 3) '45
        LifelineExplanationsButton.Text = currentBlock1(67, 3) '46
        LightsToCentreButton.Text = currentBlock1(68, 3) '47
        FiftyFiftyMusicButton.Text = currentBlock1(69, 3) '48
        PhoneAFriendMusicButton.Text = currentBlock1(70, 3) '49
        AskTheAudienceMusicButton.Text = currentBlock1(71, 3) '50
        StartTheGameButton.Text = currentBlock1(72, 3) '51
        SeeYouLaterButton.Text = currentBlock1(73, 3) '52
        HelloAgainButton.Text = currentBlock1(74, 3) '53
        GoodbyePunterButton.Text = currentBlock1(75, 3) '54
        TimesUpButton.Text = currentBlock1(76, 3) '55
        TomorrowsNamesButton.Text = currentBlock1(77, 3) '56
        ClosingTitlesButton.Text = currentBlock1(78, 3) '57
        StereoTestButton.Text = currentBlock1(79, 3) '58
        SmsClockButton.Text = currentBlock1(80, 3) '59
        StopSoundButton.Text = currentBlock1(81, 3) '60
        StopMusicButton.Text = currentBlock1(82, 3) '61
        FastestFingerFirstButton.Text = currentBlock1(83, 3) '62
        LocationLabel.Text = currentBlock1(84, 3) '63
        HostLocationLabel.Text = currentBlock1(85, 3) '64
        PlayerLocationLabel.Text = currentBlock1(86, 3) '65
        AudienceLocationLabel.Text = currentBlock1(87, 3) '66
        FramesLabel.Text = currentBlock1(88, 3) '67
        HostFrameCheckBox.Text = currentBlock1(89, 3) '68
        PlayerFrameCheckBox.Text = currentBlock1(90, 3) '69
        AudienceFrameCheckBox.Text = currentBlock1(91, 3) '70
        AvailabilityLabel.Text = currentBlock1(92, 3) '71
        HostVisibleCheckBox.Text = currentBlock1(93, 3) '72
        PlayerVisibleCheckBox.Text = currentBlock1(94, 3) '73
        AudienceVisibleCheckBox.Text = currentBlock1(95, 3) '74
        ContestantLabel.Text = currentBlock1(96, 3) '75
        ContestantNameTextBox.Text = currentBlock1(97, 3) '76
        AboutButton.Text = currentBlock1(98, 3) '77
        Host.LogoPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LOGO_FEEL.png")
        Player.LogoPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LOGO_FEEL.png")
        Audience.LogoPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LOGO_FEEL.png")
        Host.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\BG4.jpg")
        Audience.QuestionFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile("source\QUESTION.png")
        QuestionFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile("source\QUESTION.png")
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_0.png"
        Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_0.png"
        Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_0.png"
        Audience.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_0.png"
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\000.png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\000.png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\000.png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\000.png"
        Host.AnswerAChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Host.AnswerBChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Host.AnswerCChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Host.AnswerDChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Player.AnswerAChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Player.AnswerBChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Player.AnswerCChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Player.AnswerDChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Audience.AnswerAChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Audience.AnswerBChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Audience.AnswerCChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        Audience.AnswerDChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        'Смена шрифта
        QuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        AnswerATextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AnswerBTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AnswerCTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AnswerDTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Host.QuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Host.AnswerATextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Host.AnswerBTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Host.AnswerCTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Host.AnswerDTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Player.QuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Player.AnswerATextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Player.AnswerBTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Player.AnswerCTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Player.AnswerDTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.FffQuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Audience.FffAnswer1Label.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.FffAnswer2Label.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.FffAnswer3Label.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.FffAnswer4Label.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.QuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Audience.AnswerATextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.AnswerBTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.AnswerCTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.AnswerDTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        'ATA
        Host.AnswerAPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        Host.AnswerBPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        Host.AnswerCPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        Host.AnswerDPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        Player.AnswerAPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Player.AnswerBPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Player.AnswerCPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Player.AnswerDPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Audience.AnswerAPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Audience.AnswerBPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Audience.AnswerCPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Audience.AnswerDPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        QuestionNumberNumericUpDown.Value = 1
        hostPort = Int(ServerPortTextBox.Text)
        Server.Start(1, hostPort)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ServerPortTextBox_TextChanged(sender As Object, e As EventArgs) Handles ServerPortTextBox.TextChanged
        'Изменение порта соединения
        Server.Stop()
        hostPort = Int(ServerPortTextBox.Text)
        Server.Start(1, hostPort)
    End Sub

    Private Sub AskQuestionButton_Click(sender As Object, e As EventArgs) Handles AskQuestionButton.Click
        'Ask choosed question ДЛЯ ВСЕХ
        ClearFormsButton.PerformClick()
        QuestionPreviewLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & currentBlock1(143, 3) & " " & rightAnswerText
        questionText = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
        QuestionTextLabel.Text = questionText
        numberRightAnswer = rightAnswerNumber
        ToggleHintButton.BackColor = Color.FromArgb(255, 192, 128)
        ToggleHintButton.Text = currentBlock1(42, 3) 'Show Hint
        Host.FinalAnswerLetterLabel.Text = ""
        Host.QuestionCommentLabel.Text = ""
        commentShow = False
        If HostMessageTextBox.Text.StartsWith("-A:") And HostMessageTextBox.Text.EndsWith("%") Then
            ClearHostMessageButton.PerformClick()
        End If
        Select Case questionNumber
            Case 0 To 5
                'Обращение к *.bat файлу для включения внешнего проигрывателя
                If winampOn <> 1 Or questionNumber = 0 Then
                    batFileName = Chr(34) & sourcePath & "\MUSIC\Q1-5 Bed Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & batFileName)
                    winampOn = 1
                End If
            Case 6
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q6 - Heartbeat Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
            Case 7
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q7 - Heartbeat Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
            Case 8
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q8 - Heartbeat Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
            Case 9
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q9 - Heartbeat Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
            Case 10
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q10 - Heartbeat Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
            Case 11
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q11 - Heartbeat Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
            Case 12
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q12 - Heartbeat Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
            Case 13
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q13 - Heartbeat Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
            Case 14
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q14 - Heartbeat Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
            Case 15
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q15 - Heartbeat (R1 000 000) Loop.wav" & Chr(34)
                Shell("source\BAT\run_back_music1.bat " & batFileName)
                winampOn = 1
        End Select
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button1|" & questionText & "|" & Str(numberRightAnswer) & "|" & questionNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        EnableAnswerAButton.BackColor = Color.Yellow
        EnableAnswerBButton.BackColor = Color.Yellow
        EnableAnswerCButton.BackColor = Color.Yellow
        EnableAnswerDButton.BackColor = Color.Yellow
        EnableAllAnswersButton.BackColor = Color.Yellow
        ReceiveAnswerAButton.BackColor = Color.White
        ReceiveAnswerBButton.BackColor = Color.White
        ReceiveAnswerCButton.BackColor = Color.White
        ReceiveAnswerDButton.BackColor = Color.White
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub StopSoundButton_Click(sender As Object, e As EventArgs) Handles StopSoundButton.Click
        'Stop Sound
        My.Computer.Audio.Stop()
    End Sub

    Private Sub LightsDownButton_Click(sender As Object, e As EventArgs) Handles LightsDownButton.Click
        'Lights down (LX), clear forms
        TakeTheMoneyButton.BackColor = Color.White
        MoneyWonRevealTimer.Stop()
        Player.MoneyWonPictureBox.Visible = False
        Audience.MoneyWonPictureBox.Visible = False
        QuestionTextLabel.Text = ""
        AnswerATextLabel.Text = ""
        AnswerBTextLabel.Text = ""
        AnswerCTextLabel.Text = ""
        AnswerDTextLabel.Text = ""
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        Player.QuestionTextLabel.Visible = True
        Player.AnswerATextLabel.Visible = True
        Player.AnswerBTextLabel.Visible = True
        Player.AnswerCTextLabel.Visible = True
        Player.AnswerDTextLabel.Visible = True
        Player.AnswerAFramePictureBox.Visible = True
        Player.AnswerBFramePictureBox.Visible = True
        Player.AnswerCFramePictureBox.Visible = True
        Player.AnswerDFramePictureBox.Visible = True
        Player.PrizePictureBox.Visible = False
        Player.WinnerNameLabel.Visible = False
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        Audience.QuestionTextLabel.Visible = True
        Audience.AnswerATextLabel.Visible = True
        Audience.AnswerBTextLabel.Visible = True
        Audience.AnswerCTextLabel.Visible = True
        Audience.AnswerDTextLabel.Visible = True
        Audience.QuestionFramePictureBox.Visible = True
        Audience.AnswerAFramePictureBox.Visible = True
        Audience.AnswerBFramePictureBox.Visible = True
        Audience.AnswerCFramePictureBox.Visible = True
        Audience.AnswerDFramePictureBox.Visible = True
        Audience.PrizePictureBox.Visible = False
        Audience.WinnerNameLabel.Visible = False
        AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerATextLabel.ForeColor = Color.White
        AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerBTextLabel.ForeColor = Color.White
        AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerCTextLabel.ForeColor = Color.White
        AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerDTextLabel.ForeColor = Color.White
        AnswerIndicatorLabel.BackColor = Color.DarkGray
        AnswerIndicatorLabel.Text = currentBlock1(39, 3) 'Answer Indicator
        Select Case questionNumber
            Case 0
                Shell("source\BAT\stop_back_music1.bat")
                winampOn = 0
                My.Computer.Audio.Play("\MUSIC\Let's See Q1.wav")
            Case 5, 10, 15
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q10 - Lx.wav" & Chr(34)
                Shell("source\BAT\run2_back_music1.bat " & batFileName)
                winampOn = 1
            Case 6, 11
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q6 - Lx.wav" & Chr(34)
                Shell("source\BAT\run2_back_music1.bat " & batFileName)
                winampOn = 1
            Case 7, 12
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q7-12 - Lx.wav" & Chr(34)
                Shell("source\BAT\run2_back_music1.bat " & batFileName)
                winampOn = 1
            Case 8, 13
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q8-13 - Lx.wav" & Chr(34)
                Shell("source\BAT\run2_back_music1.bat " & batFileName)
                winampOn = 1
            Case 9, 14
                batFileName = Chr(34) & sourcePath & "\MUSIC\Q9-14 - Lx.wav" & Chr(34)
                Shell("source\BAT\run2_back_music1.bat " & batFileName)
                winampOn = 1
        End Select
        If QuestionNumberNumericUpDown.Value < 15 And QuestionNumberNumericUpDown.Value > -1 Then
            QuestionNumberNumericUpDown.Value = QuestionNumberNumericUpDown.Value + 1
        End If
        MoneyTakenCheckBox.Checked = False
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button13|" & QuestionNumberNumericUpDown.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Подсвечивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.Yellow
        EnableAnswerAButton.BackColor = Color.White
        EnableAnswerBButton.BackColor = Color.White
        EnableAnswerCButton.BackColor = Color.White
        EnableAnswerDButton.BackColor = Color.White
        EnableAllAnswersButton.BackColor = Color.White
        ReceiveAnswerAButton.BackColor = Color.White
        ReceiveAnswerBButton.BackColor = Color.White
        ReceiveAnswerCButton.BackColor = Color.White
        ReceiveAnswerDButton.BackColor = Color.White
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
        StartTheGameButton.BackColor = Color.White
        GoodbyePunterButton.BackColor = Color.White
    End Sub

    Private Sub ReceiveAnswerAButton_Click(sender As Object, e As EventArgs) Handles ReceiveAnswerAButton.Click
        'A is a final answer
        Select Case numberRightAnswer
            Case 1
                Host.FinalAnswerLetterLabel.Text = "A"
            Case 2
                Host.FinalAnswerLetterLabel.Text = "B"
            Case 3
                Host.FinalAnswerLetterLabel.Text = "C"
            Case 4
                Host.FinalAnswerLetterLabel.Text = "D"
        End Select
        playerAnswerNumber = 1
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_ORANGE.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        AnswerATextLabel.BackColor = Color.FromArgb(244, 155, 15)
        AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerATextLabel.ForeColor = Color.Black
        AnswerBTextLabel.ForeColor = Color.White
        AnswerCTextLabel.ForeColor = Color.White
        AnswerDTextLabel.ForeColor = Color.White
        ToggleHintButton.BackColor = Color.FromArgb(128, 255, 255)
        ToggleHintButton.Text = currentBlock1(42, 4) 'Hide Hint
        Host.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            Shell("source\BAT\stop_back_music1.bat")
            winampOn = 0
        End If
        If MoneyTakenCheckBox.Checked = False Then
            Select Case questionNumber
                Case 6, 11
                    My.Computer.Audio.Play("source\MUSIC\Q6-11 -  Are you sure.wav", AudioPlayMode.Background)
                Case 7, 12
                    My.Computer.Audio.Play("source\MUSIC\Q7-12 - Are you sure.wav", AudioPlayMode.Background)
                Case 8, 13
                    My.Computer.Audio.Play("source\MUSIC\Q8-13 - Are you sure.wav", AudioPlayMode.Background)
                Case 9, 14
                    My.Computer.Audio.Play("source\MUSIC\Q9-14 - Are you sure.wav", AudioPlayMode.Background)
                Case 10, 15
                    My.Computer.Audio.Play("source\MUSIC\Q10-15 - Are you sure.wav", AudioPlayMode.Background)
            End Select
        End If
        If playerAnswerNumber = numberRightAnswer Then
            AnswerIndicatorLabel.BackColor = Color.FromArgb(0, 255, 0)
            AnswerIndicatorLabel.Text = currentBlock1(39, 4) 'Right Answer
        Else
            AnswerIndicatorLabel.BackColor = Color.FromArgb(255, 0, 0)
            AnswerIndicatorLabel.Text = currentBlock1(39, 5) 'Wrong Answer
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button8|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        EnableAnswerAButton.BackColor = Color.White
        EnableAnswerBButton.BackColor = Color.White
        EnableAnswerCButton.BackColor = Color.White
        EnableAnswerDButton.BackColor = Color.White
        EnableAllAnswersButton.BackColor = Color.White
        ReceiveAnswerAButton.BackColor = Color.White
        ReceiveAnswerBButton.BackColor = Color.White
        ReceiveAnswerCButton.BackColor = Color.White
        ReceiveAnswerDButton.BackColor = Color.White
        RevealCorrectAnswerButton.BackColor = Color.Yellow
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub ReceiveAnswerBButton_Click(sender As Object, e As EventArgs) Handles ReceiveAnswerBButton.Click
        'B is a final answer
        Select Case numberRightAnswer
            Case 1
                Host.FinalAnswerLetterLabel.Text = "A"
            Case 2
                Host.FinalAnswerLetterLabel.Text = "B"
            Case 3
                Host.FinalAnswerLetterLabel.Text = "C"
            Case 4
                Host.FinalAnswerLetterLabel.Text = "D"
        End Select
        playerAnswerNumber = 2
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_ORANGE.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerBTextLabel.BackColor = Color.FromArgb(244, 155, 15)
        AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerATextLabel.ForeColor = Color.White
        AnswerBTextLabel.ForeColor = Color.Black
        AnswerCTextLabel.ForeColor = Color.White
        AnswerDTextLabel.ForeColor = Color.White
        ToggleHintButton.BackColor = Color.FromArgb(128, 255, 255)
        ToggleHintButton.Text = currentBlock1(42, 4) 'Hide Hint
        Host.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            Shell("source\BAT\stop_back_music1.bat")
            winampOn = 0
        End If
        If MoneyTakenCheckBox.Checked = False Then
            Select Case questionNumber
                Case 6, 11
                    My.Computer.Audio.Play("source\MUSIC\Q6-11 -  Are you sure.wav", AudioPlayMode.Background)
                Case 7, 12
                    My.Computer.Audio.Play("source\MUSIC\Q7-12 - Are you sure.wav", AudioPlayMode.Background)
                Case 8, 13
                    My.Computer.Audio.Play("source\MUSIC\Q8-13 - Are you sure.wav", AudioPlayMode.Background)
                Case 9, 14
                    My.Computer.Audio.Play("source\MUSIC\Q9-14 - Are you sure.wav", AudioPlayMode.Background)
                Case 10, 15
                    My.Computer.Audio.Play("source\MUSIC\Q10-15 - Are you sure.wav", AudioPlayMode.Background)
            End Select
        End If
        If playerAnswerNumber = numberRightAnswer Then
            AnswerIndicatorLabel.BackColor = Color.FromArgb(0, 255, 0)
            AnswerIndicatorLabel.Text = currentBlock1(39, 4) 'Right Answer
        Else
            AnswerIndicatorLabel.BackColor = Color.FromArgb(255, 0, 0)
            AnswerIndicatorLabel.Text = currentBlock1(39, 5) 'Wrong Answer
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button9|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        EnableAnswerAButton.BackColor = Color.White
        EnableAnswerBButton.BackColor = Color.White
        EnableAnswerCButton.BackColor = Color.White
        EnableAnswerDButton.BackColor = Color.White
        EnableAllAnswersButton.BackColor = Color.White
        ReceiveAnswerAButton.BackColor = Color.White
        ReceiveAnswerBButton.BackColor = Color.White
        ReceiveAnswerCButton.BackColor = Color.White
        ReceiveAnswerDButton.BackColor = Color.White
        RevealCorrectAnswerButton.BackColor = Color.Yellow
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub ReceiveAnswerCButton_Click(sender As Object, e As EventArgs) Handles ReceiveAnswerCButton.Click
        'C is a final answer
        Select Case numberRightAnswer
            Case 1
                Host.FinalAnswerLetterLabel.Text = "A"
            Case 2
                Host.FinalAnswerLetterLabel.Text = "B"
            Case 3
                Host.FinalAnswerLetterLabel.Text = "C"
            Case 4
                Host.FinalAnswerLetterLabel.Text = "D"
        End Select
        playerAnswerNumber = 3
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_ORANGE.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerCTextLabel.BackColor = Color.FromArgb(244, 155, 15)
        AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerATextLabel.ForeColor = Color.White
        AnswerBTextLabel.ForeColor = Color.White
        AnswerCTextLabel.ForeColor = Color.Black
        AnswerDTextLabel.ForeColor = Color.White
        ToggleHintButton.BackColor = Color.FromArgb(128, 255, 255)
        ToggleHintButton.Text = currentBlock1(42, 4) 'Hide Hint
        Host.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            Shell("source\BAT\stop_back_music1.bat")
            winampOn = 0
        End If
        If MoneyTakenCheckBox.Checked = False Then
            Select Case questionNumber
                Case 6, 11
                    My.Computer.Audio.Play("source\MUSIC\Q6-11 -  Are you sure.wav", AudioPlayMode.Background)
                Case 7, 12
                    My.Computer.Audio.Play("source\MUSIC\Q7-12 - Are you sure.wav", AudioPlayMode.Background)
                Case 8, 13
                    My.Computer.Audio.Play("source\MUSIC\Q8-13 - Are you sure.wav", AudioPlayMode.Background)
                Case 9, 14
                    My.Computer.Audio.Play("source\MUSIC\Q9-14 - Are you sure.wav", AudioPlayMode.Background)
                Case 10, 15
                    My.Computer.Audio.Play("source\MUSIC\Q10-15 - Are you sure.wav", AudioPlayMode.Background)
            End Select
        End If
        If playerAnswerNumber = numberRightAnswer Then
            AnswerIndicatorLabel.BackColor = Color.FromArgb(0, 255, 0)
            AnswerIndicatorLabel.Text = currentBlock1(39, 4) 'Right Answer
        Else
            AnswerIndicatorLabel.BackColor = Color.FromArgb(255, 0, 0)
            AnswerIndicatorLabel.Text = currentBlock1(39, 5) 'Wrong Answer
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button10|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        EnableAnswerAButton.BackColor = Color.White
        EnableAnswerBButton.BackColor = Color.White
        EnableAnswerCButton.BackColor = Color.White
        EnableAnswerDButton.BackColor = Color.White
        EnableAllAnswersButton.BackColor = Color.White
        ReceiveAnswerAButton.BackColor = Color.White
        ReceiveAnswerBButton.BackColor = Color.White
        ReceiveAnswerCButton.BackColor = Color.White
        ReceiveAnswerDButton.BackColor = Color.White
        RevealCorrectAnswerButton.BackColor = Color.Yellow
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub ReceiveAnswerDButton_Click(sender As Object, e As EventArgs) Handles ReceiveAnswerDButton.Click
        'D is a final answer
        Select Case numberRightAnswer
            Case 1
                Host.FinalAnswerLetterLabel.Text = "A"
            Case 2
                Host.FinalAnswerLetterLabel.Text = "B"
            Case 3
                Host.FinalAnswerLetterLabel.Text = "C"
            Case 4
                Host.FinalAnswerLetterLabel.Text = "D"
        End Select
        playerAnswerNumber = 4
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_ORANGE.png")
        AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerDTextLabel.BackColor = Color.FromArgb(244, 155, 15)
        AnswerATextLabel.ForeColor = Color.White
        AnswerBTextLabel.ForeColor = Color.White
        AnswerCTextLabel.ForeColor = Color.White
        AnswerDTextLabel.ForeColor = Color.Black
        ToggleHintButton.BackColor = Color.FromArgb(128, 255, 255)
        ToggleHintButton.Text = currentBlock1(42, 4) 'Hide Hint
        Host.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            Shell("source\BAT\stop_back_music1.bat")
            winampOn = 0
        End If
        If MoneyTakenCheckBox.Checked = False Then
            Select Case questionNumber
                Case 6, 11
                    My.Computer.Audio.Play("source\MUSIC\Q6-11 -  Are you sure.wav", AudioPlayMode.Background)
                Case 7, 12
                    My.Computer.Audio.Play("source\MUSIC\Q7-12 - Are you sure.wav", AudioPlayMode.Background)
                Case 8, 13
                    My.Computer.Audio.Play("source\MUSIC\Q8-13 - Are you sure.wav", AudioPlayMode.Background)
                Case 9, 14
                    My.Computer.Audio.Play("source\MUSIC\Q9-14 - Are you sure.wav", AudioPlayMode.Background)
                Case 10, 15
                    My.Computer.Audio.Play("source\MUSIC\Q10-15 - Are you sure.wav", AudioPlayMode.Background)
            End Select
        End If
        If playerAnswerNumber = numberRightAnswer Then
            AnswerIndicatorLabel.BackColor = Color.FromArgb(0, 255, 0)
            AnswerIndicatorLabel.Text = currentBlock1(39, 4) 'Right Answer
        Else
            AnswerIndicatorLabel.BackColor = Color.FromArgb(255, 0, 0)
            AnswerIndicatorLabel.Text = currentBlock1(39, 5) 'Wrong Answer
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button11|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        EnableAnswerAButton.BackColor = Color.White
        EnableAnswerBButton.BackColor = Color.White
        EnableAnswerCButton.BackColor = Color.White
        EnableAnswerDButton.BackColor = Color.White
        EnableAllAnswersButton.BackColor = Color.White
        ReceiveAnswerAButton.BackColor = Color.White
        ReceiveAnswerBButton.BackColor = Color.White
        ReceiveAnswerCButton.BackColor = Color.White
        ReceiveAnswerDButton.BackColor = Color.White
        RevealCorrectAnswerButton.BackColor = Color.Yellow
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub RevealCorrectAnswerButton_Click(sender As Object, e As EventArgs) Handles RevealCorrectAnswerButton.Click
        'Check the correct answer
        Host.QuestionsLeftLabel.Text = "Qaway:" & Str(15 - questionNumber)
        RevealCorrectAnswerButton.BackColor = Color.Orange
        Select Case numberRightAnswer
            Case 1
                AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_GREEN.png")
                AnswerATextLabel.BackColor = Color.FromArgb(93, 179, 87)
                AnswerATextLabel.ForeColor = Color.Black
            Case 2
                AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_GREEN.png")
                AnswerBTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                AnswerBTextLabel.ForeColor = Color.Black
            Case 3
                AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_GREEN.png")
                AnswerCTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                AnswerCTextLabel.ForeColor = Color.Black
            Case 4
                AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_GREEN.png")
                AnswerDTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                AnswerDTextLabel.ForeColor = Color.Black
        End Select
        If MoneyTakenCheckBox.Checked = False Then
            If playerAnswerNumber = numberRightAnswer Then
                MoneyWonRevealTimer.Start()
                Select Case questionNumber
                    Case 0
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 0
                        Host.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                        Host.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                        Host.PossibleLossLabel.Text = "0" 'Возможная потеря
                        Host.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                    Case 1
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 1
                        Host.PossibleWinLabel.Text = "200"
                        Host.CurrentWinLabel.Text = "100"
                        Host.PossibleLossLabel.Text = "100"
                        Host.GuaranteedSumLabel.Text = "0"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    Case 2
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 2
                        Host.PossibleWinLabel.Text = "300"
                        Host.CurrentWinLabel.Text = "200"
                        Host.PossibleLossLabel.Text = "200"
                        Host.GuaranteedSumLabel.Text = "0"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    Case 3
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 3
                        Host.PossibleWinLabel.Text = "500"
                        Host.CurrentWinLabel.Text = "200"
                        Host.PossibleLossLabel.Text = "200"
                        Host.GuaranteedSumLabel.Text = "0"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    Case 4
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 4
                        Host.PossibleWinLabel.Text = "1,000"
                        Host.CurrentWinLabel.Text = "500"
                        Host.PossibleLossLabel.Text = "500"
                        Host.GuaranteedSumLabel.Text = "0"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    Case 5
                        My.Computer.Audio.Play("source\MUSIC\R1000 Winner.wav", AudioPlayMode.Background)
                        Shell("source\BAT\stop_back_music1.bat")
                        winampOn = 0
                        winNumber = 5
                        Host.PossibleWinLabel.Text = "2,000"
                        Host.CurrentWinLabel.Text = "1,000"
                        Host.PossibleLossLabel.Text = "0"
                        Host.GuaranteedSumLabel.Text = "1,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    Case 6
                        My.Computer.Audio.Play("source\MUSIC\Q6 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 6
                        Host.PossibleWinLabel.Text = "4,000"
                        Host.CurrentWinLabel.Text = "2,000"
                        Host.PossibleLossLabel.Text = "1,000"
                        Host.GuaranteedSumLabel.Text = "1,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    Case 7
                        My.Computer.Audio.Play("source\MUSIC\Q7 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 7
                        Host.PossibleWinLabel.Text = "8,000"
                        Host.CurrentWinLabel.Text = "4,000"
                        Host.PossibleLossLabel.Text = "3,000"
                        Host.GuaranteedSumLabel.Text = "1,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    Case 8
                        My.Computer.Audio.Play("source\MUSIC\Q8 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 8
                        Host.PossibleWinLabel.Text = "16,000"
                        Host.CurrentWinLabel.Text = "8,000"
                        Host.PossibleLossLabel.Text = "7,000"
                        Host.GuaranteedSumLabel.Text = "1,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    Case 9
                        My.Computer.Audio.Play("source\MUSIC\Q9 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 9
                        Host.PossibleWinLabel.Text = "32,000"
                        Host.CurrentWinLabel.Text = "16,000"
                        Host.PossibleLossLabel.Text = "15,000"
                        Host.GuaranteedSumLabel.Text = "1,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    Case 10
                        My.Computer.Audio.Play("source\MUSIC\R32000 - Winner.wav", AudioPlayMode.Background)
                        winNumber = 10
                        Host.PossibleWinLabel.Text = "64,000"
                        Host.CurrentWinLabel.Text = "32,000"
                        Host.PossibleLossLabel.Text = "0"
                        Host.GuaranteedSumLabel.Text = "32,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    Case 11
                        My.Computer.Audio.Play("source\MUSIC\Q11 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 11
                        Host.PossibleWinLabel.Text = "125,000"
                        Host.CurrentWinLabel.Text = "64,000"
                        Host.PossibleLossLabel.Text = "32,000"
                        Host.GuaranteedSumLabel.Text = "32,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    Case 12
                        My.Computer.Audio.Play("source\MUSIC\Q12 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 12
                        Host.PossibleWinLabel.Text = "250,000"
                        Host.CurrentWinLabel.Text = "125,000"
                        Host.PossibleLossLabel.Text = "93,000"
                        Host.GuaranteedSumLabel.Text = "32,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    Case 13
                        My.Computer.Audio.Play("source\MUSIC\Q13 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 13
                        Host.PossibleWinLabel.Text = "500,000"
                        Host.CurrentWinLabel.Text = "250,000"
                        Host.PossibleLossLabel.Text = "218,000"
                        Host.GuaranteedSumLabel.Text = "32,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    Case 14
                        My.Computer.Audio.Play("source\MUSIC\Q14 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 14
                        Host.PossibleWinLabel.Text = "1,000,000"
                        Host.CurrentWinLabel.Text = "500,000"
                        Host.PossibleLossLabel.Text = "468,000"
                        Host.GuaranteedSumLabel.Text = "32,000"
                        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    Case 15
                        Host.QuestionsLeftLabel.Text = "Qaway: 0"
                        My.Computer.Audio.Play("source\MUSIC\R1 000 000 - Winner.wav", AudioPlayMode.Background)
                        winNumber = 15
                        Host.PossibleWinLabel.Text = "1,000,000"
                        Host.CurrentWinLabel.Text = "1,000,000"
                        Host.PossibleLossLabel.Text = "0"
                        Host.GuaranteedSumLabel.Text = "1,000,000"
                        MoneyWonRevealTimer.Stop()
                        PrizeRevealTimer.Start()
                        Player.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\MILLIONAIRE.png")
                        Player.WinnerNameLabel.Text = ContestantNameTextBox.Text
                        Audience.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\MILLIONAIRE.png")
                        Audience.WinnerNameLabel.Text = ContestantNameTextBox.Text
                        MoneyTakenCheckBox.Checked = True
                        TakeTheMoneyButton.BackColor = Color.Blue
                        'Подсвечивание кнопок-подсказок
                        AskQuestionButton.BackColor = Color.White
                        EnableAnswerAButton.BackColor = Color.White
                        EnableAnswerBButton.BackColor = Color.White
                        EnableAnswerCButton.BackColor = Color.White
                        EnableAnswerDButton.BackColor = Color.White
                        EnableAllAnswersButton.BackColor = Color.White
                        ReceiveAnswerAButton.BackColor = Color.White
                        ReceiveAnswerBButton.BackColor = Color.White
                        ReceiveAnswerCButton.BackColor = Color.White
                        ReceiveAnswerDButton.BackColor = Color.White
                        RevealCorrectAnswerButton.BackColor = Color.White
                        LightsDownButton.BackColor = Color.White
                        GoodbyePunterButton.BackColor = Color.Yellow
                End Select
                If winNumber < 15 Then
                    AskQuestionButton.BackColor = Color.White
                    EnableAnswerAButton.BackColor = Color.White
                    EnableAnswerBButton.BackColor = Color.White
                    EnableAnswerCButton.BackColor = Color.White
                    EnableAnswerDButton.BackColor = Color.White
                    EnableAllAnswersButton.BackColor = Color.White
                    ReceiveAnswerAButton.BackColor = Color.White
                    ReceiveAnswerBButton.BackColor = Color.White
                    ReceiveAnswerCButton.BackColor = Color.White
                    ReceiveAnswerDButton.BackColor = Color.White
                    LightsDownButton.BackColor = Color.Yellow
                End If
            Else
                Select Case questionNumber
                    Case 0 To 5
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - No.wav", AudioPlayMode.Background)
                        Shell("source\BAT\stop_back_music1.bat")
                        winampOn = 0
                        winNumber = 0
                    Case 6
                        My.Computer.Audio.Play("source\MUSIC\Q6 - No.wav", AudioPlayMode.Background)
                        winNumber = 5
                    Case 7
                        My.Computer.Audio.Play("source\MUSIC\Q7 - No.wav", AudioPlayMode.Background)
                        winNumber = 5
                    Case 8
                        My.Computer.Audio.Play("source\MUSIC\Q8 - No.wav", AudioPlayMode.Background)
                        winNumber = 5
                    Case 9
                        My.Computer.Audio.Play("source\MUSIC\Q9 - No.wav", AudioPlayMode.Background)
                        winNumber = 5
                    Case 10
                        My.Computer.Audio.Play("source\MUSIC\R32000 - Loser.wav", AudioPlayMode.Background)
                        winNumber = 5
                    Case 11
                        My.Computer.Audio.Play("source\MUSIC\Q11 - No.wav", AudioPlayMode.Background)
                        winNumber = 10
                    Case 12
                        My.Computer.Audio.Play("source\MUSIC\Q12 - No.wav", AudioPlayMode.Background)
                        winNumber = 10
                    Case 13
                        My.Computer.Audio.Play("source\MUSIC\Q13 - No.wav", AudioPlayMode.Background)
                        winNumber = 10
                    Case 14
                        My.Computer.Audio.Play("source\MUSIC\Q14 - No.wav", AudioPlayMode.Background)
                        winNumber = 10
                    Case 15
                        My.Computer.Audio.Play("source\MUSIC\R1 000 000 - Loser.wav", AudioPlayMode.Background)
                        winNumber = 10
                End Select
                PrizeRevealTimer.Start()
                Player.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                Audience.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                MoneyTakenCheckBox.Checked = True
                'Подсвечивание кнопок-подсказок
                AskQuestionButton.BackColor = Color.White
                EnableAnswerAButton.BackColor = Color.White
                EnableAnswerBButton.BackColor = Color.White
                EnableAnswerCButton.BackColor = Color.White
                EnableAnswerDButton.BackColor = Color.White
                EnableAllAnswersButton.BackColor = Color.White
                ReceiveAnswerAButton.BackColor = Color.White
                ReceiveAnswerBButton.BackColor = Color.White
                ReceiveAnswerCButton.BackColor = Color.White
                ReceiveAnswerDButton.BackColor = Color.White
                RevealCorrectAnswerButton.BackColor = Color.White
                LightsDownButton.BackColor = Color.White
                GoodbyePunterButton.BackColor = Color.Yellow
            End If
        Else
            PrizeRevealTimer.Start()
            If winNumber < 15 Then
                Player.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                Audience.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
            End If
            'Подсвечивание кнопок-подсказок
            AskQuestionButton.BackColor = Color.White
            EnableAnswerAButton.BackColor = Color.White
            EnableAnswerBButton.BackColor = Color.White
            EnableAnswerCButton.BackColor = Color.White
            EnableAnswerDButton.BackColor = Color.White
            EnableAllAnswersButton.BackColor = Color.White
            ReceiveAnswerAButton.BackColor = Color.White
            ReceiveAnswerBButton.BackColor = Color.White
            ReceiveAnswerCButton.BackColor = Color.White
            ReceiveAnswerDButton.BackColor = Color.White
            RevealCorrectAnswerButton.BackColor = Color.White
            LightsDownButton.BackColor = Color.White
            GoodbyePunterButton.BackColor = Color.Yellow
        End If
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                If winNumber = 15 Then
                    .Command = "@millionaire|" & ContestantNameTextBox.Text & "|"
                Else
                    .Command = "@button12|" & MoneyTakenCheckBox.Checked & "|" & winNumber & "|"
                End If
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub MoneyWonRevealTimer_Tick(sender As Object, e As EventArgs) Handles MoneyWonRevealTimer.Tick
        'Таймер показа выигрыша
        Player.QuestionTextLabel.Visible = False
        Player.AnswerATextLabel.Visible = False
        Player.AnswerBTextLabel.Visible = False
        Player.AnswerCTextLabel.Visible = False
        Player.AnswerDTextLabel.Visible = False
        Player.AnswerAFramePictureBox.Visible = False
        Player.AnswerBFramePictureBox.Visible = False
        Player.AnswerCFramePictureBox.Visible = False
        Player.AnswerDFramePictureBox.Visible = False
        Player.MoneyWonPictureBox.Visible = True
        Audience.QuestionTextLabel.Visible = False
        Audience.AnswerATextLabel.Visible = False
        Audience.AnswerBTextLabel.Visible = False
        Audience.AnswerCTextLabel.Visible = False
        Audience.AnswerDTextLabel.Visible = False
        Audience.QuestionFramePictureBox.Visible = False
        Audience.AnswerAFramePictureBox.Visible = False
        Audience.AnswerBFramePictureBox.Visible = False
        Audience.AnswerCFramePictureBox.Visible = False
        Audience.AnswerDFramePictureBox.Visible = False
        Audience.MoneyWonPictureBox.Visible = True
        Player.BackgroundImage = Nothing
        RevealCorrectAnswerButton.BackColor = Color.White
        MoneyWonRevealTimer.Stop()
    End Sub

    Private Sub PrizeRevealTimer_Tick(sender As Object, e As EventArgs) Handles PrizeRevealTimer.Tick
        'Таймер панели TPM
        If winNumber = 15 Then
            Player.WinnerNameLabel.Visible = True
            Audience.WinnerNameLabel.Visible = True
        End If
        Player.QuestionTextLabel.Visible = False
        Player.AnswerATextLabel.Visible = False
        Player.AnswerBTextLabel.Visible = False
        Player.AnswerCTextLabel.Visible = False
        Player.AnswerDTextLabel.Visible = False
        Player.AnswerAFramePictureBox.Visible = False
        Player.AnswerBFramePictureBox.Visible = False
        Player.AnswerCFramePictureBox.Visible = False
        Player.AnswerDFramePictureBox.Visible = False
        Player.PrizePictureBox.Visible = True
        Audience.QuestionTextLabel.Visible = False
        Audience.AnswerATextLabel.Visible = False
        Audience.AnswerBTextLabel.Visible = False
        Audience.AnswerCTextLabel.Visible = False
        Audience.AnswerDTextLabel.Visible = False
        Audience.QuestionFramePictureBox.Visible = False
        Audience.AnswerAFramePictureBox.Visible = False
        Audience.AnswerBFramePictureBox.Visible = False
        Audience.AnswerCFramePictureBox.Visible = False
        Audience.AnswerDFramePictureBox.Visible = False
        Audience.PrizePictureBox.Visible = True
        Player.BackgroundImage = Nothing
        RevealCorrectAnswerButton.BackColor = Color.White
        TakeTheMoneyButton.BackColor = Color.Aqua
        PrizeRevealTimer.Stop()
    End Sub

    Private Sub OpeningTitlesButton_Click(sender As Object, e As EventArgs) Handles OpeningTitlesButton.Click
        'Opening Titles
        batFileName = Chr(34) & sourcePath & "\MUSIC\Millionaire Opening.wav" & Chr(34)
        Shell("source\BAT\run2_back_music1.bat " & batFileName)
        winampOn = 1
        If splashOn = False Then
            ToggleLogoButton.PerformClick()
        End If
        ClearFormsButton.PerformClick()
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button16|" & splashOn & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        HostEntranceButton.BackColor = Color.FromArgb(255, 128, 128)
        OpeningTitlesButton.BackColor = Color.White
    End Sub

    Private Sub HostEntranceButton_Click(sender As Object, e As EventArgs) Handles HostEntranceButton.Click
        'Host Entrance
        My.Computer.Audio.Play(sourcePath & "\MUSIC\Host Entrance #2.wav")
        Shell("source\BAT\stopfade_back_music1.bat")
        winampOn = 0
        HostEntranceButton.BackColor = Color.White
        LetsPlayButton.BackColor = Color.FromArgb(255, 128, 128)
        FastestFingerFirstButton.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub LetsPlayButton_Click(sender As Object, e As EventArgs) Handles LetsPlayButton.Click
        'Let's Play
        batFileName = Chr(34) & sourcePath & "\MUSIC\Lets Play.wav" & Chr(34)
        Shell("source\BAT\run2_back_music1.bat " & batFileName)
        winampOn = 1
        My.Computer.Audio.Stop()
        QuestionNumberNumericUpDown.Value = 1
        LetsPlayButton.BackColor = Color.White
        LightsToCentreButton.BackColor = Color.FromArgb(255, 128, 128)
        TomorrowsNamesButton.BackColor = Color.White
        FastestFingerFirstButton.BackColor = Color.White
    End Sub

    Private Sub LightsToCentreButton_Click(sender As Object, e As EventArgs) Handles LightsToCentreButton.Click
        'LX To Centre
        My.Computer.Audio.Play("source\MUSIC\LX To Centre.wav", AudioPlayMode.Background)
        Shell("source\BAT\stopfade_back_music1.bat " & batFileName)
        winampOn = 0
        LightsToCentreButton.BackColor = Color.White
        LifelineExplanationsButton.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub LifelineExplanationsButton_Click(sender As Object, e As EventArgs) Handles LifelineExplanationsButton.Click
        'Lifeline Explanations
        If winampOn <> 1 Then
            batFileName = Chr(34) & sourcePath & "\MUSIC\Lifeline Explanations.wav" & Chr(34)
            Shell("source\BAT\run_back_music1.bat " & batFileName)
            winampOn = 1
        End If
        LifelineExplanationsButton.BackColor = Color.White
        'Скрытие Splash Screen
        Host.LogoPictureBox.Visible = False
        Player.LogoPictureBox.Visible = False
        Audience.LogoPictureBox.Visible = False
        splashOn = False
        ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
        ToggleLogoButton.BackColor = Color.White
        ClearFormsButton.PerformClick()
        StartTheGameButton.BackColor = Color.Green
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button25|" & activ50 & "|" & activPAF & "|" & activATA & "|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub FiftyFiftyMusicButton_Click(sender As Object, e As EventArgs) Handles FiftyFiftyMusicButton.Click
        '50:50 Ping
        My.Computer.Audio.Play("source\MUSIC\50-50 Ping.wav", AudioPlayMode.Background)
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        LifelinesRefreshTimer.Start()
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button26|1|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub PhoneAFriendMusicButton_Click(sender As Object, e As EventArgs) Handles PhoneAFriendMusicButton.Click
        'PAF Ping
        My.Computer.Audio.Play("source\MUSIC\Phone a Friend Ping.wav", AudioPlayMode.Background)
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        LifelinesRefreshTimer.Start()
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button27|" & activ50 & "|1|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AskTheAudienceMusicButton_Click(sender As Object, e As EventArgs) Handles AskTheAudienceMusicButton.Click
        'ATA Ping
        My.Computer.Audio.Play("source\MUSIC\Audience Ping.wav", AudioPlayMode.Background)
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        LifelinesRefreshTimer.Start()
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button28|" & activ50 & "|" & activPAF & "|1|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub StartTheGameButton_Click(sender As Object, e As EventArgs) Handles StartTheGameButton.Click
        'Start the game
        Player.MoneyWonPictureBox.Visible = False
        Audience.MoneyWonPictureBox.Visible = False
        If winNumber < 15 Then QuestionNumberNumericUpDown.Value = winNumber + 1 Else QuestionNumberNumericUpDown.Value = 15
        Host.QuestionsLeftLabel.Text = "Qaway:" & Str(15 - winNumber)
        If winNumber < 15 Then
            Select Case questionNumber
                Case 0, 1
                    Host.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                    Host.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                    Host.PossibleLossLabel.Text = "0" 'Возможная потеря
                    Host.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                Case 2
                    Host.PossibleWinLabel.Text = "200"
                    Host.CurrentWinLabel.Text = "100"
                    Host.PossibleLossLabel.Text = "100"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                Case 3
                    Host.PossibleWinLabel.Text = "300"
                    Host.CurrentWinLabel.Text = "200"
                    Host.PossibleLossLabel.Text = "200"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                Case 4
                    Host.PossibleWinLabel.Text = "500"
                    Host.CurrentWinLabel.Text = "200"
                    Host.PossibleLossLabel.Text = "200"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                Case 5
                    Host.PossibleWinLabel.Text = "1,000"
                    Host.CurrentWinLabel.Text = "500"
                    Host.PossibleLossLabel.Text = "500"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                Case 6
                    Host.PossibleWinLabel.Text = "2,000"
                    Host.CurrentWinLabel.Text = "1,000"
                    Host.PossibleLossLabel.Text = "0"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                Case 7
                    Host.PossibleWinLabel.Text = "4,000"
                    Host.CurrentWinLabel.Text = "2,000"
                    Host.PossibleLossLabel.Text = "1,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                Case 8
                    Host.PossibleWinLabel.Text = "8,000"
                    Host.CurrentWinLabel.Text = "4,000"
                    Host.PossibleLossLabel.Text = "3,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                Case 9
                    Host.PossibleWinLabel.Text = "16,000"
                    Host.CurrentWinLabel.Text = "8,000"
                    Host.PossibleLossLabel.Text = "7,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                Case 10
                    Host.PossibleWinLabel.Text = "32,000"
                    Host.CurrentWinLabel.Text = "16,000"
                    Host.PossibleLossLabel.Text = "15,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                Case 11
                    Host.PossibleWinLabel.Text = "64,000"
                    Host.CurrentWinLabel.Text = "32,000"
                    Host.PossibleLossLabel.Text = "0"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                Case 12
                    Host.PossibleWinLabel.Text = "125,000"
                    Host.CurrentWinLabel.Text = "64,000"
                    Host.PossibleLossLabel.Text = "32,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                Case 13
                    Host.PossibleWinLabel.Text = "250,000"
                    Host.CurrentWinLabel.Text = "125,000"
                    Host.PossibleLossLabel.Text = "93,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                Case 14
                    Host.PossibleWinLabel.Text = "500,000"
                    Host.CurrentWinLabel.Text = "250,000"
                    Host.PossibleLossLabel.Text = "218,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                Case 15
                    Host.PossibleWinLabel.Text = "1,000,000"
                    Host.CurrentWinLabel.Text = "500,000"
                    Host.PossibleLossLabel.Text = "468,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
            End Select
        End If
        Host.FinalAnswerLetterLabel.Text = ""
        QuestionTextLabel.Text = ""
        AnswerATextLabel.Text = ""
        AnswerBTextLabel.Text = ""
        AnswerCTextLabel.Text = ""
        AnswerDTextLabel.Text = ""
        Player.QuestionTextLabel.Visible = True
        Player.AnswerATextLabel.Visible = True
        Player.AnswerBTextLabel.Visible = True
        Player.AnswerCTextLabel.Visible = True
        Player.AnswerDTextLabel.Visible = True
        Player.AnswerAFramePictureBox.Visible = True
        Player.AnswerBFramePictureBox.Visible = True
        Player.AnswerCFramePictureBox.Visible = True
        Player.AnswerDFramePictureBox.Visible = True
        Player.PrizePictureBox.Visible = False
        Player.WinnerNameLabel.Visible = False
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        Audience.QuestionTextLabel.Visible = True
        Audience.AnswerATextLabel.Visible = True
        Audience.AnswerBTextLabel.Visible = True
        Audience.AnswerCTextLabel.Visible = True
        Audience.AnswerDTextLabel.Visible = True
        Audience.QuestionFramePictureBox.Visible = True
        Audience.AnswerAFramePictureBox.Visible = True
        Audience.AnswerBFramePictureBox.Visible = True
        Audience.AnswerCFramePictureBox.Visible = True
        Audience.AnswerDFramePictureBox.Visible = True
        Audience.PrizePictureBox.Visible = False
        Audience.WinnerNameLabel.Visible = False
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerATextLabel.ForeColor = Color.White
        AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerBTextLabel.ForeColor = Color.White
        AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerCTextLabel.ForeColor = Color.White
        AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerDTextLabel.ForeColor = Color.White
        AnswerIndicatorLabel.BackColor = Color.DarkGray
        AnswerIndicatorLabel.Text = currentBlock1(39, 3) 'Answer Indicator
        Shell("source\BAT\stop_back_music1.bat")
        winampOn = 0
        My.Computer.Audio.Play("source\MUSIC\Let's See Q1.wav", AudioPlayMode.Background)
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        ToggleHintButton.Text = currentBlock1(42, 3) 'Show Hint
        Host.QuestionCommentLabel.Text = ""
        commentShow = False
        If HostMessageTextBox.Text.StartsWith("-A:") And HostMessageTextBox.Text.EndsWith("%") Then
            ClearHostMessageButton.PerformClick()
        End If
        MoneyTakenCheckBox.Checked = False
        If Host.HostMessageLabel.Text = "Message to host" Then ClearHostMessageButton.PerformClick()
        'Скрытие Splash Screen
        Host.LogoPictureBox.Visible = False
        Player.LogoPictureBox.Visible = False
        Audience.LogoPictureBox.Visible = False
        splashOn = False
        ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
        ToggleLogoButton.BackColor = Color.White
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button30|" & questionNumber & "|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.Yellow
        EnableAnswerAButton.BackColor = Color.White
        EnableAnswerBButton.BackColor = Color.White
        EnableAnswerCButton.BackColor = Color.White
        EnableAnswerDButton.BackColor = Color.White
        EnableAllAnswersButton.BackColor = Color.White
        ReceiveAnswerAButton.BackColor = Color.White
        ReceiveAnswerBButton.BackColor = Color.White
        ReceiveAnswerCButton.BackColor = Color.White
        ReceiveAnswerDButton.BackColor = Color.White
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
        ToggleHintButton.BackColor = Color.FromArgb(255, 192, 128)
        TakeTheMoneyButton.BackColor = Color.White
        HostEntranceButton.BackColor = Color.White
        LetsPlayButton.BackColor = Color.White
        ClearFormsButton.BackColor = Color.White
        LifelineExplanationsButton.BackColor = Color.White
        LightsToCentreButton.BackColor = Color.White
        StartTheGameButton.BackColor = Color.White
        GoodbyePunterButton.BackColor = Color.White
        TomorrowsNamesButton.BackColor = Color.White
        ClosingTitlesButton.BackColor = Color.White
        FastestFingerFirstButton.BackColor = Color.White
        OpeningTitlesButton.BackColor = Color.White
    End Sub

    Private Sub SeeYouLaterButton_Click(sender As Object, e As EventArgs) Handles SeeYouLaterButton.Click
        'See Yoy Later (P1)
        Shell("source\BAT\stop_back_music1.bat")
        winampOn = 0
        My.Computer.Audio.Play("source\MUSIC\See you later (End of Part 1).wav", AudioPlayMode.Background)
    End Sub

    Private Sub HelloAgainButton_Click(sender As Object, e As EventArgs) Handles HelloAgainButton.Click
        'Hello Again (P2)
        My.Computer.Audio.Play("source\MUSIC\Hello Again (Begin of part 2).wav", AudioPlayMode.Background)
    End Sub

    Private Sub GoodbyePunterButton_Click(sender As Object, e As EventArgs) Handles GoodbyePunterButton.Click
        'Goodbye Punter
        My.Computer.Audio.Play("source\MUSIC\Goodbye Punter.wav", AudioPlayMode.Background)
        ClearFormsButton.PerformClick()
        MoneyTreeLevel0Button.PerformClick()
        QuestionNumberNumericUpDown.Value = 1
        FiftyFiftyAvailableCheckBox.Checked = True
        PhoneAFriendAvailableCheckBox.Checked = True
        AskTheAudienceAvailableCheckBox.Checked = True
        MoneyTakenCheckBox.Checked = False
        If splashOn = False Then
            ToggleLogoButton.PerformClick()
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button33|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        EnableAnswerAButton.BackColor = Color.White
        EnableAnswerBButton.BackColor = Color.White
        EnableAnswerCButton.BackColor = Color.White
        EnableAnswerDButton.BackColor = Color.White
        EnableAllAnswersButton.BackColor = Color.White
        ReceiveAnswerAButton.BackColor = Color.White
        ReceiveAnswerBButton.BackColor = Color.White
        ReceiveAnswerCButton.BackColor = Color.White
        ReceiveAnswerDButton.BackColor = Color.White
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
        LetsPlayButton.BackColor = Color.FromArgb(255, 128, 128)
        StartTheGameButton.BackColor = Color.Green
        GoodbyePunterButton.BackColor = Color.White
        TomorrowsNamesButton.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub TimesUpButton_Click(sender As Object, e As EventArgs) Handles TimesUpButton.Click
        'Time's Up
        My.Computer.Audio.Play("source\MUSIC\Time's Up.wav", AudioPlayMode.Background)
        Shell("source\BAT\stop_back_music1.bat")
        winampOn = 0
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        EnableAnswerAButton.BackColor = Color.White
        EnableAnswerBButton.BackColor = Color.White
        EnableAnswerCButton.BackColor = Color.White
        EnableAnswerDButton.BackColor = Color.White
        EnableAllAnswersButton.BackColor = Color.White
        ReceiveAnswerAButton.BackColor = Color.White
        ReceiveAnswerBButton.BackColor = Color.White
        ReceiveAnswerCButton.BackColor = Color.White
        ReceiveAnswerDButton.BackColor = Color.White
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
        StartTheGameButton.BackColor = Color.White
        GoodbyePunterButton.BackColor = Color.White
        TomorrowsNamesButton.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub TomorrowsNamesButton_Click(sender As Object, e As EventArgs) Handles TomorrowsNamesButton.Click
        'Tomorrows Names
        My.Computer.Audio.Play("source\MUSIC\Tomorrows Names.wav", AudioPlayMode.Background)
        If splashOn = False Then ToggleLogoButton.PerformClick()
        'Перекрашивание кнопок-подсказок
        LetsPlayButton.BackColor = Color.White
        TomorrowsNamesButton.BackColor = Color.White
        ClosingTitlesButton.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub ClosingTitlesButton_Click(sender As Object, e As EventArgs) Handles ClosingTitlesButton.Click
        'Closing Titles
        My.Computer.Audio.Play("source\MUSIC\Millionaire Closing.wav", AudioPlayMode.Background)
        'Перекрашивание кнопок-подсказок
        ClosingTitlesButton.BackColor = Color.White
    End Sub

    Private Sub StereoTestButton_Click(sender As Object, e As EventArgs) Handles StereoTestButton.Click
        'Stereo Test
        My.Computer.Audio.Play("source\MUSIC\Stereo Test.wav", AudioPlayMode.Background)
    End Sub

    Private Sub SmsClockButton_Click(sender As Object, e As EventArgs) Handles SmsClockButton.Click
        'SMS Clock
        My.Computer.Audio.Play("source\MUSIC\sms_clock.wav", AudioPlayMode.Background)
    End Sub

    Private Sub OpenQuestionBaseButton_Click_1(sender As Object, e As EventArgs) Handles OpenQuestionBaseButton.Click
        'Open file button
        OpenQuestionBaseDialog.FileName = "*.questions"
        OpenQuestionBaseDialog.InitialDirectory = CurDir() & "\Bases"
        OpenQuestionBaseDialog.CheckFileExists = True
        If OpenQuestionBaseDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenQuestionBaseDialog.FileName
            Call openfilesdata(FileNameQ)
            QuestionListBox.SelectedIndex = QuestionNumberNumericUpDown.Value - 1
        End If
    End Sub

    Public Sub openfilesdata(sender As Object)
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        QuestionFilePathLabel.Text = FileNameQ
        If FileNameQ <> "*.questions" Then
            QuestionListBox.Enabled = True
            REM ****************************
            REM Считывание базы данных вопросов из выбранного файла
            i1 = 0
            i0 = 0
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(FileNameQ, System.Text.Encoding.Default)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters("|")
                ReDim currentRow(15)
                ReDim currentBlock0(100, 15)
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        If currentRow(2) <> "" Then
                            i0 = i0 + 1
                            i1 = 0
                            For Each currentField In currentRow
                                i1 = i1 + 1
                                currentBlock0(i0, i1) = ""
                                currentBlock0(i0, i1) = currentField
                                If currentBlock0(i0, i1) = "" And i1 > 0 Then
                                    maxCow = i1 - 1
                                End If
                            Next
                        End If
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    End Try
                End While
                ReDim currentBlock2(i0, maxCow)
                For i2 = 0 To i0
                    For i1 = 0 To maxCow
                        currentBlock2(i2, i1) = currentBlock0(i2, i1)
                        'Замена переноса строки и "|"
                        If currentBlock0(i2, i1) <> "" Then
                            currentBlock0(i2, i1) = currentBlock0(i2, i1).Replace("¶", " ")
                            currentBlock0(i2, i1) = currentBlock0(i2, i1).Replace("|", "")
                        End If
                        If currentBlock2(i2, i1) <> "" Then
                            currentBlock2(i2, i1) = currentBlock2(i2, i1).Replace("¶", Chr(13) & Chr(10))
                            currentBlock2(i2, i1) = currentBlock2(i2, i1).Replace("|", "")
                        End If
                    Next
                Next
            End Using
            REM /Считывание базы данных вопросов из выбранного файла
            REM /**********************

            REM ***********************
            REM Заполнение QuestionListBox
            QuestionListBox.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    QuestionListBox.Items.Add(currentBlock0(i1, 2) & ": " & currentBlock0(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            REM /Заполнение QuestionListBox
            REM /***********************
            OpenQuestionBaseButton.BackColor = Color.White
        Else
            QuestionListBox.Enabled = False
            QuestionListBox.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open"" button.")
            OpenQuestionBaseButton.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
            QuestionFilePathLabel.Text = "Question File Adress (Choose question base file with format ""*.question"")"
        End If
    End Sub

    Private Sub QuestionListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QuestionListBox.SelectedIndexChanged
        rightAnswerNumber = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 8)) 'Выбор номера правильного ответа из массива
        rightAnswerText = currentBlock2(QuestionListBox.SelectedIndex + 1, rightAnswerNumber + 3) 'Текст ответа из массива (номер ответа + 3)
        QuestionPreviewLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & currentBlock1(143, 3) & " " & rightAnswerText
    End Sub

    Private Sub QuestionListBox_DoubleClick(sender As Object, e As EventArgs) Handles QuestionListBox.DoubleClick
        Editor.Show()
    End Sub

    Private Sub QuestionNumberNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles QuestionNumberNumericUpDown.ValueChanged
        'Смена значения номера вопроса
        questionNumber = QuestionNumberNumericUpDown.Value
        QuestionListBox.SelectedIndex = questionNumber - 1
        If QuestionNumberNumericUpDown.Value <> 0 Then
            QuestionNumberNumericUpDown.Minimum = 1
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@numericupdown1|" & QuestionNumberNumericUpDown.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub EnableAnswerAButton_Click(sender As Object, e As EventArgs) Handles EnableAnswerAButton.Click
        'Show answer A on graphics
        textAnswerA = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        AnswerATextLabel.Text = textAnswerA
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button2|" & textAnswerA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        If AnswerATextLabel.Text <> Nothing Then EnableAnswerAButton.BackColor = Color.White Else EnableAnswerAButton.BackColor = Color.Yellow
        If AnswerBTextLabel.Text <> Nothing Then EnableAnswerBButton.BackColor = Color.White Else EnableAnswerBButton.BackColor = Color.Yellow
        If AnswerCTextLabel.Text <> Nothing Then EnableAnswerCButton.BackColor = Color.White Else EnableAnswerCButton.BackColor = Color.Yellow
        If AnswerDTextLabel.Text <> Nothing Then EnableAnswerDButton.BackColor = Color.White Else EnableAnswerDButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then EnableAllAnswersButton.BackColor = Color.White Else EnableAllAnswersButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerAButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerBButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerCButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerDButton.BackColor = Color.Yellow
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub EnableAnswerBButton_Click(sender As Object, e As EventArgs) Handles EnableAnswerBButton.Click
        'Show answer B on graphics
        textAnswerB = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        AnswerBTextLabel.Text = textAnswerB
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button3|" & textAnswerB & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        If AnswerATextLabel.Text <> Nothing Then EnableAnswerAButton.BackColor = Color.White Else EnableAnswerAButton.BackColor = Color.Yellow
        If AnswerBTextLabel.Text <> Nothing Then EnableAnswerBButton.BackColor = Color.White Else EnableAnswerBButton.BackColor = Color.Yellow
        If AnswerCTextLabel.Text <> Nothing Then EnableAnswerCButton.BackColor = Color.White Else EnableAnswerCButton.BackColor = Color.Yellow
        If AnswerDTextLabel.Text <> Nothing Then EnableAnswerDButton.BackColor = Color.White Else EnableAnswerDButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then EnableAllAnswersButton.BackColor = Color.White Else EnableAllAnswersButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerAButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerBButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerCButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerDButton.BackColor = Color.Yellow
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub EnableAnswerCButton_Click(sender As Object, e As EventArgs) Handles EnableAnswerCButton.Click
        'Show answer C on graphics
        textAnswerC = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        AnswerCTextLabel.Text = textAnswerC
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button4|" & textAnswerC & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        If AnswerATextLabel.Text <> Nothing Then EnableAnswerAButton.BackColor = Color.White Else EnableAnswerAButton.BackColor = Color.Yellow
        If AnswerBTextLabel.Text <> Nothing Then EnableAnswerBButton.BackColor = Color.White Else EnableAnswerBButton.BackColor = Color.Yellow
        If AnswerCTextLabel.Text <> Nothing Then EnableAnswerCButton.BackColor = Color.White Else EnableAnswerCButton.BackColor = Color.Yellow
        If AnswerDTextLabel.Text <> Nothing Then EnableAnswerDButton.BackColor = Color.White Else EnableAnswerDButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then EnableAllAnswersButton.BackColor = Color.White Else EnableAllAnswersButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerAButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerBButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerCButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerDButton.BackColor = Color.Yellow
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub EnableAnswerDButton_Click(sender As Object, e As EventArgs) Handles EnableAnswerDButton.Click
        'Show answer D on graphics
        textAnswerD = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        AnswerDTextLabel.Text = textAnswerD
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button5|" & textAnswerD & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        If AnswerATextLabel.Text <> Nothing Then EnableAnswerAButton.BackColor = Color.White Else EnableAnswerAButton.BackColor = Color.Yellow
        If AnswerBTextLabel.Text <> Nothing Then EnableAnswerBButton.BackColor = Color.White Else EnableAnswerBButton.BackColor = Color.Yellow
        If AnswerCTextLabel.Text <> Nothing Then EnableAnswerCButton.BackColor = Color.White Else EnableAnswerCButton.BackColor = Color.Yellow
        If AnswerDTextLabel.Text <> Nothing Then EnableAnswerDButton.BackColor = Color.White Else EnableAnswerDButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then EnableAllAnswersButton.BackColor = Color.White Else EnableAllAnswersButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerAButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerBButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerCButton.BackColor = Color.Yellow
        If AnswerATextLabel.Text <> Nothing And AnswerBTextLabel.Text <> Nothing And AnswerCTextLabel.Text <> Nothing And AnswerDTextLabel.Text <> Nothing Then ReceiveAnswerDButton.BackColor = Color.Yellow
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub EnableAllAnswersButton_Click(sender As Object, e As EventArgs) Handles EnableAllAnswersButton.Click
        'Show ALL answers on graphics
        questionText = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
        textAnswerA = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
        textAnswerB = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
        textAnswerC = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
        textAnswerD = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
        rightAnswerNumber = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 8))
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        QuestionTextLabel.Text = questionText
        AnswerATextLabel.Text = textAnswerA
        AnswerBTextLabel.Text = textAnswerB
        AnswerCTextLabel.Text = textAnswerC
        AnswerDTextLabel.Text = textAnswerD
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button6|" & questionText & "|" & textAnswerA & "|" & textAnswerB & "|" & textAnswerC & "|" & textAnswerD & "|" & numberRightAnswer & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        AskQuestionButton.BackColor = Color.White
        EnableAnswerAButton.BackColor = Color.White
        EnableAnswerBButton.BackColor = Color.White
        EnableAnswerCButton.BackColor = Color.White
        EnableAnswerDButton.BackColor = Color.White
        EnableAllAnswersButton.BackColor = Color.White
        ReceiveAnswerAButton.BackColor = Color.Yellow
        ReceiveAnswerBButton.BackColor = Color.Yellow
        ReceiveAnswerCButton.BackColor = Color.Yellow
        ReceiveAnswerDButton.BackColor = Color.Yellow
        RevealCorrectAnswerButton.BackColor = Color.White
        LightsDownButton.BackColor = Color.White
    End Sub

    Private Sub StopMusicButton_Click(sender As Object, e As EventArgs) Handles StopMusicButton.Click
        'Stop музыки в проигрывателе
        Shell("source\BAT\stop_back_music1.bat")
        winampOn = 0
    End Sub

    Private Sub ClearFormsButton_Click(sender As Object, e As EventArgs) Handles ClearFormsButton.Click
        'Clear forms
        TakeTheMoneyButton.BackColor = Color.White
        ClearFormsButton.BackColor = Color.White
        Player.MoneyWonPictureBox.Visible = False
        Audience.MoneyWonPictureBox.Visible = False
        Host.FinalAnswerLetterLabel.Text = ""
        QuestionTextLabel.Text = ""
        AnswerATextLabel.Text = ""
        AnswerBTextLabel.Text = ""
        AnswerCTextLabel.Text = ""
        AnswerDTextLabel.Text = ""
        Player.QuestionTextLabel.Visible = True
        Player.AnswerATextLabel.Visible = True
        Player.AnswerBTextLabel.Visible = True
        Player.AnswerCTextLabel.Visible = True
        Player.AnswerDTextLabel.Visible = True
        Player.AnswerAFramePictureBox.Visible = True
        Player.AnswerBFramePictureBox.Visible = True
        Player.AnswerCFramePictureBox.Visible = True
        Player.AnswerDFramePictureBox.Visible = True
        Player.PrizePictureBox.Visible = False
        Player.WinnerNameLabel.Visible = False
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        If FastestFingerFirstButton.BackColor <> Color.Orange Then
            Audience.QuestionTextLabel.Visible = True
            Audience.AnswerATextLabel.Visible = True
            Audience.AnswerBTextLabel.Visible = True
            Audience.AnswerCTextLabel.Visible = True
            Audience.AnswerDTextLabel.Visible = True
            Audience.QuestionFramePictureBox.Visible = True
            Audience.AnswerAFramePictureBox.Visible = True
            Audience.AnswerBFramePictureBox.Visible = True
            Audience.AnswerCFramePictureBox.Visible = True
            Audience.AnswerDFramePictureBox.Visible = True
        End If
        Audience.PrizePictureBox.Visible = False
        Audience.WinnerNameLabel.Visible = False
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerATextLabel.ForeColor = Color.White
        AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerBTextLabel.ForeColor = Color.White
        AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerCTextLabel.ForeColor = Color.White
        AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        AnswerDTextLabel.ForeColor = Color.White
        AnswerIndicatorLabel.BackColor = Color.DarkGray
        AnswerIndicatorLabel.Text = currentBlock1(39, 3) 'Answer Indicator
        ToggleHintButton.BackColor = Color.FromArgb(255, 192, 128)
        ToggleHintButton.Text = currentBlock1(42, 3) 'Show Hint
        Host.QuestionCommentLabel.Text = ""
        commentShow = False
        If HostMessageTextBox.Text.StartsWith("-A:") And HostMessageTextBox.Text.EndsWith("%") Then
            ClearHostMessageButton.PerformClick()
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button24|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub TakeTheMoneyButton_Click(sender As Object, e As EventArgs) Handles TakeTheMoneyButton.Click
        'Take a money
        If MoneyTakenCheckBox.Checked = False Then
            Shell("source\BAT\stopfade_back_music1.bat")
            winampOn = 0
            PrizeRevealTimer.Start()
            If winNumber < 15 Then
                Player.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                Audience.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
            End If
            TakeTheMoneyButton.BackColor = Color.Blue
            MoneyTakenCheckBox.Checked = True
            'Перекрашивание кнопок-подсказок
            AskQuestionButton.BackColor = Color.White
            EnableAnswerAButton.BackColor = Color.White
            EnableAnswerBButton.BackColor = Color.White
            EnableAnswerCButton.BackColor = Color.White
            EnableAnswerDButton.BackColor = Color.White
            EnableAllAnswersButton.BackColor = Color.White
            ReceiveAnswerAButton.BackColor = Color.White
            ReceiveAnswerBButton.BackColor = Color.White
            ReceiveAnswerCButton.BackColor = Color.White
            ReceiveAnswerDButton.BackColor = Color.White
            RevealCorrectAnswerButton.BackColor = Color.White
            LightsDownButton.BackColor = Color.White
            'Сеть
            If ConnectButton.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@button20_1|" & MoneyTakenCheckBox.Checked & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        Else
            Player.WinnerNameLabel.Visible = False
            Player.QuestionTextLabel.Visible = True
            Player.AnswerATextLabel.Visible = True
            Player.AnswerBTextLabel.Visible = True
            Player.AnswerCTextLabel.Visible = True
            Player.AnswerDTextLabel.Visible = True
            Player.AnswerAFramePictureBox.Visible = True
            Player.AnswerBFramePictureBox.Visible = True
            Player.AnswerCFramePictureBox.Visible = True
            Player.AnswerDFramePictureBox.Visible = True
            Player.PrizePictureBox.Visible = False
            Audience.WinnerNameLabel.Visible = False
            Audience.QuestionTextLabel.Visible = True
            Audience.AnswerATextLabel.Visible = True
            Audience.AnswerBTextLabel.Visible = True
            Audience.AnswerCTextLabel.Visible = True
            Audience.AnswerDTextLabel.Visible = True
            Audience.QuestionFramePictureBox.Visible = True
            Audience.AnswerAFramePictureBox.Visible = True
            Audience.AnswerBFramePictureBox.Visible = True
            Audience.AnswerCFramePictureBox.Visible = True
            Audience.AnswerDFramePictureBox.Visible = True
            Audience.PrizePictureBox.Visible = False
            Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
            RevealCorrectAnswerButton.BackColor = Color.White
            PrizeRevealTimer.Stop()
            TakeTheMoneyButton.BackColor = Color.White
            'Перекрашивание кнопок-подсказок
            AskQuestionButton.BackColor = Color.White
            EnableAnswerAButton.BackColor = Color.White
            EnableAnswerBButton.BackColor = Color.White
            EnableAnswerCButton.BackColor = Color.White
            EnableAnswerDButton.BackColor = Color.White
            EnableAllAnswersButton.BackColor = Color.White
            ReceiveAnswerAButton.BackColor = Color.Yellow
            ReceiveAnswerBButton.BackColor = Color.Yellow
            ReceiveAnswerCButton.BackColor = Color.Yellow
            ReceiveAnswerDButton.BackColor = Color.Yellow
            RevealCorrectAnswerButton.BackColor = Color.White
            LightsDownButton.BackColor = Color.White
            'Сеть
            If ConnectButton.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@button20_2|" & MoneyTakenCheckBox.Checked & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        End If
    End Sub

    Private Sub LittleQuitButton_Click(sender As Object, e As EventArgs) Handles LittleQuitButton.Click
        'Little Quitter
        My.Computer.Audio.Play("source\MUSIC\Little Quitter.wav", AudioPlayMode.Background)
    End Sub

    Private Sub BigQuitButton_Click(sender As Object, e As EventArgs) Handles BigQuitButton.Click
        'Big Quitter
        My.Computer.Audio.Play("source\MUSIC\Big Quitter.wav", AudioPlayMode.Background)
    End Sub

    Private Sub FiftyFiftyAvailableCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles FiftyFiftyAvailableCheckBox.CheckedChanged
        '50-50 state change
        If FiftyFiftyAvailableCheckBox.Checked = True Then
            activ50 = "0"
        Else
            activ50 = "x"
        End If
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@lifelines_state|" & activ50 & "|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub PhoneAFriendAvailableCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PhoneAFriendAvailableCheckBox.CheckedChanged
        'PAF state change
        If PhoneAFriendAvailableCheckBox.Checked = True Then
            activPAF = "0"
        Else
            activPAF = "x"
        End If
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@lifelines_state|" & activ50 & "|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AskTheAudienceAvailableCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AskTheAudienceAvailableCheckBox.CheckedChanged
        'ATA state change
        If AskTheAudienceAvailableCheckBox.Checked = True Then
            activATA = "0"
        Else
            activATA = "x"
        End If
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@lifelines_state|" & activ50 & "|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub LifelinesRefreshTimer_Tick(sender As Object, e As EventArgs) Handles LifelinesRefreshTimer.Tick
        'Таймер представления подсказок
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        LifelinesRefreshTimer.Stop()
    End Sub

    Private Sub FiftyFiftyButton_Click(sender As Object, e As EventArgs) Handles FiftyFiftyButton.Click
        '50-50 Lifeline
        Form50_50.Show()
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button17|1|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub PhoneAFriendButton_Click(sender As Object, e As EventArgs) Handles PhoneAFriendButton.Click
        'PAF Lifeline
        FormPAF.Show()
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button15|" & activ50 & "|1|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AskTheAudienceButton_Click(sender As Object, e As EventArgs) Handles AskTheAudienceButton.Click
        'ATA Lifeline
        FormATA.Show()
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button18|" & activ50 & "|" & activPAF & "|1|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ToggleLifelinesPanelButton_Click(sender As Object, e As EventArgs) Handles ToggleLifelinesPanelButton.Click
        'Show panel
        Select Case ToggleLifelinesPanelButton.BackColor
            Case Color.White
                'ToggleLifelinesPanelButton.BackColor = Color.Green
                timer4_coef = 41
                LifelinesPanelSlideTimer.Start()
                Audience.LifelinesPanelPictureBox.Left = 1024
                Audience.LifelinesPanelPictureBox.Visible = True
            Case Color.Green
                ToggleLifelinesPanelButton.BackColor = Color.White
                Audience.LifelinesPanelPictureBox.Left = 0
                LifelinesPanelHoldTimer.Stop()
                LifelinesPanelSlideTimer.Start()
        End Select
    End Sub

    'Private Sub LifelinesPanelSlideTimer_Tick(sender As Object, e As EventArgs) Handles LifelinesPanelSlideTimer.Tick
    '    'Анимация панели подсказок
    '    'llPanelTimer = llPanelTimer + 1
    '    If Audience.LifelinesPanelPictureBox.Left < 1025 Then
    '        If Audience.LifelinesPanelPictureBox.Left > 0 Then
    '            Audience.LifelinesPanelPictureBox.Left = Audience.LifelinesPanelPictureBox.Left - timer4_coef
    '            If Audience.LifelinesPanelPictureBox.Left = 0 Then
    '                LifelinesPanelSlideTimer.Stop()
    '                LifelinesPanelHoldTimer.Start()
    '                timer4_coef = timer4_coef * -1
    '            End If
    '            timer4_coef = Math.Ceiling(1 / Math.Sqrt(timer4_coef))
    '        Else
    '            LifelinesPanelSlideTimer.Stop()
    '            Audience.LifelinesPanelPictureBox.Location = New Point(0, 637)
    '        End If
    '    End If
    'End Sub

    'Private Sub LifelinesPanelHoldTimer_Tick(sender As Object, e As EventArgs) Handles LifelinesPanelHoldTimer.Tick
    '    'Время показа панели подсказок
    '    If ToggleLifelinesPanelButton.BackColor = Color.Green Then ToggleLifelinesPanelButton.PerformClick()
    'End Sub

    Public Sub HostFrameCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HostFrameCheckBox.CheckedChanged
        'Рамка окна ведущего
        If HostFrameCheckBox.Checked = True Then
            Host.FormBorderStyle = FormBorderStyle.Sizable
        Else
            Host.FormBorderStyle = FormBorderStyle.None
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@checkbox4|" & HostFrameCheckBox.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Public Sub PlayerFrameCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PlayerFrameCheckBox.CheckedChanged
        'Рамка окна игрока
        If PlayerFrameCheckBox.Checked = True Then
            Player.FormBorderStyle = FormBorderStyle.Sizable
        Else
            Player.FormBorderStyle = FormBorderStyle.None
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@checkbox5|" & PlayerFrameCheckBox.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Public Sub AudienceFrameCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AudienceFrameCheckBox.CheckedChanged
        'Рамка окна зрителей
        If AudienceFrameCheckBox.Checked = True Then
            Audience.FormBorderStyle = FormBorderStyle.Sizable
        Else
            Audience.FormBorderStyle = FormBorderStyle.None
        End If
    End Sub

    Public Sub HostVisibleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HostVisibleCheckBox.CheckedChanged
        'Видимость окна ведущего
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@checkbox7|" & HostVisibleCheckBox.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        Else
            If HostVisibleCheckBox.Checked = True Then
                Host.Show()
                Me.Focus()
            Else
                Host.Hide()
            End If
        End If
    End Sub

    Public Sub PlayerVisibleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PlayerVisibleCheckBox.CheckedChanged
        'Видимость окна игрока
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@checkbox8|" & PlayerVisibleCheckBox.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        Else
            If PlayerVisibleCheckBox.Checked = True Then
                Player.Show()
                Me.Focus()
            Else
                Player.Hide()
            End If
        End If
    End Sub

    Public Sub AudienceVisibleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AudienceVisibleCheckBox.CheckedChanged
        'Видимость окна зрителей
        If AudienceVisibleCheckBox.Checked = True Then
            Audience.Show()
            Me.Focus()
        Else
            Audience.Hide()
        End If
    End Sub

    Public Sub AnswerAFramePictureBox_BackgroundImageChanged(sender As Object, e As EventArgs) Handles AnswerAFramePictureBox.BackgroundImageChanged
        'Смена картинки режиссёра и всех остальных
        Host.AnswerAFramePictureBox.BackgroundImage = AnswerAFramePictureBox.BackgroundImage
        Player.AnswerAFramePictureBox.BackgroundImage = AnswerAFramePictureBox.BackgroundImage
        Audience.AnswerAFramePictureBox.BackgroundImage = AnswerAFramePictureBox.BackgroundImage
    End Sub

    Public Sub AnswerBFramePictureBox_BackgroundImageChanged(sender As Object, e As EventArgs) Handles AnswerBFramePictureBox.BackgroundImageChanged
        Host.AnswerBFramePictureBox.BackgroundImage = AnswerBFramePictureBox.BackgroundImage
        Player.AnswerBFramePictureBox.BackgroundImage = AnswerBFramePictureBox.BackgroundImage
        Audience.AnswerBFramePictureBox.BackgroundImage = AnswerBFramePictureBox.BackgroundImage
    End Sub

    Public Sub AnswerCFramePictureBox_BackgroundImageChanged(sender As Object, e As EventArgs) Handles AnswerCFramePictureBox.BackgroundImageChanged
        Host.AnswerCFramePictureBox.BackgroundImage = AnswerCFramePictureBox.BackgroundImage
        Player.AnswerCFramePictureBox.BackgroundImage = AnswerCFramePictureBox.BackgroundImage
        Audience.AnswerCFramePictureBox.BackgroundImage = AnswerCFramePictureBox.BackgroundImage
    End Sub

    Public Sub AnswerDFramePictureBox_BackgroundImageChanged(sender As Object, e As EventArgs) Handles AnswerDFramePictureBox.BackgroundImageChanged
        Host.AnswerDFramePictureBox.BackgroundImage = AnswerDFramePictureBox.BackgroundImage
        Player.AnswerDFramePictureBox.BackgroundImage = AnswerDFramePictureBox.BackgroundImage
        Audience.AnswerDFramePictureBox.BackgroundImage = AnswerDFramePictureBox.BackgroundImage
    End Sub

    Private Sub QuestionTextLabel_TextChanged(sender As Object, e As EventArgs) Handles QuestionTextLabel.TextChanged, AnswerATextLabel.TextChanged, AnswerBTextLabel.TextChanged, AnswerCTextLabel.TextChanged, AnswerDTextLabel.TextChanged
        'Смена текста вопроса и вариантов у режиссёра и всех остальных
        Host.QuestionTextLabel.Text = QuestionTextLabel.Text
        Player.QuestionTextLabel.Text = QuestionTextLabel.Text
        Audience.QuestionTextLabel.Text = QuestionTextLabel.Text
        Host.AnswerATextLabel.Text = AnswerATextLabel.Text
        Player.AnswerATextLabel.Text = AnswerATextLabel.Text
        Audience.AnswerATextLabel.Text = AnswerATextLabel.Text
        Host.AnswerBTextLabel.Text = AnswerBTextLabel.Text
        Player.AnswerBTextLabel.Text = AnswerBTextLabel.Text
        Audience.AnswerBTextLabel.Text = AnswerBTextLabel.Text
        Host.AnswerCTextLabel.Text = AnswerCTextLabel.Text
        Player.AnswerCTextLabel.Text = AnswerCTextLabel.Text
        Audience.AnswerCTextLabel.Text = AnswerCTextLabel.Text
        Host.AnswerDTextLabel.Text = AnswerDTextLabel.Text
        Player.AnswerDTextLabel.Text = AnswerDTextLabel.Text
        Audience.AnswerDTextLabel.Text = AnswerDTextLabel.Text
    End Sub

    Private Sub AnswerATextLabel_BackColorChanged(sender As Object, e As EventArgs) Handles AnswerATextLabel.BackColorChanged, AnswerBTextLabel.BackColorChanged, AnswerCTextLabel.BackColorChanged, AnswerDTextLabel.BackColorChanged
        'Смена фона текста вариантов ответа у всех
        Host.AnswerATextLabel.BackColor = AnswerATextLabel.BackColor
        Player.AnswerATextLabel.BackColor = AnswerATextLabel.BackColor
        Audience.AnswerATextLabel.BackColor = AnswerATextLabel.BackColor
        Host.AnswerBTextLabel.BackColor = AnswerBTextLabel.BackColor
        Player.AnswerBTextLabel.BackColor = AnswerBTextLabel.BackColor
        Audience.AnswerBTextLabel.BackColor = AnswerBTextLabel.BackColor
        Host.AnswerCTextLabel.BackColor = AnswerCTextLabel.BackColor
        Player.AnswerCTextLabel.BackColor = AnswerCTextLabel.BackColor
        Audience.AnswerCTextLabel.BackColor = AnswerCTextLabel.BackColor
        Host.AnswerDTextLabel.BackColor = AnswerDTextLabel.BackColor
        Player.AnswerDTextLabel.BackColor = AnswerDTextLabel.BackColor
        Audience.AnswerDTextLabel.BackColor = AnswerDTextLabel.BackColor
    End Sub

    Private Sub AnswerATextLabel_ForeColorChanged(sender As Object, e As EventArgs) Handles QuestionTextLabel.ForeColorChanged, AnswerATextLabel.ForeColorChanged, AnswerBTextLabel.ForeColorChanged, AnswerCTextLabel.ForeColorChanged, AnswerDTextLabel.ForeColorChanged
        'Смена цвета текста вариантов ответа у всех
        Host.QuestionTextLabel.ForeColor = QuestionTextLabel.ForeColor
        Player.QuestionTextLabel.ForeColor = QuestionTextLabel.ForeColor
        Audience.QuestionTextLabel.ForeColor = QuestionTextLabel.ForeColor
        Host.AnswerATextLabel.ForeColor = AnswerATextLabel.ForeColor
        Player.AnswerATextLabel.ForeColor = AnswerATextLabel.ForeColor
        Audience.AnswerATextLabel.ForeColor = AnswerATextLabel.ForeColor
        Host.AnswerBTextLabel.ForeColor = AnswerBTextLabel.ForeColor
        Player.AnswerBTextLabel.ForeColor = AnswerBTextLabel.ForeColor
        Audience.AnswerBTextLabel.ForeColor = AnswerBTextLabel.ForeColor
        Host.AnswerCTextLabel.ForeColor = AnswerCTextLabel.ForeColor
        Player.AnswerCTextLabel.ForeColor = AnswerCTextLabel.ForeColor
        Audience.AnswerCTextLabel.ForeColor = AnswerCTextLabel.ForeColor
        Host.AnswerDTextLabel.ForeColor = AnswerDTextLabel.ForeColor
        Player.AnswerDTextLabel.ForeColor = AnswerDTextLabel.ForeColor
        Audience.AnswerDTextLabel.ForeColor = AnswerDTextLabel.ForeColor
    End Sub

    Private Sub SendHostMessageButton_Click(sender As Object, e As EventArgs) Handles SendHostMessageButton.Click
        'Отправить сообщение ведущему
        Host.HostMessageLabel.Text = HostMessageTextBox.Text
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button44|" & HostMessageTextBox.Text & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ClearHostMessageButton_Click(sender As Object, e As EventArgs) Handles ClearHostMessageButton.Click
        'Очистить поле сообщения
        HostMessageTextBox.Text = ""
        Host.HostMessageLabel.Text = ""
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button45|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ToggleHintButton_Click(sender As Object, e As EventArgs) Handles ToggleHintButton.Click
        'Показ комментария к вопросу
        If commentShow = False Then
            ToggleHintButton.BackColor = Color.FromArgb(128, 255, 255)
            ToggleHintButton.Text = currentBlock1(42, 4) 'Hide Hint
            Host.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
            commentShow = True
        Else
            ToggleHintButton.BackColor = Color.FromArgb(255, 192, 128)
            ToggleHintButton.Text = currentBlock1(42, 3) 'Show Hint
            Host.QuestionCommentLabel.Text = ""
            commentShow = False
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button14|" & commentShow & "|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ToggleLogoButton_Click(sender As Object, e As EventArgs) Handles ToggleLogoButton.Click
        'Показать полноэкранную картинку
        If splashOn = False Then
            Host.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
            Host.LogoPictureBox.Visible = True
            Player.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
            Player.LogoPictureBox.Visible = True
            Audience.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
            Audience.LogoPictureBox.Visible = True
            splashOn = True
            ToggleLogoButton.Text = currentBlock1(45, 4) 'Hide logo
            ToggleLogoButton.BackColor = Color.Violet
        Else
            Host.LogoPictureBox.Visible = False
            Player.LogoPictureBox.Visible = False
            Audience.LogoPictureBox.Visible = False
            splashOn = False
            ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
            ToggleLogoButton.BackColor = Color.White
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button16|" & splashOn & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        'Кнопка About
        AboutUs.Show()
    End Sub

    Private Sub HostScreenXNumericUpDown_LostFocus(sender As Object, e As EventArgs) Handles HostScreenXNumericUpDown.LostFocus, HostScreenYNumericUpDown.LostFocus
        Host.Location = New Point(HostScreenXNumericUpDown.Value, HostScreenYNumericUpDown.Value)
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@numericupdown2|" & HostScreenXNumericUpDown.Value & "|" & HostScreenYNumericUpDown.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub PlayerScreenXNumericUpDown_LostFocus(sender As Object, e As EventArgs) Handles PlayerScreenXNumericUpDown.LostFocus, PlayerScreenYNumericUpDown.LostFocus
        Player.Location = New Point(PlayerScreenXNumericUpDown.Value, PlayerScreenYNumericUpDown.Value)
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@numericupdown4|" & PlayerScreenXNumericUpDown.Value & "|" & PlayerScreenYNumericUpDown.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AudienceScreenXNumericUpDown_LostFocus(sender As Object, e As EventArgs) Handles AudienceScreenXNumericUpDown.LostFocus, AudienceScreenYNumericUpDown.LostFocus
        Audience.Location = New Point(AudienceScreenXNumericUpDown.Value, AudienceScreenYNumericUpDown.Value)
    End Sub

    Private Sub MoneyTreeUpButton_Click(sender As Object, e As EventArgs) Handles MoneyTreeUpButton.Click
        'Tree Up
        If winNumber < 15 Then
            winNumber = winNumber + 1
            Select Case questionNumber
                Case 1
                    Host.PossibleWinLabel.Text = "200"
                    Host.CurrentWinLabel.Text = "100"
                    Host.PossibleLossLabel.Text = "100"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                Case 2
                    Host.PossibleWinLabel.Text = "300"
                    Host.CurrentWinLabel.Text = "200"
                    Host.PossibleLossLabel.Text = "200"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                Case 3
                    Host.PossibleWinLabel.Text = "500"
                    Host.CurrentWinLabel.Text = "200"
                    Host.PossibleLossLabel.Text = "200"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                Case 4
                    Host.PossibleWinLabel.Text = "1,000"
                    Host.CurrentWinLabel.Text = "500"
                    Host.PossibleLossLabel.Text = "500"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                Case 5
                    Host.PossibleWinLabel.Text = "2,000"
                    Host.CurrentWinLabel.Text = "1,000"
                    Host.PossibleLossLabel.Text = "0"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                Case 6
                    Host.PossibleWinLabel.Text = "4,000"
                    Host.CurrentWinLabel.Text = "2,000"
                    Host.PossibleLossLabel.Text = "1,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                Case 7
                    Host.PossibleWinLabel.Text = "8,000"
                    Host.CurrentWinLabel.Text = "4,000"
                    Host.PossibleLossLabel.Text = "3,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                Case 8
                    Host.PossibleWinLabel.Text = "16,000"
                    Host.CurrentWinLabel.Text = "8,000"
                    Host.PossibleLossLabel.Text = "7,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                Case 9
                    Host.PossibleWinLabel.Text = "32,000"
                    Host.CurrentWinLabel.Text = "16,000"
                    Host.PossibleLossLabel.Text = "15,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                Case 10
                    Host.PossibleWinLabel.Text = "64,000"
                    Host.CurrentWinLabel.Text = "32,000"
                    Host.PossibleLossLabel.Text = "0"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                Case 11
                    Host.PossibleWinLabel.Text = "125,000"
                    Host.CurrentWinLabel.Text = "64,000"
                    Host.PossibleLossLabel.Text = "32,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                Case 12
                    Host.PossibleWinLabel.Text = "250,000"
                    Host.CurrentWinLabel.Text = "125,000"
                    Host.PossibleLossLabel.Text = "93,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                Case 13
                    Host.PossibleWinLabel.Text = "500,000"
                    Host.CurrentWinLabel.Text = "250,000"
                    Host.PossibleLossLabel.Text = "218,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                Case 14
                    Host.PossibleWinLabel.Text = "1,000,000"
                    Host.CurrentWinLabel.Text = "500,000"
                    Host.PossibleLossLabel.Text = "468,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                Case 15
                    Host.PossibleWinLabel.Text = "1,000,000"
                    Host.CurrentWinLabel.Text = "1,000,000"
                    Host.PossibleLossLabel.Text = "0"
                    Host.GuaranteedSumLabel.Text = "1,000,000"
            End Select
            MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Audience.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            'Сеть
            If ConnectButton.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@button42|" & winNumber & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        End If
    End Sub

    Private Sub MoneyTreeDownButton_Click(sender As Object, e As EventArgs) Handles MoneyTreeDownButton.Click
        'Tree Down
        If winNumber > 0 Then
            winNumber = winNumber - 1
            Select Case questionNumber
                Case 0
                    Host.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                    Host.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                    Host.PossibleLossLabel.Text = "0" 'Возможная потеря
                    Host.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                Case 1
                    Host.PossibleWinLabel.Text = "200"
                    Host.CurrentWinLabel.Text = "100"
                    Host.PossibleLossLabel.Text = "100"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                Case 2
                    Host.PossibleWinLabel.Text = "300"
                    Host.CurrentWinLabel.Text = "200"
                    Host.PossibleLossLabel.Text = "200"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                Case 3
                    Host.PossibleWinLabel.Text = "500"
                    Host.CurrentWinLabel.Text = "200"
                    Host.PossibleLossLabel.Text = "200"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                Case 4
                    Host.PossibleWinLabel.Text = "1,000"
                    Host.CurrentWinLabel.Text = "500"
                    Host.PossibleLossLabel.Text = "500"
                    Host.GuaranteedSumLabel.Text = "0"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                Case 5
                    Host.PossibleWinLabel.Text = "2,000"
                    Host.CurrentWinLabel.Text = "1,000"
                    Host.PossibleLossLabel.Text = "0"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                Case 6
                    Host.PossibleWinLabel.Text = "4,000"
                    Host.CurrentWinLabel.Text = "2,000"
                    Host.PossibleLossLabel.Text = "1,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                Case 7
                    Host.PossibleWinLabel.Text = "8,000"
                    Host.CurrentWinLabel.Text = "4,000"
                    Host.PossibleLossLabel.Text = "3,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                Case 8
                    Host.PossibleWinLabel.Text = "16,000"
                    Host.CurrentWinLabel.Text = "8,000"
                    Host.PossibleLossLabel.Text = "7,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                Case 9
                    Host.PossibleWinLabel.Text = "32,000"
                    Host.CurrentWinLabel.Text = "16,000"
                    Host.PossibleLossLabel.Text = "15,000"
                    Host.GuaranteedSumLabel.Text = "1,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                Case 10
                    Host.PossibleWinLabel.Text = "64,000"
                    Host.CurrentWinLabel.Text = "32,000"
                    Host.PossibleLossLabel.Text = "0"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                Case 11
                    Host.PossibleWinLabel.Text = "125,000"
                    Host.CurrentWinLabel.Text = "64,000"
                    Host.PossibleLossLabel.Text = "32,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                Case 12
                    Host.PossibleWinLabel.Text = "250,000"
                    Host.CurrentWinLabel.Text = "125,000"
                    Host.PossibleLossLabel.Text = "93,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                Case 13
                    Host.PossibleWinLabel.Text = "500,000"
                    Host.CurrentWinLabel.Text = "250,000"
                    Host.PossibleLossLabel.Text = "218,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                Case 14
                    Host.PossibleWinLabel.Text = "1,000,000"
                    Host.CurrentWinLabel.Text = "500,000"
                    Host.PossibleLossLabel.Text = "468,000"
                    Host.GuaranteedSumLabel.Text = "32,000"
                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
            End Select
            MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Audience.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            'Сеть
            If ConnectButton.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@button43|" & winNumber & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        End If
    End Sub

    Private Sub MoneyTreeLevel0Button_Click(sender As Object, e As EventArgs) Handles MoneyTreeLevel0Button.Click
        'Tree 0
        winNumber = 0
        Host.PossibleWinLabel.Text = "100"
        Host.CurrentWinLabel.Text = "0"
        Host.PossibleLossLabel.Text = "0"
        Host.GuaranteedSumLabel.Text = "0"
        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button52|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub MoneyTreeLevel5Button_Click(sender As Object, e As EventArgs) Handles MoneyTreeLevel5Button.Click
        'Tree 5
        winNumber = 5
        Host.PossibleWinLabel.Text = "2,000"
        Host.CurrentWinLabel.Text = "1,000"
        Host.PossibleLossLabel.Text = "0"
        Host.GuaranteedSumLabel.Text = "1,000"
        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button51|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub MoneyTreeLevel10Button_Click(sender As Object, e As EventArgs) Handles MoneyTreeLevel10Button.Click
        'Tree 10
        winNumber = 10
        Host.PossibleWinLabel.Text = "64,000"
        Host.CurrentWinLabel.Text = "32,000"
        Host.PossibleLossLabel.Text = "0"
        Host.GuaranteedSumLabel.Text = "32,000"
        Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
        Audience.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button50|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub MoneyTreeLevel15Button_Click(sender As Object, e As EventArgs) Handles MoneyTreeLevel15Button.Click
        'Tree 15
        winNumber = 15
        Host.PossibleWinLabel.Text = "1,000,000"
        Host.CurrentWinLabel.Text = "1,000,000"
        Host.PossibleLossLabel.Text = "0"
        Host.GuaranteedSumLabel.Text = "1,000,000"
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button49|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ContestantNameTextBox_Click(sender As Object, e As EventArgs) Handles ContestantNameTextBox.Click
        'Нажатие на поле ввода имени игрока
        ContestantNameTextBox.SelectAll()
    End Sub

    Private Sub FastestFingerFirstButton_Click(sender As Object, e As EventArgs) Handles FastestFingerFirstButton.Click
        'Fastest Finger First
        FormFFF.Show()
        LetsPlayButton.BackColor = Color.White
        TomorrowsNamesButton.BackColor = Color.White
        FastestFingerFirstButton.BackColor = Color.Orange
    End Sub

    Private Sub Project_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Закрытие программы
        If Client.IsConnection Then Client.Disconnect()
        If HostVisibleCheckBox.Checked = True Then ini(1) = "1" Else ini(1) = "0"
        If PlayerVisibleCheckBox.Checked = True Then ini(2) = "1" Else ini(2) = "0"
        If AudienceVisibleCheckBox.Checked = True Then ini(3) = "1" Else ini(3) = "0"
        ini(4) = HostScreenXNumericUpDown.Value
        ini(5) = HostScreenYNumericUpDown.Value
        ini(6) = PlayerScreenXNumericUpDown.Value
        ini(7) = PlayerScreenYNumericUpDown.Value
        ini(8) = AudienceScreenXNumericUpDown.Value
        ini(9) = AudienceScreenYNumericUpDown.Value
        ini(10) = FileNameQ
        ini(12) = ServerIpTextBox.Text
        ini(13) = ServerPortTextBox.Text
        FileClose(1)
        FileOpen(1, CurDir() & "\wwtbam_set.ini", OpenMode.Output)
        Print(1, "|" & ini(1) & "|" & ini(2) & "|" & ini(3) & "|" & ini(4) & "|" & ini(5) & "|" & ini(6) & "|" & ini(7) & "|" & ini(8) & "|" & ini(9) & "|" & ini(10) & "|" & ini(11) & "|" & ini(12) & "|" & ini(13) & "|" & ini(14) & "|" & ini(15) & "|")
        FileClose(1)
        Host.Close()
        Player.Close()
        Audience.Close()
        Form50_50.Close()
        FormPAF.Close()
        FormATA.Close()
        Editor.Close()
        FormFFF.Close()
        AboutUs.Close()
        Shell("source\BAT\stop_back_music1.bat", AppWinStyle.MinimizedNoFocus)
        End
    End Sub

    REM СЕТЕВОЕ ОБЕСПЕЧЕНИЕ!!!
    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click
        'Установка соединения с сервером (Connect Button)
        hostIP = ServerIpTextBox.Text
        port = ServerPortTextBox.Text
        If Client.IsConnection Then
            Client.Disconnect()
        Else
            If hostIP = String.Empty Then Exit Sub
            If Not Client.Connect(hostIP, port) Then 'Успешна ли попытка подключения
                MsgBox(currentBlock1(145, 3) & ": " & hostIP, MsgBoxStyle.Critical, currentBlock1(145, 4))
            Else
                ConnectButton.Text = currentBlock1(33, 4) 'Disconnect
                ConnectButton.BackColor = Color.Green
                ConnectionPost()
                Host.Hide()
                Player.Hide()
                'Синхронизация по сети
                'If ConnectButton.BackColor = Color.Green Then
                '    Dim NetworkInfo As New IONetwork
                '    With NetworkInfo
                '        .Command = "@sync|questionText|textAnswerA|textAnswerB|textAnswerC|textAnswerD|numberRightAnswer|currentBlock2(QuestionListBox.SelectedIndex + 1, 9)|winNumber|MoneyTakenCheckBox.Checked|QuestionNumberNumericUpDown.Value|activ50|activPAF|activATA|HostFrameCheckBox.Checked|PlayerFrameCheckBox.Checked|HostVisibleCheckBox.Checked|PlayerVisibleCheckBox.Checked|commentShow|splashOn|HostScreenXNumericUpDown.Value|HostScreenYNumericUpDown.Value|PlayerScreenXNumericUpDown.Value|PlayerScreenYNumericUpDown.Value|FormPAF.clockFrame|Host.ClockPictureBox.ImageLocation|Player.ClockPictureBox.ImageLocation|Host.ClockPictureBox.Visible|Player.ClockPictureBox.Visible|Host.AnswerAPercentLabel.Text|Host.AnswerBPercentLabel.Text|Host.AnswerCPercentLabel.Text|Host.AnswerDPercentLabel.Text|Host.AnswerAPercentLabel.Visible|Host.AnswerBPercentLabel.Visible|Host.AnswerCPercentLabel.Visible|Host.AnswerDPercentLabel.Visible|Host.AnswerAChartPictureBox.Visible|Host.AnswerBChartPictureBox.Visible|Host.AnswerCChartPictureBox.Visible|Host.AnswerDChartPictureBox.Visible|Host.AnswerAChartPictureBox.Height|Host.AnswerBChartPictureBox.Height|Host.AnswerCChartPictureBox.Height|Host.AnswerDChartPictureBox.Height|Host.AnswerAChartPictureBox.Top|Host.AnswerBChartPictureBox.Top|Host.AnswerCChartPictureBox.Top|Host.AnswerDChartPictureBox.Top|Player.AnswerAPercentLabel.Text|Player.AnswerBPercentLabel.Text|Player.AnswerCPercentLabel.Text|Player.AnswerDPercentLabel.Text|Player.AnswerAPercentLabel.Visible|Player.AnswerBPercentLabel.Visible|Player.AnswerCPercentLabel.Visible|Player.AnswerDPercentLabel.Visible|Player.AnswerAChartPictureBox.Visible|Player.AnswerBChartPictureBox.Visible|Player.AnswerCChartPictureBox.Visible|Player.AnswerDChartPictureBox.Visible|Player.AnswerAChartPictureBox.Height|Player.AnswerBChartPictureBox.Height|Player.AnswerCChartPictureBox.Height|Player.AnswerDChartPictureBox.Height|Player.AnswerAChartPictureBox.Top|Player.AnswerBChartPictureBox.Top|Player.AnswerCChartPictureBox.Top|Player.AnswerDChartPictureBox.Top|Host.BackgroundImage|Host.AnswerAFramePictureBox.BackgroundImage|Host.AnswerBFramePictureBox.BackgroundImage|Host.AnswerCFramePictureBox.BackgroundImage|Host.AnswerDFramePictureBox.BackgroundImage|Host.MoneyTreePictureBox.BackgroundImage|Host.LifelinesPictureBox.BackgroundImage|Host.QuestionTextLabel.Text|Host.AnswerATextLabel.Text|Host.AnswerBTextLabel.Text|Host.AnswerCTextLabel.Text|Host.AnswerDTextLabel.Text|Host.QuestionsLeftLabel.Text|Host.PossibleWinLabel.Text|Host.CurrentWinLabel.Text|Host.PossibleLossLabel.Text|Host.FinalAnswerLetterLabel.Text|Host.GuaranteedSumLabel.Text|Host.QuestionCommentLabel.Text|Host.HostMessageLabel.Text|Host.LogoPictureBox.Visible|Player.BackgroundImage|Player.AnswerAFramePictureBox.BackgroundImage|Player.AnswerBFramePictureBox.BackgroundImage|Player.AnswerCFramePictureBox.BackgroundImage|Player.AnswerDFramePictureBox.BackgroundImage|Player.MoneyTreePictureBox.BackgroundImage|Player.LifelinesPictureBox.BackgroundImage|Player.QuestionTextLabel.Text|Player.AnswerATextLabel.Text|Player.AnswerBTextLabel.Text|Player.AnswerCTextLabel.Text|Player.AnswerDTextLabel.Text|Player.WinnerNameLabel.Text|Player.MoneyWonPictureBox.BackgroundImage|Player.PrizePictureBox.BackgroundImage|Player.LogoPictureBox.Visible|"
                '    End With
                '    Client_SendIONetwork(NetworkInfo)
                'End If
            End If
        End If
    End Sub

    Public Sub ConnectionPost()
        'Команда пересылки данных
        Dim NetworkInfo As New IONetwork
        With NetworkInfo
            .Command = "@connect_success|"
        End With
        Client_SendIONetwork(NetworkInfo)
    End Sub

    Public Sub Client_SendIONetwork(e As IONetwork)
        'Создание данных для пересылки
        Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
        Using streamSend As New IO.MemoryStream
            formatter.Serialize(streamSend, e)
            Client.Send(System.Text.Encoding.Default.GetBytes(System.Text.Encoding.Default.GetString(streamSend.ToArray) & "@end_sending"))
        End Using
        GC.Collect()
    End Sub

    REM ДЕЙСТВИЯ СЕРВЕРА
    Private Sub Server_ReceiveData(sender As Object, e As Server.ReceiveDataEventArgs) Handles Server.ReceiveData
        'Чтение сервером полученных данных
        Static MessageString As String = String.Empty
        MessageString &= System.Text.Encoding.Default.GetString(e.MessageData)
        If MessageString.EndsWith("@end_sending") Then
            MessageString = Strings.Left(MessageString, MessageString.Length)
            Dim Messages() As String = Split(MessageString, "@end_sending")
            MessageString = String.Empty
            Array.Resize(Messages, Messages.Length - 1)
            For Each M In Messages
                Try
                    Dim formatter As New Runtime.Serialization.Formatters.Binary.BinaryFormatter()
                    Server_GetIONetwork(formatter.Deserialize(New IO.MemoryStream(System.Text.Encoding.Default.GetBytes(M))), e.RemoteEndPoint)
                Catch ex As Exception

                End Try
            Next
        End If
        GC.Collect()
    End Sub

    Public Sub Server_GetIONetwork(e As IONetwork, endPoint As Net.EndPoint)
        'Обработка принятых команд
        Dim doingEvent() As String = Split(e.Command, "|")
        If Client.IsConnection = False Then
            Select Case doingEvent(0)
                Case "@connect_success" 'При успешном соединении
                    If Me.WindowState <> FormWindowState.Minimized Then Me.WindowState = FormWindowState.Minimized
                    If HostVisibleCheckBox.Checked Then Host.Focus()
                    If PlayerVisibleCheckBox.Checked Then Player.Focus()
                    AudienceVisibleCheckBox.Checked = False
                    Host.HostMessageLabel.Text = currentBlock1(146, 3)
                Case "@button1" 'Ask It
                    Host.FinalAnswerLetterLabel.Text = ""
                    Host.QuestionCommentLabel.Text = ""
                    questionText = doingEvent(1)
                    QuestionTextLabel.Text = questionText
                    numberRightAnswer = doingEvent(2)
                    questionNumber = doingEvent(3)
                    winNumber = questionNumber - 1
                    Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@button2" 'Enable A
                    AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                    AnswerATextLabel.Text = doingEvent(1)
                Case "@button3" 'Enable B
                    AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                    AnswerBTextLabel.Text = doingEvent(1)
                Case "@button4" 'Enable C
                    AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                    AnswerCTextLabel.Text = doingEvent(1)
                Case "@button5" 'Enable D
                    AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                    AnswerDTextLabel.Text = doingEvent(1)
                Case "@button6" 'Enable All
                    AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                    AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                    AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                    AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                    numberRightAnswer = doingEvent(6)
                    QuestionTextLabel.Text = doingEvent(1)
                    AnswerATextLabel.Text = doingEvent(2)
                    AnswerBTextLabel.Text = doingEvent(3)
                    AnswerCTextLabel.Text = doingEvent(4)
                    AnswerDTextLabel.Text = doingEvent(5)
                    Host.QuestionCommentLabel.Text = doingEvent(6)
                Case "@button8", "@button9", "@button10", "@button11" 'Receive A, B, C, D
                    Select Case numberRightAnswer
                        Case 1
                            Host.FinalAnswerLetterLabel.Text = "A"
                        Case 2
                            Host.FinalAnswerLetterLabel.Text = "B"
                        Case 3
                            Host.FinalAnswerLetterLabel.Text = "C"
                        Case 4
                            Host.FinalAnswerLetterLabel.Text = "D"
                    End Select
                    AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                    AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                    AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                    AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                    AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerATextLabel.ForeColor = Color.White
                    AnswerBTextLabel.ForeColor = Color.White
                    AnswerCTextLabel.ForeColor = Color.White
                    AnswerDTextLabel.ForeColor = Color.White
                    Host.QuestionCommentLabel.Text = doingEvent(1)
                    Select Case doingEvent(0)
                        Case "@button8"
                            playerAnswerNumber = 1
                            AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_ORANGE.png")
                            AnswerATextLabel.BackColor = Color.FromArgb(244, 155, 15)
                            AnswerATextLabel.ForeColor = Color.Black
                        Case "@button9"
                            playerAnswerNumber = 2
                            AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_ORANGE.png")
                            AnswerBTextLabel.BackColor = Color.FromArgb(244, 155, 15)
                            AnswerBTextLabel.ForeColor = Color.Black
                        Case "@button10"
                            playerAnswerNumber = 3
                            AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_ORANGE.png")
                            AnswerCTextLabel.BackColor = Color.FromArgb(244, 155, 15)
                            AnswerCTextLabel.ForeColor = Color.Black
                        Case "@button11"
                            playerAnswerNumber = 4
                            AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_ORANGE.png")
                            AnswerDTextLabel.BackColor = Color.FromArgb(244, 155, 15)
                            AnswerDTextLabel.ForeColor = Color.Black
                    End Select
                Case "@button12" 'What's correct
                    Host.QuestionsLeftLabel.Text = "Qaway:" & Str(15 - questionNumber)
                    Select Case numberRightAnswer
                        Case 1
                            AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_GREEN.png")
                            AnswerATextLabel.BackColor = Color.FromArgb(93, 179, 87)
                            AnswerATextLabel.ForeColor = Color.Black
                        Case 2
                            AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_GREEN.png")
                            AnswerBTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                            AnswerBTextLabel.ForeColor = Color.Black
                        Case 3
                            AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_GREEN.png")
                            AnswerCTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                            AnswerCTextLabel.ForeColor = Color.Black
                        Case 4
                            AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_GREEN.png")
                            AnswerDTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                            AnswerDTextLabel.ForeColor = Color.Black
                    End Select
                    winNumber = doingEvent(2)
                    If doingEvent(1) = False Then
                        If playerAnswerNumber = numberRightAnswer Then
                            MoneyWonRevealTimer.Start()
                            Select Case questionNumber
                                Case 0
                                    Host.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                                    Host.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                                    Host.PossibleLossLabel.Text = "0" 'Возможная потеря
                                    Host.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                                Case 1
                                    Host.PossibleWinLabel.Text = "200"
                                    Host.CurrentWinLabel.Text = "100"
                                    Host.PossibleLossLabel.Text = "100"
                                    Host.GuaranteedSumLabel.Text = "0"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                                Case 2
                                    Host.PossibleWinLabel.Text = "300"
                                    Host.CurrentWinLabel.Text = "200"
                                    Host.PossibleLossLabel.Text = "200"
                                    Host.GuaranteedSumLabel.Text = "0"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                                Case 3
                                    Host.PossibleWinLabel.Text = "500"
                                    Host.CurrentWinLabel.Text = "200"
                                    Host.PossibleLossLabel.Text = "200"
                                    Host.GuaranteedSumLabel.Text = "0"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                                Case 4
                                    Host.PossibleWinLabel.Text = "1,000"
                                    Host.CurrentWinLabel.Text = "500"
                                    Host.PossibleLossLabel.Text = "500"
                                    Host.GuaranteedSumLabel.Text = "0"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                                Case 5
                                    Host.PossibleWinLabel.Text = "2,000"
                                    Host.CurrentWinLabel.Text = "1,000"
                                    Host.PossibleLossLabel.Text = "0"
                                    Host.GuaranteedSumLabel.Text = "1,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                                Case 6
                                    Host.PossibleWinLabel.Text = "4,000"
                                    Host.CurrentWinLabel.Text = "2,000"
                                    Host.PossibleLossLabel.Text = "1,000"
                                    Host.GuaranteedSumLabel.Text = "1,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                                Case 7
                                    Host.PossibleWinLabel.Text = "8,000"
                                    Host.CurrentWinLabel.Text = "4,000"
                                    Host.PossibleLossLabel.Text = "3,000"
                                    Host.GuaranteedSumLabel.Text = "1,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                                Case 8
                                    Host.PossibleWinLabel.Text = "16,000"
                                    Host.CurrentWinLabel.Text = "8,000"
                                    Host.PossibleLossLabel.Text = "7,000"
                                    Host.GuaranteedSumLabel.Text = "1,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                                Case 9
                                    Host.PossibleWinLabel.Text = "32,000"
                                    Host.CurrentWinLabel.Text = "16,000"
                                    Host.PossibleLossLabel.Text = "15,000"
                                    Host.GuaranteedSumLabel.Text = "1,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                                Case 10
                                    Host.PossibleWinLabel.Text = "64,000"
                                    Host.CurrentWinLabel.Text = "32,000"
                                    Host.PossibleLossLabel.Text = "0"
                                    Host.GuaranteedSumLabel.Text = "32,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                                Case 11
                                    Host.PossibleWinLabel.Text = "125,000"
                                    Host.CurrentWinLabel.Text = "64,000"
                                    Host.PossibleLossLabel.Text = "32,000"
                                    Host.GuaranteedSumLabel.Text = "32,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                                Case 12
                                    Host.PossibleWinLabel.Text = "250,000"
                                    Host.CurrentWinLabel.Text = "125,000"
                                    Host.PossibleLossLabel.Text = "93,000"
                                    Host.GuaranteedSumLabel.Text = "32,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                                Case 13
                                    Host.PossibleWinLabel.Text = "500,000"
                                    Host.CurrentWinLabel.Text = "250,000"
                                    Host.PossibleLossLabel.Text = "218,000"
                                    Host.GuaranteedSumLabel.Text = "32,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                                Case 14
                                    Host.PossibleWinLabel.Text = "1,000,000"
                                    Host.CurrentWinLabel.Text = "500,000"
                                    Host.PossibleLossLabel.Text = "468,000"
                                    Host.GuaranteedSumLabel.Text = "32,000"
                                    Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                            End Select
                        Else
                            PrizeRevealTimer.Start()
                            Player.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                        End If
                    Else
                        PrizeRevealTimer.Start()
                        If winNumber < 15 Then
                            Player.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                        End If
                    End If
                    Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@millionaire" '@button12 + winNumber=15
                    winNumber = 15
                    Select Case numberRightAnswer
                        Case 1
                            AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_GREEN.png")
                            AnswerATextLabel.BackColor = Color.FromArgb(93, 179, 87)
                            AnswerATextLabel.ForeColor = Color.Black
                        Case 2
                            AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_GREEN.png")
                            AnswerBTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                            AnswerBTextLabel.ForeColor = Color.Black
                        Case 3
                            AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_GREEN.png")
                            AnswerCTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                            AnswerCTextLabel.ForeColor = Color.Black
                        Case 4
                            AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_GREEN.png")
                            AnswerDTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                            AnswerDTextLabel.ForeColor = Color.Black
                    End Select
                    Host.QuestionsLeftLabel.Text = "Qaway: 0"
                    Host.PossibleWinLabel.Text = "1,000,000"
                    Host.CurrentWinLabel.Text = "1,000,000"
                    Host.PossibleLossLabel.Text = "0"
                    Host.GuaranteedSumLabel.Text = "1,000,000"
                    PrizeRevealTimer.Start()
                    Player.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\MILLIONAIRE.png")
                    Player.WinnerNameLabel.Text = doingEvent(1)
                    Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@button13" 'Lx
                    MoneyWonRevealTimer.Stop()
                    Player.MoneyWonPictureBox.Visible = False
                    QuestionTextLabel.Text = ""
                    AnswerATextLabel.Text = ""
                    AnswerBTextLabel.Text = ""
                    AnswerCTextLabel.Text = ""
                    AnswerDTextLabel.Text = ""
                    AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    Player.QuestionTextLabel.Visible = True
                    Player.AnswerATextLabel.Visible = True
                    Player.AnswerBTextLabel.Visible = True
                    Player.AnswerCTextLabel.Visible = True
                    Player.AnswerDTextLabel.Visible = True
                    Player.AnswerAFramePictureBox.Visible = True
                    Player.AnswerBFramePictureBox.Visible = True
                    Player.AnswerCFramePictureBox.Visible = True
                    Player.AnswerDFramePictureBox.Visible = True
                    Player.PrizePictureBox.Visible = False
                    Player.WinnerNameLabel.Visible = False
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerATextLabel.ForeColor = Color.White
                    AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerBTextLabel.ForeColor = Color.White
                    AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerCTextLabel.ForeColor = Color.White
                    AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerDTextLabel.ForeColor = Color.White
                    questionNumber = doingEvent(1)
                Case "@button25" 'Explane Lifelines
                    winNumber = doingEvent(4)
                    Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Host.LogoPictureBox.Visible = False
                    Player.LogoPictureBox.Visible = False
                    splashOn = False
                    ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
                    ToggleLogoButton.BackColor = Color.White
                    ClearFormsButton.PerformClick()
                    If doingEvent(1) = "0" Then FiftyFiftyAvailableCheckBox.Checked = True Else FiftyFiftyAvailableCheckBox.Checked = False
                    If doingEvent(2) = "0" Then PhoneAFriendAvailableCheckBox.Checked = True Else PhoneAFriendAvailableCheckBox.Checked = False
                    If doingEvent(3) = "0" Then AskTheAudienceAvailableCheckBox.Checked = True Else AskTheAudienceAvailableCheckBox.Checked = False
                Case "@button26", "@button27", "@button28" 'Lifelines Pings
                    Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    LifelinesRefreshTimer.Start()
                Case "@button30" 'Start the game
                    Player.MoneyWonPictureBox.Visible = False
                    Host.QuestionsLeftLabel.Text = "Qaway:" & Str(15 - doingEvent(2))
                    If doingEvent(2) < 15 Then
                        Select Case doingEvent(1)
                            Case 0, 1
                                Host.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                                Host.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                                Host.PossibleLossLabel.Text = "0" 'Возможная потеря
                                Host.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                            Case 2
                                Host.PossibleWinLabel.Text = "200"
                                Host.CurrentWinLabel.Text = "100"
                                Host.PossibleLossLabel.Text = "100"
                                Host.GuaranteedSumLabel.Text = "0"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                            Case 3
                                Host.PossibleWinLabel.Text = "300"
                                Host.CurrentWinLabel.Text = "200"
                                Host.PossibleLossLabel.Text = "200"
                                Host.GuaranteedSumLabel.Text = "0"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                            Case 4
                                Host.PossibleWinLabel.Text = "500"
                                Host.CurrentWinLabel.Text = "200"
                                Host.PossibleLossLabel.Text = "200"
                                Host.GuaranteedSumLabel.Text = "0"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                            Case 5
                                Host.PossibleWinLabel.Text = "1,000"
                                Host.CurrentWinLabel.Text = "500"
                                Host.PossibleLossLabel.Text = "500"
                                Host.GuaranteedSumLabel.Text = "0"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                            Case 6
                                Host.PossibleWinLabel.Text = "2,000"
                                Host.CurrentWinLabel.Text = "1,000"
                                Host.PossibleLossLabel.Text = "0"
                                Host.GuaranteedSumLabel.Text = "1,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                            Case 7
                                Host.PossibleWinLabel.Text = "4,000"
                                Host.CurrentWinLabel.Text = "2,000"
                                Host.PossibleLossLabel.Text = "1,000"
                                Host.GuaranteedSumLabel.Text = "1,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                            Case 8
                                Host.PossibleWinLabel.Text = "8,000"
                                Host.CurrentWinLabel.Text = "4,000"
                                Host.PossibleLossLabel.Text = "3,000"
                                Host.GuaranteedSumLabel.Text = "1,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                            Case 9
                                Host.PossibleWinLabel.Text = "16,000"
                                Host.CurrentWinLabel.Text = "8,000"
                                Host.PossibleLossLabel.Text = "7,000"
                                Host.GuaranteedSumLabel.Text = "1,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                            Case 10
                                Host.PossibleWinLabel.Text = "32,000"
                                Host.CurrentWinLabel.Text = "16,000"
                                Host.PossibleLossLabel.Text = "15,000"
                                Host.GuaranteedSumLabel.Text = "1,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                            Case 11
                                Host.PossibleWinLabel.Text = "64,000"
                                Host.CurrentWinLabel.Text = "32,000"
                                Host.PossibleLossLabel.Text = "0"
                                Host.GuaranteedSumLabel.Text = "32,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                            Case 12
                                Host.PossibleWinLabel.Text = "125,000"
                                Host.CurrentWinLabel.Text = "64,000"
                                Host.PossibleLossLabel.Text = "32,000"
                                Host.GuaranteedSumLabel.Text = "32,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                            Case 13
                                Host.PossibleWinLabel.Text = "250,000"
                                Host.CurrentWinLabel.Text = "125,000"
                                Host.PossibleLossLabel.Text = "93,000"
                                Host.GuaranteedSumLabel.Text = "32,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                            Case 14
                                Host.PossibleWinLabel.Text = "500,000"
                                Host.CurrentWinLabel.Text = "250,000"
                                Host.PossibleLossLabel.Text = "218,000"
                                Host.GuaranteedSumLabel.Text = "32,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                            Case 15
                                Host.PossibleWinLabel.Text = "1,000,000"
                                Host.CurrentWinLabel.Text = "500,000"
                                Host.PossibleLossLabel.Text = "468,000"
                                Host.GuaranteedSumLabel.Text = "32,000"
                                Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                        End Select
                    End If
                    Host.FinalAnswerLetterLabel.Text = ""
                    QuestionTextLabel.Text = ""
                    AnswerATextLabel.Text = ""
                    AnswerBTextLabel.Text = ""
                    AnswerCTextLabel.Text = ""
                    AnswerDTextLabel.Text = ""
                    Player.QuestionTextLabel.Visible = True
                    Player.AnswerATextLabel.Visible = True
                    Player.AnswerBTextLabel.Visible = True
                    Player.AnswerCTextLabel.Visible = True
                    Player.AnswerDTextLabel.Visible = True
                    Player.AnswerAFramePictureBox.Visible = True
                    Player.AnswerBFramePictureBox.Visible = True
                    Player.AnswerCFramePictureBox.Visible = True
                    Player.AnswerDFramePictureBox.Visible = True
                    Player.PrizePictureBox.Visible = False
                    Player.WinnerNameLabel.Visible = False
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerATextLabel.ForeColor = Color.White
                    AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerBTextLabel.ForeColor = Color.White
                    AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerCTextLabel.ForeColor = Color.White
                    AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerDTextLabel.ForeColor = Color.White
                    Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & doingEvent(2) & ".png"
                    Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & doingEvent(2) & ".png"
                    Host.QuestionCommentLabel.Text = ""
                    commentShow = False
                    MoneyTakenCheckBox.Checked = False
                    Host.LogoPictureBox.Visible = False
                    Player.LogoPictureBox.Visible = False
                    splashOn = False
                    ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
                    ToggleLogoButton.BackColor = Color.White
                Case "@button33" 'Goodbye Punter
                    ClearFormsButton.PerformClick()
                    MoneyTreeLevel0Button.PerformClick()
                    questionNumber = 1
                    FiftyFiftyAvailableCheckBox.Checked = True
                    PhoneAFriendAvailableCheckBox.Checked = True
                    AskTheAudienceAvailableCheckBox.Checked = True
                    MoneyTakenCheckBox.Checked = False
                    If splashOn = False Then
                        ToggleLogoButton.PerformClick()
                    End If
                Case "@numericupdown1" 'Смена номера вопроса
                    questionNumber = doingEvent(1)
                Case "@button24" 'Clear forms
                    ClearFormsButton.PerformClick()
                Case "@button20_1" 'Take a money 1
                    MoneyTakenCheckBox.Checked = doingEvent(1)
                    PrizeRevealTimer.Start()
                    If winNumber < 15 Then
                        Player.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                    End If
                    TakeTheMoneyButton.BackColor = Color.Blue
                    MoneyTakenCheckBox.Checked = True
                Case "@button20_2" 'Take a money 2
                    MoneyTakenCheckBox.Checked = doingEvent(1)
                    Player.WinnerNameLabel.Visible = False
                    Player.QuestionTextLabel.Visible = True
                    Player.AnswerATextLabel.Visible = True
                    Player.AnswerBTextLabel.Visible = True
                    Player.AnswerCTextLabel.Visible = True
                    Player.AnswerDTextLabel.Visible = True
                    Player.AnswerAFramePictureBox.Visible = True
                    Player.AnswerBFramePictureBox.Visible = True
                    Player.AnswerCFramePictureBox.Visible = True
                    Player.AnswerDFramePictureBox.Visible = True
                    Player.PrizePictureBox.Visible = False
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    PrizeRevealTimer.Stop()
                    TakeTheMoneyButton.BackColor = Color.White
                Case "@lifelines_state", "@button17", "@button15", "@button18" '50-50, PAF or ATA state changed
                    Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                Case "@checkbox4" 'Host frame
                    HostFrameCheckBox.Checked = doingEvent(1)
                    If HostFrameCheckBox.Checked = True Then
                        Host.FormBorderStyle = FormBorderStyle.Sizable
                    Else
                        Host.FormBorderStyle = FormBorderStyle.None
                    End If
                Case "@checkbox5" 'Player frame state
                    PlayerFrameCheckBox.Checked = doingEvent(1)
                    If PlayerFrameCheckBox.Checked = True Then
                        Player.FormBorderStyle = FormBorderStyle.Sizable
                    Else
                        Player.FormBorderStyle = FormBorderStyle.None
                    End If
                Case "@checkbox7" 'Host window visibility
                    HostVisibleCheckBox.Checked = doingEvent(1)
                    If HostVisibleCheckBox.Checked = True Then
                        Host.Show()
                    Else
                        Host.Hide()
                    End If
                Case "@checkbox8" 'Player window visibility
                    PlayerVisibleCheckBox.Checked = doingEvent(1)
                    If PlayerVisibleCheckBox.Checked = True Then
                        Player.Show()
                    Else
                        Player.Hide()
                    End If
                Case "@button44" 'Send (message)
                    Host.HostMessageLabel.Text = doingEvent(1)
                Case "@button45" 'Clear (message)
                    Host.HostMessageLabel.Text = Nothing
                Case "@button14" 'Show hint
                    If doingEvent(1) = True Then commentShow = False Else commentShow = True
                    currentBlock2(QuestionListBox.SelectedIndex + 1, 9) = doingEvent(2)
                    ToggleHintButton.PerformClick()
                Case "@button16" 'Show logo
                    If doingEvent(1) = True Then splashOn = False Else splashOn = True
                    If splashOn = False Then
                        Host.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
                        Host.LogoPictureBox.Visible = True
                        Player.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
                        Player.LogoPictureBox.Visible = True
                        splashOn = True
                    Else
                        Host.LogoPictureBox.Visible = False
                        Player.LogoPictureBox.Visible = False
                        splashOn = False
                    End If
                Case "@numericupdown2" 'Host window location
                    Host.Location = New Point(doingEvent(1), doingEvent(2))
                Case "@numericupdown4" 'Player window location
                    Player.Location = New Point(doingEvent(1), doingEvent(2))
                Case "@button42", "@button43", "@button52", "@button51", "@button50", "@button49" 'Tree Up or Tree Down
                    winNumber = doingEvent(1)
                    Select Case questionNumber
                        Case 0
                            Host.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                            Host.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                            Host.PossibleLossLabel.Text = "0" 'Возможная потеря
                            Host.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                        Case 1
                            Host.PossibleWinLabel.Text = "200"
                            Host.CurrentWinLabel.Text = "100"
                            Host.PossibleLossLabel.Text = "100"
                            Host.GuaranteedSumLabel.Text = "0"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                        Case 2
                            Host.PossibleWinLabel.Text = "300"
                            Host.CurrentWinLabel.Text = "200"
                            Host.PossibleLossLabel.Text = "200"
                            Host.GuaranteedSumLabel.Text = "0"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                        Case 3
                            Host.PossibleWinLabel.Text = "500"
                            Host.CurrentWinLabel.Text = "200"
                            Host.PossibleLossLabel.Text = "200"
                            Host.GuaranteedSumLabel.Text = "0"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                        Case 4
                            Host.PossibleWinLabel.Text = "1,000"
                            Host.CurrentWinLabel.Text = "500"
                            Host.PossibleLossLabel.Text = "500"
                            Host.GuaranteedSumLabel.Text = "0"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                        Case 5
                            Host.PossibleWinLabel.Text = "2,000"
                            Host.CurrentWinLabel.Text = "1,000"
                            Host.PossibleLossLabel.Text = "0"
                            Host.GuaranteedSumLabel.Text = "1,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                        Case 6
                            Host.PossibleWinLabel.Text = "4,000"
                            Host.CurrentWinLabel.Text = "2,000"
                            Host.PossibleLossLabel.Text = "1,000"
                            Host.GuaranteedSumLabel.Text = "1,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                        Case 7
                            Host.PossibleWinLabel.Text = "8,000"
                            Host.CurrentWinLabel.Text = "4,000"
                            Host.PossibleLossLabel.Text = "3,000"
                            Host.GuaranteedSumLabel.Text = "1,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                        Case 8
                            Host.PossibleWinLabel.Text = "16,000"
                            Host.CurrentWinLabel.Text = "8,000"
                            Host.PossibleLossLabel.Text = "7,000"
                            Host.GuaranteedSumLabel.Text = "1,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                        Case 9
                            Host.PossibleWinLabel.Text = "32,000"
                            Host.CurrentWinLabel.Text = "16,000"
                            Host.PossibleLossLabel.Text = "15,000"
                            Host.GuaranteedSumLabel.Text = "1,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                        Case 10
                            Host.PossibleWinLabel.Text = "64,000"
                            Host.CurrentWinLabel.Text = "32,000"
                            Host.PossibleLossLabel.Text = "0"
                            Host.GuaranteedSumLabel.Text = "32,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                        Case 11
                            Host.PossibleWinLabel.Text = "125,000"
                            Host.CurrentWinLabel.Text = "64,000"
                            Host.PossibleLossLabel.Text = "32,000"
                            Host.GuaranteedSumLabel.Text = "32,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                        Case 12
                            Host.PossibleWinLabel.Text = "250,000"
                            Host.CurrentWinLabel.Text = "125,000"
                            Host.PossibleLossLabel.Text = "93,000"
                            Host.GuaranteedSumLabel.Text = "32,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                        Case 13
                            Host.PossibleWinLabel.Text = "500,000"
                            Host.CurrentWinLabel.Text = "250,000"
                            Host.PossibleLossLabel.Text = "218,000"
                            Host.GuaranteedSumLabel.Text = "32,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                        Case 14
                            Host.PossibleWinLabel.Text = "1,000,000"
                            Host.CurrentWinLabel.Text = "500,000"
                            Host.PossibleLossLabel.Text = "468,000"
                            Host.GuaranteedSumLabel.Text = "32,000"
                            Player.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                        Case 15
                            Host.PossibleWinLabel.Text = "1,000,000"
                            Host.CurrentWinLabel.Text = "1,000,000"
                            Host.PossibleLossLabel.Text = "0"
                            Host.GuaranteedSumLabel.Text = "1,000,000"
                    End Select
                    Host.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@50-50_button1" '50:50 AskQuestionButton
                    AnswerATextLabel.Text = doingEvent(1)
                    AnswerBTextLabel.Text = doingEvent(2)
                    AnswerCTextLabel.Text = doingEvent(3)
                    AnswerDTextLabel.Text = doingEvent(4)
                    FiftyFiftyAvailableCheckBox.Checked = False
                    Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                Case "@paf_button1" 'PAF AskQuestionButton
                    FormPAF.ClockTimer.Stop()
                    Host.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
                    Player.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
                    Host.ClockPictureBox.Visible = False
                    Player.ClockPictureBox.Visible = False
                    My.Computer.Audio.Stop()
                Case "@paf_button2" 'PAF EnableAnswerAButton
                    FormPAF.ClockTimer.Stop()
                    FormPAF.clockFrame = 1
                    Host.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
                    Player.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
                    FormPAF.ClockTimer.Start()
                    Host.ClockPictureBox.Visible = True
                    Player.ClockPictureBox.Visible = True
                    My.Computer.Audio.Stop()
                Case "@paf_button3" 'PAF EnableAnswerBButton
                    FormPAF.ClockTimer.Stop()
                    PhoneAFriendAvailableCheckBox.Checked = False
                    Host.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
                    Player.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
                    My.Computer.Audio.Stop()
                Case "@paf_closed" 'PAF closed
                    FormPAF.ClockTimer.Stop()
                    Host.ClockPictureBox.Visible = False
                    Player.ClockPictureBox.Visible = False
                    My.Computer.Audio.Stop()
                    Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                Case "@ata_button2" 'ATA EnableAnswerAButton
                    Host.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Host Screen ATA.png")
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen ATA.png")
                Case "@ata_button3" 'ATA EnableAnswerBButton
                    Host.AnswerAPercentLabel.Text = doingEvent(5) & "%"
                    Host.AnswerBPercentLabel.Text = doingEvent(6) & "%"
                    Host.AnswerCPercentLabel.Text = doingEvent(7) & "%"
                    Host.AnswerDPercentLabel.Text = doingEvent(8) & "%"
                    Host.AnswerAPercentLabel.Visible = True
                    Host.AnswerBPercentLabel.Visible = True
                    Host.AnswerCPercentLabel.Visible = True
                    Host.AnswerDPercentLabel.Visible = True
                    Host.AnswerAChartPictureBox.Visible = True
                    Host.AnswerBChartPictureBox.Visible = True
                    Host.AnswerCChartPictureBox.Visible = True
                    Host.AnswerDChartPictureBox.Visible = True
                    Host.AnswerAChartPictureBox.Height = doingEvent(1) * 1.2
                    Host.AnswerBChartPictureBox.Height = doingEvent(2) * 1.2
                    Host.AnswerCChartPictureBox.Height = doingEvent(3) * 1.2
                    Host.AnswerDChartPictureBox.Height = doingEvent(4) * 1.2
                    Host.AnswerAChartPictureBox.Top = 515 - doingEvent(1) * 1.2
                    Host.AnswerBChartPictureBox.Top = 515 - doingEvent(2) * 1.2
                    Host.AnswerCChartPictureBox.Top = 515 - doingEvent(3) * 1.2
                    Host.AnswerDChartPictureBox.Top = 515 - doingEvent(4) * 1.2
                    Player.AnswerAPercentLabel.Text = doingEvent(5) & "%"
                    Player.AnswerBPercentLabel.Text = doingEvent(6) & "%"
                    Player.AnswerCPercentLabel.Text = doingEvent(7) & "%"
                    Player.AnswerDPercentLabel.Text = doingEvent(8) & "%"
                    Player.AnswerAPercentLabel.Visible = True
                    Player.AnswerBPercentLabel.Visible = True
                    Player.AnswerCPercentLabel.Visible = True
                    Player.AnswerDPercentLabel.Visible = True
                    Player.AnswerAChartPictureBox.Visible = True
                    Player.AnswerBChartPictureBox.Visible = True
                    Player.AnswerCChartPictureBox.Visible = True
                    Player.AnswerDChartPictureBox.Visible = True
                    Player.AnswerAChartPictureBox.Height = doingEvent(1) * 2.4
                    Player.AnswerBChartPictureBox.Height = doingEvent(2) * 2.4
                    Player.AnswerCChartPictureBox.Height = doingEvent(3) * 2.4
                    Player.AnswerDChartPictureBox.Height = doingEvent(4) * 2.4
                    Player.AnswerAChartPictureBox.Top = 538 - doingEvent(1) * 2.4
                    Player.AnswerBChartPictureBox.Top = 538 - doingEvent(2) * 2.4
                    Player.AnswerCChartPictureBox.Top = 538 - doingEvent(3) * 2.4
                    Player.AnswerDChartPictureBox.Top = 538 - doingEvent(4) * 2.4
                    HostMessageTextBox.Text = doingEvent(9)
                    Host.HostMessageLabel.Text = doingEvent(9)
                    AskTheAudienceAvailableCheckBox.Checked = False
                Case "@ata_closed" 'ATA closed
                    Host.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    Host.AnswerAPercentLabel.Visible = False
                    Host.AnswerBPercentLabel.Visible = False
                    Host.AnswerCPercentLabel.Visible = False
                    Host.AnswerDPercentLabel.Visible = False
                    Host.AnswerAChartPictureBox.Visible = False
                    Host.AnswerBChartPictureBox.Visible = False
                    Host.AnswerCChartPictureBox.Visible = False
                    Host.AnswerDChartPictureBox.Visible = False
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    Player.AnswerAPercentLabel.Visible = False
                    Player.AnswerBPercentLabel.Visible = False
                    Player.AnswerCPercentLabel.Visible = False
                    Player.AnswerDPercentLabel.Visible = False
                    Player.AnswerAChartPictureBox.Visible = False
                    Player.AnswerBChartPictureBox.Visible = False
                    Player.AnswerCChartPictureBox.Visible = False
                    Player.AnswerDChartPictureBox.Visible = False
                    My.Computer.Audio.Stop()
                    Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    'Case "@sync" 'Синхронизация
                    '    numberRightAnswer = doingEvent(1) '1
                    '    currentBlock2(QuestionListBox.SelectedIndex + 1, 9) = doingEvent(2) '2
                    '    winNumber = doingEvent(3) '3
                    '    MoneyTakenCheckBox.Checked = doingEvent(4) '4
                    '    QuestionNumberNumericUpDown.Value = doingEvent(5) '5
                    '    activ50 = doingEvent(6) '6
                    '    activPAF = doingEvent(7) '7
                    '    activATA = doingEvent(8) '8
                    '    HostFrameCheckBox.Checked = doingEvent(9) '9
                    '    PlayerFrameCheckBox.Checked = doingEvent(10) '10
                    '    HostVisibleCheckBox.Checked = doingEvent(11) '11
                    '    PlayerVisibleCheckBox.Checked = doingEvent(12) '12
                    '    commentShow = doingEvent(13) '13
                    '    splashOn = doingEvent(14) '14
                    '    HostScreenXNumericUpDown.Value = doingEvent(15) '15
                    '    HostScreenYNumericUpDown.Value = doingEvent(16) '16
                    '    PlayerScreenXNumericUpDown.Value = doingEvent(17) '17
                    '    PlayerScreenYNumericUpDown.Value = doingEvent(18) '18


            End Select
        End If
        doingEvent = Nothing
    End Sub

    Private Sub Client_Disconnected(sender As Object, e As EventArgs) Handles Client.Disconnected
        'При отключении соединения
        My.Computer.Audio.Play("source\MUSIC\Timp Hit.wav", AudioPlayMode.Background)
        If Me.WindowState <> FormWindowState.Normal Then Me.WindowState = FormWindowState.Normal
        ConnectButton.Text = currentBlock1(33, 3) 'Connect
        ConnectButton.BackColor = Color.Orange
    End Sub
End Class

'Синхронизация
'doingEvent:
' 0 - @sync
' 1 - numberRightAnswer
' 2 - currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
' 3 - winNumber
' 4 - MoneyTakenCheckBox.Checked
' 5 - QuestionNumberNumericUpDown.Value
' 6 - activ50
' 7 - activPAF
' 8 - activATA
' 9 - HostFrameCheckBox.Checked
'10 - PlayerFrameCheckBox.Checked
'11 - HostVisibleCheckBox.Checked
'12 - PlayerVisibleCheckBox.Checked
'13 - commentShow
'14 - splashOn
'15 - HostScreenXNumericUpDown.Value
'16 - HostScreenYNumericUpDown.Value
'17 - PlayerScreenXNumericUpDown.Value
'18 - PlayerScreenYNumericUpDown.Value

'19 - FormPAF.clockFrame
'20 - Host.ClockPictureBox.ImageLocation
'21 - Player.ClockPictureBox.ImageLocation
'22 - Host.ClockPictureBox.Visible
'23 - Player.ClockPictureBox.Visible

'24 - Host.AnswerAPercentLabel.Text
'25 - Host.AnswerBPercentLabel.Text
'26 - Host.AnswerCPercentLabel.Text
'27 - Host.AnswerDPercentLabel.Text
'28 - Host.AnswerAPercentLabel.Visible
'29 - Host.AnswerBPercentLabel.Visible
'30 - Host.AnswerCPercentLabel.Visible
'31 - Host.AnswerDPercentLabel.Visible
'32 - Host.AnswerAChartPictureBox.Visible
'33 - Host.AnswerBChartPictureBox.Visible
'34 - Host.AnswerCChartPictureBox.Visible
'35 - Host.AnswerDChartPictureBox.Visible
'36 - Host.AnswerAChartPictureBox.Height
'37 - Host.AnswerBChartPictureBox.Height
'38 - Host.AnswerCChartPictureBox.Height
'39 - Host.AnswerDChartPictureBox.Height
'40 - Host.AnswerAChartPictureBox.Top
'41 - Host.AnswerBChartPictureBox.Top
'42 - Host.AnswerCChartPictureBox.Top
'43 - Host.AnswerDChartPictureBox.Top
'44 - Player.AnswerAPercentLabel.Text
'45 - Player.AnswerBPercentLabel.Text
'46 - Player.AnswerCPercentLabel.Text
'47 - Player.AnswerDPercentLabel.Text
'48 - Player.AnswerAPercentLabel.Visible
'49 - Player.AnswerBPercentLabel.Visible
'50 - Player.AnswerCPercentLabel.Visible
'51 - Player.AnswerDPercentLabel.Visible
'52 - Player.AnswerAChartPictureBox.Visible
'53 - Player.AnswerBChartPictureBox.Visible
'54 - Player.AnswerCChartPictureBox.Visible
'55 - Player.AnswerDChartPictureBox.Visible
'56 - Player.AnswerAChartPictureBox.Height
'57 - Player.AnswerBChartPictureBox.Height
'58 - Player.AnswerCChartPictureBox.Height
'59 - Player.AnswerDChartPictureBox.Height
'60 - Player.AnswerAChartPictureBox.Top
'61 - Player.AnswerBChartPictureBox.Top
'62 - Player.AnswerCChartPictureBox.Top
'63 - Player.AnswerDChartPictureBox.Top

'64 - Host.BackgroundImage
'65 - Host.BackgroundImage
'66 - Host.AnswerAFramePictureBox.BackgroundImage
'67 - Host.AnswerBFramePictureBox.BackgroundImage
'68 - Host.AnswerCFramePictureBox.BackgroundImage
'69 - Host.AnswerDFramePictureBox.BackgroundImage
'70 - Host.MoneyTreePictureBox.BackgroundImage
'71 - Host.LifelinesPictureBox.BackgroundImage
'72 - Host.QuestionTextLabel.Text
'73 - Host.AnswerATextLabel.Text
'74 - Host.AnswerBTextLabel.Text
'75 - Host.AnswerCTextLabel.Text
'76 - Host.AnswerDTextLabel.Text
'77 - Host.QuestionsLeftLabel.Text
'78 - Host.PossibleWinLabel.Text
'79 - Host.CurrentWinLabel.Text
'80 - Host.PossibleLossLabel.Text
'81 - Host.FinalAnswerLetterLabel.Text
'82 - Host.GuaranteedSumLabel.Text
'83 - Host.QuestionCommentLabel.Text
'84 - Host.HostMessageLabel.Text
'85 - Host.LogoPictureBox.Visible

'86 - Player.BackgroundImage
'87 - Player.AnswerAFramePictureBox.BackgroundImage
'88 - Player.AnswerBFramePictureBox.BackgroundImage
'89 - Player.AnswerCFramePictureBox.BackgroundImage
'90 - Player.AnswerDFramePictureBox.BackgroundImage
'91 - Player.MoneyTreePictureBox.BackgroundImage
'92 - Player.LifelinesPictureBox.BackgroundImage
'93 - Player.QuestionTextLabel.Text
'94 - Player.AnswerATextLabel.Text
'95 - Player.AnswerBTextLabel.Text
'96 - Player.AnswerCTextLabel.Text
'97 - Player.AnswerDTextLabel.Text
'98 - Player.WinnerNameLabel.Text
'99 - Player.MoneyWonPictureBox.BackgroundImage
'100 - Player.PrizePictureBox.BackgroundImage
'101 - Player.LogoPictureBox.Visible

'"@sync|questionText|textAnswerA|textAnswerB|textAnswerC|textAnswerD|numberRightAnswer|currentBlock2(QuestionListBox.SelectedIndex + 1, 9)|winNumber|MoneyTakenCheckBox.Checked|QuestionNumberNumericUpDown.Value|activ50|activPAF|activATA|HostFrameCheckBox.Checked|PlayerFrameCheckBox.Checked|HostVisibleCheckBox.Checked|PlayerVisibleCheckBox.Checked|commentShow|splashOn|HostScreenXNumericUpDown.Value|HostScreenYNumericUpDown.Value|PlayerScreenXNumericUpDown.Value|PlayerScreenYNumericUpDown.Value|FormPAF.clockFrame|Host.ClockPictureBox.ImageLocation|Player.ClockPictureBox.ImageLocation|Host.ClockPictureBox.Visible|Player.ClockPictureBox.Visible|Host.AnswerAPercentLabel.Text|Host.AnswerBPercentLabel.Text|Host.AnswerCPercentLabel.Text|Host.AnswerDPercentLabel.Text|Host.AnswerAPercentLabel.Visible|Host.AnswerBPercentLabel.Visible|Host.AnswerCPercentLabel.Visible|Host.AnswerDPercentLabel.Visible|Host.AnswerAChartPictureBox.Visible|Host.AnswerBChartPictureBox.Visible|Host.AnswerCChartPictureBox.Visible|Host.AnswerDChartPictureBox.Visible|Host.AnswerAChartPictureBox.Height|Host.AnswerBChartPictureBox.Height|Host.AnswerCChartPictureBox.Height|Host.AnswerDChartPictureBox.Height|Host.AnswerAChartPictureBox.Top|Host.AnswerBChartPictureBox.Top|Host.AnswerCChartPictureBox.Top|Host.AnswerDChartPictureBox.Top|Player.AnswerAPercentLabel.Text|Player.AnswerBPercentLabel.Text|Player.AnswerCPercentLabel.Text|Player.AnswerDPercentLabel.Text|Player.AnswerAPercentLabel.Visible|Player.AnswerBPercentLabel.Visible|Player.AnswerCPercentLabel.Visible|Player.AnswerDPercentLabel.Visible|Player.AnswerAChartPictureBox.Visible|Player.AnswerBChartPictureBox.Visible|Player.AnswerCChartPictureBox.Visible|Player.AnswerDChartPictureBox.Visible|Player.AnswerAChartPictureBox.Height|Player.AnswerBChartPictureBox.Height|Player.AnswerCChartPictureBox.Height|Player.AnswerDChartPictureBox.Height|Player.AnswerAChartPictureBox.Top|Player.AnswerBChartPictureBox.Top|Player.AnswerCChartPictureBox.Top|Player.AnswerDChartPictureBox.Top|Host.BackgroundImage|Host.AnswerAFramePictureBox.BackgroundImage|Host.AnswerBFramePictureBox.BackgroundImage|Host.AnswerCFramePictureBox.BackgroundImage|Host.AnswerDFramePictureBox.BackgroundImage|Host.MoneyTreePictureBox.BackgroundImage|Host.LifelinesPictureBox.BackgroundImage|Host.QuestionTextLabel.Text|Host.AnswerATextLabel.Text|Host.AnswerBTextLabel.Text|Host.AnswerCTextLabel.Text|Host.AnswerDTextLabel.Text|Host.QuestionsLeftLabel.Text|Host.PossibleWinLabel.Text|Host.CurrentWinLabel.Text|Host.PossibleLossLabel.Text|Host.FinalAnswerLetterLabel.Text|Host.GuaranteedSumLabel.Text|Host.QuestionCommentLabel.Text|Host.HostMessageLabel.Text|Host.LogoPictureBox.Visible|Player.BackgroundImage|Player.AnswerAFramePictureBox.BackgroundImage|Player.AnswerBFramePictureBox.BackgroundImage|Player.AnswerCFramePictureBox.BackgroundImage|Player.AnswerDFramePictureBox.BackgroundImage|Player.MoneyTreePictureBox.BackgroundImage|Player.LifelinesPictureBox.BackgroundImage|Player.QuestionTextLabel.Text|Player.AnswerATextLabel.Text|Player.AnswerBTextLabel.Text|Player.AnswerCTextLabel.Text|Player.AnswerDTextLabel.Text|Player.WinnerNameLabel.Text|Player.MoneyWonPictureBox.BackgroundImage|Player.PrizePictureBox.BackgroundImage|Player.LogoPictureBox.Visible|"

'Case "@connect_success" 'При успешном соединении
'Case "@button1" 'Ask It                                                                                                 questionText & Str(numberRightAnswer) & questionNumber
'Case "@button2" 'Enable A                                                                                                                                          textAnswerA
'Case "@button3" 'Enable B                                                                                                                                          textAnswerB
'Case "@button4" 'Enable C                                                                                                                                          textAnswerC
'Case "@button5" 'Enable D                                                                                                                                          textAnswerD
'Case "@button6" 'Enable All                                                           questionText & textAnswerA & textAnswerB & textAnswerC & textAnswerD & numberRightAnswer
'Case "@button8", "@button9", "@button10", "@button11" 'Receive A, B, C, D                                                         currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
'Case "@button12" 'What's correct                                                                                                                            MoneyTakenCheckBox.Checked
'Case "@millionaire" '@button12 + winNumber=15                                                                                                                   ContestantNameTextBox.Text
'Case "@button13" 'Lx                                                                                                                                      QuestionNumberNumericUpDown.Value
'Case "@button25" 'Lifeline Explanations                                                                                              activ50 & activPAF & activATA & winNumber
'Case "@button26", "@button27", "@button28" 'Lifelines Pings                                                                                      activ50 & activPAF & activATA
'Case "@button30" 'Start the game                                                                                                                    questionNumber & winNumber
'Case "@button33" 'Goodbye Punter                                                                                                                                           ---
'Case "@numericupdown1" 'Смена номера вопроса                                                                                                              QuestionNumberNumericUpDown.Value
'Case "@button24" 'Clear forms                                                                                                                                              ---
'Case "@button20" 'Take a money                                                                                                                              MoneyTakenCheckBox.Checked
'Case "@lifelines_state", "@button17", "@button15", "@button18" '50-50, PAF or ATA state changed                                                  activ50 & activPAF & activATA
'Case "@checkbox4" 'Host frame                                                                                                                                HostFrameCheckBox.Checked
'Case "@checkbox5" 'Player frame state                                                                                                                        PlayerFrameCheckBox.Checked
'Case "@checkbox7" 'Host window visibility                                                                                                                    HostVisibleCheckBox.Checked
'Case "@checkbox8" 'Player window visibility                                                                                                                  PlayerVisibleCheckBox.Checked
'Case "@button44" 'Send (message)                                                                                                                                HostMessageTextBox.Text
'Case "@button45" 'Clear (message)                                                                                                                                          ---
'Case "@button14" 'Show hint                                                                                         commentShow & currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
'Case "@button16" 'Show logo                                                                                                                                           splashOn
'Case "@numericupdown2" 'Host window location                                                                                       HostScreenXNumericUpDown.Value & HostScreenYNumericUpDown.Value
'Case "@numericupdown4" 'Player window location                                                                                     PlayerScreenXNumericUpDown.Value & PlayerScreenYNumericUpDown.Value
'Case "@button42", "@button43", "@button52", "@button51", "@button50", "@button49" 'Tree Up or Tree Down                                                              winNumber
'Case "@50-50_button1" '50:50 AskQuestionButton                                                                                 AnswerATextLabel.Text & AnswerBTextLabel.Text & AnswerCTextLabel.Text & AnswerDTextLabel.Text
'Case "@paf_button1" 'PAF AskQuestionButton                                                                                                                                           ---
'Case "@paf_button2" 'PAF EnableAnswerAButton                                                                                                                                           ---
'Case "@paf_button3" 'PAF EnableAnswerBButton                                                                                                                                           ---
'Case "@paf_closed" 'PAF closed                                                                                                                                             ---
'Case "@ata_button2" 'ATA EnableAnswerAButton                                                                                                                                           ---
'Case "@ata_button3" 'ATA EnableAnswerBButton                              FormATA.percentsA & FormATA.percentsB & FormATA.percentsC & FormATA.percentsD & FormATA.AnswerAPercentNumericUpDown.Value & _ 
'                                                                 & FormATA.AnswerBPercentNumericUpDown.Value & FormATA.AnswerCPercentNumericUpDown.Value & FormATA.AnswerDPercentNumericUpDown.Value & HostMessageTextBox.Text
'Case "@ata_closed" 'ATA closed                                                                                                                                             ---