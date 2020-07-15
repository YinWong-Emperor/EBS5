<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLiqList
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
        Dim DataGridViewCellStyle49 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle60 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle61 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle50 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle51 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle52 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle53 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle54 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle55 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle56 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle57 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle58 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle59 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle62 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle63 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle71 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle72 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle64 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle65 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle66 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle67 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle68 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle69 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle70 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.DtgDetail = New System.Windows.Forms.DataGridView()
        Me.AE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Client = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dr_bal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mkt_val = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.act_ratio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.mc_act_ratio = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.due = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.undue = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.total = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.os_day = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.net_trade = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.cr_limit = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Client_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RBAll = New ESL.myRadioButton(Me.components)
        Me.DtgTotal = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn6 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn7 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn8 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn9 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn10 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn11 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn12 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RBFinance = New ESL.myRadioButton(Me.components)
        Me.RBMargin = New ESL.myRadioButton(Me.components)
        Me.RBCash = New ESL.myRadioButton(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.AmtOSDay = New ESL.myNumericUpDown(Me.components)
        Me.AmtOverDraft = New ESL.myNumericUpDown(Me.components)
        Me.Amttotal = New ESL.myNumericUpDown(Me.components)
        Me.AmtLimit = New ESL.myNumericUpDown(Me.components)
        Me.AmtUndue = New ESL.myNumericUpDown(Me.components)
        Me.AmtFutures = New ESL.myNumericUpDown(Me.components)
        Me.AmtDue = New ESL.myNumericUpDown(Me.components)
        Me.AmtMarRatio = New ESL.myNumericUpDown(Me.components)
        Me.AmtActRatio = New ESL.myNumericUpDown(Me.components)
        Me.AmtMktLess = New ESL.myNumericUpDown(Me.components)
        Me.AmtMktMore = New ESL.myNumericUpDown(Me.components)
        Me.AmtDR = New ESL.myNumericUpDown(Me.components)
        Me.AmtCR = New ESL.myNumericUpDown(Me.components)
        Me.btnPrc = New ESL.myButton(Me.components)
        Me.RBTypeCash = New ESL.myRadioButton(Me.components)
        Me.RBTypeMargin = New ESL.myRadioButton(Me.components)
        Me.CBType = New System.Windows.Forms.CheckBox()
        Me.CBOSDay = New System.Windows.Forms.CheckBox()
        Me.txtName = New ESL.myTextbox()
        Me.CBName = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtClientTo = New ESL.myTextbox()
        Me.txtClientFrom = New ESL.myTextbox()
        Me.CBClient = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.CboRunTo = New ESL.myComboBox(Me.components)
        Me.CBRunner = New System.Windows.Forms.CheckBox()
        Me.CBoRunFrom = New ESL.myComboBox(Me.components)
        Me.CBOverDraft = New System.Windows.Forms.CheckBox()
        Me.CBTotal = New System.Windows.Forms.CheckBox()
        Me.CBLimit = New System.Windows.Forms.CheckBox()
        Me.CBUndue = New System.Windows.Forms.CheckBox()
        Me.CBFutures = New System.Windows.Forms.CheckBox()
        Me.CBDue = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CBMarRatio = New System.Windows.Forms.CheckBox()
        Me.CBActRatio = New System.Windows.Forms.CheckBox()
        Me.CBMKTLess = New System.Windows.Forms.CheckBox()
        Me.CBMktMore = New System.Windows.Forms.CheckBox()
        Me.CBdr = New System.Windows.Forms.CheckBox()
        Me.CBcr = New System.Windows.Forms.CheckBox()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.BtnPrint = New ESL.myButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.CboFrm = New ESL.myComboBox(Me.components)
        Me.CboTo = New ESL.myComboBox(Me.components)
        Me.TabPage4 = New System.Windows.Forms.TabPage()
        Me.txtClientCode = New ESL.myTextbox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.BtnSearch = New ESL.myButton(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtClientName = New ESL.myTextbox()
        Me.TabPage5 = New System.Windows.Forms.TabPage()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.tbExport = New ESL.myTextbox()
        Me.BtnExport = New ESL.myButton(Me.components)
        Me.TabPage6 = New System.Windows.Forms.TabPage()
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnCancel2 = New ESL.myButton(Me.components)
        Me.btnStore = New ESL.myButton(Me.components)
        Me.txtFilter = New ESL.myTextbox()
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.PrintDlg = New System.Windows.Forms.PrintDialog()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        CType(Me.DtgDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DtgTotal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage2.SuspendLayout()
        CType(Me.AmtOSDay, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtOverDraft, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Amttotal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtLimit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtUndue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtFutures, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtDue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtMarRatio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtActRatio, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtMktLess, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtMktMore, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtDR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AmtCR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.TabPage5.SuspendLayout()
        Me.TabPage6.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(573, 420)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(521, 420)
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Controls.Add(Me.TabPage5)
        Me.TabControl1.Controls.Add(Me.TabPage6)
        Me.TabControl1.Location = New System.Drawing.Point(2, 4)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(621, 414)
        Me.TabControl1.TabIndex = 23
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Linen
        Me.TabPage1.Controls.Add(Me.DtgDetail)
        Me.TabPage1.Controls.Add(Me.RBAll)
        Me.TabPage1.Controls.Add(Me.DtgTotal)
        Me.TabPage1.Controls.Add(Me.RBFinance)
        Me.TabPage1.Controls.Add(Me.RBMargin)
        Me.TabPage1.Controls.Add(Me.RBCash)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(613, 386)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Securities Liquidation Master Table"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'DtgDetail
        '
        Me.DtgDetail.AllowUserToAddRows = False
        Me.DtgDetail.AllowUserToDeleteRows = False
        Me.DtgDetail.AllowUserToResizeRows = False
        Me.DtgDetail.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle49.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle49.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle49.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle49.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle49.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle49.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle49.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtgDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle49
        Me.DtgDetail.ColumnHeadersHeight = 20
        Me.DtgDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AE, Me.Client, Me.dr_bal, Me.mkt_val, Me.act_ratio, Me.mc_act_ratio, Me.due, Me.undue, Me.total, Me.os_day, Me.net_trade, Me.cr_limit, Me.Client_Name})
        DataGridViewCellStyle60.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle60.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle60.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle60.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle60.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle60.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle60.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtgDetail.DefaultCellStyle = DataGridViewCellStyle60
        Me.DtgDetail.Location = New System.Drawing.Point(3, 23)
        Me.DtgDetail.MultiSelect = False
        Me.DtgDetail.Name = "DtgDetail"
        Me.DtgDetail.RowHeadersVisible = False
        DataGridViewCellStyle61.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtgDetail.RowsDefaultCellStyle = DataGridViewCellStyle61
        Me.DtgDetail.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtgDetail.RowTemplate.Height = 18
        Me.DtgDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DtgDetail.Size = New System.Drawing.Size(606, 296)
        Me.DtgDetail.TabIndex = 4
        '
        'AE
        '
        Me.AE.DataPropertyName = "run_code"
        Me.AE.HeaderText = "AE"
        Me.AE.Name = "AE"
        Me.AE.Width = 50
        '
        'Client
        '
        Me.Client.DataPropertyName = "clt_code"
        Me.Client.HeaderText = "Client"
        Me.Client.Name = "Client"
        Me.Client.Width = 60
        '
        'dr_bal
        '
        Me.dr_bal.DataPropertyName = "mc_dr_bal"
        DataGridViewCellStyle50.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle50.Format = "N2"
        DataGridViewCellStyle50.NullValue = "0"
        Me.dr_bal.DefaultCellStyle = DataGridViewCellStyle50
        Me.dr_bal.HeaderText = "Dr. Bal"
        Me.dr_bal.Name = "dr_bal"
        Me.dr_bal.Width = 80
        '
        'mkt_val
        '
        Me.mkt_val.DataPropertyName = "mkt_value"
        DataGridViewCellStyle51.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle51.Format = "N2"
        DataGridViewCellStyle51.NullValue = Nothing
        Me.mkt_val.DefaultCellStyle = DataGridViewCellStyle51
        Me.mkt_val.HeaderText = "Mkt. Value"
        Me.mkt_val.Name = "mkt_val"
        Me.mkt_val.Width = 80
        '
        'act_ratio
        '
        Me.act_ratio.DataPropertyName = "aratio"
        DataGridViewCellStyle52.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle52.NullValue = Nothing
        Me.act_ratio.DefaultCellStyle = DataGridViewCellStyle52
        Me.act_ratio.HeaderText = "A. Ratio"
        Me.act_ratio.Name = "act_ratio"
        Me.act_ratio.Width = 60
        '
        'mc_act_ratio
        '
        Me.mc_act_ratio.DataPropertyName = "mratio"
        DataGridViewCellStyle53.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.mc_act_ratio.DefaultCellStyle = DataGridViewCellStyle53
        Me.mc_act_ratio.HeaderText = "M. Ratio"
        Me.mc_act_ratio.Name = "mc_act_ratio"
        Me.mc_act_ratio.Width = 60
        '
        'due
        '
        Me.due.DataPropertyName = "mc_due"
        DataGridViewCellStyle54.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle54.Format = "N2"
        Me.due.DefaultCellStyle = DataGridViewCellStyle54
        Me.due.HeaderText = "Due"
        Me.due.Name = "due"
        Me.due.Width = 80
        '
        'undue
        '
        Me.undue.DataPropertyName = "mc_t2"
        DataGridViewCellStyle55.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle55.Format = "N2"
        Me.undue.DefaultCellStyle = DataGridViewCellStyle55
        Me.undue.HeaderText = "Undue"
        Me.undue.Name = "undue"
        Me.undue.Width = 80
        '
        'total
        '
        Me.total.DataPropertyName = "mc_total"
        DataGridViewCellStyle56.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle56.Format = "N2"
        Me.total.DefaultCellStyle = DataGridViewCellStyle56
        Me.total.HeaderText = "Total"
        Me.total.Name = "total"
        Me.total.Width = 80
        '
        'os_day
        '
        Me.os_day.DataPropertyName = "os_day"
        DataGridViewCellStyle57.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.os_day.DefaultCellStyle = DataGridViewCellStyle57
        Me.os_day.HeaderText = "OS Day"
        Me.os_day.Name = "os_day"
        Me.os_day.Width = 80
        '
        'net_trade
        '
        Me.net_trade.DataPropertyName = "net_trade"
        DataGridViewCellStyle58.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle58.Format = "N2"
        Me.net_trade.DefaultCellStyle = DataGridViewCellStyle58
        Me.net_trade.HeaderText = "Net Trade"
        Me.net_trade.Name = "net_trade"
        Me.net_trade.Width = 80
        '
        'cr_limit
        '
        Me.cr_limit.DataPropertyName = "cr_limit"
        DataGridViewCellStyle59.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle59.Format = "N2"
        Me.cr_limit.DefaultCellStyle = DataGridViewCellStyle59
        Me.cr_limit.HeaderText = "Cr. Limit"
        Me.cr_limit.Name = "cr_limit"
        Me.cr_limit.Width = 80
        '
        'Client_Name
        '
        Me.Client_Name.DataPropertyName = "clt_name"
        Me.Client_Name.HeaderText = "Client Name"
        Me.Client_Name.Name = "Client_Name"
        Me.Client_Name.Width = 200
        '
        'RBAll
        '
        Me.RBAll.AutoSize = True
        Me.RBAll.BackColor = System.Drawing.Color.White
        Me.RBAll.Location = New System.Drawing.Point(527, 3)
        Me.RBAll.Name = "RBAll"
        Me.RBAll.Size = New System.Drawing.Size(38, 19)
        Me.RBAll.TabIndex = 3
        Me.RBAll.Text = "All"
        Me.RBAll.UseVisualStyleBackColor = False
        '
        'DtgTotal
        '
        Me.DtgTotal.AllowUserToAddRows = False
        Me.DtgTotal.AllowUserToDeleteRows = False
        Me.DtgTotal.AllowUserToResizeRows = False
        DataGridViewCellStyle62.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtgTotal.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle62
        Me.DtgTotal.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle63.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle63.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle63.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle63.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle63.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle63.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle63.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DtgTotal.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle63
        Me.DtgTotal.ColumnHeadersHeight = 20
        Me.DtgTotal.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn1, Me.DataGridViewTextBoxColumn2, Me.DataGridViewTextBoxColumn3, Me.DataGridViewTextBoxColumn4, Me.DataGridViewTextBoxColumn5, Me.DataGridViewTextBoxColumn6, Me.DataGridViewTextBoxColumn7, Me.DataGridViewTextBoxColumn8, Me.DataGridViewTextBoxColumn9, Me.DataGridViewTextBoxColumn10, Me.DataGridViewTextBoxColumn11, Me.DataGridViewTextBoxColumn12, Me.DataGridViewTextBoxColumn13})
        DataGridViewCellStyle71.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle71.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle71.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle71.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle71.SelectionBackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle71.SelectionForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle71.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtgTotal.DefaultCellStyle = DataGridViewCellStyle71
        Me.DtgTotal.Location = New System.Drawing.Point(3, 321)
        Me.DtgTotal.Name = "DtgTotal"
        Me.DtgTotal.ReadOnly = True
        Me.DtgTotal.RowHeadersVisible = False
        DataGridViewCellStyle72.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtgTotal.RowsDefaultCellStyle = DataGridViewCellStyle72
        Me.DtgTotal.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Arial", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DtgTotal.RowTemplate.Height = 20
        Me.DtgTotal.Size = New System.Drawing.Size(606, 64)
        Me.DtgTotal.TabIndex = 5
        '
        'DataGridViewTextBoxColumn1
        '
        Me.DataGridViewTextBoxColumn1.DataPropertyName = "ttl_desc"
        Me.DataGridViewTextBoxColumn1.HeaderText = ""
        Me.DataGridViewTextBoxColumn1.Name = "DataGridViewTextBoxColumn1"
        Me.DataGridViewTextBoxColumn1.ReadOnly = True
        Me.DataGridViewTextBoxColumn1.Width = 50
        '
        'DataGridViewTextBoxColumn2
        '
        Me.DataGridViewTextBoxColumn2.DataPropertyName = "ttl_rec"
        DataGridViewCellStyle64.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.DataGridViewTextBoxColumn2.DefaultCellStyle = DataGridViewCellStyle64
        Me.DataGridViewTextBoxColumn2.HeaderText = ""
        Me.DataGridViewTextBoxColumn2.Name = "DataGridViewTextBoxColumn2"
        Me.DataGridViewTextBoxColumn2.ReadOnly = True
        Me.DataGridViewTextBoxColumn2.Width = 60
        '
        'DataGridViewTextBoxColumn3
        '
        Me.DataGridViewTextBoxColumn3.DataPropertyName = "s_mc_dr_bal"
        DataGridViewCellStyle65.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle65.Format = "N2"
        Me.DataGridViewTextBoxColumn3.DefaultCellStyle = DataGridViewCellStyle65
        Me.DataGridViewTextBoxColumn3.HeaderText = "Dr. Bal"
        Me.DataGridViewTextBoxColumn3.Name = "DataGridViewTextBoxColumn3"
        Me.DataGridViewTextBoxColumn3.ReadOnly = True
        Me.DataGridViewTextBoxColumn3.Width = 80
        '
        'DataGridViewTextBoxColumn4
        '
        Me.DataGridViewTextBoxColumn4.DataPropertyName = "s_mkt_value"
        DataGridViewCellStyle66.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle66.Format = "N2"
        Me.DataGridViewTextBoxColumn4.DefaultCellStyle = DataGridViewCellStyle66
        Me.DataGridViewTextBoxColumn4.HeaderText = "Mkt. Value"
        Me.DataGridViewTextBoxColumn4.Name = "DataGridViewTextBoxColumn4"
        Me.DataGridViewTextBoxColumn4.ReadOnly = True
        Me.DataGridViewTextBoxColumn4.Width = 80
        '
        'DataGridViewTextBoxColumn5
        '
        Me.DataGridViewTextBoxColumn5.HeaderText = ""
        Me.DataGridViewTextBoxColumn5.Name = "DataGridViewTextBoxColumn5"
        Me.DataGridViewTextBoxColumn5.ReadOnly = True
        Me.DataGridViewTextBoxColumn5.Width = 60
        '
        'DataGridViewTextBoxColumn6
        '
        Me.DataGridViewTextBoxColumn6.HeaderText = ""
        Me.DataGridViewTextBoxColumn6.Name = "DataGridViewTextBoxColumn6"
        Me.DataGridViewTextBoxColumn6.ReadOnly = True
        Me.DataGridViewTextBoxColumn6.Width = 60
        '
        'DataGridViewTextBoxColumn7
        '
        Me.DataGridViewTextBoxColumn7.DataPropertyName = "s_mc_due"
        DataGridViewCellStyle67.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle67.Format = "N2"
        Me.DataGridViewTextBoxColumn7.DefaultCellStyle = DataGridViewCellStyle67
        Me.DataGridViewTextBoxColumn7.HeaderText = "Due"
        Me.DataGridViewTextBoxColumn7.Name = "DataGridViewTextBoxColumn7"
        Me.DataGridViewTextBoxColumn7.ReadOnly = True
        Me.DataGridViewTextBoxColumn7.Width = 80
        '
        'DataGridViewTextBoxColumn8
        '
        Me.DataGridViewTextBoxColumn8.DataPropertyName = "s_mc_t2"
        DataGridViewCellStyle68.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle68.Format = "N2"
        Me.DataGridViewTextBoxColumn8.DefaultCellStyle = DataGridViewCellStyle68
        Me.DataGridViewTextBoxColumn8.HeaderText = "Undue"
        Me.DataGridViewTextBoxColumn8.Name = "DataGridViewTextBoxColumn8"
        Me.DataGridViewTextBoxColumn8.ReadOnly = True
        Me.DataGridViewTextBoxColumn8.Width = 80
        '
        'DataGridViewTextBoxColumn9
        '
        Me.DataGridViewTextBoxColumn9.DataPropertyName = "s_mc_total"
        DataGridViewCellStyle69.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle69.Format = "N2"
        Me.DataGridViewTextBoxColumn9.DefaultCellStyle = DataGridViewCellStyle69
        Me.DataGridViewTextBoxColumn9.HeaderText = "Total"
        Me.DataGridViewTextBoxColumn9.Name = "DataGridViewTextBoxColumn9"
        Me.DataGridViewTextBoxColumn9.ReadOnly = True
        Me.DataGridViewTextBoxColumn9.Width = 80
        '
        'DataGridViewTextBoxColumn10
        '
        Me.DataGridViewTextBoxColumn10.HeaderText = ""
        Me.DataGridViewTextBoxColumn10.Name = "DataGridViewTextBoxColumn10"
        Me.DataGridViewTextBoxColumn10.ReadOnly = True
        Me.DataGridViewTextBoxColumn10.Width = 80
        '
        'DataGridViewTextBoxColumn11
        '
        Me.DataGridViewTextBoxColumn11.DataPropertyName = "s_net_trade"
        DataGridViewCellStyle70.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle70.Format = "N2"
        Me.DataGridViewTextBoxColumn11.DefaultCellStyle = DataGridViewCellStyle70
        Me.DataGridViewTextBoxColumn11.HeaderText = "Net Trade"
        Me.DataGridViewTextBoxColumn11.Name = "DataGridViewTextBoxColumn11"
        Me.DataGridViewTextBoxColumn11.ReadOnly = True
        Me.DataGridViewTextBoxColumn11.Width = 80
        '
        'DataGridViewTextBoxColumn12
        '
        Me.DataGridViewTextBoxColumn12.DataPropertyName = "s_cr_limit"
        Me.DataGridViewTextBoxColumn12.HeaderText = "Cr. Limit"
        Me.DataGridViewTextBoxColumn12.Name = "DataGridViewTextBoxColumn12"
        Me.DataGridViewTextBoxColumn12.ReadOnly = True
        Me.DataGridViewTextBoxColumn12.Width = 80
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.HeaderText = ""
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Width = 200
        '
        'RBFinance
        '
        Me.RBFinance.AutoSize = True
        Me.RBFinance.BackColor = System.Drawing.Color.White
        Me.RBFinance.Location = New System.Drawing.Point(452, 3)
        Me.RBFinance.Name = "RBFinance"
        Me.RBFinance.Size = New System.Drawing.Size(69, 19)
        Me.RBFinance.TabIndex = 2
        Me.RBFinance.Text = "Finance"
        Me.RBFinance.UseVisualStyleBackColor = False
        '
        'RBMargin
        '
        Me.RBMargin.AutoSize = True
        Me.RBMargin.BackColor = System.Drawing.Color.White
        Me.RBMargin.Location = New System.Drawing.Point(323, 3)
        Me.RBMargin.Name = "RBMargin"
        Me.RBMargin.Size = New System.Drawing.Size(62, 19)
        Me.RBMargin.TabIndex = 0
        Me.RBMargin.Text = "Margin"
        Me.RBMargin.UseVisualStyleBackColor = False
        '
        'RBCash
        '
        Me.RBCash.AutoSize = True
        Me.RBCash.BackColor = System.Drawing.Color.White
        Me.RBCash.Location = New System.Drawing.Point(391, 3)
        Me.RBCash.Name = "RBCash"
        Me.RBCash.Size = New System.Drawing.Size(55, 19)
        Me.RBCash.TabIndex = 1
        Me.RBCash.Text = "Cash"
        Me.RBCash.UseVisualStyleBackColor = False
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.White
        Me.TabPage2.Controls.Add(Me.AmtOSDay)
        Me.TabPage2.Controls.Add(Me.AmtOverDraft)
        Me.TabPage2.Controls.Add(Me.Amttotal)
        Me.TabPage2.Controls.Add(Me.AmtLimit)
        Me.TabPage2.Controls.Add(Me.AmtUndue)
        Me.TabPage2.Controls.Add(Me.AmtFutures)
        Me.TabPage2.Controls.Add(Me.AmtDue)
        Me.TabPage2.Controls.Add(Me.AmtMarRatio)
        Me.TabPage2.Controls.Add(Me.AmtActRatio)
        Me.TabPage2.Controls.Add(Me.AmtMktLess)
        Me.TabPage2.Controls.Add(Me.AmtMktMore)
        Me.TabPage2.Controls.Add(Me.AmtDR)
        Me.TabPage2.Controls.Add(Me.AmtCR)
        Me.TabPage2.Controls.Add(Me.btnPrc)
        Me.TabPage2.Controls.Add(Me.RBTypeCash)
        Me.TabPage2.Controls.Add(Me.RBTypeMargin)
        Me.TabPage2.Controls.Add(Me.CBType)
        Me.TabPage2.Controls.Add(Me.CBOSDay)
        Me.TabPage2.Controls.Add(Me.txtName)
        Me.TabPage2.Controls.Add(Me.CBName)
        Me.TabPage2.Controls.Add(Me.Label4)
        Me.TabPage2.Controls.Add(Me.txtClientTo)
        Me.TabPage2.Controls.Add(Me.txtClientFrom)
        Me.TabPage2.Controls.Add(Me.CBClient)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.CboRunTo)
        Me.TabPage2.Controls.Add(Me.CBRunner)
        Me.TabPage2.Controls.Add(Me.CBoRunFrom)
        Me.TabPage2.Controls.Add(Me.CBOverDraft)
        Me.TabPage2.Controls.Add(Me.CBTotal)
        Me.TabPage2.Controls.Add(Me.CBLimit)
        Me.TabPage2.Controls.Add(Me.CBUndue)
        Me.TabPage2.Controls.Add(Me.CBFutures)
        Me.TabPage2.Controls.Add(Me.CBDue)
        Me.TabPage2.Controls.Add(Me.Label2)
        Me.TabPage2.Controls.Add(Me.Label1)
        Me.TabPage2.Controls.Add(Me.CBMarRatio)
        Me.TabPage2.Controls.Add(Me.CBActRatio)
        Me.TabPage2.Controls.Add(Me.CBMKTLess)
        Me.TabPage2.Controls.Add(Me.CBMktMore)
        Me.TabPage2.Controls.Add(Me.CBdr)
        Me.TabPage2.Controls.Add(Me.CBcr)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(613, 386)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "   Enquiry   "
        '
        'AmtOSDay
        '
        Me.AmtOSDay.Location = New System.Drawing.Point(140, 302)
        Me.AmtOSDay.Maximum = New Decimal(New Integer() {9999999, 0, 0, 0})
        Me.AmtOSDay.Minimum = New Decimal(New Integer() {9999999, 0, 0, -2147483648})
        Me.AmtOSDay.Name = "AmtOSDay"
        Me.AmtOSDay.Size = New System.Drawing.Size(120, 21)
        Me.AmtOSDay.TabIndex = 34
        Me.AmtOSDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtOSDay.ThousandsSeparator = True
        '
        'AmtOverDraft
        '
        Me.AmtOverDraft.Location = New System.Drawing.Point(402, 176)
        Me.AmtOverDraft.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.AmtOverDraft.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.AmtOverDraft.Name = "AmtOverDraft"
        Me.AmtOverDraft.Size = New System.Drawing.Size(120, 21)
        Me.AmtOverDraft.TabIndex = 24
        Me.AmtOverDraft.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtOverDraft.ThousandsSeparator = True
        '
        'Amttotal
        '
        Me.Amttotal.Location = New System.Drawing.Point(141, 176)
        Me.Amttotal.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.Amttotal.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.Amttotal.Name = "Amttotal"
        Me.Amttotal.Size = New System.Drawing.Size(120, 21)
        Me.Amttotal.TabIndex = 22
        Me.Amttotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.Amttotal.ThousandsSeparator = True
        '
        'AmtLimit
        '
        Me.AmtLimit.Location = New System.Drawing.Point(402, 147)
        Me.AmtLimit.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.AmtLimit.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.AmtLimit.Name = "AmtLimit"
        Me.AmtLimit.Size = New System.Drawing.Size(120, 21)
        Me.AmtLimit.TabIndex = 20
        Me.AmtLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtLimit.ThousandsSeparator = True
        '
        'AmtUndue
        '
        Me.AmtUndue.Location = New System.Drawing.Point(140, 147)
        Me.AmtUndue.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.AmtUndue.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.AmtUndue.Name = "AmtUndue"
        Me.AmtUndue.Size = New System.Drawing.Size(120, 21)
        Me.AmtUndue.TabIndex = 18
        Me.AmtUndue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtUndue.ThousandsSeparator = True
        '
        'AmtFutures
        '
        Me.AmtFutures.Location = New System.Drawing.Point(402, 119)
        Me.AmtFutures.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.AmtFutures.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.AmtFutures.Name = "AmtFutures"
        Me.AmtFutures.Size = New System.Drawing.Size(120, 21)
        Me.AmtFutures.TabIndex = 16
        Me.AmtFutures.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtFutures.ThousandsSeparator = True
        Me.AmtFutures.Visible = False
        '
        'AmtDue
        '
        Me.AmtDue.Location = New System.Drawing.Point(140, 118)
        Me.AmtDue.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.AmtDue.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.AmtDue.Name = "AmtDue"
        Me.AmtDue.Size = New System.Drawing.Size(120, 21)
        Me.AmtDue.TabIndex = 14
        Me.AmtDue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtDue.ThousandsSeparator = True
        '
        'AmtMarRatio
        '
        Me.AmtMarRatio.DecimalPlaces = 2
        Me.AmtMarRatio.Location = New System.Drawing.Point(402, 81)
        Me.AmtMarRatio.Name = "AmtMarRatio"
        Me.AmtMarRatio.Size = New System.Drawing.Size(93, 21)
        Me.AmtMarRatio.TabIndex = 12
        Me.AmtMarRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AmtActRatio
        '
        Me.AmtActRatio.DecimalPlaces = 2
        Me.AmtActRatio.Location = New System.Drawing.Point(140, 80)
        Me.AmtActRatio.Name = "AmtActRatio"
        Me.AmtActRatio.Size = New System.Drawing.Size(93, 21)
        Me.AmtActRatio.TabIndex = 10
        Me.AmtActRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'AmtMktLess
        '
        Me.AmtMktLess.Location = New System.Drawing.Point(402, 46)
        Me.AmtMktLess.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.AmtMktLess.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.AmtMktLess.Name = "AmtMktLess"
        Me.AmtMktLess.Size = New System.Drawing.Size(120, 21)
        Me.AmtMktLess.TabIndex = 8
        Me.AmtMktLess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtMktLess.ThousandsSeparator = True
        '
        'AmtMktMore
        '
        Me.AmtMktMore.Location = New System.Drawing.Point(402, 17)
        Me.AmtMktMore.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.AmtMktMore.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.AmtMktMore.Name = "AmtMktMore"
        Me.AmtMktMore.Size = New System.Drawing.Size(120, 21)
        Me.AmtMktMore.TabIndex = 4
        Me.AmtMktMore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtMktMore.ThousandsSeparator = True
        '
        'AmtDR
        '
        Me.AmtDR.Location = New System.Drawing.Point(141, 46)
        Me.AmtDR.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.AmtDR.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.AmtDR.Name = "AmtDR"
        Me.AmtDR.Size = New System.Drawing.Size(120, 21)
        Me.AmtDR.TabIndex = 6
        Me.AmtDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtDR.ThousandsSeparator = True
        '
        'AmtCR
        '
        Me.AmtCR.Location = New System.Drawing.Point(140, 17)
        Me.AmtCR.Maximum = New Decimal(New Integer() {999999999, 0, 0, 0})
        Me.AmtCR.Minimum = New Decimal(New Integer() {999999999, 0, 0, -2147483648})
        Me.AmtCR.Name = "AmtCR"
        Me.AmtCR.Size = New System.Drawing.Size(120, 21)
        Me.AmtCR.TabIndex = 2
        Me.AmtCR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.AmtCR.ThousandsSeparator = True
        '
        'btnPrc
        '
        Me.btnPrc.Image = Global.ESL.My.Resources.Resources.Printer
        Me.btnPrc.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrc.Location = New System.Drawing.Point(306, 313)
        Me.btnPrc.Name = "btnPrc"
        Me.btnPrc.Size = New System.Drawing.Size(51, 56)
        Me.btnPrc.TabIndex = 38
        Me.btnPrc.Text = "Print"
        Me.btnPrc.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrc.UseVisualStyleBackColor = True
        '
        'RBTypeCash
        '
        Me.RBTypeCash.AccessibleRole = System.Windows.Forms.AccessibleRole.None
        Me.RBTypeCash.AutoSize = True
        Me.RBTypeCash.BackColor = System.Drawing.Color.White
        Me.RBTypeCash.Location = New System.Drawing.Point(208, 337)
        Me.RBTypeCash.Name = "RBTypeCash"
        Me.RBTypeCash.Size = New System.Drawing.Size(55, 19)
        Me.RBTypeCash.TabIndex = 37
        Me.RBTypeCash.TabStop = True
        Me.RBTypeCash.Text = "Cash"
        Me.RBTypeCash.UseVisualStyleBackColor = False
        '
        'RBTypeMargin
        '
        Me.RBTypeMargin.AutoSize = True
        Me.RBTypeMargin.BackColor = System.Drawing.Color.White
        Me.RBTypeMargin.Location = New System.Drawing.Point(140, 338)
        Me.RBTypeMargin.Name = "RBTypeMargin"
        Me.RBTypeMargin.Size = New System.Drawing.Size(62, 19)
        Me.RBTypeMargin.TabIndex = 36
        Me.RBTypeMargin.TabStop = True
        Me.RBTypeMargin.Text = "Margin"
        Me.RBTypeMargin.UseVisualStyleBackColor = False
        '
        'CBType
        '
        Me.CBType.AutoSize = True
        Me.CBType.BackColor = System.Drawing.Color.White
        Me.CBType.Location = New System.Drawing.Point(17, 338)
        Me.CBType.Name = "CBType"
        Me.CBType.Size = New System.Drawing.Size(101, 19)
        Me.CBType.TabIndex = 35
        Me.CBType.Text = "Product Code"
        Me.CBType.UseVisualStyleBackColor = False
        '
        'CBOSDay
        '
        Me.CBOSDay.AutoSize = True
        Me.CBOSDay.BackColor = System.Drawing.Color.White
        Me.CBOSDay.Location = New System.Drawing.Point(17, 304)
        Me.CBOSDay.Name = "CBOSDay"
        Me.CBOSDay.Size = New System.Drawing.Size(77, 19)
        Me.CBOSDay.TabIndex = 33
        Me.CBOSDay.Text = "OS Day >"
        Me.CBOSDay.UseVisualStyleBackColor = False
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(140, 271)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(287, 21)
        Me.txtName.TabIndex = 32
        '
        'CBName
        '
        Me.CBName.AutoSize = True
        Me.CBName.BackColor = System.Drawing.Color.White
        Me.CBName.Location = New System.Drawing.Point(17, 273)
        Me.CBName.Name = "CBName"
        Me.CBName.Size = New System.Drawing.Size(95, 19)
        Me.CBName.TabIndex = 31
        Me.CBName.Text = "Client Name"
        Me.CBName.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(276, 243)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(20, 15)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "To"
        '
        'txtClientTo
        '
        Me.txtClientTo.Location = New System.Drawing.Point(306, 240)
        Me.txtClientTo.Name = "txtClientTo"
        Me.txtClientTo.Size = New System.Drawing.Size(121, 21)
        Me.txtClientTo.TabIndex = 30
        '
        'txtClientFrom
        '
        Me.txtClientFrom.Location = New System.Drawing.Point(139, 240)
        Me.txtClientFrom.Name = "txtClientFrom"
        Me.txtClientFrom.Size = New System.Drawing.Size(121, 21)
        Me.txtClientFrom.TabIndex = 29
        '
        'CBClient
        '
        Me.CBClient.AutoSize = True
        Me.CBClient.BackColor = System.Drawing.Color.White
        Me.CBClient.Location = New System.Drawing.Point(17, 244)
        Me.CBClient.Name = "CBClient"
        Me.CBClient.Size = New System.Drawing.Size(94, 19)
        Me.CBClient.TabIndex = 28
        Me.CBClient.Text = "Client Code "
        Me.CBClient.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(276, 213)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(20, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "To"
        '
        'CboRunTo
        '
        Me.CboRunTo.FormattingEnabled = True
        Me.CboRunTo.Location = New System.Drawing.Point(306, 210)
        Me.CboRunTo.Name = "CboRunTo"
        Me.CboRunTo.Size = New System.Drawing.Size(121, 23)
        Me.CboRunTo.TabIndex = 27
        '
        'CBRunner
        '
        Me.CBRunner.AutoSize = True
        Me.CBRunner.BackColor = System.Drawing.Color.White
        Me.CBRunner.Location = New System.Drawing.Point(17, 212)
        Me.CBRunner.Name = "CBRunner"
        Me.CBRunner.Size = New System.Drawing.Size(103, 19)
        Me.CBRunner.TabIndex = 25
        Me.CBRunner.Text = "Runner Code "
        Me.CBRunner.UseVisualStyleBackColor = False
        '
        'CBoRunFrom
        '
        Me.CBoRunFrom.FormattingEnabled = True
        Me.CBoRunFrom.Location = New System.Drawing.Point(140, 210)
        Me.CBoRunFrom.Name = "CBoRunFrom"
        Me.CBoRunFrom.Size = New System.Drawing.Size(121, 23)
        Me.CBoRunFrom.TabIndex = 26
        '
        'CBOverDraft
        '
        Me.CBOverDraft.AutoSize = True
        Me.CBOverDraft.BackColor = System.Drawing.Color.White
        Me.CBOverDraft.Location = New System.Drawing.Point(279, 176)
        Me.CBOverDraft.Name = "CBOverDraft"
        Me.CBOverDraft.Size = New System.Drawing.Size(85, 19)
        Me.CBOverDraft.TabIndex = 23
        Me.CBOverDraft.Text = "Overdraft >"
        Me.CBOverDraft.UseVisualStyleBackColor = False
        '
        'CBTotal
        '
        Me.CBTotal.AutoSize = True
        Me.CBTotal.BackColor = System.Drawing.Color.White
        Me.CBTotal.Location = New System.Drawing.Point(17, 174)
        Me.CBTotal.Name = "CBTotal"
        Me.CBTotal.Size = New System.Drawing.Size(62, 19)
        Me.CBTotal.TabIndex = 21
        Me.CBTotal.Text = "Total >"
        Me.CBTotal.UseVisualStyleBackColor = False
        '
        'CBLimit
        '
        Me.CBLimit.AutoSize = True
        Me.CBLimit.BackColor = System.Drawing.Color.White
        Me.CBLimit.Location = New System.Drawing.Point(279, 147)
        Me.CBLimit.Name = "CBLimit"
        Me.CBLimit.Size = New System.Drawing.Size(99, 19)
        Me.CBLimit.TabIndex = 19
        Me.CBLimit.Text = "Credit Limit >"
        Me.CBLimit.UseVisualStyleBackColor = False
        '
        'CBUndue
        '
        Me.CBUndue.AutoSize = True
        Me.CBUndue.BackColor = System.Drawing.Color.White
        Me.CBUndue.Location = New System.Drawing.Point(17, 147)
        Me.CBUndue.Name = "CBUndue"
        Me.CBUndue.Size = New System.Drawing.Size(73, 19)
        Me.CBUndue.TabIndex = 17
        Me.CBUndue.Text = "Undue >"
        Me.CBUndue.UseVisualStyleBackColor = False
        '
        'CBFutures
        '
        Me.CBFutures.AutoSize = True
        Me.CBFutures.BackColor = System.Drawing.Color.White
        Me.CBFutures.Location = New System.Drawing.Point(279, 120)
        Me.CBFutures.Name = "CBFutures"
        Me.CBFutures.Size = New System.Drawing.Size(120, 19)
        Me.CBFutures.TabIndex = 15
        Me.CBFutures.Text = "Futures Suplus >"
        Me.CBFutures.UseVisualStyleBackColor = False
        Me.CBFutures.Visible = False
        '
        'CBDue
        '
        Me.CBDue.AutoSize = True
        Me.CBDue.BackColor = System.Drawing.Color.White
        Me.CBDue.Location = New System.Drawing.Point(17, 120)
        Me.CBDue.Name = "CBDue"
        Me.CBDue.Size = New System.Drawing.Size(99, 19)
        Me.CBDue.TabIndex = 13
        Me.CBDue.Text = "Due Margin >"
        Me.CBDue.UseVisualStyleBackColor = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(495, 83)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(18, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "%"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(234, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(18, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "%"
        '
        'CBMarRatio
        '
        Me.CBMarRatio.AutoSize = True
        Me.CBMarRatio.BackColor = System.Drawing.Color.White
        Me.CBMarRatio.Location = New System.Drawing.Point(279, 82)
        Me.CBMarRatio.Name = "CBMarRatio"
        Me.CBMarRatio.Size = New System.Drawing.Size(105, 19)
        Me.CBMarRatio.TabIndex = 11
        Me.CBMarRatio.Text = "Margin Ratio >"
        Me.CBMarRatio.UseVisualStyleBackColor = False
        '
        'CBActRatio
        '
        Me.CBActRatio.AutoSize = True
        Me.CBActRatio.BackColor = System.Drawing.Color.White
        Me.CBActRatio.Location = New System.Drawing.Point(17, 82)
        Me.CBActRatio.Name = "CBActRatio"
        Me.CBActRatio.Size = New System.Drawing.Size(101, 19)
        Me.CBActRatio.TabIndex = 9
        Me.CBActRatio.Text = "Actual Ratio >"
        Me.CBActRatio.UseVisualStyleBackColor = False
        '
        'CBMKTLess
        '
        Me.CBMKTLess.AutoSize = True
        Me.CBMKTLess.BackColor = System.Drawing.Color.White
        Me.CBMKTLess.Location = New System.Drawing.Point(279, 46)
        Me.CBMKTLess.Name = "CBMKTLess"
        Me.CBMKTLess.Size = New System.Drawing.Size(105, 19)
        Me.CBMKTLess.TabIndex = 7
        Me.CBMKTLess.Text = "Market Value <"
        Me.CBMKTLess.UseVisualStyleBackColor = False
        '
        'CBMktMore
        '
        Me.CBMktMore.AutoSize = True
        Me.CBMktMore.BackColor = System.Drawing.Color.White
        Me.CBMktMore.Location = New System.Drawing.Point(279, 19)
        Me.CBMktMore.Name = "CBMktMore"
        Me.CBMktMore.Size = New System.Drawing.Size(105, 19)
        Me.CBMktMore.TabIndex = 3
        Me.CBMktMore.Text = "Market Value >"
        Me.CBMktMore.UseVisualStyleBackColor = False
        '
        'CBdr
        '
        Me.CBdr.AutoSize = True
        Me.CBdr.BackColor = System.Drawing.Color.White
        Me.CBdr.Location = New System.Drawing.Point(17, 46)
        Me.CBdr.Name = "CBdr"
        Me.CBdr.Size = New System.Drawing.Size(113, 19)
        Me.CBdr.TabIndex = 5
        Me.CBdr.Text = "Debit Balance >"
        Me.CBdr.UseVisualStyleBackColor = False
        '
        'CBcr
        '
        Me.CBcr.AutoSize = True
        Me.CBcr.BackColor = System.Drawing.Color.White
        Me.CBcr.Location = New System.Drawing.Point(17, 19)
        Me.CBcr.Name = "CBcr"
        Me.CBcr.Size = New System.Drawing.Size(117, 19)
        Me.CBcr.TabIndex = 1
        Me.CBcr.Text = "Credit Balance >"
        Me.CBcr.UseVisualStyleBackColor = False
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Linen
        Me.TabPage3.Controls.Add(Me.BtnPrint)
        Me.TabPage3.Controls.Add(Me.GroupBox2)
        Me.TabPage3.Controls.Add(Me.Label5)
        Me.TabPage3.Controls.Add(Me.Label6)
        Me.TabPage3.Controls.Add(Me.CboFrm)
        Me.TabPage3.Controls.Add(Me.CboTo)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(613, 386)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "   Print    "
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'BtnPrint
        '
        Me.BtnPrint.Image = Global.ESL.My.Resources.Resources.Printer
        Me.BtnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnPrint.Location = New System.Drawing.Point(277, 235)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(55, 53)
        Me.BtnPrint.TabIndex = 2
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.White
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(131, 144)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(348, 68)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(181, 30)
        Me.RBPrint.Name = "RBPrint"
        Me.RBPrint.Size = New System.Drawing.Size(108, 19)
        Me.RBPrint.TabIndex = 1
        Me.RBPrint.Text = "Direct to printer"
        Me.RBPrint.UseVisualStyleBackColor = True
        '
        'RBPreview
        '
        Me.RBPreview.AutoSize = True
        Me.RBPreview.Checked = True
        Me.RBPreview.Location = New System.Drawing.Point(69, 30)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BackColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(327, 99)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(20, 15)
        Me.Label5.TabIndex = 20
        Me.Label5.Text = "To"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(128, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 15)
        Me.Label6.TabIndex = 19
        Me.Label6.Text = "Runner Code"
        '
        'CboFrm
        '
        Me.CboFrm.BackColor = System.Drawing.SystemColors.Window
        Me.CboFrm.FormattingEnabled = True
        Me.CboFrm.Location = New System.Drawing.Point(215, 96)
        Me.CboFrm.Name = "CboFrm"
        Me.CboFrm.Size = New System.Drawing.Size(106, 23)
        Me.CboFrm.TabIndex = 0
        '
        'CboTo
        '
        Me.CboTo.FormattingEnabled = True
        Me.CboTo.Location = New System.Drawing.Point(354, 96)
        Me.CboTo.Name = "CboTo"
        Me.CboTo.Size = New System.Drawing.Size(121, 23)
        Me.CboTo.TabIndex = 1
        '
        'TabPage4
        '
        Me.TabPage4.BackColor = System.Drawing.Color.Linen
        Me.TabPage4.Controls.Add(Me.txtClientCode)
        Me.TabPage4.Controls.Add(Me.Label9)
        Me.TabPage4.Controls.Add(Me.BtnSearch)
        Me.TabPage4.Controls.Add(Me.Label8)
        Me.TabPage4.Controls.Add(Me.Label7)
        Me.TabPage4.Controls.Add(Me.txtClientName)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage4.Size = New System.Drawing.Size(613, 386)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "  Find  "
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'txtClientCode
        '
        Me.txtClientCode.Location = New System.Drawing.Point(191, 99)
        Me.txtClientCode.MaxLength = 8
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(100, 21)
        Me.txtClientCode.TabIndex = 0
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.BackColor = System.Drawing.Color.White
        Me.Label9.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(188, 41)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(233, 19)
        Me.Label9.TabIndex = 4
        Me.Label9.Text = "SEARCH CRC MARGIN CALL"
        '
        'BtnSearch
        '
        Me.BtnSearch.Image = Global.ESL.My.Resources.Resources.Find
        Me.BtnSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnSearch.Location = New System.Drawing.Point(233, 198)
        Me.BtnSearch.Name = "BtnSearch"
        Me.BtnSearch.Size = New System.Drawing.Size(58, 54)
        Me.BtnSearch.TabIndex = 2
        Me.BtnSearch.Text = "Search"
        Me.BtnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnSearch.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.BackColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(115, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 15)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Client Name"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.BackColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(115, 99)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 15)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Client Code"
        '
        'txtClientName
        '
        Me.txtClientName.Location = New System.Drawing.Point(191, 137)
        Me.txtClientName.Name = "txtClientName"
        Me.txtClientName.Size = New System.Drawing.Size(286, 21)
        Me.txtClientName.TabIndex = 1
        '
        'TabPage5
        '
        Me.TabPage5.BackColor = System.Drawing.Color.Linen
        Me.TabPage5.Controls.Add(Me.Label10)
        Me.TabPage5.Controls.Add(Me.tbExport)
        Me.TabPage5.Controls.Add(Me.BtnExport)
        Me.TabPage5.Location = New System.Drawing.Point(4, 24)
        Me.TabPage5.Name = "TabPage5"
        Me.TabPage5.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage5.Size = New System.Drawing.Size(613, 386)
        Me.TabPage5.TabIndex = 4
        Me.TabPage5.Text = "   Export   "
        Me.TabPage5.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.BackColor = System.Drawing.Color.White
        Me.Label10.Location = New System.Drawing.Point(142, 136)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 15)
        Me.Label10.TabIndex = 25
        Me.Label10.Text = "Export File"
        '
        'tbExport
        '
        Me.tbExport.Location = New System.Drawing.Point(222, 133)
        Me.tbExport.Name = "tbExport"
        Me.tbExport.ReadOnly = True
        Me.tbExport.Size = New System.Drawing.Size(271, 21)
        Me.tbExport.TabIndex = 24
        '
        'BtnExport
        '
        Me.BtnExport.Image = Global.ESL.My.Resources.Resources.export
        Me.BtnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BtnExport.Location = New System.Drawing.Point(282, 174)
        Me.BtnExport.Name = "BtnExport"
        Me.BtnExport.Size = New System.Drawing.Size(57, 55)
        Me.BtnExport.TabIndex = 23
        Me.BtnExport.Text = "Export"
        Me.BtnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnExport.UseVisualStyleBackColor = True
        '
        'TabPage6
        '
        Me.TabPage6.Controls.Add(Me.btnEdit)
        Me.TabPage6.Controls.Add(Me.btnCancel2)
        Me.TabPage6.Controls.Add(Me.btnStore)
        Me.TabPage6.Controls.Add(Me.txtFilter)
        Me.TabPage6.Location = New System.Drawing.Point(4, 24)
        Me.TabPage6.Name = "TabPage6"
        Me.TabPage6.Size = New System.Drawing.Size(613, 386)
        Me.TabPage6.TabIndex = 5
        Me.TabPage6.Text = "  Filter  "
        Me.TabPage6.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Image = Global.ESL.My.Resources.Resources.btnEdit_Image
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(223, 283)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(57, 55)
        Me.btnEdit.TabIndex = 26
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnCancel2
        '
        Me.btnCancel2.Enabled = False
        Me.btnCancel2.Image = Global.ESL.My.Resources.Resources.back
        Me.btnCancel2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnCancel2.Location = New System.Drawing.Point(349, 283)
        Me.btnCancel2.Name = "btnCancel2"
        Me.btnCancel2.Size = New System.Drawing.Size(57, 55)
        Me.btnCancel2.TabIndex = 25
        Me.btnCancel2.Text = "Cancel"
        Me.btnCancel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnCancel2.UseVisualStyleBackColor = True
        '
        'btnStore
        '
        Me.btnStore.Enabled = False
        Me.btnStore.Image = Global.ESL.My.Resources.Resources.document_save
        Me.btnStore.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnStore.Location = New System.Drawing.Point(286, 283)
        Me.btnStore.Name = "btnStore"
        Me.btnStore.Size = New System.Drawing.Size(57, 55)
        Me.btnStore.TabIndex = 24
        Me.btnStore.Text = "Store"
        Me.btnStore.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnStore.UseVisualStyleBackColor = True
        '
        'txtFilter
        '
        Me.txtFilter.Enabled = False
        Me.txtFilter.Location = New System.Drawing.Point(10, 13)
        Me.txtFilter.Multiline = True
        Me.txtFilter.Name = "txtFilter"
        Me.txtFilter.Size = New System.Drawing.Size(591, 264)
        Me.txtFilter.TabIndex = 0
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(16, 443)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(360, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 24
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(13, 421)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 25
        Me.lblProcess.Text = "Processing"
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'FrmLiqList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(626, 476)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.KeyPreview = True
        Me.Name = "FrmLiqList"
        Me.Text = "New Liquidation Listing"
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.DtgDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DtgTotal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.AmtOSDay, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtOverDraft, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Amttotal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtLimit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtUndue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtFutures, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtDue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtMarRatio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtActRatio, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtMktLess, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtMktMore, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtDR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AmtCR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.TabPage5.ResumeLayout(False)
        Me.TabPage5.PerformLayout()
        Me.TabPage6.ResumeLayout(False)
        Me.TabPage6.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents DtgDetail As System.Windows.Forms.DataGridView
    Friend WithEvents RBAll As ESL.myRadioButton
    Friend WithEvents DtgTotal As System.Windows.Forms.DataGridView
    Friend WithEvents RBFinance As ESL.myRadioButton
    Friend WithEvents RBMargin As ESL.myRadioButton
    Friend WithEvents RBCash As ESL.myRadioButton
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnPrc As ESL.myButton
    Friend WithEvents RBTypeCash As ESL.myRadioButton
    Friend WithEvents RBTypeMargin As ESL.myRadioButton
    Friend WithEvents CBType As System.Windows.Forms.CheckBox
    Friend WithEvents CBOSDay As System.Windows.Forms.CheckBox
    Friend WithEvents txtName As ESL.myTextbox
    Friend WithEvents CBName As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtClientTo As ESL.myTextbox
    Friend WithEvents txtClientFrom As ESL.myTextbox
    Friend WithEvents CBClient As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents CboRunTo As ESL.myComboBox
    Friend WithEvents CBRunner As System.Windows.Forms.CheckBox
    Friend WithEvents CBoRunFrom As ESL.myComboBox
    Friend WithEvents CBOverDraft As System.Windows.Forms.CheckBox
    Friend WithEvents CBTotal As System.Windows.Forms.CheckBox
    Friend WithEvents CBLimit As System.Windows.Forms.CheckBox
    Friend WithEvents CBUndue As System.Windows.Forms.CheckBox
    Friend WithEvents CBFutures As System.Windows.Forms.CheckBox
    Friend WithEvents CBDue As System.Windows.Forms.CheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBMarRatio As System.Windows.Forms.CheckBox
    Friend WithEvents CBActRatio As System.Windows.Forms.CheckBox
    Friend WithEvents CBMKTLess As System.Windows.Forms.CheckBox
    Friend WithEvents CBMktMore As System.Windows.Forms.CheckBox
    Friend WithEvents CBdr As System.Windows.Forms.CheckBox
    Friend WithEvents CBcr As System.Windows.Forms.CheckBox
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents BtnPrint As ESL.myButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents CboFrm As ESL.myComboBox
    Friend WithEvents CboTo As ESL.myComboBox
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents txtClientCode As ESL.myTextbox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents BtnSearch As ESL.myButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtClientName As ESL.myTextbox
    Friend WithEvents TabPage5 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents tbExport As ESL.myTextbox
    Friend WithEvents BtnExport As ESL.myButton
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents TabPage6 As System.Windows.Forms.TabPage
    Friend WithEvents txtFilter As ESL.myTextbox
    Friend WithEvents btnCancel2 As ESL.myButton
    Friend WithEvents btnStore As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents AmtCR As ESL.myNumericUpDown
    Friend WithEvents AmtDR As ESL.myNumericUpDown
    Friend WithEvents AmtMktLess As ESL.myNumericUpDown
    Friend WithEvents AmtMktMore As ESL.myNumericUpDown
    Friend WithEvents AmtActRatio As ESL.myNumericUpDown
    Friend WithEvents AmtMarRatio As ESL.myNumericUpDown
    Friend WithEvents AmtFutures As ESL.myNumericUpDown
    Friend WithEvents AmtDue As ESL.myNumericUpDown
    Friend WithEvents AmtLimit As ESL.myNumericUpDown
    Friend WithEvents AmtUndue As ESL.myNumericUpDown
    Friend WithEvents AmtOSDay As ESL.myNumericUpDown
    Friend WithEvents AmtOverDraft As ESL.myNumericUpDown
    Friend WithEvents Amttotal As ESL.myNumericUpDown
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn6 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn7 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn8 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn9 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn10 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn11 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn12 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn13 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AE As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Client As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dr_bal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mkt_val As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents act_ratio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents mc_act_ratio As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents due As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents undue As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents total As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents os_day As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents net_trade As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cr_limit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Client_Name As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
