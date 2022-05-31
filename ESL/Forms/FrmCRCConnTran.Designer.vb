<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCRCConnTran
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
        Me.tcClient = New System.Windows.Forms.TabControl
        Me.tpGroup = New System.Windows.Forms.TabPage
        Me.PrintOption = New System.Windows.Forms.GroupBox
        Me.rbtPrint = New ESL.myRadioButton(Me.components)
        Me.rbtPreview = New ESL.myRadioButton(Me.components)
        Me.lblAccCount = New System.Windows.Forms.Label
        Me.btnExportIPO = New ESL.myButton(Me.components)
        Me.btnExportAva = New ESL.myButton(Me.components)
        Me.btnExportLgr = New ESL.myButton(Me.components)
        Me.btnPrintIPO = New ESL.myButton(Me.components)
        Me.lbGroup = New ESL.myListBox(Me.components)
        Me.btnPrintAva = New ESL.myButton(Me.components)
        Me.btnPrintLgr = New ESL.myButton(Me.components)
        Me.lbClient = New ESL.myListBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.tpIPO = New System.Windows.Forms.TabPage
        Me.btnGet = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.nupMonth = New System.Windows.Forms.NumericUpDown
        Me.nupYear = New System.Windows.Forms.NumericUpDown
        Me.lblIPOTotal = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtClientTo = New System.Windows.Forms.TextBox
        Me.txtClientFrom = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.dtgIPO = New System.Windows.Forms.DataGridView
        Me.client_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.loan_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ipo_loan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tpAdd = New System.Windows.Forms.TabPage
        Me.MyButton1 = New ESL.myButton(Me.components)
        Me.dpDate = New ESL.myDateTimePicker
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtIPO = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtClient = New ESL.myTextbox
        Me.Label11 = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.tcClient.SuspendLayout()
        Me.tpGroup.SuspendLayout()
        Me.PrintOption.SuspendLayout()
        Me.tpIPO.SuspendLayout()
        CType(Me.nupMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nupYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgIPO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAdd.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(512, 441)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(456, 441)
        Me.btnSave.TabIndex = 1
        '
        'tcClient
        '
        Me.tcClient.Controls.Add(Me.tpGroup)
        Me.tcClient.Controls.Add(Me.tpIPO)
        Me.tcClient.Controls.Add(Me.tpAdd)
        Me.tcClient.Location = New System.Drawing.Point(37, 86)
        Me.tcClient.Name = "tcClient"
        Me.tcClient.SelectedIndex = 0
        Me.tcClient.Size = New System.Drawing.Size(529, 336)
        Me.tcClient.TabIndex = 0
        '
        'tpGroup
        '
        Me.tpGroup.Controls.Add(Me.PrintOption)
        Me.tpGroup.Controls.Add(Me.lblAccCount)
        Me.tpGroup.Controls.Add(Me.btnExportIPO)
        Me.tpGroup.Controls.Add(Me.btnExportAva)
        Me.tpGroup.Controls.Add(Me.btnExportLgr)
        Me.tpGroup.Controls.Add(Me.btnPrintIPO)
        Me.tpGroup.Controls.Add(Me.lbGroup)
        Me.tpGroup.Controls.Add(Me.btnPrintAva)
        Me.tpGroup.Controls.Add(Me.btnPrintLgr)
        Me.tpGroup.Controls.Add(Me.lbClient)
        Me.tpGroup.Controls.Add(Me.Label2)
        Me.tpGroup.Controls.Add(Me.Label1)
        Me.tpGroup.Location = New System.Drawing.Point(4, 24)
        Me.tpGroup.Name = "tpGroup"
        Me.tpGroup.Padding = New System.Windows.Forms.Padding(3)
        Me.tpGroup.Size = New System.Drawing.Size(521, 308)
        Me.tpGroup.TabIndex = 0
        Me.tpGroup.Text = "Group List"
        Me.tpGroup.UseVisualStyleBackColor = True
        '
        'PrintOption
        '
        Me.PrintOption.Controls.Add(Me.rbtPrint)
        Me.PrintOption.Controls.Add(Me.rbtPreview)
        Me.PrintOption.Location = New System.Drawing.Point(341, 35)
        Me.PrintOption.Name = "PrintOption"
        Me.PrintOption.Size = New System.Drawing.Size(162, 45)
        Me.PrintOption.TabIndex = 60
        Me.PrintOption.TabStop = False
        Me.PrintOption.Text = "Print / Preview"
        '
        'rbtPrint
        '
        Me.rbtPrint.AutoSize = True
        Me.rbtPrint.Location = New System.Drawing.Point(107, 20)
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
        Me.rbtPreview.Location = New System.Drawing.Point(6, 20)
        Me.rbtPreview.Name = "rbtPreview"
        Me.rbtPreview.Size = New System.Drawing.Size(67, 19)
        Me.rbtPreview.TabIndex = 0
        Me.rbtPreview.TabStop = True
        Me.rbtPreview.Text = "preview"
        Me.rbtPreview.UseVisualStyleBackColor = True
        '
        'lblAccCount
        '
        Me.lblAccCount.AutoSize = True
        Me.lblAccCount.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAccCount.Location = New System.Drawing.Point(186, 280)
        Me.lblAccCount.Name = "lblAccCount"
        Me.lblAccCount.Size = New System.Drawing.Size(0, 14)
        Me.lblAccCount.TabIndex = 22
        '
        'btnExportIPO
        '
        Me.btnExportIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportIPO.Location = New System.Drawing.Point(453, 222)
        Me.btnExportIPO.Name = "btnExportIPO"
        Me.btnExportIPO.Size = New System.Drawing.Size(50, 55)
        Me.btnExportIPO.TabIndex = 21
        Me.btnExportIPO.Text = "Export IPO"
        Me.btnExportIPO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportIPO.UseVisualStyleBackColor = True
        '
        'btnExportAva
        '
        Me.btnExportAva.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportAva.Location = New System.Drawing.Point(397, 222)
        Me.btnExportAva.Name = "btnExportAva"
        Me.btnExportAva.Size = New System.Drawing.Size(48, 55)
        Me.btnExportAva.TabIndex = 20
        Me.btnExportAva.Text = "Export Ava Bal"
        Me.btnExportAva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportAva.UseVisualStyleBackColor = True
        '
        'btnExportLgr
        '
        Me.btnExportLgr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExportLgr.Location = New System.Drawing.Point(341, 222)
        Me.btnExportLgr.Name = "btnExportLgr"
        Me.btnExportLgr.Size = New System.Drawing.Size(50, 55)
        Me.btnExportLgr.TabIndex = 19
        Me.btnExportLgr.Text = "Export Lgr Bal"
        Me.btnExportLgr.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExportLgr.UseVisualStyleBackColor = True
        '
        'btnPrintIPO
        '
        Me.btnPrintIPO.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintIPO.Location = New System.Drawing.Point(453, 161)
        Me.btnPrintIPO.Name = "btnPrintIPO"
        Me.btnPrintIPO.Size = New System.Drawing.Size(50, 55)
        Me.btnPrintIPO.TabIndex = 18
        Me.btnPrintIPO.Text = "Print IPO"
        Me.btnPrintIPO.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrintIPO.UseVisualStyleBackColor = True
        '
        'lbGroup
        '
        Me.lbGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbGroup.FormattingEnabled = True
        Me.lbGroup.ItemHeight = 14
        Me.lbGroup.Location = New System.Drawing.Point(23, 35)
        Me.lbGroup.Name = "lbGroup"
        Me.lbGroup.Size = New System.Drawing.Size(149, 242)
        Me.lbGroup.TabIndex = 0
        '
        'btnPrintAva
        '
        Me.btnPrintAva.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintAva.Location = New System.Drawing.Point(397, 161)
        Me.btnPrintAva.Name = "btnPrintAva"
        Me.btnPrintAva.Size = New System.Drawing.Size(50, 55)
        Me.btnPrintAva.TabIndex = 17
        Me.btnPrintAva.Text = "Print Ava Bal"
        Me.btnPrintAva.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrintAva.UseVisualStyleBackColor = True
        '
        'btnPrintLgr
        '
        Me.btnPrintLgr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrintLgr.Location = New System.Drawing.Point(341, 161)
        Me.btnPrintLgr.Name = "btnPrintLgr"
        Me.btnPrintLgr.Size = New System.Drawing.Size(50, 55)
        Me.btnPrintLgr.TabIndex = 16
        Me.btnPrintLgr.Text = "Print Lgr Bal"
        Me.btnPrintLgr.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrintLgr.UseVisualStyleBackColor = True
        '
        'lbClient
        '
        Me.lbClient.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbClient.FormattingEnabled = True
        Me.lbClient.ItemHeight = 14
        Me.lbClient.Location = New System.Drawing.Point(189, 35)
        Me.lbClient.Name = "lbClient"
        Me.lbClient.Size = New System.Drawing.Size(135, 242)
        Me.lbClient.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(186, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 14)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Client"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(20, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 14)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Group"
        '
        'tpIPO
        '
        Me.tpIPO.Controls.Add(Me.btnGet)
        Me.tpIPO.Controls.Add(Me.btnDelete)
        Me.tpIPO.Controls.Add(Me.Label15)
        Me.tpIPO.Controls.Add(Me.Label14)
        Me.tpIPO.Controls.Add(Me.nupMonth)
        Me.tpIPO.Controls.Add(Me.nupYear)
        Me.tpIPO.Controls.Add(Me.lblIPOTotal)
        Me.tpIPO.Controls.Add(Me.Label12)
        Me.tpIPO.Controls.Add(Me.txtClientTo)
        Me.tpIPO.Controls.Add(Me.txtClientFrom)
        Me.tpIPO.Controls.Add(Me.Label10)
        Me.tpIPO.Controls.Add(Me.Label9)
        Me.tpIPO.Controls.Add(Me.Label8)
        Me.tpIPO.Controls.Add(Me.dtgIPO)
        Me.tpIPO.Location = New System.Drawing.Point(4, 24)
        Me.tpIPO.Name = "tpIPO"
        Me.tpIPO.Padding = New System.Windows.Forms.Padding(3)
        Me.tpIPO.Size = New System.Drawing.Size(521, 308)
        Me.tpIPO.TabIndex = 1
        Me.tpIPO.Text = "IPO Client List"
        Me.tpIPO.UseVisualStyleBackColor = True
        '
        'btnGet
        '
        Me.btnGet.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGet.Location = New System.Drawing.Point(391, 232)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(50, 55)
        Me.btnGet.TabIndex = 5
        Me.btnGet.Text = "Get Record"
        Me.btnGet.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnGet.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(447, 232)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 6
        Me.btnDelete.Text = "Delete Record"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(326, 229)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 15)
        Me.Label15.TabIndex = 11
        Me.Label15.Text = "Month"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(208, 229)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(32, 15)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "Year"
        '
        'nupMonth
        '
        Me.nupMonth.Location = New System.Drawing.Point(246, 227)
        Me.nupMonth.Name = "nupMonth"
        Me.nupMonth.Size = New System.Drawing.Size(74, 21)
        Me.nupMonth.TabIndex = 2
        Me.nupMonth.Value = New Decimal(New Integer() {88, 0, 0, 0})
        '
        'nupYear
        '
        Me.nupYear.Location = New System.Drawing.Point(128, 227)
        Me.nupYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.nupYear.Name = "nupYear"
        Me.nupYear.Size = New System.Drawing.Size(74, 21)
        Me.nupYear.TabIndex = 1
        Me.nupYear.Value = New Decimal(New Integer() {8888, 0, 0, 0})
        '
        'lblIPOTotal
        '
        Me.lblIPOTotal.AutoSize = True
        Me.lblIPOTotal.Location = New System.Drawing.Point(125, 193)
        Me.lblIPOTotal.Name = "lblIPOTotal"
        Me.lblIPOTotal.Size = New System.Drawing.Size(67, 15)
        Me.lblIPOTotal.TabIndex = 7
        Me.lblIPOTotal.Text = "lblIPOTotal"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(234, 268)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(21, 15)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "To"
        '
        'txtClientTo
        '
        Me.txtClientTo.Location = New System.Drawing.Point(261, 265)
        Me.txtClientTo.Name = "txtClientTo"
        Me.txtClientTo.Size = New System.Drawing.Size(100, 21)
        Me.txtClientTo.TabIndex = 4
        '
        'txtClientFrom
        '
        Me.txtClientFrom.Location = New System.Drawing.Point(128, 265)
        Me.txtClientFrom.Name = "txtClientFrom"
        Me.txtClientFrom.Size = New System.Drawing.Size(100, 21)
        Me.txtClientFrom.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(21, 268)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 15)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Client Range"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(21, 229)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(33, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Date"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(21, 193)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(84, 15)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "IPO loan Total"
        '
        'dtgIPO
        '
        Me.dtgIPO.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgIPO.ColumnHeadersHeight = 20
        Me.dtgIPO.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.client_code, Me.loan_date, Me.ipo_loan})
        Me.dtgIPO.GridColor = System.Drawing.Color.Linen
        Me.dtgIPO.Location = New System.Drawing.Point(24, 22)
        Me.dtgIPO.MultiSelect = False
        Me.dtgIPO.Name = "dtgIPO"
        Me.dtgIPO.ReadOnly = True
        Me.dtgIPO.RowHeadersVisible = False
        Me.dtgIPO.RowTemplate.Height = 24
        Me.dtgIPO.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgIPO.Size = New System.Drawing.Size(473, 168)
        Me.dtgIPO.TabIndex = 0
        '
        'client_code
        '
        Me.client_code.DataPropertyName = "client_code"
        Me.client_code.HeaderText = "Client"
        Me.client_code.Name = "client_code"
        Me.client_code.ReadOnly = True
        '
        'loan_date
        '
        Me.loan_date.DataPropertyName = "loan_date"
        Me.loan_date.HeaderText = "Date"
        Me.loan_date.Name = "loan_date"
        Me.loan_date.ReadOnly = True
        '
        'ipo_loan
        '
        Me.ipo_loan.DataPropertyName = "ipo_loan"
        Me.ipo_loan.HeaderText = "IPO"
        Me.ipo_loan.Name = "ipo_loan"
        Me.ipo_loan.ReadOnly = True
        '
        'tpAdd
        '
        Me.tpAdd.Controls.Add(Me.MyButton1)
        Me.tpAdd.Controls.Add(Me.dpDate)
        Me.tpAdd.Controls.Add(Me.Label7)
        Me.tpAdd.Controls.Add(Me.Label6)
        Me.tpAdd.Controls.Add(Me.txtIPO)
        Me.tpAdd.Controls.Add(Me.Label5)
        Me.tpAdd.Controls.Add(Me.txtClient)
        Me.tpAdd.Location = New System.Drawing.Point(4, 24)
        Me.tpAdd.Name = "tpAdd"
        Me.tpAdd.Padding = New System.Windows.Forms.Padding(3)
        Me.tpAdd.Size = New System.Drawing.Size(521, 308)
        Me.tpAdd.TabIndex = 2
        Me.tpAdd.Text = "Add IPO Client"
        Me.tpAdd.UseVisualStyleBackColor = True
        '
        'MyButton1
        '
        Me.MyButton1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyButton1.Location = New System.Drawing.Point(187, 199)
        Me.MyButton1.Name = "MyButton1"
        Me.MyButton1.Size = New System.Drawing.Size(50, 55)
        Me.MyButton1.TabIndex = 6
        Me.MyButton1.Text = "Save"
        Me.MyButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MyButton1.UseVisualStyleBackColor = True
        '
        'dpDate
        '
        Me.dpDate.CustomFormat = "dd/MM/yyyy"
        Me.dpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpDate.Location = New System.Drawing.Point(125, 89)
        Me.dpDate.Name = "dpDate"
        Me.dpDate.Size = New System.Drawing.Size(112, 21)
        Me.dpDate.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(26, 146)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(27, 15)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "IPO"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(26, 92)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(33, 15)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Date"
        '
        'txtIPO
        '
        Me.txtIPO.Location = New System.Drawing.Point(125, 143)
        Me.txtIPO.Name = "txtIPO"
        Me.txtIPO.Size = New System.Drawing.Size(112, 21)
        Me.txtIPO.TabIndex = 5
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 0
        Me.Label5.Text = "Client Code"
        '
        'txtClient
        '
        Me.txtClient.Location = New System.Drawing.Point(125, 37)
        Me.txtClient.Name = "txtClient"
        Me.txtClient.Size = New System.Drawing.Size(112, 21)
        Me.txtClient.TabIndex = 1
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(132, 33)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(341, 22)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "CRC Connected Transaction Report"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(37, 481)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(289, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 59
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(34, 463)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 58
        Me.lblProcess.Text = "Processing"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmCRCConnTran
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(604, 535)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.tcClient)
        Me.KeyPreview = True
        Me.Name = "FrmCRCConnTran"
        Me.Text = "CRC Connected Transaction Report"
        Me.Controls.SetChildIndex(Me.tcClient, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.tcClient.ResumeLayout(False)
        Me.tpGroup.ResumeLayout(False)
        Me.tpGroup.PerformLayout()
        Me.PrintOption.ResumeLayout(False)
        Me.PrintOption.PerformLayout()
        Me.tpIPO.ResumeLayout(False)
        Me.tpIPO.PerformLayout()
        CType(Me.nupMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nupYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgIPO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAdd.ResumeLayout(False)
        Me.tpAdd.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tcClient As System.Windows.Forms.TabControl
    Friend WithEvents tpGroup As System.Windows.Forms.TabPage
    Friend WithEvents tpIPO As System.Windows.Forms.TabPage
    Friend WithEvents tpAdd As System.Windows.Forms.TabPage
    Friend WithEvents lbGroup As ESL.myListBox
    Friend WithEvents lbClient As ESL.myListBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExportIPO As ESL.myButton
    Friend WithEvents btnExportAva As ESL.myButton
    Friend WithEvents btnExportLgr As ESL.myButton
    Friend WithEvents btnPrintIPO As ESL.myButton
    Friend WithEvents btnPrintAva As ESL.myButton
    Friend WithEvents btnPrintLgr As ESL.myButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtClient As ESL.myTextbox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtIPO As ESL.myTextbox
    Friend WithEvents dpDate As ESL.myDateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents nupMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents nupYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblIPOTotal As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtClientTo As System.Windows.Forms.TextBox
    Friend WithEvents txtClientFrom As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dtgIPO As System.Windows.Forms.DataGridView
    Friend WithEvents MyButton1 As ESL.myButton
    Friend WithEvents lblAccCount As System.Windows.Forms.Label
    Friend WithEvents btnGet As ESL.myButton
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents client_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents loan_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ipo_loan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents PrintOption As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPrint As ESL.myRadioButton
    Friend WithEvents rbtPreview As ESL.myRadioButton
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog

End Class
