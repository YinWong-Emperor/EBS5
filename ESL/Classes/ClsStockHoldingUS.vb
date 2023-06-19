Public Class ClsStockHoldingUS

    Protected Friend Function lFncExptStockHoldings(ByVal withDebit As Boolean) As Boolean

        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet
        Dim strExFile As String = ""

        If (GSubShowYNConfirm(GFncGetSysMsg(27)) = Windows.Forms.DialogResult.Yes) Then
            If (withDebit) Then
                lstrSQL = "select stock_code, sm.s_code, closing_price, sum(net_onhand_qty) as qty, " & _
                                    "sum(closing_price * net_onhand_qty) as mkt_val, margin_ratio, " & _
                                    "sum(margin_ratio*closing_price * net_onhand_qty/100) as mgn_val, " & _
                                    "cp.currency_code as currency, ce.last/cur.base as fx_rate, " & _
                                    "sum(closing_price * net_onhand_qty * ce.last/cur.base) as mkt_val_HKD, " & _
                                    "sum(margin_ratio*closing_price * net_onhand_qty/100 * ce.last/cur.base) as mgn_val_HKD " & _
                                    "from " & GStrG2BS2DB & ".dbo.view_ER_client_master_mkt_mrg_value cm, " & _
                                    GStrG2BS2DB & ".dbo.view_ER_client_portfolio cp, " & _
                                    GStrG2BS2DB & ".dbo.stock_master sm, " & _
                                    GStrG2BS2DB & ".dbo.currency_exchange ce, " & _
                                    GStrG2BSDB & ".dbo.currency_master cur, " & _
                                    " ( select distinct client_code from " & GStrG2BS2DB & _
                                    ".dbo.view_ER_client_master_bals  where ledger_bal < 0 ) cmb " & _
                                    "where cmb.client_code = cm.client_code and " & _
                                    " cm.client_code = cp.accno and cp.stock_code = sm.stkno " & _
                                    "and client_type = 'Margin' and suspended <> 'Y' " & _
                                    "and net_onhand_qty <> 0 " & _
                                    "and cm.currency_code = 'HKD' " & _
                                    "and cp.cuid = ce.cuid and cuid_ex = 1 " & _
                                    "and cp.cuid = cur.cuid " & _
                                    "group by  stock_code, sm.s_code, closing_price, margin_ratio, cp.currency_code, ce.last/cur.base " & _
                                    "order by stock_code"

                'lstrSQL = "and ledger_bal < 0 "
                strExFile = "debit_"

            Else
                lstrSQL = "select stock_code, sm.s_code, closing_price, sum(net_onhand_qty) as qty, " & _
                                     "sum(closing_price * net_onhand_qty) as mkt_val, margin_ratio, " & _
                                     "sum(margin_ratio*closing_price * net_onhand_qty/100) as mgn_val, " & _
                                     "cp.currency_code as currency, ce.last/cur.base as fx_rate, " & _
                                     "sum(closing_price * net_onhand_qty * ce.last/cur.base) as mkt_val_HKD, " & _
                                     "sum(margin_ratio*closing_price * net_onhand_qty/100 * ce.last/cur.base) as mgn_val_HKD " & _
                                     "from " & GStrG2BS2DB & ".dbo.view_ER_client_master_mkt_mrg_value cm, " & _
                                     GStrG2BS2DB & ".dbo.view_ER_client_portfolio cp, " & _
                                     GStrG2BS2DB & ".dbo.stock_master sm, " & _
                                     GStrG2BS2DB & ".dbo.currency_exchange ce, " & _
                                     GStrG2BSDB & ".dbo.currency_master cur " & _
                                     "where cm.client_code = cp.accno and cp.stock_code = sm.stkno " & _
                                     "and client_type = 'Margin' and suspended <> 'Y' " & _
                                     "and net_onhand_qty <> 0 " & _
                                     "and cm.currency_code = 'HKD' " & _
                                     "and cp.cuid = ce.cuid and cuid_ex = 1 " & _
                                     "and cp.cuid = cur.cuid " & _
                                     "group by  stock_code, sm.s_code, closing_price, margin_ratio, cp.currency_code, ce.last/cur.base " & _
                                     "order by stock_code"
            End If
            strExFile = strExFile & "mgn_clt_holding.csv"

            ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

            If (ldtsTemp.Tables(0).Rows.Count > 0) Then
                GExportCSV(GStrExptDir, strExFile, ldtsTemp, " stock_code, stock_name, closing_price, qty, mkt_val, " & _
                            "margin_ratio, mrg_val, currency, fx rate to HKD, mkt_val (HKD Equiv), mrg_val (HKD Equiv)")
                Return True
            End If

            GSubShowInfo(GFncGetSysMsg(2))
        End If

        Return False

    End Function

End Class
