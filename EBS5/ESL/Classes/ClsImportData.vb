Imports System.Data.SqlClient

Public Class ClsImportData
    Protected Friend Function FncGetProgress(ByVal group As String, ByVal stepId As Integer) As DataTable
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_ImportDataProgress", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            ' parms
            AddParameter(sqlCmd, "group", group)
            AddParameter(sqlCmd, "stepId", stepId)

            Return GFncRtnDS(sqlCmd).Tables(0)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function
    Protected Friend Function FncGetExecutingGroup() As Object
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_ImportDataExecutingGroup", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            ' parms
            'AddParameter(sqlCmd, "group", group)
            'AddParameter(sqlCmd, "stepId", stepId)

            Return GFncExecuteScalar(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function FncGetTradeData() As DataTable
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_ImportData", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        ' parms
        AddParameter(sqlCmd, "ESLLiqDB", GSCnLiqConn.Database.Trim)

        Return GFncRtnDS(sqlCmd).Tables(0)
    End Function

    Protected Friend Function FncImportData(ByVal group As String, ByVal nextTradeDate As Date) As String
        Dim newConn As SqlConnection = CType(GSCnSqlConn, ICloneable).Clone
        newConn.Open()
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Ins_ImportData", newConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            Dim timestamp As String = Format(Now, "yyyyMMddHHmmssfff")
            ' parms
            AddParameter(sqlCmd, "G2BSDB", GStrG2BSDB)
            AddParameter(sqlCmd, "G2BFDB", GStrG2BFDB)
            AddParameter(sqlCmd, "LiqDB", GSCnLiqConn.Database.Trim)
            AddParameter(sqlCmd, "BalanceDB", GSCnBalConn.Database.Trim)
            AddParameter(sqlCmd, "group", group)
            AddParameter(sqlCmd, "user", GStrloginID)
            AddParameter(sqlCmd, "nextTradeDate", nextTradeDate)
            AddParameter(sqlCmd, "timestamp", timestamp)

            Dim result As DataTable = GFncRtnDS(sqlCmd).Tables(0)
            If result Is Nothing Or result.Rows.Count <= 0 Then
                Return "Import Error!"
            Else
                Dim item As DataRow = result.Rows(0)
                If GFncNoNullIntValue(item("error")) <> 0 Then
                    Return item("message")
                Else
                    Return Nothing
                End If

            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return ex.Message
        Finally
            newConn.Close()
        End Try
    End Function

    ' 暂时没有用
    Protected Friend Function FncImportBackup(ByVal group As String) As String
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Bak_ImportData", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            Dim dbName As String = GSCnSqlConn.Database.Trim
            'Dim path As String = "c:\\data\\backup\\"
            Dim path As String = ""
            Dim fileName As String = String.Format("{0}backup_{1}_{2}.bak", path, dbName, Format(Now, "yyyyMMddHHmmssfff"))
            ' parms
            AddParameter(sqlCmd, "group", group)
            AddParameter(sqlCmd, "user", GStrloginID)
            AddParameter(sqlCmd, "DBName", GSCnSqlConn.Database.Trim)
            AddParameter(sqlCmd, "BackupFileName", fileName)

            If GFncExecuteNonQuery(sqlCmd) Then
                Return Nothing
            Else
                Return "Error"
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return ex.Message
        End Try
    End Function

    'Protected Friend Function FncDeleteProgress() As Object
    '    Try
    '        Dim sqlCmd As SqlCommand = New SqlCommand("s_Del_ImportDataProgress", GSCnSqlConn)
    '        sqlCmd.CommandType = CommandType.StoredProcedure

    '        Return GFncExecuteScalar(sqlCmd)
    '    Catch ex As Exception
    '        GSubWriteErrLog(ex.Message, "", False)
    '        Return Nothing
    '    End Try
    'End Function

End Class
