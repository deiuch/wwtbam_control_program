<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class QuestionEditorForm
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
        Me.QuestionListBox = New System.Windows.Forms.ListBox()
        Me.QuestionFilePathLabel = New System.Windows.Forms.Label()
        Me.QuestionFieldTextBox1 = New System.Windows.Forms.TextBox()
        Me.QuestionFieldTextBox2 = New System.Windows.Forms.TextBox()
        Me.QuestionFieldTextBox3 = New System.Windows.Forms.TextBox()
        Me.QuestionFieldTextBox4 = New System.Windows.Forms.TextBox()
        Me.QuestionFieldTextBox5 = New System.Windows.Forms.TextBox()
        Me.AnswerARadioButton = New System.Windows.Forms.RadioButton()
        Me.AnswerBRadioButton = New System.Windows.Forms.RadioButton()
        Me.AnswerCRadioButton = New System.Windows.Forms.RadioButton()
        Me.AnswerDRadioButton = New System.Windows.Forms.RadioButton()
        Me.SaveBaseFileButton = New System.Windows.Forms.Button()
        Me.OpenBaseFileButton = New System.Windows.Forms.Button()
        Me.CreateBaseFileButton = New System.Windows.Forms.Button()
        Me.QuestionCommentTextBox = New System.Windows.Forms.TextBox()
        Me.QuestionCommentLabel = New System.Windows.Forms.Label()
        Me.OpenBaseFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveBaseFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SaveTemporarilyButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'QuestionListBox
        '
        Me.QuestionListBox.Enabled = False
        Me.QuestionListBox.FormattingEnabled = True
        Me.QuestionListBox.Items.AddRange(New Object() {"Q1", "Q2", "Q3", "Q4", "Q5", "Q6", "Q7", "Q8", "Q9", "Q10", "Q11", "Q12", "Q13", "Q14", "Q15"})
        Me.QuestionListBox.Location = New System.Drawing.Point(11, 12)
        Me.QuestionListBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.QuestionListBox.Name = "QuestionListBox"
        Me.QuestionListBox.Size = New System.Drawing.Size(149, 199)
        Me.QuestionListBox.TabIndex = 111
        '
        'QuestionFilePathLabel
        '
        Me.QuestionFilePathLabel.AutoSize = True
        Me.QuestionFilePathLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionFilePathLabel.Location = New System.Drawing.Point(167, 12)
        Me.QuestionFilePathLabel.Name = "QuestionFilePathLabel"
        Me.QuestionFilePathLabel.Size = New System.Drawing.Size(103, 13)
        Me.QuestionFilePathLabel.TabIndex = 112
        Me.QuestionFilePathLabel.Text = "Question File Adress"
        '
        'QuestionFieldTextBox1
        '
        Me.QuestionFieldTextBox1.Location = New System.Drawing.Point(170, 32)
        Me.QuestionFieldTextBox1.Multiline = True
        Me.QuestionFieldTextBox1.Name = "QuestionFieldTextBox1"
        Me.QuestionFieldTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.QuestionFieldTextBox1.Size = New System.Drawing.Size(302, 52)
        Me.QuestionFieldTextBox1.TabIndex = 113
        '
        'QuestionFieldTextBox2
        '
        Me.QuestionFieldTextBox2.Location = New System.Drawing.Point(205, 92)
        Me.QuestionFieldTextBox2.Name = "QuestionFieldTextBox2"
        Me.QuestionFieldTextBox2.Size = New System.Drawing.Size(114, 20)
        Me.QuestionFieldTextBox2.TabIndex = 114
        '
        'QuestionFieldTextBox3
        '
        Me.QuestionFieldTextBox3.Location = New System.Drawing.Point(358, 92)
        Me.QuestionFieldTextBox3.Name = "QuestionFieldTextBox3"
        Me.QuestionFieldTextBox3.Size = New System.Drawing.Size(114, 20)
        Me.QuestionFieldTextBox3.TabIndex = 115
        '
        'QuestionFieldTextBox4
        '
        Me.QuestionFieldTextBox4.Location = New System.Drawing.Point(205, 120)
        Me.QuestionFieldTextBox4.Name = "QuestionFieldTextBox4"
        Me.QuestionFieldTextBox4.Size = New System.Drawing.Size(114, 20)
        Me.QuestionFieldTextBox4.TabIndex = 116
        '
        'QuestionFieldTextBox5
        '
        Me.QuestionFieldTextBox5.Location = New System.Drawing.Point(358, 120)
        Me.QuestionFieldTextBox5.Name = "QuestionFieldTextBox5"
        Me.QuestionFieldTextBox5.Size = New System.Drawing.Size(114, 20)
        Me.QuestionFieldTextBox5.TabIndex = 117
        '
        'AnswerARadioButton
        '
        Me.AnswerARadioButton.AutoSize = True
        Me.AnswerARadioButton.ForeColor = System.Drawing.Color.White
        Me.AnswerARadioButton.Location = New System.Drawing.Point(170, 93)
        Me.AnswerARadioButton.Name = "AnswerARadioButton"
        Me.AnswerARadioButton.Size = New System.Drawing.Size(35, 17)
        Me.AnswerARadioButton.TabIndex = 118
        Me.AnswerARadioButton.Text = "A:"
        Me.AnswerARadioButton.UseVisualStyleBackColor = True
        '
        'AnswerBRadioButton
        '
        Me.AnswerBRadioButton.AutoSize = True
        Me.AnswerBRadioButton.ForeColor = System.Drawing.Color.White
        Me.AnswerBRadioButton.Location = New System.Drawing.Point(322, 93)
        Me.AnswerBRadioButton.Name = "AnswerBRadioButton"
        Me.AnswerBRadioButton.Size = New System.Drawing.Size(35, 17)
        Me.AnswerBRadioButton.TabIndex = 119
        Me.AnswerBRadioButton.Text = "B:"
        Me.AnswerBRadioButton.UseVisualStyleBackColor = True
        '
        'AnswerCRadioButton
        '
        Me.AnswerCRadioButton.AutoSize = True
        Me.AnswerCRadioButton.ForeColor = System.Drawing.Color.White
        Me.AnswerCRadioButton.Location = New System.Drawing.Point(170, 121)
        Me.AnswerCRadioButton.Name = "AnswerCRadioButton"
        Me.AnswerCRadioButton.Size = New System.Drawing.Size(35, 17)
        Me.AnswerCRadioButton.TabIndex = 120
        Me.AnswerCRadioButton.Text = "C:"
        Me.AnswerCRadioButton.UseVisualStyleBackColor = True
        '
        'AnswerDRadioButton
        '
        Me.AnswerDRadioButton.AutoSize = True
        Me.AnswerDRadioButton.ForeColor = System.Drawing.Color.White
        Me.AnswerDRadioButton.Location = New System.Drawing.Point(322, 121)
        Me.AnswerDRadioButton.Name = "AnswerDRadioButton"
        Me.AnswerDRadioButton.Size = New System.Drawing.Size(36, 17)
        Me.AnswerDRadioButton.TabIndex = 121
        Me.AnswerDRadioButton.Text = "D:"
        Me.AnswerDRadioButton.UseVisualStyleBackColor = True
        '
        'SaveBaseFileButton
        '
        Me.SaveBaseFileButton.BackColor = System.Drawing.Color.White
        Me.SaveBaseFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SaveBaseFileButton.Location = New System.Drawing.Point(128, 226)
        Me.SaveBaseFileButton.Name = "SaveBaseFileButton"
        Me.SaveBaseFileButton.Size = New System.Drawing.Size(110, 23)
        Me.SaveBaseFileButton.TabIndex = 122
        Me.SaveBaseFileButton.Text = "Save base file"
        Me.SaveBaseFileButton.UseVisualStyleBackColor = False
        '
        'OpenBaseFileButton
        '
        Me.OpenBaseFileButton.BackColor = System.Drawing.Color.White
        Me.OpenBaseFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.OpenBaseFileButton.Location = New System.Drawing.Point(244, 226)
        Me.OpenBaseFileButton.Name = "OpenBaseFileButton"
        Me.OpenBaseFileButton.Size = New System.Drawing.Size(110, 23)
        Me.OpenBaseFileButton.TabIndex = 123
        Me.OpenBaseFileButton.Text = "Open file..."
        Me.OpenBaseFileButton.UseVisualStyleBackColor = False
        '
        'CreateBaseFileButton
        '
        Me.CreateBaseFileButton.BackColor = System.Drawing.Color.White
        Me.CreateBaseFileButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.CreateBaseFileButton.Location = New System.Drawing.Point(360, 226)
        Me.CreateBaseFileButton.Name = "CreateBaseFileButton"
        Me.CreateBaseFileButton.Size = New System.Drawing.Size(110, 23)
        Me.CreateBaseFileButton.TabIndex = 124
        Me.CreateBaseFileButton.Text = "Create new file..."
        Me.CreateBaseFileButton.UseVisualStyleBackColor = False
        '
        'QuestionCommentTextBox
        '
        Me.QuestionCommentTextBox.Location = New System.Drawing.Point(170, 160)
        Me.QuestionCommentTextBox.Multiline = True
        Me.QuestionCommentTextBox.Name = "QuestionCommentTextBox"
        Me.QuestionCommentTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.QuestionCommentTextBox.Size = New System.Drawing.Size(302, 51)
        Me.QuestionCommentTextBox.TabIndex = 125
        '
        'QuestionCommentLabel
        '
        Me.QuestionCommentLabel.AutoSize = True
        Me.QuestionCommentLabel.ForeColor = System.Drawing.Color.White
        Me.QuestionCommentLabel.Location = New System.Drawing.Point(167, 144)
        Me.QuestionCommentLabel.Name = "QuestionCommentLabel"
        Me.QuestionCommentLabel.Size = New System.Drawing.Size(98, 13)
        Me.QuestionCommentLabel.TabIndex = 126
        Me.QuestionCommentLabel.Text = "Question comment:"
        '
        'OpenBaseFileDialog
        '
        Me.OpenBaseFileDialog.FileName = "*.questions"
        Me.OpenBaseFileDialog.Filter = "Question base files (*.questions)|All files (*.*)"
        Me.OpenBaseFileDialog.InitialDirectory = "\Bases"
        Me.OpenBaseFileDialog.Title = "Open question base file"
        '
        'SaveBaseFileDialog
        '
        Me.SaveBaseFileDialog.CreatePrompt = True
        Me.SaveBaseFileDialog.Filter = "Question base files (*.questions)|All files (*.*)"
        Me.SaveBaseFileDialog.InitialDirectory = "Bases\"
        Me.SaveBaseFileDialog.Title = "Save question base file"
        '
        'SaveTemporarilyButton
        '
        Me.SaveTemporarilyButton.BackColor = System.Drawing.Color.White
        Me.SaveTemporarilyButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.SaveTemporarilyButton.Location = New System.Drawing.Point(12, 226)
        Me.SaveTemporarilyButton.Name = "SaveTemporarilyButton"
        Me.SaveTemporarilyButton.Size = New System.Drawing.Size(110, 23)
        Me.SaveTemporarilyButton.TabIndex = 127
        Me.SaveTemporarilyButton.Text = "Save temporarily"
        Me.SaveTemporarilyButton.UseVisualStyleBackColor = False
        '
        'QuestionEditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(484, 261)
        Me.Controls.Add(Me.SaveTemporarilyButton)
        Me.Controls.Add(Me.QuestionCommentLabel)
        Me.Controls.Add(Me.QuestionCommentTextBox)
        Me.Controls.Add(Me.CreateBaseFileButton)
        Me.Controls.Add(Me.OpenBaseFileButton)
        Me.Controls.Add(Me.SaveBaseFileButton)
        Me.Controls.Add(Me.AnswerDRadioButton)
        Me.Controls.Add(Me.AnswerCRadioButton)
        Me.Controls.Add(Me.AnswerBRadioButton)
        Me.Controls.Add(Me.AnswerARadioButton)
        Me.Controls.Add(Me.QuestionFieldTextBox5)
        Me.Controls.Add(Me.QuestionFieldTextBox4)
        Me.Controls.Add(Me.QuestionFieldTextBox3)
        Me.Controls.Add(Me.QuestionFieldTextBox2)
        Me.Controls.Add(Me.QuestionFieldTextBox1)
        Me.Controls.Add(Me.QuestionFilePathLabel)
        Me.Controls.Add(Me.QuestionListBox)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.ControlProgram.My.Resources.Resources.ICON
        Me.MaximizeBox = False
        Me.Name = "QuestionEditorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Question editor"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents QuestionListBox As System.Windows.Forms.ListBox
    Friend WithEvents QuestionFilePathLabel As System.Windows.Forms.Label
    Friend WithEvents QuestionFieldTextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents QuestionFieldTextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents QuestionFieldTextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents QuestionFieldTextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents QuestionFieldTextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents AnswerARadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AnswerBRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AnswerCRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents AnswerDRadioButton As System.Windows.Forms.RadioButton
    Friend WithEvents SaveBaseFileButton As System.Windows.Forms.Button
    Friend WithEvents OpenBaseFileButton As System.Windows.Forms.Button
    Friend WithEvents CreateBaseFileButton As System.Windows.Forms.Button
    Friend WithEvents QuestionCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QuestionCommentLabel As System.Windows.Forms.Label
    Friend WithEvents OpenBaseFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveBaseFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveTemporarilyButton As System.Windows.Forms.Button
End Class
