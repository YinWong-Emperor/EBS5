Imports System.Data.SqlClient

Public Class ClsITrade

    Protected Friend Function lFncGetITradeList() As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "SELECT client_code FROM stitrade"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "clientList")

        Return lds
    End Function

    Protected Friend Function lFncGetLastTradeDate() As DataSet
        Dim lstrSQL As String

        lstrSQL = "select MAX(tdate) as lasttrade from " & _
                    "(SELECT tdate FROM " & GStrG2BSDB & ".dbo.histcltradeh UNION all " & _
                    "select tdate FROM " & GStrG2BSDB & ".dbo.daycltradehd) hd "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, "lastTradeDate")
    End Function

    Protected Friend Function lFncSaveClientList(ByVal list As ListBox) As Boolean
        Dim lstrSQL As String
        Dim MyTrans As SqlTransaction = Nothing
        Dim i As Integer

        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            lstrSQL = "Delete FROM stitrade "
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

            For i = 0 To list.Items.Count - 1
                lstrSQL = ("Insert into stitrade(client_code, seq_no) values ('" & Trim(list.Items(i)) & "', " & i + 1 & ")")

                GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            Next i

            MyTrans.Commit()
            MyTrans = Nothing

            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        Return False
    End Function
    Protected Friend Function lFncExportEquilty(ByVal lastDateFrom As Date, ByVal lastDateTo As Date, _
                                                ByVal currentDateFrom As Date, ByVal currentDateTo As Date, _
                                                ByVal strExFile As String, ByVal strExFile2 As String) As Boolean

        Dim lstrSQL As String = ""
        Dim ldtsTurnover As DataSet = Nothing
        Dim ldtsEquilty As DataSet = Nothing

        Try

            'lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(iTurnover) as iTurnover, " & _
            '            "sum(TTurnover) as TTurnover into #curitrade " & _
            '            "from (select aid, accno, case when tradetype = 4 then grossamt else 0 end as iTurnover, " & _
            '            "grossamt as TTurnover from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
            '            "where tdate  >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '            Format(currentDateTo, "yyyyMMdd") & "' union all select aid, accno, " & _
            '            "case when tradetype = 4 then grossamt else 0 end as iTurnover, grossamt as TTurnover " & _
            '            "from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
            '            "where tdate >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '            Format(currentDateTo, "yyyyMMdd") & "' ) trade, " & _
            '            GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am, stitrade " & _
            '            "where trade.aid = cs.aid and trade.accno = stitrade.client_code collate database_default " & _
            '            "and cs.aeid = am.aeid group by accno, aeno order by accno"
            'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

            'lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(iTurnover) as iTurnover, " & _
            '            "sum(TTurnover) as TTurnover into #curitradelastm " & _
            '            "from (select aid, accno, case when tradetype = 4 then grossamt else 0 end as iTurnover, " & _
            '            "grossamt as TTurnover from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
            '            "where tdate  >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '            Format(lastDateTo, "yyyyMMdd") & "' union all select aid, accno, " & _
            '            "case when tradetype = 4 then grossamt else 0 end as iTurnover, grossamt as TTurnover " & _
            '            "from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
            '            "where tdate >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '            Format(lastDateTo, "yyyyMMdd") & "') trade, " & _
            '            GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am, stitrade " & _
            '            "where trade.aid = cs.aid and trade.accno = stitrade.client_code collate database_default " & _
            '            "and cs.aeid = am.aeid group by accno, aeno order by accno"
            'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)


            'lstrSQL = "SELECT isnull(#curitradelastm.client_code, #curitrade.client_code) as client_code, " & _
            '          "isnull(#curitradelastm.iTurnover, 0) as last_month_iturnover, " & _
            '          "isnull(#curitrade.iTurnover, 0) as this_month_iturnover, " & _
            '          "isnull(#curitradelastm.TTurnover, 0) as last_month_tturnover, " & _
            '          "isnull(#curitrade.TTurnover, 0) as this_month_tturnover " & _
            '          "FROM #curitradelastm FULL JOIN #curitrade ON #curitradelastm.client_code = #curitrade.client_code "
            'ldtsTurnover = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            lsubCreateClientMaster()

            lstrSQL = "select cm.client_code, client_name, ledger_bal, market_value, ledger_bal + market_value as equity_value " & _
                      "from  #er_client_master cm, stitrade " & _
                      "where cm.client_code = stitrade.client_code collate database_default"
            ldtsEquilty = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)


            lstrSQL = "drop table #er_client_master "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            'lstrSQL = "drop table #curitradelastm "
            'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            'lstrSQL = "drop table #curitrade "
            'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        'If (GExportCSV(GStrExptDir, strExFile, ldtsTurnover, " client_code, last_month_iturnover, this_month_iturnover, last_month_total_turnover, this_month_total_turnover ")) Then

        If (GExportCSV(GStrExptDir, strExFile2, ldtsEquilty, " client_code, client_name, ledger_bal, market_value, equity_value ")) Then
            Return True
        End If
        'End If

        Return False
    End Function
    Protected Friend Function lFncExportTurnover(ByVal lastDateFrom As Date, ByVal lastDateTo As Date, _
                                               ByVal currentDateFrom As Date, ByVal currentDateTo As Date, _
                                               ByVal strExFile As String, ByVal strExFile2 As String) As Boolean

        Dim lstrSQL As String = ""
        Dim ldtsTurnover As DataSet = Nothing
        Dim ldtsEquilty As DataSet = Nothing

        Try
            'lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(grossamt) as Turnover into #curitrade " & _
            '          "from (select aid, accno, grossamt from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
            '          "where tdate  >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '          Format(currentDateTo, "yyyyMMdd") & "' and tradetype = 4 union all " & _
            '          "select aid, accno, grossamt from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
            '          "where tdate  >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '          Format(currentDateTo, "yyyyMMdd") & "' and tradetype = 4) trade, " & _
            '          GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am, stitrade " & _
            '          "where trade.aid = cs.aid and trade.accno = stitrade.client_code collate database_default " & _
            '          "and cs.aeid = am.aeid group by accno, aeno order by accno"
            lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(iTurnover) as iTurnover, " & _
                        "sum(TTurnover) as TTurnover into #curitrade " & _
                        "from (select aid, accno, case when tradetype = 4 then grossamt else 0 end as iTurnover, " & _
                        "grossamt as TTurnover from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
                        "where tdate  >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
                        Format(currentDateTo, "yyyyMMdd") & "' union all select aid, accno, " & _
                        "case when tradetype = 4 then grossamt else 0 end as iTurnover, grossamt as TTurnover " & _
                        "from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
                        "where tdate >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
                        Format(currentDateTo, "yyyyMMdd") & "' ) trade, " & _
                        GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am, stitrade " & _
                        "where trade.aid = cs.aid and trade.accno = stitrade.client_code collate database_default " & _
                        "and cs.aeid = am.aeid group by accno, aeno order by accno"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            'lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(grossamt) as Turnover into #curitradelastm " & _
            '          "from (select aid, accno, grossamt from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
            '          "where tdate  >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '          Format(lastDateTo, "yyyyMMdd") & "' and tradetype = 4 union all " & _
            '          "select aid, accno, grossamt from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
            '          "where tdate  >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '          Format(lastDateTo, "yyyyMMdd") & "' and tradetype = 4) trade, " & _
            '          GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am, stitrade " & _
            '          "where trade.aid = cs.aid and trade.accno = stitrade.client_code collate database_default " & _
            '          "and cs.aeid = am.aeid group by accno, aeno order by accno"
            lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(iTurnover) as iTurnover, " & _
                        "sum(TTurnover) as TTurnover into #curitradelastm " & _
                        "from (select aid, accno, case when tradetype = 4 then grossamt else 0 end as iTurnover, " & _
                        "grossamt as TTurnover from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
                        "where tdate  >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
                        Format(lastDateTo, "yyyyMMdd") & "' union all select aid, accno, " & _
                        "case when tradetype = 4 then grossamt else 0 end as iTurnover, grossamt as TTurnover " & _
                        "from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
                        "where tdate >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
                        Format(lastDateTo, "yyyyMMdd") & "') trade, " & _
                        GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am, stitrade " & _
                        "where trade.aid = cs.aid and trade.accno = stitrade.client_code collate database_default " & _
                        "and cs.aeid = am.aeid group by accno, aeno order by accno"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

            'lstrSQL = "SELECT isnull(#curitradelastm.client_code, #curitrade.client_code) as client_code, " & _
            '          "isnull(#curitradelastm.turnover, 0) as last_month_iturnover, " & _
            '          "isnull(#curitrade.turnover, 0) as this_month_iturnover " & _
            '          "FROM #curitradelastm FULL JOIN #curitrade ON #curitradelastm.client_code = #curitrade.client_code "
            lstrSQL = "SELECT isnull(#curitradelastm.client_code, #curitrade.client_code) as client_code, " & _
                      "isnull(#curitradelastm.iTurnover, 0) as last_month_iturnover, " & _
                      "isnull(#curitrade.iTurnover, 0) as this_month_iturnover, " & _
                      "isnull(#curitradelastm.TTurnover, 0) as last_month_tturnover, " & _
                      "isnull(#curitrade.TTurnover, 0) as this_month_tturnover " & _
                      "FROM #curitradelastm FULL JOIN #curitrade ON #curitradelastm.client_code = #curitrade.client_code "
            ldtsTurnover = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            lsubCreateClientMaster()

            lstrSQL = "select cm.client_code, client_name, ledger_bal, market_value, ledger_bal + market_value as equity_value " & _
                      "from  #er_client_master cm, stitrade " & _
                      "where cm.client_code = stitrade.client_code collate database_default"
            ldtsEquilty = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            'lstrSQL = "select cm.client_code, client_name, ledger_bal, market_value, ledger_bal + market_value as equity_value " & _
            '          "from " & GStrG2BSDB & ".dbo.view_er_client_master cm, stitrade " & _
            '          "where cm.client_code = stitrade.client_code collate database_default"
            'ldtsEquilty = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            lstrSQL = "drop table #er_client_master "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "drop table #curitradelastm "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "drop table #curitrade "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        If (GExportCSV(GStrExptDir, strExFile, ldtsTurnover, " client_code, last_month_iturnover, this_month_iturnover, last_month_total_turnover, this_month_total_turnover ")) Then
            'If (GExportCSV(GStrExptDir, strExFile, ldtsTurnover, " client_code, last_month_iturnover, this_month_iturnover ")) Then
            If (GExportCSV(GStrExptDir, strExFile2, ldtsEquilty, " client_code, client_name, ledger_bal, market_value, equity_value ")) Then
                Return True
            End If
        End If

        Return False
    End Function

    Protected Friend Function lFncExportClient(ByVal strExFile As String) As Boolean
        Dim ldtsClient As DataSet = lFncGetITradeList()
        If (ldtsClient.Tables(0).Rows.Count > 0) Then
            If (GExportCSV(GStrExptDir, strExFile, ldtsClient, " client_code ")) Then
                Return True
            End If
        End If

        Return False
    End Function

    Private Sub lsubCreateClientMaster()

        Dim lstrSQL As String

        lstrSQL = "select * into #er_client_master_bals" & _
               " from " & GStrG2BSDB & ".dbo.view_er_client_master_bals"
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        lstrSQL = "select * into #er_client_master_mkt_mrg_value" & _
                  " from " & GStrG2BSDB & ".dbo.view_er_client_master_mkt_mrg_value"
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        lstrSQL = "select * " & _
                    " into  #er_client_master" & _
                    " from (" & _
                    " SELECT distinct cmid,client_code,ae_code,client_name,client_type" & _
                          " ,locked,suspend_date,close_date,cast(0 as decimal(18,2)) as credit_lmt" & _
                          " ,cast(0 as decimal(18,2)) as ledger_bal,cast(0 as decimal(18,2)) as interest_accrued,cast(0 as decimal(18,2)) as market_value" & _
                          " ,cast(0 as decimal(18,2)) as margin_value,cast(0 as decimal(18,2)) as cal_margin_value,cast(0 as decimal(18,2)) as t1_trade_amount" & _
                          " ,cast(0 as decimal(18,2)) as t2_trade_amount,cast(0 as decimal(18,2)) as t2_margin_value,cast(0 as decimal(18,2)) as cal_t2_margin_value" & _
                          " ,cast(0 as decimal(18,2)) as avail_bal FROM #er_client_master_mkt_mrg_value" & _
                    " union SELECT distinct cmid,client_code,ae_code,client_name,client_type" & _
                          " ,locked,suspend_date,close_date,cast(0 as decimal(18,2)) as credit_lmt" & _
                          " ,cast(0 as decimal(18,2)) as ledger_bal,cast(0 as decimal(18,2)) as interest_accrued,cast(0 as decimal(18,2)) as market_value" & _
                          " ,cast(0 as decimal(18,2)) as margin_value,cast(0 as decimal(18,2)) as cal_margin_value,cast(0 as decimal(18,2)) as t1_trade_amount" & _
                          " ,cast(0 as decimal(18,2)) as t2_trade_amount,cast(0 as decimal(18,2)) as t2_margin_value,cast(0 as decimal(18,2)) as cal_t2_margin_value" & _
                          " ,cast(0 as decimal(18,2)) as avail_bal FROM #er_client_master_bals) a"
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        lstrSQL = "update #er_client_master set" & _
                        " #er_client_master.market_value = a.market_value," & _
                        " #er_client_master.margin_value = a.margin_value," & _
                        " #er_client_master.cal_margin_value = a.cal_margin_value ," & _
                        " #er_client_master.t2_margin_value = a.t2_margin_value ," & _
                        " #er_client_master.cal_t2_margin_value = a.cal_t2_margin_value " & _
                        " from ( select  client_code, sum(market_value * exchange_rate) as market_value, " & _
                        " sum(margin_value * exchange_rate) as margin_value, " & _
                        " sum(cal_margin_value * exchange_rate) as cal_margin_value, " & _
                        " sum(t2_margin_value * exchange_rate) as t2_margin_value, " & _
                        " sum(cal_t2_margin_value * exchange_rate) as cal_t2_margin_value " & _
                        " from #er_client_master_mkt_mrg_value group by client_code ) a" & _
                        " where #er_client_master.client_code = a.client_code "
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)



        lstrSQL = "update #er_client_master set" & _
                          " #er_client_master.ledger_bal = a.ledger_bal ," & _
                          " #er_client_master.credit_lmt = a.credit_lmt ," & _
                          " #er_client_master.interest_accrued = a.interest_accrued ," & _
                          " #er_client_master.t1_trade_amount = a.t1_trade_amount," & _
                          " #er_client_master.t2_trade_amount = a.t2_trade_amount," & _
                          " #er_client_master.avail_bal = a.avail_bal " & _
                          " from (select client_code, sum(avail_bal * exchange_rate) as avail_bal, " & _
                          " sum (ledger_bal * exchange_rate) as ledger_bal," & _
                          " sum (interest_accrued * exchange_rate) as interest_accrued," & _
                          " sum (credit_lmt * exchange_rate) as credit_lmt," & _
                           " sum (t1_trade_amount * exchange_rate) as t1_trade_amount," & _
                          " sum (t2_trade_amount * exchange_rate) as t2_trade_amount" & _
                          " from #er_client_master_bals group by client_code) a" & _
                          " where #er_client_master.client_code = a.client_code"
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        lstrSQL = "drop table  #er_client_master_mkt_mrg_value "
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
        lstrSQL = "drop table #er_client_master_bals "
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

    End Sub
    Protected Friend Function lFncExportEquityAll(ByVal lastDateFrom As Date, ByVal lastDateTo As Date, _
                                            ByVal currentDateFrom As Date, ByVal currentDateTo As Date, _
                                            ByVal strExFile As String, ByVal strExFile2 As String) As Boolean
        Dim lstrSQL As String = ""
        Dim ldtsTurnover As DataSet = Nothing
        Dim ldtsEquilty As DataSet = Nothing

        Try
            'lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(iTurnover) as iTurnover, " & _
            '            "sum(TTurnover) as TTurnover into #curitrade " & _
            '            "from (select aid, accno, case when tradetype = 4 then grossamt else 0 end as iTurnover, " & _
            '            "grossamt as TTurnover from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
            '            "where tdate  >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '            Format(currentDateTo, "yyyyMMdd") & "' union all select aid, accno, " & _
            '            "case when tradetype = 4 then grossamt else 0 end as iTurnover, grossamt as TTurnover " & _
            '            "from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
            '            "where tdate >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '            Format(currentDateTo, "yyyyMMdd") & "' ) trade, " & _
            '            GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am " & _
            '            "where trade.aid = cs.aid and cs.aeid = am.aeid group by accno, aeno order by accno"
            'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

            'lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(iTurnover) as iTurnover, " & _
            '            "sum(TTurnover) as TTurnover into #curitradelastm " & _
            '            "from (select aid, accno, case when tradetype = 4 then grossamt else 0 end as iTurnover, " & _
            '            "grossamt as TTurnover from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
            '            "where tdate  >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '            Format(lastDateTo, "yyyyMMdd") & "' union all select aid, accno, " & _
            '            "case when tradetype = 4 then grossamt else 0 end as iTurnover, grossamt as TTurnover " & _
            '            "from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
            '            "where tdate >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
            '            Format(lastDateTo, "yyyyMMdd") & "') trade, " & _
            '            GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am " & _
            '            "where trade.aid = cs.aid and cs.aeid = am.aeid group by accno, aeno order by accno"
            'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

            'lstrSQL = "SELECT isnull(#curitradelastm.client_code, #curitrade.client_code) as client_code, " & _
            '          "isnull(#curitradelastm.iTurnover, 0) as last_month_iturnover, " & _
            '          "isnull(#curitrade.iTurnover, 0) as this_month_iturnover, " & _
            '          "isnull(#curitradelastm.TTurnover, 0) as last_month_tturnover, " & _
            '          "isnull(#curitrade.TTurnover, 0) as this_month_tturnover " & _
            '          "FROM #curitradelastm FULL JOIN #curitrade ON #curitradelastm.client_code = #curitrade.client_code "
            'ldtsTurnover = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            lsubCreateClientMaster()

            lstrSQL = "select cm.client_code, cm.client_name, cm.ledger_bal, cm.market_value, cm.ledger_bal + cm.market_value as equity_value " & _
                     "from  #er_client_master cm "
            ldtsEquilty = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            lstrSQL = "drop table #er_client_master "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            'lstrSQL = "drop table #curitradelastm "
            'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            'lstrSQL = "drop table #curitrade "
            'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        'If (GExportCSV(GStrExptDir, strExFile, ldtsTurnover, " client_code, last_month_iturnover, this_month_iturnover, last_month_total_turnover, this_month_total_turnover ")) Then
        If (GExportCSV(GStrExptDir, strExFile2, ldtsEquilty, " client_code, client_name, ledger_bal, market_value, equity_value ")) Then
            Return True
        End If
        'End If

        Return False

    End Function

    Protected Friend Function lFncExportTurnoverAll(ByVal lastDateFrom As Date, ByVal lastDateTo As Date, _
                                               ByVal currentDateFrom As Date, ByVal currentDateTo As Date, _
                                               ByVal strExFile As String, ByVal strExFile2 As String) As Boolean
        Dim lstrSQL As String = ""
        Dim ldtsTurnover As DataSet = Nothing
        Dim ldtsEquilty As DataSet = Nothing

        Try
            lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(iTurnover) as iTurnover, " & _
                        "sum(TTurnover) as TTurnover into #curitrade " & _
                        "from (select aid, accno, case when tradetype = 4 then grossamt else 0 end as iTurnover, " & _
                        "grossamt as TTurnover from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
                        "where tdate  >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
                        Format(currentDateTo, "yyyyMMdd") & "' union all select aid, accno, " & _
                        "case when tradetype = 4 then grossamt else 0 end as iTurnover, grossamt as TTurnover " & _
                        "from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
                        "where tdate >= '" & Format(currentDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
                        Format(currentDateTo, "yyyyMMdd") & "' ) trade, " & _
                        GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am " & _
                        "where trade.aid = cs.aid and cs.aeid = am.aeid group by accno, aeno order by accno"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

            lstrSQL = "select accno as Client_Code, aeno as AE_Code, sum(iTurnover) as iTurnover, " & _
                        "sum(TTurnover) as TTurnover into #curitradelastm " & _
                        "from (select aid, accno, case when tradetype = 4 then grossamt else 0 end as iTurnover, " & _
                        "grossamt as TTurnover from " & GStrG2BSDB & ".dbo.view_ctrade_namt_order " & _
                        "where tdate  >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
                        Format(lastDateTo, "yyyyMMdd") & "' union all select aid, accno, " & _
                        "case when tradetype = 4 then grossamt else 0 end as iTurnover, grossamt as TTurnover " & _
                        "from " & GStrG2BSDB & ".dbo.view_hs_ctrade_namt_order " & _
                        "where tdate >= '" & Format(lastDateFrom, "yyyyMMdd") & "' and tdate <= '" & _
                        Format(lastDateTo, "yyyyMMdd") & "') trade, " & _
                        GStrG2BSDB & ".dbo.client_master_s cs, " & GStrG2BSDB & ".dbo.ae_master am " & _
                        "where trade.aid = cs.aid and cs.aeid = am.aeid group by accno, aeno order by accno"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

            lstrSQL = "SELECT isnull(#curitradelastm.client_code, #curitrade.client_code) as client_code, " & _
                      "isnull(#curitradelastm.iTurnover, 0) as last_month_iturnover, " & _
                      "isnull(#curitrade.iTurnover, 0) as this_month_iturnover, " & _
                      "isnull(#curitradelastm.TTurnover, 0) as last_month_tturnover, " & _
                      "isnull(#curitrade.TTurnover, 0) as this_month_tturnover " & _
                      "FROM #curitradelastm FULL JOIN #curitrade ON #curitradelastm.client_code = #curitrade.client_code "
            ldtsTurnover = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            lsubCreateClientMaster()

            lstrSQL = "select cm.client_code, cm.client_name, cm.ledger_bal, cm.market_value, cm.ledger_bal + cm.market_value as equity_value " & _
                     "from  #er_client_master cm "
            ldtsEquilty = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            lstrSQL = "drop table #er_client_master "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "drop table #curitradelastm "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "drop table #curitrade "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        If (GExportCSV(GStrExptDir, strExFile, ldtsTurnover, " client_code, last_month_iturnover, this_month_iturnover, last_month_total_turnover, this_month_total_turnover ")) Then
            If (GExportCSV(GStrExptDir, strExFile2, ldtsEquilty, " client_code, client_name, ledger_bal, market_value, equity_value ")) Then
                Return True
            End If
        End If

        Return False

    End Function

End Class
