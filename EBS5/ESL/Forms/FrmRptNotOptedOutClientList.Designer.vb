<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmRptNotOptedOutClientList
    Inherits ESL.frmBase

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.rbAccNo = New System.Windows.Forms.RadioButton
        Me.rbBrancdAndAE = New System.Windows.Forms.RadioButton
        Me.btnExport = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.rbG2bs = New System.Windows.Forms.RadioButton
        Me.rbG2bf = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(431, 230)
        Me.btnCancel.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.btnCancel.TabIndex = 66
        '
        'rbAccNo
        '
        Me.rbAccNo.AutoSize = True
        Me.rbAccNo.Location = New System.Drawing.Point(154, 4)
        Me.rbAccNo.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbAccNo.Name = "rbAccNo"
        Me.rbAccNo.Size = New System.Drawing.Size(87, 19)
        Me.rbAccNo.TabIndex = 1
        Me.rbAccNo.TabStop = True
        Me.rbAccNo.Text = "Account No"
        Me.rbAccNo.UseVisualStyleBackColor = True
        '
        'rbBrancdAndAE
        '
        Me.rbBrancdAndAE.AutoSize = True
        Me.rbBrancdAndAE.Location = New System.Drawing.Point(3, 4)
        Me.rbBrancdAndAE.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbBrancdAndAE.Name = "rbBrancdAndAE"
        Me.rbBrancdAndAE.Size = New System.Drawing.Size(139, 19)
        Me.rbBrancdAndAE.TabIndex = 0
        Me.rbBrancdAndAE.TabStop = True
        Me.rbBrancdAndAE.Text = "Branch and AE Code"
        Me.rbBrancdAndAE.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExport.Location = New System.Drawing.Point(376, 230)
        Me.btnExport.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(49, 55)
        Me.btnExport.TabIndex = 65
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.Label1.Location = New System.Drawing.Point(109, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(238, 22)
        Me.Label1.TabIndex = 67
        Me.Label1.Text = "Not Opted-Out Client List"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 173)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(86, 12)
        Me.Label2.TabIndex = 68
        Me.Label2.Text = "Sorting Order By"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 12)
        Me.Label3.TabIndex = 71
        Me.Label3.Text = "Client Database"
        '
        'rbG2bs
        '
        Me.rbG2bs.AutoSize = True
        Me.rbG2bs.Location = New System.Drawing.Point(69, 4)
        Me.rbG2bs.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbG2bs.Name = "rbG2bs"
        Me.rbG2bs.Size = New System.Drawing.Size(57, 19)
        Me.rbG2bs.TabIndex = 70
        Me.rbG2bs.TabStop = True
        Me.rbG2bs.Text = "G2BS"
        Me.rbG2bs.UseVisualStyleBackColor = True
        '
        'rbG2bf
        '
        Me.rbG2bf.AutoSize = True
        Me.rbG2bf.Location = New System.Drawing.Point(2, 4)
        Me.rbG2bf.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.rbG2bf.Name = "rbG2bf"
        Me.rbG2bf.Size = New System.Drawing.Size(56, 19)
        Me.rbG2bf.TabIndex = 69
        Me.rbG2bf.TabStop = True
        Me.rbG2bf.Text = "G2BF"
        Me.rbG2bf.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbG2bs)
        Me.Panel1.Controls.Add(Me.rbG2bf)
        Me.Panel1.Location = New System.Drawing.Point(130, 116)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(202, 31)
        Me.Panel1.TabIndex = 72
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbBrancdAndAE)
        Me.Panel2.Controls.Add(Me.rbAccNo)
        Me.Panel2.Location = New System.Drawing.Point(130, 173)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(318, 36)
        Me.Panel2.TabIndex = 73
        '
        'FrmRptNotOptedOutClientList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(499, 301)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExport)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "FrmRptNotOptedOutClientList"
        Me.Text = "Not Opted-Out Client List"
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Panel2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents rbAccNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbBrancdAndAE As System.Windows.Forms.RadioButton
    Friend WithEvents btnExport As System.Windows.Forms.Button
    'Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbG2bs As System.Windows.Forms.RadioButton
    Friend WithEvents rbG2bf As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
End Class
