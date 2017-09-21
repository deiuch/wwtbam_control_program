Public Class FormFFF
    Dim FileNameQ As String 'Путь и имя файла базы вопросов
    Dim currentBlock0(,) As String 'Временный массив
    Public currentBlock1(,) As String 'Массив русификации
    Public currentBlock2(,) As String 'Массив вопросов
    Dim currentBlock3(,) As String 'Массив списка участников
    'Dim massiv4(,) As String 'Массив сортировки участников
    Dim TimerTick As Integer
    Dim rules As Boolean = False
    Public first As Integer 'Номер 1 ответа
    Public second As Integer 'Номер 2 ответа
    Public third As Integer 'Номер 3 ответа
    Public fourth As Integer 'Номер 4 ответа
    Dim Text1 As String 'Текст 1 ответа
    Dim Text2 As String 'Текст 2 ответа
    Dim Text3 As String 'Текст 3 ответа
    Dim Text4 As String 'Текст 4 ответа
    Dim Timer2tick As Integer 'Номер щелчка таймера
    Dim winTime As Decimal = 20.0 'Победное время
    Dim winTime2 As Decimal = 20.0 'Время 2 победителя
    Dim winners As Integer
    Dim time1 As Decimal
    Dim time2 As Decimal
    Dim time3 As Decimal
    Dim time4 As Decimal
    Dim time5 As Decimal
    Dim time6 As Decimal
    Dim time7 As Decimal
    Dim time8 As Decimal
    Dim time9 As Decimal
    Dim time10 As Decimal
    Dim winLine As Boolean 'Зелёная ли полоса победителя
    Dim clockFrame As Integer 'Кадр часов
    Dim orderDemo As Boolean = False
    Public maxCow As Integer = 8 'Максимальное кол-во колоннок в файле вопросов

    Private Sub FormFFF_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.MaximizeBox = False
        Project.Button24.PerformClick()
        OpenFileDialog1.InitialDirectory = Project.sourcePath
        If Project.ini(14) <> Nothing And My.Computer.FileSystem.FileExists(Project.ini(14)) Then
            OpenFileDialog1.FileName = Project.ini(14)
        Else
            OpenFileDialog1.FileName = "Bases\" & Project.currentBlock1(2, 3) & "qualify.fff"
        End If
        FileNameQ = OpenFileDialog1.FileName
        Call openfilesdata(FileNameQ)
        Audience.Label16.Visible = False
        Audience.Label17.Visible = False
        Audience.Label18.Visible = False
        Audience.Label19.Visible = False
        Audience.Label20.Visible = False
        Audience.PictureBox1.Visible = False
        Audience.PictureBox2.Visible = False
        Audience.PictureBox3.Visible = False
        Audience.PictureBox4.Visible = False
        Audience.PictureBox5.Visible = False
        Audience.PictureBox6.Visible = False
        Audience.PictureBox7.Visible = False
        'Открытие списка участников
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        i1 = 0
        i0 = 0
        If OpenFileDialog2.FileName = Nothing Or My.Computer.FileSystem.FileExists(OpenFileDialog2.FileName) = False Then
            If Project.ini(15) <> Nothing And My.Computer.FileSystem.FileExists(Project.ini(15)) Then
                OpenFileDialog2.FileName = Project.ini(15)
            Else
                OpenFileDialog2.FileName = "Bases\" & Project.currentBlock1(2, 3) & "contestants.con"
            End If
        End If
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(OpenFileDialog2.FileName, System.Text.Encoding.Default)
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
            ReDim currentBlock3(i0, 5)
            For i2 = 0 To i0
                For i1 = 0 To 5
                    currentBlock3(i2, i1) = currentBlock0(i2, i1)
                Next
            Next
        End Using
        'Заполнение текстовых полей данными участников
        For x = 1 To i0
            Me.Controls("TextBox" & x).Text = currentBlock3(x, 3)
        Next
        For x = 11 To i0 + 10
            Me.Controls("TextBox" & x).Text = currentBlock3(x - 10, 4)
        Next
        For x = 21 To i0 + 20
            Me.Controls("TextBox" & x).Text = currentBlock3(x - 20, 5)
        Next
        For x = 1 To 10 - i0
            Me.Controls("TextBox" & 11 - x).Text = Nothing
            Me.Controls("TextBox" & 21 - x).Text = Nothing
            Me.Controls("TextBox" & 31 - x).Text = Nothing
        Next
        'Выравнивание по полям
        Dim x1 As Integer = 0
        ReDim currentBlock0(10, 3)
        ReDim currentBlock3(10, 3)
        For x = 1 To 10
            currentBlock0(x, 1) = Me.Controls("TextBox" & x).Text
        Next
        For x = 11 To 20
            currentBlock0(x - 10, 2) = Me.Controls("TextBox" & x).Text
        Next
        For x = 21 To 30
            currentBlock0(x - 20, 3) = Me.Controls("TextBox" & x).Text
        Next
        x1 = 1
        For x = 1 To 10
            If currentBlock0(x, 1) <> Nothing Then
                currentBlock3(x1, 1) = ""
                currentBlock3(x1, 2) = ""
                currentBlock3(x1, 3) = ""
                currentBlock3(x1, 1) = currentBlock0(x, 1)
                currentBlock3(x1, 2) = currentBlock0(x, 2)
                currentBlock3(x1, 3) = currentBlock0(x, 3)
                x1 = x1 + 1
            End If
        Next
        'Заполнение текстовых полей данными участников
        Dim m As Integer = 0 'Кол-во пустых строк
        Dim n As Integer = 0 'Кол-во строк отступа
        For x = 1 To 10
            If Me.Controls("TextBox" & x).Text = Nothing Then m = m + 1
        Next
        n = Math.Floor(m / 2)
        For x = 1 To 10
            If x + n <= 10 Then
                Me.Controls("TextBox" & x + n).Text = currentBlock3(x, 1)
                Me.Controls("TextBox" & x + 10 + n).Text = currentBlock3(x, 2)
                Me.Controls("TextBox" & x + 20 + n).Text = currentBlock3(x, 3)
            End If
        Next
        For x = 1 To n
            Me.Controls("TextBox" & x).Text = Nothing
            Me.Controls("TextBox" & x + 10).Text = Nothing
            Me.Controls("TextBox" & x + 20).Text = Nothing
        Next
        'Перевод "G" FormFFF
        Text = Project.currentBlock1(123, 3) '0
        Button13.Text = Project.currentBlock1(124, 3) '1
        Button14.Text = Project.currentBlock1(124, 4) '1
        CheckBox1.Text = Project.currentBlock1(124, 5) '1
        CheckBox2.Text = Project.currentBlock1(124, 6) '1
        Button1.Text = Project.currentBlock1(125, 3) '2
        Button2.Text = Project.currentBlock1(126, 3) '3
        Button3.Text = Project.currentBlock1(127, 3) '4
        Button4.Text = Project.currentBlock1(128, 3) '5
        Button5.Text = Project.currentBlock1(129, 3) '6
        Button6.Text = Project.currentBlock1(130, 3) '7 |What's Correct|
        Button7.Text = Project.currentBlock1(131, 3) '8
        Button8.Text = Project.currentBlock1(132, 3) '9
        Button9.Text = Project.currentBlock1(133, 3) '10
        Button10.Text = Project.currentBlock1(134, 3) '11
        Button11.Text = Project.currentBlock1(135, 3) '12
        Button12.Text = Project.currentBlock1(136, 3) '13
        Label1.Text = Project.currentBlock1(137, 3) '14
        Label13.Text = Project.currentBlock1(138, 3) '15
        Label18.Text = Project.currentBlock1(138, 3) '15
        Label14.Text = Project.currentBlock1(139, 3) '16
        Label17.Text = Project.currentBlock1(139, 3) '16
        Label15.Text = Project.currentBlock1(140, 3) '17
        Label16.Text = Project.currentBlock1(140, 3) '17
    End Sub

    Private Sub openfilesdata(sender As Object)
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
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
            REM /Считывание базы данных вопросов из выбранного файла
            REM /**********************

            REM ***********************
            REM Заполнение ListBox1
            ListBox1.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    ListBox1.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3))
                End If
            Next
            ListBox1.SelectedIndex = 0
            REM /Заполнение ListBox1
            REM /***********************
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
            Button7.Enabled = True
            Button8.Enabled = True
            Button9.Enabled = True
            Button10.Enabled = True
            Label2.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(ListBox1.SelectedIndex + 1, 4) & " B: " & currentBlock2(ListBox1.SelectedIndex + 1, 5) & " C: " & currentBlock2(ListBox1.SelectedIndex + 1, 6) & " D: " & currentBlock2(ListBox1.SelectedIndex + 1, 7) & ". " & Project.currentBlock1(144, 3) & " " & first & ", " & second & ", " & third & ", " & fourth
            Button6.Text = Project.currentBlock1(130, 3) 'Right Order
        Else
            Button7.Enabled = False
            Button8.Enabled = False
            Button9.Enabled = False
            Button10.Enabled = False
            Label2.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(ListBox1.SelectedIndex + 1, 4) & " B: " & currentBlock2(ListBox1.SelectedIndex + 1, 5) & " C: " & currentBlock2(ListBox1.SelectedIndex + 1, 6) & " D: " & currentBlock2(ListBox1.SelectedIndex + 1, 7) & ". " & Project.currentBlock1(143, 3) & " " & first
            Button6.Text = Project.currentBlock1(130, 4) 'What's Correct
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked = True Then
            CheckBox1.Checked = False
            CheckBox1.Enabled = False
        Else
            CheckBox1.Checked = True
            CheckBox1.Enabled = True
        End If
    End Sub

    Private Sub ListBox1_DoubleClick(sender As Object, e As EventArgs) Handles ListBox1.DoubleClick
        EditorFFF.Show()
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        'Open base file...
        OpenFileDialog1.FileName = "*.fff"
        OpenFileDialog1.InitialDirectory = CurDir() & "\Bases"
        OpenFileDialog1.CheckFileExists = True
        If OpenFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenFileDialog1.FileName
            Project.ini(14) = FileNameQ
            Call openfilesdata(FileNameQ)
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        'Open contestants list...
        OpenFileDialog2.FileName = "*.con"
        OpenFileDialog2.InitialDirectory = CurDir() & "\Bases"
        OpenFileDialog2.CheckFileExists = True
        If OpenFileDialog2.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project.ini(15) = OpenFileDialog2.FileName
            Dim currentField As String
            Dim currentRow As String()
            Dim i0 As Integer
            Dim i1 As Integer
            i1 = 0
            i0 = 0
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(OpenFileDialog2.FileName, System.Text.Encoding.Default)
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
                ReDim currentBlock3(i0, 5)
                For i2 = 0 To i0
                    For i1 = 0 To 5
                        currentBlock3(i2, i1) = currentBlock0(i2, i1)
                    Next
                Next
            End Using
            'Заполнение текстовых полей данными участников
            For x = 1 To i0
                Me.Controls("TextBox" & x).Text = currentBlock3(x, 3)
            Next
            For x = 11 To i0 + 10
                Me.Controls("TextBox" & x).Text = currentBlock3(x - 10, 4)
            Next
            For x = 21 To i0 + 20
                Me.Controls("TextBox" & x).Text = currentBlock3(x - 20, 5)
            Next
            For x = 1 To 10 - i0
                Me.Controls("TextBox" & 11 - x).Text = Nothing
                Me.Controls("TextBox" & 21 - x).Text = Nothing
                Me.Controls("TextBox" & 31 - x).Text = Nothing
            Next
            'Выравнивание по полям
            Dim x1 As Integer = 0
            ReDim currentBlock0(10, 3)
            ReDim currentBlock3(10, 3)
            For x = 1 To 10
                currentBlock0(x, 1) = Me.Controls("TextBox" & x).Text
            Next
            For x = 11 To 20
                currentBlock0(x - 10, 2) = Me.Controls("TextBox" & x).Text
            Next
            For x = 21 To 30
                currentBlock0(x - 20, 3) = Me.Controls("TextBox" & x).Text
            Next
            x1 = 1
            For x = 1 To 10
                If currentBlock0(x, 1) <> Nothing Then
                    currentBlock3(x1, 1) = ""
                    currentBlock3(x1, 2) = ""
                    currentBlock3(x1, 3) = ""
                    currentBlock3(x1, 1) = currentBlock0(x, 1)
                    currentBlock3(x1, 2) = currentBlock0(x, 2)
                    currentBlock3(x1, 3) = currentBlock0(x, 3)
                    x1 = x1 + 1
                End If
            Next
            'Заполнение текстовых полей данными участников
            Dim m As Integer = 0 'Кол-во пустых строк
            Dim n As Integer = 0 'Кол-во строк отступа
            For x = 1 To 10
                If Me.Controls("TextBox" & x).Text = Nothing Then m = m + 1
            Next
            n = Math.Floor(m / 2)
            For x = 1 To 10
                If x + n <= 10 Then
                    Me.Controls("TextBox" & x + n).Text = currentBlock3(x, 1)
                    Me.Controls("TextBox" & x + 10 + n).Text = currentBlock3(x, 2)
                    Me.Controls("TextBox" & x + 20 + n).Text = currentBlock3(x, 3)
                End If
            Next
            For x = 1 To n
                Me.Controls("TextBox" & x).Text = Nothing
                Me.Controls("TextBox" & x + 10).Text = Nothing
                Me.Controls("TextBox" & x + 20).Text = Nothing
            Next
        End If
    End Sub

    Public Sub TextBox1_LostFocus(sender As Object, e As EventArgs) Handles TextBox1.LostFocus, TextBox2.LostFocus, TextBox3.LostFocus, TextBox4.LostFocus, TextBox5.LostFocus, TextBox6.LostFocus, TextBox7.LostFocus, TextBox8.LostFocus, TextBox9.LostFocus, TextBox10.LostFocus
        'Выравнивание по полям
        Dim x1 As Integer = 0
        Dim currentRow(10)
        ReDim currentBlock0(10, 3)
        ReDim currentBlock3(10, 3)
        For x = 1 To 10
            currentBlock0(x, 1) = Me.Controls("TextBox" & x).Text
        Next
        For x = 11 To 20
            currentBlock0(x - 10, 2) = Me.Controls("TextBox" & x).Text
        Next
        For x = 21 To 30
            currentBlock0(x - 20, 3) = Me.Controls("TextBox" & x).Text
        Next
        x1 = 1
        For x = 1 To 10
            If currentBlock0(x, 1) <> Nothing Then
                currentBlock3(x1, 1) = ""
                currentBlock3(x1, 2) = ""
                currentBlock3(x1, 3) = ""
                currentBlock3(x1, 1) = currentBlock0(x, 1)
                currentBlock3(x1, 2) = currentBlock0(x, 2)
                currentBlock3(x1, 3) = currentBlock0(x, 3)
                x1 = x1 + 1
            End If
        Next
        'Заполнение текстовых полей данными участников
        Dim m As Integer = 0 'Кол-во пустых строк
        Dim n As Integer = 0 'Кол-во строк отступа
        For x = 1 To 10
            If Me.Controls("TextBox" & x).Text = Nothing Then m = m + 1
        Next
        n = Math.Floor(m / 2)
        For x = 1 To 10
            If x + n <= 10 Then
                Me.Controls("TextBox" & x + n).Text = currentBlock3(x, 1)
                Me.Controls("TextBox" & x + 10 + n).Text = currentBlock3(x, 2)
                Me.Controls("TextBox" & x + 20 + n).Text = currentBlock3(x, 3)
            End If
        Next
        For x = 1 To n
            Me.Controls("TextBox" & x).Text = Nothing
            Me.Controls("TextBox" & x + 10).Text = Nothing
            Me.Controls("TextBox" & x + 20).Text = Nothing
        Next
    End Sub

    Private Sub TextBox21_LostFocus(sender As Object, e As EventArgs) Handles TextBox21.LostFocus, TextBox22.LostFocus, TextBox23.LostFocus, TextBox24.LostFocus, TextBox25.LostFocus, TextBox26.LostFocus, TextBox27.LostFocus, TextBox28.LostFocus, TextBox29.LostFocus, TextBox30.LostFocus
        'My.Application.Culture.NumberFormat.NumberDecimalSeparator 32 39 44 46
        TextBox21.Text = TextBox21.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox21.Text = TextBox21.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox21.Text = TextBox21.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox21.Text = TextBox21.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox22.Text = TextBox22.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox22.Text = TextBox22.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox22.Text = TextBox22.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox22.Text = TextBox22.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox23.Text = TextBox23.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox23.Text = TextBox23.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox23.Text = TextBox23.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox23.Text = TextBox23.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox24.Text = TextBox24.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox24.Text = TextBox24.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox24.Text = TextBox24.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox24.Text = TextBox24.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox25.Text = TextBox25.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox25.Text = TextBox25.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox25.Text = TextBox25.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox25.Text = TextBox25.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox26.Text = TextBox26.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox26.Text = TextBox26.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox26.Text = TextBox26.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox26.Text = TextBox26.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox27.Text = TextBox27.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox27.Text = TextBox27.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox27.Text = TextBox27.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox27.Text = TextBox27.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox28.Text = TextBox28.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox28.Text = TextBox28.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox28.Text = TextBox28.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox28.Text = TextBox28.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox29.Text = TextBox29.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox29.Text = TextBox29.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox29.Text = TextBox29.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox29.Text = TextBox29.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox30.Text = TextBox30.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox30.Text = TextBox30.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox30.Text = TextBox30.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        TextBox30.Text = TextBox30.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Today's Names
        If Project.splashOn = False Then
            Project.Button16.PerformClick()
            Project.Button16.BackColor = Color.Green
            Project.splashOn = True
        End If
        Audience.PictureBox0.Visible = False
        orderDemo = False
        'Cкрытие таблицы результатов
        Audience.PictureBox21.Visible = False
        Audience.PictureBox22.Visible = False
        Audience.PictureBox23.Visible = False
        Audience.PictureBox24.Visible = False
        Audience.PictureBox25.Visible = False
        Audience.PictureBox26.Visible = False
        Audience.PictureBox27.Visible = False
        Audience.PictureBox28.Visible = False
        Audience.PictureBox29.Visible = False
        Audience.PictureBox30.Visible = False
        Audience.Label21.Visible = False
        Audience.Label22.Visible = False
        Audience.Label23.Visible = False
        Audience.Label24.Visible = False
        Audience.Label25.Visible = False
        Audience.Label26.Visible = False
        Audience.Label27.Visible = False
        Audience.Label28.Visible = False
        Audience.Label29.Visible = False
        Audience.Label30.Visible = False
        Audience.Label31.Visible = False
        Audience.Label32.Visible = False
        Audience.Label33.Visible = False
        Audience.Label34.Visible = False
        Audience.Label35.Visible = False
        Audience.Label36.Visible = False
        Audience.Label37.Visible = False
        Audience.Label38.Visible = False
        Audience.Label39.Visible = False
        Audience.Label40.Visible = False
        Audience.Label21.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label22.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label23.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label24.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label25.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label26.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label27.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label28.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label29.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label30.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label31.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label32.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label33.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label34.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label35.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label36.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label37.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label38.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label39.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label40.BackColor = Color.FromArgb(31, 31, 31)
        Button11.BackColor = Color.White
        '\Конец скрытия таблицы
        Audience.PictureBox0.Visible = False
        Audience.Label6.Visible = False
        Audience.Label7.Visible = False
        Audience.Label8.Visible = False
        Audience.Label9.Visible = False
        Audience.Label10.Visible = False
        Audience.Label11.Visible = False
        Audience.Label12.Visible = False
        Audience.Label16.Visible = False
        Audience.Label17.Visible = False
        Audience.Label18.Visible = False
        Audience.Label19.Visible = False
        Audience.Label20.Visible = False
        Audience.PictureBox1.Visible = False
        Audience.PictureBox2.Visible = False
        Audience.PictureBox3.Visible = False
        Audience.PictureBox4.Visible = False
        Audience.PictureBox5.Visible = False
        Audience.PictureBox8.Visible = False
        Timer5.Stop()
        Button5.BackColor = Color.White
        Timer5.Stop()
        Button5.BackColor = Color.White
        Audience.PictureBox16.Visible = False
        Audience.PictureBox17.Visible = False
        Audience.PictureBox18.Visible = False
        Audience.PictureBox19.Visible = False
        Timer4.Interval = 35000
        If TextBox5.Text <> Nothing Then
            If TextBox6.Text <> Nothing Then
                If TextBox4.Text <> Nothing Then
                    If TextBox7.Text <> Nothing Then
                        If TextBox3.Text <> Nothing Then
                            If TextBox8.Text <> Nothing Then
                                If TextBox2.Text <> Nothing Then
                                    If TextBox9.Text <> Nothing Then
                                        If TextBox1.Text <> Nothing Then
                                            If TextBox10.Text = Nothing Then
                                                Timer4.Interval = 26860
                                            End If
                                        Else
                                            Timer4.Interval = 23780
                                        End If
                                    Else
                                        Timer4.Interval = 20700
                                    End If
                                Else
                                    Timer4.Interval = 17620
                                End If
                            Else
                                Timer4.Interval = 14540
                            End If
                        Else
                            Timer4.Interval = 11460
                        End If
                    Else
                        Timer4.Interval = 8380
                    End If
                Else
                    Timer4.Interval = 5300
                End If
            Else
                Timer4.Interval = 2100
            End If
        End If
        If TimerTick <> 0 Then
            Button1.BackColor = Color.White
            My.Computer.Audio.Stop()
            Timer1.Stop()
            Timer4.Stop()
            TimerTick = 0
            Audience.Label6.Visible = False
            Audience.Label7.Visible = False
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        Else
            Button1.BackColor = Color.Aqua
            Timer1.Interval = 3200
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\AudienceFFF.png")
            My.Computer.Audio.Stop()
            Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Today's Names with ten.wav" & Chr(34)
            Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
            Project.winampOn = 1
            Timer1.Start()
            Timer4.Start()
            TimerTick = 1
            Select Case Timer4.Interval
                Case 23780, 20700
                    Audience.Label6.Text = TextBox2.Text
                    Audience.Label7.Text = TextBox12.Text
                Case 17620, 14540
                    Audience.Label6.Text = TextBox3.Text
                    Audience.Label7.Text = TextBox13.Text
                Case 11460, 8380
                    Audience.Label6.Text = TextBox4.Text
                    Audience.Label7.Text = TextBox14.Text
                Case 5300, 2100
                    Audience.Label6.Text = TextBox5.Text
                    Audience.Label7.Text = TextBox15.Text
                Case Else
                    Audience.Label6.Text = TextBox1.Text
                    Audience.Label7.Text = TextBox11.Text
            End Select
            Audience.Label6.Visible = True
            Audience.Label7.Visible = True
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Переключение имён каждые 3 секунды
        If TimerTick < 10 Then
            TimerTick = TimerTick + 1
            Select Case TimerTick
                Case 1
                    Select Case Timer4.Interval
                        Case 23780, 20700
                            Audience.Label6.Text = TextBox2.Text
                            Audience.Label7.Text = TextBox12.Text
                        Case 17620, 14540
                            Audience.Label6.Text = TextBox3.Text
                            Audience.Label7.Text = TextBox13.Text
                        Case 11460, 8380
                            Audience.Label6.Text = TextBox4.Text
                            Audience.Label7.Text = TextBox14.Text
                        Case 5300, 2100
                            Audience.Label6.Text = TextBox5.Text
                            Audience.Label7.Text = TextBox15.Text
                        Case Else
                            Audience.Label6.Text = TextBox1.Text
                            Audience.Label7.Text = TextBox11.Text
                    End Select
                Case 2
                    Timer1.Interval = 3080
                    Select Case Timer4.Interval
                        Case 23780, 20700
                            Audience.Label6.Text = TextBox3.Text
                            Audience.Label7.Text = TextBox13.Text
                        Case 17620, 14540
                            Audience.Label6.Text = TextBox4.Text
                            Audience.Label7.Text = TextBox14.Text
                        Case 11460, 8380
                            Audience.Label6.Text = TextBox5.Text
                            Audience.Label7.Text = TextBox15.Text
                        Case 5300
                            Audience.Label6.Text = TextBox6.Text
                            Audience.Label7.Text = TextBox16.Text
                        Case Else
                            Audience.Label6.Text = TextBox2.Text
                            Audience.Label7.Text = TextBox12.Text
                    End Select
                Case 3
                    Select Case Timer4.Interval
                        Case 23780, 20700
                            Audience.Label6.Text = TextBox4.Text
                            Audience.Label7.Text = TextBox14.Text
                        Case 17620, 14540
                            Audience.Label6.Text = TextBox5.Text
                            Audience.Label7.Text = TextBox15.Text
                        Case 11460, 8380
                            Audience.Label6.Text = TextBox6.Text
                            Audience.Label7.Text = TextBox16.Text
                        Case Else
                            Audience.Label6.Text = TextBox3.Text
                            Audience.Label7.Text = TextBox13.Text
                    End Select
                Case 4
                    Select Case Timer4.Interval
                        Case 23780, 20700
                            Audience.Label6.Text = TextBox5.Text
                            Audience.Label7.Text = TextBox15.Text
                        Case 17620, 14540
                            Audience.Label6.Text = TextBox6.Text
                            Audience.Label7.Text = TextBox16.Text
                        Case 11460
                            Audience.Label6.Text = TextBox7.Text
                            Audience.Label7.Text = TextBox17.Text
                        Case Else
                            Audience.Label6.Text = TextBox4.Text
                            Audience.Label7.Text = TextBox14.Text
                    End Select
                Case 5
                    Select Case Timer4.Interval
                        Case 23780, 20700
                            Audience.Label6.Text = TextBox6.Text
                            Audience.Label7.Text = TextBox16.Text
                        Case 17620, 14540
                            Audience.Label6.Text = TextBox7.Text
                            Audience.Label7.Text = TextBox17.Text
                        Case Else
                            Audience.Label6.Text = TextBox5.Text
                            Audience.Label7.Text = TextBox15.Text
                    End Select
                Case 6
                    Select Case Timer4.Interval
                        Case 23780, 20700
                            Audience.Label6.Text = TextBox7.Text
                            Audience.Label7.Text = TextBox17.Text
                        Case 17620
                            Audience.Label6.Text = TextBox8.Text
                            Audience.Label7.Text = TextBox18.Text
                        Case Else
                            Audience.Label6.Text = TextBox6.Text
                            Audience.Label7.Text = TextBox16.Text
                    End Select
                Case 7
                    Select Case Timer4.Interval
                        Case 23780, 20700
                            Audience.Label6.Text = TextBox8.Text
                            Audience.Label7.Text = TextBox18.Text
                        Case Else
                            Audience.Label6.Text = TextBox7.Text
                            Audience.Label7.Text = TextBox17.Text
                    End Select
                Case 8
                    Select Case Timer4.Interval
                        Case 23780
                            Audience.Label6.Text = TextBox9.Text
                            Audience.Label7.Text = TextBox19.Text
                        Case Else
                            Audience.Label6.Text = TextBox8.Text
                            Audience.Label7.Text = TextBox18.Text
                    End Select
                Case 9
                    Audience.Label6.Text = TextBox9.Text
                    Audience.Label7.Text = TextBox19.Text
                Case 10
                    Audience.Label6.Text = TextBox10.Text
                    Audience.Label7.Text = TextBox20.Text
            End Select
        Else
            Timer1.Stop()
            Timer4.Stop()
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
            Audience.Label6.Visible = False
            Audience.Label7.Visible = False
            Button1.BackColor = Color.White
            Project.winampOn = 0
            TimerTick = 0
        End If
    End Sub

    Private Sub Timer4_Tick(sender As Object, e As EventArgs) Handles Timer4.Tick
        Timer1.Stop()
        Timer4.Stop()
        My.Computer.Audio.Play("source\MUSIC\Today's Names end.wav")
        Shell("source\BAT\stop_back_music1.bat")
        Project.winampOn = 0
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
        Audience.Label6.Visible = False
        Audience.Label7.Visible = False
        Button1.BackColor = Color.White
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Explain the rules
        If Button1.BackColor = Color.Aqua Then
            Timer1.Stop()
            TimerTick = 0
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
            Audience.Label6.Visible = False
            Audience.Label7.Visible = False
            Button1.BackColor = Color.White
        End If
        Audience.Label8.Visible = False
        Audience.Label9.Visible = False
        Audience.Label10.Visible = False
        Audience.Label11.Visible = False
        Audience.Label12.Visible = False
        Audience.PictureBox16.Visible = False
        Audience.PictureBox17.Visible = False
        Audience.PictureBox18.Visible = False
        Audience.PictureBox19.Visible = False
        My.Computer.Audio.Play("source\MUSIC\Explain the games.wav")
        rules = True
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        'Ask question
        If Project.splashOn = False Then
            Project.Button16.PerformClick()
            Project.Button16.BackColor = Color.Green
            Project.splashOn = True
        End If
        Audience.PictureBox0.Visible = False
        orderDemo = False
        Button12.Enabled = True
        Audience.PictureBox8.Visible = False
        Timer5.Stop()
        Button5.BackColor = Color.White
        Project.Button24.PerformClick()
        'Cкрытие таблицы результатов
        Audience.PictureBox21.Visible = False
        Audience.PictureBox22.Visible = False
        Audience.PictureBox23.Visible = False
        Audience.PictureBox24.Visible = False
        Audience.PictureBox25.Visible = False
        Audience.PictureBox26.Visible = False
        Audience.PictureBox27.Visible = False
        Audience.PictureBox28.Visible = False
        Audience.PictureBox29.Visible = False
        Audience.PictureBox30.Visible = False
        Audience.Label21.Visible = False
        Audience.Label22.Visible = False
        Audience.Label23.Visible = False
        Audience.Label24.Visible = False
        Audience.Label25.Visible = False
        Audience.Label26.Visible = False
        Audience.Label27.Visible = False
        Audience.Label28.Visible = False
        Audience.Label29.Visible = False
        Audience.Label30.Visible = False
        Audience.Label31.Visible = False
        Audience.Label32.Visible = False
        Audience.Label33.Visible = False
        Audience.Label34.Visible = False
        Audience.Label35.Visible = False
        Audience.Label36.Visible = False
        Audience.Label37.Visible = False
        Audience.Label38.Visible = False
        Audience.Label39.Visible = False
        Audience.Label40.Visible = False
        Audience.Label21.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label22.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label23.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label24.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label25.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label26.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label27.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label28.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label29.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label30.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label31.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label32.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label33.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label34.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label35.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label36.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label37.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label38.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label39.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label40.BackColor = Color.FromArgb(31, 31, 31)
        Button11.BackColor = Color.White
        '\Конец скрытия таблицы
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
        Button1.BackColor = Color.White
        Timer1.Stop()
        Timer4.Stop()
        TimerTick = 0
        Audience.Label6.Visible = False
        Audience.Label7.Visible = False
        Audience.Label8.Visible = False
        Audience.Label9.Visible = False
        Audience.Label10.Visible = False
        Audience.Label11.Visible = False
        Audience.Label12.Visible = False
        Audience.PictureBox16.Visible = False
        Audience.PictureBox17.Visible = False
        Audience.PictureBox18.Visible = False
        Audience.PictureBox19.Visible = False
        My.Computer.Audio.Stop()
        If rules = True Then
            My.Computer.Audio.Play("source\MUSIC\Explain the games end.wav")
            rules = False
        End If
        Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Standby for Q.wav" & Chr(34)
        Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
        Project.winampOn = 1
        Project.Label16.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3)
        Button1.BackColor = Color.White
        Timer1.Stop()
        Timer4.Stop()
        TimerTick = 0
        Audience.Label6.Visible = False
        Audience.Label7.Visible = False
        Audience.Label16.Visible = True
        Audience.Label17.Visible = False
        Audience.Label18.Visible = False
        Audience.Label19.Visible = False
        Audience.Label20.Visible = False
        Project.PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LEFT.png")
        Project.PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\RIGHT.png")
        Project.PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LEFT.png")
        Project.PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\RIGHT.png")
        Project.Label17.BackColor = Color.FromArgb(42, 42, 42)
        Project.Label17.ForeColor = Color.White
        Project.Label18.BackColor = Color.FromArgb(42, 42, 42)
        Project.Label18.ForeColor = Color.White
        Project.Label19.BackColor = Color.FromArgb(42, 42, 42)
        Project.Label19.ForeColor = Color.White
        Project.Label20.BackColor = Color.FromArgb(42, 42, 42)
        Project.Label20.ForeColor = Color.White
        Audience.PictureBox1.Visible = True
        Audience.PictureBox2.Visible = True
        Audience.PictureBox3.Visible = True
        Audience.PictureBox4.Visible = True
        Audience.PictureBox5.Visible = True
        Button3.BackColor = Color.White
        Timer5.Stop()
        Button5.BackColor = Color.White
        Button11.BackColor = Color.White
        Button12.BackColor = Color.White
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        'Three beeps
        Shell("source\BAT\stop_back_music1.bat")
        Project.winampOn = 0
        My.Computer.Audio.Play("source\MUSIC\Three Beeps.wav")
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        'Start timer
        Select Case Button5.BackColor
            Case Color.White
                Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
                Button1.BackColor = Color.White
                Timer1.Stop()
                Timer4.Stop()
                TimerTick = 0
                Audience.Label6.Visible = False
                Audience.Label7.Visible = False
                Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Fastest finger first.wav" & Chr(34)
                Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
                Project.winampOn = 1
                Project.Label16.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3)
                Project.Label17.Text = currentBlock2(ListBox1.SelectedIndex + 1, 4)
                Project.Label18.Text = currentBlock2(ListBox1.SelectedIndex + 1, 5)
                Project.Label19.Text = currentBlock2(ListBox1.SelectedIndex + 1, 6)
                Project.Label20.Text = currentBlock2(ListBox1.SelectedIndex + 1, 7)
                Project.PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\A_BLACK.png")
                Project.PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\B_BLACK.png")
                Project.PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\C_BLACK.png")
                Project.PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\D_BLACK.png")
                Audience.Label16.Visible = True
                Audience.Label17.Visible = True
                Audience.Label18.Visible = True
                Audience.Label19.Visible = True
                Audience.Label20.Visible = True
                Audience.PictureBox1.Visible = True
                Audience.PictureBox2.Visible = True
                Audience.PictureBox3.Visible = True
                Audience.PictureBox4.Visible = True
                Audience.PictureBox5.Visible = True
                Button5.BackColor = Color.Green
                Audience.PictureBox8.Visible = True
                Timer5.Start()
                clockFrame = 21
                Audience.PictureBox8.ImageLocation = "source\CLOCK\Clock (21).png"
                'Cкрытие таблицы результатов
                Audience.PictureBox21.Visible = False
                Audience.PictureBox22.Visible = False
                Audience.PictureBox23.Visible = False
                Audience.PictureBox24.Visible = False
                Audience.PictureBox25.Visible = False
                Audience.PictureBox26.Visible = False
                Audience.PictureBox27.Visible = False
                Audience.PictureBox28.Visible = False
                Audience.PictureBox29.Visible = False
                Audience.PictureBox30.Visible = False
                Audience.Label21.Visible = False
                Audience.Label22.Visible = False
                Audience.Label23.Visible = False
                Audience.Label24.Visible = False
                Audience.Label25.Visible = False
                Audience.Label26.Visible = False
                Audience.Label27.Visible = False
                Audience.Label28.Visible = False
                Audience.Label29.Visible = False
                Audience.Label30.Visible = False
                Audience.Label31.Visible = False
                Audience.Label32.Visible = False
                Audience.Label33.Visible = False
                Audience.Label34.Visible = False
                Audience.Label35.Visible = False
                Audience.Label36.Visible = False
                Audience.Label37.Visible = False
                Audience.Label38.Visible = False
                Audience.Label39.Visible = False
                Audience.Label40.Visible = False
                Audience.Label21.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label22.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label23.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label24.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label25.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label26.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label27.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label28.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label29.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label30.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label31.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label32.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label33.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label34.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label35.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label36.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label37.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label38.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label39.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label40.BackColor = Color.FromArgb(31, 31, 31)
                Button11.BackColor = Color.White
                '\Конец скрытия таблицы
            Case Color.Green
                My.Computer.Audio.Play("source\MUSIC\Fastest finger first end.wav")
                Shell("source\BAT\stop_back_music1.bat")
                Project.winampOn = 0
                Audience.PictureBox8.ImageLocation = "source\CLOCK\Clock (62).png"
                Timer5.Stop()
                Button5.BackColor = Color.White
        End Select
    End Sub

    Private Sub Timer5_Tick(sender As Object, e As EventArgs) Handles Timer5.Tick
        clockFrame = clockFrame + 1
        Audience.PictureBox8.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        If clockFrame = 61 Then
            Timer5.Stop()
            Audience.PictureBox8.ImageLocation = "source\CLOCK\Clock (61).png"
            Project.winampOn = 0
            Button5.BackColor = Color.White
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        'Right order
        Audience.PictureBox8.Visible = False
        Timer5.Stop()
        Button5.BackColor = Color.White
        'Cкрытие таблицы результатов
        Audience.PictureBox21.Visible = False
        Audience.PictureBox22.Visible = False
        Audience.PictureBox23.Visible = False
        Audience.PictureBox24.Visible = False
        Audience.PictureBox25.Visible = False
        Audience.PictureBox26.Visible = False
        Audience.PictureBox27.Visible = False
        Audience.PictureBox28.Visible = False
        Audience.PictureBox29.Visible = False
        Audience.PictureBox30.Visible = False
        Audience.Label21.Visible = False
        Audience.Label22.Visible = False
        Audience.Label23.Visible = False
        Audience.Label24.Visible = False
        Audience.Label25.Visible = False
        Audience.Label26.Visible = False
        Audience.Label27.Visible = False
        Audience.Label28.Visible = False
        Audience.Label29.Visible = False
        Audience.Label30.Visible = False
        Audience.Label31.Visible = False
        Audience.Label32.Visible = False
        Audience.Label33.Visible = False
        Audience.Label34.Visible = False
        Audience.Label35.Visible = False
        Audience.Label36.Visible = False
        Audience.Label37.Visible = False
        Audience.Label38.Visible = False
        Audience.Label39.Visible = False
        Audience.Label40.Visible = False
        Audience.Label21.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label22.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label23.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label24.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label25.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label26.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label27.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label28.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label29.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label30.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label31.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label32.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label33.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label34.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label35.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label36.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label37.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label38.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label39.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label40.BackColor = Color.FromArgb(31, 31, 31)
        Button11.BackColor = Color.White
        '\Конец скрытия таблицы
        If fourth <> 0 Then
            Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\What's the Order.wav" & Chr(34)
            Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
            Project.winampOn = 1
            Audience.Label16.Visible = False
            Audience.Label17.Visible = False
            Audience.Label18.Visible = False
            Audience.Label19.Visible = False
            Audience.Label20.Visible = False
            Audience.PictureBox1.Visible = False
            Audience.PictureBox2.Visible = False
            Audience.PictureBox3.Visible = False
            Audience.PictureBox4.Visible = False
            Audience.PictureBox5.Visible = False
            Button1.BackColor = Color.White
            Timer1.Stop()
            Timer4.Stop()
            TimerTick = 0
            Audience.PictureBox6.Visible = False
            Audience.PictureBox7.Visible = False
            Audience.PictureBox16.Visible = False
            Audience.PictureBox17.Visible = False
            Audience.PictureBox18.Visible = False
            Audience.PictureBox19.Visible = False
            Audience.Label9.Visible = False
            Audience.Label10.Visible = False
            Audience.Label11.Visible = False
            Audience.Label12.Visible = False
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\AudienceFFF2.png")
            Audience.Label8.Text = currentBlock2(ListBox1.SelectedIndex + 1, 3)
            Audience.Label8.Visible = True
            orderDemo = True
        Else
            Project.PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\A_BLACK.png")
            Project.PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\B_BLACK.png")
            Project.PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\C_BLACK.png")
            Project.PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\D_BLACK.png")
            Project.Label17.BackColor = Color.FromArgb(42, 42, 42)
            Project.Label17.ForeColor = Color.White
            Project.Label18.BackColor = Color.FromArgb(42, 42, 42)
            Project.Label18.ForeColor = Color.White
            Project.Label19.BackColor = Color.FromArgb(42, 42, 42)
            Project.Label19.ForeColor = Color.White
            Project.Label20.BackColor = Color.FromArgb(42, 42, 42)
            Project.Label20.ForeColor = Color.White
            Select Case first
                Case 1
                    Project.PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\A_GREEN.png")
                    Project.Label17.BackColor = Color.FromArgb(93, 179, 87)
                    Project.Label17.ForeColor = Color.Black
                Case 2
                    Project.PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\B_GREEN.png")
                    Project.Label18.BackColor = Color.FromArgb(93, 179, 87)
                    Project.Label18.ForeColor = Color.Black
                Case 3
                    Project.PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\C_GREEN.png")
                    Project.Label19.BackColor = Color.FromArgb(93, 179, 87)
                    Project.Label19.ForeColor = Color.Black
                Case 4
                    Project.PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\D_GREEN.png")
                    Project.Label20.BackColor = Color.FromArgb(93, 179, 87)
                    Project.Label20.ForeColor = Color.Black
            End Select
            If Project.winampOn <> 0 Then
                Shell("source\BAT\stop_back_music1.bat")
                Project.winampOn = 0
            End If
            My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        '1st answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\1st in Order.wav")
            Audience.PictureBox16.Visible = True
            Audience.Label9.Visible = True
            Select Case first
                Case 1
                    Audience.PictureBox16.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_A.png")
                    Audience.Label9.Text = currentBlock2(ListBox1.SelectedIndex + 1, 4)
                Case 2
                    Audience.PictureBox16.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_B.png")
                    Audience.Label9.Text = currentBlock2(ListBox1.SelectedIndex + 1, 5)
                Case 3
                    Audience.PictureBox16.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_C.png")
                    Audience.Label9.Text = currentBlock2(ListBox1.SelectedIndex + 1, 6)
                Case 4
                    Audience.PictureBox16.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_D.png")
                    Audience.Label9.Text = currentBlock2(ListBox1.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        '2nd answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\2nd in Order.wav")
            Audience.PictureBox17.Visible = True
            Audience.Label10.Visible = True
            Select Case second
                Case 1
                    Audience.PictureBox17.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_A.png")
                    Audience.Label10.Text = currentBlock2(ListBox1.SelectedIndex + 1, 4)
                Case 2
                    Audience.PictureBox17.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_B.png")
                    Audience.Label10.Text = currentBlock2(ListBox1.SelectedIndex + 1, 5)
                Case 3
                    Audience.PictureBox17.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_C.png")
                    Audience.Label10.Text = currentBlock2(ListBox1.SelectedIndex + 1, 6)
                Case 4
                    Audience.PictureBox17.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_D.png")
                    Audience.Label10.Text = currentBlock2(ListBox1.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        '3rd answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\3rd in Order.wav")
            Audience.PictureBox18.Visible = True
            Audience.Label11.Visible = True
            Select Case third
                Case 1
                    Audience.PictureBox18.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_A.png")
                    Audience.Label11.Text = currentBlock2(ListBox1.SelectedIndex + 1, 4)
                Case 2
                    Audience.PictureBox18.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_B.png")
                    Audience.Label11.Text = currentBlock2(ListBox1.SelectedIndex + 1, 5)
                Case 3
                    Audience.PictureBox18.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_C.png")
                    Audience.Label11.Text = currentBlock2(ListBox1.SelectedIndex + 1, 6)
                Case 4
                    Audience.PictureBox18.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_D.png")
                    Audience.Label11.Text = currentBlock2(ListBox1.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        '4th answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\4th in Order.wav")
            Audience.PictureBox19.Visible = True
            Audience.Label12.Visible = True
            Select Case fourth
                Case 1
                    Audience.PictureBox19.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_A.png")
                    Audience.Label12.Text = currentBlock2(ListBox1.SelectedIndex + 1, 4)
                Case 2
                    Audience.PictureBox19.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_B.png")
                    Audience.Label12.Text = currentBlock2(ListBox1.SelectedIndex + 1, 5)
                Case 3
                    Audience.PictureBox19.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_C.png")
                    Audience.Label12.Text = currentBlock2(ListBox1.SelectedIndex + 1, 6)
                Case 4
                    Audience.PictureBox19.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_D.png")
                    Audience.Label12.Text = currentBlock2(ListBox1.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        'Show the correct answered contestants
        orderDemo = False
        winTime = 20.0
        If TextBox25.Text = Nothing Then TextBox25.Text = "0"
        If TextBox26.Text = Nothing Then TextBox26.Text = "0"
        If TextBox24.Text = Nothing Then TextBox24.Text = "0"
        If TextBox27.Text = Nothing Then TextBox27.Text = "0"
        If TextBox23.Text = Nothing Then TextBox23.Text = "0"
        If TextBox28.Text = Nothing Then TextBox28.Text = "0"
        If TextBox22.Text = Nothing Then TextBox22.Text = "0"
        If TextBox29.Text = Nothing Then TextBox29.Text = "0"
        If TextBox21.Text = Nothing Then TextBox21.Text = "0"
        If TextBox30.Text = Nothing Then TextBox30.Text = "0"
        Select Case Button11.BackColor
            Case Color.White 'Показ таблицы
                Button11.BackColor = Color.Gold
                Audience.PictureBox1.Visible = False
                Audience.PictureBox2.Visible = False
                Audience.PictureBox3.Visible = False
                Audience.PictureBox4.Visible = False
                Audience.PictureBox5.Visible = False
                Audience.Label16.Visible = False
                Audience.Label17.Visible = False
                Audience.Label18.Visible = False
                Audience.Label19.Visible = False
                Audience.Label20.Visible = False
                Button1.BackColor = Color.White
                Timer1.Stop()
                Timer4.Stop()
                TimerTick = 0
                Audience.Label6.Visible = False
                Audience.Label7.Visible = False
                Audience.Label6.Visible = False
                Audience.Label7.Visible = False
                Audience.Label8.Visible = False
                Audience.Label9.Visible = False
                Audience.Label10.Visible = False
                Audience.Label11.Visible = False
                Audience.Label12.Visible = False
                Audience.PictureBox16.Visible = False
                Audience.PictureBox17.Visible = False
                Audience.PictureBox18.Visible = False
                Audience.PictureBox19.Visible = False
                Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\bg.jpg")
                Audience.Label21.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label22.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label23.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label24.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label25.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label26.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label27.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label28.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label29.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label30.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label31.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label32.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label33.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label34.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label35.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label36.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label37.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label38.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label39.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label40.BackColor = Color.FromArgb(31, 31, 31)
                Audience.PictureBox30.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label40.Text = Nothing
                'Отбор имён
                If TextBox5.Text <> Nothing Then
                    Audience.PictureBox21.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox21.Visible = True
                    Audience.Label21.Visible = True
                    Audience.Label21.Text = TextBox5.Text
                    Audience.Label31.Text = TextBox25.Text
                End If
                If TextBox6.Text <> Nothing Then
                    Audience.PictureBox22.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox22.Visible = True
                    Audience.Label22.Visible = True
                    Audience.Label22.Text = TextBox6.Text
                    Audience.Label32.Text = TextBox26.Text
                End If
                If TextBox4.Text <> Nothing Then
                    Audience.PictureBox23.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox23.Visible = True
                    Audience.Label23.Visible = True
                    Audience.Label23.Text = TextBox4.Text
                    Audience.Label33.Text = TextBox24.Text
                End If
                If TextBox7.Text <> Nothing Then
                    Audience.PictureBox24.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox24.Visible = True
                    Audience.Label24.Visible = True
                    Audience.Label24.Text = TextBox7.Text
                    Audience.Label34.Text = TextBox27.Text
                End If
                If TextBox3.Text <> Nothing Then
                    Audience.PictureBox25.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox25.Visible = True
                    Audience.Label25.Visible = True
                    Audience.Label25.Text = TextBox3.Text
                    Audience.Label35.Text = TextBox23.Text
                End If
                If TextBox8.Text <> Nothing Then
                    Audience.PictureBox26.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox26.Visible = True
                    Audience.Label26.Visible = True
                    Audience.Label26.Text = TextBox8.Text
                    Audience.Label36.Text = TextBox28.Text
                End If
                If TextBox2.Text <> Nothing Then
                    Audience.PictureBox27.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox27.Visible = True
                    Audience.Label27.Visible = True
                    Audience.Label27.Text = TextBox2.Text
                    Audience.Label37.Text = TextBox22.Text
                End If
                If TextBox9.Text <> Nothing Then
                    Audience.PictureBox28.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox28.Visible = True
                    Audience.Label28.Visible = True
                    Audience.Label28.Text = TextBox9.Text
                    Audience.Label38.Text = TextBox29.Text
                End If
                If TextBox1.Text <> Nothing Then
                    Audience.PictureBox29.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox29.Visible = True
                    Audience.Label29.Visible = True
                    Audience.Label29.Text = TextBox1.Text
                    Audience.Label39.Text = TextBox21.Text
                End If
                If TextBox10.Text <> Nothing Then
                    Audience.PictureBox30.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.PictureBox30.Visible = True
                    Audience.Label30.Visible = True
                    Audience.Label30.Text = TextBox10.Text
                    Audience.Label40.Text = TextBox30.Text
                End If
            Case Color.Gold 'Показ результатов
                Button11.BackColor = Color.Green
                If TextBox25.Text = 0 And TextBox26.Text = 0 And TextBox24.Text = 0 And TextBox27.Text = 0 And TextBox23.Text = 0 And TextBox28.Text = 0 And TextBox22.Text = 0 And TextBox29.Text = 0 And TextBox21.Text = 0 And TextBox30.Text = 0 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Whoosh.wav" & Chr(34)
                    Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
                    Button12.Enabled = False
                    Button3.BackColor = Color.Gold
                Else
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Correct Answers.wav" & Chr(34)
                    Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
                    Timer2tick = 0
                    Timer2.Start()
                    Button12.BackColor = Color.Gold
                End If
            Case Color.Green
                'Cкрытие таблицы результатов
                Audience.PictureBox21.Visible = False
                Audience.PictureBox22.Visible = False
                Audience.PictureBox23.Visible = False
                Audience.PictureBox24.Visible = False
                Audience.PictureBox25.Visible = False
                Audience.PictureBox26.Visible = False
                Audience.PictureBox27.Visible = False
                Audience.PictureBox28.Visible = False
                Audience.PictureBox29.Visible = False
                Audience.PictureBox30.Visible = False
                Audience.Label21.Visible = False
                Audience.Label22.Visible = False
                Audience.Label23.Visible = False
                Audience.Label24.Visible = False
                Audience.Label25.Visible = False
                Audience.Label26.Visible = False
                Audience.Label27.Visible = False
                Audience.Label28.Visible = False
                Audience.Label29.Visible = False
                Audience.Label30.Visible = False
                Audience.Label31.Visible = False
                Audience.Label32.Visible = False
                Audience.Label33.Visible = False
                Audience.Label34.Visible = False
                Audience.Label35.Visible = False
                Audience.Label36.Visible = False
                Audience.Label37.Visible = False
                Audience.Label38.Visible = False
                Audience.Label39.Visible = False
                Audience.Label40.Visible = False
                Button11.BackColor = Color.White
        End Select
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'Таймер показа результатов
        Timer2tick = Timer2tick + 1
        Select Case Timer2tick
            Case 1
                If TextBox30.Text <> "0" Then
                    Audience.PictureBox30.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label30.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label40.BackColor = Color.FromArgb(96, 182, 90)
                    time1 = TextBox30.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time1 < winTime Then
                            winTime = time1
                        End If
                    Else 'Два победителя
                        If time1 < winTime2 Then
                            If time1 < winTime Then
                                winTime2 = winTime
                                winTime = time1
                            Else
                                winTime2 = time1
                            End If
                        End If
                    End If
                    Audience.Label40.Text = TextBox30.Text
                    Audience.Label40.Visible = True
                End If
            Case 2
                If TextBox29.Text <> "0" Then
                    Audience.PictureBox28.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label28.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label38.BackColor = Color.FromArgb(96, 182, 90)
                    time2 = TextBox29.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time2 < winTime Then
                            winTime = time2
                        End If
                    Else 'Два победителя
                        If time2 < winTime2 Then
                            If time2 < winTime Then
                                winTime2 = winTime
                                winTime = time2
                            Else
                                winTime2 = time2
                            End If
                        End If
                    End If
                    Audience.Label38.Text = TextBox29.Text
                    Audience.Label38.Visible = True
                End If
            Case 3
                If TextBox28.Text <> "0" Then
                    Audience.PictureBox26.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label26.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label36.BackColor = Color.FromArgb(96, 182, 90)
                    time3 = TextBox28.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time3 < winTime Then
                            winTime = time3
                        End If
                    Else 'Два победителя
                        If time3 < winTime2 Then
                            If time3 < winTime Then
                                winTime2 = winTime
                                winTime = time3
                            Else
                                winTime2 = time3
                            End If
                        End If
                    End If
                    Audience.Label36.Text = TextBox28.Text
                    Audience.Label36.Visible = True
                End If
            Case 4
                If TextBox27.Text <> "0" Then
                    Audience.PictureBox24.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label24.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label34.BackColor = Color.FromArgb(96, 182, 90)
                    time4 = TextBox27.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time4 < winTime Then
                            winTime = time4
                        End If
                    Else 'Два победителя
                        If time4 < winTime2 Then
                            If time4 < winTime Then
                                winTime2 = winTime
                                winTime = time4
                            Else
                                winTime2 = time4
                            End If
                        End If
                    End If
                    Audience.Label34.Text = TextBox27.Text
                    Audience.Label34.Visible = True
                End If
            Case 5
                If TextBox26.Text <> "0" Then
                    Audience.PictureBox22.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label22.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label32.BackColor = Color.FromArgb(96, 182, 90)
                    time5 = TextBox26.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time5 < winTime Then
                            winTime = time5
                        End If
                    Else 'Два победителя
                        If time5 < winTime2 Then
                            If time5 < winTime Then
                                winTime2 = winTime
                                winTime = time5
                            Else
                                winTime2 = time5
                            End If
                        End If
                    End If
                    Audience.Label32.Text = TextBox26.Text
                    Audience.Label32.Visible = True
                End If
            Case 6
                If TextBox25.Text <> "0" Then
                    Audience.PictureBox21.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label21.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label31.BackColor = Color.FromArgb(96, 182, 90)
                    time6 = TextBox25.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time6 < winTime Then
                            winTime = time6
                        End If
                    Else 'Два победителя
                        If time6 < winTime2 Then
                            If time6 < winTime Then
                                winTime2 = winTime
                                winTime = time6
                            Else
                                winTime2 = time6
                            End If
                        End If
                    End If
                    Audience.Label31.Text = TextBox25.Text
                    Audience.Label31.Visible = True
                End If
            Case 7
                If TextBox24.Text <> "0" Then
                    Audience.PictureBox23.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label23.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label33.BackColor = Color.FromArgb(96, 182, 90)
                    time7 = TextBox24.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time7 < winTime Then
                            winTime = time7
                        End If
                    Else 'Два победителя
                        If time7 < winTime2 Then
                            If time7 < winTime Then
                                winTime2 = winTime
                                winTime = time7
                            Else
                                winTime2 = time7
                            End If
                        End If
                    End If
                    Audience.Label33.Text = TextBox24.Text
                    Audience.Label33.Visible = True
                End If
            Case 8
                If TextBox23.Text <> "0" Then
                    Audience.PictureBox25.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label25.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label35.BackColor = Color.FromArgb(96, 182, 90)
                    time8 = TextBox23.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time8 < winTime Then
                            winTime = time8
                        End If
                    Else 'Два победителя
                        If time8 < winTime2 Then
                            If time8 < winTime Then
                                winTime2 = winTime
                                winTime = time8
                            Else
                                winTime2 = time8
                            End If
                        End If
                    End If
                    Audience.Label35.Text = TextBox23.Text
                    Audience.Label35.Visible = True
                End If
            Case 9
                If TextBox22.Text <> "0" Then
                    Audience.PictureBox27.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label27.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label37.BackColor = Color.FromArgb(96, 182, 90)
                    time9 = TextBox22.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time9 < winTime Then
                            winTime = time9
                        End If
                    Else 'Два победителя
                        If time9 < winTime2 Then
                            If time9 < winTime Then
                                winTime2 = winTime
                                winTime = time9
                            Else
                                winTime2 = time9
                            End If
                        End If
                    End If
                    Audience.Label37.Text = TextBox22.Text
                    Audience.Label37.Visible = True
                End If
            Case 10
                If TextBox21.Text <> "0" Then
                    Audience.PictureBox29.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.Label29.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.Label39.BackColor = Color.FromArgb(96, 182, 90)
                    time10 = TextBox21.Text
                    If CheckBox2.Checked = False Then 'Один победитель
                        If time10 < winTime Then
                            winTime = time10
                        End If
                    Else 'Два победителя
                        If time10 < winTime2 Then
                            If time10 < winTime Then
                                winTime2 = winTime
                                winTime = time10
                            Else
                                winTime2 = time10
                            End If
                        End If
                    End If
                    Audience.Label39.Text = TextBox21.Text
                    Audience.Label39.Visible = True
                End If
                    Timer2.Stop()
                    Timer3.Start()
        End Select
    End Sub

    Private Sub Timer3_Tick(sender As Object, e As EventArgs) Handles Timer3.Tick
        'Выявление победителя
        If winLine = False Then
            If time6 = winTime Or time6 = winTime2 Then
                Audience.PictureBox21.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label21.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label31.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time5 = winTime Or time5 = winTime2 Then
                Audience.PictureBox22.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label22.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label32.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time7 = winTime Or time7 = winTime2 Then
                Audience.PictureBox23.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label23.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label33.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time4 = winTime Or time4 = winTime2 Then
                Audience.PictureBox24.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label24.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label34.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time8 = winTime Or time8 = winTime2 Then
                Audience.PictureBox25.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label25.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label35.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time3 = winTime Or time3 = winTime2 Then
                Audience.PictureBox26.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label26.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label36.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time9 = winTime Or time9 = winTime2 Then
                Audience.PictureBox27.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label27.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label37.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time2 = winTime Or time2 = winTime2 Then
                Audience.PictureBox28.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label28.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label38.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time10 = winTime Or time10 = winTime2 Then
                Audience.PictureBox29.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label29.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label39.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time1 = winTime Or time1 = winTime2 Then
                Audience.PictureBox30.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.Label30.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label40.BackColor = Color.FromArgb(96, 182, 90)
            End If
            winLine = True
        Else
            If time6 = winTime Or time6 = winTime2 Then
                Audience.PictureBox21.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label21.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label31.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time5 = winTime Or time5 = winTime2 Then
                Audience.PictureBox22.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label22.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label32.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time7 = winTime Or time7 = winTime2 Then
                Audience.PictureBox23.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label23.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label33.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time4 = winTime Or time4 = winTime2 Then
                Audience.PictureBox24.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label24.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label34.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time8 = winTime Or time8 = winTime2 Then
                Audience.PictureBox25.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label25.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label35.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time3 = winTime Or time3 = winTime2 Then
                Audience.PictureBox26.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label26.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label36.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time9 = winTime Or time9 = winTime2 Then
                Audience.PictureBox27.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label27.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label37.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time2 = winTime Or time2 = winTime2 Then
                Audience.PictureBox28.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label28.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label38.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time10 = winTime Or time10 = winTime2 Then
                Audience.PictureBox29.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label29.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label39.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time1 = winTime Or time1 = winTime2 Then
                Audience.PictureBox30.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.Label30.BackColor = Color.FromArgb(31, 31, 31)
                Audience.Label40.BackColor = Color.FromArgb(31, 31, 31)
            End If
            winLine = False
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        'Qualifying winner
        If Button11.BackColor <> Color.Gold Then
            orderDemo = False
            Button12.BackColor = Color.White
            Timer3.Stop()
            'Cкрытие таблицы результатов
            Audience.PictureBox21.Visible = False
            Audience.PictureBox22.Visible = False
            Audience.PictureBox23.Visible = False
            Audience.PictureBox24.Visible = False
            Audience.PictureBox25.Visible = False
            Audience.PictureBox26.Visible = False
            Audience.PictureBox27.Visible = False
            If CheckBox2.Checked = False Then Audience.PictureBox28.Visible = False
            Audience.PictureBox29.Visible = False
            'Audience.PictureBox30.Visible = False
            Audience.Label21.Visible = False
            Audience.Label22.Visible = False
            Audience.Label23.Visible = False
            Audience.Label24.Visible = False
            Audience.Label25.Visible = False
            Audience.Label26.Visible = False
            Audience.Label27.Visible = False
            If CheckBox2.Checked = False Then Audience.Label28.Visible = False
            Audience.Label29.Visible = False
            'Audience.Label30.Visible = False
            Audience.Label31.Visible = False
            Audience.Label32.Visible = False
            Audience.Label33.Visible = False
            Audience.Label34.Visible = False
            Audience.Label35.Visible = False
            Audience.Label36.Visible = False
            Audience.Label37.Visible = False
            If CheckBox2.Checked = False Then Audience.Label38.Visible = False
            Audience.Label39.Visible = False
            'Audience.Label40.Visible = False
            Audience.Label21.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label22.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label23.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label24.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label25.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label26.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label27.BackColor = Color.FromArgb(31, 31, 31)
            If CheckBox2.Checked = False Then Audience.Label28.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label29.BackColor = Color.FromArgb(31, 31, 31)
            'Audience.Label30.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label31.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label32.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label33.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label34.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label35.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label36.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label37.BackColor = Color.FromArgb(31, 31, 31)
            If CheckBox2.Checked = False Then Audience.Label38.BackColor = Color.FromArgb(31, 31, 31)
            Audience.Label39.BackColor = Color.FromArgb(31, 31, 31)
            'Audience.Label40.BackColor = Color.FromArgb(31, 31, 31)
            '\Конец скрытия таблицы
            Audience.PictureBox30.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
            If time6 = winTime Then
                Audience.Label30.Text = Audience.Label21.Text
                Audience.Label40.Text = Audience.Label31.Text
            End If
            If time5 = winTime Then
                Audience.Label30.Text = Audience.Label22.Text
                Audience.Label40.Text = Audience.Label32.Text
                winners = winners + 1
            End If
            If time7 = winTime Then
                Audience.Label30.Text = Audience.Label23.Text
                Audience.Label40.Text = Audience.Label33.Text
            End If
            If time4 = winTime Then
                Audience.Label30.Text = Audience.Label24.Text
                Audience.Label40.Text = Audience.Label34.Text
            End If
            If time8 = winTime Then
                Audience.Label30.Text = Audience.Label25.Text
                Audience.Label40.Text = Audience.Label35.Text
            End If
            If time3 = winTime Then
                Audience.Label30.Text = Audience.Label26.Text
                Audience.Label40.Text = Audience.Label36.Text
            End If
            If time9 = winTime Then
                Audience.Label30.Text = Audience.Label27.Text
                Audience.Label40.Text = Audience.Label37.Text
            End If
            If time2 = winTime Then
                Audience.Label30.Text = Audience.Label28.Text
                Audience.Label40.Text = Audience.Label38.Text
            End If
            If time10 = winTime Then
                Audience.Label30.Text = Audience.Label29.Text
                Audience.Label40.Text = Audience.Label39.Text
            End If
            Audience.Label30.BackColor = Color.FromArgb(96, 182, 90)
            Audience.Label40.BackColor = Color.FromArgb(96, 182, 90)
            Audience.PictureBox30.Visible = True
            Audience.Label30.Visible = True
            Audience.Label40.Visible = True
            If CheckBox2.Checked = True Then
                If time6 = winTime2 Then
                    Audience.Label28.Text = Audience.Label21.Text
                    Audience.Label38.Text = Audience.Label31.Text
                End If
                If time5 = winTime2 Then
                    Audience.Label28.Text = Audience.Label22.Text
                    Audience.Label38.Text = Audience.Label32.Text
                    winners = winners + 1
                End If
                If time7 = winTime2 Then
                    Audience.Label28.Text = Audience.Label23.Text
                    Audience.Label38.Text = Audience.Label33.Text
                End If
                If time4 = winTime2 Then
                    Audience.Label28.Text = Audience.Label24.Text
                    Audience.Label38.Text = Audience.Label34.Text
                End If
                If time8 = winTime2 Then
                    Audience.Label28.Text = Audience.Label25.Text
                    Audience.Label38.Text = Audience.Label35.Text
                End If
                If time3 = winTime2 Then
                    Audience.Label28.Text = Audience.Label26.Text
                    Audience.Label38.Text = Audience.Label36.Text
                End If
                If time9 = winTime2 Then
                    Audience.Label28.Text = Audience.Label27.Text
                    Audience.Label38.Text = Audience.Label37.Text
                End If
                If time10 = winTime2 Then
                    Audience.Label28.Text = Audience.Label29.Text
                    Audience.Label38.Text = Audience.Label39.Text
                End If
                If time1 = winTime2 Then
                    Audience.Label28.Text = Audience.Label30.Text
                    Audience.Label38.Text = Audience.Label40.Text
                End If
                Audience.Label28.BackColor = Color.FromArgb(96, 182, 90)
                Audience.Label38.BackColor = Color.FromArgb(96, 182, 90)
                Audience.PictureBox28.Visible = True
                Audience.Label28.Visible = True
                Audience.Label38.Visible = True
            End If
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
            Project.TextBox11.Text = Audience.Label30.Text
            'Удаление победителя из списка
            If CheckBox1.Checked = True Then
                If TextBox1.Text <> Audience.Label30.Text Then
                    If TextBox2.Text <> Audience.Label30.Text Then
                        If TextBox3.Text <> Audience.Label30.Text Then
                            If TextBox4.Text <> Audience.Label30.Text Then
                                If TextBox5.Text <> Audience.Label30.Text Then
                                    If TextBox6.Text <> Audience.Label30.Text Then
                                        If TextBox7.Text <> Audience.Label30.Text Then
                                            If TextBox8.Text <> Audience.Label30.Text Then
                                                If TextBox9.Text <> Audience.Label30.Text Then
                                                    If TextBox10.Text = Audience.Label30.Text Then TextBox10.Text = Nothing
                                                Else
                                                    TextBox9.Text = Nothing
                                                End If
                                            Else
                                                TextBox8.Text = Nothing
                                            End If
                                        Else
                                            TextBox7.Text = Nothing
                                        End If
                                    Else
                                        TextBox6.Text = Nothing
                                    End If
                                Else
                                    TextBox5.Text = Nothing
                                End If
                            Else
                                TextBox4.Text = Nothing
                            End If
                        Else
                            TextBox3.Text = Nothing
                        End If
                    Else
                        TextBox2.Text = Nothing
                    End If
                Else
                    TextBox1.Text = Nothing
                End If
                TextBox1.Focus()
                Button12.Focus()
                FileClose(1)
                FileOpen(1, OpenFileDialog2.FileName, OpenMode.Output)
                Dim n As Integer = 1
                If TextBox1.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox1.Text & "|" & TextBox11.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If TextBox2.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox2.Text & "|" & TextBox12.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If TextBox3.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox3.Text & "|" & TextBox13.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If TextBox4.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox4.Text & "|" & TextBox14.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If TextBox5.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox5.Text & "|" & TextBox15.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If TextBox6.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox6.Text & "|" & TextBox16.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If TextBox7.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox7.Text & "|" & TextBox17.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If TextBox8.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox8.Text & "|" & TextBox18.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If TextBox9.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox9.Text & "|" & TextBox19.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If TextBox10.Text <> Nothing Then
                    Print(1, "|" & n & "|" & TextBox10.Text & "|" & TextBox20.Text & "|0|" & Chr(13) & Chr(10))
                End If
                FileClose(1)
            End If
            Button11.BackColor = Color.White
            My.Computer.Audio.Play("source\MUSIC\Qualifying Winner.wav")
        End If
    End Sub

    Private Sub FormFFF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'Cкрытие таблицы результатов
        Audience.PictureBox21.Visible = False
        Audience.PictureBox22.Visible = False
        Audience.PictureBox23.Visible = False
        Audience.PictureBox24.Visible = False
        Audience.PictureBox25.Visible = False
        Audience.PictureBox26.Visible = False
        Audience.PictureBox27.Visible = False
        Audience.PictureBox28.Visible = False
        Audience.PictureBox29.Visible = False
        Audience.PictureBox30.Visible = False
        Audience.Label21.Visible = False
        Audience.Label22.Visible = False
        Audience.Label23.Visible = False
        Audience.Label24.Visible = False
        Audience.Label25.Visible = False
        Audience.Label26.Visible = False
        Audience.Label27.Visible = False
        Audience.Label28.Visible = False
        Audience.Label29.Visible = False
        Audience.Label30.Visible = False
        Audience.Label31.Visible = False
        Audience.Label32.Visible = False
        Audience.Label33.Visible = False
        Audience.Label34.Visible = False
        Audience.Label35.Visible = False
        Audience.Label36.Visible = False
        Audience.Label37.Visible = False
        Audience.Label38.Visible = False
        Audience.Label39.Visible = False
        Audience.Label40.Visible = False
        Audience.Label21.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label22.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label23.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label24.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label25.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label26.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label27.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label28.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label29.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label30.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label31.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label32.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label33.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label34.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label35.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label36.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label37.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label38.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label39.BackColor = Color.FromArgb(31, 31, 31)
        Audience.Label40.BackColor = Color.FromArgb(31, 31, 31)
        '\Конец скрытия таблицы
        Audience.Label6.Visible = False
        Audience.Label7.Visible = False
        Audience.Label8.Visible = False
        Audience.Label9.Visible = False
        Audience.Label10.Visible = False
        Audience.Label11.Visible = False
        Audience.Label12.Visible = False
        Audience.PictureBox16.Visible = False
        Audience.PictureBox17.Visible = False
        Audience.PictureBox18.Visible = False
        Audience.PictureBox19.Visible = False
        Audience.PictureBox0.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LOGO_FEEL.png")
        Audience.PictureBox0.Visible = False
        Project.Button16.BackColor = Color.White
        Project.Label16.Text = ""
        Project.Label17.Text = ""
        Project.Label18.Text = ""
        Project.Label19.Text = ""
        Project.Label20.Text = ""
        Audience.Label16.Visible = True
        Audience.Label17.Visible = True
        Audience.Label18.Visible = True
        Audience.Label19.Visible = True
        Audience.Label20.Visible = True
        Audience.PictureBox1.Visible = True
        Audience.PictureBox2.Visible = True
        Audience.PictureBox3.Visible = True
        Audience.PictureBox4.Visible = True
        Audience.PictureBox5.Visible = True
        Audience.PictureBox6.Visible = True
        Audience.PictureBox7.Visible = True
        Audience.PictureBox8.Visible = False
        Project.PictureBox2.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LEFT.png")
        Project.PictureBox3.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\RIGHT.png")
        Project.PictureBox4.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LEFT.png")
        Project.PictureBox5.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\RIGHT.png")
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
        Project.Button41.BackColor = Color.White
        Project.Button23.BackColor = Color.FromArgb(255, 128, 128)
        If Project.splashOn = False Then
            Project.Button16.PerformClick()
            Project.Button16.BackColor = Color.Violet
            Project.splashOn = True
        End If
        Audience.PictureBox0.Visible = True
    End Sub
End Class