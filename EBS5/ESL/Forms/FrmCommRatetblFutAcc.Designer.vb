<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRatetblFutAcc
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmCommRatetblFutAcc))
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.lblTitle = New System.Windows.Forms.Label
        Me.txtSrcAe = New ESL.myTextbox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnBDelete = New ESL.myButton(Me.components)
        Me.btnBEdit = New ESL.myButton(Me.components)
        Me.btnBNew = New ESL.myButton(Me.components)
        Me.cbConsolidate = New ESL.myCheckBox(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtNRate = New ESL.myNumericBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.comboSrcMonth = New ESL.myComboBox(Me.components)
        Me.comboSrchProd = New ESL.myComboBox(Me.components)
        Me.txtRate = New ESL.myNumericBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSrcAcc = New ESL.myTextbox
        Me.comboProduct = New ESL.myComboBox(Me.components)
        Me.comboAE = New ESL.myComboBox(Me.components)
        Me.GroupTradeType = New System.Windows.Forms.GroupBox
        Me.rbNormal = New ESL.myRadioButton(Me.components)
        Me.rbInternet = New ESL.myRadioButton(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSrchNormal = New ESL.myRadioButton(Me.components)
        Me.rbSrchConsolidate = New ESL.myRadioButton(Me.components)
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.rbSrchInternet = New ESL.myRadioButton(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.comboSrcYr = New ESL.myComboBox(Me.components)
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.LabLot_range = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtgAE = New System.Windows.Forms.DataGridView
        Me.ac_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AENo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.AEName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgAC = New System.Windows.Forms.DataGridView
        Me.ACNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ACName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgRateTbl = New System.Windows.Forms.DataGridView
        Me.acc_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.product_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fut_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.trade_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acc_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acc_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lot_range = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rate_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.day_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.night_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rsid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lblAcc = New System.Windows.Forms.Label
        Me.txtMonth = New ESL.myTextbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAccName = New ESL.myTextbox
        Me.txtAEName = New ESL.myTextbox
        Me.txtTOFrom = New ESL.myAmountBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.comboAccNo = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbOptions = New ESL.myRadioButton(Me.components)
        Me.rbFutOpt = New ESL.myRadioButton(Me.components)
        Me.rbFutures = New ESL.myRadioButton(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbSrchFutALL = New ESL.myRadioButton(Me.components)
        Me.rbSrchOptions = New ESL.myRadioButton(Me.components)
        Me.rbSrchFutures = New ESL.myRadioButton(Me.components)
        Me.rbSrchFutOpt = New ESL.myRadioButton(Me.components)
        Me.GroupTradeType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgAC, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgRateTbl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Image = CType(resources.GetObject("btnCancel.Image"), System.Drawing.Image)
        Me.btnCancel.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnCancel.Location = New System.Drawing.Point(847, 471)
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.btnSave.Location = New System.Drawing.Point(797, 471)
        Me.btnSave.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Visible = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitle.Location = New System.Drawing.Point(257, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(377, 22)
        Me.lblTitle.TabIndex = 190
        Me.lblTitle.Text = "Futures Comm. Rate Table (by Account)"
        '
        'txtSrcAe
        '
        Me.txtSrcAe.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSrcAe.Location = New System.Drawing.Point(169, 57)
        Me.txtSrcAe.Name = "txtSrcAe"
        Me.txtSrcAe.Size = New System.Drawing.Size(67, 20)
        Me.txtSrcAe.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(127, 59)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(21, 14)
        Me.Label17.TabIndex = 407
        Me.Label17.Text = "AE"
        '
        'btnBDelete
        '
        Me.btnBDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBDelete.Location = New System.Drawing.Point(587, 471)
        Me.btnBDelete.Name = "btnBDelete"
        Me.btnBDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnBDelete.TabIndex = 18
        Me.btnBDelete.Text = "AE Batch Delete"
        Me.btnBDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBDelete.UseVisualStyleBackColor = True
        '
        'btnBEdit
        '
        Me.btnBEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBEdit.Location = New System.Drawing.Point(538, 471)
        Me.btnBEdit.Name = "btnBEdit"
        Me.btnBEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnBEdit.TabIndex = 17
        Me.btnBEdit.Text = "AE Batch Edit"
        Me.btnBEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBEdit.UseVisualStyleBackColor = True
        '
        'btnBNew
        '
        Me.btnBNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBNew.Location = New System.Drawing.Point(489, 471)
        Me.btnBNew.Name = "btnBNew"
        Me.btnBNew.Size = New System.Drawing.Size(50, 55)
        Me.btnBNew.TabIndex = 16
        Me.btnBNew.Text = "AE Batch New"
        Me.btnBNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBNew.UseVisualStyleBackColor = True
        '
        'cbConsolidate
        '
        Me.cbConsolidate.AutoSize = True
        Me.cbConsolidate.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.cbConsolidate.Location = New System.Drawing.Point(369, 433)
        Me.cbConsolidate.Name = "cbConsolidate"
        Me.cbConsolidate.Size = New System.Drawing.Size(82, 18)
        Me.cbConsolidate.TabIndex = 11
        Me.cbConsolidate.Text = "Consolidate"
        Me.cbConsolidate.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(436, 482)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 15)
        Me.Label9.TabIndex = 300
        Me.Label9.Text = "%"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(181, 482)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 15)
        Me.Label7.TabIndex = 299
        Me.Label7.Text = "%"
        '
        'txtNRate
        '
        Me.txtNRate.Location = New System.Drawing.Point(340, 479)
        Me.txtNRate.Name = "txtNRate"
        Me.txtNRate.Size = New System.Drawing.Size(90, 21)
        Me.txtNRate.TabIndex = 14
        Me.txtNRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(278, 483)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(56, 14)
        Me.Label15.TabIndex = 298
        Me.Label15.Text = "Night Rate"
        '
        'comboSrcMonth
        '
        Me.comboSrcMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrcMonth.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboSrcMonth.FormattingEnabled = True
        Me.comboSrcMonth.Location = New System.Drawing.Point(169, 30)
        Me.comboSrcMonth.Name = "comboSrcMonth"
        Me.comboSrcMonth.Size = New System.Drawing.Size(67, 22)
        Me.comboSrcMonth.TabIndex = 1
        '
        'comboSrchProd
        '
        Me.comboSrchProd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrchProd.FormattingEnabled = True
        Me.comboSrchProd.Location = New System.Drawing.Point(294, 55)
        Me.comboSrchProd.Name = "comboSrchProd"
        Me.comboSrchProd.Size = New System.Drawing.Size(146, 23)
        Me.comboSrchProd.TabIndex = 5
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(96, 479)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(79, 21)
        Me.txtRate.TabIndex = 13
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(245, 59)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 14)
        Me.Label10.TabIndex = 296
        Me.Label10.Text = "Product"
        '
        'txtSrcAcc
        '
        Me.txtSrcAcc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSrcAcc.Location = New System.Drawing.Point(50, 57)
        Me.txtSrcAcc.Name = "txtSrcAcc"
        Me.txtSrcAcc.Size = New System.Drawing.Size(73, 20)
        Me.txtSrcAcc.TabIndex = 3
        '
        'comboProduct
        '
        Me.comboProduct.Enabled = False
        Me.comboProduct.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboProduct.FormattingEnabled = True
        Me.comboProduct.Location = New System.Drawing.Point(96, 455)
        Me.comboProduct.Name = "comboProduct"
        Me.comboProduct.Size = New System.Drawing.Size(179, 22)
        Me.comboProduct.TabIndex = 12
        '
        'comboAE
        '
        Me.comboAE.Enabled = False
        Me.comboAE.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboAE.FormattingEnabled = True
        Me.comboAE.Location = New System.Drawing.Point(96, 406)
        Me.comboAE.Name = "comboAE"
        Me.comboAE.Size = New System.Drawing.Size(179, 22)
        Me.comboAE.TabIndex = 9
        '
        'GroupTradeType
        '
        Me.GroupTradeType.Controls.Add(Me.rbNormal)
        Me.GroupTradeType.Controls.Add(Me.rbInternet)
        Me.GroupTradeType.Location = New System.Drawing.Point(457, 423)
        Me.GroupTradeType.Name = "GroupTradeType"
        Me.GroupTradeType.Size = New System.Drawing.Size(141, 30)
        Me.GroupTradeType.TabIndex = 10
        Me.GroupTradeType.TabStop = False
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.rbNormal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNormal.Location = New System.Drawing.Point(6, 10)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(58, 18)
        Me.rbNormal.TabIndex = 0
        Me.rbNormal.Text = "Normal"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'rbInternet
        '
        Me.rbInternet.AutoSize = True
        Me.rbInternet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbInternet.Location = New System.Drawing.Point(67, 10)
        Me.rbInternet.Name = "rbInternet"
        Me.rbInternet.Size = New System.Drawing.Size(61, 18)
        Me.rbInternet.TabIndex = 1
        Me.rbInternet.Text = "Internet"
        Me.rbInternet.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(25, 434)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(62, 14)
        Me.Label14.TabIndex = 289
        Me.Label14.Text = "Trade Type"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSrchNormal)
        Me.GroupBox1.Controls.Add(Me.rbSrchConsolidate)
        Me.GroupBox1.Controls.Add(Me.rbSrchAll)
        Me.GroupBox1.Controls.Add(Me.rbSrchInternet)
        Me.GroupBox1.Location = New System.Drawing.Point(242, 22)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 30)
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
        'rbSrchConsolidate
        '
        Me.rbSrchConsolidate.AutoSize = True
        Me.rbSrchConsolidate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchConsolidate.Location = New System.Drawing.Point(137, 9)
        Me.rbSrchConsolidate.Name = "rbSrchConsolidate"
        Me.rbSrchConsolidate.Size = New System.Drawing.Size(81, 18)
        Me.rbSrchConsolidate.TabIndex = 2
        Me.rbSrchConsolidate.Text = "Consolidate"
        Me.rbSrchConsolidate.UseVisualStyleBackColor = True
        '
        'rbSrchAll
        '
        Me.rbSrchAll.AutoSize = True
        Me.rbSrchAll.Checked = True
        Me.rbSrchAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchAll.Location = New System.Drawing.Point(224, 9)
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(13, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(25, 14)
        Me.Label8.TabIndex = 273
        Me.Label8.Text = "A/C"
        '
        'comboSrcYr
        '
        Me.comboSrcYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrcYr.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboSrcYr.FormattingEnabled = True
        Me.comboSrcYr.Location = New System.Drawing.Point(50, 30)
        Me.comboSrcYr.Name = "comboSrcYr"
        Me.comboSrcYr.Size = New System.Drawing.Size(73, 22)
        Me.comboSrcYr.TabIndex = 0
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(13, 33)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 14)
        Me.Label19.TabIndex = 283
        Me.Label19.Text = "Year"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(127, 33)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 14)
        Me.Label6.TabIndex = 272
        Me.Label6.Text = "Month"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(810, 55)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 24)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'LabLot_range
        '
        Me.LabLot_range.AutoSize = True
        Me.LabLot_range.Location = New System.Drawing.Point(281, 507)
        Me.LabLot_range.Name = "LabLot_range"
        Me.LabLot_range.Size = New System.Drawing.Size(35, 15)
        Me.LabLot_range.TabIndex = 285
        Me.LabLot_range.Text = "<???"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtgAE)
        Me.Panel1.Controls.Add(Me.dtgAC)
        Me.Panel1.Controls.Add(Me.dtgRateTbl)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Panel1.Location = New System.Drawing.Point(12, 78)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(888, 305)
        Me.Panel1.TabIndex = 7
        '
        'dtgAE
        '
        Me.dtgAE.AllowUserToAddRows = False
        Me.dtgAE.AllowUserToDeleteRows = False
        Me.dtgAE.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgAE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ac_group, Me.AENo, Me.AEName})
        Me.dtgAE.Location = New System.Drawing.Point(3, 224)
        Me.dtgAE.MultiSelect = False
        Me.dtgAE.Name = "dtgAE"
        Me.dtgAE.ReadOnly = True
        Me.dtgAE.RowHeadersVisible = False
        Me.dtgAE.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgAE.RowTemplate.Height = 24
        Me.dtgAE.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgAE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAE.Size = New System.Drawing.Size(193, 75)
        Me.dtgAE.TabIndex = 1
        '
        'ac_group
        '
        Me.ac_group.DataPropertyName = "acc_group"
        Me.ac_group.HeaderText = "A/C group"
        Me.ac_group.Name = "ac_group"
        Me.ac_group.ReadOnly = True
        Me.ac_group.Visible = False
        Me.ac_group.Width = 80
        '
        'AENo
        '
        Me.AENo.DataPropertyName = "ae_no"
        Me.AENo.HeaderText = "A/E"
        Me.AENo.Name = "AENo"
        Me.AENo.ReadOnly = True
        Me.AENo.Width = 75
        '
        'AEName
        '
        Me.AEName.DataPropertyName = "ae_name"
        Me.AEName.HeaderText = "Name"
        Me.AEName.Name = "AEName"
        Me.AEName.ReadOnly = True
        Me.AEName.Width = 115
        '
        'dtgAC
        '
        Me.dtgAC.AllowUserToAddRows = False
        Me.dtgAC.AllowUserToDeleteRows = False
        Me.dtgAC.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgAC.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAC.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ACNo, Me.ACName})
        Me.dtgAC.Location = New System.Drawing.Point(3, 7)
        Me.dtgAC.MultiSelect = False
        Me.dtgAC.Name = "dtgAC"
        Me.dtgAC.ReadOnly = True
        Me.dtgAC.RowHeadersVisible = False
        Me.dtgAC.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgAC.RowTemplate.Height = 24
        Me.dtgAC.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgAC.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAC.Size = New System.Drawing.Size(193, 211)
        Me.dtgAC.TabIndex = 0
        '
        'ACNo
        '
        Me.ACNo.DataPropertyName = "acc_no"
        Me.ACNo.HeaderText = "A/C"
        Me.ACNo.Name = "ACNo"
        Me.ACNo.ReadOnly = True
        Me.ACNo.Width = 80
        '
        'ACName
        '
        Me.ACName.DataPropertyName = "acc_name"
        Me.ACName.HeaderText = "Name"
        Me.ACName.Name = "ACName"
        Me.ACName.ReadOnly = True
        '
        'dtgRateTbl
        '
        Me.dtgRateTbl.AllowUserToAddRows = False
        Me.dtgRateTbl.AllowUserToDeleteRows = False
        Me.dtgRateTbl.AllowUserToResizeRows = False
        Me.dtgRateTbl.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgRateTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRateTbl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.acc_group, Me.product_group, Me.fut_type, Me.trade_type, Me.ae_no, Me.ae_name, Me.acc_no, Me.acc_name_s, Me.man_group, Me.man_no, Me.misc_desc, Me.turnover_from, Me.lot_range, Me.rate_type, Me.day_rate, Me.night_rate, Me.comm_rate, Me.comm_month, Me.rsid})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.0!)
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRateTbl.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgRateTbl.Location = New System.Drawing.Point(202, 7)
        Me.dtgRateTbl.MultiSelect = False
        Me.dtgRateTbl.Name = "dtgRateTbl"
        Me.dtgRateTbl.ReadOnly = True
        Me.dtgRateTbl.RowHeadersVisible = False
        Me.dtgRateTbl.RowTemplate.Height = 24
        Me.dtgRateTbl.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRateTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgRateTbl.Size = New System.Drawing.Size(683, 292)
        Me.dtgRateTbl.TabIndex = 2
        '
        'acc_group
        '
        Me.acc_group.DataPropertyName = "acc_group"
        Me.acc_group.HeaderText = "A/C Group"
        Me.acc_group.Name = "acc_group"
        Me.acc_group.ReadOnly = True
        Me.acc_group.Visible = False
        '
        'product_group
        '
        Me.product_group.DataPropertyName = "product_group"
        Me.product_group.HeaderText = "Product Group"
        Me.product_group.Name = "product_group"
        Me.product_group.ReadOnly = True
        Me.product_group.Width = 120
        '
        'fut_type
        '
        Me.fut_type.DataPropertyName = "fut_type"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.fut_type.DefaultCellStyle = DataGridViewCellStyle1
        Me.fut_type.HeaderText = "Type"
        Me.fut_type.Name = "fut_type"
        Me.fut_type.ReadOnly = True
        Me.fut_type.Width = 120
        '
        'trade_type
        '
        Me.trade_type.DataPropertyName = "trade_type"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.trade_type.DefaultCellStyle = DataGridViewCellStyle2
        Me.trade_type.HeaderText = "Trade Type"
        Me.trade_type.Name = "trade_type"
        Me.trade_type.ReadOnly = True
        Me.trade_type.Width = 150
        '
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "A/E Code"
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        Me.ae_no.Visible = False
        Me.ae_no.Width = 80
        '
        'ae_name
        '
        Me.ae_name.DataPropertyName = "ae_name"
        Me.ae_name.HeaderText = "A/E Name"
        Me.ae_name.Name = "ae_name"
        Me.ae_name.ReadOnly = True
        Me.ae_name.Visible = False
        Me.ae_name.Width = 90
        '
        'acc_no
        '
        Me.acc_no.DataPropertyName = "acc_no"
        Me.acc_no.HeaderText = "Account No."
        Me.acc_no.Name = "acc_no"
        Me.acc_no.ReadOnly = True
        Me.acc_no.Visible = False
        '
        'acc_name_s
        '
        Me.acc_name_s.DataPropertyName = "acc_name_f"
        Me.acc_name_s.HeaderText = "Account Name"
        Me.acc_name_s.Name = "acc_name_s"
        Me.acc_name_s.ReadOnly = True
        Me.acc_name_s.Visible = False
        Me.acc_name_s.Width = 120
        '
        'man_group
        '
        Me.man_group.DataPropertyName = "man_group"
        Me.man_group.HeaderText = "Manager Group"
        Me.man_group.Name = "man_group"
        Me.man_group.ReadOnly = True
        Me.man_group.Visible = False
        '
        'man_no
        '
        Me.man_no.DataPropertyName = "man_no"
        Me.man_no.HeaderText = "Manager Number"
        Me.man_no.Name = "man_no"
        Me.man_no.ReadOnly = True
        Me.man_no.Visible = False
        '
        'misc_desc
        '
        Me.misc_desc.DataPropertyName = "comm_type"
        Me.misc_desc.HeaderText = "Commission Type"
        Me.misc_desc.Name = "misc_desc"
        Me.misc_desc.ReadOnly = True
        Me.misc_desc.Visible = False
        '
        'turnover_from
        '
        Me.turnover_from.DataPropertyName = "turnover_from"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.turnover_from.DefaultCellStyle = DataGridViewCellStyle3
        Me.turnover_from.HeaderText = "Lot"
        Me.turnover_from.Name = "turnover_from"
        Me.turnover_from.ReadOnly = True
        Me.turnover_from.Visible = False
        Me.turnover_from.Width = 120
        '
        'lot_range
        '
        Me.lot_range.DataPropertyName = "lot_range"
        Me.lot_range.HeaderText = "Lot Range"
        Me.lot_range.Name = "lot_range"
        Me.lot_range.ReadOnly = True
        Me.lot_range.Width = 150
        '
        'rate_type
        '
        Me.rate_type.DataPropertyName = "rate_type"
        Me.rate_type.HeaderText = "Rate Type"
        Me.rate_type.Name = "rate_type"
        Me.rate_type.ReadOnly = True
        Me.rate_type.Visible = False
        '
        'day_rate
        '
        Me.day_rate.DataPropertyName = "day_rate"
        Me.day_rate.HeaderText = "Day Rate (%)"
        Me.day_rate.Name = "day_rate"
        Me.day_rate.ReadOnly = True
        '
        'night_rate
        '
        Me.night_rate.DataPropertyName = "night_rate"
        Me.night_rate.HeaderText = "Night Rate (%)"
        Me.night_rate.Name = "night_rate"
        Me.night_rate.ReadOnly = True
        '
        'comm_rate
        '
        Me.comm_rate.DataPropertyName = "comm_rate"
        Me.comm_rate.HeaderText = "Commission Rate"
        Me.comm_rate.Name = "comm_rate"
        Me.comm_rate.ReadOnly = True
        Me.comm_rate.Visible = False
        '
        'comm_month
        '
        Me.comm_month.DataPropertyName = "comm_month"
        Me.comm_month.HeaderText = "Month"
        Me.comm_month.Name = "comm_month"
        Me.comm_month.ReadOnly = True
        Me.comm_month.Visible = False
        Me.comm_month.Width = 70
        '
        'rsid
        '
        Me.rsid.DataPropertyName = "rsid"
        Me.rsid.HeaderText = "rsid"
        Me.rsid.Name = "rsid"
        Me.rsid.ReadOnly = True
        Me.rsid.Visible = False
        '
        'lblAcc
        '
        Me.lblAcc.AutoSize = True
        Me.lblAcc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAcc.Location = New System.Drawing.Point(25, 386)
        Me.lblAcc.Name = "lblAcc"
        Me.lblAcc.Size = New System.Drawing.Size(48, 14)
        Me.lblAcc.TabIndex = 269
        Me.lblAcc.Text = "Account"
        '
        'txtMonth
        '
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtMonth.Location = New System.Drawing.Point(640, 383)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(108, 20)
        Me.txtMonth.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 503)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 14)
        Me.Label3.TabIndex = 270
        Me.Label3.Text = "Lot >="
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 483)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 14)
        Me.Label4.TabIndex = 271
        Me.Label4.Text = "Day Rate"
        '
        'txtAccName
        '
        Me.txtAccName.Enabled = False
        Me.txtAccName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccName.Location = New System.Drawing.Point(281, 383)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(267, 20)
        Me.txtAccName.TabIndex = 254
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtAEName.Location = New System.Drawing.Point(281, 407)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(267, 20)
        Me.txtAEName.TabIndex = 264
        '
        'txtTOFrom
        '
        Me.txtTOFrom.DecimalPoints = 2
        Me.txtTOFrom.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtTOFrom.Location = New System.Drawing.Point(96, 502)
        Me.txtTOFrom.Name = "txtTOFrom"
        Me.txtTOFrom.Size = New System.Drawing.Size(179, 20)
        Me.txtTOFrom.TabIndex = 15
        Me.txtTOFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(598, 386)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 14)
        Me.Label5.TabIndex = 275
        Me.Label5.Text = "Month"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(25, 410)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(21, 14)
        Me.Label11.TabIndex = 279
        Me.Label11.Text = "AE"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(741, 471)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 21
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'comboAccNo
        '
        Me.comboAccNo.Enabled = False
        Me.comboAccNo.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboAccNo.FormattingEnabled = True
        Me.comboAccNo.Location = New System.Drawing.Point(96, 382)
        Me.comboAccNo.Name = "comboAccNo"
        Me.comboAccNo.Size = New System.Drawing.Size(179, 22)
        Me.comboAccNo.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 458)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(44, 14)
        Me.Label2.TabIndex = 276
        Me.Label2.Text = "Product"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(692, 471)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 20
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(643, 471)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 19
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbOptions)
        Me.GroupBox2.Controls.Add(Me.rbFutOpt)
        Me.GroupBox2.Controls.Add(Me.rbFutures)
        Me.GroupBox2.Location = New System.Drawing.Point(96, 423)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(267, 30)
        Me.GroupBox2.TabIndex = 409
        Me.GroupBox2.TabStop = False
        '
        'rbOptions
        '
        Me.rbOptions.AutoSize = True
        Me.rbOptions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbOptions.Location = New System.Drawing.Point(198, 9)
        Me.rbOptions.Name = "rbOptions"
        Me.rbOptions.Size = New System.Drawing.Size(62, 18)
        Me.rbOptions.TabIndex = 2
        Me.rbOptions.Text = "Options"
        Me.rbOptions.UseVisualStyleBackColor = True
        '
        'rbFutOpt
        '
        Me.rbFutOpt.AutoSize = True
        Me.rbFutOpt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFutOpt.Location = New System.Drawing.Point(6, 9)
        Me.rbFutOpt.Name = "rbFutOpt"
        Me.rbFutOpt.Size = New System.Drawing.Size(123, 18)
        Me.rbFutOpt.TabIndex = 0
        Me.rbFutOpt.Text = "Futures and Options"
        Me.rbFutOpt.UseVisualStyleBackColor = True
        '
        'rbFutures
        '
        Me.rbFutures.AutoSize = True
        Me.rbFutures.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbFutures.Location = New System.Drawing.Point(130, 9)
        Me.rbFutures.Name = "rbFutures"
        Me.rbFutures.Size = New System.Drawing.Size(62, 18)
        Me.rbFutures.TabIndex = 1
        Me.rbFutures.Text = "Futures"
        Me.rbFutures.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbSrchFutALL)
        Me.GroupBox3.Controls.Add(Me.rbSrchOptions)
        Me.GroupBox3.Controls.Add(Me.rbSrchFutures)
        Me.GroupBox3.Controls.Add(Me.rbSrchFutOpt)
        Me.GroupBox3.Location = New System.Drawing.Point(515, 22)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(320, 30)
        Me.GroupBox3.TabIndex = 410
        Me.GroupBox3.TabStop = False
        '
        'rbSrchFutALL
        '
        Me.rbSrchFutALL.AutoSize = True
        Me.rbSrchFutALL.Checked = True
        Me.rbSrchFutALL.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchFutALL.Location = New System.Drawing.Point(271, 9)
        Me.rbSrchFutALL.Name = "rbSrchFutALL"
        Me.rbSrchFutALL.Size = New System.Drawing.Size(37, 18)
        Me.rbSrchFutALL.TabIndex = 4
        Me.rbSrchFutALL.TabStop = True
        Me.rbSrchFutALL.Text = "All"
        Me.rbSrchFutALL.UseVisualStyleBackColor = True
        '
        'rbSrchOptions
        '
        Me.rbSrchOptions.AutoSize = True
        Me.rbSrchOptions.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchOptions.Location = New System.Drawing.Point(203, 10)
        Me.rbSrchOptions.Name = "rbSrchOptions"
        Me.rbSrchOptions.Size = New System.Drawing.Size(62, 18)
        Me.rbSrchOptions.TabIndex = 2
        Me.rbSrchOptions.Text = "Options"
        Me.rbSrchOptions.UseVisualStyleBackColor = True
        '
        'rbSrchFutures
        '
        Me.rbSrchFutures.AutoSize = True
        Me.rbSrchFutures.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchFutures.Location = New System.Drawing.Point(135, 10)
        Me.rbSrchFutures.Name = "rbSrchFutures"
        Me.rbSrchFutures.Size = New System.Drawing.Size(62, 18)
        Me.rbSrchFutures.TabIndex = 1
        Me.rbSrchFutures.Text = "Futures"
        Me.rbSrchFutures.UseVisualStyleBackColor = True
        '
        'rbSrchFutOpt
        '
        Me.rbSrchFutOpt.AutoSize = True
        Me.rbSrchFutOpt.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchFutOpt.Location = New System.Drawing.Point(9, 9)
        Me.rbSrchFutOpt.Name = "rbSrchFutOpt"
        Me.rbSrchFutOpt.Size = New System.Drawing.Size(123, 18)
        Me.rbSrchFutOpt.TabIndex = 0
        Me.rbSrchFutOpt.Text = "Futures and Options"
        Me.rbSrchFutOpt.UseVisualStyleBackColor = True
        '
        'FrmCommRatetblFutAcc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(904, 542)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.txtAEName)
        Me.Controls.Add(Me.comboAE)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtSrcAe)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.btnBDelete)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.btnBEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnBNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.cbConsolidate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.comboAccNo)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.txtNRate)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.comboSrcMonth)
        Me.Controls.Add(Me.txtTOFrom)
        Me.Controls.Add(Me.comboSrchProd)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.txtAccName)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtSrcAcc)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.comboProduct)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.lblAcc)
        Me.Controls.Add(Me.GroupTradeType)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.LabLot_range)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.comboSrcYr)
        Me.KeyPreview = True
        Me.Name = "FrmCommRatetblFutAcc"
        Me.Text = "Futures Comm. Rate Table (by Account)"
        Me.Controls.SetChildIndex(Me.comboSrcYr, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.LabLot_range, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.GroupTradeType, 0)
        Me.Controls.SetChildIndex(Me.lblAcc, 0)
        Me.Controls.SetChildIndex(Me.txtMonth, 0)
        Me.Controls.SetChildIndex(Me.comboProduct, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtSrcAcc, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.txtAccName, 0)
        Me.Controls.SetChildIndex(Me.txtRate, 0)
        Me.Controls.SetChildIndex(Me.comboSrchProd, 0)
        Me.Controls.SetChildIndex(Me.txtTOFrom, 0)
        Me.Controls.SetChildIndex(Me.comboSrcMonth, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.txtNRate, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.comboAccNo, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cbConsolidate, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnBNew, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnBEdit, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.btnBDelete, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.txtSrcAe, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.comboAE, 0)
        Me.Controls.SetChildIndex(Me.txtAEName, 0)
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.GroupTradeType.ResumeLayout(False)
        Me.GroupTradeType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtgAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgAC, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgRateTbl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtRate As ESL.myNumericBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents comboSrchProd As ESL.myComboBox
    Friend WithEvents txtSrcAcc As ESL.myTextbox
    Friend WithEvents comboProduct As ESL.myComboBox
    Friend WithEvents comboAE As ESL.myComboBox
    Friend WithEvents GroupTradeType As System.Windows.Forms.GroupBox
    Friend WithEvents rbNormal As ESL.myRadioButton
    Friend WithEvents rbInternet As ESL.myRadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchNormal As ESL.myRadioButton
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents rbSrchInternet As ESL.myRadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents comboSrcYr As ESL.myComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents comboSrcMonth As ESL.myComboBox
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents LabLot_range As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtgAE As System.Windows.Forms.DataGridView
    Friend WithEvents dtgAC As System.Windows.Forms.DataGridView
    Friend WithEvents ACNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ACName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgRateTbl As System.Windows.Forms.DataGridView
    Friend WithEvents lblAcc As System.Windows.Forms.Label
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAccName As ESL.myTextbox
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents txtTOFrom As ESL.myAmountBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents comboAccNo As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents ac_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AENo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AEName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txtNRate As ESL.myNumericBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cbConsolidate As ESL.myCheckBox
    Friend WithEvents rbSrchConsolidate As ESL.myRadioButton
    Friend WithEvents btnBDelete As ESL.myButton
    Friend WithEvents btnBEdit As ESL.myButton
    Friend WithEvents btnBNew As ESL.myButton
    Friend WithEvents txtSrcAe As ESL.myTextbox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbOptions As ESL.myRadioButton
    Friend WithEvents rbFutOpt As ESL.myRadioButton
    Friend WithEvents rbFutures As ESL.myRadioButton
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchOptions As ESL.myRadioButton
    Friend WithEvents rbSrchFutures As ESL.myRadioButton
    Friend WithEvents rbSrchFutOpt As ESL.myRadioButton
    Friend WithEvents acc_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fut_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents trade_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lot_range As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rate_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents day_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents night_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbSrchFutALL As ESL.myRadioButton


End Class
