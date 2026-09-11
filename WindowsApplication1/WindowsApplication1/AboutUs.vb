Public Class AboutUs

    Private Sub AboutUs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        LogoPictureBox.ImageLocation = Project.langSource & "\LOGO.png"
        'Перевод "H" AboutUs
        Me.Text = Project.currentBlock1(141, 3) '0
        CreditsLabel.Text = Project.currentBlock1(142, 3).Replace("¶", Chr(13) & Chr(10)) '1
    End Sub
End Class