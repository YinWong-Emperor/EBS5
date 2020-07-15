<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCommAEDetail
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
        Me.DtgData = New System.Windows.Forms.DataGridView
        Me.cboYear = New ESL.myComboBox(Me.components)
        Me.cboMonth = New ESL.myComboBox(Me.components)
        Me.rbSec = New ESL.myRadioButton(Me.components)
        Me.rbFut = New ESL.myRadioButton(Me.components)
        Me.rbOther = New ESL.myRadioButton(Me.components)
        Me.rbMan = New ESL.myRadioButton(Me.components)
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.lbltxmonth = New System.Windows.Forms.Label
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.btnShow = New ESL.myButton(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        CType(Me.DtgData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(879, 585)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(739, 581)
        '
        'DtgData
        '
        Me.DtgData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DtgData.Location = New System.Drawing.Point(12, 15)
        Me.DtgData.Name = "DtgData"
        Me.DtgData.RowTemplate.Height = 24
        Me.DtgData.Size = New System.Drawing.Size(917, 550)
        Me.DtgData.TabIndex = 6
        '
        'cboYear
        '
        Me.cboYear.FormattingEnabled = True
        Me.cboYear.Location = New System.Drawing.Point(104, 588)
        Me.cboYear.Name = "cboYear"
        Me.cboYear.Size = New System.Drawing.Size(121, 23)
        Me.cboYear.TabIndex = 7
        '
        'cboMonth
        '
        Me.cboMonth.FormattingEnabled = True
        Me.cboMonth.Location = New System.Drawing.Point(231, 588)
        Me.cboMonth.Name = "cboMonth"
        Me.cboMonth.Size = New System.Drawing.Size(121, 23)
        Me.cboMonth.TabIndex = 8
        '
        'rbSec
        '
        Me.rbSec.AutoSize = True
        Me.rbSec.Checked = True
        Me.rbSec.Location = New System.Drawing.Point(26, 619)
        Me.rbSec.Name = "rbSec"
        Me.rbSec.Size = New System.Drawing.Size(80, 19)
        Me.rbSec.TabIndex = 9
        Me.rbSec.TabStop = True
        Me.rbSec.Text = "Securities"
        Me.rbSec.UseVisualStyleBackColor = True
        '
        'rbFut
        '
        Me.rbFut.AutoSize = True
        Me.rbFut.Location = New System.Drawing.Point(112, 619)
        Me.rbFut.Name = "rbFut"
        Me.rbFut.Size = New System.Drawing.Size(67, 19)
        Me.rbFut.TabIndex = 10
        Me.rbFut.TabStop = True
        Me.rbFut.Text = "Futures"
        Me.rbFut.UseVisualStyleBackColor = True
        '
        'rbOther
        '
        Me.rbOther.AutoSize = True
        Me.rbOther.Location = New System.Drawing.Point(185, 619)
        Me.rbOther.Name = "rbOther"
        Me.rbOther.Size = New System.Drawing.Size(62, 19)
        Me.rbOther.TabIndex = 11
        Me.rbOther.TabStop = True
        Me.rbOther.Text = "Others"
        Me.rbOther.UseVisualStyleBackColor = True
        '
        'rbMan
        '
        Me.rbMan.AutoSize = True
        Me.rbMan.Location = New System.Drawing.Point(253, 619)
        Me.rbMan.Name = "rbMan"
        Me.rbMan.Size = New System.Drawing.Size(73, 19)
        Me.rbMan.TabIndex = 12
        Me.rbMan.TabStop = True
        Me.rbMan.Text = "Manager"
        Me.rbMan.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(823, 585)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 13
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'lbltxmonth
        '
        Me.lbltxmonth.AutoSize = True
        Me.lbltxmonth.Location = New System.Drawing.Point(23, 596)
        Me.lbltxmonth.Name = "lbltxmonth"
        Me.lbltxmonth.Size = New System.Drawing.Size(75, 15)
        Me.lbltxmonth.TabIndex = 14
        Me.lbltxmonth.Text = "Trade Month"
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(613, 608)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 32
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(616, 626)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(201, 14)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 31
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(414, 597)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(199, 46)
        Me.GroupBox2.TabIndex = 33
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(85, 20)
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
        Me.RBPreview.Location = New System.Drawing.Point(11, 20)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'btnShow
        '
        Me.btnShow.Location = New System.Drawing.Point(358, 588)
        Me.btnShow.Name = "btnShow"
        Me.btnShow.Size = New System.Drawing.Size(50, 55)
        Me.btnShow.TabIndex = 34
        Me.btnShow.Text = "Show"
        Me.btnShow.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnShow.UseVisualStyleBackColor = True
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'FrmRptCommAEDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(941, 679)
        Me.Controls.Add(Me.btnShow)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lbltxmonth)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.rbMan)
        Me.Controls.Add(Me.rbOther)
        Me.Controls.Add(Me.rbFut)
        Me.Controls.Add(Me.rbSec)
        Me.Controls.Add(Me.cboMonth)
        Me.Controls.Add(Me.cboYear)
        Me.Controls.Add(Me.DtgData)
        Me.KeyPreview = True
        Me.Name = "FrmRptCommAEDetail"
        Me.Text = "Commission AE Detail Report"
        Me.Controls.SetChildIndex(Me.DtgData, 0)
        Me.Controls.SetChildIndex(Me.cboYear, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.cboMonth, 0)
        Me.Controls.SetChildIndex(Me.rbSec, 0)
        Me.Controls.SetChildIndex(Me.rbFut, 0)
        Me.Controls.SetChildIndex(Me.rbOther, 0)
        Me.Controls.SetChildIndex(Me.rbMan, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.lbltxmonth, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btnShow, 0)
        CType(Me.DtgData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DtgData As System.Windows.Forms.DataGridView
    Friend WithEvents cboYear As ESL.myComboBox
    Friend WithEvents cboMonth As ESL.myComboBox
    Friend WithEvents rbSec As ESL.myRadioButton
    Friend WithEvents rbFut As ESL.myRadioButton
    Friend WithEvents rbOther As ESL.myRadioButton
    Friend WithEvents rbMan As ESL.myRadioButton
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents lbltxmonth As System.Windows.Forms.Label
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents btnShow As ESL.myButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog

End Class
