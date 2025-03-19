<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptOPChecking
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbxCounterParty2 = New System.Windows.Forms.ComboBox
        Me.lblCounterParty2 = New System.Windows.Forms.Label
        Me.cbxCounterParty = New System.Windows.Forms.ComboBox
        Me.lblCounterParty = New System.Windows.Forms.Label
        Me.dtpTrade = New ESL.myDateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(313, 127)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(261, 127)
        Me.btnSave.Text = "Print"
        Me.btnSave.Visible = True
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(16, 167)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(239, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 61
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(16, 127)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 60
        Me.lblProcess.Text = "Processing"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxCounterParty2)
        Me.GroupBox1.Controls.Add(Me.lblCounterParty2)
        Me.GroupBox1.Controls.Add(Me.cbxCounterParty)
        Me.GroupBox1.Controls.Add(Me.lblCounterParty)
        Me.GroupBox1.Controls.Add(Me.dtpTrade)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 93)
        Me.GroupBox1.TabIndex = 59
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trade Date"
        '
        'cbxCounterParty2
        '
        Me.cbxCounterParty2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCounterParty2.FormattingEnabled = True
        Me.cbxCounterParty2.Location = New System.Drawing.Point(107, 63)
        Me.cbxCounterParty2.Name = "cbxCounterParty2"
        Me.cbxCounterParty2.Size = New System.Drawing.Size(145, 23)
        Me.cbxCounterParty2.TabIndex = 4
        '
        'lblCounterParty2
        '
        Me.lblCounterParty2.AutoSize = True
        Me.lblCounterParty2.Location = New System.Drawing.Point(6, 66)
        Me.lblCounterParty2.Name = "lblCounterParty2"
        Me.lblCounterParty2.Size = New System.Drawing.Size(81, 15)
        Me.lblCounterParty2.TabIndex = 3
        Me.lblCounterParty2.Text = "Counter Party"
        '
        'cbxCounterParty
        '
        Me.cbxCounterParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCounterParty.FormattingEnabled = True
        Me.cbxCounterParty.Location = New System.Drawing.Point(107, 38)
        Me.cbxCounterParty.Name = "cbxCounterParty"
        Me.cbxCounterParty.Size = New System.Drawing.Size(145, 23)
        Me.cbxCounterParty.TabIndex = 2
        '
        'lblCounterParty
        '
        Me.lblCounterParty.AutoSize = True
        Me.lblCounterParty.Location = New System.Drawing.Point(6, 41)
        Me.lblCounterParty.Name = "lblCounterParty"
        Me.lblCounterParty.Size = New System.Drawing.Size(81, 15)
        Me.lblCounterParty.TabIndex = 2
        Me.lblCounterParty.Text = "Counter Party"
        '
        'dtpTrade
        '
        Me.dtpTrade.CustomFormat = "dd MMM yyyy"
        Me.dtpTrade.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTrade.Location = New System.Drawing.Point(107, 15)
        Me.dtpTrade.Name = "dtpTrade"
        Me.dtpTrade.Size = New System.Drawing.Size(145, 21)
        Me.dtpTrade.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Trade Date"
        '
        'frmRptOPChecking
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(374, 198)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmRptOPChecking"
        Me.Text = "Open Position Checking Report"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cbxCounterParty As System.Windows.Forms.ComboBox
    Friend WithEvents lblCounterParty As System.Windows.Forms.Label
    Friend WithEvents dtpTrade As ESL.myDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxCounterParty2 As System.Windows.Forms.ComboBox
    Friend WithEvents lblCounterParty2 As System.Windows.Forms.Label

End Class
