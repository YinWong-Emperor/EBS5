<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCIESPerformance
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
        Me.PrintOption = New System.Windows.Forms.GroupBox
        Me.rbtPrint = New ESL.myRadioButton(Me.components)
        Me.rbtPreview = New ESL.myRadioButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbxTradeDate = New ESL.myComboBox(Me.components)
        Me.cbxClientCode = New ESL.myComboBox(Me.components)
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.dtpTrade = New ESL.myDateTimePicker
        Me.lblCounterParty = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.PrintOption.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(430, 187)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(378, 187)
        Me.btnSave.Text = "Print"
        Me.btnSave.Visible = True
        '
        'PrintOption
        '
        Me.PrintOption.Controls.Add(Me.rbtPrint)
        Me.PrintOption.Controls.Add(Me.rbtPreview)
        Me.PrintOption.Location = New System.Drawing.Point(21, 102)
        Me.PrintOption.Name = "PrintOption"
        Me.PrintOption.Size = New System.Drawing.Size(351, 45)
        Me.PrintOption.TabIndex = 59
        Me.PrintOption.TabStop = False
        Me.PrintOption.Text = "Print option"
        '
        'rbtPrint
        '
        Me.rbtPrint.AutoSize = True
        Me.rbtPrint.Location = New System.Drawing.Point(169, 20)
        Me.rbtPrint.Name = "rbtPrint"
        Me.rbtPrint.Size = New System.Drawing.Size(92, 19)
        Me.rbtPrint.TabIndex = 1
        Me.rbtPrint.Text = "print Directly"
        Me.rbtPrint.UseVisualStyleBackColor = True
        '
        'rbtPreview
        '
        Me.rbtPreview.AutoSize = True
        Me.rbtPreview.Checked = True
        Me.rbtPreview.Location = New System.Drawing.Point(6, 20)
        Me.rbtPreview.Name = "rbtPreview"
        Me.rbtPreview.Size = New System.Drawing.Size(67, 19)
        Me.rbtPreview.TabIndex = 0
        Me.rbtPreview.TabStop = True
        Me.rbtPreview.Text = "preview"
        Me.rbtPreview.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxTradeDate)
        Me.GroupBox1.Controls.Add(Me.cbxClientCode)
        Me.GroupBox1.Controls.Add(Me.txtClientCode)
        Me.GroupBox1.Controls.Add(Me.dtpTrade)
        Me.GroupBox1.Controls.Add(Me.lblCounterParty)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 65)
        Me.GroupBox1.TabIndex = 60
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trade Date"
        '
        'cbxTradeDate
        '
        Me.cbxTradeDate.FormatString = "D"
        Me.cbxTradeDate.FormattingEnabled = True
        Me.cbxTradeDate.Location = New System.Drawing.Point(108, 36)
        Me.cbxTradeDate.Name = "cbxTradeDate"
        Me.cbxTradeDate.Size = New System.Drawing.Size(145, 23)
        Me.cbxTradeDate.TabIndex = 9
        '
        'cbxClientCode
        '
        Me.cbxClientCode.FormattingEnabled = True
        Me.cbxClientCode.Location = New System.Drawing.Point(108, 10)
        Me.cbxClientCode.Name = "cbxClientCode"
        Me.cbxClientCode.Size = New System.Drawing.Size(145, 23)
        Me.cbxClientCode.TabIndex = 8
        '
        'txtClientCode
        '
        Me.txtClientCode.Location = New System.Drawing.Point(108, 10)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(145, 21)
        Me.txtClientCode.TabIndex = 7
        Me.txtClientCode.Text = "50031931"
        Me.txtClientCode.Visible = False
        '
        'dtpTrade
        '
        Me.dtpTrade.CustomFormat = "dd MMM yyyy"
        Me.dtpTrade.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpTrade.Location = New System.Drawing.Point(108, 37)
        Me.dtpTrade.Name = "dtpTrade"
        Me.dtpTrade.Size = New System.Drawing.Size(145, 21)
        Me.dtpTrade.TabIndex = 4
        Me.dtpTrade.Value = New Date(2011, 5, 30, 11, 2, 0, 0)
        Me.dtpTrade.Visible = False
        '
        'lblCounterParty
        '
        Me.lblCounterParty.AutoSize = True
        Me.lblCounterParty.Location = New System.Drawing.Point(6, 17)
        Me.lblCounterParty.Name = "lblCounterParty"
        Me.lblCounterParty.Size = New System.Drawing.Size(72, 15)
        Me.lblCounterParty.TabIndex = 6
        Me.lblCounterParty.Text = "Client Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 15)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Trade Date"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(25, 217)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(239, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 63
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(25, 177)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 62
        Me.lblProcess.Text = "Processing"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'FrmCIESPerformance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(500, 265)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PrintOption)
        Me.KeyPreview = True
        Me.Name = "FrmCIESPerformance"
        Me.Text = "CIES Performance"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.PrintOption, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.PrintOption.ResumeLayout(False)
        Me.PrintOption.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintOption As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPrint As ESL.myRadioButton
    Friend WithEvents rbtPreview As ESL.myRadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblCounterParty As System.Windows.Forms.Label
    Friend WithEvents dtpTrade As ESL.myDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents cbxClientCode As ESL.myComboBox
    Friend WithEvents cbxTradeDate As ESL.myComboBox

End Class
