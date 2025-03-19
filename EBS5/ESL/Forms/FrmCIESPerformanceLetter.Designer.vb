<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCIESPerformanceLetter
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
        Me.txtClientCode = New System.Windows.Forms.TextBox
        Me.dtpTrade = New ESL.myDateTimePicker
        Me.lblCounterParty = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.PrintOption = New System.Windows.Forms.GroupBox
        Me.rbtPrint = New ESL.myRadioButton(Me.components)
        Me.rbtPreview = New ESL.myRadioButton(Me.components)
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.lblProcess = New System.Windows.Forms.Label
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog
        Me.ppl1 = New System.Windows.Forms.TextBox
        Me.phone1 = New System.Windows.Forms.TextBox
        Me.ppl2 = New System.Windows.Forms.TextBox
        Me.phone2 = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.PrintOption.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(476, 388)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(424, 388)
        Me.btnSave.Text = "Print"
        Me.btnSave.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtClientCode)
        Me.GroupBox1.Controls.Add(Me.dtpTrade)
        Me.GroupBox1.Controls.Add(Me.lblCounterParty)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(39, 34)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(351, 65)
        Me.GroupBox1.TabIndex = 62
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Trade Date"
        '
        'txtClientCode
        '
        Me.txtClientCode.Location = New System.Drawing.Point(108, 10)
        Me.txtClientCode.Name = "txtClientCode"
        Me.txtClientCode.Size = New System.Drawing.Size(145, 21)
        Me.txtClientCode.TabIndex = 7
        Me.txtClientCode.Text = "50031931"
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
        'PrintOption
        '
        Me.PrintOption.Controls.Add(Me.rbtPrint)
        Me.PrintOption.Controls.Add(Me.rbtPreview)
        Me.PrintOption.Location = New System.Drawing.Point(39, 124)
        Me.PrintOption.Name = "PrintOption"
        Me.PrintOption.Size = New System.Drawing.Size(351, 45)
        Me.PrintOption.TabIndex = 61
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
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(68, 417)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(239, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 65
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(65, 388)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 64
        Me.lblProcess.Text = "Processing"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'ppl1
        '
        Me.ppl1.Location = New System.Drawing.Point(150, 24)
        Me.ppl1.Name = "ppl1"
        Me.ppl1.Size = New System.Drawing.Size(161, 21)
        Me.ppl1.TabIndex = 66
        '
        'phone1
        '
        Me.phone1.Location = New System.Drawing.Point(150, 64)
        Me.phone1.Name = "phone1"
        Me.phone1.Size = New System.Drawing.Size(161, 21)
        Me.phone1.TabIndex = 67
        '
        'ppl2
        '
        Me.ppl2.Location = New System.Drawing.Point(150, 104)
        Me.ppl2.Name = "ppl2"
        Me.ppl2.Size = New System.Drawing.Size(161, 21)
        Me.ppl2.TabIndex = 68
        '
        'phone2
        '
        Me.phone2.Location = New System.Drawing.Point(150, 142)
        Me.phone2.Name = "phone2"
        Me.phone2.Size = New System.Drawing.Size(161, 21)
        Me.phone2.TabIndex = 69
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.phone2)
        Me.GroupBox2.Controls.Add(Me.ppl2)
        Me.GroupBox2.Controls.Add(Me.phone1)
        Me.GroupBox2.Controls.Add(Me.ppl1)
        Me.GroupBox2.Location = New System.Drawing.Point(39, 188)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(351, 186)
        Me.GroupBox2.TabIndex = 70
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Contact Info"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 148)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(98, 15)
        Me.Label5.TabIndex = 73
        Me.Label5.Text = "Contact Phone 2"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 107)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(102, 15)
        Me.Label4.TabIndex = 72
        Me.Label4.Text = "Contact Person 2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Contact Phone 1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(102, 15)
        Me.Label2.TabIndex = 70
        Me.Label2.Text = "Contact Person 1"
        '
        'FrmCIESPerformanceLetter
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(564, 481)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.PrintOption)
        Me.KeyPreview = True
        Me.Name = "FrmCIESPerformanceLetter"
        Me.Text = "CIES Performance Letter"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.PrintOption, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.PrintOption.ResumeLayout(False)
        Me.PrintOption.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtClientCode As System.Windows.Forms.TextBox
    Friend WithEvents dtpTrade As ESL.myDateTimePicker
    Friend WithEvents lblCounterParty As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents PrintOption As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPrint As ESL.myRadioButton
    Friend WithEvents rbtPreview As ESL.myRadioButton
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents ppl1 As System.Windows.Forms.TextBox
    Friend WithEvents phone1 As System.Windows.Forms.TextBox
    Friend WithEvents ppl2 As System.Windows.Forms.TextBox
    Friend WithEvents phone2 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
