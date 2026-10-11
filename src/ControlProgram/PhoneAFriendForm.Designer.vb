<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PhoneAFriendForm
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
        Me.StopClockButton = New System.Windows.Forms.Button()
        Me.StartClockButton = New System.Windows.Forms.Button()
        Me.StartPhoneAFriendButton = New System.Windows.Forms.Button()
        Me.ClockTimer = New System.Windows.Forms.Timer(Me.components)
        Me.ClockPictureBox = New System.Windows.Forms.PictureBox()
        CType(Me.ClockPictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'StopClockButton
        '
        Me.StopClockButton.BackColor = System.Drawing.Color.White
        Me.StopClockButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StopClockButton.Location = New System.Drawing.Point(35, 420)
        Me.StopClockButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StopClockButton.Name = "StopClockButton"
        Me.StopClockButton.Size = New System.Drawing.Size(315, 23)
        Me.StopClockButton.TabIndex = 16
        Me.StopClockButton.Text = "Stop the clock"
        Me.StopClockButton.UseVisualStyleBackColor = False
        '
        'StartClockButton
        '
        Me.StartClockButton.BackColor = System.Drawing.Color.White
        Me.StartClockButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StartClockButton.Location = New System.Drawing.Point(35, 391)
        Me.StartClockButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StartClockButton.Name = "StartClockButton"
        Me.StartClockButton.Size = New System.Drawing.Size(315, 23)
        Me.StartClockButton.TabIndex = 15
        Me.StartClockButton.Text = "Start the clock"
        Me.StartClockButton.UseVisualStyleBackColor = False
        '
        'StartPhoneAFriendButton
        '
        Me.StartPhoneAFriendButton.BackColor = System.Drawing.Color.White
        Me.StartPhoneAFriendButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.StartPhoneAFriendButton.Location = New System.Drawing.Point(35, 362)
        Me.StartPhoneAFriendButton.Margin = New System.Windows.Forms.Padding(2, 3, 2, 3)
        Me.StartPhoneAFriendButton.Name = "StartPhoneAFriendButton"
        Me.StartPhoneAFriendButton.Size = New System.Drawing.Size(315, 23)
        Me.StartPhoneAFriendButton.TabIndex = 14
        Me.StartPhoneAFriendButton.Text = "Start Phone-A-Friend"
        Me.StartPhoneAFriendButton.UseVisualStyleBackColor = False
        '
        'ClockTimer
        '
        Me.ClockTimer.Interval = 500
        '
        'ClockPictureBox
        '
        Me.ClockPictureBox.Image = Global.ControlProgram.My.Resources.Resources.Clock__62_
        Me.ClockPictureBox.Location = New System.Drawing.Point(35, 18)
        Me.ClockPictureBox.Name = "ClockPictureBox"
        Me.ClockPictureBox.Size = New System.Drawing.Size(315, 315)
        Me.ClockPictureBox.TabIndex = 13
        Me.ClockPictureBox.TabStop = False
        '
        'PhoneAFriendForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer), CType(CType(42, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(384, 461)
        Me.Controls.Add(Me.StopClockButton)
        Me.Controls.Add(Me.StartClockButton)
        Me.Controls.Add(Me.StartPhoneAFriendButton)
        Me.Controls.Add(Me.ClockPictureBox)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = Global.ControlProgram.My.Resources.Resources.ICON
        Me.MaximizeBox = False
        Me.Name = "PhoneAFriendForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Phone-A-Friend"
        Me.TopMost = True
        CType(Me.ClockPictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents StopClockButton As System.Windows.Forms.Button
    Friend WithEvents StartClockButton As System.Windows.Forms.Button
    Friend WithEvents StartPhoneAFriendButton As System.Windows.Forms.Button
    Friend WithEvents ClockTimer As System.Windows.Forms.Timer
    Friend WithEvents ClockPictureBox As System.Windows.Forms.PictureBox
End Class
