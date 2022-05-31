Imports System.Data.SqlClient


Public Class ClsCommAeCommAdj
    Public Fut As String = "F"
    Public Sec As String = "S"

    'Protected Friend Sub GetLatestDate(ByRef yr As String, ByRef month As String)
    '    Dim lstrSQL As String = "Select max(txmonth) from comm_comm_adj"
    '    Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL, "maxDate").Tables(0)
    '    If dt.Rows.Count > 0 Then
    '        If (IsDBNull(dt.Rows(0).Item(0)) = False) Then
    '            yr = CInt(dt.Rows(0).Item(0).ToString.Substring(0, 4)).ToString
    '            month = CInt(dt.Rows(0).Item(0).ToString.Substring(4, 2)).ToString
    '            Return

    '        End If
    '    End If
    '    yr = Now.Year
    '    month = Now.Month - 1
    'End Sub

    Protected Friend Function FncGetAE() As DataSet
        Dim lstrSQL As String = "Select distinct a.ae_no, b.ae_name, a.txmonth, b.infut, b.inSec from draft_comm_ae_comm a " & _
            "left outer join draft_comm_ae_master b on a.ae_no= b.ae_no where 1=1 order by a.ae_no asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "ae")
    End Function

    Protected Friend Function FncEnquiry(ByVal txmonth As String, ByVal ae As String, ByVal FutSec As String) As DataSet
        Dim lstrSQL As String = ""
        If ae.Trim.Length > 0 Then
            lstrSQL += " and upper(a.ae_no) like '%" & ae & "%' "
        End If
        If FutSec <> "" Or FutSec <> Nothing Then
            lstrSQL += " and SecFut='" & FutSec & "' "
        End If
        lstrSQL = "Select  a.ae_no, b.ae_name, a.txmonth, a.cjid, a.adj_amt, a.reason, " & _
            "case a.SecFut when 'S' then 'Securities' when 'F' then 'Futures' end SecFut from draft_comm_comm_adj a " & _
            "left outer join comm_ae_master b on a.ae_no= b.ae_no where a.txmonth = '" & txmonth & "' " & lstrSQL & _
            "order by a.ae_no asc,a.cjid asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "AdjTbl")
    End Function

    Protected Friend Function NewRecord(ByVal ae_no As String, ByVal txmonth As String, ByVal amt As Double, ByVal reason As String, ByVal TradeType As String) As Integer
        Dim lstrSQL As String = "Insert into draft_comm_comm_adj (txmonth, ae_no, adj_amt, reason, SecFut) Values ('" & _
            txmonth & "', '" & ae_no & "', " & amt & ", '" & GFncSqlQuote(reason) & "', '" & TradeType & "')"
        'Dim lstrAEComm As String = "Update comm_ae_comm Set comm_adj=" & amt & " where ae_no ='" & ae_no & "' and txmonth ='" & txmonth & "'"
        Dim NewAmt As Double = 0
        Dim AdjSQL As String = ""
        Dim logstr As String = GfncOneFieldLog("AdjustMent Amt.", amt) & " " & GfncOneFieldLog("Reason", GFncSqlQuote(reason)) & _
            " " & GfncOneFieldLog("Trade Type", TradeType)
        Dim rsid As DataTable = Nothing
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "CommAdj", ae_no, "", 0, txmonth, logstr, MyTrans) Then
                MyTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            NewAmt = GFncRtnDS(GSCnSqlConn, "select isnull(sum(adj_amt),0) as adj_amt from draft_comm_comm_adj where ae_no='" & _
                ae_no & "' and txmonth='" & txmonth & "' and SecFut='" & TradeType & "'", MyTrans).Tables(0).Rows(0).Item(0)
            Dim oldDt As DataTable
            Dim oldAdj As Double = 0
            If TradeType = Sec Then
                AdjSQL = "Update draft_comm_ae_comm Set comm_adj_s=" & NewAmt & " where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'"
                oldDt = GFncRtnDS(GSCnSqlConn, "select comm_adj_s from draft_comm_ae_comm where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'", MyTrans).Tables(0)
                If oldDt.Rows.Count > 0 Then
                    oldADj = GFncNoNullValue(oldDt.Rows(0).Item("comm_adj_s"))
                End If
                logstr = GfncOneFieldLog("Commission Adjustment Securities", oldAdj, NewAmt)
            Else
                AdjSQL = "Update draft_comm_ae_comm Set comm_adj_f=" & NewAmt & " where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'"
                oldDt = GFncRtnDS(GSCnSqlConn, "select comm_adj_f from draft_comm_ae_comm where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'", MyTrans).Tables(0)
                If oldDt.Rows.Count > 0 Then
                    oldADj = GFncNoNullValue(oldDt.Rows(0).Item("comm_adj_f"))
                End If
                logstr = GfncOneFieldLog("Commission Adjustment Futures", oldAdj, NewAmt)
            End If
            GFncRunSQL(GSCnSqlConn, MyTrans, AdjSQL, 0)
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "CommAdj", ae_no, "", 0, txmonth, logstr, MyTrans) Then
                MyTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            rsid = GFncRtnDS(GSCnSqlConn, "Select max(cjid) from draft_comm_comm_adj", MyTrans).Tables(0)
            MyTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return GFncNoNullString(rsid.Rows(0).Item(0))
    End Function

    Protected Friend Function EditRecord(ByVal ae_no As String, ByVal txmonth As String, ByVal id As String, ByVal amt As Double, ByVal reason As String, ByVal TradeType As String) As Boolean
        Dim lstrSQL As String = "Update draft_comm_comm_adj Set adj_amt = " & amt & ", reason='" & GFncSqlQuote(reason) & _
            "' where cjid =" & id
        Dim AdjSQL As String = ""
        'Dim lstrAEComm As String = "Update comm_ae_comm Set comm_adj=" & amt & " where ae_no ='" & ae_no & "' and txmonth ='" & txmonth & "'"
        Dim NewAmt As Double = 0
        Dim logstr As String = ""
        Dim oldAmt As Double = 0
        Dim oldReason As String = ""
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_comm_adj where cjid =" & id).Tables(0)
        If oldDt.Rows.Count > 0 Then
            oldAmt = GFncNoNullValue(oldDt.Rows(0).Item("adj_amt"))
            oldReason = GFncNoNullString(oldDt.Rows(0).Item("reason")).Trim
        End If
        If oldAmt <> amt Then
            logstr = GfncOneFieldLog("Adjustment Amount", oldAmt, amt) & " "
        End If
        If oldReason.Trim <> reason.Trim Then
            logstr &= GfncOneFieldLog("Adjustment Amount", oldReason.Trim, reason.Trim)
        End If
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "CommAdj", ae_no, "", id, txmonth, logstr, MyTrans) Then
                MyTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            NewAmt = GFncRtnDS(GSCnSqlConn, "select isnull(sum(adj_amt),0) as adj_amt from draft_comm_comm_adj where ae_no='" & _
                ae_no & "' and txmonth='" & txmonth & "' and SecFut='" & TradeType & "'", MyTrans).Tables(0).Rows(0).Item(0)
            oldAmt = 0
            If TradeType = Sec Then
                AdjSQL = "Update draft_comm_ae_comm Set comm_adj_s=" & NewAmt & " where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'"
                oldDt = GFncRtnDS(GSCnSqlConn, "select comm_adj_s from draft_comm_ae_comm where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'", MyTrans).Tables(0)
                If oldDt.Rows.Count > 0 Then
                    oldAmt = GFncNoNullValue(oldDt.Rows(0).Item("comm_adj_s"))
                End If
                logstr = GfncOneFieldLog("Commission Adjustment Securities", oldAmt, NewAmt)
            Else
                AdjSQL = "Update draft_comm_ae_comm Set comm_adj_f=" & NewAmt & " where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'"
                oldDt = GFncRtnDS(GSCnSqlConn, "select comm_adj_f from draft_comm_ae_comm where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'", MyTrans).Tables(0)
                If oldDt.Rows.Count > 0 Then
                    oldAmt = GFncNoNullValue(oldDt.Rows(0).Item("comm_adj_f"))
                End If
                logstr = GfncOneFieldLog("Commission Adjustment Futures", oldAmt, NewAmt)
            End If
            GFncRunSQL(GSCnSqlConn, MyTrans, AdjSQL, 0)
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "CommAdj", ae_no, "", 0, txmonth, logstr, MyTrans) Then
                MyTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            MyTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function DelRecord(ByVal ae_no As String, ByVal txmonth As String, ByVal id As Integer, ByVal TradeType As String, ByVal type As String) As Boolean
        Dim lstrSQL As String = "Delete from draft_comm_comm_adj where cjid =" & id
        Dim NewAmt As Double = 0
        'Dim lstrAEComm As String = "Update comm_ae_comm Set comm_adj=0 where ae_no ='" & ae_no & "' and txmonth ='" & txmonth & "'"
        Dim AdjSQL As String = ""
        Dim logstr As String = GfncOneFieldLog("Commission Type", type)
        Dim oldDt As DataTable
        Dim oldAmt As Double = 0
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            If Not GFncFillLog(GStrloginID, "D", GDteTradeDate, "CommAdj", ae_no, "", id, txmonth, logstr, MyTrans) Then
                MyTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            NewAmt = GFncRtnDS(GSCnSqlConn, "select isnull(sum(adj_amt),0) as adj_amt from draft_comm_comm_adj where ae_no='" & _
                ae_no & "' and txmonth='" & txmonth & "' and SecFut='" & TradeType & "'", MyTrans).Tables(0).Rows(0).Item(0)
            If TradeType = Sec Then
                AdjSQL = "Update draft_comm_ae_comm Set comm_adj_s=" & NewAmt & " where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'"
                oldDt = GFncRtnDS(GSCnSqlConn, "select comm_adj_s from draft_comm_ae_comm where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'", MyTrans).Tables(0)
                If oldDt.Rows.Count > 0 Then
                    oldAmt = GFncNoNullValue(oldDt.Rows(0).Item("comm_adj_s"))
                End If
                logstr = GfncOneFieldLog("Commission Adjustment Securities", oldAmt, NewAmt)
            Else
                AdjSQL = "Update draft_comm_ae_comm Set comm_adj_f=" & NewAmt & " where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'"
                oldDt = GFncRtnDS(GSCnSqlConn, "select comm_adj_f from draft_comm_ae_comm where ae_no ='" & ae_no & _
                    "' and txmonth ='" & txmonth & "'", MyTrans).Tables(0)
                If oldDt.Rows.Count > 0 Then
                    oldAmt = GFncNoNullValue(oldDt.Rows(0).Item("comm_adj_f"))
                End If
                logstr = GfncOneFieldLog("Commission Adjustment Futures", oldAmt, NewAmt)
            End If
            GFncRunSQL(GSCnSqlConn, MyTrans, AdjSQL, 0)
            If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "CommAdj", ae_no, "", 0, txmonth, logstr, MyTrans) Then
                MyTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            'GFncRunSQL(GSCnSqlConn, MyTrans, lstrAEComm, 0)
            MyTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(13))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function ValidateExist(ByVal id As String) As Boolean
        Dim lstrSQL As String = "Select * from draft_comm_comm_adj where cjid =" & id
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    'Protected Friend Function ValidateDuplicate(ByVal condition As String) As Boolean
    '    Dim lstrSQL As String = "Select * from comm_comm_adj  where 1=1 " & condition
    '    Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    '    If dt.Rows.Count > 0 Then
    '        Return True
    '    Else
    '        Return False
    '    End If
    'End Function

    Protected Friend Function ValidateAEComm(ByVal ae_no As String, ByVal txmonth As String) As Boolean
        Dim lstrSQL As String = "Select * from draft_comm_ae_comm where ae_no ='" & ae_no & "' and txmonth ='" & txmonth & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
