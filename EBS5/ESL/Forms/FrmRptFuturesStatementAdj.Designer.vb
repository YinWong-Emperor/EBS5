<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptFuturesStatementAdj
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
        Me.Label7 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.dtpTdate = New System.Windows.Forms.DateTimePicker
        Me.cbxCounterParty = New System.Windows.Forms.ComboBox
        Me.lblTdate = New System.Windows.Forms.Label
        Me.lblCounterParty = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCancel.Location = New System.Drawing.Point(331, 160)
        '
        'btnSave
        '
        Me.btnSave.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSave.Location = New System.Drawing.Point(12, 161)
        '
        'Label7
        '
        Me.Label7.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(12, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(369, 22)
        Me.Label7.TabIndex = 18
        Me.Label7.Text = "Adjustment Report"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnPrint
        '
        Me.btnPrint.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPrint.Location = New System.Drawing.Point(275, 160)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(50, 55)
        Me.btnPrint.TabIndex = 64
        Me.btnPrint.Text = "Print"
        Me.btnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnPrint.UseVisualStyleBackColor = True
        '
        'dtpTdate
        '
        Me.dtpTdate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpTdate.Location = New System.Drawing.Point(190, 63)
        Me.dtpTdate.Name = "dtpTdate"
        Me.dtpTdate.Size = New System.Drawing.Size(121, 21)
        Me.dtpTdate.TabIndex = 65
        '
        'cbxCounterParty
        '
        Me.cbxCounterParty.FormattingEnabled = True
        Me.cbxCounterParty.Location = New System.Drawing.Point(190, 90)
        Me.cbxCounterParty.Name = "cbxCounterParty"
        Me.cbxCounterParty.Size = New System.Drawing.Size(121, 23)
        Me.cbxCounterParty.TabIndex = 66
        '
        'lblTdate
        '
        Me.lblTdate.AutoSize = True
        Me.lblTdate.Location = New System.Drawing.Point(78, 66)
        Me.lblTdate.Name = "lblTdate"
        Me.lblTdate.Size = New System.Drawing.Size(68, 15)
        Me.lblTdate.TabIndex = 67
        Me.lblTdate.Text = "Trade Date"
        '
        'lblCounterParty
        '
        Me.lblCounterParty.AutoSize = True
        Me.lblCounterParty.Location = New System.Drawing.Point(78, 93)
        Me.lblCounterParty.Name = "lblCounterParty"
        Me.lblCounterParty.Size = New System.Drawing.Size(81, 15)
        Me.lblCounterParty.TabIndex = 68
        Me.lblCounterParty.Text = "Counter Party"
        '
        'FrmRptFuturesStatementAdj
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(393, 228)
        Me.Controls.Add(Me.lblCounterParty)
        Me.Controls.Add(Me.lblTdate)
        Me.Controls.Add(Me.cbxCounterParty)
        Me.Controls.Add(Me.dtpTdate)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Label7)
        Me.KeyPreview = True
        Me.Name = "FrmRptFuturesStatementAdj"
        Me.Text = "Adjustment Report"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnPrint, 0)
        Me.Controls.SetChildIndex(Me.dtpTdate, 0)
        Me.Controls.SetChildIndex(Me.cbxCounterParty, 0)
        Me.Controls.SetChildIndex(Me.lblTdate, 0)
        Me.Controls.SetChildIndex(Me.lblCounterParty, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents dtpTdate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cbxCounterParty As System.Windows.Forms.ComboBox
    Friend WithEvents lblTdate As System.Windows.Forms.Label
    Friend WithEvents lblCounterParty As System.Windows.Forms.Label

End Class
