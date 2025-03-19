<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCRCDebitBalance
    Inherits ESL.frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.tabCRCBAD = New System.Windows.Forms.TabControl()
        Me.tlpAEListing = New System.Windows.Forms.TabPage()
        Me.dgvTotal = New System.Windows.Forms.DataGridView()
        Me.space1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ttl = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dr_str_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mv_str_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actr_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_dr_bal_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dd_c_str_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dd_b_str_total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.space2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.txtAECode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btnExit = New ESL.myButton(Me.components)
        Me.btnReset = New ESL.myButton(Me.components)
        Me.dgvAEListing = New System.Windows.Forms.DataGridView()
        Me.run_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.rname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dr_str = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mv_str = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.actr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.f_dr_bal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dd_c_str = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dd_b_str = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.seto = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mv = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.fdr = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.b_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.c_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tlpAEDtl = New System.Windows.Forms.TabPage()
        Me.btnCancelDtl = New ESL.myButton(Me.components)
        Me.btnSaveDtl = New ESL.myButton(Me.components)
        Me.btnExit2 = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.plAEDtl = New System.Windows.Forms.Panel()
        Me.rtxtRemark = New System.Windows.Forms.RichTextBox()
        Me.nudTypeB = New System.Windows.Forms.NumericUpDown()
        Me.nudTypeC = New System.Windows.Forms.NumericUpDown()
        Me.lblDtlTotal = New System.Windows.Forms.Label()
        Me.lblBType = New System.Windows.Forms.Label()
        Me.lblRemark = New System.Windows.Forms.Label()
        Me.lblCType = New System.Windows.Forms.Label()
        Me.chkSetOff = New System.Windows.Forms.CheckBox()
        Me.lblSetOff = New System.Windows.Forms.Label()
        Me.txtDtlTotal = New System.Windows.Forms.TextBox()
        Me.lblCRCContrlDtl = New System.Windows.Forms.Label()
        Me.txtActualRatio = New System.Windows.Forms.TextBox()
        Me.txtMarketValue = New System.Windows.Forms.TextBox()
        Me.txtTotalDebit = New System.Windows.Forms.TextBox()
        Me.txtDebitBalF = New System.Windows.Forms.TextBox()
        Me.txtDebitBalS = New System.Windows.Forms.TextBox()
        Me.lblActualRatio = New System.Windows.Forms.Label()
        Me.lblMarketValue = New System.Windows.Forms.Label()
        Me.lblTotalDebit = New System.Windows.Forms.Label()
        Me.lblDebitBalF = New System.Windows.Forms.Label()
        Me.lblDebitBalS = New System.Windows.Forms.Label()
        Me.txtName = New System.Windows.Forms.TextBox()
        Me.txtAECodeShow = New System.Windows.Forms.TextBox()
        Me.lblRunner = New System.Windows.Forms.Label()
        Me.tlpPrint = New System.Windows.Forms.TabPage()
        Me.btnExit_print = New System.Windows.Forms.Button()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.lblPrintRange = New System.Windows.Forms.Label()
        Me.gbxPrintRange = New System.Windows.Forms.GroupBox()
        Me.cbxPrintRange_Addition = New System.Windows.Forms.CheckBox()
        Me.cbbPrintRange_CodeTo = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbbPrintRange_CodeFrom = New System.Windows.Forms.ComboBox()
        Me.rbPrintRange_RunnerCode = New System.Windows.Forms.RadioButton()
        Me.rbPrintRange_All = New System.Windows.Forms.RadioButton()
        Me.tabCRCBAD.SuspendLayout()
        Me.tlpAEListing.SuspendLayout()
        CType(Me.dgvTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvAEListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpAEDtl.SuspendLayout()
        Me.plAEDtl.SuspendLayout()
        CType(Me.nudTypeB, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudTypeC, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpPrint.SuspendLayout()
        Me.gbxPrintRange.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(1016, 698)
        Me.btnCancel.Visible = False
        '
        'btnSave
        '
        Me.btnSave.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.btnSave.Location = New System.Drawing.Point(976, 590)
        '
        'tabCRCBAD
        '
        Me.tabCRCBAD.Controls.Add(Me.tlpAEListing)
        Me.tabCRCBAD.Controls.Add(Me.tlpAEDtl)
        Me.tabCRCBAD.Controls.Add(Me.tlpPrint)
        Me.tabCRCBAD.Location = New System.Drawing.Point(11, 12)
        Me.tabCRCBAD.Name = "tabCRCBAD"
        Me.tabCRCBAD.SelectedIndex = 0
        Me.tabCRCBAD.Size = New System.Drawing.Size(1101, 524)
        Me.tabCRCBAD.TabIndex = 5
        '
        'tlpAEListing
        '
        Me.tlpAEListing.Controls.Add(Me.dgvTotal)
        Me.tlpAEListing.Controls.Add(Me.txtAECode)
        Me.tlpAEListing.Controls.Add(Me.Label3)
        Me.tlpAEListing.Controls.Add(Me.btnExit)
        Me.tlpAEListing.Controls.Add(Me.btnReset)
        Me.tlpAEListing.Controls.Add(Me.dgvAEListing)
        Me.tlpAEListing.Location = New System.Drawing.Point(4, 24)
        Me.tlpAEListing.Name = "tlpAEListing"
        Me.tlpAEListing.Padding = New System.Windows.Forms.Padding(3)
        Me.tlpAEListing.Size = New System.Drawing.Size(1093, 496)
        Me.tlpAEListing.TabIndex = 0
        Me.tlpAEListing.Text = "Runner Listing"
        Me.tlpAEListing.UseVisualStyleBackColor = True
        '
        'dgvTotal
        '
        Me.dgvTotal.AllowUserToAddRows = False
        Me.dgvTotal.AllowUserToDeleteRows = False
        Me.dgvTotal.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvTotal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvTotal.ColumnHeadersVisible = False
        Me.dgvTotal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.space1, Me.ttl, Me.dr_str_total, Me.mv_str_total, Me.actr_total, Me.f_dr_bal_total, Me.dd_c_str_total, Me.dd_b_str_total, Me.space2})
        Me.dgvTotal.Location = New System.Drawing.Point(6, 464)
        Me.dgvTotal.Name = "dgvTotal"
        Me.dgvTotal.ReadOnly = True
        Me.dgvTotal.RowHeadersVisible = False
        Me.dgvTotal.RowTemplate.Height = 23
        Me.dgvTotal.Size = New System.Drawing.Size(989, 28)
        Me.dgvTotal.TabIndex = 12
        '
        'space1
        '
        Me.space1.HeaderText = ""
        Me.space1.Name = "space1"
        Me.space1.ReadOnly = True
        Me.space1.Width = 70
        '
        'ttl
        '
        Me.ttl.DataPropertyName = "ttl"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.ttl.DefaultCellStyle = DataGridViewCellStyle1
        Me.ttl.HeaderText = ""
        Me.ttl.Name = "ttl"
        Me.ttl.ReadOnly = True
        Me.ttl.Width = 230
        '
        'dr_str_total
        '
        Me.dr_str_total.DataPropertyName = "dr_str"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dr_str_total.DefaultCellStyle = DataGridViewCellStyle2
        Me.dr_str_total.HeaderText = ""
        Me.dr_str_total.Name = "dr_str_total"
        Me.dr_str_total.ReadOnly = True
        '
        'mv_str_total
        '
        Me.mv_str_total.DataPropertyName = "mv_str"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.mv_str_total.DefaultCellStyle = DataGridViewCellStyle3
        Me.mv_str_total.HeaderText = ""
        Me.mv_str_total.Name = "mv_str_total"
        Me.mv_str_total.ReadOnly = True
        '
        'actr_total
        '
        Me.actr_total.DataPropertyName = "actr"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.actr_total.DefaultCellStyle = DataGridViewCellStyle4
        Me.actr_total.HeaderText = ""
        Me.actr_total.Name = "actr_total"
        Me.actr_total.ReadOnly = True
        '
        'f_dr_bal_total
        '
        Me.f_dr_bal_total.DataPropertyName = "f_dr_bal"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_dr_bal_total.DefaultCellStyle = DataGridViewCellStyle5
        Me.f_dr_bal_total.HeaderText = ""
        Me.f_dr_bal_total.Name = "f_dr_bal_total"
        Me.f_dr_bal_total.ReadOnly = True
        '
        'dd_c_str_total
        '
        Me.dd_c_str_total.DataPropertyName = "dd_c_str"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dd_c_str_total.DefaultCellStyle = DataGridViewCellStyle6
        Me.dd_c_str_total.HeaderText = ""
        Me.dd_c_str_total.Name = "dd_c_str_total"
        Me.dd_c_str_total.ReadOnly = True
        '
        'dd_b_str_total
        '
        Me.dd_b_str_total.DataPropertyName = "dd_b_str"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dd_b_str_total.DefaultCellStyle = DataGridViewCellStyle7
        Me.dd_b_str_total.HeaderText = ""
        Me.dd_b_str_total.Name = "dd_b_str_total"
        Me.dd_b_str_total.ReadOnly = True
        '
        'space2
        '
        Me.space2.HeaderText = ""
        Me.space2.Name = "space2"
        Me.space2.ReadOnly = True
        Me.space2.Width = 70
        '
        'txtAECode
        '
        Me.txtAECode.Location = New System.Drawing.Point(1004, 78)
        Me.txtAECode.Name = "txtAECode"
        Me.txtAECode.Size = New System.Drawing.Size(72, 21)
        Me.txtAECode.TabIndex = 8
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label3.ForeColor = System.Drawing.SystemColors.MenuHighlight
        Me.Label3.Location = New System.Drawing.Point(1001, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 15)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Runner Code"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(1004, 467)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 23)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "Exit"
        Me.btnExit.UseVisualStyleBackColor = True
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(1001, 6)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 6
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'dgvAEListing
        '
        Me.dgvAEListing.AllowUserToAddRows = False
        Me.dgvAEListing.AllowUserToDeleteRows = False
        Me.dgvAEListing.AllowUserToOrderColumns = True
        Me.dgvAEListing.AllowUserToResizeRows = False
        Me.dgvAEListing.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvAEListing.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvAEListing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAEListing.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.run_code, Me.rname, Me.dr_str, Me.mv_str, Me.actr, Me.f_dr_bal, Me.dd_c_str, Me.dd_b_str, Me.seto, Me.mv, Me.dr, Me.fdr, Me.remarks, Me.b_type, Me.c_type})
        Me.dgvAEListing.Location = New System.Drawing.Point(6, 6)
        Me.dgvAEListing.MultiSelect = False
        Me.dgvAEListing.Name = "dgvAEListing"
        Me.dgvAEListing.ReadOnly = True
        Me.dgvAEListing.RowHeadersVisible = False
        Me.dgvAEListing.RowTemplate.Height = 23
        Me.dgvAEListing.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAEListing.Size = New System.Drawing.Size(989, 442)
        Me.dgvAEListing.TabIndex = 11
        '
        'run_code
        '
        Me.run_code.DataPropertyName = "run_code"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.run_code.DefaultCellStyle = DataGridViewCellStyle8
        Me.run_code.HeaderText = "Runner"
        Me.run_code.Name = "run_code"
        Me.run_code.ReadOnly = True
        Me.run_code.Width = 70
        '
        'rname
        '
        Me.rname.DataPropertyName = "rname"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.rname.DefaultCellStyle = DataGridViewCellStyle9
        Me.rname.HeaderText = "Name"
        Me.rname.Name = "rname"
        Me.rname.ReadOnly = True
        Me.rname.Width = 230
        '
        'dr_str
        '
        Me.dr_str.DataPropertyName = "dr_str"
        DataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dr_str.DefaultCellStyle = DataGridViewCellStyle10
        Me.dr_str.HeaderText = "Dr. Bal.(S)"
        Me.dr_str.Name = "dr_str"
        Me.dr_str.ReadOnly = True
        '
        'mv_str
        '
        Me.mv_str.DataPropertyName = "mv_str"
        DataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.mv_str.DefaultCellStyle = DataGridViewCellStyle11
        Me.mv_str.HeaderText = "Mkt. V."
        Me.mv_str.Name = "mv_str"
        Me.mv_str.ReadOnly = True
        '
        'actr
        '
        Me.actr.DataPropertyName = "actr"
        DataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.actr.DefaultCellStyle = DataGridViewCellStyle12
        Me.actr.HeaderText = "Act. Ratio"
        Me.actr.Name = "actr"
        Me.actr.ReadOnly = True
        '
        'f_dr_bal
        '
        Me.f_dr_bal.DataPropertyName = "f_dr_bal"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.f_dr_bal.DefaultCellStyle = DataGridViewCellStyle13
        Me.f_dr_bal.HeaderText = "Dr. Bal(F)"
        Me.f_dr_bal.Name = "f_dr_bal"
        Me.f_dr_bal.ReadOnly = True
        '
        'dd_c_str
        '
        Me.dd_c_str.DataPropertyName = "dd_c_str"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dd_c_str.DefaultCellStyle = DataGridViewCellStyle14
        Me.dd_c_str.HeaderText = "Deduct C"
        Me.dd_c_str.Name = "dd_c_str"
        Me.dd_c_str.ReadOnly = True
        '
        'dd_b_str
        '
        Me.dd_b_str.DataPropertyName = "dd_b_str"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.dd_b_str.DefaultCellStyle = DataGridViewCellStyle15
        Me.dd_b_str.HeaderText = "Deduct B"
        Me.dd_b_str.Name = "dd_b_str"
        Me.dd_b_str.ReadOnly = True
        '
        'seto
        '
        Me.seto.DataPropertyName = "seto"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.seto.DefaultCellStyle = DataGridViewCellStyle16
        Me.seto.HeaderText = "Set Off"
        Me.seto.Name = "seto"
        Me.seto.ReadOnly = True
        Me.seto.Width = 70
        '
        'mv
        '
        Me.mv.DataPropertyName = "mv"
        Me.mv.HeaderText = "mv"
        Me.mv.Name = "mv"
        Me.mv.ReadOnly = True
        Me.mv.Visible = False
        '
        'dr
        '
        Me.dr.DataPropertyName = "dr"
        Me.dr.HeaderText = "dr"
        Me.dr.Name = "dr"
        Me.dr.ReadOnly = True
        Me.dr.Visible = False
        '
        'fdr
        '
        Me.fdr.DataPropertyName = "fdr"
        Me.fdr.HeaderText = "fdr"
        Me.fdr.Name = "fdr"
        Me.fdr.ReadOnly = True
        Me.fdr.Visible = False
        '
        'remarks
        '
        Me.remarks.DataPropertyName = "remarks"
        Me.remarks.HeaderText = "remarks"
        Me.remarks.Name = "remarks"
        Me.remarks.ReadOnly = True
        Me.remarks.Visible = False
        '
        'b_type
        '
        Me.b_type.DataPropertyName = "b_type"
        Me.b_type.HeaderText = "b_type"
        Me.b_type.Name = "b_type"
        Me.b_type.ReadOnly = True
        Me.b_type.Visible = False
        '
        'c_type
        '
        Me.c_type.DataPropertyName = "c_type"
        Me.c_type.HeaderText = "c_type"
        Me.c_type.Name = "c_type"
        Me.c_type.ReadOnly = True
        Me.c_type.Visible = False
        '
        'tlpAEDtl
        '
        Me.tlpAEDtl.Controls.Add(Me.btnCancelDtl)
        Me.tlpAEDtl.Controls.Add(Me.btnSaveDtl)
        Me.tlpAEDtl.Controls.Add(Me.btnExit2)
        Me.tlpAEDtl.Controls.Add(Me.btnEdit)
        Me.tlpAEDtl.Controls.Add(Me.plAEDtl)
        Me.tlpAEDtl.Controls.Add(Me.txtActualRatio)
        Me.tlpAEDtl.Controls.Add(Me.txtMarketValue)
        Me.tlpAEDtl.Controls.Add(Me.txtTotalDebit)
        Me.tlpAEDtl.Controls.Add(Me.txtDebitBalF)
        Me.tlpAEDtl.Controls.Add(Me.txtDebitBalS)
        Me.tlpAEDtl.Controls.Add(Me.lblActualRatio)
        Me.tlpAEDtl.Controls.Add(Me.lblMarketValue)
        Me.tlpAEDtl.Controls.Add(Me.lblTotalDebit)
        Me.tlpAEDtl.Controls.Add(Me.lblDebitBalF)
        Me.tlpAEDtl.Controls.Add(Me.lblDebitBalS)
        Me.tlpAEDtl.Controls.Add(Me.txtName)
        Me.tlpAEDtl.Controls.Add(Me.txtAECodeShow)
        Me.tlpAEDtl.Controls.Add(Me.lblRunner)
        Me.tlpAEDtl.Location = New System.Drawing.Point(4, 24)
        Me.tlpAEDtl.Name = "tlpAEDtl"
        Me.tlpAEDtl.Padding = New System.Windows.Forms.Padding(3)
        Me.tlpAEDtl.Size = New System.Drawing.Size(1093, 496)
        Me.tlpAEDtl.TabIndex = 1
        Me.tlpAEDtl.Text = "Runner Detail"
        Me.tlpAEDtl.UseVisualStyleBackColor = True
        '
        'btnCancelDtl
        '
        Me.btnCancelDtl.Enabled = False
        Me.btnCancelDtl.Location = New System.Drawing.Point(839, 321)
        Me.btnCancelDtl.Name = "btnCancelDtl"
        Me.btnCancelDtl.Size = New System.Drawing.Size(75, 23)
        Me.btnCancelDtl.TabIndex = 11
        Me.btnCancelDtl.Text = "Cancel"
        Me.btnCancelDtl.UseVisualStyleBackColor = True
        '
        'btnSaveDtl
        '
        Me.btnSaveDtl.Enabled = False
        Me.btnSaveDtl.Location = New System.Drawing.Point(839, 280)
        Me.btnSaveDtl.Name = "btnSaveDtl"
        Me.btnSaveDtl.Size = New System.Drawing.Size(75, 23)
        Me.btnSaveDtl.TabIndex = 11
        Me.btnSaveDtl.Text = "Save"
        Me.btnSaveDtl.UseVisualStyleBackColor = True
        '
        'btnExit2
        '
        Me.btnExit2.Location = New System.Drawing.Point(839, 423)
        Me.btnExit2.Name = "btnExit2"
        Me.btnExit2.Size = New System.Drawing.Size(75, 23)
        Me.btnExit2.TabIndex = 11
        Me.btnExit2.Text = "Exit"
        Me.btnExit2.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(839, 236)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 23)
        Me.btnEdit.TabIndex = 11
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'plAEDtl
        '
        Me.plAEDtl.Controls.Add(Me.rtxtRemark)
        Me.plAEDtl.Controls.Add(Me.nudTypeB)
        Me.plAEDtl.Controls.Add(Me.nudTypeC)
        Me.plAEDtl.Controls.Add(Me.lblDtlTotal)
        Me.plAEDtl.Controls.Add(Me.lblBType)
        Me.plAEDtl.Controls.Add(Me.lblRemark)
        Me.plAEDtl.Controls.Add(Me.lblCType)
        Me.plAEDtl.Controls.Add(Me.chkSetOff)
        Me.plAEDtl.Controls.Add(Me.lblSetOff)
        Me.plAEDtl.Controls.Add(Me.txtDtlTotal)
        Me.plAEDtl.Controls.Add(Me.lblCRCContrlDtl)
        Me.plAEDtl.Location = New System.Drawing.Point(31, 204)
        Me.plAEDtl.Name = "plAEDtl"
        Me.plAEDtl.Size = New System.Drawing.Size(802, 258)
        Me.plAEDtl.TabIndex = 8
        '
        'rtxtRemark
        '
        Me.rtxtRemark.Enabled = False
        Me.rtxtRemark.Location = New System.Drawing.Point(64, 187)
        Me.rtxtRemark.MaxLength = 100
        Me.rtxtRemark.Name = "rtxtRemark"
        Me.rtxtRemark.Size = New System.Drawing.Size(728, 55)
        Me.rtxtRemark.TabIndex = 6
        Me.rtxtRemark.Text = ""
        '
        'nudTypeB
        '
        Me.nudTypeB.DecimalPlaces = 2
        Me.nudTypeB.Location = New System.Drawing.Point(498, 76)
        Me.nudTypeB.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 131072})
        Me.nudTypeB.Minimum = New Decimal(New Integer() {1410065407, 2, 0, -2147352576})
        Me.nudTypeB.Name = "nudTypeB"
        Me.nudTypeB.ReadOnly = True
        Me.nudTypeB.Size = New System.Drawing.Size(294, 21)
        Me.nudTypeB.TabIndex = 5
        Me.nudTypeB.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudTypeB.ThousandsSeparator = True
        '
        'nudTypeC
        '
        Me.nudTypeC.DecimalPlaces = 2
        Me.nudTypeC.Location = New System.Drawing.Point(498, 32)
        Me.nudTypeC.Maximum = New Decimal(New Integer() {1215752191, 23, 0, 131072})
        Me.nudTypeC.Minimum = New Decimal(New Integer() {1410065407, 2, 0, -2147352576})
        Me.nudTypeC.Name = "nudTypeC"
        Me.nudTypeC.ReadOnly = True
        Me.nudTypeC.Size = New System.Drawing.Size(294, 21)
        Me.nudTypeC.TabIndex = 5
        Me.nudTypeC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudTypeC.ThousandsSeparator = True
        '
        'lblDtlTotal
        '
        Me.lblDtlTotal.AutoSize = True
        Me.lblDtlTotal.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblDtlTotal.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDtlTotal.Location = New System.Drawing.Point(455, 115)
        Me.lblDtlTotal.Name = "lblDtlTotal"
        Me.lblDtlTotal.Size = New System.Drawing.Size(33, 15)
        Me.lblDtlTotal.TabIndex = 3
        Me.lblDtlTotal.Text = "Total"
        '
        'lblBType
        '
        Me.lblBType.AutoSize = True
        Me.lblBType.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblBType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblBType.Location = New System.Drawing.Point(430, 76)
        Me.lblBType.Name = "lblBType"
        Me.lblBType.Size = New System.Drawing.Size(57, 15)
        Me.lblBType.TabIndex = 3
        Me.lblBType.Text = "Deduct B"
        '
        'lblRemark
        '
        Me.lblRemark.AutoSize = True
        Me.lblRemark.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblRemark.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRemark.Location = New System.Drawing.Point(61, 169)
        Me.lblRemark.Name = "lblRemark"
        Me.lblRemark.Size = New System.Drawing.Size(51, 15)
        Me.lblRemark.TabIndex = 3
        Me.lblRemark.Text = "Remark"
        '
        'lblCType
        '
        Me.lblCType.AutoSize = True
        Me.lblCType.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblCType.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblCType.Location = New System.Drawing.Point(430, 32)
        Me.lblCType.Name = "lblCType"
        Me.lblCType.Size = New System.Drawing.Size(58, 15)
        Me.lblCType.TabIndex = 3
        Me.lblCType.Text = "Deduct C"
        '
        'chkSetOff
        '
        Me.chkSetOff.AutoSize = True
        Me.chkSetOff.Checked = True
        Me.chkSetOff.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkSetOff.Enabled = False
        Me.chkSetOff.Location = New System.Drawing.Point(126, 36)
        Me.chkSetOff.Name = "chkSetOff"
        Me.chkSetOff.Size = New System.Drawing.Size(46, 19)
        Me.chkSetOff.TabIndex = 2
        Me.chkSetOff.Text = "Yes"
        Me.chkSetOff.UseVisualStyleBackColor = True
        '
        'lblSetOff
        '
        Me.lblSetOff.AutoSize = True
        Me.lblSetOff.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblSetOff.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblSetOff.Location = New System.Drawing.Point(61, 35)
        Me.lblSetOff.Name = "lblSetOff"
        Me.lblSetOff.Size = New System.Drawing.Size(43, 15)
        Me.lblSetOff.TabIndex = 1
        Me.lblSetOff.Text = "Set Off"
        '
        'txtDtlTotal
        '
        Me.txtDtlTotal.Location = New System.Drawing.Point(498, 116)
        Me.txtDtlTotal.Name = "txtDtlTotal"
        Me.txtDtlTotal.ReadOnly = True
        Me.txtDtlTotal.Size = New System.Drawing.Size(294, 21)
        Me.txtDtlTotal.TabIndex = 4
        Me.txtDtlTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCRCContrlDtl
        '
        Me.lblCRCContrlDtl.AutoSize = True
        Me.lblCRCContrlDtl.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblCRCContrlDtl.ForeColor = System.Drawing.Color.Red
        Me.lblCRCContrlDtl.Location = New System.Drawing.Point(12, 11)
        Me.lblCRCContrlDtl.Name = "lblCRCContrlDtl"
        Me.lblCRCContrlDtl.Size = New System.Drawing.Size(77, 15)
        Me.lblCRCContrlDtl.TabIndex = 0
        Me.lblCRCContrlDtl.Text = "CRC Control"
        '
        'txtActualRatio
        '
        Me.txtActualRatio.Location = New System.Drawing.Point(529, 116)
        Me.txtActualRatio.Name = "txtActualRatio"
        Me.txtActualRatio.ReadOnly = True
        Me.txtActualRatio.Size = New System.Drawing.Size(294, 21)
        Me.txtActualRatio.TabIndex = 4
        Me.txtActualRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMarketValue
        '
        Me.txtMarketValue.Location = New System.Drawing.Point(529, 75)
        Me.txtMarketValue.Name = "txtMarketValue"
        Me.txtMarketValue.ReadOnly = True
        Me.txtMarketValue.Size = New System.Drawing.Size(294, 21)
        Me.txtMarketValue.TabIndex = 4
        Me.txtMarketValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtTotalDebit
        '
        Me.txtTotalDebit.Location = New System.Drawing.Point(122, 157)
        Me.txtTotalDebit.Name = "txtTotalDebit"
        Me.txtTotalDebit.ReadOnly = True
        Me.txtTotalDebit.Size = New System.Drawing.Size(279, 21)
        Me.txtTotalDebit.TabIndex = 4
        Me.txtTotalDebit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebitBalF
        '
        Me.txtDebitBalF.Location = New System.Drawing.Point(122, 116)
        Me.txtDebitBalF.Name = "txtDebitBalF"
        Me.txtDebitBalF.ReadOnly = True
        Me.txtDebitBalF.Size = New System.Drawing.Size(279, 21)
        Me.txtDebitBalF.TabIndex = 4
        Me.txtDebitBalF.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtDebitBalS
        '
        Me.txtDebitBalS.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtDebitBalS.Location = New System.Drawing.Point(122, 75)
        Me.txtDebitBalS.Name = "txtDebitBalS"
        Me.txtDebitBalS.ReadOnly = True
        Me.txtDebitBalS.Size = New System.Drawing.Size(279, 21)
        Me.txtDebitBalS.TabIndex = 4
        Me.txtDebitBalS.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblActualRatio
        '
        Me.lblActualRatio.AutoSize = True
        Me.lblActualRatio.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblActualRatio.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblActualRatio.Location = New System.Drawing.Point(446, 119)
        Me.lblActualRatio.Name = "lblActualRatio"
        Me.lblActualRatio.Size = New System.Drawing.Size(72, 15)
        Me.lblActualRatio.TabIndex = 3
        Me.lblActualRatio.Text = "Actual Ratio"
        '
        'lblMarketValue
        '
        Me.lblMarketValue.AutoSize = True
        Me.lblMarketValue.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblMarketValue.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblMarketValue.Location = New System.Drawing.Point(442, 78)
        Me.lblMarketValue.Name = "lblMarketValue"
        Me.lblMarketValue.Size = New System.Drawing.Size(76, 15)
        Me.lblMarketValue.TabIndex = 3
        Me.lblMarketValue.Text = "Market Value"
        '
        'lblTotalDebit
        '
        Me.lblTotalDebit.AutoSize = True
        Me.lblTotalDebit.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblTotalDebit.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblTotalDebit.Location = New System.Drawing.Point(30, 160)
        Me.lblTotalDebit.Name = "lblTotalDebit"
        Me.lblTotalDebit.Size = New System.Drawing.Size(86, 15)
        Me.lblTotalDebit.TabIndex = 3
        Me.lblTotalDebit.Text = "Total Debit Bal"
        '
        'lblDebitBalF
        '
        Me.lblDebitBalF.AutoSize = True
        Me.lblDebitBalF.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblDebitBalF.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDebitBalF.Location = New System.Drawing.Point(28, 119)
        Me.lblDebitBalF.Name = "lblDebitBalF"
        Me.lblDebitBalF.Size = New System.Drawing.Size(88, 15)
        Me.lblDebitBalF.TabIndex = 3
        Me.lblDebitBalF.Text = "Debit Bal（F）"
        '
        'lblDebitBalS
        '
        Me.lblDebitBalS.AutoSize = True
        Me.lblDebitBalS.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblDebitBalS.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblDebitBalS.Location = New System.Drawing.Point(28, 78)
        Me.lblDebitBalS.Name = "lblDebitBalS"
        Me.lblDebitBalS.Size = New System.Drawing.Size(89, 15)
        Me.lblDebitBalS.TabIndex = 3
        Me.lblDebitBalS.Text = "Debit Bal（S）"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(301, 34)
        Me.txtName.Name = "txtName"
        Me.txtName.ReadOnly = True
        Me.txtName.Size = New System.Drawing.Size(522, 21)
        Me.txtName.TabIndex = 2
        '
        'txtAECodeShow
        '
        Me.txtAECodeShow.Location = New System.Drawing.Point(122, 34)
        Me.txtAECodeShow.Name = "txtAECodeShow"
        Me.txtAECodeShow.ReadOnly = True
        Me.txtAECodeShow.Size = New System.Drawing.Size(111, 21)
        Me.txtAECodeShow.TabIndex = 1
        '
        'lblRunner
        '
        Me.lblRunner.AutoSize = True
        Me.lblRunner.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblRunner.ForeColor = System.Drawing.SystemColors.WindowText
        Me.lblRunner.Location = New System.Drawing.Point(28, 37)
        Me.lblRunner.Name = "lblRunner"
        Me.lblRunner.Size = New System.Drawing.Size(48, 15)
        Me.lblRunner.TabIndex = 0
        Me.lblRunner.Text = "Runner"
        '
        'tlpPrint
        '
        Me.tlpPrint.Controls.Add(Me.btnExit_print)
        Me.tlpPrint.Controls.Add(Me.btnPrint)
        Me.tlpPrint.Controls.Add(Me.lblPrintRange)
        Me.tlpPrint.Controls.Add(Me.gbxPrintRange)
        Me.tlpPrint.ForeColor = System.Drawing.SystemColors.WindowText
        Me.tlpPrint.Location = New System.Drawing.Point(4, 24)
        Me.tlpPrint.Name = "tlpPrint"
        Me.tlpPrint.Padding = New System.Windows.Forms.Padding(3)
        Me.tlpPrint.Size = New System.Drawing.Size(1093, 496)
        Me.tlpPrint.TabIndex = 2
        Me.tlpPrint.Text = "Print"
        Me.tlpPrint.UseVisualStyleBackColor = True
        '
        'btnExit_print
        '
        Me.btnExit_print.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit_print.Location = New System.Drawing.Point(850, 430)
        Me.btnExit_print.Name = "btnExit_print"
        Me.btnExit_print.Size = New System.Drawing.Size(75, 23)
        Me.btnExit_print.TabIndex = 0
        Me.btnExit_print.Text = "Exit"
        Me.btnExit_print.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnPrint.Location = New System.Drawing.Point(458, 362)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 23)
        Me.btnPrint.TabIndex = 0
        Me.btnPrint.Text = "Print"
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'lblPrintRange
        '
        Me.lblPrintRange.AutoSize = True
        Me.lblPrintRange.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.lblPrintRange.Location = New System.Drawing.Point(60, 130)
        Me.lblPrintRange.Name = "lblPrintRange"
        Me.lblPrintRange.Size = New System.Drawing.Size(87, 15)
        Me.lblPrintRange.TabIndex = 1
        Me.lblPrintRange.Text = "Record Range"
        '
        'gbxPrintRange
        '
        Me.gbxPrintRange.Controls.Add(Me.cbxPrintRange_Addition)
        Me.gbxPrintRange.Controls.Add(Me.cbbPrintRange_CodeTo)
        Me.gbxPrintRange.Controls.Add(Me.Label1)
        Me.gbxPrintRange.Controls.Add(Me.cbbPrintRange_CodeFrom)
        Me.gbxPrintRange.Controls.Add(Me.rbPrintRange_RunnerCode)
        Me.gbxPrintRange.Controls.Add(Me.rbPrintRange_All)
        Me.gbxPrintRange.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.gbxPrintRange.Location = New System.Drawing.Point(158, 121)
        Me.gbxPrintRange.Name = "gbxPrintRange"
        Me.gbxPrintRange.Size = New System.Drawing.Size(683, 215)
        Me.gbxPrintRange.TabIndex = 0
        Me.gbxPrintRange.TabStop = False
        Me.gbxPrintRange.Text = "Record Option"
        '
        'cbxPrintRange_Addition
        '
        Me.cbxPrintRange_Addition.AutoSize = True
        Me.cbxPrintRange_Addition.Checked = True
        Me.cbxPrintRange_Addition.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbxPrintRange_Addition.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.cbxPrintRange_Addition.Location = New System.Drawing.Point(37, 141)
        Me.cbxPrintRange_Addition.Name = "cbxPrintRange_Addition"
        Me.cbxPrintRange_Addition.Size = New System.Drawing.Size(211, 19)
        Me.cbxPrintRange_Addition.TabIndex = 4
        Me.cbxPrintRange_Addition.Text = "Deduct B > 0 or Deduct C > 0 Only"
        Me.cbxPrintRange_Addition.UseVisualStyleBackColor = True
        '
        'cbbPrintRange_CodeTo
        '
        Me.cbbPrintRange_CodeTo.FormattingEnabled = True
        Me.cbbPrintRange_CodeTo.Location = New System.Drawing.Point(371, 71)
        Me.cbbPrintRange_CodeTo.Name = "cbbPrintRange_CodeTo"
        Me.cbbPrintRange_CodeTo.Size = New System.Drawing.Size(121, 23)
        Me.cbbPrintRange_CodeTo.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(314, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 15)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "To"
        '
        'cbbPrintRange_CodeFrom
        '
        Me.cbbPrintRange_CodeFrom.FormattingEnabled = True
        Me.cbbPrintRange_CodeFrom.Location = New System.Drawing.Point(160, 71)
        Me.cbbPrintRange_CodeFrom.Name = "cbbPrintRange_CodeFrom"
        Me.cbbPrintRange_CodeFrom.Size = New System.Drawing.Size(121, 23)
        Me.cbbPrintRange_CodeFrom.TabIndex = 2
        '
        'rbPrintRange_RunnerCode
        '
        Me.rbPrintRange_RunnerCode.AutoSize = True
        Me.rbPrintRange_RunnerCode.Location = New System.Drawing.Point(37, 73)
        Me.rbPrintRange_RunnerCode.Name = "rbPrintRange_RunnerCode"
        Me.rbPrintRange_RunnerCode.Size = New System.Drawing.Size(99, 19)
        Me.rbPrintRange_RunnerCode.TabIndex = 1
        Me.rbPrintRange_RunnerCode.Text = "Runner Code"
        Me.rbPrintRange_RunnerCode.UseVisualStyleBackColor = True
        '
        'rbPrintRange_All
        '
        Me.rbPrintRange_All.AutoSize = True
        Me.rbPrintRange_All.Location = New System.Drawing.Point(37, 38)
        Me.rbPrintRange_All.Name = "rbPrintRange_All"
        Me.rbPrintRange_All.Size = New System.Drawing.Size(38, 19)
        Me.rbPrintRange_All.TabIndex = 0
        Me.rbPrintRange_All.Text = "All"
        Me.rbPrintRange_All.UseVisualStyleBackColor = True
        '
        'frmCRCDebitBalance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(1124, 548)
        Me.Controls.Add(Me.tabCRCBAD)
        Me.KeyPreview = True
        Me.Name = "frmCRCDebitBalance"
        Me.Text = "CRC Debit Balance Account Detail"
        Me.Controls.SetChildIndex(Me.tabCRCBAD, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.tabCRCBAD.ResumeLayout(False)
        Me.tlpAEListing.ResumeLayout(False)
        Me.tlpAEListing.PerformLayout()
        CType(Me.dgvTotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvAEListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpAEDtl.ResumeLayout(False)
        Me.tlpAEDtl.PerformLayout()
        Me.plAEDtl.ResumeLayout(False)
        Me.plAEDtl.PerformLayout()
        CType(Me.nudTypeB, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudTypeC, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpPrint.ResumeLayout(False)
        Me.tlpPrint.PerformLayout()
        Me.gbxPrintRange.ResumeLayout(False)
        Me.gbxPrintRange.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabCRCBAD As System.Windows.Forms.TabControl
    Friend WithEvents tlpAEListing As System.Windows.Forms.TabPage
    Friend WithEvents tlpAEDtl As System.Windows.Forms.TabPage
    Friend WithEvents dgvAEListing As System.Windows.Forms.DataGridView
    Friend WithEvents btnReset As ESL.myButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAECode As System.Windows.Forms.TextBox
    Friend WithEvents tlpPrint As System.Windows.Forms.TabPage
    Friend WithEvents dgvTotal As System.Windows.Forms.DataGridView
    Friend WithEvents lblRunner As System.Windows.Forms.Label
    Friend WithEvents txtName As System.Windows.Forms.TextBox
    Friend WithEvents txtAECodeShow As System.Windows.Forms.TextBox
    Friend WithEvents lblDebitBalS As System.Windows.Forms.Label
    Friend WithEvents txtDebitBalS As System.Windows.Forms.TextBox
    Friend WithEvents txtMarketValue As System.Windows.Forms.TextBox
    Friend WithEvents lblMarketValue As System.Windows.Forms.Label
    Friend WithEvents txtActualRatio As System.Windows.Forms.TextBox
    Friend WithEvents txtDebitBalF As System.Windows.Forms.TextBox
    Friend WithEvents lblActualRatio As System.Windows.Forms.Label
    Friend WithEvents lblDebitBalF As System.Windows.Forms.Label
    Friend WithEvents txtTotalDebit As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalDebit As System.Windows.Forms.Label
    Friend WithEvents plAEDtl As System.Windows.Forms.Panel
    Friend WithEvents gbxPrintRange As System.Windows.Forms.GroupBox
    Friend WithEvents lblPrintRange As System.Windows.Forms.Label
    Friend WithEvents rbPrintRange_RunnerCode As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrintRange_All As System.Windows.Forms.RadioButton
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents cbbPrintRange_CodeTo As System.Windows.Forms.ComboBox
    Friend WithEvents cbbPrintRange_CodeFrom As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxPrintRange_Addition As System.Windows.Forms.CheckBox
    Friend WithEvents btnCancelDtl As ESL.myButton
    Friend WithEvents btnSaveDtl As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents lblCRCContrlDtl As System.Windows.Forms.Label
    Friend WithEvents chkSetOff As System.Windows.Forms.CheckBox
    Friend WithEvents lblSetOff As System.Windows.Forms.Label
    Friend WithEvents lblCType As System.Windows.Forms.Label
    Friend WithEvents lblBType As System.Windows.Forms.Label
    Friend WithEvents lblDtlTotal As System.Windows.Forms.Label
    Friend WithEvents lblRemark As System.Windows.Forms.Label
    Friend WithEvents txtDtlTotal As System.Windows.Forms.TextBox
    Friend WithEvents nudTypeC As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudTypeB As System.Windows.Forms.NumericUpDown
    Friend WithEvents rtxtRemark As System.Windows.Forms.RichTextBox
    Friend WithEvents btnExit As ESL.myButton
    Friend WithEvents btnExit2 As ESL.myButton
    Friend WithEvents btnExit_print As System.Windows.Forms.Button
    Friend WithEvents space1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ttl As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dr_str_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mv_str_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents actr_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_dr_bal_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dd_c_str_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dd_b_str_total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents space2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents run_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dr_str As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mv_str As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents actr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents f_dr_bal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dd_c_str As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dd_b_str As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents seto As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mv As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fdr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents remarks As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents b_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents c_type As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
