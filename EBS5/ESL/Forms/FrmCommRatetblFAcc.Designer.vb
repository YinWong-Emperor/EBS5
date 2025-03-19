<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRatetblFAcc
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnReset = New ESL.myButton(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.comboAccNo = New ESL.myComboBox(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTOFrom = New ESL.myAmountBox
        Me.comboMonth = New ESL.myComboBox(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtAccName = New ESL.myTextbox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.txtSrcAcc = New ESL.myTextbox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.comboProduct = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtProductName = New ESL.myTextbox
        Me.txtNightRate = New ESL.myAmountBox
        Me.txtDayRate = New ESL.myAmountBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RBOption = New ESL.myRadioButton(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.RBFut = New ESL.myRadioButton(Me.components)
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rbNormal = New ESL.myRadioButton(Me.components)
        Me.rbInternet = New ESL.myRadioButton(Me.components)
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtAEName = New ESL.myTextbox
        Me.comboAE = New ESL.myComboBox(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.dtgRateTbl = New System.Windows.Forms.DataGridView
        Me.txtMonth = New ESL.myComboBox(Me.components)
        Me.acc_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fut_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.trade_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acc_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acc_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.product_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rate_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.day_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.night_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.all_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rsid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.dtgRateTbl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(788, 434)
        Me.btnCancel.TabIndex = 17
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(736, 434)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Visible = True
        '
        'btnReset
        '
        Me.btnReset.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReset.Location = New System.Drawing.Point(493, 52)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(88, 24)
        Me.btnReset.TabIndex = 3
        Me.btnReset.Text = "Reset"
        Me.btnReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(399, 52)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(88, 24)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Enquiry"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(676, 434)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(564, 434)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 13
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(620, 434)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 14
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'comboAccNo
        '
        Me.comboAccNo.Enabled = False
        Me.comboAccNo.FormattingEnabled = True
        Me.comboAccNo.Location = New System.Drawing.Point(86, 296)
        Me.comboAccNo.Name = "comboAccNo"
        Me.comboAccNo.Size = New System.Drawing.Size(148, 23)
        Me.comboAccNo.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(11, 358)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 14)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "Month"
        '
        'txtTOFrom
        '
        Me.txtTOFrom.DecimalPoints = 2
        Me.txtTOFrom.Location = New System.Drawing.Point(330, 354)
        Me.txtTOFrom.Name = "txtTOFrom"
        Me.txtTOFrom.Size = New System.Drawing.Size(148, 21)
        Me.txtTOFrom.TabIndex = 10
        Me.txtTOFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'comboMonth
        '
        Me.comboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMonth.FormattingEnabled = True
        Me.comboMonth.Location = New System.Drawing.Point(54, 53)
        Me.comboMonth.Name = "comboMonth"
        Me.comboMonth.Size = New System.Drawing.Size(92, 23)
        Me.comboMonth.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(242, 300)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 14)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "Account Name"
        '
        'txtAccName
        '
        Me.txtAccName.Enabled = False
        Me.txtAccName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccName.Location = New System.Drawing.Point(329, 297)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(258, 20)
        Me.txtAccName.TabIndex = 6
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(133, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(495, 22)
        Me.lblTitle.TabIndex = 104
        Me.lblTitle.Text = "Futures and Options Comm. Rate Table (by Account)"
        '
        'txtSrcAcc
        '
        Me.txtSrcAcc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSrcAcc.Location = New System.Drawing.Point(225, 54)
        Me.txtSrcAcc.Name = "txtSrcAcc"
        Me.txtSrcAcc.Size = New System.Drawing.Size(168, 20)
        Me.txtSrcAcc.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(152, 57)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 14)
        Me.Label8.TabIndex = 106
        Me.Label8.Text = "Account No."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 57)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 14)
        Me.Label6.TabIndex = 103
        Me.Label6.Text = "Month"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(11, 387)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 14)
        Me.Label4.TabIndex = 100
        Me.Label4.Text = "Day rate"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(246, 358)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 14)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Turnover >="
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(11, 300)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 14)
        Me.Label1.TabIndex = 96
        Me.Label1.Text = "Account No."
        '
        'comboProduct
        '
        Me.comboProduct.Enabled = False
        Me.comboProduct.FormattingEnabled = True
        Me.comboProduct.Location = New System.Drawing.Point(86, 325)
        Me.comboProduct.Name = "comboProduct"
        Me.comboProduct.Size = New System.Drawing.Size(148, 23)
        Me.comboProduct.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(11, 329)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 122
        Me.Label2.Text = "Product"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(246, 387)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(53, 14)
        Me.Label7.TabIndex = 125
        Me.Label7.Text = "Night rate"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(246, 329)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 14)
        Me.Label10.TabIndex = 127
        Me.Label10.Text = "Product Name"
        '
        'txtProductName
        '
        Me.txtProductName.Enabled = False
        Me.txtProductName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtProductName.Location = New System.Drawing.Point(330, 326)
        Me.txtProductName.Name = "txtProductName"
        Me.txtProductName.Size = New System.Drawing.Size(258, 20)
        Me.txtProductName.TabIndex = 8
        '
        'txtNightRate
        '
        Me.txtNightRate.DecimalPoints = 2
        Me.txtNightRate.Location = New System.Drawing.Point(330, 383)
        Me.txtNightRate.Name = "txtNightRate"
        Me.txtNightRate.Size = New System.Drawing.Size(148, 21)
        Me.txtNightRate.TabIndex = 12
        Me.txtNightRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDayRate
        '
        Me.txtDayRate.DecimalPoints = 2
        Me.txtDayRate.Location = New System.Drawing.Point(86, 383)
        Me.txtDayRate.Name = "txtDayRate"
        Me.txtDayRate.Size = New System.Drawing.Size(148, 21)
        Me.txtDayRate.TabIndex = 11
        Me.txtDayRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(3, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 14)
        Me.Label13.TabIndex = 160
        Me.Label13.Text = "Trade Type"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RBOption)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.RBFut)
        Me.Panel1.Location = New System.Drawing.Point(593, 324)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(211, 22)
        Me.Panel1.TabIndex = 167
        '
        'RBOption
        '
        Me.RBOption.AutoSize = True
        Me.RBOption.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RBOption.Location = New System.Drawing.Point(148, 3)
        Me.RBOption.Name = "RBOption"
        Me.RBOption.Size = New System.Drawing.Size(56, 18)
        Me.RBOption.TabIndex = 164
        Me.RBOption.Text = "Option"
        Me.RBOption.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(3, 5)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 14)
        Me.Label14.TabIndex = 163
        Me.Label14.Text = "Type"
        '
        'RBFut
        '
        Me.RBFut.AutoSize = True
        Me.RBFut.Checked = True
        Me.RBFut.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.RBFut.Location = New System.Drawing.Point(78, 3)
        Me.RBFut.Name = "RBFut"
        Me.RBFut.Size = New System.Drawing.Size(62, 18)
        Me.RBFut.TabIndex = 159
        Me.RBFut.TabStop = True
        Me.RBFut.Text = "Futures"
        Me.RBFut.UseVisualStyleBackColor = True
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbNormal)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.rbInternet)
        Me.Panel2.Location = New System.Drawing.Point(593, 297)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(211, 20)
        Me.Panel2.TabIndex = 168
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.rbNormal.Checked = True
        Me.rbNormal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNormal.Location = New System.Drawing.Point(78, 1)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(58, 18)
        Me.rbNormal.TabIndex = 162
        Me.rbNormal.TabStop = True
        Me.rbNormal.Text = "Normal"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'rbInternet
        '
        Me.rbInternet.AutoSize = True
        Me.rbInternet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbInternet.Location = New System.Drawing.Point(148, 1)
        Me.rbInternet.Name = "rbInternet"
        Me.rbInternet.Size = New System.Drawing.Size(61, 18)
        Me.rbInternet.TabIndex = 161
        Me.rbInternet.Text = "Internet"
        Me.rbInternet.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(246, 414)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 14)
        Me.Label12.TabIndex = 172
        Me.Label12.Text = "AE Name"
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Location = New System.Drawing.Point(330, 410)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(257, 21)
        Me.txtAEName.TabIndex = 171
        '
        'comboAE
        '
        Me.comboAE.Enabled = False
        Me.comboAE.FormattingEnabled = True
        Me.comboAE.Location = New System.Drawing.Point(86, 410)
        Me.comboAE.Name = "comboAE"
        Me.comboAE.Size = New System.Drawing.Size(148, 23)
        Me.comboAE.TabIndex = 170
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(11, 414)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(49, 14)
        Me.Label11.TabIndex = 169
        Me.Label11.Text = "AE Code"
        '
        'dtgRateTbl
        '
        Me.dtgRateTbl.AllowUserToAddRows = False
        Me.dtgRateTbl.AllowUserToDeleteRows = False
        Me.dtgRateTbl.AllowUserToResizeRows = False
        Me.dtgRateTbl.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgRateTbl.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dtgRateTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRateTbl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.acc_no, Me.fut_type, Me.trade_type, Me.acc_group, Me.acc_name_s, Me.man_group, Me.ae_no, Me.man_no, Me.product_code, Me.comm_month, Me.misc_desc, Me.rate_type, Me.day_rate, Me.night_rate, Me.turnover_from, Me.all_rate, Me.comm_rate, Me.rsid})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRateTbl.DefaultCellStyle = DataGridViewCellStyle3
        Me.dtgRateTbl.Location = New System.Drawing.Point(12, 82)
        Me.dtgRateTbl.MultiSelect = False
        Me.dtgRateTbl.Name = "dtgRateTbl"
        Me.dtgRateTbl.ReadOnly = True
        Me.dtgRateTbl.RowHeadersVisible = False
        Me.dtgRateTbl.RowTemplate.Height = 24
        Me.dtgRateTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgRateTbl.Size = New System.Drawing.Size(833, 208)
        Me.dtgRateTbl.TabIndex = 173
        '
        'txtMonth
        '
        Me.txtMonth.FormattingEnabled = True
        Me.txtMonth.Location = New System.Drawing.Point(86, 354)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(148, 23)
        Me.txtMonth.TabIndex = 174
        '
        'acc_no
        '
        Me.acc_no.DataPropertyName = "acc_no"
        Me.acc_no.HeaderText = "Account No."
        Me.acc_no.Name = "acc_no"
        Me.acc_no.ReadOnly = True
        '
        'fut_type
        '
        Me.fut_type.DataPropertyName = "fut_type"
        Me.fut_type.HeaderText = "Type"
        Me.fut_type.Name = "fut_type"
        Me.fut_type.ReadOnly = True
        '
        'trade_type
        '
        Me.trade_type.DataPropertyName = "trade_type"
        Me.trade_type.HeaderText = "Trade Type"
        Me.trade_type.Name = "trade_type"
        Me.trade_type.ReadOnly = True
        '
        'acc_group
        '
        Me.acc_group.DataPropertyName = "acc_group"
        Me.acc_group.HeaderText = "Account Group"
        Me.acc_group.Name = "acc_group"
        Me.acc_group.ReadOnly = True
        Me.acc_group.Visible = False
        '
        'acc_name_s
        '
        Me.acc_name_s.DataPropertyName = "acc_name_f"
        Me.acc_name_s.HeaderText = "Account Name"
        Me.acc_name_s.Name = "acc_name_s"
        Me.acc_name_s.ReadOnly = True
        Me.acc_name_s.Width = 120
        '
        'man_group
        '
        Me.man_group.DataPropertyName = "man_group"
        Me.man_group.HeaderText = "Manager Group"
        Me.man_group.Name = "man_group"
        Me.man_group.ReadOnly = True
        Me.man_group.Visible = False
        '
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "A/E Code"
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        '
        'man_no
        '
        Me.man_no.DataPropertyName = "man_no"
        Me.man_no.HeaderText = "Manager Number"
        Me.man_no.Name = "man_no"
        Me.man_no.ReadOnly = True
        Me.man_no.Visible = False
        '
        'product_code
        '
        Me.product_code.DataPropertyName = "prod_code"
        Me.product_code.HeaderText = "Product"
        Me.product_code.Name = "product_code"
        Me.product_code.ReadOnly = True
        Me.product_code.Width = 120
        '
        'comm_month
        '
        Me.comm_month.DataPropertyName = "comm_month"
        Me.comm_month.HeaderText = "Month"
        Me.comm_month.Name = "comm_month"
        Me.comm_month.ReadOnly = True
        Me.comm_month.Width = 70
        '
        'misc_desc
        '
        Me.misc_desc.DataPropertyName = "comm_type"
        Me.misc_desc.HeaderText = "Commission Type"
        Me.misc_desc.Name = "misc_desc"
        Me.misc_desc.ReadOnly = True
        Me.misc_desc.Visible = False
        '
        'rate_type
        '
        Me.rate_type.DataPropertyName = "rate_type"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.rate_type.DefaultCellStyle = DataGridViewCellStyle1
        Me.rate_type.HeaderText = "Rate Type"
        Me.rate_type.Name = "rate_type"
        Me.rate_type.ReadOnly = True
        Me.rate_type.Visible = False
        Me.rate_type.Width = 60
        '
        'day_rate
        '
        Me.day_rate.DataPropertyName = "day_rate"
        Me.day_rate.HeaderText = "Day Rate"
        Me.day_rate.Name = "day_rate"
        Me.day_rate.ReadOnly = True
        '
        'night_rate
        '
        Me.night_rate.DataPropertyName = "night_rate"
        Me.night_rate.HeaderText = "Night Rate"
        Me.night_rate.Name = "night_rate"
        Me.night_rate.ReadOnly = True
        '
        'turnover_from
        '
        Me.turnover_from.DataPropertyName = "turnover_from"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.turnover_from.DefaultCellStyle = DataGridViewCellStyle2
        Me.turnover_from.HeaderText = "Turnover >="
        Me.turnover_from.Name = "turnover_from"
        Me.turnover_from.ReadOnly = True
        Me.turnover_from.Width = 120
        '
        'all_rate
        '
        Me.all_rate.DataPropertyName = "all_rate"
        Me.all_rate.HeaderText = "all_rate"
        Me.all_rate.Name = "all_rate"
        Me.all_rate.ReadOnly = True
        Me.all_rate.Visible = False
        '
        'comm_rate
        '
        Me.comm_rate.DataPropertyName = "comm_rate"
        Me.comm_rate.HeaderText = "Commission Rate"
        Me.comm_rate.Name = "comm_rate"
        Me.comm_rate.ReadOnly = True
        Me.comm_rate.Visible = False
        '
        'rsid
        '
        Me.rsid.DataPropertyName = "rsid"
        Me.rsid.HeaderText = "rsid"
        Me.rsid.Name = "rsid"
        Me.rsid.ReadOnly = True
        Me.rsid.Visible = False
        '
        'FrmCommRatetblFAcc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(850, 493)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.dtgRateTbl)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtAEName)
        Me.Controls.Add(Me.comboAE)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.txtDayRate)
        Me.Controls.Add(Me.txtNightRate)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtProductName)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.comboProduct)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.comboAccNo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTOFrom)
        Me.Controls.Add(Me.comboMonth)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtAccName)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtSrcAcc)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmCommRatetblFAcc"
        Me.Text = "Futures and Options Comm. Rate Table (by Account)"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtSrcAcc, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtAccName, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.comboMonth, 0)
        Me.Controls.SetChildIndex(Me.txtTOFrom, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.comboAccNo, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnReset, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.comboProduct, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtProductName, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtNightRate, 0)
        Me.Controls.SetChildIndex(Me.txtDayRate, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.comboAE, 0)
        Me.Controls.SetChildIndex(Me.txtAEName, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.dtgRateTbl, 0)
        Me.Controls.SetChildIndex(Me.txtMonth, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.dtgRateTbl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnReset As ESL.myButton
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents comboAccNo As ESL.myComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTOFrom As ESL.myAmountBox
    Friend WithEvents comboMonth As ESL.myComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAccName As ESL.myTextbox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtSrcAcc As ESL.myTextbox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents comboProduct As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtProductName As ESL.myTextbox
    Friend WithEvents txtNightRate As ESL.myAmountBox
    Friend WithEvents txtDayRate As ESL.myAmountBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RBOption As ESL.myRadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents RBFut As ESL.myRadioButton
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents rbNormal As ESL.myRadioButton
    Friend WithEvents rbInternet As ESL.myRadioButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents comboAE As ESL.myComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents dtgRateTbl As System.Windows.Forms.DataGridView
    Friend WithEvents txtMonth As ESL.myComboBox
    Friend WithEvents acc_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fut_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents trade_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rate_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents day_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents night_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents all_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsid As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
