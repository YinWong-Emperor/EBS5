Imports System.Data.SqlClient

Public Class ClsCommAEMaster

    Protected Friend Function GetLatestMonth() As String
        Dim lstrSQL As String = "Select isnull(max(txmonth),0) as txmonth from draft_comm_ae_master_d "
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows(0).Item(0) = 0 Then
            Return Now.Year.ToString & Format(Val(Now.Month) - 1, "00")
        Else
            Return dt.Rows(0).Item(0)
        End If
    End Function

    Protected Friend Function lFncIsValidAE(ByVal ae_no As String, ByVal sec_fut As String) As Boolean
        Dim lstrSQL As String = ""
        Dim ae_name As String = ""
        Dim lds As DataSet = Nothing
        If (sec_fut = "S") Then
            lstrSQL = " inSec = 1 "
        ElseIf (sec_fut = "F") Then
            lstrSQL = " inFut = 1 "
        End If
        lstrSQL = "select * from draft_comm_ae_master where ae_no = '" & ae_no & "' and " & lstrSQL & " order by ae_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "ae")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function lFncGetAEName(ByVal ae_no As String, ByVal sec_fut As String) As String
        Dim lstrSQL As String = ""
        Dim ae_name As String = ""
        Dim lds As DataSet
        If (sec_fut = "S") Then
            ae_name = " ae_name_s "
        ElseIf (sec_fut = "F") Then
            ae_name = " ae_name_f "
        End If
        lstrSQL = "select " & ae_name & " from draft_comm_ae_master where ae_no = '" & ae_no & "' order by ae_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aename")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return lds.Tables(0).Rows(0).Item(0)
        End If
        Return ""
    End Function

    Protected Friend Function lFncChkAE(ByVal ae_no As String, ByVal sec_fut As String, ByVal inDetail As Boolean, ByVal strMonth As String) As Boolean
        Dim lstrSQL As String = ""
        Dim ae_name As String = ""
        Dim lds As DataSet
        If IsDBNull(ae_no) Then
            Return False
        End If
        If ae_no.Trim = "" Then
            Return False
        End If
        lstrSQL = "select * from draft_comm_ae_master where ae_no = '" & ae_no & "' "
        If (sec_fut = "S") Then
            lstrSQL += " and insec = 1 "
        ElseIf (sec_fut = "F") Then
            lstrSQL += " and infut = 1 "
        End If
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If (lds.Tables(0).Rows.Count <= 0) Then
            Return False
        End If
        lstrSQL = "select * from draft_comm_ae_master_d where ae_no = '" & ae_no & "' " & _
                " and txmonth = '" & strMonth & "' "
        If (sec_fut = "S") Then
            lstrSQL += " and iscommission_s = 1 "
        ElseIf (sec_fut = "F") Then
            lstrSQL += " and iscommission_f = 1 "
        End If
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If (lds.Tables(0).Rows.Count <= 0) Then
            If inDetail Then
                Return False
            End If
        Else
            'If Not inDetail Then
            '    Return False
            'End If
        End If
        Return True
    End Function

    Protected Friend Function lFncGetAEFullList(ByVal AE As String) As DataSet
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        If AE.Length > 0 Then
            lstrSQL = "where ae_no like '%" & AE & "%' "
        End If
        lstrSQL = "select ae_no from draft_comm_ae_master " & lstrSQL & "order by ae_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aem")
        Return lds
    End Function

    Protected Friend Function lFncGetMgrGrpList(ByVal txmonth As String) As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet
        lstrSQL = "select man_no, man_grp, case when (turnover_flag_s <> 0 or brokerage_flag_s <> 0) then 'S' else 'F' end " & _
            "as sec_fut from draft_comm_man_master_d where txmonth = '" & txmonth & "' order by man_no, man_grp"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aem")
        Return lds
    End Function

    Protected Friend Function lFncGetAEList(ByVal txmonth As String, ByVal incentive_bonus As String, ByVal AE As String) As DataSet
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        If (incentive_bonus = "I") Then
            lstrSQL = " and incentive_flag = 1 "
        ElseIf (incentive_bonus = "B") Then
            lstrSQL = " and bonus_flag = 1 "
        End If
        If AE.Length > 0 Then
            lstrSQL = " and ae_no like '%" & AE & "%' "
        End If
        lstrSQL = "select distinct ae_no from draft_comm_ae_master_d where txmonth = '" & txmonth & "' " & lstrSQL & " order by ae_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aem")
        Return lds
    End Function

    Protected Friend Function lFncGetAEDetail(ByVal ae_no As String, ByVal txmonth As String, ByVal incentive_bonus As String) As DataSet
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        If (incentive_bonus = "I") Then
            lstrSQL = " and incentive_flag = 1 "
        ElseIf (incentive_bonus = "B") Then
            lstrSQL = " and bonus_flag = 1 "
        End If
        lstrSQL = "select txmonth, man_no_s, man_group_s, man_no_f, man_group_f, " & _
                    "case when incentive_flag = 1 then 'Y' else 'N' end incentive, " & _
                    "case when bonus_flag = 1 then 'Y' else 'N' end bonus, isnull(team, '') as team, " & _
                    "case when isConsolid = 1 then 'Y' else 'N' end as isConsolid, " & _
                    "minNorAmt, minIntAmt, minNorRate, minIntRate, " & _
                    "case when isDefault_s = 1 then 'Y' else 'N' end as standard_s, " & _
                    "case when isDefault_f = 1 then 'Y' else 'N' end as standard_f, " & _
                    "case when isCommission_s = 1 then 'Securities' else 'Futures' end as sec_fut, " & _
                    "case when isBothFO = 1 then 'Y' else 'N' end as isFOB " & _
                    "from draft_comm_ae_master_d where ae_no = '" & ae_no & "' and txmonth = '" & txmonth & "' " & _
                    lstrSQL & " order by txmonth"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aed")
        Return lds
    End Function
    Protected Friend Function lFncCopyAE(ByVal strAEFrom As String, ByVal strAETo As String, ByVal strMonth As String, ByVal sec_fut As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = ""
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            lstrSQL = " delete from draft_comm_ae_master_d where ae_no = '" & strAETo & "' and txmonth = '" & strMonth & "' "
            If (sec_fut = "S") Then
                lstrSQL += " and iscommission_s = 1 "
            Else
                lstrSQL += " and iscommission_f = 1 "
            End If
            lstrSQL = "insert into draft_comm_ae_master_d (ae_no, txmonth, man_no_s, man_no_f, man_group_s, man_group_f, " & _
                "incentive_flag, bonus_flag, team, isConsolid, minNorAmt, minIntAmt, minNorRate, minIntRate, isDefault_s, " & _
                "isDefault_f, isCommission_s,isCommission_f,isBothFO) select '" & strAETo & "' as ae_no, txmonth ,man_no_s ,man_no_f, " & _
                "man_group_s, man_group_f, incentive_flag, bonus_flag, team, isConsolid, minNorAmt, minIntAmt, minNorRate, " & _
                "minIntRate, isDefault_s, isDefault_f, isCommission_s, isCommission_f,isBothFO from draft_comm_ae_master_d " & _
                "where ae_no = '" & strAEFrom & "' and txmonth = '" & strMonth & "' "
            If (sec_fut = "S") Then
                lstrSQL += " and iscommission_s = 1 "
            Else
                lstrSQL += " and iscommission_f = 1 "
            End If
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            If (sec_fut = "S") Then
                lstrSQL = " delete from draft_comm_rate_s where ae_no = '" & strAETo & "' and comm_month = '" & strMonth & _
                    "' and comm_type = 'AE' "
                GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0)
                lstrSQL = " insert into draft_comm_rate_s (acc_no, acc_group, man_no, man_group, ae_no, rate_type, turnover_from, " & _
                    "comm_rate, comm_month, comm_type, turnover_type, brokerage_rate) select acc_no, acc_group, man_no, " & _
                    "man_group, '" & strAETo & "' as ae_no, rate_type, turnover_from, comm_rate, comm_month, comm_type, " & _
                    "turnover_type, brokerage_rate from draft_comm_rate_s " & _
                    "where ae_no = '" & strAEFrom & "' and comm_type = 'AE' and comm_month = '" & strMonth & "' "
            Else
                lstrSQL = " delete from draft_comm_rate_f where ae_no = '" & strAETo & "' and comm_month = '" & strMonth & _
                    "' and comm_type = 'AE' "
                GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0)
                lstrSQL = " insert into draft_comm_rate_f (acc_no, acc_group, man_no, man_group, ae_no, product_group, comm_rate, " & _
                    "rate_type, turnover_from, day_rate, night_rate, all_rate, comm_month, comm_type, turnover_type, " & _
                    "brok_per_lot) select acc_no, acc_group, man_no, man_group, '" & strAETo & "' as ae_no, product_group, " & _
                    "comm_rate, rate_type,turnover_from, day_rate, night_rate, all_rate, comm_month, comm_type, turnover_type, " & _
                    "brok_per_lot from draft_comm_rate_f " & _
                    "where ae_no = '" & strAEFrom & "' and comm_type = 'AE' and comm_month = '" & strMonth & "' "
            End If
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            Dim logstr As String = ""
            If (sec_fut = "S") Then
                logstr = "Copy from AE No. (Securities) " & strAEFrom & " To AE. No. (Securities) " & strAETo
            Else
                logstr = "Copy from AE No. (Futures) " & strAEFrom & " To AE. No. (Futures) " & strAETo
            End If
            If Not GFncFillLog(GStrloginID, "C", GDteTradeDate, "AEMaster", "", "", 0, strMonth, logstr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstnTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function lFncDeleteAE(ByVal ae_no As String, ByVal txmonth As String, ByVal man_no As String, ByVal man_grp As String, ByVal sec_fut As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        If (sec_fut = "S") Then
            lsqlstr = " and man_no_s = '" & man_no & "' and man_group_s = '" & man_grp & "' and isCommission_s = 1 "
        ElseIf (sec_fut = "F") Then
            lsqlstr = " and man_no_f = '" & man_no & "' and man_group_f = '" & man_grp & "' and isCommission_f = 1 "
        Else
            Return False
        End If
        lsqlstr = "delete from draft_comm_ae_master_d where ae_no = '" & ae_no & "' and txmonth ='" & txmonth & "' " & lsqlstr
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(14))
                Return False
            End If
            Dim logStr As String = ""
            If (sec_fut = "S") Then
                logStr &= GfncOneFieldLog("Manager No. Securities", man_no) & " " & GfncOneFieldLog("Manager Group Securities", man_grp) & _
                            " " & GfncOneFieldLog("Commission Securities", "Yes")
            ElseIf (sec_fut = "F") Then
                logStr &= GfncOneFieldLog("Manager No. Futures", man_no) & " " & GfncOneFieldLog("Manager Group Futures", man_grp) & " " & _
                            GfncOneFieldLog("Commission Futures", "Yes")
            End If
            If Not GFncFillLog(GStrloginID, "D", GDteTradeDate, "AEMASTER", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstnTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(13))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    'Protected Friend Function lFncAddAE(ByVal ae_no As String, ByVal txmonth As String, ByVal man_no_s As String, _
    '   ByVal man_no_f As String, ByVal man_group_s As String, ByVal man_group_f As String, _
    '   ByVal incentive As String, ByVal bonus As String) As Boolean
    '    Dim lstnTrans As SqlTransaction = Nothing
    '    Dim lsqlstr As String = ""
    '    lsqlstr = "insert into comm_ae_master_d(ae_no, txmonth, man_no_s, man_no_f, man_group_s, man_group_f, incentive_flag, " & _
    '                "bonus_flag) values ('" & ae_no & "', '" & txmonth & "', '" & man_no_s & "', '" & man_no_f & "', '" & _
    '                man_group_s & "', '" & man_group_f & "', " & incentive & ", " & bonus & ") "
    '    Try
    '        lstnTrans = GSCnSqlConn.BeginTransaction
    '        If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
    '            lstnTrans.Rollback()
    '            Return False
    '        End If
    '        lstnTrans.Commit()
    '    Catch ex As Exception
    '        If GSCnLiqConn.State <> ConnectionState.Closed Then
    '            If (lstnTrans IsNot Nothing) Then
    '                lstnTrans.Rollback()
    '            End If
    '            GSubWriteErrLog(ex.Message)
    '        End If
    '    End Try
    '    Return True
    'End Function

    Protected Friend Function lFncAddAE(ByVal ae_no As String, ByVal txmonth As String, ByVal sec_fut As String, ByVal team As String, _
        ByVal man_no As String, ByVal man_group As String, ByVal incentive As String, ByVal bonus As String, ByVal standard As String, _
        ByVal isConsolid As String, ByVal isFOB As String, ByVal minNorAmt As Decimal, ByVal minIntAmt As Decimal, _
        ByVal minNorRate As Decimal, ByVal minIntRate As Decimal) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        If (standard = "1") Then
            minNorAmt = 0
            minIntAmt = 0
            minNorRate = 0
            minIntRate = 0
        End If
        If (IsDBNull(isFOB)) Then
            isFOB = "0"
        End If
        Dim logStr As String = GfncOneFieldLog("txmonth", txmonth) & " "
        lsqlstr = "insert into draft_comm_ae_master_d(ae_no, txmonth, man_no_s, man_no_f, man_group_s, man_group_f, " & _
            "incentive_flag, bonus_flag, team, isConsolid, minNorAmt, minIntAmt, minNorRate, minIntRate, isDefault_s, " & _
            "isDefault_f, isCommission_s, isCommission_f, isBothFO) values ('" & ae_no & "', '" & txmonth & "', '"
        If (sec_fut = "S") Then
            lsqlstr &= man_no & "', '', '" & man_group & "', '', " & incentive & ", " & bonus & ", '" & team & "', " & _
                isConsolid & ", " & minNorAmt & ", " & minIntAmt & ", " & minNorRate & ", " & minIntRate & ", " & standard & _
                ", 0, 1, 0, " & isFOB & ")"
            logStr &= GfncOneFieldLog("Manager No. Securities", man_no) & " " & _
                GfncOneFieldLog("Manager Group Securities", man_group) & " " & _
                GfncOneFieldLog("Incentive", IIf(CBool(incentive) = False, "No", "Yes")) & " " & _
                GfncOneFieldLog("Bonus", IIf(CBool(bonus) = False, "No", "Yes")) & " " & _
                GfncOneFieldLog("Team", team) & " " & GfncOneFieldLog("Consolid", CBool(isConsolid)) & " " & _
                GfncOneFieldLog("Min. Nor. Amt.", minNorAmt) & " " & GfncOneFieldLog("Min. Int. Amt.", minIntAmt) & " " & _
                GfncOneFieldLog("Min. Nor. Rate", minNorRate) & " " & GfncOneFieldLog("Min. Int. Rate", minIntRate) & " " & _
                GfncOneFieldLog("Default Securities", IIf(CBool(standard) = False, "No", "Yes")) & " " & _
                GfncOneFieldLog("Commission Securities", "Yes") & " " & _
                GfncOneFieldLog("Consolidate FO", IIf(CBool(isFOB) = False, "No", "Yes"))
        ElseIf (sec_fut = "F") Then
            lsqlstr += "','" & man_no & "','','" & man_group & "'," & incentive & "," & bonus & ",'" & team & "'," & isConsolid & "," & _
                        minNorAmt & "," & minIntAmt & "," & minNorRate & "," & minIntRate & ",0," & standard & ",0,1, " & isFOB & ")"
            logStr &= GfncOneFieldLog("Manager No. Futures", man_no) & " " & GfncOneFieldLog("Manager Group Futures", man_group) & " " & _
                        GfncOneFieldLog("Incentive", IIf(CBool(incentive) = False, "No", "Yes")) & " " & _
                        GfncOneFieldLog("Bonus", IIf(CBool(bonus) = False, "No", "Yes")) & " " & _
                        GfncOneFieldLog("Team", team) & " " & GfncOneFieldLog("Consolid", IIf(CBool(isConsolid) = False, "No", "Yes")) & " " & _
                        GfncOneFieldLog("Min. Nor. Amt.", minNorAmt) & " " & GfncOneFieldLog("Min. Int. Amt.", minIntAmt) & " " & _
                        GfncOneFieldLog("Min. Nor. Rate", minNorRate) & " " & GfncOneFieldLog("Min. Int. Rate", minIntRate) & " " & _
                        GfncOneFieldLog("Default Futures", IIf(CBool(standard) = False, "No", "Yes")) & " " & _
                        GfncOneFieldLog("Commission Futures", "No") & " " & GfncOneFieldLog("Consolidate FO", IIf(CBool(isFOB) = False, "No", "Yes"))
        Else
            Return False
        End If
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "AEMASTER", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstnTrans.Commit()
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function lFncEditAE(ByVal ae_no As String, ByVal txmonth As String, ByVal sec_fut As String, ByVal team As String, _
        ByVal pre_mgr_no As String, ByVal pre_mgr_grp As String, ByVal man_no As String, ByVal man_group As String, ByVal incentive As String, _
        ByVal bonus As String, ByVal standard As String, ByVal isConsolid As String, ByVal isFOB As String, ByVal minNorAmt As Decimal, _
        ByVal minIntAmt As Decimal, ByVal minNorRate As Decimal, ByVal minIntRate As Decimal) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        If (standard = "1") Then
            minNorAmt = 0
            minIntAmt = 0
            minNorRate = 0
            minIntRate = 0
        End If
        If (IsDBNull(isFOB)) Then
            isFOB = "0"
        End If
        Dim oldDt As DataTable
        lsqlstr = "update draft_comm_ae_master_d set incentive_flag = " & incentive & ", bonus_flag = " & bonus & _
            ", team = '" & team & "', isConsolid = " & isConsolid & ", isBothFO = " & isFOB & ", minNorAmt = " & minNorAmt & _
            ", minIntAmt = " & minIntAmt & ", minNorRate = " & minNorRate & ", minIntRate = " & minIntRate
        If (sec_fut = "S") Then
            lsqlstr &= ", man_no_s = '" & man_no & "', man_group_s = '" & man_group & "', isDefault_s = " & standard & _
                " where ae_no = '" & ae_no & "' and txmonth ='" & txmonth & "' and man_no_s = '" & pre_mgr_no & _
                "' and man_group_s = '" & pre_mgr_grp & "' and isCommission_s = 1 "
            oldDt = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_ae_master_d where ae_no = '" & ae_no & "' and txmonth ='" & _
                txmonth & "' and man_no_s = '" & pre_mgr_no & "' and man_group_s = '" & pre_mgr_grp & "' and isCommission_s = 1 ").Tables(0)
        ElseIf (sec_fut = "F") Then
            lsqlstr &= ", man_no_f = '" & man_no & "', man_group_f = '" & man_group & "', isDefault_f = " & standard & _
                " where ae_no = '" & ae_no & "' and txmonth ='" & txmonth & "' and man_no_f = '" & pre_mgr_no & _
                "' and man_group_f = '" & pre_mgr_grp & "' and isCommission_f = 1 "
            oldDt = GFncRtnDS(GSCnSqlConn, "select * from comm_ae_master_d where ae_no = '" & ae_no & "' and txmonth ='" & _
                txmonth & "' and man_no_f = '" & pre_mgr_no & "' and man_group_f = '" & pre_mgr_grp & "' and isCommission_f = 1 ").Tables(0)
        Else
            Return False
        End If
        Dim oldIncentive As String = ""
        Dim oldBonus As String = ""
        Dim oldTeam As String = ""
        Dim oldIsConsolid As String = ""
        Dim oldIsBothFo As String = ""
        Dim oldMinNorAmt As String = ""
        Dim oldMinIntAmt As String = ""
        Dim oldMinNorRate As String = ""
        Dim oldMinIntRate As String = ""
        Dim oldMan_no As String = ""
        Dim oldMan_group As String = ""
        Dim oldStandard As String = ""
        If oldDt.Rows.Count > 0 Then
            oldIncentive = GFncNoNullString(oldDt.Rows(0).Item("incentive_flag")).Trim
            oldBonus = GFncNoNullString(oldDt.Rows(0).Item("bonus_flag")).Trim
            oldTeam = GFncNoNullString(oldDt.Rows(0).Item("team")).Trim
            oldIsConsolid = GFncNoNullString(oldDt.Rows(0).Item("isConsolid")).Trim
            oldIsBothFo = GFncNoNullString(oldDt.Rows(0).Item("isBothFO")).Trim
            oldMinNorAmt = GFncNoNullString(oldDt.Rows(0).Item("minNorAmt")).Trim
            oldMinIntAmt = GFncNoNullString(oldDt.Rows(0).Item("minIntAmt")).Trim
            oldMinNorRate = GFncNoNullString(oldDt.Rows(0).Item("minNorRate")).Trim
            oldMinIntRate = GFncNoNullString(oldDt.Rows(0).Item("minIntRate")).Trim
            If sec_fut = "S" Then
                oldMan_no = GFncNoNullString(oldDt.Rows(0).Item("man_no_s")).Trim
                oldMan_group = GFncNoNullString(oldDt.Rows(0).Item("man_group_s")).Trim
                oldStandard = GFncNoNullString(oldDt.Rows(0).Item("isDefault_s")).Trim
            ElseIf (sec_fut = "F") Then
                oldMan_no = GFncNoNullString(oldDt.Rows(0).Item("man_no_f")).Trim
                oldMan_group = GFncNoNullString(oldDt.Rows(0).Item("man_group_f")).Trim
                oldStandard = GFncNoNullString(oldDt.Rows(0).Item("isDefault_f")).Trim
            End If
        End If
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim logStr As String = ""
            If CBool(oldIncentive) <> CBool(incentive) Then
                logStr &= GfncOneFieldLog("Incentive", IIf(CBool(oldIncentive) = False, "No", "Yes"), IIf(CBool(incentive) = False, "No", "Yes")) & " "
            End If
            If CBool(oldBonus) <> CBool(bonus) Then
                logStr &= GfncOneFieldLog("Bonus", IIf(CBool(oldBonus) = False, "No", "Yes"), IIf(CBool(bonus) = False, "No", "Yes")) & " "
            End If
            If oldTeam.Trim <> team.Trim Then
                logStr &= GfncOneFieldLog("Team", oldTeam.Trim, team.Trim) & " "
            End If
            If CBool(oldIsConsolid) <> CBool(isConsolid) Then
                logStr &= GfncOneFieldLog("Consolid", IIf(CBool(oldIsConsolid) = False, "No", "Yes"), IIf(CBool(isConsolid) = False, "No", "Yes")) & " "
            End If
            If CBool(oldIsBothFo) <> CBool(isFOB) Then
                logStr &= GfncOneFieldLog("Consolidate FO", IIf(CBool(oldIsBothFo) = False, "No", "Yes"), IIf(CBool(isFOB) = False, "No", "Yes")) & " "
            End If
            If CDbl(oldMinNorAmt) <> minNorAmt Then
                logStr &= GfncOneFieldLog("Min. Nor. Amt.", CDbl(oldMinNorAmt), minNorAmt) & " "
            End If
            If CDbl(oldMinIntAmt) <> minIntAmt Then
                logStr &= GfncOneFieldLog("Min. Int. Amt.", CDbl(oldMinIntAmt), minIntAmt) & " "
            End If
            If CDbl(oldMinNorRate) <> minNorRate Then
                logStr &= GfncOneFieldLog("Min. Nor. Rate", CDbl(oldMinNorRate), minNorRate) & " "
            End If
            If CDbl(oldMinIntRate) <> minIntRate Then
                logStr &= GfncOneFieldLog("Min. Int. Rate", CDbl(oldMinIntRate), minIntRate) & " "
            End If
            If sec_fut = "S" Then
                If oldMan_no.Trim <> man_no.Trim Then
                    logStr &= GfncOneFieldLog("Manager No Securities", oldMan_no.Trim, man_no.Trim) & " "
                End If
                If oldMan_group.Trim <> man_group.Trim Then
                    logStr &= GfncOneFieldLog("Manager Group Securities", oldMan_group.Trim, man_group.Trim) & " "
                End If
                If CBool(oldStandard) <> CBool(standard) Then
                    logStr &= GfncOneFieldLog("Default Securities", IIf(CBool(oldStandard) = False, "No", "Yes"), IIf(CBool(standard) = False, "No", "Yes")) & " "
                End If
            ElseIf (sec_fut = "F") Then
                If oldMan_no.Trim <> man_no.Trim Then
                    logStr &= GfncOneFieldLog("Manager No. Futures", oldMan_no.Trim, man_no.Trim) & " "
                End If
                If oldMan_group.Trim <> man_group.Trim Then
                    logStr &= GfncOneFieldLog("Manager Group Futures", oldMan_group.Trim, man_group.Trim) & " "
                End If
                If CBool(oldStandard) <> CBool(standard) Then
                    logStr &= GfncOneFieldLog("Default Futures", IIf(CBool(oldStandard) = False, "No", "Yes"), IIf(CBool(standard) = False, "No", "Yes")) & " "
                End If
            End If
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "AEMASTER", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstnTrans.Commit()
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function lFncValidate(ByVal ae_no As String, ByVal txmonth As String, ByVal man_no As String, _
        ByVal man_grp As String, ByVal sec_fut As String) As Boolean
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        If (sec_fut = "S") Then
            lstrSQL = " and man_no_s = '" & man_no & "' and man_group_s = '" & man_grp & "' and isCommission_s = 1 "
        Else
            lstrSQL = " and man_no_f = '" & man_no & "' and man_group_f = '" & man_grp & "' and isCommission_f = 1 "
        End If
        lstrSQL = "select * from draft_comm_ae_master_d where ae_no = '" & ae_no & "' and txmonth = '" & txmonth & "' " & lstrSQL
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aem")
        If (lds.Tables(0).Rows.Count <= 0) Then
            Return True
        End If
        Return False
    End Function

    'Protected Friend Function lFncValidateF(ByVal ae_no As String, ByVal txmonth As String, ByVal man_no_f As String) As Boolean
    '    Dim lstrSQL As String = ""
    '    Dim lds As DataSet = Nothing
    '    lstrSQL = "select * from comm_ae_master_d where ae_no = '" & ae_no & "' and txmonth = '" & txmonth & _
    '                "' and man_no_f = '" & man_no_f & "'"
    '    lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aem")
    '    If (lds.Tables(0).Rows.Count > 0) Then
    '        Return True
    '    End If
    '    Return False
    'End Function

    Protected Friend Function lFncGetAEInfo(ByVal ae_no As String) As DataTable
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        lstrSQL = "select ae_name, ae_name_s, ae_name_f, bank_code, bank_acc, IR56M_flag from draft_comm_ae_master where ae_no = '" & ae_no & "' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aed")
        Return lds.Tables(0)
    End Function

    Protected Friend Function lFncSaveAE(ByVal ae_no As String, ByVal ae_name As String, ByVal bank_code As String, _
        ByVal bank_acc As String, ByVal IR56M As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        'for logs
        Dim monthStr As String = "select * from misc_master where misc_type = 'commmonth'"
        Dim monthDT As DataTable = GFncRtnDS(GSCnSqlConn, monthStr).Tables(0)
        Dim monthCode As String = Format(Date.Now, "yyyyMM")
        If monthDT.Rows.Count > 0 Then
            monthCode = GFncNoNullString(monthDT.Rows(0).Item("misc_code")).Trim
        End If
        'for logs end
        lsqlstr = "update draft_comm_ae_master set ae_name = '" & ae_name & "', bank_code = '" & bank_code & "', bank_acc = '" & _
            bank_acc & "', IR56M_flag = '" & IR56M & "' where ae_no = '" & ae_no & "'"
        Try
            Dim oldName As String = ""
            Dim oldBank As String = ""
            Dim oldAcc As String = ""
            Dim oldIR As String = ""
            Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_ae_master where ae_no = '" & ae_no & "'").Tables(0)
            If oldDt.Rows.Count > 0 Then
                oldName = GFncNoNullString(oldDt.Rows(0).Item("ae_name")).Trim
                oldBank = GFncNoNullString(oldDt.Rows(0).Item("bank_code")).Trim
                oldAcc = GFncNoNullString(oldDt.Rows(0).Item("bank_acc")).Trim
                oldIR = GFncNoNullString(oldDt.Rows(0).Item("IR56M_flag")).Trim
            End If
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            Dim logStr As String = ""
            If oldName <> ae_name.Trim Then
                logStr = GfncOneFieldLog("AE Name", oldName, ae_name.Trim)
            End If
            If oldBank <> bank_code.Trim Then
                logStr &= GfncOneFieldLog("Bank Code", oldBank, bank_code.Trim)
            End If
            If oldAcc <> bank_acc.Trim Then
                logStr &= GfncOneFieldLog("Bank Account", oldAcc, bank_acc.Trim)
            End If
            If oldIR <> IR56M.Trim Then
                logStr &= GfncOneFieldLog("IR56M", oldIR, IR56M.Trim)
            End If
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "AEMASTER", ae_no, "", 0, monthCode, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstnTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

End Class
