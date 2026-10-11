Imports System
Imports System.IO

Public Class FastestFingerFirstForm
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
        EmbeddedFonts.Apply(Me)
        Me.FormBorderStyle = Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        LanguageComboBox.Items.Clear()
        'ini-файл
        If My.Computer.FileSystem.FileExists(CurDir() & "\wwtbam_set.ini") = False Then
            TextFile.Close()
            TextFile.Open(CurDir() & "\wwtbam_set.ini")
            TextFile.Write("|1|1|1|0|0|0|0|0|0||English|127.0.0.1|8000|||" & Chr(13) & Chr(10))
            TextFile.Close()
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
        OpenContestantsListDialog.FileName = "Bases\" & currentBlock1(2, 3) & "contestants.con"
        sourcePath = CurDir() & "\Source"
        AudioOutput.Open(sourcePath & "\MUSIC") 'Загружается заранее, чтобы первый трек запустился без задержки
        langSource = CurDir() & currentBlock1(3, 3)
        OpenQuestionBaseDialog.InitialDirectory = CurDir() & "Bases\"
        OpenQuestionBaseDialog.FileName = "Bases\" & currentBlock1(2, 3) & "qualify.fff"
        FileNameQ = OpenQuestionBaseDialog.FileName
        Call openfilesdata(FileNameQ)
        For x = 1 To 20
            Me.Controls("ContestantFieldTextBox" & x).Text = Nothing
        Next
        DelKeyLabel.Text = Nothing
        OkKeyLabel.Text = Nothing
        For x = 16 To 20
            Me.Controls("QuestionFieldLabel" & x).Text = Nothing
        Next
        For x = 26 To 29
            Me.Controls("AnswerOrderLabel" & x).Text = Nothing
        Next
        QuestionFieldLabel16.Visible = False
        QuestionFieldLabel17.Visible = False
        QuestionFieldLabel18.Visible = False
        QuestionFieldLabel19.Visible = False
        QuestionFieldLabel20.Visible = False
        ContestantNumberLabel.Visible = False
        ContestantNameHeaderLabel.Visible = False
        ContestantTownHeaderLabel.Visible = False
        ContestantNameTextBox.Visible = False
        ContestantTownTextBox.Visible = False
        StartContestantButton.Visible = False
    End Sub

    Private Sub QuestionListBox_DoubleClick(sender As Object, e As EventArgs) Handles QuestionListBox.DoubleClick
        FastestFingerEditorForm.Show()
    End Sub

    Private Sub LanguageComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles LanguageComboBox.SelectedIndexChanged
        'Выбор языка
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer = 0
        Dim i1 As Integer = 0
        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(files(LanguageComboBox.SelectedIndex), System.Text.Encoding.Default)
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
        OpenQuestionBaseDialog.FileName = "Bases\" & currentBlock1(2, 3) & "qualify.fff"
        OpenContestantsListDialog.FileName = "Bases\" & currentBlock1(2, 3) & "contestants.con"
        FileNameQ = OpenQuestionBaseDialog.FileName
        Call openfilesdata(FileNameQ)
        'Перевод "A" StartForm
        LanguageLabel.Text = currentBlock1(19, 3)
        StartContestantButton.Text = currentBlock1(20, 3)
        'Перевод "G" FastestFingerFirstForm
        Text = currentBlock1(123, 3) '0
        OpenQuestionBaseButton.Text = currentBlock1(124, 3) '1
        FullQuestionTextHeaderLabel.Text = currentBlock1(137, 3) '14
        LeftNameHeaderLabel.Text = currentBlock1(138, 3) '15
        RightNameHeaderLabel.Text = currentBlock1(138, 3) '15
        ContestantNameHeaderLabel.Text = currentBlock1(138, 3) '15
        LeftFromHeaderLabel.Text = currentBlock1(139, 3) '16
        RightFromHeaderLabel.Text = currentBlock1(139, 3) '16
        ContestantTownHeaderLabel.Text = currentBlock1(139, 3) '16
        'Перевод "J" Fastest Finger First
        StartFffButton.Text = currentBlock1(147, 3) '0
        InstructionsLabel.Text = currentBlock1(148, 3).Replace("¶", Chr(13) & Chr(10)) '1
        EnterNamesLaterCheckBox.Text = currentBlock1(149, 3) '2
        'Шрифты
        QuestionFieldLabel16.Font = EmbeddedFonts.Create(currentBlock1(4, 3), Int(currentBlock1(4, 4)))
        QuestionFieldLabel17.Font = EmbeddedFonts.Create(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        QuestionFieldLabel18.Font = EmbeddedFonts.Create(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        QuestionFieldLabel19.Font = EmbeddedFonts.Create(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        QuestionFieldLabel20.Font = EmbeddedFonts.Create(currentBlock1(5, 3), Int(currentBlock1(5, 4)))
        InstructionsLabel.Font = EmbeddedFonts.Create(currentBlock1(5, 3), Int(currentBlock1(4, 4)) - 8.25)
    End Sub

    Private Sub openfilesdata(sender As Object)
        Dim currentField As String
        Dim currentRow As String()
        Dim i0 As Integer
        Dim i1 As Integer
        If FileNameQ <> "*.fff" Then
            QuestionListBox.Enabled = True
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
            QuestionListBox.Items.Clear()
            For i1 = 1 To currentBlock2.GetUpperBound(0)
                If (currentBlock2(1, 3)) <> Nothing Then
                    QuestionListBox.Items.Add(currentBlock2(i1, 2) & ": " & currentBlock2(i1, 3))
                End If
            Next
            QuestionListBox.SelectedIndex = 0
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
            FullQuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & currentBlock1(144, 3) & " " & first & ", " & second & ", " & third & ", " & fourth
        Else
            FullQuestionTextLabel.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3) & Chr(13) & "A: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 4) & " B: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 5) & " C: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 6) & " D: " & currentBlock2(QuestionListBox.SelectedIndex + 1, 7) & ". " & currentBlock1(143, 3) & " " & first
        End If
    End Sub

    Private Sub OpenQuestionBaseButton_Click(sender As Object, e As EventArgs) Handles OpenQuestionBaseButton.Click
        'Open base file...
        OpenQuestionBaseDialog.FileName = "*.fff"
        OpenQuestionBaseDialog.InitialDirectory = CurDir() & "\Bases"
        OpenQuestionBaseDialog.CheckFileExists = True
        If OpenQuestionBaseDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            FileNameQ = OpenQuestionBaseDialog.FileName
            Call openfilesdata(FileNameQ)
        End If
    End Sub

    Private Sub EnterNamesLaterCheckBox_CheckedChanged(sender As Object, e As EventArgs) Handles EnterNamesLaterCheckBox.CheckedChanged
        If EnterNamesLaterCheckBox.Checked = True Then
            For x = 1 To 20
                Me.Controls("ContestantFieldTextBox" & x).Enabled = False
            Next
        Else
            For x = 1 To 20
                Me.Controls("ContestantFieldTextBox" & x).Enabled = True
            Next
        End If
    End Sub

    Private Sub StartFffButton_Click(sender As Object, e As EventArgs) Handles StartFffButton.Click
        'Start FFF
        contNumber = 1
        stepOK = 0
        QuestionListBox.Visible = False
        StartFffButton.Visible = False
        OpenQuestionBaseButton.Visible = False
        FullQuestionTextLabel.Visible = False
        FullQuestionTextHeaderLabel.Visible = False
        EnterNamesLaterCheckBox.Visible = False
        LanguageLabel.Visible = False
        LanguageComboBox.Visible = False
        LeftNameHeaderLabel.Visible = False
        LeftFromHeaderLabel.Visible = False
        RightNameHeaderLabel.Visible = False
        RightFromHeaderLabel.Visible = False
        Podium1NumberLabel.Visible = False
        Podium2NumberLabel.Visible = False
        Podium3NumberLabel.Visible = False
        Podium4NumberLabel.Visible = False
        Podium5NumberLabel.Visible = False
        Podium6NumberLabel.Visible = False
        Podium7NumberLabel.Visible = False
        Podium8NumberLabel.Visible = False
        Podium9NumberLabel.Visible = False
        Podium10NumberLabel.Visible = False
        For x = 1 To 20
            Me.Controls("ContestantFieldTextBox" & x).Visible = False
        Next
        InstructionsLabel.Visible = False
        'Отображение интерфейса игрока
        QuestionFieldLabel16.Text = Nothing
        QuestionFieldLabel17.Text = Nothing
        QuestionFieldLabel18.Text = Nothing
        QuestionFieldLabel19.Text = Nothing
        QuestionFieldLabel20.Text = Nothing
        QuestionFieldLabel16.Visible = True
        QuestionFieldLabel17.Visible = True
        QuestionFieldLabel18.Visible = True
        QuestionFieldLabel19.Visible = True
        QuestionFieldLabel20.Visible = True
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        QuestionFramePictureBox.Visible = True
        AnswerAFramePictureBox.Visible = True
        AnswerBFramePictureBox.Visible = True
        AnswerCFramePictureBox.Visible = True
        AnswerDFramePictureBox.Visible = True
        For x = 6 To 11
            Me.Controls("KeypadPictureBox" & x).Visible = True
        Next
        For x = 26 To 29
            Me.Controls("AnswerOrderLabel" & x).Text = Nothing
        Next
        For x = 16 To 20
            Me.Controls("QuestionFieldLabel" & x).Text = Nothing
        Next
        DelKeyLabel.Text = "Del"
        OkKeyLabel.Text = "OK"
        ReDim currentBlock3(10, 3)
        If EnterNamesLaterCheckBox.Checked = False Then
            Dim y As Integer = 0
            Dim currentRow(10)
            ReDim currentBlock0(10, 3)
            For x = 1 To 10
                currentBlock0(x, 1) = Me.Controls("ContestantFieldTextBox" & x).Text
            Next
            For x = 11 To 20
                currentBlock0(x - 10, 2) = Me.Controls("ContestantFieldTextBox" & x).Text
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
                EnterNamesLaterCheckBox.Checked = True
                ContestantNumberLabel.Text = Str(contNumber)
                ContestantNumberLabel.Visible = True
                ContestantNameHeaderLabel.Visible = True
                ContestantTownHeaderLabel.Visible = True
                ContestantNameTextBox.Visible = True
                ContestantTownTextBox.Visible = True
                StartContestantButton.Visible = True
                ReDim currentBlock3(10, 3)
            Else
                QuestionFieldLabel16.Text = currentBlock3(contNumber, 1) & Chr(13) & currentBlock3(contNumber, 2)
            End If
        Else
            ContestantNumberLabel.Text = Str(contNumber)
            ContestantNumberLabel.Visible = True
            ContestantNameHeaderLabel.Visible = True
            ContestantTownHeaderLabel.Visible = True
            ContestantNameTextBox.Visible = True
            ContestantTownTextBox.Visible = True
            StartContestantButton.Visible = True
        End If
    End Sub

    Private Sub ContestantNameTextBox_TextChanged(sender As Object, e As EventArgs) Handles ContestantNameTextBox.TextChanged, ContestantTownTextBox.TextChanged
        'Изменение текста имени текущего игрока (EnterNamesLaterCheckBox.Checked)
        QuestionFieldLabel16.Text = ContestantNameTextBox.Text & Chr(13) & ContestantTownTextBox.Text
    End Sub

    Private Sub StartContestantButton_Click(sender As Object, e As EventArgs) Handles StartContestantButton.Click
        'START button (EnterNamesLaterCheckBox.Checked)
        If ContestantNameTextBox.Text <> Nothing Then
            stepOK = 1
            currentBlock3(contNumber, 1) = ContestantNameTextBox.Text
            currentBlock3(contNumber, 2) = ContestantTownTextBox.Text
            ContestantNumberLabel.Visible = False
            ContestantNameHeaderLabel.Visible = False
            ContestantTownHeaderLabel.Visible = False
            ContestantNameTextBox.Visible = False
            ContestantTownTextBox.Visible = False
            StartContestantButton.Visible = False
            SoundCues.Play("source\MUSIC\Standby for Q.wav")
            QuestionFieldLabel16.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
        Else
            If contNumber <> 1 Then
                Dim n As Integer
                While My.Computer.FileSystem.FileExists(CurDir() & "\Bases\NewBaseCON" & n & ".con") = True
                    n = n + 1
                End While
                SaveContestantsListDialog.FileName = "NewBaseCON" & n & ".con"
                SaveContestantsListDialog.InitialDirectory = CurDir() & "\Bases"
                SaveContestantsListDialog.CreatePrompt = False
                SaveContestantsListDialog.OverwritePrompt = True
                SaveContestantsListDialog.CheckPathExists = True
                If SaveContestantsListDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    contQuant = Int(ContestantNumberLabel.Text) - 1
                    contNumber = contQuant
                    stepOK = 4
                    Dim tmpText As String
                    TextFile.Close()
                    TextFile.Open(SaveContestantsListDialog.FileName)
                    For i1 = 1 To currentBlock3.GetUpperBound(0)
                        If currentBlock3(i1, 1) <> Nothing Then
                            tmpText = "|" & i1 & "|"
                            For i2 = 1 To 3
                                'Сохранение в файл
                                If currentBlock3(i1, i2) <> "" Then currentBlock3(i1, i2) = currentBlock3(i1, i2).Replace("|", "")
                                tmpText = tmpText & currentBlock3(i1, i2) & "|"
                            Next
                            TextFile.Write(tmpText & Chr(13) & Chr(10))
                        End If
                    Next
                    TextFile.Close()
                    MsgBox(currentBlock1(150, 6) & "! " & currentBlock1(150, 7) & ": " & SaveContestantsListDialog.FileName, MsgBoxStyle.Information, currentBlock1(150, 6))
                    Me.Close()
                End If
            Else
                MsgBox(currentBlock1(150, 3)) 'You don't entered any contestant name!
            End If
        End If
    End Sub

    Private Sub KeypadPictureBox11_Click(sender As Object, e As EventArgs) Handles KeypadPictureBox11.Click, OkKeyLabel.Click
        'OK
        Select Case stepOK
            Case 0
                If EnterNamesLaterCheckBox.Checked = False Then
                    stepOK = 1
                    SoundCues.Play("source\MUSIC\Standby for Q.wav")
                    QuestionFieldLabel16.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
                End If
            Case 1
                stepOK = 2
                SoundCues.Play("source\MUSIC\Three Beeps.wav")
            Case 2
                stepOK = 3
                SoundCues.Play("source\MUSIC\Fastest finger first.wav")
                contTime = 0
                TimeLimitTimer.Start()
                startTimer = System.DateTime.Now.Ticks
                QuestionFieldLabel16.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 3)
                QuestionFieldLabel17.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 4)
                QuestionFieldLabel18.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 5)
                QuestionFieldLabel19.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 6)
                QuestionFieldLabel20.Text = currentBlock2(QuestionListBox.SelectedIndex + 1, 7)
                AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                ClockPictureBox.Visible = True
                ClockTimer.Start()
                clockFrame = 21
                ClockPictureBox.ImageLocation = "source\CLOCK\Clock (21).png"
            Case 3
                If QuestionFieldLabel16.Text <> currentBlock1(150, 5) Then
                    If AnswerOrderLabel26.Text <> Nothing And AnswerOrderLabel27.Text <> Nothing And AnswerOrderLabel28.Text <> Nothing And AnswerOrderLabel29.Text <> Nothing Then
                        TimeLimitTimer.Stop()
                        stopTimer = System.DateTime.Now.Ticks
                        contTime = Math.Round((stopTimer - startTimer) / 100000) / 100
                        SoundCues.Play("source\MUSIC\Fastest finger first end.wav")
                        ClockTimer.Stop()
                        clockFrame = 62
                        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (62).png"
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
                        QuestionFieldLabel16.Text = currentBlock1(150, 4) 'Saving complete.
                        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
                        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
                        QuestionFieldLabel17.BackColor = Color.FromArgb(42, 42, 42)
                        QuestionFieldLabel18.BackColor = Color.FromArgb(42, 42, 42)
                        QuestionFieldLabel19.BackColor = Color.FromArgb(42, 42, 42)
                        QuestionFieldLabel20.BackColor = Color.FromArgb(42, 42, 42)
                        QuestionFieldLabel17.ForeColor = Color.White
                        QuestionFieldLabel18.ForeColor = Color.White
                        QuestionFieldLabel19.ForeColor = Color.White
                        QuestionFieldLabel20.ForeColor = Color.White
                        QuestionFieldLabel17.Text = Nothing
                        QuestionFieldLabel18.Text = Nothing
                        QuestionFieldLabel19.Text = Nothing
                        QuestionFieldLabel20.Text = Nothing
                        AnswerOrderLabel26.Text = Nothing
                        AnswerOrderLabel27.Text = Nothing
                        AnswerOrderLabel28.Text = Nothing
                        AnswerOrderLabel29.Text = Nothing
                        ClockPictureBox.Visible = False
                        stepOK = 4
                    End If
                Else
                    AnswerOrderLabel26.Text = Nothing
                    AnswerOrderLabel27.Text = Nothing
                    AnswerOrderLabel28.Text = Nothing
                    AnswerOrderLabel29.Text = Nothing
                    currentBlock3(contNumber, 3) = 0
                    QuestionFieldLabel16.Text = currentBlock1(150, 4) 'Saving complete.
                    ClockPictureBox.Visible = False
                    stepOK = 4
                End If
            Case 4
                If contNumber <> contQuant And contNumber < 10 Then
                    'Следующий участник
                    KeypadPictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer1.png")
                    OkKeyLabel.BackColor = Color.FromArgb(42, 42, 42)
                    OkKeyLabel.ForeColor = Color.White
                    contAnswer = Nothing
                    stepOK = 0
                    contNumber = contNumber + 1
                    If EnterNamesLaterCheckBox.Checked Then
                        ContestantNameTextBox.Text = Nothing
                        ContestantTownTextBox.Text = Nothing
                        ContestantNumberLabel.Text = Str(contNumber)
                        ContestantNumberLabel.Visible = True
                        ContestantNameHeaderLabel.Visible = True
                        ContestantTownHeaderLabel.Visible = True
                        ContestantNameTextBox.Visible = True
                        ContestantTownTextBox.Visible = True
                        StartContestantButton.Visible = True
                    End If
                    QuestionFieldLabel16.Text = currentBlock3(contNumber, 1) & Chr(13) & currentBlock3(contNumber, 2)
                Else
                    Call SaveFileData() 'Запсь данных в файл
                End If
        End Select
    End Sub

    Private Sub TimeLimitTimer_Tick(sender As Object, e As EventArgs) Handles TimeLimitTimer.Tick
        TimeLimitTimer.Stop()
        contTime = 0
        QuestionFieldLabel16.Text = currentBlock1(150, 5) 'TIME'S UP!
        QuestionFieldLabel17.Text = Nothing
        QuestionFieldLabel18.Text = Nothing
        QuestionFieldLabel19.Text = Nothing
        QuestionFieldLabel20.Text = Nothing
        KeypadPictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
        OkKeyLabel.BackColor = Color.FromArgb(244, 155, 15)
        OkKeyLabel.ForeColor = Color.Black
        AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\LEFT.png")
        AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\RIGHT.png")
        QuestionFieldLabel17.BackColor = Color.FromArgb(42, 42, 42)
        QuestionFieldLabel18.BackColor = Color.FromArgb(42, 42, 42)
        QuestionFieldLabel19.BackColor = Color.FromArgb(42, 42, 42)
        QuestionFieldLabel20.BackColor = Color.FromArgb(42, 42, 42)
        QuestionFieldLabel17.ForeColor = Color.White
        QuestionFieldLabel18.ForeColor = Color.White
        QuestionFieldLabel19.ForeColor = Color.White
        QuestionFieldLabel20.ForeColor = Color.White
    End Sub

    Private Sub ClockTimer_Tick(sender As Object, e As EventArgs) Handles ClockTimer.Tick
        clockFrame = clockFrame + 1
        ClockPictureBox.ImageLocation = "source\CLOCK\Clock (" & clockFrame & ").png"
        If clockFrame = 61 Then
            ClockTimer.Stop()
            ClockPictureBox.ImageLocation = "source\CLOCK\Clock (61).png"
        End If
    End Sub

    Private Sub KeypadPictureBox10_Click(sender As Object, e As EventArgs) Handles KeypadPictureBox10.Click, DelKeyLabel.Click
        'Del
        If stepOK = 3 Then
            For x = 26 To 29
                Me.Controls("AnswerOrderLabel" & x).Text = Nothing
            Next
            KeypadPictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer1.png")
            OkKeyLabel.BackColor = Color.FromArgb(42, 42, 42)
            OkKeyLabel.ForeColor = Color.White
            AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
            AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
            AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
            AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
            QuestionFieldLabel17.BackColor = Color.FromArgb(42, 42, 42)
            QuestionFieldLabel18.BackColor = Color.FromArgb(42, 42, 42)
            QuestionFieldLabel19.BackColor = Color.FromArgb(42, 42, 42)
            QuestionFieldLabel20.BackColor = Color.FromArgb(42, 42, 42)
            QuestionFieldLabel17.ForeColor = Color.White
            QuestionFieldLabel18.ForeColor = Color.White
            QuestionFieldLabel19.ForeColor = Color.White
            QuestionFieldLabel20.ForeColor = Color.White
            contAnswer = Nothing
        End If
    End Sub

    Private Sub AnswerAFramePictureBox_Click(sender As Object, e As EventArgs) Handles AnswerAFramePictureBox.Click, QuestionFieldLabel17.Click
        'A
        If stepOK = 3 And QuestionFieldLabel17.BackColor <> Color.FromArgb(244, 155, 15) Then
            If fourth <> 0 Then
                If AnswerOrderLabel26.Text = Nothing Then
                    AnswerOrderLabel26.Text = "A:"
                Else
                    If AnswerOrderLabel27.Text = Nothing Then
                        AnswerOrderLabel27.Text = "A:"
                    Else
                        If AnswerOrderLabel28.Text = Nothing Then
                            AnswerOrderLabel28.Text = "A:"
                        Else
                            AnswerOrderLabel29.Text = "A:"
                            KeypadPictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
                            OkKeyLabel.BackColor = Color.FromArgb(244, 155, 15)
                            OkKeyLabel.ForeColor = Color.Black
                        End If
                    End If
                End If
                AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_ORANGE.png")
                QuestionFieldLabel17.BackColor = Color.FromArgb(244, 155, 15)
                QuestionFieldLabel17.ForeColor = Color.Black
                contAnswer = contAnswer & "1"
            Else
                AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_ORANGE.png")
                AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                QuestionFieldLabel17.BackColor = Color.FromArgb(244, 155, 15)
                QuestionFieldLabel18.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel19.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel20.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel17.ForeColor = Color.Black
                QuestionFieldLabel18.ForeColor = Color.White
                QuestionFieldLabel19.ForeColor = Color.White
                QuestionFieldLabel20.ForeColor = Color.White
                contAnswer = "1"
            End If
        End If
    End Sub

    Private Sub AnswerBFramePictureBox_Click(sender As Object, e As EventArgs) Handles AnswerBFramePictureBox.Click, QuestionFieldLabel18.Click
        'B
        If stepOK = 3 And QuestionFieldLabel18.BackColor <> Color.FromArgb(244, 155, 15) Then
            If fourth <> 0 Then
                If AnswerOrderLabel26.Text = Nothing Then
                    AnswerOrderLabel26.Text = "B:"
                Else
                    If AnswerOrderLabel27.Text = Nothing Then
                        AnswerOrderLabel27.Text = "B:"
                    Else
                        If AnswerOrderLabel28.Text = Nothing Then
                            AnswerOrderLabel28.Text = "B:"
                        Else
                            AnswerOrderLabel29.Text = "B:"
                            KeypadPictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
                            OkKeyLabel.BackColor = Color.FromArgb(244, 155, 15)
                            OkKeyLabel.ForeColor = Color.Black
                        End If
                    End If
                End If
                AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_ORANGE.png")
                QuestionFieldLabel18.BackColor = Color.FromArgb(244, 155, 15)
                QuestionFieldLabel18.ForeColor = Color.Black
                contAnswer = contAnswer & "2"
            Else
                AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_ORANGE.png")
                AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                QuestionFieldLabel17.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel18.BackColor = Color.FromArgb(244, 155, 15)
                QuestionFieldLabel19.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel20.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel17.ForeColor = Color.White
                QuestionFieldLabel18.ForeColor = Color.Black
                QuestionFieldLabel19.ForeColor = Color.White
                QuestionFieldLabel20.ForeColor = Color.White
                contAnswer = "2"
            End If
        End If
    End Sub

    Private Sub AnswerCFramePictureBox_Click(sender As Object, e As EventArgs) Handles AnswerCFramePictureBox.Click, QuestionFieldLabel19.Click
        'C
        If stepOK = 3 And QuestionFieldLabel19.BackColor <> Color.FromArgb(244, 155, 15) Then
            If fourth <> 0 Then
                If AnswerOrderLabel26.Text = Nothing Then
                    AnswerOrderLabel26.Text = "C:"
                Else
                    If AnswerOrderLabel27.Text = Nothing Then
                        AnswerOrderLabel27.Text = "C:"
                    Else
                        If AnswerOrderLabel28.Text = Nothing Then
                            AnswerOrderLabel28.Text = "C:"
                        Else
                            AnswerOrderLabel29.Text = "C:"
                            KeypadPictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
                            OkKeyLabel.BackColor = Color.FromArgb(244, 155, 15)
                            OkKeyLabel.ForeColor = Color.Black
                        End If
                    End If
                End If
                AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_ORANGE.png")
                QuestionFieldLabel19.BackColor = Color.FromArgb(244, 155, 15)
                QuestionFieldLabel19.ForeColor = Color.Black
                contAnswer = contAnswer & "3"
            Else
                AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_ORANGE.png")
                AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_BLACK.png")
                QuestionFieldLabel17.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel18.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel19.BackColor = Color.FromArgb(244, 155, 15)
                QuestionFieldLabel20.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel17.ForeColor = Color.White
                QuestionFieldLabel18.ForeColor = Color.White
                QuestionFieldLabel19.ForeColor = Color.Black
                QuestionFieldLabel20.ForeColor = Color.White
                contAnswer = "3"
            End If
        End If
    End Sub

    Private Sub AnswerDFramePictureBox_Click(sender As Object, e As EventArgs) Handles AnswerDFramePictureBox.Click, QuestionFieldLabel20.Click
        'D
        If stepOK = 3 And QuestionFieldLabel20.BackColor <> Color.FromArgb(244, 155, 15) Then
            If fourth <> 0 Then
                If AnswerOrderLabel26.Text = Nothing Then
                    AnswerOrderLabel26.Text = "D:"
                Else
                    If AnswerOrderLabel27.Text = Nothing Then
                        AnswerOrderLabel27.Text = "D:"
                    Else
                        If AnswerOrderLabel28.Text = Nothing Then
                            AnswerOrderLabel28.Text = "D:"
                        Else
                            AnswerOrderLabel29.Text = "D:"
                            KeypadPictureBox11.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\FFF\FFF-Answer2.png")
                            OkKeyLabel.BackColor = Color.FromArgb(244, 155, 15)
                            OkKeyLabel.ForeColor = Color.Black
                        End If
                    End If
                End If
                AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_ORANGE.png")
                QuestionFieldLabel20.BackColor = Color.FromArgb(244, 155, 15)
                QuestionFieldLabel20.ForeColor = Color.Black
                contAnswer = contAnswer & "4"
            Else
                AnswerAFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\A_BLACK.png")
                AnswerBFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\B_BLACK.png")
                AnswerCFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\C_BLACK.png")
                AnswerDFramePictureBox.BackgroundImage = System.Drawing.Bitmap.FromFile(langSource & "\D_ORANGE.png")
                QuestionFieldLabel17.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel18.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel19.BackColor = Color.FromArgb(42, 42, 42)
                QuestionFieldLabel20.BackColor = Color.FromArgb(244, 155, 15)
                QuestionFieldLabel17.ForeColor = Color.White
                QuestionFieldLabel18.ForeColor = Color.White
                QuestionFieldLabel19.ForeColor = Color.White
                QuestionFieldLabel20.ForeColor = Color.Black
                contAnswer = "4"
            End If
        End If
    End Sub

    Private Sub SaveFileData()
        Dim n As Integer
        While My.Computer.FileSystem.FileExists(CurDir() & "\Bases\NewBaseCON" & n & ".con") = True
            n = n + 1
        End While
        SaveContestantsListDialog.FileName = "NewBaseCON" & n & ".con"
        SaveContestantsListDialog.InitialDirectory = CurDir() & "\Bases"
        SaveContestantsListDialog.CreatePrompt = False
        SaveContestantsListDialog.OverwritePrompt = True
        SaveContestantsListDialog.CheckPathExists = True
        If SaveContestantsListDialog.ShowDialog() = Windows.Forms.DialogResult.OK Then
            Dim tmpText As String
            TextFile.Close()
            TextFile.Open(SaveContestantsListDialog.FileName)
            For i1 = 1 To currentBlock3.GetUpperBound(0)
                If currentBlock3(i1, 1) <> Nothing Then
                    tmpText = "|" & i1 & "|"
                    For i2 = 1 To 3
                        'Сохранение в файл
                        If currentBlock3(i1, i2) <> "" Then currentBlock3(i1, i2) = currentBlock3(i1, i2).Replace("|", "")
                        tmpText = tmpText & currentBlock3(i1, i2) & "|"
                    Next
                    TextFile.Write(tmpText & Chr(13) & Chr(10))
                End If
            Next
            TextFile.Close()
            MsgBox(currentBlock1(150, 6) & "! " & currentBlock1(150, 7) & ": " & SaveContestantsListDialog.FileName, MsgBoxStyle.Information, currentBlock1(150, 6))
            Me.Close()
        End If
    End Sub
End Class
