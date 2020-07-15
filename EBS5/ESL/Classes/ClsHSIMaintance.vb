Imports System.Data.SqlClient

Public Class ClsHSIMaintance
    Protected Friend Function lfncGetHSI() As DataTable

        Dim ldtsData As DataSet

        ldtsData = GFncRtnDS(GSCnSqlConn, "SELECT cast(HSI_Stock as int)as HSI_StockCode,HSI_Stock_desc,lstupddate,lstupduser from HSI_stock_master order by HSI_StockCode", 0)
        Return ldtsData.Tables(0)

    End Function

    Protected Friend Function lFncGetName(ByVal stock_code As String) As String
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        lstrSQL = "select HSI_Stock_desc from HSI_stock_master where HSI_Stock = '" & stock_code & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "name")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return lds.Tables(0).Rows(0).Item(0)
        End If
        Return ""
    End Function

    Protected Friend Function lFncGetHSI(ByVal txtStockCode As String, ByVal txtName As String) As DataTable
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        If (txtStockCode <> "") Then
            lstrSQL += " and HSI_Stock like '%" & txtStockCode & "%' "
        End If
        If (txtName <> "") Then
            lstrSQL += " and HSI_Stock_desc like '%" & txtName & "%' "
        End If
        lstrSQL = "select cast(HSI_Stock as int)as HSI_StockCode,HSI_Stock_desc,lstupddate,lstupduser from HSI_stock_master where 1=1" & lstrSQL & "order by HSI_StockCode"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "HSI")
        Return lds.Tables(0)
    End Function

    Protected Friend Function lFncDelete(ByVal stock_code As Integer, ByVal name As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lsqlstr As String = ""
        lsqlstr = "delete from HSI_Stock_Master where HSI_Stock = '" & Str(stock_code).Trim & "'"
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lsqlstr, 0) < 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(14))
                Return False
            End If
            Dim logStr As String = GfncOneFieldLog("Stock Code", Str(stock_code).Trim) & " " & GfncOneFieldLog("Name", name)
            If Not GFncFillLog(GStrloginID, "D", Nothing, "HSI_list_main", "", "", 0, "", logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
            End If
            lstnTrans.Commit()
        Catch ex As Exception
            GSubShowInfo("fail2")
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        Return True
    End Function

    Protected Friend Function lFncAdd(ByVal stock_code As Integer, ByVal name As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = "insert into HSI_stock_master (HSI_stock, HSI_stock_desc, lstupddate, lstupduser) " & _
            "values ('" & Str(stock_code).Trim & "','" & name & "',GETDATE(),'" & GStrloginID & "') "
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim logStr As String = GfncOneFieldLog("Stock Code", Str(stock_code).Trim) & " " & GfncOneFieldLog("Name", name)
            If Not GFncFillLog(GStrloginID, "A", Nothing, "HSI_list_main", "", "", 0, "", logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
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

    Protected Friend Function lFncEdit(ByVal stock_code As Integer, ByVal name As String) As Boolean
        Dim lstnTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = "update HSI_stock_master set HSI_stock_desc='" & name & "',lstupddate=GETDATE(),lstupduser='" & GStrloginID & "'where HSI_stock='" & Str(stock_code).Trim & "'"
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from HSI_stock_master where HSI_stock = '" & Str(stock_code).Trim & "'", lstnTrans).Tables(0)
            Dim oldName As String = ""
            If oldDt.Rows.Count > 0 Then
                oldName = GFncNoNullString(oldDt.Rows(0).Item("HSI_stock_desc")).Trim
            End If
            If GFncRunSQL(GSCnSqlConn, lstnTrans, lstrSQL, 0) <= 0 Then
                lstnTrans.Rollback()
                Return False
            End If
            Dim logStr As String = GfncOneFieldLog("Stock Code", Str(stock_code).Trim) & " "
            If name.Trim <> oldName Then
                logStr &= GfncOneFieldLog("Name", oldName, name) & " "
            End If
            If Not GFncFillLog(GStrloginID, "M", Nothing, "HSI_list_main", "", "", 0, "", logStr, lstnTrans) Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Return False
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

    Protected Friend Function lFncIsOverlap(ByVal stock_code as Integer) As Boolean
        Dim lstrSQL As String = ""
        Dim lds As DataSet
        lstrSQL = "select * from HSI_stock_master where HSI_stock = '" & Str(stock_code).Trim & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "HSI")
        If (lds.Tables(0).Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

End Class
