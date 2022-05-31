Imports System.Data.SqlClient

Public Class ClsTransAdjF

    'Protected Friend Function GetNewOID()
    '    Dim query As String = "select isnull(max(oid),0) as oid from comm_adj_f where adj_action='A'"
    '    Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
    '    If dt.Rows.Count > 0 Then
    '        Return dt.Rows(0).Item(0) + 1
    '    Else
    '        Return 1
    '    End If
    'End Function

    Protected Friend Function ModifyRecord(ByVal condition As String, ByVal id As String, ByVal type As String, ByVal log As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim query As String = "Update draft_comm_adj_f Set " & condition & " where recordID = " & id
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, " & _
            "D_TXMONTH, D_LOG) values (" & log & ")"
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, query, 0)
            GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(8))
            Return True
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                Return False
            End If
        End Try
    End Function

    Protected Friend Function AddNewRecord(ByVal condition As String, ByVal log As String) As Integer
        Dim MyTrans As SqlTransaction = Nothing
        Dim dt As DataTable
        Dim query As String = " Insert into draft_comm_adj_f (txmonth, aeno, aename, accno, accname1, accname2, commod, mth, " & _
            "call_put, strike, s_price_str, day_dd, night_dd, tg_dd, commission_dd, exchange_fee_dd, ae_rebate_dd, " & _
            "commission_mm, day_commission, night_commission, exchange_fee_mm, ae_rebate_mm, day_mm, night_mm, tg_mm, " & _
            "marketname, ccy, lastupddate, lastupduser, oid, adj_action, tradetype) Values (" & condition & ")"
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_TXMONTH, D_LOG, " & _
            "D_OID) values (" & log
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, query, 0)
            dt = GFncRtnDS(GSCnSqlConn, "select max(recordID) as MID from draft_comm_adj_f ", MyTrans).Tables(0)
            sql_log += " '" & dt.Rows(0).Item(0) & "' )"
            GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(8))
            Return dt.Rows(0).Item(0)
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                Return 0
            End If
        End Try
    End Function

    'Protected Friend Function GetRestoreFlag(ByVal id As String) As String
    '    Dim recTypeFlag As String = ""
    '    Dim query As String = " select distinct D_action from logtbl where D_type ='TradeAdjF' and D_oid ='" & id & "'"
    '    Dim ReStoreDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
    '    If ReStoreDT.Rows.Count <= 0 Then
    '        Return ""
    '    End If
    '    For Each dr As DataRow In ReStoreDT.Rows
    '        If dr.Item("D_action") = "M" Then
    '            recTypeFlag = "M"
    '            Exit For
    '        End If
    '    Next
    '    Return recTypeFlag
    'End Function

    Protected Friend Function RestoreDel(ByVal type As String, ByVal id As String, ByVal log As String) As Boolean
        Dim query As String
        Dim MyTrans As SqlTransaction = Nothing
        query = "Update draft_comm_adj_f Set adj_action='" & type & "' where recordID =" & id
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, " & _
            "D_TXMONTH, D_LOG) values (" & log & ")"
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, query, 0)
            GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(8))
            Return True
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                Return False
            End If
        End Try
    End Function

    Protected Friend Function LabeledDel(ByVal id As String, ByVal log As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim query As String = "Update draft_comm_adj_f Set adj_action='D' where recordID =" & id
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, " & _
            "D_TXMONTH, D_LOG) values (" & log & ")"
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, query, 0)
            GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(8))
            Return True
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                Return False
            End If
        End Try
    End Function

    Protected Friend Function PhysicalDel(ByVal id As String, ByVal log As String) As Boolean
        If id = Nothing Or log = Nothing Then
            Return False
        End If
        Dim sql As String = "Delete from draft_comm_adj_f where recordID= " & id
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, " & _
            "D_TXMONTH, D_LOG) values (" & log & ")"
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sql, 0)
            GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function Search(ByVal AdjCondition As String, ByVal State As String) As DataTable
        Dim query As String
        Dim TradeDT As New DataTable
        Dim AdjDr() As DataRow
        Dim TradeDr As DataRow
        Dim AeDr() As DataRow
        Dim AcDr() As DataRow
        InitSearchDT(TradeDT)
        query = "select * from draft_comm_adj_f where 1=1 " & AdjCondition & " order by txmonth desc, aeno asc, recordID asc"
        Dim AdjDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select * from draft_comm_trade_f where 1=1 " & AdjCondition & " order by txmonth desc, aeno asc, oid asc"
        Dim OrgDt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select ae_no, isnull(ae_name, isnull(ae_name_f, '')) as aename from draft_comm_ae_master"
        Dim AeDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select acc_no, isnull(acc_name_f, '') as acname from draft_comm_acc_master"
        Dim AcDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        Select Case State
            Case "All"
                For Each dr As DataRow In OrgDt.Rows
                    AdjDr = AdjDT.Select("oid =" & dr.Item("oid"))
                    If AdjDr.Length > 0 Then
                        If GFncNoNullString(AdjDr(0).Item("adj_action")) = "M" Then
                            TradeDr = TradeDT.NewRow
                            TradeDr.Item("adj_action") = "Adjusted"
                            TradeDr.Item("txmonth") = AdjDr(0).Item("txmonth").ToString.Trim
                            TradeDr.Item("aeno") = AdjDr(0).Item("aeno").ToString.Trim
                            AeDr = AeDT.Select("ae_no='" & TradeDr.Item("aeno") & "'")
                            If AeDr.Length > 0 Then
                                TradeDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                            Else
                                TradeDr.Item("aename") = AdjDr(0).Item("aename").ToString.Trim
                            End If
                            TradeDr.Item("accno") = AdjDr(0).Item("accno").ToString.Trim
                            AcDr = AcDT.Select("acc_no='" & TradeDr.Item("accno") & "'")
                            If AcDr.Length > 0 Then
                                TradeDr.Item("accname1") = AcDr(0).Item("acname").ToString.Trim
                            Else
                                TradeDr.Item("accname1") = AdjDr(0).Item("accname1").ToString.Trim
                            End If
                            TradeDr.Item("accname2") = AdjDr(0).Item("accname2").ToString.Trim
                            TradeDr.Item("commod") = AdjDr(0).Item("commod").ToString.Trim
                            TradeDr.Item("mth") = AdjDr(0).Item("mth").ToString.Trim
                            TradeDr.Item("call_put") = ReturnCallPutString(AdjDr(0).Item("call_put").ToString.Trim)
                            TradeDr.Item("strike") = AdjDr(0).Item("strike").ToString.Trim
                            TradeDr.Item("s_price_str") = AdjDr(0).Item("s_price_str").ToString.Trim
                            TradeDr.Item("commission_mm") = AdjDr(0).Item("commission_mm").ToString.Trim
                            TradeDr.Item("day_commission") = GFncNoNullValue(AdjDr(0).Item("day_commission"))
                            TradeDr.Item("night_commission") = GFncNoNullValue(AdjDr(0).Item("night_commission"))
                            TradeDr.Item("exchange_fee_mm") = AdjDr(0).Item("exchange_fee_mm").ToString.Trim
                            TradeDr.Item("ae_rebate_mm") = AdjDr(0).Item("ae_rebate_mm").ToString.Trim
                            TradeDr.Item("day_mm") = AdjDr(0).Item("day_mm").ToString.Trim
                            TradeDr.Item("night_mm") = AdjDr(0).Item("night_mm").ToString.Trim
                            TradeDr.Item("tg_mm") = AdjDr(0).Item("tg_mm").ToString.Trim
                            TradeDr.Item("ccy") = AdjDr(0).Item("ccy").ToString.Trim
                            TradeDr.Item("marketname") = AdjDr(0).Item("marketname").ToString.Trim
                            TradeDr.Item("oid") = AdjDr(0).Item("oid").ToString.Trim
                            TradeDr.Item("commission_dd") = AdjDr(0).Item("commission_dd").ToString.Trim
                            TradeDr.Item("exchange_fee_dd") = AdjDr(0).Item("exchange_fee_dd").ToString.Trim
                            TradeDr.Item("ae_rebate_dd") = AdjDr(0).Item("ae_rebate_dd").ToString.Trim
                            TradeDr.Item("day_dd") = AdjDr(0).Item("day_dd").ToString.Trim
                            TradeDr.Item("night_dd") = AdjDr(0).Item("night_dd").ToString.Trim
                            TradeDr.Item("tg_dd") = AdjDr(0).Item("tg_dd").ToString.Trim
                            TradeDr.Item("tradetype") = GetTypeDesc(GFncNoNullString(AdjDr(0).Item("tradetype")))
                            TradeDr.Item("recordID") = AdjDr(0).Item("recordID")
                            TradeDT.Rows.Add(TradeDr)
                        End If
                    Else
                        TradeDr = TradeDT.NewRow
                        TradeDr.Item("txmonth") = dr.Item("txmonth").ToString.Trim
                        TradeDr.Item("aeno") = dr.Item("aeno").ToString.Trim
                        AeDr = AeDT.Select("ae_no='" & TradeDr.Item("aeno") & "'")
                        If AeDr.Length > 0 Then
                            TradeDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                        Else
                            TradeDr.Item("aename") = dr.Item("aename").ToString.Trim
                        End If
                        TradeDr.Item("accno") = dr.Item("accno").ToString.Trim
                        AcDr = AcDT.Select("acc_no='" & TradeDr.Item("accno") & "'")
                        If AcDr.Length > 0 Then
                            TradeDr.Item("accname1") = AcDr(0).Item("acname").ToString.Trim
                        Else

                            TradeDr.Item("accname1") = dr.Item("accname1").ToString.Trim
                        End If
                        TradeDr.Item("accname2") = dr.Item("accname2").ToString.Trim
                        TradeDr.Item("commod") = dr.Item("commod").ToString.Trim
                        TradeDr.Item("mth") = dr.Item("mth").ToString.Trim
                        TradeDr.Item("call_put") = ReturnCallPutString(dr.Item("call_put").ToString.Trim)
                        TradeDr.Item("strike") = dr.Item("strike").ToString.Trim
                        TradeDr.Item("s_price_str") = dr.Item("s_price_str").ToString.Trim
                        TradeDr.Item("commission_mm") = dr.Item("commission_mm").ToString.Trim
                        TradeDr.Item("day_commission") = dr.Item("day_commission").ToString.Trim
                        TradeDr.Item("night_commission") = dr.Item("night_commission").ToString.Trim
                        TradeDr.Item("exchange_fee_mm") = dr.Item("exchange_fee_mm").ToString.Trim
                        TradeDr.Item("ae_rebate_mm") = dr.Item("ae_rebate_mm").ToString.Trim
                        TradeDr.Item("day_mm") = dr.Item("day_mm").ToString.Trim
                        TradeDr.Item("night_mm") = dr.Item("night_mm").ToString.Trim
                        TradeDr.Item("tg_mm") = dr.Item("tg_mm").ToString.Trim
                        TradeDr.Item("ccy") = dr.Item("ccy").ToString.Trim
                        TradeDr.Item("marketname") = dr.Item("marketname").ToString.Trim
                        TradeDr.Item("oid") = dr.Item("oid").ToString.Trim
                        TradeDr.Item("commission_dd") = dr.Item("commission_dd").ToString.Trim
                        TradeDr.Item("exchange_fee_dd") = dr.Item("exchange_fee_dd").ToString.Trim
                        TradeDr.Item("ae_rebate_dd") = dr.Item("ae_rebate_dd").ToString.Trim
                        TradeDr.Item("day_dd") = dr.Item("day_dd").ToString.Trim
                        TradeDr.Item("night_dd") = dr.Item("night_dd").ToString.Trim
                        TradeDr.Item("tg_dd") = dr.Item("tg_dd").ToString.Trim
                        TradeDr.Item("tradetype") = GetTypeDesc(GFncNoNullString(dr.Item("tradetype")))
                        TradeDr.Item("recordID") = -1
                        TradeDT.Rows.Add(TradeDr)
                    End If
                Next
                AdjDr = AdjDT.Select("oid =0")
                For Each dr As DataRow In AdjDr
                    TradeDr = TradeDT.NewRow
                    If dr.Item("adj_action") = "A" Then
                        TradeDr.Item("adj_action") = "New"
                    End If
                    TradeDr.Item("txmonth") = dr.Item("txmonth").ToString.Trim
                    TradeDr.Item("aeno") = dr.Item("aeno").ToString.Trim
                    AeDr = AeDT.Select("ae_no='" & TradeDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        TradeDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        TradeDr.Item("aename") = dr.Item("aename").ToString.Trim
                    End If

                    TradeDr.Item("accno") = dr.Item("accno").ToString.Trim
                    AcDr = AcDT.Select("acc_no='" & TradeDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        TradeDr.Item("accname1") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        TradeDr.Item("accname1") = dr.Item("accname1").ToString.Trim
                    End If
                    TradeDr.Item("accname2") = dr.Item("accname2").ToString.Trim
                    TradeDr.Item("commod") = dr.Item("commod").ToString.Trim
                    TradeDr.Item("mth") = dr.Item("mth").ToString.Trim
                    TradeDr.Item("call_put") = ReturnCallPutString(dr.Item("call_put").ToString.Trim)
                    TradeDr.Item("strike") = dr.Item("strike").ToString.Trim
                    TradeDr.Item("s_price_str") = dr.Item("s_price_str").ToString.Trim
                    TradeDr.Item("commission_mm") = dr.Item("commission_mm").ToString.Trim
                    TradeDr.Item("day_commission") = GFncNoNullValue(dr.Item("day_commission"))
                    TradeDr.Item("night_commission") = GFncNoNullValue(dr.Item("night_commission"))
                    TradeDr.Item("exchange_fee_mm") = dr.Item("exchange_fee_mm").ToString.Trim
                    TradeDr.Item("ae_rebate_mm") = dr.Item("ae_rebate_mm").ToString.Trim
                    TradeDr.Item("day_mm") = dr.Item("day_mm").ToString.Trim
                    TradeDr.Item("night_mm") = dr.Item("night_mm").ToString.Trim
                    TradeDr.Item("tg_mm") = dr.Item("tg_mm").ToString.Trim
                    TradeDr.Item("ccy") = dr.Item("ccy").ToString.Trim
                    TradeDr.Item("marketname") = dr.Item("marketname").ToString.Trim
                    TradeDr.Item("oid") = dr.Item("oid").ToString.Trim
                    TradeDr.Item("commission_dd") = dr.Item("commission_dd").ToString.Trim
                    TradeDr.Item("exchange_fee_dd") = dr.Item("exchange_fee_dd").ToString.Trim
                    TradeDr.Item("ae_rebate_dd") = dr.Item("ae_rebate_dd").ToString.Trim
                    TradeDr.Item("day_dd") = dr.Item("day_dd").ToString.Trim
                    TradeDr.Item("night_dd") = dr.Item("night_dd").ToString.Trim
                    TradeDr.Item("tg_dd") = dr.Item("tg_dd").ToString.Trim
                    TradeDr.Item("tradetype") = GetTypeDesc(GFncNoNullString(dr.Item("tradetype")))
                    TradeDr.Item("recordID") = dr.Item("recordID").ToString.Trim
                    TradeDT.Rows.Add(TradeDr)
                Next
            Case "Adjusted"
                AdjDr = AdjDT.Select("adj_action <>'D'")
                For Each dr As DataRow In AdjDr
                    TradeDr = TradeDT.NewRow
                    If dr.Item("adj_action") = "A" Then
                        TradeDr.Item("adj_action") = "New"
                    End If
                    If dr.Item("adj_action") = "M" Then
                        TradeDr.Item("adj_action") = "Adjusted"
                    End If
                    TradeDr.Item("txmonth") = dr.Item("txmonth").ToString.Trim
                    TradeDr.Item("aeno") = dr.Item("aeno").ToString.Trim
                    AeDr = AeDT.Select("ae_no='" & TradeDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        TradeDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        TradeDr.Item("aename") = dr.Item("aename").ToString.Trim
                    End If
                    TradeDr.Item("accno") = dr.Item("accno").ToString.Trim
                    AcDr = AcDT.Select("acc_no='" & TradeDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        TradeDr.Item("accname1") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        TradeDr.Item("accname1") = dr.Item("accname1").ToString.Trim
                    End If
                    TradeDr.Item("accname2") = dr.Item("accname2").ToString.Trim
                    TradeDr.Item("commod") = dr.Item("commod").ToString.Trim
                    TradeDr.Item("mth") = dr.Item("mth").ToString.Trim
                    TradeDr.Item("call_put") = ReturnCallPutString(dr.Item("call_put").ToString.Trim)
                    TradeDr.Item("strike") = dr.Item("strike").ToString.Trim
                    TradeDr.Item("s_price_str") = dr.Item("s_price_str").ToString.Trim
                    TradeDr.Item("commission_mm") = dr.Item("commission_mm").ToString.Trim
                    TradeDr.Item("day_commission") = dr.Item("day_commission").ToString.Trim
                    TradeDr.Item("night_commission") = dr.Item("night_commission").ToString.Trim
                    TradeDr.Item("exchange_fee_mm") = dr.Item("exchange_fee_mm").ToString.Trim
                    TradeDr.Item("ae_rebate_mm") = dr.Item("ae_rebate_mm").ToString.Trim
                    TradeDr.Item("day_mm") = dr.Item("day_mm").ToString.Trim
                    TradeDr.Item("night_mm") = dr.Item("night_mm").ToString.Trim
                    TradeDr.Item("tg_mm") = dr.Item("tg_mm").ToString.Trim
                    TradeDr.Item("ccy") = dr.Item("ccy").ToString.Trim
                    TradeDr.Item("marketname") = dr.Item("marketname").ToString.Trim
                    TradeDr.Item("oid") = dr.Item("oid").ToString.Trim
                    TradeDr.Item("commission_dd") = dr.Item("commission_dd").ToString.Trim
                    TradeDr.Item("exchange_fee_dd") = dr.Item("exchange_fee_dd").ToString.Trim
                    TradeDr.Item("ae_rebate_dd") = dr.Item("ae_rebate_dd").ToString.Trim
                    TradeDr.Item("day_dd") = dr.Item("day_dd").ToString.Trim
                    TradeDr.Item("night_dd") = dr.Item("night_dd").ToString.Trim
                    TradeDr.Item("tg_dd") = dr.Item("tg_dd").ToString.Trim
                    TradeDr.Item("tradetype") = GetTypeDesc(GFncNoNullValue(dr.Item("tradetype")))
                    TradeDr.Item("recordID") = dr.Item("recordID").ToString.Trim
                    TradeDT.Rows.Add(TradeDr)
                Next
            Case "Deleted"
                AdjDr = AdjDT.Select("adj_action='D'")
                For Each dr As DataRow In AdjDr
                    TradeDr = TradeDT.NewRow
                    TradeDr.Item("adj_action") = "Deleted"
                    TradeDr.Item("txmonth") = dr.Item("txmonth").ToString.Trim
                    TradeDr.Item("aeno") = dr.Item("aeno").ToString.Trim
                    AeDr = AeDT.Select("ae_no='" & TradeDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        TradeDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        TradeDr.Item("aename") = dr.Item("aename").ToString.Trim
                    End If
                    TradeDr.Item("accno") = dr.Item("accno").ToString.Trim
                    AcDr = AcDT.Select("acc_no='" & TradeDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        TradeDr.Item("accname1") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        TradeDr.Item("accname1") = dr.Item("accname1").ToString.Trim
                    End If
                    TradeDr.Item("accname2") = dr.Item("accname2").ToString.Trim
                    TradeDr.Item("commod") = dr.Item("commod").ToString.Trim
                    TradeDr.Item("mth") = dr.Item("mth").ToString.Trim
                    TradeDr.Item("call_put") = ReturnCallPutString(dr.Item("call_put").ToString.Trim)
                    TradeDr.Item("strike") = dr.Item("strike").ToString.Trim
                    TradeDr.Item("s_price_str") = dr.Item("s_price_str").ToString.Trim
                    TradeDr.Item("commission_mm") = dr.Item("commission_mm").ToString.Trim
                    TradeDr.Item("day_commission") = dr.Item("day_commission").ToString.Trim
                    TradeDr.Item("night_commission") = dr.Item("night_commission").ToString.Trim
                    TradeDr.Item("exchange_fee_mm") = dr.Item("exchange_fee_mm").ToString.Trim
                    TradeDr.Item("ae_rebate_mm") = dr.Item("ae_rebate_mm").ToString.Trim
                    TradeDr.Item("day_mm") = dr.Item("day_mm").ToString.Trim
                    TradeDr.Item("night_mm") = dr.Item("night_mm").ToString.Trim
                    TradeDr.Item("tg_mm") = dr.Item("tg_mm").ToString.Trim
                    TradeDr.Item("ccy") = dr.Item("ccy").ToString.Trim
                    TradeDr.Item("marketname") = dr.Item("marketname").ToString.Trim
                    TradeDr.Item("oid") = dr.Item("oid").ToString.Trim
                    TradeDr.Item("commission_dd") = dr.Item("commission_dd").ToString.Trim
                    TradeDr.Item("exchange_fee_dd") = dr.Item("exchange_fee_dd").ToString.Trim
                    TradeDr.Item("ae_rebate_dd") = dr.Item("ae_rebate_dd").ToString.Trim
                    TradeDr.Item("day_dd") = dr.Item("day_dd").ToString.Trim
                    TradeDr.Item("night_dd") = dr.Item("night_dd").ToString.Trim
                    TradeDr.Item("tg_dd") = dr.Item("tg_dd").ToString.Trim
                    TradeDr.Item("tradetype") = GetTypeDesc(GFncNoNullString(dr.Item("tradetype")))
                    TradeDr.Item("recordID") = dr.Item("recordID").ToString.Trim
                    TradeDT.Rows.Add(TradeDr)
                Next
        End Select
        Return TradeDT
    End Function

    Private Sub InitSearchDT(ByRef dt As DataTable)
        Dim Column As DataColumn
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "adj_action"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "txmonth"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aeno"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aename"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accno"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accname1"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accname2"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "commod"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "mth"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "call_put"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "strike"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "s_price_str"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "commission_mm"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "exchange_fee_mm"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "ae_rebate_mm"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_mm"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_mm"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "tg_mm"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ccy"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "marketname"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "oid"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "commission_dd"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "exchange_fee_dd"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "ae_rebate_dd"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_dd"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_dd"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "tg_dd"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "recordID"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "day_commission"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "night_commission"
        dt.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "tradetype"
        dt.Columns.Add(Column)
    End Sub

    Protected Friend Function GetAction(ByVal oid As String, ByVal Action As String) As String
        Dim query As String = ""
        Select Case Action
            Case "New"
                query = "Select case when adj_action='A' then 'New' else '' end adj_action, oid from draft_comm_adj_f " & _
                    "where oid=" & oid & " and adj_action='A'"
            Case Else
                query = "select case when adj_action='A' then 'New' when adj_action='D' then 'Deleted' " & _
                    "when adj_action='M' then 'Adjusted' else 'unAdj' end adj_action, oid from draft_comm_adj_f " & _
                    "where adj_action <> 'A' and oid=" & oid & " and exists " & _
                    "(select * from draft_comm_trade_f a inner join draft_comm_adj_f b on a.oid=b.oid " & _
                    "where b.adj_action<>'A') union " & _
                    "select adj_action='unAdj', oid from draft_comm_trade_f where oid=" & oid & " and not exists " & _
                    "(select * from draft_comm_adj_f where oid='" & oid & "' and adj_action<>'A')"
        End Select
        Dim DT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If DT.Rows.Count > 0 Then
            Return GFncNoNullString(DT.Rows(0).Item("adj_action"))
        Else
            Return ""
        End If
    End Function

    Private Function ReturnCallPutString(ByVal inCall As String) As String
        Select Case inCall
            Case "2"
                Return "Call"
            Case "1"
                Return "Put"
            Case Else
                Return ""
        End Select
    End Function

    Protected Friend Sub getLastTradeMonth(ByRef inYr As String, ByRef inMonth As String)
        Dim sql As String = "select max(a.txmonth) as txmonth from (select max(txmonth) as txmonth from draft_comm_adj_f " & _
            "where adj_action <>'D' union select max(txmonth) as txmonth from draft_comm_trade_f) a "
        Dim monthYr As DataTable = GFncRtnDS(GSCnSqlConn, sql).Tables(0)
        If monthYr.Rows.Count > 0 Then
            inYr = monthYr.Rows(0).Item(0).ToString.Substring(0, 4)
            inMonth = Val(monthYr.Rows(0).Item(0).ToString.Substring(4, 2))
        Else
            inYr = Now.Year
            inMonth = Now.Month
        End If
    End Sub

    Protected Friend Function GetAeCode() As DataTable
        Dim query As String = "select distinct ae_no from draft_comm_ae_master where ae_status='A' and inFut=1 order by ae_no asc"
        Return GFncRtnDS(GSCnSqlConn, query).Tables(0)
    End Function

    Protected Friend Function GetAeName(ByVal Code As String) As String
        If Code.Length > 0 Then
            Dim query As String = "select isnull(ae_name, isnull(ae_name_f, '')) as ae_name_s from draft_comm_ae_master " & _
                "where ae_no ='" & Code & "'"
            Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
            If dt.Rows.Count > 0 Then
                Return GFncNoNullString(dt.Rows(0).Item(0).ToString.Trim)
            Else
                Return ""
            End If
        End If
        Return ""
    End Function

    Protected Friend Function GetAcCode() As DataTable
        Dim query As String = "select distinct acc_no from draft_comm_acc_master where inFut=1 order by acc_no asc"
        Return GFncRtnDS(GSCnSqlConn, query).Tables(0)
    End Function

    Protected Friend Function GetAcName(ByVal Code As String) As String
        If Code.Length > 0 Then
            Dim query As String = "select isnull(acc_name, isnull(acc_name_s,'')) as ac_name_s from draft_comm_acc_master " & _
                "where acc_no ='" & Code & "'"
            Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
            If dt.Rows.Count > 0 Then
                Return GFncNoNullString(dt.Rows(0).Item(0).ToString.Trim)
            Else
                Return ""
            End If
        End If
        Return ""
    End Function
    'Protected Friend Function GetNewVal(ByVal oid As Integer, ByVal type As String) As DataTable
    '    Dim query as string
    '    Dim dt As New DataTable
    '    Dim AdjDT As DataTable
    '    InitSearchDT(dt)
    '    Select Case type
    '        Case "New"
    '            query = "select * from comm_adj_f where oid=" & oid & " and adj_action='A' order by txmonth desc, aeno asc, oid asc"
    '            AdjDT = GFncRtnDS(GSCnSqlConn, query).Tables(0)
    '        Case Else
    '            query = "select * from comm_trade_f where oid=" & oid & " and not exists (select * from comm_adj_f where oid=" & oid & " and adj_action<>'A')"
    '            AdjDT = GFncRtnDS(GSCnSqlConn, query).Tables(0)
    '        Case "Deleted"


    '    End Select
    '    Return dt
    'End Function
    Protected Friend Function GetNewestVal(ByVal ID As String, ByVal RecordID As Integer) As DataTable
        Dim DT As New DataTable
        Dim AdjDT As DataTable
        InitSearchDT(DT)
        If RecordID > 0 Then
            AdjDT = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_adj_f where recordID=" & RecordID).Tables(0)
            If AdjDT.Rows.Count > 0 Then
                Dim dr As DataRow = DT.NewRow
                Select Case AdjDT.Rows(0).Item("adj_action").ToString.Trim
                    Case "A"
                        dr.Item("adj_action") = "New"
                    Case "M"
                        dr.Item("adj_action") = "Adjusted"
                    Case "D"
                        dr.Item("adj_action") = "Deleted"
                    Case Else
                        dr.Item("adj_action") = ""
                End Select
                dr.Item("txmonth") = AdjDT.Rows(0).Item("txmonth").ToString.Trim
                dr.Item("aeno") = AdjDT.Rows(0).Item("aeno").ToString.Trim
                dr.Item("aename") = AdjDT.Rows(0).Item("aename").ToString.Trim
                dr.Item("accno") = AdjDT.Rows(0).Item("accno").ToString.Trim
                dr.Item("accname1") = AdjDT.Rows(0).Item("accname1").ToString.Trim
                dr.Item("accname2") = AdjDT.Rows(0).Item("accname2").ToString.Trim
                dr.Item("commod") = AdjDT.Rows(0).Item("commod").ToString.Trim
                dr.Item("mth") = AdjDT.Rows(0).Item("mth").ToString.Trim
                dr.Item("call_put") = ReturnCallPutString(AdjDT.Rows(0).Item("call_put").ToString.Trim)
                dr.Item("strike") = AdjDT.Rows(0).Item("strike").ToString.Trim
                dr.Item("s_price_str") = AdjDT.Rows(0).Item("s_price_str").ToString.Trim
                dr.Item("commission_mm") = AdjDT.Rows(0).Item("commission_mm").ToString.Trim
                dr.Item("exchange_fee_mm") = AdjDT.Rows(0).Item("exchange_fee_mm").ToString.Trim
                dr.Item("ae_rebate_mm") = AdjDT.Rows(0).Item("ae_rebate_mm").ToString.Trim
                dr.Item("day_mm") = AdjDT.Rows(0).Item("day_mm").ToString.Trim
                dr.Item("night_mm") = AdjDT.Rows(0).Item("night_mm").ToString.Trim
                dr.Item("tg_mm") = AdjDT.Rows(0).Item("tg_mm").ToString.Trim
                dr.Item("ccy") = AdjDT.Rows(0).Item("ccy").ToString.Trim
                dr.Item("marketname") = AdjDT.Rows(0).Item("marketname").ToString.Trim
                dr.Item("oid") = AdjDT.Rows(0).Item("oid").ToString.Trim
                dr.Item("commission_dd") = AdjDT.Rows(0).Item("commission_dd").ToString.Trim
                dr.Item("exchange_fee_dd") = AdjDT.Rows(0).Item("exchange_fee_dd").ToString.Trim
                dr.Item("ae_rebate_dd") = AdjDT.Rows(0).Item("ae_rebate_dd").ToString.Trim
                dr.Item("day_dd") = AdjDT.Rows(0).Item("day_dd").ToString.Trim
                dr.Item("night_dd") = AdjDT.Rows(0).Item("night_dd").ToString.Trim
                dr.Item("tg_dd") = AdjDT.Rows(0).Item("tg_dd").ToString.Trim
                dr.Item("tradetype") = GetTypeDesc(GFncNoNullString(AdjDT.Rows(0).Item("tradetype")))
                dr.Item("recordID") = AdjDT.Rows(0).Item("recordID")
                DT.Rows.Add(dr)
            End If
        Else
            'AdjDT = GFncRtnDS(GSCnSqlConn, "select * from comm_adj_f where oid='" & ID & "' and adj_action=<>'A'").Tables(0)
            'If AdjDT.Rows.Count <= 0 Then
            '    Dim OrgDT As DataTable = GFncRtnDS(GSCnSqlConn, "select * from comm_trade_f where oid='" & ID & "'").Tables(0)
            '    If OrgDT.Rows.Count <= 0 Then
            '        Return Nothing
            '    Else
            '        Dim dr As DataRow = DT.NewRow
            '        dr.Item("adj_action") = "Adjusted"
            '        dr.Item("txmonth") = OrgDT.Rows(0).Item("txmonth").ToString.Trim
            '        dr.Item("aeno") = OrgDT.Rows(0).Item("aeno").ToString.Trim
            '        dr.Item("aename") = OrgDT.Rows(0).Item("aename").ToString.Trim
            '        dr.Item("accno") = OrgDT.Rows(0).Item("accno").ToString.Trim
            '        dr.Item("accname1") = OrgDT.Rows(0).Item("acname").ToString.Trim
            '        dr.Item("accname2") = OrgDT.Rows(0).Item("accname2").ToString.Trim
            '        dr.Item("commod") = OrgDT.Rows(0).Item("commod").ToString.Trim
            '        dr.Item("mth") = OrgDT.Rows(0).Item("mth").ToString.Trim
            '        dr.Item("call_put") = ReturnCallPutString(OrgDT.Rows(0).Item("call_put").ToString.Trim)
            '        dr.Item("strike") = OrgDT.Rows(0).Item("strike").ToString.Trim
            '        dr.Item("s_price_str") = OrgDT.Rows(0).Item("s_price_str").ToString.Trim
            '        dr.Item("commission_mm") = OrgDT.Rows(0).Item("commission_mm").ToString.Trim
            '        dr.Item("exchange_fee_mm") = OrgDT.Rows(0).Item("exchange_fee_mm").ToString.Trim
            '        dr.Item("ae_rebate_mm") = OrgDT.Rows(0).Item("ae_rebate_mm").ToString.Trim
            '        dr.Item("day_mm") = OrgDT.Rows(0).Item("day_mm").ToString.Trim
            '        dr.Item("night_mm") = OrgDT.Rows(0).Item("night_mm").ToString.Trim
            '        dr.Item("tg_mm") = OrgDT.Rows(0).Item("tg_mm").ToString.Trim
            '        dr.Item("ccy") = OrgDT.Rows(0).Item("ccy").ToString.Trim
            '        dr.Item("marketname") = OrgDT.Rows(0).Item("marketname").ToString.Trim
            '        dr.Item("oid") = OrgDT.Rows(0).Item("oid").ToString.Trim
            '        dr.Item("commission_dd") = OrgDT.Rows(0).Item("commission_dd").ToString.Trim
            '        dr.Item("exchange_fee_dd") = OrgDT.Rows(0).Item("exchange_fee_dd").ToString.Trim
            '        dr.Item("ae_rebate_dd") = OrgDT.Rows(0).Item("ae_rebate_dd").ToString.Trim
            '        dr.Item("day_dd") = OrgDT.Rows(0).Item("day_dd").ToString.Trim
            '        dr.Item("night_dd") = OrgDT.Rows(0).Item("night_dd").ToString.Trim
            '        dr.Item("tg_dd") = OrgDT.Rows(0).Item("tg_dd").ToString.Trim
            '        DT.Rows.Add(dr)
            '    End If
            'Else
            AdjDT = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_trade_f where oid='" & ID & "'").Tables(0)
            If AdjDT.Rows.Count > 0 Then
                Dim dr As DataRow = DT.NewRow
                dr.Item("adj_action") = ""
                dr.Item("txmonth") = AdjDT.Rows(0).Item("txmonth").ToString.Trim
                dr.Item("aeno") = AdjDT.Rows(0).Item("aeno").ToString.Trim
                dr.Item("aename") = AdjDT.Rows(0).Item("aename").ToString.Trim
                dr.Item("accno") = AdjDT.Rows(0).Item("accno").ToString.Trim
                dr.Item("accname1") = AdjDT.Rows(0).Item("accname1").ToString.Trim
                dr.Item("accname2") = AdjDT.Rows(0).Item("accname2").ToString.Trim
                dr.Item("commod") = AdjDT.Rows(0).Item("commod").ToString.Trim
                dr.Item("mth") = AdjDT.Rows(0).Item("mth").ToString.Trim
                dr.Item("call_put") = ReturnCallPutString(AdjDT.Rows(0).Item("call_put").ToString.Trim)
                dr.Item("strike") = AdjDT.Rows(0).Item("strike").ToString.Trim
                dr.Item("s_price_str") = AdjDT.Rows(0).Item("s_price_str").ToString.Trim
                dr.Item("commission_mm") = AdjDT.Rows(0).Item("commission_mm").ToString.Trim
                dr.Item("exchange_fee_mm") = AdjDT.Rows(0).Item("exchange_fee_mm").ToString.Trim
                dr.Item("ae_rebate_mm") = AdjDT.Rows(0).Item("ae_rebate_mm").ToString.Trim
                dr.Item("day_mm") = AdjDT.Rows(0).Item("day_mm").ToString.Trim
                dr.Item("night_mm") = AdjDT.Rows(0).Item("night_mm").ToString.Trim
                dr.Item("tg_mm") = AdjDT.Rows(0).Item("tg_mm").ToString.Trim
                dr.Item("ccy") = AdjDT.Rows(0).Item("ccy").ToString.Trim
                dr.Item("marketname") = AdjDT.Rows(0).Item("marketname").ToString.Trim
                dr.Item("oid") = AdjDT.Rows(0).Item("oid").ToString.Trim
                dr.Item("commission_dd") = AdjDT.Rows(0).Item("commission_dd").ToString.Trim
                dr.Item("exchange_fee_dd") = AdjDT.Rows(0).Item("exchange_fee_dd").ToString.Trim
                dr.Item("ae_rebate_dd") = AdjDT.Rows(0).Item("ae_rebate_dd").ToString.Trim
                dr.Item("day_dd") = AdjDT.Rows(0).Item("day_dd").ToString.Trim
                dr.Item("night_dd") = AdjDT.Rows(0).Item("night_dd").ToString.Trim
                dr.Item("tg_dd") = AdjDT.Rows(0).Item("tg_dd").ToString.Trim
                dr.Item("tradetype") = GetTypeDesc(GFncNoNullString(AdjDT.Rows(0).Item("tradetype")))
                dr.Item("recordID") = -1
                DT.Rows.Add(dr)
            End If
        End If
        Return DT
    End Function

    Protected Friend Function GetNewRecordID()
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, "Select max(recordid) as NID from draft_comm_adj_f").Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item("NID") + 1
        Else
            Return 1
        End If
    End Function

    Protected Friend Function GetCCY() As DataSet
        'Return GFncRtnDS(GSCnSqlConn, "")
        Return Nothing
    End Function

    Protected Friend Function GetProduct() As DataSet
        'Return GFncRtnDS(GSCnSqlConn, "select distinct product_no, product_name, type from comm_product_master where tradeMarket='F' order by product_name asc")
        Return GFncRtnDS(GSCnSqlConn, "select distinct product_code as product_no, product_name, ptype as type from " & _
            "futures_product_master order by product_no asc")
    End Function

    Protected Friend Function GetTType() As DataSet
        Return GFncRtnDS(GSCnSqlConn, "select distinct misc_code as code, misc_desc as type from misc_master " & _
            "where misc_type ='TranAdjFTType' order by misc_code")
    End Function

    Protected Friend Function GetTypeCode(ByVal inVal As String) As String
        'Dim query As String = " select misc_code from misc_master where misc_type='TranAdjSTType' and misc_desc='" & inVal & "'"
        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        'If dt.Rows.Count > 0 Then
        '    Return CInt(dt.Rows(0).Item(0))
        'Else
        '    Return 0
        'End If
        If inVal = "Internet" Then
            Return "3"
        Else
            Return "0"
        End If

    End Function
    Protected Friend Function GetTypeDesc(ByVal inVal As String) As String
        'Dim query As String = " select misc_desc from misc_master where misc_type='TranAdjSTType' and misc_code='" & inVal & "'"
        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        'If dt.Rows.Count > 0 Then
        '    Return dt.Rows(0).Item(0)
        'Else
        '    Return ""
        'End If
        If inVal = "3" Then
            Return "Internet"
        Else
            Return "Normal"
        End If

    End Function

    Protected Friend Function ValidAeCode(ByVal code As String) As Boolean
        If code.Length > 0 Then
            Dim query As String = "select * from draft_comm_ae_master where ae_no = '" & code & "' and inFut=1"
            Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Protected Friend Function ValidAcCode(ByVal code As String) As Boolean
        If code.Length > 0 Then
            Dim query As String = "select * from draft_comm_acc_master where acc_no = '" & code & "' and inFut=1"
            Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Protected Friend Function ValidProduct(ByVal code As String) As Boolean
        If code.Length > 0 Then
            Dim query As String = "select * from futures_product_master where product_code ='" & code & "' "
            Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
            If dt.Rows.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
End Class