Imports System.Data.SqlClient

Public Class ClsAutoMailMain

    Protected Friend Function lFnGetMailList() As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select record_no, branch_name, branch_manager, aeno, email, attachment " & _
                  " from branch_report "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mail")
        Return lds

    End Function

    Protected Friend Function lFnAddEmailAddr(ByRef MyTrans As SqlTransaction, ByVal branchName As String, ByVal branchManager As String, _
                                                ByVal aeno As String, ByVal emailaddr As String, ByVal attachPath As String) As Long

        Dim lstrSQL As String

        lstrSQL = "insert into branch_report(branch_name, branch_manager, aeno, email, attachment, test_email) values " & _
                    "('" & branchName & "', '" & branchManager & "', '" & aeno & "', '" & LCase(emailaddr) & "', '" & attachPath & _
                    "', 'cytso@emperor.com.hk')"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnEditEmailAddr(ByRef MyTrans As SqlTransaction, ByVal eid As String, ByVal branchName As String, _
                                                ByVal branchManager As String, ByVal aeno As String, ByVal emailaddr As String, _
                                                ByVal attachPath As String) As Long

        Dim lstrSQL As String

        lstrSQL = "update branch_report set branch_name = '" & branchName & "', branch_manager = '" & branchManager & _
                    "', aeno = '" & aeno & "', email = '" & LCase(emailaddr) & "', attachment = '" & attachPath & _
                    "' where record_no = " & eid
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnDeleteEmailAddr(ByRef MyTrans As SqlTransaction, ByVal eid As String) As Long

        Dim lstrSQL As String

        lstrSQL = "DELETE FROM branch_report where record_no = " & eid
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnWriteLog(ByRef MyTrans As SqlTransaction, ByVal eid As String, ByVal aeno As String, ByVal Action As String, ByVal Log As String)
        Dim lstrSQL As String
        lstrSQL = " Insert into LogTbl (D_User, D_Date, D_Action, D_Type, D_AE, D_AC, D_O_TDate, D_OID, D_Txmonth, D_Log) values " & _
            "( '" & GStrloginID & "', GETDATE(), '" & Action & "', 'AutoMailMain', '" & aeno & "', '', '', '" & eid & "', '', '" & GFncSqlQuote(Log) & "' )"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnGetLargestID(ByVal Mytrans As SqlTransaction) As String
        Dim lstrSQL As String
        lstrSQL = " Select max(record_no) from branch_report"
        Dim DT As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL, Mytrans).Tables(0)
        Return DT.Rows(0).Item(0)
    End Function

    Protected Friend Function lfncGetMailByID(ByVal ID As String, ByVal MyTrans As SqlTransaction) As DataTable
        Dim lstrSQL As String = "Select * from branch_report where record_no = " & ID
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
    End Function
End Class
