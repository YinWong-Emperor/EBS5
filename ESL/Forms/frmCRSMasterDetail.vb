

Public Class frmCRSMasterDetail

    Dim cls As New clsCRSMasterMain

    Private prvMid As Integer
    Private prvAccno As String
    Private prvAccType As String
    Private prvCrsType As String
    Private prvClientName As String
    Private prvFstName As String
    Private prvLastName As String
    Private prvAccHolderType As String
    Private prvCPType As String
    Private prvResCCode As String
    Private prvTIN As String
    Private prvTinIssueBy As String
    Private prvLegalAddrType As String
    Private prvAddrCCode As String
    Private prvAddr As String
    Private prvBirthDate As String
    Private prvBirthCCode As String
    Private prvBirthCity As String
    Private prvOpenedMode As EnumFormStatus


    Private Sub frmCRSMasterDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LoadDetail()
        Me.GetValue()
        Me.SetStatus()
    End Sub

#Region "Load"

    Public Sub LoadDetail()
        Dim dtCountryCode As DataTable = cls.FnGetCountryCode()
        Dim emptyRow As DataRow
        emptyRow = dtCountryCode.NewRow()
        emptyRow("TEXT") = ""
        emptyRow("VALUE") = ""
        dtCountryCode.Rows.InsertAt(emptyRow, 0)

        Me.cmbAddressCountryCode.DataSource = dtCountryCode.Copy()
        Me.cmbAddressCountryCode.DisplayMember = "TEXT"
        Me.cmbAddressCountryCode.ValueMember = "VALUE"


        Me.cmbResCountryCode.DataSource = dtCountryCode.Copy()
        Me.cmbResCountryCode.DisplayMember = "TEXT"
        Me.cmbResCountryCode.ValueMember = "VALUE"


        Me.cmbTINIssueBy.DataSource = dtCountryCode.Copy()
        Me.cmbTINIssueBy.DisplayMember = "TEXT"
        Me.cmbTINIssueBy.ValueMember = "VALUE"


        Me.cmbBrithCountryCode.DataSource = dtCountryCode.Copy()
        Me.cmbBrithCountryCode.DisplayMember = "TEXT"
        Me.cmbBrithCountryCode.ValueMember = "VALUE"

        Dim accHolderTypes As ArrayList = New ArrayList()
        accHolderTypes.Add(New DictionaryEntry("", ""))
        accHolderTypes.Add(New DictionaryEntry("CRS101", "CRS101 - Passive Non-Financial One or more controlling person that is a Reportable Person"))
        accHolderTypes.Add(New DictionaryEntry("CRS102", "CRS102 - Reportable Person"))
        accHolderTypes.Add(New DictionaryEntry("CRS103", "CRS103 - Passive Non-Financial Entity that is a Reportable Person"))

        Me.cmbAccountHolderType.DataSource = accHolderTypes
        Me.cmbAccountHolderType.DisplayMember = "Value"
        Me.cmbAccountHolderType.ValueMember = "Key"

        Dim cpTypes As ArrayList = New ArrayList()
        cpTypes.Add(New DictionaryEntry("", ""))
        cpTypes.Add(New DictionaryEntry("CRS801", "CRS801 - CP of legal person – ownership"))
        cpTypes.Add(New DictionaryEntry("CRS802", "CRS802 - CP of legal person – other means"))
        cpTypes.Add(New DictionaryEntry("CRS803", "CRS803 - CP of legal person – senior managing official"))
        cpTypes.Add(New DictionaryEntry("CRS804", "CRS804 - CP of legal arrangement – trust – settlor"))
        cpTypes.Add(New DictionaryEntry("CRS805", "CRS805 - CP of legal arrangement – trust – trustee"))
        cpTypes.Add(New DictionaryEntry("CRS806", "CRS806 - CP of legal arrangement – trust – protector"))
        cpTypes.Add(New DictionaryEntry("CRS807", "CRS807 - CP of legal arrangement – trust – beneficiary"))
        cpTypes.Add(New DictionaryEntry("CRS808", "CRS808 - CP of legal arrangement – trust – other"))
        cpTypes.Add(New DictionaryEntry("CRS809", "CRS809 - CP of legal arrangement – other – settlor-equivalent"))
        cpTypes.Add(New DictionaryEntry("CRS810", "CRS810 - CP of legal arrangement – other – trustee-equivalent"))
        cpTypes.Add(New DictionaryEntry("CRS811", "CRS811 - CP of legal arrangement – other – protector-equivalent"))
        cpTypes.Add(New DictionaryEntry("CRS812", "CRS812 - CP of legal arrangement – other – beneficiary-equivalent"))
        cpTypes.Add(New DictionaryEntry("CRS813", "CRS813 - CP of legal arrangement – other – other-equivalent"))

        Me.cmbCPType.DataSource = cpTypes
        Me.cmbCPType.DisplayMember = "Value"
        Me.cmbCPType.ValueMember = "Key"

        Dim legalAddressTypes As ArrayList = New ArrayList()
        legalAddressTypes.Add(New DictionaryEntry("", ""))
        legalAddressTypes.Add(New DictionaryEntry("OECD301", "OECD301 - ResidentialOrBusiness"))
        legalAddressTypes.Add(New DictionaryEntry("OECD302", "OECD302 - Residential"))
        legalAddressTypes.Add(New DictionaryEntry("OECD303", "OECD303 - Business"))
        legalAddressTypes.Add(New DictionaryEntry("OECD304", "OECD304 - RegisteredOffice"))
        legalAddressTypes.Add(New DictionaryEntry("OECD305", "OECD305 - Unspecified"))

        Me.cmbLegalAddressType.DataSource = legalAddressTypes
        Me.cmbLegalAddressType.DisplayMember = "Value"
        Me.cmbLegalAddressType.ValueMember = "Key"

        ''Me.dtpBirthDate.MaxDate = Date.Now().AddYears(-18)

    End Sub

