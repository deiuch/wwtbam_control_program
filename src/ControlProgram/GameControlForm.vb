Public Class GameControlForm
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
    Public sourcePath As String 'Путь ресурсной папки
    Public langSource As String 'Путь ресурсов локализации
    Public winampOn As Integer 'Включена ли фоновая музыка
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
        AudienceScreenForm.FffAnswer1Label.Visible = False
        AudienceScreenForm.FffResultName5Label.Visible = False
        AudienceScreenForm.FffResultTime5Label.Visible = False
        HostScreenXNumericUpDown.Value = StartForm.HostScreenXNumericUpDown.Value
        HostScreenYNumericUpDown.Value = StartForm.HostScreenYNumericUpDown.Value
        PlayerScreenXNumericUpDown.Value = StartForm.PlayerScreenXNumericUpDown.Value
        PlayerScreenYNumericUpDown.Value = StartForm.PlayerScreenYNumericUpDown.Value
        AudienceScreenXNumericUpDown.Value = StartForm.AudienceScreenXNumericUpDown.Value
        AudienceScreenYNumericUpDown.Value = StartForm.AudienceScreenYNumericUpDown.Value
        Me.MaximizeBox = False
        HostScreenForm.Show()
        PlayerScreenForm.Show()
        AudienceScreenForm.Show()
        If StartForm.HostScreenCheckBox.Checked = False Then
            HostScreenForm.Hide()
            HostVisibleCheckBox.Checked = False
        End If
        If StartForm.PlayerScreenCheckBox.Checked = False Then
            PlayerScreenForm.Hide()
            PlayerVisibleCheckBox.Checked = False
        End If
        If StartForm.AudienceScreenCheckBox.Checked = False Then
            AudienceScreenForm.Hide()
            AudienceVisibleCheckBox.Checked = False
        End If
        HostScreenForm.Location = New Point(HostScreenXNumericUpDown.Value, HostScreenYNumericUpDown.Value)
        PlayerScreenForm.Location = New Point(PlayerScreenXNumericUpDown.Value, PlayerScreenYNumericUpDown.Value)
        AudienceScreenForm.Location = New Point(AudienceScreenXNumericUpDown.Value, AudienceScreenYNumericUpDown.Value)
        StartForm.Close()
        HostScreenForm.LogoPictureBox.Size = New System.Drawing.Size(1024, 768)
        PlayerScreenForm.LogoPictureBox.Size = New System.Drawing.Size(1024, 768)
        AudienceScreenForm.LogoPictureBox.Size = New System.Drawing.Size(1024, 768)
        sourcePath = CurDir() & "\Source" 'Задание пути ресурсной папки
        langSource = CurDir() & currentBlock1(3, 3)
        ServerIpTextBox.Text = ini(12)
        ServerPortTextBox.Text = ini(13)
        'Подсвечивание кнопок-подсказок
        ToggleLogoButton.BackColor = Color.FromArgb(255, 128, 128)
        OpeningTitlesButton.BackColor = Color.FromArgb(255, 128, 128)
        ClearFormsButton.BackColor = Color.FromArgb(255, 128, 128)
        StartTheGameButton.BackColor = Color.Green
        'Перевод "B" GameControlForm
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
        HostScreenForm.LogoPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LOGO_FEEL.png")
        PlayerScreenForm.LogoPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LOGO_FEEL.png")
        AudienceScreenForm.LogoPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LOGO_FEEL.png")
        HostScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\BG4.jpg")
        AudienceScreenForm.QuestionFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile("source\QUESTION.png")
        QuestionFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile("source\QUESTION.png")
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_0.png"
        HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_0.png"
        PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_0.png"
        AudienceScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_0.png"
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\000.png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\000.png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\000.png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\000.png"
        HostScreenForm.AnswerAChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        HostScreenForm.AnswerBChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        HostScreenForm.AnswerCChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        HostScreenForm.AnswerDChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        PlayerScreenForm.AnswerAChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        PlayerScreenForm.AnswerBChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        PlayerScreenForm.AnswerCChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        PlayerScreenForm.AnswerDChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        AudienceScreenForm.AnswerAChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        AudienceScreenForm.AnswerBChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        AudienceScreenForm.AnswerCChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        AudienceScreenForm.AnswerDChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        'Смена шрифта
        QuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        AnswerATextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AnswerBTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AnswerCTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AnswerDTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        HostScreenForm.QuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        HostScreenForm.AnswerATextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        HostScreenForm.AnswerBTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        HostScreenForm.AnswerCTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        HostScreenForm.AnswerDTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        PlayerScreenForm.QuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        PlayerScreenForm.AnswerATextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        PlayerScreenForm.AnswerBTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        PlayerScreenForm.AnswerCTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        PlayerScreenForm.AnswerDTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AudienceScreenForm.FffQuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        AudienceScreenForm.FffAnswer1Label.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AudienceScreenForm.FffAnswer2Label.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AudienceScreenForm.FffAnswer3Label.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AudienceScreenForm.FffAnswer4Label.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AudienceScreenForm.QuestionTextLabel.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        AudienceScreenForm.AnswerATextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AudienceScreenForm.AnswerBTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AudienceScreenForm.AnswerCTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        AudienceScreenForm.AnswerDTextLabel.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        'ATA
        HostScreenForm.AnswerAPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        HostScreenForm.AnswerBPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        HostScreenForm.AnswerCPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        HostScreenForm.AnswerDPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        PlayerScreenForm.AnswerAPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        PlayerScreenForm.AnswerBPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        PlayerScreenForm.AnswerCPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        PlayerScreenForm.AnswerDPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        AudienceScreenForm.AnswerAPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        AudienceScreenForm.AnswerBPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        AudienceScreenForm.AnswerCPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        AudienceScreenForm.AnswerDPercentLabel.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
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
        HostScreenForm.FinalAnswerLetterLabel.Text = ""
        HostScreenForm.QuestionCommentLabel.Text = ""
        commentShow = False
        If HostMessageTextBox.Text.StartsWith("-A:") And HostMessageTextBox.Text.EndsWith("%") Then
            ClearHostMessageButton.PerformClick()
        End If
        Select Case questionNumber
            Case 0 To 5
                'Включение фоновой музыки
                If winampOn <> 1 Or questionNumber = 0 Then
                    BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q1-5 Bed Loop.wav")
                    winampOn = 1
                End If
            Case 6
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q6 - Heartbeat Loop.wav")
                winampOn = 1
            Case 7
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q7 - Heartbeat Loop.wav")
                winampOn = 1
            Case 8
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q8 - Heartbeat Loop.wav")
                winampOn = 1
            Case 9
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q9 - Heartbeat Loop.wav")
                winampOn = 1
            Case 10
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q10 - Heartbeat Loop.wav")
                winampOn = 1
            Case 11
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q11 - Heartbeat Loop.wav")
                winampOn = 1
            Case 12
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q12 - Heartbeat Loop.wav")
                winampOn = 1
            Case 13
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q13 - Heartbeat Loop.wav")
                winampOn = 1
            Case 14
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q14 - Heartbeat Loop.wav")
                winampOn = 1
            Case 15
                BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Q15 - Heartbeat (R1 000 000) Loop.wav")
                winampOn = 1
        End Select
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ask_question|" & questionText & "|" & Str(numberRightAnswer) & "|" & questionNumber & "|"
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
        SoundCues.Stop()
    End Sub

    Private Sub LightsDownButton_Click(sender As Object, e As EventArgs) Handles LightsDownButton.Click
        'Lights down (LX), clear forms
        TakeTheMoneyButton.BackColor = Color.White
        MoneyWonRevealTimer.Stop()
        PlayerScreenForm.MoneyWonPictureBox.Visible = False
        AudienceScreenForm.MoneyWonPictureBox.Visible = False
        QuestionTextLabel.Text = ""
        AnswerATextLabel.Text = ""
        AnswerBTextLabel.Text = ""
        AnswerCTextLabel.Text = ""
        AnswerDTextLabel.Text = ""
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        PlayerScreenForm.QuestionTextLabel.Visible = True
        PlayerScreenForm.AnswerATextLabel.Visible = True
        PlayerScreenForm.AnswerBTextLabel.Visible = True
        PlayerScreenForm.AnswerCTextLabel.Visible = True
        PlayerScreenForm.AnswerDTextLabel.Visible = True
        PlayerScreenForm.AnswerAFramePictureBox.Visible = True
        PlayerScreenForm.AnswerBFramePictureBox.Visible = True
        PlayerScreenForm.AnswerCFramePictureBox.Visible = True
        PlayerScreenForm.AnswerDFramePictureBox.Visible = True
        PlayerScreenForm.PrizePictureBox.Visible = False
        PlayerScreenForm.WinnerNameLabel.Visible = False
        PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        AudienceScreenForm.QuestionTextLabel.Visible = True
        AudienceScreenForm.AnswerATextLabel.Visible = True
        AudienceScreenForm.AnswerBTextLabel.Visible = True
        AudienceScreenForm.AnswerCTextLabel.Visible = True
        AudienceScreenForm.AnswerDTextLabel.Visible = True
        AudienceScreenForm.QuestionFramePictureBox.Visible = True
        AudienceScreenForm.AnswerAFramePictureBox.Visible = True
        AudienceScreenForm.AnswerBFramePictureBox.Visible = True
        AudienceScreenForm.AnswerCFramePictureBox.Visible = True
        AudienceScreenForm.AnswerDFramePictureBox.Visible = True
        AudienceScreenForm.PrizePictureBox.Visible = False
        AudienceScreenForm.WinnerNameLabel.Visible = False
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
                BackgroundMusic.Stop()
                winampOn = 0
                SoundCues.Play("\MUSIC\Let's See Q1.wav")
            Case 5, 10, 15
                BackgroundMusic.PlayOnce(sourcePath & "\MUSIC\Q10 - Lx.wav")
                winampOn = 1
            Case 6, 11
                BackgroundMusic.PlayOnce(sourcePath & "\MUSIC\Q6 - Lx.wav")
                winampOn = 1
            Case 7, 12
                BackgroundMusic.PlayOnce(sourcePath & "\MUSIC\Q7-12 - Lx.wav")
                winampOn = 1
            Case 8, 13
                BackgroundMusic.PlayOnce(sourcePath & "\MUSIC\Q8-13 - Lx.wav")
                winampOn = 1
            Case 9, 14
                BackgroundMusic.PlayOnce(sourcePath & "\MUSIC\Q9-14 - Lx.wav")
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
                .Command = "@lights_down|" & QuestionNumberNumericUpDown.Value & "|"
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
                HostScreenForm.FinalAnswerLetterLabel.Text = "A"
            Case 2
                HostScreenForm.FinalAnswerLetterLabel.Text = "B"
            Case 3
                HostScreenForm.FinalAnswerLetterLabel.Text = "C"
            Case 4
                HostScreenForm.FinalAnswerLetterLabel.Text = "D"
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
        HostScreenForm.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            BackgroundMusic.Stop()
            winampOn = 0
        End If
        If MoneyTakenCheckBox.Checked = False Then
            Select Case questionNumber
                Case 6, 11
                    SoundCues.Play("source\MUSIC\Q6-11 -  Are you sure.wav")
                Case 7, 12
                    SoundCues.Play("source\MUSIC\Q7-12 - Are you sure.wav")
                Case 8, 13
                    SoundCues.Play("source\MUSIC\Q8-13 - Are you sure.wav")
                Case 9, 14
                    SoundCues.Play("source\MUSIC\Q9-14 - Are you sure.wav")
                Case 10, 15
                    SoundCues.Play("source\MUSIC\Q10-15 - Are you sure.wav")
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
                .Command = "@receive_answer_a|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
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
                HostScreenForm.FinalAnswerLetterLabel.Text = "A"
            Case 2
                HostScreenForm.FinalAnswerLetterLabel.Text = "B"
            Case 3
                HostScreenForm.FinalAnswerLetterLabel.Text = "C"
            Case 4
                HostScreenForm.FinalAnswerLetterLabel.Text = "D"
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
        HostScreenForm.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            BackgroundMusic.Stop()
            winampOn = 0
        End If
        If MoneyTakenCheckBox.Checked = False Then
            Select Case questionNumber
                Case 6, 11
                    SoundCues.Play("source\MUSIC\Q6-11 -  Are you sure.wav")
                Case 7, 12
                    SoundCues.Play("source\MUSIC\Q7-12 - Are you sure.wav")
                Case 8, 13
                    SoundCues.Play("source\MUSIC\Q8-13 - Are you sure.wav")
                Case 9, 14
                    SoundCues.Play("source\MUSIC\Q9-14 - Are you sure.wav")
                Case 10, 15
                    SoundCues.Play("source\MUSIC\Q10-15 - Are you sure.wav")
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
                .Command = "@receive_answer_b|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
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
                HostScreenForm.FinalAnswerLetterLabel.Text = "A"
            Case 2
                HostScreenForm.FinalAnswerLetterLabel.Text = "B"
            Case 3
                HostScreenForm.FinalAnswerLetterLabel.Text = "C"
            Case 4
                HostScreenForm.FinalAnswerLetterLabel.Text = "D"
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
        HostScreenForm.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            BackgroundMusic.Stop()
            winampOn = 0
        End If
        If MoneyTakenCheckBox.Checked = False Then
            Select Case questionNumber
                Case 6, 11
                    SoundCues.Play("source\MUSIC\Q6-11 -  Are you sure.wav")
                Case 7, 12
                    SoundCues.Play("source\MUSIC\Q7-12 - Are you sure.wav")
                Case 8, 13
                    SoundCues.Play("source\MUSIC\Q8-13 - Are you sure.wav")
                Case 9, 14
                    SoundCues.Play("source\MUSIC\Q9-14 - Are you sure.wav")
                Case 10, 15
                    SoundCues.Play("source\MUSIC\Q10-15 - Are you sure.wav")
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
                .Command = "@receive_answer_c|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
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
                HostScreenForm.FinalAnswerLetterLabel.Text = "A"
            Case 2
                HostScreenForm.FinalAnswerLetterLabel.Text = "B"
            Case 3
                HostScreenForm.FinalAnswerLetterLabel.Text = "C"
            Case 4
                HostScreenForm.FinalAnswerLetterLabel.Text = "D"
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
        HostScreenForm.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            BackgroundMusic.Stop()
            winampOn = 0
        End If
        If MoneyTakenCheckBox.Checked = False Then
            Select Case questionNumber
                Case 6, 11
                    SoundCues.Play("source\MUSIC\Q6-11 -  Are you sure.wav")
                Case 7, 12
                    SoundCues.Play("source\MUSIC\Q7-12 - Are you sure.wav")
                Case 8, 13
                    SoundCues.Play("source\MUSIC\Q8-13 - Are you sure.wav")
                Case 9, 14
                    SoundCues.Play("source\MUSIC\Q9-14 - Are you sure.wav")
                Case 10, 15
                    SoundCues.Play("source\MUSIC\Q10-15 - Are you sure.wav")
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
                .Command = "@receive_answer_d|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
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
        HostScreenForm.QuestionsLeftLabel.Text = "Qaway:" & Str(15 - questionNumber)
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
                        SoundCues.Play("source\MUSIC\Q1-5 - Yes.wav")
                        winNumber = 0
                        HostScreenForm.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                        HostScreenForm.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                        HostScreenForm.PossibleLossLabel.Text = "0" 'Возможная потеря
                        HostScreenForm.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                    Case 1
                        SoundCues.Play("source\MUSIC\Q1-5 - Yes.wav")
                        winNumber = 1
                        HostScreenForm.PossibleWinLabel.Text = "200"
                        HostScreenForm.CurrentWinLabel.Text = "100"
                        HostScreenForm.PossibleLossLabel.Text = "100"
                        HostScreenForm.GuaranteedSumLabel.Text = "0"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    Case 2
                        SoundCues.Play("source\MUSIC\Q1-5 - Yes.wav")
                        winNumber = 2
                        HostScreenForm.PossibleWinLabel.Text = "300"
                        HostScreenForm.CurrentWinLabel.Text = "200"
                        HostScreenForm.PossibleLossLabel.Text = "200"
                        HostScreenForm.GuaranteedSumLabel.Text = "0"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    Case 3
                        SoundCues.Play("source\MUSIC\Q1-5 - Yes.wav")
                        winNumber = 3
                        HostScreenForm.PossibleWinLabel.Text = "500"
                        HostScreenForm.CurrentWinLabel.Text = "200"
                        HostScreenForm.PossibleLossLabel.Text = "200"
                        HostScreenForm.GuaranteedSumLabel.Text = "0"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    Case 4
                        SoundCues.Play("source\MUSIC\Q1-5 - Yes.wav")
                        winNumber = 4
                        HostScreenForm.PossibleWinLabel.Text = "1,000"
                        HostScreenForm.CurrentWinLabel.Text = "500"
                        HostScreenForm.PossibleLossLabel.Text = "500"
                        HostScreenForm.GuaranteedSumLabel.Text = "0"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    Case 5
                        SoundCues.Play("source\MUSIC\R1000 Winner.wav")
                        BackgroundMusic.Stop()
                        winampOn = 0
                        winNumber = 5
                        HostScreenForm.PossibleWinLabel.Text = "2,000"
                        HostScreenForm.CurrentWinLabel.Text = "1,000"
                        HostScreenForm.PossibleLossLabel.Text = "0"
                        HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    Case 6
                        SoundCues.Play("source\MUSIC\Q6 - Yes.wav")
                        winNumber = 6
                        HostScreenForm.PossibleWinLabel.Text = "4,000"
                        HostScreenForm.CurrentWinLabel.Text = "2,000"
                        HostScreenForm.PossibleLossLabel.Text = "1,000"
                        HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    Case 7
                        SoundCues.Play("source\MUSIC\Q7 - Yes.wav")
                        winNumber = 7
                        HostScreenForm.PossibleWinLabel.Text = "8,000"
                        HostScreenForm.CurrentWinLabel.Text = "4,000"
                        HostScreenForm.PossibleLossLabel.Text = "3,000"
                        HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    Case 8
                        SoundCues.Play("source\MUSIC\Q8 - Yes.wav")
                        winNumber = 8
                        HostScreenForm.PossibleWinLabel.Text = "16,000"
                        HostScreenForm.CurrentWinLabel.Text = "8,000"
                        HostScreenForm.PossibleLossLabel.Text = "7,000"
                        HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    Case 9
                        SoundCues.Play("source\MUSIC\Q9 - Yes.wav")
                        winNumber = 9
                        HostScreenForm.PossibleWinLabel.Text = "32,000"
                        HostScreenForm.CurrentWinLabel.Text = "16,000"
                        HostScreenForm.PossibleLossLabel.Text = "15,000"
                        HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    Case 10
                        SoundCues.Play("source\MUSIC\R32000 - Winner.wav")
                        winNumber = 10
                        HostScreenForm.PossibleWinLabel.Text = "64,000"
                        HostScreenForm.CurrentWinLabel.Text = "32,000"
                        HostScreenForm.PossibleLossLabel.Text = "0"
                        HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    Case 11
                        SoundCues.Play("source\MUSIC\Q11 - Yes.wav")
                        winNumber = 11
                        HostScreenForm.PossibleWinLabel.Text = "125,000"
                        HostScreenForm.CurrentWinLabel.Text = "64,000"
                        HostScreenForm.PossibleLossLabel.Text = "32,000"
                        HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    Case 12
                        SoundCues.Play("source\MUSIC\Q12 - Yes.wav")
                        winNumber = 12
                        HostScreenForm.PossibleWinLabel.Text = "250,000"
                        HostScreenForm.CurrentWinLabel.Text = "125,000"
                        HostScreenForm.PossibleLossLabel.Text = "93,000"
                        HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    Case 13
                        SoundCues.Play("source\MUSIC\Q13 - Yes.wav")
                        winNumber = 13
                        HostScreenForm.PossibleWinLabel.Text = "500,000"
                        HostScreenForm.CurrentWinLabel.Text = "250,000"
                        HostScreenForm.PossibleLossLabel.Text = "218,000"
                        HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    Case 14
                        SoundCues.Play("source\MUSIC\Q14 - Yes.wav")
                        winNumber = 14
                        HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                        HostScreenForm.CurrentWinLabel.Text = "500,000"
                        HostScreenForm.PossibleLossLabel.Text = "468,000"
                        HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    Case 15
                        HostScreenForm.QuestionsLeftLabel.Text = "Qaway: 0"
                        SoundCues.Play("source\MUSIC\R1 000 000 - Winner.wav")
                        winNumber = 15
                        HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                        HostScreenForm.CurrentWinLabel.Text = "1,000,000"
                        HostScreenForm.PossibleLossLabel.Text = "0"
                        HostScreenForm.GuaranteedSumLabel.Text = "1,000,000"
                        MoneyWonRevealTimer.Stop()
                        PrizeRevealTimer.Start()
                        PlayerScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\MILLIONAIRE.png")
                        PlayerScreenForm.WinnerNameLabel.Text = ContestantNameTextBox.Text
                        AudienceScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\MILLIONAIRE.png")
                        AudienceScreenForm.WinnerNameLabel.Text = ContestantNameTextBox.Text
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
                        SoundCues.Play("source\MUSIC\Q1-5 - No.wav")
                        BackgroundMusic.Stop()
                        winampOn = 0
                        winNumber = 0
                    Case 6
                        SoundCues.Play("source\MUSIC\Q6 - No.wav")
                        winNumber = 5
                    Case 7
                        SoundCues.Play("source\MUSIC\Q7 - No.wav")
                        winNumber = 5
                    Case 8
                        SoundCues.Play("source\MUSIC\Q8 - No.wav")
                        winNumber = 5
                    Case 9
                        SoundCues.Play("source\MUSIC\Q9 - No.wav")
                        winNumber = 5
                    Case 10
                        SoundCues.Play("source\MUSIC\R32000 - Loser.wav")
                        winNumber = 5
                    Case 11
                        SoundCues.Play("source\MUSIC\Q11 - No.wav")
                        winNumber = 10
                    Case 12
                        SoundCues.Play("source\MUSIC\Q12 - No.wav")
                        winNumber = 10
                    Case 13
                        SoundCues.Play("source\MUSIC\Q13 - No.wav")
                        winNumber = 10
                    Case 14
                        SoundCues.Play("source\MUSIC\Q14 - No.wav")
                        winNumber = 10
                    Case 15
                        SoundCues.Play("source\MUSIC\R1 000 000 - Loser.wav")
                        winNumber = 10
                End Select
                PrizeRevealTimer.Start()
                PlayerScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                AudienceScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
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
                PlayerScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                AudienceScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
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
        HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        AudienceScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                If winNumber = 15 Then
                    .Command = "@millionaire_win|" & ContestantNameTextBox.Text & "|"
                Else
                    .Command = "@reveal_correct_answer|" & MoneyTakenCheckBox.Checked & "|" & winNumber & "|"
                End If
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub MoneyWonRevealTimer_Tick(sender As Object, e As EventArgs) Handles MoneyWonRevealTimer.Tick
        'Таймер показа выигрыша
        PlayerScreenForm.QuestionTextLabel.Visible = False
        PlayerScreenForm.AnswerATextLabel.Visible = False
        PlayerScreenForm.AnswerBTextLabel.Visible = False
        PlayerScreenForm.AnswerCTextLabel.Visible = False
        PlayerScreenForm.AnswerDTextLabel.Visible = False
        PlayerScreenForm.AnswerAFramePictureBox.Visible = False
        PlayerScreenForm.AnswerBFramePictureBox.Visible = False
        PlayerScreenForm.AnswerCFramePictureBox.Visible = False
        PlayerScreenForm.AnswerDFramePictureBox.Visible = False
        PlayerScreenForm.MoneyWonPictureBox.Visible = True
        AudienceScreenForm.QuestionTextLabel.Visible = False
        AudienceScreenForm.AnswerATextLabel.Visible = False
        AudienceScreenForm.AnswerBTextLabel.Visible = False
        AudienceScreenForm.AnswerCTextLabel.Visible = False
        AudienceScreenForm.AnswerDTextLabel.Visible = False
        AudienceScreenForm.QuestionFramePictureBox.Visible = False
        AudienceScreenForm.AnswerAFramePictureBox.Visible = False
        AudienceScreenForm.AnswerBFramePictureBox.Visible = False
        AudienceScreenForm.AnswerCFramePictureBox.Visible = False
        AudienceScreenForm.AnswerDFramePictureBox.Visible = False
        AudienceScreenForm.MoneyWonPictureBox.Visible = True
        PlayerScreenForm.BackgroundImage = Nothing
        RevealCorrectAnswerButton.BackColor = Color.White
        MoneyWonRevealTimer.Stop()
    End Sub

    Private Sub PrizeRevealTimer_Tick(sender As Object, e As EventArgs) Handles PrizeRevealTimer.Tick
        'Таймер панели TPM
        If winNumber = 15 Then
            PlayerScreenForm.WinnerNameLabel.Visible = True
            AudienceScreenForm.WinnerNameLabel.Visible = True
        End If
        PlayerScreenForm.QuestionTextLabel.Visible = False
        PlayerScreenForm.AnswerATextLabel.Visible = False
        PlayerScreenForm.AnswerBTextLabel.Visible = False
        PlayerScreenForm.AnswerCTextLabel.Visible = False
        PlayerScreenForm.AnswerDTextLabel.Visible = False
        PlayerScreenForm.AnswerAFramePictureBox.Visible = False
        PlayerScreenForm.AnswerBFramePictureBox.Visible = False
        PlayerScreenForm.AnswerCFramePictureBox.Visible = False
        PlayerScreenForm.AnswerDFramePictureBox.Visible = False
        PlayerScreenForm.PrizePictureBox.Visible = True
        AudienceScreenForm.QuestionTextLabel.Visible = False
        AudienceScreenForm.AnswerATextLabel.Visible = False
        AudienceScreenForm.AnswerBTextLabel.Visible = False
        AudienceScreenForm.AnswerCTextLabel.Visible = False
        AudienceScreenForm.AnswerDTextLabel.Visible = False
        AudienceScreenForm.QuestionFramePictureBox.Visible = False
        AudienceScreenForm.AnswerAFramePictureBox.Visible = False
        AudienceScreenForm.AnswerBFramePictureBox.Visible = False
        AudienceScreenForm.AnswerCFramePictureBox.Visible = False
        AudienceScreenForm.AnswerDFramePictureBox.Visible = False
        AudienceScreenForm.PrizePictureBox.Visible = True
        PlayerScreenForm.BackgroundImage = Nothing
        RevealCorrectAnswerButton.BackColor = Color.White
        TakeTheMoneyButton.BackColor = Color.Aqua
        PrizeRevealTimer.Stop()
    End Sub

    Private Sub OpeningTitlesButton_Click(sender As Object, e As EventArgs) Handles OpeningTitlesButton.Click
        'Opening Titles
        BackgroundMusic.PlayOnce(sourcePath & "\MUSIC\Millionaire Opening.wav")
        winampOn = 1
        If splashOn = False Then
            ToggleLogoButton.PerformClick()
        End If
        ClearFormsButton.PerformClick()
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@toggle_logo|" & splashOn & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        HostEntranceButton.BackColor = Color.FromArgb(255, 128, 128)
        OpeningTitlesButton.BackColor = Color.White
    End Sub

    Private Sub HostEntranceButton_Click(sender As Object, e As EventArgs) Handles HostEntranceButton.Click
        'HostScreenForm Entrance
        SoundCues.Play(sourcePath & "\MUSIC\Host Entrance #2.wav")
        BackgroundMusic.FadeOut()
        winampOn = 0
        HostEntranceButton.BackColor = Color.White
        LetsPlayButton.BackColor = Color.FromArgb(255, 128, 128)
        FastestFingerFirstButton.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub LetsPlayButton_Click(sender As Object, e As EventArgs) Handles LetsPlayButton.Click
        'Let's Play
        BackgroundMusic.PlayOnce(sourcePath & "\MUSIC\Lets Play.wav")
        winampOn = 1
        SoundCues.Stop()
        QuestionNumberNumericUpDown.Value = 1
        LetsPlayButton.BackColor = Color.White
        LightsToCentreButton.BackColor = Color.FromArgb(255, 128, 128)
        TomorrowsNamesButton.BackColor = Color.White
        FastestFingerFirstButton.BackColor = Color.White
    End Sub

    Private Sub LightsToCentreButton_Click(sender As Object, e As EventArgs) Handles LightsToCentreButton.Click
        'LX To Centre
        SoundCues.Play("source\MUSIC\LX To Centre.wav")
        BackgroundMusic.FadeOut()
        winampOn = 0
        LightsToCentreButton.BackColor = Color.White
        LifelineExplanationsButton.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub LifelineExplanationsButton_Click(sender As Object, e As EventArgs) Handles LifelineExplanationsButton.Click
        'Lifeline Explanations
        If winampOn <> 1 Then
            BackgroundMusic.PlayLoop(sourcePath & "\MUSIC\Lifeline Explanations.wav")
            winampOn = 1
        End If
        LifelineExplanationsButton.BackColor = Color.White
        'Скрытие Splash Screen
        HostScreenForm.LogoPictureBox.Visible = False
        PlayerScreenForm.LogoPictureBox.Visible = False
        AudienceScreenForm.LogoPictureBox.Visible = False
        splashOn = False
        ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
        ToggleLogoButton.BackColor = Color.White
        ClearFormsButton.PerformClick()
        StartTheGameButton.BackColor = Color.Green
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@lifeline_explanations|" & activ50 & "|" & activPAF & "|" & activATA & "|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub FiftyFiftyMusicButton_Click(sender As Object, e As EventArgs) Handles FiftyFiftyMusicButton.Click
        '50:50 Ping
        SoundCues.Play("source\MUSIC\50-50 Ping.wav")
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        LifelinesRefreshTimer.Start()
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@fifty_fifty_music|1|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub PhoneAFriendMusicButton_Click(sender As Object, e As EventArgs) Handles PhoneAFriendMusicButton.Click
        'PAF Ping
        SoundCues.Play("source\MUSIC\Phone a Friend Ping.wav")
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        LifelinesRefreshTimer.Start()
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@phone_a_friend_music|" & activ50 & "|1|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AskTheAudienceMusicButton_Click(sender As Object, e As EventArgs) Handles AskTheAudienceMusicButton.Click
        'ATA Ping
        SoundCues.Play("source\MUSIC\Audience Ping.wav")
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        LifelinesRefreshTimer.Start()
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ask_the_audience_music|" & activ50 & "|" & activPAF & "|1|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub StartTheGameButton_Click(sender As Object, e As EventArgs) Handles StartTheGameButton.Click
        'Start the game
        PlayerScreenForm.MoneyWonPictureBox.Visible = False
        AudienceScreenForm.MoneyWonPictureBox.Visible = False
        If winNumber < 15 Then QuestionNumberNumericUpDown.Value = winNumber + 1 Else QuestionNumberNumericUpDown.Value = 15
        HostScreenForm.QuestionsLeftLabel.Text = "Qaway:" & Str(15 - winNumber)
        If winNumber < 15 Then
            Select Case questionNumber
                Case 0, 1
                    HostScreenForm.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                    HostScreenForm.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                    HostScreenForm.PossibleLossLabel.Text = "0" 'Возможная потеря
                    HostScreenForm.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                Case 2
                    HostScreenForm.PossibleWinLabel.Text = "200"
                    HostScreenForm.CurrentWinLabel.Text = "100"
                    HostScreenForm.PossibleLossLabel.Text = "100"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                Case 3
                    HostScreenForm.PossibleWinLabel.Text = "300"
                    HostScreenForm.CurrentWinLabel.Text = "200"
                    HostScreenForm.PossibleLossLabel.Text = "200"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                Case 4
                    HostScreenForm.PossibleWinLabel.Text = "500"
                    HostScreenForm.CurrentWinLabel.Text = "200"
                    HostScreenForm.PossibleLossLabel.Text = "200"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                Case 5
                    HostScreenForm.PossibleWinLabel.Text = "1,000"
                    HostScreenForm.CurrentWinLabel.Text = "500"
                    HostScreenForm.PossibleLossLabel.Text = "500"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                Case 6
                    HostScreenForm.PossibleWinLabel.Text = "2,000"
                    HostScreenForm.CurrentWinLabel.Text = "1,000"
                    HostScreenForm.PossibleLossLabel.Text = "0"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                Case 7
                    HostScreenForm.PossibleWinLabel.Text = "4,000"
                    HostScreenForm.CurrentWinLabel.Text = "2,000"
                    HostScreenForm.PossibleLossLabel.Text = "1,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                Case 8
                    HostScreenForm.PossibleWinLabel.Text = "8,000"
                    HostScreenForm.CurrentWinLabel.Text = "4,000"
                    HostScreenForm.PossibleLossLabel.Text = "3,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                Case 9
                    HostScreenForm.PossibleWinLabel.Text = "16,000"
                    HostScreenForm.CurrentWinLabel.Text = "8,000"
                    HostScreenForm.PossibleLossLabel.Text = "7,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                Case 10
                    HostScreenForm.PossibleWinLabel.Text = "32,000"
                    HostScreenForm.CurrentWinLabel.Text = "16,000"
                    HostScreenForm.PossibleLossLabel.Text = "15,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                Case 11
                    HostScreenForm.PossibleWinLabel.Text = "64,000"
                    HostScreenForm.CurrentWinLabel.Text = "32,000"
                    HostScreenForm.PossibleLossLabel.Text = "0"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                Case 12
                    HostScreenForm.PossibleWinLabel.Text = "125,000"
                    HostScreenForm.CurrentWinLabel.Text = "64,000"
                    HostScreenForm.PossibleLossLabel.Text = "32,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                Case 13
                    HostScreenForm.PossibleWinLabel.Text = "250,000"
                    HostScreenForm.CurrentWinLabel.Text = "125,000"
                    HostScreenForm.PossibleLossLabel.Text = "93,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                Case 14
                    HostScreenForm.PossibleWinLabel.Text = "500,000"
                    HostScreenForm.CurrentWinLabel.Text = "250,000"
                    HostScreenForm.PossibleLossLabel.Text = "218,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                Case 15
                    HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                    HostScreenForm.CurrentWinLabel.Text = "500,000"
                    HostScreenForm.PossibleLossLabel.Text = "468,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
            End Select
        End If
        HostScreenForm.FinalAnswerLetterLabel.Text = ""
        QuestionTextLabel.Text = ""
        AnswerATextLabel.Text = ""
        AnswerBTextLabel.Text = ""
        AnswerCTextLabel.Text = ""
        AnswerDTextLabel.Text = ""
        PlayerScreenForm.QuestionTextLabel.Visible = True
        PlayerScreenForm.AnswerATextLabel.Visible = True
        PlayerScreenForm.AnswerBTextLabel.Visible = True
        PlayerScreenForm.AnswerCTextLabel.Visible = True
        PlayerScreenForm.AnswerDTextLabel.Visible = True
        PlayerScreenForm.AnswerAFramePictureBox.Visible = True
        PlayerScreenForm.AnswerBFramePictureBox.Visible = True
        PlayerScreenForm.AnswerCFramePictureBox.Visible = True
        PlayerScreenForm.AnswerDFramePictureBox.Visible = True
        PlayerScreenForm.PrizePictureBox.Visible = False
        PlayerScreenForm.WinnerNameLabel.Visible = False
        PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        AudienceScreenForm.QuestionTextLabel.Visible = True
        AudienceScreenForm.AnswerATextLabel.Visible = True
        AudienceScreenForm.AnswerBTextLabel.Visible = True
        AudienceScreenForm.AnswerCTextLabel.Visible = True
        AudienceScreenForm.AnswerDTextLabel.Visible = True
        AudienceScreenForm.QuestionFramePictureBox.Visible = True
        AudienceScreenForm.AnswerAFramePictureBox.Visible = True
        AudienceScreenForm.AnswerBFramePictureBox.Visible = True
        AudienceScreenForm.AnswerCFramePictureBox.Visible = True
        AudienceScreenForm.AnswerDFramePictureBox.Visible = True
        AudienceScreenForm.PrizePictureBox.Visible = False
        AudienceScreenForm.WinnerNameLabel.Visible = False
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
        BackgroundMusic.Stop()
        winampOn = 0
        SoundCues.Play("source\MUSIC\Let's See Q1.wav")
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        AudienceScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        ToggleHintButton.Text = currentBlock1(42, 3) 'Show Hint
        HostScreenForm.QuestionCommentLabel.Text = ""
        commentShow = False
        If HostMessageTextBox.Text.StartsWith("-A:") And HostMessageTextBox.Text.EndsWith("%") Then
            ClearHostMessageButton.PerformClick()
        End If
        MoneyTakenCheckBox.Checked = False
        If HostScreenForm.HostMessageLabel.Text = "Message to host" Then ClearHostMessageButton.PerformClick()
        'Скрытие Splash Screen
        HostScreenForm.LogoPictureBox.Visible = False
        PlayerScreenForm.LogoPictureBox.Visible = False
        AudienceScreenForm.LogoPictureBox.Visible = False
        splashOn = False
        ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
        ToggleLogoButton.BackColor = Color.White
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@start_the_game|" & questionNumber & "|" & winNumber & "|"
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
        BackgroundMusic.Stop()
        winampOn = 0
        SoundCues.Play("source\MUSIC\See you later (End of Part 1).wav")
    End Sub

    Private Sub HelloAgainButton_Click(sender As Object, e As EventArgs) Handles HelloAgainButton.Click
        'Hello Again (P2)
        SoundCues.Play("source\MUSIC\Hello Again (Begin of part 2).wav")
    End Sub

    Private Sub GoodbyePunterButton_Click(sender As Object, e As EventArgs) Handles GoodbyePunterButton.Click
        'Goodbye Punter
        SoundCues.Play("source\MUSIC\Goodbye Punter.wav")
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
                .Command = "@goodbye_punter|"
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
        SoundCues.Play("source\MUSIC\Time's Up.wav")
        BackgroundMusic.Stop()
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
        SoundCues.Play("source\MUSIC\Tomorrows Names.wav")
        If splashOn = False Then ToggleLogoButton.PerformClick()
        'Перекрашивание кнопок-подсказок
        LetsPlayButton.BackColor = Color.White
        TomorrowsNamesButton.BackColor = Color.White
        ClosingTitlesButton.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub ClosingTitlesButton_Click(sender As Object, e As EventArgs) Handles ClosingTitlesButton.Click
        'Closing Titles
        SoundCues.Play("source\MUSIC\Millionaire Closing.wav")
        'Перекрашивание кнопок-подсказок
        ClosingTitlesButton.BackColor = Color.White
    End Sub

    Private Sub StereoTestButton_Click(sender As Object, e As EventArgs) Handles StereoTestButton.Click
        'Stereo Test
        SoundCues.Play("source\MUSIC\Stereo Test.wav")
    End Sub

    Private Sub SmsClockButton_Click(sender As Object, e As EventArgs) Handles SmsClockButton.Click
        'SMS Clock
        SoundCues.Play("source\MUSIC\sms_clock.wav")
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
        QuestionEditorForm.Show()
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
                .Command = "@question_number|" & QuestionNumberNumericUpDown.Value & "|"
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
                .Command = "@enable_answer_a|" & textAnswerA & "|"
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
                .Command = "@enable_answer_b|" & textAnswerB & "|"
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
                .Command = "@enable_answer_c|" & textAnswerC & "|"
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
                .Command = "@enable_answer_d|" & textAnswerD & "|"
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
                .Command = "@enable_all_answers|" & questionText & "|" & textAnswerA & "|" & textAnswerB & "|" & textAnswerC & "|" & textAnswerD & "|" & numberRightAnswer & "|"
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
        BackgroundMusic.Stop()
        winampOn = 0
    End Sub

    Private Sub ClearFormsButton_Click(sender As Object, e As EventArgs) Handles ClearFormsButton.Click
        'Clear forms
        TakeTheMoneyButton.BackColor = Color.White
        ClearFormsButton.BackColor = Color.White
        PlayerScreenForm.MoneyWonPictureBox.Visible = False
        AudienceScreenForm.MoneyWonPictureBox.Visible = False
        HostScreenForm.FinalAnswerLetterLabel.Text = ""
        QuestionTextLabel.Text = ""
        AnswerATextLabel.Text = ""
        AnswerBTextLabel.Text = ""
        AnswerCTextLabel.Text = ""
        AnswerDTextLabel.Text = ""
        PlayerScreenForm.QuestionTextLabel.Visible = True
        PlayerScreenForm.AnswerATextLabel.Visible = True
        PlayerScreenForm.AnswerBTextLabel.Visible = True
        PlayerScreenForm.AnswerCTextLabel.Visible = True
        PlayerScreenForm.AnswerDTextLabel.Visible = True
        PlayerScreenForm.AnswerAFramePictureBox.Visible = True
        PlayerScreenForm.AnswerBFramePictureBox.Visible = True
        PlayerScreenForm.AnswerCFramePictureBox.Visible = True
        PlayerScreenForm.AnswerDFramePictureBox.Visible = True
        PlayerScreenForm.PrizePictureBox.Visible = False
        PlayerScreenForm.WinnerNameLabel.Visible = False
        PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        If FastestFingerFirstButton.BackColor <> Color.Orange Then
            AudienceScreenForm.QuestionTextLabel.Visible = True
            AudienceScreenForm.AnswerATextLabel.Visible = True
            AudienceScreenForm.AnswerBTextLabel.Visible = True
            AudienceScreenForm.AnswerCTextLabel.Visible = True
            AudienceScreenForm.AnswerDTextLabel.Visible = True
            AudienceScreenForm.QuestionFramePictureBox.Visible = True
            AudienceScreenForm.AnswerAFramePictureBox.Visible = True
            AudienceScreenForm.AnswerBFramePictureBox.Visible = True
            AudienceScreenForm.AnswerCFramePictureBox.Visible = True
            AudienceScreenForm.AnswerDFramePictureBox.Visible = True
        End If
        AudienceScreenForm.PrizePictureBox.Visible = False
        AudienceScreenForm.WinnerNameLabel.Visible = False
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
        HostScreenForm.QuestionCommentLabel.Text = ""
        commentShow = False
        If HostMessageTextBox.Text.StartsWith("-A:") And HostMessageTextBox.Text.EndsWith("%") Then
            ClearHostMessageButton.PerformClick()
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@clear_forms|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub TakeTheMoneyButton_Click(sender As Object, e As EventArgs) Handles TakeTheMoneyButton.Click
        'Take a money
        If MoneyTakenCheckBox.Checked = False Then
            BackgroundMusic.FadeOut()
            winampOn = 0
            PrizeRevealTimer.Start()
            If winNumber < 15 Then
                PlayerScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                AudienceScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
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
                    .Command = "@take_the_money_reveal|" & MoneyTakenCheckBox.Checked & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        Else
            PlayerScreenForm.WinnerNameLabel.Visible = False
            PlayerScreenForm.QuestionTextLabel.Visible = True
            PlayerScreenForm.AnswerATextLabel.Visible = True
            PlayerScreenForm.AnswerBTextLabel.Visible = True
            PlayerScreenForm.AnswerCTextLabel.Visible = True
            PlayerScreenForm.AnswerDTextLabel.Visible = True
            PlayerScreenForm.AnswerAFramePictureBox.Visible = True
            PlayerScreenForm.AnswerBFramePictureBox.Visible = True
            PlayerScreenForm.AnswerCFramePictureBox.Visible = True
            PlayerScreenForm.AnswerDFramePictureBox.Visible = True
            PlayerScreenForm.PrizePictureBox.Visible = False
            AudienceScreenForm.WinnerNameLabel.Visible = False
            AudienceScreenForm.QuestionTextLabel.Visible = True
            AudienceScreenForm.AnswerATextLabel.Visible = True
            AudienceScreenForm.AnswerBTextLabel.Visible = True
            AudienceScreenForm.AnswerCTextLabel.Visible = True
            AudienceScreenForm.AnswerDTextLabel.Visible = True
            AudienceScreenForm.QuestionFramePictureBox.Visible = True
            AudienceScreenForm.AnswerAFramePictureBox.Visible = True
            AudienceScreenForm.AnswerBFramePictureBox.Visible = True
            AudienceScreenForm.AnswerCFramePictureBox.Visible = True
            AudienceScreenForm.AnswerDFramePictureBox.Visible = True
            AudienceScreenForm.PrizePictureBox.Visible = False
            PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
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
                    .Command = "@take_the_money_restore|" & MoneyTakenCheckBox.Checked & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        End If
    End Sub

    Private Sub LittleQuitButton_Click(sender As Object, e As EventArgs) Handles LittleQuitButton.Click
        'Little Quitter
        SoundCues.Play("source\MUSIC\Little Quitter.wav")
    End Sub

    Private Sub BigQuitButton_Click(sender As Object, e As EventArgs) Handles BigQuitButton.Click
        'Big Quitter
        SoundCues.Play("source\MUSIC\Big Quitter.wav")
    End Sub

    Private Sub FiftyFiftyAvailableCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles FiftyFiftyAvailableCheckBox.CheckedChanged
        '50-50 state change
        If FiftyFiftyAvailableCheckBox.Checked = True Then
            activ50 = "0"
        Else
            activ50 = "x"
        End If
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
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
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
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
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
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
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        LifelinesRefreshTimer.Stop()
    End Sub

    Private Sub FiftyFiftyButton_Click(sender As Object, e As EventArgs) Handles FiftyFiftyButton.Click
        '50-50 Lifeline
        FiftyFiftyForm.Show()
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@fifty_fifty_used|1|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub PhoneAFriendButton_Click(sender As Object, e As EventArgs) Handles PhoneAFriendButton.Click
        'PAF Lifeline
        PhoneAFriendForm.Show()
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@phone_a_friend_used|" & activ50 & "|1|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AskTheAudienceButton_Click(sender As Object, e As EventArgs) Handles AskTheAudienceButton.Click
        'ATA Lifeline
        AskTheAudienceForm.Show()
        LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ask_the_audience_used|" & activ50 & "|" & activPAF & "|1|"
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
                AudienceScreenForm.LifelinesPanelPictureBox.Left = 1024
                AudienceScreenForm.LifelinesPanelPictureBox.Visible = True
            Case Color.Green
                ToggleLifelinesPanelButton.BackColor = Color.White
                AudienceScreenForm.LifelinesPanelPictureBox.Left = 0
                LifelinesPanelHoldTimer.Stop()
                LifelinesPanelSlideTimer.Start()
        End Select
    End Sub

    'Private Sub LifelinesPanelSlideTimer_Tick(sender As Object, e As EventArgs) Handles LifelinesPanelSlideTimer.Tick
    '    'Анимация панели подсказок
    '    'llPanelTimer = llPanelTimer + 1
    '    If AudienceScreenForm.LifelinesPanelPictureBox.Left < 1025 Then
    '        If AudienceScreenForm.LifelinesPanelPictureBox.Left > 0 Then
    '            AudienceScreenForm.LifelinesPanelPictureBox.Left = AudienceScreenForm.LifelinesPanelPictureBox.Left - timer4_coef
    '            If AudienceScreenForm.LifelinesPanelPictureBox.Left = 0 Then
    '                LifelinesPanelSlideTimer.Stop()
    '                LifelinesPanelHoldTimer.Start()
    '                timer4_coef = timer4_coef * -1
    '            End If
    '            timer4_coef = Math.Ceiling(1 / Math.Sqrt(timer4_coef))
    '        Else
    '            LifelinesPanelSlideTimer.Stop()
    '            AudienceScreenForm.LifelinesPanelPictureBox.Location = New Point(0, 637)
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
            HostScreenForm.FormBorderStyle = FormBorderStyle.Sizable
        Else
            HostScreenForm.FormBorderStyle = FormBorderStyle.None
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@host_frame|" & HostFrameCheckBox.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Public Sub PlayerFrameCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PlayerFrameCheckBox.CheckedChanged
        'Рамка окна игрока
        If PlayerFrameCheckBox.Checked = True Then
            PlayerScreenForm.FormBorderStyle = FormBorderStyle.Sizable
        Else
            PlayerScreenForm.FormBorderStyle = FormBorderStyle.None
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@player_frame|" & PlayerFrameCheckBox.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Public Sub AudienceFrameCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AudienceFrameCheckBox.CheckedChanged
        'Рамка окна зрителей
        If AudienceFrameCheckBox.Checked = True Then
            AudienceScreenForm.FormBorderStyle = FormBorderStyle.Sizable
        Else
            AudienceScreenForm.FormBorderStyle = FormBorderStyle.None
        End If
    End Sub

    Public Sub HostVisibleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles HostVisibleCheckBox.CheckedChanged
        'Видимость окна ведущего
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@host_visible|" & HostVisibleCheckBox.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        Else
            If HostVisibleCheckBox.Checked = True Then
                HostScreenForm.Show()
                Me.Focus()
            Else
                HostScreenForm.Hide()
            End If
        End If
    End Sub

    Public Sub PlayerVisibleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles PlayerVisibleCheckBox.CheckedChanged
        'Видимость окна игрока
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@player_visible|" & PlayerVisibleCheckBox.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        Else
            If PlayerVisibleCheckBox.Checked = True Then
                PlayerScreenForm.Show()
                Me.Focus()
            Else
                PlayerScreenForm.Hide()
            End If
        End If
    End Sub

    Public Sub AudienceVisibleCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles AudienceVisibleCheckBox.CheckedChanged
        'Видимость окна зрителей
        If AudienceVisibleCheckBox.Checked = True Then
            AudienceScreenForm.Show()
            Me.Focus()
        Else
            AudienceScreenForm.Hide()
        End If
    End Sub

    Public Sub AnswerAFramePictureBox_BackgroundImageChanged(sender As Object, e As EventArgs) Handles AnswerAFramePictureBox.BackgroundImageChanged
        'Смена картинки режиссёра и всех остальных
        HostScreenForm.AnswerAFramePictureBox.BackgroundImage = AnswerAFramePictureBox.BackgroundImage
        PlayerScreenForm.AnswerAFramePictureBox.BackgroundImage = AnswerAFramePictureBox.BackgroundImage
        AudienceScreenForm.AnswerAFramePictureBox.BackgroundImage = AnswerAFramePictureBox.BackgroundImage
    End Sub

    Public Sub AnswerBFramePictureBox_BackgroundImageChanged(sender As Object, e As EventArgs) Handles AnswerBFramePictureBox.BackgroundImageChanged
        HostScreenForm.AnswerBFramePictureBox.BackgroundImage = AnswerBFramePictureBox.BackgroundImage
        PlayerScreenForm.AnswerBFramePictureBox.BackgroundImage = AnswerBFramePictureBox.BackgroundImage
        AudienceScreenForm.AnswerBFramePictureBox.BackgroundImage = AnswerBFramePictureBox.BackgroundImage
    End Sub

    Public Sub AnswerCFramePictureBox_BackgroundImageChanged(sender As Object, e As EventArgs) Handles AnswerCFramePictureBox.BackgroundImageChanged
        HostScreenForm.AnswerCFramePictureBox.BackgroundImage = AnswerCFramePictureBox.BackgroundImage
        PlayerScreenForm.AnswerCFramePictureBox.BackgroundImage = AnswerCFramePictureBox.BackgroundImage
        AudienceScreenForm.AnswerCFramePictureBox.BackgroundImage = AnswerCFramePictureBox.BackgroundImage
    End Sub

    Public Sub AnswerDFramePictureBox_BackgroundImageChanged(sender As Object, e As EventArgs) Handles AnswerDFramePictureBox.BackgroundImageChanged
        HostScreenForm.AnswerDFramePictureBox.BackgroundImage = AnswerDFramePictureBox.BackgroundImage
        PlayerScreenForm.AnswerDFramePictureBox.BackgroundImage = AnswerDFramePictureBox.BackgroundImage
        AudienceScreenForm.AnswerDFramePictureBox.BackgroundImage = AnswerDFramePictureBox.BackgroundImage
    End Sub

    Private Sub QuestionTextLabel_TextChanged(sender As Object, e As EventArgs) Handles QuestionTextLabel.TextChanged, AnswerATextLabel.TextChanged, AnswerBTextLabel.TextChanged, AnswerCTextLabel.TextChanged, AnswerDTextLabel.TextChanged
        'Смена текста вопроса и вариантов у режиссёра и всех остальных
        HostScreenForm.QuestionTextLabel.Text = QuestionTextLabel.Text
        PlayerScreenForm.QuestionTextLabel.Text = QuestionTextLabel.Text
        AudienceScreenForm.QuestionTextLabel.Text = QuestionTextLabel.Text
        HostScreenForm.AnswerATextLabel.Text = AnswerATextLabel.Text
        PlayerScreenForm.AnswerATextLabel.Text = AnswerATextLabel.Text
        AudienceScreenForm.AnswerATextLabel.Text = AnswerATextLabel.Text
        HostScreenForm.AnswerBTextLabel.Text = AnswerBTextLabel.Text
        PlayerScreenForm.AnswerBTextLabel.Text = AnswerBTextLabel.Text
        AudienceScreenForm.AnswerBTextLabel.Text = AnswerBTextLabel.Text
        HostScreenForm.AnswerCTextLabel.Text = AnswerCTextLabel.Text
        PlayerScreenForm.AnswerCTextLabel.Text = AnswerCTextLabel.Text
        AudienceScreenForm.AnswerCTextLabel.Text = AnswerCTextLabel.Text
        HostScreenForm.AnswerDTextLabel.Text = AnswerDTextLabel.Text
        PlayerScreenForm.AnswerDTextLabel.Text = AnswerDTextLabel.Text
        AudienceScreenForm.AnswerDTextLabel.Text = AnswerDTextLabel.Text
    End Sub

    Private Sub AnswerATextLabel_BackColorChanged(sender As Object, e As EventArgs) Handles AnswerATextLabel.BackColorChanged, AnswerBTextLabel.BackColorChanged, AnswerCTextLabel.BackColorChanged, AnswerDTextLabel.BackColorChanged
        'Смена фона текста вариантов ответа у всех
        HostScreenForm.AnswerATextLabel.BackColor = AnswerATextLabel.BackColor
        PlayerScreenForm.AnswerATextLabel.BackColor = AnswerATextLabel.BackColor
        AudienceScreenForm.AnswerATextLabel.BackColor = AnswerATextLabel.BackColor
        HostScreenForm.AnswerBTextLabel.BackColor = AnswerBTextLabel.BackColor
        PlayerScreenForm.AnswerBTextLabel.BackColor = AnswerBTextLabel.BackColor
        AudienceScreenForm.AnswerBTextLabel.BackColor = AnswerBTextLabel.BackColor
        HostScreenForm.AnswerCTextLabel.BackColor = AnswerCTextLabel.BackColor
        PlayerScreenForm.AnswerCTextLabel.BackColor = AnswerCTextLabel.BackColor
        AudienceScreenForm.AnswerCTextLabel.BackColor = AnswerCTextLabel.BackColor
        HostScreenForm.AnswerDTextLabel.BackColor = AnswerDTextLabel.BackColor
        PlayerScreenForm.AnswerDTextLabel.BackColor = AnswerDTextLabel.BackColor
        AudienceScreenForm.AnswerDTextLabel.BackColor = AnswerDTextLabel.BackColor
    End Sub

    Private Sub AnswerATextLabel_ForeColorChanged(sender As Object, e As EventArgs) Handles QuestionTextLabel.ForeColorChanged, AnswerATextLabel.ForeColorChanged, AnswerBTextLabel.ForeColorChanged, AnswerCTextLabel.ForeColorChanged, AnswerDTextLabel.ForeColorChanged
        'Смена цвета текста вариантов ответа у всех
        HostScreenForm.QuestionTextLabel.ForeColor = QuestionTextLabel.ForeColor
        PlayerScreenForm.QuestionTextLabel.ForeColor = QuestionTextLabel.ForeColor
        AudienceScreenForm.QuestionTextLabel.ForeColor = QuestionTextLabel.ForeColor
        HostScreenForm.AnswerATextLabel.ForeColor = AnswerATextLabel.ForeColor
        PlayerScreenForm.AnswerATextLabel.ForeColor = AnswerATextLabel.ForeColor
        AudienceScreenForm.AnswerATextLabel.ForeColor = AnswerATextLabel.ForeColor
        HostScreenForm.AnswerBTextLabel.ForeColor = AnswerBTextLabel.ForeColor
        PlayerScreenForm.AnswerBTextLabel.ForeColor = AnswerBTextLabel.ForeColor
        AudienceScreenForm.AnswerBTextLabel.ForeColor = AnswerBTextLabel.ForeColor
        HostScreenForm.AnswerCTextLabel.ForeColor = AnswerCTextLabel.ForeColor
        PlayerScreenForm.AnswerCTextLabel.ForeColor = AnswerCTextLabel.ForeColor
        AudienceScreenForm.AnswerCTextLabel.ForeColor = AnswerCTextLabel.ForeColor
        HostScreenForm.AnswerDTextLabel.ForeColor = AnswerDTextLabel.ForeColor
        PlayerScreenForm.AnswerDTextLabel.ForeColor = AnswerDTextLabel.ForeColor
        AudienceScreenForm.AnswerDTextLabel.ForeColor = AnswerDTextLabel.ForeColor
    End Sub

    Private Sub SendHostMessageButton_Click(sender As Object, e As EventArgs) Handles SendHostMessageButton.Click
        'Отправить сообщение ведущему
        HostScreenForm.HostMessageLabel.Text = HostMessageTextBox.Text
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@send_host_message|" & HostMessageTextBox.Text & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ClearHostMessageButton_Click(sender As Object, e As EventArgs) Handles ClearHostMessageButton.Click
        'Очистить поле сообщения
        HostMessageTextBox.Text = ""
        HostScreenForm.HostMessageLabel.Text = ""
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@clear_host_message|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ToggleHintButton_Click(sender As Object, e As EventArgs) Handles ToggleHintButton.Click
        'Показ комментария к вопросу
        If commentShow = False Then
            ToggleHintButton.BackColor = Color.FromArgb(128, 255, 255)
            ToggleHintButton.Text = currentBlock1(42, 4) 'Hide Hint
            HostScreenForm.QuestionCommentLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
            commentShow = True
        Else
            ToggleHintButton.BackColor = Color.FromArgb(255, 192, 128)
            ToggleHintButton.Text = currentBlock1(42, 3) 'Show Hint
            HostScreenForm.QuestionCommentLabel.Text = ""
            commentShow = False
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@toggle_hint|" & commentShow & "|" & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ToggleLogoButton_Click(sender As Object, e As EventArgs) Handles ToggleLogoButton.Click
        'Показать полноэкранную картинку
        If splashOn = False Then
            HostScreenForm.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
            HostScreenForm.LogoPictureBox.Visible = True
            PlayerScreenForm.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
            PlayerScreenForm.LogoPictureBox.Visible = True
            AudienceScreenForm.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
            AudienceScreenForm.LogoPictureBox.Visible = True
            splashOn = True
            ToggleLogoButton.Text = currentBlock1(45, 4) 'Hide logo
            ToggleLogoButton.BackColor = Color.Violet
        Else
            HostScreenForm.LogoPictureBox.Visible = False
            PlayerScreenForm.LogoPictureBox.Visible = False
            AudienceScreenForm.LogoPictureBox.Visible = False
            splashOn = False
            ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
            ToggleLogoButton.BackColor = Color.White
        End If
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@toggle_logo|" & splashOn & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AboutButton_Click(sender As Object, e As EventArgs) Handles AboutButton.Click
        'Кнопка About
        AboutForm.Show()
    End Sub

    Private Sub HostScreenXNumericUpDown_LostFocus(sender As Object, e As EventArgs) Handles HostScreenXNumericUpDown.LostFocus, HostScreenYNumericUpDown.LostFocus
        HostScreenForm.Location = New Point(HostScreenXNumericUpDown.Value, HostScreenYNumericUpDown.Value)
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@host_window_location|" & HostScreenXNumericUpDown.Value & "|" & HostScreenYNumericUpDown.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub PlayerScreenXNumericUpDown_LostFocus(sender As Object, e As EventArgs) Handles PlayerScreenXNumericUpDown.LostFocus, PlayerScreenYNumericUpDown.LostFocus
        PlayerScreenForm.Location = New Point(PlayerScreenXNumericUpDown.Value, PlayerScreenYNumericUpDown.Value)
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@player_window_location|" & PlayerScreenXNumericUpDown.Value & "|" & PlayerScreenYNumericUpDown.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AudienceScreenXNumericUpDown_LostFocus(sender As Object, e As EventArgs) Handles AudienceScreenXNumericUpDown.LostFocus, AudienceScreenYNumericUpDown.LostFocus
        AudienceScreenForm.Location = New Point(AudienceScreenXNumericUpDown.Value, AudienceScreenYNumericUpDown.Value)
    End Sub

    Private Sub MoneyTreeUpButton_Click(sender As Object, e As EventArgs) Handles MoneyTreeUpButton.Click
        'Tree Up
        If winNumber < 15 Then
            winNumber = winNumber + 1
            Select Case questionNumber
                Case 1
                    HostScreenForm.PossibleWinLabel.Text = "200"
                    HostScreenForm.CurrentWinLabel.Text = "100"
                    HostScreenForm.PossibleLossLabel.Text = "100"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                Case 2
                    HostScreenForm.PossibleWinLabel.Text = "300"
                    HostScreenForm.CurrentWinLabel.Text = "200"
                    HostScreenForm.PossibleLossLabel.Text = "200"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                Case 3
                    HostScreenForm.PossibleWinLabel.Text = "500"
                    HostScreenForm.CurrentWinLabel.Text = "200"
                    HostScreenForm.PossibleLossLabel.Text = "200"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                Case 4
                    HostScreenForm.PossibleWinLabel.Text = "1,000"
                    HostScreenForm.CurrentWinLabel.Text = "500"
                    HostScreenForm.PossibleLossLabel.Text = "500"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                Case 5
                    HostScreenForm.PossibleWinLabel.Text = "2,000"
                    HostScreenForm.CurrentWinLabel.Text = "1,000"
                    HostScreenForm.PossibleLossLabel.Text = "0"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                Case 6
                    HostScreenForm.PossibleWinLabel.Text = "4,000"
                    HostScreenForm.CurrentWinLabel.Text = "2,000"
                    HostScreenForm.PossibleLossLabel.Text = "1,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                Case 7
                    HostScreenForm.PossibleWinLabel.Text = "8,000"
                    HostScreenForm.CurrentWinLabel.Text = "4,000"
                    HostScreenForm.PossibleLossLabel.Text = "3,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                Case 8
                    HostScreenForm.PossibleWinLabel.Text = "16,000"
                    HostScreenForm.CurrentWinLabel.Text = "8,000"
                    HostScreenForm.PossibleLossLabel.Text = "7,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                Case 9
                    HostScreenForm.PossibleWinLabel.Text = "32,000"
                    HostScreenForm.CurrentWinLabel.Text = "16,000"
                    HostScreenForm.PossibleLossLabel.Text = "15,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                Case 10
                    HostScreenForm.PossibleWinLabel.Text = "64,000"
                    HostScreenForm.CurrentWinLabel.Text = "32,000"
                    HostScreenForm.PossibleLossLabel.Text = "0"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                Case 11
                    HostScreenForm.PossibleWinLabel.Text = "125,000"
                    HostScreenForm.CurrentWinLabel.Text = "64,000"
                    HostScreenForm.PossibleLossLabel.Text = "32,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                Case 12
                    HostScreenForm.PossibleWinLabel.Text = "250,000"
                    HostScreenForm.CurrentWinLabel.Text = "125,000"
                    HostScreenForm.PossibleLossLabel.Text = "93,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                Case 13
                    HostScreenForm.PossibleWinLabel.Text = "500,000"
                    HostScreenForm.CurrentWinLabel.Text = "250,000"
                    HostScreenForm.PossibleLossLabel.Text = "218,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                Case 14
                    HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                    HostScreenForm.CurrentWinLabel.Text = "500,000"
                    HostScreenForm.PossibleLossLabel.Text = "468,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                Case 15
                    HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                    HostScreenForm.CurrentWinLabel.Text = "1,000,000"
                    HostScreenForm.PossibleLossLabel.Text = "0"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000,000"
            End Select
            MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            AudienceScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            'Сеть
            If ConnectButton.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@money_tree_up|" & winNumber & "|"
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
                    HostScreenForm.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                    HostScreenForm.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                    HostScreenForm.PossibleLossLabel.Text = "0" 'Возможная потеря
                    HostScreenForm.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                Case 1
                    HostScreenForm.PossibleWinLabel.Text = "200"
                    HostScreenForm.CurrentWinLabel.Text = "100"
                    HostScreenForm.PossibleLossLabel.Text = "100"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                Case 2
                    HostScreenForm.PossibleWinLabel.Text = "300"
                    HostScreenForm.CurrentWinLabel.Text = "200"
                    HostScreenForm.PossibleLossLabel.Text = "200"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                Case 3
                    HostScreenForm.PossibleWinLabel.Text = "500"
                    HostScreenForm.CurrentWinLabel.Text = "200"
                    HostScreenForm.PossibleLossLabel.Text = "200"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                Case 4
                    HostScreenForm.PossibleWinLabel.Text = "1,000"
                    HostScreenForm.CurrentWinLabel.Text = "500"
                    HostScreenForm.PossibleLossLabel.Text = "500"
                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                Case 5
                    HostScreenForm.PossibleWinLabel.Text = "2,000"
                    HostScreenForm.CurrentWinLabel.Text = "1,000"
                    HostScreenForm.PossibleLossLabel.Text = "0"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                Case 6
                    HostScreenForm.PossibleWinLabel.Text = "4,000"
                    HostScreenForm.CurrentWinLabel.Text = "2,000"
                    HostScreenForm.PossibleLossLabel.Text = "1,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                Case 7
                    HostScreenForm.PossibleWinLabel.Text = "8,000"
                    HostScreenForm.CurrentWinLabel.Text = "4,000"
                    HostScreenForm.PossibleLossLabel.Text = "3,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                Case 8
                    HostScreenForm.PossibleWinLabel.Text = "16,000"
                    HostScreenForm.CurrentWinLabel.Text = "8,000"
                    HostScreenForm.PossibleLossLabel.Text = "7,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                Case 9
                    HostScreenForm.PossibleWinLabel.Text = "32,000"
                    HostScreenForm.CurrentWinLabel.Text = "16,000"
                    HostScreenForm.PossibleLossLabel.Text = "15,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                Case 10
                    HostScreenForm.PossibleWinLabel.Text = "64,000"
                    HostScreenForm.CurrentWinLabel.Text = "32,000"
                    HostScreenForm.PossibleLossLabel.Text = "0"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                Case 11
                    HostScreenForm.PossibleWinLabel.Text = "125,000"
                    HostScreenForm.CurrentWinLabel.Text = "64,000"
                    HostScreenForm.PossibleLossLabel.Text = "32,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                Case 12
                    HostScreenForm.PossibleWinLabel.Text = "250,000"
                    HostScreenForm.CurrentWinLabel.Text = "125,000"
                    HostScreenForm.PossibleLossLabel.Text = "93,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                Case 13
                    HostScreenForm.PossibleWinLabel.Text = "500,000"
                    HostScreenForm.CurrentWinLabel.Text = "250,000"
                    HostScreenForm.PossibleLossLabel.Text = "218,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                Case 14
                    HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                    HostScreenForm.CurrentWinLabel.Text = "500,000"
                    HostScreenForm.PossibleLossLabel.Text = "468,000"
                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
            End Select
            MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            AudienceScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            'Сеть
            If ConnectButton.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@money_tree_down|" & winNumber & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        End If
    End Sub

    Private Sub MoneyTreeLevel0Button_Click(sender As Object, e As EventArgs) Handles MoneyTreeLevel0Button.Click
        'Tree 0
        winNumber = 0
        HostScreenForm.PossibleWinLabel.Text = "100"
        HostScreenForm.CurrentWinLabel.Text = "0"
        HostScreenForm.PossibleLossLabel.Text = "0"
        HostScreenForm.GuaranteedSumLabel.Text = "0"
        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        AudienceScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@money_tree_level_0|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub MoneyTreeLevel5Button_Click(sender As Object, e As EventArgs) Handles MoneyTreeLevel5Button.Click
        'Tree 5
        winNumber = 5
        HostScreenForm.PossibleWinLabel.Text = "2,000"
        HostScreenForm.CurrentWinLabel.Text = "1,000"
        HostScreenForm.PossibleLossLabel.Text = "0"
        HostScreenForm.GuaranteedSumLabel.Text = "1,000"
        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        AudienceScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@money_tree_level_5|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub MoneyTreeLevel10Button_Click(sender As Object, e As EventArgs) Handles MoneyTreeLevel10Button.Click
        'Tree 10
        winNumber = 10
        HostScreenForm.PossibleWinLabel.Text = "64,000"
        HostScreenForm.CurrentWinLabel.Text = "32,000"
        HostScreenForm.PossibleLossLabel.Text = "0"
        HostScreenForm.GuaranteedSumLabel.Text = "32,000"
        PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
        AudienceScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        AudienceScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@money_tree_level_10|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub MoneyTreeLevel15Button_Click(sender As Object, e As EventArgs) Handles MoneyTreeLevel15Button.Click
        'Tree 15
        winNumber = 15
        HostScreenForm.PossibleWinLabel.Text = "1,000,000"
        HostScreenForm.CurrentWinLabel.Text = "1,000,000"
        HostScreenForm.PossibleLossLabel.Text = "0"
        HostScreenForm.GuaranteedSumLabel.Text = "1,000,000"
        MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        AudienceScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@money_tree_level_15|" & winNumber & "|"
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
        FastestFingerFirstForm.Show()
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
        HostScreenForm.Close()
        PlayerScreenForm.Close()
        AudienceScreenForm.Close()
        FiftyFiftyForm.Close()
        PhoneAFriendForm.Close()
        AskTheAudienceForm.Close()
        QuestionEditorForm.Close()
        FastestFingerFirstForm.Close()
        AboutForm.Close()
        BackgroundMusic.Stop()
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
                HostScreenForm.Hide()
                PlayerScreenForm.Hide()
                'Синхронизация по сети
                'If ConnectButton.BackColor = Color.Green Then
                '    Dim NetworkInfo As New IONetwork
                '    With NetworkInfo
                '        .Command = "@sync|questionText|textAnswerA|textAnswerB|textAnswerC|textAnswerD|numberRightAnswer|currentBlock2(QuestionListBox.SelectedIndex + 1, 9)|winNumber|MoneyTakenCheckBox.Checked|QuestionNumberNumericUpDown.Value|activ50|activPAF|activATA|HostFrameCheckBox.Checked|PlayerFrameCheckBox.Checked|HostVisibleCheckBox.Checked|PlayerVisibleCheckBox.Checked|commentShow|splashOn|HostScreenXNumericUpDown.Value|HostScreenYNumericUpDown.Value|PlayerScreenXNumericUpDown.Value|PlayerScreenYNumericUpDown.Value|PhoneAFriendForm.clockFrame|HostScreenForm.ClockPictureBox.ImageLocation|PlayerScreenForm.ClockPictureBox.ImageLocation|HostScreenForm.ClockPictureBox.Visible|PlayerScreenForm.ClockPictureBox.Visible|HostScreenForm.AnswerAPercentLabel.Text|HostScreenForm.AnswerBPercentLabel.Text|HostScreenForm.AnswerCPercentLabel.Text|HostScreenForm.AnswerDPercentLabel.Text|HostScreenForm.AnswerAPercentLabel.Visible|HostScreenForm.AnswerBPercentLabel.Visible|HostScreenForm.AnswerCPercentLabel.Visible|HostScreenForm.AnswerDPercentLabel.Visible|HostScreenForm.AnswerAChartPictureBox.Visible|HostScreenForm.AnswerBChartPictureBox.Visible|HostScreenForm.AnswerCChartPictureBox.Visible|HostScreenForm.AnswerDChartPictureBox.Visible|HostScreenForm.AnswerAChartPictureBox.Height|HostScreenForm.AnswerBChartPictureBox.Height|HostScreenForm.AnswerCChartPictureBox.Height|HostScreenForm.AnswerDChartPictureBox.Height|HostScreenForm.AnswerAChartPictureBox.Top|HostScreenForm.AnswerBChartPictureBox.Top|HostScreenForm.AnswerCChartPictureBox.Top|HostScreenForm.AnswerDChartPictureBox.Top|PlayerScreenForm.AnswerAPercentLabel.Text|PlayerScreenForm.AnswerBPercentLabel.Text|PlayerScreenForm.AnswerCPercentLabel.Text|PlayerScreenForm.AnswerDPercentLabel.Text|PlayerScreenForm.AnswerAPercentLabel.Visible|PlayerScreenForm.AnswerBPercentLabel.Visible|PlayerScreenForm.AnswerCPercentLabel.Visible|PlayerScreenForm.AnswerDPercentLabel.Visible|PlayerScreenForm.AnswerAChartPictureBox.Visible|PlayerScreenForm.AnswerBChartPictureBox.Visible|PlayerScreenForm.AnswerCChartPictureBox.Visible|PlayerScreenForm.AnswerDChartPictureBox.Visible|PlayerScreenForm.AnswerAChartPictureBox.Height|PlayerScreenForm.AnswerBChartPictureBox.Height|PlayerScreenForm.AnswerCChartPictureBox.Height|PlayerScreenForm.AnswerDChartPictureBox.Height|PlayerScreenForm.AnswerAChartPictureBox.Top|PlayerScreenForm.AnswerBChartPictureBox.Top|PlayerScreenForm.AnswerCChartPictureBox.Top|PlayerScreenForm.AnswerDChartPictureBox.Top|HostScreenForm.BackgroundImage|HostScreenForm.AnswerAFramePictureBox.BackgroundImage|HostScreenForm.AnswerBFramePictureBox.BackgroundImage|HostScreenForm.AnswerCFramePictureBox.BackgroundImage|HostScreenForm.AnswerDFramePictureBox.BackgroundImage|HostScreenForm.MoneyTreePictureBox.BackgroundImage|HostScreenForm.LifelinesPictureBox.BackgroundImage|HostScreenForm.QuestionTextLabel.Text|HostScreenForm.AnswerATextLabel.Text|HostScreenForm.AnswerBTextLabel.Text|HostScreenForm.AnswerCTextLabel.Text|HostScreenForm.AnswerDTextLabel.Text|HostScreenForm.QuestionsLeftLabel.Text|HostScreenForm.PossibleWinLabel.Text|HostScreenForm.CurrentWinLabel.Text|HostScreenForm.PossibleLossLabel.Text|HostScreenForm.FinalAnswerLetterLabel.Text|HostScreenForm.GuaranteedSumLabel.Text|HostScreenForm.QuestionCommentLabel.Text|HostScreenForm.HostMessageLabel.Text|HostScreenForm.LogoPictureBox.Visible|PlayerScreenForm.BackgroundImage|PlayerScreenForm.AnswerAFramePictureBox.BackgroundImage|PlayerScreenForm.AnswerBFramePictureBox.BackgroundImage|PlayerScreenForm.AnswerCFramePictureBox.BackgroundImage|PlayerScreenForm.AnswerDFramePictureBox.BackgroundImage|PlayerScreenForm.MoneyTreePictureBox.BackgroundImage|PlayerScreenForm.LifelinesPictureBox.BackgroundImage|PlayerScreenForm.QuestionTextLabel.Text|PlayerScreenForm.AnswerATextLabel.Text|PlayerScreenForm.AnswerBTextLabel.Text|PlayerScreenForm.AnswerCTextLabel.Text|PlayerScreenForm.AnswerDTextLabel.Text|PlayerScreenForm.WinnerNameLabel.Text|PlayerScreenForm.MoneyWonPictureBox.BackgroundImage|PlayerScreenForm.PrizePictureBox.BackgroundImage|PlayerScreenForm.LogoPictureBox.Visible|"
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
                    If HostVisibleCheckBox.Checked Then HostScreenForm.Focus()
                    If PlayerVisibleCheckBox.Checked Then PlayerScreenForm.Focus()
                    AudienceVisibleCheckBox.Checked = False
                    HostScreenForm.HostMessageLabel.Text = currentBlock1(146, 3)
                Case "@ask_question" 'Ask It
                    HostScreenForm.FinalAnswerLetterLabel.Text = ""
                    HostScreenForm.QuestionCommentLabel.Text = ""
                    questionText = doingEvent(1)
                    QuestionTextLabel.Text = questionText
                    numberRightAnswer = doingEvent(2)
                    questionNumber = doingEvent(3)
                    winNumber = questionNumber - 1
                    HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@enable_answer_a" 'Enable A
                    AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                    AnswerATextLabel.Text = doingEvent(1)
                Case "@enable_answer_b" 'Enable B
                    AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                    AnswerBTextLabel.Text = doingEvent(1)
                Case "@enable_answer_c" 'Enable C
                    AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                    AnswerCTextLabel.Text = doingEvent(1)
                Case "@enable_answer_d" 'Enable D
                    AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                    AnswerDTextLabel.Text = doingEvent(1)
                Case "@enable_all_answers" 'Enable All
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
                    HostScreenForm.QuestionCommentLabel.Text = doingEvent(6)
                Case "@receive_answer_a", "@receive_answer_b", "@receive_answer_c", "@receive_answer_d" 'Receive A, B, C, D
                    Select Case numberRightAnswer
                        Case 1
                            HostScreenForm.FinalAnswerLetterLabel.Text = "A"
                        Case 2
                            HostScreenForm.FinalAnswerLetterLabel.Text = "B"
                        Case 3
                            HostScreenForm.FinalAnswerLetterLabel.Text = "C"
                        Case 4
                            HostScreenForm.FinalAnswerLetterLabel.Text = "D"
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
                    HostScreenForm.QuestionCommentLabel.Text = doingEvent(1)
                    Select Case doingEvent(0)
                        Case "@receive_answer_a"
                            playerAnswerNumber = 1
                            AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_ORANGE.png")
                            AnswerATextLabel.BackColor = Color.FromArgb(244, 155, 15)
                            AnswerATextLabel.ForeColor = Color.Black
                        Case "@receive_answer_b"
                            playerAnswerNumber = 2
                            AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_ORANGE.png")
                            AnswerBTextLabel.BackColor = Color.FromArgb(244, 155, 15)
                            AnswerBTextLabel.ForeColor = Color.Black
                        Case "@receive_answer_c"
                            playerAnswerNumber = 3
                            AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_ORANGE.png")
                            AnswerCTextLabel.BackColor = Color.FromArgb(244, 155, 15)
                            AnswerCTextLabel.ForeColor = Color.Black
                        Case "@receive_answer_d"
                            playerAnswerNumber = 4
                            AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_ORANGE.png")
                            AnswerDTextLabel.BackColor = Color.FromArgb(244, 155, 15)
                            AnswerDTextLabel.ForeColor = Color.Black
                    End Select
                Case "@reveal_correct_answer" 'What's correct
                    HostScreenForm.QuestionsLeftLabel.Text = "Qaway:" & Str(15 - questionNumber)
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
                                    HostScreenForm.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                                    HostScreenForm.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                                    HostScreenForm.PossibleLossLabel.Text = "0" 'Возможная потеря
                                    HostScreenForm.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                                Case 1
                                    HostScreenForm.PossibleWinLabel.Text = "200"
                                    HostScreenForm.CurrentWinLabel.Text = "100"
                                    HostScreenForm.PossibleLossLabel.Text = "100"
                                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                                Case 2
                                    HostScreenForm.PossibleWinLabel.Text = "300"
                                    HostScreenForm.CurrentWinLabel.Text = "200"
                                    HostScreenForm.PossibleLossLabel.Text = "200"
                                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                                Case 3
                                    HostScreenForm.PossibleWinLabel.Text = "500"
                                    HostScreenForm.CurrentWinLabel.Text = "200"
                                    HostScreenForm.PossibleLossLabel.Text = "200"
                                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                                Case 4
                                    HostScreenForm.PossibleWinLabel.Text = "1,000"
                                    HostScreenForm.CurrentWinLabel.Text = "500"
                                    HostScreenForm.PossibleLossLabel.Text = "500"
                                    HostScreenForm.GuaranteedSumLabel.Text = "0"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                                Case 5
                                    HostScreenForm.PossibleWinLabel.Text = "2,000"
                                    HostScreenForm.CurrentWinLabel.Text = "1,000"
                                    HostScreenForm.PossibleLossLabel.Text = "0"
                                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                                Case 6
                                    HostScreenForm.PossibleWinLabel.Text = "4,000"
                                    HostScreenForm.CurrentWinLabel.Text = "2,000"
                                    HostScreenForm.PossibleLossLabel.Text = "1,000"
                                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                                Case 7
                                    HostScreenForm.PossibleWinLabel.Text = "8,000"
                                    HostScreenForm.CurrentWinLabel.Text = "4,000"
                                    HostScreenForm.PossibleLossLabel.Text = "3,000"
                                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                                Case 8
                                    HostScreenForm.PossibleWinLabel.Text = "16,000"
                                    HostScreenForm.CurrentWinLabel.Text = "8,000"
                                    HostScreenForm.PossibleLossLabel.Text = "7,000"
                                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                                Case 9
                                    HostScreenForm.PossibleWinLabel.Text = "32,000"
                                    HostScreenForm.CurrentWinLabel.Text = "16,000"
                                    HostScreenForm.PossibleLossLabel.Text = "15,000"
                                    HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                                Case 10
                                    HostScreenForm.PossibleWinLabel.Text = "64,000"
                                    HostScreenForm.CurrentWinLabel.Text = "32,000"
                                    HostScreenForm.PossibleLossLabel.Text = "0"
                                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                                Case 11
                                    HostScreenForm.PossibleWinLabel.Text = "125,000"
                                    HostScreenForm.CurrentWinLabel.Text = "64,000"
                                    HostScreenForm.PossibleLossLabel.Text = "32,000"
                                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                                Case 12
                                    HostScreenForm.PossibleWinLabel.Text = "250,000"
                                    HostScreenForm.CurrentWinLabel.Text = "125,000"
                                    HostScreenForm.PossibleLossLabel.Text = "93,000"
                                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                                Case 13
                                    HostScreenForm.PossibleWinLabel.Text = "500,000"
                                    HostScreenForm.CurrentWinLabel.Text = "250,000"
                                    HostScreenForm.PossibleLossLabel.Text = "218,000"
                                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                                Case 14
                                    HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                                    HostScreenForm.CurrentWinLabel.Text = "500,000"
                                    HostScreenForm.PossibleLossLabel.Text = "468,000"
                                    HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                    PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                            End Select
                        Else
                            PrizeRevealTimer.Start()
                            PlayerScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                        End If
                    Else
                        PrizeRevealTimer.Start()
                        If winNumber < 15 Then
                            PlayerScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                        End If
                    End If
                    HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@millionaire_win" '@reveal_correct_answer + winNumber=15
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
                    HostScreenForm.QuestionsLeftLabel.Text = "Qaway: 0"
                    HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                    HostScreenForm.CurrentWinLabel.Text = "1,000,000"
                    HostScreenForm.PossibleLossLabel.Text = "0"
                    HostScreenForm.GuaranteedSumLabel.Text = "1,000,000"
                    PrizeRevealTimer.Start()
                    PlayerScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\MILLIONAIRE.png")
                    PlayerScreenForm.WinnerNameLabel.Text = doingEvent(1)
                    HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@lights_down" 'Lx
                    MoneyWonRevealTimer.Stop()
                    PlayerScreenForm.MoneyWonPictureBox.Visible = False
                    QuestionTextLabel.Text = ""
                    AnswerATextLabel.Text = ""
                    AnswerBTextLabel.Text = ""
                    AnswerCTextLabel.Text = ""
                    AnswerDTextLabel.Text = ""
                    AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    PlayerScreenForm.QuestionTextLabel.Visible = True
                    PlayerScreenForm.AnswerATextLabel.Visible = True
                    PlayerScreenForm.AnswerBTextLabel.Visible = True
                    PlayerScreenForm.AnswerCTextLabel.Visible = True
                    PlayerScreenForm.AnswerDTextLabel.Visible = True
                    PlayerScreenForm.AnswerAFramePictureBox.Visible = True
                    PlayerScreenForm.AnswerBFramePictureBox.Visible = True
                    PlayerScreenForm.AnswerCFramePictureBox.Visible = True
                    PlayerScreenForm.AnswerDFramePictureBox.Visible = True
                    PlayerScreenForm.PrizePictureBox.Visible = False
                    PlayerScreenForm.WinnerNameLabel.Visible = False
                    PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerATextLabel.ForeColor = Color.White
                    AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerBTextLabel.ForeColor = Color.White
                    AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerCTextLabel.ForeColor = Color.White
                    AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
                    AnswerDTextLabel.ForeColor = Color.White
                    questionNumber = doingEvent(1)
                Case "@lifeline_explanations" 'Explane Lifelines
                    winNumber = doingEvent(4)
                    HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    HostScreenForm.LogoPictureBox.Visible = False
                    PlayerScreenForm.LogoPictureBox.Visible = False
                    splashOn = False
                    ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
                    ToggleLogoButton.BackColor = Color.White
                    ClearFormsButton.PerformClick()
                    If doingEvent(1) = "0" Then FiftyFiftyAvailableCheckBox.Checked = True Else FiftyFiftyAvailableCheckBox.Checked = False
                    If doingEvent(2) = "0" Then PhoneAFriendAvailableCheckBox.Checked = True Else PhoneAFriendAvailableCheckBox.Checked = False
                    If doingEvent(3) = "0" Then AskTheAudienceAvailableCheckBox.Checked = True Else AskTheAudienceAvailableCheckBox.Checked = False
                Case "@fifty_fifty_music", "@phone_a_friend_music", "@ask_the_audience_music" 'Lifelines Pings
                    HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    LifelinesRefreshTimer.Start()
                Case "@start_the_game" 'Start the game
                    PlayerScreenForm.MoneyWonPictureBox.Visible = False
                    HostScreenForm.QuestionsLeftLabel.Text = "Qaway:" & Str(15 - doingEvent(2))
                    If doingEvent(2) < 15 Then
                        Select Case doingEvent(1)
                            Case 0, 1
                                HostScreenForm.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                                HostScreenForm.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                                HostScreenForm.PossibleLossLabel.Text = "0" 'Возможная потеря
                                HostScreenForm.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                            Case 2
                                HostScreenForm.PossibleWinLabel.Text = "200"
                                HostScreenForm.CurrentWinLabel.Text = "100"
                                HostScreenForm.PossibleLossLabel.Text = "100"
                                HostScreenForm.GuaranteedSumLabel.Text = "0"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                            Case 3
                                HostScreenForm.PossibleWinLabel.Text = "300"
                                HostScreenForm.CurrentWinLabel.Text = "200"
                                HostScreenForm.PossibleLossLabel.Text = "200"
                                HostScreenForm.GuaranteedSumLabel.Text = "0"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                            Case 4
                                HostScreenForm.PossibleWinLabel.Text = "500"
                                HostScreenForm.CurrentWinLabel.Text = "200"
                                HostScreenForm.PossibleLossLabel.Text = "200"
                                HostScreenForm.GuaranteedSumLabel.Text = "0"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                            Case 5
                                HostScreenForm.PossibleWinLabel.Text = "1,000"
                                HostScreenForm.CurrentWinLabel.Text = "500"
                                HostScreenForm.PossibleLossLabel.Text = "500"
                                HostScreenForm.GuaranteedSumLabel.Text = "0"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                            Case 6
                                HostScreenForm.PossibleWinLabel.Text = "2,000"
                                HostScreenForm.CurrentWinLabel.Text = "1,000"
                                HostScreenForm.PossibleLossLabel.Text = "0"
                                HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                            Case 7
                                HostScreenForm.PossibleWinLabel.Text = "4,000"
                                HostScreenForm.CurrentWinLabel.Text = "2,000"
                                HostScreenForm.PossibleLossLabel.Text = "1,000"
                                HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                            Case 8
                                HostScreenForm.PossibleWinLabel.Text = "8,000"
                                HostScreenForm.CurrentWinLabel.Text = "4,000"
                                HostScreenForm.PossibleLossLabel.Text = "3,000"
                                HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                            Case 9
                                HostScreenForm.PossibleWinLabel.Text = "16,000"
                                HostScreenForm.CurrentWinLabel.Text = "8,000"
                                HostScreenForm.PossibleLossLabel.Text = "7,000"
                                HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                            Case 10
                                HostScreenForm.PossibleWinLabel.Text = "32,000"
                                HostScreenForm.CurrentWinLabel.Text = "16,000"
                                HostScreenForm.PossibleLossLabel.Text = "15,000"
                                HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                            Case 11
                                HostScreenForm.PossibleWinLabel.Text = "64,000"
                                HostScreenForm.CurrentWinLabel.Text = "32,000"
                                HostScreenForm.PossibleLossLabel.Text = "0"
                                HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                            Case 12
                                HostScreenForm.PossibleWinLabel.Text = "125,000"
                                HostScreenForm.CurrentWinLabel.Text = "64,000"
                                HostScreenForm.PossibleLossLabel.Text = "32,000"
                                HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                            Case 13
                                HostScreenForm.PossibleWinLabel.Text = "250,000"
                                HostScreenForm.CurrentWinLabel.Text = "125,000"
                                HostScreenForm.PossibleLossLabel.Text = "93,000"
                                HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                            Case 14
                                HostScreenForm.PossibleWinLabel.Text = "500,000"
                                HostScreenForm.CurrentWinLabel.Text = "250,000"
                                HostScreenForm.PossibleLossLabel.Text = "218,000"
                                HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                            Case 15
                                HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                                HostScreenForm.CurrentWinLabel.Text = "500,000"
                                HostScreenForm.PossibleLossLabel.Text = "468,000"
                                HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                                PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                        End Select
                    End If
                    HostScreenForm.FinalAnswerLetterLabel.Text = ""
                    QuestionTextLabel.Text = ""
                    AnswerATextLabel.Text = ""
                    AnswerBTextLabel.Text = ""
                    AnswerCTextLabel.Text = ""
                    AnswerDTextLabel.Text = ""
                    PlayerScreenForm.QuestionTextLabel.Visible = True
                    PlayerScreenForm.AnswerATextLabel.Visible = True
                    PlayerScreenForm.AnswerBTextLabel.Visible = True
                    PlayerScreenForm.AnswerCTextLabel.Visible = True
                    PlayerScreenForm.AnswerDTextLabel.Visible = True
                    PlayerScreenForm.AnswerAFramePictureBox.Visible = True
                    PlayerScreenForm.AnswerBFramePictureBox.Visible = True
                    PlayerScreenForm.AnswerCFramePictureBox.Visible = True
                    PlayerScreenForm.AnswerDFramePictureBox.Visible = True
                    PlayerScreenForm.PrizePictureBox.Visible = False
                    PlayerScreenForm.WinnerNameLabel.Visible = False
                    PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
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
                    HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & doingEvent(2) & ".png"
                    PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & doingEvent(2) & ".png"
                    HostScreenForm.QuestionCommentLabel.Text = ""
                    commentShow = False
                    MoneyTakenCheckBox.Checked = False
                    HostScreenForm.LogoPictureBox.Visible = False
                    PlayerScreenForm.LogoPictureBox.Visible = False
                    splashOn = False
                    ToggleLogoButton.Text = currentBlock1(45, 3) 'Show logo
                    ToggleLogoButton.BackColor = Color.White
                Case "@goodbye_punter" 'Goodbye Punter
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
                Case "@question_number" 'Смена номера вопроса
                    questionNumber = doingEvent(1)
                Case "@clear_forms" 'Clear forms
                    ClearFormsButton.PerformClick()
                Case "@take_the_money_reveal" 'Take a money 1
                    MoneyTakenCheckBox.Checked = doingEvent(1)
                    PrizeRevealTimer.Start()
                    If winNumber < 15 Then
                        PlayerScreenForm.PrizePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                    End If
                    TakeTheMoneyButton.BackColor = Color.Blue
                    MoneyTakenCheckBox.Checked = True
                Case "@take_the_money_restore" 'Take a money 2
                    MoneyTakenCheckBox.Checked = doingEvent(1)
                    PlayerScreenForm.WinnerNameLabel.Visible = False
                    PlayerScreenForm.QuestionTextLabel.Visible = True
                    PlayerScreenForm.AnswerATextLabel.Visible = True
                    PlayerScreenForm.AnswerBTextLabel.Visible = True
                    PlayerScreenForm.AnswerCTextLabel.Visible = True
                    PlayerScreenForm.AnswerDTextLabel.Visible = True
                    PlayerScreenForm.AnswerAFramePictureBox.Visible = True
                    PlayerScreenForm.AnswerBFramePictureBox.Visible = True
                    PlayerScreenForm.AnswerCFramePictureBox.Visible = True
                    PlayerScreenForm.AnswerDFramePictureBox.Visible = True
                    PlayerScreenForm.PrizePictureBox.Visible = False
                    PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    PrizeRevealTimer.Stop()
                    TakeTheMoneyButton.BackColor = Color.White
                Case "@lifelines_state", "@fifty_fifty_used", "@phone_a_friend_used", "@ask_the_audience_used" '50-50, PAF or ATA state changed
                    HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                Case "@host_frame" 'HostScreenForm frame
                    HostFrameCheckBox.Checked = doingEvent(1)
                    If HostFrameCheckBox.Checked = True Then
                        HostScreenForm.FormBorderStyle = FormBorderStyle.Sizable
                    Else
                        HostScreenForm.FormBorderStyle = FormBorderStyle.None
                    End If
                Case "@player_frame" 'PlayerScreenForm frame state
                    PlayerFrameCheckBox.Checked = doingEvent(1)
                    If PlayerFrameCheckBox.Checked = True Then
                        PlayerScreenForm.FormBorderStyle = FormBorderStyle.Sizable
                    Else
                        PlayerScreenForm.FormBorderStyle = FormBorderStyle.None
                    End If
                Case "@host_visible" 'HostScreenForm window visibility
                    HostVisibleCheckBox.Checked = doingEvent(1)
                    If HostVisibleCheckBox.Checked = True Then
                        HostScreenForm.Show()
                    Else
                        HostScreenForm.Hide()
                    End If
                Case "@player_visible" 'PlayerScreenForm window visibility
                    PlayerVisibleCheckBox.Checked = doingEvent(1)
                    If PlayerVisibleCheckBox.Checked = True Then
                        PlayerScreenForm.Show()
                    Else
                        PlayerScreenForm.Hide()
                    End If
                Case "@send_host_message" 'Send (message)
                    HostScreenForm.HostMessageLabel.Text = doingEvent(1)
                Case "@clear_host_message" 'Clear (message)
                    HostScreenForm.HostMessageLabel.Text = Nothing
                Case "@toggle_hint" 'Show hint
                    If doingEvent(1) = True Then commentShow = False Else commentShow = True
                    currentBlock2(QuestionListBox.SelectedIndex + 1, 9) = doingEvent(2)
                    ToggleHintButton.PerformClick()
                Case "@toggle_logo" 'Show logo
                    If doingEvent(1) = True Then splashOn = False Else splashOn = True
                    If splashOn = False Then
                        HostScreenForm.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
                        HostScreenForm.LogoPictureBox.Visible = True
                        PlayerScreenForm.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
                        PlayerScreenForm.LogoPictureBox.Visible = True
                        splashOn = True
                    Else
                        HostScreenForm.LogoPictureBox.Visible = False
                        PlayerScreenForm.LogoPictureBox.Visible = False
                        splashOn = False
                    End If
                Case "@host_window_location" 'HostScreenForm window location
                    HostScreenForm.Location = New Point(doingEvent(1), doingEvent(2))
                Case "@player_window_location" 'PlayerScreenForm window location
                    PlayerScreenForm.Location = New Point(doingEvent(1), doingEvent(2))
                Case "@money_tree_up", "@money_tree_down", "@money_tree_level_0", "@money_tree_level_5", "@money_tree_level_10", "@money_tree_level_15" 'Tree Up or Tree Down
                    winNumber = doingEvent(1)
                    Select Case questionNumber
                        Case 0
                            HostScreenForm.PossibleWinLabel.Text = "100" 'Возможный выигрыш
                            HostScreenForm.CurrentWinLabel.Text = "0" 'Текущий выигрыш
                            HostScreenForm.PossibleLossLabel.Text = "0" 'Возможная потеря
                            HostScreenForm.GuaranteedSumLabel.Text = "0" 'Несгораемая сумма
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                        Case 1
                            HostScreenForm.PossibleWinLabel.Text = "200"
                            HostScreenForm.CurrentWinLabel.Text = "100"
                            HostScreenForm.PossibleLossLabel.Text = "100"
                            HostScreenForm.GuaranteedSumLabel.Text = "0"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                        Case 2
                            HostScreenForm.PossibleWinLabel.Text = "300"
                            HostScreenForm.CurrentWinLabel.Text = "200"
                            HostScreenForm.PossibleLossLabel.Text = "200"
                            HostScreenForm.GuaranteedSumLabel.Text = "0"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                        Case 3
                            HostScreenForm.PossibleWinLabel.Text = "500"
                            HostScreenForm.CurrentWinLabel.Text = "200"
                            HostScreenForm.PossibleLossLabel.Text = "200"
                            HostScreenForm.GuaranteedSumLabel.Text = "0"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                        Case 4
                            HostScreenForm.PossibleWinLabel.Text = "1,000"
                            HostScreenForm.CurrentWinLabel.Text = "500"
                            HostScreenForm.PossibleLossLabel.Text = "500"
                            HostScreenForm.GuaranteedSumLabel.Text = "0"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                        Case 5
                            HostScreenForm.PossibleWinLabel.Text = "2,000"
                            HostScreenForm.CurrentWinLabel.Text = "1,000"
                            HostScreenForm.PossibleLossLabel.Text = "0"
                            HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                        Case 6
                            HostScreenForm.PossibleWinLabel.Text = "4,000"
                            HostScreenForm.CurrentWinLabel.Text = "2,000"
                            HostScreenForm.PossibleLossLabel.Text = "1,000"
                            HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                        Case 7
                            HostScreenForm.PossibleWinLabel.Text = "8,000"
                            HostScreenForm.CurrentWinLabel.Text = "4,000"
                            HostScreenForm.PossibleLossLabel.Text = "3,000"
                            HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                        Case 8
                            HostScreenForm.PossibleWinLabel.Text = "16,000"
                            HostScreenForm.CurrentWinLabel.Text = "8,000"
                            HostScreenForm.PossibleLossLabel.Text = "7,000"
                            HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                        Case 9
                            HostScreenForm.PossibleWinLabel.Text = "32,000"
                            HostScreenForm.CurrentWinLabel.Text = "16,000"
                            HostScreenForm.PossibleLossLabel.Text = "15,000"
                            HostScreenForm.GuaranteedSumLabel.Text = "1,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                        Case 10
                            HostScreenForm.PossibleWinLabel.Text = "64,000"
                            HostScreenForm.CurrentWinLabel.Text = "32,000"
                            HostScreenForm.PossibleLossLabel.Text = "0"
                            HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                        Case 11
                            HostScreenForm.PossibleWinLabel.Text = "125,000"
                            HostScreenForm.CurrentWinLabel.Text = "64,000"
                            HostScreenForm.PossibleLossLabel.Text = "32,000"
                            HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                        Case 12
                            HostScreenForm.PossibleWinLabel.Text = "250,000"
                            HostScreenForm.CurrentWinLabel.Text = "125,000"
                            HostScreenForm.PossibleLossLabel.Text = "93,000"
                            HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                        Case 13
                            HostScreenForm.PossibleWinLabel.Text = "500,000"
                            HostScreenForm.CurrentWinLabel.Text = "250,000"
                            HostScreenForm.PossibleLossLabel.Text = "218,000"
                            HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                        Case 14
                            HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                            HostScreenForm.CurrentWinLabel.Text = "500,000"
                            HostScreenForm.PossibleLossLabel.Text = "468,000"
                            HostScreenForm.GuaranteedSumLabel.Text = "32,000"
                            PlayerScreenForm.MoneyWonPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                        Case 15
                            HostScreenForm.PossibleWinLabel.Text = "1,000,000"
                            HostScreenForm.CurrentWinLabel.Text = "1,000,000"
                            HostScreenForm.PossibleLossLabel.Text = "0"
                            HostScreenForm.GuaranteedSumLabel.Text = "1,000,000"
                    End Select
                    HostScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    PlayerScreenForm.MoneyTreePictureBox.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@fifty_fifty_execute" '50:50 AskQuestionButton
                    AnswerATextLabel.Text = doingEvent(1)
                    AnswerBTextLabel.Text = doingEvent(2)
                    AnswerCTextLabel.Text = doingEvent(3)
                    AnswerDTextLabel.Text = doingEvent(4)
                    FiftyFiftyAvailableCheckBox.Checked = False
                    HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                Case "@paf_start" 'PAF AskQuestionButton
                    PhoneAFriendForm.ClockTimer.Stop()
                    HostScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
                    PlayerScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
                    HostScreenForm.ClockPictureBox.Visible = False
                    PlayerScreenForm.ClockPictureBox.Visible = False
                    SoundCues.Stop()
                Case "@paf_clock_start" 'PAF EnableAnswerAButton
                    PhoneAFriendForm.ClockTimer.Stop()
                    PhoneAFriendForm.clockFrame = 1
                    HostScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
                    PlayerScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
                    PhoneAFriendForm.ClockTimer.Start()
                    HostScreenForm.ClockPictureBox.Visible = True
                    PlayerScreenForm.ClockPictureBox.Visible = True
                    SoundCues.Stop()
                Case "@paf_clock_stop" 'PAF EnableAnswerBButton
                    PhoneAFriendForm.ClockTimer.Stop()
                    PhoneAFriendAvailableCheckBox.Checked = False
                    HostScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
                    PlayerScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
                    SoundCues.Stop()
                Case "@paf_closed" 'PAF closed
                    PhoneAFriendForm.ClockTimer.Stop()
                    HostScreenForm.ClockPictureBox.Visible = False
                    PlayerScreenForm.ClockPictureBox.Visible = False
                    SoundCues.Stop()
                    HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                Case "@ata_start_voting" 'ATA EnableAnswerAButton
                    HostScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Host Screen ATA.png")
                    PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen ATA.png")
                Case "@ata_execute" 'ATA EnableAnswerBButton
                    HostScreenForm.AnswerAPercentLabel.Text = doingEvent(5) & "%"
                    HostScreenForm.AnswerBPercentLabel.Text = doingEvent(6) & "%"
                    HostScreenForm.AnswerCPercentLabel.Text = doingEvent(7) & "%"
                    HostScreenForm.AnswerDPercentLabel.Text = doingEvent(8) & "%"
                    HostScreenForm.AnswerAPercentLabel.Visible = True
                    HostScreenForm.AnswerBPercentLabel.Visible = True
                    HostScreenForm.AnswerCPercentLabel.Visible = True
                    HostScreenForm.AnswerDPercentLabel.Visible = True
                    HostScreenForm.AnswerAChartPictureBox.Visible = True
                    HostScreenForm.AnswerBChartPictureBox.Visible = True
                    HostScreenForm.AnswerCChartPictureBox.Visible = True
                    HostScreenForm.AnswerDChartPictureBox.Visible = True
                    HostScreenForm.AnswerAChartPictureBox.Height = doingEvent(1) * 1.2
                    HostScreenForm.AnswerBChartPictureBox.Height = doingEvent(2) * 1.2
                    HostScreenForm.AnswerCChartPictureBox.Height = doingEvent(3) * 1.2
                    HostScreenForm.AnswerDChartPictureBox.Height = doingEvent(4) * 1.2
                    HostScreenForm.AnswerAChartPictureBox.Top = 515 - doingEvent(1) * 1.2
                    HostScreenForm.AnswerBChartPictureBox.Top = 515 - doingEvent(2) * 1.2
                    HostScreenForm.AnswerCChartPictureBox.Top = 515 - doingEvent(3) * 1.2
                    HostScreenForm.AnswerDChartPictureBox.Top = 515 - doingEvent(4) * 1.2
                    PlayerScreenForm.AnswerAPercentLabel.Text = doingEvent(5) & "%"
                    PlayerScreenForm.AnswerBPercentLabel.Text = doingEvent(6) & "%"
                    PlayerScreenForm.AnswerCPercentLabel.Text = doingEvent(7) & "%"
                    PlayerScreenForm.AnswerDPercentLabel.Text = doingEvent(8) & "%"
                    PlayerScreenForm.AnswerAPercentLabel.Visible = True
                    PlayerScreenForm.AnswerBPercentLabel.Visible = True
                    PlayerScreenForm.AnswerCPercentLabel.Visible = True
                    PlayerScreenForm.AnswerDPercentLabel.Visible = True
                    PlayerScreenForm.AnswerAChartPictureBox.Visible = True
                    PlayerScreenForm.AnswerBChartPictureBox.Visible = True
                    PlayerScreenForm.AnswerCChartPictureBox.Visible = True
                    PlayerScreenForm.AnswerDChartPictureBox.Visible = True
                    PlayerScreenForm.AnswerAChartPictureBox.Height = doingEvent(1) * 2.4
                    PlayerScreenForm.AnswerBChartPictureBox.Height = doingEvent(2) * 2.4
                    PlayerScreenForm.AnswerCChartPictureBox.Height = doingEvent(3) * 2.4
                    PlayerScreenForm.AnswerDChartPictureBox.Height = doingEvent(4) * 2.4
                    PlayerScreenForm.AnswerAChartPictureBox.Top = 538 - doingEvent(1) * 2.4
                    PlayerScreenForm.AnswerBChartPictureBox.Top = 538 - doingEvent(2) * 2.4
                    PlayerScreenForm.AnswerCChartPictureBox.Top = 538 - doingEvent(3) * 2.4
                    PlayerScreenForm.AnswerDChartPictureBox.Top = 538 - doingEvent(4) * 2.4
                    HostMessageTextBox.Text = doingEvent(9)
                    HostScreenForm.HostMessageLabel.Text = doingEvent(9)
                    AskTheAudienceAvailableCheckBox.Checked = False
                Case "@ata_closed" 'ATA closed
                    HostScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    HostScreenForm.AnswerAPercentLabel.Visible = False
                    HostScreenForm.AnswerBPercentLabel.Visible = False
                    HostScreenForm.AnswerCPercentLabel.Visible = False
                    HostScreenForm.AnswerDPercentLabel.Visible = False
                    HostScreenForm.AnswerAChartPictureBox.Visible = False
                    HostScreenForm.AnswerBChartPictureBox.Visible = False
                    HostScreenForm.AnswerCChartPictureBox.Visible = False
                    HostScreenForm.AnswerDChartPictureBox.Visible = False
                    PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    PlayerScreenForm.AnswerAPercentLabel.Visible = False
                    PlayerScreenForm.AnswerBPercentLabel.Visible = False
                    PlayerScreenForm.AnswerCPercentLabel.Visible = False
                    PlayerScreenForm.AnswerDPercentLabel.Visible = False
                    PlayerScreenForm.AnswerAChartPictureBox.Visible = False
                    PlayerScreenForm.AnswerBChartPictureBox.Visible = False
                    PlayerScreenForm.AnswerCChartPictureBox.Visible = False
                    PlayerScreenForm.AnswerDChartPictureBox.Visible = False
                    SoundCues.Stop()
                    HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
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
        SoundCues.Play("source\MUSIC\Timp Hit.wav")
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

