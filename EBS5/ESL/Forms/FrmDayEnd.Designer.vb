<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmDayEnd
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.ListBox1 = New System.Windows.Forms.ListBox
        Me.MyTextbox2 = New ESL.myTextbox
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(431, 377)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.TabStop = False
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(375, 377)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ListBox1)
        Me.GroupBox1.Controls.Add(Me.MyTextbox2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 10)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(503, 361)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "DayEnd"
        '
        'ListBox1
        '
        Me.ListBox1.BackColor = System.Drawing.Color.LemonChiffon
        Me.ListBox1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListBox1.ForeColor = System.Drawing.Color.Red
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 22
        Me.ListBox1.Location = New System.Drawing.Point(6, 20)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.ScrollAlwaysVisible = True
        Me.ListBox1.Size = New System.Drawing.Size(491, 312)
        Me.ListBox1.TabIndex = 2
        Me.ListBox1.TabStop = False
        '
        'MyTextbox2
        '
        Me.MyTextbox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.MyTextbox2.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyTextbox2.Location = New System.Drawing.Point(353, 333)
        Me.MyTextbox2.MaxLength = 1
        Me.MyTextbox2.Name = "MyTextbox2"
        Me.MyTextbox2.Size = New System.Drawing.Size(16, 26)
        Me.MyTextbox2.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(83, 335)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(262, 18)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Proceed to DAYEND process? (Y/N)"
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(12, 386)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 8
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(12, 406)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(503, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 7
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(185, 386)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 15)
        Me.Label2.TabIndex = 9
        '
        'FrmDayEnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(527, 434)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "FrmDayEnd"
        Me.Text = "DayEnd"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents MyTextbox2 As ESL.myTextbox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents Label2 As System.Windows.Forms.Label

End Class
