<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDataRestore
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
        Me.Label3 = New System.Windows.Forms.Label
        Me.TxtBPath = New ESL.myTextbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.RdAccount = New System.Windows.Forms.RadioButton
        Me.RdLiq = New System.Windows.Forms.RadioButton
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.cboFileName = New ESL.myComboBox(Me.components)
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Image = Nothing
        Me.btnCancel.Location = New System.Drawing.Point(430, 132)
        Me.btnCancel.Size = New System.Drawing.Size(72, 32)
        Me.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnSave
        '
        Me.btnSave.Image = Nothing
        Me.btnSave.Location = New System.Drawing.Point(350, 133)
        Me.btnSave.Size = New System.Drawing.Size(74, 32)
        Me.btnSave.Text = "Start"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.btnSave.Visible = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(470, 41)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 15)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "(Server)"
        '
        'TxtBPath
        '
        Me.TxtBPath.Location = New System.Drawing.Point(84, 35)
        Me.TxtBPath.Name = "TxtBPath"
        Me.TxtBPath.ReadOnly = True
        Me.TxtBPath.Size = New System.Drawing.Size(380, 21)
        Me.TxtBPath.TabIndex = 12
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(0, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Backup Path:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(2, 2)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(86, 19)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Branch is "
        '
        'RdAccount
        '
        Me.RdAccount.AutoSize = True
        Me.RdAccount.Checked = True
        Me.RdAccount.Location = New System.Drawing.Point(84, 73)
        Me.RdAccount.Name = "RdAccount"
        Me.RdAccount.Size = New System.Drawing.Size(89, 19)
        Me.RdAccount.TabIndex = 14
        Me.RdAccount.TabStop = True
        Me.RdAccount.Text = "For Account"
        Me.RdAccount.UseVisualStyleBackColor = True
        '
        'RdLiq
        '
        Me.RdLiq.AutoSize = True
        Me.RdLiq.Location = New System.Drawing.Point(200, 73)
        Me.RdLiq.Name = "RdLiq"
        Me.RdLiq.Size = New System.Drawing.Size(107, 19)
        Me.RdLiq.TabIndex = 15
        Me.RdLiq.Text = "For Liquidation"
        Me.RdLiq.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.Brown
        Me.Label4.Location = New System.Drawing.Point(307, 105)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(45, 15)
        Me.Label4.TabIndex = 20
        Me.Label4.Text = "Label4"
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(9, 132)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 22
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(9, 152)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(331, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 21
        '
        'cboFileName
        '
        Me.cboFileName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFileName.FormattingEnabled = True
        Me.cboFileName.Location = New System.Drawing.Point(78, 102)
        Me.cboFileName.Name = "cboFileName"
        Me.cboFileName.Size = New System.Drawing.Size(223, 23)
        Me.cboFileName.TabIndex = 23
        '
        'FrmDataRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(531, 177)
        Me.Controls.Add(Me.cboFileName)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.RdLiq)
        Me.Controls.Add(Me.RdAccount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TxtBPath)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmDataRestore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Database Restore"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.TxtBPath, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.RdAccount, 0)
        Me.Controls.SetChildIndex(Me.RdLiq, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.cboFileName, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TxtBPath As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents RdAccount As System.Windows.Forms.RadioButton
    Friend WithEvents RdLiq As System.Windows.Forms.RadioButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents cboFileName As ESL.myComboBox

End Class
