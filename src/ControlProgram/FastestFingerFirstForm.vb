Public Class FastestFingerFirstForm
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
        GameControlForm.ClearFormsButton.PerformClick()
        OpenQuestionBaseDialog.InitialDirectory = GameControlForm.sourcePath
        If GameControlForm.ini(14) <> Nothing And My.Computer.FileSystem.FileExists(GameControlForm.ini(14)) Then
            OpenQuestionBaseDialog.FileName = GameControlForm.ini(14)
        Else
            OpenQuestionBaseDialog.FileName = "Bases\" & GameControlForm.currentBlock1(2, 3) & "qualify.fff"
        End If
        FileNameQ = OpenQuestionBaseDialog.FileName
        Call openfilesdata(FileNameQ)
        AudienceScreenForm.QuestionTextLabel.Visible = False
        AudienceScreenForm.AnswerATextLabel.Visible = False
        AudienceScreenForm.AnswerBTextLabel.Visible = False
        AudienceScreenForm.AnswerCTextLabel.Visible = False
        AudienceScreenForm.AnswerDTextLabel.Visible = False
        AudienceScreenForm.QuestionFramePictureBox.Visible = False
        AudienceScreenForm.AnswerAFramePictureBox.Visible = False
        AudienceScreenForm.AnswerBFramePictureBox.Visible = False
        AudienceScreenForm.AnswerCFramePictureBox.Visible = False
        AudienceScreenForm.AnswerDFramePictureBox.Visible = False
        AudienceScreenForm.MoneyTreePictureBox.Visible = False
        AudienceScreenForm.LifelinesPictureBox.Visible = False
        'Открытие списка участников
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        i1 = 0
        i0 = 0
        If OpenContestantsListDialog.FileName = Nothing Or My.Computer.FileSystem.FileExists(OpenContestantsListDialog.FileName) = False Then
            If GameControlForm.ini(15) <> Nothing And My.Computer.FileSystem.FileExists(GameControlForm.ini(15)) Then
                OpenContestantsListDialog.FileName = GameControlForm.ini(15)
            Else
                OpenContestantsListDialog.FileName = "Bases\" & GameControlForm.currentBlock1(2, 3) & "contestants.con"
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
        'Перевод "G" FastestFingerFirstForm
        Text = GameControlForm.currentBlock1(123, 3) '0
        OpenQuestionBaseButton.Text = GameControlForm.currentBlock1(124, 3) '1
        OpenContestantsListButton.Text = GameControlForm.currentBlock1(124, 4) '1
        DropWinnerCheckBox.Text = GameControlForm.currentBlock1(124, 5) '1
        TwoWinnersCheckBox.Text = GameControlForm.currentBlock1(124, 6) '1
        TodaysNamesButton.Text = GameControlForm.currentBlock1(125, 3) '2
        ExplainRulesButton.Text = GameControlForm.currentBlock1(126, 3) '3
        AskQuestionButton.Text = GameControlForm.currentBlock1(127, 3) '4
        ThreeBeepsButton.Text = GameControlForm.currentBlock1(128, 3) '5
        StartTimerButton.Text = GameControlForm.currentBlock1(129, 3) '6
        RightOrderButton.Text = GameControlForm.currentBlock1(130, 3) '7 |What's Correct|
        RightOrder1Button.Text = GameControlForm.currentBlock1(131, 3) '8
        RightOrder2Button.Text = GameControlForm.currentBlock1(132, 3) '9
        RightOrder3Button.Text = GameControlForm.currentBlock1(133, 3) '10
        RightOrder4Button.Text = GameControlForm.currentBlock1(134, 3) '11
        CorrectAnswersButton.Text = GameControlForm.currentBlock1(135, 3) '12
        QualifyingWinnerButton.Text = GameControlForm.currentBlock1(136, 3) '13
        FullQuestionTextLabel.Text = GameControlForm.currentBlock1(137, 3) '14
        LeftNameHeaderLabel.Text = GameControlForm.currentBlock1(138, 3) '15
        RightNameHeaderLabel.Text = GameControlForm.currentBlock1(138, 3) '15
        LeftFromHeaderLabel.Text = GameControlForm.currentBlock1(139, 3) '16
        RightFromHeaderLabel.Text = GameControlForm.currentBlock1(139, 3) '16
        LeftTimeHeaderLabel.Text = GameControlForm.currentBlock1(140, 3) '17
        RightTimeHeaderLabel.Text = GameControlForm.currentBlock1(140, 3) '17
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
            QuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & GameControlForm.currentBlock1(144, 3) & " " & first & ", " & second & ", " & third & ", " & fourth
            RightOrderButton.Text = GameControlForm.currentBlock1(130, 3) 'Right Order
        Else
            RightOrder1Button.Enabled = False
            RightOrder2Button.Enabled = False
            RightOrder3Button.Enabled = False
            RightOrder4Button.Enabled = False
            QuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & GameControlForm.currentBlock1(143, 3) & " " & first
            RightOrderButton.Text = GameControlForm.currentBlock1(130, 4) 'What's Correct
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
        FastestFingerEditorForm.Show()
    End Sub

    Private Sub OpenQuestionBaseButton_Click(sender As Object, e As EventArgs) Handles OpenQuestionBaseButton.Click
        'Open base file...
        OpenQuestionBaseDialog.FileName = "*.fff"
        OpenQuestionBaseDialog.InitialDirectory = CurDir() & "\Bases"
        OpenQuestionBaseDialog.CheckFileExists = True
        If OpenQuestionBaseDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenQuestionBaseDialog.FileName
            GameControlForm.ini(14) = FileNameQ
            Call openfilesdata(FileNameQ)
        End If
    End Sub

    Private Sub OpenContestantsListButton_Click(sender As Object, e As EventArgs) Handles OpenContestantsListButton.Click
        'Open contestants list...
        OpenContestantsListDialog.FileName = "*.con"
        OpenContestantsListDialog.InitialDirectory = CurDir() & "\Bases"
        OpenContestantsListDialog.CheckFileExists = True
        If OpenContestantsListDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            GameControlForm.ini(15) = OpenContestantsListDialog.FileName
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
        If GameControlForm.splashOn = False Then
            GameControlForm.ToggleLogoButton.PerformClick()
            GameControlForm.ToggleLogoButton.BackColor = Color.Green
            GameControlForm.splashOn = True
        End If
        AudienceScreenForm.LogoPictureBox.Visible = False
        orderDemo = False
        'Cкрытие таблицы результатов
        AudienceScreenForm.FffResultRow5PictureBox.Visible = False
        AudienceScreenForm.FffResultRow6PictureBox.Visible = False
        AudienceScreenForm.FffResultRow4PictureBox.Visible = False
        AudienceScreenForm.FffResultRow7PictureBox.Visible = False
        AudienceScreenForm.FffResultRow3PictureBox.Visible = False
        AudienceScreenForm.FffResultRow8PictureBox.Visible = False
        AudienceScreenForm.FffResultRow2PictureBox.Visible = False
        AudienceScreenForm.FffResultRow9PictureBox.Visible = False
        AudienceScreenForm.FffResultRow1PictureBox.Visible = False
        AudienceScreenForm.FffResultRow10PictureBox.Visible = False
        AudienceScreenForm.FffResultName5Label.Visible = False
        AudienceScreenForm.FffResultName6Label.Visible = False
        AudienceScreenForm.FffResultName4Label.Visible = False
        AudienceScreenForm.FffResultName7Label.Visible = False
        AudienceScreenForm.FffResultName3Label.Visible = False
        AudienceScreenForm.FffResultName8Label.Visible = False
        AudienceScreenForm.FffResultName2Label.Visible = False
        AudienceScreenForm.FffResultName9Label.Visible = False
        AudienceScreenForm.FffResultName1Label.Visible = False
        AudienceScreenForm.FffResultName10Label.Visible = False
        AudienceScreenForm.FffResultTime5Label.Visible = False
        AudienceScreenForm.FffResultTime6Label.Visible = False
        AudienceScreenForm.FffResultTime4Label.Visible = False
        AudienceScreenForm.FffResultTime7Label.Visible = False
        AudienceScreenForm.FffResultTime3Label.Visible = False
        AudienceScreenForm.FffResultTime8Label.Visible = False
        AudienceScreenForm.FffResultTime2Label.Visible = False
        AudienceScreenForm.FffResultTime9Label.Visible = False
        AudienceScreenForm.FffResultTime1Label.Visible = False
        AudienceScreenForm.FffResultTime10Label.Visible = False
        AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
        CorrectAnswersButton.BackColor = Color.White
        '\Конец скрытия таблицы
        AudienceScreenForm.LogoPictureBox.Visible = False
        AudienceScreenForm.ContestantNameLabel.Visible = False
        AudienceScreenForm.ContestantTownLabel.Visible = False
        AudienceScreenForm.FffQuestionTextLabel.Visible = False
        AudienceScreenForm.FffAnswer1Label.Visible = False
        AudienceScreenForm.FffAnswer2Label.Visible = False
        AudienceScreenForm.FffAnswer3Label.Visible = False
        AudienceScreenForm.FffAnswer4Label.Visible = False
        AudienceScreenForm.QuestionTextLabel.Visible = False
        AudienceScreenForm.AnswerATextLabel.Visible = False
        AudienceScreenForm.AnswerBTextLabel.Visible = False
        AudienceScreenForm.AnswerCTextLabel.Visible = False
        AudienceScreenForm.AnswerDTextLabel.Visible = False
        AudienceScreenForm.QuestionFramePictureBox.Visible = False
        AudienceScreenForm.AnswerAFramePictureBox.Visible = False
        AudienceScreenForm.AnswerBFramePictureBox.Visible = False
        AudienceScreenForm.AnswerCFramePictureBox.Visible = False
        AudienceScreenForm.AnswerDFramePictureBox.Visible = False
        AudienceScreenForm.ClockPictureBox.Visible = False
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        AudienceScreenForm.FffAnswer1FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer2FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer3FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer4FramePictureBox.Visible = False
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
            AudienceScreenForm.ContestantNameLabel.Visible = False
            AudienceScreenForm.ContestantTownLabel.Visible = False
            AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\BG4.jpg")
            Shell("source\BAT\stop_back_music1.bat")
            GameControlForm.winampOn = 0
        Else
            TodaysNamesButton.BackColor = Color.Aqua
            NameCycleTimer.Interval = 3200
            AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\AudienceFFF.png")
            My.Computer.Audio.Stop()
            GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Today's Names with ten.wav" & Chr(34)
            Shell("source\BAT\run2_back_music1.bat " & GameControlForm.batFileName)
            GameControlForm.winampOn = 1
            NameCycleTimer.Start()
            NameSequenceTimer.Start()
            TimerTick = 1
            Select Case NameSequenceTimer.Interval
                Case 23780, 20700
                    AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox2.Text
                    AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox12.Text
                Case 17620, 14540
                    AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox3.Text
                    AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox13.Text
                Case 11460, 8380
                    AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                    AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                Case 5300, 2100
                    AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                    AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                Case Else
                    AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox1.Text
                    AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox11.Text
            End Select
            AudienceScreenForm.ContestantNameLabel.Visible = True
            AudienceScreenForm.ContestantTownLabel.Visible = True
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
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox2.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox12.Text
                        Case 17620, 14540
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox3.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox13.Text
                        Case 11460, 8380
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                        Case 5300, 2100
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                        Case Else
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox1.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox11.Text
                    End Select
                Case 2
                    NameCycleTimer.Interval = 3080
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox3.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox13.Text
                        Case 17620, 14540
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                        Case 11460, 8380
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                        Case 5300
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                        Case Else
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox2.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox12.Text
                    End Select
                Case 3
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                        Case 17620, 14540
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                        Case 11460, 8380
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                        Case Else
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox3.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox13.Text
                    End Select
                Case 4
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                        Case 17620, 14540
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                        Case 11460
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox7.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox17.Text
                        Case Else
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox4.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox14.Text
                    End Select
                Case 5
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                        Case 17620, 14540
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox7.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox17.Text
                        Case Else
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox5.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox15.Text
                    End Select
                Case 6
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox7.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox17.Text
                        Case 17620
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox8.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox18.Text
                        Case Else
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox6.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox16.Text
                    End Select
                Case 7
                    Select Case NameSequenceTimer.Interval
                        Case 23780, 20700
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox8.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox18.Text
                        Case Else
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox7.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox17.Text
                    End Select
                Case 8
                    Select Case NameSequenceTimer.Interval
                        Case 23780
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox9.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox19.Text
                        Case Else
                            AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox8.Text
                            AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox18.Text
                    End Select
                Case 9
                    AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox9.Text
                    AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox19.Text
                Case 10
                    AudienceScreenForm.ContestantNameLabel.Text = ContestantFieldTextBox10.Text
                    AudienceScreenForm.ContestantTownLabel.Text = ContestantFieldTextBox20.Text
            End Select
        Else
            NameCycleTimer.Stop()
            NameSequenceTimer.Stop()
            AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\BG4.jpg")
            AudienceScreenForm.ContestantNameLabel.Visible = False
            AudienceScreenForm.ContestantTownLabel.Visible = False
            TodaysNamesButton.BackColor = Color.White
            GameControlForm.winampOn = 0
            TimerTick = 0
        End If
    End Sub

    Private Sub NameSequenceTimer_Tick(sender As Object, e As EventArgs) Handles NameSequenceTimer.Tick
        NameCycleTimer.Stop()
        NameSequenceTimer.Stop()
        My.Computer.Audio.Play("source\MUSIC\Today's Names end.wav")
        Shell("source\BAT\stop_back_music1.bat")
        GameControlForm.winampOn = 0
        AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\BG4.jpg")
        AudienceScreenForm.ContestantNameLabel.Visible = False
        AudienceScreenForm.ContestantTownLabel.Visible = False
        TodaysNamesButton.BackColor = Color.White
    End Sub

    Private Sub ExplainRulesButton_Click(sender As Object, e As EventArgs) Handles ExplainRulesButton.Click
        'Explain the rules
        If TodaysNamesButton.BackColor = Color.Aqua Then
            NameCycleTimer.Stop()
            TimerTick = 0
            AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\BG4.jpg")
            AudienceScreenForm.ContestantNameLabel.Visible = False
            AudienceScreenForm.ContestantTownLabel.Visible = False
            TodaysNamesButton.BackColor = Color.White
        End If
        AudienceScreenForm.FffQuestionTextLabel.Visible = False
        AudienceScreenForm.FffAnswer1Label.Visible = False
        AudienceScreenForm.FffAnswer2Label.Visible = False
        AudienceScreenForm.FffAnswer3Label.Visible = False
        AudienceScreenForm.FffAnswer4Label.Visible = False
        AudienceScreenForm.FffAnswer1FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer2FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer3FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer4FramePictureBox.Visible = False
        My.Computer.Audio.Play("source\MUSIC\Explain the games.wav")
        rules = True
    End Sub

    Private Sub AskQuestionButton_Click(sender As Object, e As EventArgs) Handles AskQuestionButton.Click
        'Ask question
        If GameControlForm.splashOn = False Then
            GameControlForm.ToggleLogoButton.PerformClick()
            GameControlForm.ToggleLogoButton.BackColor = Color.Green
            GameControlForm.splashOn = True
        End If
        AudienceScreenForm.LogoPictureBox.Visible = False
        orderDemo = False
        QualifyingWinnerButton.Enabled = True
        AudienceScreenForm.ClockPictureBox.Visible = False
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        GameControlForm.ClearFormsButton.PerformClick()
        'Cкрытие таблицы результатов
        AudienceScreenForm.FffResultRow5PictureBox.Visible = False
        AudienceScreenForm.FffResultRow6PictureBox.Visible = False
        AudienceScreenForm.FffResultRow4PictureBox.Visible = False
        AudienceScreenForm.FffResultRow7PictureBox.Visible = False
        AudienceScreenForm.FffResultRow3PictureBox.Visible = False
        AudienceScreenForm.FffResultRow8PictureBox.Visible = False
        AudienceScreenForm.FffResultRow2PictureBox.Visible = False
        AudienceScreenForm.FffResultRow9PictureBox.Visible = False
        AudienceScreenForm.FffResultRow1PictureBox.Visible = False
        AudienceScreenForm.FffResultRow10PictureBox.Visible = False
        AudienceScreenForm.FffResultName5Label.Visible = False
        AudienceScreenForm.FffResultName6Label.Visible = False
        AudienceScreenForm.FffResultName4Label.Visible = False
        AudienceScreenForm.FffResultName7Label.Visible = False
        AudienceScreenForm.FffResultName3Label.Visible = False
        AudienceScreenForm.FffResultName8Label.Visible = False
        AudienceScreenForm.FffResultName2Label.Visible = False
        AudienceScreenForm.FffResultName9Label.Visible = False
        AudienceScreenForm.FffResultName1Label.Visible = False
        AudienceScreenForm.FffResultName10Label.Visible = False
        AudienceScreenForm.FffResultTime5Label.Visible = False
        AudienceScreenForm.FffResultTime6Label.Visible = False
        AudienceScreenForm.FffResultTime4Label.Visible = False
        AudienceScreenForm.FffResultTime7Label.Visible = False
        AudienceScreenForm.FffResultTime3Label.Visible = False
        AudienceScreenForm.FffResultTime8Label.Visible = False
        AudienceScreenForm.FffResultTime2Label.Visible = False
        AudienceScreenForm.FffResultTime9Label.Visible = False
        AudienceScreenForm.FffResultTime1Label.Visible = False
        AudienceScreenForm.FffResultTime10Label.Visible = False
        AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
        CorrectAnswersButton.BackColor = Color.White
        '\Конец скрытия таблицы
        AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\BG4.jpg")
        TodaysNamesButton.BackColor = Color.White
        NameCycleTimer.Stop()
        NameSequenceTimer.Stop()
        TimerTick = 0
        AudienceScreenForm.ContestantNameLabel.Visible = False
        AudienceScreenForm.ContestantTownLabel.Visible = False
        AudienceScreenForm.FffQuestionTextLabel.Visible = False
        AudienceScreenForm.FffAnswer1Label.Visible = False
        AudienceScreenForm.FffAnswer2Label.Visible = False
        AudienceScreenForm.FffAnswer3Label.Visible = False
        AudienceScreenForm.FffAnswer4Label.Visible = False
        AudienceScreenForm.FffAnswer1FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer2FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer3FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer4FramePictureBox.Visible = False
        My.Computer.Audio.Stop()
        If rules = True Then
            My.Computer.Audio.Play("source\MUSIC\Explain the games end.wav")
            rules = False
        End If
        GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Standby for Q.wav" & Chr(34)
        Shell("source\BAT\run2_back_music1.bat " & GameControlForm.batFileName)
        GameControlForm.winampOn = 1
        GameControlForm.QuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
        TodaysNamesButton.BackColor = Color.White
        NameCycleTimer.Stop()
        NameSequenceTimer.Stop()
        TimerTick = 0
        AudienceScreenForm.ContestantNameLabel.Visible = False
        AudienceScreenForm.ContestantTownLabel.Visible = False
        AudienceScreenForm.QuestionTextLabel.Visible = True
        AudienceScreenForm.AnswerATextLabel.Visible = False
        AudienceScreenForm.AnswerBTextLabel.Visible = False
        AudienceScreenForm.AnswerCTextLabel.Visible = False
        AudienceScreenForm.AnswerDTextLabel.Visible = False
        GameControlForm.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\LEFT.png")
        GameControlForm.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\RIGHT.png")
        GameControlForm.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\LEFT.png")
        GameControlForm.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\RIGHT.png")
        GameControlForm.AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
        GameControlForm.AnswerATextLabel.ForeColor = Color.White
        GameControlForm.AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        GameControlForm.AnswerBTextLabel.ForeColor = Color.White
        GameControlForm.AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        GameControlForm.AnswerCTextLabel.ForeColor = Color.White
        GameControlForm.AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
        GameControlForm.AnswerDTextLabel.ForeColor = Color.White
        AudienceScreenForm.QuestionFramePictureBox.Visible = True
        AudienceScreenForm.AnswerAFramePictureBox.Visible = True
        AudienceScreenForm.AnswerBFramePictureBox.Visible = True
        AudienceScreenForm.AnswerCFramePictureBox.Visible = True
        AudienceScreenForm.AnswerDFramePictureBox.Visible = True
        AskQuestionButton.BackColor = Color.White
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        CorrectAnswersButton.BackColor = Color.White
        QualifyingWinnerButton.BackColor = Color.White
    End Sub

    Private Sub ThreeBeepsButton_Click(sender As Object, e As EventArgs) Handles ThreeBeepsButton.Click
        'Three beeps
        Shell("source\BAT\stop_back_music1.bat")
        GameControlForm.winampOn = 0
        My.Computer.Audio.Play("source\MUSIC\Three Beeps.wav")
    End Sub

    Private Sub StartTimerButton_Click(sender As Object, e As EventArgs) Handles StartTimerButton.Click
        'Start timer
        Select Case StartTimerButton.BackColor
            Case Color.White
                AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\BG4.jpg")
                TodaysNamesButton.BackColor = Color.White
                NameCycleTimer.Stop()
                NameSequenceTimer.Stop()
                TimerTick = 0
                AudienceScreenForm.ContestantNameLabel.Visible = False
                AudienceScreenForm.ContestantTownLabel.Visible = False
                GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Fastest finger first.wav" & Chr(34)
                Shell("source\BAT\run2_back_music1.bat " & GameControlForm.batFileName)
                GameControlForm.winampOn = 1
                GameControlForm.QuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
                GameControlForm.AnswerATextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                GameControlForm.AnswerBTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                GameControlForm.AnswerCTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                GameControlForm.AnswerDTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
                GameControlForm.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\A_BLACK.png")
                GameControlForm.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\B_BLACK.png")
                GameControlForm.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\C_BLACK.png")
                GameControlForm.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\D_BLACK.png")
                AudienceScreenForm.QuestionTextLabel.Visible = True
                AudienceScreenForm.AnswerATextLabel.Visible = True
                AudienceScreenForm.AnswerBTextLabel.Visible = True
                AudienceScreenForm.AnswerCTextLabel.Visible = True
                AudienceScreenForm.AnswerDTextLabel.Visible = True
                AudienceScreenForm.QuestionFramePictureBox.Visible = True
                AudienceScreenForm.AnswerAFramePictureBox.Visible = True
                AudienceScreenForm.AnswerBFramePictureBox.Visible = True
                AudienceScreenForm.AnswerCFramePictureBox.Visible = True
                AudienceScreenForm.AnswerDFramePictureBox.Visible = True
                StartTimerButton.BackColor = Color.Green
                AudienceScreenForm.ClockPictureBox.Visible = True
                ClockTimer.Start()
                clockFrame = 21
                AudienceScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (21).png"
                'Cкрытие таблицы результатов
                AudienceScreenForm.FffResultRow5PictureBox.Visible = False
                AudienceScreenForm.FffResultRow6PictureBox.Visible = False
                AudienceScreenForm.FffResultRow4PictureBox.Visible = False
                AudienceScreenForm.FffResultRow7PictureBox.Visible = False
                AudienceScreenForm.FffResultRow3PictureBox.Visible = False
                AudienceScreenForm.FffResultRow8PictureBox.Visible = False
                AudienceScreenForm.FffResultRow2PictureBox.Visible = False
                AudienceScreenForm.FffResultRow9PictureBox.Visible = False
                AudienceScreenForm.FffResultRow1PictureBox.Visible = False
                AudienceScreenForm.FffResultRow10PictureBox.Visible = False
                AudienceScreenForm.FffResultName5Label.Visible = False
                AudienceScreenForm.FffResultName6Label.Visible = False
                AudienceScreenForm.FffResultName4Label.Visible = False
                AudienceScreenForm.FffResultName7Label.Visible = False
                AudienceScreenForm.FffResultName3Label.Visible = False
                AudienceScreenForm.FffResultName8Label.Visible = False
                AudienceScreenForm.FffResultName2Label.Visible = False
                AudienceScreenForm.FffResultName9Label.Visible = False
                AudienceScreenForm.FffResultName1Label.Visible = False
                AudienceScreenForm.FffResultName10Label.Visible = False
                AudienceScreenForm.FffResultTime5Label.Visible = False
                AudienceScreenForm.FffResultTime6Label.Visible = False
                AudienceScreenForm.FffResultTime4Label.Visible = False
                AudienceScreenForm.FffResultTime7Label.Visible = False
                AudienceScreenForm.FffResultTime3Label.Visible = False
                AudienceScreenForm.FffResultTime8Label.Visible = False
                AudienceScreenForm.FffResultTime2Label.Visible = False
                AudienceScreenForm.FffResultTime9Label.Visible = False
                AudienceScreenForm.FffResultTime1Label.Visible = False
                AudienceScreenForm.FffResultTime10Label.Visible = False
                AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
                CorrectAnswersButton.BackColor = Color.White
                '\Конец скрытия таблицы
            Case Color.Green
                My.Computer.Audio.Play("source\MUSIC\Fastest finger first end.wav")
                Shell("source\BAT\stop_back_music1.bat")
                GameControlForm.winampOn = 0
                AudienceScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
                ClockTimer.Stop()
                StartTimerButton.BackColor = Color.White
        End Select
    End Sub

    Private Sub ClockTimer_Tick(sender As Object, e As EventArgs) Handles ClockTimer.Tick
        clockFrame = clockFrame + 1
        AudienceScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        If clockFrame = 61 Then
            ClockTimer.Stop()
            AudienceScreenForm.ClockPictureBox.ImageLocation = "source\CLOCK\Clock (61).png"
            GameControlForm.winampOn = 0
            StartTimerButton.BackColor = Color.White
        End If
    End Sub

    Private Sub RightOrderButton_Click(sender As Object, e As EventArgs) Handles RightOrderButton.Click
        'Right order
        AudienceScreenForm.ClockPictureBox.Visible = False
        ClockTimer.Stop()
        StartTimerButton.BackColor = Color.White
        'Cкрытие таблицы результатов
        AudienceScreenForm.FffResultRow5PictureBox.Visible = False
        AudienceScreenForm.FffResultRow6PictureBox.Visible = False
        AudienceScreenForm.FffResultRow4PictureBox.Visible = False
        AudienceScreenForm.FffResultRow7PictureBox.Visible = False
        AudienceScreenForm.FffResultRow3PictureBox.Visible = False
        AudienceScreenForm.FffResultRow8PictureBox.Visible = False
        AudienceScreenForm.FffResultRow2PictureBox.Visible = False
        AudienceScreenForm.FffResultRow9PictureBox.Visible = False
        AudienceScreenForm.FffResultRow1PictureBox.Visible = False
        AudienceScreenForm.FffResultRow10PictureBox.Visible = False
        AudienceScreenForm.FffResultName5Label.Visible = False
        AudienceScreenForm.FffResultName6Label.Visible = False
        AudienceScreenForm.FffResultName4Label.Visible = False
        AudienceScreenForm.FffResultName7Label.Visible = False
        AudienceScreenForm.FffResultName3Label.Visible = False
        AudienceScreenForm.FffResultName8Label.Visible = False
        AudienceScreenForm.FffResultName2Label.Visible = False
        AudienceScreenForm.FffResultName9Label.Visible = False
        AudienceScreenForm.FffResultName1Label.Visible = False
        AudienceScreenForm.FffResultName10Label.Visible = False
        AudienceScreenForm.FffResultTime5Label.Visible = False
        AudienceScreenForm.FffResultTime6Label.Visible = False
        AudienceScreenForm.FffResultTime4Label.Visible = False
        AudienceScreenForm.FffResultTime7Label.Visible = False
        AudienceScreenForm.FffResultTime3Label.Visible = False
        AudienceScreenForm.FffResultTime8Label.Visible = False
        AudienceScreenForm.FffResultTime2Label.Visible = False
        AudienceScreenForm.FffResultTime9Label.Visible = False
        AudienceScreenForm.FffResultTime1Label.Visible = False
        AudienceScreenForm.FffResultTime10Label.Visible = False
        AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
        CorrectAnswersButton.BackColor = Color.White
        '\Конец скрытия таблицы
        If fourth <> 0 Then
            GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\What's the Order.wav" & Chr(34)
            Shell("source\BAT\run_back_music1.bat " & GameControlForm.batFileName)
            GameControlForm.winampOn = 1
            AudienceScreenForm.QuestionTextLabel.Visible = False
            AudienceScreenForm.AnswerATextLabel.Visible = False
            AudienceScreenForm.AnswerBTextLabel.Visible = False
            AudienceScreenForm.AnswerCTextLabel.Visible = False
            AudienceScreenForm.AnswerDTextLabel.Visible = False
            AudienceScreenForm.QuestionFramePictureBox.Visible = False
            AudienceScreenForm.AnswerAFramePictureBox.Visible = False
            AudienceScreenForm.AnswerBFramePictureBox.Visible = False
            AudienceScreenForm.AnswerCFramePictureBox.Visible = False
            AudienceScreenForm.AnswerDFramePictureBox.Visible = False
            TodaysNamesButton.BackColor = Color.White
            NameCycleTimer.Stop()
            NameSequenceTimer.Stop()
            TimerTick = 0
            AudienceScreenForm.MoneyTreePictureBox.Visible = False
            AudienceScreenForm.LifelinesPictureBox.Visible = False
            AudienceScreenForm.FffAnswer1FramePictureBox.Visible = False
            AudienceScreenForm.FffAnswer2FramePictureBox.Visible = False
            AudienceScreenForm.FffAnswer3FramePictureBox.Visible = False
            AudienceScreenForm.FffAnswer4FramePictureBox.Visible = False
            AudienceScreenForm.FffAnswer1Label.Visible = False
            AudienceScreenForm.FffAnswer2Label.Visible = False
            AudienceScreenForm.FffAnswer3Label.Visible = False
            AudienceScreenForm.FffAnswer4Label.Visible = False
            AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\AudienceFFF2.png")
            AudienceScreenForm.FffQuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
            AudienceScreenForm.FffQuestionTextLabel.Visible = True
            orderDemo = True
        Else
            GameControlForm.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\A_BLACK.png")
            GameControlForm.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\B_BLACK.png")
            GameControlForm.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\C_BLACK.png")
            GameControlForm.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\D_BLACK.png")
            GameControlForm.AnswerATextLabel.BackColor = Color.FromArgb(42, 42, 42)
            GameControlForm.AnswerATextLabel.ForeColor = Color.White
            GameControlForm.AnswerBTextLabel.BackColor = Color.FromArgb(42, 42, 42)
            GameControlForm.AnswerBTextLabel.ForeColor = Color.White
            GameControlForm.AnswerCTextLabel.BackColor = Color.FromArgb(42, 42, 42)
            GameControlForm.AnswerCTextLabel.ForeColor = Color.White
            GameControlForm.AnswerDTextLabel.BackColor = Color.FromArgb(42, 42, 42)
            GameControlForm.AnswerDTextLabel.ForeColor = Color.White
            Select Case first
                Case 1
                    GameControlForm.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\A_GREEN.png")
                    GameControlForm.AnswerATextLabel.BackColor = Color.FromArgb(93, 179, 87)
                    GameControlForm.AnswerATextLabel.ForeColor = Color.Black
                Case 2
                    GameControlForm.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\B_GREEN.png")
                    GameControlForm.AnswerBTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                    GameControlForm.AnswerBTextLabel.ForeColor = Color.Black
                Case 3
                    GameControlForm.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\C_GREEN.png")
                    GameControlForm.AnswerCTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                    GameControlForm.AnswerCTextLabel.ForeColor = Color.Black
                Case 4
                    GameControlForm.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\D_GREEN.png")
                    GameControlForm.AnswerDTextLabel.BackColor = Color.FromArgb(93, 179, 87)
                    GameControlForm.AnswerDTextLabel.ForeColor = Color.Black
            End Select
            If GameControlForm.winampOn <> 0 Then
                Shell("source\BAT\stop_back_music1.bat")
                GameControlForm.winampOn = 0
            End If
            My.Computer.Audio.Play("source\MUSIC\Q1-5 - Yes.wav", AudioPlayMode.Background)
        End If
    End Sub

    Private Sub RightOrder1Button_Click(sender As Object, e As EventArgs) Handles RightOrder1Button.Click
        '1st answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\1st in Order.wav")
            AudienceScreenForm.FffAnswer1FramePictureBox.Visible = True
            AudienceScreenForm.FffAnswer1Label.Visible = True
            Select Case first
                Case 1
                    AudienceScreenForm.FffAnswer1FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_A.png")
                    AudienceScreenForm.FffAnswer1Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                Case 2
                    AudienceScreenForm.FffAnswer1FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_B.png")
                    AudienceScreenForm.FffAnswer1Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                Case 3
                    AudienceScreenForm.FffAnswer1FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_C.png")
                    AudienceScreenForm.FffAnswer1Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                Case 4
                    AudienceScreenForm.FffAnswer1FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_D.png")
                    AudienceScreenForm.FffAnswer1Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub RightOrder2Button_Click(sender As Object, e As EventArgs) Handles RightOrder2Button.Click
        '2nd answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\2nd in Order.wav")
            AudienceScreenForm.FffAnswer2FramePictureBox.Visible = True
            AudienceScreenForm.FffAnswer2Label.Visible = True
            Select Case second
                Case 1
                    AudienceScreenForm.FffAnswer2FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_A.png")
                    AudienceScreenForm.FffAnswer2Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                Case 2
                    AudienceScreenForm.FffAnswer2FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_B.png")
                    AudienceScreenForm.FffAnswer2Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                Case 3
                    AudienceScreenForm.FffAnswer2FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_C.png")
                    AudienceScreenForm.FffAnswer2Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                Case 4
                    AudienceScreenForm.FffAnswer2FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_D.png")
                    AudienceScreenForm.FffAnswer2Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub RightOrder3Button_Click(sender As Object, e As EventArgs) Handles RightOrder3Button.Click
        '3rd answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\3rd in Order.wav")
            AudienceScreenForm.FffAnswer3FramePictureBox.Visible = True
            AudienceScreenForm.FffAnswer3Label.Visible = True
            Select Case third
                Case 1
                    AudienceScreenForm.FffAnswer3FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_A.png")
                    AudienceScreenForm.FffAnswer3Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                Case 2
                    AudienceScreenForm.FffAnswer3FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_B.png")
                    AudienceScreenForm.FffAnswer3Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                Case 3
                    AudienceScreenForm.FffAnswer3FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_C.png")
                    AudienceScreenForm.FffAnswer3Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                Case 4
                    AudienceScreenForm.FffAnswer3FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_D.png")
                    AudienceScreenForm.FffAnswer3Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
            End Select
        End If
    End Sub

    Private Sub RightOrder4Button_Click(sender As Object, e As EventArgs) Handles RightOrder4Button.Click
        '4th answer in order
        If fourth <> 0 And orderDemo = True Then
            My.Computer.Audio.Play("source\MUSIC\4th in Order.wav")
            AudienceScreenForm.FffAnswer4FramePictureBox.Visible = True
            AudienceScreenForm.FffAnswer4Label.Visible = True
            Select Case fourth
                Case 1
                    AudienceScreenForm.FffAnswer4FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_A.png")
                    AudienceScreenForm.FffAnswer4Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                Case 2
                    AudienceScreenForm.FffAnswer4FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_B.png")
                    AudienceScreenForm.FffAnswer4Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                Case 3
                    AudienceScreenForm.FffAnswer4FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_C.png")
                    AudienceScreenForm.FffAnswer4Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                Case 4
                    AudienceScreenForm.FffAnswer4FramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_D.png")
                    AudienceScreenForm.FffAnswer4Label.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
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
                AudienceScreenForm.QuestionFramePictureBox.Visible = False
                AudienceScreenForm.AnswerAFramePictureBox.Visible = False
                AudienceScreenForm.AnswerBFramePictureBox.Visible = False
                AudienceScreenForm.AnswerCFramePictureBox.Visible = False
                AudienceScreenForm.AnswerDFramePictureBox.Visible = False
                AudienceScreenForm.QuestionTextLabel.Visible = False
                AudienceScreenForm.AnswerATextLabel.Visible = False
                AudienceScreenForm.AnswerBTextLabel.Visible = False
                AudienceScreenForm.AnswerCTextLabel.Visible = False
                AudienceScreenForm.AnswerDTextLabel.Visible = False
                TodaysNamesButton.BackColor = Color.White
                NameCycleTimer.Stop()
                NameSequenceTimer.Stop()
                TimerTick = 0
                AudienceScreenForm.ContestantNameLabel.Visible = False
                AudienceScreenForm.ContestantTownLabel.Visible = False
                AudienceScreenForm.ContestantNameLabel.Visible = False
                AudienceScreenForm.ContestantTownLabel.Visible = False
                AudienceScreenForm.FffQuestionTextLabel.Visible = False
                AudienceScreenForm.FffAnswer1Label.Visible = False
                AudienceScreenForm.FffAnswer2Label.Visible = False
                AudienceScreenForm.FffAnswer3Label.Visible = False
                AudienceScreenForm.FffAnswer4Label.Visible = False
                AudienceScreenForm.FffAnswer1FramePictureBox.Visible = False
                AudienceScreenForm.FffAnswer2FramePictureBox.Visible = False
                AudienceScreenForm.FffAnswer3FramePictureBox.Visible = False
                AudienceScreenForm.FffAnswer4FramePictureBox.Visible = False
                AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\bg.jpg")
                AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultTime10Label.Text = Nothing
                'Отбор имён
                If ContestantFieldTextBox5.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow5PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow5PictureBox.Visible = True
                    AudienceScreenForm.FffResultName5Label.Visible = True
                    AudienceScreenForm.FffResultName5Label.Text = ContestantFieldTextBox5.Text
                    AudienceScreenForm.FffResultTime5Label.Text = ContestantFieldTextBox25.Text
                End If
                If ContestantFieldTextBox6.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow6PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow6PictureBox.Visible = True
                    AudienceScreenForm.FffResultName6Label.Visible = True
                    AudienceScreenForm.FffResultName6Label.Text = ContestantFieldTextBox6.Text
                    AudienceScreenForm.FffResultTime6Label.Text = ContestantFieldTextBox26.Text
                End If
                If ContestantFieldTextBox4.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow4PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow4PictureBox.Visible = True
                    AudienceScreenForm.FffResultName4Label.Visible = True
                    AudienceScreenForm.FffResultName4Label.Text = ContestantFieldTextBox4.Text
                    AudienceScreenForm.FffResultTime4Label.Text = ContestantFieldTextBox24.Text
                End If
                If ContestantFieldTextBox7.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow7PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow7PictureBox.Visible = True
                    AudienceScreenForm.FffResultName7Label.Visible = True
                    AudienceScreenForm.FffResultName7Label.Text = ContestantFieldTextBox7.Text
                    AudienceScreenForm.FffResultTime7Label.Text = ContestantFieldTextBox27.Text
                End If
                If ContestantFieldTextBox3.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow3PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow3PictureBox.Visible = True
                    AudienceScreenForm.FffResultName3Label.Visible = True
                    AudienceScreenForm.FffResultName3Label.Text = ContestantFieldTextBox3.Text
                    AudienceScreenForm.FffResultTime3Label.Text = ContestantFieldTextBox23.Text
                End If
                If ContestantFieldTextBox8.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow8PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow8PictureBox.Visible = True
                    AudienceScreenForm.FffResultName8Label.Visible = True
                    AudienceScreenForm.FffResultName8Label.Text = ContestantFieldTextBox8.Text
                    AudienceScreenForm.FffResultTime8Label.Text = ContestantFieldTextBox28.Text
                End If
                If ContestantFieldTextBox2.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow2PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow2PictureBox.Visible = True
                    AudienceScreenForm.FffResultName2Label.Visible = True
                    AudienceScreenForm.FffResultName2Label.Text = ContestantFieldTextBox2.Text
                    AudienceScreenForm.FffResultTime2Label.Text = ContestantFieldTextBox22.Text
                End If
                If ContestantFieldTextBox9.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow9PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow9PictureBox.Visible = True
                    AudienceScreenForm.FffResultName9Label.Visible = True
                    AudienceScreenForm.FffResultName9Label.Text = ContestantFieldTextBox9.Text
                    AudienceScreenForm.FffResultTime9Label.Text = ContestantFieldTextBox29.Text
                End If
                If ContestantFieldTextBox1.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow1PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow1PictureBox.Visible = True
                    AudienceScreenForm.FffResultName1Label.Visible = True
                    AudienceScreenForm.FffResultName1Label.Text = ContestantFieldTextBox1.Text
                    AudienceScreenForm.FffResultTime1Label.Text = ContestantFieldTextBox21.Text
                End If
                If ContestantFieldTextBox10.Text <> Nothing Then
                    AudienceScreenForm.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                    AudienceScreenForm.FffResultRow10PictureBox.Visible = True
                    AudienceScreenForm.FffResultName10Label.Visible = True
                    AudienceScreenForm.FffResultName10Label.Text = ContestantFieldTextBox10.Text
                    AudienceScreenForm.FffResultTime10Label.Text = ContestantFieldTextBox30.Text
                End If
            Case Color.Gold 'Показ результатов
                CorrectAnswersButton.BackColor = Color.Green
                If ContestantFieldTextBox25.Text = 0 And ContestantFieldTextBox26.Text = 0 And ContestantFieldTextBox24.Text = 0 And ContestantFieldTextBox27.Text = 0 And ContestantFieldTextBox23.Text = 0 And ContestantFieldTextBox28.Text = 0 And ContestantFieldTextBox22.Text = 0 And ContestantFieldTextBox29.Text = 0 And ContestantFieldTextBox21.Text = 0 And ContestantFieldTextBox30.Text = 0 Then
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Whoosh.wav" & Chr(34)
                    Shell("source\BAT\run2_back_music1.bat " & GameControlForm.batFileName)
                    QualifyingWinnerButton.Enabled = False
                    AskQuestionButton.BackColor = Color.Gold
                Else
                    GameControlForm.batFileName = Chr(34) & GameControlForm.sourcePath & "\MUSIC\Correct Answers.wav" & Chr(34)
                    Shell("source\BAT\run2_back_music1.bat " & GameControlForm.batFileName)
                    Timer2tick = 0
                    ResultsRevealTimer.Start()
                    QualifyingWinnerButton.BackColor = Color.Gold
                End If
            Case Color.Green
                'Cкрытие таблицы результатов
                AudienceScreenForm.FffResultRow5PictureBox.Visible = False
                AudienceScreenForm.FffResultRow6PictureBox.Visible = False
                AudienceScreenForm.FffResultRow4PictureBox.Visible = False
                AudienceScreenForm.FffResultRow7PictureBox.Visible = False
                AudienceScreenForm.FffResultRow3PictureBox.Visible = False
                AudienceScreenForm.FffResultRow8PictureBox.Visible = False
                AudienceScreenForm.FffResultRow2PictureBox.Visible = False
                AudienceScreenForm.FffResultRow9PictureBox.Visible = False
                AudienceScreenForm.FffResultRow1PictureBox.Visible = False
                AudienceScreenForm.FffResultRow10PictureBox.Visible = False
                AudienceScreenForm.FffResultName5Label.Visible = False
                AudienceScreenForm.FffResultName6Label.Visible = False
                AudienceScreenForm.FffResultName4Label.Visible = False
                AudienceScreenForm.FffResultName7Label.Visible = False
                AudienceScreenForm.FffResultName3Label.Visible = False
                AudienceScreenForm.FffResultName8Label.Visible = False
                AudienceScreenForm.FffResultName2Label.Visible = False
                AudienceScreenForm.FffResultName9Label.Visible = False
                AudienceScreenForm.FffResultName1Label.Visible = False
                AudienceScreenForm.FffResultName10Label.Visible = False
                AudienceScreenForm.FffResultTime5Label.Visible = False
                AudienceScreenForm.FffResultTime6Label.Visible = False
                AudienceScreenForm.FffResultTime4Label.Visible = False
                AudienceScreenForm.FffResultTime7Label.Visible = False
                AudienceScreenForm.FffResultTime3Label.Visible = False
                AudienceScreenForm.FffResultTime8Label.Visible = False
                AudienceScreenForm.FffResultTime2Label.Visible = False
                AudienceScreenForm.FffResultTime9Label.Visible = False
                AudienceScreenForm.FffResultTime1Label.Visible = False
                AudienceScreenForm.FffResultTime10Label.Visible = False
                CorrectAnswersButton.BackColor = Color.White
        End Select
    End Sub

    Private Sub ResultsRevealTimer_Tick(sender As Object, e As EventArgs) Handles ResultsRevealTimer.Tick
        'Таймер показа результатов
        Timer2tick = Timer2tick + 1
        Select Case Timer2tick
            Case 1
                If ContestantFieldTextBox30.Text <> "0" Then
                    AudienceScreenForm.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime10Label.Text = ContestantFieldTextBox30.Text
                    AudienceScreenForm.FffResultTime10Label.Visible = True
                End If
            Case 2
                If ContestantFieldTextBox29.Text <> "0" Then
                    AudienceScreenForm.FffResultRow9PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime9Label.Text = ContestantFieldTextBox29.Text
                    AudienceScreenForm.FffResultTime9Label.Visible = True
                End If
            Case 3
                If ContestantFieldTextBox28.Text <> "0" Then
                    AudienceScreenForm.FffResultRow8PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime8Label.Text = ContestantFieldTextBox28.Text
                    AudienceScreenForm.FffResultTime8Label.Visible = True
                End If
            Case 4
                If ContestantFieldTextBox27.Text <> "0" Then
                    AudienceScreenForm.FffResultRow7PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime7Label.Text = ContestantFieldTextBox27.Text
                    AudienceScreenForm.FffResultTime7Label.Visible = True
                End If
            Case 5
                If ContestantFieldTextBox26.Text <> "0" Then
                    AudienceScreenForm.FffResultRow6PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime6Label.Text = ContestantFieldTextBox26.Text
                    AudienceScreenForm.FffResultTime6Label.Visible = True
                End If
            Case 6
                If ContestantFieldTextBox25.Text <> "0" Then
                    AudienceScreenForm.FffResultRow5PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime5Label.Text = ContestantFieldTextBox25.Text
                    AudienceScreenForm.FffResultTime5Label.Visible = True
                End If
            Case 7
                If ContestantFieldTextBox24.Text <> "0" Then
                    AudienceScreenForm.FffResultRow4PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime4Label.Text = ContestantFieldTextBox24.Text
                    AudienceScreenForm.FffResultTime4Label.Visible = True
                End If
            Case 8
                If ContestantFieldTextBox23.Text <> "0" Then
                    AudienceScreenForm.FffResultRow3PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime3Label.Text = ContestantFieldTextBox23.Text
                    AudienceScreenForm.FffResultTime3Label.Visible = True
                End If
            Case 9
                If ContestantFieldTextBox22.Text <> "0" Then
                    AudienceScreenForm.FffResultRow2PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime2Label.Text = ContestantFieldTextBox22.Text
                    AudienceScreenForm.FffResultTime2Label.Visible = True
                End If
            Case 10
                If ContestantFieldTextBox21.Text <> "0" Then
                    AudienceScreenForm.FffResultRow1PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                    AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(96, 182, 90)
                    AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(96, 182, 90)
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
                    AudienceScreenForm.FffResultTime1Label.Text = ContestantFieldTextBox21.Text
                    AudienceScreenForm.FffResultTime1Label.Visible = True
                End If
                    ResultsRevealTimer.Stop()
                    WinnerRevealTimer.Start()
        End Select
    End Sub

    Private Sub WinnerRevealTimer_Tick(sender As Object, e As EventArgs) Handles WinnerRevealTimer.Tick
        'Выявление победителя
        If winLine = False Then
            If time6 = winTime Or time6 = winTime2 Then
                AudienceScreenForm.FffResultRow5PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time5 = winTime Or time5 = winTime2 Then
                AudienceScreenForm.FffResultRow6PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time7 = winTime Or time7 = winTime2 Then
                AudienceScreenForm.FffResultRow4PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time4 = winTime Or time4 = winTime2 Then
                AudienceScreenForm.FffResultRow7PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time8 = winTime Or time8 = winTime2 Then
                AudienceScreenForm.FffResultRow3PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time3 = winTime Or time3 = winTime2 Then
                AudienceScreenForm.FffResultRow8PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time9 = winTime Or time9 = winTime2 Then
                AudienceScreenForm.FffResultRow2PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time2 = winTime Or time2 = winTime2 Then
                AudienceScreenForm.FffResultRow9PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time10 = winTime Or time10 = winTime2 Then
                AudienceScreenForm.FffResultRow1PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            If time1 = winTime Or time1 = winTime2 Then
                AudienceScreenForm.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
                AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(96, 182, 90)
            End If
            winLine = True
        Else
            If time6 = winTime Or time6 = winTime2 Then
                AudienceScreenForm.FffResultRow5PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time5 = winTime Or time5 = winTime2 Then
                AudienceScreenForm.FffResultRow6PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time7 = winTime Or time7 = winTime2 Then
                AudienceScreenForm.FffResultRow4PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time4 = winTime Or time4 = winTime2 Then
                AudienceScreenForm.FffResultRow7PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time8 = winTime Or time8 = winTime2 Then
                AudienceScreenForm.FffResultRow3PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time3 = winTime Or time3 = winTime2 Then
                AudienceScreenForm.FffResultRow8PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time9 = winTime Or time9 = winTime2 Then
                AudienceScreenForm.FffResultRow2PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time2 = winTime Or time2 = winTime2 Then
                AudienceScreenForm.FffResultRow9PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time10 = winTime Or time10 = winTime2 Then
                AudienceScreenForm.FffResultRow1PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
            End If
            If time1 = winTime Or time1 = winTime2 Then
                AudienceScreenForm.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG1.png")
                AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
                AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
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
            AudienceScreenForm.FffResultRow5PictureBox.Visible = False
            AudienceScreenForm.FffResultRow6PictureBox.Visible = False
            AudienceScreenForm.FffResultRow4PictureBox.Visible = False
            AudienceScreenForm.FffResultRow7PictureBox.Visible = False
            AudienceScreenForm.FffResultRow3PictureBox.Visible = False
            AudienceScreenForm.FffResultRow8PictureBox.Visible = False
            AudienceScreenForm.FffResultRow2PictureBox.Visible = False
            If TwoWinnersCheckBox.Checked = False Then AudienceScreenForm.FffResultRow9PictureBox.Visible = False
            AudienceScreenForm.FffResultRow1PictureBox.Visible = False
            'AudienceScreenForm.FffResultRow10PictureBox.Visible = False
            AudienceScreenForm.FffResultName5Label.Visible = False
            AudienceScreenForm.FffResultName6Label.Visible = False
            AudienceScreenForm.FffResultName4Label.Visible = False
            AudienceScreenForm.FffResultName7Label.Visible = False
            AudienceScreenForm.FffResultName3Label.Visible = False
            AudienceScreenForm.FffResultName8Label.Visible = False
            AudienceScreenForm.FffResultName2Label.Visible = False
            If TwoWinnersCheckBox.Checked = False Then AudienceScreenForm.FffResultName9Label.Visible = False
            AudienceScreenForm.FffResultName1Label.Visible = False
            'AudienceScreenForm.FffResultName10Label.Visible = False
            AudienceScreenForm.FffResultTime5Label.Visible = False
            AudienceScreenForm.FffResultTime6Label.Visible = False
            AudienceScreenForm.FffResultTime4Label.Visible = False
            AudienceScreenForm.FffResultTime7Label.Visible = False
            AudienceScreenForm.FffResultTime3Label.Visible = False
            AudienceScreenForm.FffResultTime8Label.Visible = False
            AudienceScreenForm.FffResultTime2Label.Visible = False
            If TwoWinnersCheckBox.Checked = False Then AudienceScreenForm.FffResultTime9Label.Visible = False
            AudienceScreenForm.FffResultTime1Label.Visible = False
            'AudienceScreenForm.FffResultTime10Label.Visible = False
            AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
            If TwoWinnersCheckBox.Checked = False Then AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
            'AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
            If TwoWinnersCheckBox.Checked = False Then AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
            AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
            'AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
            '\Конец скрытия таблицы
            AudienceScreenForm.FffResultRow10PictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\FFF\FFF_LOZENG2.png")
            If time6 = winTime Then
                AudienceScreenForm.FffResultName10Label.Text = AudienceScreenForm.FffResultName5Label.Text
                AudienceScreenForm.FffResultTime10Label.Text = AudienceScreenForm.FffResultTime5Label.Text
            End If
            If time5 = winTime Then
                AudienceScreenForm.FffResultName10Label.Text = AudienceScreenForm.FffResultName6Label.Text
                AudienceScreenForm.FffResultTime10Label.Text = AudienceScreenForm.FffResultTime6Label.Text
                winners = winners + 1
            End If
            If time7 = winTime Then
                AudienceScreenForm.FffResultName10Label.Text = AudienceScreenForm.FffResultName4Label.Text
                AudienceScreenForm.FffResultTime10Label.Text = AudienceScreenForm.FffResultTime4Label.Text
            End If
            If time4 = winTime Then
                AudienceScreenForm.FffResultName10Label.Text = AudienceScreenForm.FffResultName7Label.Text
                AudienceScreenForm.FffResultTime10Label.Text = AudienceScreenForm.FffResultTime7Label.Text
            End If
            If time8 = winTime Then
                AudienceScreenForm.FffResultName10Label.Text = AudienceScreenForm.FffResultName3Label.Text
                AudienceScreenForm.FffResultTime10Label.Text = AudienceScreenForm.FffResultTime3Label.Text
            End If
            If time3 = winTime Then
                AudienceScreenForm.FffResultName10Label.Text = AudienceScreenForm.FffResultName8Label.Text
                AudienceScreenForm.FffResultTime10Label.Text = AudienceScreenForm.FffResultTime8Label.Text
            End If
            If time9 = winTime Then
                AudienceScreenForm.FffResultName10Label.Text = AudienceScreenForm.FffResultName2Label.Text
                AudienceScreenForm.FffResultTime10Label.Text = AudienceScreenForm.FffResultTime2Label.Text
            End If
            If time2 = winTime Then
                AudienceScreenForm.FffResultName10Label.Text = AudienceScreenForm.FffResultName9Label.Text
                AudienceScreenForm.FffResultTime10Label.Text = AudienceScreenForm.FffResultTime9Label.Text
            End If
            If time10 = winTime Then
                AudienceScreenForm.FffResultName10Label.Text = AudienceScreenForm.FffResultName1Label.Text
                AudienceScreenForm.FffResultTime10Label.Text = AudienceScreenForm.FffResultTime1Label.Text
            End If
            AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(96, 182, 90)
            AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(96, 182, 90)
            AudienceScreenForm.FffResultRow10PictureBox.Visible = True
            AudienceScreenForm.FffResultName10Label.Visible = True
            AudienceScreenForm.FffResultTime10Label.Visible = True
            If TwoWinnersCheckBox.Checked = True Then
                If time6 = winTime2 Then
                    AudienceScreenForm.FffResultName9Label.Text = AudienceScreenForm.FffResultName5Label.Text
                    AudienceScreenForm.FffResultTime9Label.Text = AudienceScreenForm.FffResultTime5Label.Text
                End If
                If time5 = winTime2 Then
                    AudienceScreenForm.FffResultName9Label.Text = AudienceScreenForm.FffResultName6Label.Text
                    AudienceScreenForm.FffResultTime9Label.Text = AudienceScreenForm.FffResultTime6Label.Text
                    winners = winners + 1
                End If
                If time7 = winTime2 Then
                    AudienceScreenForm.FffResultName9Label.Text = AudienceScreenForm.FffResultName4Label.Text
                    AudienceScreenForm.FffResultTime9Label.Text = AudienceScreenForm.FffResultTime4Label.Text
                End If
                If time4 = winTime2 Then
                    AudienceScreenForm.FffResultName9Label.Text = AudienceScreenForm.FffResultName7Label.Text
                    AudienceScreenForm.FffResultTime9Label.Text = AudienceScreenForm.FffResultTime7Label.Text
                End If
                If time8 = winTime2 Then
                    AudienceScreenForm.FffResultName9Label.Text = AudienceScreenForm.FffResultName3Label.Text
                    AudienceScreenForm.FffResultTime9Label.Text = AudienceScreenForm.FffResultTime3Label.Text
                End If
                If time3 = winTime2 Then
                    AudienceScreenForm.FffResultName9Label.Text = AudienceScreenForm.FffResultName8Label.Text
                    AudienceScreenForm.FffResultTime9Label.Text = AudienceScreenForm.FffResultTime8Label.Text
                End If
                If time9 = winTime2 Then
                    AudienceScreenForm.FffResultName9Label.Text = AudienceScreenForm.FffResultName2Label.Text
                    AudienceScreenForm.FffResultTime9Label.Text = AudienceScreenForm.FffResultTime2Label.Text
                End If
                If time10 = winTime2 Then
                    AudienceScreenForm.FffResultName9Label.Text = AudienceScreenForm.FffResultName1Label.Text
                    AudienceScreenForm.FffResultTime9Label.Text = AudienceScreenForm.FffResultTime1Label.Text
                End If
                If time1 = winTime2 Then
                    AudienceScreenForm.FffResultName9Label.Text = AudienceScreenForm.FffResultName10Label.Text
                    AudienceScreenForm.FffResultTime9Label.Text = AudienceScreenForm.FffResultTime10Label.Text
                End If
                AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(96, 182, 90)
                AudienceScreenForm.FffResultRow9PictureBox.Visible = True
                AudienceScreenForm.FffResultName9Label.Visible = True
                AudienceScreenForm.FffResultTime9Label.Visible = True
            End If
            AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\BG4.jpg")
            GameControlForm.ContestantNameTextBox.Text = AudienceScreenForm.FffResultName10Label.Text
            'Удаление победителя из списка
            If DropWinnerCheckBox.Checked = True Then
                If ContestantFieldTextBox1.Text <> AudienceScreenForm.FffResultName10Label.Text Then
                    If ContestantFieldTextBox2.Text <> AudienceScreenForm.FffResultName10Label.Text Then
                        If ContestantFieldTextBox3.Text <> AudienceScreenForm.FffResultName10Label.Text Then
                            If ContestantFieldTextBox4.Text <> AudienceScreenForm.FffResultName10Label.Text Then
                                If ContestantFieldTextBox5.Text <> AudienceScreenForm.FffResultName10Label.Text Then
                                    If ContestantFieldTextBox6.Text <> AudienceScreenForm.FffResultName10Label.Text Then
                                        If ContestantFieldTextBox7.Text <> AudienceScreenForm.FffResultName10Label.Text Then
                                            If ContestantFieldTextBox8.Text <> AudienceScreenForm.FffResultName10Label.Text Then
                                                If ContestantFieldTextBox9.Text <> AudienceScreenForm.FffResultName10Label.Text Then
                                                    If ContestantFieldTextBox10.Text = AudienceScreenForm.FffResultName10Label.Text Then ContestantFieldTextBox10.Text = Nothing
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
        AudienceScreenForm.FffResultRow5PictureBox.Visible = False
        AudienceScreenForm.FffResultRow6PictureBox.Visible = False
        AudienceScreenForm.FffResultRow4PictureBox.Visible = False
        AudienceScreenForm.FffResultRow7PictureBox.Visible = False
        AudienceScreenForm.FffResultRow3PictureBox.Visible = False
        AudienceScreenForm.FffResultRow8PictureBox.Visible = False
        AudienceScreenForm.FffResultRow2PictureBox.Visible = False
        AudienceScreenForm.FffResultRow9PictureBox.Visible = False
        AudienceScreenForm.FffResultRow1PictureBox.Visible = False
        AudienceScreenForm.FffResultRow10PictureBox.Visible = False
        AudienceScreenForm.FffResultName5Label.Visible = False
        AudienceScreenForm.FffResultName6Label.Visible = False
        AudienceScreenForm.FffResultName4Label.Visible = False
        AudienceScreenForm.FffResultName7Label.Visible = False
        AudienceScreenForm.FffResultName3Label.Visible = False
        AudienceScreenForm.FffResultName8Label.Visible = False
        AudienceScreenForm.FffResultName2Label.Visible = False
        AudienceScreenForm.FffResultName9Label.Visible = False
        AudienceScreenForm.FffResultName1Label.Visible = False
        AudienceScreenForm.FffResultName10Label.Visible = False
        AudienceScreenForm.FffResultTime5Label.Visible = False
        AudienceScreenForm.FffResultTime6Label.Visible = False
        AudienceScreenForm.FffResultTime4Label.Visible = False
        AudienceScreenForm.FffResultTime7Label.Visible = False
        AudienceScreenForm.FffResultTime3Label.Visible = False
        AudienceScreenForm.FffResultTime8Label.Visible = False
        AudienceScreenForm.FffResultTime2Label.Visible = False
        AudienceScreenForm.FffResultTime9Label.Visible = False
        AudienceScreenForm.FffResultTime1Label.Visible = False
        AudienceScreenForm.FffResultTime10Label.Visible = False
        AudienceScreenForm.FffResultName5Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName6Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName4Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName7Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName3Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName8Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName2Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName9Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName1Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultName10Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime5Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime6Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime4Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime7Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime3Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime8Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime2Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime9Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime1Label.BackColor = Color.FromArgb(31, 31, 31)
        AudienceScreenForm.FffResultTime10Label.BackColor = Color.FromArgb(31, 31, 31)
        '\Конец скрытия таблицы
        AudienceScreenForm.ContestantNameLabel.Visible = False
        AudienceScreenForm.ContestantTownLabel.Visible = False
        AudienceScreenForm.FffQuestionTextLabel.Visible = False
        AudienceScreenForm.FffAnswer1Label.Visible = False
        AudienceScreenForm.FffAnswer2Label.Visible = False
        AudienceScreenForm.FffAnswer3Label.Visible = False
        AudienceScreenForm.FffAnswer4Label.Visible = False
        AudienceScreenForm.FffAnswer1FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer2FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer3FramePictureBox.Visible = False
        AudienceScreenForm.FffAnswer4FramePictureBox.Visible = False
        AudienceScreenForm.LogoPictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\LOGO_FEEL.png")
        AudienceScreenForm.LogoPictureBox.Visible = False
        GameControlForm.ToggleLogoButton.BackColor = Color.White
        GameControlForm.QuestionTextLabel.Text = ""
        GameControlForm.AnswerATextLabel.Text = ""
        GameControlForm.AnswerBTextLabel.Text = ""
        GameControlForm.AnswerCTextLabel.Text = ""
        GameControlForm.AnswerDTextLabel.Text = ""
        AudienceScreenForm.QuestionTextLabel.Visible = True
        AudienceScreenForm.AnswerATextLabel.Visible = True
        AudienceScreenForm.AnswerBTextLabel.Visible = True
        AudienceScreenForm.AnswerCTextLabel.Visible = True
        AudienceScreenForm.AnswerDTextLabel.Visible = True
        AudienceScreenForm.QuestionFramePictureBox.Visible = True
        AudienceScreenForm.AnswerAFramePictureBox.Visible = True
        AudienceScreenForm.AnswerBFramePictureBox.Visible = True
        AudienceScreenForm.AnswerCFramePictureBox.Visible = True
        AudienceScreenForm.AnswerDFramePictureBox.Visible = True
        AudienceScreenForm.MoneyTreePictureBox.Visible = True
        AudienceScreenForm.LifelinesPictureBox.Visible = True
        AudienceScreenForm.ClockPictureBox.Visible = False
        GameControlForm.AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\LEFT.png")
        GameControlForm.AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\RIGHT.png")
        GameControlForm.AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\LEFT.png")
        GameControlForm.AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\RIGHT.png")
        AudienceScreenForm.BackgroundImage = System.Drawing.Bitmap.FromFile(GameControlForm.langSource & "\BG4.jpg")
        GameControlForm.FastestFingerFirstButton.BackColor = Color.White
        GameControlForm.LetsPlayButton.BackColor = Color.FromArgb(255, 128, 128)
        If GameControlForm.splashOn = False Then
            GameControlForm.ToggleLogoButton.PerformClick()
            GameControlForm.ToggleLogoButton.BackColor = Color.Violet
            GameControlForm.splashOn = True
        End If
        AudienceScreenForm.LogoPictureBox.Visible = True
    End Sub
End Class