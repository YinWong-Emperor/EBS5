<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportFuturesComm
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
        Me.nudYear = New ESL.myNumericUpDown(Me.components)
        Me.nudMonth = New ESL.myNumericUpDown(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudMonth, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(266, 144)
        Me.btnCancel.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(210, 144)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Visible = True
        '
        'nudYear
        '
        Me.nudYear.Location = New System.Drawing.Point(87, 93)
        Me.nudYear.Maximum = New Decimal(New Integer() {3000, 0, 0, 0})
        Me.nudYear.Minimum = New Decimal(New Integer() {2005, 0, 0, 0})
        Me.nudYear.Name = "nudYear"
        Me.nudYear.Size = New System.Drawing.Size(85, 21)
        Me.nudYear.TabIndex = 0
        Me.nudYear.Value = New Decimal(New Integer() {2005, 0, 0, 0})
        '
        'nudMonth
        '
        Me.nudMonth.Location = New System.Drawing.Point(231, 93)
        Me.nudMonth.Maximum = New Decimal(New Integer() {12, 0, 0, 0})
        Me.nudMonth.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.nudMonth.Name = "nudMonth"
        Me.nudMonth.Size = New System.Drawing.Size(85, 21)
        Me.nudMonth.TabIndex = 1
        Me.nudMonth.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(49, 95)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(32, 15)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Year"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(185, 95)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Month"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(73, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(238, 22)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Import Commission Data"
        '
        'FrmImportFuturesComm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(385, 259)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.nudMonth)
        Me.Controls.Add(Me.nudYear)
        Me.KeyPreview = True
        Me.Name = "FrmImportFuturesComm"
        Me.Text = "Import Futures Commission"
        Me.Controls.SetChildIndex(Me.nudYear, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.nudMonth, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        CType(Me.nudYear, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudMonth, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents nudYear As ESL.myNumericUpDown
    Friend WithEvents nudMonth As ESL.myNumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label

End Class
