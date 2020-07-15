Imports System.Data.SqlClient

Public Class ClsCommGroupMaster

    Protected Friend Function GetLatestMonth() As String
        Dim lstrSQL As String = "Select isnull(max(txmonth),0) as txmonth from draft_comm_group_s "
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

    Protected Friend Function lFncGetAEListS(ByVal txmonth As String) As DataTable
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select distinct ae_no from draft_comm_group_s where txmonth = '" & txmonth & "' order by ae_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mgrl")
        Return lds.Tables(0)
    End Function

    Protected Friend Function lFncGetAEListF(ByVal txmonth As String) As DataTable
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select distinct ae_no from draft_comm_group_f where txmonth = '" & txmonth & "' order by ae_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mgrl")
        Return lds.Tables(0)
    End Function

    Protected Friend Function lFncGetAEDetailS(ByVal ae_no As String, ByVal txmonth As String) As DataTable
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        lstrSQL = "select txmonth, ae_group_s, case when isConsolid=1 then 'Y' else 'N' end as isConsolid, minConTO, minNorTO, " & _
            "minIntTO from draft_comm_group_s where ae_no = '" & ae_no & "' and txmonth = '" & txmonth & "' order by txmonth"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mgrd")
        Return lds.Tables(0)
    End Function

    Protected Friend Function lFncGetAEDetailF(ByVal ae_no As String, ByVal txmonth As String) As DataTable
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        lstrSQL = "select txmonth, ae_group_f, case when isConsolid=1 then 'Y' else 'N' end as isConsolid, minConTO, minNorTO, " & _
            "minIntTO, case when isBothFO=1 then 'Y' else 'N' end as isBothFO from draft_comm_group_f where ae_no = '" & ae_no & _
            "' and txmonth = '" & txmonth & "' order by txmonth"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mgrd")
        Return lds.Tables(0)
    End Function

    Protected Friend Function lFncAddAES(ByVal ae_no As String, ByVal ae_group As String, ByVal txmonth As String, _
        ByVal isConsolid As String, ByVal minConTO As String, ByVal minNorTO As String, ByVal minIntTO As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        lsqlstr = "insert into draft_comm_group_s (ae_no, ae_group_s, txmonth, isConsolid, minConTO, minNorTO, minIntTO) " & _
            "values ('" & ae_no & "', '" & ae_group & "', '" & txmonth & "', '" & isConsolid & "', '" & minConTO & "', '" & _
            minNorTO & "', '" & minIntTO & "') "
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim logStr As String = GfncOneFieldLog("AE Group Securities", ae_group) & " " & _
                GfncOneFieldLog("Consolid", IIf(CBool(isConsolid) = False, "No", "Yes")) & " " & _
                GfncOneFieldLog("Min. Con. Turnover", minConTO) & " " & GfncOneFieldLog("Min. Nor. Turnover", minNorTO) & " " & _
                GfncOneFieldLog("Min. Int. Turnover", minIntTO)
            If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "ACGrpMasterS", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
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

    Protected Friend Function lFncAddAEF(ByVal ae_no As String, ByVal ae_group As String, ByVal txmonth As String, ByVal isConsolid As String, _
        ByVal minConTO As String, ByVal minNorTO As String, ByVal minIntTO As String, ByVal isBothFO As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        lsqlstr = "insert into draft_comm_group_f (ae_no, ae_group_f, txmonth, isConsolid, minConTO, minNorTO, minIntTO, " & _
            "isBothFO) values ('" & ae_no & "', '" & ae_group & "', '" & txmonth & "', '" & isConsolid & "', '" & minConTO & _
            "', '" & minNorTO & "', '" & minIntTO & "', '" & isBothFO & "') "
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim logStr As String = GfncOneFieldLog("AE Group Futures", ae_group) & " " & _
                GfncOneFieldLog("Consolid", IIf(CBool(isConsolid) = False, "No", "Yes")) & " " & _
                GfncOneFieldLog("Min. Con. Turnover", minConTO) & " " & GfncOneFieldLog("Min. Nor. Turnover", minNorTO) & " " & _
                GfncOneFieldLog("Min. Int. Turnover", minIntTO) & " " & _
                GfncOneFieldLog("Consolidate", IIf(CBool(isBothFO) = False, "No", "Yes"))
            If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "ACGrpMasterF", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
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

    Protected Friend Function lFncEditAES(ByVal ae_no As String, ByVal ae_group As String, ByVal preAEGroup As String, ByVal txmonth As String, _
        ByVal isConsolid As String, ByVal minConTO As String, ByVal minNorTO As String, ByVal minIntTO As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        Try
            Dim oldIsConsolid As Boolean = False
            Dim oldMinConTo As Double = 0
            Dim oldMinNorTo As Double = 0
            Dim oldMinIntTo As Double = 0
            Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_group_s where ae_no = '" & ae_no & _
                "' and ae_group_s = '" & preAEGroup & "' and txmonth ='" & txmonth & "' ").Tables(0)
            If oldDt.Rows.Count > 0 Then
                oldIsConsolid = CBool(oldDt.Rows(0).Item("isConsolid"))
                oldMinConTo = GFncNoNullValue(oldDt.Rows(0).Item("minConTO"))
                oldMinNorTo = GFncNoNullValue(oldDt.Rows(0).Item("minNorTO"))
                oldMinIntTo = GFncNoNullValue(oldDt.Rows(0).Item("minIntTO"))
            End If
            lstnTrans = GSCnSqlConn.BeginTransaction
            lsqlstr = "update draft_comm_group_s set ae_group_s = '" & ae_group & "', isConsolid = " & isConsolid & _
                ", minConTO = " & minConTO & ",  minNorTO = " & minNorTO & ", minIntTO = " & minIntTO & " where ae_no = '" & _
                ae_no & "' and ae_group_s = '" & preAEGroup & "' and txmonth ='" & txmonth & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim logStr As String = ""
            If preAEGroup.Trim <> ae_group.Trim Then
                logStr &= GfncOneFieldLog("AE Group", preAEGroup.Trim, ae_group.Trim) & " "
            End If
            If oldIsConsolid <> CBool(isConsolid) Then
                logStr &= GfncOneFieldLog("Consolid", IIf(oldIsConsolid = False, "No", "Yes"), IIf(CBool(isConsolid) = False, "No", "Yes")) & " "
            End If
            If oldMinConTo <> CDbl(minConTO) Then
                logStr &= GfncOneFieldLog("Min. Con. Turnover", oldMinConTo, CDbl(minConTO)) & " "
            End If
            If oldMinNorTo <> CDbl(minNorTO) Then
                logStr &= GfncOneFieldLog("Min. Nor. Turnover", oldMinNorTo, CDbl(minNorTO)) & " "
            End If
            If oldMinIntTo <> CDbl(minIntTO) Then
                logStr &= GfncOneFieldLog("Min. Int. Turnover", oldMinIntTo, CDbl(minIntTO))
            End If
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "ACGrpMasterS", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            Dim oldGAE As String = ""
            oldDt = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_acc_master_d where ae_no_s = '" & ae_no & _
                "' and acc_group_s = '" & preAEGroup & "' and txmonth ='" & txmonth & "' ", lstnTrans).Tables(0)
            If oldDt.Rows.Count > 0 Then
                oldGAE = GFncNoNullString(oldDt.Rows(0).Item("acc_group_s")).Trim
            End If
            lsqlstr = "update draft_comm_acc_master_d set acc_group_s = '" & ae_group & "' where ae_no_s = '" & ae_no & _
                "' and acc_group_s = '" & preAEGroup & "' and txmonth ='" & txmonth & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) < 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            logStr = GfncOneFieldLog("Account Group Securities", oldGAE, ae_group)
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "ACGrpMasterS", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
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

    Protected Friend Function lFncEditAEF(ByVal ae_no As String, ByVal ae_group As String, ByVal preAEGroup As String, ByVal txmonth As String, _
        ByVal isConsolid As String, ByVal minConTO As String, ByVal minNorTO As String, ByVal minIntTO As String, ByVal isBothFO As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        Try
            Dim oldIsConsolid As Boolean = False
            Dim oldMinConTo As Double = 0
            Dim oldMinNorTo As Double = 0
            Dim oldMinIntTo As Double = 0
            Dim oldIsBothFo As Boolean = False
            Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from comm_group_f  where ae_no = '" & ae_no & _
                "' and ae_group_f = '" & preAEGroup & "' and txmonth ='" & txmonth & "' ").Tables(0)
            If oldDt.Rows.Count > 0 Then
                oldIsConsolid = CBool(oldDt.Rows(0).Item("isConsolid"))
                oldMinConTo = GFncNoNullValue(oldDt.Rows(0).Item("minConTO"))
                oldMinNorTo = GFncNoNullValue(oldDt.Rows(0).Item("minNorTO"))
                oldMinIntTo = GFncNoNullValue(oldDt.Rows(0).Item("minIntTO"))
                oldIsBothFo = CBool(oldDt.Rows(0).Item("isBothFO"))
            End If
            lstnTrans = GSCnSqlConn.BeginTransaction
            lsqlstr = "update draft_comm_group_f set ae_group_f = '" & ae_group & "', isConsolid = '" & isConsolid & _
                "', minConTO = '" & minConTO & "',  minNorTO = '" & minNorTO & "', minIntTO = '" & minIntTO & _
                "', isBothFO = '" & isBothFO & "' where ae_no = '" & ae_no & "' and ae_group_f = '" & preAEGroup & _
                "' and txmonth ='" & txmonth & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim logStr As String = ""
            If ae_no.Trim <> ae_group Then
                logStr &= GfncOneFieldLog("AE Group Futures", ae_no.Trim, ae_group.Trim) & " "
            End If
            If oldIsConsolid <> CBool(isConsolid) Then
                logStr &= GfncOneFieldLog("Consolid", IIf(oldIsConsolid = False, "No", "Yes"), IIf(CBool(isConsolid) = False, "No", "Yes")) & " "
            End If
            If oldMinConTo <> CDbl(minConTO) Then
                logStr &= GfncOneFieldLog("Min. Con. Turnover", oldMinConTo, CDbl(minConTO)) & " "
            End If
            If oldMinNorTo <> CDbl(minNorTO) Then
                logStr &= GfncOneFieldLog("Min. Nor. Turnover", oldMinNorTo, CDbl(minNorTO)) & " "
            End If
            If oldMinIntTo <> CDbl(minIntTO) Then
                logStr &= GfncOneFieldLog("Min. Int. Turnover", oldMinIntTo, CDbl(minIntTO))
            End If
            If oldIsBothFo <> CBool(isBothFO) Then
                logStr &= GfncOneFieldLog("Consolidate", oldIsBothFo, CDbl(isBothFO))
            End If
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "ACGrpMasterF", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lsqlstr = "update draft_comm_acc_master_d set acc_group_f = '" & ae_group & "' where ae_no_f = '" & ae_no & _
                "' and acc_group_f = '" & preAEGroup & "' and txmonth ='" & txmonth & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) < 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim oldGAE As String = ""
            oldDt = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_acc_master_d where ae_no_f = '" & ae_no & _
                "' and acc_group_f = '" & preAEGroup & "' and txmonth ='" & txmonth & "' ", lstnTrans).Tables(0)
            If oldDt.Rows.Count > 0 Then
                oldGAE = GFncNoNullString(oldDt.Rows(0).Item("acc_group_f")).Trim
            End If
            lsqlstr = "update draft_comm_acc_master_d set acc_group_s = '" & ae_group & "' where ae_no_s = '" & ae_no & _
                "' and acc_group_s = '" & preAEGroup & "' and txmonth ='" & txmonth & "' "
            logStr = GfncOneFieldLog("Account Group Securities", oldGAE, ae_group)
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "ACGrpMasterF", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
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

    Protected Friend Function lFncDeleteAES(ByVal ae_no As String, ByVal ae_group As String, ByVal txmonth As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            lsqlstr = "delete from draft_comm_group_s where ae_no = '" & ae_no & "' and ae_group_s = '" & ae_group & _
                "' and txmonth ='" & txmonth & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(14))
                Return False
            End If
            Dim logStr As String = ""
            logStr = GfncOneFieldLog("AE Group Securities", ae_group)
            If Not GFncFillLog(GStrloginID, "D", GDteTradeDate, "ACGrpMasterS", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            Dim oldAccGP As String = ""
            Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select acc_group_s from draft_comm_acc_master_d where ae_no_s = '" & _
                ae_no & "' and acc_group_s = '" & ae_group & "' and txmonth ='" & txmonth & "' ", lstnTrans).Tables(0)
            If oldDt.Rows.Count > 0 Then
                oldAccGP = GFncNoNullString(oldDt.Rows(0).Item("acc_group_s")).Trim
            End If
            lsqlstr = "update draft_comm_acc_master_d set acc_group_s = '' where ae_no_s = '" & ae_no & "' and acc_group_s = '" & _
                        ae_group & "' and txmonth ='" & txmonth & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(14))
                Return False
            End If
            logStr = GfncOneFieldLog("Account Group Securities", oldAccGP)
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "ACGrpMasterS", ae_no, "", 0, txmonth, logStr, lstnTrans) Then
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

    Protected Friend Function lFncDeleteAEF(ByVal ae_no As String, ByVal ae_group As String, ByVal txmonth As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            lsqlstr = "delete from draft_comm_group_f where ae_no = '" & ae_no & "' and ae_group_f = '" & ae_group & _
                "' and txmonth ='" & txmonth & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) <= 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(14))
                Return False
            End If
            Dim logstr As String = ""
            logstr = GfncOneFieldLog("AE Group Futures", ae_group)
            If Not GFncFillLog(GStrloginID, "D", GDteTradeDate, "ACGrpMasterF", ae_no, "", 0, txmonth, logstr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            Dim oldAccGP As String = ""
            Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select acc_group_f from draft_comm_acc_master_d where ae_no_s = '" & _
                ae_no & "' and acc_group_s = '" & ae_group & "' and txmonth ='" & txmonth & "' ", lstnTrans).Tables(0)
            If oldDt.Rows.Count > 0 Then
                oldAccGP = GFncNoNullString(oldDt.Rows(0).Item("acc_group_f")).Trim
            End If
            lsqlstr = "update draft_comm_acc_master_d set acc_group_f = '' where ae_no_f = '" & ae_no & "' and acc_group_f = '" & _
                ae_group & "' and txmonth ='" & txmonth & "' "
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(14))
                Return False
            End If
            logstr = GfncOneFieldLog("Account Group Futures", oldAccGP, "")
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "ACGrpMasterF", ae_no, "", 0, txmonth, logstr, lstnTrans) Then
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

    Protected Friend Function lFncValidateS(ByVal ae_no As String, ByVal ae_group As String, ByVal txmonth As String) As Boolean
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select * from draft_comm_group_s where ae_no = '" & ae_no & "' and ae_group_s = '" & ae_group & _
            "' and txmonth = '" & txmonth & "' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aem")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function lFncValidateF(ByVal ae_no As String, ByVal ae_group As String, ByVal txmonth As String) As Boolean
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select * from draft_comm_group_f where ae_no = '" & ae_no & "' and ae_group_f = '" & ae_group & _
                    "' and txmonth = '" & txmonth & "' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aem")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

End Class
