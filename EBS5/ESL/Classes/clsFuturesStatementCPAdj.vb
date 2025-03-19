Public Class clsFuturesStatementCPAdj

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

    Protected Friend Function GetProduct() As DataTable
        Dim lcStrSQL As String = "Select distinct product From newedge_cap_CP UNION Select distinct product From newedge_cap_CP_adj"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function

    Protected Friend Function InsertAdjustmentRecord(ByVal pNoId As String, ByVal pAdjAction As String, ByVal pAdjRemark As String, ByVal pTdate As Object, _
                                            ByVal pOdate As Object, ByVal pBuy As String, ByVal pSell As String, ByVal pMonthCode As String, _
                                            ByVal pProduct As String, ByVal pPrice As String, ByVal pLiqPrice As String, ByVal pPL As String, _
                                            ByVal pSettleDate As Object, ByVal pMonthlyDaily As String, ByVal pLiqId As String, ByVal pContractSize As String, _
                                            ByVal pCounterParty As String, ByVal pCallPut As String, ByVal pStrike As String, Optional ByVal myTrans As SqlClient.SqlTransaction = Nothing, Optional ByVal myConn As SqlClient.SqlConnection = Nothing) As Boolean
        Dim canEndTrans As Boolean = False
        Dim lcStrSQL As String = ""
        If IsNothing(myConn) Then
            myConn = CType(GSCnSqlConn, ICloneable).Clone
            myConn.Open()
            myTrans = myConn.BeginTransaction
            canEndTrans = True
        End If
        'Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction
        lcStrSQL = "INSERT INTO newedge_cap_cp_adj (cpnoid, Adj_Action, Adj_Remark, tdate, odate, buy, sell, monthcode, " & _
                    "product, price, liq_price, pl, settle_date, monthly_daily, contract_size, liq_id ,counterparty, lupduser, lupddate, callput, strike) VALUES (" & _
                    IIf(pNoId = "", "NULL", pNoId) & ", " & _
                    IIf(pAdjAction = "", "NULL", "'" & pAdjAction & "'") & ", " & _
                    IIf(pAdjRemark = "", "NULL", "'" & pAdjRemark & "'") & ", " & _
                    IIf(IsNothing(pTdate), "NULL", "'" & GFncNoNullDate(pTdate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    IIf(IsNothing(pOdate), "NULL", "'" & GFncNoNullDate(pOdate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    IIf(pBuy = "", "NULL", pBuy) & ", " & _
                    IIf(pSell = "", "NULL", pSell) & ", " & _
                    IIf(pMonthCode = "", "NULL", "'" & pMonthCode & "'") & ", " & _
                    IIf(pProduct = "", "NULL", "'" & pProduct & "'") & ", " & _
                    IIf(pPrice = "", "NULL", pPrice) & ", " & _
                    IIf(pLiqPrice = "", "NULL", pLiqPrice) & ", 0," & _
                    IIf(IsNothing(pSettleDate), "NULL", "'" & GFncNoNullDate(pSettleDate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    IIf(pMonthlyDaily = "", "NULL", "'" & pMonthlyDaily & "'") & ", " & _
                    IIf(pContractSize = "" OrElse pContractSize = "0", "NULL", "" & pContractSize & "") & ", " & _
                    pLiqId & ", " & _
                    IIf(pCounterParty = "", "NULL", "'" & pCounterParty & "'") & ", " & _
                    "'" & GStrloginID & "'" & ", GETDATE()" & ", " & _
                    "'" & pCallPut & "', " & _
                    IIf(pStrike = "", "NULL", pStrike) & ")"
        If GFncRunSQL(myConn, myTrans, lcStrSQL) > 0 Then
            'If GFncRunSQL(GSCnSqlConn, myTrans, lcStrSQL) > 0 Then
            If canEndTrans Then
                myTrans.Commit()
            End If
            Return True
        Else
            'myTrans.Rollback()
            If canEndTrans Then
                myTrans.Rollback()
            End If
            Return False
        End If
    End Function

    Protected Friend Function UpdateAdjustmentRecord(ByVal pAdjNoId As String, ByVal pAdjAction As String, ByVal pAdjRemark As String, ByVal pTdate As Object, _
                                            ByVal pOdate As Object, ByVal pBuy As String, ByVal pSell As String, ByVal pMonthCode As String, _
                                            ByVal pProduct As String, ByVal pPrice As String, ByVal pLiqPrice As String, ByVal pPL As String, _
                                            ByVal pSettleDate As Object, ByVal pMonthlyDaily As String, ByVal pLiqId As String, ByVal pContractSize As String, _
                                            ByVal pCounterParty As String, ByVal pCallPut As String, ByVal pStrike As String, Optional ByVal myTrans As SqlClient.SqlTransaction = Nothing, Optional ByVal myConn As SqlClient.SqlConnection = Nothing) As Boolean
        Dim canEndTrans As Boolean = False
        Dim lcStrSQL As String = ""
        'Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction
        If IsNothing(myConn) Then
            myConn = CType(GSCnSqlConn, ICloneable).Clone
            myConn.Open()
            myTrans = myConn.BeginTransaction
            canEndTrans = True
        End If
        lcStrSQL = "UPDATE newedge_cap_cp_adj SET " & _
                    "Adj_Action = " & IIf(pAdjAction = "", "NULL", "'" & pAdjAction & "'") & ", " & _
                    "Adj_Remark = " & IIf(pAdjRemark = "", "NULL", "'" & pAdjRemark & "'") & ", " & _
                    "tdate = " & IIf(IsNothing(pTdate), "NULL", "'" & GFncNoNullDate(pTdate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    "odate = " & IIf(IsNothing(pOdate), "NULL", "'" & GFncNoNullDate(pOdate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    "buy = " & IIf(pBuy = "", "NULL", pBuy) & ", " & _
                    "sell = " & IIf(pSell = "", "NULL", pSell) & ", " & _
                    "monthcode = " & IIf(pMonthCode = "", "NULL", "'" & pMonthCode & "'") & ", " & _
                    "product = " & IIf(pProduct = "", "NULL", "'" & pProduct & "'") & ", " & _
                    "price = " & IIf(pPrice = "", "NULL", pPrice) & ", " & _
                    "liq_price = " & IIf(pLiqPrice = "", "NULL", pLiqPrice) & ", " & _
                    "pl = 0,  " & _
                    "settle_date = " & IIf(IsNothing(pSettleDate), "NULL", "'" & GFncNoNullDate(pSettleDate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    "monthly_daily = " & IIf(pMonthlyDaily = "", "NULL", "'" & pMonthlyDaily & "'") & ", " & _
                    "contract_size = " & IIf(pContractSize = "", "NULL", "" & pContractSize & "") & ", " & _
                    "liq_id = " & pLiqId & ", " & _
                    "counterparty = " & IIf(pCounterParty = "", "NULL", "'" & pCounterParty & "'") & ", " & _
                    "lupduser = '" & GStrloginID & "', " & _
                    "lupddate = " & "GETDATE()" & ", " & _
                    "callput = '" & pCallPut & "', " & _
                    "strike = " & IIf(pStrike = "", "NULL", pStrike) & " " & _
                    "WHERE adjNoId = " & pAdjNoId

        If GFncRunSQL(myConn, myTrans, lcStrSQL) > 0 Then
            'If GFncRunSQL(GSCnSqlConn, myTrans, lcStrSQL) > 0 Then
            'myTrans.Commit()
            If canEndTrans Then
                myTrans.Commit()
            End If

            Return True
        Else
            'myTrans.Rollback()
            If canEndTrans Then
                myTrans.Rollback()
            End If
            Return False
        End If
    End Function

    Protected Friend Function DeleteAdjustmentRecord(ByVal pAdjNoId As String, Optional ByVal myTrans As SqlClient.SqlTransaction = Nothing, Optional ByVal myConn As SqlClient.SqlConnection = Nothing) As Boolean
        Dim canEndTrans As Boolean = False
        If IsNothing(myConn) Then
            myConn = CType(GSCnSqlConn, ICloneable).Clone
            myConn.Open()
            myTrans = myConn.BeginTransaction
            canEndTrans = True
        End If
        Dim lcStrSQL As String = ""
        Dim lcCls As New clsFuturesStatementLHAdj

        'lcStrSQL = "SELECT * FROM newedge_cap_cp_adj a INNER JOIN vw_liq_header b ON a.liq_id=b.nid WHERE a.adjnoid=" & pAdjNoId
        'Dim dt As DataTable = GFncRtnDS(myConn, lcStrSQL, myTrans).Tables(0)
        'If dt.Rows.Count <= 0 Then
        '    lcStrSQL = "SELECT c.* FROM newedge_cap_cp_adj a INNER JOIN newedge_liq_header b " & _
        '                "ON a.liq_id=b.nid INNER JOIN newedge_liq_header_adj c ON b.nid=c.lhnid WHERE a.adjnoid=" & pAdjNoId
        '    dt = GFncRtnDS(myConn, lcStrSQL, myTrans).Tables(0)
        '    If Not lcCls.DeleteAdjustmentRecord(GFncNoNullString(dt.Rows(0).Item("adjNoId")), myTrans, myConn) Then
        '        If canEndTrans Then
        '            myTrans.Rollback()
        '        End If
        '        Return False
        '    End If
        'End If

        lcStrSQL = "SELECT c.adjNoId FROM newedge_cap_cp_adj a INNER JOIN newedge_liq_header_adj c ON a.liq_id=c.lhnid " & _
                " WHERE a.adj_action = 'A' and a.adjnoid=" & pAdjNoId
        Dim dt As DataTable = GFncRtnDS(myConn, lcStrSQL, myTrans).Tables(0)
        If dt.Rows.Count > 0 Then
            If Not lcCls.DeleteAdjustmentRecord(GFncNoNullString(dt.Rows(0).Item("adjNoId")), myTrans, myConn) Then
                If canEndTrans Then
                    myTrans.Rollback()
                End If
                Return False
            End If
        End If


        lcStrSQL = "DELETE FROM newedge_cap_cp_adj WHERE adjnoid=" & pAdjNoId

        If GFncRunSQL(myConn, myTrans, lcStrSQL) > 0 Then
            'If GFncRunSQL(GSCnSqlConn, myTrans, lcStrSQL) > 0 Then
            'myTrans.Commit()
            If canEndTrans Then
                myTrans.Commit()
            End If

            Return True
        Else
            'myTrans.Rollback()
            If canEndTrans Then
                myTrans.Rollback()
            End If
            Return False
        End If


        'Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction

        'If GFncRunSQL(GSCnSqlConn, myTrans, lcStrSQL) > 0 Then
        '    myTrans.Commit()
        '    Return True
        'Else
        '    myTrans.Rollback()
        '    Return False
        'End If
    End Function

    Protected Friend Function QueryAdjRecord(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String, ByVal pProduct As String, ByVal pLiqId As String, ByVal pPrice As String, ByVal pSearchMode As SearchMode, ByVal pCallPut As String, ByVal pStrike As String) As DataTable
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
        If pLiqId <> "-- ALL --" Then
            lcStrWhere &= "AND liq_id = '" & pLiqId & "' "
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
            lcStrTable = "newedge_cap_cp_adj"
            lcStrSQL = "SELECT adjnoid, cpnoid, Adj_Action, Adj_Remark, tdate, odate, buy, sell, monthcode, " & _
                        "product, price, liq_price, pl, settle_date, monthly_daily, contract_size, liq_id, counterparty, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput, strike FROM " & lcStrTable & " WHERE 1=1 "
            lcStrSQL &= lcStrWhere
        ElseIf pSearchMode = SearchMode.Normal Then
            lcStrTable = "newedge_cap_cp"
            lcStrSQL = "SELECT '' AS adjnoid, noid AS cpnoid, '' AS Adj_Action, '' AS Adj_Remark, tdate, odate, buy, sell, monthcode, " & _
                        "product, price, liq_price, pl, settle_date, monthly_daily, contract_size, liq_id, counterparty, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput, strike FROM " & lcStrTable & " WHERE 1=1 "
            lcStrSQL &= lcStrWhere
            lcStrSQL &= "AND noid NOT IN (SELECT cpnoid FROM newedge_cap_cp_adj)"
        ElseIf pSearchMode = SearchMode.All Then
            lcStrSQL = "SELECT * FROM ( " & _
                        "SELECT c.adjnoid, a.noid AS cpnoid, c.adj_action, c.adj_remark, " & _
                        "a.tdate, a.odate, a.buy, a.sell, a.monthcode, a.product, a.price, a.liq_price, " & _
                        "a.pl, a.settle_date, a.monthly_daily, a.contract_size, a.liq_id, a.counterparty, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput, a.strike " & _
                        "FROM vw_cap_cp a INNER JOIN newedge_cap_cp b " & _
                        "ON a.noid = b.noid " & _
                        "INNER JOIN newedge_cap_cp_adj c " & _
                        "ON b.noid = c.cpnoid " & _
                        ") AS a WHERE 1=1 " & _
                        lcStrWhere & _
                        "UNION " & _
                        "SELECT adjnoid, cpnoid, Adj_Action, Adj_Remark, tdate, odate, buy, sell, monthcode, " & _
                        "product, price, liq_price, pl, settle_date, monthly_daily, contract_size, liq_id, counterparty, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput, strike FROM newedge_cap_cp_adj WHERE adj_action <> 'M' " & _
                        lcStrWhere & _
                        "UNION " & _
                        "SELECT '' AS adjnoid, noid AS cpnoid, '' AS Adj_Action, '' AS Adj_Remark, " & _
                        "tdate, odate, buy, sell, monthcode, product, price, liq_price, " & _
                        "pl, settle_date, monthly_daily, contract_size, liq_id, counterparty, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput, strike " & _
                        "FROM newedge_cap_cp WHERE noid NOT IN (SELECT cpnoid FROM newedge_cap_cp_adj) " & _
                        lcStrWhere & _
                        "ORDER by cpnoid, adjnoid "

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

    Protected Friend Function CheckExistAdjustment(ByVal pCpNoId As String, ByVal pAdjNoId As String, _
                                    Optional ByVal pMyTrans As SqlClient.SqlTransaction = Nothing, _
                                    Optional ByVal pMyConn As SqlClient.SqlConnection = Nothing) As String
        If IsNothing(pMyConn) Then
            pMyConn = CType(GSCnSqlConn, ICloneable).Clone
            pMyConn.Open()
            pMyTrans = pMyConn.BeginTransaction
        End If
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        If pAdjNoId <> "" Then
            lcStrWhere = "AND adjnoid=" & pAdjNoId
        End If
        lcStrSQL = "SELECT * FROM newedge_cap_cp_adj WHERE cpnoid=" & pCpNoId & " AND adj_action IN ('M') " & lcStrWhere

        Dim dt As DataTable = Nothing
        dt = GFncRtnDS(pMyConn, lcStrSQL, pMyTrans).Tables(0)
        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return GFncNoNullString(dt.Rows(0).Item("adjNoId"))
        End If
        Return ""
    End Function

    Protected Friend Function IsDeletedAdjustment(ByVal pCpNoId As String, ByVal pAdjNoId As String, _
                                    Optional ByVal pMyTrans As SqlClient.SqlTransaction = Nothing, _
                                    Optional ByVal pMyConn As SqlClient.SqlConnection = Nothing) As Boolean
        If IsNothing(pMyConn) Then
            pMyConn = CType(GSCnSqlConn, ICloneable).Clone
            pMyConn.Open()
            pMyTrans = pMyConn.BeginTransaction
        End If
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        If pAdjNoId <> "" Then
            lcStrWhere = "AND adjnoid=" & pAdjNoId
        End If
        lcStrSQL = "SELECT * FROM newedge_cap_cp_adj WHERE cpnoid=" & pCpNoId & " AND adj_action IN ('D') " & lcStrWhere

        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        Dim dt As DataTable = Nothing
        dt = GFncRtnDS(pMyConn, lcStrSQL, pMyTrans).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function IsNewAddedAdjustment(ByVal pAdjNoId As String, _
                                    Optional ByVal pMyTrans As SqlClient.SqlTransaction = Nothing, _
                                    Optional ByVal pMyConn As SqlClient.SqlConnection = Nothing) As Boolean
        If IsNothing(pMyConn) Then
            pMyConn = CType(GSCnSqlConn, ICloneable).Clone
            pMyConn.Open()
            pMyTrans = pMyConn.BeginTransaction
        End If
        If pAdjNoId = "" Then
            Return False
        End If

        Dim lcStrSQL As String = ""
        lcStrSQL = "SELECT * FROM newedge_cap_cp_adj WHERE adjnoid=" & pAdjNoId & " AND adj_action IN ('A')"

        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        Dim dt As DataTable = Nothing
        dt = GFncRtnDS(pMyConn, lcStrSQL, pMyTrans).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function GetLiqId(ByVal pProduct As String, ByVal pMonthCode As String, _
                                    ByVal pTdate As Date, ByVal pCounterParty As String, _
                                    Optional ByVal pMyTrans As SqlClient.SqlTransaction = Nothing, _
                                    Optional ByVal pMyConn As SqlClient.SqlConnection = Nothing) As String
        If IsNothing(pMyConn) Then
            pMyConn = CType(GSCnSqlConn, ICloneable).Clone
            pMyConn.Open()
            pMyTrans = pMyConn.BeginTransaction
        End If
        If pProduct = "" Then
            Return ""
        Else
            Dim lcStrSQL As String = ""
            lcStrSQL = "SELECT * FROM vw_liq_header WHERE product='" & pProduct & "' AND monthcode='" & pMonthCode & "' AND " & _
                        "tdate='" & pTdate.ToString("yyyy/MM/dd") & "' AND counterparty='" & pCounterParty & "'"

            Dim dt As DataTable = Nothing
            'If IsNothing(pMyTrans) Then
            'dt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
            'Else
            dt = GFncRtnDS(pMyConn, lcStrSQL, pMyTrans).Tables(0)
            'End If

            If dt.Rows.Count <= 0 Then
                Return ""
            Else
                Return dt.Rows(0).Item("nid")
            End If
        End If
    End Function

    Protected Friend Function CreateNewLiqHeader(ByVal pLiqId As Integer, ByVal pProduct As String, ByVal pTdate As Date, ByVal pMonthCode As String, _
                                            ByVal pSettleDate As Date, ByVal pMonthlyDaily As String, ByVal pCounterParty As String, _
                                            ByVal pPL As String, ByVal pContractSize As String, pCallPut As String, pStrike As String, _
                                            Optional ByVal myTrans As SqlClient.SqlTransaction = Nothing, Optional ByVal myConn As SqlClient.SqlConnection = Nothing) As Boolean
        ''Dim lcStrSQL As String = ""
        ''Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction

        ''lcStrSQL = "INSERT INTO newedge_liq_header_adj (lhnid, Adj_Action, Adj_Remark, tdate, monthcode, settle_date, monthly_daily, product, PL, contract_size, counterparty) VALUES (" & _
        ''            "-1, 'A', 'Auto-generated for CP Adjustment', " & _
        ''            IIf(IsNothing(pTdate), "NULL", "'" & GFncNoNullDate(pTdate).ToString("yyyy/MM/dd") & "'") & ", " & _
        ''            IIf(pMonthCode = "", "NULL", "'" & pMonthCode & "'") & ", " & _
        ''            IIf(IsNothing(pSettleDate), "NULL", "'" & GFncNoNullDate(pSettleDate).ToString("yyyy/MM/dd") & "'") & ", " & _
        ''            IIf(pMonthlyDaily = "", "NULL", "'" & pMonthlyDaily & "'") & ", " & _
        ''            IIf(pProduct = "", "NULL", "'" & pProduct & "'") & ", " & _
        ''            "" & pPL & ", " & _
        ''            "" & pContractSize & ", " & _
        ''            IIf(pCounterParty = "", "NULL", "'" & pCounterParty & "'") & ")"

        ''If GFncRunSQL(GSCnSqlConn, myTrans, lcStrSQL) > 0 Then
        ''    myTrans.Commit()
        ''    Return True
        ''Else
        ''    myTrans.Rollback()
        ''    Return False
        ''End If
        If IsNothing(myConn) Then
            myConn = CType(GSCnSqlConn, ICloneable).Clone
            myConn.Open()
            myTrans = myConn.BeginTransaction
        End If

        If pPL = "" Then
            pPL = 0
        End If

        Dim lcCls As New clsFuturesStatementLHAdj
        If lcCls.InsertAdjustmentRecord(pLiqId, "A", "Auto-generated for CP Adjustment", pTdate, pMonthCode, _
                                        pProduct, pPL, pSettleDate, pMonthlyDaily, pContractSize, pCounterParty, pStrike, pCallPut, myTrans, myConn) Then
            Return True
        Else
            Return False
        End If
        Return True
    End Function

    Protected Friend Function UpdateLiqHeader(ByVal pLiqId As String, ByVal pProduct As String, ByVal pTdate As Date, ByVal pMonthCode As String, ByVal pSettleDate As Date, _
                                            ByVal pMonthlyDaily As String, ByVal pCounterParty As String, ByVal pPL As Decimal, _
                                            ByVal pContractSize As String, ByVal pStrike As String, ByVal pCallPut As String, _
                                            Optional ByVal myTrans As SqlClient.SqlTransaction = Nothing, Optional ByVal myConn As SqlClient.SqlConnection = Nothing) As Boolean
        If IsNothing(myConn) Then
            myConn = CType(GSCnSqlConn, ICloneable).Clone
            myConn.Open()
            myTrans = myConn.BeginTransaction
        End If
        Dim lcCls As New clsFuturesStatementLHAdj
        Dim lcStrSQL As String = ""

        'lcStrSQL = "SELECT * FROM newedge_liq_header_adj WHERE monthcode='" & pMonthCode & "' AND product='" & pProduct & "' AND adj_action IN ('A','M')"
        lcStrSQL = "SELECT * FROM newedge_liq_header_adj WHERE lhnid=" & pLiqId
        Dim dt As DataTable = GFncRtnDS(myConn, lcStrSQL, myTrans).Tables(0)
        If dt.Rows.Count > 0 Then
            If lcCls.UpdateAdjustmentRecord(GFncNoNullString(dt.Rows(0).Item("adjNoId")), GFncNoNullString(dt.Rows(0).Item("adj_action")), _
                           GFncNoNullString(dt.Rows(0).Item("adj_remark")), GFncNoNullDate(dt.Rows(0).Item("tdate")), GFncNoNullString(pMonthCode), _
                           GFncNoNullString(pProduct), pPL, GFncNoNullDate(pSettleDate), _
                           GFncNoNullString(pMonthlyDaily), GFncNoNullString(pContractSize), GFncNoNullString(dt.Rows(0).Item("counterparty")), GFncNoNullString(pStrike), GFncNoNullString(pCallPut), myTrans, myConn) Then
                Return True
            Else
                Return False
            End If
            'If lcCls.UpdateAdjustmentRecord(GFncNoNullString(dt.Rows(0).Item("adjNoId")), GFncNoNullString(dt.Rows(0).Item("adj_action")), _
            '    GFncNoNullString(dt.Rows(0).Item("adj_remark")), GFncNoNullDate(dt.Rows(0).Item("tdate")), GFncNoNullString(dt.Rows(0).Item("monthcode")), _
            '    GFncNoNullString(dt.Rows(0).Item("product")), pPL, GFncNoNullDate(dt.Rows(0).Item("settle_date")), _
            '    GFncNoNullString(dt.Rows(0).Item("monthly_daily")), GFncNoNullString(dt.Rows(0).Item("contract_size")), GFncNoNullString(dt.Rows(0).Item("counterparty")), myTrans, myConn) Then
            '    Return True
            'Else
            '    Return False
            'End If
        Else
            If lcCls.InsertAdjustmentRecord(pLiqId, "M", "Auto-generated for CP Adjusment", pTdate, pMonthCode, pProduct, pPL, pSettleDate, pMonthlyDaily, pContractSize, pCounterParty, pStrike, pCallPut, myTrans, myConn) Then
                Return True
            Else
                Return False
            End If

        End If

        Return True
    End Function

    Protected Friend Function GetLatestLiqId() As Integer
        Dim lcStrSQL As String = "SELECT MIN(lhnid) FROM newedge_liq_header_adj"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        If dt.Rows.Count > 0 AndAlso GFncNoNullValue(dt.Rows(0).Item(0)) <= 0 Then
            Return (GFncNoNullValue(dt.Rows(0).Item(0)) - 1)
        Else
            Return -1
        End If
    End Function

    Protected Friend Function DeleteLiqHeader(ByVal pId As Integer, Optional ByVal myTrans As SqlClient.SqlTransaction = Nothing, Optional ByVal myConn As SqlClient.SqlConnection = Nothing) As Boolean
        Dim canEndTrans As Boolean = False
        If IsNothing(myConn) Then
            myConn = CType(GSCnSqlConn, ICloneable).Clone
            myConn.Open()
            myTrans = myConn.BeginTransaction
            canEndTrans = True
        End If

        Dim lcCls As New clsFuturesStatementLHAdj
        'Dim lcStrSQL As String = "SELECT * FROM vw_liq_header WHERE nid = " & pId
        Dim lcStrSQL As String = ""

        'Dim dt As DataTable = GFncRtnDS(myConn, lcStrSQL, myTrans).Tables(0)
        'If dt.Rows.Count = 1 Then
        If pId < 0 Then
            lcStrSQL = "DELETE FROM newedge_liq_header_adj WHERE lhNid = " & pId
            If GFncRunSQL(myConn, myTrans, lcStrSQL) > 0 Then
                If canEndTrans Then
                    myTrans.Commit()
                End If
                Return True
            Else
                If canEndTrans Then
                    myTrans.Rollback()
                End If
                Return False
            End If
        Else
            lcStrSQL = "SELECT * FROM newedge_liq_header a INNER JOIN vw_cap_cp b ON a.nid=b.liq_id WHERE a.nid = " & pId
            Dim dt As DataTable = GFncRtnDS(myConn, lcStrSQL, myTrans).Tables(0)
            If dt.Rows.Count = 1 Then
                Dim lcTargetAdjNoId As String = lcCls.CheckExistAdjustment(pId, "", myTrans, myConn)

                If lcTargetAdjNoId <> "" Then
                    If lcCls.UpdateAdjustmentRecord(lcTargetAdjNoId, "D", "Auto-generated for CP Adjustment", dt.Rows(0).Item("tdate"), _
                    dt.Rows(0).Item("monthcode"), dt.Rows(0).Item("product"), dt.Rows(0).Item("pl"), dt.Rows(0).Item("settle_date"), _
                    dt.Rows(0).Item("monthly_Daily"), dt.Rows(0).Item("contract_size"), dt.Rows(0).Item("counterparty"), dt.Rows(0).Item("strike"), dt.Rows(0).Item("callput"), myTrans, myConn) Then
                        If canEndTrans Then
                            myTrans.Commit()
                        End If
                        Return True
                    Else
                        If canEndTrans Then
                            myTrans.Rollback()
                        End If
                        Return False
                    End If
                Else
                    If lcCls.InsertAdjustmentRecord(pId, "D", "Auto-generated for CP Adjustment", dt.Rows(0).Item("tdate"), _
                    dt.Rows(0).Item("monthcode"), dt.Rows(0).Item("product"), dt.Rows(0).Item("pl"), dt.Rows(0).Item("settle_date"), _
                    dt.Rows(0).Item("monthly_Daily"), dt.Rows(0).Item("contract_size"), dt.Rows(0).Item("counterparty"), dt.Rows(0).Item("strike"), dt.Rows(0).Item("callput"), myTrans, myConn) Then
                        If canEndTrans Then
                            myTrans.Commit()
                        End If
                        Return True
                    Else
                        If canEndTrans Then
                            myTrans.Rollback()
                        End If
                        Return False
                    End If
                End If
            End If
        End If
        'End If
        Return True
    End Function

    Protected Friend Function GetPLOrginalData(ByVal pNid As String) As Decimal
        If pNid = "" Then
            Return 0
        End If
        Dim lcStrSQL As String = "SELECT * FROM newedge_liq_header WHERE nid = " & pNid
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return GFncNoNullValue(dt.Rows(0).Item("pl"))
        End If
        Return 0
    End Function

    Protected Friend Function GetPLData(ByVal pNid As String) As Decimal
        If pNid = "" Then
            Return 0
        End If
        Dim lcStrSQL As String = "SELECT * FROM newedge_liq_header_adj WHERE lhNid = " & pNid
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return GFncNoNullValue(dt.Rows(0).Item("pl"))
        End If
        Return 0
    End Function

    Protected Friend Function GetOrginalData(ByVal pNoid As String) As DataTable
        Dim lcStrSQL As String = "SELECT noid, tdate, odate, buy, sell, monthcode, product, price, liq_price, PL, settle_date, monthly_daily, contract_size, liq_id, counterparty, strike, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput FROM newedge_cap_cp WHERE noId = " & pNoid
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetAdjustedData(ByVal pAdjNoid As String) As DataTable
        Dim lcStrSQL As String = "SELECT adjnoid, cpnoid, Adj_Action, Adj_Remark, tdate, odate, buy, sell, monthcode, product, price, liq_price, PL, settle_date, monthly_daily, contract_size, liq_id, counterparty, lupduser, lupddate, strike, CASE WHEN callput ='C' THEN 'Call' WHEN callput='P' THEN 'Put' ELSE '' END as callput FROM newedge_cap_cp_adj WHERE adjNoId = " & pAdjNoid
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetQryCounterParty(ByVal pTdate As Date) As DataTable
        Dim lcStrWhere As String = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "

        Dim lcStrSQL As String = "SELECT DISTINCT counterparty FROM newedge_cap_cp " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT counterparty FROM newedge_cap_cp_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY counterparty"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetQryMonthCode(ByVal pTdate As Date, ByVal pCounterParty As String) As DataTable
        Dim lcStrWhere As String = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If
        Dim lcStrSQL As String = "SELECT DISTINCT monthcode FROM newedge_cap_cp " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT monthcode FROM newedge_cap_cp_adj " & _
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
        Dim lcStrSQL As String = "SELECT DISTINCT product FROM newedge_cap_cp " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT product FROM newedge_cap_cp_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY product"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetQryLiqId(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String, ByVal pProduct As String) As DataTable
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
        Dim lcStrSQL As String = "SELECT DISTINCT liq_id FROM newedge_cap_cp " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT liq_id FROM newedge_cap_cp_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY liq_id"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetQryPrice(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String, ByVal pProduct As String, ByVal pLiqId As String) As DataTable
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
        If pLiqId <> "-- ALL --" Then
            lcStrWhere &= "AND liq_id = '" & pLiqId & "' "
        End If
        Dim lcStrSQL As String = "SELECT DISTINCT price FROM newedge_cap_cp " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT price FROM newedge_cap_cp_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY price"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function
    Protected Friend Function GetQryStrike(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String, ByVal pProduct As String, ByVal pLiqId As String) As DataTable
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
        If pLiqId <> "-- ALL --" Then
            lcStrWhere &= "AND liq_id = '" & pLiqId & "' "
        End If
        Dim lcStrSQL As String = "SELECT DISTINCT strike FROM newedge_cap_cp " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT strike FROM newedge_cap_cp_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY strike"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function
    Protected Friend Function GetQryCallPut(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pMonthCode As String, ByVal pProduct As String, ByVal pLiqId As String) As DataTable
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
        If pLiqId <> "-- ALL --" Then
            lcStrWhere &= "AND liq_id = '" & pLiqId & "' "
        End If
        Dim lcStrSQL As String = "SELECT DISTINCT callput FROM newedge_cap_cp " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "UNION SELECT DISTINCT callput FROM newedge_cap_cp_adj " & _
                                    "WHERE 1=1 " & lcStrWhere & _
                                    "ORDER BY callput"
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function
End Class
