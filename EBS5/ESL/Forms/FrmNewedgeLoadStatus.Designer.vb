<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmNewedgeLoadStatus
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
        Me.lbtdate = New System.Windows.Forms.ListBox
        Me.rtbcontent = New System.Windows.Forms.RichTextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(781, 397)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(719, 397)
        '
        'lbtdate
        '
        Me.lbtdate.FormattingEnabled = True
        Me.lbtdate.HorizontalScrollbar = True
        Me.lbtdate.ItemHeight = 15
        Me.lbtdate.Location = New System.Drawing.Point(12, 87)
        Me.lbtdate.Name = "lbtdate"
        Me.lbtdate.Size = New System.Drawing.Size(103, 289)
        Me.lbtdate.Sorted = True
        Me.lbtdate.TabIndex = 6
        '
        'rtbcontent
        '
        Me.rtbcontent.Font = New System.Drawing.Font("Courier New", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbcontent.Location = New System.Drawing.Point(118, 87)
        Me.rtbcontent.Name = "rtbcontent"
        Me.rtbcontent.ReadOnly = True
        Me.rtbcontent.Size = New System.Drawing.Size(713, 289)
        Me.rtbcontent.TabIndex = 7
        Me.rtbcontent.Text = ""
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(322, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(211, 22)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Futures Import Status"
        '
        'FrmNewedgeLoadStatus
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(844, 498)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lbtdate)
        Me.Controls.Add(Me.rtbcontent)
        Me.KeyPreview = True
        Me.Name = "FrmNewedgeLoadStatus"
        Me.Text = "Futures Import Status"
        Me.Controls.SetChildIndex(Me.rtbcontent, 0)
        Me.Controls.SetChildIndex(Me.lbtdate, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbtdate As System.Windows.Forms.ListBox
    Friend WithEvents rtbcontent As System.Windows.Forms.RichTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label

End Class
