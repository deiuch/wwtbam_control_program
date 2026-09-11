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
        Project.ClearFormsButton.PerformClick()
        OpenQuestionBaseDialog.InitialDirectory = Project.sourcePath
        If Project.ini(14) <> Nothing And My.Computer.FileSystem.FileExists(Project.ini(14)) Then
            OpenQuestionBaseDialog.FileName = Project.ini(14)
        Else
            OpenQuestionBaseDialog.FileName = "Bases\" & Project.currentBlock1(2, 3) & "qualify.fff"
        End If
        FileNameQ = OpenQuestionBaseDialog.FileName
        Call openfilesdata(FileNameQ)
        Audience.QuestionTextLabel.Visible = False
        Audience.AnswerATextLabel.Visible = False
        Audience.AnswerBTextLabel.Visible = False
        Audience.AnswerCTextLabel.Visible = False
        Audience.AnswerDTextLabel.Visible = False
        Audience.QuestionFramePictureBox.Visible = False
        Audience.AnswerAFramePictureBox.Visible = False
        Audience.AnswerBFramePictureBox.Visible = False
        Audience.AnswerCFramePictureBox.Visible = False
        Audience.AnswerDFramePictureBox.Visible = False
        Audience.MoneyTreePictureBox.Visible = False
        Audience.LifelinesPictureBox.Visible = False
        'Открытие списка участников
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        i1 = 0
        i0 = 0
        If OpenContestantsListDialog.FileName = Nothing Or My.Computer.FileSystem.FileExists(OpenContestantsListDialog.FileName) = False Then
            If Project.ini(15) <> Nothing And My.Computer.FileSystem.FileExists(Project.ini(15)) Then
                OpenContestantsListDialog.FileName = Project.ini(15)
            Else
                OpenContestantsListDialog.FileName = "Bases\" & Project.currentBlock1(2, 3) & "contestants.con"
            End If
        End If
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(OpenContestantsListDialog.FileName, System.Text.Encoding.Default)
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
            Me.Controls("ContestantFieldTextBox" & x).Text = currentBlock3(x, 3)
        Next
        For x = 11 To i0 + 10
            Me.Controls("ContestantFieldTextBox" & x).Text = currentBlock3(x - 10, 4)
        Next
        For x = 21 To i0 + 20
            Me.Controls("ContestantFieldTextBox" & x).Text = currentBlock3(x - 20, 5)
        Next
        For x = 1 To 10 - i0
            Me.Controls("ContestantFieldTextBox" & 11 - x).Text = Nothing
            Me.Controls("ContestantFieldTextBox" & 21 - x).Text = Nothing
            Me.Controls("ContestantFieldTextBox" & 31 - x).Text = Nothing
        Next
        'Выравнивание по полям
        Dim x1 As Integer = 0
        ReDim currentBlock0(10, 3)
        ReDim currentBlock3(10, 3)
        For x = 1 To 10
            currentBlock0(x, 1) = Me.Controls("ContestantFieldTextBox" & x).Text
        Next
        For x = 11 To 20
            currentBlock0(x - 10, 2) = Me.Controls("ContestantFieldTextBox" & x).Text
        Next
        For x = 21 To 30
            currentBlock0(x - 20, 3) = Me.Controls("ContestantFieldTextBox" & x).Text
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
            If Me.Controls("ContestantFieldTextBox" & x).Text = Nothing Then m = m + 1
        Next
        n = Math.Floor(m / 2)
        For x = 1 To 10
            If x + n <= 10 Then
                Me.Controls("ContestantFieldTextBox" & x + n).Text = currentBlock3(x, 1)
                Me.Controls("ContestantFieldTextBox" & x + 10 + n).Text = currentBlock3(x, 2)
                Me.Controls("ContestantFieldTextBox" & x + 20 + n).Text = currentBlock3(x, 3)
            End If
        Next
        For x = 1 To n
            Me.Controls("ContestantFieldTextBox" & x).Text = Nothing
            Me.Controls("ContestantFieldTextBox" & x + 10).Text = Nothing
            Me.Controls("ContestantFieldTextBox" & x + 20).Text = Nothing
        Next
        'Перевод "G" FormFFF
        Text = Project.currentBlock1(123, 3) '0
        OpenQuestionBaseButton.Text = Project.currentBlock1(124, 3) '1
        OpenContestantsListButton.Text = Project.currentBlock1(124, 4) '1
        DropWinnerCheckBox.Text = Project.currentBlock1(124, 5) '1
        TwoWinnersCheckBox.Text = Project.currentBlock1(124, 6) '1
        TodaysNamesButton.Text = Project.currentBlock1(125, 3) '2
        ExplainRulesButton.Text = Project.currentBlock1(126, 3) '3
        AskQuestionButton.Text = Project.currentBlock1(127, 3) '4
        ThreeBeepsButton.Text = Project.currentBlock1(128, 3) '5
        StartTimerButton.Text = Project.currentBlock1(129, 3) '6
        RightOrderButton.Text = Project.currentBlock1(130, 3) '7 |What's Correct|
        RightOrder1Button.Text = Project.currentBlock1(131, 3) '8
        RightOrder2Button.Text = Project.currentBlock1(132, 3) '9
        RightOrder3Button.Text = Project.currentBlock1(133, 3) '10
        RightOrder4Button.Text = Project.currentBlock1(134, 3) '11
        CorrectAnswersButton.Text = Project.currentBlock1(135, 3) '12
        QualifyingWinnerButton.Text = Project.currentBlock1(136, 3) '13
        FullQuestionTextLabel.Text = Project.currentBlock1(137, 3) '14
        LeftNameHeaderLabel.Text = Project.currentBlock1(138, 3) '15
        RightNameHeaderLabel.Text = Project.currentBlock1(138, 3) '15
        LeftFromHeaderLabel.Text = Project.currentBlock1(139, 3) '16
        RightFromHeaderLabel.Text = Project.currentBlock1(139, 3) '16
        LeftTimeHeaderLabel.Text = Project.currentBlock1(140, 3) '17
        RightTimeHeaderLabel.Text = Project.currentBlock1(140, 3) '17
    End Sub

    Private Sub openfilesdata(sender As Object)
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
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
            REM Заполнение QuestionListBox
            QuestionListBox.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    QuestionListBox.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3))
                End If
            Next
            QuestionListBox.SelectedIndex = 0
            REM /Заполнение QuestionListBox
            REM /***********************
            OpenQuestionBaseButton.BackColor = Color.White
        Else
            QuestionListBox.Enabled = False
            QuestionListBox.Items.Clear()
            MsgBox("You don't choosed question base file! Please, press ""Open base file"" button.")
            OpenQuestionBaseButton.BackColor = Color.FromArgb(255, 128, 0) 'Open button -> Orange
        End If
    End Sub

    Private Sub QuestionListBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QuestionListBox.SelectedIndexChanged
        first = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 8))
        second = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 9))
        third = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 10))
        fourth = Int(currentBlock2(QuestionListBox.SelectedIndex + 1, 11))
        If fourth <> 0 Then
            RightOrder1Button.Enabled = True
            RightOrder2Button.Enabled = True
            RightOrder3Button.Enabled = True
            RightOrder4Button.Enabled = True
            QuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & Project.currentBlock1(144, 3) & " " & first & ", " & second & ", " & third & ", " & fourth
            RightOrderButton.Text = Project.currentBlock1(130, 3) 'Right Order
        Else
            RightOrder1Button.Enabled = False
            RightOrder2Button.Enabled = False
            RightOrder3Button.Enabled = False
            RightOrder4Button.Enabled = False
            QuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & Project.currentBlock1(143, 3) & " " & first
            RightOrderButton.Text = Project.currentBlock1(130, 4) 'What's Correct
        End If
    End Sub

    Private Sub TwoWinnersCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles TwoWinnersCheckBox.CheckedChanged
        If TwoWinnersCheckBox.Checked = True Then
            DropWinnerCheckBox.Checked = False
            DropWinnerCheckBox.Enabled = False
        Else
            DropWinnerCheckBox.Checked = True
            DropWinnerCheckBox.Enabled = True
        End If
    End Sub

    Private Sub QuestionListBox_DoubleClick(sender As Object, e As EventArgs) Handles QuestionListBox.DoubleClick
        EditorFFF.Show()
    End Sub

    Private Sub OpenQuestionBaseButton_Click(sender As Object, e As EventArgs) Handles OpenQuestionBaseButton.Click
        'Open base file...
        OpenQuestionBaseDialog.FileName = "*.fff"
        OpenQuestionBaseDialog.InitialDirectory = CurDir() & "\Bases"
        OpenQuestionBaseDialog.CheckFileExists = True
        If OpenQuestionBaseDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenQuestionBaseDialog.FileName
            Project.ini(14) = FileNameQ
            Call openfilesdata(FileNameQ)
        End If
    End Sub

    Private Sub OpenContestantsListButton_Click(sender As Object, e As EventArgs) Handles OpenContestantsListButton.Click
        'Open contestants list...
        OpenContestantsListDialog.FileName = "*.con"
        OpenContestantsListDialog.InitialDirectory = CurDir() & "\Bases"
        OpenContestantsListDialog.CheckFileExists = True
        If OpenContestantsListDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Project.ini(15) = OpenContestantsListDialog.FileName
            Dim currentField As String
            Dim currentRow As String()
            Dim i0 As Integer
            Dim i1 As Integer
            i1 = 0
            i0 = 0
            Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(OpenContestantsListDialog.FileName, System.Text.Encoding.Default)
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
                Me.Controls("ContestantFieldTextBox" & x).Text = currentBlock3(x, 3)
            Next
            For x = 11 To i0 + 10
                Me.Controls("ContestantFieldTextBox" & x).Text = currentBlock3(x - 10, 4)
            Next
            For x = 21 To i0 + 20
                Me.Controls("ContestantFieldTextBox" & x).Text = currentBlock3(x - 20, 5)
            Next
            For x = 1 To 10 - i0
                Me.Controls("ContestantFieldTextBox" & 11 - x).Text = Nothing
                Me.Controls("ContestantFieldTextBox" & 21 - x).Text = Nothing
                Me.Controls("ContestantFieldTextBox" & 31 - x).Text = Nothing
            Next
            'Выравнивание по полям
            Dim x1 As Integer = 0
            ReDim currentBlock0(10, 3)
            ReDim currentBlock3(10, 3)
            For x = 1 To 10
                currentBlock0(x, 1) = Me.Controls("ContestantFieldTextBox" & x).Text
            Next
            For x = 11 To 20
                currentBlock0(x - 10, 2) = Me.Controls("ContestantFieldTextBox" & x).Text
            Next
            For x = 21 To 30
                currentBlock0(x - 20, 3) = Me.Controls("ContestantFieldTextBox" & x).Text
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
                If Me.Controls("ContestantFieldTextBox" & x).Text = Nothing Then m = m + 1
            Next
            n = Math.Floor(m / 2)
            For x = 1 To 10
                If x + n <= 10 Then
                    Me.Controls("ContestantFieldTextBox" & x + n).Text = currentBlock3(x, 1)
                    Me.Controls("ContestantFieldTextBox" & x + 10 + n).Text = currentBlock3(x, 2)
                    Me.Controls("ContestantFieldTextBox" & x + 20 + n).Text = currentBlock3(x, 3)
                End If
            Next
            For x = 1 To n
                Me.Controls("ContestantFieldTextBox" & x).Text = Nothing
                Me.Controls("ContestantFieldTextBox" & x + 10).Text = Nothing
                Me.Controls("ContestantFieldTextBox" & x + 20).Text = Nothing
            Next
        End If
    End Sub

    Public Sub ContestantFieldTextBox1_LostFocus(sender As Object, e As EventArgs) Handles ContestantFieldTextBox1.LostFocus, ContestantFieldTextBox2.LostFocus, ContestantFieldTextBox3.LostFocus, ContestantFieldTextBox4.LostFocus, ContestantFieldTextBox5.LostFocus, ContestantFieldTextBox6.LostFocus, ContestantFieldTextBox7.LostFocus, ContestantFieldTextBox8.LostFocus, ContestantFieldTextBox9.LostFocus, ContestantFieldTextBox10.LostFocus
        'Выравнивание по полям
        Dim x1 As Integer = 0
        Dim currentRow(10)
        ReDim currentBlock0(10, 3)
        ReDim currentBlock3(10, 3)
        For x = 1 To 10
            currentBlock0(x, 1) = Me.Controls("ContestantFieldTextBox" & x).Text
        Next
        For x = 11 To 20
            currentBlock0(x - 10, 2) = Me.Controls("ContestantFieldTextBox" & x).Text
        Next
        For x = 21 To 30
            currentBlock0(x - 20, 3) = Me.Controls("ContestantFieldTextBox" & x).Text
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
            If Me.Controls("ContestantFieldTextBox" & x).Text = Nothing Then m = m + 1
        Next
        n = Math.Floor(m / 2)
        For x = 1 To 10
            If x + n <= 10 Then
                Me.Controls("ContestantFieldTextBox" & x + n).Text = currentBlock3(x, 1)
                Me.Controls("ContestantFieldTextBox" & x + 10 + n).Text = currentBlock3(x, 2)
                Me.Controls("ContestantFieldTextBox" & x + 20 + n).Text = currentBlock3(x, 3)
            End If
        Next
        For x = 1 To n
            Me.Controls("ContestantFieldTextBox" & x).Text = Nothing
            Me.Controls("ContestantFieldTextBox" & x + 10).Text = Nothing
            Me.Controls("ContestantFieldTextBox" & x + 20).Text = Nothing
        Next
    End Sub

    Private Sub ContestantFieldTextBox21_LostFocus(sender As Object, e As EventArgs) Handles ContestantFieldTextBox21.LostFocus, ContestantFieldTextBox22.LostFocus, ContestantFieldTextBox23.LostFocus, ContestantFieldTextBox24.LostFocus, ContestantFieldTextBox25.LostFocus, ContestantFieldTextBox26.LostFocus, ContestantFieldTextBox27.LostFocus, ContestantFieldTextBox28.LostFocus, ContestantFieldTextBox29.LostFocus, ContestantFieldTextBox30.LostFocus
        'My.Application.Culture.NumberFormat.NumberDecimalSeparator 32 39 44 46
        ContestantFieldTextBox21.Text = ContestantFieldTextBox21.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox21.Text = ContestantFieldTextBox21.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox21.Text = ContestantFieldTextBox21.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox21.Text = ContestantFieldTextBox21.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox22.Text = ContestantFieldTextBox22.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox22.Text = ContestantFieldTextBox22.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox22.Text = ContestantFieldTextBox22.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox22.Text = ContestantFieldTextBox22.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox23.Text = ContestantFieldTextBox23.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox23.Text = ContestantFieldTextBox23.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox23.Text = ContestantFieldTextBox23.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox23.Text = ContestantFieldTextBox23.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox24.Text = ContestantFieldTextBox24.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox24.Text = ContestantFieldTextBox24.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox24.Text = ContestantFieldTextBox24.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox24.Text = ContestantFieldTextBox24.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox25.Text = ContestantFieldTextBox25.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox25.Text = ContestantFieldTextBox25.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox25.Text = ContestantFieldTextBox25.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox25.Text = ContestantFieldTextBox25.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox26.Text = ContestantFieldTextBox26.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox26.Text = ContestantFieldTextBox26.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox26.Text = ContestantFieldTextBox26.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox26.Text = ContestantFieldTextBox26.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox27.Text = ContestantFieldTextBox27.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox27.Text = ContestantFieldTextBox27.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox27.Text = ContestantFieldTextBox27.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox27.Text = ContestantFieldTextBox27.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox28.Text = ContestantFieldTextBox28.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox28.Text = ContestantFieldTextBox28.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox28.Text = ContestantFieldTextBox28.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox28.Text = ContestantFieldTextBox28.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox29.Text = ContestantFieldTextBox29.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox29.Text = ContestantFieldTextBox29.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox29.Text = ContestantFieldTextBox29.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox29.Text = ContestantFieldTextBox29.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox30.Text = ContestantFieldTextBox30.Text.Replace(Chr(32), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox30.Text = ContestantFieldTextBox30.Text.Replace(Chr(39), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox30.Text = ContestantFieldTextBox30.Text.Replace(Chr(44), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
        ContestantFieldTextBox30.Text = ContestantFieldTextBox30.Text.Replace(Chr(46), My.Application.Culture.NumberFormat.NumberDecimalSeparator)
    End Sub

    Private Sub TodaysNamesButton_Click(sender As Object, e As EventArgs) Handles TodaysNamesButton.Click
        'Today's Names
        If Project.splashOn = False Then
            Project.ToggleLogoButton.PerformClick()
            Project.ToggleLogoButton.BackColor = Color.Green
            Project.splashOn = True
        End If
        Audience.LogoPictureBox.Visible = False
        orderDemo = False
        'Cкрытие таблицы результатов
        Audience.FffResultRow5PictureBox.Visible = False
        Audience.FffResultRow6PictureBox.Visible = False
        Audience.FffResultRow4PictureBox.Visible = False
        Audience.FffResultRow7PictureBox.Visible = False
        Audience.FffResultRow3PictureBox.Visible = False
        Audience.FffResultRow8PictureBox.Visible = False
        Audience.FffResultRow2PictureBox.Visible = False
        Audience.FffResultRow9PictureBox.Visible = False
        Audience.FffResultRow1PictureBox.Visible = False
        Audience.FffResultRow10PictureBox.Visible = False
        Audience.FffResultName5Label.Visible = False
        Audience.FffResultName6Label.Visible = False
        Audience.FffResultName4Label.Visible = False
        Audience.FffResultName7Label.Visible = False
        Audience.FffResultName3Label.Visible = False
        Audience.FffResultName8Label.Visible = False
        Audience.FffResultName2Label.Visible = False
        Audience.FffResultName9Label.Visible = False
        Audience.FffResultName1Label.Visible = False
        Audience.FffResultName10Label.Visible = False
        Audience.FffResultTime5Label.Visible = False
        Audience.FffResultTime6Label.Visible = False
        Audience.FffResultTime4Label.Visible = False
        Audience.FffResultTime7Label.Visible = False
        Audience.FffResultTime3Label.Visible = False
        Audience.FffResultTime8Label.Visible = False
        Audience.FffResultTime2Label.Visible = False
        Audience.FffResultTime9Label.Visible = False
        Audience.FffResultTime1Label.Visible = False
        Audience.FffResultTime10Label.Visible = False
        Audience.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
        CorrectAnswersButton.BackColor = Color.White
        '\Конец скрытия таблицы
        Audience.LogoPictureBox.Visible = False
        Audience.ContestantNameLabel.Visible = False
        Audience.ContestantTownLabel.Visible = False
        Audience.FffQuestionTextLabel.Visible = False
        Audience.FffAnswer1Label.Visible = False
        Audience.FffAnswer2Label.Visible = False
        Audience.FffAnswer3Label.Visible = False
        Audience.FffAnswer4Label.Visible = False
        Audience.QuestionTextLabel.Visible = False
        Audience.AnswerATextLabel.Visible = False
        Audience.AnswerBTextLabel.Visible = False
        Audience.AnswerCTextLabel.Visible = False
        Audience.AnswerDTextLabel.Visible = False
        Audience.QuestionFramePictureBox.Visible = False
        Audience.AnswerAFramePictureBox.Visible = False
        Audience.AnswerBFramePictureBox.Visible = False
        Audience.AnswerCFramePictureBox.Visible = False
        Audience.AnswerDFramePictureBox.Visible = False
        Audience.ClockPictureBox.Visible = False
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        Audience.FffAnswer1FramePictureBox.Visible = False
        Audience.FffAnswer2FramePictureBox.Visible = False
        Audience.FffAnswer3FramePictureBox.Visible = False
        Audience.FffAnswer4FramePictureBox.Visible = False
        NameSequenceTimer.Interval = 35000
        If ContestantFieldTextBox5.Text <> Nothing Then
            If ContestantFieldTextBox6.Text <> Nothing Then
                If ContestantFieldTextBox4.Text <> Nothing Then
                    If ContestantFieldTextBox7.Text <> Nothing Then
                        If ContestantFieldTextBox3.Text <> Nothing Then
                            If ContestantFieldTextBox8.Text <> Nothing Then
                                If ContestantFieldTextBox2.Text <> Nothing Then
                                    If ContestantFieldTextBox9.Text <> Nothing Then
                                        If ContestantFieldTextBox1.Text <> Nothing Then
                                            If ContestantFieldTextBox10.Text = Nothing Then
                                                NameSequenceTimer.Interval = 26860
                                            End If
                                        Else
                                            NameSequenceTimer.Interval = 23780
                                        End If
                                    Else
                                        NameSequenceTimer.Interval = 20700
                                    End If
                                Else
                                    NameSequenceTimer.Interval = 17620
                                End If
                            Else
                                NameSequenceTimer.Interval = 14540
                            End If
                        Else
                            NameSequenceTimer.Interval = 11460
                        End If
                    Else
                        NameSequenceTimer.Interval = 8380
                    End If
                Else
                    NameSequenceTimer.Interval = 5300
                End If
            Else
                NameSequenceTimer.Interval = 2100
            End If
        End If
        If TimerTick <> 0 Then
            TodaysNamesButton.BackColor = Color.White
            My.Computer.Audio.Stop()
            NameCycleTimer.Stop()
            NameSequenceTimer.Stop()
            TimerTick = 0
            Audience.ContestantNameLabel.Visible = False
            Audience.ContestantTownLabel.Visible = False
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
            Shell("source\BAT\stop_back_music1.bat")
            Project.winampOn = 0
        Else
            TodaysNamesButton.BackColor = Color.Aqua
            NameCycleTimer.Interval = 3200
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\AudienceFFF.png")
            My.Computer.Audio.Stop()
            Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Today's Names with ten.wav" & Chr(34)
            Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
            Project.winampOn = 1
            NameCycleTimer.Start()
            NameSequenceTimer.Start()
            TimerTick = 1
            Select Case NameSequenceTimer.Interval
                Case 23780, 20700
                    Audience.ContestantNameLabel.Text = ContestantFieldTextBox2.Text
                    Audience.ContestantTownLabel.Text = ContestantFieldTextBox12.Text
                Case 17620, 14540
                    Audience.ContestantNameLabel.Text = ContestantFieldTextBox3.Text
                    Audience.ContestantTownLabel.Text = ContestantFieldTextBox13.Text
                Case 11460, 8380
                    Audience.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                    Audience.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                Case 5300, 2100
                    Audience.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                    Audience.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                Case Else
                    Audience.ContestantNameLabel.Text = ContestantFieldTextBox1.Text
                    Audience.ContestantTownLabel.Text = ContestantFieldTextBox11.Text
            End Select
            Audience.ContestantNameLabel.Visible = True
            Audience.ContestantTownLabel.Visible = True
        End If
    End Sub

    Private Sub NameCycleTimer_Tick(sender As Object, e As EventArgs) Handles NameCycleTimer.Tick
        'Переключение имён каждые 3 секунды
        If TimerTick < 10 Then
            TimerTick = TimerTick + 1
            Select Case TimerTick
                Case 1
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox2.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox12.Text
                        Case 17620, 14540
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox3.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox13.Text
                        Case 11460, 8380
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                        Case 5300, 2100
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                        Case Else
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox1.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox11.Text
                    End Select
                Case 2
                    NameCycleTimer.Interval = 3080
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox3.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox13.Text
                        Case 17620, 14540
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                        Case 11460, 8380
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                        Case 5300
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                        Case Else
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox2.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox12.Text
                    End Select
                Case 3
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                        Case 17620, 14540
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                        Case 11460, 8380
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                        Case Else
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox3.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox13.Text
                    End Select
                Case 4
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                        Case 17620, 14540
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                        Case 11460
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox7.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox17.Text
                        Case Else
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                    End Select
                Case 5
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                        Case 17620, 14540
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox7.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox17.Text
                        Case Else
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                    End Select
                Case 6
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox7.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox17.Text
                        Case 17620
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox8.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox18.Text
                        Case Else
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                    End Select
                Case 7
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox8.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox18.Text
                        Case Else
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox7.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox17.Text
                    End Select
                Case 8
                    Select Case NameSequenceTimer.Interval
                        Case 23780
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox9.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox19.Text
                        Case Else
                            Audience.ContestantNameLabel.Text = ContestantFieldTextBox8.Text
                            Audience.ContestantTownLabel.Text = ContestantFieldTextBox18.Text
                    End Select
                Case 9
                    Audience.ContestantNameLabel.Text = ContestantFieldTextBox9.Text
                    Audience.ContestantTownLabel.Text = ContestantFieldTextBox19.Text
                Case 10
                    Audience.ContestantNameLabel.Text = ContestantFieldTextBox10.Text
                    Audience.ContestantTownLabel.Text = ContestantFieldTextBox20.Text
            End Select
        Else
            NameCycleTimer.Stop()
            NameSequenceTimer.Stop()
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
            Audience.ContestantNameLabel.Visible = False
            Audience.ContestantTownLabel.Visible = False
            TodaysNamesButton.BackColor = Color.White
            Project.winampOn = 0
            TimerTick = 0
        End If
    End Sub

    Private Sub NameSequenceTimer_Tick(sender As Object, e As EventArgs) Handles NameSequenceTimer.Tick
        NameCycleTimer.Stop()
        NameSequenceTimer.Stop()
        My.Computer.Audio.Play("source\MUSIC\Today's Names end.wav")
        Shell("source\BAT\stop_back_music1.bat")
        Project.winampOn = 0
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
        Audience.ContestantNameLabel.Visible = False
        Audience.ContestantTownLabel.Visible = False
        TodaysNamesButton.BackColor = Color.White
    End Sub

    Private Sub ExplainRulesButton_Click(sender As Object, e As EventArgs) Handles ExplainRulesButton.Click
        'Explain the rules
        If TodaysNamesButton.BackColor = Color.Aqua Then
            NameCycleTimer.Stop()
            TimerTick = 0
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
            Audience.ContestantNameLabel.Visible = False
            Audience.ContestantTownLabel.Visible = False
            TodaysNamesButton.BackColor = Color.White
        End If
        Audience.FffQuestionTextLabel.Visible = False
        Audience.FffAnswer1Label.Visible = False
        Audience.FffAnswer2Label.Visible = False
        Audience.FffAnswer3Label.Visible = False
        Audience.FffAnswer4Label.Visible = False
        Audience.FffAnswer1FramePictureBox.Visible = False
        Audience.FffAnswer2FramePictureBox.Visible = False
        Audience.FffAnswer3FramePictureBox.Visible = False
        Audience.FffAnswer4FramePictureBox.Visible = False
        My.Computer.Audio.Play("source\MUSIC\Explain the games.wav")
        rules = True
    End Sub

    Private Sub AskQuestionButton_Click(sender As Object, e As EventArgs) Handles AskQuestionButton.Click
        'Ask question
        If Project.splashOn = False Then
            Project.ToggleLogoButton.PerformClick()
            Project.ToggleLogoButton.BackColor = Color.Green
            Project.splashOn = True
        End If
        Audience.LogoPictureBox.Visible = False
        orderDemo = False
        QualifyingWinnerButton.Enabled = True
        Audience.ClockPictureBox.Visible = False
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        Project.ClearFormsButton.PerformClick()
        'Cкрытие таблицы результатов
        Audience.FffResultRow5PictureBox.Visible = False
        Audience.FffResultRow6PictureBox.Visible = False
        Audience.FffResultRow4PictureBox.Visible = False
        Audience.FffResultRow7PictureBox.Visible = False
        Audience.FffResultRow3PictureBox.Visible = False
        Audience.FffResultRow8PictureBox.Visible = False
        Audience.FffResultRow2PictureBox.Visible = False
        Audience.FffResultRow9PictureBox.Visible = False
        Audience.FffResultRow1PictureBox.Visible = False
        Audience.FffResultRow10PictureBox.Visible = False
        Audience.FffResultName5Label.Visible = False
        Audience.FffResultName6Label.Visible = False
        Audience.FffResultName4Label.Visible = False
        Audience.FffResultName7Label.Visible = False
        Audience.FffResultName3Label.Visible = False
        Audience.FffResultName8Label.Visible = False
        Audience.FffResultName2Label.Visible = False
        Audience.FffResultName9Label.Visible = False
        Audience.FffResultName1Label.Visible = False
        Audience.FffResultName10Label.Visible = False
        Audience.FffResultTime5Label.Visible = False
        Audience.FffResultTime6Label.Visible = False
        Audience.FffResultTime4Label.Visible = False
        Audience.FffResultTime7Label.Visible = False
        Audience.FffResultTime3Label.Visible = False
        Audience.FffResultTime8Label.Visible = False
        Audience.FffResultTime2Label.Visible = False
        Audience.FffResultTime9Label.Visible = False
        Audience.FffResultTime1Label.Visible = False
        Audience.FffResultTime10Label.Visible = False
        Audience.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
        CorrectAnswersButton.BackColor = Color.White
        '\Конец скрытия таблицы
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
        TodaysNamesButton.BackColor = Color.White
        NameCycleTimer.Stop()
        NameSequenceTimer.Stop()
        TimerTick = 0
        Audience.ContestantNameLabel.Visible = False
        Audience.ContestantTownLabel.Visible = False
        Audience.FffQuestionTextLabel.Visible = False
        Audience.FffAnswer1Label.Visible = False
        Audience.FffAnswer2Label.Visible = False
        Audience.FffAnswer3Label.Visible = False
        Audience.FffAnswer4Label.Visible = False
        Audience.FffAnswer1FramePictureBox.Visible = False
        Audience.FffAnswer2FramePictureBox.Visible = False
        Audience.FffAnswer3FramePictureBox.Visible = False
        Audience.FffAnswer4FramePictureBox.Visible = False
        My.Computer.Audio.Stop()
        If rules = True Then
            My.Computer.Audio.Play("source\MUSIC\Explain the games end.wav")
            rules = False
        End If
        Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Standby for Q.wav" & Chr(34)
        Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
        Project.winampOn = 1
        Project.QuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
        TodaysNamesButton.BackColor = Color.White
        NameCycleTimer.Stop()
        NameSequenceTimer.Stop()
        TimerTick = 0
        Audience.ContestantNameLabel.Visible = False
        Audience.ContestantTownLabel.Visible = False
        Audience.QuestionTextLabel.Visible = True
        Audience.AnswerATextLabel.Visible = False
        Audience.AnswerBTextLabel.Visible = False
        Audience.AnswerCTextLabel.Visible = False
        Audience.AnswerDTextLabel.Visible = False
        Project.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LEFT.png")
        Project.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\RIGHT.png")
        Project.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LEFT.png")
        Project.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\RIGHT.png")
        Project.AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
        Project.AnswerATextLabel.ForeColor = Color.White
        Project.AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        Project.AnswerBTextLabel.ForeColor = Color.White
        Project.AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        Project.AnswerCTextLabel.ForeColor = Color.White
        Project.AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        Project.AnswerDTextLabel.ForeColor = Color.White
        Audience.QuestionFramePictureBox.Visible = True
        Audience.AnswerAFramePictureBox.Visible = True
        Audience.AnswerBFramePictureBox.Visible = True
        Audience.AnswerCFramePictureBox.Visible = True
        Audience.AnswerDFramePictureBox.Visible = True
        AskQuestionButton.BackColor = Color.White
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        CorrectAnswersButton.BackColor = Color.White
        QualifyingWinnerButton.BackColor = Color.White
    End Sub

    Private Sub ThreeBeepsButton_Click(sender As Object, e As EventArgs) Handles ThreeBeepsButton.Click
        'Three beeps
        Shell("source\BAT\stop_back_music1.bat")
        Project.winampOn = 0
        My.Computer.Audio.Play("source\MUSIC\Three Beeps.wav")
    End Sub

    Private Sub StartTimerButton_Click(sender As Object, e As EventArgs) Handles StartTimerButton.Click
        'Start timer
        Select Case StartTimerButton.BackColor
            Case Color.White
                Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
                TodaysNamesButton.BackColor = Color.White
                NameCycleTimer.Stop()
                NameSequenceTimer.Stop()
                TimerTick = 0
                Audience.ContestantNameLabel.Visible = False
                Audience.ContestantTownLabel.Visible = False
                Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Fastest finger first.wav" & Chr(34)
                Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
                Project.winampOn = 1
                Project.QuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
                Project.AnswerATextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                Project.AnswerBTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                Project.AnswerCTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                Project.AnswerDTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
                Project.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\A_BLACK.png")
                Project.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\B_BLACK.png")
                Project.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\C_BLACK.png")
                Project.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\D_BLACK.png")
                Audience.QuestionTextLabel.Visible = True
                Audience.AnswerATextLabel.Visible = True
                Audience.AnswerBTextLabel.Visible = True
                Audience.AnswerCTextLabel.Visible = True
                Audience.AnswerDTextLabel.Visible = True
                Audience.QuestionFramePictureBox.Visible = True
                Audience.AnswerAFramePictureBox.Visible = True
                Audience.AnswerBFramePictureBox.Visible = True
                Audience.AnswerCFramePictureBox.Visible = True
                Audience.AnswerDFramePictureBox.Visible = True
                StartTimerButton.BackColor = Color.Green
                Audience.ClockPictureBox.Visible = True
                ClockTimer.Start()
                clockFrame = 21
                Audience.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (21).png"
                'Cкрытие таблицы результатов
                Audience.FffResultRow5PictureBox.Visible = False
                Audience.FffResultRow6PictureBox.Visible = False
                Audience.FffResultRow4PictureBox.Visible = False
                Audience.FffResultRow7PictureBox.Visible = False
                Audience.FffResultRow3PictureBox.Visible = False
                Audience.FffResultRow8PictureBox.Visible = False
                Audience.FffResultRow2PictureBox.Visible = False
                Audience.FffResultRow9PictureBox.Visible = False
                Audience.FffResultRow1PictureBox.Visible = False
                Audience.FffResultRow10PictureBox.Visible = False
                Audience.FffResultName5Label.Visible = False
                Audience.FffResultName6Label.Visible = False
                Audience.FffResultName4Label.Visible = False
                Audience.FffResultName7Label.Visible = False
                Audience.FffResultName3Label.Visible = False
                Audience.FffResultName8Label.Visible = False
                Audience.FffResultName2Label.Visible = False
                Audience.FffResultName9Label.Visible = False
                Audience.FffResultName1Label.Visible = False
                Audience.FffResultName10Label.Visible = False
                Audience.FffResultTime5Label.Visible = False
                Audience.FffResultTime6Label.Visible = False
                Audience.FffResultTime4Label.Visible = False
                Audience.FffResultTime7Label.Visible = False
                Audience.FffResultTime3Label.Visible = False
                Audience.FffResultTime8Label.Visible = False
                Audience.FffResultTime2Label.Visible = False
                Audience.FffResultTime9Label.Visible = False
                Audience.FffResultTime1Label.Visible = False
                Audience.FffResultTime10Label.Visible = False
                Audience.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
                CorrectAnswersButton.BackColor = Color.White
                '\Конец скрытия таблицы
            Case Color.Green
                My.Computer.Audio.Play("source\MUSIC\Fastest finger first end.wav")
                Shell("source\BAT\stop_back_music1.bat")
                Project.winampOn = 0
                Audience.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
                ClockTimer.Stop()
                StartTimerButton.BackColor = Color.White
        End Select
    End Sub

    Private Sub ClockTimer_Tick(sender As Object, e As EventArgs) Handles ClockTimer.Tick
        clockFrame = clockFrame + 1
        Audience.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        If clockFrame = 61 Then
            ClockTimer.Stop()
            Audience.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (61).png"
            Project.winampOn = 0
            StartTimerButton.BackColor = Color.White
        End If
    End Sub

    Private Sub RightOrderButton_Click(sender As Object, e As EventArgs) Handles RightOrderButton.Click
        'Right order
        Audience.ClockPictureBox.Visible = False
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        'Cкрытие таблицы результатов
        Audience.FffResultRow5PictureBox.Visible = False
        Audience.FffResultRow6PictureBox.Visible = False
        Audience.FffResultRow4PictureBox.Visible = False
        Audience.FffResultRow7PictureBox.Visible = False
        Audience.FffResultRow3PictureBox.Visible = False
        Audience.FffResultRow8PictureBox.Visible = False
        Audience.FffResultRow2PictureBox.Visible = False
        Audience.FffResultRow9PictureBox.Visible = False
        Audience.FffResultRow1PictureBox.Visible = False
        Audience.FffResultRow10PictureBox.Visible = False
        Audience.FffResultName5Label.Visible = False
        Audience.FffResultName6Label.Visible = False
        Audience.FffResultName4Label.Visible = False
        Audience.FffResultName7Label.Visible = False
        Audience.FffResultName3Label.Visible = False
        Audience.FffResultName8Label.Visible = False
        Audience.FffResultName2Label.Visible = False
        Audience.FffResultName9Label.Visible = False
        Audience.FffResultName1Label.Visible = False
        Audience.FffResultName10Label.Visible = False
        Audience.FffResultTime5Label.Visible = False
        Audience.FffResultTime6Label.Visible = False
        Audience.FffResultTime4Label.Visible = False
        Audience.FffResultTime7Label.Visible = False
        Audience.FffResultTime3Label.Visible = False
        Audience.FffResultTime8Label.Visible = False
        Audience.FffResultTime2Label.Visible = False
        Audience.FffResultTime9Label.Visible = False
        Audience.FffResultTime1Label.Visible = False
        Audience.FffResultTime10Label.Visible = False
        Audience.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
        CorrectAnswersButton.BackColor = Color.White
        '\Конец скрытия таблицы
        If fourth <> 0 Then
            Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\What's the Order.wav" & Chr(34)
            Shell("source\BAT\run_back_music1.bat " & Project.batFileName)
            Project.winampOn = 1
            Audience.QuestionTextLabel.Visible = False
            Audience.AnswerATextLabel.Visible = False
            Audience.AnswerBTextLabel.Visible = False
            Audience.AnswerCTextLabel.Visible = False
            Audience.AnswerDTextLabel.Visible = False
            Audience.QuestionFramePictureBox.Visible = False
            Audience.AnswerAFramePictureBox.Visible = False
            Audience.AnswerBFramePictureBox.Visible = False
            Audience.AnswerCFramePictureBox.Visible = False
            Audience.AnswerDFramePictureBox.Visible = False
            TodaysNamesButton.BackColor = Color.White
            NameCycleTimer.Stop()
            NameSequenceTimer.Stop()
            TimerTick = 0
            Audience.MoneyTreePictureBox.Visible = False
            Audience.LifelinesPictureBox.Visible = False
            Audience.FffAnswer1FramePictureBox.Visible = False
            Audience.FffAnswer2FramePictureBox.Visible = False
            Audience.FffAnswer3FramePictureBox.Visible = False
            Audience.FffAnswer4FramePictureBox.Visible = False
            Audience.FffAnswer1Label.Visible = False
            Audience.FffAnswer2Label.Visible = False
            Audience.FffAnswer3Label.Visible = False
            Audience.FffAnswer4Label.Visible = False
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\AudienceFFF2.png")
            Audience.FffQuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
            Audience.FffQuestionTextLabel.Visible = True
            orderDemo = True
        Else
            Project.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\A_BLACK.png")
            Project.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\B_BLACK.png")
            Project.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\C_BLACK.png")
            Project.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\D_BLACK.png")
            Project.AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
            Project.AnswerATextLabel.ForeColor = Color.White
            Project.AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
            Project.AnswerBTextLabel.ForeColor = Color.White
            Project.AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
            Project.AnswerCTextLabel.ForeColor = Color.White
            Project.AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
            Project.AnswerDTextLabel.ForeColor = Color.White
            Select Case first
                Case 1
                    Project.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\A_GREEN.png")
                    Project.AnswerATextLabel.BackColor = Color.FromArgb(93, 179, 87)
                    Project.AnswerATextLabel.ForeColor = Color.Black
                Case 2
                    Project.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\B_GREEN.png")
                    Project.AnswerBTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                    Project.AnswerBTextLabel.ForeColor = Color.Black
                Case 3
                    Project.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\C_GREEN.png")
                    Project.AnswerCTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                    Project.AnswerCTextLabel.ForeColor = Color.Black
                Case 4
                    Project.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\D_GREEN.png")
                    Project.AnswerDTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                    Project.AnswerDTextLabel.ForeColor = Color.Black
            End Select
            If Project.winampOn <> 0 Then
                Shell("source\BAT\stop_back_music1.bat")
                Project.winampOn = 0
            End If
            My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
        End If
    End Sub

    Private Sub RightOrder1Button_Click(sender As Object, e As EventArgs) Handles RightOrder1Button.Click
        '1st answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\1st in Order.wav")
            Audience.FffAnswer1FramePictureBox.Visible = True
            Audience.FffAnswer1Label.Visible = True
            Select Case first
                Case 1
                    Audience.FffAnswer1FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_A.png")
                    Audience.FffAnswer1Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                Case 2
                    Audience.FffAnswer1FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_B.png")
                    Audience.FffAnswer1Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                Case 3
                    Audience.FffAnswer1FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_C.png")
                    Audience.FffAnswer1Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                Case 4
                    Audience.FffAnswer1FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_D.png")
                    Audience.FffAnswer1Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub RightOrder2Button_Click(sender As Object, e As EventArgs) Handles RightOrder2Button.Click
        '2nd answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\2nd in Order.wav")
            Audience.FffAnswer2FramePictureBox.Visible = True
            Audience.FffAnswer2Label.Visible = True
            Select Case second
                Case 1
                    Audience.FffAnswer2FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_A.png")
                    Audience.FffAnswer2Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                Case 2
                    Audience.FffAnswer2FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_B.png")
                    Audience.FffAnswer2Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                Case 3
                    Audience.FffAnswer2FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_C.png")
                    Audience.FffAnswer2Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                Case 4
                    Audience.FffAnswer2FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_D.png")
                    Audience.FffAnswer2Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub RightOrder3Button_Click(sender As Object, e As EventArgs) Handles RightOrder3Button.Click
        '3rd answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\3rd in Order.wav")
            Audience.FffAnswer3FramePictureBox.Visible = True
            Audience.FffAnswer3Label.Visible = True
            Select Case third
                Case 1
                    Audience.FffAnswer3FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_A.png")
                    Audience.FffAnswer3Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                Case 2
                    Audience.FffAnswer3FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_B.png")
                    Audience.FffAnswer3Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                Case 3
                    Audience.FffAnswer3FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_C.png")
                    Audience.FffAnswer3Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                Case 4
                    Audience.FffAnswer3FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_D.png")
                    Audience.FffAnswer3Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub RightOrder4Button_Click(sender As Object, e As EventArgs) Handles RightOrder4Button.Click
        '4th answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\4th in Order.wav")
            Audience.FffAnswer4FramePictureBox.Visible = True
            Audience.FffAnswer4Label.Visible = True
            Select Case fourth
                Case 1
                    Audience.FffAnswer4FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_A.png")
                    Audience.FffAnswer4Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                Case 2
                    Audience.FffAnswer4FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_B.png")
                    Audience.FffAnswer4Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                Case 3
                    Audience.FffAnswer4FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_C.png")
                    Audience.FffAnswer4Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                Case 4
                    Audience.FffAnswer4FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_D.png")
                    Audience.FffAnswer4Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub CorrectAnswersButton_Click(sender As Object, e As EventArgs) Handles CorrectAnswersButton.Click
        'Show the correct answered contestants
        orderDemo = False
        winTime = 20.0
        If ContestantFieldTextBox25.Text = Nothing Then ContestantFieldTextBox25.Text = "0"
        If ContestantFieldTextBox26.Text = Nothing Then ContestantFieldTextBox26.Text = "0"
        If ContestantFieldTextBox24.Text = Nothing Then ContestantFieldTextBox24.Text = "0"
        If ContestantFieldTextBox27.Text = Nothing Then ContestantFieldTextBox27.Text = "0"
        If ContestantFieldTextBox23.Text = Nothing Then ContestantFieldTextBox23.Text = "0"
        If ContestantFieldTextBox28.Text = Nothing Then ContestantFieldTextBox28.Text = "0"
        If ContestantFieldTextBox22.Text = Nothing Then ContestantFieldTextBox22.Text = "0"
        If ContestantFieldTextBox29.Text = Nothing Then ContestantFieldTextBox29.Text = "0"
        If ContestantFieldTextBox21.Text = Nothing Then ContestantFieldTextBox21.Text = "0"
        If ContestantFieldTextBox30.Text = Nothing Then ContestantFieldTextBox30.Text = "0"
        Select Case CorrectAnswersButton.BackColor
            Case Color.White 'Показ таблицы
                CorrectAnswersButton.BackColor = Color.Gold
                Audience.QuestionFramePictureBox.Visible = False
                Audience.AnswerAFramePictureBox.Visible = False
                Audience.AnswerBFramePictureBox.Visible = False
                Audience.AnswerCFramePictureBox.Visible = False
                Audience.AnswerDFramePictureBox.Visible = False
                Audience.QuestionTextLabel.Visible = False
                Audience.AnswerATextLabel.Visible = False
                Audience.AnswerBTextLabel.Visible = False
                Audience.AnswerCTextLabel.Visible = False
                Audience.AnswerDTextLabel.Visible = False
                TodaysNamesButton.BackColor = Color.White
                NameCycleTimer.Stop()
                NameSequenceTimer.Stop()
                TimerTick = 0
                Audience.ContestantNameLabel.Visible = False
                Audience.ContestantTownLabel.Visible = False
                Audience.ContestantNameLabel.Visible = False
                Audience.ContestantTownLabel.Visible = False
                Audience.FffQuestionTextLabel.Visible = False
                Audience.FffAnswer1Label.Visible = False
                Audience.FffAnswer2Label.Visible = False
                Audience.FffAnswer3Label.Visible = False
                Audience.FffAnswer4Label.Visible = False
                Audience.FffAnswer1FramePictureBox.Visible = False
                Audience.FffAnswer2FramePictureBox.Visible = False
                Audience.FffAnswer3FramePictureBox.Visible = False
                Audience.FffAnswer4FramePictureBox.Visible = False
                Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\bg.jpg")
                Audience.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultTime10Label.Text = Nothing
                'Отбор имён
                If ContestantFieldTextBox5.Text <> Nothing Then
                    Audience.FffResultRow5PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow5PictureBox.Visible = True
                    Audience.FffResultName5Label.Visible = True
                    Audience.FffResultName5Label.Text = ContestantFieldTextBox5.Text
                    Audience.FffResultTime5Label.Text = ContestantFieldTextBox25.Text
                End If
                If ContestantFieldTextBox6.Text <> Nothing Then
                    Audience.FffResultRow6PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow6PictureBox.Visible = True
                    Audience.FffResultName6Label.Visible = True
                    Audience.FffResultName6Label.Text = ContestantFieldTextBox6.Text
                    Audience.FffResultTime6Label.Text = ContestantFieldTextBox26.Text
                End If
                If ContestantFieldTextBox4.Text <> Nothing Then
                    Audience.FffResultRow4PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow4PictureBox.Visible = True
                    Audience.FffResultName4Label.Visible = True
                    Audience.FffResultName4Label.Text = ContestantFieldTextBox4.Text
                    Audience.FffResultTime4Label.Text = ContestantFieldTextBox24.Text
                End If
                If ContestantFieldTextBox7.Text <> Nothing Then
                    Audience.FffResultRow7PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow7PictureBox.Visible = True
                    Audience.FffResultName7Label.Visible = True
                    Audience.FffResultName7Label.Text = ContestantFieldTextBox7.Text
                    Audience.FffResultTime7Label.Text = ContestantFieldTextBox27.Text
                End If
                If ContestantFieldTextBox3.Text <> Nothing Then
                    Audience.FffResultRow3PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow3PictureBox.Visible = True
                    Audience.FffResultName3Label.Visible = True
                    Audience.FffResultName3Label.Text = ContestantFieldTextBox3.Text
                    Audience.FffResultTime3Label.Text = ContestantFieldTextBox23.Text
                End If
                If ContestantFieldTextBox8.Text <> Nothing Then
                    Audience.FffResultRow8PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow8PictureBox.Visible = True
                    Audience.FffResultName8Label.Visible = True
                    Audience.FffResultName8Label.Text = ContestantFieldTextBox8.Text
                    Audience.FffResultTime8Label.Text = ContestantFieldTextBox28.Text
                End If
                If ContestantFieldTextBox2.Text <> Nothing Then
                    Audience.FffResultRow2PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow2PictureBox.Visible = True
                    Audience.FffResultName2Label.Visible = True
                    Audience.FffResultName2Label.Text = ContestantFieldTextBox2.Text
                    Audience.FffResultTime2Label.Text = ContestantFieldTextBox22.Text
                End If
                If ContestantFieldTextBox9.Text <> Nothing Then
                    Audience.FffResultRow9PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow9PictureBox.Visible = True
                    Audience.FffResultName9Label.Visible = True
                    Audience.FffResultName9Label.Text = ContestantFieldTextBox9.Text
                    Audience.FffResultTime9Label.Text = ContestantFieldTextBox29.Text
                End If
                If ContestantFieldTextBox1.Text <> Nothing Then
                    Audience.FffResultRow1PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow1PictureBox.Visible = True
                    Audience.FffResultName1Label.Visible = True
                    Audience.FffResultName1Label.Text = ContestantFieldTextBox1.Text
                    Audience.FffResultTime1Label.Text = ContestantFieldTextBox21.Text
                End If
                If ContestantFieldTextBox10.Text <> Nothing Then
                    Audience.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                    Audience.FffResultRow10PictureBox.Visible = True
                    Audience.FffResultName10Label.Visible = True
                    Audience.FffResultName10Label.Text = ContestantFieldTextBox10.Text
                    Audience.FffResultTime10Label.Text = ContestantFieldTextBox30.Text
                End If
            Case Color.Gold 'Показ результатов
                CorrectAnswersButton.BackColor = Color.Green
                If ContestantFieldTextBox25.Text = 0 And ContestantFieldTextBox26.Text = 0 And ContestantFieldTextBox24.Text = 0 And ContestantFieldTextBox27.Text = 0 And ContestantFieldTextBox23.Text = 0 And ContestantFieldTextBox28.Text = 0 And ContestantFieldTextBox22.Text = 0 And ContestantFieldTextBox29.Text = 0 And ContestantFieldTextBox21.Text = 0 And ContestantFieldTextBox30.Text = 0 Then
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Whoosh.wav" & Chr(34)
                    Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
                    QualifyingWinnerButton.Enabled = False
                    AskQuestionButton.BackColor = Color.Gold
                Else
                    Project.batFileName = Chr(34) & Project.sourcePath & "\MUSIC\Correct Answers.wav" & Chr(34)
                    Shell("source\BAT\run2_back_music1.bat " & Project.batFileName)
                    Timer2tick = 0
                    ResultsRevealTimer.Start()
                    QualifyingWinnerButton.BackColor = Color.Gold
                End If
            Case Color.Green
                'Cкрытие таблицы результатов
                Audience.FffResultRow5PictureBox.Visible = False
                Audience.FffResultRow6PictureBox.Visible = False
                Audience.FffResultRow4PictureBox.Visible = False
                Audience.FffResultRow7PictureBox.Visible = False
                Audience.FffResultRow3PictureBox.Visible = False
                Audience.FffResultRow8PictureBox.Visible = False
                Audience.FffResultRow2PictureBox.Visible = False
                Audience.FffResultRow9PictureBox.Visible = False
                Audience.FffResultRow1PictureBox.Visible = False
                Audience.FffResultRow10PictureBox.Visible = False
                Audience.FffResultName5Label.Visible = False
                Audience.FffResultName6Label.Visible = False
                Audience.FffResultName4Label.Visible = False
                Audience.FffResultName7Label.Visible = False
                Audience.FffResultName3Label.Visible = False
                Audience.FffResultName8Label.Visible = False
                Audience.FffResultName2Label.Visible = False
                Audience.FffResultName9Label.Visible = False
                Audience.FffResultName1Label.Visible = False
                Audience.FffResultName10Label.Visible = False
                Audience.FffResultTime5Label.Visible = False
                Audience.FffResultTime6Label.Visible = False
                Audience.FffResultTime4Label.Visible = False
                Audience.FffResultTime7Label.Visible = False
                Audience.FffResultTime3Label.Visible = False
                Audience.FffResultTime8Label.Visible = False
                Audience.FffResultTime2Label.Visible = False
                Audience.FffResultTime9Label.Visible = False
                Audience.FffResultTime1Label.Visible = False
                Audience.FffResultTime10Label.Visible = False
                CorrectAnswersButton.BackColor = Color.White
        End Select
    End Sub

    Private Sub ResultsRevealTimer_Tick(sender As Object, e As EventArgs) Handles ResultsRevealTimer.Tick
        'Таймер показа результатов
        Timer2tick = Timer2tick + 1
        Select Case Timer2tick
            Case 1
                If ContestantFieldTextBox30.Text <> "0" Then
                    Audience.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName10Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime10Label.BackColor = Color.FromArgb(96, 182, 90)
                    time1 = ContestantFieldTextBox30.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime10Label.Text = ContestantFieldTextBox30.Text
                    Audience.FffResultTime10Label.Visible = True
                End If
            Case 2
                If ContestantFieldTextBox29.Text <> "0" Then
                    Audience.FffResultRow9PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName9Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime9Label.BackColor = Color.FromArgb(96, 182, 90)
                    time2 = ContestantFieldTextBox29.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime9Label.Text = ContestantFieldTextBox29.Text
                    Audience.FffResultTime9Label.Visible = True
                End If
            Case 3
                If ContestantFieldTextBox28.Text <> "0" Then
                    Audience.FffResultRow8PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName8Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime8Label.BackColor = Color.FromArgb(96, 182, 90)
                    time3 = ContestantFieldTextBox28.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime8Label.Text = ContestantFieldTextBox28.Text
                    Audience.FffResultTime8Label.Visible = True
                End If
            Case 4
                If ContestantFieldTextBox27.Text <> "0" Then
                    Audience.FffResultRow7PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName7Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime7Label.BackColor = Color.FromArgb(96, 182, 90)
                    time4 = ContestantFieldTextBox27.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime7Label.Text = ContestantFieldTextBox27.Text
                    Audience.FffResultTime7Label.Visible = True
                End If
            Case 5
                If ContestantFieldTextBox26.Text <> "0" Then
                    Audience.FffResultRow6PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName6Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime6Label.BackColor = Color.FromArgb(96, 182, 90)
                    time5 = ContestantFieldTextBox26.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime6Label.Text = ContestantFieldTextBox26.Text
                    Audience.FffResultTime6Label.Visible = True
                End If
            Case 6
                If ContestantFieldTextBox25.Text <> "0" Then
                    Audience.FffResultRow5PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName5Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime5Label.BackColor = Color.FromArgb(96, 182, 90)
                    time6 = ContestantFieldTextBox25.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime5Label.Text = ContestantFieldTextBox25.Text
                    Audience.FffResultTime5Label.Visible = True
                End If
            Case 7
                If ContestantFieldTextBox24.Text <> "0" Then
                    Audience.FffResultRow4PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName4Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime4Label.BackColor = Color.FromArgb(96, 182, 90)
                    time7 = ContestantFieldTextBox24.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime4Label.Text = ContestantFieldTextBox24.Text
                    Audience.FffResultTime4Label.Visible = True
                End If
            Case 8
                If ContestantFieldTextBox23.Text <> "0" Then
                    Audience.FffResultRow3PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName3Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime3Label.BackColor = Color.FromArgb(96, 182, 90)
                    time8 = ContestantFieldTextBox23.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime3Label.Text = ContestantFieldTextBox23.Text
                    Audience.FffResultTime3Label.Visible = True
                End If
            Case 9
                If ContestantFieldTextBox22.Text <> "0" Then
                    Audience.FffResultRow2PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName2Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime2Label.BackColor = Color.FromArgb(96, 182, 90)
                    time9 = ContestantFieldTextBox22.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime2Label.Text = ContestantFieldTextBox22.Text
                    Audience.FffResultTime2Label.Visible = True
                End If
            Case 10
                If ContestantFieldTextBox21.Text <> "0" Then
                    Audience.FffResultRow1PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                    Audience.FffResultName1Label.BackColor = Color.FromArgb(96, 182, 90)
                    Audience.FffResultTime1Label.BackColor = Color.FromArgb(96, 182, 90)
                    time10 = ContestantFieldTextBox21.Text
                    If TwoWinnersCheckBox.Checked = False Then 'Один победитель
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
                    Audience.FffResultTime1Label.Text = ContestantFieldTextBox21.Text
                    Audience.FffResultTime1Label.Visible = True
                End If
                    ResultsRevealTimer.Stop()
                    WinnerRevealTimer.Start()
        End Select
    End Sub

    Private Sub WinnerRevealTimer_Tick(sender As Object, e As EventArgs) Handles WinnerRevealTimer.Tick
        'Выявление победителя
        If winLine = False Then
            If time6 = winTime Or time6 = winTime2 Then
                Audience.FffResultRow5PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName5Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime5Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time5 = winTime Or time5 = winTime2 Then
                Audience.FffResultRow6PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName6Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime6Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time7 = winTime Or time7 = winTime2 Then
                Audience.FffResultRow4PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName4Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime4Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time4 = winTime Or time4 = winTime2 Then
                Audience.FffResultRow7PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName7Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime7Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time8 = winTime Or time8 = winTime2 Then
                Audience.FffResultRow3PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName3Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime3Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time3 = winTime Or time3 = winTime2 Then
                Audience.FffResultRow8PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName8Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime8Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time9 = winTime Or time9 = winTime2 Then
                Audience.FffResultRow2PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName2Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime2Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time2 = winTime Or time2 = winTime2 Then
                Audience.FffResultRow9PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName9Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime9Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time10 = winTime Or time10 = winTime2 Then
                Audience.FffResultRow1PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName1Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime1Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time1 = winTime Or time1 = winTime2 Then
                Audience.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
                Audience.FffResultName10Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime10Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            winLine = True
        Else
            If time6 = winTime Or time6 = winTime2 Then
                Audience.FffResultRow5PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time5 = winTime Or time5 = winTime2 Then
                Audience.FffResultRow6PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time7 = winTime Or time7 = winTime2 Then
                Audience.FffResultRow4PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time4 = winTime Or time4 = winTime2 Then
                Audience.FffResultRow7PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time8 = winTime Or time8 = winTime2 Then
                Audience.FffResultRow3PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time3 = winTime Or time3 = winTime2 Then
                Audience.FffResultRow8PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time9 = winTime Or time9 = winTime2 Then
                Audience.FffResultRow2PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time2 = winTime Or time2 = winTime2 Then
                Audience.FffResultRow9PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time10 = winTime Or time10 = winTime2 Then
                Audience.FffResultRow1PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time1 = winTime Or time1 = winTime2 Then
                Audience.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG1.png")
                Audience.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
                Audience.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            winLine = False
        End If
    End Sub

    Private Sub QualifyingWinnerButton_Click(sender As Object, e As EventArgs) Handles QualifyingWinnerButton.Click
        'Qualifying winner
        If CorrectAnswersButton.BackColor <> Color.Gold Then
            orderDemo = False
            QualifyingWinnerButton.BackColor = Color.White
            WinnerRevealTimer.Stop()
            'Cкрытие таблицы результатов
            Audience.FffResultRow5PictureBox.Visible = False
            Audience.FffResultRow6PictureBox.Visible = False
            Audience.FffResultRow4PictureBox.Visible = False
            Audience.FffResultRow7PictureBox.Visible = False
            Audience.FffResultRow3PictureBox.Visible = False
            Audience.FffResultRow8PictureBox.Visible = False
            Audience.FffResultRow2PictureBox.Visible = False
            If TwoWinnersCheckBox.Checked = False Then Audience.FffResultRow9PictureBox.Visible = False
            Audience.FffResultRow1PictureBox.Visible = False
            'Audience.FffResultRow10PictureBox.Visible = False
            Audience.FffResultName5Label.Visible = False
            Audience.FffResultName6Label.Visible = False
            Audience.FffResultName4Label.Visible = False
            Audience.FffResultName7Label.Visible = False
            Audience.FffResultName3Label.Visible = False
            Audience.FffResultName8Label.Visible = False
            Audience.FffResultName2Label.Visible = False
            If TwoWinnersCheckBox.Checked = False Then Audience.FffResultName9Label.Visible = False
            Audience.FffResultName1Label.Visible = False
            'Audience.FffResultName10Label.Visible = False
            Audience.FffResultTime5Label.Visible = False
            Audience.FffResultTime6Label.Visible = False
            Audience.FffResultTime4Label.Visible = False
            Audience.FffResultTime7Label.Visible = False
            Audience.FffResultTime3Label.Visible = False
            Audience.FffResultTime8Label.Visible = False
            Audience.FffResultTime2Label.Visible = False
            If TwoWinnersCheckBox.Checked = False Then Audience.FffResultTime9Label.Visible = False
            Audience.FffResultTime1Label.Visible = False
            'Audience.FffResultTime10Label.Visible = False
            Audience.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
            If TwoWinnersCheckBox.Checked = False Then Audience.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
            'Audience.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
            If TwoWinnersCheckBox.Checked = False Then Audience.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
            Audience.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
            'Audience.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
            '\Конец скрытия таблицы
            Audience.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\FFF\FFF_LOZENG2.png")
            If time6 = winTime Then
                Audience.FffResultName10Label.Text = Audience.FffResultName5Label.Text
                Audience.FffResultTime10Label.Text = Audience.FffResultTime5Label.Text
            End If
            If time5 = winTime Then
                Audience.FffResultName10Label.Text = Audience.FffResultName6Label.Text
                Audience.FffResultTime10Label.Text = Audience.FffResultTime6Label.Text
                winners = winners + 1
            End If
            If time7 = winTime Then
                Audience.FffResultName10Label.Text = Audience.FffResultName4Label.Text
                Audience.FffResultTime10Label.Text = Audience.FffResultTime4Label.Text
            End If
            If time4 = winTime Then
                Audience.FffResultName10Label.Text = Audience.FffResultName7Label.Text
                Audience.FffResultTime10Label.Text = Audience.FffResultTime7Label.Text
            End If
            If time8 = winTime Then
                Audience.FffResultName10Label.Text = Audience.FffResultName3Label.Text
                Audience.FffResultTime10Label.Text = Audience.FffResultTime3Label.Text
            End If
            If time3 = winTime Then
                Audience.FffResultName10Label.Text = Audience.FffResultName8Label.Text
                Audience.FffResultTime10Label.Text = Audience.FffResultTime8Label.Text
            End If
            If time9 = winTime Then
                Audience.FffResultName10Label.Text = Audience.FffResultName2Label.Text
                Audience.FffResultTime10Label.Text = Audience.FffResultTime2Label.Text
            End If
            If time2 = winTime Then
                Audience.FffResultName10Label.Text = Audience.FffResultName9Label.Text
                Audience.FffResultTime10Label.Text = Audience.FffResultTime9Label.Text
            End If
            If time10 = winTime Then
                Audience.FffResultName10Label.Text = Audience.FffResultName1Label.Text
                Audience.FffResultTime10Label.Text = Audience.FffResultTime1Label.Text
            End If
            Audience.FffResultName10Label.BackColor = Color.FromArgb(96, 182, 90)
            Audience.FffResultTime10Label.BackColor = Color.FromArgb(96, 182, 90)
            Audience.FffResultRow10PictureBox.Visible = True
            Audience.FffResultName10Label.Visible = True
            Audience.FffResultTime10Label.Visible = True
            If TwoWinnersCheckBox.Checked = True Then
                If time6 = winTime2 Then
                    Audience.FffResultName9Label.Text = Audience.FffResultName5Label.Text
                    Audience.FffResultTime9Label.Text = Audience.FffResultTime5Label.Text
                End If
                If time5 = winTime2 Then
                    Audience.FffResultName9Label.Text = Audience.FffResultName6Label.Text
                    Audience.FffResultTime9Label.Text = Audience.FffResultTime6Label.Text
                    winners = winners + 1
                End If
                If time7 = winTime2 Then
                    Audience.FffResultName9Label.Text = Audience.FffResultName4Label.Text
                    Audience.FffResultTime9Label.Text = Audience.FffResultTime4Label.Text
                End If
                If time4 = winTime2 Then
                    Audience.FffResultName9Label.Text = Audience.FffResultName7Label.Text
                    Audience.FffResultTime9Label.Text = Audience.FffResultTime7Label.Text
                End If
                If time8 = winTime2 Then
                    Audience.FffResultName9Label.Text = Audience.FffResultName3Label.Text
                    Audience.FffResultTime9Label.Text = Audience.FffResultTime3Label.Text
                End If
                If time3 = winTime2 Then
                    Audience.FffResultName9Label.Text = Audience.FffResultName8Label.Text
                    Audience.FffResultTime9Label.Text = Audience.FffResultTime8Label.Text
                End If
                If time9 = winTime2 Then
                    Audience.FffResultName9Label.Text = Audience.FffResultName2Label.Text
                    Audience.FffResultTime9Label.Text = Audience.FffResultTime2Label.Text
                End If
                If time10 = winTime2 Then
                    Audience.FffResultName9Label.Text = Audience.FffResultName1Label.Text
                    Audience.FffResultTime9Label.Text = Audience.FffResultTime1Label.Text
                End If
                If time1 = winTime2 Then
                    Audience.FffResultName9Label.Text = Audience.FffResultName10Label.Text
                    Audience.FffResultTime9Label.Text = Audience.FffResultTime10Label.Text
                End If
                Audience.FffResultName9Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultTime9Label.BackColor = Color.FromArgb(96, 182, 90)
                Audience.FffResultRow9PictureBox.Visible = True
                Audience.FffResultName9Label.Visible = True
                Audience.FffResultTime9Label.Visible = True
            End If
            Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
            Project.ContestantNameTextBox.Text = Audience.FffResultName10Label.Text
            'Удаление победителя из списка
            If DropWinnerCheckBox.Checked = True Then
                If ContestantFieldTextBox1.Text <> Audience.FffResultName10Label.Text Then
                    If ContestantFieldTextBox2.Text <> Audience.FffResultName10Label.Text Then
                        If ContestantFieldTextBox3.Text <> Audience.FffResultName10Label.Text Then
                            If ContestantFieldTextBox4.Text <> Audience.FffResultName10Label.Text Then
                                If ContestantFieldTextBox5.Text <> Audience.FffResultName10Label.Text Then
                                    If ContestantFieldTextBox6.Text <> Audience.FffResultName10Label.Text Then
                                        If ContestantFieldTextBox7.Text <> Audience.FffResultName10Label.Text Then
                                            If ContestantFieldTextBox8.Text <> Audience.FffResultName10Label.Text Then
                                                If ContestantFieldTextBox9.Text <> Audience.FffResultName10Label.Text Then
                                                    If ContestantFieldTextBox10.Text = Audience.FffResultName10Label.Text Then ContestantFieldTextBox10.Text = Nothing
                                                Else
                                                    ContestantFieldTextBox9.Text = Nothing
                                                End If
                                            Else
                                                ContestantFieldTextBox8.Text = Nothing
                                            End If
                                        Else
                                            ContestantFieldTextBox7.Text = Nothing
                                        End If
                                    Else
                                        ContestantFieldTextBox6.Text = Nothing
                                    End If
                                Else
                                    ContestantFieldTextBox5.Text = Nothing
                                End If
                            Else
                                ContestantFieldTextBox4.Text = Nothing
                            End If
                        Else
                            ContestantFieldTextBox3.Text = Nothing
                        End If
                    Else
                        ContestantFieldTextBox2.Text = Nothing
                    End If
                Else
                    ContestantFieldTextBox1.Text = Nothing
                End If
                ContestantFieldTextBox1.Focus()
                QualifyingWinnerButton.Focus()
                FileClose(1)
                FileOpen(1, OpenContestantsListDialog.FileName, OpenMode.Output)
                Dim n As Integer = 1
                If ContestantFieldTextBox1.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox1.Text & "|" & ContestantFieldTextBox11.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If ContestantFieldTextBox2.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox2.Text & "|" & ContestantFieldTextBox12.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If ContestantFieldTextBox3.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox3.Text & "|" & ContestantFieldTextBox13.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If ContestantFieldTextBox4.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox4.Text & "|" & ContestantFieldTextBox14.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If ContestantFieldTextBox5.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox5.Text & "|" & ContestantFieldTextBox15.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If ContestantFieldTextBox6.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox6.Text & "|" & ContestantFieldTextBox16.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If ContestantFieldTextBox7.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox7.Text & "|" & ContestantFieldTextBox17.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If ContestantFieldTextBox8.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox8.Text & "|" & ContestantFieldTextBox18.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If ContestantFieldTextBox9.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox9.Text & "|" & ContestantFieldTextBox19.Text & "|0|" & Chr(13) & Chr(10))
                    n = n + 1
                End If
                If ContestantFieldTextBox10.Text <> Nothing Then
                    Print(1, "|" & n & "|" & ContestantFieldTextBox10.Text & "|" & ContestantFieldTextBox20.Text & "|0|" & Chr(13) & Chr(10))
                End If
                FileClose(1)
            End If
            CorrectAnswersButton.BackColor = Color.White
            My.Computer.Audio.Play("source\MUSIC\Qualifying Winner.wav")
        End If
    End Sub

    Private Sub FormFFF_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        'Cкрытие таблицы результатов
        Audience.FffResultRow5PictureBox.Visible = False
        Audience.FffResultRow6PictureBox.Visible = False
        Audience.FffResultRow4PictureBox.Visible = False
        Audience.FffResultRow7PictureBox.Visible = False
        Audience.FffResultRow3PictureBox.Visible = False
        Audience.FffResultRow8PictureBox.Visible = False
        Audience.FffResultRow2PictureBox.Visible = False
        Audience.FffResultRow9PictureBox.Visible = False
        Audience.FffResultRow1PictureBox.Visible = False
        Audience.FffResultRow10PictureBox.Visible = False
        Audience.FffResultName5Label.Visible = False
        Audience.FffResultName6Label.Visible = False
        Audience.FffResultName4Label.Visible = False
        Audience.FffResultName7Label.Visible = False
        Audience.FffResultName3Label.Visible = False
        Audience.FffResultName8Label.Visible = False
        Audience.FffResultName2Label.Visible = False
        Audience.FffResultName9Label.Visible = False
        Audience.FffResultName1Label.Visible = False
        Audience.FffResultName10Label.Visible = False
        Audience.FffResultTime5Label.Visible = False
        Audience.FffResultTime6Label.Visible = False
        Audience.FffResultTime4Label.Visible = False
        Audience.FffResultTime7Label.Visible = False
        Audience.FffResultTime3Label.Visible = False
        Audience.FffResultTime8Label.Visible = False
        Audience.FffResultTime2Label.Visible = False
        Audience.FffResultTime9Label.Visible = False
        Audience.FffResultTime1Label.Visible = False
        Audience.FffResultTime10Label.Visible = False
        Audience.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
        Audience.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
        '\Конец скрытия таблицы
        Audience.ContestantNameLabel.Visible = False
        Audience.ContestantTownLabel.Visible = False
        Audience.FffQuestionTextLabel.Visible = False
        Audience.FffAnswer1Label.Visible = False
        Audience.FffAnswer2Label.Visible = False
        Audience.FffAnswer3Label.Visible = False
        Audience.FffAnswer4Label.Visible = False
        Audience.FffAnswer1FramePictureBox.Visible = False
        Audience.FffAnswer2FramePictureBox.Visible = False
        Audience.FffAnswer3FramePictureBox.Visible = False
        Audience.FffAnswer4FramePictureBox.Visible = False
        Audience.LogoPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LOGO_FEEL.png")
        Audience.LogoPictureBox.Visible = False
        Project.ToggleLogoButton.BackColor = Color.White
        Project.QuestionTextLabel.Text = ""
        Project.AnswerATextLabel.Text = ""
        Project.AnswerBTextLabel.Text = ""
        Project.AnswerCTextLabel.Text = ""
        Project.AnswerDTextLabel.Text = ""
        Audience.QuestionTextLabel.Visible = True
        Audience.AnswerATextLabel.Visible = True
        Audience.AnswerBTextLabel.Visible = True
        Audience.AnswerCTextLabel.Visible = True
        Audience.AnswerDTextLabel.Visible = True
        Audience.QuestionFramePictureBox.Visible = True
        Audience.AnswerAFramePictureBox.Visible = True
        Audience.AnswerBFramePictureBox.Visible = True
        Audience.AnswerCFramePictureBox.Visible = True
        Audience.AnswerDFramePictureBox.Visible = True
        Audience.MoneyTreePictureBox.Visible = True
        Audience.LifelinesPictureBox.Visible = True
        Audience.ClockPictureBox.Visible = False
        Project.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LEFT.png")
        Project.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\RIGHT.png")
        Project.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\LEFT.png")
        Project.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\RIGHT.png")
        Audience.BackgroundImage = System.Drawing.Bitmap.FromFile(Project.langSource & "\BG4.jpg")
        Project.FastestFingerFirstButton.BackColor = Color.White
        Project.LetsPlayButton.BackColor = Color.FromArgb(255, 128, 128)
        If Project.splashOn = False Then
            Project.ToggleLogoButton.PerformClick()
            Project.ToggleLogoButton.BackColor = Color.Violet
            Project.splashOn = True
        End If
        Audience.LogoPictureBox.Visible = True
    End Sub
End Class