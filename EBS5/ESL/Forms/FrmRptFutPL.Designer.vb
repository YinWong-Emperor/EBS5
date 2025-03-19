<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptFutPL
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
        Me.dpEndRptDate = New ESL.myDateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.pbarProcess = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(215, 87)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(163, 87)
        Me.btnSave.TabIndex = 1
        Me.btnSave.Visible = True
        '
        'dpEndRptDate
        '
        Me.dpEndRptDate.CustomFormat = "dd MMM yyyy"
        Me.dpEndRptDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpEndRptDate.Location = New System.Drawing.Point(149, 43)
        Me.dpEndRptDate.Name = "dpEndRptDate"
        Me.dpEndRptDate.Size = New System.Drawing.Size(116, 21)
        Me.dpEndRptDate.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(45, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Report End Date"
        '
        'pbarProcess
        '
        Me.pbarProcess.Location = New System.Drawing.Point(48, 116)
        Me.pbarProcess.Name = "pbarProcess"
        Me.pbarProcess.Size = New System.Drawing.Size(217, 12)
        Me.pbarProcess.TabIndex = 12
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(45, 97)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 11
        Me.lblProcess.Text = "Processing"
        '
        'FrmRptFutPL
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(319, 208)
        Me.Controls.Add(Me.pbarProcess)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dpEndRptDate)
        Me.KeyPreview = True
        Me.Name = "FrmRptFutPL"
        Me.Text = "Futures Profit and Loss Analysis Report"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.dpEndRptDate, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarProcess, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dpEndRptDate As ESL.myDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbarProcess As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label

End Class
