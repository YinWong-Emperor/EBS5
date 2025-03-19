<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportData
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
        Me.txtMessage = New ESL.myTextbox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCurrentTradeDate = New System.Windows.Forms.Label()
        Me.lblNextTradeDate = New System.Windows.Forms.Label()
        Me.pgbImport = New System.Windows.Forms.ProgressBar()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(560, 409)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(508, 409)
        Me.btnSave.Text = "Import"
        Me.btnSave.Visible = True
        '
        'txtMessage
        '
        Me.txtMessage.Location = New System.Drawing.Point(12, 85)
        Me.txtMessage.Multiline = True
        Me.txtMessage.Name = "txtMessage"
        Me.txtMessage.ReadOnly = True
        Me.txtMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtMessage.Size = New System.Drawing.Size(598, 287)
        Me.txtMessage.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(115, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Current Trade Date:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 15)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Next Trade Date:"
        '
        'lblCurrentTradeDate
        '
        Me.lblCurrentTradeDate.AutoSize = True
        Me.lblCurrentTradeDate.Location = New System.Drawing.Point(127, 17)
        Me.lblCurrentTradeDate.Name = "lblCurrentTradeDate"
        Me.lblCurrentTradeDate.Size = New System.Drawing.Size(112, 15)
        Me.lblCurrentTradeDate.TabIndex = 7
        Me.lblCurrentTradeDate.Text = "Current Trade Date"
        '
        'lblNextTradeDate
        '
        Me.lblNextTradeDate.AutoSize = True
        Me.lblNextTradeDate.Location = New System.Drawing.Point(127, 41)
        Me.lblNextTradeDate.Name = "lblNextTradeDate"
        Me.lblNextTradeDate.Size = New System.Drawing.Size(95, 15)
        Me.lblNextTradeDate.TabIndex = 7
        Me.lblNextTradeDate.Text = "Next Trade Date"
        '
        'pgbImport
        '
        Me.pgbImport.Location = New System.Drawing.Point(13, 379)
        Me.pgbImport.Name = "pgbImport"
        Me.pgbImport.Size = New System.Drawing.Size(597, 23)
        Me.pgbImport.TabIndex = 8
        Me.pgbImport.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.lblNextTradeDate)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.lblCurrentTradeDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(597, 67)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        '
        'FrmImportData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(625, 477)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.pgbImport)
        Me.Controls.Add(Me.txtMessage)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "FrmImportData"
        Me.Text = "Import Data"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.txtMessage, 0)
        Me.Controls.SetChildIndex(Me.pgbImport, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtMessage As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCurrentTradeDate As System.Windows.Forms.Label
    Friend WithEvents lblNextTradeDate As System.Windows.Forms.Label
    Friend WithEvents pgbImport As System.Windows.Forms.ProgressBar
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