#End Region

#Region "Frm Function"

    Public Sub SetValues(ByVal mode As EnumFormStatus,
                         ByVal mid As Integer,
                          ByVal accno As String,
                          ByVal accType As String,
                          ByVal crsType As String,
                          ByVal clientName As String,
                          ByVal fstName As String,
                          ByVal lastName As String,
                          ByVal accHolderType As String,
                          ByVal cpType As String,
                          ByVal resCCode As String,
                          ByVal tin As String,
                          ByVal tinIssueBy As String,
                          ByVal legalAddrType As String,
                          ByVal addrCCode As String,
                          ByVal addr As String,
                          ByVal birthDate As String,
                          ByVal birthCCode As String,
                          ByVal birthCity As String)
        Me.prvOpenedMode = mode
        Me.prvMid = mid
        Me.prvAccno = accno
        Me.prvAccType = accType
        Me.prvCrsType = crsType.Trim
        Me.prvClientName = clientName
        Me.prvFstName = fstName
        Me.prvLastName = lastName
        Me.prvAccHolderType = accHolderType
        Me.prvCPType = cpType
        Me.prvResCCode = resCCode
        Me.prvTIN = tin
        Me.prvTinIssueBy = tinIssueBy
        Me.prvLegalAddrType = legalAddrType
        Me.prvAddrCCode = addrCCode
        Me.prvAddr = addr
        Me.prvBirthDate = IIf(GFncNoNullString(birthDate) = "", "1900-01-01", birthDate)
        Me.prvBirthCCode = birthCCode
        Me.prvBirthCity = birthCity
    End Sub

    Private Sub GetValue()
        Me.lblAccno.Text = prvAccno
        Me.lblAccountType.Text = prvAccType
        Me.lblCRSType.Text = prvCrsType.Trim
        Me.txtClientName.Text = prvClientName
        Me.txtFirstName.Text = prvFstName
        Me.txtLastName.Text = prvLastName
        Me.cmbAccountHolderType.SelectedValue = prvAccHolderType.Trim
        Me.cmbCPType.SelectedValue = prvCPType.Trim
        Me.cmbResCountryCode.SelectedValue = prvResCCode
        Me.txtTIN.Text = prvTIN
        Me.cmbTINIssueBy.SelectedValue = prvTinIssueBy
        Me.cmbLegalAddressType.SelectedValue = prvLegalAddrType
        Me.cmbAddressCountryCode.SelectedValue = prvAddrCCode
        Me.txtAddressFreeText.Text = prvAddr
        Me.dtpBirthDate.Value = prvBirthDate
        Me.cmbBrithCountryCode.SelectedValue = prvBirthCCode
        Me.txtBrithCity.Text = prvBirthCity
    End Sub

    Public Sub SetStatus()
        If Me.prvOpenedMode = EnumFormStatus.New Or Me.prvOpenedMode = EnumFormStatus.Edit Then
            Me.txtClientName.Enabled = Me.lblCRSType.Text = "Controlling Person"
            Me.txtFirstName.Enabled = Me.lblCRSType.Text = "Controlling Person"
            Me.txtLastName.Enabled = Me.lblCRSType.Text = "Controlling Person"
            Me.txtAddressFreeText.Enabled = Me.lblCRSType.Text = "Controlling Person"
            Me.btnSave.Text = IIf(Me.prvOpenedMode = EnumFormStatus.New, "Add", "Save")
        Else
            Me.btnSave.Text = "Delete"
            Me.txtClientName.Enabled = False
            Me.txtFirstName.Enabled = False
            Me.txtLastName.Enabled = False
            Me.cmbAccountHolderType.Enabled = False
            Me.cmbCPType.Enabled = False
            Me.cmbResCountryCode.Enabled = False
            Me.txtTIN.Enabled = False
            Me.cmbTINIssueBy.Enabled = False
            Me.cmbLegalAddressType.Enabled = False
            Me.cmbAddressCountryCode.Enabled = False
            Me.txtAddressFreeText.Enabled = False
            Me.dtpBirthDate.Enabled = False
            Me.cmbBrithCountryCode.Enabled = False
            Me.txtBrithCity.Enabled = False
        End If

        Me.cmbCPType.Visible = Me.prvCrsType = "Controlling Person"
        Me.lblCPType.Visible = Me.lblCRSType.Text = "Controlling Person"
        Me.cmbAccountHolderType.Visible = Me.prvCrsType <> "Controlling Person"
        Me.lblAccHolderType.Visible = Me.lblCRSType.Text <> "Controlling Person"
    End Sub

    Public Function CheckData() As Boolean
        Dim strCRSType As String = IIf(Me.lblCRSType.Text = "Individual", "I", IIf(Me.lblCRSType.Text = "Joint", "J", IIf(Me.lblCRSType.Text = "Entity", "E", "CP")))
        If strCRSType = "I" Or strCRSType = "J" Or strCRSType = "CP" Then
            If GFncNoNullString(Me.dtpBirthDate.Value) = "" Then
                Me.dtpBirthDate.Value = "1900-01-01"
            Else
                If Date.Now().Year - Me.dtpBirthDate.Value.Year < 18 Then
                    GSubShowInfo("Birth Date Error.The customer needs to be an adult.")
                    Return False
                End If
            End If
        End If
        Return True

    End Function

