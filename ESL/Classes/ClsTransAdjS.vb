Imports System.Data.SqlClient
'Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsTransAdjS
    '    Dim clsRpt As New ClsReports
    Protected Friend Function getNewestDate()
        Dim Isql As String = " select max(tdate) as tdate from (select max(tdate) as tdate from view_comm_trade_s union " & _
            "select max(tdate) as tdate from draft_comm_adj_s) a "
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, Isql, 0).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item("tdate")
        Else
            Return Now.Date
        End If
    End Function

    Protected Friend Function AddAdj(ByVal condition As String, ByVal log As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sql As String = "Insert into draft_comm_adj_s (txmonth, aename, accname, tdate, oid, stkno, price, qty, grossamt, " & _
            "commission, comm_rate, tradetype, lastupddate, lastupduser, adj_action , aeno, accno) values(" & condition & ")"
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
        Dim sql As String = "Update draft_comm_adj_s set " & condition & " where oid = '" & id & "'"
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
        Dim GridDT As New DataTable
        InitSearchDT(GridDT)
        Dim query As String = "select * from draft_comm_adj_s where 1=1 " & condition1
        Dim AdjDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select * from view_comm_trade_s where 1=1" & condition2 & "order by tdate desc, oid asc "
        Dim ViewDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select ae_no, isnull(ae_name, isnull(ae_name_s, '')) as  aename from draft_comm_ae_master"
        Dim AeDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select acc_no, isnull(acc_name_s, '') as acname from draft_comm_acc_master"
        Dim AcDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        Dim AdjDr() As DataRow
        Dim GridDr As DataRow
        Dim AeDr() As DataRow
        Dim AcDr() As DataRow
        Select Case DisplayType
            Case "All"
                For Each dr As DataRow In ViewDT.Rows
                    AdjDr = AdjDT.Select("oid ='" & dr.Item("oid") & "' and adj_action<>'A' ")
                    If AdjDr.Length > 0 Then
                        If AdjDr(0).Item("adj_action") <> "D" Then
                            'show adj records
                            GridDr = GridDT.NewRow
                            GridDr.Item("oid") = AdjDr(0).Item("oid")
                            GridDr.Item("txmonth") = AdjDr(0).Item("txmonth")
                            GridDr.Item("aeno") = AdjDr(0).Item("aeno")
                            GridDr.Item("accno") = AdjDr(0).Item("accno")
                            GridDr.Item("tdate") = AdjDr(0).Item("tdate")
                            GridDr.Item("stkno") = AdjDr(0).Item("stkno")
                            GridDr.Item("avgprice") = AdjDr(0).Item("price")
                            GridDr.Item("qty") = AdjDr(0).Item("qty")
                            GridDr.Item("grossamt") = AdjDr(0).Item("grossamt")
                            GridDr.Item("comm") = AdjDr(0).Item("commission")
                            GridDr.Item("comm_rate") = AdjDr(0).Item("comm_rate")
                            GridDr.Item("ttype") = GetTypeDesc(AdjDr(0).Item("tradetype"))
                            GridDr.Item("adj_action") = "Adjusted"
                            AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                            If AeDr.Length > 0 Then
                                GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                            Else
                                GridDr.Item("aename") = AdjDr(0).Item("aename").ToString.Trim
                            End If
                            AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                            If AcDr.Length > 0 Then
                                GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                            Else
                                GridDr.Item("accname") = AdjDr(0).Item("accname").ToString.Trim
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
                        GridDr.Item("stkno") = dr.Item("stkno")
                        GridDr.Item("avgprice") = dr.Item("avgprice")
                        GridDr.Item("qty") = dr.Item("qty")
                        GridDr.Item("grossamt") = dr.Item("grossamt")
                        GridDr.Item("comm") = dr.Item("commission")
                        GridDr.Item("comm_rate") = dr.Item("comm_rate")
                        GridDr.Item("ttype") = GetTypeDesc(dr.Item("tradetype"))
                        GridDr.Item("adj_action") = ""
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
                AdjDr = AdjDT.Select("adj_action='A'")
                For Each dr As DataRow In AdjDr
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = dr.Item("oid")
                    GridDr.Item("txmonth") = dr.Item("txmonth")
                    GridDr.Item("aeno") = dr.Item("aeno")
                    GridDr.Item("accno") = dr.Item("accno")
                    GridDr.Item("tdate") = dr.Item("tdate")
                    GridDr.Item("stkno") = dr.Item("stkno")
                    GridDr.Item("avgprice") = dr.Item("price")
                    GridDr.Item("qty") = dr.Item("qty")
                    GridDr.Item("grossamt") = dr.Item("grossamt")
                    GridDr.Item("comm") = dr.Item("commission")
                    GridDr.Item("comm_rate") = dr.Item("comm_rate")
                    GridDr.Item("ttype") = GetTypeDesc(dr.Item("tradetype"))
                    GridDr.Item("adj_action") = "New"
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
                    'GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("acno")))
                    GridDr.Item("stkname") = dr.Item("stkname")
                    GridDT.Rows.Add(GridDr)
                Next
            Case "Adjusted"
                AdjDr = AdjDT.Select("adj_action='M' or adj_action='A'", "adj_action desc, tdate asc")
                For Each dr As DataRow In AdjDr
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = dr.Item("oid")
                    GridDr.Item("txmonth") = dr.Item("txmonth")
                    GridDr.Item("aeno") = dr.Item("aeno")
                    GridDr.Item("accno") = dr.Item("accno")
                    GridDr.Item("tdate") = dr.Item("tdate")
                    GridDr.Item("stkno") = dr.Item("stkno")
                    GridDr.Item("avgprice") = dr.Item("price")
                    GridDr.Item("qty") = dr.Item("qty")
                    GridDr.Item("grossamt") = dr.Item("grossamt")
                    GridDr.Item("comm") = dr.Item("commission")
                    GridDr.Item("comm_rate") = dr.Item("comm_rate")
                    GridDr.Item("ttype") = GetTypeDesc((dr.Item("tradetype")))
                    If dr.Item("adj_action") = "A" Then
                        GridDr.Item("adj_action") = "New"
                    End If
                    If dr.Item("adj_action") = "M" Then
                        GridDr.Item("adj_action") = "Adjusted"
                    End If
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
                    'GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("acno")))
                    GridDr.Item("stkname") = dr.Item("stkname")
                    GridDT.Rows.Add(GridDr)
                Next
            Case "Deleted"
                AdjDr = AdjDT.Select("adj_action='D'", "adj_action desc, tdate asc")
                For Each dr As DataRow In AdjDr
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = dr.Item("oid")
                    GridDr.Item("txmonth") = dr.Item("txmonth")
                    GridDr.Item("aeno") = dr.Item("aeno")
                    GridDr.Item("accno") = dr.Item("accno")
                    GridDr.Item("tdate") = dr.Item("tdate")
                    GridDr.Item("stkno") = dr.Item("stkno")
                    GridDr.Item("avgprice") = dr.Item("price")
                    GridDr.Item("qty") = dr.Item("qty")
                    GridDr.Item("grossamt") = dr.Item("grossamt")
                    GridDr.Item("comm") = dr.Item("commission")
                    GridDr.Item("comm_rate") = dr.Item("comm_rate")
                    GridDr.Item("ttype") = GetTypeDesc(dr.Item("tradetype"))
                    GridDr.Item("adj_action") = "Deleted"
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
                    ' GridDr.Item("aename") = GetAeName(GFncNoNullString(dr.Item("aeno")))
                    ' GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("acno")))
                    GridDr.Item("stkname") = dr.Item("stkname")
                    GridDT.Rows.Add(GridDr)
                Next
            Case "Oid"
                For Each dr As DataRow In ViewDT.Rows
                    AdjDr = AdjDT.Select("oid ='" & dr.Item("oid") & "' and adj_action<>'A' ")
                    If AdjDr.Length > 0 Then
                        'If AdjDr(0).Item("adj_action") <> "D" Then
                        'show adj records
                        GridDr = GridDT.NewRow
                        GridDr.Item("oid") = AdjDr(0).Item("oid")
                        GridDr.Item("txmonth") = AdjDr(0).Item("txmonth")
                        GridDr.Item("aeno") = AdjDr(0).Item("aeno")
                        GridDr.Item("accno") = AdjDr(0).Item("accno")
                        GridDr.Item("tdate") = AdjDr(0).Item("tdate")
                        GridDr.Item("stkno") = AdjDr(0).Item("stkno")
                        GridDr.Item("avgprice") = AdjDr(0).Item("price")
                        GridDr.Item("qty") = AdjDr(0).Item("qty")
                        GridDr.Item("grossamt") = AdjDr(0).Item("grossamt")
                        GridDr.Item("comm") = AdjDr(0).Item("commission")
                        GridDr.Item("comm_rate") = AdjDr(0).Item("comm_rate")
                        GridDr.Item("ttype") = GetTypeDesc(AdjDr(0).Item("tradetype"))
                        Select Case AdjDr(0).Item("adj_action")
                            Case "M"
                                GridDr.Item("adj_action") = "Adjusted"
                            Case "D"
                                GridDr.Item("adj_action") = "Deleted"
                            Case Else
                                GridDr.Item("adj_action") = ""
                        End Select


                        AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                        If AeDr.Length > 0 Then
                            GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                        Else
                            GridDr.Item("aename") = AdjDr(0).Item("aename").ToString.Trim
                        End If
                        AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                        If AcDr.Length > 0 Then
                            GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                        Else
                            GridDr.Item("accname") = AdjDr(0).Item("accname").ToString.Trim
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
                        GridDr.Item("stkno") = dr.Item("stkno")
                        GridDr.Item("avgprice") = dr.Item("avgprice")
                        GridDr.Item("qty") = dr.Item("qty")
                        GridDr.Item("grossamt") = dr.Item("grossamt")
                        GridDr.Item("comm") = dr.Item("commission")
                        GridDr.Item("comm_rate") = dr.Item("comm_rate")
                        GridDr.Item("ttype") = GetTypeDesc(dr.Item("tradetype"))
                        GridDr.Item("adj_action") = ""
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
                AdjDr = AdjDT.Select("adj_action='A'")
                For Each dr As DataRow In AdjDr
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = dr.Item("oid")
                    GridDr.Item("txmonth") = dr.Item("txmonth")
                    GridDr.Item("aeno") = dr.Item("aeno")
                    GridDr.Item("accno") = dr.Item("accno")
                    GridDr.Item("tdate") = dr.Item("tdate")
                    GridDr.Item("stkno") = dr.Item("stkno")
                    GridDr.Item("avgprice") = dr.Item("price")
                    GridDr.Item("qty") = dr.Item("qty")
                    GridDr.Item("grossamt") = dr.Item("grossamt")
                    GridDr.Item("comm") = dr.Item("commission")
                    GridDr.Item("comm_rate") = dr.Item("comm_rate")
                    GridDr.Item("ttype") = GetTypeDesc(dr.Item("tradetype"))
                    GridDr.Item("adj_action") = "New"
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
                sql = "Update draft_comm_adj_s set adj_action='D' where oid = '" & condition & "'"
            Case 0
                sql = "Insert into draft_comm_adj_s (txmonth, aeno, accno, tdate, oid, stkno, price, qty, grossamt, " & _
                    "commission, comm_rate, tradetype, lastupddate, lastupduser, adj_action , ae, accname) values (" & condition & ")"
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
        Dim sql As String = "Update draft_comm_adj_s set adj_action=" + condition
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
        Dim query As String = "select oid from draft_comm_adj_s where oid ='" & id & "' union " & _
            "select oid from view_comm_trade_s where oid ='" & id & "'"
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
        Dim sql As String = "Delete from draft_comm_adj_s where oid= '" & id & "'"
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
        Dim query As String = "select max(oid)as oid from draft_comm_adj_s where oid like 'A%'"
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
        Column.ColumnName = "adj_action"
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
        Column.ColumnName = "stkno"
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

    Protected Friend Function ValidAeCode(ByVal code As String) As Boolean
        If code.Length > 0 Then
            Dim query As String = "select * from draft_comm_ae_master where ae_no ='" & code & "' and inSec=1"
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
            Dim query As String = "select * from draft_comm_acc_master where acc_no ='" & code & "' and inSec=1"
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

    Protected Friend Function GetAeCode() As DataTable
        Dim query As String = "select distinct ae_no from draft_comm_ae_master where ae_status='A' and inSec=1 order by ae_no asc"
        Return GFncRtnDS(GSCnSqlConn, query).Tables(0)
    End Function

    Protected Friend Function GetAeName(ByVal Code As String) As String
        If Code.Length > 0 Then
            Dim query As String = "select isnull(ae_name, isnull(ae_name_s, '')) as ae_name_s from draft_comm_ae_master " & _
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
        Dim query As String = "select distinct acc_no from draft_comm_acc_master where inSec=1 order by acc_no asc"
        Return GFncRtnDS(GSCnSqlConn, query).Tables(0)
    End Function

    Protected Friend Function GetAcName(ByVal Code As String) As String
        If Code.Length > 0 Then
            Dim query As String = "select isnull( acc_name, isnull(acc_name_s, '')) as ac_name_s from draft_comm_acc_master " & _
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

    Protected Friend Function GetNewestVal(ByVal ID As String) As DataTable
        Dim DT As New DataTable
        InitSearchDT(DT)
        Dim AdjDT As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_adj_s where oid='" & ID & "'").Tables(0)
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
                dr.Item("stkno") = OrgDT.Rows(0).Item("stkno")
                dr.Item("avgprice") = OrgDT.Rows(0).Item("avgprice")
                dr.Item("qty") = OrgDT.Rows(0).Item("qty")
                dr.Item("grossamt") = OrgDT.Rows(0).Item("grossamt")
                dr.Item("comm") = OrgDT.Rows(0).Item("commission")
                dr.Item("comm_rate") = OrgDT.Rows(0).Item("comm_rate")
                dr.Item("ttype") = GetTypeDesc(OrgDT.Rows(0).Item("tradetype"))
                dr.Item("adj_action") = ""
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
            dr.Item("accno") = AdjDT.Rows(0).Item("accno")
            dr.Item("tdate") = AdjDT.Rows(0).Item("tdate")
            dr.Item("stkno") = AdjDT.Rows(0).Item("stkno")
            dr.Item("avgprice") = AdjDT.Rows(0).Item("price")
            dr.Item("qty") = AdjDT.Rows(0).Item("qty")
            dr.Item("grossamt") = AdjDT.Rows(0).Item("grossamt")
            dr.Item("comm") = AdjDT.Rows(0).Item("commission")
            dr.Item("comm_rate") = AdjDT.Rows(0).Item("comm_rate")
            dr.Item("ttype") = GetTypeDesc(AdjDT.Rows(0).Item("tradetype"))
            Select Case AdjDT.Rows(0).Item("adj_action")
                Case "A"
                    dr.Item("adj_action") = "New"
                Case "M"
                    dr.Item("adj_action") = "Adjusted"
                Case "D"
                    dr.Item("adj_action") = "Deleted"
                Case Else
                    dr.Item("adj_action") = ""
            End Select
            'dr.Item("adj_action") = AdjDT.Rows(0).Item("adj_action")
            dr.Item("aename") = AdjDT.Rows(0).Item("aename").ToString.Trim
            dr.Item("accname") = AdjDT.Rows(0).Item("accname").ToString.Trim
            dr.Item("stkname") = AdjDT.Rows(0).Item("stkname")
            DT.Rows.Add(dr)
        End If
        Return DT
    End Function

    Protected Friend Function GetMaxMonth() As String
        Dim sql As String = "select max(a.txmonth) as txmonth from (select max(a.txmonth)as txmonth from view_comm_trade_s a " & _
            "left outer join draft_comm_adj_s b on a.oid=b.oid where isnull(b.adj_action,'') <>'D' union " & _
            "select max(txmonth)as txmonth from draft_comm_adj_s where isnull(adj_action,'') <>'D') a"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, sql).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item(0)
        Else
            Return (Now.Year & Format(CInt(Now.Month) - 1, "00"))
        End If
    End Function

    Protected Friend Function LoadTType() As DataTable
        Dim query As String = " select * from misc_master where misc_type='TranAdjSTType'"
        Return GFncRtnDS(GSCnSqlConn, query).Tables(0)
    End Function

    Protected Friend Function GetTypeCode(ByVal inVal As String) As Integer
        Dim query As String = " select misc_code from misc_master where misc_type='TranAdjSTType' and misc_desc='" & inVal & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If dt.Rows.Count > 0 Then
            Return CInt(dt.Rows(0).Item(0))
        Else
            Return 0
        End If
    End Function

    Protected Friend Function GetTypeDesc(ByVal inVal As String) As String
        Dim query As String = " select misc_desc from misc_master where misc_type='TranAdjSTType' and misc_code='" & inVal & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item(0)
        Else
            Return ""
        End If
    End Function

End Class
