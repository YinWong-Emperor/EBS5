<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCIESAlertMaster
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
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnDelete = New ESL.myButton(Me.components)
        Me.Label6 = New System.Windows.Forms.Label
        Me.tpRecord = New System.Windows.Forms.TabPage
        Me.dgvAlertDate = New System.Windows.Forms.DataGridView
        Me.alertDate = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.txtemail_cc = New ESL.myTextbox
        Me.txtemail_to = New ESL.myTextbox
        Me.txtaeno = New ESL.myTextbox
        Me.Label2 = New System.Windows.Forms.Label
        Me.lblid = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboClientCodeEnd = New ESL.myComboBox(Me.components)
        Me.cboClientCodeStart = New ESL.myComboBox(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.Label7 = New System.Windows.Forms.Label
        Me.dtgMail = New System.Windows.Forms.DataGridView
        Me.tpMain = New System.Windows.Forms.TabPage
        Me.btnEdit = New ESL.myButton(Me.components)
        Me.tcMail = New System.Windows.Forms.TabControl
        Me.SeqNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cCode_from = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.cCode_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.aeno = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.email_to = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.email_Cc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.sendAlertDate = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.tpRecord.SuspendLayout()
        CType(Me.dgvAlertDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dtgMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpMain.SuspendLayout()
        Me.tcMail.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(557, 306)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(506, 306)
        Me.btnSave.Visible = True
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(28, 154)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 15)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Email (To)"
        '
        'tpRecord
        '
        Me.tpRecord.Controls.Add(Me.dgvAlertDate)
        Me.tpRecord.Controls.Add(Me.txtemail_cc)
        Me.tpRecord.Controls.Add(Me.txtemail_to)
        Me.tpRecord.Controls.Add(Me.txtaeno)
        Me.tpRecord.Controls.Add(Me.Label2)
        Me.tpRecord.Controls.Add(Me.lblid)
        Me.tpRecord.Controls.Add(Me.Label1)
        Me.tpRecord.Controls.Add(Me.Label6)
        Me.tpRecord.Controls.Add(Me.Label5)
        Me.tpRecord.Controls.Add(Me.Label4)
        Me.tpRecord.Controls.Add(Me.Label3)
        Me.tpRecord.Controls.Add(Me.cboClientCodeEnd)
        Me.tpRecord.Controls.Add(Me.cboClientCodeStart)
        Me.tpRecord.Location = New System.Drawing.Point(4, 24)
        Me.tpRecord.Name = "tpRecord"
        Me.tpRecord.Padding = New System.Windows.Forms.Padding(3)
        Me.tpRecord.Size = New System.Drawing.Size(600, 319)
        Me.tpRecord.TabIndex = 1
        Me.tpRecord.Text = "Modification"
        Me.tpRecord.UseVisualStyleBackColor = True
        '
        'dgvAlertDate
        '
        Me.dgvAlertDate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAlertDate.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.alertDate})
        Me.dgvAlertDate.Location = New System.Drawing.Point(301, 26)
        Me.dgvAlertDate.Name = "dgvAlertDate"
        Me.dgvAlertDate.RowHeadersVisible = False
        Me.dgvAlertDate.RowTemplate.Height = 24
        Me.dgvAlertDate.Size = New System.Drawing.Size(258, 107)
        Me.dgvAlertDate.TabIndex = 111
        '
        'alertDate
        '
        Me.alertDate.HeaderText = "Alert Date"
        Me.alertDate.Name = "alertDate"
        Me.alertDate.Width = 230
        '
        'txtemail_cc
        '
        Me.txtemail_cc.Location = New System.Drawing.Point(151, 194)
        Me.txtemail_cc.MaxLength = 500
        Me.txtemail_cc.Name = "txtemail_cc"
        Me.txtemail_cc.Size = New System.Drawing.Size(408, 21)
        Me.txtemail_cc.TabIndex = 103
        Me.txtemail_cc.Visible = False
        '
        'txtemail_to
        '
        Me.txtemail_to.Location = New System.Drawing.Point(151, 151)
        Me.txtemail_to.MaxLength = 500
        Me.txtemail_to.Name = "txtemail_to"
        Me.txtemail_to.Size = New System.Drawing.Size(408, 21)
        Me.txtemail_to.TabIndex = 3
        '
        'txtaeno
        '
        Me.txtaeno.Location = New System.Drawing.Point(151, 108)
        Me.txtaeno.MaxLength = 20
        Me.txtaeno.Name = "txtaeno"
        Me.txtaeno.Size = New System.Drawing.Size(121, 21)
        Me.txtaeno.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(28, 197)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 104
        Me.Label2.Text = "Email (Cc)"
        Me.Label2.Visible = False
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
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(28, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 15)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Client Code To"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(28, 29)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(104, 15)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Client Code From"
        '
        'cboClientCodeEnd
        '
        Me.cboClientCodeEnd.FormattingEnabled = True
        Me.cboClientCodeEnd.Location = New System.Drawing.Point(151, 70)
        Me.cboClientCodeEnd.Name = "cboClientCodeEnd"
        Me.cboClientCodeEnd.Size = New System.Drawing.Size(121, 23)
        Me.cboClientCodeEnd.TabIndex = 102
        '
        'cboClientCodeStart
        '
        Me.cboClientCodeStart.FormattingEnabled = True
        Me.cboClientCodeStart.Location = New System.Drawing.Point(151, 26)
        Me.cboClientCodeStart.Name = "cboClientCodeStart"
        Me.cboClientCodeStart.Size = New System.Drawing.Size(121, 23)
        Me.cboClientCodeStart.TabIndex = 101
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
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(231, 4)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(172, 22)
        Me.Label7.TabIndex = 119
        Me.Label7.Text = "CIES Alert Master"
        '
        'dtgMail
        '
        Me.dtgMail.AllowUserToAddRows = False
        Me.dtgMail.AllowUserToDeleteRows = False
        Me.dtgMail.AllowUserToResizeRows = False
        Me.dtgMail.BackgroundColor = System.Drawing.Color.Linen
        Me.dtgMail.ColumnHeadersHeight = 20
        Me.dtgMail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.SeqNo, Me.cCode_from, Me.cCode_to, Me.aeno, Me.email_to, Me.email_Cc, Me.sendAlertDate})
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
        'tpMain
        '
        Me.tpMain.Controls.Add(Me.dtgMail)
        Me.tpMain.Controls.Add(Me.btnEdit)
        Me.tpMain.Controls.Add(Me.btnDelete)
        Me.tpMain.Controls.Add(Me.btnAdd)
        Me.tpMain.Location = New System.Drawing.Point(4, 24)
        Me.tpMain.Name = "tpMain"
        Me.tpMain.Padding = New System.Windows.Forms.Padding(3)
        Me.tpMain.Size = New System.Drawing.Size(600, 319)
        Me.tpMain.TabIndex = 0
        Me.tpMain.Text = "Main"
        Me.tpMain.UseVisualStyleBackColor = True
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
        'tcMail
        '
        Me.tcMail.Controls.Add(Me.tpMain)
        Me.tcMail.Controls.Add(Me.tpRecord)
        Me.tcMail.Location = New System.Drawing.Point(12, 29)
        Me.tcMail.Name = "tcMail"
        Me.tcMail.SelectedIndex = 0
        Me.tcMail.Size = New System.Drawing.Size(608, 347)
        Me.tcMail.TabIndex = 120
        '
        'SeqNo
        '
        Me.SeqNo.DataPropertyName = "alert_seq_no"
        Me.SeqNo.HeaderText = "Sequence No"
        Me.SeqNo.Name = "SeqNo"
        Me.SeqNo.ReadOnly = True
        Me.SeqNo.Visible = False
        '
        'cCode_from
        '
        Me.cCode_from.DataPropertyName = "from_clt_code"
        Me.cCode_from.HeaderText = "Client Code From"
        Me.cCode_from.Name = "cCode_from"
        Me.cCode_from.ReadOnly = True
        Me.cCode_from.Width = 120
        '
        'cCode_to
        '
        Me.cCode_to.DataPropertyName = "to_clt_code"
        Me.cCode_to.HeaderText = "Client Code To"
        Me.cCode_to.Name = "cCode_to"
        Me.cCode_to.ReadOnly = True
        Me.cCode_to.Width = 120
        '
        'aeno
        '
        Me.aeno.DataPropertyName = "run_code"
        Me.aeno.HeaderText = "AE No"
        Me.aeno.Name = "aeno"
        Me.aeno.ReadOnly = True
        Me.aeno.Width = 50
        '
        'email_to
        '
        Me.email_to.DataPropertyName = "To_email_address"
        Me.email_to.HeaderText = "Email Address (To)"
        Me.email_to.Name = "email_to"
        Me.email_to.ReadOnly = True
        Me.email_to.Width = 220
        '
        'email_Cc
        '
        Me.email_Cc.DataPropertyName = "Cc_email_address"
        Me.email_Cc.HeaderText = "Email Address (Cc)"
        Me.email_Cc.Name = "email_Cc"
        Me.email_Cc.ReadOnly = True
        Me.email_Cc.Visible = False
        Me.email_Cc.Width = 220
        '
        'sendAlertDate
        '
        Me.sendAlertDate.DataPropertyName = "alertDate"
        Me.sendAlertDate.HeaderText = "Send Alert Date"
        Me.sendAlertDate.Name = "sendAlertDate"
        Me.sendAlertDate.ReadOnly = True
        '
        'FrmCIESAlertMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(628, 385)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.tcMail)
        Me.KeyPreview = True
        Me.Name = "FrmCIESAlertMaster"
        Me.Text = "CIES Alert Master"
        Me.Controls.SetChildIndex(Me.tcMail, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.tpRecord.ResumeLayout(False)
        Me.tpRecord.PerformLayout()
        CType(Me.dgvAlertDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dtgMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpMain.ResumeLayout(False)
        Me.tcMail.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnDelete As ESL.myButton
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents tpRecord As System.Windows.Forms.TabPage
    Friend WithEvents txtemail_cc As ESL.myTextbox
    Friend WithEvents txtemail_to As ESL.myTextbox
    Friend WithEvents txtaeno As ESL.myTextbox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblid As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboClientCodeEnd As ESL.myComboBox
    Friend WithEvents cboClientCodeStart As ESL.myComboBox
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents dtgMail As System.Windows.Forms.DataGridView
    Friend WithEvents tpMain As System.Windows.Forms.TabPage
    Friend WithEvents btnEdit As ESL.myButton
    Friend WithEvents tcMail As System.Windows.Forms.TabControl
    Friend WithEvents dgvAlertDate As System.Windows.Forms.DataGridView
    Friend WithEvents alertDate As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents SeqNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCode_from As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cCode_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents aeno As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents email_to As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents email_Cc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents sendAlertDate As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
