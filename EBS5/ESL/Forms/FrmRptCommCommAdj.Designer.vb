<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCommCommAdj
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
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblTxMonth = New System.Windows.Forms.Label
        Me.CboYear = New ESL.myComboBox(Me.components)
        Me.CboMonth = New ESL.myComboBox(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(314, 98)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(197, 98)
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(262, 98)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 31
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 35)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(348, 56)
        Me.GroupBox2.TabIndex = 27
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
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(13, 94)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 30
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(16, 112)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(240, 14)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 29
        '
        'lblTxMonth
        '
        Me.lblTxMonth.AutoSize = True
        Me.lblTxMonth.Location = New System.Drawing.Point(12, 9)
        Me.lblTxMonth.Name = "lblTxMonth"
        Me.lblTxMonth.Size = New System.Drawing.Size(57, 15)
        Me.lblTxMonth.TabIndex = 28
        Me.lblTxMonth.Text = "Txmonth:"
        '
        'CboYear
        '
        Me.CboYear.FormattingEnabled = True
        Me.CboYear.Location = New System.Drawing.Point(75, 6)
        Me.CboYear.Name = "CboYear"
        Me.CboYear.Size = New System.Drawing.Size(78, 23)
        Me.CboYear.TabIndex = 25
        '
        'CboMonth
        '
        Me.CboMonth.FormattingEnabled = True
        Me.CboMonth.Location = New System.Drawing.Point(159, 6)
        Me.CboMonth.Name = "CboMonth"
        Me.CboMonth.Size = New System.Drawing.Size(60, 23)
        Me.CboMonth.TabIndex = 26
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'FrmRptCommCommAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(375, 162)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblTxMonth)
        Me.Controls.Add(Me.CboYear)
        Me.Controls.Add(Me.CboMonth)
        Me.KeyPreview = True
        Me.Name = "FrmRptCommCommAdj"
        Me.Text = "AE Commission Adjustment Report"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.CboMonth, 0)
        Me.Controls.SetChildIndex(Me.CboYear, 0)
        Me.Controls.SetChildIndex(Me.lblTxMonth, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblTxMonth As System.Windows.Forms.Label
    Friend WithEvents CboYear As ESL.myComboBox
    Friend WithEvents CboMonth As ESL.myComboBox
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog

End Class
