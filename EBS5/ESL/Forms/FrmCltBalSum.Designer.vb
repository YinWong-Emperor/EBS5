<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCltBalSum
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.cbClient = New ESL.myCheckBox(Me.components)
        Me.cbAE = New ESL.myCheckBox(Me.components)
        Me.cbActualRatio = New ESL.myCheckBox(Me.components)
        Me.cbDRBal = New ESL.myCheckBox(Me.components)
        Me.cbSuspended = New ESL.myCheckBox(Me.components)
        Me.cbClosed = New ESL.myCheckBox(Me.components)
        Me.cbAllZero = New ESL.myCheckBox(Me.components)
        Me.txtClientFrom = New ESL.myTextbox
        Me.txtClientTo = New ESL.myTextbox
        Me.comboAEFrom = New ESL.myComboBox(Me.components)
        Me.comboAETo = New ESL.myComboBox(Me.components)
        Me.rbPrinter = New ESL.myRadioButton(Me.components)
        Me.rbPreview = New ESL.myRadioButton(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.rbSortDrBal = New ESL.myRadioButton(Me.components)
        Me.rbSortAE = New ESL.myRadioButton(Me.components)
        Me.rbSortClient = New ESL.myRadioButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbExcel = New ESL.myRadioButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cbSummary = New System.Windows.Forms.CheckBox
        Me.txtDR = New ESL.myNumericBox
        Me.txtAR = New ESL.myNumericBox
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgvMiscValue = New System.Windows.Forms.DataGridView
        Me.code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.descpt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtDisplay = New ESL.myTextbox
        Me.txtName = New ESL.myTextbox
        Me.dgvMiscList = New System.Windows.Forms.DataGridView
        Me.misc_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.misc_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtEndor2 = New ESL.myTextbox
        Me.txtEndor1 = New ESL.myTextbox
        Me.txtNoted3 = New ESL.myTextbox
        Me.txtNoted1 = New ESL.myTextbox
        Me.txtNoted2 = New ESL.myTextbox
        Me.txtRegard = New ESL.myTextbox
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvMiscValue, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMiscList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(494, 560)
        Me.btnCancel.TabIndex = 6
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(438, 560)
        Me.btnSave.TabIndex = 4
        '
        'cbClient
        '
        Me.cbClient.AutoSize = True
        Me.cbClient.Location = New System.Drawing.Point(123, 21)
        Me.cbClient.Name = "cbClient"
        Me.cbClient.Size = New System.Drawing.Size(58, 19)
        Me.cbClient.TabIndex = 0
        Me.cbClient.Text = "Client"
        Me.cbClient.UseVisualStyleBackColor = True
        '
        'cbAE
        '
        Me.cbAE.AutoSize = True
        Me.cbAE.Location = New System.Drawing.Point(123, 46)
        Me.cbAE.Name = "cbAE"
        Me.cbAE.Size = New System.Drawing.Size(74, 19)
        Me.cbAE.TabIndex = 3
        Me.cbAE.Text = "AE Code"
        Me.cbAE.UseVisualStyleBackColor = True
        '
        'cbActualRatio
        '
        Me.cbActualRatio.AutoSize = True
        Me.cbActualRatio.Location = New System.Drawing.Point(123, 71)
        Me.cbActualRatio.Name = "cbActualRatio"
        Me.cbActualRatio.Size = New System.Drawing.Size(104, 19)
        Me.cbActualRatio.TabIndex = 6
        Me.cbActualRatio.Text = "Actual Ratio > "
        Me.cbActualRatio.UseVisualStyleBackColor = True
        '
        'cbDRBal
        '
        Me.cbDRBal.AutoSize = True
        Me.cbDRBal.Location = New System.Drawing.Point(123, 96)
        Me.cbDRBal.Name = "cbDRBal"
        Me.cbDRBal.Size = New System.Drawing.Size(105, 19)
        Me.cbDRBal.TabIndex = 8
        Me.cbDRBal.Text = "DR Balance > "
        Me.cbDRBal.UseVisualStyleBackColor = True
        '
        'cbSuspended
        '
        Me.cbSuspended.AutoSize = True
        Me.cbSuspended.Checked = True
        Me.cbSuspended.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSuspended.Location = New System.Drawing.Point(123, 121)
        Me.cbSuspended.Name = "cbSuspended"
        Me.cbSuspended.Size = New System.Drawing.Size(154, 19)
        Me.cbSuspended.TabIndex = 10
        Me.cbSuspended.Text = "Include Suspend Client"
        Me.cbSuspended.UseVisualStyleBackColor = True
        '
        'cbClosed
        '
        Me.cbClosed.AutoSize = True
        Me.cbClosed.Location = New System.Drawing.Point(123, 146)
        Me.cbClosed.Name = "cbClosed"
        Me.cbClosed.Size = New System.Drawing.Size(144, 19)
        Me.cbClosed.TabIndex = 11
        Me.cbClosed.Text = "Include Closed Client"
        Me.cbClosed.UseVisualStyleBackColor = True
        '
        'cbAllZero
        '
        Me.cbAllZero.AutoSize = True
        Me.cbAllZero.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbAllZero.Location = New System.Drawing.Point(123, 171)
        Me.cbAllZero.Name = "cbAllZero"
        Me.cbAllZero.Size = New System.Drawing.Size(233, 34)
        Me.cbAllZero.TabIndex = 12
        Me.cbAllZero.Text = "Include All Zero (Avalible Balance = 0, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Ledger Balance = 0 and Interest = 0)"
        Me.cbAllZero.UseVisualStyleBackColor = True
        '
        'txtClientFrom
        '
        Me.txtClientFrom.Enabled = False
        Me.txtClientFrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientFrom.Location = New System.Drawing.Point(240, 19)
        Me.txtClientFrom.MaxLength = 8
        Me.txtClientFrom.Name = "txtClientFrom"
        Me.txtClientFrom.Size = New System.Drawing.Size(104, 21)
        Me.txtClientFrom.TabIndex = 1
        '
        'txtClientTo
        '
        Me.txtClientTo.Enabled = False
        Me.txtClientTo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtClientTo.Location = New System.Drawing.Point(377, 19)
        Me.txtClientTo.Name = "txtClientTo"
        Me.txtClientTo.Size = New System.Drawing.Size(104, 21)
        Me.txtClientTo.TabIndex = 2
        '
        'comboAEFrom
        '
        Me.comboAEFrom.Enabled = False
        Me.comboAEFrom.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAEFrom.FormattingEnabled = True
        Me.comboAEFrom.Location = New System.Drawing.Point(240, 43)
        Me.comboAEFrom.Name = "comboAEFrom"
        Me.comboAEFrom.Size = New System.Drawing.Size(104, 23)
        Me.comboAEFrom.TabIndex = 4
        '
        'comboAETo
        '
        Me.comboAETo.Enabled = False
        Me.comboAETo.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.comboAETo.FormattingEnabled = True
        Me.comboAETo.Location = New System.Drawing.Point(377, 43)
        Me.comboAETo.Name = "comboAETo"
        Me.comboAETo.Size = New System.Drawing.Size(104, 23)
        Me.comboAETo.TabIndex = 5
        '
        'rbPrinter
        '
        Me.rbPrinter.AutoSize = True
        Me.rbPrinter.Location = New System.Drawing.Point(123, 42)
        Me.rbPrinter.Name = "rbPrinter"
        Me.rbPrinter.Size = New System.Drawing.Size(157, 19)
        Me.rbPrinter.TabIndex = 1
        Me.rbPrinter.Text = "Send to Printer Directory"
        Me.rbPrinter.UseVisualStyleBackColor = True
        '
        'rbPreview
        '
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Checked = True
        Me.rbPreview.Location = New System.Drawing.Point(123, 17)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(143, 19)
        Me.rbPreview.TabIndex = 0
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Print Preview Window"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 32)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 23
        Me.Label3.Text = "Print Report"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(350, 47)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(21, 15)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(350, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(21, 15)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "To"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 110)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(87, 15)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Record Range"
        '
        'rbSortDrBal
        '
        Me.rbSortDrBal.AutoSize = True
        Me.rbSortDrBal.Location = New System.Drawing.Point(123, 68)
        Me.rbSortDrBal.Name = "rbSortDrBal"
        Me.rbSortDrBal.Size = New System.Drawing.Size(157, 19)
        Me.rbSortDrBal.TabIndex = 2
        Me.rbSortDrBal.Text = "Debit Bal + Margin Ratio"
        Me.rbSortDrBal.UseVisualStyleBackColor = True
        '
        'rbSortAE
        '
        Me.rbSortAE.AutoSize = True
        Me.rbSortAE.Location = New System.Drawing.Point(123, 43)
        Me.rbSortAE.Name = "rbSortAE"
        Me.rbSortAE.Size = New System.Drawing.Size(118, 19)
        Me.rbSortAE.TabIndex = 1
        Me.rbSortAE.Text = "AE + Client Code"
        Me.rbSortAE.UseVisualStyleBackColor = True
        '
        'rbSortClient
        '
        Me.rbSortClient.AutoSize = True
        Me.rbSortClient.Checked = True
        Me.rbSortClient.Location = New System.Drawing.Point(123, 18)
        Me.rbSortClient.Name = "rbSortClient"
        Me.rbSortClient.Size = New System.Drawing.Size(90, 19)
        Me.rbSortClient.TabIndex = 0
        Me.rbSortClient.TabStop = True
        Me.rbSortClient.Text = "Client Code"
        Me.rbSortClient.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(45, 15)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Sort By"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(116, 16)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(304, 22)
        Me.Label11.TabIndex = 40
        Me.Label11.Text = "Client Balance Summary Report"
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(438, 560)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 5
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbExcel)
        Me.GroupBox1.Controls.Add(Me.rbPrinter)
        Me.GroupBox1.Controls.Add(Me.rbPreview)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 361)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(498, 102)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'rbExcel
        '
        Me.rbExcel.AutoSize = True
        Me.rbExcel.Location = New System.Drawing.Point(123, 67)
        Me.rbExcel.Name = "rbExcel"
        Me.rbExcel.Size = New System.Drawing.Size(71, 19)
        Me.rbExcel.TabIndex = 2
        Me.rbExcel.Text = "To Excel"
        Me.rbExcel.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbSortDrBal)
        Me.GroupBox2.Controls.Add(Me.rbSortClient)
        Me.GroupBox2.Controls.Add(Me.rbSortAE)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 256)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(498, 99)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cbSummary)
        Me.GroupBox3.Controls.Add(Me.txtDR)
        Me.GroupBox3.Controls.Add(Me.txtAR)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.txtClientFrom)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cbAE)
        Me.GroupBox3.Controls.Add(Me.cbActualRatio)
        Me.GroupBox3.Controls.Add(Me.cbClient)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cbDRBal)
        Me.GroupBox3.Controls.Add(Me.comboAEFrom)
        Me.GroupBox3.Controls.Add(Me.cbAllZero)
        Me.GroupBox3.Controls.Add(Me.cbSuspended)
        Me.GroupBox3.Controls.Add(Me.comboAETo)
        Me.GroupBox3.Controls.Add(Me.txtClientTo)
        Me.GroupBox3.Controls.Add(Me.cbClosed)
        Me.GroupBox3.Location = New System.Drawing.Point(15, 6)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(498, 244)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'cbSummary
        '
        Me.cbSummary.AutoSize = True
        Me.cbSummary.Location = New System.Drawing.Point(123, 212)
        Me.cbSummary.Name = "cbSummary"
        Me.cbSummary.Size = New System.Drawing.Size(186, 19)
        Me.cbSummary.TabIndex = 13
        Me.cbSummary.Text = "Print AE and Group Summary"
        Me.cbSummary.UseVisualStyleBackColor = True
        '
        'txtDR
        '
        Me.txtDR.Enabled = False
        Me.txtDR.Location = New System.Drawing.Point(240, 94)
        Me.txtDR.Name = "txtDR"
        Me.txtDR.Size = New System.Drawing.Size(104, 21)
        Me.txtDR.TabIndex = 9
        Me.txtDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txtAR
        '
        Me.txtAR.Enabled = False
        Me.txtAR.Location = New System.Drawing.Point(240, 69)
        Me.txtAR.Name = "txtAR"
        Me.txtAR.Size = New System.Drawing.Size(104, 21)
        Me.txtAR.TabIndex = 7
        Me.txtAR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Location = New System.Drawing.Point(12, 44)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(536, 509)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Linen
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(528, 481)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Report"
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Linen
        Me.TabPage2.Controls.Add(Me.dgvMiscValue)
        Me.TabPage2.Controls.Add(Me.Label7)
        Me.TabPage2.Controls.Add(Me.Label6)
        Me.TabPage2.Controls.Add(Me.txtDisplay)
        Me.TabPage2.Controls.Add(Me.txtName)
        Me.TabPage2.Controls.Add(Me.dgvMiscList)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(528, 481)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Maintainence"
        '
        'dgvMiscValue
        '
        Me.dgvMiscValue.AllowUserToAddRows = False
        Me.dgvMiscValue.AllowUserToDeleteRows = False
        Me.dgvMiscValue.AllowUserToResizeRows = False
        Me.dgvMiscValue.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMiscValue.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvMiscValue.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMiscValue.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.code, Me.descpt})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMiscValue.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvMiscValue.Location = New System.Drawing.Point(174, 23)
        Me.dgvMiscValue.MultiSelect = False
        Me.dgvMiscValue.Name = "dgvMiscValue"
        Me.dgvMiscValue.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMiscValue.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvMiscValue.RowHeadersVisible = False
        Me.dgvMiscValue.RowTemplate.Height = 24
        Me.dgvMiscValue.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMiscValue.Size = New System.Drawing.Size(332, 259)
        Me.dgvMiscValue.TabIndex = 1
        '
        'code
        '
        Me.code.DataPropertyName = "code"
        Me.code.HeaderText = "Name"
        Me.code.Name = "code"
        Me.code.ReadOnly = True
        Me.code.Width = 160
        '
        'descpt
        '
        Me.descpt.DataPropertyName = "descpt"
        Me.descpt.HeaderText = "Value"
        Me.descpt.Name = "descpt"
        Me.descpt.ReadOnly = True
        Me.descpt.Width = 160
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 341)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(85, 15)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "Display Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 305)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Branch/AE"
        '
        'txtDisplay
        '
        Me.txtDisplay.Location = New System.Drawing.Point(107, 338)
        Me.txtDisplay.Name = "txtDisplay"
        Me.txtDisplay.Size = New System.Drawing.Size(192, 21)
        Me.txtDisplay.TabIndex = 3
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(107, 302)
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(192, 21)
        Me.txtName.TabIndex = 2
        '
        'dgvMiscList
        '
        Me.dgvMiscList.AllowUserToAddRows = False
        Me.dgvMiscList.AllowUserToDeleteRows = False
        Me.dgvMiscList.AllowUserToResizeRows = False
        Me.dgvMiscList.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMiscList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.dgvMiscList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMiscList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.misc_code, Me.misc_desc})
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle5.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvMiscList.DefaultCellStyle = DataGridViewCellStyle5
        Me.dgvMiscList.Location = New System.Drawing.Point(19, 23)
        Me.dgvMiscList.MultiSelect = False
        Me.dgvMiscList.Name = "dgvMiscList"
        Me.dgvMiscList.ReadOnly = True
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvMiscList.RowHeadersDefaultCellStyle = DataGridViewCellStyle6
        Me.dgvMiscList.RowHeadersVisible = False
        Me.dgvMiscList.RowTemplate.Height = 24
        Me.dgvMiscList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMiscList.Size = New System.Drawing.Size(138, 259)
        Me.dgvMiscList.TabIndex = 0
        '
        'misc_code
        '
        Me.misc_code.DataPropertyName = "misc_code"
        Me.misc_code.HeaderText = "misc_code"
        Me.misc_code.Name = "misc_code"
        Me.misc_code.ReadOnly = True
        Me.misc_code.Visible = False
        Me.misc_code.Width = 135
        '
        'misc_desc
        '
        Me.misc_desc.DataPropertyName = "misc_desc"
        Me.misc_desc.HeaderText = "Type"
        Me.misc_desc.Name = "misc_desc"
        Me.misc_desc.ReadOnly = True
        Me.misc_desc.Width = 135
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Linen
        Me.TabPage3.Controls.Add(Me.Label14)
        Me.TabPage3.Controls.Add(Me.Label13)
        Me.TabPage3.Controls.Add(Me.Label12)
        Me.TabPage3.Controls.Add(Me.Label10)
        Me.TabPage3.Controls.Add(Me.Label9)
        Me.TabPage3.Controls.Add(Me.Label8)
        Me.TabPage3.Controls.Add(Me.txtEndor2)
        Me.TabPage3.Controls.Add(Me.txtEndor1)
        Me.TabPage3.Controls.Add(Me.txtNoted3)
        Me.TabPage3.Controls.Add(Me.txtNoted1)
        Me.TabPage3.Controls.Add(Me.txtNoted2)
        Me.TabPage3.Controls.Add(Me.txtRegard)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage3.Size = New System.Drawing.Size(528, 481)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Signature"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(340, 89)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(58, 15)
        Me.Label14.TabIndex = 12
        Me.Label14.Text = "Endorsor"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(179, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 15)
        Me.Label13.TabIndex = 11
        Me.Label13.Text = "Endorsor"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(179, 32)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 15)
        Me.Label12.TabIndex = 10
        Me.Label12.Text = "Noted by"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(18, 89)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(55, 15)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Noted by"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 32)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(55, 15)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Regards"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(340, 32)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(55, 15)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Noted by"
        '
        'txtEndor2
        '
        Me.txtEndor2.Location = New System.Drawing.Point(343, 107)
        Me.txtEndor2.Name = "txtEndor2"
        Me.txtEndor2.Size = New System.Drawing.Size(155, 21)
        Me.txtEndor2.TabIndex = 5
        '
        'txtEndor1
        '
        Me.txtEndor1.Location = New System.Drawing.Point(182, 107)
        Me.txtEndor1.Name = "txtEndor1"
        Me.txtEndor1.Size = New System.Drawing.Size(155, 21)
        Me.txtEndor1.TabIndex = 4
        '
        'txtNoted3
        '
        Me.txtNoted3.Location = New System.Drawing.Point(21, 107)
        Me.txtNoted3.Name = "txtNoted3"
        Me.txtNoted3.Size = New System.Drawing.Size(155, 21)
        Me.txtNoted3.TabIndex = 3
        '
        'txtNoted1
        '
        Me.txtNoted1.Location = New System.Drawing.Point(182, 50)
        Me.txtNoted1.Name = "txtNoted1"
        Me.txtNoted1.Size = New System.Drawing.Size(155, 21)
        Me.txtNoted1.TabIndex = 1
        '
        'txtNoted2
        '
        Me.txtNoted2.Location = New System.Drawing.Point(343, 50)
        Me.txtNoted2.Name = "txtNoted2"
        Me.txtNoted2.Size = New System.Drawing.Size(155, 21)
        Me.txtNoted2.TabIndex = 2
        '
        'txtRegard
        '
        Me.txtRegard.Location = New System.Drawing.Point(21, 50)
        Me.txtRegard.Name = "txtRegard"
        Me.txtRegard.Size = New System.Drawing.Size(155, 21)
        Me.txtRegard.TabIndex = 0
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(326, 560)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(270, 560)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(382, 560)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'FrmCltBalSum
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(562, 627)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label11)
        Me.KeyPreview = True
        Me.Name = "FrmCltBalSum"
        Me.Text = "Client Balance Summary Report"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvMiscValue, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMiscList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cbClient As ESL.myCheckBox
    Friend WithEvents cbAE As ESL.myCheckBox
    Friend WithEvents cbActualRatio As ESL.myCheckBox
    Friend WithEvents cbDRBal As ESL.myCheckBox
    Friend WithEvents cbSuspended As ESL.myCheckBox
    Friend WithEvents cbClosed As ESL.myCheckBox
    Friend WithEvents cbAllZero As ESL.myCheckBox
    Friend WithEvents txtClientFrom As ESL.myTextbox
    Friend WithEvents txtClientTo As ESL.myTextbox
    Friend WithEvents comboAEFrom As ESL.myComboBox
    Friend WithEvents comboAETo As ESL.myComboBox
    Friend WithEvents rbPrinter As ESL.myRadioButton
    Friend WithEvents rbPreview As ESL.myRadioButton
    Friend WithEvents rbSortDrBal As ESL.myRadioButton
    Friend WithEvents rbSortAE As ESL.myRadioButton
    Friend WithEvents rbSortClient As ESL.myRadioButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAR As ESL.myNumericBox
    Friend WithEvents txtDR As ESL.myNumericBox
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents rbExcel As ESL.myRadioButton
    Friend WithEvents cbSummary As System.Windows.Forms.CheckBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDisplay As ESL.myTextbox
    Friend WithEvents txtName As ESL.myTextbox
    Friend WithEvents dgvMiscList As System.Windows.Forms.DataGridView
    Friend WithEvents dgvMiscValue As System.Windows.Forms.DataGridView
    Friend WithEvents misc_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents misc_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents descpt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEndor2 As ESL.myTextbox
    Friend WithEvents txtEndor1 As ESL.myTextbox
    Friend WithEvents txtNoted3 As ESL.myTextbox
    Friend WithEvents txtNoted1 As ESL.myTextbox
    Friend WithEvents txtNoted2 As ESL.myTextbox
    Friend WithEvents txtRegard As ESL.myTextbox

End Class
