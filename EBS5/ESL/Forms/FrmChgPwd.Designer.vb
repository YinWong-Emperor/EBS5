<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmChgPwd
    Inherits ESL.frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GBxPassword = New System.Windows.Forms.GroupBox
        Me.TxtConfirmPass = New ESL.myTextbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtNewPass = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtOldPass = New ESL.myTextbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.GBxPassword.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(400, 140)
        '
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(350, 140)
        Me.btnSave.Visible = True
        '
        'GBxPassword
        '
        Me.GBxPassword.Controls.Add(Me.TxtConfirmPass)
        Me.GBxPassword.Controls.Add(Me.Label6)
        Me.GBxPassword.Controls.Add(Me.TxtNewPass)
        Me.GBxPassword.Controls.Add(Me.Label5)
        Me.GBxPassword.Controls.Add(Me.TxtOldPass)
        Me.GBxPassword.Controls.Add(Me.Label4)
        Me.GBxPassword.Location = New System.Drawing.Point(8, 26)
        Me.GBxPassword.Name = "GBxPassword"
        Me.GBxPassword.Size = New System.Drawing.Size(448, 112)
        Me.GBxPassword.TabIndex = 9
        Me.GBxPassword.TabStop = False
        Me.GBxPassword.Text = "Password"
        '
        'TxtConfirmPass
        '
        Me.TxtConfirmPass.Location = New System.Drawing.Point(196, 82)
        Me.TxtConfirmPass.Name = "TxtConfirmPass"
        Me.TxtConfirmPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmPass.Size = New System.Drawing.Size(188, 21)
        Me.TxtConfirmPass.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(198, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(110, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Confirm Password"
        '
        'TxtNewPass
        '
        Me.TxtNewPass.Location = New System.Drawing.Point(4, 82)
        Me.TxtNewPass.Name = "TxtNewPass"
        Me.TxtNewPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtNewPass.Size = New System.Drawing.Size(188, 21)
        Me.TxtNewPass.TabIndex = 9
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "New Password"
        '
        'TxtOldPass
        '
        Me.TxtOldPass.Location = New System.Drawing.Point(4, 40)
        Me.TxtOldPass.Name = "TxtOldPass"
        Me.TxtOldPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtOldPass.Size = New System.Drawing.Size(188, 21)
        Me.TxtOldPass.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Old Password"
        '
        'FrmChgPwd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(463, 196)
        Me.Controls.Add(Me.GBxPassword)
        Me.KeyPreview = True
        Me.Name = "FrmChgPwd"
        Me.Text = "Change Password"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GBxPassword, 0)
        Me.GBxPassword.ResumeLayout(False)
        Me.GBxPassword.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GBxPassword As System.Windows.Forms.GroupBox
    Friend WithEvents TxtConfirmPass As ESL.myTextbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNewPass As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtOldPass As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label

End Class
