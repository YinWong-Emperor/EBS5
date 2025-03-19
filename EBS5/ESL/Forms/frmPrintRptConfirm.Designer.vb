<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmPrintRptConfirm
    Inherits ESL.frmBaseSrh

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
        Me.lblQuestion = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.grbPrintOpt = New System.Windows.Forms.GroupBox
        Me.btnFile = New System.Windows.Forms.Button
        Me.txtFilePath = New ESL.myTextbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.radPrinter = New System.Windows.Forms.RadioButton
        Me.radFile = New System.Windows.Forms.RadioButton
        Me.radPreview = New System.Windows.Forms.RadioButton
        Me.saveDlg = New System.Windows.Forms.SaveFileDialog
        Me.printDlg = New System.Windows.Forms.PrintDialog
        Me.grbPrintOpt.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(244, 168)
        Me.btnClose.TabIndex = 3
        Me.btnClose.Text = "No"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(116, 168)
        Me.btnOK.TabIndex = 2
        Me.btnOK.Text = "Yes"
        '
        'lblQuestion
        '
        Me.lblQuestion.Location = New System.Drawing.Point(12, 12)
        Me.lblQuestion.Name = "lblQuestion"
        Me.lblQuestion.Size = New System.Drawing.Size(400, 48)
        Me.lblQuestion.TabIndex = 0
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(8, 148)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(400, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 3
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(8, 128)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 4
        Me.lblProcess.Text = "Processing"
        '
        'grbPrintOpt
        '
        Me.grbPrintOpt.Controls.Add(Me.btnFile)
        Me.grbPrintOpt.Controls.Add(Me.txtFilePath)
        Me.grbPrintOpt.Controls.Add(Me.Label1)
        Me.grbPrintOpt.Controls.Add(Me.radPrinter)
        Me.grbPrintOpt.Controls.Add(Me.radFile)
        Me.grbPrintOpt.Controls.Add(Me.radPreview)
        Me.grbPrintOpt.Location = New System.Drawing.Point(8, 64)
        Me.grbPrintOpt.Name = "grbPrintOpt"
        Me.grbPrintOpt.Size = New System.Drawing.Size(404, 52)
        Me.grbPrintOpt.TabIndex = 1
        Me.grbPrintOpt.TabStop = False
        Me.grbPrintOpt.Text = "Print Option"
        '
        'btnFile
        '
        Me.btnFile.Location = New System.Drawing.Point(368, 44)
        Me.btnFile.Name = "btnFile"
        Me.btnFile.Size = New System.Drawing.Size(28, 23)
        Me.btnFile.TabIndex = 4
        Me.btnFile.Text = "..."
        Me.btnFile.UseVisualStyleBackColor = True
        Me.btnFile.Visible = False
        '
        'txtFilePath
        '
        Me.txtFilePath.Location = New System.Drawing.Point(72, 44)
        Me.txtFilePath.Name = "txtFilePath"
        Me.txtFilePath.Size = New System.Drawing.Size(292, 21)
        Me.txtFilePath.TabIndex = 3
        Me.txtFilePath.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "File Path"
        Me.Label1.Visible = False
        '
        'radPrinter
        '
        Me.radPrinter.AutoSize = True
        Me.radPrinter.Location = New System.Drawing.Point(124, 20)
        Me.radPrinter.Name = "radPrinter"
        Me.radPrinter.Size = New System.Drawing.Size(134, 19)
        Me.radPrinter.TabIndex = 1
        Me.radPrinter.TabStop = True
        Me.radPrinter.Text = "Print direct to printer"
        Me.radPrinter.UseVisualStyleBackColor = True
        '
        'radFile
        '
        Me.radFile.AutoSize = True
        Me.radFile.Location = New System.Drawing.Point(288, 20)
        Me.radFile.Name = "radFile"
        Me.radFile.Size = New System.Drawing.Size(99, 19)
        Me.radFile.TabIndex = 2
        Me.radFile.TabStop = True
        Me.radFile.Text = "Export to PDF"
        Me.radFile.UseVisualStyleBackColor = True
        '
        'radPreview
        '
        Me.radPreview.AutoSize = True
        Me.radPreview.Location = New System.Drawing.Point(28, 20)
        Me.radPreview.Name = "radPreview"
        Me.radPreview.Size = New System.Drawing.Size(68, 19)
        Me.radPreview.TabIndex = 0
        Me.radPreview.TabStop = True
        Me.radPreview.Text = "Preview"
        Me.radPreview.UseVisualStyleBackColor = True
        '
        'printDlg
        '
        Me.printDlg.UseEXDialog = True
        '
        'frmPrintRptConfirm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(425, 203)
        Me.Controls.Add(Me.grbPrintOpt)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblQuestion)
        Me.KeyPreview = True
        Me.Name = "frmPrintRptConfirm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Confirm"
        Me.Controls.SetChildIndex(Me.btnOK, 0)
        Me.Controls.SetChildIndex(Me.btnClose, 0)
        Me.Controls.SetChildIndex(Me.lblQuestion, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.grbPrintOpt, 0)
        Me.grbPrintOpt.ResumeLayout(False)
        Me.grbPrintOpt.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblQuestion As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents grbPrintOpt As System.Windows.Forms.GroupBox
    Friend WithEvents radPreview As System.Windows.Forms.RadioButton
    Friend WithEvents btnFile As System.Windows.Forms.Button
    Friend WithEvents txtFilePath As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents radPrinter As System.Windows.Forms.RadioButton
    Friend WithEvents radFile As System.Windows.Forms.RadioButton
    Friend WithEvents saveDlg As System.Windows.Forms.SaveFileDialog
    Friend WithEvents printDlg As System.Windows.Forms.PrintDialog

End Class
