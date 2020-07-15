<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRateTblOtherAE
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.comboSrcMonth = New ESL.myComboBox(Me.components)
        Me.txtRate = New ESL.myNumericBox
        Me.txtSrcAE = New ESL.myTextbox
        Me.comboAE = New ESL.myComboBox(Me.components)
        Me.GroupTradeType = New System.Windows.Forms.GroupBox
        Me.rbINC = New ESL.myRadioButton(Me.components)
        Me.rbBonus = New ESL.myRadioButton(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSrchINC = New ESL.myRadioButton(Me.components)
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.rbSrchBonus = New ESL.myRadioButton(Me.components)
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
        Me.dtgRateTbl = New System.Windows.Forms.DataGridView
        Me.comm_month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_net_brok = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_net_brok_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.brok_range = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rsid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txtMonth = New ESL.myTextbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtAEName = New ESL.myTextbox
        Me.txtTOFrom = New ESL.myAmountBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.lblTitle = New System.Windows.Forms.Label
        Me.cbSrchDefault = New ESL.myCheckBox(Me.components)
        Me.cbDefault = New ESL.myCheckBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupTradeType.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgRateTbl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(640, 393)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(589, 393)
        Me.btnSave.Visible = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(157, 407)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 15)
        Me.Label7.TabIndex = 335
        Me.Label7.Text = "%"
        '
        'comboSrcMonth
        '
        Me.comboSrcMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrcMonth.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboSrcMonth.FormattingEnabled = True
        Me.comboSrcMonth.Location = New System.Drawing.Point(142, 28)
        Me.comboSrcMonth.Name = "comboSrcMonth"
        Me.comboSrcMonth.Size = New System.Drawing.Size(56, 22)
        Me.comboSrcMonth.TabIndex = 302
        '
        'txtRate
        '
        Me.txtRate.Location = New System.Drawing.Point(72, 404)
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(79, 21)
        Me.txtRate.TabIndex = 314
        Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtSrcAE
        '
        Me.txtSrcAE.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSrcAE.Location = New System.Drawing.Point(425, 28)
        Me.txtSrcAE.Name = "txtSrcAE"
        Me.txtSrcAE.Size = New System.Drawing.Size(91, 20)
        Me.txtSrcAE.TabIndex = 304
        '
        'comboAE
        '
        Me.comboAE.Enabled = False
        Me.comboAE.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboAE.FormattingEnabled = True
        Me.comboAE.Location = New System.Drawing.Point(72, 354)
        Me.comboAE.Name = "comboAE"
        Me.comboAE.Size = New System.Drawing.Size(179, 22)
        Me.comboAE.TabIndex = 310
        '
        'GroupTradeType
        '
        Me.GroupTradeType.Controls.Add(Me.rbINC)
        Me.GroupTradeType.Controls.Add(Me.rbBonus)
        Me.GroupTradeType.Location = New System.Drawing.Point(72, 372)
        Me.GroupTradeType.Name = "GroupTradeType"
        Me.GroupTradeType.Size = New System.Drawing.Size(141, 30)
        Me.GroupTradeType.TabIndex = 311
        Me.GroupTradeType.TabStop = False
        '
        'rbINC
        '
        Me.rbINC.AutoSize = True
        Me.rbINC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbINC.Location = New System.Drawing.Point(6, 10)
        Me.rbINC.Name = "rbINC"
        Me.rbINC.Size = New System.Drawing.Size(68, 18)
        Me.rbINC.TabIndex = 0
        Me.rbINC.Text = "Incentive"
        Me.rbINC.UseVisualStyleBackColor = True
        '
        'rbBonus
        '
        Me.rbBonus.AutoSize = True
        Me.rbBonus.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBonus.Location = New System.Drawing.Point(82, 10)
        Me.rbBonus.Name = "rbBonus"
        Me.rbBonus.Size = New System.Drawing.Size(56, 18)
        Me.rbBonus.TabIndex = 1
        Me.rbBonus.Text = "Bonus"
        Me.rbBonus.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(1, 384)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(66, 14)
        Me.Label14.TabIndex = 332
        Me.Label14.Text = "Comm. Type"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSrchINC)
        Me.GroupBox1.Controls.Add(Me.rbSrchAll)
        Me.GroupBox1.Controls.Add(Me.rbSrchBonus)
        Me.GroupBox1.Location = New System.Drawing.Point(204, 20)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(185, 30)
        Me.GroupBox1.TabIndex = 303
        Me.GroupBox1.TabStop = False
        '
        'rbSrchINC
        '
        Me.rbSrchINC.AutoSize = True
        Me.rbSrchINC.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchINC.Location = New System.Drawing.Point(6, 10)
        Me.rbSrchINC.Name = "rbSrchINC"
        Me.rbSrchINC.Size = New System.Drawing.Size(68, 18)
        Me.rbSrchINC.TabIndex = 0
        Me.rbSrchINC.Text = "Incentive"
        Me.rbSrchINC.UseVisualStyleBackColor = True
        '
        'rbSrchAll
        '
        Me.rbSrchAll.AutoSize = True
        Me.rbSrchAll.Checked = True
        Me.rbSrchAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchAll.Location = New System.Drawing.Point(142, 10)
        Me.rbSrchAll.Name = "rbSrchAll"
        Me.rbSrchAll.Size = New System.Drawing.Size(37, 18)
        Me.rbSrchAll.TabIndex = 3
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(395, 31)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 14)
        Me.Label8.TabIndex = 326
        Me.Label8.Text = "A/E"
        '
        'comboSrcYr
        '
        Me.comboSrcYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrcYr.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboSrcYr.FormattingEnabled = True
        Me.comboSrcYr.Location = New System.Drawing.Point(38, 28)
        Me.comboSrcYr.Name = "comboSrcYr"
        Me.comboSrcYr.Size = New System.Drawing.Size(59, 22)
        Me.comboSrcYr.TabIndex = 301
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(1, 31)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 14)
        Me.Label19.TabIndex = 330
        Me.Label19.Text = "Year"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(103, 31)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 14)
        Me.Label6.TabIndex = 325
        Me.Label6.Text = "Month"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(603, 24)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 24)
        Me.btnSearch.TabIndex = 306
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'LabLot_range
        '
        Me.LabLot_range.AutoSize = True
        Me.LabLot_range.Location = New System.Drawing.Point(257, 429)
        Me.LabLot_range.Name = "LabLot_range"
        Me.LabLot_range.Size = New System.Drawing.Size(35, 15)
        Me.LabLot_range.TabIndex = 331
        Me.LabLot_range.Text = "<???"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtgAE)
        Me.Panel1.Controls.Add(Me.dtgRateTbl)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Panel1.Location = New System.Drawing.Point(1, 48)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(689, 305)
        Me.Panel1.TabIndex = 307
        '
        'dtgAE
        '
        Me.dtgAE.AllowUserToAddRows = False
        Me.dtgAE.AllowUserToDeleteRows = False
        Me.dtgAE.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgAE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ac_group, Me.AENo, Me.AEName})
        Me.dtgAE.Location = New System.Drawing.Point(3, 7)
        Me.dtgAE.MultiSelect = False
        Me.dtgAE.Name = "dtgAE"
        Me.dtgAE.ReadOnly = True
        Me.dtgAE.RowHeadersVisible = False
        Me.dtgAE.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgAE.RowTemplate.Height = 24
        Me.dtgAE.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgAE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAE.Size = New System.Drawing.Size(193, 292)
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
        'dtgRateTbl
        '
        Me.dtgRateTbl.AllowUserToAddRows = False
        Me.dtgRateTbl.AllowUserToDeleteRows = False
        Me.dtgRateTbl.AllowUserToResizeRows = False
        Me.dtgRateTbl.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgRateTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRateTbl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.comm_month, Me.ae_no, Me.comm_type, Me.comm_net_brok, Me.comm_net_brok_to, Me.brok_range, Me.comm_rate, Me.rsid})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.0!)
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRateTbl.DefaultCellStyle = DataGridViewCellStyle1
        Me.dtgRateTbl.Location = New System.Drawing.Point(202, 7)
        Me.dtgRateTbl.MultiSelect = False
        Me.dtgRateTbl.Name = "dtgRateTbl"
        Me.dtgRateTbl.ReadOnly = True
        Me.dtgRateTbl.RowHeadersVisible = False
        Me.dtgRateTbl.RowTemplate.Height = 24
        Me.dtgRateTbl.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRateTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgRateTbl.Size = New System.Drawing.Size(487, 292)
        Me.dtgRateTbl.TabIndex = 2
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
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "AE no"
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        Me.ae_no.Visible = False
        '
        'comm_type
        '
        Me.comm_type.DataPropertyName = "misc_desc"
        Me.comm_type.HeaderText = "Comm. Type"
        Me.comm_type.Name = "comm_type"
        Me.comm_type.ReadOnly = True
        '
        'comm_net_brok
        '
        Me.comm_net_brok.DataPropertyName = "comm_net_brok"
        Me.comm_net_brok.HeaderText = "comm_net_brok"
        Me.comm_net_brok.Name = "comm_net_brok"
        Me.comm_net_brok.ReadOnly = True
        Me.comm_net_brok.Visible = False
        Me.comm_net_brok.Width = 120
        '
        'comm_net_brok_to
        '
        Me.comm_net_brok_to.DataPropertyName = "comm_net_brok_to"
        Me.comm_net_brok_to.HeaderText = "net_brok_to"
        Me.comm_net_brok_to.Name = "comm_net_brok_to"
        Me.comm_net_brok_to.ReadOnly = True
        Me.comm_net_brok_to.Visible = False
        '
        'brok_range
        '
        Me.brok_range.DataPropertyName = "brok_range"
        Me.brok_range.HeaderText = "Range"
        Me.brok_range.Name = "brok_range"
        Me.brok_range.ReadOnly = True
        Me.brok_range.Width = 200
        '
        'comm_rate
        '
        Me.comm_rate.DataPropertyName = "comm_rate"
        Me.comm_rate.HeaderText = "Comm. Rate"
        Me.comm_rate.Name = "comm_rate"
        Me.comm_rate.ReadOnly = True
        '
        'rsid
        '
        Me.rsid.DataPropertyName = "rsid"
        Me.rsid.HeaderText = "Rsid"
        Me.rsid.Name = "rsid"
        Me.rsid.ReadOnly = True
        Me.rsid.Visible = False
        '
        'txtMonth
        '
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtMonth.Location = New System.Drawing.Point(572, 354)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(108, 20)
        Me.txtMonth.TabIndex = 308
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1, 428)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 14)
        Me.Label3.TabIndex = 323
        Me.Label3.Text = "Range >="
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1, 408)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 14)
        Me.Label4.TabIndex = 324
        Me.Label4.Text = "Comm. Rate"
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtAEName.Location = New System.Drawing.Point(257, 355)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(267, 20)
        Me.txtAEName.TabIndex = 321
        '
        'txtTOFrom
        '
        Me.txtTOFrom.DecimalPoints = 2
        Me.txtTOFrom.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.txtTOFrom.Location = New System.Drawing.Point(72, 427)
        Me.txtTOFrom.Name = "txtTOFrom"
        Me.txtTOFrom.Size = New System.Drawing.Size(179, 20)
        Me.txtTOFrom.TabIndex = 316
        Me.txtTOFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(530, 358)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 14)
        Me.Label5.TabIndex = 327
        Me.Label5.Text = "Month"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label11.Location = New System.Drawing.Point(1, 358)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(24, 14)
        Me.Label11.TabIndex = 329
        Me.Label11.Text = "A/E"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(533, 393)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 319
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(482, 393)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 318
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(431, 393)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 317
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(210, 3)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(286, 22)
        Me.lblTitle.TabIndex = 337
        Me.lblTitle.Text = "Commission Rate Table Other"
        '
        'cbSrchDefault
        '
        Me.cbSrchDefault.AutoSize = True
        Me.cbSrchDefault.Location = New System.Drawing.Point(532, 30)
        Me.cbSrchDefault.Name = "cbSrchDefault"
        Me.cbSrchDefault.Size = New System.Drawing.Size(65, 19)
        Me.cbSrchDefault.TabIndex = 338
        Me.cbSrchDefault.Text = "Default"
        Me.cbSrchDefault.UseVisualStyleBackColor = True
        '
        'cbDefault
        '
        Me.cbDefault.AutoSize = True
        Me.cbDefault.Location = New System.Drawing.Point(219, 382)
        Me.cbDefault.Name = "cbDefault"
        Me.cbDefault.Size = New System.Drawing.Size(65, 19)
        Me.cbDefault.TabIndex = 339
        Me.cbDefault.Text = "Default"
        Me.cbDefault.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(181, 408)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(174, 14)
        Me.Label1.TabIndex = 349
        Me.Label1.Text = "(co. comm = comm rate * turnover)"
        '
        'FrmCommRateTblOtherAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(697, 454)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.cbDefault)
        Me.Controls.Add(Me.cbSrchDefault)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.comboSrcMonth)
        Me.Controls.Add(Me.txtRate)
        Me.Controls.Add(Me.txtSrcAE)
        Me.Controls.Add(Me.comboAE)
        Me.Controls.Add(Me.GroupTradeType)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.comboSrcYr)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.LabLot_range)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAEName)
        Me.Controls.Add(Me.txtTOFrom)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.KeyPreview = True
        Me.Name = "FrmCommRateTblOtherAE"
        Me.Text = "Commission Rate Table Other"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtTOFrom, 0)
        Me.Controls.SetChildIndex(Me.txtAEName, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.txtMonth, 0)
        Me.Controls.SetChildIndex(Me.LabLot_range, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.Label19, 0)
        Me.Controls.SetChildIndex(Me.comboSrcYr, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.GroupTradeType, 0)
        Me.Controls.SetChildIndex(Me.comboAE, 0)
        Me.Controls.SetChildIndex(Me.txtSrcAE, 0)
        Me.Controls.SetChildIndex(Me.txtRate, 0)
        Me.Controls.SetChildIndex(Me.comboSrcMonth, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cbSrchDefault, 0)
        Me.Controls.SetChildIndex(Me.cbDefault, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.GroupTradeType.ResumeLayout(False)
        Me.GroupTradeType.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtgAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgRateTbl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents comboSrcMonth As ESL.myComboBox
    Friend WithEvents txtRate As ESL.myNumericBox
    Friend WithEvents txtSrcAE As ESL.myTextbox
    Friend WithEvents comboAE As ESL.myComboBox
    Friend WithEvents GroupTradeType As System.Windows.Forms.GroupBox
    Friend WithEvents rbINC As ESL.myRadioButton
    Friend WithEvents rbBonus As ESL.myRadioButton
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchINC As ESL.myRadioButton
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents rbSrchBonus As ESL.myRadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents comboSrcYr As ESL.myComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents LabLot_range As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents dtgAE As System.Windows.Forms.DataGridView
    Friend WithEvents ac_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AENo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AEName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dtgRateTbl As System.Windows.Forms.DataGridView
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents txtTOFrom As ESL.myAmountBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents cbSrchDefault As ESL.myCheckBox
    Friend WithEvents cbDefault As ESL.myCheckBox
    Friend WithEvents comm_month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_net_brok As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_net_brok_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents brok_range As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rsid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
