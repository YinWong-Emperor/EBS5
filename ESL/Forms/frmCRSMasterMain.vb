
Public Class frmCRSMasterMain

    Dim cls As New clsCRSMasterMain
    Private strAccType As String = "Securities"
    Dim frmDetail As New frmCRSMasterDetail
    Dim pFrmStatus As EnumFormStatus
    Private canNew As Boolean = False
    Private canDelete As Boolean = False

#Region "Event"
    Private Sub frmCRSMasterMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.LoadCmb()
        btnSearch_Click(Nothing, System.EventArgs.Empty)
    End Sub


    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SetStatus(EnumFormStatus.Loading)
        Me.strAccType = IIf(Me.rbSecurities.Checked, "Securities", "Futures")
        Dim dt As DataTable = cls.FncSearch(strAccType, Me.cmbCRSType.SelectedValue.ToString.Trim, Me.txtAccno.Text.Trim)
        Me.dgvCRSMaster.AutoGenerateColumns = False
        Me.dgvCRSMaster.DataSource = dt
        Me.btnNew.Visible = False
        Me.btnDelete.Visible = False
        If Me.cmbCRSType.SelectedValue = "CP" Then
            Me.btnDelete.Visible = True
        ElseIf Me.cmbCRSType.SelectedValue = "E" Then
            Me.btnNew.Visible = True
        End If
        SetStatus(EnumFormStatus.Search)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        frmDetail.SetValues(
            EnumFormStatus.New,
            CInt(Me.GetDgvSelectedString("Mid")),
            Me.GetDgvSelectedString("Accno"),
            strAccType,
            "Controlling Person",
            Me.GetDgvSelectedString("ClientName"),
            Me.GetDgvSelectedString("Firstname"),
            Me.GetDgvSelectedString("LastName"),
            Me.GetDgvSelectedString("AccHolderType"),
            Me.GetDgvSelectedString("CPType"),
            Me.GetDgvSelectedString("ResCountryCode"),
            Me.GetDgvSelectedString("TIN"),
            Me.GetDgvSelectedString("TINIssueBy"),
            Me.GetDgvSelectedString("LegalAddressType"),
            Me.GetDgvSelectedString("AddressCountryCode"),
            Me.GetDgvSelectedString("AddressFree"),
            Me.GetDgvSelectedString("BirthDate"),
            Me.GetDgvSelectedString("BirthCountryCode"),
            Me.GetDgvSelectedString("BirthCity"))
        frmDetail.ShowDialog()
        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click
        frmDetail.SetValues(
            EnumFormStatus.Edit,
            CInt(Me.GetDgvSelectedString("Mid")),
            Me.GetDgvSelectedString("Accno"),
            strAccType,
            Me.GetDgvSelectedString("CrsType"),
            Me.GetDgvSelectedString("ClientName"),
            Me.GetDgvSelectedString("Firstname"),
            Me.GetDgvSelectedString("LastName"),
            Me.GetDgvSelectedString("AccHolderType"),
            Me.GetDgvSelectedString("CPType"),
            Me.GetDgvSelectedString("ResCountryCode"),
            Me.GetDgvSelectedString("TIN"),
            Me.GetDgvSelectedString("TINIssueBy"),
            Me.GetDgvSelectedString("LegalAddressType"),
            Me.GetDgvSelectedString("AddressCountryCode"),
            Me.GetDgvSelectedString("AddressFree"),
            Me.GetDgvSelectedString("BirthDate"),
            Me.GetDgvSelectedString("BirthCountryCode"),
            Me.GetDgvSelectedString("BirthCity"))
        frmDetail.ShowDialog()
        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        frmDetail.SetValues(
            EnumFormStatus.Delete,
            CInt(Me.GetDgvSelectedString("Mid")),
            Me.GetDgvSelectedString("Accno"),
            strAccType,
            Me.GetDgvSelectedString("CrsType"),
            Me.GetDgvSelectedString("ClientName"),
            Me.GetDgvSelectedString("Firstname"),
            Me.GetDgvSelectedString("LastName"),
            Me.GetDgvSelectedString("AccHolderType"),
            Me.GetDgvSelectedString("CPType"),
            Me.GetDgvSelectedString("ResCountryCode"),
            Me.GetDgvSelectedString("TIN"),
            Me.GetDgvSelectedString("TINIssueBy"),
            Me.GetDgvSelectedString("LegalAddressType"),
            Me.GetDgvSelectedString("AddressCountryCode"),
            Me.GetDgvSelectedString("AddressFree"),
            Me.GetDgvSelectedString("BirthDate"),
            Me.GetDgvSelectedString("BirthCountryCode"),
            Me.GetDgvSelectedString("BirthCity"))
        frmDetail.ShowDialog()
        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub dgvClientCheque_SelectionChanged(sender As Object, e As EventArgs) Handles dgvCRSMaster.SelectionChanged
        'pbIsGridSelected = Not Me.dgvCRSMaster.CurrentRow Is Nothing
        Me.CheckCurrentRow()
        SetStatus(pFrmStatus)
    End Sub

    Private Sub dgvClientCheque_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvCRSMaster.DataSourceChanged
        'pbIsGridSelected = Not Me.dgvCRSMaster.CurrentRow Is Nothing
        Me.CheckCurrentRow()
        SetStatus(pFrmStatus)
    End Sub

