Imports System.Data.SqlClient

Public Class ClsAutoMailStatementMain

    Protected Friend Function lFnGetMailList() As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select record_no, email, attachment, summary " & _
                  " from branch_statement "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mail")
        Return lds

    End Function

    Protected Friend Function lFnAddEmailAddr(ByRef MyTrans As SqlTransaction, ByVal emailaddr As String, ByVal attachPath As String, ByVal summary As Boolean) As Long

        Dim lstrSQL As String

        lstrSQL = "insert into branch_statement(email, attachment, summary, test_email) values " & _
                    "('" & LCase(emailaddr) & "', '" & attachPath & _
                    "', "
        If summary = True Then
            lstrSQL = lstrSQL & "1 ,'alexfungky@emperor.com.hk')"
        Else
            lstrSQL = lstrSQL & "0 ,'alexfungky@emperor.com.hk')"
        End If
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnEditEmailAddr(ByRef MyTrans As SqlTransaction, ByVal eid As String, ByVal emailaddr As String, _
                                                ByVal attachPath As String, ByVal summary As Boolean) As Long

        Dim lstrSQL As String

        lstrSQL = "update branch_statement set email = '" & LCase(emailaddr) & "', attachment = '" & attachPath & _
                    "', summary = "
        If summary = True Then
            lstrSQL = lstrSQL & "1 where record_no = " & eid
        Else
            lstrSQL = lstrSQL & "0 where record_no = " & eid
        End If
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnDeleteEmailAddr(ByRef MyTrans As SqlTransaction, ByVal eid As String) As Long

        Dim lstrSQL As String

        lstrSQL = "DELETE FROM branch_statement where record_no = " & eid
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnWriteLog(ByRef MyTrans As SqlTransaction, ByVal eid As String, ByVal Action As String, ByVal Log As String)
        Dim lstrSQL As String
        lstrSQL = " Insert into LogTbl (D_User, D_Date, D_Action, D_Type, D_AE, D_AC, D_O_TDate, D_OID, D_Txmonth, D_Log) values " & _
            "( '" & GStrloginID & "', GETDATE(), '" & Action & "', 'AutoMailStmtMain', '', '', '', '" & eid & "', '', '" & GFncSqlQuote(Log) & "' )"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnGetLargestID(ByVal Mytrans As SqlTransaction) As String
        Dim lstrSQL As String
        lstrSQL = " Select max(record_no) from branch_statement"
        Dim DT As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL, Mytrans).Tables(0)
        Return DT.Rows(0).Item(0)
    End Function

    Protected Friend Function lfncGetMailByID(ByVal ID As String, ByVal MyTrans As SqlTransaction) As DataTable
        Dim lstrSQL As String = "Select * from branch_statement where record_no = " & ID
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
    End Function
End Class
