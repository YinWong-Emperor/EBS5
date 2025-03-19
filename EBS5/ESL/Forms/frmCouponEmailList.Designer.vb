<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCouponEmailList
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCouponEmailList))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.cmbSID = New ESL.myComboBox(Me.components)
        Me.cmbSAcc = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvEmail = New System.Windows.Forms.DataGridView
        Me.email_list_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.account_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sales_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.alert_type_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.alert_type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.email_addr = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupddate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupdby = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtSales = New ESL.myTextbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtAcc = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.cmbAlertID = New ESL.myComboBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtEmail = New ESL.myTextbox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(460, 334)
        Me.btnCancel.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(408, 334)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.cmbSID)
        Me.GroupBox1.Controls.Add(Me.cmbSAcc)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(505, 40)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(419, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(80, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Query"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbSID
        '
        Me.cmbSID.FormattingEnabled = True
        Me.cmbSID.Location = New System.Drawing.Point(294, 14)
        Me.cmbSID.Name = "cmbSID"
        Me.cmbSID.Size = New System.Drawing.Size(120, 23)
        Me.cmbSID.TabIndex = 1
        '
        'cmbSAcc
        '
        Me.cmbSAcc.FormattingEnabled = True
        Me.cmbSAcc.Location = New System.Drawing.Point(85, 14)
        Me.cmbSAcc.Name = "cmbSAcc"
        Me.cmbSAcc.Size = New System.Drawing.Size(120, 23)
        Me.cmbSAcc.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(211, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(54, 15)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Sales ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(74, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Account NO."
        '
        'dgvEmail
        '
        Me.dgvEmail.AllowUserToAddRows = False
        Me.dgvEmail.AllowUserToDeleteRows = False
        Me.dgvEmail.AllowUserToResizeColumns = False
        Me.dgvEmail.AllowUserToResizeRows = False
        Me.dgvEmail.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvEmail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvEmail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.email_list_id, Me.account_no, Me.sales_id, Me.alert_type_id, Me.alert_type, Me.email_addr, Me.lstupddate, Me.lstupdby})
        Me.dgvEmail.Location = New System.Drawing.Point(5, 45)
        Me.dgvEmail.MultiSelect = False
        Me.dgvEmail.Name = "dgvEmail"
        Me.dgvEmail.ReadOnly = True
        Me.dgvEmail.RowHeadersVisible = False
        Me.dgvEmail.RowTemplate.Height = 24
        Me.dgvEmail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvEmail.Size = New System.Drawing.Size(505, 200)
        Me.dgvEmail.TabIndex = 7
        '
        'email_list_id
        '
        Me.email_list_id.DataPropertyName = "email_list_id"
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N0"
        Me.email_list_id.DefaultCellStyle = DataGridViewCellStyle1
        Me.email_list_id.Frozen = True
        Me.email_list_id.HeaderText = "Email List ID"
        Me.email_list_id.Name = "email_list_id"
        Me.email_list_id.ReadOnly = True
        Me.email_list_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.email_list_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.email_list_id.Visible = False
        Me.email_list_id.Width = 5
        '
        'account_no
        '
        Me.account_no.DataPropertyName = "account_no"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.account_no.DefaultCellStyle = DataGridViewCellStyle2
        Me.account_no.Frozen = True
        Me.account_no.HeaderText = "Account No."
        Me.account_no.Name = "account_no"
        Me.account_no.ReadOnly = True
        Me.account_no.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.account_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'sales_id
        '
        Me.sales_id.DataPropertyName = "sales_id"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Format = "N0"
        Me.sales_id.DefaultCellStyle = DataGridViewCellStyle3
        Me.sales_id.Frozen = True
        Me.sales_id.HeaderText = "Sales ID"
        Me.sales_id.Name = "sales_id"
        Me.sales_id.ReadOnly = True
        Me.sales_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.sales_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'alert_type_id
        '
        Me.alert_type_id.DataPropertyName = "alert_type_id"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        Me.alert_type_id.DefaultCellStyle = DataGridViewCellStyle4
        Me.alert_type_id.Frozen = True
        Me.alert_type_id.HeaderText = "Alert ID"
        Me.alert_type_id.Name = "alert_type_id"
        Me.alert_type_id.ReadOnly = True
        Me.alert_type_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.alert_type_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.alert_type_id.Visible = False
        Me.alert_type_id.Width = 5
        '
        'alert_type
        '
        Me.alert_type.DataPropertyName = "alert_type"
        Me.alert_type.Frozen = True
        Me.alert_type.HeaderText = "Alert Type"
        Me.alert_type.Name = "alert_type"
        Me.alert_type.ReadOnly = True
        Me.alert_type.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.alert_type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.alert_type.Width = 80
        '
        'email_addr
        '
        Me.email_addr.DataPropertyName = "email_addr"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.email_addr.DefaultCellStyle = DataGridViewCellStyle5
        Me.email_addr.Frozen = True
        Me.email_addr.HeaderText = "Email Addr."
        Me.email_addr.Name = "email_addr"
        Me.email_addr.ReadOnly = True
        Me.email_addr.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.email_addr.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.email_addr.Width = 200
        '
        'lstupddate
        '
        Me.lstupddate.DataPropertyName = "lstupddate"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "G"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.lstupddate.DefaultCellStyle = DataGridViewCellStyle6
        Me.lstupddate.Frozen = True
        Me.lstupddate.HeaderText = "Last Update Time"
        Me.lstupddate.Name = "lstupddate"
        Me.lstupddate.ReadOnly = True
        Me.lstupddate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstupddate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.lstupddate.Visible = False
        Me.lstupddate.Width = 5
        '
        'lstupdby
        '
        Me.lstupdby.DataPropertyName = "lstupdby"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.lstupdby.DefaultCellStyle = DataGridViewCellStyle7
        Me.lstupdby.Frozen = True
        Me.lstupdby.HeaderText = "Last Update By"
        Me.lstupdby.Name = "lstupdby"
        Me.lstupdby.ReadOnly = True
        Me.lstupdby.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstupdby.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.lstupdby.Visible = False
        Me.lstupdby.Width = 5
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSales)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.txtAcc)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.cmbAlertID)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtEmail)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 245)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(505, 82)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details"
        '
        'txtSales
        '
        Me.txtSales.Enabled = False
        Me.txtSales.Location = New System.Drawing.Point(294, 12)
        Me.txtSales.Name = "txtSales"
        Me.txtSales.Size = New System.Drawing.Size(120, 21)
        Me.txtSales.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(211, 15)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Sales ID"
        '
        'txtAcc
        '
        Me.txtAcc.Enabled = False
        Me.txtAcc.Location = New System.Drawing.Point(85, 12)
        Me.txtAcc.Name = "txtAcc"
        Me.txtAcc.Size = New System.Drawing.Size(120, 21)
        Me.txtAcc.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(5, 15)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Account No."
        '
        'cmbAlertID
        '
        Me.cmbAlertID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbAlertID.Enabled = False
        Me.cmbAlertID.FormattingEnabled = True
        Me.cmbAlertID.Location = New System.Drawing.Point(85, 34)
        Me.cmbAlertID.Name = "cmbAlertID"
        Me.cmbAlertID.Size = New System.Drawing.Size(329, 23)
        Me.cmbAlertID.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 37)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Alert Type"
        '
        'txtEmail
        '
        Me.txtEmail.Enabled = False
        Me.txtEmail.Location = New System.Drawing.Point(85, 58)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(329, 21)
        Me.txtEmail.TabIndex = 3
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(5, 61)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Email Addr."
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(351, 334)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(249, 334)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Image = CType(resources.GetObject("btnEdit.Image"), System.Drawing.Image)
        Me.btnEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnEdit.Location = New System.Drawing.Point(300, 334)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'frmCouponEmailList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(514, 393)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvEmail)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmCouponEmailList"
        Me.Text = "Coupon Email List"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.dgvEmail, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvEmail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSAcc As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents cmbSID As ESL.myComboBox
    Friend WithEvents dgvEmail As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As ESL.myTextbox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAcc As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents cmbAlertID As ESL.myComboBox
    Friend WithEvents txtSales As ESL.myTextbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents email_list_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents account_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sales_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alert_type_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents alert_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents email_addr As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupdby As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
