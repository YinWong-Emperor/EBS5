<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptCommScheme
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
        Me.lblTxMonth = New System.Windows.Forms.Label
        Me.CboYear = New ESL.myComboBox(Me.components)
        Me.CboMonth = New ESL.myComboBox(Me.components)
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.btnPrint = New ESL.myButton(Me.components)
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbAENo = New ESL.myRadioButton(Me.components)
        Me.rbTeam = New ESL.myRadioButton(Me.components)
        Me.rbAENameS = New ESL.myRadioButton(Me.components)
        Me.rbAENameF = New ESL.myRadioButton(Me.components)
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(292, 223)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(236, 223)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RBPrint)
        Me.GroupBox2.Controls.Add(Me.RBPreview)
        Me.GroupBox2.Location = New System.Drawing.Point(32, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(310, 56)
        Me.GroupBox2.TabIndex = 31
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Print Option"
        '
        'RBPrint
        '
        Me.RBPrint.AutoSize = True
        Me.RBPrint.Location = New System.Drawing.Point(172, 20)
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
        Me.RBPreview.Location = New System.Drawing.Point(33, 20)
        Me.RBPreview.Name = "RBPreview"
        Me.RBPreview.Size = New System.Drawing.Size(68, 19)
        Me.RBPreview.TabIndex = 0
        Me.RBPreview.TabStop = True
        Me.RBPreview.Text = "Preview"
        Me.RBPreview.UseVisualStyleBackColor = True
        '
        'lblTxMonth
        '
        Me.lblTxMonth.AutoSize = True
        Me.lblTxMonth.Location = New System.Drawing.Point(29, 20)
        Me.lblTxMonth.Name = "lblTxMonth"
        Me.lblTxMonth.Size = New System.Drawing.Size(57, 15)
        Me.lblTxMonth.TabIndex = 32
        Me.lblTxMonth.Text = "Txmonth:"
        '
        'CboYear
        '
        Me.CboYear.FormattingEnabled = True
        Me.CboYear.Location = New System.Drawing.Point(92, 17)
        Me.CboYear.Name = "CboYear"
        Me.CboYear.Size = New System.Drawing.Size(78, 23)
        Me.CboYear.TabIndex = 29
        '
        'CboMonth
        '
        Me.CboMonth.FormattingEnabled = True
        Me.CboMonth.Location = New System.Drawing.Point(176, 17)
        Me.CboMonth.Name = "CboMonth"
        Me.CboMonth.Size = New System.Drawing.Size(60, 23)
        Me.CboMonth.TabIndex = 30
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(29, 223)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 34
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(32, 241)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(198, 14)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 33
        '
        'btnPrint
        '
        Me.btnPrint.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPrint.Location = New System.Drawing.Point(236, 223)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 35
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbAENameF)
        Me.GroupBox1.Controls.Add(Me.rbAENameS)
        Me.GroupBox1.Controls.Add(Me.rbAENo)
        Me.GroupBox1.Controls.Add(Me.rbTeam)
        Me.GroupBox1.Location = New System.Drawing.Point(32, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(310, 80)
        Me.GroupBox1.TabIndex = 36
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sort by"
        '
        'rbAENo
        '
        Me.rbAENo.AutoSize = True
        Me.rbAENo.Location = New System.Drawing.Point(172, 20)
        Me.rbAENo.Name = "rbAENo"
        Me.rbAENo.Size = New System.Drawing.Size(62, 19)
        Me.rbAENo.TabIndex = 1
        Me.rbAENo.Text = "AE No."
        Me.rbAENo.UseVisualStyleBackColor = True
        '
        'rbTeam
        '
        Me.rbTeam.AutoSize = True
        Me.rbTeam.Checked = True
        Me.rbTeam.Location = New System.Drawing.Point(33, 20)
        Me.rbTeam.Name = "rbTeam"
        Me.rbTeam.Size = New System.Drawing.Size(57, 19)
        Me.rbTeam.TabIndex = 0
        Me.rbTeam.TabStop = True
        Me.rbTeam.Text = "Team"
        Me.rbTeam.UseVisualStyleBackColor = True
        '
        'rbAENameS
        '
        Me.rbAENameS.AutoSize = True
        Me.rbAENameS.Location = New System.Drawing.Point(33, 45)
        Me.rbAENameS.Name = "rbAENameS"
        Me.rbAENameS.Size = New System.Drawing.Size(93, 19)
        Me.rbAENameS.TabIndex = 2
        Me.rbAENameS.Text = "AE Name(S)"
        Me.rbAENameS.UseVisualStyleBackColor = True
        '
        'rbAENameF
        '
        Me.rbAENameF.AutoSize = True
        Me.rbAENameF.Location = New System.Drawing.Point(172, 45)
        Me.rbAENameF.Name = "rbAENameF"
        Me.rbAENameF.Size = New System.Drawing.Size(92, 19)
        Me.rbAENameF.TabIndex = 3
        Me.rbAENameF.Text = "AE Name(F)"
        Me.rbAENameF.UseVisualStyleBackColor = True
        '
        'FrmRptCommScheme
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(381, 311)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblTxMonth)
        Me.Controls.Add(Me.CboYear)
        Me.Controls.Add(Me.CboMonth)
        Me.KeyPreview = True
        Me.Name = "FrmRptCommScheme"
        Me.Text = "Commission Scheme Report"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.CboMonth, 0)
        Me.Controls.SetChildIndex(Me.CboYear, 0)
        Me.Controls.SetChildIndex(Me.lblTxMonth, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
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
    Friend WithEvents lblTxMonth As System.Windows.Forms.Label
    Friend WithEvents CboYear As ESL.myComboBox
    Friend WithEvents CboMonth As ESL.myComboBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents btnPrint As ESL.myButton
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbAENo As ESL.myRadioButton
    Friend WithEvents rbTeam As ESL.myRadioButton
    Friend WithEvents rbAENameS As ESL.myRadioButton
    Friend WithEvents rbAENameF As ESL.myRadioButton

End Class
