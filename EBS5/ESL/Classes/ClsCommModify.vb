Imports System.Data.SqlClient
'Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsCommModify
    '    Dim clsRpt As New ClsReports
    Protected Friend Function getNewestDate()
        Dim Isql As String = " select max(tdate) as tdate from (select max(tdate) as tdate from view_comm_trade_s union select max(tdate) as tdate from comm_adj_s) a "

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, Isql, 0).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item("tdate")
        Else
            Return Now.Date
        End If


    End Function

    Protected Friend Function AddAdj(ByVal condition As String, ByVal log As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sql As String = "Insert into comm_adj_s (txmonth, ae, acct, tdate, oid, stk, price, qty, grossamt, commission, comm_rate," & _
        "tradetype, lastupddate, lastupduser, adjaction , aeno, acno) values(" & condition & ")"
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, " & _
                                        "D_TXMONTH, D_LOG) values (" & log & ")"
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sql, 0)
            GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
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

    Protected Friend Function UpdateAdj(ByVal id As String, ByVal condition As String, ByVal log As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sql As String = "Update comm_adj_s set " & condition & " where oid = '" & id & "'"
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, " & _
                                        "D_TXMONTH, D_LOG) values (" & log & ")"
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sql, 0)
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
            End If
        End Try
    End Function

    Protected Friend Function Search(ByVal condition1 As String, ByVal condition2 As String, ByVal DisplayType As String) As DataTable
        'Dim query As String
        'query = "select a.txmonth as txmonth, " & _
        '                "isnull(b.aeno, a.aeno) as aeno," & _
        '                "isnull(b.ae, a.aename) as aename," & _
        '                "isnull(b.acno, a.accno) as accno," & _
        '                "isnull(b.acct, a.accname)as accname," & _
        '                "a.tdate as tdate, a.oid as oid, a.stkno, a.stkname, " & _
        '                "isnull(b.price, a.avgprice) as avgprice, " & _
        '                "isnull(b.qty, a.qty) as qty, " & _
        '                "isnull(b.grossamt, a.grossamt) as grossamt, " & _
        '                "isnull(b.commission, a.commission) as commission, " & _
        '                "isnull(b.comm_rate, a.comm_rate) as comm_rate, " & _
        '                "case when isnull(b.tradetype,'')='' then a.tradetype else (case when b.tradetype='4' then 'I-trade' else 'Normal' end) end tradetype, " & _
        '                "case when b.adjaction='A' then 'New' when b.adjaction='M' then 'Adjusted' when b.adjaction='D' then 'Deleted' end adjaction " & _
        '                "from view_comm_trade_s a left outer join comm_adj_s b on a.oid=b.oid where isnull(b.adjaction,'') <>'D' "
        'If sql.Length > 0 Then
        '    query += sql
        'End If
        'query += " union select txmonth, aeno, ae as aename, acno as accno, acct as accname, tdate, oid, stk as stkno,'' as stkname, price as avgprice," & _
        '                "qty, grossamt, commission, comm_rate, " & _
        '                " case when tradetype='4' then 'I-trade' else 'Normal' end tradetype , " & _
        '                " case when adjaction='A' then 'New' when adjaction='M' then 'Adjusted' when adjaction='D' then 'Deleted' end adjaction " & _
        '                " from comm_adj_s where 1=1"
        'If sql.Length > 0 Then
        '    query += sql2
        'End If
        'query += " order by tdate desc, oid asc"
        'Return GFncRtnDS(GSCnSqlConn, query)
        Dim GridDT As New DataTable
        InitSearchDT(GridDT)
        Dim query As String = "select * from comm_adj_s where 1=1 " & condition1
        Dim AdjDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select * from view_comm_trade_s where 1=1" & condition2 & "order by tdate desc, oid asc "
        Dim ViewDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select ae_no, isnull(ae_name, isnull(ae_name_s, '')) as  aename from comm_ae_master"
        Dim AeDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select acc_no, isnull(acc_name, isnull(acc_name_s, '')) as acname from comm_acc_master"
        Dim AcDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        Dim AdjDr() As DataRow
        Dim GridDr As DataRow
        Dim AeDr() As DataRow
        Dim AcDr() As DataRow
        Select Case DisplayType
            Case "All"
                For Each dr As DataRow In ViewDT.Rows
                    AdjDr = AdjDT.Select("oid ='" & dr.Item("oid") & "' and AdjAction<>'A' ")
                    If AdjDr.Length > 0 Then
                        If AdjDr(0).Item("adjaction") <> "D" Then
                            'show adj records
                            GridDr = GridDT.NewRow
                            GridDr.Item("oid") = AdjDr(0).Item("oid")
                            GridDr.Item("txmonth") = AdjDr(0).Item("txmonth")
                            GridDr.Item("aeno") = AdjDr(0).Item("aeno")
                            GridDr.Item("accno") = AdjDr(0).Item("acno")
                            GridDr.Item("tdate") = AdjDr(0).Item("tdate")
                            GridDr.Item("stk") = AdjDr(0).Item("stk")
                            GridDr.Item("avgprice") = AdjDr(0).Item("price")
                            GridDr.Item("qty") = AdjDr(0).Item("qty")
                            GridDr.Item("grossamt") = AdjDr(0).Item("grossamt")
                            GridDr.Item("comm") = AdjDr(0).Item("commission")
                            GridDr.Item("comm_rate") = AdjDr(0).Item("comm_rate")
                            GridDr.Item("ttype") = GetTradeType(AdjDr(0).Item("tradetype"))
                            GridDr.Item("adjaction") = "Adjusted"

                            AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                            If AeDr.Length > 0 Then
                                GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                            Else
                                GridDr.Item("aename") = AdjDr(0).Item("ae").ToString.Trim
                            End If
                            AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                            If AcDr.Length > 0 Then
                                GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                            Else
                                GridDr.Item("accname") = AdjDr(0).Item("acct").ToString.Trim
                            End If
                            'GridDr.Item("aename") = GetAeName(GFncNoNullString(AdjDr(0).Item("aeno")))
                            'GridDr.Item("accname") = GetAcName(GFncNoNullString(AdjDr(0).Item("acno")))
                            GridDr.Item("stkname") = AdjDr(0).Item("stkname")

                            GridDT.Rows.Add(GridDr)
                        End If
                    Else
                        'show unAdj record
                        GridDr = GridDT.NewRow
                        GridDr.Item("oid") = dr.Item("oid")
                        GridDr.Item("txmonth") = dr.Item("txmonth")
                        GridDr.Item("aeno") = dr.Item("aeno").ToString.Trim
                        GridDr.Item("accno") = dr.Item("accno").ToString.Trim
                        GridDr.Item("tdate") = dr.Item("tdate")
                        GridDr.Item("stk") = dr.Item("stkno")
                        GridDr.Item("avgprice") = dr.Item("avgprice")
                        GridDr.Item("qty") = dr.Item("qty")
                        GridDr.Item("grossamt") = dr.Item("grossamt")
                        GridDr.Item("comm") = dr.Item("commission")
                        GridDr.Item("comm_rate") = dr.Item("comm_rate")
                        GridDr.Item("ttype") = dr.Item("tradetype")
                        GridDr.Item("adjaction") = ""
                        AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                        If AeDr.Length > 0 Then
                            GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                        Else
                            GridDr.Item("aename") = dr.Item("aename").ToString.Trim
                        End If
                        AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                        If AcDr.Length > 0 Then
                            GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                        Else
                            GridDr.Item("accname") = dr.Item("accname").ToString.Trim
                        End If
                        'GridDr.Item("aename") = GetAeName(GFncNoNullString(dr.Item("aeno")))
                        'GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("accno").ToString.Trim))
                        GridDr.Item("stkname") = dr.Item("stkname")
                        GridDT.Rows.Add(GridDr)
                    End If

                Next
                AdjDr = AdjDT.Select("Adjaction='A'")
                For Each dr As DataRow In AdjDr
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = dr.Item("oid")
                    GridDr.Item("txmonth") = dr.Item("txmonth")
                    GridDr.Item("aeno") = dr.Item("aeno")
                    GridDr.Item("accno") = dr.Item("acno")
                    GridDr.Item("tdate") = dr.Item("tdate")
                    GridDr.Item("stk") = dr.Item("stk")
                    GridDr.Item("avgprice") = dr.Item("price")
                    GridDr.Item("qty") = dr.Item("qty")
                    GridDr.Item("grossamt") = dr.Item("grossamt")
                    GridDr.Item("comm") = dr.Item("commission")
                    GridDr.Item("comm_rate") = dr.Item("comm_rate")
                    GridDr.Item("ttype") = GetTradeType(dr.Item("tradetype"))
                    GridDr.Item("adjaction") = "New"
                    AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        GridDr.Item("aename") = dr.Item("ae").ToString.Trim
                    End If
                    AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        GridDr.Item("accname") = dr.Item("acct").ToString.Trim
                    End If
                    'GridDr.Item("aename") = GetAeName(GFncNoNullString(dr.Item("aeno")))
                    'GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("acno")))
                    GridDr.Item("stkname") = dr.Item("stkname")
                    GridDT.Rows.Add(GridDr)
                Next

            Case "Adjusted"
                AdjDr = AdjDT.Select("Adjaction='M' or Adjaction='A'", "adjaction desc, tdate asc")
                For Each dr As DataRow In AdjDr
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = dr.Item("oid")
                    GridDr.Item("txmonth") = dr.Item("txmonth")
                    GridDr.Item("aeno") = dr.Item("aeno")
                    GridDr.Item("accno") = dr.Item("acno")
                    GridDr.Item("tdate") = dr.Item("tdate")
                    GridDr.Item("stk") = dr.Item("stk")
                    GridDr.Item("avgprice") = dr.Item("price")
                    GridDr.Item("qty") = dr.Item("qty")
                    GridDr.Item("grossamt") = dr.Item("grossamt")
                    GridDr.Item("comm") = dr.Item("commission")
                    GridDr.Item("comm_rate") = dr.Item("comm_rate")
                    GridDr.Item("ttype") = GetTradeType(dr.Item("tradetype"))
                    If dr.Item("adjaction") = "A" Then
                        GridDr.Item("adjaction") = "New"
                    End If
                    If dr.Item("adjaction") = "M" Then
                        GridDr.Item("adjaction") = "Adjusted"
                    End If
                    AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        GridDr.Item("aename") = dr.Item("ae").ToString.Trim
                    End If
                    AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        GridDr.Item("accname") = dr.Item("acct").ToString.Trim
                    End If
                    'GridDr.Item("aename") = GetAeName(GFncNoNullString(dr.Item("aeno")))
                    'GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("acno")))
                    GridDr.Item("stkname") = dr.Item("stkname")
                    GridDT.Rows.Add(GridDr)
                Next
            Case "Deleted"
                AdjDr = AdjDT.Select("Adjaction='D'", "adjaction desc, tdate asc")
                For Each dr As DataRow In AdjDr
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = dr.Item("oid")
                    GridDr.Item("txmonth") = dr.Item("txmonth")
                    GridDr.Item("aeno") = dr.Item("aeno")
                    GridDr.Item("accno") = dr.Item("acno")
                    GridDr.Item("tdate") = dr.Item("tdate")
                    GridDr.Item("stk") = dr.Item("stk")
                    GridDr.Item("avgprice") = dr.Item("price")
                    GridDr.Item("qty") = dr.Item("qty")
                    GridDr.Item("grossamt") = dr.Item("grossamt")
                    GridDr.Item("comm") = dr.Item("commission")
                    GridDr.Item("comm_rate") = dr.Item("comm_rate")
                    GridDr.Item("ttype") = GetTradeType(dr.Item("tradetype"))
                    GridDr.Item("adjaction") = "Deleted"
                    AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        GridDr.Item("aename") = dr.Item("ae").ToString.Trim
                    End If
                    AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        GridDr.Item("accname") = dr.Item("acct").ToString.Trim
                    End If
                    ' GridDr.Item("aename") = GetAeName(GFncNoNullString(dr.Item("aeno")))
                    ' GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("acno")))
                    GridDr.Item("stkname") = dr.Item("stkname")
                    GridDT.Rows.Add(GridDr)
                Next
            Case "Oid"
                For Each dr As DataRow In ViewDT.Rows
                    AdjDr = AdjDT.Select("oid ='" & dr.Item("oid") & "' and AdjAction<>'A' ")
                    If AdjDr.Length > 0 Then
                        'If AdjDr(0).Item("adjaction") <> "D" Then
                        'show adj records
                        GridDr = GridDT.NewRow
                        GridDr.Item("oid") = AdjDr(0).Item("oid")
                        GridDr.Item("txmonth") = AdjDr(0).Item("txmonth")
                        GridDr.Item("aeno") = AdjDr(0).Item("aeno")
                        GridDr.Item("accno") = AdjDr(0).Item("acno")
                        GridDr.Item("tdate") = AdjDr(0).Item("tdate")
                        GridDr.Item("stk") = AdjDr(0).Item("stk")
                        GridDr.Item("avgprice") = AdjDr(0).Item("price")
                        GridDr.Item("qty") = AdjDr(0).Item("qty")
                        GridDr.Item("grossamt") = AdjDr(0).Item("grossamt")
                        GridDr.Item("comm") = AdjDr(0).Item("commission")
                        GridDr.Item("comm_rate") = AdjDr(0).Item("comm_rate")
                        GridDr.Item("ttype") = GetTradeType(AdjDr(0).Item("tradetype"))
                        Select Case AdjDr(0).Item("adjaction")
                            Case "M"
                                GridDr.Item("adjaction") = "Adjusted"
                            Case "D"
                                GridDr.Item("adjaction") = "Deleted"
                            Case Else
                                GridDr.Item("adjaction") = ""
                        End Select


                        AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                        If AeDr.Length > 0 Then
                            GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                        Else
                            GridDr.Item("aename") = AdjDr(0).Item("ae").ToString.Trim
                        End If
                        AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                        If AcDr.Length > 0 Then
                            GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                        Else
                            GridDr.Item("accname") = AdjDr(0).Item("acct").ToString.Trim
                        End If
                        'GridDr.Item("aename") = GetAeName(GFncNoNullString(AdjDr(0).Item("aeno")))
                        'GridDr.Item("accname") = GetAcName(GFncNoNullString(AdjDr(0).Item("acno")))
                        GridDr.Item("stkname") = AdjDr(0).Item("stkname")

                        GridDT.Rows.Add(GridDr)
                        'End If
                    Else
                    'show unAdj record
                        GridDr = GridDT.NewRow
                        GridDr.Item("oid") = dr.Item("oid")
                        GridDr.Item("txmonth") = dr.Item("txmonth")
                        GridDr.Item("aeno") = dr.Item("aeno").ToString.Trim
                        GridDr.Item("accno") = dr.Item("accno").ToString.Trim
                        GridDr.Item("tdate") = dr.Item("tdate")
                        GridDr.Item("stk") = dr.Item("stkno")
                        GridDr.Item("avgprice") = dr.Item("avgprice")
                        GridDr.Item("qty") = dr.Item("qty")
                        GridDr.Item("grossamt") = dr.Item("grossamt")
                        GridDr.Item("comm") = dr.Item("commission")
                        GridDr.Item("comm_rate") = dr.Item("comm_rate")
                        GridDr.Item("ttype") = dr.Item("tradetype")
                        GridDr.Item("adjaction") = ""
                        AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                        If AeDr.Length > 0 Then
                            GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                        Else
                            GridDr.Item("aename") = dr.Item("aename").ToString.Trim
                        End If
                        AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                        If AcDr.Length > 0 Then
                            GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                        Else
                            GridDr.Item("accname") = dr.Item("accname").ToString.Trim
                        End If
                        'GridDr.Item("aename") = GetAeName(GFncNoNullString(dr.Item("aeno")))
                        'GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("accno").ToString.Trim))
                        GridDr.Item("stkname") = dr.Item("stkname")
                        GridDT.Rows.Add(GridDr)
                    End If

                Next
                AdjDr = AdjDT.Select("Adjaction='A'")
                For Each dr As DataRow In AdjDr
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = dr.Item("oid")
                    GridDr.Item("txmonth") = dr.Item("txmonth")
                    GridDr.Item("aeno") = dr.Item("aeno")
                    GridDr.Item("accno") = dr.Item("acno")
                    GridDr.Item("tdate") = dr.Item("tdate")
                    GridDr.Item("stk") = dr.Item("stk")
                    GridDr.Item("avgprice") = dr.Item("price")
                    GridDr.Item("qty") = dr.Item("qty")
                    GridDr.Item("grossamt") = dr.Item("grossamt")
                    GridDr.Item("comm") = dr.Item("commission")
                    GridDr.Item("comm_rate") = dr.Item("comm_rate")
                    GridDr.Item("ttype") = GetTradeType(dr.Item("tradetype"))
                    GridDr.Item("adjaction") = "New"
                    AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        GridDr.Item("aename") = dr.Item("ae").ToString.Trim
                    End If
                    AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        GridDr.Item("accname") = dr.Item("acct").ToString.Trim
                    End If
                    'GridDr.Item("aename") = GetAeName(GFncNoNullString(dr.Item("aeno")))
                    'GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("acno")))
                    GridDr.Item("stkname") = dr.Item("stkname")
                    GridDT.Rows.Add(GridDr)
                Next
        End Select

        Return GridDT
    End Function

    Protected Friend Sub delRecord(ByVal condition As String, ByVal log As String, ByVal no As Integer)
        Dim MyTrans As SqlTransaction = Nothing
        Dim sql As String = ""
        Select Case no
            Case 1
                sql = "Update comm_adj_s set adjaction='D' where oid = '" & condition & "'"
            Case 0
                sql = "Insert into comm_adj_s (txmonth, aeno, acno, tdate, oid, stk, price, qty, grossamt, commission, comm_rate," & _
               "tradetype, lastupddate, lastupduser, adjaction , ae, acct) values(" & condition & ")"
        End Select

        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, " & _
                                        "D_TXMONTH, D_LOG) values (" & log & ")"
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
    End Sub

    Protected Friend Sub ReStoreDel(ByVal condition As String, ByVal log As String)
        If condition = Nothing Or log = Nothing Then
            Return
        End If
        Dim sql As String = "Update comm_adj_s set adjaction=" + condition

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
    End Sub

    Protected Friend Function RestoreDel(ByVal id As String) As String

        Dim sql As String = "select * from LOGTBL where D_oid='" & id & "' and D_type ='commAdj' order by D_date desc"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, sql).Tables(0)
        If dt.Rows.Count > 0 Then
            For Each rw As DataRow In dt.Rows
                If GFncNoNullString(rw.Item("d_action")) <> "D" Then
                    Return GFncNoNullString(rw.Item("d_action"))
                End If
            Next
            Return "M"
        End If
        Return Nothing
    End Function

    Protected Friend Function IDValidate(ByVal id As String) As Boolean
        Dim query As String = "select oid from comm_adj_s where oid ='" & id & "' union select oid from view_comm_trade_s where oid ='" & id & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Friend Function DelNewRec(ByVal id As String, ByVal log As String) As Boolean
        If id = Nothing Or log = Nothing Then
            Return False
        End If
        Dim sql As String = "Delete from comm_adj_s where oid= '" & id & "'"

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

    Protected Friend Function GetNewID()
        Dim query As String = "select max(oid)as oid from comm_adj_s where oid like 'A%'"
        Dim MID As String
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If dt.Rows.Count > 0 Then
            MID = dt.Rows(0).Item(0)
            MID = MID.Substring(1)
            MID = Format(CInt(MID) + 1, "0000000")
            MID = "A" + MID
        Else
            MID = "A0000001"
        End If
        Return MID

    End Function

    Private Sub InitSearchDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "adjaction"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "oid"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "txmonth"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aeno"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aename"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accno"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accname"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "tdate"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "stk"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "stkname"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "avgprice"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "qty"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "grossamt"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_rate"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ttype"
        DT.Columns.Add(Column)
    End Sub

    Private Function GetTradeType(ByVal inVal As String)
        If inVal = "4" Then
            Return "I-trade"
        Else
            Return "Normal"
        End If
    End Function

    Protected Friend Function GetAeCode() As DataTable
        Dim query As String = "select distinct ae_no from comm_ae_master where ae_status='A' order by ae_no asc"
        Return GFncRtnDS(GSCnSqlConn, query).Tables(0)
    End Function
    Protected Friend Function GetAeName(ByVal Code As String) As String
        If Code.Length > 0 Then
            Dim query As String = "select isnull(ae_name, isnull(ae_name_s, '')) as ae_name_s from comm_ae_master where ae_no ='" & Code & "'"
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
        Dim query As String = "select distinct acc_no from comm_acc_master  order by acc_no asc"
        Return GFncRtnDS(GSCnSqlConn, query).Tables(0)
    End Function

    Protected Friend Function GetAcName(ByVal Code As String) As String
        If Code.Length > 0 Then
            Dim query As String = "select isnull( acc_name, isnull(acc_name_s, '')) as ac_name_s from comm_acc_master where acc_no ='" & Code & "'"
            Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
            If dt.Rows.Count > 0 Then
                Return GFncNoNullString(dt.Rows(0).Item(0).ToString.Trim)
            Else
                Return ""
            End If
        End If
        Return ""
    End Function

    Protected Friend Function GetNewestVal(ByVal ID As String) As DataTable
        Dim DT As New DataTable
        InitSearchDT(DT)
        Dim AdjDT As DataTable = GFncRtnDS(GSCnSqlConn, "select * from comm_adj_s where oid='" & ID & "'").Tables(0)
        If AdjDT.Rows.Count <= 0 Then
            Dim OrgDT As DataTable = GFncRtnDS(GSCnSqlConn, "select * from view_comm_trade_s where oid='" & ID & "'").Tables(0)
            If OrgDT.Rows.Count <= 0 Then
                Return Nothing
            Else
                Dim dr As DataRow = DT.NewRow
                dr.Item("oid") = OrgDT.Rows(0).Item("oid")
                dr.Item("txmonth") = OrgDT.Rows(0).Item("txmonth")
                dr.Item("aeno") = OrgDT.Rows(0).Item("aeno")
                dr.Item("accno") = OrgDT.Rows(0).Item("accno")
                dr.Item("tdate") = OrgDT.Rows(0).Item("tdate")
                dr.Item("stk") = OrgDT.Rows(0).Item("stkno")
                dr.Item("avgprice") = OrgDT.Rows(0).Item("avgprice")
                dr.Item("qty") = OrgDT.Rows(0).Item("qty")
                dr.Item("grossamt") = OrgDT.Rows(0).Item("grossamt")
                dr.Item("comm") = OrgDT.Rows(0).Item("commission")
                dr.Item("comm_rate") = OrgDT.Rows(0).Item("comm_rate")
                dr.Item("ttype") = GetTradeType(OrgDT.Rows(0).Item("tradetype"))
                dr.Item("adjaction") = ""
                dr.Item("aename") = OrgDT.Rows(0).Item("aename").ToString.Trim
                dr.Item("accname") = OrgDT.Rows(0).Item("accname").ToString.Trim
                dr.Item("stkname") = OrgDT.Rows(0).Item("stkname")
                DT.Rows.Add(dr)
            End If
        Else
            Dim dr As DataRow = DT.NewRow
            dr.Item("oid") = AdjDT.Rows(0).Item("oid")
            dr.Item("txmonth") = AdjDT.Rows(0).Item("txmonth")
            dr.Item("aeno") = AdjDT.Rows(0).Item("aeno")
            dr.Item("accno") = AdjDT.Rows(0).Item("acno")
            dr.Item("tdate") = AdjDT.Rows(0).Item("tdate")
            dr.Item("stk") = AdjDT.Rows(0).Item("stk")
            dr.Item("avgprice") = AdjDT.Rows(0).Item("price")
            dr.Item("qty") = AdjDT.Rows(0).Item("qty")
            dr.Item("grossamt") = AdjDT.Rows(0).Item("grossamt")
            dr.Item("comm") = AdjDT.Rows(0).Item("commission")
            dr.Item("comm_rate") = AdjDT.Rows(0).Item("comm_rate")
            dr.Item("ttype") = GetTradeType(AdjDT.Rows(0).Item("tradetype"))
            Select Case AdjDT.Rows(0).Item("adjaction")
                Case "A"
                    dr.Item("adjaction") = "New"
                Case "M"
                    dr.Item("adjaction") = "Adjusted"
                Case "D"
                    dr.Item("adjaction") = "Deleted"
                Case Else
                    dr.Item("adjaction") = ""
            End Select
            'dr.Item("adjaction") = AdjDT.Rows(0).Item("adjaction")
            dr.Item("aename") = AdjDT.Rows(0).Item("ae").ToString.Trim
            dr.Item("accname") = AdjDT.Rows(0).Item("acct").ToString.Trim
            dr.Item("stkname") = AdjDT.Rows(0).Item("stkname")
            DT.Rows.Add(dr)
        End If
        Return DT
    End Function
End Class
