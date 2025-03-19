<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRateTblSMan
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.lblTurnover = New System.Windows.Forms.Label
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtSrchMan = New ESL.myTextbox
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.lblCommRate = New System.Windows.Forms.Label
        Me.cboSearchYear = New ESL.myComboBox(Me.components)
        Me.cboSearchMonth = New ESL.myComboBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.fontPanel = New System.Windows.Forms.Panel
        Me.dgvManList = New System.Windows.Forms.DataGridView
        Me.man_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvRateList = New System.Windows.Forms.DataGridView
        Me.srid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_month = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Brokerage_rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.nbCommRate = New ESL.myNumericBox
        Me.abTurnover = New ESL.myAmountBox
        Me.txtMonth = New ESL.myTextbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtManName = New ESL.myTextbox
        Me.cboManNo = New ESL.myComboBox(Me.components)
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBoxSrchRateType = New System.Windows.Forms.GroupBox
        Me.rbSrchRebate = New ESL.myRadioButton(Me.components)
        Me.rbSrchTurn = New ESL.myRadioButton(Me.components)
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.rbSrchBrok = New ESL.myRadioButton(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBoxRateType = New System.Windows.Forms.GroupBox
        Me.rbRebate = New ESL.myRadioButton(Me.components)
        Me.rbTurnover = New ESL.myRadioButton(Me.components)
        Me.rbBrokerage = New ESL.myRadioButton(Me.components)
        Me.fontPanel.SuspendLayout()
        CType(Me.dgvManList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSrchRateType.SuspendLayout()
        Me.GroupBoxRateType.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(635, 404)
        Me.btnCancel.TabIndex = 17
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(585, 404)
        Me.btnSave.TabIndex = 16
        Me.btnSave.Visible = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(3, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 159
        Me.Label3.Text = "Year"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(529, 404)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 15
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(478, 404)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 14
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(427, 404)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 13
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'lblTurnover
        '
        Me.lblTurnover.AutoSize = True
        Me.lblTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTurnover.Location = New System.Drawing.Point(204, 421)
        Me.lblTurnover.Name = "lblTurnover"
        Me.lblTurnover.Size = New System.Drawing.Size(106, 14)
        Me.lblTurnover.TabIndex = 155
        Me.lblTurnover.Text = "< ??,???,???,???.??"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(157, 4)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(403, 22)
        Me.lblTitle.TabIndex = 144
        Me.lblTitle.Text = "Securities Comm. Rate Table (by Manager)"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(538, 373)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(36, 14)
        Me.Label10.TabIndex = 153
        Me.Label10.Text = "Month"
        '
        'txtSrchMan
        '
        Me.txtSrchMan.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.txtSrchMan.Location = New System.Drawing.Point(501, 28)
        Me.txtSrchMan.Name = "txtSrchMan"
        Me.txtSrchMan.Size = New System.Drawing.Size(86, 21)
        Me.txtSrchMan.TabIndex = 3
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(593, 26)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(92, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblCommRate
        '
        Me.lblCommRate.AutoSize = True
        Me.lblCommRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCommRate.Location = New System.Drawing.Point(7, 442)
        Me.lblCommRate.Name = "lblCommRate"
        Me.lblCommRate.Size = New System.Drawing.Size(64, 14)
        Me.lblCommRate.TabIndex = 151
        Me.lblCommRate.Text = "Comm. Rate"
        '
        'cboSearchYear
        '
        Me.cboSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchYear.FormattingEnabled = True
        Me.cboSearchYear.Location = New System.Drawing.Point(40, 31)
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(54, 19)
        Me.cboSearchYear.TabIndex = 1
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchMonth.FormattingEnabled = True
        Me.cboSearchMonth.Location = New System.Drawing.Point(136, 31)
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(39, 19)
        Me.cboSearchMonth.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(100, 32)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 147
        Me.Label4.Text = "Month"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(454, 31)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(49, 14)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "Manager"
        '
        'fontPanel
        '
        Me.fontPanel.Controls.Add(Me.dgvManList)
        Me.fontPanel.Controls.Add(Me.dgvRateList)
        Me.fontPanel.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.fontPanel.Location = New System.Drawing.Point(6, 52)
        Me.fontPanel.Name = "fontPanel"
        Me.fontPanel.Size = New System.Drawing.Size(681, 316)
        Me.fontPanel.TabIndex = 6
        '
        'dgvManList
        '
        Me.dgvManList.AllowUserToAddRows = False
        Me.dgvManList.AllowUserToDeleteRows = False
        Me.dgvManList.AllowUserToResizeRows = False
        Me.dgvManList.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvManList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvManList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.man_group, Me.man_no, Me.man_name})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvManList.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvManList.Location = New System.Drawing.Point(0, 3)
        Me.dgvManList.MultiSelect = False
        Me.dgvManList.Name = "dgvManList"
        Me.dgvManList.ReadOnly = True
        Me.dgvManList.RowHeadersVisible = False
        Me.dgvManList.RowTemplate.Height = 24
        Me.dgvManList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvManList.Size = New System.Drawing.Size(194, 309)
        Me.dgvManList.TabIndex = 0
        '
        'man_group
        '
        Me.man_group.DataPropertyName = "man_group"
        Me.man_group.HeaderText = "Man. Group"
        Me.man_group.Name = "man_group"
        Me.man_group.ReadOnly = True
        Me.man_group.Visible = False
        Me.man_group.Width = 85
        '
        'man_no
        '
        Me.man_no.DataPropertyName = "man_no"
        Me.man_no.HeaderText = "Man. No"
        Me.man_no.Name = "man_no"
        Me.man_no.ReadOnly = True
        Me.man_no.Width = 75
        '
        'man_name
        '
        Me.man_name.DataPropertyName = "man_name"
        Me.man_name.HeaderText = "Man. Name"
        Me.man_name.Name = "man_name"
        Me.man_name.ReadOnly = True
        '
        'dgvRateList
        '
        Me.dgvRateList.AllowUserToAddRows = False
        Me.dgvRateList.AllowUserToDeleteRows = False
        Me.dgvRateList.AllowUserToResizeRows = False
        Me.dgvRateList.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRateList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle7
        Me.dgvRateList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRateList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.srid, Me.comm_month, Me.misc_desc, Me.turnover_from, Me.turnover_to, Me.turnover, Me.comm_rate, Me.Brokerage_rate})
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle9.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRateList.DefaultCellStyle = DataGridViewCellStyle9
        Me.dgvRateList.Location = New System.Drawing.Point(200, 3)
        Me.dgvRateList.MultiSelect = False
        Me.dgvRateList.Name = "dgvRateList"
        Me.dgvRateList.ReadOnly = True
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvRateList.RowHeadersDefaultCellStyle = DataGridViewCellStyle10
        Me.dgvRateList.RowHeadersVisible = False
        Me.dgvRateList.RowTemplate.Height = 24
        Me.dgvRateList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRateList.Size = New System.Drawing.Size(479, 310)
        Me.dgvRateList.TabIndex = 1
        '
        'srid
        '
        Me.srid.DataPropertyName = "srid"
        Me.srid.HeaderText = "srid"
        Me.srid.Name = "srid"
        Me.srid.ReadOnly = True
        Me.srid.Visible = False
        '
        'comm_month
        '
        Me.comm_month.DataPropertyName = "comm_month"
        Me.comm_month.HeaderText = "Month"
        Me.comm_month.Name = "comm_month"
        Me.comm_month.ReadOnly = True
        Me.comm_month.Width = 52
        '
        'misc_desc
        '
        Me.misc_desc.DataPropertyName = "misc_desc"
        Me.misc_desc.HeaderText = "Rate Type"
        Me.misc_desc.Name = "misc_desc"
        Me.misc_desc.ReadOnly = True
        Me.misc_desc.Width = 81
        '
        'turnover_from
        '
        Me.turnover_from.DataPropertyName = "turnover_from"
        Me.turnover_from.HeaderText = "Turnover Min."
        Me.turnover_from.Name = "turnover_from"
        Me.turnover_from.ReadOnly = True
        Me.turnover_from.Visible = False
        '
        'turnover_to
        '
        Me.turnover_to.DataPropertyName = "turnover_to"
        Me.turnover_to.HeaderText = "turnover_to"
        Me.turnover_to.Name = "turnover_to"
        Me.turnover_to.ReadOnly = True
        Me.turnover_to.Visible = False
        '
        'turnover
        '
        Me.turnover.DataPropertyName = "turnover"
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.turnover.DefaultCellStyle = DataGridViewCellStyle8
        Me.turnover.HeaderText = "Turnover Range"
        Me.turnover.Name = "turnover"
        Me.turnover.ReadOnly = True
        Me.turnover.Width = 228
        '
        'comm_rate
        '
        Me.comm_rate.DataPropertyName = "comm_rate"
        Me.comm_rate.HeaderText = "Comm. Rate (%)"
        Me.comm_rate.Name = "comm_rate"
        Me.comm_rate.ReadOnly = True
        Me.comm_rate.Width = 90
        '
        'Brokerage_rate
        '
        Me.Brokerage_rate.DataPropertyName = "Brokerage_rate"
        Me.Brokerage_rate.HeaderText = "Brok. Rate (%)"
        Me.Brokerage_rate.Name = "Brokerage_rate"
        Me.Brokerage_rate.ReadOnly = True
        Me.Brokerage_rate.Visible = False
        Me.Brokerage_rate.Width = 90
        '
        'nbCommRate
        '
        Me.nbCommRate.Enabled = False
        Me.nbCommRate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.nbCommRate.Location = New System.Drawing.Point(80, 439)
        Me.nbCommRate.Name = "nbCommRate"
        Me.nbCommRate.Size = New System.Drawing.Size(57, 20)
        Me.nbCommRate.TabIndex = 11
        Me.nbCommRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'abTurnover
        '
        Me.abTurnover.DecimalPoints = 2
        Me.abTurnover.Enabled = False
        Me.abTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.abTurnover.Location = New System.Drawing.Point(80, 418)
        Me.abTurnover.Name = "abTurnover"
        Me.abTurnover.Size = New System.Drawing.Size(119, 20)
        Me.abTurnover.TabIndex = 10
        Me.abTurnover.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(580, 370)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(105, 20)
        Me.txtMonth.TabIndex = 148
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(7, 421)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 14)
        Me.Label1.TabIndex = 143
        Me.Label1.Text = "Turnover >="
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(7, 373)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(49, 14)
        Me.Label9.TabIndex = 163
        Me.Label9.Text = "Manager"
        '
        'txtManName
        '
        Me.txtManName.Enabled = False
        Me.txtManName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtManName.Location = New System.Drawing.Point(207, 370)
        Me.txtManName.Name = "txtManName"
        Me.txtManName.Size = New System.Drawing.Size(325, 20)
        Me.txtManName.TabIndex = 6
        '
        'cboManNo
        '
        Me.cboManNo.FormattingEnabled = True
        Me.cboManNo.Location = New System.Drawing.Point(80, 369)
        Me.cboManNo.Name = "cboManNo"
        Me.cboManNo.Size = New System.Drawing.Size(121, 23)
        Me.cboManNo.TabIndex = 7
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(7, 398)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 14)
        Me.Label8.TabIndex = 302
        Me.Label8.Text = "Rate Type"
        '
        'GroupBoxSrchRateType
        '
        Me.GroupBoxSrchRateType.Controls.Add(Me.rbSrchRebate)
        Me.GroupBoxSrchRateType.Controls.Add(Me.rbSrchTurn)
        Me.GroupBoxSrchRateType.Controls.Add(Me.rbSrchAll)
        Me.GroupBoxSrchRateType.Controls.Add(Me.rbSrchBrok)
        Me.GroupBoxSrchRateType.Location = New System.Drawing.Point(181, 20)
        Me.GroupBoxSrchRateType.Name = "GroupBoxSrchRateType"
        Me.GroupBoxSrchRateType.Size = New System.Drawing.Size(267, 30)
        Me.GroupBoxSrchRateType.TabIndex = 2
        Me.GroupBoxSrchRateType.TabStop = False
        '
        'rbSrchRebate
        '
        Me.rbSrchRebate.AutoSize = True
        Me.rbSrchRebate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchRebate.Location = New System.Drawing.Point(162, 10)
        Me.rbSrchRebate.Name = "rbSrchRebate"
        Me.rbSrchRebate.Size = New System.Drawing.Size(59, 18)
        Me.rbSrchRebate.TabIndex = 3
        Me.rbSrchRebate.Text = "Rebate"
        Me.rbSrchRebate.UseVisualStyleBackColor = True
        '
        'rbSrchTurn
        '
        Me.rbSrchTurn.AutoSize = True
        Me.rbSrchTurn.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchTurn.Location = New System.Drawing.Point(6, 10)
        Me.rbSrchTurn.Name = "rbSrchTurn"
        Me.rbSrchTurn.Size = New System.Drawing.Size(69, 18)
        Me.rbSrchTurn.TabIndex = 0
        Me.rbSrchTurn.Text = "Turnover"
        Me.rbSrchTurn.UseVisualStyleBackColor = True
        '
        'rbSrchAll
        '
        Me.rbSrchAll.AutoSize = True
        Me.rbSrchAll.Checked = True
        Me.rbSrchAll.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchAll.Location = New System.Drawing.Point(227, 10)
        Me.rbSrchAll.Name = "rbSrchAll"
        Me.rbSrchAll.Size = New System.Drawing.Size(37, 18)
        Me.rbSrchAll.TabIndex = 2
        Me.rbSrchAll.TabStop = True
        Me.rbSrchAll.Text = "All"
        Me.rbSrchAll.UseVisualStyleBackColor = True
        '
        'rbSrchBrok
        '
        Me.rbSrchBrok.AutoSize = True
        Me.rbSrchBrok.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchBrok.Location = New System.Drawing.Point(81, 10)
        Me.rbSrchBrok.Name = "rbSrchBrok"
        Me.rbSrchBrok.Size = New System.Drawing.Size(75, 18)
        Me.rbSrchBrok.TabIndex = 1
        Me.rbSrchBrok.Text = "Brokerage"
        Me.rbSrchBrok.UseVisualStyleBackColor = True
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(143, 441)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(187, 14)
        Me.Label14.TabIndex = 299
        Me.Label14.Text = "% (co. comm = comm rate * turnover)"
        '
        'GroupBoxRateType
        '
        Me.GroupBoxRateType.Controls.Add(Me.rbRebate)
        Me.GroupBoxRateType.Controls.Add(Me.rbTurnover)
        Me.GroupBoxRateType.Controls.Add(Me.rbBrokerage)
        Me.GroupBoxRateType.Location = New System.Drawing.Point(80, 386)
        Me.GroupBoxRateType.Name = "GroupBoxRateType"
        Me.GroupBoxRateType.Size = New System.Drawing.Size(230, 30)
        Me.GroupBoxRateType.TabIndex = 8
        Me.GroupBoxRateType.TabStop = False
        '
        'rbRebate
        '
        Me.rbRebate.AutoSize = True
        Me.rbRebate.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbRebate.Location = New System.Drawing.Point(162, 10)
        Me.rbRebate.Name = "rbRebate"
        Me.rbRebate.Size = New System.Drawing.Size(59, 18)
        Me.rbRebate.TabIndex = 2
        Me.rbRebate.Text = "Rebate"
        Me.rbRebate.UseVisualStyleBackColor = True
        '
        'rbTurnover
        '
        Me.rbTurnover.AutoSize = True
        Me.rbTurnover.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbTurnover.Location = New System.Drawing.Point(6, 10)
        Me.rbTurnover.Name = "rbTurnover"
        Me.rbTurnover.Size = New System.Drawing.Size(69, 18)
        Me.rbTurnover.TabIndex = 0
        Me.rbTurnover.Text = "Turnover"
        Me.rbTurnover.UseVisualStyleBackColor = True
        '
        'rbBrokerage
        '
        Me.rbBrokerage.AutoSize = True
        Me.rbBrokerage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBrokerage.Location = New System.Drawing.Point(81, 10)
        Me.rbBrokerage.Name = "rbBrokerage"
        Me.rbBrokerage.Size = New System.Drawing.Size(75, 18)
        Me.rbBrokerage.TabIndex = 1
        Me.rbBrokerage.Text = "Brokerage"
        Me.rbBrokerage.UseVisualStyleBackColor = True
        '
        'FrmCommRateTblSMan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(695, 465)
        Me.Controls.Add(Me.nbCommRate)
        Me.Controls.Add(Me.txtSrchMan)
        Me.Controls.Add(Me.txtManName)
        Me.Controls.Add(Me.cboManNo)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.GroupBoxSrchRateType)
        Me.Controls.Add(Me.fontPanel)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.GroupBoxRateType)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblCommRate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cboSearchYear)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.cboSearchMonth)
        Me.Controls.Add(Me.lblTurnover)
        Me.Controls.Add(Me.abTurnover)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnNew)
        Me.KeyPreview = True
        Me.Name = "FrmCommRateTblSMan"
        Me.Text = "Securities Comm. Rate Table (by Manager)"
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.abTurnover, 0)
        Me.Controls.SetChildIndex(Me.lblTurnover, 0)
        Me.Controls.SetChildIndex(Me.cboSearchMonth, 0)
        Me.Controls.SetChildIndex(Me.txtMonth, 0)
        Me.Controls.SetChildIndex(Me.cboSearchYear, 0)
        Me.Controls.SetChildIndex(Me.Label9, 0)
        Me.Controls.SetChildIndex(Me.lblCommRate, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label10, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxRateType, 0)
        Me.Controls.SetChildIndex(Me.Label14, 0)
        Me.Controls.SetChildIndex(Me.fontPanel, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxSrchRateType, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.cboManNo, 0)
        Me.Controls.SetChildIndex(Me.txtManName, 0)
        Me.Controls.SetChildIndex(Me.txtSrchMan, 0)
        Me.Controls.SetChildIndex(Me.nbCommRate, 0)
        Me.fontPanel.ResumeLayout(False)
        CType(Me.dgvManList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvRateList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSrchRateType.ResumeLayout(False)
        Me.GroupBoxSrchRateType.PerformLayout()
        Me.GroupBoxRateType.ResumeLayout(False)
        Me.GroupBoxRateType.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents lblTurnover As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSrchMan As ESL.myTextbox
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents lblCommRate As System.Windows.Forms.Label
    Friend WithEvents cboSearchYear As ESL.myComboBox
    Friend WithEvents cboSearchMonth As ESL.myComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents fontPanel As System.Windows.Forms.Panel
    Friend WithEvents dgvRateList As System.Windows.Forms.DataGridView
    Friend WithEvents nbCommRate As ESL.myNumericBox
    Friend WithEvents abTurnover As ESL.myAmountBox
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtManName As ESL.myTextbox
    Friend WithEvents dgvManList As System.Windows.Forms.DataGridView
    Friend WithEvents man_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboManNo As ESL.myComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxSrchRateType As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchTurn As ESL.myRadioButton
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents rbSrchBrok As ESL.myRadioButton
    Friend WithEvents GroupBoxRateType As System.Windows.Forms.GroupBox
    Friend WithEvents rbTurnover As ESL.myRadioButton
    Friend WithEvents rbBrokerage As ESL.myRadioButton
    Friend WithEvents srid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_month As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Brokerage_rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbSrchRebate As ESL.myRadioButton
    Friend WithEvents rbRebate As ESL.myRadioButton

End Class
