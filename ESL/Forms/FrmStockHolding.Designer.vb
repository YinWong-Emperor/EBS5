<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmStockHolding
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
        Me.rbMargin = New ESL.myRadioButton(Me.components)
        Me.rbDebitMargin = New ESL.myRadioButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(344, 179)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(288, 179)
        Me.btnSave.Visible = True
        '
        'rbMargin
        '
        Me.rbMargin.AutoSize = True
        Me.rbMargin.Checked = True
        Me.rbMargin.Location = New System.Drawing.Point(49, 88)
        Me.rbMargin.Name = "rbMargin"
        Me.rbMargin.Size = New System.Drawing.Size(183, 19)
        Me.rbMargin.TabIndex = 6
        Me.rbMargin.TabStop = True
        Me.rbMargin.Text = "Margin Client Stock Holdings"
        Me.rbMargin.UseVisualStyleBackColor = True
        '
        'rbDebitMargin
        '
        Me.rbDebitMargin.AutoSize = True
        Me.rbDebitMargin.Location = New System.Drawing.Point(49, 123)
        Me.rbDebitMargin.Name = "rbDebitMargin"
        Me.rbDebitMargin.Size = New System.Drawing.Size(305, 19)
        Me.rbDebitMargin.TabIndex = 7
        Me.rbDebitMargin.Text = "Debit Ledger Balance Margin Client Stock Holdings"
        Me.rbDebitMargin.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(45, 33)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(345, 22)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Export Margin Client Stock Holdings"
        '
        'FrmStockHolding
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(435, 274)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.rbDebitMargin)
        Me.Controls.Add(Me.rbMargin)
        Me.KeyPreview = True
        Me.Name = "FrmStockHolding"
        Me.Text = "Export Margin Client Stock Holdings"
        Me.Controls.SetChildIndex(Me.rbMargin, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.rbDebitMargin, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbMargin As ESL.myRadioButton
    Friend WithEvents rbDebitMargin As ESL.myRadioButton
    Friend WithEvents Label7 As System.Windows.Forms.Label

End Class
