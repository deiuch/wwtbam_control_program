Public Class Project
    Public ini(20) As String 'Массив файла .ini
    Public FileNameQ As String 'Путь и имя файла базы вопросов
    Public questionText As String 'Текст выбранного вопроса
    Dim currentBlock0(,) As String 'Временный массив
    Public currentBlock1(150, 8) As String 'Массив русификации
    Public currentBlock2(,) As String 'Массив вопросов
    Dim rightAnswerNumber As Integer 'Номер правильного ответа (1-4) РЕЖИССЁРУ (см. ListBox1; numberRightAnswer то же самое ДЛЯ ВСЕХ)
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
        Audience.Label9.Visible = False
        Audience.Label21.Visible = False
        Audience.Label31.Visible = False
        NumericUpDown2.Value = FormStart.NumericUpDown2.Value
        NumericUpDown3.Value = FormStart.NumericUpDown3.Value
        NumericUpDown4.Value = FormStart.NumericUpDown4.Value
        NumericUpDown5.Value = FormStart.NumericUpDown5.Value
        NumericUpDown6.Value = FormStart.NumericUpDown6.Value
        NumericUpDown7.Value = FormStart.NumericUpDown7.Value
        Me.MaximizeBox = False
        Host.Show()
        Player.Show()
        Audience.Show()
        If FormStart.CheckBox1.Checked = False Then
            Host.Hide()
            CheckBox7.Checked = False
        End If
        If FormStart.CheckBox2.Checked = False Then
            Player.Hide()
            CheckBox8.Checked = False
        End If
        If FormStart.CheckBox3.Checked = False Then
            Audience.Hide()
            CheckBox9.Checked = False
        End If
        Host.Location = New Point(NumericUpDown2.Value, NumericUpDown3.Value)
        Player.Location = New Point(NumericUpDown4.Value, NumericUpDown5.Value)
        Audience.Location = New Point(NumericUpDown6.Value, NumericUpDown7.Value)
        FormStart.Close()
        Host.PictureBox0.Size = New System.Drawing.Size(1024, 768)
        Player.PictureBox0.Size = New System.Drawing.Size(1024, 768)
        Audience.PictureBox0.Size = New System.Drawing.Size(1024, 768)
        sourcePath = CurDir() & "\Source" 'Задание пути ресурсной папки
        langSource = CurDir() & currentBlock1(3, 3)
        TextBox1.Text = ini(12)
        TextBox2.Text = ini(13)
        'Подсвечивание кнопок-подсказок
        Button16.BackColor = Color.FromArgb(255, 128, 128)
        Button53.BackColor = Color.FromArgb(255, 128, 128)
        Button24.BackColor = Color.FromArgb(255, 128, 128)
        Button30.BackColor = Color.Green
        'Перевод "B" Project
        Text = currentBlock1(21, 3) '0
        Label2.Text = currentBlock1(22, 3) '1
        Label1.Text = currentBlock1(23, 3) '2
        Button46.Text = currentBlock1(24, 3) '3
        Button1.Text = currentBlock1(25, 3) '4
        Label6.Text = currentBlock1(26, 3) '5
        Button2.Text = currentBlock1(27, 3) '6
        Button3.Text = currentBlock1(28, 3) '7
        Button4.Text = currentBlock1(29, 3) '8
        Button5.Text = currentBlock1(30, 3) '9
        Button6.Text = currentBlock1(31, 3) '10
        Label4.Text = currentBlock1(32, 3) '11
        Button7.Text = currentBlock1(33, 3) '12
        Label8.Text = currentBlock1(34, 3) '13
        Button8.Text = currentBlock1(35, 3) '14
        Button9.Text = currentBlock1(36, 3) '15
        Button10.Text = currentBlock1(37, 3) '16
        Button11.Text = currentBlock1(38, 3) '17
        Label7.Text = currentBlock1(39, 3) '18 |Right Answer|Wrong Answer|
        Button12.Text = currentBlock1(40, 3) '19
        Button13.Text = currentBlock1(41, 3) '20
        Button14.Text = currentBlock1(42, 3) '21 |Hide Hint|
        Label15.Text = currentBlock1(43, 3) '22
        Button44.Text = currentBlock1(44, 3) '23
        Button16.Text = currentBlock1(45, 3) '24 |Hide logo|
        Label9.Text = currentBlock1(46, 3) '25
        Button17.Text = currentBlock1(47, 3) '26
        Button15.Text = currentBlock1(48, 3) '27
        Button18.Text = currentBlock1(49, 3) '28
        CheckBox1.Text = currentBlock1(50, 3) '29
        CheckBox2.Text = currentBlock1(51, 3) '30
        CheckBox3.Text = currentBlock1(52, 3) '31
        Button19.Text = currentBlock1(53, 3) '32 |Hide panel|
        Button45.Text = currentBlock1(54, 3) '33
        Button24.Text = currentBlock1(55, 3) '34
        Label10.Text = currentBlock1(56, 3) '35
        Button20.Text = currentBlock1(57, 3) '36
        Button47.Text = currentBlock1(58, 3) '37
        Button48.Text = currentBlock1(59, 3) '38
        CheckBox10.Text = currentBlock1(60, 3) '39
        Button42.Text = currentBlock1(61, 3) '40
        Button43.Text = currentBlock1(62, 3) '41
        Label11.Text = currentBlock1(63, 3) '42
        Button53.Text = currentBlock1(64, 3) '43
        Button22.Text = currentBlock1(65, 3) '44
        Button23.Text = currentBlock1(66, 3) '45
        Button25.Text = currentBlock1(67, 3) '46
        Button29.Text = currentBlock1(68, 3) '47
        Button26.Text = currentBlock1(69, 3) '48
        Button27.Text = currentBlock1(70, 3) '49
        Button28.Text = currentBlock1(71, 3) '50
        Button30.Text = currentBlock1(72, 3) '51
        Button31.Text = currentBlock1(73, 3) '52
        Button32.Text = currentBlock1(74, 3) '53
        Button33.Text = currentBlock1(75, 3) '54
        Button34.Text = currentBlock1(76, 3) '55
        Button35.Text = currentBlock1(77, 3) '56
        Button36.Text = currentBlock1(78, 3) '57
        Button37.Text = currentBlock1(79, 3) '58
        Button38.Text = currentBlock1(80, 3) '59
        Button39.Text = currentBlock1(81, 3) '60
        Button40.Text = currentBlock1(82, 3) '61
        Button41.Text = currentBlock1(83, 3) '62
        Label12.Text = currentBlock1(84, 3) '63
        Label3.Text = currentBlock1(85, 3) '64
        Label23.Text = currentBlock1(86, 3) '65
        Label24.Text = currentBlock1(87, 3) '66
        Label13.Text = currentBlock1(88, 3) '67
        CheckBox4.Text = currentBlock1(89, 3) '68
        CheckBox5.Text = currentBlock1(90, 3) '69
        CheckBox6.Text = currentBlock1(91, 3) '70
        Label14.Text = currentBlock1(92, 3) '71
        CheckBox7.Text = currentBlock1(93, 3) '72
        CheckBox8.Text = currentBlock1(94, 3) '73
        CheckBox9.Text = currentBlock1(95, 3) '74
        Label21.Text = currentBlock1(96, 3) '75
        TextBox11.Text = currentBlock1(97, 3) '76
        Button21.Text = currentBlock1(98, 3) '77
        Host.PictureBox0.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LOGO_FEEL.png")
        Player.PictureBox0.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LOGO_FEEL.png")
        Audience.PictureBox0.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LOGO_FEEL.png")
        Host.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\BG4.jpg")
        Audience.PictureBox1.BackgroundImage = System.Drawing.Bitmap.FromFile("source\QUESTION.png")
        PictureBox1.BackgroundImage = System.Drawing.Bitmap.FromFile("source\QUESTION.png")
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        PictureBox6.ImageLocation = langSource & "\TREE\TREE_0.png"
        Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_0.png"
        Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_0.png"
        Audience.PictureBox6.ImageLocation = langSource & "\TREE\TREE_0.png"
        PictureBox7.ImageLocation = "source\LIFELINES\000.png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\000.png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\000.png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\000.png"
        Host.PictureBox12.ImageLocation = "source\GRAPH COLUMN.png"
        Host.PictureBox11.ImageLocation = "source\GRAPH COLUMN.png"
        Host.PictureBox10.ImageLocation = "source\GRAPH COLUMN.png"
        Host.PictureBox9.ImageLocation = "source\GRAPH COLUMN.png"
        Player.PictureBox11.ImageLocation = "source\GRAPH COLUMN.png"
        Player.PictureBox10.ImageLocation = "source\GRAPH COLUMN.png"
        Player.PictureBox9.ImageLocation = "source\GRAPH COLUMN.png"
        Player.PictureBox1.ImageLocation = "source\GRAPH COLUMN.png"
        Audience.PictureBox12.ImageLocation = "source\GRAPH COLUMN.png"
        Audience.PictureBox11.ImageLocation = "source\GRAPH COLUMN.png"
        Audience.PictureBox10.ImageLocation = "source\GRAPH COLUMN.png"
        Audience.PictureBox9.ImageLocation = "source\GRAPH COLUMN.png"
        'Смена шрифта
        Label16.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Label17.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Label18.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Label19.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Label20.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Host.Label16.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Host.Label17.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Host.Label18.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Host.Label19.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Host.Label20.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Player.Label16.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Player.Label17.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Player.Label18.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Player.Label19.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Player.Label20.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.Label8.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Audience.Label9.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.Label10.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.Label11.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.Label12.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.Label16.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Audience.Label17.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.Label18.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.Label19.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Audience.Label20.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        'ATA
        Host.Label10.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        Host.Label9.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        Host.Label8.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        Host.Label7.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)) - 6)
        Player.Label1.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Player.Label2.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Player.Label3.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Player.Label4.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Audience.Label1.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Audience.Label2.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Audience.Label3.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        Audience.Label4.Font = New Font(currentBlock1(6, 3), Int(currentBlock1(6, 4)))
        NumericUpDown1.Value = 1
        hostPort = Int(TextBox2.Text)
        Server.Start(1, hostPort)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        'Изменение порта соединения
        Server.Stop()
        hostPort = Int(TextBox2.Text)
        Server.Start(1, hostPort)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Ask choosed question ДЛЯ ВСЕХ
        Button24.PerformClick()
        Label5.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(ListBox1.SelectedIndex + 1, 4) & " B: " & currentBlock2(ListBox1.SelectedIndex + 1, 5) & " C: " & currentBlock2(ListBox1.SelectedIndex + 1, 6) & " D: " & currentBlock2(ListBox1.SelectedIndex + 1, 7) & ". " & currentBlock1(143, 3) & " " & rightAnswerText
        questionText = currentBlock2(ListBox1.SelectedIndex + 1, 3)
        Label16.Text = questionText
        numberRightAnswer = rightAnswerNumber
        Button14.BackColor = Color.FromArgb(255, 192, 128)
        Button14.Text = currentBlock1(42, 3) 'Show Hint
        Host.Label5.Text = ""
        Host.Label11.Text = ""
        commentShow = False
        If TextBox10.Text.StartsWith("-A:") And TextBox10.Text.EndsWith("%") Then
            Button45.PerformClick()
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
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button1|" & questionText & "|" & Str(numberRightAnswer) & "|" & questionNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        Button2.BackColor = Color.Yellow
        Button3.BackColor = Color.Yellow
        Button4.BackColor = Color.Yellow
        Button5.BackColor = Color.Yellow
        Button6.BackColor = Color.Yellow
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        Button10.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button39_Click(sender As Object, e As EventArgs) Handles Button39.Click
        'Stop Sound
        My.Computer.Audio.Stop()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        'Lights down (LX), clear forms
        Button20.BackColor = Color.White
        Timer2.Stop()
        Player.PictureBox12.Visible = False
        Audience.PictureBox14.Visible = False
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        Label20.Text = ""
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        Player.Label16.Visible = True
        Player.Label17.Visible = True
        Player.Label18.Visible = True
        Player.Label19.Visible = True
        Player.Label20.Visible = True
        Player.PictureBox2.Visible = True
        Player.PictureBox3.Visible = True
        Player.PictureBox4.Visible = True
        Player.PictureBox5.Visible = True
        Player.PictureBox13.Visible = False
        Player.Label5.Visible = False
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        Audience.Label16.Visible = True
        Audience.Label17.Visible = True
        Audience.Label18.Visible = True
        Audience.Label19.Visible = True
        Audience.Label20.Visible = True
        Audience.PictureBox1.Visible = True
        Audience.PictureBox2.Visible = True
        Audience.PictureBox3.Visible = True
        Audience.PictureBox4.Visible = True
        Audience.PictureBox5.Visible = True
        Audience.PictureBox13.Visible = False
        Audience.Label5.Visible = False
        Label17.BackColor = Color.FromArgb(42, 42, 42)
        Label17.ForeColor = Color.White
        Label18.BackColor = Color.FromArgb(42, 42, 42)
        Label18.ForeColor = Color.White
        Label19.BackColor = Color.FromArgb(42, 42, 42)
        Label19.ForeColor = Color.White
        Label20.BackColor = Color.FromArgb(42, 42, 42)
        Label20.ForeColor = Color.White
        Label7.BackColor = Color.DarkGray
        Label7.Text = currentBlock1(39, 3) 'Answer Indicator
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
        If NumericUpDown1.Value < 15 And NumericUpDown1.Value > -1 Then
            NumericUpDown1.Value = NumericUpDown1.Value + 1
        End If
        CheckBox10.Checked = False
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button13|" & NumericUpDown1.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Подсвечивание кнопок-подсказок
        Button1.BackColor = Color.Yellow
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        Button10.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
        Button30.BackColor = Color.White
        Button33.BackColor = Color.White
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        'A is a final answer
        Select Case numberRightAnswer
            Case 1
                Host.Label5.Text = "A"
            Case 2
                Host.Label5.Text = "B"
            Case 3
                Host.Label5.Text = "C"
            Case 4
                Host.Label5.Text = "D"
        End Select
        playerAnswerNumber = 1
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_ORANGE.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        Label17.BackColor = Color.FromArgb(244, 155, 15)
        Label18.BackColor = Color.FromArgb(42, 42, 42)
        Label19.BackColor = Color.FromArgb(42, 42, 42)
        Label20.BackColor = Color.FromArgb(42, 42, 42)
        Label17.ForeColor = Color.Black
        Label18.ForeColor = Color.White
        Label19.ForeColor = Color.White
        Label20.ForeColor = Color.White
        Button14.BackColor = Color.FromArgb(128, 255, 255)
        Button14.Text = currentBlock1(42, 4) 'Hide Hint
        Host.Label11.Text = currentBlock2(ListBox1.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            Shell("source\BAT\stop_back_music1.bat")
            winampOn = 0
        End If
        If CheckBox10.Checked = False Then
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
            Label7.BackColor = Color.FromArgb(0, 255, 0)
            Label7.Text = currentBlock1(39, 4) 'Right Answer
        Else
            Label7.BackColor = Color.FromArgb(255, 0, 0)
            Label7.Text = currentBlock1(39, 5) 'Wrong Answer
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button8|" & currentBlock2(ListBox1.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        Button10.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.Yellow
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        'B is a final answer
        Select Case numberRightAnswer
            Case 1
                Host.Label5.Text = "A"
            Case 2
                Host.Label5.Text = "B"
            Case 3
                Host.Label5.Text = "C"
            Case 4
                Host.Label5.Text = "D"
        End Select
        playerAnswerNumber = 2
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_ORANGE.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        Label17.BackColor = Color.FromArgb(42, 42, 42)
        Label18.BackColor = Color.FromArgb(244, 155, 15)
        Label19.BackColor = Color.FromArgb(42, 42, 42)
        Label20.BackColor = Color.FromArgb(42, 42, 42)
        Label17.ForeColor = Color.White
        Label18.ForeColor = Color.Black
        Label19.ForeColor = Color.White
        Label20.ForeColor = Color.White
        Button14.BackColor = Color.FromArgb(128, 255, 255)
        Button14.Text = currentBlock1(42, 4) 'Hide Hint
        Host.Label11.Text = currentBlock2(ListBox1.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            Shell("source\BAT\stop_back_music1.bat")
            winampOn = 0
        End If
        If CheckBox10.Checked = False Then
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
            Label7.BackColor = Color.FromArgb(0, 255, 0)
            Label7.Text = currentBlock1(39, 4) 'Right Answer
        Else
            Label7.BackColor = Color.FromArgb(255, 0, 0)
            Label7.Text = currentBlock1(39, 5) 'Wrong Answer
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button9|" & currentBlock2(ListBox1.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        Button10.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.Yellow
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        'C is a final answer
        Select Case numberRightAnswer
            Case 1
                Host.Label5.Text = "A"
            Case 2
                Host.Label5.Text = "B"
            Case 3
                Host.Label5.Text = "C"
            Case 4
                Host.Label5.Text = "D"
        End Select
        playerAnswerNumber = 3
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_ORANGE.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        Label17.BackColor = Color.FromArgb(42, 42, 42)
        Label18.BackColor = Color.FromArgb(42, 42, 42)
        Label19.BackColor = Color.FromArgb(244, 155, 15)
        Label20.BackColor = Color.FromArgb(42, 42, 42)
        Label17.ForeColor = Color.White
        Label18.ForeColor = Color.White
        Label19.ForeColor = Color.Black
        Label20.ForeColor = Color.White
        Button14.BackColor = Color.FromArgb(128, 255, 255)
        Button14.Text = currentBlock1(42, 4) 'Hide Hint
        Host.Label11.Text = currentBlock2(ListBox1.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            Shell("source\BAT\stop_back_music1.bat")
            winampOn = 0
        End If
        If CheckBox10.Checked = False Then
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
            Label7.BackColor = Color.FromArgb(0, 255, 0)
            Label7.Text = currentBlock1(39, 4) 'Right Answer
        Else
            Label7.BackColor = Color.FromArgb(255, 0, 0)
            Label7.Text = currentBlock1(39, 5) 'Wrong Answer
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button10|" & currentBlock2(ListBox1.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        Button10.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.Yellow
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'D is a final answer
        Select Case numberRightAnswer
            Case 1
                Host.Label5.Text = "A"
            Case 2
                Host.Label5.Text = "B"
            Case 3
                Host.Label5.Text = "C"
            Case 4
                Host.Label5.Text = "D"
        End Select
        playerAnswerNumber = 4
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_ORANGE.png")
        Label17.BackColor = Color.FromArgb(42, 42, 42)
        Label18.BackColor = Color.FromArgb(42, 42, 42)
        Label19.BackColor = Color.FromArgb(42, 42, 42)
        Label20.BackColor = Color.FromArgb(244, 155, 15)
        Label17.ForeColor = Color.White
        Label18.ForeColor = Color.White
        Label19.ForeColor = Color.White
        Label20.ForeColor = Color.Black
        Button14.BackColor = Color.FromArgb(128, 255, 255)
        Button14.Text = currentBlock1(42, 4) 'Hide Hint
        Host.Label11.Text = currentBlock2(ListBox1.SelectedIndex + 1, 9)
        commentShow = True
        If winampOn <> 0 And questionNumber > 5 Then
            Shell("source\BAT\stop_back_music1.bat")
            winampOn = 0
        End If
        If CheckBox10.Checked = False Then
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
            Label7.BackColor = Color.FromArgb(0, 255, 0)
            Label7.Text = currentBlock1(39, 4) 'Right Answer
        Else
            Label7.BackColor = Color.FromArgb(255, 0, 0)
            Label7.Text = currentBlock1(39, 5) 'Wrong Answer
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button11|" & currentBlock2(ListBox1.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        Button10.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.Yellow
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        'Check the correct answer
        Host.Label1.Text = "Qaway:" & Str(15 - questionNumber)
        Button12.BackColor = Color.Orange
        Select Case numberRightAnswer
            Case 1
                PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_GREEN.png")
                Label17.BackColor = Color.FromArgb(93, 179, 87)
                Label17.ForeColor = Color.Black
            Case 2
                PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_GREEN.png")
                Label18.BackColor = Color.FromArgb(93, 179, 87)
                Label18.ForeColor = Color.Black
            Case 3
                PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_GREEN.png")
                Label19.BackColor = Color.FromArgb(93, 179, 87)
                Label19.ForeColor = Color.Black
            Case 4
                PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_GREEN.png")
                Label20.BackColor = Color.FromArgb(93, 179, 87)
                Label20.ForeColor = Color.Black
        End Select
        If CheckBox10.Checked = False Then
            If playerAnswerNumber = numberRightAnswer Then
                Timer2.Start()
                Select Case questionNumber
                    Case 0
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 0
                        Host.Label2.Text = "100" 'Возможный выигрыш
                        Host.Label3.Text = "0" 'Текущий выигрыш
                        Host.Label4.Text = "0" 'Возможная потеря
                        Host.Label6.Text = "0" 'Несгораемая сумма
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                    Case 1
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 1
                        Host.Label2.Text = "200"
                        Host.Label3.Text = "100"
                        Host.Label4.Text = "100"
                        Host.Label6.Text = "0"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    Case 2
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 2
                        Host.Label2.Text = "300"
                        Host.Label3.Text = "200"
                        Host.Label4.Text = "200"
                        Host.Label6.Text = "0"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    Case 3
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 3
                        Host.Label2.Text = "500"
                        Host.Label3.Text = "200"
                        Host.Label4.Text = "200"
                        Host.Label6.Text = "0"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    Case 4
                        My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 4
                        Host.Label2.Text = "1,000"
                        Host.Label3.Text = "500"
                        Host.Label4.Text = "500"
                        Host.Label6.Text = "0"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    Case 5
                        My.Computer.Audio.Play("source\MUSIC\R1000 Winner.wav", AudioPlayMode.Background)
                        Shell("source\BAT\stop_back_music1.bat")
                        winampOn = 0
                        winNumber = 5
                        Host.Label2.Text = "2,000"
                        Host.Label3.Text = "1,000"
                        Host.Label4.Text = "0"
                        Host.Label6.Text = "1,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    Case 6
                        My.Computer.Audio.Play("source\MUSIC\Q6 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 6
                        Host.Label2.Text = "4,000"
                        Host.Label3.Text = "2,000"
                        Host.Label4.Text = "1,000"
                        Host.Label6.Text = "1,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    Case 7
                        My.Computer.Audio.Play("source\MUSIC\Q7 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 7
                        Host.Label2.Text = "8,000"
                        Host.Label3.Text = "4,000"
                        Host.Label4.Text = "3,000"
                        Host.Label6.Text = "1,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    Case 8
                        My.Computer.Audio.Play("source\MUSIC\Q8 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 8
                        Host.Label2.Text = "16,000"
                        Host.Label3.Text = "8,000"
                        Host.Label4.Text = "7,000"
                        Host.Label6.Text = "1,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    Case 9
                        My.Computer.Audio.Play("source\MUSIC\Q9 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 9
                        Host.Label2.Text = "32,000"
                        Host.Label3.Text = "16,000"
                        Host.Label4.Text = "15,000"
                        Host.Label6.Text = "1,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    Case 10
                        My.Computer.Audio.Play("source\MUSIC\R32000 - Winner.wav", AudioPlayMode.Background)
                        winNumber = 10
                        Host.Label2.Text = "64,000"
                        Host.Label3.Text = "32,000"
                        Host.Label4.Text = "0"
                        Host.Label6.Text = "32,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    Case 11
                        My.Computer.Audio.Play("source\MUSIC\Q11 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 11
                        Host.Label2.Text = "125,000"
                        Host.Label3.Text = "64,000"
                        Host.Label4.Text = "32,000"
                        Host.Label6.Text = "32,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    Case 12
                        My.Computer.Audio.Play("source\MUSIC\Q12 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 12
                        Host.Label2.Text = "250,000"
                        Host.Label3.Text = "125,000"
                        Host.Label4.Text = "93,000"
                        Host.Label6.Text = "32,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    Case 13
                        My.Computer.Audio.Play("source\MUSIC\Q13 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 13
                        Host.Label2.Text = "500,000"
                        Host.Label3.Text = "250,000"
                        Host.Label4.Text = "218,000"
                        Host.Label6.Text = "32,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    Case 14
                        My.Computer.Audio.Play("source\MUSIC\Q14 - Yes.wav", AudioPlayMode.Background)
                        winNumber = 14
                        Host.Label2.Text = "1,000,000"
                        Host.Label3.Text = "500,000"
                        Host.Label4.Text = "468,000"
                        Host.Label6.Text = "32,000"
                        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    Case 15
                        Host.Label1.Text = "Qaway: 0"
                        My.Computer.Audio.Play("source\MUSIC\R1 000 000 - Winner.wav", AudioPlayMode.Background)
                        winNumber = 15
                        Host.Label2.Text = "1,000,000"
                        Host.Label3.Text = "1,000,000"
                        Host.Label4.Text = "0"
                        Host.Label6.Text = "1,000,000"
                        Timer2.Stop()
                        Timer3.Start()
                        Player.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\MILLIONAIRE.png")
                        Player.Label5.Text = TextBox11.Text
                        Audience.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\MILLIONAIRE.png")
                        Audience.Label5.Text = TextBox11.Text
                        CheckBox10.Checked = True
                        Button20.BackColor = Color.Blue
                        'Подсвечивание кнопок-подсказок
                        Button1.BackColor = Color.White
                        Button2.BackColor = Color.White
                        Button3.BackColor = Color.White
                        Button4.BackColor = Color.White
                        Button5.BackColor = Color.White
                        Button6.BackColor = Color.White
                        Button8.BackColor = Color.White
                        Button9.BackColor = Color.White
                        Button10.BackColor = Color.White
                        Button11.BackColor = Color.White
                        Button12.BackColor = Color.White
                        Button13.BackColor = Color.White
                        Button33.BackColor = Color.Yellow
                End Select
                If winNumber < 15 Then
                    Button1.BackColor = Color.White
                    Button2.BackColor = Color.White
                    Button3.BackColor = Color.White
                    Button4.BackColor = Color.White
                    Button5.BackColor = Color.White
                    Button6.BackColor = Color.White
                    Button8.BackColor = Color.White
                    Button9.BackColor = Color.White
                    Button10.BackColor = Color.White
                    Button11.BackColor = Color.White
                    Button13.BackColor = Color.Yellow
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
                Timer3.Start()
                Player.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                Audience.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                CheckBox10.Checked = True
                'Подсвечивание кнопок-подсказок
                Button1.BackColor = Color.White
                Button2.BackColor = Color.White
                Button3.BackColor = Color.White
                Button4.BackColor = Color.White
                Button5.BackColor = Color.White
                Button6.BackColor = Color.White
                Button8.BackColor = Color.White
                Button9.BackColor = Color.White
                Button10.BackColor = Color.White
                Button11.BackColor = Color.White
                Button12.BackColor = Color.White
                Button13.BackColor = Color.White
                Button33.BackColor = Color.Yellow
            End If
        Else
            Timer3.Start()
            If winNumber < 15 Then
                Player.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                Audience.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
            End If
            'Подсвечивание кнопок-подсказок
            Button1.BackColor = Color.White
            Button2.BackColor = Color.White
            Button3.BackColor = Color.White
            Button4.BackColor = Color.White
            Button5.BackColor = Color.White
            Button6.BackColor = Color.White
            Button8.BackColor = Color.White
            Button9.BackColor = Color.White
            Button10.BackColor = Color.White
            Button11.BackColor = Color.White
            Button12.BackColor = Color.White
            Button13.BackColor = Color.White
            Button33.BackColor = Color.Yellow
        End If
        PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                If winNumber = 15 Then
                    .Command = "@millionaire|" & TextBox11.Text & "|"
                Else
                    .Command = "@button12|" & CheckBox10.Checked & "|" & winNumber & "|"
                End If
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Таймер показа выигрыша
        Player.Label16.Visible = False
        Player.Label17.Visible = False
        Player.Label18.Visible = False
        Player.Label19.Visible = False
        Player.Label20.Visible = False
        Player.PictureBox2.Visible = False
        Player.PictureBox3.Visible = False
        Player.PictureBox4.Visible = False
        Player.PictureBox5.Visible = False
        Player.PictureBox12.Visible = True
        Audience.Label16.Visible = False
        Audience.Label17.Visible = False
        Audience.Label18.Visible = False
        Audience.Label19.Visible = False
        Audience.Label20.Visible = False
        Audience.PictureBox1.Visible = False
        Audience.PictureBox2.Visible = False
        Audience.PictureBox3.Visible = False
        Audience.PictureBox4.Visible = False
        Audience.PictureBox5.Visible = False
        Audience.PictureBox14.Visible = True
        Player.BackgroundImage = Nothing
        Button12.BackColor = Color.White
        Timer2.Stop()
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        'Таймер панели TPM
        If winNumber = 15 Then
            Player.Label5.Visible = True
            Audience.Label5.Visible = True
        End If
        Player.Label16.Visible = False
        Player.Label17.Visible = False
        Player.Label18.Visible = False
        Player.Label19.Visible = False
        Player.Label20.Visible = False
        Player.PictureBox2.Visible = False
        Player.PictureBox3.Visible = False
        Player.PictureBox4.Visible = False
        Player.PictureBox5.Visible = False
        Player.PictureBox13.Visible = True
        Audience.Label16.Visible = False
        Audience.Label17.Visible = False
        Audience.Label18.Visible = False
        Audience.Label19.Visible = False
        Audience.Label20.Visible = False
        Audience.PictureBox1.Visible = False
        Audience.PictureBox2.Visible = False
        Audience.PictureBox3.Visible = False
        Audience.PictureBox4.Visible = False
        Audience.PictureBox5.Visible = False
        Audience.PictureBox13.Visible = True
        Player.BackgroundImage = Nothing
        Button12.BackColor = Color.White
        Button20.BackColor = Color.Aqua
        Timer3.Stop()
    End Sub

    Private Sub Button53_Click(sender As Object, e As EventArgs) Handles Button53.Click
        'Opening Titles
        batFileName = Chr(34) & sourcePath & "\MUSIC\Millionaire Opening.wav" & Chr(34)
        Shell("source\BAT\run2_back_music1.bat " & batFileName)
        winampOn = 1
        If splashOn = False Then
            Button16.PerformClick()
        End If
        Button24.PerformClick()
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button16|" & splashOn & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        Button22.BackColor = Color.FromArgb(255, 128, 128)
        Button53.BackColor = Color.White
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        'Host Entrance
        My.Computer.Audio.Play(sourcePath & "\MUSIC\Host Entrance #2.wav")
        Shell("source\BAT\stopfade_back_music1.bat")
        winampOn = 0
        Button22.BackColor = Color.White
        Button23.BackColor = Color.FromArgb(255, 128, 128)
        Button41.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        'Let's Play
        batFileName = Chr(34) & sourcePath & "\MUSIC\Lets Play.wav" & Chr(34)
        Shell("source\BAT\run2_back_music1.bat " & batFileName)
        winampOn = 1
        My.Computer.Audio.Stop()
        NumericUpDown1.Value = 1
        Button23.BackColor = Color.White
        Button29.BackColor = Color.FromArgb(255, 128, 128)
        Button35.BackColor = Color.White
        Button41.BackColor = Color.White
    End Sub

    Private Sub Button29_Click(sender As Object, e As EventArgs) Handles Button29.Click
        'LX To Centre
        My.Computer.Audio.Play("source\MUSIC\LX To Centre.wav", AudioPlayMode.Background)
        Shell("source\BAT\stopfade_back_music1.bat " & batFileName)
        winampOn = 0
        Button29.BackColor = Color.White
        Button25.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub Button25_Click(sender As Object, e As EventArgs) Handles Button25.Click
        'Lifeline Explanations
        If winampOn <> 1 Then
            batFileName = Chr(34) & sourcePath & "\MUSIC\Lifeline Explanations.wav" & Chr(34)
            Shell("source\BAT\run_back_music1.bat " & batFileName)
            winampOn = 1
        End If
        Button25.BackColor = Color.White
        'Скрытие Splash Screen
        Host.PictureBox0.Visible = False
        Player.PictureBox0.Visible = False
        Audience.PictureBox0.Visible = False
        splashOn = False
        Button16.Text = currentBlock1(45, 3) 'Show logo
        Button16.BackColor = Color.White
        Button24.PerformClick()
        Button30.BackColor = Color.Green
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button25|" & activ50 & "|" & activPAF & "|" & activATA & "|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        '50:50 Ping
        My.Computer.Audio.Play("source\MUSIC\50-50 Ping.wav", AudioPlayMode.Background)
        PictureBox7.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Timer1.Start()
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button26|1|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        'PAF Ping
        My.Computer.Audio.Play("source\MUSIC\Phone a Friend Ping.wav", AudioPlayMode.Background)
        PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Timer1.Start()
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button27|" & activ50 & "|1|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        'ATA Ping
        My.Computer.Audio.Play("source\MUSIC\Audience Ping.wav", AudioPlayMode.Background)
        PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Timer1.Start()
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button28|" & activ50 & "|" & activPAF & "|1|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button30_Click(sender As Object, e As EventArgs) Handles Button30.Click
        'Start the game
        Player.PictureBox12.Visible = False
        Audience.PictureBox14.Visible = False
        If winNumber < 15 Then NumericUpDown1.Value = winNumber + 1 Else NumericUpDown1.Value = 15
        Host.Label1.Text = "Qaway:" & Str(15 - winNumber)
        If winNumber < 15 Then
            Select Case questionNumber
                Case 0, 1
                    Host.Label2.Text = "100" 'Возможный выигрыш
                    Host.Label3.Text = "0" 'Текущий выигрыш
                    Host.Label4.Text = "0" 'Возможная потеря
                    Host.Label6.Text = "0" 'Несгораемая сумма
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                Case 2
                    Host.Label2.Text = "200"
                    Host.Label3.Text = "100"
                    Host.Label4.Text = "100"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                Case 3
                    Host.Label2.Text = "300"
                    Host.Label3.Text = "200"
                    Host.Label4.Text = "200"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                Case 4
                    Host.Label2.Text = "500"
                    Host.Label3.Text = "200"
                    Host.Label4.Text = "200"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                Case 5
                    Host.Label2.Text = "1,000"
                    Host.Label3.Text = "500"
                    Host.Label4.Text = "500"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                Case 6
                    Host.Label2.Text = "2,000"
                    Host.Label3.Text = "1,000"
                    Host.Label4.Text = "0"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                Case 7
                    Host.Label2.Text = "4,000"
                    Host.Label3.Text = "2,000"
                    Host.Label4.Text = "1,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                Case 8
                    Host.Label2.Text = "8,000"
                    Host.Label3.Text = "4,000"
                    Host.Label4.Text = "3,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                Case 9
                    Host.Label2.Text = "16,000"
                    Host.Label3.Text = "8,000"
                    Host.Label4.Text = "7,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                Case 10
                    Host.Label2.Text = "32,000"
                    Host.Label3.Text = "16,000"
                    Host.Label4.Text = "15,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                Case 11
                    Host.Label2.Text = "64,000"
                    Host.Label3.Text = "32,000"
                    Host.Label4.Text = "0"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                Case 12
                    Host.Label2.Text = "125,000"
                    Host.Label3.Text = "64,000"
                    Host.Label4.Text = "32,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                Case 13
                    Host.Label2.Text = "250,000"
                    Host.Label3.Text = "125,000"
                    Host.Label4.Text = "93,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                Case 14
                    Host.Label2.Text = "500,000"
                    Host.Label3.Text = "250,000"
                    Host.Label4.Text = "218,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                Case 15
                    Host.Label2.Text = "1,000,000"
                    Host.Label3.Text = "500,000"
                    Host.Label4.Text = "468,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
            End Select
        End If
        Host.Label5.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        Label20.Text = ""
        Player.Label16.Visible = True
        Player.Label17.Visible = True
        Player.Label18.Visible = True
        Player.Label19.Visible = True
        Player.Label20.Visible = True
        Player.PictureBox2.Visible = True
        Player.PictureBox3.Visible = True
        Player.PictureBox4.Visible = True
        Player.PictureBox5.Visible = True
        Player.PictureBox13.Visible = False
        Player.Label5.Visible = False
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        Audience.Label16.Visible = True
        Audience.Label17.Visible = True
        Audience.Label18.Visible = True
        Audience.Label19.Visible = True
        Audience.Label20.Visible = True
        Audience.PictureBox1.Visible = True
        Audience.PictureBox2.Visible = True
        Audience.PictureBox3.Visible = True
        Audience.PictureBox4.Visible = True
        Audience.PictureBox5.Visible = True
        Audience.PictureBox13.Visible = False
        Audience.Label5.Visible = False
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        Label17.BackColor = Color.FromArgb(42, 42, 42)
        Label17.ForeColor = Color.White
        Label18.BackColor = Color.FromArgb(42, 42, 42)
        Label18.ForeColor = Color.White
        Label19.BackColor = Color.FromArgb(42, 42, 42)
        Label19.ForeColor = Color.White
        Label20.BackColor = Color.FromArgb(42, 42, 42)
        Label20.ForeColor = Color.White
        Label7.BackColor = Color.DarkGray
        Label7.Text = currentBlock1(39, 3) 'Answer Indicator
        Shell("source\BAT\stop_back_music1.bat")
        winampOn = 0
        My.Computer.Audio.Play("source\MUSIC\Let's See Q1.wav", AudioPlayMode.Background)
        PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Button14.Text = currentBlock1(42, 3) 'Show Hint
        Host.Label11.Text = ""
        commentShow = False
        If TextBox10.Text.StartsWith("-A:") And TextBox10.Text.EndsWith("%") Then
            Button45.PerformClick()
        End If
        CheckBox10.Checked = False
        If Host.Label12.Text = "Message to host" Then Button45.PerformClick()
        'Скрытие Splash Screen
        Host.PictureBox0.Visible = False
        Player.PictureBox0.Visible = False
        Audience.PictureBox0.Visible = False
        splashOn = False
        Button16.Text = currentBlock1(45, 3) 'Show logo
        Button16.BackColor = Color.White
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button30|" & questionNumber & "|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.Yellow
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        Button10.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
        Button14.BackColor = Color.FromArgb(255, 192, 128)
        Button20.BackColor = Color.White
        Button22.BackColor = Color.White
        Button23.BackColor = Color.White
        Button24.BackColor = Color.White
        Button25.BackColor = Color.White
        Button29.BackColor = Color.White
        Button30.BackColor = Color.White
        Button33.BackColor = Color.White
        Button35.BackColor = Color.White
        Button36.BackColor = Color.White
        Button41.BackColor = Color.White
        Button53.BackColor = Color.White
    End Sub

    Private Sub Button31_Click(sender As Object, e As EventArgs) Handles Button31.Click
        'See Yoy Later (P1)
        Shell("source\BAT\stop_back_music1.bat")
        winampOn = 0
        My.Computer.Audio.Play("source\MUSIC\See you later (End of Part 1).wav", AudioPlayMode.Background)
    End Sub

    Private Sub Button32_Click(sender As Object, e As EventArgs) Handles Button32.Click
        'Hello Again (P2)
        My.Computer.Audio.Play("source\MUSIC\Hello Again (Begin of part 2).wav", AudioPlayMode.Background)
    End Sub

    Private Sub Button33_Click(sender As Object, e As EventArgs) Handles Button33.Click
        'Goodbye Punter
        My.Computer.Audio.Play("source\MUSIC\Goodbye Punter.wav", AudioPlayMode.Background)
        Button24.PerformClick()
        Button52.PerformClick()
        NumericUpDown1.Value = 1
        CheckBox1.Checked = True
        CheckBox2.Checked = True
        CheckBox3.Checked = True
        CheckBox10.Checked = False
        If splashOn = False Then
            Button16.PerformClick()
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button33|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        Button10.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
        Button23.BackColor = Color.FromArgb(255, 128, 128)
        Button30.BackColor = Color.Green
        Button33.BackColor = Color.White
        Button35.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub Button34_Click(sender As Object, e As EventArgs) Handles Button34.Click
        'Time's Up
        My.Computer.Audio.Play("source\MUSIC\Time's Up.wav", AudioPlayMode.Background)
        Shell("source\BAT\stop_back_music1.bat")
        winampOn = 0
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button8.BackColor = Color.White
        Button9.BackColor = Color.White
        Button10.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
        Button30.BackColor = Color.White
        Button33.BackColor = Color.White
        Button35.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub Button35_Click(sender As Object, e As EventArgs) Handles Button35.Click
        'Tomorrows Names
        My.Computer.Audio.Play("source\MUSIC\Tomorrows Names.wav", AudioPlayMode.Background)
        If splashOn = False Then Button16.PerformClick()
        'Перекрашивание кнопок-подсказок
        Button23.BackColor = Color.White
        Button35.BackColor = Color.White
        Button36.BackColor = Color.FromArgb(255, 128, 128)
    End Sub

    Private Sub Button36_Click(sender As Object, e As EventArgs) Handles Button36.Click
        'Closing Titles
        My.Computer.Audio.Play("source\MUSIC\Millionaire Closing.wav", AudioPlayMode.Background)
        'Перекрашивание кнопок-подсказок
        Button36.BackColor = Color.White
    End Sub

    Private Sub Button37_Click(sender As Object, e As EventArgs) Handles Button37.Click
        'Stereo Test
        My.Computer.Audio.Play("source\MUSIC\Stereo Test.wav", AudioPlayMode.Background)
    End Sub

    Private Sub Button38_Click(sender As Object, e As EventArgs) Handles Button38.Click
        'SMS Clock
        My.Computer.Audio.Play("source\MUSIC\sms_clock.wav", AudioPlayMode.Background)
    End Sub

    Private Sub Button46_Click_1(sender As Object, e As EventArgs) Handles Button46.Click
        'Open file button
        OpenFileDialog1.FileName = "*.questions"
        OpenFileDialog1.InitialDirectory = CurDir() & "\Bases"
        OpenFileDialog1.CheckFileExists = True
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenFileDialog1.FileName
            Call openfilesdata(FileNameQ)
            ListBox1.SelectedIndex = NumericUpDown1.Value - 1
        End If
    End Sub

    Public Sub openfilesdata(sender As Object)
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        Label22.Text = FileNameQ
        If FileNameQ <> "*.questions" Then
            ListBox1.Enabled = True
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
            REM Заполнение ListBox1
            ListBox1.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    ListBox1.Items.Add(currentBlock0(i1, 2) & ": " & currentBlock0(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            REM /Заполнение ListBox1
            REM /***********************
            Button46.BackColor = Color.White
        Else
            ListBox1.Enabled = False
            ListBox1.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open"" button.")
            Button46.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
            Label22.Text = "Question File Adress (Choose question base file with format ""*.question"")"
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        rightAnswerNumber = Int(currentBlock2(ListBox1.SelectedIndex + 1, 8)) 'Выбор номера правильного ответа из массива
        rightAnswerText = currentBlock2(ListBox1.SelectedIndex + 1, rightAnswerNumber + 3) 'Текст ответа из массива (номер ответа + 3)
        Label5.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(ListBox1.SelectedIndex + 1, 4) & " B: " & currentBlock2(ListBox1.SelectedIndex + 1, 5) & " C: " & currentBlock2(ListBox1.SelectedIndex + 1, 6) & " D: " & currentBlock2(ListBox1.SelectedIndex + 1, 7) & ". " & currentBlock1(143, 3) & " " & rightAnswerText
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        Editor.Show()
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged
        'Смена значения номера вопроса
        questionNumber = NumericUpDown1.Value
        ListBox1.SelectedIndex = questionNumber - 1
        If NumericUpDown1.Value <> 0 Then
            NumericUpDown1.Minimum = 1
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@numericupdown1|" & NumericUpDown1.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Show answer A on graphics
        textAnswerA = currentBlock2(ListBox1.SelectedIndex + 1, 4)
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        Label17.Text = textAnswerA
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button2|" & textAnswerA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        If Label17.Text <> Nothing Then Button2.BackColor = Color.White Else Button2.BackColor = Color.Yellow
        If Label18.Text <> Nothing Then Button3.BackColor = Color.White Else Button3.BackColor = Color.Yellow
        If Label19.Text <> Nothing Then Button4.BackColor = Color.White Else Button4.BackColor = Color.Yellow
        If Label20.Text <> Nothing Then Button5.BackColor = Color.White Else Button5.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button6.BackColor = Color.White Else Button6.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button8.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button9.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button10.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button11.BackColor = Color.Yellow
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Show answer B on graphics
        textAnswerB = currentBlock2(ListBox1.SelectedIndex + 1, 5)
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        Label18.Text = textAnswerB
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button3|" & textAnswerB & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        If Label17.Text <> Nothing Then Button2.BackColor = Color.White Else Button2.BackColor = Color.Yellow
        If Label18.Text <> Nothing Then Button3.BackColor = Color.White Else Button3.BackColor = Color.Yellow
        If Label19.Text <> Nothing Then Button4.BackColor = Color.White Else Button4.BackColor = Color.Yellow
        If Label20.Text <> Nothing Then Button5.BackColor = Color.White Else Button5.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button6.BackColor = Color.White Else Button6.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button8.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button9.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button10.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button11.BackColor = Color.Yellow
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Show answer C on graphics
        textAnswerC = currentBlock2(ListBox1.SelectedIndex + 1, 6)
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        Label19.Text = textAnswerC
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button4|" & textAnswerC & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        If Label17.Text <> Nothing Then Button2.BackColor = Color.White Else Button2.BackColor = Color.Yellow
        If Label18.Text <> Nothing Then Button3.BackColor = Color.White Else Button3.BackColor = Color.Yellow
        If Label19.Text <> Nothing Then Button4.BackColor = Color.White Else Button4.BackColor = Color.Yellow
        If Label20.Text <> Nothing Then Button5.BackColor = Color.White Else Button5.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button6.BackColor = Color.White Else Button6.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button8.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button9.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button10.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button11.BackColor = Color.Yellow
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Show answer D on graphics
        textAnswerD = currentBlock2(ListBox1.SelectedIndex + 1, 7)
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        Label20.Text = textAnswerD
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button5|" & textAnswerD & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        If Label17.Text <> Nothing Then Button2.BackColor = Color.White Else Button2.BackColor = Color.Yellow
        If Label18.Text <> Nothing Then Button3.BackColor = Color.White Else Button3.BackColor = Color.Yellow
        If Label19.Text <> Nothing Then Button4.BackColor = Color.White Else Button4.BackColor = Color.Yellow
        If Label20.Text <> Nothing Then Button5.BackColor = Color.White Else Button5.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button6.BackColor = Color.White Else Button6.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button8.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button9.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button10.BackColor = Color.Yellow
        If Label17.Text <> Nothing And Label18.Text <> Nothing And Label19.Text <> Nothing And Label20.Text <> Nothing Then Button11.BackColor = Color.Yellow
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Show ALL answers on graphics
        questionText = currentBlock2(ListBox1.SelectedIndex + 1, 3)
        textAnswerA = currentBlock2(ListBox1.SelectedIndex + 1, 4)
        textAnswerB = currentBlock2(ListBox1.SelectedIndex + 1, 5)
        textAnswerC = currentBlock2(ListBox1.SelectedIndex + 1, 6)
        textAnswerD = currentBlock2(ListBox1.SelectedIndex + 1, 7)
        rightAnswerNumber = Int(currentBlock2(ListBox1.SelectedIndex + 1, 8))
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
        Label16.Text = questionText
        Label17.Text = textAnswerA
        Label18.Text = textAnswerB
        Label19.Text = textAnswerC
        Label20.Text = textAnswerD
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button6|" & questionText & "|" & textAnswerA & "|" & textAnswerB & "|" & textAnswerC & "|" & textAnswerD & "|" & numberRightAnswer & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
        'Перекрашивание кнопок-подсказок
        Button1.BackColor = Color.White
        Button2.BackColor = Color.White
        Button3.BackColor = Color.White
        Button4.BackColor = Color.White
        Button5.BackColor = Color.White
        Button6.BackColor = Color.White
        Button8.BackColor = Color.Yellow
        Button9.BackColor = Color.Yellow
        Button10.BackColor = Color.Yellow
        Button11.BackColor = Color.Yellow
        Button12.BackColor = Color.White
        Button13.BackColor = Color.White
    End Sub

    Private Sub Button40_Click(sender As Object, e As EventArgs) Handles Button40.Click
        'Stop музыки в проигрывателе
        Shell("source\BAT\stop_back_music1.bat")
        winampOn = 0
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        'Clear forms
        Button20.BackColor = Color.White
        Button24.BackColor = Color.White
        Player.PictureBox12.Visible = False
        Audience.PictureBox14.Visible = False
        Host.Label5.Text = ""
        Label16.Text = ""
        Label17.Text = ""
        Label18.Text = ""
        Label19.Text = ""
        Label20.Text = ""
        Player.Label16.Visible = True
        Player.Label17.Visible = True
        Player.Label18.Visible = True
        Player.Label19.Visible = True
        Player.Label20.Visible = True
        Player.PictureBox2.Visible = True
        Player.PictureBox3.Visible = True
        Player.PictureBox4.Visible = True
        Player.PictureBox5.Visible = True
        Player.PictureBox13.Visible = False
        Player.Label5.Visible = False
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
        If Button41.BackColor <> Color.Orange Then
            Audience.Label16.Visible = True
            Audience.Label17.Visible = True
            Audience.Label18.Visible = True
            Audience.Label19.Visible = True
            Audience.Label20.Visible = True
            Audience.PictureBox1.Visible = True
            Audience.PictureBox2.Visible = True
            Audience.PictureBox3.Visible = True
            Audience.PictureBox4.Visible = True
            Audience.PictureBox5.Visible = True
        End If
        Audience.PictureBox13.Visible = False
        Audience.Label5.Visible = False
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        Label17.BackColor = Color.FromArgb(42, 42, 42)
        Label17.ForeColor = Color.White
        Label18.BackColor = Color.FromArgb(42, 42, 42)
        Label18.ForeColor = Color.White
        Label19.BackColor = Color.FromArgb(42, 42, 42)
        Label19.ForeColor = Color.White
        Label20.BackColor = Color.FromArgb(42, 42, 42)
        Label20.ForeColor = Color.White
        Label7.BackColor = Color.DarkGray
        Label7.Text = currentBlock1(39, 3) 'Answer Indicator
        Button14.BackColor = Color.FromArgb(255, 192, 128)
        Button14.Text = currentBlock1(42, 3) 'Show Hint
        Host.Label11.Text = ""
        commentShow = False
        If TextBox10.Text.StartsWith("-A:") And TextBox10.Text.EndsWith("%") Then
            Button45.PerformClick()
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button24|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        'Take a money
        If CheckBox10.Checked = False Then
            Shell("source\BAT\stopfade_back_music1.bat")
            winampOn = 0
            Timer3.Start()
            If winNumber < 15 Then
                Player.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                Audience.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
            End If
            Button20.BackColor = Color.Blue
            CheckBox10.Checked = True
            'Перекрашивание кнопок-подсказок
            Button1.BackColor = Color.White
            Button2.BackColor = Color.White
            Button3.BackColor = Color.White
            Button4.BackColor = Color.White
            Button5.BackColor = Color.White
            Button6.BackColor = Color.White
            Button8.BackColor = Color.White
            Button9.BackColor = Color.White
            Button10.BackColor = Color.White
            Button11.BackColor = Color.White
            Button12.BackColor = Color.White
            Button13.BackColor = Color.White
            'Сеть
            If Button7.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@button20_1|" & CheckBox10.Checked & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        Else
            Player.Label5.Visible = False
            Player.Label16.Visible = True
            Player.Label17.Visible = True
            Player.Label18.Visible = True
            Player.Label19.Visible = True
            Player.Label20.Visible = True
            Player.PictureBox2.Visible = True
            Player.PictureBox3.Visible = True
            Player.PictureBox4.Visible = True
            Player.PictureBox5.Visible = True
            Player.PictureBox13.Visible = False
            Audience.Label5.Visible = False
            Audience.Label16.Visible = True
            Audience.Label17.Visible = True
            Audience.Label18.Visible = True
            Audience.Label19.Visible = True
            Audience.Label20.Visible = True
            Audience.PictureBox1.Visible = True
            Audience.PictureBox2.Visible = True
            Audience.PictureBox3.Visible = True
            Audience.PictureBox4.Visible = True
            Audience.PictureBox5.Visible = True
            Audience.PictureBox13.Visible = False
            Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
            Button12.BackColor = Color.White
            Timer3.Stop()
            Button20.BackColor = Color.White
            'Перекрашивание кнопок-подсказок
            Button1.BackColor = Color.White
            Button2.BackColor = Color.White
            Button3.BackColor = Color.White
            Button4.BackColor = Color.White
            Button5.BackColor = Color.White
            Button6.BackColor = Color.White
            Button8.BackColor = Color.Yellow
            Button9.BackColor = Color.Yellow
            Button10.BackColor = Color.Yellow
            Button11.BackColor = Color.Yellow
            Button12.BackColor = Color.White
            Button13.BackColor = Color.White
            'Сеть
            If Button7.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@button20_2|" & CheckBox10.Checked & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        End If
    End Sub

    Private Sub Button47_Click(sender As Object, e As EventArgs) Handles Button47.Click
        'Little Quitter
        My.Computer.Audio.Play("source\MUSIC\Little Quitter.wav", AudioPlayMode.Background)
    End Sub

    Private Sub Button48_Click(sender As Object, e As EventArgs) Handles Button48.Click
        'Big Quitter
        My.Computer.Audio.Play("source\MUSIC\Big Quitter.wav", AudioPlayMode.Background)
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        '50-50 state change
        If CheckBox1.Checked = True Then
            activ50 = "0"
        Else
            activ50 = "x"
        End If
        PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@lifelines_state|" & activ50 & "|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        'PAF state change
        If CheckBox2.Checked = True Then
            activPAF = "0"
        Else
            activPAF = "x"
        End If
        PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@lifelines_state|" & activ50 & "|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub CheckBox3_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox3.CheckedChanged
        'ATA state change
        If CheckBox3.Checked = True Then
            activATA = "0"
        Else
            activATA = "x"
        End If
        PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@lifelines_state|" & activ50 & "|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Таймер представления подсказок
        PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
        Timer1.Stop()
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        '50-50 Lifeline
        Form50_50.Show()
        PictureBox7.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\1" & activPAF & activATA & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button17|1|" & activPAF & "|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        'PAF Lifeline
        FormPAF.Show()
        PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & "1" & activATA & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button15|" & activ50 & "|1|" & activATA & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        'ATA Lifeline
        FormATA.Show()
        PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & "1.png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button18|" & activ50 & "|" & activPAF & "|1|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        'Show panel
        Select Case Button19.BackColor
            Case Color.White
                'Button19.BackColor = Color.Green
                timer4_coef = 41
                Timer4.Start()
                Audience.PictureBox15.Left = 1024
                Audience.PictureBox15.Visible = True
            Case Color.Green
                Button19.BackColor = Color.White
                Audience.PictureBox15.Left = 0
                Timer5.Stop()
                Timer4.Start()
        End Select
    End Sub

    'Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
    '    'Анимация панели подсказок
    '    'llPanelTimer = llPanelTimer + 1
    '    If Audience.PictureBox15.Left < 1025 Then
    '        If Audience.PictureBox15.Left > 0 Then
    '            Audience.PictureBox15.Left = Audience.PictureBox15.Left - timer4_coef
    '            If Audience.PictureBox15.Left = 0 Then
    '                Timer4.Stop()
    '                Timer5.Start()
    '                timer4_coef = timer4_coef * -1
    '            End If
    '            timer4_coef = Math.Ceiling(1 / Math.Sqrt(timer4_coef))
    '        Else
    '            Timer4.Stop()
    '            Audience.PictureBox15.Location = New Point(0, 637)
    '        End If
    '    End If
    'End Sub

    'Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
    '    'Время показа панели подсказок
    '    If Button19.BackColor = Color.Green Then Button19.PerformClick()
    'End Sub

    Public Sub CheckBox4_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox4.CheckedChanged
        'Рамка окна ведущего
        If CheckBox4.Checked = True Then
            Host.FormBorderStyle = FormBorderStyle.Sizable
        Else
            Host.FormBorderStyle = FormBorderStyle.None
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@checkbox4|" & CheckBox4.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Public Sub CheckBox5_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox5.CheckedChanged
        'Рамка окна игрока
        If CheckBox5.Checked = True Then
            Player.FormBorderStyle = FormBorderStyle.Sizable
        Else
            Player.FormBorderStyle = FormBorderStyle.None
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@checkbox5|" & CheckBox5.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Public Sub CheckBox6_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox6.CheckedChanged
        'Рамка окна зрителей
        If CheckBox6.Checked = True Then
            Audience.FormBorderStyle = FormBorderStyle.Sizable
        Else
            Audience.FormBorderStyle = FormBorderStyle.None
        End If
    End Sub

    Public Sub CheckBox7_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox7.CheckedChanged
        'Видимость окна ведущего
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@checkbox7|" & CheckBox7.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        Else
            If CheckBox7.Checked = True Then
                Host.Show()
                Me.Focus()
            Else
                Host.Hide()
            End If
        End If
    End Sub

    Public Sub CheckBox8_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox8.CheckedChanged
        'Видимость окна игрока
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@checkbox8|" & CheckBox8.Checked & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        Else
            If CheckBox8.Checked = True Then
                Player.Show()
                Me.Focus()
            Else
                Player.Hide()
            End If
        End If
    End Sub

    Public Sub CheckBox9_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox9.CheckedChanged
        'Видимость окна зрителей
        If CheckBox9.Checked = True Then
            Audience.Show()
            Me.Focus()
        Else
            Audience.Hide()
        End If
    End Sub

    Public Sub PictureBox2_BackgroundImageChanged(sender As Object, e As EventArgs) Handles PictureBox2.BackgroundImageChanged
        'Смена картинки режиссёра и всех остальных
        Host.PictureBox2.BackgroundImage = PictureBox2.BackgroundImage
        Player.PictureBox2.BackgroundImage = PictureBox2.BackgroundImage
        Audience.PictureBox2.BackgroundImage = PictureBox2.BackgroundImage
    End Sub

    Public Sub PictureBox3_BackgroundImageChanged(sender As Object, e As EventArgs) Handles PictureBox3.BackgroundImageChanged
        Host.PictureBox3.BackgroundImage = PictureBox3.BackgroundImage
        Player.PictureBox3.BackgroundImage = PictureBox3.BackgroundImage
        Audience.PictureBox3.BackgroundImage = PictureBox3.BackgroundImage
    End Sub

    Public Sub PictureBox4_BackgroundImageChanged(sender As Object, e As EventArgs) Handles PictureBox4.BackgroundImageChanged
        Host.PictureBox4.BackgroundImage = PictureBox4.BackgroundImage
        Player.PictureBox4.BackgroundImage = PictureBox4.BackgroundImage
        Audience.PictureBox4.BackgroundImage = PictureBox4.BackgroundImage
    End Sub

    Public Sub PictureBox5_BackgroundImageChanged(sender As Object, e As EventArgs) Handles PictureBox5.BackgroundImageChanged
        Host.PictureBox5.BackgroundImage = PictureBox5.BackgroundImage
        Player.PictureBox5.BackgroundImage = PictureBox5.BackgroundImage
        Audience.PictureBox5.BackgroundImage = PictureBox5.BackgroundImage
    End Sub

    Private Sub Label16_TextChanged(sender As Object, e As EventArgs) Handles Label16.TextChanged, Label17.TextChanged, Label18.TextChanged, Label19.TextChanged, Label20.TextChanged
        'Смена текста вопроса и вариантов у режиссёра и всех остальных
        Host.Label16.Text = Label16.Text
        Player.Label16.Text = Label16.Text
        Audience.Label16.Text = Label16.Text
        Host.Label17.Text = Label17.Text
        Player.Label17.Text = Label17.Text
        Audience.Label17.Text = Label17.Text
        Host.Label18.Text = Label18.Text
        Player.Label18.Text = Label18.Text
        Audience.Label18.Text = Label18.Text
        Host.Label19.Text = Label19.Text
        Player.Label19.Text = Label19.Text
        Audience.Label19.Text = Label19.Text
        Host.Label20.Text = Label20.Text
        Player.Label20.Text = Label20.Text
        Audience.Label20.Text = Label20.Text
    End Sub

    Private Sub Label17_BackColorChanged(sender As Object, e As EventArgs) Handles Label17.BackColorChanged, Label18.BackColorChanged, Label19.BackColorChanged, Label20.BackColorChanged
        'Смена фона текста вариантов ответа у всех
        Host.Label17.BackColor = Label17.BackColor
        Player.Label17.BackColor = Label17.BackColor
        Audience.Label17.BackColor = Label17.BackColor
        Host.Label18.BackColor = Label18.BackColor
        Player.Label18.BackColor = Label18.BackColor
        Audience.Label18.BackColor = Label18.BackColor
        Host.Label19.BackColor = Label19.BackColor
        Player.Label19.BackColor = Label19.BackColor
        Audience.Label19.BackColor = Label19.BackColor
        Host.Label20.BackColor = Label20.BackColor
        Player.Label20.BackColor = Label20.BackColor
        Audience.Label20.BackColor = Label20.BackColor
    End Sub

    Private Sub Label17_ForeColorChanged(sender As Object, e As EventArgs) Handles Label16.ForeColorChanged, Label17.ForeColorChanged, Label18.ForeColorChanged, Label19.ForeColorChanged, Label20.ForeColorChanged
        'Смена цвета текста вариантов ответа у всех
        Host.Label16.ForeColor = Label16.ForeColor
        Player.Label16.ForeColor = Label16.ForeColor
        Audience.Label16.ForeColor = Label16.ForeColor
        Host.Label17.ForeColor = Label17.ForeColor
        Player.Label17.ForeColor = Label17.ForeColor
        Audience.Label17.ForeColor = Label17.ForeColor
        Host.Label18.ForeColor = Label18.ForeColor
        Player.Label18.ForeColor = Label18.ForeColor
        Audience.Label18.ForeColor = Label18.ForeColor
        Host.Label19.ForeColor = Label19.ForeColor
        Player.Label19.ForeColor = Label19.ForeColor
        Audience.Label19.ForeColor = Label19.ForeColor
        Host.Label20.ForeColor = Label20.ForeColor
        Player.Label20.ForeColor = Label20.ForeColor
        Audience.Label20.ForeColor = Label20.ForeColor
    End Sub

    Private Sub Button44_Click(sender As Object, e As EventArgs) Handles Button44.Click
        'Отправить сообщение ведущему
        Host.Label12.Text = TextBox10.Text
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button44|" & TextBox10.Text & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button45_Click(sender As Object, e As EventArgs) Handles Button45.Click
        'Очистить поле сообщения
        TextBox10.Text = ""
        Host.Label12.Text = ""
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button45|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        'Показ комментария к вопросу
        If commentShow = False Then
            Button14.BackColor = Color.FromArgb(128, 255, 255)
            Button14.Text = currentBlock1(42, 4) 'Hide Hint
            Host.Label11.Text = currentBlock2(ListBox1.SelectedIndex + 1, 9)
            commentShow = True
        Else
            Button14.BackColor = Color.FromArgb(255, 192, 128)
            Button14.Text = currentBlock1(42, 3) 'Show Hint
            Host.Label11.Text = ""
            commentShow = False
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button14|" & commentShow & "|" & currentBlock2(ListBox1.SelectedIndex + 1, 9) & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        'Показать полноэкранную картинку
        If splashOn = False Then
            Host.PictureBox0.Location = New System.Drawing.Point(0, 0)
            Host.PictureBox0.Visible = True
            Player.PictureBox0.Location = New System.Drawing.Point(0, 0)
            Player.PictureBox0.Visible = True
            Audience.PictureBox0.Location = New System.Drawing.Point(0, 0)
            Audience.PictureBox0.Visible = True
            splashOn = True
            Button16.Text = currentBlock1(45, 4) 'Hide logo
            Button16.BackColor = Color.Violet
        Else
            Host.PictureBox0.Visible = False
            Player.PictureBox0.Visible = False
            Audience.PictureBox0.Visible = False
            splashOn = False
            Button16.Text = currentBlock1(45, 3) 'Show logo
            Button16.BackColor = Color.White
        End If
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button16|" & splashOn & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        'Кнопка About
        AboutUs.Show()
    End Sub

    Private Sub NumericUpDown2_LostFocus(sender As Object, e As EventArgs) Handles NumericUpDown2.LostFocus, NumericUpDown3.LostFocus
        Host.Location = New Point(NumericUpDown2.Value, NumericUpDown3.Value)
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@numericupdown2|" & NumericUpDown2.Value & "|" & NumericUpDown3.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub NumericUpDown4_LostFocus(sender As Object, e As EventArgs) Handles NumericUpDown4.LostFocus, NumericUpDown5.LostFocus
        Player.Location = New Point(NumericUpDown4.Value, NumericUpDown5.Value)
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@numericupdown4|" & NumericUpDown4.Value & "|" & NumericUpDown5.Value & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub NumericUpDown6_LostFocus(sender As Object, e As EventArgs) Handles NumericUpDown6.LostFocus, NumericUpDown7.LostFocus
        Audience.Location = New Point(NumericUpDown6.Value, NumericUpDown7.Value)
    End Sub

    Private Sub Button42_Click(sender As Object, e As EventArgs) Handles Button42.Click
        'Tree Up
        If winNumber < 15 Then
            winNumber = winNumber + 1
            Select Case questionNumber
                Case 1
                    Host.Label2.Text = "200"
                    Host.Label3.Text = "100"
                    Host.Label4.Text = "100"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                Case 2
                    Host.Label2.Text = "300"
                    Host.Label3.Text = "200"
                    Host.Label4.Text = "200"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                Case 3
                    Host.Label2.Text = "500"
                    Host.Label3.Text = "200"
                    Host.Label4.Text = "200"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                Case 4
                    Host.Label2.Text = "1,000"
                    Host.Label3.Text = "500"
                    Host.Label4.Text = "500"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                Case 5
                    Host.Label2.Text = "2,000"
                    Host.Label3.Text = "1,000"
                    Host.Label4.Text = "0"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                Case 6
                    Host.Label2.Text = "4,000"
                    Host.Label3.Text = "2,000"
                    Host.Label4.Text = "1,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                Case 7
                    Host.Label2.Text = "8,000"
                    Host.Label3.Text = "4,000"
                    Host.Label4.Text = "3,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                Case 8
                    Host.Label2.Text = "16,000"
                    Host.Label3.Text = "8,000"
                    Host.Label4.Text = "7,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                Case 9
                    Host.Label2.Text = "32,000"
                    Host.Label3.Text = "16,000"
                    Host.Label4.Text = "15,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                Case 10
                    Host.Label2.Text = "64,000"
                    Host.Label3.Text = "32,000"
                    Host.Label4.Text = "0"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                Case 11
                    Host.Label2.Text = "125,000"
                    Host.Label3.Text = "64,000"
                    Host.Label4.Text = "32,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                Case 12
                    Host.Label2.Text = "250,000"
                    Host.Label3.Text = "125,000"
                    Host.Label4.Text = "93,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                Case 13
                    Host.Label2.Text = "500,000"
                    Host.Label3.Text = "250,000"
                    Host.Label4.Text = "218,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                Case 14
                    Host.Label2.Text = "1,000,000"
                    Host.Label3.Text = "500,000"
                    Host.Label4.Text = "468,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                Case 15
                    Host.Label2.Text = "1,000,000"
                    Host.Label3.Text = "1,000,000"
                    Host.Label4.Text = "0"
                    Host.Label6.Text = "1,000,000"
            End Select
            PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Audience.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            'Сеть
            If Button7.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@button42|" & winNumber & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        End If
    End Sub

    Private Sub Button43_Click(sender As Object, e As EventArgs) Handles Button43.Click
        'Tree Down
        If winNumber > 0 Then
            winNumber = winNumber - 1
            Select Case questionNumber
                Case 0
                    Host.Label2.Text = "100" 'Возможный выигрыш
                    Host.Label3.Text = "0" 'Текущий выигрыш
                    Host.Label4.Text = "0" 'Возможная потеря
                    Host.Label6.Text = "0" 'Несгораемая сумма
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                Case 1
                    Host.Label2.Text = "200"
                    Host.Label3.Text = "100"
                    Host.Label4.Text = "100"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                Case 2
                    Host.Label2.Text = "300"
                    Host.Label3.Text = "200"
                    Host.Label4.Text = "200"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                Case 3
                    Host.Label2.Text = "500"
                    Host.Label3.Text = "200"
                    Host.Label4.Text = "200"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                Case 4
                    Host.Label2.Text = "1,000"
                    Host.Label3.Text = "500"
                    Host.Label4.Text = "500"
                    Host.Label6.Text = "0"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                Case 5
                    Host.Label2.Text = "2,000"
                    Host.Label3.Text = "1,000"
                    Host.Label4.Text = "0"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                Case 6
                    Host.Label2.Text = "4,000"
                    Host.Label3.Text = "2,000"
                    Host.Label4.Text = "1,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                Case 7
                    Host.Label2.Text = "8,000"
                    Host.Label3.Text = "4,000"
                    Host.Label4.Text = "3,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                Case 8
                    Host.Label2.Text = "16,000"
                    Host.Label3.Text = "8,000"
                    Host.Label4.Text = "7,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                Case 9
                    Host.Label2.Text = "32,000"
                    Host.Label3.Text = "16,000"
                    Host.Label4.Text = "15,000"
                    Host.Label6.Text = "1,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                Case 10
                    Host.Label2.Text = "64,000"
                    Host.Label3.Text = "32,000"
                    Host.Label4.Text = "0"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                Case 11
                    Host.Label2.Text = "125,000"
                    Host.Label3.Text = "64,000"
                    Host.Label4.Text = "32,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                Case 12
                    Host.Label2.Text = "250,000"
                    Host.Label3.Text = "125,000"
                    Host.Label4.Text = "93,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                Case 13
                    Host.Label2.Text = "500,000"
                    Host.Label3.Text = "250,000"
                    Host.Label4.Text = "218,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                Case 14
                    Host.Label2.Text = "1,000,000"
                    Host.Label3.Text = "500,000"
                    Host.Label4.Text = "468,000"
                    Host.Label6.Text = "32,000"
                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                    Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
            End Select
            PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            Audience.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
            'Сеть
            If Button7.BackColor = Color.Green Then
                Dim NetworkInfo As New IONetwork
                With NetworkInfo
                    .Command = "@button43|" & winNumber & "|"
                End With
                Client_SendIONetwork(NetworkInfo)
            End If
        End If
    End Sub

    Private Sub Button52_Click(sender As Object, e As EventArgs) Handles Button52.Click
        'Tree 0
        winNumber = 0
        Host.Label2.Text = "100"
        Host.Label3.Text = "0"
        Host.Label4.Text = "0"
        Host.Label6.Text = "0"
        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
        PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button52|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button51_Click(sender As Object, e As EventArgs) Handles Button51.Click
        'Tree 5
        winNumber = 5
        Host.Label2.Text = "2,000"
        Host.Label3.Text = "1,000"
        Host.Label4.Text = "0"
        Host.Label6.Text = "1,000"
        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
        PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button51|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button50_Click(sender As Object, e As EventArgs) Handles Button50.Click
        'Tree 10
        winNumber = 10
        Host.Label2.Text = "64,000"
        Host.Label3.Text = "32,000"
        Host.Label4.Text = "0"
        Host.Label6.Text = "32,000"
        Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
        Audience.PictureBox14.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
        PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button50|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button49_Click(sender As Object, e As EventArgs) Handles Button49.Click
        'Tree 15
        winNumber = 15
        Host.Label2.Text = "1,000,000"
        Host.Label3.Text = "1,000,000"
        Host.Label4.Text = "0"
        Host.Label6.Text = "1,000,000"
        PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        Audience.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
        'Сеть
        If Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@button49|" & winNumber & "|"
            End With
            Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub TextBox11_Click(sender As Object, e As EventArgs) Handles TextBox11.Click
        'Нажатие на поле ввода имени игрока
        TextBox11.SelectAll()
    End Sub

    Private Sub Button41_Click(sender As Object, e As EventArgs) Handles Button41.Click
        'Fastest Finger First
        FormFFF.Show()
        Button23.BackColor = Color.White
        Button35.BackColor = Color.White
        Button41.BackColor = Color.Orange
    End Sub

    Private Sub Project_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'Закрытие программы
        If Client.IsConnection Then Client.Disconnect()
        If CheckBox7.Checked = True Then ini(1) = "1" Else ini(1) = "0"
        If CheckBox8.Checked = True Then ini(2) = "1" Else ini(2) = "0"
        If CheckBox9.Checked = True Then ini(3) = "1" Else ini(3) = "0"
        ini(4) = NumericUpDown2.Value
        ini(5) = NumericUpDown3.Value
        ini(6) = NumericUpDown4.Value
        ini(7) = NumericUpDown5.Value
        ini(8) = NumericUpDown6.Value
        ini(9) = NumericUpDown7.Value
        ini(10) = FileNameQ
        ini(12) = TextBox1.Text
        ini(13) = TextBox2.Text
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
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        'Установка соединения с сервером (Connect Button)
        hostIP = TextBox1.Text
        port = TextBox2.Text
        If Client.IsConnection Then
            Client.Disconnect()
        Else
            If hostIP = String.Empty Then Exit Sub
            If Not Client.Connect(hostIP, port) Then 'Успешна ли попытка подключения
                MsgBox(currentBlock1(145, 3) & ": " & hostIP, MsgBoxStyle.Critical, currentBlock1(145, 4))
            Else
                Button7.Text = currentBlock1(33, 4) 'Disconnect
                Button7.BackColor = Color.Green
                ConnectionPost()
                Host.Hide()
                Player.Hide()
                'Синхронизация по сети
                'If Button7.BackColor = Color.Green Then
                '    Dim NetworkInfo As New IONetwork
                '    With NetworkInfo
                '        .Command = "@sync|questionText|textAnswerA|textAnswerB|textAnswerC|textAnswerD|numberRightAnswer|currentBlock2(ListBox1.SelectedIndex + 1, 9)|winNumber|CheckBox10.Checked|NumericUpDown1.Value|activ50|activPAF|activATA|CheckBox4.Checked|CheckBox5.Checked|CheckBox7.Checked|CheckBox8.Checked|commentShow|splashOn|NumericUpDown2.Value|NumericUpDown3.Value|NumericUpDown4.Value|NumericUpDown5.Value|FormPAF.clockFrame|Host.PictureBox8.ImageLocation|Player.PictureBox8.ImageLocation|Host.PictureBox8.Visible|Player.PictureBox8.Visible|Host.Label10.Text|Host.Label9.Text|Host.Label8.Text|Host.Label7.Text|Host.Label10.Visible|Host.Label9.Visible|Host.Label8.Visible|Host.Label7.Visible|Host.PictureBox12.Visible|Host.PictureBox11.Visible|Host.PictureBox10.Visible|Host.PictureBox9.Visible|Host.PictureBox12.Height|Host.PictureBox11.Height|Host.PictureBox10.Height|Host.PictureBox9.Height|Host.PictureBox12.Top|Host.PictureBox11.Top|Host.PictureBox10.Top|Host.PictureBox9.Top|Player.Label1.Text|Player.Label2.Text|Player.Label3.Text|Player.Label4.Text|Player.Label1.Visible|Player.Label2.Visible|Player.Label3.Visible|Player.Label4.Visible|Player.PictureBox11.Visible|Player.PictureBox10.Visible|Player.PictureBox9.Visible|Player.PictureBox1.Visible|Player.PictureBox11.Height|Player.PictureBox10.Height|Player.PictureBox9.Height|Player.PictureBox1.Height|Player.PictureBox11.Top|Player.PictureBox10.Top|Player.PictureBox9.Top|Player.PictureBox1.Top|Host.BackgroundImage|Host.PictureBox2.BackgroundImage|Host.PictureBox3.BackgroundImage|Host.PictureBox4.BackgroundImage|Host.PictureBox5.BackgroundImage|Host.PictureBox6.BackgroundImage|Host.PictureBox7.BackgroundImage|Host.Label16.Text|Host.Label17.Text|Host.Label18.Text|Host.Label19.Text|Host.Label20.Text|Host.Label1.Text|Host.Label2.Text|Host.Label3.Text|Host.Label4.Text|Host.Label5.Text|Host.Label6.Text|Host.Label11.Text|Host.Label12.Text|Host.PictureBox0.Visible|Player.BackgroundImage|Player.PictureBox2.BackgroundImage|Player.PictureBox3.BackgroundImage|Player.PictureBox4.BackgroundImage|Player.PictureBox5.BackgroundImage|Player.PictureBox6.BackgroundImage|Player.PictureBox7.BackgroundImage|Player.Label16.Text|Player.Label17.Text|Player.Label18.Text|Player.Label19.Text|Player.Label20.Text|Player.Label5.Text|Player.PictureBox12.BackgroundImage|Player.PictureBox13.BackgroundImage|Player.PictureBox0.Visible|"
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
                    If CheckBox7.Checked Then Host.Focus()
                    If CheckBox8.Checked Then Player.Focus()
                    CheckBox9.Checked = False
                    Host.Label12.Text = currentBlock1(146, 3)
                Case "@button1" 'Ask It
                    Host.Label5.Text = ""
                    Host.Label11.Text = ""
                    questionText = doingEvent(1)
                    Label16.Text = questionText
                    numberRightAnswer = doingEvent(2)
                    questionNumber = doingEvent(3)
                    winNumber = questionNumber - 1
                    Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@button2" 'Enable A
                    PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                    Label17.Text = doingEvent(1)
                Case "@button3" 'Enable B
                    PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                    Label18.Text = doingEvent(1)
                Case "@button4" 'Enable C
                    PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                    Label19.Text = doingEvent(1)
                Case "@button5" 'Enable D
                    PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                    Label20.Text = doingEvent(1)
                Case "@button6" 'Enable All
                    PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                    PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                    PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                    PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                    numberRightAnswer = doingEvent(6)
                    Label16.Text = doingEvent(1)
                    Label17.Text = doingEvent(2)
                    Label18.Text = doingEvent(3)
                    Label19.Text = doingEvent(4)
                    Label20.Text = doingEvent(5)
                    Host.Label11.Text = doingEvent(6)
                Case "@button8", "@button9", "@button10", "@button11" 'Receive A, B, C, D
                    Select Case numberRightAnswer
                        Case 1
                            Host.Label5.Text = "A"
                        Case 2
                            Host.Label5.Text = "B"
                        Case 3
                            Host.Label5.Text = "C"
                        Case 4
                            Host.Label5.Text = "D"
                    End Select
                    PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                    PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                    PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                    PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                    Label17.BackColor = Color.FromArgb(42, 42, 42)
                    Label18.BackColor = Color.FromArgb(42, 42, 42)
                    Label19.BackColor = Color.FromArgb(42, 42, 42)
                    Label20.BackColor = Color.FromArgb(42, 42, 42)
                    Label17.ForeColor = Color.White
                    Label18.ForeColor = Color.White
                    Label19.ForeColor = Color.White
                    Label20.ForeColor = Color.White
                    Host.Label11.Text = doingEvent(1)
                    Select Case doingEvent(0)
                        Case "@button8"
                            playerAnswerNumber = 1
                            PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_ORANGE.png")
                            Label17.BackColor = Color.FromArgb(244, 155, 15)
                            Label17.ForeColor = Color.Black
                        Case "@button9"
                            playerAnswerNumber = 2
                            PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_ORANGE.png")
                            Label18.BackColor = Color.FromArgb(244, 155, 15)
                            Label18.ForeColor = Color.Black
                        Case "@button10"
                            playerAnswerNumber = 3
                            PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_ORANGE.png")
                            Label19.BackColor = Color.FromArgb(244, 155, 15)
                            Label19.ForeColor = Color.Black
                        Case "@button11"
                            playerAnswerNumber = 4
                            PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_ORANGE.png")
                            Label20.BackColor = Color.FromArgb(244, 155, 15)
                            Label20.ForeColor = Color.Black
                    End Select
                Case "@button12" 'What's correct
                    Host.Label1.Text = "Qaway:" & Str(15 - questionNumber)
                    Select Case numberRightAnswer
                        Case 1
                            PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_GREEN.png")
                            Label17.BackColor = Color.FromArgb(93, 179, 87)
                            Label17.ForeColor = Color.Black
                        Case 2
                            PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_GREEN.png")
                            Label18.BackColor = Color.FromArgb(93, 179, 87)
                            Label18.ForeColor = Color.Black
                        Case 3
                            PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_GREEN.png")
                            Label19.BackColor = Color.FromArgb(93, 179, 87)
                            Label19.ForeColor = Color.Black
                        Case 4
                            PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_GREEN.png")
                            Label20.BackColor = Color.FromArgb(93, 179, 87)
                            Label20.ForeColor = Color.Black
                    End Select
                    winNumber = doingEvent(2)
                    If doingEvent(1) = False Then
                        If playerAnswerNumber = numberRightAnswer Then
                            Timer2.Start()
                            Select Case questionNumber
                                Case 0
                                    Host.Label2.Text = "100" 'Возможный выигрыш
                                    Host.Label3.Text = "0" 'Текущий выигрыш
                                    Host.Label4.Text = "0" 'Возможная потеря
                                    Host.Label6.Text = "0" 'Несгораемая сумма
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                                Case 1
                                    Host.Label2.Text = "200"
                                    Host.Label3.Text = "100"
                                    Host.Label4.Text = "100"
                                    Host.Label6.Text = "0"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                                Case 2
                                    Host.Label2.Text = "300"
                                    Host.Label3.Text = "200"
                                    Host.Label4.Text = "200"
                                    Host.Label6.Text = "0"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                                Case 3
                                    Host.Label2.Text = "500"
                                    Host.Label3.Text = "200"
                                    Host.Label4.Text = "200"
                                    Host.Label6.Text = "0"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                                Case 4
                                    Host.Label2.Text = "1,000"
                                    Host.Label3.Text = "500"
                                    Host.Label4.Text = "500"
                                    Host.Label6.Text = "0"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                                Case 5
                                    Host.Label2.Text = "2,000"
                                    Host.Label3.Text = "1,000"
                                    Host.Label4.Text = "0"
                                    Host.Label6.Text = "1,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                                Case 6
                                    Host.Label2.Text = "4,000"
                                    Host.Label3.Text = "2,000"
                                    Host.Label4.Text = "1,000"
                                    Host.Label6.Text = "1,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                                Case 7
                                    Host.Label2.Text = "8,000"
                                    Host.Label3.Text = "4,000"
                                    Host.Label4.Text = "3,000"
                                    Host.Label6.Text = "1,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                                Case 8
                                    Host.Label2.Text = "16,000"
                                    Host.Label3.Text = "8,000"
                                    Host.Label4.Text = "7,000"
                                    Host.Label6.Text = "1,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                                Case 9
                                    Host.Label2.Text = "32,000"
                                    Host.Label3.Text = "16,000"
                                    Host.Label4.Text = "15,000"
                                    Host.Label6.Text = "1,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                                Case 10
                                    Host.Label2.Text = "64,000"
                                    Host.Label3.Text = "32,000"
                                    Host.Label4.Text = "0"
                                    Host.Label6.Text = "32,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                                Case 11
                                    Host.Label2.Text = "125,000"
                                    Host.Label3.Text = "64,000"
                                    Host.Label4.Text = "32,000"
                                    Host.Label6.Text = "32,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                                Case 12
                                    Host.Label2.Text = "250,000"
                                    Host.Label3.Text = "125,000"
                                    Host.Label4.Text = "93,000"
                                    Host.Label6.Text = "32,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                                Case 13
                                    Host.Label2.Text = "500,000"
                                    Host.Label3.Text = "250,000"
                                    Host.Label4.Text = "218,000"
                                    Host.Label6.Text = "32,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                                Case 14
                                    Host.Label2.Text = "1,000,000"
                                    Host.Label3.Text = "500,000"
                                    Host.Label4.Text = "468,000"
                                    Host.Label6.Text = "32,000"
                                    Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                            End Select
                        Else
                            Timer3.Start()
                            Player.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                        End If
                    Else
                        Timer3.Start()
                        If winNumber < 15 Then
                            Player.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                        End If
                    End If
                    Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@millionaire" '@button12 + winNumber=15
                    winNumber = 15
                    Select Case numberRightAnswer
                        Case 1
                            PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_GREEN.png")
                            Label17.BackColor = Color.FromArgb(93, 179, 87)
                            Label17.ForeColor = Color.Black
                        Case 2
                            PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_GREEN.png")
                            Label18.BackColor = Color.FromArgb(93, 179, 87)
                            Label18.ForeColor = Color.Black
                        Case 3
                            PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_GREEN.png")
                            Label19.BackColor = Color.FromArgb(93, 179, 87)
                            Label19.ForeColor = Color.Black
                        Case 4
                            PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_GREEN.png")
                            Label20.BackColor = Color.FromArgb(93, 179, 87)
                            Label20.ForeColor = Color.Black
                    End Select
                    Host.Label1.Text = "Qaway: 0"
                    Host.Label2.Text = "1,000,000"
                    Host.Label3.Text = "1,000,000"
                    Host.Label4.Text = "0"
                    Host.Label6.Text = "1,000,000"
                    Timer3.Start()
                    Player.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\MILLIONAIRE.png")
                    Player.Label5.Text = doingEvent(1)
                    Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@button13" 'Lx
                    Timer2.Stop()
                    Player.PictureBox12.Visible = False
                    Label16.Text = ""
                    Label17.Text = ""
                    Label18.Text = ""
                    Label19.Text = ""
                    Label20.Text = ""
                    PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    Player.Label16.Visible = True
                    Player.Label17.Visible = True
                    Player.Label18.Visible = True
                    Player.Label19.Visible = True
                    Player.Label20.Visible = True
                    Player.PictureBox2.Visible = True
                    Player.PictureBox3.Visible = True
                    Player.PictureBox4.Visible = True
                    Player.PictureBox5.Visible = True
                    Player.PictureBox13.Visible = False
                    Player.Label5.Visible = False
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    Label17.BackColor = Color.FromArgb(42, 42, 42)
                    Label17.ForeColor = Color.White
                    Label18.BackColor = Color.FromArgb(42, 42, 42)
                    Label18.ForeColor = Color.White
                    Label19.BackColor = Color.FromArgb(42, 42, 42)
                    Label19.ForeColor = Color.White
                    Label20.BackColor = Color.FromArgb(42, 42, 42)
                    Label20.ForeColor = Color.White
                    questionNumber = doingEvent(1)
                Case "@button25" 'Explane Lifelines
                    winNumber = doingEvent(4)
                    Host.PictureBox7.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    Player.PictureBox7.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Host.PictureBox0.Visible = False
                    Player.PictureBox0.Visible = False
                    splashOn = False
                    Button16.Text = currentBlock1(45, 3) 'Show logo
                    Button16.BackColor = Color.White
                    Button24.PerformClick()
                    If doingEvent(1) = "0" Then CheckBox1.Checked = True Else CheckBox1.Checked = False
                    If doingEvent(2) = "0" Then CheckBox2.Checked = True Else CheckBox2.Checked = False
                    If doingEvent(3) = "0" Then CheckBox3.Checked = True Else CheckBox3.Checked = False
                Case "@button26", "@button27", "@button28" 'Lifelines Pings
                    Host.PictureBox7.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    Player.PictureBox7.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    Timer1.Start()
                Case "@button30" 'Start the game
                    Player.PictureBox12.Visible = False
                    Host.Label1.Text = "Qaway:" & Str(15 - doingEvent(2))
                    If doingEvent(2) < 15 Then
                        Select Case doingEvent(1)
                            Case 0, 1
                                Host.Label2.Text = "100" 'Возможный выигрыш
                                Host.Label3.Text = "0" 'Текущий выигрыш
                                Host.Label4.Text = "0" 'Возможная потеря
                                Host.Label6.Text = "0" 'Несгораемая сумма
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                            Case 2
                                Host.Label2.Text = "200"
                                Host.Label3.Text = "100"
                                Host.Label4.Text = "100"
                                Host.Label6.Text = "0"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                            Case 3
                                Host.Label2.Text = "300"
                                Host.Label3.Text = "200"
                                Host.Label4.Text = "200"
                                Host.Label6.Text = "0"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                            Case 4
                                Host.Label2.Text = "500"
                                Host.Label3.Text = "200"
                                Host.Label4.Text = "200"
                                Host.Label6.Text = "0"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                            Case 5
                                Host.Label2.Text = "1,000"
                                Host.Label3.Text = "500"
                                Host.Label4.Text = "500"
                                Host.Label6.Text = "0"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                            Case 6
                                Host.Label2.Text = "2,000"
                                Host.Label3.Text = "1,000"
                                Host.Label4.Text = "0"
                                Host.Label6.Text = "1,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                            Case 7
                                Host.Label2.Text = "4,000"
                                Host.Label3.Text = "2,000"
                                Host.Label4.Text = "1,000"
                                Host.Label6.Text = "1,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                            Case 8
                                Host.Label2.Text = "8,000"
                                Host.Label3.Text = "4,000"
                                Host.Label4.Text = "3,000"
                                Host.Label6.Text = "1,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                            Case 9
                                Host.Label2.Text = "16,000"
                                Host.Label3.Text = "8,000"
                                Host.Label4.Text = "7,000"
                                Host.Label6.Text = "1,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                            Case 10
                                Host.Label2.Text = "32,000"
                                Host.Label3.Text = "16,000"
                                Host.Label4.Text = "15,000"
                                Host.Label6.Text = "1,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                            Case 11
                                Host.Label2.Text = "64,000"
                                Host.Label3.Text = "32,000"
                                Host.Label4.Text = "0"
                                Host.Label6.Text = "32,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                            Case 12
                                Host.Label2.Text = "125,000"
                                Host.Label3.Text = "64,000"
                                Host.Label4.Text = "32,000"
                                Host.Label6.Text = "32,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                            Case 13
                                Host.Label2.Text = "250,000"
                                Host.Label3.Text = "125,000"
                                Host.Label4.Text = "93,000"
                                Host.Label6.Text = "32,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                            Case 14
                                Host.Label2.Text = "500,000"
                                Host.Label3.Text = "250,000"
                                Host.Label4.Text = "218,000"
                                Host.Label6.Text = "32,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                            Case 15
                                Host.Label2.Text = "1,000,000"
                                Host.Label3.Text = "500,000"
                                Host.Label4.Text = "468,000"
                                Host.Label6.Text = "32,000"
                                Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                        End Select
                    End If
                    Host.Label5.Text = ""
                    Label16.Text = ""
                    Label17.Text = ""
                    Label18.Text = ""
                    Label19.Text = ""
                    Label20.Text = ""
                    Player.Label16.Visible = True
                    Player.Label17.Visible = True
                    Player.Label18.Visible = True
                    Player.Label19.Visible = True
                    Player.Label20.Visible = True
                    Player.PictureBox2.Visible = True
                    Player.PictureBox3.Visible = True
                    Player.PictureBox4.Visible = True
                    Player.PictureBox5.Visible = True
                    Player.PictureBox13.Visible = False
                    Player.Label5.Visible = False
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                    PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                    Label17.BackColor = Color.FromArgb(42, 42, 42)
                    Label17.ForeColor = Color.White
                    Label18.BackColor = Color.FromArgb(42, 42, 42)
                    Label18.ForeColor = Color.White
                    Label19.BackColor = Color.FromArgb(42, 42, 42)
                    Label19.ForeColor = Color.White
                    Label20.BackColor = Color.FromArgb(42, 42, 42)
                    Label20.ForeColor = Color.White
                    Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & doingEvent(2) & ".png"
                    Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & doingEvent(2) & ".png"
                    Host.Label11.Text = ""
                    commentShow = False
                    CheckBox10.Checked = False
                    Host.PictureBox0.Visible = False
                    Player.PictureBox0.Visible = False
                    splashOn = False
                    Button16.Text = currentBlock1(45, 3) 'Show logo
                    Button16.BackColor = Color.White
                Case "@button33" 'Goodbye Punter
                    Button24.PerformClick()
                    Button52.PerformClick()
                    questionNumber = 1
                    CheckBox1.Checked = True
                    CheckBox2.Checked = True
                    CheckBox3.Checked = True
                    CheckBox10.Checked = False
                    If splashOn = False Then
                        Button16.PerformClick()
                    End If
                Case "@numericupdown1" 'Смена номера вопроса
                    questionNumber = doingEvent(1)
                Case "@button24" 'Clear forms
                    Button24.PerformClick()
                Case "@button20_1" 'Take a money 1
                    CheckBox10.Checked = doingEvent(1)
                    Timer3.Start()
                    If winNumber < 15 Then
                        Player.PictureBox13.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\TPM" & winNumber & ".png")
                    End If
                    Button20.BackColor = Color.Blue
                    CheckBox10.Checked = True
                Case "@button20_2" 'Take a money 2
                    CheckBox10.Checked = doingEvent(1)
                    Player.Label5.Visible = False
                    Player.Label16.Visible = True
                    Player.Label17.Visible = True
                    Player.Label18.Visible = True
                    Player.Label19.Visible = True
                    Player.Label20.Visible = True
                    Player.PictureBox2.Visible = True
                    Player.PictureBox3.Visible = True
                    Player.PictureBox4.Visible = True
                    Player.PictureBox5.Visible = True
                    Player.PictureBox13.Visible = False
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    Timer3.Stop()
                    Button20.BackColor = Color.White
                Case "@lifelines_state", "@button17", "@button15", "@button18" '50-50, PAF or ATA state changed
                    Host.PictureBox7.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                    Player.PictureBox7.ImageLocation = "source\LIFELINES\" & doingEvent(1) & doingEvent(2) & doingEvent(3) & ".png"
                Case "@checkbox4" 'Host frame
                    CheckBox4.Checked = doingEvent(1)
                    If CheckBox4.Checked = True Then
                        Host.FormBorderStyle = FormBorderStyle.Sizable
                    Else
                        Host.FormBorderStyle = FormBorderStyle.None
                    End If
                Case "@checkbox5" 'Player frame state
                    CheckBox5.Checked = doingEvent(1)
                    If CheckBox5.Checked = True Then
                        Player.FormBorderStyle = FormBorderStyle.Sizable
                    Else
                        Player.FormBorderStyle = FormBorderStyle.None
                    End If
                Case "@checkbox7" 'Host window visibility
                    CheckBox7.Checked = doingEvent(1)
                    If CheckBox7.Checked = True Then
                        Host.Show()
                    Else
                        Host.Hide()
                    End If
                Case "@checkbox8" 'Player window visibility
                    CheckBox8.Checked = doingEvent(1)
                    If CheckBox8.Checked = True Then
                        Player.Show()
                    Else
                        Player.Hide()
                    End If
                Case "@button44" 'Send (message)
                    Host.Label12.Text = doingEvent(1)
                Case "@button45" 'Clear (message)
                    Host.Label12.Text = Nothing
                Case "@button14" 'Show hint
                    If doingEvent(1) = True Then commentShow = False Else commentShow = True
                    currentBlock2(ListBox1.SelectedIndex + 1, 9) = doingEvent(2)
                    Button14.PerformClick()
                Case "@button16" 'Show logo
                    If doingEvent(1) = True Then splashOn = False Else splashOn = True
                    If splashOn = False Then
                        Host.PictureBox0.Location = New System.Drawing.Point(0, 0)
                        Host.PictureBox0.Visible = True
                        Player.PictureBox0.Location = New System.Drawing.Point(0, 0)
                        Player.PictureBox0.Visible = True
                        splashOn = True
                    Else
                        Host.PictureBox0.Visible = False
                        Player.PictureBox0.Visible = False
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
                            Host.Label2.Text = "100" 'Возможный выигрыш
                            Host.Label3.Text = "0" 'Текущий выигрыш
                            Host.Label4.Text = "0" 'Возможная потеря
                            Host.Label6.Text = "0" 'Несгораемая сумма
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W0.png")
                        Case 1
                            Host.Label2.Text = "200"
                            Host.Label3.Text = "100"
                            Host.Label4.Text = "100"
                            Host.Label6.Text = "0"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W1.png")
                        Case 2
                            Host.Label2.Text = "300"
                            Host.Label3.Text = "200"
                            Host.Label4.Text = "200"
                            Host.Label6.Text = "0"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W2.png")
                        Case 3
                            Host.Label2.Text = "500"
                            Host.Label3.Text = "200"
                            Host.Label4.Text = "200"
                            Host.Label6.Text = "0"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W3.png")
                        Case 4
                            Host.Label2.Text = "1,000"
                            Host.Label3.Text = "500"
                            Host.Label4.Text = "500"
                            Host.Label6.Text = "0"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W4.png")
                        Case 5
                            Host.Label2.Text = "2,000"
                            Host.Label3.Text = "1,000"
                            Host.Label4.Text = "0"
                            Host.Label6.Text = "1,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W5.png")
                        Case 6
                            Host.Label2.Text = "4,000"
                            Host.Label3.Text = "2,000"
                            Host.Label4.Text = "1,000"
                            Host.Label6.Text = "1,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W6.png")
                        Case 7
                            Host.Label2.Text = "8,000"
                            Host.Label3.Text = "4,000"
                            Host.Label4.Text = "3,000"
                            Host.Label6.Text = "1,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W7.png")
                        Case 8
                            Host.Label2.Text = "16,000"
                            Host.Label3.Text = "8,000"
                            Host.Label4.Text = "7,000"
                            Host.Label6.Text = "1,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W8.png")
                        Case 9
                            Host.Label2.Text = "32,000"
                            Host.Label3.Text = "16,000"
                            Host.Label4.Text = "15,000"
                            Host.Label6.Text = "1,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W9.png")
                        Case 10
                            Host.Label2.Text = "64,000"
                            Host.Label3.Text = "32,000"
                            Host.Label4.Text = "0"
                            Host.Label6.Text = "32,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W10.png")
                        Case 11
                            Host.Label2.Text = "125,000"
                            Host.Label3.Text = "64,000"
                            Host.Label4.Text = "32,000"
                            Host.Label6.Text = "32,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W11.png")
                        Case 12
                            Host.Label2.Text = "250,000"
                            Host.Label3.Text = "125,000"
                            Host.Label4.Text = "93,000"
                            Host.Label6.Text = "32,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W12.png")
                        Case 13
                            Host.Label2.Text = "500,000"
                            Host.Label3.Text = "250,000"
                            Host.Label4.Text = "218,000"
                            Host.Label6.Text = "32,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W13.png")
                        Case 14
                            Host.Label2.Text = "1,000,000"
                            Host.Label3.Text = "500,000"
                            Host.Label4.Text = "468,000"
                            Host.Label6.Text = "32,000"
                            Player.PictureBox12.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\TREE\W14.png")
                        Case 15
                            Host.Label2.Text = "1,000,000"
                            Host.Label3.Text = "1,000,000"
                            Host.Label4.Text = "0"
                            Host.Label6.Text = "1,000,000"
                    End Select
                    Host.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                    Player.PictureBox6.ImageLocation = langSource & "\TREE\TREE_" & winNumber & ".png"
                Case "@50-50_button1" '50:50 Button1
                    Label17.Text = doingEvent(1)
                    Label18.Text = doingEvent(2)
                    Label19.Text = doingEvent(3)
                    Label20.Text = doingEvent(4)
                    CheckBox1.Checked = False
                    Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                Case "@paf_button1" 'PAF Button1
                    FormPAF.Timer1.Stop()
                    Host.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
                    Player.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
                    Host.PictureBox8.Visible = False
                    Player.PictureBox8.Visible = False
                    My.Computer.Audio.Stop()
                Case "@paf_button2" 'PAF Button2
                    FormPAF.Timer1.Stop()
                    FormPAF.clockFrame = 1
                    Host.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
                    Player.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
                    FormPAF.Timer1.Start()
                    Host.PictureBox8.Visible = True
                    Player.PictureBox8.Visible = True
                    My.Computer.Audio.Stop()
                Case "@paf_button3" 'PAF Button3
                    FormPAF.Timer1.Stop()
                    CheckBox2.Checked = False
                    Host.PictureBox8.ImageLocation = "source\CLOCK\Clock (62).png"
                    Player.PictureBox8.ImageLocation = "source\CLOCK\Clock (62).png"
                    My.Computer.Audio.Stop()
                Case "@paf_closed" 'PAF closed
                    FormPAF.Timer1.Stop()
                    Host.PictureBox8.Visible = False
                    Player.PictureBox8.Visible = False
                    My.Computer.Audio.Stop()
                    Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                Case "@ata_button2" 'ATA Button2
                    Host.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Host Screen ATA.png")
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen ATA.png")
                Case "@ata_button3" 'ATA Button3
                    Host.Label10.Text = doingEvent(5) & "%"
                    Host.Label9.Text = doingEvent(6) & "%"
                    Host.Label8.Text = doingEvent(7) & "%"
                    Host.Label7.Text = doingEvent(8) & "%"
                    Host.Label10.Visible = True
                    Host.Label9.Visible = True
                    Host.Label8.Visible = True
                    Host.Label7.Visible = True
                    Host.PictureBox12.Visible = True
                    Host.PictureBox11.Visible = True
                    Host.PictureBox10.Visible = True
                    Host.PictureBox9.Visible = True
                    Host.PictureBox12.Height = doingEvent(1) * 1.2
                    Host.PictureBox11.Height = doingEvent(2) * 1.2
                    Host.PictureBox10.Height = doingEvent(3) * 1.2
                    Host.PictureBox9.Height = doingEvent(4) * 1.2
                    Host.PictureBox12.Top = 515 - doingEvent(1) * 1.2
                    Host.PictureBox11.Top = 515 - doingEvent(2) * 1.2
                    Host.PictureBox10.Top = 515 - doingEvent(3) * 1.2
                    Host.PictureBox9.Top = 515 - doingEvent(4) * 1.2
                    Player.Label1.Text = doingEvent(5) & "%"
                    Player.Label2.Text = doingEvent(6) & "%"
                    Player.Label3.Text = doingEvent(7) & "%"
                    Player.Label4.Text = doingEvent(8) & "%"
                    Player.Label1.Visible = True
                    Player.Label2.Visible = True
                    Player.Label3.Visible = True
                    Player.Label4.Visible = True
                    Player.PictureBox11.Visible = True
                    Player.PictureBox10.Visible = True
                    Player.PictureBox9.Visible = True
                    Player.PictureBox1.Visible = True
                    Player.PictureBox11.Height = doingEvent(1) * 2.4
                    Player.PictureBox10.Height = doingEvent(2) * 2.4
                    Player.PictureBox9.Height = doingEvent(3) * 2.4
                    Player.PictureBox1.Height = doingEvent(4) * 2.4
                    Player.PictureBox11.Top = 538 - doingEvent(1) * 2.4
                    Player.PictureBox10.Top = 538 - doingEvent(2) * 2.4
                    Player.PictureBox9.Top = 538 - doingEvent(3) * 2.4
                    Player.PictureBox1.Top = 538 - doingEvent(4) * 2.4
                    TextBox10.Text = doingEvent(9)
                    Host.Label12.Text = doingEvent(9)
                    CheckBox3.Checked = False
                Case "@ata_closed" 'ATA closed
                    Host.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    Host.Label10.Visible = False
                    Host.Label9.Visible = False
                    Host.Label8.Visible = False
                    Host.Label7.Visible = False
                    Host.PictureBox12.Visible = False
                    Host.PictureBox11.Visible = False
                    Host.PictureBox10.Visible = False
                    Host.PictureBox9.Visible = False
                    Player.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\Player Screen.png")
                    Player.Label1.Visible = False
                    Player.Label2.Visible = False
                    Player.Label3.Visible = False
                    Player.Label4.Visible = False
                    Player.PictureBox11.Visible = False
                    Player.PictureBox10.Visible = False
                    Player.PictureBox9.Visible = False
                    Player.PictureBox1.Visible = False
                    My.Computer.Audio.Stop()
                    Host.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    Player.PictureBox7.ImageLocation = "source\LIFELINES\" & activ50 & activPAF & activATA & ".png"
                    'Case "@sync" 'Синхронизация
                    '    numberRightAnswer = doingEvent(1) '1
                    '    currentBlock2(ListBox1.SelectedIndex + 1, 9) = doingEvent(2) '2
                    '    winNumber = doingEvent(3) '3
                    '    CheckBox10.Checked = doingEvent(4) '4
                    '    NumericUpDown1.Value = doingEvent(5) '5
                    '    activ50 = doingEvent(6) '6
                    '    activPAF = doingEvent(7) '7
                    '    activATA = doingEvent(8) '8
                    '    CheckBox4.Checked = doingEvent(9) '9
                    '    CheckBox5.Checked = doingEvent(10) '10
                    '    CheckBox7.Checked = doingEvent(11) '11
                    '    CheckBox8.Checked = doingEvent(12) '12
                    '    commentShow = doingEvent(13) '13
                    '    splashOn = doingEvent(14) '14
                    '    NumericUpDown2.Value = doingEvent(15) '15
                    '    NumericUpDown3.Value = doingEvent(16) '16
                    '    NumericUpDown4.Value = doingEvent(17) '17
                    '    NumericUpDown5.Value = doingEvent(18) '18


            End Select
        End If
        doingEvent = Nothing
    End Sub

    Private Sub Client_Disconnected(sender As Object, e As EventArgs) Handles Client.Disconnected
        'При отключении соединения
        My.Computer.Audio.Play("source\MUSIC\Timp Hit.wav", AudioPlayMode.Background)
        If Me.WindowState <> FormWindowState.Normal Then Me.WindowState = FormWindowState.Normal
        Button7.Text = currentBlock1(33, 3) 'Connect
        Button7.BackColor = Color.Orange
    End Sub
End Class

'Синхронизация
'doingEvent:
' 0 - @sync
' 1 - numberRightAnswer
' 2 - currentBlock2(ListBox1.SelectedIndex + 1, 9)
' 3 - winNumber
' 4 - CheckBox10.Checked
' 5 - NumericUpDown1.Value
' 6 - activ50
' 7 - activPAF
' 8 - activATA
' 9 - CheckBox4.Checked
'10 - CheckBox5.Checked
'11 - CheckBox7.Checked
'12 - CheckBox8.Checked
'13 - commentShow
'14 - splashOn
'15 - NumericUpDown2.Value
'16 - NumericUpDown3.Value
'17 - NumericUpDown4.Value
'18 - NumericUpDown5.Value

'19 - FormPAF.clockFrame
'20 - Host.PictureBox8.ImageLocation
'21 - Player.PictureBox8.ImageLocation
'22 - Host.PictureBox8.Visible
'23 - Player.PictureBox8.Visible

'24 - Host.Label10.Text
'25 - Host.Label9.Text
'26 - Host.Label8.Text
'27 - Host.Label7.Text
'28 - Host.Label10.Visible
'29 - Host.Label9.Visible
'30 - Host.Label8.Visible
'31 - Host.Label7.Visible
'32 - Host.PictureBox12.Visible
'33 - Host.PictureBox11.Visible
'34 - Host.PictureBox10.Visible
'35 - Host.PictureBox9.Visible
'36 - Host.PictureBox12.Height
'37 - Host.PictureBox11.Height
'38 - Host.PictureBox10.Height
'39 - Host.PictureBox9.Height
'40 - Host.PictureBox12.Top
'41 - Host.PictureBox11.Top
'42 - Host.PictureBox10.Top
'43 - Host.PictureBox9.Top
'44 - Player.Label1.Text
'45 - Player.Label2.Text
'46 - Player.Label3.Text
'47 - Player.Label4.Text
'48 - Player.Label1.Visible
'49 - Player.Label2.Visible
'50 - Player.Label3.Visible
'51 - Player.Label4.Visible
'52 - Player.PictureBox11.Visible
'53 - Player.PictureBox10.Visible
'54 - Player.PictureBox9.Visible
'55 - Player.PictureBox1.Visible
'56 - Player.PictureBox11.Height
'57 - Player.PictureBox10.Height
'58 - Player.PictureBox9.Height
'59 - Player.PictureBox1.Height
'60 - Player.PictureBox11.Top
'61 - Player.PictureBox10.Top
'62 - Player.PictureBox9.Top
'63 - Player.PictureBox1.Top

'64 - Host.BackgroundImage
'65 - Host.BackgroundImage
'66 - Host.PictureBox2.BackgroundImage
'67 - Host.PictureBox3.BackgroundImage
'68 - Host.PictureBox4.BackgroundImage
'69 - Host.PictureBox5.BackgroundImage
'70 - Host.PictureBox6.BackgroundImage
'71 - Host.PictureBox7.BackgroundImage
'72 - Host.Label16.Text
'73 - Host.Label17.Text
'74 - Host.Label18.Text
'75 - Host.Label19.Text
'76 - Host.Label20.Text
'77 - Host.Label1.Text
'78 - Host.Label2.Text
'79 - Host.Label3.Text
'80 - Host.Label4.Text
'81 - Host.Label5.Text
'82 - Host.Label6.Text
'83 - Host.Label11.Text
'84 - Host.Label12.Text
'85 - Host.PictureBox0.Visible

'86 - Player.BackgroundImage
'87 - Player.PictureBox2.BackgroundImage
'88 - Player.PictureBox3.BackgroundImage
'89 - Player.PictureBox4.BackgroundImage
'90 - Player.PictureBox5.BackgroundImage
'91 - Player.PictureBox6.BackgroundImage
'92 - Player.PictureBox7.BackgroundImage
'93 - Player.Label16.Text
'94 - Player.Label17.Text
'95 - Player.Label18.Text
'96 - Player.Label19.Text
'97 - Player.Label20.Text
'98 - Player.Label5.Text
'99 - Player.PictureBox12.BackgroundImage
'100 - Player.PictureBox13.BackgroundImage
'101 - Player.PictureBox0.Visible

'"@sync|questionText|textAnswerA|textAnswerB|textAnswerC|textAnswerD|numberRightAnswer|currentBlock2(ListBox1.SelectedIndex + 1, 9)|winNumber|CheckBox10.Checked|NumericUpDown1.Value|activ50|activPAF|activATA|CheckBox4.Checked|CheckBox5.Checked|CheckBox7.Checked|CheckBox8.Checked|commentShow|splashOn|NumericUpDown2.Value|NumericUpDown3.Value|NumericUpDown4.Value|NumericUpDown5.Value|FormPAF.clockFrame|Host.PictureBox8.ImageLocation|Player.PictureBox8.ImageLocation|Host.PictureBox8.Visible|Player.PictureBox8.Visible|Host.Label10.Text|Host.Label9.Text|Host.Label8.Text|Host.Label7.Text|Host.Label10.Visible|Host.Label9.Visible|Host.Label8.Visible|Host.Label7.Visible|Host.PictureBox12.Visible|Host.PictureBox11.Visible|Host.PictureBox10.Visible|Host.PictureBox9.Visible|Host.PictureBox12.Height|Host.PictureBox11.Height|Host.PictureBox10.Height|Host.PictureBox9.Height|Host.PictureBox12.Top|Host.PictureBox11.Top|Host.PictureBox10.Top|Host.PictureBox9.Top|Player.Label1.Text|Player.Label2.Text|Player.Label3.Text|Player.Label4.Text|Player.Label1.Visible|Player.Label2.Visible|Player.Label3.Visible|Player.Label4.Visible|Player.PictureBox11.Visible|Player.PictureBox10.Visible|Player.PictureBox9.Visible|Player.PictureBox1.Visible|Player.PictureBox11.Height|Player.PictureBox10.Height|Player.PictureBox9.Height|Player.PictureBox1.Height|Player.PictureBox11.Top|Player.PictureBox10.Top|Player.PictureBox9.Top|Player.PictureBox1.Top|Host.BackgroundImage|Host.PictureBox2.BackgroundImage|Host.PictureBox3.BackgroundImage|Host.PictureBox4.BackgroundImage|Host.PictureBox5.BackgroundImage|Host.PictureBox6.BackgroundImage|Host.PictureBox7.BackgroundImage|Host.Label16.Text|Host.Label17.Text|Host.Label18.Text|Host.Label19.Text|Host.Label20.Text|Host.Label1.Text|Host.Label2.Text|Host.Label3.Text|Host.Label4.Text|Host.Label5.Text|Host.Label6.Text|Host.Label11.Text|Host.Label12.Text|Host.PictureBox0.Visible|Player.BackgroundImage|Player.PictureBox2.BackgroundImage|Player.PictureBox3.BackgroundImage|Player.PictureBox4.BackgroundImage|Player.PictureBox5.BackgroundImage|Player.PictureBox6.BackgroundImage|Player.PictureBox7.BackgroundImage|Player.Label16.Text|Player.Label17.Text|Player.Label18.Text|Player.Label19.Text|Player.Label20.Text|Player.Label5.Text|Player.PictureBox12.BackgroundImage|Player.PictureBox13.BackgroundImage|Player.PictureBox0.Visible|"

'Case "@connect_success" 'При успешном соединении
'Case "@button1" 'Ask It                                                                                                 questionText & Str(numberRightAnswer) & questionNumber
'Case "@button2" 'Enable A                                                                                                                                          textAnswerA
'Case "@button3" 'Enable B                                                                                                                                          textAnswerB
'Case "@button4" 'Enable C                                                                                                                                          textAnswerC
'Case "@button5" 'Enable D                                                                                                                                          textAnswerD
'Case "@button6" 'Enable All                                                           questionText & textAnswerA & textAnswerB & textAnswerC & textAnswerD & numberRightAnswer
'Case "@button8", "@button9", "@button10", "@button11" 'Receive A, B, C, D                                                         currentBlock2(ListBox1.SelectedIndex + 1, 9)
'Case "@button12" 'What's correct                                                                                                                            CheckBox10.Checked
'Case "@millionaire" '@button12 + winNumber=15                                                                                                                   TextBox11.Text
'Case "@button13" 'Lx                                                                                                                                      NumericUpDown1.Value
'Case "@button25" 'Lifeline Explanations                                                                                              activ50 & activPAF & activATA & winNumber
'Case "@button26", "@button27", "@button28" 'Lifelines Pings                                                                                      activ50 & activPAF & activATA
'Case "@button30" 'Start the game                                                                                                                    questionNumber & winNumber
'Case "@button33" 'Goodbye Punter                                                                                                                                           ---
'Case "@numericupdown1" 'Смена номера вопроса                                                                                                              NumericUpDown1.Value
'Case "@button24" 'Clear forms                                                                                                                                              ---
'Case "@button20" 'Take a money                                                                                                                              CheckBox10.Checked
'Case "@lifelines_state", "@button17", "@button15", "@button18" '50-50, PAF or ATA state changed                                                  activ50 & activPAF & activATA
'Case "@checkbox4" 'Host frame                                                                                                                                CheckBox4.Checked
'Case "@checkbox5" 'Player frame state                                                                                                                        CheckBox5.Checked
'Case "@checkbox7" 'Host window visibility                                                                                                                    CheckBox7.Checked
'Case "@checkbox8" 'Player window visibility                                                                                                                  CheckBox8.Checked
'Case "@button44" 'Send (message)                                                                                                                                TextBox10.Text
'Case "@button45" 'Clear (message)                                                                                                                                          ---
'Case "@button14" 'Show hint                                                                                         commentShow & currentBlock2(ListBox1.SelectedIndex + 1, 9)
'Case "@button16" 'Show logo                                                                                                                                           splashOn
'Case "@numericupdown2" 'Host window location                                                                                       NumericUpDown2.Value & NumericUpDown3.Value
'Case "@numericupdown4" 'Player window location                                                                                     NumericUpDown4.Value & NumericUpDown5.Value
'Case "@button42", "@button43", "@button52", "@button51", "@button50", "@button49" 'Tree Up or Tree Down                                                              winNumber
'Case "@50-50_button1" '50:50 Button1                                                                                 Label17.Text & Label18.Text & Label19.Text & Label20.Text
'Case "@paf_button1" 'PAF Button1                                                                                                                                           ---
'Case "@paf_button2" 'PAF Button2                                                                                                                                           ---
'Case "@paf_button3" 'PAF Button3                                                                                                                                           ---
'Case "@paf_closed" 'PAF closed                                                                                                                                             ---
'Case "@ata_button2" 'ATA Button2                                                                                                                                           ---
'Case "@ata_button3" 'ATA Button3                              FormATA.percentsA & FormATA.percentsB & FormATA.percentsC & FormATA.percentsD & FormATA.NumericUpDown5.Value & _ 
'                                                                 & FormATA.NumericUpDown6.Value & FormATA.NumericUpDown7.Value & FormATA.NumericUpDown8.Value & TextBox10.Text
'Case "@ata_closed" 'ATA closed                                                                                                                                             ---