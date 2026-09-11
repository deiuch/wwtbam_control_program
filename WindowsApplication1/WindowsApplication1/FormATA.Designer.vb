<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormATA
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormATA))
        Me.TotalPercentLabel = New System.Windows.Forms.Label()
        Me.ExecuteButton = New System.Windows.Forms.Button()
        Me.StartVotingButton = New System.Windows.Forms.Button()
        Me.TotalVotesLabel = New System.Windows.Forms.Label()
        Me.AnswerDPercentSignLabel = New System.Windows.Forms.Label()
        Me.AnswerCPercentSignLabel = New System.Windows.Forms.Label()
        Me.AnswerBPercentSignLabel = New System.Windows.Forms.Label()
        Me.AnswerAPercentSignLabel = New System.Windows.Forms.Label()
        Me.AnswerDOrLabel = New System.Windows.Forms.Label()
        Me.AnswerCOrLabel = New System.Windows.Forms.Label()
        Me.AnswerBOrLabel = New System.Windows.Forms.Label()
        Me.AnswerAOrLabel = New System.Windows.Forms.Label()
        Me.AnswerDLetterLabel = New System.Windows.Forms.Label()
        Me.AnswerCLetterLabel = New System.Windows.Forms.Label()
        Me.AnswerBLetterLabel = New System.Windows.Forms.Label()
        Me.AnswerALetterLabel = New System.Windows.Forms.Label()
        Me.AnswerDPercentNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AnswerCPercentNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AnswerBPercentNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AnswerAPercentNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AnswerDVotesNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AnswerCVotesNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AnswerBVotesNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AnswerAVotesNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AnswerDChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerCChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerBChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerAChartPictureBox = New System.Windows.Forms.PictureBox()
        Me.AnswerDResultLabel = New System.Windows.Forms.Label()
        Me.AnswerCResultLabel = New System.Windows.Forms.Label()
        Me.AnswerBResultLabel = New System.Windows.Forms.Label()
        Me.AnswerAResultLabel = New System.Windows.Forms.Label()
        Me.StartAskTheAudienceButton = New System.Windows.Forms.Button()
        CType(Me.AnswerDPercentNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerCPercentNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerBPercentNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerAPercentNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerDVotesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerCVotesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerBVotesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerAVotesNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerDChartPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerCChartPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerBChartPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AnswerAChartPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TotalPercentLabel
        '
        Me.TotalPercentLabel.AutoSize = True
        Me.TotalPercentLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TotalPercentLabel.ForeColor = System.Drawing.Color.White
        Me.TotalPercentLabel.Location = New System.Drawing.Point(122, 279)
        Me.TotalPercentLabel.Name = "TotalPercentLabel"
        Me.TotalPercentLabel.Size = New System.Drawing.Size(68, 13)
        Me.TotalPercentLabel.TabIndex = 76
        Me.TotalPercentLabel.Text = "All percents: "
        '
        'ExecuteButton
        '
        Me.ExecuteButton.BackColor = System.Drawing.Color.White
        Me.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ExecuteButton.Location = New System.Drawing.Point(19, 305)
        Me.ExecuteButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ExecuteButton.Name = "ExecuteButton"
        Me.ExecuteButton.Size = New System.Drawing.Size(206, 23)
        Me.ExecuteButton.TabIndex = 75
        Me.ExecuteButton.Text = "Execute"
        Me.ExecuteButton.UseVisualStyleBackColor = False
        '
        'StartVotingButton
        '
        Me.StartVotingButton.BackColor = System.Drawing.Color.White
        Me.StartVotingButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StartVotingButton.Location = New System.Drawing.Point(125, 36)
        Me.StartVotingButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StartVotingButton.Name = "StartVotingButton"
        Me.StartVotingButton.Size = New System.Drawing.Size(100, 23)
        Me.StartVotingButton.TabIndex = 74
        Me.StartVotingButton.Text = "Start Voiting"
        Me.StartVotingButton.UseVisualStyleBackColor = False
        '
        'TotalVotesLabel
        '
        Me.TotalVotesLabel.AutoSize = True
        Me.TotalVotesLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TotalVotesLabel.ForeColor = System.Drawing.Color.White
        Me.TotalVotesLabel.Location = New System.Drawing.Point(16, 279)
        Me.TotalVotesLabel.Name = "TotalVotesLabel"
        Me.TotalVotesLabel.Size = New System.Drawing.Size(58, 13)
        Me.TotalVotesLabel.TabIndex = 73
        Me.TotalVotesLabel.Text = "All voices: "
        '
        'AnswerDPercentSignLabel
        '
        Me.AnswerDPercentSignLabel.AutoSize = True
        Me.AnswerDPercentSignLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDPercentSignLabel.Location = New System.Drawing.Point(215, 237)
        Me.AnswerDPercentSignLabel.Name = "AnswerDPercentSignLabel"
        Me.AnswerDPercentSignLabel.Size = New System.Drawing.Size(15, 13)
        Me.AnswerDPercentSignLabel.TabIndex = 72
        Me.AnswerDPercentSignLabel.Text = "%"
        '
        'AnswerCPercentSignLabel
        '
        Me.AnswerCPercentSignLabel.AutoSize = True
        Me.AnswerCPercentSignLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerCPercentSignLabel.Location = New System.Drawing.Point(215, 187)
        Me.AnswerCPercentSignLabel.Name = "AnswerCPercentSignLabel"
        Me.AnswerCPercentSignLabel.Size = New System.Drawing.Size(15, 13)
        Me.AnswerCPercentSignLabel.TabIndex = 71
        Me.AnswerCPercentSignLabel.Text = "%"
        '
        'AnswerBPercentSignLabel
        '
        Me.AnswerBPercentSignLabel.AutoSize = True
        Me.AnswerBPercentSignLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerBPercentSignLabel.Location = New System.Drawing.Point(215, 137)
        Me.AnswerBPercentSignLabel.Name = "AnswerBPercentSignLabel"
        Me.AnswerBPercentSignLabel.Size = New System.Drawing.Size(15, 13)
        Me.AnswerBPercentSignLabel.TabIndex = 70
        Me.AnswerBPercentSignLabel.Text = "%"
        '
        'AnswerAPercentSignLabel
        '
        Me.AnswerAPercentSignLabel.AutoSize = True
        Me.AnswerAPercentSignLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerAPercentSignLabel.Location = New System.Drawing.Point(215, 86)
        Me.AnswerAPercentSignLabel.Name = "AnswerAPercentSignLabel"
        Me.AnswerAPercentSignLabel.Size = New System.Drawing.Size(15, 13)
        Me.AnswerAPercentSignLabel.TabIndex = 69
        Me.AnswerAPercentSignLabel.Text = "%"
        '
        'AnswerDOrLabel
        '
        Me.AnswerDOrLabel.AutoSize = True
        Me.AnswerDOrLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDOrLabel.Location = New System.Drawing.Point(119, 236)
        Me.AnswerDOrLabel.MinimumSize = New System.Drawing.Size(30, 0)
        Me.AnswerDOrLabel.Name = "AnswerDOrLabel"
        Me.AnswerDOrLabel.Size = New System.Drawing.Size(30, 13)
        Me.AnswerDOrLabel.TabIndex = 68
        Me.AnswerDOrLabel.Text = "or"
        Me.AnswerDOrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AnswerCOrLabel
        '
        Me.AnswerCOrLabel.AutoSize = True
        Me.AnswerCOrLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerCOrLabel.Location = New System.Drawing.Point(119, 186)
        Me.AnswerCOrLabel.MinimumSize = New System.Drawing.Size(30, 0)
        Me.AnswerCOrLabel.Name = "AnswerCOrLabel"
        Me.AnswerCOrLabel.Size = New System.Drawing.Size(30, 13)
        Me.AnswerCOrLabel.TabIndex = 67
        Me.AnswerCOrLabel.Text = "or"
        Me.AnswerCOrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AnswerBOrLabel
        '
        Me.AnswerBOrLabel.AutoSize = True
        Me.AnswerBOrLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerBOrLabel.Location = New System.Drawing.Point(119, 136)
        Me.AnswerBOrLabel.MinimumSize = New System.Drawing.Size(30, 0)
        Me.AnswerBOrLabel.Name = "AnswerBOrLabel"
        Me.AnswerBOrLabel.Size = New System.Drawing.Size(30, 13)
        Me.AnswerBOrLabel.TabIndex = 66
        Me.AnswerBOrLabel.Text = "or"
        Me.AnswerBOrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AnswerAOrLabel
        '
        Me.AnswerAOrLabel.AutoSize = True
        Me.AnswerAOrLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerAOrLabel.Location = New System.Drawing.Point(119, 85)
        Me.AnswerAOrLabel.MinimumSize = New System.Drawing.Size(30, 0)
        Me.AnswerAOrLabel.Name = "AnswerAOrLabel"
        Me.AnswerAOrLabel.Size = New System.Drawing.Size(30, 13)
        Me.AnswerAOrLabel.TabIndex = 65
        Me.AnswerAOrLabel.Text = "or"
        Me.AnswerAOrLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'AnswerDLetterLabel
        '
        Me.AnswerDLetterLabel.AutoSize = True
        Me.AnswerDLetterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerDLetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDLetterLabel.Location = New System.Drawing.Point(13, 227)
        Me.AnswerDLetterLabel.Name = "AnswerDLetterLabel"
        Me.AnswerDLetterLabel.Size = New System.Drawing.Size(34, 31)
        Me.AnswerDLetterLabel.TabIndex = 64
        Me.AnswerDLetterLabel.Text = "D"
        '
        'AnswerCLetterLabel
        '
        Me.AnswerCLetterLabel.AutoSize = True
        Me.AnswerCLetterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerCLetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerCLetterLabel.Location = New System.Drawing.Point(13, 177)
        Me.AnswerCLetterLabel.Name = "AnswerCLetterLabel"
        Me.AnswerCLetterLabel.Size = New System.Drawing.Size(34, 31)
        Me.AnswerCLetterLabel.TabIndex = 63
        Me.AnswerCLetterLabel.Text = "C"
        '
        'AnswerBLetterLabel
        '
        Me.AnswerBLetterLabel.AutoSize = True
        Me.AnswerBLetterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerBLetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerBLetterLabel.Location = New System.Drawing.Point(13, 127)
        Me.AnswerBLetterLabel.Name = "AnswerBLetterLabel"
        Me.AnswerBLetterLabel.Size = New System.Drawing.Size(32, 31)
        Me.AnswerBLetterLabel.TabIndex = 62
        Me.AnswerBLetterLabel.Text = "B"
        '
        'AnswerALetterLabel
        '
        Me.AnswerALetterLabel.AutoSize = True
        Me.AnswerALetterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerALetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerALetterLabel.Location = New System.Drawing.Point(13, 77)
        Me.AnswerALetterLabel.Name = "AnswerALetterLabel"
        Me.AnswerALetterLabel.Size = New System.Drawing.Size(32, 31)
        Me.AnswerALetterLabel.TabIndex = 61
        Me.AnswerALetterLabel.Text = "A"
        '
        'AnswerDPercentNumericUpDown
        '
        Me.AnswerDPercentNumericUpDown.Location = New System.Drawing.Point(149, 234)
        Me.AnswerDPercentNumericUpDown.Name = "AnswerDPercentNumericUpDown"
        Me.AnswerDPercentNumericUpDown.Size = New System.Drawing.Size(60, 20)
        Me.AnswerDPercentNumericUpDown.TabIndex = 60
        '
        'AnswerCPercentNumericUpDown
        '
        Me.AnswerCPercentNumericUpDown.Location = New System.Drawing.Point(149, 184)
        Me.AnswerCPercentNumericUpDown.Name = "AnswerCPercentNumericUpDown"
        Me.AnswerCPercentNumericUpDown.Size = New System.Drawing.Size(60, 20)
        Me.AnswerCPercentNumericUpDown.TabIndex = 59
        '
        'AnswerBPercentNumericUpDown
        '
        Me.AnswerBPercentNumericUpDown.Location = New System.Drawing.Point(149, 134)
        Me.AnswerBPercentNumericUpDown.Name = "AnswerBPercentNumericUpDown"
        Me.AnswerBPercentNumericUpDown.Size = New System.Drawing.Size(60, 20)
        Me.AnswerBPercentNumericUpDown.TabIndex = 58
        '
        'AnswerAPercentNumericUpDown
        '
        Me.AnswerAPercentNumericUpDown.Location = New System.Drawing.Point(149, 84)
        Me.AnswerAPercentNumericUpDown.Name = "AnswerAPercentNumericUpDown"
        Me.AnswerAPercentNumericUpDown.Size = New System.Drawing.Size(60, 20)
        Me.AnswerAPercentNumericUpDown.TabIndex = 57
        '
        'AnswerDVotesNumericUpDown
        '
        Me.AnswerDVotesNumericUpDown.Location = New System.Drawing.Point(56, 234)
        Me.AnswerDVotesNumericUpDown.Name = "AnswerDVotesNumericUpDown"
        Me.AnswerDVotesNumericUpDown.Size = New System.Drawing.Size(60, 20)
        Me.AnswerDVotesNumericUpDown.TabIndex = 56
        '
        'AnswerCVotesNumericUpDown
        '
        Me.AnswerCVotesNumericUpDown.Location = New System.Drawing.Point(56, 184)
        Me.AnswerCVotesNumericUpDown.Name = "AnswerCVotesNumericUpDown"
        Me.AnswerCVotesNumericUpDown.Size = New System.Drawing.Size(60, 20)
        Me.AnswerCVotesNumericUpDown.TabIndex = 55
        '
        'AnswerBVotesNumericUpDown
        '
        Me.AnswerBVotesNumericUpDown.Location = New System.Drawing.Point(56, 134)
        Me.AnswerBVotesNumericUpDown.Name = "AnswerBVotesNumericUpDown"
        Me.AnswerBVotesNumericUpDown.Size = New System.Drawing.Size(60, 20)
        Me.AnswerBVotesNumericUpDown.TabIndex = 54
        '
        'AnswerAVotesNumericUpDown
        '
        Me.AnswerAVotesNumericUpDown.Location = New System.Drawing.Point(56, 84)
        Me.AnswerAVotesNumericUpDown.Name = "AnswerAVotesNumericUpDown"
        Me.AnswerAVotesNumericUpDown.Size = New System.Drawing.Size(60, 20)
        Me.AnswerAVotesNumericUpDown.TabIndex = 53
        '
        'AnswerDChartPictureBox
        '
        Me.AnswerDChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerDChartPictureBox.Image = CType(resources.GetObject("AnswerDChartPictureBox.Image"), System.Drawing.Image)
        Me.AnswerDChartPictureBox.Location = New System.Drawing.Point(409, 60)
        Me.AnswerDChartPictureBox.Name = "AnswerDChartPictureBox"
        Me.AnswerDChartPictureBox.Size = New System.Drawing.Size(37, 240)
        Me.AnswerDChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerDChartPictureBox.TabIndex = 52
        Me.AnswerDChartPictureBox.TabStop = False
        '
        'AnswerCChartPictureBox
        '
        Me.AnswerCChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerCChartPictureBox.Image = CType(resources.GetObject("AnswerCChartPictureBox.Image"), System.Drawing.Image)
        Me.AnswerCChartPictureBox.Location = New System.Drawing.Point(360, 60)
        Me.AnswerCChartPictureBox.Name = "AnswerCChartPictureBox"
        Me.AnswerCChartPictureBox.Size = New System.Drawing.Size(37, 240)
        Me.AnswerCChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerCChartPictureBox.TabIndex = 51
        Me.AnswerCChartPictureBox.TabStop = False
        '
        'AnswerBChartPictureBox
        '
        Me.AnswerBChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerBChartPictureBox.Image = CType(resources.GetObject("AnswerBChartPictureBox.Image"), System.Drawing.Image)
        Me.AnswerBChartPictureBox.Location = New System.Drawing.Point(311, 60)
        Me.AnswerBChartPictureBox.Name = "AnswerBChartPictureBox"
        Me.AnswerBChartPictureBox.Size = New System.Drawing.Size(37, 240)
        Me.AnswerBChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerBChartPictureBox.TabIndex = 50
        Me.AnswerBChartPictureBox.TabStop = False
        '
        'AnswerAChartPictureBox
        '
        Me.AnswerAChartPictureBox.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.AnswerAChartPictureBox.Image = CType(resources.GetObject("AnswerAChartPictureBox.Image"), System.Drawing.Image)
        Me.AnswerAChartPictureBox.Location = New System.Drawing.Point(262, 60)
        Me.AnswerAChartPictureBox.Name = "AnswerAChartPictureBox"
        Me.AnswerAChartPictureBox.Size = New System.Drawing.Size(37, 240)
        Me.AnswerAChartPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.AnswerAChartPictureBox.TabIndex = 49
        Me.AnswerAChartPictureBox.TabStop = False
        '
        'AnswerDResultLabel
        '
        Me.AnswerDResultLabel.AutoSize = True
        Me.AnswerDResultLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerDResultLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnswerDResultLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDResultLabel.Location = New System.Drawing.Point(404, 35)
        Me.AnswerDResultLabel.MinimumSize = New System.Drawing.Size(50, 0)
        Me.AnswerDResultLabel.Name = "AnswerDResultLabel"
        Me.AnswerDResultLabel.Size = New System.Drawing.Size(50, 21)
        Me.AnswerDResultLabel.TabIndex = 48
        Me.AnswerDResultLabel.Text = "0%"
        Me.AnswerDResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerDResultLabel.Visible = False
        '
        'AnswerCResultLabel
        '
        Me.AnswerCResultLabel.AutoSize = True
        Me.AnswerCResultLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerCResultLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnswerCResultLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerCResultLabel.Location = New System.Drawing.Point(354, 35)
        Me.AnswerCResultLabel.MinimumSize = New System.Drawing.Size(50, 0)
        Me.AnswerCResultLabel.Name = "AnswerCResultLabel"
        Me.AnswerCResultLabel.Size = New System.Drawing.Size(50, 21)
        Me.AnswerCResultLabel.TabIndex = 47
        Me.AnswerCResultLabel.Text = "0%"
        Me.AnswerCResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerCResultLabel.Visible = False
        '
        'AnswerBResultLabel
        '
        Me.AnswerBResultLabel.AutoSize = True
        Me.AnswerBResultLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerBResultLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnswerBResultLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerBResultLabel.Location = New System.Drawing.Point(305, 35)
        Me.AnswerBResultLabel.MinimumSize = New System.Drawing.Size(50, 0)
        Me.AnswerBResultLabel.Name = "AnswerBResultLabel"
        Me.AnswerBResultLabel.Size = New System.Drawing.Size(50, 21)
        Me.AnswerBResultLabel.TabIndex = 46
        Me.AnswerBResultLabel.Text = "0%"
        Me.AnswerBResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerBResultLabel.Visible = False
        '
        'AnswerAResultLabel
        '
        Me.AnswerAResultLabel.AutoSize = True
        Me.AnswerAResultLabel.BackColor = System.Drawing.Color.Transparent
        Me.AnswerAResultLabel.Font = New System.Drawing.Font("ITC Conduit Cyrillic", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AnswerAResultLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerAResultLabel.Location = New System.Drawing.Point(256, 35)
        Me.AnswerAResultLabel.MinimumSize = New System.Drawing.Size(50, 0)
        Me.AnswerAResultLabel.Name = "AnswerAResultLabel"
        Me.AnswerAResultLabel.Size = New System.Drawing.Size(50, 21)
        Me.AnswerAResultLabel.TabIndex = 45
        Me.AnswerAResultLabel.Text = "0%"
        Me.AnswerAResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.AnswerAResultLabel.Visible = False
        '
        'StartAskTheAudienceButton
        '
        Me.StartAskTheAudienceButton.BackColor = System.Drawing.Color.White
        Me.StartAskTheAudienceButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StartAskTheAudienceButton.Location = New System.Drawing.Point(19, 36)
        Me.StartAskTheAudienceButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StartAskTheAudienceButton.Name = "StartAskTheAudienceButton"
        Me.StartAskTheAudienceButton.Size = New System.Drawing.Size(100, 23)
        Me.StartAskTheAudienceButton.TabIndex = 44
        Me.StartAskTheAudienceButton.Text = "Start ATA"
        Me.StartAskTheAudienceButton.UseVisualStyleBackColor = False
        '
        'FormATA
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(484, 361)
        Me.Controls.Add(Me.TotalPercentLabel)
        Me.Controls.Add(Me.ExecuteButton)
        Me.Controls.Add(Me.StartVotingButton)
        Me.Controls.Add(Me.TotalVotesLabel)
        Me.Controls.Add(Me.AnswerDPercentSignLabel)
        Me.Controls.Add(Me.AnswerCPercentSignLabel)
        Me.Controls.Add(Me.AnswerBPercentSignLabel)
        Me.Controls.Add(Me.AnswerAPercentSignLabel)
        Me.Controls.Add(Me.AnswerDOrLabel)
        Me.Controls.Add(Me.AnswerCOrLabel)
        Me.Controls.Add(Me.AnswerBOrLabel)
        Me.Controls.Add(Me.AnswerAOrLabel)
        Me.Controls.Add(Me.AnswerDLetterLabel)
        Me.Controls.Add(Me.AnswerCLetterLabel)
        Me.Controls.Add(Me.AnswerBLetterLabel)
        Me.Controls.Add(Me.AnswerALetterLabel)
        Me.Controls.Add(Me.AnswerDPercentNumericUpDown)
        Me.Controls.Add(Me.AnswerCPercentNumericUpDown)
        Me.Controls.Add(Me.AnswerBPercentNumericUpDown)
        Me.Controls.Add(Me.AnswerAPercentNumericUpDown)
        Me.Controls.Add(Me.AnswerDVotesNumericUpDown)
        Me.Controls.Add(Me.AnswerCVotesNumericUpDown)
        Me.Controls.Add(Me.AnswerBVotesNumericUpDown)
        Me.Controls.Add(Me.AnswerAVotesNumericUpDown)
        Me.Controls.Add(Me.AnswerDChartPictureBox)
        Me.Controls.Add(Me.AnswerCChartPictureBox)
        Me.Controls.Add(Me.AnswerBChartPictureBox)
        Me.Controls.Add(Me.AnswerAChartPictureBox)
        Me.Controls.Add(Me.AnswerDResultLabel)
        Me.Controls.Add(Me.AnswerCResultLabel)
        Me.Controls.Add(Me.AnswerBResultLabel)
        Me.Controls.Add(Me.AnswerAResultLabel)
        Me.Controls.Add(Me.StartAskTheAudienceButton)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormATA"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Ask The Audience"
        Me.TopMost = True
        CType(Me.AnswerDPercentNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerCPercentNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerBPercentNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerAPercentNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerDVotesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerCVotesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerBVotesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerAVotesNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerDChartPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerCChartPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerBChartPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AnswerAChartPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TotalPercentLabel As System.Windows.Forms.Label
    Friend WithEvents ExecuteButton As System.Windows.Forms.Button
    Friend WithEvents StartVotingButton As System.Windows.Forms.Button
    Friend WithEvents TotalVotesLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerDPercentSignLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCPercentSignLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBPercentSignLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerAPercentSignLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerDOrLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCOrLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBOrLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerAOrLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerDLetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCLetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBLetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerALetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerDPercentNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AnswerCPercentNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AnswerBPercentNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AnswerAPercentNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AnswerDVotesNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AnswerCVotesNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AnswerBVotesNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AnswerAVotesNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AnswerDChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerCChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerBChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerAChartPictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents AnswerDResultLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCResultLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBResultLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerAResultLabel As System.Windows.Forms.Label
    Friend WithEvents StartAskTheAudienceButton As System.Windows.Forms.Button
End Class
