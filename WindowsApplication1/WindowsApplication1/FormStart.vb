Imports System
Imports System.IO

Public Class FormStart
    Public currentBlock1(,) As String 'Массив русификации
    Public ini() As String 'Массив файла .ini
    Dim lang As String 'Путь языкового пакета
    Dim files() As String 'Массив списка файлов перевода

    Private Sub FormStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Project.OpenQuestionBaseDialog.InitialDirectory = "\Bases"
        My.Computer.Audio.Play("source\MUSIC\Roll 1.wav")
        Host.Hide()
        Player.Hide()
        Audience.Hide()
        'ini-файл
        If My.Computer.FileSystem.FileExists(CurDir() & "\wwtbam_set.ini") = False Then
            FileClose(1)
            FileOpen(1, CurDir() & "\wwtbam_set.ini", OpenMode.Output)
            Print(1, "|1|1|1|0|0|0|0|0|0||English|127.0.0.1|8000|||")
            FileClose(1)
        End If
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(CurDir() & "\wwtbam_set.ini", System.Text.Encoding.Default)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters("|")
            ReDim ini(25)
            ini = MyReader.ReadFields()
        End Using
        If ini(1) = "1" Then HostScreenCheckBox.Checked = True Else HostScreenCheckBox.Checked = False
        If ini(2) = "1" Then PlayerScreenCheckBox.Checked = True Else PlayerScreenCheckBox.Checked = False
        If ini(3) = "1" Then AudienceScreenCheckBox.Checked = True Else AudienceScreenCheckBox.Checked = False
        HostScreenXNumericUpDown.Value = ini(4)
        HostScreenYNumericUpDown.Value = ini(5)
        PlayerScreenXNumericUpDown.Value = ini(6)
        PlayerScreenYNumericUpDown.Value = ini(7)
        AudienceScreenXNumericUpDown.Value = ini(8)
        AudienceScreenYNumericUpDown.Value = ini(9)
        'Поиск файлов языка
        LanguageComboBox.Items.Clear()
        Dim currentRow As String()
        Dim i0 As Integer = 0
        Dim i1 As Integer = 0
        files = Directory.GetFiles(CurDir() & "\Languages", "*.lng")
        For x = 0 To files.GetUpperBound(0)
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(files(x), System.Text.Encoding.Default)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters("|")
                ReDim currentRow(5)
                currentRow = MyReader.ReadFields()
                LanguageComboBox.Items.Add(currentRow(2))
            End Using
        Next
        'Если языки не найдены
        If LanguageComboBox.Items.Count = 0 Then
            MsgBox("No language packs was found!" & Chr(13) & Chr(10) & "Языковые пакеты не обнаружены!")
            End
        End If
        LanguageComboBox.SelectedIndex = 0
        'Выбор последнего использованного языка
        Try
            LanguageComboBox.SelectedIndex = LanguageComboBox.FindStringExact(ini(11))
        Catch
        End Try
        If LanguageComboBox.SelectedIndex < 0 Then
            LanguageComboBox.SelectedIndex = 0
        End If
        'Поиск последнего открытого файла базы вопросов
        If My.Computer.FileSystem.FileExists(ini(10)) = True And Not ini(10) = Nothing Then QuestionBaseFileTextBox.Text = ini(10)
    End Sub

    Private Sub LanguageComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LanguageComboBox.SelectedIndexChanged
        'Выбор языка
        REM ****************************
        REM Языковая поддержка программы *.lng
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer = 0
        Dim i1 As Integer = 0
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(files(LanguageComboBox.SelectedIndex), System.Text.Encoding.Default)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters("|")
            ReDim currentRow(5)
            ReDim currentBlock1(150, 8)
            currentBlock1(2, 3) = "ENG_" '''''''''''''''
            currentBlock1(3, 3) = "\Source" '''''''''''
            While Not MyReader.EndOfData
                i0 = i0 + 1
                Try
                    currentRow = MyReader.ReadFields()
                    i1 = 0
                    For Each currentField In currentRow
                        i1 = i1 + 1
                        currentBlock1(i0, i1) = ""
                        currentBlock1(i0, i1) = currentField
                    Next
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                End Try
            End While
        End Using
        REM /Языковая поддержка программы *.lng
        REM /****************************
        'Перевод "A" FormStart
        Me.Text = currentBlock1(11, 3)
        TitleLabel.Text = currentBlock1(12, 3)
        HostScreenCheckBox.Text = currentBlock1(13, 3)
        PlayerScreenCheckBox.Text = currentBlock1(14, 3)
        AudienceScreenCheckBox.Text = currentBlock1(15, 3)
        QuestionBaseFileLabel.Text = currentBlock1(16, 3)
        QuestionBaseFileTextBox.Text = CurDir() & currentBlock1(17, 3)
        OpenQuestionBaseButton.Text = currentBlock1(18, 3)
        LanguageLabel.Text = currentBlock1(19, 3)
        StartButton.Text = currentBlock1(20, 3)
        'Размер шрифта FormStart
        'TitleLabel.Font = New Font(DefaultFont, Int(currentBlock1(12, 4)))
        'HostScreenCheckBox.Font = New Font(DefaultFont, Int(currentBlock1(13, 4)))
        'PlayerScreenCheckBox.Font = New Font(DefaultFont, Int(currentBlock1(14, 4)))
        'AudienceScreenCheckBox.Font = New Font(DefaultFont, Int(currentBlock1(15, 4)))
        'QuestionBaseFileLabel.Font = New Font(DefaultFont, Int(currentBlock1(16, 4)))
        'QuestionBaseFileTextBox.Font = New Font(DefaultFont, Int(currentBlock1(17, 4)))
        'OpenQuestionBaseButton.Font = New Font(DefaultFont, Int(currentBlock1(18, 4)))
        'LanguageLabel.Font = New Font(DefaultFont, Int(currentBlock1(19, 4)))
        'StartButton.Font = New Font(DefaultFont, Int(currentBlock1(20, 4)))
    End Sub

    Private Sub OpenQuestionBaseButton_Click(sender As Object, e As EventArgs) Handles OpenQuestionBaseButton.Click
        'Open button
        Project.OpenQuestionBaseDialog.FileName = "*.questions"
        Project.OpenQuestionBaseDialog.InitialDirectory = CurDir() & "\Bases"
        Project.OpenQuestionBaseDialog.CheckFileExists = True
        If Project.OpenQuestionBaseDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            QuestionBaseFileTextBox.Text = Project.OpenQuestionBaseDialog.FileName
        End If
        If QuestionBaseFileTextBox.Text = "*.question" Or QuestionBaseFileTextBox.Text = Nothing Then
            QuestionBaseFileTextBox.Text = CurDir() & "\Bases\" & Project.currentBlock1(2, 3) & "Base_Example.questions"
        End If
    End Sub

    Private Sub HostScreenXNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles HostScreenXNumericUpDown.ValueChanged, HostScreenYNumericUpDown.ValueChanged
        Host.Location = New Point(HostScreenXNumericUpDown.Value, HostScreenYNumericUpDown.Value)
    End Sub

    Private Sub PlayerScreenXNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles PlayerScreenXNumericUpDown.ValueChanged, PlayerScreenYNumericUpDown.ValueChanged
        Player.Location = New Point(PlayerScreenXNumericUpDown.Value, PlayerScreenYNumericUpDown.Value)
    End Sub

    Private Sub AudienceScreenXNumericUpDown_ValueChanged(sender As Object, e As EventArgs) Handles AudienceScreenXNumericUpDown.ValueChanged, AudienceScreenYNumericUpDown.ValueChanged
        Audience.Location = New Point(AudienceScreenXNumericUpDown.Value, AudienceScreenYNumericUpDown.Value)
    End Sub

    Private Sub StartButton_Click(sender As Object, e As EventArgs) Handles StartButton.Click
        If My.Computer.FileSystem.FileExists(QuestionBaseFileTextBox.Text) = True Then
            Me.Cursor = Cursors.WaitCursor
            'Перевод
            For i1 = 1 To currentBlock1.GetUpperBound(0)
                For i2 = 1 To 6
                    Project.currentBlock1(i1, i2) = currentBlock1(i1, i2)
                Next
            Next
            ini(11) = LanguageComboBox.SelectedItem
            For x = 1 To ini.GetUpperBound(0)
                Project.ini(x) = ini(x)
            Next
            My.Computer.Audio.Play("source\MUSIC\Roll 2.wav")
            Project.HostVisibleCheckBox.Checked = HostScreenCheckBox.Checked
            Project.PlayerVisibleCheckBox.Checked = PlayerScreenCheckBox.Checked
            Project.AudienceVisibleCheckBox.Checked = AudienceScreenCheckBox.Checked
            Project.HostScreenXNumericUpDown.Value = HostScreenXNumericUpDown.Value
            Project.HostScreenYNumericUpDown.Value = HostScreenYNumericUpDown.Value
            Project.PlayerScreenXNumericUpDown.Value = PlayerScreenXNumericUpDown.Value
            Project.PlayerScreenYNumericUpDown.Value = PlayerScreenYNumericUpDown.Value
            Project.AudienceScreenXNumericUpDown.Value = AudienceScreenXNumericUpDown.Value
            Project.AudienceScreenYNumericUpDown.Value = AudienceScreenYNumericUpDown.Value
            Project.FileNameQ = QuestionBaseFileTextBox.Text
            Call Project.openfilesdata(Project.FileNameQ)
            Project.Show()
        Else
            MsgBox(currentBlock1(146, 4), MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FormClosing
        If HostScreenCheckBox.Checked = True Then ini(1) = "1" Else ini(1) = "0"
        If PlayerScreenCheckBox.Checked = True Then ini(2) = "1" Else ini(2) = "0"
        If AudienceScreenCheckBox.Checked = True Then ini(3) = "1" Else ini(3) = "0"
        ini(4) = HostScreenXNumericUpDown.Value
        ini(5) = HostScreenYNumericUpDown.Value
        ini(6) = PlayerScreenXNumericUpDown.Value
        ini(7) = PlayerScreenYNumericUpDown.Value
        ini(8) = AudienceScreenXNumericUpDown.Value
        ini(9) = AudienceScreenYNumericUpDown.Value
        ini(10) = QuestionBaseFileTextBox.Text
        ini(11) = LanguageComboBox.SelectedItem
        FileClose(1)
        FileOpen(1, CurDir() & "\wwtbam_set.ini", OpenMode.Output)
        Print(1, "|" & ini(1) & "|" & ini(2) & "|" & ini(3) & "|" & ini(4) & "|" & ini(5) & "|" & ini(6) & "|" & ini(7) & "|" & ini(8) & "|" & ini(9) & "|" & ini(10) & "|" & ini(11) & "|" & ini(12) & "|" & ini(13) & "|" & ini(14) & "|" & ini(15) & "|")
        FileClose(1)
        If Me.Cursor <> Cursors.WaitCursor Then
            End
        End If
    End Sub
End Class