Public Class clsRptFuturesStatementAdj

    Protected Friend Function GetCounterParty(ByVal pShowAll As Boolean) As DataTable
        Dim lcStrSQL As String = "Select misc_desc From misc_master Where misc_type = 'FuturesReport' And misc_code = 'CounterParty' Order By misc_desc"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        If pShowAll Then
            Dim lcDr As DataRow = lcDt.NewRow()
            lcDr("misc_desc") = "-- ALL --"
            lcDt.Rows.InsertAt(lcDr, 0)
        End If

        Return lcDt
    End Function

    Protected Friend Function GenCPAdjReport(ByVal pTdate As Date, ByVal pCounterParty As String) As DataTable
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        Dim lcResult As DataTable = New DtsRptFuturesStatementAdj.dtsRptFuturesStatementCPAdjDataTable
        Dim lcResultRow As DataRow = Nothing

        lcStrWhere = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If

        lcStrSQL = "SELECT * FROM (SELECT a.adjnoid, a.cpnoid, 'Delete' AS Adj_Action, a.Adj_Remark, " & _
                    "a.tdate, a.odate, b.buy, b.sell, a.monthcode, a.product, " & _
                    "b.price, a.liq_price, b.pl, a.settle_date, a.monthly_daily, " & _
                    "a.contract_size, a.liq_id, a.counterparty, " & _
                    "0 as buy_adj, 0 as sell_adj, 0 as price_adj, 0 as pl_adj " & _
                    "FROM newedge_cap_cp_adj a " & _
                    "INNER JOIN newedge_cap_cp b " & _
                    "ON a.cpnoid = b.noid WHERE a.adj_action = 'D') AS a " & _
                    "WHERE 1=1 " & _
                    lcStrWhere & _
                    "UNION " & _
                    "SELECT * FROM (SELECT b.adjnoid, b.cpnoid, 'Modify' AS Adj_Action, b.Adj_Remark, " & _
                    "a.tdate, a.odate, a.buy, a.sell, a.monthcode, a.product, " & _
                    "a.price, a.liq_price, a.pl, a.settle_date, a.monthly_daily, " & _
                    "a.contract_size, a.liq_id, a.counterparty, " & _
                    "b.buy as buy_adj, b.sell as sell_adj, b.price as price_adj, b.pl as pl_adj " & _
                    "FROM newedge_cap_cp a " & _
                    "INNER JOIN newedge_cap_cp_adj b " & _
                    "ON a.noid = b.cpnoid WHERE b.adj_action = 'M') AS b " & _
                    "WHERE 1=1 " & _
                    lcStrWhere & _
                    "UNION " & _
                    "SELECT * FROM (SELECT a.adjnoid, a.cpnoid, 'Add' AS Adj_Action, a.Adj_Remark, " & _
                    "a.tdate, a.odate, 0 as buy, 0 as sell, a.monthcode, a.product, " & _
                    "0 as price, a.liq_price, 0 as pl, a.settle_date, a.monthly_daily, " & _
                    "a.contract_size, a.liq_id, a.counterparty, " & _
                    "a.buy as buy_adj, a.sell as sell_adj, a.price as price_adj, a.pl as pl_adj " & _
                    "FROM newedge_cap_cp_adj a WHERE a.adj_action = 'A') AS c " & _
                    "WHERE 1=1 " & _
                    lcStrWhere

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        If dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1
                lcResultRow = lcResult.NewRow()
                lcResultRow.Item("d_tDate") = GFncNoNullDate(dt.Rows(i).Item("tdate"))
                lcResultRow.Item("d_settleDate") = GFncNoNullDate(dt.Rows(i).Item("settle_date"))
                lcResultRow.Item("d_oDate") = GFncNoNullDate(dt.Rows(i).Item("odate"))

                lcResultRow.Item("d_adj_action") = GFncNoNullString(dt.Rows(i).Item("adj_action"))
                lcResultRow.Item("d_remark") = GFncNoNullString(dt.Rows(i).Item("adj_remark"))
                lcResultRow.Item("d_liqId") = GFncNoNullString(dt.Rows(i).Item("liq_id"))
                lcResultRow.Item("d_monthCode") = GFncNoNullString(dt.Rows(i).Item("monthcode"))
                lcResultRow.Item("d_counterParty") = GFncNoNullString(dt.Rows(i).Item("counterparty"))
                lcResultRow.Item("d_monthlyDaily") = GFncNoNullString(dt.Rows(i).Item("monthly_daily"))
                lcResultRow.Item("d_product") = GFncNoNullString(dt.Rows(i).Item("product"))

                lcResultRow.Item("d_pl_adj") = GFncNoNullValue(dt.Rows(i).Item("pl_adj"))
                lcResultRow.Item("d_price_adj") = GFncNoNullValue(dt.Rows(i).Item("price_adj"))
                lcResultRow.Item("d_sell_adj") = GFncNoNullValue(dt.Rows(i).Item("sell_adj"))
                lcResultRow.Item("d_buy_adj") = GFncNoNullValue(dt.Rows(i).Item("buy_adj"))
                lcResultRow.Item("d_pl") = GFncNoNullValue(dt.Rows(i).Item("pl"))
                lcResultRow.Item("d_price") = GFncNoNullValue(dt.Rows(i).Item("price"))
                lcResultRow.Item("d_sell") = GFncNoNullValue(dt.Rows(i).Item("sell"))
                lcResultRow.Item("d_buy") = GFncNoNullValue(dt.Rows(i).Item("buy"))
                lcResultRow.Item("d_contractSize") = GFncNoNullValue(dt.Rows(i).Item("contract_size"))

                lcResult.Rows.Add(lcResultRow)
            Next
        End If

        Return lcResult
    End Function

    Protected Friend Function GenOPAdjReport(ByVal pTdate As Date, ByVal pCounterParty As String) As DataTable
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        Dim lcResult As DataTable = New DtsRptFuturesStatementAdj.dtsRptFuturesStatementOPAdjDataTable
        Dim lcResultRow As DataRow = Nothing

        lcStrWhere = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If

        lcStrSQL = "SELECT * FROM (SELECT a.adjnoid, a.opnoid, 'Delete' AS Adj_Action, a.Adj_Remark, " & _
                    "a.tdate, a.odate, b.buy, b.sell, a.monthcode, a.product, " & _
                    "b.price, a.closing_price, b.floating, a.settle_date, a.monthly_daily, " & _
                    "a.contract_size, a.counterparty, " & _
                    "0 as buy_adj, 0 as sell_adj, 0 as price_adj, 0 as floating_adj, 0 as closingPrice_adj, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
                    "FROM newedge_cap_op_adj a " & _
                    "INNER JOIN newedge_cap_op b " & _
                    "ON a.opnoid = b.noid WHERE a.adj_action = 'D') AS a " & _
                    "WHERE 1=1 " & _
                    lcStrWhere & _
                    "UNION " & _
                    "SELECT * FROM (SELECT b.adjnoid, b.opnoid, 'Modify' AS Adj_Action, b.Adj_Remark, " & _
                    "a.tdate, a.odate, a.buy, a.sell, a.monthcode, a.product, " & _
                    "a.price, a.closing_price, a.floating, a.settle_date, a.monthly_daily, " & _
                    "a.contract_size, a.counterparty, " & _
                    "b.buy as buy_adj, b.sell as sell_adj, b.price as price_adj, b.floating as floating_adj, b.closing_price as closingPrice_adj, a.strike,  CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
                    "FROM newedge_cap_op a " & _
                    "INNER JOIN newedge_cap_op_adj b " & _
                    "ON a.noid = b.opnoid WHERE b.adj_action = 'M') AS b " & _
                    "WHERE 1=1 " & _
                    lcStrWhere & _
                    "UNION " & _
                    "SELECT * FROM (SELECT a.adjnoid, a.opnoid, 'Add' AS Adj_Action, a.Adj_Remark, " & _
                    "a.tdate, a.odate, 0 as buy, 0 as sell, a.monthcode, a.product, " & _
                    "0 as price, 0 as closing_price, 0 as floating, a.settle_date, a.monthly_daily, " & _
                    "a.contract_size, a.counterparty, " & _
                    "a.buy as buy_adj, a.sell as sell_adj, a.price as price_adj, a.floating as floating_adj, a.closing_price as closingPrice_adj, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
                    "FROM newedge_cap_op_adj a WHERE a.adj_action = 'A') AS c " & _
                    "WHERE 1=1 " & _
                    lcStrWhere

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        If dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1
                lcResultRow = lcResult.NewRow()

                lcResultRow.Item("d_tDate") = GFncNoNullDate(dt.Rows(i).Item("tdate"))
                lcResultRow.Item("d_settleDate") = GFncNoNullDate(dt.Rows(i).Item("settle_date"))
                lcResultRow.Item("d_oDate") = GFncNoNullDate(dt.Rows(i).Item("odate"))

                lcResultRow.Item("d_adj_action") = GFncNoNullString(dt.Rows(i).Item("adj_action"))
                lcResultRow.Item("d_remark") = GFncNoNullString(dt.Rows(i).Item("adj_remark"))
                lcResultRow.Item("d_monthCode") = GFncNoNullString(dt.Rows(i).Item("monthcode"))
                lcResultRow.Item("d_counterParty") = GFncNoNullString(dt.Rows(i).Item("counterparty"))
                lcResultRow.Item("d_monthlyDaily") = GFncNoNullString(dt.Rows(i).Item("monthly_daily"))
                lcResultRow.Item("d_product") = GFncNoNullString(dt.Rows(i).Item("product")) + " " + If(GFncNoNullStrike(dt.Rows(i).Item("strike")) = 0, "", GFncNoNullStrike(dt.Rows(i).Item("strike")).ToString(modGlobal.DecimalFormat)) + " " + GFncNoNullString(dt.Rows(i).Item("callput"))

                lcResultRow.Item("d_floating_adj") = GFncNoNullValue(dt.Rows(i).Item("floating_adj"))
                lcResultRow.Item("d_closingPrice_adj") = GFncNoNullValue(dt.Rows(i).Item("closingPrice_adj"))
                lcResultRow.Item("d_price_adj") = GFncNoNullValue(dt.Rows(i).Item("price_adj"))
                lcResultRow.Item("d_sell_adj") = GFncNoNullValue(dt.Rows(i).Item("sell_adj"))
                lcResultRow.Item("d_buy_adj") = GFncNoNullValue(dt.Rows(i).Item("buy_adj"))
                lcResultRow.Item("d_floating") = GFncNoNullValue(dt.Rows(i).Item("floating"))
                lcResultRow.Item("d_closingPrice") = GFncNoNullValue(dt.Rows(i).Item("closing_price"))
                lcResultRow.Item("d_price") = GFncNoNullValue(dt.Rows(i).Item("price"))
                lcResultRow.Item("d_sell") = GFncNoNullValue(dt.Rows(i).Item("sell"))
                lcResultRow.Item("d_buy") = GFncNoNullValue(dt.Rows(i).Item("buy"))
                lcResultRow.Item("d_contractSize") = GFncNoNullValue(dt.Rows(i).Item("contract_size"))
                'lcResultRow.Item("d_strike") = GFncNoNullStrike(dt.Rows(i).Item("strike"))
                'lcResultRow.Item("d_callput") = GFncNoNullString(dt.Rows(i).Item("callput"))
                lcResult.Rows.Add(lcResultRow)
            Next
        End If

        Return lcResult
    End Function

    Protected Friend Function GenTHAdjReport(ByVal pTdate As Date, ByVal pCounterParty As String) As DataTable
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        Dim lcResult As DataTable = New DtsRptFuturesStatementAdj.dtsRptFuturesStatementTHAdjDataTable
        Dim lcResultRow As DataRow = Nothing

        lcStrWhere = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If

        lcStrSQL = "SELECT * FROM (SELECT a.adjnoid, a.thtid, 'Delete' AS Adj_Action, a.Adj_Remark, " & _
                    "a.tdate, a.period, b.buy, b.sell, a.monthcode, a.product, " & _
                    "b.price, a.comm, b.clearing, a.settle_date, a.monthly_daily, " & _
                    "a.contract_size, a.levy, a.counterparty, " & _
                    "0 as buy_adj, 0 as sell_adj, 0 as price_adj, 0 as clearing_adj, 0 as comm_adj, 0 as levy_adj, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
                    "FROM newedge_cap_trade_hist_adj a " & _
                    "INNER JOIN newedge_cap_trade_hist b " & _
                    "ON a.thtid = b.tid WHERE a.adj_action = 'D') AS a " & _
                    "WHERE 1=1 " & _
                    lcStrWhere & _
                    "UNION " & _
                    "SELECT * FROM (SELECT b.adjnoid, b.thtid, 'Modify' AS Adj_Action, b.Adj_Remark, " & _
                    "a.tdate, a.period, a.buy, a.sell, a.monthcode, a.product, " & _
                    "a.price, a.comm, a.clearing, a.settle_date, a.monthly_daily, " & _
                    "a.contract_size, a.levy, a.counterparty, " & _
                    "b.buy as buy_adj, b.sell as sell_adj, b.price as price_adj, b.clearing as clearing_adj, 0 as comm_adj, 0 as levy_adj, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
                    "FROM newedge_cap_trade_hist a " & _
                    "INNER JOIN newedge_cap_trade_hist_adj b " & _
                    "ON a.tid = b.thtid WHERE b.adj_action = 'M') AS b " & _
                    "WHERE 1=1 " & _
                    lcStrWhere & _
                    "UNION " & _
                    "SELECT * FROM (SELECT a.adjnoid, a.thtid, 'Add' AS Adj_Action, a.Adj_Remark, " & _
                    "a.tdate, a.period, 0 as buy, 0 as sell, a.monthcode, a.product, " & _
                    "0 as price, a.comm, 0 as clearing, a.settle_date, a.monthly_daily, " & _
                    "a.contract_size, 0 as levy, a.counterparty, " & _
                    "a.buy as buy_adj, a.sell as sell_adj, a.price as price_adj, a.clearing as clearing_adj, a.comm as comm_adj, a.levy as levy_adj, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
                    "FROM newedge_cap_trade_hist_adj a WHERE a.adj_action = 'A') AS c " & _
                    "WHERE 1=1 " & _
                    lcStrWhere

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        If dt.Rows.Count > 0 Then

            For i As Integer = 0 To dt.Rows.Count - 1
                lcResultRow = lcResult.NewRow()

                lcResultRow.Item("d_tDate") = GFncNoNullDate(dt.Rows(i).Item("tdate"))
                lcResultRow.Item("d_settleDate") = GFncNoNullDate(dt.Rows(i).Item("settle_date"))

                lcResultRow.Item("d_period") = GFncNoNullString(dt.Rows(i).Item("period"))
                lcResultRow.Item("d_adj_action") = GFncNoNullString(dt.Rows(i).Item("adj_action"))
                lcResultRow.Item("d_remark") = GFncNoNullString(dt.Rows(i).Item("adj_remark"))
                lcResultRow.Item("d_monthCode") = GFncNoNullString(dt.Rows(i).Item("monthcode"))
                lcResultRow.Item("d_counterParty") = GFncNoNullString(dt.Rows(i).Item("counterparty"))
                lcResultRow.Item("d_monthlyDaily") = GFncNoNullString(dt.Rows(i).Item("monthly_daily"))
                lcResultRow.Item("d_product") = GFncNoNullString(dt.Rows(i).Item("product")) + " " + If(GFncNoNullStrike(dt.Rows(i).Item("strike")) = 0, "", GFncNoNullStrike(dt.Rows(i).Item("strike")).ToString(modGlobal.DecimalFormat)) + " " + GFncNoNullString(dt.Rows(i).Item("callput"))

                lcResultRow.Item("d_levy_adj") = GFncNoNullValue(dt.Rows(i).Item("levy_adj"))
                lcResultRow.Item("d_comm_adj") = GFncNoNullValue(dt.Rows(i).Item("comm_adj"))
                lcResultRow.Item("d_clearing_adj") = GFncNoNullValue(dt.Rows(i).Item("clearing_adj"))
                lcResultRow.Item("d_price_adj") = GFncNoNullValue(dt.Rows(i).Item("price_adj"))
                lcResultRow.Item("d_sell_adj") = GFncNoNullValue(dt.Rows(i).Item("sell_adj"))
                lcResultRow.Item("d_buy_adj") = GFncNoNullValue(dt.Rows(i).Item("buy_adj"))
                lcResultRow.Item("d_levy") = GFncNoNullValue(dt.Rows(i).Item("levy"))
                lcResultRow.Item("d_comm") = GFncNoNullValue(dt.Rows(i).Item("comm"))
                lcResultRow.Item("d_clearing") = GFncNoNullValue(dt.Rows(i).Item("clearing"))
                lcResultRow.Item("d_price") = GFncNoNullValue(dt.Rows(i).Item("price"))
                lcResultRow.Item("d_sell") = GFncNoNullValue(dt.Rows(i).Item("sell"))
                lcResultRow.Item("d_buy") = GFncNoNullValue(dt.Rows(i).Item("buy"))
                lcResultRow.Item("d_contractSize") = GFncNoNullValue(dt.Rows(i).Item("contract_size"))
                lcResult.Rows.Add(lcResultRow)
            Next
        End If

        Return lcResult
    End Function
End Class