'19 - PhoneAFriendForm.clockFrame
'20 - HostScreenForm.ClockPictureBox.ImageLocation
'21 - PlayerScreenForm.ClockPictureBox.ImageLocation
'22 - HostScreenForm.ClockPictureBox.Visible
'23 - PlayerScreenForm.ClockPictureBox.Visible

'24 - HostScreenForm.AnswerAPercentLabel.Text
'25 - HostScreenForm.AnswerBPercentLabel.Text
'26 - HostScreenForm.AnswerCPercentLabel.Text
'27 - HostScreenForm.AnswerDPercentLabel.Text
'28 - HostScreenForm.AnswerAPercentLabel.Visible
'29 - HostScreenForm.AnswerBPercentLabel.Visible
'30 - HostScreenForm.AnswerCPercentLabel.Visible
'31 - HostScreenForm.AnswerDPercentLabel.Visible
'32 - HostScreenForm.AnswerAChartPictureBox.Visible
'33 - HostScreenForm.AnswerBChartPictureBox.Visible
'34 - HostScreenForm.AnswerCChartPictureBox.Visible
'35 - HostScreenForm.AnswerDChartPictureBox.Visible
'36 - HostScreenForm.AnswerAChartPictureBox.Height
'37 - HostScreenForm.AnswerBChartPictureBox.Height
'38 - HostScreenForm.AnswerCChartPictureBox.Height
'39 - HostScreenForm.AnswerDChartPictureBox.Height
'40 - HostScreenForm.AnswerAChartPictureBox.Top
'41 - HostScreenForm.AnswerBChartPictureBox.Top
'42 - HostScreenForm.AnswerCChartPictureBox.Top
'43 - HostScreenForm.AnswerDChartPictureBox.Top
'44 - PlayerScreenForm.AnswerAPercentLabel.Text
'45 - PlayerScreenForm.AnswerBPercentLabel.Text
'46 - PlayerScreenForm.AnswerCPercentLabel.Text
'47 - PlayerScreenForm.AnswerDPercentLabel.Text
'48 - PlayerScreenForm.AnswerAPercentLabel.Visible
'49 - PlayerScreenForm.AnswerBPercentLabel.Visible
'50 - PlayerScreenForm.AnswerCPercentLabel.Visible
'51 - PlayerScreenForm.AnswerDPercentLabel.Visible
'52 - PlayerScreenForm.AnswerAChartPictureBox.Visible
'53 - PlayerScreenForm.AnswerBChartPictureBox.Visible
'54 - PlayerScreenForm.AnswerCChartPictureBox.Visible
'55 - PlayerScreenForm.AnswerDChartPictureBox.Visible
'56 - PlayerScreenForm.AnswerAChartPictureBox.Height
'57 - PlayerScreenForm.AnswerBChartPictureBox.Height
'58 - PlayerScreenForm.AnswerCChartPictureBox.Height
'59 - PlayerScreenForm.AnswerDChartPictureBox.Height
'60 - PlayerScreenForm.AnswerAChartPictureBox.Top
'61 - PlayerScreenForm.AnswerBChartPictureBox.Top
'62 - PlayerScreenForm.AnswerCChartPictureBox.Top
'63 - PlayerScreenForm.AnswerDChartPictureBox.Top

