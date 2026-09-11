Public Class AboutForm

    Private Sub AboutUs_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        LogoPictureBox.ImageLocation = GameControlForm.langSource & "\LOGO.png"
        'Перевод "H" AboutForm
        Me.Text = GameControlForm.currentBlock1(141, 3) '0
        CreditsLabel.Text = GameControlForm.currentBlock1(142, 3).Replace("¶", Chr(13) & Chr(10)) '1
    End Sub
End Class