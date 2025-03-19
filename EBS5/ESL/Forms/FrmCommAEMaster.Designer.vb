<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommAEMaster
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
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dgvAEList = New System.Windows.Forms.DataGridView
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvDetail = New System.Windows.Forms.DataGridView
        Me.txmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.team = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_no_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_group_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_no_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_group_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sec_fut = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.standard_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.standard_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isConsolid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isFOB = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minNorAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minIntAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minNorRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minIntRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.incentive = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bonus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.special_scheme = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.btnAEInfoSearch = New ESL.myButton(Me.components)
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtSrchAEInfo = New ESL.myTextbox
        Me.dgvAEInfoList = New System.Windows.Forms.DataGridView
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnInfoEdit = New ESL.myButton(Me.components)
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtInfoAENameS = New ESL.myTextbox
        Me.btnInfoSave = New ESL.myButton(Me.components)
        Me.cbIR56M = New ESL.myCheckBox(Me.components)
        Me.txtInfoAENo = New ESL.myTextbox
        Me.Label10 = New System.Windows.Forms.Label
        Me.btnInfoCancel = New ESL.myButton(Me.components)
        Me.txtInfoAENameF = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtInfoAEName = New ESL.myTextbox
        Me.txtBankAcc = New ESL.myTextbox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtBankCode = New ESL.myTextbox
        Me.Label11 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtSpecial = New ESL.myTextbox
        Me.cboSpecial = New ESL.myComboBox(Me.components)
        Me.cbSpecial = New ESL.myCheckBox(Me.components)
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSrchAE = New ESL.myTextbox
        Me.cbFOB = New ESL.myCheckBox(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.txtAEName = New ESL.myTextbox
        Me.nbIntRate = New ESL.myNumericBox
        Me.abIntAmt = New ESL.myAmountBox
        Me.nbNorRate = New ESL.myNumericBox
        Me.abNorAmt = New ESL.myAmountBox
        Me.cbStandard = New ESL.myCheckBox(Me.components)
        Me.lblIntRate = New System.Windows.Forms.Label
        Me.lblIntAmt = New System.Windows.Forms.Label
        Me.lblNorRate = New System.Windows.Forms.Label
        Me.lblNorAmt = New System.Windows.Forms.Label
        Me.cbConsolid = New ESL.myCheckBox(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtTeam = New ESL.myTextbox
        Me.cboMgrGrp = New ESL.myComboBox(Me.components)
        Me.cboMgrNo = New ESL.myComboBox(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbSec = New ESL.myRadioButton(Me.components)
        Me.rbFut = New ESL.myRadioButton(Me.components)
        Me.txtMonth = New ESL.myTextbox
        Me.cboSearchYear = New ESL.myComboBox(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cbBonus = New ESL.myCheckBox(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cbIncentive = New ESL.myCheckBox(Me.components)
        Me.cboSearchMonth = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSrchIncentive = New ESL.myRadioButton(Me.components)
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.rbSrchBonus = New ESL.myRadioButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.cboAENo = New ESL.myComboBox(Me.components)
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbCopySec = New ESL.myRadioButton(Me.components)
        Me.rbCopyFut = New ESL.myRadioButton(Me.components)
        Me.txtAETo = New ESL.myTextbox
        Me.txtAEFrom = New ESL.myTextbox
        Me.btnCopy = New ESL.myButton(Me.components)
        Me.Label17 = New System.Windows.Forms.Label
        Me.cbAEFrom = New ESL.myComboBox(Me.components)
        Me.cbCopyYear = New ESL.myComboBox(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.cbCopyMonth = New ESL.myComboBox(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.cbAETo = New ESL.myComboBox(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.CachedRptAccIntClsAccDetail1 = New ESL.CachedRptAccIntClsAccDetail
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvAEInfoList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(784, 546)
        Me.btnCancel.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(728, 546)
        Me.btnSave.TabIndex = 4
        '
        'dgvAEList
        '
        Me.dgvAEList.AllowUserToAddRows = False
        Me.dgvAEList.AllowUserToDeleteRows = False
        Me.dgvAEList.AllowUserToResizeRows = False
        Me.dgvAEList.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvAEList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAEList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ae_no})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAEList.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvAEList.Location = New System.Drawing.Point(20, 42)
        Me.dgvAEList.MultiSelect = False
        Me.dgvAEList.Name = "dgvAEList"
        Me.dgvAEList.ReadOnly = True
        Me.dgvAEList.RowHeadersVisible = False
        Me.dgvAEList.RowTemplate.Height = 24
        Me.dgvAEList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAEList.Size = New System.Drawing.Size(120, 306)
        Me.dgvAEList.TabIndex = 4
        '
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "AE No."
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.AllowUserToResizeRows = False
        Me.dgvDetail.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txmonth, Me.team, Me.man_no_s, Me.man_group_s, Me.man_no_f, Me.man_group_f, Me.sec_fut, Me.standard_s, Me.standard_f, Me.isConsolid, Me.isFOB, Me.minNorAmt, Me.minIntAmt, Me.minNorRate, Me.minIntRate, Me.incentive, Me.bonus, Me.special_scheme})
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetail.DefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDetail.Location = New System.Drawing.Point(146, 42)
        Me.dgvDetail.MultiSelect = False
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.RowTemplate.Height = 24
        Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetail.Size = New System.Drawing.Size(639, 306)
        Me.dgvDetail.TabIndex = 5
        '
        'txmonth
        '
        Me.txmonth.DataPropertyName = "txmonth"
        Me.txmonth.HeaderText = "Month"
        Me.txmonth.Name = "txmonth"
        Me.txmonth.ReadOnly = True
        Me.txmonth.Width = 60
        '
        'team
        '
        Me.team.DataPropertyName = "team"
        Me.team.HeaderText = "Team"
        Me.team.Name = "team"
        Me.team.ReadOnly = True
        '
        'man_no_s
        '
        Me.man_no_s.DataPropertyName = "man_no_s"
        Me.man_no_s.HeaderText = "AE Mgr (Securities)"
        Me.man_no_s.Name = "man_no_s"
        Me.man_no_s.ReadOnly = True
        Me.man_no_s.Width = 80
        '
        'man_group_s
        '
        Me.man_group_s.DataPropertyName = "man_group_s"
        Me.man_group_s.HeaderText = "Mgr Grp (Securities)"
        Me.man_group_s.Name = "man_group_s"
        Me.man_group_s.ReadOnly = True
        Me.man_group_s.Width = 80
        '
        'man_no_f
        '
        Me.man_no_f.DataPropertyName = "man_no_f"
        Me.man_no_f.HeaderText = "AE Mgr (Futures)"
        Me.man_no_f.Name = "man_no_f"
        Me.man_no_f.ReadOnly = True
        Me.man_no_f.Width = 80
        '
        'man_group_f
        '
        Me.man_group_f.DataPropertyName = "man_group_f"
        Me.man_group_f.HeaderText = "Mgr Grp (Futures)"
        Me.man_group_f.Name = "man_group_f"
        Me.man_group_f.ReadOnly = True
        Me.man_group_f.Width = 80
        '
        'sec_fut
        '
        Me.sec_fut.DataPropertyName = "sec_fut"
        Me.sec_fut.HeaderText = "Market"
        Me.sec_fut.Name = "sec_fut"
        Me.sec_fut.ReadOnly = True
        Me.sec_fut.Width = 70
        '
        'standard_s
        '
        Me.standard_s.DataPropertyName = "standard_s"
        Me.standard_s.HeaderText = "Standard (Securities)"
        Me.standard_s.Name = "standard_s"
        Me.standard_s.ReadOnly = True
        Me.standard_s.Width = 70
        '
        'standard_f
        '
        Me.standard_f.DataPropertyName = "standard_f"
        Me.standard_f.HeaderText = "Standard (Futures)"
        Me.standard_f.Name = "standard_f"
        Me.standard_f.ReadOnly = True
        Me.standard_f.Width = 70
        '
        'isConsolid
        '
        Me.isConsolid.DataPropertyName = "isConsolid"
        Me.isConsolid.HeaderText = "Consolidate (Nor and Int)"
        Me.isConsolid.Name = "isConsolid"
        Me.isConsolid.ReadOnly = True
        Me.isConsolid.Width = 70
        '
        'isFOB
        '
        Me.isFOB.DataPropertyName = "isFOB"
        Me.isFOB.HeaderText = "Consolidate (Fut and Int)"
        Me.isFOB.Name = "isFOB"
        Me.isFOB.ReadOnly = True
        '
        'minNorAmt
        '
        Me.minNorAmt.DataPropertyName = "minNorAmt"
        Me.minNorAmt.HeaderText = "Min. Nor. Amt."
        Me.minNorAmt.Name = "minNorAmt"
        Me.minNorAmt.ReadOnly = True
        '
        'minIntAmt
        '
        Me.minIntAmt.DataPropertyName = "minIntAmt"
        Me.minIntAmt.HeaderText = "Min. Int. Amt."
        Me.minIntAmt.Name = "minIntAmt"
        Me.minIntAmt.ReadOnly = True
        '
        'minNorRate
        '
        Me.minNorRate.DataPropertyName = "minNorRate"
        Me.minNorRate.HeaderText = "Min. Nor. Rate"
        Me.minNorRate.Name = "minNorRate"
        Me.minNorRate.ReadOnly = True
        '
        'minIntRate
        '
        Me.minIntRate.DataPropertyName = "minIntRate"
        Me.minIntRate.HeaderText = "Min. Int. Rate"
        Me.minIntRate.Name = "minIntRate"
        Me.minIntRate.ReadOnly = True
        '
        'incentive
        '
        Me.incentive.DataPropertyName = "incentive"
        Me.incentive.HeaderText = "Incentive"
        Me.incentive.Name = "incentive"
        Me.incentive.ReadOnly = True
        Me.incentive.Width = 55
        '
        'bonus
        '
        Me.bonus.DataPropertyName = "bonus"
        Me.bonus.HeaderText = "Bonus"
        Me.bonus.Name = "bonus"
        Me.bonus.ReadOnly = True
        Me.bonus.Width = 55
        '
        'special_scheme
        '
        Me.special_scheme.DataPropertyName = "special_scheme"
        Me.special_scheme.HeaderText = "Special Scheme"
        Me.special_scheme.Name = "special_scheme"
        Me.special_scheme.ReadOnly = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.TabControl1)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(9, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(825, 530)
        Me.Panel1.TabIndex = 0
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(7, 6)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(812, 519)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Linen
        Me.TabPage1.Controls.Add(Me.btnAEInfoSearch)
        Me.TabPage1.Controls.Add(Me.Label19)
        Me.TabPage1.Controls.Add(Me.txtSrchAEInfo)
        Me.TabPage1.Controls.Add(Me.dgvAEInfoList)
        Me.TabPage1.Controls.Add(Me.btnInfoEdit)
        Me.TabPage1.Controls.Add(Me.Label12)
        Me.TabPage1.Controls.Add(Me.txtInfoAENameS)
        Me.TabPage1.Controls.Add(Me.btnInfoSave)
        Me.TabPage1.Controls.Add(Me.cbIR56M)
        Me.TabPage1.Controls.Add(Me.txtInfoAENo)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.btnInfoCancel)
        Me.TabPage1.Controls.Add(Me.txtInfoAENameF)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.txtInfoAEName)
        Me.TabPage1.Controls.Add(Me.txtBankAcc)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.txtBankCode)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Location = New System.Drawing.Point(4, 23)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(804, 492)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "AE Info"
        '
        'btnAEInfoSearch
        '
        Me.btnAEInfoSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAEInfoSearch.Location = New System.Drawing.Point(139, 12)
        Me.btnAEInfoSearch.Name = "btnAEInfoSearch"
        Me.btnAEInfoSearch.Size = New System.Drawing.Size(83, 23)
        Me.btnAEInfoSearch.TabIndex = 1
        Me.btnAEInfoSearch.Text = "Search"
        Me.btnAEInfoSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAEInfoSearch.UseVisualStyleBackColor = True
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(18, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(21, 14)
        Me.Label19.TabIndex = 127
        Me.Label19.Text = "AE"
        '
        'txtSrchAEInfo
        '
        Me.txtSrchAEInfo.Location = New System.Drawing.Point(45, 14)
        Me.txtSrchAEInfo.Name = "txtSrchAEInfo"
        Me.txtSrchAEInfo.Size = New System.Drawing.Size(84, 20)
        Me.txtSrchAEInfo.TabIndex = 0
        '
        'dgvAEInfoList
        '
        Me.dgvAEInfoList.AllowUserToAddRows = False
        Me.dgvAEInfoList.AllowUserToDeleteRows = False
        Me.dgvAEInfoList.AllowUserToResizeRows = False
        Me.dgvAEInfoList.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvAEInfoList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAEInfoList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvAEInfoList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvAEInfoList.Location = New System.Drawing.Point(21, 55)
        Me.dgvAEInfoList.MultiSelect = False
        Me.dgvAEInfoList.Name = "dgvAEInfoList"
        Me.dgvAEInfoList.ReadOnly = True
        Me.dgvAEInfoList.RowHeadersVisible = False
        Me.dgvAEInfoList.RowTemplate.Height = 24
        Me.dgvAEInfoList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAEInfoList.Size = New System.Drawing.Size(120, 373)
        Me.dgvAEInfoList.TabIndex = 2
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ae_no"
        Me.DataGridViewTextBoxColumn1.HeaderText = "AE No."
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        '
        'btnInfoEdit
        '
        Me.btnInfoEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInfoEdit.Location = New System.Drawing.Point(290, 373)
        Me.btnInfoEdit.Name = "btnInfoEdit"
        Me.btnInfoEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnInfoEdit.TabIndex = 9
        Me.btnInfoEdit.Text = "Edit"
        Me.btnInfoEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnInfoEdit.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Enabled = False
        Me.Label12.Location = New System.Drawing.Point(163, 78)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 14)
        Me.Label12.TabIndex = 116
        Me.Label12.Text = "AE No."
        '
        'txtInfoAENameS
        '
        Me.txtInfoAENameS.Enabled = False
        Me.txtInfoAENameS.Location = New System.Drawing.Point(294, 129)
        Me.txtInfoAENameS.Name = "txtInfoAENameS"
        Me.txtInfoAENameS.Size = New System.Drawing.Size(158, 20)
        Me.txtInfoAENameS.TabIndex = 5
        '
        'btnInfoSave
        '
        Me.btnInfoSave.Enabled = False
        Me.btnInfoSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInfoSave.Location = New System.Drawing.Point(346, 373)
        Me.btnInfoSave.Name = "btnInfoSave"
        Me.btnInfoSave.Size = New System.Drawing.Size(50, 55)
        Me.btnInfoSave.TabIndex = 10
        Me.btnInfoSave.Text = "Save"
        Me.btnInfoSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnInfoSave.UseVisualStyleBackColor = True
        '
        'cbIR56M
        '
        Me.cbIR56M.AutoSize = True
        Me.cbIR56M.Enabled = False
        Me.cbIR56M.Location = New System.Drawing.Point(391, 77)
        Me.cbIR56M.Name = "cbIR56M"
        Me.cbIR56M.Size = New System.Drawing.Size(55, 18)
        Me.cbIR56M.TabIndex = 2
        Me.cbIR56M.Text = "IR56M"
        Me.cbIR56M.UseVisualStyleBackColor = True
        '
        'txtInfoAENo
        '
        Me.txtInfoAENo.Enabled = False
        Me.txtInfoAENo.Location = New System.Drawing.Point(294, 75)
        Me.txtInfoAENo.Name = "txtInfoAENo"
        Me.txtInfoAENo.Size = New System.Drawing.Size(91, 20)
        Me.txtInfoAENo.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Enabled = False
        Me.Label10.Location = New System.Drawing.Point(163, 186)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(59, 14)
        Me.Label10.TabIndex = 113
        Me.Label10.Text = "Bank Code"
        '
        'btnInfoCancel
        '
        Me.btnInfoCancel.Enabled = False
        Me.btnInfoCancel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInfoCancel.Location = New System.Drawing.Point(402, 373)
        Me.btnInfoCancel.Name = "btnInfoCancel"
        Me.btnInfoCancel.Size = New System.Drawing.Size(50, 55)
        Me.btnInfoCancel.TabIndex = 11
        Me.btnInfoCancel.Text = "Cancel"
        Me.btnInfoCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnInfoCancel.UseVisualStyleBackColor = True
        '
        'txtInfoAENameF
        '
        Me.txtInfoAENameF.Enabled = False
        Me.txtInfoAENameF.Location = New System.Drawing.Point(294, 156)
        Me.txtInfoAENameF.Name = "txtInfoAENameF"
        Me.txtInfoAENameF.Size = New System.Drawing.Size(158, 20)
        Me.txtInfoAENameF.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Enabled = False
        Me.Label5.Location = New System.Drawing.Point(163, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(51, 14)
        Me.Label5.TabIndex = 110
        Me.Label5.Text = "AE Name"
        '
        'txtInfoAEName
        '
        Me.txtInfoAEName.Enabled = False
        Me.txtInfoAEName.Location = New System.Drawing.Point(294, 102)
        Me.txtInfoAEName.Name = "txtInfoAEName"
        Me.txtInfoAEName.Size = New System.Drawing.Size(158, 20)
        Me.txtInfoAEName.TabIndex = 4
        '
        'txtBankAcc
        '
        Me.txtBankAcc.Enabled = False
        Me.txtBankAcc.Location = New System.Drawing.Point(294, 210)
        Me.txtBankAcc.Name = "txtBankAcc"
        Me.txtBankAcc.Size = New System.Drawing.Size(158, 20)
        Me.txtBankAcc.TabIndex = 8
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Enabled = False
        Me.Label9.Location = New System.Drawing.Point(163, 159)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(99, 14)
        Me.Label9.TabIndex = 112
        Me.Label9.Text = "AE Name (Futures)"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Enabled = False
        Me.Label8.Location = New System.Drawing.Point(163, 132)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(110, 14)
        Me.Label8.TabIndex = 111
        Me.Label8.Text = "AE Name (Securities)"
        '
        'txtBankCode
        '
        Me.txtBankCode.Enabled = False
        Me.txtBankCode.Location = New System.Drawing.Point(294, 183)
        Me.txtBankCode.Name = "txtBankCode"
        Me.txtBankCode.Size = New System.Drawing.Size(158, 20)
        Me.txtBankCode.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Enabled = False
        Me.Label11.Location = New System.Drawing.Point(163, 213)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 14)
        Me.Label11.TabIndex = 114
        Me.Label11.Text = "Bank A/C No."
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Linen
        Me.TabPage2.Controls.Add(Me.txtSpecial)
        Me.TabPage2.Controls.Add(Me.cboSpecial)
        Me.TabPage2.Controls.Add(Me.cbSpecial)
        Me.TabPage2.Controls.Add(Me.Label18)
        Me.TabPage2.Controls.Add(Me.txtSrchAE)
        Me.TabPage2.Controls.Add(Me.cbFOB)
        Me.TabPage2.Controls.Add(Me.btnSearch)
        Me.TabPage2.Controls.Add(Me.txtAEName)
        Me.TabPage2.Controls.Add(Me.nbIntRate)
        Me.TabPage2.Controls.Add(Me.abIntAmt)
        Me.TabPage2.Controls.Add(Me.nbNorRate)
        Me.TabPage2.Controls.Add(Me.abNorAmt)
        Me.TabPage2.Controls.Add(Me.cbStandard)
        Me.TabPage2.Controls.Add(Me.lblIntRate)
        Me.TabPage2.Controls.Add(Me.lblIntAmt)
        Me.TabPage2.Controls.Add(Me.lblNorRate)
        Me.TabPage2.Controls.Add(Me.lblNorAmt)
        Me.TabPage2.Controls.Add(Me.cbConsolid)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.txtTeam)
        Me.TabPage2.Controls.Add(Me.cboMgrGrp)
        Me.TabPage2.Controls.Add(Me.cboMgrNo)
        Me.TabPage2.Controls.Add(Me.GroupBox2)
        Me.TabPage2.Controls.Add(Me.txtMonth)
        Me.TabPage2.Controls.Add(Me.cboSearchYear)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.dgvAEList)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.dgvDetail)
        Me.TabPage2.Controls.Add(Me.cbBonus)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.cbIncentive)
        Me.TabPage2.Controls.Add(Me.cboSearchMonth)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.GroupBox1)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.cboAENo)
        Me.TabPage2.Location = New System.Drawing.Point(4, 23)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(804, 492)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "AE Detail"
        '
        'txtSpecial
        '
        Me.txtSpecial.Enabled = False
        Me.txtSpecial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSpecial.Location = New System.Drawing.Point(586, 458)
        Me.txtSpecial.Name = "txtSpecial"
        Me.txtSpecial.Size = New System.Drawing.Size(85, 20)
        Me.txtSpecial.TabIndex = 128
        Me.txtSpecial.Visible = False
        '
        'cboSpecial
        '
        Me.cboSpecial.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSpecial.Enabled = False
        Me.cboSpecial.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSpecial.FormattingEnabled = True
        Me.cboSpecial.Location = New System.Drawing.Point(240, 459)
        Me.cboSpecial.Name = "cboSpecial"
        Me.cboSpecial.Size = New System.Drawing.Size(340, 19)
        Me.cboSpecial.TabIndex = 127
        Me.cboSpecial.Visible = False
        '
        'cbSpecial
        '
        Me.cbSpecial.AutoSize = True
        Me.cbSpecial.Enabled = False
        Me.cbSpecial.Location = New System.Drawing.Point(132, 459)
        Me.cbSpecial.Name = "cbSpecial"
        Me.cbSpecial.Size = New System.Drawing.Size(103, 18)
        Me.cbSpecial.TabIndex = 126
        Me.cbSpecial.Text = "Special Scheme"
        Me.cbSpecial.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(447, 21)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 14)
        Me.Label18.TabIndex = 125
        Me.Label18.Text = "AE no."
        '
        'txtSrchAE
        '
        Me.txtSrchAE.Location = New System.Drawing.Point(492, 16)
        Me.txtSrchAE.Name = "txtSrchAE"
        Me.txtSrchAE.Size = New System.Drawing.Size(100, 20)
        Me.txtSrchAE.TabIndex = 3
        '
        'cbFOB
        '
        Me.cbFOB.AutoSize = True
        Me.cbFOB.Enabled = False
        Me.cbFOB.Location = New System.Drawing.Point(132, 434)
        Me.cbFOB.Name = "cbFOB"
        Me.cbFOB.Size = New System.Drawing.Size(185, 18)
        Me.cbFOB.TabIndex = 18
        Me.cbFOB.Text = "Consolidate (Futures and Option)"
        Me.cbFOB.UseVisualStyleBackColor = True
        Me.cbFOB.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(701, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(83, 23)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAEName.Location = New System.Drawing.Point(191, 357)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(249, 20)
        Me.txtAEName.TabIndex = 6
        '
        'nbIntRate
        '
        Me.nbIntRate.Enabled = False
        Me.nbIntRate.Location = New System.Drawing.Point(599, 407)
        Me.nbIntRate.Name = "nbIntRate"
        Me.nbIntRate.Size = New System.Drawing.Size(72, 20)
        Me.nbIntRate.TabIndex = 17
        Me.nbIntRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbIntRate.Visible = False
        '
        'abIntAmt
        '
        Me.abIntAmt.DecimalPoints = 2
        Me.abIntAmt.Enabled = False
        Me.abIntAmt.Location = New System.Drawing.Point(599, 432)
        Me.abIntAmt.Name = "abIntAmt"
        Me.abIntAmt.Size = New System.Drawing.Size(72, 20)
        Me.abIntAmt.TabIndex = 20
        Me.abIntAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.abIntAmt.Visible = False
        '
        'nbNorRate
        '
        Me.nbNorRate.Enabled = False
        Me.nbNorRate.Location = New System.Drawing.Point(425, 407)
        Me.nbNorRate.Name = "nbNorRate"
        Me.nbNorRate.Size = New System.Drawing.Size(72, 20)
        Me.nbNorRate.TabIndex = 16
        Me.nbNorRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nbNorRate.Visible = False
        '
        'abNorAmt
        '
        Me.abNorAmt.DecimalPoints = 2
        Me.abNorAmt.Enabled = False
        Me.abNorAmt.Location = New System.Drawing.Point(425, 432)
        Me.abNorAmt.Name = "abNorAmt"
        Me.abNorAmt.Size = New System.Drawing.Size(72, 20)
        Me.abNorAmt.TabIndex = 19
        Me.abNorAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.abNorAmt.Visible = False
        '
        'cbStandard
        '
        Me.cbStandard.AutoSize = True
        Me.cbStandard.Enabled = False
        Me.cbStandard.Location = New System.Drawing.Point(19, 409)
        Me.cbStandard.Name = "cbStandard"
        Me.cbStandard.Size = New System.Drawing.Size(107, 18)
        Me.cbStandard.TabIndex = 14
        Me.cbStandard.Text = "Use Default Rate"
        Me.cbStandard.UseVisualStyleBackColor = True
        '
        'lblIntRate
        '
        Me.lblIntRate.AutoSize = True
        Me.lblIntRate.Location = New System.Drawing.Point(503, 410)
        Me.lblIntRate.Name = "lblIntRate"
        Me.lblIntRate.Size = New System.Drawing.Size(90, 14)
        Me.lblIntRate.TabIndex = 122
        Me.lblIntRate.Text = "Min. Internet Rate"
        Me.lblIntRate.Visible = False
        '
        'lblIntAmt
        '
        Me.lblIntAmt.AutoSize = True
        Me.lblIntAmt.Location = New System.Drawing.Point(503, 435)
        Me.lblIntAmt.Name = "lblIntAmt"
        Me.lblIntAmt.Size = New System.Drawing.Size(90, 14)
        Me.lblIntAmt.TabIndex = 120
        Me.lblIntAmt.Text = "Min. Internet Amt."
        Me.lblIntAmt.Visible = False
        '
        'lblNorRate
        '
        Me.lblNorRate.AutoSize = True
        Me.lblNorRate.Location = New System.Drawing.Point(332, 410)
        Me.lblNorRate.Name = "lblNorRate"
        Me.lblNorRate.Size = New System.Drawing.Size(87, 14)
        Me.lblNorRate.TabIndex = 121
        Me.lblNorRate.Text = "Min. Normal Rate"
        Me.lblNorRate.Visible = False
        '
        'lblNorAmt
        '
        Me.lblNorAmt.AutoSize = True
        Me.lblNorAmt.Location = New System.Drawing.Point(332, 435)
        Me.lblNorAmt.Name = "lblNorAmt"
        Me.lblNorAmt.Size = New System.Drawing.Size(87, 14)
        Me.lblNorAmt.TabIndex = 15
        Me.lblNorAmt.Text = "Min. Normal Amt."
        Me.lblNorAmt.Visible = False
        '
        'cbConsolid
        '
        Me.cbConsolid.AutoSize = True
        Me.cbConsolid.Enabled = False
        Me.cbConsolid.Location = New System.Drawing.Point(132, 409)
        Me.cbConsolid.Name = "cbConsolid"
        Me.cbConsolid.Size = New System.Drawing.Size(174, 18)
        Me.cbConsolid.TabIndex = 15
        Me.cbConsolid.Text = "Consolidate (Normal + Internet)"
        Me.cbConsolid.UseVisualStyleBackColor = True
        Me.cbConsolid.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(17, 385)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(33, 14)
        Me.Label13.TabIndex = 112
        Me.Label13.Text = "Team"
        '
        'txtTeam
        '
        Me.txtTeam.Enabled = False
        Me.txtTeam.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTeam.Location = New System.Drawing.Point(56, 383)
        Me.txtTeam.Name = "txtTeam"
        Me.txtTeam.Size = New System.Drawing.Size(203, 20)
        Me.txtTeam.TabIndex = 9
        '
        'cboMgrGrp
        '
        Me.cboMgrGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMgrGrp.Enabled = False
        Me.cboMgrGrp.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboMgrGrp.FormattingEnabled = True
        Me.cboMgrGrp.Location = New System.Drawing.Point(494, 384)
        Me.cboMgrGrp.Name = "cboMgrGrp"
        Me.cboMgrGrp.Size = New System.Drawing.Size(122, 19)
        Me.cboMgrGrp.TabIndex = 11
        '
        'cboMgrNo
        '
        Me.cboMgrNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMgrNo.Enabled = False
        Me.cboMgrNo.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboMgrNo.FormattingEnabled = True
        Me.cboMgrNo.Location = New System.Drawing.Point(311, 384)
        Me.cboMgrNo.Name = "cboMgrNo"
        Me.cboMgrNo.Size = New System.Drawing.Size(122, 19)
        Me.cboMgrNo.TabIndex = 10
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbSec)
        Me.GroupBox2.Controls.Add(Me.rbFut)
        Me.GroupBox2.Location = New System.Drawing.Point(616, 348)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 30)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        '
        'rbSec
        '
        Me.rbSec.AutoSize = True
        Me.rbSec.Checked = True
        Me.rbSec.Enabled = False
        Me.rbSec.Location = New System.Drawing.Point(6, 9)
        Me.rbSec.Name = "rbSec"
        Me.rbSec.Size = New System.Drawing.Size(73, 18)
        Me.rbSec.TabIndex = 0
        Me.rbSec.TabStop = True
        Me.rbSec.Text = "Securities"
        Me.rbSec.UseVisualStyleBackColor = True
        '
        'rbFut
        '
        Me.rbFut.AutoSize = True
        Me.rbFut.Enabled = False
        Me.rbFut.Location = New System.Drawing.Point(81, 9)
        Me.rbFut.Name = "rbFut"
        Me.rbFut.Size = New System.Drawing.Size(62, 18)
        Me.rbFut.TabIndex = 1
        Me.rbFut.Text = "Futures"
        Me.rbFut.UseVisualStyleBackColor = True
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(488, 357)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(122, 20)
        Me.txtMonth.TabIndex = 7
        '
        'cboSearchYear
        '
        Me.cboSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchYear.Enabled = False
        Me.cboSearchYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchYear.FormattingEnabled = True
        Me.cboSearchYear.Location = New System.Drawing.Point(54, 17)
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(72, 19)
        Me.cboSearchYear.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(439, 385)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 14)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Mgr Grp."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(17, 359)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "AE No."
        '
        'cbBonus
        '
        Me.cbBonus.AutoSize = True
        Me.cbBonus.Enabled = False
        Me.cbBonus.Location = New System.Drawing.Point(701, 385)
        Me.cbBonus.Name = "cbBonus"
        Me.cbBonus.Size = New System.Drawing.Size(57, 18)
        Me.cbBonus.TabIndex = 13
        Me.cbBonus.Text = "Bonus"
        Me.cbBonus.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(16, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Year"
        '
        'cbIncentive
        '
        Me.cbIncentive.AutoSize = True
        Me.cbIncentive.Enabled = False
        Me.cbIncentive.Location = New System.Drawing.Point(626, 385)
        Me.cbIncentive.Name = "cbIncentive"
        Me.cbIncentive.Size = New System.Drawing.Size(69, 18)
        Me.cbIncentive.TabIndex = 12
        Me.cbIncentive.Text = "Incentive"
        Me.cbIncentive.UseVisualStyleBackColor = True
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchMonth.Enabled = False
        Me.cboSearchMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchMonth.FormattingEnabled = True
        Me.cboSearchMonth.Location = New System.Drawing.Point(174, 17)
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(53, 19)
        Me.cboSearchMonth.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(446, 359)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 14)
        Me.Label2.TabIndex = 105
        Me.Label2.Text = "Month"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(131, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Month"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSrchIncentive)
        Me.GroupBox1.Controls.Add(Me.rbSrchAll)
        Me.GroupBox1.Controls.Add(Me.rbSrchBonus)
        Me.GroupBox1.Location = New System.Drawing.Point(240, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(201, 31)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'rbSrchIncentive
        '
        Me.rbSrchIncentive.AutoSize = True
        Me.rbSrchIncentive.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchIncentive.Location = New System.Drawing.Point(6, 10)
        Me.rbSrchIncentive.Name = "rbSrchIncentive"
        Me.rbSrchIncentive.Size = New System.Drawing.Size(68, 18)
        Me.rbSrchIncentive.TabIndex = 0
        Me.rbSrchIncentive.Text = "Incentive"
        Me.rbSrchIncentive.UseVisualStyleBackColor = True
        '
        'rbSrchAll
        '
        Me.rbSrchAll.AutoSize = True
        Me.rbSrchAll.Checked = True
        Me.rbSrchAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchAll.Location = New System.Drawing.Point(142, 10)
        Me.rbSrchAll.Name = "rbSrchAll"
        Me.rbSrchAll.Size = New System.Drawing.Size(37, 18)
        Me.rbSrchAll.TabIndex = 2
        Me.rbSrchAll.TabStop = True
        Me.rbSrchAll.Text = "All"
        Me.rbSrchAll.UseVisualStyleBackColor = True
        '
        'rbSrchBonus
        '
        Me.rbSrchBonus.AutoSize = True
        Me.rbSrchBonus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchBonus.Location = New System.Drawing.Point(80, 10)
        Me.rbSrchBonus.Name = "rbSrchBonus"
        Me.rbSrchBonus.Size = New System.Drawing.Size(56, 18)
        Me.rbSrchBonus.TabIndex = 1
        Me.rbSrchBonus.Text = "Bonus"
        Me.rbSrchBonus.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(265, 385)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(44, 14)
        Me.Label6.TabIndex = 107
        Me.Label6.Text = "Mgr No."
        '
        'cboAENo
        '
        Me.cboAENo.Enabled = False
        Me.cboAENo.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboAENo.FormattingEnabled = True
        Me.cboAENo.Location = New System.Drawing.Point(63, 358)
        Me.cboAENo.Name = "cboAENo"
        Me.cboAENo.Size = New System.Drawing.Size(122, 19)
        Me.cboAENo.TabIndex = 5
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Linen
        Me.TabPage3.Controls.Add(Me.GroupBox3)
        Me.TabPage3.Controls.Add(Me.txtAETo)
        Me.TabPage3.Controls.Add(Me.txtAEFrom)
        Me.TabPage3.Controls.Add(Me.btnCopy)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.cbAEFrom)
        Me.TabPage3.Controls.Add(Me.cbCopyYear)
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.cbCopyMonth)
        Me.TabPage3.Controls.Add(Me.Label16)
        Me.TabPage3.Controls.Add(Me.cbAETo)
        Me.TabPage3.Location = New System.Drawing.Point(4, 23)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(804, 492)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Copy AE Detail"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbCopySec)
        Me.GroupBox3.Controls.Add(Me.rbCopyFut)
        Me.GroupBox3.Location = New System.Drawing.Point(235, 62)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(163, 30)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'rbCopySec
        '
        Me.rbCopySec.AutoSize = True
        Me.rbCopySec.Checked = True
        Me.rbCopySec.Enabled = False
        Me.rbCopySec.Location = New System.Drawing.Point(6, 9)
        Me.rbCopySec.Name = "rbCopySec"
        Me.rbCopySec.Size = New System.Drawing.Size(73, 18)
        Me.rbCopySec.TabIndex = 0
        Me.rbCopySec.TabStop = True
        Me.rbCopySec.Text = "Securities"
        Me.rbCopySec.UseVisualStyleBackColor = True
        '
        'rbCopyFut
        '
        Me.rbCopyFut.AutoSize = True
        Me.rbCopyFut.Enabled = False
        Me.rbCopyFut.Location = New System.Drawing.Point(81, 9)
        Me.rbCopyFut.Name = "rbCopyFut"
        Me.rbCopyFut.Size = New System.Drawing.Size(62, 18)
        Me.rbCopyFut.TabIndex = 1
        Me.rbCopyFut.Text = "Futures"
        Me.rbCopyFut.UseVisualStyleBackColor = True
        '
        'txtAETo
        '
        Me.txtAETo.Enabled = False
        Me.txtAETo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAETo.Location = New System.Drawing.Point(363, 226)
        Me.txtAETo.Name = "txtAETo"
        Me.txtAETo.Size = New System.Drawing.Size(249, 20)
        Me.txtAETo.TabIndex = 6
        '
        'txtAEFrom
        '
        Me.txtAEFrom.Enabled = False
        Me.txtAEFrom.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAEFrom.Location = New System.Drawing.Point(363, 191)
        Me.txtAEFrom.Name = "txtAEFrom"
        Me.txtAEFrom.Size = New System.Drawing.Size(249, 20)
        Me.txtAEFrom.TabIndex = 4
        '
        'btnCopy
        '
        Me.btnCopy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCopy.Location = New System.Drawing.Point(235, 281)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(50, 55)
        Me.btnCopy.TabIndex = 7
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCopy.UseVisualStyleBackColor = True
        Me.btnCopy.Visible = False
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(162, 228)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(55, 14)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "To AE No."
        '
        'cbAEFrom
        '
        Me.cbAEFrom.Enabled = False
        Me.cbAEFrom.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbAEFrom.FormattingEnabled = True
        Me.cbAEFrom.Location = New System.Drawing.Point(235, 192)
        Me.cbAEFrom.Name = "cbAEFrom"
        Me.cbAEFrom.Size = New System.Drawing.Size(122, 19)
        Me.cbAEFrom.TabIndex = 3
        '
        'cbCopyYear
        '
        Me.cbCopyYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCopyYear.Enabled = False
        Me.cbCopyYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbCopyYear.FormattingEnabled = True
        Me.cbCopyYear.Location = New System.Drawing.Point(235, 113)
        Me.cbCopyYear.Name = "cbCopyYear"
        Me.cbCopyYear.Size = New System.Drawing.Size(72, 19)
        Me.cbCopyYear.TabIndex = 1
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(162, 191)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 14)
        Me.Label14.TabIndex = 110
        Me.Label14.Text = "From AE No."
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(162, 118)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(31, 14)
        Me.Label15.TabIndex = 108
        Me.Label15.Text = "Year"
        '
        'cbCopyMonth
        '
        Me.cbCopyMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbCopyMonth.Enabled = False
        Me.cbCopyMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbCopyMonth.FormattingEnabled = True
        Me.cbCopyMonth.Location = New System.Drawing.Point(235, 150)
        Me.cbCopyMonth.Name = "cbCopyMonth"
        Me.cbCopyMonth.Size = New System.Drawing.Size(72, 19)
        Me.cbCopyMonth.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(162, 151)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 14)
        Me.Label16.TabIndex = 109
        Me.Label16.Text = "Month"
        '
        'cbAETo
        '
        Me.cbAETo.Enabled = False
        Me.cbAETo.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cbAETo.FormattingEnabled = True
        Me.cbAETo.Location = New System.Drawing.Point(235, 227)
        Me.cbAETo.Name = "cbAETo"
        Me.cbAETo.Size = New System.Drawing.Size(122, 19)
        Me.cbAETo.TabIndex = 5
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(616, 546)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        Me.btnEdit.Visible = False
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(560, 546)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        Me.btnAdd.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(672, 546)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        Me.btnDelete.Visible = False
        '
        'FrmCommAEMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(844, 615)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.KeyPreview = True
        Me.Name = "FrmCommAEMaster"
        Me.Text = "AE Master"
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        CType(Me.dgvAEList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvAEInfoList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvAEList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cboSearchYear As ESL.myComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSearchMonth As ESL.myComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchIncentive As ESL.myRadioButton
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents rbSrchBonus As ESL.myRadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents cboAENo As ESL.myComboBox
    Friend WithEvents cbBonus As ESL.myCheckBox
    Friend WithEvents cbIncentive As ESL.myCheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBankAcc As ESL.myTextbox
    Friend WithEvents txtBankCode As ESL.myTextbox
    Friend WithEvents txtInfoAENameF As ESL.myTextbox
    Friend WithEvents txtInfoAENameS As ESL.myTextbox
    Friend WithEvents txtInfoAEName As ESL.myTextbox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbIR56M As ESL.myCheckBox
    Friend WithEvents btnInfoEdit As ESL.myButton
    Friend WithEvents btnInfoSave As ESL.myButton
    Friend WithEvents btnInfoCancel As ESL.myButton
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents dgvAEInfoList As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtInfoAENo As ESL.myTextbox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSec As ESL.myRadioButton
    Friend WithEvents rbFut As ESL.myRadioButton
    Friend WithEvents cboMgrNo As ESL.myComboBox
    Friend WithEvents cboMgrGrp As ESL.myComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtTeam As ESL.myTextbox
    Friend WithEvents cbStandard As ESL.myCheckBox
    Friend WithEvents lblIntRate As System.Windows.Forms.Label
    Friend WithEvents lblNorRate As System.Windows.Forms.Label
    Friend WithEvents lblIntAmt As System.Windows.Forms.Label
    Friend WithEvents lblNorAmt As System.Windows.Forms.Label
    Friend WithEvents cbConsolid As ESL.myCheckBox
    Friend WithEvents nbNorRate As ESL.myNumericBox
    Friend WithEvents abNorAmt As ESL.myAmountBox
    Friend WithEvents nbIntRate As ESL.myNumericBox
    Friend WithEvents abIntAmt As ESL.myAmountBox
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents btnCopy As ESL.myButton
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cbAEFrom As ESL.myComboBox
    Friend WithEvents cbCopyYear As ESL.myComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents cbCopyMonth As ESL.myComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cbAETo As ESL.myComboBox
    Friend WithEvents txtAETo As ESL.myTextbox
    Friend WithEvents txtAEFrom As ESL.myTextbox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbCopySec As ESL.myRadioButton
    Friend WithEvents rbCopyFut As ESL.myRadioButton
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents cbFOB As ESL.myCheckBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSrchAE As ESL.myTextbox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtSrchAEInfo As ESL.myTextbox
    Friend WithEvents btnAEInfoSearch As ESL.myButton
    Friend WithEvents txtSpecial As ESL.myTextbox
    Friend WithEvents cboSpecial As ESL.myComboBox
    Friend WithEvents cbSpecial As ESL.myCheckBox
    Friend WithEvents txmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents team As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_no_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_group_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_no_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_group_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sec_fut As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents standard_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents standard_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isConsolid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isFOB As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minNorAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minIntAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minNorRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minIntRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents incentive As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bonus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents special_scheme As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CachedRptAccIntClsAccDetail1 As ESL.CachedRptAccIntClsAccDetail

End Class