'64 - HostScreenForm.BackgroundImage
'65 - HostScreenForm.BackgroundImage
'66 - HostScreenForm.AnswerAFramePictureBox.BackgroundImage
'67 - HostScreenForm.AnswerBFramePictureBox.BackgroundImage
'68 - HostScreenForm.AnswerCFramePictureBox.BackgroundImage
'69 - HostScreenForm.AnswerDFramePictureBox.BackgroundImage
'70 - HostScreenForm.MoneyTreePictureBox.BackgroundImage
'71 - HostScreenForm.LifelinesPictureBox.BackgroundImage
'72 - HostScreenForm.QuestionTextLabel.Text
'73 - HostScreenForm.AnswerATextLabel.Text
'74 - HostScreenForm.AnswerBTextLabel.Text
'75 - HostScreenForm.AnswerCTextLabel.Text
'76 - HostScreenForm.AnswerDTextLabel.Text
'77 - HostScreenForm.QuestionsLeftLabel.Text
'78 - HostScreenForm.PossibleWinLabel.Text
'79 - HostScreenForm.CurrentWinLabel.Text
'80 - HostScreenForm.PossibleLossLabel.Text
'81 - HostScreenForm.FinalAnswerLetterLabel.Text
'82 - HostScreenForm.GuaranteedSumLabel.Text
'83 - HostScreenForm.QuestionCommentLabel.Text
'84 - HostScreenForm.HostMessageLabel.Text
'85 - HostScreenForm.LogoPictureBox.Visible

