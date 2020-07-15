<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmHSBCAutopay
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.txtFirstPartyRef = New ESL.myTextbox
        Me.txtPaymentCode = New ESL.myTextbox
        Me.txtClientRef = New ESL.myTextbox
        Me.txtClientIDCon = New ESL.myTextbox
        Me.txtAmt = New ESL.myTextbox
        Me.txtClientAC = New ESL.myTextbox
        Me.txtClientBankBrh = New ESL.myTextbox
        Me.txtClientBankNo = New ESL.myTextbox
        Me.txtClientBankName = New ESL.myTextbox
        Me.txtClientID = New ESL.myTextbox
        Me.btnEditH = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.dpVDate = New System.Windows.Forms.DateTimePicker
        Me.Label9 = New System.Windows.Forms.Label
        Me.dgvRecord = New System.Windows.Forms.DataGridView
        Me.clientID = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientBankName = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientBankNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientBankBrh = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientAC = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.amt = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientIDCon = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clientRef = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnLoad = New System.Windows.Forms.Button
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Label16 = New System.Windows.Forms.Label
        Me.txtTimeToS = New ESL.myTextbox
        Me.txtDateToS = New ESL.myTextbox
        Me.txtTimeFromS = New ESL.myTextbox
        Me.txtDateFromS = New ESL.myTextbox
        Me.Label14 = New System.Windows.Forms.Label
        Me.dgvFundOutS = New System.Windows.Forms.DataGridView
        Me.clt_check_s = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tdate_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clt_code_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clt_name_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bank_code_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fund_out_amt_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.notes_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.is_chq_s = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnTransfer_s = New System.Windows.Forms.Button
        Me.btnLoad_s = New System.Windows.Forms.Button
        Me.dpS = New System.Windows.Forms.DateTimePicker
        Me.Label20 = New System.Windows.Forms.Label
        Me.TabPage3 = New System.Windows.Forms.TabPage
        Me.Label15 = New System.Windows.Forms.Label
        Me.txtTimeToF = New ESL.myTextbox
        Me.txtDateToF = New ESL.myTextbox
        Me.txtTimeFromF = New ESL.myTextbox
        Me.txtDateFromF = New ESL.myTextbox
        Me.Label17 = New System.Windows.Forms.Label
        Me.btnTransfer_f = New System.Windows.Forms.Button
        Me.dgvFundOutF = New System.Windows.Forms.DataGridView
        Me.clt_check_f = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.tdate_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clt_code_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clt_name_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.bank_code_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.fund_out_amt_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.notes_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.is_chq_f = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.btnLoad_f = New System.Windows.Forms.Button
        Me.dpF = New System.Windows.Forms.DateTimePicker
        Me.Label21 = New System.Windows.Forms.Label
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.cboFirstPartyAC = New ESL.myComboBox(Me.components)
        Me.TabPage4 = New System.Windows.Forms.TabPage
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.txtPayCodeF = New ESL.myTextbox
        Me.txtCommAccF = New ESL.myTextbox
        Me.txtPayCodeS = New ESL.myTextbox
        Me.txtCommAccS = New ESL.myTextbox
        Me.txtCutTime = New ESL.myTextbox
        Me.lblProcess = New System.Windows.Forms.Label
        Me.pbarPrint = New System.Windows.Forms.ProgressBar
        CType(Me.dgvRecord, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvFundOutS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage3.SuspendLayout()
        CType(Me.dgvFundOutF, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabPage1.SuspendLayout()
        Me.TabPage4.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(732, 538)
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(626, 538)
        Me.btnSave.Visible = True
        '
        'txtFirstPartyRef
        '
        Me.txtFirstPartyRef.Location = New System.Drawing.Point(146, 40)
        Me.txtFirstPartyRef.MaxLength = 12
        Me.txtFirstPartyRef.Name = "txtFirstPartyRef"
        Me.txtFirstPartyRef.Size = New System.Drawing.Size(111, 21)
        Me.txtFirstPartyRef.TabIndex = 64
        '
        'txtPaymentCode
        '
        Me.txtPaymentCode.Location = New System.Drawing.Point(363, 12)
        Me.txtPaymentCode.MaxLength = 3
        Me.txtPaymentCode.Name = "txtPaymentCode"
        Me.txtPaymentCode.Size = New System.Drawing.Size(87, 21)
        Me.txtPaymentCode.TabIndex = 63
        '
        'txtClientRef
        '
        Me.txtClientRef.Location = New System.Drawing.Point(594, 404)
        Me.txtClientRef.MaxLength = 12
        Me.txtClientRef.Name = "txtClientRef"
        Me.txtClientRef.Size = New System.Drawing.Size(149, 21)
        Me.txtClientRef.TabIndex = 61
        '
        'txtClientIDCon
        '
        Me.txtClientIDCon.Location = New System.Drawing.Point(325, 406)
        Me.txtClientIDCon.MaxLength = 6
        Me.txtClientIDCon.Name = "txtClientIDCon"
        Me.txtClientIDCon.Size = New System.Drawing.Size(170, 21)
        Me.txtClientIDCon.TabIndex = 60
        '
        'txtAmt
        '
        Me.txtAmt.Location = New System.Drawing.Point(61, 406)
        Me.txtAmt.MaxLength = 11
        Me.txtAmt.Name = "txtAmt"
        Me.txtAmt.Size = New System.Drawing.Size(117, 21)
        Me.txtAmt.TabIndex = 59
        '
        'txtClientAC
        '
        Me.txtClientAC.Location = New System.Drawing.Point(594, 377)
        Me.txtClientAC.MaxLength = 9
        Me.txtClientAC.Name = "txtClientAC"
        Me.txtClientAC.Size = New System.Drawing.Size(149, 21)
        Me.txtClientAC.TabIndex = 58
        '
        'txtClientBankBrh
        '
        Me.txtClientBankBrh.Location = New System.Drawing.Point(325, 377)
        Me.txtClientBankBrh.MaxLength = 3
        Me.txtClientBankBrh.Name = "txtClientBankBrh"
        Me.txtClientBankBrh.Size = New System.Drawing.Size(170, 21)
        Me.txtClientBankBrh.TabIndex = 57
        '
        'txtClientBankNo
        '
        Me.txtClientBankNo.Location = New System.Drawing.Point(115, 378)
        Me.txtClientBankNo.MaxLength = 3
        Me.txtClientBankNo.Name = "txtClientBankNo"
        Me.txtClientBankNo.Size = New System.Drawing.Size(63, 21)
        Me.txtClientBankNo.TabIndex = 56
        '
        'txtClientBankName
        '
        Me.txtClientBankName.Location = New System.Drawing.Point(325, 349)
        Me.txtClientBankName.MaxLength = 20
        Me.txtClientBankName.Name = "txtClientBankName"
        Me.txtClientBankName.Size = New System.Drawing.Size(421, 21)
        Me.txtClientBankName.TabIndex = 55
        '
        'txtClientID
        '
        Me.txtClientID.Location = New System.Drawing.Point(61, 350)
        Me.txtClientID.MaxLength = 12
        Me.txtClientID.Name = "txtClientID"
        Me.txtClientID.Size = New System.Drawing.Size(117, 21)
        Me.txtClientID.TabIndex = 54
        '
        'btnEditH
        '
        Me.btnEditH.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEditH.Location = New System.Drawing.Point(696, 7)
        Me.btnEditH.Name = "btnEditH"
        Me.btnEditH.Size = New System.Drawing.Size(50, 55)
        Me.btnEditH.TabIndex = 53
        Me.btnEditH.Text = "Edit Header"
        Me.btnEditH.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEditH.UseVisualStyleBackColor = True
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(6, 409)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(44, 14)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Amount"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Arial", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(316, 9)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(183, 29)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "HSBC Autopay"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(284, 43)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 14)
        Me.Label4.TabIndex = 43
        Me.Label4.Text = "Value Date"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(501, 408)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(87, 14)
        Me.Label11.TabIndex = 50
        Me.Label11.Text = "Client Reference"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(6, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(106, 14)
        Me.Label3.TabIndex = 42
        Me.Label3.Text = "Company Reference"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(284, 15)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 14)
        Me.Label2.TabIndex = 41
        Me.Label2.Text = "Payment Code"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(184, 409)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(120, 14)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Continuation of Client ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(6, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(136, 14)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Company Account Number"
        '
        'dpVDate
        '
        Me.dpVDate.CustomFormat = "dd MMM yy"
        Me.dpVDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpVDate.Location = New System.Drawing.Point(363, 38)
        Me.dpVDate.Name = "dpVDate"
        Me.dpVDate.Size = New System.Drawing.Size(87, 21)
        Me.dpVDate.TabIndex = 39
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(501, 381)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 14)
        Me.Label9.TabIndex = 48
        Me.Label9.Text = "Client Account"
        '
        'dgvRecord
        '
        Me.dgvRecord.AllowUserToAddRows = False
        Me.dgvRecord.AllowUserToDeleteRows = False
        Me.dgvRecord.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvRecord.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clientID, Me.clientBankName, Me.clientBankNo, Me.clientBankBrh, Me.clientAC, Me.amt, Me.clientIDCon, Me.clientRef})
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvRecord.DefaultCellStyle = DataGridViewCellStyle2
        Me.dgvRecord.Location = New System.Drawing.Point(9, 76)
        Me.dgvRecord.MultiSelect = False
        Me.dgvRecord.Name = "dgvRecord"
        Me.dgvRecord.ReadOnly = True
        Me.dgvRecord.RowHeadersVisible = False
        Me.dgvRecord.RowTemplate.Height = 24
        Me.dgvRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvRecord.Size = New System.Drawing.Size(737, 268)
        Me.dgvRecord.TabIndex = 38
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
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle1.Format = "N2"
        Me.amt.DefaultCellStyle = DataGridViewCellStyle1
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
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(184, 381)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 14)
        Me.Label8.TabIndex = 47
        Me.Label8.Text = "Client Branch Number"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(184, 353)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(134, 14)
        Me.Label7.TabIndex = 46
        Me.Label7.Text = "Client Bank Account Name"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 381)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(100, 14)
        Me.Label6.TabIndex = 45
        Me.Label6.Text = "Client Bank Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 353)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 14)
        Me.Label5.TabIndex = 44
        Me.Label5.Text = "Client ID"
        '
        'btnExport
        '
        Me.btnExport.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExport.Location = New System.Drawing.Point(679, 538)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(50, 55)
        Me.btnExport.TabIndex = 69
        Me.btnExport.Text = "Export File"
        Me.btnExport.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExport.UseVisualStyleBackColor = True
        '
        'btnDelete
        '
        Me.btnDelete.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnDelete.Location = New System.Drawing.Point(520, 538)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(50, 55)
        Me.btnDelete.TabIndex = 68
        Me.btnDelete.Text = "Delete"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.UseVisualStyleBackColor = True
        '
        'btnEdit
        '
        Me.btnEdit.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnEdit.Location = New System.Drawing.Point(573, 538)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(50, 55)
        Me.btnEdit.TabIndex = 67
        Me.btnEdit.Text = "Edit"
        Me.btnEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnEdit.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAdd.Location = New System.Drawing.Point(467, 538)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(50, 55)
        Me.btnAdd.TabIndex = 66
        Me.btnAdd.Text = "Add"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'btnLoad
        '
        Me.btnLoad.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad.Location = New System.Drawing.Point(414, 538)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(50, 55)
        Me.btnLoad.TabIndex = 65
        Me.btnLoad.Text = "Load"
        Me.btnLoad.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoad.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage4)
        Me.TabControl1.Location = New System.Drawing.Point(12, 41)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(791, 490)
        Me.TabControl1.TabIndex = 71
        '
        'TabPage2
        '
        Me.TabPage2.BackColor = System.Drawing.Color.Linen
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtTimeToS)
        Me.TabPage2.Controls.Add(Me.txtDateToS)
        Me.TabPage2.Controls.Add(Me.txtTimeFromS)
        Me.TabPage2.Controls.Add(Me.txtDateFromS)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.dgvFundOutS)
        Me.TabPage2.Controls.Add(Me.btnTransfer_s)
        Me.TabPage2.Controls.Add(Me.btnLoad_s)
        Me.TabPage2.Controls.Add(Me.dpS)
        Me.TabPage2.Controls.Add(Me.Label20)
        Me.TabPage2.Location = New System.Drawing.Point(4, 24)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(783, 462)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "AFE(S)"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.Location = New System.Drawing.Point(224, 14)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(46, 14)
        Me.Label16.TabIndex = 111
        Me.Label16.Text = "From >="
        '
        'txtTimeToS
        '
        Me.txtTimeToS.Enabled = False
        Me.txtTimeToS.Location = New System.Drawing.Point(557, 10)
        Me.txtTimeToS.Name = "txtTimeToS"
        Me.txtTimeToS.Size = New System.Drawing.Size(73, 21)
        Me.txtTimeToS.TabIndex = 110
        '
        'txtDateToS
        '
        Me.txtDateToS.Enabled = False
        Me.txtDateToS.Location = New System.Drawing.Point(473, 10)
        Me.txtDateToS.Name = "txtDateToS"
        Me.txtDateToS.Size = New System.Drawing.Size(78, 21)
        Me.txtDateToS.TabIndex = 109
        '
        'txtTimeFromS
        '
        Me.txtTimeFromS.Enabled = False
        Me.txtTimeFromS.Location = New System.Drawing.Point(360, 10)
        Me.txtTimeFromS.Name = "txtTimeFromS"
        Me.txtTimeFromS.Size = New System.Drawing.Size(73, 21)
        Me.txtTimeFromS.TabIndex = 108
        '
        'txtDateFromS
        '
        Me.txtDateFromS.Enabled = False
        Me.txtDateFromS.Location = New System.Drawing.Point(276, 10)
        Me.txtDateFromS.Name = "txtDateFromS"
        Me.txtDateFromS.Size = New System.Drawing.Size(78, 21)
        Me.txtDateFromS.TabIndex = 107
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(439, 14)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(28, 14)
        Me.Label14.TabIndex = 106
        Me.Label14.Text = "To <"
        '
        'dgvFundOutS
        '
        Me.dgvFundOutS.AllowUserToAddRows = False
        Me.dgvFundOutS.AllowUserToDeleteRows = False
        Me.dgvFundOutS.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvFundOutS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFundOutS.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clt_check_s, Me.tdate_s, Me.clt_code_s, Me.clt_name_s, Me.bank_code_s, Me.fund_out_amt_s, Me.notes_s, Me.is_chq_s})
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle4.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFundOutS.DefaultCellStyle = DataGridViewCellStyle4
        Me.dgvFundOutS.Location = New System.Drawing.Point(15, 42)
        Me.dgvFundOutS.MultiSelect = False
        Me.dgvFundOutS.Name = "dgvFundOutS"
        Me.dgvFundOutS.RowHeadersVisible = False
        Me.dgvFundOutS.RowTemplate.Height = 24
        Me.dgvFundOutS.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFundOutS.Size = New System.Drawing.Size(751, 350)
        Me.dgvFundOutS.TabIndex = 71
        '
        'clt_check_s
        '
        Me.clt_check_s.DataPropertyName = "clt_check_s"
        Me.clt_check_s.HeaderText = "Export"
        Me.clt_check_s.Name = "clt_check_s"
        Me.clt_check_s.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clt_check_s.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clt_check_s.Width = 50
        '
        'tdate_s
        '
        Me.tdate_s.DataPropertyName = "tdate_s"
        Me.tdate_s.HeaderText = "Trade Date"
        Me.tdate_s.Name = "tdate_s"
        Me.tdate_s.Width = 130
        '
        'clt_code_s
        '
        Me.clt_code_s.DataPropertyName = "clt_code_s"
        Me.clt_code_s.HeaderText = "Acc No"
        Me.clt_code_s.Name = "clt_code_s"
        Me.clt_code_s.Width = 80
        '
        'clt_name_s
        '
        Me.clt_name_s.DataPropertyName = "clt_name_s"
        Me.clt_name_s.HeaderText = "Acc Name"
        Me.clt_name_s.Name = "clt_name_s"
        Me.clt_name_s.Width = 180
        '
        'bank_code_s
        '
        Me.bank_code_s.DataPropertyName = "bank_code_s"
        Me.bank_code_s.HeaderText = "Bank Code"
        Me.bank_code_s.Name = "bank_code_s"
        Me.bank_code_s.Width = 165
        '
        'fund_out_amt_s
        '
        Me.fund_out_amt_s.DataPropertyName = "fund_out_amt_s"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        Me.fund_out_amt_s.DefaultCellStyle = DataGridViewCellStyle3
        Me.fund_out_amt_s.HeaderText = "Amount"
        Me.fund_out_amt_s.Name = "fund_out_amt_s"
        Me.fund_out_amt_s.Width = 120
        '
        'notes_s
        '
        Me.notes_s.DataPropertyName = "notes_s"
        Me.notes_s.HeaderText = "Description"
        Me.notes_s.Name = "notes_s"
        '
        'is_chq_s
        '
        Me.is_chq_s.DataPropertyName = "is_chq_s"
        Me.is_chq_s.HeaderText = "Cash/Chq"
        Me.is_chq_s.Name = "is_chq_s"
        '
        'btnTransfer_s
        '
        Me.btnTransfer_s.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfer_s.Location = New System.Drawing.Point(716, 398)
        Me.btnTransfer_s.Name = "btnTransfer_s"
        Me.btnTransfer_s.Size = New System.Drawing.Size(50, 55)
        Me.btnTransfer_s.TabIndex = 72
        Me.btnTransfer_s.Text = "Import"
        Me.btnTransfer_s.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTransfer_s.UseVisualStyleBackColor = True
        '
        'btnLoad_s
        '
        Me.btnLoad_s.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad_s.Location = New System.Drawing.Point(669, 10)
        Me.btnLoad_s.Name = "btnLoad_s"
        Me.btnLoad_s.Size = New System.Drawing.Size(97, 21)
        Me.btnLoad_s.TabIndex = 103
        Me.btnLoad_s.Text = "Load AFE"
        Me.btnLoad_s.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoad_s.UseVisualStyleBackColor = True
        '
        'dpS
        '
        Me.dpS.CustomFormat = "dd MMM yyyy"
        Me.dpS.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpS.Location = New System.Drawing.Point(78, 10)
        Me.dpS.Name = "dpS"
        Me.dpS.Size = New System.Drawing.Size(119, 21)
        Me.dpS.TabIndex = 94
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(12, 14)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(60, 14)
        Me.Label20.TabIndex = 97
        Me.Label20.Text = "Value Date"
        '
        'TabPage3
        '
        Me.TabPage3.BackColor = System.Drawing.Color.Linen
        Me.TabPage3.Controls.Add(Me.Label15)
        Me.TabPage3.Controls.Add(Me.txtTimeToF)
        Me.TabPage3.Controls.Add(Me.txtDateToF)
        Me.TabPage3.Controls.Add(Me.txtTimeFromF)
        Me.TabPage3.Controls.Add(Me.txtDateFromF)
        Me.TabPage3.Controls.Add(Me.Label17)
        Me.TabPage3.Controls.Add(Me.btnTransfer_f)
        Me.TabPage3.Controls.Add(Me.dgvFundOutF)
        Me.TabPage3.Controls.Add(Me.btnLoad_f)
        Me.TabPage3.Controls.Add(Me.dpF)
        Me.TabPage3.Controls.Add(Me.Label21)
        Me.TabPage3.Location = New System.Drawing.Point(4, 24)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(783, 462)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "AFE(F)"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(224, 14)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(46, 14)
        Me.Label15.TabIndex = 117
        Me.Label15.Text = "From >="
        '
        'txtTimeToF
        '
        Me.txtTimeToF.Enabled = False
        Me.txtTimeToF.Location = New System.Drawing.Point(557, 10)
        Me.txtTimeToF.Name = "txtTimeToF"
        Me.txtTimeToF.Size = New System.Drawing.Size(73, 21)
        Me.txtTimeToF.TabIndex = 116
        '
        'txtDateToF
        '
        Me.txtDateToF.Enabled = False
        Me.txtDateToF.Location = New System.Drawing.Point(473, 10)
        Me.txtDateToF.Name = "txtDateToF"
        Me.txtDateToF.Size = New System.Drawing.Size(78, 21)
        Me.txtDateToF.TabIndex = 115
        '
        'txtTimeFromF
        '
        Me.txtTimeFromF.Enabled = False
        Me.txtTimeFromF.Location = New System.Drawing.Point(360, 10)
        Me.txtTimeFromF.Name = "txtTimeFromF"
        Me.txtTimeFromF.Size = New System.Drawing.Size(73, 21)
        Me.txtTimeFromF.TabIndex = 114
        '
        'txtDateFromF
        '
        Me.txtDateFromF.Enabled = False
        Me.txtDateFromF.Location = New System.Drawing.Point(276, 10)
        Me.txtDateFromF.Name = "txtDateFromF"
        Me.txtDateFromF.Size = New System.Drawing.Size(78, 21)
        Me.txtDateFromF.TabIndex = 113
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(439, 14)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(28, 14)
        Me.Label17.TabIndex = 112
        Me.Label17.Text = "To <"
        '
        'btnTransfer_f
        '
        Me.btnTransfer_f.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnTransfer_f.Location = New System.Drawing.Point(716, 398)
        Me.btnTransfer_f.Name = "btnTransfer_f"
        Me.btnTransfer_f.Size = New System.Drawing.Size(50, 55)
        Me.btnTransfer_f.TabIndex = 105
        Me.btnTransfer_f.Text = "Import"
        Me.btnTransfer_f.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnTransfer_f.UseVisualStyleBackColor = True
        '
        'dgvFundOutF
        '
        Me.dgvFundOutF.AllowUserToAddRows = False
        Me.dgvFundOutF.AllowUserToDeleteRows = False
        Me.dgvFundOutF.BackgroundColor = System.Drawing.Color.Linen
        Me.dgvFundOutF.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFundOutF.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clt_check_f, Me.tdate_f, Me.clt_code_f, Me.clt_name_f, Me.bank_code_f, Me.fund_out_amt_f, Me.notes_f, Me.is_chq_f})
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle6.BackColor = System.Drawing.Color.Linen
        DataGridViewCellStyle6.Font = New System.Drawing.Font("Arial", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvFundOutF.DefaultCellStyle = DataGridViewCellStyle6
        Me.dgvFundOutF.Location = New System.Drawing.Point(15, 42)
        Me.dgvFundOutF.MultiSelect = False
        Me.dgvFundOutF.Name = "dgvFundOutF"
        Me.dgvFundOutF.RowHeadersVisible = False
        Me.dgvFundOutF.RowTemplate.Height = 24
        Me.dgvFundOutF.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvFundOutF.Size = New System.Drawing.Size(751, 350)
        Me.dgvFundOutF.TabIndex = 91
        '
        'clt_check_f
        '
        Me.clt_check_f.DataPropertyName = "clt_check_f"
        Me.clt_check_f.HeaderText = "Export"
        Me.clt_check_f.Name = "clt_check_f"
        Me.clt_check_f.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clt_check_f.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.clt_check_f.Width = 50
        '
        'tdate_f
        '
        Me.tdate_f.DataPropertyName = "tdate_f"
        Me.tdate_f.HeaderText = "Trade Date"
        Me.tdate_f.Name = "tdate_f"
        Me.tdate_f.Width = 130
        '
        'clt_code_f
        '
        Me.clt_code_f.DataPropertyName = "clt_code_f"
        Me.clt_code_f.HeaderText = "Acc No"
        Me.clt_code_f.Name = "clt_code_f"
        Me.clt_code_f.Width = 80
        '
        'clt_name_f
        '
        Me.clt_name_f.DataPropertyName = "clt_name_f"
        Me.clt_name_f.HeaderText = "Acc Name"
        Me.clt_name_f.Name = "clt_name_f"
        Me.clt_name_f.Width = 180
        '
        'bank_code_f
        '
        Me.bank_code_f.DataPropertyName = "bank_code_f"
        Me.bank_code_f.HeaderText = "Bank Code"
        Me.bank_code_f.Name = "bank_code_f"
        Me.bank_code_f.Width = 165
        '
        'fund_out_amt_f
        '
        Me.fund_out_amt_f.DataPropertyName = "fund_out_amt_f"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        Me.fund_out_amt_f.DefaultCellStyle = DataGridViewCellStyle5
        Me.fund_out_amt_f.HeaderText = "Amount"
        Me.fund_out_amt_f.Name = "fund_out_amt_f"
        Me.fund_out_amt_f.Width = 120
        '
        'notes_f
        '
        Me.notes_f.DataPropertyName = "notes_f"
        Me.notes_f.HeaderText = "Description"
        Me.notes_f.Name = "notes_f"
        '
        'is_chq_f
        '
        Me.is_chq_f.DataPropertyName = "is_chq_f"
        Me.is_chq_f.HeaderText = "Cash/Chq"
        Me.is_chq_f.Name = "is_chq_f"
        '
        'btnLoad_f
        '
        Me.btnLoad_f.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLoad_f.Location = New System.Drawing.Point(669, 10)
        Me.btnLoad_f.Name = "btnLoad_f"
        Me.btnLoad_f.Size = New System.Drawing.Size(97, 21)
        Me.btnLoad_f.TabIndex = 104
        Me.btnLoad_f.Text = "Load AFE"
        Me.btnLoad_f.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnLoad_f.UseVisualStyleBackColor = True
        '
        'dpF
        '
        Me.dpF.CustomFormat = "dd MMM yyyy"
        Me.dpF.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dpF.Location = New System.Drawing.Point(78, 10)
        Me.dpF.Name = "dpF"
        Me.dpF.Size = New System.Drawing.Size(119, 21)
        Me.dpF.TabIndex = 82
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(12, 14)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 14)
        Me.Label21.TabIndex = 86
        Me.Label21.Text = "Value Date"
        '
        'TabPage1
        '
        Me.TabPage1.BackColor = System.Drawing.Color.Linen
        Me.TabPage1.Controls.Add(Me.cboFirstPartyAC)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.Label5)
        Me.TabPage1.Controls.Add(Me.Label6)
        Me.TabPage1.Controls.Add(Me.Label7)
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.dgvRecord)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.txtFirstPartyRef)
        Me.TabPage1.Controls.Add(Me.dpVDate)
        Me.TabPage1.Controls.Add(Me.txtPaymentCode)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtClientRef)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.txtClientIDCon)
        Me.TabPage1.Controls.Add(Me.Label11)
        Me.TabPage1.Controls.Add(Me.txtAmt)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Controls.Add(Me.txtClientAC)
        Me.TabPage1.Controls.Add(Me.Label13)
        Me.TabPage1.Controls.Add(Me.txtClientBankBrh)
        Me.TabPage1.Controls.Add(Me.btnEditH)
        Me.TabPage1.Controls.Add(Me.txtClientBankNo)
        Me.TabPage1.Controls.Add(Me.txtClientID)
        Me.TabPage1.Controls.Add(Me.txtClientBankName)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(783, 462)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "File Export"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'cboFirstPartyAC
        '
        Me.cboFirstPartyAC.FormattingEnabled = True
        Me.cboFirstPartyAC.Location = New System.Drawing.Point(146, 11)
        Me.cboFirstPartyAC.MaxLength = 12
        Me.cboFirstPartyAC.Name = "cboFirstPartyAC"
        Me.cboFirstPartyAC.Size = New System.Drawing.Size(121, 23)
        Me.cboFirstPartyAC.TabIndex = 65
        '
        'TabPage4
        '
        Me.TabPage4.Controls.Add(Me.Label25)
        Me.TabPage4.Controls.Add(Me.Label24)
        Me.TabPage4.Controls.Add(Me.Label23)
        Me.TabPage4.Controls.Add(Me.Label22)
        Me.TabPage4.Controls.Add(Me.Label19)
        Me.TabPage4.Controls.Add(Me.txtPayCodeF)
        Me.TabPage4.Controls.Add(Me.txtCommAccF)
        Me.TabPage4.Controls.Add(Me.txtPayCodeS)
        Me.TabPage4.Controls.Add(Me.txtCommAccS)
        Me.TabPage4.Controls.Add(Me.txtCutTime)
        Me.TabPage4.Location = New System.Drawing.Point(4, 24)
        Me.TabPage4.Name = "TabPage4"
        Me.TabPage4.Size = New System.Drawing.Size(783, 462)
        Me.TabPage4.TabIndex = 3
        Me.TabPage4.Text = "Maintenance"
        Me.TabPage4.UseVisualStyleBackColor = True
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(36, 137)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(101, 14)
        Me.Label25.TabIndex = 53
        Me.Label25.Text = "Pay Code (Futures)"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(36, 110)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(144, 14)
        Me.Label24.TabIndex = 52
        Me.Label24.Text = "Comapny Account (Futures)"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(36, 83)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(112, 14)
        Me.Label23.TabIndex = 51
        Me.Label23.Text = "Pay Code (Securities)"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(36, 56)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(155, 14)
        Me.Label22.TabIndex = 50
        Me.Label22.Text = "Company Account (Securities)"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.Location = New System.Drawing.Point(36, 29)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(105, 14)
        Me.Label19.TabIndex = 49
        Me.Label19.Text = "Cut Time (hh:mm:ss)"
        '
        'txtPayCodeF
        '
        Me.txtPayCodeF.Enabled = False
        Me.txtPayCodeF.Location = New System.Drawing.Point(197, 133)
        Me.txtPayCodeF.MaxLength = 3
        Me.txtPayCodeF.Name = "txtPayCodeF"
        Me.txtPayCodeF.Size = New System.Drawing.Size(198, 21)
        Me.txtPayCodeF.TabIndex = 48
        '
        'txtCommAccF
        '
        Me.txtCommAccF.Enabled = False
        Me.txtCommAccF.Location = New System.Drawing.Point(197, 106)
        Me.txtCommAccF.MaxLength = 12
        Me.txtCommAccF.Name = "txtCommAccF"
        Me.txtCommAccF.Size = New System.Drawing.Size(198, 21)
        Me.txtCommAccF.TabIndex = 47
        '
        'txtPayCodeS
        '
        Me.txtPayCodeS.Enabled = False
        Me.txtPayCodeS.Location = New System.Drawing.Point(197, 79)
        Me.txtPayCodeS.MaxLength = 3
        Me.txtPayCodeS.Name = "txtPayCodeS"
        Me.txtPayCodeS.Size = New System.Drawing.Size(198, 21)
        Me.txtPayCodeS.TabIndex = 46
        '
        'txtCommAccS
        '
        Me.txtCommAccS.Enabled = False
        Me.txtCommAccS.Location = New System.Drawing.Point(197, 52)
        Me.txtCommAccS.MaxLength = 12
        Me.txtCommAccS.Name = "txtCommAccS"
        Me.txtCommAccS.Size = New System.Drawing.Size(198, 21)
        Me.txtCommAccS.TabIndex = 45
        '
        'txtCutTime
        '
        Me.txtCutTime.Enabled = False
        Me.txtCutTime.Location = New System.Drawing.Point(197, 25)
        Me.txtCutTime.MaxLength = 8
        Me.txtCutTime.Name = "txtCutTime"
        Me.txtCutTime.Size = New System.Drawing.Size(198, 21)
        Me.txtCutTime.TabIndex = 44
        '
        'lblProcess
        '
        Me.lblProcess.AutoSize = True
        Me.lblProcess.Location = New System.Drawing.Point(9, 542)
        Me.lblProcess.Name = "lblProcess"
        Me.lblProcess.Size = New System.Drawing.Size(70, 15)
        Me.lblProcess.TabIndex = 105
        Me.lblProcess.Text = "Processing"
        '
        'pbarPrint
        '
        Me.pbarPrint.Location = New System.Drawing.Point(12, 560)
        Me.pbarPrint.Name = "pbarPrint"
        Me.pbarPrint.Size = New System.Drawing.Size(405, 16)
        Me.pbarPrint.Style = System.Windows.Forms.ProgressBarStyle.Marquee
        Me.pbarPrint.TabIndex = 104
        '
        'FrmHSBCAutopay
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(814, 616)
        Me.Controls.Add(Me.lblProcess)
        Me.Controls.Add(Me.pbarPrint)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.btnLoad)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.btnDelete)
        Me.Controls.Add(Me.btnEdit)
        Me.KeyPreview = True
        Me.Name = "FrmHSBCAutopay"
        Me.Text = "HSBC Auto Pay"
        Me.Controls.SetChildIndex(Me.btnEdit, 0)
        Me.Controls.SetChildIndex(Me.btnDelete, 0)
        Me.Controls.SetChildIndex(Me.btnAdd, 0)
        Me.Controls.SetChildIndex(Me.btnLoad, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.Controls.SetChildIndex(Me.Label12, 0)
        Me.Controls.SetChildIndex(Me.btnExport, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.TabControl1, 0)
        Me.Controls.SetChildIndex(Me.pbarPrint, 0)
        Me.Controls.SetChildIndex(Me.lblProcess, 0)
        CType(Me.dgvRecord, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        CType(Me.dgvFundOutS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage3.ResumeLayout(False)
        Me.TabPage3.PerformLayout()
        CType(Me.dgvFundOutF, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage4.ResumeLayout(False)
        Me.TabPage4.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtFirstPartyRef As ESL.myTextbox
    Friend WithEvents txtPaymentCode As ESL.myTextbox
    Friend WithEvents txtClientRef As ESL.myTextbox
    Friend WithEvents txtClientIDCon As ESL.myTextbox
    Friend WithEvents txtAmt As ESL.myTextbox
    Friend WithEvents txtClientAC As ESL.myTextbox
    Friend WithEvents txtClientBankBrh As ESL.myTextbox
    Friend WithEvents txtClientBankNo As ESL.myTextbox
    Friend WithEvents txtClientBankName As ESL.myTextbox
    Friend WithEvents txtClientID As ESL.myTextbox
    Friend WithEvents btnEditH As System.Windows.Forms.Button
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dpVDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents dgvRecord As System.Windows.Forms.DataGridView
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents btnExport As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvFundOutS As System.Windows.Forms.DataGridView
    Friend WithEvents TabPage3 As System.Windows.Forms.TabPage
    Friend WithEvents dpF As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents dpS As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents dgvFundOutF As System.Windows.Forms.DataGridView
    Friend WithEvents btnLoad_s As System.Windows.Forms.Button
    Friend WithEvents btnLoad_f As System.Windows.Forms.Button
    Friend WithEvents btnTransfer_s As System.Windows.Forms.Button
    Friend WithEvents btnTransfer_f As System.Windows.Forms.Button
    Friend WithEvents TabPage4 As System.Windows.Forms.TabPage
    Friend WithEvents lblProcess As System.Windows.Forms.Label
    Friend WithEvents pbarPrint As System.Windows.Forms.ProgressBar
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents clientID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientBankName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientBankNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientBankBrh As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientAC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents amt As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientIDCon As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clientRef As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clt_check_s As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tdate_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clt_code_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clt_name_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bank_code_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fund_out_amt_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents notes_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents is_chq_s As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clt_check_f As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents tdate_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clt_code_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clt_name_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents bank_code_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents fund_out_amt_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents notes_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents is_chq_f As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents cboFirstPartyAC As ESL.myComboBox
    Friend WithEvents txtTimeToS As ESL.myTextbox
    Friend WithEvents txtDateToS As ESL.myTextbox
    Friend WithEvents txtTimeFromS As ESL.myTextbox
    Friend WithEvents txtDateFromS As ESL.myTextbox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtTimeToF As ESL.myTextbox
    Friend WithEvents txtDateToF As ESL.myTextbox
    Friend WithEvents txtTimeFromF As ESL.myTextbox
    Friend WithEvents txtDateFromF As ESL.myTextbox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtPayCodeF As ESL.myTextbox
    Friend WithEvents txtCommAccF As ESL.myTextbox
    Friend WithEvents txtPayCodeS As ESL.myTextbox
    Friend WithEvents txtCommAccS As ESL.myTextbox
    Friend WithEvents txtCutTime As ESL.myTextbox

End Class
