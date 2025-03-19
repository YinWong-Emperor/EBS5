<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSuspendStock
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtgStock = New System.Windows.Forms.DataGridView
        Me.stock_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Last_Suspend_Date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rbAll = New ESL.myRadioButton(Me.components)
        Me.rbDate = New ESL.myRadioButton(Me.components)
        Me.dpFrom = New ESL.myDateTimePicker
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.dpTo = New ESL.myDateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnExport = New ESL.myButton(Me.components)
        Me.Label11 = New System.Windows.Forms.Label
        CType(Me.dtgStock, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(386, 391)
        '
        'btnSave
        '
        Me.btnSave.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(330, 391)
        '
        'dtgStock
        '
        Me.dtgStock.AllowUserToAddRows = False
        Me.dtgStock.AllowUserToDeleteRows = False
        Me.dtgStock.AllowUserToResizeRows = False
        Me.dtgStock.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgStock.ColumnHeadersHeight = 20
        Me.dtgStock.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.stock_code, Me.Last_Suspend_Date})
        Me.dtgStock.GridColor = System.Drawing.Color.Linen
        Me.dtgStock.Location = New System.Drawing.Point(41, 66)
        Me.dtgStock.MultiSelect = False
        Me.dtgStock.Name = "dtgStock"
        Me.dtgStock.ReadOnly = True
        Me.dtgStock.RowHeadersVisible = False
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtgStock.RowsDefaultCellStyle = DataGridViewCellStyle1
        Me.dtgStock.RowTemplate.Height = 24
        Me.dtgStock.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgStock.Size = New System.Drawing.Size(395, 245)
        Me.dtgStock.TabIndex = 6
        '
        'stock_code
        '
        Me.stock_code.DataPropertyName = "Stock_Code"
        Me.stock_code.HeaderText = "Stock Code"
        Me.stock_code.Name = "stock_code"
        Me.stock_code.ReadOnly = True
        '
        'Last_Suspend_Date
        '
        Me.Last_Suspend_Date.DataPropertyName = "Last_Suspend_Date"
        Me.Last_Suspend_Date.HeaderText = "Last Susp. Date"
        Me.Last_Suspend_Date.Name = "Last_Suspend_Date"
        Me.Last_Suspend_Date.ReadOnly = True
        Me.Last_Suspend_Date.Width = 120
        '
        'rbAll
        '
        Me.rbAll.AutoSize = True
        Me.rbAll.Checked = True
        Me.rbAll.Location = New System.Drawing.Point(45, 325)
        Me.rbAll.Name = "rbAll"
        Me.rbAll.Size = New System.Drawing.Size(38, 19)
        Me.rbAll.TabIndex = 7
        Me.rbAll.TabStop = True
        Me.rbAll.Text = "All"
        Me.rbAll.UseVisualStyleBackColor = True
        '
        'rbDate
        '
        Me.rbDate.AutoSize = True
        Me.rbDate.Location = New System.Drawing.Point(45, 350)
        Me.rbDate.Name = "rbDate"
        Me.rbDate.Size = New System.Drawing.Size(153, 19)
        Me.rbDate.TabIndex = 8
        Me.rbDate.TabStop = True
        Me.rbDate.Text = "Suspension Date From"
        Me.rbDate.UseVisualStyleBackColor = True
        '
        'dpFrom
        '
        Me.dpFrom.CustomFormat = "dd MMM yyyy"
        Me.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpFrom.Location = New System.Drawing.Point(204, 349)
        Me.dpFrom.Name = "dpFrom"
        Me.dpFrom.Size = New System.Drawing.Size(100, 21)
        Me.dpFrom.TabIndex = 9
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(274, 391)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(50, 55)
        Me.btnSearch.TabIndex = 10
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dpTo
        '
        Me.dpTo.CustomFormat = "dd MMM yyyy"
        Me.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpTo.Location = New System.Drawing.Point(337, 349)
        Me.dpTo.Name = "dpTo"
        Me.dpTo.Size = New System.Drawing.Size(99, 21)
        Me.dpTo.TabIndex = 11
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(310, 352)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(21, 15)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "To"
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(330, 391)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 13
        Me.btnExport.Text = "Export"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(139, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(209, 22)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "G2BS Suspend Stock"
        '
        'FrmSuspendStock
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(477, 479)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dpTo)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.dpFrom)
        Me.Controls.Add(Me.rbDate)
        Me.Controls.Add(Me.rbAll)
        Me.Controls.Add(Me.dtgStock)
        Me.KeyPreview = True
        Me.Name = "FrmSuspendStock"
        Me.Text = "G2BS Suspend Stock"
        Me.Controls.SetChildIndex(Me.dtgStock, 0)
        Me.Controls.SetChildIndex(Me.rbAll, 0)
        Me.Controls.SetChildIndex(Me.rbDate, 0)
        Me.Controls.SetChildIndex(Me.dpFrom, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.dpTo, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.Label11, 0)
        CType(Me.dtgStock, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgStock As System.Windows.Forms.DataGridView
    Friend WithEvents rbAll As ESL.myRadioButton
    Friend WithEvents rbDate As ESL.myRadioButton
    Friend WithEvents dpFrom As ESL.myDateTimePicker
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents dpTo As ESL.myDateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents stock_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Last_Suspend_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label

End Class
