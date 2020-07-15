Public Class ClsClientMasterCustom
    Protected Friend Function lFncGetAECode() As DataSet

        Dim lstrSQL As String

        lstrSQL = "SELECT DISTINCT stcltmaster.run_code as aeno FROM stcltmaster ORDER BY stcltmaster.run_code "
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "clt")

    End Function
    Protected Friend Function lFncExportClientMasterS(ByVal strExFile As String, ByVal clientFrom As String, ByVal clientTo As String, _
                                                         ByVal aeFrom As String, ByVal aeTo As String, AccOpenDateFrom As String, AccOpenDateTo As String, sAT As String, sAN As String, sAS As String, sCT As String, sTitleToBeIncludedOutput As String, sFieldsToBeIncludedOutput As String, sViewAbbrev1 As String, sViewAbbrev2 As String) As Boolean

        Dim ldtsData As DataSet
        Dim strSQL As String = ""
        Dim strSQLv1 As String = ""
        Dim strSQLv2 As String = ""
        Dim strSubSQLsclm As String = ""
        Dim strSubSQLfclm As String = ""
        Dim strSubSQLsclms As String = ""
        Dim strSubSQLfclms As String = ""
        Dim strSubSQLsrelae As String = ""
        Dim strSubSQLfrelae As String = ""
        Dim strTitle As String = ""


        strTitle = "ccd_ref, accno, name_1, name_1_c, account_type, " & sTitleToBeIncludedOutput


        If sFieldsToBeIncludedOutput.Length <> 0 Then
            sFieldsToBeIncludedOutput = sViewAbbrev2 & ".ccd_ref, " & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".name_1, " & sViewAbbrev1 & ".name_1_c, " & sViewAbbrev1 & ".client_type, " & sFieldsToBeIncludedOutput
        Else
            sFieldsToBeIncludedOutput = sViewAbbrev2 & ".ccd_ref, " & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".name_1, " & sViewAbbrev1 & ".name_1_c, " & sViewAbbrev1 & ".client_type"
        End If

        If (clientFrom.Trim.Length > 0) Then
            strSubSQLsclm = strSubSQLsclm & " and clm.accno >=  '" & clientFrom.Trim & "'"
            strSubSQLfclm = strSubSQLfclm & " and clm.accno >=  '" & clientFrom.Trim & "'"
        End If
        If (clientTo.Trim.Length > 0) Then
            strSubSQLsclm = strSubSQLsclm & " and clm.accno <=  '" & clientTo.Trim & "'"
            strSubSQLfclm = strSubSQLfclm & " and clm.accno <=  '" & clientTo.Trim & "'"
        End If

        If (aeFrom.Trim.Length > 0) Then
            strSubSQLsrelae = strSubSQLsrelae & " and relae.aeno >=  '" & aeFrom.Trim & "'"
            strSubSQLfrelae = strSubSQLfrelae & " and relae.aeno >=  '" & aeFrom.Trim & "'"
        End If
        If (aeTo.Trim.Length > 0) Then
            strSubSQLsrelae = strSubSQLsrelae & " and relae.aeno <=  '" & aeTo.Trim & "'"
            strSubSQLfrelae = strSubSQLfrelae & " and relae.aeno <=  '" & aeTo.Trim & "'"
        End If

        If (AccOpenDateFrom.ToString.Trim.Length > 0) Then
            strSubSQLsclms = strSubSQLsclms & " and clms.date_open >=  '" & AccOpenDateFrom.ToString.Trim & "'"
            strSubSQLfclms = strSubSQLfclms & " and clms.date_open >=  '" & AccOpenDateFrom.ToString.Trim & "'"
        End If
        If (AccOpenDateTo.ToString.Trim.Length > 0) Then
            strSubSQLsclms = strSubSQLsclms & " and clms.date_open <=  '" & AccOpenDateTo.ToString.Trim & "'"
            strSubSQLfclms = strSubSQLfclms & " and clms.date_open <=  '" & AccOpenDateTo.ToString.Trim & "'"
        End If

        If sAT.Trim <> "" And sAT.Trim <> "ALL" Then
            strSubSQLsclm += " and CASE WHEN SUBSTRING(clm.accno,1,3) ='500' THEN 'CIES' ELSE 'Securities'/*v.client_type*/ END = '" & sAT.Trim & "' "
            strSubSQLfclm += " and CASE WHEN SUBSTRING(clm.accno,1,3) ='500' THEN 'CIES' ELSE 'Futures'/*v.client_type*/ END  = '" & sAT.Trim & "' "
        End If

        If sAN.Trim <> "" And sAN.Trim <> "ALL" Then
            strSubSQLsclm += " and CASE clm.nature WHEN '0' THEN 'Individual' WHEN '1' THEN 'Joint' ELSE 'Corporation' END = '" & sAN.Trim & "' "
            strSubSQLfclm += " and CASE clm.nature WHEN '0' THEN 'Individual' WHEN '1' THEN 'Joint' ELSE 'Corporation' END = '" & sAN.Trim & "' "
        End If

        If sCT.Trim <> "" And sCT.Trim <> "ALL" Then
            strSubSQLsclms += " and clms.type='" & sCT.Trim & "' "
            If sCT.Trim = "1" Then 'Margin
                strSubSQLfclms += " and clm.accno LIKE('000%') "
            Else  ' not Margin
                strSubSQLfclms += " and clm.accno NOT LIKE('000%') "
            End If

        End If


        If (clientFrom.Trim.Length > 0) Then
            strSQLv1 = strSQLv1 & " and " & sViewAbbrev1 & ".accno >= '" & clientFrom.Trim & "'"
            strSQLv2 = strSQLv2 & " and " & sViewAbbrev2 & ".accno >= '" & clientFrom.Trim & "'"
        End If
        If (clientTo.Trim.Length > 0) Then
            strSQLv1 = strSQLv1 & " and " & sViewAbbrev1 & ".accno <= '" & clientTo.Trim & "'"
            strSQLv2 = strSQLv2 & " and " & sViewAbbrev2 & ".accno <= '" & clientTo.Trim & "'"
        End If

        If (aeFrom.Trim.Length > 0) Then
            strSQLv1 = strSQLv1 & " and " & sViewAbbrev1 & ".aeno >= '" & aeFrom.Trim & "'"
            strSQLv2 = strSQLv2 & " and " & sViewAbbrev2 & ".aeno >= '" & aeFrom.Trim & "'"
        End If
        If (aeTo.Trim.Length > 0) Then
            strSQLv1 = strSQLv1 & " and " & sViewAbbrev1 & ".aeno <= '" & aeTo.Trim & "'"
            strSQLv2 = strSQLv2 & " and " & sViewAbbrev2 & ".aeno <= '" & aeTo.Trim & "'"
        End If

        If (AccOpenDateFrom.ToString.Trim.Length > 0) Then
            strSQLv1 = strSQLv1 & " and " & sViewAbbrev1 & ".date_open >= '" & AccOpenDateFrom.ToString.Trim & "'"
            strSQLv2 = strSQLv2 & " and " & sViewAbbrev2 & ".date_open >= '" & AccOpenDateFrom.ToString.Trim & "'"
        End If
        If (AccOpenDateTo.ToString.Trim.Length > 0) Then
            strSQLv1 = strSQLv1 & " and " & sViewAbbrev1 & ".date_open <= '" & AccOpenDateTo.ToString.Trim & "'"
            strSQLv2 = strSQLv2 & " and " & sViewAbbrev2 & ".date_open <= '" & AccOpenDateTo.ToString.Trim & "'"
        End If

        If sAT.Trim <> "" And sAT.Trim <> "ALL" Then
            strSQLv2 += " and " & sViewAbbrev2 & ".client_type = '" & sAT.Trim & "'"
        End If

        If sAN.Trim <> "" And sAN.Trim <> "ALL" Then
            strSQLv1 += " and " & sViewAbbrev1 & ".nature_s = '" & sAN.Trim & "'"
            strSQLv2 += " and " & sViewAbbrev2 & ".nature_s = '" & sAN.Trim & "'"
        End If

        'strSQL = "DBCC TRACEON(8765)  " & "SELECT DISTINCT " & sFieldsToBeIncludedOutput & _
        strSQL = "SELECT DISTINCT " & sFieldsToBeIncludedOutput & _
                    " FROM " & _
                    "( " & _
                        "SELECT " & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".nature_s, " & sViewAbbrev1 & ".gender_s, " & sViewAbbrev1 & ".name_1, " & sViewAbbrev1 & ".name_1_c, " & sViewAbbrev1 & ".aeno, " & sViewAbbrev1 & ".br_id, " & sViewAbbrev1 & ".phone_1, " & sViewAbbrev1 & ".phone_2, " & sViewAbbrev1 & ".phone_3, " & sViewAbbrev1 & ".fax, " & sViewAbbrev1 & ".email, " & sViewAbbrev1 & ".addr_1, " & sViewAbbrev1 & ".addr_2, " & sViewAbbrev1 & ".addr_3, " & sViewAbbrev1 & ".addr_4, " & sViewAbbrev1 & ".bank_code_1, " & sViewAbbrev1 & ".date_open,  " & sViewAbbrev1 & ".pstat, " & sViewAbbrev1 & ".suspend_field, " & sViewAbbrev1 & ".suspend_code, " & sViewAbbrev1 & ".date_close, " & sViewAbbrev1 & ".mail_status, " & sViewAbbrev1 & ".category, " & sViewAbbrev1 & ".relationship, " & sViewAbbrev1 & ".relationstaff, " & sViewAbbrev1 & ".relationae,  " & sViewAbbrev1 & ".nd_addr_1, " & sViewAbbrev1 & ".nd_addr_2, " & sViewAbbrev1 & ".nd_addr_3, " & sViewAbbrev1 & ".nd_addr_4, " & sViewAbbrev1 & ".Last_Tran_Date, " & sViewAbbrev1 & ".ae_name, " & sViewAbbrev1 & ".ae_email, " & sViewAbbrev1 & ".branch_name, " & sViewAbbrev1 & ".client_type, " & sViewAbbrev1 & ".ClientBranch, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".notes, ISNULL(" & sViewAbbrev1 & ".net_trade_lmt,0) AS net_trade_lmt, ISNULL(" & sViewAbbrev1 & ".credit_lmt, 0) AS credit_lmt, " & sViewAbbrev1 & ".type, " & sViewAbbrev1 & ".FeeClass FROM" & _
                        "( " & _
                            "SELECT DISTINCT " & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".nature_s, " & sViewAbbrev1 & ".gender_s, " & sViewAbbrev1 & ".name_1, " & sViewAbbrev1 & ".name_1_c, " & sViewAbbrev1 & ".aeno, " & sViewAbbrev1 & ".br_id, " & sViewAbbrev1 & ".phone_1, " & sViewAbbrev1 & ".phone_2, " & sViewAbbrev1 & ".phone_3, " & sViewAbbrev1 & ".fax, " & sViewAbbrev1 & ".email, " & sViewAbbrev1 & ".addr_1, " & sViewAbbrev1 & ".addr_2, " & sViewAbbrev1 & ".addr_3, " & sViewAbbrev1 & ".addr_4, bal.bank_code_1, " & sViewAbbrev1 & ".date_open,  " & sViewAbbrev1 & ".pstat, " & sViewAbbrev1 & ".suspend_field, " & sViewAbbrev1 & ".suspend_code, " & sViewAbbrev1 & ".date_close, " & sViewAbbrev1 & ".mail_status, " & sViewAbbrev1 & ".category, " & sViewAbbrev1 & ".relationship, " & sViewAbbrev1 & ".relationstaff, " & sViewAbbrev1 & ".relationae,  " & sViewAbbrev1 & ".nd_addr_1, " & sViewAbbrev1 & ".nd_addr_2, " & sViewAbbrev1 & ".nd_addr_3, " & sViewAbbrev1 & ".nd_addr_4, " & sViewAbbrev1 & ".Last_Tran_Date, " & sViewAbbrev1 & ".ae_name, " & sViewAbbrev1 & ".ae_email, " & sViewAbbrev1 & ".branch_name, " & sViewAbbrev1 & ".client_type, clb.ClientBranch, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".notes, ISNULL(mc.net_trade_lmt,0) AS net_trade_lmt, ISNULL(bal.credit_lmt, 0) AS credit_lmt, CASE clms.type WHEN '2' THEN 'Cash' WHEN '1' THEN 'Margin' END AS type, fcs.FeeClass " & _
                            "FROM vw_client_master " & sViewAbbrev1 & " " & _
                            "INNER JOIN " & _
                            "( " & _
                            "SELECT clms.aid, clms.type FROM  " & GStrG2BSDB & ".dbo.client_master_s clms WHERE 1=1 " & strSubSQLsclms & " " & _
                            ") clms ON clms.aid=" & sViewAbbrev1 & ".aid " & _
                            "LEFT OUTER JOIN " & _
                            "( " & _
                            "SELECT aid, mkid, net_trade_lmt FROM " & GStrG2BSDB & ".dbo.market_client WHERE mkid='1001' " & _
                            ") mc ON mc.aid=" & sViewAbbrev1 & ".aid " & _
                            "LEFT OUTER JOIN " & GStrG2BSDB & ".dbo.market_master mm ON mm.mkid=mc.mkid " & _
                            "LEFT OUTER JOIN " & _
                            "( " & _
                             "SELECT aid, cuid, bank_code_1, credit_lmt FROM " & GStrG2BSDB & ".dbo.client_bal WHERE cuid=1 " & _
                            ") bal ON bal.aid=" & sViewAbbrev1 & ".aid " & _
                            "LEFT OUTER JOIN " & _
                            "( " & _
                            "SELECT cuid, name_s FROM " & GStrG2BSDB & ".dbo.currency_master WHERE cuid=1 " & _
                            ") cm ON cm.cuid=bal.cuid " & _
                            "INNER JOIN " & _
                            "( " & _
                                "SELECT " & _
                                    "cms.aid," & _
                                    "bm.name as ClientBranch " & _
                                "FROM " & _
                                "( " & _
                                    "SELECT " & _
                                        "aid, " & _
                                        "aeid, " & _
                                        "bhid " & _
                                    "FROM " & _
                                        GStrG2BSDB & ".dbo.client_master_s clms " & _
                                    "WHERE 1=1 " & strSubSQLsclms & _
                                ") cms " & _
                                "INNER JOIN " & _
                                "( " & _
                                    "SELECT " & _
                                        "bhid, " & _
                                        "name " & _
                                    "FROM " & _
                                         GStrG2BSDB & ".dbo.branch_master " & _
                                ") bm " & _
                                "ON " & _
                                    "bm.bhid = cms.bhid " & _
                            " ) clb ON clb.aid =" & sViewAbbrev1 & ".aid " & _
                            "INNER JOIN " & _
                            "( " & _
                                "SELECT " & _
                                    "cmf.aid, " & _
                                    "'' AS FeeClass " & _
                                "FROM " & _
                                "( " & _
                                    "SELECT " & _
                                        "aid " & _
                                    "FROM " & _
                                        GStrG2BSDB & ".dbo.client_master_s clms WHERE 1=1 " & strSubSQLsclms & _
                                ") cmf " & _
                            ") fcs " & _
                            "ON " & _
                                "fcs.aid = " & sViewAbbrev1 & ".aid " & _
                            "WHERE " & sViewAbbrev1 & ".client_type='Securities' OR " & sViewAbbrev1 & ".client_type='CIES' " & _
                            "UNION " & _
                            "SELECT DISTINCT " & sViewAbbrev1 & ".accno, " & sViewAbbrev1 & ".nature_s, " & sViewAbbrev1 & ".gender_s, " & sViewAbbrev1 & ".name_1, " & sViewAbbrev1 & ".name_1_c, RTRIM(" & sViewAbbrev1 & ".aeno) AS aeno, " & sViewAbbrev1 & ".br_id, " & sViewAbbrev1 & ".phone_1, " & sViewAbbrev1 & ".phone_2, " & sViewAbbrev1 & ".phone_3, " & sViewAbbrev1 & ".fax, " & sViewAbbrev1 & ".email, " & sViewAbbrev1 & ".addr_1, " & sViewAbbrev1 & ".addr_2, " & sViewAbbrev1 & ".addr_3, " & sViewAbbrev1 & ".addr_4, bal.bank_code_1, " & sViewAbbrev1 & ".date_open,  " & sViewAbbrev1 & ".pstat, " & sViewAbbrev1 & ".suspend_field, " & sViewAbbrev1 & ".suspend_code, " & sViewAbbrev1 & ".date_close, " & sViewAbbrev1 & ".mail_status, " & sViewAbbrev1 & ".category, " & sViewAbbrev1 & ".relationship, " & sViewAbbrev1 & ".relationstaff, " & sViewAbbrev1 & ".relationae,  " & sViewAbbrev1 & ".nd_addr_1, " & sViewAbbrev1 & ".nd_addr_2, " & sViewAbbrev1 & ".nd_addr_3, " & sViewAbbrev1 & ".nd_addr_4, " & sViewAbbrev1 & ".Last_Tran_Date, " & sViewAbbrev1 & ".ae_name, " & sViewAbbrev1 & ".ae_email, " & sViewAbbrev1 & ".branch_name, " & sViewAbbrev1 & ".client_type, clms.ClientBranch, " & sViewAbbrev1 & ".aid, " & sViewAbbrev1 & ".notes, ISNULL(mc.net_trade_lmt,0) AS net_trade_lmt, ISNULL(bal.credit_lmt, 0) AS credit_lmt, CASE WHEN SUBSTRING(" & sViewAbbrev1 & ".accno, 1,3) = '000' THEN 'Margin' ELSE 'Cash' END AS type, clms.FeeClass " & _
                            "FROM vw_client_master " & sViewAbbrev1 & " " & _
                            "INNER JOIN " & _
                            "( " & _
                                "SELECT clms.aid, clms.type, clms.aeid, clms.bhid, clms.fcid,bm.name as ClientBranch, fc.FeeClass FROM  " & GStrG2BFDB & ".dbo.client_master clm " & _
                                "INNER JOIN " & GStrG2BFDB & ".dbo.client_master_f clms " & _
                                "INNER JOIN " & _
                                "( " & _
                                    "SELECT bhid, name FROM " & GStrG2BFDB & ".dbo.branch_master " & _
                                ") bm ON bm.bhid = clms.bhid " & _
                                "INNER JOIN " & _
                                "( " & _
                                    "SELECT fcid,  name AS FeeClass FROM " & GStrG2BFDB & ".dbo.fee_class " & _
                                ")  fc ON fc.fcid = clms.fcid " & _
                                "ON clms.aid=clm.aid WHERE 1=1 " & strSubSQLfclms & " " & _
                            ") clms ON clms.aid=" & sViewAbbrev1 & ".aid " & _
                            "LEFT OUTER JOIN " & _
                            "( " & _
                             "SELECT aid, mkid, 0 AS net_trade_lmt FROM " & GStrG2BFDB & ".dbo.market_client WHERE mkid='1101' " & _
                            ") mc ON mc.aid=" & sViewAbbrev1 & ".aid " & _
                            "LEFT OUTER JOIN " & GStrG2BFDB & ".dbo.market_master mm ON mm.mkid=mc.mkid " & _
                            "LEFT OUTER JOIN " & _
                            "( " & _
                            "SELECT aid, cuid, bank_code_1, credit_lmt FROM " & GStrG2BFDB & ".dbo.client_bal WHERE cuid=1 " & _
                            ") bal ON bal.aid=" & sViewAbbrev1 & ".aid " & _
                            "LEFT OUTER JOIN " & _
                            "( " & _
                             "SELECT cuid, name_s FROM " & GStrG2BFDB & ".dbo.currency_master WHERE cuid=1 " & _
                            ") cm ON cm.cuid=bal.cuid " & _
                            "WHERE " & sViewAbbrev1 & ".client_type='Futures' " & _
                        ") " & sViewAbbrev1 & " " & _
                        "WHERE 1=1 " & strSQLv1 & " " & _
                    ") " & sViewAbbrev1 & " " & _
                    "INNER JOIN " & _
                    "( " & _
                    "SELECT " & sViewAbbrev2 & ".accno, " & sViewAbbrev2 & ".nature_s, " & sViewAbbrev2 & ".client_type, " & sViewAbbrev2 & ".name_1, " & sViewAbbrev2 & ".name_1_c, " & sViewAbbrev2 & ".aeno, " & sViewAbbrev2 & ".br_id, " & sViewAbbrev2 & ".date_open, " & sViewAbbrev2 & ".sus_date, " & sViewAbbrev2 & ".suspend_field, " & sViewAbbrev2 & ".suspend_code, " & sViewAbbrev2 & ".date_close, " & sViewAbbrev2 & ".external_accno, " & sViewAbbrev2 & ".date_renew, " & _
                    "" & sViewAbbrev2 & ".dob , " & sViewAbbrev2 & ".external_credit_lmt, " & sViewAbbrev2 & ".memo, " & _
                    "" & sViewAbbrev2 & ".CBT ," & _
                    "" & sViewAbbrev2 & ".CJCE , " & _
                    "" & sViewAbbrev2 & ".CME , " & _
                    "" & sViewAbbrev2 & ".CMX , " & _
                    "" & sViewAbbrev2 & ".HKEX ," & _
                    "" & sViewAbbrev2 & ".LME , " & _
                    "" & sViewAbbrev2 & ".NYM , " & _
                    "" & sViewAbbrev2 & ".NYB , " & _
                    "" & sViewAbbrev2 & ".TGE , " & _
                    "" & sViewAbbrev2 & ".TOCOM , " & _
                    "" & sViewAbbrev2 & ".aid , " & _
                    "" & sViewAbbrev2 & ".SEHK, " & _
                    "" & sViewAbbrev2 & ".SZEN, " & _
                    "" & sViewAbbrev2 & ".TF, " & _
                    "" & sViewAbbrev2 & ".CBUS, " & _
                    "" & sViewAbbrev2 & ".CBHK, " & _
                    "" & sViewAbbrev2 & ".SG, " & _
                    "" & sViewAbbrev2 & ".SSE, " & _
                    "" & sViewAbbrev2 & ".BDHK, " & _
                    "" & sViewAbbrev2 & ".FUND, " & _
                    "" & sViewAbbrev2 & ".US, " & _
                    "" & sViewAbbrev2 & ".BDCN, " & _
                    "" & sViewAbbrev2 & ".MAMK, " & _
                    "" & sViewAbbrev2 & ".ae_name , " & _
                    "" & sViewAbbrev2 & ".ae_email , " & _
                    "" & sViewAbbrev2 & ".branch_name," & sViewAbbrev2 & ".ccd_ref, " & sViewAbbrev2 & ".nationality_1 FROM dbo.vw_client_master_2 " & sViewAbbrev2 & " " & _
                    "WHERE 1=1 " & strSQLv2 & " " & _
                    ") " & sViewAbbrev2 & " " & _
                    "ON " & sViewAbbrev2 & ".accno=" & sViewAbbrev1 & ".accno AND " & sViewAbbrev2 & ".aid=" & sViewAbbrev1 & ".aid AND " & sViewAbbrev2 & ".client_type=" & sViewAbbrev1 & ".client_type " & _
                    "WHERE 1=1 ORDER BY " & sViewAbbrev1 & ".accno ASC "


        ldtsData = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        Return GExportCSV(GStrExptDir, strExFile, ldtsData, strTitle, True)

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

End Class
