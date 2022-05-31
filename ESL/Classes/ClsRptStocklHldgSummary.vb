Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Public Class ClsRptStocklHldgSummary

    Dim clsRpt As New ClsReports

    Protected Friend Function Executed_Rpt(ByVal clientID() As String) As ReportClass

        Dim lstrSQL As String
        Dim ldtsTemp As DataSet
         Dim rpt As New RptStockHldgSummary
        'Save_Client_List(clientID)
         Dim lstrClientID As String = ""
        If clientID.Length > 0 Then
            lstrClientID = clientID(0)
            For j As Integer = 1 To clientID.Length - 1
                lstrClientID &= ", " & clientID(j)
            Next
        End If

        lstrSQL = "select stock_code as 'stock_no', name as 'stock_name', accno as 'client_id', client_name, net_onhand_qty as 'qty' " & _
        "from " & GStrG2BSPRODDB & ".dbo.view_ER_client_portfolio a " & _
        "left outer join( select distinct client_code, client_name from " & GStrG2BSPRODDB & ".dbo.view_ER_client_master ) b " & _
        "on client_code = accno left outer join " & GStrG2BSPRODDB & ".dbo.stock_master c on stock_code = stkno where net_onhand_qty<>0 and (1=0"
        
        For i As Integer = 0 To clientID.Length - 1
            lstrSQL += " or accno = '" & clientID(i) & "'"
        Next
        lstrSQL += " )"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraTitle", "Stock Holding Summary Report")
            clsRpt.AddParam(rpt, "paraClientID", Trim(lstrClientID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Stock Holding Summary Report")
        End If

    End Function

    Protected Friend Function Load_Client_List() As DataSet
        Dim ldtsTemp As DataSet
        Dim lstrSQL As String
        lstrSQL = " select distinct client_code as 'client_id' from " & GStrG2BSPRODDB & ".dbo.view_ER_client_master order by client_code"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            Return ldtsTemp
        Else
            Return Nothing
        End If
    End Function

    Protected Friend Function Load_Saved_List() As DataSet
        Dim ldtsTemp As DataSet
        Dim lstrSQL As String
        lstrSQL = " select distinct misc_code as 'client_code' from misc_master where misc_type = 'StockHldgSummary' order by misc_code"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        Return ldtsTemp
    End Function

    Protected Friend Function Save_Client_List(ByVal clientID() As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim ldtsTemp As DataSet
        Dim lstrSQL As String
        Try
            'lstnTrans = GSCnSqlConn.BeginTransaction
            lstrSQL = "select * from misc_master where misc_type = 'StockHldgSummary'"
            ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
            If ldtsTemp.Tables(0).Rows.Count > 0 Then
                lstnTrans = GSCnSqlConn.BeginTransaction
                lstrSQL = "delete from misc_master where misc_type = 'StockHldgSummary'"
                If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                    lstnTrans.Rollback()
                    Return False
                Else
                    For i As Integer = 0 To clientID.Length - 1
                        lstrSQL = "insert into misc_master (misc_type, misc_code, misc_desc) " & _
                            "values ('StockHldgSummary','" & clientID(i).Trim & "','') "
                        If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                            lstnTrans.Rollback()
                            Return False
                        End If
                    Next
                End If
            Else
                lstnTrans = GSCnSqlConn.BeginTransaction
                For i As Integer = 0 To clientID.Length - 1
                    lstrSQL = "insert into misc_master (misc_type, misc_code, misc_desc) " & _
                        "values ('StockHldgSummary','" & clientID(i).Trim & "','') "
                    If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                        lstnTrans.Rollback()
                        Return False
                    End If
                Next
            End If
            lstnTrans.Commit()
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return True
    End Function

    Protected Friend Function validate(ByVal clientID As String) As Boolean
        Dim ldtsTemp As DataSet
        Dim lstrSQL As String
        lstrSQL = " select CLT_CODE from STCLTMASTER where CLT_CODE = '" & clientID & "'"
        ldtsTemp = GFncRtnDS(GSCnLiqConn, lstrSQL, 0)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

End Class
