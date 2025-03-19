<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRateTblSACC
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
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblTitle = New System.Windows.Forms.Label
        Me.rbInternet = New ESL.myRadioButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupTradeType = New System.Windows.Forms.GroupBox
        Me.rbNormal = New ESL.myRadioButton(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtAEName = New ESL.myTextbox
        Me.cboAENo = New ESL.myComboBox(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAccName = New ESL.myTextbox
        Me.cboAccNo = New ESL.myComboBox(Me.components)
        Me.lblAcc = New System.Windows.Forms.Label
        Me.nbCommRate = New ESL.myNumericBox
        Me.abTurnover = New ESL.myAmountBox
        Me.txtMonth = New ESL.myTextbox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSrchNormal = New ESL.myRadioButton(Me.components)
        Me.rbConsolidate = New ESL.myRadioButton(Me.components)
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.rbSrchInternet = New ESL.myRadioButton(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtSrchAccNo = New ESL.myTextbox
        Me.cboSearchMonth = New ESL.myComboBox(Me.components)
        Me.cboSearchYear = New ESL.myComboBox(Me.components)
        Me.dgvAEList = New System.Windows.Forms.DataGridView
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvAccList = New System.Windows.Forms.DataGridView
        Me.acc_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acc_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvRateList = New System.Windows.Forms.DataGridView
        Me.srid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Brokerage_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fontPanel = New System.Windows.Forms.Panel
        Me.lblTurnover = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.cbConsolidate = New ESL.myCheckBox(Me.components)
        Me.txtSrcAE = New ESL.myTextbox
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnBEdit = New ESL.myButton(Me.components)
        Me.btnBNew = New ESL.myButton(Me.components)
        Me.btnBDelete = New ESL.myButton(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.nbBrok_rate = New ESL.myNumericBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupTradeType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAccList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.fontPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(741, 457)
        Me.btnCancel.TabIndex = 20
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(690, 457)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Visible = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(179, 2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(447, 22)
        Me.lblTitle.TabIndex = 73
        Me.lblTitle.Text = "Securities Commission Rate Table (by account)"
        '
        'rbInternet
        '
        Me.rbInternet.AutoSize = True
        Me.rbInternet.Enabled = False
        Me.rbInternet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbInternet.Location = New System.Drawing.Point(72, 12)
        Me.rbInternet.Name = "rbInternet"
        Me.rbInternet.Size = New System.Drawing.Size(61, 18)
        Me.rbInternet.TabIndex = 1
        Me.rbInternet.Text = "Internet"
        Me.rbInternet.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(640, 457)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 18
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(540, 457)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 16
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(590, 457)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 17
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 452)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 65
        Me.Label1.Text = "Turnover >="
        '
        'GroupTradeType
        '
        Me.GroupTradeType.Controls.Add(Me.rbNormal)
        Me.GroupTradeType.Controls.Add(Me.rbInternet)
        Me.GroupTradeType.Location = New System.Drawing.Point(190, 413)
        Me.GroupTradeType.Name = "GroupTradeType"
        Me.GroupTradeType.Size = New System.Drawing.Size(151, 33)
        Me.GroupTradeType.TabIndex = 9
        Me.GroupTradeType.TabStop = False
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.rbNormal.Checked = True
        Me.rbNormal.Enabled = False
        Me.rbNormal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNormal.Location = New System.Drawing.Point(6, 12)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(58, 18)
        Me.rbNormal.TabIndex = 0
        Me.rbNormal.TabStop = True
        Me.rbNormal.Text = "Normal"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(555, 376)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 14)
        Me.Label10.TabIndex = 99
        Me.Label10.Text = "Month"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(21, 427)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 14)
        Me.Label8.TabIndex = 97
        Me.Label8.Text = "Trade Type"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(21, 475)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 14)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Comm. Rate"
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAEName.Location = New System.Drawing.Point(196, 398)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(345, 20)
        Me.txtAEName.TabIndex = 95
        '
        'cboAENo
        '
        Me.cboAENo.Enabled = False
        Me.cboAENo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAENo.FormattingEnabled = True
        Me.cboAENo.Location = New System.Drawing.Point(89, 398)
        Me.cboAENo.Name = "cboAENo"
        Me.cboAENo.Size = New System.Drawing.Size(101, 22)
        Me.cboAENo.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(21, 401)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 14)
        Me.Label6.TabIndex = 93
        Me.Label6.Text = "AE"
        '
        'txtAccName
        '
        Me.txtAccName.Enabled = False
        Me.txtAccName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccName.Location = New System.Drawing.Point(196, 373)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(345, 20)
        Me.txtAccName.TabIndex = 92
        '
        'cboAccNo
        '
        Me.cboAccNo.Enabled = False
        Me.cboAccNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAccNo.FormattingEnabled = True
        Me.cboAccNo.Location = New System.Drawing.Point(89, 373)
        Me.cboAccNo.Name = "cboAccNo"
        Me.cboAccNo.Size = New System.Drawing.Size(101, 22)
        Me.cboAccNo.TabIndex = 6
        '
        'lblAcc
        '
        Me.lblAcc.AutoSize = True
        Me.lblAcc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcc.Location = New System.Drawing.Point(21, 376)
        Me.lblAcc.Name = "lblAcc"
        Me.lblAcc.Size = New System.Drawing.Size(48, 14)
        Me.lblAcc.TabIndex = 76
        Me.lblAcc.Text = "Account"
        '
        'nbCommRate
        '
        Me.nbCommRate.Enabled = False
        Me.nbCommRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbCommRate.Location = New System.Drawing.Point(89, 472)
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
        Me.abTurnover.Location = New System.Drawing.Point(89, 449)
        Me.abTurnover.Name = "abTurnover"
        Me.abTurnover.Size = New System.Drawing.Size(119, 20)
        Me.abTurnover.TabIndex = 10
        Me.abTurnover.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(615, 373)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(83, 20)
        Me.txtMonth.TabIndex = 86
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSrchNormal)
        Me.GroupBox1.Controls.Add(Me.rbConsolidate)
        Me.GroupBox1.Controls.Add(Me.rbSrchAll)
        Me.GroupBox1.Controls.Add(Me.rbSrchInternet)
        Me.GroupBox1.Location = New System.Drawing.Point(215, 27)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 31)
        Me.GroupBox1.TabIndex = 2
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(117, 38)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 83
        Me.Label4.Text = "Month"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(12, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 76
        Me.Label3.Text = "Year"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(698, 33)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(63, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(477, 39)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(25, 14)
        Me.Label2.TabIndex = 78
        Me.Label2.Text = "A/C"
        '
        'txtSrchAccNo
        '
        Me.txtSrchAccNo.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtSrchAccNo.Location = New System.Drawing.Point(502, 36)
        Me.txtSrchAccNo.Name = "txtSrchAccNo"
        Me.txtSrchAccNo.Size = New System.Drawing.Size(82, 21)
        Me.txtSrchAccNo.TabIndex = 3
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchMonth.Enabled = False
        Me.cboSearchMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchMonth.FormattingEnabled = True
        Me.cboSearchMonth.Location = New System.Drawing.Point(156, 37)
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(53, 19)
        Me.cboSearchMonth.TabIndex = 1
        '
        'cboSearchYear
        '
        Me.cboSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchYear.Enabled = False
        Me.cboSearchYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchYear.FormattingEnabled = True
        Me.cboSearchYear.Location = New System.Drawing.Point(40, 36)
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(72, 19)
        Me.cboSearchYear.TabIndex = 0
        '
        'dgvAEList
        '
        Me.dgvAEList.AllowUserToAddRows = False
        Me.dgvAEList.AllowUserToDeleteRows = False
        Me.dgvAEList.AllowUserToResizeRows = False
        Me.dgvAEList.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvAEList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAEList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ae_no, Me.ae_name_s})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAEList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAEList.Location = New System.Drawing.Point(0, 232)
        Me.dgvAEList.MultiSelect = False
        Me.dgvAEList.Name = "dgvAEList"
        Me.dgvAEList.ReadOnly = True
        Me.dgvAEList.RowHeadersVisible = False
        Me.dgvAEList.RowTemplate.Height = 24
        Me.dgvAEList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAEList.Size = New System.Drawing.Size(194, 74)
        Me.dgvAEList.TabIndex = 1
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
        'dgvAccList
        '
        Me.dgvAccList.AllowUserToAddRows = False
        Me.dgvAccList.AllowUserToDeleteRows = False
        Me.dgvAccList.AllowUserToResizeRows = False
        Me.dgvAccList.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvAccList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAccList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.acc_no, Me.acc_name_s})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAccList.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvAccList.Location = New System.Drawing.Point(0, 0)
        Me.dgvAccList.MultiSelect = False
        Me.dgvAccList.Name = "dgvAccList"
        Me.dgvAccList.ReadOnly = True
        Me.dgvAccList.RowHeadersVisible = False
        Me.dgvAccList.RowTemplate.Height = 24
        Me.dgvAccList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccList.Size = New System.Drawing.Size(194, 226)
        Me.dgvAccList.TabIndex = 0
        '
        'acc_no
        '
        Me.acc_no.DataPropertyName = "acc_no"
        Me.acc_no.HeaderText = "A/C No."
        Me.acc_no.Name = "acc_no"
        Me.acc_no.ReadOnly = True
        Me.acc_no.Width = 75
        '
        'acc_name_s
        '
        Me.acc_name_s.DataPropertyName = "acc_name_s"
        Me.acc_name_s.HeaderText = "A/C Name"
        Me.acc_name_s.Name = "acc_name_s"
        Me.acc_name_s.ReadOnly = True
        '
        'dgvRateList
        '
        Me.dgvRateList.AllowUserToAddRows = False
        Me.dgvRateList.AllowUserToDeleteRows = False
        Me.dgvRateList.AllowUserToResizeRows = False
        Me.dgvRateList.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRateList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvRateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRateList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.srid, Me.comm_month, Me.misc_desc, Me.turnover_from, Me.turnover_to, Me.turnover, Me.comm_rate, Me.Brokerage_rate})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRateList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRateList.Location = New System.Drawing.Point(196, 0)
        Me.dgvRateList.MultiSelect = False
        Me.dgvRateList.Name = "dgvRateList"
        Me.dgvRateList.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRateList.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvRateList.RowHeadersVisible = False
        Me.dgvRateList.RowTemplate.Height = 24
        Me.dgvRateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRateList.Size = New System.Drawing.Size(580, 306)
        Me.dgvRateList.TabIndex = 2
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
        Me.misc_desc.Width = 110
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
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.turnover.DefaultCellStyle = DataGridViewCellStyle4
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
        'fontPanel
        '
        Me.fontPanel.Controls.Add(Me.dgvRateList)
        Me.fontPanel.Controls.Add(Me.dgvAccList)
        Me.fontPanel.Controls.Add(Me.dgvAEList)
        Me.fontPanel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontPanel.Location = New System.Drawing.Point(15, 64)
        Me.fontPanel.Name = "fontPanel"
        Me.fontPanel.Size = New System.Drawing.Size(779, 306)
        Me.fontPanel.TabIndex = 5
        '
        'lblTurnover
        '
        Me.lblTurnover.AutoSize = True
        Me.lblTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnover.Location = New System.Drawing.Point(214, 452)
        Me.lblTurnover.Name = "lblTurnover"
        Me.lblTurnover.Size = New System.Drawing.Size(106, 14)
        Me.lblTurnover.TabIndex = 102
        Me.lblTurnover.Text = "< ??,???,???,???.??"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(152, 474)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(187, 14)
        Me.Label9.TabIndex = 299
        Me.Label9.Text = "% (co. comm = comm rate * turnover)"
        '
        'cbConsolidate
        '
        Me.cbConsolidate.AutoSize = True
        Me.cbConsolidate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbConsolidate.Location = New System.Drawing.Point(89, 425)
        Me.cbConsolidate.Name = "cbConsolidate"
        Me.cbConsolidate.Size = New System.Drawing.Size(82, 18)
        Me.cbConsolidate.TabIndex = 8
        Me.cbConsolidate.Text = "Consolidate"
        Me.cbConsolidate.UseVisualStyleBackColor = True
        '
        'txtSrcAE
        '
        Me.txtSrcAE.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtSrcAE.Location = New System.Drawing.Point(610, 35)
        Me.txtSrcAE.Name = "txtSrcAE"
        Me.txtSrcAE.Size = New System.Drawing.Size(82, 21)
        Me.txtSrcAE.TabIndex = 4
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(588, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 14)
        Me.Label11.TabIndex = 301
        Me.Label11.Text = "AE"
        '
        'btnBEdit
        '
        Me.btnBEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBEdit.Location = New System.Drawing.Point(442, 457)
        Me.btnBEdit.Name = "btnBEdit"
        Me.btnBEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnBEdit.TabIndex = 14
        Me.btnBEdit.Text = "AE Batch Edit"
        Me.btnBEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBEdit.UseVisualStyleBackColor = True
        '
        'btnBNew
        '
        Me.btnBNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBNew.Location = New System.Drawing.Point(393, 457)
        Me.btnBNew.Name = "btnBNew"
        Me.btnBNew.Size = New System.Drawing.Size(50, 55)
        Me.btnBNew.TabIndex = 13
        Me.btnBNew.Text = "AE Batch New"
        Me.btnBNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBNew.UseVisualStyleBackColor = True
        '
        'btnBDelete
        '
        Me.btnBDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBDelete.Location = New System.Drawing.Point(491, 457)
        Me.btnBDelete.Name = "btnBDelete"
        Me.btnBDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnBDelete.TabIndex = 15
        Me.btnBDelete.Text = "AE Batch Delete"
        Me.btnBDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBDelete.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(152, 497)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(197, 14)
        Me.Label5.TabIndex = 307
        Me.Label5.Text = "% (co. comm = brok rate * comm. rec'd)"
        '
        'nbBrok_rate
        '
        Me.nbBrok_rate.Enabled = False
        Me.nbBrok_rate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbBrok_rate.Location = New System.Drawing.Point(89, 495)
        Me.nbBrok_rate.Name = "nbBrok_rate"
        Me.nbBrok_rate.Size = New System.Drawing.Size(57, 20)
        Me.nbBrok_rate.TabIndex = 12
        Me.nbBrok_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(21, 498)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 14)
        Me.Label12.TabIndex = 306
        Me.Label12.Text = "Brok. Rate"
        '
        'FrmCommRateTblSACC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(797, 526)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nbBrok_rate)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnBDelete)
        Me.Controls.Add(Me.btnBEdit)
        Me.Controls.Add(Me.btnBNew)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSrcAE)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.lblAcc)
        Me.Controls.Add(Me.cbConsolidate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboSearchYear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lblTurnover)
        Me.Controls.Add(Me.cboSearchMonth)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.txtAEName)
        Me.Controls.Add(Me.abTurnover)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.nbCommRate)
        Me.Controls.Add(Me.GroupTradeType)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.cboAccNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtAccName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.fontPanel)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtSrchAccNo)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboAENo)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FrmCommRateTblSACC"
        Me.Text = "Securities Commission Rate Table (by account)"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.cboAENo, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtSrchAccNo, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.fontPanel, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtAccName, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cboAccNo, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.GroupTradeType, 0)
        Me.Controls.SetChildIndex(Me.nbCommRate, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.abTurnover, 0)
        Me.Controls.SetChildIndex(Me.txtAEName, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.txtMonth, 0)
        Me.Controls.SetChildIndex(Me.cboSearchMonth, 0)
        Me.Controls.SetChildIndex(Me.lblTurnover, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cboSearchYear, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.cbConsolidate, 0)
        Me.Controls.SetChildIndex(Me.lblAcc, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtSrcAE, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.btnBNew, 0)
        Me.Controls.SetChildIndex(Me.btnBEdit, 0)
        Me.Controls.SetChildIndex(Me.btnBDelete, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.nbBrok_rate, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.GroupTradeType.ResumeLayout(False)
        Me.GroupTradeType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAccList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.fontPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents rbInternet As ESL.myRadioButton
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents Label1 As System.Windows.Forms.Label

    Private Sub comboAENo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Friend WithEvents cboSearchMonth As ESL.myComboBox
    Friend WithEvents cboSearchYear As ESL.myComboBox
    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub comboMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub rbGetInternet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub rbGetAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub rbGetNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Private Sub comboAccNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
    Friend WithEvents txtSrchAccNo As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbSrchInternet As ESL.myRadioButton
    Friend WithEvents rbSrchNormal As ESL.myRadioButton
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents nbCommRate As ESL.myNumericBox
    Friend WithEvents abTurnover As ESL.myAmountBox
    Friend WithEvents rbNormal As ESL.myRadioButton
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents cboAENo As ESL.myComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtAccName As ESL.myTextbox
    Friend WithEvents cboAccNo As ESL.myComboBox
    Friend WithEvents lblAcc As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupTradeType As System.Windows.Forms.GroupBox
    Friend WithEvents dgvAEList As System.Windows.Forms.DataGridView
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvAccList As System.Windows.Forms.DataGridView
    Friend WithEvents acc_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvRateList As System.Windows.Forms.DataGridView
    Friend WithEvents fontPanel As System.Windows.Forms.Panel
    Friend WithEvents lblTurnover As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbConsolidate As ESL.myCheckBox
    Friend WithEvents rbConsolidate As ESL.myRadioButton
    Friend WithEvents txtSrcAE As ESL.myTextbox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnBEdit As ESL.myButton
    Friend WithEvents btnBNew As ESL.myButton
    Friend WithEvents btnBDelete As ESL.myButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nbBrok_rate As ESL.myNumericBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents srid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brokerage_rate As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
