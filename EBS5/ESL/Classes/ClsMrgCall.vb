Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsMrgCall
    Dim clsRpt As New ClsReports
    Protected Friend Function lFncGetRunner() As DataSet
        Dim lstrSQL As String

        lstrSQL = "Select * from staemaster order by run_code "

        Return GFncRtnDS(GSCnLiqConn, lstrSQL)

    End Function

    Protected Friend Function lFncPrepareMC(ByVal lstrQuery As String, ByVal lstrSort As String, ByVal MC As String) As DataTable
        Dim ldtsTemp As DataSet
        Dim lstrCrit As String = ""
        Dim lstrSQL As String = ""

        'lstrSQL = "SELECT  *, liq.liq_day is null then 0 else liq.liq_day end liq_day, " & _
        '        " cast(0 as decimal(18,2)) as top1_market_value, '' as top1_stock_code, " & _
        '        " cast(0 as decimal(18,2)) as top2_market_value, '' as top2_stock_code, " & _
        '        " cast(0 as decimal(18,2)) as top3_market_value, '' as top3_stock_code, " & _
        '        " run_name, cast(0 as decimal(18,2)) as margin_call_amount,  " & _
        '        " '' as Due_Undue, '' as Risk " & _
        '        " FROM #stcltmaster mst inner JOIN #clt_tmp liq ON  mst.clt_code = liq.clt_code " & _
        '        " and liq.liq_day > 0 " & _
        '        " left outer join staemaster ae on ae.run_code = mst.run_code WHERE 1=1 "

        'lstrSQL = "SELECT  *, mst.os_day as liq_day, " & _
        '        " cast(0 as decimal(18,2)) as top1_market_value, '' as top1_stock_code, " & _
        '        " cast(0 as decimal(18,2)) as top2_market_value, '' as top2_stock_code, " & _
        '        " cast(0 as decimal(18,2)) as top3_market_value, '' as top3_stock_code, " & _
        '        " run_name, cast(0 as decimal(18,2)) as margin_call_amount,  " & _
        '        " '' as Due_Undue, '' as Risk " & _
        '        " FROM #stcltmaster_mrg mst inner JOIN #clt_tmp_mrg liq ON  mst.clt_code = liq.clt_code " & _
        '        " left outer join staemaster ae on ae.run_code = mst.run_code WHERE 1=1 "
        'lstrSQL += lstrQuery & " order by " & lstrSort

        lstrSQL = "SELECT mst.*, mst.os_day as liq_day, " & _
                " cast(0 as decimal(18,2)) as top1_market_value, '' as top1_stock_code, " & _
                " cast(0 as decimal(18,2)) as top2_market_value, '' as top2_stock_code, " & _
                " cast(0 as decimal(18,2)) as top3_market_value, '' as top3_stock_code, " & _
                " run_name, cast(0 as decimal(18,2)) as margin_call_amount,  " & _
                " '' as Due_Undue, '' as Risk " & _
                " FROM #stcltmaster_mrg mst inner JOIN #clt_tmp_mrg liq ON  mst.clt_code = liq.clt_code " & _
                " left outer join staemaster ae on ae.run_code = mst.run_code WHERE 1=1 "
        lstrSQL += lstrQuery & " order by " & lstrSort


        ldtsTemp = GFncRtnDS(GSCnLiqConn, lstrSQL)

        lstrSQL = " select * from STPortfolio " & _
                " where clt_code in (select mst.clt_code from #stcltmaster_mrg mst " & _
                " inner JOIN  #clt_tmp_mrg liq ON  mst.clt_code = liq.clt_code " & _
                lstrQuery & ")  "
        Dim ldtTop As DataTable = GFncRtnDS(GSCnLiqConn, lstrSQL).Tables(0)
        For Each ldtwTemp As DataRow In ldtsTemp.Tables(0).Rows
            ldtwTemp.Item("top1_stock_code") = ""
            ldtwTemp.Item("top2_stock_code") = ""
            ldtwTemp.Item("top3_stock_code") = ""
            ldtwTemp.Item("top1_market_value") = 0
            ldtwTemp.Item("top2_market_value") = 0
            ldtwTemp.Item("top3_market_value") = 0

            Dim tmp_bal As Decimal
            If (ldtwTemp.Item("mc_dr_bal") - ldtwTemp.Item("cr_limit") < 0) Then
                tmp_bal = 0
            Else
                tmp_bal = ldtwTemp.Item("mc_dr_bal") - ldtwTemp.Item("cr_limit")
            End If

            If (ldtwTemp.Item("cr_limit") > 1) Then
                If (ldtwTemp.Item("mc_due") > tmp_bal) Then
                    ldtwTemp.Item("margin_call_amount") = ldtwTemp.Item("mc_due")
                Else
                    ldtwTemp.Item("margin_call_amount") = tmp_bal
                End If
            Else
                If ldtwTemp.Item("MC_T2") < 0 Then
                    ldtwTemp.Item("margin_call_amount") = ldtwTemp.Item("mc_due") + ldtwTemp.Item("MC_T2")
                Else
                    ldtwTemp.Item("margin_call_amount") = ldtwTemp.Item("mc_due")
                End If
            End If

            Dim ldtaTop As DataRow()
            ldtaTop = ldtTop.Select(" clt_code = '" & ldtwTemp.Item("clt_code") & "'", " net_market_value desc ")
            For lintCnt As Integer = 0 To ldtaTop.Length - 1
                Select Case lintCnt
                    Case 0
                        ldtwTemp.Item("top1_stock_code") = ldtaTop(0).Item("stk_code")
                        ldtwTemp.Item("top1_market_value") = GFncNoNullValue(ldtaTop(0).Item("net_market_value"))
                    Case 1
                        ldtwTemp.Item("top2_stock_code") = ldtaTop(1).Item("stk_code")
                        ldtwTemp.Item("top2_market_value") = GFncNoNullValue(ldtaTop(1).Item("net_market_value"))
                    Case 2
                        ldtwTemp.Item("top3_stock_code") = ldtaTop(2).Item("stk_code")
                        ldtwTemp.Item("top3_market_value") = GFncNoNullValue(ldtaTop(2).Item("net_market_value"))
                    Case Else
                        Exit For
                End Select
            Next
            ldtwTemp.Item("Due_Undue") = lFncDue(ldtwTemp.Item("mc_due"), ldtwTemp.Item("mc_t2"))
            ldtwTemp.Item("Risk") = lFncRickFactor(ldtwTemp.Item("MC_ACT_RATIO"), ldtwTemp.Item("Due_Undue"), ldtwTemp.Item("dr_bal"))
        Next

        Dim ldt As DataTable = ldtsTemp.Tables(0).Copy
        ldt.Clear()
        Dim Sort As String
        If MC.Length > 0 Then
            Sort = MC
        Else
            Sort = "1=1"
        End If
        Dim ldtaDD As DataRow() = ldtsTemp.Tables(0).Select(Sort, lstrSort)
        For lintCnt As Integer = 0 To ldtaDD.Length - 1
            If (ldtaDD(lintCnt).Item("margin_call_amount") >= 0) Then
                ldt.ImportRow(ldtaDD(lintCnt))
            End If
        Next

        Return ldt

    End Function

    Protected Friend Function lFncPrepareMC2(ByVal lstrQuery As String, ByVal lstrSort As String, ByVal MC As String) As DataTable
        Dim ldtsTemp As DataSet
        Dim lstrCrit As String = ""
        Dim lstrSQL As String = ""

        'lstrSQL = "SELECT  *, liq.liq_day is null then 0 else liq.liq_day end liq_day, " & _
        '        " cast(0 as decimal(18,2)) as top1_market_value, '' as top1_stock_code, " & _
        '        " cast(0 as decimal(18,2)) as top2_market_value, '' as top2_stock_code, " & _
        '        " cast(0 as decimal(18,2)) as top3_market_value, '' as top3_stock_code, " & _
        '        " run_name, cast(0 as decimal(18,2)) as margin_call_amount,  " & _
        '        " '' as Due_Undue, '' as Risk " & _
        '        " FROM #stcltmaster mst inner JOIN #clt_tmp liq ON  mst.clt_code = liq.clt_code " & _
        '        " and liq.liq_day > 0 " & _
        '        " left outer join staemaster ae on ae.run_code = mst.run_code WHERE 1=1 "
        lstrSQL = "SELECT  *, mst.os_day as liq_day, " & _
                " cast(0 as decimal(18,2)) as top1_market_value, '' as top1_stock_code, " & _
                " cast(0 as decimal(18,2)) as top2_market_value, '' as top2_stock_code, " & _
                " cast(0 as decimal(18,2)) as top3_market_value, '' as top3_stock_code, " & _
                " run_name, cast(0 as decimal(18,2)) as margin_call_amount,  " & _
                " '' as Due_Undue, '' as Risk " & _
                " FROM #stcltmaster_mrg2 mst inner JOIN #clt_tmp_mrg2 liq ON  mst.clt_code = liq.clt_code " & _
                " left outer join staemaster ae on ae.run_code = mst.run_code WHERE 1=1 "
        lstrSQL += lstrQuery & " order by " & lstrSort


        ldtsTemp = GFncRtnDS(GSCnLiqConn, lstrSQL)

        lstrSQL = " select * from STPortfolio " & _
                " where clt_code in (select mst.clt_code from #stcltmaster_mrg2 mst " & _
                " inner JOIN  #clt_tmp_mrg2 liq ON  mst.clt_code = liq.clt_code " & _
                lstrQuery & ")  "
        Dim ldtTop As DataTable = GFncRtnDS(GSCnLiqConn, lstrSQL).Tables(0)
        For Each ldtwTemp As DataRow In ldtsTemp.Tables(0).Rows
            ldtwTemp.Item("top1_stock_code") = ""
            ldtwTemp.Item("top2_stock_code") = ""
            ldtwTemp.Item("top3_stock_code") = ""
            ldtwTemp.Item("top1_market_value") = 0
            ldtwTemp.Item("top2_market_value") = 0
            ldtwTemp.Item("top3_market_value") = 0

            Dim tmp_bal As Decimal
            If (ldtwTemp.Item("mc_dr_bal") - ldtwTemp.Item("cr_limit") < 0) Then
                tmp_bal = 0
            Else
                tmp_bal = ldtwTemp.Item("mc_dr_bal") - ldtwTemp.Item("cr_limit")
            End If

            If (ldtwTemp.Item("cr_limit") > 1) Then
                If (ldtwTemp.Item("mc_due") > tmp_bal) Then
                    ldtwTemp.Item("margin_call_amount") = ldtwTemp.Item("mc_due")
                Else
                    ldtwTemp.Item("margin_call_amount") = tmp_bal
                End If
            Else
                If ldtwTemp.Item("MC_T2") < 0 Then
                    ldtwTemp.Item("margin_call_amount") = ldtwTemp.Item("mc_due") + ldtwTemp.Item("MC_T2")
                Else
                    ldtwTemp.Item("margin_call_amount") = ldtwTemp.Item("mc_due")
                End If
            End If

            Dim ldtaTop As DataRow()
            ldtaTop = ldtTop.Select(" clt_code = '" & ldtwTemp.Item("clt_code") & "'", " net_market_value desc ")
            For lintCnt As Integer = 0 To ldtaTop.Length - 1
                Select Case lintCnt
                    Case 0
                        ldtwTemp.Item("top1_stock_code") = ldtaTop(0).Item("stk_code")
                        ldtwTemp.Item("top1_market_value") = GFncNoNullValue(ldtaTop(0).Item("net_market_value"))
                    Case 1
                        ldtwTemp.Item("top2_stock_code") = ldtaTop(1).Item("stk_code")
                        ldtwTemp.Item("top2_market_value") = GFncNoNullValue(ldtaTop(1).Item("net_market_value"))
                    Case 2
                        ldtwTemp.Item("top3_stock_code") = ldtaTop(2).Item("stk_code")
                        ldtwTemp.Item("top3_market_value") = GFncNoNullValue(ldtaTop(2).Item("net_market_value"))
                    Case Else
                        Exit For
                End Select
            Next
            ldtwTemp.Item("Due_Undue") = lFncDue(ldtwTemp.Item("mc_due"), ldtwTemp.Item("mc_t2"))
            ldtwTemp.Item("Risk") = lFncRickFactor(ldtwTemp.Item("MC_ACT_RATIO"), ldtwTemp.Item("Due_Undue"), ldtwTemp.Item("dr_bal"))
        Next

        Dim ldt As DataTable = ldtsTemp.Tables(0).Copy
        ldt.Clear()
        Dim Sort As String
        If MC.Length > 0 Then
            Sort = MC
        Else
            Sort = "1=1"
        End If
        Dim ldtaDD As DataRow() = ldtsTemp.Tables(0).Select(Sort, lstrSort)
        For lintCnt As Integer = 0 To ldtaDD.Length - 1
            If (ldtaDD(lintCnt).Item("margin_call_amount") >= 0) Then
                ldt.ImportRow(ldtaDD(lintCnt))
            End If
        Next

        Return ldt

    End Function

    Protected Friend Function lFncPrintMarginCall(ByVal strQuery As String, ByVal strSort As String, _
    ByVal strTitle As String, ByVal MC As String) As ReportClass
        Dim rpt As New RptMarginCall
        Dim ldtsTemp As DataTable = Me.lFncPrepareMC(strQuery, strSort, MC)

        If ldtsTemp.Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp)
            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraTitle", strTitle)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Margin Call Report (New)")
        End If

    End Function

    Protected Friend Function lFncPrintMarginCall2(ByVal strQuery As String, ByVal strSort As String, _
ByVal strTitle As String, ByVal MC As String) As ReportClass
        Dim rpt As New RptMarginCall2
        Dim ldtsTemp As DataTable = Me.lFncPrepareMC2(strQuery, strSort, MC)

        If ldtsTemp.Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp)
            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraTitle", strTitle)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Margin Call Report (New)")
        End If

    End Function

    Protected Friend Function lFncRickFactor(ByVal AR As Double, ByVal Due As String, ByVal Deb_Bal As Double) As Integer
        If AR <= 0.5 Or Due = "Undue" Then
            Return 0
        End If
        If (AR > 0.5 And AR <= 0.6) Then
            Return 1
        End If
        If (AR > 0.6 And AR <= 0.7) Then
            Return 2
        End If
        If (AR > 0.7 And AR <= 0.8) Then
            Return 3
        End If
        If (AR > 0.8 And AR <= 1) Or (AR = 999.99 And Deb_Bal <= 150000) Then
            Return 4
        End If
        If (AR > 1) Or (AR = 999.99 And Deb_Bal > 150000) Then
            Return 5
        End If
    End Function

    Protected Friend Function lFncDue(ByVal McDue As Double, ByVal Undue As Double) As String
        If McDue <= 0 And Undue > 0 Then
            Return "Undue"
        ElseIf McDue > 0 Then
            Return "Due"
        Else
            Return ""
        End If
    End Function

    Protected Friend Sub lFncCreateList()

        Dim lstrSQL As String
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnLiqConn.BeginTransaction

            lstrSQL = "select * into #stcltmaster_mrg from client_liq_master"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "update #stcltmaster_mrg " & _
                        "set #stcltmaster_mrg.os_day = 1 "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "update #stcltmaster_mrg " & _
                        "set #stcltmaster_mrg.os_day = stcltliq.liq_day " & _
                        "from stcltliq " & _
                        "where #stcltmaster_mrg.clt_code = stcltliq.clt_code"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "select a.clt_code, a.run_code, a.mc_dr_bal as dr, a.mc_act_ratio as ar, " & _
                        "a.mc_total as mc, a.mc_due as due, a.mc_t2 as undue, " & _
                        "a.margin_ratio as mr, a.cr_limit as cl, a.clt_type, a.margin_value - isnull(b.margin_value, 0) as due_mv, " & _
                        "isnull(b.margin_value, 0) as undue_margin_value, " & _
                        "isnull(b.market_value, 0) as undue_mv, a.short " & _
                        "into #margin_tmp_mrg " & _
                        "from #stcltmaster_mrg a left join client_mkt_mrg b on a.clt_code = b.client_code " & _
                        "where (a.clt_type = 'M' or a.clt_type = 'F')"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            'lstrSQL = "select clt_code " & _
            '            "into #clt_tmp_mrg " & _
            '            "from #margin_tmp_mrg " & _
            '            "where (    (dr>0 and ar>0.4 and mr>1)     or     (cl<100 and mc>0)     or     ((dr-cl)>0)  )   and   (not (dr<=1000000 and due=0 and undue>=0 and ar<0.7))   or   (short=1)"
            lstrSQL = "select clt_code " & _
                        "into #clt_tmp_mrg " & _
                        "from #margin_tmp_mrg " & _
                        "where (    (dr>0 and mr>1)     or     (cl<100 and mc>0)     or     ((dr-cl)>0)  )   and   (not (dr<=1000000 and due=0 and undue>=0 and ar<0.7))   or   (short=1)"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "select a.accno, sum(a.amount) as amount " & _
                        "into #cashin_tmp_mrg " & _
                        "from client_fund_movement a, #stcltmaster_mrg b " & _
                        "where a.accno = b.clt_code and b.clt_type = 'C' " & _
                        "group by a.accno"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "update #stcltmaster_mrg set deposit = 0"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "update #stcltmaster_mrg " & _
                        "set #stcltmaster_mrg.deposit = #cashin_tmp_mrg.amount " & _
                        "from #cashin_tmp_mrg " & _
                        "where #stcltmaster_mrg.clt_code = #cashin_tmp_mrg.accno " & _
                        "and #cashin_tmp_mrg.amount <> 0"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "select clt_code " & _
                        "into #os_tmp_mrg " & _
                        "from #stcltmaster_mrg " & _
                        "where clt_type = 'C' " & _
                        "and ((withdrawal > 0 and withdrawal > deposit) or (mc_act_ratio > 0.7) or (short = 1)) "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "insert into #clt_tmp_mrg(clt_code) select clt_code from #os_tmp_mrg "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "drop table #margin_tmp_mrg "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "drop table #cashin_tmp_mrg "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "drop table #os_tmp_mrg "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            MyTrans.Commit()
            MyTrans = Nothing

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

    End Sub

    Protected Friend Sub lFncCleanTempTable()

        Dim lstrSQL As String
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnLiqConn.BeginTransaction

            lstrSQL = "drop table #stcltmaster_mrg"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "drop table #clt_tmp_mrg "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            MyTrans.Commit()
            MyTrans = Nothing

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

    End Sub

    Protected Friend Sub lFncCreateList2()

        Dim lstrSQL As String
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnLiqConn.BeginTransaction

            lstrSQL = "select * into #stcltmaster_mrg2 from client_liq_master"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "update #stcltmaster_mrg2 " & _
                        "set #stcltmaster_mrg2.os_day = 1 "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "update #stcltmaster_mrg2 " & _
                        "set #stcltmaster_mrg2.os_day = stcltliq.liq_day " & _
                        "from stcltliq " & _
                        "where #stcltmaster_mrg2.clt_code = stcltliq.clt_code"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "select a.clt_code, a.run_code, a.mc_dr_bal as dr, a.mc_act_ratio as ar, " & _
                        "a.mc_total as mc, a.mc_due as due, a.mc_t2 as undue, " & _
                        "a.margin_ratio as mr, a.cr_limit as cl, a.clt_type, a.margin_value - isnull(b.margin_value, 0) as due_mv, " & _
                        "isnull(b.margin_value, 0) as undue_margin_value, " & _
                        "isnull(b.market_value, 0) as undue_mv, a.short " & _
                        "into #margin_tmp_mrg " & _
                        "from #stcltmaster_mrg2 a left join client_mkt_mrg b on a.clt_code = b.client_code " & _
                        "where (a.clt_type = 'M' or a.clt_type = 'F')"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "select clt_code " & _
                        "into #clt_tmp_mrg2 " & _
                        "from #margin_tmp_mrg " & _
                        "where " & getFilterLogic()
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "select a.accno, sum(a.amount) as amount " & _
                        "into #cashin_tmp_mrg " & _
                        "from client_fund_movement a, #stcltmaster_mrg2 b " & _
                        "where a.accno = b.clt_code and b.clt_type = 'C' " & _
                        "group by a.accno"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "update #stcltmaster_mrg2 set deposit = 0"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "update #stcltmaster_mrg2 " & _
                        "set #stcltmaster_mrg2.deposit = #cashin_tmp_mrg.amount " & _
                        "from #cashin_tmp_mrg " & _
                        "where #stcltmaster_mrg2.clt_code = #cashin_tmp_mrg.accno " & _
                        "and #cashin_tmp_mrg.amount <> 0"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "select clt_code " & _
                        "into #os_tmp_mrg " & _
                        "from #stcltmaster_mrg2 " & _
                        "where clt_type = 'C' " & _
                        "and ((withdrawal > 0 and withdrawal > deposit) or (mc_act_ratio > 0.7) or (short = 1)) "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "insert into #clt_tmp_mrg2(clt_code) select clt_code from #os_tmp_mrg "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "drop table #margin_tmp_mrg "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "drop table #cashin_tmp_mrg "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "drop table #os_tmp_mrg "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            MyTrans.Commit()
            MyTrans = Nothing

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

    End Sub

    Protected Friend Sub lFncCleanTempTable2()

        Dim lstrSQL As String
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnLiqConn.BeginTransaction

            lstrSQL = "drop table #stcltmaster_mrg2"
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            lstrSQL = "drop table #clt_tmp_mrg2 "
            GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

            MyTrans.Commit()
            MyTrans = Nothing

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

    End Sub

    Protected Friend Function getFilterLogic() As String
        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet = Nothing

        lstrSQL = "SELECT misc_desc " & _
                    " FROM misc_master " & _
                    " where misc_type = 'LiqListLogic' and misc_code = 'liq_list_margin'"

        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsTemp.Tables(0).Rows.Count <= 0 Then
            Return ""
        End If

        Return ldtsTemp.Tables(0).Rows(0).Item("misc_desc")

    End Function

    Protected Friend Function getAR() As String
        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet = Nothing

        lstrSQL = "SELECT misc_desc " & _
                    " FROM misc_master " & _
                    " where misc_type = 'MrgCallRpt' and misc_code = 'new_mrg_call_ar'"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsTemp.Tables(0).Rows.Count <= 0 Then
            Return ""
        End If

        Return ldtsTemp.Tables(0).Rows(0).Item("misc_desc")
    End Function

    Protected Friend Function getMR() As String
        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet = Nothing

        lstrSQL = "SELECT misc_desc " & _
                    " FROM misc_master " & _
                    " where misc_type = 'MrgCallRpt' and misc_code = 'new_mrg_call_mr'"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsTemp.Tables(0).Rows.Count <= 0 Then
            Return ""
        End If

        Return ldtsTemp.Tables(0).Rows(0).Item("misc_desc")
    End Function

    Protected Friend Function getAndOr() As String
        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet = Nothing

        lstrSQL = "SELECT misc_desc " & _
                    " FROM misc_master " & _
                    " where misc_type = 'MrgCallRpt' and misc_code = 'new_mrg_call_AndOr'"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsTemp.Tables(0).Rows.Count <= 0 Then
            Return ""
        End If

        Return ldtsTemp.Tables(0).Rows(0).Item("misc_desc")
    End Function

    Protected Friend Function setCriteria(ByVal newAR As String, ByVal newAndOr As String, ByVal newMR As String) As Boolean
        Dim lstrSQL As String = ""
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            lstrSQL = "Update misc_master set misc_desc = '" & newAR & _
                        "' where misc_type = 'MrgCallRpt' and misc_code = 'new_mrg_call_ar'"
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            lstrSQL = "Update misc_master set misc_desc = '" & newAndOr & _
                        "' where misc_type = 'MrgCallRpt' and misc_code = 'new_mrg_call_AndOr'"
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            lstrSQL = "Update misc_master set misc_desc = '" & newMR & _
                        "' where misc_type = 'MrgCallRpt' and misc_code = 'new_mrg_call_mr'"
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            MyTrans.Commit()
            MyTrans = Nothing
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

End Class
