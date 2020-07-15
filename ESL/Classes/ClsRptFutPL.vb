Public Class ClsRptFutPL

    Protected Friend Sub InitManagerDTF(ByRef DT As DataTable)
        Dim Column As DataColumn
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accno"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accname"
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
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_comm_w1"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_comm_w2"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_comm_w3"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_comm_w4"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_comm_w5"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_comm_total"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "floating_w1"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "floating_w2"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "floating_w3"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "floating_w4"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "floating_w5"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_w1"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_w2"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_w3"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_w4"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "pl_w5"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_w1"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_w2"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_w3"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_w4"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_w5"
        DT.Columns.Add(Column)
    End Sub

    Protected Friend Function lFncInitDatarow(ByRef dr As DataRow) As Boolean
        dr("accno") = ""
        dr("accname") = ""
        dr("aeno") = ""
        dr("aename") = ""
        dr("pl_comm_w1") = 0
        dr("pl_comm_w2") = 0
        dr("pl_comm_w3") = 0
        dr("pl_comm_w4") = 0
        dr("pl_comm_w5") = 0
        dr("pl_comm_total") = 0
        dr("floating_w1") = 0
        dr("floating_w2") = 0
        dr("floating_w3") = 0
        dr("floating_w4") = 0
        dr("floating_w5") = 0
        dr("pl_w1") = 0
        dr("pl_w2") = 0
        dr("pl_w3") = 0
        dr("pl_w4") = 0
        dr("pl_w5") = 0
        dr("comm_w1") = 0
        dr("comm_w2") = 0
        dr("comm_w3") = 0
        dr("comm_w4") = 0
        dr("comm_w5") = 0
    End Function

    Protected Friend Function lFncDropTempTbl() As Long
        Dim lstrSQL As String = ""
        lstrSQL = "drop table #rate_table "
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
    End Function

    Protected Friend Function lFncCreateExchangeRateTbl(ByVal endDate As Date) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "select b.name_s as from_name, c.name_s as to_name, a.cuid as from_id, a.cuid_ex as to_id, a.last " & _
                    "into #rate_table " & _
                    "from " & GStrG2BFDB & ".dbo.currency_exchange a " & _
                    "inner join " & GStrG2BFDB & ".dbo.currency_master b on a.cuid = b.cuid " & _
                    "inner join " & GStrG2BFDB & ".dbo.currency_master  c on a.cuid_ex = c.cuid " & _
                    "left join " & GStrG2BFDB & ".dbo.hist_currency_exchange d on a.cuid = d.cuid and a.cuid_ex = d.cuid_ex " & _
                    "where c.name_s = 'HKD' and d.cuid is null union " & _
                    "select c.name_s, d.name_s, a.cuid, a.cuid_ex, a.rate_new " & _
                    "from " & GStrG2BFDB & ".dbo.hist_currency_exchange a " & _
                    "inner join (select cuid, cuid_ex, max(date_upd) as mdate " & _
                    "from " & GStrG2BFDB & ".dbo.hist_currency_exchange " & _
                    "where date_upd <'" & Format(DateAdd(DateInterval.Day, 1, endDate), "yyyyMMdd") & "' group by cuid, cuid_ex) b " & _
                    "on a.cuid = b.cuid and a.cuid_ex = b.cuid_ex and a.date_upd = b.mdate " & _
                    "inner join " & GStrG2BFDB & ".dbo.currency_master c on a.cuid = c.cuid " & _
                    "inner join " & GStrG2BFDB & ".dbo.currency_master d on a.cuid_ex = d.cuid " & _
                    "where d.name_s = 'HKD' "
        Return GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
    End Function

    Protected Friend Function lFncGetTDate() As Date
        Dim lstrSQL As String = ""
        lstrSQL = "select tradedate from " & GStrG2BFDB & ".dbo.system_parameter where cmid = '999' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0).Rows(0).Item("tradedate")
    End Function

    Protected Friend Function lFncGetOpenPostDate() As DataTable
        Dim lstrSQL As String = ""
        lstrSQL = "select distinct sysdate from " & GStrG2BFDB & ".dbo.open_pos_hist "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
    End Function

    Protected Friend Function lFncGetFloating(ByVal lastDate As Date, ByVal tdate As Date) As DataTable
        Dim lstrSQL As String = ""
        lstrSQL = "select f.accno, sum((case when a.type = 1 then 1 else -1 end) * b.qty " & _
                    "* (isnull(d.price, c.cprice) - b.price) * e.contract_size * g.last) as floating " & _
                    "from (select type, cast('" & Format(lastDate, "yyyyMMdd") & "' as datetime) as tdate, oid, ctid, " & _
                    "aid, cuid_chrg from " & GStrG2BFDB & ".dbo.open_pos union select type, sysdate as tdate, oid, ctid, " & _
                    "aid, cuid_chrg from " & GStrG2BFDB & ".dbo.open_pos_hist) a " & _
                    "left join (select cast('" & Format(lastDate, "yyyyMMdd") & "' as datetime) as tdate, oid, qty, price " & _
                    "from " & GStrG2BFDB & ".dbo.open_pos_d union select sysdate as tdate, oid, qty, price from " & _
                    GStrG2BFDB & ".dbo.open_pos_hist_d) b on  a.tdate = b.tdate and a.oid = b.oid " & _
                    "left join " & GStrG2BFDB & ".dbo.contract_master c on a.ctid = c.ctid " & _
                    "left join " & GStrG2BFDB & ".dbo.hist_close_price d on a.tdate = d.sysdate " & _
                    "and a.ctid = d.ctid and d.cmid = '999' " & _
                    "left join " & GStrG2BFDB & ".dbo.commod_master e on c.cyid = e.cyid " & _
                    "left join " & GStrG2BFDB & ".dbo.client_master f on a.aid = f.aid " & _
                    "left join #rate_table g on a.cuid_chrg = g.from_id " & _
                    "where a.tdate = '" & Format(tdate, "yyyyMMdd") & "' " & _
                    "group by accno "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
    End Function

    Protected Friend Function lFncGetPL(ByVal from_date As Date, ByVal to_date As Date) As DataTable
        Dim lstrSQL As String = ""
        lstrSQL = "select b.accno, sum(c.last * pl) as pl " & _
                    "from " & GStrG2BFDB & ".dbo.close_pos a " & _
                    "left join " & GStrG2BFDB & ".dbo.client_master b on a.aid = b.aid " & _
                    "left join " & GStrG2BFDB & ".dbo.#rate_table c on a.cuid_chrg = c.from_id " & _
                    "where vdate >= '" & Format(from_date, "yyyyMMdd") & "' and vdate <= '" & _
                    Format(to_date, "yyyyMMdd") & "' group by b.accno "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
    End Function

    Protected Friend Function lFncGetComm(ByVal from_date As Date, ByVal to_date As Date) As DataTable
        Dim lstrSQL As String = ""
        Dim ldsComm As DataSet = Nothing

        lstrSQL = "select * into #trade from " & GStrG2BFDB & ".dbo.view_IT_G2B_client_trade_dt_with_comm"
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
        lstrSQL = "select a.accno, sum(a.comm * b.last) * -1 as comm " & _
                    "from #trade a " & _
                    "left join #rate_table b on a.charge_currency = b.from_name " & _
                    "where a.tdate >= '" & Format(from_date, "yyyyMMdd") & _
                    "' and  a.tdate <= '" & Format(to_date, "yyyyMMdd") & "' " & _
                    "group by a.accno "
        ldsComm = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        lstrSQL = "drop table #trade "
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        Return ldsComm.Tables(0)
    End Function

    Protected Friend Function lFncGetAccInfo() As DataTable
        Dim lstrSQL As String = ""
        lstrSQL = "select rtrim(a.accno) as accno, rtrim(a.name_1) as accname, rtrim(c.aeno) as aeno, rtrim(c.name) as aename " & _
                    "from " & GStrG2BFDB & ".dbo.client_master a " & _
                    "left join " & GStrG2BFDB & ".dbo.client_master_f b on a.aid = b.aid " & _
                    "left join " & GStrG2BFDB & ".dbo.ae_master c on b.aeid = c.aeid "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
    End Function

    Protected Friend Sub lFncAssignFloating(ByRef ldtClient As DataTable, ByVal ldtFloat As DataTable, ByVal column_name As String)
        For i As Integer = 0 To ldtFloat.Rows.Count - 1
            Dim accno As String = ldtFloat.Rows(i).Item("accno")
            Dim ldrClient As DataRow() = ldtClient.Select(" accno = '" & Trim(accno) & "' ")

            If (ldrClient.Length > 0) Then
                ldrClient(0).Item(column_name) = ldtFloat.Rows(i).Item("floating")
            Else
                Dim ldr As DataRow = ldtClient.NewRow
                lFncInitDatarow(ldr)
                ldr("accno") = accno
                ldr(column_name) = ldtFloat.Rows(i).Item("floating")
                ldtClient.Rows.Add(ldr)
            End If
        Next
    End Sub

    Protected Friend Sub lFncAssignPL(ByRef ldtClient As DataTable, ByVal ldtPL As DataTable, _
                                        ByVal column_name1 As String, ByVal column_name2 As String)
        For i As Integer = 0 To ldtPL.Rows.Count - 1
            Dim accno As String = ldtPL.Rows(i).Item("accno")
            Dim ldrClient As DataRow() = ldtClient.Select(" accno = '" & Trim(accno) & "' ")

            If (ldrClient.Length > 0) Then
                ldrClient(0).Item(column_name1) = ldtPL.Rows(i).Item("pl")
                ldrClient(0).Item(column_name2) += ldtPL.Rows(i).Item("pl")
                ldrClient(0).Item("pl_comm_total") += ldtPL.Rows(i).Item("pl")
            Else
                Dim ldr As DataRow = ldtClient.NewRow
                lFncInitDatarow(ldr)
                ldr("accno") = accno
                ldr(column_name1) = ldtPL.Rows(i).Item("pl")
                ldr(column_name2) += ldtPL.Rows(i).Item("pl")
                ldr("pl_comm_total") += ldtPL.Rows(i).Item("pl")
                ldtClient.Rows.Add(ldr)
            End If
        Next
    End Sub

    Protected Friend Sub lFncAssignComm(ByRef ldtClient As DataTable, ByVal ldtComm As DataTable, _
                                        ByVal column_name1 As String, ByVal column_name2 As String)
        For i As Integer = 0 To ldtComm.Rows.Count - 1
            Dim accno As String = ldtComm.Rows(i).Item("accno")
            Dim ldrClient As DataRow() = ldtClient.Select(" accno = '" & Trim(accno) & "' ")

            If (ldrClient.Length > 0) Then
                ldrClient(0).Item(column_name1) = GFncNoNullValue(ldtComm.Rows(i).Item("comm"))
                ldrClient(0).Item(column_name2) += GFncNoNullValue(ldtComm.Rows(i).Item("comm"))
                ldrClient(0).Item("pl_comm_total") += GFncNoNullValue(ldtComm.Rows(i).Item("comm"))
            Else
                Dim ldr As DataRow = ldtClient.NewRow
                lFncInitDatarow(ldr)
                ldr("accno") = accno
                ldr(column_name1) = GFncNoNullValue(ldtComm.Rows(i).Item("comm"))
                ldr(column_name2) += GFncNoNullValue(ldtComm.Rows(i).Item("comm"))
                ldr("pl_comm_total") += GFncNoNullValue(ldtComm.Rows(i).Item("comm"))
                ldtClient.Rows.Add(ldr)
            End If
        Next
    End Sub

    Protected Friend Function lFncGetClientPL(ByVal eDate As Date) As DataTable
        Dim ldtClient As New DataTable
        InitManagerDTF(ldtClient)
        Dim lastTDate As Date = lFncGetTDate()
        lFncCreateExchangeRateTbl(eDate)

        Dim ldtOpenPostDate As DataTable = lFncGetOpenPostDate()
        For i As Integer = 0 To 4
            Application.DoEvents()
            Dim tmpDate As Date = DateAdd(DateInterval.Day, -7 * i, eDate)
            Dim ldrOpenPostDate As DataRow() = ldtOpenPostDate.Select(" sysdate <= #" & Format(tmpDate.Date, "yyyy/MM/dd") & "# ", " sysdate desc ")
            tmpDate = ldrOpenPostDate(0).Item("sysdate")
            Dim ldtFloating As DataTable = lFncGetFloating(lastTDate, tmpDate)
            lFncAssignFloating(ldtClient, ldtFloating, "floating_w" & CStr(i + 1))
        Next

        For i As Integer = 0 To 4
            Application.DoEvents()
            Dim fromDate As Date = CDate(Format(DateAdd(DateInterval.Day, (-7 * (i + 1)) + 1, eDate), "yyyy/MM/dd"))
            Dim toDate As Date = CDate(Format(DateAdd(DateInterval.Day, -7 * i, eDate), "yyyy/MM/dd"))

            Application.DoEvents()
            Dim ldtPL As DataTable = lFncGetPL(fromDate, toDate)
            lFncAssignPL(ldtClient, ldtPL, "pl_w" & CStr(i + 1), "pl_comm_w" & CStr(i + 1))
            Dim ldtComm As DataTable = lFncGetComm(fromDate, toDate)
            lFncAssignComm(ldtClient, ldtComm, "comm_w" & CStr(i + 1), "pl_comm_w" & CStr(i + 1))
        Next

        Dim ldtAccInfo As DataTable = lFncGetAccInfo()
        For i As Integer = 0 To ldtClient.Rows.Count - 1
            Dim accno As String = ldtClient.Rows(i).Item("accno").ToString.Trim
            Dim ldrAccInfo As DataRow() = ldtAccInfo.Select(" accno = '" & accno & "' ")
            If (ldrAccInfo.Length > 0) Then
                ldtClient.Rows(i).Item("accname") = ldrAccInfo(0).Item("accname")
                ldtClient.Rows(i).Item("aeno") = ldrAccInfo(0).Item("aeno")
                ldtClient.Rows(i).Item("aename") = ldrAccInfo(0).Item("aename")
            End If
        Next

        lFncDropTempTbl()
        Return ldtClient
    End Function

End Class
