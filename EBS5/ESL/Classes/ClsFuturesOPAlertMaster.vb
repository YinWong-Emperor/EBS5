Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class ClsFuturesOPAlertMaster
    Dim EmailDT As DataTable
    Dim clsRpt As New ClsReports

    Protected Friend Function GetMkt() As DataSet
        Dim query As String = "select distinct market from futures_product_master "
        Return GFncRtnDS(GSCnSqlConn, query)
    End Function

    Protected Friend Function SearchAlert(ByVal condition As String) As DataSet
        Dim query As String = "Select product_code, product_name, position_limit, market, email_alert, " & _
        "case when gross_net='N' then 'Net' when gross_net ='G' then 'Gross' else 'Net' end gross_net, month_alert, " & _
        " isnull(position_limit_2, 0) as position_limit_2, isnull(email_alert_2, 0) as email_alert_2 " & _
        " from futures_product_master where 1=1 " & condition & " order by product_code asc"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, query)
        Return ds
    End Function

    Protected Friend Function ModifyProductMaster(ByVal Code As String, ByVal Condition As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing

        Dim sql As String = "Update futures_product_master Set " & Condition & " where product_code ='" & Code & "'"
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sql, 0)
            'GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
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

    Protected Friend Function EmailRefresh() As DataTable
        Dim query As String = "Select misc_desc as Email from misc_master where misc_type='MAILALERT' and misc_code= 'PRODUCT'"
        EmailDT = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        Return EmailDT
    End Function

    Protected Friend Function CheckExistEmail(ByVal address As String) As Boolean

    End Function

    Protected Friend Function EmailAdd(ByVal Address As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlDel As String = " Delete from misc_master where misc_type='MAILALERT' and  misc_code='PRODUCT'"
        Dim sql As String = " Insert into misc_master (misc_type, misc_code, misc_desc) Values ( 'MAILALERT', 'PRODUCT', "
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sqlDel, 0)
            For row As Integer = 0 To EmailDT.Rows.Count - 1
                GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim & "')", 0)
            Next
            GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & Address.ToLower.Trim & "')", 0)

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

    Protected Friend Function EmailAdjust(ByVal OldAddress As String, ByVal NewAddress As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlDel As String = " Delete from misc_master where misc_type='MAILALERT' and  misc_code='PRODUCT'"
        Dim sql As String = " Insert into misc_master (misc_type, misc_code, misc_desc) Values ( 'MAILALERT', 'PRODUCT', "
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sqlDel, 0)
            For row As Integer = 0 To EmailDT.Rows.Count - 1
                If EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim = OldAddress.ToLower.Trim Then
                    GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & NewAddress.ToLower.Trim & "')", 0)
                Else
                    GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim & "')", 0)
                End If
            Next

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

    Protected Friend Function EmailDel(ByVal Address As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlDel As String = " Delete from misc_master where misc_type='MAILALERT' and  misc_code='PRODUCT'"
        Dim sql As String = " Insert into misc_master (misc_type, misc_code, misc_desc) Values ( 'MAILALERT', 'PRODUCT', "
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sqlDel, 0)
            For row As Integer = 0 To EmailDT.Rows.Count - 1
                If EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim <> Address.ToLower.Trim Then
                    GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim & "')", 0)
                End If
            Next

            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(13))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
    End Function

    'Protected Friend Function EmailDelAll() As Boolean
    '    Dim MyTrans As SqlTransaction = Nothing
    '    Dim sql As String = "Delete from misc_master where misc_type='MAILALERT' and  misc_code='PRODUCT'"
    '    Try
    '        MyTrans = GSCnSqlConn.BeginTransaction
    '        GFncRunSQL(GSCnSqlConn, MyTrans, sql, 0)
    '        'GFncRunSQL(GSCnSqlConn, MyTrans, sql_log, 0)
    '        MyTrans.Commit()
    '        MyTrans = Nothing
    '        'GSubShowInfo(GFncGetSysMsg(13))
    '    Catch ex As Exception
    '        If GSCnLiqConn.State <> ConnectionState.Closed Then
    '            If (MyTrans IsNot Nothing) Then
    '                MyTrans.Rollback()
    '            End If
    '            GSubWriteErrLog(ex.Message)
    '        End If
    '    End Try
    'End Function


    Protected Friend Function CurrentEmail(ByVal address As String) As Boolean
        Dim query As String = "Select misc_desc as Email from misc_master where misc_type='MAILALERT' and misc_code= 'PRODUCT' and misc_desc='" & address & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Protected Friend Function GetSysdate() As Date
        Dim sql As String = " select max(sysdate) from futuresopenpost"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, sql).Tables(0)
        Return dt.Rows(0).Item(0)
    End Function

    Protected Friend Function GetError(ByVal condition As String, ByVal Type As String) As DataSet
        'Dim sql As String = " select max(sysdate) from FuturesOpenPost"
        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, sql).Tables(0)
        'Dim sysdate As Date = dt.Rows(0).Item(0)

        'Dim lstrSQL As String = "select * from futures_product_master"
        Dim lstrSQL As String = "select counterparty, code, position_limit, position_limit_2, qty, cal_type from (" & _
                   "select counterparty, code, position_limit,position_limit_2, " & _
            "case when gross_net = 'G' then 'Gross Open Position' else 'Net Open Position' end as cal_type, " & _
           "case when gross_net = 'G' then (case when long > short then long else short end) else abs(long-short) end as qty " & _
          "from (select counterparty, code, " & _
          "sum(case when type=1 then qty else 0 end) as long, sum(case when type=2 then qty else 0 end) as short, " & _
               "gross_net, case when email_alert = 1 then position_limit else null end as position_limit , " & _
               " case when email_alert_2 = 1 then position_limit_2 else null end as position_limit_2 " & _
               " from FuturesOpenPost, futures_product_master " & _
               "where code = product_code collate database_default and (email_alert = 1 or email_alert_2 = 1) " & _
                        "group by counterparty, code, gross_net, email_alert, position_limit, email_alert_2, position_limit_2) a " & _
                  ") b where 1=1 " & condition
        Select Case Type
            Case "Error"
                lstrSQL += " and (qty>position_limit or qty>position_limit_2 ) "
        End Select

        lstrSQL += " order by counterparty, code "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL)

    End Function

    Protected Friend Function PrintErrRpt(ByVal sysdate As Date, ByVal Type As String) As ReportClass
        Dim ldtsTemp As New DataTable
        InitErrDT(ldtsTemp)
        Dim ErrDr As DataRow
        Dim rpt As New RptFuturesOPErr
        Dim lstrSQL As String

        lstrSQL = "select counterparty, code, position_limit,position_limit_2, long, short," & _
                            "case when gross_net = 'G' then 'Gross Open Position' else 'Net Open Position' end as cal_type, " & _
                            "case when gross_net = 'G' then (case when long > short then long else short end) else abs(long-short) end as qty " & _
                            "from (select counterparty, code, " & _
                            "sum(case when type=1 then qty else 0 end) as long, sum(case when type=2 then qty else 0 end) as short, " & _
                            "gross_net, case when email_alert = 1 then position_limit else -1 end as position_limit , " & _
                           " case when isnull(email_alert_2, 0) = 1 then isnull(position_limit_2, 0) else -1 end as position_limit_2 " & _
                            " from FuturesOpenPost, futures_product_master " & _
                            "where code = product_code collate database_default and (email_alert = 1 or isnull(email_alert_2, 0) = 1)  " & _
                            "group by counterparty, code, gross_net, email_alert, position_limit, " & _
                            " email_alert_2 , position_limit_2) a  order by counterparty, code"
        'Dim lstrSQL As String = "select counterparty, code, cal_type, position_limit, qty, diff from (" & _
        '                                              "select counterparty, code, 'Net OP' as cal_type, position_limit, " & _
        '                                              "abs(sum(case when type = 1 then qty else qty * -1 end)) as qty, " & _
        '                                              "case when position_limit - abs(sum(case when type = 1 then qty else qty * -1 end)) < 0 then 'E' else 'N' end as diff " & _
        '                                              "from futuresopalert, futures_product_master " & _
        '                                              "where futuresopalert.code = futures_product_master.product_code and gross_net = 'N' " & _
        '                                              "and convert(nvarchar(20), lupdtdate, 103) = convert(nvarchar(20), getdate(), 103) " & _
        '                                              "group by counterparty, code, position_limit " & _
        '                                              "union select counterparty, code,  'Gross OP' as cal_type, position_limit, max(qty) as qty, " & _
        '                                              "case when position_limit - max(qty) < 0 then 'E' else 'N' end as diff " & _
        '                                              "from futuresopalert, futures_product_master " & _
        '                                              "where futuresopalert.code = futures_product_master.product_code and gross_net = 'G' " & _
        '                                              "and sysdate ='" & Format(sysdate, "yyyy/MM/dd") & "' " & _
        '                                              "group by counterparty, code, position_limit" & _
        '                                              " ) a "
        Dim ErrDT As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        For Each dr As DataRow In ErrDT.Rows
            ErrDr = ldtsTemp.NewRow
            ErrDr.Item("datatype") = "Sum"
            ErrDr.Item("counterparty") = dr.Item("counterparty")
            ErrDr.Item("code") = dr.Item("code")
            ErrDr.Item("cal_type") = dr.Item("cal_type")
            ErrDr.Item("position_limit") = dr.Item("position_limit")
            ErrDr.Item("position_limit_2") = dr.Item("position_limit_2")
            ErrDr.Item("qty") = dr.Item("qty")
            ErrDr.Item("long") = dr.Item("long")
            ErrDr.Item("short") = dr.Item("short")
            'ErrDr.Item("diff") = dr.Item("diff")
            ldtsTemp.Rows.Add(ErrDr)
            If (dr.Item("position_limit") > -1 And dr.Item("qty") > dr.Item("position_limit")) Then
                ErrDr = ldtsTemp.NewRow
                ErrDr.Item("datatype") = "TError"
                ErrDr.Item("counterparty") = dr.Item("counterparty")
                ErrDr.Item("code") = dr.Item("code")
                ErrDr.Item("cal_type") = dr.Item("cal_type")
                ErrDr.Item("position_limit") = dr.Item("position_limit")
                ErrDr.Item("qty") = dr.Item("qty")
                ErrDr.Item("long") = dr.Item("long")
                ErrDr.Item("short") = dr.Item("short")

                'ErrDr.Item("diff") = dr.Item("diff")
                ldtsTemp.Rows.Add(ErrDr)
            End If
            If (dr.Item("position_limit_2") > -1 And dr.Item("qty") > dr.Item("position_limit_2")) Then
                ErrDr = ldtsTemp.NewRow
                ErrDr.Item("datatype") = "TError2"
                ErrDr.Item("counterparty") = dr.Item("counterparty")
                ErrDr.Item("code") = dr.Item("code")
                ErrDr.Item("cal_type") = dr.Item("cal_type")
                ErrDr.Item("position_limit") = dr.Item("position_limit_2")
                ErrDr.Item("qty") = dr.Item("qty")
                ErrDr.Item("long") = dr.Item("long")
                ErrDr.Item("short") = dr.Item("short")

                'ErrDr.Item("diff") = dr.Item("diff")
                ldtsTemp.Rows.Add(ErrDr)
            End If
        Next
        If Type = "Full" Then
            lstrSQL = "select counterparty, code, type, tdate, market_name, accno, monthcode , sum(qty)as qty from futuresopenpost " & _
                                "group by counterparty, code, type, tdate, market_name, accno, monthcode "
            Dim DetailDT As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
            lstrSQL = " select counterparty, code,  tdate, market_name, accno, monthcode from futuresopenpost group by counterparty, code, tdate, market_name, accno, monthcode order by counterparty asc, code asc, monthcode asc, tdate asc, accno asc"
            Dim GroupDetailDT As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
            Dim DetailDr() As DataRow
            For Each dr As DataRow In GroupDetailDT.Rows
                ErrDr = ldtsTemp.NewRow
                ErrDr.Item("datatype") = "Detail"
                ErrDr.Item("counterparty") = dr.Item("counterparty")
                ErrDr.Item("code") = dr.Item("code")
                ErrDr.Item("tdate") = dr.Item("tdate")
                ErrDr.Item("marketname") = dr.Item("market_name")
                'ErrDr.Item("cal_type") = ReturnType(dr.Item("type"))
                ErrDr.Item("monthcode") = dr.Item("monthcode")
                ErrDr.Item("accno") = dr.Item("accno")
                ErrDr.Item("long") = 0
                ErrDr.Item("short") = 0
                DetailDr = DetailDT.Select("counterparty='" & dr.Item("counterparty") & "' and code='" & dr.Item("code") & "' and tdate='" & dr.Item("tdate") & "' and market_name ='" & dr.Item("market_name") & "' " & _
                                                " and monthcode ='" & dr.Item("monthcode") & "' and accno ='" & dr.Item("accno") & "'")

                For i As Integer = 0 To DetailDr.Length - 1
                    If DetailDr(i).Item("type") = "1" Then
                        ErrDr.Item("long") = DetailDr(i).Item("qty")
                    End If
                    If DetailDr(i).Item("type") = "2" Then
                        ErrDr.Item("short") = DetailDr(i).Item("qty")
                    End If
                Next


                ldtsTemp.Rows.Add(ErrDr)
            Next
        End If
        'lstrSQL = "select counterparty, code, cal_type, position_limit, qty, diff from (" & _
        '                                                     "select counterparty, code, 'Net OP' as cal_type, position_limit, " & _
        '                                                     "abs(sum(case when type = 1 then qty else qty * -1 end)) as qty, " & _
        '                                                     "case when position_limit - abs(sum(case when type = 1 then qty else qty * -1 end)) < 0 then 'E' else 'N' end as diff " & _
        '                                                     "from futuresopalert, futures_product_master " & _
        '                                                     "where futuresopalert.code = futures_product_master.product_code and gross_net = 'N' " & _
        '                                                     "and convert(nvarchar(20), lupdtdate, 103) = convert(nvarchar(20), getdate(), 103) " & _
        '                                                     "group by counterparty, code, position_limit " & _
        '                                                     "union select counterparty, code,  'Gross OP' as cal_type, position_limit, max(qty) as qty, " & _
        '                                                     "case when position_limit - max(qty) < 0 then 'E' else 'N' end as diff " & _
        '                                                     "from futuresopalert, futures_product_master " & _
        '                                                     "where futuresopalert.code = futures_product_master.product_code and gross_net = 'G' " & _
        '                                                     "and sysdate ='" & Format(sysdate, "yyyy/MM/dd") & "' " & _
        '                                                     "group by counterparty, code, position_limit" & _
        '                                                     " ) a where diff='E' "
        'Dim Err As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        'For Each dr As DataRow In Err.Rows
        '    ErrDr = ldtsTemp.NewRow
        '    ErrDr.Item("datatype") = "TError"
        '    ErrDr.Item("counterparty") = dr.Item("counterparty")
        '    ErrDr.Item("code") = dr.Item("code")
        '    ErrDr.Item("cal_type") = dr.Item("cal_type")
        '    ErrDr.Item("position_limit") = dr.Item("position_limit")
        '    ErrDr.Item("qty") = dr.Item("qty")
        '    ErrDr.Item("diff") = dr.Item("diff")
        '    ldtsTemp.Rows.Add(ErrDr)
        'Next


        rpt.SetDataSource(ldtsTemp)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        clsRpt.AddParam(rpt, "paraSysdate", sysdate)
        Return rpt
    End Function

    Private Sub InitErrDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "datatype"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "monthcode"
        DT.Columns.Add(Column)
        Column = New DataColumn

        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "tdate"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "marketname"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "long"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "short"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "qty"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "position_limit"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "position_limit_2"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "cal_type"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "code"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "counterparty"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accno"
        DT.Columns.Add(Column)

    End Sub

    'Private Function ReturnType(ByVal type As String) As String
    '    Select Case type
    '        Case 1
    '            Return "Long"
    '        Case 2
    '            Return "Sell"
    '        Case Else
    '            Return ""
    '    End Select
    'End Function

End Class
