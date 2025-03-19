<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransAdjF
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
        Me.SearchBox = New System.Windows.Forms.GroupBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.RBDel = New ESL.myRadioButton(Me.components)
        Me.RBAdj = New ESL.myRadioButton(Me.components)
        Me.RBAll = New ESL.myRadioButton(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtSAccno = New ESL.myTextbox
        Me.txtSAeno = New ESL.myTextbox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.btnEnquiry = New ESL.myButton(Me.components)
        Me.label8 = New System.Windows.Forms.Label
        Me.Year = New System.Windows.Forms.Label
        Me.CboSMonth = New ESL.myComboBox(Me.components)
        Me.CboSYr = New ESL.myComboBox(Me.components)
        Me.dtgTrade = New System.Windows.Forms.DataGridView
        Me.dtgAdjaction = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgtxmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgaeno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgAename = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgAccno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgAccName1 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgAccName2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgCommod = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgMth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgCall_Put = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgStrike = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgS_price_str = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgCommission_mm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgexchange_fee_mm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgAe_rebate_mm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgday_mm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgnight_mm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgtg_mm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.day_comm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.night_comm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgmarketname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgTradeType = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgccy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgoid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgRecordID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgnight_dd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgday_dd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgexchange_fee_dd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgtg_dd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgcommission_dd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgae_rebate_dd = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboMYr = New ESL.myComboBox(Me.components)
        Me.CboMMonth = New ESL.myComboBox(Me.components)
        Me.txtMDay_mm = New ESL.myNumericBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtMNight_mm = New ESL.myNumericBox
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnModify = New ESL.myButton(Me.components)
        Me.btnDel = New ESL.myButton(Me.components)
        Me.CboMAccNo = New ESL.myComboBox(Me.components)
        Me.CboMAeno = New ESL.myComboBox(Me.components)
        Me.CboMCallPut = New ESL.myComboBox(Me.components)
        Me.LbCallPut = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TxtMAeName = New ESL.myTextbox
        Me.txtMAcName = New ESL.myTextbox
        Me.label50 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Label15 = New System.Windows.Forms.Label
        Me.CboMCcy = New ESL.myComboBox(Me.components)
        Me.cboMCommod = New ESL.myComboBox(Me.components)
        Me.txtMProductName = New ESL.myTextbox
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtMMarket = New ESL.myTextbox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.cboTradeType = New ESL.myComboBox(Me.components)
        Me.txtDayComm = New ESL.myNumericBox
        Me.txtNightComm = New ESL.myNumericBox
        Me.txtTotComm = New ESL.myNumericBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.SearchBox.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgTrade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnCancel.Location = New System.Drawing.Point(773, 646)
        Me.btnCancel.TabIndex = 16
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnSave.Location = New System.Drawing.Point(721, 646)
        Me.btnSave.TabIndex = 15
        Me.btnSave.Visible = True
        '
        'SearchBox
        '
        Me.SearchBox.Controls.Add(Me.Panel1)
        Me.SearchBox.Controls.Add(Me.txtSAccno)
        Me.SearchBox.Controls.Add(Me.txtSAeno)
        Me.SearchBox.Controls.Add(Me.Label10)
        Me.SearchBox.Controls.Add(Me.Label9)
        Me.SearchBox.Controls.Add(Me.btnEnquiry)
        Me.SearchBox.Controls.Add(Me.label8)
        Me.SearchBox.Controls.Add(Me.Year)
        Me.SearchBox.Controls.Add(Me.CboSMonth)
        Me.SearchBox.Controls.Add(Me.CboSYr)
        Me.SearchBox.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SearchBox.Location = New System.Drawing.Point(9, 34)
        Me.SearchBox.Name = "SearchBox"
        Me.SearchBox.Size = New System.Drawing.Size(820, 63)
        Me.SearchBox.TabIndex = 0
        Me.SearchBox.TabStop = False
        Me.SearchBox.Text = "Search"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.RBDel)
        Me.Panel1.Controls.Add(Me.RBAdj)
        Me.Panel1.Controls.Add(Me.RBAll)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Panel1.Location = New System.Drawing.Point(357, 28)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(275, 27)
        Me.Panel1.TabIndex = 4
        '
        'RBDel
        '
        Me.RBDel.AutoSize = True
        Me.RBDel.Location = New System.Drawing.Point(204, 7)
        Me.RBDel.Name = "RBDel"
        Me.RBDel.Size = New System.Drawing.Size(58, 16)
        Me.RBDel.TabIndex = 2
        Me.RBDel.TabStop = True
        Me.RBDel.Text = "Deleted"
        Me.RBDel.UseVisualStyleBackColor = True
        '
        'RBAdj
        '
        Me.RBAdj.AutoSize = True
        Me.RBAdj.Location = New System.Drawing.Point(125, 7)
        Me.RBAdj.Name = "RBAdj"
        Me.RBAdj.Size = New System.Drawing.Size(64, 16)
        Me.RBAdj.TabIndex = 1
        Me.RBAdj.TabStop = True
        Me.RBAdj.Text = "Adjusted"
        Me.RBAdj.UseVisualStyleBackColor = True
        '
        'RBAll
        '
        Me.RBAll.AutoSize = True
        Me.RBAll.Checked = True
        Me.RBAll.Location = New System.Drawing.Point(81, 7)
        Me.RBAll.Name = "RBAll"
        Me.RBAll.Size = New System.Drawing.Size(37, 16)
        Me.RBAll.TabIndex = 0
        Me.RBAll.TabStop = True
        Me.RBAll.Text = "All"
        Me.RBAll.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 12)
        Me.Label11.TabIndex = 0
        Me.Label11.Text = "Adjustment:"
        '
        'txtSAccno
        '
        Me.txtSAccno.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtSAccno.Location = New System.Drawing.Point(260, 32)
        Me.txtSAccno.Name = "txtSAccno"
        Me.txtSAccno.Size = New System.Drawing.Size(90, 22)
        Me.txtSAccno.TabIndex = 3
        '
        'txtSAeno
        '
        Me.txtSAeno.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtSAeno.Location = New System.Drawing.Point(161, 32)
        Me.txtSAeno.Name = "txtSAeno"
        Me.txtSAeno.Size = New System.Drawing.Size(92, 22)
        Me.txtSAeno.TabIndex = 2
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label10.Location = New System.Drawing.Point(258, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(49, 12)
        Me.Label10.TabIndex = 6
        Me.Label10.Text = "A/C code"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label9.Location = New System.Drawing.Point(159, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 12)
        Me.Label9.TabIndex = 5
        Me.Label9.Text = "A/E code"
        '
        'btnEnquiry
        '
        Me.btnEnquiry.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnEnquiry.Location = New System.Drawing.Point(706, 28)
        Me.btnEnquiry.Name = "btnEnquiry"
        Me.btnEnquiry.Size = New System.Drawing.Size(99, 27)
        Me.btnEnquiry.TabIndex = 5
        Me.btnEnquiry.Text = "Enquiry"
        Me.btnEnquiry.UseVisualStyleBackColor = True
        '
        'label8
        '
        Me.label8.AutoSize = True
        Me.label8.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.label8.Location = New System.Drawing.Point(91, 16)
        Me.label8.Name = "label8"
        Me.label8.Size = New System.Drawing.Size(36, 12)
        Me.label8.TabIndex = 3
        Me.label8.Text = "Month"
        '
        'Year
        '
        Me.Year.AutoSize = True
        Me.Year.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Year.Location = New System.Drawing.Point(6, 17)
        Me.Year.Name = "Year"
        Me.Year.Size = New System.Drawing.Size(27, 12)
        Me.Year.TabIndex = 2
        Me.Year.Text = "Year"
        '
        'CboSMonth
        '
        Me.CboSMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSMonth.Enabled = False
        Me.CboSMonth.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CboSMonth.FormattingEnabled = True
        Me.CboSMonth.Location = New System.Drawing.Point(94, 34)
        Me.CboSMonth.Name = "CboSMonth"
        Me.CboSMonth.Size = New System.Drawing.Size(62, 20)
        Me.CboSMonth.TabIndex = 1
        '
        'CboSYr
        '
        Me.CboSYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboSYr.Enabled = False
        Me.CboSYr.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CboSYr.FormattingEnabled = True
        Me.CboSYr.Location = New System.Drawing.Point(6, 34)
        Me.CboSYr.Name = "CboSYr"
        Me.CboSYr.Size = New System.Drawing.Size(82, 20)
        Me.CboSYr.TabIndex = 0
        '
        'dtgTrade
        '
        Me.dtgTrade.AllowUserToAddRows = False
        Me.dtgTrade.AllowUserToDeleteRows = False
        Me.dtgTrade.AllowUserToResizeRows = False
        Me.dtgTrade.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgTrade.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgTrade.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtgAdjaction, Me.dtgtxmonth, Me.dtgaeno, Me.dtgAename, Me.dtgAccno, Me.dtgAccName1, Me.dtgAccName2, Me.dtgCommod, Me.dtgMth, Me.dtgCall_Put, Me.dtgStrike, Me.dtgS_price_str, Me.dtgCommission_mm, Me.dtgexchange_fee_mm, Me.dtgAe_rebate_mm, Me.dtgday_mm, Me.dtgnight_mm, Me.dtgtg_mm, Me.day_comm, Me.night_comm, Me.dtgmarketname, Me.dtgTradeType, Me.dtgccy, Me.dtgoid, Me.dtgRecordID, Me.dtgnight_dd, Me.dtgday_dd, Me.dtgexchange_fee_dd, Me.dtgtg_dd, Me.dtgcommission_dd, Me.dtgae_rebate_dd})
        Me.dtgTrade.Location = New System.Drawing.Point(5, 2)
        Me.dtgTrade.MultiSelect = False
        Me.dtgTrade.Name = "dtgTrade"
        Me.dtgTrade.ReadOnly = True
        Me.dtgTrade.RowHeadersVisible = False
        Me.dtgTrade.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dtgTrade.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgTrade.RowTemplate.Height = 16
        Me.dtgTrade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgTrade.Size = New System.Drawing.Size(820, 456)
        Me.dtgTrade.TabIndex = 0
        '
        'dtgAdjaction
        '
        Me.dtgAdjaction.DataPropertyName = "adj_action"
        Me.dtgAdjaction.HeaderText = "Action"
        Me.dtgAdjaction.Name = "dtgAdjaction"
        Me.dtgAdjaction.ReadOnly = True
        Me.dtgAdjaction.Width = 50
        '
        'dtgtxmonth
        '
        Me.dtgtxmonth.DataPropertyName = "txmonth"
        Me.dtgtxmonth.HeaderText = "txmonth"
        Me.dtgtxmonth.Name = "dtgtxmonth"
        Me.dtgtxmonth.ReadOnly = True
        Me.dtgtxmonth.Width = 50
        '
        'dtgaeno
        '
        Me.dtgaeno.DataPropertyName = "aeno"
        Me.dtgaeno.HeaderText = "A/E code"
        Me.dtgaeno.Name = "dtgaeno"
        Me.dtgaeno.ReadOnly = True
        Me.dtgaeno.Width = 75
        '
        'dtgAename
        '
        Me.dtgAename.DataPropertyName = "aename"
        Me.dtgAename.HeaderText = "A/E Name"
        Me.dtgAename.Name = "dtgAename"
        Me.dtgAename.ReadOnly = True
        Me.dtgAename.Width = 180
        '
        'dtgAccno
        '
        Me.dtgAccno.DataPropertyName = "accno"
        Me.dtgAccno.HeaderText = "A/C code"
        Me.dtgAccno.Name = "dtgAccno"
        Me.dtgAccno.ReadOnly = True
        Me.dtgAccno.Width = 75
        '
        'dtgAccName1
        '
        Me.dtgAccName1.DataPropertyName = "accname1"
        Me.dtgAccName1.HeaderText = "A/C Name"
        Me.dtgAccName1.Name = "dtgAccName1"
        Me.dtgAccName1.ReadOnly = True
        Me.dtgAccName1.Width = 180
        '
        'dtgAccName2
        '
        Me.dtgAccName2.DataPropertyName = "accname2"
        Me.dtgAccName2.HeaderText = "Acc Name 2"
        Me.dtgAccName2.Name = "dtgAccName2"
        Me.dtgAccName2.ReadOnly = True
        Me.dtgAccName2.Visible = False
        Me.dtgAccName2.Width = 180
        '
        'dtgCommod
        '
        Me.dtgCommod.DataPropertyName = "commod"
        Me.dtgCommod.HeaderText = "Product"
        Me.dtgCommod.Name = "dtgCommod"
        Me.dtgCommod.ReadOnly = True
        Me.dtgCommod.Width = 50
        '
        'dtgMth
        '
        Me.dtgMth.DataPropertyName = "mth"
        Me.dtgMth.HeaderText = "Month"
        Me.dtgMth.Name = "dtgMth"
        Me.dtgMth.ReadOnly = True
        Me.dtgMth.Width = 45
        '
        'dtgCall_Put
        '
        Me.dtgCall_Put.DataPropertyName = "call_put"
        Me.dtgCall_Put.HeaderText = "Call/Put"
        Me.dtgCall_Put.Name = "dtgCall_Put"
        Me.dtgCall_Put.ReadOnly = True
        Me.dtgCall_Put.Width = 55
        '
        'dtgStrike
        '
        Me.dtgStrike.DataPropertyName = "strike"
        Me.dtgStrike.HeaderText = "Strike"
        Me.dtgStrike.Name = "dtgStrike"
        Me.dtgStrike.ReadOnly = True
        Me.dtgStrike.Width = 90
        '
        'dtgS_price_str
        '
        Me.dtgS_price_str.DataPropertyName = "s_price_str"
        Me.dtgS_price_str.HeaderText = "Strike Price String"
        Me.dtgS_price_str.Name = "dtgS_price_str"
        Me.dtgS_price_str.ReadOnly = True
        Me.dtgS_price_str.Width = 115
        '
        'dtgCommission_mm
        '
        Me.dtgCommission_mm.DataPropertyName = "commission_mm"
        Me.dtgCommission_mm.HeaderText = "Commission"
        Me.dtgCommission_mm.Name = "dtgCommission_mm"
        Me.dtgCommission_mm.ReadOnly = True
        Me.dtgCommission_mm.Width = 90
        '
        'dtgexchange_fee_mm
        '
        Me.dtgexchange_fee_mm.DataPropertyName = "exchange_fee_mm"
        Me.dtgexchange_fee_mm.HeaderText = "Exchange Fee"
        Me.dtgexchange_fee_mm.Name = "dtgexchange_fee_mm"
        Me.dtgexchange_fee_mm.ReadOnly = True
        '
        'dtgAe_rebate_mm
        '
        Me.dtgAe_rebate_mm.DataPropertyName = "ae_rebate_mm"
        Me.dtgAe_rebate_mm.HeaderText = "Rebate"
        Me.dtgAe_rebate_mm.Name = "dtgAe_rebate_mm"
        Me.dtgAe_rebate_mm.ReadOnly = True
        Me.dtgAe_rebate_mm.Width = 70
        '
        'dtgday_mm
        '
        Me.dtgday_mm.DataPropertyName = "day_mm"
        Me.dtgday_mm.HeaderText = "Lot (Day)"
        Me.dtgday_mm.Name = "dtgday_mm"
        Me.dtgday_mm.ReadOnly = True
        Me.dtgday_mm.Width = 80
        '
        'dtgnight_mm
        '
        Me.dtgnight_mm.DataPropertyName = "night_mm"
        Me.dtgnight_mm.HeaderText = "Lot (Night)"
        Me.dtgnight_mm.Name = "dtgnight_mm"
        Me.dtgnight_mm.ReadOnly = True
        Me.dtgnight_mm.Width = 80
        '
        'dtgtg_mm
        '
        Me.dtgtg_mm.DataPropertyName = "tg_mm"
        Me.dtgtg_mm.HeaderText = "T/G"
        Me.dtgtg_mm.Name = "dtgtg_mm"
        Me.dtgtg_mm.ReadOnly = True
        Me.dtgtg_mm.Width = 45
        '
        'day_comm
        '
        Me.day_comm.DataPropertyName = "day_commission"
        Me.day_comm.HeaderText = "Day Comm."
        Me.day_comm.Name = "day_comm"
        Me.day_comm.ReadOnly = True
        '
        'night_comm
        '
        Me.night_comm.DataPropertyName = "night_commission"
        Me.night_comm.HeaderText = "Night Comm."
        Me.night_comm.Name = "night_comm"
        Me.night_comm.ReadOnly = True
        '
        'dtgmarketname
        '
        Me.dtgmarketname.DataPropertyName = "marketname"
        Me.dtgmarketname.HeaderText = "Market Name"
        Me.dtgmarketname.Name = "dtgmarketname"
        Me.dtgmarketname.ReadOnly = True
        Me.dtgmarketname.Width = 180
        '
        'dtgTradeType
        '
        Me.dtgTradeType.DataPropertyName = "tradetype"
        Me.dtgTradeType.HeaderText = "Trade Type"
        Me.dtgTradeType.Name = "dtgTradeType"
        Me.dtgTradeType.ReadOnly = True
        '
        'dtgccy
        '
        Me.dtgccy.DataPropertyName = "ccy"
        Me.dtgccy.HeaderText = "Currency"
        Me.dtgccy.Name = "dtgccy"
        Me.dtgccy.ReadOnly = True
        Me.dtgccy.Width = 65
        '
        'dtgoid
        '
        Me.dtgoid.DataPropertyName = "oid"
        Me.dtgoid.HeaderText = "oid"
        Me.dtgoid.Name = "dtgoid"
        Me.dtgoid.ReadOnly = True
        Me.dtgoid.Visible = False
        '
        'dtgRecordID
        '
        Me.dtgRecordID.DataPropertyName = "recordID"
        Me.dtgRecordID.HeaderText = "RecordID"
        Me.dtgRecordID.Name = "dtgRecordID"
        Me.dtgRecordID.ReadOnly = True
        Me.dtgRecordID.Visible = False
        '
        'dtgnight_dd
        '
        Me.dtgnight_dd.DataPropertyName = "night_dd"
        Me.dtgnight_dd.HeaderText = ""
        Me.dtgnight_dd.Name = "dtgnight_dd"
        Me.dtgnight_dd.ReadOnly = True
        Me.dtgnight_dd.Visible = False
        '
        'dtgday_dd
        '
        Me.dtgday_dd.DataPropertyName = "day_dd"
        Me.dtgday_dd.HeaderText = ""
        Me.dtgday_dd.Name = "dtgday_dd"
        Me.dtgday_dd.ReadOnly = True
        Me.dtgday_dd.Visible = False
        '
        'dtgexchange_fee_dd
        '
        Me.dtgexchange_fee_dd.DataPropertyName = "exchange_fee_dd"
        Me.dtgexchange_fee_dd.HeaderText = ""
        Me.dtgexchange_fee_dd.Name = "dtgexchange_fee_dd"
        Me.dtgexchange_fee_dd.ReadOnly = True
        Me.dtgexchange_fee_dd.Visible = False
        '
        'dtgtg_dd
        '
        Me.dtgtg_dd.DataPropertyName = "tg_dd"
        Me.dtgtg_dd.HeaderText = ""
        Me.dtgtg_dd.Name = "dtgtg_dd"
        Me.dtgtg_dd.ReadOnly = True
        Me.dtgtg_dd.Visible = False
        '
        'dtgcommission_dd
        '
        Me.dtgcommission_dd.DataPropertyName = "commission_dd"
        Me.dtgcommission_dd.HeaderText = ""
        Me.dtgcommission_dd.Name = "dtgcommission_dd"
        Me.dtgcommission_dd.ReadOnly = True
        Me.dtgcommission_dd.Visible = False
        '
        'dtgae_rebate_dd
        '
        Me.dtgae_rebate_dd.DataPropertyName = "ae_rebate_dd"
        Me.dtgae_rebate_dd.HeaderText = ""
        Me.dtgae_rebate_dd.Name = "dtgae_rebate_dd"
        Me.dtgae_rebate_dd.ReadOnly = True
        Me.dtgae_rebate_dd.Visible = False
        '
        'cboMYr
        '
        Me.cboMYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMYr.Enabled = False
        Me.cboMYr.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboMYr.FormattingEnabled = True
        Me.cboMYr.Location = New System.Drawing.Point(9, 580)
        Me.cboMYr.Name = "cboMYr"
        Me.cboMYr.Size = New System.Drawing.Size(75, 20)
        Me.cboMYr.TabIndex = 1
        '
        'CboMMonth
        '
        Me.CboMMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMMonth.Enabled = False
        Me.CboMMonth.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CboMMonth.FormattingEnabled = True
        Me.CboMMonth.Location = New System.Drawing.Point(90, 580)
        Me.CboMMonth.Name = "CboMMonth"
        Me.CboMMonth.Size = New System.Drawing.Size(75, 20)
        Me.CboMMonth.TabIndex = 2
        '
        'txtMDay_mm
        '
        Me.txtMDay_mm.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtMDay_mm.Location = New System.Drawing.Point(9, 617)
        Me.txtMDay_mm.Name = "txtMDay_mm"
        Me.txtMDay_mm.Size = New System.Drawing.Size(75, 22)
        Me.txtMDay_mm.TabIndex = 6
        Me.txtMDay_mm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(88, 565)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 12)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Trans. Month"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(7, 565)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 12)
        Me.Label2.TabIndex = 17
        Me.Label2.Text = "Trans. Year"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(168, 565)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 12)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "A/E code"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(445, 565)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 12)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "A/C Code"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(169, 603)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(41, 12)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Product"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(7, 603)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 12)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "Lot (Day)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label7.Location = New System.Drawing.Point(88, 603)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 12)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Lot (Night)"
        '
        'txtMNight_mm
        '
        Me.txtMNight_mm.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtMNight_mm.Location = New System.Drawing.Point(90, 617)
        Me.txtMNight_mm.Name = "txtMNight_mm"
        Me.txtMNight_mm.Size = New System.Drawing.Size(75, 22)
        Me.txtMNight_mm.TabIndex = 7
        Me.txtMNight_mm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(542, 646)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 12
        Me.btnAdd.Text = "New"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnModify
        '
        Me.btnModify.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnModify.Location = New System.Drawing.Point(598, 646)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(50, 55)
        Me.btnModify.TabIndex = 13
        Me.btnModify.Text = "Adjust"
        Me.btnModify.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(652, 646)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(50, 55)
        Me.btnDel.TabIndex = 14
        Me.btnDel.Text = "Delete"
        Me.btnDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'CboMAccNo
        '
        Me.CboMAccNo.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CboMAccNo.FormattingEnabled = True
        Me.CboMAccNo.Location = New System.Drawing.Point(447, 580)
        Me.CboMAccNo.Name = "CboMAccNo"
        Me.CboMAccNo.Size = New System.Drawing.Size(100, 20)
        Me.CboMAccNo.TabIndex = 4
        '
        'CboMAeno
        '
        Me.CboMAeno.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CboMAeno.FormattingEnabled = True
        Me.CboMAeno.Location = New System.Drawing.Point(171, 580)
        Me.CboMAeno.Name = "CboMAeno"
        Me.CboMAeno.Size = New System.Drawing.Size(100, 20)
        Me.CboMAeno.TabIndex = 3
        '
        'CboMCallPut
        '
        Me.CboMCallPut.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMCallPut.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CboMCallPut.FormattingEnabled = True
        Me.CboMCallPut.ItemHeight = 12
        Me.CboMCallPut.Location = New System.Drawing.Point(447, 620)
        Me.CboMCallPut.Name = "CboMCallPut"
        Me.CboMCallPut.Size = New System.Drawing.Size(100, 20)
        Me.CboMCallPut.TabIndex = 9
        Me.CboMCallPut.Visible = False
        '
        'LbCallPut
        '
        Me.LbCallPut.AutoSize = True
        Me.LbCallPut.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.LbCallPut.Location = New System.Drawing.Point(445, 603)
        Me.LbCallPut.Name = "LbCallPut"
        Me.LbCallPut.Size = New System.Drawing.Size(48, 12)
        Me.LbCallPut.TabIndex = 26
        Me.LbCallPut.Text = "Call / Put"
        Me.LbCallPut.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label13.Location = New System.Drawing.Point(199, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(428, 22)
        Me.Label13.TabIndex = 28
        Me.Label13.Text = "Transaction Adjustment (Futures and Option)"
        '
        'TxtMAeName
        '
        Me.TxtMAeName.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.TxtMAeName.Location = New System.Drawing.Point(277, 580)
        Me.TxtMAeName.Name = "TxtMAeName"
        Me.TxtMAeName.ReadOnly = True
        Me.TxtMAeName.Size = New System.Drawing.Size(164, 22)
        Me.TxtMAeName.TabIndex = 5
        '
        'txtMAcName
        '
        Me.txtMAcName.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtMAcName.Location = New System.Drawing.Point(553, 580)
        Me.txtMAcName.Name = "txtMAcName"
        Me.txtMAcName.ReadOnly = True
        Me.txtMAcName.Size = New System.Drawing.Size(164, 22)
        Me.txtMAcName.TabIndex = 7
        '
        'label50
        '
        Me.label50.AutoSize = True
        Me.label50.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.label50.Location = New System.Drawing.Point(275, 565)
        Me.label50.Name = "label50"
        Me.label50.Size = New System.Drawing.Size(53, 12)
        Me.label50.TabIndex = 20
        Me.label50.Text = "A/E Name"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label14.Location = New System.Drawing.Point(551, 565)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 12)
        Me.Label14.TabIndex = 22
        Me.Label14.Text = "A/C Name"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.dtgTrade)
        Me.Panel2.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.Panel2.Location = New System.Drawing.Point(4, 103)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(825, 461)
        Me.Panel2.TabIndex = 1
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label15.Location = New System.Drawing.Point(721, 564)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(49, 12)
        Me.Label15.TabIndex = 27
        Me.Label15.Text = "Currency"
        '
        'CboMCcy
        '
        Me.CboMCcy.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.CboMCcy.FormattingEnabled = True
        Me.CboMCcy.ItemHeight = 12
        Me.CboMCcy.Location = New System.Drawing.Point(723, 580)
        Me.CboMCcy.Name = "CboMCcy"
        Me.CboMCcy.Size = New System.Drawing.Size(100, 20)
        Me.CboMCcy.TabIndex = 5
        '
        'cboMCommod
        '
        Me.cboMCommod.FormattingEnabled = True
        Me.cboMCommod.Location = New System.Drawing.Point(171, 615)
        Me.cboMCommod.Name = "cboMCommod"
        Me.cboMCommod.Size = New System.Drawing.Size(100, 23)
        Me.cboMCommod.TabIndex = 8
        '
        'txtMProductName
        '
        Me.txtMProductName.Location = New System.Drawing.Point(277, 618)
        Me.txtMProductName.Name = "txtMProductName"
        Me.txtMProductName.ReadOnly = True
        Me.txtMProductName.Size = New System.Drawing.Size(164, 21)
        Me.txtMProductName.TabIndex = 29
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("PMingLiU", 9.0!)
        Me.Label16.Location = New System.Drawing.Point(275, 603)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(71, 12)
        Me.Label16.TabIndex = 30
        Me.Label16.Text = "Product Name"
        '
        'txtMMarket
        '
        Me.txtMMarket.Location = New System.Drawing.Point(553, 620)
        Me.txtMMarket.Name = "txtMMarket"
        Me.txtMMarket.Size = New System.Drawing.Size(164, 21)
        Me.txtMMarket.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(550, 603)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 15)
        Me.Label12.TabIndex = 32
        Me.Label12.Text = "Market"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(721, 604)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(59, 12)
        Me.Label17.TabIndex = 34
        Me.Label17.Text = "Trade Type"
        '
        'cboTradeType
        '
        Me.cboTradeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboTradeType.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboTradeType.FormattingEnabled = True
        Me.cboTradeType.ItemHeight = 12
        Me.cboTradeType.Location = New System.Drawing.Point(723, 620)
        Me.cboTradeType.Name = "cboTradeType"
        Me.cboTradeType.Size = New System.Drawing.Size(100, 20)
        Me.cboTradeType.TabIndex = 11
        '
        'txtDayComm
        '
        Me.txtDayComm.Location = New System.Drawing.Point(9, 660)
        Me.txtDayComm.Name = "txtDayComm"
        Me.txtDayComm.Size = New System.Drawing.Size(75, 21)
        Me.txtDayComm.TabIndex = 35
        Me.txtDayComm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtNightComm
        '
        Me.txtNightComm.Location = New System.Drawing.Point(90, 660)
        Me.txtNightComm.Name = "txtNightComm"
        Me.txtNightComm.Size = New System.Drawing.Size(75, 21)
        Me.txtNightComm.TabIndex = 36
        Me.txtNightComm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotComm
        '
        Me.txtTotComm.Location = New System.Drawing.Point(171, 660)
        Me.txtTotComm.Name = "txtTotComm"
        Me.txtTotComm.Size = New System.Drawing.Size(100, 21)
        Me.txtTotComm.TabIndex = 37
        Me.txtTotComm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(7, 646)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(62, 12)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Day Comm."
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label19.Location = New System.Drawing.Point(88, 645)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(69, 12)
        Me.Label19.TabIndex = 39
        Me.Label19.Text = "Night Comm."
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(169, 645)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(67, 12)
        Me.Label20.TabIndex = 40
        Me.Label20.Text = "Total Comm."
        '
        'FrmTransAdjF
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(832, 709)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtTotComm)
        Me.Controls.Add(Me.txtNightComm)
        Me.Controls.Add(Me.txtDayComm)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.cboTradeType)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtMMarket)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.txtMProductName)
        Me.Controls.Add(Me.cboMCommod)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CboMCcy)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.label50)
        Me.Controls.Add(Me.txtMAcName)
        Me.Controls.Add(Me.TxtMAeName)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.LbCallPut)
        Me.Controls.Add(Me.CboMCallPut)
        Me.Controls.Add(Me.CboMAeno)
        Me.Controls.Add(Me.CboMAccNo)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.txtMNight_mm)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMDay_mm)
        Me.Controls.Add(Me.CboMMonth)
        Me.Controls.Add(Me.cboMYr)
        Me.Controls.Add(Me.SearchBox)
        Me.KeyPreview = True
        Me.Name = "FrmTransAdjF"
        Me.Text = "Transaction Adjustment (Futures and Option)"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.SearchBox, 0)
        Me.Controls.SetChildIndex(Me.cboMYr, 0)
        Me.Controls.SetChildIndex(Me.CboMMonth, 0)
        Me.Controls.SetChildIndex(Me.txtMDay_mm, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.txtMNight_mm, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnModify, 0)
        Me.Controls.SetChildIndex(Me.btnDel, 0)
        Me.Controls.SetChildIndex(Me.CboMAccNo, 0)
        Me.Controls.SetChildIndex(Me.CboMAeno, 0)
        Me.Controls.SetChildIndex(Me.CboMCallPut, 0)
        Me.Controls.SetChildIndex(Me.LbCallPut, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.TxtMAeName, 0)
        Me.Controls.SetChildIndex(Me.txtMAcName, 0)
        Me.Controls.SetChildIndex(Me.label50, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.CboMCcy, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.cboMCommod, 0)
        Me.Controls.SetChildIndex(Me.txtMProductName, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.txtMMarket, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.cboTradeType, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.txtDayComm, 0)
        Me.Controls.SetChildIndex(Me.txtNightComm, 0)
        Me.Controls.SetChildIndex(Me.txtTotComm, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.SearchBox.ResumeLayout(False)
        Me.SearchBox.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.dtgTrade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SearchBox As System.Windows.Forms.GroupBox
    Friend WithEvents dtgTrade As System.Windows.Forms.DataGridView
    Friend WithEvents cboMYr As ESL.myComboBox
    Friend WithEvents CboMMonth As ESL.myComboBox
    Friend WithEvents txtMDay_mm As ESL.myNumericBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtMNight_mm As ESL.myNumericBox
    Friend WithEvents CboSMonth As ESL.myComboBox
    Friend WithEvents CboSYr As ESL.myComboBox
    Friend WithEvents label8 As System.Windows.Forms.Label
    Friend WithEvents Year As System.Windows.Forms.Label
    Friend WithEvents btnEnquiry As ESL.myButton
    Friend WithEvents txtSAccno As ESL.myTextbox
    Friend WithEvents txtSAeno As ESL.myTextbox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnModify As ESL.myButton
    Friend WithEvents btnDel As ESL.myButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents RBAll As ESL.myRadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents RBDel As ESL.myRadioButton
    Friend WithEvents RBAdj As ESL.myRadioButton
    Friend WithEvents CboMAccNo As ESL.myComboBox
    Friend WithEvents CboMAeno As ESL.myComboBox
    Friend WithEvents CboMCallPut As ESL.myComboBox
    Friend WithEvents LbCallPut As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TxtMAeName As ESL.myTextbox
    Friend WithEvents txtMAcName As ESL.myTextbox
    Friend WithEvents label50 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents CboMCcy As ESL.myComboBox
    Friend WithEvents cboMCommod As ESL.myComboBox
    Friend WithEvents txtMProductName As ESL.myTextbox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtMMarket As ESL.myTextbox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents cboTradeType As ESL.myComboBox
    Friend WithEvents txtDayComm As ESL.myNumericBox
    Friend WithEvents txtNightComm As ESL.myNumericBox
    Friend WithEvents txtTotComm As ESL.myNumericBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dtgAdjaction As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgtxmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgaeno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgAename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgAccno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgAccName1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgAccName2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgCommod As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgMth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgCall_Put As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgStrike As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgS_price_str As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgCommission_mm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgexchange_fee_mm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgAe_rebate_mm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgday_mm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgnight_mm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgtg_mm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents day_comm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents night_comm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgmarketname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgTradeType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgccy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgoid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgRecordID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgnight_dd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgday_dd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgexchange_fee_dd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgtg_dd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgcommission_dd As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgae_rebate_dd As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
