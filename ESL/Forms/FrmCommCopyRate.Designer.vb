<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommCopyRate
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.dtgCopyRate = New System.Windows.Forms.DataGridView
        Me.Edit = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.txmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.accno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fee_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fee_nature_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.rate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.aeno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cboSrchMonth = New ESL.myComboBox(Me.components)
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboSrchYear = New ESL.myComboBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtSrchAe = New ESL.myTextbox
        Me.txtSrchAcc = New ESL.myTextbox
        Me.Label7 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbSrchAll = New ESL.myRadioButton(Me.components)
        Me.rbSrchInt = New ESL.myRadioButton(Me.components)
        Me.rbSrchNor = New ESL.myRadioButton(Me.components)
        Me.btnImport = New ESL.myButton(Me.components)
        Me.cbAll = New ESL.myCheckBox(Me.components)
        Me.dtgAEList = New System.Windows.Forms.DataGridView
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        CType(Me.dtgCopyRate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dtgAEList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(780, 301)
        Me.btnCancel.TabIndex = 11
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(728, 301)
        Me.btnSave.TabIndex = 10
        Me.btnSave.Visible = True
        '
        'dtgCopyRate
        '
        Me.dtgCopyRate.AllowUserToAddRows = False
        Me.dtgCopyRate.AllowUserToDeleteRows = False
        Me.dtgCopyRate.AllowUserToResizeRows = False
        Me.dtgCopyRate.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgCopyRate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgCopyRate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Edit, Me.txmonth, Me.accno, Me.fee_name, Me.fee_nature_name, Me.rate, Me.aeno})
        Me.dtgCopyRate.Location = New System.Drawing.Point(172, 56)
        Me.dtgCopyRate.MultiSelect = False
        Me.dtgCopyRate.Name = "dtgCopyRate"
        Me.dtgCopyRate.RowHeadersVisible = False
        Me.dtgCopyRate.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.dtgCopyRate.RowTemplate.Height = 24
        Me.dtgCopyRate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgCopyRate.Size = New System.Drawing.Size(658, 238)
        Me.dtgCopyRate.TabIndex = 7
        '
        'Edit
        '
        Me.Edit.FalseValue = "False"
        Me.Edit.HeaderText = ""
        Me.Edit.Name = "Edit"
        Me.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Edit.TrueValue = "True"
        Me.Edit.Width = 40
        '
        'txmonth
        '
        Me.txmonth.DataPropertyName = "txmonth"
        Me.txmonth.HeaderText = "txmonth"
        Me.txmonth.Name = "txmonth"
        Me.txmonth.Width = 60
        '
        'accno
        '
        Me.accno.DataPropertyName = "accno"
        Me.accno.HeaderText = "A/C no."
        Me.accno.Name = "accno"
        Me.accno.Width = 80
        '
        'fee_name
        '
        Me.fee_name.DataPropertyName = "fee_name"
        Me.fee_name.HeaderText = "Fee Name"
        Me.fee_name.Name = "fee_name"
        Me.fee_name.Width = 260
        '
        'fee_nature_name
        '
        Me.fee_nature_name.DataPropertyName = "fee_nature_name"
        Me.fee_nature_name.HeaderText = "Fee Nature Name"
        Me.fee_nature_name.Name = "fee_nature_name"
        Me.fee_nature_name.Width = 115
        '
        'rate
        '
        Me.rate.DataPropertyName = "rate"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        Me.rate.DefaultCellStyle = DataGridViewCellStyle3
        Me.rate.HeaderText = "Rate"
        Me.rate.Name = "rate"
        Me.rate.Width = 70
        '
        'aeno
        '
        Me.aeno.DataPropertyName = "aeno"
        Me.aeno.HeaderText = "AE"
        Me.aeno.Name = "aeno"
        Me.aeno.Visible = False
        Me.aeno.Width = 80
        '
        'cboSrchMonth
        '
        Me.cboSrchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSrchMonth.FormattingEnabled = True
        Me.cboSrchMonth.Location = New System.Drawing.Point(163, 5)
        Me.cboSrchMonth.Name = "cboSrchMonth"
        Me.cboSrchMonth.Size = New System.Drawing.Size(47, 23)
        Me.cboSrchMonth.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(114, 9)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(40, 15)
        Me.Label13.TabIndex = 157
        Me.Label13.Text = "Month"
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(748, 2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(82, 24)
        Me.btnSearch.TabIndex = 5
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(2, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(32, 15)
        Me.Label3.TabIndex = 155
        Me.Label3.Text = "Year"
        '
        'cboSrchYear
        '
        Me.cboSrchYear.FormattingEnabled = True
        Me.cboSrchYear.Location = New System.Drawing.Point(40, 6)
        Me.cboSrchYear.Name = "cboSrchYear"
        Me.cboSrchYear.Size = New System.Drawing.Size(68, 23)
        Me.cboSrchYear.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(352, 7)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(22, 15)
        Me.Label4.TabIndex = 161
        Me.Label4.Text = "AE"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(211, 9)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(50, 15)
        Me.Label5.TabIndex = 160
        Me.Label5.Text = "Account"
        '
        'txtSrchAe
        '
        Me.txtSrchAe.Location = New System.Drawing.Point(380, 6)
        Me.txtSrchAe.Name = "txtSrchAe"
        Me.txtSrchAe.Size = New System.Drawing.Size(79, 21)
        Me.txtSrchAe.TabIndex = 3
        '
        'txtSrchAcc
        '
        Me.txtSrchAcc.Location = New System.Drawing.Point(267, 5)
        Me.txtSrchAcc.Name = "txtSrchAcc"
        Me.txtSrchAcc.Size = New System.Drawing.Size(79, 21)
        Me.txtSrchAcc.TabIndex = 2
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(463, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 15)
        Me.Label7.TabIndex = 165
        Me.Label7.Text = "Trade Type"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbSrchAll)
        Me.GroupBox1.Controls.Add(Me.rbSrchInt)
        Me.GroupBox1.Controls.Add(Me.rbSrchNor)
        Me.GroupBox1.Location = New System.Drawing.Point(531, -4)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(198, 32)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'rbSrchAll
        '
        Me.rbSrchAll.AutoSize = True
        Me.rbSrchAll.Checked = True
        Me.rbSrchAll.Location = New System.Drawing.Point(152, 11)
        Me.rbSrchAll.Name = "rbSrchAll"
        Me.rbSrchAll.Size = New System.Drawing.Size(38, 19)
        Me.rbSrchAll.TabIndex = 2
        Me.rbSrchAll.TabStop = True
        Me.rbSrchAll.Text = "All"
        Me.rbSrchAll.UseVisualStyleBackColor = True
        '
        'rbSrchInt
        '
        Me.rbSrchInt.AutoSize = True
        Me.rbSrchInt.Location = New System.Drawing.Point(80, 11)
        Me.rbSrchInt.Name = "rbSrchInt"
        Me.rbSrchInt.Size = New System.Drawing.Size(66, 19)
        Me.rbSrchInt.TabIndex = 1
        Me.rbSrchInt.Text = "Internet"
        Me.rbSrchInt.UseVisualStyleBackColor = True
        '
        'rbSrchNor
        '
        Me.rbSrchNor.AutoSize = True
        Me.rbSrchNor.Location = New System.Drawing.Point(6, 11)
        Me.rbSrchNor.Name = "rbSrchNor"
        Me.rbSrchNor.Size = New System.Drawing.Size(66, 19)
        Me.rbSrchNor.TabIndex = 0
        Me.rbSrchNor.Text = "Normal"
        Me.rbSrchNor.UseVisualStyleBackColor = True
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(672, 300)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(50, 55)
        Me.btnImport.TabIndex = 9
        Me.btnImport.Text = "Import"
        Me.btnImport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnImport.UseVisualStyleBackColor = True
        '
        'cbAll
        '
        Me.cbAll.AutoSize = True
        Me.cbAll.Location = New System.Drawing.Point(735, 35)
        Me.cbAll.Name = "cbAll"
        Me.cbAll.Size = New System.Drawing.Size(76, 19)
        Me.cbAll.TabIndex = 8
        Me.cbAll.Text = "Select All"
        Me.cbAll.UseVisualStyleBackColor = True
        '
        'dtgAEList
        '
        Me.dtgAEList.AllowUserToAddRows = False
        Me.dtgAEList.AllowUserToDeleteRows = False
        Me.dtgAEList.AllowUserToResizeRows = False
        Me.dtgAEList.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgAEList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dtgAEList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ae_no, Me.ae_name_s})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dtgAEList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dtgAEList.Location = New System.Drawing.Point(5, 56)
        Me.dtgAEList.MultiSelect = False
        Me.dtgAEList.Name = "dtgAEList"
        Me.dtgAEList.ReadOnly = True
        Me.dtgAEList.RowHeadersVisible = False
        Me.dtgAEList.RowTemplate.Height = 24
        Me.dtgAEList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgAEList.Size = New System.Drawing.Size(161, 238)
        Me.dtgAEList.TabIndex = 6
        '
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "AE No"
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        Me.ae_no.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.ae_no.Width = 75
        '
        'ae_name_s
        '
        Me.ae_name_s.DataPropertyName = "ae_name_s"
        Me.ae_name_s.HeaderText = "AE Name"
        Me.ae_name_s.Name = "ae_name_s"
        Me.ae_name_s.ReadOnly = True
        Me.ae_name_s.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'FrmCommCopyRate
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(837, 363)
        Me.Controls.Add(Me.dtgAEList)
        Me.Controls.Add(Me.cbAll)
        Me.Controls.Add(Me.dtgCopyRate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtSrchAe)
        Me.Controls.Add(Me.txtSrchAcc)
        Me.Controls.Add(Me.cboSrchMonth)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboSrchYear)
        Me.Controls.Add(Me.btnSearch)
        Me.KeyPreview = True
        Me.Name = "FrmCommCopyRate"
        Me.Text = "Commission Copy Rate"
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.cboSrchYear, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.Label13, 0)
        Me.Controls.SetChildIndex(Me.cboSrchMonth, 0)
        Me.Controls.SetChildIndex(Me.txtSrchAcc, 0)
        Me.Controls.SetChildIndex(Me.txtSrchAe, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.btnImport, 0)
        Me.Controls.SetChildIndex(Me.GroupBox1, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.dtgCopyRate, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.cbAll, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.dtgAEList, 0)
        CType(Me.dtgCopyRate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dtgAEList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgCopyRate As System.Windows.Forms.DataGridView
    Friend WithEvents cboSrchMonth As ESL.myComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSrchYear As ESL.myComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtSrchAe As ESL.myTextbox
    Friend WithEvents txtSrchAcc As ESL.myTextbox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSrchAll As ESL.myRadioButton
    Friend WithEvents rbSrchInt As ESL.myRadioButton
    Friend WithEvents rbSrchNor As ESL.myRadioButton
    Friend WithEvents btnImport As ESL.myButton
    Friend WithEvents cbAll As ESL.myCheckBox
    Friend WithEvents dtgAEList As System.Windows.Forms.DataGridView
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Edit As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents txmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents accno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fee_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fee_nature_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rate As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aeno As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
