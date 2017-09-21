<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStart
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStart))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.NumericUpDown7 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown6 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown5 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown4 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown3 = New System.Windows.Forms.NumericUpDown()
        Me.NumericUpDown2 = New System.Windows.Forms.NumericUpDown()
        Me.Button46 = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.DirectorySearcher1 = New System.DirectoryServices.DirectorySearcher()
        Me.DirectoryEntry1 = New System.DirectoryServices.DirectoryEntry()
        CType(Me.NumericUpDown7, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.BackColor = System.Drawing.Color.White
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button1.Location = New System.Drawing.Point(72, 238)
        Me.Button1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(149, 23)
        Me.Button1.TabIndex = 114
        Me.Button1.Text = "START"
        Me.Button1.UseVisualStyleBackColor = False
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.ForeColor = System.Drawing.Color.White
        Me.CheckBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBox1.Location = New System.Drawing.Point(31, 58)
        Me.CheckBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(83, 17)
        Me.CheckBox1.TabIndex = 161
        Me.CheckBox1.Text = "Host screen"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Checked = True
        Me.CheckBox2.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox2.ForeColor = System.Drawing.Color.White
        Me.CheckBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBox2.Location = New System.Drawing.Point(31, 86)
        Me.CheckBox2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(90, 17)
        Me.CheckBox2.TabIndex = 162
        Me.CheckBox2.Text = "Player screen"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Checked = True
        Me.CheckBox3.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox3.ForeColor = System.Drawing.Color.White
        Me.CheckBox3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.CheckBox3.Location = New System.Drawing.Point(31, 115)
        Me.CheckBox3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(106, 17)
        Me.CheckBox3.TabIndex = 163
        Me.CheckBox3.Text = "Audience screen"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!)
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label1.Location = New System.Drawing.Point(1, 18)
        Me.Label1.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label1.MaximumSize = New System.Drawing.Size(290, 0)
        Me.Label1.MinimumSize = New System.Drawing.Size(290, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(290, 24)
        Me.Label1.TabIndex = 164
        Me.Label1.Text = "WWTBAM Control Program"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'NumericUpDown7
        '
        Me.NumericUpDown7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericUpDown7.Location = New System.Drawing.Point(215, 114)
        Me.NumericUpDown7.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NumericUpDown7.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumericUpDown7.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.NumericUpDown7.Name = "NumericUpDown7"
        Me.NumericUpDown7.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown7.TabIndex = 220
        '
        'NumericUpDown6
        '
        Me.NumericUpDown6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericUpDown6.Location = New System.Drawing.Point(165, 114)
        Me.NumericUpDown6.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NumericUpDown6.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumericUpDown6.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.NumericUpDown6.Name = "NumericUpDown6"
        Me.NumericUpDown6.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown6.TabIndex = 219
        '
        'NumericUpDown5
        '
        Me.NumericUpDown5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericUpDown5.Location = New System.Drawing.Point(215, 85)
        Me.NumericUpDown5.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NumericUpDown5.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumericUpDown5.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.NumericUpDown5.Name = "NumericUpDown5"
        Me.NumericUpDown5.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown5.TabIndex = 218
        '
        'NumericUpDown4
        '
        Me.NumericUpDown4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericUpDown4.Location = New System.Drawing.Point(165, 85)
        Me.NumericUpDown4.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NumericUpDown4.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumericUpDown4.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.NumericUpDown4.Name = "NumericUpDown4"
        Me.NumericUpDown4.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown4.TabIndex = 217
        '
        'NumericUpDown3
        '
        Me.NumericUpDown3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericUpDown3.Location = New System.Drawing.Point(215, 57)
        Me.NumericUpDown3.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NumericUpDown3.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumericUpDown3.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.NumericUpDown3.Name = "NumericUpDown3"
        Me.NumericUpDown3.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown3.TabIndex = 216
        '
        'NumericUpDown2
        '
        Me.NumericUpDown2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NumericUpDown2.Location = New System.Drawing.Point(165, 57)
        Me.NumericUpDown2.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.NumericUpDown2.Maximum = New Decimal(New Integer() {5000, 0, 0, 0})
        Me.NumericUpDown2.Minimum = New Decimal(New Integer() {5000, 0, 0, -2147483648})
        Me.NumericUpDown2.Name = "NumericUpDown2"
        Me.NumericUpDown2.Size = New System.Drawing.Size(50, 20)
        Me.NumericUpDown2.TabIndex = 215
        '
        'Button46
        '
        Me.Button46.BackColor = System.Drawing.Color.White
        Me.Button46.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.Button46.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Button46.Location = New System.Drawing.Point(220, 167)
        Me.Button46.Name = "Button46"
        Me.Button46.Size = New System.Drawing.Size(52, 23)
        Me.Button46.TabIndex = 222
        Me.Button46.Text = "Open..."
        Me.Button46.UseVisualStyleBackColor = False
        '
        'TextBox1
        '
        Me.TextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TextBox1.Location = New System.Drawing.Point(31, 169)
        Me.TextBox1.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(184, 20)
        Me.TextBox1.TabIndex = 221
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label2.Location = New System.Drawing.Point(28, 146)
        Me.Label2.MaximumSize = New System.Drawing.Size(340, 13)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 223
        Me.Label2.Text = "Question base file:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Cursor = System.Windows.Forms.Cursors.Default
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.Label3.Location = New System.Drawing.Point(28, 205)
        Me.Label3.MaximumSize = New System.Drawing.Size(340, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(58, 13)
        Me.Label3.TabIndex = 224
        Me.Label3.Text = "Language:"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Items.AddRange(New Object() {"English"})
        Me.ComboBox1.Location = New System.Drawing.Point(92, 202)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(180, 21)
        Me.ComboBox1.TabIndex = 225
        Me.ComboBox1.Text = "select language"
        '
        'DirectorySearcher1
        '
        Me.DirectorySearcher1.ClientTimeout = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.SearchRoot = Me.DirectoryEntry1
        Me.DirectorySearcher1.ServerPageTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.ServerTimeLimit = System.TimeSpan.Parse("-00:00:01")
        Me.DirectorySearcher1.Sort.PropertyName = "Name"
        '
        'DirectoryEntry1
        '
        Me.DirectoryEntry1.Path = "\Languages"
        '
        'FormStart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(292, 273)
        Me.Controls.Add(Me.ComboBox1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button46)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.NumericUpDown7)
        Me.Controls.Add(Me.NumericUpDown6)
        Me.Controls.Add(Me.NumericUpDown5)
        Me.Controls.Add(Me.NumericUpDown4)
        Me.Controls.Add(Me.NumericUpDown3)
        Me.Controls.Add(Me.NumericUpDown2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FormStart"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "WWTBAM"
        CType(Me.NumericUpDown7, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDown2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents NumericUpDown7 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown6 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown5 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown4 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown3 As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDown2 As System.Windows.Forms.NumericUpDown
    Friend WithEvents Button46 As System.Windows.Forms.Button
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents DirectorySearcher1 As System.DirectoryServices.DirectorySearcher
    Friend WithEvents DirectoryEntry1 As System.DirectoryServices.DirectoryEntry
End Class
