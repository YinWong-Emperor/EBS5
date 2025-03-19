<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRateTblSSpecial
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSrcAE = New ESL.myTextbox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.cbConsolidate = New ESL.myCheckBox(Me.components)
        Me.cboSearchYear = New ESL.myComboBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboSearchMonth = New ESL.myComboBox(Me.components)
        Me.txtMonth = New ESL.myTextbox
        Me.txtAEName = New ESL.myTextbox
        Me.GroupTradeType = New System.Windows.Forms.GroupBox
        Me.rbNormal = New ESL.myRadioButton(Me.components)
        Me.rbInternet = New ESL.myRadioButton(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.fontPanel = New System.Windows.Forms.Panel
        Me.dgvRateList = New System.Windows.Forms.DataGridView
        Me.srid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Brokerage_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvAEList = New System.Windows.Forms.DataGridView
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSrchNormal = New ESL.myRadioButton(Me.components)
        Me.rbConsolidate = New ESL.myRadioButton(Me.components)
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.rbSrchInternet = New ESL.myRadioButton(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboAENo = New ESL.myComboBox(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbCommRate = New ESL.myRadioButton(Me.components)
        Me.rbTurnover = New ESL.myRadioButton(Me.components)
        Me.rbCommRecd = New ESL.myRadioButton(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.nbBrok_rate = New ESL.myNumericBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblTurnover = New System.Windows.Forms.Label
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.abTurnover = New ESL.myAmountBox
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.nbCommRate = New ESL.myNumericBox
        Me.btnNew = New ESL.myButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupTradeType.SuspendLayout()
        Me.fontPanel.SuspendLayout()
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(753, 463)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(701, 463)
        Me.btnSave.Visible = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(489, 53)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 14)
        Me.Label11.TabIndex = 361
        Me.Label11.Text = "AE"
        '
        'txtSrcAE
        '
        Me.txtSrcAE.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtSrcAE.Location = New System.Drawing.Point(511, 48)
        Me.txtSrcAE.Name = "txtSrcAE"
        Me.txtSrcAE.Size = New System.Drawing.Size(82, 21)
        Me.txtSrcAE.TabIndex = 347
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(189, 14)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(469, 22)
        Me.lblTitle.TabIndex = 353
        Me.lblTitle.Text = "Securities Commission Rate Table (special by AE)"
        '
        'cbConsolidate
        '
        Me.cbConsolidate.AutoSize = True
        Me.cbConsolidate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbConsolidate.Location = New System.Drawing.Point(101, 416)
        Me.cbConsolidate.Name = "cbConsolidate"
        Me.cbConsolidate.Size = New System.Drawing.Size(82, 18)
        Me.cbConsolidate.TabIndex = 351
        Me.cbConsolidate.Text = "Consolidate"
        Me.cbConsolidate.UseVisualStyleBackColor = True
        '
        'cboSearchYear
        '
        Me.cboSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchYear.FormattingEnabled = True
        Me.cboSearchYear.Location = New System.Drawing.Point(49, 50)
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(72, 19)
        Me.cboSearchYear.TabIndex = 344
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(126, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 355
        Me.Label4.Text = "Month"
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchMonth.FormattingEnabled = True
        Me.cboSearchMonth.Location = New System.Drawing.Point(165, 51)
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(53, 19)
        Me.cboSearchMonth.TabIndex = 345
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(630, 388)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(83, 20)
        Me.txtMonth.TabIndex = 356
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAEName.Location = New System.Drawing.Point(208, 388)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(345, 20)
        Me.txtAEName.TabIndex = 358
        '
        'GroupTradeType
        '
        Me.GroupTradeType.Controls.Add(Me.rbNormal)
        Me.GroupTradeType.Controls.Add(Me.rbInternet)
        Me.GroupTradeType.Location = New System.Drawing.Point(208, 402)
        Me.GroupTradeType.Name = "GroupTradeType"
        Me.GroupTradeType.Size = New System.Drawing.Size(151, 33)
        Me.GroupTradeType.TabIndex = 352
        Me.GroupTradeType.TabStop = False
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.rbNormal.Checked = True
        Me.rbNormal.Enabled = False
        Me.rbNormal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNormal.Location = New System.Drawing.Point(6, 11)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(58, 18)
        Me.rbNormal.TabIndex = 0
        Me.rbNormal.TabStop = True
        Me.rbNormal.Text = "Normal"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'rbInternet
        '
        Me.rbInternet.AutoSize = True
        Me.rbInternet.Enabled = False
        Me.rbInternet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbInternet.Location = New System.Drawing.Point(78, 11)
        Me.rbInternet.Name = "rbInternet"
        Me.rbInternet.Size = New System.Drawing.Size(61, 18)
        Me.rbInternet.TabIndex = 1
        Me.rbInternet.Text = "Internet"
        Me.rbInternet.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(570, 391)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 14)
        Me.Label10.TabIndex = 360
        Me.Label10.Text = "Month"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(707, 47)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(93, 23)
        Me.btnSearch.TabIndex = 348
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 390)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 14)
        Me.Label6.TabIndex = 357
        Me.Label6.Text = "AE"
        '
        'fontPanel
        '
        Me.fontPanel.Controls.Add(Me.dgvRateList)
        Me.fontPanel.Controls.Add(Me.dgvAEList)
        Me.fontPanel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontPanel.Location = New System.Drawing.Point(24, 78)
        Me.fontPanel.Name = "fontPanel"
        Me.fontPanel.Size = New System.Drawing.Size(779, 306)
        Me.fontPanel.TabIndex = 349
        '
        'dgvRateList
        '
        Me.dgvRateList.AllowUserToAddRows = False
        Me.dgvRateList.AllowUserToDeleteRows = False
        Me.dgvRateList.AllowUserToResizeRows = False
        Me.dgvRateList.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRateList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRateList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.srid, Me.comm_month, Me.misc_desc, Me.turnover_type, Me.turnover_from, Me.turnover_to, Me.turnover, Me.comm_rate, Me.Brokerage_rate})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRateList.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRateList.Location = New System.Drawing.Point(196, 0)
        Me.dgvRateList.MultiSelect = False
        Me.dgvRateList.Name = "dgvRateList"
        Me.dgvRateList.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRateList.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRateList.RowHeadersVisible = False
        Me.dgvRateList.RowTemplate.Height = 24
        Me.dgvRateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRateList.Size = New System.Drawing.Size(580, 306)
        Me.dgvRateList.TabIndex = 1
        '
        'srid
        '
        Me.srid.DataPropertyName = "srid"
        Me.srid.HeaderText = "srid"
        Me.srid.Name = "srid"
        Me.srid.ReadOnly = True
        Me.srid.Visible = False
        '
        'comm_month
        '
        Me.comm_month.DataPropertyName = "comm_month"
        Me.comm_month.HeaderText = "Month"
        Me.comm_month.Name = "comm_month"
        Me.comm_month.ReadOnly = True
        Me.comm_month.Width = 50
        '
        'misc_desc
        '
        Me.misc_desc.DataPropertyName = "misc_desc"
        Me.misc_desc.HeaderText = "Rate Type"
        Me.misc_desc.Name = "misc_desc"
        Me.misc_desc.ReadOnly = True
        Me.misc_desc.Width = 70
        '
        'turnover_type
        '
        Me.turnover_type.DataPropertyName = "turnover_type"
        Me.turnover_type.HeaderText = "Turnover / Comm. rec'd"
        Me.turnover_type.Name = "turnover_type"
        Me.turnover_type.ReadOnly = True
        Me.turnover_type.Width = 70
        '
        'turnover_from
        '
        Me.turnover_from.DataPropertyName = "turnover_from"
        Me.turnover_from.HeaderText = "Turnover Min."
        Me.turnover_from.Name = "turnover_from"
        Me.turnover_from.ReadOnly = True
        Me.turnover_from.Visible = False
        '
        'turnover_to
        '
        Me.turnover_to.DataPropertyName = "turnover_to"
        Me.turnover_to.HeaderText = "turnover_to"
        Me.turnover_to.Name = "turnover_to"
        Me.turnover_to.ReadOnly = True
        Me.turnover_to.Visible = False
        '
        'turnover
        '
        Me.turnover.DataPropertyName = "turnover"
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.turnover.DefaultCellStyle = DataGridViewCellStyle2
        Me.turnover.HeaderText = "Turnover Range"
        Me.turnover.Name = "turnover"
        Me.turnover.ReadOnly = True
        Me.turnover.Width = 227
        '
        'comm_rate
        '
        Me.comm_rate.DataPropertyName = "comm_rate"
        Me.comm_rate.HeaderText = "Comm. Rate (%)"
        Me.comm_rate.Name = "comm_rate"
        Me.comm_rate.ReadOnly = True
        Me.comm_rate.Width = 95
        '
        'Brokerage_rate
        '
        Me.Brokerage_rate.DataPropertyName = "Brokerage_rate"
        Me.Brokerage_rate.HeaderText = "Brok. Rate (%)"
        Me.Brokerage_rate.Name = "Brokerage_rate"
        Me.Brokerage_rate.ReadOnly = True
        Me.Brokerage_rate.Width = 95
        '
        'dgvAEList
        '
        Me.dgvAEList.AllowUserToAddRows = False
        Me.dgvAEList.AllowUserToDeleteRows = False
        Me.dgvAEList.AllowUserToResizeRows = False
        Me.dgvAEList.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvAEList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAEList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ae_no, Me.ae_name_s})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAEList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvAEList.Location = New System.Drawing.Point(0, 0)
        Me.dgvAEList.MultiSelect = False
        Me.dgvAEList.Name = "dgvAEList"
        Me.dgvAEList.ReadOnly = True
        Me.dgvAEList.RowHeadersVisible = False
        Me.dgvAEList.RowTemplate.Height = 24
        Me.dgvAEList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAEList.Size = New System.Drawing.Size(194, 306)
        Me.dgvAEList.TabIndex = 0
        '
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "AE No"
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        Me.ae_no.Width = 75
        '
        'ae_name_s
        '
        Me.ae_name_s.DataPropertyName = "ae_name_s"
        Me.ae_name_s.HeaderText = "AE Name"
        Me.ae_name_s.Name = "ae_name_s"
        Me.ae_name_s.ReadOnly = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(21, 52)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 354
        Me.Label3.Text = "Year"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSrchNormal)
        Me.GroupBox1.Controls.Add(Me.rbConsolidate)
        Me.GroupBox1.Controls.Add(Me.rbSrchAll)
        Me.GroupBox1.Controls.Add(Me.rbSrchInternet)
        Me.GroupBox1.Location = New System.Drawing.Point(224, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 31)
        Me.GroupBox1.TabIndex = 346
        Me.GroupBox1.TabStop = False
        '
        'rbSrchNormal
        '
        Me.rbSrchNormal.AutoSize = True
        Me.rbSrchNormal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchNormal.Location = New System.Drawing.Point(6, 10)
        Me.rbSrchNormal.Name = "rbSrchNormal"
        Me.rbSrchNormal.Size = New System.Drawing.Size(58, 18)
        Me.rbSrchNormal.TabIndex = 0
        Me.rbSrchNormal.Text = "Normal"
        Me.rbSrchNormal.UseVisualStyleBackColor = True
        '
        'rbConsolidate
        '
        Me.rbConsolidate.AutoSize = True
        Me.rbConsolidate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbConsolidate.Location = New System.Drawing.Point(137, 10)
        Me.rbConsolidate.Name = "rbConsolidate"
        Me.rbConsolidate.Size = New System.Drawing.Size(81, 18)
        Me.rbConsolidate.TabIndex = 2
        Me.rbConsolidate.Text = "Consolidate"
        Me.rbConsolidate.UseVisualStyleBackColor = True
        '
        'rbSrchAll
        '
        Me.rbSrchAll.AutoSize = True
        Me.rbSrchAll.Checked = True
        Me.rbSrchAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchAll.Location = New System.Drawing.Point(219, 11)
        Me.rbSrchAll.Name = "rbSrchAll"
        Me.rbSrchAll.Size = New System.Drawing.Size(37, 18)
        Me.rbSrchAll.TabIndex = 3
        Me.rbSrchAll.TabStop = True
        Me.rbSrchAll.Text = "All"
        Me.rbSrchAll.UseVisualStyleBackColor = True
        '
        'rbSrchInternet
        '
        Me.rbSrchInternet.AutoSize = True
        Me.rbSrchInternet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchInternet.Location = New System.Drawing.Point(70, 10)
        Me.rbSrchInternet.Name = "rbSrchInternet"
        Me.rbSrchInternet.Size = New System.Drawing.Size(61, 18)
        Me.rbSrchInternet.TabIndex = 1
        Me.rbSrchInternet.Text = "Internet"
        Me.rbSrchInternet.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 417)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 14)
        Me.Label8.TabIndex = 359
        Me.Label8.Text = "Trade Type"
        '
        'cboAENo
        '
        Me.cboAENo.Enabled = False
        Me.cboAENo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAENo.FormattingEnabled = True
        Me.cboAENo.Location = New System.Drawing.Point(101, 388)
        Me.cboAENo.Name = "cboAENo"
        Me.cboAENo.Size = New System.Drawing.Size(101, 22)
        Me.cboAENo.TabIndex = 350
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbCommRate)
        Me.GroupBox2.Controls.Add(Me.rbTurnover)
        Me.GroupBox2.Controls.Add(Me.rbCommRecd)
        Me.GroupBox2.Location = New System.Drawing.Point(361, 430)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(255, 33)
        Me.GroupBox2.TabIndex = 374
        Me.GroupBox2.TabStop = False
        '
        'rbCommRate
        '
        Me.rbCommRate.AutoSize = True
        Me.rbCommRate.Enabled = False
        Me.rbCommRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCommRate.Location = New System.Drawing.Point(168, 11)
        Me.rbCommRate.Name = "rbCommRate"
        Me.rbCommRate.Size = New System.Drawing.Size(79, 18)
        Me.rbCommRate.TabIndex = 2
        Me.rbCommRate.Text = "Comm. rate"
        Me.rbCommRate.UseVisualStyleBackColor = True
        '
        'rbTurnover
        '
        Me.rbTurnover.AutoSize = True
        Me.rbTurnover.Checked = True
        Me.rbTurnover.Enabled = False
        Me.rbTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTurnover.Location = New System.Drawing.Point(6, 11)
        Me.rbTurnover.Name = "rbTurnover"
        Me.rbTurnover.Size = New System.Drawing.Size(69, 18)
        Me.rbTurnover.TabIndex = 0
        Me.rbTurnover.TabStop = True
        Me.rbTurnover.Text = "Turnover"
        Me.rbTurnover.UseVisualStyleBackColor = True
        '
        'rbCommRecd
        '
        Me.rbCommRecd.AutoSize = True
        Me.rbCommRecd.Enabled = False
        Me.rbCommRecd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCommRecd.Location = New System.Drawing.Point(78, 11)
        Me.rbCommRecd.Name = "rbCommRecd"
        Me.rbCommRecd.Size = New System.Drawing.Size(84, 18)
        Me.rbCommRecd.TabIndex = 1
        Me.rbCommRecd.Text = "Comm. rec'd"
        Me.rbCommRecd.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(164, 488)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(200, 14)
        Me.Label5.TabIndex = 373
        Me.Label5.Text = "% (co. comm = brok. rate * comm. rec'd)"
        '
        'nbBrok_rate
        '
        Me.nbBrok_rate.Enabled = False
        Me.nbBrok_rate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbBrok_rate.Location = New System.Drawing.Point(101, 486)
        Me.nbBrok_rate.Name = "nbBrok_rate"
        Me.nbBrok_rate.Size = New System.Drawing.Size(57, 20)
        Me.nbBrok_rate.TabIndex = 364
        Me.nbBrok_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(21, 489)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 14)
        Me.Label12.TabIndex = 372
        Me.Label12.Text = "Brok. Rate"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(164, 465)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(187, 14)
        Me.Label9.TabIndex = 371
        Me.Label9.Text = "% (co. comm = comm rate * turnover)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 443)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 368
        Me.Label1.Text = "Turnover >="
        '
        'lblTurnover
        '
        Me.lblTurnover.AutoSize = True
        Me.lblTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnover.Location = New System.Drawing.Point(226, 443)
        Me.lblTurnover.Name = "lblTurnover"
        Me.lblTurnover.Size = New System.Drawing.Size(106, 14)
        Me.lblTurnover.TabIndex = 370
        Me.lblTurnover.Text = "< ??,???,???,???.??"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(597, 464)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 366
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'abTurnover
        '
        Me.abTurnover.DecimalPoints = 2
        Me.abTurnover.Enabled = False
        Me.abTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abTurnover.Location = New System.Drawing.Point(101, 440)
        Me.abTurnover.Name = "abTurnover"
        Me.abTurnover.Size = New System.Drawing.Size(119, 20)
        Me.abTurnover.TabIndex = 362
        Me.abTurnover.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(649, 463)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 367
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'nbCommRate
        '
        Me.nbCommRate.Enabled = False
        Me.nbCommRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbCommRate.Location = New System.Drawing.Point(101, 463)
        Me.nbCommRate.Name = "nbCommRate"
        Me.nbCommRate.Size = New System.Drawing.Size(57, 20)
        Me.nbCommRate.TabIndex = 363
        Me.nbCommRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(545, 464)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 365
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 466)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 14)
        Me.Label7.TabIndex = 369
        Me.Label7.Text = "Comm. Rate"
        '
        'FrmCommRateTblSSpecial
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(828, 536)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nbBrok_rate)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTurnover)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.abTurnover)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.nbCommRate)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSrcAE)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.cbConsolidate)
        Me.Controls.Add(Me.cboSearchYear)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboSearchMonth)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.txtAEName)
        Me.Controls.Add(Me.GroupTradeType)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.fontPanel)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cboAENo)
        Me.KeyPreview = True
        Me.Name = "FrmCommRateTblSSpecial"
        Me.Text = "frmBase          User:      Trade Date: 01/01/0001"
        Me.Controls.SetChildIndex(Me.cboAENo, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.fontPanel, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.GroupTradeType, 0)
        Me.Controls.SetChildIndex(Me.txtAEName, 0)
        Me.Controls.SetChildIndex(Me.txtMonth, 0)
        Me.Controls.SetChildIndex(Me.cboSearchMonth, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cboSearchYear, 0)
        Me.Controls.SetChildIndex(Me.cbConsolidate, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtSrcAE, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.nbCommRate, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.abTurnover, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.lblTurnover, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.nbBrok_rate, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupTradeType.ResumeLayout(False)
        Me.GroupTradeType.PerformLayout()
        Me.fontPanel.ResumeLayout(False)
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtSrcAE As ESL.myTextbox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cbConsolidate As ESL.myCheckBox
    Friend WithEvents cboSearchYear As ESL.myComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSearchMonth As ESL.myComboBox
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents GroupTradeType As System.Windows.Forms.GroupBox
    Friend WithEvents rbNormal As ESL.myRadioButton
    Friend WithEvents rbInternet As ESL.myRadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents fontPanel As System.Windows.Forms.Panel
    Friend WithEvents dgvRateList As System.Windows.Forms.DataGridView
    Friend WithEvents srid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brokerage_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvAEList As System.Windows.Forms.DataGridView
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchNormal As ESL.myRadioButton
    Friend WithEvents rbConsolidate As ESL.myRadioButton
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents rbSrchInternet As ESL.myRadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboAENo As ESL.myComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTurnover As ESL.myRadioButton
    Friend WithEvents rbCommRecd As ESL.myRadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nbBrok_rate As ESL.myNumericBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTurnover As System.Windows.Forms.Label
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents abTurnover As ESL.myAmountBox
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents nbCommRate As ESL.myNumericBox
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents rbCommRate As ESL.myRadioButton

End Class
