<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptAdj
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
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog()
        Me.btnExport = New ESL.myButton(Me.components)
        Me.Label13 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.cmbToAE = New ESL.myTextbox()
        Me.cmbFromAE = New ESL.myTextbox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.radAll = New System.Windows.Forms.RadioButton()
        Me.radNeg = New System.Windows.Forms.RadioButton()
        Me.radPos = New System.Windows.Forms.RadioButton()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cbNZero = New System.Windows.Forms.CheckBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.lblTxMonth = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numToMonth = New System.Windows.Forms.NumericUpDown()
        Me.numToYear = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.numFromMonth = New System.Windows.Forms.NumericUpDown()
        Me.numFromYear = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.radInt = New System.Windows.Forms.RadioButton()
        Me.radCommF = New System.Windows.Forms.RadioButton()
        Me.radCommS = New System.Windows.Forms.RadioButton()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numToMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numToYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFromMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFromYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(659, 389)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(491, 389)
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(48, 399)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 23
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(51, 417)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(232, 14)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 22
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.ESL.My.Resources.Resources.Printer
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(547, 389)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 24
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'btnExport
        '
        Me.btnExport.Image = Global.ESL.My.Resources.Resources.export
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExport.Location = New System.Drawing.Point(603, 389)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 36
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(181, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(387, 22)
        Me.Label13.TabIndex = 55
        Me.Label13.Text = "Commission / Interest Adjustment Report"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cmbToAE)
        Me.GroupBox4.Controls.Add(Me.cmbFromAE)
        Me.GroupBox4.Controls.Add(Me.GroupBox1)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.cbNZero)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.GroupBox2)
        Me.GroupBox4.Controls.Add(Me.lblTxMonth)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.numToMonth)
        Me.GroupBox4.Controls.Add(Me.numToYear)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.numFromMonth)
        Me.GroupBox4.Controls.Add(Me.numFromYear)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.GroupBox3)
        Me.GroupBox4.Location = New System.Drawing.Point(51, 43)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(658, 338)
        Me.GroupBox4.TabIndex = 59
        Me.GroupBox4.TabStop = False
        '
        'cmbToAE
        '
        Me.cmbToAE.Location = New System.Drawing.Point(392, 141)
        Me.cmbToAE.MaxLength = 8
        Me.cmbToAE.Name = "cmbToAE"
        Me.cmbToAE.Size = New System.Drawing.Size(116, 21)
        Me.cmbToAE.TabIndex = 86
        '
        'cmbFromAE
        '
        Me.cmbFromAE.Location = New System.Drawing.Point(159, 141)
        Me.cmbFromAE.MaxLength = 8
        Me.cmbFromAE.Name = "cmbFromAE"
        Me.cmbFromAE.Size = New System.Drawing.Size(115, 21)
        Me.cmbFromAE.TabIndex = 85
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.radAll)
        Me.GroupBox1.Controls.Add(Me.radNeg)
        Me.GroupBox1.Controls.Add(Me.radPos)
        Me.GroupBox1.Location = New System.Drawing.Point(141, 204)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(319, 53)
        Me.GroupBox1.TabIndex = 84
        Me.GroupBox1.TabStop = False
        '
        'radAll
        '
        Me.radAll.AutoSize = True
        Me.radAll.Checked = True
        Me.radAll.Enabled = False
        Me.radAll.Location = New System.Drawing.Point(18, 20)
        Me.radAll.Name = "radAll"
        Me.radAll.Size = New System.Drawing.Size(38, 19)
        Me.radAll.TabIndex = 42
        Me.radAll.TabStop = True
        Me.radAll.Text = "All"
        Me.radAll.UseVisualStyleBackColor = True
        '
        'radNeg
        '
        Me.radNeg.AutoSize = True
        Me.radNeg.Enabled = False
        Me.radNeg.Location = New System.Drawing.Point(237, 20)
        Me.radNeg.Name = "radNeg"
        Me.radNeg.Size = New System.Drawing.Size(66, 19)
        Me.radNeg.TabIndex = 44
        Me.radNeg.Text = "<0 Only"
        Me.radNeg.UseVisualStyleBackColor = True
        '
        'radPos
        '
        Me.radPos.AutoSize = True
        Me.radPos.Enabled = False
        Me.radPos.Location = New System.Drawing.Point(121, 20)
        Me.radPos.Name = "radPos"
        Me.radPos.Size = New System.Drawing.Size(73, 19)
        Me.radPos.TabIndex = 43
        Me.radPos.Text = ">=0 Only"
        Me.radPos.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(35, 226)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(81, 15)
        Me.Label8.TabIndex = 83
        Me.Label8.Text = "Stock Interest"
        '
        'cbNZero
        '
        Me.cbNZero.AutoSize = True
        Me.cbNZero.Location = New System.Drawing.Point(38, 177)
        Me.cbNZero.Name = "cbNZero"
        Me.cbNZero.Size = New System.Drawing.Size(207, 19)
        Me.cbNZero.TabIndex = 82
        Me.cbNZero.Text = "Only Non-zero Adjustment or IPO "
        Me.cbNZero.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(320, 144)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 15)
        Me.Label1.TabIndex = 81
        Me.Label1.Text = "To"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 268)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(428, 56)
        Me.GroupBox2.TabIndex = 79
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(194, 24)
        Me.RBPrint.Name = "RBPrint"
        Me.RBPrint.Size = New System.Drawing.Size(109, 19)
        Me.RBPrint.TabIndex = 1
        Me.RBPrint.Text = "Direct to Printer"
        Me.RBPrint.UseVisualStyleBackColor = True
        '
        'RBPreview
        '
        Me.RBPreview.AutoSize = True
        Me.RBPreview.Checked = True
        Me.RBPreview.Location = New System.Drawing.Point(67, 24)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'lblTxMonth
        '
        Me.lblTxMonth.AutoSize = True
        Me.lblTxMonth.Location = New System.Drawing.Point(35, 144)
        Me.lblTxMonth.Name = "lblTxMonth"
        Me.lblTxMonth.Size = New System.Drawing.Size(79, 15)
        Me.lblTxMonth.TabIndex = 80
        Me.lblTxMonth.Text = "Client Range"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.ForeColor = System.Drawing.Color.Red
        Me.Label5.Location = New System.Drawing.Point(523, 107)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 76
        Me.Label5.Text = "Month"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.ForeColor = System.Drawing.Color.Red
        Me.Label6.Location = New System.Drawing.Point(404, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 75
        Me.Label6.Text = "Year"
        '
        'numToMonth
        '
        Me.numToMonth.Location = New System.Drawing.Point(510, 85)
        Me.numToMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numToMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numToMonth.Name = "numToMonth"
        Me.numToMonth.Size = New System.Drawing.Size(68, 21)
        Me.numToMonth.TabIndex = 74
        Me.numToMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numToYear
        '
        Me.numToYear.Location = New System.Drawing.Point(392, 85)
        Me.numToYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numToYear.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.numToYear.Name = "numToYear"
        Me.numToYear.Size = New System.Drawing.Size(68, 21)
        Me.numToYear.TabIndex = 73
        Me.numToYear.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(320, 87)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(20, 15)
        Me.Label7.TabIndex = 72
        Me.Label7.Text = "To"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Red
        Me.Label4.Location = New System.Drawing.Point(219, 109)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 15)
        Me.Label4.TabIndex = 71
        Me.Label4.Text = "Month"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(113, 109)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 70
        Me.Label3.Text = "Year"
        '
        'numFromMonth
        '
        Me.numFromMonth.Location = New System.Drawing.Point(206, 85)
        Me.numFromMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numFromMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFromMonth.Name = "numFromMonth"
        Me.numFromMonth.Size = New System.Drawing.Size(68, 21)
        Me.numFromMonth.TabIndex = 69
        Me.numFromMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numFromYear
        '
        Me.numFromYear.Location = New System.Drawing.Point(99, 85)
        Me.numFromYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numFromYear.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.numFromYear.Name = "numFromYear"
        Me.numFromYear.Size = New System.Drawing.Size(68, 21)
        Me.numFromYear.TabIndex = 68
        Me.numFromYear.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(35, 87)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 15)
        Me.Label2.TabIndex = 67
        Me.Label2.Text = "From"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.radInt)
        Me.GroupBox3.Controls.Add(Me.radCommF)
        Me.GroupBox3.Controls.Add(Me.radCommS)
        Me.GroupBox3.Location = New System.Drawing.Point(32, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(600, 46)
        Me.GroupBox3.TabIndex = 49
        Me.GroupBox3.TabStop = False
        '
        'radInt
        '
        Me.radInt.AutoSize = True
        Me.radInt.Location = New System.Drawing.Point(447, 17)
        Me.radInt.Name = "radInt"
        Me.radInt.Size = New System.Drawing.Size(99, 19)
        Me.radInt.TabIndex = 39
        Me.radInt.Text = "Stock Interest"
        Me.radInt.UseVisualStyleBackColor = True
        '
        'radCommF
        '
        Me.radCommF.AutoSize = True
        Me.radCommF.Location = New System.Drawing.Point(230, 17)
        Me.radCommF.Name = "radCommF"
        Me.radCommF.Size = New System.Drawing.Size(142, 19)
        Me.radCommF.TabIndex = 38
        Me.radCommF.Text = "Futures Commission"
        Me.radCommF.UseVisualStyleBackColor = True
        '
        'radCommS
        '
        Me.radCommS.AutoSize = True
        Me.radCommS.Checked = True
        Me.radCommS.Location = New System.Drawing.Point(19, 17)
        Me.radCommS.Name = "radCommS"
        Me.radCommS.Size = New System.Drawing.Size(130, 19)
        Me.radCommS.TabIndex = 37
        Me.radCommS.TabStop = True
        Me.radCommS.Text = "Stock Commission"
        Me.radCommS.UseVisualStyleBackColor = True
        '
        'FrmRptAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(753, 457)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.KeyPreview = True
        Me.Name = "FrmRptAdj"
        Me.Text = "Adjustment Report"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.GroupBox4, 0)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numToMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numToYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFromMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFromYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents radAll As System.Windows.Forms.RadioButton
    Friend WithEvents radNeg As System.Windows.Forms.RadioButton
    Friend WithEvents radPos As System.Windows.Forms.RadioButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cbNZero As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents lblTxMonth As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numToMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents numToYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents numFromMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents numFromYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents radInt As System.Windows.Forms.RadioButton
    Friend WithEvents radCommF As System.Windows.Forms.RadioButton
    Friend WithEvents radCommS As System.Windows.Forms.RadioButton
    Friend WithEvents cmbToAE As ESL.myTextbox
    Friend WithEvents cmbFromAE As ESL.myTextbox

End Class
