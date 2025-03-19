<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExptStockCon
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
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExptStockCon = New ESL.myButton(Me.components)
        Me.dpStock = New ESL.myDateTimePicker
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(272, 112)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(220, 112)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(55, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 22)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Export Stock Concentration"
        '
        'btnExptStockCon
        '
        Me.btnExptStockCon.Location = New System.Drawing.Point(59, 63)
        Me.btnExptStockCon.Name = "btnExptStockCon"
        Me.btnExptStockCon.Size = New System.Drawing.Size(138, 27)
        Me.btnExptStockCon.TabIndex = 9
        Me.btnExptStockCon.Text = "Export Stock"
        Me.btnExptStockCon.UseVisualStyleBackColor = True
        '
        'dpStock
        '
        Me.dpStock.CustomFormat = "dd MMM yyyy"
        Me.dpStock.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpStock.Location = New System.Drawing.Point(219, 66)
        Me.dpStock.Name = "dpStock"
        Me.dpStock.Size = New System.Drawing.Size(103, 21)
        Me.dpStock.TabIndex = 10
        '
        'FrmExptStockCon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(391, 215)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExptStockCon)
        Me.Controls.Add(Me.dpStock)
        Me.KeyPreview = True
        Me.Name = "FrmExptStockCon"
        Me.Text = "Export Stock Concentration"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.dpStock, 0)
        Me.Controls.SetChildIndex(Me.btnExptStockCon, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExptStockCon As ESL.myButton
    Friend WithEvents dpStock As ESL.myDateTimePicker

End Class
