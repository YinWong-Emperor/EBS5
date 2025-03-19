<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRateTblAgp
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
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.comboAENo = New ESL.myComboBox(Me.components)
        Me.comboAccNo = New ESL.myComboBox(Me.components)
        Me.lblAEGroup = New System.Windows.Forms.Label
        Me.lblAENo = New System.Windows.Forms.Label
        Me.txtAEGroup = New ESL.myTextbox
        Me.txtMonth = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtTOFrom = New ESL.myAmountBox
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.comboMonth = New ESL.myComboBox(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtAccName = New ESL.myTextbox
        Me.lblTOTo = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.txtSrcAcc = New ESL.myTextbox
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbGetInternet = New ESL.myRadioButton(Me.components)
        Me.rbGetAll = New ESL.myRadioButton(Me.components)
        Me.rbGetNormal = New ESL.myRadioButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.rbNormal = New ESL.myRadioButton(Me.components)
        Me.rbInternet = New ESL.myRadioButton(Me.components)
        Me.txtCommRate = New ESL.myTextbox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtgRateTbl = New System.Windows.Forms.DataGridView
        Me.srid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acc_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acc_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TurnOver = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgRateTbl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(662, 540)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(610, 540)
        '
        'comboAENo
        '
        Me.comboAENo.FormattingEnabled = True
        Me.comboAENo.Location = New System.Drawing.Point(339, 431)
        Me.comboAENo.Name = "comboAENo"
        Me.comboAENo.Size = New System.Drawing.Size(133, 23)
        Me.comboAENo.TabIndex = 86
        Me.comboAENo.Visible = False
        '
        'comboAccNo
        '
        Me.comboAccNo.Enabled = False
        Me.comboAccNo.FormattingEnabled = True
        Me.comboAccNo.Location = New System.Drawing.Point(95, 350)
        Me.comboAccNo.Name = "comboAccNo"
        Me.comboAccNo.Size = New System.Drawing.Size(134, 23)
        Me.comboAccNo.TabIndex = 85
        '
        'lblAEGroup
        '
        Me.lblAEGroup.AutoSize = True
        Me.lblAEGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAEGroup.Location = New System.Drawing.Point(21, 435)
        Me.lblAEGroup.Name = "lblAEGroup"
        Me.lblAEGroup.Size = New System.Drawing.Size(54, 14)
        Me.lblAEGroup.TabIndex = 84
        Me.lblAEGroup.Text = "AE Group"
        Me.lblAEGroup.Visible = False
        '
        'lblAENo
        '
        Me.lblAENo.AutoSize = True
        Me.lblAENo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAENo.Location = New System.Drawing.Point(255, 435)
        Me.lblAENo.Name = "lblAENo"
        Me.lblAENo.Size = New System.Drawing.Size(40, 14)
        Me.lblAENo.TabIndex = 83
        Me.lblAENo.Text = "AE No."
        Me.lblAENo.Visible = False
        '
        'txtAEGroup
        '
        Me.txtAEGroup.Enabled = False
        Me.txtAEGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAEGroup.Location = New System.Drawing.Point(95, 432)
        Me.txtAEGroup.Name = "txtAEGroup"
        Me.txtAEGroup.Size = New System.Drawing.Size(134, 20)
        Me.txtAEGroup.TabIndex = 82
        Me.txtAEGroup.Visible = False
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(95, 379)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(134, 20)
        Me.txtMonth.TabIndex = 81
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(21, 382)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 14)
        Me.Label5.TabIndex = 80
        Me.Label5.Text = "Month"
        '
        'txtTOFrom
        '
        Me.txtTOFrom.DecimalPoints = 2
        Me.txtTOFrom.Enabled = False
        Me.txtTOFrom.Location = New System.Drawing.Point(339, 404)
        Me.txtTOFrom.Name = "txtTOFrom"
        Me.txtTOFrom.Size = New System.Drawing.Size(133, 21)
        Me.txtTOFrom.TabIndex = 78
        Me.txtTOFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(603, 105)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(97, 24)
        Me.btnSearch.TabIndex = 63
        Me.btnSearch.Text = "Enquiry"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'comboMonth
        '
        Me.comboMonth.FormattingEnabled = True
        Me.comboMonth.Location = New System.Drawing.Point(258, 107)
        Me.comboMonth.Name = "comboMonth"
        Me.comboMonth.Size = New System.Drawing.Size(92, 23)
        Me.comboMonth.TabIndex = 79
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(255, 353)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 14)
        Me.Label9.TabIndex = 77
        Me.Label9.Text = "Account Name"
        '
        'txtAccName
        '
        Me.txtAccName.Enabled = False
        Me.txtAccName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAccName.Location = New System.Drawing.Point(339, 351)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(190, 20)
        Me.txtAccName.TabIndex = 65
        '
        'lblTOTo
        '
        Me.lblTOTo.AutoSize = True
        Me.lblTOTo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTOTo.Location = New System.Drawing.Point(479, 408)
        Me.lblTOTo.Name = "lblTOTo"
        Me.lblTOTo.Size = New System.Drawing.Size(40, 14)
        Me.lblTOTo.TabIndex = 75
        Me.lblTOTo.Text = "< ????"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(176, 25)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(416, 22)
        Me.lblTitle.TabIndex = 74
        Me.lblTitle.Text = "Securities Commission Rate Table(Account)"
        '
        'txtSrcAcc
        '
        Me.txtSrcAcc.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSrcAcc.Location = New System.Drawing.Point(429, 108)
        Me.txtSrcAcc.Name = "txtSrcAcc"
        Me.txtSrcAcc.Size = New System.Drawing.Size(168, 20)
        Me.txtSrcAcc.TabIndex = 62
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(356, 111)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 14)
        Me.Label8.TabIndex = 76
        Me.Label8.Text = "Account No."
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbGetInternet)
        Me.GroupBox1.Controls.Add(Me.rbGetAll)
        Me.GroupBox1.Controls.Add(Me.rbGetNormal)
        Me.GroupBox1.Location = New System.Drawing.Point(24, 97)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(186, 35)
        Me.GroupBox1.TabIndex = 61
        Me.GroupBox1.TabStop = False
        '
        'rbGetInternet
        '
        Me.rbGetInternet.AutoSize = True
        Me.rbGetInternet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGetInternet.Location = New System.Drawing.Point(72, 12)
        Me.rbGetInternet.Name = "rbGetInternet"
        Me.rbGetInternet.Size = New System.Drawing.Size(61, 18)
        Me.rbGetInternet.TabIndex = 1
        Me.rbGetInternet.Text = "Internet"
        Me.rbGetInternet.UseVisualStyleBackColor = True
        '
        'rbGetAll
        '
        Me.rbGetAll.AutoSize = True
        Me.rbGetAll.Checked = True
        Me.rbGetAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGetAll.Location = New System.Drawing.Point(139, 12)
        Me.rbGetAll.Name = "rbGetAll"
        Me.rbGetAll.Size = New System.Drawing.Size(37, 18)
        Me.rbGetAll.TabIndex = 2
        Me.rbGetAll.TabStop = True
        Me.rbGetAll.Text = "All"
        Me.rbGetAll.UseVisualStyleBackColor = True
        '
        'rbGetNormal
        '
        Me.rbGetNormal.AutoSize = True
        Me.rbGetNormal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbGetNormal.Location = New System.Drawing.Point(8, 12)
        Me.rbGetNormal.Name = "rbGetNormal"
        Me.rbGetNormal.Size = New System.Drawing.Size(58, 18)
        Me.rbGetNormal.TabIndex = 0
        Me.rbGetNormal.Text = "Normal"
        Me.rbGetNormal.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(216, 111)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 14)
        Me.Label6.TabIndex = 73
        Me.Label6.Text = "Month"
        '
        'rbNormal
        '
        Me.rbNormal.AutoSize = True
        Me.rbNormal.Checked = True
        Me.rbNormal.Enabled = False
        Me.rbNormal.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbNormal.Location = New System.Drawing.Point(95, 406)
        Me.rbNormal.Name = "rbNormal"
        Me.rbNormal.Size = New System.Drawing.Size(58, 18)
        Me.rbNormal.TabIndex = 72
        Me.rbNormal.TabStop = True
        Me.rbNormal.Text = "Normal"
        Me.rbNormal.UseVisualStyleBackColor = True
        '
        'rbInternet
        '
        Me.rbInternet.AutoSize = True
        Me.rbInternet.Enabled = False
        Me.rbInternet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbInternet.Location = New System.Drawing.Point(159, 406)
        Me.rbInternet.Name = "rbInternet"
        Me.rbInternet.Size = New System.Drawing.Size(61, 18)
        Me.rbInternet.TabIndex = 71
        Me.rbInternet.Text = "Internet"
        Me.rbInternet.UseVisualStyleBackColor = True
        '
        'txtCommRate
        '
        Me.txtCommRate.Enabled = False
        Me.txtCommRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCommRate.Location = New System.Drawing.Point(339, 379)
        Me.txtCommRate.Name = "txtCommRate"
        Me.txtCommRate.Size = New System.Drawing.Size(190, 20)
        Me.txtCommRate.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(255, 382)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 14)
        Me.Label4.TabIndex = 70
        Me.Label4.Text = "Comm. rate"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(255, 408)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 14)
        Me.Label3.TabIndex = 69
        Me.Label3.Text = "Turnover >="
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(21, 408)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(62, 14)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Trade Type"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(21, 354)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 14)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "Account No."
        '
        'dtgRateTbl
        '
        Me.dtgRateTbl.AllowUserToAddRows = False
        Me.dtgRateTbl.AllowUserToDeleteRows = False
        Me.dtgRateTbl.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgRateTbl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgRateTbl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.srid, Me.acc_no, Me.acc_name_s, Me.comm_month, Me.misc_desc, Me.comm_rate, Me.turnover_from, Me.turnover_to, Me.TurnOver})
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle16.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgRateTbl.DefaultCellStyle = DataGridViewCellStyle16
        Me.dtgRateTbl.Location = New System.Drawing.Point(24, 136)
        Me.dtgRateTbl.Name = "dtgRateTbl"
        Me.dtgRateTbl.ReadOnly = True
        Me.dtgRateTbl.RowHeadersVisible = False
        Me.dtgRateTbl.RowTemplate.Height = 24
        Me.dtgRateTbl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgRateTbl.Size = New System.Drawing.Size(676, 208)
        Me.dtgRateTbl.TabIndex = 64
        '
        'srid
        '
        Me.srid.DataPropertyName = "srid"
        Me.srid.HeaderText = "srid"
        Me.srid.Name = "srid"
        Me.srid.ReadOnly = True
        '
        'acc_no
        '
        Me.acc_no.DataPropertyName = "acc_no"
        Me.acc_no.HeaderText = "Account No."
        Me.acc_no.Name = "acc_no"
        Me.acc_no.ReadOnly = True
        Me.acc_no.Width = 80
        '
        'acc_name_s
        '
        Me.acc_name_s.DataPropertyName = "acc_name_s"
        Me.acc_name_s.HeaderText = "Account Name"
        Me.acc_name_s.Name = "acc_name_s"
        Me.acc_name_s.ReadOnly = True
        '
        'comm_month
        '
        Me.comm_month.DataPropertyName = "comm_month"
        Me.comm_month.HeaderText = "Month"
        Me.comm_month.Name = "comm_month"
        Me.comm_month.ReadOnly = True
        Me.comm_month.Width = 65
        '
        'misc_desc
        '
        Me.misc_desc.DataPropertyName = "misc_desc"
        Me.misc_desc.HeaderText = "Trade Type"
        Me.misc_desc.Name = "misc_desc"
        Me.misc_desc.ReadOnly = True
        '
        'comm_rate
        '
        Me.comm_rate.DataPropertyName = "comm_rate"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.comm_rate.DefaultCellStyle = DataGridViewCellStyle13
        Me.comm_rate.HeaderText = "Comm. Rate(%)"
        Me.comm_rate.Name = "comm_rate"
        Me.comm_rate.ReadOnly = True
        Me.comm_rate.Width = 60
        '
        'turnover_from
        '
        Me.turnover_from.DataPropertyName = "turnover_from"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle14.Format = "N2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.turnover_from.DefaultCellStyle = DataGridViewCellStyle14
        Me.turnover_from.HeaderText = "Turnover >="
        Me.turnover_from.Name = "turnover_from"
        Me.turnover_from.ReadOnly = True
        Me.turnover_from.Visible = False
        Me.turnover_from.Width = 110
        '
        'turnover_to
        '
        Me.turnover_to.DataPropertyName = "turnover_to"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle15.Format = "N2"
        DataGridViewCellStyle15.NullValue = Nothing
        Me.turnover_to.DefaultCellStyle = DataGridViewCellStyle15
        Me.turnover_to.HeaderText = "Turnover <"
        Me.turnover_to.Name = "turnover_to"
        Me.turnover_to.ReadOnly = True
        Me.turnover_to.Visible = False
        Me.turnover_to.Width = 110
        '
        'TurnOver
        '
        Me.TurnOver.DataPropertyName = "TurnOver"
        Me.TurnOver.HeaderText = "TurnOver"
        Me.TurnOver.Name = "TurnOver"
        Me.TurnOver.ReadOnly = True
        Me.TurnOver.Width = 250
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(530, 540)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 89
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(418, 540)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 87
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(474, 540)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 88
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'FrmCommRateTblAgp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(771, 633)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.comboAENo)
        Me.Controls.Add(Me.comboAccNo)
        Me.Controls.Add(Me.lblAEGroup)
        Me.Controls.Add(Me.lblAENo)
        Me.Controls.Add(Me.txtAEGroup)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtTOFrom)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.comboMonth)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtAccName)
        Me.Controls.Add(Me.lblTOTo)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtSrcAcc)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.rbNormal)
        Me.Controls.Add(Me.rbInternet)
        Me.Controls.Add(Me.txtCommRate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dtgRateTbl)
        Me.KeyPreview = True
        Me.Name = "FrmCommRateTblAgp"
        Me.Text = "frmBase          User:      Trade Date: 01/01/0001"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.dtgRateTbl, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.txtCommRate, 0)
        Me.Controls.SetChildIndex(Me.rbInternet, 0)
        Me.Controls.SetChildIndex(Me.rbNormal, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.txtSrcAcc, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.lblTOTo, 0)
        Me.Controls.SetChildIndex(Me.txtAccName, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.comboMonth, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.txtTOFrom, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtMonth, 0)
        Me.Controls.SetChildIndex(Me.txtAEGroup, 0)
        Me.Controls.SetChildIndex(Me.lblAENo, 0)
        Me.Controls.SetChildIndex(Me.lblAEGroup, 0)
        Me.Controls.SetChildIndex(Me.comboAccNo, 0)
        Me.Controls.SetChildIndex(Me.comboAENo, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgRateTbl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comboAENo As ESL.myComboBox
    Friend WithEvents comboAccNo As ESL.myComboBox
    Friend WithEvents lblAEGroup As System.Windows.Forms.Label
    Friend WithEvents lblAENo As System.Windows.Forms.Label
    Friend WithEvents txtAEGroup As ESL.myTextbox
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtTOFrom As ESL.myAmountBox
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents comboMonth As ESL.myComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtAccName As ESL.myTextbox
    Friend WithEvents lblTOTo As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents txtSrcAcc As ESL.myTextbox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbGetInternet As ESL.myRadioButton
    Friend WithEvents rbGetAll As ESL.myRadioButton
    Friend WithEvents rbGetNormal As ESL.myRadioButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents rbNormal As ESL.myRadioButton
    Friend WithEvents rbInternet As ESL.myRadioButton
    Friend WithEvents txtCommRate As ESL.myTextbox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtgRateTbl As System.Windows.Forms.DataGridView
    Friend WithEvents srid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TurnOver As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton

End Class
