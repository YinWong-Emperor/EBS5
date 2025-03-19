<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptTransDiff
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.CboMonth = New ESL.myComboBox(Me.components)
        Me.CboYr = New ESL.myComboBox(Me.components)
        Me.RBTA_futRpt = New ESL.myRadioButton(Me.components)
        Me.RBTradeRpt = New ESL.myRadioButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.RBPrint = New ESL.myRadioButton(Me.components)
        Me.RBPreview = New ESL.myRadioButton(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.Label7 = New System.Windows.Forms.Label
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(367, 193)
        Me.btnCancel.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(315, 193)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.CboMonth)
        Me.GroupBox1.Controls.Add(Me.CboYr)
        Me.GroupBox1.Controls.Add(Me.RBTA_futRpt)
        Me.GroupBox1.Controls.Add(Me.RBTradeRpt)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(407, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(21, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Trans. Month:"
        '
        'CboMonth
        '
        Me.CboMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboMonth.FormattingEnabled = True
        Me.CboMonth.Location = New System.Drawing.Point(194, 17)
        Me.CboMonth.Name = "CboMonth"
        Me.CboMonth.Size = New System.Drawing.Size(76, 23)
        Me.CboMonth.TabIndex = 4
        '
        'CboYr
        '
        Me.CboYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CboYr.FormattingEnabled = True
        Me.CboYr.Location = New System.Drawing.Point(110, 17)
        Me.CboYr.Name = "CboYr"
        Me.CboYr.Size = New System.Drawing.Size(78, 23)
        Me.CboYr.TabIndex = 3
        '
        'RBTA_futRpt
        '
        Me.RBTA_futRpt.AutoSize = True
        Me.RBTA_futRpt.Location = New System.Drawing.Point(24, 69)
        Me.RBTA_futRpt.Name = "RBTA_futRpt"
        Me.RBTA_futRpt.Size = New System.Drawing.Size(228, 19)
        Me.RBTA_futRpt.TabIndex = 2
        Me.RBTA_futRpt.Text = "Future and Option Adjustment Report"
        Me.RBTA_futRpt.UseVisualStyleBackColor = True
        '
        'RBTradeRpt
        '
        Me.RBTradeRpt.AutoSize = True
        Me.RBTradeRpt.Checked = True
        Me.RBTradeRpt.Location = New System.Drawing.Point(24, 46)
        Me.RBTradeRpt.Name = "RBTradeRpt"
        Me.RBTradeRpt.Size = New System.Drawing.Size(185, 19)
        Me.RBTradeRpt.TabIndex = 0
        Me.RBTradeRpt.TabStop = True
        Me.RBTradeRpt.Text = "Securities Adjustment Report"
        Me.RBTradeRpt.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 136)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(407, 50)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(178, 20)
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
        Me.RBPreview.Location = New System.Drawing.Point(66, 20)
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
        Me.lblProcess.Location = New System.Drawing.Point(20, 187)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 28
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(20, 205)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(289, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(59, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(299, 22)
        Me.Label7.TabIndex = 4
        Me.Label7.Text = "Transaction Adjustment Report"
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'FrmRptTransDiff
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(426, 262)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.Label7)
        Me.KeyPreview = True
        Me.Name = "FrmRptTransDiff"
        Me.Text = "Transaction Adjustment Report"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents RBPrint As ESL.myRadioButton
    Friend WithEvents RBPreview As ESL.myRadioButton
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents RBTA_futRpt As ESL.myRadioButton
    Friend WithEvents RBTradeRpt As ESL.myRadioButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CboMonth As ESL.myComboBox
    Friend WithEvents CboYr As ESL.myComboBox

End Class
