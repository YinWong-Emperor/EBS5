<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmLoadNewedge
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
        Me.btnLoad = New ESL.myButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnLoadPdf = New ESL.myButton(Me.components)
        Me.btnLoadMarex = New ESL.myButton(Me.components)
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(248, 83)
        Me.btnCancel.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(192, 83)
        Me.btnSave.TabIndex = 3
        '
        'btnLoad
        '
        Me.btnLoad.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(174, 83)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(68, 55)
        Me.btnLoad.TabIndex = 0
        Me.btnLoad.TabStop = False
        Me.btnLoad.Text = "Load Newedge"
        Me.btnLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(53, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(245, 22)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "Import Futures Statement"
        '
        'btnLoadPdf
        '
        Me.btnLoadPdf.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadPdf.Location = New System.Drawing.Point(99, 83)
        Me.btnLoadPdf.Name = "btnLoadPdf"
        Me.btnLoadPdf.Size = New System.Drawing.Size(69, 55)
        Me.btnLoadPdf.TabIndex = 14
        Me.btnLoadPdf.Text = "Load ADM (PDF)"
        Me.btnLoadPdf.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoadPdf.UseVisualStyleBackColor = True
        '
        'btnLoadMarex
        '
        Me.btnLoadMarex.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoadMarex.Location = New System.Drawing.Point(24, 83)
        Me.btnLoadMarex.Name = "btnLoadMarex"
        Me.btnLoadMarex.Size = New System.Drawing.Size(69, 55)
        Me.btnLoadMarex.TabIndex = 15
        Me.btnLoadMarex.Text = "Load Marex"
        Me.btnLoadMarex.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoadMarex.UseVisualStyleBackColor = True
        '
        'FrmLoadNewedge
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(324, 194)
        Me.Controls.Add(Me.btnLoadMarex)
        Me.Controls.Add(Me.btnLoadPdf)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnLoad)
        Me.KeyPreview = True
        Me.Name = "FrmLoadNewedge"
        Me.Text = "Import Futures Statement"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnLoad, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnLoadPdf, 0)
        Me.Controls.SetChildIndex(Me.btnLoadMarex, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnLoad As ESL.myButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLoadPdf As ESL.myButton
    Friend WithEvents btnLoadMarex As ESL.myButton

End Class
