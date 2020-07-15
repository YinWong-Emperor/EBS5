<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCouponPlan
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
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCouponPlan))
        Me.dgvCouponPlan = New System.Windows.Forms.DataGridView
        Me.coupon_plan_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.plan_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Turnover_limit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grace_value_percentage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grace_period = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.expiry_extension_period = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupddate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupdby = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtPlanCode = New ESL.myTextbox
        Me.Label8 = New System.Windows.Forms.Label
        Me.nmbExpiry = New ESL.myNumericBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.nmbGracePeriod = New ESL.myNumericBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.nmbGraceValue = New ESL.myNumericBox
        Me.label3 = New System.Windows.Forms.Label
        Me.nmbTurnover = New ESL.myNumericBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.ambPrice = New ESL.myAmountBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbPlanCode = New ESL.myComboBox(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.Label9 = New System.Windows.Forms.Label
        CType(Me.dgvCouponPlan, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(570, 432)
        Me.btnCancel.TabIndex = 4
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(519, 432)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Visible = True
        '
        'dgvCouponPlan
        '
        Me.dgvCouponPlan.AllowUserToAddRows = False
        Me.dgvCouponPlan.AllowUserToDeleteRows = False
        Me.dgvCouponPlan.AllowUserToResizeColumns = False
        Me.dgvCouponPlan.AllowUserToResizeRows = False
        Me.dgvCouponPlan.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvCouponPlan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCouponPlan.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.coupon_plan_id, Me.plan_code, Me.price, Me.Turnover_limit, Me.grace_value_percentage, Me.grace_period, Me.expiry_extension_period, Me.lstupddate, Me.lstupdby})
        Me.dgvCouponPlan.Location = New System.Drawing.Point(5, 45)
        Me.dgvCouponPlan.MultiSelect = False
        Me.dgvCouponPlan.Name = "dgvCouponPlan"
        Me.dgvCouponPlan.ReadOnly = True
        Me.dgvCouponPlan.RowHeadersVisible = False
        Me.dgvCouponPlan.RowTemplate.Height = 24
        Me.dgvCouponPlan.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCouponPlan.Size = New System.Drawing.Size(615, 300)
        Me.dgvCouponPlan.TabIndex = 6
        '
        'coupon_plan_id
        '
        Me.coupon_plan_id.DataPropertyName = "coupon_plan_id"
        DataGridViewCellStyle1.Format = "N0"
        Me.coupon_plan_id.DefaultCellStyle = DataGridViewCellStyle1
        Me.coupon_plan_id.Frozen = True
        Me.coupon_plan_id.HeaderText = "Coupon PlanID"
        Me.coupon_plan_id.Name = "coupon_plan_id"
        Me.coupon_plan_id.ReadOnly = True
        Me.coupon_plan_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.coupon_plan_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.coupon_plan_id.Visible = False
        Me.coupon_plan_id.Width = 5
        '
        'plan_code
        '
        Me.plan_code.DataPropertyName = "plan_code"
        Me.plan_code.Frozen = True
        Me.plan_code.HeaderText = "Plan Code"
        Me.plan_code.Name = "plan_code"
        Me.plan_code.ReadOnly = True
        Me.plan_code.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.plan_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.plan_code.Width = 80
        '
        'price
        '
        Me.price.DataPropertyName = "price"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.price.DefaultCellStyle = DataGridViewCellStyle2
        Me.price.Frozen = True
        Me.price.HeaderText = "Price (1K)"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        Me.price.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Turnover_limit
        '
        Me.Turnover_limit.DataPropertyName = "turnover_limit"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.Turnover_limit.DefaultCellStyle = DataGridViewCellStyle3
        Me.Turnover_limit.Frozen = True
        Me.Turnover_limit.HeaderText = "Turnover limit (100M)"
        Me.Turnover_limit.Name = "Turnover_limit"
        Me.Turnover_limit.ReadOnly = True
        Me.Turnover_limit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Turnover_limit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'grace_value_percentage
        '
        Me.grace_value_percentage.DataPropertyName = "grace_value_percentage"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N0"
        Me.grace_value_percentage.DefaultCellStyle = DataGridViewCellStyle4
        Me.grace_value_percentage.Frozen = True
        Me.grace_value_percentage.HeaderText = "Grace Value Percentage"
        Me.grace_value_percentage.Name = "grace_value_percentage"
        Me.grace_value_percentage.ReadOnly = True
        Me.grace_value_percentage.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grace_value_percentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'grace_period
        '
        Me.grace_period.DataPropertyName = "grace_period"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N0"
        Me.grace_period.DefaultCellStyle = DataGridViewCellStyle5
        Me.grace_period.Frozen = True
        Me.grace_period.HeaderText = "Grace Period (day)"
        Me.grace_period.Name = "grace_period"
        Me.grace_period.ReadOnly = True
        Me.grace_period.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grace_period.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'expiry_extension_period
        '
        Me.expiry_extension_period.DataPropertyName = "expiry_extension_period"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N0"
        Me.expiry_extension_period.DefaultCellStyle = DataGridViewCellStyle6
        Me.expiry_extension_period.Frozen = True
        Me.expiry_extension_period.HeaderText = "Expiry Extension Period (day)"
        Me.expiry_extension_period.Name = "expiry_extension_period"
        Me.expiry_extension_period.ReadOnly = True
        Me.expiry_extension_period.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.expiry_extension_period.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.expiry_extension_period.Width = 110
        '
        'lstupddate
        '
        Me.lstupddate.DataPropertyName = "lstupddate"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "G"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.lstupddate.DefaultCellStyle = DataGridViewCellStyle7
        Me.lstupddate.Frozen = True
        Me.lstupddate.HeaderText = "Last Update Time"
        Me.lstupddate.Name = "lstupddate"
        Me.lstupddate.ReadOnly = True
        Me.lstupddate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstupddate.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.lstupddate.Visible = False
        Me.lstupddate.Width = 120
        '
        'lstupdby
        '
        Me.lstupdby.DataPropertyName = "lstupdby"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.lstupdby.DefaultCellStyle = DataGridViewCellStyle8
        Me.lstupdby.Frozen = True
        Me.lstupdby.HeaderText = "Last Update User"
        Me.lstupdby.Name = "lstupdby"
        Me.lstupdby.ReadOnly = True
        Me.lstupdby.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstupdby.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.lstupdby.Visible = False
        Me.lstupdby.Width = 80
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(463, 432)
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
        Me.btnNew.Location = New System.Drawing.Point(361, 432)
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
        Me.btnEdit.Location = New System.Drawing.Point(412, 432)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPlanCode)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.nmbExpiry)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.nmbGracePeriod)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.nmbGraceValue)
        Me.GroupBox1.Controls.Add(Me.label3)
        Me.GroupBox1.Controls.Add(Me.nmbTurnover)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ambPrice)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 345)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(615, 80)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Details"
        '
        'txtPlanCode
        '
        Me.txtPlanCode.Enabled = False
        Me.txtPlanCode.Location = New System.Drawing.Point(179, 11)
        Me.txtPlanCode.Name = "txtPlanCode"
        Me.txtPlanCode.Size = New System.Drawing.Size(120, 21)
        Me.txtPlanCode.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(5, 14)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(62, 15)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Plan code"
        '
        'nmbExpiry
        '
        Me.nmbExpiry.Enabled = False
        Me.nmbExpiry.Location = New System.Drawing.Point(487, 55)
        Me.nmbExpiry.Name = "nmbExpiry"
        Me.nmbExpiry.Size = New System.Drawing.Size(120, 21)
        Me.nmbExpiry.TabIndex = 5
        Me.nmbExpiry.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(306, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 15)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Expiry extension (day)"
        '
        'nmbGracePeriod
        '
        Me.nmbGracePeriod.Enabled = False
        Me.nmbGracePeriod.Location = New System.Drawing.Point(179, 55)
        Me.nmbGracePeriod.Name = "nmbGracePeriod"
        Me.nmbGracePeriod.Size = New System.Drawing.Size(120, 21)
        Me.nmbGracePeriod.TabIndex = 4
        Me.nmbGracePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 58)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(108, 15)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Grace period (day)"
        '
        'nmbGraceValue
        '
        Me.nmbGraceValue.Enabled = False
        Me.nmbGraceValue.Location = New System.Drawing.Point(487, 33)
        Me.nmbGraceValue.Name = "nmbGraceValue"
        Me.nmbGraceValue.Size = New System.Drawing.Size(120, 21)
        Me.nmbGraceValue.TabIndex = 3
        Me.nmbGraceValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'label3
        '
        Me.label3.AutoSize = True
        Me.label3.Location = New System.Drawing.Point(305, 36)
        Me.label3.Name = "label3"
        Me.label3.Size = New System.Drawing.Size(94, 15)
        Me.label3.TabIndex = 4
        Me.label3.Text = "Grace value (%)"
        '
        'nmbTurnover
        '
        Me.nmbTurnover.Enabled = False
        Me.nmbTurnover.Location = New System.Drawing.Point(179, 33)
        Me.nmbTurnover.Name = "nmbTurnover"
        Me.nmbTurnover.Size = New System.Drawing.Size(120, 21)
        Me.nmbTurnover.TabIndex = 2
        Me.nmbTurnover.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 36)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(122, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Turnover limit (100M)"
        '
        'ambPrice
        '
        Me.ambPrice.DecimalPoints = 2
        Me.ambPrice.Enabled = False
        Me.ambPrice.Location = New System.Drawing.Point(487, 11)
        Me.ambPrice.Name = "ambPrice"
        Me.ambPrice.Size = New System.Drawing.Size(120, 21)
        Me.ambPrice.TabIndex = 1
        Me.ambPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(305, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Price(1K)"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbPlanCode)
        Me.GroupBox2.Controls.Add(Me.btnSearch)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(615, 40)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Search"
        '
        'cmbPlanCode
        '
        Me.cmbPlanCode.FormattingEnabled = True
        Me.cmbPlanCode.Location = New System.Drawing.Point(133, 14)
        Me.cmbPlanCode.Name = "cmbPlanCode"
        Me.cmbPlanCode.Size = New System.Drawing.Size(120, 23)
        Me.cmbPlanCode.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(487, 13)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 23)
        Me.btnSearch.TabIndex = 1
        Me.btnSearch.Text = "Query"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(5, 17)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 15)
        Me.Label9.TabIndex = 0
        Me.Label9.Text = "Plan code"
        '
        'frmCouponPlan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(624, 493)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.dgvCouponPlan)
        Me.KeyPreview = True
        Me.Name = "frmCouponPlan"
        Me.Text = "Coupon Plan"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.dgvCouponPlan, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        CType(Me.dgvCouponPlan, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dgvCouponPlan As System.Windows.Forms.DataGridView
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents nmbGraceValue As ESL.myNumericBox
    Friend WithEvents label3 As System.Windows.Forms.Label
    Friend WithEvents nmbTurnover As ESL.myNumericBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ambPrice As ESL.myAmountBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents nmbGracePeriod As ESL.myNumericBox
    Friend WithEvents nmbExpiry As ESL.myNumericBox
    Friend WithEvents txtPlanCode As ESL.myTextbox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents cmbPlanCode As ESL.myComboBox
    Friend WithEvents coupon_plan_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plan_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Turnover_limit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grace_value_percentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grace_period As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents expiry_extension_period As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupdby As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
