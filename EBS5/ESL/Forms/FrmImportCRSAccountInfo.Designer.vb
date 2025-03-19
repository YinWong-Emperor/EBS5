<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmImportCRSAccountInfo
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
        Me.components = New System.ComponentModel.Container()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnImport = New ESL.myButton(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.numReturnYear = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.numReturnYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(289, 124)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(113, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(236, 22)
        Me.Label1.TabIndex = 14
        Me.Label1.Text = "Import CRS Account Info"
        '
        'btnImport
        '
        Me.btnImport.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnImport.Location = New System.Drawing.Point(117, 124)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(108, 55)
        Me.btnImport.TabIndex = 15
        Me.btnImport.Text = "Import From Yearly Image"
        Me.btnImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.ItemHeight = 15
        Me.ListBox1.Location = New System.Drawing.Point(12, 205)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(421, 124)
        Me.ListBox1.TabIndex = 16
        '
        'numReturnYear
        '
        Me.numReturnYear.Location = New System.Drawing.Point(261, 71)
        Me.numReturnYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numReturnYear.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.numReturnYear.Name = "numReturnYear"
        Me.numReturnYear.Size = New System.Drawing.Size(78, 21)
        Me.numReturnYear.TabIndex = 67
        Me.numReturnYear.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(114, 73)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(93, 15)
        Me.Label2.TabIndex = 66
        Me.Label2.Text = "Financial Year : "
        '
        'FrmImportCRSAccountInfo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(445, 361)
        Me.Controls.Add(Me.numReturnYear)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmImportCRSAccountInfo"
        Me.Text = "Import CRS Account Info"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnImport, 0)
        Me.Controls.SetChildIndex(Me.ListBox1, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.numReturnYear, 0)
        CType(Me.numReturnYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub



    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImport As ESL.myButton
    Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
    Friend WithEvents numReturnYear As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
