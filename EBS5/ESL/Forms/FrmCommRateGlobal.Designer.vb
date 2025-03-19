<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommRateGlobal
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
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle17 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle18 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle19 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle20 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle21 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtgGlobalRate = New System.Windows.Forms.DataGridView
        Me.txmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.comm_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minNorAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minNorRate_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.commNorRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minIntAmt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minIntRate_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.commIntRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minFNorBrkRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minFIntBrkRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.commNorRate_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minONorBrkRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.minOIntBrkRate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.commIntRate_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ComboSrchYear = New ESL.myComboBox(Me.components)
        Me.rbSrchAcc = New ESL.myRadioButton(Me.components)
        Me.rbSrchAcGP = New ESL.myRadioButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBoxSrchType = New System.Windows.Forms.GroupBox
        Me.rbSrchMan = New ESL.myRadioButton(Me.components)
        Me.rbSrchAE = New ESL.myRadioButton(Me.components)
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.GroupBoxSec = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtMinNorAmt = New ESL.myNumericBox
        Me.lblCommIntRate = New System.Windows.Forms.Label
        Me.lblcommNorRate = New System.Windows.Forms.Label
        Me.lblminIntRate_s = New System.Windows.Forms.Label
        Me.txtminIntRate_s = New ESL.myNumericBox
        Me.lblMinNorRate_s = New System.Windows.Forms.Label
        Me.lblMinIntAmt = New System.Windows.Forms.Label
        Me.txtCommIntRate = New ESL.myNumericBox
        Me.lblMinNorAmt = New System.Windows.Forms.Label
        Me.txtMinIntAmt = New ESL.myNumericBox
        Me.txtcommNorRate = New ESL.myNumericBox
        Me.txtMinNorRate_s = New ESL.myNumericBox
        Me.GroupBoxFut = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtMinOIntBrkRate = New ESL.myNumericBox
        Me.txtcommIntRate_f = New ESL.myNumericBox
        Me.txtCommNorRate_f = New ESL.myNumericBox
        Me.txtMinONorBrkRate = New ESL.myNumericBox
        Me.txtMinFIntBrkRate = New ESL.myNumericBox
        Me.txtminFNorBrkRate = New ESL.myNumericBox
        Me.lblcommIntRate_f = New System.Windows.Forms.Label
        Me.lblCommNorRate_f = New System.Windows.Forms.Label
        Me.lblMinOIntBrkRate = New System.Windows.Forms.Label
        Me.lblMinFIntBrkRate = New System.Windows.Forms.Label
        Me.lblMinONorBrkRate = New System.Windows.Forms.Label
        Me.lblminFNorBrkRate = New System.Windows.Forms.Label
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.rbMan = New ESL.myRadioButton(Me.components)
        Me.rbAE = New ESL.myRadioButton(Me.components)
        Me.rbAGRP = New ESL.myRadioButton(Me.components)
        Me.rbACC = New ESL.myRadioButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.comboYear = New ESL.myComboBox(Me.components)
        Me.Label16 = New System.Windows.Forms.Label
        Me.comboMonth = New ESL.myComboBox(Me.components)
        Me.lblTitle = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.comboSrchMonth = New ESL.myComboBox(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        CType(Me.dtgGlobalRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBoxSrchType.SuspendLayout()
        Me.GroupBoxSec.SuspendLayout()
        Me.GroupBoxFut.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(698, 494)
        Me.btnCancel.TabIndex = 13
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(647, 494)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Visible = True
        '
        'dtgGlobalRate
        '
        Me.dtgGlobalRate.AllowUserToAddRows = False
        Me.dtgGlobalRate.AllowUserToDeleteRows = False
        Me.dtgGlobalRate.AllowUserToResizeRows = False
        Me.dtgGlobalRate.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgGlobalRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgGlobalRate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txmonth, Me.comm_type, Me.minNorAmt, Me.minNorRate_s, Me.commNorRate, Me.minIntAmt, Me.minIntRate_s, Me.commIntRate, Me.minFNorBrkRate, Me.minFIntBrkRate, Me.commNorRate_f, Me.minONorBrkRate, Me.minOIntBrkRate, Me.commIntRate_f})
        Me.dtgGlobalRate.Location = New System.Drawing.Point(3, 1)
        Me.dtgGlobalRate.MultiSelect = False
        Me.dtgGlobalRate.Name = "dtgGlobalRate"
        Me.dtgGlobalRate.ReadOnly = True
        Me.dtgGlobalRate.RowHeadersVisible = False
        Me.dtgGlobalRate.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgGlobalRate.RowTemplate.Height = 24
        Me.dtgGlobalRate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgGlobalRate.Size = New System.Drawing.Size(749, 192)
        Me.dtgGlobalRate.TabIndex = 3
        '
        'txmonth
        '
        Me.txmonth.DataPropertyName = "txmonth"
        Me.txmonth.HeaderText = "Month"
        Me.txmonth.Name = "txmonth"
        Me.txmonth.ReadOnly = True
        Me.txmonth.Width = 60
        '
        'comm_type
        '
        Me.comm_type.DataPropertyName = "comm_type"
        Me.comm_type.HeaderText = "Type"
        Me.comm_type.Name = "comm_type"
        Me.comm_type.ReadOnly = True
        Me.comm_type.Width = 70
        '
        'minNorAmt
        '
        Me.minNorAmt.DataPropertyName = "minNorAmt"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.minNorAmt.DefaultCellStyle = DataGridViewCellStyle13
        Me.minNorAmt.HeaderText = "Min. Normal Amount (Securities)"
        Me.minNorAmt.Name = "minNorAmt"
        Me.minNorAmt.ReadOnly = True
        '
        'minNorRate_s
        '
        Me.minNorRate_s.DataPropertyName = "minNorRate_s"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.minNorRate_s.DefaultCellStyle = DataGridViewCellStyle14
        Me.minNorRate_s.HeaderText = "Min Normal Comm. Recd Rate (Securities)"
        Me.minNorRate_s.Name = "minNorRate_s"
        Me.minNorRate_s.ReadOnly = True
        '
        'commNorRate
        '
        Me.commNorRate.DataPropertyName = "commNorRate"
        DataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.commNorRate.DefaultCellStyle = DataGridViewCellStyle15
        Me.commNorRate.HeaderText = "Min. Normal Turnover Rate (Securities)"
        Me.commNorRate.Name = "commNorRate"
        Me.commNorRate.ReadOnly = True
        '
        'minIntAmt
        '
        Me.minIntAmt.DataPropertyName = "minIntAmt"
        DataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.minIntAmt.DefaultCellStyle = DataGridViewCellStyle16
        Me.minIntAmt.HeaderText = "Min Internet Amount (Securities)"
        Me.minIntAmt.Name = "minIntAmt"
        Me.minIntAmt.ReadOnly = True
        '
        'minIntRate_s
        '
        Me.minIntRate_s.DataPropertyName = "minIntRate_s"
        DataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.minIntRate_s.DefaultCellStyle = DataGridViewCellStyle17
        Me.minIntRate_s.HeaderText = "Min Internet Comm. Recd Rate (Securities)"
        Me.minIntRate_s.Name = "minIntRate_s"
        Me.minIntRate_s.ReadOnly = True
        '
        'commIntRate
        '
        Me.commIntRate.DataPropertyName = "commIntRate"
        DataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.commIntRate.DefaultCellStyle = DataGridViewCellStyle18
        Me.commIntRate.HeaderText = "Min. Internet Turnover Rate (Securities)"
        Me.commIntRate.Name = "commIntRate"
        Me.commIntRate.ReadOnly = True
        '
        'minFNorBrkRate
        '
        Me.minFNorBrkRate.DataPropertyName = "minFNorBrkRate"
        DataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.minFNorBrkRate.DefaultCellStyle = DataGridViewCellStyle19
        Me.minFNorBrkRate.HeaderText = "Min Futures Normal Brokerage Rate"
        Me.minFNorBrkRate.Name = "minFNorBrkRate"
        Me.minFNorBrkRate.ReadOnly = True
        Me.minFNorBrkRate.Visible = False
        '
        'minFIntBrkRate
        '
        Me.minFIntBrkRate.DataPropertyName = "minFIntBrkRate"
        DataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.minFIntBrkRate.DefaultCellStyle = DataGridViewCellStyle20
        Me.minFIntBrkRate.HeaderText = "Min Fut. Internet Brokerage Rate"
        Me.minFIntBrkRate.Name = "minFIntBrkRate"
        Me.minFIntBrkRate.ReadOnly = True
        Me.minFIntBrkRate.Visible = False
        '
        'commNorRate_f
        '
        Me.commNorRate_f.DataPropertyName = "commNorRate_f"
        DataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.commNorRate_f.DefaultCellStyle = DataGridViewCellStyle21
        Me.commNorRate_f.HeaderText = "Comm Normal Rate (Futures)"
        Me.commNorRate_f.Name = "commNorRate_f"
        Me.commNorRate_f.ReadOnly = True
        '
        'minONorBrkRate
        '
        Me.minONorBrkRate.DataPropertyName = "minONorBrkRate"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.minONorBrkRate.DefaultCellStyle = DataGridViewCellStyle22
        Me.minONorBrkRate.HeaderText = "Min Opt Normal Brokerage Rate"
        Me.minONorBrkRate.Name = "minONorBrkRate"
        Me.minONorBrkRate.ReadOnly = True
        Me.minONorBrkRate.Visible = False
        '
        'minOIntBrkRate
        '
        Me.minOIntBrkRate.DataPropertyName = "minOIntBrkRate"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.minOIntBrkRate.DefaultCellStyle = DataGridViewCellStyle23
        Me.minOIntBrkRate.HeaderText = "Min Opt Internet Brokerage Rate"
        Me.minOIntBrkRate.Name = "minOIntBrkRate"
        Me.minOIntBrkRate.ReadOnly = True
        Me.minOIntBrkRate.Visible = False
        '
        'commIntRate_f
        '
        Me.commIntRate_f.DataPropertyName = "commIntRate_f"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.commIntRate_f.DefaultCellStyle = DataGridViewCellStyle24
        Me.commIntRate_f.HeaderText = "Comm Internet Rate (Futures)"
        Me.commIntRate_f.Name = "commIntRate_f"
        Me.commIntRate_f.ReadOnly = True
        '
        'ComboSrchYear
        '
        Me.ComboSrchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboSrchYear.FormattingEnabled = True
        Me.ComboSrchYear.Location = New System.Drawing.Point(45, 43)
        Me.ComboSrchYear.Name = "ComboSrchYear"
        Me.ComboSrchYear.Size = New System.Drawing.Size(62, 23)
        Me.ComboSrchYear.TabIndex = 0
        '
        'rbSrchAcc
        '
        Me.rbSrchAcc.AutoSize = True
        Me.rbSrchAcc.Location = New System.Drawing.Point(6, 11)
        Me.rbSrchAcc.Name = "rbSrchAcc"
        Me.rbSrchAcc.Size = New System.Drawing.Size(68, 19)
        Me.rbSrchAcc.TabIndex = 0
        Me.rbSrchAcc.Text = "Account"
        Me.rbSrchAcc.UseVisualStyleBackColor = True
        '
        'rbSrchAcGP
        '
        Me.rbSrchAcGP.AutoSize = True
        Me.rbSrchAcGP.Location = New System.Drawing.Point(126, 10)
        Me.rbSrchAcGP.Name = "rbSrchAcGP"
        Me.rbSrchAcGP.Size = New System.Drawing.Size(81, 19)
        Me.rbSrchAcGP.TabIndex = 1
        Me.rbSrchAcGP.Text = "A/C Group"
        Me.rbSrchAcGP.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(7, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 15)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Year"
        '
        'GroupBoxSrchType
        '
        Me.GroupBoxSrchType.Controls.Add(Me.rbSrchMan)
        Me.GroupBoxSrchType.Controls.Add(Me.rbSrchAE)
        Me.GroupBoxSrchType.Controls.Add(Me.rbSrchAll)
        Me.GroupBoxSrchType.Controls.Add(Me.rbSrchAcGP)
        Me.GroupBoxSrchType.Controls.Add(Me.rbSrchAcc)
        Me.GroupBoxSrchType.Location = New System.Drawing.Point(220, 34)
        Me.GroupBoxSrchType.Name = "GroupBoxSrchType"
        Me.GroupBoxSrchType.Size = New System.Drawing.Size(332, 32)
        Me.GroupBoxSrchType.TabIndex = 1
        Me.GroupBoxSrchType.TabStop = False
        '
        'rbSrchMan
        '
        Me.rbSrchMan.AutoSize = True
        Me.rbSrchMan.Location = New System.Drawing.Point(213, 10)
        Me.rbSrchMan.Name = "rbSrchMan"
        Me.rbSrchMan.Size = New System.Drawing.Size(73, 19)
        Me.rbSrchMan.TabIndex = 4
        Me.rbSrchMan.Text = "Manager"
        Me.rbSrchMan.UseVisualStyleBackColor = True
        '
        'rbSrchAE
        '
        Me.rbSrchAE.AutoSize = True
        Me.rbSrchAE.Location = New System.Drawing.Point(80, 11)
        Me.rbSrchAE.Name = "rbSrchAE"
        Me.rbSrchAE.Size = New System.Drawing.Size(40, 19)
        Me.rbSrchAE.TabIndex = 3
        Me.rbSrchAE.Text = "AE"
        Me.rbSrchAE.UseVisualStyleBackColor = True
        '
        'rbSrchAll
        '
        Me.rbSrchAll.AutoSize = True
        Me.rbSrchAll.Checked = True
        Me.rbSrchAll.Location = New System.Drawing.Point(292, 11)
        Me.rbSrchAll.Name = "rbSrchAll"
        Me.rbSrchAll.Size = New System.Drawing.Size(38, 19)
        Me.rbSrchAll.TabIndex = 2
        Me.rbSrchAll.TabStop = True
        Me.rbSrchAll.Text = "All"
        Me.rbSrchAll.UseVisualStyleBackColor = True
        '
        'GroupBoxSec
        '
        Me.GroupBoxSec.Controls.Add(Me.Label6)
        Me.GroupBoxSec.Controls.Add(Me.Label5)
        Me.GroupBoxSec.Controls.Add(Me.Label4)
        Me.GroupBoxSec.Controls.Add(Me.Label3)
        Me.GroupBoxSec.Controls.Add(Me.txtMinNorAmt)
        Me.GroupBoxSec.Controls.Add(Me.lblCommIntRate)
        Me.GroupBoxSec.Controls.Add(Me.lblcommNorRate)
        Me.GroupBoxSec.Controls.Add(Me.lblminIntRate_s)
        Me.GroupBoxSec.Controls.Add(Me.txtminIntRate_s)
        Me.GroupBoxSec.Controls.Add(Me.lblMinNorRate_s)
        Me.GroupBoxSec.Controls.Add(Me.lblMinIntAmt)
        Me.GroupBoxSec.Controls.Add(Me.txtCommIntRate)
        Me.GroupBoxSec.Controls.Add(Me.lblMinNorAmt)
        Me.GroupBoxSec.Controls.Add(Me.txtMinIntAmt)
        Me.GroupBoxSec.Controls.Add(Me.txtcommNorRate)
        Me.GroupBoxSec.Controls.Add(Me.txtMinNorRate_s)
        Me.GroupBoxSec.Location = New System.Drawing.Point(4, 294)
        Me.GroupBoxSec.Name = "GroupBoxSec"
        Me.GroupBoxSec.Size = New System.Drawing.Size(748, 97)
        Me.GroupBoxSec.TabIndex = 7
        Me.GroupBoxSec.TabStop = False
        Me.GroupBoxSec.Text = "Securities"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(593, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(18, 15)
        Me.Label6.TabIndex = 30
        Me.Label6.Text = "%"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(340, 72)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 15)
        Me.Label5.TabIndex = 29
        Me.Label5.Text = "%"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(593, 35)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(18, 15)
        Me.Label4.TabIndex = 28
        Me.Label4.Text = "%"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(340, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(18, 15)
        Me.Label3.TabIndex = 27
        Me.Label3.Text = "%"
        '
        'txtMinNorAmt
        '
        Me.txtMinNorAmt.Location = New System.Drawing.Point(10, 32)
        Me.txtMinNorAmt.Name = "txtMinNorAmt"
        Me.txtMinNorAmt.Size = New System.Drawing.Size(100, 21)
        Me.txtMinNorAmt.TabIndex = 0
        Me.txtMinNorAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblCommIntRate
        '
        Me.lblCommIntRate.AutoSize = True
        Me.lblCommIntRate.Location = New System.Drawing.Point(484, 54)
        Me.lblCommIntRate.Name = "lblCommIntRate"
        Me.lblCommIntRate.Size = New System.Drawing.Size(153, 15)
        Me.lblCommIntRate.TabIndex = 5
        Me.lblCommIntRate.Text = "Min. Internet Turnover Rate"
        '
        'lblcommNorRate
        '
        Me.lblcommNorRate.AutoSize = True
        Me.lblcommNorRate.Location = New System.Drawing.Point(484, 17)
        Me.lblcommNorRate.Name = "lblcommNorRate"
        Me.lblcommNorRate.Size = New System.Drawing.Size(153, 15)
        Me.lblcommNorRate.TabIndex = 4
        Me.lblcommNorRate.Text = "Min. Normal Turnover Rate"
        '
        'lblminIntRate_s
        '
        Me.lblminIntRate_s.AutoSize = True
        Me.lblminIntRate_s.Location = New System.Drawing.Point(233, 54)
        Me.lblminIntRate_s.Name = "lblminIntRate_s"
        Me.lblminIntRate_s.Size = New System.Drawing.Size(178, 15)
        Me.lblminIntRate_s.TabIndex = 3
        Me.lblminIntRate_s.Text = "Min. Internet Comm. Recd Rate"
        '
        'txtminIntRate_s
        '
        Me.txtminIntRate_s.Location = New System.Drawing.Point(234, 69)
        Me.txtminIntRate_s.Name = "txtminIntRate_s"
        Me.txtminIntRate_s.Size = New System.Drawing.Size(100, 21)
        Me.txtminIntRate_s.TabIndex = 4
        Me.txtminIntRate_s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMinNorRate_s
        '
        Me.lblMinNorRate_s.AutoSize = True
        Me.lblMinNorRate_s.Location = New System.Drawing.Point(233, 17)
        Me.lblMinNorRate_s.Name = "lblMinNorRate_s"
        Me.lblMinNorRate_s.Size = New System.Drawing.Size(178, 15)
        Me.lblMinNorRate_s.TabIndex = 2
        Me.lblMinNorRate_s.Text = "Min. Normal Comm. Recd Rate"
        '
        'lblMinIntAmt
        '
        Me.lblMinIntAmt.AutoSize = True
        Me.lblMinIntAmt.Location = New System.Drawing.Point(6, 54)
        Me.lblMinIntAmt.Name = "lblMinIntAmt"
        Me.lblMinIntAmt.Size = New System.Drawing.Size(118, 15)
        Me.lblMinIntAmt.TabIndex = 1
        Me.lblMinIntAmt.Text = "Min. Internet Amount"
        '
        'txtCommIntRate
        '
        Me.txtCommIntRate.Location = New System.Drawing.Point(487, 69)
        Me.txtCommIntRate.Name = "txtCommIntRate"
        Me.txtCommIntRate.Size = New System.Drawing.Size(100, 21)
        Me.txtCommIntRate.TabIndex = 5
        Me.txtCommIntRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblMinNorAmt
        '
        Me.lblMinNorAmt.AutoSize = True
        Me.lblMinNorAmt.Location = New System.Drawing.Point(6, 17)
        Me.lblMinNorAmt.Name = "lblMinNorAmt"
        Me.lblMinNorAmt.Size = New System.Drawing.Size(118, 15)
        Me.lblMinNorAmt.TabIndex = 0
        Me.lblMinNorAmt.Text = "Min. Normal Amount"
        '
        'txtMinIntAmt
        '
        Me.txtMinIntAmt.Location = New System.Drawing.Point(9, 69)
        Me.txtMinIntAmt.Name = "txtMinIntAmt"
        Me.txtMinIntAmt.Size = New System.Drawing.Size(100, 21)
        Me.txtMinIntAmt.TabIndex = 3
        Me.txtMinIntAmt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcommNorRate
        '
        Me.txtcommNorRate.Location = New System.Drawing.Point(487, 32)
        Me.txtcommNorRate.Name = "txtcommNorRate"
        Me.txtcommNorRate.Size = New System.Drawing.Size(100, 21)
        Me.txtcommNorRate.TabIndex = 2
        Me.txtcommNorRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinNorRate_s
        '
        Me.txtMinNorRate_s.Location = New System.Drawing.Point(234, 32)
        Me.txtMinNorRate_s.Name = "txtMinNorRate_s"
        Me.txtMinNorRate_s.Size = New System.Drawing.Size(100, 21)
        Me.txtMinNorRate_s.TabIndex = 1
        Me.txtMinNorRate_s.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'GroupBoxFut
        '
        Me.GroupBoxFut.Controls.Add(Me.Label12)
        Me.GroupBoxFut.Controls.Add(Me.Label11)
        Me.GroupBoxFut.Controls.Add(Me.Label10)
        Me.GroupBoxFut.Controls.Add(Me.Label9)
        Me.GroupBoxFut.Controls.Add(Me.Label8)
        Me.GroupBoxFut.Controls.Add(Me.Label7)
        Me.GroupBoxFut.Controls.Add(Me.txtMinOIntBrkRate)
        Me.GroupBoxFut.Controls.Add(Me.txtcommIntRate_f)
        Me.GroupBoxFut.Controls.Add(Me.txtCommNorRate_f)
        Me.GroupBoxFut.Controls.Add(Me.txtMinONorBrkRate)
        Me.GroupBoxFut.Controls.Add(Me.txtMinFIntBrkRate)
        Me.GroupBoxFut.Controls.Add(Me.txtminFNorBrkRate)
        Me.GroupBoxFut.Controls.Add(Me.lblcommIntRate_f)
        Me.GroupBoxFut.Controls.Add(Me.lblCommNorRate_f)
        Me.GroupBoxFut.Controls.Add(Me.lblMinOIntBrkRate)
        Me.GroupBoxFut.Controls.Add(Me.lblMinFIntBrkRate)
        Me.GroupBoxFut.Controls.Add(Me.lblMinONorBrkRate)
        Me.GroupBoxFut.Controls.Add(Me.lblminFNorBrkRate)
        Me.GroupBoxFut.Location = New System.Drawing.Point(4, 393)
        Me.GroupBoxFut.Name = "GroupBoxFut"
        Me.GroupBoxFut.Size = New System.Drawing.Size(749, 97)
        Me.GroupBoxFut.TabIndex = 8
        Me.GroupBoxFut.TabStop = False
        Me.GroupBoxFut.Text = "Futures and Options"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(594, 73)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(18, 15)
        Me.Label12.TabIndex = 36
        Me.Label12.Text = "%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(593, 34)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(18, 15)
        Me.Label11.TabIndex = 35
        Me.Label11.Text = "%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(116, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(18, 15)
        Me.Label10.TabIndex = 34
        Me.Label10.Text = "%"
        Me.Label10.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(116, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(18, 15)
        Me.Label9.TabIndex = 33
        Me.Label9.Text = "%"
        Me.Label9.Visible = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(341, 73)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(18, 15)
        Me.Label8.TabIndex = 32
        Me.Label8.Text = "%"
        Me.Label8.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(341, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 15)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "%"
        Me.Label7.Visible = False
        '
        'txtMinOIntBrkRate
        '
        Me.txtMinOIntBrkRate.Location = New System.Drawing.Point(235, 70)
        Me.txtMinOIntBrkRate.Name = "txtMinOIntBrkRate"
        Me.txtMinOIntBrkRate.Size = New System.Drawing.Size(100, 21)
        Me.txtMinOIntBrkRate.TabIndex = 4
        Me.txtMinOIntBrkRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtcommIntRate_f
        '
        Me.txtcommIntRate_f.Location = New System.Drawing.Point(487, 70)
        Me.txtcommIntRate_f.Name = "txtcommIntRate_f"
        Me.txtcommIntRate_f.Size = New System.Drawing.Size(100, 21)
        Me.txtcommIntRate_f.TabIndex = 5
        Me.txtcommIntRate_f.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtCommNorRate_f
        '
        Me.txtCommNorRate_f.Location = New System.Drawing.Point(487, 31)
        Me.txtCommNorRate_f.Name = "txtCommNorRate_f"
        Me.txtCommNorRate_f.Size = New System.Drawing.Size(100, 21)
        Me.txtCommNorRate_f.TabIndex = 2
        Me.txtCommNorRate_f.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinONorBrkRate
        '
        Me.txtMinONorBrkRate.Location = New System.Drawing.Point(10, 69)
        Me.txtMinONorBrkRate.Name = "txtMinONorBrkRate"
        Me.txtMinONorBrkRate.Size = New System.Drawing.Size(100, 21)
        Me.txtMinONorBrkRate.TabIndex = 3
        Me.txtMinONorBrkRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtMinFIntBrkRate
        '
        Me.txtMinFIntBrkRate.Location = New System.Drawing.Point(235, 31)
        Me.txtMinFIntBrkRate.Name = "txtMinFIntBrkRate"
        Me.txtMinFIntBrkRate.Size = New System.Drawing.Size(100, 21)
        Me.txtMinFIntBrkRate.TabIndex = 1
        Me.txtMinFIntBrkRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtminFNorBrkRate
        '
        Me.txtminFNorBrkRate.Location = New System.Drawing.Point(10, 31)
        Me.txtminFNorBrkRate.Name = "txtminFNorBrkRate"
        Me.txtminFNorBrkRate.Size = New System.Drawing.Size(100, 21)
        Me.txtminFNorBrkRate.TabIndex = 0
        Me.txtminFNorBrkRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblcommIntRate_f
        '
        Me.lblcommIntRate_f.AutoSize = True
        Me.lblcommIntRate_f.Location = New System.Drawing.Point(483, 55)
        Me.lblcommIntRate_f.Name = "lblcommIntRate_f"
        Me.lblcommIntRate_f.Size = New System.Drawing.Size(77, 15)
        Me.lblcommIntRate_f.TabIndex = 5
        Me.lblcommIntRate_f.Text = "Internet Rate"
        '
        'lblCommNorRate_f
        '
        Me.lblCommNorRate_f.AutoSize = True
        Me.lblCommNorRate_f.Location = New System.Drawing.Point(484, 17)
        Me.lblCommNorRate_f.Name = "lblCommNorRate_f"
        Me.lblCommNorRate_f.Size = New System.Drawing.Size(77, 15)
        Me.lblCommNorRate_f.TabIndex = 4
        Me.lblCommNorRate_f.Text = "Normal Rate"
        '
        'lblMinOIntBrkRate
        '
        Me.lblMinOIntBrkRate.AutoSize = True
        Me.lblMinOIntBrkRate.Location = New System.Drawing.Point(232, 55)
        Me.lblMinOIntBrkRate.Name = "lblMinOIntBrkRate"
        Me.lblMinOIntBrkRate.Size = New System.Drawing.Size(179, 15)
        Me.lblMinOIntBrkRate.TabIndex = 3
        Me.lblMinOIntBrkRate.Text = "Min. Options Internet Brokerage"
        Me.lblMinOIntBrkRate.Visible = False
        '
        'lblMinFIntBrkRate
        '
        Me.lblMinFIntBrkRate.AutoSize = True
        Me.lblMinFIntBrkRate.Location = New System.Drawing.Point(233, 17)
        Me.lblMinFIntBrkRate.Name = "lblMinFIntBrkRate"
        Me.lblMinFIntBrkRate.Size = New System.Drawing.Size(178, 15)
        Me.lblMinFIntBrkRate.TabIndex = 2
        Me.lblMinFIntBrkRate.Text = "Min. Futures Internet Brokerage"
        Me.lblMinFIntBrkRate.Visible = False
        '
        'lblMinONorBrkRate
        '
        Me.lblMinONorBrkRate.AutoSize = True
        Me.lblMinONorBrkRate.Location = New System.Drawing.Point(7, 55)
        Me.lblMinONorBrkRate.Name = "lblMinONorBrkRate"
        Me.lblMinONorBrkRate.Size = New System.Drawing.Size(179, 15)
        Me.lblMinONorBrkRate.TabIndex = 1
        Me.lblMinONorBrkRate.Text = "Min. Options Normal Brokerage"
        Me.lblMinONorBrkRate.Visible = False
        '
        'lblminFNorBrkRate
        '
        Me.lblminFNorBrkRate.AutoSize = True
        Me.lblminFNorBrkRate.Location = New System.Drawing.Point(7, 17)
        Me.lblminFNorBrkRate.Name = "lblminFNorBrkRate"
        Me.lblminFNorBrkRate.Size = New System.Drawing.Size(178, 15)
        Me.lblminFNorBrkRate.TabIndex = 0
        Me.lblminFNorBrkRate.Text = "Min. Futures Normal Brokerage"
        Me.lblminFNorBrkRate.Visible = False
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(676, 40)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(82, 24)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(591, 494)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(539, 494)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(486, 494)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 9
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.rbMan)
        Me.GroupBox3.Controls.Add(Me.rbAE)
        Me.GroupBox3.Controls.Add(Me.rbAGRP)
        Me.GroupBox3.Controls.Add(Me.rbACC)
        Me.GroupBox3.Location = New System.Drawing.Point(50, 261)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(288, 32)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'rbMan
        '
        Me.rbMan.AutoSize = True
        Me.rbMan.Location = New System.Drawing.Point(207, 9)
        Me.rbMan.Name = "rbMan"
        Me.rbMan.Size = New System.Drawing.Size(73, 19)
        Me.rbMan.TabIndex = 3
        Me.rbMan.Text = "Manager"
        Me.rbMan.UseVisualStyleBackColor = True
        '
        'rbAE
        '
        Me.rbAE.AutoSize = True
        Me.rbAE.Location = New System.Drawing.Point(77, 10)
        Me.rbAE.Name = "rbAE"
        Me.rbAE.Size = New System.Drawing.Size(40, 19)
        Me.rbAE.TabIndex = 2
        Me.rbAE.Text = "AE"
        Me.rbAE.UseVisualStyleBackColor = True
        '
        'rbAGRP
        '
        Me.rbAGRP.AutoSize = True
        Me.rbAGRP.Location = New System.Drawing.Point(123, 10)
        Me.rbAGRP.Name = "rbAGRP"
        Me.rbAGRP.Size = New System.Drawing.Size(81, 19)
        Me.rbAGRP.TabIndex = 1
        Me.rbAGRP.Text = "A/C Group"
        Me.rbAGRP.UseVisualStyleBackColor = True
        '
        'rbACC
        '
        Me.rbACC.AutoSize = True
        Me.rbACC.Checked = True
        Me.rbACC.Location = New System.Drawing.Point(6, 10)
        Me.rbACC.Name = "rbACC"
        Me.rbACC.Size = New System.Drawing.Size(68, 19)
        Me.rbACC.TabIndex = 0
        Me.rbACC.TabStop = True
        Me.rbACC.Text = "Account"
        Me.rbACC.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 272)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 23
        Me.Label1.Text = "Type"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(357, 273)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(32, 15)
        Me.Label15.TabIndex = 25
        Me.Label15.Text = "Year"
        '
        'comboYear
        '
        Me.comboYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboYear.FormattingEnabled = True
        Me.comboYear.Location = New System.Drawing.Point(395, 270)
        Me.comboYear.Name = "comboYear"
        Me.comboYear.Size = New System.Drawing.Size(62, 23)
        Me.comboYear.TabIndex = 5
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(473, 273)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(40, 15)
        Me.Label16.TabIndex = 26
        Me.Label16.Text = "Month"
        '
        'comboMonth
        '
        Me.comboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboMonth.FormattingEnabled = True
        Me.comboMonth.Location = New System.Drawing.Point(519, 270)
        Me.comboMonth.Name = "comboMonth"
        Me.comboMonth.Size = New System.Drawing.Size(48, 23)
        Me.comboMonth.TabIndex = 6
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(216, 9)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(306, 22)
        Me.lblTitle.TabIndex = 149
        Me.lblTitle.Text = "Global Commission Rate Master"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.dtgGlobalRate)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(2, 69)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(757, 196)
        Me.Panel1.TabIndex = 150
        '
        'comboSrchMonth
        '
        Me.comboSrchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrchMonth.FormattingEnabled = True
        Me.comboSrchMonth.Location = New System.Drawing.Point(159, 43)
        Me.comboSrchMonth.Name = "comboSrchMonth"
        Me.comboSrchMonth.Size = New System.Drawing.Size(48, 23)
        Me.comboSrchMonth.TabIndex = 151
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(113, 46)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 15)
        Me.Label13.TabIndex = 152
        Me.Label13.Text = "Month"
        '
        'FrmCommRateGlobal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(760, 554)
        Me.Controls.Add(Me.comboSrchMonth)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.comboMonth)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.comboYear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.GroupBoxFut)
        Me.Controls.Add(Me.GroupBoxSec)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBoxSrchType)
        Me.Controls.Add(Me.ComboSrchYear)
        Me.Controls.Add(Me.GroupBox3)
        Me.KeyPreview = True
        Me.Name = "FrmCommRateGlobal"
        Me.Text = "Global Commission Rate"
        Me.Controls.SetChildIndex(Me.GroupBox3, 0)
        Me.Controls.SetChildIndex(Me.ComboSrchYear, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxSrchType, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxSec, 0)
        Me.Controls.SetChildIndex(Me.GroupBoxFut, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.comboYear, 0)
        Me.Controls.SetChildIndex(Me.Label15, 0)
        Me.Controls.SetChildIndex(Me.Label16, 0)
        Me.Controls.SetChildIndex(Me.comboMonth, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.comboSrchMonth, 0)
        CType(Me.dtgGlobalRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBoxSrchType.ResumeLayout(False)
        Me.GroupBoxSrchType.PerformLayout()
        Me.GroupBoxSec.ResumeLayout(False)
        Me.GroupBoxSec.PerformLayout()
        Me.GroupBoxFut.ResumeLayout(False)
        Me.GroupBoxFut.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgGlobalRate As System.Windows.Forms.DataGridView
    Friend WithEvents ComboSrchYear As ESL.myComboBox
    Friend WithEvents rbSrchAcc As ESL.myRadioButton
    Friend WithEvents rbSrchAcGP As ESL.myRadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBoxSrchType As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxSec As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBoxFut As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents lblMinIntAmt As System.Windows.Forms.Label
    Friend WithEvents lblMinNorAmt As System.Windows.Forms.Label
    Friend WithEvents lblminIntRate_s As System.Windows.Forms.Label
    Friend WithEvents lblMinNorRate_s As System.Windows.Forms.Label
    Friend WithEvents lblCommIntRate As System.Windows.Forms.Label
    Friend WithEvents lblcommNorRate As System.Windows.Forms.Label
    Friend WithEvents lblminFNorBrkRate As System.Windows.Forms.Label
    Friend WithEvents lblMinONorBrkRate As System.Windows.Forms.Label
    Friend WithEvents lblMinFIntBrkRate As System.Windows.Forms.Label
    Friend WithEvents lblMinOIntBrkRate As System.Windows.Forms.Label
    Friend WithEvents lblcommIntRate_f As System.Windows.Forms.Label
    Friend WithEvents lblCommNorRate_f As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents txtMinNorAmt As ESL.myNumericBox
    Friend WithEvents txtminIntRate_s As ESL.myNumericBox
    Friend WithEvents txtCommIntRate As ESL.myNumericBox
    Friend WithEvents txtMinIntAmt As ESL.myNumericBox
    Friend WithEvents txtcommNorRate As ESL.myNumericBox
    Friend WithEvents txtMinNorRate_s As ESL.myNumericBox
    Friend WithEvents txtMinOIntBrkRate As ESL.myNumericBox
    Friend WithEvents txtcommIntRate_f As ESL.myNumericBox
    Friend WithEvents txtCommNorRate_f As ESL.myNumericBox
    Friend WithEvents txtMinONorBrkRate As ESL.myNumericBox
    Friend WithEvents txtMinFIntBrkRate As ESL.myNumericBox
    Friend WithEvents txtminFNorBrkRate As ESL.myNumericBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAGRP As ESL.myRadioButton
    Friend WithEvents rbACC As ESL.myRadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents comboYear As ESL.myComboBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents comboMonth As ESL.myComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents comboSrchMonth As ESL.myComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents rbSrchAE As ESL.myRadioButton
    Friend WithEvents rbAE As ESL.myRadioButton
    Friend WithEvents rbSrchMan As ESL.myRadioButton
    Friend WithEvents rbMan As ESL.myRadioButton
    Friend WithEvents txmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents comm_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minNorAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minNorRate_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents commNorRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minIntAmt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minIntRate_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents commIntRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minFNorBrkRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minFIntBrkRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents commNorRate_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minONorBrkRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents minOIntBrkRate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents commIntRate_f As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
