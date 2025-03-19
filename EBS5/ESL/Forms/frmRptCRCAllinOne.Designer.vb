<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmRptCRCAllinOne
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
        Me.components = New System.ComponentModel.Container()
        Me.PrintOption = New System.Windows.Forms.GroupBox()
        Me.rbtPrint = New ESL.myRadioButton(Me.components)
        Me.rbtPreview = New ESL.myRadioButton(Me.components)
        Me.pbarPrint = New System.Windows.Forms.ProgressBar()
        Me.lblProcess = New System.Windows.Forms.Label()
        Me.PrintDialog1 = New System.Windows.Forms.PrintDialog()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.CheckBox2 = New System.Windows.Forms.CheckBox()
        Me.CheckBox3 = New System.Windows.Forms.CheckBox()
        Me.CheckBox4 = New System.Windows.Forms.CheckBox()
        Me.CheckBox5 = New System.Windows.Forms.CheckBox()
        Me.CheckBox6 = New System.Windows.Forms.CheckBox()
        Me.CheckBox7 = New System.Windows.Forms.CheckBox()
        Me.PrintOption.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Image = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(367, 543)
        Me.btnCancel.Size = New System.Drawing.Size(50, 23)
        '
        'btnSave
        '
        Me.btnSave.Image = Nothing
        Me.btnSave.Location = New System.Drawing.Point(311, 543)
        Me.btnSave.Size = New System.Drawing.Size(50, 23)
        Me.btnSave.Text = "OK"
        Me.btnSave.Visible = True
        '
        'PrintOption
        '
        Me.PrintOption.Controls.Add(Me.rbtPrint)
        Me.PrintOption.Controls.Add(Me.rbtPreview)
        Me.PrintOption.Location = New System.Drawing.Point(15, 447)
        Me.PrintOption.Name = "PrintOption"
        Me.PrintOption.Size = New System.Drawing.Size(402, 45)
        Me.PrintOption.TabIndex = 51
        Me.PrintOption.TabStop = False
        Me.PrintOption.Text = "Print option"
        '
        'rbtPrint
        '
        Me.rbtPrint.AutoSize = True
        Me.rbtPrint.Location = New System.Drawing.Point(236, 20)
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
        Me.pbarPrint.Location = New System.Drawing.Point(15, 522)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(402, 15)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 57
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(15, 495)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 56
        Me.lblProcess.Text = "Processing"
        '
        'PrintDialog1
        '
        Me.PrintDialog1.UseEXDialog = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 12)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(248, 19)
        Me.CheckBox1.TabIndex = 63
        Me.CheckBox1.Text = "Daily Traders Account Status Control List"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'CheckBox2
        '
        Me.CheckBox2.AutoSize = True
        Me.CheckBox2.Location = New System.Drawing.Point(15, 37)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(177, 19)
        Me.CheckBox2.TabIndex = 64
        Me.CheckBox2.Text = "CIES Account Status Report"
        Me.CheckBox2.UseVisualStyleBackColor = True
        '
        'CheckBox3
        '
        Me.CheckBox3.AutoSize = True
        Me.CheckBox3.Location = New System.Drawing.Point(15, 62)
        Me.CheckBox3.Name = "CheckBox3"
        Me.CheckBox3.Size = New System.Drawing.Size(131, 19)
        Me.CheckBox3.TabIndex = 65
        Me.CheckBox3.Text = "Margin Call Record"
        Me.CheckBox3.UseVisualStyleBackColor = True
        '
        'CheckBox4
        '
        Me.CheckBox4.AutoSize = True
        Me.CheckBox4.Location = New System.Drawing.Point(15, 87)
        Me.CheckBox4.Name = "CheckBox4"
        Me.CheckBox4.Size = New System.Drawing.Size(264, 19)
        Me.CheckBox4.TabIndex = 66
        Me.CheckBox4.Text = "Margin Client Stock Holdings Concentration"
        Me.CheckBox4.UseVisualStyleBackColor = True
        '
        'CheckBox5
        '
        Me.CheckBox5.AutoSize = True
        Me.CheckBox5.Location = New System.Drawing.Point(15, 112)
        Me.CheckBox5.Name = "CheckBox5"
        Me.CheckBox5.Size = New System.Drawing.Size(296, 19)
        Me.CheckBox5.TabIndex = 67
        Me.CheckBox5.Text = "Debit Margin Client Stock Holdings Concentration"
        Me.CheckBox5.UseVisualStyleBackColor = True
        '
        'CheckBox6
        '
        Me.CheckBox6.AutoSize = True
        Me.CheckBox6.Location = New System.Drawing.Point(15, 137)
        Me.CheckBox6.Name = "CheckBox6"
        Me.CheckBox6.Size = New System.Drawing.Size(161, 19)
        Me.CheckBox6.TabIndex = 68
        Me.CheckBox6.Text = "Connected Transactions"
        Me.CheckBox6.UseVisualStyleBackColor = True
        '
        'CheckBox7
        '
        Me.CheckBox7.AutoSize = True
        Me.CheckBox7.Location = New System.Drawing.Point(15, 162)
        Me.CheckBox7.Name = "CheckBox7"
        Me.CheckBox7.Size = New System.Drawing.Size(299, 19)
        Me.CheckBox7.TabIndex = 69
        Me.CheckBox7.Text = "Debit Margin Client Balance (+$1M) Concentration"
        Me.CheckBox7.UseVisualStyleBackColor = True
        '
        'frmRptCRCAllinOne
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(446, 587)
        Me.Controls.Add(Me.CheckBox7)
        Me.Controls.Add(Me.CheckBox6)
        Me.Controls.Add(Me.CheckBox5)
        Me.Controls.Add(Me.CheckBox4)
        Me.Controls.Add(Me.CheckBox3)
        Me.Controls.Add(Me.CheckBox2)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.PrintOption)
        Me.KeyPreview = True
        Me.Name = "frmRptCRCAllinOne"
        Me.Text = "CRC Report (All in One)"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.PrintOption, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.CheckBox1, 0)
        Me.Controls.SetChildIndex(Me.CheckBox2, 0)
        Me.Controls.SetChildIndex(Me.CheckBox3, 0)
        Me.Controls.SetChildIndex(Me.CheckBox4, 0)
        Me.Controls.SetChildIndex(Me.CheckBox5, 0)
        Me.Controls.SetChildIndex(Me.CheckBox6, 0)
        Me.Controls.SetChildIndex(Me.CheckBox7, 0)
        Me.PrintOption.ResumeLayout(False)
        Me.PrintOption.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents PrintOption As System.Windows.Forms.GroupBox
    Friend WithEvents rbtPrint As ESL.myRadioButton
    Friend WithEvents rbtPreview As ESL.myRadioButton
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents PrintDialog1 As System.Windows.Forms.PrintDialog
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox3 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox4 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox5 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox6 As System.Windows.Forms.CheckBox
    Friend WithEvents CheckBox7 As System.Windows.Forms.CheckBox

End Class
