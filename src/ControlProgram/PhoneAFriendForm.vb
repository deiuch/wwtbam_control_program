Public Class PhoneAFriendForm
    Public clockFrame As Integer

    Private Sub FormPAF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        'Перевод "D" PhoneAFriendForm
        Me.Text = GameControlForm.currentBlock1(106, 3) '0
        StartPhoneAFriendButton.Text = GameControlForm.currentBlock1(107, 3) '1
        StartClockButton.Text = GameControlForm.currentBlock1(108, 3) '2
        StopClockButton.Text = GameControlForm.currentBlock1(109, 3) '3
    End Sub

    Private Sub StartPhoneAFriendButton_Click(sender As Object, e As EventArgs) Handles StartPhoneAFriendButton.Click
        ClockTimer.Stop()
        SoundCues.Play("source\MUSIC\Phone a Friend.wav")
        If GameControlForm.winampOn <> 0 Then
            BackgroundMusic.Stop()
            GameControlForm.winampOn = 0
        End If
        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        HostScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        PlayerScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        AudienceScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        HostScreenForm.ClockPictureBox.Visible = False
        PlayerScreenForm.ClockPictureBox.Visible = False
        AudienceScreenForm.ClockPictureBox.Visible = False
        'Сеть
        If GameControlForm.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@paf_start|"
            End With
            GameControlForm.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub StartClockButton_Click(sender As Object, e As EventArgs) Handles StartClockButton.Click
        If GameControlForm.winampOn <> 0 Then
            BackgroundMusic.Stop()
            GameControlForm.winampOn = 0
        End If
        ClockTimer.Stop()
        clockFrame = 1
        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        HostScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        PlayerScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        AudienceScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (1).png"
        ClockTimer.Start()
        SoundCues.Play("source\MUSIC\Friend Clock.wav")
        HostScreenForm.ClockPictureBox.Visible = True
        PlayerScreenForm.ClockPictureBox.Visible = True
        AudienceScreenForm.ClockPictureBox.Visible = True
        'Сеть
        If GameControlForm.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@paf_clock_start|"
            End With
            GameControlForm.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub ClockTimer_Tick(sender As Object, e As EventArgs) Handles ClockTimer.Tick
        clockFrame = clockFrame + 1
        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        HostScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        PlayerScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        AudienceScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        If clockFrame = 61 Then
            ClockTimer.Stop()
            GameControlForm.PhoneAFriendAvailableCheckBox.Checked = False
        End If
    End Sub

    Private Sub StopClockButton_Click(sender As Object, e As EventArgs) Handles StopClockButton.Click
        SoundCues.Play("source\MUSIC\Interrupted Clock.wav")
        ClockTimer.Stop()
        If GameControlForm.winampOn <> 0 Then
            BackgroundMusic.Stop()
            GameControlForm.winampOn = 0
        End If
        GameControlForm.PhoneAFriendAvailableCheckBox.Checked = False
        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
        HostScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
        PlayerScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
        AudienceScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
        'Сеть
        If GameControlForm.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@paf_clock_stop|"
            End With
            GameControlForm.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub FormPAF_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        ClockTimer.Stop()
        SoundCues.Stop()
        HostScreenForm.ClockPictureBox.Visible = False
        PlayerScreenForm.ClockPictureBox.Visible = False
        AudienceScreenForm.ClockPictureBox.Visible = False
        Select Case GameControlForm.questionNumber
            Case 0 To 5
                'Включение фоновой музыки
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q1-5 Bed Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 6
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q6 - Heartbeat Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 7
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q7 - Heartbeat Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 8
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q8 - Heartbeat Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 9
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q9 - Heartbeat Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 10
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q10 - Heartbeat Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 11
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q11 - Heartbeat Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 12
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q12 - Heartbeat Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 13
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q13 - Heartbeat Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 14
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q14 - Heartbeat Loop.wav")
                    GameControlForm.winampOn = 1
                End If
            Case 15
                If GameControlForm.winampOn <> 1 Then
                    BackgroundMusic.PlayLoop(GameControlForm.sourcePath & "\MUSIC\Q15 - Heartbeat (R1 000 000) Loop.wav")
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
                .Command = "@paf_closed|"
            End With
            GameControlForm.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub
End Class
