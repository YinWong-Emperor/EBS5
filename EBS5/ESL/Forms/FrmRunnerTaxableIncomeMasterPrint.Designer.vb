<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRunnerTaxableIncomeMasterPrint
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.rdbPrinter = New System.Windows.Forms.RadioButton()
        Me.rdbPrintPreview = New System.Windows.Forms.RadioButton()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtRangeMember = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxRangeTo = New System.Windows.Forms.ComboBox()
        Me.cbxRangeFrom = New System.Windows.Forms.ComboBox()
        Me.rdbRangeChoose = New System.Windows.Forms.RadioButton()
        Me.rdbRangeAll = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.rdbStatementOfWithheldRemuneration = New System.Windows.Forms.RadioButton()
        Me.rdbStatementOfTaxableIncome = New System.Windows.Forms.RadioButton()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Location = New System.Drawing.Point(429, 326)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(32, 326)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(467, 296)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 238)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Print Report"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(17, 146)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(87, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Record Range"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(17, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Report Type"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.rdbPrinter)
        Me.GroupBox4.Controls.Add(Me.rdbPrintPreview)
        Me.GroupBox4.Location = New System.Drawing.Point(130, 204)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(317, 76)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Print Option"
        '
        'rdbPrinter
        '
        Me.rdbPrinter.AutoSize = True
        Me.rdbPrinter.Location = New System.Drawing.Point(19, 45)
        Me.rdbPrinter.Name = "rdbPrinter"
        Me.rdbPrinter.Size = New System.Drawing.Size(147, 19)
        Me.rdbPrinter.TabIndex = 0
        Me.rdbPrinter.Text = "Send to Printer directly"
        Me.rdbPrinter.UseVisualStyleBackColor = True
        '
        'rdbPrintPreview
        '
        Me.rdbPrintPreview.AutoSize = True
        Me.rdbPrintPreview.Checked = True
        Me.rdbPrintPreview.Location = New System.Drawing.Point(19, 20)
        Me.rdbPrintPreview.Name = "rdbPrintPreview"
        Me.rdbPrintPreview.Size = New System.Drawing.Size(143, 19)
        Me.rdbPrintPreview.TabIndex = 0
        Me.rdbPrintPreview.TabStop = True
        Me.rdbPrintPreview.Text = "Print Preview Window"
        Me.rdbPrintPreview.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtRangeMember)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.cbxRangeTo)
        Me.GroupBox3.Controls.Add(Me.cbxRangeFrom)
        Me.GroupBox3.Controls.Add(Me.rdbRangeChoose)
        Me.GroupBox3.Controls.Add(Me.rdbRangeAll)
        Me.GroupBox3.Location = New System.Drawing.Point(130, 113)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(317, 76)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Record Option"
        '
        'txtRangeMember
        '
        Me.txtRangeMember.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtRangeMember.Location = New System.Drawing.Point(271, 42)
        Me.txtRangeMember.MaxLength = 1
        Me.txtRangeMember.Name = "txtRangeMember"
        Me.txtRangeMember.Size = New System.Drawing.Size(22, 21)
        Me.txtRangeMember.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(213, 45)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(52, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Member"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(102, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 15)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "To"
        '
        'cbxRangeTo
        '
        Me.cbxRangeTo.FormattingEnabled = True
        Me.cbxRangeTo.Location = New System.Drawing.Point(126, 41)
        Me.cbxRangeTo.MaxLength = 5
        Me.cbxRangeTo.Name = "cbxRangeTo"
        Me.cbxRangeTo.Size = New System.Drawing.Size(60, 23)
        Me.cbxRangeTo.TabIndex = 2
        '
        'cbxRangeFrom
        '
        Me.cbxRangeFrom.FormattingEnabled = True
        Me.cbxRangeFrom.Location = New System.Drawing.Point(39, 41)
        Me.cbxRangeFrom.MaxLength = 5
        Me.cbxRangeFrom.Name = "cbxRangeFrom"
        Me.cbxRangeFrom.Size = New System.Drawing.Size(60, 23)
        Me.cbxRangeFrom.TabIndex = 1
        '
        'rdbRangeChoose
        '
        Me.rdbRangeChoose.AutoSize = True
        Me.rdbRangeChoose.Location = New System.Drawing.Point(19, 45)
        Me.rdbRangeChoose.Name = "rdbRangeChoose"
        Me.rdbRangeChoose.Size = New System.Drawing.Size(14, 13)
        Me.rdbRangeChoose.TabIndex = 0
        Me.rdbRangeChoose.UseVisualStyleBackColor = True
        '
        'rdbRangeAll
        '
        Me.rdbRangeAll.AutoSize = True
        Me.rdbRangeAll.Checked = True
        Me.rdbRangeAll.Location = New System.Drawing.Point(19, 20)
        Me.rdbRangeAll.Name = "rdbRangeAll"
        Me.rdbRangeAll.Size = New System.Drawing.Size(38, 19)
        Me.rdbRangeAll.TabIndex = 0
        Me.rdbRangeAll.TabStop = True
        Me.rdbRangeAll.Text = "All"
        Me.rdbRangeAll.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rdbStatementOfWithheldRemuneration)
        Me.GroupBox2.Controls.Add(Me.rdbStatementOfTaxableIncome)
        Me.GroupBox2.Location = New System.Drawing.Point(130, 20)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(317, 76)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Report Type"
        '
        'rdbStatementOfWithheldRemuneration
        '
        Me.rdbStatementOfWithheldRemuneration.AutoSize = True
        Me.rdbStatementOfWithheldRemuneration.Location = New System.Drawing.Point(19, 46)
        Me.rdbStatementOfWithheldRemuneration.Name = "rdbStatementOfWithheldRemuneration"
        Me.rdbStatementOfWithheldRemuneration.Size = New System.Drawing.Size(227, 19)
        Me.rdbStatementOfWithheldRemuneration.TabIndex = 0
        Me.rdbStatementOfWithheldRemuneration.Text = "Statement of Withheld Remuneration"
        Me.rdbStatementOfWithheldRemuneration.UseVisualStyleBackColor = True
        '
        'rdbStatementOfTaxableIncome
        '
        Me.rdbStatementOfTaxableIncome.AutoSize = True
        Me.rdbStatementOfTaxableIncome.Checked = True
        Me.rdbStatementOfTaxableIncome.Location = New System.Drawing.Point(19, 21)
        Me.rdbStatementOfTaxableIncome.Name = "rdbStatementOfTaxableIncome"
        Me.rdbStatementOfTaxableIncome.Size = New System.Drawing.Size(183, 19)
        Me.rdbStatementOfTaxableIncome.TabIndex = 0
        Me.rdbStatementOfTaxableIncome.TabStop = True
        Me.rdbStatementOfTaxableIncome.Text = "Statement of Taxable Income"
        Me.rdbStatementOfTaxableIncome.UseVisualStyleBackColor = True
        '
        'btnPrint
        '
        Me.btnPrint.Image = Global.ESL.My.Resources.Resources.Printer
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnPrint.Location = New System.Drawing.Point(373, 326)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'FrmRunnerTaxableIncomeMasterPrint
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(498, 394)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FrmRunnerTaxableIncomeMasterPrint"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "PRINT GL RECORD"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtRangeMember As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbxRangeTo As System.Windows.Forms.ComboBox
    Friend WithEvents cbxRangeFrom As System.Windows.Forms.ComboBox
    Friend WithEvents rdbRangeChoose As System.Windows.Forms.RadioButton
    Friend WithEvents rdbRangeAll As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbStatementOfWithheldRemuneration As System.Windows.Forms.RadioButton
    Friend WithEvents rdbStatementOfTaxableIncome As System.Windows.Forms.RadioButton
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents rdbPrinter As System.Windows.Forms.RadioButton
    Friend WithEvents rdbPrintPreview As System.Windows.Forms.RadioButton
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button

End Class
