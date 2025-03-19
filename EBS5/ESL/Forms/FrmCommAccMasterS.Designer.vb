<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommAccMasterS
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
        Me.dtgAE = New System.Windows.Forms.DataGridView
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dtgAccDetail = New System.Windows.Forms.DataGridView
        Me.txmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acc_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.acc_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isConsolid = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.isbothfo = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Standard = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.minNorAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minIntAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minNorRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minIntRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSrchSec = New ESL.myRadioButton(Me.components)
        Me.rbSrchFut = New ESL.myRadioButton(Me.components)
        Me.cboSrchYear = New ESL.myComboBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboSrchMonth = New ESL.myComboBox(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboAccNo = New ESL.myComboBox(Me.components)
        Me.cboAENo = New ESL.myComboBox(Me.components)
        Me.txtMonth = New ESL.myTextbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtAEName = New ESL.myTextbox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtMinNorAmt = New ESL.myAmountBox
        Me.txtMinIntAmt = New ESL.myAmountBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtMinNorRate = New ESL.myAmountBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtMinIntRate = New ESL.myAmountBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtAccName = New ESL.myTextbox
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.Label15 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.dtgDetatil_B = New System.Windows.Forms.DataGridView
        Me.acc_no_B = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.consolid_B = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.isbothfo_b = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.isdefault = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.minNorAmt_B = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minIntAmt_B = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minNorRate_B = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minIntRate_B = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Update_B = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.GroupBoxEditType = New System.Windows.Forms.GroupBox
        Me.rbSingle = New ESL.myRadioButton(Me.components)
        Me.rbBatch = New ESL.myRadioButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBoxAcc = New System.Windows.Forms.GroupBox
        Me.cboACGrp = New ESL.myComboBox(Me.components)
        Me.Label14 = New System.Windows.Forms.Label
        Me.GroupBoxDetail = New System.Windows.Forms.GroupBox
        Me.CBFO = New System.Windows.Forms.CheckBox
        Me.CBNI = New System.Windows.Forms.CheckBox
        Me.CheckDefault = New ESL.myCheckBox(Me.components)
        Me.txtSrchAcc = New ESL.myTextbox
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.cbBatchAll = New ESL.myCheckBox(Me.components)
        Me.txtSrcAE = New ESL.myTextbox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnBatchDelete = New ESL.myButton(Me.components)
        Me.btnBatchNew = New ESL.myButton(Me.components)
        Me.btnBatchEdit = New ESL.myButton(Me.components)
        CType(Me.dtgAE, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgAccDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.dtgDetatil_B, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxEditType.SuspendLayout()
        Me.GroupBoxAcc.SuspendLayout()
        Me.GroupBoxDetail.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(808, 547)
        Me.btnCancel.TabIndex = 15
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(755, 547)
        Me.btnSave.TabIndex = 14
        Me.btnSave.Visible = True
        '
        'dtgAE
        '
        Me.dtgAE.AllowUserToAddRows = False
        Me.dtgAE.AllowUserToDeleteRows = False
        Me.dtgAE.AllowUserToResizeRows = False
        Me.dtgAE.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgAE.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAE.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ae_no, Me.ae_name})
        Me.dtgAE.Location = New System.Drawing.Point(3, 3)
        Me.dtgAE.MultiSelect = False
        Me.dtgAE.Name = "dtgAE"
        Me.dtgAE.ReadOnly = True
        Me.dtgAE.RowHeadersVisible = False
        Me.dtgAE.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgAE.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgAE.RowTemplate.Height = 24
        Me.dtgAE.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAE.Size = New System.Drawing.Size(145, 318)
        Me.dtgAE.TabIndex = 2
        '
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "A/E No."
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        Me.ae_no.Width = 80
        '
        'ae_name
        '
        Me.ae_name.DataPropertyName = "ae_name"
        Me.ae_name.HeaderText = "A/E Name"
        Me.ae_name.Name = "ae_name"
        Me.ae_name.ReadOnly = True
        '
        'dtgAccDetail
        '
        Me.dtgAccDetail.AllowUserToAddRows = False
        Me.dtgAccDetail.AllowUserToDeleteRows = False
        Me.dtgAccDetail.AllowUserToResizeRows = False
        Me.dtgAccDetail.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgAccDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAccDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txmonth, Me.acc_no, Me.acc_name, Me.isConsolid, Me.isbothfo, Me.Standard, Me.minNorAmt, Me.minIntAmt, Me.minNorRate, Me.minIntRate})
        Me.dtgAccDetail.Location = New System.Drawing.Point(151, 3)
        Me.dtgAccDetail.MultiSelect = False
        Me.dtgAccDetail.Name = "dtgAccDetail"
        Me.dtgAccDetail.ReadOnly = True
        Me.dtgAccDetail.RowHeadersVisible = False
        Me.dtgAccDetail.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgAccDetail.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black
        Me.dtgAccDetail.RowTemplate.Height = 24
        Me.dtgAccDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAccDetail.Size = New System.Drawing.Size(700, 318)
        Me.dtgAccDetail.TabIndex = 0
        '
        'txmonth
        '
        Me.txmonth.DataPropertyName = "txmonth"
        Me.txmonth.HeaderText = "Month"
        Me.txmonth.Name = "txmonth"
        Me.txmonth.ReadOnly = True
        Me.txmonth.Visible = False
        Me.txmonth.Width = 60
        '
        'acc_no
        '
        Me.acc_no.DataPropertyName = "acc_no"
        Me.acc_no.HeaderText = "A/C"
        Me.acc_no.Name = "acc_no"
        Me.acc_no.ReadOnly = True
        Me.acc_no.Width = 75
        '
        'acc_name
        '
        Me.acc_name.DataPropertyName = "acc_name"
        Me.acc_name.HeaderText = "A/C Name"
        Me.acc_name.Name = "acc_name"
        Me.acc_name.ReadOnly = True
        Me.acc_name.Width = 120
        '
        'isConsolid
        '
        Me.isConsolid.DataPropertyName = "isConsolid"
        Me.isConsolid.HeaderText = "Consolidate (N+I)"
        Me.isConsolid.Name = "isConsolid"
        Me.isConsolid.ReadOnly = True
        Me.isConsolid.Width = 70
        '
        'isbothfo
        '
        Me.isbothfo.DataPropertyName = "isbothfo"
        Me.isbothfo.HeaderText = "Consolidate (F+O)"
        Me.isbothfo.Name = "isbothfo"
        Me.isbothfo.ReadOnly = True
        Me.isbothfo.Width = 70
        '
        'Standard
        '
        Me.Standard.DataPropertyName = "isdefault"
        Me.Standard.HeaderText = "Default Rate"
        Me.Standard.Name = "Standard"
        Me.Standard.ReadOnly = True
        Me.Standard.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.Standard.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.Standard.Width = 50
        '
        'minNorAmt
        '
        Me.minNorAmt.DataPropertyName = "minNorAmt"
        Me.minNorAmt.HeaderText = "Min. Normal Amt."
        Me.minNorAmt.Name = "minNorAmt"
        Me.minNorAmt.ReadOnly = True
        Me.minNorAmt.Width = 70
        '
        'minIntAmt
        '
        Me.minIntAmt.DataPropertyName = "minIntAmt"
        Me.minIntAmt.HeaderText = "Min. Internet Amt."
        Me.minIntAmt.Name = "minIntAmt"
        Me.minIntAmt.ReadOnly = True
        Me.minIntAmt.Width = 70
        '
        'minNorRate
        '
        Me.minNorRate.DataPropertyName = "minNorRate"
        Me.minNorRate.HeaderText = "Min Normal Rate (%)"
        Me.minNorRate.Name = "minNorRate"
        Me.minNorRate.ReadOnly = True
        Me.minNorRate.Width = 80
        '
        'minIntRate
        '
        Me.minIntRate.DataPropertyName = "minIntRate"
        Me.minIntRate.HeaderText = "Min. Internet Rate (%)"
        Me.minIntRate.Name = "minIntRate"
        Me.minIntRate.ReadOnly = True
        Me.minIntRate.Width = 80
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSrchSec)
        Me.GroupBox1.Controls.Add(Me.rbSrchFut)
        Me.GroupBox1.Location = New System.Drawing.Point(243, 21)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(223, 31)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'rbSrchSec
        '
        Me.rbSrchSec.AutoSize = True
        Me.rbSrchSec.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchSec.Location = New System.Drawing.Point(6, 10)
        Me.rbSrchSec.Name = "rbSrchSec"
        Me.rbSrchSec.Size = New System.Drawing.Size(73, 18)
        Me.rbSrchSec.TabIndex = 0
        Me.rbSrchSec.Text = "Securities"
        Me.rbSrchSec.UseVisualStyleBackColor = True
        '
        'rbSrchFut
        '
        Me.rbSrchFut.AutoSize = True
        Me.rbSrchFut.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSrchFut.Location = New System.Drawing.Point(93, 11)
        Me.rbSrchFut.Name = "rbSrchFut"
        Me.rbSrchFut.Size = New System.Drawing.Size(123, 18)
        Me.rbSrchFut.TabIndex = 1
        Me.rbSrchFut.Text = "Futures and Options"
        Me.rbSrchFut.UseVisualStyleBackColor = True
        '
        'cboSrchYear
        '
        Me.cboSrchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSrchYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSrchYear.FormattingEnabled = True
        Me.cboSrchYear.Location = New System.Drawing.Point(43, 32)
        Me.cboSrchYear.Name = "cboSrchYear"
        Me.cboSrchYear.Size = New System.Drawing.Size(72, 19)
        Me.cboSrchYear.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(123, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 92
        Me.Label4.Text = "Month"
        '
        'cboSrchMonth
        '
        Me.cboSrchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSrchMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSrchMonth.FormattingEnabled = True
        Me.cboSrchMonth.Location = New System.Drawing.Point(165, 32)
        Me.cboSrchMonth.Name = "cboSrchMonth"
        Me.cboSrchMonth.Size = New System.Drawing.Size(53, 19)
        Me.cboSrchMonth.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(11, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 91
        Me.Label3.Text = "Year"
        '
        'cboAccNo
        '
        Me.cboAccNo.Enabled = False
        Me.cboAccNo.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboAccNo.FormattingEnabled = True
        Me.cboAccNo.Location = New System.Drawing.Point(62, 19)
        Me.cboAccNo.Name = "cboAccNo"
        Me.cboAccNo.Size = New System.Drawing.Size(141, 19)
        Me.cboAccNo.TabIndex = 0
        '
        'cboAENo
        '
        Me.cboAENo.Enabled = False
        Me.cboAENo.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboAENo.FormattingEnabled = True
        Me.cboAENo.Location = New System.Drawing.Point(62, 46)
        Me.cboAENo.Name = "cboAENo"
        Me.cboAENo.Size = New System.Drawing.Size(141, 19)
        Me.cboAENo.TabIndex = 1
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(653, 19)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(118, 20)
        Me.txtMonth.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(8, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 15)
        Me.Label6.TabIndex = 122
        Me.Label6.Text = "A/E No."
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(537, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Month"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 15)
        Me.Label1.TabIndex = 120
        Me.Label1.Text = "A/C No."
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Location = New System.Drawing.Point(209, 43)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(294, 21)
        Me.txtAEName.TabIndex = 4
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(290, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(97, 15)
        Me.Label8.TabIndex = 131
        Me.Label8.Text = "Min. Normal Amt"
        '
        'txtMinNorAmt
        '
        Me.txtMinNorAmt.DecimalPoints = 2
        Me.txtMinNorAmt.Location = New System.Drawing.Point(391, 15)
        Me.txtMinNorAmt.Name = "txtMinNorAmt"
        Me.txtMinNorAmt.Size = New System.Drawing.Size(113, 21)
        Me.txtMinNorAmt.TabIndex = 3
        Me.txtMinNorAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinIntAmt
        '
        Me.txtMinIntAmt.DecimalPoints = 2
        Me.txtMinIntAmt.Location = New System.Drawing.Point(659, 15)
        Me.txtMinIntAmt.Name = "txtMinIntAmt"
        Me.txtMinIntAmt.Size = New System.Drawing.Size(113, 21)
        Me.txtMinIntAmt.TabIndex = 4
        Me.txtMinIntAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(543, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(97, 15)
        Me.Label9.TabIndex = 133
        Me.Label9.Text = "Min. Internet Amt"
        '
        'txtMinNorRate
        '
        Me.txtMinNorRate.DecimalPoints = 4
        Me.txtMinNorRate.Location = New System.Drawing.Point(391, 42)
        Me.txtMinNorRate.Name = "txtMinNorRate"
        Me.txtMinNorRate.Size = New System.Drawing.Size(113, 21)
        Me.txtMinNorRate.TabIndex = 5
        Me.txtMinNorRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(289, 45)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 15)
        Me.Label10.TabIndex = 135
        Me.Label10.Text = "Min. Normal Rate"
        '
        'txtMinIntRate
        '
        Me.txtMinIntRate.DecimalPoints = 4
        Me.txtMinIntRate.Location = New System.Drawing.Point(659, 42)
        Me.txtMinIntRate.Name = "txtMinIntRate"
        Me.txtMinIntRate.Size = New System.Drawing.Size(113, 21)
        Me.txtMinIntRate.TabIndex = 6
        Me.txtMinIntRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(543, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 15)
        Me.Label11.TabIndex = 137
        Me.Label11.Text = "Min. Internet Rate"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(507, 45)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 15)
        Me.Label12.TabIndex = 139
        Me.Label12.Text = "%"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(778, 45)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(18, 15)
        Me.Label13.TabIndex = 140
        Me.Label13.Text = "%"
        '
        'txtAccName
        '
        Me.txtAccName.Location = New System.Drawing.Point(209, 19)
        Me.txtAccName.Name = "txtAccName"
        Me.txtAccName.Size = New System.Drawing.Size(294, 21)
        Me.txtAccName.TabIndex = 1
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(699, 548)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 13
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(597, 548)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 11
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(648, 548)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 12
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label15.Location = New System.Drawing.Point(280, 2)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(277, 22)
        Me.Label15.TabIndex = 146
        Me.Label15.Text = "Commission Account Master"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtgAE)
        Me.Panel1.Controls.Add(Me.dtgAccDetail)
        Me.Panel1.Controls.Add(Me.dtgDetatil_B)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.0!)
        Me.Panel1.Location = New System.Drawing.Point(12, 53)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(859, 329)
        Me.Panel1.TabIndex = 148
        '
        'dtgDetatil_B
        '
        Me.dtgDetatil_B.AllowUserToAddRows = False
        Me.dtgDetatil_B.AllowUserToDeleteRows = False
        Me.dtgDetatil_B.AllowUserToResizeRows = False
        Me.dtgDetatil_B.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgDetatil_B.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgDetatil_B.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.acc_no_B, Me.consolid_B, Me.isbothfo_b, Me.isdefault, Me.minNorAmt_B, Me.minIntAmt_B, Me.minNorRate_B, Me.minIntRate_B, Me.Update_B})
        Me.dtgDetatil_B.Location = New System.Drawing.Point(151, 3)
        Me.dtgDetatil_B.MultiSelect = False
        Me.dtgDetatil_B.Name = "dtgDetatil_B"
        Me.dtgDetatil_B.RowHeadersVisible = False
        Me.dtgDetatil_B.RowTemplate.Height = 24
        Me.dtgDetatil_B.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgDetatil_B.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgDetatil_B.Size = New System.Drawing.Size(700, 318)
        Me.dtgDetatil_B.TabIndex = 142
        '
        'acc_no_B
        '
        Me.acc_no_B.DataPropertyName = "acc_no"
        Me.acc_no_B.HeaderText = "A/C"
        Me.acc_no_B.Name = "acc_no_B"
        Me.acc_no_B.Width = 60
        '
        'consolid_B
        '
        Me.consolid_B.DataPropertyName = "isConsolid"
        Me.consolid_B.HeaderText = "Consolidate (N+I)"
        Me.consolid_B.Name = "consolid_B"
        Me.consolid_B.Width = 80
        '
        'isbothfo_b
        '
        Me.isbothfo_b.DataPropertyName = "isbothfo"
        Me.isbothfo_b.HeaderText = "Consolidate (F+O)"
        Me.isbothfo_b.Name = "isbothfo_b"
        Me.isbothfo_b.Width = 80
        '
        'isdefault
        '
        Me.isdefault.DataPropertyName = "isdefault"
        Me.isdefault.HeaderText = "Default Rate"
        Me.isdefault.Name = "isdefault"
        '
        'minNorAmt_B
        '
        Me.minNorAmt_B.DataPropertyName = "minNorAmt"
        Me.minNorAmt_B.HeaderText = "Min. Normal Amt."
        Me.minNorAmt_B.Name = "minNorAmt_B"
        Me.minNorAmt_B.Width = 80
        '
        'minIntAmt_B
        '
        Me.minIntAmt_B.DataPropertyName = "minIntAmt"
        Me.minIntAmt_B.HeaderText = "Min. Internet Amt."
        Me.minIntAmt_B.Name = "minIntAmt_B"
        Me.minIntAmt_B.Width = 80
        '
        'minNorRate_B
        '
        Me.minNorRate_B.DataPropertyName = "minNorRate"
        Me.minNorRate_B.HeaderText = "Min Normal Rate (%)"
        Me.minNorRate_B.Name = "minNorRate_B"
        Me.minNorRate_B.Width = 80
        '
        'minIntRate_B
        '
        Me.minIntRate_B.DataPropertyName = "minIntRate"
        Me.minIntRate_B.HeaderText = "Min. Internet Rate (%)"
        Me.minIntRate_B.Name = "minIntRate_B"
        Me.minIntRate_B.Width = 80
        '
        'Update_B
        '
        Me.Update_B.DataPropertyName = "selection"
        Me.Update_B.FalseValue = "False"
        Me.Update_B.HeaderText = ""
        Me.Update_B.Name = "Update_B"
        Me.Update_B.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Update_B.TrueValue = "True"
        Me.Update_B.Width = 40
        '
        'GroupBoxEditType
        '
        Me.GroupBoxEditType.Controls.Add(Me.rbSingle)
        Me.GroupBoxEditType.Controls.Add(Me.rbBatch)
        Me.GroupBoxEditType.Location = New System.Drawing.Point(84, 546)
        Me.GroupBoxEditType.Name = "GroupBoxEditType"
        Me.GroupBoxEditType.Size = New System.Drawing.Size(128, 31)
        Me.GroupBoxEditType.TabIndex = 7
        Me.GroupBoxEditType.TabStop = False
        Me.GroupBoxEditType.Visible = False
        '
        'rbSingle
        '
        Me.rbSingle.AutoSize = True
        Me.rbSingle.Checked = True
        Me.rbSingle.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbSingle.Location = New System.Drawing.Point(6, 10)
        Me.rbSingle.Name = "rbSingle"
        Me.rbSingle.Size = New System.Drawing.Size(54, 18)
        Me.rbSingle.TabIndex = 0
        Me.rbSingle.TabStop = True
        Me.rbSingle.Text = "Single"
        Me.rbSingle.UseVisualStyleBackColor = True
        '
        'rbBatch
        '
        Me.rbBatch.AutoSize = True
        Me.rbBatch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbBatch.Location = New System.Drawing.Point(66, 10)
        Me.rbBatch.Name = "rbBatch"
        Me.rbBatch.Size = New System.Drawing.Size(53, 18)
        Me.rbBatch.TabIndex = 1
        Me.rbBatch.Text = "Batch"
        Me.rbBatch.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(21, 557)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(57, 15)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Edit Type"
        Me.Label7.Visible = False
        '
        'GroupBoxAcc
        '
        Me.GroupBoxAcc.Controls.Add(Me.cboACGrp)
        Me.GroupBoxAcc.Controls.Add(Me.Label14)
        Me.GroupBoxAcc.Controls.Add(Me.Label2)
        Me.GroupBoxAcc.Controls.Add(Me.txtMonth)
        Me.GroupBoxAcc.Controls.Add(Me.Label6)
        Me.GroupBoxAcc.Controls.Add(Me.cboAENo)
        Me.GroupBoxAcc.Controls.Add(Me.txtAEName)
        Me.GroupBoxAcc.Controls.Add(Me.cboAccNo)
        Me.GroupBoxAcc.Controls.Add(Me.Label1)
        Me.GroupBoxAcc.Controls.Add(Me.txtAccName)
        Me.GroupBoxAcc.Location = New System.Drawing.Point(9, 393)
        Me.GroupBoxAcc.Name = "GroupBoxAcc"
        Me.GroupBoxAcc.Size = New System.Drawing.Size(850, 70)
        Me.GroupBoxAcc.TabIndex = 6
        Me.GroupBoxAcc.TabStop = False
        Me.GroupBoxAcc.Text = "Account"
        '
        'cboACGrp
        '
        Me.cboACGrp.Enabled = False
        Me.cboACGrp.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboACGrp.FormattingEnabled = True
        Me.cboACGrp.Location = New System.Drawing.Point(653, 43)
        Me.cboACGrp.Name = "cboACGrp"
        Me.cboACGrp.Size = New System.Drawing.Size(118, 19)
        Me.cboACGrp.TabIndex = 2
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(537, 46)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(63, 15)
        Me.Label14.TabIndex = 123
        Me.Label14.Text = "A/C Group"
        '
        'GroupBoxDetail
        '
        Me.GroupBoxDetail.Controls.Add(Me.CBFO)
        Me.GroupBoxDetail.Controls.Add(Me.CBNI)
        Me.GroupBoxDetail.Controls.Add(Me.CheckDefault)
        Me.GroupBoxDetail.Controls.Add(Me.Label10)
        Me.GroupBoxDetail.Controls.Add(Me.Label11)
        Me.GroupBoxDetail.Controls.Add(Me.txtMinNorRate)
        Me.GroupBoxDetail.Controls.Add(Me.Label8)
        Me.GroupBoxDetail.Controls.Add(Me.txtMinIntRate)
        Me.GroupBoxDetail.Controls.Add(Me.txtMinNorAmt)
        Me.GroupBoxDetail.Controls.Add(Me.Label13)
        Me.GroupBoxDetail.Controls.Add(Me.Label9)
        Me.GroupBoxDetail.Controls.Add(Me.Label12)
        Me.GroupBoxDetail.Controls.Add(Me.txtMinIntAmt)
        Me.GroupBoxDetail.Location = New System.Drawing.Point(8, 462)
        Me.GroupBoxDetail.Name = "GroupBoxDetail"
        Me.GroupBoxDetail.Size = New System.Drawing.Size(851, 80)
        Me.GroupBoxDetail.TabIndex = 7
        Me.GroupBoxDetail.TabStop = False
        Me.GroupBoxDetail.Text = "Detail"
        '
        'CBFO
        '
        Me.CBFO.AutoSize = True
        Me.CBFO.Location = New System.Drawing.Point(12, 55)
        Me.CBFO.Name = "CBFO"
        Me.CBFO.Size = New System.Drawing.Size(208, 19)
        Me.CBFO.TabIndex = 2
        Me.CBFO.Text = "Consolidate ( Futures + Options )"
        Me.CBFO.UseVisualStyleBackColor = True
        '
        'CBNI
        '
        Me.CBNI.AutoSize = True
        Me.CBNI.Location = New System.Drawing.Point(12, 34)
        Me.CBNI.Name = "CBNI"
        Me.CBNI.Size = New System.Drawing.Size(205, 19)
        Me.CBNI.TabIndex = 1
        Me.CBNI.Text = "Consolidate ( Normal + Internet )"
        Me.CBNI.UseVisualStyleBackColor = True
        '
        'CheckDefault
        '
        Me.CheckDefault.AutoSize = True
        Me.CheckDefault.Location = New System.Drawing.Point(12, 14)
        Me.CheckDefault.Name = "CheckDefault"
        Me.CheckDefault.Size = New System.Drawing.Size(117, 19)
        Me.CheckDefault.TabIndex = 0
        Me.CheckDefault.Text = "Use Defaut Rate"
        Me.CheckDefault.UseVisualStyleBackColor = True
        '
        'txtSrchAcc
        '
        Me.txtSrchAcc.Location = New System.Drawing.Point(518, 29)
        Me.txtSrchAcc.Name = "txtSrchAcc"
        Me.txtSrchAcc.Size = New System.Drawing.Size(100, 21)
        Me.txtSrchAcc.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(487, 33)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(25, 14)
        Me.Label16.TabIndex = 155
        Me.Label16.Text = "A/C"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(770, 25)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(93, 26)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cbBatchAll
        '
        Me.cbBatchAll.AutoSize = True
        Me.cbBatchAll.Location = New System.Drawing.Point(782, 380)
        Me.cbBatchAll.Name = "cbBatchAll"
        Me.cbBatchAll.Size = New System.Drawing.Size(76, 19)
        Me.cbBatchAll.TabIndex = 14
        Me.cbBatchAll.Text = "Select All"
        Me.cbBatchAll.UseVisualStyleBackColor = True
        '
        'txtSrcAE
        '
        Me.txtSrcAE.Location = New System.Drawing.Point(662, 28)
        Me.txtSrcAE.Name = "txtSrcAE"
        Me.txtSrcAE.Size = New System.Drawing.Size(100, 21)
        Me.txtSrcAE.TabIndex = 4
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(628, 34)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(21, 14)
        Me.Label17.TabIndex = 159
        Me.Label17.Text = "AE"
        '
        'btnBatchDelete
        '
        Me.btnBatchDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatchDelete.Location = New System.Drawing.Point(541, 548)
        Me.btnBatchDelete.Name = "btnBatchDelete"
        Me.btnBatchDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnBatchDelete.TabIndex = 10
        Me.btnBatchDelete.Text = "Batch Delete"
        Me.btnBatchDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBatchDelete.UseVisualStyleBackColor = True
        '
        'btnBatchNew
        '
        Me.btnBatchNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatchNew.Location = New System.Drawing.Point(439, 548)
        Me.btnBatchNew.Name = "btnBatchNew"
        Me.btnBatchNew.Size = New System.Drawing.Size(50, 55)
        Me.btnBatchNew.TabIndex = 8
        Me.btnBatchNew.Text = "Batch New"
        Me.btnBatchNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBatchNew.UseVisualStyleBackColor = True
        '
        'btnBatchEdit
        '
        Me.btnBatchEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBatchEdit.Location = New System.Drawing.Point(490, 548)
        Me.btnBatchEdit.Name = "btnBatchEdit"
        Me.btnBatchEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnBatchEdit.TabIndex = 9
        Me.btnBatchEdit.Text = "Batch Edit"
        Me.btnBatchEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBatchEdit.UseVisualStyleBackColor = True
        '
        'FrmCommAccMasterS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(883, 605)
        Me.Controls.Add(Me.btnBatchDelete)
        Me.Controls.Add(Me.btnBatchNew)
        Me.Controls.Add(Me.btnBatchEdit)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.txtSrcAE)
        Me.Controls.Add(Me.cbBatchAll)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.GroupBoxAcc)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.txtSrchAcc)
        Me.Controls.Add(Me.GroupBoxEditType)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cboSrchYear)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboSrchMonth)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.GroupBoxDetail)
        Me.KeyPreview = True
        Me.Name = "FrmCommAccMasterS"
        Me.Text = "Commission Account Master"
        Me.Controls.SetChildIndex(Me.GroupBoxDetail, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.cboSrchMonth, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.cboSrchYear, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxEditType, 0)
        Me.Controls.SetChildIndex(Me.txtSrchAcc, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxAcc, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.cbBatchAll, 0)
        Me.Controls.SetChildIndex(Me.txtSrcAE, 0)
        Me.Controls.SetChildIndex(Me.Label17, 0)
        Me.Controls.SetChildIndex(Me.btnBatchEdit, 0)
        Me.Controls.SetChildIndex(Me.btnBatchNew, 0)
        Me.Controls.SetChildIndex(Me.btnBatchDelete, 0)
        CType(Me.dtgAE, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgAccDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        CType(Me.dtgDetatil_B, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxEditType.ResumeLayout(False)
        Me.GroupBoxEditType.PerformLayout()
        Me.GroupBoxAcc.ResumeLayout(False)
        Me.GroupBoxAcc.PerformLayout()
        Me.GroupBoxDetail.ResumeLayout(False)
        Me.GroupBoxDetail.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgAE As System.Windows.Forms.DataGridView
    Friend WithEvents dtgAccDetail As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchSec As ESL.myRadioButton
    Friend WithEvents rbSrchFut As ESL.myRadioButton
    Friend WithEvents cboSrchYear As ESL.myComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSrchMonth As ESL.myComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboAccNo As ESL.myComboBox
    Friend WithEvents cboAENo As ESL.myComboBox
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtMinNorAmt As ESL.myAmountBox
    Friend WithEvents txtMinIntAmt As ESL.myAmountBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtMinNorRate As ESL.myAmountBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMinIntRate As ESL.myAmountBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtAccName As ESL.myTextbox
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents dtgDetatil_B As System.Windows.Forms.DataGridView
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents GroupBoxEditType As System.Windows.Forms.GroupBox
    Friend WithEvents rbSingle As ESL.myRadioButton
    Friend WithEvents rbBatch As ESL.myRadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxAcc As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxDetail As System.Windows.Forms.GroupBox
    Friend WithEvents txtSrchAcc As ESL.myTextbox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents cbBatchAll As ESL.myCheckBox
    Friend WithEvents txtSrcAE As ESL.myTextbox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents CheckDefault As ESL.myCheckBox
    Friend WithEvents btnBatchDelete As ESL.myButton
    Friend WithEvents btnBatchNew As ESL.myButton
    Friend WithEvents btnBatchEdit As ESL.myButton
    Friend WithEvents cboACGrp As ESL.myComboBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents CBFO As System.Windows.Forms.CheckBox
    Friend WithEvents CBNI As System.Windows.Forms.CheckBox
    Friend WithEvents txmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isConsolid As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents isbothfo As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Standard As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents minNorAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minIntAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minNorRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minIntRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents acc_no_B As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents consolid_B As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents isbothfo_b As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents isdefault As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents minNorAmt_B As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minIntAmt_B As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minNorRate_B As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minIntRate_B As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Update_B As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
