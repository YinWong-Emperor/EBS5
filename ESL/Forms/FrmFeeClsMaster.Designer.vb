<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFeeClsMaster
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
        Me.rbProd = New ESL.myRadioButton(Me.components)
        Me.rbUAT = New ESL.myRadioButton(Me.components)
        Me.txtDB = New ESL.myTextbox
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(201, 134)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(145, 134)
        Me.btnSave.Visible = True
        '
        'rbProd
        '
        Me.rbProd.AutoSize = True
        Me.rbProd.Location = New System.Drawing.Point(75, 51)
        Me.rbProd.Name = "rbProd"
        Me.rbProd.Size = New System.Drawing.Size(60, 19)
        Me.rbProd.TabIndex = 6
        Me.rbProd.TabStop = True
        Me.rbProd.Text = "PROD"
        Me.rbProd.UseVisualStyleBackColor = True
        '
        'rbUAT
        '
        Me.rbUAT.AutoSize = True
        Me.rbUAT.Checked = True
        Me.rbUAT.Location = New System.Drawing.Point(175, 51)
        Me.rbUAT.Name = "rbUAT"
        Me.rbUAT.Size = New System.Drawing.Size(48, 19)
        Me.rbUAT.TabIndex = 7
        Me.rbUAT.TabStop = True
        Me.rbUAT.Text = "UAT"
        Me.rbUAT.UseVisualStyleBackColor = True
        '
        'txtDB
        '
        Me.txtDB.Location = New System.Drawing.Point(75, 89)
        Me.txtDB.Name = "txtDB"
        Me.txtDB.Size = New System.Drawing.Size(176, 21)
        Me.txtDB.TabIndex = 8
        Me.txtDB.Text = "G2BF_RET"
        '
        'FrmFeeClsMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(325, 239)
        Me.Controls.Add(Me.txtDB)
        Me.Controls.Add(Me.rbUAT)
        Me.Controls.Add(Me.rbProd)
        Me.KeyPreview = True
        Me.Name = "FrmFeeClsMaster"
        Me.Text = "frmBase          User:      Trade Date: 01/01/0001"
        Me.Controls.SetChildIndex(Me.rbProd, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.rbUAT, 0)
        Me.Controls.SetChildIndex(Me.txtDB, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbProd As ESL.myRadioButton
    Friend WithEvents rbUAT As ESL.myRadioButton
    Friend WithEvents txtDB As ESL.myTextbox

End Class
