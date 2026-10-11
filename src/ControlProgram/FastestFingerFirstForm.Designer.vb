<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FastestFingerFirstForm
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ExplainRulesButton = New System.Windows.Forms.Button()
        Me.AskQuestionButton = New System.Windows.Forms.Button()
        Me.ThreeBeepsButton = New System.Windows.Forms.Button()
        Me.StartTimerButton = New System.Windows.Forms.Button()
        Me.RightOrderButton = New System.Windows.Forms.Button()
        Me.CorrectAnswersButton = New System.Windows.Forms.Button()
        Me.QualifyingWinnerButton = New System.Windows.Forms.Button()
        Me.RightOrder1Button = New System.Windows.Forms.Button()
        Me.RightOrder2Button = New System.Windows.Forms.Button()
        Me.RightOrder3Button = New System.Windows.Forms.Button()
        Me.RightOrder4Button = New System.Windows.Forms.Button()
        Me.QuestionListBox = New System.Windows.Forms.ListBox()
        Me.TodaysNamesButton = New System.Windows.Forms.Button()
        Me.OpenQuestionBaseButton = New System.Windows.Forms.Button()
        Me.OpenQuestionBaseDialog = New System.Windows.Forms.OpenFileDialog()
        Me.QuestionTextLabel = New System.Windows.Forms.Label()
        Me.FullQuestionTextLabel = New System.Windows.Forms.Label()
        Me.ContestantFieldTextBox1 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox11 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox21 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox26 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox16 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox6 = New System.Windows.Forms.TextBox()
        Me.Podium1NumberLabel = New System.Windows.Forms.Label()
        Me.Podium6NumberLabel = New System.Windows.Forms.Label()
        Me.Podium7NumberLabel = New System.Windows.Forms.Label()
        Me.Podium2NumberLabel = New System.Windows.Forms.Label()
        Me.ContestantFieldTextBox27 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox17 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox7 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox22 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox12 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox2 = New System.Windows.Forms.TextBox()
        Me.Podium8NumberLabel = New System.Windows.Forms.Label()
        Me.Podium3NumberLabel = New System.Windows.Forms.Label()
        Me.ContestantFieldTextBox28 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox18 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox8 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox23 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox13 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox3 = New System.Windows.Forms.TextBox()
        Me.Podium4NumberLabel = New System.Windows.Forms.Label()
        Me.ContestantFieldTextBox29 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox19 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox9 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox24 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox14 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox4 = New System.Windows.Forms.TextBox()
        Me.Podium10NumberLabel = New System.Windows.Forms.Label()
        Me.Podium5NumberLabel = New System.Windows.Forms.Label()
        Me.ContestantFieldTextBox30 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox20 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox10 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox25 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox15 = New System.Windows.Forms.TextBox()
        Me.ContestantFieldTextBox5 = New System.Windows.Forms.TextBox()
        Me.LeftNameHeaderLabel = New System.Windows.Forms.Label()
        Me.LeftFromHeaderLabel = New System.Windows.Forms.Label()
        Me.LeftTimeHeaderLabel = New System.Windows.Forms.Label()
        Me.RightTimeHeaderLabel = New System.Windows.Forms.Label()
        Me.RightFromHeaderLabel = New System.Windows.Forms.Label()
        Me.RightNameHeaderLabel = New System.Windows.Forms.Label()
        Me.NameCycleTimer = New System.Windows.Forms.Timer(Me.components)
        Me.Podium9NumberLabel = New System.Windows.Forms.Label()
        Me.ResultsRevealTimer = New System.Windows.Forms.Timer(Me.components)
        Me.WinnerRevealTimer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenContestantsListDialog = New System.Windows.Forms.OpenFileDialog()
        Me.NameSequenceTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenContestantsListButton = New System.Windows.Forms.Button()
        Me.DropWinnerCheckBox = New System.Windows.Forms.CheckBox()
        Me.TwoWinnersCheckBox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'ExplainRulesButton
        '
        Me.ExplainRulesButton.BackColor = System.Drawing.Color.White
        Me.ExplainRulesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ExplainRulesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ExplainRulesButton.Location = New System.Drawing.Point(434, 12)
        Me.ExplainRulesButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ExplainRulesButton.Name = "ExplainRulesButton"
        Me.ExplainRulesButton.Size = New System.Drawing.Size(100, 23)
        Me.ExplainRulesButton.TabIndex = 114
        Me.ExplainRulesButton.Text = "Explain rules"
        Me.ExplainRulesButton.UseVisualStyleBackColor = False
        '
        'AskQuestionButton
        '
        Me.AskQuestionButton.BackColor = System.Drawing.Color.White
        Me.AskQuestionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AskQuestionButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AskQuestionButton.Location = New System.Drawing.Point(226, 41)
        Me.AskQuestionButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AskQuestionButton.Name = "AskQuestionButton"
        Me.AskQuestionButton.Size = New System.Drawing.Size(100, 23)
        Me.AskQuestionButton.TabIndex = 115
        Me.AskQuestionButton.Text = "Ask FFF question"
        Me.AskQuestionButton.UseVisualStyleBackColor = False
        '
        'ThreeBeepsButton
        '
        Me.ThreeBeepsButton.BackColor = System.Drawing.Color.White
        Me.ThreeBeepsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ThreeBeepsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ThreeBeepsButton.Location = New System.Drawing.Point(330, 41)
        Me.ThreeBeepsButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ThreeBeepsButton.Name = "ThreeBeepsButton"
        Me.ThreeBeepsButton.Size = New System.Drawing.Size(100, 23)
        Me.ThreeBeepsButton.TabIndex = 116
        Me.ThreeBeepsButton.Text = "Three Beeps"
        Me.ThreeBeepsButton.UseVisualStyleBackColor = False
        '
        'StartTimerButton
        '
        Me.StartTimerButton.BackColor = System.Drawing.Color.White
        Me.StartTimerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StartTimerButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.StartTimerButton.Location = New System.Drawing.Point(434, 41)
        Me.StartTimerButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StartTimerButton.Name = "StartTimerButton"
        Me.StartTimerButton.Size = New System.Drawing.Size(100, 23)
        Me.StartTimerButton.TabIndex = 117
        Me.StartTimerButton.Text = "Start timer"
        Me.StartTimerButton.UseVisualStyleBackColor = False
        '
        'RightOrderButton
        '
        Me.RightOrderButton.BackColor = System.Drawing.Color.White
        Me.RightOrderButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RightOrderButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RightOrderButton.Location = New System.Drawing.Point(226, 70)
        Me.RightOrderButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RightOrderButton.Name = "RightOrderButton"
        Me.RightOrderButton.Size = New System.Drawing.Size(100, 23)
        Me.RightOrderButton.TabIndex = 118
        Me.RightOrderButton.Text = "Right Order"
        Me.RightOrderButton.UseVisualStyleBackColor = False
        '
        'CorrectAnswersButton
        '
        Me.CorrectAnswersButton.BackColor = System.Drawing.Color.White
        Me.CorrectAnswersButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CorrectAnswersButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CorrectAnswersButton.Location = New System.Drawing.Point(434, 70)
        Me.CorrectAnswersButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CorrectAnswersButton.Name = "CorrectAnswersButton"
        Me.CorrectAnswersButton.Size = New System.Drawing.Size(100, 23)
        Me.CorrectAnswersButton.TabIndex = 119
        Me.CorrectAnswersButton.Text = "Correct Answers"
        Me.CorrectAnswersButton.UseVisualStyleBackColor = False
        '
        'QualifyingWinnerButton
        '
        Me.QualifyingWinnerButton.BackColor = System.Drawing.Color.White
        Me.QualifyingWinnerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.QualifyingWinnerButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QualifyingWinnerButton.Location = New System.Drawing.Point(227, 97)
        Me.QualifyingWinnerButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.QualifyingWinnerButton.Name = "QualifyingWinnerButton"
        Me.QualifyingWinnerButton.Size = New System.Drawing.Size(100, 23)
        Me.QualifyingWinnerButton.TabIndex = 120
        Me.QualifyingWinnerButton.Text = "Qualifying winner"
        Me.QualifyingWinnerButton.UseVisualStyleBackColor = False
        '
        'RightOrder1Button
        '
        Me.RightOrder1Button.BackColor = System.Drawing.Color.White
        Me.RightOrder1Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RightOrder1Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.RightOrder1Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RightOrder1Button.Location = New System.Drawing.Point(330, 70)
        Me.RightOrder1Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RightOrder1Button.Name = "RightOrder1Button"
        Me.RightOrder1Button.Size = New System.Drawing.Size(26, 23)
        Me.RightOrder1Button.TabIndex = 121
        Me.RightOrder1Button.Text = "1st"
        Me.RightOrder1Button.UseVisualStyleBackColor = False
        '
        'RightOrder2Button
        '
        Me.RightOrder2Button.BackColor = System.Drawing.Color.White
        Me.RightOrder2Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RightOrder2Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.RightOrder2Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RightOrder2Button.Location = New System.Drawing.Point(355, 70)
        Me.RightOrder2Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RightOrder2Button.Name = "RightOrder2Button"
        Me.RightOrder2Button.Size = New System.Drawing.Size(26, 23)
        Me.RightOrder2Button.TabIndex = 122
        Me.RightOrder2Button.Text = "2nd"
        Me.RightOrder2Button.UseVisualStyleBackColor = False
        '
        'RightOrder3Button
        '
        Me.RightOrder3Button.BackColor = System.Drawing.Color.White
        Me.RightOrder3Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RightOrder3Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.RightOrder3Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RightOrder3Button.Location = New System.Drawing.Point(380, 70)
        Me.RightOrder3Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RightOrder3Button.Name = "RightOrder3Button"
        Me.RightOrder3Button.Size = New System.Drawing.Size(26, 23)
        Me.RightOrder3Button.TabIndex = 123
        Me.RightOrder3Button.Text = "3rd"
        Me.RightOrder3Button.UseVisualStyleBackColor = False
        '
        'RightOrder4Button
        '
        Me.RightOrder4Button.BackColor = System.Drawing.Color.White
        Me.RightOrder4Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RightOrder4Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.RightOrder4Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RightOrder4Button.Location = New System.Drawing.Point(404, 70)
        Me.RightOrder4Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RightOrder4Button.Name = "RightOrder4Button"
        Me.RightOrder4Button.Size = New System.Drawing.Size(26, 23)
        Me.RightOrder4Button.TabIndex = 124
        Me.RightOrder4Button.Text = "4th"
        Me.RightOrder4Button.UseVisualStyleBackColor = False
        '
        'QuestionListBox
        '
        Me.QuestionListBox.Enabled = False
        Me.QuestionListBox.FormattingEnabled = True
        Me.QuestionListBox.Items.AddRange(New Object() {"FFF1", "FFF2", "FFF3", "FFF4", "FFF5", "FFF6", "FFF7", "FFF8"})
        Me.QuestionListBox.Location = New System.Drawing.Point(11, 12)
        Me.QuestionListBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.QuestionListBox.Name = "QuestionListBox"
        Me.QuestionListBox.Size = New System.Drawing.Size(211, 108)
        Me.QuestionListBox.TabIndex = 125
        '
        'TodaysNamesButton
        '
        Me.TodaysNamesButton.BackColor = System.Drawing.Color.White
        Me.TodaysNamesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.TodaysNamesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TodaysNamesButton.Location = New System.Drawing.Point(330, 12)
        Me.TodaysNamesButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TodaysNamesButton.Name = "TodaysNamesButton"
        Me.TodaysNamesButton.Size = New System.Drawing.Size(100, 23)
        Me.TodaysNamesButton.TabIndex = 126
        Me.TodaysNamesButton.Text = "Today's Names"
        Me.TodaysNamesButton.UseVisualStyleBackColor = False
        '
        'OpenQuestionBaseButton
        '
        Me.OpenQuestionBaseButton.BackColor = System.Drawing.Color.White
        Me.OpenQuestionBaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OpenQuestionBaseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.OpenQuestionBaseButton.Location = New System.Drawing.Point(226, 12)
        Me.OpenQuestionBaseButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.OpenQuestionBaseButton.Name = "OpenQuestionBaseButton"
        Me.OpenQuestionBaseButton.Size = New System.Drawing.Size(100, 23)
        Me.OpenQuestionBaseButton.TabIndex = 127
        Me.OpenQuestionBaseButton.Text = "Open base file..."
        Me.OpenQuestionBaseButton.UseVisualStyleBackColor = False
        '
        'OpenQuestionBaseDialog
        '
        Me.OpenQuestionBaseDialog.FileName = "Bases\Qualify.fff"
        Me.OpenQuestionBaseDialog.Filter = "Question base for FFF|*.fff|All files|*.*"
        Me.OpenQuestionBaseDialog.InitialDirectory = "Bases\"
        Me.OpenQuestionBaseDialog.Title = "Open FFF question base file"
        '
        'QuestionTextLabel
        '
        Me.QuestionTextLabel.AutoSize = True
        Me.QuestionTextLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.QuestionTextLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QuestionTextLabel.Location = New System.Drawing.Point(11, 142)
        Me.QuestionTextLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.QuestionTextLabel.MaximumSize = New System.Drawing.Size(785, 40)
        Me.QuestionTextLabel.Name = "QuestionTextLabel"
        Me.QuestionTextLabel.Size = New System.Drawing.Size(94, 13)
        Me.QuestionTextLabel.TabIndex = 129
        Me.QuestionTextLabel.Text = "QUESTION TEXT"
        '
        'FullQuestionTextLabel
        '
        Me.FullQuestionTextLabel.AutoSize = True
        Me.FullQuestionTextLabel.ForeColor = System.Drawing.Color.White
        Me.FullQuestionTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FullQuestionTextLabel.Location = New System.Drawing.Point(11, 126)
        Me.FullQuestionTextLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FullQuestionTextLabel.Name = "FullQuestionTextLabel"
        Me.FullQuestionTextLabel.Size = New System.Drawing.Size(43, 13)
        Me.FullQuestionTextLabel.TabIndex = 128
        Me.FullQuestionTextLabel.Text = "Full text"
        '
        'ContestantFieldTextBox1
        '
        Me.ContestantFieldTextBox1.AllowDrop = True
        Me.ContestantFieldTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox1.Location = New System.Drawing.Point(28, 190)
        Me.ContestantFieldTextBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox1.Name = "ContestantFieldTextBox1"
        Me.ContestantFieldTextBox1.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox1.TabIndex = 130
        Me.ContestantFieldTextBox1.Text = "Contestant1"
        '
        'ContestantFieldTextBox11
        '
        Me.ContestantFieldTextBox11.AllowDrop = True
        Me.ContestantFieldTextBox11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox11.Location = New System.Drawing.Point(157, 190)
        Me.ContestantFieldTextBox11.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox11.Name = "ContestantFieldTextBox11"
        Me.ContestantFieldTextBox11.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox11.TabIndex = 131
        Me.ContestantFieldTextBox11.Text = "Town1"
        '
        'ContestantFieldTextBox21
        '
        Me.ContestantFieldTextBox21.AllowDrop = True
        Me.ContestantFieldTextBox21.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox21.Location = New System.Drawing.Point(226, 190)
        Me.ContestantFieldTextBox21.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox21.Name = "ContestantFieldTextBox21"
        Me.ContestantFieldTextBox21.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox21.TabIndex = 132
        Me.ContestantFieldTextBox21.Text = "0"
        '
        'ContestantFieldTextBox26
        '
        Me.ContestantFieldTextBox26.AllowDrop = True
        Me.ContestantFieldTextBox26.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox26.Location = New System.Drawing.Point(493, 190)
        Me.ContestantFieldTextBox26.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox26.Name = "ContestantFieldTextBox26"
        Me.ContestantFieldTextBox26.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox26.TabIndex = 135
        Me.ContestantFieldTextBox26.Text = "0"
        '
        'ContestantFieldTextBox16
        '
        Me.ContestantFieldTextBox16.AllowDrop = True
        Me.ContestantFieldTextBox16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox16.Location = New System.Drawing.Point(424, 190)
        Me.ContestantFieldTextBox16.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox16.Name = "ContestantFieldTextBox16"
        Me.ContestantFieldTextBox16.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox16.TabIndex = 134
        Me.ContestantFieldTextBox16.Text = "Town6"
        '
        'ContestantFieldTextBox6
        '
        Me.ContestantFieldTextBox6.AllowDrop = True
        Me.ContestantFieldTextBox6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox6.Location = New System.Drawing.Point(295, 190)
        Me.ContestantFieldTextBox6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox6.Name = "ContestantFieldTextBox6"
        Me.ContestantFieldTextBox6.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox6.TabIndex = 133
        Me.ContestantFieldTextBox6.Text = "Contestant6"
        '
        'Podium1NumberLabel
        '
        Me.Podium1NumberLabel.AutoSize = True
        Me.Podium1NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium1NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium1NumberLabel.Location = New System.Drawing.Point(11, 192)
        Me.Podium1NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium1NumberLabel.Name = "Podium1NumberLabel"
        Me.Podium1NumberLabel.Size = New System.Drawing.Size(13, 13)
        Me.Podium1NumberLabel.TabIndex = 136
        Me.Podium1NumberLabel.Text = "9"
        '
        'Podium6NumberLabel
        '
        Me.Podium6NumberLabel.AutoSize = True
        Me.Podium6NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium6NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium6NumberLabel.Location = New System.Drawing.Point(276, 192)
        Me.Podium6NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium6NumberLabel.Name = "Podium6NumberLabel"
        Me.Podium6NumberLabel.Size = New System.Drawing.Size(13, 13)
        Me.Podium6NumberLabel.TabIndex = 137
        Me.Podium6NumberLabel.Text = "2"
        '
        'Podium7NumberLabel
        '
        Me.Podium7NumberLabel.AutoSize = True
        Me.Podium7NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium7NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium7NumberLabel.Location = New System.Drawing.Point(276, 218)
        Me.Podium7NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium7NumberLabel.Name = "Podium7NumberLabel"
        Me.Podium7NumberLabel.Size = New System.Drawing.Size(13, 13)
        Me.Podium7NumberLabel.TabIndex = 145
        Me.Podium7NumberLabel.Text = "4"
        '
        'Podium2NumberLabel
        '
        Me.Podium2NumberLabel.AutoSize = True
        Me.Podium2NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium2NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium2NumberLabel.Location = New System.Drawing.Point(11, 218)
        Me.Podium2NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium2NumberLabel.Name = "Podium2NumberLabel"
        Me.Podium2NumberLabel.Size = New System.Drawing.Size(13, 13)
        Me.Podium2NumberLabel.TabIndex = 144
        Me.Podium2NumberLabel.Text = "7"
        '
        'ContestantFieldTextBox27
        '
        Me.ContestantFieldTextBox27.AllowDrop = True
        Me.ContestantFieldTextBox27.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox27.Location = New System.Drawing.Point(493, 216)
        Me.ContestantFieldTextBox27.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox27.Name = "ContestantFieldTextBox27"
        Me.ContestantFieldTextBox27.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox27.TabIndex = 143
        Me.ContestantFieldTextBox27.Text = "0"
        '
        'ContestantFieldTextBox17
        '
        Me.ContestantFieldTextBox17.AllowDrop = True
        Me.ContestantFieldTextBox17.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox17.Location = New System.Drawing.Point(424, 216)
        Me.ContestantFieldTextBox17.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox17.Name = "ContestantFieldTextBox17"
        Me.ContestantFieldTextBox17.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox17.TabIndex = 142
        Me.ContestantFieldTextBox17.Text = "Town7"
        '
        'ContestantFieldTextBox7
        '
        Me.ContestantFieldTextBox7.AllowDrop = True
        Me.ContestantFieldTextBox7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox7.Location = New System.Drawing.Point(295, 216)
        Me.ContestantFieldTextBox7.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox7.Name = "ContestantFieldTextBox7"
        Me.ContestantFieldTextBox7.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox7.TabIndex = 141
        Me.ContestantFieldTextBox7.Text = "Contestant7"
        '
        'ContestantFieldTextBox22
        '
        Me.ContestantFieldTextBox22.AllowDrop = True
        Me.ContestantFieldTextBox22.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox22.Location = New System.Drawing.Point(226, 216)
        Me.ContestantFieldTextBox22.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox22.Name = "ContestantFieldTextBox22"
        Me.ContestantFieldTextBox22.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox22.TabIndex = 140
        Me.ContestantFieldTextBox22.Text = "0"
        '
        'ContestantFieldTextBox12
        '
        Me.ContestantFieldTextBox12.AllowDrop = True
        Me.ContestantFieldTextBox12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox12.Location = New System.Drawing.Point(157, 216)
        Me.ContestantFieldTextBox12.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox12.Name = "ContestantFieldTextBox12"
        Me.ContestantFieldTextBox12.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox12.TabIndex = 139
        Me.ContestantFieldTextBox12.Text = "Town2"
        '
        'ContestantFieldTextBox2
        '
        Me.ContestantFieldTextBox2.AllowDrop = True
        Me.ContestantFieldTextBox2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox2.Location = New System.Drawing.Point(28, 216)
        Me.ContestantFieldTextBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox2.Name = "ContestantFieldTextBox2"
        Me.ContestantFieldTextBox2.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox2.TabIndex = 138
        Me.ContestantFieldTextBox2.Text = "Contestant2"
        '
        'Podium8NumberLabel
        '
        Me.Podium8NumberLabel.AutoSize = True
        Me.Podium8NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium8NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium8NumberLabel.Location = New System.Drawing.Point(276, 244)
        Me.Podium8NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium8NumberLabel.Name = "Podium8NumberLabel"
        Me.Podium8NumberLabel.Size = New System.Drawing.Size(13, 13)
        Me.Podium8NumberLabel.TabIndex = 153
        Me.Podium8NumberLabel.Text = "6"
        '
        'Podium3NumberLabel
        '
        Me.Podium3NumberLabel.AutoSize = True
        Me.Podium3NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium3NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium3NumberLabel.Location = New System.Drawing.Point(11, 244)
        Me.Podium3NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium3NumberLabel.Name = "Podium3NumberLabel"
        Me.Podium3NumberLabel.Size = New System.Drawing.Size(13, 13)
        Me.Podium3NumberLabel.TabIndex = 152
        Me.Podium3NumberLabel.Text = "5"
        '
        'ContestantFieldTextBox28
        '
        Me.ContestantFieldTextBox28.AllowDrop = True
        Me.ContestantFieldTextBox28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox28.Location = New System.Drawing.Point(493, 242)
        Me.ContestantFieldTextBox28.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox28.Name = "ContestantFieldTextBox28"
        Me.ContestantFieldTextBox28.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox28.TabIndex = 151
        Me.ContestantFieldTextBox28.Text = "0"
        '
        'ContestantFieldTextBox18
        '
        Me.ContestantFieldTextBox18.AllowDrop = True
        Me.ContestantFieldTextBox18.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox18.Location = New System.Drawing.Point(424, 242)
        Me.ContestantFieldTextBox18.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox18.Name = "ContestantFieldTextBox18"
        Me.ContestantFieldTextBox18.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox18.TabIndex = 150
        Me.ContestantFieldTextBox18.Text = "Town8"
        '
        'ContestantFieldTextBox8
        '
        Me.ContestantFieldTextBox8.AllowDrop = True
        Me.ContestantFieldTextBox8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox8.Location = New System.Drawing.Point(295, 242)
        Me.ContestantFieldTextBox8.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox8.Name = "ContestantFieldTextBox8"
        Me.ContestantFieldTextBox8.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox8.TabIndex = 149
        Me.ContestantFieldTextBox8.Text = "Contestant8"
        '
        'ContestantFieldTextBox23
        '
        Me.ContestantFieldTextBox23.AllowDrop = True
        Me.ContestantFieldTextBox23.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox23.Location = New System.Drawing.Point(226, 242)
        Me.ContestantFieldTextBox23.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox23.Name = "ContestantFieldTextBox23"
        Me.ContestantFieldTextBox23.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox23.TabIndex = 148
        Me.ContestantFieldTextBox23.Text = "0"
        '
        'ContestantFieldTextBox13
        '
        Me.ContestantFieldTextBox13.AllowDrop = True
        Me.ContestantFieldTextBox13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox13.Location = New System.Drawing.Point(157, 242)
        Me.ContestantFieldTextBox13.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox13.Name = "ContestantFieldTextBox13"
        Me.ContestantFieldTextBox13.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox13.TabIndex = 147
        Me.ContestantFieldTextBox13.Text = "Town3"
        '
        'ContestantFieldTextBox3
        '
        Me.ContestantFieldTextBox3.AllowDrop = True
        Me.ContestantFieldTextBox3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox3.Location = New System.Drawing.Point(28, 242)
        Me.ContestantFieldTextBox3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox3.Name = "ContestantFieldTextBox3"
        Me.ContestantFieldTextBox3.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox3.TabIndex = 146
        Me.ContestantFieldTextBox3.Text = "Contestant3"
        '
        'Podium4NumberLabel
        '
        Me.Podium4NumberLabel.AutoSize = True
        Me.Podium4NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium4NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium4NumberLabel.Location = New System.Drawing.Point(11, 270)
        Me.Podium4NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium4NumberLabel.Name = "Podium4NumberLabel"
        Me.Podium4NumberLabel.Size = New System.Drawing.Size(13, 13)
        Me.Podium4NumberLabel.TabIndex = 160
        Me.Podium4NumberLabel.Text = "3"
        '
        'ContestantFieldTextBox29
        '
        Me.ContestantFieldTextBox29.AllowDrop = True
        Me.ContestantFieldTextBox29.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox29.Location = New System.Drawing.Point(493, 268)
        Me.ContestantFieldTextBox29.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox29.Name = "ContestantFieldTextBox29"
        Me.ContestantFieldTextBox29.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox29.TabIndex = 159
        Me.ContestantFieldTextBox29.Text = "0"
        '
        'ContestantFieldTextBox19
        '
        Me.ContestantFieldTextBox19.AllowDrop = True
        Me.ContestantFieldTextBox19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox19.Location = New System.Drawing.Point(424, 268)
        Me.ContestantFieldTextBox19.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox19.Name = "ContestantFieldTextBox19"
        Me.ContestantFieldTextBox19.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox19.TabIndex = 158
        Me.ContestantFieldTextBox19.Text = "Town9"
        '
        'ContestantFieldTextBox9
        '
        Me.ContestantFieldTextBox9.AllowDrop = True
        Me.ContestantFieldTextBox9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox9.Location = New System.Drawing.Point(295, 268)
        Me.ContestantFieldTextBox9.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox9.Name = "ContestantFieldTextBox9"
        Me.ContestantFieldTextBox9.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox9.TabIndex = 157
        Me.ContestantFieldTextBox9.Text = "Contestant9"
        '
        'ContestantFieldTextBox24
        '
        Me.ContestantFieldTextBox24.AllowDrop = True
        Me.ContestantFieldTextBox24.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox24.Location = New System.Drawing.Point(226, 268)
        Me.ContestantFieldTextBox24.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox24.Name = "ContestantFieldTextBox24"
        Me.ContestantFieldTextBox24.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox24.TabIndex = 156
        Me.ContestantFieldTextBox24.Text = "0"
        '
        'ContestantFieldTextBox14
        '
        Me.ContestantFieldTextBox14.AllowDrop = True
        Me.ContestantFieldTextBox14.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox14.Location = New System.Drawing.Point(157, 268)
        Me.ContestantFieldTextBox14.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox14.Name = "ContestantFieldTextBox14"
        Me.ContestantFieldTextBox14.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox14.TabIndex = 155
        Me.ContestantFieldTextBox14.Text = "Town4"
        '
        'ContestantFieldTextBox4
        '
        Me.ContestantFieldTextBox4.AllowDrop = True
        Me.ContestantFieldTextBox4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox4.Location = New System.Drawing.Point(28, 268)
        Me.ContestantFieldTextBox4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox4.Name = "ContestantFieldTextBox4"
        Me.ContestantFieldTextBox4.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox4.TabIndex = 154
        Me.ContestantFieldTextBox4.Text = "Contestant4"
        '
        'Podium10NumberLabel
        '
        Me.Podium10NumberLabel.AutoSize = True
        Me.Podium10NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium10NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium10NumberLabel.Location = New System.Drawing.Point(271, 296)
        Me.Podium10NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium10NumberLabel.Name = "Podium10NumberLabel"
        Me.Podium10NumberLabel.Size = New System.Drawing.Size(19, 13)
        Me.Podium10NumberLabel.TabIndex = 169
        Me.Podium10NumberLabel.Text = "10"
        '
        'Podium5NumberLabel
        '
        Me.Podium5NumberLabel.AutoSize = True
        Me.Podium5NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium5NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium5NumberLabel.Location = New System.Drawing.Point(11, 296)
        Me.Podium5NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium5NumberLabel.Name = "Podium5NumberLabel"
        Me.Podium5NumberLabel.Size = New System.Drawing.Size(13, 13)
        Me.Podium5NumberLabel.TabIndex = 168
        Me.Podium5NumberLabel.Text = "1"
        '
        'ContestantFieldTextBox30
        '
        Me.ContestantFieldTextBox30.AllowDrop = True
        Me.ContestantFieldTextBox30.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox30.Location = New System.Drawing.Point(493, 294)
        Me.ContestantFieldTextBox30.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox30.Name = "ContestantFieldTextBox30"
        Me.ContestantFieldTextBox30.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox30.TabIndex = 167
        Me.ContestantFieldTextBox30.Text = "0"
        '
        'ContestantFieldTextBox20
        '
        Me.ContestantFieldTextBox20.AllowDrop = True
        Me.ContestantFieldTextBox20.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox20.Location = New System.Drawing.Point(424, 294)
        Me.ContestantFieldTextBox20.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox20.Name = "ContestantFieldTextBox20"
        Me.ContestantFieldTextBox20.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox20.TabIndex = 166
        Me.ContestantFieldTextBox20.Text = "Town10"
        '
        'ContestantFieldTextBox10
        '
        Me.ContestantFieldTextBox10.AllowDrop = True
        Me.ContestantFieldTextBox10.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox10.Location = New System.Drawing.Point(295, 294)
        Me.ContestantFieldTextBox10.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox10.Name = "ContestantFieldTextBox10"
        Me.ContestantFieldTextBox10.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox10.TabIndex = 165
        Me.ContestantFieldTextBox10.Text = "Contestant10"
        '
        'ContestantFieldTextBox25
        '
        Me.ContestantFieldTextBox25.AllowDrop = True
        Me.ContestantFieldTextBox25.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox25.Location = New System.Drawing.Point(226, 294)
        Me.ContestantFieldTextBox25.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox25.Name = "ContestantFieldTextBox25"
        Me.ContestantFieldTextBox25.Size = New System.Drawing.Size(40, 20)
        Me.ContestantFieldTextBox25.TabIndex = 164
        Me.ContestantFieldTextBox25.Text = "0"
        '
        'ContestantFieldTextBox15
        '
        Me.ContestantFieldTextBox15.AllowDrop = True
        Me.ContestantFieldTextBox15.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox15.Location = New System.Drawing.Point(157, 294)
        Me.ContestantFieldTextBox15.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox15.Name = "ContestantFieldTextBox15"
        Me.ContestantFieldTextBox15.Size = New System.Drawing.Size(70, 20)
        Me.ContestantFieldTextBox15.TabIndex = 163
        Me.ContestantFieldTextBox15.Text = "Town5"
        '
        'ContestantFieldTextBox5
        '
        Me.ContestantFieldTextBox5.AllowDrop = True
        Me.ContestantFieldTextBox5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantFieldTextBox5.Location = New System.Drawing.Point(28, 294)
        Me.ContestantFieldTextBox5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ContestantFieldTextBox5.Name = "ContestantFieldTextBox5"
        Me.ContestantFieldTextBox5.Size = New System.Drawing.Size(130, 20)
        Me.ContestantFieldTextBox5.TabIndex = 162
        Me.ContestantFieldTextBox5.Text = "Contestant5"
        '
        'LeftNameHeaderLabel
        '
        Me.LeftNameHeaderLabel.AutoSize = True
        Me.LeftNameHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.LeftNameHeaderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LeftNameHeaderLabel.Location = New System.Drawing.Point(25, 174)
        Me.LeftNameHeaderLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LeftNameHeaderLabel.Name = "LeftNameHeaderLabel"
        Me.LeftNameHeaderLabel.Size = New System.Drawing.Size(35, 13)
        Me.LeftNameHeaderLabel.TabIndex = 170
        Me.LeftNameHeaderLabel.Text = "Name"
        '
        'LeftFromHeaderLabel
        '
        Me.LeftFromHeaderLabel.AutoSize = True
        Me.LeftFromHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.LeftFromHeaderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LeftFromHeaderLabel.Location = New System.Drawing.Point(154, 174)
        Me.LeftFromHeaderLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LeftFromHeaderLabel.Name = "LeftFromHeaderLabel"
        Me.LeftFromHeaderLabel.Size = New System.Drawing.Size(30, 13)
        Me.LeftFromHeaderLabel.TabIndex = 171
        Me.LeftFromHeaderLabel.Text = "From"
        '
        'LeftTimeHeaderLabel
        '
        Me.LeftTimeHeaderLabel.AutoSize = True
        Me.LeftTimeHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.LeftTimeHeaderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LeftTimeHeaderLabel.Location = New System.Drawing.Point(223, 174)
        Me.LeftTimeHeaderLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LeftTimeHeaderLabel.Name = "LeftTimeHeaderLabel"
        Me.LeftTimeHeaderLabel.Size = New System.Drawing.Size(30, 13)
        Me.LeftTimeHeaderLabel.TabIndex = 172
        Me.LeftTimeHeaderLabel.Text = "Time"
        '
        'RightTimeHeaderLabel
        '
        Me.RightTimeHeaderLabel.AutoSize = True
        Me.RightTimeHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.RightTimeHeaderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RightTimeHeaderLabel.Location = New System.Drawing.Point(490, 174)
        Me.RightTimeHeaderLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.RightTimeHeaderLabel.Name = "RightTimeHeaderLabel"
        Me.RightTimeHeaderLabel.Size = New System.Drawing.Size(30, 13)
        Me.RightTimeHeaderLabel.TabIndex = 175
        Me.RightTimeHeaderLabel.Text = "Time"
        '
        'RightFromHeaderLabel
        '
        Me.RightFromHeaderLabel.AutoSize = True
        Me.RightFromHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.RightFromHeaderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RightFromHeaderLabel.Location = New System.Drawing.Point(421, 174)
        Me.RightFromHeaderLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.RightFromHeaderLabel.Name = "RightFromHeaderLabel"
        Me.RightFromHeaderLabel.Size = New System.Drawing.Size(30, 13)
        Me.RightFromHeaderLabel.TabIndex = 174
        Me.RightFromHeaderLabel.Text = "From"
        '
        'RightNameHeaderLabel
        '
        Me.RightNameHeaderLabel.AutoSize = True
        Me.RightNameHeaderLabel.ForeColor = System.Drawing.Color.White
        Me.RightNameHeaderLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RightNameHeaderLabel.Location = New System.Drawing.Point(292, 174)
        Me.RightNameHeaderLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.RightNameHeaderLabel.Name = "RightNameHeaderLabel"
        Me.RightNameHeaderLabel.Size = New System.Drawing.Size(35, 13)
        Me.RightNameHeaderLabel.TabIndex = 173
        Me.RightNameHeaderLabel.Text = "Name"
        '
        'NameCycleTimer
        '
        Me.NameCycleTimer.Interval = 3200
        '
        'Podium9NumberLabel
        '
        Me.Podium9NumberLabel.AutoSize = True
        Me.Podium9NumberLabel.ForeColor = System.Drawing.Color.White
        Me.Podium9NumberLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Podium9NumberLabel.Location = New System.Drawing.Point(276, 270)
        Me.Podium9NumberLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Podium9NumberLabel.Name = "Podium9NumberLabel"
        Me.Podium9NumberLabel.Size = New System.Drawing.Size(13, 13)
        Me.Podium9NumberLabel.TabIndex = 161
        Me.Podium9NumberLabel.Text = "8"
        '
        'ResultsRevealTimer
        '
        '
        'WinnerRevealTimer
        '
        Me.WinnerRevealTimer.Interval = 200
        '
        'OpenContestantsListDialog
        '
        Me.OpenContestantsListDialog.Filter = "Contestants List File|*.con"
        Me.OpenContestantsListDialog.InitialDirectory = "Bases\"
        '
        'NameSequenceTimer
        '
        Me.NameSequenceTimer.Interval = 35000
        '
        'ClockTimer
        '
        Me.ClockTimer.Interval = 500
        '
        'OpenContestantsListButton
        '
        Me.OpenContestantsListButton.BackColor = System.Drawing.Color.White
        Me.OpenContestantsListButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OpenContestantsListButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.OpenContestantsListButton.Location = New System.Drawing.Point(295, 326)
        Me.OpenContestantsListButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.OpenContestantsListButton.Name = "OpenContestantsListButton"
        Me.OpenContestantsListButton.Size = New System.Drawing.Size(239, 23)
        Me.OpenContestantsListButton.TabIndex = 176
        Me.OpenContestantsListButton.Text = "Open contestants list..."
        Me.OpenContestantsListButton.UseVisualStyleBackColor = False
        '
        'DropWinnerCheckBox
        '
        Me.DropWinnerCheckBox.AutoSize = True
        Me.DropWinnerCheckBox.ForeColor = System.Drawing.Color.White
        Me.DropWinnerCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.DropWinnerCheckBox.Location = New System.Drawing.Point(28, 330)
        Me.DropWinnerCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.DropWinnerCheckBox.Name = "DropWinnerCheckBox"
        Me.DropWinnerCheckBox.Size = New System.Drawing.Size(157, 17)
        Me.DropWinnerCheckBox.TabIndex = 177
        Me.DropWinnerCheckBox.Text = "Drop the winner from the list"
        Me.DropWinnerCheckBox.UseVisualStyleBackColor = True
        '
        'TwoWinnersCheckBox
        '
        Me.TwoWinnersCheckBox.AutoSize = True
        Me.TwoWinnersCheckBox.ForeColor = System.Drawing.Color.White
        Me.TwoWinnersCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TwoWinnersCheckBox.Location = New System.Drawing.Point(331, 101)
        Me.TwoWinnersCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TwoWinnersCheckBox.Name = "TwoWinnersCheckBox"
        Me.TwoWinnersCheckBox.Size = New System.Drawing.Size(86, 17)
        Me.TwoWinnersCheckBox.TabIndex = 178
        Me.TwoWinnersCheckBox.Text = "Two winners"
        Me.TwoWinnersCheckBox.UseVisualStyleBackColor = True
        '
        'FastestFingerFirstForm
        '
        Me.AllowDrop = True
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(544, 361)
        Me.Controls.Add(Me.TwoWinnersCheckBox)
        Me.Controls.Add(Me.DropWinnerCheckBox)
        Me.Controls.Add(Me.OpenContestantsListButton)
        Me.Controls.Add(Me.RightTimeHeaderLabel)
        Me.Controls.Add(Me.RightFromHeaderLabel)
        Me.Controls.Add(Me.RightNameHeaderLabel)
        Me.Controls.Add(Me.LeftTimeHeaderLabel)
        Me.Controls.Add(Me.LeftFromHeaderLabel)
        Me.Controls.Add(Me.LeftNameHeaderLabel)
        Me.Controls.Add(Me.Podium10NumberLabel)
        Me.Controls.Add(Me.Podium5NumberLabel)
        Me.Controls.Add(Me.ContestantFieldTextBox30)
        Me.Controls.Add(Me.ContestantFieldTextBox20)
        Me.Controls.Add(Me.ContestantFieldTextBox10)
        Me.Controls.Add(Me.ContestantFieldTextBox25)
        Me.Controls.Add(Me.ContestantFieldTextBox15)
        Me.Controls.Add(Me.ContestantFieldTextBox5)
        Me.Controls.Add(Me.Podium9NumberLabel)
        Me.Controls.Add(Me.Podium4NumberLabel)
        Me.Controls.Add(Me.ContestantFieldTextBox29)
        Me.Controls.Add(Me.ContestantFieldTextBox19)
        Me.Controls.Add(Me.ContestantFieldTextBox9)
        Me.Controls.Add(Me.ContestantFieldTextBox24)
        Me.Controls.Add(Me.ContestantFieldTextBox14)
        Me.Controls.Add(Me.ContestantFieldTextBox4)
        Me.Controls.Add(Me.Podium8NumberLabel)
        Me.Controls.Add(Me.Podium3NumberLabel)
        Me.Controls.Add(Me.ContestantFieldTextBox28)
        Me.Controls.Add(Me.ContestantFieldTextBox18)
        Me.Controls.Add(Me.ContestantFieldTextBox8)
        Me.Controls.Add(Me.ContestantFieldTextBox23)
        Me.Controls.Add(Me.ContestantFieldTextBox13)
        Me.Controls.Add(Me.ContestantFieldTextBox3)
        Me.Controls.Add(Me.Podium7NumberLabel)
        Me.Controls.Add(Me.Podium2NumberLabel)
        Me.Controls.Add(Me.ContestantFieldTextBox27)
        Me.Controls.Add(Me.ContestantFieldTextBox17)
        Me.Controls.Add(Me.ContestantFieldTextBox7)
        Me.Controls.Add(Me.ContestantFieldTextBox22)
        Me.Controls.Add(Me.ContestantFieldTextBox12)
        Me.Controls.Add(Me.ContestantFieldTextBox2)
        Me.Controls.Add(Me.Podium6NumberLabel)
        Me.Controls.Add(Me.Podium1NumberLabel)
        Me.Controls.Add(Me.ContestantFieldTextBox26)
        Me.Controls.Add(Me.ContestantFieldTextBox16)
        Me.Controls.Add(Me.ContestantFieldTextBox6)
        Me.Controls.Add(Me.ContestantFieldTextBox21)
        Me.Controls.Add(Me.ContestantFieldTextBox11)
        Me.Controls.Add(Me.ContestantFieldTextBox1)
        Me.Controls.Add(Me.QuestionTextLabel)
        Me.Controls.Add(Me.FullQuestionTextLabel)
        Me.Controls.Add(Me.OpenQuestionBaseButton)
        Me.Controls.Add(Me.TodaysNamesButton)
        Me.Controls.Add(Me.QuestionListBox)
        Me.Controls.Add(Me.RightOrder4Button)
        Me.Controls.Add(Me.RightOrder3Button)
        Me.Controls.Add(Me.RightOrder2Button)
        Me.Controls.Add(Me.RightOrder1Button)
        Me.Controls.Add(Me.QualifyingWinnerButton)
        Me.Controls.Add(Me.CorrectAnswersButton)
        Me.Controls.Add(Me.RightOrderButton)
        Me.Controls.Add(Me.StartTimerButton)
        Me.Controls.Add(Me.ThreeBeepsButton)
        Me.Controls.Add(Me.AskQuestionButton)
        Me.Controls.Add(Me.ExplainRulesButton)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.ControlProgram.My.Resources.Resources.ICON
        Me.MaximizeBox = False
        Me.Name = "FastestFingerFirstForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fastest Finger First"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ExplainRulesButton As System.Windows.Forms.Button
    Friend WithEvents AskQuestionButton As System.Windows.Forms.Button
    Friend WithEvents ThreeBeepsButton As System.Windows.Forms.Button
    Friend WithEvents StartTimerButton As System.Windows.Forms.Button
    Friend WithEvents RightOrderButton As System.Windows.Forms.Button
    Friend WithEvents CorrectAnswersButton As System.Windows.Forms.Button
    Friend WithEvents QualifyingWinnerButton As System.Windows.Forms.Button
    Friend WithEvents RightOrder1Button As System.Windows.Forms.Button
    Friend WithEvents RightOrder2Button As System.Windows.Forms.Button
    Friend WithEvents RightOrder3Button As System.Windows.Forms.Button
    Friend WithEvents RightOrder4Button As System.Windows.Forms.Button
    Friend WithEvents QuestionListBox As System.Windows.Forms.ListBox
    Friend WithEvents TodaysNamesButton As System.Windows.Forms.Button
    Friend WithEvents OpenQuestionBaseButton As System.Windows.Forms.Button
    Friend WithEvents OpenQuestionBaseDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents QuestionTextLabel As System.Windows.Forms.Label
    Friend WithEvents FullQuestionTextLabel As System.Windows.Forms.Label
    Friend WithEvents ContestantFieldTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox21 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox26 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Podium1NumberLabel As System.Windows.Forms.Label
    Friend WithEvents Podium6NumberLabel As System.Windows.Forms.Label
    Friend WithEvents Podium7NumberLabel As System.Windows.Forms.Label
    Friend WithEvents Podium2NumberLabel As System.Windows.Forms.Label
    Friend WithEvents ContestantFieldTextBox27 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox17 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox22 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Podium8NumberLabel As System.Windows.Forms.Label
    Friend WithEvents Podium3NumberLabel As System.Windows.Forms.Label
    Friend WithEvents ContestantFieldTextBox28 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox18 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox23 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Podium4NumberLabel As System.Windows.Forms.Label
    Friend WithEvents ContestantFieldTextBox29 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox19 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox24 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Podium10NumberLabel As System.Windows.Forms.Label
    Friend WithEvents Podium5NumberLabel As System.Windows.Forms.Label
    Friend WithEvents ContestantFieldTextBox30 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox20 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox25 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents ContestantFieldTextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents LeftNameHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents LeftFromHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents LeftTimeHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents RightTimeHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents RightFromHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents RightNameHeaderLabel As System.Windows.Forms.Label
    Friend WithEvents NameCycleTimer As System.Windows.Forms.Timer
    Friend WithEvents Podium9NumberLabel As System.Windows.Forms.Label
    Friend WithEvents ResultsRevealTimer As System.Windows.Forms.Timer
    Friend WithEvents WinnerRevealTimer As System.Windows.Forms.Timer
    Friend WithEvents OpenContestantsListDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents NameSequenceTimer As System.Windows.Forms.Timer
    Friend WithEvents ClockTimer As System.Windows.Forms.Timer
    Friend WithEvents OpenContestantsListButton As System.Windows.Forms.Button
    Friend WithEvents DropWinnerCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TwoWinnersCheckBox As System.Windows.Forms.CheckBox
End Class
