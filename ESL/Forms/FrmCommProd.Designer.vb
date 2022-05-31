<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommProd
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
        Me.comboSrcMonth = New ESL.myComboBox(Me.components)
        Me.Label10 = New System.Windows.Forms.Label
        Me.comboSrcYr = New ESL.myComboBox(Me.components)
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.lblTitle = New System.Windows.Forms.Label
        Me.dgdPGroup = New System.Windows.Forms.DataGridView
        Me.product_group = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgdPCode = New System.Windows.Forms.DataGridView
        Me.PCCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCGroup = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.PCpgid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtMonth = New ESL.myTextbox
        Me.lblName = New System.Windows.Forms.Label
        Me.cboPCode = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboPGroup = New ESL.myComboBox(Me.components)
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.txtBPGroup = New ESL.myTextbox
        Me.CBAll = New ESL.myCheckBox(Me.components)
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtBMonth = New ESL.myTextbox
        Me.cboBPgroup = New ESL.myComboBox(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgdBPCode = New System.Windows.Forms.DataGridView
        Me.BPCode = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.BPCName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.market = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.product_flag = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtSrcProd = New ESL.myTextbox
        CType(Me.dgdPGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgdPCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgdBPCode, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(541, 498)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(485, 498)
        '
        'comboSrcMonth
        '
        Me.comboSrcMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrcMonth.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboSrcMonth.FormattingEnabled = True
        Me.comboSrcMonth.Location = New System.Drawing.Point(174, 14)
        Me.comboSrcMonth.Name = "comboSrcMonth"
        Me.comboSrcMonth.Size = New System.Drawing.Size(67, 22)
        Me.comboSrcMonth.TabIndex = 298
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label10.Location = New System.Drawing.Point(247, 17)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(77, 14)
        Me.Label10.TabIndex = 303
        Me.Label10.Text = "Product Group"
        '
        'comboSrcYr
        '
        Me.comboSrcYr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.comboSrcYr.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.comboSrcYr.FormattingEnabled = True
        Me.comboSrcYr.Location = New System.Drawing.Point(55, 14)
        Me.comboSrcYr.Name = "comboSrcYr"
        Me.comboSrcYr.Size = New System.Drawing.Size(71, 22)
        Me.comboSrcYr.TabIndex = 297
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(7, 17)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 14)
        Me.Label19.TabIndex = 302
        Me.Label19.Text = "Year"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(132, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 14)
        Me.Label6.TabIndex = 301
        Me.Label6.Text = "Month"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(471, 11)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(87, 24)
        Me.btnSearch.TabIndex = 300
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold)
        Me.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.lblTitle.Location = New System.Drawing.Point(98, 2)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(380, 22)
        Me.lblTitle.TabIndex = 304
        Me.lblTitle.Text = "Product Group For Futures and Options"
        '
        'dgdPGroup
        '
        Me.dgdPGroup.AllowUserToAddRows = False
        Me.dgdPGroup.AllowUserToDeleteRows = False
        Me.dgdPGroup.AllowUserToResizeColumns = False
        Me.dgdPGroup.AllowUserToResizeRows = False
        Me.dgdPGroup.BackgroundColor = System.Drawing.Color.Linen
        Me.dgdPGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPGroup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.product_group})
        Me.dgdPGroup.Location = New System.Drawing.Point(6, 6)
        Me.dgdPGroup.MultiSelect = False
        Me.dgdPGroup.Name = "dgdPGroup"
        Me.dgdPGroup.RowHeadersVisible = False
        Me.dgdPGroup.RowTemplate.Height = 24
        Me.dgdPGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdPGroup.Size = New System.Drawing.Size(235, 294)
        Me.dgdPGroup.TabIndex = 305
        '
        'product_group
        '
        Me.product_group.DataPropertyName = "product_group"
        Me.product_group.HeaderText = "Product Group"
        Me.product_group.Name = "product_group"
        Me.product_group.Width = 200
        '
        'dgdPCode
        '
        Me.dgdPCode.AllowUserToAddRows = False
        Me.dgdPCode.AllowUserToDeleteRows = False
        Me.dgdPCode.AllowUserToResizeColumns = False
        Me.dgdPCode.AllowUserToResizeRows = False
        Me.dgdPCode.BackgroundColor = System.Drawing.Color.Linen
        Me.dgdPCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdPCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.PCCode, Me.PCName, Me.PCGroup, Me.PCmonth, Me.PCpgid})
        Me.dgdPCode.Location = New System.Drawing.Point(247, 6)
        Me.dgdPCode.MultiSelect = False
        Me.dgdPCode.Name = "dgdPCode"
        Me.dgdPCode.RowHeadersVisible = False
        Me.dgdPCode.RowTemplate.Height = 24
        Me.dgdPCode.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgdPCode.Size = New System.Drawing.Size(318, 294)
        Me.dgdPCode.TabIndex = 306
        '
        'PCCode
        '
        Me.PCCode.DataPropertyName = "product_code"
        Me.PCCode.HeaderText = "Code"
        Me.PCCode.Name = "PCCode"
        '
        'PCName
        '
        Me.PCName.DataPropertyName = "product_name"
        Me.PCName.HeaderText = "Name"
        Me.PCName.Name = "PCName"
        Me.PCName.Width = 150
        '
        'PCGroup
        '
        Me.PCGroup.DataPropertyName = "product_group"
        Me.PCGroup.HeaderText = "product group"
        Me.PCGroup.Name = "PCGroup"
        Me.PCGroup.Visible = False
        '
        'PCmonth
        '
        Me.PCmonth.DataPropertyName = "txmonth"
        Me.PCmonth.HeaderText = "month"
        Me.PCmonth.Name = "PCmonth"
        Me.PCmonth.Visible = False
        '
        'PCpgid
        '
        Me.PCpgid.DataPropertyName = "pgid"
        Me.PCpgid.HeaderText = "id"
        Me.PCpgid.Name = "PCpgid"
        Me.PCpgid.Visible = False
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(12, 75)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(579, 420)
        Me.TabControl1.TabIndex = 307
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Linen
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtMonth)
        Me.TabPage1.Controls.Add(Me.lblName)
        Me.TabPage1.Controls.Add(Me.cboPCode)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.cboPGroup)
        Me.TabPage1.Controls.Add(Me.dgdPGroup)
        Me.TabPage1.Controls.Add(Me.dgdPCode)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(571, 392)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Product Group"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label4.Location = New System.Drawing.Point(16, 310)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 311
        Me.Label4.Text = "Month"
        '
        'txtMonth
        '
        Me.txtMonth.Location = New System.Drawing.Point(99, 306)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(138, 21)
        Me.txtMonth.TabIndex = 310
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.lblName.Location = New System.Drawing.Point(247, 367)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(74, 14)
        Me.lblName.TabIndex = 309
        Me.lblName.Text = "Product Name"
        '
        'cboPCode
        '
        Me.cboPCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPCode.FormattingEnabled = True
        Me.cboPCode.Location = New System.Drawing.Point(99, 363)
        Me.cboPCode.MaxLength = 10
        Me.cboPCode.Name = "cboPCode"
        Me.cboPCode.Size = New System.Drawing.Size(138, 23)
        Me.cboPCode.TabIndex = 308
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label2.Location = New System.Drawing.Point(16, 367)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 14)
        Me.Label2.TabIndex = 307
        Me.Label2.Text = "Product Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(16, 334)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(77, 14)
        Me.Label1.TabIndex = 304
        Me.Label1.Text = "Product Group"
        '
        'cboPGroup
        '
        Me.cboPGroup.FormattingEnabled = True
        Me.cboPGroup.Location = New System.Drawing.Point(99, 334)
        Me.cboPGroup.MaxLength = 10
        Me.cboPGroup.Name = "cboPGroup"
        Me.cboPGroup.Size = New System.Drawing.Size(138, 23)
        Me.cboPGroup.TabIndex = 304
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Linen
        Me.TabPage2.Controls.Add(Me.txtBPGroup)
        Me.TabPage2.Controls.Add(Me.CBAll)
        Me.TabPage2.Controls.Add(Me.Label5)
        Me.TabPage2.Controls.Add(Me.txtBMonth)
        Me.TabPage2.Controls.Add(Me.cboBPgroup)
        Me.TabPage2.Controls.Add(Me.Label3)
        Me.TabPage2.Controls.Add(Me.dgdBPCode)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(571, 392)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Batch Update"
        '
        'txtBPGroup
        '
        Me.txtBPGroup.Location = New System.Drawing.Point(103, 9)
        Me.txtBPGroup.Name = "txtBPGroup"
        Me.txtBPGroup.Size = New System.Drawing.Size(164, 21)
        Me.txtBPGroup.TabIndex = 312
        '
        'CBAll
        '
        Me.CBAll.AutoSize = True
        Me.CBAll.Location = New System.Drawing.Point(501, 11)
        Me.CBAll.Name = "CBAll"
        Me.CBAll.Size = New System.Drawing.Size(39, 19)
        Me.CBAll.TabIndex = 311
        Me.CBAll.Text = "All"
        Me.CBAll.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label5.Location = New System.Drawing.Point(278, 13)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 14)
        Me.Label5.TabIndex = 310
        Me.Label5.Text = "Month"
        '
        'txtBMonth
        '
        Me.txtBMonth.Location = New System.Drawing.Point(322, 9)
        Me.txtBMonth.Name = "txtBMonth"
        Me.txtBMonth.Size = New System.Drawing.Size(120, 21)
        Me.txtBMonth.TabIndex = 309
        '
        'cboBPgroup
        '
        Me.cboBPgroup.FormattingEnabled = True
        Me.cboBPgroup.Location = New System.Drawing.Point(103, 9)
        Me.cboBPgroup.Name = "cboBPgroup"
        Me.cboBPgroup.Size = New System.Drawing.Size(165, 23)
        Me.cboBPgroup.TabIndex = 304
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!)
        Me.Label3.Location = New System.Drawing.Point(23, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 14)
        Me.Label3.TabIndex = 308
        Me.Label3.Text = "Product Group"
        '
        'dgdBPCode
        '
        Me.dgdBPCode.AllowUserToAddRows = False
        Me.dgdBPCode.AllowUserToDeleteRows = False
        Me.dgdBPCode.AllowUserToResizeColumns = False
        Me.dgdBPCode.AllowUserToResizeRows = False
        Me.dgdBPCode.BackgroundColor = System.Drawing.Color.Linen
        Me.dgdBPCode.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgdBPCode.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.BPCode, Me.BPCName, Me.market, Me.product_flag})
        Me.dgdBPCode.Location = New System.Drawing.Point(6, 40)
        Me.dgdBPCode.Name = "dgdBPCode"
        Me.dgdBPCode.RowHeadersVisible = False
        Me.dgdBPCode.RowTemplate.Height = 24
        Me.dgdBPCode.Size = New System.Drawing.Size(559, 331)
        Me.dgdBPCode.TabIndex = 307
        '
        'BPCode
        '
        Me.BPCode.DataPropertyName = "product_code"
        Me.BPCode.HeaderText = "Code"
        Me.BPCode.Name = "BPCode"
        Me.BPCode.ReadOnly = True
        Me.BPCode.Width = 80
        '
        'BPCName
        '
        Me.BPCName.DataPropertyName = "product_name"
        Me.BPCName.HeaderText = "Name"
        Me.BPCName.Name = "BPCName"
        Me.BPCName.ReadOnly = True
        Me.BPCName.Width = 200
        '
        'market
        '
        Me.market.DataPropertyName = "market"
        Me.market.HeaderText = "Market"
        Me.market.Name = "market"
        Me.market.ReadOnly = True
        Me.market.Width = 200
        '
        'product_flag
        '
        Me.product_flag.DataPropertyName = "product_flag"
        Me.product_flag.HeaderText = ""
        Me.product_flag.Name = "product_flag"
        Me.product_flag.Width = 50
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(429, 498)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 310
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(377, 498)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 309
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Location = New System.Drawing.Point(324, 498)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 308
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSrcProd)
        Me.GroupBox1.Controls.Add(Me.comboSrcMonth)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.comboSrcYr)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 25)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(564, 44)
        Me.GroupBox1.TabIndex = 311
        Me.GroupBox1.TabStop = False
        '
        'txtSrcProd
        '
        Me.txtSrcProd.Location = New System.Drawing.Point(326, 13)
        Me.txtSrcProd.Name = "txtSrcProd"
        Me.txtSrcProd.Size = New System.Drawing.Size(139, 21)
        Me.txtSrcProd.TabIndex = 304
        '
        'FrmCommProd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(596, 562)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.lblTitle)
        Me.KeyPreview = True
        Me.Name = "FrmCommProd"
        Me.Text = "Product Group for Futures and Options"
        Me.Controls.SetChildIndex(Me.lblTitle, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        CType(Me.dgdPGroup, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgdPCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgdBPCode, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents comboSrcMonth As ESL.myComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents comboSrcYr As ESL.myComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents lblTitle As System.Windows.Forms.Label
    Friend WithEvents dgdPGroup As System.Windows.Forms.DataGridView
    Friend WithEvents dgdPCode As System.Windows.Forms.DataGridView
    Friend WithEvents product_group As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents lblName As System.Windows.Forms.Label
    Friend WithEvents cboPCode As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboPGroup As ESL.myComboBox
    Friend WithEvents dgdBPCode As System.Windows.Forms.DataGridView
    Friend WithEvents cboBPgroup As ESL.myComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents PCCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCGroup As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PCpgid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents txtSrcProd As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtBMonth As ESL.myTextbox
    Friend WithEvents BPCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BPCName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents market As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents product_flag As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CBAll As ESL.myCheckBox
    Friend WithEvents txtBPGroup As ESL.myTextbox

End Class
