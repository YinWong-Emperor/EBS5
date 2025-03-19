<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCouponAlertType
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCouponAlertType))
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.cmbSearchType = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.dgvAlert = New System.Windows.Forms.DataGridView
        Me.alert_type_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.type = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupddate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupdby = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.ambValue = New ESL.myAmountBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cmbType = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvAlert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(315, 290)
        Me.btnCancel.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(263, 290)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Visible = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.cmbSearchType)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(360, 40)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(227, 12)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbSearchType
        '
        Me.cmbSearchType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSearchType.FormattingEnabled = True
        Me.cmbSearchType.Location = New System.Drawing.Point(47, 13)
        Me.cmbSearchType.Name = "cmbSearchType"
        Me.cmbSearchType.Size = New System.Drawing.Size(120, 23)
        Me.cmbSearchType.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(33, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Type"
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(207, 290)
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
        Me.btnNew.Location = New System.Drawing.Point(105, 290)
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
        Me.btnEdit.Location = New System.Drawing.Point(156, 290)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'dgvAlert
        '
        Me.dgvAlert.AllowUserToAddRows = False
        Me.dgvAlert.AllowUserToDeleteRows = False
        Me.dgvAlert.AllowUserToResizeColumns = False
        Me.dgvAlert.AllowUserToResizeRows = False
        Me.dgvAlert.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvAlert.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlert.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.alert_type_id, Me.type, Me.value, Me.lstupddate, Me.lstupdby})
        Me.dgvAlert.Location = New System.Drawing.Point(5, 45)
        Me.dgvAlert.MultiSelect = False
        Me.dgvAlert.Name = "dgvAlert"
        Me.dgvAlert.ReadOnly = True
        Me.dgvAlert.RowHeadersVisible = False
        Me.dgvAlert.RowTemplate.Height = 24
        Me.dgvAlert.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAlert.Size = New System.Drawing.Size(360, 200)
        Me.dgvAlert.TabIndex = 10
        '
        'alert_type_id
        '
        Me.alert_type_id.DataPropertyName = "alert_type_id"
        DataGridViewCellStyle1.Format = "N0"
        Me.alert_type_id.DefaultCellStyle = DataGridViewCellStyle1
        Me.alert_type_id.Frozen = True
        Me.alert_type_id.HeaderText = "alert_type_id"
        Me.alert_type_id.Name = "alert_type_id"
        Me.alert_type_id.ReadOnly = True
        Me.alert_type_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.alert_type_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.alert_type_id.Visible = False
        Me.alert_type_id.Width = 5
        '
        'type
        '
        Me.type.DataPropertyName = "type"
        Me.type.Frozen = True
        Me.type.HeaderText = "Type"
        Me.type.Name = "type"
        Me.type.ReadOnly = True
        Me.type.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.type.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.type.Width = 40
        '
        'value
        '
        Me.value.DataPropertyName = "value"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N0"
        Me.value.DefaultCellStyle = DataGridViewCellStyle2
        Me.value.Frozen = True
        Me.value.HeaderText = "Value"
        Me.value.Name = "value"
        Me.value.ReadOnly = True
        Me.value.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.value.Width = 80
        '
        'lstupddate
        '
        Me.lstupddate.DataPropertyName = "lstupddate"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "G"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.lstupddate.DefaultCellStyle = DataGridViewCellStyle3
        Me.lstupddate.Frozen = True
        Me.lstupddate.HeaderText = "Last update time"
        Me.lstupddate.Name = "lstupddate"
        Me.lstupddate.ReadOnly = True
        Me.lstupddate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstupddate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.lstupddate.Width = 120
        '
        'lstupdby
        '
        Me.lstupdby.DataPropertyName = "lstupdby"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.lstupdby.DefaultCellStyle = DataGridViewCellStyle4
        Me.lstupdby.Frozen = True
        Me.lstupdby.HeaderText = "Last update by"
        Me.lstupdby.Name = "lstupdby"
        Me.lstupdby.ReadOnly = True
        Me.lstupdby.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstupdby.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.ambValue)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.cmbType)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 245)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(360, 40)
        Me.GroupBox2.TabIndex = 11
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details"
        '
        'ambValue
        '
        Me.ambValue.DecimalPoints = 2
        Me.ambValue.Enabled = False
        Me.ambValue.Location = New System.Drawing.Point(227, 13)
        Me.ambValue.Name = "ambValue"
        Me.ambValue.Size = New System.Drawing.Size(120, 21)
        Me.ambValue.TabIndex = 1
        Me.ambValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(183, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(38, 15)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Value"
        '
        'cmbType
        '
        Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbType.Enabled = False
        Me.cmbType.FormattingEnabled = True
        Me.cmbType.Location = New System.Drawing.Point(47, 13)
        Me.cmbType.Name = "cmbType"
        Me.cmbType.Size = New System.Drawing.Size(120, 23)
        Me.cmbType.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(33, 15)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Type"
        '
        'frmCouponAlertType
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(369, 348)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.dgvAlert)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.GroupBox1)
        Me.KeyPreview = True
        Me.Name = "frmCouponAlertType"
        Me.Text = "Coupon Alert Type"
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.dgvAlert, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvAlert, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSearchType As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents dgvAlert As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ambValue As ESL.myAmountBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbType As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents alert_type_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupdby As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
