<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccTradePattern
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
        Me.PrintDlg = New System.Windows.Forms.PrintDialog
        Me.txtAccNo = New ESL.myTextbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpTDateFrom = New ESL.myDateTimePicker
        Me.dpTDateTo = New ESL.myDateTimePicker
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbSpreadLockPost = New ESL.myCheckBox(Me.components)
        Me.cbLockPost = New ESL.myCheckBox(Me.components)
        Me.cbAvgPeriod = New ESL.myCheckBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(307, 236)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(251, 236)
        Me.btnSave.Visible = True
        '
        'PrintDlg
        '
        Me.PrintDlg.UseEXDialog = True
        '
        'txtAccNo
        '
        Me.txtAccNo.Location = New System.Drawing.Point(129, 29)
        Me.txtAccNo.Name = "txtAccNo"
        Me.txtAccNo.Size = New System.Drawing.Size(228, 21)
        Me.txtAccNo.TabIndex = 15
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(47, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 16
        Me.Label1.Text = "Account No."
        '
        'dpTDateFrom
        '
        Me.dpTDateFrom.Checked = False
        Me.dpTDateFrom.CustomFormat = "dd MMM yyyy"
        Me.dpTDateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpTDateFrom.Location = New System.Drawing.Point(96, 67)
        Me.dpTDateFrom.Name = "dpTDateFrom"
        Me.dpTDateFrom.ShowCheckBox = True
        Me.dpTDateFrom.Size = New System.Drawing.Size(112, 21)
        Me.dpTDateFrom.TabIndex = 17
        '
        'dpTDateTo
        '
        Me.dpTDateTo.Checked = False
        Me.dpTDateTo.CustomFormat = "dd MMM yyyy"
        Me.dpTDateTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpTDateTo.Location = New System.Drawing.Point(241, 67)
        Me.dpTDateTo.Name = "dpTDateTo"
        Me.dpTDateTo.ShowCheckBox = True
        Me.dpTDateTo.Size = New System.Drawing.Size(116, 21)
        Me.dpTDateTo.TabIndex = 18
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbSpreadLockPost)
        Me.GroupBox1.Controls.Add(Me.cbLockPost)
        Me.GroupBox1.Controls.Add(Me.cbAvgPeriod)
        Me.GroupBox1.Location = New System.Drawing.Point(50, 98)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(307, 117)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Display Option"
        '
        'cbSpreadLockPost
        '
        Me.cbSpreadLockPost.AutoSize = True
        Me.cbSpreadLockPost.Checked = True
        Me.cbSpreadLockPost.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSpreadLockPost.Location = New System.Drawing.Point(31, 83)
        Me.cbSpreadLockPost.Name = "cbSpreadLockPost"
        Me.cbSpreadLockPost.Size = New System.Drawing.Size(151, 19)
        Me.cbSpreadLockPost.TabIndex = 2
        Me.cbSpreadLockPost.Text = "Lock Position (Spread)"
        Me.cbSpreadLockPost.UseVisualStyleBackColor = True
        '
        'cbLockPost
        '
        Me.cbLockPost.AutoSize = True
        Me.cbLockPost.Checked = True
        Me.cbLockPost.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbLockPost.Location = New System.Drawing.Point(31, 54)
        Me.cbLockPost.Name = "cbLockPost"
        Me.cbLockPost.Size = New System.Drawing.Size(97, 19)
        Me.cbLockPost.TabIndex = 1
        Me.cbLockPost.Text = "Lock Postion"
        Me.cbLockPost.UseVisualStyleBackColor = True
        '
        'cbAvgPeriod
        '
        Me.cbAvgPeriod.AutoSize = True
        Me.cbAvgPeriod.Checked = True
        Me.cbAvgPeriod.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbAvgPeriod.Location = New System.Drawing.Point(31, 26)
        Me.cbAvgPeriod.Name = "cbAvgPeriod"
        Me.cbAvgPeriod.Size = New System.Drawing.Size(120, 19)
        Me.cbAvgPeriod.TabIndex = 0
        Me.cbAvgPeriod.Text = "Average Duration"
        Me.cbAvgPeriod.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 15)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Period"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(214, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(21, 15)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "To"
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(47, 236)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 22
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(50, 259)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(307, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 21
        '
        'FrmAccTradePattern
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(410, 331)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dpTDateTo)
        Me.Controls.Add(Me.dpTDateFrom)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtAccNo)
        Me.KeyPreview = True
        Me.Name = "FrmAccTradePattern"
        Me.Text = "Account Trade Pattern"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.txtAccNo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.dpTDateFrom, 0)
        Me.Controls.SetChildIndex(Me.dpTDateTo, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintDlg As System.Windows.Forms.PrintDialog
    Friend WithEvents txtAccNo As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpTDateFrom As ESL.myDateTimePicker
    Friend WithEvents dpTDateTo As ESL.myDateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbSpreadLockPost As ESL.myCheckBox
    Friend WithEvents cbLockPost As ESL.myCheckBox
    Friend WithEvents cbAvgPeriod As ESL.myCheckBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar

End Class
