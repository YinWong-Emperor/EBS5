Imports System.Data.SqlClient

Public Class ClsCommMgrMaster

    Protected Friend Function GetLatestMonth() As String
        Dim lstrSQL As String = "Select isnull(max(txmonth),0) as txmonth from draft_comm_man_master_d "
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows(0).Item(0) = 0 Then
            Return Now.Year.ToString & Format(Val(Now.Month) - 1, "00")
        Else
            Return dt.Rows(0).Item(0)
        End If
    End Function

    Protected Friend Function lFncGetAEFullList() As DataTable
        Dim lstrSQL As String
        Dim lds As DataSet
        lstrSQL = "select ae_no from draft_comm_ae_master order by ae_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mgrm")
        Return lds.Tables(0)
    End Function

    Protected Friend Function lFncGetMgrList(ByVal txmonth As String) As DataTable
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select distinct man_no, man_grp from draft_comm_man_master_d where txmonth = '" & txmonth & "' order by man_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mgrl")
        Return lds.Tables(0)

    End Function

    Protected Friend Function lFncGetMgrDetail(ByVal man_no As String, ByVal man_grp As String, ByVal txmonth As String) As DataTable
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        lstrSQL = "select txmonth, case when (turnover_flag_s <> 0 or brokerage_flag_s <> 0 or rebate_flag_s <> 0) " & _
                    "then case when isDefault_s = 1 then 'Y' else 'N' end " & _
                    "else case when isDefault_f = 1 then 'Y' else 'N' end end as isDefault, " & _
                    "case when turnover_flag_s = 1 then 'Turnover' when brokerage_flag_s = 1 " & _
                    "then 'Brokerage' when rebate_flag_s = 1 then 'Rebate' else '' end turn_brok_s, " & _
                    "case when turnover_flag_f = 1 then 'Turnover' when brokerage_flag_f = 1 " & _
                    "then 'Brokerage' when rebate_flag_f = 1 then 'Rebate' else '' end turn_brok_f " & _
                    "from draft_comm_man_master_d where man_no = '" & man_no & "' and man_grp = '" & man_grp & _
                    "' and txmonth = '" & txmonth & "' order by txmonth"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mgrd")
        Return lds.Tables(0)
    End Function

    Protected Friend Function lFncAddMgr(ByVal mgr_no As String, ByVal mgr_grp As String, ByVal txmonth As String, ByVal turnS As String, _
        ByVal brokS As String, ByVal rebateS As String, ByVal turnF As String, ByVal brokF As String, ByVal rebateF As String, _
        ByVal isDefaultS As String, ByVal isDefaultF As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        lsqlstr = "insert into draft_comm_man_master_d (man_no, man_grp, txmonth, turnover_flag_s, brokerage_flag_s, " & _
            "rebate_flag_s, turnover_flag_f, brokerage_flag_f, rebate_flag_f, isDefault_s, isDefault_f) values ('" & mgr_no & _
            "', '" & mgr_grp & "', '" & txmonth & "', " & turnS & ", " & brokS & ", " & rebateS & ", " & turnF & ", " & brokF & _
            ", " & rebateF & ", " & isDefaultS & ", " & isDefaultF & ") "
        Dim logstr As String = GfncOneFieldLog("Manager No.", mgr_no) & " " & GfncOneFieldLog("Manager Group", mgr_grp) & " " & _
            GfncOneFieldLog("Turnover Securities", IIf(CBool(turnS) = False, "No", "Yes")) & " " & _
            GfncOneFieldLog("Brokerage Securities", IIf(CBool(brokS) = False, "No", "Yes")) & " " & _
            GfncOneFieldLog("Rebate Securities", IIf(CBool(rebateS) = False, "No", "Yes")) & " " & _
            GfncOneFieldLog("Turnover Futures", IIf(CBool(turnF) = False, "No", "Yes")) & " " & _
            GfncOneFieldLog("Brokerage Futures", IIf(CBool(brokF) = False, "No", "Yes")) & " " & _
            GfncOneFieldLog("Rebate Futures", IIf(CBool(rebateF) = False, "No", "Yes")) & " " & _
            GfncOneFieldLog("Default Securities", IIf(CBool(isDefaultS) = False, "No", "Yes")) & " " & _
            GfncOneFieldLog("Default Futures", IIf(CBool(isDefaultF) = False, "No", "Yes"))
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "MgrMaster", "", "", 0, txmonth, logstr, lstnTrans) Then
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

    Protected Friend Function lFncEditMgr(ByVal mgr_no As String, ByVal mgr_grp As String, ByVal txmonth As String, ByVal turnS As String, _
        ByVal brokS As String, ByVal rebateS As String, ByVal turnF As String, ByVal brokF As String, ByVal rebateF As String, _
        ByVal isDefaultS As String, ByVal isDefaultF As String, ByVal sec_fut As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        If (sec_fut = "S") Then
            lsqlstr = " and (turnover_flag_s <> 0 or brokerage_flag_s <> 0 or rebate_flag_s <> 0) "
        Else
            lsqlstr = " and (turnover_flag_f <> 0 or brokerage_flag_f <> 0 or rebate_flag_f <> 0) "
        End If
        lsqlstr = "update draft_comm_man_master_d set turnover_flag_s = " & turnS & ", brokerage_flag_s = " & brokS & _
                    ", rebate_flag_s = " & rebateS & ",  turnover_flag_f = " & turnF & ", brokerage_flag_f = " & brokF & _
                    ", rebate_flag_f = " & rebateF & ", isDefault_s = " & isDefaultS & ", isDefault_f = " & isDefaultF & _
                    " where man_no = '" & mgr_no & "' and man_grp = '" & mgr_grp & "' and txmonth ='" & txmonth & "' " & lsqlstr
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from comm_man_master_d where man_no = '" & mgr_no & _
            "' and man_grp = '" & mgr_grp & "' and txmonth ='" & txmonth & "' " & lsqlstr).Tables(0)
        Dim oldTurnS As String = "0"
        Dim oldBrokS As String = "0"
        Dim oldRebateS As String = "0"
        Dim oldTurnF As String = "0"
        Dim oldBrokF As String = "0"
        Dim oldRebateF As String = "0"
        Dim oldIsDefaultS As String = "0"
        Dim oldIsDefaultF As String = "0"
        If oldDt.Rows.Count > 0 Then
            oldTurnS = GFncNoNullString(oldDt.Rows(0).Item("turnover_flag_s")).Trim
            If oldTurnS = "" Then
                oldTurnS = "0"
            End If
            oldBrokS = GFncNoNullString(oldDt.Rows(0).Item("brokerage_flag_s")).Trim
            If oldBrokS = "" Then
                oldBrokS = "0"
            End If
            oldRebateS = GFncNoNullString(oldDt.Rows(0).Item("rebate_flag_s")).Trim
            If oldRebateS = "" Then
                oldRebateS = "0"
            End If
            oldTurnF = GFncNoNullString(oldDt.Rows(0).Item("turnover_flag_f")).Trim
            If oldTurnF = "" Then
                oldTurnF = "0"
            End If
            oldBrokF = GFncNoNullString(oldDt.Rows(0).Item("brokerage_flag_f")).Trim
            If oldBrokF = "" Then
                oldBrokF = "0"
            End If
            oldRebateF = GFncNoNullString(oldDt.Rows(0).Item("rebate_flag_f")).Trim
            If oldRebateF = "" Then
                oldRebateF = "0"
            End If
            oldIsDefaultS = GFncNoNullString(oldDt.Rows(0).Item("isDefault_s")).Trim
            If oldIsDefaultS = "" Then
                oldIsDefaultS = "0"
            End If
            oldIsDefaultF = GFncNoNullString(oldDt.Rows(0).Item("isDefault_f")).Trim
            If oldIsDefaultF = "" Then
                oldIsDefaultF = "0"
            End If
        End If

        Dim logstr As String = "" 'GfncOneFieldLog("Manager Group", mgr_grp) & " "
        If CBool(oldTurnS) <> CBool(turnS) Then
            logstr &= GfncOneFieldLog("Turnover Securities", IIf(CBool(oldTurnS) = False, "No", "Yes"), IIf(CBool(turnS) = False, "No", "Yes")) & " "
        End If
        If CBool(oldBrokS) <> CBool(brokS) Then
            logstr &= GfncOneFieldLog("Brokerage Securities", IIf(CBool(oldBrokS) = False, "No", "Yes"), IIf(CBool(brokS) = False, "No", "Yes")) & " "
        End If
        If CBool(oldRebateS) <> CBool(rebateS) Then
            logstr &= GfncOneFieldLog("Rebate Securities", IIf(CBool(oldRebateS) = False, "No", "Yes"), IIf(CBool(rebateS) = False, "No", "Yes")) & " "
        End If
        If CBool(oldTurnF) <> CBool(turnF) Then
            logstr &= GfncOneFieldLog("Turnover Futures", IIf(CBool(oldTurnF) = False, "No", "Yes"), IIf(CBool(turnF) = False, "No", "Yes")) & " "
        End If
        If CBool(oldBrokF) <> CBool(brokF) Then
            logstr &= GfncOneFieldLog("Brokerage Futures", IIf(CBool(oldBrokF) = False, "No", "Yes"), IIf(CBool(brokF) = False, "No", "Yes")) & " "
        End If
        If CBool(oldRebateF) <> CBool(rebateF) Then
            logstr &= GfncOneFieldLog("Rebate Futures", IIf(CBool(oldRebateF) = False, "No", "Yes"), IIf(CBool(rebateF) = False, "No", "Yes")) & " "
        End If
        If CBool(oldIsDefaultS) <> CBool(isDefaultS) Then
            logstr &= GfncOneFieldLog("Default Securities", IIf(CBool(oldIsDefaultS) = False, "No", "Yes"), IIf(CBool(isDefaultS) = False, "No", "Yes")) & " "
        End If
        If CBool(oldIsDefaultF) <> CBool(isDefaultF) Then
            logstr &= GfncOneFieldLog("Default Futures", IIf(CBool(oldIsDefaultF) = False, "No", "Yes"), IIf(CBool(isDefaultF) = False, "No", "Yes"))
        End If
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "MgrMaster", mgr_no, "", 0, txmonth, logstr, lstnTrans) Then
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

    Protected Friend Function lFncDeleteMgr(ByVal mgr_no As String, ByVal mgr_grp As String, ByVal txmonth As String, ByVal sec_fut As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        Dim lsqlstr2 As String = ""
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            lsqlstr = "delete from draft_comm_man_master_d where man_no = '" & mgr_no & "' and man_grp = '" & mgr_grp & _
                "' and txmonth ='" & txmonth & "' "
            If (sec_fut = "S") Then
                lsqlstr = lsqlstr & " and (turnover_flag_s = 1 or brokerage_flag_s = 1 or rebate_flag_s = 1)"
                lsqlstr2 = "update draft_comm_ae_master_d set man_no_s = '', man_group_s = '' where man_no_s = '" & mgr_no & _
                    "' and man_group_s = '" & mgr_grp & "' and txmonth = '" & txmonth & "' "
            Else
                lsqlstr = lsqlstr & " and (turnover_flag_f = 1 or brokerage_flag_f = 1 or rebate_flag_f = 1)"
                lsqlstr2 = "update draft_comm_ae_master_d set man_no_f = '', man_group_f = '' where man_no_f = '" & mgr_no & _
                    "' and man_group_f = '" & mgr_grp & "' and txmonth = '" & txmonth & "' "
            End If
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(14))
                Return False
            End If
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr2, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(14))
                Return False
            End If
            Dim logstr As String = GfncOneFieldLog("Manager No.", mgr_no) & " " & GfncOneFieldLog("Manager Group", mgr_grp)
            If Not GFncFillLog(GStrloginID, "D", GDteTradeDate, "MgrMaster", "", "", 0, txmonth, logstr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            logstr = ""
            If mgr_no.Trim <> "" Then
                logstr &= GfncOneFieldLog("Manager No.", mgr_no, "")
            End If
            If mgr_grp.Trim <> "" Then
                logstr &= GfncOneFieldLog("Manager Group", mgr_grp, "")
            End If
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "MgrMaster", mgr_no, "", 0, txmonth, logstr, lstnTrans) Then
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

    Protected Friend Function lFncValidate(ByVal mgr_no As String, ByVal mgr_grp As String, ByVal txmonth As String, ByVal sec_fut As String) As Boolean
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        If (sec_fut = "S") Then
            lstrSQL = " and (turnover_flag_s <> 0 or brokerage_flag_s <> 0 or rebate_flag_s <> 0) "
        Else
            lstrSQL = " and (turnover_flag_f <> 0 or brokerage_flag_f <> 0 or rebate_flag_f <> 0) "
        End If
        lstrSQL = "select * from draft_comm_man_master_d where man_no = '" & mgr_no & "' and man_grp = '" & mgr_grp & _
                    "' and txmonth = '" & txmonth & "' " & lstrSQL
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mgrv")
        If (lds.Tables(0).Rows.Count <= 0) Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function lFncIsAE(ByVal mgr_no As String) As Boolean
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select * from draft_comm_ae_master where ae_no = '" & mgr_no & "' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aev")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

End Class
