<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmUserMain
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.CboUserID = New System.Windows.Forms.ComboBox
        Me.GBxUserMain = New System.Windows.Forms.GroupBox
        Me.CboUserType = New System.Windows.Forms.ComboBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.ChkChgPwd = New System.Windows.Forms.CheckBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.ChkActive = New System.Windows.Forms.CheckBox
        Me.DTPExpiry = New System.Windows.Forms.DateTimePicker
        Me.CboDept = New System.Windows.Forms.ComboBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.TxtTitle = New ESL.myTextbox
        Me.LblTitle = New System.Windows.Forms.Label
        Me.TxtFirstName = New ESL.myTextbox
        Me.Label8 = New System.Windows.Forms.Label
        Me.TxtLastName = New ESL.myTextbox
        Me.Label7 = New System.Windows.Forms.Label
        Me.TxtUserID = New ESL.myTextbox
        Me.RdbUserInfo = New System.Windows.Forms.RadioButton
        Me.RdbPass = New System.Windows.Forms.RadioButton
        Me.GBxPassword = New System.Windows.Forms.GroupBox
        Me.TxtConfirmPass = New ESL.myTextbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.TxtNewPass = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TxtOldPass = New ESL.myTextbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.NewToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ModifyStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.DeleteToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.ExitToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.MnuUser = New System.Windows.Forms.MenuStrip
        Me.PasswordToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem
        Me.GBxUserMain.SuspendLayout()
        Me.GBxPassword.SuspendLayout()
        Me.MnuUser.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(556, 360)
        Me.btnCancel.Size = New System.Drawing.Size(68, 52)
        Me.btnCancel.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(476, 360)
        Me.btnSave.Size = New System.Drawing.Size(69, 52)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Visible = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(135, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 15)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "User ID"
        '
        'CboUserID
        '
        Me.CboUserID.FormattingEnabled = True
        Me.CboUserID.Location = New System.Drawing.Point(186, 60)
        Me.CboUserID.Name = "CboUserID"
        Me.CboUserID.Size = New System.Drawing.Size(121, 23)
        Me.CboUserID.TabIndex = 6
        '
        'GBxUserMain
        '
        Me.GBxUserMain.Controls.Add(Me.CboUserType)
        Me.GBxUserMain.Controls.Add(Me.Label11)
        Me.GBxUserMain.Controls.Add(Me.ChkChgPwd)
        Me.GBxUserMain.Controls.Add(Me.Label10)
        Me.GBxUserMain.Controls.Add(Me.ChkActive)
        Me.GBxUserMain.Controls.Add(Me.DTPExpiry)
        Me.GBxUserMain.Controls.Add(Me.CboDept)
        Me.GBxUserMain.Controls.Add(Me.Label9)
        Me.GBxUserMain.Controls.Add(Me.TxtTitle)
        Me.GBxUserMain.Controls.Add(Me.LblTitle)
        Me.GBxUserMain.Controls.Add(Me.TxtFirstName)
        Me.GBxUserMain.Controls.Add(Me.Label8)
        Me.GBxUserMain.Controls.Add(Me.TxtLastName)
        Me.GBxUserMain.Controls.Add(Me.Label7)
        Me.GBxUserMain.Location = New System.Drawing.Point(132, 88)
        Me.GBxUserMain.Name = "GBxUserMain"
        Me.GBxUserMain.Size = New System.Drawing.Size(496, 150)
        Me.GBxUserMain.TabIndex = 2
        Me.GBxUserMain.TabStop = False
        Me.GBxUserMain.Text = " User Maintenance"
        '
        'CboUserType
        '
        Me.CboUserType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboUserType.Enabled = False
        Me.CboUserType.FormattingEnabled = True
        Me.CboUserType.Items.AddRange(New Object() {"User", "Administrator"})
        Me.CboUserType.Location = New System.Drawing.Point(74, 126)
        Me.CboUserType.Name = "CboUserType"
        Me.CboUserType.Size = New System.Drawing.Size(176, 23)
        Me.CboUserType.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(4, 130)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(63, 15)
        Me.Label11.TabIndex = 25
        Me.Label11.Text = "User Type"
        '
        'ChkChgPwd
        '
        Me.ChkChgPwd.AutoSize = True
        Me.ChkChgPwd.Checked = True
        Me.ChkChgPwd.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkChgPwd.Location = New System.Drawing.Point(282, 20)
        Me.ChkChgPwd.Name = "ChkChgPwd"
        Me.ChkChgPwd.Size = New System.Drawing.Size(201, 19)
        Me.ChkChgPwd.TabIndex = 2
        Me.ChkChgPwd.Text = "Change Password on next login"
        Me.ChkChgPwd.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(4, 24)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 15)
        Me.Label10.TabIndex = 22
        Me.Label10.Text = "Expiry Date"
        '
        'ChkActive
        '
        Me.ChkActive.AutoSize = True
        Me.ChkActive.Checked = True
        Me.ChkActive.CheckState = System.Windows.Forms.CheckState.Checked
        Me.ChkActive.Location = New System.Drawing.Point(224, 20)
        Me.ChkActive.Name = "ChkActive"
        Me.ChkActive.Size = New System.Drawing.Size(57, 19)
        Me.ChkActive.TabIndex = 1
        Me.ChkActive.Text = "Active"
        Me.ChkActive.UseVisualStyleBackColor = True
        '
        'DTPExpiry
        '
        Me.DTPExpiry.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPExpiry.Location = New System.Drawing.Point(74, 20)
        Me.DTPExpiry.Name = "DTPExpiry"
        Me.DTPExpiry.Size = New System.Drawing.Size(98, 21)
        Me.DTPExpiry.TabIndex = 0
        '
        'CboDept
        '
        Me.CboDept.Enabled = False
        Me.CboDept.FormattingEnabled = True
        Me.CboDept.Location = New System.Drawing.Point(74, 104)
        Me.CboDept.Name = "CboDept"
        Me.CboDept.Size = New System.Drawing.Size(176, 23)
        Me.CboDept.TabIndex = 6
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(4, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Department"
        '
        'TxtTitle
        '
        Me.TxtTitle.Location = New System.Drawing.Point(74, 84)
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.Size = New System.Drawing.Size(334, 21)
        Me.TxtTitle.TabIndex = 5
        '
        'LblTitle
        '
        Me.LblTitle.AutoSize = True
        Me.LblTitle.Location = New System.Drawing.Point(4, 86)
        Me.LblTitle.Name = "LblTitle"
        Me.LblTitle.Size = New System.Drawing.Size(30, 15)
        Me.LblTitle.TabIndex = 15
        Me.LblTitle.Text = "Title"
        '
        'TxtFirstName
        '
        Me.TxtFirstName.Location = New System.Drawing.Point(74, 64)
        Me.TxtFirstName.Name = "TxtFirstName"
        Me.TxtFirstName.Size = New System.Drawing.Size(334, 21)
        Me.TxtFirstName.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(4, 66)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 15)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "First Name"
        '
        'TxtLastName
        '
        Me.TxtLastName.Location = New System.Drawing.Point(74, 42)
        Me.TxtLastName.Name = "TxtLastName"
        Me.TxtLastName.Size = New System.Drawing.Size(334, 21)
        Me.TxtLastName.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(4, 46)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 15)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Last Name"
        '
        'TxtUserID
        '
        Me.TxtUserID.Location = New System.Drawing.Point(185, 60)
        Me.TxtUserID.Name = "TxtUserID"
        Me.TxtUserID.Size = New System.Drawing.Size(122, 21)
        Me.TxtUserID.TabIndex = 1
        Me.TxtUserID.Visible = False
        '
        'RdbUserInfo
        '
        Me.RdbUserInfo.AutoSize = True
        Me.RdbUserInfo.Checked = True
        Me.RdbUserInfo.Location = New System.Drawing.Point(136, 32)
        Me.RdbUserInfo.Name = "RdbUserInfo"
        Me.RdbUserInfo.Size = New System.Drawing.Size(113, 19)
        Me.RdbUserInfo.TabIndex = 7
        Me.RdbUserInfo.TabStop = True
        Me.RdbUserInfo.Text = "User Infomation"
        Me.RdbUserInfo.UseVisualStyleBackColor = True
        '
        'RdbPass
        '
        Me.RdbPass.AutoSize = True
        Me.RdbPass.Location = New System.Drawing.Point(256, 32)
        Me.RdbPass.Name = "RdbPass"
        Me.RdbPass.Size = New System.Drawing.Size(81, 19)
        Me.RdbPass.TabIndex = 8
        Me.RdbPass.Text = "Password"
        Me.RdbPass.UseVisualStyleBackColor = True
        '
        'GBxPassword
        '
        Me.GBxPassword.Controls.Add(Me.TxtConfirmPass)
        Me.GBxPassword.Controls.Add(Me.Label6)
        Me.GBxPassword.Controls.Add(Me.TxtNewPass)
        Me.GBxPassword.Controls.Add(Me.Label5)
        Me.GBxPassword.Controls.Add(Me.TxtOldPass)
        Me.GBxPassword.Controls.Add(Me.Label4)
        Me.GBxPassword.Enabled = False
        Me.GBxPassword.Location = New System.Drawing.Point(132, 240)
        Me.GBxPassword.Name = "GBxPassword"
        Me.GBxPassword.Size = New System.Drawing.Size(494, 112)
        Me.GBxPassword.TabIndex = 3
        Me.GBxPassword.TabStop = False
        Me.GBxPassword.Text = "Password"
        '
        'TxtConfirmPass
        '
        Me.TxtConfirmPass.Location = New System.Drawing.Point(196, 82)
        Me.TxtConfirmPass.Name = "TxtConfirmPass"
        Me.TxtConfirmPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtConfirmPass.Size = New System.Drawing.Size(188, 21)
        Me.TxtConfirmPass.TabIndex = 2
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
        Me.TxtNewPass.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(91, 15)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "New Password"
        '
        'TxtOldPass
        '
        Me.TxtOldPass.Location = New System.Drawing.Point(4, 40)
        Me.TxtOldPass.Name = "TxtOldPass"
        Me.TxtOldPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.TxtOldPass.Size = New System.Drawing.Size(188, 21)
        Me.TxtOldPass.TabIndex = 0
        Me.TxtOldPass.Visible = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(85, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Old Password"
        Me.Label4.Visible = False
        '
        'NewToolStripMenuItem
        '
        Me.NewToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NewToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.NewToolStripMenuItem.Name = "NewToolStripMenuItem"
        Me.NewToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.NewToolStripMenuItem.Text = "1. New"
        Me.NewToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.NewToolStripMenuItem.ToolTipText = "New Account"
        '
        'ModifyStripMenuItem
        '
        Me.ModifyStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ModifyStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ModifyStripMenuItem.Name = "ModifyStripMenuItem"
        Me.ModifyStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ModifyStripMenuItem.Text = "2. Modify"
        Me.ModifyStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DeleteToolStripMenuItem
        '
        Me.DeleteToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.DeleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem"
        Me.DeleteToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.DeleteToolStripMenuItem.Text = "3. Delete"
        Me.DeleteToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ExitToolStripMenuItem
        '
        Me.ExitToolStripMenuItem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.ExitToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem"
        Me.ExitToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.ExitToolStripMenuItem.Text = "5. Exit"
        Me.ExitToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'MnuUser
        '
        Me.MnuUser.Dock = System.Windows.Forms.DockStyle.Left
        Me.MnuUser.Font = New System.Drawing.Font("Arial", 12.0!)
        Me.MnuUser.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NewToolStripMenuItem, Me.ModifyStripMenuItem, Me.DeleteToolStripMenuItem, Me.PasswordToolStripMenuItem, Me.ExitToolStripMenuItem})
        Me.MnuUser.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow
        Me.MnuUser.Location = New System.Drawing.Point(0, 0)
        Me.MnuUser.Name = "MnuUser"
        Me.MnuUser.Padding = New System.Windows.Forms.Padding(7, 2, 0, 2)
        Me.MnuUser.Size = New System.Drawing.Size(114, 415)
        Me.MnuUser.TabIndex = 0
        Me.MnuUser.TabStop = True
        Me.MnuUser.Text = "MenuStrip1"
        '
        'PasswordToolStripMenuItem
        '
        Me.PasswordToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.PasswordToolStripMenuItem.Name = "PasswordToolStripMenuItem"
        Me.PasswordToolStripMenuItem.Size = New System.Drawing.Size(99, 22)
        Me.PasswordToolStripMenuItem.Text = "4. Password"
        '
        'FrmUserMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(647, 415)
        Me.Controls.Add(Me.MnuUser)
        Me.Controls.Add(Me.GBxUserMain)
        Me.Controls.Add(Me.TxtUserID)
        Me.Controls.Add(Me.RdbUserInfo)
        Me.Controls.Add(Me.CboUserID)
        Me.Controls.Add(Me.RdbPass)
        Me.Controls.Add(Me.GBxPassword)
        Me.Controls.Add(Me.Label3)
        Me.KeyPreview = True
        Me.Name = "FrmUserMain"
        Me.Text = "User Maintenance "
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.GBxPassword, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.RdbPass, 0)
        Me.Controls.SetChildIndex(Me.CboUserID, 0)
        Me.Controls.SetChildIndex(Me.RdbUserInfo, 0)
        Me.Controls.SetChildIndex(Me.TxtUserID, 0)
        Me.Controls.SetChildIndex(Me.GBxUserMain, 0)
        Me.Controls.SetChildIndex(Me.MnuUser, 0)
        Me.GBxUserMain.ResumeLayout(False)
        Me.GBxUserMain.PerformLayout()
        Me.GBxPassword.ResumeLayout(False)
        Me.GBxPassword.PerformLayout()
        Me.MnuUser.ResumeLayout(False)
        Me.MnuUser.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboUserID As System.Windows.Forms.ComboBox
    Friend WithEvents GBxUserMain As System.Windows.Forms.GroupBox
    Friend WithEvents GBxPassword As System.Windows.Forms.GroupBox
    Friend WithEvents TxtConfirmPass As ESL.myTextbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TxtNewPass As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TxtOldPass As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RdbUserInfo As System.Windows.Forms.RadioButton
    Friend WithEvents RdbPass As System.Windows.Forms.RadioButton
    Friend WithEvents TxtFirstName As ESL.myTextbox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TxtLastName As ESL.myTextbox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents TxtTitle As ESL.myTextbox
    Friend WithEvents LblTitle As System.Windows.Forms.Label
    Friend WithEvents CboDept As System.Windows.Forms.ComboBox
    Friend WithEvents TxtUserID As ESL.myTextbox
    Friend WithEvents NewToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ModifyStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents DeleteToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ExitToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MnuUser As System.Windows.Forms.MenuStrip
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents DTPExpiry As System.Windows.Forms.DateTimePicker
    Friend WithEvents ChkChgPwd As System.Windows.Forms.CheckBox
    Friend WithEvents ChkActive As System.Windows.Forms.CheckBox
    Friend WithEvents CboUserType As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents PasswordToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
