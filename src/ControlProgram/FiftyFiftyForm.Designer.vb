<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FiftyFiftyForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FiftyFiftyForm))
        Me.AnswerDLetterLabel = New System.Windows.Forms.Label()
        Me.AnswerCLetterLabel = New System.Windows.Forms.Label()
        Me.AnswerBLetterLabel = New System.Windows.Forms.Label()
        Me.AnswerALetterLabel = New System.Windows.Forms.Label()
        Me.ExecuteButton = New System.Windows.Forms.Button()
        Me.KeepAnswerDCheckBox = New System.Windows.Forms.CheckBox()
        Me.KeepAnswerCCheckBox = New System.Windows.Forms.CheckBox()
        Me.KeepAnswerBCheckBox = New System.Windows.Forms.CheckBox()
        Me.KeepAnswerACheckBox = New System.Windows.Forms.CheckBox()
        Me.RandomiseButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'AnswerDLetterLabel
        '
        Me.AnswerDLetterLabel.AutoSize = True
        Me.AnswerDLetterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerDLetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerDLetterLabel.Location = New System.Drawing.Point(210, 71)
        Me.AnswerDLetterLabel.Name = "AnswerDLetterLabel"
        Me.AnswerDLetterLabel.Size = New System.Drawing.Size(34, 31)
        Me.AnswerDLetterLabel.TabIndex = 23
        Me.AnswerDLetterLabel.Text = "D"
        '
        'AnswerCLetterLabel
        '
        Me.AnswerCLetterLabel.AutoSize = True
        Me.AnswerCLetterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerCLetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerCLetterLabel.Location = New System.Drawing.Point(158, 71)
        Me.AnswerCLetterLabel.Name = "AnswerCLetterLabel"
        Me.AnswerCLetterLabel.Size = New System.Drawing.Size(34, 31)
        Me.AnswerCLetterLabel.TabIndex = 22
        Me.AnswerCLetterLabel.Text = "C"
        '
        'AnswerBLetterLabel
        '
        Me.AnswerBLetterLabel.AutoSize = True
        Me.AnswerBLetterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerBLetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerBLetterLabel.Location = New System.Drawing.Point(210, 23)
        Me.AnswerBLetterLabel.Name = "AnswerBLetterLabel"
        Me.AnswerBLetterLabel.Size = New System.Drawing.Size(32, 31)
        Me.AnswerBLetterLabel.TabIndex = 21
        Me.AnswerBLetterLabel.Text = "B"
        '
        'AnswerALetterLabel
        '
        Me.AnswerALetterLabel.AutoSize = True
        Me.AnswerALetterLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.AnswerALetterLabel.ForeColor = System.Drawing.Color.White
        Me.AnswerALetterLabel.Location = New System.Drawing.Point(159, 23)
        Me.AnswerALetterLabel.Name = "AnswerALetterLabel"
        Me.AnswerALetterLabel.Size = New System.Drawing.Size(32, 31)
        Me.AnswerALetterLabel.TabIndex = 20
        Me.AnswerALetterLabel.Text = "A"
        '
        'ExecuteButton
        '
        Me.ExecuteButton.BackColor = System.Drawing.Color.White
        Me.ExecuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.ExecuteButton.Location = New System.Drawing.Point(31, 115)
        Me.ExecuteButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.ExecuteButton.Name = "ExecuteButton"
        Me.ExecuteButton.Size = New System.Drawing.Size(100, 23)
        Me.ExecuteButton.TabIndex = 19
        Me.ExecuteButton.Text = "Execute"
        Me.ExecuteButton.UseVisualStyleBackColor = False
        '
        'KeepAnswerDCheckBox
        '
        Me.KeepAnswerDCheckBox.AutoSize = True
        Me.KeepAnswerDCheckBox.Checked = True
        Me.KeepAnswerDCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.KeepAnswerDCheckBox.ForeColor = System.Drawing.Color.White
        Me.KeepAnswerDCheckBox.Location = New System.Drawing.Point(46, 91)
        Me.KeepAnswerDCheckBox.Name = "KeepAnswerDCheckBox"
        Me.KeepAnswerDCheckBox.Size = New System.Drawing.Size(72, 17)
        Me.KeepAnswerDCheckBox.TabIndex = 18
        Me.KeepAnswerDCheckBox.Text = "Answer D"
        Me.KeepAnswerDCheckBox.UseVisualStyleBackColor = True
        '
        'KeepAnswerCCheckBox
        '
        Me.KeepAnswerCCheckBox.AutoSize = True
        Me.KeepAnswerCCheckBox.Checked = True
        Me.KeepAnswerCCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.KeepAnswerCCheckBox.ForeColor = System.Drawing.Color.White
        Me.KeepAnswerCCheckBox.Location = New System.Drawing.Point(46, 68)
        Me.KeepAnswerCCheckBox.Name = "KeepAnswerCCheckBox"
        Me.KeepAnswerCCheckBox.Size = New System.Drawing.Size(71, 17)
        Me.KeepAnswerCCheckBox.TabIndex = 17
        Me.KeepAnswerCCheckBox.Text = "Answer C"
        Me.KeepAnswerCCheckBox.UseVisualStyleBackColor = True
        '
        'KeepAnswerBCheckBox
        '
        Me.KeepAnswerBCheckBox.AutoSize = True
        Me.KeepAnswerBCheckBox.Checked = True
        Me.KeepAnswerBCheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.KeepAnswerBCheckBox.ForeColor = System.Drawing.Color.White
        Me.KeepAnswerBCheckBox.Location = New System.Drawing.Point(46, 45)
        Me.KeepAnswerBCheckBox.Name = "KeepAnswerBCheckBox"
        Me.KeepAnswerBCheckBox.Size = New System.Drawing.Size(71, 17)
        Me.KeepAnswerBCheckBox.TabIndex = 16
        Me.KeepAnswerBCheckBox.Text = "Answer B"
        Me.KeepAnswerBCheckBox.UseVisualStyleBackColor = True
        '
        'KeepAnswerACheckBox
        '
        Me.KeepAnswerACheckBox.AutoSize = True
        Me.KeepAnswerACheckBox.Checked = True
        Me.KeepAnswerACheckBox.CheckState = System.Windows.Forms.CheckState.Checked
        Me.KeepAnswerACheckBox.ForeColor = System.Drawing.Color.White
        Me.KeepAnswerACheckBox.Location = New System.Drawing.Point(46, 22)
        Me.KeepAnswerACheckBox.Name = "KeepAnswerACheckBox"
        Me.KeepAnswerACheckBox.Size = New System.Drawing.Size(71, 17)
        Me.KeepAnswerACheckBox.TabIndex = 15
        Me.KeepAnswerACheckBox.Text = "Answer A"
        Me.KeepAnswerACheckBox.UseVisualStyleBackColor = True
        '
        'RandomiseButton
        '
        Me.RandomiseButton.BackColor = System.Drawing.Color.White
        Me.RandomiseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.RandomiseButton.Location = New System.Drawing.Point(151, 115)
        Me.RandomiseButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.RandomiseButton.Name = "RandomiseButton"
        Me.RandomiseButton.Size = New System.Drawing.Size(100, 23)
        Me.RandomiseButton.TabIndex = 24
        Me.RandomiseButton.Text = "Randomise"
        Me.RandomiseButton.UseVisualStyleBackColor = False
        '
        'FiftyFiftyForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(284, 161)
        Me.Controls.Add(Me.RandomiseButton)
        Me.Controls.Add(Me.AnswerDLetterLabel)
        Me.Controls.Add(Me.AnswerCLetterLabel)
        Me.Controls.Add(Me.AnswerBLetterLabel)
        Me.Controls.Add(Me.AnswerALetterLabel)
        Me.Controls.Add(Me.ExecuteButton)
        Me.Controls.Add(Me.KeepAnswerDCheckBox)
        Me.Controls.Add(Me.KeepAnswerCCheckBox)
        Me.Controls.Add(Me.KeepAnswerBCheckBox)
        Me.Controls.Add(Me.KeepAnswerACheckBox)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FiftyFiftyForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Fifty-Fifty"
        Me.TopMost = True
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents AnswerDLetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerCLetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerBLetterLabel As System.Windows.Forms.Label
    Friend WithEvents AnswerALetterLabel As System.Windows.Forms.Label
    Friend WithEvents ExecuteButton As System.Windows.Forms.Button
    Friend WithEvents KeepAnswerDCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents KeepAnswerCCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents KeepAnswerBCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents KeepAnswerACheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents RandomiseButton As System.Windows.Forms.Button
End Class
