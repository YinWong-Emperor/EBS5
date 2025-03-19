<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDailyNetTrade
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
        Me.btnAccOverLmt = New ESL.myButton(Me.components)
        Me.dpAcc = New ESL.myDateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(259, 114)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(203, 114)
        '
        'btnAccOverLmt
        '
        Me.btnAccOverLmt.Location = New System.Drawing.Point(47, 65)
        Me.btnAccOverLmt.Name = "btnAccOverLmt"
        Me.btnAccOverLmt.Size = New System.Drawing.Size(138, 27)
        Me.btnAccOverLmt.TabIndex = 6
        Me.btnAccOverLmt.Text = "A/C over Credit Limit"
        Me.btnAccOverLmt.UseVisualStyleBackColor = True
        '
        'dpAcc
        '
        Me.dpAcc.CustomFormat = "dd MMM yyyy"
        Me.dpAcc.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpAcc.Location = New System.Drawing.Point(206, 68)
        Me.dpAcc.Name = "dpAcc"
        Me.dpAcc.Size = New System.Drawing.Size(103, 21)
        Me.dpAcc.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(108, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(151, 22)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Daily Net Trade"
        '
        'FrmDailyNetTrade
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(371, 209)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnAccOverLmt)
        Me.Controls.Add(Me.dpAcc)
        Me.KeyPreview = True
        Me.Name = "FrmDailyNetTrade"
        Me.Text = "Daily Net Trade"
        Me.Controls.SetChildIndex(Me.dpAcc, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnAccOverLmt, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnAccOverLmt As ESL.myButton
    Friend WithEvents dpAcc As ESL.myDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
