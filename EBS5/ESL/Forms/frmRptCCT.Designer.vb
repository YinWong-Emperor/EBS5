<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptCCT
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
        Me.DTPStart = New ESL.myDateTimePicker
        Me.DTPEnd = New ESL.myDateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.PrintOption = New System.Windows.Forms.GroupBox
        Me.rbtPrint = New ESL.myRadioButton(Me.components)
        Me.rbtPreview = New ESL.myRadioButton(Me.components)
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Image = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(306, 157)
        Me.btnCancel.Size = New System.Drawing.Size(50, 23)
        '
        'btnSave
        '
        Me.btnSave.Image = Nothing
        Me.btnSave.Location = New System.Drawing.Point(250, 157)
        Me.btnSave.Size = New System.Drawing.Size(50, 23)
        Me.btnSave.Text = "OK"
        Me.btnSave.Visible = True
        '
        'DTPStart
        '
        Me.DTPStart.Location = New System.Drawing.Point(156, 6)
        Me.DTPStart.Name = "DTPStart"
        Me.DTPStart.Size = New System.Drawing.Size(200, 21)
        Me.DTPStart.TabIndex = 6
        '
        'DTPEnd
        '
        Me.DTPEnd.Location = New System.Drawing.Point(156, 33)
        Me.DTPEnd.Name = "DTPEnd"
        Me.DTPEnd.Size = New System.Drawing.Size(200, 21)
        Me.DTPEnd.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(61, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Start Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "End Date"
        '
        'PrintOption
        '
        Me.PrintOption.Controls.Add(Me.rbtPrint)
        Me.PrintOption.Controls.Add(Me.rbtPreview)
        Me.PrintOption.Location = New System.Drawing.Point(15, 60)
        Me.PrintOption.Name = "PrintOption"
        Me.PrintOption.Size = New System.Drawing.Size(341, 45)
        Me.PrintOption.TabIndex = 51
        Me.PrintOption.TabStop = False
        Me.PrintOption.Text = "Print option"
        '
        'rbtPrint
        '
        Me.rbtPrint.AutoSize = True
        Me.rbtPrint.Location = New System.Drawing.Point(207, 20)
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
        Me.rbtPreview.Location = New System.Drawing.Point(90, 20)
        Me.rbtPreview.Name = "rbtPreview"
        Me.rbtPreview.Size = New System.Drawing.Size(67, 19)
        Me.rbtPreview.TabIndex = 0
        Me.rbtPreview.TabStop = True
        Me.rbtPreview.Text = "preview"
        Me.rbtPreview.UseVisualStyleBackColor = True
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(15, 135)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(341, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 57
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(15, 108)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 56
        Me.lblProcess.Text = "Processing"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'frmRptCCT
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(365, 190)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.PrintOption)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DTPStart)
        Me.Controls.Add(Me.DTPEnd)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "frmRptCCT"
        Me.Text = "CCT Report"
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DTPEnd, 0)
        Me.Controls.SetChildIndex(Me.DTPStart, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.PrintOption, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.PrintOption.ResumeLayout(False)
        Me.PrintOption.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DTPStart As ESL.myDateTimePicker
    Friend WithEvents DTPEnd As ESL.myDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents PrintOption As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPrint As ESL.myRadioButton
    Friend WithEvents rbtPreview As ESL.myRadioButton
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog

End Class
