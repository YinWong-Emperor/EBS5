<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmFutureProductMaster
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmFutureProductMaster))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSEProductCode = New ESL.myTextbox()
        Me.cmbSECounterParty = New ESL.myComboBox(Me.components)
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cmbSEProductType = New ESL.myComboBox(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.txtSEProductName = New ESL.myTextbox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.nudEStrikeDecPla = New System.Windows.Forms.NumericUpDown()
        Me.nudEPriceDecPla = New System.Windows.Forms.NumericUpDown()
        Me.nudEContractSize = New System.Windows.Forms.NumericUpDown()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtEProductCode = New ESL.myTextbox()
        Me.txtEProductName = New ESL.myTextbox()
        Me.chkEIsOption = New ESL.myCheckBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbECounterParty = New ESL.myComboBox(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvFutureProdcuts = New System.Windows.Forms.DataGridView()
        Me.ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CounterParty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ProductName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsOptionDisplay = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PriceDecPla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ContractSize = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StrikeDecPla = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IsOption = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.nudEStrikeDecPla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudEPriceDecPla, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudEContractSize, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvFutureProdcuts, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(813, 541)
        Me.btnCancel.TabIndex = 18
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(761, 541)
        Me.btnSave.TabIndex = 17
        Me.btnSave.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.txtSEProductCode)
        Me.GroupBox1.Controls.Add(Me.cmbSECounterParty)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.cmbSEProductType)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSEProductName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(7, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(856, 77)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(19, 18)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(81, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Counter Party"
        '
        'txtSEProductCode
        '
        Me.txtSEProductCode.Location = New System.Drawing.Point(106, 43)
        Me.txtSEProductCode.MaxLength = 10
        Me.txtSEProductCode.Name = "txtSEProductCode"
        Me.txtSEProductCode.Size = New System.Drawing.Size(284, 21)
        Me.txtSEProductCode.TabIndex = 3
        '
        'cmbSECounterParty
        '
        Me.cmbSECounterParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSECounterParty.FormattingEnabled = True
        Me.cmbSECounterParty.Location = New System.Drawing.Point(106, 15)
        Me.cmbSECounterParty.Name = "cmbSECounterParty"
        Me.cmbSECounterParty.Size = New System.Drawing.Size(284, 23)
        Me.cmbSECounterParty.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(429, 17)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Product Type"
        '
        'cmbSEProductType
        '
        Me.cmbSEProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSEProductType.FormattingEnabled = True
        Me.cmbSEProductType.Location = New System.Drawing.Point(521, 14)
        Me.cmbSEProductType.Name = "cmbSEProductType"
        Me.cmbSEProductType.Size = New System.Drawing.Size(224, 23)
        Me.cmbSEProductType.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(767, 14)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Enquiry"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSEProductName
        '
        Me.txtSEProductName.Location = New System.Drawing.Point(521, 43)
        Me.txtSEProductName.MaxLength = 60
        Me.txtSEProductName.Name = "txtSEProductName"
        Me.txtSEProductName.Size = New System.Drawing.Size(321, 21)
        Me.txtSEProductName.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(428, 46)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Product Name"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Product Code"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(710, 541)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 16
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(608, 541)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 14
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(659, 541)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 15
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.nudEStrikeDecPla)
        Me.GroupBox2.Controls.Add(Me.nudEPriceDecPla)
        Me.GroupBox2.Controls.Add(Me.nudEContractSize)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtEProductCode)
        Me.GroupBox2.Controls.Add(Me.txtEProductName)
        Me.GroupBox2.Controls.Add(Me.chkEIsOption)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbECounterParty)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 408)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(856, 126)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details"
        '
        'nudEStrikeDecPla
        '
        Me.nudEStrikeDecPla.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.nudEStrikeDecPla.Location = New System.Drawing.Point(136, 99)
        Me.nudEStrikeDecPla.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.nudEStrikeDecPla.Name = "nudEStrikeDecPla"
        Me.nudEStrikeDecPla.Size = New System.Drawing.Size(285, 21)
        Me.nudEStrikeDecPla.TabIndex = 13
        Me.nudEStrikeDecPla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudEPriceDecPla
        '
        Me.nudEPriceDecPla.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.nudEPriceDecPla.Location = New System.Drawing.Point(136, 72)
        Me.nudEPriceDecPla.Maximum = New Decimal(New Integer() {9, 0, 0, 0})
        Me.nudEPriceDecPla.Name = "nudEPriceDecPla"
        Me.nudEPriceDecPla.Size = New System.Drawing.Size(285, 21)
        Me.nudEPriceDecPla.TabIndex = 11
        Me.nudEPriceDecPla.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'nudEContractSize
        '
        Me.nudEContractSize.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.nudEContractSize.Location = New System.Drawing.Point(541, 72)
        Me.nudEContractSize.Maximum = New Decimal(New Integer() {2147483647, 0, 0, 0})
        Me.nudEContractSize.Name = "nudEContractSize"
        Me.nudEContractSize.Size = New System.Drawing.Size(301, 21)
        Me.nudEContractSize.TabIndex = 12
        Me.nudEContractSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudEContractSize.ThousandsSeparator = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Counter Party"
        '
        'txtEProductCode
        '
        Me.txtEProductCode.Location = New System.Drawing.Point(136, 45)
        Me.txtEProductCode.MaxLength = 10
        Me.txtEProductCode.Name = "txtEProductCode"
        Me.txtEProductCode.Size = New System.Drawing.Size(284, 21)
        Me.txtEProductCode.TabIndex = 9
        '
        'txtEProductName
        '
        Me.txtEProductName.Location = New System.Drawing.Point(541, 46)
        Me.txtEProductName.MaxLength = 60
        Me.txtEProductName.Name = "txtEProductName"
        Me.txtEProductName.Size = New System.Drawing.Size(301, 21)
        Me.txtEProductName.TabIndex = 10
        '
        'chkEIsOption
        '
        Me.chkEIsOption.AutoSize = True
        Me.chkEIsOption.Location = New System.Drawing.Point(541, 18)
        Me.chkEIsOption.Name = "chkEIsOption"
        Me.chkEIsOption.Size = New System.Drawing.Size(82, 19)
        Me.chkEIsOption.TabIndex = 8
        Me.chkEIsOption.Text = "Is Options"
        Me.chkEIsOption.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(449, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Product Name"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 75)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(125, 15)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Price Decimal Places"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 102)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 15)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Strike Decimal Places"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(449, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Contract Size"
        '
        'cmbECounterParty
        '
        Me.cmbECounterParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbECounterParty.Location = New System.Drawing.Point(136, 16)
        Me.cmbECounterParty.Name = "cmbECounterParty"
        Me.cmbECounterParty.Size = New System.Drawing.Size(284, 23)
        Me.cmbECounterParty.TabIndex = 7
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(82, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "Product Code"
        '
        'dgvFutureProdcuts
        '
        Me.dgvFutureProdcuts.AllowUserToAddRows = False
        Me.dgvFutureProdcuts.AllowUserToDeleteRows = False
        Me.dgvFutureProdcuts.AllowUserToResizeRows = False
        Me.dgvFutureProdcuts.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvFutureProdcuts.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvFutureProdcuts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFutureProdcuts.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ID, Me.CounterParty, Me.ProductCode, Me.ProductName, Me.IsOptionDisplay, Me.PriceDecPla, Me.ContractSize, Me.StrikeDecPla, Me.IsOption})
        Me.dgvFutureProdcuts.Location = New System.Drawing.Point(7, 85)
        Me.dgvFutureProdcuts.MultiSelect = False
        Me.dgvFutureProdcuts.Name = "dgvFutureProdcuts"
        Me.dgvFutureProdcuts.ReadOnly = True
        Me.dgvFutureProdcuts.RowHeadersVisible = False
        Me.dgvFutureProdcuts.RowTemplate.Height = 24
        Me.dgvFutureProdcuts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFutureProdcuts.Size = New System.Drawing.Size(856, 314)
        Me.dgvFutureProdcuts.TabIndex = 6
        '
        'ID
        '
        Me.ID.DataPropertyName = "id"
        Me.ID.HeaderText = "ID"
        Me.ID.Name = "ID"
        Me.ID.ReadOnly = True
        Me.ID.Visible = False
        '
        'CounterParty
        '
        Me.CounterParty.DataPropertyName = "counter_party"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        Me.CounterParty.DefaultCellStyle = DataGridViewCellStyle1
        Me.CounterParty.HeaderText = "Counter Party"
        Me.CounterParty.Name = "CounterParty"
        Me.CounterParty.ReadOnly = True
        Me.CounterParty.Width = 110
        '
        'ProductCode
        '
        Me.ProductCode.DataPropertyName = "Product_Code"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        Me.ProductCode.DefaultCellStyle = DataGridViewCellStyle2
        Me.ProductCode.HeaderText = "Product Code"
        Me.ProductCode.Name = "ProductCode"
        Me.ProductCode.ReadOnly = True
        Me.ProductCode.Width = 110
        '
        'ProductName
        '
        Me.ProductName.DataPropertyName = "Product_Name"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        Me.ProductName.DefaultCellStyle = DataGridViewCellStyle3
        Me.ProductName.HeaderText = "Product Name"
        Me.ProductName.Name = "ProductName"
        Me.ProductName.ReadOnly = True
        Me.ProductName.Width = 110
        '
        'IsOptionDisplay
        '
        Me.IsOptionDisplay.DataPropertyName = "Is_Option_Display"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        Me.IsOptionDisplay.DefaultCellStyle = DataGridViewCellStyle4
        Me.IsOptionDisplay.HeaderText = "Is Options"
        Me.IsOptionDisplay.Name = "IsOptionDisplay"
        Me.IsOptionDisplay.ReadOnly = True
        Me.IsOptionDisplay.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsOptionDisplay.Width = 88
        '
        'PriceDecPla
        '
        Me.PriceDecPla.DataPropertyName = "Price_Dec_Pla"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle5.Format = "#0.##########"
        Me.PriceDecPla.DefaultCellStyle = DataGridViewCellStyle5
        Me.PriceDecPla.HeaderText = "Price Decimal Places"
        Me.PriceDecPla.Name = "PriceDecPla"
        Me.PriceDecPla.ReadOnly = True
        Me.PriceDecPla.Width = 150
        '
        'ContractSize
        '
        Me.ContractSize.DataPropertyName = "Contract_Size"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle6.Format = "N0"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.ContractSize.DefaultCellStyle = DataGridViewCellStyle6
        Me.ContractSize.HeaderText = "Contract Size"
        Me.ContractSize.Name = "ContractSize"
        Me.ContractSize.ReadOnly = True
        Me.ContractSize.Width = 110
        '
        'StrikeDecPla
        '
        Me.StrikeDecPla.DataPropertyName = "Strike_Dec_Pla"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle7.Format = "#0.##########"
        Me.StrikeDecPla.DefaultCellStyle = DataGridViewCellStyle7
        Me.StrikeDecPla.HeaderText = "Strike Decimal Places"
        Me.StrikeDecPla.Name = "StrikeDecPla"
        Me.StrikeDecPla.ReadOnly = True
        Me.StrikeDecPla.Width = 155
        '
        'IsOption
        '
        Me.IsOption.DataPropertyName = "Is_Option"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle8.NullValue = False
        Me.IsOption.DefaultCellStyle = DataGridViewCellStyle8
        Me.IsOption.HeaderText = "Is Option"
        Me.IsOption.Name = "IsOption"
        Me.IsOption.ReadOnly = True
        Me.IsOption.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.IsOption.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.IsOption.Visible = False
        Me.IsOption.Width = 80
        '
        'frmFutureProductMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(869, 602)
        Me.Controls.Add(Me.dgvFutureProdcuts)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmFutureProductMaster"
        Me.Text = "Futures Product Master"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.dgvFutureProdcuts, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.nudEStrikeDecPla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudEPriceDecPla, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudEContractSize, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvFutureProdcuts, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents txtSEProductName As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbECounterParty As ESL.myComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvFutureProdcuts As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents chkEIsOption As ESL.myCheckBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbSEProductType As ESL.myComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSEProductCode As ESL.myTextbox
    Friend WithEvents cmbSECounterParty As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtEProductCode As ESL.myTextbox
    Friend WithEvents txtEProductName As ESL.myTextbox
    Friend WithEvents nudEContractSize As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudEStrikeDecPla As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudEPriceDecPla As System.Windows.Forms.NumericUpDown
    Friend WithEvents ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CounterParty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ProductName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsOptionDisplay As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PriceDecPla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ContractSize As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StrikeDecPla As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IsOption As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
