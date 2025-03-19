<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmClientOptInOut
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
        Me.components = New System.ComponentModel.Container()
        Me.tcClientOptIOMain = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSearchAccName = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtSearchAccNo = New System.Windows.Forms.TextBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvClientMaster = New System.Windows.Forms.DataGridView()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.rbnNo = New System.Windows.Forms.RadioButton()
        Me.rbnYes = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.rbnOptOut = New System.Windows.Forms.RadioButton()
        Me.rbnOptIn = New System.Windows.Forms.RadioButton()
        Me.txtUpdateBy = New ESL.myTextbox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRemark = New ESL.myTextbox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAccNo = New ESL.myTextbox()
        Me.dtpOptIODate = New ESL.myDateTimePicker()
        Me.txtName = New ESL.myTextbox()
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.CachedRptAccIntClsAccDetail1 = New ESL.CachedRptAccIntClsAccDetail()
        Me.acc_no = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acc_ename = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.acc_cname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.branch_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.aeno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ae_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ae_email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.corr_addr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.resid_addr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tel_home = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tel_mobile = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tel_office = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mail_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ac_openDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.last_trade_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suspend_status = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.suspend_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.opt_io_date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.opt_io = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcClientOptIOMain.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvClientMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(718, 377)
        Me.btnCancel.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(666, 377)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Visible = True
        '
        'tcClientOptIOMain
        '
        Me.tcClientOptIOMain.Controls.Add(Me.TabPage1)
        Me.tcClientOptIOMain.Controls.Add(Me.TabPage2)
        Me.tcClientOptIOMain.Location = New System.Drawing.Point(12, 12)
        Me.tcClientOptIOMain.Name = "tcClientOptIOMain"
        Me.tcClientOptIOMain.SelectedIndex = 0
        Me.tcClientOptIOMain.Size = New System.Drawing.Size(764, 358)
        Me.tcClientOptIOMain.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtSearchAccName)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtSearchAccNo)
        Me.TabPage1.Controls.Add(Me.btnSearch)
        Me.TabPage1.Controls.Add(Me.dgvClientMaster)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(756, 330)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Client Master"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(191, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Account Name"
        '
        'txtSearchAccName
        '
        Me.txtSearchAccName.Location = New System.Drawing.Point(281, 7)
        Me.txtSearchAccName.Name = "txtSearchAccName"
        Me.txtSearchAccName.Size = New System.Drawing.Size(100, 21)
        Me.txtSearchAccName.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Account No."
        '
        'txtSearchAccNo
        '
        Me.txtSearchAccNo.Location = New System.Drawing.Point(84, 8)
        Me.txtSearchAccNo.Name = "txtSearchAccNo"
        Me.txtSearchAccNo.Size = New System.Drawing.Size(100, 21)
        Me.txtSearchAccNo.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(389, 6)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvClientMaster
        '
        Me.dgvClientMaster.AllowUserToAddRows = False
        Me.dgvClientMaster.AllowUserToDeleteRows = False
        Me.dgvClientMaster.AllowUserToResizeRows = False
        Me.dgvClientMaster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.acc_no, Me.acc_ename, Me.acc_cname, Me.branch_name, Me.aeno, Me.ae_name, Me.ae_email, Me.corr_addr, Me.resid_addr, Me.tel_home, Me.tel_mobile, Me.tel_office, Me.email, Me.mail_status, Me.ac_openDate, Me.last_trade_date, Me.suspend_status, Me.suspend_date, Me.opt_io_date, Me.opt_io})
        Me.dgvClientMaster.Location = New System.Drawing.Point(6, 40)
        Me.dgvClientMaster.MultiSelect = False
        Me.dgvClientMaster.Name = "dgvClientMaster"
        Me.dgvClientMaster.ReadOnly = True
        Me.dgvClientMaster.RowHeadersVisible = False
        Me.dgvClientMaster.RowTemplate.Height = 24
        Me.dgvClientMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvClientMaster.Size = New System.Drawing.Size(746, 284)
        Me.dgvClientMaster.TabIndex = 0
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Controls.Add(Me.Panel1)
        Me.TabPage2.Controls.Add(Me.txtUpdateBy)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.txtRemark)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.txtAccNo)
        Me.TabPage2.Controls.Add(Me.dtpOptIODate)
        Me.TabPage2.Controls.Add(Me.txtName)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(756, 330)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Modification"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbnNo)
        Me.Panel2.Controls.Add(Me.rbnYes)
        Me.Panel2.Location = New System.Drawing.Point(201, 171)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(151, 22)
        Me.Panel2.TabIndex = 19
        '
        'rbnNo
        '
        Me.rbnNo.AutoSize = True
        Me.rbnNo.Location = New System.Drawing.Point(56, 0)
        Me.rbnNo.Name = "rbnNo"
        Me.rbnNo.Size = New System.Drawing.Size(41, 19)
        Me.rbnNo.TabIndex = 17
        Me.rbnNo.TabStop = True
        Me.rbnNo.Text = "No"
        Me.rbnNo.UseVisualStyleBackColor = True
        '
        'rbnYes
        '
        Me.rbnYes.AutoSize = True
        Me.rbnYes.Location = New System.Drawing.Point(4, 0)
        Me.rbnYes.Name = "rbnYes"
        Me.rbnYes.Size = New System.Drawing.Size(45, 19)
        Me.rbnYes.TabIndex = 16
        Me.rbnYes.TabStop = True
        Me.rbnYes.Text = "Yes"
        Me.rbnYes.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbnOptOut)
        Me.Panel1.Controls.Add(Me.rbnOptIn)
        Me.Panel1.Location = New System.Drawing.Point(201, 132)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(136, 22)
        Me.Panel1.TabIndex = 18
        '
        'rbnOptOut
        '
        Me.rbnOptOut.AutoSize = True
        Me.rbnOptOut.Location = New System.Drawing.Point(67, 2)
        Me.rbnOptOut.Name = "rbnOptOut"
        Me.rbnOptOut.Size = New System.Drawing.Size(65, 19)
        Me.rbnOptOut.TabIndex = 15
        Me.rbnOptOut.TabStop = True
        Me.rbnOptOut.Text = "Opt-out"
        Me.rbnOptOut.UseVisualStyleBackColor = True
        '
        'rbnOptIn
        '
        Me.rbnOptIn.AutoSize = True
        Me.rbnOptIn.Location = New System.Drawing.Point(3, 2)
        Me.rbnOptIn.Name = "rbnOptIn"
        Me.rbnOptIn.Size = New System.Drawing.Size(58, 19)
        Me.rbnOptIn.TabIndex = 14
        Me.rbnOptIn.TabStop = True
        Me.rbnOptIn.Text = "Opt-in"
        Me.rbnOptIn.UseVisualStyleBackColor = True
        '
        'txtUpdateBy
        '
        Me.txtUpdateBy.Enabled = False
        Me.txtUpdateBy.Location = New System.Drawing.Point(201, 288)
        Me.txtUpdateBy.Name = "txtUpdateBy"
        Me.txtUpdateBy.Size = New System.Drawing.Size(100, 21)
        Me.txtUpdateBy.TabIndex = 13
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(20, 288)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 15)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Update By"
        '
        'txtRemark
        '
        Me.txtRemark.Location = New System.Drawing.Point(201, 205)
        Me.txtRemark.Multiline = True
        Me.txtRemark.Name = "txtRemark"
        Me.txtRemark.Size = New System.Drawing.Size(280, 70)
        Me.txtRemark.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(20, 208)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 15)
        Me.Label6.TabIndex = 10
        Me.Label6.Text = "Remark"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(20, 171)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(158, 15)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Opt-out on account opening"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 132)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Opt-in/out"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(89, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Opt-in/out Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(140, 15)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Account Name (English)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Account No."
        '
        'txtAccNo
        '
        Me.txtAccNo.Location = New System.Drawing.Point(201, 20)
        Me.txtAccNo.Name = "txtAccNo"
        Me.txtAccNo.Size = New System.Drawing.Size(100, 21)
        Me.txtAccNo.TabIndex = 0
        '
        'dtpOptIODate
        '
        Me.dtpOptIODate.Location = New System.Drawing.Point(201, 93)
        Me.dtpOptIODate.Name = "dtpOptIODate"
        Me.dtpOptIODate.Size = New System.Drawing.Size(200, 21)
        Me.dtpOptIODate.TabIndex = 3
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(201, 56)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(200, 21)
        Me.txtName.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
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
        Me.btnEdit.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(562, 377)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'acc_no
        '
        Me.acc_no.DataPropertyName = "accno"
        Me.acc_no.HeaderText = "Account No."
        Me.acc_no.Name = "acc_no"
        Me.acc_no.ReadOnly = True
        '
        'acc_ename
        '
        Me.acc_ename.DataPropertyName = "name_1"
        Me.acc_ename.HeaderText = "Account Name (English)"
        Me.acc_ename.Name = "acc_ename"
        Me.acc_ename.ReadOnly = True
        '
        'acc_cname
        '
        Me.acc_cname.DataPropertyName = "name_1_c"
        Me.acc_cname.HeaderText = "Account Name (Chinese)"
        Me.acc_cname.Name = "acc_cname"
        Me.acc_cname.ReadOnly = True
        '
        'branch_name
        '
        Me.branch_name.DataPropertyName = "branch_name"
        Me.branch_name.HeaderText = "Branch"
        Me.branch_name.Name = "branch_name"
        Me.branch_name.ReadOnly = True
        '
        'aeno
        '
        Me.aeno.DataPropertyName = "aeno"
        Me.aeno.HeaderText = "Runner Code"
        Me.aeno.Name = "aeno"
        Me.aeno.ReadOnly = True
        '
        'ae_name
        '
        Me.ae_name.DataPropertyName = "ae_name"
        Me.ae_name.HeaderText = "AE Name"
        Me.ae_name.Name = "ae_name"
        Me.ae_name.ReadOnly = True
        '
        'ae_email
        '
        Me.ae_email.DataPropertyName = "ae_email"
        Me.ae_email.HeaderText = "AE Email"
        Me.ae_email.Name = "ae_email"
        Me.ae_email.ReadOnly = True
        '
        'corr_addr
        '
        Me.corr_addr.DataPropertyName = "addr_1"
        Me.corr_addr.HeaderText = "Correspondence Address"
        Me.corr_addr.Name = "corr_addr"
        Me.corr_addr.ReadOnly = True
        '
        'resid_addr
        '
        Me.resid_addr.DataPropertyName = "nd_addr_1"
        Me.resid_addr.HeaderText = "Residential Address"
        Me.resid_addr.Name = "resid_addr"
        Me.resid_addr.ReadOnly = True
        '
        'tel_home
        '
        Me.tel_home.DataPropertyName = "phone_1"
        Me.tel_home.HeaderText = "Tel (Home)"
        Me.tel_home.Name = "tel_home"
        Me.tel_home.ReadOnly = True
        '
        'tel_mobile
        '
        Me.tel_mobile.DataPropertyName = "phone_2"
        Me.tel_mobile.HeaderText = "Tel (Mobile)"
        Me.tel_mobile.Name = "tel_mobile"
        Me.tel_mobile.ReadOnly = True
        '
        'tel_office
        '
        Me.tel_office.DataPropertyName = "phone_3"
        Me.tel_office.HeaderText = "Tel (Office)"
        Me.tel_office.Name = "tel_office"
        Me.tel_office.ReadOnly = True
        '
        'email
        '
        Me.email.DataPropertyName = "email"
        Me.email.HeaderText = "Email Address"
        Me.email.Name = "email"
        Me.email.ReadOnly = True
        '
        'mail_status
        '
        Me.mail_status.DataPropertyName = "mail_status"
        Me.mail_status.HeaderText = "Mail Status"
        Me.mail_status.Name = "mail_status"
        Me.mail_status.ReadOnly = True
        '
        'ac_openDate
        '
        Me.ac_openDate.DataPropertyName = "date_open"
        Me.ac_openDate.HeaderText = "A/C Open Date"
        Me.ac_openDate.Name = "ac_openDate"
        Me.ac_openDate.ReadOnly = True
        '
        'last_trade_date
        '
        Me.last_trade_date.DataPropertyName = "Last_tran_date"
        Me.last_trade_date.HeaderText = "Last Trade Date"
        Me.last_trade_date.Name = "last_trade_date"
        Me.last_trade_date.ReadOnly = True
        '
        'suspend_status
        '
        Me.suspend_status.DataPropertyName = "suspend_field"
        Me.suspend_status.HeaderText = "Suspend Status"
        Me.suspend_status.Name = "suspend_status"
        Me.suspend_status.ReadOnly = True
        '
        'suspend_date
        '
        Me.suspend_date.DataPropertyName = "date_close"
        Me.suspend_date.HeaderText = "Suspend Date"
        Me.suspend_date.Name = "suspend_date"
        Me.suspend_date.ReadOnly = True
        '
        'opt_io_date
        '
        Me.opt_io_date.DataPropertyName = "opt_in_out_date"
        Me.opt_io_date.HeaderText = "Opt-in/out Date"
        Me.opt_io_date.Name = "opt_io_date"
        Me.opt_io_date.ReadOnly = True
        '
        'opt_io
        '
        Me.opt_io.DataPropertyName = "opt_in_out"
        Me.opt_io.HeaderText = "Opt-in/out"
        Me.opt_io.Name = "opt_io"
        Me.opt_io.ReadOnly = True
        '
        'FrmClientOptInOut
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(784, 444)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.tcClientOptIOMain)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.KeyPreview = True
        Me.Name = "FrmClientOptInOut"
        Me.Text = "Client Opt-in/out"
        Me.Controls.SetChildIndex(Me.tcClientOptIOMain, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.tcClientOptIOMain.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvClientMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tcClientOptIOMain As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvClientMaster As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAccNo As ESL.myTextbox
    Friend WithEvents dtpOptIODate As ESL.myDateTimePicker
    Friend WithEvents txtName As ESL.myTextbox
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents CachedRptAccIntClsAccDetail1 As ESL.CachedRptAccIntClsAccDetail
    Friend WithEvents txtRemark As ESL.myTextbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtUpdateBy As ESL.myTextbox
    Friend WithEvents rbnOptIn As System.Windows.Forms.RadioButton
    Friend WithEvents rbnNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbnYes As System.Windows.Forms.RadioButton
    Friend WithEvents rbnOptOut As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSearchAccName As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSearchAccNo As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents acc_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_ename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_cname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents branch_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aeno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents corr_addr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents resid_addr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tel_home As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tel_mobile As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tel_office As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mail_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ac_openDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents last_trade_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents suspend_status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents suspend_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents opt_io_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents opt_io As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
