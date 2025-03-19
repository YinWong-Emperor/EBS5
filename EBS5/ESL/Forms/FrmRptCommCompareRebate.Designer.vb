<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCommCompareRebate
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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lbltxmonth = New System.Windows.Forms.Label
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.cboMonth = New ESL.myComboBox(Me.components)
        Me.cboYear = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbDiff = New ESL.myRadioButton(Me.components)
        Me.rbAll = New ESL.myRadioButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.lblRange = New System.Windows.Forms.Label
        Me.txtRange = New ESL.myAmountBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.cboAE = New ESL.myComboBox(Me.components)
        Me.txtAE = New ESL.myTextbox
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(383, 186)
        Me.btnCancel.TabIndex = 9
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(187, 185)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(63, 133)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(370, 46)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(207, 20)
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
        Me.RBPreview.Location = New System.Drawing.Point(84, 20)
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
        Me.lblProcess.Location = New System.Drawing.Point(60, 202)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 39
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(63, 220)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(258, 14)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 38
        '
        'lbltxmonth
        '
        Me.lbltxmonth.AutoSize = True
        Me.lbltxmonth.Location = New System.Drawing.Point(60, 9)
        Me.lbltxmonth.Name = "lbltxmonth"
        Me.lbltxmonth.Size = New System.Drawing.Size(75, 15)
        Me.lbltxmonth.TabIndex = 37
        Me.lbltxmonth.Text = "Trade Month"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(327, 186)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 8
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(270, 6)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(65, 23)
        Me.cboMonth.TabIndex = 1
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(180, 6)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(84, 23)
        Me.cboYear.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(60, 35)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 15)
        Me.Label1.TabIndex = 41
        Me.Label1.Text = "AE"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbDiff)
        Me.GroupBox1.Controls.Add(Me.rbAll)
        Me.GroupBox1.Location = New System.Drawing.Point(180, 49)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(253, 37)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'rbDiff
        '
        Me.rbDiff.AutoSize = True
        Me.rbDiff.Location = New System.Drawing.Point(90, 12)
        Me.rbDiff.Name = "rbDiff"
        Me.rbDiff.Size = New System.Drawing.Size(108, 19)
        Me.rbDiff.TabIndex = 1
        Me.rbDiff.Text = "Difference Only"
        Me.rbDiff.UseVisualStyleBackColor = True
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(17, 12)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(45, 19)
        Me.rbAll.TabIndex = 0
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "Full"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(60, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(88, 15)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Display Report"
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'lblRange
        '
        Me.lblRange.AutoSize = True
        Me.lblRange.Location = New System.Drawing.Point(60, 92)
        Me.lblRange.Name = "lblRange"
        Me.lblRange.Size = New System.Drawing.Size(114, 15)
        Me.lblRange.TabIndex = 45
        Me.lblRange.Text = "Different More Than" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'txtRange
        '
        Me.txtRange.DecimalPoints = 2
        Me.txtRange.Location = New System.Drawing.Point(180, 89)
        Me.txtRange.Name = "txtRange"
        Me.txtRange.Size = New System.Drawing.Size(155, 21)
        Me.txtRange.TabIndex = 4
        Me.txtRange.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(94, 113)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(106, 19)
        Me.CheckBox1.TabIndex = 5
        Me.CheckBox1.Text = "Summary Only"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(270, 113)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(137, 19)
        Me.CheckBox2.TabIndex = 6
        Me.CheckBox2.Text = "Summary of AE Only"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'cboAE
        '
        Me.cboAE.FormattingEnabled = True
        Me.cboAE.Location = New System.Drawing.Point(180, 31)
        Me.cboAE.Name = "cboAE"
        Me.cboAE.Size = New System.Drawing.Size(84, 23)
        Me.cboAE.TabIndex = 2
        '
        'txtAE
        '
        Me.txtAE.Enabled = False
        Me.txtAE.Location = New System.Drawing.Point(270, 32)
        Me.txtAE.Name = "txtAE"
        Me.txtAE.Size = New System.Drawing.Size(163, 21)
        Me.txtAE.TabIndex = 46
        '
        'FrmRptCommCompareRebate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(496, 254)
        Me.Controls.Add(Me.txtAE)
        Me.Controls.Add(Me.cboAE)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.txtRange)
        Me.Controls.Add(Me.lblRange)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lbltxmonth)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboYear)
        Me.KeyPreview = True
        Me.Name = "FrmRptCommCompareRebate"
        Me.Text = "Rebate Difference Report (Securities)"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.cboYear, 0)
        Me.Controls.SetChildIndex(Me.cboMonth, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.lbltxmonth, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.lblRange, 0)
        Me.Controls.SetChildIndex(Me.txtRange, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox2, 0)
        Me.Controls.SetChildIndex(Me.cboAE, 0)
        Me.Controls.SetChildIndex(Me.txtAE, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents lbltxmonth As System.Windows.Forms.Label
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents cboMonth As ESL.myComboBox
    Friend WithEvents cboYear As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbDiff As ESL.myRadioButton
    Friend WithEvents rbAll As ESL.myRadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents lblRange As System.Windows.Forms.Label
    Friend WithEvents txtRange As ESL.myAmountBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents cboAE As ESL.myComboBox
    Friend WithEvents txtAE As ESL.myTextbox

End Class
