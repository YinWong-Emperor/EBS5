Imports System.Data.SqlClient

Public Class ClsDailyIPOAdj

    Protected Friend Function lFncSearch(ByVal adjYear As String, ByVal adjMonth As String, _
                                                ByVal fromClient As String, ByVal toClient As String, ByVal tables() As String) As DataSet
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_DailyIPOAdj", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "adjYear", adjYear)
            AddParameter(sqlCmd, "adjMonth", adjMonth)
            AddParameter(sqlCmd, "fromClient", fromClient)
            AddParameter(sqlCmd, "toClient", toClient)

            Return GFncRtnDSTables(sqlCmd, tables)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function lFncIsClientExist(ByVal client_code As String, ByVal adate As Date) As Boolean

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_DailyIPOAdj_CheckExist", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "clientCode", client_code)
            AddParameter(sqlCmd, "adjDate", adate)
            Dim ds As DataSet = GFncRtnDS(sqlCmd)

            If (ds.Tables(0).Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try

    End Function

    Protected Friend Function lFncAddIPOAdj(ByVal client_code As String, ByVal adate As Date, ByVal ipo As Double) As Boolean

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Ins_DailyIPOAdj", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "clientCode", client_code)
            AddParameter(sqlCmd, "adjDate", adate)
            AddParameter(sqlCmd, "IPO", ipo)

            Return GFncExecuteScalar(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try

    End Function

    Protected Friend Function lFncDeleteIPOAdj(ByVal adjID As Integer) As Boolean

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Del_DailyIPOAdj", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "adjIPOID", adjID)

            Return GFncExecuteScalar(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try

    End Function


    Protected Friend Function lFncExptIPOAdj(ByVal adjYear As String, ByVal adjMonth As String, ByVal fromClient As String, _
                                                ByVal toClient As String, ByVal tables() As String, ByVal strExFile As String) As Boolean
        Try
            Dim ldtsData As DataSet
            ldtsData = lFncSearch(adjYear, adjMonth, fromClient, toClient, tables)
            If (ldtsData.Tables.Count > 0) Then
                ldtsData.Tables(0).Columns.Remove("adjIPOID")
            End If

            Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Date, IPO ")
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try

    End Function

End Class
