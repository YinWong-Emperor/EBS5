<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHSIMaintance
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
        Me.dgvHSI = New System.Windows.Forms.DataGridView
        Me.HSI_StockCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.HSI_Stock_desc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupddate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupduser = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSrchName = New ESL.myTextbox
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSrchStockCode = New ESL.myTextbox
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtName = New ESL.myTextbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtStockCode = New ESL.myTextbox
        CType(Me.dgvHSI, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(433, 418)
        Me.btnCancel.TabIndex = 11
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(381, 418)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Visible = True
        '
        'dgvHSI
        '
        Me.dgvHSI.AllowUserToAddRows = False
        Me.dgvHSI.AllowUserToDeleteRows = False
        Me.dgvHSI.AllowUserToResizeRows = False
        Me.dgvHSI.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvHSI.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvHSI.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.HSI_StockCode, Me.HSI_Stock_desc, Me.lstupddate, Me.lstupduser})
        Me.dgvHSI.Location = New System.Drawing.Point(6, 39)
        Me.dgvHSI.MultiSelect = False
        Me.dgvHSI.Name = "dgvHSI"
        Me.dgvHSI.ReadOnly = True
        Me.dgvHSI.RowHeadersVisible = False
        Me.dgvHSI.RowTemplate.Height = 24
        Me.dgvHSI.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvHSI.Size = New System.Drawing.Size(479, 311)
        Me.dgvHSI.TabIndex = 4
        '
        'HSI_StockCode
        '
        Me.HSI_StockCode.DataPropertyName = "HSI_StockCode"
        Me.HSI_StockCode.HeaderText = "Stock Code"
        Me.HSI_StockCode.Name = "HSI_StockCode"
        Me.HSI_StockCode.ReadOnly = True
        '
        'HSI_Stock_desc
        '
        Me.HSI_Stock_desc.DataPropertyName = "HSI_Stock_desc"
        Me.HSI_Stock_desc.HeaderText = "Name"
        Me.HSI_Stock_desc.Name = "HSI_Stock_desc"
        Me.HSI_Stock_desc.ReadOnly = True
        '
        'lstupddate
        '
        Me.lstupddate.DataPropertyName = "lstupddate"
        Me.lstupddate.HeaderText = "Last update date"
        Me.lstupddate.Name = "lstupddate"
        Me.lstupddate.ReadOnly = True
        '
        'lstupduser
        '
        Me.lstupduser.DataPropertyName = "lstupduser"
        Me.lstupduser.HeaderText = "Last update user"
        Me.lstupduser.Name = "lstupduser"
        Me.lstupduser.ReadOnly = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(269, 419)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 8
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(213, 419)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 7
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(325, 418)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(12, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(62, 14)
        Me.Label6.TabIndex = 172
        Me.Label6.Text = "Stock Code"
        '
        'txtSrchName
        '
        Me.txtSrchName.Location = New System.Drawing.Point(229, 12)
        Me.txtSrchName.Name = "txtSrchName"
        Me.txtSrchName.Size = New System.Drawing.Size(156, 21)
        Me.txtSrchName.TabIndex = 2
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(189, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(34, 14)
        Me.Label18.TabIndex = 171
        Me.Label18.Text = "Name"
        '
        'txtSrchStockCode
        '
        Me.txtSrchStockCode.Location = New System.Drawing.Point(80, 12)
        Me.txtSrchStockCode.Name = "txtSrchStockCode"
        Me.txtSrchStockCode.Size = New System.Drawing.Size(100, 21)
        Me.txtSrchStockCode.TabIndex = 1
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(402, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(83, 23)
        Me.btnSearch.TabIndex = 3
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 364)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 14)
        Me.Label1.TabIndex = 176
        Me.Label1.Text = "Stock Code"
        '
        'txtName
        '
        Me.txtName.Location = New System.Drawing.Point(80, 391)
        Me.txtName.MaxLength = 100
        Me.txtName.Name = "txtName"
        Me.txtName.Size = New System.Drawing.Size(405, 21)
        Me.txtName.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(12, 391)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(34, 14)
        Me.Label2.TabIndex = 175
        Me.Label2.Text = "Name"
        '
        'txtStockCode
        '
        Me.txtStockCode.Location = New System.Drawing.Point(80, 361)
        Me.txtStockCode.MaxLength = 50
        Me.txtStockCode.Name = "txtStockCode"
        Me.txtStockCode.Size = New System.Drawing.Size(100, 21)
        Me.txtStockCode.TabIndex = 5
        '
        'frmHSIMaintance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(491, 480)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtName)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtStockCode)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSrchName)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtSrchStockCode)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.dgvHSI)
        Me.KeyPreview = True
        Me.Name = "frmHSIMaintance"
        Me.Text = "HSI Maintance"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.dgvHSI, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.txtSrchStockCode, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.txtSrchName, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        Me.Controls.SetChildIndex(Me.txtStockCode, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.txtName, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        CType(Me.dgvHSI, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dgvHSI As System.Windows.Forms.DataGridView
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSrchName As ESL.myTextbox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSrchStockCode As ESL.myTextbox
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtName As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtStockCode As ESL.myTextbox
    Friend WithEvents HSI_StockCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HSI_Stock_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupduser As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
