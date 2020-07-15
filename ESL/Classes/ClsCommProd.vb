Imports System.Data.SqlClient

Public Class ClsCommProd

    Protected Friend Function GetProduct(ByVal strMonth As String, Optional ByVal strQuery As String = "") As DataTable
        Dim lstrSQL As String = "Select distinct product_group from draft_comm_product_group where txmonth = '" & _
            strMonth & "' " & strQuery & " order by product_group asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetProductCode() As DataTable
        Dim lstrSQL As String = "Select * from futures_product_master order by product_code asc"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetProductGroup(ByVal strMonth As String, ByVal strQuery As String) As DataTable
        Dim lstrSQL As String = "Select a.*, b.product_name from draft_comm_product_group a left outer join " & _
            "futures_product_master b on a.product_code = b.product_code where txmonth = '" & strMonth & "' " & strQuery & _
            " order by product_group, a.product_code "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function GetLatestMonth() As String
        Dim lstrSQL As String = "Select isnull(max(txmonth),0) as txmonth from draft_comm_product_group  "
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows(0).Item(0) = 0 Then
            Return Now.Year.ToString & Format(Val(Now.Month) - 1, "00")
        Else
            Return dt.Rows(0).Item(0)
        End If
    End Function

    Protected Friend Function lfncUpd(ByVal strSQL As String, Optional ByVal logstr As String = "", Optional ByVal action As String = "", Optional ByVal month As String = "", Optional ByVal intPGid As Integer = 0) As Boolean
        If action = "N" Then
            action = "A"
        End If
        Dim lstnTrans As SqlTransaction = Nothing
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, strSQL, 0) <= 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            If logstr <> "" Then
                If Not GFncFillLog(GStrloginID, action, GDteTradeDate, "ProductGroup", "", "", intPGid, month, logstr, lstnTrans) Then
                    lstnTrans.Rollback()
                    GSubShowInfo(GFncGetSysMsg(9))
                    Return False
                End If
            End If
            lstnTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
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

    Protected Friend Function lfncUpdBatch(ByVal strMonth As String, ByVal strPG As String, ByVal dgd As DataGridView) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lstrSQL As String
        Try
            Dim logstr As String = ""
            lstnTrans = GSCnSqlConn.BeginTransaction
            lstrSQL = "delete from draft_comm_product_group where txmonth = '" & strMonth & "' and product_group = '" & strPG & "' "
            Dim resultCount As Integer = 0
            resultCount = GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0)
            If resultCount > 0 Then
                logstr = GfncOneFieldLog("Product Group", strPG.Trim)
                GFncFillLog(GStrloginID, "D", GDteTradeDate, "ProductGroup", "", "", 0, strMonth.Trim, logstr, lstnTrans)
            End If
            For lintCnt As Integer = 0 To dgd.Rows.Count - 1
                If GFncNoNullValue(dgd.Rows(lintCnt).Cells("product_flag").Value) = 1 Then
                    lstrSQL = "insert into draft_comm_product_group (txmonth, product_group, product_code) values ('" & _
                        strMonth.Trim & "','" & strPG.Trim & "','" & dgd.Rows(lintCnt).Cells("bpcode").Value.ToString.Trim & "')"
                    If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                        lstnTrans.Rollback()
                        GSubShowInfo(GFncGetSysMsg(9))
                        Return False
                    End If
                    logstr = ""
                    logstr = GfncOneFieldLog("Product Group", strPG.Trim) & " " & _
                            GfncOneFieldLog("Product Code", GFncNoNullString(dgd.Rows(lintCnt).Cells("bpcode").Value).Trim)
                    If Not GFncFillLog(GStrloginID, "A", GDteTradeDate, "ProductGroup", "", "", 0, strMonth.Trim, logstr, lstnTrans) Then
                        lstnTrans.Rollback()
                        GSubShowInfo(GFncGetSysMsg(9))
                        Return False
                    End If
                End If
            Next
            lstnTrans.Commit()
            GSubShowInfo(GFncGetSysMsg(8))
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

    Protected Friend Sub lsubInitDT(ByRef DT As DataTable)
        Dim Column As DataColumn
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "product_code"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "product_name"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "market"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Int16")
        Column.ColumnName = "product_flag"
        DT.Columns.Add(Column)
    End Sub

End Class
