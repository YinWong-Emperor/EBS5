<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCommRebateSecur
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
        Me.txtAE = New ESL.myTextbox
        Me.cboAE = New ESL.myComboBox(Me.components)
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.lbltxmonth = New System.Windows.Forms.Label
        Me.cboMonth = New ESL.myComboBox(Me.components)
        Me.cboYear = New ESL.myComboBox(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(459, 214)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(261, 213)
        '
        'txtAE
        '
        Me.txtAE.Enabled = False
        Me.txtAE.Location = New System.Drawing.Point(274, 58)
        Me.txtAE.Name = "txtAE"
        Me.txtAE.Size = New System.Drawing.Size(163, 21)
        Me.txtAE.TabIndex = 59
        '
        'cboAE
        '
        Me.cboAE.FormattingEnabled = True
        Me.cboAE.Location = New System.Drawing.Point(184, 57)
        Me.cboAE.Name = "cboAE"
        Me.cboAE.Size = New System.Drawing.Size(84, 23)
        Me.cboAE.TabIndex = 49
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(274, 99)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(137, 19)
        Me.CheckBox2.TabIndex = 53
        Me.CheckBox2.Text = "Summary of AE Only"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(98, 99)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(106, 19)
        Me.CheckBox1.TabIndex = 52
        Me.CheckBox1.Text = "Summary Only"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(64, 61)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(22, 15)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "AE"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(67, 119)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(370, 46)
        Me.GroupBox2.TabIndex = 54
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
        'lbltxmonth
        '
        Me.lbltxmonth.AutoSize = True
        Me.lbltxmonth.Location = New System.Drawing.Point(64, 35)
        Me.lbltxmonth.Name = "lbltxmonth"
        Me.lbltxmonth.Size = New System.Drawing.Size(75, 15)
        Me.lbltxmonth.TabIndex = 55
        Me.lbltxmonth.Text = "Trade Month"
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(274, 32)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(65, 23)
        Me.cboMonth.TabIndex = 48
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(184, 32)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(84, 23)
        Me.cboYear.TabIndex = 47
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(64, 213)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 61
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(67, 231)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(258, 14)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 60
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(385, 214)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 62
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'FrmRptCommRebateSecur
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(546, 285)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.txtAE)
        Me.Controls.Add(Me.cboAE)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lbltxmonth)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboYear)
        Me.KeyPreview = True
        Me.Name = "FrmRptCommRebateSecur"
        Me.Text = "AE Commission Report (Securities)"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.cboYear, 0)
        Me.Controls.SetChildIndex(Me.cboMonth, 0)
        Me.Controls.SetChildIndex(Me.lbltxmonth, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox2, 0)
        Me.Controls.SetChildIndex(Me.cboAE, 0)
        Me.Controls.SetChildIndex(Me.txtAE, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtAE As ESL.myTextbox
    Friend WithEvents cboAE As ESL.myComboBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents lbltxmonth As System.Windows.Forms.Label
    Friend WithEvents cboMonth As ESL.myComboBox
    Friend WithEvents cboYear As ESL.myComboBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog

End Class
