<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCoupons
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCoupons))
        Dim DataGridViewCellStyle22 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle23 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle24 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle25 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle26 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle27 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle28 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle29 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle30 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle31 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle32 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle33 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle34 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle35 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle36 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle37 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle38 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle39 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle40 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle41 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle42 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnNew = New ESL.myButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbSAcc = New ESL.myComboBox(Me.components)
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.cmbSStatus = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dptPruD = New ESL.myDateTimePicker
        Me.txtAcc = New ESL.myTextbox
        Me.txtCreatTime = New ESL.myTextbox
        Me.txtCreateBy = New ESL.myTextbox
        Me.dtpExpD = New ESL.myDateTimePicker
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.txtStatus = New ESL.myTextbox
        Me.Label16 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ambGVC = New ESL.myAmountBox
        Me.ambVC = New ESL.myAmountBox
        Me.ambCVID = New ESL.myAmountBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.ambGV = New ESL.myAmountBox
        Me.ambPrice = New ESL.myAmountBox
        Me.ambEEP = New ESL.myAmountBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmbPlanCode = New ESL.myComboBox(Me.components)
        Me.txtPlanID = New ESL.myTextbox
        Me.ambLimit = New ESL.myAmountBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ambGVP = New ESL.myAmountBox
        Me.ambGracePeriod = New ESL.myAmountBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvCoupon = New System.Windows.Forms.DataGridView
        Me.coupon_info_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.coupon_value_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.account_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.value_consumed = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grace_value_consumed = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.coupon_plan_id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.plan_code = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grace_value_percentage = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grace_value = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turnover_limit = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grace_period = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.expiry_extension_period = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.purchase_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.expiry_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.grace_expiry = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.status = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.creation_date = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.created_by = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupddate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.lstupdby = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.price = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.dgvCoupon, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(761, 527)
        Me.btnCancel.TabIndex = 3
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(709, 527)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Visible = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnDelete.Location = New System.Drawing.Point(657, 527)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 1
        Me.btnDelete.Text = "Void"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnNew
        '
        Me.btnNew.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnNew.Image = CType(resources.GetObject("btnNew.Image"), System.Drawing.Image)
        Me.btnNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.btnNew.Location = New System.Drawing.Point(605, 527)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(50, 55)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "New"
        Me.btnNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnNew.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbSAcc)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.cmbSStatus)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(806, 40)
        Me.GroupBox1.TabIndex = 18
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Search"
        '
        'cmbSAcc
        '
        Me.cmbSAcc.FormattingEnabled = True
        Me.cmbSAcc.Location = New System.Drawing.Point(140, 12)
        Me.cmbSAcc.Name = "cmbSAcc"
        Me.cmbSAcc.Size = New System.Drawing.Size(120, 23)
        Me.cmbSAcc.TabIndex = 0
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(674, 10)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(120, 23)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.Text = "Query"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'cmbSStatus
        '
        Me.cmbSStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSStatus.FormattingEnabled = True
        Me.cmbSStatus.Location = New System.Drawing.Point(435, 11)
        Me.cmbSStatus.Name = "cmbSStatus"
        Me.cmbSStatus.Size = New System.Drawing.Size(120, 23)
        Me.cmbSStatus.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(266, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 15)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Status"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(11, 14)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Account No."
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dptPruD)
        Me.GroupBox2.Controls.Add(Me.txtAcc)
        Me.GroupBox2.Controls.Add(Me.txtCreatTime)
        Me.GroupBox2.Controls.Add(Me.txtCreateBy)
        Me.GroupBox2.Controls.Add(Me.dtpExpD)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.txtStatus)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(4, 345)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(807, 175)
        Me.GroupBox2.TabIndex = 20
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Details"
        '
        'dptPruD
        '
        Me.dptPruD.Enabled = False
        Me.dptPruD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dptPruD.Location = New System.Drawing.Point(436, 11)
        Me.dptPruD.Name = "dptPruD"
        Me.dptPruD.Size = New System.Drawing.Size(120, 21)
        Me.dptPruD.TabIndex = 1
        Me.dptPruD.Value = New Date(2009, 8, 25, 0, 0, 0, 0)
        '
        'txtAcc
        '
        Me.txtAcc.Enabled = False
        Me.txtAcc.Location = New System.Drawing.Point(141, 11)
        Me.txtAcc.Name = "txtAcc"
        Me.txtAcc.Size = New System.Drawing.Size(120, 21)
        Me.txtAcc.TabIndex = 0
        '
        'txtCreatTime
        '
        Me.txtCreatTime.Enabled = False
        Me.txtCreatTime.Location = New System.Drawing.Point(141, 33)
        Me.txtCreatTime.Name = "txtCreatTime"
        Me.txtCreatTime.ReadOnly = True
        Me.txtCreatTime.Size = New System.Drawing.Size(120, 21)
        Me.txtCreatTime.TabIndex = 6
        Me.txtCreatTime.WordWrap = False
        '
        'txtCreateBy
        '
        Me.txtCreateBy.Enabled = False
        Me.txtCreateBy.Location = New System.Drawing.Point(436, 33)
        Me.txtCreateBy.Name = "txtCreateBy"
        Me.txtCreateBy.ReadOnly = True
        Me.txtCreateBy.Size = New System.Drawing.Size(120, 21)
        Me.txtCreateBy.TabIndex = 5
        '
        'dtpExpD
        '
        Me.dtpExpD.Enabled = False
        Me.dtpExpD.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpExpD.Location = New System.Drawing.Point(675, 11)
        Me.dtpExpD.Name = "dtpExpD"
        Me.dtpExpD.Size = New System.Drawing.Size(120, 21)
        Me.dtpExpD.TabIndex = 2
        Me.dtpExpD.Value = New Date(2009, 8, 25, 0, 0, 0, 0)
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(562, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(68, 15)
        Me.Label14.TabIndex = 9
        Me.Label14.Text = "Expiry Date"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 36)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(81, 15)
        Me.Label17.TabIndex = 16
        Me.Label17.Text = "Creation time"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(562, 36)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(42, 15)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Status"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(267, 14)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(89, 15)
        Me.Label13.TabIndex = 7
        Me.Label13.Text = "Pruchase Date"
        '
        'txtStatus
        '
        Me.txtStatus.Enabled = False
        Me.txtStatus.Location = New System.Drawing.Point(675, 33)
        Me.txtStatus.Name = "txtStatus"
        Me.txtStatus.ReadOnly = True
        Me.txtStatus.Size = New System.Drawing.Size(120, 21)
        Me.txtStatus.TabIndex = 3
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(267, 36)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(67, 15)
        Me.Label16.TabIndex = 14
        Me.Label16.Text = "Created By"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ambGVC)
        Me.GroupBox4.Controls.Add(Me.ambVC)
        Me.GroupBox4.Controls.Add(Me.ambCVID)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 137)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(795, 35)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Coupon Value Details"
        '
        'ambGVC
        '
        Me.ambGVC.DecimalPoints = 2
        Me.ambGVC.Enabled = False
        Me.ambGVC.Location = New System.Drawing.Point(430, 10)
        Me.ambGVC.Name = "ambGVC"
        Me.ambGVC.ReadOnly = True
        Me.ambGVC.Size = New System.Drawing.Size(120, 21)
        Me.ambGVC.TabIndex = 19
        Me.ambGVC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ambVC
        '
        Me.ambVC.DecimalPoints = 2
        Me.ambVC.Enabled = False
        Me.ambVC.Location = New System.Drawing.Point(669, 10)
        Me.ambVC.Name = "ambVC"
        Me.ambVC.ReadOnly = True
        Me.ambVC.Size = New System.Drawing.Size(120, 21)
        Me.ambVC.TabIndex = 18
        Me.ambVC.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ambCVID
        '
        Me.ambCVID.DecimalPoints = 2
        Me.ambCVID.Enabled = False
        Me.ambCVID.Location = New System.Drawing.Point(135, 10)
        Me.ambCVID.Name = "ambCVID"
        Me.ambCVID.ReadOnly = True
        Me.ambCVID.Size = New System.Drawing.Size(120, 21)
        Me.ambCVID.TabIndex = 15
        Me.ambCVID.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(100, 15)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "Coupon Value ID"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(261, 13)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(139, 15)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Grace Value Consumed"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(556, 13)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(103, 15)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Value Consumed"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.ambGV)
        Me.GroupBox3.Controls.Add(Me.ambPrice)
        Me.GroupBox3.Controls.Add(Me.ambEEP)
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.cmbPlanCode)
        Me.GroupBox3.Controls.Add(Me.txtPlanID)
        Me.GroupBox3.Controls.Add(Me.ambLimit)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.ambGVP)
        Me.GroupBox3.Controls.Add(Me.ambGracePeriod)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 54)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(795, 80)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Coupon Plan Details"
        '
        'ambGV
        '
        Me.ambGV.DecimalPoints = 2
        Me.ambGV.Enabled = False
        Me.ambGV.Location = New System.Drawing.Point(669, 55)
        Me.ambGV.Name = "ambGV"
        Me.ambGV.ReadOnly = True
        Me.ambGV.Size = New System.Drawing.Size(120, 21)
        Me.ambGV.TabIndex = 14
        Me.ambGV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ambPrice
        '
        Me.ambPrice.DecimalPoints = 2
        Me.ambPrice.Enabled = False
        Me.ambPrice.Location = New System.Drawing.Point(430, 11)
        Me.ambPrice.Name = "ambPrice"
        Me.ambPrice.ReadOnly = True
        Me.ambPrice.Size = New System.Drawing.Size(120, 21)
        Me.ambPrice.TabIndex = 6
        Me.ambPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ambEEP
        '
        Me.ambEEP.DecimalPoints = 2
        Me.ambEEP.Enabled = False
        Me.ambEEP.Location = New System.Drawing.Point(430, 33)
        Me.ambEEP.Name = "ambEEP"
        Me.ambEEP.ReadOnly = True
        Me.ambEEP.Size = New System.Drawing.Size(120, 21)
        Me.ambEEP.TabIndex = 16
        Me.ambEEP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(556, 58)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(115, 15)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Grace Value (100M)"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(261, 36)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(161, 15)
        Me.Label18.TabIndex = 15
        Me.Label18.Text = "Expiry Extention Period (day)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(261, 14)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 15)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Price"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(5, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(112, 15)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Coupon Plan Code"
        '
        'cmbPlanCode
        '
        Me.cmbPlanCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPlanCode.Enabled = False
        Me.cmbPlanCode.FormattingEnabled = True
        Me.cmbPlanCode.Location = New System.Drawing.Point(135, 9)
        Me.cmbPlanCode.Name = "cmbPlanCode"
        Me.cmbPlanCode.Size = New System.Drawing.Size(120, 23)
        Me.cmbPlanCode.TabIndex = 0
        '
        'txtPlanID
        '
        Me.txtPlanID.Enabled = False
        Me.txtPlanID.Location = New System.Drawing.Point(135, 11)
        Me.txtPlanID.Name = "txtPlanID"
        Me.txtPlanID.ReadOnly = True
        Me.txtPlanID.Size = New System.Drawing.Size(10, 21)
        Me.txtPlanID.TabIndex = 4
        Me.txtPlanID.Visible = False
        '
        'ambLimit
        '
        Me.ambLimit.DecimalPoints = 2
        Me.ambLimit.Enabled = False
        Me.ambLimit.Location = New System.Drawing.Point(135, 55)
        Me.ambLimit.Name = "ambLimit"
        Me.ambLimit.ReadOnly = True
        Me.ambLimit.Size = New System.Drawing.Size(120, 21)
        Me.ambLimit.TabIndex = 8
        Me.ambLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(5, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(126, 15)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Turnover Limit (100M)"
        '
        'ambGVP
        '
        Me.ambGVP.DecimalPoints = 2
        Me.ambGVP.Enabled = False
        Me.ambGVP.Location = New System.Drawing.Point(430, 55)
        Me.ambGVP.Name = "ambGVP"
        Me.ambGVP.ReadOnly = True
        Me.ambGVP.Size = New System.Drawing.Size(120, 21)
        Me.ambGVP.TabIndex = 10
        Me.ambGVP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'ambGracePeriod
        '
        Me.ambGracePeriod.DecimalPoints = 2
        Me.ambGracePeriod.Enabled = False
        Me.ambGracePeriod.Location = New System.Drawing.Point(135, 33)
        Me.ambGracePeriod.Name = "ambGracePeriod"
        Me.ambGracePeriod.ReadOnly = True
        Me.ambGracePeriod.Size = New System.Drawing.Size(120, 21)
        Me.ambGracePeriod.TabIndex = 12
        Me.ambGracePeriod.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 36)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(109, 15)
        Me.Label8.TabIndex = 11
        Me.Label8.Text = "Grace Period (day)"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(261, 58)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(96, 15)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Grace Value (%)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(11, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Account No."
        '
        'dgvCoupon
        '
        Me.dgvCoupon.AllowUserToAddRows = False
        Me.dgvCoupon.AllowUserToDeleteRows = False
        Me.dgvCoupon.AllowUserToResizeColumns = False
        Me.dgvCoupon.AllowUserToResizeRows = False
        Me.dgvCoupon.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvCoupon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvCoupon.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.coupon_info_id, Me.coupon_value_id, Me.account_no, Me.value_consumed, Me.grace_value_consumed, Me.coupon_plan_id, Me.plan_code, Me.grace_value_percentage, Me.grace_value, Me.turnover_limit, Me.grace_period, Me.expiry_extension_period, Me.purchase_date, Me.expiry_date, Me.grace_expiry, Me.status, Me.creation_date, Me.created_by, Me.lstupddate, Me.lstupdby, Me.price})
        Me.dgvCoupon.Location = New System.Drawing.Point(5, 45)
        Me.dgvCoupon.MultiSelect = False
        Me.dgvCoupon.Name = "dgvCoupon"
        Me.dgvCoupon.ReadOnly = True
        Me.dgvCoupon.RowHeadersVisible = False
        Me.dgvCoupon.RowTemplate.Height = 24
        Me.dgvCoupon.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvCoupon.Size = New System.Drawing.Size(806, 300)
        Me.dgvCoupon.TabIndex = 19
        '
        'coupon_info_id
        '
        Me.coupon_info_id.DataPropertyName = "coupon_info_id"
        DataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle22.Format = "N0"
        Me.coupon_info_id.DefaultCellStyle = DataGridViewCellStyle22
        Me.coupon_info_id.Frozen = True
        Me.coupon_info_id.HeaderText = "Coupon ID"
        Me.coupon_info_id.Name = "coupon_info_id"
        Me.coupon_info_id.ReadOnly = True
        Me.coupon_info_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.coupon_info_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.coupon_info_id.Visible = False
        Me.coupon_info_id.Width = 5
        '
        'coupon_value_id
        '
        Me.coupon_value_id.DataPropertyName = "coupon_value_id"
        DataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle23.Format = "N0"
        Me.coupon_value_id.DefaultCellStyle = DataGridViewCellStyle23
        Me.coupon_value_id.Frozen = True
        Me.coupon_value_id.HeaderText = "Coupon Value ID"
        Me.coupon_value_id.Name = "coupon_value_id"
        Me.coupon_value_id.ReadOnly = True
        Me.coupon_value_id.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.coupon_value_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.coupon_value_id.Visible = False
        Me.coupon_value_id.Width = 5
        '
        'account_no
        '
        Me.account_no.DataPropertyName = "account_no"
        DataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.account_no.DefaultCellStyle = DataGridViewCellStyle24
        Me.account_no.Frozen = True
        Me.account_no.HeaderText = "Account No."
        Me.account_no.Name = "account_no"
        Me.account_no.ReadOnly = True
        Me.account_no.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.account_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'value_consumed
        '
        Me.value_consumed.DataPropertyName = "value_consumed"
        DataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle25.Format = "N2"
        DataGridViewCellStyle25.NullValue = Nothing
        Me.value_consumed.DefaultCellStyle = DataGridViewCellStyle25
        Me.value_consumed.Frozen = True
        Me.value_consumed.HeaderText = "Value Consumed"
        Me.value_consumed.Name = "value_consumed"
        Me.value_consumed.ReadOnly = True
        Me.value_consumed.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.value_consumed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.value_consumed.Width = 150
        '
        'grace_value_consumed
        '
        Me.grace_value_consumed.DataPropertyName = "grace_value_consumed"
        DataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle26.Format = "N2"
        DataGridViewCellStyle26.NullValue = Nothing
        Me.grace_value_consumed.DefaultCellStyle = DataGridViewCellStyle26
        Me.grace_value_consumed.Frozen = True
        Me.grace_value_consumed.HeaderText = "Grace Value  Consumed"
        Me.grace_value_consumed.Name = "grace_value_consumed"
        Me.grace_value_consumed.ReadOnly = True
        Me.grace_value_consumed.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grace_value_consumed.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grace_value_consumed.Width = 150
        '
        'coupon_plan_id
        '
        Me.coupon_plan_id.DataPropertyName = "coupon_plan_id"
        DataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.coupon_plan_id.DefaultCellStyle = DataGridViewCellStyle27
        Me.coupon_plan_id.Frozen = True
        Me.coupon_plan_id.HeaderText = "Coupon Plan ID"
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
        DataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.plan_code.DefaultCellStyle = DataGridViewCellStyle28
        Me.plan_code.Frozen = True
        Me.plan_code.HeaderText = "Plan Code"
        Me.plan_code.Name = "plan_code"
        Me.plan_code.ReadOnly = True
        Me.plan_code.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.plan_code.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.plan_code.Width = 80
        '
        'grace_value_percentage
        '
        Me.grace_value_percentage.DataPropertyName = "grace_value_percentage"
        DataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle29.Format = "N0"
        Me.grace_value_percentage.DefaultCellStyle = DataGridViewCellStyle29
        Me.grace_value_percentage.Frozen = True
        Me.grace_value_percentage.HeaderText = "Grace Value Percentage"
        Me.grace_value_percentage.Name = "grace_value_percentage"
        Me.grace_value_percentage.ReadOnly = True
        Me.grace_value_percentage.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grace_value_percentage.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grace_value_percentage.Visible = False
        Me.grace_value_percentage.Width = 5
        '
        'grace_value
        '
        Me.grace_value.DataPropertyName = "grace_value"
        DataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle30.Format = "N2"
        Me.grace_value.DefaultCellStyle = DataGridViewCellStyle30
        Me.grace_value.Frozen = True
        Me.grace_value.HeaderText = "Grace Value"
        Me.grace_value.Name = "grace_value"
        Me.grace_value.ReadOnly = True
        Me.grace_value.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grace_value.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grace_value.Visible = False
        Me.grace_value.Width = 5
        '
        'turnover_limit
        '
        Me.turnover_limit.DataPropertyName = "turnover_limit"
        DataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle31.Format = "N2"
        DataGridViewCellStyle31.NullValue = Nothing
        Me.turnover_limit.DefaultCellStyle = DataGridViewCellStyle31
        Me.turnover_limit.Frozen = True
        Me.turnover_limit.HeaderText = "Turn Over Limit (100M)"
        Me.turnover_limit.Name = "turnover_limit"
        Me.turnover_limit.ReadOnly = True
        Me.turnover_limit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.turnover_limit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.turnover_limit.Width = 150
        '
        'grace_period
        '
        Me.grace_period.DataPropertyName = "grace_period"
        DataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle32.Format = "N0"
        DataGridViewCellStyle32.NullValue = Nothing
        Me.grace_period.DefaultCellStyle = DataGridViewCellStyle32
        Me.grace_period.Frozen = True
        Me.grace_period.HeaderText = "Grace Period"
        Me.grace_period.Name = "grace_period"
        Me.grace_period.ReadOnly = True
        Me.grace_period.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grace_period.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grace_period.Visible = False
        Me.grace_period.Width = 5
        '
        'expiry_extension_period
        '
        Me.expiry_extension_period.DataPropertyName = "expiry_extension_period"
        DataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle33.Format = "N0"
        DataGridViewCellStyle33.NullValue = Nothing
        Me.expiry_extension_period.DefaultCellStyle = DataGridViewCellStyle33
        Me.expiry_extension_period.Frozen = True
        Me.expiry_extension_period.HeaderText = "Expiry Extention Period"
        Me.expiry_extension_period.Name = "expiry_extension_period"
        Me.expiry_extension_period.ReadOnly = True
        Me.expiry_extension_period.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.expiry_extension_period.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.expiry_extension_period.Visible = False
        Me.expiry_extension_period.Width = 5
        '
        'purchase_date
        '
        Me.purchase_date.DataPropertyName = "purchase_date"
        DataGridViewCellStyle34.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle34.Format = "d"
        DataGridViewCellStyle34.NullValue = Nothing
        Me.purchase_date.DefaultCellStyle = DataGridViewCellStyle34
        Me.purchase_date.Frozen = True
        Me.purchase_date.HeaderText = "Purchase Date"
        Me.purchase_date.Name = "purchase_date"
        Me.purchase_date.ReadOnly = True
        Me.purchase_date.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.purchase_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.purchase_date.Visible = False
        Me.purchase_date.Width = 5
        '
        'expiry_date
        '
        Me.expiry_date.DataPropertyName = "expiry_date"
        DataGridViewCellStyle35.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle35.Format = "d"
        DataGridViewCellStyle35.NullValue = Nothing
        Me.expiry_date.DefaultCellStyle = DataGridViewCellStyle35
        Me.expiry_date.Frozen = True
        Me.expiry_date.HeaderText = "Expiry Date"
        Me.expiry_date.Name = "expiry_date"
        Me.expiry_date.ReadOnly = True
        Me.expiry_date.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.expiry_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'grace_expiry
        '
        Me.grace_expiry.DataPropertyName = "grace_expiry"
        DataGridViewCellStyle36.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.grace_expiry.DefaultCellStyle = DataGridViewCellStyle36
        Me.grace_expiry.Frozen = True
        Me.grace_expiry.HeaderText = "Grace Expiry"
        Me.grace_expiry.Name = "grace_expiry"
        Me.grace_expiry.ReadOnly = True
        Me.grace_expiry.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.grace_expiry.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.grace_expiry.Visible = False
        Me.grace_expiry.Width = 5
        '
        'status
        '
        Me.status.DataPropertyName = "status"
        DataGridViewCellStyle37.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.status.DefaultCellStyle = DataGridViewCellStyle37
        Me.status.Frozen = True
        Me.status.HeaderText = "status"
        Me.status.Name = "status"
        Me.status.ReadOnly = True
        Me.status.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.status.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.status.Width = 50
        '
        'creation_date
        '
        Me.creation_date.DataPropertyName = "creation_date"
        DataGridViewCellStyle38.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle38.Format = "d"
        DataGridViewCellStyle38.NullValue = Nothing
        Me.creation_date.DefaultCellStyle = DataGridViewCellStyle38
        Me.creation_date.Frozen = True
        Me.creation_date.HeaderText = "Creation Date"
        Me.creation_date.Name = "creation_date"
        Me.creation_date.ReadOnly = True
        Me.creation_date.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.creation_date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.creation_date.Visible = False
        Me.creation_date.Width = 5
        '
        'created_by
        '
        Me.created_by.DataPropertyName = "created_by"
        DataGridViewCellStyle39.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.created_by.DefaultCellStyle = DataGridViewCellStyle39
        Me.created_by.Frozen = True
        Me.created_by.HeaderText = "Created By"
        Me.created_by.Name = "created_by"
        Me.created_by.ReadOnly = True
        Me.created_by.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.created_by.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.created_by.Visible = False
        Me.created_by.Width = 5
        '
        'lstupddate
        '
        Me.lstupddate.DataPropertyName = "lstupddate"
        DataGridViewCellStyle40.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle40.Format = "d"
        DataGridViewCellStyle40.NullValue = Nothing
        Me.lstupddate.DefaultCellStyle = DataGridViewCellStyle40
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
        DataGridViewCellStyle41.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle41.Format = "d"
        DataGridViewCellStyle41.NullValue = Nothing
        Me.lstupdby.DefaultCellStyle = DataGridViewCellStyle41
        Me.lstupdby.Frozen = True
        Me.lstupdby.HeaderText = "Last Update By"
        Me.lstupdby.Name = "lstupdby"
        Me.lstupdby.ReadOnly = True
        Me.lstupdby.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.lstupdby.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.lstupdby.Visible = False
        Me.lstupdby.Width = 5
        '
        'price
        '
        Me.price.DataPropertyName = "price"
        DataGridViewCellStyle42.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle42.Format = "N2"
        DataGridViewCellStyle42.NullValue = Nothing
        Me.price.DefaultCellStyle = DataGridViewCellStyle42
        Me.price.Frozen = True
        Me.price.HeaderText = "price"
        Me.price.Name = "price"
        Me.price.ReadOnly = True
        Me.price.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.price.Visible = False
        Me.price.Width = 5
        '
        'frmCoupons
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.BackColor = System.Drawing.Color.Linen
        Me.ClientSize = New System.Drawing.Size(814, 588)
        Me.Controls.Add(Me.dgvCoupon)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnNew)
        Me.KeyPreview = True
        Me.Name = "frmCoupons"
        Me.Text = "Coupon"
        Me.Controls.SetChildIndex(Me.btnNew, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.GroupBox2, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.dgvCoupon, 0)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.dgvCoupon, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnNew As ESL.myButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbSAcc As ESL.myComboBox
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents cmbSStatus As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbPlanCode As ESL.myComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPlanID As ESL.myTextbox
    Friend WithEvents ambPrice As ESL.myAmountBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ambGVP As ESL.myAmountBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ambLimit As ESL.myAmountBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ambGV As ESL.myAmountBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ambGracePeriod As ESL.myAmountBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents ambGVC As ESL.myAmountBox
    Friend WithEvents ambVC As ESL.myAmountBox
    Friend WithEvents ambCVID As ESL.myAmountBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents dtpExpD As ESL.myDateTimePicker
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtStatus As ESL.myTextbox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCreateBy As ESL.myTextbox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCreatTime As ESL.myTextbox
    Friend WithEvents txtAcc As ESL.myTextbox
    Friend WithEvents ambEEP As ESL.myAmountBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents dptPruD As ESL.myDateTimePicker
    Friend WithEvents dgvCoupon As System.Windows.Forms.DataGridView
    Friend WithEvents coupon_info_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coupon_value_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents account_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents value_consumed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grace_value_consumed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents coupon_plan_id As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plan_code As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grace_value_percentage As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grace_value As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turnover_limit As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grace_period As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents expiry_extension_period As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents purchase_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents expiry_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents grace_expiry As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents status As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents creation_date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents created_by As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupddate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents lstupdby As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents price As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
