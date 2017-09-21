Imports System
Imports System.IO

Public Class FastestFingerFirst
    Dim lang As String 'Путь языкового пакета
    Dim files() As String 'Массив списка файлов перевода
    Public sourcePath As String 'Путь ресурсной папки
    Dim langSource As String 'Путь ресурсов локализации
    Dim FileNameQ As String 'Путь и имя файла базы вопросов
    Dim currentBlock0(,) As String 'Временный массив
    Public currentBlock1(,) As String 'Массив русификации
    Public currentBlock2(,) As String 'Массив вопросов
    Dim currentBlock3(,) As String 'Массив списка участников
    Dim ini() As String 'Массив файла .ini
    Dim contQuant As Integer 'Кол-во участников
    Dim contNumber As Integer 'Номер текущего участника
    Public first As Integer 'Номер 1 ответа
    Public second As Integer 'Номер 2 ответа
    Public third As Integer 'Номер 3 ответа
    Public fourth As Integer 'Номер 4 ответа
    Dim stepOK As Integer 'Шаг кнопки OK
    Dim contAnswer As String 'Последовательность ответа участника
    Dim contTime As Decimal 'Текущее время участника
    Dim startTimer As Long 'Время комп-ра при старте таймера
    Dim stopTimer As Long 'Время комп-ра при остановке таймера
    Dim clockFrame As Integer 'Кадр часов
    Public maxCow As Integer = 8 'Максимальное кол-во колоннок в файле вопросов

    Private Sub FastestFingerFirst_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        ComboBox1.Items.Clear()
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
        'Поиск файлов языка
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
        OpenFileDialog2.FileName = "Bases\" & currentBlock1(2, 3) & "contestants.con"
        sourcePath = CurDir() & "\Source"
        langSource = CurDir() & currentBlock1(3, 3)
        OpenFileDialog1.InitialDirectory = CurDir() & "Bases\"
        OpenFileDialog1.FileName = "Bases\" & currentBlock1(2, 3) & "qualify.fff"
        FileNameQ = OpenFileDialog1.FileName
        Call openfilesdata(FileNameQ)
        For x = 1 To 20
            Me.Controls("TextBox" & x).Text = Nothing
        Next
        Label1.Text = Nothing
        Label15.Text = Nothing
        For x = 16 To 20
            Me.Controls("Label" & x).Text = Nothing
        Next
        For x = 26 To 29
            Me.Controls("Label" & x).Text = Nothing
        Next
        Label16.Visible = False
        Label17.Visible = False
        Label18.Visible = False
        Label19.Visible = False
        Label20.Visible = False
        Label30.Visible = False
        Label31.Visible = False
        Label32.Visible = False
        TextBox21.Visible = False
        TextBox22.Visible = False
        Button2.Visible = False
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        EditorFFF.Show()
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        'Выбор языка
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer = 0
        Dim i1 As Integer = 0
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(files(ComboBox1.SelectedIndex), System.Text.Encoding.Default)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters("|")
            ReDim currentRow(5)
            ReDim currentBlock1(150, 8)
            currentBlock1(2, 3) = "ENG_"
            currentBlock1(3, 3) = "\Source"
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
        langSource = CurDir() & currentBlock1(3, 3)
        OpenFileDialog1.FileName = "Bases\" & currentBlock1(2, 3) & "qualify.fff"
        OpenFileDialog2.FileName = "Bases\" & currentBlock1(2, 3) & "contestants.con"
        FileNameQ = OpenFileDialog1.FileName
        Call openfilesdata(FileNameQ)
        'Перевод "A" FormStart
        Label25.Text = currentBlock1(19, 3)
        Button2.Text = currentBlock1(20, 3)
        'Перевод "G" FormFFF
        Text = currentBlock1(123, 3) '0
        Button13.Text = currentBlock1(124, 3) '1
        Label23.Text = currentBlock1(137, 3) '14
        Label13.Text = currentBlock1(138, 3) '15
        Label3.Text = currentBlock1(138, 3) '15
        Label31.Text = currentBlock1(138, 3) '15
        Label14.Text = currentBlock1(139, 3) '16
        Label2.Text = currentBlock1(139, 3) '16
        Label32.Text = currentBlock1(139, 3) '16
        'Перевод "J" Fastest Finger First
        Button1.Text = currentBlock1(147, 3) '0
        Label24.Text = currentBlock1(148, 3).Replace("¶", Chr(13) & Chr(10)) '1
        CheckBox1.Text = currentBlock1(149, 3) '2
        'Шрифты
        Label16.Font = New Font(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        Label17.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Label18.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Label19.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Label20.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        Label24.Font = New Font(currentBlock1(5, 3), Int(currentBlock1(4, 4)) - 8.25)
    End Sub

    Private Sub openfilesdata(sender As Object)
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        If FileNameQ <> "*.fff" Then
            ListBox1.Enabled = True
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
                                    maxCow = i1 - 1
                                End If
                            Next
                        End If
                    Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    End Try
                End While
                ReDim currentBlock2(i0, maxCow)
                For i2 = 0 To i0
                    For i1 = 0 To maxCow
                        currentBlock2(i2, i1) = currentBlock0(i2, i1)
                    Next
                Next
            End Using
            ListBox1.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    ListBox1.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3))
                End If
            Next
            ListBox1.SelectedIndex = 0
            Button13.BackColor = Color.White
        Else
            ListBox1.Enabled = False
            ListBox1.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open base file"" button.")
            Button13.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
        End If
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        first = Int(currentBlock2(ListBox1.SelectedIndex + 1, 8))
        second = Int(currentBlock2(ListBox1.SelectedIndex + 1, 9))
        third = Int(currentBlock2(ListBox1.SelectedIndex + 1, 10))
        fourth = Int(currentBlock2(ListBox1.SelectedIndex + 1, 11))
        If fourth <> 0 Then
            Label22.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(ListBox1.SelectedIndex + 1, 4) & " B: " & currentBlock2(ListBox1.SelectedIndex + 1, 5) & " C: " & currentBlock2(ListBox1.SelectedIndex + 1, 6) & " D: " & currentBlock2(ListBox1.SelectedIndex + 1, 7) & ". " & currentBlock1(144, 3) & " " & first & ", " & second & ", " & third & ", " & fourth
        Else
            Label22.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(ListBox1.SelectedIndex + 1, 4) & " B: " & currentBlock2(ListBox1.SelectedIndex + 1, 5) & " C: " & currentBlock2(ListBox1.SelectedIndex + 1, 6) & " D: " & currentBlock2(ListBox1.SelectedIndex + 1, 7) & ". " & currentBlock1(143, 3) & " " & first
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        'Open base file...
        OpenFileDialog1.FileName = "*.fff"
        OpenFileDialog1.InitialDirectory = CurDir() & "\Bases"
        OpenFileDialog1.CheckFileExists = True
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenFileDialog1.FileName
            Call openfilesdata(FileNameQ)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked = True Then
            For x = 1 To 20
                Me.Controls("TextBox" & x).Enabled = False
            Next
        Else
            For x = 1 To 20
                Me.Controls("TextBox" & x).Enabled = True
            Next
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Start FFF
        contNumber = 1
        stepOK = 0
        ListBox1.Visible = False
        Button1.Visible = False
        Button13.Visible = False
        Label22.Visible = False
        Label23.Visible = False
        CheckBox1.Visible = False
        Label25.Visible = False
        ComboBox1.Visible = False
        Label13.Visible = False
        Label14.Visible = False
        Label3.Visible = False
        Label2.Visible = False
        Label21.Visible = False
        Label6.Visible = False
        Label8.Visible = False
        Label10.Visible = False
        Label12.Visible = False
        Label4.Visible = False
        Label5.Visible = False
        Label7.Visible = False
        Label9.Visible = False
        Label11.Visible = False
        For x = 1 To 20
            Me.Controls("TextBox" & x).Visible = False
        Next
        Label24.Visible = False
        'Отображение интерфейса игрока
        Label16.Text = Nothing
        Label17.Text = Nothing
        Label18.Text = Nothing
        Label19.Text = Nothing
        Label20.Text = Nothing
        Label16.Visible = True
        Label17.Visible = True
        Label18.Visible = True
        Label19.Visible = True
        Label20.Visible = True
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        PictureBox1.Visible = True
        PictureBox2.Visible = True
        PictureBox3.Visible = True
        PictureBox4.Visible = True
        PictureBox5.Visible = True
        For x = 6 To 11
            Me.Controls("PictureBox" & x).Visible = True
        Next
        For x = 26 To 29
            Me.Controls("Label" & x).Text = Nothing
        Next
        For x = 16 To 20
            Me.Controls("Label" & x).Text = Nothing
        Next
        Label1.Text = "Del"
        Label15.Text = "OK"
        ReDim currentBlock3(10, 3)
        If CheckBox1.Checked = False Then
            Dim y As Integer = 0
            Dim currentRow(10)
            ReDim currentBlock0(10, 3)
            For x = 1 To 10
                currentBlock0(x, 1) = Me.Controls("TextBox" & x).Text
            Next
            For x = 11 To 20
                currentBlock0(x - 10, 2) = Me.Controls("TextBox" & x).Text
            Next
            Dim m As Integer = 10 'Кол-во заполненных строк
            For x = 1 To 10
                If currentBlock0(x, 1) = Nothing Then m = m - 1
            Next
            ReDim currentBlock3(m, 3)
            y = 1
            For x = 1 To 10
                If currentBlock0(x, 1) <> Nothing Then
                    currentBlock3(y, 1) = ""
                    currentBlock3(y, 2) = ""
                    currentBlock3(y, 1) = currentBlock0(x, 1)
                    currentBlock3(y, 2) = currentBlock0(x, 2)
                    y = y + 1
                End If
            Next
            contQuant = m 'Задание кол-ва участников
            If m = 0 Then
                CheckBox1.Checked = True
                Label30.Text = Str(contNumber)
                Label30.Visible = True
                Label31.Visible = True
                Label32.Visible = True
                TextBox21.Visible = True
                TextBox22.Visible = True
                Button2.Visible = True
                ReDim currentBlock3(10, 3)
            Else
                Label16.Text = currentBlock3(contNumber, 1) & Chr(13) & currentBlock3(contNumber, 2)
            End If
        Else
            Label30.Text = Str(contNumber)
            Label30.Visible = True
            Label31.Visible = True
            Label32.Visible = True
            TextBox21.Visible = True
            TextBox22.Visible = True
            Button2.Visible = True
        End If
    End Sub

    Private Sub TextBox21_TextChanged(sender As Object, e As EventArgs) Handles TextBox21.TextChanged, TextBox22.TextChanged
        'Изменение текста имени текущего игрока (CheckBox1.Checked)
        Label16.Text = TextBox21.Text & Chr(13) & TextBox22.Text
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'START button (CheckBox2.Checked)
        If TextBox21.Text <> Nothing Then
            stepOK = 1
            currentBlock3(contNumber, 1) = TextBox21.Text
            currentBlock3(contNumber, 2) = TextBox22.Text
            Label30.Visible = False
            Label31.Visible = False
            Label32.Visible = False
            TextBox21.Visible = False
            TextBox22.Visible = False
            Button2.Visible = False
            My.Computer.Audio.Play("source\MUSIC\Standby for Q.wav")
            Label16.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3)
        Else
            If contNumber <> 1 Then
                Dim n As Integer
                While My.Computer.FileSystem.FileExists(CurDir() & "\Bases\NewBaseCON" & n & ".con") = True
                    n = n + 1
                End While
                SaveFileDialog1.FileName = "NewBaseCON" & n & ".con"
                SaveFileDialog1.InitialDirectory = CurDir() & "\Bases"
                SaveFileDialog1.CreatePrompt = False
                SaveFileDialog1.OverwritePrompt = True
                SaveFileDialog1.CheckPathExists = True
                If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    contQuant = Int(Label30.Text) - 1
                    contNumber = contQuant
                    stepOK = 4
                    Dim tmpText As String
                    FileClose(1)
                    FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)
                    For i1 = 1 To currentBlock3.GetUpperBound(0)
                        If currentBlock3(i1, 1) <> Nothing Then
                            tmpText = "|" & i1 & "|"
                            For i2 = 1 To 3
                                'Сохранение в файл
                                If currentBlock3(i1, i2) <> "" Then currentBlock3(i1, i2) = currentBlock3(i1, i2).Replace("|", "")
                                tmpText = tmpText & currentBlock3(i1, i2) & "|"
                            Next
                            Print(1, tmpText & Chr(13) & Chr(10))
                        End If
                    Next
                    FileClose(1)
                    MsgBox(currentBlock1(150, 6) & "! " & currentBlock1(150, 7) & ": " & SaveFileDialog1.FileName, MsgBoxStyle.Information, currentBlock1(150, 6))
                    Me.Close()
                End If
            Else
                MsgBox(currentBlock1(150, 3)) 'You don't entered any contestant name!
            End If
        End If
    End Sub

    Private Sub PictureBox11_Click(sender As Object, e As EventArgs) Handles PictureBox11.Click, Label15.Click
        'OK
        Select Case stepOK
            Case 0
                If CheckBox1.Checked = False Then
                    stepOK = 1
                    My.Computer.Audio.Play("source\MUSIC\Standby for Q.wav")
                    Label16.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3)
                End If
            Case 1
                stepOK = 2
                My.Computer.Audio.Play("source\MUSIC\Three Beeps.wav")
            Case 2
                stepOK = 3
                My.Computer.Audio.Play("source\MUSIC\Fastest finger first.wav")
                contTime = 0
                Timer1.Start()
                startTimer = System.DateTime.Now.Ticks
                Label16.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3)
                Label17.Text = currentBlock2(ListBox1.SelectedIndex + 1, 4)
                Label18.Text = currentBlock2(ListBox1.SelectedIndex + 1, 5)
                Label19.Text = currentBlock2(ListBox1.SelectedIndex + 1, 6)
                Label20.Text = currentBlock2(ListBox1.SelectedIndex + 1, 7)
                PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                PictureBox12.Visible = True
                Timer2.Start()
                clockFrame = 21
                PictureBox12.ImageLocation = "source\CLOCK\Clock (21).png"
            Case 3
                If Label16.Text <> currentBlock1(150, 5) Then
                    If Label26.Text <> Nothing And Label27.Text <> Nothing And Label28.Text <> Nothing And Label29.Text <> Nothing Then
                        Timer1.Stop()
                        stopTimer = System.DateTime.Now.Ticks
                        contTime = Math.Round((stopTimer - startTimer) / 100000) / 100
                        My.Computer.Audio.Play("source\MUSIC\Fastest finger first end.wav")
                        Timer2.Stop()
                        clockFrame = 62
                        PictureBox12.ImageLocation = "source\CLOCK\Clock (62).png"
                        'Сравнение ответа с правильным
                        If fourth <> 0 Then
                            Dim right As String = first & second & third & fourth
                            If contAnswer = right Then
                                Dim temp As String = Str(contTime).Replace(Chr(46), Chr(44))
                                currentBlock3(contNumber, 3) = temp.Trim(" ")
                                If Int(currentBlock3(contNumber, 3)) < 10 Then
                                    Select Case currentBlock3(contNumber, 3).Length
                                        Case 3
                                            currentBlock3(contNumber, 3) &= "0"
                                        Case 1
                                            currentBlock3(contNumber, 3) &= ",00"
                                    End Select
                                Else
                                    Select Case currentBlock3(contNumber, 3).Length
                                        Case 4
                                            currentBlock3(contNumber, 3) &= "0"
                                        Case 2
                                            currentBlock3(contNumber, 3) &= ",00"
                                    End Select
                                End If
                            Else
                                contTime = 0
                                currentBlock3(contNumber, 3) = "0"
                            End If
                        Else
                            If first = contAnswer Then
                                Dim temp As String = Str(contTime).Replace(Chr(46), Chr(44))
                                currentBlock3(contNumber, 3) = temp.Trim(" ")
                                If Int(currentBlock3(contNumber, 3)) < 10 Then
                                    Select Case currentBlock3(contNumber, 3).Length
                                        Case 3
                                            currentBlock3(contNumber, 3) &= "0"
                                        Case 1
                                            currentBlock3(contNumber, 3) &= ",00"
                                    End Select
                                Else
                                    Select Case currentBlock3(contNumber, 3).Length
                                        Case 4
                                            currentBlock3(contNumber, 3) &= "0"
                                        Case 2
                                            currentBlock3(contNumber, 3) &= ",00"
                                    End Select
                                End If
                            Else
                                contTime = 0
                                currentBlock3(contNumber, 3) = "0"
                            End If
                        End If
                        contTime = 0
                        Label16.Text = currentBlock1(150, 4) 'Saving complete.
                        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                        Label17.BackColor = Color.FromArgb(42, 42, 42)
                        Label18.BackColor = Color.FromArgb(42, 42, 42)
                        Label19.BackColor = Color.FromArgb(42, 42, 42)
                        Label20.BackColor = Color.FromArgb(42, 42, 42)
                        Label17.ForeColor = Color.White
                        Label18.ForeColor = Color.White
                        Label19.ForeColor = Color.White
                        Label20.ForeColor = Color.White
                        Label17.Text = Nothing
                        Label18.Text = Nothing
                        Label19.Text = Nothing
                        Label20.Text = Nothing
                        Label26.Text = Nothing
                        Label27.Text = Nothing
                        Label28.Text = Nothing
                        Label29.Text = Nothing
                        PictureBox12.Visible = False
                        stepOK = 4
                    End If
                Else
                    Label26.Text = Nothing
                    Label27.Text = Nothing
                    Label28.Text = Nothing
                    Label29.Text = Nothing
                    currentBlock3(contNumber, 3) = 0
                    Label16.Text = currentBlock1(150, 4) 'Saving complete.
                    PictureBox12.Visible = False
                    stepOK = 4
                End If
            Case 4
                If contNumber <> contQuant And contNumber < 10 Then
                    'Следующий участник
                    PictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer1.png")
                    Label15.BackColor = Color.FromArgb(42, 42, 42)
                    Label15.ForeColor = Color.White
                    contAnswer = Nothing
                    stepOK = 0
                    contNumber = contNumber + 1
                    If CheckBox1.Checked Then
                        TextBox21.Text = Nothing
                        TextBox22.Text = Nothing
                        Label30.Text = Str(contNumber)
                        Label30.Visible = True
                        Label31.Visible = True
                        Label32.Visible = True
                        TextBox21.Visible = True
                        TextBox22.Visible = True
                        Button2.Visible = True
                    End If
                    Label16.Text = currentBlock3(contNumber, 1) & Chr(13) & currentBlock3(contNumber, 2)
                Else
                    Call SaveFileData() 'Запсь данных в файл
                End If
        End Select
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        contTime = 0
        Label16.Text = currentBlock1(150, 5) 'TIME'S UP!
        Label17.Text = Nothing
        Label18.Text = Nothing
        Label19.Text = Nothing
        Label20.Text = Nothing
        PictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
        Label15.BackColor = Color.FromArgb(244, 155, 15)
        Label15.ForeColor = Color.Black
        PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        Label17.BackColor = Color.FromArgb(42, 42, 42)
        Label18.BackColor = Color.FromArgb(42, 42, 42)
        Label19.BackColor = Color.FromArgb(42, 42, 42)
        Label20.BackColor = Color.FromArgb(42, 42, 42)
        Label17.ForeColor = Color.White
        Label18.ForeColor = Color.White
        Label19.ForeColor = Color.White
        Label20.ForeColor = Color.White
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        clockFrame = clockFrame + 1
        PictureBox12.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        If clockFrame = 61 Then
            Timer2.Stop()
            PictureBox12.ImageLocation = "source\CLOCK\Clock (61).png"
        End If
    End Sub

    Private Sub PictureBox10_Click(sender As Object, e As EventArgs) Handles PictureBox10.Click, Label1.Click
        'Del
        If stepOK = 3 Then
            For x = 26 To 29
                Me.Controls("Label" & x).Text = Nothing
            Next
            PictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer1.png")
            Label15.BackColor = Color.FromArgb(42, 42, 42)
            Label15.ForeColor = Color.White
            PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
            PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
            PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
            PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
            Label17.BackColor = Color.FromArgb(42, 42, 42)
            Label18.BackColor = Color.FromArgb(42, 42, 42)
            Label19.BackColor = Color.FromArgb(42, 42, 42)
            Label20.BackColor = Color.FromArgb(42, 42, 42)
            Label17.ForeColor = Color.White
            Label18.ForeColor = Color.White
            Label19.ForeColor = Color.White
            Label20.ForeColor = Color.White
            contAnswer = Nothing
        End If
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click, Label17.Click
        'A
        If stepOK = 3 And Label17.BackColor <> Color.FromArgb(244, 155, 15) Then
            If fourth <> 0 Then
                If Label26.Text = Nothing Then
                    Label26.Text = "A:"
                Else
                    If Label27.Text = Nothing Then
                        Label27.Text = "A:"
                    Else
                        If Label28.Text = Nothing Then
                            Label28.Text = "A:"
                        Else
                            Label29.Text = "A:"
                            PictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
                            Label15.BackColor = Color.FromArgb(244, 155, 15)
                            Label15.ForeColor = Color.Black
                        End If
                    End If
                End If
                PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_ORANGE.png")
                Label17.BackColor = Color.FromArgb(244, 155, 15)
                Label17.ForeColor = Color.Black
                contAnswer = contAnswer & "1"
            Else
                PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_ORANGE.png")
                PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                Label17.BackColor = Color.FromArgb(244, 155, 15)
                Label18.BackColor = Color.FromArgb(42, 42, 42)
                Label19.BackColor = Color.FromArgb(42, 42, 42)
                Label20.BackColor = Color.FromArgb(42, 42, 42)
                Label17.ForeColor = Color.Black
                Label18.ForeColor = Color.White
                Label19.ForeColor = Color.White
                Label20.ForeColor = Color.White
                contAnswer = "1"
            End If
        End If
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click, Label18.Click
        'B
        If stepOK = 3 And Label18.BackColor <> Color.FromArgb(244, 155, 15) Then
            If fourth <> 0 Then
                If Label26.Text = Nothing Then
                    Label26.Text = "B:"
                Else
                    If Label27.Text = Nothing Then
                        Label27.Text = "B:"
                    Else
                        If Label28.Text = Nothing Then
                            Label28.Text = "B:"
                        Else
                            Label29.Text = "B:"
                            PictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
                            Label15.BackColor = Color.FromArgb(244, 155, 15)
                            Label15.ForeColor = Color.Black
                        End If
                    End If
                End If
                PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_ORANGE.png")
                Label18.BackColor = Color.FromArgb(244, 155, 15)
                Label18.ForeColor = Color.Black
                contAnswer = contAnswer & "2"
            Else
                PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_ORANGE.png")
                PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                Label17.BackColor = Color.FromArgb(42, 42, 42)
                Label18.BackColor = Color.FromArgb(244, 155, 15)
                Label19.BackColor = Color.FromArgb(42, 42, 42)
                Label20.BackColor = Color.FromArgb(42, 42, 42)
                Label17.ForeColor = Color.White
                Label18.ForeColor = Color.Black
                Label19.ForeColor = Color.White
                Label20.ForeColor = Color.White
                contAnswer = "2"
            End If
        End If
    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click, Label19.Click
        'C
        If stepOK = 3 And Label19.BackColor <> Color.FromArgb(244, 155, 15) Then
            If fourth <> 0 Then
                If Label26.Text = Nothing Then
                    Label26.Text = "C:"
                Else
                    If Label27.Text = Nothing Then
                        Label27.Text = "C:"
                    Else
                        If Label28.Text = Nothing Then
                            Label28.Text = "C:"
                        Else
                            Label29.Text = "C:"
                            PictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
                            Label15.BackColor = Color.FromArgb(244, 155, 15)
                            Label15.ForeColor = Color.Black
                        End If
                    End If
                End If
                PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_ORANGE.png")
                Label19.BackColor = Color.FromArgb(244, 155, 15)
                Label19.ForeColor = Color.Black
                contAnswer = contAnswer & "3"
            Else
                PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_ORANGE.png")
                PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                Label17.BackColor = Color.FromArgb(42, 42, 42)
                Label18.BackColor = Color.FromArgb(42, 42, 42)
                Label19.BackColor = Color.FromArgb(244, 155, 15)
                Label20.BackColor = Color.FromArgb(42, 42, 42)
                Label17.ForeColor = Color.White
                Label18.ForeColor = Color.White
                Label19.ForeColor = Color.Black
                Label20.ForeColor = Color.White
                contAnswer = "3"
            End If
        End If
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click, Label20.Click
        'D
        If stepOK = 3 And Label20.BackColor <> Color.FromArgb(244, 155, 15) Then
            If fourth <> 0 Then
                If Label26.Text = Nothing Then
                    Label26.Text = "D:"
                Else
                    If Label27.Text = Nothing Then
                        Label27.Text = "D:"
                    Else
                        If Label28.Text = Nothing Then
                            Label28.Text = "D:"
                        Else
                            Label29.Text = "D:"
                            PictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
                            Label15.BackColor = Color.FromArgb(244, 155, 15)
                            Label15.ForeColor = Color.Black
                        End If
                    End If
                End If
                PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_ORANGE.png")
                Label20.BackColor = Color.FromArgb(244, 155, 15)
                Label20.ForeColor = Color.Black
                contAnswer = contAnswer & "4"
            Else
                PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_ORANGE.png")
                Label17.BackColor = Color.FromArgb(42, 42, 42)
                Label18.BackColor = Color.FromArgb(42, 42, 42)
                Label19.BackColor = Color.FromArgb(42, 42, 42)
                Label20.BackColor = Color.FromArgb(244, 155, 15)
                Label17.ForeColor = Color.White
                Label18.ForeColor = Color.White
                Label19.ForeColor = Color.White
                Label20.ForeColor = Color.Black
                contAnswer = "4"
            End If
        End If
    End Sub

    Private Sub SaveFileData()
        Dim n As Integer
        While My.Computer.FileSystem.FileExists(CurDir() & "\Bases\NewBaseCON" & n & ".con") = True
            n = n + 1
        End While
        SaveFileDialog1.FileName = "NewBaseCON" & n & ".con"
        SaveFileDialog1.InitialDirectory = CurDir() & "\Bases"
        SaveFileDialog1.CreatePrompt = False
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.CheckPathExists = True
        If SaveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim tmpText As String
            FileClose(1)
            FileOpen(1, SaveFileDialog1.FileName, OpenMode.Output)
            For i1 = 1 To currentBlock3.GetUpperBound(0)
                If currentBlock3(i1, 1) <> Nothing Then
                    tmpText = "|" & i1 & "|"
                    For i2 = 1 To 3
                        'Сохранение в файл
                        If currentBlock3(i1, i2) <> "" Then currentBlock3(i1, i2) = currentBlock3(i1, i2).Replace("|", "")
                        tmpText = tmpText & currentBlock3(i1, i2) & "|"
                    Next
                    Print(1, tmpText & Chr(13) & Chr(10))
                End If
            Next
            FileClose(1)
            MsgBox(currentBlock1(150, 6) & "! " & currentBlock1(150, 7) & ": " & SaveFileDialog1.FileName, MsgBoxStyle.Information, currentBlock1(150, 6))
            Me.Close()
        End If
    End Sub
End Class