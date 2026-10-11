Public Class AskTheAudienceForm
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
        'Перевод "E" AskTheAudienceForm
        Text = GameControlForm.currentBlock1(110, 3) '0
        StartAskTheAudienceButton.Text = GameControlForm.currentBlock1(111, 3) '1
        StartVotingButton.Text = GameControlForm.currentBlock1(112, 3) '2
        AnswerAOrLabel.Text = GameControlForm.currentBlock1(113, 3) '3
        AnswerBOrLabel.Text = GameControlForm.currentBlock1(113, 3) '3
        AnswerCOrLabel.Text = GameControlForm.currentBlock1(113, 3) '3
        AnswerDOrLabel.Text = GameControlForm.currentBlock1(113, 3) '3
        TotalVotesLabel.Text = GameControlForm.currentBlock1(114, 3) '4
        TotalPercentLabel.Text = GameControlForm.currentBlock1(115, 3) '5
        ExecuteButton.Text = GameControlForm.currentBlock1(116, 3) '6
        AnswerAResultLabel.Font = New Font(GameControlForm.currentBlock1(6, 3), Int(GameControlForm.currentBlock1(6, 4)))
        AnswerBResultLabel.Font = New Font(GameControlForm.currentBlock1(6, 3), Int(GameControlForm.currentBlock1(6, 4)))
        AnswerCResultLabel.Font = New Font(GameControlForm.currentBlock1(6, 3), Int(GameControlForm.currentBlock1(6, 4)))
        AnswerDResultLabel.Font = New Font(GameControlForm.currentBlock1(6, 3), Int(GameControlForm.currentBlock1(6, 4)))
    End Sub

    Private Sub StartAskTheAudienceButton_Click(sender As Object, e As EventArgs) Handles StartAskTheAudienceButton.Click
        If GameControlForm.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            GameControlForm.winampOn = 0
        End If
        My.Computer.Audio.Play("source\MUSIC\Ask the Audience.wav", AudioPlayMode.Background)
    End Sub

    Private Sub StartVotingButton_Click(sender As Object, e As EventArgs) Handles StartVotingButton.Click
        HostScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\Host Screen ATA.png")
        PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\Player Screen ATA.png")
        AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\Audience Screen ATA.png")
        If GameControlForm.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            GameControlForm.winampOn = 0
        End If
        My.Computer.Audio.Play("source\MUSIC\Audience Keyboards.wav", AudioPlayMode.Background)
        'Сеть
        If GameControlForm.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ata_start_voting|"
            End With
            GameControlForm.Client_SendIONetwork(NetworkInfo)
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
        HostScreenForm.AnswerAPercentLabel.Text = AnswerAPercentNumericUpDown.Value & "%"
        HostScreenForm.AnswerBPercentLabel.Text = AnswerBPercentNumericUpDown.Value & "%"
        HostScreenForm.AnswerCPercentLabel.Text = AnswerCPercentNumericUpDown.Value & "%"
        HostScreenForm.AnswerDPercentLabel.Text = AnswerDPercentNumericUpDown.Value & "%"
        HostScreenForm.AnswerAPercentLabel.Visible = True
        HostScreenForm.AnswerBPercentLabel.Visible = True
        HostScreenForm.AnswerCPercentLabel.Visible = True
        HostScreenForm.AnswerDPercentLabel.Visible = True
        HostScreenForm.AnswerAChartPictureBox.Visible = True
        HostScreenForm.AnswerBChartPictureBox.Visible = True
        HostScreenForm.AnswerCChartPictureBox.Visible = True
        HostScreenForm.AnswerDChartPictureBox.Visible = True
        HostScreenForm.AnswerAChartPictureBox.Height = percentsA * 1.2
        HostScreenForm.AnswerBChartPictureBox.Height = percentsB * 1.2
        HostScreenForm.AnswerCChartPictureBox.Height = percentsC * 1.2
        HostScreenForm.AnswerDChartPictureBox.Height = percentsD * 1.2
        HostScreenForm.AnswerAChartPictureBox.Top = 515 - percentsA * 1.2
        HostScreenForm.AnswerBChartPictureBox.Top = 515 - percentsB * 1.2
        HostScreenForm.AnswerCChartPictureBox.Top = 515 - percentsC * 1.2
        HostScreenForm.AnswerDChartPictureBox.Top = 515 - percentsD * 1.2
        'Экран игрока
        PlayerScreenForm.AnswerAPercentLabel.Text = AnswerAPercentNumericUpDown.Value & "%"
        PlayerScreenForm.AnswerBPercentLabel.Text = AnswerBPercentNumericUpDown.Value & "%"
        PlayerScreenForm.AnswerCPercentLabel.Text = AnswerCPercentNumericUpDown.Value & "%"
        PlayerScreenForm.AnswerDPercentLabel.Text = AnswerDPercentNumericUpDown.Value & "%"
        PlayerScreenForm.AnswerAPercentLabel.Visible = True
        PlayerScreenForm.AnswerBPercentLabel.Visible = True
        PlayerScreenForm.AnswerCPercentLabel.Visible = True
        PlayerScreenForm.AnswerDPercentLabel.Visible = True
        PlayerScreenForm.AnswerAChartPictureBox.Visible = True
        PlayerScreenForm.AnswerBChartPictureBox.Visible = True
        PlayerScreenForm.AnswerCChartPictureBox.Visible = True
        PlayerScreenForm.AnswerDChartPictureBox.Visible = True
        PlayerScreenForm.AnswerAChartPictureBox.Height = percentsA * 2.4
        PlayerScreenForm.AnswerBChartPictureBox.Height = percentsB * 2.4
        PlayerScreenForm.AnswerCChartPictureBox.Height = percentsC * 2.4
        PlayerScreenForm.AnswerDChartPictureBox.Height = percentsD * 2.4
        PlayerScreenForm.AnswerAChartPictureBox.Top = 538 - percentsA * 2.4
        PlayerScreenForm.AnswerBChartPictureBox.Top = 538 - percentsB * 2.4
        PlayerScreenForm.AnswerCChartPictureBox.Top = 538 - percentsC * 2.4
        PlayerScreenForm.AnswerDChartPictureBox.Top = 538 - percentsD * 2.4
        'Экран зрителей
        AudienceScreenForm.AnswerAPercentLabel.Text = AnswerAPercentNumericUpDown.Value & "%"
        AudienceScreenForm.AnswerBPercentLabel.Text = AnswerBPercentNumericUpDown.Value & "%"
        AudienceScreenForm.AnswerCPercentLabel.Text = AnswerCPercentNumericUpDown.Value & "%"
        AudienceScreenForm.AnswerDPercentLabel.Text = AnswerDPercentNumericUpDown.Value & "%"
        AudienceScreenForm.AnswerAPercentLabel.Visible = True
        AudienceScreenForm.AnswerBPercentLabel.Visible = True
        AudienceScreenForm.AnswerCPercentLabel.Visible = True
        AudienceScreenForm.AnswerDPercentLabel.Visible = True
        AudienceScreenForm.AnswerAChartPictureBox.Visible = True
        AudienceScreenForm.AnswerBChartPictureBox.Visible = True
        AudienceScreenForm.AnswerCChartPictureBox.Visible = True
        AudienceScreenForm.AnswerDChartPictureBox.Visible = True
        AudienceScreenForm.AnswerAChartPictureBox.Height = percentsA * 2.4
        AudienceScreenForm.AnswerBChartPictureBox.Height = percentsB * 2.4
        AudienceScreenForm.AnswerCChartPictureBox.Height = percentsC * 2.4
        AudienceScreenForm.AnswerDChartPictureBox.Height = percentsD * 2.4
        AudienceScreenForm.AnswerAChartPictureBox.Top = 347 - percentsA * 2.4
        AudienceScreenForm.AnswerBChartPictureBox.Top = 347 - percentsB * 2.4
        AudienceScreenForm.AnswerCChartPictureBox.Top = 347 - percentsC * 2.4
        AudienceScreenForm.AnswerDChartPictureBox.Top = 347 - percentsD * 2.4
        My.Computer.Audio.Play("source\MUSIC\Audience Decide.wav", AudioPlayMode.Background)
        GameControlForm.HostMessageTextBox.Text = "-A: " & percentsA & "% -B: " & percentsB & "% -C: " & percentsC & "% -D: " & percentsD & "%"
        HostScreenForm.HostMessageLabel.Text = "-A: " & percentsA & "% -B: " & percentsB & "% -C: " & percentsC & "% -D: " & percentsD & "%"
        GameControlForm.AskTheAudienceAvailableCheckBox.Checked = False
        'Сеть
        If GameControlForm.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ata_execute|" & percentsA & "|" & percentsB & "|" & percentsC & "|" & percentsD & "|" & AnswerAPercentNumericUpDown.Value & "|" & AnswerBPercentNumericUpDown.Value & "|" & AnswerCPercentNumericUpDown.Value & "|" & AnswerDPercentNumericUpDown.Value & "|" & GameControlForm.HostMessageTextBox.Text & "|"
            End With
            GameControlForm.Client_SendIONetwork(NetworkInfo)
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
        TotalVotesLabel.Text = GameControlForm.currentBlock1(114, 3) & " " & voicesSum
        TotalPercentLabel.Text = GameControlForm.currentBlock1(115, 3) & " " & percentsSum & "%"
        If percentsSum <> 100 Then
            TotalPercentLabel.ForeColor = Color.Red
        Else
            TotalPercentLabel.ForeColor = Color.White
        End If
    End Sub

    Private Sub AnswerAPercentNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles AnswerAPercentNumericUpDown.ValueChanged, AnswerBPercentNumericUpDown.ValueChanged, AnswerCPercentNumericUpDown.ValueChanged, AnswerDPercentNumericUpDown.ValueChanged
        percentsSum = AnswerAPercentNumericUpDown.Value + AnswerBPercentNumericUpDown.Value + AnswerCPercentNumericUpDown.Value + AnswerDPercentNumericUpDown.Value
        TotalPercentLabel.Text = GameControlForm.currentBlock1(115, 3) & " " & percentsSum & "%"
        If percentsSum <> 100 Then
            TotalPercentLabel.ForeColor = Color.Red
        Else
            TotalPercentLabel.ForeColor = Color.White
        End If
    End Sub

    Private Sub FormATA_Closed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        'Экран ведущего
        HostScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\Player Screen.png")
        HostScreenForm.AnswerAPercentLabel.Visible = False
        HostScreenForm.AnswerBPercentLabel.Visible = False
        HostScreenForm.AnswerCPercentLabel.Visible = False
        HostScreenForm.AnswerDPercentLabel.Visible = False
        HostScreenForm.AnswerAChartPictureBox.Visible = False
        HostScreenForm.AnswerBChartPictureBox.Visible = False
        HostScreenForm.AnswerCChartPictureBox.Visible = False
        HostScreenForm.AnswerDChartPictureBox.Visible = False
        'Экран игрока
        PlayerScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\Player Screen.png")
        PlayerScreenForm.AnswerAPercentLabel.Visible = False
        PlayerScreenForm.AnswerBPercentLabel.Visible = False
        PlayerScreenForm.AnswerCPercentLabel.Visible = False
        PlayerScreenForm.AnswerDPercentLabel.Visible = False
        PlayerScreenForm.AnswerAChartPictureBox.Visible = False
        PlayerScreenForm.AnswerBChartPictureBox.Visible = False
        PlayerScreenForm.AnswerCChartPictureBox.Visible = False
        PlayerScreenForm.AnswerDChartPictureBox.Visible = False
        'Экран зрителей
        AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\BG4.jpg")
        AudienceScreenForm.AnswerAPercentLabel.Visible = False
        AudienceScreenForm.AnswerBPercentLabel.Visible = False
        AudienceScreenForm.AnswerCPercentLabel.Visible = False
        AudienceScreenForm.AnswerDPercentLabel.Visible = False
        AudienceScreenForm.AnswerAChartPictureBox.Visible = False
        AudienceScreenForm.AnswerBChartPictureBox.Visible = False
        AudienceScreenForm.AnswerCChartPictureBox.Visible = False
        AudienceScreenForm.AnswerDChartPictureBox.Visible = False
        My.Computer.Audio.Stop()
        Select Case GameControlForm.questionNumber
            Case 0 To 5
                'Обращение к *.bat файлу для включения внешнего проигрывателя
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q1-5 Bed Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 6
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q6 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 7
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q7 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 8
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q8 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 9
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q9 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 10
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q10 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 11
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q11 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 12
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q12 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 13
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q13 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 14
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q14 - Heartbeat Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
            Case 15
                If GameControlForm.winampOn <> 1 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Q15 - Heartbeat (R1 000 000) Loop.wav" & Chr(34)
                    Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
                    GameControlForm.winampOn = 1
                End If
        End Select
        GameControlForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        'Сеть
        If GameControlForm.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@ata_closed|"
            End With
            GameControlForm.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub
End Class
