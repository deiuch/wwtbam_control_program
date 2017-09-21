Imports System
Imports System.IO

Public Class FormStart
    Public currentBlock1(,) As String 'Массив русификации
    Public ini() As String 'Массив файла .ini
    Dim lang As String 'Путь языкового пакета
    Dim files() As String 'Массив списка файлов перевода

    Private Sub FormStart_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Project.OpenFileDialog1.InitialDirectory = "\Bases"
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
        If ini(1) = "1" Then CheckBox1.Checked = True Else CheckBox1.Checked = False
        If ini(2) = "1" Then CheckBox2.Checked = True Else CheckBox2.Checked = False
        If ini(3) = "1" Then CheckBox3.Checked = True Else CheckBox3.Checked = False
        NumericUpDown2.Value = ini(4)
        NumericUpDown3.Value = ini(5)
        NumericUpDown4.Value = ini(6)
        NumericUpDown5.Value = ini(7)
        NumericUpDown6.Value = ini(8)
        NumericUpDown7.Value = ini(9)
        'Поиск файлов языка
        ComboBox1.Items.Clear()
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
                ComboBox1.Items.Add(currentRow(2))
            End Using
        Next
        'Если языки не найдены
        If ComboBox1.Items.Count = 0 Then
            MsgBox("No language packs was found!" & Chr(13) & Chr(10) & "Языковые пакеты не обнаружены!")
            End
        End If
        ComboBox1.SelectedIndex = 0
        'Выбор последнего использованного языка
        Try
            ComboBox1.SelectedIndex = ComboBox1.FindStringExact(ini(11))
        Catch
        End Try
        If ComboBox1.SelectedIndex < 0 Then
            ComboBox1.SelectedIndex = 0
        End If
        'Поиск последнего открытого файла базы вопросов
        If My.Computer.FileSystem.FileExists(ini(10)) = True And Not ini(10) = Nothing Then TextBox1.Text = ini(10)
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Выбор языка
        REM ****************************
        REM Языковая поддержка программы *.lng
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer = 0
        Dim i1 As Integer = 0
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(files(ComboBox1.SelectedIndex), System.Text.Encoding.Default)
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
        Label1.Text = currentBlock1(12, 3)
        CheckBox1.Text = currentBlock1(13, 3)
        CheckBox2.Text = currentBlock1(14, 3)
        CheckBox3.Text = currentBlock1(15, 3)
        Label2.Text = currentBlock1(16, 3)
        TextBox1.Text = CurDir() & currentBlock1(17, 3)
        Button46.Text = currentBlock1(18, 3)
        Label3.Text = currentBlock1(19, 3)
        Button1.Text = currentBlock1(20, 3)
        'Размер шрифта FormStart
        'Label1.Font = New Font(DefaultFont, Int(currentBlock1(12, 4)))
        'CheckBox1.Font = New Font(DefaultFont, Int(currentBlock1(13, 4)))
        'CheckBox2.Font = New Font(DefaultFont, Int(currentBlock1(14, 4)))
        'CheckBox3.Font = New Font(DefaultFont, Int(currentBlock1(15, 4)))
        'Label2.Font = New Font(DefaultFont, Int(currentBlock1(16, 4)))
        'TextBox1.Font = New Font(DefaultFont, Int(currentBlock1(17, 4)))
        'Button46.Font = New Font(DefaultFont, Int(currentBlock1(18, 4)))
        'Label3.Font = New Font(DefaultFont, Int(currentBlock1(19, 4)))
        'Button1.Font = New Font(DefaultFont, Int(currentBlock1(20, 4)))
    End Sub

    Private Sub Button46_Click(sender As Object, e As EventArgs) Handles Button46.Click
        'Open button
        Project.OpenFileDialog1.FileName = "*.questions"
        Project.OpenFileDialog1.InitialDirectory = CurDir() & "\Bases"
        Project.OpenFileDialog1.CheckFileExists = True
        If Project.OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            TextBox1.Text = Project.OpenFileDialog1.FileName
        End If
        If TextBox1.Text = "*.question" Or TextBox1.Text = Nothing Then
            TextBox1.Text = CurDir() & "\Bases\" & Project.currentBlock1(2, 3) & "Base_Example.questions"
        End If
    End Sub

    Private Sub NumericUpDown2_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown2.ValueChanged, NumericUpDown3.ValueChanged
        Host.Location = New Point(NumericUpDown2.Value, NumericUpDown3.Value)
    End Sub

    Private Sub NumericUpDown4_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown4.ValueChanged, NumericUpDown5.ValueChanged
        Player.Location = New Point(NumericUpDown4.Value, NumericUpDown5.Value)
    End Sub

    Private Sub NumericUpDown6_ValueChanged(sender As Object, e As EventArgs) Handles NumericUpDown6.ValueChanged, NumericUpDown7.ValueChanged
        Audience.Location = New Point(NumericUpDown6.Value, NumericUpDown7.Value)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If My.Computer.FileSystem.FileExists(TextBox1.Text) = True Then
            Me.Cursor = Cursors.WaitCursor
            'Перевод
            For i1 = 1 To currentBlock1.GetUpperBound(0)
                For i2 = 1 To 6
                    Project.currentBlock1(i1, i2) = currentBlock1(i1, i2)
                Next
            Next
            ini(11) = ComboBox1.SelectedItem
            For x = 1 To ini.GetUpperBound(0)
                Project.ini(x) = ini(x)
            Next
            My.Computer.Audio.Play("source\MUSIC\Roll 2.wav")
            Project.CheckBox7.Checked = CheckBox1.Checked
            Project.CheckBox8.Checked = CheckBox2.Checked
            Project.CheckBox9.Checked = CheckBox3.Checked
            Project.NumericUpDown2.Value = NumericUpDown2.Value
            Project.NumericUpDown3.Value = NumericUpDown3.Value
            Project.NumericUpDown4.Value = NumericUpDown4.Value
            Project.NumericUpDown5.Value = NumericUpDown5.Value
            Project.NumericUpDown6.Value = NumericUpDown6.Value
            Project.NumericUpDown7.Value = NumericUpDown7.Value
            Project.FileNameQ = TextBox1.Text
            Call Project.openfilesdata(Project.FileNameQ)
            Project.Show()
        Else
            MsgBox(currentBlock1(146, 4), MsgBoxStyle.Exclamation)
        End If
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FormClosing
        If CheckBox1.Checked = True Then ini(1) = "1" Else ini(1) = "0"
        If CheckBox2.Checked = True Then ini(2) = "1" Else ini(2) = "0"
        If CheckBox3.Checked = True Then ini(3) = "1" Else ini(3) = "0"
        ini(4) = NumericUpDown2.Value
        ini(5) = NumericUpDown3.Value
        ini(6) = NumericUpDown4.Value
        ini(7) = NumericUpDown5.Value
        ini(8) = NumericUpDown6.Value
        ini(9) = NumericUpDown7.Value
        ini(10) = TextBox1.Text
        ini(11) = ComboBox1.SelectedItem
        FileClose(1)
        FileOpen(1, CurDir() & "\wwtbam_set.ini", OpenMode.Output)
        Print(1, "|" & ini(1) & "|" & ini(2) & "|" & ini(3) & "|" & ini(4) & "|" & ini(5) & "|" & ini(6) & "|" & ini(7) & "|" & ini(8) & "|" & ini(9) & "|" & ini(10) & "|" & ini(11) & "|" & ini(12) & "|" & ini(13) & "|" & ini(14) & "|" & ini(15) & "|")
        FileClose(1)
        If Me.Cursor <> Cursors.WaitCursor Then
            End
        End If
    End Sub
End Class