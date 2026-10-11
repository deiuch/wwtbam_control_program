Imports System.Text

Public Class FastestFingerEditorForm
    Dim FileNameQ As String 'Путь и имя файла базы вопросов
    Dim currentBlock0(,) As String 'Временный массив
    Public currentBlock2(,) As String 'Массив вопросов
    Dim rightAnswerNumber As Integer 'Номер правильного ответа (1-4)
    Dim rightAnswerText As String 'Текст правильного ответа РЕЖИССЁРУ

    Private Sub Editor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        OpenBaseFileDialog.InitialDirectory = GameControlForm.sourcePath
        FileNameQ = FastestFingerFirstForm.OpenQuestionBaseDialog.FileName
        QuestionFilePathLabel.Text = FastestFingerFirstForm.OpenQuestionBaseDialog.FileName
        OpenBaseFileDialog.FileName = FileNameQ
        If FileNameQ <> "*.fff" Then
            QuestionListBox.Enabled = True
            REM ****************************
            REM Считывание базы данных вопросов из выбранного файла
            i1 = 0
            i0 = 0
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(FileNameQ, System.Text.Encoding.Default)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters("|")
                ReDim currentRow(15)
                ReDim currentBlock0(100, 15)
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        If currentRow(2) <> "" Then
                            i0 = i0 + 1
                            i1 = 0
                            For Each currentField In currentRow
                                i1 = i1 + 1
                                currentBlock0(i0, i1) = ""
                                currentBlock0(i0, i1) = currentField
                                If currentBlock0(i0, i1) = "" And i1 > 0 Then
                                    FastestFingerFirstForm.maxCow = i1 - 1
                                End If
                            Next
                        End If
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    End Try
                End While
                ReDim currentBlock2(i0, FastestFingerFirstForm.maxCow)
                For i2 = 0 To i0
                    For i1 = 0 To FastestFingerFirstForm.maxCow
                        currentBlock2(i2, i1) = currentBlock0(i2, i1)
                    Next
                Next
            End Using
            REM /Считывание базы данных вопросов из выбранного файла
            REM /**********************
            'Приравнивание массивов
            For i1 = 1 To FastestFingerFirstForm.currentBlock2.GetUpperBound(0)
                For i2 = 1 To FastestFingerFirstForm.maxCow
                    If FastestFingerFirstForm.currentBlock2(i1, i2) <> Nothing Then
                        currentBlock2(i1, i2) = FastestFingerFirstForm.currentBlock2(i1, i2)
                    End If
                Next
            Next
            REM ***********************
            REM Заполнение QuestionListBox
            QuestionListBox.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    QuestionListBox.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            REM /Заполнение QuestionListBox
            REM /***********************
            QuestionListBox.SelectedIndex = FastestFingerFirstForm.QuestionListBox.SelectedIndex
        Else
            QuestionListBox.Enabled = False
            QuestionListBox.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open"" button.")
            OpenBaseFileButton.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
            QuestionFilePathLabel.Text = "Question File Adress (Choose question base file with format ""*.fff"")"
        End If
        'Перевод "F" QuestionEditorForm
        Me.Text = GameControlForm.currentBlock1(117, 3) '0
        QuestionCommentLabel.Text = GameControlForm.currentBlock1(118, 3) '1
        SaveTemporarilyButton.Text = GameControlForm.currentBlock1(119, 3) '2
        SaveBaseFileButton.Text = GameControlForm.currentBlock1(120, 3) '3
        OpenBaseFileButton.Text = GameControlForm.currentBlock1(121, 3) '4
        CreateBaseFileButton.Text = GameControlForm.currentBlock1(122, 3) '5
        RightOrder1Label.Text = GameControlForm.currentBlock1(131, 3) '8
        RightOrder2Label.Text = GameControlForm.currentBlock1(132, 3) '9
        RightOrder3Label.Text = GameControlForm.currentBlock1(133, 3) '10
        RightOrder4Label.Text = GameControlForm.currentBlock1(134, 3) '11
        'Перевод "I"
        RightOrderLabel.Text = GameControlForm.currentBlock1(144, 3) '1
    End Sub

    Private Sub QuestionListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QuestionListBox.SelectedIndexChanged
        rightAnswerNumber = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 8) & currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & currentBlock2(QuestionListBox.SelectedIndex + 1, 10) & currentBlock2(QuestionListBox.SelectedIndex + 1, 11)) 'Выбор номера правильного ответа из массива
        'rightAnswerText = currentBlock2(QuestionListBox.SelectedIndex + 1, rightAnswerNumber + 3) 'Текст ответа из массива (номер ответа + 3)
        For x = 1 To 5
            Me.Controls("QuestionFieldTextBox" & x).Text = currentBlock2(QuestionListBox.SelectedIndex + 1, x + 2)
        Next
        RightOrder1ComboBox.SelectedIndex = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 8))
        RightOrder2ComboBox.SelectedIndex = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 9))
        RightOrder3ComboBox.SelectedIndex = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 10))
        RightOrder4ComboBox.SelectedIndex = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 11))
        QuestionCommentTextBox.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 12)
    End Sub

    Private Sub SaveTemporarilyButton_Click(sender As Object, e As EventArgs) Handles SaveTemporarilyButton.Click
        'Save temporarily
        If QuestionFieldTextBox1.Text <> "" Then
            FastestFingerFirstForm.QuestionListBox.SelectedIndex = QuestionListBox.SelectedIndex
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 3) = QuestionFieldTextBox1.Text 'Временное сохранение текста вопроса
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 4) = QuestionFieldTextBox2.Text 'Временное сохранение текста ответа A
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 5) = QuestionFieldTextBox3.Text 'Временное сохранение текста ответа B
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 6) = QuestionFieldTextBox4.Text 'Временное сохранение текста ответа C
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 7) = QuestionFieldTextBox5.Text 'Временное сохранение текста ответа D
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = RightOrder1ComboBox.SelectedIndex 'Временное сохранение первого ответа
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 9) = RightOrder2ComboBox.SelectedIndex 'Временное сохранение второго ответа
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 10) = RightOrder3ComboBox.SelectedIndex 'Временное сохранение третьего ответа
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 11) = RightOrder4ComboBox.SelectedIndex 'Временное сохранение четвёртого ответа
            FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 12) = QuestionCommentTextBox.Text 'Временное сохранение текста комментария
            FastestFingerFirstForm.first = RightOrder1ComboBox.SelectedIndex
            FastestFingerFirstForm.second = RightOrder2ComboBox.SelectedIndex
            FastestFingerFirstForm.third = RightOrder3ComboBox.SelectedIndex
            FastestFingerFirstForm.fourth = RightOrder4ComboBox.SelectedIndex
            'Перезагрузка FastestFingerFirstForm.QuestionListBox
            FastestFingerFirstForm.QuestionListBox.Items.Clear()
            For i1 = 1 To FastestFingerFirstForm.currentBlock2.GetUpperBound(0)
                If (FastestFingerFirstForm.currentBlock2(1, 3)) <> Nothing Then
                    FastestFingerFirstForm.QuestionListBox.Items.Add(FastestFingerFirstForm.currentBlock2(i1, 2) & ": " & FastestFingerFirstForm.currentBlock2(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            FastestFingerFirstForm.QuestionListBox.SelectedIndex = QuestionListBox.SelectedIndex
            'Приравнивание массивов
            For i1 = 1 To FastestFingerFirstForm.currentBlock2.GetUpperBound(0)
                For i2 = 1 To FastestFingerFirstForm.maxCow
                    If FastestFingerFirstForm.currentBlock2(i1, i2) <> Nothing Then
                        currentBlock2(i1, i2) = FastestFingerFirstForm.currentBlock2(i1, i2)
                    End If
                Next
            Next
            'Перезагрузка QuestionListBox
            QuestionListBox.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    QuestionListBox.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            QuestionListBox.SelectedIndex = FastestFingerFirstForm.QuestionListBox.SelectedIndex
            If FastestFingerFirstForm.fourth <> 0 Then
                FastestFingerFirstForm.QuestionTextLabel.Text = FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & GameControlForm.currentBlock1(144, 3) & " " & FastestFingerFirstForm.first & ", " & FastestFingerFirstForm.second & ", " & FastestFingerFirstForm.third & ", " & FastestFingerFirstForm.fourth
            Else
                FastestFingerFirstForm.QuestionTextLabel.Text = FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & GameControlForm.currentBlock1(143, 3) & " " & FastestFingerFirstForm.first
            End If
            If QuestionListBox.SelectedIndex = FastestFingerFirstForm.QuestionListBox.SelectedIndex Then 'Если редактируемый вопрос = задаваемому, то...
                If GameControlForm.QuestionTextLabel.Text <> Nothing Then GameControlForm.QuestionTextLabel.Text = FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
                If GameControlForm.AnswerATextLabel.Text <> Nothing Then GameControlForm.AnswerATextLabel.Text = FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                If GameControlForm.AnswerBTextLabel.Text <> Nothing Then GameControlForm.AnswerBTextLabel.Text = FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                If GameControlForm.AnswerCTextLabel.Text <> Nothing Then GameControlForm.AnswerCTextLabel.Text = FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                If GameControlForm.AnswerDTextLabel.Text <> Nothing Then GameControlForm.AnswerDTextLabel.Text = FastestFingerFirstForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
            End If
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If
    End Sub

    Private Sub SaveBaseFileButton_Click(sender As Object, e As EventArgs) Handles SaveBaseFileButton.Click
        'Save base file
        If QuestionFieldTextBox1.Text <> "" Then
            Dim tmpText As String
            Dim listSelect As Integer
            If SaveTemporarilyButton.Enabled = False Then
                listSelect = QuestionListBox.SelectedIndex
                currentBlock2(QuestionListBox.SelectedIndex + 1, 3) = QuestionFieldTextBox1.Text 'Временное сохранение текста вопроса
                currentBlock2(QuestionListBox.SelectedIndex + 1, 4) = QuestionFieldTextBox2.Text 'Временное сохранение текста ответа A
                currentBlock2(QuestionListBox.SelectedIndex + 1, 5) = QuestionFieldTextBox3.Text 'Временное сохранение текста ответа B
                currentBlock2(QuestionListBox.SelectedIndex + 1, 6) = QuestionFieldTextBox4.Text 'Временное сохранение текста ответа C
                currentBlock2(QuestionListBox.SelectedIndex + 1, 7) = QuestionFieldTextBox5.Text 'Временное сохранение текста ответа D
                currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = RightOrder1ComboBox.SelectedIndex 'Временное сохранение первого ответа
                currentBlock2(QuestionListBox.SelectedIndex + 1, 9) = RightOrder2ComboBox.SelectedIndex 'Временное сохранение второго ответа
                currentBlock2(QuestionListBox.SelectedIndex + 1, 10) = RightOrder3ComboBox.SelectedIndex 'Временное сохранение третьего ответа
                currentBlock2(QuestionListBox.SelectedIndex + 1, 11) = RightOrder4ComboBox.SelectedIndex 'Временное сохранение четвёртого ответа
                currentBlock2(QuestionListBox.SelectedIndex + 1, 12) = QuestionCommentTextBox.Text 'Временное сохранение текста комментария
                QuestionListBox.Items.Clear()
                For i1 = 1 To currentBlock2.GetUpperBound(0)
                    If (currentBlock2(1, 3)) <> Nothing Then
                        QuestionListBox.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3))
                    End If
                Next
                QuestionListBox.SelectedIndex = listSelect
            Else
                SaveTemporarilyButton.PerformClick()
            End If
            SaveBaseFileDialog.FileName = OpenBaseFileDialog.FileName
            TextFile.Close()
            TextFile.Open(SaveBaseFileDialog.FileName)
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                tmpText = ""
                For i2 = 1 To FastestFingerFirstForm.maxCow
                    'Сохранение в файл
                    If currentBlock2(i1, i2) <> "" Then
                        'Замена переноса строки и "|"
                        currentBlock2(i1, i2) = currentBlock2(i1, i2).Replace(Chr(13) & Chr(10), "¶")
                        currentBlock2(i1, i2) = currentBlock2(i1, i2).Replace("|", "")
                    End If
                    tmpText = tmpText & currentBlock2(i1, i2) & "|"
                    If currentBlock2(i1, i2) <> "" Then currentBlock2(i1, i2) = currentBlock2(i1, i2).Replace("¶", Chr(13) & Chr(10)) 'Замена переноса строки
                Next
                TextFile.Write(tmpText & Chr(13) & Chr(10))
            Next
        TextFile.Close()
        Else
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If
    End Sub

    Private Sub OpenBaseFileButton_Click(sender As Object, e As EventArgs) Handles OpenBaseFileButton.Click
        'Open file...
        OpenBaseFileDialog.FileName = "*.fff"
        OpenBaseFileDialog.InitialDirectory = CurDir() & "\Bases"
        OpenBaseFileDialog.CheckFileExists = True
        If OpenBaseFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenBaseFileDialog.FileName
            Call openfilesdata(FileNameQ)
            If OpenBaseFileDialog.FileName <> FastestFingerFirstForm.OpenQuestionBaseDialog.FileName Then
                SaveTemporarilyButton.Enabled = False
            Else
                SaveTemporarilyButton.Enabled = True
            End If
        End If
    End Sub

    Private Sub openfilesdata(sender As Object)
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        QuestionFilePathLabel.Text = FileNameQ
        If FileNameQ <> "*.fff" Then
            QuestionListBox.Enabled = True
            REM ****************************
            REM Считывание базы данных вопросов из выбранного файла
            i1 = 0
            i0 = 0
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(FileNameQ, System.Text.Encoding.Default)
                MyReader.TextFieldType = FileIO.FieldType.Delimited
                MyReader.SetDelimiters("|")
                ReDim currentRow(15)
                ReDim currentBlock0(100, 15)
                While Not MyReader.EndOfData
                    Try
                        currentRow = MyReader.ReadFields()
                        If currentRow(2) <> "" Then
                            i0 = i0 + 1
                            i1 = 0
                            For Each currentField In currentRow
                                i1 = i1 + 1
                                currentBlock0(i0, i1) = ""
                                currentBlock0(i0, i1) = currentField
                            Next
                        End If
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    End Try
                End While
                ReDim currentBlock2(i0, 15)
                For i2 = 0 To i0
                    For i1 = 0 To 15
                        currentBlock2(i2, i1) = currentBlock0(i2, i1)
                        'Замена переноса строки и "|"
                        If currentBlock0(i2, i1) <> "" Then
                            currentBlock0(i2, i1) = currentBlock0(i2, i1).Replace("¶", " ")
                            currentBlock0(i2, i1) = currentBlock0(i2, i1).Replace("|", "")
                        End If
                        If currentBlock2(i2, i1) <> "" Then
                            currentBlock2(i2, i1) = currentBlock2(i2, i1).Replace("¶", Chr(13) & Chr(10))
                            currentBlock2(i2, i1) = currentBlock2(i2, i1).Replace("|", "")
                        End If
                    Next
                Next
            End Using
            REM /Считывание базы данных вопросов из выбранного файла
            REM /**********************

            REM ***********************
            REM Заполнение QuestionListBox
            QuestionListBox.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0) 'Можно 15, но мы сделали резерв
                If (currentBlock2(1, 3)) <> Nothing Then
                    QuestionListBox.Items.Add(currentBlock0(i1, 2) & ": " & currentBlock0(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            REM /Заполнение QuestionListBox
            REM /***********************
            OpenBaseFileButton.BackColor = Color.White
            QuestionListBox.SelectedIndex = 0
        Else
            QuestionListBox.Enabled = False
            QuestionListBox.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open file..."" button.")
            OpenBaseFileButton.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
            QuestionFilePathLabel.Text = "Question File Adress (Choose question base file with format ""*.fff"")"
        End If
    End Sub

    Private Sub CreateBaseFileButton_Click(sender As Object, e As EventArgs) Handles CreateBaseFileButton.Click
        'Create new file...
        Dim n As Integer
        While My.Computer.FileSystem.FileExists(CurDir() & "\Bases\NewBaseFFF" & n & ".fff") = True
            n = n + 1
        End While
        SaveBaseFileDialog.FileName = "NewBaseFFF" & n & ".fff"
        SaveBaseFileDialog.InitialDirectory = CurDir() & "\Bases"
        SaveBaseFileDialog.CreatePrompt = False
        SaveBaseFileDialog.OverwritePrompt = True
        SaveBaseFileDialog.CheckPathExists = True
        If SaveBaseFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                FileCopy(CurDir() & "\Bases\" & GameControlForm.currentBlock1(2, 3) & "Qualify.fff", SaveBaseFileDialog.FileName)
            Catch
                TextFile.Close()
                TextFile.Open(SaveBaseFileDialog.FileName)
                TextFile.Write("|1|Fastest Finger 1 Question.|Answer A1|Answer B1|Answer C1|Answer D1|1|2|3|4|Comment for question 1.|" & Chr(13) & Chr(10) & _
                      "|2|Fastest Finger 2 Question.|Answer A2|Answer B2|Answer C2|Answer D2|1|2|3|4|Comment for question 2.|" & Chr(13) & Chr(10) & _
                      "|3|Fastest Finger 3 Question.|Answer A3|Answer B3|Answer C3|Answer D3|1|2|3|4|Comment for question 3.|" & Chr(13) & Chr(10) & _
                      "|4|Fastest Finger 4 Question.|Answer A4|Answer B4|Answer C4|Answer D4|1|2|3|4|Comment for question 4.|" & Chr(13) & Chr(10) & _
                      "|5|Fastest Finger 5 Question.|Answer A5|Answer B5|Answer C5|Answer D5|1|2|3|4|Comment for question 5.|" & Chr(13) & Chr(10) & _
                      "|6|Fastest Finger 6 Question.|Answer A6|Answer B6|Answer C6|Answer D6|1|2|3|4|Comment for question 6.|" & Chr(13) & Chr(10) & _
                      "|7|Fastest Finger 7 Question.|Answer A7|Answer B7|Answer C7|Answer D7|1|2|3|4|Comment for question 7.|" & Chr(13) & Chr(10) & _
                      "|8|Fastest Finger 8 Question.|Answer A8|Answer B8|Answer C8|Answer D8|1|2|3|4|Comment for question 8.|" & Chr(13) & Chr(10))
                TextFile.Close()
            End Try
            OpenBaseFileDialog.FileName = SaveBaseFileDialog.FileName
            FileNameQ = OpenBaseFileDialog.FileName
            Call openfilesdata(FileNameQ)
            If OpenBaseFileDialog.FileName <> FastestFingerFirstForm.OpenQuestionBaseDialog.FileName Then
                SaveTemporarilyButton.Enabled = False
            Else
                SaveTemporarilyButton.Enabled = True
            End If
        End If
    End Sub
End Class
