<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommGroupAE
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
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtSrchAE = New ESL.myTextbox
        Me.btnSearch = New ESL.myButton(Me.components)
        Me.txtAEName = New ESL.myTextbox
        Me.cbSpecial = New ESL.myCheckBox(Me.components)
        Me.cbConsolid = New ESL.myCheckBox(Me.components)
        Me.txtMonth = New ESL.myTextbox
        Me.cboSearchYear = New ESL.myComboBox(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.dgvGroup = New System.Windows.Forms.DataGridView
        Me.gpid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.txmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.group_ae = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.ae_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.calSpecial = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isConsolid = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboSearchMonth = New ESL.myComboBox(Me.components)
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboAENo = New ESL.myComboBox(Me.components)
        Me.txtGroup = New ESL.myTextbox
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtSrchGroup = New ESL.myTextbox
        CType(Me.dgvGroup, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(558, 387)
        Me.btnCancel.TabIndex = 13
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(502, 386)
        Me.btnSave.TabIndex = 12
        Me.btnSave.Visible = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(373, 22)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(37, 14)
        Me.Label18.TabIndex = 160
        Me.Label18.Text = "Group"
        '
        'txtSrchAE
        '
        Me.txtSrchAE.Location = New System.Drawing.Point(267, 19)
        Me.txtSrchAE.Name = "txtSrchAE"
        Me.txtSrchAE.Size = New System.Drawing.Size(100, 21)
        Me.txtSrchAE.TabIndex = 2
        '
        'btnSearch
        '
        Me.btnSearch.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.Location = New System.Drawing.Point(525, 18)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(83, 23)
        Me.btnSearch.TabIndex = 4
        Me.btnSearch.Text = "Search"
        Me.btnSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'txtAEName
        '
        Me.txtAEName.Enabled = False
        Me.txtAEName.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAEName.Location = New System.Drawing.Point(182, 360)
        Me.txtAEName.Name = "txtAEName"
        Me.txtAEName.Size = New System.Drawing.Size(249, 20)
        Me.txtAEName.TabIndex = 134
        '
        'cbSpecial
        '
        Me.cbSpecial.AutoSize = True
        Me.cbSpecial.Enabled = False
        Me.cbSpecial.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbSpecial.Location = New System.Drawing.Point(182, 387)
        Me.cbSpecial.Name = "cbSpecial"
        Me.cbSpecial.Size = New System.Drawing.Size(125, 18)
        Me.cbSpecial.TabIndex = 7
        Me.cbSpecial.Text = "Use Special Scheme"
        Me.cbSpecial.UseVisualStyleBackColor = True
        '
        'cbConsolid
        '
        Me.cbConsolid.AutoSize = True
        Me.cbConsolid.Enabled = False
        Me.cbConsolid.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbConsolid.Location = New System.Drawing.Point(12, 412)
        Me.cbConsolid.Name = "cbConsolid"
        Me.cbConsolid.Size = New System.Drawing.Size(174, 18)
        Me.cbConsolid.TabIndex = 8
        Me.cbConsolid.Text = "Consolidate (Normal + Internet)"
        Me.cbConsolid.UseVisualStyleBackColor = True
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(486, 360)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(122, 20)
        Me.txtMonth.TabIndex = 135
        '
        'cboSearchYear
        '
        Me.cboSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchYear.Enabled = False
        Me.cboSearchYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchYear.FormattingEnabled = True
        Me.cboSearchYear.Location = New System.Drawing.Point(46, 21)
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(72, 19)
        Me.cboSearchYear.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(9, 362)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 14)
        Me.Label1.TabIndex = 152
        Me.Label1.Text = "AE No."
        '
        'dgvGroup
        '
        Me.dgvGroup.AllowUserToAddRows = False
        Me.dgvGroup.AllowUserToDeleteRows = False
        Me.dgvGroup.AllowUserToResizeRows = False
        Me.dgvGroup.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGroup.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvGroup.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.gpid, Me.txmonth, Me.group_ae, Me.ae_no, Me.calSpecial, Me.isConsolid})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvGroup.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvGroup.Location = New System.Drawing.Point(11, 46)
        Me.dgvGroup.MultiSelect = False
        Me.dgvGroup.Name = "dgvGroup"
        Me.dgvGroup.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvGroup.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvGroup.RowHeadersVisible = False
        Me.dgvGroup.RowTemplate.Height = 24
        Me.dgvGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvGroup.Size = New System.Drawing.Size(597, 306)
        Me.dgvGroup.TabIndex = 132
        '
        'gpid
        '
        Me.gpid.DataPropertyName = "gpid"
        Me.gpid.HeaderText = "gpid"
        Me.gpid.Name = "gpid"
        Me.gpid.ReadOnly = True
        Me.gpid.Visible = False
        '
        'txmonth
        '
        Me.txmonth.DataPropertyName = "txmonth"
        Me.txmonth.HeaderText = "Month"
        Me.txmonth.Name = "txmonth"
        Me.txmonth.ReadOnly = True
        Me.txmonth.Width = 60
        '
        'group_ae
        '
        Me.group_ae.DataPropertyName = "group_ae"
        Me.group_ae.HeaderText = "Group"
        Me.group_ae.Name = "group_ae"
        Me.group_ae.ReadOnly = True
        '
        'ae_no
        '
        Me.ae_no.DataPropertyName = "ae_no"
        Me.ae_no.HeaderText = "AE"
        Me.ae_no.Name = "ae_no"
        Me.ae_no.ReadOnly = True
        '
        'calSpecial
        '
        Me.calSpecial.DataPropertyName = "calSpecial"
        Me.calSpecial.HeaderText = "Use Special Scheme"
        Me.calSpecial.Name = "calSpecial"
        Me.calSpecial.ReadOnly = True
        '
        'isConsolid
        '
        Me.isConsolid.DataPropertyName = "isConsolid"
        Me.isConsolid.HeaderText = "Consolidate"
        Me.isConsolid.Name = "isConsolid"
        Me.isConsolid.ReadOnly = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(9, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Year"
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchMonth.Enabled = False
        Me.cboSearchMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchMonth.FormattingEnabled = True
        Me.cboSearchMonth.Location = New System.Drawing.Point(166, 21)
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(53, 19)
        Me.cboSearchMonth.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(440, 362)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 14)
        Me.Label2.TabIndex = 153
        Me.Label2.Text = "Month"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(124, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Month"
        '
        'cboAENo
        '
        Me.cboAENo.Enabled = False
        Me.cboAENo.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboAENo.FormattingEnabled = True
        Me.cboAENo.Location = New System.Drawing.Point(54, 361)
        Me.cboAENo.Name = "cboAENo"
        Me.cboAENo.Size = New System.Drawing.Size(122, 19)
        Me.cboAENo.TabIndex = 5
        '
        'txtGroup
        '
        Me.txtGroup.Enabled = False
        Me.txtGroup.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtGroup.Location = New System.Drawing.Point(54, 386)
        Me.txtGroup.Name = "txtGroup"
        Me.txtGroup.Size = New System.Drawing.Size(122, 20)
        Me.txtGroup.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 388)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(37, 14)
        Me.Label5.TabIndex = 162
        Me.Label5.Text = "Group"
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(390, 387)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 10
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(334, 387)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 9
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(446, 386)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 11
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(224, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 14)
        Me.Label6.TabIndex = 167
        Me.Label6.Text = "AE no."
        '
        'txtSrchGroup
        '
        Me.txtSrchGroup.Location = New System.Drawing.Point(416, 19)
        Me.txtSrchGroup.Name = "txtSrchGroup"
        Me.txtSrchGroup.Size = New System.Drawing.Size(100, 21)
        Me.txtSrchGroup.TabIndex = 3
        '
        'FrmCommGroupAE
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(622, 462)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtSrchGroup)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.txtGroup)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.txtSrchAE)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtAEName)
        Me.Controls.Add(Me.cbSpecial)
        Me.Controls.Add(Me.cbConsolid)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.cboSearchYear)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dgvGroup)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboSearchMonth)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboAENo)
        Me.KeyPreview = True
        Me.Name = "FrmCommGroupAE"
        Me.Text = "Group AE"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.cboAENo, 0)
        Me.Controls.SetChildIndex(Me.Label4, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        Me.Controls.SetChildIndex(Me.cboSearchMonth, 0)
        Me.Controls.SetChildIndex(Me.Label3, 0)
        Me.Controls.SetChildIndex(Me.dgvGroup, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.cboSearchYear, 0)
        Me.Controls.SetChildIndex(Me.txtMonth, 0)
        Me.Controls.SetChildIndex(Me.cbConsolid, 0)
        Me.Controls.SetChildIndex(Me.cbSpecial, 0)
        Me.Controls.SetChildIndex(Me.txtAEName, 0)
        Me.Controls.SetChildIndex(Me.btnSearch, 0)
        Me.Controls.SetChildIndex(Me.txtSrchAE, 0)
        Me.Controls.SetChildIndex(Me.Label18, 0)
        Me.Controls.SetChildIndex(Me.Label5, 0)
        Me.Controls.SetChildIndex(Me.txtGroup, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.txtSrchGroup, 0)
        Me.Controls.SetChildIndex(Me.Label6, 0)
        CType(Me.dgvGroup, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtSrchAE As ESL.myTextbox
    Friend WithEvents btnSearch As ESL.myButton
    Friend WithEvents txtAEName As ESL.myTextbox
    Friend WithEvents cbSpecial As ESL.myCheckBox
    Friend WithEvents cbConsolid As ESL.myCheckBox
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents cboSearchYear As ESL.myComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dgvGroup As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSearchMonth As ESL.myComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboAENo As ESL.myComboBox
    Friend WithEvents txtGroup As ESL.myTextbox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtSrchGroup As ESL.myTextbox
    Friend WithEvents gpid As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents group_ae As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ae_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents calSpecial As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isConsolid As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
