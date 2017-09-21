Imports System.Text

Public Class Editor
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
        OpenFileDialog1.InitialDirectory = Project.sourcePath
        FileNameQ = Project.FileNameQ
        Label1.Text = Project.FileNameQ
        OpenFileDialog1.FileName = FileNameQ
        If FileNameQ <> "*.questions" Then
            ListBox1.Enabled = True
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
                                    Project.maxCow = i1 - 1
                                End If
                            Next
                        End If
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    End Try
                End While
                ReDim currentBlock2(i0, Project.maxCow)
                For i2 = 0 To i0
                    For i1 = 0 To Project.maxCow
                        currentBlock2(i2, i1) = currentBlock0(i2, i1)
                    Next
                Next
            End Using
            REM /Считывание базы данных вопросов из выбранного файла
            REM /**********************
            'Приравнивание массивов
            For i1 = 1 To Project.currentBlock2.GetUpperBound(0)
                For i2 = 1 To Project.maxCow
                    If Project.currentBlock2(i1, i2) <> Nothing Then
                        currentBlock2(i1, i2) = Project.currentBlock2(i1, i2)
                    End If
                Next
            Next
            REM ***********************
            REM Заполнение ListBox1
            ListBox1.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    ListBox1.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            REM /Заполнение ListBox1
            REM /***********************
            ListBox1.SelectedIndex = Project.ListBox1.SelectedIndex
        Else
            ListBox1.Enabled = False
            ListBox1.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open"" button.")
            Button3.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
            Label1.Text = "Question File Adress (Choose question base file with format ""*.question"")"
        End If
        'Перевод "F" Editor
        Me.Text = Project.currentBlock1(117, 3) '0
        Label2.Text = Project.currentBlock1(118, 3) '1
        Button1.Text = Project.currentBlock1(119, 3) '2
        Button2.Text = Project.currentBlock1(120, 3) '3
        Button3.Text = Project.currentBlock1(121, 3) '4
        Button4.Text = Project.currentBlock1(122, 3) '5
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        rightAnswerNumber = Int(currentBlock2(ListBox1.SelectedIndex + 1, 8)) 'Выбор номера правильного ответа из массива
        rightAnswerText = currentBlock2(ListBox1.SelectedIndex + 1, rightAnswerNumber + 3) 'Текст ответа из массива (номер ответа + 3)
        For x = 1 To 5
            Me.Controls("TextBox" & x).Text = currentBlock2(ListBox1.SelectedIndex + 1, x + 2)
        Next
        Select Case rightAnswerNumber
            Case 1
                RadioButton1.Checked = True
            Case 2
                RadioButton2.Checked = True
            Case 3
                RadioButton3.Checked = True
            Case 4
                RadioButton4.Checked = True
        End Select
        TextBox6.Text = currentBlock2(ListBox1.SelectedIndex + 1, 9)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Save temporarily
        If TextBox1.Text <> "" Then
            Project.ListBox1.SelectedIndex = ListBox1.SelectedIndex
            Project.currentBlock2(ListBox1.SelectedIndex + 1, 3) = TextBox1.Text 'Временное сохранение текста вопроса
            Project.currentBlock2(ListBox1.SelectedIndex + 1, 4) = TextBox2.Text 'Временное сохранение текста ответа A
            Project.currentBlock2(ListBox1.SelectedIndex + 1, 5) = TextBox3.Text 'Временное сохранение текста ответа B
            Project.currentBlock2(ListBox1.SelectedIndex + 1, 6) = TextBox4.Text 'Временное сохранение текста ответа C
            Project.currentBlock2(ListBox1.SelectedIndex + 1, 7) = TextBox5.Text 'Временное сохранение текста ответа D
            If RadioButton1.Checked = True Then
                Project.currentBlock2(ListBox1.SelectedIndex + 1, 8) = 1 'Временное сохранение правильного ответа 1
            End If
            If RadioButton2.Checked = True Then
                Project.currentBlock2(ListBox1.SelectedIndex + 1, 8) = 2 'Временное сохранение правильного ответа 2
            End If
            If RadioButton3.Checked = True Then
                Project.currentBlock2(ListBox1.SelectedIndex + 1, 8) = 3 'Временное сохранение правильного ответа 3
            End If
            If RadioButton4.Checked = True Then
                Project.currentBlock2(ListBox1.SelectedIndex + 1, 8) = 4 'Временное сохранение правильного ответа 4
            End If
            Project.currentBlock2(ListBox1.SelectedIndex + 1, 9) = TextBox6.Text 'Временное сохранение текста комментария
            'Перезагрузка Project.ListBox1
            Project.ListBox1.Items.Clear()
            For i1 = 1 To Project.currentBlock2.GetUpperBound(0)
                If (Project.currentBlock2(1, 3)) <> Nothing Then
                    Project.ListBox1.Items.Add(Project.currentBlock2(i1, 2) & ": " & Project.currentBlock2(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            Project.ListBox1.SelectedIndex = ListBox1.SelectedIndex
            'Приравнивание массивов
            For i1 = 1 To Project.currentBlock2.GetUpperBound(0)
                For i2 = 1 To Project.maxCow
                    If Project.currentBlock2(i1, i2) <> Nothing Then
                        currentBlock2(i1, i2) = Project.currentBlock2(i1, i2)
                    End If
                Next
            Next
            'Перезагрузка ListBox1
            ListBox1.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    ListBox1.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            ListBox1.SelectedIndex = Project.ListBox1.SelectedIndex
            Project.Label5.Text = Project.currentBlock2(Project.ListBox1.SelectedIndex + 1, 3) & Chr(13) & "A: " & Project.currentBlock2(Project.ListBox1.SelectedIndex + 1, 4) & " B: " & Project.currentBlock2(Project.ListBox1.SelectedIndex + 1, 5) & " C: " & Project.currentBlock2(Project.ListBox1.SelectedIndex + 1, 6) & " D: " & Project.currentBlock2(Project.ListBox1.SelectedIndex + 1, 7) & ". " & Project.currentBlock1(143, 3) & " " & Project.rightAnswerText
            If ListBox1.SelectedIndex = Project.questionNumber - 1 And Project.Button1.BackColor <> Color.Yellow Then 'Если редактируемый вопрос = задаваемому и Кнопка "Задать выбранный вопрос" не жёлтая, то...
                Project.questionText = Project.currentBlock2(ListBox1.SelectedIndex + 1, 3)
                Project.textAnswerA = Project.currentBlock2(ListBox1.SelectedIndex + 1, 4)
                Project.textAnswerB = Project.currentBlock2(ListBox1.SelectedIndex + 1, 5)
                Project.textAnswerC = Project.currentBlock2(ListBox1.SelectedIndex + 1, 6)
                Project.textAnswerD = Project.currentBlock2(ListBox1.SelectedIndex + 1, 7)
                Project.Label16.Text = Project.questionText
                Project.Label17.Text = Project.textAnswerA
                Project.Label18.Text = Project.textAnswerB
                Project.Label19.Text = Project.textAnswerC
                Project.Label20.Text = Project.textAnswerD
                Project.numberRightAnswer = Project.currentBlock2(ListBox1.SelectedIndex + 1, 8)
                Host.Label11.Text = Project.currentBlock2(ListBox1.SelectedIndex + 1, 9)
                'Сеть
                If Project.Button7.BackColor = Color.Green Then
                    Dim NetworkInfo As New IONetwork
                    With NetworkInfo
                        .Command = "@button6|" & Project.questionText & "|" & Project.textAnswerA & "|" & Project.textAnswerB & "|" & Project.textAnswerC & "|" & Project.textAnswerD & "|" & Project.numberRightAnswer & "|" & Project.currentBlock2(ListBox1.SelectedIndex + 1, 9) & "|"
                    End With
                    Project.Client_SendIONetwork(NetworkInfo)
                End If
            End If
        Else
            My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Save base file
        If TextBox1.Text <> "" Then
            Dim tmpText As String
            Dim listSelect As Integer
            If Button1.Enabled = False Then
                listSelect = ListBox1.SelectedIndex
                currentBlock2(ListBox1.SelectedIndex + 1, 3) = TextBox1.Text 'Временное сохранение текста вопроса
                currentBlock2(ListBox1.SelectedIndex + 1, 4) = TextBox2.Text 'Временное сохранение текста ответа A
                currentBlock2(ListBox1.SelectedIndex + 1, 5) = TextBox3.Text 'Временное сохранение текста ответа B
                currentBlock2(ListBox1.SelectedIndex + 1, 6) = TextBox4.Text 'Временное сохранение текста ответа C
                currentBlock2(ListBox1.SelectedIndex + 1, 7) = TextBox5.Text 'Временное сохранение текста ответа D
                If RadioButton1.Checked = True Then
                    currentBlock2(ListBox1.SelectedIndex + 1, 8) = 1 'Временное сохранение правильного ответа 1
                End If
                If RadioButton2.Checked = True Then
                    currentBlock2(ListBox1.SelectedIndex + 1, 8) = 2 'Временное сохранение правильного ответа 2
                End If
                If RadioButton3.Checked = True Then
                    currentBlock2(ListBox1.SelectedIndex + 1, 8) = 3 'Временное сохранение правильного ответа 3
                End If
                If RadioButton4.Checked = True Then
                    currentBlock2(ListBox1.SelectedIndex + 1, 8) = 4 'Временное сохранение правильного ответа 4
                End If
                currentBlock2(ListBox1.SelectedIndex + 1, 9) = TextBox6.Text 'Временное сохранение текста комментария
                ListBox1.Items.Clear()
                For i1 = 1 To currentBlock2.GetUpperBound(0)
                    If (currentBlock2(1, 3)) <> Nothing Then
                        ListBox1.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3))
                    End If
                Next
                ListBox1.SelectedIndex = listSelect
            Else
                Button1.PerformClick()
            End If
            SaveFileDialog1.FileName = OpenFileDialog1.FileName
            FileClose(1)
            FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                tmpText = ""
                For i2 = 1 To Project.maxCow
                    'Сохранение в файл
                    If currentBlock2(i1, i2) <> "" Then
                        'Замена переноса строки и "|"
                        currentBlock2(i1, i2) = currentBlock2(i1, i2).Replace(Chr(13) & Chr(10), "¶")
                        currentBlock2(i1, i2) = currentBlock2(i1, i2).Replace("|", "")
                    End If
                    tmpText = tmpText & currentBlock2(i1, i2) & "|"
                    If currentBlock2(i1, i2) <> "" Then currentBlock2(i1, i2) = currentBlock2(i1, i2).Replace("¶", Chr(13) & Chr(10)) 'Замена переноса строки
                Next
                Print(1, tmpText & Chr(13) & Chr(10))
            Next
        FileClose(1)
        Else
        My.Computer.Audio.PlaySystemSound(Media.SystemSounds.Exclamation)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Open file...
        OpenFileDialog1.FileName = "*.questions"
        OpenFileDialog1.InitialDirectory = CurDir() & "\Bases"
        OpenFileDialog1.CheckFileExists = True
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenFileDialog1.FileName
            Call openfilesdata(FileNameQ)
            If OpenFileDialog1.FileName <> Project.OpenFileDialog1.FileName Then
                Button1.Enabled = False
            Else
                Button1.Enabled = True
            End If
        End If
    End Sub

    Private Sub openfilesdata(sender As Object)
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        Label1.Text = FileNameQ
        If FileNameQ <> "*.questions" Then
            ListBox1.Enabled = True
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
            REM Заполнение ListBox1
            ListBox1.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0) 'Можно 15, но мы сделали резерв
                If (currentBlock2(1, 3)) <> Nothing Then
                    ListBox1.Items.Add(currentBlock0(i1, 2) & ": " & currentBlock0(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            REM /Заполнение ListBox1
            REM /***********************
            Button3.BackColor = Color.White
            ListBox1.SelectedIndex = 0
        Else
            ListBox1.Enabled = False
            ListBox1.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open file..."" button.")
            Button3.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
            Label1.Text = "Question File Adress (Choose question base file with format ""*.question"")"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Create new file...
        Dim n As Integer
        While My.Computer.FileSystem.FileExists(CurDir() & "\Bases\NewBase" & n & ".questions") = True
            n = n + 1
        End While
        SaveFileDialog1.FileName = "NewBase" & n & ".questions"
        SaveFileDialog1.InitialDirectory = CurDir() & "\Bases"
        SaveFileDialog1.CreatePrompt = False
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.CheckPathExists = True
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                FileCopy(CurDir() & "\Bases\" & Project.currentBlock1(2, 3) & "Base_Example.questions", SaveFileDialog1.FileName)
            Catch
                FileClose(1)
                FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)
                Print(1, "|1|First question?|Answer A1|Answer B1|Answer C1|Answer D1|1|Comment for question number 1.|" & Chr(13) & Chr(10) & _
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
                FileClose(1)
            End Try
            OpenFileDialog1.FileName = SaveFileDialog1.FileName
            FileNameQ = OpenFileDialog1.FileName
            Call openfilesdata(FileNameQ)
            If OpenFileDialog1.FileName <> Project.OpenFileDialog1.FileName Then
                Button1.Enabled = False
            Else
                Button1.Enabled = True
            End If
        End If
    End Sub
End Class