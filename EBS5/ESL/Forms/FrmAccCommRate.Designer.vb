<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAccCommRate
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
        Me.btnNoAcc = New ESL.myButton(Me.components)
        Me.btnAccDetail = New ESL.myButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(485, 178)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(429, 178)
        '
        'btnNoAcc
        '
        Me.btnNoAcc.Location = New System.Drawing.Point(128, 39)
        Me.btnNoAcc.Name = "btnNoAcc"
        Me.btnNoAcc.Size = New System.Drawing.Size(120, 27)
        Me.btnNoAcc.TabIndex = 6
        Me.btnNoAcc.Text = "No. of A/C"
        Me.btnNoAcc.UseVisualStyleBackColor = True
        '
        'btnAccDetail
        '
        Me.btnAccDetail.Location = New System.Drawing.Point(295, 39)
        Me.btnAccDetail.Name = "btnAccDetail"
        Me.btnAccDetail.Size = New System.Drawing.Size(120, 27)
        Me.btnAccDetail.TabIndex = 7
        Me.btnAccDetail.Text = "A/C Details"
        Me.btnAccDetail.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(106, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(347, 22)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "A/C by Commission Rate (Securities)"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNoAcc)
        Me.GroupBox1.Controls.Add(Me.btnAccDetail)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 58)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(526, 100)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'FrmAccCommRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(566, 257)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmAccCommRate"
        Me.Text = "A/C by Commission Rate (Securities)"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnNoAcc As ESL.myButton
    Friend WithEvents btnAccDetail As ESL.myButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox

End Class
