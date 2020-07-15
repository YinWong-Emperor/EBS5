<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportLiqData
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
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.lbllaststatus1 = New System.Windows.Forms.Label
        Me.lbllaststatus2 = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(468, 398)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(412, 398)
        Me.btnSave.Visible = True
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Location = New System.Drawing.Point(27, 356)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(491, 23)
        Me.ProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.ProgressBar1.TabIndex = 6
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.LemonChiffon
        Me.ListBox1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Red
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 22
        Me.ListBox1.Location = New System.Drawing.Point(27, 47)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(491, 312)
        Me.ListBox1.TabIndex = 9
        Me.ListBox1.TabStop = False
        '
        'lbllaststatus1
        '
        Me.lbllaststatus1.AutoSize = True
        Me.lbllaststatus1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllaststatus1.Location = New System.Drawing.Point(24, 398)
        Me.lbllaststatus1.Name = "lbllaststatus1"
        Me.lbllaststatus1.Size = New System.Drawing.Size(45, 15)
        Me.lbllaststatus1.TabIndex = 10
        Me.lbllaststatus1.Text = "Label1"
        '
        'lbllaststatus2
        '
        Me.lbllaststatus2.AutoSize = True
        Me.lbllaststatus2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbllaststatus2.Location = New System.Drawing.Point(24, 438)
        Me.lbllaststatus2.Name = "lbllaststatus2"
        Me.lbllaststatus2.Size = New System.Drawing.Size(45, 15)
        Me.lbllaststatus2.TabIndex = 11
        Me.lbllaststatus2.Text = "Label2"
        '
        'FrmImportLiqData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(546, 507)
        Me.Controls.Add(Me.lbllaststatus2)
        Me.Controls.Add(Me.lbllaststatus1)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.KeyPreview = True
        Me.Name = "FrmImportLiqData"
        Me.Text = "Import Liquidation Data"
        Me.Controls.SetChildIndex(Me.ProgressBar1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.ListBox1, 0)
        Me.Controls.SetChildIndex(Me.lbllaststatus1, 0)
        Me.Controls.SetChildIndex(Me.lbllaststatus2, 0)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ProgressBar1 As System.Windows.Forms.ProgressBar
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents lbllaststatus1 As System.Windows.Forms.Label
    Friend WithEvents lbllaststatus2 As System.Windows.Forms.Label

End Class
