<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptComm
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.lblTxMonth = New System.Windows.Forms.Label()
        Me.cmbFromAE = New ESL.myComboBox(Me.components)
        Me.cmbToAE = New ESL.myComboBox(Me.components)
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.numFromYear = New System.Windows.Forms.NumericUpDown()
        Me.numFromMonth = New System.Windows.Forms.NumericUpDown()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.numToMonth = New System.Windows.Forms.NumericUpDown()
        Me.numToYear = New System.Windows.Forms.NumericUpDown()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.MyButton1 = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        CType(Me.numFromYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numFromMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numToMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.numToYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(483, 310)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(315, 310)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 162)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(483, 56)
        Me.GroupBox2.TabIndex = 19
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(280, 24)
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
        Me.RBPreview.Location = New System.Drawing.Point(85, 24)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(12, 310)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 23
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(15, 328)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(161, 14)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 22
        '
        'lblTxMonth
        '
        Me.lblTxMonth.AutoSize = True
        Me.lblTxMonth.Location = New System.Drawing.Point(16, 35)
        Me.lblTxMonth.Name = "lblTxMonth"
        Me.lblTxMonth.Size = New System.Drawing.Size(62, 15)
        Me.lblTxMonth.TabIndex = 20
        Me.lblTxMonth.Text = "AE Range"
        '
        'cmbFromAE
        '
        Me.cmbFromAE.FormattingEnabled = True
        Me.cmbFromAE.Location = New System.Drawing.Point(103, 32)
        Me.cmbFromAE.Name = "cmbFromAE"
        Me.cmbFromAE.Size = New System.Drawing.Size(116, 23)
        Me.cmbFromAE.TabIndex = 16
        '
        'cmbToAE
        '
        Me.cmbToAE.FormattingEnabled = True
        Me.cmbToAE.Location = New System.Drawing.Point(298, 32)
        Me.cmbToAE.Name = "cmbToAE"
        Me.cmbToAE.Size = New System.Drawing.Size(116, 23)
        Me.cmbToAE.TabIndex = 17
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.ESL.My.Resources.Resources.Printer
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(371, 310)
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(234, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 15)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "To"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 81)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Date From"
        '
        'numFromYear
        '
        Me.numFromYear.Location = New System.Drawing.Point(103, 78)
        Me.numFromYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numFromYear.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.numFromYear.Name = "numFromYear"
        Me.numFromYear.Size = New System.Drawing.Size(116, 21)
        Me.numFromYear.TabIndex = 27
        Me.numFromYear.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'numFromMonth
        '
        Me.numFromMonth.Location = New System.Drawing.Point(298, 78)
        Me.numFromMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numFromMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numFromMonth.Name = "numFromMonth"
        Me.numFromMonth.Size = New System.Drawing.Size(68, 21)
        Me.numFromMonth.TabIndex = 28
        Me.numFromMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(234, 81)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 15)
        Me.Label3.TabIndex = 29
        Me.Label3.Text = "Year"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(372, 81)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 15)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Month"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(372, 126)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(40, 15)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Month"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(234, 127)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(31, 15)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Year"
        '
        'numToMonth
        '
        Me.numToMonth.Location = New System.Drawing.Point(298, 124)
        Me.numToMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.numToMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.numToMonth.Name = "numToMonth"
        Me.numToMonth.Size = New System.Drawing.Size(68, 21)
        Me.numToMonth.TabIndex = 33
        Me.numToMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'numToYear
        '
        Me.numToYear.Location = New System.Drawing.Point(103, 124)
        Me.numToYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numToYear.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.numToYear.Name = "numToYear"
        Me.numToYear.Size = New System.Drawing.Size(116, 21)
        Me.numToYear.TabIndex = 32
        Me.numToYear.Value = New Decimal(New Integer() {1900, 0, 0, 0})
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(16, 127)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 15)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "Date To"
        '
        'MyButton1
        '
        Me.MyButton1.Image = Global.ESL.My.Resources.Resources.export
        Me.MyButton1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.MyButton1.Location = New System.Drawing.Point(427, 310)
        Me.MyButton1.Name = "MyButton1"
        Me.MyButton1.Size = New System.Drawing.Size(50, 55)
        Me.MyButton1.TabIndex = 36
        Me.MyButton1.Text = "Export"
        Me.MyButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MyButton1.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblTxMonth)
        Me.GroupBox1.Controls.Add(Me.cmbFromAE)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.cmbToAE)
        Me.GroupBox1.Controls.Add(Me.numToMonth)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.numToYear)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.numFromYear)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.numFromMonth)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 61)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(518, 242)
        Me.GroupBox1.TabIndex = 37
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(138, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(251, 22)
        Me.Label8.TabIndex = 38
        Me.Label8.Text = "Commission Report by AE"
        '
        'FrmRptComm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(545, 378)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.MyButton1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.KeyPreview = True
        Me.Name = "FrmRptComm"
        Me.Text = "Commission Report By AE"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.MyButton1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.numFromYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numFromMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numToMonth, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.numToYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblTxMonth As System.Windows.Forms.Label
    Friend WithEvents cmbFromAE As ESL.myComboBox
    Friend WithEvents cmbToAE As ESL.myComboBox
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents numFromYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents numFromMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents numToMonth As System.Windows.Forms.NumericUpDown
    Friend WithEvents numToYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents MyButton1 As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label

End Class
