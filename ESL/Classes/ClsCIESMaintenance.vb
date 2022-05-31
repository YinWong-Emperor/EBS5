Imports System.Data.SqlClient

Public Class ClsCIESMaintenance
    Dim EmailDT As DataTable

    Protected Friend Function lFnGetClientMaster() As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select a.clt_code,b.clt_name,a.plan_code,a.init_date,a.charge_rate,a.Open_deposit, a.FA_date from CIES_client_master a left join STCLTMASTER b on a.clt_code = b.CLT_CODE order by a.clt_code"
        ds = GFncRtnDS(GSCnLiqConn, lstr, "cltMaster")
        Return ds
    End Function

    Protected Friend Function lfncCheckClientCode(ByVal client_code As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select clt_name from STCLTMASTER where CLT_CODE = '" & client_code & "'"
        ds = GFncRtnDS(GSCnLiqConn, lstr, "cltMaster")
        Return ds
    End Function


    Protected Friend Function lFnEditClientMaster(ByRef MyTrans As SqlTransaction, ByVal old_client_code As String, ByVal client_code As String, ByVal plan_code As String, ByVal init_date As DateTime, ByVal charge_rate As String, ByVal open_deposit As String, ByVal fa_date As DateTime) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "update CIES_client_master set clt_code = '" & client_code & "' , plan_code = '" & plan_code & _
        "' , Charge_rate = " & charge_rate & " , Init_date = '" & Format(init_date, "yyyy/MM/dd") & _
        "', Open_deposit = " & open_deposit & " , FA_date = '" & Format(fa_date, "yyyy/MM/dd") & "'" & _
        " where clt_code = '" & old_client_code & "'"
        Return GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnAddClientMaster(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal plan_code As String, ByVal init_date As DateTime, ByVal charge_rate As String, ByVal open_deposit As String, ByVal fa_date As DateTime) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "insert into CIES_client_master values ('" & client_code & "','" & plan_code & _
        "' , '" & Format(init_date, "yyyy/MM/dd") & "'," & charge_rate & "," & open_deposit & ", '" & Format(fa_date, "yyyy/MM/dd") & "')"
        Return GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnDelClientMaster(ByRef MyTrans As SqlTransaction, ByVal client_code As String)
        Dim lstrSQL As String = ""
        lstrSQL = "delete from CIES_client_master where clt_code = '" & client_code & "'"
        Return GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnGetPlanCode() As DataTable
        Dim ds As New DataSet
        Dim lstr As String = "select misc_code from misc_master where misc_type = 'CIESPlanCode'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "plan_code")
        Return ds.Tables(0)
    End Function

    Protected Friend Function lFnWriteLog(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal Action As String, ByVal Log As String)
        Dim lstrSQL As String
        lstrSQL = " Insert into LogTbl (D_User, D_Date, D_Action, D_Type, D_AE, D_AC, D_O_TDate, D_OID, D_Txmonth, D_Log) values " & _
            "( '" & GStrloginID & "', GETDATE(), '" & Action & "', 'CIESMain', '', '', '', '', '', '" & GFncSqlQuote(Log) & "' )"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lfncGetClientMasterByClientCode(ByVal ClientCode As String, ByVal MyTrans As SqlTransaction) As DataTable
        Dim lstrSQL As String = "Select * from CIES_client_master where clt_code = '" & ClientCode & "'"
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans).Tables(0)
    End Function
    Protected Friend Function EmailRefresh() As DataTable
        Dim query As String = "Select misc_desc as Email from misc_master where misc_type='MAILALERT' and misc_code= 'CIES'"
        EmailDT = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        Return EmailDT
    End Function

    Protected Friend Function EmailDel(ByVal Address As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlDel As String = " Delete from misc_master where misc_type='MAILALERT' and  misc_code='CIES'"
        Dim sql As String = " Insert into misc_master (misc_type, misc_code, misc_desc) Values ( 'MAILALERT', 'CIES', "
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sqlDel, 0)
            For row As Integer = 0 To EmailDT.Rows.Count - 1
                If EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim <> Address.ToLower.Trim Then
                    GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim & "')", 0)
                End If
            Next

            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(13))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function EmailAdd(ByVal Address As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlDel As String = " Delete from misc_master where misc_type='MAILALERT' and  misc_code='CIES'"
        Dim sql As String = " Insert into misc_master (misc_type, misc_code, misc_desc) Values ( 'MAILALERT', 'CIES', "
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sqlDel, 0)
            For row As Integer = 0 To EmailDT.Rows.Count - 1
                GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim & "')", 0)
            Next
            GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & Address.ToLower.Trim & "')", 0)

            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function EmailAdjust(ByVal OldAddress As String, ByVal NewAddress As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim sqlDel As String = " Delete from misc_master where misc_type='MAILALERT' and  misc_code='CIES'"
        Dim sql As String = " Insert into misc_master (misc_type, misc_code, misc_desc) Values ( 'MAILALERT', 'CIES', "
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, sqlDel, 0)
            For row As Integer = 0 To EmailDT.Rows.Count - 1
                If EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim = OldAddress.ToLower.Trim Then
                    GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & NewAddress.ToLower.Trim & "')", 0)
                Else
                    GFncRunSQL(GSCnSqlConn, MyTrans, sql & "'" & EmailDT.Rows(row).Item("Email").ToString.ToLower.Trim & "')", 0)
                End If
            Next

             

            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
    End Function

End Class
