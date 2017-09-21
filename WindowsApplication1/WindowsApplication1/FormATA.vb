Public Class FormATA
    Dim voicesSum As Integer 'Сумма всех голосов
    Public percentsA As Integer
    Public percentsB As Integer
    Public percentsC As Integer
    Public percentsD As Integer
    Public columnHeightA As Integer
    Public columnHeightB As Integer
    Public columnHeightC As Integer
    Public columnHeightD As Integer
    Dim percentsSum As Integer

    Private Sub FormATA_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        PictureBox2.ImageLocation = "source\GRAPH COLUMN.png"
        PictureBox3.ImageLocation = "source\GRAPH COLUMN.png"
        PictureBox4.ImageLocation = "source\GRAPH COLUMN.png"
        PictureBox5.ImageLocation = "source\GRAPH COLUMN.png"
        PictureBox2.Height = percentsA * 2.4
        PictureBox3.Height = percentsB * 2.4
        PictureBox4.Height = percentsC * 2.4
        PictureBox5.Height = percentsD * 2.4
        PictureBox2.Top = 300 - percentsA * 2.4
        PictureBox3.Top = 300 - percentsB * 2.4
        PictureBox4.Top = 300 - percentsC * 2.4
        PictureBox5.Top = 300 - percentsD * 2.4
        'Перевод "E" FormATA
        Text = Project.currentBlock1(110, 3) '0
        Button1.Text = Project.currentBlock1(111, 3) '1
        Button2.Text = Project.currentBlock1(112, 3) '2
        Label9.Text = Project.currentBlock1(113, 3) '3
        Label10.Text = Project.currentBlock1(113, 3) '3
        Label11.Text = Project.currentBlock1(113, 3) '3
        Label12.Text = Project.currentBlock1(113, 3) '3
        Label17.Text = Project.currentBlock1(114, 3) '4
        Label18.Text = Project.currentBlock1(115, 3) '5
        Button3.Text = Project.currentBlock1(116, 3) '6
        Label1.Font = New Font(Project.currentBlock1(6, 3), Int(Project.currentBlock1(6, 4)))
        Label2.Font = New Font(Project.currentBlock1(6, 3), Int(Project.currentBlock1(6, 4)))
        Label3.Font = New Font(Project.currentBlock1(6, 3), Int(Project.currentBlock1(6, 4)))
        Label4.Font = New Font(Project.currentBlock1(6, 3), Int(Project.currentBlock1(6, 4)))
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        My.Computer.Audio.Play("source\MUSIC\Ask the Audience.wav", AudioPlayMode.Background)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Host.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Host Screen ATA.png")
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Player Screen ATA.png")
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Audience Screen ATA.png")
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        My.Computer.Audio.Play("source\MUSIC\Audience Keyboards.wav", AudioPlayMode.Background)
        'Сеть
        If Project.Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ata_button2|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If percentsA < 1 Then percentsA = NumericUpDown5.Value
        If percentsB < 1 Then percentsB = NumericUpDown6.Value
        If percentsC < 1 Then percentsC = NumericUpDown7.Value
        If percentsD < 1 Then percentsD = NumericUpDown8.Value
        'Окно режиссёра
        Label1.Text = NumericUpDown5.Value & "%"
        Label2.Text = NumericUpDown6.Value & "%"
        Label3.Text = NumericUpDown7.Value & "%"
        Label4.Text = NumericUpDown8.Value & "%"
        Label1.Visible = True
        Label2.Visible = True
        Label3.Visible = True
        Label4.Visible = True
        PictureBox2.Height = percentsA * 2.4
        PictureBox3.Height = percentsB * 2.4
        PictureBox4.Height = percentsC * 2.4
        PictureBox5.Height = percentsD * 2.4
        PictureBox2.Top = 300 - percentsA * 2.4
        PictureBox3.Top = 300 - percentsB * 2.4
        PictureBox4.Top = 300 - percentsC * 2.4
        PictureBox5.Top = 300 - percentsD * 2.4
        'Экран ведущего
        Host.Label10.Text = NumericUpDown5.Value & "%"
        Host.Label9.Text = NumericUpDown6.Value & "%"
        Host.Label8.Text = NumericUpDown7.Value & "%"
        Host.Label7.Text = NumericUpDown8.Value & "%"
        Host.Label10.Visible = True
        Host.Label9.Visible = True
        Host.Label8.Visible = True
        Host.Label7.Visible = True
        Host.PictureBox12.Visible = True
        Host.PictureBox11.Visible = True
        Host.PictureBox10.Visible = True
        Host.PictureBox9.Visible = True
        Host.PictureBox12.Height = percentsA * 1.2
        Host.PictureBox11.Height = percentsB * 1.2
        Host.PictureBox10.Height = percentsC * 1.2
        Host.PictureBox9.Height = percentsD * 1.2
        Host.PictureBox12.Top = 515 - percentsA * 1.2
        Host.PictureBox11.Top = 515 - percentsB * 1.2
        Host.PictureBox10.Top = 515 - percentsC * 1.2
        Host.PictureBox9.Top = 515 - percentsD * 1.2
        'Экран игрока
        Player.Label1.Text = NumericUpDown5.Value & "%"
        Player.Label2.Text = NumericUpDown6.Value & "%"
        Player.Label3.Text = NumericUpDown7.Value & "%"
        Player.Label4.Text = NumericUpDown8.Value & "%"
        Player.Label1.Visible = True
        Player.Label2.Visible = True
        Player.Label3.Visible = True
        Player.Label4.Visible = True
        Player.PictureBox11.Visible = True
        Player.PictureBox10.Visible = True
        Player.PictureBox9.Visible = True
        Player.PictureBox1.Visible = True
        Player.PictureBox11.Height = percentsA * 2.4
        Player.PictureBox10.Height = percentsB * 2.4
        Player.PictureBox9.Height = percentsC * 2.4
        Player.PictureBox1.Height = percentsD * 2.4
        Player.PictureBox11.Top = 538 - percentsA * 2.4
        Player.PictureBox10.Top = 538 - percentsB * 2.4
        Player.PictureBox9.Top = 538 - percentsC * 2.4
        Player.PictureBox1.Top = 538 - percentsD * 2.4
        'Экран зрителей
        Audience.Label1.Text = NumericUpDown5.Value & "%"
        Audience.Label2.Text = NumericUpDown6.Value & "%"
        Audience.Label3.Text = NumericUpDown7.Value & "%"
        Audience.Label4.Text = NumericUpDown8.Value & "%"
        Audience.Label1.Visible = True
        Audience.Label2.Visible = True
        Audience.Label3.Visible = True
        Audience.Label4.Visible = True
        Audience.PictureBox12.Visible = True
        Audience.PictureBox11.Visible = True
        Audience.PictureBox10.Visible = True
        Audience.PictureBox9.Visible = True
        Audience.PictureBox12.Height = percentsA * 2.4
        Audience.PictureBox11.Height = percentsB * 2.4
        Audience.PictureBox10.Height = percentsC * 2.4
        Audience.PictureBox9.Height = percentsD * 2.4
        Audience.PictureBox12.Top = 347 - percentsA * 2.4
        Audience.PictureBox11.Top = 347 - percentsB * 2.4
        Audience.PictureBox10.Top = 347 - percentsC * 2.4
        Audience.PictureBox9.Top = 347 - percentsD * 2.4
        My.Computer.Audio.Play("source\MUSIC\Audience Decide.wav", AudioPlayMode.Background)
        Project.TextBox10.Text = "-A: " & percentsA & "% -B: " & percentsB & "% -C: " & percentsC & "% -D: " & percentsD & "%"
        Host.Label12.Text = "-A: " & percentsA & "% -B: " & percentsB & "% -C: " & percentsC & "% -D: " & percentsD & "%"
        Project.CheckBox3.Checked = False
        'Сеть
        If Project.Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ata_button3|" & percentsA & "|" & percentsB & "|" & percentsC & "|" & percentsD & "|" & NumericUpDown5.Value & "|" & NumericUpDown6.Value & "|" & NumericUpDown7.Value & "|" & NumericUpDown8.Value & "|" & Project.TextBox10.Text & "|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub NumericUpDown1_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown1.ValueChanged, NumericUpDown2.ValueChanged, NumericUpDown3.ValueChanged, NumericUpDown4.ValueChanged
        voicesSum = NumericUpDown1.Value + NumericUpDown2.Value + NumericUpDown3.Value + NumericUpDown4.Value
        If NumericUpDown1.Value < 1 Then
            percentsA = 0
        Else
            percentsA = NumericUpDown1.Value / voicesSum * 100
        End If
        If NumericUpDown2.Value < 1 Then
            percentsB = 0
        Else
            percentsB = NumericUpDown2.Value / voicesSum * 100
        End If
        If NumericUpDown3.Value < 1 Then
            percentsC = 0
        Else
            percentsC = NumericUpDown3.Value / voicesSum * 100
        End If
        If NumericUpDown4.Value < 1 Then
            percentsD = 0
        Else
            percentsD = NumericUpDown4.Value / voicesSum * 100
        End If
        NumericUpDown5.Value = percentsA
        NumericUpDown6.Value = percentsB
        NumericUpDown7.Value = percentsC
        NumericUpDown8.Value = percentsD
        percentsSum = NumericUpDown5.Value + NumericUpDown6.Value + NumericUpDown7.Value + NumericUpDown8.Value
        Label17.Text = Project.currentBlock1(114, 3) & voicesSum
        Label18.Text = Project.currentBlock1(115, 3) & percentsSum & "%"
        If percentsSum <> 100 Then
            Label18.ForeColor = Color.Red
        Else
            Label18.ForeColor = Color.White
        End If
    End Sub

    Private Sub NumericUpDown5_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown5.ValueChanged, NumericUpDown6.ValueChanged, NumericUpDown7.ValueChanged, NumericUpDown8.ValueChanged
        percentsSum = NumericUpDown5.Value + NumericUpDown6.Value + NumericUpDown7.Value + NumericUpDown8.Value
        Label18.Text = Project.currentBlock1(115, 3) & percentsSum & "%"
        If percentsSum <> 100 Then
            Label18.ForeColor = Color.Red
        Else
            Label18.ForeColor = Color.White
        End If
    End Sub

    Private Sub FormATA_Closed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        'Экран ведущего
        Host.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Player Screen.png")
        Host.Label10.Visible = False
        Host.Label9.Visible = False
        Host.Label8.Visible = False
        Host.Label7.Visible = False
        Host.PictureBox12.Visible = False
        Host.PictureBox11.Visible = False
        Host.PictureBox10.Visible = False
        Host.PictureBox9.Visible = False
        'Экран игрока
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Player Screen.png")
        Player.Label1.Visible = False
        Player.Label2.Visible = False
        Player.Label3.Visible = False
        Player.Label4.Visible = False
        Player.PictureBox11.Visible = False
        Player.PictureBox10.Visible = False
        Player.PictureBox9.Visible = False
        Player.PictureBox1.Visible = False
        'Экран зрителей
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
        Audience.Label1.Visible = False
        Audience.Label2.Visible = False
        Audience.Label3.Visible = False
        Audience.Label4.Visible = False
        Audience.PictureBox12.Visible = False
        Audience.PictureBox11.Visible = False
        Audience.PictureBox10.Visible = False
        Audience.PictureBox9.Visible = False
        My.Computer.Audio.Stop()
        Select Case Project.questionNumber
            Case 0 To 5
                'Обращение к *.bat файлу для включения внешнего проигрывателя
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q1-5 Bed Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 6
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q6 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 7
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q7 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 8
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q8 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 9
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q9 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 10
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q10 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 11
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q11 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 12
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q12 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 13
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q13 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 14
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q14 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
            Case 15
                If Project.winampOn <> 1 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Q15 - Heartbeat (R1 000 000) Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
                    Project.winampOn = 1
                End If
        End Select
        Project.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        'Сеть
        If Project.Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ata_closed|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub
End Class