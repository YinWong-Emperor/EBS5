<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCRSMasterMain
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCRSMasterMain))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmbCRSType = New ESL.myComboBox(Me.components)
        Me.rbFutures = New ESL.myRadioButton(Me.components)
        Me.rbSecurities = New ESL.myRadioButton(Me.components)
        Me.txtAccno = New ESL.myTextbox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.dgvCRSMaster = New System.Windows.Forms.DataGridView()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.dtpRetrunYear = New ESL.myDateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbExportFutures = New ESL.myRadioButton(Me.components)
        Me.rbExportSecurities = New ESL.myRadioButton(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnExport = New ESL.myButton(Me.components)
        Me.Mid = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Accno = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClientName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CrsType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AccHolderType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CPType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ResCountryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TINIssueBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Firstname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LastName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BirthDate = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BirthCountryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BirthCity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddressCountryCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LegalAddressType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AddressFree = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvCRSMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(671, 443)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(849, 485)
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(615, 443)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 19
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(499, 443)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 55)
        Me.btnNew.TabIndex = 17
        Me.btnNew.Text = "New CP"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(564, 443)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 18
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbCRSType)
        Me.GroupBox1.Controls.Add(Me.rbFutures)
        Me.GroupBox1.Controls.Add(Me.rbSecurities)
        Me.GroupBox1.Controls.Add(Me.txtAccno)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(704, 54)
        Me.GroupBox1.TabIndex = 20
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(416, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 15)
        Me.Label1.TabIndex = 66
        Me.Label1.Text = "CRS Type:"
        '
        'cmbCRSType
        '
        Me.cmbCRSType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCRSType.FormattingEnabled = True
        Me.cmbCRSType.Location = New System.Drawing.Point(486, 18)
        Me.cmbCRSType.Name = "cmbCRSType"
        Me.cmbCRSType.Size = New System.Drawing.Size(135, 23)
        Me.cmbCRSType.TabIndex = 65
        '
        'rbFutures
        '
        Me.rbFutures.AutoSize = True
        Me.rbFutures.Location = New System.Drawing.Point(345, 20)
        Me.rbFutures.Name = "rbFutures"
        Me.rbFutures.Size = New System.Drawing.Size(67, 19)
        Me.rbFutures.TabIndex = 64
        Me.rbFutures.Text = "Futures"
        Me.rbFutures.UseVisualStyleBackColor = True
        '
        'rbSecurities
        '
        Me.rbSecurities.AutoSize = True
        Me.rbSecurities.Checked = True
        Me.rbSecurities.Location = New System.Drawing.Point(259, 20)
        Me.rbSecurities.Name = "rbSecurities"
        Me.rbSecurities.Size = New System.Drawing.Size(80, 19)
        Me.rbSecurities.TabIndex = 63
        Me.rbSecurities.TabStop = True
        Me.rbSecurities.Text = "Securities"
        Me.rbSecurities.UseVisualStyleBackColor = True
        '
        'txtAccno
        '
        Me.txtAccno.Location = New System.Drawing.Point(57, 19)
        Me.txtAccno.MaxLength = 8
        Me.txtAccno.Name = "txtAccno"
        Me.txtAccno.Size = New System.Drawing.Size(110, 21)
        Me.txtAccno.TabIndex = 15
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(8, 22)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 15)
        Me.Label10.TabIndex = 14
        Me.Label10.Text = "Accno:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(172, 22)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 15)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Account Type:"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(623, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Enquiry"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvCRSMaster
        '
        Me.dgvCRSMaster.AllowUserToAddRows = False
        Me.dgvCRSMaster.AllowUserToDeleteRows = False
        Me.dgvCRSMaster.AllowUserToResizeRows = False
        Me.dgvCRSMaster.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvCRSMaster.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.dgvCRSMaster.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCRSMaster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Mid, Me.Accno, Me.ClientName, Me.CrsType, Me.AccHolderType, Me.CPType, Me.ResCountryCode, Me.TIN, Me.TINIssueBy, Me.Firstname, Me.LastName, Me.BirthDate, Me.BirthCountryCode, Me.BirthCity, Me.AddressCountryCode, Me.LegalAddressType, Me.AddressFree})
        Me.dgvCRSMaster.Location = New System.Drawing.Point(12, 72)
        Me.dgvCRSMaster.MultiSelect = False
        Me.dgvCRSMaster.Name = "dgvCRSMaster"
        Me.dgvCRSMaster.ReadOnly = True
        Me.dgvCRSMaster.RowHeadersVisible = False
        Me.dgvCRSMaster.RowTemplate.Height = 24
        Me.dgvCRSMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCRSMaster.Size = New System.Drawing.Size(725, 354)
        Me.dgvCRSMaster.TabIndex = 21
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtpRetrunYear)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.rbExportFutures)
        Me.GroupBox2.Controls.Add(Me.rbExportSecurities)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.btnExport)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 432)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(481, 78)
        Me.GroupBox2.TabIndex = 22
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Export CSV Form G2B"
        '
        'dtpRetrunYear
        '
        Me.dtpRetrunYear.CustomFormat = "yyyy"
        Me.dtpRetrunYear.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpRetrunYear.Location = New System.Drawing.Point(332, 28)
        Me.dtpRetrunYear.Name = "dtpRetrunYear"
        Me.dtpRetrunYear.Size = New System.Drawing.Size(86, 21)
        Me.dtpRetrunYear.TabIndex = 69
        Me.dtpRetrunYear.Value = New Date(2018, 1, 1, 0, 0, 0, 0)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(252, 31)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 15)
        Me.Label3.TabIndex = 68
        Me.Label3.Text = "Return Year:"
        '
        'rbExportFutures
        '
        Me.rbExportFutures.AutoSize = True
        Me.rbExportFutures.Location = New System.Drawing.Point(179, 29)
        Me.rbExportFutures.Name = "rbExportFutures"
        Me.rbExportFutures.Size = New System.Drawing.Size(67, 19)
        Me.rbExportFutures.TabIndex = 67
        Me.rbExportFutures.Text = "Futures"
        Me.rbExportFutures.UseVisualStyleBackColor = True
        '
        'rbExportSecurities
        '
        Me.rbExportSecurities.AutoSize = True
        Me.rbExportSecurities.Checked = True
        Me.rbExportSecurities.Location = New System.Drawing.Point(95, 30)
        Me.rbExportSecurities.Name = "rbExportSecurities"
        Me.rbExportSecurities.Size = New System.Drawing.Size(80, 19)
        Me.rbExportSecurities.TabIndex = 66
        Me.rbExportSecurities.TabStop = True
        Me.rbExportSecurities.Text = "Securities"
        Me.rbExportSecurities.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 15)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Account Type:"
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Image = Global.ESL.My.Resources.Resources.export
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnExport.Location = New System.Drawing.Point(424, 11)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(49, 55)
        Me.btnExport.TabIndex = 23
        Me.btnExport.Text = "Export"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Mid
        '
        Me.Mid.DataPropertyName = "Mid"
        Me.Mid.HeaderText = "Mid"
        Me.Mid.Name = "Mid"
        Me.Mid.ReadOnly = True
        Me.Mid.Visible = False
        Me.Mid.Width = 90
        '
        'Accno
        '
        Me.Accno.DataPropertyName = "Accno"
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Linen
        Me.Accno.DefaultCellStyle = DataGridViewCellStyle1
        Me.Accno.HeaderText = "Accno"
        Me.Accno.Name = "Accno"
        Me.Accno.ReadOnly = True
        Me.Accno.Width = 70
        '
        'ClientName
        '
        Me.ClientName.DataPropertyName = "ClientName"
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        Me.ClientName.DefaultCellStyle = DataGridViewCellStyle2
        Me.ClientName.HeaderText = "Client Name"
        Me.ClientName.Name = "ClientName"
        Me.ClientName.ReadOnly = True
        Me.ClientName.Width = 230
        '
        'CrsType
        '
        Me.CrsType.DataPropertyName = "CrsType"
        DataGridViewCellStyle3.BackColor = System.Drawing.Color.Linen
        Me.CrsType.DefaultCellStyle = DataGridViewCellStyle3
        Me.CrsType.HeaderText = "CRS Type"
        Me.CrsType.Name = "CrsType"
        Me.CrsType.ReadOnly = True
        Me.CrsType.Width = 90
        '
        'AccHolderType
        '
        Me.AccHolderType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader
        Me.AccHolderType.DataPropertyName = "AccHolderType"
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        Me.AccHolderType.DefaultCellStyle = DataGridViewCellStyle4
        Me.AccHolderType.HeaderText = "Holder Type"
        Me.AccHolderType.Name = "AccHolderType"
        Me.AccHolderType.ReadOnly = True
        Me.AccHolderType.Visible = False
        Me.AccHolderType.Width = 97
        '
        'CPType
        '
        Me.CPType.DataPropertyName = "CPType"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle5.BackColor = System.Drawing.Color.Linen
        Me.CPType.DefaultCellStyle = DataGridViewCellStyle5
        Me.CPType.HeaderText = "CP Type"
        Me.CPType.Name = "CPType"
        Me.CPType.ReadOnly = True
        Me.CPType.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.CPType.Visible = False
        Me.CPType.Width = 88
        '
        'ResCountryCode
        '
        Me.ResCountryCode.DataPropertyName = "ResCountryCode"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle6.Format = "#0.##########"
        Me.ResCountryCode.DefaultCellStyle = DataGridViewCellStyle6
        Me.ResCountryCode.HeaderText = "ResCountryCode"
        Me.ResCountryCode.Name = "ResCountryCode"
        Me.ResCountryCode.ReadOnly = True
        Me.ResCountryCode.Width = 120
        '
        'TIN
        '
        Me.TIN.DataPropertyName = "TIN"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle7.Format = "N0"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.TIN.DefaultCellStyle = DataGridViewCellStyle7
        Me.TIN.HeaderText = "TIN"
        Me.TIN.Name = "TIN"
        Me.TIN.ReadOnly = True
        Me.TIN.Width = 90
        '
        'TINIssueBy
        '
        Me.TINIssueBy.DataPropertyName = "TINIssueBy"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle8.Format = "#0.##########"
        Me.TINIssueBy.DefaultCellStyle = DataGridViewCellStyle8
        Me.TINIssueBy.HeaderText = "TIN Issue By"
        Me.TINIssueBy.Name = "TINIssueBy"
        Me.TINIssueBy.ReadOnly = True
        '
        'Firstname
        '
        Me.Firstname.DataPropertyName = "Firstname"
        Me.Firstname.HeaderText = "Firstname"
        Me.Firstname.Name = "Firstname"
        Me.Firstname.ReadOnly = True
        Me.Firstname.Visible = False
        '
        'LastName
        '
        Me.LastName.DataPropertyName = "LastName"
        Me.LastName.HeaderText = "LastName"
        Me.LastName.Name = "LastName"
        Me.LastName.ReadOnly = True
        Me.LastName.Visible = False
        '
        'BirthDate
        '
        Me.BirthDate.DataPropertyName = "BirthDate"
        Me.BirthDate.HeaderText = "Birth Date"
        Me.BirthDate.Name = "BirthDate"
        Me.BirthDate.ReadOnly = True
        Me.BirthDate.Visible = False
        '
        'BirthCountryCode
        '
        Me.BirthCountryCode.DataPropertyName = "BirthCountryCode"
        Me.BirthCountryCode.HeaderText = "BirthCountryCode"
        Me.BirthCountryCode.Name = "BirthCountryCode"
        Me.BirthCountryCode.ReadOnly = True
        Me.BirthCountryCode.Visible = False
        '
        'BirthCity
        '
        Me.BirthCity.DataPropertyName = "BirthCity"
        Me.BirthCity.HeaderText = "BirthCity"
        Me.BirthCity.Name = "BirthCity"
        Me.BirthCity.ReadOnly = True
        Me.BirthCity.Visible = False
        '
        'AddressCountryCode
        '
        Me.AddressCountryCode.DataPropertyName = "AddressCountryCode"
        Me.AddressCountryCode.HeaderText = "AddressCountryCode"
        Me.AddressCountryCode.Name = "AddressCountryCode"
        Me.AddressCountryCode.ReadOnly = True
        Me.AddressCountryCode.Visible = False
        '
        'LegalAddressType
        '
        Me.LegalAddressType.DataPropertyName = "LegalAddressType"
        Me.LegalAddressType.HeaderText = "LegalAddressType"
        Me.LegalAddressType.Name = "LegalAddressType"
        Me.LegalAddressType.ReadOnly = True
        Me.LegalAddressType.Visible = False
        '
        'AddressFree
        '
        Me.AddressFree.DataPropertyName = "AddressFree"
        Me.AddressFree.HeaderText = "AddressFree"
        Me.AddressFree.Name = "AddressFree"
        Me.AddressFree.ReadOnly = True
        Me.AddressFree.Visible = False
        '
        'frmCRSMasterMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(740, 515)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvCRSMaster)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.KeyPreview = True
        Me.Name = "frmCRSMasterMain"
        Me.Text = "CRS Master Maintence"
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.dgvCRSMaster, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvCRSMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtAccno As ESL.myTextbox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents dgvCRSMaster As System.Windows.Forms.DataGridView
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmbCRSType As ESL.myComboBox
    Friend WithEvents rbFutures As ESL.myRadioButton
    Friend WithEvents rbSecurities As ESL.myRadioButton
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbExportFutures As ESL.myRadioButton
    Friend WithEvents rbExportSecurities As ESL.myRadioButton
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExport As ESL.myButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpRetrunYear As ESL.myDateTimePicker
    Friend WithEvents Mid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Accno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ClientName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CrsType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AccHolderType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CPType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ResCountryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TINIssueBy As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Firstname As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LastName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BirthDate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BirthCountryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BirthCity As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddressCountryCode As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents LegalAddressType As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AddressFree As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
