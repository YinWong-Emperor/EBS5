Imports System.Data.SqlClient

Public Class ClsImportFuturesComm


    Private Sub runFnc(ByVal fncName As String)

        GSubWriteEventLog(fncName, "C:\errorpath")
        Application.DoEvents()

    End Sub

    Protected Friend Function lFncTradeDateImported(ByVal nyear As String, ByVal nmonth As String) As Boolean

        Dim strSQL As String
        Dim lds As DataSet
        Dim cnt As Integer = 0

        strSQL = "Select * from comm_trade_s where txmonth = '" & nyear & nmonth & "'"
        lds = GFncRtnDS(GSCnSqlConn, strSQL, 0)
        cnt = lds.Tables(0).Rows.Count

        strSQL = "Select * from comm_trade_f where txmonth = '" & nyear & nmonth & "'"
        lds = GFncRtnDS(GSCnSqlConn, strSQL, 0)
        cnt = cnt + lds.Tables(0).Rows.Count

        Return (cnt > 0)

    End Function

    Protected Friend Function lFncUpdateDataFromG2B(ByVal nyear As String, ByVal nmonth As String, _
                                                    ByVal smonth As String) As Boolean

        Dim MyTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = ""

        runFnc(" start to Import Commission")
        Try
            runFnc("0) ImportDataFromG2B")
            lFncImportDataFromG2B(nyear, nmonth, smonth, lstrSQL)
            MyTrans = GSCnSqlConn.BeginTransaction

            runFnc("1) UpdateAEMasterFromG2B")
            lFncUpdateAEMasterFromG2B(MyTrans, lstrSQL)
            runFnc("2) pdateClientMasterFromG2B")
            lFncUpdateClientMasterFromG2B(MyTrans, lstrSQL)
            runFnc("3) UpdateRateFromG2B")
            lFncUpdateRateFromG2B(nyear, nmonth, MyTrans, lstrSQL)
            runFnc("4) UpdateProductMasterF")
            lFncUpdateProductMasterF(nyear, nmonth, MyTrans, lstrSQL)
            runFnc("5) UpdateTradeFromG2B")
            lFncUpdateTradeFromG2B(nyear, nmonth, smonth, MyTrans, lstrSQL)

            MyTrans.Commit()
            MyTrans = Nothing
            runFnc("6) ClearTempTable")
            lFncClearTempTable(lstrSQL)
            runFnc(" Complete to Import Commission")

            Return True
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message & " - " & lstrSQL)
            End If
            Return False
        End Try


    End Function

    Protected Friend Sub lFncImportDataFromG2B(ByVal nyear As String, ByVal nmonth As String, ByVal smonth As String, ByRef strSQL As String)

        Dim dbStoreProS As String = "G2BS_LASTM"
        Dim dbStoreProF As String = "G2BF_LASTM"

        'Dim dbStoreProS As String = "G2BS_RET"
        'Dim dbStoreProF As String = "G2BF_RET"
        Dim dbStringS As String = GStrG2BSLMTHDB
        Dim dbStringF As String = GStrG2BFLMTHDB


        'Dim dbStoreProS As String = "G2BS_UAT" 'for testing
        'Dim dbStoreProF As String = "G2BF_UAT"
        'Dim dbStringS As String = "G2BS_UAT.G2BS_RET_LASTM"
        'Dim dbStringF As String = "G2BF_UAT.G2BF_UAT"

        'import securities data from afe
        'ae master
        strSQL = "select ltrim(rtrim(aeno)) as aeno, ltrim(rtrim(name)) as aename " & _
                    "into #aes " & _
                    "from " & dbStringS & ".dbo.ae_master "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        'account master
        strSQL = "select ltrim(rtrim(accno)) as accno, ltrim(rtrim(name_1)) as accname, ltrim(rtrim(aeno)) as aeno " & _
                    "into #accs " & _
                    "from " & dbStringS & ".dbo.view_it_client_all "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        'last month trade
        'strSQL = "SELECT ae, acct, tdate, oid, stk, price, qty, grossamt, commission, comm_rate, tradetype, rebate " & _
        '          "into #trades " & _
        '          "FROM OPENQUERY (" & dbStoreProS & ", 'SET FMTONLY OFF EXEC rpt_MSSAERDR03_ER ''366'', ''" & smonth & _
        '          " " & nyear & "'', ''''  ' ) "
        strSQL = "SELECT ae, acct, tdate, oid, stk, price, qty, grossamt, commission, comm_rate, tradetype, rebate " & _
                  "into #trades " & _
                  "FROM OPENQUERY (" & dbStoreProS & ", 'SET FMTONLY OFF EXEC rpt_MSSAERDR03_ER ''366'', ''" & smonth & _
                  " " & nyear & "'', ''''  WITH RESULT SETS((p_month char(8),  p_cnt money,    groupfield varchar(111),  tdate char(15),  oid char(12),    tradetype char(1),  mkt char(44),  ccy_charge char(4),  AE char(60),  acct char(82),  stk char(41),  price decimal(19,6), qty decimal(18,6), grossamt decimal(38,6)  ,  commission money,  rebate money,  netamt_charge_ccy  decimal(38,6),  comm_rate varchar,  stamp varchar,  price_dp int,  qty_dp int,company_ccy char(4),grossamt_company_ccy decimal(18,6),commission_company_ccy decimal(18,6),  rebate_company_ccy decimal(18,6)) )' ) "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        'strSQL = "select * into  #trades from temp_trades_s  "
        'GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = " select cn_no, accno, name_1 as acc_name, oid, stkno, stkname, " & _
                " price, ttlqty, price * ttlqty as grossamt, " & _
                " commission, comm_rate, tradetype, currency_code_set, market, tdate,rebate * (-1) as rebate, aeno, ae_name " & _
                " into #trades_other " & _
                " from " & dbStringS & ".dbo.view_it_trade_detail " & _
                " where Month(tdate) = " & nmonth & _
                " and year(tdate) = " & nyear & _
                " and market <> 'SEHK' "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "select accno, name_1, stkno, s_code, aeno, ae_name, cn_no " & _
                    "into #tradesinfo " & _
                    "from " & dbStringS & ".dbo.view_ctrade_namt_order  " & _
                    "union all " & _
                    "select accno, name_1, stkno, s_code, aeno, b.name, cn_no " & _
                    "from " & dbStringS & ".dbo.view_hs_ctrade_namt_order a " & _
                    "left join " & dbStringS & ".dbo.ae_master b on a.uid = b.aeid"
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        'rebate rate
        strSQL = "select rtrim(a.accno) as accno, rtrim(c.aeno) as aeno, f.name as nature_name, e.name as fee_name, " & _
                    "e.rate, e.rate_1, e.rate_2, e.rate_3, e.rate_4, e.rate_5, e.rate_6, e.rate_7, e.rate_8, e.rate_9, " & _
                    "e.upper_1, e.upper_2, e.upper_3, e.upper_4, e.upper_5, e.upper_6, e.upper_7, e.upper_8, e.upper_9, " & _
                    "e.min_f into #rates " & _
                    "from " & dbStringS & ".dbo.client_master a " & _
                    "inner join " & dbStringS & ".dbo.client_master_s b on a.aid = b.aid " & _
                    "inner join " & dbStringS & ".dbo.ae_master c on b.aeid = c.aeid " & _
                    "inner join " & dbStringS & ".dbo.Client_Fee d on a.aid = d.aid " & _
                    "inner join " & dbStringS & ".dbo.fee_master e on d.fid = e.fid " & _
                    "inner join " & dbStringS & ".dbo.FeeNature_master f on d.fuid = f.fuid " & _
                    "where f.name in ('A/E Rebate','A/E Rebate (i)') "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        'import futures data from afe
        'ae master
        strSQL = "select ltrim(rtrim(aeno)) as aeno, ltrim(rtrim(name)) as aename " & _
                    "into #aef " & _
                    "from " & dbStringF & ".dbo.ae_master "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        'account master
        strSQL = "select ltrim(rtrim(accno)) as accno, ltrim(rtrim(name_1)) as accname, ltrim(rtrim(aeno)) as aeno " & _
                    "into #accf " & _
                    "from " & dbStringF & ".dbo.view_it_client_all "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        'product master
        strSQL = "select rtrim(a.code) as product_code, rtrim(a.name) as product_name, 'G' as gross_net, " & _
                    "0 as position_limit, rtrim(b.name) as market, 0 as email_alert, a.ptype, rtrim(c.name_s) as currency, " & _
                    "0 as month_alert into #product_master_f " & _
                    "from " & dbStringF & ".dbo.commod_master a " & _
                    "inner join " & dbStringF & ".dbo.market_master b on a.mkid = b.mkid " & _
                    "inner join " & dbStringF & ".dbo.currency_master c on a.cuid_trd = c.cuid "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        'last month trade
        'strSQL = "SELECT * into #tradef " & _
        '          "FROM OPENQUERY (" & dbStoreProF & ", 'SET FMTONLY OFF;  EXEC  rpt_IT_DSFAERB01_ER ''999''  ' )"
        strSQL = "SELECT * into #tradef " & _
                  "FROM OPENQUERY (" & dbStoreProF & ", 'SET FMTONLY OFF;  EXEC  rpt_IT_DSFAERB01_ER ''999''  WITH RESULT SETS (([A/E Code] char(20), [A/E Name] char(40) ,   [Account Code] char(20), [Name_1] nchar(60), [Name_2] nchar(40),   [Comdy] char(10), [Month] char(4), [CALL/PUT] char(1), [Strike] decimal(18,8),   s_price_str varchar(50),  day_dd int, night_dd int, tg_dd int,  commission_dd money, exchange_fee_dd money, ae_rebate_dd money,  commission_mm money, exchange_fee_mm money, ae_rebate_mm money,  day_mm int, night_mm int, tg_mm int,  [Market Name] char(60), [CCY] char(4)))' )"

            GFncRunSQL(GSCnSqlConn, strSQL, 0)

            'strSQL = "select * into  #tradef from temp_trades_f  "
            'GFncRunSQL(GSCnSqlConn, strSQL, 0)

            'last month commission
        'strSQL = "SELECT * into #comm " & _
        '            "FROM OPENQUERY (" & dbStoreProF & ", 'SET NOCOUNT ON; SET FMTONLY OFF;  EXEC  rpt_IT_MSFCRR14 ''999'', ''" & _
        '            smonth & " " & nyear & "'', '' ''  ' ) " & _
        '            "where substring(tdate,4,2) = '" & nmonth & "' and substring(tdate,7,2) = '" & Right(nyear, 2) & "'"
        strSQL = "SELECT * into #comm " & _
                        "FROM OPENQUERY (" & dbStoreProF & ", 'SET NOCOUNT ON; SET FMTONLY OFF;  EXEC  rpt_IT_MSFCRR14 ''999'', ''" & _
                        smonth & " " & nyear & "'', '' ''  WITH RESULT SETS ((cmid char(10), aeid char(10), aeno char(20), ae_name char(40),   oid varchar(11),  group_o char(10), acct nchar(60),  market char(68),  ccy char(4),comdy_code nvarchar(22),  dec_loc smallint, [MONTH] char(4),put_call char(1),s_price decimal(18,8),price_str varchar(50),s_price_str varchar(50),future_type char(1),  [TYPE] char(1), tdate char(15),  qty_day int,qty_night int,qty_tg int, comm money, exchange_fee money, levy money, rebate money,  m_qty_day int, m_qty_night int,m_qty_tg int,m_comm money,m_exchange_fee money,m_levy money, m_rebate money,  bhid char(10), tradetype char(1),  tranxdate_b char(20),  tranxdate_e char(20)))' ) " & _
                        "where substring(tdate,4,2) = '" & nmonth & "' and substring(tdate,7,2) = '" & Right(nyear, 2) & "'"
            GFncRunSQL(GSCnSqlConn, strSQL, 0)

            'strSQL = "select * into  #comm from temp_comm_f  "
            'GFncRunSQL(GSCnSqlConn, strSQL, 0)

    End Sub

    Protected Friend Sub lFncUpdateAEMasterFromG2B(ByRef MyTrans As SqlTransaction, ByRef strSQL As String)

        strSQL = "insert into comm_ae_master(ae_no, ae_name, ae_name_s, ae_name_f, bank_code, bank_acc, IR56M_flag, inSec, inFut) " & _
                    "select aeno, '', aename, '', '', '', 'N', 1, 0 " & _
                    "from #aes " & _
                    "where aeno collate database_default not in (select ae_no from comm_ae_master)"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = "insert into comm_ae_master(ae_no, ae_name, ae_name_s, ae_name_f, bank_code, bank_acc, IR56M_flag, inSec, inFut) " & _
                    "select aeno, '', aename, '', '', '', 'N', 0, 1 " & _
                    "from #aef " & _
                    "where aeno collate database_default not in (select ae_no from comm_ae_master)"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = "update comm_ae_master " & _
                    "set comm_ae_master.ae_name_s = a.aename, inSec = 1 " & _
                    "from #aes a " & _
                    "where comm_ae_master.ae_no = a.aeno collate database_default "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = "update comm_ae_master " & _
                    "set comm_ae_master.ae_name_f = a.aename, inFut = 1 " & _
                    "from #aef a " & _
                    "where comm_ae_master.ae_no = a.aeno collate database_default "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = " delete from draft_comm_ae_master "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = " insert into draft_comm_ae_master select * from comm_ae_master "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
    End Sub

    Protected Friend Sub lFncUpdateClientMasterFromG2B(ByRef MyTrans As SqlTransaction, ByRef strSQL As String)


        strSQL = "insert into comm_acc_master(acc_no, acc_name, ae_no_s, ae_no_f, acc_name_s, acc_name_f, turnover_con_flag, inSec, inFut) " & _
                    "select accno, '', aeno, '', accname, '', 'N', 1, 0 " & _
                    "from #accs " & _
                    "where accno collate database_default not in (select acc_no from comm_acc_master) " & _
                    "and accno <> '' "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = "insert into comm_acc_master(acc_no, acc_name, ae_no_s, ae_no_f, acc_name_s, acc_name_f, turnover_con_flag, inSec, inFut) " & _
                    "select accno, '', '', aeno, '', accname, 'N', 0, 1 " & _
                    "from #accf " & _
                    "where accno collate database_default not in (select acc_no from comm_acc_master) " & _
                    "and accno <> '' "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = "update comm_acc_master " & _
                    "set comm_acc_master.acc_name_s = a.accname, comm_acc_master.ae_no_s = a.aeno, comm_acc_master.inSec = 1 " & _
                    "from #accs a " & _
                    "where comm_acc_master.acc_no = a.accno collate database_default " & _
                    "and accno <> ' ' "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = "update comm_acc_master " & _
                    "set comm_acc_master.acc_name_f = a.accname, comm_acc_master.ae_no_f = a.aeno, comm_acc_master.inFut = 1 " & _
                    "from #accf a " & _
                    "where comm_acc_master.acc_no = a.accno collate database_default " & _
                    "and accno <> ' ' "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = " delete from draft_comm_acc_master "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = " insert into draft_comm_acc_master select * from comm_acc_master "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
    End Sub

    Protected Friend Sub lFncUpdateRateFromG2B(ByVal nyear As String, ByVal nmonth As String, _
    ByRef MyTrans As SqlTransaction, ByRef strSQL As String)

        strSQL = "delete from comm_afe_rate_s where txmonth = '" & nyear & nmonth & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
        strSQL = "insert into comm_afe_rate_s(txmonth, accno, aeno, fee_nature_name, fee_name, rate, rate_1, rate_2, " & _
                    "rate_3, rate_4, rate_5, rate_6, rate_7, rate_8, rate_9, upper_1, upper_2, upper_3, upper_4, upper_5, " & _
                    "upper_6, upper_7, upper_8, upper_9, min_f) " & _
                    "select '" & nyear & nmonth & "', accno, aeno, nature_name, fee_name, rate, rate_1, rate_2, rate_3, " & _
                    "rate_4, rate_5, rate_6, rate_7, rate_8, rate_9, upper_1, upper_2, upper_3, upper_4, upper_5, upper_6, " & _
                    "upper_7, upper_8, upper_9, min_f from #rates"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

    End Sub

    Protected Friend Sub lFncUpdateProductMasterF(ByVal nyear As String, ByVal nmonth As String, _
    ByRef MyTrans As SqlTransaction, ByRef strSQL As String)

        strSQL = "insert into futures_product_master(product_code, product_name, gross_net, position_limit, market, " & _
                    "email_alert, ptype, currency, month_alert) select a.product_code, a.product_name, a.gross_net, " & _
                    "a.position_limit, a.market, a.email_alert, a.ptype, a.currency, a.month_alert " & _
                    "from #product_master_f a " & _
                    "left join futures_product_master b on a.product_code = b.product_code collate database_default " & _
                    "where b.product_code is null"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = "insert into comm_product_group(product_group, product_code, txmonth) " & _
                    "select 'ALL', a.product_code, '" & nyear & nmonth & "' from futures_product_master a " & _
                    "left join comm_product_group b on a.product_code = b.product_code collate database_default " & _
                    "and b.product_group = 'ALL' and b.txmonth = '" & nyear & nmonth & "' " & _
                    "where b.product_code is null "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

    End Sub

    Protected Friend Sub lFncUpdateTradeFromG2B(ByVal nyear As String, ByVal nmonth As String, _
                                                ByVal smonth As String, ByRef MyTrans As SqlTransaction, ByRef strSQL As String)


        'insert sec trade detail
        strSQL = "delete from comm_trade_s where txmonth = '" & nyear & nmonth & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
        strSQL = "insert into comm_trade_s(txmonth, ae, acct, tdate, oid, stk, price, " & _
                  "qty, grossamt, commission, comm_rate, tradetype, lastupddate, lastupduser, rebate) " & _
                  "SELECT '" & nyear & nmonth & "', ae, acct, tdate, oid, stk, price, qty, " & _
                  "isnull(grossamt, 0), commission, comm_rate, tradetype, getdate(), '" & GStrloginID & "', rebate " & _
                  "FROM #trades where qty is not null  "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        strSQL = "insert into comm_trade_s(txmonth, ae, acct, tdate, oid, stk, price, " & _
               "qty, grossamt, commission, comm_rate, tradetype, lastupddate, lastupduser, rebate, currency_code_set) " & _
               " select  '" & nyear & nmonth & "', aeno as ae, accno as acct, a.tdate, cn_no as oid, " & _
               " stkno as stk, isnull(price, 0) as price, isnull(ttlqty, 0) as aty, isnull(grossamt, 0) as grossamt, " & _
                " commission as commission ," & _
               " comm_rate, tradetype, getdate(), '" & GStrloginID & "', rebate, currency_code_set " & _
               " from #trades_other a "

        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)


        'update sec trade ae, account and stock info
        strSQL = " update  dbo.comm_trade_s " & _
                " set aeno = left(ae, charindex(' ', ae)-1), " & _
                " aename = substring(ae, charindex(' ', ae), len(ae) -1), " & _
                " accno = left(acct, charindex(' ', acct)-1), " & _
                " accname= ltrim(substring(acct, charindex(' ', acct), len(acct) -1)), " & _
                " stkno = left(stk, charindex(' ', stk)-1), " & _
                " stkname = ltrim(substring(stk, charindex(' ', stk), len(stk) -1)) " & _
                " where txmonth = '" & nyear & nmonth & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        'strSQL = "update comm_trade_s " & _
        '            "set comm_trade_s.aeno = b.aeno, comm_trade_s.aename = b.ae_name, " & _
        '            "comm_trade_s.accno = b.accno, comm_trade_s.accname = b.name_1, " & _
        '            "comm_trade_s.stkno = b.stkno, comm_trade_s.stkname = b.s_code " & _
        '            "from  " & _
        '            "(select accno, name_1, stkno, s_code, aeno, ae_name, cn_no " & _
        '            "from #tradesinfo) as b " & _
        '            "where b.cn_no collate database_default = comm_trade_s.oid " & _
        '            "and txmonth = '" & nyear & nmonth & "'"
        'GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        'insert fut trade summary table
        strSQL = "delete from comm_trade_f where txmonth = '" & nyear & nmonth & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
        strSQL = "insert into comm_trade_f(txmonth, aeno, aename, accno, accname1, accname2, commod, mth, " & _
                  "call_put, strike, s_price_str, day_dd, night_dd, tg_dd, commission_dd, exchange_fee_dd, " & _
                  "ae_rebate_dd, commission_mm, exchange_fee_mm, ae_rebate_mm, day_mm, night_mm, tg_mm,  " & _
                  "marketname, ccy, lastupddate, lastupduser, day_commission, night_commission) " & _
                  "SELECT '" & nyear & nmonth & "', *, getdate(), '" & GStrloginID & "', 0, 0 " & _
                  "FROM #tradef "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        'insert day commission and night commission
        strSQL = "delete from comm_trade_d_f"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
        strSQL = "insert into comm_trade_d_f(cmid, aeid, aeno, ae_name, oid, group_o, acct, market, ccy, comdy_code, " & _
                    "trade_month, put_call, s_price, s_price_str, type, tdate, qty_day, qty_night, comm, exchange_fee, " & _
                    "rebate, bhid, tradetype) " & _
                    "select cmid, aeid, aeno, ae_name, oid, group_o, acct, market, ccy, comdy_code, [month] as txmonth, " & _
                    "put_call, s_price, s_price_str, type, tdate, qty_day, qty_night, comm, exchange_fee, rebate, bhid, " & _
                    "tradetype from #comm"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        'update day commission and night commission to summary table
        'strSQL = "select aeno, acct, comdy_code, [month] as txmonth, put_call, s_price_str, " & _
        '            "sum(qty_day) as qty_day, sum(qty_night) as qty_night, " & _
        '            "sum(case when qty_day>0 then case when qty_night>0 then comm/2 else comm end else 0 end) as day_comm, " & _
        '            "sum(case when qty_night>0 then case when qty_day>0 then comm/2 else comm end else 0 end) as night_comm " & _
        '            "into #day_night_comm from #comm " & _
        '            "group by aeno, acct, comdy_code, [month], put_call, s_price_str order by aeno, acct"
        'strSQL = "select aeno, acct, comdy_code, trade_month as txmonth, put_call, s_price_str, " & _
        '            "sum(qty_day) as qty_day, sum(qty_night) as qty_night, " & _
        '            "sum(case when qty_day>0 then case when qty_night>0 then comm/2 else comm end else 0 end) as day_comm, " & _
        '            "sum(case when qty_night>0 then case when qty_day>0 then comm/2 else comm end else 0 end) as night_comm " & _
        '            "into #day_night_comm from comm_trade_d_f " & _
        '            "group by aeno, acct, comdy_code, trade_month, put_call, s_price_str order by aeno, acct"
        'GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
        'strSQL = "update comm_trade_f set comm_trade_f.day_commission = #day_night_comm.day_comm, " & _
        '            "comm_trade_f.night_commission = #day_night_comm.night_comm from #day_night_comm " & _
        '            "where comm_trade_f.txmonth= '" & nyear & nmonth & "' " & _
        '            "and rtrim(#day_night_comm.aeno) = comm_trade_f.aeno collate database_default " & _
        '            "and substring(rtrim(#day_night_comm.acct),1,8) = comm_trade_f.accno collate database_default " & _
        '            "and #day_night_comm.comdy_code = comm_trade_f.commod collate database_default " & _
        '            "and #day_night_comm.txmonth = comm_trade_f.mth collate database_default " & _
        '            "and #day_night_comm.put_call = comm_trade_f.call_put collate database_default " & _
        '            "and #day_night_comm.s_price_str = comm_trade_f.s_price_str collate database_default " & _
        '            "and #day_night_comm.qty_day = comm_trade_f.day_mm and #day_night_comm.qty_night = comm_trade_f.night_mm"
        'GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
        strSQL = "select aeno, acct, comdy_code, trade_month as txmonth, put_call, s_price_str, " & _
                    "sum(case when qty_night>0 then case when qty_day>0 then comm * qty_night /(qty_day+qty_night) " & _
                    "else comm end else 0 end) as night_comm " & _
                    "into #day_night_comm " & _
                    "from comm_trade_d_f " & _
                    "group by aeno, acct, comdy_code, trade_month, put_call, s_price_str order by aeno, acct"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
        strSQL = "update comm_trade_f set comm_trade_f.night_commission = #day_night_comm.night_comm " & _
                    "from #day_night_comm " & _
                    "where comm_trade_f.txmonth= '" & nyear & nmonth & "' " & _
                    "and rtrim(#day_night_comm.aeno) = comm_trade_f.aeno collate database_default " & _
                    "and substring(rtrim(#day_night_comm.acct),1,8) = comm_trade_f.accno collate database_default " & _
                    "and #day_night_comm.comdy_code = comm_trade_f.commod collate database_default " & _
                    "and #day_night_comm.txmonth = comm_trade_f.mth collate database_default " & _
                    "and #day_night_comm.put_call = comm_trade_f.call_put collate database_default " & _
                    "and #day_night_comm.s_price_str = comm_trade_f.s_price_str collate database_default "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
        strSQL = "update comm_trade_f set comm_trade_f.day_commission = commission_mm - night_commission " & _
                    "where comm_trade_f.txmonth= '" & nyear & nmonth & "' "
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

        'update internet trade commission
        strSQL = "select '" & nyear & nmonth & "' as txmonth, aeno, acct, comdy_code, trade_month, put_call, " & _
                    "s_price_str,  sum(qty_day) as qty_day, sum(qty_night) as qty_night, " & _
                    "sum(case when qty_day > 0 then qty_day / (qty_day + qty_night) * comm else 0 end) as comm_day, " & _
                    "sum(case when qty_night > 0 then qty_night / (qty_day + qty_night) * comm else 0 end) as comm_night, " & _
                    "sum(comm) as comm, sum(exchange_fee) as exchange_fee, sum(rebate) as rebate, tradetype " & _
                    "into #comm_internet " & _
                    "from comm_trade_d_f  " & _
                    "where tradetype = '3' " & _
                    "group by aeno, acct, comdy_code, trade_month, put_call, s_price_str, tradetype " & _
                    "order by aeno, acct"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)
        strSQL = "update comm_trade_f " & _
                    "set comm_trade_f.i_day_mm = #comm_internet.qty_day, comm_trade_f.i_night_mm = #comm_internet.qty_night, " & _
                    "comm_trade_f.i_day_commission = #comm_internet.comm_day, " & _
                    "comm_trade_f.i_night_commission = #comm_internet.comm_night," & _
                    "comm_trade_f.tradetype = #comm_internet.tradetype " & _
                    "from #comm_internet " & _
                    "where comm_trade_f.txmonth = #comm_internet.txmonth collate database_default " & _
                    "and comm_trade_f.aeno = #comm_internet.aeno collate database_default " & _
                    "and rtrim(comm_trade_f.accno) =  substring(#comm_internet.acct, 1,8) collate database_default " & _
                    "and comm_trade_f.commod = #comm_internet.comdy_code collate database_default " & _
                    "and comm_trade_f.mth = #comm_internet.trade_month collate database_default " & _
                    "and comm_trade_f.call_put = #comm_internet.put_call collate database_default " & _
                    "and comm_trade_f.s_price_str = #comm_internet.s_price_str collate database_default " & _
                    "and comm_trade_f.txmonth = '" & nyear & nmonth & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, strSQL, 0)

    End Sub

    Protected Friend Sub lFncClearTempTable(ByRef strSQL As String)

        strSQL = "drop table #aes "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #accs "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #trades "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #trades_other "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #tradesinfo "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)
        strSQL = "drop table #rates "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #aef "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #accf "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #product_master_f"
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #tradef "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #comm "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #day_night_comm "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

        strSQL = "drop table #comm_internet "
        GFncRunSQL(GSCnSqlConn, strSQL, 0)

    End Sub

End Class
