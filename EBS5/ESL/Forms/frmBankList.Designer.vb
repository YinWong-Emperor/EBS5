<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmBankList
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmBankList))
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.cmbSStock = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSBank = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dgvBank = New System.Windows.Forms.DataGridView()
        Me.d_bank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_bank_name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dgvStock = New System.Windows.Forms.DataGridView()
        Me.d_seq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_stock = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_ratio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtRatio = New ESL.myTextbox()
        Me.txtSeq = New ESL.myTextbox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cmbStock = New ESL.myComboBox(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtName = New ESL.myTextbox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtBank = New ESL.myTextbox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.btnReport = New ESL.myButton(Me.components)
        Me.PrintOption = New System.Windows.Forms.GroupBox()
        Me.rbtPrint = New ESL.myRadioButton(Me.components)
        Me.rbtPreview = New ESL.myRadioButton(Me.components)
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.btnFile = New ESL.myButton(Me.components)
        Me.txtFile = New ESL.myTextbox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.ambPre = New ESL.myAmountBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.btnSearch2 = New ESL.myButton(Me.components)
        Me.cmbSBank2 = New ESL.myComboBox(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cmbSStock2 = New ESL.myComboBox(Me.components)
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.dtpEnd2 = New ESL.myDateTimePicker()
        Me.dtpStart2 = New ESL.myDateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dgvRepledged = New System.Windows.Forms.DataGridView()
        Me.seq = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.stk_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.bank = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.qty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RValue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ratio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.repledgedDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mkt_value = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.ambSeq2 = New ESL.myAmountBox()
        Me.ambAva = New ESL.myAmountBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.ambTotal = New ESL.myAmountBox()
        Me.ambValue = New ESL.myAmountBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ambRatio = New ESL.myAmountBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.ambAmount = New ESL.myAmountBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.ambQty = New ESL.myAmountBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.cmbBank2 = New ESL.myComboBox(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.cmbStock2 = New ESL.myComboBox(Me.components)
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.radPrintDetail = New System.Windows.Forms.RadioButton()
        Me.radPrintSummary = New System.Windows.Forms.RadioButton()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.btnImport = New ESL.myButton(Me.components)
        Me.btnExport = New ESL.myButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvBank, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.PrintOption.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.dgvRepledged, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(598, 600)
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(545, 600)
        Me.btnSave.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.cmbSStock)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbSBank)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(626, 40)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Searching"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(545, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Inquiry"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbSStock
        '
        Me.cmbSStock.FormattingEnabled = True
        Me.cmbSStock.Location = New System.Drawing.Point(353, 13)
        Me.cmbSStock.Name = "cmbSStock"
        Me.cmbSStock.Size = New System.Drawing.Size(121, 23)
        Me.cmbSStock.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(240, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Stock"
        '
        'cmbSBank
        '
        Me.cmbSBank.FormattingEnabled = True
        Me.cmbSBank.Location = New System.Drawing.Point(102, 13)
        Me.cmbSBank.Name = "cmbSBank"
        Me.cmbSBank.Size = New System.Drawing.Size(121, 23)
        Me.cmbSBank.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bank"
        '
        'dgvBank
        '
        Me.dgvBank.AllowUserToAddRows = False
        Me.dgvBank.AllowUserToDeleteRows = False
        Me.dgvBank.AllowUserToResizeRows = False
        Me.dgvBank.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvBank.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvBank.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.d_bank, Me.d_bank_name})
        Me.dgvBank.GridColor = System.Drawing.Color.Linen
        Me.dgvBank.Location = New System.Drawing.Point(6, 20)
        Me.dgvBank.MultiSelect = False
        Me.dgvBank.Name = "dgvBank"
        Me.dgvBank.RowHeadersVisible = False
        Me.dgvBank.RowTemplate.Height = 24
        Me.dgvBank.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvBank.Size = New System.Drawing.Size(293, 293)
        Me.dgvBank.TabIndex = 7
        '
        'd_bank
        '
        Me.d_bank.DataPropertyName = "d_bank"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        Me.d_bank.DefaultCellStyle = DataGridViewCellStyle1
        Me.d_bank.HeaderText = "Bank"
        Me.d_bank.Name = "d_bank"
        Me.d_bank.ReadOnly = True
        Me.d_bank.Width = 120
        '
        'd_bank_name
        '
        Me.d_bank_name.DataPropertyName = "d_bank_name"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        Me.d_bank_name.DefaultCellStyle = DataGridViewCellStyle2
        Me.d_bank_name.HeaderText = "Bank Name"
        Me.d_bank_name.Name = "d_bank_name"
        Me.d_bank_name.ReadOnly = True
        Me.d_bank_name.Width = 150
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dgvStock)
        Me.GroupBox2.Controls.Add(Me.dgvBank)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 52)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(626, 319)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "List"
        '
        'dgvStock
        '
        Me.dgvStock.AllowUserToAddRows = False
        Me.dgvStock.AllowUserToDeleteRows = False
        Me.dgvStock.AllowUserToResizeRows = False
        Me.dgvStock.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvStock.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvStock.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.d_seq, Me.d_stock, Me.d_ratio})
        Me.dgvStock.GridColor = System.Drawing.Color.Linen
        Me.dgvStock.Location = New System.Drawing.Point(353, 20)
        Me.dgvStock.MultiSelect = False
        Me.dgvStock.Name = "dgvStock"
        Me.dgvStock.RowHeadersVisible = False
        Me.dgvStock.RowTemplate.Height = 24
        Me.dgvStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvStock.Size = New System.Drawing.Size(267, 293)
        Me.dgvStock.TabIndex = 8
        '
        'd_seq
        '
        Me.d_seq.DataPropertyName = "d_seq"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        Me.d_seq.DefaultCellStyle = DataGridViewCellStyle3
        Me.d_seq.HeaderText = "d_seq"
        Me.d_seq.Name = "d_seq"
        Me.d_seq.ReadOnly = True
        Me.d_seq.Visible = False
        '
        'd_stock
        '
        Me.d_stock.DataPropertyName = "d_stock"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        Me.d_stock.DefaultCellStyle = DataGridViewCellStyle4
        Me.d_stock.HeaderText = "Stock"
        Me.d_stock.Name = "d_stock"
        Me.d_stock.ReadOnly = True
        Me.d_stock.Width = 120
        '
        'd_ratio
        '
        Me.d_ratio.DataPropertyName = "d_ratio"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle5.NullValue = "N2"
        Me.d_ratio.DefaultCellStyle = DataGridViewCellStyle5
        Me.d_ratio.HeaderText = "Ratio"
        Me.d_ratio.Name = "d_ratio"
        Me.d_ratio.ReadOnly = True
        Me.d_ratio.Width = 120
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.txtRatio)
        Me.GroupBox3.Controls.Add(Me.txtSeq)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.cmbStock)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtName)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.txtBank)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 377)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(626, 94)
        Me.GroupBox3.TabIndex = 9
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detail"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(602, 66)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "%"
        '
        'txtRatio
        '
        Me.txtRatio.Enabled = False
        Me.txtRatio.Location = New System.Drawing.Point(462, 63)
        Me.txtRatio.Name = "txtRatio"
        Me.txtRatio.Size = New System.Drawing.Size(121, 21)
        Me.txtRatio.TabIndex = 9
        '
        'txtSeq
        '
        Me.txtSeq.Location = New System.Drawing.Point(462, 14)
        Me.txtSeq.Name = "txtSeq"
        Me.txtSeq.Size = New System.Drawing.Size(121, 21)
        Me.txtSeq.TabIndex = 8
        Me.txtSeq.Visible = False
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(299, 66)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Repledged Ratio"
        '
        'cmbStock
        '
        Me.cmbStock.Enabled = False
        Me.cmbStock.FormattingEnabled = True
        Me.cmbStock.Location = New System.Drawing.Point(102, 63)
        Me.cmbStock.Name = "cmbStock"
        Me.cmbStock.Size = New System.Drawing.Size(121, 23)
        Me.cmbStock.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 66)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Stock"
        '
        'txtName
        '
        Me.txtName.Enabled = False
        Me.txtName.Location = New System.Drawing.Point(102, 38)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(518, 21)
        Me.txtName.TabIndex = 3
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 41)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Bank Name"
        '
        'txtBank
        '
        Me.txtBank.Enabled = False
        Me.txtBank.Location = New System.Drawing.Point(102, 14)
        Me.txtBank.Name = "txtBank"
        Me.txtBank.Size = New System.Drawing.Size(121, 21)
        Me.txtBank.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 17)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Bank"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(492, 600)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 10
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(386, 600)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 8
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(439, 600)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 9
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(12, 578)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(636, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 58
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(9, 560)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 57
        Me.lblProcess.Text = "Processing"
        '
        'btnReport
        '
        Me.btnReport.Location = New System.Drawing.Point(227, 600)
        Me.btnReport.Name = "btnReport"
        Me.btnReport.Size = New System.Drawing.Size(50, 55)
        Me.btnReport.TabIndex = 56
        Me.btnReport.Text = "Print"
        Me.btnReport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnReport.UseVisualStyleBackColor = True
        '
        'PrintOption
        '
        Me.PrintOption.Controls.Add(Me.rbtPrint)
        Me.PrintOption.Controls.Add(Me.rbtPreview)
        Me.PrintOption.Location = New System.Drawing.Point(12, 600)
        Me.PrintOption.Name = "PrintOption"
        Me.PrintOption.Size = New System.Drawing.Size(209, 55)
        Me.PrintOption.TabIndex = 59
        Me.PrintOption.TabStop = False
        Me.PrintOption.Text = "Print option"
        '
        'rbtPrint
        '
        Me.rbtPrint.AutoSize = True
        Me.rbtPrint.Location = New System.Drawing.Point(142, 20)
        Me.rbtPrint.Name = "rbtPrint"
        Me.rbtPrint.Size = New System.Drawing.Size(49, 19)
        Me.rbtPrint.TabIndex = 1
        Me.rbtPrint.Text = "print"
        Me.rbtPrint.UseVisualStyleBackColor = True
        '
        'rbtPreview
        '
        Me.rbtPreview.AutoSize = True
        Me.rbtPreview.Checked = True
        Me.rbtPreview.Location = New System.Drawing.Point(10, 20)
        Me.rbtPreview.Name = "rbtPreview"
        Me.rbtPreview.Size = New System.Drawing.Size(67, 19)
        Me.rbtPreview.TabIndex = 0
        Me.rbtPreview.TabStop = True
        Me.rbtPreview.Text = "preview"
        Me.rbtPreview.UseVisualStyleBackColor = True
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(2, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(646, 555)
        Me.TabControl1.TabIndex = 60
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Linen
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(638, 527)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Re-pledge Stock Maintenance"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btnFile)
        Me.GroupBox6.Controls.Add(Me.txtFile)
        Me.GroupBox6.Controls.Add(Me.Label22)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 478)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(626, 43)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Import Data"
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(589, 13)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(31, 23)
        Me.btnFile.TabIndex = 12
        Me.btnFile.Text = "..."
        Me.btnFile.UseVisualStyleBackColor = True
        '
        'txtFile
        '
        Me.txtFile.BackColor = System.Drawing.Color.Linen
        Me.txtFile.Enabled = False
        Me.txtFile.Location = New System.Drawing.Point(102, 14)
        Me.txtFile.Name = "txtFile"
        Me.txtFile.Size = New System.Drawing.Size(481, 21)
        Me.txtFile.TabIndex = 11
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(7, 17)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(93, 15)
        Me.Label22.TabIndex = 10
        Me.Label22.Text = "Import File Path"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Linen
        Me.TabPage2.Controls.Add(Me.ambPre)
        Me.TabPage2.Controls.Add(Me.Label21)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Controls.Add(Me.GroupBox5)
        Me.TabPage2.Controls.Add(Me.dgvRepledged)
        Me.TabPage2.Controls.Add(Me.GroupBox4)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(638, 527)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Re-pledgable Stocks"
        '
        'ambPre
        '
        Me.ambPre.DecimalPoints = 2
        Me.ambPre.Location = New System.Drawing.Point(337, 503)
        Me.ambPre.Name = "ambPre"
        Me.ambPre.Size = New System.Drawing.Size(120, 21)
        Me.ambPre.TabIndex = 24
        Me.ambPre.Text = "140.00"
        Me.ambPre.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(463, 506)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(169, 15)
        Me.Label21.TabIndex = 23
        Me.Label21.Text = " % of aggregate margin loans"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(6, 506)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(313, 15)
        Me.Label20.TabIndex = 22
        Me.Label20.Text = "Alert if aggregate market value of the repledged stocks >"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.btnSearch2)
        Me.GroupBox5.Controls.Add(Me.cmbSBank2)
        Me.GroupBox5.Controls.Add(Me.Label11)
        Me.GroupBox5.Controls.Add(Me.cmbSStock2)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.dtpEnd2)
        Me.GroupBox5.Controls.Add(Me.dtpStart2)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Location = New System.Drawing.Point(4, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(630, 71)
        Me.GroupBox5.TabIndex = 10
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Search"
        '
        'btnSearch2
        '
        Me.btnSearch2.Location = New System.Drawing.Point(553, 42)
        Me.btnSearch2.Name = "btnSearch2"
        Me.btnSearch2.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch2.TabIndex = 8
        Me.btnSearch2.Text = "Inquiry"
        Me.btnSearch2.UseVisualStyleBackColor = True
        '
        'cmbSBank2
        '
        Me.cmbSBank2.FormattingEnabled = True
        Me.cmbSBank2.Location = New System.Drawing.Point(376, 42)
        Me.cmbSBank2.Name = "cmbSBank2"
        Me.cmbSBank2.Size = New System.Drawing.Size(120, 23)
        Me.cmbSBank2.TabIndex = 7
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(239, 46)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(99, 15)
        Me.Label11.TabIndex = 6
        Me.Label11.Text = "Repledged Bank"
        '
        'cmbSStock2
        '
        Me.cmbSStock2.FormattingEnabled = True
        Me.cmbSStock2.Location = New System.Drawing.Point(113, 42)
        Me.cmbSStock2.Name = "cmbSStock2"
        Me.cmbSStock2.Size = New System.Drawing.Size(120, 23)
        Me.cmbSStock2.TabIndex = 5
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 15)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "Repledged Stock"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(239, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(20, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "To"
        '
        'dtpEnd2
        '
        Me.dtpEnd2.CustomFormat = """yyyy/MM/dd"""
        Me.dtpEnd2.Location = New System.Drawing.Point(376, 15)
        Me.dtpEnd2.Name = "dtpEnd2"
        Me.dtpEnd2.Size = New System.Drawing.Size(120, 21)
        Me.dtpEnd2.TabIndex = 2
        '
        'dtpStart2
        '
        Me.dtpStart2.CustomFormat = """yyyy/MM/dd"""
        Me.dtpStart2.Location = New System.Drawing.Point(113, 15)
        Me.dtpStart2.Name = "dtpStart2"
        Me.dtpStart2.Size = New System.Drawing.Size(120, 21)
        Me.dtpStart2.TabIndex = 1
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(73, 15)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Date Range"
        '
        'dgvRepledged
        '
        Me.dgvRepledged.AllowUserToAddRows = False
        Me.dgvRepledged.AllowUserToDeleteRows = False
        Me.dgvRepledged.AllowUserToResizeRows = False
        Me.dgvRepledged.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvRepledged.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvRepledged.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRepledged.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.seq, Me.stk_code, Me.bank, Me.qty, Me.RValue, Me.ratio, Me.repledgedDate, Me.mkt_value})
        Me.dgvRepledged.GridColor = System.Drawing.Color.Linen
        Me.dgvRepledged.Location = New System.Drawing.Point(4, 84)
        Me.dgvRepledged.MultiSelect = False
        Me.dgvRepledged.Name = "dgvRepledged"
        Me.dgvRepledged.RowHeadersVisible = False
        Me.dgvRepledged.RowTemplate.Height = 24
        Me.dgvRepledged.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRepledged.Size = New System.Drawing.Size(628, 285)
        Me.dgvRepledged.TabIndex = 9
        '
        'seq
        '
        Me.seq.DataPropertyName = "d_seq"
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Linen
        Me.seq.DefaultCellStyle = DataGridViewCellStyle6
        Me.seq.HeaderText = "seq"
        Me.seq.Name = "seq"
        Me.seq.ReadOnly = True
        Me.seq.Visible = False
        '
        'stk_code
        '
        Me.stk_code.DataPropertyName = "stk_code"
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Linen
        Me.stk_code.DefaultCellStyle = DataGridViewCellStyle7
        Me.stk_code.HeaderText = "Stock"
        Me.stk_code.Name = "stk_code"
        Me.stk_code.ReadOnly = True
        Me.stk_code.Width = 80
        '
        'bank
        '
        Me.bank.DataPropertyName = "d_bank"
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Linen
        Me.bank.DefaultCellStyle = DataGridViewCellStyle8
        Me.bank.HeaderText = "Bank"
        Me.bank.Name = "bank"
        Me.bank.ReadOnly = True
        Me.bank.Width = 80
        '
        'qty
        '
        Me.qty.DataPropertyName = "qty"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle9.Format = "N0"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.qty.DefaultCellStyle = DataGridViewCellStyle9
        Me.qty.HeaderText = "Qty"
        Me.qty.Name = "qty"
        Me.qty.ReadOnly = True
        '
        'RValue
        '
        Me.RValue.DataPropertyName = "d_value"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle10.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle10.Format = "N2"
        DataGridViewCellStyle10.NullValue = Nothing
        Me.RValue.DefaultCellStyle = DataGridViewCellStyle10
        Me.RValue.HeaderText = "Repledged Value"
        Me.RValue.Name = "RValue"
        Me.RValue.ReadOnly = True
        Me.RValue.Width = 150
        '
        'ratio
        '
        Me.ratio.DataPropertyName = "d_ratio"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle11.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle11.NullValue = "N2"
        Me.ratio.DefaultCellStyle = DataGridViewCellStyle11
        Me.ratio.HeaderText = "Ratio"
        Me.ratio.Name = "ratio"
        Me.ratio.ReadOnly = True
        '
        'repledgedDate
        '
        Me.repledgedDate.DataPropertyName = "d_date"
        DataGridViewCellStyle12.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle12.Format = "d"
        DataGridViewCellStyle12.NullValue = Nothing
        Me.repledgedDate.DefaultCellStyle = DataGridViewCellStyle12
        Me.repledgedDate.HeaderText = "Date"
        Me.repledgedDate.Name = "repledgedDate"
        Me.repledgedDate.ReadOnly = True
        '
        'mkt_value
        '
        Me.mkt_value.DataPropertyName = "market_value"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle13.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle13.Format = "N2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.mkt_value.DefaultCellStyle = DataGridViewCellStyle13
        Me.mkt_value.HeaderText = "Market Value"
        Me.mkt_value.Name = "mkt_value"
        Me.mkt_value.ReadOnly = True
        Me.mkt_value.Visible = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ambSeq2)
        Me.GroupBox4.Controls.Add(Me.ambAva)
        Me.GroupBox4.Controls.Add(Me.Label19)
        Me.GroupBox4.Controls.Add(Me.Label18)
        Me.GroupBox4.Controls.Add(Me.ambTotal)
        Me.GroupBox4.Controls.Add(Me.ambValue)
        Me.GroupBox4.Controls.Add(Me.Label17)
        Me.GroupBox4.Controls.Add(Me.ambRatio)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.ambAmount)
        Me.GroupBox4.Controls.Add(Me.Label15)
        Me.GroupBox4.Controls.Add(Me.ambQty)
        Me.GroupBox4.Controls.Add(Me.Label14)
        Me.GroupBox4.Controls.Add(Me.cmbBank2)
        Me.GroupBox4.Controls.Add(Me.Label13)
        Me.GroupBox4.Controls.Add(Me.cmbStock2)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(4, 375)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(631, 128)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Select Repledge Stock"
        '
        'ambSeq2
        '
        Me.ambSeq2.BackColor = System.Drawing.Color.Linen
        Me.ambSeq2.DecimalPoints = 2
        Me.ambSeq2.Location = New System.Drawing.Point(240, 18)
        Me.ambSeq2.Name = "ambSeq2"
        Me.ambSeq2.ReadOnly = True
        Me.ambSeq2.Size = New System.Drawing.Size(10, 21)
        Me.ambSeq2.TabIndex = 21
        Me.ambSeq2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.ambSeq2.Visible = False
        '
        'ambAva
        '
        Me.ambAva.BackColor = System.Drawing.Color.Linen
        Me.ambAva.DecimalPoints = 2
        Me.ambAva.Location = New System.Drawing.Point(509, 47)
        Me.ambAva.Name = "ambAva"
        Me.ambAva.ReadOnly = True
        Me.ambAva.Size = New System.Drawing.Size(120, 21)
        Me.ambAva.TabIndex = 20
        Me.ambAva.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(373, 50)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(103, 15)
        Me.Label19.TabIndex = 19
        Me.Label19.Text = "Available Quantity"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(6, 77)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 15)
        Me.Label18.TabIndex = 18
        Me.Label18.Text = "Total Quantity"
        '
        'ambTotal
        '
        Me.ambTotal.BackColor = System.Drawing.Color.Linen
        Me.ambTotal.DecimalPoints = 2
        Me.ambTotal.Location = New System.Drawing.Point(114, 74)
        Me.ambTotal.Name = "ambTotal"
        Me.ambTotal.ReadOnly = True
        Me.ambTotal.Size = New System.Drawing.Size(120, 21)
        Me.ambTotal.TabIndex = 17
        Me.ambTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ambValue
        '
        Me.ambValue.BackColor = System.Drawing.Color.Linen
        Me.ambValue.DecimalPoints = 2
        Me.ambValue.Location = New System.Drawing.Point(509, 74)
        Me.ambValue.Name = "ambValue"
        Me.ambValue.ReadOnly = True
        Me.ambValue.Size = New System.Drawing.Size(120, 21)
        Me.ambValue.TabIndex = 16
        Me.ambValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(373, 77)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(105, 15)
        Me.Label17.TabIndex = 15
        Me.Label17.Text = "Total Market Value"
        '
        'ambRatio
        '
        Me.ambRatio.BackColor = System.Drawing.Color.Linen
        Me.ambRatio.DecimalPoints = 2
        Me.ambRatio.Location = New System.Drawing.Point(114, 101)
        Me.ambRatio.Name = "ambRatio"
        Me.ambRatio.ReadOnly = True
        Me.ambRatio.Size = New System.Drawing.Size(120, 21)
        Me.ambRatio.TabIndex = 14
        Me.ambRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(7, 104)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(36, 15)
        Me.Label16.TabIndex = 13
        Me.Label16.Text = "Ratio"
        '
        'ambAmount
        '
        Me.ambAmount.BackColor = System.Drawing.Color.Linen
        Me.ambAmount.DecimalPoints = 2
        Me.ambAmount.Location = New System.Drawing.Point(509, 100)
        Me.ambAmount.Name = "ambAmount"
        Me.ambAmount.ReadOnly = True
        Me.ambAmount.Size = New System.Drawing.Size(120, 21)
        Me.ambAmount.TabIndex = 12
        Me.ambAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(373, 104)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(68, 15)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Receivable"
        '
        'ambQty
        '
        Me.ambQty.DecimalPoints = 2
        Me.ambQty.Enabled = False
        Me.ambQty.Location = New System.Drawing.Point(114, 47)
        Me.ambQty.Name = "ambQty"
        Me.ambQty.Size = New System.Drawing.Size(120, 21)
        Me.ambQty.TabIndex = 10
        Me.ambQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(7, 50)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(51, 15)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Quantity"
        '
        'cmbBank2
        '
        Me.cmbBank2.Enabled = False
        Me.cmbBank2.FormattingEnabled = True
        Me.cmbBank2.Location = New System.Drawing.Point(509, 18)
        Me.cmbBank2.Name = "cmbBank2"
        Me.cmbBank2.Size = New System.Drawing.Size(120, 23)
        Me.cmbBank2.TabIndex = 8
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(373, 21)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(74, 15)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Repledge to"
        '
        'cmbStock2
        '
        Me.cmbStock2.Enabled = False
        Me.cmbStock2.FormattingEnabled = True
        Me.cmbStock2.Location = New System.Drawing.Point(114, 18)
        Me.cmbStock2.Name = "cmbStock2"
        Me.cmbStock2.Size = New System.Drawing.Size(120, 23)
        Me.cmbStock2.TabIndex = 6
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(7, 21)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(101, 15)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Repledged Stock"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Linen
        Me.TabPage3.Controls.Add(Me.radPrintDetail)
        Me.TabPage3.Controls.Add(Me.radPrintSummary)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(638, 527)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Print Report"
        '
        'radPrintDetail
        '
        Me.radPrintDetail.AutoSize = True
        Me.radPrintDetail.Location = New System.Drawing.Point(185, 216)
        Me.radPrintDetail.Name = "radPrintDetail"
        Me.radPrintDetail.Size = New System.Drawing.Size(191, 19)
        Me.radPrintDetail.TabIndex = 1
        Me.radPrintDetail.TabStop = True
        Me.radPrintDetail.Text = "Re-pledge Stock Detail Report"
        Me.radPrintDetail.UseVisualStyleBackColor = True
        '
        'radPrintSummary
        '
        Me.radPrintSummary.AutoSize = True
        Me.radPrintSummary.Location = New System.Drawing.Point(185, 180)
        Me.radPrintSummary.Name = "radPrintSummary"
        Me.radPrintSummary.Size = New System.Drawing.Size(212, 19)
        Me.radPrintSummary.TabIndex = 0
        Me.radPrintSummary.TabStop = True
        Me.radPrintSummary.Text = "Re-pledge Stock Summary Report"
        Me.radPrintSummary.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(280, 600)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(50, 55)
        Me.btnImport.TabIndex = 61
        Me.btnImport.Text = "Import"
        Me.btnImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(333, 600)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 62
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'frmBankList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(650, 659)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.PrintOption)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.btnReport)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.KeyPreview = True
        Me.Name = "frmBankList"
        Me.Text = "Bank List for Re-Pledgable Stocks"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnReport, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.PrintOption, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnImport, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvBank, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.dgvStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.PrintOption.ResumeLayout(False)
        Me.PrintOption.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.dgvRepledged, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSBank As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents cmbSStock As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dgvBank As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dgvStock As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtName As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtBank As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbStock As ESL.myComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents txtSeq As ESL.myTextbox
    Friend WithEvents txtRatio As ESL.myTextbox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents btnReport As ESL.myButton
    Friend WithEvents PrintOption As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPrint As ESL.myRadioButton
    Friend WithEvents rbtPreview As ESL.myRadioButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents d_seq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_stock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_ratio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvRepledged As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents d_bank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_bank_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dtpEnd2 As ESL.myDateTimePicker
    Friend WithEvents dtpStart2 As ESL.myDateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbSStock2 As ESL.myComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbSBank2 As ESL.myComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnSearch2 As ESL.myButton
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cmbStock2 As ESL.myComboBox
    Friend WithEvents cmbBank2 As ESL.myComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ambValue As ESL.myAmountBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ambRatio As ESL.myAmountBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents ambAmount As ESL.myAmountBox
    Friend WithEvents ambQty As ESL.myAmountBox
    Friend WithEvents ambTotal As ESL.myAmountBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents ambAva As ESL.myAmountBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ambSeq2 As ESL.myAmountBox
    Friend WithEvents seq As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents stk_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bank As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents qty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents RValue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ratio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents repledgedDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mkt_value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ambPre As ESL.myAmountBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents btnFile As ESL.myButton
    Friend WithEvents txtFile As ESL.myTextbox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents btnImport As ESL.myButton
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents radPrintDetail As System.Windows.Forms.RadioButton
    Friend WithEvents radPrintSummary As System.Windows.Forms.RadioButton

End Class
