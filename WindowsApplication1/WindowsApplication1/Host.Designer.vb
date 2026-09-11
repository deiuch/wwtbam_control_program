<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Host
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Host))
        Me.HostMessageLabel = New System.Windows.Forms.Label()
        Me.QuestionCommentLabel = New System.Windows.Forms.Label()
        Me.AnswerDChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerCChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerBChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerAChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerDPercentLabel = New System.Windows.Forms.Label()
        Me.AnswerCPercentLabel = New System.Windows.Forms.Label()
        Me.AnswerBPercentLabel = New System.Windows.Forms.Label()
        Me.AnswerAPercentLabel = New System.Windows.Forms.Label()
        Me.ClockPictureBox = New System.Windows.Forms.PictureBox()
        Me.GuaranteedSumLabel = New System.Windows.Forms.Label()
        Me.FinalAnswerLetterLabel = New System.Windows.Forms.Label()
        Me.PossibleLossLabel = New System.Windows.Forms.Label()
        Me.CurrentWinLabel = New System.Windows.Forms.Label()
        Me.PossibleWinLabel = New System.Windows.Forms.Label()
        Me.QuestionsLeftLabel = New System.Windows.Forms.Label()
        Me.LifelinesPictureBox = New System.Windows.Forms.PictureBox()
        Me.MoneyTreePictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerDTextLabel = New System.Windows.Forms.Label()
        Me.AnswerCTextLabel = New System.Windows.Forms.Label()
        Me.AnswerBTextLabel = New System.Windows.Forms.Label()
        Me.AnswerATextLabel = New System.Windows.Forms.Label()
        Me.AnswerDFramePictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerCFramePictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerBFramePictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerAFramePictureBox = New System.Windows.Forms.PictureBox()
        Me.QuestionTextLabel = New System.Windows.Forms.Label()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.AnswerDChartPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerCChartPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerBChartPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerAChartPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ClockPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LifelinesPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MoneyTreePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerDFramePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerCFramePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerBFramePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerAFramePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'HostMessageLabel
        '
        Me.HostMessageLabel.AutoSize = True
        Me.HostMessageLabel.BackColor = System.Drawing.Color.Transparent
        Me.HostMessageLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.HostMessageLabel.ForeColor = System.Drawing.Color.White
        Me.HostMessageLabel.Location = New System.Drawing.Point(19, 601)
        Me.HostMessageLabel.MaximumSize = New System.Drawing.Size(600, 120)
        Me.HostMessageLabel.Name = "HostMessageLabel"
        Me.HostMessageLabel.Size = New System.Drawing.Size(107, 16)
        Me.HostMessageLabel.TabIndex = 153
        Me.HostMessageLabel.Text = "Message to host"
        '
        'QuestionCommentLabel
        '
        Me.QuestionCommentLabel.AutoSize = True
        Me.QuestionCommentLabel.BackColor = System.Drawing.Color.Transparent
        Me.QuestionCommentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.QuestionCommentLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionCommentLabel.Location = New System.Drawing.Point(19, 381)
        Me.QuestionCommentLabel.MaximumSize = New System.Drawing.Size(400, 210)
        Me.QuestionCommentLabel.Name = "QuestionCommentLabel"
        Me.QuestionCommentLabel.Size = New System.Drawing.Size(137, 16)
        Me.QuestionCommentLabel.TabIndex = 152
        Me.QuestionCommentLabel.Text = "Comment for question"
        '
        'AnswerDChartPictureBox
        '
        Me.AnswerDChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerDChartPictureBox.Image = CType(resources.GetObject("AnswerDChartPictureBox.Image"), System.Drawing.Image)
        Me.AnswerDChartPictureBox.Location = New System.Drawing.Point(583, 396)
        Me.AnswerDChartPictureBox.Name = "AnswerDChartPictureBox"
        Me.AnswerDChartPictureBox.Size = New System.Drawing.Size(17, 120)
        Me.AnswerDChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerDChartPictureBox.TabIndex = 151
        Me.AnswerDChartPictureBox.TabStop = False
        Me.AnswerDChartPictureBox.Visible = False
        '
        'AnswerCChartPictureBox
        '
        Me.AnswerCChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerCChartPictureBox.Image = CType(resources.GetObject("AnswerCChartPictureBox.Image"), System.Drawing.Image)
        Me.AnswerCChartPictureBox.Location = New System.Drawing.Point(558, 396)
        Me.AnswerCChartPictureBox.Name = "AnswerCChartPictureBox"
        Me.AnswerCChartPictureBox.Size = New System.Drawing.Size(17, 120)
        Me.AnswerCChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerCChartPictureBox.TabIndex = 150
        Me.AnswerCChartPictureBox.TabStop = False
        Me.AnswerCChartPictureBox.Visible = False
        '
        'AnswerBChartPictureBox
        '
        Me.AnswerBChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerBChartPictureBox.Image = CType(resources.GetObject("AnswerBChartPictureBox.Image"), System.Drawing.Image)
        Me.AnswerBChartPictureBox.Location = New System.Drawing.Point(533, 396)
        Me.AnswerBChartPictureBox.Name = "AnswerBChartPictureBox"
        Me.AnswerBChartPictureBox.Size = New System.Drawing.Size(17, 120)
        Me.AnswerBChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerBChartPictureBox.TabIndex = 149
        Me.AnswerBChartPictureBox.TabStop = False
        Me.AnswerBChartPictureBox.Visible = False
        '
        'AnswerAChartPictureBox
        '
        Me.AnswerAChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerAChartPictureBox.Image = CType(resources.GetObject("AnswerAChartPictureBox.Image"), System.Drawing.Image)
        Me.AnswerAChartPictureBox.Location = New System.Drawing.Point(508, 396)
        Me.AnswerAChartPictureBox.Name = "AnswerAChartPictureBox"
        Me.AnswerAChartPictureBox.Size = New System.Drawing.Size(17, 120)
        Me.AnswerAChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerAChartPictureBox.TabIndex = 148
        Me.AnswerAChartPictureBox.TabStop = False
        Me.AnswerAChartPictureBox.Visible = False
        '
        'AnswerDPercentLabel
        '
        Me.AnswerDPercentLabel.AutoSize = True
        Me.AnswerDPercentLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerDPercentLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerDPercentLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDPercentLabel.Location = New System.Drawing.Point(580, 381)
        Me.AnswerDPercentLabel.MinimumSize = New System.Drawing.Size(25, 0)
        Me.AnswerDPercentLabel.Name = "AnswerDPercentLabel"
        Me.AnswerDPercentLabel.Size = New System.Drawing.Size(25, 12)
        Me.AnswerDPercentLabel.TabIndex = 147
        Me.AnswerDPercentLabel.Text = "0%"
        Me.AnswerDPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerDPercentLabel.Visible = False
        '
        'AnswerCPercentLabel
        '
        Me.AnswerCPercentLabel.AutoSize = True
        Me.AnswerCPercentLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerCPercentLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerCPercentLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerCPercentLabel.Location = New System.Drawing.Point(554, 381)
        Me.AnswerCPercentLabel.MinimumSize = New System.Drawing.Size(25, 0)
        Me.AnswerCPercentLabel.Name = "AnswerCPercentLabel"
        Me.AnswerCPercentLabel.Size = New System.Drawing.Size(25, 12)
        Me.AnswerCPercentLabel.TabIndex = 146
        Me.AnswerCPercentLabel.Text = "0%"
        Me.AnswerCPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerCPercentLabel.Visible = False
        '
        'AnswerBPercentLabel
        '
        Me.AnswerBPercentLabel.AutoSize = True
        Me.AnswerBPercentLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerBPercentLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerBPercentLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerBPercentLabel.Location = New System.Drawing.Point(530, 381)
        Me.AnswerBPercentLabel.MinimumSize = New System.Drawing.Size(25, 0)
        Me.AnswerBPercentLabel.Name = "AnswerBPercentLabel"
        Me.AnswerBPercentLabel.Size = New System.Drawing.Size(25, 12)
        Me.AnswerBPercentLabel.TabIndex = 145
        Me.AnswerBPercentLabel.Text = "0%"
        Me.AnswerBPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerBPercentLabel.Visible = False
        '
        'AnswerAPercentLabel
        '
        Me.AnswerAPercentLabel.AutoSize = True
        Me.AnswerAPercentLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerAPercentLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerAPercentLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerAPercentLabel.Location = New System.Drawing.Point(504, 381)
        Me.AnswerAPercentLabel.MinimumSize = New System.Drawing.Size(25, 0)
        Me.AnswerAPercentLabel.Name = "AnswerAPercentLabel"
        Me.AnswerAPercentLabel.Size = New System.Drawing.Size(25, 12)
        Me.AnswerAPercentLabel.TabIndex = 144
        Me.AnswerAPercentLabel.Text = "0%"
        Me.AnswerAPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerAPercentLabel.Visible = False
        '
        'ClockPictureBox
        '
        Me.ClockPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ClockPictureBox.Location = New System.Drawing.Point(455, 380)
        Me.ClockPictureBox.Name = "ClockPictureBox"
        Me.ClockPictureBox.Size = New System.Drawing.Size(157, 157)
        Me.ClockPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ClockPictureBox.TabIndex = 143
        Me.ClockPictureBox.TabStop = False
        '
        'GuaranteedSumLabel
        '
        Me.GuaranteedSumLabel.AutoSize = True
        Me.GuaranteedSumLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.GuaranteedSumLabel.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.GuaranteedSumLabel.ForeColor = System.Drawing.Color.White
        Me.GuaranteedSumLabel.Location = New System.Drawing.Point(408, 308)
        Me.GuaranteedSumLabel.MaximumSize = New System.Drawing.Size(204, 51)
        Me.GuaranteedSumLabel.MinimumSize = New System.Drawing.Size(204, 51)
        Me.GuaranteedSumLabel.Name = "GuaranteedSumLabel"
        Me.GuaranteedSumLabel.Size = New System.Drawing.Size(204, 51)
        Me.GuaranteedSumLabel.TabIndex = 142
        Me.GuaranteedSumLabel.Text = "EarnGrnt"
        Me.GuaranteedSumLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'FinalAnswerLetterLabel
        '
        Me.FinalAnswerLetterLabel.AutoSize = True
        Me.FinalAnswerLetterLabel.BackColor = System.Drawing.Color.Gray
        Me.FinalAnswerLetterLabel.Font = New System.Drawing.Font("Arial", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.FinalAnswerLetterLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer), CType(CType(100, Byte), Integer))
        Me.FinalAnswerLetterLabel.Location = New System.Drawing.Point(492, 264)
        Me.FinalAnswerLetterLabel.MaximumSize = New System.Drawing.Size(36, 36)
        Me.FinalAnswerLetterLabel.MinimumSize = New System.Drawing.Size(36, 36)
        Me.FinalAnswerLetterLabel.Name = "FinalAnswerLetterLabel"
        Me.FinalAnswerLetterLabel.Size = New System.Drawing.Size(36, 36)
        Me.FinalAnswerLetterLabel.TabIndex = 141
        Me.FinalAnswerLetterLabel.Text = "R"
        Me.FinalAnswerLetterLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PossibleLossLabel
        '
        Me.PossibleLossLabel.AutoSize = True
        Me.PossibleLossLabel.BackColor = System.Drawing.Color.Red
        Me.PossibleLossLabel.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PossibleLossLabel.ForeColor = System.Drawing.Color.White
        Me.PossibleLossLabel.Location = New System.Drawing.Point(204, 308)
        Me.PossibleLossLabel.MaximumSize = New System.Drawing.Size(204, 51)
        Me.PossibleLossLabel.MinimumSize = New System.Drawing.Size(204, 51)
        Me.PossibleLossLabel.Name = "PossibleLossLabel"
        Me.PossibleLossLabel.Size = New System.Drawing.Size(204, 51)
        Me.PossibleLossLabel.TabIndex = 140
        Me.PossibleLossLabel.Text = "PosLose"
        Me.PossibleLossLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'CurrentWinLabel
        '
        Me.CurrentWinLabel.AutoSize = True
        Me.CurrentWinLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(202, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.CurrentWinLabel.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.CurrentWinLabel.ForeColor = System.Drawing.Color.White
        Me.CurrentWinLabel.Location = New System.Drawing.Point(204, 257)
        Me.CurrentWinLabel.MaximumSize = New System.Drawing.Size(204, 51)
        Me.CurrentWinLabel.MinimumSize = New System.Drawing.Size(204, 51)
        Me.CurrentWinLabel.Name = "CurrentWinLabel"
        Me.CurrentWinLabel.Size = New System.Drawing.Size(204, 51)
        Me.CurrentWinLabel.TabIndex = 139
        Me.CurrentWinLabel.Text = "Prise"
        Me.CurrentWinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PossibleWinLabel
        '
        Me.PossibleWinLabel.AutoSize = True
        Me.PossibleWinLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.PossibleWinLabel.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.PossibleWinLabel.ForeColor = System.Drawing.Color.White
        Me.PossibleWinLabel.Location = New System.Drawing.Point(0, 308)
        Me.PossibleWinLabel.MaximumSize = New System.Drawing.Size(204, 51)
        Me.PossibleWinLabel.MinimumSize = New System.Drawing.Size(204, 51)
        Me.PossibleWinLabel.Name = "PossibleWinLabel"
        Me.PossibleWinLabel.Size = New System.Drawing.Size(204, 51)
        Me.PossibleWinLabel.TabIndex = 138
        Me.PossibleWinLabel.Text = "PosWin"
        Me.PossibleWinLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'QuestionsLeftLabel
        '
        Me.QuestionsLeftLabel.AutoSize = True
        Me.QuestionsLeftLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.QuestionsLeftLabel.Font = New System.Drawing.Font("Arial", 27.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.QuestionsLeftLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionsLeftLabel.Location = New System.Drawing.Point(0, 257)
        Me.QuestionsLeftLabel.MaximumSize = New System.Drawing.Size(204, 51)
        Me.QuestionsLeftLabel.MinimumSize = New System.Drawing.Size(204, 51)
        Me.QuestionsLeftLabel.Name = "QuestionsLeftLabel"
        Me.QuestionsLeftLabel.Size = New System.Drawing.Size(204, 51)
        Me.QuestionsLeftLabel.TabIndex = 137
        Me.QuestionsLeftLabel.Text = "Qaway: 0"
        Me.QuestionsLeftLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LifelinesPictureBox
        '
        Me.LifelinesPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LifelinesPictureBox.Image = CType(resources.GetObject("LifelinesPictureBox.Image"), System.Drawing.Image)
        Me.LifelinesPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LifelinesPictureBox.Location = New System.Drawing.Point(675, 270)
        Me.LifelinesPictureBox.Name = "LifelinesPictureBox"
        Me.LifelinesPictureBox.Size = New System.Drawing.Size(300, 59)
        Me.LifelinesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LifelinesPictureBox.TabIndex = 136
        Me.LifelinesPictureBox.TabStop = False
        '
        'MoneyTreePictureBox
        '
        Me.MoneyTreePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MoneyTreePictureBox.Image = CType(resources.GetObject("MoneyTreePictureBox.Image"), System.Drawing.Image)
        Me.MoneyTreePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTreePictureBox.Location = New System.Drawing.Point(675, 270)
        Me.MoneyTreePictureBox.Name = "MoneyTreePictureBox"
        Me.MoneyTreePictureBox.Size = New System.Drawing.Size(300, 443)
        Me.MoneyTreePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MoneyTreePictureBox.TabIndex = 135
        Me.MoneyTreePictureBox.TabStop = False
        '
        'AnswerDTextLabel
        '
        Me.AnswerDTextLabel.AutoSize = True
        Me.AnswerDTextLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.AnswerDTextLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerDTextLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerDTextLabel.Location = New System.Drawing.Point(591, 196)
        Me.AnswerDTextLabel.MaximumSize = New System.Drawing.Size(335, 39)
        Me.AnswerDTextLabel.MinimumSize = New System.Drawing.Size(0, 39)
        Me.AnswerDTextLabel.Name = "AnswerDTextLabel"
        Me.AnswerDTextLabel.Size = New System.Drawing.Size(147, 39)
        Me.AnswerDTextLabel.TabIndex = 130
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
        Me.AnswerCTextLabel.Location = New System.Drawing.Point(132, 197)
        Me.AnswerCTextLabel.MaximumSize = New System.Drawing.Size(335, 39)
        Me.AnswerCTextLabel.MinimumSize = New System.Drawing.Size(0, 39)
        Me.AnswerCTextLabel.Name = "AnswerCTextLabel"
        Me.AnswerCTextLabel.Size = New System.Drawing.Size(145, 39)
        Me.AnswerCTextLabel.TabIndex = 129
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
        Me.AnswerBTextLabel.Location = New System.Drawing.Point(591, 131)
        Me.AnswerBTextLabel.MaximumSize = New System.Drawing.Size(335, 39)
        Me.AnswerBTextLabel.MinimumSize = New System.Drawing.Size(0, 39)
        Me.AnswerBTextLabel.Name = "AnswerBTextLabel"
        Me.AnswerBTextLabel.Size = New System.Drawing.Size(147, 39)
        Me.AnswerBTextLabel.TabIndex = 128
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
        Me.AnswerATextLabel.Location = New System.Drawing.Point(133, 131)
        Me.AnswerATextLabel.MaximumSize = New System.Drawing.Size(335, 39)
        Me.AnswerATextLabel.MinimumSize = New System.Drawing.Size(0, 39)
        Me.AnswerATextLabel.Name = "AnswerATextLabel"
        Me.AnswerATextLabel.Size = New System.Drawing.Size(144, 39)
        Me.AnswerATextLabel.TabIndex = 127
        Me.AnswerATextLabel.Text = "Answer A"
        Me.AnswerATextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AnswerDFramePictureBox
        '
        Me.AnswerDFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerDFramePictureBox.BackgroundImage = CType(resources.GetObject("AnswerDFramePictureBox.BackgroundImage"), System.Drawing.Image)
        Me.AnswerDFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerDFramePictureBox.Location = New System.Drawing.Point(512, 187)
        Me.AnswerDFramePictureBox.Name = "AnswerDFramePictureBox"
        Me.AnswerDFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerDFramePictureBox.TabIndex = 134
        Me.AnswerDFramePictureBox.TabStop = False
        '
        'AnswerCFramePictureBox
        '
        Me.AnswerCFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerCFramePictureBox.BackgroundImage = CType(resources.GetObject("AnswerCFramePictureBox.BackgroundImage"), System.Drawing.Image)
        Me.AnswerCFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerCFramePictureBox.InitialImage = CType(resources.GetObject("AnswerCFramePictureBox.InitialImage"), System.Drawing.Image)
        Me.AnswerCFramePictureBox.Location = New System.Drawing.Point(0, 187)
        Me.AnswerCFramePictureBox.Name = "AnswerCFramePictureBox"
        Me.AnswerCFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerCFramePictureBox.TabIndex = 133
        Me.AnswerCFramePictureBox.TabStop = False
        '
        'AnswerBFramePictureBox
        '
        Me.AnswerBFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerBFramePictureBox.BackgroundImage = CType(resources.GetObject("AnswerBFramePictureBox.BackgroundImage"), System.Drawing.Image)
        Me.AnswerBFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerBFramePictureBox.Location = New System.Drawing.Point(512, 122)
        Me.AnswerBFramePictureBox.Name = "AnswerBFramePictureBox"
        Me.AnswerBFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerBFramePictureBox.TabIndex = 132
        Me.AnswerBFramePictureBox.TabStop = False
        '
        'AnswerAFramePictureBox
        '
        Me.AnswerAFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerAFramePictureBox.BackgroundImage = CType(resources.GetObject("AnswerAFramePictureBox.BackgroundImage"), System.Drawing.Image)
        Me.AnswerAFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerAFramePictureBox.Location = New System.Drawing.Point(0, 122)
        Me.AnswerAFramePictureBox.Name = "AnswerAFramePictureBox"
        Me.AnswerAFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerAFramePictureBox.TabIndex = 131
        Me.AnswerAFramePictureBox.TabStop = False
        '
        'QuestionTextLabel
        '
        Me.QuestionTextLabel.AutoSize = True
        Me.QuestionTextLabel.BackColor = System.Drawing.Color.Transparent
        Me.QuestionTextLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 26.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.QuestionTextLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionTextLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QuestionTextLabel.Location = New System.Drawing.Point(128, 14)
        Me.QuestionTextLabel.MaximumSize = New System.Drawing.Size(766, 90)
        Me.QuestionTextLabel.MinimumSize = New System.Drawing.Size(766, 90)
        Me.QuestionTextLabel.Name = "QuestionTextLabel"
        Me.QuestionTextLabel.Size = New System.Drawing.Size(766, 90)
        Me.QuestionTextLabel.TabIndex = 126
        Me.QuestionTextLabel.Text = "Question Text"
        Me.QuestionTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoPictureBox.BackgroundImage = CType(resources.GetObject("LogoPictureBox.BackgroundImage"), System.Drawing.Image)
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(50, 50)
        Me.LogoPictureBox.TabIndex = 154
        Me.LogoPictureBox.TabStop = False
        Me.LogoPictureBox.Visible = False
        '
        'Host
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.HostMessageLabel)
        Me.Controls.Add(Me.QuestionCommentLabel)
        Me.Controls.Add(Me.AnswerDChartPictureBox)
        Me.Controls.Add(Me.AnswerCChartPictureBox)
        Me.Controls.Add(Me.AnswerBChartPictureBox)
        Me.Controls.Add(Me.AnswerAChartPictureBox)
        Me.Controls.Add(Me.AnswerDPercentLabel)
        Me.Controls.Add(Me.AnswerCPercentLabel)
        Me.Controls.Add(Me.AnswerBPercentLabel)
        Me.Controls.Add(Me.AnswerAPercentLabel)
        Me.Controls.Add(Me.ClockPictureBox)
        Me.Controls.Add(Me.GuaranteedSumLabel)
        Me.Controls.Add(Me.FinalAnswerLetterLabel)
        Me.Controls.Add(Me.PossibleLossLabel)
        Me.Controls.Add(Me.CurrentWinLabel)
        Me.Controls.Add(Me.PossibleWinLabel)
        Me.Controls.Add(Me.QuestionsLeftLabel)
        Me.Controls.Add(Me.LifelinesPictureBox)
        Me.Controls.Add(Me.MoneyTreePictureBox)
        Me.Controls.Add(Me.AnswerDTextLabel)
        Me.Controls.Add(Me.AnswerCTextLabel)
        Me.Controls.Add(Me.AnswerBTextLabel)
        Me.Controls.Add(Me.AnswerATextLabel)
        Me.Controls.Add(Me.AnswerDFramePictureBox)
        Me.Controls.Add(Me.AnswerCFramePictureBox)
        Me.Controls.Add(Me.AnswerBFramePictureBox)
        Me.Controls.Add(Me.AnswerAFramePictureBox)
        Me.Controls.Add(Me.QuestionTextLabel)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(1024, 0)
        Me.MaximizeBox = False
        Me.Name = "Host"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Host"
        CType(Me.AnswerDChartPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerCChartPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerBChartPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerAChartPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ClockPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LifelinesPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MoneyTreePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerDFramePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerCFramePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerBFramePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerAFramePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents HostMessageLabel As System.Windows.Forms.Label
    Friend WithEvents QuestionCommentLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerDChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerCChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerBChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerAChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerDPercentLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCPercentLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBPercentLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerAPercentLabel As System.Windows.Forms.Label
    Friend WithEvents ClockPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents GuaranteedSumLabel As System.Windows.Forms.Label
    Friend WithEvents FinalAnswerLetterLabel As System.Windows.Forms.Label
    Friend WithEvents PossibleLossLabel As System.Windows.Forms.Label
    Friend WithEvents CurrentWinLabel As System.Windows.Forms.Label
    Friend WithEvents PossibleWinLabel As System.Windows.Forms.Label
    Friend WithEvents QuestionsLeftLabel As System.Windows.Forms.Label
    Friend WithEvents LifelinesPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents MoneyTreePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerDTextLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCTextLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBTextLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerATextLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerDFramePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerCFramePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerBFramePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerAFramePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents QuestionTextLabel As System.Windows.Forms.Label
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
End Class
