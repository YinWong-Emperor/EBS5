Imports System.Data.SqlClient
Imports System.Configuration

Imports System.Globalization
Imports System.Reflection
Imports System.Threading
Public Class FrmFatcaIJAccProfile
    Dim cls As New ClsFatcaIJAccProfile
    Dim type As String = ""
    Private psAccno As String
    Private psAccname As String
    Private psClienttype As String
    Private initCCDRef As String
    Private initPersonID As String

    Private relatedACRemarks As String
    Private relatedACFTAD As String
    Private relatedACOTAD As String
    Private _tabSelectDisabled As Boolean

    Dim pstrFATCA_Account_Type As String = ""
    Dim pstrFATCA_GIIN As String = ""
    Dim pstrNatureS As String = ""
    Dim pstrUS_in_care_of_or_hold_mail_address As String = ""
    Dim pstrUS_Citizen As Char = ""
    Dim pstrBorn_in_US As String = ""
    Dim pstrUS_Address As String = ""
    Dim pstrUS_Telephone_No As String = ""
    Dim pstrFund_Transfer_US As String = ""
    Dim pstrAuthorized_person_with_US_address As String = ""
    Dim pstrW_form_signed As String = ""
    Dim pdtDate_of_Signings As String = DateTime.Now
    Dim pstrTIN As String = ""
    Dim pdtLast_Review_Date As String = DateTime.Now
    Dim pstrFATCA_Remarks As String = ""

    Private psFMMAMKServStartDate As String
    Private psFMSGServStartDate As String
    Private psFMSSEServStartDate As String
    Private psFMRiskDisclosure As String
    Private psFMSZENServStartDate As String
    Private psFMUSServStartDate As String
    Private psFMOrderPlacingMode As String
    Private psFMUVOTCMarketStartDate As String
    Private psFMITradeStartDate As String
    Private psFMUSStartDate As String
    Private psFMUSEndDate As String

    Private psFMTPServStartDate As String
    Private psFMPlatform As String
    Private psFMTPAccNo As String
    Private psFMTPUsername As String
    Private psFMRemarks As String

    Private dtThirdPartyMappingForMarketChange As DataTable


    Private Sub RemoveClientProfileTabsByName(ByVal tabname As String)

        Dim i As Integer
        For i = 0 To Me.tcFatcaIJAccProfileMain.TabPages.Count - 1
            If tabname = Me.tcFatcaIJAccProfileMain.TabPages.Item(i).Text.Trim Then
                Me.tcFatcaIJAccProfileMain.TabPages.RemoveAt(i)
                Exit For
            End If
        Next i
    End Sub

    Private Sub FrmFatcaIJAccProfile_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load


        Thread.CurrentThread.CurrentCulture = New CultureInfo(GFncGetCulture())
        System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(GFncGetCulture())

        'Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"

        dtpFatcaDOS.Format = DateTimePickerFormat.Custom
        dtpFatcaDOS.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpFatcaLRD.Format = DateTimePickerFormat.Custom
        dtpFatcaLRD.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpRelateACFTAD.Format = DateTimePickerFormat.Custom
        dtpRelateACFTAD.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpRelateACOTAD.Format = DateTimePickerFormat.Custom
        dtpRelateACOTAD.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        RemoveClientProfileTabsByName("Client Background")
        RemoveClientProfileTabsByName("Disc-a/c")
        RemoveClientProfileTabsByName("3rd Party")
        RemoveClientProfileTabsByName("AML")
        RemoveClientProfileTabsByName("Financial Info")


        

        If String.IsNullOrEmpty(initCCDRef) Then
            btnAccountInfoLinkCCDRef.Enabled = True
            btnAccountInfoUnlinkCCDRef.Enabled = False
        Else
            btnAccountInfoLinkCCDRef.Enabled = False
            btnAccountInfoUnlinkCCDRef.Enabled = True
        End If

        RefreshFATCA()
        _tabSelectDisabled = False


    End Sub
    Public Sub SetPersonID(ByVal personID As String)
        initPersonID = personID
    End Sub
    Public Sub SetCCDRef(ByVal ccdRef As String)
        txtAccountInfoCCDRef.Text = ccdRef
        initCCDRef = ccdRef
    End Sub
    Public Sub SetAENo(ByVal aeno As String)
        lblAccountInfoAECode.Text = aeno
    End Sub
    Public Sub SetClientNature(ByVal clientNature As String)
        lblAccountInfoClientNature.Text = clientNature
    End Sub

    Public Sub SetBranchName(ByVal branchName As String)
        lblAccountInfoBranchName.Text = branchName
    End Sub
    Public Sub SetAccNo(ByVal accNo As String)
        lblFatcaAccNo.Text = accNo
        lblAccountInfoAccNo.Text = accNo
        lblRelatedACAccNo.Text = accNo
        lblFMAccNo.Text = accNo
    End Sub
    Public Sub SetAccName(ByVal accName As String)
        lblFatcaAccName.Text = accName
        lblAccountInfoAccName.Text = accName
        lblRelatedACAccName.Text = accName
        lblFMAccName.Text = accName
    End Sub
    Public Sub SetClientType(ByVal clientType As String)
        lblFatcaClientType.Text = clientType
        lblAccountInfoClientType.Text = clientType
        lblFMClientType.Text = clientType
    End Sub
    Private Sub btnFatcaSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFatcaSave.Click
        Dim MyTrans As SqlTransaction = Nothing
        Dim dtCheckAccExist As New DataTable()
        Dim dtMatchedAccList As New DataTable()
        Dim dtIsolatedPrefix As New DataTable()
        Dim strFATCA_Account_Type As String = ""
        Dim strFATCA_GIIN As String = ""
        Dim strUS_in_care_of_or_hold_mail_address As String = ""
        Dim strUS_Citizen As String = ""
        Dim strBorn_in_US As String = ""
        Dim strUS_Address As String = ""
        Dim strUS_Telephone_No As String = ""
        Dim strFund_Transfer_US As String = ""
        Dim strAuthorized_person_with_US_address As String = ""
        Dim strW_form_signed As String = ""
        Dim dtDate_of_Signings As DateTime = New Date(1900, 1, 1)
        Dim dtExpiry_date_w_form As DateTime = New Date(1900, 1, 1)
        Dim strTIN As String = ""
        Dim dtLast_Review_Date As DateTime = DateTime.Now
        Dim strFATCA_Remarks As String = ""
        Dim strAccPrefixFilter As String = ""
        Dim isLinkedPrefix As Boolean = True

        If lblFatcaAccNo.Text = "" Then
            GSubShowWarn(GFncGetSysMsg(124))
            Me.lblFatcaAccNo.Focus()
            Return
        ElseIf rbFatca20.Checked = True And rbFatca01.Checked <> True Then
            GSubShowWarn("The FATCA Type should be 'Non-US' for US Citizen/US resident")
            Return
        ElseIf rbFatca21.Checked = True And rbFatca01.Checked = True Then
            GSubShowWarn("The FATCA Type should be US/Recalcitrant  for US Citizen/US resident")
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            If Not Me.dtpFatcaDOS.Text.Trim.Contains("01/01/1900") And _
               Not Me.dtpFatcaLRD.Text.Trim.Contains("01/01/1900") Then


                Try
                    If pstrNatureS = "Individual" Or pstrNatureS = "Joint" Then
                        If rbFatca00.Checked = True Then
                            strFATCA_Account_Type = rbFatca00.Text
                        ElseIf rbFatca01.Checked = True Then
                            strFATCA_Account_Type = rbFatca01.Text
                        ElseIf rbFatca02.Checked = True Then
                            strFATCA_Account_Type = rbFatca02.Text
                        End If

                    Else
                        If rbFatca03.Checked = True Then
                            strFATCA_Account_Type = rbFatca03.Text
                        ElseIf rbFatca04.Checked = True Then
                            strFATCA_Account_Type = rbFatca04.Text
                        ElseIf rbFatca05.Checked = True Then
                            strFATCA_Account_Type = rbFatca05.Text
                        ElseIf rbFatca06.Checked = True Then
                            strFATCA_Account_Type = rbFatca06.Text
                        ElseIf rbFatca07.Checked = True Then
                            strFATCA_Account_Type = rbFatca07.Text
                        ElseIf rbFatca08.Checked = True Then
                            strFATCA_Account_Type = rbFatca08.Text
                        ElseIf rbFatca09.Checked = True Then
                            strFATCA_Account_Type = rbFatca09.Text
                            'Else
                            'GSubShowInfo(GFncGetSysMsg(121))
                            'Return
                        End If
                    End If

                    If rbFatca10.Checked Then
                        strUS_in_care_of_or_hold_mail_address = "N"
                    ElseIf rbFatca11.Checked Then
                        strUS_in_care_of_or_hold_mail_address = "Y"
                    End If

                    If rbFatca20.Checked Then
                        strUS_Citizen = "N"
                    ElseIf rbFatca21.Checked Then
                        strUS_Citizen = "Y"
                    End If

                    If rbFatca30.Checked Then
                        strBorn_in_US = "N"
                    ElseIf rbFatca31.Checked Then
                        strBorn_in_US = "Y"
                    End If

                    If rbFatca40.Checked Then
                        strUS_Address = "N"
                    ElseIf rbFatca41.Checked Then
                        strUS_Address = "Y"
                    End If

                    If rbFatca50.Checked Then
                        strUS_Telephone_No = "N"
                    ElseIf rbFatca51.Checked Then
                        strUS_Telephone_No = "Y"
                    End If

                    If rbFatca60.Checked Then
                        strFund_Transfer_US = "N"
                    ElseIf rbFatca61.Checked Then
                        strFund_Transfer_US = "Y"
                    End If

                    If rbFatca70.Checked Then
                        strAuthorized_person_with_US_address = "N"
                    ElseIf rbFatca71.Checked Then
                        strAuthorized_person_with_US_address = "Y"
                    End If

                    If rbFatca80.Checked Then
                        strW_form_signed = "N"
                        dtDate_of_Signings = New Date(1900, 1, 1)
                        dtExpiry_date_w_form = New Date(1900, 1, 1)
                    ElseIf rbFatca81.Checked Then
                        strW_form_signed = "Y"
                        dtDate_of_Signings = dtpFatcaDOS.Value
                        dtExpiry_date_w_form = New Date(Year(dtDate_of_Signings) + 3, 12, 31)
                    End If

                    strTIN = GFncSqlQuote(GFncNoNullString(txtFatcaTIN.Text.ToString()))
                    dtLast_Review_Date = dtpFatcaLRD.Value

                    strFATCA_Remarks = GFncSqlQuote(GFncNoNullString(rtxtFatcaRemarks.Text.ToString))

                    strFATCA_GIIN = GFncSqlQuote(GFncNoNullString(txtFatcaGIIN.Text.ToString))

                    dtCheckAccExist = cls.lFnGetClientMasterByAcc(lblFatcaAccNo.Text.Trim(), lblFatcaClientType.Text.Trim()).Tables(0)

                    strAccPrefixFilter = cls.getAccPrefixFilter("acc_no")

                    dtIsolatedPrefix = cls.getIsolatedPrefix()
                    If dtIsolatedPrefix.Rows.Count > 0 Then
                        For Each row As DataRow In dtIsolatedPrefix.Rows
                            isLinkedPrefix = Not Me.lblFatcaAccNo.Text.Trim.StartsWith(row.Item("IsolatedPrefix"))
                            If (Not isLinkedPrefix) Then Exit For
                        Next
                    End If

                    If (isLinkedPrefix) Then
                        dtMatchedAccList = cls.lFncGetAddLinkedAccList(Me.lblFatcaAccNo.Text.Trim, Me.lblFatcaClientType.Text.Trim, strAccPrefixFilter)
                    Else
                        dtMatchedAccList = cls.lFncGetAddIsolatedAccList(Me.lblFatcaAccNo.Text.Trim, Me.lblFatcaClientType.Text.Trim)
                    End If

                    If dtCheckAccExist.Rows.Count > 0 Then
                        type = "Edit"
                        'cls.lFnWriteLog(MyTrans, Me.lblFatcaAccNo.Text, "M", lfncGetLogFATCA(type, MyTrans))
                    Else
                        type = "Add"
                        'cls.lFnWriteLog(MyTrans, Me.lblFatcaAccNo.Text, "A", lfncGetLogFATCA(type, MyTrans))
                    End If
                    Dim logFatca As String = lfncGetLogFATCA(type, Nothing)

                    MyTrans = GSCnSqlConn.BeginTransaction

                    cls.lFnWriteLog(MyTrans, Me.lblFatcaAccNo.Text, If(type = "Edit", "M", "A"), logFatca)

                    For Each row As DataRow In dtMatchedAccList.Rows
                        cls.lFnAddClientMaster(MyTrans, row.Item("acc_no"), row.Item("client_type"), strFATCA_Account_Type, strUS_in_care_of_or_hold_mail_address, strUS_Citizen, strBorn_in_US, strUS_Address, strUS_Telephone_No, strFund_Transfer_US, strAuthorized_person_with_US_address, strW_form_signed, dtDate_of_Signings, dtExpiry_date_w_form, strTIN, dtLast_Review_Date, strFATCA_Remarks, strFATCA_GIIN)
                    Next

                    If (isLinkedPrefix) Then
                        cls.lFnEditLinkedAcc(MyTrans, Me.lblFatcaAccNo.Text.Trim, Me.lblFatcaClientType.Text.Trim, strFATCA_Account_Type, strUS_in_care_of_or_hold_mail_address, strUS_Citizen, strBorn_in_US, strUS_Address, strUS_Telephone_No, strFund_Transfer_US, strAuthorized_person_with_US_address, strW_form_signed, dtDate_of_Signings, dtExpiry_date_w_form, strTIN, dtLast_Review_Date, strFATCA_Remarks, strFATCA_GIIN, initPersonID, strAccPrefixFilter)
                    Else
                        cls.lFnEditIsolatedAcc(MyTrans, Me.lblFatcaAccNo.Text.Trim, Me.lblFatcaClientType.Text.Trim, strFATCA_Account_Type, strUS_in_care_of_or_hold_mail_address, strUS_Citizen, strBorn_in_US, strUS_Address, strUS_Telephone_No, strFund_Transfer_US, strAuthorized_person_with_US_address, strW_form_signed, dtDate_of_Signings, dtExpiry_date_w_form, strTIN, dtLast_Review_Date, strFATCA_Remarks, strFATCA_GIIN, initPersonID)
                    End If

                    MyTrans.Commit()
                    MyTrans = Nothing
                    GSubShowInfo(GFncGetSysMsg(8))


                    lFnFATCAEnableEdit(False, "Save")
                    btnFatcaEdit.Enabled = True
                    btnFatcaCancel.Enabled = False
                    btnFatcaSave.Enabled = False
                    RefreshFATCA()
                Catch ex As Exception

                    If GSCnSqlConn.State <> ConnectionState.Closed Then
                        If (MyTrans IsNot Nothing) Then
                            MyTrans.Rollback()
                        End If
                        GSubWriteErrLog(ex.Message)
                    End If
                End Try

            Else
                MsgBox("Invalid date input")
                btnFatcaCancel_Click(sender, e)
            End If




        Else
            Me.btnFatcaCancel_Click(sender, e)
        End If

        _tabSelectDisabled = False

    End Sub
    Public Function lfncGetLogFATCA(ByVal type As String, ByVal mytrans As SqlTransaction) As String
        Dim Log As String = ""
        Dim strFATCA_acc_type As String = ""
        Dim strFATCA_GIIN As String = ""
        Dim strUS_in_care_of_or_hold_mail_address As String = ""
        Dim strUS_Citizen As String = ""
        Dim strBorn_in_US As String = ""
        Dim strUS_Address As String = ""
        Dim strUS_Telephone_No As String = ""
        Dim strFund_Transfer_US As String = ""
        Dim strAuthorized_person_with_US_address As String = ""
        Dim strW_form_signed As String = ""
        Dim dtDate_of_Signings As DateTime = DateTime.Now
        Dim dtExpiry_date_w_form As DateTime = DateTime.Now
        Dim strTIN As String = ""
        Dim dtLast_Review_Date As DateTime = DateTime.Now
        Dim strFATCA_Remarks As String = ""

        If type = "Add" Then
            If pstrNatureS = "Individual" Or pstrNatureS = "Joint" Then
                If rbFatca00.Checked = True Then
                    strFATCA_acc_type = rbFatca00.Text
                ElseIf rbFatca01.Checked = True Then
                    strFATCA_acc_type = rbFatca01.Text
                ElseIf rbFatca02.Checked = True Then
                    strFATCA_acc_type = rbFatca02.Text
                End If
            Else
                If rbFatca03.Checked = True Then
                    strFATCA_acc_type = rbFatca03.Text
                ElseIf rbFatca04.Checked = True Then
                    strFATCA_acc_type = rbFatca04.Text
                ElseIf rbFatca05.Checked = True Then
                    strFATCA_acc_type = rbFatca05.Text
                ElseIf rbFatca06.Checked = True Then
                    strFATCA_acc_type = rbFatca06.Text
                ElseIf rbFatca07.Checked = True Then
                    strFATCA_acc_type = rbFatca07.Text
                ElseIf rbFatca08.Checked = True Then
                    strFATCA_acc_type = rbFatca08.Text
                ElseIf rbFatca09.Checked = True Then
                    strFATCA_acc_type = rbFatca09.Text
                    'Else
                    'GSubShowInfo(GFncGetSysMsg(121))
                    'Return
                End If
            End If
            If strFATCA_acc_type.Length > 0 Then
                Log += GfncOneFieldLog("FATCA_Account_Type", strFATCA_acc_type)
            End If

            If Me.rbFatca10.Checked = True Then
                strUS_in_care_of_or_hold_mail_address = "N"
            ElseIf Me.rbFatca11.Checked Then
                strUS_in_care_of_or_hold_mail_address = "Y"
            End If
            Log += GfncOneFieldLog("US_in_care_of_or_hold_mail_address", strUS_in_care_of_or_hold_mail_address)

            If Me.rbFatca20.Checked = True Then
                strUS_Citizen = "N"
            ElseIf Me.rbFatca20.Checked Then
                strUS_Citizen = "Y"
            End If
            Log += GfncOneFieldLog("US_Citizen", strUS_Citizen)

            If Me.rbFatca30.Checked = True Then
                strBorn_in_US = "N"
            ElseIf Me.rbFatca31.Checked Then
                strBorn_in_US = "Y"
            End If
            Log += GfncOneFieldLog("Born_in_US", strBorn_in_US)

            If Me.rbFatca40.Checked = True Then
                strUS_Address = "N"
            ElseIf Me.rbFatca41.Checked Then
                strUS_Address = "Y"
            End If
            Log += GfncOneFieldLog("US_Address", strUS_Address)

            If Me.rbFatca50.Checked = True Then
                strUS_Telephone_No = "N"
            ElseIf Me.rbFatca51.Checked Then
                strUS_Telephone_No = "Y"
            End If
            Log += GfncOneFieldLog("US_Telephone_No", strUS_Telephone_No)

            If Me.rbFatca60.Checked = True Then
                strFund_Transfer_US = "N"
            ElseIf Me.rbFatca61.Checked Then
                strFund_Transfer_US = "Y"
            End If
            Log += GfncOneFieldLog("Fund_Transfer_US", strFund_Transfer_US)

            If Me.rbFatca70.Checked = True Then
                strAuthorized_person_with_US_address = "N"
            ElseIf Me.rbFatca71.Checked Then
                strAuthorized_person_with_US_address = "Y"
            End If
            Log += GfncOneFieldLog("Authorized_person_with_US_address", strAuthorized_person_with_US_address)

            If Me.rbFatca80.Checked = True Then
                strW_form_signed = "N"
            ElseIf Me.rbFatca81.Checked = True Then
                strW_form_signed = "Y"
            End If
            Log += GfncOneFieldLog("W_form_signed", strW_form_signed)

            If Me.rbFatca81.Checked = True Then
                dtDate_of_Signings = dtpFatcaDOS.Value
                Log += GfncOneFieldLog("Date_of_Signings", dtDate_of_Signings)
            End If

            strTIN = txtFatcaTIN.Text.ToString
            Log += GfncOneFieldLog("TIN", strTIN)

            dtLast_Review_Date = dtpFatcaLRD.Value

            Log += GfncOneFieldLog("Last_Review_Date", dtLast_Review_Date)

            strFATCA_Remarks = rtxtFatcaRemarks.Text
            Log += GfncOneFieldLog("FATCA_Remarks", strFATCA_Remarks)

            strFATCA_GIIN = txtFatcaGIIN.Text
            Log += GfncOneFieldLog("FATCA_GIIN", strFATCA_GIIN)

        Else

            If type = "Edit" Then
                Dim ds As DataSet = cls.lFnGetAccMasterRecordByAcc(mytrans, GFncSqlQuote(lblFatcaAccNo.Text.Trim()), GFncSqlQuote(lblFatcaClientType.Text.Trim()))
                If pstrNatureS = "Individual" Or pstrNatureS = "Joint" Then
                    If rbFatca00.Checked = True Then
                        strFATCA_acc_type = rbFatca00.Text
                    ElseIf rbFatca01.Checked = True Then
                        strFATCA_acc_type = rbFatca01.Text
                    ElseIf rbFatca02.Checked = True Then
                        strFATCA_acc_type = rbFatca02.Text
                    End If

                Else
                    If rbFatca03.Checked = True Then
                        strFATCA_acc_type = rbFatca03.Text
                    ElseIf rbFatca04.Checked = True Then
                        strFATCA_acc_type = rbFatca04.Text
                    ElseIf rbFatca05.Checked = True Then
                        strFATCA_acc_type = rbFatca05.Text
                    ElseIf rbFatca06.Checked = True Then
                        strFATCA_acc_type = rbFatca06.Text
                    ElseIf rbFatca07.Checked = True Then
                        strFATCA_acc_type = rbFatca07.Text
                    ElseIf rbFatca08.Checked = True Then
                        strFATCA_acc_type = rbFatca08.Text
                    ElseIf rbFatca09.Checked = True Then
                        strFATCA_acc_type = rbFatca09.Text

                        'Else
                        'GSubShowInfo(GFncGetSysMsg(121))
                        'Return
                    End If
                End If

                If strFATCA_acc_type <> GFncNoNullString(ds.Tables(0).Rows(0).Item("FATCA_Account_Type")) Then
                    Log += GfncOneFieldLog("FATCA_Account_Type", GFncNoNullString(ds.Tables(0).Rows(0).Item("FATCA_Account_Type")), strFATCA_acc_type)
                End If

                If Me.rbFatca10.Checked = True Then
                    strUS_in_care_of_or_hold_mail_address = "N"
                ElseIf Me.rbFatca11.Checked Then
                    strUS_in_care_of_or_hold_mail_address = "Y"
                End If

                If strUS_in_care_of_or_hold_mail_address <> GFncNoNullString(ds.Tables(0).Rows(0).Item("US_in_care_of_or_hold_mail_address")) Then
                    Log += GfncOneFieldLog("US_in_care_of_or_hold_mail_address", GFncNoNullString(ds.Tables(0).Rows(0).Item("US_in_care_of_or_hold_mail_address")), strUS_in_care_of_or_hold_mail_address)
                End If

                If Me.rbFatca20.Checked = True Then
                    strUS_Citizen = "N"
                ElseIf Me.rbFatca21.Checked Then
                    strUS_Citizen = "Y"
                End If
                If strUS_Citizen <> GFncNoNullString(ds.Tables(0).Rows(0).Item("US_Citizen")) Then
                    Log += GfncOneFieldLog("US_Citizen", GFncNoNullString(ds.Tables(0).Rows(0).Item("US_Citizen")), strUS_Citizen)
                End If

                If Me.rbFatca30.Checked = True Then
                    strBorn_in_US = "N"
                ElseIf Me.rbFatca31.Checked Then
                    strBorn_in_US = "Y"
                End If
                If strBorn_in_US <> GFncNoNullString(ds.Tables(0).Rows(0).Item("Born_in_US")) Then
                    Log += GfncOneFieldLog("Born_in_US", GFncNoNullString(ds.Tables(0).Rows(0).Item("Born_in_US")), strBorn_in_US)
                End If

                If Me.rbFatca40.Checked = True Then
                    strUS_Address = "N"
                ElseIf Me.rbFatca41.Checked Then
                    strUS_Address = "Y"
                End If
                If strUS_Address <> GFncNoNullString(ds.Tables(0).Rows(0).Item("US_Address")) Then
                    Log += GfncOneFieldLog("US_Address", GFncNoNullString(ds.Tables(0).Rows(0).Item("US_Address")), strUS_Address)
                End If

                If Me.rbFatca50.Checked = True Then
                    strUS_Telephone_No = "N"
                ElseIf Me.rbFatca51.Checked Then
                    strUS_Telephone_No = "Y"
                End If
                If strUS_Telephone_No <> GFncNoNullString(ds.Tables(0).Rows(0).Item("US_Telephone_No")) Then
                    Log += GfncOneFieldLog("US_Telephone_No", GFncNoNullString(ds.Tables(0).Rows(0).Item("US_Telephone_No")), strUS_Telephone_No)
                End If

                If Me.rbFatca60.Checked = True Then
                    strFund_Transfer_US = "N"
                ElseIf Me.rbFatca61.Checked Then
                    strFund_Transfer_US = "Y"
                End If
                If strFund_Transfer_US <> GFncNoNullString(ds.Tables(0).Rows(0).Item("Fund_Transfer_US")) Then
                    Log += GfncOneFieldLog("Fund_Transfer_US", GFncNoNullString(ds.Tables(0).Rows(0).Item("Fund_Transfer_US")), strFund_Transfer_US)
                End If

                If Me.rbFatca70.Checked = True Then
                    strAuthorized_person_with_US_address = "N"
                ElseIf Me.rbFatca71.Checked Then
                    strAuthorized_person_with_US_address = "Y"
                End If
                If strAuthorized_person_with_US_address <> GFncNoNullString(ds.Tables(0).Rows(0).Item("Authorized_person_with_US_address")) Then
                    Log += GfncOneFieldLog("Authorized_person_with_US_address", GFncNoNullString(ds.Tables(0).Rows(0).Item("Authorized_person_with_US_address")), strAuthorized_person_with_US_address)
                End If

                If Me.rbFatca80.Checked = True Then
                    strW_form_signed = "N"
                ElseIf Me.rbFatca81.Checked = True Then
                    strW_form_signed = "Y"
                End If
                If strW_form_signed <> GFncNoNullString(ds.Tables(0).Rows(0).Item("W_form_signed")) Then
                    Log += GfncOneFieldLog("W_form_signed", GFncNoNullString(ds.Tables(0).Rows(0).Item("W_form_signed")), strW_form_signed)
                End If

                If Me.rbFatca81.Checked = True Then
                    dtDate_of_Signings = dtpFatcaDOS.Value

                    If dtDate_of_Signings <> GFncNoNullDate(ds.Tables(0).Rows(0).Item("Date_of_Signings")) Then
                        Log += GfncOneFieldLog("Date_of_Signings", GFncNoNullString(ds.Tables(0).Rows(0).Item("Date_of_Signings")), dtDate_of_Signings)
                    End If
                End If


                strTIN = txtFatcaTIN.Text.ToString
                If strTIN <> GFncNoNullString(ds.Tables(0).Rows(0).Item("TIN")) Then
                    Log += GfncOneFieldLog("TIN", GFncNoNullString(ds.Tables(0).Rows(0).Item("TIN")), strTIN)
                End If

                dtLast_Review_Date = dtpFatcaLRD.Value
                If dtLast_Review_Date <> GFncNoNullDate(ds.Tables(0).Rows(0).Item("Last_Review_Date")) Then
                    Log += GfncOneFieldLog("Last_Review_Date", GFncNoNullString(ds.Tables(0).Rows(0).Item("Last_Review_Date")), dtLast_Review_Date)
                End If

                strFATCA_Remarks = rtxtFatcaRemarks.Text.ToString
                If strFATCA_Remarks <> GFncNoNullString(ds.Tables(0).Rows(0).Item("FATCA_Remarks")) Then
                    Log += GfncOneFieldLog("FATCA_Remarks", GFncNoNullString(ds.Tables(0).Rows(0).Item("FATCA_Remarks")), strFATCA_Remarks)
                End If

                strFATCA_GIIN = txtFatcaGIIN.Text.ToString
                If strFATCA_GIIN <> GFncNoNullString(ds.Tables(0).Rows(0).Item("FATCA_GIIN")) Then
                    Log += GfncOneFieldLog("FATCA_GIIN", GFncNoNullString(ds.Tables(0).Rows(0).Item("FATCA_GIIN")), strFATCA_GIIN)
                End If

            End If
        End If
        Return Log
    End Function
    Private Sub rbFatca00_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFatca00.CheckedChanged
        If rbFatca00.Checked = True Then

            chkNo.Checked = False
        End If

    End Sub

    Private Sub rbFatca80_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFatca80.CheckedChanged
        If rbFatca80.Checked = True Then
            dtpFatcaDOS.CustomFormat = " "  'An empty SPACE
            dtpFatcaDOS.Format = DateTimePickerFormat.Custom
            dtpFatcaDOS.Enabled = False

        End If
    End Sub
    Private Sub rbFatca81_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbFatca81.CheckedChanged
        If type = "Edit" Then
            If rbFatca81.Checked = True Then
                If Not String.IsNullOrEmpty(pdtDate_of_Signings) Then
                    dtpFatcaDOS.Value = pdtDate_of_Signings
                Else
                    dtpFatcaDOS.Value = Date.Now
                End If

                dtpFatcaDOS.Enabled = True
                dtpFatcaDOS.CustomFormat = "dd/MM/yyyy"
                dtpFatcaDOS.Format = DateTimePickerFormat.Custom
            End If
        Else
            dtpFatcaDOS.Enabled = False
        End If

    End Sub
    Private Sub btnFatcaEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFatcaEdit.Click
        lFnFATCAEnableEdit(True, "Edit")
        btnFatcaEdit.Enabled = False
        btnFatcaCancel.Enabled = True
        btnFatcaSave.Enabled = True

        _tabSelectDisabled = True

    End Sub
    Private Sub btnFatcaCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFatcaCancel.Click
        lFnFATCAEnableEdit(False, "Cancel")

        btnFatcaEdit.Enabled = True
        btnFatcaSave.Enabled = False

        If pstrNatureS = "Individual" Or pstrNatureS = "Joint" Then
            If pstrFATCA_Account_Type = "US" Then
                rbFatca00.Checked = True
            ElseIf pstrFATCA_Account_Type = "Non-US" Then
                rbFatca01.Checked = True
            ElseIf pstrFATCA_Account_Type = "Recalcitrant" Then
                rbFatca02.Checked = True
            Else
                rbFatca00.Checked = False
                rbFatca01.Checked = False
                rbFatca02.Checked = False
            End If
        Else
            If pstrFATCA_Account_Type = "PFFI" Then
                rbFatca03.Checked = True
            ElseIf pstrFATCA_Account_Type = "NPFFI" Then
                rbFatca04.Checked = True
            ElseIf pstrFATCA_Account_Type = "NFFE" Then
                rbFatca05.Checked = True
            ElseIf pstrFATCA_Account_Type = "US Entity" Then
                rbFatca06.Checked = True
            ElseIf pstrFATCA_Account_Type = "DCFFI" Then
                rbFatca07.Checked = True
            ElseIf pstrFATCA_Account_Type = "EBO" Then
                rbFatca08.Checked = True
            ElseIf pstrFATCA_Account_Type = "Recalcitrant" Then
                rbFatca09.Checked = True
            Else
                rbFatca03.Checked = False
                rbFatca04.Checked = False
                rbFatca05.Checked = False
                rbFatca06.Checked = False
                rbFatca07.Checked = False
                rbFatca08.Checked = False
                rbFatca09.Checked = False
            End If
        End If

        If pstrUS_in_care_of_or_hold_mail_address = "N" Then
            rbFatca10.Checked = True
        ElseIf pstrUS_in_care_of_or_hold_mail_address = "Y" Then
            rbFatca11.Checked = True
        Else
            rbFatca10.Checked = False
            rbFatca11.Checked = False
        End If

        If pstrUS_Citizen = "N" Then
            rbFatca20.Checked = True
        ElseIf pstrUS_Citizen = "Y" Then
            rbFatca21.Checked = True
        Else
            rbFatca20.Checked = False
            rbFatca21.Checked = False
        End If

        If pstrBorn_in_US = "N" Then
            rbFatca30.Checked = True
        ElseIf pstrBorn_in_US = "Y" Then
            rbFatca31.Checked = True
        Else
            rbFatca30.Checked = False
            rbFatca31.Checked = False
        End If

        If pstrUS_Address = "N" Then
            rbFatca40.Checked = True
        ElseIf pstrUS_Address = "Y" Then
            rbFatca41.Checked = True
        Else
            rbFatca40.Checked = False
            rbFatca41.Checked = False
        End If

        If pstrUS_Telephone_No = "N" Then
            rbFatca50.Checked = True
        ElseIf pstrUS_Telephone_No = "Y" Then
            rbFatca51.Checked = True
        Else
            rbFatca50.Checked = False
            rbFatca51.Checked = False
        End If

        If pstrFund_Transfer_US = "N" Then
            rbFatca60.Checked = True
        ElseIf pstrFund_Transfer_US = "Y" Then
            rbFatca61.Checked = True
        Else
            rbFatca60.Checked = False
            rbFatca61.Checked = False
        End If

        If pstrAuthorized_person_with_US_address = "N" Then
            rbFatca70.Checked = True
        ElseIf pstrAuthorized_person_with_US_address = "Y" Then
            rbFatca71.Checked = True
        Else
            rbFatca70.Checked = False
            rbFatca71.Checked = False
        End If

        chkNo.Checked = False

        If pstrW_form_signed = "N" Then
            rbFatca80.Checked = True
            dtpFatcaDOS.CustomFormat = " "  'An empty SPACE
            dtpFatcaDOS.Format = DateTimePickerFormat.Custom
        ElseIf pstrW_form_signed = "Y" Then
            rbFatca81.Checked = True
            dtpFatcaDOS.CustomFormat = "dd/MM/yyyy"
            dtpFatcaDOS.Format = DateTimePickerFormat.Custom
            dtpFatcaDOS.Value = pdtDate_of_Signings

        Else
            rbFatca80.Checked = False
            rbFatca81.Checked = False
            dtpFatcaDOS.CustomFormat = " "  'An empty SPACE
            dtpFatcaDOS.Format = DateTimePickerFormat.Custom
        End If

        If pstrTIN <> "" Then
            txtFatcaTIN.Text = pstrTIN
        Else
            txtFatcaTIN.Text = ""
        End If


        If pstrFATCA_Remarks <> "" Then
            rtxtFatcaRemarks.Text = pstrFATCA_Remarks
        Else
            rtxtFatcaRemarks.Text = ""
        End If

        If pstrFATCA_GIIN <> "" Then
            txtFatcaGIIN.Text = pstrFATCA_GIIN
        Else
            txtFatcaGIIN.Text = ""
        End If


        If pdtLast_Review_Date <> Date.Now Then
            dtpFatcaLRD.Value = pdtLast_Review_Date
        Else
            dtpFatcaLRD.Value = Date.Now
        End If

        _tabSelectDisabled = False
    End Sub
    Private Sub btnFatcaExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFatcaExit.Click
        FrmFatcaAccMaster.MdiParent = Me.MdiParent
        FrmFatcaAccMaster.Activate()
        Me.Close()
    End Sub
    Private Sub lFnFATCAEnableEdit(ByVal bool As Boolean, ByVal action As String)

        If action = "Edit" Then
            type = "Edit"
        ElseIf action = "Cancel" Then
            type = "Cancel"
        ElseIf action = "Save" Then
            type = "Save"
        ElseIf action = "Load" Then
            type = "Load"
        End If


        gbFatcaAccTypeIndivdual.Enabled = bool
        gbFatcaAccTypeCorp.Enabled = bool
        gbUPGCH.Enabled = bool
        gbUCURFTP.Enabled = bool
        gbBIU.Enabled = bool
        gbUA.Enabled = bool
        gbUTN.Enabled = bool
        gbSIFT.Enabled = bool
        gbAPUSA.Enabled = bool
        gbWFS.Enabled = bool
        chkNo.Enabled = bool
        If type = "Edit" Then
            If rbFatca81.Checked = True Then
                dtpFatcaDOS.Enabled = True
            End If
        Else
            dtpFatcaDOS.Enabled = False
        End If

        txtFatcaTIN.Enabled = bool
        dtpFatcaLRD.Enabled = bool

        rtxtFatcaRemarks.Enabled = bool

        txtFatcaGIIN.Enabled = bool
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        FrmFatcaAccMaster.MdiParent = Me.MdiParent
        FrmFatcaAccMaster.Activate()
        Me.Close()
    End Sub

    Private Sub CheckQ2_7No()
        If rbFatca10.Checked = True Then
            If rbFatca20.Checked = True Then
                If rbFatca30.Checked = True Then
                    If rbFatca40.Checked = True Then
                        If rbFatca50.Checked = True Then
                            If rbFatca60.Checked = True Then
                                If rbFatca70.Checked = True Then
                                    rbFatca01.Checked = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub chkNo_CheckChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkNo.CheckedChanged
        If chkNo.Checked = True Then
            rbFatca10.Checked = True
            rbFatca20.Checked = True
            rbFatca30.Checked = True
            rbFatca40.Checked = True
            rbFatca50.Checked = True
            rbFatca60.Checked = True
            rbFatca70.Checked = True
            rbFatca01.Checked = True

        End If

    End Sub

    Private Sub btnAccountInfoLinkCCDRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountInfoLinkCCDRef.Click
        FrmCCDRefManagement.SetAccNo(Me.lblAccountInfoAccNo.Text.Trim)
        FrmCCDRefManagement.SetClientType(Me.lblAccountInfoClientType.Text.Trim)
        ShowNewForm(FrmCCDRefManagement)
    End Sub

    Private Sub ShowNewForm(ByVal ChildForm As System.Windows.Forms.Form)
        ' Make it a child of this MDI form before showing it
        ChildForm.MdiParent = Me.MdiParent
        ChildForm.Show()
        ChildForm.Activate()
    End Sub

    Private Sub btnAccountInfoUnlinkCCDRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountInfoUnlinkCCDRef.Click
        If MsgBox("Confirm to remove current CCD Ref?", MsgBoxStyle.YesNo) = DialogResult.Yes Then
            InvokeUnlinkCCDRef(Me.lblAccountInfoAccNo.Text.Trim, Me.lblAccountInfoClientType.Text.Trim)
            initCCDRef = String.Empty
            Me.btnAccountInfoUnlinkCCDRef.Enabled = False
            btnAccountInfoLinkCCDRef.Enabled = True
        End If

    End Sub

    Private Sub InvokeUnlinkCCDRef(ByVal selectAccNo As String, ByVal selectAccType As String)
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            Dim rtnCode = cls.lFnUnlinkCCDRef(MyTrans, selectAccNo, selectAccType)

            If rtnCode <= 0 Then
                MsgBox("No row has been updated")
            End If

            MyTrans.Commit()
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                MsgBox("Failed to unlink", MsgBoxStyle.OkOnly)
            End If
        End Try

        MyTrans = Nothing
    End Sub

    Private Sub btnAccountInfoModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountInfoModify.Click
        'textfield 
        Me.txtAccountInfoCCDRef.Enabled = True

        'button field
        btnAccountInfoModify.Enabled = False
        btnAccountInfoCancel.Enabled = True
        btnAccountInfoSave.Enabled = True
        btnAccountInfoExit.Enabled = True

        If Not String.IsNullOrEmpty(initCCDRef) Then
            ' CCD Ref has content 
            btnAccountInfoLinkCCDRef.Enabled = False
            btnAccountInfoUnlinkCCDRef.Enabled = True
        Else
            btnAccountInfoLinkCCDRef.Enabled = True
            btnAccountInfoUnlinkCCDRef.Enabled = False
        End If

        _tabSelectDisabled = True

    End Sub

    Private Sub btnAccountInfoCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountInfoCancel.Click

        'text field
        If Not String.IsNullOrEmpty(initCCDRef) Then
            txtAccountInfoCCDRef.Text = initCCDRef
        Else
            txtAccountInfoCCDRef.Text = String.Empty
        End If

        txtAccountInfoCCDRef.Enabled = False

        'button field
        btnAccountInfoModify.Enabled = True
        btnAccountInfoCancel.Enabled = True
        btnAccountInfoSave.Enabled = False
        btnAccountInfoExit.Enabled = True

        If Not String.IsNullOrEmpty(initCCDRef) Then
            ' CCD Ref has content 
            btnAccountInfoLinkCCDRef.Enabled = False
            btnAccountInfoUnlinkCCDRef.Enabled = True
        Else
            btnAccountInfoLinkCCDRef.Enabled = True
            btnAccountInfoUnlinkCCDRef.Enabled = False
        End If

        _tabSelectDisabled = False

    End Sub
    Private Sub txtAccountInfoCCDRef_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccountInfoCCDRef.KeyUp
        InvokecCDRefInputValidation()
    End Sub

    Private Sub txtAccountInfoCCDRef_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtAccountInfoCCDRef.PreviewKeyDown
        InvokecCDRefInputValidation()
    End Sub

    Private Sub InvokecCDRefInputValidation()
        Dim checkCCDRefTextField As String
        checkCCDRefTextField = txtAccountInfoCCDRef.Text.Trim

        Dim temp As Integer

        If Not String.IsNullOrEmpty(checkCCDRefTextField) And _
           Not Int32.TryParse(checkCCDRefTextField, temp) Then
            MsgBox("CCD Ref does not accept characters", MsgBoxStyle.OkOnly)
            txtAccountInfoCCDRef.Text = String.Empty
        End If
    End Sub

    Private Sub btnAccountInfoSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountInfoSave.Click
        ' Update CCD Ref for current Account No 

        Dim selectCCDRef, selectAccNo, selectAccType As String
        Dim dtCheckAccExist As New DataTable()
        selectAccNo = Me.lblAccountInfoAccNo.Text.Trim
        selectCCDRef = Me.txtAccountInfoCCDRef.Text.Trim
        selectAccType = Me.lblAccountInfoClientType.Text.Trim

        If MsgBox("Confirm to Save?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            If Not String.IsNullOrEmpty(selectAccNo) And _
                Not String.IsNullOrEmpty(selectAccType) And _
                (String.IsNullOrEmpty(selectCCDRef) Or (IsNumeric(selectCCDRef) And selectCCDRef.Length > 0)) Then

                dtCheckAccExist = cls.lFnGetClientMasterByAcc(selectAccNo, selectAccType).Tables(0)

                Dim MyTrans As SqlTransaction = Nothing
                Try
                    MyTrans = GSCnSqlConn.BeginTransaction

                    If dtCheckAccExist.Rows.Count > 0 Then
                        cls.lFnModifyCCDRefWithGivenAccountNo(MyTrans, selectAccNo, selectAccType, selectCCDRef)
                    Else
                        cls.lFnInsertNewCCDRefWithGivenAccountNo(MyTrans, selectAccNo, selectAccType, selectCCDRef)
                    End If

                    MyTrans.Commit()

                    Me.btnAccountInfoSave.Enabled = False
                    Me.txtAccountInfoCCDRef.Enabled = False

                Catch ex As Exception
                    If GSCnSqlConn.State <> ConnectionState.Closed Then
                        If (MyTrans IsNot Nothing) Then
                            MyTrans.Rollback()
                        End If
                        GSubWriteErrLog(ex.Message)
                        MsgBox("Fail to update CCDRef", MsgBoxStyle.OkOnly)
                    End If
                Finally
                    MyTrans = Nothing
                End Try
            ElseIf Not IsNumeric(selectCCDRef) And selectCCDRef.Length > 0 Then
                MsgBox("Input CCD Ref is not a number.")
            End If
        Else
            Me.btnAccountInfoCancel_Click(sender, e)
        End If

        Me.btnAccountInfoModify.Enabled = True
        Me.btnAccountInfoCancel.Enabled = False
        Me.btnAccountInfoSave.Enabled = False

        _tabSelectDisabled = False

    End Sub

    Private Sub btnAccountInfoExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccountInfoExit.Click
        Me.Close()
    End Sub

    Private Sub btnRelatedACModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelatedACModify.Click
        dtpRelateACFTAD.CustomFormat = "dd/MM/yyyy"
        dtpRelateACFTAD.Format = DateTimePickerFormat.Custom

        Dim cur_relatedACFTADDateTime As String = dtpRelateACFTAD.Value.ToString.Trim
        Dim cur_relatedACOTADDateTime As String = dtpRelateACOTAD.Value.ToString.Trim


        If String.IsNullOrEmpty(cur_relatedACFTADDateTime) Or cur_relatedACFTADDateTime.Contains("01/01/1900") Then
            dtpRelateACFTAD.Value = Now
        End If

        ' keep 01/01/1900 as default value before use.
        If String.IsNullOrEmpty(cur_relatedACOTADDateTime) Or cur_relatedACOTADDateTime.Contains("01/01/1900") Then
            dtpRelateACOTAD.Value = #1/1/1900#
        End If


        dtpRelateACFTAD.Enabled = True

        dtpRelateACOTAD.Enabled = True
        rtxtRelatedACRemarks.Enabled = True

        btnRelatedACModify.Enabled = False
        btnRelatedACCancel.Enabled = True
        btnRelatedACSave.Enabled = True
        btnRelatedACExit.Enabled = True

        _tabSelectDisabled = True


    End Sub

    Private Sub tcFatcaIJAccProfileMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcFatcaIJAccProfileMain.SelectedIndexChanged

        ' Disable the tab switching.
        'If _selectTabIndex <> -1 Then
        ' tcFatcaIJAccProfileMain.SelectedTab = tcFatcaIJAccProfileMain.TabPages.Item(_selectTabIndex)
        ' End If


        Dim selectTabCaption As String
        selectTabCaption = Me.tcFatcaIJAccProfileMain.SelectedTab.Text

        Select Case selectTabCaption
            Case "Account Info."
                RefreshAccountInfo()
            Case "Related a/c"
                RefreshRelatedAccountsContent()
            Case "FATCA"
                RefreshFATCA()
            Case "Foreign Market"
                RefreshForeignMarket()
            Case Else
        End Select

    End Sub
    Private Sub RefreshFATCA()
        Dim dt As New DataTable
        If dtpFatcaDOS.Enabled Or (Not dtpFatcaDOS.Enabled And dtpFatcaDOS.Text.Trim <> "") Then
            dtpFatcaDOS.CustomFormat = "dd/MM/yyyy"
            dtpFatcaDOS.Format = DateTimePickerFormat.Custom
        Else
            dtpFatcaDOS.CustomFormat = " "  'An empty SPACE
            dtpFatcaDOS.Format = DateTimePickerFormat.Custom
        End If

        If dtpFatcaLRD.Enabled Or (Not dtpFatcaLRD.Enabled And dtpFatcaLRD.Text.Trim <> "") Then
            dtpFatcaLRD.CustomFormat = "dd/MM/yyyy"
            dtpFatcaLRD.Format = DateTimePickerFormat.Custom
        Else
            dtpFatcaLRD.CustomFormat = " "  'An empty SPACE
            dtpFatcaLRD.Format = DateTimePickerFormat.Custom
        End If

        dt = cls.lFnGetAccMasterRecordByAcc(GFncSqlQuote(lblFatcaAccNo.Text.Trim()), GFncSqlQuote(lblFatcaClientType.Text.Trim())).Tables(0)

        For row As Integer = 0 To dt.Rows.Count - 1
            If Not IsDBNull(dt.Rows(row).Item("FATCA_Account_Type")) Then
            pstrFATCA_Account_Type = dt.Rows(row).Item("FATCA_Account_Type").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("FATCA_GIIN")) Then
            pstrFATCA_GIIN = dt.Rows(row).Item("FATCA_GIIN").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("nature_s")) Then
            pstrNatureS = dt.Rows(row).Item("nature_s").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("US_Citizen")) Then
            pstrUS_Citizen = dt.Rows(row).Item("US_Citizen").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("US_in_care_of_or_hold_mail_address")) Then
            pstrUS_in_care_of_or_hold_mail_address = dt.Rows(row).Item("US_in_care_of_or_hold_mail_address").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("Born_in_US")) Then
            pstrBorn_in_US = dt.Rows(row).Item("Born_in_US").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("US_Address")) Then
            pstrUS_Address = dt.Rows(row).Item("US_Address").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("US_Telephone_No")) Then
            pstrUS_Telephone_No = dt.Rows(row).Item("US_Telephone_No").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("Fund_Transfer_US")) Then
            pstrFund_Transfer_US = dt.Rows(row).Item("Fund_Transfer_US").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("Authorized_person_with_US_address")) Then
            pstrAuthorized_person_with_US_address = dt.Rows(row).Item("Authorized_person_with_US_address").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("W_form_signed")) Then
            pstrW_form_signed = dt.Rows(row).Item("W_form_signed").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("Date_of_Signings")) Then
            pdtDate_of_Signings = dt.Rows(row).Item("Date_of_Signings")
            End If

            If Not IsDBNull(dt.Rows(row).Item("TIN")) Then
            pstrTIN = dt.Rows(row).Item("TIN").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("Last_Review_Date")) Then
            pdtLast_Review_Date = dt.Rows(row).Item("Last_Review_Date")
            End If

            If Not IsDBNull(dt.Rows(row).Item("FATCA_Remarks")) Then
            pstrFATCA_Remarks = dt.Rows(row).Item("FATCA_Remarks").ToString
            End If

            If Not IsDBNull(dt.Rows(row).Item("CCD_Ref")) Then
                SetCCDRef(dt.Rows(row).Item("CCD_Ref").ToString.Trim())
            End If

            If Not IsDBNull(dt.Rows(row).Item("PersonID")) Then
                SetPersonID(dt.Rows(row).Item("PersonID").ToString.Trim())
            End If

        Next
        If pstrNatureS = "Individual" Or pstrNatureS = "Joint" Then
            If pstrFATCA_Account_Type = "US" Then
                rbFatca00.Checked = True
            ElseIf pstrFATCA_Account_Type = "Non-US" Then
                rbFatca01.Checked = True
            ElseIf pstrFATCA_Account_Type = "Recalcitrant" Then
                rbFatca02.Checked = True
            End If
            gbFatcaAccTypeIndivdual.Visible = True
            gbFatcaAccTypeCorp.Visible = False
            lblUSTaxpayerId.Text = "US Taxpayer Identification No. (SSN)"

            lblGIIN.Visible = False         ' Enable GIIN if corp account
            txtFatcaGIIN.Visible = False
        Else
            If pstrFATCA_Account_Type = "PFFI" Then
                rbFatca03.Checked = True
            ElseIf pstrFATCA_Account_Type = "NPFFI" Then
                rbFatca04.Checked = True
            ElseIf pstrFATCA_Account_Type = "NFFE" Then
                rbFatca05.Checked = True
            ElseIf pstrFATCA_Account_Type = "US Entity" Then
                rbFatca06.Checked = True
            ElseIf pstrFATCA_Account_Type = "DCFFI" Then
                rbFatca07.Checked = True
            ElseIf pstrFATCA_Account_Type = "EBO" Then
                rbFatca08.Checked = True
            ElseIf pstrFATCA_Account_Type = "Recalcitrant" Then
                rbFatca09.Checked = True
            End If
            gbFatcaAccTypeIndivdual.Visible = False
            gbFatcaAccTypeCorp.Visible = True
            gbFatcaAccTypeCorp.Location = New Point(282, 82)
            lblUSTaxpayerId.Text = "US Taxpayer Identification No. (EIN)"

            lblGIIN.Visible = True
            txtFatcaGIIN.Visible = True
        End If


        If pstrUS_in_care_of_or_hold_mail_address = "N" Then
            rbFatca10.Checked = True
        ElseIf pstrUS_in_care_of_or_hold_mail_address = "Y" Then
            rbFatca11.Checked = True
        End If

        If pstrUS_Citizen = "N" Then
            rbFatca20.Checked = True
        ElseIf pstrUS_Citizen = "Y" Then
            rbFatca21.Checked = True
        End If

        If pstrBorn_in_US = "N" Then
            rbFatca30.Checked = True
        ElseIf pstrBorn_in_US = "Y" Then
            rbFatca31.Checked = True
        End If

        If pstrUS_Address = "N" Then
            rbFatca40.Checked = True
        ElseIf pstrUS_Address = "Y" Then
            rbFatca41.Checked = True
        End If

        If pstrUS_Telephone_No = "N" Then
            rbFatca50.Checked = True
        ElseIf pstrUS_Telephone_No = "Y" Then
            rbFatca51.Checked = True
        End If

        If pstrFund_Transfer_US = "N" Then
            rbFatca60.Checked = True
        ElseIf pstrFund_Transfer_US = "Y" Then
            rbFatca61.Checked = True
        End If

        If pstrAuthorized_person_with_US_address = "N" Then
            rbFatca70.Checked = True
        ElseIf pstrAuthorized_person_with_US_address = "Y" Then
            rbFatca71.Checked = True
        End If

        dtpFatcaDOS.Enabled = False
        If pstrW_form_signed = "N" Then
            rbFatca80.Checked = True
            dtpFatcaDOS.Enabled = False
            If pdtDate_of_Signings = "" Then

                dtpFatcaDOS.CustomFormat = " "  'An empty SPACE
                dtpFatcaDOS.Format = DateTimePickerFormat.Custom
            Else
                dtpFatcaDOS.Value = pdtDate_of_Signings
            End If
        ElseIf pstrW_form_signed = "Y" Then
            rbFatca81.Checked = True
            dtpFatcaDOS.Enabled = True
            If pdtDate_of_Signings = "" Then
                dtpFatcaDOS.Value = Date.Now
                pdtDate_of_Signings = Date.Now
            Else
                dtpFatcaDOS.Value = pdtDate_of_Signings
            End If
        Else
            dtpFatcaDOS.CustomFormat = " "  'An empty SPACE
            dtpFatcaDOS.Format = DateTimePickerFormat.Custom
        End If

        txtFatcaTIN.Text = pstrTIN

        If pdtLast_Review_Date = "" Then
            dtpFatcaLRD.Value = Date.Now
            pdtLast_Review_Date = Date.Now
        Else
            dtpFatcaLRD.Value = pdtLast_Review_Date
        End If

        rtxtFatcaRemarks.Text = pstrFATCA_Remarks
        txtFatcaGIIN.Text = pstrFATCA_GIIN

        lFnFATCAEnableEdit(False, "Load")
        btnFatcaSave.Enabled = False
    End Sub

    Private Sub RefreshAccountInfo()

    End Sub

    Private Function ConsolidateAccount(ByRef ds As DataSet) As Dictionary(Of String, List(Of String))

        Dim dict As New Dictionary(Of String, List(Of String))
        Dim futuresList As New List(Of String)
        Dim securitiesList As New List(Of String)
        Dim ciesList As New List(Of String)


        Try
            If ds IsNot Nothing And _
            ds.Tables.Count > 0 Then
                Dim datatable = ds.Tables(0)
                For Each row As DataRow In datatable.Rows
                    If datatable.Columns.Count > 0 And _
                       Not row.IsNull(datatable.Columns("acc_no")) And _
                       Not row.IsNull(datatable.Columns("client_type")) And _
                       Not row.IsNull(datatable.Columns("ccd_ref")) Then

                        Dim selectAccount_Type = row("client_type").ToString.Trim
                        Select Case selectAccount_Type
                            Case ClsAccountType.Futures.ToString
                                futuresList.Add(row("acc_no").ToString.Trim)
                            Case ClsAccountType.Securities.ToString
                                securitiesList.Add(row("acc_no").ToString.Trim)
                            Case ClsAccountType.CIES.ToString
                                ciesList.Add(row("acc_no").ToString.Trim)
                            Case Else
                        End Select

                        SetCCDRef(row("ccd_ref").ToString.Trim)

                    End If
                Next
            End If
        Catch ex As Exception
            MsgBox(ex.Message & " StackTrace " & vbCrLf & ex.StackTrace)
        End Try

        dict.Add(ClsAccountType.Futures.ToString, futuresList)
        dict.Add(ClsAccountType.Securities.ToString, securitiesList)
        dict.Add(ClsAccountType.CIES.ToString, ciesList)

        ConsolidateAccount = dict
    End Function

    Private Sub RefreshRelatedAccountsContent()

        Dim selectAccNo, selectAccName, selectAccType As String
        selectAccNo = lblRelatedACAccNo.Text.Trim
        selectAccName = lblRelatedACAccName.Text.Trim
        selectAccType = lblAccountInfoClientType.Text.Trim

        Dim relatedAccountDS As DataSet = Nothing

        Try
            relatedAccountDS = cls.lFnGetRelatedACInfo(selectAccNo, selectAccType)
            If relatedAccountDS IsNot Nothing Then
                Dim rtn As Dictionary(Of String, List(Of String))
                rtn = ConsolidateAccount(relatedAccountDS)

                If rtn IsNot Nothing Then
                    'Update UI
                    If rtn(ClsAccountType.Futures.ToString).Count > 0 Then Me.txtRelatedACFutures_1.Text = rtn(ClsAccountType.Futures.ToString).Item(0).Trim
                    If rtn(ClsAccountType.Futures.ToString).Count > 1 Then Me.txtRelatedACFutures_2.Text = rtn(ClsAccountType.Futures.ToString).Item(1).Trim
                    If rtn(ClsAccountType.Futures.ToString).Count > 2 Then Me.txtRelatedACFutures_3.Text = rtn(ClsAccountType.Futures.ToString).Item(2).Trim

                    If rtn(ClsAccountType.Securities.ToString).Count > 0 Then Me.txtRelatedACSecurities_1.Text = rtn(ClsAccountType.Securities.ToString).Item(0).Trim
                    If rtn(ClsAccountType.Securities.ToString).Count > 1 Then Me.txtRelatedACSecurities_2.Text = rtn(ClsAccountType.Securities.ToString).Item(1).Trim

                    If rtn(ClsAccountType.CIES.ToString).Count > 0 Then Me.txtRelatedACCIES.Text = rtn(ClsAccountType.CIES.ToString).Item(0).Trim
                End If
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & " Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            relatedAccountDS = Nothing
        End Try

        Dim additionalAccountDS As DataSet = Nothing
        Try

            additionalAccountDS = cls.lFnGetRelatedACAdditionalInfo(selectAccNo, selectAccType)

            If additionalAccountDS IsNot Nothing And _
               additionalAccountDS.Tables.Count > 0 Then

                Dim datatable = additionalAccountDS.Tables(0)

                For Each row As DataRow In datatable.Rows
                    If datatable.Columns.Count > 0 Then

                        Dim minDate As Date = #1/1/1900#

                        ' fill Fund Transfer Authorization Date on Related Account tab.
                        If Not IsDBNull(row("RelatedAC_FTAD")) Then

                            Dim rtnDate As DateTime = CType(row("RelatedAC_FTAD"), DateTime)

                            If DateTime.Compare(rtnDate, minDate) > 0 Then

                                dtpRelateACFTAD.CustomFormat = "dd/MM/yyyy"
                                dtpRelateACFTAD.Format = DateTimePickerFormat.Custom
                                Dim relatedAC_FTAD As String
                                relatedAC_FTAD = rtnDate.ToString("dd/MM/yyyy")
                                dtpRelateACFTAD.Value = DateTime.ParseExact(relatedAC_FTAD, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                            Else
                                dtpRelateACFTAD.CustomFormat = " "  'An empty SPACE
                                dtpRelateACFTAD.Format = DateTimePickerFormat.Custom
                            End If

                        Else
                            dtpRelateACFTAD.CustomFormat = " "  'An empty SPACE
                            dtpRelateACFTAD.Format = DateTimePickerFormat.Custom
                        End If

                        ' fill Option Transfer Authorization Date on Related Account tab.
                        If Not IsDBNull(row("RelatedAC_OTAD")) Then

                            Dim rtnDate As DateTime = CType(row("RelatedAC_OTAD"), DateTime)

                            If DateTime.Compare(rtnDate, minDate) > 0 Then
                                dtpRelateACOTAD.CustomFormat = "dd/MM/yyyy"
                                dtpRelateACOTAD.Format = DateTimePickerFormat.Custom

                                Dim relatedAC_OTAD As String
                                relatedAC_OTAD = rtnDate.ToString("dd/MM/yyyy")
                                dtpRelateACOTAD.Value = DateTime.ParseExact(relatedAC_OTAD, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                            Else
                                dtpRelateACOTAD.CustomFormat = " "  'An empty SPACE
                                dtpRelateACOTAD.Format = DateTimePickerFormat.Custom
                            End If

                        Else
                            dtpRelateACOTAD.CustomFormat = " "  'An empty SPACE
                            dtpRelateACOTAD.Format = DateTimePickerFormat.Custom
                        End If

                        ' fill Remarks

                        If Not IsDBNull(row("RelatedAC_Remarks")) Then
                            Dim relatedAC_Remarks = row("RelatedAC_Remarks").ToString.Trim
                            rtxtRelatedACRemarks.Text = relatedAC_Remarks
                        Else
                            rtxtRelatedACRemarks.Text = String.Empty
                        End If

                    End If
                Next
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message & " Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            additionalAccountDS = Nothing

            relatedACRemarks = Me.rtxtRelatedACRemarks.Text
            relatedACFTAD = Me.dtpRelateACFTAD.Value.ToString("dd/MM/yyyy").Trim
            relatedACOTAD = Me.dtpRelateACOTAD.Value.ToString("dd/MM/yyyy").Trim
        End Try


        If dtpRelateACFTAD.Enabled Or (Not dtpRelateACFTAD.Enabled And dtpRelateACFTAD.Text.Trim <> "") Then
            dtpRelateACFTAD.CustomFormat = "dd/MM/yyyy"
            dtpRelateACFTAD.Format = DateTimePickerFormat.Custom
        Else
            dtpRelateACFTAD.CustomFormat = " "  'An empty SPACE
            dtpRelateACFTAD.Format = DateTimePickerFormat.Custom
        End If


        If dtpRelateACOTAD.Enabled Or (Not dtpRelateACOTAD.Enabled And dtpRelateACOTAD.Text.Trim <> "") Then
            dtpRelateACOTAD.CustomFormat = "dd/MM/yyyy"
            dtpRelateACOTAD.Format = DateTimePickerFormat.Custom
        Else
            dtpRelateACOTAD.CustomFormat = " "  'An empty SPACE
            dtpRelateACOTAD.Format = DateTimePickerFormat.Custom
        End If

    End Sub
    Private Sub RefreshForeignMarket()
        Dim dsSecuritiesAccountDetails As DataSet = Nothing
        Dim dtSecuritiesAccountDetails As DataTable = Nothing

        Dim dsFuturesAccountDetails As DataSet = Nothing
        Dim dtFuturesAccountDetails As DataTable = Nothing

        Dim dsForeignMarket As DataSet = Nothing
        Dim dtForeignMarket As DataTable = Nothing

        Dim dsClientMarket As DataSet = Nothing
        Dim dtClientMarket As DataTable = Nothing

        Dim dsThirdPartyMapping As DataSet = Nothing
        Dim dtThirdPartyMapping As DataTable = Nothing

        Dim dsFutureThirdPartyMaster As DataSet = Nothing
        Dim dtFutureThirdPartyMaster As DataTable = Nothing

        Dim sMarket As String = String.Empty
        Dim sMAMK As String = String.Empty
        Dim sSG As String = String.Empty
        Dim sSSE As String = String.Empty
        Dim sSZEN As String = String.Empty
        Dim sUS As String = String.Empty

        Dim bFilledMAMK As Boolean = False
        Dim bFilledSG As Boolean = False
        Dim bFilledSSE As Boolean = False
        Dim bFilledSZEN As Boolean = False
        Dim bFilledUS As Boolean = False

        lFnFMEnableEdit(False, "Load")

        dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
        dtpFMMAMKSerStartDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
        dtpFMSGSerStartDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
        dtpFMSSESerStartDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
        dtpFMSZENSerStartDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
        dtpFMUSSerStartDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
        dtpFMUSITradeStartDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
        dtpUVOTCMarketStartDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
        dtpFMUSStartDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
        dtpFMUSEndDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom
        dtpFMTPSerStartDate.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern

        Dim list As New DataTable()
        With list
            .Columns.Add(New DataColumn("Display", System.Type.GetType("System.String")))
            .Columns.Add(New DataColumn("Id", System.Type.GetType("System.String")))
            .Rows.Add(list.NewRow())
            .Rows.Add(list.NewRow())
            .Rows.Add(list.NewRow())
            .Rows(0)(0) = ""
            .Rows(0)(1) = ""
            .Rows(1)(0) = "P"
            .Rows(1)(1) = "P"
            .Rows(2)(0) = "P&I"
            .Rows(2)(1) = "I"
        End With

        With cboFMOrderPlaceMode
            .DataSource = list
            .DisplayMember = "Display"
            .ValueMember = "Id"
        End With

        Try
            If lblFMClientType.Text.ToString = "Securities" Then
                dsSecuritiesAccountDetails = cls.lFnGetSecuritiesAccountDetailsByAcc(lblFMAccNo.Text.ToString)
                If dsSecuritiesAccountDetails IsNot Nothing And dsSecuritiesAccountDetails.Tables.Count > 0 Then
                    dtSecuritiesAccountDetails = dsSecuritiesAccountDetails.Tables(0)
                End If
                If dtSecuritiesAccountDetails.Rows.Count > 0 Then
                    Dim minDate As Date = #1/1/1900#
                    For Each row As DataRow In dtSecuritiesAccountDetails.Rows
                        If Not IsDBNull(row("w8_form_date")) Then
                            Dim rtnDate As DateTime = CType(row("w8_form_date"), DateTime)
                            If DateTime.Compare(rtnDate, minDate) > 0 Then

                                Dim sFMDOS As String
                                sFMDOS = rtnDate.ToString("dd/MM/yyyy")

                                lblFMDOS.Text = DateTime.ParseExact(sFMDOS, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                            Else
                                lblFMDOS.Text = ""
                                
                            End If
                        Else
                                lblFMDOS.Text = ""
                        End If

                        If Not IsDBNull(row("external_accno")) Then
                            lblFMExternalAccNo.Text = row("external_accno").ToString
                        End If
                    Next
                End If
            Else
                dsFuturesAccountDetails = cls.lFnGetFuturesAccountDetailsByAcc(lblFMAccNo.Text.ToString)
                If dsFuturesAccountDetails IsNot Nothing And dsFuturesAccountDetails.Tables.Count > 0 Then
                    dtFuturesAccountDetails = dsFuturesAccountDetails.Tables(0)
                End If
                If dtFuturesAccountDetails.Rows.Count > 0 Then
                    Dim minDate As Date = #1/1/1900#
                    For Each row As DataRow In dtFuturesAccountDetails.Rows
                        If Not IsDBNull(row("w8_form_date")) Then
                            Dim rtnDate As DateTime = CType(row("w8_form_date"), DateTime)
                            If DateTime.Compare(rtnDate, minDate) > 0 Then

                                Dim sFMDOS As String
                                sFMDOS = rtnDate.ToString("dd/MM/yyyy")

                                lblFMDOS.Text = DateTime.ParseExact(sFMDOS, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                            Else
                                lblFMDOS.Text = ""

                            End If
                        Else
                            lblFMDOS.Text = ""
                        End If

                        If Not IsDBNull(row("external_accno")) Then
                            lblFMExternalAccNo.Text = row("external_accno").ToString
                        End If
                    Next
                End If
            End If



            If lblFMClientType.Text.ToString = "Securities" Then
                dsClientMarket = cls.lFnGetClientMarketRecordByAcc(lblFMAccNo.Text.ToString)
                If dsClientMarket IsNot Nothing And dsClientMarket.Tables.Count > 0 Then
                    dtClientMarket = dsClientMarket.Tables(0)
                End If
                If dtClientMarket.Rows.Count > 0 Then
                    cboMarket.Items.Clear()
                    If lblFatcaClientType.Text.ToString = "Securities" Then
                        For Each row As DataRow In dtClientMarket.Rows
                            If Not IsDBNull(row("MAMK")) Then
                                sMAMK = row("MAMK").ToString
                                If sMAMK = "Yes" Then
                                    cboMarket.Items.Add("MAMK")
                                End If
                            Else
                                dtpFMMAMKSerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
                            End If
                            If Not IsDBNull(row("SG")) Then
                                sSG = row("SG").ToString
                                If sSG = "Yes" Then
                                    cboMarket.Items.Add("SG")
                                End If
                            Else
                                dtpFMSGSerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
                            End If
                            If Not IsDBNull(row("SSE")) Then
                                sSSE = row("SSE").ToString
                                If sSSE = "Yes" Then
                                    cboMarket.Items.Add("SSE")
                                End If
                            Else
                                dtpFMSSESerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
                            End If
                            If Not IsDBNull(row("SZEN")) Then
                                sSZEN = row("SZEN").ToString
                                If sSZEN = "Yes" Then
                                    cboMarket.Items.Add("SZEN")
                                End If
                            Else
                                dtpFMSZENSerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
                            End If
                            If Not IsDBNull(row("US")) Then
                                sUS = row("US").ToString
                                If sUS = "Yes" Then
                                    cboMarket.Items.Add("US")
                                End If
                            Else
                                dtpFMUSSerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                                dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
                            End If
                        Next
                    End If
                Else
                    gbFMAccountDetails.Visible = False
                End If
            End If


            If lblFMClientType.Text.ToString = "Futures" Then
                'cboMarket.Items.Add("ThirdPartyAccountMapping")
                dsFutureThirdPartyMaster = cls.lFnGetFuturesThirdParty()
                If dsFutureThirdPartyMaster IsNot Nothing And dsFutureThirdPartyMaster.Tables.Count > 0 Then
                    dtFutureThirdPartyMaster = dsFutureThirdPartyMaster.Tables(0)
                End If
                If dtFutureThirdPartyMaster.Rows.Count > 0 Then
                    cboMarket.Items.Clear()
                    For Each row As DataRow In dtFutureThirdPartyMaster.Rows
                        If Not IsDBNull(row("CharValue")) Then
                            cboMarket.Items.Add(row("CharValue"))
                        End If
                    Next
                End If

            End If



            dsForeignMarket = cls.lFnGetForeignMarketRecordByAcc(lblFMAccNo.Text.ToString)
            If dsForeignMarket IsNot Nothing And dsForeignMarket.Tables.Count > 0 Then
                dtForeignMarket = dsForeignMarket.Tables(0)
            End If

            If dtForeignMarket.Rows.Count > 0 Then
                For Each row As DataRow In dtForeignMarket.Rows
                    Dim minDate As Date = #1/1/1900#
                    If Not IsDBNull(row("Market")) Then
                        sMarket = row("Market").ToString.Trim
                        Select Case sMarket
                            Case "MAMK"
                                If sMarket = "MAMK" And sMAMK = "Yes" Then
                                    If Not IsDBNull(row("ServiceStartDate")) Then
                                        Dim rtnDate As DateTime = CType(row("ServiceStartDate"), DateTime)
                                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                                            dtpFMMAMKSerStartDate.CustomFormat = "dd/MM/yyyy"
                                            dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
                                            Dim sFMMAMKSerStartDate As String
                                            sFMMAMKSerStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            psFMMAMKServStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            dtpFMMAMKSerStartDate.Value = DateTime.ParseExact(sFMMAMKSerStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        Else
                                            dtpFMMAMKSerStartDate.CustomFormat = " "  'An empty SPACE
                                            dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
                                        End If
                                    Else
                                        dtpFMMAMKSerStartDate.CustomFormat = " "  'An empty SPACE
                                        dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
                                    End If
                                ElseIf sMarket <> "" And sMAMK = "Yes" Then
                                    dtpFMMAMKSerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
                                ElseIf sMAMK = "No" Then
                                    dtpFMMAMKSerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
                                End If
                                bFilledMAMK = True
                            Case "SG"
                                If sMarket = "SG" And sSG = "Yes" Then
                                    If Not IsDBNull(row("ServiceStartDate")) Then
                                        Dim rtnDate As DateTime = CType(row("ServiceStartDate"), DateTime)
                                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                                            dtpFMSGSerStartDate.CustomFormat = "dd/MM/yyyy"
                                            dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
                                            Dim sFMSGSerStartDate As String
                                            sFMSGSerStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            psFMSGServStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            dtpFMSGSerStartDate.Value = DateTime.ParseExact(sFMSGSerStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        Else
                                            dtpFMSGSerStartDate.CustomFormat = " "  'An empty SPACE
                                            dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
                                        End If
                                    Else
                                        dtpFMSGSerStartDate.CustomFormat = " "  'An empty SPACE
                                        dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
                                    End If
                                ElseIf sMarket <> "" And sSG = "Yes" Then
                                    dtpFMSGSerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
                                ElseIf sSG = "No" Then
                                    dtpFMSGSerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
                                End If

                                bFilledSG = True

                            Case "SSE"
                                If sMarket = "SSE" And sSSE = "Yes" Then
                                    If Not IsDBNull(row("ServiceStartDate")) Then
                                        Dim rtnDate As DateTime = CType(row("ServiceStartDate"), DateTime)
                                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                                            dtpFMSSESerStartDate.CustomFormat = "dd/MM/yyyy"
                                            dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
                                            Dim sFMSSESerStartDate As String
                                            sFMSSESerStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            psFMSSEServStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            dtpFMSSESerStartDate.Value = DateTime.ParseExact(sFMSSESerStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        Else
                                            dtpFMSSESerStartDate.CustomFormat = " "  'An empty SPACE
                                            dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
                                        End If
                                    Else
                                        dtpFMSSESerStartDate.CustomFormat = " "  'An empty SPACE
                                        dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
                                    End If
                                    If Not IsDBNull(row("RiskDisclosure")) Then
                                        If Convert.ToBoolean(row("RiskDisclosure")) = True Then
                                            chkRiskDisclosure.Checked = True
                                        Else
                                            chkRiskDisclosure.Checked = False
                                        End If
                                    End If

                                ElseIf sMarket <> "" And sSSE = "Yes" Then
                                    dtpFMSSESerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
                                ElseIf sSSE = "No" Then
                                    dtpFMSSESerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
                                End If

                                bFilledSSE = True

                            Case "SZEN"
                                If sMarket = "SZEN" And sSZEN = "Yes" Then
                                    If Not IsDBNull(row("ServiceStartDate")) Then
                                        Dim rtnDate As DateTime = CType(row("ServiceStartDate"), DateTime)
                                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                                            dtpFMSZENSerStartDate.CustomFormat = "dd/MM/yyyy"
                                            dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
                                            Dim sFMSZENSerStartDate As String
                                            sFMSZENSerStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            psFMSZENServStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            dtpFMSZENSerStartDate.Value = DateTime.ParseExact(sFMSZENSerStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        Else
                                            dtpFMSZENSerStartDate.CustomFormat = " "  'An empty SPACE
                                            dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
                                        End If
                                    Else
                                        dtpFMSZENSerStartDate.CustomFormat = " "  'An empty SPACE
                                        dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
                                    End If
                                ElseIf sMarket <> "" And sSZEN = "Yes" Then
                                    dtpFMSZENSerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
                                ElseIf sSZEN = "No" Then
                                    dtpFMSZENSerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
                                End If
                                bFilledSZEN = True

                            Case "US"


                                If sMarket = "US" And sUS = "Yes" Then
                                    If Not IsDBNull(row("ServiceStartDate")) Then
                                        Dim rtnDate As DateTime = CType(row("ServiceStartDate"), DateTime)
                                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                                            dtpFMUSSerStartDate.CustomFormat = "dd/MM/yyyy"
                                            dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
                                            Dim sFMUSSerStartDate As String
                                            sFMUSSerStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            psFMUSServStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            dtpFMUSSerStartDate.Value = DateTime.ParseExact(sFMUSSerStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        Else
                                            dtpFMUSSerStartDate.CustomFormat = " "  'An empty SPACE
                                            dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
                                            psFMUSServStartDate = ""
                                        End If
                                    Else
                                        dtpFMUSSerStartDate.CustomFormat = " "  'An empty SPACE
                                        dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
                                        psFMUSServStartDate = ""
                                    End If

                                    If Not IsDBNull(row("Channel")) Then
                                        If row("Channel").ToString.Trim = "P" Then
                                            cboFMOrderPlaceMode.SelectedIndex = 1
                                        ElseIf row("Channel").ToString.Trim = "I" Then
                                            cboFMOrderPlaceMode.SelectedIndex = 2
                                        Else
                                            cboFMOrderPlaceMode.SelectedIndex = 0
                                        End If
                                        psFMOrderPlacingMode = row("Channel").ToString.Trim

                                    End If

                                    If Not IsDBNull(row("UVOTCMarketStartDate")) Then
                                        Dim rtnDate As DateTime = CType(row("UVOTCMarketStartDate"), DateTime)
                                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                                            chkUVOTCMarketStartDate.Checked = True
                                            dtpUVOTCMarketStartDate.CustomFormat = "dd/MM/yyyy"
                                            dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                                            Dim sFMUVOTCMarketStartDate As String
                                            sFMUVOTCMarketStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            psFMUVOTCMarketStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            dtpUVOTCMarketStartDate.Value = DateTime.ParseExact(sFMUVOTCMarketStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)

                                        Else
                                            chkUVOTCMarketStartDate.Checked = False
                                            dtpUVOTCMarketStartDate.CustomFormat = " "  'An empty SPACE
                                            dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                                            psFMUVOTCMarketStartDate = ""

                                        End If
                                    Else
                                        chkUVOTCMarketStartDate.Checked = False
                                        dtpUVOTCMarketStartDate.CustomFormat = " "  'An empty SPACE
                                        dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                                        psFMUVOTCMarketStartDate = ""

                                    End If

                                    If Not IsDBNull(row("iTradeStartDate")) Then
                                        Dim rtnDate As DateTime = CType(row("iTradeStartDate"), DateTime)
                                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                                            dtpFMUSITradeStartDate.CustomFormat = "dd/MM/yyyy"
                                            dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                                            Dim sFMUSITradeStartDate As String
                                            sFMUSITradeStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            psFMITradeStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            dtpFMUSITradeStartDate.Value = DateTime.ParseExact(sFMUSITradeStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        Else
                                            dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                                            dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                                            psFMITradeStartDate = ""
                                        End If
                                    Else
                                        dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                                        dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                                        psFMITradeStartDate = ""
                                    End If

                                    If Not IsDBNull(row("StartDate")) Then

                                        Dim rtnDate As DateTime = CType(row("StartDate"), DateTime)
                                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                                            chkFMUSStartStreaming.Checked = True
                                            dtpFMUSStartDate.CustomFormat = "dd/MM/yyyy"
                                            dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                                            Dim sFMUSStartDate As String
                                            sFMUSStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            psFMUSStartDate = rtnDate.ToString("dd/MM/yyyy")
                                            dtpFMUSStartDate.Value = DateTime.ParseExact(sFMUSStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        Else
                                            chkFMUSStartStreaming.Checked = False
                                            dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                                            dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                                            psFMUSStartDate = ""
                                        End If
                                    Else
                                        chkFMUSStartStreaming.Checked = False
                                        dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                                        dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                                        psFMUSStartDate = ""
                                    End If

                                    If Not IsDBNull(row("EndDate")) Then

                                        Dim rtnDate As DateTime = CType(row("EndDate"), DateTime)
                                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                                            chkFMUSEndStreaming.Checked = True
                                            dtpFMUSEndDate.CustomFormat = "dd/MM/yyyy"
                                            dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
                                            Dim sFMUSEndDate As String
                                            sFMUSEndDate = rtnDate.ToString("dd/MM/yyyy")
                                            psFMUSEndDate = rtnDate.ToString("dd/MM/yyyy")
                                            dtpFMUSEndDate.Value = DateTime.ParseExact(sFMUSEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                                        Else
                                            chkFMUSEndStreaming.Checked = False
                                            dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                                            dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
                                            psFMUSEndDate = ""
                                        End If
                                    Else
                                        chkFMUSEndStreaming.Checked = False
                                        dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                                        dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
                                        psFMUSEndDate = ""
                                    End If
                                ElseIf sMarket <> "" And sUS = "Yes" Then
                                    dtpFMUSSerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
                                    dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                                    dtpUVOTCMarketStartDate.CustomFormat = " "
                                    dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                                    dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                                    dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
                                ElseIf sUS = "no" Then
                                    dtpFMUSSerStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
                                    dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                                    dtpUVOTCMarketStartDate.CustomFormat = " "
                                    dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                                    dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                                    dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                                    dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
                                End If

                                bFilledUS = True

                            Case Else
                                dtpFMMAMKSerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMSGSerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMSSESerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMSZENSerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMUSSerStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                                dtpUVOTCMarketStartDate.CustomFormat = " "
                                dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                                dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                                dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                                dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
                        End Select


                    End If
                Next

            Else

                dtpFMMAMKSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
                dtpFMSGSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
                dtpFMSSESerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
                dtpFMSZENSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                dtpUVOTCMarketStartDate.CustomFormat = " "
                dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
            End If


            If bFilledMAMK = False Then
                dtpFMMAMKSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
            End If
            If bFilledSG = False Then
                dtpFMSGSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
            End If
            If bFilledSSE = False Then
                dtpFMSSESerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
            End If
            If bFilledSZEN = False Then
                dtpFMSZENSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
            End If
            If bFilledUS = False Then
                dtpFMUSSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                dtpUVOTCMarketStartDate.CustomFormat = " "
                dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
            End If

        Catch ex As Exception
            MessageBox.Show(ex.Message & " Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            dsClientMarket = Nothing
            dtClientMarket = Nothing
            dsForeignMarket = Nothing
            dtForeignMarket = Nothing

            dsFutureThirdPartyMaster = Nothing
            dtFutureThirdPartyMaster = Nothing

            dsSecuritiesAccountDetails = Nothing
            dtSecuritiesAccountDetails = Nothing

            dsFuturesAccountDetails = Nothing
            dtFuturesAccountDetails = Nothing
        End Try

        Try
            txtFMPlatform.Enabled = False

            dsThirdPartyMapping = cls.lFnGetThirdPartyMappingByAcc(lblFMAccNo.Text.ToString)
            If dsThirdPartyMapping IsNot Nothing And dsThirdPartyMapping.Tables.Count > 0 Then
                dtThirdPartyMapping = dsThirdPartyMapping.Tables(0)
            End If

            dtpFMTPSerStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom

            txtFMPlatform.Text = cboMarket.Text.ToString
            txtFMTPAccNo.Text = ""
            txtFMTPUsername.Text = ""
            txtFMRemarks.Text = ""
            dtThirdPartyMappingForMarketChange = dtThirdPartyMapping.Clone
            For Each row As DataRow In dtThirdPartyMapping.Rows
                dtThirdPartyMappingForMarketChange.ImportRow(row)
            Next

        Catch ex As Exception
            MessageBox.Show(ex.Message & " Stack Trace: " & vbCrLf & ex.StackTrace)
        Finally
            dsThirdPartyMapping = Nothing
            dtThirdPartyMapping = Nothing
        End Try

        If cboMarket.Items.Count > 0 Then
            cboMarket.SelectedIndex = 0
        Else
            gbFMMAMK.Visible = False
            gbFMSG.Visible = False
            gbFMSSE.Visible = False
            gbFMSZEN.Visible = False
            gbFMUS.Visible = False
            gbFMThirdPartyAccountMapping.Visible = False
        End If
    End Sub

    Private Sub btnRelatedACExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelatedACExit.Click
        Me.Close()
    End Sub

    Private Sub btnRelatedACSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelatedACSave.Click

        btnRelatedACSave.Enabled = False

        Dim selectCCDRef, selectAccNo As String
        selectAccNo = Me.lblAccountInfoAccNo.Text.Trim
        selectCCDRef = initCCDRef

        Dim selectFTAD As String = Me.dtpRelateACFTAD.Value.ToString("dd/MM/yyyy")
        Dim selectOTAD As String = Me.dtpRelateACOTAD.Value.ToString("dd/MM/yyyy")
        Dim selectRemarks As String = Me.rtxtRelatedACRemarks.Text.Trim

        If MsgBox("Confirm to Save?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then

            'If selectFTAD.Contains("01/01/1900") Or selectOTAD.Contains("01/01/1900") Then
            If selectFTAD.Contains("01/01/1900") Then
                MsgBox("Invalid date input")
                btnRelatedACCancel_Click(sender, e)

            ElseIf Not String.IsNullOrEmpty(selectAccNo) Then

                If Not String.IsNullOrEmpty(selectCCDRef) Then
                    Dim MyTrans As SqlTransaction = Nothing

                    ' Brought down CCD Ref
                    ' Apply for all record which have same CCD ref with fields: FTAD,OTAD, Remarks

                    Try
                        MyTrans = GSCnSqlConn.BeginTransaction

                        Dim rtnCode = cls.lFnUpdateAdditionalRelatedACInfo(MyTrans, selectFTAD, selectOTAD, selectRemarks, selectCCDRef)

                        If rtnCode <= 0 Then
                            MsgBox("No rows has been updated")
                        Else
                            MsgBox("Saved Successfully!")
                            dtpRelateACFTAD.Enabled = False
                            dtpRelateACOTAD.Enabled = False
                            rtxtRelatedACRemarks.Enabled = False

                        End If

                        MyTrans.Commit()
                    Catch ex As Exception
                        If GSCnSqlConn.State <> ConnectionState.Closed Then
                            If (MyTrans IsNot Nothing) Then
                                MyTrans.Rollback()
                            End If
                            GSubWriteErrLog(ex.Message)
                            MsgBox("Fail to update CCDRef", MsgBoxStyle.OkOnly)
                        End If
                    End Try

                    MyTrans = Nothing
                Else

                    ' No brought down CCD Ref
                    ' Apply for the brought down record ( acc_no + client_type ) only with fields: FTAD, OTAD, Remarks

                    Dim MyTrans As SqlTransaction = Nothing

                    Try
                        MyTrans = GSCnSqlConn.BeginTransaction

                        Dim selectAccountNo As String = lblRelatedACAccNo.Text.Trim
                        Dim selectAccountType As String = lblAccountInfoClientType.Text.Trim

                        Dim rtnCode = cls.lFnUpdateAdditionalRelatedACInfo(MyTrans, selectFTAD, selectOTAD, selectRemarks, _
                            selectAccountNo, selectAccountType)

                        If rtnCode <= 0 Then
                            MsgBox("No rows has been updated")
                        Else
                            MsgBox("Saved Successfully!")
                            dtpRelateACFTAD.Enabled = False
                            dtpRelateACOTAD.Enabled = False
                            rtxtRelatedACRemarks.Enabled = False
                        End If

                        MyTrans.Commit()


                    Catch ex As Exception
                        If GSCnSqlConn.State <> ConnectionState.Closed Then
                            If (MyTrans IsNot Nothing) Then
                                MyTrans.Rollback()
                            End If
                            GSubWriteErrLog(ex.Message)
                        End If
                    End Try

                    MyTrans = Nothing
                End If
            End If

        Else
            btnRelatedACCancel_Click(sender, e)
        End If

        Me.btnRelatedACModify.Enabled = True
        Me.btnRelatedACCancel.Enabled = False
        Me.btnRelatedACSave.Enabled = False

        _tabSelectDisabled = False

    End Sub

    Private Sub btnRelatedACCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelatedACCancel.Click

        btnRelatedACModify.Enabled = True
        btnRelatedACCancel.Enabled = True
        btnRelatedACSave.Enabled = False

        dtpRelateACFTAD.Enabled = False
        dtpRelateACOTAD.Enabled = False
        rtxtRelatedACRemarks.Enabled = False

        If relatedACRemarks <> "" Then
            Me.rtxtRelatedACRemarks.Text = relatedACRemarks
        Else
            Me.rtxtRelatedACRemarks.Text = ""
        End If

        Dim minDate As Date = #1/1/1900#

        Dim acftDate As DateTime
        Me.dtpRelateACFTAD.CustomFormat = "dd/MM/yyyy"
        Me.dtpRelateACFTAD.Format = DateTimePickerFormat.Custom

        If DateTime.TryParseExact(relatedACFTAD, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, acftDate) And _
           acftDate > minDate Then
            Me.dtpRelateACFTAD.Value = acftDate
        Else
            dtpRelateACFTAD.CustomFormat = " "  'An empty SPACE
            dtpRelateACFTAD.Format = DateTimePickerFormat.Custom

        End If

        Dim ocftDate As DateTime
        Me.dtpRelateACOTAD.CustomFormat = "dd/MM/yyyy"
        Me.dtpRelateACOTAD.Format = DateTimePickerFormat.Custom
        If DateTime.TryParseExact(relatedACOTAD, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, ocftDate) And _
            ocftDate > minDate Then
            Me.dtpRelateACFTAD.Value = ocftDate
        End If

        _tabSelectDisabled = False

    End Sub

    Private Sub btnRelatedACModify_MouseClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btnRelatedACModify.MouseClick
        dtpRelateACFTAD.Enabled = True
        dtpRelateACOTAD.Enabled = True
        rtxtRelatedACRemarks.Enabled = True

        btnRelatedACCancel.Enabled = True
        btnRelatedACSave.Enabled = True
        btnRelatedACModify.Enabled = False
    End Sub

    Private Sub tcFatcaIJAccProfileMain_Deselecting(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tcFatcaIJAccProfileMain.Deselecting

        If _tabSelectDisabled Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If

    End Sub
    Private Sub lFnFMEnableEdit(ByVal bool As Boolean, ByVal action As String)

        If action = "Edit" Then
            type = "Edit"
        ElseIf action = "Cancel" Then
            type = "Cancel"
        ElseIf action = "Save" Then
            type = "Save"
        ElseIf action = "Load" Then
            type = "Load"
        End If

        'gbFMMAMK.Enabled = bool
        dtpFMMAMKSerStartDate.Enabled = bool
        'gbFMSG.Enabled = bool
        dtpFMSGSerStartDate.Enabled = bool
        'gbFMSSE.Enabled = bool
        dtpFMSSESerStartDate.Enabled = bool
        chkRiskDisclosure.Enabled = bool
        'gbFMSZEN.Enabled = bool
        dtpFMSZENSerStartDate.Enabled = bool
        'gbFMUS.Enabled = bool
        dtpFMUSSerStartDate.Enabled = bool
        dtpFMUSITradeStartDate.Enabled = bool
        cboFMOrderPlaceMode.Enabled = bool

        chkUVOTCMarketStartDate.Enabled = bool
        dtpUVOTCMarketStartDate.Enabled = bool
        If type = "Edit" Then
            If chkUVOTCMarketStartDate.Checked = True Then
                If Not String.IsNullOrEmpty(psFMUVOTCMarketStartDate) Then
                    dtpUVOTCMarketStartDate.Value = psFMUVOTCMarketStartDate
                Else
                    dtpUVOTCMarketStartDate.Value = Date.Now
                End If

                dtpUVOTCMarketStartDate.Enabled = True
                dtpUVOTCMarketStartDate.CustomFormat = "dd/MM/yyyy"
                dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
            Else
                dtpUVOTCMarketStartDate.CustomFormat = " "  'An empty SPACE
                dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                dtpUVOTCMarketStartDate.Enabled = False
            End If
        Else
            dtpUVOTCMarketStartDate.Enabled = False
        End If

        If type = "Edit" Then
            If cboFMOrderPlaceMode.SelectedIndex = 2 Then
                If Not String.IsNullOrEmpty(psFMITradeStartDate) Then
                    dtpFatcaDOS.Value = psFMITradeStartDate
                Else
                    dtpFMUSITradeStartDate.Value = Date.Now
                End If

                dtpFMUSITradeStartDate.Enabled = True
                dtpFMUSITradeStartDate.CustomFormat = "dd/MM/yyyy"
                dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
            Else
                dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSITradeStartDate.Enabled = False
            End If
        Else
            dtpFMUSITradeStartDate.Enabled = False
        End If

        chkFMUSStartStreaming.Enabled = bool
        chkFMUSEndStreaming.Enabled = bool
        dtpFMUSStartDate.Enabled = bool
        dtpFMUSEndDate.Enabled = bool
        If type = "Edit" Then
            If chkFMUSStartStreaming.Checked = True Then
                If Not String.IsNullOrEmpty(psFMUSStartDate) Then
                    dtpFMUSStartDate.Value = psFMUSStartDate
                Else
                    dtpFMUSStartDate.Value = Date.Now
                End If

                dtpFMUSStartDate.Enabled = True
                dtpFMUSStartDate.CustomFormat = "dd/MM/yyyy"
                dtpFMUSStartDate.Format = DateTimePickerFormat.Custom

            Else
                dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSStartDate.Enabled = False

            End If

        Else
            dtpFMUSStartDate.Enabled = False
        End If

        If type = "Edit" Then
            If chkFMUSEndStreaming.Checked = True Then

                If Not String.IsNullOrEmpty(psFMUSEndDate) Then
                    dtpFMUSEndDate.Value = psFMUSEndDate
                Else
                    dtpFMUSEndDate.Value = Date.Now
                End If

                dtpFMUSEndDate.Enabled = True
                dtpFMUSEndDate.CustomFormat = "dd/MM/yyyy"
                dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
            Else
                dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
                dtpFMUSEndDate.Enabled = False
            End If

        Else
            dtpFMUSEndDate.Enabled = False
        End If

        chkFMTPSerStartdate.Enabled = bool
        dtpFMTPSerStartDate.Enabled = bool

        If type = "Edit" Then
            If chkFMTPSerStartdate.Checked = True Then
                If Not String.IsNullOrEmpty(psFMTPServStartDate) Then
                    dtpFMTPSerStartDate.Value = psFMTPServStartDate
                Else
                    dtpFMTPSerStartDate.Value = Date.Now
                End If

                dtpFMTPSerStartDate.Enabled = True
                dtpFMTPSerStartDate.CustomFormat = "dd/MM/yyyy"
                dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom

            Else
                dtpFMTPSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom
                dtpFMTPSerStartDate.Enabled = False

                dtpFMTPSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom
                dtpFMTPSerStartDate.Enabled = False
            End If

        Else
            dtpFMTPSerStartDate.Enabled = False
        End If
        'txtFMPlatform.Enabled = bool
        txtFMTPAccNo.Enabled = bool
        txtFMTPUsername.Enabled = bool
        txtFMRemarks.Enabled = bool


    End Sub
    Private Sub cboMarket_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboMarket.SelectedIndexChanged
        Dim Dr() As DataRow = Nothing

        If lblFMClientType.Text = "Futures" Then
            gbFMMAMK.Visible = False
            gbFMSG.Visible = False
            gbFMSSE.Visible = False
            gbFMSZEN.Visible = False
            gbFMUS.Visible = False
            gbFMThirdPartyAccountMapping.Text = cboMarket.SelectedItem.ToString + " Account Mapping"
            gbFMThirdPartyAccountMapping.Visible = True
            gbFMThirdPartyAccountMapping.Left = gbFMMAMK.Left
            gbFMThirdPartyAccountMapping.Top = gbFMMAMK.Top
            gbFMThirdPartyAccountMapping.Width = 675

            Label61.Text = cboMarket.SelectedItem.ToString() + " Account No."
            Label62.Text = cboMarket.SelectedItem.ToString() + " Username"

            'Start Set Account Details visible
            gbFMAccountDetails.Visible = True
            gbFMAccountDetails.Left = gbFMThirdPartyAccountMapping.Left
            gbFMAccountDetails.Top = gbFMThirdPartyAccountMapping.Top + gbFMThirdPartyAccountMapping.Height + 20
            gbFMAccountDetails.Width = 675
            Label81.Visible = False
            lblFMExternalAccNo.Visible = False
            Label87.Left = Label81.Left
            lblFMDOS.Left = lblFMExternalAccNo.Left
            'End Set Account Details visible

            txtFMPlatform.Text = cboMarket.SelectedItem.ToString
            Dr = dtThirdPartyMappingForMarketChange.Select("Platform='" & cboMarket.SelectedItem.ToString & "'")
            If Dr.Length > 0 Then

                Dim minDate As Date = #1/1/1900#
                For i As Integer = 0 To Dr.Length - 1
                    If Not IsDBNull(Dr(0).Item("ServiceStartDate")) Then
                        Dim rtnDate As DateTime = CType(Dr(0).Item("ServiceStartDate"), DateTime)
                        If DateTime.Compare(rtnDate, minDate) > 0 Then
                            chkFMTPSerStartdate.Checked = True
                            dtpFMTPSerStartDate.CustomFormat = "dd/MM/yyyy"
                            dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom
                            Dim sFMTPSerStartDate As String
                            sFMTPSerStartDate = rtnDate.ToString("dd/MM/yyyy")
                            psFMTPServStartDate = rtnDate.ToString("dd/MM/yyyy")
                            dtpFMTPSerStartDate.Value = DateTime.ParseExact(psFMTPServStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                        Else
                            chkFMTPSerStartdate.Checked = False
                            dtpFMTPSerStartDate.CustomFormat = " "  'An empty SPACE
                            dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom
                        End If
                    Else
                        chkFMTPSerStartdate.Checked = False
                        dtpFMTPSerStartDate.CustomFormat = " "  'An empty SPACE
                        dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom
                    End If
                    If Not IsDBNull(Dr(0).Item("Platform")) Then
                        txtFMPlatform.Text = Dr(0).Item("Platform").ToString.Trim
                        psFMPlatform = Dr(0).Item("Platform").ToString.Trim
                    End If
                    If Not IsDBNull(Dr(0).Item("ThirdPartyAccNo")) Then
                        txtFMTPAccNo.Text = Dr(0).Item("ThirdPartyAccNo").ToString.Trim
                        psFMTPAccNo = Dr(0).Item("ThirdPartyAccNo").ToString.Trim
                    End If
                    If Not IsDBNull(Dr(0).Item("ThirdPartyUsername")) Then
                        txtFMTPUsername.Text = Dr(0).Item("ThirdPartyUsername").ToString.Trim
                        psFMTPUsername = Dr(0).Item("ThirdPartyUsername").ToString.Trim
                    End If
                    If Not IsDBNull(Dr(0).Item("Remarks")) Then
                        txtFMRemarks.Text = Dr(0).Item("Remarks").ToString.Trim
                        psFMRemarks = Dr(0).Item("Remarks").ToString.Trim
                    End If
                Next

            Else
                txtFMPlatform.Text = cboMarket.Text.ToString
                txtFMTPAccNo.Text = ""
                txtFMTPUsername.Text = ""
                txtFMRemarks.Text = ""
            End If
        ElseIf lblFMClientType.Text = "Securities" Then


            Select Case cboMarket.SelectedItem.ToString
                Case "MAMK"
                    gbFMMAMK.Visible = True
                    gbFMSG.Visible = False
                    gbFMSSE.Visible = False
                    gbFMSZEN.Visible = False
                    gbFMUS.Visible = False
                    gbFMThirdPartyAccountMapping.Visible = False
                    gbFMAccountDetails.Visible = True
                    gbFMAccountDetails.Left = gbFMMAMK.Left
                    gbFMAccountDetails.Top = gbFMMAMK.Top + gbFMMAMK.Height + 20
                    gbFMAccountDetails.Width = 675
                    gbFMAccountDetails.Visible = False
                    lblFMExternalAccNo.Visible = False
                    lblFMDOS.Visible = False

                Case "SG"
                    gbFMMAMK.Visible = False
                    gbFMSG.Visible = True
                    gbFMSSE.Visible = False
                    gbFMSZEN.Visible = False
                    gbFMUS.Visible = False
                    gbFMThirdPartyAccountMapping.Visible = False
                    gbFMSG.Left = gbFMMAMK.Left
                    gbFMSG.Top = gbFMMAMK.Top
                    gbFMAccountDetails.Visible = True
                    gbFMAccountDetails.Left = gbFMSG.Left
                    gbFMAccountDetails.Top = gbFMSG.Top + gbFMSG.Height + 20
                    gbFMAccountDetails.Width = 675

                    lblFMExternalAccNo.Visible = True
                    Label87.Visible = False
                    lblFMDOS.Visible = False
                Case "SSE"
                    gbFMMAMK.Visible = False
                    gbFMSG.Visible = False
                    gbFMSSE.Visible = True
                    gbFMSZEN.Visible = False
                    gbFMUS.Visible = False
                    gbFMThirdPartyAccountMapping.Visible = False
                    gbFMSSE.Left = gbFMMAMK.Left
                    gbFMSSE.Top = gbFMMAMK.Top
                    gbFMAccountDetails.Visible = True
                    gbFMAccountDetails.Left = gbFMSSE.Left
                    gbFMAccountDetails.Top = gbFMSSE.Top + gbFMSSE.Height + 20
                    gbFMAccountDetails.Width = 675
                    gbFMAccountDetails.Visible = False
                    lblFMExternalAccNo.Visible = False
                    lblFMDOS.Visible = False
                Case "SZEN"
                    gbFMMAMK.Visible = False
                    gbFMSG.Visible = False
                    gbFMSSE.Visible = False
                    gbFMSZEN.Visible = True
                    gbFMUS.Visible = False
                    gbFMThirdPartyAccountMapping.Visible = False
                    gbFMSZEN.Left = gbFMMAMK.Left
                    gbFMSZEN.Top = gbFMMAMK.Top
                    gbFMAccountDetails.Visible = True
                    gbFMAccountDetails.Left = gbFMSZEN.Left
                    gbFMAccountDetails.Top = gbFMSZEN.Top + gbFMSZEN.Height + 20
                    gbFMAccountDetails.Width = 675
                    gbFMAccountDetails.Visible = False
                    lblFMExternalAccNo.Visible = False
                    lblFMDOS.Visible = False
                Case "US"
                    gbFMMAMK.Visible = False
                    gbFMSG.Visible = False
                    gbFMSSE.Visible = False
                    gbFMSZEN.Visible = False
                    gbFMUS.Visible = True
                    gbFMThirdPartyAccountMapping.Visible = False
                    gbFMUS.Left = gbFMMAMK.Left
                    gbFMUS.Top = gbFMMAMK.Top
                    gbFMAccountDetails.Visible = True
                    gbFMAccountDetails.Left = gbFMUS.Left
                    gbFMAccountDetails.Top = gbFMUS.Top + gbFMUS.Height + 20
                    gbFMAccountDetails.Width = 675
                    lblFMExternalAccNo.Visible = True
                    lblFMDOS.Visible = True
                Case Else
                    gbFMMAMK.Visible = False
                    gbFMSG.Visible = False
                    gbFMSSE.Visible = False
                    gbFMSZEN.Visible = False
                    gbFMUS.Visible = False
                    gbFMThirdPartyAccountMapping.Visible = False
                    gbFMAccountDetails.Visible = False
                    lblFMExternalAccNo.Visible = False
                    lblFMDOS.Visible = False
            End Select
        End If


    End Sub
    Private Sub cboFMOrderPlaceMode_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cboFMOrderPlaceMode.SelectedIndexChanged
        If type = "Edit" Then
            If cboFMOrderPlaceMode.SelectedIndex = 2 Then
                If Not String.IsNullOrEmpty(psFMITradeStartDate) Then
                    dtpFatcaDOS.Value = psFMITradeStartDate
                Else
                    dtpFMUSITradeStartDate.Value = Date.Now
                End If

                dtpFMUSITradeStartDate.Enabled = True
                dtpFMUSITradeStartDate.CustomFormat = "dd/MM/yyyy"
                dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
            Else
                dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSITradeStartDate.Enabled = False
            End If
        Else
            dtpFMUSITradeStartDate.Enabled = False
        End If

    End Sub
    Private Sub chkUVOTCMarketStartDate_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkUVOTCMarketStartDate.CheckStateChanged
        If type = "Edit" Then
            If chkUVOTCMarketStartDate.Checked = True Then
                If Not String.IsNullOrEmpty(psFMUVOTCMarketStartDate) Then
                    dtpUVOTCMarketStartDate.Value = psFMUVOTCMarketStartDate
                Else
                    dtpUVOTCMarketStartDate.Value = Date.Now
                End If

                dtpUVOTCMarketStartDate.Enabled = True
                dtpUVOTCMarketStartDate.CustomFormat = "dd/MM/yyyy"
                dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
            Else
                dtpUVOTCMarketStartDate.CustomFormat = " "  'An empty SPACE
                dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
                dtpUVOTCMarketStartDate.Enabled = False
            End If
        Else
            dtpUVOTCMarketStartDate.Enabled = False
        End If
    End Sub
    Private Sub chkFMUSStartStreaming_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkFMUSStartStreaming.CheckStateChanged
        If type = "Edit" Then
            If chkFMUSStartStreaming.Checked = True Then
                If Not String.IsNullOrEmpty(psFMUSStartDate) Then
                    dtpFMUSStartDate.Value = psFMUSStartDate
                Else
                    dtpFMUSStartDate.Value = Date.Now
                End If

                dtpFMUSStartDate.Enabled = True
                dtpFMUSStartDate.CustomFormat = "dd/MM/yyyy"
                dtpFMUSStartDate.Format = DateTimePickerFormat.Custom

            Else
                dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
                dtpFMUSStartDate.Enabled = False

            End If
        Else
            dtpFMUSStartDate.Enabled = False
        End If
    End Sub
    Private Sub chkFMUSEndStreaming_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkFMUSEndStreaming.CheckStateChanged
        If type = "Edit" Then
            If chkFMUSEndStreaming.Checked = True Then

                If Not String.IsNullOrEmpty(psFMUSEndDate) Then
                    dtpFMUSEndDate.Value = psFMUSEndDate
                Else
                    dtpFMUSEndDate.Value = Date.Now
                End If

                dtpFMUSEndDate.Enabled = True
                dtpFMUSEndDate.CustomFormat = "dd/MM/yyyy"
                dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
            Else

                dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
                dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
                dtpFMUSEndDate.Enabled = False
            End If
        Else
            dtpFMUSEndDate.Enabled = False
        End If
    End Sub
    Private Sub chkFMTPSerStartdate_CheckStateChanged(sender As Object, e As System.EventArgs) Handles chkFMTPSerStartdate.CheckStateChanged
        If type = "Edit" Then
            If chkFMTPSerStartdate.Checked = True Then
                If Not String.IsNullOrEmpty(psFMTPServStartDate) Then
                    dtpFMTPSerStartDate.Value = psFMTPServStartDate
                Else
                    dtpFMTPSerStartDate.Value = Date.Now
                End If

                dtpFMTPSerStartDate.Enabled = True
                dtpFMTPSerStartDate.CustomFormat = "dd/MM/yyyy"
                dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom

            Else
                dtpFMTPSerStartDate.CustomFormat = " "  'An empty SPACE
                dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom
                dtpFMTPSerStartDate.Enabled = False

            End If
        Else
            dtpFMTPSerStartDate.Enabled = False
        End If
    End Sub
    Private Sub btnFMEdit_Click(sender As System.Object, e As System.EventArgs) Handles btnFMEdit.Click
        lFnFMEnableEdit(True, "Edit")
        btnFMEdit.Enabled = False
        btnFMCancel.Enabled = True
        btnFMSave.Enabled = True

        dtpFMMAMKSerStartDate.Enabled = True
        dtpFMMAMKSerStartDate.CustomFormat = "dd/MM/yyyy"
        dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom

        dtpFMSGSerStartDate.Enabled = True
        dtpFMSGSerStartDate.CustomFormat = "dd/MM/yyyy"
        dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom

        dtpFMSSESerStartDate.Enabled = True
        dtpFMSSESerStartDate.CustomFormat = "dd/MM/yyyy"
        dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom

        dtpFMSZENSerStartDate.Enabled = True
        dtpFMSZENSerStartDate.CustomFormat = "dd/MM/yyyy"
        dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom

        dtpFMSZENSerStartDate.Enabled = True
        dtpFMSZENSerStartDate.CustomFormat = "dd/MM/yyyy"
        dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom

        dtpFMUSSerStartDate.Enabled = True
        dtpFMUSSerStartDate.CustomFormat = "dd/MM/yyyy"
        dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom

        cboFMOrderPlaceMode.Font = New Font("arial, 9pt", 9, FontStyle.Bold)

        _tabSelectDisabled = True
    End Sub
    Private Sub btnFMSave_Click(sender As System.Object, e As System.EventArgs) Handles btnFMSave.Click





        Dim dsCheckClientMarketExists As DataSet = Nothing
        Dim dtCheckClientMarketExists As DataTable = Nothing

        Dim dsCheckForeignMarketExists As DataSet = Nothing
        Dim dtCheckForeignMarketExists As DataTable = Nothing

        Dim dsCheckThirdPartyMappingExists As DataSet = Nothing
        Dim dtCheckThirdPartyMappingExists As DataTable = Nothing

        Dim dsCheckThirdPartyMappingNotAccExists As DataSet = Nothing
        Dim dtCheckThirdPartyMappingNotAccExists As DataTable = Nothing

        Dim dsCheckThirdPartyMasterExists As DataSet = Nothing
        Dim dtCheckThirdPartyMasterExists As DataTable = Nothing

        Dim sFMMAMKSerStartDate As String = String.Empty
        Dim sFMSGSerStartDate As String = String.Empty
        Dim sFMSSESerStartDate As String = String.Empty
        Dim sFMRiskDisclosure As String = String.Empty
        Dim sFMSZENSerStartDate As String = String.Empty
        Dim sFMUSSerStartDate As String = String.Empty
        Dim sFMUSITradeStartDate As String = String.Empty
        Dim sFMUSServiceType As String = String.Empty
        Dim sFMUSStartDate As String = String.Empty
        Dim sFMUSEndDate As String = String.Empty
        Dim sFMUVOTCMarketStartDate As String = String.Empty
        Dim sFMChannel As String = String.Empty

        Dim sFMTPSerStartDate As String = String.Empty
        Dim sFMPlatform As String = String.Empty
        Dim sFMTPAccNo As String = String.Empty
        Dim sFMTPUsername As String = String.Empty
        Dim sFMRemarks As String = String.Empty

        Dim iErr As Integer
        iErr = 0
        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            If Not String.IsNullOrEmpty(lblFMAccNo.Text.ToString) Then


                If Not Me.dtpFMMAMKSerStartDate.Text.Trim.Contains("01/01/1900") And _
                    Not Me.dtpFMSGSerStartDate.Text.Trim.Contains("01/01/1900") And _
                    Not Me.dtpFMSSESerStartDate.Text.Trim.Contains("01/01/1900") And _
                    Not Me.dtpFMSZENSerStartDate.Text.Trim.Contains("01/01/1900") And _
                    Not Me.dtpFMUSSerStartDate.Text.Trim.Contains("01/01/1900") And _
                    Not Me.dtpUVOTCMarketStartDate.Text.Trim.Contains("01/01/1900") And _
                    Not Me.dtpFMUSITradeStartDate.Text.Trim.Contains("01/01/1900") And _
                    Not Me.dtpFMUSStartDate.Text.Trim.Contains("01/01/1900") And _
                    Not Me.dtpFMUSEndDate.Text.Trim.Contains("01/01/1900") And _
                    Not Me.dtpFMTPSerStartDate.Text.Trim.Contains("01/01/1900") Then


                    sFMMAMKSerStartDate = Me.dtpFMMAMKSerStartDate.Value.ToString("dd/MM/yyyy")
                    sFMSGSerStartDate = Me.dtpFMSGSerStartDate.Value.ToString("dd/MM/yyyy")
                    sFMSSESerStartDate = Me.dtpFMSSESerStartDate.Value.ToString("dd/MM/yyyy")


                    sFMSZENSerStartDate = Me.dtpFMSZENSerStartDate.Value.ToString("dd/MM/yyyy")
                    sFMUSSerStartDate = Me.dtpFMUSSerStartDate.Value.ToString("dd/MM/yyyy")
                    If cboFMOrderPlaceMode.SelectedIndex = 2 Then
                        sFMUSITradeStartDate = Me.dtpFMUSITradeStartDate.Value.ToString("dd/MM/yyyy")
                    Else
                        sFMUSITradeStartDate = ""
                    End If


                    sFMUSServiceType = "streaming"
                    sFMChannel = GFncSqlQuote(cboFMOrderPlaceMode.SelectedValue.ToString)
                    If chkUVOTCMarketStartDate.Checked = True Then
                        sFMUVOTCMarketStartDate = dtpUVOTCMarketStartDate.Value.ToString("dd/MM/yyyy")
                    Else
                        sFMUVOTCMarketStartDate = ""
                    End If

                    If chkFMUSStartStreaming.Checked = True Then
                        sFMUSStartDate = Me.dtpFMUSStartDate.Value.ToString("dd/MM/yyyy")
                    Else
                        sFMUSStartDate = ""
                    End If

                    If chkFMUSEndStreaming.Checked = True Then
                        sFMUSEndDate = Me.dtpFMUSEndDate.Value.ToString("dd/MM/yyyy")
                    Else
                        sFMUSEndDate = ""
                    End If

                    If chkFMTPSerStartdate.Checked = True Then
                        sFMTPSerStartDate = Me.dtpFMTPSerStartDate.Value.ToString("dd/MM/yyyy")
                    Else
                        sFMTPSerStartDate = ""
                    End If

                    sFMPlatform = GFncSqlQuote(txtFMPlatform.Text.ToString)
                    sFMTPAccNo = GFncSqlQuote(txtFMTPAccNo.Text.ToString)
                    sFMTPUsername = GFncSqlQuote(txtFMTPUsername.Text.ToString)
                    sFMRemarks = GFncSqlQuote(txtFMRemarks.Text.ToString)

                    Dim MyTrans As SqlTransaction = Nothing
                    Try
                        dsCheckClientMarketExists = cls.lFnGetClientMarketRecordByAcc(lblFMAccNo.Text.ToString)
                        If dsCheckClientMarketExists IsNot Nothing And dsCheckClientMarketExists.Tables.Count > 0 Then
                            dtCheckClientMarketExists = dsCheckClientMarketExists.Tables(0)
                        End If

                        dsCheckThirdPartyMappingExists = cls.lFnGetThirdPartyMappingByAccByPlatform(lblFMAccNo.Text.ToString, sFMPlatform)
                        If dsCheckThirdPartyMappingExists IsNot Nothing And dsCheckThirdPartyMappingExists.Tables.Count > 0 Then
                            dtCheckThirdPartyMappingExists = dsCheckThirdPartyMappingExists.Tables(0)
                        End If

                        dsCheckThirdPartyMasterExists = cls.lFnGetThirdPartyMasterByPlatform(sFMPlatform)
                        If dsCheckThirdPartyMasterExists IsNot Nothing And dsCheckThirdPartyMasterExists.Tables.Count > 0 Then
                            dtCheckThirdPartyMasterExists = dsCheckThirdPartyMasterExists.Tables(0)
                        End If

                        dsCheckThirdPartyMappingNotAccExists = cls.lFnGetThirdPartyMappingByNotAccPlatform(lblFMAccNo.Text.ToString, sFMPlatform, sFMTPAccNo)
                        If dsCheckThirdPartyMappingNotAccExists IsNot Nothing And dsCheckThirdPartyMappingNotAccExists.Tables.Count > 0 Then
                            dtCheckThirdPartyMappingNotAccExists = dsCheckThirdPartyMappingNotAccExists.Tables(0)
                        End If

                        MyTrans = GSCnSqlConn.BeginTransaction
                        If lblFMClientType.Text = "Securities" Then
                            For Each row As DataRow In dtCheckClientMarketExists.Rows

                                If dtCheckClientMarketExists.Rows.Count > 0 Then
                                    If Not row.IsNull(dtCheckClientMarketExists.Columns("MAMK")) Then
                                        Dim sMAMKYesNo As String = row("MAMK").ToString.Trim
                                        If sMAMKYesNo = "Yes" Then
                                            Dim sMarket As String
                                            sMarket = "MAMK"
                                            dsCheckForeignMarketExists = cls.lFnGetForeignMarketRecordByAccByMarket(MyTrans, lblFMAccNo.Text.ToString, sMarket)
                                            If dsCheckForeignMarketExists IsNot Nothing And dsCheckForeignMarketExists.Tables.Count > 0 Then
                                                dtCheckForeignMarketExists = dsCheckForeignMarketExists.Tables(0)
                                            End If
                                            If dtCheckForeignMarketExists.Rows.Count > 0 Then
                                                'edit
                                                type = "Edit"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "M", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnEditAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMMAMKSerStartDate, sFMRiskDisclosure, "", "", "")

                                            Else
                                                'add
                                                type = "Add"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "A", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnAddAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMMAMKSerStartDate, sFMRiskDisclosure, "", "", "")
                                            End If
                                        End If
                                    End If

                                    If Not row.IsNull(dtCheckClientMarketExists.Columns("SG")) Then
                                        Dim sSGYesNo As String = row("SG").ToString.Trim
                                        If sSGYesNo = "Yes" Then
                                            Dim sMarket As String
                                            sMarket = "SG"
                                            dsCheckForeignMarketExists = cls.lFnGetForeignMarketRecordByAccByMarket(MyTrans, lblFMAccNo.Text.ToString, sMarket)
                                            If dsCheckForeignMarketExists IsNot Nothing And dsCheckForeignMarketExists.Tables.Count > 0 Then
                                                dtCheckForeignMarketExists = dsCheckForeignMarketExists.Tables(0)
                                            End If
                                            If dtCheckForeignMarketExists.Rows.Count > 0 Then

                                                'edit
                                                type = "Edit"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "M", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnEditAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMSGSerStartDate, sFMRiskDisclosure, "", "", "")

                                            Else
                                                'add
                                                type = "Add"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "A", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnAddAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMSGSerStartDate, sFMRiskDisclosure, "", "", "")
                                            End If
                                        End If
                                    End If

                                    If Not row.IsNull(dtCheckClientMarketExists.Columns("SSE")) Then
                                        Dim sSSEYesNo As String = row("SSE").ToString.Trim
                                        If sSSEYesNo = "Yes" Then
                                            sFMRiskDisclosure = chkRiskDisclosure.CheckState
                                            Dim sMarket As String
                                            sMarket = "SSE"
                                            dsCheckForeignMarketExists = cls.lFnGetForeignMarketRecordByAccByMarket(MyTrans, lblFMAccNo.Text.ToString, sMarket)
                                            If dsCheckForeignMarketExists IsNot Nothing And dsCheckForeignMarketExists.Tables.Count > 0 Then
                                                dtCheckForeignMarketExists = dsCheckForeignMarketExists.Tables(0)
                                            End If
                                            If dtCheckForeignMarketExists.Rows.Count > 0 Then

                                                'edit
                                                type = "Edit"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "M", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnEditAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMSSESerStartDate, sFMRiskDisclosure, "", "", "")

                                            Else
                                                'add
                                                type = "Add"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "A", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnAddAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMSSESerStartDate, sFMRiskDisclosure, "", "", "")
                                            End If
                                        End If
                                        sFMRiskDisclosure = String.Empty
                                    End If

                                    If Not row.IsNull(dtCheckClientMarketExists.Columns("SZEN")) Then
                                        Dim sSZENYesNo As String = row("SZEN").ToString.Trim
                                        If sSZENYesNo = "Yes" Then
                                            Dim sMarket As String
                                            sMarket = "SZEN"
                                            dsCheckForeignMarketExists = cls.lFnGetForeignMarketRecordByAccByMarket(MyTrans, lblFMAccNo.Text.ToString, sMarket)
                                            If dsCheckForeignMarketExists IsNot Nothing And dsCheckForeignMarketExists.Tables.Count > 0 Then
                                                dtCheckForeignMarketExists = dsCheckForeignMarketExists.Tables(0)
                                            End If
                                            If dtCheckForeignMarketExists.Rows.Count > 0 Then

                                                'edit
                                                type = "Edit"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "M", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnEditAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMSZENSerStartDate, sFMRiskDisclosure, "", "", "")

                                            Else
                                                'add
                                                type = "Add"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "A", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnAddAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMSZENSerStartDate, sFMRiskDisclosure, "", "", "")
                                            End If
                                        End If
                                    End If

                                    If Not row.IsNull(dtCheckClientMarketExists.Columns("US")) Then

                                        Dim sUSYesNo As String = row("US").ToString.Trim
                                        If sUSYesNo = "Yes" Then
                                            Dim sMarket As String
                                            sMarket = "US"
                                            dsCheckForeignMarketExists = cls.lFnGetForeignMarketRecordByAccByMarket(MyTrans, lblFMAccNo.Text.ToString, "US")
                                            If dsCheckForeignMarketExists IsNot Nothing And dsCheckForeignMarketExists.Tables.Count > 0 Then
                                                dtCheckForeignMarketExists = dsCheckForeignMarketExists.Tables(0)
                                            End If
                                            If dtCheckForeignMarketExists.Rows.Count > 0 Then
                                                'For Each row1 As DataRow In dtCheckForeignMarketExists.Rows
                                                'edit
                                                type = "Edit"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "M", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnEditAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMUSSerStartDate, sFMRiskDisclosure, sFMChannel, sFMUSITradeStartDate, sFMUVOTCMarketStartDate)
                                                cls.lFnEditAdvServiceInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMUSServiceType, sFMUSStartDate, sFMUSEndDate)
                                                'Next
                                            Else
                                                'add
                                                type = "Add"
                                                cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "A", lfncGetLogFM(type, MyTrans, sMarket))
                                                cls.lFnAddAccountForeignInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMMAMKSerStartDate, sFMRiskDisclosure, sFMChannel, sFMUSITradeStartDate, sFMUVOTCMarketStartDate)
                                                cls.lFnAddAdvServiceInfo(MyTrans, lblFMAccNo.Text.ToString, sMarket, sFMUSServiceType, sFMUSStartDate, sFMUSEndDate)
                                            End If
                                        End If

                                    End If

                                End If

                            Next
                        End If

                        If lblFMClientType.Text = "Futures" Then

                            If sFMPlatform <> "" And sFMTPAccNo <> "" Then
                                If dtCheckThirdPartyMappingExists.Rows.Count > 0 Then

                                    If dtCheckThirdPartyMappingNotAccExists.Rows.Count > 0 Then
                                        MsgBox("this third party account is already used")
                                        iErr = 1
                                    Else
                                        'edit
                                        type = "Edit"

                                        cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "M", lfncGetLogThirdParty(type, MyTrans))
                                        cls.lFnEditThirdPartyMapping(MyTrans, lblFMAccNo.Text.ToString, sFMPlatform, sFMTPAccNo, sFMTPSerStartDate)

                                        cls.lFnEditThirdPartyMaster(MyTrans, psFMPlatform, psFMTPAccNo, sFMPlatform, sFMTPAccNo, sFMTPUsername, sFMRemarks)

                                    End If

                                Else
                                    If dtCheckThirdPartyMappingNotAccExists.Rows.Count > 0 Then
                                        MsgBox("this third party account is already used")
                                        iErr = 1
                                    Else
                                        type = "Add"
                                        cls.lFnWriteLog(MyTrans, Me.lblFMAccNo.Text, "A", lfncGetLogThirdParty(type, MyTrans))
                                        cls.lFnAddThirdPartyMapping(MyTrans, lblFMAccNo.Text.ToString, sFMPlatform, sFMTPAccNo, sFMTPSerStartDate)

                                        cls.lFnaddThirdPartyMaster(MyTrans, sFMPlatform, sFMTPAccNo, sFMTPUsername, sFMRemarks)

                                    End If
                                End If
                            End If
                        End If


                        If iErr = 1 Then
                            MyTrans.Rollback()
                            MyTrans = Nothing
                            'btnFMCancel_Click(sender, e)
                            Return
                        Else
                            MyTrans.Commit()
                            MyTrans = Nothing
                            GSubShowInfo(GFncGetSysMsg(8))
                            RefreshForeignMarket()
                            lFnFMEnableEdit(False, "Save")
                            btnFMEdit.Enabled = True
                            btnFMCancel.Enabled = False
                            btnFMSave.Enabled = False
                        End If





                    Catch ex As Exception

                        If GSCnSqlConn.State <> ConnectionState.Closed Then
                            If (MyTrans IsNot Nothing) Then
                                MyTrans.Rollback()
                            End If
                            GSubWriteErrLog(ex.Message)
                        End If
                    Finally
                        MyTrans = Nothing
                    End Try


                Else
                    MsgBox("Invalid date input")
                    btnFMCancel_Click(sender, e)
                End If

            End If
        Else
            btnFMCancel_Click(sender, e)
        End If

        dsCheckClientMarketExists = Nothing
        dtCheckClientMarketExists = Nothing

        dsCheckForeignMarketExists = Nothing
        dtCheckForeignMarketExists = Nothing

        dsCheckThirdPartyMappingExists = Nothing
        dtCheckThirdPartyMappingExists = Nothing

        dsCheckThirdPartyMasterExists = Nothing
        dtCheckThirdPartyMasterExists = Nothing

        dsCheckThirdPartyMappingNotAccExists = Nothing
        dtCheckThirdPartyMappingNotAccExists = Nothing

        _tabSelectDisabled = False
    End Sub

    Private Sub btnFMCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnFMCancel.Click

        Dim minDate As Date = #1/1/1900#
        Dim dtResultDate As DateTime

        lFnFMEnableEdit(False, "Cancel")
        btnFMEdit.Enabled = True
        btnFMCancel.Enabled = True
        btnFMSave.Enabled = False

        If DateTime.TryParseExact(psFMMAMKServStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            Me.dtpFMMAMKSerStartDate.Value = dtResultDate
        Else
            dtpFMMAMKSerStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMMAMKSerStartDate.Format = DateTimePickerFormat.Custom
        End If

        If DateTime.TryParseExact(psFMSGServStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            Me.dtpFMSGSerStartDate.Value = dtResultDate
        Else
            dtpFMSGSerStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMSGSerStartDate.Format = DateTimePickerFormat.Custom
        End If

        If DateTime.TryParseExact(psFMSSEServStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            Me.dtpFMSSESerStartDate.Value = dtResultDate
        Else
            dtpFMSSESerStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMSSESerStartDate.Format = DateTimePickerFormat.Custom
        End If

        If psFMRiskDisclosure = "1" Then
            Me.chkRiskDisclosure.Checked = psFMRiskDisclosure
        Else
            Me.chkRiskDisclosure.Checked = False
        End If

        If DateTime.TryParseExact(psFMSZENServStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            Me.dtpFMSZENSerStartDate.Value = dtResultDate
        Else
            dtpFMSZENSerStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMSZENSerStartDate.Format = DateTimePickerFormat.Custom
        End If

        If DateTime.TryParseExact(psFMUSServStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            Me.dtpFMUSSerStartDate.Value = dtResultDate
        Else
            dtpFMUSSerStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMUSSerStartDate.Format = DateTimePickerFormat.Custom
        End If

        If DateTime.TryParseExact(psFMITradeStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            Me.dtpFMUSITradeStartDate.Value = dtResultDate
        Else
            dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
        End If

        If DateTime.TryParseExact(psFMITradeStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            Me.dtpFMUSITradeStartDate.Value = dtResultDate

        Else
            dtpFMUSITradeStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMUSITradeStartDate.Format = DateTimePickerFormat.Custom
        End If

        cboFMOrderPlaceMode.Font = New Font("arial, 9pt", 9, FontStyle.Regular)
        If psFMOrderPlacingMode <> "" Then
            If psFMOrderPlacingMode.Trim = "P" Then
                cboFMOrderPlaceMode.SelectedIndex = 1
            ElseIf psFMOrderPlacingMode.Trim = "I" Then
                cboFMOrderPlaceMode.SelectedIndex = 2
            Else
                cboFMOrderPlaceMode.SelectedIndex = 0
            End If
        Else
            Me.cboFMOrderPlaceMode.Text = ""
        End If

        If DateTime.TryParseExact(psFMUVOTCMarketStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
            dtResultDate > minDate Then
            chkUVOTCMarketStartDate.Checked = True
            Me.dtpUVOTCMarketStartDate.Value = dtResultDate
            dtpUVOTCMarketStartDate.CustomFormat = "dd/MM/yyyy"
            dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
        Else
            chkUVOTCMarketStartDate.Checked = False
            dtpUVOTCMarketStartDate.CustomFormat = " "  'An empty SPACE
            dtpUVOTCMarketStartDate.Format = DateTimePickerFormat.Custom
        End If

        If DateTime.TryParseExact(psFMUSStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            chkFMUSStartStreaming.Checked = True
            Me.dtpFMUSStartDate.Value = dtResultDate
            dtpFMUSStartDate.CustomFormat = "dd/MM/yyyy"
            dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
        Else
            chkFMUSStartStreaming.Checked = False
            dtpFMUSStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMUSStartDate.Format = DateTimePickerFormat.Custom
        End If

        If DateTime.TryParseExact(psFMUSEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            chkFMUSEndStreaming.Checked = True
            Me.dtpFMUSEndDate.Value = dtResultDate
            dtpFMUSEndDate.CustomFormat = "dd/MM/yyyy"
            dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
        Else
            chkFMUSEndStreaming.Checked = False
            dtpFMUSEndDate.CustomFormat = " "  'An empty SPACE
            dtpFMUSEndDate.Format = DateTimePickerFormat.Custom
        End If

        If DateTime.TryParseExact(psFMTPServStartDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, dtResultDate) And _
           dtResultDate > minDate Then
            chkFMTPSerStartdate.Checked = True
            Me.dtpFMTPSerStartDate.Value = dtResultDate
            dtpFMTPSerStartDate.CustomFormat = "dd/MM/yyyy"
            dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom
        Else
            chkFMTPSerStartdate.Checked = False
            dtpFMTPSerStartDate.CustomFormat = " "  'An empty SPACE
            dtpFMTPSerStartDate.Format = DateTimePickerFormat.Custom
        End If

        If psFMPlatform <> "" Then
            Me.txtFMPlatform.Text = psFMPlatform
        Else
            Me.txtFMPlatform.Text = cboMarket.Text.ToString
        End If

        If psFMTPAccNo <> "" Then
            Me.txtFMTPAccNo.Text = psFMTPAccNo
        Else
            Me.txtFMTPAccNo.Text = ""
        End If

        If psFMTPUsername <> "" Then
            Me.txtFMTPUsername.Text = psFMTPUsername
        Else
            Me.txtFMTPUsername.Text = ""
        End If

        If psFMRemarks <> "" Then
            Me.txtFMRemarks.Text = psFMRemarks
        Else
            Me.txtFMRemarks.Text = ""
        End If

        _tabSelectDisabled = False
    End Sub

    Private Sub btnFMExit_Click(sender As System.Object, e As System.EventArgs) Handles btnFMExit.Click
        FrmFatcaAccMaster.MdiParent = Me.MdiParent
        FrmFatcaAccMaster.Activate()
        Me.Close()
    End Sub
    Public Function lfncGetLogFM(ByVal type As String, ByVal mytrans As SqlTransaction, ByVal sMarket As String) As String
        Dim Log As String = String.Empty
        Dim sFMMAMKSerStartDate As String = String.Empty
        Dim sFMSGSerStartDate As String = String.Empty
        Dim sFMSSESerStartDate As String = String.Empty
        Dim sFMRiskDisclosure As String = String.Empty
        Dim sFMSZENSerStartDate As String = String.Empty
        Dim sFMUSSerStartDate As String = String.Empty
        Dim sFMUSITradeStartDate As String = String.Empty
        Dim sFMUSStartDate As String = String.Empty
        Dim sFMUSEndDate As String = String.Empty
        Dim sFMUSchannel As String = String.Empty
        Dim sFMUSUVOTCMarketStartDate As String = String.Empty

        If type = "Add" Then
            Select Case sMarket
                Case "MAMK"
                    sFMMAMKSerStartDate = Me.dtpFMMAMKSerStartDate.Value.ToString("dd/MM/yyyy")
                    If sFMMAMKSerStartDate.Length > 0 Then
                        Log += GfncOneFieldLog("MAMKSerStartDate", sFMMAMKSerStartDate)
                    End If
                Case "SG"
                    sFMSGSerStartDate = Me.dtpFMSGSerStartDate.Value.ToString("dd/MM/yyyy")
                    If sFMSGSerStartDate.Length > 0 Then
                        Log += GfncOneFieldLog("SGSerStartDate", sFMSGSerStartDate)
                    End If
                Case "SSE"
                    sFMSSESerStartDate = Me.dtpFMSSESerStartDate.Value.ToString("dd/MM/yyyy")
                    If sFMSSESerStartDate.Length > 0 Then
                        Log += GfncOneFieldLog("SSESerStartDate", sFMSSESerStartDate)
                    End If
                    sFMRiskDisclosure = Me.chkRiskDisclosure.CheckState
                    If sFMRiskDisclosure.Length > 0 Then
                        Log += GfncOneFieldLog("RiskDisclosure", sFMRiskDisclosure)
                    End If
                Case "SZEN"
                    sFMSZENSerStartDate = Me.dtpFMSZENSerStartDate.Value.ToString("dd/MM/yyyy")
                    If sFMSZENSerStartDate.Length > 0 Then
                        Log += GfncOneFieldLog("SZENSerStartDate", sFMSZENSerStartDate)
                    End If
                Case "US"
                    sFMUSSerStartDate = Me.dtpFMUSSerStartDate.Value.ToString("dd/MM/yyyy")
                    If sFMUSSerStartDate.Length > 0 Then
                        Log += GfncOneFieldLog("USSerStartDate", sFMUSSerStartDate)
                    End If

                    sFMUSITradeStartDate = Me.dtpFMUSITradeStartDate.Value.ToString("dd/MM/yyyy")
                    If sFMUSITradeStartDate.Length > 0 Then
                        Log += GfncOneFieldLog("USITradeStartDate", sFMUSITradeStartDate)
                    End If

                    sFMUSchannel = Me.cboFMOrderPlaceMode.SelectedValue.ToString
                    If sFMUSchannel.Length > 0 Then
                        Log += GfncOneFieldLog("Channel", sFMUSchannel)
                    End If

                    sFMUSUVOTCMarketStartDate = Me.dtpUVOTCMarketStartDate.Value.ToString("dd/MM/yyyy")
                    If sFMUSUVOTCMarketStartDate.Length > 0 Then
                        Log += GfncOneFieldLog("USUVOTCMarketStartDate", sFMUSUVOTCMarketStartDate)
                    End If

                    sFMUSStartDate = Me.dtpFMUSStartDate.Value.ToString("dd/MM/yyyy")
                    If sFMUSStartDate.Length > 0 Then
                        Log += GfncOneFieldLog("USStartDate", sFMUSStartDate)
                    End If

                    sFMUSEndDate = Me.dtpFMUSEndDate.Value.ToString("dd/MM/yyyy")
                    If sFMUSEndDate.Length > 0 Then
                        Log += GfncOneFieldLog("USEndDate", sFMUSEndDate)
                    End If

            End Select

        Else

            If type = "Edit" Then
                Dim dtClientMarket As DataTable = Nothing
                Dim dsClientMarket As DataSet = Nothing
                dsClientMarket = cls.lFnGetForeignMarketRecordByAcc(mytrans, lblFMAccNo.Text.ToString, sMarket)
                If dsClientMarket IsNot Nothing And dsClientMarket.Tables.Count > 0 Then
                    dtClientMarket = dsClientMarket.Tables(0)
                End If
                If dtClientMarket.Rows.Count > 0 Then
                    Select Case sMarket
                        Case "MAMK"
                            sFMMAMKSerStartDate = Me.dtpFMMAMKSerStartDate.Value.ToString("dd/MM/yyyy")

                            If sFMMAMKSerStartDate <> GFncNoNullDate(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")).ToString("dd/MM/yyyy") Then
                                Log += GfncOneFieldLog("MAMKSerStartDate", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")), sFMMAMKSerStartDate)
                            End If


                        Case "SG"
                            sFMSGSerStartDate = Me.dtpFMSGSerStartDate.Value.ToString("dd/MM/yyyy")

                            If sFMSGSerStartDate <> GFncNoNullDate(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")).ToString("dd/MM/yyyy") Then
                                Log += GfncOneFieldLog("SGSerStartDate", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")), sFMSGSerStartDate)
                            End If

                        Case "SSE"
                            sFMSSESerStartDate = Me.dtpFMSSESerStartDate.Value.ToString("dd/MM/yyyy")

                            If sFMSSESerStartDate <> GFncNoNullDate(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")).ToString("dd/MM/yyyy") Then
                                Log += GfncOneFieldLog("SSESerStartDate", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")), sFMSSESerStartDate)
                            End If


                            sFMRiskDisclosure = Me.chkRiskDisclosure.CheckState

                            If sFMRiskDisclosure <> GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("RiskDisclosure")).ToString Then
                                Log += GfncOneFieldLog("RiskDisclosure", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("RiskDisclosure")).ToString, sFMUSchannel)
                            End If

                        Case "SZEN"
                            sFMSZENSerStartDate = Me.dtpFMSZENSerStartDate.Value.ToString("dd/MM/yyyy")

                            If sFMSZENSerStartDate <> GFncNoNullDate(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")).ToString("dd/MM/yyyy") Then
                                Log += GfncOneFieldLog("SZENSerStartDate", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")), sFMSZENSerStartDate)
                            End If

                        Case "US"
                            sFMUSSerStartDate = Me.dtpFMUSSerStartDate.Value.ToString("dd/MM/yyyy")

                            If sFMUSSerStartDate <> GFncNoNullDate(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")).ToString("dd/MM/yyyy") Then
                                Log += GfncOneFieldLog("USSerStartDate", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("ServiceStartDate")), sFMUSSerStartDate)
                            End If


                            If cboFMOrderPlaceMode.SelectedIndex = 2 Then
                                sFMUSITradeStartDate = Me.dtpFMUSITradeStartDate.Value.ToString("dd/MM/yyyy")
                            Else
                                sFMUSITradeStartDate = ""
                            End If
                            If sFMUSITradeStartDate <> GFncNoNullDate(dsClientMarket.Tables(0).Rows(0).Item("iTradeStartDate")).ToString("dd/MM/yyyy") Then
                                Log += GfncOneFieldLog("USITradeStartDate", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("iTradeStartDate")), sFMUSITradeStartDate)
                            End If


                            sFMUSchannel = Me.cboFMOrderPlaceMode.SelectedValue.ToString


                            If sFMUSchannel <> GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("Channel")).ToString Then
                                Log += GfncOneFieldLog("Channel", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("Channel")).ToString, sFMUSchannel)
                            End If



                            If chkUVOTCMarketStartDate.Checked = True Then
                                sFMUSUVOTCMarketStartDate = dtpUVOTCMarketStartDate.Value.ToString("dd/MM/yyyy")
                            Else
                                sFMUSUVOTCMarketStartDate = ""
                            End If
                            If sFMUSUVOTCMarketStartDate <> GFncNoNullDate(dsClientMarket.Tables(0).Rows(0).Item("UVOTCMarketStartDate")).ToString("dd/MM/yyyy") Then
                                Log += GfncOneFieldLog("UVOTCMarketStartDate", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("UVOTCMarketStartDate")), sFMUSUVOTCMarketStartDate)
                            End If

                            If chkFMUSStartStreaming.Checked = True Then
                                sFMUSStartDate = Me.dtpFMUSStartDate.Value.ToString("dd/MM/yyyy")
                            Else
                                sFMUSStartDate = ""
                            End If
                            If sFMUSStartDate <> GFncNoNullDate(dsClientMarket.Tables(0).Rows(0).Item("StartDate")).ToString("dd/MM/yyyy") Then
                                Log += GfncOneFieldLog("USStartDate", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("StartDate")), sFMUSStartDate)
                            End If


                            If chkFMUSEndStreaming.Checked = True Then
                                sFMUSEndDate = Me.dtpFMUSEndDate.Value.ToString("dd/MM/yyyy")
                            Else
                                sFMUSEndDate = ""
                            End If

                            If sFMUSEndDate <> GFncNoNullDate(dsClientMarket.Tables(0).Rows(0).Item("EndDate")).ToString("dd/MM/yyyy") Then
                                Log += GfncOneFieldLog("USEndDate", GFncNoNullString(dsClientMarket.Tables(0).Rows(0).Item("EndDate")), sFMUSEndDate)
                            End If

                    End Select

                End If

            End If
        End If
        Return Log
    End Function
    Public Function lfncGetLogThirdParty(ByVal type As String, ByVal mytrans As SqlTransaction) As String
        Dim Log As String = String.Empty
        Dim sFMTPSerStartDate As String = String.Empty
        Dim sFMPlatform As String = String.Empty
        Dim sFMTPAccNo As String = String.Empty
        Dim sFMTPUsername As String = String.Empty
        Dim sFMRemarks As String = String.Empty

        If type = "Add" Then
            sFMTPSerStartDate = Me.dtpFMTPSerStartDate.Value.ToString("dd/MM/yyyy")
            If sFMTPSerStartDate.Length > 0 Then
                Log += GfncOneFieldLog("FMTPSerStartDate", sFMTPSerStartDate)
            End If

            sFMPlatform = Me.txtFMPlatform.Text
            If sFMPlatform.Length > 0 Then
                Log += GfncOneFieldLog("Platform", sFMPlatform)
            End If

            sFMTPAccNo = Me.txtFMTPAccNo.Text
            If sFMTPAccNo.Length > 0 Then
                Log += GfncOneFieldLog("ThirdPartyAccNo", sFMTPAccNo)
            End If

            sFMTPUsername = Me.txtFMTPUsername.Text
            If sFMTPUsername.Length > 0 Then
                Log += GfncOneFieldLog("ThirdPartyUserName", sFMTPUsername)
            End If

            sFMRemarks = Me.txtFMRemarks.Text
            If sFMRemarks.Length > 0 Then
                Log += GfncOneFieldLog("Remarks", sFMRemarks)
            End If
        ElseIf type = "Edit" Then
            Dim dtThirdPartyAccMapping As DataTable = Nothing
            Dim dsThirdPartyAccMapping As DataSet = Nothing
            dsThirdPartyAccMapping = cls.lFnGetThirdPartyMappingByAccByPlatform(mytrans, lblFMAccNo.Text.ToString, psFMPlatform)
            If dsThirdPartyAccMapping IsNot Nothing And dsThirdPartyAccMapping.Tables.Count > 0 Then
                dtThirdPartyAccMapping = dsThirdPartyAccMapping.Tables(0)
            End If
            If dtThirdPartyAccMapping.Rows.Count > 0 Then

                If chkFMTPSerStartdate.Checked = True Then
                    sFMTPSerStartDate = dtpFMTPSerStartDate.Value.ToString("dd/MM/yyyy")
                Else
                    sFMTPSerStartDate = ""
                End If

                If sFMTPSerStartDate <> GFncNoNullDate(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("ServiceStartDate")).ToString("dd/MM/yyyy") Then
                    Log += GfncOneFieldLog("FMTPSerStartDate", GFncNoNullString(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("ServiceStartDate")), sFMTPSerStartDate)
                End If


                sFMPlatform = Me.txtFMPlatform.Text.ToString

                If sFMPlatform <> GFncNoNullString(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("Platform")).ToString Then
                    Log += GfncOneFieldLog("Platform", GFncNoNullString(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("Platform")).ToString, sFMPlatform)
                End If


                sFMTPAccNo = Me.txtFMTPAccNo.Text.ToString

                If sFMTPAccNo <> GFncNoNullString(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("ThirdPartyAccNo")).ToString Then
                    Log += GfncOneFieldLog("ThirdPartyAccNo", GFncNoNullString(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("ThirdPartyAccNo")).ToString, sFMTPAccNo)
                End If


                sFMTPUsername = Me.txtFMTPUsername.Text.ToString

                If sFMTPUsername <> GFncNoNullString(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("ThirdPartyUsername")).ToString Then
                    Log += GfncOneFieldLog("ThirdPartyUsername", GFncNoNullString(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("ThirdPartyUsername")).ToString, sFMTPUsername)
                End If


                sFMRemarks = Me.txtFMRemarks.Text.ToString

                If sFMRemarks <> GFncNoNullString(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("Remarks")).ToString Then
                    Log += GfncOneFieldLog("Remarks", GFncNoNullString(dsThirdPartyAccMapping.Tables(0).Rows(0).Item("Remarks")).ToString, sFMRemarks)
                End If

            End If

        End If
        Return Log
    End Function

End Class
