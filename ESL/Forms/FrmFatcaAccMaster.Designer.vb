<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmFatcaAccMaster
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
        Me.Label11 = New System.Windows.Forms.Label()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.txtSearchPersonID = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSearchBRID = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtSearchCCDRef = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtSearchAccName = New System.Windows.Forms.TextBox()
        Me.txtSearchAccNo = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.dgvAccMaster = New System.Windows.Forms.DataGridView()
        Me.Account_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Account_Name = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.client_type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BR_ID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CCD_REF = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FATCA_GIIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FATCA_Account_Type = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.US_Citizen = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Born_in_US = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.US_Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.US_Telephone_No = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Fund_Transfer_US = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Authorized_person_with_US_address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.US_in_care_of_or_hold_mail_address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.W_form_signed = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Date_of_Signings = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TIN = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Last_Review_Date = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FATCA_Remarks = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tcClientOptIOMain = New System.Windows.Forms.TabControl()
        Me.TabPage1.SuspendLayout()
        CType(Me.dgvAccMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tcClientOptIOMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(725, 394)
        Me.btnCancel.TabIndex = 7
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(673, 394)
        Me.btnSave.TabIndex = 6
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Arial", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(258, 9)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(222, 22)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "FATCA Account Master"
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.txtSearchPersonID)
        Me.TabPage1.Controls.Add(Me.Label3)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtSearchBRID)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtSearchCCDRef)
        Me.TabPage1.Controls.Add(Me.Label10)
        Me.TabPage1.Controls.Add(Me.txtSearchAccName)
        Me.TabPage1.Controls.Add(Me.txtSearchAccNo)
        Me.TabPage1.Controls.Add(Me.Label9)
        Me.TabPage1.Controls.Add(Me.btnSearch)
        Me.TabPage1.Controls.Add(Me.dgvAccMaster)
        Me.TabPage1.Location = New System.Drawing.Point(4, 24)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(756, 330)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Client Master"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'txtSearchPersonID
        '
        Me.txtSearchPersonID.Location = New System.Drawing.Point(481, 8)
        Me.txtSearchPersonID.Name = "txtSearchPersonID"
        Me.txtSearchPersonID.Size = New System.Drawing.Size(100, 21)
        Me.txtSearchPersonID.TabIndex = 5
        Me.txtSearchPersonID.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(416, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 15)
        Me.Label3.TabIndex = 10
        Me.Label3.Text = "PersonID"
        Me.Label3.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(206, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(39, 15)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "BR ID"
        '
        'txtSearchBRID
        '
        Me.txtSearchBRID.Location = New System.Drawing.Point(306, 39)
        Me.txtSearchBRID.Name = "txtSearchBRID"
        Me.txtSearchBRID.Size = New System.Drawing.Size(100, 21)
        Me.txtSearchBRID.TabIndex = 4
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(56, 15)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "CCD Ref"
        '
        'txtSearchCCDRef
        '
        Me.txtSearchCCDRef.Location = New System.Drawing.Point(95, 39)
        Me.txtSearchCCDRef.Name = "txtSearchCCDRef"
        Me.txtSearchCCDRef.Size = New System.Drawing.Size(100, 21)
        Me.txtSearchCCDRef.TabIndex = 3
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(206, 10)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(87, 15)
        Me.Label10.TabIndex = 5
        Me.Label10.Text = "Account Name"
        '
        'txtSearchAccName
        '
        Me.txtSearchAccName.Location = New System.Drawing.Point(306, 7)
        Me.txtSearchAccName.Name = "txtSearchAccName"
        Me.txtSearchAccName.Size = New System.Drawing.Size(100, 21)
        Me.txtSearchAccName.TabIndex = 2
        '
        'txtSearchAccNo
        '
        Me.txtSearchAccNo.Location = New System.Drawing.Point(95, 8)
        Me.txtSearchAccNo.Name = "txtSearchAccNo"
        Me.txtSearchAccNo.Size = New System.Drawing.Size(100, 21)
        Me.txtSearchAccNo.TabIndex = 1
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 10)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 15)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Account No."
        '
        'btnSearch
        '
        Me.btnSearch.Location = New System.Drawing.Point(419, 38)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 23)
        Me.btnSearch.TabIndex = 6
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'dgvAccMaster
        '
        Me.dgvAccMaster.AllowUserToAddRows = False
        Me.dgvAccMaster.AllowUserToDeleteRows = False
        Me.dgvAccMaster.AllowUserToResizeRows = False
        Me.dgvAccMaster.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Account_No, Me.Account_Name, Me.client_type, Me.BR_ID, Me.CCD_REF, Me.FATCA_GIIN, Me.FATCA_Account_Type, Me.US_Citizen, Me.Born_in_US, Me.US_Address, Me.US_Telephone_No, Me.Fund_Transfer_US, Me.Authorized_person_with_US_address, Me.US_in_care_of_or_hold_mail_address, Me.W_form_signed, Me.Date_of_Signings, Me.TIN, Me.Last_Review_Date, Me.FATCA_Remarks})
        Me.dgvAccMaster.Location = New System.Drawing.Point(9, 67)
        Me.dgvAccMaster.MultiSelect = False
        Me.dgvAccMaster.Name = "dgvAccMaster"
        Me.dgvAccMaster.ReadOnly = True
        Me.dgvAccMaster.RowHeadersVisible = False
        Me.dgvAccMaster.RowTemplate.Height = 24
        Me.dgvAccMaster.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAccMaster.Size = New System.Drawing.Size(746, 255)
        Me.dgvAccMaster.TabIndex = 0
        '
        'Account_No
        '
        Me.Account_No.DataPropertyName = "Account_No"
        Me.Account_No.HeaderText = "Account_No"
        Me.Account_No.Name = "Account_No"
        Me.Account_No.ReadOnly = True
        '
        'Account_Name
        '
        Me.Account_Name.DataPropertyName = "Account_Name"
        Me.Account_Name.HeaderText = "Account_Name"
        Me.Account_Name.Name = "Account_Name"
        Me.Account_Name.ReadOnly = True
        Me.Account_Name.Width = 130
        '
        'client_type
        '
        Me.client_type.DataPropertyName = "client_type"
        Me.client_type.HeaderText = "Account_Type"
        Me.client_type.Name = "client_type"
        Me.client_type.ReadOnly = True
        '
        'BR_ID
        '
        Me.BR_ID.DataPropertyName = "br_id"
        Me.BR_ID.HeaderText = "BR_ID"
        Me.BR_ID.Name = "BR_ID"
        Me.BR_ID.ReadOnly = True
        '
        'CCD_REF
        '
        Me.CCD_REF.DataPropertyName = "ccd_ref"
        Me.CCD_REF.HeaderText = "CCD_REF"
        Me.CCD_REF.Name = "CCD_REF"
        Me.CCD_REF.ReadOnly = True
        '
        'FATCA_GIIN
        '
        Me.FATCA_GIIN.DataPropertyName = "FATCA_GIIN"
        Me.FATCA_GIIN.HeaderText = "FATCA_GIIN"
        Me.FATCA_GIIN.MaxInputLength = 19
        Me.FATCA_GIIN.Name = "FATCA_GIIN"
        Me.FATCA_GIIN.ReadOnly = True
        Me.FATCA_GIIN.Width = 140
        '
        'FATCA_Account_Type
        '
        Me.FATCA_Account_Type.DataPropertyName = "FATCA_Account_Type"
        Me.FATCA_Account_Type.HeaderText = "FATCA_Account_Type"
        Me.FATCA_Account_Type.Name = "FATCA_Account_Type"
        Me.FATCA_Account_Type.ReadOnly = True
        Me.FATCA_Account_Type.Width = 130
        '
        'US_Citizen
        '
        Me.US_Citizen.DataPropertyName = "US_Citizen"
        Me.US_Citizen.HeaderText = "US_Citizen/Resident"
        Me.US_Citizen.Name = "US_Citizen"
        Me.US_Citizen.ReadOnly = True
        Me.US_Citizen.Width = 130
        '
        'Born_in_US
        '
        Me.Born_in_US.DataPropertyName = "Born_in_US"
        Me.Born_in_US.HeaderText = "Born_in_US"
        Me.Born_in_US.Name = "Born_in_US"
        Me.Born_in_US.ReadOnly = True
        '
        'US_Address
        '
        Me.US_Address.DataPropertyName = "US_Address"
        Me.US_Address.HeaderText = "US_Address"
        Me.US_Address.Name = "US_Address"
        Me.US_Address.ReadOnly = True
        '
        'US_Telephone_No
        '
        Me.US_Telephone_No.DataPropertyName = "US_Telephone_No"
        Me.US_Telephone_No.HeaderText = "US_Telephone_No"
        Me.US_Telephone_No.Name = "US_Telephone_No"
        Me.US_Telephone_No.ReadOnly = True
        Me.US_Telephone_No.Width = 130
        '
        'Fund_Transfer_US
        '
        Me.Fund_Transfer_US.DataPropertyName = "Fund_Transfer_US"
        Me.Fund_Transfer_US.HeaderText = "Fund_Transfer_US"
        Me.Fund_Transfer_US.Name = "Fund_Transfer_US"
        Me.Fund_Transfer_US.ReadOnly = True
        Me.Fund_Transfer_US.Width = 130
        '
        'Authorized_person_with_US_address
        '
        Me.Authorized_person_with_US_address.DataPropertyName = "Authorized_person_with_US_address"
        Me.Authorized_person_with_US_address.HeaderText = "Authorized_person_with_US_address"
        Me.Authorized_person_with_US_address.Name = "Authorized_person_with_US_address"
        Me.Authorized_person_with_US_address.ReadOnly = True
        Me.Authorized_person_with_US_address.Width = 220
        '
        'US_in_care_of_or_hold_mail_address
        '
        Me.US_in_care_of_or_hold_mail_address.DataPropertyName = "US_in_care_of_or_hold_mail_address"
        Me.US_in_care_of_or_hold_mail_address.HeaderText = "US 'in-care-of' or 'hold mail' address?"
        Me.US_in_care_of_or_hold_mail_address.Name = "US_in_care_of_or_hold_mail_address"
        Me.US_in_care_of_or_hold_mail_address.ReadOnly = True
        Me.US_in_care_of_or_hold_mail_address.Width = 240
        '
        'W_form_signed
        '
        Me.W_form_signed.DataPropertyName = "W_form_signed"
        Me.W_form_signed.HeaderText = "W_form_signed"
        Me.W_form_signed.Name = "W_form_signed"
        Me.W_form_signed.ReadOnly = True
        '
        'Date_of_Signings
        '
        Me.Date_of_Signings.DataPropertyName = "Date_of_Signings"
        Me.Date_of_Signings.HeaderText = "Date_of_Signings"
        Me.Date_of_Signings.Name = "Date_of_Signings"
        Me.Date_of_Signings.ReadOnly = True
        '
        'TIN
        '
        Me.TIN.DataPropertyName = "TIN"
        Me.TIN.HeaderText = "EIN/SSN"
        Me.TIN.Name = "TIN"
        Me.TIN.ReadOnly = True
        '
        'Last_Review_Date
        '
        Me.Last_Review_Date.DataPropertyName = "Last_Review_Date"
        Me.Last_Review_Date.HeaderText = "Last_Review_Date"
        Me.Last_Review_Date.Name = "Last_Review_Date"
        Me.Last_Review_Date.ReadOnly = True
        Me.Last_Review_Date.Width = 120
        '
        'FATCA_Remarks
        '
        Me.FATCA_Remarks.DataPropertyName = "FATCA_Remarks"
        Me.FATCA_Remarks.HeaderText = "FATCA_Remarks"
        Me.FATCA_Remarks.Name = "FATCA_Remarks"
        Me.FATCA_Remarks.ReadOnly = True
        '
        'tcClientOptIOMain
        '
        Me.tcClientOptIOMain.Controls.Add(Me.TabPage1)
        Me.tcClientOptIOMain.Font = New System.Drawing.Font("Arial", 9.0!)
        Me.tcClientOptIOMain.Location = New System.Drawing.Point(12, 34)
        Me.tcClientOptIOMain.Name = "tcClientOptIOMain"
        Me.tcClientOptIOMain.SelectedIndex = 0
        Me.tcClientOptIOMain.Size = New System.Drawing.Size(764, 358)
        Me.tcClientOptIOMain.TabIndex = 8
        '
        'FrmFatcaAccMaster
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.ClientSize = New System.Drawing.Size(794, 454)
        Me.Controls.Add(Me.tcClientOptIOMain)
        Me.Controls.Add(Me.Label11)
        Me.KeyPreview = True
        Me.Name = "FrmFatcaAccMaster"
        Me.Text = "FATCA Account Master"
        Me.Controls.SetChildIndex(Me.Label11, 0)
        Me.Controls.SetChildIndex(Me.tcClientOptIOMain, 0)
        Me.Controls.SetChildIndex(Me.btnCancel, 0)
        Me.Controls.SetChildIndex(Me.btnSave, 0)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        CType(Me.dgvAccMaster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tcClientOptIOMain.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtSearchAccName As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchAccNo As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents dgvAccMaster As System.Windows.Forms.DataGridView
    Friend WithEvents tcClientOptIOMain As System.Windows.Forms.TabControl
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSearchBRID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtSearchCCDRef As System.Windows.Forms.TextBox
    Friend WithEvents txtSearchPersonID As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Account_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Account_Name As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents client_type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents BR_ID As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CCD_REF As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FATCA_GIIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FATCA_Account_Type As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents US_Citizen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Born_in_US As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents US_Address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents US_Telephone_No As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Fund_Transfer_US As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Authorized_person_with_US_address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents US_in_care_of_or_hold_mail_address As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents W_form_signed As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Date_of_Signings As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TIN As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Last_Review_Date As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents FATCA_Remarks As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
