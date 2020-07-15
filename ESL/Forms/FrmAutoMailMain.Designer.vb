<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAutoMailMain
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
        Me.dtgMail = New System.Windows.Forms.DataGridView
        Me.record_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.branch_name = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.branch_manager = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.aeno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.attachment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label7 = New System.Windows.Forms.Label
        Me.tcMail = New System.Windows.Forms.TabControl
        Me.tpMain = New System.Windows.Forms.TabPage
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.tpRecord = New System.Windows.Forms.TabPage
        Me.lblReportPath = New System.Windows.Forms.Label
        Me.txtattach = New ESL.myTextbox
        Me.txtemail = New ESL.myTextbox
        Me.txtaeno = New ESL.myTextbox
        Me.txt_brh_mgr = New ESL.myTextbox
        Me.lblid = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txt_brh_name = New ESL.myTextbox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        CType(Me.dtgMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcMail.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.tpRecord.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(557, 306)
        Me.btnCancel.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(506, 306)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Visible = True
        '
        'dtgMail
        '
        Me.dtgMail.AllowUserToAddRows = False
        Me.dtgMail.AllowUserToDeleteRows = False
        Me.dtgMail.AllowUserToResizeRows = False
        Me.dtgMail.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgMail.ColumnHeadersHeight = 20
        Me.dtgMail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.record_no, Me.branch_name, Me.branch_manager, Me.aeno, Me.email, Me.attachment})
        Me.dtgMail.GridColor = System.Drawing.Color.Linen
        Me.dtgMail.Location = New System.Drawing.Point(26, 22)
        Me.dtgMail.MultiSelect = False
        Me.dtgMail.Name = "dtgMail"
        Me.dtgMail.ReadOnly = True
        Me.dtgMail.RowHeadersVisible = False
        Me.dtgMail.RowTemplate.Height = 24
        Me.dtgMail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgMail.Size = New System.Drawing.Size(543, 216)
        Me.dtgMail.TabIndex = 1
        '
        'record_no
        '
        Me.record_no.DataPropertyName = "record_no"
        Me.record_no.HeaderText = "record_no"
        Me.record_no.Name = "record_no"
        Me.record_no.ReadOnly = True
        Me.record_no.Visible = False
        '
        'branch_name
        '
        Me.branch_name.DataPropertyName = "branch_name"
        Me.branch_name.HeaderText = "Branch Name"
        Me.branch_name.Name = "branch_name"
        Me.branch_name.ReadOnly = True
        '
        'branch_manager
        '
        Me.branch_manager.DataPropertyName = "branch_manager"
        Me.branch_manager.HeaderText = "Branch Manager"
        Me.branch_manager.Name = "branch_manager"
        Me.branch_manager.ReadOnly = True
        '
        'aeno
        '
        Me.aeno.DataPropertyName = "aeno"
        Me.aeno.HeaderText = "AE No"
        Me.aeno.Name = "aeno"
        Me.aeno.ReadOnly = True
        Me.aeno.Width = 50
        '
        'email
        '
        Me.email.DataPropertyName = "email"
        Me.email.HeaderText = "Email Address"
        Me.email.Name = "email"
        Me.email.ReadOnly = True
        Me.email.Width = 220
        '
        'attachment
        '
        Me.attachment.DataPropertyName = "attachment"
        Me.attachment.HeaderText = "Attachment Path"
        Me.attachment.Name = "attachment"
        Me.attachment.ReadOnly = True
        Me.attachment.Width = 280
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(192, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(292, 22)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Auto Mail Report Maintainence"
        '
        'tcMail
        '
        Me.tcMail.Controls.Add(Me.tpMain)
        Me.tcMail.Controls.Add(Me.tpRecord)
        Me.tcMail.Location = New System.Drawing.Point(12, 29)
        Me.tcMail.Name = "tcMail"
        Me.tcMail.SelectedIndex = 0
        Me.tcMail.Size = New System.Drawing.Size(608, 347)
        Me.tcMail.TabIndex = 0
        '
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.btnDelete)
        Me.tpMain.Controls.Add(Me.btnAdd)
        Me.tpMain.Controls.Add(Me.dtgMail)
        Me.tpMain.Controls.Add(Me.btnEdit)
        Me.tpMain.Location = New System.Drawing.Point(4, 24)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(600, 319)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(434, 253)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 2
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(332, 253)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 0
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(383, 253)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'tpRecord
        '
        Me.tpRecord.Controls.Add(Me.lblReportPath)
        Me.tpRecord.Controls.Add(Me.txtattach)
        Me.tpRecord.Controls.Add(Me.txtemail)
        Me.tpRecord.Controls.Add(Me.txtaeno)
        Me.tpRecord.Controls.Add(Me.txt_brh_mgr)
        Me.tpRecord.Controls.Add(Me.lblid)
        Me.tpRecord.Controls.Add(Me.Label1)
        Me.tpRecord.Controls.Add(Me.txt_brh_name)
        Me.tpRecord.Controls.Add(Me.Label8)
        Me.tpRecord.Controls.Add(Me.Label6)
        Me.tpRecord.Controls.Add(Me.Label5)
        Me.tpRecord.Controls.Add(Me.Label4)
        Me.tpRecord.Controls.Add(Me.Label3)
        Me.tpRecord.Location = New System.Drawing.Point(4, 24)
        Me.tpRecord.Name = "tpRecord"
        Me.tpRecord.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRecord.Size = New System.Drawing.Size(600, 319)
        Me.tpRecord.TabIndex = 1
        Me.tpRecord.Text = "Modification"
        Me.tpRecord.UseVisualStyleBackColor = True
        '
        'lblReportPath
        '
        Me.lblReportPath.AutoSize = True
        Me.lblReportPath.Location = New System.Drawing.Point(148, 196)
        Me.lblReportPath.Name = "lblReportPath"
        Me.lblReportPath.Size = New System.Drawing.Size(161, 15)
        Me.lblReportPath.TabIndex = 12
        Me.lblReportPath.Text = "X:\STOCK_EXPORT\yyMMdd"
        '
        'txtattach
        '
        Me.txtattach.Location = New System.Drawing.Point(309, 193)
        Me.txtattach.MaxLength = 100
        Me.txtattach.Name = "txtattach"
        Me.txtattach.Size = New System.Drawing.Size(250, 21)
        Me.txtattach.TabIndex = 4
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(151, 151)
        Me.txtemail.MaxLength = 100
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(408, 21)
        Me.txtemail.TabIndex = 3
        '
        'txtaeno
        '
        Me.txtaeno.Location = New System.Drawing.Point(151, 108)
        Me.txtaeno.MaxLength = 20
        Me.txtaeno.Name = "txtaeno"
        Me.txtaeno.Size = New System.Drawing.Size(205, 21)
        Me.txtaeno.TabIndex = 2
        '
        'txt_brh_mgr
        '
        Me.txt_brh_mgr.Location = New System.Drawing.Point(151, 67)
        Me.txt_brh_mgr.MaxLength = 50
        Me.txt_brh_mgr.Name = "txt_brh_mgr"
        Me.txt_brh_mgr.Size = New System.Drawing.Size(205, 21)
        Me.txt_brh_mgr.TabIndex = 1
        '
        'lblid
        '
        Me.lblid.AutoSize = True
        Me.lblid.Location = New System.Drawing.Point(552, 3)
        Me.lblid.Name = "lblid"
        Me.lblid.Size = New System.Drawing.Size(45, 15)
        Me.lblid.TabIndex = 1
        Me.lblid.Text = "Label2"
        Me.lblid.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(527, 3)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(19, 15)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "ID"
        Me.Label1.Visible = False
        '
        'txt_brh_name
        '
        Me.txt_brh_name.Location = New System.Drawing.Point(151, 26)
        Me.txt_brh_name.MaxLength = 50
        Me.txt_brh_name.Name = "txt_brh_name"
        Me.txt_brh_name.Size = New System.Drawing.Size(205, 21)
        Me.txt_brh_name.TabIndex = 0
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(28, 196)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 15)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Attachment Path"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Email"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 111)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 15)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "AE No."
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(97, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Branch Manager"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(83, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Branch Name"
        '
        'FrmAutoMailMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(628, 385)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tcMail)
        Me.KeyPreview = True
        Me.Name = "FrmAutoMailMain"
        Me.Text = "Auto Mail Report Maintainence"
        Me.Controls.SetChildIndex(Me.tcMail, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        CType(Me.dtgMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcMail.ResumeLayout(False)
        Me.tpMain.ResumeLayout(False)
        Me.tpRecord.ResumeLayout(False)
        Me.tpRecord.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dtgMail As System.Windows.Forms.DataGridView
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents tcMail As System.Windows.Forms.TabControl
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents tpRecord As System.Windows.Forms.TabPage
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblReportPath As System.Windows.Forms.Label
    Friend WithEvents txtattach As ESL.myTextbox
    Friend WithEvents txtemail As ESL.myTextbox
    Friend WithEvents txtaeno As ESL.myTextbox
    Friend WithEvents txt_brh_mgr As ESL.myTextbox
    Friend WithEvents txt_brh_name As ESL.myTextbox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents record_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents branch_name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents branch_manager As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aeno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents attachment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton

End Class
