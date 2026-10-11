<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FastestFingerEditorForm
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
        Me.SaveBaseFileButton = New System.Windows.Forms.Button()
        Me.OpenBaseFileButton = New System.Windows.Forms.Button()
        Me.CreateBaseFileButton = New System.Windows.Forms.Button()
        Me.QuestionCommentTextBox = New System.Windows.Forms.TextBox()
        Me.QuestionCommentLabel = New System.Windows.Forms.Label()
        Me.OpenBaseFileDialog = New System.Windows.Forms.OpenFileDialog()
        Me.SaveBaseFileDialog = New System.Windows.Forms.SaveFileDialog()
        Me.SaveTemporarilyButton = New System.Windows.Forms.Button()
        Me.AnswerALetterLabel = New System.Windows.Forms.Label()
        Me.AnswerBLetterLabel = New System.Windows.Forms.Label()
        Me.AnswerCLetterLabel = New System.Windows.Forms.Label()
        Me.AnswerDLetterLabel = New System.Windows.Forms.Label()
        Me.RightOrder1Label = New System.Windows.Forms.Label()
        Me.RightOrder2Label = New System.Windows.Forms.Label()
        Me.RightOrder3Label = New System.Windows.Forms.Label()
        Me.RightOrder4Label = New System.Windows.Forms.Label()
        Me.RightOrderLabel = New System.Windows.Forms.Label()
        Me.RightOrder1ComboBox = New System.Windows.Forms.ComboBox()
        Me.RightOrder2ComboBox = New System.Windows.Forms.ComboBox()
        Me.RightOrder3ComboBox = New System.Windows.Forms.ComboBox()
        Me.RightOrder4ComboBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'QuestionListBox
        '
        Me.QuestionListBox.Enabled = False
        Me.QuestionListBox.FormattingEnabled = True
        Me.QuestionListBox.Items.AddRange(New Object() {"Q1", "Q2", "Q3", "Q4", "Q5", "Q6", "Q7", "Q8"})
        Me.QuestionListBox.Location = New System.Drawing.Point(11, 12)
        Me.QuestionListBox.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.QuestionListBox.Name = "QuestionListBox"
        Me.QuestionListBox.Size = New System.Drawing.Size(149, 108)
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
        Me.QuestionFieldTextBox2.Location = New System.Drawing.Point(184, 92)
        Me.QuestionFieldTextBox2.Name = "QuestionFieldTextBox2"
        Me.QuestionFieldTextBox2.Size = New System.Drawing.Size(135, 20)
        Me.QuestionFieldTextBox2.TabIndex = 114
        '
        'QuestionFieldTextBox3
        '
        Me.QuestionFieldTextBox3.Location = New System.Drawing.Point(341, 92)
        Me.QuestionFieldTextBox3.Name = "QuestionFieldTextBox3"
        Me.QuestionFieldTextBox3.Size = New System.Drawing.Size(131, 20)
        Me.QuestionFieldTextBox3.TabIndex = 115
        '
        'QuestionFieldTextBox4
        '
        Me.QuestionFieldTextBox4.Location = New System.Drawing.Point(184, 120)
        Me.QuestionFieldTextBox4.Name = "QuestionFieldTextBox4"
        Me.QuestionFieldTextBox4.Size = New System.Drawing.Size(135, 20)
        Me.QuestionFieldTextBox4.TabIndex = 116
        '
        'QuestionFieldTextBox5
        '
        Me.QuestionFieldTextBox5.Location = New System.Drawing.Point(341, 120)
        Me.QuestionFieldTextBox5.Name = "QuestionFieldTextBox5"
        Me.QuestionFieldTextBox5.Size = New System.Drawing.Size(131, 20)
        Me.QuestionFieldTextBox5.TabIndex = 117
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
        Me.OpenBaseFileDialog.FileName = "*.fff"
        Me.OpenBaseFileDialog.Filter = "Question base for FFF (*.fff)|All files (*.*)"
        Me.OpenBaseFileDialog.InitialDirectory = "\Bases"
        Me.OpenBaseFileDialog.Title = "Open question base file"
        '
        'SaveBaseFileDialog
        '
        Me.SaveBaseFileDialog.CreatePrompt = True
        Me.SaveBaseFileDialog.Filter = "FFF question base files (*.fff)|All files (*.*)"
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
        'AnswerALetterLabel
        '
        Me.AnswerALetterLabel.AutoSize = True
        Me.AnswerALetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerALetterLabel.Location = New System.Drawing.Point(167, 95)
        Me.AnswerALetterLabel.Name = "AnswerALetterLabel"
        Me.AnswerALetterLabel.Size = New System.Drawing.Size(17, 13)
        Me.AnswerALetterLabel.TabIndex = 128
        Me.AnswerALetterLabel.Text = "A:"
        '
        'AnswerBLetterLabel
        '
        Me.AnswerBLetterLabel.AutoSize = True
        Me.AnswerBLetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerBLetterLabel.Location = New System.Drawing.Point(323, 95)
        Me.AnswerBLetterLabel.Name = "AnswerBLetterLabel"
        Me.AnswerBLetterLabel.Size = New System.Drawing.Size(17, 13)
        Me.AnswerBLetterLabel.TabIndex = 129
        Me.AnswerBLetterLabel.Text = "B:"
        '
        'AnswerCLetterLabel
        '
        Me.AnswerCLetterLabel.AutoSize = True
        Me.AnswerCLetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerCLetterLabel.Location = New System.Drawing.Point(167, 123)
        Me.AnswerCLetterLabel.Name = "AnswerCLetterLabel"
        Me.AnswerCLetterLabel.Size = New System.Drawing.Size(17, 13)
        Me.AnswerCLetterLabel.TabIndex = 130
        Me.AnswerCLetterLabel.Text = "C:"
        '
        'AnswerDLetterLabel
        '
        Me.AnswerDLetterLabel.AutoSize = True
        Me.AnswerDLetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDLetterLabel.Location = New System.Drawing.Point(323, 123)
        Me.AnswerDLetterLabel.Name = "AnswerDLetterLabel"
        Me.AnswerDLetterLabel.Size = New System.Drawing.Size(18, 13)
        Me.AnswerDLetterLabel.TabIndex = 131
        Me.AnswerDLetterLabel.Text = "D:"
        '
        'RightOrder1Label
        '
        Me.RightOrder1Label.AutoSize = True
        Me.RightOrder1Label.ForeColor = System.Drawing.Color.White
        Me.RightOrder1Label.Location = New System.Drawing.Point(10, 163)
        Me.RightOrder1Label.Name = "RightOrder1Label"
        Me.RightOrder1Label.Size = New System.Drawing.Size(21, 13)
        Me.RightOrder1Label.TabIndex = 135
        Me.RightOrder1Label.Text = "1st"
        '
        'RightOrder2Label
        '
        Me.RightOrder2Label.AutoSize = True
        Me.RightOrder2Label.ForeColor = System.Drawing.Color.White
        Me.RightOrder2Label.Location = New System.Drawing.Point(87, 163)
        Me.RightOrder2Label.Name = "RightOrder2Label"
        Me.RightOrder2Label.Size = New System.Drawing.Size(25, 13)
        Me.RightOrder2Label.TabIndex = 134
        Me.RightOrder2Label.Text = "2nd"
        '
        'RightOrder3Label
        '
        Me.RightOrder3Label.AutoSize = True
        Me.RightOrder3Label.ForeColor = System.Drawing.Color.White
        Me.RightOrder3Label.Location = New System.Drawing.Point(10, 191)
        Me.RightOrder3Label.Name = "RightOrder3Label"
        Me.RightOrder3Label.Size = New System.Drawing.Size(22, 13)
        Me.RightOrder3Label.TabIndex = 133
        Me.RightOrder3Label.Text = "3rd"
        '
        'RightOrder4Label
        '
        Me.RightOrder4Label.AutoSize = True
        Me.RightOrder4Label.ForeColor = System.Drawing.Color.White
        Me.RightOrder4Label.Location = New System.Drawing.Point(87, 191)
        Me.RightOrder4Label.Name = "RightOrder4Label"
        Me.RightOrder4Label.Size = New System.Drawing.Size(22, 13)
        Me.RightOrder4Label.TabIndex = 132
        Me.RightOrder4Label.Text = "4th"
        '
        'RightOrderLabel
        '
        Me.RightOrderLabel.AutoSize = True
        Me.RightOrderLabel.ForeColor = System.Drawing.Color.White
        Me.RightOrderLabel.Location = New System.Drawing.Point(8, 135)
        Me.RightOrderLabel.Name = "RightOrderLabel"
        Me.RightOrderLabel.Size = New System.Drawing.Size(62, 13)
        Me.RightOrderLabel.TabIndex = 140
        Me.RightOrderLabel.Text = "Right order:"
        '
        'RightOrder1ComboBox
        '
        Me.RightOrder1ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RightOrder1ComboBox.FormattingEnabled = True
        Me.RightOrder1ComboBox.Items.AddRange(New Object() {"", "A", "B", "C", "D"})
        Me.RightOrder1ComboBox.Location = New System.Drawing.Point(36, 160)
        Me.RightOrder1ComboBox.MaxDropDownItems = 5
        Me.RightOrder1ComboBox.Name = "RightOrder1ComboBox"
        Me.RightOrder1ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.RightOrder1ComboBox.TabIndex = 141
        '
        'RightOrder2ComboBox
        '
        Me.RightOrder2ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RightOrder2ComboBox.FormattingEnabled = True
        Me.RightOrder2ComboBox.Items.AddRange(New Object() {"", "A", "B", "C", "D"})
        Me.RightOrder2ComboBox.Location = New System.Drawing.Point(115, 160)
        Me.RightOrder2ComboBox.MaxDropDownItems = 5
        Me.RightOrder2ComboBox.Name = "RightOrder2ComboBox"
        Me.RightOrder2ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.RightOrder2ComboBox.TabIndex = 142
        '
        'RightOrder3ComboBox
        '
        Me.RightOrder3ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RightOrder3ComboBox.FormattingEnabled = True
        Me.RightOrder3ComboBox.Items.AddRange(New Object() {"", "A", "B", "C", "D"})
        Me.RightOrder3ComboBox.Location = New System.Drawing.Point(36, 188)
        Me.RightOrder3ComboBox.MaxDropDownItems = 5
        Me.RightOrder3ComboBox.Name = "RightOrder3ComboBox"
        Me.RightOrder3ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.RightOrder3ComboBox.TabIndex = 143
        '
        'RightOrder4ComboBox
        '
        Me.RightOrder4ComboBox.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.RightOrder4ComboBox.FormattingEnabled = True
        Me.RightOrder4ComboBox.Items.AddRange(New Object() {"", "A", "B", "C", "D"})
        Me.RightOrder4ComboBox.Location = New System.Drawing.Point(115, 188)
        Me.RightOrder4ComboBox.MaxDropDownItems = 5
        Me.RightOrder4ComboBox.Name = "RightOrder4ComboBox"
        Me.RightOrder4ComboBox.Size = New System.Drawing.Size(45, 21)
        Me.RightOrder4ComboBox.TabIndex = 144
        '
        'FastestFingerEditorForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(484, 261)
        Me.Controls.Add(Me.RightOrder4ComboBox)
        Me.Controls.Add(Me.RightOrder3ComboBox)
        Me.Controls.Add(Me.RightOrder2ComboBox)
        Me.Controls.Add(Me.RightOrder1ComboBox)
        Me.Controls.Add(Me.RightOrderLabel)
        Me.Controls.Add(Me.RightOrder1Label)
        Me.Controls.Add(Me.RightOrder2Label)
        Me.Controls.Add(Me.RightOrder3Label)
        Me.Controls.Add(Me.RightOrder4Label)
        Me.Controls.Add(Me.AnswerDLetterLabel)
        Me.Controls.Add(Me.AnswerCLetterLabel)
        Me.Controls.Add(Me.AnswerBLetterLabel)
        Me.Controls.Add(Me.AnswerALetterLabel)
        Me.Controls.Add(Me.SaveTemporarilyButton)
        Me.Controls.Add(Me.QuestionCommentLabel)
        Me.Controls.Add(Me.QuestionCommentTextBox)
        Me.Controls.Add(Me.CreateBaseFileButton)
        Me.Controls.Add(Me.OpenBaseFileButton)
        Me.Controls.Add(Me.SaveBaseFileButton)
        Me.Controls.Add(Me.QuestionFieldTextBox5)
        Me.Controls.Add(Me.QuestionFieldTextBox4)
        Me.Controls.Add(Me.QuestionFieldTextBox3)
        Me.Controls.Add(Me.QuestionFieldTextBox2)
        Me.Controls.Add(Me.QuestionFieldTextBox1)
        Me.Controls.Add(Me.QuestionFilePathLabel)
        Me.Controls.Add(Me.QuestionListBox)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.FastestFingerFirst.My.Resources.Resources.ICON
        Me.MaximizeBox = False
        Me.Name = "FastestFingerEditorForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "FFF question editor"
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
    Friend WithEvents SaveBaseFileButton As System.Windows.Forms.Button
    Friend WithEvents OpenBaseFileButton As System.Windows.Forms.Button
    Friend WithEvents CreateBaseFileButton As System.Windows.Forms.Button
    Friend WithEvents QuestionCommentTextBox As System.Windows.Forms.TextBox
    Friend WithEvents QuestionCommentLabel As System.Windows.Forms.Label
    Friend WithEvents OpenBaseFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SaveBaseFileDialog As System.Windows.Forms.SaveFileDialog
    Friend WithEvents SaveTemporarilyButton As System.Windows.Forms.Button
    Friend WithEvents AnswerALetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBLetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCLetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerDLetterLabel As System.Windows.Forms.Label
    Friend WithEvents RightOrder1Label As System.Windows.Forms.Label
    Friend WithEvents RightOrder2Label As System.Windows.Forms.Label
    Friend WithEvents RightOrder3Label As System.Windows.Forms.Label
    Friend WithEvents RightOrder4Label As System.Windows.Forms.Label
    Friend WithEvents RightOrderLabel As System.Windows.Forms.Label
    Friend WithEvents RightOrder1ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RightOrder2ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RightOrder3ComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents RightOrder4ComboBox As System.Windows.Forms.ComboBox
End Class