#End Region

#Region "Event"

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        If (GSubShowYNConfirm(GFncGetSysMsg(10)) <> Windows.Forms.DialogResult.Yes) Then
            Return
        End If

        Dim strCRSType As String = IIf(Me.lblCRSType.Text = "Individual", "I", IIf(Me.lblCRSType.Text = "Joint", "J", IIf(Me.lblCRSType.Text = "Entity", "E", "CP")))
        Dim result As Integer = 0

        If Me.prvOpenedMode = EnumFormStatus.New Then
            If Not Me.CheckData() Then
                Return
            End If
            result = cls.FnAddCRSMaster(Me.lblAccno.Text, Me.lblAccountType.Text, Me.txtFirstName.Text, Me.txtLastName.Text, Me.cmbCPType.SelectedValue, _
                               Me.cmbResCountryCode.SelectedValue, Me.txtTIN.Text, Me.cmbTINIssueBy.SelectedValue, Me.cmbLegalAddressType.SelectedValue, _
                               Me.cmbAddressCountryCode.SelectedValue, Me.txtAddressFreeText.Text, Me.dtpBirthDate.Value, Me.cmbBrithCountryCode.SelectedValue, Me.txtBrithCity.Text)
        ElseIf Me.prvOpenedMode = EnumFormStatus.Edit Then
            If Not Me.CheckData() Then
                Return
            End If
            result = cls.FnUpdateCRSMaster(Me.prvMid, Me.lblAccno.Text, Me.lblAccountType.Text, strCRSType, _
                                           Me.txtFirstName.Text, Me.txtLastName.Text, Me.cmbAccountHolderType.SelectedValue, Me.cmbCPType.SelectedValue, _
                               Me.cmbResCountryCode.SelectedValue, Me.txtTIN.Text, Me.cmbTINIssueBy.SelectedValue, Me.cmbLegalAddressType.SelectedValue, _
                               Me.cmbAddressCountryCode.SelectedValue, Me.txtAddressFreeText.Text, Me.dtpBirthDate.Value, Me.cmbBrithCountryCode.SelectedValue, Me.txtBrithCity.Text)
        ElseIf Me.prvOpenedMode = EnumFormStatus.Delete Then
            result = cls.FnDeleteCRSMaster(Me.prvMid, Me.lblAccno.Text, Me.lblAccountType.Text, Me.txtFirstName.Text, Me.txtLastName.Text)
        End If

        If result = 1 Then
            GSubShowInfo(btnSave.Text & " successfully")
        ElseIf result = 2 Then
            GSubShowInfo("Controlling Person is exists.")
            Return
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

#End Region

End Class