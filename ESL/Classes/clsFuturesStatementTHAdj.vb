Public Class clsFuturesStatementTHAdj

    Protected Friend Enum SearchMode
        All
        Adjusted
        Normal
    End Enum

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

    Protected Friend Function GetPeriod() As DataTable
        Dim lcStrSQL As String = "Select distinct period From newedge_cap_trade_hist UNION Select distinct period From newedge_cap_trade_hist_adj"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function

    Protected Friend Function GetProduct() As DataTable
        Dim lcStrSQL As String = "Select distinct product From newedge_cap_trade_hist UNION Select distinct product From newedge_cap_trade_hist_adj"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function

    Protected Friend Function InsertAdjustmentRecord(ByVal pNoId As String, ByVal pAdjAction As String, ByVal pAdjRemark As String, ByVal pTdate As Object, _
                                            ByVal pBuy As String, ByVal pSell As String, ByVal pMonthCode As String, _
                                            ByVal pProduct As String, ByVal pPeriod As String, ByVal pPrice As String, ByVal pComm As String, ByVal pClearing As String, ByVal pLevy As String, _
                                            ByVal pSettleDate As Object, ByVal pMonthlyDaily As String, ByVal pContractSize As String, _
                                            ByVal pCounterParty As String, ByVal pCallPut As String, ByVal pStrike As String) As Boolean
        Dim lcStrSQL As String = ""
        Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction
        lcStrSQL = "INSERT INTO newedge_cap_trade_hist_adj (thtid, Adj_Action, Adj_Remark, tdate, buy, sell, monthcode, " & _
                    "product, period, price, comm, clearing, levy, settle_date, monthly_daily, contract_size, counterparty, lupduser, lupddate, callput, strike) VALUES (" & _
                    IIf(pNoId = "", "NULL", pNoId) & ", " & _
                    IIf(pAdjAction = "", "NULL", "'" & pAdjAction & "'") & ", " & _
                    IIf(pAdjRemark = "", "NULL", "'" & pAdjRemark & "'") & ", " & _
                    IIf(IsNothing(pTdate), "NULL", "'" & GFncNoNullDate(pTdate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    IIf(pBuy = "", "NULL", pBuy) & ", " & _
                    IIf(pSell = "", "NULL", pSell) & ", " & _
                    IIf(pMonthCode = "", "NULL", "'" & pMonthCode & "'") & ", " & _
                    IIf(pProduct = "", "NULL", "'" & pProduct & "'") & ", " & _
                    IIf(pPeriod = "", "NULL", "'" & pPeriod & "'") & ", " & _
                    IIf(pPrice = "", "NULL", pPrice) & ", " & _
                    IIf(pComm = "", "NULL", pComm) & ", " & _
                    IIf(pClearing = "", "NULL", pClearing) & ", " & _
                    IIf(pLevy = "", "NULL", pLevy) & ", " & _
                    IIf(IsNothing(pSettleDate), "NULL", "'" & GFncNoNullDate(pSettleDate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    IIf(pMonthlyDaily = "", "NULL", "'" & pMonthlyDaily & "'") & ", " & _
                    IIf(pContractSize = "" OrElse pContractSize = "0", "NULL", "" & pContractSize & "") & ", " & _
                    IIf(pCounterParty = "", "NULL", "'" & pCounterParty & "'") & ", " & _
                    "'" & GStrloginID & "'" & ", GETDATE()" & ", " & _
                     "'" & pCallPut & "'" & ", " & _
                    IIf(pStrike = "", "NULL", pStrike) & ")"
        If GFncRunSQL(GSCnSqlConn, myTrans, lcStrSQL) > 0 Then
            myTrans.Commit()
            Return True
        Else
            myTrans.Rollback()
            Return False
        End If
    End Function

    Protected Friend Function UpdateAdjustmentRecord(ByVal pAdjNoId As String, ByVal pAdjAction As String, ByVal pAdjRemark As String, ByVal pTdate As Object, _
                                            ByVal pBuy As String, ByVal pSell As String, ByVal pMonthCode As String, _
                                            ByVal pProduct As String, ByVal pPeriod As String, ByVal pPrice As String, ByVal pComm As String, ByVal pClearing As String, ByVal pLevy As String, _
                                            ByVal pSettleDate As Object, ByVal pMonthlyDaily As String, ByVal pContractSize As String, _
                                            ByVal pCounterParty As String, ByVal pCallPut As String, ByVal pStrike As String) As Boolean
        Dim lcStrSQL As String = ""
        Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction

        lcStrSQL = "UPDATE newedge_cap_trade_hist_adj SET " & _
                    "Adj_Action = " & IIf(pAdjAction = "", "NULL", "'" & pAdjAction & "'") & ", " & _
                    "Adj_Remark = " & IIf(pAdjRemark = "", "NULL", "'" & pAdjRemark & "'") & ", " & _
                    "tdate = " & IIf(IsNothing(pTdate), "NULL", "'" & GFncNoNullDate(pTdate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    "buy = " & IIf(pBuy = "", "NULL", pBuy) & ", " & _
                    "sell = " & IIf(pSell = "", "NULL", pSell) & ", " & _
                    "monthcode = " & IIf(pMonthCode = "", "NULL", "'" & pMonthCode & "'") & ", " & _
                    "product = " & IIf(pProduct = "", "NULL", "'" & pProduct & "'") & ", " & _
                    "period = " & IIf(pPeriod = "", "NULL", "'" & pPeriod & "'") & ", " & _
                    "price = " & IIf(pPrice = "", "NULL", pPrice) & ", " & _
                    "comm = " & IIf(pComm = "", "NULL", pComm) & ", " & _
                    "clearing = " & IIf(pClearing = "", "NULL", pClearing) & ", " & _
                    "levy = " & IIf(pLevy = "", "NULL", pLevy) & ", " & _
                    "settle_date = " & IIf(IsNothing(pSettleDate), "NULL", "'" & GFncNoNullDate(pSettleDate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    "monthly_daily = " & IIf(pMonthlyDaily = "", "NULL", "'" & pMonthlyDaily & "'") & ", " & _
                    "contract_size = " & IIf(pContractSize = "", "NULL", "" & pContractSize & "") & ", " & _
                    "counterparty = " & IIf(pCounterParty = "", "NULL", "'" & pCounterParty & "'") & ", " & _
                    "lupduser = '" & GStrloginID & "', " & _
                    "lupddate = " & "GETDATE()" & ", " & _
                    "callput = '" & pCallPut & "', " & _
                    "strike = " & IIf(pStrike = "", "NULL", pStrike) & " " & _
                    "WHERE adjNoId = " & pAdjNoId

        If GFncRunSQL(GSCnSqlConn, myTrans, lcStrSQL) > 0 Then
            myTrans.Commit()
            Return True
        Else
            myTrans.Rollback()
            Return False
        End If
    End Function

    Protected Friend Function DeleteAdjustmentRecord(ByVal pAdjNoId As String) As Boolean
        Dim lcStrSQL As String = ""
        Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction
        lcStrSQL = "DELETE FROM newedge_cap_trade_hist_adj WHERE adjnoid=" & pAdjNoId

        If GFncRunSQL(GSCnSqlConn, myTrans, lcStrSQL) > 0 Then
            myTrans.Commit()
            Return True
        Else
            myTrans.Rollback()
            Return False
        End If
    End Function

    Protected Friend Function QueryAdjRecord(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String, ByVal pProduct As String, ByVal pPrice As String, ByVal pSearchMode As SearchMode, ByVal pCallPut As String, ByVal pStrike As String) As DataTable
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        Dim lcStrTable As String = ""
        Dim lcResult As DataTable = Nothing
        Dim lcResultRow As DataRow = Nothing

        lcStrWhere = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If
        If pMonthCode <> "-- ALL --" Then
            lcStrWhere &= "AND monthcode = '" & pMonthCode & "' "
        End If
        If pProduct <> "-- ALL --" Then
            lcStrWhere &= "AND product = '" & pProduct & "' "
        End If
        If pPrice <> "-- ALL --" Then
            lcStrWhere &= "AND price = " & pPrice & " "
        End If

        If pCallPut <> "-- ALL --" Then
            lcStrWhere &= "AND callput = '" & pCallPut & "' "
        End If

        If pStrike <> "-- ALL --" Then
            lcStrWhere &= "AND strike = " & pStrike & " "
        End If

        If pSearchMode = SearchMode.Adjusted Then
            lcStrTable = "newedge_cap_trade_hist_adj"
            lcStrSQL = "SELECT adjnoid, thtid, Adj_Action, Adj_Remark, tdate, buy, sell, monthcode, " & _
                        "product, period, price, comm, clearing, levy, settle_date, monthly_daily, contract_size, counterparty, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput, strike FROM " & lcStrTable & " WHERE 1=1 "
            lcStrSQL &= lcStrWhere
        ElseIf pSearchMode = SearchMode.Normal Then
            lcStrTable = "newedge_cap_trade_hist"
            lcStrSQL = "SELECT '' AS adjnoid, tid AS thtid, '' AS Adj_Action, '' AS Adj_Remark, tdate, buy, sell, monthcode, " & _
                        "product, period, price, comm, clearing, levy, settle_date, monthly_daily, contract_size, counterparty, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput, strike FROM " & lcStrTable & " WHERE 1=1 "
            lcStrSQL &= lcStrWhere
            lcStrSQL &= "AND tid NOT IN (SELECT thtid FROM newedge_cap_trade_hist_adj)"
        ElseIf pSearchMode = SearchMode.All Then
            lcStrSQL = "SELECT * FROM ( " & _
                        "SELECT c.adjnoid, a.tid AS thtid, c.adj_action, c.adj_remark, " & _
                        "a.tdate, a.buy, a.sell, a.monthcode, a.product, a.period, a.price, a.comm, a.clearing, a.levy, " & _
                        "a.settle_date, a.monthly_daily, a.contract_size, a.counterparty, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput, a.strike " & _
                        "FROM vw_cap_trade_hist a INNER JOIN newedge_cap_trade_hist b " & _
                        "ON a.tid = b.tid " & _
                        "INNER JOIN newedge_cap_trade_hist_adj c " & _
                        "ON b.tid = c.thtid " & _
                        ") AS a WHERE 1=1 " & _
                        lcStrWhere & _
                        "UNION " & _
                        "SELECT adjnoid, THtid, Adj_Action, Adj_Remark, tdate, buy, sell, monthcode, " & _
                        "product, period, price, comm, clearing, levy, settle_date, monthly_daily, " & _
                        "contract_size, counterparty, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput, strike FROM newedge_cap_trade_hist_adj WHERE adj_action <> 'M' " & _
                        lcStrWhere & _
                        "UNION " & _
                        "SELECT '' AS adjnoid, tid AS thtid, '' AS Adj_Action, '' AS Adj_Remark, " & _
                        "tdate, buy, sell, monthcode, product, period, price, comm, clearing, levy, " & _
                        "settle_date, monthly_daily, contract_size, counterparty, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput, strike " & _
                        "FROM newedge_cap_trade_hist WHERE tid NOT IN (SELECT thtid FROM newedge_cap_trade_hist_adj) " & _
                        lcStrWhere & _
                        "ORDER by thtid, adjnoid "

            '    lcStrSQL = "SELECT adjnoid, opnoid, Adj_Action, Adj_Remark, tdate, odate, buy, sell, monthcode, " & _
            '                "product, price, closing_price, floating, settle_date, monthly_daily, contract_size, counterparty FROM newedge_cap_op_adj WHERE 1=1 "
            '    lcStrSQL &= lcStrWhere
            '    lcStrSQL &= "UNION "
            '    lcStrSQL &= "(SELECT '' AS adjnoid, noid AS opnoid, '' AS Adj_Action, '' AS Adj_Remark, tdate, odate, buy, sell, monthcode, " & _
            '                "product, price, closing_price, floating, settle_date, monthly_daily, contract_size, counterparty FROM newedge_cap_op WHERE 1=1 " & lcStrWhere & " AND noid NOT IN (SELECT adjnoid FROM newedge_cap_op_adj))"
        End If

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        lcResult = dt.Clone()

        For i As Integer = 0 To dt.Columns.Count - 1
            If i = 0 OrElse i = 1 Then
                lcResult.Columns(i).DataType = Type.GetType("System.String")
            End If
        Next

        For i As Integer = 0 To dt.Rows.Count - 1
            lcResultRow = lcResult.NewRow()
            For j As Integer = 0 To dt.Columns.Count - 1
                lcResultRow.Item(j) = dt.Rows(i).Item(j)
            Next
            lcResult.Rows.Add(lcResultRow)
        Next

        Return lcResult

    End Function

    Protected Friend Function CheckExistAdjustment(ByVal pThtId As String, ByVal pAdjNoId As String) As String
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        If pAdjNoId <> "" Then
            lcStrWhere = "AND adjnoid=" & pAdjNoId
        End If
        lcStrSQL = "SELECT * FROM newedge_cap_trade_hist_adj WHERE thtid=" & pThtId & " AND adj_action IN ('M') " & lcStrWhere

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return GFncNoNullString(dt.Rows(0).Item("adjNoId"))
        End If
        Return ""
    End Function

    Protected Friend Function IsDeletedAdjustment(ByVal pTHtId As String, ByVal pAdjNoId As String) As Boolean
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        If pAdjNoId <> "" Then
            lcStrWhere = "AND adjnoid=" & pAdjNoId
        End If
        lcStrSQL = "SELECT * FROM newedge_cap_trade_hist_adj WHERE thtid=" & pTHtId & " AND adj_action IN ('D') " & lcStrWhere

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function IsNewAddedAdjustment(ByVal pAdjNoId As String) As Boolean
        If pAdjNoId = "" Then
            Return False
        End If

        Dim lcStrSQL As String = ""
        lcStrSQL = "SELECT * FROM newedge_cap_trade_hist_adj WHERE adjnoid=" & pAdjNoId & " AND adj_action IN ('A')"

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function GetOrginalData(ByVal pNoid As String) As DataTable
        Dim lcStrSQL As String = "SELECT tid, tdate, buy, sell, monthcode, product, price, period, comm, clearing, levy, settle_date, monthly_daily, contract_size, counterparty, strike, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput FROM newedge_cap_trade_hist WHERE tId = " & pNoid
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetAdjustedData(ByVal pAdjNoid As String) As DataTable
        Dim lcStrSQL As String = "SELECT adjnoid, Adj_Action, Adj_Remark, THtid, tdate, buy, sell, monthcode, product, price, period, comm, clearing, levy, settle_date, monthly_daily, contract_size, counterparty, lupduser, lupddate, strike, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput FROM newedge_cap_trade_hist_adj WHERE adjNoId = " & pAdjNoid
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetQryCounterParty(ByVal pTdate As Date) As DataTable
        Dim lcStrWhere As String = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "

        Dim lcStrSQL As String = "SELECT DISTINCT counterparty FROM newedge_cap_trade_hist " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT counterparty FROM newedge_cap_trade_hist_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY counterparty"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetQryMonthCode(ByVal pTdate As Date, ByVal pCounterParty As String) As DataTable
        Dim lcStrWhere As String = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If
        Dim lcStrSQL As String = "SELECT DISTINCT monthcode FROM newedge_cap_trade_hist " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT monthcode FROM newedge_cap_trade_hist_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY monthcode"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetQryProduct(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String) As DataTable
        Dim lcStrWhere As String = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If
        If pMonthCode <> "-- ALL --" Then
            lcStrWhere &= "AND monthcode = '" & pMonthCode & "' "
        End If
        Dim lcStrSQL As String = "SELECT DISTINCT product FROM newedge_cap_trade_hist " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT product FROM newedge_cap_trade_hist_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY product"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetQryPrice(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String, ByVal pProduct As String) As DataTable
        Dim lcStrWhere As String = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If
        If pMonthCode <> "-- ALL --" Then
            lcStrWhere &= "AND monthcode = '" & pMonthCode & "' "
        End If
        If pProduct <> "-- ALL --" Then
            lcStrWhere &= "AND product = '" & pProduct & "' "
        End If
        Dim lcStrSQL As String = "SELECT DISTINCT price FROM newedge_cap_trade_hist " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT price FROM newedge_cap_trade_hist_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY price"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function
    Protected Friend Function GetQryCallPut(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String, ByVal pProduct As String) As DataTable
        Dim lcStrWhere As String = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If
        If pMonthCode <> "-- ALL --" Then
            lcStrWhere &= "AND monthcode = '" & pMonthCode & "' "
        End If
        If pProduct <> "-- ALL --" Then
            lcStrWhere &= "AND product = '" & pProduct & "' "
        End If
        Dim lcStrSQL As String = "SELECT DISTINCT callput FROM newedge_cap_trade_hist " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT callput FROM newedge_cap_trade_hist_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY callput"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function
    Protected Friend Function GetQryStrike(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String, ByVal pProduct As String) As DataTable
        Dim lcStrWhere As String = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If
        If pMonthCode <> "-- ALL --" Then
            lcStrWhere &= "AND monthcode = '" & pMonthCode & "' "
        End If
        If pProduct <> "-- ALL --" Then
            lcStrWhere &= "AND product = '" & pProduct & "' "
        End If
        Dim lcStrSQL As String = "SELECT DISTINCT strike FROM newedge_cap_trade_hist " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT strike FROM newedge_cap_trade_hist_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY strike"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function
End Class
