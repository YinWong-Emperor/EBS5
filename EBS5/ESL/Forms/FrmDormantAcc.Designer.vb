<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDormantAcc
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
        Me.dpFrom = New ESL.myDateTimePicker
        Me.Label11 = New System.Windows.Forms.Label
        Me.btnExport = New ESL.myButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(243, 118)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(187, 118)
        '
        'dpFrom
        '
        Me.dpFrom.CustomFormat = "dd MMM yyyy"
        Me.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFrom.Location = New System.Drawing.Point(187, 69)
        Me.dpFrom.Name = "dpFrom"
        Me.dpFrom.Size = New System.Drawing.Size(106, 21)
        Me.dpFrom.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(57, 25)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(211, 22)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Dormant Account List"
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(187, 118)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 39
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 72)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(153, 15)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Dormant account list since"
        '
        'FrmDormantAcc
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(332, 212)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.dpFrom)
        Me.KeyPreview = True
        Me.Name = "FrmDormantAcc"
        Me.Text = "Dormant Account List"
        Me.Controls.SetChildIndex(Me.dpFrom, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dpFrom As ESL.myDateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
