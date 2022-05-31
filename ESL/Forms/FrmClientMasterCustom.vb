Public Class FrmClientMasterCustom

    Dim cls As New ClsClientMasterCustom
    Private Const sViewAbbrev1 As String = "v1"
    Private Const sViewAbbrev2 As String = "v2"


    Private Sub FrmClientMasterCustom_Load(sender As Object, e As System.EventArgs) Handles Me.Load
        Dim ldsDetail As DataSet
        Dim ldsDetail2 As DataSet

        SetAutoScroll()

        chkAOD.Checked = False
        dtpAccOpenDateFrom.Text = Format(Date.Now, "yyyy/MM/dd")
        dtpAccOpenDateTo.Text = Format(Date.Now, "yyyy/MM/dd")
        dtpAccOpenDateFrom.CustomFormat = " "
        dtpAccOpenDateFrom.Format = DateTimePickerFormat.Custom
        dtpAccOpenDateTo.CustomFormat = " "
        dtpAccOpenDateTo.Format = DateTimePickerFormat.Custom
        rbECM01.Checked = True

        rbECM11.Checked = True
        rbECM31.Checked = True
        chkAccountStatus11.Enabled = False
        gbAS.Enabled = False
        cboAMLRiskLv.Enabled = False
        cboMarket.Enabled = False

        ldsDetail = cls.lFncGetAECode()
        ldsDetail2 = cls.lFncGetAECode()
        Me.cboAENoFrom.DataSource = ldsDetail.Tables("clt")
        Me.cboAENoFrom.DisplayMember = "aeno"
        Me.cboAENoTo.DataSource = ldsDetail2.Tables("clt")
        Me.cboAENoTo.DisplayMember = "aeno"




    End Sub
    Private Sub btnCancel_Click(sender As System.Object, e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExport_Click(sender As System.Object, e As System.EventArgs) Handles btnExport.Click
        Dim strExFile As String = "clientmastercustom.csv"
        Dim dt As DataTable
        Dim sSQL As String
        Dim sAT As String
        Dim sAN As String
        Dim sAS As String
        Dim sCT As String

        Dim sFieldsToBeIncludedInput As String
        Dim sFieldsToBeIncludedOutput As String

        Dim sTitleToBeIncludedOutput As String

        Dim sAODF As String
        Dim sAODT As String

        sSQL = ""
        sAT = ""
        sAN = ""
        sAS = ""
        sCT = ""
        sAODF = ""
        sAODT = ""
        sFieldsToBeIncludedInput = ""
        sFieldsToBeIncludedOutput = ""
        sTitleToBeIncludedOutput = ""

        'Account Open Date
        If chkAOD.Checked = True Then
            sAODF = Format(dtpAccOpenDateFrom.Value, "yyyy/MM/dd")
            sAODT = Format(dtpAccOpenDateTo.Value, "yyyy/MM/dd")
        Else
            dtpAccOpenDateFrom.CustomFormat = " "
            dtpAccOpenDateTo.CustomFormat = " "
            sAODF = ""
            sAODT = ""
        End If


        'Account Type
        If rbECM01.Checked = True Then
            sAT = "ALL"
        ElseIf rbECM02.Checked = True Then
            sAT = "Securities"
        ElseIf rbECM03.Checked = True Then
            sAT = "Futures"
        ElseIf rbECM04.Checked = True Then
            sAT = "CIES"
        End If

        'Acount Nature
        If rbECM11.Checked = True Then
            sAN = "ALL"
        ElseIf rbECM12.Checked = True Then
            sAN = "Individual"
        ElseIf rbECM13.Checked = True Then
            sAN = "Joint"
        ElseIf rbECM14.Checked = True Then
            sAN = "Corporation"
        End If

        'Account Status
        If rbECM21.Checked = True Then
            sAS = "ALL"
        ElseIf rbECM22.Checked = True Then
            sAS = "Active"
        ElseIf rbECM23.Checked = True Then
            sAS = "Suspended"
        ElseIf rbECM24.Checked = True Then
            sAS = "Closed"
        End If

        'Client Type
        If rbECM31.Checked = True Then
            sCT = "ALL"
        ElseIf rbECM32.Checked = True Then
            sCT = "2" 'Cash
        ElseIf rbECM33.Checked = True Then
            sCT = "1" 'Margin
        End If

        'AML risk level

        ' Market

        'Account Info



        Dim arrClientMasterCustomColumnLibrary As New ArrayList

        SetClientMasterCustomColumnLibrary(arrClientMasterCustomColumnLibrary, sViewAbbrev1, sViewAbbrev2)


        Dim obj As New ClientMasterCustomColumnLibrary


        sFieldsToBeIncludedInput = genSQLAccountInfo()
        If sFieldsToBeIncludedInput.Length <> 0 Then
            sSQL = "SELECT DataField FROM ReportParam WHERE " & sFieldsToBeIncludedInput
            dt = GFncRtnDS(GSCnSqlConn, sSQL, 0).Tables(0)
            For Each dr As DataRow In dt.Rows
                If GFncNoNullString(dr("DataField")) <> "" Then
                    For Each obj In arrClientMasterCustomColumnLibrary
                        Dim sColumn As String
                        sColumn = obj.getColumn.ToString
                        sColumn = obj.getSpecialField.ToString
                        If obj.getColumn.ToString = GFncNoNullString(dr("DataField")) Then
                            sColumn = obj.getColumn.ToString
                            sColumn = obj.getSpecialField.ToString                            
                            If obj.getSpecialField.ToString <> "" Then
                                sFieldsToBeIncludedOutput = sFieldsToBeIncludedOutput & obj.getSpecialField & ","
                            Else
                                sFieldsToBeIncludedOutput = sFieldsToBeIncludedOutput & obj.getViewColumn & ","
                            End If

                        End If
                    Next
                End If
            Next
            sFieldsToBeIncludedOutput = sFieldsToBeIncludedOutput.Substring(0, sFieldsToBeIncludedOutput.LastIndexOf(","))

            ' begin set title
            sTitleToBeIncludedOutput = sFieldsToBeIncludedOutput

            'If chkAccountInfo14.Checked = True Then
            '    sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace("dbo.f_GetBankcodeByAccNo(" & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".client_type) AS bank_code_1,", "bank_code_1,")
            '    sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace("dbo.f_GetBankcodeByAccNo(" & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".client_type) AS bank_code_1", "bank_code_1")
            'End If
            If chkAccountInfo13.Checked = True Then
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace(sViewAbbrev1 & ".branch_name,", "AEBranch,")
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace(sViewAbbrev1 & ".branch_name", "AEBranch")
            End If
            If chkAccountInfo15.Checked = True Then
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace(sViewAbbrev1 & ".type,", "client_type,")
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace(sViewAbbrev1 & ".type", "client_type")
            End If

            If chkAddressInfo11.Checked = True Then
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace("LTRIM(RTRIM(addr_1)) AS corr_addr_1, LTRIM(RTRIM(addr_2)) AS corr_addr_2, LTRIM(RTRIM(addr_3)) AS corr_addr_3, LTRIM(RTRIM(addr_4)) AS corr_addr_4,", "corr_addr_1, corr_addr_2, corr_addr_3, corr_addr_4,")
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace("LTRIM(RTRIM(addr_1)) AS corr_addr_1, LTRIM(RTRIM(addr_2)) AS corr_addr_2, LTRIM(RTRIM(addr_3)) AS corr_addr_3, LTRIM(RTRIM(addr_4)) AS corr_addr_4", "corr_addr_1, corr_addr_2, corr_addr_3, corr_addr_4,")
            End If
            If chkAddressInfo12.Checked = True Then
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace("LTRIM(RTRIM(nd_addr_1)) AS resid_addr_1, LTRIM(RTRIM(nd_addr_2)) AS resid_addr_2, LTRIM(RTRIM(nd_addr_3)) AS resid_addr_3, LTRIM(RTRIM(nd_addr_4)) AS resid_addr_4,", "resid_addr_1, resid_addr_2, resid_addr_3, resid_addr_4,")
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace("LTRIM(RTRIM(nd_addr_1)) AS resid_addr_1, LTRIM(RTRIM(nd_addr_2)) AS resid_addr_2, LTRIM(RTRIM(nd_addr_3)) AS resid_addr_3, LTRIM(RTRIM(nd_addr_4)) AS resid_addr_4", "resid_addr_1, resid_addr_2, resid_addr_3, resid_addr_4")
            End If

            If chkOthers11.Checked = True Then
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace(sViewAbbrev1 & ".notes,", "Remarks,")
                sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace(sViewAbbrev1 & ".notes", "Remarks")
            End If
            sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace(sViewAbbrev1 & ".", "")
            sTitleToBeIncludedOutput = sTitleToBeIncludedOutput.Replace(sViewAbbrev2 & ".", "")
            ' end set title
        End If



        If (lIsValidClient() = True And lIsValidClient() = True) Then
            If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
                    If (cls.lFncExportClientMasterS(strExFile, Me.txtAccNoFrom.Text, Me.txtAccNoTo.Text, _
    Me.cboAENoFrom.Text, Me.cboAENoTo.Text, sAODF, sAODT, sAT, sAN, sAS, sCT, sTitleToBeIncludedOutput, sFieldsToBeIncludedOutput, sViewAbbrev1, sViewAbbrev2) = True) Then
                        GSubShowInfo(GFncGetSysMsg(28))
                    Else
                        GSubShowInfo(GFncGetSysMsg(29))
                    End If
            End If

        End If
    End Sub

    Private Function lIsValidClient() As Boolean

        If (Me.txtAccNoFrom.Text.Trim.Length > 0 And Me.txtAccNoTo.Text.Trim.Length > 0) Then
            If (Me.txtAccNoTo.Text < Me.txtAccNoFrom.Text) Then
                GSubShowInfo(GFncGetSysMsg(5))
                Me.txtAccNoFrom.Focus()
                Return False
            End If
        End If

        Return True

    End Function
    Private Function genSQLAccountInfo() As String
        Dim sFunctionGroup As String
        Dim sFunctionName As String
        Dim bTick As Boolean
        Dim sSql As String

        bTick = False
        sSql = ""

        'start check tick AcctInfo
        sFunctionGroup = "(FunctionGroup='AcctInfo' AND "
        sFunctionName = "FunctionName IN ("

        If chkAccountInfo11.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'AECode',"
        End If
        If chkAccountInfo12.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'AEName',"
        End If
        If chkAccountInfo13.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'AEBranch',"
        End If
        If chkAccountInfo14.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'BankCode',"
        End If
        If chkAccountInfo15.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'ClientType',"
        End If
        If chkAccountInfo16.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'ExternalAcctNo',"
        End If
        If chkAccountInfo17.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'AccountNature',"
        End If
        If chkAccountInfo18.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'ClientBranch',"
        End If

        If bTick = True Then
            sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
            sFunctionName = sFunctionName & ")) OR "
            sSql = sSql & sFunctionGroup & sFunctionName
        End If
        'end check tick AcctInfo

        'start check tick AcctStatus
        bTick = False
        sFunctionGroup = "(FunctionGroup='AcctStatus' AND "
        sFunctionName = "FunctionName IN ("

        If chkAccountStatus11.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'AcctStatus',"
        End If
        If chkAccountStatus12.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'AcctOpenDate',"
        End If
        If chkAccountStatus13.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'RenewalDate',"
        End If
        If chkAccountStatus14.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'LastTxnDate',"
        End If
        If chkAccountStatus15.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'SuspendField',"
        End If
        If chkAccountStatus16.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'SuspendCode',"
        End If
        If chkAccountStatus17.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'SuspendDate',"
        End If
        If chkAccountStatus18.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'CloseDate',"
        End If
        If bTick = True Then
            sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
            sFunctionName = sFunctionName & ")) OR "
            sSql = sSql & sFunctionGroup & sFunctionName
        End If
        'end check tick AcctStatus

        'start check tick ClientInfo
        bTick = False
        sFunctionGroup = "(FunctionGroup='ClientInfo' AND "
        sFunctionName = "FunctionName IN ("

        If chkClientInfo11.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Nationality',"
        End If
        If chkClientInfo12.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'IDPassport',"
        End If
        If chkClientInfo13.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Gender',"
        End If
        If chkClientInfo14.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'DateOfBirth',"
        End If
        If bTick = True Then
            sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
            sFunctionName = sFunctionName & ")) OR "
            sSql = sSql & sFunctionGroup & sFunctionName
        End If
        'end check tick ClientInfo

        'start check tick ContactDetails
        bTick = False
        sFunctionGroup = "(FunctionGroup='ContactDetails' AND "
        sFunctionName = "FunctionName IN ("

        If chkContactDetails11.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Phone_1',"
        End If
        If chkContactDetails12.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Phone_2',"
        End If
        If chkContactDetails13.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Phone_3',"
        End If
        If chkContactDetails14.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Fax',"
        End If
        If chkContactDetails14.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'email',"
        End If
        If bTick = True Then
            sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
            sFunctionName = sFunctionName & ")) OR "
            sSql = sSql & sFunctionGroup & sFunctionName
        End If
        'end check tick ContactDetails

        'start check tick AddressInfo
        bTick = False
        sFunctionGroup = "(FunctionGroup='AddressInfo' AND "
        sFunctionName = "FunctionName IN ("

        If chkAddressInfo11.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'CorrespondenceAddress',"
        End If
        If chkAddressInfo12.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'ResidentialAddress',"
        End If
        If chkAddressInfo13.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'MailStatus',"
        End If
        If bTick = True Then
            sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
            sFunctionName = sFunctionName & ")) OR "
            sSql = sSql & sFunctionGroup & sFunctionName
        End If
        'end check tick AddressInfo

        'start check tick Risk Control
        bTick = False
        sFunctionGroup = "(FunctionGroup='Risk Control' AND "
        sFunctionName = "FunctionName IN ("

        If chkRiskControl11.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'NetTradeLmt',"
        End If
        If chkRiskControl12.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'CreditLmt',"
        End If
        If chkRiskControl13.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'ExternalCreditLmt',"
        End If

        If bTick = True Then
            sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
            sFunctionName = sFunctionName & ")) OR "
            sSql = sSql & sFunctionGroup & sFunctionName
        End If
        'end check tick Risk Control

        'start check tick Staff Dealing
        bTick = False
        sFunctionGroup = "(FunctionGroup='Staff Dealing' AND "
        sFunctionName = "FunctionName IN ("

        If chkStaffDealing11.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Category',"
        End If
        If chkStaffDealing12.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Relationship',"
        End If
        If chkStaffDealing13.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'RelationStaff',"
        End If
        If chkStaffDealing13.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'RelationAE',"
        End If
        If bTick = True Then
            sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
            sFunctionName = sFunctionName & ")) OR "
            sSql = sSql & sFunctionGroup & sFunctionName
        End If
        'end check tick Staff Dealing

        'start check tick Others
        bTick = False
        sFunctionGroup = "(FunctionGroup='Others' AND "
        sFunctionName = "FunctionName IN ("

        If chkOthers11.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Notes',"
        End If
        If chkOthers12.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'Memo',"
        End If
        If chkOthers13.Checked = True Then
            bTick = True
            sFunctionName = sFunctionName & "'FeeClass',"
        End If

        If bTick = True Then
            sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
            sFunctionName = sFunctionName & ")) OR "
            sSql = sSql & sFunctionGroup & sFunctionName
        End If
        'end check tick Others

        'start check tick Market
        If rbECM02.Checked = False And rbECM04.Checked = False Then
            bTick = False
            sFunctionGroup = "(FunctionGroup='Market' AND "
            sFunctionName = "FunctionName IN ("

            If chkMarket11.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'CBT',"
            End If
            If chkMarket12.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'CJCE',"
            End If
            If chkMarket13.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'CME',"
            End If
            If chkMarket14.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'CMX',"
            End If
            If chkMarket15.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'HKEX',"
            End If
            If chkMarket16.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'LME',"
            End If
            If chkMarket17.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'NYB',"
            End If
            If chkMarket18.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'NYM',"
            End If
            If chkMarket19.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'TGE',"
            End If
            If chkMarket20.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'TOCOM',"
            End If
            If chkMarket21.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'SGX',"
            End If

            If bTick = True Then
                sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
                sFunctionName = sFunctionName & ")) OR "
                sSql = sSql & sFunctionGroup & sFunctionName
            End If
        End If
        'end check tick Market

        'start check tick MarketS
        If rbECM03.Checked = False Then
            bTick = False
            sFunctionGroup = "(FunctionGroup='MarketS' AND "
            sFunctionName = "FunctionName IN ("

            If chkMarketS11.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'SEHK',"
            End If
            If chkMarketS13.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'TF',"
            End If
            If chkMarketS14.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'CBUS',"
            End If
            If chkMarketS15.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'CBHK',"
            End If
            If chkMarketS16.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'SG',"
            End If
            If chkMarketS18.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'BDHK',"
            End If
            If chkMarketS19.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'FUND',"
            End If
            If chkMarketS20.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'US',"
            End If
            If chkMarketS21.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'BDCN',"
            End If
            If chkMarketS22.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'MAMK',"
            End If
            If chkMarketS23.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'ASX',"
            End If
            If chkMarketS24.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'BDAU',"
            End If
            If chkMarketS25.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'CA',"
            End If
            If chkMarketS26.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'NSX',"
            End If
            If chkMarketS27.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'SS',"
            End If
            If chkMarketS28.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'SZ',"
            End If
            If chkMarketS29.Checked = True Then
                bTick = True
                sFunctionName = sFunctionName & "'SZMK',"
            End If

            If bTick = True Then
                sFunctionName = sFunctionName.Substring(0, Len(sFunctionName) - 1)
                sFunctionName = sFunctionName & ")) OR "
                sSql = sSql & sFunctionGroup & sFunctionName
            End If
        End If
        'end check tick MarketS

        If sSql.Length <> 0 Then
            sSql = sSql.Substring(0, sSql.LastIndexOf("OR"))
        End If

        Return sSql
    End Function
    Private Sub rbECM01_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbECM01.CheckedChanged
        If rbECM01.Checked = True Then
            chkOthers13.Enabled = True
            chkOthers13.Checked = False
        Else
            chkOthers13.Enabled = True
        End If
    End Sub
    Private Sub rbECM02_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbECM02.CheckedChanged
        If rbECM02.Checked = True Then
            chkOthers13.Enabled = False
            chkOthers13.Checked = False
        Else
            chkOthers13.Enabled = True
        End If
    End Sub
    Private Sub rbECM03_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbECM03.CheckedChanged
        If rbECM03.Checked = True Then
            chkOthers13.Enabled = True
        Else
            chkOthers13.Enabled = False
            chkOthers13.Checked = False
        End If
    End Sub
    Private Sub rbECM04_CheckedChanged(sender As Object, e As System.EventArgs) Handles rbECM04.CheckedChanged
        If rbECM04.Checked = True Then
            chkOthers13.Enabled = False
            chkOthers13.Checked = False
        Else
            chkOthers13.Enabled = True
        End If
    End Sub
    Private Sub chkAllFields_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAllFields.CheckedChanged
        If chkAllFields.Checked = True Then

            chkAccountInfo10.Checked = True
            chkAccountInfo11.Checked = True
            chkAccountInfo12.Checked = True
            chkAccountInfo13.Checked = True
            chkAccountInfo14.Checked = True
            chkAccountInfo15.Checked = True
            chkAccountInfo16.Checked = True
            chkAccountInfo16.Checked = True

            chkAccountStatus10.Checked = True
            chkAccountStatus11.Checked = False
            chkAccountStatus12.Checked = True
            chkAccountStatus13.Checked = True
            chkAccountStatus14.Checked = True
            chkAccountStatus15.Checked = True
            chkAccountStatus16.Checked = True
            chkAccountStatus17.Checked = True
            chkAccountStatus18.Checked = True

            chkClientInfo10.Checked = True
            chkClientInfo11.Checked = True
            chkClientInfo12.Checked = True
            chkClientInfo13.Checked = True
            chkClientInfo14.Checked = True

            chkContactDetails10.Checked = True
            chkContactDetails11.Checked = True
            chkContactDetails12.Checked = True
            chkContactDetails13.Checked = True
            chkContactDetails14.Checked = True
            chkContactDetails15.Checked = True

            chkAddressInfo10.Checked = True
            chkAddressInfo11.Checked = True
            chkAddressInfo12.Checked = True
            chkAddressInfo13.Checked = True

            chkRiskControl10.Checked = True
            chkRiskControl11.Checked = True
            chkRiskControl12.Checked = True
            chkRiskControl13.Checked = True

            chkStaffDealing10.Checked = True
            chkStaffDealing11.Checked = True
            chkStaffDealing12.Checked = True
            chkStaffDealing13.Checked = True
            chkStaffDealing14.Checked = True

            chkOthers10.Checked = True
            chkOthers11.Checked = True
            chkOthers12.Checked = True
            If rbECM01.Checked = True Or rbECM03.Checked = True Then
                chkOthers13.Checked = True
            Else
                chkOthers13.Checked = False
            End If


            chkMarket10.Checked = True
            chkMarket11.Checked = True
            chkMarket12.Checked = True
            chkMarket13.Checked = True
            chkMarket14.Checked = True
            chkMarket15.Checked = True
            chkMarket16.Checked = True
            chkMarket17.Checked = True
            chkMarket18.Checked = True
            chkMarket19.Checked = True
            chkMarket20.Checked = True
            chkMarket21.Checked = True

            chkMarketS10.Checked = True
            chkMarketS11.Checked = True
            chkMarketS13.Checked = True
            chkMarketS14.Checked = True
            chkMarketS15.Checked = True
            chkMarketS16.Checked = True
            chkMarketS18.Checked = True
            chkMarketS19.Checked = True
            chkMarketS20.Checked = True
            chkMarketS21.Checked = True
            chkMarketS22.Checked = True
            chkMarketS23.Checked = True
            chkMarketS24.Checked = True
            chkMarketS25.Checked = True
            chkMarketS26.Checked = True
            chkMarketS27.Checked = True
            chkMarketS28.Checked = True
            chkMarketS29.Checked = True

        Else

            chkAccountInfo10.Checked = False
            chkAccountInfo11.Checked = False
            chkAccountInfo12.Checked = False
            chkAccountInfo13.Checked = False
            chkAccountInfo14.Checked = False
            chkAccountInfo15.Checked = False
            chkAccountInfo16.Checked = False
            chkAccountInfo17.Checked = False
            chkAccountInfo18.Checked = False

            chkAccountStatus10.Checked = False
            chkAccountStatus11.Checked = False
            chkAccountStatus12.Checked = False
            chkAccountStatus13.Checked = False
            chkAccountStatus14.Checked = False
            chkAccountStatus15.Checked = False
            chkAccountStatus16.Checked = False
            chkAccountStatus17.Checked = False
            chkAccountStatus18.Checked = False

            chkClientInfo10.Checked = False
            chkClientInfo11.Checked = False
            chkClientInfo12.Checked = False
            chkClientInfo13.Checked = False
            chkClientInfo14.Checked = False

            chkContactDetails10.Checked = False
            chkContactDetails11.Checked = False
            chkContactDetails12.Checked = False
            chkContactDetails13.Checked = False
            chkContactDetails14.Checked = False
            chkContactDetails15.Checked = False

            chkAddressInfo10.Checked = False
            chkAddressInfo11.Checked = False
            chkAddressInfo12.Checked = False
            chkAddressInfo13.Checked = False


            chkRiskControl10.Checked = False
            chkRiskControl11.Checked = False
            chkRiskControl12.Checked = False
            chkRiskControl13.Checked = False

            chkStaffDealing10.Checked = False
            chkStaffDealing11.Checked = False
            chkStaffDealing12.Checked = False
            chkStaffDealing13.Checked = False
            chkStaffDealing14.Checked = False

            chkOthers10.Checked = False
            chkOthers11.Checked = False
            chkOthers12.Checked = False
            chkOthers13.Checked = False

            chkMarket10.Checked = False
            chkMarket11.Checked = False
            chkMarket12.Checked = False
            chkMarket13.Checked = False
            chkMarket14.Checked = False
            chkMarket15.Checked = False
            chkMarket16.Checked = False
            chkMarket17.Checked = False
            chkMarket18.Checked = False
            chkMarket19.Checked = False
            chkMarket20.Checked = False
            chkMarket21.Checked = False

            chkMarketS10.Checked = False
            chkMarketS11.Checked = False
            chkMarketS13.Checked = False
            chkMarketS14.Checked = False
            chkMarketS15.Checked = False
            chkMarketS16.Checked = False
            chkMarketS18.Checked = False
            chkMarketS19.Checked = False
            chkMarketS20.Checked = False
            chkMarketS21.Checked = False
            chkMarketS22.Checked = False
            chkMarketS23.Checked = False
            chkMarketS24.Checked = False
            chkMarketS25.Checked = False
            chkMarketS26.Checked = False
            chkMarketS27.Checked = False
            chkMarketS28.Checked = False
            chkMarketS29.Checked = False
        End If


    End Sub

    Private Sub chkAccountInfo10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAccountInfo10.CheckedChanged
        If chkAccountInfo10.Checked = True Then
            chkAccountInfo10.Checked = True
            chkAccountInfo11.Checked = True
            chkAccountInfo12.Checked = True
            chkAccountInfo13.Checked = True
            chkAccountInfo14.Checked = True
            chkAccountInfo15.Checked = True
            chkAccountInfo16.Checked = True
            chkAccountInfo17.Checked = True
            chkAccountInfo18.Checked = True
        Else
            chkAccountInfo10.Checked = False
            chkAccountInfo11.Checked = False
            chkAccountInfo12.Checked = False
            chkAccountInfo13.Checked = False
            chkAccountInfo14.Checked = False
            chkAccountInfo15.Checked = False
            chkAccountInfo16.Checked = False
            chkAccountInfo17.Checked = False
            chkAccountInfo18.Checked = False
        End If

    End Sub

    Private Sub chkAccountStatus10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAccountStatus10.CheckedChanged
        If chkAccountStatus10.Checked = True Then
            chkAccountStatus11.Checked = False
            chkAccountStatus12.Checked = True
            chkAccountStatus13.Checked = True
            chkAccountStatus14.Checked = True
            chkAccountStatus15.Checked = True
            chkAccountStatus16.Checked = True
            chkAccountStatus17.Checked = True
            chkAccountStatus18.Checked = True
        Else
            chkAccountStatus11.Checked = False
            chkAccountStatus12.Checked = False
            chkAccountStatus13.Checked = False
            chkAccountStatus14.Checked = False
            chkAccountStatus15.Checked = False
            chkAccountStatus16.Checked = False
            chkAccountStatus17.Checked = False
            chkAccountStatus18.Checked = False
        End If
    End Sub

    Private Sub chkClientInfo10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkClientInfo10.CheckedChanged
        If chkClientInfo10.Checked = True Then
            chkClientInfo11.Checked = True
            chkClientInfo12.Checked = True
            chkClientInfo13.Checked = True
            chkClientInfo14.Checked = True
        Else
            chkClientInfo11.Checked = False
            chkClientInfo12.Checked = False
            chkClientInfo13.Checked = False
            chkClientInfo14.Checked = False
        End If
    End Sub

    Private Sub chkContactDetails10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkContactDetails10.CheckedChanged
        If chkContactDetails10.Checked = True Then
            chkContactDetails11.Checked = True
            chkContactDetails12.Checked = True
            chkContactDetails13.Checked = True
            chkContactDetails14.Checked = True
            chkContactDetails15.Checked = True
        Else
            chkContactDetails11.Checked = False
            chkContactDetails12.Checked = False
            chkContactDetails13.Checked = False
            chkContactDetails14.Checked = False
            chkContactDetails15.Checked = False
        End If

    End Sub

    Private Sub chkAddressInfo10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAddressInfo10.CheckedChanged
        If chkAddressInfo10.Checked = True Then
            chkAddressInfo11.Checked = True
            chkAddressInfo12.Checked = True
            chkAddressInfo13.Checked = True
        Else
            chkAddressInfo11.Checked = False
            chkAddressInfo12.Checked = False
            chkAddressInfo13.Checked = False
        End If
    End Sub

    Private Sub chkRiskControl10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkRiskControl10.CheckedChanged
        If chkRiskControl10.Checked = True Then
            chkRiskControl11.Checked = True
            chkRiskControl12.Checked = True
            chkRiskControl13.Checked = True
        Else
            chkRiskControl11.Checked = False
            chkRiskControl12.Checked = False
            chkRiskControl13.Checked = False
        End If
    End Sub

    Private Sub chkStaffDealing10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkStaffDealing10.CheckedChanged
        If chkStaffDealing10.Checked = True Then
            chkStaffDealing11.Checked = True
            chkStaffDealing12.Checked = True
            chkStaffDealing13.Checked = True
            chkStaffDealing14.Checked = True
        Else
            chkStaffDealing11.Checked = False
            chkStaffDealing12.Checked = False
            chkStaffDealing13.Checked = False
            chkStaffDealing14.Checked = False
        End If
    End Sub

    Private Sub chkOthers10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkOthers10.CheckedChanged
        If chkOthers10.Checked = True Then
            chkOthers11.Checked = True
            chkOthers12.Checked = True
            If rbECM01.Checked = True Or rbECM03.Checked = True Then
                chkOthers13.Checked = True
            Else
                chkOthers13.Checked = False
            End If
        Else
            chkOthers11.Checked = False
            chkOthers12.Checked = False
            chkOthers13.Checked = False
        End If
    End Sub

    Private Sub chkMarket10_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkMarket10.CheckedChanged
        If chkMarket10.Checked = True Then
            chkMarket11.Checked = True
            chkMarket12.Checked = True
            chkMarket13.Checked = True
            chkMarket14.Checked = True
            chkMarket15.Checked = True
            chkMarket16.Checked = True
            chkMarket17.Checked = True
            chkMarket18.Checked = True
            chkMarket19.Checked = True
            chkMarket20.Checked = True
            chkMarket21.Checked = True
        Else
            chkMarket11.Checked = False
            chkMarket12.Checked = False
            chkMarket13.Checked = False
            chkMarket14.Checked = False
            chkMarket15.Checked = False
            chkMarket16.Checked = False
            chkMarket17.Checked = False
            chkMarket18.Checked = False
            chkMarket19.Checked = False
            chkMarket20.Checked = False
            chkMarket21.Checked = False
        End If
    End Sub
    Private Sub chkMarketS10_CheckedChanged(sender As Object, e As System.EventArgs) Handles chkMarketS10.CheckedChanged
        If chkMarketS10.Checked = True Then
            chkMarketS10.Checked = True
            chkMarketS11.Checked = True
            chkMarketS13.Checked = True
            chkMarketS14.Checked = True
            chkMarketS15.Checked = True
            chkMarketS16.Checked = True
            chkMarketS18.Checked = True
            chkMarketS19.Checked = True
            chkMarketS20.Checked = True
            chkMarketS21.Checked = True
            chkMarketS22.Checked = True
            chkMarketS23.Checked = True
            chkMarketS24.Checked = True
            chkMarketS25.Checked = True
            chkMarketS26.Checked = True
            chkMarketS27.Checked = True
            chkMarketS28.Checked = True
            chkMarketS29.Checked = True
        Else
            chkMarketS10.Checked = False
            chkMarketS11.Checked = False
            chkMarketS13.Checked = False
            chkMarketS14.Checked = False
            chkMarketS15.Checked = False
            chkMarketS16.Checked = False
            chkMarketS18.Checked = False
            chkMarketS19.Checked = False
            chkMarketS20.Checked = False
            chkMarketS21.Checked = False
            chkMarketS22.Checked = False
            chkMarketS23.Checked = False
            chkMarketS24.Checked = False
            chkMarketS25.Checked = False
            chkMarketS26.Checked = False
            chkMarketS27.Checked = False
            chkMarketS28.Checked = False
            chkMarketS29.Checked = False
        End If

    End Sub

    Private Sub chkAOD_CheckedChanged(sender As System.Object, e As System.EventArgs) Handles chkAOD.CheckedChanged
        If chkAOD.Checked = True Then
            dtpAccOpenDateFrom.Enabled = True
            dtpAccOpenDateTo.Enabled = True
            dtpAccOpenDateFrom.CustomFormat = "yyyy/MM/dd"
            dtpAccOpenDateFrom.Format = DateTimePickerFormat.Custom
            dtpAccOpenDateFrom.Text = Format(Date.Now, "yyyy/MM/dd")
            dtpAccOpenDateTo.CustomFormat = "yyyy/MM/dd"
            dtpAccOpenDateTo.Format = DateTimePickerFormat.Custom
            dtpAccOpenDateTo.Text = Format(Date.Now, "yyyy/MM/dd")

        Else
            dtpAccOpenDateFrom.Enabled = False
            dtpAccOpenDateTo.Enabled = False
            dtpAccOpenDateFrom.CustomFormat = " "
            dtpAccOpenDateFrom.Format = DateTimePickerFormat.Custom
            dtpAccOpenDateTo.CustomFormat = " "
            dtpAccOpenDateTo.Format = DateTimePickerFormat.Custom

        End If
    End Sub
    Private Sub btnReset_Click(sender As System.Object, e As System.EventArgs) Handles btnReset.Click
        txtAccNoFrom.Text = ""
        txtAccNoTo.Text = ""
        cboAENoFrom.SelectedIndex = -1
        cboAENoTo.SelectedIndex = -1
        chkAOD.Checked = False
        dtpAccOpenDateFrom.CustomFormat = " "
        dtpAccOpenDateFrom.Format = DateTimePickerFormat.Custom
        dtpAccOpenDateTo.CustomFormat = " "
        dtpAccOpenDateTo.Format = DateTimePickerFormat.Custom
        rbECM01.Checked = True
        rbECM11.Checked = True
        'rbECM21.Checked = True
        rbECM31.Checked = True
        chkAllFields.Checked = False

        chkAccountInfo10.Checked = False
        chkAccountInfo11.Checked = False
        chkAccountInfo12.Checked = False
        chkAccountInfo13.Checked = False
        chkAccountInfo14.Checked = False
        chkAccountInfo15.Checked = False
        chkAccountInfo16.Checked = False
        chkAccountInfo17.Checked = False
        chkAccountInfo18.Checked = False

        chkAccountStatus10.Checked = False
        chkAccountStatus11.Checked = False
        chkAccountStatus12.Checked = False
        chkAccountStatus13.Checked = False
        chkAccountStatus14.Checked = False
        chkAccountStatus15.Checked = False
        chkAccountStatus16.Checked = False
        chkAccountStatus17.Checked = False
        chkAccountStatus18.Checked = False

        chkAccountStatus10.Checked = False
        chkAccountStatus11.Checked = False
        chkAccountStatus12.Checked = False
        chkAccountStatus13.Checked = False
        chkAccountStatus14.Checked = False
        chkAccountStatus15.Checked = False
        chkAccountStatus16.Checked = False
        chkAccountStatus17.Checked = False
        chkAccountStatus18.Checked = False

        chkClientInfo10.Checked = False
        chkClientInfo11.Checked = False
        chkClientInfo12.Checked = False
        chkClientInfo13.Checked = False
        chkClientInfo14.Checked = False

        chkContactDetails10.Checked = False
        chkContactDetails11.Checked = False
        chkContactDetails12.Checked = False
        chkContactDetails13.Checked = False
        chkContactDetails14.Checked = False
        chkContactDetails15.Checked = False

        chkAddressInfo10.Checked = False
        chkAddressInfo11.Checked = False
        chkAddressInfo12.Checked = False
        chkAddressInfo13.Checked = False

        chkRiskControl10.Checked = False
        chkRiskControl11.Checked = False
        chkRiskControl12.Checked = False
        chkRiskControl13.Checked = False

        chkStaffDealing10.Checked = False
        chkStaffDealing11.Checked = False
        chkStaffDealing12.Checked = False
        chkStaffDealing13.Checked = False
        chkStaffDealing14.Checked = False

        chkOthers10.Checked = False
        chkOthers11.Checked = False
        chkOthers12.Checked = False
        chkOthers13.Checked = False

        chkMarket10.Checked = False
        chkMarket11.Checked = False
        chkMarket12.Checked = False
        chkMarket13.Checked = False
        chkMarket15.Checked = False
        chkMarket16.Checked = False
        chkMarket17.Checked = False
        chkMarket18.Checked = False
        chkMarket19.Checked = False
        chkMarket20.Checked = False
        chkMarket21.Checked = False

        chkMarketS10.Checked = False
        chkMarketS11.Checked = False
        chkMarketS13.Checked = False
        chkMarketS14.Checked = False
        chkMarketS15.Checked = False
        chkMarketS16.Checked = False
        chkMarketS18.Checked = False
        chkMarketS19.Checked = False
        chkMarketS20.Checked = False
        chkMarketS21.Checked = False
        chkMarketS22.Checked = False
        chkMarketS23.Checked = False
        chkMarketS24.Checked = False
        chkMarketS25.Checked = False
        chkMarketS26.Checked = False
        chkMarketS27.Checked = False
        chkMarketS28.Checked = False
        chkMarketS29.Checked = False
    End Sub
    Public Sub SetClientMasterCustomColumnLibrary(arrClientMasterCustomColumnLibrary As ArrayList, sViewAbbrev1 As String, sViewAbbrev2 As String)
        Dim objClientMasterCustomColumnLibrary As ClientMasterCustomColumnLibrary
        'objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        'objClientMasterCustomColumnLibrary.setColumn("accno")
        'objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        'objClientMasterCustomColumnLibrary.setSpecialField("")
        'arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        'objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        'objClientMasterCustomColumnLibrary.setColumn("name_1")
        'objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        'objClientMasterCustomColumnLibrary.setSpecialField("")
        'arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        'objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        'objClientMasterCustomColumnLibrary.setColumn("name_1_c")
        'objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        'objClientMasterCustomColumnLibrary.setSpecialField("")
        'arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        'objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        'objClientMasterCustomColumnLibrary.setColumn("client_type")
        'objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        'objClientMasterCustomColumnLibrary.setSpecialField("")
        'arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("aeno")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("ae_name")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("branch_name")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("bank_code_1")
        'objClientMasterCustomColumnLibrary.setSpecialField("dbo.f_GetBankcodeByAccNo(" & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".client_type) AS bank_code_1")
        objClientMasterCustomColumnLibrary.setSpecialField("")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("type")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("ClientBranch")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("external_accno")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("Nature_s")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("date_open")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("date_renew")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("Last_Tran_Date")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("suspend_field")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("suspend_code")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("sus_date")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("date_close")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("nationality_1")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("br_id")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("gender_s")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("dob")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("phone_1")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("phone_2")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("phone_3")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("fax")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("email")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("corr_addr_1")
        objClientMasterCustomColumnLibrary.setSpecialField("LTRIM(RTRIM(addr_1)) AS corr_addr_1, LTRIM(RTRIM(addr_2)) AS corr_addr_2, LTRIM(RTRIM(addr_3)) AS corr_addr_3, LTRIM(RTRIM(addr_4)) AS corr_addr_4")
        objClientMasterCustomColumnLibrary.setView("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("resid_addr_1")
        objClientMasterCustomColumnLibrary.setSpecialField("LTRIM(RTRIM(nd_addr_1)) AS resid_addr_1, LTRIM(RTRIM(nd_addr_2)) AS resid_addr_2, LTRIM(RTRIM(nd_addr_3)) AS resid_addr_3, LTRIM(RTRIM(nd_addr_4)) AS resid_addr_4")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("mail_status")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("int_code")
        objClientMasterCustomColumnLibrary.setView("dbo.f_GetIntCodeByAccNo(" & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".client_type) AS int_code")
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("int_1")
        objClientMasterCustomColumnLibrary.setView("dbo.f_GetInt1ByAccNo(" & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".client_type) AS int_1")
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("int_2")
        objClientMasterCustomColumnLibrary.setView("dbo.f_GetInt2ByAccNo(" & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".client_type) AS int_2")
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("int_3")
        objClientMasterCustomColumnLibrary.setView("dbo.f_GetInt3ByAccNo(" & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".client_type) AS int_3")
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("pstat")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("brokerage_p")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("brokerage_i")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("rebate_p")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("rebate_i")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("net_trade_lmt")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("credit_lmt")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("external_credit_lmt")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("category")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("relationship")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("relationstaff")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("relationae")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("notes")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("memo")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("FeeClass")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev1)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        'Market Futures
        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("CBT")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("CJCE")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("CME")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("CMX")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("HKEX")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("LME")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("NYM")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("NYB")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("TGE")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("TOCOM")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        'Market Securities
        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("SEHK")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("SZEN")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("TF")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("CBUS")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("CBHK")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("SG")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("SSE")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("BDHK")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("FUND")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("US")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("BDCN")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)

        objClientMasterCustomColumnLibrary = New ClientMasterCustomColumnLibrary()
        objClientMasterCustomColumnLibrary.setColumn("MAMK")
        objClientMasterCustomColumnLibrary.setView(sViewAbbrev2)
        objClientMasterCustomColumnLibrary.setSpecialField("")
        arrClientMasterCustomColumnLibrary.Add(objClientMasterCustomColumnLibrary)
    End Sub

End Class
Public Class ClientMasterCustomColumnLibrary
    Private sView As String
    Private sColumn As String
    Private sSpecialField As String

    Public Sub ClientMasterCustomColumnLibrary()
        sView = ""
        sColumn = ""
        sSpecialField = ""
    End Sub

    Public Sub setView(ByVal pView As String)
        sView = pView
    End Sub
    Public Sub setColumn(ByVal pColumn As String)
        sColumn = pColumn
    End Sub
    Public Sub setSpecialField(ByVal pSpecialField As String)
        sSpecialField = pSpecialField
    End Sub
    Public Function getColumn()
        Return sColumn
    End Function
    Public Function getSpecialField()
        Return sSpecialField
    End Function
    Public Function getViewColumn() As String
        Return sView & "." & sColumn
    End Function
End Class




