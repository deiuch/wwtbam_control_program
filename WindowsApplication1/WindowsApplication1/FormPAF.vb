Public Class FormPAF
    Public clockFrame As Integer

    Private Sub FormPAF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        'Перевод "D" FormPAF
        Me.Text = Project.currentBlock1(106, 3) '0
        StartPhoneAFriendButton.Text = Project.currentBlock1(107, 3) '1
        StartClockButton.Text = Project.currentBlock1(108, 3) '2
        StopClockButton.Text = Project.currentBlock1(109, 3) '3
    End Sub

    Private Sub StartPhoneAFriendButton_Click(sender As Object, e As EventArgs) Handles StartPhoneAFriendButton.Click
        ClockTimer.Stop()
        My.Computer.Audio.Play("source\MUSIC\Phone a Friend.wav", AudioPlayMode.Background)
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        Host.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        Player.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        Audience.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        Host.ClockPictureBox.Visible = False
        Player.ClockPictureBox.Visible = False
        Audience.ClockPictureBox.Visible = False
        'Сеть
        If Project.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@paf_button1|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub StartClockButton_Click(sender As Object, e As EventArgs) Handles StartClockButton.Click
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        ClockTimer.Stop()
        clockFrame = 1
        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        Host.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        Player.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        Audience.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        ClockTimer.Start()
        My.Computer.Audio.Play("source\MUSIC\Friend Clock.wav", AudioPlayMode.Background)
        Host.ClockPictureBox.Visible = True
        Player.ClockPictureBox.Visible = True
        Audience.ClockPictureBox.Visible = True
        'Сеть
        If Project.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@paf_button2|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ClockTimer_Tick(sender As Object, e As EventArgs) Handles ClockTimer.Tick
        clockFrame = clockFrame + 1
        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        Host.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        Player.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        Audience.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        If clockFrame = 61 Then
            ClockTimer.Stop()
            Project.PhoneAFriendAvailableCheckBox.Checked = False
        End If
    End Sub

    Private Sub StopClockButton_Click(sender As Object, e As EventArgs) Handles StopClockButton.Click
        My.Computer.Audio.Play("source\MUSIC\Interrupted Clock.wav", AudioPlayMode.Background)
        ClockTimer.Stop()
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        Project.PhoneAFriendAvailableCheckBox.Checked = False
        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
        Host.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
        Player.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
        Audience.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
        'Сеть
        If Project.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@paf_button3|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub FormPAF_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        ClockTimer.Stop()
        My.Computer.Audio.Stop()
        Host.ClockPictureBox.Visible = False
        Player.ClockPictureBox.Visible = False
        Audience.ClockPictureBox.Visible = False
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
                .Command = "@paf_closed|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub
End Class