Public Class Form50_50

    Private Sub Form50_50_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Select Case Project.numberRightAnswer
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
        If Project.ReceiveAnswerAButton.BackColor = Color.Yellow Or Project.ReceiveAnswerBButton.BackColor = Color.Yellow Or Project.ReceiveAnswerCButton.BackColor = Color.Yellow Or Project.ReceiveAnswerDButton.BackColor = Color.Yellow Then
            If Project.AnswerATextLabel.Text <> Nothing Then KeepAnswerACheckBox.Checked = True
            If Project.AnswerBTextLabel.Text <> Nothing Then KeepAnswerBCheckBox.Checked = True
            If Project.AnswerCTextLabel.Text <> Nothing Then KeepAnswerCCheckBox.Checked = True
            If Project.AnswerDTextLabel.Text <> Nothing Then KeepAnswerDCheckBox.Checked = True
        End If
        'Перевод "C" Form50_50
        Me.Text = Project.currentBlock1(99, 3) '0
        KeepAnswerACheckBox.Text = Project.currentBlock1(100, 3) '1
        KeepAnswerBCheckBox.Text = Project.currentBlock1(101, 3) '2
        KeepAnswerCCheckBox.Text = Project.currentBlock1(102, 3) '3
        KeepAnswerDCheckBox.Text = Project.currentBlock1(103, 3) '4
        ExecuteButton.Text = Project.currentBlock1(104, 3) '5
        RandomiseButton.Text = Project.currentBlock1(105, 3) '6
    End Sub

    Private Sub ExecuteButton_Click(sender As Object, e As EventArgs) Handles ExecuteButton.Click
        If KeepAnswerACheckBox.Checked = True Then
            Project.AnswerATextLabel.Text = Project.textAnswerA
            AnswerALetterLabel.Text = "A"
            Project.ReceiveAnswerAButton.BackColor = Color.Yellow
        Else
            Project.AnswerATextLabel.Text = ""
            AnswerALetterLabel.Text = ""
            Project.ReceiveAnswerAButton.BackColor = Color.White
        End If
        If KeepAnswerBCheckBox.Checked = True Then
            Project.AnswerBTextLabel.Text = Project.textAnswerB
            AnswerBLetterLabel.Text = "B"
            Project.ReceiveAnswerBButton.BackColor = Color.Yellow
        Else
            Project.AnswerBTextLabel.Text = ""
            AnswerBLetterLabel.Text = ""
            Project.ReceiveAnswerBButton.BackColor = Color.White
        End If
        If KeepAnswerCCheckBox.Checked = True Then
            Project.AnswerCTextLabel.Text = Project.textAnswerC
            AnswerCLetterLabel.Text = "C"
            Project.ReceiveAnswerCButton.BackColor = Color.Yellow
        Else
            Project.AnswerCTextLabel.Text = ""
            AnswerCLetterLabel.Text = ""
            Project.ReceiveAnswerCButton.BackColor = Color.White
        End If
        If KeepAnswerDCheckBox.Checked = True Then
            Project.AnswerDTextLabel.Text = Project.textAnswerD
            AnswerDLetterLabel.Text = "D"
            Project.ReceiveAnswerDButton.BackColor = Color.Yellow
        Else
            Project.AnswerDTextLabel.Text = ""
            AnswerDLetterLabel.Text = ""
            Project.ReceiveAnswerDButton.BackColor = Color.White
        End If
        My.Computer.Audio.Play("source\MUSIC\50-50.wav", AudioPlayMode.Background)
        Project.FiftyFiftyAvailableCheckBox.Checked = False
        Project.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        'Сеть
        If Project.ConnectButton.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@50-50_button1|" & Project.AnswerATextLabel.Text & "|" & Project.AnswerBTextLabel.Text & "|" & Project.AnswerCTextLabel.Text & "|" & Project.AnswerDTextLabel.Text & "|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
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
            If rand1 <> Project.numberRightAnswer And rand1 <> 0 Then
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
        Select Case Project.numberRightAnswer
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
        Project.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Host.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Player.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Audience.LifelinesPictureBox.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
    End Sub
End Class