<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAutoMailStatementMain
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
        Me.email = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.attachment = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.summary = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.record_no = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label7 = New System.Windows.Forms.Label
        Me.tcMail = New System.Windows.Forms.TabControl
        Me.tpMain = New System.Windows.Forms.TabPage
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.tpRecord = New System.Windows.Forms.TabPage
        Me.MyButton1 = New ESL.myButton(Me.components)
        Me.MyCheckBox1 = New ESL.myCheckBox(Me.components)
        Me.lblReportPath = New System.Windows.Forms.Label
        Me.txtattach = New ESL.myTextbox
        Me.txtemail = New ESL.myTextbox
        Me.lblid = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        CType(Me.dtgMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcMail.SuspendLayout()
        Me.tpMain.SuspendLayout()
        Me.tpRecord.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(646, 309)
        Me.btnCancel.TabIndex = 1
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(595, 309)
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
        Me.dtgMail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.email, Me.attachment, Me.summary, Me.record_no})
        Me.dtgMail.GridColor = System.Drawing.Color.Linen
        Me.dtgMail.Location = New System.Drawing.Point(26, 22)
        Me.dtgMail.MultiSelect = False
        Me.dtgMail.Name = "dtgMail"
        Me.dtgMail.ReadOnly = True
        Me.dtgMail.RowHeadersVisible = False
        Me.dtgMail.RowTemplate.Height = 24
        Me.dtgMail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dtgMail.Size = New System.Drawing.Size(640, 216)
        Me.dtgMail.TabIndex = 1
        '
        'email
        '
        Me.email.DataPropertyName = "email"
        Me.email.HeaderText = "Email Address"
        Me.email.Name = "email"
        Me.email.ReadOnly = True
        Me.email.Width = 400
        '
        'attachment
        '
        Me.attachment.DataPropertyName = "attachment"
        Me.attachment.HeaderText = "Attachment Path"
        Me.attachment.Name = "attachment"
        Me.attachment.ReadOnly = True
        '
        'summary
        '
        Me.summary.DataPropertyName = "summary"
        Me.summary.HeaderText = "Summary Only"
        Me.summary.Name = "summary"
        Me.summary.ReadOnly = True
        Me.summary.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.summary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        '
        'record_no
        '
        Me.record_no.DataPropertyName = "record_no"
        Me.record_no.HeaderText = "Record_no"
        Me.record_no.Name = "record_no"
        Me.record_no.ReadOnly = True
        Me.record_no.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(192, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(323, 22)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Auto Mail Statement Maintainence"
        '
        'tcMail
        '
        Me.tcMail.Controls.Add(Me.tpMain)
        Me.tcMail.Controls.Add(Me.tpRecord)
        Me.tcMail.Location = New System.Drawing.Point(12, 29)
        Me.tcMail.Name = "tcMail"
        Me.tcMail.SelectedIndex = 0
        Me.tcMail.Size = New System.Drawing.Size(693, 346)
        Me.tcMail.TabIndex = 0
        '
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.dtgMail)
        Me.tpMain.Controls.Add(Me.btnDelete)
        Me.tpMain.Controls.Add(Me.btnAdd)
        Me.tpMain.Controls.Add(Me.btnEdit)
        Me.tpMain.Location = New System.Drawing.Point(4, 24)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(685, 318)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main"
        Me.tpMain.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(523, 256)
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
        Me.btnAdd.Location = New System.Drawing.Point(421, 256)
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
        Me.btnEdit.Location = New System.Drawing.Point(472, 256)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'tpRecord
        '
        Me.tpRecord.Controls.Add(Me.MyButton1)
        Me.tpRecord.Controls.Add(Me.MyCheckBox1)
        Me.tpRecord.Controls.Add(Me.lblReportPath)
        Me.tpRecord.Controls.Add(Me.txtattach)
        Me.tpRecord.Controls.Add(Me.txtemail)
        Me.tpRecord.Controls.Add(Me.lblid)
        Me.tpRecord.Controls.Add(Me.Label1)
        Me.tpRecord.Controls.Add(Me.Label8)
        Me.tpRecord.Controls.Add(Me.Label6)
        Me.tpRecord.Location = New System.Drawing.Point(4, 24)
        Me.tpRecord.Name = "tpRecord"
        Me.tpRecord.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRecord.Size = New System.Drawing.Size(685, 318)
        Me.tpRecord.TabIndex = 1
        Me.tpRecord.Text = "Modification"
        Me.tpRecord.UseVisualStyleBackColor = True
        '
        'MyButton1
        '
        Me.MyButton1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MyButton1.Location = New System.Drawing.Point(523, 256)
        Me.MyButton1.Name = "MyButton1"
        Me.MyButton1.Size = New System.Drawing.Size(50, 55)
        Me.MyButton1.TabIndex = 15
        Me.MyButton1.Text = "Edit"
        Me.MyButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.MyButton1.UseVisualStyleBackColor = True
        '
        'MyCheckBox1
        '
        Me.MyCheckBox1.AutoSize = True
        Me.MyCheckBox1.Location = New System.Drawing.Point(164, 185)
        Me.MyCheckBox1.Name = "MyCheckBox1"
        Me.MyCheckBox1.Size = New System.Drawing.Size(197, 19)
        Me.MyCheckBox1.TabIndex = 14
        Me.MyCheckBox1.Text = "Send Statement Summary Only"
        Me.MyCheckBox1.UseVisualStyleBackColor = True
        '
        'lblReportPath
        '
        Me.lblReportPath.AutoSize = True
        Me.lblReportPath.Location = New System.Drawing.Point(161, 141)
        Me.lblReportPath.Name = "lblReportPath"
        Me.lblReportPath.Size = New System.Drawing.Size(185, 15)
        Me.lblReportPath.TabIndex = 12
        Me.lblReportPath.Text = "X:\STOCK_EXPORT\D-yyMMdd\*\"
        '
        'txtattach
        '
        Me.txtattach.Location = New System.Drawing.Point(348, 138)
        Me.txtattach.MaxLength = 100
        Me.txtattach.Name = "txtattach"
        Me.txtattach.Size = New System.Drawing.Size(224, 21)
        Me.txtattach.TabIndex = 4
        '
        'txtemail
        '
        Me.txtemail.Location = New System.Drawing.Point(164, 96)
        Me.txtemail.MaxLength = 100
        Me.txtemail.Name = "txtemail"
        Me.txtemail.Size = New System.Drawing.Size(408, 21)
        Me.txtemail.TabIndex = 3
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(41, 141)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(96, 15)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Attachment Path"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(41, 99)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(39, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Email"
        '
        'FrmAutoMailStatementMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(717, 387)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tcMail)
        Me.KeyPreview = True
        Me.Name = "FrmAutoMailStatementMain"
        Me.Text = "Auto Mail Statement Maintainence"
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
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents tpRecord As System.Windows.Forms.TabPage
    Friend WithEvents lblReportPath As System.Windows.Forms.Label
    Friend WithEvents txtattach As ESL.myTextbox
    Friend WithEvents txtemail As ESL.myTextbox
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents MyCheckBox1 As ESL.myCheckBox
    Friend WithEvents email As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents attachment As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents summary As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents record_no As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MyButton1 As ESL.myButton

End Class
