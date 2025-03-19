<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFuturesStatementOPAdj
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmFuturesStatementOPAdj))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnAdjBack = New ESL.myButton(Me.components)
        Me.btnAdjDelete = New ESL.myButton(Me.components)
        Me.btnAdjSave = New ESL.myButton(Me.components)
        Me.btnAdjUndoDelete = New ESL.myButton(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.cbxCounterParty = New ESL.myComboBox(Me.components)
        Me.dgvQryResult = New System.Windows.Forms.DataGridView()
        Me.qry_adjnoid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_opnoId = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_adjAction = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_tdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_odate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_buy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_sell = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_monthCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_product = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_price = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_closingPrice = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_floating = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_settleDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_monthlyDaily = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_contractSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_counterParty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qry_adjRemark = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dtpTdate = New ESL.myDateTimePicker()
        Me.gbxAdj = New System.Windows.Forms.GroupBox()
        Me.txtAdj_AdjRemark = New ESL.myTextbox()
        Me.txtAdj_ClosingPrice = New ESL.myAmountBox()
        Me.txtAdj_Buy = New ESL.myAmountBox()
        Me.txtAdj_Sell = New ESL.myAmountBox()
        Me.txtAdj_Price = New ESL.myAmountBox()
        Me.txtAdj_Floating = New ESL.myAmountBox()
        Me.gbxOrg = New System.Windows.Forms.GroupBox()
        Me.txtAdj_AdjRemark_Org = New ESL.myTextbox()
        Me.txtAdj_ClosingPrice_Org = New ESL.myAmountBox()
        Me.txtAdj_Buy_Org = New ESL.myAmountBox()
        Me.txtAdj_Sell_Org = New ESL.myAmountBox()
        Me.txtAdj_Price_Org = New ESL.myAmountBox()
        Me.txtAdj_Floating_Org = New ESL.myAmountBox()
        Me.gbxSearch = New System.Windows.Forms.GroupBox()
        Me.lblStrike = New System.Windows.Forms.Label()
        Me.cboStrike = New System.Windows.Forms.ComboBox()
        Me.cboCallPut = New System.Windows.Forms.ComboBox()
        Me.Label = New System.Windows.Forms.Label()
        Me.cbxPrice = New ESL.myComboBox(Me.components)
        Me.lblPrice = New System.Windows.Forms.Label()
        Me.cbxProduct = New ESL.myComboBox(Me.components)
        Me.lblProduct = New System.Windows.Forms.Label()
        Me.cbxMonthCode = New ESL.myComboBox(Me.components)
        Me.lblMonthCode = New System.Windows.Forms.Label()
        Me.rbShowNormal = New System.Windows.Forms.RadioButton()
        Me.rbShowAll = New System.Windows.Forms.RadioButton()
        Me.rbAdjustedOnly = New System.Windows.Forms.RadioButton()
        Me.lblCounterParty = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.gbxSum = New System.Windows.Forms.GroupBox()
        Me.txtAdj_ClosingPrice_Sum = New ESL.myAmountBox()
        Me.txtAdj_Buy_Sum = New ESL.myAmountBox()
        Me.txtAdj_Sell_Sum = New ESL.myAmountBox()
        Me.txtAdj_Price_Sum = New ESL.myAmountBox()
        Me.txtAdj_Floating_Sum = New ESL.myAmountBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblAdj_Buy = New System.Windows.Forms.Label()
        Me.lblAdj_PL = New System.Windows.Forms.Label()
        Me.lblAdj_Price = New System.Windows.Forms.Label()
        Me.lblAdj_Sell = New System.Windows.Forms.Label()
        Me.lblVoid = New System.Windows.Forms.Label()
        Me.tabctrlMain = New System.Windows.Forms.TabControl()
        Me.tabpageView = New System.Windows.Forms.TabPage()
        Me.tabpageModify = New System.Windows.Forms.TabPage()
        Me.cboAdj_Strike = New System.Windows.Forms.ComboBox()
        Me.cboAdj_CallPut = New System.Windows.Forms.ComboBox()
        Me.lblAdjStrike = New System.Windows.Forms.Label()
        Me.lblAdjCallPut = New System.Windows.Forms.Label()
        Me.dtpAdj_LstUpdTime = New ESL.myDateTimePicker()
        Me.txtAdj_LstUpdUser = New ESL.myTextbox()
        Me.lblAdj_LstUpdTime = New System.Windows.Forms.Label()
        Me.lblAdj_LstUpdUser = New System.Windows.Forms.Label()
        Me.cbxAdj_CounterParty = New ESL.myComboBox(Me.components)
        Me.Label28 = New System.Windows.Forms.Label()
        Me.txtAdj_contractSize = New ESL.myAmountBox()
        Me.cbxAdj_monthlyDaily = New ESL.myComboBox(Me.components)
        Me.dtpAdj_settleDate = New ESL.myDateTimePicker()
        Me.dtpAdj_oDate = New ESL.myDateTimePicker()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.cbxAdj_Product = New ESL.myComboBox(Me.components)
        Me.txtAdj_MonthCode = New ESL.myTextbox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.dtpAdj_tDate = New ESL.myDateTimePicker()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.btnAdjModify = New ESL.myButton(Me.components)
        Me.tabpageAdd = New System.Windows.Forms.TabPage()
        Me.cboAdd_CallPut = New ESL.myComboBox(Me.components)
        Me.txtAdd_Strike = New ESL.myAmountBox()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.dtpAdd_LstUpdTime = New ESL.myDateTimePicker()
        Me.txtAdd_LstUpdUser = New ESL.myTextbox()
        Me.lblAdd_LstUpdTime = New System.Windows.Forms.Label()
        Me.lblAdd_LstUpdUser = New System.Windows.Forms.Label()
        Me.btnAddModify = New ESL.myButton(Me.components)
        Me.btnAddDelete = New ESL.myButton(Me.components)
        Me.btnAddSave = New ESL.myButton(Me.components)
        Me.cbxAdd_Product = New ESL.myComboBox(Me.components)
        Me.txtAdd_AdjRemark = New ESL.myTextbox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.txtAdd_ClosingPrice = New ESL.myAmountBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAdd_MonthCode = New ESL.myTextbox()
        Me.txtAdd_ContractSize = New ESL.myAmountBox()
        Me.cbxAdd_MonthlyDaily = New ESL.myComboBox(Me.components)
        Me.dtpAdd_SettleDate = New ESL.myDateTimePicker()
        Me.txtAdd_Floating = New ESL.myAmountBox()
        Me.txtAdd_Price = New ESL.myAmountBox()
        Me.txtAdd_Sell = New ESL.myAmountBox()
        Me.dtpAdd_Odate = New ESL.myDateTimePicker()
        Me.txtAdd_Buy = New ESL.myAmountBox()
        Me.cbxAdd_CounterParty = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.btnAddBack = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.dtpAdd_Tdate = New ESL.myDateTimePicker()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtAdj_AdjNoId = New ESL.myTextbox()
        Me.txtAdj_OpNoId = New ESL.myTextbox()
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
        Me.cbxCounterParty.Location = New System.Drawing.Point(86, 42)
        Me.cbxCounterParty.Name = "cbxCounterParty"
        Me.cbxCounterParty.Size = New System.Drawing.Size(133, 23)
        Me.cbxCounterParty.TabIndex = 3
        '
        'dgvQryResult
        '
        Me.dgvQryResult.AllowUserToAddRows = False
        Me.dgvQryResult.AllowUserToDeleteRows = False
        Me.dgvQryResult.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.dgvQryResult.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvQryResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvQryResult.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.qry_adjnoid, Me.qry_opnoId, Me.qry_adjAction, Me.qry_tdate, Me.qry_odate, Me.qry_buy, Me.qry_sell, Me.qry_monthCode, Me.qry_product, Me.qry_price, Me.qry_closingPrice, Me.qry_floating, Me.qry_settleDate, Me.qry_monthlyDaily, Me.qry_contractSize, Me.qry_counterParty, Me.qry_adjRemark})
        Me.dgvQryResult.GridColor = System.Drawing.Color.Linen
        Me.dgvQryResult.Location = New System.Drawing.Point(9, 6)
        Me.dgvQryResult.MultiSelect = False
        Me.dgvQryResult.Name = "dgvQryResult"
        Me.dgvQryResult.ReadOnly = True
        Me.dgvQryResult.RowHeadersVisible = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dgvQryResult.RowsDefaultCellStyle = DataGridViewCellStyle1
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
        'qry_opnoId
        '
        Me.qry_opnoId.DataPropertyName = "opnoid"
        Me.qry_opnoId.HeaderText = "opNoId"
        Me.qry_opnoId.Name = "qry_opnoId"
        Me.qry_opnoId.ReadOnly = True
        Me.qry_opnoId.Visible = False
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
        'qry_odate
        '
        Me.qry_odate.DataPropertyName = "odate"
        Me.qry_odate.HeaderText = "oDate"
        Me.qry_odate.Name = "qry_odate"
        Me.qry_odate.ReadOnly = True
        '
        'qry_buy
        '
        Me.qry_buy.DataPropertyName = "buy"
        Me.qry_buy.HeaderText = "Buy"
        Me.qry_buy.Name = "qry_buy"
        Me.qry_buy.ReadOnly = True
        '
        'qry_sell
        '
        Me.qry_sell.DataPropertyName = "sell"
        Me.qry_sell.HeaderText = "Sell"
        Me.qry_sell.Name = "qry_sell"
        Me.qry_sell.ReadOnly = True
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
        'qry_price
        '
        Me.qry_price.DataPropertyName = "price"
        Me.qry_price.HeaderText = "Price"
        Me.qry_price.Name = "qry_price"
        Me.qry_price.ReadOnly = True
        '
        'qry_closingPrice
        '
        Me.qry_closingPrice.DataPropertyName = "closing_price"
        Me.qry_closingPrice.HeaderText = "Closing Price"
        Me.qry_closingPrice.Name = "qry_closingPrice"
        Me.qry_closingPrice.ReadOnly = True
        '
        'qry_floating
        '
        Me.qry_floating.DataPropertyName = "floating"
        Me.qry_floating.HeaderText = "Floating"
        Me.qry_floating.Name = "qry_floating"
        Me.qry_floating.ReadOnly = True
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
        Me.dtpTdate.Location = New System.Drawing.Point(88, 15)
        Me.dtpTdate.Name = "dtpTdate"
        Me.dtpTdate.Size = New System.Drawing.Size(133, 21)
        Me.dtpTdate.TabIndex = 1
        '
        'gbxAdj
        '
        Me.gbxAdj.Controls.Add(Me.txtAdj_AdjRemark)
        Me.gbxAdj.Controls.Add(Me.txtAdj_ClosingPrice)
        Me.gbxAdj.Controls.Add(Me.txtAdj_Buy)
        Me.gbxAdj.Controls.Add(Me.txtAdj_Sell)
        Me.gbxAdj.Controls.Add(Me.txtAdj_Price)
        Me.gbxAdj.Controls.Add(Me.txtAdj_Floating)
        Me.gbxAdj.Location = New System.Drawing.Point(102, 113)
        Me.gbxAdj.Name = "gbxAdj"
        Me.gbxAdj.Size = New System.Drawing.Size(163, 317)
        Me.gbxAdj.TabIndex = 4
        Me.gbxAdj.TabStop = False
        Me.gbxAdj.Text = "Adjustment"
        '
        'txtAdj_AdjRemark
        '
        Me.txtAdj_AdjRemark.Location = New System.Drawing.Point(18, 170)
        Me.txtAdj_AdjRemark.Multiline = True
        Me.txtAdj_AdjRemark.Name = "txtAdj_AdjRemark"
        Me.txtAdj_AdjRemark.Size = New System.Drawing.Size(133, 141)
        Me.txtAdj_AdjRemark.TabIndex = 5
        '
        'txtAdj_ClosingPrice
        '
        Me.txtAdj_ClosingPrice.DecimalPoints = 2
        Me.txtAdj_ClosingPrice.EnabledRemoveTrailingZero = True
        Me.txtAdj_ClosingPrice.Location = New System.Drawing.Point(18, 116)
        Me.txtAdj_ClosingPrice.Name = "txtAdj_ClosingPrice"
        Me.txtAdj_ClosingPrice.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_ClosingPrice.TabIndex = 3
        Me.txtAdj_ClosingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Buy
        '
        Me.txtAdj_Buy.DecimalPoints = 2
        Me.txtAdj_Buy.EnabledRemoveTrailingZero = False
        Me.txtAdj_Buy.Location = New System.Drawing.Point(18, 35)
        Me.txtAdj_Buy.Name = "txtAdj_Buy"
        Me.txtAdj_Buy.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Buy.TabIndex = 0
        Me.txtAdj_Buy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Sell
        '
        Me.txtAdj_Sell.DecimalPoints = 2
        Me.txtAdj_Sell.EnabledRemoveTrailingZero = False
        Me.txtAdj_Sell.Location = New System.Drawing.Point(18, 62)
        Me.txtAdj_Sell.Name = "txtAdj_Sell"
        Me.txtAdj_Sell.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Sell.TabIndex = 1
        Me.txtAdj_Sell.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Price
        '
        Me.txtAdj_Price.DecimalPoints = 2
        Me.txtAdj_Price.EnabledRemoveTrailingZero = True
        Me.txtAdj_Price.Location = New System.Drawing.Point(18, 89)
        Me.txtAdj_Price.Name = "txtAdj_Price"
        Me.txtAdj_Price.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Price.TabIndex = 2
        Me.txtAdj_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Floating
        '
        Me.txtAdj_Floating.DecimalPoints = 4
        Me.txtAdj_Floating.EnabledRemoveTrailingZero = False
        Me.txtAdj_Floating.Location = New System.Drawing.Point(18, 143)
        Me.txtAdj_Floating.Name = "txtAdj_Floating"
        Me.txtAdj_Floating.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Floating.TabIndex = 4
        Me.txtAdj_Floating.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbxOrg
        '
        Me.gbxOrg.Controls.Add(Me.txtAdj_AdjRemark_Org)
        Me.gbxOrg.Controls.Add(Me.txtAdj_ClosingPrice_Org)
        Me.gbxOrg.Controls.Add(Me.txtAdj_Buy_Org)
        Me.gbxOrg.Controls.Add(Me.txtAdj_Sell_Org)
        Me.gbxOrg.Controls.Add(Me.txtAdj_Price_Org)
        Me.gbxOrg.Controls.Add(Me.txtAdj_Floating_Org)
        Me.gbxOrg.Location = New System.Drawing.Point(273, 113)
        Me.gbxOrg.Name = "gbxOrg"
        Me.gbxOrg.Size = New System.Drawing.Size(167, 317)
        Me.gbxOrg.TabIndex = 5
        Me.gbxOrg.TabStop = False
        Me.gbxOrg.Text = "Original"
        '
        'txtAdj_AdjRemark_Org
        '
        Me.txtAdj_AdjRemark_Org.Enabled = False
        Me.txtAdj_AdjRemark_Org.Location = New System.Drawing.Point(17, 173)
        Me.txtAdj_AdjRemark_Org.Multiline = True
        Me.txtAdj_AdjRemark_Org.Name = "txtAdj_AdjRemark_Org"
        Me.txtAdj_AdjRemark_Org.Size = New System.Drawing.Size(133, 138)
        Me.txtAdj_AdjRemark_Org.TabIndex = 5
        Me.txtAdj_AdjRemark_Org.Visible = False
        '
        'txtAdj_ClosingPrice_Org
        '
        Me.txtAdj_ClosingPrice_Org.DecimalPoints = 2
        Me.txtAdj_ClosingPrice_Org.Enabled = False
        Me.txtAdj_ClosingPrice_Org.EnabledRemoveTrailingZero = True
        Me.txtAdj_ClosingPrice_Org.Location = New System.Drawing.Point(17, 119)
        Me.txtAdj_ClosingPrice_Org.Name = "txtAdj_ClosingPrice_Org"
        Me.txtAdj_ClosingPrice_Org.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_ClosingPrice_Org.TabIndex = 3
        Me.txtAdj_ClosingPrice_Org.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Buy_Org
        '
        Me.txtAdj_Buy_Org.DecimalPoints = 2
        Me.txtAdj_Buy_Org.Enabled = False
        Me.txtAdj_Buy_Org.EnabledRemoveTrailingZero = False
        Me.txtAdj_Buy_Org.Location = New System.Drawing.Point(17, 38)
        Me.txtAdj_Buy_Org.Name = "txtAdj_Buy_Org"
        Me.txtAdj_Buy_Org.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Buy_Org.TabIndex = 0
        Me.txtAdj_Buy_Org.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Sell_Org
        '
        Me.txtAdj_Sell_Org.DecimalPoints = 2
        Me.txtAdj_Sell_Org.Enabled = False
        Me.txtAdj_Sell_Org.EnabledRemoveTrailingZero = False
        Me.txtAdj_Sell_Org.Location = New System.Drawing.Point(17, 65)
        Me.txtAdj_Sell_Org.Name = "txtAdj_Sell_Org"
        Me.txtAdj_Sell_Org.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Sell_Org.TabIndex = 1
        Me.txtAdj_Sell_Org.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Price_Org
        '
        Me.txtAdj_Price_Org.DecimalPoints = 2
        Me.txtAdj_Price_Org.Enabled = False
        Me.txtAdj_Price_Org.EnabledRemoveTrailingZero = False
        Me.txtAdj_Price_Org.Location = New System.Drawing.Point(17, 92)
        Me.txtAdj_Price_Org.Name = "txtAdj_Price_Org"
        Me.txtAdj_Price_Org.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Price_Org.TabIndex = 2
        Me.txtAdj_Price_Org.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Floating_Org
        '
        Me.txtAdj_Floating_Org.DecimalPoints = 2
        Me.txtAdj_Floating_Org.Enabled = False
        Me.txtAdj_Floating_Org.EnabledRemoveTrailingZero = False
        Me.txtAdj_Floating_Org.Location = New System.Drawing.Point(17, 146)
        Me.txtAdj_Floating_Org.Name = "txtAdj_Floating_Org"
        Me.txtAdj_Floating_Org.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Floating_Org.TabIndex = 4
        Me.txtAdj_Floating_Org.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gbxSearch
        '
        Me.gbxSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.gbxSearch.Controls.Add(Me.lblStrike)
        Me.gbxSearch.Controls.Add(Me.cboStrike)
        Me.gbxSearch.Controls.Add(Me.cboCallPut)
        Me.gbxSearch.Controls.Add(Me.Label)
        Me.gbxSearch.Controls.Add(Me.cbxPrice)
        Me.gbxSearch.Controls.Add(Me.lblPrice)
        Me.gbxSearch.Controls.Add(Me.cbxProduct)
        Me.gbxSearch.Controls.Add(Me.lblProduct)
        Me.gbxSearch.Controls.Add(Me.cbxMonthCode)
        Me.gbxSearch.Controls.Add(Me.lblMonthCode)
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
        'lblStrike
        '
        Me.lblStrike.AutoSize = True
        Me.lblStrike.Location = New System.Drawing.Point(304, 74)
        Me.lblStrike.Name = "lblStrike"
        Me.lblStrike.Size = New System.Drawing.Size(38, 15)
        Me.lblStrike.TabIndex = 24
        Me.lblStrike.Text = "Strike"
        '
        'cboStrike
        '
        Me.cboStrike.FormattingEnabled = True
        Me.cboStrike.Location = New System.Drawing.Point(350, 69)
        Me.cboStrike.Name = "cboStrike"
        Me.cboStrike.Size = New System.Drawing.Size(100, 23)
        Me.cboStrike.TabIndex = 23
        '
        'cboCallPut
        '
        Me.cboCallPut.FormattingEnabled = True
        Me.cboCallPut.Location = New System.Drawing.Point(237, 70)
        Me.cboCallPut.Name = "cboCallPut"
        Me.cboCallPut.Size = New System.Drawing.Size(57, 23)
        Me.cboCallPut.TabIndex = 22
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(179, 74)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(47, 15)
        Me.Label.TabIndex = 21
        Me.Label.Text = "CallPut"
        '
        'cbxPrice
        '
        Me.cbxPrice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxPrice.FormattingEnabled = True
        Me.cbxPrice.Location = New System.Drawing.Point(287, 42)
        Me.cbxPrice.Name = "cbxPrice"
        Me.cbxPrice.Size = New System.Drawing.Size(163, 23)
        Me.cbxPrice.TabIndex = 20
        '
        'lblPrice
        '
        Me.lblPrice.AutoSize = True
        Me.lblPrice.Location = New System.Drawing.Point(232, 45)
        Me.lblPrice.Name = "lblPrice"
        Me.lblPrice.Size = New System.Drawing.Size(35, 15)
        Me.lblPrice.TabIndex = 19
        Me.lblPrice.Text = "Price"
        '
        'cbxProduct
        '
        Me.cbxProduct.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProduct.FormattingEnabled = True
        Me.cbxProduct.Location = New System.Drawing.Point(287, 15)
        Me.cbxProduct.Name = "cbxProduct"
        Me.cbxProduct.Size = New System.Drawing.Size(163, 23)
        Me.cbxProduct.TabIndex = 18
        '
        'lblProduct
        '
        Me.lblProduct.AutoSize = True
        Me.lblProduct.Location = New System.Drawing.Point(232, 18)
        Me.lblProduct.Name = "lblProduct"
        Me.lblProduct.Size = New System.Drawing.Size(49, 15)
        Me.lblProduct.TabIndex = 17
        Me.lblProduct.Text = "Product"
        '
        'cbxMonthCode
        '
        Me.cbxMonthCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxMonthCode.FormattingEnabled = True
        Me.cbxMonthCode.Location = New System.Drawing.Point(86, 71)
        Me.cbxMonthCode.Name = "cbxMonthCode"
        Me.cbxMonthCode.Size = New System.Drawing.Size(81, 23)
        Me.cbxMonthCode.TabIndex = 16
        '
        'lblMonthCode
        '
        Me.lblMonthCode.AutoSize = True
        Me.lblMonthCode.Location = New System.Drawing.Point(6, 74)
        Me.lblMonthCode.Name = "lblMonthCode"
        Me.lblMonthCode.Size = New System.Drawing.Size(73, 15)
        Me.lblMonthCode.TabIndex = 15
        Me.lblMonthCode.Text = "Month Code"
        '
        'rbShowNormal
        '
        Me.rbShowNormal.AutoSize = True
        Me.rbShowNormal.Location = New System.Drawing.Point(456, 45)
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
        Me.rbShowAll.Location = New System.Drawing.Point(456, 20)
        Me.rbShowAll.Name = "rbShowAll"
        Me.rbShowAll.Size = New System.Drawing.Size(130, 19)
        Me.rbShowAll.TabIndex = 4
        Me.rbShowAll.TabStop = True
        Me.rbShowAll.Text = "Show All Statement"
        Me.rbShowAll.UseVisualStyleBackColor = True
        '
        'rbAdjustedOnly
        '
        Me.rbAdjustedOnly.AutoSize = True
        Me.rbAdjustedOnly.Location = New System.Drawing.Point(456, 70)
        Me.rbAdjustedOnly.Name = "rbAdjustedOnly"
        Me.rbAdjustedOnly.Size = New System.Drawing.Size(192, 19)
        Me.rbAdjustedOnly.TabIndex = 6
        Me.rbAdjustedOnly.TabStop = True
        Me.rbAdjustedOnly.Text = "Show Adjusted Statement Only"
        Me.rbAdjustedOnly.UseVisualStyleBackColor = True
        '
        'lblCounterParty
        '
        Me.lblCounterParty.AutoSize = True
        Me.lblCounterParty.Location = New System.Drawing.Point(6, 45)
        Me.lblCounterParty.Name = "lblCounterParty"
        Me.lblCounterParty.Size = New System.Drawing.Size(81, 15)
        Me.lblCounterParty.TabIndex = 2
        Me.lblCounterParty.Text = "Counter Party"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(68, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Trade Date"
        '
        'gbxSum
        '
        Me.gbxSum.Controls.Add(Me.txtAdj_ClosingPrice_Sum)
        Me.gbxSum.Controls.Add(Me.txtAdj_Buy_Sum)
        Me.gbxSum.Controls.Add(Me.txtAdj_Sell_Sum)
        Me.gbxSum.Controls.Add(Me.txtAdj_Price_Sum)
        Me.gbxSum.Controls.Add(Me.txtAdj_Floating_Sum)
        Me.gbxSum.Location = New System.Drawing.Point(446, 113)
        Me.gbxSum.Name = "gbxSum"
        Me.gbxSum.Size = New System.Drawing.Size(167, 188)
        Me.gbxSum.TabIndex = 6
        Me.gbxSum.TabStop = False
        Me.gbxSum.Text = "Sum"
        '
        'txtAdj_ClosingPrice_Sum
        '
        Me.txtAdj_ClosingPrice_Sum.DecimalPoints = 2
        Me.txtAdj_ClosingPrice_Sum.Enabled = False
        Me.txtAdj_ClosingPrice_Sum.EnabledRemoveTrailingZero = False
        Me.txtAdj_ClosingPrice_Sum.Location = New System.Drawing.Point(17, 119)
        Me.txtAdj_ClosingPrice_Sum.Name = "txtAdj_ClosingPrice_Sum"
        Me.txtAdj_ClosingPrice_Sum.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_ClosingPrice_Sum.TabIndex = 3
        Me.txtAdj_ClosingPrice_Sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Buy_Sum
        '
        Me.txtAdj_Buy_Sum.DecimalPoints = 2
        Me.txtAdj_Buy_Sum.Enabled = False
        Me.txtAdj_Buy_Sum.EnabledRemoveTrailingZero = False
        Me.txtAdj_Buy_Sum.Location = New System.Drawing.Point(17, 38)
        Me.txtAdj_Buy_Sum.Name = "txtAdj_Buy_Sum"
        Me.txtAdj_Buy_Sum.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Buy_Sum.TabIndex = 0
        Me.txtAdj_Buy_Sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Sell_Sum
        '
        Me.txtAdj_Sell_Sum.DecimalPoints = 2
        Me.txtAdj_Sell_Sum.Enabled = False
        Me.txtAdj_Sell_Sum.EnabledRemoveTrailingZero = False
        Me.txtAdj_Sell_Sum.Location = New System.Drawing.Point(17, 65)
        Me.txtAdj_Sell_Sum.Name = "txtAdj_Sell_Sum"
        Me.txtAdj_Sell_Sum.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Sell_Sum.TabIndex = 1
        Me.txtAdj_Sell_Sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Price_Sum
        '
        Me.txtAdj_Price_Sum.DecimalPoints = 2
        Me.txtAdj_Price_Sum.Enabled = False
        Me.txtAdj_Price_Sum.EnabledRemoveTrailingZero = False
        Me.txtAdj_Price_Sum.Location = New System.Drawing.Point(17, 92)
        Me.txtAdj_Price_Sum.Name = "txtAdj_Price_Sum"
        Me.txtAdj_Price_Sum.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Price_Sum.TabIndex = 2
        Me.txtAdj_Price_Sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdj_Floating_Sum
        '
        Me.txtAdj_Floating_Sum.DecimalPoints = 2
        Me.txtAdj_Floating_Sum.Enabled = False
        Me.txtAdj_Floating_Sum.EnabledRemoveTrailingZero = False
        Me.txtAdj_Floating_Sum.Location = New System.Drawing.Point(17, 146)
        Me.txtAdj_Floating_Sum.Name = "txtAdj_Floating_Sum"
        Me.txtAdj_Floating_Sum.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_Floating_Sum.TabIndex = 4
        Me.txtAdj_Floating_Sum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(12, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(722, 22)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Statement Open Position Adjustment (Futures)"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(15, 232)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(81, 15)
        Me.Label18.TabIndex = 10
        Me.Label18.Text = "Closing Price"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(15, 286)
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
        Me.Label4.Size = New System.Drawing.Size(49, 15)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "OpNoId"
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
        'lblAdj_Buy
        '
        Me.lblAdj_Buy.AutoSize = True
        Me.lblAdj_Buy.Location = New System.Drawing.Point(15, 154)
        Me.lblAdj_Buy.Name = "lblAdj_Buy"
        Me.lblAdj_Buy.Size = New System.Drawing.Size(27, 15)
        Me.lblAdj_Buy.TabIndex = 7
        Me.lblAdj_Buy.Text = "Buy"
        '
        'lblAdj_PL
        '
        Me.lblAdj_PL.AutoSize = True
        Me.lblAdj_PL.Location = New System.Drawing.Point(15, 259)
        Me.lblAdj_PL.Name = "lblAdj_PL"
        Me.lblAdj_PL.Size = New System.Drawing.Size(51, 15)
        Me.lblAdj_PL.TabIndex = 11
        Me.lblAdj_PL.Text = "Floating"
        '
        'lblAdj_Price
        '
        Me.lblAdj_Price.AutoSize = True
        Me.lblAdj_Price.Location = New System.Drawing.Point(15, 205)
        Me.lblAdj_Price.Name = "lblAdj_Price"
        Me.lblAdj_Price.Size = New System.Drawing.Size(35, 15)
        Me.lblAdj_Price.TabIndex = 9
        Me.lblAdj_Price.Text = "Price"
        '
        'lblAdj_Sell
        '
        Me.lblAdj_Sell.AutoSize = True
        Me.lblAdj_Sell.Location = New System.Drawing.Point(15, 181)
        Me.lblAdj_Sell.Name = "lblAdj_Sell"
        Me.lblAdj_Sell.Size = New System.Drawing.Size(28, 15)
        Me.lblAdj_Sell.TabIndex = 8
        Me.lblAdj_Sell.Text = "Sell"
        '
        'lblVoid
        '
        Me.lblVoid.AutoSize = True
        Me.lblVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.lblVoid.ForeColor = System.Drawing.Color.Red
        Me.lblVoid.Location = New System.Drawing.Point(601, 293)
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
        Me.tabpageModify.Controls.Add(Me.cboAdj_Strike)
        Me.tabpageModify.Controls.Add(Me.cboAdj_CallPut)
        Me.tabpageModify.Controls.Add(Me.lblAdjStrike)
        Me.tabpageModify.Controls.Add(Me.lblAdjCallPut)
        Me.tabpageModify.Controls.Add(Me.dtpAdj_LstUpdTime)
        Me.tabpageModify.Controls.Add(Me.txtAdj_LstUpdUser)
        Me.tabpageModify.Controls.Add(Me.lblAdj_LstUpdTime)
        Me.tabpageModify.Controls.Add(Me.lblAdj_LstUpdUser)
        Me.tabpageModify.Controls.Add(Me.cbxAdj_CounterParty)
        Me.tabpageModify.Controls.Add(Me.Label28)
        Me.tabpageModify.Controls.Add(Me.txtAdj_contractSize)
        Me.tabpageModify.Controls.Add(Me.cbxAdj_monthlyDaily)
        Me.tabpageModify.Controls.Add(Me.dtpAdj_settleDate)
        Me.tabpageModify.Controls.Add(Me.dtpAdj_oDate)
        Me.tabpageModify.Controls.Add(Me.Label24)
        Me.tabpageModify.Controls.Add(Me.Label25)
        Me.tabpageModify.Controls.Add(Me.Label26)
        Me.tabpageModify.Controls.Add(Me.Label27)
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
        Me.tabpageModify.Controls.Add(Me.Label18)
        Me.tabpageModify.Controls.Add(Me.lblAdj_Price)
        Me.tabpageModify.Controls.Add(Me.lblAdj_Sell)
        Me.tabpageModify.Controls.Add(Me.lblAdj_PL)
        Me.tabpageModify.Controls.Add(Me.lblAdj_Buy)
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
        'cboAdj_Strike
        '
        Me.cboAdj_Strike.Enabled = False
        Me.cboAdj_Strike.FormattingEnabled = True
        Me.cboAdj_Strike.Location = New System.Drawing.Point(531, 69)
        Me.cboAdj_Strike.Name = "cboAdj_Strike"
        Me.cboAdj_Strike.Size = New System.Drawing.Size(144, 23)
        Me.cboAdj_Strike.TabIndex = 62
        '
        'cboAdj_CallPut
        '
        Me.cboAdj_CallPut.Enabled = False
        Me.cboAdj_CallPut.FormattingEnabled = True
        Me.cboAdj_CallPut.Location = New System.Drawing.Point(654, 13)
        Me.cboAdj_CallPut.Name = "cboAdj_CallPut"
        Me.cboAdj_CallPut.Size = New System.Drawing.Size(50, 23)
        Me.cboAdj_CallPut.TabIndex = 61
        '
        'lblAdjStrike
        '
        Me.lblAdjStrike.AutoSize = True
        Me.lblAdjStrike.Location = New System.Drawing.Point(452, 74)
        Me.lblAdjStrike.Name = "lblAdjStrike"
        Me.lblAdjStrike.Size = New System.Drawing.Size(38, 15)
        Me.lblAdjStrike.TabIndex = 58
        Me.lblAdjStrike.Text = "Strike"
        '
        'lblAdjCallPut
        '
        Me.lblAdjCallPut.AutoSize = True
        Me.lblAdjCallPut.Location = New System.Drawing.Point(601, 16)
        Me.lblAdjCallPut.Name = "lblAdjCallPut"
        Me.lblAdjCallPut.Size = New System.Drawing.Size(50, 15)
        Me.lblAdjCallPut.TabIndex = 57
        Me.lblAdjCallPut.Text = "Call/Put"
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
        'cbxAdj_CounterParty
        '
        Me.cbxAdj_CounterParty.Enabled = False
        Me.cbxAdj_CounterParty.FormattingEnabled = True
        Me.cbxAdj_CounterParty.Location = New System.Drawing.Point(312, 71)
        Me.cbxAdj_CounterParty.Name = "cbxAdj_CounterParty"
        Me.cbxAdj_CounterParty.Size = New System.Drawing.Size(133, 23)
        Me.cbxAdj_CounterParty.TabIndex = 46
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(228, 74)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(81, 15)
        Me.Label28.TabIndex = 45
        Me.Label28.Text = "Counter Party"
        '
        'txtAdj_contractSize
        '
        Me.txtAdj_contractSize.DecimalPoints = 2
        Me.txtAdj_contractSize.Enabled = False
        Me.txtAdj_contractSize.EnabledRemoveTrailingZero = False
        Me.txtAdj_contractSize.Location = New System.Drawing.Point(531, 42)
        Me.txtAdj_contractSize.Name = "txtAdj_contractSize"
        Me.txtAdj_contractSize.Size = New System.Drawing.Size(144, 21)
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
        Me.dtpAdj_settleDate.Location = New System.Drawing.Point(89, 69)
        Me.dtpAdj_settleDate.Name = "dtpAdj_settleDate"
        Me.dtpAdj_settleDate.Size = New System.Drawing.Size(133, 21)
        Me.dtpAdj_settleDate.TabIndex = 40
        '
        'dtpAdj_oDate
        '
        Me.dtpAdj_oDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpAdj_oDate.Enabled = False
        Me.dtpAdj_oDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdj_oDate.Location = New System.Drawing.Point(89, 42)
        Me.dtpAdj_oDate.Name = "dtpAdj_oDate"
        Me.dtpAdj_oDate.Size = New System.Drawing.Size(133, 21)
        Me.dtpAdj_oDate.TabIndex = 38
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
        Me.Label26.Location = New System.Drawing.Point(15, 74)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 15)
        Me.Label26.TabIndex = 39
        Me.Label26.Text = "Settle Date"
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(15, 45)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(40, 15)
        Me.Label27.TabIndex = 37
        Me.Label27.Text = "oDate"
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
        Me.txtAdj_MonthCode.Location = New System.Drawing.Point(531, 15)
        Me.txtAdj_MonthCode.Name = "txtAdj_MonthCode"
        Me.txtAdj_MonthCode.Size = New System.Drawing.Size(60, 21)
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
        Me.tabpageAdd.Controls.Add(Me.cboAdd_CallPut)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_Strike)
        Me.tabpageAdd.Controls.Add(Me.Label31)
        Me.tabpageAdd.Controls.Add(Me.Label30)
        Me.tabpageAdd.Controls.Add(Me.dtpAdd_LstUpdTime)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_LstUpdUser)
        Me.tabpageAdd.Controls.Add(Me.lblAdd_LstUpdTime)
        Me.tabpageAdd.Controls.Add(Me.lblAdd_LstUpdUser)
        Me.tabpageAdd.Controls.Add(Me.btnAddModify)
        Me.tabpageAdd.Controls.Add(Me.btnAddDelete)
        Me.tabpageAdd.Controls.Add(Me.btnAddSave)
        Me.tabpageAdd.Controls.Add(Me.cbxAdd_Product)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_AdjRemark)
        Me.tabpageAdd.Controls.Add(Me.Label20)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_ClosingPrice)
        Me.tabpageAdd.Controls.Add(Me.Label17)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_MonthCode)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_ContractSize)
        Me.tabpageAdd.Controls.Add(Me.cbxAdd_MonthlyDaily)
        Me.tabpageAdd.Controls.Add(Me.dtpAdd_SettleDate)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_Floating)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_Price)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_Sell)
        Me.tabpageAdd.Controls.Add(Me.dtpAdd_Odate)
        Me.tabpageAdd.Controls.Add(Me.txtAdd_Buy)
        Me.tabpageAdd.Controls.Add(Me.cbxAdd_CounterParty)
        Me.tabpageAdd.Controls.Add(Me.Label1)
        Me.tabpageAdd.Controls.Add(Me.Label2)
        Me.tabpageAdd.Controls.Add(Me.Label6)
        Me.tabpageAdd.Controls.Add(Me.Label8)
        Me.tabpageAdd.Controls.Add(Me.Label10)
        Me.tabpageAdd.Controls.Add(Me.Label11)
        Me.tabpageAdd.Controls.Add(Me.Label12)
        Me.tabpageAdd.Controls.Add(Me.Label14)
        Me.tabpageAdd.Controls.Add(Me.Label15)
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
        'cboAdd_CallPut
        '
        Me.cboAdd_CallPut.FormattingEnabled = True
        Me.cboAdd_CallPut.Location = New System.Drawing.Point(397, 200)
        Me.cboAdd_CallPut.Name = "cboAdd_CallPut"
        Me.cboAdd_CallPut.Size = New System.Drawing.Size(133, 23)
        Me.cboAdd_CallPut.TabIndex = 65
        '
        'txtAdd_Strike
        '
        Me.txtAdd_Strike.DecimalPoints = 2
        Me.txtAdd_Strike.EnabledRemoveTrailingZero = True
        Me.txtAdd_Strike.Location = New System.Drawing.Point(397, 227)
        Me.txtAdd_Strike.Name = "txtAdd_Strike"
        Me.txtAdd_Strike.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_Strike.TabIndex = 64
        Me.txtAdd_Strike.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(321, 230)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(38, 15)
        Me.Label31.TabIndex = 63
        Me.Label31.Text = "Strike"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(321, 203)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(47, 15)
        Me.Label30.TabIndex = 61
        Me.Label30.Text = "CallPut"
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
        'cbxAdd_Product
        '
        Me.cbxAdd_Product.FormattingEnabled = True
        Me.cbxAdd_Product.Location = New System.Drawing.Point(159, 171)
        Me.cbxAdd_Product.Name = "cbxAdd_Product"
        Me.cbxAdd_Product.Size = New System.Drawing.Size(133, 23)
        Me.cbxAdd_Product.TabIndex = 30
        '
        'txtAdd_AdjRemark
        '
        Me.txtAdd_AdjRemark.Location = New System.Drawing.Point(159, 393)
        Me.txtAdd_AdjRemark.Multiline = True
        Me.txtAdd_AdjRemark.Name = "txtAdd_AdjRemark"
        Me.txtAdd_AdjRemark.Size = New System.Drawing.Size(288, 42)
        Me.txtAdd_AdjRemark.TabIndex = 27
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(38, 396)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(51, 15)
        Me.Label20.TabIndex = 26
        Me.Label20.Text = "Remark"
        '
        'txtAdd_ClosingPrice
        '
        Me.txtAdd_ClosingPrice.DecimalPoints = 2
        Me.txtAdd_ClosingPrice.EnabledRemoveTrailingZero = True
        Me.txtAdd_ClosingPrice.Location = New System.Drawing.Point(159, 227)
        Me.txtAdd_ClosingPrice.Name = "txtAdd_ClosingPrice"
        Me.txtAdd_ClosingPrice.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_ClosingPrice.TabIndex = 15
        Me.txtAdd_ClosingPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(38, 230)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 15)
        Me.Label17.TabIndex = 14
        Me.Label17.Text = "Closing Price"
        '
        'txtAdd_MonthCode
        '
        Me.txtAdd_MonthCode.Location = New System.Drawing.Point(159, 144)
        Me.txtAdd_MonthCode.Name = "txtAdd_MonthCode"
        Me.txtAdd_MonthCode.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_MonthCode.TabIndex = 9
        '
        'txtAdd_ContractSize
        '
        Me.txtAdd_ContractSize.DecimalPoints = 2
        Me.txtAdd_ContractSize.EnabledRemoveTrailingZero = False
        Me.txtAdd_ContractSize.Location = New System.Drawing.Point(159, 337)
        Me.txtAdd_ContractSize.Name = "txtAdd_ContractSize"
        Me.txtAdd_ContractSize.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_ContractSize.TabIndex = 23
        Me.txtAdd_ContractSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxAdd_MonthlyDaily
        '
        Me.cbxAdd_MonthlyDaily.FormattingEnabled = True
        Me.cbxAdd_MonthlyDaily.Location = New System.Drawing.Point(159, 308)
        Me.cbxAdd_MonthlyDaily.Name = "cbxAdd_MonthlyDaily"
        Me.cbxAdd_MonthlyDaily.Size = New System.Drawing.Size(133, 23)
        Me.cbxAdd_MonthlyDaily.TabIndex = 21
        '
        'dtpAdd_SettleDate
        '
        Me.dtpAdd_SettleDate.CustomFormat = "MM/dd/yyyy"
        Me.dtpAdd_SettleDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdd_SettleDate.Location = New System.Drawing.Point(159, 281)
        Me.dtpAdd_SettleDate.Name = "dtpAdd_SettleDate"
        Me.dtpAdd_SettleDate.Size = New System.Drawing.Size(133, 21)
        Me.dtpAdd_SettleDate.TabIndex = 19
        '
        'txtAdd_Floating
        '
        Me.txtAdd_Floating.DecimalPoints = 4
        Me.txtAdd_Floating.EnabledRemoveTrailingZero = False
        Me.txtAdd_Floating.Location = New System.Drawing.Point(159, 254)
        Me.txtAdd_Floating.Name = "txtAdd_Floating"
        Me.txtAdd_Floating.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_Floating.TabIndex = 17
        Me.txtAdd_Floating.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdd_Price
        '
        Me.txtAdd_Price.DecimalPoints = 2
        Me.txtAdd_Price.EnabledRemoveTrailingZero = True
        Me.txtAdd_Price.Location = New System.Drawing.Point(159, 200)
        Me.txtAdd_Price.Name = "txtAdd_Price"
        Me.txtAdd_Price.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_Price.TabIndex = 13
        Me.txtAdd_Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAdd_Sell
        '
        Me.txtAdd_Sell.DecimalPoints = 2
        Me.txtAdd_Sell.EnabledRemoveTrailingZero = False
        Me.txtAdd_Sell.Location = New System.Drawing.Point(159, 117)
        Me.txtAdd_Sell.Name = "txtAdd_Sell"
        Me.txtAdd_Sell.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_Sell.TabIndex = 7
        Me.txtAdd_Sell.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'dtpAdd_Odate
        '
        Me.dtpAdd_Odate.CustomFormat = "MM/dd/yyyy"
        Me.dtpAdd_Odate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpAdd_Odate.Location = New System.Drawing.Point(159, 65)
        Me.dtpAdd_Odate.Name = "dtpAdd_Odate"
        Me.dtpAdd_Odate.Size = New System.Drawing.Size(133, 21)
        Me.dtpAdd_Odate.TabIndex = 3
        '
        'txtAdd_Buy
        '
        Me.txtAdd_Buy.DecimalPoints = 2
        Me.txtAdd_Buy.EnabledRemoveTrailingZero = False
        Me.txtAdd_Buy.Location = New System.Drawing.Point(159, 90)
        Me.txtAdd_Buy.Name = "txtAdd_Buy"
        Me.txtAdd_Buy.Size = New System.Drawing.Size(133, 21)
        Me.txtAdd_Buy.TabIndex = 5
        Me.txtAdd_Buy.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cbxAdd_CounterParty
        '
        Me.cbxAdd_CounterParty.FormattingEnabled = True
        Me.cbxAdd_CounterParty.Location = New System.Drawing.Point(159, 364)
        Me.cbxAdd_CounterParty.Name = "cbxAdd_CounterParty"
        Me.cbxAdd_CounterParty.Size = New System.Drawing.Size(133, 23)
        Me.cbxAdd_CounterParty.TabIndex = 25
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(38, 367)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(81, 15)
        Me.Label1.TabIndex = 24
        Me.Label1.Text = "Counter Party"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(38, 340)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Contract Size"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(38, 203)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 15)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Price"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(38, 120)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 15)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Sell"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(38, 311)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(78, 15)
        Me.Label10.TabIndex = 20
        Me.Label10.Text = "Monthly/Daily"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(38, 284)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 15)
        Me.Label11.TabIndex = 18
        Me.Label11.Text = "Settle Date"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(38, 257)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(51, 15)
        Me.Label12.TabIndex = 16
        Me.Label12.Text = "Floating"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(38, 93)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(27, 15)
        Me.Label14.TabIndex = 4
        Me.Label14.Text = "Buy"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(38, 65)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 15)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "oDate"
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
        Me.Label7.Location = New System.Drawing.Point(38, 174)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Product"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(38, 147)
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
        'txtAdj_OpNoId
        '
        Me.txtAdj_OpNoId.Enabled = False
        Me.txtAdj_OpNoId.Location = New System.Drawing.Point(87, 551)
        Me.txtAdj_OpNoId.Name = "txtAdj_OpNoId"
        Me.txtAdj_OpNoId.Size = New System.Drawing.Size(133, 21)
        Me.txtAdj_OpNoId.TabIndex = 1
        Me.txtAdj_OpNoId.Visible = False
        '
        'FrmFuturesStatementOPAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(746, 582)
        Me.Controls.Add(Me.tabctrlMain)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAdj_OpNoId)
        Me.Controls.Add(Me.txtAdj_AdjNoId)
        Me.Controls.Add(Me.Label5)
        Me.KeyPreview = True
        Me.Name = "FrmFuturesStatementOPAdj"
        Me.Text = "Statement Open Position Adjustment (Futures)"
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtAdj_AdjNoId, 0)
        Me.Controls.SetChildIndex(Me.txtAdj_OpNoId, 0)
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
    Friend WithEvents lblAdj_Price As System.Windows.Forms.Label
    Friend WithEvents lblAdj_Sell As System.Windows.Forms.Label
    Friend WithEvents lblAdj_PL As System.Windows.Forms.Label
    Friend WithEvents lblAdj_Buy As System.Windows.Forms.Label
    Friend WithEvents txtAdj_Buy As myAmountBox
    Friend WithEvents txtAdj_Floating As myAmountBox
    Friend WithEvents txtAdj_Price As myAmountBox
    Friend WithEvents txtAdj_Sell As myAmountBox
    Friend WithEvents txtAdj_ClosingPrice As myAmountBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents gbxAdj As System.Windows.Forms.GroupBox
    Friend WithEvents gbxOrg As System.Windows.Forms.GroupBox
    Friend WithEvents txtAdj_ClosingPrice_Org As myAmountBox
    Friend WithEvents txtAdj_Buy_Org As myAmountBox
    Friend WithEvents txtAdj_Sell_Org As myAmountBox
    Friend WithEvents txtAdj_Price_Org As myAmountBox
    Friend WithEvents txtAdj_Floating_Org As myAmountBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtAdj_AdjRemark As myTextbox
    Friend WithEvents txtAdj_AdjRemark_Org As myTextbox
    Friend WithEvents dtpTdate As myDateTimePicker
    Friend WithEvents rbShowNormal As System.Windows.Forms.RadioButton
    Friend WithEvents rbShowAll As System.Windows.Forms.RadioButton
    Friend WithEvents rbAdjustedOnly As System.Windows.Forms.RadioButton
    Friend WithEvents btnAdjDelete As ESL.myButton
    Friend WithEvents txtAdj_OpNoId As myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblVoid As System.Windows.Forms.Label
    Friend WithEvents btnAdjUndoDelete As ESL.myButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtAdj_AdjNoId As myTextbox
    Friend WithEvents gbxSum As System.Windows.Forms.GroupBox
    Friend WithEvents txtAdj_ClosingPrice_Sum As myAmountBox
    Friend WithEvents txtAdj_Buy_Sum As myAmountBox
    Friend WithEvents txtAdj_Sell_Sum As myAmountBox
    Friend WithEvents txtAdj_Price_Sum As myAmountBox
    Friend WithEvents txtAdj_Floating_Sum As myAmountBox
    Friend WithEvents btnAdjModify As ESL.myButton
    Friend WithEvents tabpageAdd As System.Windows.Forms.TabPage
    Friend WithEvents cbxAdd_Product As ESL.myComboBox
    Friend WithEvents txtAdd_AdjRemark As ESL.myTextbox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents txtAdd_ClosingPrice As ESL.myAmountBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAdd_MonthCode As ESL.myTextbox
    Friend WithEvents txtAdd_ContractSize As ESL.myAmountBox
    Friend WithEvents cbxAdd_MonthlyDaily As ESL.myComboBox
    Friend WithEvents dtpAdd_SettleDate As ESL.myDateTimePicker
    Friend WithEvents txtAdd_Floating As ESL.myAmountBox
    Friend WithEvents txtAdd_Price As ESL.myAmountBox
    Friend WithEvents txtAdd_Sell As ESL.myAmountBox
    Friend WithEvents dtpAdd_Odate As ESL.myDateTimePicker
    Friend WithEvents txtAdd_Buy As ESL.myAmountBox
    Friend WithEvents cbxAdd_CounterParty As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
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
    Friend WithEvents qry_adjnoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_opnoId As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_adjAction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_tdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_odate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_buy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_sell As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_monthCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_product As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_closingPrice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_floating As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_settleDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_monthlyDaily As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_contractSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_counterParty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qry_adjRemark As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtAdj_contractSize As ESL.myAmountBox
    Friend WithEvents cbxAdj_monthlyDaily As ESL.myComboBox
    Friend WithEvents dtpAdj_settleDate As ESL.myDateTimePicker
    Friend WithEvents dtpAdj_oDate As ESL.myDateTimePicker
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents cbxAdj_CounterParty As ESL.myComboBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents btnAddDelete As ESL.myButton
    Friend WithEvents btnAddSave As ESL.myButton
    Friend WithEvents btnAddModify As ESL.myButton
    Friend WithEvents dtpAdd_LstUpdTime As ESL.myDateTimePicker
    Friend WithEvents txtAdd_LstUpdUser As ESL.myTextbox
    Friend WithEvents lblAdd_LstUpdTime As System.Windows.Forms.Label
    Friend WithEvents lblAdd_LstUpdUser As System.Windows.Forms.Label
    Friend WithEvents dtpAdj_LstUpdTime As ESL.myDateTimePicker
    Friend WithEvents txtAdj_LstUpdUser As ESL.myTextbox
    Friend WithEvents lblAdj_LstUpdTime As System.Windows.Forms.Label
    Friend WithEvents lblAdj_LstUpdUser As System.Windows.Forms.Label
    Friend WithEvents cbxPrice As ESL.myComboBox
    Friend WithEvents lblPrice As System.Windows.Forms.Label
    Friend WithEvents cbxProduct As ESL.myComboBox
    Friend WithEvents lblProduct As System.Windows.Forms.Label
    Friend WithEvents cbxMonthCode As ESL.myComboBox
    Friend WithEvents lblMonthCode As System.Windows.Forms.Label
    Friend WithEvents lblAdjStrike As System.Windows.Forms.Label
    Friend WithEvents lblAdjCallPut As System.Windows.Forms.Label
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents cboCallPut As System.Windows.Forms.ComboBox
    Friend WithEvents txtAdd_Strike As ESL.myAmountBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents cboAdd_CallPut As ESL.myComboBox
    Friend WithEvents lblStrike As System.Windows.Forms.Label
    Friend WithEvents cboStrike As System.Windows.Forms.ComboBox
    Friend WithEvents cboAdj_Strike As System.Windows.Forms.ComboBox
    Friend WithEvents cboAdj_CallPut As System.Windows.Forms.ComboBox

End Class
