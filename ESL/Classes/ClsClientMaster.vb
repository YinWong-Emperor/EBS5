Public Class ClsClientMaster

    Protected Friend Function lFncGetAECode() As DataSet

        Dim lstrSQL As String

        lstrSQL = "SELECT DISTINCT stcltmaster.run_code as aeno FROM stcltmaster ORDER BY stcltmaster.run_code "
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "clt")

    End Function

    Protected Friend Function lFncGetSuspendCode() As DataSet

        Dim lstrSQL As String

        lstrSQL = "select misc_desc from misc_master where misc_type = 'ExportClientEmail'"

        Return GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

    End Function
    Protected Friend Function lFncExportClientMasterS(ByVal strExFile As String, ByVal clientFrom As String, ByVal clientTo As String, _
                                                         ByVal aeFrom As String, ByVal aeTo As String) As Boolean

        Dim ldtsData As DataSet
        Dim strSQL As String = ""
        Dim strTitle As String = ""

        strTitle = " accno, nature_s, gender_s, name_1, name_1_c, aeno, br_id, phone_1, phone_2, phone_3, fax, " & _
                    "email, addr_1, addr_2, addr_3, addr_4, bank_code_1, client_type, date_open, date_renew, date_close, credit_lmt, " & _
                    "net_trade_lmt, pstat, suspend_field, suspend_code, date_suspend, mail_status, category, relationship, " & _
                    "relationstaff, relationae, int_code, int_1, int_2, int_3, brokerage_income,  brokerage_itrade, ae_rebate, ae_rebate_itrade, " & _
                    " nd_contact_name, nd_addr_1, nd_addr_2, nd_addr_3, nd_addr_4,external_account_no, external_credit_limit, Last_Tran_Date  "

        strSQL = "SELECT accno, nature_s, gender_s, name_1, name_1_c, aeno, br_id, phone_1, phone_2, phone_3, fax, " & _
                    "email, addr_1, addr_2, addr_3, addr_4, bank_code_1, client_type, date_open, date_renew, date_close, credit_lmt, " & _
                    "net_trade_lmt, pstat, suspend_field, suspend_code, date_suspend, mail_status, category, relationship, " & _
                    "relationstaff, relationae, int_code, int_1, int_2, int_3, brokerage_p, brokerage_i, rebate_p, rebate_i, " & _
                    " nd_contact_name, nd_addr_1, nd_addr_2, nd_addr_3, nd_addr_4, external_accno, external_credit_lmt, Last_Tran_Date " & _
                    " FROM " & GStrG2BSDB & _
                    ".dbo.view_it_client_all WHERE 1=1 "

        If (clientFrom.Trim.Length > 0) Then
            strSQL = strSQL & " and accno >=  '" & clientFrom.Trim & "'"
        End If
        If (clientTo.Trim.Length > 0) Then
            strSQL = strSQL & " and accno <=  '" & clientTo.Trim & "'"
        End If

        If (aeFrom.Trim.Length > 0) Then
            strSQL = strSQL & " and aeno >=  '" & aeFrom.Trim & "'"
        End If
        If (aeTo.Trim.Length > 0) Then
            strSQL = strSQL & " and aeno <=  '" & aeTo.Trim & "'"
        End If

        strSQL = strSQL & " order by accno "

        ldtsData = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        Return GExportCSV(GStrExptDir, strExFile, ldtsData, strTitle)

    End Function

    Protected Friend Function lFncExportClientMasterFmail(ByVal strExFile As String, _
    ByVal clientFrom As String, ByVal clientTo As String, _
    ByVal aeFrom As String, ByVal aeTo As String, _
    ByVal strFromDate As String, ByVal strToDate As String, _
    ByVal strCloseFromDate As String, ByVal strCloseToDate As String, ByVal boolActiveClient As Boolean) As Boolean

        Dim ldtsData As DataSet
        Dim strSQL As String = ""
        Dim strTitle As String = ""

        strTitle = " accno, email, open_date, close_date "

        strSQL = "SELECT accno, email, date_open, date_close " & _
                    "FROM " & GStrG2BFDB & ".dbo.view_it_client_all WHERE rtrim(email) <> '' "

        'strSQL = "SELECT accno, email, date_open " & _
        '            "FROM " & GStrG2BFDB & ".dbo.view_it_client_all WHERE upper(suspend_field) <> 'YES' " & _
        '            " and rtrim(suspend_code) = '' " & _
        '            " and date_close is null " & _
        '            " and rtrim(email) <> '' "
        If (clientFrom.Trim.Length > 0) Then
            strSQL = strSQL & " and accno >=  '" & clientFrom.Trim & "'"
        End If
        If (clientTo.Trim.Length > 0) Then
            strSQL = strSQL & " and accno <=  '" & clientTo.Trim & "'"
        End If

        If (aeFrom.Trim.Length > 0) Then
            strSQL = strSQL & " and aeno >=  '" & aeFrom.Trim & "'"
        End If
        If (aeTo.Trim.Length > 0) Then
            strSQL = strSQL & " and aeno <=  '" & aeTo.Trim & "'"
        End If
        If (strFromDate.Trim.Length > 0) Then
            strSQL = strSQL & " and date_open >=  '" & strFromDate.Trim & "'"
        End If
        If (strToDate.Trim.Length > 0) Then
            strSQL = strSQL & " and  date_open <=  '" & strToDate.Trim & "'"
        End If
        If (strCloseFromDate.Trim.Length > 0) Then
            strSQL = strSQL & " and date_close >=  '" & strCloseFromDate.Trim & "'"
        End If
        If (strCloseToDate.Trim.Length > 0) Then
            strSQL = strSQL & " and  date_close <=  '" & strCloseToDate.Trim & "'"
        End If
        If (strCloseFromDate.Trim.Length > 0) Or (strCloseToDate.Trim.Length > 0) Then
            strSQL = strSQL & " and rtrim(suspend_code) COLLATE Chinese_Taiwan_Bopomofo_CI_AS in (select misc_desc from misc_master where misc_type = 'ExportClientEmail')"
        End If
        If (boolActiveClient) Then
            strSQL = strSQL & " and upper(suspend_field) <> 'YES' " & _
                      " and rtrim(suspend_code) = '' " & _
                    " and date_close is null "
        End If
        strSQL = strSQL & " order by accno "

        ldtsData = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        Return GExportCSV(GStrExptDir, strExFile, ldtsData, strTitle)

    End Function

    Protected Friend Function lFncExportClientMasterSMail(ByVal strExFile As String, ByVal clientFrom As String, ByVal clientTo As String, _
                                                      ByVal aeFrom As String, ByVal aeTo As String, _
                                                      ByVal strFromDate As String, ByVal strToDate As String, _
                                                      ByVal strCloseFromDate As String, ByVal strCloseToDate As String, ByVal boolActiveClient As Boolean) As Boolean

        Dim ldtsData As DataSet
        Dim strSQL As String = ""
        Dim strTitle As String = ""
        
        strTitle = " accno, email, open_date, close_date"

        'strSQL = "SELECT accno, email, date_open " & _
        '            " FROM " & GStrG2BSDB & _
        '            ".dbo.view_it_client_all WHERE upper(suspend_field) <> 'YES' " & _
        '              " and rtrim(suspend_code) = '' " & _
        '            " and date_close is null " & _
        '            " and rtrim(email) <> '' "

        strSQL = "SELECT accno, email, date_open, date_close" & _
                    " FROM " & GStrG2BSDB & _
                    ".dbo.view_it_client_all WHERE rtrim(email) <> '' "

        If (clientFrom.Trim.Length > 0) Then
            strSQL = strSQL & " and accno >=  '" & clientFrom.Trim & "'"
        End If
        If (clientTo.Trim.Length > 0) Then
            strSQL = strSQL & " and accno <=  '" & clientTo.Trim & "'"
        End If

        If (aeFrom.Trim.Length > 0) Then
            strSQL = strSQL & " and aeno >=  '" & aeFrom.Trim & "'"
        End If
        If (aeTo.Trim.Length > 0) Then
            strSQL = strSQL & " and aeno <=  '" & aeTo.Trim & "'"
        End If
        If (strFromDate.Trim.Length > 0) Then
            strSQL = strSQL & " and date_open >=  '" & strFromDate.Trim & "'"
        End If
        If (strToDate.Trim.Length > 0) Then
            strSQL = strSQL & " and  date_open <=  '" & strToDate.Trim & "'"
        End If
        If (strCloseFromDate.Trim.Length > 0) Then
            strSQL = strSQL & " and date_close >=  '" & strCloseFromDate.Trim & "'"
        End If
        If (strCloseToDate.Trim.Length > 0) Then
            strSQL = strSQL & " and  date_close <=  '" & strCloseToDate.Trim & "'"
        End If
        If (strCloseFromDate.Trim.Length > 0) Or (strCloseToDate.Trim.Length > 0) Then

            strSQL = strSQL & " and rtrim(suspend_code) COLLATE Chinese_Taiwan_Bopomofo_CI_AS in (select misc_desc from misc_master where misc_type = 'ExportClientEmail')"
        End If
        If (boolActiveClient) Then
            strSQL = strSQL & " and upper(suspend_field) <> 'YES' " & _
                      " and rtrim(suspend_code) = '' " & _
                    " and date_close is null "
        End If
        strSQL = strSQL & " order by accno "

        ldtsData = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        Return GExportCSV(GStrExptDir, strExFile, ldtsData, strTitle)

    End Function

    Protected Friend Function lFncExportClientMasterF(ByVal strExFile As String, ByVal clientFrom As String, ByVal clientTo As String, _
                                                      ByVal aeFrom As String, ByVal aeTo As String) As Boolean

        Dim ldtsData As DataSet
        Dim strSQL As String = ""
        Dim strTitle As String = ""

        strTitle = " accno, nature_s, gender_s, name_1, name_1_c, aeno, br_id, phone_1, phone_2, phone_3, fax, " & _
                    "email, addr_1, addr_2, addr_3, addr_4, bank_code_1, date_open, credit_lmt, pstat, suspend_field, " & _
                    "suspend_code, date_close, mail_status, category, relationship, relationstaff, relationae, int_code, " & _
                    "nd_addr_1, nd_addr_2, nd_addr_3, nd_addr_4, Last_Tran_Date, CBT, CJCE, CME, CMX, HKEX, LME, NYB, NYM, TGE, TOCOM "

        strSQL = "SELECT accno, nature_s, gender_s, name_1, name_1_c, aeno, br_id, phone_1, phone_2, phone_3, fax, " & _
                    "email, addr_1, addr_2, addr_3, addr_4, bank_code_1, date_open, credit_lmt, pstat, suspend_field, " & _
                    "suspend_code, date_close, mail_status, category, relationship, relationstaff, relationae, int_code, " & _
                    "nd_addr_1, nd_addr_2, nd_addr_3, nd_addr_4, Last_Tran_Date, CBT, CJCE, CME, CMX, HKEX, LME, NYB, NYM, TGE, TOCOM " & _
                    "FROM " & GStrG2BFDB & ".dbo.view_it_client_all WHERE 1=1 "

        If (clientFrom.Trim.Length > 0) Then
            strSQL = strSQL & " and accno >=  '" & clientFrom.Trim & "'"
        End If
        If (clientTo.Trim.Length > 0) Then
            strSQL = strSQL & " and accno <=  '" & clientTo.Trim & "'"
        End If

        If (aeFrom.Trim.Length > 0) Then
            strSQL = strSQL & " and aeno >=  '" & aeFrom.Trim & "'"
        End If
        If (aeTo.Trim.Length > 0) Then
            strSQL = strSQL & " and aeno <=  '" & aeTo.Trim & "'"
        End If

        strSQL = strSQL & " order by accno "

        ldtsData = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        Return GExportCSV(GStrExptDir, strExFile, ldtsData, strTitle)

    End Function

End Class
