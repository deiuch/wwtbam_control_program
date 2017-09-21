Public Class FormPAF
    Public clockFrame As Integer

    Private Sub FormPAF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        'Перевод "D" FormPAF
        Me.Text = Project.currentBlock1(106, 3) '0
        Button1.Text = Project.currentBlock1(107, 3) '1
        Button2.Text = Project.currentBlock1(108, 3) '2
        Button3.Text = Project.currentBlock1(109, 3) '3
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Stop()
        My.Computer.Audio.Play("source\MUSIC\Phone a Friend.wav", AudioPlayMode.Background)
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        PictureBox1.ImageLocation = "source\CLOCK\Clock (1).png"
        Host.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
        Player.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
        Audience.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
        Host.PictureBox8.Visible = False
        Player.PictureBox8.Visible = False
        Audience.PictureBox8.Visible = False
        'Сеть
        If Project.Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@paf_button1|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        Timer1.Stop()
        clockFrame = 1
        PictureBox1.ImageLocation = "source\CLOCK\Clock (1).png"
        Host.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
        Player.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
        Audience.PictureBox8.ImageLocation = "source\CLOCK\Clock (1).png"
        Timer1.Start()
        My.Computer.Audio.Play("source\MUSIC\Friend Clock.wav", AudioPlayMode.Background)
        Host.PictureBox8.Visible = True
        Player.PictureBox8.Visible = True
        Audience.PictureBox8.Visible = True
        'Сеть
        If Project.Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@paf_button2|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        clockFrame = clockFrame + 1
        PictureBox1.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        Host.PictureBox8.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        Player.PictureBox8.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        Audience.PictureBox8.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        If clockFrame = 61 Then
            Timer1.Stop()
            Project.CheckBox2.Checked = False
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        My.Computer.Audio.Play("source\MUSIC\Interrupted Clock.wav", AudioPlayMode.Background)
        Timer1.Stop()
        If Project.winampOn <> 0 Then
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        End If
        Project.CheckBox2.Checked = False
        PictureBox1.ImageLocation = "source\CLOCK\Clock (62).png"
        Host.PictureBox8.ImageLocation = "source\CLOCK\Clock (62).png"
        Player.PictureBox8.ImageLocation = "source\CLOCK\Clock (62).png"
        Audience.PictureBox8.ImageLocation = "source\CLOCK\Clock (62).png"
        'Сеть
        If Project.Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@paf_button3|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub FormPAF_Closed(sender As Object, e As EventArgs) Handles MyBase.Closed
        Timer1.Stop()
        My.Computer.Audio.Stop()
        Host.PictureBox8.Visible = False
        Player.PictureBox8.Visible = False
        Audience.PictureBox8.Visible = False
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
                .Command = "@paf_closed|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub
End Class