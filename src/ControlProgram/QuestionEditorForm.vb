Imports System.Text

Public Class QuestionEditorForm
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
        FileNameQ = GameControlForm.FileNameQ
        QuestionFilePathLabel.Text = GameControlForm.FileNameQ
        OpenBaseFileDialog.FileName = FileNameQ
        If FileNameQ <> "*.questions" Then
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
                                    GameControlForm.maxCow = i1 - 1
                                End If
                            Next
                        End If
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    End Try
                End While
                ReDim currentBlock2(i0, GameControlForm.maxCow)
                For i2 = 0 To i0
                    For i1 = 0 To GameControlForm.maxCow
                        currentBlock2(i2, i1) = currentBlock0(i2, i1)
                    Next
                Next
            End Using
            REM /Считывание базы данных вопросов из выбранного файла
            REM /**********************
            'Приравнивание массивов
            For i1 = 1 To GameControlForm.currentBlock2.GetUpperBound(0)
                For i2 = 1 To GameControlForm.maxCow
                    If GameControlForm.currentBlock2(i1, i2) <> Nothing Then
                        currentBlock2(i1, i2) = GameControlForm.currentBlock2(i1, i2)
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
            QuestionListBox.SelectedIndex = GameControlForm.QuestionListBox.SelectedIndex
        Else
            QuestionListBox.Enabled = False
            QuestionListBox.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open"" button.")
            OpenBaseFileButton.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
            QuestionFilePathLabel.Text = "Question File Adress (Choose question base file with format ""*.question"")"
        End If
        'Перевод "F" QuestionEditorForm
        Me.Text = GameControlForm.currentBlock1(117, 3) '0
        QuestionCommentLabel.Text = GameControlForm.currentBlock1(118, 3) '1
        SaveTemporarilyButton.Text = GameControlForm.currentBlock1(119, 3) '2
        SaveBaseFileButton.Text = GameControlForm.currentBlock1(120, 3) '3
        OpenBaseFileButton.Text = GameControlForm.currentBlock1(121, 3) '4
        CreateBaseFileButton.Text = GameControlForm.currentBlock1(122, 3) '5
    End Sub

    Private Sub QuestionListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QuestionListBox.SelectedIndexChanged
        rightAnswerNumber = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 8)) 'Выбор номера правильного ответа из массива
        rightAnswerText = currentBlock2(QuestionListBox.SelectedIndex + 1, rightAnswerNumber + 3) 'Текст ответа из массива (номер ответа + 3)
        For x = 1 To 5
            Me.Controls("QuestionFieldTextBox" & x).Text = currentBlock2(QuestionListBox.SelectedIndex + 1, x + 2)
        Next
        Select Case rightAnswerNumber
            Case 1
                AnswerARadioButton.Checked = True
            Case 2
                AnswerBRadioButton.Checked = True
            Case 3
                AnswerCRadioButton.Checked = True
            Case 4
                AnswerDRadioButton.Checked = True
        End Select
        QuestionCommentTextBox.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
    End Sub

    Private Sub SaveTemporarilyButton_Click(sender As Object, e As EventArgs) Handles SaveTemporarilyButton.Click
        'Save temporarily
        If QuestionFieldTextBox1.Text <> "" Then
            GameControlForm.QuestionListBox.SelectedIndex = QuestionListBox.SelectedIndex
            GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 3) = QuestionFieldTextBox1.Text 'Временное сохранение текста вопроса
            GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 4) = QuestionFieldTextBox2.Text 'Временное сохранение текста ответа A
            GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 5) = QuestionFieldTextBox3.Text 'Временное сохранение текста ответа B
            GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 6) = QuestionFieldTextBox4.Text 'Временное сохранение текста ответа C
            GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 7) = QuestionFieldTextBox5.Text 'Временное сохранение текста ответа D
            If AnswerARadioButton.Checked = True Then
                GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = 1 'Временное сохранение правильного ответа 1
            End If
            If AnswerBRadioButton.Checked = True Then
                GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = 2 'Временное сохранение правильного ответа 2
            End If
            If AnswerCRadioButton.Checked = True Then
                GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = 3 'Временное сохранение правильного ответа 3
            End If
            If AnswerDRadioButton.Checked = True Then
                GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = 4 'Временное сохранение правильного ответа 4
            End If
            GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 9) = QuestionCommentTextBox.Text 'Временное сохранение текста комментария
            'Перезагрузка GameControlForm.QuestionListBox
            GameControlForm.QuestionListBox.Items.Clear()
            For i1 = 1 To GameControlForm.currentBlock2.GetUpperBound(0)
                If (GameControlForm.currentBlock2(1, 3)) <> Nothing Then
                    GameControlForm.QuestionListBox.Items.Add(GameControlForm.currentBlock2(i1, 2) & ": " & GameControlForm.currentBlock2(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            GameControlForm.QuestionListBox.SelectedIndex = QuestionListBox.SelectedIndex
            'Приравнивание массивов
            For i1 = 1 To GameControlForm.currentBlock2.GetUpperBound(0)
                For i2 = 1 To GameControlForm.maxCow
                    If GameControlForm.currentBlock2(i1, i2) <> Nothing Then
                        currentBlock2(i1, i2) = GameControlForm.currentBlock2(i1, i2)
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
            QuestionListBox.SelectedIndex = GameControlForm.QuestionListBox.SelectedIndex
            GameControlForm.QuestionPreviewLabel.Text = GameControlForm.currentBlock2(GameControlForm.QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & GameControlForm.currentBlock2(GameControlForm.QuestionListBox.SelectedIndex + 1, 4) & " B: " & GameControlForm.currentBlock2(GameControlForm.QuestionListBox.SelectedIndex + 1, 5) & " C: " & GameControlForm.currentBlock2(GameControlForm.QuestionListBox.SelectedIndex + 1, 6) & " D: " & GameControlForm.currentBlock2(GameControlForm.QuestionListBox.SelectedIndex + 1, 7) & ". " & GameControlForm.currentBlock1(143, 3) & " " & GameControlForm.rightAnswerText
            If QuestionListBox.SelectedIndex = GameControlForm.questionNumber - 1 And GameControlForm.AskQuestionButton.BackColor <> Color.Yellow Then 'Если редактируемый вопрос = задаваемому и Кнопка "Задать выбранный вопрос" не жёлтая, то...
                GameControlForm.questionText = GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
                GameControlForm.textAnswerA = GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                GameControlForm.textAnswerB = GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                GameControlForm.textAnswerC = GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                GameControlForm.textAnswerD = GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
                GameControlForm.QuestionTextLabel.Text = GameControlForm.questionText
                GameControlForm.AnswerATextLabel.Text = GameControlForm.textAnswerA
                GameControlForm.AnswerBTextLabel.Text = GameControlForm.textAnswerB
                GameControlForm.AnswerCTextLabel.Text = GameControlForm.textAnswerC
                GameControlForm.AnswerDTextLabel.Text = GameControlForm.textAnswerD
                GameControlForm.numberRightAnswer = GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 8)
                HostScreenForm.QuestionCommentLabel.Text = GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 9)
                'Сеть
                If GameControlForm.ConnectButton.BackColor = Color.Green Then
                    Dim NetworkInfo As New IONetwork
                    With NetworkInfo
                        .Command = "@enable_all_answers|" & GameControlForm.questionText & "|" & GameControlForm.textAnswerA & "|" & GameControlForm.textAnswerB & "|" & GameControlForm.textAnswerC & "|" & GameControlForm.textAnswerD & "|" & GameControlForm.numberRightAnswer & "|" & GameControlForm.currentBlock2(QuestionListBox.SelectedIndex + 1, 9) & "|"
                    End With
                    GameControlForm.Client_SendIONetwork(NetworkInfo)
                End If
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
                If AnswerARadioButton.Checked = True Then
                    currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = 1 'Временное сохранение правильного ответа 1
                End If
                If AnswerBRadioButton.Checked = True Then
                    currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = 2 'Временное сохранение правильного ответа 2
                End If
                If AnswerCRadioButton.Checked = True Then
                    currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = 3 'Временное сохранение правильного ответа 3
                End If
                If AnswerDRadioButton.Checked = True Then
                    currentBlock2(QuestionListBox.SelectedIndex + 1, 8) = 4 'Временное сохранение правильного ответа 4
                End If
                currentBlock2(QuestionListBox.SelectedIndex + 1, 9) = QuestionCommentTextBox.Text 'Временное сохранение текста комментария
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
                For i2 = 1 To GameControlForm.maxCow
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
        OpenBaseFileDialog.FileName = "*.questions"
        OpenBaseFileDialog.InitialDirectory = CurDir() & "\Bases"
        OpenBaseFileDialog.CheckFileExists = True
        If OpenBaseFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenBaseFileDialog.FileName
            Call openfilesdata(FileNameQ)
            If OpenBaseFileDialog.FileName <> GameControlForm.OpenQuestionBaseDialog.FileName Then
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
        If FileNameQ <> "*.questions" Then
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
            QuestionFilePathLabel.Text = "Question File Adress (Choose question base file with format ""*.question"")"
        End If
    End Sub

    Private Sub CreateBaseFileButton_Click(sender As Object, e As EventArgs) Handles CreateBaseFileButton.Click
        'Create new file...
        Dim n As Integer
        While My.Computer.FileSystem.FileExists(CurDir() & "\Bases\NewBase" & n & ".questions") = True
            n = n + 1
        End While
        SaveBaseFileDialog.FileName = "NewBase" & n & ".questions"
        SaveBaseFileDialog.InitialDirectory = CurDir() & "\Bases"
        SaveBaseFileDialog.CreatePrompt = False
        SaveBaseFileDialog.OverwritePrompt = True
        SaveBaseFileDialog.CheckPathExists = True
        If SaveBaseFileDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                FileCopy(CurDir() & "\Bases\" & GameControlForm.currentBlock1(2, 3) & "Base_Example.questions", SaveBaseFileDialog.FileName)
            Catch
                TextFile.Close()
                TextFile.Open(SaveBaseFileDialog.FileName)
                TextFile.Write("|1|First question?|Answer A1|Answer B1|Answer C1|Answer D1|1|Comment for question number 1.|" & Chr(13) & Chr(10) & _
                      "|2|Second question?|Answer A2|Answer B2|Answer C2|Answer D2|1|Comment for question number 2.|" & Chr(13) & Chr(10) & _
                      "|3|Third question?|Answer A3|Answer B3|Answer C3|Answer D3|1|Comment for question number 3.|" & Chr(13) & Chr(10) & _
                      "|4|Fourth question?|Answer A4|Answer B4|Answer C4|Answer D4|1|Comment for question number 4.|" & Chr(13) & Chr(10) & _
                      "|5|Fifth question?|Answer A5|Answer B5|Answer C5|Answer D5|1|Comment for question number 5.|" & Chr(13) & Chr(10) & _
                      "|6|Sixth question?|Answer A6|Answer B6|Answer C6|Answer D6|1|Comment for question number 6.|" & Chr(13) & Chr(10) & _
                      "|7|Seventh question?|Answer A7|Answer B7|Answer C7|Answer D7|1|Comment for question number 7.|" & Chr(13) & Chr(10) & _
                      "|8|Eighth question?|Answer A8|Answer B8|Answer C8|Answer D8|1|Comment for question number 8.|" & Chr(13) & Chr(10) & _
                      "|9|Ninth question?|Answer A9|Answer B9|Answer C9|Answer D9|1|Comment for question number 9.|" & Chr(13) & Chr(10) & _
                      "|10|Tenth question?|Answer A10|Answer B10|Answer C10|Answer D10|1|Comment for question number 10.|" & Chr(13) & Chr(10) & _
                      "|11|Eleventh question?|Answer A11|Answer B11|Answer C11|Answer D11|1|Comment for question number 11.|" & Chr(13) & Chr(10) & _
                      "|12|Twelfth question?|Answer A12|Answer B12|Answer C12|Answer D12|1|Comment for question number 12.|" & Chr(13) & Chr(10) & _
                      "|13|Thirteenth question?|Answer A13|Answer B13|Answer C13|Answer D13|1|Comment for question number 13.|" & Chr(13) & Chr(10) & _
                      "|14|Fourteenth question?|Answer A14|Answer B14|Answer C14|Answer D14|1|Comment for question number 14.|" & Chr(13) & Chr(10) & _
                      "|15|Fifteenth question?|Answer A15|Answer B15|Answer C15|Answer D15|1|Comment for question number 15.|" & Chr(13) & Chr(10))
                TextFile.Close()
            End Try
            OpenBaseFileDialog.FileName = SaveBaseFileDialog.FileName
            FileNameQ = OpenBaseFileDialog.FileName
            Call openfilesdata(FileNameQ)
            If OpenBaseFileDialog.FileName <> GameControlForm.OpenQuestionBaseDialog.FileName Then
                SaveTemporarilyButton.Enabled = False
            Else
                SaveTemporarilyButton.Enabled = True
            End If
        End If
    End Sub
End Class
