Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Text.RegularExpressions.Regex

Public Class ClsImportCRSAccountInfo
    Protected Friend rowIndex As Integer
    Protected Friend currClientType As String
    Protected Friend currAccNo As String
    Protected Friend dtFatcaType As DataTable
    Protected Friend dtClientType As DataTable

    Private strFuncCode As String = "ImportCRSAccountInfo"

    Protected Friend Function lFncImportData(ByVal year As Integer)
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            FrmImportCRSAccountInfo.runFnc("Importing data from G2B yearly image...")
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Import_CRSAccountInfo", GSCnSqlConn, MyTrans)
            sqlCmd.CommandType = CommandType.StoredProcedure
            AddParameter(sqlCmd, "year", year)
            GFncExecuteNonQuery(sqlCmd)

            lFncUploadActionLog(strFuncCode, strFuncCode & ": Import Data - Year=" & year, MyTrans)
            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
            End If
            GSubWriteELog("Import Data Error:" & ex.Message)
        End Try
    End Function

    Protected Friend Function lFncUploadActionLog(ByVal Action As String, ByVal ActionDetail As String, ByVal MyTrans As SqlTransaction) As Boolean

        Dim lstrSQL As String

        lstrSQL = "INSERT INTO [dbo].[ACTIONLOG] VALUES ('" & Action & "', '" & ActionDetail & "', GETDATE(), '" & GStrloginID.Replace("'", "''") & "')"

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Public Function FncGetActionLog() As String
        Dim str As String = "SELECT TOP 1 CreatedById, CreatedOn FROM ACTIONLOG WHERE [ACTION] = '" & strFuncCode & "' ORDER BY CREATEDON DESC"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        Dim result As String = ""
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            result = GFncNoNullString(ds.Tables(0).Rows(0)("CreatedById")) & " on " & GFncNoNullString(ds.Tables(0).Rows(0)("CreatedOn"))
        End If
        Return result
    End Function


End Class
