Imports System.Data.SqlClient

Public Class ClsCommRatetblFAcc

    Dim AeDT As DataTable
    Dim AccDT As DataTable
    Protected Friend Function EnquiryACTbl(ByVal condition As String) As DataSet
        Dim lstrSQL As String = "Select distinct b.acc_no as acc_no, isnull(a.acc_name_f, '') as acc_name from " & _
            "draft_comm_acc_master a inner join draft_comm_rate_f b on a.acc_no=b.acc_no where a.inFut=1 " & condition & _
            " order by acc_no asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL)
    End Function

    Protected Friend Function EnquiryAETbl(ByVal condition As String) As DataSet
        Dim lstrSQL As String = "Select distinct b.ae_no as ae_no, isnull(a.ae_name_f, '') as ae_name, b.acc_group from " & _
            "draft_comm_ae_master a inner join draft_comm_rate_f b on a.ae_no=b.ae_no where a.inFut=1 " & condition & _
            " order by b.acc_group asc, ae_no asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL)
    End Function

    Protected Friend Function EnquiryManTbl(ByVal condition As String) As DataSet
        Dim lstrSQL As String = "select distinct a.man_no, a.man_name,b.man_group from draft_comm_man_master a inner join " & _
            "draft_comm_rate_f b on a.man_no= b.man_no where 1=1" & condition & " order by a.man_no asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL)
    End Function

    'Protected Friend Function GetOptProd() As DataTable
    '    'Dim lstrSQL As String = "Select distinct product_group, isnull(product_name, '') as product_name,ptype as type from futures_product_master where ptype =1 order by product_group asc"
    '    Dim lstrSQL As String = "Select distinct product_group from comm_product_group order by product_group asc"
    '    Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    'End Function
    Protected Friend Function GetAccList() As DataTable
        Dim lstrSQL As String
        lstrSQL = "select distinct acc_no from draft_comm_acc_master where inFut=1 order by acc_no"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetAcc() As DataTable
        Dim lstrSQL As String
        'lstrSQL = "Select distinct acc_no, isnull(acc_name, isnull(acc_name_f, '')) as acc_name, acc_group_f, ae_no_f, man_group_f, man_no_f from comm_acc_master where inFut=1 order by acc_no asc"
        lstrSQL = "Select a.acc_no, isnull(b.txmonth,'') as txmonth, isnull(a.acc_name_f, '') as acc_name, " & _
            "isnull(b.acc_group_f,'') as acc_group, isnull(b.ae_no_f, '') as ae_no, isnull(b.man_no_f, '') as man_no, " & _
            "isnull(b.isconsolid,0) as isconsolid from draft_comm_acc_master a left outer join draft_comm_acc_master_d b " & _
            "on a.acc_no = b.acc_no where a.inFut = 1 and b.ae_no_f <> '' order by a.acc_no asc"
        AccDT = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Return AccDT
    End Function

    Protected Friend Function GetProduct() As DataTable
        Dim lstrSQL As String = "Select distinct product_group, txmonth from draft_comm_product_group order by product_group asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetAe() As DataTable
        Dim lstrSQL As String = "Select distinct ae_no, isnull(ae_name_f, '') as ae_name from draft_comm_ae_master " & _
            "where inFut=1 order by ae_no asc"
        AeDT = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Return AeDT
    End Function

    Protected Friend Function GetAllAe() As DataTable
        Dim lstrSQL As String = "select distinct a.ae_no, a.ae_name_f, b.txmonth, b.isconsolid from draft_comm_ae_master a " & _
            "inner join draft_comm_ae_master_d b on a.ae_no = b.ae_no where infut=1 and iscommission_f = 1 and a.ae_no <> '' " & _
            "order by b.txmonth, a.ae_no"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetMan() As DataTable
        Dim lstrSQL As String = "Select distinct man_no, isnull(man_name, '') as man_name from draft_comm_man_master "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetManGP() As DataTable
        Dim lstrSQL As String = "Select b.man_no, a.txmonth, isnull(a.man_group_f,'') as man_group " & _
            "from draft_comm_ae_master_d a right outer join draft_comm_man_master b on a.ae_no= b.man_no order by b.man_no "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetLatestRecord(ByVal id As Integer) As DataSet
        Dim lstrSQL As String = "Select * from draft_comm_rate_f where rsid =" & id
        Return GFncRtnDS(GSCnSqlConn, lstrSQL)
    End Function

    Protected Friend Function GetAeByAcc(ByVal ACC As String) As String
        Dim lstrSQL As String = "Select ae_no_f from draft_comm_acc_master where acc_no ='" & ACC & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return GFncNoNullString(dt.Rows(0).Item("ae_no_f")).Trim
        Else
            Return ""
        End If
    End Function

    'Protected Friend Function GetManGroupByManNo(ByVal Man As String, ByVal month As String) As DataSet
    '    Dim lstrSQL As String = "Select man_group_f from comm_ae_master_d where ae_no ='" & Man & "' and txmonth ='" & month & "' "
    '    Return GFncRtnDS(GSCnSqlConn, lstrSQL)
    'End Function

    Protected Friend Function GetAeGroup() As DataTable
        Dim lstrSQL As String = "select distinct a.ae_no, a.ae_name_f, isnull(b.txmonth,'') as txmonth, " & _
            "isnull(ae_group_f,'') as ae_group, isnull(isConsolid,0) as isConsolid from draft_comm_ae_master a " & _
            "inner join comm_group_f b on a.ae_no = b.ae_no where inFut=1 order by a.ae_no, txmonth"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function ValidateManager(ByVal Manno As String) As Boolean
        If Manno <> Nothing Then
            Dim lstrSQL As String = "Select man_no from draft_comm_man_master where man_no ='" & Manno & "' "
            Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
            If dt.Rows.Count > 0 Then
                Return True
            End If
        End If
        Return False
    End Function

    Protected Friend Function ValidateDuplicate(ByVal condition As String) As Boolean
        Dim lstrSQL As String = "Select * from draft_comm_rate_f  where 1=1 " & condition
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Friend Function NewRecord(ByVal condition As String, ByVal log As String) As Integer
        Dim rsid As DataTable = Nothing
        Dim lstrSQL As String = "Insert into draft_comm_rate_f (acc_no, acc_group, man_no, man_group, ae_no, product_group, " & _
            "comm_rate, rate_type, turnover_from, day_rate, night_rate, all_rate, comm_month, comm_type) Values (" & condition & ")"
        Dim MyTrans As SqlTransaction = Nothing
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_TXMONTH, " & _
            "D_LOG, D_OID) values (" & log
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            rsid = GFncRtnDS(GSCnSqlConn, "Select max(rsid) from draft_comm_rate_f", MyTrans).Tables(0)
            sql_log += " '" & rsid.Rows(0).Item(0) & "')"
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
        Return GFncNoNullString(rsid.Rows(0).Item(0))
    End Function

    Protected Friend Function EditRecord(ByVal condition As String, ByVal id As Integer, ByVal log As String) As Boolean
        Dim lstrSQL As String = "Update draft_comm_rate_f Set " & condition & " where rsid =" & id
        Dim MyTrans As SqlTransaction = Nothing
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE, D_OID, " & _
            "D_TXMONTH, D_LOG) values (" & log & ")"
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
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

    Protected Friend Function DelRecord(ByVal id As Integer, ByVal log As String) As Boolean
        Dim lstrSQL As String = "Delete from draft_comm_rate_f where rsid =" & id
        Dim MyTrans As SqlTransaction = Nothing
        Dim sql_log As String = "Insert into LOGTBL (D_USER, D_DATE, D_ACTION, D_TYPE, D_AE, D_AC, D_O_TDATE,D_OID, " & _
            "D_TXMONTH, D_LOG) values (" & log & ")"
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
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

    Protected Friend Function EnquiryRateTbl(ByVal Condition As String, ByVal OrderCondition As String) As DataTable
        Dim RateDT As New DataTable
        InitRateDT(RateDT)
        Dim AeDr() As DataRow
        Dim Dr As DataRow
        Dim Lot() As DataRow
        Dim lstrSQL As String = "Select acc_no, acc_group, man_no, man_group, product_group,ae_no, comm_rate, rate_type, " & _
            "turnover_from, day_rate, night_rate, all_rate, comm_month, comm_type, rsid from draft_comm_rate_f " & _
            "where 1=1 " & Condition & " order by " & OrderCondition & " rsid asc"
        Dim SearchDt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If SearchDt.Rows.Count > 0 Then
            GetAe()
            'GetAcc()
            For Each Searchdr As DataRow In SearchDt.Rows
                Dr = RateDT.NewRow
                Dr.Item("acc_no") = Searchdr.Item("acc_no")
                Dr.Item("acc_group") = Searchdr.Item("acc_group")
                Dr.Item("man_no") = Searchdr.Item("man_no")
                Dr.Item("product_group") = Searchdr.Item("product_group")
                Dr.Item("man_group") = Searchdr.Item("man_group")
                Dr.Item("ae_no") = Searchdr.Item("ae_no")
                AeDr = AeDT.Select("ae_no='" & Dr.Item("ae_no") & "'")
                If AeDr.Length > 0 Then
                    Dr.Item("ae_name") = AeDr(0).Item("ae_name").ToString.Trim
                End If
                Dr.Item("comm_rate") = Searchdr.Item("comm_rate")
                Dr.Item("rate_type") = Searchdr.Item("rate_type")
                Dr.Item("turnover_from") = Searchdr.Item("turnover_from")
                Dr.Item("day_rate") = Searchdr.Item("day_rate")
                Dr.Item("night_rate") = Searchdr.Item("night_rate")
                'Dr.Item("all_rate") = Searchdr.Item("all_rate")
                Dr.Item("comm_month") = Searchdr.Item("comm_month")
                Dr.Item("comm_type") = Searchdr.Item("comm_type")
                Dr.Item("rsid") = Searchdr.Item("rsid")
                'AccDr = AccDT.Select("acc_no='" & Dr.Item("acc_no") & "'")
                'Dr.Item("acc_name_f") = AccDr(0).Item("acc_name")
                Select Case Searchdr.Item("rate_type").ToString
                    Case "NORF"
                        Dr.Item("fut_type") = "Futures"
                        Dr.Item("trade_type") = "Normal Trade"
                    Case "NORO"
                        Dr.Item("fut_type") = "Options"
                        Dr.Item("trade_type") = "Normal Trade"
                    Case "NORB"
                        Dr.Item("fut_type") = "Futures and Options"
                        Dr.Item("trade_type") = "Normal Trade"
                    Case "INTF"
                        Dr.Item("fut_type") = "Futures"
                        Dr.Item("trade_type") = "Internet Trade"
                    Case "INTO"
                        Dr.Item("fut_type") = "Options"
                        Dr.Item("trade_type") = "Internet Trade"
                    Case "INTB"
                        Dr.Item("fut_type") = "Futures and Options"
                        Dr.Item("trade_type") = "Internet Trade"
                    Case "CONF"
                        Dr.Item("fut_type") = "Futures"
                        Dr.Item("trade_type") = "Consolidate Trade"
                    Case "CONO"
                        Dr.Item("fut_type") = "Options"
                        Dr.Item("trade_type") = "Consolidate Trade"
                    Case "CONB"
                        Dr.Item("fut_type") = "Futures and Options"
                        Dr.Item("trade_type") = "Consolidate Trade"
                    Case "TURNF"
                        Dr.Item("fut_type") = "Futures"
                        Dr.Item("trade_type") = "Turnover"
                    Case "TURNO"
                        Dr.Item("fut_type") = "Options"
                        Dr.Item("trade_type") = "Turnover"
                    Case "BROKF"
                        Dr.Item("fut_type") = "Futures"
                        Dr.Item("trade_type") = "Brokerage"
                    Case "BROKO"
                        Dr.Item("fut_type") = "Options"
                        Dr.Item("trade_type") = "Brokerage"
                    Case "REBATEF"
                        Dr.Item("fut_type") = "Futures"
                        Dr.Item("trade_type") = "Rebate"
                    Case "REBATEO"
                        Dr.Item("fut_type") = "Options"
                        Dr.Item("trade_type") = "Rebate"
                    Case "DEFNORF"
                        Dr.Item("fut_type") = "Futures"
                        Dr.Item("trade_type") = "Normal Trade (Default)"
                    Case "DEFINTF"
                        Dr.Item("fut_type") = "Futures"
                        Dr.Item("trade_type") = "Internet Trade (Default)"
                    Case "DEFNORO"
                        Dr.Item("fut_type") = "Options"
                        Dr.Item("trade_type") = "Normal Trade (Default)"
                    Case "DEFINTO"
                        Dr.Item("fut_type") = "Options"
                        Dr.Item("trade_type") = "Internet Trade (Default)"
                    Case "DEFCONF"
                        Dr.Item("fut_type") = "Futures"
                        Dr.Item("trade_type") = "Consolidate Trade (Default)"
                    Case "DEFCONO"
                        Dr.Item("fut_type") = "Options"
                        Dr.Item("trade_type") = "Consolidate Trade (Default)"
                End Select
                'If Searchdr.Item("rate_type").ToString <> "NORO" And Searchdr.Item("rate_type").ToString <> "INTO" Then
                'Select Case Searchdr.Item("rate_type").ToString.Substring(4, 2)
                '    Case "AL"
                '        Dr.Item("rate_type") = "All"
                '        Dr.Item("rate") = Searchdr.Item("all_rate")
                '    Case "DA"
                '        Dr.Item("rate_type") = "Day"
                '        Dr.Item("rate") = Searchdr.Item("day_rate")
                '    Case "ON"
                '        Dr.Item("rate_type") = "Overnight"
                '        Dr.Item("rate") = Searchdr.Item("night_rate")
                'End Select
                Lot = SearchDt.Select(" acc_no = '" & Dr.Item("acc_no") & "' and product_group = '" & Dr.Item("product_group") & _
                    "' and ae_no = '" & Dr.Item("ae_no") & "' and comm_type = '" & Dr.Item("comm_type") & "' and rate_type = '" & _
                    Searchdr.Item("rate_type") & "' and turnover_from > " & Dr.Item("turnover_from") & " and acc_group = '" & _
                        Dr.Item("acc_group") & "' ", "turnover_from asc")
                Dim from As String = Dr.Item("turnover_from").ToString
                If Lot.Length > 0 Then
                    While from.Length < 10
                        from = from.Insert(0, " ")
                    End While
                    Dim Lotto As String = Lot(0).Item("turnover_from")
                    While from.Length < 10
                        from = from.Insert(0, " ")
                    End While
                    Dr.Item("Lot_range") = ">=" & from & " and < " & Lotto
                Else
                    While from.Length < 9
                        from = from.Insert(0, " ")
                    End While
                    Dr.Item("Lot_range") = ">= " & from
                End If
                'Else
                'Dr.Item("rate") = Searchdr.Item("comm_rate")
                'Lot = SearchDt.Select(" acc_no='" & Dr.Item("acc_no") & "' and product_group='" & Dr.Item("product_group") & "' and ae_no='" & Dr.Item("ae_no") & "' " & _
                '                                    " and comm_type='" & Dr.Item("comm_type") & "' and rate_type='" & Searchdr.Item("rate_type") & "' and turnover_from >" & Dr.Item("turnover_from") & _
                '                                    " and acc_group='" & Dr.Item("acc_group") & "' ", _
                '                                    "turnover_from asc")
                'Dim from As String = Dr.Item("turnover_from").ToString

                'If Lot.Length > 0 Then
                '    While from.Length < 10
                '        from = from.Insert(0, " ")
                '    End While
                '    Dim Lotto As String = Lot(0).Item("turnover_from")
                '    While from.Length < 10
                '        from = from.Insert(0, " ")
                '    End While
                '    Dr.Item("Lot_range") = ">=" & from & " and < " & Lotto
                'Else
                '    While from.Length < 9
                '        from = from.Insert(0, " ")
                '    End While
                '    Dr.Item("Lot_range") = ">= " & from
                'End If
                'End If
                RateDT.Rows.Add(Dr)
            Next
        End If
        Return RateDT
    End Function

    Protected Friend Function GetLatestMonth(ByVal condition As String) As String
        Dim lstrSQL As String = "Select isnull(max(comm_month),0) as comm_month from draft_comm_rate_f where 1=1" & condition
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows(0).Item(0) = 0 Then
            Return Now.Year.ToString & Format(Val(Now.Month) - 1, "00")
        Else
            Return dt.Rows(0).Item(0)
        End If
    End Function

    'Protected Friend Function BatchSave(ByVal BatchDT As DataTable) As Boolean
    '    Dim MyTrans As SqlTransaction = Nothing
    '    Dim lstrSQL As String = ""
    '    Try
    '        MyTrans = GSCnSqlConn.BeginTransaction
    '        For Each BatchDr As DataRow In BatchDT.Rows
    '            Select Case BatchDr.Item("Brsid")
    '                Case 0
    '                    lstrSQL = "Insert into comm_rate_f ( acc_no, acc_group, man_no, man_group, ae_no, product_group, comm_rate, rate_type, turnover_from, day_rate, " & _
    '                                        "night_rate, all_rate, comm_month, comm_type) Values ( " & _
    '                                        BatchDr.Item("condition") & _
    '                                        ")"
    '                Case Else
    '                    lstrSQL = "Update comm_rate_f Set " & BatchDr.Item("condition") & " where rsid =" & BatchDr.Item("Brsid")
    '            End Select

    '            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    '        Next
    '        'GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
    '        MyTrans.Commit()
    '        GSubShowInfo(GFncGetSysMsg(8))
    '    Catch ex As Exception
    '        If GSCnLiqConn.State <> ConnectionState.Closed Then
    '            If (MyTrans IsNot Nothing) Then
    '                MyTrans.Rollback()
    '            End If
    '            GSubWriteErrLog(ex.Message)
    '        End If
    '    End Try
    'End Function

    Private Sub InitRateDT(ByRef DT As DataTable)
        Dim column As DataColumn
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "acc_no"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "acc_group"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "man_no"
        DT.Columns.Add(column)
        'column = New DataColumn
        'column.DataType = System.Type.GetType("System.String")
        'column.ColumnName = "acc_no"
        'DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "man_group"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "ae_no"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "ae_name"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "product_group"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.Decimal")
        column.ColumnName = "comm_rate"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "rate_type"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "fut_type"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.Decimal")
        column.ColumnName = "turnover_from"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "Lot_range"
        DT.Columns.Add(column)
        'column = New DataColumn
        'column.DataType = System.Type.GetType("System.String")
        'column.ColumnName = "rate_type"
        'DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.Decimal")
        column.ColumnName = "day_rate"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.Decimal")
        column.ColumnName = "night_rate"
        DT.Columns.Add(column)
        'column = New DataColumn
        'column.DataType = System.Type.GetType("System.String")
        'column.ColumnName = "all_rate"
        'DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "comm_month"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "comm_type"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.Single")
        column.ColumnName = "rsid"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "acc_name_f"
        DT.Columns.Add(column)
        column = New DataColumn
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "trade_type"
        DT.Columns.Add(column)
    End Sub

    Public Function GfncOneFieldLog(ByVal lstrTitle As String, ByVal lstrFm As String, Optional ByVal lstrTo As String = Nothing) As String
        If IsNothing(lstrTo) Then
            Return "[" & lstrTitle.Trim & "] = '" & lstrFm.Trim & "'"
        Else
            Return "[" & lstrTitle.Trim & "] = '" & lstrFm.Trim & "' To '" & lstrTo.Trim & "' "
        End If
    End Function

    Protected Friend Function lFncGetNextComm(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal ae_no As String, ByVal acc_group As String, ByVal man_no As String, ByVal man_group As String, _
        ByVal prod_code As String, ByVal comm_type As String, ByVal turnover As String) As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet
        lstrSQL = "select min (turnover_from) as mt from draft_comm_rate_f where acc_no = '" & acc_no & "' and ae_no = '" & _
            ae_no & "' and product_group='" & prod_code & "' and rate_type = '" & rate_type & "' and comm_month = '" & _
            comm_month & "' and comm_type = '" & comm_type & "'  and turnover_from > " & turnover
        If acc_group <> Nothing Then
            lstrSQL += " and acc_group='" & acc_group & "' "
        End If
        If man_no <> Nothing Then
            lstrSQL += " and man_no = '" & man_no & "' "
        End If
        If man_group <> Nothing Then
            lstrSQL += " and man_group = '" & man_group & "' "
        End If
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "next_comm")
        Return lds
    End Function

    Protected Friend Function lFnGetAllAccNo(ByVal strMonth As String, Optional ByVal ae_no As String = "") As DataSet
        Dim lstrSQL As String = ""
        'If (UCase(market_type) = market_sec) Then
        lstrSQL = "select distinct a.acc_no, a.acc_name_f from draft_comm_acc_master a inner join draft_comm_acc_master_d b " & _
                " on a.acc_no = b.acc_no and txmonth = '" & strMonth & "' "
        If ae_no <> "" Then
            lstrSQL += " and b.ae_no_f = '" & ae_no & "' "
        End If
        lstrSQL += " where infut=1 order by a.acc_no "
        'ElseIf (UCase(market_type) = market_fut) Then
        'lstrSQL = "select distinct acc_no, acc_name_f from comm_acc_master where inFut=1 order by acc_no "
        'End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "accno")
    End Function

    Protected Friend Sub lFncInsertRate(ByVal acc_no As String, ByVal ae_no As String, ByVal ae_group As String, ByVal rate_type As String, _
        ByVal ProductGroup As String, ByVal turnover_from As String, ByVal comm_rate As String, ByVal day_rate As String, ByVal night_rate As String, _
        ByVal comm_month As String, ByVal comm_type As String, ByRef MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        lstrSQL = "insert into draft_comm_rate_f (acc_no, ae_no, acc_group, rate_type, product_group, turnover_from, " & _
            "comm_rate, day_rate, night_rate, comm_month, comm_type) values ('" & acc_no & "', '" & ae_no & "', '" & ae_group & _
            "', '" & rate_type & "', '" & ProductGroup & "', " & CDbl(turnover_from) & ", " & comm_rate & ", " & day_rate & _
            ", " & night_rate & ", '" & comm_month & "', '" & comm_type & "')"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        Dim logStr As String = GfncOneFieldLog("Account Group", ae_group) & " " & GfncOneFieldLog("Rate Type", rate_type) & " " & _
            GfncOneFieldLog("Product Group", ProductGroup) & " " & GfncOneFieldLog("Turnover From", CDbl(turnover_from)) & " " & _
            GfncOneFieldLog("Commission Rate", comm_rate) & " " & GfncOneFieldLog("Day Rate", day_rate) & " " & _
            GfncOneFieldLog("Night Rate", night_rate) & " " & GfncOneFieldLog("Commission Type", comm_type)
        GFncFillLog(GStrloginID, "A", GDteTradeDate, "CommRateTblFutAcc", ae_no, acc_no, 0, comm_month, logStr, MyTrans)
    End Sub

    Protected Friend Function lFnGetRSID() As String
        Dim lstrSQL As String = ""
        Dim lds As DataSet = Nothing
        lstrSQL = "select max(rsid) as newid from draft_comm_rate_f "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "aeno")
        Return lds.Tables(0).Rows(0).Item(0).ToString
    End Function

    Protected Friend Sub lFncModifyBRate(ByVal rate_type As String, ByVal comm_type As String, ByVal product As String, ByVal turnover_from As String, _
        ByVal comm_rate As String, ByVal day_rate As String, ByVal night_rate As String, ByVal comm_month As String, ByVal ae_no As String, ByRef MyTrans As SqlTransaction)
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_rate_f where rate_type = '" & rate_type & _
            "' and turnover_from = " & CDbl(turnover_from) & " and comm_type = '" & comm_type & "' and ae_no = '" & ae_no & _
            "' and product_group ='" & product & "' and comm_month = '" & comm_month & "' ", MyTrans).Tables(0)
        Dim lstrSQL As String = ""
        lstrSQL = "update draft_comm_rate_f set "
        If comm_rate.Trim.Length > 0 Then
            lstrSQL += " comm_rate = " & comm_rate & " "
        ElseIf day_rate.Trim.Length > 0 And night_rate.Trim.Length > 0 Then
            lstrSQL += " day_rate = " & day_rate & ",  night_rate = " & night_rate & " "
        End If
        lstrSQL += " where rate_type = '" & rate_type & "' and turnover_from = " & CDbl(turnover_from) & " and comm_type = '" & _
            comm_type & "' and ae_no = '" & ae_no & "' and product_group ='" & product & "' and comm_month = '" & comm_month & "' "
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        Dim logstr As String
        For Each dr As DataRow In oldDt.Rows
            logstr = ""
            If comm_rate.Trim <> "" Then
                If GFncNoNullValue(dr("comm_rate")) <> CDbl(comm_rate) Then
                    logstr &= GfncOneFieldLog("Commission Rate", GFncNoNullValue(dr("comm_rate")), CDbl(comm_rate))
                End If
            ElseIf day_rate.Trim.Length > 0 And night_rate.Trim.Length > 0 Then
                If GFncNoNullValue(dr("day_rate")) <> CDbl(day_rate) Then
                    logstr &= GfncOneFieldLog("Day Rate", GFncNoNullValue(dr("day_rate")), CDbl(day_rate))
                End If
                If GFncNoNullValue(dr("night_rate")) <> CDbl(night_rate) Then
                    logstr &= GfncOneFieldLog("Night Rate", GFncNoNullValue(dr("night_rate")), CDbl(night_rate))
                End If
            End If
            GFncFillLog(GStrloginID, "M", GDteTradeDate, "CommRateTblFutAcc", ae_no, GFncNoNullString(dr("acc_no")).Trim, _
                GFncNoNullValue(dr("rsid")), comm_month, logstr, MyTrans)
        Next
    End Sub

    Protected Friend Sub lFncDeleteBRate(ByVal rate_type As String, ByVal comm_type As String, ByVal Prod As String, ByVal turnover_from As String, _
        ByVal comm_month As String, ByVal ae_no As String, ByRef MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_rate_f where rate_type = '" & rate_type & _
            "' and turnover_from = " & CDbl(turnover_from) & " and comm_type = '" & comm_type & "' and ae_no = '" & ae_no & _
            "' and comm_month = '" & comm_month & "' and product_group ='" & Prod & "'", MyTrans).Tables(0)
        lstrSQL = "delete draft_comm_rate_f where rate_type = '" & rate_type & "' and turnover_from = " & CDbl(turnover_from) & _
            " and comm_type = '" & comm_type & "' and ae_no = '" & ae_no & "' and comm_month = '" & comm_month & _
            "' and product_group ='" & Prod & "' "
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        Dim logstr As String = GfncOneFieldLog("Rate Type", rate_type) & " " & _
            GfncOneFieldLog("Turnover From", CDbl(turnover_from)) & " " & GfncOneFieldLog("Commission Type", comm_type) & " " & _
            GfncOneFieldLog("Product Group", Prod)
        For Each dr As DataRow In oldDt.Rows
            GFncFillLog(GStrloginID, "D", GDteTradeDate, "CommRateTblFutAcc", ae_no, GFncNoNullString(dr("acc_no")).Trim, _
                GFncNoNullValue(dr("rsid")), comm_month, logstr, MyTrans)
        Next
    End Sub

End Class
