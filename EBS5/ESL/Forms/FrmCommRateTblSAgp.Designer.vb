<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRateTblSAgp
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
        Me.lblAEGroup = New System.Windows.Forms.Label
        Me.lblTurnover = New System.Windows.Forms.Label
        Me.GroupTradeType = New System.Windows.Forms.GroupBox
        Me.rbNormal = New ESL.myRadioButton(Me.components)
        Me.rbInternet = New ESL.myRadioButton(Me.components)
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbConsolidate = New ESL.myRadioButton(Me.components)
        Me.rbSrchNormal = New ESL.myRadioButton(Me.components)
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.rbSrchInternet = New ESL.myRadioButton(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.cboSearchYear = New ESL.myComboBox(Me.components)
        Me.cboSearchMonth = New ESL.myComboBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAEName = New ESL.myTextbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.fontPanel = New System.Windows.Forms.Panel
        Me.dgvRateList = New System.Windows.Forms.DataGridView
        Me.srid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Brokerage_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvAEList = New System.Windows.Forms.DataGridView
        Me.acc_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboAENo = New ESL.myComboBox(Me.components)
        Me.nbCommRate = New ESL.myNumericBox
        Me.abTurnover = New ESL.myAmountBox
        Me.txtMonth = New ESL.myTextbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboAEGroup = New ESL.myComboBox(Me.components)
        Me.cboSrchAEGP = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cbConsolidate = New ESL.myCheckBox(Me.components)
        Me.nbBrok_rate = New ESL.myNumericBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupTradeType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.fontPanel.SuspendLayout()
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(719, 465)
        Me.btnCancel.TabIndex = 17
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(668, 465)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Visible = True
        '
        'lblAEGroup
        '
        Me.lblAEGroup.AutoSize = True
        Me.lblAEGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAEGroup.Location = New System.Drawing.Point(12, 407)
        Me.lblAEGroup.Name = "lblAEGroup"
        Me.lblAEGroup.Size = New System.Drawing.Size(58, 14)
        Me.lblAEGroup.TabIndex = 84
        Me.lblAEGroup.Text = "A/C Group"
        '
        'lblTurnover
        '
        Me.lblTurnover.AutoSize = True
        Me.lblTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnover.Location = New System.Drawing.Point(205, 464)
        Me.lblTurnover.Name = "lblTurnover"
        Me.lblTurnover.Size = New System.Drawing.Size(106, 14)
        Me.lblTurnover.TabIndex = 125
        Me.lblTurnover.Text = "< ??,???,???,???.??"
        '
        'GroupTradeType
        '
        Me.GroupTradeType.Controls.Add(Me.rbNormal)
        Me.GroupTradeType.Controls.Add(Me.rbInternet)
        Me.GroupTradeType.Location = New System.Drawing.Point(80, 422)
        Me.GroupTradeType.Name = "GroupTradeType"
        Me.GroupTradeType.Size = New System.Drawing.Size(145, 33)
        Me.GroupTradeType.TabIndex = 8
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
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(165, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(457, 22)
        Me.lblTitle.TabIndex = 114
        Me.lblTitle.Text = "Securities Comm. Rate Table (by account group)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(539, 381)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 14)
        Me.Label10.TabIndex = 123
        Me.Label10.Text = "Month"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(12, 435)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 14)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "Trade Type"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbConsolidate)
        Me.GroupBox1.Controls.Add(Me.rbSrchNormal)
        Me.GroupBox1.Controls.Add(Me.rbSrchAll)
        Me.GroupBox1.Controls.Add(Me.rbSrchInternet)
        Me.GroupBox1.Location = New System.Drawing.Point(212, 29)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 31)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
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
        'rbSrchAll
        '
        Me.rbSrchAll.AutoSize = True
        Me.rbSrchAll.Checked = True
        Me.rbSrchAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchAll.Location = New System.Drawing.Point(224, 10)
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
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(657, 38)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(91, 23)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 483)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 14)
        Me.Label7.TabIndex = 121
        Me.Label7.Text = "Comm. Rate"
        '
        'cboSearchYear
        '
        Me.cboSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchYear.FormattingEnabled = True
        Me.cboSearchYear.Location = New System.Drawing.Point(40, 40)
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(66, 19)
        Me.cboSearchYear.TabIndex = 0
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchMonth.FormattingEnabled = True
        Me.cboSearchMonth.Location = New System.Drawing.Point(151, 40)
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(55, 19)
        Me.cboSearchMonth.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(112, 42)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 117
        Me.Label4.Text = "Month"
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAEName.Location = New System.Drawing.Point(207, 378)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(326, 20)
        Me.txtAEName.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(491, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 14)
        Me.Label2.TabIndex = 116
        Me.Label2.Text = "A/C Group"
        '
        'fontPanel
        '
        Me.fontPanel.Controls.Add(Me.dgvRateList)
        Me.fontPanel.Controls.Add(Me.dgvAEList)
        Me.fontPanel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontPanel.Location = New System.Drawing.Point(6, 66)
        Me.fontPanel.Name = "fontPanel"
        Me.fontPanel.Size = New System.Drawing.Size(766, 303)
        Me.fontPanel.TabIndex = 5
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
        Me.dgvRateList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.srid, Me.comm_month, Me.misc_desc, Me.turnover_from, Me.turnover_to, Me.turnover, Me.comm_rate, Me.Brokerage_rate})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRateList.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRateList.Location = New System.Drawing.Point(200, 3)
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
        Me.dgvRateList.Size = New System.Drawing.Size(563, 297)
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
        Me.comm_month.Width = 48
        '
        'misc_desc
        '
        Me.misc_desc.DataPropertyName = "misc_desc"
        Me.misc_desc.HeaderText = "Rate Type"
        Me.misc_desc.Name = "misc_desc"
        Me.misc_desc.ReadOnly = True
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
        Me.turnover.Width = 228
        '
        'comm_rate
        '
        Me.comm_rate.DataPropertyName = "comm_rate"
        Me.comm_rate.HeaderText = "Comm. Rate (%)"
        Me.comm_rate.Name = "comm_rate"
        Me.comm_rate.ReadOnly = True
        Me.comm_rate.Width = 90
        '
        'Brokerage_rate
        '
        Me.Brokerage_rate.DataPropertyName = "Brokerage_rate"
        Me.Brokerage_rate.HeaderText = "Brok. Rate (%)"
        Me.Brokerage_rate.Name = "Brokerage_rate"
        Me.Brokerage_rate.ReadOnly = True
        Me.Brokerage_rate.Width = 90
        '
        'dgvAEList
        '
        Me.dgvAEList.AllowUserToAddRows = False
        Me.dgvAEList.AllowUserToDeleteRows = False
        Me.dgvAEList.AllowUserToResizeRows = False
        Me.dgvAEList.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvAEList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAEList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.acc_group, Me.ae_no, Me.ae_name_s})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAEList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvAEList.Location = New System.Drawing.Point(0, 3)
        Me.dgvAEList.MultiSelect = False
        Me.dgvAEList.Name = "dgvAEList"
        Me.dgvAEList.ReadOnly = True
        Me.dgvAEList.RowHeadersVisible = False
        Me.dgvAEList.RowTemplate.Height = 24
        Me.dgvAEList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAEList.Size = New System.Drawing.Size(194, 297)
        Me.dgvAEList.TabIndex = 0
        '
        'acc_group
        '
        Me.acc_group.DataPropertyName = "acc_group"
        Me.acc_group.HeaderText = "A/C Group"
        Me.acc_group.Name = "acc_group"
        Me.acc_group.ReadOnly = True
        Me.acc_group.Width = 85
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
        'cboAENo
        '
        Me.cboAENo.Enabled = False
        Me.cboAENo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAENo.FormattingEnabled = True
        Me.cboAENo.Location = New System.Drawing.Point(80, 378)
        Me.cboAENo.Name = "cboAENo"
        Me.cboAENo.Size = New System.Drawing.Size(121, 22)
        Me.cboAENo.TabIndex = 6
        '
        'nbCommRate
        '
        Me.nbCommRate.Enabled = False
        Me.nbCommRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbCommRate.Location = New System.Drawing.Point(80, 480)
        Me.nbCommRate.Name = "nbCommRate"
        Me.nbCommRate.Size = New System.Drawing.Size(57, 20)
        Me.nbCommRate.TabIndex = 11
        Me.nbCommRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'abTurnover
        '
        Me.abTurnover.DecimalPoints = 2
        Me.abTurnover.Enabled = False
        Me.abTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abTurnover.Location = New System.Drawing.Point(80, 458)
        Me.abTurnover.Name = "abTurnover"
        Me.abTurnover.Size = New System.Drawing.Size(119, 20)
        Me.abTurnover.TabIndex = 10
        Me.abTurnover.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(581, 378)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(83, 20)
        Me.txtMonth.TabIndex = 118
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 461)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 113
        Me.Label1.Text = "Turnover >="
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(612, 465)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(561, 465)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 14
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(510, 465)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 13
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 129
        Me.Label3.Text = "Year"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 381)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 14)
        Me.Label6.TabIndex = 130
        Me.Label6.Text = "AE"
        '
        'cboAEGroup
        '
        Me.cboAEGroup.FormattingEnabled = True
        Me.cboAEGroup.Location = New System.Drawing.Point(80, 403)
        Me.cboAEGroup.Name = "cboAEGroup"
        Me.cboAEGroup.Size = New System.Drawing.Size(121, 23)
        Me.cboAEGroup.TabIndex = 7
        '
        'cboSrchAEGP
        '
        Me.cboSrchAEGP.Location = New System.Drawing.Point(555, 37)
        Me.cboSrchAEGP.Name = "cboSrchAEGP"
        Me.cboSrchAEGP.Size = New System.Drawing.Size(88, 21)
        Me.cboSrchAEGP.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(143, 482)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(187, 14)
        Me.Label5.TabIndex = 299
        Me.Label5.Text = "% (co. comm = comm rate * turnover)"
        '
        'cbConsolidate
        '
        Me.cbConsolidate.AutoSize = True
        Me.cbConsolidate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbConsolidate.Location = New System.Drawing.Point(231, 433)
        Me.cbConsolidate.Name = "cbConsolidate"
        Me.cbConsolidate.Size = New System.Drawing.Size(82, 18)
        Me.cbConsolidate.TabIndex = 9
        Me.cbConsolidate.Text = "Consolidate"
        Me.cbConsolidate.UseVisualStyleBackColor = True
        '
        'nbBrok_rate
        '
        Me.nbBrok_rate.Enabled = False
        Me.nbBrok_rate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbBrok_rate.Location = New System.Drawing.Point(80, 503)
        Me.nbBrok_rate.Name = "nbBrok_rate"
        Me.nbBrok_rate.Size = New System.Drawing.Size(57, 20)
        Me.nbBrok_rate.TabIndex = 12
        Me.nbBrok_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(143, 505)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(194, 14)
        Me.Label9.TabIndex = 302
        Me.Label9.Text = "% (co. comm = brok rate * comm.rec'd)"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(12, 506)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(57, 14)
        Me.Label11.TabIndex = 301
        Me.Label11.Text = "Brok. Rate"
        '
        'FrmCommRateTblSAgp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(772, 537)
        Me.Controls.Add(Me.nbBrok_rate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cboAEGroup)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboAENo)
        Me.Controls.Add(Me.fontPanel)
        Me.Controls.Add(Me.cboSearchMonth)
        Me.Controls.Add(Me.cbConsolidate)
        Me.Controls.Add(Me.nbCommRate)
        Me.Controls.Add(Me.cboSearchYear)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblAEGroup)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.cboSrchAEGP)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupTradeType)
        Me.Controls.Add(Me.txtAEName)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.lblTurnover)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.abTurnover)
        Me.KeyPreview = True
        Me.Name = "FrmCommRateTblSAgp"
        Me.Text = "Securities Commission Rate Table (by account group)"
        Me.Controls.SetChildIndex(Me.abTurnover, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.lblTurnover, 0)
        Me.Controls.SetChildIndex(Me.txtMonth, 0)
        Me.Controls.SetChildIndex(Me.txtAEName, 0)
        Me.Controls.SetChildIndex(Me.GroupTradeType, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cboSrchAEGP, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.lblAEGroup, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.cboSearchYear, 0)
        Me.Controls.SetChildIndex(Me.nbCommRate, 0)
        Me.Controls.SetChildIndex(Me.cbConsolidate, 0)
        Me.Controls.SetChildIndex(Me.cboSearchMonth, 0)
        Me.Controls.SetChildIndex(Me.fontPanel, 0)
        Me.Controls.SetChildIndex(Me.cboAENo, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.cboAEGroup, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.nbBrok_rate, 0)
        Me.GroupTradeType.ResumeLayout(False)
        Me.GroupTradeType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.fontPanel.ResumeLayout(False)
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblAEGroup As System.Windows.Forms.Label
    Friend WithEvents lblTurnover As System.Windows.Forms.Label
    Friend WithEvents GroupTradeType As System.Windows.Forms.GroupBox
    Friend WithEvents rbNormal As ESL.myRadioButton
    Friend WithEvents rbInternet As ESL.myRadioButton
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchNormal As ESL.myRadioButton
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents rbSrchInternet As ESL.myRadioButton
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboSearchYear As ESL.myComboBox
    Friend WithEvents cboSearchMonth As ESL.myComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fontPanel As System.Windows.Forms.Panel
    Friend WithEvents dgvRateList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvAEList As System.Windows.Forms.DataGridView
    Friend WithEvents cboAENo As ESL.myComboBox
    Friend WithEvents nbCommRate As ESL.myNumericBox
    Friend WithEvents abTurnover As ESL.myAmountBox
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cboAEGroup As ESL.myComboBox
    Friend WithEvents cboSrchAEGP As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbConsolidate As ESL.myRadioButton
    Friend WithEvents cbConsolidate As ESL.myCheckBox
    Friend WithEvents acc_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents nbBrok_rate As ESL.myNumericBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents srid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brokerage_rate As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
