Imports System.Data.SqlClient

Public Class clsCIESAlertMaster
    Protected Friend Function getClientCode() As DataTable
        Dim strSQL As String = "select distinct(CLT_CODE) from STCLTMASTER order by CLT_CODE"

        Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        Return dt

    End Function

    Protected Friend Function lFnGetMailList() As DataSet
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select alert_seq_no, from_clt_code, to_clt_code, run_code, To_email_address, Cc_email_address, alertDate from CIES_Alert_Master"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "mail")
        Return lds

    End Function

    Protected Friend Function lFnAddEmailAddr(ByRef MyTrans As SqlTransaction, ByVal cCode_from As String, ByVal cCode_to As String, _
                                                ByVal aeno As String, ByVal email_to As String, ByVal email_cc As String, _
                                                ByVal alertDate As String) As Long

        Dim lstrSQL As String = "INSERT INTO CIES_Alert_Master " & _
                                "(from_clt_code, to_clt_code, run_code, To_email_address, Cc_email_address, lastupddate, lastupduser, alertDate) VALUES " & _
                                "('" & cCode_from & "', '" & cCode_to & "', '" & aeno & _
                                "', '" & LCase(email_to) & "', '" & LCase(email_cc) & "', GETDATE(), '" & GStrloginID & "'" & _
                                ", '" & alertDate & "')"

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnEditEmailAddr(ByRef MyTrans As SqlTransaction, ByVal eid As String, ByVal cCode_from As String, _
                                            ByVal cCode_to As String, ByVal aeno As String, ByVal email_to As String, _
                                            ByVal email_cc As String, _
                                            ByVal alertDate As String) As Long

        Dim lstrSQL As String = "update CIES_Alert_Master set from_clt_code = '" & cCode_from & "', to_clt_code = '" & cCode_to & _
                    "', run_code = '" & aeno & "', To_email_address = '" & LCase(email_to) & "', Cc_email_address = '" & LCase(email_cc) & _
                    "', lastupddate = GETDATE(), lastupduser = '" & GStrloginID & "'" & _
                    ", alertDate='" & alertDate & "' where alert_seq_no = " & eid

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFnDeleteEmailAddr(ByRef MyTrans As SqlTransaction, ByVal eid As String) As Long

        Dim lstrSQL As String = "DELETE FROM CIES_Alert_Master where alert_seq_no = " & eid
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function
End Class
