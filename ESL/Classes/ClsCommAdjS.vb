Imports System.Data.SqlClient

Public Class ClsCommAdjS

    Protected Friend Function lFncSearch(ByVal adjYear As String, ByVal adjMonth As String, _
                                                ByVal fromClient As String, ByVal toClient As String, _
                                                ByVal nonZero As Boolean, ByVal tables() As String) As DataSet
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_CommssionAdjustStock", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
            AddParameter(sqlCmd, "adjYear", adjYear)
            AddParameter(sqlCmd, "adjMonth", adjMonth)
            AddParameter(sqlCmd, "fromClient", fromClient)
            AddParameter(sqlCmd, "toClient", toClient)
            AddParameter(sqlCmd, "nonZero", IIf(nonZero, 1, 0))

            Return GFncRtnDSTables(sqlCmd, tables)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function lFncAddClient(ByVal client_code As String, ByVal adjYear As String, _
                                            ByVal adjMonth As String) As Boolean
        If (adjMonth.Length = 1) Then
            adjMonth = "0" & adjMonth
        End If

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Ins_CommssionAdjustStock", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "adjYear", adjYear)
            AddParameter(sqlCmd, "adjMonth", adjMonth)
            AddParameter(sqlCmd, "clientCode", client_code)
            Return GFncExecuteScalar(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try

    End Function

    Protected Friend Function lFncSaveAdj(ByVal client_code As String, ByVal adjYear As String, _
                                          ByVal adjMonth As String, ByVal adjustment As Decimal, ByVal ipo As Decimal) As Boolean
        Try
            If (adjMonth.Length = 1) Then
                adjMonth = "0" & adjMonth
            End If

            Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_CommssionAdjustStock", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB.Trim)
            AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
            AddParameter(sqlCmd, "adjYear", adjYear)
            AddParameter(sqlCmd, "adjMonth", adjMonth)
            AddParameter(sqlCmd, "clientCode", client_code)
            AddParameter(sqlCmd, "adjustment", adjustment)
            AddParameter(sqlCmd, "ipo", ipo)
            Return GFncExecuteScalar(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try

    End Function

    Protected Friend Function lFncIsClientExist(ByVal client_code As String, ByVal adjYear As String, _
                                                ByVal adjMonth As String) As Boolean
        Try
            Dim tableNames As String() = New String(1) {"liqdb", "local"}
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_CommssionAdjustStock_CheckExist", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
            AddParameter(sqlCmd, "adjYear", adjYear)
            AddParameter(sqlCmd, "adjMonth", adjMonth)
            AddParameter(sqlCmd, "clientCode", client_code)
            Dim ds As DataSet = GFncRtnDSTables(sqlCmd, tableNames)

            If (ds.Tables(0).Rows.Count > 0 Or ds.Tables(1).Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try
    End Function

    Protected Friend Function lFncIsClientCodeExist(ByVal client_code As String) As Boolean
        Dim ccCls As New ClsClientCodes
        Return ccCls.FncIsClientCodeExist(client_code)
    End Function

    Protected Friend Function lFncExptCommAdj(ByVal ldtsData As DataSet, ByVal strExFile As String) As Boolean
        Try
            Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, Month, Comm, Adj, IPO, Total ")
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try
    End Function

End Class
