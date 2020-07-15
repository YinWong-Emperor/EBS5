<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFuturesStatementLHAdj
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFuturesStatementLHAdj))
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnAdjBack = New ESL.myButton(Me.components)
        Me.btnAdjDelete = New ESL.myButton(Me.components)
        Me.btnAdjSave = New ESL.myButton(Me.components)
        Me.btnAdjUndoDelete = New ESL.myButton(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.cbxCounterParty = New ESL.myComboBox(Me.components)
        Me.dgvQryResult = New System.Windows.Forms.DataGridView
        Me.qry_adjnoid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_lhnId = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_adjAction = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_tdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_monthCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_product = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_pl = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_settleDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_monthlyDaily = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_contractSize = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_counterParty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qry_adjRemark = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtpTdate = New ESL.myDateTimePicker
        Me.gbxAdj = New System.Windows.Forms.GroupBox
        Me.txtAdj_AdjRemark = New ESL.myTextbox
        Me.txtAdj_PL = New ESL.myAmountBox
        Me.gbxOrg = New System.Windows.Forms.GroupBox
        Me.txtAdj_AdjRemark_Org = New ESL.myTextbox
        Me.txtAdj_PL_Org = New ESL.myAmountBox
        Me.gbxSearch = New System.Windows.Forms.GroupBox
        Me.rbShowNormal = New System.Windows.Forms.RadioButton
        Me.rbShowAll = New System.Windows.Forms.RadioButton
        Me.rbAdjustedOnly = New System.Windows.Forms.RadioButton
        Me.lblCounterParty = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.gbxSum = New System.Windows.Forms.GroupBox
        Me.txtAdj_PL_Sum = New ESL.myAmountBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.lblAdj_PL = New System.Windows.Forms.Label
        Me.lblVoid = New System.Windows.Forms.Label
        Me.tabctrlMain = New System.Windows.Forms.TabControl
        Me.tabpageView = New System.Windows.Forms.TabPage
        Me.tabpageModify = New System.Windows.Forms.TabPage
        Me.cbxAdj_CounterParty = New ESL.myComboBox(Me.components)
        Me.Label28 = New System.Windows.Forms.Label
        Me.txtAdj_contractSize = New ESL.myAmountBox
        Me.cbxAdj_monthlyDaily = New ESL.myComboBox(Me.components)
        Me.dtpAdj_settleDate = New ESL.myDateTimePicker
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.cbxAdj_Product = New ESL.myComboBox(Me.components)
        Me.txtAdj_MonthCode = New ESL.myTextbox
        Me.Label21 = New System.Windows.Forms.Label
        Me.dtpAdj_tDate = New ESL.myDateTimePicker
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.btnAdjModify = New ESL.myButton(Me.components)
        Me.tabpageAdd = New System.Windows.Forms.TabPage
        Me.btnAddModify = New ESL.myButton(Me.components)
        Me.btnAddDelete = New ESL.myButton(Me.components)
        Me.btnAddSave = New ESL.myButton(Me.components)
        Me.txtAdd_Product = New ESL.myTextbox
        Me.txtAdd_AdjRemark = New ESL.myTextbox
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtAdd_MonthCode = New ESL.myTextbox
        Me.txtAdd_ContractSize = New ESL.myAmountBox
        Me.cbxAdd_MonthlyDaily = New ESL.myComboBox(Me.components)
        Me.dtpAdd_SettleDate = New ESL.myDateTimePicker
        Me.txtAdd_PL = New ESL.myAmountBox
        Me.cbxAdd_CounterParty = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnAddBack = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.dtpAdd_Tdate = New ESL.myDateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtAdj_AdjNoId = New ESL.myTextbox
        Me.txtAdj_LhNId = New ESL.myTextbox
        Me.dtpAdd_LstUpdTime = New ESL.myDateTimePicker
        Me.txtAdd_LstUpdUser = New ESL.myTextbox
        Me.lblAdd_LstUpdTime = New System.Windows.Forms.Label
        Me.lblAdd_LstUpdUser = New System.Windows.Forms.Label
        Me.dtpAdj_LstUpdTime = New ESL.myDateTimePicker
        Me.txtAdj_LstUpdUser = New ESL.myTextbox
        Me.lblAdj_LstUpdTime = New System.Windows.Forms.Label
        Me.lblAdj_LstUpdUser = New System.Windows.Forms.Label
        CType(Me.dgvQryResult, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbxAdj.SuspendLayout()
        Me.gbxOrg.SuspendLayout()
        Me.gbxSearch.SuspendLayout()
        Me.gbxSum.SuspendLayout()
        Me.tabctrlMain.SuspendLayout()
        Me.tabpageView.SuspendLayout()
        Me.tabpageModify.SuspendLayout()
        Me.tabpageAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(684, 514)
        Me.btnCancel.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(628, 514)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnSave.TabIndex = 2
        '
        'btnAdjBack
        '
        Me.btnAdjBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdjBack.Location = New System.Drawing.Point(661, 387)
        Me.btnAdjBack.Name = "btnAdjBack"
        Me.btnAdjBack.Size = New System.Drawing.Size(50, 55)
        Me.btnAdjBack.TabIndex = 16
        Me.btnAdjBack.Text = "Back"
        Me.btnAdjBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdjBack.UseVisualStyleBackColor = True
        '
        'btnAdjDelete
        '
        Me.btnAdjDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdjDelete.Location = New System.Drawing.Point(505, 387)
        Me.btnAdjDelete.Name = "btnAdjDelete"
        Me.btnAdjDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnAdjDelete.TabIndex = 14
        Me.btnAdjDelete.Text = "Delete"
        Me.btnAdjDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdjDelete.UseVisualStyleBackColor = True
        '
        'btnAdjSave
        '
        Me.btnAdjSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdjSave.Location = New System.Drawing.Point(609, 387)
        Me.btnAdjSave.Name = "btnAdjSave"
        Me.btnAdjSave.Size = New System.Drawing.Size(50, 55)
        Me.btnAdjSave.TabIndex = 15
        Me.btnAdjSave.Text = "Save"
        Me.btnAdjSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdjSave.UseVisualStyleBackColor = True
        '
        'btnAdjUndoDelete
        '
        Me.btnAdjUndoDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjUndoDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdjUndoDelete.Location = New System.Drawing.Point(452, 387)
        Me.btnAdjUndoDelete.Name = "btnAdjUndoDelete"
        Me.btnAdjUndoDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnAdjUndoDelete.TabIndex = 13
        Me.btnAdjUndoDelete.Text = "Undo Delete"
        Me.btnAdjUndoDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdjUndoDelete.UseVisualStyleBackColor = True
        Me.btnAdjUndoDelete.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Image = CType(resources.GetObject("btnSearch.Image"), System.Drawing.Image)
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnSearch.Location = New System.Drawing.Point(658, 384)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(50, 55)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cbxCounterParty
        '
        Me.cbxCounterParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCounterParty.FormattingEnabled = True
        Me.cbxCounterParty.Location = New System.Drawing.Point(107, 62)
        Me.cbxCounterParty.Name = "cbxCounterParty"
        Me.cbxCounterParty.Size = New System.Drawing.Size(133, 23)
        Me.cbxCounterParty.TabIndex = 3
        '
        'dgvQryResult
        '
        Me.dgvQryResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQryResult.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvQryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQryResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.qry_adjnoid, Me.qry_lhnId, Me.qry_adjAction, Me.qry_tdate, Me.qry_monthCode, Me.qry_product, Me.qry_pl, Me.qry_settleDate, Me.qry_monthlyDaily, Me.qry_contractSize, Me.qry_counterParty, Me.qry_adjRemark})
        Me.dgvQryResult.GridColor = System.Drawing.Color.Linen
        Me.dgvQryResult.Location = New System.Drawing.Point(9, 6)
        Me.dgvQryResult.MultiSelect = False
        Me.dgvQryResult.Name = "dgvQryResult"
        Me.dgvQryResult.ReadOnly = True
        Me.dgvQryResult.RowHeadersVisible = False
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvQryResult.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvQryResult.RowTemplate.Height = 24
        Me.dgvQryResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvQryResult.Size = New System.Drawing.Size(702, 327)
        Me.dgvQryResult.TabIndex = 0
        '
        'qry_adjnoid
        '
        Me.qry_adjnoid.DataPropertyName = "adjnoid"
        Me.qry_adjnoid.HeaderText = "adjNoId"
        Me.qry_adjnoid.Name = "qry_adjnoid"
        Me.qry_adjnoid.ReadOnly = True
        Me.qry_adjnoid.Visible = False
        '
        'qry_lhnId
        '
        Me.qry_lhnId.DataPropertyName = "lhnid"
        Me.qry_lhnId.HeaderText = "lhNId"
        Me.qry_lhnId.Name = "qry_lhnId"
        Me.qry_lhnId.ReadOnly = True
        Me.qry_lhnId.Visible = False
        '
        'qry_adjAction
        '
        Me.qry_adjAction.DataPropertyName = "adj_action"
        Me.qry_adjAction.HeaderText = "Adj. Action"
        Me.qry_adjAction.Name = "qry_adjAction"
        Me.qry_adjAction.ReadOnly = True
        '
        'qry_tdate
        '
        Me.qry_tdate.DataPropertyName = "tdate"
        Me.qry_tdate.HeaderText = "Trade Date"
        Me.qry_tdate.Name = "qry_tdate"
        Me.qry_tdate.ReadOnly = True
        '
        'qry_monthCode
        '
        Me.qry_monthCode.DataPropertyName = "monthcode"
        Me.qry_monthCode.HeaderText = "Month Code"
        Me.qry_monthCode.Name = "qry_monthCode"
        Me.qry_monthCode.ReadOnly = True
        '
        'qry_product
        '
        Me.qry_product.DataPropertyName = "product"
        Me.qry_product.HeaderText = "Product"
        Me.qry_product.Name = "qry_product"
        Me.qry_product.ReadOnly = True
        '
        'qry_pl
        '
        Me.qry_pl.DataPropertyName = "PL"
        Me.qry_pl.HeaderText = "PL"
        Me.qry_pl.Name = "qry_pl"
        Me.qry_pl.ReadOnly = True
        '
        'qry_settleDate
        '
        Me.qry_settleDate.DataPropertyName = "settle_date"
        Me.qry_settleDate.HeaderText = "Settle Date"
        Me.qry_settleDate.Name = "qry_settleDate"
        Me.qry_settleDate.ReadOnly = True
        '
        'qry_monthlyDaily
        '
        Me.qry_monthlyDaily.DataPropertyName = "monthly_daily"
        Me.qry_monthlyDaily.HeaderText = "Monthly/Daily"
        Me.qry_monthlyDaily.Name = "qry_monthlyDaily"
        Me.qry_monthlyDaily.ReadOnly = True
        '
        'qry_contractSize
        '
        Me.qry_contractSize.DataPropertyName = "contract_size"
        Me.qry_contractSize.HeaderText = "Contract Size"
        Me.qry_contractSize.Name = "qry_contractSize"
        Me.qry_contractSize.ReadOnly = True
        '
        'qry_counterParty
        '
        Me.qry_counterParty.DataPropertyName = "counterparty"
        Me.qry_counterParty.HeaderText = "Counter Party"
        Me.qry_counterParty.Name = "qry_counterParty"
        Me.qry_counterParty.ReadOnly = True
        '
        'qry_adjRemark
        '
        Me.qry_adjRemark.DataPropertyName = "adj_remark"
        Me.qry_adjRemark.HeaderText = "Remark"
        Me.qry_adjRemark.Name = "qry_adjRemark"
        Me.qry_adjRemark.ReadOnly = True
        '
        'dtpTdate
        '
        Me.dtpTdate.CustomFormat = "MM/dd/yyyy"
        Me.dtpTdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTdate.Location = New System.Drawing.Point(107, 31)
        Me.dtpTdate.Name = "dtpTdate"
        Me.dtpTdate.Size = New System.Drawing.Size(133, 21)
        Me.dtpTdate.TabIndex = 1
        '
        'gbxAdj
        '
        Me.gbxAdj.Controls.Add(Me.txtAdj_AdjRemark)
        Me.gbxAdj.Controls.Add(Me.txtAdj_PL)
        Me.gbxAdj.Location = New System.Drawing.Point(102, 113)
        Me.gbxAdj.Name = "gbxAdj"
        Me.gbxAdj.Size = New System.Drawing.Size(163, 212)
        Me.gbxAdj.TabIndex = 4
        Me.gbxAdj.TabStop = False
        Me.gbxAdj.Text = "Adjustment"
        '
        'txtAdj_AdjRemark
        '
        Me.txtAdj_AdjRemark.Location = New System.Drawing.Point(18, 57)
        Me.txtAdj_AdjRemark.Multiline = True
        Me.txtAdj_AdjRemark.Name = "txtAdj_AdjRemark"
        Me.txtAdj_AdjRemark.Size = New System.Drawing.Size(133, 141)
        Me.txtAdj_AdjRemark.TabIndex = 5
        '
        'txtAdj_PL
        '
        Me.txtAdj_PL.DecimalPoints = 4
        Me.txtAdj_PL.Location = New System.Drawing.Point(18, 30)
        Me.txtAdj_PL.Name = "txtAdj_PL"
        Me.txtAdj_PL.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_PL.TabIndex = 4
        Me.txtAdj_PL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbxOrg
        '
        Me.gbxOrg.Controls.Add(Me.txtAdj_AdjRemark_Org)
        Me.gbxOrg.Controls.Add(Me.txtAdj_PL_Org)
        Me.gbxOrg.Location = New System.Drawing.Point(273, 113)
        Me.gbxOrg.Name = "gbxOrg"
        Me.gbxOrg.Size = New System.Drawing.Size(167, 212)
        Me.gbxOrg.TabIndex = 5
        Me.gbxOrg.TabStop = False
        Me.gbxOrg.Text = "Original"
        '
        'txtAdj_AdjRemark_Org
        '
        Me.txtAdj_AdjRemark_Org.Enabled = False
        Me.txtAdj_AdjRemark_Org.Location = New System.Drawing.Point(17, 57)
        Me.txtAdj_AdjRemark_Org.Multiline = True
        Me.txtAdj_AdjRemark_Org.Name = "txtAdj_AdjRemark_Org"
        Me.txtAdj_AdjRemark_Org.Size = New System.Drawing.Size(133, 141)
        Me.txtAdj_AdjRemark_Org.TabIndex = 5
        Me.txtAdj_AdjRemark_Org.Visible = False
        '
        'txtAdj_PL_Org
        '
        Me.txtAdj_PL_Org.DecimalPoints = 2
        Me.txtAdj_PL_Org.Enabled = False
        Me.txtAdj_PL_Org.Location = New System.Drawing.Point(17, 30)
        Me.txtAdj_PL_Org.Name = "txtAdj_PL_Org"
        Me.txtAdj_PL_Org.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_PL_Org.TabIndex = 4
        Me.txtAdj_PL_Org.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbxSearch
        '
        Me.gbxSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxSearch.Controls.Add(Me.rbShowNormal)
        Me.gbxSearch.Controls.Add(Me.rbShowAll)
        Me.gbxSearch.Controls.Add(Me.rbAdjustedOnly)
        Me.gbxSearch.Controls.Add(Me.dtpTdate)
        Me.gbxSearch.Controls.Add(Me.cbxCounterParty)
        Me.gbxSearch.Controls.Add(Me.lblCounterParty)
        Me.gbxSearch.Controls.Add(Me.Label3)
        Me.gbxSearch.Location = New System.Drawing.Point(6, 339)
        Me.gbxSearch.Name = "gbxSearch"
        Me.gbxSearch.Size = New System.Drawing.Size(646, 100)
        Me.gbxSearch.TabIndex = 1
        Me.gbxSearch.TabStop = False
        Me.gbxSearch.Text = "Search Criteria"
        '
        'rbShowNormal
        '
        Me.rbShowNormal.AutoSize = True
        Me.rbShowNormal.Location = New System.Drawing.Point(280, 45)
        Me.rbShowNormal.Name = "rbShowNormal"
        Me.rbShowNormal.Size = New System.Drawing.Size(179, 19)
        Me.rbShowNormal.TabIndex = 5
        Me.rbShowNormal.TabStop = True
        Me.rbShowNormal.Text = "Show Normal Statment Only"
        Me.rbShowNormal.UseVisualStyleBackColor = True
        '
        'rbShowAll
        '
        Me.rbShowAll.AutoSize = True
        Me.rbShowAll.Location = New System.Drawing.Point(280, 20)
        Me.rbShowAll.Name = "rbShowAll"
        Me.rbShowAll.Size = New System.Drawing.Size(131, 19)
        Me.rbShowAll.TabIndex = 4
        Me.rbShowAll.TabStop = True
        Me.rbShowAll.Text = "Show All Statement"
        Me.rbShowAll.UseVisualStyleBackColor = True
        '
        'rbAdjustedOnly
        '
        Me.rbAdjustedOnly.AutoSize = True
        Me.rbAdjustedOnly.Location = New System.Drawing.Point(280, 70)
        Me.rbAdjustedOnly.Name = "rbAdjustedOnly"
        Me.rbAdjustedOnly.Size = New System.Drawing.Size(193, 19)
        Me.rbAdjustedOnly.TabIndex = 6
        Me.rbAdjustedOnly.TabStop = True
        Me.rbAdjustedOnly.Text = "Show Adjusted Statement Only"
        Me.rbAdjustedOnly.UseVisualStyleBackColor = True
        '
        'lblCounterParty
        '
        Me.lblCounterParty.AutoSize = True
        Me.lblCounterParty.Location = New System.Drawing.Point(6, 65)
        Me.lblCounterParty.Name = "lblCounterParty"
        Me.lblCounterParty.Size = New System.Drawing.Size(81, 15)
        Me.lblCounterParty.TabIndex = 2
        Me.lblCounterParty.Text = "Counter Party"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Trade Date"
        '
        'gbxSum
        '
        Me.gbxSum.Controls.Add(Me.txtAdj_PL_Sum)
        Me.gbxSum.Location = New System.Drawing.Point(446, 113)
        Me.gbxSum.Name = "gbxSum"
        Me.gbxSum.Size = New System.Drawing.Size(167, 75)
        Me.gbxSum.TabIndex = 6
        Me.gbxSum.TabStop = False
        Me.gbxSum.Text = "Sum"
        '
        'txtAdj_PL_Sum
        '
        Me.txtAdj_PL_Sum.DecimalPoints = 2
        Me.txtAdj_PL_Sum.Enabled = False
        Me.txtAdj_PL_Sum.Location = New System.Drawing.Point(17, 30)
        Me.txtAdj_PL_Sum.Name = "txtAdj_PL_Sum"
        Me.txtAdj_PL_Sum.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_PL_Sum.TabIndex = 4
        Me.txtAdj_PL_Sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(722, 22)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Statement Liq. Header Adjustment (Futures)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(15, 173)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(51, 15)
        Me.Label19.TabIndex = 12
        Me.Label19.Text = "Remark"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 554)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "LhNId"
        Me.Label4.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(226, 554)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "AdjNoId"
        Me.Label5.Visible = False
        '
        'lblAdj_PL
        '
        Me.lblAdj_PL.AutoSize = True
        Me.lblAdj_PL.Location = New System.Drawing.Point(15, 146)
        Me.lblAdj_PL.Name = "lblAdj_PL"
        Me.lblAdj_PL.Size = New System.Drawing.Size(22, 15)
        Me.lblAdj_PL.TabIndex = 11
        Me.lblAdj_PL.Text = "PL"
        '
        'lblVoid
        '
        Me.lblVoid.AutoSize = True
        Me.lblVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblVoid.ForeColor = System.Drawing.Color.Red
        Me.lblVoid.Location = New System.Drawing.Point(601, 288)
        Me.lblVoid.Name = "lblVoid"
        Me.lblVoid.Size = New System.Drawing.Size(99, 37)
        Me.lblVoid.TabIndex = 17
        Me.lblVoid.Text = "VOID"
        Me.lblVoid.Visible = False
        '
        'tabctrlMain
        '
        Me.tabctrlMain.Controls.Add(Me.tabpageView)
        Me.tabctrlMain.Controls.Add(Me.tabpageModify)
        Me.tabctrlMain.Controls.Add(Me.tabpageAdd)
        Me.tabctrlMain.Location = New System.Drawing.Point(12, 34)
        Me.tabctrlMain.Name = "tabctrlMain"
        Me.tabctrlMain.SelectedIndex = 0
        Me.tabctrlMain.Size = New System.Drawing.Size(722, 473)
        Me.tabctrlMain.TabIndex = 1
        '
        'tabpageView
        '
        Me.tabpageView.Controls.Add(Me.gbxSearch)
        Me.tabpageView.Controls.Add(Me.dgvQryResult)
        Me.tabpageView.Controls.Add(Me.btnSearch)
        Me.tabpageView.Location = New System.Drawing.Point(4, 24)
        Me.tabpageView.Name = "tabpageView"
        Me.tabpageView.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageView.Size = New System.Drawing.Size(714, 445)
        Me.tabpageView.TabIndex = 0
        Me.tabpageView.Text = "View"
        Me.tabpageView.UseVisualStyleBackColor = True
        '
        'tabpageModify
        '
        Me.tabpageModify.Controls.Add(Me.dtpAdj_LstUpdTime)
        Me.tabpageModify.Controls.Add(Me.txtAdj_LstUpdUser)
        Me.tabpageModify.Controls.Add(Me.lblAdj_LstUpdTime)
        Me.tabpageModify.Controls.Add(Me.lblAdj_LstUpdUser)
        Me.tabpageModify.Controls.Add(Me.cbxAdj_CounterParty)
        Me.tabpageModify.Controls.Add(Me.Label28)
        Me.tabpageModify.Controls.Add(Me.txtAdj_contractSize)
        Me.tabpageModify.Controls.Add(Me.cbxAdj_monthlyDaily)
        Me.tabpageModify.Controls.Add(Me.dtpAdj_settleDate)
        Me.tabpageModify.Controls.Add(Me.Label24)
        Me.tabpageModify.Controls.Add(Me.Label25)
        Me.tabpageModify.Controls.Add(Me.Label26)
        Me.tabpageModify.Controls.Add(Me.cbxAdj_Product)
        Me.tabpageModify.Controls.Add(Me.txtAdj_MonthCode)
        Me.tabpageModify.Controls.Add(Me.Label21)
        Me.tabpageModify.Controls.Add(Me.dtpAdj_tDate)
        Me.tabpageModify.Controls.Add(Me.Label22)
        Me.tabpageModify.Controls.Add(Me.Label23)
        Me.tabpageModify.Controls.Add(Me.btnAdjModify)
        Me.tabpageModify.Controls.Add(Me.gbxSum)
        Me.tabpageModify.Controls.Add(Me.btnAdjUndoDelete)
        Me.tabpageModify.Controls.Add(Me.lblVoid)
        Me.tabpageModify.Controls.Add(Me.btnAdjDelete)
        Me.tabpageModify.Controls.Add(Me.Label19)
        Me.tabpageModify.Controls.Add(Me.gbxOrg)
        Me.tabpageModify.Controls.Add(Me.lblAdj_PL)
        Me.tabpageModify.Controls.Add(Me.btnAdjBack)
        Me.tabpageModify.Controls.Add(Me.btnAdjSave)
        Me.tabpageModify.Controls.Add(Me.gbxAdj)
        Me.tabpageModify.Location = New System.Drawing.Point(4, 24)
        Me.tabpageModify.Name = "tabpageModify"
        Me.tabpageModify.Padding = New System.Windows.Forms.Padding(3)
        Me.tabpageModify.Size = New System.Drawing.Size(714, 445)
        Me.tabpageModify.TabIndex = 1
        Me.tabpageModify.Text = "Adjustment"
        Me.tabpageModify.UseVisualStyleBackColor = True
        '
        'cbxAdj_CounterParty
        '
        Me.cbxAdj_CounterParty.Enabled = False
        Me.cbxAdj_CounterParty.FormattingEnabled = True
        Me.cbxAdj_CounterParty.Location = New System.Drawing.Point(89, 69)
        Me.cbxAdj_CounterParty.Name = "cbxAdj_CounterParty"
        Me.cbxAdj_CounterParty.Size = New System.Drawing.Size(133, 23)
        Me.cbxAdj_CounterParty.TabIndex = 46
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(5, 72)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(81, 15)
        Me.Label28.TabIndex = 45
        Me.Label28.Text = "Counter Party"
        '
        'txtAdj_contractSize
        '
        Me.txtAdj_contractSize.DecimalPoints = 2
        Me.txtAdj_contractSize.Enabled = False
        Me.txtAdj_contractSize.Location = New System.Drawing.Point(536, 44)
        Me.txtAdj_contractSize.Name = "txtAdj_contractSize"
        Me.txtAdj_contractSize.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_contractSize.TabIndex = 44
        Me.txtAdj_contractSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxAdj_monthlyDaily
        '
        Me.cbxAdj_monthlyDaily.Enabled = False
        Me.cbxAdj_monthlyDaily.FormattingEnabled = True
        Me.cbxAdj_monthlyDaily.Location = New System.Drawing.Point(312, 42)
        Me.cbxAdj_monthlyDaily.Name = "cbxAdj_monthlyDaily"
        Me.cbxAdj_monthlyDaily.Size = New System.Drawing.Size(133, 23)
        Me.cbxAdj_monthlyDaily.TabIndex = 42
        '
        'dtpAdj_settleDate
        '
        Me.dtpAdj_settleDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpAdj_settleDate.Enabled = False
        Me.dtpAdj_settleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdj_settleDate.Location = New System.Drawing.Point(89, 42)
        Me.dtpAdj_settleDate.Name = "dtpAdj_settleDate"
        Me.dtpAdj_settleDate.Size = New System.Drawing.Size(133, 21)
        Me.dtpAdj_settleDate.TabIndex = 40
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(451, 48)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(79, 15)
        Me.Label24.TabIndex = 43
        Me.Label24.Text = "Contract Size"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Location = New System.Drawing.Point(228, 45)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(78, 15)
        Me.Label25.TabIndex = 41
        Me.Label25.Text = "Monthly/Daily"
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(15, 47)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 15)
        Me.Label26.TabIndex = 39
        Me.Label26.Text = "Settle Date"
        '
        'cbxAdj_Product
        '
        Me.cbxAdj_Product.Enabled = False
        Me.cbxAdj_Product.FormattingEnabled = True
        Me.cbxAdj_Product.Location = New System.Drawing.Point(312, 13)
        Me.cbxAdj_Product.Name = "cbxAdj_Product"
        Me.cbxAdj_Product.Size = New System.Drawing.Size(133, 23)
        Me.cbxAdj_Product.TabIndex = 36
        '
        'txtAdj_MonthCode
        '
        Me.txtAdj_MonthCode.Enabled = False
        Me.txtAdj_MonthCode.Location = New System.Drawing.Point(536, 15)
        Me.txtAdj_MonthCode.Name = "txtAdj_MonthCode"
        Me.txtAdj_MonthCode.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_MonthCode.TabIndex = 34
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(15, 18)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(68, 15)
        Me.Label21.TabIndex = 31
        Me.Label21.Text = "Trade Date"
        '
        'dtpAdj_tDate
        '
        Me.dtpAdj_tDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpAdj_tDate.Enabled = False
        Me.dtpAdj_tDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdj_tDate.Location = New System.Drawing.Point(89, 15)
        Me.dtpAdj_tDate.Name = "dtpAdj_tDate"
        Me.dtpAdj_tDate.Size = New System.Drawing.Size(133, 21)
        Me.dtpAdj_tDate.TabIndex = 32
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(228, 18)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(49, 15)
        Me.Label22.TabIndex = 35
        Me.Label22.Text = "Product"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(452, 18)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(73, 15)
        Me.Label23.TabIndex = 33
        Me.Label23.Text = "Month Code"
        '
        'btnAdjModify
        '
        Me.btnAdjModify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdjModify.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdjModify.Location = New System.Drawing.Point(557, 387)
        Me.btnAdjModify.Name = "btnAdjModify"
        Me.btnAdjModify.Size = New System.Drawing.Size(50, 55)
        Me.btnAdjModify.TabIndex = 18
        Me.btnAdjModify.Text = "Modify"
        Me.btnAdjModify.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdjModify.UseVisualStyleBackColor = True
        '
        'tabpageAdd
        '
        Me.tabpageAdd.Controls.Add(Me.dtpAdd_LstUpdTime)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_LstUpdUser)
        Me.tabpageAdd.Controls.Add(Me.lblAdd_LstUpdTime)
        Me.tabpageAdd.Controls.Add(Me.lblAdd_LstUpdUser)
        Me.tabpageAdd.Controls.Add(Me.btnAddModify)
        Me.tabpageAdd.Controls.Add(Me.btnAddDelete)
        Me.tabpageAdd.Controls.Add(Me.btnAddSave)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_Product)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_AdjRemark)
        Me.tabpageAdd.Controls.Add(Me.Label20)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_MonthCode)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_ContractSize)
        Me.tabpageAdd.Controls.Add(Me.cbxAdd_MonthlyDaily)
        Me.tabpageAdd.Controls.Add(Me.dtpAdd_SettleDate)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_PL)
        Me.tabpageAdd.Controls.Add(Me.cbxAdd_CounterParty)
        Me.tabpageAdd.Controls.Add(Me.Label1)
        Me.tabpageAdd.Controls.Add(Me.Label2)
        Me.tabpageAdd.Controls.Add(Me.Label10)
        Me.tabpageAdd.Controls.Add(Me.Label11)
        Me.tabpageAdd.Controls.Add(Me.Label12)
        Me.tabpageAdd.Controls.Add(Me.Label16)
        Me.tabpageAdd.Controls.Add(Me.btnAddBack)
        Me.tabpageAdd.Controls.Add(Me.btnAdd)
        Me.tabpageAdd.Controls.Add(Me.dtpAdd_Tdate)
        Me.tabpageAdd.Controls.Add(Me.Label7)
        Me.tabpageAdd.Controls.Add(Me.Label9)
        Me.tabpageAdd.Location = New System.Drawing.Point(4, 24)
        Me.tabpageAdd.Name = "tabpageAdd"
        Me.tabpageAdd.Size = New System.Drawing.Size(714, 445)
        Me.tabpageAdd.TabIndex = 2
        Me.tabpageAdd.Text = "Add"
        Me.tabpageAdd.UseVisualStyleBackColor = True
        '
        'btnAddModify
        '
        Me.btnAddModify.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddModify.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddModify.Location = New System.Drawing.Point(557, 387)
        Me.btnAddModify.Name = "btnAddModify"
        Me.btnAddModify.Size = New System.Drawing.Size(50, 55)
        Me.btnAddModify.TabIndex = 33
        Me.btnAddModify.Text = "Modify"
        Me.btnAddModify.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddModify.UseVisualStyleBackColor = True
        '
        'btnAddDelete
        '
        Me.btnAddDelete.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddDelete.Location = New System.Drawing.Point(453, 387)
        Me.btnAddDelete.Name = "btnAddDelete"
        Me.btnAddDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnAddDelete.TabIndex = 31
        Me.btnAddDelete.Text = "Delete"
        Me.btnAddDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddDelete.UseVisualStyleBackColor = True
        '
        'btnAddSave
        '
        Me.btnAddSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddSave.Location = New System.Drawing.Point(609, 387)
        Me.btnAddSave.Name = "btnAddSave"
        Me.btnAddSave.Size = New System.Drawing.Size(50, 55)
        Me.btnAddSave.TabIndex = 32
        Me.btnAddSave.Text = "Save"
        Me.btnAddSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddSave.UseVisualStyleBackColor = True
        '
        'txtAdd_Product
        '
        Me.txtAdd_Product.Location = New System.Drawing.Point(159, 92)
        Me.txtAdd_Product.MaxLength = 45
        Me.txtAdd_Product.Name = "txtAdd_Product"
        Me.txtAdd_Product.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_Product.TabIndex = 30
        '
        'txtAdd_AdjRemark
        '
        Me.txtAdd_AdjRemark.Location = New System.Drawing.Point(159, 260)
        Me.txtAdd_AdjRemark.Multiline = True
        Me.txtAdd_AdjRemark.Name = "txtAdd_AdjRemark"
        Me.txtAdd_AdjRemark.Size = New System.Drawing.Size(288, 42)
        Me.txtAdd_AdjRemark.TabIndex = 27
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(38, 263)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 15)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "Remark"
        '
        'txtAdd_MonthCode
        '
        Me.txtAdd_MonthCode.Location = New System.Drawing.Point(159, 65)
        Me.txtAdd_MonthCode.Name = "txtAdd_MonthCode"
        Me.txtAdd_MonthCode.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_MonthCode.TabIndex = 9
        '
        'txtAdd_ContractSize
        '
        Me.txtAdd_ContractSize.DecimalPoints = 2
        Me.txtAdd_ContractSize.Location = New System.Drawing.Point(159, 204)
        Me.txtAdd_ContractSize.Name = "txtAdd_ContractSize"
        Me.txtAdd_ContractSize.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_ContractSize.TabIndex = 23
        Me.txtAdd_ContractSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxAdd_MonthlyDaily
        '
        Me.cbxAdd_MonthlyDaily.FormattingEnabled = True
        Me.cbxAdd_MonthlyDaily.Location = New System.Drawing.Point(159, 175)
        Me.cbxAdd_MonthlyDaily.Name = "cbxAdd_MonthlyDaily"
        Me.cbxAdd_MonthlyDaily.Size = New System.Drawing.Size(133, 23)
        Me.cbxAdd_MonthlyDaily.TabIndex = 21
        '
        'dtpAdd_SettleDate
        '
        Me.dtpAdd_SettleDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpAdd_SettleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdd_SettleDate.Location = New System.Drawing.Point(159, 148)
        Me.dtpAdd_SettleDate.Name = "dtpAdd_SettleDate"
        Me.dtpAdd_SettleDate.Size = New System.Drawing.Size(133, 21)
        Me.dtpAdd_SettleDate.TabIndex = 19
        '
        'txtAdd_PL
        '
        Me.txtAdd_PL.DecimalPoints = 4
        Me.txtAdd_PL.Location = New System.Drawing.Point(159, 121)
        Me.txtAdd_PL.Name = "txtAdd_PL"
        Me.txtAdd_PL.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_PL.TabIndex = 17
        Me.txtAdd_PL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxAdd_CounterParty
        '
        Me.cbxAdd_CounterParty.FormattingEnabled = True
        Me.cbxAdd_CounterParty.Location = New System.Drawing.Point(159, 231)
        Me.cbxAdd_CounterParty.Name = "cbxAdd_CounterParty"
        Me.cbxAdd_CounterParty.Size = New System.Drawing.Size(133, 23)
        Me.cbxAdd_CounterParty.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 234)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Counter Party"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 207)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Contract Size"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(38, 178)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 15)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Monthly/Daily"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(38, 151)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 15)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Settle Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(38, 124)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(22, 15)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "PL"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(38, 38)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(68, 15)
        Me.Label16.TabIndex = 0
        Me.Label16.Text = "Trade Date"
        '
        'btnAddBack
        '
        Me.btnAddBack.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAddBack.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAddBack.Location = New System.Drawing.Point(661, 387)
        Me.btnAddBack.Name = "btnAddBack"
        Me.btnAddBack.Size = New System.Drawing.Size(50, 55)
        Me.btnAddBack.TabIndex = 29
        Me.btnAddBack.Text = "Back"
        Me.btnAddBack.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAddBack.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(505, 387)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 28
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dtpAdd_Tdate
        '
        Me.dtpAdd_Tdate.CustomFormat = "MM/dd/yyyy"
        Me.dtpAdd_Tdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdd_Tdate.Location = New System.Drawing.Point(159, 38)
        Me.dtpAdd_Tdate.Name = "dtpAdd_Tdate"
        Me.dtpAdd_Tdate.Size = New System.Drawing.Size(133, 21)
        Me.dtpAdd_Tdate.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(38, 95)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Product"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(38, 68)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(73, 15)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Month Code"
        '
        'txtAdj_AdjNoId
        '
        Me.txtAdj_AdjNoId.Enabled = False
        Me.txtAdj_AdjNoId.Location = New System.Drawing.Point(305, 551)
        Me.txtAdj_AdjNoId.Name = "txtAdj_AdjNoId"
        Me.txtAdj_AdjNoId.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_AdjNoId.TabIndex = 3
        Me.txtAdj_AdjNoId.Visible = False
        '
        'txtAdj_LhNId
        '
        Me.txtAdj_LhNId.Enabled = False
        Me.txtAdj_LhNId.Location = New System.Drawing.Point(87, 551)
        Me.txtAdj_LhNId.Name = "txtAdj_LhNId"
        Me.txtAdj_LhNId.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_LhNId.TabIndex = 1
        Me.txtAdj_LhNId.Visible = False
        '
        'dtpAdd_LstUpdTime
        '
        Me.dtpAdd_LstUpdTime.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.dtpAdd_LstUpdTime.Enabled = False
        Me.dtpAdd_LstUpdTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdd_LstUpdTime.Location = New System.Drawing.Point(557, 360)
        Me.dtpAdd_LstUpdTime.Name = "dtpAdd_LstUpdTime"
        Me.dtpAdd_LstUpdTime.Size = New System.Drawing.Size(143, 21)
        Me.dtpAdd_LstUpdTime.TabIndex = 60
        '
        'txtAdd_LstUpdUser
        '
        Me.txtAdd_LstUpdUser.Enabled = False
        Me.txtAdd_LstUpdUser.Location = New System.Drawing.Point(557, 333)
        Me.txtAdd_LstUpdUser.Name = "txtAdd_LstUpdUser"
        Me.txtAdd_LstUpdUser.Size = New System.Drawing.Size(143, 21)
        Me.txtAdd_LstUpdUser.TabIndex = 59
        '
        'lblAdd_LstUpdTime
        '
        Me.lblAdd_LstUpdTime.AutoSize = True
        Me.lblAdd_LstUpdTime.Location = New System.Drawing.Point(451, 363)
        Me.lblAdd_LstUpdTime.Name = "lblAdd_LstUpdTime"
        Me.lblAdd_LstUpdTime.Size = New System.Drawing.Size(99, 15)
        Me.lblAdd_LstUpdTime.TabIndex = 58
        Me.lblAdd_LstUpdTime.Text = "Last update time"
        '
        'lblAdd_LstUpdUser
        '
        Me.lblAdd_LstUpdUser.AutoSize = True
        Me.lblAdd_LstUpdUser.Location = New System.Drawing.Point(451, 336)
        Me.lblAdd_LstUpdUser.Name = "lblAdd_LstUpdUser"
        Me.lblAdd_LstUpdUser.Size = New System.Drawing.Size(100, 15)
        Me.lblAdd_LstUpdUser.TabIndex = 57
        Me.lblAdd_LstUpdUser.Text = "Last update user"
        '
        'dtpAdj_LstUpdTime
        '
        Me.dtpAdj_LstUpdTime.CustomFormat = "MM/dd/yyyy HH:mm:ss"
        Me.dtpAdj_LstUpdTime.Enabled = False
        Me.dtpAdj_LstUpdTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdj_LstUpdTime.Location = New System.Drawing.Point(557, 360)
        Me.dtpAdj_LstUpdTime.Name = "dtpAdj_LstUpdTime"
        Me.dtpAdj_LstUpdTime.Size = New System.Drawing.Size(143, 21)
        Me.dtpAdj_LstUpdTime.TabIndex = 56
        '
        'txtAdj_LstUpdUser
        '
        Me.txtAdj_LstUpdUser.Enabled = False
        Me.txtAdj_LstUpdUser.Location = New System.Drawing.Point(557, 333)
        Me.txtAdj_LstUpdUser.Name = "txtAdj_LstUpdUser"
        Me.txtAdj_LstUpdUser.Size = New System.Drawing.Size(143, 21)
        Me.txtAdj_LstUpdUser.TabIndex = 55
        '
        'lblAdj_LstUpdTime
        '
        Me.lblAdj_LstUpdTime.AutoSize = True
        Me.lblAdj_LstUpdTime.Location = New System.Drawing.Point(451, 363)
        Me.lblAdj_LstUpdTime.Name = "lblAdj_LstUpdTime"
        Me.lblAdj_LstUpdTime.Size = New System.Drawing.Size(99, 15)
        Me.lblAdj_LstUpdTime.TabIndex = 54
        Me.lblAdj_LstUpdTime.Text = "Last update time"
        '
        'lblAdj_LstUpdUser
        '
        Me.lblAdj_LstUpdUser.AutoSize = True
        Me.lblAdj_LstUpdUser.Location = New System.Drawing.Point(451, 336)
        Me.lblAdj_LstUpdUser.Name = "lblAdj_LstUpdUser"
        Me.lblAdj_LstUpdUser.Size = New System.Drawing.Size(100, 15)
        Me.lblAdj_LstUpdUser.TabIndex = 53
        Me.lblAdj_LstUpdUser.Text = "Last update user"
        '
        'FrmFuturesStatementLHAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(746, 582)
        Me.Controls.Add(Me.tabctrlMain)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAdj_LhNId)
        Me.Controls.Add(Me.txtAdj_AdjNoId)
        Me.Controls.Add(Me.Label5)
        Me.KeyPreview = True
        Me.Name = "FrmFuturesStatementLHAdj"
        Me.Text = "Statement Liq Header Adjustment (Futures)"
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtAdj_AdjNoId, 0)
        Me.Controls.SetChildIndex(Me.txtAdj_LhNId, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.tabctrlMain, 0)
        CType(Me.dgvQryResult, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbxAdj.ResumeLayout(False)
        Me.gbxAdj.PerformLayout()
        Me.gbxOrg.ResumeLayout(False)
        Me.gbxOrg.PerformLayout()
        Me.gbxSearch.ResumeLayout(False)
        Me.gbxSearch.PerformLayout()
        Me.gbxSum.ResumeLayout(False)
        Me.gbxSum.PerformLayout()
        Me.tabctrlMain.ResumeLayout(False)
        Me.tabpageView.ResumeLayout(False)
        Me.tabpageModify.ResumeLayout(False)
        Me.tabpageModify.PerformLayout()
        Me.tabpageAdd.ResumeLayout(False)
        Me.tabpageAdd.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents tabctrlMain As System.Windows.Forms.TabControl
    Friend WithEvents tabpageView As System.Windows.Forms.TabPage
    Friend WithEvents tabpageModify As System.Windows.Forms.TabPage
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents btnAdjBack As ESL.myButton
    Friend WithEvents btnAdjSave As ESL.myButton
    Friend WithEvents dgvQryResult As System.Windows.Forms.DataGridView
    Friend WithEvents gbxSearch As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbxCounterParty As myComboBox
    Friend WithEvents lblCounterParty As System.Windows.Forms.Label
    Friend WithEvents lblAdj_PL As System.Windows.Forms.Label
    Friend WithEvents txtAdj_PL As myAmountBox
    Friend WithEvents gbxAdj As System.Windows.Forms.GroupBox
    Friend WithEvents gbxOrg As System.Windows.Forms.GroupBox
    Friend WithEvents txtAdj_PL_Org As myAmountBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtAdj_AdjRemark As myTextbox
    Friend WithEvents txtAdj_AdjRemark_Org As myTextbox
    Friend WithEvents dtpTdate As myDateTimePicker
    Friend WithEvents rbShowNormal As System.Windows.Forms.RadioButton
    Friend WithEvents rbShowAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbAdjustedOnly As System.Windows.Forms.RadioButton
    Friend WithEvents btnAdjDelete As ESL.myButton
    Friend WithEvents txtAdj_LhNId As myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblVoid As System.Windows.Forms.Label
    Friend WithEvents btnAdjUndoDelete As ESL.myButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAdj_AdjNoId As myTextbox
    Friend WithEvents gbxSum As System.Windows.Forms.GroupBox
    Friend WithEvents txtAdj_PL_Sum As myAmountBox
    Friend WithEvents btnAdjModify As ESL.myButton
    Friend WithEvents tabpageAdd As System.Windows.Forms.TabPage
    Friend WithEvents txtAdd_Product As ESL.myTextbox
    Friend WithEvents txtAdd_AdjRemark As ESL.myTextbox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtAdd_MonthCode As ESL.myTextbox
    Friend WithEvents txtAdd_ContractSize As ESL.myAmountBox
    Friend WithEvents cbxAdd_MonthlyDaily As ESL.myComboBox
    Friend WithEvents dtpAdd_SettleDate As ESL.myDateTimePicker
    Friend WithEvents txtAdd_PL As ESL.myAmountBox
    Friend WithEvents cbxAdd_CounterParty As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnAddBack As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents dtpAdd_Tdate As ESL.myDateTimePicker
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cbxAdj_Product As ESL.myComboBox
    Friend WithEvents txtAdj_MonthCode As ESL.myTextbox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dtpAdj_tDate As ESL.myDateTimePicker
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtAdj_contractSize As ESL.myAmountBox
    Friend WithEvents cbxAdj_monthlyDaily As ESL.myComboBox
    Friend WithEvents dtpAdj_settleDate As ESL.myDateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cbxAdj_CounterParty As ESL.myComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnAddDelete As ESL.myButton
    Friend WithEvents btnAddSave As ESL.myButton
    Friend WithEvents btnAddModify As ESL.myButton
    Friend WithEvents qry_adjnoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_lhnId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_adjAction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_tdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_monthCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_product As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_pl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_settleDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_monthlyDaily As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_contractSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_counterParty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_adjRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtpAdd_LstUpdTime As ESL.myDateTimePicker
    Friend WithEvents txtAdd_LstUpdUser As ESL.myTextbox
    Friend WithEvents lblAdd_LstUpdTime As System.Windows.Forms.Label
    Friend WithEvents lblAdd_LstUpdUser As System.Windows.Forms.Label
    Friend WithEvents dtpAdj_LstUpdTime As ESL.myDateTimePicker
    Friend WithEvents txtAdj_LstUpdUser As ESL.myTextbox
    Friend WithEvents lblAdj_LstUpdTime As System.Windows.Forms.Label
    Friend WithEvents lblAdj_LstUpdUser As System.Windows.Forms.Label

End Class
