<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmTransAdjS
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
        Me.CommTradeGrid = New System.Windows.Forms.DataGridView
        Me.adj_action = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.oid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.aename = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.accno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.accname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.stkno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.stkname = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.avgprice = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grossamt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.commission = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tradetype = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.MyButtonAdd = New ESL.myButton(Me.components)
        Me.MyButtonModify = New ESL.myButton(Me.components)
        Me.MyButtonDel = New ESL.myButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.MOid = New ESL.myTextbox
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.MStk = New ESL.myTextbox
        Me.MTDate = New ESL.myDateTimePicker
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.MYr = New ESL.myComboBox(Me.components)
        Me.MMonth = New ESL.myComboBox(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label25 = New System.Windows.Forms.Label
        Me.MQty = New ESL.myNumericBox
        Me.MPrice = New ESL.myNumericBox
        Me.MgrossAmt = New ESL.myNumericBox
        Me.MCommRate = New ESL.myNumericBox
        Me.MComm = New ESL.myNumericBox
        Me.MTtype = New ESL.myComboBox(Me.components)
        Me.MAE = New ESL.myComboBox(Me.components)
        Me.MAC = New ESL.myComboBox(Me.components)
        Me.Label19 = New System.Windows.Forms.Label
        Me.tc = New System.Windows.Forms.TabControl
        Me.tp1 = New System.Windows.Forms.TabPage
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.CboAdjSYr = New ESL.myComboBox(Me.components)
        Me.CboAdjSMonth = New ESL.myComboBox(Me.components)
        Me.SAdj = New System.Windows.Forms.Panel
        Me.MyRadioButtonDel = New ESL.myRadioButton(Me.components)
        Me.MyRadioButtonAll = New ESL.myRadioButton(Me.components)
        Me.MyRadioButtonAdj = New ESL.myRadioButton(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.tp2 = New System.Windows.Forms.TabPage
        Me.TCSDay = New ESL.myDateTimePicker
        Me.PanelAdj = New System.Windows.Forms.Panel
        Me.RBDel = New ESL.myRadioButton(Me.components)
        Me.RBAll = New ESL.myRadioButton(Me.components)
        Me.RBAdj = New ESL.myRadioButton(Me.components)
        Me.Label26 = New System.Windows.Forms.Label
        Me.MyButtonResetSearch = New ESL.myButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.EnqToolStripButton = New ESL.myButton(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.RadioOID = New ESL.myRadioButton(Me.components)
        Me.SYr = New ESL.myComboBox(Me.components)
        Me.SMonth = New ESL.myComboBox(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.SOid = New ESL.myTextbox
        Me.RadioOther = New ESL.myRadioButton(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        Me.SAccNo = New ESL.myTextbox
        Me.Label12 = New System.Windows.Forms.Label
        Me.SAeNo = New ESL.myTextbox
        Me.Label13 = New System.Windows.Forms.Label
        Me.MyCheckBoxDate = New ESL.myCheckBox(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.SAeName = New ESL.myTextbox
        Me.MyCheckBoxAE = New ESL.myCheckBox(Me.components)
        Me.SAccName = New ESL.myTextbox
        Me.PanelButton = New System.Windows.Forms.Panel
        Me.txtAeName = New ESL.myTextbox
        Me.txtAcName = New ESL.myTextbox
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label28 = New System.Windows.Forms.Label
        CType(Me.CommTradeGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tc.SuspendLayout()
        Me.tp1.SuspendLayout()
        Me.SAdj.SuspendLayout()
        Me.tp2.SuspendLayout()
        Me.PanelAdj.SuspendLayout()
        Me.PanelButton.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(737, 577)
        Me.btnCancel.TabIndex = 15
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(681, 577)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Visible = True
        '
        'CommTradeGrid
        '
        Me.CommTradeGrid.AllowUserToAddRows = False
        Me.CommTradeGrid.AllowUserToDeleteRows = False
        Me.CommTradeGrid.AllowUserToResizeColumns = False
        Me.CommTradeGrid.AllowUserToResizeRows = False
        Me.CommTradeGrid.BackgroundColor = System.Drawing.Color.Linen
        Me.CommTradeGrid.ColumnHeadersHeight = 19
        Me.CommTradeGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.CommTradeGrid.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.adj_action, Me.oid, Me.txmonth, Me.ae, Me.aename, Me.accno, Me.accname, Me.tdate, Me.stkno, Me.stkname, Me.avgprice, Me.qty, Me.grossamt, Me.commission, Me.comm_rate, Me.tradetype})
        Me.CommTradeGrid.Location = New System.Drawing.Point(6, 38)
        Me.CommTradeGrid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CommTradeGrid.MultiSelect = False
        Me.CommTradeGrid.Name = "CommTradeGrid"
        Me.CommTradeGrid.ReadOnly = True
        Me.CommTradeGrid.RowHeadersVisible = False
        Me.CommTradeGrid.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.CommTradeGrid.RowTemplate.Height = 16
        Me.CommTradeGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.CommTradeGrid.Size = New System.Drawing.Size(764, 388)
        Me.CommTradeGrid.TabIndex = 3
        '
        'adj_action
        '
        Me.adj_action.DataPropertyName = "adj_action"
        Me.adj_action.HeaderText = "Action"
        Me.adj_action.Name = "adj_action"
        Me.adj_action.ReadOnly = True
        Me.adj_action.Width = 50
        '
        'oid
        '
        Me.oid.DataPropertyName = "oid"
        Me.oid.HeaderText = "OID"
        Me.oid.Name = "oid"
        Me.oid.ReadOnly = True
        Me.oid.Width = 70
        '
        'txmonth
        '
        Me.txmonth.DataPropertyName = "txmonth"
        Me.txmonth.HeaderText = "txmonth"
        Me.txmonth.Name = "txmonth"
        Me.txmonth.ReadOnly = True
        Me.txmonth.Width = 60
        '
        'ae
        '
        Me.ae.DataPropertyName = "aeno"
        Me.ae.HeaderText = "A/E code"
        Me.ae.Name = "ae"
        Me.ae.ReadOnly = True
        Me.ae.Width = 80
        '
        'aename
        '
        Me.aename.DataPropertyName = "aename"
        Me.aename.HeaderText = "A/E Name"
        Me.aename.Name = "aename"
        Me.aename.ReadOnly = True
        Me.aename.Width = 160
        '
        'accno
        '
        Me.accno.DataPropertyName = "accno"
        Me.accno.HeaderText = "A/C code"
        Me.accno.Name = "accno"
        Me.accno.ReadOnly = True
        Me.accno.Width = 90
        '
        'accname
        '
        Me.accname.DataPropertyName = "accname"
        Me.accname.HeaderText = "A/C Name"
        Me.accname.Name = "accname"
        Me.accname.ReadOnly = True
        Me.accname.Width = 180
        '
        'tdate
        '
        Me.tdate.DataPropertyName = "tdate"
        Me.tdate.HeaderText = "Trade Date"
        Me.tdate.Name = "tdate"
        Me.tdate.ReadOnly = True
        Me.tdate.Width = 70
        '
        'stkno
        '
        Me.stkno.DataPropertyName = "stkno"
        Me.stkno.HeaderText = "Stock"
        Me.stkno.Name = "stkno"
        Me.stkno.ReadOnly = True
        Me.stkno.Width = 70
        '
        'stkname
        '
        Me.stkname.DataPropertyName = "stkname"
        Me.stkname.HeaderText = "Stock Name"
        Me.stkname.Name = "stkname"
        Me.stkname.ReadOnly = True
        Me.stkname.Width = 150
        '
        'avgprice
        '
        Me.avgprice.DataPropertyName = "avgprice"
        Me.avgprice.HeaderText = "Avg. Price"
        Me.avgprice.Name = "avgprice"
        Me.avgprice.ReadOnly = True
        Me.avgprice.Width = 70
        '
        'qty
        '
        Me.qty.DataPropertyName = "qty"
        Me.qty.HeaderText = "Qty"
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        Me.qty.Width = 60
        '
        'grossamt
        '
        Me.grossamt.DataPropertyName = "grossamt"
        Me.grossamt.HeaderText = "Gross Amount"
        Me.grossamt.Name = "grossamt"
        Me.grossamt.ReadOnly = True
        Me.grossamt.Width = 70
        '
        'commission
        '
        Me.commission.DataPropertyName = "comm"
        Me.commission.HeaderText = "Commission"
        Me.commission.Name = "commission"
        Me.commission.ReadOnly = True
        Me.commission.Width = 90
        '
        'comm_rate
        '
        Me.comm_rate.DataPropertyName = "comm_rate"
        Me.comm_rate.HeaderText = "Comm (%)"
        Me.comm_rate.Name = "comm_rate"
        Me.comm_rate.ReadOnly = True
        Me.comm_rate.Width = 80
        '
        'tradetype
        '
        Me.tradetype.DataPropertyName = "ttype"
        Me.tradetype.HeaderText = "Trade Type"
        Me.tradetype.Name = "tradetype"
        Me.tradetype.ReadOnly = True
        Me.tradetype.Width = 70
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label1.Location = New System.Drawing.Point(253, 499)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 12)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "A/E code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(526, 499)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 12)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "A/C code"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(140, 537)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(22, 12)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Qty"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label4.Location = New System.Drawing.Point(637, 537)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(63, 12)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Commission"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label5.Location = New System.Drawing.Point(12, 578)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(57, 12)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Comm (%)"
        '
        'MyButtonAdd
        '
        Me.MyButtonAdd.Location = New System.Drawing.Point(3, 0)
        Me.MyButtonAdd.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyButtonAdd.Name = "MyButtonAdd"
        Me.MyButtonAdd.Size = New System.Drawing.Size(50, 55)
        Me.MyButtonAdd.TabIndex = 0
        Me.MyButtonAdd.Text = "New"
        Me.MyButtonAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MyButtonAdd.UseVisualStyleBackColor = True
        '
        'MyButtonModify
        '
        Me.MyButtonModify.Location = New System.Drawing.Point(59, 1)
        Me.MyButtonModify.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyButtonModify.Name = "MyButtonModify"
        Me.MyButtonModify.Size = New System.Drawing.Size(50, 55)
        Me.MyButtonModify.TabIndex = 1
        Me.MyButtonModify.Text = "Adjust"
        Me.MyButtonModify.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MyButtonModify.UseVisualStyleBackColor = True
        '
        'MyButtonDel
        '
        Me.MyButtonDel.Location = New System.Drawing.Point(115, 1)
        Me.MyButtonDel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyButtonDel.Name = "MyButtonDel"
        Me.MyButtonDel.Size = New System.Drawing.Size(50, 55)
        Me.MyButtonDel.TabIndex = 2
        Me.MyButtonDel.Text = "Delete"
        Me.MyButtonDel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MyButtonDel.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label6.Location = New System.Drawing.Point(141, 499)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 12)
        Me.Label6.TabIndex = 23
        Me.Label6.Text = "OID"
        '
        'MOid
        '
        Me.MOid.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MOid.Location = New System.Drawing.Point(144, 512)
        Me.MOid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MOid.Name = "MOid"
        Me.MOid.Size = New System.Drawing.Size(105, 22)
        Me.MOid.TabIndex = 3
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label17.Location = New System.Drawing.Point(252, 537)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(56, 12)
        Me.Label17.TabIndex = 24
        Me.Label17.Text = "Trade Date"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label18.Location = New System.Drawing.Point(11, 537)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(31, 12)
        Me.Label18.TabIndex = 25
        Me.Label18.Text = "Stock"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label20.Location = New System.Drawing.Point(141, 578)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(59, 12)
        Me.Label20.TabIndex = 27
        Me.Label20.Text = "Trade Type"
        '
        'MStk
        '
        Me.MStk.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MStk.Location = New System.Drawing.Point(13, 550)
        Me.MStk.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MStk.Name = "MStk"
        Me.MStk.Size = New System.Drawing.Size(123, 22)
        Me.MStk.TabIndex = 5
        '
        'MTDate
        '
        Me.MTDate.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MTDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.MTDate.Location = New System.Drawing.Point(254, 550)
        Me.MTDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MTDate.MaxDate = New Date(2099, 12, 31, 0, 0, 0, 0)
        Me.MTDate.MinDate = New Date(1950, 1, 1, 0, 0, 0, 0)
        Me.MTDate.Name = "MTDate"
        Me.MTDate.Size = New System.Drawing.Size(105, 22)
        Me.MTDate.TabIndex = 7
        Me.MTDate.Value = New Date(2008, 9, 17, 0, 0, 0, 0)
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label23.Location = New System.Drawing.Point(11, 497)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(27, 12)
        Me.Label23.TabIndex = 38
        Me.Label23.Text = "Year"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label24.Location = New System.Drawing.Point(81, 499)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(36, 12)
        Me.Label24.TabIndex = 39
        Me.Label24.Text = "Month"
        '
        'MYr
        '
        Me.MYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MYr.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MYr.FormattingEnabled = True
        Me.MYr.Location = New System.Drawing.Point(13, 512)
        Me.MYr.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MYr.Name = "MYr"
        Me.MYr.Size = New System.Drawing.Size(64, 20)
        Me.MYr.TabIndex = 1
        '
        'MMonth
        '
        Me.MMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MMonth.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MMonth.FormattingEnabled = True
        Me.MMonth.Location = New System.Drawing.Point(83, 512)
        Me.MMonth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MMonth.Name = "MMonth"
        Me.MMonth.Size = New System.Drawing.Size(54, 20)
        Me.MMonth.TabIndex = 2
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label16.Location = New System.Drawing.Point(366, 537)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(54, 12)
        Me.Label16.TabIndex = 40
        Me.Label16.Text = "Avg. Price"
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label25.Location = New System.Drawing.Point(526, 537)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 12)
        Me.Label25.TabIndex = 42
        Me.Label25.Text = "Gross Amount"
        '
        'MQty
        '
        Me.MQty.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MQty.Location = New System.Drawing.Point(142, 550)
        Me.MQty.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MQty.Name = "MQty"
        Me.MQty.Size = New System.Drawing.Size(106, 22)
        Me.MQty.TabIndex = 6
        Me.MQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MPrice
        '
        Me.MPrice.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MPrice.Location = New System.Drawing.Point(366, 550)
        Me.MPrice.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MPrice.Name = "MPrice"
        Me.MPrice.Size = New System.Drawing.Size(156, 22)
        Me.MPrice.TabIndex = 8
        Me.MPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MgrossAmt
        '
        Me.MgrossAmt.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MgrossAmt.Location = New System.Drawing.Point(528, 550)
        Me.MgrossAmt.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MgrossAmt.Name = "MgrossAmt"
        Me.MgrossAmt.Size = New System.Drawing.Size(105, 22)
        Me.MgrossAmt.TabIndex = 9
        Me.MgrossAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MCommRate
        '
        Me.MCommRate.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MCommRate.Location = New System.Drawing.Point(14, 591)
        Me.MCommRate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MCommRate.Name = "MCommRate"
        Me.MCommRate.Size = New System.Drawing.Size(123, 22)
        Me.MCommRate.TabIndex = 11
        Me.MCommRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MComm
        '
        Me.MComm.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MComm.Location = New System.Drawing.Point(639, 550)
        Me.MComm.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MComm.Name = "MComm"
        Me.MComm.Size = New System.Drawing.Size(148, 22)
        Me.MComm.TabIndex = 10
        Me.MComm.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'MTtype
        '
        Me.MTtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.MTtype.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MTtype.FormattingEnabled = True
        Me.MTtype.Location = New System.Drawing.Point(143, 592)
        Me.MTtype.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MTtype.Name = "MTtype"
        Me.MTtype.Size = New System.Drawing.Size(105, 20)
        Me.MTtype.TabIndex = 12
        '
        'MAE
        '
        Me.MAE.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MAE.FormattingEnabled = True
        Me.MAE.Location = New System.Drawing.Point(255, 512)
        Me.MAE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MAE.Name = "MAE"
        Me.MAE.Size = New System.Drawing.Size(105, 20)
        Me.MAE.TabIndex = 3
        '
        'MAC
        '
        Me.MAC.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.MAC.FormattingEnabled = True
        Me.MAC.Location = New System.Drawing.Point(528, 512)
        Me.MAC.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MAC.Name = "MAC"
        Me.MAC.Size = New System.Drawing.Size(105, 20)
        Me.MAC.TabIndex = 4
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label19.Location = New System.Drawing.Point(237, 8)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(342, 22)
        Me.Label19.TabIndex = 45
        Me.Label19.Text = "Transaction Adjustment (Securities)"
        '
        'tc
        '
        Me.tc.Controls.Add(Me.tp1)
        Me.tc.Controls.Add(Me.tp2)
        Me.tc.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.tc.Location = New System.Drawing.Point(13, 32)
        Me.tc.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tc.Name = "tc"
        Me.tc.SelectedIndex = 0
        Me.tc.Size = New System.Drawing.Size(786, 459)
        Me.tc.TabIndex = 0
        '
        'tp1
        '
        Me.tp1.BackColor = System.Drawing.Color.Linen
        Me.tp1.Controls.Add(Me.Label21)
        Me.tp1.Controls.Add(Me.Label22)
        Me.tp1.Controls.Add(Me.CboAdjSYr)
        Me.tp1.Controls.Add(Me.CboAdjSMonth)
        Me.tp1.Controls.Add(Me.SAdj)
        Me.tp1.Controls.Add(Me.CommTradeGrid)
        Me.tp1.Font = New System.Drawing.Font("Arial", 7.0!)
        Me.tp1.Location = New System.Drawing.Point(4, 24)
        Me.tp1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tp1.Name = "tp1"
        Me.tp1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tp1.Size = New System.Drawing.Size(778, 431)
        Me.tp1.TabIndex = 0
        Me.tp1.Text = "Adjustment"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label21.Location = New System.Drawing.Point(6, 12)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(32, 15)
        Me.Label21.TabIndex = 28
        Me.Label21.Text = "Year"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label22.Location = New System.Drawing.Point(113, 12)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(40, 15)
        Me.Label22.TabIndex = 29
        Me.Label22.Text = "Month"
        '
        'CboAdjSYr
        '
        Me.CboAdjSYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAdjSYr.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.CboAdjSYr.FormattingEnabled = True
        Me.CboAdjSYr.Location = New System.Drawing.Point(43, 9)
        Me.CboAdjSYr.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CboAdjSYr.Name = "CboAdjSYr"
        Me.CboAdjSYr.Size = New System.Drawing.Size(61, 23)
        Me.CboAdjSYr.TabIndex = 0
        '
        'CboAdjSMonth
        '
        Me.CboAdjSMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboAdjSMonth.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.CboAdjSMonth.FormattingEnabled = True
        Me.CboAdjSMonth.Location = New System.Drawing.Point(160, 9)
        Me.CboAdjSMonth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.CboAdjSMonth.Name = "CboAdjSMonth"
        Me.CboAdjSMonth.Size = New System.Drawing.Size(60, 23)
        Me.CboAdjSMonth.TabIndex = 1
        '
        'SAdj
        '
        Me.SAdj.Controls.Add(Me.MyRadioButtonDel)
        Me.SAdj.Controls.Add(Me.MyRadioButtonAll)
        Me.SAdj.Controls.Add(Me.MyRadioButtonAdj)
        Me.SAdj.Controls.Add(Me.Label10)
        Me.SAdj.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SAdj.Location = New System.Drawing.Point(244, 6)
        Me.SAdj.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SAdj.Name = "SAdj"
        Me.SAdj.Size = New System.Drawing.Size(286, 28)
        Me.SAdj.TabIndex = 2
        '
        'MyRadioButtonDel
        '
        Me.MyRadioButtonDel.AutoSize = True
        Me.MyRadioButtonDel.Location = New System.Drawing.Point(206, 5)
        Me.MyRadioButtonDel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyRadioButtonDel.Name = "MyRadioButtonDel"
        Me.MyRadioButtonDel.Size = New System.Drawing.Size(68, 19)
        Me.MyRadioButtonDel.TabIndex = 2
        Me.MyRadioButtonDel.TabStop = True
        Me.MyRadioButtonDel.Text = "Deleted"
        Me.MyRadioButtonDel.UseVisualStyleBackColor = True
        '
        'MyRadioButtonAll
        '
        Me.MyRadioButtonAll.AutoSize = True
        Me.MyRadioButtonAll.CausesValidation = False
        Me.MyRadioButtonAll.Checked = True
        Me.MyRadioButtonAll.Location = New System.Drawing.Point(76, 5)
        Me.MyRadioButtonAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyRadioButtonAll.Name = "MyRadioButtonAll"
        Me.MyRadioButtonAll.Size = New System.Drawing.Size(46, 19)
        Me.MyRadioButtonAll.TabIndex = 0
        Me.MyRadioButtonAll.TabStop = True
        Me.MyRadioButtonAll.Text = "ALL"
        Me.MyRadioButtonAll.UseVisualStyleBackColor = True
        '
        'MyRadioButtonAdj
        '
        Me.MyRadioButtonAdj.AutoSize = True
        Me.MyRadioButtonAdj.CausesValidation = False
        Me.MyRadioButtonAdj.Location = New System.Drawing.Point(127, 5)
        Me.MyRadioButtonAdj.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyRadioButtonAdj.Name = "MyRadioButtonAdj"
        Me.MyRadioButtonAdj.Size = New System.Drawing.Size(73, 19)
        Me.MyRadioButtonAdj.TabIndex = 1
        Me.MyRadioButtonAdj.Text = "Adjusted"
        Me.MyRadioButtonAdj.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(3, 7)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 15)
        Me.Label10.TabIndex = 27
        Me.Label10.Text = "Adjustment"
        '
        'tp2
        '
        Me.tp2.BackColor = System.Drawing.Color.Linen
        Me.tp2.Controls.Add(Me.TCSDay)
        Me.tp2.Controls.Add(Me.PanelAdj)
        Me.tp2.Controls.Add(Me.MyButtonResetSearch)
        Me.tp2.Controls.Add(Me.Label7)
        Me.tp2.Controls.Add(Me.EnqToolStripButton)
        Me.tp2.Controls.Add(Me.Label8)
        Me.tp2.Controls.Add(Me.RadioOID)
        Me.tp2.Controls.Add(Me.SYr)
        Me.tp2.Controls.Add(Me.SMonth)
        Me.tp2.Controls.Add(Me.Label9)
        Me.tp2.Controls.Add(Me.SOid)
        Me.tp2.Controls.Add(Me.RadioOther)
        Me.tp2.Controls.Add(Me.Label11)
        Me.tp2.Controls.Add(Me.SAccNo)
        Me.tp2.Controls.Add(Me.Label12)
        Me.tp2.Controls.Add(Me.SAeNo)
        Me.tp2.Controls.Add(Me.Label13)
        Me.tp2.Controls.Add(Me.MyCheckBoxDate)
        Me.tp2.Controls.Add(Me.Label14)
        Me.tp2.Controls.Add(Me.Label15)
        Me.tp2.Controls.Add(Me.SAeName)
        Me.tp2.Controls.Add(Me.MyCheckBoxAE)
        Me.tp2.Controls.Add(Me.SAccName)
        Me.tp2.Location = New System.Drawing.Point(4, 24)
        Me.tp2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tp2.Name = "tp2"
        Me.tp2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.tp2.Size = New System.Drawing.Size(778, 431)
        Me.tp2.TabIndex = 1
        Me.tp2.Text = "Advance Search"
        '
        'TCSDay
        '
        Me.TCSDay.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.TCSDay.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.TCSDay.Location = New System.Drawing.Point(450, 68)
        Me.TCSDay.Name = "TCSDay"
        Me.TCSDay.Size = New System.Drawing.Size(112, 21)
        Me.TCSDay.TabIndex = 59
        Me.TCSDay.Visible = False
        '
        'PanelAdj
        '
        Me.PanelAdj.Controls.Add(Me.RBDel)
        Me.PanelAdj.Controls.Add(Me.RBAll)
        Me.PanelAdj.Controls.Add(Me.RBAdj)
        Me.PanelAdj.Controls.Add(Me.Label26)
        Me.PanelAdj.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.PanelAdj.Location = New System.Drawing.Point(55, 184)
        Me.PanelAdj.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelAdj.Name = "PanelAdj"
        Me.PanelAdj.Size = New System.Drawing.Size(286, 76)
        Me.PanelAdj.TabIndex = 58
        '
        'RBDel
        '
        Me.RBDel.AutoSize = True
        Me.RBDel.Location = New System.Drawing.Point(197, 35)
        Me.RBDel.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RBDel.Name = "RBDel"
        Me.RBDel.Size = New System.Drawing.Size(68, 19)
        Me.RBDel.TabIndex = 2
        Me.RBDel.TabStop = True
        Me.RBDel.Text = "Deleted"
        Me.RBDel.UseVisualStyleBackColor = True
        '
        'RBAll
        '
        Me.RBAll.AutoSize = True
        Me.RBAll.CausesValidation = False
        Me.RBAll.Checked = True
        Me.RBAll.Location = New System.Drawing.Point(36, 35)
        Me.RBAll.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RBAll.Name = "RBAll"
        Me.RBAll.Size = New System.Drawing.Size(46, 19)
        Me.RBAll.TabIndex = 0
        Me.RBAll.TabStop = True
        Me.RBAll.Text = "ALL"
        Me.RBAll.UseVisualStyleBackColor = True
        '
        'RBAdj
        '
        Me.RBAdj.AutoSize = True
        Me.RBAdj.CausesValidation = False
        Me.RBAdj.Location = New System.Drawing.Point(102, 35)
        Me.RBAdj.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RBAdj.Name = "RBAdj"
        Me.RBAdj.Size = New System.Drawing.Size(73, 19)
        Me.RBAdj.TabIndex = 1
        Me.RBAdj.Text = "Adjusted"
        Me.RBAdj.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.AutoSize = True
        Me.Label26.Location = New System.Drawing.Point(3, 12)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(72, 15)
        Me.Label26.TabIndex = 27
        Me.Label26.Text = "Adjustment:"
        '
        'MyButtonResetSearch
        '
        Me.MyButtonResetSearch.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MyButtonResetSearch.Location = New System.Drawing.Point(294, 269)
        Me.MyButtonResetSearch.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyButtonResetSearch.Name = "MyButtonResetSearch"
        Me.MyButtonResetSearch.Size = New System.Drawing.Size(92, 22)
        Me.MyButtonResetSearch.TabIndex = 3
        Me.MyButtonResetSearch.Text = "Reset"
        Me.MyButtonResetSearch.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label7.Location = New System.Drawing.Point(52, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 15)
        Me.Label7.TabIndex = 24
        Me.Label7.Text = "Year"
        '
        'EnqToolStripButton
        '
        Me.EnqToolStripButton.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.EnqToolStripButton.Location = New System.Drawing.Point(392, 269)
        Me.EnqToolStripButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.EnqToolStripButton.Name = "EnqToolStripButton"
        Me.EnqToolStripButton.Size = New System.Drawing.Size(92, 22)
        Me.EnqToolStripButton.TabIndex = 2
        Me.EnqToolStripButton.Text = "Enquiry"
        Me.EnqToolStripButton.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label8.Location = New System.Drawing.Point(178, 74)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(40, 15)
        Me.Label8.TabIndex = 25
        Me.Label8.Text = "Month"
        '
        'RadioOID
        '
        Me.RadioOID.AutoSize = True
        Me.RadioOID.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.RadioOID.Location = New System.Drawing.Point(35, 21)
        Me.RadioOID.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioOID.Name = "RadioOID"
        Me.RadioOID.Size = New System.Drawing.Size(46, 19)
        Me.RadioOID.TabIndex = 0
        Me.RadioOID.Text = "OID"
        Me.RadioOID.UseVisualStyleBackColor = True
        '
        'SYr
        '
        Me.SYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SYr.Enabled = False
        Me.SYr.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SYr.FormattingEnabled = True
        Me.SYr.Location = New System.Drawing.Point(90, 71)
        Me.SYr.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SYr.Name = "SYr"
        Me.SYr.Size = New System.Drawing.Size(61, 23)
        Me.SYr.TabIndex = 3
        '
        'SMonth
        '
        Me.SMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.SMonth.Enabled = False
        Me.SMonth.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SMonth.FormattingEnabled = True
        Me.SMonth.Location = New System.Drawing.Point(226, 71)
        Me.SMonth.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SMonth.Name = "SMonth"
        Me.SMonth.Size = New System.Drawing.Size(61, 23)
        Me.SMonth.TabIndex = 4
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label9.Location = New System.Drawing.Point(105, 107)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 15)
        Me.Label9.TabIndex = 57
        Me.Label9.Text = "AE / ACC"
        '
        'SOid
        '
        Me.SOid.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SOid.Location = New System.Drawing.Point(84, 20)
        Me.SOid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SOid.Name = "SOid"
        Me.SOid.Size = New System.Drawing.Size(94, 21)
        Me.SOid.TabIndex = 1
        '
        'RadioOther
        '
        Me.RadioOther.AutoSize = True
        Me.RadioOther.Checked = True
        Me.RadioOther.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.RadioOther.Location = New System.Drawing.Point(35, 52)
        Me.RadioOther.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.RadioOther.Name = "RadioOther"
        Me.RadioOther.Size = New System.Drawing.Size(55, 19)
        Me.RadioOther.TabIndex = 2
        Me.RadioOther.TabStop = True
        Me.RadioOther.Text = "Other"
        Me.RadioOther.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label11.Location = New System.Drawing.Point(113, 132)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(61, 15)
        Me.Label11.TabIndex = 28
        Me.Label11.Text = "A/E code :"
        '
        'SAccNo
        '
        Me.SAccNo.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SAccNo.Location = New System.Drawing.Point(181, 159)
        Me.SAccNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SAccNo.Name = "SAccNo"
        Me.SAccNo.Size = New System.Drawing.Size(112, 21)
        Me.SAccNo.TabIndex = 10
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label12.Location = New System.Drawing.Point(298, 132)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 15)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "A/E name :"
        '
        'SAeNo
        '
        Me.SAeNo.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SAeNo.Location = New System.Drawing.Point(181, 132)
        Me.SAeNo.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SAeNo.Name = "SAeNo"
        Me.SAeNo.Size = New System.Drawing.Size(112, 21)
        Me.SAeNo.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label13.Location = New System.Drawing.Point(113, 159)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 15)
        Me.Label13.TabIndex = 30
        Me.Label13.Text = "A/C code :"
        '
        'MyCheckBoxDate
        '
        Me.MyCheckBoxDate.AutoSize = True
        Me.MyCheckBoxDate.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MyCheckBoxDate.Location = New System.Drawing.Point(345, 72)
        Me.MyCheckBoxDate.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyCheckBoxDate.Name = "MyCheckBoxDate"
        Me.MyCheckBoxDate.Size = New System.Drawing.Size(15, 14)
        Me.MyCheckBoxDate.TabIndex = 5
        Me.MyCheckBoxDate.UseVisualStyleBackColor = True
        Me.MyCheckBoxDate.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label14.Location = New System.Drawing.Point(298, 159)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 15)
        Me.Label14.TabIndex = 31
        Me.Label14.Text = "A/C name :"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label15.Location = New System.Drawing.Point(374, 72)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(74, 15)
        Me.Label15.TabIndex = 32
        Me.Label15.Text = "Trans. Date:"
        Me.Label15.Visible = False
        '
        'SAeName
        '
        Me.SAeName.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SAeName.Location = New System.Drawing.Point(372, 129)
        Me.SAeName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SAeName.Name = "SAeName"
        Me.SAeName.Size = New System.Drawing.Size(112, 21)
        Me.SAeName.TabIndex = 9
        '
        'MyCheckBoxAE
        '
        Me.MyCheckBoxAE.AutoSize = True
        Me.MyCheckBoxAE.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.MyCheckBoxAE.Location = New System.Drawing.Point(76, 108)
        Me.MyCheckBoxAE.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.MyCheckBoxAE.Name = "MyCheckBoxAE"
        Me.MyCheckBoxAE.Size = New System.Drawing.Size(15, 14)
        Me.MyCheckBoxAE.TabIndex = 7
        Me.MyCheckBoxAE.UseVisualStyleBackColor = True
        '
        'SAccName
        '
        Me.SAccName.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.SAccName.Location = New System.Drawing.Point(372, 156)
        Me.SAccName.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.SAccName.Name = "SAccName"
        Me.SAccName.Size = New System.Drawing.Size(112, 21)
        Me.SAccName.TabIndex = 11
        '
        'PanelButton
        '
        Me.PanelButton.Controls.Add(Me.MyButtonAdd)
        Me.PanelButton.Controls.Add(Me.MyButtonModify)
        Me.PanelButton.Controls.Add(Me.MyButtonDel)
        Me.PanelButton.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.PanelButton.Location = New System.Drawing.Point(499, 576)
        Me.PanelButton.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.PanelButton.Name = "PanelButton"
        Me.PanelButton.Size = New System.Drawing.Size(165, 57)
        Me.PanelButton.TabIndex = 13
        '
        'txtAeName
        '
        Me.txtAeName.Enabled = False
        Me.txtAeName.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtAeName.Location = New System.Drawing.Point(366, 512)
        Me.txtAeName.Name = "txtAeName"
        Me.txtAeName.Size = New System.Drawing.Size(156, 22)
        Me.txtAeName.TabIndex = 48
        '
        'txtAcName
        '
        Me.txtAcName.Enabled = False
        Me.txtAcName.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtAcName.Location = New System.Drawing.Point(639, 512)
        Me.txtAcName.Name = "txtAcName"
        Me.txtAcName.Size = New System.Drawing.Size(148, 22)
        Me.txtAcName.TabIndex = 49
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label27.Location = New System.Drawing.Point(363, 496)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(53, 12)
        Me.Label27.TabIndex = 50
        Me.Label27.Text = "A/E Name"
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label28.Location = New System.Drawing.Point(636, 496)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(54, 12)
        Me.Label28.TabIndex = 51
        Me.Label28.Text = "A/C Name"
        '
        'FrmTransAdjS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(808, 637)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.Label27)
        Me.Controls.Add(Me.txtAcName)
        Me.Controls.Add(Me.txtAeName)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.MAC)
        Me.Controls.Add(Me.MAE)
        Me.Controls.Add(Me.MTtype)
        Me.Controls.Add(Me.tc)
        Me.Controls.Add(Me.MComm)
        Me.Controls.Add(Me.PanelButton)
        Me.Controls.Add(Me.MCommRate)
        Me.Controls.Add(Me.MgrossAmt)
        Me.Controls.Add(Me.MPrice)
        Me.Controls.Add(Me.MQty)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.MYr)
        Me.Controls.Add(Me.MMonth)
        Me.Controls.Add(Me.MTDate)
        Me.Controls.Add(Me.MStk)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.MOid)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmTransAdjS"
        Me.Text = "Transaction Adjustment (Securities)"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.MOid, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label20, 0)
        Me.Controls.SetChildIndex(Me.MStk, 0)
        Me.Controls.SetChildIndex(Me.MTDate, 0)
        Me.Controls.SetChildIndex(Me.MMonth, 0)
        Me.Controls.SetChildIndex(Me.MYr, 0)
        Me.Controls.SetChildIndex(Me.Label24, 0)
        Me.Controls.SetChildIndex(Me.Label23, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.Label25, 0)
        Me.Controls.SetChildIndex(Me.MQty, 0)
        Me.Controls.SetChildIndex(Me.MPrice, 0)
        Me.Controls.SetChildIndex(Me.MgrossAmt, 0)
        Me.Controls.SetChildIndex(Me.MCommRate, 0)
        Me.Controls.SetChildIndex(Me.PanelButton, 0)
        Me.Controls.SetChildIndex(Me.MComm, 0)
        Me.Controls.SetChildIndex(Me.tc, 0)
        Me.Controls.SetChildIndex(Me.MTtype, 0)
        Me.Controls.SetChildIndex(Me.MAE, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.MAC, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.txtAeName, 0)
        Me.Controls.SetChildIndex(Me.txtAcName, 0)
        Me.Controls.SetChildIndex(Me.Label27, 0)
        Me.Controls.SetChildIndex(Me.Label28, 0)
        CType(Me.CommTradeGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tc.ResumeLayout(False)
        Me.tp1.ResumeLayout(False)
        Me.tp1.PerformLayout()
        Me.SAdj.ResumeLayout(False)
        Me.SAdj.PerformLayout()
        Me.tp2.ResumeLayout(False)
        Me.tp2.PerformLayout()
        Me.PanelAdj.ResumeLayout(False)
        Me.PanelAdj.PerformLayout()
        Me.PanelButton.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CommTradeGrid As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents MyButtonAdd As ESL.myButton
    Friend WithEvents MyButtonModify As ESL.myButton
    Friend WithEvents MyButtonDel As ESL.myButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MOid As ESL.myTextbox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents MStk As ESL.myTextbox
    Friend WithEvents MTDate As ESL.myDateTimePicker
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents MYr As ESL.myComboBox
    Friend WithEvents MMonth As ESL.myComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents MQty As ESL.myNumericBox
    Friend WithEvents MPrice As ESL.myNumericBox
    Friend WithEvents MgrossAmt As ESL.myNumericBox
    Friend WithEvents MCommRate As ESL.myNumericBox
    Friend WithEvents MComm As ESL.myNumericBox
    Friend WithEvents MTtype As ESL.myComboBox
    Friend WithEvents MAE As ESL.myComboBox
    Friend WithEvents MAC As ESL.myComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents tc As System.Windows.Forms.TabControl
    Friend WithEvents tp1 As System.Windows.Forms.TabPage
    Friend WithEvents tp2 As System.Windows.Forms.TabPage
    Friend WithEvents MyButtonResetSearch As ESL.myButton
    Friend WithEvents EnqToolStripButton As ESL.myButton
    Friend WithEvents SAdj As System.Windows.Forms.Panel
    Friend WithEvents MyRadioButtonDel As ESL.myRadioButton
    Friend WithEvents MyRadioButtonAll As ESL.myRadioButton
    Friend WithEvents MyRadioButtonAdj As ESL.myRadioButton
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents SYr As ESL.myComboBox
    Friend WithEvents SMonth As ESL.myComboBox
    Friend WithEvents RadioOID As ESL.myRadioButton
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents SOid As ESL.myTextbox
    Friend WithEvents RadioOther As ESL.myRadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents SAccNo As ESL.myTextbox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents SAeNo As ESL.myTextbox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents MyCheckBoxDate As ESL.myCheckBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents SAeName As ESL.myTextbox
    Friend WithEvents MyCheckBoxAE As ESL.myCheckBox
    Friend WithEvents SAccName As ESL.myTextbox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents CboAdjSYr As ESL.myComboBox
    Friend WithEvents CboAdjSMonth As ESL.myComboBox
    Friend WithEvents PanelAdj As System.Windows.Forms.Panel
    Friend WithEvents RBDel As ESL.myRadioButton
    Friend WithEvents RBAll As ESL.myRadioButton
    Friend WithEvents RBAdj As ESL.myRadioButton
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents PanelButton As System.Windows.Forms.Panel
    Friend WithEvents txtAeName As ESL.myTextbox
    Friend WithEvents txtAcName As ESL.myTextbox
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents TCSDay As ESL.myDateTimePicker
    Friend WithEvents adj_action As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents oid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aename As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents accno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents accname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stkno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stkname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents avgprice As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grossamt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents commission As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tradetype As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
