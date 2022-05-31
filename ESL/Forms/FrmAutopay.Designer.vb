<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmAutopay
    Inherits System.Windows.Forms.Form

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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpVDate = New System.Windows.Forms.DateTimePicker
        Me.dgvRecord = New System.Windows.Forms.DataGridView
        Me.clientID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientBankName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientBankNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientBankBrh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientAC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientIDCon = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientRef = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnLoadFile = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnExport = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.btnEditH = New System.Windows.Forms.Button
        Me.txtFirstPartyRef = New ESL.myTextbox
        Me.txtPaymentCode = New ESL.myTextbox
        Me.txtFirstPartyAC = New ESL.myTextbox
        Me.txtClientRef = New ESL.myTextbox
        Me.txtClientIDCon = New ESL.myTextbox
        Me.txtAmt = New ESL.myTextbox
        Me.txtClientAC = New ESL.myTextbox
        Me.txtClientBankBrh = New ESL.myTextbox
        Me.txtClientBankNo = New ESL.myTextbox
        Me.txtClientBankName = New ESL.myTextbox
        Me.txtClientID = New ESL.myTextbox
        CType(Me.dgvRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(299, 94)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 12)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Value Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 94)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 12)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Company Reference"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(299, 66)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 12)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Payment Code"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(22, 66)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(134, 12)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Company Account Number"
        '
        'dpVDate
        '
        Me.dpVDate.CustomFormat = "dd MMM yy"
        Me.dpVDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpVDate.Location = New System.Drawing.Point(378, 89)
        Me.dpVDate.Name = "dpVDate"
        Me.dpVDate.Size = New System.Drawing.Size(87, 22)
        Me.dpVDate.TabIndex = 4
        '
        'dgvRecord
        '
        Me.dgvRecord.AllowUserToAddRows = False
        Me.dgvRecord.AllowUserToDeleteRows = False
        Me.dgvRecord.BackgroundColor = System.Drawing.Color.Moccasin
        Me.dgvRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecord.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clientID, Me.clientBankName, Me.clientBankNo, Me.clientBankBrh, Me.clientAC, Me.amt, Me.clientIDCon, Me.clientRef})
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Moccasin
        DataGridViewCellStyle1.Font = New System.Drawing.Font("PMingLiU", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(136, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRecord.DefaultCellStyle = DataGridViewCellStyle1
        Me.dgvRecord.Location = New System.Drawing.Point(24, 134)
        Me.dgvRecord.MultiSelect = False
        Me.dgvRecord.Name = "dgvRecord"
        Me.dgvRecord.ReadOnly = True
        Me.dgvRecord.RowHeadersVisible = False
        Me.dgvRecord.RowTemplate.Height = 24
        Me.dgvRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecord.Size = New System.Drawing.Size(631, 268)
        Me.dgvRecord.TabIndex = 0
        '
        'clientID
        '
        Me.clientID.DataPropertyName = "clientID"
        Me.clientID.HeaderText = "Client ID"
        Me.clientID.Name = "clientID"
        Me.clientID.ReadOnly = True
        '
        'clientBankName
        '
        Me.clientBankName.DataPropertyName = "clientBankName"
        Me.clientBankName.HeaderText = "Client Bank Name"
        Me.clientBankName.Name = "clientBankName"
        Me.clientBankName.ReadOnly = True
        '
        'clientBankNo
        '
        Me.clientBankNo.DataPropertyName = "clientBankNo"
        Me.clientBankNo.HeaderText = "Client Bank No"
        Me.clientBankNo.Name = "clientBankNo"
        Me.clientBankNo.ReadOnly = True
        '
        'clientBankBrh
        '
        Me.clientBankBrh.DataPropertyName = "clientBankBrh"
        Me.clientBankBrh.HeaderText = "Client Bank Branch"
        Me.clientBankBrh.Name = "clientBankBrh"
        Me.clientBankBrh.ReadOnly = True
        '
        'clientAC
        '
        Me.clientAC.DataPropertyName = "clientAC"
        Me.clientAC.HeaderText = "Client A/C"
        Me.clientAC.Name = "clientAC"
        Me.clientAC.ReadOnly = True
        '
        'amt
        '
        Me.amt.DataPropertyName = "amt"
        Me.amt.HeaderText = "Amount"
        Me.amt.Name = "amt"
        Me.amt.ReadOnly = True
        '
        'clientIDCon
        '
        Me.clientIDCon.DataPropertyName = "clientIDCon"
        Me.clientIDCon.HeaderText = "Client ID Continuation"
        Me.clientIDCon.Name = "clientIDCon"
        Me.clientIDCon.ReadOnly = True
        '
        'clientRef
        '
        Me.clientRef.DataPropertyName = "clientRef"
        Me.clientRef.HeaderText = "Client Ref."
        Me.clientRef.Name = "clientRef"
        Me.clientRef.ReadOnly = True
        '
        'btnLoadFile
        '
        Me.btnLoadFile.Location = New System.Drawing.Point(199, 512)
        Me.btnLoadFile.Name = "btnLoadFile"
        Me.btnLoadFile.Size = New System.Drawing.Size(60, 44)
        Me.btnLoadFile.TabIndex = 5
        Me.btnLoadFile.Text = "Load From File"
        Me.btnLoadFile.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(24, 421)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 12)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Client ID"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(24, 449)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(102, 12)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "Client Bank Number"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(201, 421)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(133, 12)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Client Bank Account Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(201, 449)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 12)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Client Branch Number"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(416, 449)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 12)
        Me.Label9.TabIndex = 14
        Me.Label9.Text = "Client Account"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(170, 480)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(125, 12)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Continuation of Client ID"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(441, 480)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 12)
        Me.Label11.TabIndex = 16
        Me.Label11.Text = "Client Reference"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(228, 14)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(183, 29)
        Me.Label12.TabIndex = 17
        Me.Label12.Text = "HSBC Autopay"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(331, 512)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(60, 44)
        Me.btnAdd.TabIndex = 18
        Me.btnAdd.Text = "Add Record"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(397, 512)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(60, 44)
        Me.btnEdit.TabIndex = 19
        Me.btnEdit.Text = "Edit Record"
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(463, 512)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(60, 44)
        Me.btnDelete.TabIndex = 20
        Me.btnDelete.Text = "Delete Record"
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(529, 512)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(60, 44)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "Save"
        Me.btnSave.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(595, 512)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(60, 44)
        Me.btnCancel.TabIndex = 22
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(265, 512)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(60, 44)
        Me.btnExport.TabIndex = 23
        Me.btnExport.Text = "Export To File"
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(22, 480)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(43, 12)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Amount"
        '
        'btnEditH
        '
        Me.btnEditH.Location = New System.Drawing.Point(595, 67)
        Me.btnEditH.Name = "btnEditH"
        Me.btnEditH.Size = New System.Drawing.Size(60, 44)
        Me.btnEditH.TabIndex = 26
        Me.btnEditH.Text = "Edit Header"
        Me.btnEditH.UseVisualStyleBackColor = True
        '
        'txtFirstPartyRef
        '
        Me.txtFirstPartyRef.Location = New System.Drawing.Point(162, 91)
        Me.txtFirstPartyRef.MaxLength = 12
        Me.txtFirstPartyRef.Name = "txtFirstPartyRef"
        Me.txtFirstPartyRef.Size = New System.Drawing.Size(111, 22)
        Me.txtFirstPartyRef.TabIndex = 37
        '
        'txtPaymentCode
        '
        Me.txtPaymentCode.Location = New System.Drawing.Point(378, 63)
        Me.txtPaymentCode.MaxLength = 3
        Me.txtPaymentCode.Name = "txtPaymentCode"
        Me.txtPaymentCode.Size = New System.Drawing.Size(87, 22)
        Me.txtPaymentCode.TabIndex = 36
        '
        'txtFirstPartyAC
        '
        Me.txtFirstPartyAC.Location = New System.Drawing.Point(162, 63)
        Me.txtFirstPartyAC.MaxLength = 12
        Me.txtFirstPartyAC.Name = "txtFirstPartyAC"
        Me.txtFirstPartyAC.Size = New System.Drawing.Size(111, 22)
        Me.txtFirstPartyAC.TabIndex = 35
        '
        'txtClientRef
        '
        Me.txtClientRef.Location = New System.Drawing.Point(530, 477)
        Me.txtClientRef.MaxLength = 12
        Me.txtClientRef.Name = "txtClientRef"
        Me.txtClientRef.Size = New System.Drawing.Size(126, 22)
        Me.txtClientRef.TabIndex = 34
        '
        'txtClientIDCon
        '
        Me.txtClientIDCon.Location = New System.Drawing.Point(301, 477)
        Me.txtClientIDCon.MaxLength = 6
        Me.txtClientIDCon.Name = "txtClientIDCon"
        Me.txtClientIDCon.Size = New System.Drawing.Size(134, 22)
        Me.txtClientIDCon.TabIndex = 33
        '
        'txtAmt
        '
        Me.txtAmt.Location = New System.Drawing.Point(71, 477)
        Me.txtAmt.MaxLength = 11
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Size = New System.Drawing.Size(93, 22)
        Me.txtAmt.TabIndex = 32
        '
        'txtClientAC
        '
        Me.txtClientAC.Location = New System.Drawing.Point(497, 446)
        Me.txtClientAC.MaxLength = 9
        Me.txtClientAC.Name = "txtClientAC"
        Me.txtClientAC.Size = New System.Drawing.Size(158, 22)
        Me.txtClientAC.TabIndex = 31
        '
        'txtClientBankBrh
        '
        Me.txtClientBankBrh.Location = New System.Drawing.Point(318, 446)
        Me.txtClientBankBrh.MaxLength = 3
        Me.txtClientBankBrh.Name = "txtClientBankBrh"
        Me.txtClientBankBrh.Size = New System.Drawing.Size(92, 22)
        Me.txtClientBankBrh.TabIndex = 30
        '
        'txtClientBankNo
        '
        Me.txtClientBankNo.Location = New System.Drawing.Point(132, 446)
        Me.txtClientBankNo.MaxLength = 3
        Me.txtClientBankNo.Name = "txtClientBankNo"
        Me.txtClientBankNo.Size = New System.Drawing.Size(63, 22)
        Me.txtClientBankNo.TabIndex = 29
        '
        'txtClientBankName
        '
        Me.txtClientBankName.Location = New System.Drawing.Point(340, 418)
        Me.txtClientBankName.MaxLength = 20
        Me.txtClientBankName.Name = "txtClientBankName"
        Me.txtClientBankName.Size = New System.Drawing.Size(315, 22)
        Me.txtClientBankName.TabIndex = 28
        '
        'txtClientID
        '
        Me.txtClientID.Location = New System.Drawing.Point(78, 418)
        Me.txtClientID.MaxLength = 12
        Me.txtClientID.Name = "txtClientID"
        Me.txtClientID.Size = New System.Drawing.Size(117, 22)
        Me.txtClientID.TabIndex = 27
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Moccasin
        Me.ClientSize = New System.Drawing.Size(680, 590)
        Me.Controls.Add(Me.txtFirstPartyRef)
        Me.Controls.Add(Me.txtPaymentCode)
        Me.Controls.Add(Me.txtFirstPartyAC)
        Me.Controls.Add(Me.txtClientRef)
        Me.Controls.Add(Me.txtClientIDCon)
        Me.Controls.Add(Me.txtAmt)
        Me.Controls.Add(Me.txtClientAC)
        Me.Controls.Add(Me.txtClientBankBrh)
        Me.Controls.Add(Me.txtClientBankNo)
        Me.Controls.Add(Me.txtClientBankName)
        Me.Controls.Add(Me.txtClientID)
        Me.Controls.Add(Me.btnEditH)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnLoadFile)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dpVDate)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.dgvRecord)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Name = "Form1"
        Me.Text = "HSBC Autopay"
        CType(Me.dgvRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dpVDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dgvRecord As System.Windows.Forms.DataGridView
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnLoadFile As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents clientID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientBankName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientBankNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientBankBrh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientAC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientIDCon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents btnEditH As System.Windows.Forms.Button
    Friend WithEvents txtClientID As ESL.myTextbox
    Friend WithEvents txtClientBankName As ESL.myTextbox
    Friend WithEvents txtClientBankNo As ESL.myTextbox
    Friend WithEvents txtClientBankBrh As ESL.myTextbox
    Friend WithEvents txtClientAC As ESL.myTextbox
    Friend WithEvents txtAmt As ESL.myTextbox
    Friend WithEvents txtClientIDCon As ESL.myTextbox
    Friend WithEvents txtClientRef As ESL.myTextbox
    Friend WithEvents txtFirstPartyAC As ESL.myTextbox
    Friend WithEvents txtPaymentCode As ESL.myTextbox
    Friend WithEvents txtFirstPartyRef As ESL.myTextbox

End Class
