<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCRS
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
        Me.gbCompany = New System.Windows.Forms.GroupBox()
        Me.rbFutures = New ESL.myRadioButton(Me.components)
        Me.rbSecurities = New ESL.myRadioButton(Me.components)
        Me.Label11 = New System.Windows.Forms.Label()
        Me.btnExport = New ESL.myButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.numReturnYear = New System.Windows.Forms.NumericUpDown()
        Me.gbCompany.SuspendLayout()
        CType(Me.numReturnYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(303, 148)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(241, 148)
        '
        'gbCompany
        '
        Me.gbCompany.Controls.Add(Me.rbFutures)
        Me.gbCompany.Controls.Add(Me.rbSecurities)
        Me.gbCompany.Location = New System.Drawing.Point(51, 95)
        Me.gbCompany.Name = "gbCompany"
        Me.gbCompany.Size = New System.Drawing.Size(302, 47)
        Me.gbCompany.TabIndex = 61
        Me.gbCompany.TabStop = False
        Me.gbCompany.Text = "Company"
        '
        'rbFutures
        '
        Me.rbFutures.AutoSize = True
        Me.rbFutures.Location = New System.Drawing.Point(201, 20)
        Me.rbFutures.Name = "rbFutures"
        Me.rbFutures.Size = New System.Drawing.Size(67, 19)
        Me.rbFutures.TabIndex = 62
        Me.rbFutures.Text = "Futures"
        Me.rbFutures.UseVisualStyleBackColor = True
        '
        'rbSecurities
        '
        Me.rbSecurities.AutoSize = True
        Me.rbSecurities.Checked = True
        Me.rbSecurities.Location = New System.Drawing.Point(23, 21)
        Me.rbSecurities.Name = "rbSecurities"
        Me.rbSecurities.Size = New System.Drawing.Size(80, 19)
        Me.rbSecurities.TabIndex = 61
        Me.rbSecurities.TabStop = True
        Me.rbSecurities.Text = "Securities"
        Me.rbSecurities.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(103, 22)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(205, 22)
        Me.Label11.TabIndex = 63
        Me.Label11.Text = "CRS XML Generation"
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(185, 148)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 64
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(81, 60)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(93, 15)
        Me.Label1.TabIndex = 63
        Me.Label1.Text = "Financial Year : "
        '
        'numReturnYear
        '
        Me.numReturnYear.Location = New System.Drawing.Point(241, 58)
        Me.numReturnYear.Maximum = New Decimal(New Integer() {9999, 0, 0, 0})
        Me.numReturnYear.Minimum = New Decimal(New Integer() {1900, 0, 0, 0})
        Me.numReturnYear.Name = "numReturnYear"
        Me.numReturnYear.Size = New System.Drawing.Size(78, 21)
        Me.numReturnYear.TabIndex = 65
        Me.numReturnYear.Value = New Decimal(New Integer() {2019, 0, 0, 0})
        '
        'frmCRS
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(412, 217)
        Me.Controls.Add(Me.numReturnYear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.gbCompany)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "frmCRS"
        Me.Text = "CRS XML Generation"
        Me.Controls.SetChildIndex(Me.gbCompany, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.numReturnYear, 0)
        Me.gbCompany.ResumeLayout(False)
        Me.gbCompany.PerformLayout()
        CType(Me.numReturnYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbCompany As System.Windows.Forms.GroupBox
    Friend WithEvents rbFutures As ESL.myRadioButton
    Friend WithEvents rbSecurities As ESL.myRadioButton
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents numReturnYear As System.Windows.Forms.NumericUpDown
End Class
