<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewedgeTradeMain
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtgTrade = New System.Windows.Forms.DataGridView
        Me.tid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tdate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.monthcode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.product = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.buy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sell = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.period = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clearing = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.levy = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dpTradeDate = New ESL.myDateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtMonthCode = New ESL.myTextbox
        Me.txtPrice = New ESL.myTextbox
        Me.txtComm = New ESL.myTextbox
        Me.txtLevy = New ESL.myTextbox
        Me.txtBuy = New ESL.myTextbox
        Me.txtCommodity = New ESL.myTextbox
        Me.txtSell = New ESL.myTextbox
        Me.txtClearing = New ESL.myTextbox
        Me.btnChange = New ESL.myButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtPeriod = New ESL.myTextbox
        Me.Label10 = New System.Windows.Forms.Label
        Me.cbxCounterParty = New System.Windows.Forms.ComboBox
        CType(Me.dtgTrade, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(513, 428)
        Me.btnCancel.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(457, 428)
        Me.btnSave.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(143, 20)
        Me.Label7.Name = "Label7"
        Me.Label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.Label7.Size = New System.Drawing.Size(282, 22)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Futures Trade History Master"
        '
        'dtgTrade
        '
        Me.dtgTrade.AllowUserToAddRows = False
        Me.dtgTrade.AllowUserToDeleteRows = False
        Me.dtgTrade.AllowUserToResizeRows = False
        Me.dtgTrade.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgTrade.ColumnHeadersHeight = 20
        Me.dtgTrade.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.tid, Me.tdate, Me.monthcode, Me.product, Me.buy, Me.sell, Me.price, Me.period, Me.comm, Me.clearing, Me.levy})
        Me.dtgTrade.Location = New System.Drawing.Point(17, 83)
        Me.dtgTrade.MultiSelect = False
        Me.dtgTrade.Name = "dtgTrade"
        Me.dtgTrade.ReadOnly = True
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle8.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Linen
        DataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dtgTrade.RowHeadersDefaultCellStyle = DataGridViewCellStyle8
        Me.dtgTrade.RowHeadersVisible = False
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.Color.Black
        Me.dtgTrade.RowsDefaultCellStyle = DataGridViewCellStyle9
        Me.dtgTrade.RowTemplate.Height = 24
        Me.dtgTrade.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgTrade.Size = New System.Drawing.Size(546, 234)
        Me.dtgTrade.TabIndex = 1
        '
        'tid
        '
        Me.tid.DataPropertyName = "tid"
        Me.tid.HeaderText = "tid"
        Me.tid.Name = "tid"
        Me.tid.ReadOnly = True
        Me.tid.Visible = False
        Me.tid.Width = 90
        '
        'tdate
        '
        Me.tdate.DataPropertyName = "tdate"
        Me.tdate.HeaderText = "Tran. Date"
        Me.tdate.Name = "tdate"
        Me.tdate.ReadOnly = True
        Me.tdate.Width = 75
        '
        'monthcode
        '
        Me.monthcode.DataPropertyName = "monthcode"
        Me.monthcode.HeaderText = "D. Mth"
        Me.monthcode.Name = "monthcode"
        Me.monthcode.ReadOnly = True
        Me.monthcode.Width = 50
        '
        'product
        '
        Me.product.DataPropertyName = "product"
        Me.product.HeaderText = "Comdy"
        Me.product.Name = "product"
        Me.product.ReadOnly = True
        '
        'buy
        '
        Me.buy.DataPropertyName = "buy"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.buy.DefaultCellStyle = DataGridViewCellStyle1
        Me.buy.HeaderText = "Buy"
        Me.buy.Name = "buy"
        Me.buy.ReadOnly = True
        Me.buy.Width = 35
        '
        'sell
        '
        Me.sell.DataPropertyName = "sell"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.sell.DefaultCellStyle = DataGridViewCellStyle2
        Me.sell.HeaderText = "Sell"
        Me.sell.Name = "sell"
        Me.sell.ReadOnly = True
        Me.sell.Width = 35
        '
        'price
        '
        Me.price.DataPropertyName = "price"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.price.DefaultCellStyle = DataGridViewCellStyle3
        Me.price.HeaderText = "Price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        Me.price.Width = 60
        '
        'period
        '
        Me.period.DataPropertyName = "period"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.period.DefaultCellStyle = DataGridViewCellStyle4
        Me.period.HeaderText = "Period"
        Me.period.Name = "period"
        Me.period.ReadOnly = True
        Me.period.Width = 60
        '
        'comm
        '
        Me.comm.DataPropertyName = "comm"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.comm.DefaultCellStyle = DataGridViewCellStyle5
        Me.comm.HeaderText = "Comm"
        Me.comm.Name = "comm"
        Me.comm.ReadOnly = True
        Me.comm.Width = 50
        '
        'clearing
        '
        Me.clearing.DataPropertyName = "clearing"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.clearing.DefaultCellStyle = DataGridViewCellStyle6
        Me.clearing.HeaderText = "Clearing"
        Me.clearing.Name = "clearing"
        Me.clearing.ReadOnly = True
        Me.clearing.Width = 50
        '
        'levy
        '
        Me.levy.DataPropertyName = "levy"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.levy.DefaultCellStyle = DataGridViewCellStyle7
        Me.levy.HeaderText = "Levy"
        Me.levy.Name = "levy"
        Me.levy.ReadOnly = True
        Me.levy.Width = 50
        '
        'dpTradeDate
        '
        Me.dpTradeDate.CustomFormat = "dd MMM yyyy"
        Me.dpTradeDate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dpTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpTradeDate.Location = New System.Drawing.Point(448, 56)
        Me.dpTradeDate.Name = "dpTradeDate"
        Me.dpTradeDate.Size = New System.Drawing.Size(115, 20)
        Me.dpTradeDate.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(382, 59)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(60, 14)
        Me.Label9.TabIndex = 22
        Me.Label9.Text = "Trade Date"
        '
        'txtMonthCode
        '
        Me.txtMonthCode.Enabled = False
        Me.txtMonthCode.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonthCode.Location = New System.Drawing.Point(93, 323)
        Me.txtMonthCode.Name = "txtMonthCode"
        Me.txtMonthCode.Size = New System.Drawing.Size(100, 20)
        Me.txtMonthCode.TabIndex = 24
        '
        'txtPrice
        '
        Me.txtPrice.Enabled = False
        Me.txtPrice.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(463, 349)
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtPrice.TabIndex = 25
        '
        'txtComm
        '
        Me.txtComm.Enabled = False
        Me.txtComm.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtComm.Location = New System.Drawing.Point(93, 401)
        Me.txtComm.Name = "txtComm"
        Me.txtComm.Size = New System.Drawing.Size(100, 20)
        Me.txtComm.TabIndex = 26
        '
        'txtLevy
        '
        Me.txtLevy.Enabled = False
        Me.txtLevy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLevy.Location = New System.Drawing.Point(463, 401)
        Me.txtLevy.Name = "txtLevy"
        Me.txtLevy.Size = New System.Drawing.Size(100, 20)
        Me.txtLevy.TabIndex = 27
        '
        'txtBuy
        '
        Me.txtBuy.Enabled = False
        Me.txtBuy.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBuy.Location = New System.Drawing.Point(93, 349)
        Me.txtBuy.Name = "txtBuy"
        Me.txtBuy.Size = New System.Drawing.Size(100, 20)
        Me.txtBuy.TabIndex = 28
        '
        'txtCommodity
        '
        Me.txtCommodity.Enabled = False
        Me.txtCommodity.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommodity.Location = New System.Drawing.Point(278, 323)
        Me.txtCommodity.Name = "txtCommodity"
        Me.txtCommodity.Size = New System.Drawing.Size(285, 20)
        Me.txtCommodity.TabIndex = 29
        '
        'txtSell
        '
        Me.txtSell.Enabled = False
        Me.txtSell.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSell.Location = New System.Drawing.Point(278, 349)
        Me.txtSell.Name = "txtSell"
        Me.txtSell.Size = New System.Drawing.Size(100, 20)
        Me.txtSell.TabIndex = 30
        '
        'txtClearing
        '
        Me.txtClearing.Enabled = False
        Me.txtClearing.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClearing.Location = New System.Drawing.Point(278, 401)
        Me.txtClearing.Name = "txtClearing"
        Me.txtClearing.Size = New System.Drawing.Size(100, 20)
        Me.txtClearing.TabIndex = 31
        '
        'btnChange
        '
        Me.btnChange.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnChange.Location = New System.Drawing.Point(202, 375)
        Me.btnChange.Name = "btnChange"
        Me.btnChange.Size = New System.Drawing.Size(100, 21)
        Me.btnChange.TabIndex = 32
        Me.btnChange.Text = "Change"
        Me.btnChange.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnChange.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 326)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 14)
        Me.Label1.TabIndex = 33
        Me.Label1.Text = "Month Code"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(199, 326)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 14)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Commodity"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 351)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(26, 14)
        Me.Label3.TabIndex = 35
        Me.Label3.Text = "Buy"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(199, 352)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(24, 14)
        Me.Label4.TabIndex = 36
        Me.Label4.Text = "Sell"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(382, 352)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(31, 14)
        Me.Label5.TabIndex = 37
        Me.Label5.Text = "Price"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(384, 404)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 14)
        Me.Label6.TabIndex = 38
        Me.Label6.Text = "Levy"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(14, 403)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(39, 14)
        Me.Label8.TabIndex = 39
        Me.Label8.Text = "Comm."
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(199, 404)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(46, 14)
        Me.Label11.TabIndex = 41
        Me.Label11.Text = "Clearing"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(14, 377)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(37, 14)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Period"
        '
        'txtPeriod
        '
        Me.txtPeriod.Enabled = False
        Me.txtPeriod.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriod.Location = New System.Drawing.Point(93, 375)
        Me.txtPeriod.Name = "txtPeriod"
        Me.txtPeriod.Size = New System.Drawing.Size(100, 20)
        Me.txtPeriod.TabIndex = 42
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(18, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(73, 14)
        Me.Label10.TabIndex = 44
        Me.Label10.Text = "Counter Party"
        '
        'cbxCounterParty
        '
        Me.cbxCounterParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCounterParty.FormattingEnabled = True
        Me.cbxCounterParty.Location = New System.Drawing.Point(97, 55)
        Me.cbxCounterParty.Name = "cbxCounterParty"
        Me.cbxCounterParty.Size = New System.Drawing.Size(115, 23)
        Me.cbxCounterParty.TabIndex = 45
        '
        'FrmNewedgeTradeMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(579, 510)
        Me.Controls.Add(Me.cbxCounterParty)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtPeriod)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnChange)
        Me.Controls.Add(Me.txtClearing)
        Me.Controls.Add(Me.txtSell)
        Me.Controls.Add(Me.txtCommodity)
        Me.Controls.Add(Me.txtBuy)
        Me.Controls.Add(Me.txtLevy)
        Me.Controls.Add(Me.txtComm)
        Me.Controls.Add(Me.txtPrice)
        Me.Controls.Add(Me.txtMonthCode)
        Me.Controls.Add(Me.dtgTrade)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dpTradeDate)
        Me.Controls.Add(Me.Label7)
        Me.KeyPreview = True
        Me.Name = "FrmNewedgeTradeMain"
        Me.Text = "Futures Trade History"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.dpTradeDate, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.dtgTrade, 0)
        Me.Controls.SetChildIndex(Me.txtMonthCode, 0)
        Me.Controls.SetChildIndex(Me.txtPrice, 0)
        Me.Controls.SetChildIndex(Me.txtComm, 0)
        Me.Controls.SetChildIndex(Me.txtLevy, 0)
        Me.Controls.SetChildIndex(Me.txtBuy, 0)
        Me.Controls.SetChildIndex(Me.txtCommodity, 0)
        Me.Controls.SetChildIndex(Me.txtSell, 0)
        Me.Controls.SetChildIndex(Me.txtClearing, 0)
        Me.Controls.SetChildIndex(Me.btnChange, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtPeriod, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.cbxCounterParty, 0)
        CType(Me.dtgTrade, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtgTrade As System.Windows.Forms.DataGridView
    Friend WithEvents dpTradeDate As ESL.myDateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMonthCode As ESL.myTextbox
    Friend WithEvents txtPrice As ESL.myTextbox
    Friend WithEvents txtComm As ESL.myTextbox
    Friend WithEvents txtLevy As ESL.myTextbox
    Friend WithEvents txtBuy As ESL.myTextbox
    Friend WithEvents txtCommodity As ESL.myTextbox
    Friend WithEvents txtSell As ESL.myTextbox
    Friend WithEvents txtClearing As ESL.myTextbox
    Friend WithEvents btnChange As ESL.myButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtPeriod As ESL.myTextbox
    Friend WithEvents tid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents monthcode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents buy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sell As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents period As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clearing As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents levy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cbxCounterParty As System.Windows.Forms.ComboBox

End Class
