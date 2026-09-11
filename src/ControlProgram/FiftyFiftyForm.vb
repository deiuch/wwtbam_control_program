Public Class FiftyFiftyForm

    Private Sub Form50_50_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Select Case GameControlForm.numberRightAnswer
            Case 1
                KeepAnswerACheckBox.Enabled = False
                AnswerALetterLabel.ForeColor = Color.Green
            Case 2
                KeepAnswerBCheckBox.Enabled = False
                AnswerBLetterLabel.ForeColor = Color.Green
            Case 3
                KeepAnswerCCheckBox.Enabled = False
                AnswerCLetterLabel.ForeColor = Color.Green
            Case 4
                KeepAnswerDCheckBox.Enabled = False
                AnswerDLetterLabel.ForeColor = Color.Green
        End Select
        If GameControlForm.ReceiveAnswerAButton.BackColor = Color.Yellow Or GameControlForm.ReceiveAnswerBButton.BackColor = Color.Yellow Or GameControlForm.ReceiveAnswerCButton.BackColor = Color.Yellow Or GameControlForm.ReceiveAnswerDButton.BackColor = Color.Yellow Then
            If GameControlForm.AnswerATextLabel.Text <> Nothing Then KeepAnswerACheckBox.Checked = True
            If GameControlForm.AnswerBTextLabel.Text <> Nothing Then KeepAnswerBCheckBox.Checked = True
            If GameControlForm.AnswerCTextLabel.Text <> Nothing Then KeepAnswerCCheckBox.Checked = True
            If GameControlForm.AnswerDTextLabel.Text <> Nothing Then KeepAnswerDCheckBox.Checked = True
        End If
        'Перевод "C" FiftyFiftyForm
        Me.Text = GameControlForm.currentBlock1(99, 3) '0
        KeepAnswerACheckBox.Text = GameControlForm.currentBlock1(100, 3) '1
        KeepAnswerBCheckBox.Text = GameControlForm.currentBlock1(101, 3) '2
        KeepAnswerCCheckBox.Text = GameControlForm.currentBlock1(102, 3) '3
        KeepAnswerDCheckBox.Text = GameControlForm.currentBlock1(103, 3) '4
        ExecuteButton.Text = GameControlForm.currentBlock1(104, 3) '5
        RandomiseButton.Text = GameControlForm.currentBlock1(105, 3) '6
    End Sub

    Private Sub ExecuteButton_Click(sender As Object, e As EventArgs) Handles ExecuteButton.Click
        If KeepAnswerACheckBox.Checked = True Then
            GameControlForm.AnswerATextLabel.Text = GameControlForm.textAnswerA
            AnswerALetterLabel.Text = "A"
            GameControlForm.ReceiveAnswerAButton.BackColor = Color.Yellow
        Else
            GameControlForm.AnswerATextLabel.Text = ""
            AnswerALetterLabel.Text = ""
            GameControlForm.ReceiveAnswerAButton.BackColor = Color.White
        End If
        If KeepAnswerBCheckBox.Checked = True Then
            GameControlForm.AnswerBTextLabel.Text = GameControlForm.textAnswerB
            AnswerBLetterLabel.Text = "B"
            GameControlForm.ReceiveAnswerBButton.BackColor = Color.Yellow
        Else
            GameControlForm.AnswerBTextLabel.Text = ""
            AnswerBLetterLabel.Text = ""
            GameControlForm.ReceiveAnswerBButton.BackColor = Color.White
        End If
        If KeepAnswerCCheckBox.Checked = True Then
            GameControlForm.AnswerCTextLabel.Text = GameControlForm.textAnswerC
            AnswerCLetterLabel.Text = "C"
            GameControlForm.ReceiveAnswerCButton.BackColor = Color.Yellow
        Else
            GameControlForm.AnswerCTextLabel.Text = ""
            AnswerCLetterLabel.Text = ""
            GameControlForm.ReceiveAnswerCButton.BackColor = Color.White
        End If
        If KeepAnswerDCheckBox.Checked = True Then
            GameControlForm.AnswerDTextLabel.Text = GameControlForm.textAnswerD
            AnswerDLetterLabel.Text = "D"
            GameControlForm.ReceiveAnswerDButton.BackColor = Color.Yellow
        Else
            GameControlForm.AnswerDTextLabel.Text = ""
            AnswerDLetterLabel.Text = ""
            GameControlForm.ReceiveAnswerDButton.BackColor = Color.White
        End If
        My.Computer.Audio.Play("source\MUSIC\50-50.wav", AudioPlayMode.Background)
        GameControlForm.FiftyFiftyAvailableCheckBox.Checked = False
        GameControlForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        'Сеть
        If GameControlForm.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@fifty_fifty_execute|" & GameControlForm.AnswerATextLabel.Text & "|" & GameControlForm.AnswerBTextLabel.Text & "|" & GameControlForm.AnswerCTextLabel.Text & "|" & GameControlForm.AnswerDTextLabel.Text & "|"
            End With
            GameControlForm.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub RandomiseButton_Click(sender As Object, e As EventArgs) Handles RandomiseButton.Click
        'Randomise
        Dim rand As New Random()
        Dim rand1 As Integer
        Dim check As Boolean = False
        KeepAnswerACheckBox.Checked = True
        KeepAnswerBCheckBox.Checked = True
        KeepAnswerCCheckBox.Checked = True
        KeepAnswerDCheckBox.Checked = True
        Do
            rand1 = rand.Next(5)
            If rand1 <> GameControlForm.numberRightAnswer And rand1 <> 0 Then
                check = True
            End If
        Loop Until check = True
        
        Select Case rand1
            Case 1
                KeepAnswerBCheckBox.Checked = False
                KeepAnswerCCheckBox.Checked = False
                KeepAnswerDCheckBox.Checked = False
            Case 2
                KeepAnswerACheckBox.Checked = False
                KeepAnswerCCheckBox.Checked = False
                KeepAnswerDCheckBox.Checked = False
            Case 3
                KeepAnswerACheckBox.Checked = False
                KeepAnswerBCheckBox.Checked = False
                KeepAnswerDCheckBox.Checked = False
            Case 4
                KeepAnswerACheckBox.Checked = False
                KeepAnswerBCheckBox.Checked = False
                KeepAnswerCCheckBox.Checked = False
        End Select
        Select Case GameControlForm.numberRightAnswer
            Case 1
                KeepAnswerACheckBox.Checked = True
            Case 2
                KeepAnswerBCheckBox.Checked = True
            Case 3
                KeepAnswerCCheckBox.Checked = True
            Case 4
                KeepAnswerDCheckBox.Checked = True
        End Select
    End Sub

    Private Sub FormATA_Closed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        GameControlForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        HostScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        PlayerScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
        AudienceScreenForm.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & GameControlForm.activ50 & GameControlForm.activPAF & GameControlForm.activATA & ".png"
    End Sub
End Class