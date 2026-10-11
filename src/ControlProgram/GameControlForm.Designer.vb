<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class GameControlForm
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
        Me.MoneyTakenCheckBox = New System.Windows.Forms.CheckBox()
        Me.BigQuitButton = New System.Windows.Forms.Button()
        Me.LittleQuitButton = New System.Windows.Forms.Button()
        Me.OpenQuestionBaseButton = New System.Windows.Forms.Button()
        Me.QuestionFilePathLabel = New System.Windows.Forms.Label()
        Me.ContestantLabel = New System.Windows.Forms.Label()
        Me.AnswerDTextLabel = New System.Windows.Forms.Label()
        Me.AnswerCTextLabel = New System.Windows.Forms.Label()
        Me.AnswerBTextLabel = New System.Windows.Forms.Label()
        Me.AnswerATextLabel = New System.Windows.Forms.Label()
        Me.QuestionTextLabel = New System.Windows.Forms.Label()
        Me.AudienceVisibleCheckBox = New System.Windows.Forms.CheckBox()
        Me.PlayerVisibleCheckBox = New System.Windows.Forms.CheckBox()
        Me.HostVisibleCheckBox = New System.Windows.Forms.CheckBox()
        Me.AudienceFrameCheckBox = New System.Windows.Forms.CheckBox()
        Me.PlayerFrameCheckBox = New System.Windows.Forms.CheckBox()
        Me.HostFrameCheckBox = New System.Windows.Forms.CheckBox()
        Me.ContestantNameTextBox = New System.Windows.Forms.TextBox()
        Me.ClearHostMessageButton = New System.Windows.Forms.Button()
        Me.SendHostMessageButton = New System.Windows.Forms.Button()
        Me.HostMessageLabel = New System.Windows.Forms.Label()
        Me.HostMessageTextBox = New System.Windows.Forms.TextBox()
        Me.AvailabilityLabel = New System.Windows.Forms.Label()
        Me.FramesLabel = New System.Windows.Forms.Label()
        Me.LocationLabel = New System.Windows.Forms.Label()
        Me.MusicLabel = New System.Windows.Forms.Label()
        Me.MoneyLabel = New System.Windows.Forms.Label()
        Me.AskTheAudienceAvailableCheckBox = New System.Windows.Forms.CheckBox()
        Me.PhoneAFriendAvailableCheckBox = New System.Windows.Forms.CheckBox()
        Me.FiftyFiftyAvailableCheckBox = New System.Windows.Forms.CheckBox()
        Me.LifelinesLabel = New System.Windows.Forms.Label()
        Me.AnswersLabel = New System.Windows.Forms.Label()
        Me.AnswerIndicatorLabel = New System.Windows.Forms.Label()
        Me.RevealCorrectAnswerButton = New System.Windows.Forms.Button()
        Me.StopMusicButton = New System.Windows.Forms.Button()
        Me.StopSoundButton = New System.Windows.Forms.Button()
        Me.SmsClockButton = New System.Windows.Forms.Button()
        Me.StereoTestButton = New System.Windows.Forms.Button()
        Me.ClosingTitlesButton = New System.Windows.Forms.Button()
        Me.TomorrowsNamesButton = New System.Windows.Forms.Button()
        Me.TimesUpButton = New System.Windows.Forms.Button()
        Me.GoodbyePunterButton = New System.Windows.Forms.Button()
        Me.HelloAgainButton = New System.Windows.Forms.Button()
        Me.SeeYouLaterButton = New System.Windows.Forms.Button()
        Me.StartTheGameButton = New System.Windows.Forms.Button()
        Me.LightsToCentreButton = New System.Windows.Forms.Button()
        Me.AskTheAudienceMusicButton = New System.Windows.Forms.Button()
        Me.PhoneAFriendMusicButton = New System.Windows.Forms.Button()
        Me.FiftyFiftyMusicButton = New System.Windows.Forms.Button()
        Me.LifelineExplanationsButton = New System.Windows.Forms.Button()
        Me.ClearFormsButton = New System.Windows.Forms.Button()
        Me.LetsPlayButton = New System.Windows.Forms.Button()
        Me.HostEntranceButton = New System.Windows.Forms.Button()
        Me.TakeTheMoneyButton = New System.Windows.Forms.Button()
        Me.ToggleLifelinesPanelButton = New System.Windows.Forms.Button()
        Me.AskTheAudienceButton = New System.Windows.Forms.Button()
        Me.FiftyFiftyButton = New System.Windows.Forms.Button()
        Me.ToggleLogoButton = New System.Windows.Forms.Button()
        Me.PhoneAFriendButton = New System.Windows.Forms.Button()
        Me.ToggleHintButton = New System.Windows.Forms.Button()
        Me.LightsDownButton = New System.Windows.Forms.Button()
        Me.ReceiveAnswerDButton = New System.Windows.Forms.Button()
        Me.ReceiveAnswerCButton = New System.Windows.Forms.Button()
        Me.ReceiveAnswerBButton = New System.Windows.Forms.Button()
        Me.ReceiveAnswerAButton = New System.Windows.Forms.Button()
        Me.ConnectButton = New System.Windows.Forms.Button()
        Me.EnableAnswersLabel = New System.Windows.Forms.Label()
        Me.EnableAllAnswersButton = New System.Windows.Forms.Button()
        Me.EnableAnswerDButton = New System.Windows.Forms.Button()
        Me.EnableAnswerCButton = New System.Windows.Forms.Button()
        Me.EnableAnswerBButton = New System.Windows.Forms.Button()
        Me.EnableAnswerAButton = New System.Windows.Forms.Button()
        Me.AskQuestionButton = New System.Windows.Forms.Button()
        Me.QuestionPreviewLabel = New System.Windows.Forms.Label()
        Me.FullQuestionTextLabel = New System.Windows.Forms.Label()
        Me.QuestionListBox = New System.Windows.Forms.ListBox()
        Me.ConnectSettingsLabel = New System.Windows.Forms.Label()
        Me.ServerPortTextBox = New System.Windows.Forms.TextBox()
        Me.ServerIpTextBox = New System.Windows.Forms.TextBox()
        Me.QuestionsLabel = New System.Windows.Forms.Label()
        Me.QuestionNumberNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.PrizeRevealTimer = New System.Windows.Forms.Timer(Me.components)
        Me.MoneyWonRevealTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LifelinesRefreshTimer = New System.Windows.Forms.Timer(Me.components)
        Me.OpenQuestionBaseDialog = New System.Windows.Forms.OpenFileDialog()
        Me.AudienceScreenYNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AudienceScreenXNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.PlayerScreenYNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.PlayerScreenXNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.HostScreenYNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.HostScreenXNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AboutButton = New System.Windows.Forms.Button()
        Me.LifelinesPictureBox = New System.Windows.Forms.PictureBox()
        Me.MoneyTreePictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerDFramePictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerCFramePictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerBFramePictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerAFramePictureBox = New System.Windows.Forms.PictureBox()
        Me.QuestionFramePictureBox = New System.Windows.Forms.PictureBox()
        Me.HostLocationLabel = New System.Windows.Forms.Label()
        Me.PlayerLocationLabel = New System.Windows.Forms.Label()
        Me.AudienceLocationLabel = New System.Windows.Forms.Label()
        Me.FastestFingerFirstButton = New System.Windows.Forms.Button()
        Me.MoneyTreeUpButton = New System.Windows.Forms.Button()
        Me.MoneyTreeDownButton = New System.Windows.Forms.Button()
        Me.MoneyTreeLevel15Button = New System.Windows.Forms.Button()
        Me.MoneyTreeLevel10Button = New System.Windows.Forms.Button()
        Me.MoneyTreeLevel5Button = New System.Windows.Forms.Button()
        Me.MoneyTreeLevel0Button = New System.Windows.Forms.Button()
        Me.OpeningTitlesButton = New System.Windows.Forms.Button()
        Me.LifelinesPanelSlideTimer = New System.Windows.Forms.Timer(Me.components)
        Me.LifelinesPanelHoldTimer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.QuestionNumberNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AudienceScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AudienceScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlayerScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlayerScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HostScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HostScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LifelinesPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MoneyTreePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerDFramePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerCFramePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerBFramePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerAFramePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.QuestionFramePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MoneyTakenCheckBox
        '
        Me.MoneyTakenCheckBox.AutoSize = True
        Me.MoneyTakenCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.MoneyTakenCheckBox.ForeColor = System.Drawing.Color.White
        Me.MoneyTakenCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTakenCheckBox.Location = New System.Drawing.Point(460, 167)
        Me.MoneyTakenCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MoneyTakenCheckBox.Name = "MoneyTakenCheckBox"
        Me.MoneyTakenCheckBox.Size = New System.Drawing.Size(105, 17)
        Me.MoneyTakenCheckBox.TabIndex = 202
        Me.MoneyTakenCheckBox.Text = "Money h/b taken"
        Me.MoneyTakenCheckBox.UseVisualStyleBackColor = True
        '
        'BigQuitButton
        '
        Me.BigQuitButton.BackColor = System.Drawing.Color.White
        Me.BigQuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.BigQuitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.BigQuitButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.BigQuitButton.Location = New System.Drawing.Point(508, 136)
        Me.BigQuitButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.BigQuitButton.Name = "BigQuitButton"
        Me.BigQuitButton.Size = New System.Drawing.Size(52, 23)
        Me.BigQuitButton.TabIndex = 201
        Me.BigQuitButton.Text = "Big Quit"
        Me.BigQuitButton.UseVisualStyleBackColor = False
        '
        'LittleQuitButton
        '
        Me.LittleQuitButton.BackColor = System.Drawing.Color.White
        Me.LittleQuitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LittleQuitButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        Me.LittleQuitButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LittleQuitButton.Location = New System.Drawing.Point(460, 136)
        Me.LittleQuitButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.LittleQuitButton.Name = "LittleQuitButton"
        Me.LittleQuitButton.Size = New System.Drawing.Size(48, 23)
        Me.LittleQuitButton.TabIndex = 200
        Me.LittleQuitButton.Text = "Lit Quit"
        Me.LittleQuitButton.UseVisualStyleBackColor = False
        '
        'OpenQuestionBaseButton
        '
        Me.OpenQuestionBaseButton.BackColor = System.Drawing.Color.White
        Me.OpenQuestionBaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OpenQuestionBaseButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.OpenQuestionBaseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.OpenQuestionBaseButton.Location = New System.Drawing.Point(109, 77)
        Me.OpenQuestionBaseButton.Name = "OpenQuestionBaseButton"
        Me.OpenQuestionBaseButton.Size = New System.Drawing.Size(52, 23)
        Me.OpenQuestionBaseButton.TabIndex = 197
        Me.OpenQuestionBaseButton.Text = "Open..."
        Me.OpenQuestionBaseButton.UseVisualStyleBackColor = False
        '
        'QuestionFilePathLabel
        '
        Me.QuestionFilePathLabel.AutoSize = True
        Me.QuestionFilePathLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.QuestionFilePathLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.QuestionFilePathLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionFilePathLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QuestionFilePathLabel.Location = New System.Drawing.Point(587, 33)
        Me.QuestionFilePathLabel.MaximumSize = New System.Drawing.Size(340, 26)
        Me.QuestionFilePathLabel.MinimumSize = New System.Drawing.Size(0, 26)
        Me.QuestionFilePathLabel.Name = "QuestionFilePathLabel"
        Me.QuestionFilePathLabel.Size = New System.Drawing.Size(103, 26)
        Me.QuestionFilePathLabel.TabIndex = 196
        Me.QuestionFilePathLabel.Text = "Question File Adress"
        Me.QuestionFilePathLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ContestantLabel
        '
        Me.ContestantLabel.AutoSize = True
        Me.ContestantLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.ContestantLabel.ForeColor = System.Drawing.Color.White
        Me.ContestantLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ContestantLabel.Location = New System.Drawing.Point(822, 364)
        Me.ContestantLabel.Name = "ContestantLabel"
        Me.ContestantLabel.Size = New System.Drawing.Size(98, 24)
        Me.ContestantLabel.TabIndex = 194
        Me.ContestantLabel.Text = "Contestant"
        '
        'AnswerDTextLabel
        '
        Me.AnswerDTextLabel.AutoSize = True
        Me.AnswerDTextLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.AnswerDTextLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerDTextLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerDTextLabel.Location = New System.Drawing.Point(583, 672)
        Me.AnswerDTextLabel.MaximumSize = New System.Drawing.Size(335, 39)
        Me.AnswerDTextLabel.MinimumSize = New System.Drawing.Size(0, 39)
        Me.AnswerDTextLabel.Name = "AnswerDTextLabel"
        Me.AnswerDTextLabel.Size = New System.Drawing.Size(147, 39)
        Me.AnswerDTextLabel.TabIndex = 189
        Me.AnswerDTextLabel.Text = "Answer D"
        Me.AnswerDTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AnswerCTextLabel
        '
        Me.AnswerCTextLabel.AutoSize = True
        Me.AnswerCTextLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.AnswerCTextLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerCTextLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerCTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerCTextLabel.Location = New System.Drawing.Point(124, 673)
        Me.AnswerCTextLabel.MaximumSize = New System.Drawing.Size(335, 39)
        Me.AnswerCTextLabel.MinimumSize = New System.Drawing.Size(0, 39)
        Me.AnswerCTextLabel.Name = "AnswerCTextLabel"
        Me.AnswerCTextLabel.Size = New System.Drawing.Size(145, 39)
        Me.AnswerCTextLabel.TabIndex = 188
        Me.AnswerCTextLabel.Text = "Answer C"
        Me.AnswerCTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AnswerBTextLabel
        '
        Me.AnswerBTextLabel.AutoSize = True
        Me.AnswerBTextLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.AnswerBTextLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerBTextLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerBTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerBTextLabel.Location = New System.Drawing.Point(583, 607)
        Me.AnswerBTextLabel.MaximumSize = New System.Drawing.Size(335, 39)
        Me.AnswerBTextLabel.MinimumSize = New System.Drawing.Size(0, 39)
        Me.AnswerBTextLabel.Name = "AnswerBTextLabel"
        Me.AnswerBTextLabel.Size = New System.Drawing.Size(147, 39)
        Me.AnswerBTextLabel.TabIndex = 187
        Me.AnswerBTextLabel.Text = "Answer B"
        Me.AnswerBTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AnswerATextLabel
        '
        Me.AnswerATextLabel.AutoSize = True
        Me.AnswerATextLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.AnswerATextLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerATextLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerATextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerATextLabel.Location = New System.Drawing.Point(125, 607)
        Me.AnswerATextLabel.MaximumSize = New System.Drawing.Size(335, 39)
        Me.AnswerATextLabel.MinimumSize = New System.Drawing.Size(0, 39)
        Me.AnswerATextLabel.Name = "AnswerATextLabel"
        Me.AnswerATextLabel.Size = New System.Drawing.Size(144, 39)
        Me.AnswerATextLabel.TabIndex = 186
        Me.AnswerATextLabel.Text = "Answer A"
        Me.AnswerATextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'QuestionTextLabel
        '
        Me.QuestionTextLabel.AutoSize = True
        Me.QuestionTextLabel.BackColor = System.Drawing.Color.Transparent
        Me.QuestionTextLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.QuestionTextLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QuestionTextLabel.Location = New System.Drawing.Point(120, 492)
        Me.QuestionTextLabel.MaximumSize = New System.Drawing.Size(766, 90)
        Me.QuestionTextLabel.MinimumSize = New System.Drawing.Size(766, 90)
        Me.QuestionTextLabel.Name = "QuestionTextLabel"
        Me.QuestionTextLabel.Size = New System.Drawing.Size(766, 90)
        Me.QuestionTextLabel.TabIndex = 185
        Me.QuestionTextLabel.Text = "Question Text"
        Me.QuestionTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AudienceVisibleCheckBox
        '
        Me.AudienceVisibleCheckBox.AutoSize = True
        Me.AudienceVisibleCheckBox.Checked = True
        Me.AudienceVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AudienceVisibleCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.AudienceVisibleCheckBox.ForeColor = System.Drawing.Color.White
        Me.AudienceVisibleCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AudienceVisibleCheckBox.Location = New System.Drawing.Point(826, 338)
        Me.AudienceVisibleCheckBox.Name = "AudienceVisibleCheckBox"
        Me.AudienceVisibleCheckBox.Size = New System.Drawing.Size(70, 17)
        Me.AudienceVisibleCheckBox.TabIndex = 184
        Me.AudienceVisibleCheckBox.Text = "Audience"
        Me.AudienceVisibleCheckBox.UseVisualStyleBackColor = True
        '
        'PlayerVisibleCheckBox
        '
        Me.PlayerVisibleCheckBox.AutoSize = True
        Me.PlayerVisibleCheckBox.Checked = True
        Me.PlayerVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PlayerVisibleCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.PlayerVisibleCheckBox.ForeColor = System.Drawing.Color.White
        Me.PlayerVisibleCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PlayerVisibleCheckBox.Location = New System.Drawing.Point(826, 323)
        Me.PlayerVisibleCheckBox.Name = "PlayerVisibleCheckBox"
        Me.PlayerVisibleCheckBox.Size = New System.Drawing.Size(55, 17)
        Me.PlayerVisibleCheckBox.TabIndex = 183
        Me.PlayerVisibleCheckBox.Text = "Player"
        Me.PlayerVisibleCheckBox.UseVisualStyleBackColor = True
        '
        'HostVisibleCheckBox
        '
        Me.HostVisibleCheckBox.AutoSize = True
        Me.HostVisibleCheckBox.Checked = True
        Me.HostVisibleCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.HostVisibleCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.HostVisibleCheckBox.ForeColor = System.Drawing.Color.White
        Me.HostVisibleCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.HostVisibleCheckBox.Location = New System.Drawing.Point(826, 308)
        Me.HostVisibleCheckBox.Name = "HostVisibleCheckBox"
        Me.HostVisibleCheckBox.Size = New System.Drawing.Size(47, 17)
        Me.HostVisibleCheckBox.TabIndex = 182
        Me.HostVisibleCheckBox.Text = "Host"
        Me.HostVisibleCheckBox.UseVisualStyleBackColor = True
        '
        'AudienceFrameCheckBox
        '
        Me.AudienceFrameCheckBox.AutoSize = True
        Me.AudienceFrameCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.AudienceFrameCheckBox.ForeColor = System.Drawing.Color.White
        Me.AudienceFrameCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AudienceFrameCheckBox.Location = New System.Drawing.Point(826, 252)
        Me.AudienceFrameCheckBox.Name = "AudienceFrameCheckBox"
        Me.AudienceFrameCheckBox.Size = New System.Drawing.Size(70, 17)
        Me.AudienceFrameCheckBox.TabIndex = 181
        Me.AudienceFrameCheckBox.Text = "Audience"
        Me.AudienceFrameCheckBox.UseVisualStyleBackColor = True
        '
        'PlayerFrameCheckBox
        '
        Me.PlayerFrameCheckBox.AutoSize = True
        Me.PlayerFrameCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.PlayerFrameCheckBox.ForeColor = System.Drawing.Color.White
        Me.PlayerFrameCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PlayerFrameCheckBox.Location = New System.Drawing.Point(826, 237)
        Me.PlayerFrameCheckBox.Name = "PlayerFrameCheckBox"
        Me.PlayerFrameCheckBox.Size = New System.Drawing.Size(55, 17)
        Me.PlayerFrameCheckBox.TabIndex = 180
        Me.PlayerFrameCheckBox.Text = "Player"
        Me.PlayerFrameCheckBox.UseVisualStyleBackColor = True
        '
        'HostFrameCheckBox
        '
        Me.HostFrameCheckBox.AutoSize = True
        Me.HostFrameCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.HostFrameCheckBox.ForeColor = System.Drawing.Color.White
        Me.HostFrameCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.HostFrameCheckBox.Location = New System.Drawing.Point(826, 222)
        Me.HostFrameCheckBox.Name = "HostFrameCheckBox"
        Me.HostFrameCheckBox.Size = New System.Drawing.Size(47, 17)
        Me.HostFrameCheckBox.TabIndex = 179
        Me.HostFrameCheckBox.Text = "Host"
        Me.HostFrameCheckBox.UseVisualStyleBackColor = True
        '
        'ContestantNameTextBox
        '
        Me.ContestantNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ContestantNameTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ContestantNameTextBox.Location = New System.Drawing.Point(826, 395)
        Me.ContestantNameTextBox.MaxLength = 25
        Me.ContestantNameTextBox.Name = "ContestantNameTextBox"
        Me.ContestantNameTextBox.Size = New System.Drawing.Size(171, 19)
        Me.ContestantNameTextBox.TabIndex = 178
        Me.ContestantNameTextBox.Text = "Contestant Name"
        '
        'ClearHostMessageButton
        '
        Me.ClearHostMessageButton.BackColor = System.Drawing.Color.White
        Me.ClearHostMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClearHostMessageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ClearHostMessageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ClearHostMessageButton.Location = New System.Drawing.Point(330, 395)
        Me.ClearHostMessageButton.Name = "ClearHostMessageButton"
        Me.ClearHostMessageButton.Size = New System.Drawing.Size(100, 23)
        Me.ClearHostMessageButton.TabIndex = 177
        Me.ClearHostMessageButton.Text = "Clear"
        Me.ClearHostMessageButton.UseVisualStyleBackColor = False
        '
        'SendHostMessageButton
        '
        Me.SendHostMessageButton.BackColor = System.Drawing.Color.White
        Me.SendHostMessageButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SendHostMessageButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.SendHostMessageButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SendHostMessageButton.Location = New System.Drawing.Point(200, 395)
        Me.SendHostMessageButton.Name = "SendHostMessageButton"
        Me.SendHostMessageButton.Size = New System.Drawing.Size(99, 23)
        Me.SendHostMessageButton.TabIndex = 176
        Me.SendHostMessageButton.Text = "Send"
        Me.SendHostMessageButton.UseVisualStyleBackColor = False
        '
        'HostMessageLabel
        '
        Me.HostMessageLabel.AutoSize = True
        Me.HostMessageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.HostMessageLabel.ForeColor = System.Drawing.Color.White
        Me.HostMessageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.HostMessageLabel.Location = New System.Drawing.Point(196, 340)
        Me.HostMessageLabel.Name = "HostMessageLabel"
        Me.HostMessageLabel.Size = New System.Drawing.Size(147, 24)
        Me.HostMessageLabel.TabIndex = 175
        Me.HostMessageLabel.Text = "Message to host"
        '
        'HostMessageTextBox
        '
        Me.HostMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HostMessageTextBox.Location = New System.Drawing.Point(200, 369)
        Me.HostMessageTextBox.Name = "HostMessageTextBox"
        Me.HostMessageTextBox.Size = New System.Drawing.Size(230, 20)
        Me.HostMessageTextBox.TabIndex = 174
        '
        'AvailabilityLabel
        '
        Me.AvailabilityLabel.AutoSize = True
        Me.AvailabilityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.AvailabilityLabel.ForeColor = System.Drawing.Color.White
        Me.AvailabilityLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AvailabilityLabel.Location = New System.Drawing.Point(822, 280)
        Me.AvailabilityLabel.Name = "AvailabilityLabel"
        Me.AvailabilityLabel.Size = New System.Drawing.Size(96, 24)
        Me.AvailabilityLabel.TabIndex = 173
        Me.AvailabilityLabel.Text = "Availability"
        '
        'FramesLabel
        '
        Me.FramesLabel.AutoSize = True
        Me.FramesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.FramesLabel.ForeColor = System.Drawing.Color.White
        Me.FramesLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FramesLabel.Location = New System.Drawing.Point(822, 193)
        Me.FramesLabel.Name = "FramesLabel"
        Me.FramesLabel.Size = New System.Drawing.Size(74, 24)
        Me.FramesLabel.TabIndex = 172
        Me.FramesLabel.Text = "Frames"
        '
        'LocationLabel
        '
        Me.LocationLabel.AutoSize = True
        Me.LocationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.LocationLabel.ForeColor = System.Drawing.Color.White
        Me.LocationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LocationLabel.Location = New System.Drawing.Point(822, 78)
        Me.LocationLabel.Name = "LocationLabel"
        Me.LocationLabel.Size = New System.Drawing.Size(81, 24)
        Me.LocationLabel.TabIndex = 171
        Me.LocationLabel.Text = "Location"
        '
        'MusicLabel
        '
        Me.MusicLabel.AutoSize = True
        Me.MusicLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.MusicLabel.ForeColor = System.Drawing.Color.White
        Me.MusicLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MusicLabel.Location = New System.Drawing.Point(586, 78)
        Me.MusicLabel.Name = "MusicLabel"
        Me.MusicLabel.Size = New System.Drawing.Size(60, 24)
        Me.MusicLabel.TabIndex = 164
        Me.MusicLabel.Text = "Music"
        '
        'MoneyLabel
        '
        Me.MoneyLabel.AutoSize = True
        Me.MoneyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.MoneyLabel.ForeColor = System.Drawing.Color.White
        Me.MoneyLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyLabel.Location = New System.Drawing.Point(456, 78)
        Me.MoneyLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.MoneyLabel.Name = "MoneyLabel"
        Me.MoneyLabel.Size = New System.Drawing.Size(68, 24)
        Me.MoneyLabel.TabIndex = 163
        Me.MoneyLabel.Text = "Money"
        '
        'AskTheAudienceAvailableCheckBox
        '
        Me.AskTheAudienceAvailableCheckBox.AutoSize = True
        Me.AskTheAudienceAvailableCheckBox.Checked = True
        Me.AskTheAudienceAvailableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AskTheAudienceAvailableCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.AskTheAudienceAvailableCheckBox.ForeColor = System.Drawing.Color.White
        Me.AskTheAudienceAvailableCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AskTheAudienceAvailableCheckBox.Location = New System.Drawing.Point(330, 255)
        Me.AskTheAudienceAvailableCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AskTheAudienceAvailableCheckBox.Name = "AskTheAudienceAvailableCheckBox"
        Me.AskTheAudienceAvailableCheckBox.Size = New System.Drawing.Size(45, 17)
        Me.AskTheAudienceAvailableCheckBox.TabIndex = 162
        Me.AskTheAudienceAvailableCheckBox.Text = "ATA"
        Me.AskTheAudienceAvailableCheckBox.UseVisualStyleBackColor = True
        '
        'PhoneAFriendAvailableCheckBox
        '
        Me.PhoneAFriendAvailableCheckBox.AutoSize = True
        Me.PhoneAFriendAvailableCheckBox.Checked = True
        Me.PhoneAFriendAvailableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PhoneAFriendAvailableCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.PhoneAFriendAvailableCheckBox.ForeColor = System.Drawing.Color.White
        Me.PhoneAFriendAvailableCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PhoneAFriendAvailableCheckBox.Location = New System.Drawing.Point(330, 226)
        Me.PhoneAFriendAvailableCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PhoneAFriendAvailableCheckBox.Name = "PhoneAFriendAvailableCheckBox"
        Me.PhoneAFriendAvailableCheckBox.Size = New System.Drawing.Size(46, 17)
        Me.PhoneAFriendAvailableCheckBox.TabIndex = 161
        Me.PhoneAFriendAvailableCheckBox.Text = "PAF"
        Me.PhoneAFriendAvailableCheckBox.UseVisualStyleBackColor = True
        '
        'FiftyFiftyAvailableCheckBox
        '
        Me.FiftyFiftyAvailableCheckBox.AutoSize = True
        Me.FiftyFiftyAvailableCheckBox.Checked = True
        Me.FiftyFiftyAvailableCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.FiftyFiftyAvailableCheckBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.FiftyFiftyAvailableCheckBox.ForeColor = System.Drawing.Color.White
        Me.FiftyFiftyAvailableCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FiftyFiftyAvailableCheckBox.Location = New System.Drawing.Point(330, 198)
        Me.FiftyFiftyAvailableCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FiftyFiftyAvailableCheckBox.Name = "FiftyFiftyAvailableCheckBox"
        Me.FiftyFiftyAvailableCheckBox.Size = New System.Drawing.Size(53, 17)
        Me.FiftyFiftyAvailableCheckBox.TabIndex = 160
        Me.FiftyFiftyAvailableCheckBox.Text = "50:50"
        Me.FiftyFiftyAvailableCheckBox.UseVisualStyleBackColor = True
        '
        'LifelinesLabel
        '
        Me.LifelinesLabel.AutoSize = True
        Me.LifelinesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.LifelinesLabel.ForeColor = System.Drawing.Color.White
        Me.LifelinesLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LifelinesLabel.Location = New System.Drawing.Point(326, 78)
        Me.LifelinesLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.LifelinesLabel.Name = "LifelinesLabel"
        Me.LifelinesLabel.Size = New System.Drawing.Size(78, 24)
        Me.LifelinesLabel.TabIndex = 159
        Me.LifelinesLabel.Text = "Lifelines"
        '
        'AnswersLabel
        '
        Me.AnswersLabel.AutoSize = True
        Me.AnswersLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.AnswersLabel.ForeColor = System.Drawing.Color.White
        Me.AnswersLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswersLabel.Location = New System.Drawing.Point(196, 78)
        Me.AnswersLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.AnswersLabel.Name = "AnswersLabel"
        Me.AnswersLabel.Size = New System.Drawing.Size(83, 24)
        Me.AnswersLabel.TabIndex = 158
        Me.AnswersLabel.Text = "Answers"
        '
        'AnswerIndicatorLabel
        '
        Me.AnswerIndicatorLabel.AutoSize = True
        Me.AnswerIndicatorLabel.BackColor = System.Drawing.Color.DarkGray
        Me.AnswerIndicatorLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.AnswerIndicatorLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerIndicatorLabel.Location = New System.Drawing.Point(201, 222)
        Me.AnswerIndicatorLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.AnswerIndicatorLabel.MinimumSize = New System.Drawing.Size(98, 23)
        Me.AnswerIndicatorLabel.Name = "AnswerIndicatorLabel"
        Me.AnswerIndicatorLabel.Size = New System.Drawing.Size(98, 23)
        Me.AnswerIndicatorLabel.TabIndex = 157
        Me.AnswerIndicatorLabel.Text = "Answer Indicator"
        Me.AnswerIndicatorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RevealCorrectAnswerButton
        '
        Me.RevealCorrectAnswerButton.BackColor = System.Drawing.Color.White
        Me.RevealCorrectAnswerButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RevealCorrectAnswerButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.RevealCorrectAnswerButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.RevealCorrectAnswerButton.Location = New System.Drawing.Point(200, 251)
        Me.RevealCorrectAnswerButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RevealCorrectAnswerButton.Name = "RevealCorrectAnswerButton"
        Me.RevealCorrectAnswerButton.Size = New System.Drawing.Size(100, 23)
        Me.RevealCorrectAnswerButton.TabIndex = 156
        Me.RevealCorrectAnswerButton.Text = "What's Correct"
        Me.RevealCorrectAnswerButton.UseVisualStyleBackColor = False
        '
        'StopMusicButton
        '
        Me.StopMusicButton.BackColor = System.Drawing.Color.White
        Me.StopMusicButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StopMusicButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.StopMusicButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.StopMusicButton.Location = New System.Drawing.Point(696, 367)
        Me.StopMusicButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StopMusicButton.Name = "StopMusicButton"
        Me.StopMusicButton.Size = New System.Drawing.Size(100, 23)
        Me.StopMusicButton.TabIndex = 152
        Me.StopMusicButton.Text = "Stop Music"
        Me.StopMusicButton.UseVisualStyleBackColor = False
        '
        'StopSoundButton
        '
        Me.StopSoundButton.BackColor = System.Drawing.Color.White
        Me.StopSoundButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StopSoundButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.StopSoundButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.StopSoundButton.Location = New System.Drawing.Point(590, 367)
        Me.StopSoundButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StopSoundButton.Name = "StopSoundButton"
        Me.StopSoundButton.Size = New System.Drawing.Size(100, 23)
        Me.StopSoundButton.TabIndex = 151
        Me.StopSoundButton.Text = "Stop Sound"
        Me.StopSoundButton.UseVisualStyleBackColor = False
        '
        'SmsClockButton
        '
        Me.SmsClockButton.BackColor = System.Drawing.Color.White
        Me.SmsClockButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SmsClockButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.SmsClockButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SmsClockButton.Location = New System.Drawing.Point(696, 309)
        Me.SmsClockButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.SmsClockButton.Name = "SmsClockButton"
        Me.SmsClockButton.Size = New System.Drawing.Size(100, 23)
        Me.SmsClockButton.TabIndex = 150
        Me.SmsClockButton.Text = "SMS Clock"
        Me.SmsClockButton.UseVisualStyleBackColor = False
        '
        'StereoTestButton
        '
        Me.StereoTestButton.BackColor = System.Drawing.Color.White
        Me.StereoTestButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StereoTestButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.StereoTestButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.StereoTestButton.Location = New System.Drawing.Point(590, 309)
        Me.StereoTestButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StereoTestButton.Name = "StereoTestButton"
        Me.StereoTestButton.Size = New System.Drawing.Size(100, 23)
        Me.StereoTestButton.TabIndex = 149
        Me.StereoTestButton.Text = "Stereo Test"
        Me.StereoTestButton.UseVisualStyleBackColor = False
        '
        'ClosingTitlesButton
        '
        Me.ClosingTitlesButton.BackColor = System.Drawing.Color.White
        Me.ClosingTitlesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClosingTitlesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ClosingTitlesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ClosingTitlesButton.Location = New System.Drawing.Point(696, 280)
        Me.ClosingTitlesButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ClosingTitlesButton.Name = "ClosingTitlesButton"
        Me.ClosingTitlesButton.Size = New System.Drawing.Size(100, 23)
        Me.ClosingTitlesButton.TabIndex = 148
        Me.ClosingTitlesButton.Text = "Closing Titles"
        Me.ClosingTitlesButton.UseVisualStyleBackColor = False
        '
        'TomorrowsNamesButton
        '
        Me.TomorrowsNamesButton.BackColor = System.Drawing.Color.White
        Me.TomorrowsNamesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.TomorrowsNamesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.TomorrowsNamesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TomorrowsNamesButton.Location = New System.Drawing.Point(590, 280)
        Me.TomorrowsNamesButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TomorrowsNamesButton.Name = "TomorrowsNamesButton"
        Me.TomorrowsNamesButton.Size = New System.Drawing.Size(100, 23)
        Me.TomorrowsNamesButton.TabIndex = 147
        Me.TomorrowsNamesButton.Text = "Tomorrow's Names"
        Me.TomorrowsNamesButton.UseVisualStyleBackColor = False
        '
        'TimesUpButton
        '
        Me.TimesUpButton.BackColor = System.Drawing.Color.White
        Me.TimesUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.TimesUpButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.TimesUpButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TimesUpButton.Location = New System.Drawing.Point(696, 251)
        Me.TimesUpButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TimesUpButton.Name = "TimesUpButton"
        Me.TimesUpButton.Size = New System.Drawing.Size(100, 23)
        Me.TimesUpButton.TabIndex = 146
        Me.TimesUpButton.Text = "Time's Up"
        Me.TimesUpButton.UseVisualStyleBackColor = False
        '
        'GoodbyePunterButton
        '
        Me.GoodbyePunterButton.BackColor = System.Drawing.Color.White
        Me.GoodbyePunterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.GoodbyePunterButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.GoodbyePunterButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.GoodbyePunterButton.Location = New System.Drawing.Point(590, 251)
        Me.GoodbyePunterButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.GoodbyePunterButton.Name = "GoodbyePunterButton"
        Me.GoodbyePunterButton.Size = New System.Drawing.Size(100, 23)
        Me.GoodbyePunterButton.TabIndex = 145
        Me.GoodbyePunterButton.Text = "Goodbye Punter"
        Me.GoodbyePunterButton.UseVisualStyleBackColor = False
        '
        'HelloAgainButton
        '
        Me.HelloAgainButton.BackColor = System.Drawing.Color.White
        Me.HelloAgainButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.HelloAgainButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.HelloAgainButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.HelloAgainButton.Location = New System.Drawing.Point(696, 222)
        Me.HelloAgainButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.HelloAgainButton.Name = "HelloAgainButton"
        Me.HelloAgainButton.Size = New System.Drawing.Size(100, 23)
        Me.HelloAgainButton.TabIndex = 144
        Me.HelloAgainButton.Text = "Hello Again (P2)"
        Me.HelloAgainButton.UseVisualStyleBackColor = False
        '
        'SeeYouLaterButton
        '
        Me.SeeYouLaterButton.BackColor = System.Drawing.Color.White
        Me.SeeYouLaterButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SeeYouLaterButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.SeeYouLaterButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.SeeYouLaterButton.Location = New System.Drawing.Point(590, 222)
        Me.SeeYouLaterButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.SeeYouLaterButton.Name = "SeeYouLaterButton"
        Me.SeeYouLaterButton.Size = New System.Drawing.Size(100, 23)
        Me.SeeYouLaterButton.TabIndex = 143
        Me.SeeYouLaterButton.Text = "See You Later (P1)"
        Me.SeeYouLaterButton.UseVisualStyleBackColor = False
        '
        'StartTheGameButton
        '
        Me.StartTheGameButton.BackColor = System.Drawing.Color.White
        Me.StartTheGameButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StartTheGameButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.StartTheGameButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.StartTheGameButton.Location = New System.Drawing.Point(696, 164)
        Me.StartTheGameButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StartTheGameButton.Name = "StartTheGameButton"
        Me.StartTheGameButton.Size = New System.Drawing.Size(100, 23)
        Me.StartTheGameButton.TabIndex = 142
        Me.StartTheGameButton.Text = "Start the game"
        Me.StartTheGameButton.UseVisualStyleBackColor = False
        '
        'LightsToCentreButton
        '
        Me.LightsToCentreButton.BackColor = System.Drawing.Color.White
        Me.LightsToCentreButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LightsToCentreButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.LightsToCentreButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LightsToCentreButton.Location = New System.Drawing.Point(696, 135)
        Me.LightsToCentreButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.LightsToCentreButton.Name = "LightsToCentreButton"
        Me.LightsToCentreButton.Size = New System.Drawing.Size(100, 23)
        Me.LightsToCentreButton.TabIndex = 141
        Me.LightsToCentreButton.Text = "LX To Centre"
        Me.LightsToCentreButton.UseVisualStyleBackColor = False
        '
        'AskTheAudienceMusicButton
        '
        Me.AskTheAudienceMusicButton.BackColor = System.Drawing.Color.White
        Me.AskTheAudienceMusicButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AskTheAudienceMusicButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!)
        Me.AskTheAudienceMusicButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AskTheAudienceMusicButton.Location = New System.Drawing.Point(660, 164)
        Me.AskTheAudienceMusicButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AskTheAudienceMusicButton.Name = "AskTheAudienceMusicButton"
        Me.AskTheAudienceMusicButton.Size = New System.Drawing.Size(30, 23)
        Me.AskTheAudienceMusicButton.TabIndex = 140
        Me.AskTheAudienceMusicButton.Text = "ATA"
        Me.AskTheAudienceMusicButton.UseVisualStyleBackColor = False
        '
        'PhoneAFriendMusicButton
        '
        Me.PhoneAFriendMusicButton.BackColor = System.Drawing.Color.White
        Me.PhoneAFriendMusicButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.PhoneAFriendMusicButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!)
        Me.PhoneAFriendMusicButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PhoneAFriendMusicButton.Location = New System.Drawing.Point(625, 164)
        Me.PhoneAFriendMusicButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PhoneAFriendMusicButton.Name = "PhoneAFriendMusicButton"
        Me.PhoneAFriendMusicButton.Size = New System.Drawing.Size(30, 23)
        Me.PhoneAFriendMusicButton.TabIndex = 139
        Me.PhoneAFriendMusicButton.Text = "PAF"
        Me.PhoneAFriendMusicButton.UseVisualStyleBackColor = False
        '
        'FiftyFiftyMusicButton
        '
        Me.FiftyFiftyMusicButton.BackColor = System.Drawing.Color.White
        Me.FiftyFiftyMusicButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FiftyFiftyMusicButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 5.25!)
        Me.FiftyFiftyMusicButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FiftyFiftyMusicButton.Location = New System.Drawing.Point(590, 164)
        Me.FiftyFiftyMusicButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FiftyFiftyMusicButton.Name = "FiftyFiftyMusicButton"
        Me.FiftyFiftyMusicButton.Size = New System.Drawing.Size(30, 23)
        Me.FiftyFiftyMusicButton.TabIndex = 138
        Me.FiftyFiftyMusicButton.Text = "50:50"
        Me.FiftyFiftyMusicButton.UseVisualStyleBackColor = False
        '
        'LifelineExplanationsButton
        '
        Me.LifelineExplanationsButton.BackColor = System.Drawing.Color.White
        Me.LifelineExplanationsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LifelineExplanationsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.LifelineExplanationsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LifelineExplanationsButton.Location = New System.Drawing.Point(590, 135)
        Me.LifelineExplanationsButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.LifelineExplanationsButton.Name = "LifelineExplanationsButton"
        Me.LifelineExplanationsButton.Size = New System.Drawing.Size(100, 23)
        Me.LifelineExplanationsButton.TabIndex = 137
        Me.LifelineExplanationsButton.Text = "Lifeline Explanations"
        Me.LifelineExplanationsButton.UseVisualStyleBackColor = False
        '
        'ClearFormsButton
        '
        Me.ClearFormsButton.BackColor = System.Drawing.Color.White
        Me.ClearFormsButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ClearFormsButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ClearFormsButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ClearFormsButton.Location = New System.Drawing.Point(460, 35)
        Me.ClearFormsButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ClearFormsButton.Name = "ClearFormsButton"
        Me.ClearFormsButton.Size = New System.Drawing.Size(100, 23)
        Me.ClearFormsButton.TabIndex = 136
        Me.ClearFormsButton.Text = "Clear forms"
        Me.ClearFormsButton.UseVisualStyleBackColor = False
        '
        'LetsPlayButton
        '
        Me.LetsPlayButton.BackColor = System.Drawing.Color.White
        Me.LetsPlayButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LetsPlayButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.LetsPlayButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LetsPlayButton.Location = New System.Drawing.Point(696, 106)
        Me.LetsPlayButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.LetsPlayButton.Name = "LetsPlayButton"
        Me.LetsPlayButton.Size = New System.Drawing.Size(100, 23)
        Me.LetsPlayButton.TabIndex = 135
        Me.LetsPlayButton.Text = "Let's Play"
        Me.LetsPlayButton.UseVisualStyleBackColor = False
        '
        'HostEntranceButton
        '
        Me.HostEntranceButton.BackColor = System.Drawing.Color.White
        Me.HostEntranceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.HostEntranceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.HostEntranceButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.HostEntranceButton.Location = New System.Drawing.Point(590, 106)
        Me.HostEntranceButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.HostEntranceButton.Name = "HostEntranceButton"
        Me.HostEntranceButton.Size = New System.Drawing.Size(100, 23)
        Me.HostEntranceButton.TabIndex = 134
        Me.HostEntranceButton.Text = "Host Entrance"
        Me.HostEntranceButton.UseVisualStyleBackColor = False
        '
        'TakeTheMoneyButton
        '
        Me.TakeTheMoneyButton.BackColor = System.Drawing.Color.White
        Me.TakeTheMoneyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.TakeTheMoneyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.TakeTheMoneyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TakeTheMoneyButton.Location = New System.Drawing.Point(460, 106)
        Me.TakeTheMoneyButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TakeTheMoneyButton.Name = "TakeTheMoneyButton"
        Me.TakeTheMoneyButton.Size = New System.Drawing.Size(100, 23)
        Me.TakeTheMoneyButton.TabIndex = 133
        Me.TakeTheMoneyButton.Text = "Take the money"
        Me.TakeTheMoneyButton.UseVisualStyleBackColor = False
        '
        'ToggleLifelinesPanelButton
        '
        Me.ToggleLifelinesPanelButton.BackColor = System.Drawing.Color.White
        Me.ToggleLifelinesPanelButton.Enabled = False
        Me.ToggleLifelinesPanelButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ToggleLifelinesPanelButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ToggleLifelinesPanelButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToggleLifelinesPanelButton.Location = New System.Drawing.Point(330, 280)
        Me.ToggleLifelinesPanelButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ToggleLifelinesPanelButton.Name = "ToggleLifelinesPanelButton"
        Me.ToggleLifelinesPanelButton.Size = New System.Drawing.Size(100, 23)
        Me.ToggleLifelinesPanelButton.TabIndex = 132
        Me.ToggleLifelinesPanelButton.Text = "Show panel"
        Me.ToggleLifelinesPanelButton.UseVisualStyleBackColor = False
        '
        'AskTheAudienceButton
        '
        Me.AskTheAudienceButton.BackColor = System.Drawing.Color.White
        Me.AskTheAudienceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AskTheAudienceButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!)
        Me.AskTheAudienceButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AskTheAudienceButton.Location = New System.Drawing.Point(330, 164)
        Me.AskTheAudienceButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AskTheAudienceButton.Name = "AskTheAudienceButton"
        Me.AskTheAudienceButton.Size = New System.Drawing.Size(100, 23)
        Me.AskTheAudienceButton.TabIndex = 131
        Me.AskTheAudienceButton.Text = "Ask The Audience"
        Me.AskTheAudienceButton.UseVisualStyleBackColor = False
        '
        'FiftyFiftyButton
        '
        Me.FiftyFiftyButton.BackColor = System.Drawing.Color.White
        Me.FiftyFiftyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FiftyFiftyButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.FiftyFiftyButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FiftyFiftyButton.Location = New System.Drawing.Point(330, 106)
        Me.FiftyFiftyButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FiftyFiftyButton.Name = "FiftyFiftyButton"
        Me.FiftyFiftyButton.Size = New System.Drawing.Size(100, 23)
        Me.FiftyFiftyButton.TabIndex = 130
        Me.FiftyFiftyButton.Text = "Fifty-Fifty"
        Me.FiftyFiftyButton.UseVisualStyleBackColor = False
        '
        'ToggleLogoButton
        '
        Me.ToggleLogoButton.BackColor = System.Drawing.Color.White
        Me.ToggleLogoButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ToggleLogoButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ToggleLogoButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToggleLogoButton.Location = New System.Drawing.Point(330, 35)
        Me.ToggleLogoButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ToggleLogoButton.Name = "ToggleLogoButton"
        Me.ToggleLogoButton.Size = New System.Drawing.Size(100, 23)
        Me.ToggleLogoButton.TabIndex = 129
        Me.ToggleLogoButton.Text = "Show logo"
        Me.ToggleLogoButton.UseVisualStyleBackColor = False
        '
        'PhoneAFriendButton
        '
        Me.PhoneAFriendButton.BackColor = System.Drawing.Color.White
        Me.PhoneAFriendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.PhoneAFriendButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.PhoneAFriendButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PhoneAFriendButton.Location = New System.Drawing.Point(330, 135)
        Me.PhoneAFriendButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PhoneAFriendButton.Name = "PhoneAFriendButton"
        Me.PhoneAFriendButton.Size = New System.Drawing.Size(100, 23)
        Me.PhoneAFriendButton.TabIndex = 128
        Me.PhoneAFriendButton.Text = "Phone-A-Friend"
        Me.PhoneAFriendButton.UseVisualStyleBackColor = False
        '
        'ToggleHintButton
        '
        Me.ToggleHintButton.BackColor = System.Drawing.Color.White
        Me.ToggleHintButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ToggleHintButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ToggleHintButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ToggleHintButton.Location = New System.Drawing.Point(200, 309)
        Me.ToggleHintButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ToggleHintButton.Name = "ToggleHintButton"
        Me.ToggleHintButton.Size = New System.Drawing.Size(100, 23)
        Me.ToggleHintButton.TabIndex = 127
        Me.ToggleHintButton.Text = "Show hint"
        Me.ToggleHintButton.UseVisualStyleBackColor = False
        '
        'LightsDownButton
        '
        Me.LightsDownButton.BackColor = System.Drawing.Color.White
        Me.LightsDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.LightsDownButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.LightsDownButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LightsDownButton.Location = New System.Drawing.Point(200, 280)
        Me.LightsDownButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.LightsDownButton.Name = "LightsDownButton"
        Me.LightsDownButton.Size = New System.Drawing.Size(100, 23)
        Me.LightsDownButton.TabIndex = 126
        Me.LightsDownButton.Text = "LX"
        Me.LightsDownButton.UseVisualStyleBackColor = False
        '
        'ReceiveAnswerDButton
        '
        Me.ReceiveAnswerDButton.BackColor = System.Drawing.Color.White
        Me.ReceiveAnswerDButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ReceiveAnswerDButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ReceiveAnswerDButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ReceiveAnswerDButton.Location = New System.Drawing.Point(200, 193)
        Me.ReceiveAnswerDButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ReceiveAnswerDButton.Name = "ReceiveAnswerDButton"
        Me.ReceiveAnswerDButton.Size = New System.Drawing.Size(100, 23)
        Me.ReceiveAnswerDButton.TabIndex = 125
        Me.ReceiveAnswerDButton.Text = "Receive D"
        Me.ReceiveAnswerDButton.UseVisualStyleBackColor = False
        '
        'ReceiveAnswerCButton
        '
        Me.ReceiveAnswerCButton.BackColor = System.Drawing.Color.White
        Me.ReceiveAnswerCButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ReceiveAnswerCButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ReceiveAnswerCButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ReceiveAnswerCButton.Location = New System.Drawing.Point(200, 164)
        Me.ReceiveAnswerCButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ReceiveAnswerCButton.Name = "ReceiveAnswerCButton"
        Me.ReceiveAnswerCButton.Size = New System.Drawing.Size(100, 23)
        Me.ReceiveAnswerCButton.TabIndex = 124
        Me.ReceiveAnswerCButton.Text = "Receive C"
        Me.ReceiveAnswerCButton.UseVisualStyleBackColor = False
        '
        'ReceiveAnswerBButton
        '
        Me.ReceiveAnswerBButton.BackColor = System.Drawing.Color.White
        Me.ReceiveAnswerBButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ReceiveAnswerBButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ReceiveAnswerBButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ReceiveAnswerBButton.Location = New System.Drawing.Point(200, 135)
        Me.ReceiveAnswerBButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ReceiveAnswerBButton.Name = "ReceiveAnswerBButton"
        Me.ReceiveAnswerBButton.Size = New System.Drawing.Size(100, 23)
        Me.ReceiveAnswerBButton.TabIndex = 123
        Me.ReceiveAnswerBButton.Text = "Receive B"
        Me.ReceiveAnswerBButton.UseVisualStyleBackColor = False
        '
        'ReceiveAnswerAButton
        '
        Me.ReceiveAnswerAButton.BackColor = System.Drawing.Color.White
        Me.ReceiveAnswerAButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ReceiveAnswerAButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ReceiveAnswerAButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ReceiveAnswerAButton.Location = New System.Drawing.Point(200, 106)
        Me.ReceiveAnswerAButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ReceiveAnswerAButton.Name = "ReceiveAnswerAButton"
        Me.ReceiveAnswerAButton.Size = New System.Drawing.Size(100, 23)
        Me.ReceiveAnswerAButton.TabIndex = 122
        Me.ReceiveAnswerAButton.Text = "Receive A"
        Me.ReceiveAnswerAButton.UseVisualStyleBackColor = False
        '
        'ConnectButton
        '
        Me.ConnectButton.BackColor = System.Drawing.Color.White
        Me.ConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ConnectButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ConnectButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ConnectButton.Location = New System.Drawing.Point(200, 35)
        Me.ConnectButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ConnectButton.Name = "ConnectButton"
        Me.ConnectButton.Size = New System.Drawing.Size(100, 23)
        Me.ConnectButton.TabIndex = 121
        Me.ConnectButton.Text = "Connect"
        Me.ConnectButton.UseVisualStyleBackColor = False
        '
        'EnableAnswersLabel
        '
        Me.EnableAnswersLabel.AutoSize = True
        Me.EnableAnswersLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.EnableAnswersLabel.ForeColor = System.Drawing.Color.White
        Me.EnableAnswersLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EnableAnswersLabel.Location = New System.Drawing.Point(8, 369)
        Me.EnableAnswersLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.EnableAnswersLabel.Name = "EnableAnswersLabel"
        Me.EnableAnswersLabel.Size = New System.Drawing.Size(145, 24)
        Me.EnableAnswersLabel.TabIndex = 119
        Me.EnableAnswersLabel.Text = "Enable answers"
        '
        'EnableAllAnswersButton
        '
        Me.EnableAllAnswersButton.BackColor = System.Drawing.Color.White
        Me.EnableAllAnswersButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.EnableAllAnswersButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!)
        Me.EnableAllAnswersButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EnableAllAnswersButton.Location = New System.Drawing.Point(130, 395)
        Me.EnableAllAnswersButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.EnableAllAnswersButton.Name = "EnableAllAnswersButton"
        Me.EnableAllAnswersButton.Size = New System.Drawing.Size(31, 23)
        Me.EnableAllAnswersButton.TabIndex = 118
        Me.EnableAllAnswersButton.Text = "All"
        Me.EnableAllAnswersButton.UseVisualStyleBackColor = False
        '
        'EnableAnswerDButton
        '
        Me.EnableAnswerDButton.BackColor = System.Drawing.Color.White
        Me.EnableAnswerDButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.EnableAnswerDButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.EnableAnswerDButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EnableAnswerDButton.Location = New System.Drawing.Point(101, 395)
        Me.EnableAnswerDButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.EnableAnswerDButton.Name = "EnableAnswerDButton"
        Me.EnableAnswerDButton.Size = New System.Drawing.Size(31, 23)
        Me.EnableAnswerDButton.TabIndex = 117
        Me.EnableAnswerDButton.Text = "D"
        Me.EnableAnswerDButton.UseVisualStyleBackColor = False
        '
        'EnableAnswerCButton
        '
        Me.EnableAnswerCButton.BackColor = System.Drawing.Color.White
        Me.EnableAnswerCButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.EnableAnswerCButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.EnableAnswerCButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EnableAnswerCButton.Location = New System.Drawing.Point(71, 395)
        Me.EnableAnswerCButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.EnableAnswerCButton.Name = "EnableAnswerCButton"
        Me.EnableAnswerCButton.Size = New System.Drawing.Size(31, 23)
        Me.EnableAnswerCButton.TabIndex = 116
        Me.EnableAnswerCButton.Text = "C"
        Me.EnableAnswerCButton.UseVisualStyleBackColor = False
        '
        'EnableAnswerBButton
        '
        Me.EnableAnswerBButton.BackColor = System.Drawing.Color.White
        Me.EnableAnswerBButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.EnableAnswerBButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.EnableAnswerBButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EnableAnswerBButton.Location = New System.Drawing.Point(41, 395)
        Me.EnableAnswerBButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.EnableAnswerBButton.Name = "EnableAnswerBButton"
        Me.EnableAnswerBButton.Size = New System.Drawing.Size(31, 23)
        Me.EnableAnswerBButton.TabIndex = 115
        Me.EnableAnswerBButton.Text = "B"
        Me.EnableAnswerBButton.UseVisualStyleBackColor = False
        '
        'EnableAnswerAButton
        '
        Me.EnableAnswerAButton.BackColor = System.Drawing.Color.White
        Me.EnableAnswerAButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.EnableAnswerAButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.EnableAnswerAButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.EnableAnswerAButton.Location = New System.Drawing.Point(11, 395)
        Me.EnableAnswerAButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.EnableAnswerAButton.Name = "EnableAnswerAButton"
        Me.EnableAnswerAButton.Size = New System.Drawing.Size(31, 23)
        Me.EnableAnswerAButton.TabIndex = 114
        Me.EnableAnswerAButton.Text = "A"
        Me.EnableAnswerAButton.UseVisualStyleBackColor = False
        '
        'AskQuestionButton
        '
        Me.AskQuestionButton.BackColor = System.Drawing.Color.White
        Me.AskQuestionButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AskQuestionButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.AskQuestionButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AskQuestionButton.Location = New System.Drawing.Point(12, 337)
        Me.AskQuestionButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AskQuestionButton.Name = "AskQuestionButton"
        Me.AskQuestionButton.Size = New System.Drawing.Size(149, 23)
        Me.AskQuestionButton.TabIndex = 113
        Me.AskQuestionButton.Text = "Ask It"
        Me.AskQuestionButton.UseVisualStyleBackColor = False
        '
        'QuestionPreviewLabel
        '
        Me.QuestionPreviewLabel.AutoSize = True
        Me.QuestionPreviewLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.QuestionPreviewLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionPreviewLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QuestionPreviewLabel.Location = New System.Drawing.Point(11, 442)
        Me.QuestionPreviewLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.QuestionPreviewLabel.MaximumSize = New System.Drawing.Size(990, 40)
        Me.QuestionPreviewLabel.Name = "QuestionPreviewLabel"
        Me.QuestionPreviewLabel.Size = New System.Drawing.Size(94, 13)
        Me.QuestionPreviewLabel.TabIndex = 112
        Me.QuestionPreviewLabel.Text = "QUESTION TEXT"
        '
        'FullQuestionTextLabel
        '
        Me.FullQuestionTextLabel.AutoSize = True
        Me.FullQuestionTextLabel.ForeColor = System.Drawing.Color.White
        Me.FullQuestionTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FullQuestionTextLabel.Location = New System.Drawing.Point(11, 426)
        Me.FullQuestionTextLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.FullQuestionTextLabel.Name = "FullQuestionTextLabel"
        Me.FullQuestionTextLabel.Size = New System.Drawing.Size(43, 13)
        Me.FullQuestionTextLabel.TabIndex = 111
        Me.FullQuestionTextLabel.Text = "Full text"
        '
        'QuestionListBox
        '
        Me.QuestionListBox.Enabled = False
        Me.QuestionListBox.FormattingEnabled = True
        Me.QuestionListBox.Items.AddRange(New Object() {"Q1", "Q2", "Q3", "Q4", "Q5", "Q6", "Q7", "Q8", "Q9", "Q10", "Q11", "Q12", "Q13", "Q14", "Q15"})
        Me.QuestionListBox.Location = New System.Drawing.Point(12, 132)
        Me.QuestionListBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.QuestionListBox.Name = "QuestionListBox"
        Me.QuestionListBox.Size = New System.Drawing.Size(149, 199)
        Me.QuestionListBox.TabIndex = 110
        '
        'ConnectSettingsLabel
        '
        Me.ConnectSettingsLabel.AutoSize = True
        Me.ConnectSettingsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.ConnectSettingsLabel.ForeColor = System.Drawing.Color.White
        Me.ConnectSettingsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.ConnectSettingsLabel.Location = New System.Drawing.Point(7, 8)
        Me.ConnectSettingsLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.ConnectSettingsLabel.Name = "ConnectSettingsLabel"
        Me.ConnectSettingsLabel.Size = New System.Drawing.Size(149, 24)
        Me.ConnectSettingsLabel.TabIndex = 109
        Me.ConnectSettingsLabel.Text = "Connect settings"
        '
        'ServerPortTextBox
        '
        Me.ServerPortTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ServerPortTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ServerPortTextBox.Location = New System.Drawing.Point(109, 35)
        Me.ServerPortTextBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ServerPortTextBox.Name = "ServerPortTextBox"
        Me.ServerPortTextBox.Size = New System.Drawing.Size(52, 19)
        Me.ServerPortTextBox.TabIndex = 108
        '
        'ServerIpTextBox
        '
        Me.ServerIpTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.ServerIpTextBox.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.ServerIpTextBox.Location = New System.Drawing.Point(12, 35)
        Me.ServerIpTextBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ServerIpTextBox.Name = "ServerIpTextBox"
        Me.ServerIpTextBox.Size = New System.Drawing.Size(97, 19)
        Me.ServerIpTextBox.TabIndex = 107
        '
        'QuestionsLabel
        '
        Me.QuestionsLabel.AutoSize = True
        Me.QuestionsLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.QuestionsLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionsLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QuestionsLabel.Location = New System.Drawing.Point(8, 78)
        Me.QuestionsLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.QuestionsLabel.Name = "QuestionsLabel"
        Me.QuestionsLabel.Size = New System.Drawing.Size(95, 24)
        Me.QuestionsLabel.TabIndex = 106
        Me.QuestionsLabel.Text = "Questions"
        '
        'QuestionNumberNumericUpDown
        '
        Me.QuestionNumberNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.QuestionNumberNumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.QuestionNumberNumericUpDown.Location = New System.Drawing.Point(12, 106)
        Me.QuestionNumberNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.QuestionNumberNumericUpDown.Maximum = New Decimal(New Integer() {15, 0, 0, 0})
        Me.QuestionNumberNumericUpDown.Name = "QuestionNumberNumericUpDown"
        Me.QuestionNumberNumericUpDown.Size = New System.Drawing.Size(149, 19)
        Me.QuestionNumberNumericUpDown.TabIndex = 105
        '
        'PrizeRevealTimer
        '
        Me.PrizeRevealTimer.Interval = 2000
        '
        'MoneyWonRevealTimer
        '
        Me.MoneyWonRevealTimer.Interval = 2000
        '
        'LifelinesRefreshTimer
        '
        Me.LifelinesRefreshTimer.Interval = 500
        '
        'OpenQuestionBaseDialog
        '
        Me.OpenQuestionBaseDialog.FileName = "*.questions"
        Me.OpenQuestionBaseDialog.Filter = "Question base files (*.questions)|All files (*.*)"
        Me.OpenQuestionBaseDialog.InitialDirectory = "\Bases"
        Me.OpenQuestionBaseDialog.Title = "Open question base file"
        '
        'AudienceScreenYNumericUpDown
        '
        Me.AudienceScreenYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AudienceScreenYNumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.AudienceScreenYNumericUpDown.Location = New System.Drawing.Point(947, 166)
        Me.AudienceScreenYNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AudienceScreenYNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.AudienceScreenYNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.AudienceScreenYNumericUpDown.Name = "AudienceScreenYNumericUpDown"
        Me.AudienceScreenYNumericUpDown.Size = New System.Drawing.Size(50, 19)
        Me.AudienceScreenYNumericUpDown.TabIndex = 214
        '
        'AudienceScreenXNumericUpDown
        '
        Me.AudienceScreenXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AudienceScreenXNumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.AudienceScreenXNumericUpDown.Location = New System.Drawing.Point(897, 166)
        Me.AudienceScreenXNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AudienceScreenXNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.AudienceScreenXNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.AudienceScreenXNumericUpDown.Name = "AudienceScreenXNumericUpDown"
        Me.AudienceScreenXNumericUpDown.Size = New System.Drawing.Size(50, 19)
        Me.AudienceScreenXNumericUpDown.TabIndex = 213
        '
        'PlayerScreenYNumericUpDown
        '
        Me.PlayerScreenYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PlayerScreenYNumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.PlayerScreenYNumericUpDown.Location = New System.Drawing.Point(947, 137)
        Me.PlayerScreenYNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PlayerScreenYNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.PlayerScreenYNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.PlayerScreenYNumericUpDown.Name = "PlayerScreenYNumericUpDown"
        Me.PlayerScreenYNumericUpDown.Size = New System.Drawing.Size(50, 19)
        Me.PlayerScreenYNumericUpDown.TabIndex = 212
        '
        'PlayerScreenXNumericUpDown
        '
        Me.PlayerScreenXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PlayerScreenXNumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.PlayerScreenXNumericUpDown.Location = New System.Drawing.Point(897, 137)
        Me.PlayerScreenXNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PlayerScreenXNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.PlayerScreenXNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.PlayerScreenXNumericUpDown.Name = "PlayerScreenXNumericUpDown"
        Me.PlayerScreenXNumericUpDown.Size = New System.Drawing.Size(50, 19)
        Me.PlayerScreenXNumericUpDown.TabIndex = 211
        '
        'HostScreenYNumericUpDown
        '
        Me.HostScreenYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HostScreenYNumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.HostScreenYNumericUpDown.Location = New System.Drawing.Point(947, 109)
        Me.HostScreenYNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.HostScreenYNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.HostScreenYNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.HostScreenYNumericUpDown.Name = "HostScreenYNumericUpDown"
        Me.HostScreenYNumericUpDown.Size = New System.Drawing.Size(50, 19)
        Me.HostScreenYNumericUpDown.TabIndex = 210
        '
        'HostScreenXNumericUpDown
        '
        Me.HostScreenXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HostScreenXNumericUpDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.HostScreenXNumericUpDown.Location = New System.Drawing.Point(897, 109)
        Me.HostScreenXNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.HostScreenXNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.HostScreenXNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.HostScreenXNumericUpDown.Name = "HostScreenXNumericUpDown"
        Me.HostScreenXNumericUpDown.Size = New System.Drawing.Size(50, 19)
        Me.HostScreenXNumericUpDown.TabIndex = 209
        '
        'AboutButton
        '
        Me.AboutButton.BackColor = System.Drawing.Color.White
        Me.AboutButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.AboutButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.AboutButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AboutButton.Location = New System.Drawing.Point(927, 35)
        Me.AboutButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AboutButton.Name = "AboutButton"
        Me.AboutButton.Size = New System.Drawing.Size(70, 23)
        Me.AboutButton.TabIndex = 215
        Me.AboutButton.Text = "About..."
        Me.AboutButton.UseVisualStyleBackColor = False
        '
        'LifelinesPictureBox
        '
        Me.LifelinesPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LifelinesPictureBox.Image = Global.ControlProgram.My.Resources.Resources._000
        Me.LifelinesPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LifelinesPictureBox.Location = New System.Drawing.Point(462, 198)
        Me.LifelinesPictureBox.Name = "LifelinesPictureBox"
        Me.LifelinesPictureBox.Size = New System.Drawing.Size(96, 19)
        Me.LifelinesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LifelinesPictureBox.TabIndex = 199
        Me.LifelinesPictureBox.TabStop = False
        '
        'MoneyTreePictureBox
        '
        Me.MoneyTreePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MoneyTreePictureBox.Image = Global.ControlProgram.My.Resources.Resources.TREE_0
        Me.MoneyTreePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTreePictureBox.Location = New System.Drawing.Point(462, 198)
        Me.MoneyTreePictureBox.Name = "MoneyTreePictureBox"
        Me.MoneyTreePictureBox.Size = New System.Drawing.Size(96, 145)
        Me.MoneyTreePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MoneyTreePictureBox.TabIndex = 198
        Me.MoneyTreePictureBox.TabStop = False
        '
        'AnswerDFramePictureBox
        '
        Me.AnswerDFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerDFramePictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.D_BLACK
        Me.AnswerDFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerDFramePictureBox.Location = New System.Drawing.Point(504, 663)
        Me.AnswerDFramePictureBox.Name = "AnswerDFramePictureBox"
        Me.AnswerDFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerDFramePictureBox.TabIndex = 193
        Me.AnswerDFramePictureBox.TabStop = False
        '
        'AnswerCFramePictureBox
        '
        Me.AnswerCFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerCFramePictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.C_BLACK
        Me.AnswerCFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerCFramePictureBox.InitialImage = Global.ControlProgram.My.Resources.Resources.LEFT
        Me.AnswerCFramePictureBox.Location = New System.Drawing.Point(-8, 663)
        Me.AnswerCFramePictureBox.Name = "AnswerCFramePictureBox"
        Me.AnswerCFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerCFramePictureBox.TabIndex = 192
        Me.AnswerCFramePictureBox.TabStop = False
        '
        'AnswerBFramePictureBox
        '
        Me.AnswerBFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerBFramePictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.B_BLACK
        Me.AnswerBFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerBFramePictureBox.Location = New System.Drawing.Point(504, 598)
        Me.AnswerBFramePictureBox.Name = "AnswerBFramePictureBox"
        Me.AnswerBFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerBFramePictureBox.TabIndex = 191
        Me.AnswerBFramePictureBox.TabStop = False
        '
        'AnswerAFramePictureBox
        '
        Me.AnswerAFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerAFramePictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.A_BLACK
        Me.AnswerAFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerAFramePictureBox.Location = New System.Drawing.Point(-8, 598)
        Me.AnswerAFramePictureBox.Name = "AnswerAFramePictureBox"
        Me.AnswerAFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerAFramePictureBox.TabIndex = 190
        Me.AnswerAFramePictureBox.TabStop = False
        '
        'QuestionFramePictureBox
        '
        Me.QuestionFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.QuestionFramePictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.QUESTION
        Me.QuestionFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QuestionFramePictureBox.InitialImage = Nothing
        Me.QuestionFramePictureBox.Location = New System.Drawing.Point(-8, 487)
        Me.QuestionFramePictureBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.QuestionFramePictureBox.Name = "QuestionFramePictureBox"
        Me.QuestionFramePictureBox.Size = New System.Drawing.Size(1024, 102)
        Me.QuestionFramePictureBox.TabIndex = 120
        Me.QuestionFramePictureBox.TabStop = False
        '
        'HostLocationLabel
        '
        Me.HostLocationLabel.AutoSize = True
        Me.HostLocationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.HostLocationLabel.ForeColor = System.Drawing.Color.White
        Me.HostLocationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.HostLocationLabel.Location = New System.Drawing.Point(823, 111)
        Me.HostLocationLabel.Name = "HostLocationLabel"
        Me.HostLocationLabel.Size = New System.Drawing.Size(28, 13)
        Me.HostLocationLabel.TabIndex = 216
        Me.HostLocationLabel.Text = "Host"
        '
        'PlayerLocationLabel
        '
        Me.PlayerLocationLabel.AutoSize = True
        Me.PlayerLocationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.PlayerLocationLabel.ForeColor = System.Drawing.Color.White
        Me.PlayerLocationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PlayerLocationLabel.Location = New System.Drawing.Point(823, 140)
        Me.PlayerLocationLabel.Name = "PlayerLocationLabel"
        Me.PlayerLocationLabel.Size = New System.Drawing.Size(36, 13)
        Me.PlayerLocationLabel.TabIndex = 217
        Me.PlayerLocationLabel.Text = "Player"
        '
        'AudienceLocationLabel
        '
        Me.AudienceLocationLabel.AutoSize = True
        Me.AudienceLocationLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.AudienceLocationLabel.ForeColor = System.Drawing.Color.White
        Me.AudienceLocationLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AudienceLocationLabel.Location = New System.Drawing.Point(823, 169)
        Me.AudienceLocationLabel.Name = "AudienceLocationLabel"
        Me.AudienceLocationLabel.Size = New System.Drawing.Size(51, 13)
        Me.AudienceLocationLabel.TabIndex = 218
        Me.AudienceLocationLabel.Text = "Audience"
        '
        'FastestFingerFirstButton
        '
        Me.FastestFingerFirstButton.BackColor = System.Drawing.Color.White
        Me.FastestFingerFirstButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.FastestFingerFirstButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.FastestFingerFirstButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.FastestFingerFirstButton.Location = New System.Drawing.Point(590, 395)
        Me.FastestFingerFirstButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.FastestFingerFirstButton.Name = "FastestFingerFirstButton"
        Me.FastestFingerFirstButton.Size = New System.Drawing.Size(206, 23)
        Me.FastestFingerFirstButton.TabIndex = 219
        Me.FastestFingerFirstButton.Text = "Fastest Finger First"
        Me.FastestFingerFirstButton.UseVisualStyleBackColor = False
        '
        'MoneyTreeUpButton
        '
        Me.MoneyTreeUpButton.BackColor = System.Drawing.Color.White
        Me.MoneyTreeUpButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MoneyTreeUpButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.MoneyTreeUpButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTreeUpButton.Location = New System.Drawing.Point(460, 367)
        Me.MoneyTreeUpButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MoneyTreeUpButton.Name = "MoneyTreeUpButton"
        Me.MoneyTreeUpButton.Size = New System.Drawing.Size(52, 23)
        Me.MoneyTreeUpButton.TabIndex = 220
        Me.MoneyTreeUpButton.Text = "Tree U"
        Me.MoneyTreeUpButton.UseVisualStyleBackColor = False
        '
        'MoneyTreeDownButton
        '
        Me.MoneyTreeDownButton.BackColor = System.Drawing.Color.White
        Me.MoneyTreeDownButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MoneyTreeDownButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.MoneyTreeDownButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTreeDownButton.Location = New System.Drawing.Point(512, 367)
        Me.MoneyTreeDownButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MoneyTreeDownButton.Name = "MoneyTreeDownButton"
        Me.MoneyTreeDownButton.Size = New System.Drawing.Size(52, 23)
        Me.MoneyTreeDownButton.TabIndex = 221
        Me.MoneyTreeDownButton.Text = "Tree D"
        Me.MoneyTreeDownButton.UseVisualStyleBackColor = False
        '
        'MoneyTreeLevel15Button
        '
        Me.MoneyTreeLevel15Button.BackColor = System.Drawing.Color.White
        Me.MoneyTreeLevel15Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MoneyTreeLevel15Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MoneyTreeLevel15Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTreeLevel15Button.Location = New System.Drawing.Point(538, 396)
        Me.MoneyTreeLevel15Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MoneyTreeLevel15Button.Name = "MoneyTreeLevel15Button"
        Me.MoneyTreeLevel15Button.Size = New System.Drawing.Size(26, 23)
        Me.MoneyTreeLevel15Button.TabIndex = 224
        Me.MoneyTreeLevel15Button.Text = "15"
        Me.MoneyTreeLevel15Button.UseVisualStyleBackColor = False
        '
        'MoneyTreeLevel10Button
        '
        Me.MoneyTreeLevel10Button.BackColor = System.Drawing.Color.White
        Me.MoneyTreeLevel10Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MoneyTreeLevel10Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MoneyTreeLevel10Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTreeLevel10Button.Location = New System.Drawing.Point(512, 396)
        Me.MoneyTreeLevel10Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MoneyTreeLevel10Button.Name = "MoneyTreeLevel10Button"
        Me.MoneyTreeLevel10Button.Size = New System.Drawing.Size(26, 23)
        Me.MoneyTreeLevel10Button.TabIndex = 223
        Me.MoneyTreeLevel10Button.Text = "10"
        Me.MoneyTreeLevel10Button.UseVisualStyleBackColor = False
        '
        'MoneyTreeLevel5Button
        '
        Me.MoneyTreeLevel5Button.BackColor = System.Drawing.Color.White
        Me.MoneyTreeLevel5Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MoneyTreeLevel5Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MoneyTreeLevel5Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTreeLevel5Button.Location = New System.Drawing.Point(486, 396)
        Me.MoneyTreeLevel5Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MoneyTreeLevel5Button.Name = "MoneyTreeLevel5Button"
        Me.MoneyTreeLevel5Button.Size = New System.Drawing.Size(26, 23)
        Me.MoneyTreeLevel5Button.TabIndex = 222
        Me.MoneyTreeLevel5Button.Text = "5"
        Me.MoneyTreeLevel5Button.UseVisualStyleBackColor = False
        '
        'MoneyTreeLevel0Button
        '
        Me.MoneyTreeLevel0Button.BackColor = System.Drawing.Color.White
        Me.MoneyTreeLevel0Button.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.MoneyTreeLevel0Button.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.MoneyTreeLevel0Button.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTreeLevel0Button.Location = New System.Drawing.Point(460, 396)
        Me.MoneyTreeLevel0Button.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.MoneyTreeLevel0Button.Name = "MoneyTreeLevel0Button"
        Me.MoneyTreeLevel0Button.Size = New System.Drawing.Size(26, 23)
        Me.MoneyTreeLevel0Button.TabIndex = 225
        Me.MoneyTreeLevel0Button.Text = "0"
        Me.MoneyTreeLevel0Button.UseVisualStyleBackColor = False
        '
        'OpeningTitlesButton
        '
        Me.OpeningTitlesButton.BackColor = System.Drawing.Color.White
        Me.OpeningTitlesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OpeningTitlesButton.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.5!)
        Me.OpeningTitlesButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.OpeningTitlesButton.Location = New System.Drawing.Point(696, 77)
        Me.OpeningTitlesButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.OpeningTitlesButton.Name = "OpeningTitlesButton"
        Me.OpeningTitlesButton.Size = New System.Drawing.Size(100, 23)
        Me.OpeningTitlesButton.TabIndex = 226
        Me.OpeningTitlesButton.Text = "Opening Titles"
        Me.OpeningTitlesButton.UseVisualStyleBackColor = False
        '
        'LifelinesPanelSlideTimer
        '
        Me.LifelinesPanelSlideTimer.Interval = 4
        '
        'LifelinesPanelHoldTimer
        '
        Me.LifelinesPanelHoldTimer.Interval = 5000
        '
        'GameControlForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.OpeningTitlesButton)
        Me.Controls.Add(Me.MoneyTreeLevel0Button)
        Me.Controls.Add(Me.MoneyTreeLevel15Button)
        Me.Controls.Add(Me.MoneyTreeLevel10Button)
        Me.Controls.Add(Me.MoneyTreeLevel5Button)
        Me.Controls.Add(Me.MoneyTreeDownButton)
        Me.Controls.Add(Me.MoneyTreeUpButton)
        Me.Controls.Add(Me.FastestFingerFirstButton)
        Me.Controls.Add(Me.AudienceLocationLabel)
        Me.Controls.Add(Me.PlayerLocationLabel)
        Me.Controls.Add(Me.HostLocationLabel)
        Me.Controls.Add(Me.AboutButton)
        Me.Controls.Add(Me.AudienceScreenYNumericUpDown)
        Me.Controls.Add(Me.AudienceScreenXNumericUpDown)
        Me.Controls.Add(Me.PlayerScreenYNumericUpDown)
        Me.Controls.Add(Me.PlayerScreenXNumericUpDown)
        Me.Controls.Add(Me.HostScreenYNumericUpDown)
        Me.Controls.Add(Me.HostScreenXNumericUpDown)
        Me.Controls.Add(Me.MoneyTakenCheckBox)
        Me.Controls.Add(Me.BigQuitButton)
        Me.Controls.Add(Me.LittleQuitButton)
        Me.Controls.Add(Me.LifelinesPictureBox)
        Me.Controls.Add(Me.MoneyTreePictureBox)
        Me.Controls.Add(Me.OpenQuestionBaseButton)
        Me.Controls.Add(Me.QuestionFilePathLabel)
        Me.Controls.Add(Me.ContestantLabel)
        Me.Controls.Add(Me.AnswerDTextLabel)
        Me.Controls.Add(Me.AnswerCTextLabel)
        Me.Controls.Add(Me.AnswerBTextLabel)
        Me.Controls.Add(Me.AnswerATextLabel)
        Me.Controls.Add(Me.AnswerDFramePictureBox)
        Me.Controls.Add(Me.AnswerCFramePictureBox)
        Me.Controls.Add(Me.AnswerBFramePictureBox)
        Me.Controls.Add(Me.AnswerAFramePictureBox)
        Me.Controls.Add(Me.QuestionTextLabel)
        Me.Controls.Add(Me.AudienceVisibleCheckBox)
        Me.Controls.Add(Me.PlayerVisibleCheckBox)
        Me.Controls.Add(Me.HostVisibleCheckBox)
        Me.Controls.Add(Me.AudienceFrameCheckBox)
        Me.Controls.Add(Me.PlayerFrameCheckBox)
        Me.Controls.Add(Me.HostFrameCheckBox)
        Me.Controls.Add(Me.ContestantNameTextBox)
        Me.Controls.Add(Me.ClearHostMessageButton)
        Me.Controls.Add(Me.SendHostMessageButton)
        Me.Controls.Add(Me.HostMessageLabel)
        Me.Controls.Add(Me.HostMessageTextBox)
        Me.Controls.Add(Me.AvailabilityLabel)
        Me.Controls.Add(Me.FramesLabel)
        Me.Controls.Add(Me.LocationLabel)
        Me.Controls.Add(Me.MusicLabel)
        Me.Controls.Add(Me.MoneyLabel)
        Me.Controls.Add(Me.AskTheAudienceAvailableCheckBox)
        Me.Controls.Add(Me.PhoneAFriendAvailableCheckBox)
        Me.Controls.Add(Me.FiftyFiftyAvailableCheckBox)
        Me.Controls.Add(Me.LifelinesLabel)
        Me.Controls.Add(Me.AnswersLabel)
        Me.Controls.Add(Me.AnswerIndicatorLabel)
        Me.Controls.Add(Me.RevealCorrectAnswerButton)
        Me.Controls.Add(Me.StopMusicButton)
        Me.Controls.Add(Me.StopSoundButton)
        Me.Controls.Add(Me.SmsClockButton)
        Me.Controls.Add(Me.StereoTestButton)
        Me.Controls.Add(Me.ClosingTitlesButton)
        Me.Controls.Add(Me.TomorrowsNamesButton)
        Me.Controls.Add(Me.TimesUpButton)
        Me.Controls.Add(Me.GoodbyePunterButton)
        Me.Controls.Add(Me.HelloAgainButton)
        Me.Controls.Add(Me.SeeYouLaterButton)
        Me.Controls.Add(Me.StartTheGameButton)
        Me.Controls.Add(Me.LightsToCentreButton)
        Me.Controls.Add(Me.AskTheAudienceMusicButton)
        Me.Controls.Add(Me.PhoneAFriendMusicButton)
        Me.Controls.Add(Me.FiftyFiftyMusicButton)
        Me.Controls.Add(Me.LifelineExplanationsButton)
        Me.Controls.Add(Me.ClearFormsButton)
        Me.Controls.Add(Me.LetsPlayButton)
        Me.Controls.Add(Me.HostEntranceButton)
        Me.Controls.Add(Me.TakeTheMoneyButton)
        Me.Controls.Add(Me.ToggleLifelinesPanelButton)
        Me.Controls.Add(Me.AskTheAudienceButton)
        Me.Controls.Add(Me.FiftyFiftyButton)
        Me.Controls.Add(Me.ToggleLogoButton)
        Me.Controls.Add(Me.PhoneAFriendButton)
        Me.Controls.Add(Me.ToggleHintButton)
        Me.Controls.Add(Me.LightsDownButton)
        Me.Controls.Add(Me.ReceiveAnswerDButton)
        Me.Controls.Add(Me.ReceiveAnswerCButton)
        Me.Controls.Add(Me.ReceiveAnswerBButton)
        Me.Controls.Add(Me.ReceiveAnswerAButton)
        Me.Controls.Add(Me.ConnectButton)
        Me.Controls.Add(Me.QuestionFramePictureBox)
        Me.Controls.Add(Me.EnableAnswersLabel)
        Me.Controls.Add(Me.EnableAllAnswersButton)
        Me.Controls.Add(Me.EnableAnswerDButton)
        Me.Controls.Add(Me.EnableAnswerCButton)
        Me.Controls.Add(Me.EnableAnswerBButton)
        Me.Controls.Add(Me.EnableAnswerAButton)
        Me.Controls.Add(Me.AskQuestionButton)
        Me.Controls.Add(Me.QuestionPreviewLabel)
        Me.Controls.Add(Me.FullQuestionTextLabel)
        Me.Controls.Add(Me.QuestionListBox)
        Me.Controls.Add(Me.ConnectSettingsLabel)
        Me.Controls.Add(Me.ServerPortTextBox)
        Me.Controls.Add(Me.ServerIpTextBox)
        Me.Controls.Add(Me.QuestionsLabel)
        Me.Controls.Add(Me.QuestionNumberNumericUpDown)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.ControlProgram.My.Resources.Resources.ICON
        Me.MaximizeBox = False
        Me.Name = "GameControlForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Game control"
        CType(Me.QuestionNumberNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AudienceScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AudienceScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlayerScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlayerScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HostScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HostScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LifelinesPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MoneyTreePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerDFramePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerCFramePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerBFramePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerAFramePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.QuestionFramePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MoneyTakenCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents BigQuitButton As System.Windows.Forms.Button
    Friend WithEvents LittleQuitButton As System.Windows.Forms.Button
    Friend WithEvents LifelinesPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents MoneyTreePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents OpenQuestionBaseButton As System.Windows.Forms.Button
    Friend WithEvents QuestionFilePathLabel As System.Windows.Forms.Label
    Friend WithEvents ContestantLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerDTextLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCTextLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBTextLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerATextLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerDFramePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerCFramePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerBFramePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerAFramePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents QuestionTextLabel As System.Windows.Forms.Label
    Friend WithEvents AudienceVisibleCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PlayerVisibleCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents HostVisibleCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AudienceFrameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PlayerFrameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents HostFrameCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ContestantNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ClearHostMessageButton As System.Windows.Forms.Button
    Friend WithEvents SendHostMessageButton As System.Windows.Forms.Button
    Friend WithEvents HostMessageLabel As System.Windows.Forms.Label
    Friend WithEvents HostMessageTextBox As System.Windows.Forms.TextBox
    Friend WithEvents AvailabilityLabel As System.Windows.Forms.Label
    Friend WithEvents FramesLabel As System.Windows.Forms.Label
    Friend WithEvents LocationLabel As System.Windows.Forms.Label
    Friend WithEvents MusicLabel As System.Windows.Forms.Label
    Friend WithEvents MoneyLabel As System.Windows.Forms.Label
    Friend WithEvents AskTheAudienceAvailableCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PhoneAFriendAvailableCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents FiftyFiftyAvailableCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents LifelinesLabel As System.Windows.Forms.Label
    Friend WithEvents AnswersLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerIndicatorLabel As System.Windows.Forms.Label
    Friend WithEvents RevealCorrectAnswerButton As System.Windows.Forms.Button
    Friend WithEvents StopMusicButton As System.Windows.Forms.Button
    Friend WithEvents StopSoundButton As System.Windows.Forms.Button
    Friend WithEvents SmsClockButton As System.Windows.Forms.Button
    Friend WithEvents StereoTestButton As System.Windows.Forms.Button
    Friend WithEvents ClosingTitlesButton As System.Windows.Forms.Button
    Friend WithEvents TomorrowsNamesButton As System.Windows.Forms.Button
    Friend WithEvents TimesUpButton As System.Windows.Forms.Button
    Friend WithEvents GoodbyePunterButton As System.Windows.Forms.Button
    Friend WithEvents HelloAgainButton As System.Windows.Forms.Button
    Friend WithEvents SeeYouLaterButton As System.Windows.Forms.Button
    Friend WithEvents StartTheGameButton As System.Windows.Forms.Button
    Friend WithEvents LightsToCentreButton As System.Windows.Forms.Button
    Friend WithEvents AskTheAudienceMusicButton As System.Windows.Forms.Button
    Friend WithEvents PhoneAFriendMusicButton As System.Windows.Forms.Button
    Friend WithEvents FiftyFiftyMusicButton As System.Windows.Forms.Button
    Friend WithEvents LifelineExplanationsButton As System.Windows.Forms.Button
    Friend WithEvents ClearFormsButton As System.Windows.Forms.Button
    Friend WithEvents LetsPlayButton As System.Windows.Forms.Button
    Friend WithEvents HostEntranceButton As System.Windows.Forms.Button
    Friend WithEvents TakeTheMoneyButton As System.Windows.Forms.Button
    Friend WithEvents ToggleLifelinesPanelButton As System.Windows.Forms.Button
    Friend WithEvents AskTheAudienceButton As System.Windows.Forms.Button
    Friend WithEvents FiftyFiftyButton As System.Windows.Forms.Button
    Friend WithEvents ToggleLogoButton As System.Windows.Forms.Button
    Friend WithEvents PhoneAFriendButton As System.Windows.Forms.Button
    Friend WithEvents ToggleHintButton As System.Windows.Forms.Button
    Friend WithEvents LightsDownButton As System.Windows.Forms.Button
    Friend WithEvents ReceiveAnswerDButton As System.Windows.Forms.Button
    Friend WithEvents ReceiveAnswerCButton As System.Windows.Forms.Button
    Friend WithEvents ReceiveAnswerBButton As System.Windows.Forms.Button
    Friend WithEvents ReceiveAnswerAButton As System.Windows.Forms.Button
    Friend WithEvents ConnectButton As System.Windows.Forms.Button
    Friend WithEvents QuestionFramePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents EnableAnswersLabel As System.Windows.Forms.Label
    Friend WithEvents EnableAllAnswersButton As System.Windows.Forms.Button
    Friend WithEvents EnableAnswerDButton As System.Windows.Forms.Button
    Friend WithEvents EnableAnswerCButton As System.Windows.Forms.Button
    Friend WithEvents EnableAnswerBButton As System.Windows.Forms.Button
    Friend WithEvents EnableAnswerAButton As System.Windows.Forms.Button
    Friend WithEvents AskQuestionButton As System.Windows.Forms.Button
    Friend WithEvents QuestionPreviewLabel As System.Windows.Forms.Label
    Friend WithEvents FullQuestionTextLabel As System.Windows.Forms.Label
    Friend WithEvents QuestionListBox As System.Windows.Forms.ListBox
    Friend WithEvents ConnectSettingsLabel As System.Windows.Forms.Label
    Friend WithEvents ServerPortTextBox As System.Windows.Forms.TextBox
    Friend WithEvents ServerIpTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QuestionsLabel As System.Windows.Forms.Label
    Friend WithEvents QuestionNumberNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents PrizeRevealTimer As System.Windows.Forms.Timer
    Friend WithEvents MoneyWonRevealTimer As System.Windows.Forms.Timer
    Friend WithEvents LifelinesRefreshTimer As System.Windows.Forms.Timer
    Friend WithEvents OpenQuestionBaseDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents AudienceScreenYNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AudienceScreenXNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents PlayerScreenYNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents PlayerScreenXNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents HostScreenYNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents HostScreenXNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AboutButton As System.Windows.Forms.Button
    Friend WithEvents HostLocationLabel As System.Windows.Forms.Label
    Friend WithEvents PlayerLocationLabel As System.Windows.Forms.Label
    Friend WithEvents AudienceLocationLabel As System.Windows.Forms.Label
    Friend WithEvents FastestFingerFirstButton As System.Windows.Forms.Button
    Friend WithEvents MoneyTreeUpButton As System.Windows.Forms.Button
    Friend WithEvents MoneyTreeDownButton As System.Windows.Forms.Button
    Friend WithEvents MoneyTreeLevel15Button As System.Windows.Forms.Button
    Friend WithEvents MoneyTreeLevel10Button As System.Windows.Forms.Button
    Friend WithEvents MoneyTreeLevel5Button As System.Windows.Forms.Button
    Friend WithEvents MoneyTreeLevel0Button As System.Windows.Forms.Button
    Friend WithEvents OpeningTitlesButton As System.Windows.Forms.Button
    Friend WithEvents LifelinesPanelSlideTimer As System.Windows.Forms.Timer
    Friend WithEvents LifelinesPanelHoldTimer As System.Windows.Forms.Timer

End Class
