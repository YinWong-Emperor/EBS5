<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptExternalAC
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
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.grpPrintOptions = New System.Windows.Forms.GroupBox
        Me.rbExport = New System.Windows.Forms.RadioButton
        Me.rbPrint = New System.Windows.Forms.RadioButton
        Me.rbPreview = New System.Windows.Forms.RadioButton
        Me.btnPrint = New System.Windows.Forms.Button
        Me.grpPrintOptions.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(326, 139)
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(12, 140)
        '
        'pbarPrint
        '
        Me.pbarPrint.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.pbarPrint.Location = New System.Drawing.Point(12, 112)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(364, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 61
        '
        'lblProcess
        '
        Me.lblProcess.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(12, 90)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 60
        Me.lblProcess.Text = "Processing"
        '
        'grpPrintOptions
        '
        Me.grpPrintOptions.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grpPrintOptions.Controls.Add(Me.rbExport)
        Me.grpPrintOptions.Controls.Add(Me.rbPrint)
        Me.grpPrintOptions.Controls.Add(Me.rbPreview)
        Me.grpPrintOptions.Location = New System.Drawing.Point(12, 12)
        Me.grpPrintOptions.Name = "grpPrintOptions"
        Me.grpPrintOptions.Size = New System.Drawing.Size(364, 60)
        Me.grpPrintOptions.TabIndex = 62
        Me.grpPrintOptions.TabStop = False
        Me.grpPrintOptions.Text = "Print Options"
        '
        'rbExport
        '
        Me.rbExport.AutoSize = True
        Me.rbExport.Location = New System.Drawing.Point(227, 26)
        Me.rbExport.Name = "rbExport"
        Me.rbExport.Size = New System.Drawing.Size(99, 19)
        Me.rbExport.TabIndex = 63
        Me.rbExport.TabStop = True
        Me.rbExport.Text = "Export (Excel)"
        Me.rbExport.UseVisualStyleBackColor = True
        '
        'rbPrint
        '
        Me.rbPrint.AutoSize = True
        Me.rbPrint.Location = New System.Drawing.Point(149, 26)
        Me.rbPrint.Name = "rbPrint"
        Me.rbPrint.Size = New System.Drawing.Size(50, 19)
        Me.rbPrint.TabIndex = 1
        Me.rbPrint.TabStop = True
        Me.rbPrint.Text = "Print"
        Me.rbPrint.UseVisualStyleBackColor = True
        '
        'rbPreview
        '
        Me.rbPreview.AutoSize = True
        Me.rbPreview.Location = New System.Drawing.Point(54, 26)
        Me.rbPreview.Name = "rbPreview"
        Me.rbPreview.Size = New System.Drawing.Size(68, 19)
        Me.rbPreview.TabIndex = 0
        Me.rbPreview.TabStop = True
        Me.rbPreview.Text = "Preview"
        Me.rbPreview.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(270, 140)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 63
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'FrmRptExternalAC
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(388, 207)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.grpPrintOptions)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.KeyPreview = True
        Me.Name = "FrmRptExternalAC"
        Me.ShowInTaskbar = False
        Me.Text = "External Account List"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.grpPrintOptions, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.grpPrintOptions.ResumeLayout(False)
        Me.grpPrintOptions.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents grpPrintOptions As System.Windows.Forms.GroupBox
    Friend WithEvents rbExport As System.Windows.Forms.RadioButton
    Friend WithEvents rbPrint As System.Windows.Forms.RadioButton
    Friend WithEvents rbPreview As System.Windows.Forms.RadioButton
    Friend WithEvents btnPrint As System.Windows.Forms.Button

End Class
