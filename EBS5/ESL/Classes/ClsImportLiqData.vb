Imports System.Data.SqlClient

Public Class ClsImportLiqData

    'This function is used to import last trade date in G2BS to local temp. table
    Public Sub lFncImportLastTradeDate()

        Dim lstrSQL As String = ""

        lstrSQL = "SELECT trade_date into #lasttradedate FROM " & GStrG2BSDB & ".dbo.View_er_system_parameter"
        GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import client information in G2BS to local temp. table
    Protected Friend Sub lFncImportTestBal()

        Dim lstrSQL As String = ""
        Dim lcheck As Long


        lstrSQL = "SELECT RTRIM(ae_code) AS ae_code, client_code, RTRIM(client_name) AS client_name, " & _
                    "case when cmid = '368' then 'F' else Left(client_type,1) end as client_type, credit_lmt as credit_limit, " & _
                    "ledger_bal as ledger_bal, interest_accrued as interest, avail_bal, t1_trade_amount, t2_trade_amount " & _
                    "into #testbal " & _
                    "FROM " & GStrG2BSDB & ".dbo.view_ER_client_master"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import client last trade date transaction in G2BS to local temp. table
    Protected Friend Sub lFncImportStStkTxnLst()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "SELECT rtrim(A.client_code) as client_code, rtrim(A.bs) as inv_no, B.trade_date as tdate, " & _
                    "rtrim(A.stkno) as stock_code, A.price as stock_price, A.qty as qty, A.price * A.qty as total, " & _
                    "A.comm as clientt_comm, A.rebate as ae_rebate, A.stamp as stamp_duty, A.tran_levy as levy, " & _
                    "A.I_C_levy as ic_levy, A.tran_levy as trading_fee, A.ccass_fee as ccass_fee, " & _
                    "case when bs = 'S' then ABS(A.net_amount) else 0.00 end as credit, " & _
                    "case when bs = 'S' then 0.00 else ABS(A.net_amount) end as debit " & _
                    "into #StStkTxnLst " & _
                    "FROM " & GStrG2BSDB & ".dbo.view_ER_client_trade_namt_with_fee A, " & GStrG2BSDB & ".dbo.view_ER_system_parameter B " & _
                    "WHERE (A.trade_date) = (select distinct trade_date from " & GStrG2BSDB & ".dbo.view_ER_system_parameter)"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import client position information in G2BS to local temp. table
    Protected Friend Sub lFncImportTestTrade()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "SELECT rtrim(client_code) AS client_code, t1_trade_amount, t2_trade_amount, " & _
                    "market_value, cal_margin_value AS margin_value, cal_t2_margin_value AS t2_margin " & _
                    "into #TestTrade " & _
                    "FROM " & GStrG2BSDB & ".dbo.View_er_client_master " & _
                    "where (t2_trade_amount <> 0 OR t1_trade_amount <> 0 OR market_value <> 0 OR cal_margin_value <> 0 OR cal_t2_margin_value <> 0)"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import client non-zero portfolio in G2BS to local temp. table
    Protected Friend Sub lFncImportTestPort()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "SELECT rtrim(accno) AS client_code, rtrim(stock_code) AS stock_code, onhand AS qty, " & _
                    "unsettled_buy_qty AS buy_qty, unsettled_sell_qty AS sell_qty " & _
                    "into #TestPort " & _
                    "FROM " & GStrG2BSDB & ".dbo.View_er_client_portfolio " & _
                    "where (onhand <> 0 OR unsettled_buy_qty <> 0 OR unsettled_sell_qty <> 0)"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import client stauts in G2BS to local temp. table
    Protected Friend Sub lFncImportTestStatus()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "select rtrim(client_code) as client_code, rtrim(locked) as stop, suspend_date, close_date " & _
                    "into #TestStatus " & _
                    "FROM " & GStrG2BSDB & ".dbo.View_er_client_master"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import suspend stock in G2BS to local temp. table
    Protected Friend Sub lFncImportSuspendStock()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "SELECT stkno, date_suspend " & _
                    "into #suspendstock " & _
                    "FROM " & GStrG2BSDB & ".dbo.stock_master " & _
                    "where so3 = 'Y' and stkno not like '%-%'"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import client fund movement in G2BS to local temp. table
    Protected Friend Sub lFncImportFundMovement()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "select rtrim(client_code) AS client_code, case when dep_wtd='Withdraw' then -amount else amount end as amount, " & _
                    "case when dep_wtd='Withdraw' then '' else 'CR' end as amount_type " & _
                    "into #IbsCacCup1 " & _
                    "from " & GStrG2BSDB & ".dbo.view_ER_client_fund_movement " & _
                    "where client_code in (select client_code from " & GStrG2BSDB & ".dbo.view_ER_client_master where client_type ='Cash')"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import client portfolio in G2BS to local temp. table
    Protected Friend Sub lFncImportStCltPortfolio()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "SELECT rtrim(P.accno) AS client_code, rtrim(P.stock_code) AS stock_code, S.trade_date AS tdate, " & _
                    "P.underreg_qty, P.onhand AS qty_onhand, (P.underreg_qty+P.onhand) AS qty_total, " & _
                    "P.closing_price AS market_price, (P.underreg_qty+P.onhand)*P.closing_price AS market_value, " & _
                    "P.margin_ratio/100 AS margin_ratio, " & _
                    "(P.underreg_qty+P.onhand)*P.closing_price*P.margin_ratio/100 AS margin_value, P.Suspended AS suspend_flag, " & _
                    " P.net_onhand_qty AS net_qty_onhand, P.net_onhand_qty*P.closing_price AS net_market_value " & _
                    "into #StCltPortfolio " & _
                    "FROM " & GStrG2BSDB & ".dbo.view_ER_client_portfolio P, " & GStrG2BSDB & ".dbo.view_ER_system_parameter S"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import client current month commission and interest in G2BS and G2BF to local temp. table
    Protected Friend Sub lFncImportSCommissionAndInterest()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "SELECT * " & _
                    "INTO #ccomm " & _
                    "FROM " & GStrG2BSDB & ".dbo.View_g2b_client_trade_dt_with_comm ccomm "
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "SELECT * " & _
                    "into #cm " & _
                    "FROM " & GStrG2BSDB & ".dbo.view_ER_client_master"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "SELECT accno, trade_date as mth, SUM(comm) as comm, client_type " & _
                    "INTO #MonthComm " & _
                    "FROM #ccomm, #lasttradedate, #cm " & _
                    "WHERE YEAR(tdate) =YEAR(trade_date) AND MONTH(tdate) = MONTH(trade_date) AND (tradetype = '0' OR tradetype = '4') " & _
                    "and #cm.client_code = #ccomm.accno " & _
                    "group by accno, trade_date, client_type order by accno"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

        lstrSQL = "SELECT * " & _
                    "INTO #fccomm " & _
                    "FROM " & GStrG2BFDB & ".dbo.View_g2b_client_trade_dt_with_comm"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "select tradedate " & _
                    "into #flasttradedate " & _
                    "from " & GStrG2BFDB & ".dbo.system_parameter " & _
                    "where rtrim(cmid) = '999'"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "SELECT accno, tradedate as mth, SUM(comm) as comm " & _
                    "INTO #MonthCommF " & _
                    "FROM #fccomm, " & _
                    "#flasttradedate " & _
                    "WHERE YEAR(tdate) =YEAR(tradedate) AND MONTH(tdate) = MONTH(tradedate) AND comm is NOT null " & _
                    "group by accno, tradedate order by accno"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

        lstrSQL = "SELECT * " & _
                    "INTO #cint " & _
                    "FROM " & GStrG2BSDB & ".dbo.view_it_client_accrue_int"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "SELECT accno, trade_date as mth, -1 * SUM(int_amt) as interest, client_type " & _
                    "INTO #MonthInt " & _
                    "FROM #cint, #lasttradedate, #cm " & _
                    "WHERE YEAR(to_date) =YEAR(trade_date) AND MONTH(to_date) = MONTH(trade_date) and #cm.client_code = #cint.accno " & _
                    "group by accno, trade_date, client_type ORDER BY accno"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

        lstrSQL = "drop table #ccomm"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "drop table #cm"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "drop table #cint"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "drop table #fccomm"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "drop table #flasttradedate"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import client last trade date balance in G2BS to local temp. table
    Protected Friend Sub lFncImportStoreBalance()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "SELECT client_code, lastday.tdate, ledger_bal, avail_bal " & _
                    "into #acbal " & _
                    "FROM " & GStrG2BSDB & ".dbo.View_er_client_master cm, " & _
                    "(SELECT MAX(tdate) tdate from " & GStrG2BSDB & ".dbo.view_IT_client_last_day_trade) lastday " & _
                    "where ledger_bal <> 0 or avail_bal <> 0"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import concentration of each stock in G2BS to local temp. table
    Protected Friend Sub lFncImportStockConcentration()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "SELECT stock_code, SUM(net_onhand_qty) as totalqty, SUM((underreg_qty + onhand) * closing_price) as totalMV " & _
                    "into #allstock " & _
                    "FROM " & GStrG2BSDB & ".dbo.View_er_client_portfolio " & _
                    "group by stock_code"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

        lstrSQL = "SELECT accno, mdate, port.stock_code, net_onhand_qty, " & _
                    "round(case when totalqty > 0 then net_onhand_qty *100 / totalqty else 0.0000 end, 4) as percentage, " & _
                    "underreg_qty+onhand*closing_price as market_value " & _
                    "into #stock_con " & _
                    "FROM " & GStrG2BSDB & ".dbo.View_er_client_portfolio port, #allstock, " & _
                    "(SELECT max(tdate) as mdate FROM " & GStrG2BSDB & ".dbo.View_it_client_last_day_trade) tmp " & _
                    "where port.stock_code = #allstock.stock_code " & _
                    "order by port.stock_code, accno"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

        lstrSQL = "insert into #stock_con " & _
                    "SELECT 'Total', mdate, stock_code, SUM(net_onhand_qty) as totalqty, 100.0000, SUM((underreg_qty + onhand) * closing_price) as totalMV " & _
                    "FROM " & GStrG2BSDB & ".dbo.View_er_client_portfolio, " & _
                    "(SELECT max(tdate) as mdate FROM " & GStrG2BSDB & ".dbo.View_it_client_last_day_trade) tmp " & _
                    "group by stock_code, mdate"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import ae code in G2BS to local temp. table
    Protected Friend Sub lFncImportAEMaster()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "select client_code, ae_code " & _
                    "into #aemaster " & _
                    "from " & GStrG2BSDB & ".dbo.View_client_contact_info"
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "select rtrim(a.aeno) as aeno, rtrim(a.name) as aename, rtrim(isnull(b.name,'')) as branchname " & _
                    "into #staemaster " & _
                    "from " & GStrG2BSDB & ".dbo.ae_master a " & _
                    "left join " & GStrG2BSDB & ".dbo.branch_master b on a.bhid = b.bhid "
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    'This function is used to import ae code in G2BS to local temp. table
    Protected Friend Sub lFncImportCltLastTradeDate()

        Dim lstrSQL As String = ""
        Dim lcheck As Long

        lstrSQL = "select client_code, lastday " & _
                    "into #client_last_trade_day " & _
                    "from " & GStrG2BSDB & ".dbo.view_IT_client_last_trade_day "
        lcheck = GFncRunSQL(GSCnLiqConn, lstrSQL, 0)

    End Sub

    Protected Friend Sub lFncImportExchangeRate()

        Dim lstrSQL As String = ""
        Dim dtTemp As DataTable = Nothing
        Dim g2bf_tdate As Date
        Dim g2bs_tdate As Date
        Dim exchangeRate_tdate As Date

        lstrSQL = "select max(tdate) tdate from " & GStrG2BFDB & "..view_IT_client_last_day_trade"
        dtTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
        If dtTemp.Rows.Count > 0 Then
            g2bf_tdate = dtTemp.Rows(0)("tdate")
        End If

        lstrSQL = "select max(tdate) tdate from exchangerate"
        dtTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
        If dtTemp.Rows.Count > 0 Then
            exchangeRate_tdate = dtTemp.Rows(0)("tdate")
        End If

        If (Year(g2bf_tdate) = Year(exchangeRate_tdate)) And (Month(g2bf_tdate) = Month(exchangeRate_tdate)) Then
            lstrSQL = "insert into exchangerate (system_type, currency_in, ex_rate, tdate) " & _
                        "select 'Futures', currency_in, tdate, ex_rate, '" & Format(g2bf_tdate, "yyyy/MM/dd") & _
                        "' from exchangerate a inner join (select currency_in, max(tdate) as tdate from exchagerate " & _
                        "group by currency_in) b on a.currency_in=b.currency_in and a.tdate=b.tdate"
            GFncRunSQL(GSCnSqlConn, lstrSQL)
        End If

        lstrSQL = "SELECT trade_date from #lasttradedate "
        dtTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
        If dtTemp.Rows.Count > 0 Then
            g2bs_tdate = dtTemp.Rows(0)("tdate")

            lstrSQL = " delete from exchangerate where system_type = 'Securities' and tdate = '" & Format(g2bs_tdate, "yyyy/MM/dd") & "' "
            GFncRunSQL(GSCnSqlConn, lstrSQL)

            lstrSQL = " insert into dbo.exchangerate " & _
                " select 'Securities' as system_type, currency as currency_in, " & _
                " 'HKD' as currency_out, rate as ex_rate, " & _
                " getdate() as lupdtdate, '" & Format(g2bs_tdate, "yyyy/MM/dd") & "' as tdate " & _
                " from  " & GStrG2BSDB & ".dbo.view_er_exchange_rate "
            GFncRunSQL(GSCnSqlConn, lstrSQL)
        End If


    End Sub

    'This function is used to update EBS3 last trade date
    Public Sub lFncUpdateIBSStTxnDate(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "delete from stcontrol"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "delete from Ibssttxndate"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into stcontrol(tradedate, starttime, endtime, procflag) " & _
                    "select trade_date, GETDATE(), NULL, 0 from #lasttradedate"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into Ibssttxndate(t2_date) " & _
                    "select trade_date from #lasttradedate"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update Client original balance
    Public Sub lFncUpdateTestbal(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "DELETE FROM testbal"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO testbal(AE_CODE, CLT_CODE, CLT_NAME, CLT_TYPE, CR_LIMIT, BAL, INTEREST, AVA_BAL, T1_TRADE, T2_TRADE) " & _
                    "SELECT ae_code, client_code, client_name, client_type, credit_limit, " & _
                    "ledger_bal, interest, avail_bal, t1_trade_amount, t2_trade_amount " & _
                    "FROM #testbal"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update Client status
    Public Sub lFncUpdateTestStatus(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "DELETE FROM TestStatus"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO TestStatus(clt_code, stop, cls_date, susp_date) " & _
                    "SELECT client_code, stop, close_date, suspend_date " & _
                    "FROM #TestStatus"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update Client status
    Public Sub lFncUpdateStCltPortfolio(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "DELETE FROM STPortfolio"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO STPortfolio(clt_code, stk_code, qty, market_value, net_qty, net_market_value, ldate) " & _
                    "SELECT client_code, stock_code, qty_onhand, market_value, net_qty_onhand, net_market_value, getdate() " & _
                    "FROM #StCltPortfolio "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 suspend stock
    Protected Friend Sub lFncUpdateSuspendStock(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "delete from stsuspendstock"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO stsuspendstock(stkno, suspend_date) SELECT stkno, date_suspend " & _
                    "FROM #suspendstock"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 client commission and interest
    Protected Friend Sub lFncUpdateSCommissionAndInterest(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "DELETE MonthComm " & _
                    "FROM MonthComm join " & _
                    "(SELECT MAX(mth) tdate from #MonthComm) lastday " & _
                    "on YEAR(mth) = YEAR(lastday.tdate) AND MONTH(mth) = MONTH(lastday.tdate)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO MonthComm(accno, mth, comm, client_type) " & _
                    "SELECT accno, mth, comm, client_type " & _
                    "FROM #MonthComm"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        lstrSQL = "DELETE MonthCommF " & _
                    "FROM MonthCommF join " & _
                    "(SELECT MAX(mth) tdate from #MonthCommF) lastday " & _
                    "on YEAR(mth) = YEAR(lastday.tdate) AND MONTH(mth) = MONTH(lastday.tdate)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO monthcommf(accno, mth, comm) " & _
                    "SELECT accno, mth, comm " & _
                    "FROM #MonthCommF"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        lstrSQL = "DELETE MonthInt " & _
                    "FROM MonthInt join " & _
                    "(SELECT MAX(mth) tdate from #MonthInt) lastday " & _
                    "on YEAR(mth) = YEAR(lastday.tdate) AND MONTH(mth) = MONTH(lastday.tdate)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO MonthInt(accno, mth, interest, client_type) " & _
                    "SELECT accno, mth, interest, client_type " & _
                    "FROM #MonthInt"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 client balance
    Protected Friend Sub lFncUpdateStoreBalance(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        'insert client balance to ebs3 database
        lstrSQL = "DELETE ebs3.dbo.acbaltest " & _
                    "FROM acbal, (SELECT MAX(tdate) tdate from #acbal) lastday " & _
                    "where acbal.tdate = lastday.tdate"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO ebs3.dbo.acbal(accno, tdate, led_bal, ava_bal) " & _
                    "SELECT client_code, tdate, ledger_bal, avail_bal " & _
                    "FROM #acbal cm"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        'insert client balance to local database
        lstrSQL = "DELETE acbal " & _
                    "FROM acbal, (SELECT MAX(tdate) tdate from #acbal) lastday " & _
                    "where acbal.tdate = lastday.tdate"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO acbal(accno, tdate, led_bal, ava_bal) " & _
                    "SELECT client_code, tdate, ledger_bal, avail_bal " & _
                    "FROM #acbal cm"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        'delete last month client balance from local database
        lstrSQL = "DELETE acbal " & _
                    "FROM acbal, (SELECT DateAdd(""d"", -1.0 * DatePart(""d"", MAX(tdate)), MAX(tdate)) ldate from #acbal) lastday " & _
                    "where month(acbal.tdate) = month(lastday.ldate) " & _
                    "and year(acbal.tdate) = year(lastday.ldate)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 stock concentration
    Protected Friend Sub lFncUpdateStockConcentration(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        'insert stock concentration to ebs3 database
        lstrSQL = "delete from ebs3.dbo.stockcontest " & _
                    "where tdate = (SELECT max(mdate) as mdate FROM #stock_con)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into ebs3.dbo.stockcon(accno, tdate, stock_code, qty, percentage, market_value) " & _
                    "SELECT accno, mdate, stock_code, net_onhand_qty, percentage, market_value from #stock_con"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        'insert stock concentration to local database
        lstrSQL = "delete from stockconcentration where tdate = (SELECT max(mdate) as mdate FROM #stock_con)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into stockconcentration(accno, tdate, stock_code, qty, percentage, market_value) " & _
                    "SELECT accno, mdate, stock_code, net_onhand_qty, percentage, market_value from #stock_con"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        'delete last month stock concentration from local database
        lstrSQL = "DELETE stockconcentration " & _
                    "FROM stockconcentration, (SELECT DateAdd(""d"", -1.0 * DatePart(""d"", MAX(mdate)), MAX(mdate)) ldate from #stock_con) lastday " & _
                    "where month(stockconcentration.tdate) = month(lastday.ldate) " & _
                    "and year(stockconcentration.tdate) = year(lastday.ldate)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 last trade date
    Protected Friend Sub lFncUpdateStSysTxnDate(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "update sttxndate set sttxndate.t0_date = sttxndate.t1_date, sttxndate.t1_date = sttxndate.t2_date " & _
                    "from sttxndate, ibssttxndate " & _
                    "where sttxndate.date <> ibssttxndate.t2_date"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update sttxndate set sttxndate.t2_date = ibssttxndate.t2_date " & _
                    "from sttxndate, ibssttxndate " & _
                    "where sttxndate.date <> ibssttxndate.t2_date"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update sttxndate set sttxndate.date = ibssttxndate.t2_date " & _
                    "from sttxndate, ibssttxndate " & _
                    "where sttxndate.date <> ibssttxndate.t2_date"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stsysparameter set stsysparameter.txn_date = ibssttxndate.t2_date " & _
                    "from stsysparameter, ibssttxndate " & _
                    "where stsysparameter.date <> ibssttxndate.t2_date"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stsysparameter set stsysparameter.last_date = sttxndate.t1_date " & _
                    "from stsysparameter, sttxndate"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stsysparameter set stsysparameter.date = sttxndate.t2_date " & _
                    "from stsysparameter, sttxndate"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stsysparameter set stsysparameter.month = month(stsysparameter.date)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stsysparameter set stsysparameter.year = year(stsysparameter.date) "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 client master
    Protected Friend Sub lFncUpdateStCltMast(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "update stcltmaster set cr_limit = 0, withdrawal = 0, interest = 0, dr_bal = 0, cr_bal = 0, " & _
                    "mc_dr_bal = 0, mc_cr_bal = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into stcltmaster(run_code, clt_code, clt_name, clt_type, cr_limit, interest) " & _
                    "select ae_code, client_code, client_name, client_type, credit_limit, interest " & _
                    "from #testbal " & _
                    "where #testbal.client_code not in (select stcltmaster.clt_code from stcltmaster) ORDER BY ae_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 client margin call information
    Protected Friend Sub lFncUpdateStCltBalMargCall(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "update stcltmaster " & _
                    "set stcltmaster.run_code = #testbal.ae_code, stcltmaster.clt_code = #testbal.client_code, " & _
                    "stcltmaster.clt_name = #testbal.client_name, stcltmaster.clt_type = #testbal.client_type, " & _
                    "stcltmaster.cr_limit = #testbal.credit_limit, stcltmaster.interest = #testbal.interest " & _
                    "from stcltmaster, #testbal " & _
                    "where stcltmaster.clt_code = #testbal.client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster " & _
                    "set stcltmaster.cr_bal = (case when #testbal.ledger_bal > 0 then #testbal.ledger_bal else 0 end), " & _
                    "stcltmaster.dr_bal = (case when #testbal.ledger_bal > 0 then 0 else ABS(#testbal.ledger_bal) end) " & _
                    "from stcltmaster, #testbal " & _
                    "where stcltmaster.clt_code = #testbal.client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_dr_bal = dr_bal"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_dr_bal = dr_bal - interest where interest < 0 and (dr_bal > 0 or (dr_bal=0 and cr_bal=0))"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_cr_bal = cr_bal"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_cr_bal = cr_bal + interest where interest < 0 and cr_bal > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_dr_bal = mc_cr_bal * (-1) where mc_cr_bal < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_cr_bal = 0 where mc_cr_bal < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set short = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster " & _
                    "set short = 1 " & _
                    "where clt_code in (select client_code from #testport where (qty+buy_qty-sell_qty)<0)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster " & _
                    "set net_trade = 0, t2_unrealized = 0, t1_unrealized = 0, mkt_value = 0, margin_value = 0, mc_act_ratio = 0, margin_ratio = 0, mc_total = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster " & _
                    "set stcltmaster.net_trade = -#testtrade.t2_trade_amount, stcltmaster.t2_unrealized = #testtrade.t2_trade_amount, " & _
                    "stcltmaster.t1_unrealized = #testtrade.t1_trade_amount, stcltmaster.mkt_value = #testtrade.market_value, " & _
                    "stcltmaster.margin_value = #testtrade.margin_value " & _
                    "from stcltmaster, #testtrade " & _
                    "where stcltmaster.clt_code = #testtrade.client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_act_ratio = mc_dr_bal / mkt_value where mkt_value > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_act_ratio = 999.99 where mkt_value = 0 and mc_dr_bal > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_act_ratio = 999.99 where mkt_value < 0 "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set margin_ratio = mc_dr_bal / margin_value where margin_value > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set margin_ratio = 999.99 where margin_value = 0 and mc_dr_bal > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set margin_ratio = 999.99 where margin_value < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_total = mc_dr_bal - cr_limit where (margin_value - dr_bal) > (cr_limit - dr_bal)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_total = mc_dr_bal - margin_value where (margin_value - dr_bal) < (cr_limit - dr_bal)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_total = mc_dr_bal where margin_value = cr_limit"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_total = mc_dr_bal - margin_value - mc_cr_bal where mkt_value < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_total = (-1)*mc_total where mc_total < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_t2 = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_t2 = t2_unrealized * (-1) where t2_unrealized < 0 and mc_dr_bal > 0 "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set withdrawal = mc_due"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_due = 0 "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_due = mc_dr_bal - mc_t2 - margin_value where mc_dr_bal > 0 "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.client_code, rtrim(a.inv_no) as type, a.stock_code, sum(a.qty) as qty, b.margin_ratio, " & _
                    "b.market_price, (sum(a.qty)*market_price*margin_ratio) as margin_value " & _
                    "into #stcltbuy_tmp " & _
                    "from #ststktxnlst a, #stcltportfolio b, sttxndate " & _
                    "where a.client_code = b.client_code and a.stock_code = b.stock_code and a.tdate = sttxndate.date and rtrim(a.inv_no) = 'B' " & _
                    "group by a.client_code, a.stock_code, rtrim(a.inv_no), b.margin_ratio, b.market_price " & _
                    "order by a.client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.client_code, rtrim(a.inv_no) as type, a.stock_code, sum(a.qty) as qty, b.margin_ratio, " & _
                    "b.market_price, (sum(a.qty)*market_price*margin_ratio) as margin_value " & _
                    "into #stcltsell_tmp " & _
                    "from #ststktxnlst a, #stcltportfolio b, sttxndate " & _
                    "where a.client_code = b.client_code and a.stock_code = b.stock_code and a.tdate = sttxndate.date and rtrim(a.inv_no) = 'S' " & _
                    "group by a.client_code, a.stock_code, rtrim(a.inv_no), b.margin_ratio, b.market_price order by a.client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select client_code, stock_code, margin_value " & _
                    "into #stcltnet_tmp " & _
                    "from( " & _
                    "select a.client_code, a.stock_code, (a.margin_value-b.margin_value) as margin_value " & _
                    "from #stcltbuy_tmp a, #stcltsell_tmp b " & _
                    "where a.client_code = b.client_code and a.stock_code = b.stock_code " & _
                    "union all " & _
                    "select client_code, stock_code, margin_value " & _
                    "from #stcltbuy_tmp " & _
                    "where client_code not in (select client_code from #stcltsell_tmp " & _
                    "where #stcltbuy_tmp.client_code = #stcltsell_tmp.client_code " & _
                    "and #stcltbuy_tmp.stock_code = #stcltsell_tmp.stock_code) " & _
                    ") tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select * " & _
                    "into #stcltnetmv_tmp " & _
                    "from #stcltnet_tmp where margin_value > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select client_code, sum(margin_value) as margin_value " & _
                    "into #stcltmv_tmp " & _
                    "from #stcltnetmv_tmp group by client_code "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster " & _
                    "set stcltmaster.mc_due = stcltmaster.mc_due + #stcltmv_tmp.margin_value " & _
                    "from stcltmaster, #stcltmv_tmp " & _
                    "where stcltmaster.clt_code = #stcltmv_tmp.client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltbuy_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltsell_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltnet_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltnetmv_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltmv_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_due = 0 where mc_due < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_t2 = 0 where mc_t2 < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_overdraft = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_overdraft = mc_total - mc_due - mc_t2 where  mc_total > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_overdraft = 0 where mc_overdraft < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_total = mc_cr_bal * (-1) where clt_type = 'C' and mc_cr_bal > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_total = mc_dr_bal where clt_type = 'C' and mc_dr_bal > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_t2 = t2_unrealized * (-1) where clt_type = 'C'"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set mc_due = mc_total - mc_t2 where clt_type = 'C'"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set avail_bal = t2_unrealized"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set avail_bal = 0 where avail_bal < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set avail_bal = mc_cr_bal - mc_dr_bal - avail_bal"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set avail_bal = 0 where avail_bal < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 client liquidation list
    Protected Friend Sub lFncUpdateNewStCltLiqList(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "select a.client_code, rtrim(a.inv_no) as type, a.stock_code, sum(a.qty) as qty, b.margin_ratio, b.market_price, b.market_value " & _
                    "into #stcltbuy_tmp " & _
                    "from #ststktxnlst a, #stcltportfolio b, sttxndate " & _
                    "where a.client_code=b.client_code and a.stock_code = b.stock_code and a.tdate = sttxndate.date and rtrim(a.inv_no)='B' " & _
                    "group by a.client_code,a.stock_code, rtrim(a.inv_no), b.margin_ratio, b.market_price, b.market_value"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.client_code, rtrim(a.inv_no) as type, a.stock_code, sum(a.qty) as qty, b.margin_ratio, b.market_price " & _
                    "into #stcltsell_tmp " & _
                    "from #ststktxnlst a, #stcltportfolio b, sttxndate " & _
                    "where a.client_code=b.client_code and a.stock_code = b.stock_code and a.tdate = sttxndate.date and rtrim(a.inv_no)='S' " & _
                    "group by a.client_code, a.stock_code, rtrim(a.inv_no), b.margin_ratio, b.market_price"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.client_code, a.stock_code, a.margin_ratio, a.market_price, a.qty as b_qty, b.qty as s_qty, " & _
                    "a.qty as n_qty, a.market_value as n_mkt_value, a.market_value as n_margin_value " & _
                    "into #stcltnetbuy_tmp " & _
                    "from #stcltbuy_tmp a left join #stcltsell_tmp b on a.client_code = b.client_code and a.stock_code = b.stock_code " & _
                    "where a.client_code in (select clt_code from stcltmaster where stcltmaster.clt_type = 'M' or stcltmaster.clt_type = 'F')"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_qty = 0, n_mkt_value = 0, n_margin_value = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set s_qty = 0 where s_qty is null"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_qty = b_qty - s_qty"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_qty = 0 where n_qty < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_mkt_value = n_qty * market_price"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_margin_value = n_qty * market_price * margin_ratio"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select client_code, sum(n_mkt_value) as market_value, sum(n_margin_value) as margin_value " & _
                    "into #stcltnet_tmp " & _
                    "from #stcltnetbuy_tmp " & _
                    "where n_qty > 0 " & _
                    "group by client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        lstrSQL = "delete from client_mkt_mrg "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into client_mkt_mrg(client_code, market_value, margin_value) " & _
                    "select client_code, market_value, margin_value " & _
                    "from #stcltnet_tmp "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "delete from client_fund_movement "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into client_fund_movement(accno, amount, amount_type) " & _
                    "select client_code, amount, amount_type " & _
                    "from #IbsCacCup1 "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "delete from client_liq_master "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into client_liq_master(CLT_CODE,CLT_TYPE,CLT_NAME,RUN_CODE,CR_LIMIT,CR_BAL,DR_BAL,DEPOSIT, " & _
                    "WITHDRAWAL,AVAIL_BAL,MKT_VALUE,MARGIN_VALUE,MARGIN_RATIO,NET_TRADE,T1_UNREALIZED,T2_UNREALIZED, " & _
                    "INTEREST,MC_CR_BAL,MC_DR_BAL,MC_ACT_RATIO,MC_DUE,MC_T2,MC_OVERDRAFT,MC_TOTAL,OS_DAY,SHORT) " & _
                    "select CLT_CODE,CLT_TYPE,CLT_NAME,RUN_CODE,CR_LIMIT,CR_BAL,DR_BAL,DEPOSIT,WITHDRAWAL,AVAIL_BAL," & _
                    "MKT_VALUE,MARGIN_VALUE,MARGIN_RATIO,NET_TRADE,T1_UNREALIZED,T2_UNREALIZED,INTEREST,MC_CR_BAL," & _
                    "MC_DR_BAL,MC_ACT_RATIO,MC_DUE,MC_T2,MC_OVERDRAFT,MC_TOTAL,OS_DAY,SHORT " & _
                    "from STCLTMASTER "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        lstrSQL = "drop table #stcltbuy_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltsell_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltnetbuy_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltnet_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 client liquidation list
    Protected Friend Sub lFncUpdateStCltLiqList(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "delete from stcltliqlist"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.client_code, rtrim(a.inv_no) as type, a.stock_code, sum(a.qty) as qty, b.margin_ratio, b.market_price, b.market_value " & _
                    "into #stcltbuy_tmp " & _
                    "from #ststktxnlst a, #stcltportfolio b, sttxndate " & _
                    "where a.client_code=b.client_code and a.stock_code = b.stock_code and a.tdate = sttxndate.date and rtrim(a.inv_no)='B' " & _
                    "group by a.client_code,a.stock_code, rtrim(a.inv_no), b.margin_ratio, b.market_price, b.market_value"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.client_code, rtrim(a.inv_no) as type, a.stock_code, sum(a.qty) as qty, b.margin_ratio, b.market_price " & _
                    "into #stcltsell_tmp " & _
                    "from #ststktxnlst a, #stcltportfolio b, sttxndate " & _
                    "where a.client_code=b.client_code and a.stock_code = b.stock_code and a.tdate = sttxndate.date and rtrim(a.inv_no)='S' " & _
                    "group by a.client_code, a.stock_code, rtrim(a.inv_no), b.margin_ratio, b.market_price"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.client_code, a.stock_code, a.margin_ratio, a.market_price, a.qty as b_qty, b.qty as s_qty, " & _
                    "a.qty as n_qty, a.market_value as n_mkt_value, a.market_value as n_margin_value " & _
                    "into #stcltnetbuy_tmp " & _
                    "from #stcltbuy_tmp a left join #stcltsell_tmp b on a.client_code = b.client_code and a.stock_code = b.stock_code " & _
                    "where a.client_code in (select clt_code from stcltmaster where stcltmaster.clt_type = 'M' or stcltmaster.clt_type = 'F')"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_qty = 0, n_mkt_value = 0, n_margin_value = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set s_qty = 0 where s_qty is null"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_qty = b_qty - s_qty"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_qty = 0 where n_qty < 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_mkt_value = n_qty * market_price"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #stcltnetbuy_tmp set n_margin_value = n_qty * market_price * margin_ratio"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select client_code, sum(n_mkt_value) as market_value, sum(n_margin_value) as margin_value " & _
                    "into #stcltnet_tmp " & _
                    "from #stcltnetbuy_tmp " & _
                    "where n_qty > 0 " & _
                    "group by client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.clt_code, a.run_code, a.mc_dr_bal as dr, a.mc_act_ratio as ar, a.mc_total as mc, a.mc_due as due, a.mc_t2 as undue, " & _
                    "a.margin_ratio as mr, a.cr_limit as cl, a.clt_type, a.margin_value as due_mv, b.margin_value as undue_margin_value, " & _
                    "b.market_value as undue_mv, a.short " & _
                    "into #margin_tmp " & _
                    "from stcltmaster a left join #stcltnet_tmp b on a.clt_code = b.client_code " & _
                    "where (a.clt_type = 'M' or a.clt_type = 'F')"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #margin_tmp set undue_margin_value = 0 where undue_margin_value is null"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #margin_tmp set undue_mv = 0 where undue_mv is null"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #margin_tmp set due_mv = due_mv - undue_margin_value"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code, '*'  as is_ar, '*' as is_mr " & _
                    "into #clt_tmp " & _
                    "from #margin_tmp " & _
                    "where ((((dr< 300000) and ((ar>=0.6 and mr>=1) or dr>=(due_mv*1.6+undue_mv*0.7))) " & _
                    "or ((300000<=dr and dr<1000000) and ((ar>=0.5 and mr>=1) or dr>=(due_mv*1.6+undue_mv*0.7))) " & _
                    "or ((1000000<=dr and dr<3000000) and ((ar>=0.4 and mr>=1) or dr>=(due_mv*1.3+undue_mv*0.7))) " & _
                    "or ((3000000<=dr) and dr>=(due_mv*1.0+undue_mv*0.7))) " & _
                    "or (cl<100 and mc>0) or ((dr-cl)>0)) " & _
                    "and (not (dr<=1000000 and due=0 and undue>=0 and ar<0.7)) " & _
                    "or (short=1)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.clt_code " & _
                    "into #good_ar_tmp " & _
                    "from #margin_tmp a, #clt_tmp b " & _
                    "where a.clt_code = b.clt_code and ((((dr< 300000) and ((ar<0.6 or mr<1))) " & _
                    "or ((300000<=dr and dr<1000000) and ((ar<0.5 or mr<1))) or " & _
                    "((1000000<=dr and dr<3000000) and ((ar<0.4 or mr<1)))))"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.clt_code " & _
                    "into #good_mr_tmp " & _
                    "from #margin_tmp a, #clt_tmp b " & _
                    "where a.clt_code = b.clt_code and ((((dr< 300000) and (dr<(due_mv*1.6+undue_mv*0.7))) " & _
                    "or ((300000<=dr and dr<1000000) and (dr<(due_mv*1.6+undue_mv*0.7))) " & _
                    "or ((1000000<=dr and dr<3000000) and ( dr<(due_mv*1.3+undue_mv*0.7))) or ((3000000<=dr) and dr<(due_mv*1.0+undue_mv*0.7))))"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #clt_tmp set is_ar = ' ' where clt_code not in (select clt_code from #good_ar_tmp) "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #clt_tmp set is_mr = ' ' where clt_code not in (select clt_code from #good_mr_tmp)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code, dr_bal as amt " & _
                    "INTO #cash_tmp " & _
                    "from stcltmaster " & _
                    "where clt_type = 'C'"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #cash_tmp set amt = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.client_code, sum(a.amount) as amount " & _
                    "into #cashin_tmp " & _
                    "from #ibscaccup1 a, stcltmaster b " & _
                    "where a.client_code = b.clt_code and b.clt_type = 'C' and a.amount <> 0 " & _
                    "group by a.client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #tmpcash " & _
                    "from #cash_tmp " & _
                    "where clt_code in (select clt_code from #cash_tmp) ORDER BY clt_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update #cash_tmp " & _
                    "set amt = amt + tmp.amount " & _
                    "from #cash_tmp, " & _
                    "(select client_code, amount from #cashin_tmp, #tmpcash where #cashin_tmp.client_code = #tmpcash.clt_code) tmp " & _
                    "where #cash_tmp.clt_code = tmp.client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set deposit = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #tmpmst " & _
                    "from stcltmaster " & _
                    "where clt_code in (select clt_code from #cash_tmp where amt <> 0) " & _
                    "ORDER BY clt_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster " & _
                    "set deposit = tmp.amt " & _
                    "from stcltmaster, " & _
                    "(select #tmpmst.clt_code, amt from #tmpmst, #cash_tmp where #tmpmst.clt_code = #cash_tmp.clt_code) tmp " & _
                    "where stcltmaster.clt_code = tmp.clt_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set deposit = 0 where deposit is null"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #os_tmp " & _
                    "from stcltmaster " & _
                    "where clt_type = 'C' and ((withdrawal > 0 and withdrawal > deposit) or (mc_act_ratio > 0.7) or (short = 1))"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set os_day = 0 where clt_code not in (select clt_code from #os_tmp)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set os_day = os_day + 1 where clt_code in (select clt_code from #os_tmp)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into #clt_tmp(clt_code, is_ar, is_mr) select clt_code, ' ', ' ' from #os_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into stcltliqlist(clt_code, ar_good, mr_good) select clt_code, is_ar, is_mr from #clt_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltbuy_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltsell_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltnetbuy_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stcltnet_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #margin_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #clt_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #good_ar_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #good_mr_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #tmpcash"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #cashin_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #cash_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #tmpmst"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #os_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 client master liquidation
    Protected Friend Sub lFncUpdateStCltMastLiq(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "select clt_code, sttxndate.date as start_date, 0 as os_day " & _
                    "into #new_tmp " & _
                    "from stcltliqlist, sttxndate " & _
                    "where clt_code not in (select clt_code from stcltliq)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #del_tmp " & _
                    "from stcltliq " & _
                    "where clt_code not in (select clt_code from stcltliqlist)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into stcltliq(clt_code, start_date, os_day, liq_day, ar_good, mr_good) " & _
                    "select clt_code, start_date, os_day, os_day, '', '' from #new_tmp ORDER BY clt_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "delete from stcltliq where clt_code in (select clt_code from #del_tmp)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltliq set os_day = os_day + 1"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster set os_day = 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltmaster " & _
                    "set stcltmaster.os_day = stcltliq.os_day " & _
                    "from stcltmaster, stcltliq " & _
                    "where stcltliq.clt_code = stcltmaster.clt_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltliq " & _
                    "set stcltliq.ar_good = isnull(stcltliqlist.ar_good, ' '), " & _
                    "stcltliq.mr_good = isnull(stcltliqlist.mr_good, ' ') " & _
                    "from stcltliq, stcltliqlist " & _
                    "where stcltliqlist.clt_code = stcltliq.clt_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #clt_must_liq_tmp " & _
                    "from stcltliq " & _
                    "where clt_code in (select a.clt_code from stcltmaster a, stcltliqlist b " & _
                    "where a.clt_code = b.clt_code and (not (((a.mc_dr_bal<500) " & _
                    "or (a.mc_act_ratio < 0.01 and a.mc_dr_bal< 10000 ) " & _
                    "or (a.mc_act_ratio < 0.05 and a.mc_dr_bal< 2000 )) and (a.short = 0)) " & _
                    "or (a.clt_type = 'C' and a.withdrawal>0 and a.withdrawal>a.deposit)))"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #clt_need_liq_tmp " & _
                    "from stcltliq " & _
                    "where clt_code in (select a.clt_code from stcltmaster a, stcltliqlist b " & _
                    "where a.clt_code = b.clt_code 	and ((((a.mc_dr_bal<500) " & _
                    "or (a.mc_act_ratio < 0.01 and a.mc_dr_bal < 10000 ) or " & _
                    "(a.mc_act_ratio < 0.05 and a.mc_dr_bal < 2000 )) and (a.short = 0)))) " & _
                    "and os_day >=20"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #clt_no_liq_tmp " & _
                    "from stcltliq " & _
                    "where clt_code not in (select clt_code from #clt_must_liq_tmp) and clt_code not in (select clt_code from #clt_need_liq_tmp)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltliq " & _
                    "set liq_day = liq_day + 1 " & _
                    "where clt_code in (select clt_code from #clt_must_liq_tmp) or clt_code in (select clt_code from #clt_need_liq_tmp)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltliq " & _
                    "set liq_day = 0 " & _
                    "where clt_code in (select clt_code from #clt_no_liq_tmp)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #new_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #del_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #clt_must_liq_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #clt_need_liq_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #clt_no_liq_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 client master futures liquidation
    Protected Friend Sub lFncUpdateStCltMastLiqFb(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "select a.clt_code " & _
                    "into #clt_tmp " & _
                    "from stcltliq a, stcltmaster b " & _
                    "where a.clt_code = b.clt_code and (not b.mkt_value = 0) and a.liq_day > 0"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code, -1 as tolerate_day, sttxndate.date as start_date, 0 as os_day, 0 as liq_day " & _
                    "into #new_tmp " & _
                    "from #clt_tmp, sttxndate " & _
                    "where clt_code not in (select clt_code from stcltliqfb) ORDER BY clt_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #del_tmp " & _
                    "from stcltliqfb " & _
                    "where clt_code not in (select clt_code from #clt_tmp)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into stcltliqfb(clt_code, tolerate_day, start_date, os_day, liq_day) " & _
                    "select clt_code, tolerate_day, start_date, os_day, liq_day from #new_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "delete from stcltliqfb where clt_code in (select clt_code from #del_tmp)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #clt_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code, mc_dr_bal as dr_bal, mc_act_ratio as ar " & _
                    "into #clt_tmp " & _
                    "from stcltmaster " & _
                    "where clt_code in (select clt_code from stcltliqfb)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #day1_tmp " & _
                    "from #clt_tmp " & _
                    "where ((dr_bal< 300000) and (ar<0.6 or (0.6<=ar and ar<=0.7))) or ((300000<=dr_bal and dr_bal<1000000) " & _
                    "and (ar<0.5 or (0.5<=ar and ar<=0.6))) or ((1000000<=dr_bal and dr_bal<3000000) " & _
                    "and (ar<0.4 or (0.4<=ar and ar<=0.5))) or ((3000000<=dr_bal) and (ar<=0.4))"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select clt_code " & _
                    "into #day0_tmp " & _
                    "from #clt_tmp " & _
                    "where ((dr_bal< 300000) and (ar>0.7)) or ((300000<=dr_bal and dr_bal<1000000) and (ar>0.6)) " & _
                    "or ((1000000<=dr_bal and dr_bal<3000000) and (ar>0.5)) or ((3000000<=dr_bal) and (ar>0.4))"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltliqfb " & _
                    "set stcltliqfb.tolerate_day = 1 " & _
                    "where stcltliqfb.clt_code in (select #day1_tmp.clt_code from #day1_tmp) and (stcltliqfb.tolerate_day < 1 or stcltliqfb.tolerate_day=-1)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltliqfb " & _
                    "set stcltliqfb.tolerate_day = 0 " & _
                    "where stcltliqfb.clt_code in (select #day0_tmp.clt_code from #day0_tmp) and (stcltliqfb.tolerate_day < 0 or stcltliqfb.tolerate_day=-1)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.clt_code, (a.liq_day-b.tolerate_day-1) as os_day " & _
                    "into #liq_tmp " & _
                    "from stcltliq a,stcltliqfb b " & _
                    "where a.clt_code = b.clt_code and (a.liq_day-b.tolerate_day) > 1"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltliqfb " & _
                    "set stcltliqfb.os_day = #liq_tmp.os_day " & _
                    "from stcltliqfb, #liq_tmp " & _
                    "where stcltliqfb.clt_code = #liq_tmp.clt_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "select a.clt_code,b.liq_day " & _
                    "into #updt_tmp " & _
                    "from stcltmaster a,stcltliq b " & _
                    "where a.clt_code = b.clt_code and a.clt_type = 'C' and b.liq_day > 0 and a.clt_code in (select clt_code from stcltliqfb)"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltliqfb set stcltliqfb.tolerate_day = 0, " & _
                    "stcltliqfb.os_day = stcltliq.liq_day-1 " & _
                    "from stcltliqfb, stcltliq, #updt_tmp " & _
                    "where stcltliqfb.clt_code = #updt_tmp.clt_code " & _
                    "and stcltliq.clt_code = #updt_tmp.clt_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update stcltliqfb set liq_day = os_day"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "delete from stcltliqfblist"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into stcltliqfblist(clt_code, tolerate_day, start_date, active_day, os_day) " & _
                    "select clt_code, tolerate_day, start_date, 0, os_day from stcltliqfb"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #clt_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #new_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #del_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #liq_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #updt_tmp"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 client's ae code
    Protected Friend Sub lFncUpdateAEMaster(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "update stcltmaster " & _
                    "set run_code = rtrim(tmp.ae_code) " & _
                    "from stcltmaster, " & _
                    "#aemaster tmp " & _
                    "where stcltmaster.clt_code = tmp.client_code"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "insert into staemaster(run_code, run_name) " & _
                    "select aeno, aename " & _
                    "from #staemaster " & _
                    "where rtrim(aeno) not in " & _
                    "(select rtrim(run_code) " & _
                    "from staemaster) "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "update staemaster " & _
                    "set staemaster.run_name = #staemaster.aename, " & _
                    "staemaster.branch_name = #staemaster.branchname " & _
                    "from #staemaster " & _
                    "where staemaster.run_code = #staemaster.aeno "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    'This function is used to update EBS3 completion time and cleanup all temp. table
    Protected Friend Sub lFncFinish(ByVal myTrans As SqlTransaction)

        Dim lstrSQL As String = ""

        lstrSQL = "update stcontrol set endtime = GETDATE(), procflag = 1"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "INSERT INTO stimportdate(impdate, msg) VALUES (getdate(), 'Import Liquidation Data Completed')"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #lasttradedate"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #testbal"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #StStkTxnLst"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #TestTrade"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #TestPort"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #TestStatus"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #suspendstock"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #IbsCacCup1"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #StCltPortfolio"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #MonthComm"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #MonthCommF"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #MonthInt"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #acbal"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #allstock"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #stock_con"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #aemaster"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        lstrSQL = "drop table #staemaster"
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    Protected Friend Sub lFncCleanLog()
        Dim lstrSQL As String = "backup log esl_liq with truncate_only"
        GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
        lstrSQL = "dbcc shrinkfile (esl_liq_log,0)"
        GFncRunSQL(GSCnLiqConn, lstrSQL, 0)
    End Sub

    'This function is used to get EBS3 last trade date
    Protected Friend Function lFncGetEBS3LastTradeDate() As DataSet

        Dim lstrSQL As String = ""

        lstrSQL = "SELECT tradedate, procflag from stcontrol"
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, 0)

    End Function

    'This function is used to get G2BS last trade date
    Protected Friend Function lFncGetG2BLastTradeDate() As DataSet

        Dim lstrSQL As String = ""

        lstrSQL = "SELECT trade_date FROM " & GStrG2BSDB & ".dbo.View_er_system_parameter"
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, 0)

    End Function

    'This function is used to update EBS3 client's ae code
    Protected Friend Sub lFncUpdateCltTurnover(ByVal myTrans As SqlTransaction, ByVal lastTradeDate As Date, _
                                                ByVal currTradeDate As Date)

        Dim lstrSQL As String = ""

        'update client last trade date
        lstrSQL = "update STCLTMASTER " & _
                    "set STCLTMASTER.lastTradeDate = #client_last_trade_day.lastday " & _
                    "from #client_last_trade_day " & _
                    "where STCLTMASTER.CLT_CODE = #client_last_trade_day.client_code "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        'calculate client's today total turnover
        lstrSQL = "select client_code, sum(total) as turnover " & _
                    "into #cltTotalTurnover " & _
                    "from #StStkTxnLst " & _
                    "group by client_code "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        If (Year(lastTradeDate) <> Year(currTradeDate)) Then
            lstrSQL = "update stcltmaster set prev_year_turnover = curr_year_turnover "
            GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
            lstrSQL = "update stcltmaster set curr_year_turnover = 0 "
            GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        End If

        If (Month(lastTradeDate) <> Month(currTradeDate)) Then
            lstrSQL = "update stcltmaster set prev_mth_turnover = curr_mth_turnover "
            GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
            lstrSQL = "update stcltmaster set curr_mth_turnover = 0 "
            GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)
        End If

        lstrSQL = "update stcltmaster " & _
                    "set curr_mth_turnover = curr_mth_turnover + #cltTotalTurnover.turnover " & _
                    "from #cltTotalTurnover " & _
                    "where clt_code = #cltTotalTurnover.client_code "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

        lstrSQL = "update stcltmaster " & _
                    "set curr_year_turnover = curr_year_turnover + #cltTotalTurnover.turnover " & _
                    "from #cltTotalTurnover " & _
                    "where clt_code = #cltTotalTurnover.client_code "
        GFncRunSQL(GSCnLiqConn, myTrans, lstrSQL, 0)

    End Sub

    Public Sub lFncCreateImportMark(ByVal StrPath As String)

        If Not (System.IO.Directory.Exists(StrPath)) Then
            System.IO.Directory.CreateDirectory(StrPath)
        End If

        If Not (System.IO.File.Exists(StrPath & "importdata.txt")) Then
            System.IO.File.Create(StrPath & "importdata.txt").Close()
        End If

    End Sub

    Public Sub lFncDeleteImportMark(ByVal StrPath As String)

        System.IO.File.Delete(StrPath & "importdata.txt")

    End Sub

End Class
