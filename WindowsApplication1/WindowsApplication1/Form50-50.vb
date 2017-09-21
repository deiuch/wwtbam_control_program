Public Class Form50_50

    Private Sub Form50_50_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Select Case Project.numberRightAnswer
            Case 1
                CheckBox1.Enabled = False
                Label1.ForeColor = Color.Green
            Case 2
                CheckBox2.Enabled = False
                Label2.ForeColor = Color.Green
            Case 3
                CheckBox3.Enabled = False
                Label3.ForeColor = Color.Green
            Case 4
                CheckBox4.Enabled = False
                Label4.ForeColor = Color.Green
        End Select
        If Project.Button8.BackColor = Color.Yellow Or Project.Button9.BackColor = Color.Yellow Or Project.Button10.BackColor = Color.Yellow Or Project.Button11.BackColor = Color.Yellow Then
            If Project.Label17.Text <> Nothing Then CheckBox1.Checked = True
            If Project.Label18.Text <> Nothing Then CheckBox2.Checked = True
            If Project.Label19.Text <> Nothing Then CheckBox3.Checked = True
            If Project.Label20.Text <> Nothing Then CheckBox4.Checked = True
        End If
        'Перевод "C" Form50_50
        Me.Text = Project.currentBlock1(99, 3) '0
        CheckBox1.Text = Project.currentBlock1(100, 3) '1
        CheckBox2.Text = Project.currentBlock1(101, 3) '2
        CheckBox3.Text = Project.currentBlock1(102, 3) '3
        CheckBox4.Text = Project.currentBlock1(103, 3) '4
        Button1.Text = Project.currentBlock1(104, 3) '5
        Button2.Text = Project.currentBlock1(105, 3) '6
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If CheckBox1.Checked = True Then
            Project.Label17.Text = Project.textAnswerA
            Label1.Text = "A"
            Project.Button8.BackColor = Color.Yellow
        Else
            Project.Label17.Text = ""
            Label1.Text = ""
            Project.Button8.BackColor = Color.White
        End If
        If CheckBox2.Checked = True Then
            Project.Label18.Text = Project.textAnswerB
            Label2.Text = "B"
            Project.Button9.BackColor = Color.Yellow
        Else
            Project.Label18.Text = ""
            Label2.Text = ""
            Project.Button9.BackColor = Color.White
        End If
        If CheckBox3.Checked = True Then
            Project.Label19.Text = Project.textAnswerC
            Label3.Text = "C"
            Project.Button10.BackColor = Color.Yellow
        Else
            Project.Label19.Text = ""
            Label3.Text = ""
            Project.Button10.BackColor = Color.White
        End If
        If CheckBox4.Checked = True Then
            Project.Label20.Text = Project.textAnswerD
            Label4.Text = "D"
            Project.Button11.BackColor = Color.Yellow
        Else
            Project.Label20.Text = ""
            Label4.Text = ""
            Project.Button11.BackColor = Color.White
        End If
        My.Computer.Audio.Play("source\MUSIC\50-50.wav", AudioPlayMode.Background)
        Project.CheckBox1.Checked = False
        Project.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        'Сеть
        If Project.Button7.BackColor = Color.Green Then
            Dim NetworkInfo As New IONetwork
            With NetworkInfo
                .Command = "@50-50_button1|" & Project.Label17.Text & "|" & Project.Label18.Text & "|" & Project.Label19.Text & "|" & Project.Label20.Text & "|"
            End With
            Project.Client_SendIONetwork(NetworkInfo)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Randomise
        Dim rand As New Random()
        Dim rand1 As Integer
        Dim check As Boolean = False
        CheckBox1.Checked = True
        CheckBox2.Checked = True
        CheckBox3.Checked = True
        CheckBox4.Checked = True
        Do
            rand1 = rand.Next(5)
            If rand1 <> Project.numberRightAnswer And rand1 <> 0 Then
                check = True
            End If
        Loop Until check = True
        
        Select Case rand1
            Case 1
                CheckBox2.Checked = False
                CheckBox3.Checked = False
                CheckBox4.Checked = False
            Case 2
                CheckBox1.Checked = False
                CheckBox3.Checked = False
                CheckBox4.Checked = False
            Case 3
                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox4.Checked = False
            Case 4
                CheckBox1.Checked = False
                CheckBox2.Checked = False
                CheckBox3.Checked = False
        End Select
        Select Case Project.numberRightAnswer
            Case 1
                CheckBox1.Checked = True
            Case 2
                CheckBox2.Checked = True
            Case 3
                CheckBox3.Checked = True
            Case 4
                CheckBox4.Checked = True
        End Select
    End Sub

    Private Sub FormATA_Closed(sender As Object, e As EventArgs) Handles MyBase.FormClosed
        Project.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Host.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Player.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
        Audience.PictureBox7.ImageLocation = "source\LIFELINES\" & Project.activ50 & Project.activPAF & Project.activATA & ".png"
    End Sub
End Class