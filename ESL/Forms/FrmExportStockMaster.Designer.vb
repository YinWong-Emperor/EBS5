<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmExportStockMaster
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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btnRemoveAllPt = New ESL.myButton(Me.components)
        Me.btnAddAllPt = New ESL.myButton(Me.components)
        Me.btnRemovePt = New ESL.myButton(Me.components)
        Me.btnAddPt = New ESL.myButton(Me.components)
        Me.lstSelectedProductType = New ESL.myListBox(Me.components)
        Me.lstProductType = New ESL.myListBox(Me.components)
        Me.dtpCpDate = New ESL.myDateTimePicker()
        Me.btnExport = New ESL.myButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(475, 290)
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(419, 290)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(177, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(199, 22)
        Me.Label1.TabIndex = 102
        Me.Label1.Text = "Export Stock Master"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 209)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 15)
        Me.Label2.TabIndex = 103
        Me.Label2.Text = "Closing Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 15)
        Me.Label3.TabIndex = 105
        Me.Label3.Text = "Product Type"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.btnRemoveAllPt)
        Me.GroupBox1.Controls.Add(Me.btnAddAllPt)
        Me.GroupBox1.Controls.Add(Me.btnRemovePt)
        Me.GroupBox1.Controls.Add(Me.btnAddPt)
        Me.GroupBox1.Controls.Add(Me.lstSelectedProductType)
        Me.GroupBox1.Controls.Add(Me.lstProductType)
        Me.GroupBox1.Controls.Add(Me.dtpCpDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 43)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(537, 240)
        Me.GroupBox1.TabIndex = 107
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Export Criteria"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(139, 21)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(129, 15)
        Me.Label5.TabIndex = 133
        Me.Label5.Text = "Available Product Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(364, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(128, 15)
        Me.Label4.TabIndex = 132
        Me.Label4.Text = "Selected Product Type"
        '
        'btnRemoveAllPt
        '
        Me.btnRemoveAllPt.Location = New System.Drawing.Point(299, 140)
        Me.btnRemoveAllPt.Name = "btnRemoveAllPt"
        Me.btnRemoveAllPt.Size = New System.Drawing.Size(38, 23)
        Me.btnRemoveAllPt.TabIndex = 131
        Me.btnRemoveAllPt.Text = "<<"
        Me.btnRemoveAllPt.UseVisualStyleBackColor = True
        '
        'btnAddAllPt
        '
        Me.btnAddAllPt.Location = New System.Drawing.Point(299, 53)
        Me.btnAddAllPt.Name = "btnAddAllPt"
        Me.btnAddAllPt.Size = New System.Drawing.Size(38, 23)
        Me.btnAddAllPt.TabIndex = 130
        Me.btnAddAllPt.Text = ">>"
        Me.btnAddAllPt.UseVisualStyleBackColor = True
        '
        'btnRemovePt
        '
        Me.btnRemovePt.Location = New System.Drawing.Point(299, 111)
        Me.btnRemovePt.Name = "btnRemovePt"
        Me.btnRemovePt.Size = New System.Drawing.Size(38, 23)
        Me.btnRemovePt.TabIndex = 129
        Me.btnRemovePt.Text = "<"
        Me.btnRemovePt.UseVisualStyleBackColor = True
        '
        'btnAddPt
        '
        Me.btnAddPt.Location = New System.Drawing.Point(299, 82)
        Me.btnAddPt.Name = "btnAddPt"
        Me.btnAddPt.Size = New System.Drawing.Size(38, 23)
        Me.btnAddPt.TabIndex = 128
        Me.btnAddPt.Text = ">"
        Me.btnAddPt.UseVisualStyleBackColor = True
        '
        'lbSelectedProductType
        '
        Me.lstSelectedProductType.FormattingEnabled = True
        Me.lstSelectedProductType.ItemHeight = 15
        Me.lstSelectedProductType.Location = New System.Drawing.Point(343, 47)
        Me.lstSelectedProductType.Name = "lbSelectedProductType"
        Me.lstSelectedProductType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstSelectedProductType.Size = New System.Drawing.Size(175, 124)
        Me.lstSelectedProductType.TabIndex = 127
        '
        'lbProductType
        '
        Me.lstProductType.FormattingEnabled = True
        Me.lstProductType.ItemHeight = 15
        Me.lstProductType.Location = New System.Drawing.Point(118, 46)
        Me.lstProductType.Name = "lbProductType"
        Me.lstProductType.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended
        Me.lstProductType.Size = New System.Drawing.Size(175, 124)
        Me.lstProductType.TabIndex = 126
        '
        'dtpCpDate
        '
        Me.dtpCpDate.Checked = False
        Me.dtpCpDate.CustomFormat = ""
        Me.dtpCpDate.Location = New System.Drawing.Point(117, 207)
        Me.dtpCpDate.Name = "dtpCpDate"
        Me.dtpCpDate.ShowCheckBox = True
        Me.dtpCpDate.Size = New System.Drawing.Size(175, 21)
        Me.dtpCpDate.TabIndex = 125
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(419, 290)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 109
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'FrmExportStockMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(554, 357)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.KeyPreview = True
        Me.Name = "FrmExportStockMaster"
        Me.Text = "Export Stock Master"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpCpDate As ESL.myDateTimePicker
    Friend WithEvents lstProductType As ESL.myListBox
    Friend WithEvents lstSelectedProductType As ESL.myListBox
    Friend WithEvents btnRemovePt As ESL.myButton
    Friend WithEvents btnAddPt As ESL.myButton
    Friend WithEvents btnRemoveAllPt As ESL.myButton
    Friend WithEvents btnAddAllPt As ESL.myButton
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnExport As ESL.myButton
End Class
