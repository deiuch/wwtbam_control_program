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
        AnswerAChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        AnswerBChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        AnswerCChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        AnswerDChartPictureBox.ImageLocation = "source\GRAPH COLUMN.png"
        AnswerAChartPictureBox.Height = percentsA * 2.4
        AnswerBChartPictureBox.Height = percentsB * 2.4
        AnswerCChartPictureBox.Height = percentsC * 2.4
        AnswerDChartPictureBox.Height = percentsD * 2.4
        AnswerAChartPictureBox.Top = 300 - percentsA * 2.4
        AnswerBChartPictureBox.Top = 300 - percentsB * 2.4
        AnswerCChartPictureBox.Top = 300 - percentsC * 2.4
        AnswerDChartPictureBox.Top = 300 - percentsD * 2.4
        'Перевод "E" FormATA
        Text = Project.currentBlock1(110, 3) '0
        StartAskTheAudienceButton.Text = Project.currentBlock1(111, 3) '1
        StartVotingButton.Text = Project.currentBlock1(112, 3) '2
        AnswerAOrLabel.Text = Project.currentBlock1(113, 3) '3
        AnswerBOrLabel.Text = Project.currentBlock1(113, 3) '3
        AnswerCOrLabel.Text = Project.currentBlock1(113, 3) '3
        AnswerDOrLabel.Text = Project.currentBlock1(113, 3) '3
        TotalVotesLabel.Text = Project.currentBlock1(114, 3) '4
        TotalPercentLabel.Text = Project.currentBlock1(115, 3) '5
        ExecuteButton.Text = Project.currentBlock1(116, 3) '6
        AnswerAResultLabel.Font = New Font(Project.currentBlock1(6, 3), Int(Project.currentBlock1(6, 4)))
        AnswerBResultLabel.Font = New Font(Project.currentBlock1(6, 3), Int(Project.currentBlock1(6, 4)))
        AnswerCResultLabel.Font = New Font(Project.currentBlock1(6, 3), Int(Project.currentBlock1(6, 4)))
        AnswerDResultLabel.Font = New Font(Project.currentBlock1(6, 3), Int(Project.currentBlock1(6, 4)))
    End Sub

    Private Sub StartAskTheAudienceButton_Click(sender As Object, e As EventArgs) Handles StartAskTheAudienceButton.Click
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        My.Computer.Audio.Play("source\MUSIC\Ask the Audience.wav", AudioPlayMode.Background)
    End Sub

    Private Sub StartVotingButton_Click(sender As Object, e As EventArgs) Handles StartVotingButton.Click
        Host.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Host Screen ATA.png")
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Player Screen ATA.png")
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Audience Screen ATA.png")
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        My.Computer.Audio.Play("source\MUSIC\Audience Keyboards.wav", AudioPlayMode.Background)
        'Сеть
        If Project.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ata_button2|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ExecuteButton_Click(sender As Object, e As EventArgs) Handles ExecuteButton.Click
        If percentsA < 1 Then percentsA = AnswerAPercentNumericUpDown.Value
        If percentsB < 1 Then percentsB = AnswerBPercentNumericUpDown.Value
        If percentsC < 1 Then percentsC = AnswerCPercentNumericUpDown.Value
        If percentsD < 1 Then percentsD = AnswerDPercentNumericUpDown.Value
        'Окно режиссёра
        AnswerAResultLabel.Text = AnswerAPercentNumericUpDown.Value & "%"
        AnswerBResultLabel.Text = AnswerBPercentNumericUpDown.Value & "%"
        AnswerCResultLabel.Text = AnswerCPercentNumericUpDown.Value & "%"
        AnswerDResultLabel.Text = AnswerDPercentNumericUpDown.Value & "%"
        AnswerAResultLabel.Visible = True
        AnswerBResultLabel.Visible = True
        AnswerCResultLabel.Visible = True
        AnswerDResultLabel.Visible = True
        AnswerAChartPictureBox.Height = percentsA * 2.4
        AnswerBChartPictureBox.Height = percentsB * 2.4
        AnswerCChartPictureBox.Height = percentsC * 2.4
        AnswerDChartPictureBox.Height = percentsD * 2.4
        AnswerAChartPictureBox.Top = 300 - percentsA * 2.4
        AnswerBChartPictureBox.Top = 300 - percentsB * 2.4
        AnswerCChartPictureBox.Top = 300 - percentsC * 2.4
        AnswerDChartPictureBox.Top = 300 - percentsD * 2.4
        'Экран ведущего
        Host.AnswerAPercentLabel.Text = AnswerAPercentNumericUpDown.Value & "%"
        Host.AnswerBPercentLabel.Text = AnswerBPercentNumericUpDown.Value & "%"
        Host.AnswerCPercentLabel.Text = AnswerCPercentNumericUpDown.Value & "%"
        Host.AnswerDPercentLabel.Text = AnswerDPercentNumericUpDown.Value & "%"
        Host.AnswerAPercentLabel.Visible = True
        Host.AnswerBPercentLabel.Visible = True
        Host.AnswerCPercentLabel.Visible = True
        Host.AnswerDPercentLabel.Visible = True
        Host.AnswerAChartPictureBox.Visible = True
        Host.AnswerBChartPictureBox.Visible = True
        Host.AnswerCChartPictureBox.Visible = True
        Host.AnswerDChartPictureBox.Visible = True
        Host.AnswerAChartPictureBox.Height = percentsA * 1.2
        Host.AnswerBChartPictureBox.Height = percentsB * 1.2
        Host.AnswerCChartPictureBox.Height = percentsC * 1.2
        Host.AnswerDChartPictureBox.Height = percentsD * 1.2
        Host.AnswerAChartPictureBox.Top = 515 - percentsA * 1.2
        Host.AnswerBChartPictureBox.Top = 515 - percentsB * 1.2
        Host.AnswerCChartPictureBox.Top = 515 - percentsC * 1.2
        Host.AnswerDChartPictureBox.Top = 515 - percentsD * 1.2
        'Экран игрока
        Player.AnswerAPercentLabel.Text = AnswerAPercentNumericUpDown.Value & "%"
        Player.AnswerBPercentLabel.Text = AnswerBPercentNumericUpDown.Value & "%"
        Player.AnswerCPercentLabel.Text = AnswerCPercentNumericUpDown.Value & "%"
        Player.AnswerDPercentLabel.Text = AnswerDPercentNumericUpDown.Value & "%"
        Player.AnswerAPercentLabel.Visible = True
        Player.AnswerBPercentLabel.Visible = True
        Player.AnswerCPercentLabel.Visible = True
        Player.AnswerDPercentLabel.Visible = True
        Player.AnswerAChartPictureBox.Visible = True
        Player.AnswerBChartPictureBox.Visible = True
        Player.AnswerCChartPictureBox.Visible = True
        Player.AnswerDChartPictureBox.Visible = True
        Player.AnswerAChartPictureBox.Height = percentsA * 2.4
        Player.AnswerBChartPictureBox.Height = percentsB * 2.4
        Player.AnswerCChartPictureBox.Height = percentsC * 2.4
        Player.AnswerDChartPictureBox.Height = percentsD * 2.4
        Player.AnswerAChartPictureBox.Top = 538 - percentsA * 2.4
        Player.AnswerBChartPictureBox.Top = 538 - percentsB * 2.4
        Player.AnswerCChartPictureBox.Top = 538 - percentsC * 2.4
        Player.AnswerDChartPictureBox.Top = 538 - percentsD * 2.4
        'Экран зрителей
        Audience.AnswerAPercentLabel.Text = AnswerAPercentNumericUpDown.Value & "%"
        Audience.AnswerBPercentLabel.Text = AnswerBPercentNumericUpDown.Value & "%"
        Audience.AnswerCPercentLabel.Text = AnswerCPercentNumericUpDown.Value & "%"
        Audience.AnswerDPercentLabel.Text = AnswerDPercentNumericUpDown.Value & "%"
        Audience.AnswerAPercentLabel.Visible = True
        Audience.AnswerBPercentLabel.Visible = True
        Audience.AnswerCPercentLabel.Visible = True
        Audience.AnswerDPercentLabel.Visible = True
        Audience.AnswerAChartPictureBox.Visible = True
        Audience.AnswerBChartPictureBox.Visible = True
        Audience.AnswerCChartPictureBox.Visible = True
        Audience.AnswerDChartPictureBox.Visible = True
        Audience.AnswerAChartPictureBox.Height = percentsA * 2.4
        Audience.AnswerBChartPictureBox.Height = percentsB * 2.4
        Audience.AnswerCChartPictureBox.Height = percentsC * 2.4
        Audience.AnswerDChartPictureBox.Height = percentsD * 2.4
        Audience.AnswerAChartPictureBox.Top = 347 - percentsA * 2.4
        Audience.AnswerBChartPictureBox.Top = 347 - percentsB * 2.4
        Audience.AnswerCChartPictureBox.Top = 347 - percentsC * 2.4
        Audience.AnswerDChartPictureBox.Top = 347 - percentsD * 2.4
        My.Computer.Audio.Play("source\MUSIC\Audience Decide.wav", AudioPlayMode.Background)
        Project.HostMessageTextBox.Text = "-A: " & percentsA & "% -B: " & percentsB & "% -C: " & percentsC & "% -D: " & percentsD & "%"
        Host.HostMessageLabel.Text = "-A: " & percentsA & "% -B: " & percentsB & "% -C: " & percentsC & "% -D: " & percentsD & "%"
        Project.AskTheAudienceAvailableCheckBox.Checked = False
        'Сеть
        If Project.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ata_button3|" & percentsA & "|" & percentsB & "|" & percentsC & "|" & percentsD & "|" & AnswerAPercentNumericUpDown.Value & "|" & AnswerBPercentNumericUpDown.Value & "|" & AnswerCPercentNumericUpDown.Value & "|" & AnswerDPercentNumericUpDown.Value & "|" & Project.HostMessageTextBox.Text & "|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub AnswerAVotesNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles AnswerAVotesNumericUpDown.ValueChanged, AnswerBVotesNumericUpDown.ValueChanged, AnswerCVotesNumericUpDown.ValueChanged, AnswerDVotesNumericUpDown.ValueChanged
        voicesSum = AnswerAVotesNumericUpDown.Value + AnswerBVotesNumericUpDown.Value + AnswerCVotesNumericUpDown.Value + AnswerDVotesNumericUpDown.Value
        If AnswerAVotesNumericUpDown.Value < 1 Then
            percentsA = 0
        Else
            percentsA = AnswerAVotesNumericUpDown.Value / voicesSum * 100
        End If
        If AnswerBVotesNumericUpDown.Value < 1 Then
            percentsB = 0
        Else
            percentsB = AnswerBVotesNumericUpDown.Value / voicesSum * 100
        End If
        If AnswerCVotesNumericUpDown.Value < 1 Then
            percentsC = 0
        Else
            percentsC = AnswerCVotesNumericUpDown.Value / voicesSum * 100
        End If
        If AnswerDVotesNumericUpDown.Value < 1 Then
            percentsD = 0
        Else
            percentsD = AnswerDVotesNumericUpDown.Value / voicesSum * 100
        End If
        AnswerAPercentNumericUpDown.Value = percentsA
        AnswerBPercentNumericUpDown.Value = percentsB
        AnswerCPercentNumericUpDown.Value = percentsC
        AnswerDPercentNumericUpDown.Value = percentsD
        percentsSum = AnswerAPercentNumericUpDown.Value + AnswerBPercentNumericUpDown.Value + AnswerCPercentNumericUpDown.Value + AnswerDPercentNumericUpDown.Value
        TotalVotesLabel.Text = Project.currentBlock1(114, 3) & voicesSum
        TotalPercentLabel.Text = Project.currentBlock1(115, 3) & percentsSum & "%"
        If percentsSum <> 100 Then
            TotalPercentLabel.ForeColor = Color.Red
        Else
            TotalPercentLabel.ForeColor = Color.White
        End If
    End Sub

    Private Sub AnswerAPercentNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles AnswerAPercentNumericUpDown.ValueChanged, AnswerBPercentNumericUpDown.ValueChanged, AnswerCPercentNumericUpDown.ValueChanged, AnswerDPercentNumericUpDown.ValueChanged
        percentsSum = AnswerAPercentNumericUpDown.Value + AnswerBPercentNumericUpDown.Value + AnswerCPercentNumericUpDown.Value + AnswerDPercentNumericUpDown.Value
        TotalPercentLabel.Text = Project.currentBlock1(115, 3) & percentsSum & "%"
        If percentsSum <> 100 Then
            TotalPercentLabel.ForeColor = Color.Red
        Else
            TotalPercentLabel.ForeColor = Color.White
        End If
    End Sub

    Private Sub FormATA_Closed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        'Экран ведущего
        Host.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Player Screen.png")
        Host.AnswerAPercentLabel.Visible = False
        Host.AnswerBPercentLabel.Visible = False
        Host.AnswerCPercentLabel.Visible = False
        Host.AnswerDPercentLabel.Visible = False
        Host.AnswerAChartPictureBox.Visible = False
        Host.AnswerBChartPictureBox.Visible = False
        Host.AnswerCChartPictureBox.Visible = False
        Host.AnswerDChartPictureBox.Visible = False
        'Экран игрока
        Player.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\Player Screen.png")
        Player.AnswerAPercentLabel.Visible = False
        Player.AnswerBPercentLabel.Visible = False
        Player.AnswerCPercentLabel.Visible = False
        Player.AnswerDPercentLabel.Visible = False
        Player.AnswerAChartPictureBox.Visible = False
        Player.AnswerBChartPictureBox.Visible = False
        Player.AnswerCChartPictureBox.Visible = False
        Player.AnswerDChartPictureBox.Visible = False
        'Экран зрителей
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
        Audience.AnswerAPercentLabel.Visible = False
        Audience.AnswerBPercentLabel.Visible = False
        Audience.AnswerCPercentLabel.Visible = False
        Audience.AnswerDPercentLabel.Visible = False
        Audience.AnswerAChartPictureBox.Visible = False
        Audience.AnswerBChartPictureBox.Visible = False
        Audience.AnswerCChartPictureBox.Visible = False
        Audience.AnswerDChartPictureBox.Visible = False
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
        Project.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        'Сеть
        If Project.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ata_closed|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub
End Class