'86 - PlayerScreenForm.BackgroundImage
'87 - PlayerScreenForm.AnswerAFramePictureBox.BackgroundImage
'88 - PlayerScreenForm.AnswerBFramePictureBox.BackgroundImage
'89 - PlayerScreenForm.AnswerCFramePictureBox.BackgroundImage
'90 - PlayerScreenForm.AnswerDFramePictureBox.BackgroundImage
'91 - PlayerScreenForm.MoneyTreePictureBox.BackgroundImage
'92 - PlayerScreenForm.LifelinesPictureBox.BackgroundImage
'93 - PlayerScreenForm.QuestionTextLabel.Text
'94 - PlayerScreenForm.AnswerATextLabel.Text
'95 - PlayerScreenForm.AnswerBTextLabel.Text
'96 - PlayerScreenForm.AnswerCTextLabel.Text
'97 - PlayerScreenForm.AnswerDTextLabel.Text
'98 - PlayerScreenForm.WinnerNameLabel.Text
'99 - PlayerScreenForm.MoneyWonPictureBox.BackgroundImage
'100 - PlayerScreenForm.PrizePictureBox.BackgroundImage
'101 - PlayerScreenForm.LogoPictureBox.Visible

'"@sync|questionText|textAnswerA|textAnswerB|textAnswerC|textAnswerD|numberRightAnswer|currentBlock2(QuestionListBox.SelectedIndex + 1, 9)|winNumber|MoneyTakenCheckBox.Checked|QuestionNumberNumericUpDown.Value|activ50|activPAF|activATA|HostFrameCheckBox.Checked|PlayerFrameCheckBox.Checked|HostVisibleCheckBox.Checked|PlayerVisibleCheckBox.Checked|commentShow|splashOn|HostScreenXNumericUpDown.Value|HostScreenYNumericUpDown.Value|PlayerScreenXNumericUpDown.Value|PlayerScreenYNumericUpDown.Value|PhoneAFriendForm.clockFrame|HostScreenForm.ClockPictureBox.ImageLocation|PlayerScreenForm.ClockPictureBox.ImageLocation|HostScreenForm.ClockPictureBox.Visible|PlayerScreenForm.ClockPictureBox.Visible|HostScreenForm.AnswerAPercentLabel.Text|HostScreenForm.AnswerBPercentLabel.Text|HostScreenForm.AnswerCPercentLabel.Text|HostScreenForm.AnswerDPercentLabel.Text|HostScreenForm.AnswerAPercentLabel.Visible|HostScreenForm.AnswerBPercentLabel.Visible|HostScreenForm.AnswerCPercentLabel.Visible|HostScreenForm.AnswerDPercentLabel.Visible|HostScreenForm.AnswerAChartPictureBox.Visible|HostScreenForm.AnswerBChartPictureBox.Visible|HostScreenForm.AnswerCChartPictureBox.Visible|HostScreenForm.AnswerDChartPictureBox.Visible|HostScreenForm.AnswerAChartPictureBox.Height|HostScreenForm.AnswerBChartPictureBox.Height|HostScreenForm.AnswerCChartPictureBox.Height|HostScreenForm.AnswerDChartPictureBox.Height|HostScreenForm.AnswerAChartPictureBox.Top|HostScreenForm.AnswerBChartPictureBox.Top|HostScreenForm.AnswerCChartPictureBox.Top|HostScreenForm.AnswerDChartPictureBox.Top|PlayerScreenForm.AnswerAPercentLabel.Text|PlayerScreenForm.AnswerBPercentLabel.Text|PlayerScreenForm.AnswerCPercentLabel.Text|PlayerScreenForm.AnswerDPercentLabel.Text|PlayerScreenForm.AnswerAPercentLabel.Visible|PlayerScreenForm.AnswerBPercentLabel.Visible|PlayerScreenForm.AnswerCPercentLabel.Visible|PlayerScreenForm.AnswerDPercentLabel.Visible|PlayerScreenForm.AnswerAChartPictureBox.Visible|PlayerScreenForm.AnswerBChartPictureBox.Visible|PlayerScreenForm.AnswerCChartPictureBox.Visible|PlayerScreenForm.AnswerDChartPictureBox.Visible|PlayerScreenForm.AnswerAChartPictureBox.Height|PlayerScreenForm.AnswerBChartPictureBox.Height|PlayerScreenForm.AnswerCChartPictureBox.Height|PlayerScreenForm.AnswerDChartPictureBox.Height|PlayerScreenForm.AnswerAChartPictureBox.Top|PlayerScreenForm.AnswerBChartPictureBox.Top|PlayerScreenForm.AnswerCChartPictureBox.Top|PlayerScreenForm.AnswerDChartPictureBox.Top|HostScreenForm.BackgroundImage|HostScreenForm.AnswerAFramePictureBox.BackgroundImage|HostScreenForm.AnswerBFramePictureBox.BackgroundImage|HostScreenForm.AnswerCFramePictureBox.BackgroundImage|HostScreenForm.AnswerDFramePictureBox.BackgroundImage|HostScreenForm.MoneyTreePictureBox.BackgroundImage|HostScreenForm.LifelinesPictureBox.BackgroundImage|HostScreenForm.QuestionTextLabel.Text|HostScreenForm.AnswerATextLabel.Text|HostScreenForm.AnswerBTextLabel.Text|HostScreenForm.AnswerCTextLabel.Text|HostScreenForm.AnswerDTextLabel.Text|HostScreenForm.QuestionsLeftLabel.Text|HostScreenForm.PossibleWinLabel.Text|HostScreenForm.CurrentWinLabel.Text|HostScreenForm.PossibleLossLabel.Text|HostScreenForm.FinalAnswerLetterLabel.Text|HostScreenForm.GuaranteedSumLabel.Text|HostScreenForm.QuestionCommentLabel.Text|HostScreenForm.HostMessageLabel.Text|HostScreenForm.LogoPictureBox.Visible|PlayerScreenForm.BackgroundImage|PlayerScreenForm.AnswerAFramePictureBox.BackgroundImage|PlayerScreenForm.AnswerBFramePictureBox.BackgroundImage|PlayerScreenForm.AnswerCFramePictureBox.BackgroundImage|PlayerScreenForm.AnswerDFramePictureBox.BackgroundImage|PlayerScreenForm.MoneyTreePictureBox.BackgroundImage|PlayerScreenForm.LifelinesPictureBox.BackgroundImage|PlayerScreenForm.QuestionTextLabel.Text|PlayerScreenForm.AnswerATextLabel.Text|PlayerScreenForm.AnswerBTextLabel.Text|PlayerScreenForm.AnswerCTextLabel.Text|PlayerScreenForm.AnswerDTextLabel.Text|PlayerScreenForm.WinnerNameLabel.Text|PlayerScreenForm.MoneyWonPictureBox.BackgroundImage|PlayerScreenForm.PrizePictureBox.BackgroundImage|PlayerScreenForm.LogoPictureBox.Visible|"

