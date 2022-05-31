<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCommAE
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
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.CBOMonth = New System.Windows.Forms.ComboBox
        Me.txtLastGenerate = New ESL.myTextbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtLastImport = New ESL.myTextbox
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(402, 398)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(346, 398)
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(12, 117)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(440, 274)
        Me.ListBox1.TabIndex = 12
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(96, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(267, 24)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "AE Commission Generation"
        '
        'CBOMonth
        '
        Me.CBOMonth.Enabled = False
        Me.CBOMonth.FormattingEnabled = True
        Me.CBOMonth.Location = New System.Drawing.Point(12, 63)
        Me.CBOMonth.Name = "CBOMonth"
        Me.CBOMonth.Size = New System.Drawing.Size(108, 23)
        Me.CBOMonth.TabIndex = 10
        '
        'txtLastGenerate
        '
        Me.txtLastGenerate.Enabled = False
        Me.txtLastGenerate.Location = New System.Drawing.Point(325, 90)
        Me.txtLastGenerate.Name = "txtLastGenerate"
        Me.txtLastGenerate.Size = New System.Drawing.Size(127, 21)
        Me.txtLastGenerate.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(195, 93)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(124, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Last Generation Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(195, 66)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 15)
        Me.Label3.TabIndex = 16
        Me.Label3.Text = "Last Import Date"
        '
        'txtLastImport
        '
        Me.txtLastImport.Enabled = False
        Me.txtLastImport.Location = New System.Drawing.Point(325, 63)
        Me.txtLastImport.Name = "txtLastImport"
        Me.txtLastImport.Size = New System.Drawing.Size(127, 21)
        Me.txtLastImport.TabIndex = 15
        '
        'frmCommAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(464, 478)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtLastImport)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtLastGenerate)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBOMonth)
        Me.KeyPreview = True
        Me.Name = "frmCommAE"
        Me.Text = "FrmCommAE"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.CBOMonth, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.ListBox1, 0)
        Me.Controls.SetChildIndex(Me.txtLastGenerate, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtLastImport, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents CBOMonth As System.Windows.Forms.ComboBox
    Friend WithEvents txtLastGenerate As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtLastImport As ESL.myTextbox

End Class
