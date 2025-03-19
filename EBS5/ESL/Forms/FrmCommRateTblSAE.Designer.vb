<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRateTblSAE
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.ae_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvAEList = New System.Windows.Forms.DataGridView
        Me.Label5 = New System.Windows.Forms.Label
        Me.rbConsolidate = New ESL.myRadioButton(Me.components)
        Me.nbBrok_rate = New ESL.myNumericBox
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.rbSrchInternet = New ESL.myRadioButton(Me.components)
        Me.dgvRateList = New System.Windows.Forms.DataGridView
        Me.Label12 = New System.Windows.Forms.Label
        Me.rbSrchNormal = New ESL.myRadioButton(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.rbInternet = New ESL.myRadioButton(Me.components)
        Me.txtSrcAE = New ESL.myTextbox
        Me.lblTitle = New System.Windows.Forms.Label
        Me.cbConsolidate = New ESL.myCheckBox(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.cboSearchYear = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblTurnover = New System.Windows.Forms.Label
        Me.cboSearchMonth = New ESL.myComboBox(Me.components)
        Me.txtMonth = New ESL.myTextbox
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.txtAEName = New ESL.myTextbox
        Me.abTurnover = New ESL.myAmountBox
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.nbCommRate = New ESL.myNumericBox
        Me.GroupTradeType = New System.Windows.Forms.GroupBox
        Me.rbNormal = New ESL.myRadioButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.fontPanel = New System.Windows.Forms.Panel
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.cboAENo = New ESL.myComboBox(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbTurnover = New ESL.myRadioButton(Me.components)
        Me.rbCommRecd = New ESL.myRadioButton(Me.components)
        Me.srid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Brokerage_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupTradeType.SuspendLayout()
        Me.fontPanel.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(725, 423)
        Me.btnCancel.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(673, 423)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Visible = True
        '
        'ae_name_s
        '
        Me.ae_name_s.DataPropertyName = "ae_name_s"
        Me.ae_name_s.HeaderText = "AE Name"
        Me.ae_name_s.Name = "ae_name_s"
        Me.ae_name_s.ReadOnly = True
        '
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "AE No"
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        Me.ae_no.Width = 75
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
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(146, 463)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(200, 14)
        Me.Label5.TabIndex = 345
        Me.Label5.Text = "% (co. comm = brok. rate * comm. rec'd)"
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
        'nbBrok_rate
        '
        Me.nbBrok_rate.Enabled = False
        Me.nbBrok_rate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbBrok_rate.Location = New System.Drawing.Point(83, 461)
        Me.nbBrok_rate.Name = "nbBrok_rate"
        Me.nbBrok_rate.Size = New System.Drawing.Size(57, 20)
        Me.nbBrok_rate.TabIndex = 11
        Me.nbBrok_rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
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
        'dgvRateList
        '
        Me.dgvRateList.AllowUserToAddRows = False
        Me.dgvRateList.AllowUserToDeleteRows = False
        Me.dgvRateList.AllowUserToResizeRows = False
        Me.dgvRateList.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRateList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRateList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.srid, Me.comm_month, Me.misc_desc, Me.turnover_type, Me.turnover_from, Me.turnover_to, Me.turnover, Me.comm_rate, Me.Brokerage_rate})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRateList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvRateList.Location = New System.Drawing.Point(196, 0)
        Me.dgvRateList.MultiSelect = False
        Me.dgvRateList.Name = "dgvRateList"
        Me.dgvRateList.ReadOnly = True
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRateList.RowHeadersDefaultCellStyle = DataGridViewCellStyle5
        Me.dgvRateList.RowHeadersVisible = False
        Me.dgvRateList.RowTemplate.Height = 24
        Me.dgvRateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRateList.Size = New System.Drawing.Size(580, 306)
        Me.dgvRateList.TabIndex = 1
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(3, 464)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 14)
        Me.Label12.TabIndex = 344
        Me.Label12.Text = "Brok. Rate"
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
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(471, 31)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 14)
        Me.Label11.TabIndex = 343
        Me.Label11.Text = "AE"
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
        'txtSrcAE
        '
        Me.txtSrcAE.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtSrcAE.Location = New System.Drawing.Point(493, 26)
        Me.txtSrcAE.Name = "txtSrcAE"
        Me.txtSrcAE.Size = New System.Drawing.Size(82, 21)
        Me.txtSrcAE.TabIndex = 3
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(170, 1)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(398, 22)
        Me.lblTitle.TabIndex = 329
        Me.lblTitle.Text = "Securities Commission Rate Table (by AE)"
        '
        'cbConsolidate
        '
        Me.cbConsolidate.AutoSize = True
        Me.cbConsolidate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbConsolidate.Location = New System.Drawing.Point(83, 394)
        Me.cbConsolidate.Name = "cbConsolidate"
        Me.cbConsolidate.Size = New System.Drawing.Size(82, 18)
        Me.cbConsolidate.TabIndex = 7
        Me.cbConsolidate.Text = "Consolidate"
        Me.cbConsolidate.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(146, 440)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(187, 14)
        Me.Label9.TabIndex = 342
        Me.Label9.Text = "% (co. comm = comm rate * turnover)"
        '
        'cboSearchYear
        '
        Me.cboSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchYear.FormattingEnabled = True
        Me.cboSearchYear.Location = New System.Drawing.Point(31, 28)
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(72, 19)
        Me.cboSearchYear.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 418)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 328
        Me.Label1.Text = "Turnover >="
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(108, 30)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 333
        Me.Label4.Text = "Month"
        '
        'lblTurnover
        '
        Me.lblTurnover.AutoSize = True
        Me.lblTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnover.Location = New System.Drawing.Point(208, 418)
        Me.lblTurnover.Name = "lblTurnover"
        Me.lblTurnover.Size = New System.Drawing.Size(106, 14)
        Me.lblTurnover.TabIndex = 341
        Me.lblTurnover.Text = "< ??,???,???,???.??"
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchMonth.FormattingEnabled = True
        Me.cboSearchMonth.Location = New System.Drawing.Point(147, 29)
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(53, 19)
        Me.cboSearchMonth.TabIndex = 1
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(612, 366)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(83, 20)
        Me.txtMonth.TabIndex = 334
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(567, 423)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 13
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAEName.Location = New System.Drawing.Point(190, 366)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(345, 20)
        Me.txtAEName.TabIndex = 337
        '
        'abTurnover
        '
        Me.abTurnover.DecimalPoints = 2
        Me.abTurnover.Enabled = False
        Me.abTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abTurnover.Location = New System.Drawing.Point(83, 415)
        Me.abTurnover.Name = "abTurnover"
        Me.abTurnover.Size = New System.Drawing.Size(119, 20)
        Me.abTurnover.TabIndex = 9
        Me.abTurnover.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(617, 423)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 14
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'nbCommRate
        '
        Me.nbCommRate.Enabled = False
        Me.nbCommRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbCommRate.Location = New System.Drawing.Point(83, 438)
        Me.nbCommRate.Name = "nbCommRate"
        Me.nbCommRate.Size = New System.Drawing.Size(57, 20)
        Me.nbCommRate.TabIndex = 10
        Me.nbCommRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupTradeType
        '
        Me.GroupTradeType.Controls.Add(Me.rbNormal)
        Me.GroupTradeType.Controls.Add(Me.rbInternet)
        Me.GroupTradeType.Location = New System.Drawing.Point(190, 380)
        Me.GroupTradeType.Name = "GroupTradeType"
        Me.GroupTradeType.Size = New System.Drawing.Size(151, 33)
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
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(517, 423)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 12
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(3, 441)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 14)
        Me.Label7.TabIndex = 338
        Me.Label7.Text = "Comm. Rate"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(552, 369)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 14)
        Me.Label10.TabIndex = 340
        Me.Label10.Text = "Month"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(689, 25)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(93, 23)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(3, 368)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(21, 14)
        Me.Label6.TabIndex = 336
        Me.Label6.Text = "AE"
        '
        'fontPanel
        '
        Me.fontPanel.Controls.Add(Me.dgvRateList)
        Me.fontPanel.Controls.Add(Me.dgvAEList)
        Me.fontPanel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontPanel.Location = New System.Drawing.Point(6, 56)
        Me.fontPanel.Name = "fontPanel"
        Me.fontPanel.Size = New System.Drawing.Size(779, 306)
        Me.fontPanel.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 30)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 331
        Me.Label3.Text = "Year"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSrchNormal)
        Me.GroupBox1.Controls.Add(Me.rbConsolidate)
        Me.GroupBox1.Controls.Add(Me.rbSrchAll)
        Me.GroupBox1.Controls.Add(Me.rbSrchInternet)
        Me.GroupBox1.Location = New System.Drawing.Point(206, 19)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(259, 31)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(3, 395)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 14)
        Me.Label8.TabIndex = 339
        Me.Label8.Text = "Trade Type"
        '
        'cboAENo
        '
        Me.cboAENo.Enabled = False
        Me.cboAENo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboAENo.FormattingEnabled = True
        Me.cboAENo.Location = New System.Drawing.Point(83, 366)
        Me.cboAENo.Name = "cboAENo"
        Me.cboAENo.Size = New System.Drawing.Size(101, 22)
        Me.cboAENo.TabIndex = 6
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbTurnover)
        Me.GroupBox2.Controls.Add(Me.rbCommRecd)
        Me.GroupBox2.Location = New System.Drawing.Point(343, 405)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(165, 33)
        Me.GroupBox2.TabIndex = 346
        Me.GroupBox2.TabStop = False
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
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.turnover.DefaultCellStyle = DataGridViewCellStyle3
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
        'FrmCommRateTblSAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(787, 489)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.nbBrok_rate)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.txtSrcAE)
        Me.Controls.Add(Me.lblTitle)
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
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.Label7)
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
        Me.Name = "FrmCommRateTblSAE"
        Me.Text = "Securities Commission Rate Table (by AE)"
        Me.Controls.SetChildIndex(Me.cboAENo, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.fontPanel, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.GroupTradeType, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
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
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.txtSrcAE, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.nbBrok_rate, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupTradeType.ResumeLayout(False)
        Me.GroupTradeType.PerformLayout()
        Me.fontPanel.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ae_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgvAEList As System.Windows.Forms.DataGridView
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbConsolidate As ESL.myRadioButton
    Friend WithEvents nbBrok_rate As ESL.myNumericBox
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents rbSrchInternet As ESL.myRadioButton
    Friend WithEvents dgvRateList As System.Windows.Forms.DataGridView
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents rbSrchNormal As ESL.myRadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents rbInternet As ESL.myRadioButton
    Friend WithEvents txtSrcAE As ESL.myTextbox
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cbConsolidate As ESL.myCheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboSearchYear As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblTurnover As System.Windows.Forms.Label
    Friend WithEvents cboSearchMonth As ESL.myComboBox
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents abTurnover As ESL.myAmountBox
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents nbCommRate As ESL.myNumericBox
    Friend WithEvents GroupTradeType As System.Windows.Forms.GroupBox
    Friend WithEvents rbNormal As ESL.myRadioButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents fontPanel As System.Windows.Forms.Panel
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cboAENo As ESL.myComboBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTurnover As ESL.myRadioButton
    Friend WithEvents rbCommRecd As ESL.myRadioButton
    Friend WithEvents srid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brokerage_rate As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
