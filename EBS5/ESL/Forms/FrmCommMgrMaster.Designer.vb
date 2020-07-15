<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCommMgrMaster
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
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtMgrNo = New ESL.myTextbox
        Me.txtMgrGrp = New ESL.myTextbox
        Me.cbStandard = New ESL.myCheckBox(Me.components)
        Me.txtMonth = New ESL.myTextbox
        Me.Label6 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.rbSec = New ESL.myRadioButton(Me.components)
        Me.rbFut = New ESL.myRadioButton(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbRebate = New ESL.myRadioButton(Me.components)
        Me.rbTurnover = New ESL.myRadioButton(Me.components)
        Me.rbBrokerage = New ESL.myRadioButton(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.cboSearchYear = New ESL.myComboBox(Me.components)
        Me.Label4 = New System.Windows.Forms.Label
        Me.cboSearchMonth = New ESL.myComboBox(Me.components)
        Me.Label3 = New System.Windows.Forms.Label
        Me.dgvDetail = New System.Windows.Forms.DataGridView
        Me.txmonth = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turn_brok_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.turn_brok_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.isDefault = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.dgvManList = New System.Windows.Forms.DataGridView
        Me.man_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.man_grp = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvManList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(596, 357)
        Me.btnCancel.TabIndex = 5
        '
        'btnSave
        '
        Me.btnSave.Enabled = False
        Me.btnSave.Location = New System.Drawing.Point(540, 357)
        Me.btnSave.TabIndex = 4
        Me.btnSave.Visible = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.txtMgrNo)
        Me.Panel1.Controls.Add(Me.txtMgrGrp)
        Me.Panel1.Controls.Add(Me.cbStandard)
        Me.Panel1.Controls.Add(Me.txtMonth)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.cboSearchYear)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.cboSearchMonth)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.dgvDetail)
        Me.Panel1.Controls.Add(Me.dgvManList)
        Me.Panel1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(634, 338)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(187, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 14)
        Me.Label2.TabIndex = 118
        Me.Label2.Text = "Manager Grp."
        '
        'txtMgrNo
        '
        Me.txtMgrNo.Enabled = False
        Me.txtMgrNo.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMgrNo.Location = New System.Drawing.Point(84, 263)
        Me.txtMgrNo.MaxLength = 20
        Me.txtMgrNo.Name = "txtMgrNo"
        Me.txtMgrNo.Size = New System.Drawing.Size(97, 20)
        Me.txtMgrNo.TabIndex = 2
        '
        'txtMgrGrp
        '
        Me.txtMgrGrp.Enabled = False
        Me.txtMgrGrp.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMgrGrp.Location = New System.Drawing.Point(266, 263)
        Me.txtMgrGrp.MaxLength = 20
        Me.txtMgrGrp.Name = "txtMgrGrp"
        Me.txtMgrGrp.Size = New System.Drawing.Size(97, 20)
        Me.txtMgrGrp.TabIndex = 3
        '
        'cbStandard
        '
        Me.cbStandard.AutoSize = True
        Me.cbStandard.Enabled = False
        Me.cbStandard.Location = New System.Drawing.Point(190, 302)
        Me.cbStandard.Name = "cbStandard"
        Me.cbStandard.Size = New System.Drawing.Size(70, 18)
        Me.cbStandard.TabIndex = 6
        Me.cbStandard.Text = "Standard"
        Me.cbStandard.UseVisualStyleBackColor = True
        '
        'txtMonth
        '
        Me.txtMonth.Enabled = False
        Me.txtMonth.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(411, 263)
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(97, 20)
        Me.txtMonth.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(369, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(36, 14)
        Me.Label6.TabIndex = 114
        Me.Label6.Text = "Month"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.rbSec)
        Me.GroupBox2.Controls.Add(Me.rbFut)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 289)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(163, 35)
        Me.GroupBox2.TabIndex = 5
        Me.GroupBox2.TabStop = False
        '
        'rbSec
        '
        Me.rbSec.AutoSize = True
        Me.rbSec.Checked = True
        Me.rbSec.Enabled = False
        Me.rbSec.Location = New System.Drawing.Point(6, 13)
        Me.rbSec.Name = "rbSec"
        Me.rbSec.Size = New System.Drawing.Size(73, 18)
        Me.rbSec.TabIndex = 0
        Me.rbSec.TabStop = True
        Me.rbSec.Text = "Securities"
        Me.rbSec.UseVisualStyleBackColor = True
        '
        'rbFut
        '
        Me.rbFut.AutoSize = True
        Me.rbFut.Enabled = False
        Me.rbFut.Location = New System.Drawing.Point(81, 13)
        Me.rbFut.Name = "rbFut"
        Me.rbFut.Size = New System.Drawing.Size(62, 18)
        Me.rbFut.TabIndex = 1
        Me.rbFut.Text = "Futures"
        Me.rbFut.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbRebate)
        Me.GroupBox1.Controls.Add(Me.rbTurnover)
        Me.GroupBox1.Controls.Add(Me.rbBrokerage)
        Me.GroupBox1.Location = New System.Drawing.Point(266, 289)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(242, 35)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'rbRebate
        '
        Me.rbRebate.AutoSize = True
        Me.rbRebate.Enabled = False
        Me.rbRebate.Location = New System.Drawing.Point(162, 13)
        Me.rbRebate.Name = "rbRebate"
        Me.rbRebate.Size = New System.Drawing.Size(59, 18)
        Me.rbRebate.TabIndex = 2
        Me.rbRebate.TabStop = True
        Me.rbRebate.Text = "Rebate"
        Me.rbRebate.UseVisualStyleBackColor = True
        '
        'rbTurnover
        '
        Me.rbTurnover.AutoSize = True
        Me.rbTurnover.Enabled = False
        Me.rbTurnover.Location = New System.Drawing.Point(6, 13)
        Me.rbTurnover.Name = "rbTurnover"
        Me.rbTurnover.Size = New System.Drawing.Size(69, 18)
        Me.rbTurnover.TabIndex = 0
        Me.rbTurnover.TabStop = True
        Me.rbTurnover.Text = "Turnover"
        Me.rbTurnover.UseVisualStyleBackColor = True
        '
        'rbBrokerage
        '
        Me.rbBrokerage.AutoSize = True
        Me.rbBrokerage.Enabled = False
        Me.rbBrokerage.Location = New System.Drawing.Point(81, 13)
        Me.rbBrokerage.Name = "rbBrokerage"
        Me.rbBrokerage.Size = New System.Drawing.Size(75, 18)
        Me.rbBrokerage.TabIndex = 1
        Me.rbBrokerage.TabStop = True
        Me.rbBrokerage.Text = "Brokerage"
        Me.rbBrokerage.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(8, 266)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(68, 14)
        Me.Label1.TabIndex = 104
        Me.Label1.Text = "Manager No."
        '
        'cboSearchYear
        '
        Me.cboSearchYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchYear.Enabled = False
        Me.cboSearchYear.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchYear.FormattingEnabled = True
        Me.cboSearchYear.Location = New System.Drawing.Point(45, 12)
        Me.cboSearchYear.Name = "cboSearchYear"
        Me.cboSearchYear.Size = New System.Drawing.Size(72, 19)
        Me.cboSearchYear.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(123, 14)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 14)
        Me.Label4.TabIndex = 87
        Me.Label4.Text = "Month"
        '
        'cboSearchMonth
        '
        Me.cboSearchMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSearchMonth.Enabled = False
        Me.cboSearchMonth.Font = New System.Drawing.Font("PMingLiU", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.cboSearchMonth.FormattingEnabled = True
        Me.cboSearchMonth.Location = New System.Drawing.Point(165, 12)
        Me.cboSearchMonth.Name = "cboSearchMonth"
        Me.cboSearchMonth.Size = New System.Drawing.Size(53, 19)
        Me.cboSearchMonth.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 14)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 14)
        Me.Label3.TabIndex = 86
        Me.Label3.Text = "Year"
        '
        'dgvDetail
        '
        Me.dgvDetail.AllowUserToAddRows = False
        Me.dgvDetail.AllowUserToDeleteRows = False
        Me.dgvDetail.AllowUserToResizeRows = False
        Me.dgvDetail.BackgroundColor = System.Drawing.Color.Linen
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetail.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvDetail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvDetail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.txmonth, Me.turn_brok_s, Me.turn_brok_f, Me.isDefault})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvDetail.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvDetail.Location = New System.Drawing.Point(243, 40)
        Me.dgvDetail.MultiSelect = False
        Me.dgvDetail.Name = "dgvDetail"
        Me.dgvDetail.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvDetail.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.dgvDetail.RowHeadersVisible = False
        Me.dgvDetail.RowTemplate.Height = 24
        Me.dgvDetail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvDetail.Size = New System.Drawing.Size(379, 217)
        Me.dgvDetail.TabIndex = 3
        '
        'txmonth
        '
        Me.txmonth.DataPropertyName = "txmonth"
        Me.txmonth.HeaderText = "Month"
        Me.txmonth.Name = "txmonth"
        Me.txmonth.ReadOnly = True
        '
        'turn_brok_s
        '
        Me.turn_brok_s.DataPropertyName = "turn_brok_s"
        Me.turn_brok_s.HeaderText = "Turnover/Brokerage (Securities)"
        Me.turn_brok_s.Name = "turn_brok_s"
        Me.turn_brok_s.ReadOnly = True
        '
        'turn_brok_f
        '
        Me.turn_brok_f.DataPropertyName = "turn_brok_f"
        Me.turn_brok_f.HeaderText = "Turnover/Brokerage (Futures)"
        Me.turn_brok_f.Name = "turn_brok_f"
        Me.turn_brok_f.ReadOnly = True
        '
        'isDefault
        '
        Me.isDefault.DataPropertyName = "isDefault"
        Me.isDefault.HeaderText = "Standard"
        Me.isDefault.Name = "isDefault"
        Me.isDefault.ReadOnly = True
        Me.isDefault.Width = 60
        '
        'dgvManList
        '
        Me.dgvManList.AllowUserToAddRows = False
        Me.dgvManList.AllowUserToDeleteRows = False
        Me.dgvManList.AllowUserToResizeRows = False
        Me.dgvManList.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvManList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvManList.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.man_no, Me.man_grp})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvManList.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvManList.Location = New System.Drawing.Point(11, 40)
        Me.dgvManList.MultiSelect = False
        Me.dgvManList.Name = "dgvManList"
        Me.dgvManList.ReadOnly = True
        Me.dgvManList.RowHeadersVisible = False
        Me.dgvManList.RowTemplate.Height = 24
        Me.dgvManList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvManList.Size = New System.Drawing.Size(219, 217)
        Me.dgvManList.TabIndex = 2
        '
        'man_no
        '
        Me.man_no.DataPropertyName = "man_no"
        Me.man_no.HeaderText = "Manager No."
        Me.man_no.Name = "man_no"
        Me.man_no.ReadOnly = True
        '
        'man_grp
        '
        Me.man_grp.DataPropertyName = "man_grp"
        Me.man_grp.HeaderText = "Manager Group"
        Me.man_grp.Name = "man_grp"
        Me.man_grp.ReadOnly = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(484, 357)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(372, 357)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 1
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(428, 357)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 2
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'FrmCommMgrMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(660, 435)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.Panel1)
        Me.KeyPreview = True
        Me.Name = "FrmCommMgrMaster"
        Me.Text = "Manager Master"
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.Panel1, 0)
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvManList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboSearchYear As ESL.myComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cboSearchMonth As ESL.myComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dgvDetail As System.Windows.Forms.DataGridView
    Friend WithEvents dgvManList As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents rbSec As ESL.myRadioButton
    Friend WithEvents rbFut As ESL.myRadioButton
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents rbTurnover As ESL.myRadioButton
    Friend WithEvents rbBrokerage As ESL.myRadioButton
    Friend WithEvents txtMonth As ESL.myTextbox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents cbStandard As ESL.myCheckBox
    Friend WithEvents man_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents man_grp As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtMgrNo As ESL.myTextbox
    Friend WithEvents txtMgrGrp As ESL.myTextbox
    Friend WithEvents txmonth As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turn_brok_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents turn_brok_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents isDefault As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents rbRebate As ESL.myRadioButton

End Class
