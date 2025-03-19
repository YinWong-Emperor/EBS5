<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFuturesOPAlertMaster
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.TabControl = New System.Windows.Forms.TabControl
        Me.TabMaster = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtgOPAlert = New System.Windows.Forms.DataGridView
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboMarket = New ESL.myComboBox(Me.components)
        Me.txtProductName = New ESL.myTextbox
        Me.txtProductCode = New ESL.myTextbox
        Me.btnEnquiry = New ESL.myButton(Me.components)
        Me.TabMail = New System.Windows.Forms.TabPage
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEmail = New ESL.myTextbox
        Me.btnRefresh = New ESL.myButton(Me.components)
        Me.btnDel = New ESL.myButton(Me.components)
        Me.DtgMail = New System.Windows.Forms.DataGridView
        Me.dtgEmail = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnModify = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.TpErrorReport = New System.Windows.Forms.TabPage
        Me.lblProcess = New System.Windows.Forms.Label
        Me.txtSysDate = New ESL.myTextbox
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.Panel4 = New System.Windows.Forms.Panel
        Me.Label9 = New System.Windows.Forms.Label
        Me.RBErrRpt = New ESL.myRadioButton(Me.components)
        Me.RBFullRpt = New ESL.myRadioButton(Me.components)
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.Label10 = New System.Windows.Forms.Label
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.btnErrEnq = New ESL.myButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtParty = New ESL.myTextbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtRptProduct = New ESL.myTextbox
        Me.DtgErrorReport = New System.Windows.Forms.DataGridView
        Me.dtgCounterParty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgProduct = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgCallPut = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgPositLimit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgPositLimit2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgError = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.RBError = New ESL.myRadioButton(Me.components)
        Me.RBAll = New ESL.myRadioButton(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.dtgProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgProductName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgMarket = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgCboGrossNet = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.dtgPositionLimit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgAlert = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.dtgPositionLimit2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgAlert2 = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.month_alert = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.TabControl.SuspendLayout()
        Me.TabMaster.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgOPAlert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabMail.SuspendLayout()
        CType(Me.DtgMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TpErrorReport.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.DtgErrorReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(706, 444)
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(654, 444)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Visible = True
        '
        'TabControl
        '
        Me.TabControl.Controls.Add(Me.TabMaster)
        Me.TabControl.Controls.Add(Me.TabMail)
        Me.TabControl.Controls.Add(Me.TpErrorReport)
        Me.TabControl.Location = New System.Drawing.Point(4, 4)
        Me.TabControl.Name = "TabControl"
        Me.TabControl.SelectedIndex = 0
        Me.TabControl.Size = New System.Drawing.Size(762, 506)
        Me.TabControl.TabIndex = 0
        '
        'TabMaster
        '
        Me.TabMaster.BackColor = System.Drawing.Color.Linen
        Me.TabMaster.Controls.Add(Me.Panel1)
        Me.TabMaster.Controls.Add(Me.btnEdit)
        Me.TabMaster.Controls.Add(Me.Label4)
        Me.TabMaster.Controls.Add(Me.Label3)
        Me.TabMaster.Controls.Add(Me.Label2)
        Me.TabMaster.Controls.Add(Me.cboMarket)
        Me.TabMaster.Controls.Add(Me.txtProductName)
        Me.TabMaster.Controls.Add(Me.txtProductCode)
        Me.TabMaster.Controls.Add(Me.btnEnquiry)
        Me.TabMaster.Location = New System.Drawing.Point(4, 24)
        Me.TabMaster.Name = "TabMaster"
        Me.TabMaster.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMaster.Size = New System.Drawing.Size(754, 478)
        Me.TabMaster.TabIndex = 0
        Me.TabMaster.Text = "Position Master"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtgOPAlert)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Panel1.Location = New System.Drawing.Point(3, 45)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(745, 367)
        Me.Panel1.TabIndex = 4
        '
        'dtgOPAlert
        '
        Me.dtgOPAlert.AllowUserToAddRows = False
        Me.dtgOPAlert.AllowUserToDeleteRows = False
        Me.dtgOPAlert.AllowUserToResizeRows = False
        Me.dtgOPAlert.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgOPAlert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgOPAlert.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtgProductCode, Me.dtgProductName, Me.dtgMarket, Me.dtgCboGrossNet, Me.dtgPositionLimit, Me.dtgAlert, Me.dtgPositionLimit2, Me.dtgAlert2, Me.month_alert})
        Me.dtgOPAlert.Location = New System.Drawing.Point(2, 0)
        Me.dtgOPAlert.MultiSelect = False
        Me.dtgOPAlert.Name = "dtgOPAlert"
        Me.dtgOPAlert.RowHeadersVisible = False
        Me.dtgOPAlert.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgOPAlert.RowTemplate.Height = 24
        Me.dtgOPAlert.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgOPAlert.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgOPAlert.Size = New System.Drawing.Size(740, 364)
        Me.dtgOPAlert.TabIndex = 0
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(4, 418)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(56, 20)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 3)
        Me.Label4.Margin = New System.Windows.Forms.Padding(0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(82, 15)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Product Code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(115, 3)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Product Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(224, 3)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Market"
        '
        'cboMarket
        '
        Me.cboMarket.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMarket.FormattingEnabled = True
        Me.cboMarket.Location = New System.Drawing.Point(227, 18)
        Me.cboMarket.Name = "cboMarket"
        Me.cboMarket.Size = New System.Drawing.Size(285, 23)
        Me.cboMarket.TabIndex = 2
        '
        'txtProductName
        '
        Me.txtProductName.Location = New System.Drawing.Point(118, 18)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(100, 21)
        Me.txtProductName.TabIndex = 1
        '
        'txtProductCode
        '
        Me.txtProductCode.Location = New System.Drawing.Point(9, 18)
        Me.txtProductCode.Name = "txtProductCode"
        Me.txtProductCode.Size = New System.Drawing.Size(100, 21)
        Me.txtProductCode.TabIndex = 0
        '
        'btnEnquiry
        '
        Me.btnEnquiry.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnEnquiry.Location = New System.Drawing.Point(649, 17)
        Me.btnEnquiry.Name = "btnEnquiry"
        Me.btnEnquiry.Size = New System.Drawing.Size(99, 25)
        Me.btnEnquiry.TabIndex = 3
        Me.btnEnquiry.Text = "Enquiry"
        Me.btnEnquiry.UseVisualStyleBackColor = True
        '
        'TabMail
        '
        Me.TabMail.BackColor = System.Drawing.Color.Linen
        Me.TabMail.Controls.Add(Me.Label5)
        Me.TabMail.Controls.Add(Me.txtEmail)
        Me.TabMail.Controls.Add(Me.btnRefresh)
        Me.TabMail.Controls.Add(Me.btnDel)
        Me.TabMail.Controls.Add(Me.DtgMail)
        Me.TabMail.Controls.Add(Me.btnModify)
        Me.TabMail.Controls.Add(Me.btnAdd)
        Me.TabMail.Location = New System.Drawing.Point(4, 24)
        Me.TabMail.Name = "TabMail"
        Me.TabMail.Padding = New System.Windows.Forms.Padding(3)
        Me.TabMail.Size = New System.Drawing.Size(754, 478)
        Me.TabMail.TabIndex = 1
        Me.TabMail.Text = "Alert Mail List"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(180, 340)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(88, 15)
        Me.Label5.TabIndex = 22
        Me.Label5.Text = "Email Address"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(183, 358)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(315, 21)
        Me.txtEmail.TabIndex = 2
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(454, 394)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(84, 23)
        Me.btnRefresh.TabIndex = 1
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        Me.btnRefresh.Visible = False
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(364, 394)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(84, 23)
        Me.btnDel.TabIndex = 5
        Me.btnDel.Text = "Delete"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'DtgMail
        '
        Me.DtgMail.AllowUserToAddRows = False
        Me.DtgMail.AllowUserToDeleteRows = False
        Me.DtgMail.BackgroundColor = System.Drawing.Color.Linen
        Me.DtgMail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtgMail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtgEmail})
        Me.DtgMail.Location = New System.Drawing.Point(183, 19)
        Me.DtgMail.MultiSelect = False
        Me.DtgMail.Name = "DtgMail"
        Me.DtgMail.ReadOnly = True
        Me.DtgMail.RowHeadersVisible = False
        Me.DtgMail.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.DtgMail.RowTemplate.Height = 24
        Me.DtgMail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtgMail.Size = New System.Drawing.Size(315, 318)
        Me.DtgMail.TabIndex = 0
        '
        'dtgEmail
        '
        Me.dtgEmail.DataPropertyName = "Email"
        Me.dtgEmail.HeaderText = "Email Address"
        Me.dtgEmail.Name = "dtgEmail"
        Me.dtgEmail.ReadOnly = True
        Me.dtgEmail.Width = 300
        '
        'btnModify
        '
        Me.btnModify.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnModify.Location = New System.Drawing.Point(274, 394)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(84, 23)
        Me.btnModify.TabIndex = 4
        Me.btnModify.Text = "Adjust"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(182, 394)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 23)
        Me.btnAdd.TabIndex = 3
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'TpErrorReport
        '
        Me.TpErrorReport.BackColor = System.Drawing.Color.Linen
        Me.TpErrorReport.Controls.Add(Me.lblProcess)
        Me.TpErrorReport.Controls.Add(Me.txtSysDate)
        Me.TpErrorReport.Controls.Add(Me.pbarPrint)
        Me.TpErrorReport.Controls.Add(Me.Label8)
        Me.TpErrorReport.Controls.Add(Me.GroupBox2)
        Me.TpErrorReport.Controls.Add(Me.btnErrEnq)
        Me.TpErrorReport.Controls.Add(Me.Label7)
        Me.TpErrorReport.Controls.Add(Me.txtParty)
        Me.TpErrorReport.Controls.Add(Me.Label6)
        Me.TpErrorReport.Controls.Add(Me.txtRptProduct)
        Me.TpErrorReport.Controls.Add(Me.DtgErrorReport)
        Me.TpErrorReport.Controls.Add(Me.Panel2)
        Me.TpErrorReport.Location = New System.Drawing.Point(4, 24)
        Me.TpErrorReport.Name = "TpErrorReport"
        Me.TpErrorReport.Padding = New System.Windows.Forms.Padding(3)
        Me.TpErrorReport.Size = New System.Drawing.Size(754, 478)
        Me.TpErrorReport.TabIndex = 2
        Me.TpErrorReport.Text = "Report"
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(47, 416)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 35
        Me.lblProcess.Text = "Processing"
        '
        'txtSysDate
        '
        Me.txtSysDate.Location = New System.Drawing.Point(266, 34)
        Me.txtSysDate.Name = "txtSysDate"
        Me.txtSysDate.ReadOnly = True
        Me.txtSysDate.Size = New System.Drawing.Size(111, 21)
        Me.txtSysDate.TabIndex = 11
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(47, 434)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(316, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 34
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(263, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 15)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Trade Date"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnPrint)
        Me.GroupBox2.Controls.Add(Me.Panel4)
        Me.GroupBox2.Controls.Add(Me.Panel3)
        Me.GroupBox2.Location = New System.Drawing.Point(41, 325)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(604, 87)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(445, 54)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(89, 23)
        Me.btnPrint.TabIndex = 4
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.RBErrRpt)
        Me.Panel4.Controls.Add(Me.RBFullRpt)
        Me.Panel4.Location = New System.Drawing.Point(6, 20)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(316, 35)
        Me.Panel4.TabIndex = 3
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Report Detail:"
        '
        'RBErrRpt
        '
        Me.RBErrRpt.AutoSize = True
        Me.RBErrRpt.Location = New System.Drawing.Point(195, 8)
        Me.RBErrRpt.Name = "RBErrRpt"
        Me.RBErrRpt.Size = New System.Drawing.Size(78, 19)
        Me.RBErrRpt.TabIndex = 1
        Me.RBErrRpt.Text = "Summary"
        Me.RBErrRpt.UseVisualStyleBackColor = True
        '
        'RBFullRpt
        '
        Me.RBFullRpt.AutoSize = True
        Me.RBFullRpt.Checked = True
        Me.RBFullRpt.Location = New System.Drawing.Point(104, 8)
        Me.RBFullRpt.Name = "RBFullRpt"
        Me.RBFullRpt.Size = New System.Drawing.Size(85, 19)
        Me.RBFullRpt.TabIndex = 0
        Me.RBFullRpt.TabStop = True
        Me.RBFullRpt.Text = "Full Report"
        Me.RBFullRpt.UseVisualStyleBackColor = True
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Label10)
        Me.Panel3.Controls.Add(Me.RBPrint)
        Me.Panel3.Controls.Add(Me.RBPreview)
        Me.Panel3.Location = New System.Drawing.Point(6, 55)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(316, 30)
        Me.Panel3.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 15)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Print Type:"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(195, 5)
        Me.RBPrint.Name = "RBPrint"
        Me.RBPrint.Size = New System.Drawing.Size(108, 19)
        Me.RBPrint.TabIndex = 1
        Me.RBPrint.Text = "Direct to printer"
        Me.RBPrint.UseVisualStyleBackColor = True
        '
        'RBPreview
        '
        Me.RBPreview.AutoSize = True
        Me.RBPreview.Checked = True
        Me.RBPreview.Location = New System.Drawing.Point(104, 5)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'btnErrEnq
        '
        Me.btnErrEnq.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnErrEnq.Location = New System.Drawing.Point(561, 33)
        Me.btnErrEnq.Name = "btnErrEnq"
        Me.btnErrEnq.Size = New System.Drawing.Size(84, 23)
        Me.btnErrEnq.TabIndex = 5
        Me.btnErrEnq.Text = "Enquiry"
        Me.btnErrEnq.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(38, 16)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Counter Party"
        '
        'txtParty
        '
        Me.txtParty.Location = New System.Drawing.Point(41, 33)
        Me.txtParty.Name = "txtParty"
        Me.txtParty.Size = New System.Drawing.Size(104, 21)
        Me.txtParty.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(148, 16)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Product Code"
        '
        'txtRptProduct
        '
        Me.txtRptProduct.Location = New System.Drawing.Point(151, 33)
        Me.txtRptProduct.Name = "txtRptProduct"
        Me.txtRptProduct.Size = New System.Drawing.Size(103, 21)
        Me.txtRptProduct.TabIndex = 1
        '
        'DtgErrorReport
        '
        Me.DtgErrorReport.AllowUserToAddRows = False
        Me.DtgErrorReport.AllowUserToDeleteRows = False
        Me.DtgErrorReport.BackgroundColor = System.Drawing.Color.Linen
        Me.DtgErrorReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtgErrorReport.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtgCounterParty, Me.dtgProduct, Me.dtgCallPut, Me.dtgPositLimit, Me.dtgPositLimit2, Me.dtgQty, Me.dtgError})
        Me.DtgErrorReport.Location = New System.Drawing.Point(24, 59)
        Me.DtgErrorReport.Name = "DtgErrorReport"
        Me.DtgErrorReport.ReadOnly = True
        Me.DtgErrorReport.RowHeadersVisible = False
        Me.DtgErrorReport.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DtgErrorReport.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.DtgErrorReport.RowTemplate.Height = 24
        Me.DtgErrorReport.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtgErrorReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtgErrorReport.Size = New System.Drawing.Size(712, 259)
        Me.DtgErrorReport.TabIndex = 0
        '
        'dtgCounterParty
        '
        Me.dtgCounterParty.DataPropertyName = "counterparty"
        Me.dtgCounterParty.HeaderText = "Counter Party"
        Me.dtgCounterParty.Name = "dtgCounterParty"
        Me.dtgCounterParty.ReadOnly = True
        Me.dtgCounterParty.Width = 120
        '
        'dtgProduct
        '
        Me.dtgProduct.DataPropertyName = "code"
        Me.dtgProduct.HeaderText = "Product"
        Me.dtgProduct.Name = "dtgProduct"
        Me.dtgProduct.ReadOnly = True
        '
        'dtgCallPut
        '
        Me.dtgCallPut.DataPropertyName = "cal_type"
        Me.dtgCallPut.HeaderText = "Net / Gross"
        Me.dtgCallPut.Name = "dtgCallPut"
        Me.dtgCallPut.ReadOnly = True
        Me.dtgCallPut.Width = 130
        '
        'dtgPositLimit
        '
        Me.dtgPositLimit.DataPropertyName = "position_limit"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dtgPositLimit.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgPositLimit.HeaderText = "Position Limit 1"
        Me.dtgPositLimit.Name = "dtgPositLimit"
        Me.dtgPositLimit.ReadOnly = True
        Me.dtgPositLimit.Width = 120
        '
        'dtgPositLimit2
        '
        Me.dtgPositLimit2.DataPropertyName = "position_limit_2"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dtgPositLimit2.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgPositLimit2.HeaderText = "Position Limit 2"
        Me.dtgPositLimit2.Name = "dtgPositLimit2"
        Me.dtgPositLimit2.ReadOnly = True
        Me.dtgPositLimit2.Width = 120
        '
        'dtgQty
        '
        Me.dtgQty.DataPropertyName = "qty"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dtgQty.DefaultCellStyle = DataGridViewCellStyle5
        Me.dtgQty.HeaderText = "Quantity"
        Me.dtgQty.Name = "dtgQty"
        Me.dtgQty.ReadOnly = True
        Me.dtgQty.Width = 80
        '
        'dtgError
        '
        Me.dtgError.DataPropertyName = "diff"
        Me.dtgError.HeaderText = ""
        Me.dtgError.Name = "dtgError"
        Me.dtgError.ReadOnly = True
        Me.dtgError.Visible = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.RBError)
        Me.Panel2.Controls.Add(Me.RBAll)
        Me.Panel2.Location = New System.Drawing.Point(394, 29)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(147, 24)
        Me.Panel2.TabIndex = 6
        '
        'RBError
        '
        Me.RBError.AutoSize = True
        Me.RBError.Checked = True
        Me.RBError.Location = New System.Drawing.Point(44, 3)
        Me.RBError.Name = "RBError"
        Me.RBError.Size = New System.Drawing.Size(92, 19)
        Me.RBError.TabIndex = 1
        Me.RBError.TabStop = True
        Me.RBError.Text = "Exceed Only"
        Me.RBError.UseVisualStyleBackColor = True
        '
        'RBAll
        '
        Me.RBAll.AutoSize = True
        Me.RBAll.Location = New System.Drawing.Point(3, 3)
        Me.RBAll.Name = "RBAll"
        Me.RBAll.Size = New System.Drawing.Size(38, 19)
        Me.RBAll.TabIndex = 0
        Me.RBAll.Text = "All"
        Me.RBAll.UseVisualStyleBackColor = True
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'dtgProductCode
        '
        Me.dtgProductCode.DataPropertyName = "Product_code"
        Me.dtgProductCode.HeaderText = "Product"
        Me.dtgProductCode.Name = "dtgProductCode"
        Me.dtgProductCode.Width = 80
        '
        'dtgProductName
        '
        Me.dtgProductName.DataPropertyName = "Product_name"
        Me.dtgProductName.HeaderText = "Name"
        Me.dtgProductName.Name = "dtgProductName"
        '
        'dtgMarket
        '
        Me.dtgMarket.DataPropertyName = "Market"
        Me.dtgMarket.HeaderText = "Market"
        Me.dtgMarket.Name = "dtgMarket"
        '
        'dtgCboGrossNet
        '
        Me.dtgCboGrossNet.DataPropertyName = "gross_net"
        Me.dtgCboGrossNet.HeaderText = "Gross / Net"
        Me.dtgCboGrossNet.Items.AddRange(New Object() {"Gross", "Net"})
        Me.dtgCboGrossNet.Name = "dtgCboGrossNet"
        Me.dtgCboGrossNet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dtgCboGrossNet.Width = 60
        '
        'dtgPositionLimit
        '
        Me.dtgPositionLimit.DataPropertyName = "position_limit"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dtgPositionLimit.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtgPositionLimit.HeaderText = "Position Limit 1"
        Me.dtgPositionLimit.Name = "dtgPositionLimit"
        Me.dtgPositionLimit.Width = 70
        '
        'dtgAlert
        '
        Me.dtgAlert.DataPropertyName = "email_alert"
        Me.dtgAlert.FalseValue = "False"
        Me.dtgAlert.HeaderText = "Email Alert 1"
        Me.dtgAlert.Name = "dtgAlert"
        Me.dtgAlert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dtgAlert.TrueValue = "True"
        Me.dtgAlert.Width = 70
        '
        'dtgPositionLimit2
        '
        Me.dtgPositionLimit2.DataPropertyName = "position_limit_2"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dtgPositionLimit2.DefaultCellStyle = DataGridViewCellStyle2
        Me.dtgPositionLimit2.HeaderText = "Position Limit 2"
        Me.dtgPositionLimit2.Name = "dtgPositionLimit2"
        Me.dtgPositionLimit2.Width = 70
        '
        'dtgAlert2
        '
        Me.dtgAlert2.DataPropertyName = "email_alert_2"
        Me.dtgAlert2.FalseValue = "False"
        Me.dtgAlert2.HeaderText = "Email Alert 2"
        Me.dtgAlert2.Name = "dtgAlert2"
        Me.dtgAlert2.ReadOnly = True
        Me.dtgAlert2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.dtgAlert2.TrueValue = "True"
        Me.dtgAlert2.Width = 70
        '
        'month_alert
        '
        Me.month_alert.DataPropertyName = "month_alert"
        Me.month_alert.FalseValue = "False"
        Me.month_alert.HeaderText = "Month Alert"
        Me.month_alert.Name = "month_alert"
        Me.month_alert.ReadOnly = True
        Me.month_alert.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.month_alert.TrueValue = "True"
        Me.month_alert.Width = 70
        '
        'FrmFuturesOPAlertMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(771, 515)
        Me.Controls.Add(Me.TabControl)
        Me.KeyPreview = True
        Me.Name = "FrmFuturesOPAlertMaster"
        Me.Text = "Futures Open Position Alert Master"
        Me.Controls.SetChildIndex(Me.TabControl, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.TabControl.ResumeLayout(False)
        Me.TabMaster.ResumeLayout(False)
        Me.TabMaster.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtgOPAlert, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabMail.ResumeLayout(False)
        Me.TabMail.PerformLayout()
        CType(Me.DtgMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TpErrorReport.ResumeLayout(False)
        Me.TpErrorReport.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        Me.Panel3.ResumeLayout(False)
        Me.Panel3.PerformLayout()
        CType(Me.DtgErrorReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl As System.Windows.Forms.TabControl
    Friend WithEvents TabMaster As System.Windows.Forms.TabPage
    Friend WithEvents TabMail As System.Windows.Forms.TabPage
    Friend WithEvents dtgOPAlert As System.Windows.Forms.DataGridView
    Friend WithEvents btnDel As ESL.myButton
    Friend WithEvents btnModify As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents cboMarket As ESL.myComboBox
    Friend WithEvents txtProductName As ESL.myTextbox
    Friend WithEvents txtProductCode As ESL.myTextbox
    Friend WithEvents btnEnquiry As ESL.myButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents DtgMail As System.Windows.Forms.DataGridView
    Friend WithEvents btnRefresh As ESL.myButton
    Friend WithEvents txtEmail As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtgEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TpErrorReport As System.Windows.Forms.TabPage
    Friend WithEvents DtgErrorReport As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtRptProduct As ESL.myTextbox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtParty As ESL.myTextbox
    Friend WithEvents btnErrEnq As ESL.myButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents RBError As ESL.myRadioButton
    Friend WithEvents RBAll As ESL.myRadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents RBErrRpt As ESL.myRadioButton
    Friend WithEvents RBFullRpt As ESL.myRadioButton
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSysDate As ESL.myTextbox
    Friend WithEvents dtgCounterParty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgProduct As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgCallPut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgPositLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgPositLimit2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgError As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgMarket As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgCboGrossNet As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents dtgPositionLimit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgAlert As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents dtgPositionLimit2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgAlert2 As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents month_alert As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
