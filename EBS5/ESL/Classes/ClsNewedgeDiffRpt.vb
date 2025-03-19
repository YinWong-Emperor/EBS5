Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsNewedgeDiffRpt
    Dim clsRpt As New ClsReports

    Protected Friend Function IFncGetTrade(ByVal InDate As Date, ByVal pCounterParty As String) As DataTable
        Dim TradeDt As New DataTable
        InitTradeDT(TradeDt)
        Dim query As String
        Dim TradeDr As DataRow
        'query = "select sum(buy) as buy, sum(sell) as sell, product, monthcode from newedge_cap_op  " & _
        '    "where tdate='" & Format(InDate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode order by product asc, monthcode asc"
        query = "select sum(buy) as buy, sum(sell) as sell, product, monthcode from vw_cap_op  " & _
                "where tdate='" & Format(InDate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode order by product asc, monthcode asc"
        Dim Dt As DataTable = GFncRtnDS(GSCnSqlConn, query, "capTrade").Tables(0)
        For Each dr As DataRow In Dt.Rows
            TradeDr = TradeDt.NewRow
            TradeDr.Item("CapBuy") = dr.Item("buy")
            TradeDr.Item("CapSell") = dr.Item("sell")
            TradeDr.Item("CapTDate") = InDate
            TradeDr.Item("Capmonthcode") = dr.Item("monthcode")
            TradeDr.Item("CapProduct") = dr.Item("product")
            TradeDt.Rows.Add(TradeDr)
        Next
        query = "select sum(buy) as buy, sum(sell) as sell, product, monthcode from newedge_emp_op  where tdate='" & Format(InDate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode order by product asc, monthcode asc"
        Dt = GFncRtnDS(GSCnSqlConn, query, "empTrade").Tables(0)
        For i As Integer = 0 To Dt.Rows.Count - 1
            If i > TradeDt.Rows.Count - 1 Then
                TradeDt.Rows.Add()
            End If
            TradeDt.Rows(i).Item("empBuy") = Dt.Rows(i).Item("buy")
            TradeDt.Rows(i).Item("empSell") = Dt.Rows(i).Item("sell")
            TradeDt.Rows(i).Item("empTDate") = InDate
            TradeDt.Rows(i).Item("empmonthcode") = Dt.Rows(i).Item("monthcode")
            TradeDt.Rows(i).Item("empProduct") = Dt.Rows(i).Item("product")
        Next


        'query = "Select monthcode, product, capBuy, empBuy, capSell, empSell from (select b.monthcode, b.product, isnull(capBuy,0) as capBuy, isnull(capSell,0) as capSell , isnull(empBuy,0) as empBuy,  isnull(empSell,0)as empSell from " & _
        '            "(select sum(buy) as capBuy, sum(sell)as capSell, monthcode, product " & _
        '             " from newedge_cap_OP " & _
        '            "where tdate='" & Format(InDate, "MM/dd/yyyy") & "' group by product, monthcode) a" & _
        '             " full Join " & _
        '            "(select sum(buy) as empBuy, sum(sell)as empSell, monthcode, product " & _
        '             " from newedge_emp_OP " & _
        '            "where tdate='" & Format(InDate, "MM/dd/yyyy") & "' group by product, monthcode) b " & _
        '            "on (a.product=b.product and a.monthcode=b.monthcode)) c order by product, monthcode"
        Return TradeDt

    End Function


    Protected Friend Function IFncGetTradeDiff(ByVal InDate As Date, ByVal pCounterParty As String) As DataSet
        Dim query As String
        'query = "Select monthcode, product, capBuy, empBuy, capSell, empSell from (select b.monthcode, b.product, isnull(capBuy,0) as capBuy, isnull(capSell,0) as capSell , isnull(empBuy,0) as empBuy,  isnull(empSell,0)as empSell from " & _
        '            "(select sum(buy) as capBuy, sum(sell)as capSell, monthcode, product " & _
        '             " from newedge_cap_OP " & _
        '            "where tdate='" & Format(InDate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode) a" & _
        '             " full Join " & _
        '            "(select sum(buy) as empBuy, sum(sell)as empSell, monthcode, product " & _
        '             " from newedge_emp_OP " & _
        '            "where tdate='" & Format(InDate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode) b " & _
        '            "on (a.product=b.product and a.monthcode=b.monthcode)) c where capBuy<>empBuy or capSell <> empSell order by product, monthcode"
        query = "Select monthcode, product, capBuy, empBuy, capSell, empSell from (select b.monthcode, b.product, isnull(capBuy,0) as capBuy, isnull(capSell,0) as capSell , isnull(empBuy,0) as empBuy,  isnull(empSell,0)as empSell from " & _
                  "(select sum(buy) as capBuy, sum(sell)as capSell, monthcode, product " & _
                   " from vw_cap_OP " & _
                  "where tdate='" & Format(InDate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode) a" & _
                   " full Join " & _
                  "(select sum(buy) as empBuy, sum(sell)as empSell, monthcode, product " & _
                   " from newedge_emp_OP " & _
                  "where tdate='" & Format(InDate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode) b " & _
                  "on (a.product=b.product and a.monthcode=b.monthcode)) c where capBuy<>empBuy or capSell <> empSell order by product, monthcode"
        Return GFncRtnDS(GSCnSqlConn, query, "TradeDiff")
    End Function

    Protected Friend Function lFnGetComm(ByVal tdate As Date, ByVal pCounterParty As String) As DataTable
        Dim lstrSQL As String
        Dim CommDt As New DataTable
        InitCommDT(CommDt)
        Dim CommDr As DataRow
        'lstrSQL = "select monthcode, product, sum(comm) as comm, sum(clearing)as clearing, sum(levy) as levy from newedge_cap_trade_hist " & _
        '            "where tdate='" & Format(tdate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode order by product asc, monthcode asc"
        lstrSQL = "select monthcode, product, sum(comm) as comm, sum(clearing)as clearing, sum(levy) as levy from vw_cap_trade_hist " & _
                    "where tdate='" & Format(tdate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode order by product asc, monthcode asc"
        Dim Dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL, "CalComm").Tables(0)
        For Each dr As DataRow In Dt.Rows
            CommDr = CommDt.NewRow
            CommDr.Item("CalLevy") = dr.Item("levy")
            CommDr.Item("Calcomm") = dr.Item("comm")
            CommDr.Item("Calclearing") = dr.Item("clearing")
            CommDr.Item("Calmonthcode") = dr.Item("monthcode")
            CommDr.Item("CalProduct") = dr.Item("product")
            CommDt.Rows.Add(CommDr)
        Next
        lstrSQL = "select monthcode, product, sum(comm) as comm, sum(clearing) as clearing , sum(exchange) as levy from newedge_cap_fee " & _
                    "where tdate='" & Format(tdate, "MM/dd/yyyy") & "' and counterparty = '" & pCounterParty & "' group by product, monthcode order by product asc, monthcode asc"
        Dt = GFncRtnDS(GSCnSqlConn, lstrSQL, "CapComm").Tables(0)
        For i As Integer = 0 To Dt.Rows.Count - 1
            If i > CommDt.Rows.Count - 1 Then
                CommDt.Rows.Add()
            End If
            CommDt.Rows(i).Item("CapLevy") = Dt.Rows(i).Item("levy")
            CommDt.Rows(i).Item("CapComm") = Dt.Rows(i).Item("comm")
            CommDt.Rows(i).Item("CapClearing") = Dt.Rows(i).Item("clearing")
            CommDt.Rows(i).Item("CapMonthcode") = Dt.Rows(i).Item("monthcode")
            CommDt.Rows(i).Item("CapProduct") = Dt.Rows(i).Item("product")
        Next
        Return CommDt

        'lstrSQL = "select isnull(a.monthcode, b.monthcode) as monthcode, isnull(a.product, b.product) as product, " & _
        '            "a.comm as cal_comm, a.clearing as cal_clearing, a.levy as cal_levy, b.comm as cap_comm, " & _
        '            "b.clearing as cap_clearing, b.exchange as cap_levy from (select monthcode, product, " & _
        '            "sum(comm) as comm, sum(clearing) as clearing, sum(levy) as levy " & _
        '            "from newedge_cap_trade_hist " & _
        '            "where tdate = '" & Format(tdate, "yyyyMMdd") & "' " & _
        '            "group by monthcode, product) a " & _
        '            "full join (select monthcode, product, comm, clearing, exchange " & _
        '            "from newedge_cap_fee " & _
        '            "where tdate = '" & Format(tdate, "yyyyMMdd") & "') b " & _
        '            "on a.monthcode = b.monthcode and a.product = b.product " & _
        '            "order by a.product, a.monthcode"
        'Return GFncRtnDS(GSCnSqlConn, lstrSQL, "Comm")

    End Function

    Protected Friend Function lFnGetCommDiff(ByVal tdate As Date, ByVal pCounterParty As String) As DataSet

        Dim lstrSQL As String

        'lstrSQL = "select isnull(a.monthcode, b.monthcode) as monthcode, isnull(a.product, b.product) as product, " & _
        '            "a.comm as cal_comm, a.clearing as cal_clearing, a.levy as cal_levy, b.comm as cap_comm, " & _
        '            "b.clearing as cap_clearing, b.exchange as cap_levy from (select monthcode, product, " & _
        '            "sum(comm) as comm, sum(clearing) as clearing, sum(levy) as levy " & _
        '            "from newedge_cap_trade_hist " & _
        '            "where tdate = '" & Format(tdate, "yyyyMMdd") & "' and counterparty = '" & pCounterParty & "' " & _
        '            "group by monthcode, product) a " & _
        '            "full join (select monthcode, product, comm, clearing, exchange " & _
        '            "from newedge_cap_fee " & _
        '            "where tdate = '" & Format(tdate, "yyyyMMdd") & "' and counterparty = '" & pCounterParty & "') b " & _
        '            "on a.monthcode = b.monthcode and a.product = b.product " & _
        '            "where (a.comm <> b.comm or a.clearing <> b.clearing or a.levy <> b.exchange) " & _
        '            "order by a.product, a.monthcode"
        lstrSQL = "select isnull(a.monthcode, b.monthcode) as monthcode, isnull(a.product, b.product) as product, " & _
                            "a.comm as cal_comm, a.clearing as cal_clearing, a.levy as cal_levy, b.comm as cap_comm, " & _
                            "b.clearing as cap_clearing, b.exchange as cap_levy from (select monthcode, product, " & _
                            "sum(comm) as comm, sum(clearing) as clearing, sum(levy) as levy " & _
                            "from vw_cap_trade_hist " & _
                            "where tdate = '" & Format(tdate, "yyyyMMdd") & "' and counterparty = '" & pCounterParty & "' " & _
                            "group by monthcode, product) a " & _
                            "full join (select monthcode, product, comm, clearing, exchange " & _
                            "from newedge_cap_fee " & _
                            "where tdate = '" & Format(tdate, "yyyyMMdd") & "' and counterparty = '" & pCounterParty & "') b " & _
                            "on a.monthcode = b.monthcode and a.product = b.product " & _
                            "where (a.comm <> b.comm or a.clearing <> b.clearing or a.levy <> b.exchange) " & _
                            "order by a.product, a.monthcode"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "CommDiff")

    End Function

    Protected Friend Function getNewestDate()
        'Dim Isql As String = " select max(tdate) as tdate from (select max(tdate) as tdate from newedge_cap_OP union select max(tdate) as tdate from newedge_emp_op) a "
        Dim Isql As String = " select max(tdate) as tdate from (select max(tdate) as tdate from vw_cap_OP union select max(tdate) as tdate from newedge_emp_op) a "

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, Isql, 0).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item("tdate")
        Else
            Return Now.Date
        End If


    End Function

    Protected Friend Function lFncPrintNewedgeDiffRpt(ByVal DiffDT As DataTable, ByVal SubTradeDiff As DataTable, _
                                                                                ByVal subcomm As DataTable, ByVal SubCommDiff As DataTable, _
                                                                                ByVal strTitle As String, ByVal tdate As Date, _
                                                                                ByVal pCounterParty As String) As ReportClass
        Dim rpt As New RptNewedgeDiff
        rpt.ReportClientDocument.LocaleID = CrystalDecisions.ReportAppServer.DataDefModel.CeLocale.ceLocaleEnglishUK
        'If DiffDT.Rows.Count > 0 Then
        rpt.Subreports("RptNewedgeTrade").SetDataSource(DiffDT)
        rpt.Subreports("RptNewedgeTradeDiff").SetDataSource(SubTradeDiff)
        rpt.Subreports("RptNewedgeComm").SetDataSource(subcomm)
        rpt.Subreports("RptNewedgeCommDiff").SetDataSource(SubCommDiff)
        clsRpt.AddParam(rpt, "paraTDate", tdate)
        clsRpt.AddParam(rpt, "paraTitle", strTitle)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        clsRpt.AddParam(rpt, "CounterParty", pCounterParty)
        Return rpt
        'Else
        'Return clsRpt.lfncRtnEmptyRpt("NewEdge Difference Report")
        'End If

    End Function

    Private Sub InitTradeDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "CapProduct"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Capmonthcode"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "CapTDate"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "CapBuy"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "CapSell"
        DT.Columns.Add(Column)
                Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "EmpProduct"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "Empmonthcode"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "EmpTDate"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "EmpBuy"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "EmpSell"
        DT.Columns.Add(Column)

    End Sub

    Private Sub InitCommDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "CapMonthCode"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "CapProduct"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "CapComm"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "CapClearing"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "CapLevy"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "CalMonthCode"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "CalProduct"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "CalComm"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "CalClearing"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "CalLevy"
        DT.Columns.Add(Column)

    End Sub


End Class