'Case "@connect_success" 'При успешном соединении
'Case "@ask_question" 'Ask It                                                                                                 questionText & Str(numberRightAnswer) & questionNumber
'Case "@enable_answer_a" 'Enable A                                                                                                                                          textAnswerA
'Case "@enable_answer_b" 'Enable B                                                                                                                                          textAnswerB
'Case "@enable_answer_c" 'Enable C                                                                                                                                          textAnswerC
'Case "@enable_answer_d" 'Enable D                                                                                                                                          textAnswerD
'Case "@enable_all_answers" 'Enable All                                                           questionText & textAnswerA & textAnswerB & textAnswerC & textAnswerD & numberRightAnswer
'Case "@receive_answer_a", "@receive_answer_b", "@receive_answer_c", "@receive_answer_d" 'Receive A, B, C, D                                                         currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
'Case "@reveal_correct_answer" 'What's correct                                                                                                                            MoneyTakenCheckBox.Checked
'Case "@millionaire_win" '@reveal_correct_answer + winNumber=15                                                                                                     ContestantNameTextBox.Text
'Case "@lights_down" 'Lx                                                                                                                                      QuestionNumberNumericUpDown.Value
'Case "@lifeline_explanations" 'Lifeline Explanations                                                                                              activ50 & activPAF & activATA & winNumber
'Case "@fifty_fifty_music", "@phone_a_friend_music", "@ask_the_audience_music" 'Lifelines Pings                                                                                      activ50 & activPAF & activATA
'Case "@start_the_game" 'Start the game                                                                                                                    questionNumber & winNumber
'Case "@goodbye_punter" 'Goodbye Punter                                                                                                                                           ---
'Case "@question_number" 'Смена номера вопроса                                                                                                              QuestionNumberNumericUpDown.Value
'Case "@clear_forms" 'Clear forms                                                                                                                                              ---
'Case "@take_the_money_reveal", "@take_the_money_restore" 'Take a money                                                                                                             MoneyTakenCheckBox.Checked
'Case "@lifelines_state", "@fifty_fifty_used", "@phone_a_friend_used", "@ask_the_audience_used" '50-50, PAF or ATA state changed                                                  activ50 & activPAF & activATA
'Case "@host_frame" 'HostScreenForm frame                                                                                                                                HostFrameCheckBox.Checked
'Case "@player_frame" 'PlayerScreenForm frame state                                                                                                                        PlayerFrameCheckBox.Checked
'Case "@host_visible" 'HostScreenForm window visibility                                                                                                                    HostVisibleCheckBox.Checked
'Case "@player_visible" 'PlayerScreenForm window visibility                                                                                                                  PlayerVisibleCheckBox.Checked
'Case "@send_host_message" 'Send (message)                                                                                                                                HostMessageTextBox.Text
'Case "@clear_host_message" 'Clear (message)                                                                                                                                          ---
'Case "@toggle_hint" 'Show hint                                                                                         commentShow & currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
'Case "@toggle_logo" 'Show logo                                                                                                                                           splashOn
'Case "@host_window_location" 'HostScreenForm window location                                                                                       HostScreenXNumericUpDown.Value & HostScreenYNumericUpDown.Value
'Case "@player_window_location" 'PlayerScreenForm window location                                                                                     PlayerScreenXNumericUpDown.Value & PlayerScreenYNumericUpDown.Value
'Case "@money_tree_up", "@money_tree_down", "@money_tree_level_0", "@money_tree_level_5", "@money_tree_level_10", "@money_tree_level_15" 'Tree Up or Tree Down                                                              winNumber
'Case "@fifty_fifty_execute" '50:50 AskQuestionButton                                                                                 AnswerATextLabel.Text & AnswerBTextLabel.Text & AnswerCTextLabel.Text & AnswerDTextLabel.Text
'Case "@paf_start" 'PAF AskQuestionButton                                                                                                                                           ---
'Case "@paf_clock_start" 'PAF EnableAnswerAButton                                                                                                                                           ---
'Case "@paf_clock_stop" 'PAF EnableAnswerBButton                                                                                                                                           ---
'Case "@paf_closed" 'PAF closed                                                                                                                                             ---
'Case "@ata_start_voting" 'ATA EnableAnswerAButton                                                                                                                                           ---
'Case "@ata_execute" 'ATA EnableAnswerBButton                              AskTheAudienceForm.percentsA & AskTheAudienceForm.percentsB & AskTheAudienceForm.percentsC & AskTheAudienceForm.percentsD & AskTheAudienceForm.AnswerAPercentNumericUpDown.Value & _
'                                                                 & AskTheAudienceForm.AnswerBPercentNumericUpDown.Value & AskTheAudienceForm.AnswerCPercentNumericUpDown.Value & AskTheAudienceForm.AnswerDPercentNumericUpDown.Value & HostMessageTextBox.Text
'Case "@ata_closed" 'ATA closed                                                                                                                                             ---
