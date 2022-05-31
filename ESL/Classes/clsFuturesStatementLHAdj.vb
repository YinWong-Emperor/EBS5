Public Class clsFuturesStatementLHAdj

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
        Dim lcStrSQL As String = "Select distinct product From newedge_liq_header UNION Select distinct product From newedge_liq_header_adj"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function

    Protected Friend Function InsertAdjustmentRecord(ByVal pNoId As String, ByVal pAdjAction As String, ByVal pAdjRemark As String, ByVal pTdate As Object, _
                                            ByVal pMonthCode As String, ByVal pProduct As String, ByVal pPL As String, _
                                            ByVal pSettleDate As Object, ByVal pMonthlyDaily As String, ByVal pContractSize As String, _
                                            ByVal pCounterParty As String, ByVal pStrike As String, ByVal pCallPut As String, Optional ByVal myTrans As SqlClient.SqlTransaction = Nothing, Optional ByVal myConn As SqlClient.SqlConnection = Nothing) As Boolean
        Dim canEndTrans As Boolean = False
        Dim lcStrSQL As String = ""
        If IsNothing(myConn) Then
            myConn = CType(GSCnSqlConn, ICloneable).Clone
            myConn.Open()
            myTrans = myConn.BeginTransaction
            canEndTrans = True
        End If
        'Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction
        lcStrSQL = "INSERT INTO newedge_liq_header_adj (lhnid, Adj_Action, Adj_Remark, tdate, monthcode, " & _
                    "product, pl, settle_date, monthly_daily, contract_size, counterparty, strike, callput, lupduser, lupddate) VALUES (" & _
                    IIf(pNoId = "", "NULL", pNoId) & ", " & _
                    IIf(pAdjAction = "", "NULL", "'" & pAdjAction & "'") & ", " & _
                    IIf(pAdjRemark = "", "NULL", "'" & pAdjRemark & "'") & ", " & _
                    IIf(IsNothing(pTdate), "NULL", "'" & GFncNoNullDate(pTdate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    IIf(pMonthCode = "", "NULL", "'" & pMonthCode & "'") & ", " & _
                    IIf(pProduct = "", "NULL", "'" & pProduct & "'") & ", " & _
                    IIf(pPL = "", "NULL", pPL) & ", " & _
                    IIf(IsNothing(pSettleDate), "NULL", "'" & GFncNoNullDate(pSettleDate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    IIf(pMonthlyDaily = "", "NULL", "'" & pMonthlyDaily & "'") & ", " & _
                    IIf(pContractSize = "" OrElse pContractSize = "0", "NULL", "" & pContractSize & "") & ", " & _
                    IIf(pCounterParty = "", "NULL", "'" & pCounterParty & "'") & ", " & _
                    IIf(pStrike = "", "NULL", "" & pStrike & "") & ", " & _
                    IIf(pCallPut = "", "NULL", "'" & pCallPut & "'") & ", " & _
                    "'" & GStrloginID & "'" & ", GETDATE())"

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

    Protected Friend Function UpdateAdjustmentRecord(ByVal pAdjNoId As String, ByVal pAdjAction As String, ByVal pAdjRemark As String, ByVal pTdate As Object, _
                                            ByVal pMonthCode As String, ByVal pProduct As String, ByVal pPL As String, _
                                            ByVal pSettleDate As Object, ByVal pMonthlyDaily As String, ByVal pContractSize As String, _
                                            ByVal pCounterParty As String, ByVal pStrike As String, ByVal pCallPut As String, Optional ByVal myTrans As SqlClient.SqlTransaction = Nothing, Optional ByVal myConn As SqlClient.SqlConnection = Nothing) As Boolean
        Dim canEndTrans As Boolean = False
        Dim lcStrSQL As String = ""
        If IsNothing(myConn) Then
            myConn = CType(GSCnSqlConn, ICloneable).Clone
            myConn.Open()
            myTrans = myConn.BeginTransaction
            canEndTrans = True
        End If
        'Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction

        lcStrSQL = "UPDATE newedge_liq_header_adj SET " & _
                    "Adj_Action = " & IIf(pAdjAction = "", "NULL", "'" & pAdjAction & "'") & ", " & _
                    "Adj_Remark = " & IIf(pAdjRemark = "", "NULL", "'" & pAdjRemark & "'") & ", " & _
                    "tdate = " & IIf(IsNothing(pTdate), "NULL", "'" & GFncNoNullDate(pTdate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    "monthcode = " & IIf(pMonthCode = "", "NULL", "'" & pMonthCode & "'") & ", " & _
                    "product = " & IIf(pProduct = "", "NULL", "'" & pProduct & "'") & ", " & _
                    "pl = " & IIf(pPL = "", "NULL", pPL) & ", " & _
                    "settle_date = " & IIf(IsNothing(pSettleDate), "NULL", "'" & GFncNoNullDate(pSettleDate).ToString("yyyy/MM/dd") & "'") & ", " & _
                    "monthly_daily = " & IIf(pMonthlyDaily = "", "NULL", "'" & pMonthlyDaily & "'") & ", " & _
                    "contract_size = " & IIf(pContractSize = "", "NULL", "" & pContractSize & "") & ", " & _
                    "counterparty = " & IIf(pCounterParty = "", "NULL", "'" & pCounterParty & "'") & ", " & _
                    "callput = '" & pCallPut & "' , " & _
                    "strike = " & IIf(pStrike = "", "NULL", pStrike) & " " & _
                    "lupduser = '" & GStrloginID & "', " & _
                    "lupddate = " & "GETDATE()" & " " & _
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
        'Dim myTrans As SqlClient.SqlTransaction = GSCnSqlConn.BeginTransaction
        lcStrSQL = "DELETE FROM newedge_liq_header_adj WHERE adjnoid=" & pAdjNoId

        'If GFncRunSQL(GSCnSqlConn, myTrans, lcStrSQL) > 0 Then
        '    myTrans.Commit()
        '    Return True
        'Else
        '    myTrans.Rollback()
        '    Return False
        'End If
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

    Protected Friend Function QueryAdjRecord(ByVal pTdate As Date, ByVal pCounterParty As String, ByVal pSearchMode As SearchMode) As DataTable
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        Dim lcStrTable As String = ""

        lcStrWhere = "AND tdate = '" & pTdate.ToString("yyyy/MM/dd") & "' "
        If pCounterParty <> "-- ALL --" Then
            lcStrWhere &= "AND counterparty = '" & pCounterParty & "' "
        End If

        If pSearchMode = SearchMode.Adjusted Then
            lcStrTable = "newedge_liq_header_adj"
            lcStrSQL = "SELECT adjnoid, lhnid, Adj_Action, Adj_Remark, tdate, monthcode, " & _
                        "product, pl, settle_date, monthly_daily, contract_size, counterparty FROM " & lcStrTable & " WHERE 1=1 "
            lcStrSQL &= lcStrWhere
        ElseIf pSearchMode = SearchMode.Normal Then
            lcStrTable = "newedge_liq_header"
            lcStrSQL = "SELECT '' AS adjnoid, nid AS lhnid, '' AS Adj_Action, '' AS Adj_Remark, tdate, monthcode, " & _
                        "product, pl, settle_date, monthly_daily, contract_size, counterparty FROM " & lcStrTable & " WHERE 1=1 "
            lcStrSQL &= lcStrWhere
            lcStrSQL &= "AND nid NOT IN (SELECT lhnid FROM newedge_liq_header_adj)"
        ElseIf pSearchMode = SearchMode.All Then
            lcStrSQL = "SELECT * FROM ( " & _
                        "SELECT c.adjnoid, a.nid AS lhnid, c.adj_action, c.adj_remark, " & _
                        "a.tdate, a.monthcode, a.product, " & _
                        "a.pl, a.settle_date, a.monthly_daily, a.contract_size, a.counterparty " & _
                        "FROM vw_liq_header a INNER JOIN newedge_liq_header b " & _
                        "ON a.nid = b.nid " & _
                        "INNER JOIN newedge_liq_header_adj c " & _
                        "ON b.nid = c.lhnid " & _
                        ") AS a WHERE 1=1 " & _
                        lcStrWhere & _
                        "UNION " & _
                        "SELECT adjnoid, lhnid, Adj_Action, Adj_Remark, tdate, monthcode, product, pl, settle_date, monthly_daily, contract_size, counterparty FROM newedge_liq_header_adj WHERE adj_action <> 'M' " & _
                        lcStrWhere & _
                        "UNION " & _
                        "SELECT '' AS adjnoid, nid AS lhnid, '' AS Adj_Action, '' AS Adj_Remark, " & _
                        "tdate, monthcode, product, " & _
                        "pl, settle_date, monthly_daily, contract_size, counterparty " & _
                        "FROM newedge_liq_header WHERE nid NOT IN (SELECT lhnid FROM newedge_liq_header_adj) " & _
                        lcStrWhere & _
                        "ORDER by lhnid, adjnoid "

            End If

        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

    End Function

    Protected Friend Function CheckExistAdjustment(ByVal pLhNoId As String, ByVal pAdjNoId As String, Optional ByVal myTrans As SqlClient.SqlTransaction = Nothing, Optional ByVal myConn As SqlClient.SqlConnection = Nothing) As String
        If IsNothing(myConn) Then
            myConn = CType(GSCnSqlConn, ICloneable).Clone
            myConn.Open()
            myTrans = myConn.BeginTransaction
        End If
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        If pAdjNoId <> "" Then
            lcStrWhere = "AND adjnoid=" & pAdjNoId
        End If
        lcStrSQL = "SELECT * FROM newedge_liq_header_adj WHERE lhnid=" & pLhNoId & " AND adj_action IN ('M') " & lcStrWhere

        Dim dt As DataTable = GFncRtnDS(myConn, lcStrSQL, myTrans).Tables(0)
        If dt.Rows.Count > 0 Then
            Return GFncNoNullString(dt.Rows(0).Item("adjNoId"))
        End If
        Return ""
    End Function

    Protected Friend Function IsDeletedAdjustment(ByVal pLhNoId As String, ByVal pAdjNoId As String) As Boolean
        Dim lcStrWhere As String = ""
        Dim lcStrSQL As String = ""
        If pAdjNoId <> "" Then
            lcStrWhere = "AND adjnoid=" & pAdjNoId
        End If
        lcStrSQL = "SELECT * FROM newedge_liq_header_adj WHERE lhnid=" & pLhNoId & " AND adj_action IN ('D') " & lcStrWhere

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
        lcStrSQL = "SELECT * FROM newedge_liq_header_adj WHERE adjnoid=" & pAdjNoId & " AND adj_action IN ('A')"

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function GetOrginalData(ByVal pNoid As String) As DataTable
        Dim lcStrSQL As String = "SELECT * FROM newedge_liq_header WHERE nid = " & pNoid
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

    Protected Friend Function GetAdjustedData(ByVal pAdjNoid As String) As DataTable
        Dim lcStrSQL As String = "SELECT * FROM newedge_liq_header_adj WHERE adjNoId = " & pAdjNoid
        Return GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
    End Function

End Class
