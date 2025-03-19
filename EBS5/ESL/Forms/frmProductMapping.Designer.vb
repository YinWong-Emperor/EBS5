<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmProductMapping
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmProductMapping))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cbxSECounterParty = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.txtSNName = New ESL.myTextbox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSEName = New ESL.myTextbox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cmbSECode = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.chkIsOption = New ESL.myCheckBox(Me.components)
        Me.cbxCounterParty = New System.Windows.Forms.ComboBox()
        Me.cmbNName = New ESL.myComboBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtEName = New ESL.myTextbox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cmbECode = New ESL.myComboBox(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dgvMapping = New System.Windows.Forms.DataGridView()
        Me.d_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_desc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CounterParty = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_newedge_code = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.d_isoption = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.dgvMapping, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(606, 520)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(554, 520)
        Me.btnSave.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbxSECounterParty)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.txtSNName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtSEName)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.cmbSECode)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(2, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(654, 100)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'cbxSECounterParty
        '
        Me.cbxSECounterParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSECounterParty.FormattingEnabled = True
        Me.cbxSECounterParty.Location = New System.Drawing.Point(133, 70)
        Me.cbxSECounterParty.Name = "cbxSECounterParty"
        Me.cbxSECounterParty.Size = New System.Drawing.Size(145, 23)
        Me.cbxSECounterParty.TabIndex = 8
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(457, 14)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Inquiry"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtSNName
        '
        Me.txtSNName.Location = New System.Drawing.Point(284, 70)
        Me.txtSNName.Name = "txtSNName"
        Me.txtSNName.Size = New System.Drawing.Size(360, 21)
        Me.txtSNName.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 73)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(86, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Product Name"
        '
        'txtSEName
        '
        Me.txtSEName.Location = New System.Drawing.Point(133, 43)
        Me.txtSEName.Name = "txtSEName"
        Me.txtSEName.Size = New System.Drawing.Size(511, 21)
        Me.txtSEName.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "G2BF Product Name"
        '
        'cmbSECode
        '
        Me.cmbSECode.FormattingEnabled = True
        Me.cmbSECode.Location = New System.Drawing.Point(133, 14)
        Me.cmbSECode.Name = "cmbSECode"
        Me.cmbSECode.Size = New System.Drawing.Size(160, 23)
        Me.cmbSECode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(116, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "G2BF Product Code"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(503, 520)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 9
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(401, 520)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 7
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(452, 520)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 8
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.chkIsOption)
        Me.GroupBox2.Controls.Add(Me.cbxCounterParty)
        Me.GroupBox2.Controls.Add(Me.cmbNName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtEName)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbECode)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Location = New System.Drawing.Point(2, 413)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(654, 100)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details"
        '
        'chkIsOption
        '
        Me.chkIsOption.AutoSize = True
        Me.chkIsOption.Location = New System.Drawing.Point(582, 16)
        Me.chkIsOption.Name = "chkIsOption"
        Me.chkIsOption.Size = New System.Drawing.Size(75, 19)
        Me.chkIsOption.TabIndex = 2
        Me.chkIsOption.Text = "Is Option"
        Me.chkIsOption.UseVisualStyleBackColor = True
        '
        'cbxCounterParty
        '
        Me.cbxCounterParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxCounterParty.FormattingEnabled = True
        Me.cbxCounterParty.Location = New System.Drawing.Point(133, 71)
        Me.cbxCounterParty.Name = "cbxCounterParty"
        Me.cbxCounterParty.Size = New System.Drawing.Size(145, 23)
        Me.cbxCounterParty.TabIndex = 7
        '
        'cmbNName
        '
        Me.cmbNName.FormattingEnabled = True
        Me.cmbNName.Location = New System.Drawing.Point(284, 70)
        Me.cmbNName.Name = "cmbNName"
        Me.cmbNName.Size = New System.Drawing.Size(360, 23)
        Me.cmbNName.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(86, 15)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Product Name"
        '
        'txtEName
        '
        Me.txtEName.Location = New System.Drawing.Point(133, 43)
        Me.txtEName.Name = "txtEName"
        Me.txtEName.Size = New System.Drawing.Size(511, 21)
        Me.txtEName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 46)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(120, 15)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "G2BF Product Name"
        '
        'cmbECode
        '
        Me.cmbECode.FormattingEnabled = True
        Me.cmbECode.Location = New System.Drawing.Point(133, 14)
        Me.cmbECode.Name = "cmbECode"
        Me.cmbECode.Size = New System.Drawing.Size(145, 23)
        Me.cmbECode.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 17)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(116, 15)
        Me.Label6.TabIndex = 0
        Me.Label6.Text = "G2BF Product Code"
        '
        'dgvMapping
        '
        Me.dgvMapping.AllowUserToAddRows = False
        Me.dgvMapping.AllowUserToDeleteRows = False
        Me.dgvMapping.AllowUserToResizeRows = False
        Me.dgvMapping.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvMapping.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMapping.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.d_code, Me.d_desc, Me.CounterParty, Me.d_newedge_code, Me.d_isoption})
        Me.dgvMapping.Location = New System.Drawing.Point(2, 108)
        Me.dgvMapping.MultiSelect = False
        Me.dgvMapping.Name = "dgvMapping"
        Me.dgvMapping.ReadOnly = True
        Me.dgvMapping.RowHeadersVisible = False
        Me.dgvMapping.RowTemplate.Height = 24
        Me.dgvMapping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvMapping.Size = New System.Drawing.Size(654, 299)
        Me.dgvMapping.TabIndex = 11
        '
        'd_code
        '
        Me.d_code.DataPropertyName = "d_code"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        Me.d_code.DefaultCellStyle = DataGridViewCellStyle1
        Me.d_code.HeaderText = "G2BF Code"
        Me.d_code.Name = "d_code"
        Me.d_code.ReadOnly = True
        '
        'd_desc
        '
        Me.d_desc.DataPropertyName = "d_desc"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        Me.d_desc.DefaultCellStyle = DataGridViewCellStyle2
        Me.d_desc.HeaderText = "G2BF Name"
        Me.d_desc.Name = "d_desc"
        Me.d_desc.ReadOnly = True
        Me.d_desc.Width = 210
        '
        'CounterParty
        '
        Me.CounterParty.DataPropertyName = "d_CounterParty"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        Me.CounterParty.DefaultCellStyle = DataGridViewCellStyle3
        Me.CounterParty.HeaderText = "Party"
        Me.CounterParty.Name = "CounterParty"
        Me.CounterParty.ReadOnly = True
        '
        'd_newedge_code
        '
        Me.d_newedge_code.DataPropertyName = "d_newedge_code"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        Me.d_newedge_code.DefaultCellStyle = DataGridViewCellStyle4
        Me.d_newedge_code.HeaderText = "Product Name"
        Me.d_newedge_code.Name = "d_newedge_code"
        Me.d_newedge_code.ReadOnly = True
        Me.d_newedge_code.Width = 210
        '
        'd_isoption
        '
        Me.d_isoption.DataPropertyName = "d_isoption"
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        Me.d_isoption.DefaultCellStyle = DataGridViewCellStyle5
        Me.d_isoption.HeaderText = "Is Option"
        Me.d_isoption.Name = "d_isoption"
        Me.d_isoption.ReadOnly = True
        '
        'frmProductMapping
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(668, 577)
        Me.Controls.Add(Me.dgvMapping)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmProductMapping"
        Me.Text = "Futures Product Mapping"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.dgvMapping, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.dgvMapping, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbSECode As ESL.myComboBox
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents txtSNName As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtSEName As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEName As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbECode As ESL.myComboBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dgvMapping As System.Windows.Forms.DataGridView
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents cmbNName As ESL.myComboBox
    Friend WithEvents cbxSECounterParty As System.Windows.Forms.ComboBox
    Friend WithEvents cbxCounterParty As System.Windows.Forms.ComboBox
    Friend WithEvents chkIsOption As ESL.myCheckBox
    Friend WithEvents d_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_desc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CounterParty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_newedge_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents d_isoption As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
