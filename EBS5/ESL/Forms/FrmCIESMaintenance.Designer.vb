<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCIESMaintenance
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
        Me.components = New System.ComponentModel.Container
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.tcCIESMain = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.dgvClientMaster = New System.Windows.Forms.DataGridView
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dtpFaDate = New ESL.myDateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtOpenDeposit = New ESL.myTextbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.cbxPlanCode = New ESL.myComboBox(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtClientCode = New ESL.myTextbox
        Me.txtChargeRate = New ESL.myTextbox
        Me.dtpInitialDate = New ESL.myDateTimePicker
        Me.txtName = New ESL.myTextbox
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.btnRefresh = New ESL.myButton(Me.components)
        Me.btnDel = New ESL.myButton(Me.components)
        Me.btnModify = New ESL.myButton(Me.components)
        Me.btnAlertAdd = New ESL.myButton(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtEmail = New ESL.myTextbox
        Me.DtgMail = New System.Windows.Forms.DataGridView
        Me.dtgEmail = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.CachedRptAccIntClsAccDetail1 = New ESL.CachedRptAccIntClsAccDetail
        Me.clt_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clt_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.plan_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.init_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Charge_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Open_deposit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Fa_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tcCIESMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvClientMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        CType(Me.DtgMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(718, 377)
        Me.btnCancel.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(666, 377)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Visible = True
        '
        'tcCIESMain
        '
        Me.tcCIESMain.Controls.Add(Me.TabPage1)
        Me.tcCIESMain.Controls.Add(Me.TabPage2)
        Me.tcCIESMain.Controls.Add(Me.TabPage3)
        Me.tcCIESMain.Location = New System.Drawing.Point(12, 12)
        Me.tcCIESMain.Name = "tcCIESMain"
        Me.tcCIESMain.SelectedIndex = 0
        Me.tcCIESMain.Size = New System.Drawing.Size(764, 358)
        Me.tcCIESMain.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.dgvClientMaster)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(756, 330)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Client Master"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'dgvClientMaster
        '
        Me.dgvClientMaster.AllowUserToAddRows = False
        Me.dgvClientMaster.AllowUserToDeleteRows = False
        Me.dgvClientMaster.AllowUserToResizeRows = False
        Me.dgvClientMaster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clt_code, Me.clt_name, Me.plan_code, Me.init_date, Me.Charge_rate, Me.Open_deposit, Me.Fa_Date})
        Me.dgvClientMaster.Location = New System.Drawing.Point(6, 6)
        Me.dgvClientMaster.MultiSelect = False
        Me.dgvClientMaster.Name = "dgvClientMaster"
        Me.dgvClientMaster.ReadOnly = True
        Me.dgvClientMaster.RowHeadersVisible = False
        Me.dgvClientMaster.RowTemplate.Height = 24
        Me.dgvClientMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClientMaster.Size = New System.Drawing.Size(746, 318)
        Me.dgvClientMaster.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dtpFaDate)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtOpenDeposit)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cbxPlanCode)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtClientCode)
        Me.TabPage2.Controls.Add(Me.txtChargeRate)
        Me.TabPage2.Controls.Add(Me.dtpInitialDate)
        Me.TabPage2.Controls.Add(Me.txtName)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(756, 330)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Modification"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dtpFaDate
        '
        Me.dtpFaDate.Location = New System.Drawing.Point(118, 253)
        Me.dtpFaDate.Name = "dtpFaDate"
        Me.dtpFaDate.Size = New System.Drawing.Size(200, 21)
        Me.dtpFaDate.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(23, 253)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(50, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "FA Date"
        '
        'txtOpenDeposit
        '
        Me.txtOpenDeposit.Location = New System.Drawing.Point(118, 218)
        Me.txtOpenDeposit.Name = "txtOpenDeposit"
        Me.txtOpenDeposit.Size = New System.Drawing.Size(100, 21)
        Me.txtOpenDeposit.TabIndex = 11
        Me.txtOpenDeposit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(23, 218)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(83, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Open Deposit"
        '
        'cbxPlanCode
        '
        Me.cbxPlanCode.FormattingEnabled = True
        Me.cbxPlanCode.Location = New System.Drawing.Point(118, 106)
        Me.cbxPlanCode.Name = "cbxPlanCode"
        Me.cbxPlanCode.Size = New System.Drawing.Size(121, 23)
        Me.cbxPlanCode.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(23, 183)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(77, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Charge Rate"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 144)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(65, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Initial Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 106)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Plan Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Client Code"
        '
        'txtClientCode
        '
        Me.txtClientCode.Location = New System.Drawing.Point(118, 33)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(100, 21)
        Me.txtClientCode.TabIndex = 0
        '
        'txtChargeRate
        '
        Me.txtChargeRate.Location = New System.Drawing.Point(118, 183)
        Me.txtChargeRate.Name = "txtChargeRate"
        Me.txtChargeRate.Size = New System.Drawing.Size(100, 21)
        Me.txtChargeRate.TabIndex = 4
        Me.txtChargeRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpInitialDate
        '
        Me.dtpInitialDate.Location = New System.Drawing.Point(118, 144)
        Me.dtpInitialDate.Name = "dtpInitialDate"
        Me.dtpInitialDate.Size = New System.Drawing.Size(200, 21)
        Me.dtpInitialDate.TabIndex = 3
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(118, 69)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(200, 21)
        Me.txtName.TabIndex = 1
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.btnRefresh)
        Me.TabPage3.Controls.Add(Me.btnDel)
        Me.TabPage3.Controls.Add(Me.btnModify)
        Me.TabPage3.Controls.Add(Me.btnAlertAdd)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.txtEmail)
        Me.TabPage3.Controls.Add(Me.DtgMail)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(756, 330)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Alert Mail List"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(429, 287)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(84, 23)
        Me.btnRefresh.TabIndex = 30
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        Me.btnRefresh.Visible = False
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(339, 287)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(84, 23)
        Me.btnDel.TabIndex = 33
        Me.btnDel.Text = "Delete"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnModify
        '
        Me.btnModify.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnModify.Location = New System.Drawing.Point(249, 287)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(84, 23)
        Me.btnModify.TabIndex = 32
        Me.btnModify.Text = "Adjust"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnAlertAdd
        '
        Me.btnAlertAdd.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAlertAdd.Location = New System.Drawing.Point(157, 287)
        Me.btnAlertAdd.Name = "btnAlertAdd"
        Me.btnAlertAdd.Size = New System.Drawing.Size(84, 23)
        Me.btnAlertAdd.TabIndex = 31
        Me.btnAlertAdd.Text = "Add"
        Me.btnAlertAdd.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(154, 242)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 15)
        Me.Label8.TabIndex = 29
        Me.Label8.Text = "Email Address"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(157, 260)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(315, 21)
        Me.txtEmail.TabIndex = 25
        '
        'DtgMail
        '
        Me.DtgMail.AllowUserToAddRows = False
        Me.DtgMail.AllowUserToDeleteRows = False
        Me.DtgMail.BackgroundColor = System.Drawing.Color.Linen
        Me.DtgMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtgMail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtgEmail})
        Me.DtgMail.Location = New System.Drawing.Point(157, 6)
        Me.DtgMail.MultiSelect = False
        Me.DtgMail.Name = "DtgMail"
        Me.DtgMail.ReadOnly = True
        Me.DtgMail.RowHeadersVisible = False
        Me.DtgMail.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.DtgMail.RowTemplate.Height = 24
        Me.DtgMail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtgMail.Size = New System.Drawing.Size(315, 233)
        Me.DtgMail.TabIndex = 23
        '
        'dtgEmail
        '
        Me.dtgEmail.DataPropertyName = "Email"
        Me.dtgEmail.HeaderText = "Email Address"
        Me.dtgEmail.Name = "dtgEmail"
        Me.dtgEmail.ReadOnly = True
        Me.dtgEmail.Width = 300
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(613, 377)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(511, 377)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(562, 377)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'clt_code
        '
        Me.clt_code.DataPropertyName = "clt_code"
        Me.clt_code.HeaderText = "Client Code"
        Me.clt_code.Name = "clt_code"
        Me.clt_code.ReadOnly = True
        '
        'clt_name
        '
        Me.clt_name.DataPropertyName = "clt_name"
        Me.clt_name.HeaderText = "Name"
        Me.clt_name.Name = "clt_name"
        Me.clt_name.ReadOnly = True
        Me.clt_name.Width = 150
        '
        'plan_code
        '
        Me.plan_code.DataPropertyName = "plan_code"
        Me.plan_code.HeaderText = "Plan Code"
        Me.plan_code.Name = "plan_code"
        Me.plan_code.ReadOnly = True
        Me.plan_code.Width = 90
        '
        'init_date
        '
        Me.init_date.DataPropertyName = "init_date"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.init_date.DefaultCellStyle = DataGridViewCellStyle1
        Me.init_date.HeaderText = "Initial Date"
        Me.init_date.Name = "init_date"
        Me.init_date.ReadOnly = True
        '
        'Charge_rate
        '
        Me.Charge_rate.DataPropertyName = "Charge_rate"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Charge_rate.DefaultCellStyle = DataGridViewCellStyle2
        Me.Charge_rate.HeaderText = "Charge Rate"
        Me.Charge_rate.Name = "Charge_rate"
        Me.Charge_rate.ReadOnly = True
        '
        'Open_deposit
        '
        Me.Open_deposit.DataPropertyName = "Open_deposit"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.Open_deposit.DefaultCellStyle = DataGridViewCellStyle3
        Me.Open_deposit.HeaderText = "Open Deposit"
        Me.Open_deposit.Name = "Open_deposit"
        Me.Open_deposit.ReadOnly = True
        '
        'Fa_Date
        '
        Me.Fa_Date.DataPropertyName = "fa_date"
        Me.Fa_Date.HeaderText = "FA Date"
        Me.Fa_Date.Name = "Fa_Date"
        Me.Fa_Date.ReadOnly = True
        '
        'FrmCIESMaintenance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(778, 444)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.tcCIESMain)
        Me.KeyPreview = True
        Me.Name = "FrmCIESMaintenance"
        Me.Text = "CIES Maintenance"
        Me.Controls.SetChildIndex(Me.tcCIESMain, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.tcCIESMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        CType(Me.dgvClientMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.DtgMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcCIESMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvClientMaster As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtClientCode As ESL.myTextbox
    Friend WithEvents txtChargeRate As ESL.myTextbox
    Friend WithEvents dtpInitialDate As ESL.myDateTimePicker
    Friend WithEvents txtName As ESL.myTextbox
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents CachedRptAccIntClsAccDetail1 As ESL.CachedRptAccIntClsAccDetail
    Friend WithEvents cbxPlanCode As ESL.myComboBox
    Friend WithEvents txtOpenDeposit As ESL.myTextbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpFaDate As ESL.myDateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As ESL.myTextbox
    Friend WithEvents DtgMail As System.Windows.Forms.DataGridView
    Friend WithEvents dtgEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnRefresh As ESL.myButton
    Friend WithEvents btnDel As ESL.myButton
    Friend WithEvents btnModify As ESL.myButton
    Friend WithEvents btnAlertAdd As ESL.myButton
    Friend WithEvents clt_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clt_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plan_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents init_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Charge_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Open_deposit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fa_Date As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
