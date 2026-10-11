<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class StartForm
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
        Me.StartButton = New System.Windows.Forms.Button()
        Me.HostScreenCheckBox = New System.Windows.Forms.CheckBox()
        Me.PlayerScreenCheckBox = New System.Windows.Forms.CheckBox()
        Me.AudienceScreenCheckBox = New System.Windows.Forms.CheckBox()
        Me.TitleLabel = New System.Windows.Forms.Label()
        Me.AudienceScreenYNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.AudienceScreenXNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.PlayerScreenYNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.PlayerScreenXNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.HostScreenYNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.HostScreenXNumericUpDown = New System.Windows.Forms.NumericUpDown()
        Me.OpenQuestionBaseButton = New System.Windows.Forms.Button()
        Me.QuestionBaseFileTextBox = New System.Windows.Forms.TextBox()
        Me.QuestionBaseFileLabel = New System.Windows.Forms.Label()
        Me.LanguageLabel = New System.Windows.Forms.Label()
        Me.LanguageComboBox = New System.Windows.Forms.ComboBox()
        CType(Me.AudienceScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AudienceScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlayerScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PlayerScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HostScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HostScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StartButton
        '
        Me.StartButton.BackColor = System.Drawing.Color.White
        Me.StartButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StartButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.StartButton.Location = New System.Drawing.Point(72, 238)
        Me.StartButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StartButton.Name = "StartButton"
        Me.StartButton.Size = New System.Drawing.Size(149, 23)
        Me.StartButton.TabIndex = 114
        Me.StartButton.Text = "START"
        Me.StartButton.UseVisualStyleBackColor = False
        '
        'HostScreenCheckBox
        '
        Me.HostScreenCheckBox.AutoSize = True
        Me.HostScreenCheckBox.Checked = True
        Me.HostScreenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.HostScreenCheckBox.ForeColor = System.Drawing.Color.White
        Me.HostScreenCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.HostScreenCheckBox.Location = New System.Drawing.Point(31, 58)
        Me.HostScreenCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.HostScreenCheckBox.Name = "HostScreenCheckBox"
        Me.HostScreenCheckBox.Size = New System.Drawing.Size(83, 17)
        Me.HostScreenCheckBox.TabIndex = 161
        Me.HostScreenCheckBox.Text = "Host screen"
        Me.HostScreenCheckBox.UseVisualStyleBackColor = True
        '
        'PlayerScreenCheckBox
        '
        Me.PlayerScreenCheckBox.AutoSize = True
        Me.PlayerScreenCheckBox.Checked = True
        Me.PlayerScreenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.PlayerScreenCheckBox.ForeColor = System.Drawing.Color.White
        Me.PlayerScreenCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.PlayerScreenCheckBox.Location = New System.Drawing.Point(31, 86)
        Me.PlayerScreenCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PlayerScreenCheckBox.Name = "PlayerScreenCheckBox"
        Me.PlayerScreenCheckBox.Size = New System.Drawing.Size(90, 17)
        Me.PlayerScreenCheckBox.TabIndex = 162
        Me.PlayerScreenCheckBox.Text = "Player screen"
        Me.PlayerScreenCheckBox.UseVisualStyleBackColor = True
        '
        'AudienceScreenCheckBox
        '
        Me.AudienceScreenCheckBox.AutoSize = True
        Me.AudienceScreenCheckBox.Checked = True
        Me.AudienceScreenCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.AudienceScreenCheckBox.ForeColor = System.Drawing.Color.White
        Me.AudienceScreenCheckBox.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.AudienceScreenCheckBox.Location = New System.Drawing.Point(31, 115)
        Me.AudienceScreenCheckBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AudienceScreenCheckBox.Name = "AudienceScreenCheckBox"
        Me.AudienceScreenCheckBox.Size = New System.Drawing.Size(106, 17)
        Me.AudienceScreenCheckBox.TabIndex = 163
        Me.AudienceScreenCheckBox.Text = "Audience screen"
        Me.AudienceScreenCheckBox.UseVisualStyleBackColor = True
        '
        'TitleLabel
        '
        Me.TitleLabel.AutoSize = True
        Me.TitleLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.TitleLabel.ForeColor = System.Drawing.Color.White
        Me.TitleLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.TitleLabel.Location = New System.Drawing.Point(1, 18)
        Me.TitleLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TitleLabel.MaximumSize = New System.Drawing.Size(290, 0)
        Me.TitleLabel.MinimumSize = New System.Drawing.Size(290, 0)
        Me.TitleLabel.Name = "TitleLabel"
        Me.TitleLabel.Size = New System.Drawing.Size(290, 24)
        Me.TitleLabel.TabIndex = 164
        Me.TitleLabel.Text = "WWTBAM Control Program"
        Me.TitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'AudienceScreenYNumericUpDown
        '
        Me.AudienceScreenYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AudienceScreenYNumericUpDown.Location = New System.Drawing.Point(215, 114)
        Me.AudienceScreenYNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AudienceScreenYNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.AudienceScreenYNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.AudienceScreenYNumericUpDown.Name = "AudienceScreenYNumericUpDown"
        Me.AudienceScreenYNumericUpDown.Size = New System.Drawing.Size(50, 20)
        Me.AudienceScreenYNumericUpDown.TabIndex = 220
        '
        'AudienceScreenXNumericUpDown
        '
        Me.AudienceScreenXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.AudienceScreenXNumericUpDown.Location = New System.Drawing.Point(165, 114)
        Me.AudienceScreenXNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.AudienceScreenXNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.AudienceScreenXNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.AudienceScreenXNumericUpDown.Name = "AudienceScreenXNumericUpDown"
        Me.AudienceScreenXNumericUpDown.Size = New System.Drawing.Size(50, 20)
        Me.AudienceScreenXNumericUpDown.TabIndex = 219
        '
        'PlayerScreenYNumericUpDown
        '
        Me.PlayerScreenYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PlayerScreenYNumericUpDown.Location = New System.Drawing.Point(215, 85)
        Me.PlayerScreenYNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PlayerScreenYNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.PlayerScreenYNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.PlayerScreenYNumericUpDown.Name = "PlayerScreenYNumericUpDown"
        Me.PlayerScreenYNumericUpDown.Size = New System.Drawing.Size(50, 20)
        Me.PlayerScreenYNumericUpDown.TabIndex = 218
        '
        'PlayerScreenXNumericUpDown
        '
        Me.PlayerScreenXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PlayerScreenXNumericUpDown.Location = New System.Drawing.Point(165, 85)
        Me.PlayerScreenXNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.PlayerScreenXNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.PlayerScreenXNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.PlayerScreenXNumericUpDown.Name = "PlayerScreenXNumericUpDown"
        Me.PlayerScreenXNumericUpDown.Size = New System.Drawing.Size(50, 20)
        Me.PlayerScreenXNumericUpDown.TabIndex = 217
        '
        'HostScreenYNumericUpDown
        '
        Me.HostScreenYNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HostScreenYNumericUpDown.Location = New System.Drawing.Point(215, 57)
        Me.HostScreenYNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.HostScreenYNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.HostScreenYNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.HostScreenYNumericUpDown.Name = "HostScreenYNumericUpDown"
        Me.HostScreenYNumericUpDown.Size = New System.Drawing.Size(50, 20)
        Me.HostScreenYNumericUpDown.TabIndex = 216
        '
        'HostScreenXNumericUpDown
        '
        Me.HostScreenXNumericUpDown.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.HostScreenXNumericUpDown.Location = New System.Drawing.Point(165, 57)
        Me.HostScreenXNumericUpDown.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.HostScreenXNumericUpDown.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.HostScreenXNumericUpDown.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.HostScreenXNumericUpDown.Name = "HostScreenXNumericUpDown"
        Me.HostScreenXNumericUpDown.Size = New System.Drawing.Size(50, 20)
        Me.HostScreenXNumericUpDown.TabIndex = 215
        '
        'OpenQuestionBaseButton
        '
        Me.OpenQuestionBaseButton.BackColor = System.Drawing.Color.White
        Me.OpenQuestionBaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OpenQuestionBaseButton.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.OpenQuestionBaseButton.Location = New System.Drawing.Point(220, 167)
        Me.OpenQuestionBaseButton.Name = "OpenQuestionBaseButton"
        Me.OpenQuestionBaseButton.Size = New System.Drawing.Size(52, 23)
        Me.OpenQuestionBaseButton.TabIndex = 222
        Me.OpenQuestionBaseButton.Text = "Open..."
        Me.OpenQuestionBaseButton.UseVisualStyleBackColor = False
        '
        'QuestionBaseFileTextBox
        '
        Me.QuestionBaseFileTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.QuestionBaseFileTextBox.Location = New System.Drawing.Point(31, 169)
        Me.QuestionBaseFileTextBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.QuestionBaseFileTextBox.Name = "QuestionBaseFileTextBox"
        Me.QuestionBaseFileTextBox.ReadOnly = True
        Me.QuestionBaseFileTextBox.Size = New System.Drawing.Size(184, 20)
        Me.QuestionBaseFileTextBox.TabIndex = 221
        '
        'QuestionBaseFileLabel
        '
        Me.QuestionBaseFileLabel.AutoSize = True
        Me.QuestionBaseFileLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.QuestionBaseFileLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionBaseFileLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.QuestionBaseFileLabel.Location = New System.Drawing.Point(28, 146)
        Me.QuestionBaseFileLabel.MaximumSize = New System.Drawing.Size(340, 13)
        Me.QuestionBaseFileLabel.Name = "QuestionBaseFileLabel"
        Me.QuestionBaseFileLabel.Size = New System.Drawing.Size(94, 13)
        Me.QuestionBaseFileLabel.TabIndex = 223
        Me.QuestionBaseFileLabel.Text = "Question base file:"
        '
        'LanguageLabel
        '
        Me.LanguageLabel.AutoSize = True
        Me.LanguageLabel.Cursor = System.Windows.Forms.Cursors.Default
        Me.LanguageLabel.ForeColor = System.Drawing.Color.White
        Me.LanguageLabel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.LanguageLabel.Location = New System.Drawing.Point(28, 205)
        Me.LanguageLabel.MaximumSize = New System.Drawing.Size(340, 13)
        Me.LanguageLabel.Name = "LanguageLabel"
        Me.LanguageLabel.Size = New System.Drawing.Size(58, 13)
        Me.LanguageLabel.TabIndex = 224
        Me.LanguageLabel.Text = "Language:"
        '
        'LanguageComboBox
        '
        Me.LanguageComboBox.FormattingEnabled = True
        Me.LanguageComboBox.Items.AddRange(New Object() {"English"})
        Me.LanguageComboBox.Location = New System.Drawing.Point(92, 202)
        Me.LanguageComboBox.Name = "LanguageComboBox"
        Me.LanguageComboBox.Size = New System.Drawing.Size(180, 21)
        Me.LanguageComboBox.TabIndex = 225
        Me.LanguageComboBox.Text = "select language"
        '
        'StartForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.LanguageComboBox)
        Me.Controls.Add(Me.LanguageLabel)
        Me.Controls.Add(Me.QuestionBaseFileLabel)
        Me.Controls.Add(Me.OpenQuestionBaseButton)
        Me.Controls.Add(Me.QuestionBaseFileTextBox)
        Me.Controls.Add(Me.AudienceScreenYNumericUpDown)
        Me.Controls.Add(Me.AudienceScreenXNumericUpDown)
        Me.Controls.Add(Me.PlayerScreenYNumericUpDown)
        Me.Controls.Add(Me.PlayerScreenXNumericUpDown)
        Me.Controls.Add(Me.HostScreenYNumericUpDown)
        Me.Controls.Add(Me.HostScreenXNumericUpDown)
        Me.Controls.Add(Me.TitleLabel)
        Me.Controls.Add(Me.AudienceScreenCheckBox)
        Me.Controls.Add(Me.PlayerScreenCheckBox)
        Me.Controls.Add(Me.HostScreenCheckBox)
        Me.Controls.Add(Me.StartButton)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.ControlProgram.My.Resources.Resources.ICON
        Me.MaximizeBox = False
        Me.Name = "StartForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WWTBAM"
        CType(Me.AudienceScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AudienceScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlayerScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PlayerScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HostScreenYNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HostScreenXNumericUpDown, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents StartButton As System.Windows.Forms.Button
    Friend WithEvents HostScreenCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents PlayerScreenCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents AudienceScreenCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents TitleLabel As System.Windows.Forms.Label
    Friend WithEvents AudienceScreenYNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents AudienceScreenXNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents PlayerScreenYNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents PlayerScreenXNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents HostScreenYNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents HostScreenXNumericUpDown As System.Windows.Forms.NumericUpDown
    Friend WithEvents OpenQuestionBaseButton As System.Windows.Forms.Button
    Friend WithEvents QuestionBaseFileTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QuestionBaseFileLabel As System.Windows.Forms.Label
    Friend WithEvents LanguageLabel As System.Windows.Forms.Label
    Friend WithEvents LanguageComboBox As System.Windows.Forms.ComboBox
End Class
