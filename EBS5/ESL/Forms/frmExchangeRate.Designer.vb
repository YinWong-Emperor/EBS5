<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmExchangeRate
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmExchangeRate))
        Me.dgvExchangeRate = New System.Windows.Forms.DataGridView()
        Me.exid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.currency = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.lupdtdate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblCurrency = New System.Windows.Forms.Label()
        Me.nudRate = New ESL.myNumericUpDown(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpTradeDate = New ESL.myDateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbType = New ESL.myComboBox(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.dgvExchangeRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.nudRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(488, 409)
        Me.btnCancel.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(432, 408)
        Me.btnSave.TabIndex = 6
        Me.btnSave.Visible = True
        '
        'dgvExchangeRate
        '
        Me.dgvExchangeRate.AllowUserToAddRows = False
        Me.dgvExchangeRate.AllowUserToDeleteRows = False
        Me.dgvExchangeRate.AllowUserToResizeRows = False
        Me.dgvExchangeRate.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvExchangeRate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.exid, Me.tdate, Me.type, Me.currency, Me.rate, Me.lupdtdate})
        Me.dgvExchangeRate.Location = New System.Drawing.Point(5, 57)
        Me.dgvExchangeRate.MultiSelect = False
        Me.dgvExchangeRate.Name = "dgvExchangeRate"
        Me.dgvExchangeRate.ReadOnly = True
        Me.dgvExchangeRate.RowHeadersVisible = False
        Me.dgvExchangeRate.RowTemplate.Height = 24
        Me.dgvExchangeRate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvExchangeRate.Size = New System.Drawing.Size(533, 300)
        Me.dgvExchangeRate.TabIndex = 3
        '
        'exid
        '
        Me.exid.DataPropertyName = "exid"
        DataGridViewCellStyle1.Format = "N0"
        Me.exid.DefaultCellStyle = DataGridViewCellStyle1
        Me.exid.Frozen = True
        Me.exid.HeaderText = "exid"
        Me.exid.Name = "exid"
        Me.exid.ReadOnly = True
        Me.exid.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.exid.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.exid.Visible = False
        Me.exid.Width = 35
        '
        'tdate
        '
        Me.tdate.DataPropertyName = "tdate"
        DataGridViewCellStyle2.Format = "dd/MM/yyyy"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.tdate.DefaultCellStyle = DataGridViewCellStyle2
        Me.tdate.Frozen = True
        Me.tdate.HeaderText = "Trade Date"
        Me.tdate.Name = "tdate"
        Me.tdate.ReadOnly = True
        Me.tdate.Width = 110
        '
        'type
        '
        Me.type.DataPropertyName = "type"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.type.DefaultCellStyle = DataGridViewCellStyle3
        Me.type.Frozen = True
        Me.type.HeaderText = "Type"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        Me.type.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'currency
        '
        Me.currency.DataPropertyName = "currency"
        Me.currency.Frozen = True
        Me.currency.HeaderText = "Currency"
        Me.currency.Name = "currency"
        Me.currency.ReadOnly = True
        Me.currency.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.currency.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.currency.Width = 72
        '
        'rate
        '
        Me.rate.DataPropertyName = "rate"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N4"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.rate.DefaultCellStyle = DataGridViewCellStyle4
        Me.rate.Frozen = True
        Me.rate.HeaderText = "Rate"
        Me.rate.Name = "rate"
        Me.rate.ReadOnly = True
        Me.rate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.rate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'lupdtdate
        '
        Me.lupdtdate.DataPropertyName = "lupdtdate"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.Format = "dd/MM/yyyy HH:mm"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.lupdtdate.DefaultCellStyle = DataGridViewCellStyle5
        Me.lupdtdate.Frozen = True
        Me.lupdtdate.HeaderText = "Last Update Date"
        Me.lupdtdate.Name = "lupdtdate"
        Me.lupdtdate.ReadOnly = True
        Me.lupdtdate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lupdtdate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.lupdtdate.Width = 129
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(376, 408)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 5
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblCurrency)
        Me.GroupBox1.Controls.Add(Me.nudRate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 357)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(533, 45)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details"
        '
        'lblCurrency
        '
        Me.lblCurrency.AutoSize = True
        Me.lblCurrency.Location = New System.Drawing.Point(323, 19)
        Me.lblCurrency.Name = "lblCurrency"
        Me.lblCurrency.Size = New System.Drawing.Size(56, 15)
        Me.lblCurrency.TabIndex = 19
        Me.lblCurrency.Text = "1 USD to"
        '
        'nudRate
        '
        Me.nudRate.DecimalPlaces = 4
        Me.nudRate.Location = New System.Drawing.Point(385, 16)
        Me.nudRate.Maximum = New Decimal(New Integer() {-727379969, 232, 0, 262144})
        Me.nudRate.Name = "nudRate"
        Me.nudRate.Size = New System.Drawing.Size(103, 21)
        Me.nudRate.TabIndex = 4
        Me.nudRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudRate.ThousandsSeparator = True
        Me.nudRate.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(494, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "HKD"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpTradeDate)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cmbType)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(533, 51)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search"
        '
        'dtpTradeDate
        '
        Me.dtpTradeDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpTradeDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTradeDate.Location = New System.Drawing.Point(282, 20)
        Me.dtpTradeDate.Name = "dtpTradeDate"
        Me.dtpTradeDate.Size = New System.Drawing.Size(120, 21)
        Me.dtpTradeDate.TabIndex = 1
        Me.dtpTradeDate.Value = New Date(2009, 8, 25, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(208, 23)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Trade Date"
        '
        'cmbType
        '
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Items.AddRange(New Object() {"", "Futures", "Securities"})
        Me.cmbType.Location = New System.Drawing.Point(62, 19)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(120, 23)
        Me.cmbType.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(418, 19)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(97, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Enquiry"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(23, 23)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Type"
        '
        'frmExchangeRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(543, 469)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.dgvExchangeRate)
        Me.KeyPreview = True
        Me.Name = "frmExchangeRate"
        Me.Text = "Exchange Rate"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.dgvExchangeRate, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.dgvExchangeRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.nudRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvExchangeRate As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents cmbType As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtpTradeDate As ESL.myDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents nudRate As myNumericUpDown
    Friend WithEvents lblCurrency As System.Windows.Forms.Label
    Friend WithEvents exid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents tdate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents currency As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lupdtdate As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
