<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmEmailAlertRecipientList
    Inherits ESL.frmBase
    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.cboEmailSubject = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnRefresh = New ESL.myButton(Me.components)
        Me.btnDel = New ESL.myButton(Me.components)
        Me.btnModify = New ESL.myButton(Me.components)
        Me.btnAdd = New ESL.myButton(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtEmail = New ESL.myTextbox()
        Me.DtgMail = New System.Windows.Forms.DataGridView()
        Me.dtgEmail = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.DtgMail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        '
        'btnSave
        '
        Me.btnSave.Visible = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(191, 9)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(238, 22)
        Me.Label7.TabIndex = 120
        Me.Label7.Text = "Email Alert Recipient List"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboEmailSubject
        '
        Me.cboEmailSubject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmailSubject.FormattingEnabled = True
        Me.cboEmailSubject.Location = New System.Drawing.Point(160, 41)
        Me.cboEmailSubject.Name = "cboEmailSubject"
        Me.cboEmailSubject.Size = New System.Drawing.Size(398, 23)
        Me.cboEmailSubject.TabIndex = 121
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label1.Location = New System.Drawing.Point(29, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(83, 15)
        Me.Label1.TabIndex = 122
        Me.Label1.Text = "Email Subject"
        '
        'btnRefresh
        '
        Me.btnRefresh.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnRefresh.Location = New System.Drawing.Point(432, 355)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(84, 23)
        Me.btnRefresh.TabIndex = 127
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = True
        Me.btnRefresh.Visible = False
        '
        'btnDel
        '
        Me.btnDel.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnDel.Location = New System.Drawing.Point(342, 355)
        Me.btnDel.Name = "btnDel"
        Me.btnDel.Size = New System.Drawing.Size(84, 23)
        Me.btnDel.TabIndex = 130
        Me.btnDel.Text = "Delete"
        Me.btnDel.UseVisualStyleBackColor = True
        '
        'btnModify
        '
        Me.btnModify.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnModify.Location = New System.Drawing.Point(252, 355)
        Me.btnModify.Name = "btnModify"
        Me.btnModify.Size = New System.Drawing.Size(84, 23)
        Me.btnModify.TabIndex = 129
        Me.btnModify.Text = "Adjust"
        Me.btnModify.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("新細明體", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(160, 355)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(84, 23)
        Me.btnAdd.TabIndex = 128
        Me.btnAdd.Text = "Add"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(157, 310)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(87, 15)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "Email Address"
        '
        'txtEmail
        '
        Me.txtEmail.Location = New System.Drawing.Point(160, 328)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.ReadOnly = True
        Me.txtEmail.Size = New System.Drawing.Size(315, 21)
        Me.txtEmail.TabIndex = 125
        '
        'DtgMail
        '
        Me.DtgMail.AllowUserToAddRows = False
        Me.DtgMail.AllowUserToDeleteRows = False
        Me.DtgMail.BackgroundColor = System.Drawing.Color.Linen
        Me.DtgMail.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.dtgEmail})
        Me.DtgMail.Location = New System.Drawing.Point(160, 74)
        Me.DtgMail.MultiSelect = False
        Me.DtgMail.Name = "DtgMail"
        Me.DtgMail.ReadOnly = True
        Me.DtgMail.RowHeadersVisible = False
        Me.DtgMail.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToDisplayedHeaders
        Me.DtgMail.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.Linen
        Me.DtgMail.RowTemplate.Height = 24
        Me.DtgMail.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DtgMail.Size = New System.Drawing.Size(315, 233)
        Me.DtgMail.TabIndex = 124
        '
        'dtgEmail
        '
        Me.dtgEmail.DataPropertyName = "Email Address"
        Me.dtgEmail.HeaderText = "Email Address"
        Me.dtgEmail.Name = "dtgEmail"
        Me.dtgEmail.ReadOnly = True
        Me.dtgEmail.Width = 312
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.Label2.Location = New System.Drawing.Point(29, 74)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 15)
        Me.Label2.TabIndex = 131
        Me.Label2.Text = "Recipient List"
        '
        'FrmEmailAlertRecipientList
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(629, 456)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnDel)
        Me.Controls.Add(Me.btnModify)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtEmail)
        Me.Controls.Add(Me.DtgMail)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cboEmailSubject)
        Me.Controls.Add(Me.Label7)
        Me.KeyPreview = True
        Me.Margin = New System.Windows.Forms.Padding(3, 5, 3, 5)
        Me.Name = "FrmEmailAlertRecipientList"
        Me.RightToLeftLayout = True
        Me.Text = "Email Alert Recipient List"
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label7, 0)
        Me.Controls.SetChildIndex(Me.cboEmailSubject, 0)
        Me.Controls.SetChildIndex(Me.Label1, 0)
        Me.Controls.SetChildIndex(Me.DtgMail, 0)
        Me.Controls.SetChildIndex(Me.txtEmail, 0)
        Me.Controls.SetChildIndex(Me.Label8, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnModify, 0)
        Me.Controls.SetChildIndex(Me.btnDel, 0)
        Me.Controls.SetChildIndex(Me.btnRefresh, 0)
        Me.Controls.SetChildIndex(Me.Label2, 0)
        CType(Me.DtgMail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cboEmailSubject As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnRefresh As ESL.myButton
    Friend WithEvents btnDel As ESL.myButton
    Friend WithEvents btnModify As ESL.myButton
    Friend WithEvents btnAdd As ESL.myButton
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtEmail As ESL.myTextbox
    Friend WithEvents DtgMail As System.Windows.Forms.DataGridView
    Friend WithEvents dtgEmail As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
