Imports System.Text

Public Class EditorFFF
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
        OpenFileDialog1.InitialDirectory = FastestFingerFirst.sourcePath
        FileNameQ = FastestFingerFirst.OpenFileDialog1.FileName
        Label1.Text = FastestFingerFirst.OpenFileDialog1.FileName
        OpenFileDialog1.FileName = FileNameQ
        If FileNameQ <> "*.fff" Then
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
                                    FastestFingerFirst.maxCow = i1 - 1
                                End If
                            Next
                        End If
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    End Try
                End While
                ReDim currentBlock2(i0, FastestFingerFirst.maxCow)
                For i2 = 0 To i0
                    For i1 = 0 To FastestFingerFirst.maxCow
                        currentBlock2(i2, i1) = currentBlock0(i2, i1)
                    Next
                Next
            End Using
            REM /Считывание базы данных вопросов из выбранного файла
            REM /**********************
            'Приравнивание массивов
            For i1 = 1 To FastestFingerFirst.currentBlock2.GetUpperBound(0)
                For i2 = 1 To FastestFingerFirst.maxCow
                    If FastestFingerFirst.currentBlock2(i1, i2) <> Nothing Then
                        currentBlock2(i1, i2) = FastestFingerFirst.currentBlock2(i1, i2)
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
            ListBox1.SelectedIndex = FastestFingerFirst.ListBox1.SelectedIndex
        Else
            ListBox1.Enabled = False
            ListBox1.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open"" button.")
            Button3.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
            Label1.Text = "Question File Adress (Choose question base file with format ""*.fff"")"
        End If
        'Перевод "F" Editor
        Me.Text = FastestFingerFirst.currentBlock1(117, 3) '0
        Label2.Text = FastestFingerFirst.currentBlock1(118, 3) '1
        Button1.Text = FastestFingerFirst.currentBlock1(119, 3) '2
        Button2.Text = FastestFingerFirst.currentBlock1(120, 3) '3
        Button3.Text = FastestFingerFirst.currentBlock1(121, 3) '4
        Button4.Text = FastestFingerFirst.currentBlock1(122, 3) '5
        Label7.Text = FastestFingerFirst.currentBlock1(131, 3) '8
        Label8.Text = FastestFingerFirst.currentBlock1(132, 3) '9
        Label9.Text = FastestFingerFirst.currentBlock1(133, 3) '10
        Label10.Text = FastestFingerFirst.currentBlock1(134, 3) '11
        'Перевод "I"
        Label11.Text = FastestFingerFirst.currentBlock1(144, 3) '1
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        rightAnswerNumber = Int(currentBlock2(ListBox1.SelectedIndex + 1, 8) & currentBlock2(ListBox1.SelectedIndex + 1, 9) & currentBlock2(ListBox1.SelectedIndex + 1, 10) & currentBlock2(ListBox1.SelectedIndex + 1, 11)) 'Выбор номера правильного ответа из массива
        'rightAnswerText = currentBlock2(ListBox1.SelectedIndex + 1, rightAnswerNumber + 3) 'Текст ответа из массива (номер ответа + 3)
        For x = 1 To 5
            Me.Controls("TextBox" & x).Text = currentBlock2(ListBox1.SelectedIndex + 1, x + 2)
        Next
        ComboBox1.SelectedIndex = Int(currentBlock2(ListBox1.SelectedIndex + 1, 8))
        ComboBox2.SelectedIndex = Int(currentBlock2(ListBox1.SelectedIndex + 1, 9))
        ComboBox3.SelectedIndex = Int(currentBlock2(ListBox1.SelectedIndex + 1, 10))
        ComboBox4.SelectedIndex = Int(currentBlock2(ListBox1.SelectedIndex + 1, 11))
        TextBox6.Text = currentBlock2(ListBox1.SelectedIndex + 1, 12)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Save temporarily
        If TextBox1.Text <> "" Then
            FastestFingerFirst.ListBox1.SelectedIndex = ListBox1.SelectedIndex
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 3) = TextBox1.Text 'Временное сохранение текста вопроса
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 4) = TextBox2.Text 'Временное сохранение текста ответа A
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 5) = TextBox3.Text 'Временное сохранение текста ответа B
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 6) = TextBox4.Text 'Временное сохранение текста ответа C
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 7) = TextBox5.Text 'Временное сохранение текста ответа D
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 8) = ComboBox1.SelectedIndex 'Временное сохранение первого ответа
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 9) = ComboBox2.SelectedIndex 'Временное сохранение второго ответа
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 10) = ComboBox3.SelectedIndex 'Временное сохранение третьего ответа
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 11) = ComboBox4.SelectedIndex 'Временное сохранение четвёртого ответа
            FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 12) = TextBox6.Text 'Временное сохранение текста комментария
            FastestFingerFirst.first = ComboBox1.SelectedIndex
            FastestFingerFirst.second = ComboBox2.SelectedIndex
            FastestFingerFirst.third = ComboBox3.SelectedIndex
            FastestFingerFirst.fourth = ComboBox4.SelectedIndex
            'Перезагрузка FastestFingerFirst.ListBox1
            FastestFingerFirst.ListBox1.Items.Clear()
            For i1 = 1 To FastestFingerFirst.currentBlock2.GetUpperBound(0)
                If (FastestFingerFirst.currentBlock2(1, 3)) <> Nothing Then
                    FastestFingerFirst.ListBox1.Items.Add(FastestFingerFirst.currentBlock2(i1, 2) & ": " & FastestFingerFirst.currentBlock2(i1, 3).Replace(Chr(13) & Chr(10), " "))
                End If
            Next
            FastestFingerFirst.ListBox1.SelectedIndex = ListBox1.SelectedIndex
            'Приравнивание массивов
            For i1 = 1 To FastestFingerFirst.currentBlock2.GetUpperBound(0)
                For i2 = 1 To FastestFingerFirst.maxCow
                    If FastestFingerFirst.currentBlock2(i1, i2) <> Nothing Then
                        currentBlock2(i1, i2) = FastestFingerFirst.currentBlock2(i1, i2)
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
            ListBox1.SelectedIndex = FastestFingerFirst.ListBox1.SelectedIndex
            If FastestFingerFirst.fourth <> 0 Then
                FastestFingerFirst.Label22.Text = FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 3) & Chr(13) & "A: " & FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 4) & " B: " & FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 5) & " C: " & FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 6) & " D: " & FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 7) & ". " & FastestFingerFirst.currentBlock1(144, 3) & " " & FastestFingerFirst.first & ", " & FastestFingerFirst.second & ", " & FastestFingerFirst.third & ", " & FastestFingerFirst.fourth
            Else
                FastestFingerFirst.Label22.Text = FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 3) & Chr(13) & "A: " & FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 4) & " B: " & FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 5) & " C: " & FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 6) & " D: " & FastestFingerFirst.currentBlock2(ListBox1.SelectedIndex + 1, 7) & ". " & FastestFingerFirst.currentBlock1(143, 3) & " " & FastestFingerFirst.first
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
                currentBlock2(ListBox1.SelectedIndex + 1, 8) = ComboBox1.SelectedIndex 'Временное сохранение первого ответа
                currentBlock2(ListBox1.SelectedIndex + 1, 9) = ComboBox2.SelectedIndex 'Временное сохранение второго ответа
                currentBlock2(ListBox1.SelectedIndex + 1, 10) = ComboBox3.SelectedIndex 'Временное сохранение третьего ответа
                currentBlock2(ListBox1.SelectedIndex + 1, 11) = ComboBox4.SelectedIndex 'Временное сохранение четвёртого ответа
                currentBlock2(ListBox1.SelectedIndex + 1, 12) = TextBox6.Text 'Временное сохранение текста комментария
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
                For i2 = 1 To FastestFingerFirst.maxCow
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
        OpenFileDialog1.FileName = "*.fff"
        OpenFileDialog1.InitialDirectory = CurDir() & "\Bases"
        OpenFileDialog1.CheckFileExists = True
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenFileDialog1.FileName
            Call openfilesdata(FileNameQ)
            If OpenFileDialog1.FileName <> FastestFingerFirst.OpenFileDialog1.FileName Then
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
        If FileNameQ <> "*.fff" Then
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
            Label1.Text = "Question File Adress (Choose question base file with format ""*.fff"")"
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Create new file...
        Dim n As Integer
        While My.Computer.FileSystem.FileExists(CurDir() & "\Bases\NewBaseFFF" & n & ".fff") = True
            n = n + 1
        End While
        SaveFileDialog1.FileName = "NewBaseFFF" & n & ".fff"
        SaveFileDialog1.InitialDirectory = CurDir() & "\Bases"
        SaveFileDialog1.CreatePrompt = False
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.CheckPathExists = True
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Try
                FileCopy(CurDir() & "\Bases\" & FastestFingerFirst.currentBlock1(2, 3) & "Qualify.fff", SaveFileDialog1.FileName)
            Catch
                FileClose(1)
                FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)
                Print(1, "|1|Fatest Finger 1 Question.|Answer A1|Answer B1|Answer C1|Answer D1|1|2|3|4|Comment for question 1.|" & Chr(13) & Chr(10) & _
                      "|2|Fatest Finger 2 Question.|Answer A2|Answer B2|Answer C2|Answer D2|1|2|3|4|Comment for question 2.|" & Chr(13) & Chr(10) & _
                      "|3|Fatest Finger 3 Question.|Answer A3|Answer B3|Answer C3|Answer D3|1|2|3|4|Comment for question 3.|" & Chr(13) & Chr(10) & _
                      "|4|Fatest Finger 4 Question.|Answer A4|Answer B4|Answer C4|Answer D4|1|2|3|4|Comment for question 4.|" & Chr(13) & Chr(10) & _
                      "|5|Fatest Finger 5 Question.|Answer A5|Answer B5|Answer C5|Answer D5|1|2|3|4|Comment for question 5.|" & Chr(13) & Chr(10) & _
                      "|6|Fatest Finger 6 Question.|Answer A6|Answer B6|Answer C6|Answer D6|1|2|3|4|Comment for question 6.|" & Chr(13) & Chr(10) & _
                      "|7|Fatest Finger 7 Question.|Answer A7|Answer B7|Answer C7|Answer D7|1|2|3|4|Comment for question 7.|" & Chr(13) & Chr(10) & _
                      "|8|Fatest Finger 8 Question.|Answer A8|Answer B8|Answer C8|Answer D8|1|2|3|4|Comment for question 8.|" & Chr(13) & Chr(10))
                FileClose(1)
            End Try
            OpenFileDialog1.FileName = SaveFileDialog1.FileName
            FileNameQ = OpenFileDialog1.FileName
            Call openfilesdata(FileNameQ)
            If OpenFileDialog1.FileName <> FastestFingerFirst.OpenFileDialog1.FileName Then
                Button1.Enabled = False
            Else
                Button1.Enabled = True
            End If
        End If
    End Sub
End Class