#End Region


#Region "Private Function"

    Private Sub LoadCmb()
        Dim crsTypes As ArrayList = New ArrayList()
        crsTypes.Add(New DictionaryEntry("", ""))
        crsTypes.Add(New DictionaryEntry("I", "Individual"))
        crsTypes.Add(New DictionaryEntry("J", "Joint"))
        crsTypes.Add(New DictionaryEntry("E", "Entity"))
        crsTypes.Add(New DictionaryEntry("CP", "Controlling Person"))

        Me.cmbCRSType.Items.Clear()

        Me.cmbCRSType.DataSource = crsTypes
        Me.cmbCRSType.DisplayMember = "Value"
        Me.cmbCRSType.ValueMember = "Key"

        Me.dtpRetrunYear.Value = Date.Now().AddYears(-1)
        Me.cmbCRSType.SelectedValue = "E"
    End Sub

    Private Sub CheckCurrentRow()
        If Me.dgvCRSMaster.CurrentRow Is Nothing Then
            Me.pFrmStatus = EnumFormStatus.Invalid
        Else
            Dim strCRSType As String = Me.GetDgvSelectedString("CrsType")
            If strCRSType = "Entity" And (Me.GetDgvSelectedString("AccHolderType") = "CRS101" And Me.GetDgvSelectedString("AccHolderType") <> "") Then
                canNew = True
                Return
            ElseIf strCRSType = "Controlling Person" Then
                canDelete = True
                Return
            End If
            canNew = False
            canDelete = False
            Me.pFrmStatus = EnumFormStatus.Search
        End If
    End Sub

    Private Sub SetStatus(ByVal status As EnumFormStatus)

        ' 设置搜索状态
        Me.dtpRetrunYear.Enabled = status = EnumFormStatus.Search Or EnumFormStatus.New Or EnumFormStatus.Delete
        Me.rbExportFutures.Enabled = status = EnumFormStatus.Search Or EnumFormStatus.New Or EnumFormStatus.Delete
        Me.rbExportSecurities.Enabled = status = EnumFormStatus.Search Or EnumFormStatus.New Or EnumFormStatus.Delete
        Me.rbSecurities.Enabled = status = EnumFormStatus.Search Or EnumFormStatus.New Or EnumFormStatus.Delete
        Me.rbFutures.Enabled = status = EnumFormStatus.Search Or EnumFormStatus.New Or EnumFormStatus.Delete


        ' 设置编辑状态
        'Me.dgvCRSMaster.Enabled = status = EnumFormStatus.Search Or EnumFormStatus.New Or EnumFormStatus.Delete

        ' 设置按钮状态
        Me.btnSearch.Enabled = Not (status = EnumFormStatus.Invalid) And Not (status = EnumFormStatus.Loading)
        Me.btnExport.Enabled = Not (status = EnumFormStatus.Invalid) And Not (status = EnumFormStatus.Loading)
        Me.btnCancel.Enabled = Not (status = EnumFormStatus.Invalid) And Not (status = EnumFormStatus.Loading)
        Me.btnNew.Enabled = canNew And Not (status = EnumFormStatus.Invalid) And Not (status = EnumFormStatus.Loading)
        Me.btnEdit.Enabled = Not (status = EnumFormStatus.Invalid) And Not (status = EnumFormStatus.Loading)
        Me.btnDelete.Enabled = canDelete And Not (status = EnumFormStatus.Invalid) And Not (status = EnumFormStatus.Loading)

    End Sub

    Private Function GetDgvSelectedString(ByVal columnName As String) As String
        Return GFncNoNullString(Me.dgvCRSMaster.CurrentRow.Cells(columnName).Value).Trim
    End Function

#End Region


#Region "Export"

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click

        SetStatus(EnumFormStatus.Loading)

        Dim strExportAccType = IIf(Me.rbExportSecurities.Checked, "Securities", "Futures")

        Dim strExFile As String = "CRS_" & strExportAccType & "_" & Me.dtpRetrunYear.Value.Year.ToString() & "_" & Format(Date.Now, "yyyyMMddHHmmss") & ".csv"

        If cls.FnExportCRSCSV(strExFile, strExportAccType, Me.dtpRetrunYear.Value.Year) Then
            GSubShowInfo("Export has completed. Plese found xml file in  " & GStrExptDir & strExFile)
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If

        SetStatus(EnumFormStatus.Search)
    End Sub

#End Region

End Class