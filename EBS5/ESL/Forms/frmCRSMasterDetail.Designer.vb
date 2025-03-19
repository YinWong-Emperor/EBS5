<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCRSMasterDetail
    Inherits ESL.frmBase

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtBrithCity = New ESL.myTextbox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cmbBrithCountryCode = New ESL.myComboBox(Me.components)
        Me.Label16 = New System.Windows.Forms.Label()
        Me.dtpBirthDate = New ESL.myDateTimePicker()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtAddressFreeText = New ESL.myTextbox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbAddressCountryCode = New ESL.myComboBox(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbLegalAddressType = New ESL.myComboBox(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cmbTINIssueBy = New ESL.myComboBox(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtTIN = New ESL.myTextbox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbResCountryCode = New ESL.myComboBox(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbCPType = New ESL.myComboBox(Me.components)
        Me.lblCPType = New System.Windows.Forms.Label()
        Me.cmbAccountHolderType = New ESL.myComboBox(Me.components)
        Me.lblAccHolderType = New System.Windows.Forms.Label()
        Me.txtLastName = New ESL.myTextbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFirstName = New ESL.myTextbox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtClientName = New ESL.myTextbox()
        Me.lblCRSType = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblAccountType = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblAccno = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(647, 561)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(595, 561)
        Me.btnSave.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtBrithCity)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.cmbBrithCountryCode)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.dtpBirthDate)
        Me.GroupBox1.Controls.Add(Me.Label15)
        Me.GroupBox1.Controls.Add(Me.txtAddressFreeText)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.cmbAddressCountryCode)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.cmbLegalAddressType)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.cmbTINIssueBy)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.txtTIN)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.cmbResCountryCode)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.cmbCPType)
        Me.GroupBox1.Controls.Add(Me.lblCPType)
        Me.GroupBox1.Controls.Add(Me.cmbAccountHolderType)
        Me.GroupBox1.Controls.Add(Me.lblAccHolderType)
        Me.GroupBox1.Controls.Add(Me.txtLastName)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.txtFirstName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtClientName)
        Me.GroupBox1.Controls.Add(Me.lblCRSType)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.lblAccountType)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.lblAccno)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(688, 542)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'txtBrithCity
        '
        Me.txtBrithCity.Location = New System.Drawing.Point(151, 501)
        Me.txtBrithCity.MaxLength = 70
        Me.txtBrithCity.Name = "txtBrithCity"
        Me.txtBrithCity.Size = New System.Drawing.Size(531, 21)
        Me.txtBrithCity.TabIndex = 36
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 504)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(58, 15)
        Me.Label17.TabIndex = 35
        Me.Label17.Text = "Birth City:"
        '
        'cmbBrithCountryCode
        '
        Me.cmbBrithCountryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBrithCountryCode.FormattingEnabled = True
        Me.cmbBrithCountryCode.Location = New System.Drawing.Point(151, 472)
        Me.cmbBrithCountryCode.Name = "cmbBrithCountryCode"
        Me.cmbBrithCountryCode.Size = New System.Drawing.Size(531, 23)
        Me.cmbBrithCountryCode.TabIndex = 34
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(6, 475)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(113, 15)
        Me.Label16.TabIndex = 33
        Me.Label16.Text = "Birth Country Code:"
        '
        'dtpBirthDate
        '
        Me.dtpBirthDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpBirthDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpBirthDate.Location = New System.Drawing.Point(151, 442)
        Me.dtpBirthDate.MinDate = New Date(1900, 1, 1, 0, 0, 0, 0)
        Me.dtpBirthDate.Name = "dtpBirthDate"
        Me.dtpBirthDate.Size = New System.Drawing.Size(531, 21)
        Me.dtpBirthDate.TabIndex = 32
        Me.dtpBirthDate.Value = New Date(2018, 6, 22, 0, 0, 0, 0)
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(6, 451)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 15)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Birth Date:"
        '
        'txtAddressFreeText
        '
        Me.txtAddressFreeText.Location = New System.Drawing.Point(151, 373)
        Me.txtAddressFreeText.MaxLength = 4000
        Me.txtAddressFreeText.Multiline = True
        Me.txtAddressFreeText.Name = "txtAddressFreeText"
        Me.txtAddressFreeText.Size = New System.Drawing.Size(531, 63)
        Me.txtAddressFreeText.TabIndex = 30
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 373)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(108, 15)
        Me.Label14.TabIndex = 29
        Me.Label14.Text = "Address Free Text:"
        '
        'cmbAddressCountryCode
        '
        Me.cmbAddressCountryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAddressCountryCode.FormattingEnabled = True
        Me.cmbAddressCountryCode.Location = New System.Drawing.Point(151, 344)
        Me.cmbAddressCountryCode.Name = "cmbAddressCountryCode"
        Me.cmbAddressCountryCode.Size = New System.Drawing.Size(531, 23)
        Me.cmbAddressCountryCode.TabIndex = 28
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 347)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(134, 15)
        Me.Label13.TabIndex = 27
        Me.Label13.Text = "Address Country Code:"
        '
        'cmbLegalAddressType
        '
        Me.cmbLegalAddressType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbLegalAddressType.FormattingEnabled = True
        Me.cmbLegalAddressType.Location = New System.Drawing.Point(151, 315)
        Me.cmbLegalAddressType.Name = "cmbLegalAddressType"
        Me.cmbLegalAddressType.Size = New System.Drawing.Size(531, 23)
        Me.cmbLegalAddressType.TabIndex = 26
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 318)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(117, 15)
        Me.Label12.TabIndex = 25
        Me.Label12.Text = "Legal Address Type:"
        '
        'cmbTINIssueBy
        '
        Me.cmbTINIssueBy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTINIssueBy.FormattingEnabled = True
        Me.cmbTINIssueBy.Location = New System.Drawing.Point(151, 287)
        Me.cmbTINIssueBy.Name = "cmbTINIssueBy"
        Me.cmbTINIssueBy.Size = New System.Drawing.Size(531, 23)
        Me.cmbTINIssueBy.TabIndex = 24
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 290)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(77, 15)
        Me.Label11.TabIndex = 23
        Me.Label11.Text = "Tin Issue By:"
        '
        'txtTIN
        '
        Me.txtTIN.Location = New System.Drawing.Point(151, 261)
        Me.txtTIN.MaxLength = 80
        Me.txtTIN.Name = "txtTIN"
        Me.txtTIN.Size = New System.Drawing.Size(531, 21)
        Me.txtTIN.TabIndex = 22
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 264)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(29, 15)
        Me.Label10.TabIndex = 21
        Me.Label10.Text = "TIN:"
        '
        'cmbResCountryCode
        '
        Me.cmbResCountryCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbResCountryCode.FormattingEnabled = True
        Me.cmbResCountryCode.Location = New System.Drawing.Point(151, 233)
        Me.cmbResCountryCode.Name = "cmbResCountryCode"
        Me.cmbResCountryCode.Size = New System.Drawing.Size(531, 23)
        Me.cmbResCountryCode.TabIndex = 20
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 236)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(111, 15)
        Me.Label9.TabIndex = 19
        Me.Label9.Text = "Res Country Code:"
        '
        'cmbCPType
        '
        Me.cmbCPType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCPType.FormattingEnabled = True
        Me.cmbCPType.Location = New System.Drawing.Point(151, 204)
        Me.cmbCPType.Name = "cmbCPType"
        Me.cmbCPType.Size = New System.Drawing.Size(531, 23)
        Me.cmbCPType.TabIndex = 18
        '
        'lblCPType
        '
        Me.lblCPType.AutoSize = True
        Me.lblCPType.Location = New System.Drawing.Point(6, 207)
        Me.lblCPType.Name = "lblCPType"
        Me.lblCPType.Size = New System.Drawing.Size(141, 15)
        Me.lblCPType.TabIndex = 17
        Me.lblCPType.Text = "Controlling Person Type:"
        '
        'cmbAccountHolderType
        '
        Me.cmbAccountHolderType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAccountHolderType.FormattingEnabled = True
        Me.cmbAccountHolderType.Location = New System.Drawing.Point(151, 176)
        Me.cmbAccountHolderType.Name = "cmbAccountHolderType"
        Me.cmbAccountHolderType.Size = New System.Drawing.Size(531, 23)
        Me.cmbAccountHolderType.TabIndex = 16
        '
        'lblAccHolderType
        '
        Me.lblAccHolderType.AutoSize = True
        Me.lblAccHolderType.Location = New System.Drawing.Point(6, 179)
        Me.lblAccHolderType.Name = "lblAccHolderType"
        Me.lblAccHolderType.Size = New System.Drawing.Size(121, 15)
        Me.lblAccHolderType.TabIndex = 15
        Me.lblAccHolderType.Text = "Account Holder Type:"
        '
        'txtLastName
        '
        Me.txtLastName.Location = New System.Drawing.Point(151, 146)
        Me.txtLastName.MaxLength = 58
        Me.txtLastName.Name = "txtLastName"
        Me.txtLastName.Size = New System.Drawing.Size(531, 21)
        Me.txtLastName.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 149)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 15)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Last Name:"
        '
        'txtFirstName
        '
        Me.txtFirstName.Location = New System.Drawing.Point(151, 119)
        Me.txtFirstName.MaxLength = 58
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(531, 21)
        Me.txtFirstName.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 122)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "First Name:"
        '
        'txtClientName
        '
        Me.txtClientName.Enabled = False
        Me.txtClientName.Location = New System.Drawing.Point(151, 89)
        Me.txtClientName.MaxLength = 120
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(531, 21)
        Me.txtClientName.TabIndex = 10
        '
        'lblCRSType
        '
        Me.lblCRSType.AutoSize = True
        Me.lblCRSType.Location = New System.Drawing.Point(148, 65)
        Me.lblCRSType.Name = "lblCRSType"
        Me.lblCRSType.Size = New System.Drawing.Size(94, 15)
        Me.lblCRSType.TabIndex = 9
        Me.lblCRSType.Text = "CRS Type Value"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 65)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 15)
        Me.Label8.TabIndex = 8
        Me.Label8.Text = "CRS Type:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(79, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Client Name:"
        '
        'lblAccountType
        '
        Me.lblAccountType.AutoSize = True
        Me.lblAccountType.Location = New System.Drawing.Point(148, 41)
        Me.lblAccountType.Name = "lblAccountType"
        Me.lblAccountType.Size = New System.Drawing.Size(111, 15)
        Me.lblAccountType.TabIndex = 5
        Me.lblAccountType.Text = "Account Type Value"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Account Type:"
        '
        'lblAccno
        '
        Me.lblAccno.AutoSize = True
        Me.lblAccno.Location = New System.Drawing.Point(148, 17)
        Me.lblAccno.Name = "lblAccno"
        Me.lblAccno.Size = New System.Drawing.Size(131, 15)
        Me.lblAccno.TabIndex = 3
        Me.lblAccno.Text = "Account Number Value"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Account Number:"
        '
        'frmCRSMasterDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 628)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmCRSMasterDetail"
        Me.Text = "CRS Detail"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCRSType As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblAccountType As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblAccno As System.Windows.Forms.Label
    Friend WithEvents txtClientName As ESL.myTextbox
    Friend WithEvents txtLastName As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbAccountHolderType As ESL.myComboBox
    Friend WithEvents lblAccHolderType As System.Windows.Forms.Label
    Friend WithEvents cmbCPType As ESL.myComboBox
    Friend WithEvents lblCPType As System.Windows.Forms.Label
    Friend WithEvents cmbResCountryCode As ESL.myComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbTINIssueBy As ESL.myComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtTIN As ESL.myTextbox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbAddressCountryCode As ESL.myComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents cmbLegalAddressType As ESL.myComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAddressFreeText As ESL.myTextbox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpBirthDate As ESL.myDateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cmbBrithCountryCode As ESL.myComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBrithCity As ESL.myTextbox
    Friend WithEvents Label17 As System.Windows.Forms.Label
End Class
