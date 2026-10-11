<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayerScreenForm
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
        Me.MoneyWonPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerDChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerCChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerBChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerAChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerDPercentLabel = New System.Windows.Forms.Label()
        Me.AnswerCPercentLabel = New System.Windows.Forms.Label()
        Me.AnswerBPercentLabel = New System.Windows.Forms.Label()
        Me.AnswerAPercentLabel = New System.Windows.Forms.Label()
        Me.ClockPictureBox = New System.Windows.Forms.PictureBox()
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
        Me.PrizePictureBox = New System.Windows.Forms.PictureBox()
        Me.LogoPictureBox = New System.Windows.Forms.PictureBox()
        Me.WinnerNameLabel = New System.Windows.Forms.Label()
        CType(Me.MoneyWonPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
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
        CType(Me.PrizePictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MoneyWonPictureBox
        '
        Me.MoneyWonPictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.MoneyWonPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.MoneyWonPictureBox.Location = New System.Drawing.Point(0, 107)
        Me.MoneyWonPictureBox.Name = "MoneyWonPictureBox"
        Me.MoneyWonPictureBox.Size = New System.Drawing.Size(1024, 90)
        Me.MoneyWonPictureBox.TabIndex = 150
        Me.MoneyWonPictureBox.TabStop = False
        Me.MoneyWonPictureBox.Visible = False
        '
        'AnswerDChartPictureBox
        '
        Me.AnswerDChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerDChartPictureBox.Image = Global.ControlProgram.My.Resources.Resources.GRAPH_COLUMN
        Me.AnswerDChartPictureBox.Location = New System.Drawing.Point(550, 298)
        Me.AnswerDChartPictureBox.Name = "AnswerDChartPictureBox"
        Me.AnswerDChartPictureBox.Size = New System.Drawing.Size(37, 240)
        Me.AnswerDChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerDChartPictureBox.TabIndex = 148
        Me.AnswerDChartPictureBox.TabStop = False
        Me.AnswerDChartPictureBox.Visible = False
        '
        'AnswerCChartPictureBox
        '
        Me.AnswerCChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerCChartPictureBox.Image = Global.ControlProgram.My.Resources.Resources.GRAPH_COLUMN
        Me.AnswerCChartPictureBox.Location = New System.Drawing.Point(501, 298)
        Me.AnswerCChartPictureBox.Name = "AnswerCChartPictureBox"
        Me.AnswerCChartPictureBox.Size = New System.Drawing.Size(37, 240)
        Me.AnswerCChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerCChartPictureBox.TabIndex = 147
        Me.AnswerCChartPictureBox.TabStop = False
        Me.AnswerCChartPictureBox.Visible = False
        '
        'AnswerBChartPictureBox
        '
        Me.AnswerBChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerBChartPictureBox.Image = Global.ControlProgram.My.Resources.Resources.GRAPH_COLUMN
        Me.AnswerBChartPictureBox.Location = New System.Drawing.Point(452, 298)
        Me.AnswerBChartPictureBox.Name = "AnswerBChartPictureBox"
        Me.AnswerBChartPictureBox.Size = New System.Drawing.Size(37, 240)
        Me.AnswerBChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerBChartPictureBox.TabIndex = 146
        Me.AnswerBChartPictureBox.TabStop = False
        Me.AnswerBChartPictureBox.Visible = False
        '
        'AnswerAChartPictureBox
        '
        Me.AnswerAChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerAChartPictureBox.Image = Global.ControlProgram.My.Resources.Resources.GRAPH_COLUMN
        Me.AnswerAChartPictureBox.Location = New System.Drawing.Point(403, 298)
        Me.AnswerAChartPictureBox.Name = "AnswerAChartPictureBox"
        Me.AnswerAChartPictureBox.Size = New System.Drawing.Size(37, 240)
        Me.AnswerAChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerAChartPictureBox.TabIndex = 145
        Me.AnswerAChartPictureBox.TabStop = False
        Me.AnswerAChartPictureBox.Visible = False
        '
        'AnswerDPercentLabel
        '
        Me.AnswerDPercentLabel.AutoSize = True
        Me.AnswerDPercentLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerDPercentLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerDPercentLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDPercentLabel.Location = New System.Drawing.Point(546, 273)
        Me.AnswerDPercentLabel.MinimumSize = New System.Drawing.Size(50, 0)
        Me.AnswerDPercentLabel.Name = "AnswerDPercentLabel"
        Me.AnswerDPercentLabel.Size = New System.Drawing.Size(50, 21)
        Me.AnswerDPercentLabel.TabIndex = 144
        Me.AnswerDPercentLabel.Text = "0%"
        Me.AnswerDPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerDPercentLabel.Visible = False
        '
        'AnswerCPercentLabel
        '
        Me.AnswerCPercentLabel.AutoSize = True
        Me.AnswerCPercentLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerCPercentLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerCPercentLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerCPercentLabel.Location = New System.Drawing.Point(496, 273)
        Me.AnswerCPercentLabel.MinimumSize = New System.Drawing.Size(50, 0)
        Me.AnswerCPercentLabel.Name = "AnswerCPercentLabel"
        Me.AnswerCPercentLabel.Size = New System.Drawing.Size(50, 21)
        Me.AnswerCPercentLabel.TabIndex = 143
        Me.AnswerCPercentLabel.Text = "0%"
        Me.AnswerCPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerCPercentLabel.Visible = False
        '
        'AnswerBPercentLabel
        '
        Me.AnswerBPercentLabel.AutoSize = True
        Me.AnswerBPercentLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerBPercentLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerBPercentLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerBPercentLabel.Location = New System.Drawing.Point(446, 273)
        Me.AnswerBPercentLabel.MinimumSize = New System.Drawing.Size(50, 0)
        Me.AnswerBPercentLabel.Name = "AnswerBPercentLabel"
        Me.AnswerBPercentLabel.Size = New System.Drawing.Size(50, 21)
        Me.AnswerBPercentLabel.TabIndex = 142
        Me.AnswerBPercentLabel.Text = "0%"
        Me.AnswerBPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerBPercentLabel.Visible = False
        '
        'AnswerAPercentLabel
        '
        Me.AnswerAPercentLabel.AutoSize = True
        Me.AnswerAPercentLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerAPercentLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerAPercentLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerAPercentLabel.Location = New System.Drawing.Point(398, 273)
        Me.AnswerAPercentLabel.MinimumSize = New System.Drawing.Size(50, 0)
        Me.AnswerAPercentLabel.Name = "AnswerAPercentLabel"
        Me.AnswerAPercentLabel.Size = New System.Drawing.Size(50, 21)
        Me.AnswerAPercentLabel.TabIndex = 141
        Me.AnswerAPercentLabel.Text = "0%"
        Me.AnswerAPercentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerAPercentLabel.Visible = False
        '
        'ClockPictureBox
        '
        Me.ClockPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.ClockPictureBox.Location = New System.Drawing.Point(455, 270)
        Me.ClockPictureBox.Name = "ClockPictureBox"
        Me.ClockPictureBox.Size = New System.Drawing.Size(157, 157)
        Me.ClockPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.ClockPictureBox.TabIndex = 140
        Me.ClockPictureBox.TabStop = False
        '
        'LifelinesPictureBox
        '
        Me.LifelinesPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.LifelinesPictureBox.Image = Global.ControlProgram.My.Resources.Resources._000
        Me.LifelinesPictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LifelinesPictureBox.Location = New System.Drawing.Point(675, 270)
        Me.LifelinesPictureBox.Name = "LifelinesPictureBox"
        Me.LifelinesPictureBox.Size = New System.Drawing.Size(300, 59)
        Me.LifelinesPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.LifelinesPictureBox.TabIndex = 139
        Me.LifelinesPictureBox.TabStop = False
        '
        'MoneyTreePictureBox
        '
        Me.MoneyTreePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.MoneyTreePictureBox.Image = Global.ControlProgram.My.Resources.Resources.TREE_0
        Me.MoneyTreePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.MoneyTreePictureBox.Location = New System.Drawing.Point(675, 270)
        Me.MoneyTreePictureBox.Name = "MoneyTreePictureBox"
        Me.MoneyTreePictureBox.Size = New System.Drawing.Size(300, 443)
        Me.MoneyTreePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.MoneyTreePictureBox.TabIndex = 138
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
        Me.AnswerDTextLabel.TabIndex = 133
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
        Me.AnswerCTextLabel.TabIndex = 132
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
        Me.AnswerBTextLabel.TabIndex = 131
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
        Me.AnswerATextLabel.TabIndex = 130
        Me.AnswerATextLabel.Text = "Answer A"
        Me.AnswerATextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'AnswerDFramePictureBox
        '
        Me.AnswerDFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerDFramePictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.D_BLACK
        Me.AnswerDFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerDFramePictureBox.Location = New System.Drawing.Point(512, 187)
        Me.AnswerDFramePictureBox.Name = "AnswerDFramePictureBox"
        Me.AnswerDFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerDFramePictureBox.TabIndex = 137
        Me.AnswerDFramePictureBox.TabStop = False
        '
        'AnswerCFramePictureBox
        '
        Me.AnswerCFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerCFramePictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.C_BLACK
        Me.AnswerCFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerCFramePictureBox.InitialImage = Global.ControlProgram.My.Resources.Resources.LEFT
        Me.AnswerCFramePictureBox.Location = New System.Drawing.Point(0, 187)
        Me.AnswerCFramePictureBox.Name = "AnswerCFramePictureBox"
        Me.AnswerCFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerCFramePictureBox.TabIndex = 136
        Me.AnswerCFramePictureBox.TabStop = False
        '
        'AnswerBFramePictureBox
        '
        Me.AnswerBFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerBFramePictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.B_BLACK
        Me.AnswerBFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerBFramePictureBox.Location = New System.Drawing.Point(512, 122)
        Me.AnswerBFramePictureBox.Name = "AnswerBFramePictureBox"
        Me.AnswerBFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerBFramePictureBox.TabIndex = 135
        Me.AnswerBFramePictureBox.TabStop = False
        '
        'AnswerAFramePictureBox
        '
        Me.AnswerAFramePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.AnswerAFramePictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.A_BLACK
        Me.AnswerAFramePictureBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AnswerAFramePictureBox.Location = New System.Drawing.Point(0, 122)
        Me.AnswerAFramePictureBox.Name = "AnswerAFramePictureBox"
        Me.AnswerAFramePictureBox.Size = New System.Drawing.Size(512, 57)
        Me.AnswerAFramePictureBox.TabIndex = 134
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
        Me.QuestionTextLabel.TabIndex = 129
        Me.QuestionTextLabel.Text = "Question Text"
        Me.QuestionTextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'PrizePictureBox
        '
        Me.PrizePictureBox.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.PrizePictureBox.BackColor = System.Drawing.Color.Transparent
        Me.PrizePictureBox.Image = Global.ControlProgram.My.Resources.Resources.LINE
        Me.PrizePictureBox.Location = New System.Drawing.Point(0, 0)
        Me.PrizePictureBox.Name = "PrizePictureBox"
        Me.PrizePictureBox.Size = New System.Drawing.Size(1024, 249)
        Me.PrizePictureBox.TabIndex = 149
        Me.PrizePictureBox.TabStop = False
        Me.PrizePictureBox.Visible = False
        '
        'LogoPictureBox
        '
        Me.LogoPictureBox.BackColor = System.Drawing.Color.Transparent
        Me.LogoPictureBox.BackgroundImage = Global.ControlProgram.My.Resources.Resources.LOGO_FEEL
        Me.LogoPictureBox.Location = New System.Drawing.Point(0, 0)
        Me.LogoPictureBox.Name = "LogoPictureBox"
        Me.LogoPictureBox.Size = New System.Drawing.Size(50, 50)
        Me.LogoPictureBox.TabIndex = 155
        Me.LogoPictureBox.TabStop = False
        Me.LogoPictureBox.Visible = False
        '
        'WinnerNameLabel
        '
        Me.WinnerNameLabel.AutoSize = True
        Me.WinnerNameLabel.BackColor = System.Drawing.Color.FromArgb(CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer), CType(CType(32, Byte), Integer))
        Me.WinnerNameLabel.Font = New System.Drawing.Font("a_CopperGothCaps", 45.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.WinnerNameLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(244, Byte), Integer), CType(CType(155, Byte), Integer), CType(CType(15, Byte), Integer))
        Me.WinnerNameLabel.Location = New System.Drawing.Point(162, 60)
        Me.WinnerNameLabel.MaximumSize = New System.Drawing.Size(701, 70)
        Me.WinnerNameLabel.MinimumSize = New System.Drawing.Size(700, 0)
        Me.WinnerNameLabel.Name = "WinnerNameLabel"
        Me.WinnerNameLabel.Size = New System.Drawing.Size(700, 68)
        Me.WinnerNameLabel.TabIndex = 157
        Me.WinnerNameLabel.Text = "WinnerNameLabel"
        Me.WinnerNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.WinnerNameLabel.Visible = False
        '
        'PlayerScreenForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.BackgroundImage = Global.ControlProgram.My.Resources.Resources.Player_Screen
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1024, 768)
        Me.Controls.Add(Me.LogoPictureBox)
        Me.Controls.Add(Me.WinnerNameLabel)
        Me.Controls.Add(Me.MoneyWonPictureBox)
        Me.Controls.Add(Me.AnswerDChartPictureBox)
        Me.Controls.Add(Me.AnswerCChartPictureBox)
        Me.Controls.Add(Me.AnswerBChartPictureBox)
        Me.Controls.Add(Me.AnswerAChartPictureBox)
        Me.Controls.Add(Me.AnswerDPercentLabel)
        Me.Controls.Add(Me.AnswerCPercentLabel)
        Me.Controls.Add(Me.AnswerBPercentLabel)
        Me.Controls.Add(Me.AnswerAPercentLabel)
        Me.Controls.Add(Me.ClockPictureBox)
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
        Me.Controls.Add(Me.PrizePictureBox)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = Global.ControlProgram.My.Resources.Resources.ICON
        Me.Location = New System.Drawing.Point(0, 768)
        Me.MaximizeBox = False
        Me.Name = "PlayerScreenForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Player"
        CType(Me.MoneyWonPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
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
        CType(Me.PrizePictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LogoPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MoneyWonPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerDChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerCChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerBChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerAChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerDPercentLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCPercentLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBPercentLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerAPercentLabel As System.Windows.Forms.Label
    Friend WithEvents ClockPictureBox As System.Windows.Forms.PictureBox
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
    Friend WithEvents PrizePictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents LogoPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents WinnerNameLabel As System.Windows.Forms.Label
End Class
