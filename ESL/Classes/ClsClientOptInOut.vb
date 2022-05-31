Imports System.Data.SqlClient

Public Class ClsClientOptInOut
    Dim EmailDT As DataTable

    Protected Friend Function lFnSearchClientMaster(ByVal accNo As String, ByVal accName As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select accno,name_1,name_1_c,branch_name,aeno,ae_name,ae_email,RTRIM(nd_addr_1)+'  '+RTRIM(nd_addr_2)+'  '+RTRIM(nd_addr_3)+'  '+RTRIM(nd_addr_4) as nd_addr_1,RTRIM(addr_1)+'  '+RTRIM(addr_2)+'  '+RTRIM(addr_3)+'  '+RTRIM(addr_4) as addr_1,phone_1,phone_2,phone_3,email,mail_status,date_open,Last_tran_date,suspend_field,date_close,opt_in_out_date,case opt_in_out when 'I'then 'Opt-in' when 'O' then 'Opt-out' else null end 'opt_in_out' from vw_client_master a left outer join client_opt_in_out b on a.accno = b.acc_no collate database_default "

        Dim condition As String = ""
        Dim isFirstCondition As Boolean = True
        If accNo <> "" Then
            If isFirstCondition Then
                lstr += "where a.accno like '%" & accNo & "%'"
                isFirstCondition = False
            End If
        End If

        If accName <> "" Then
            If isFirstCondition Then
                lstr += "where a.name_1 like '%" & accName & "%'"
                isFirstCondition = False
            Else
                lstr += "and a.name_1 like '%" & accName & "%'"
            End If
        End If


        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster")
        Return ds
    End Function

    Protected Friend Function lFnGetClientMaster() As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select accno,name_1,name_1_c,branch_name,aeno,ae_name,ae_email,RTRIM(nd_addr_1)+'  '+RTRIM(nd_addr_2)+'  '+RTRIM(nd_addr_3)+'  '+RTRIM(nd_addr_4) as nd_addr_1,RTRIM(addr_1)+'  '+RTRIM(addr_2)+'  '+RTRIM(addr_3)+'  '+RTRIM(addr_4) as addr_1,phone_1,phone_2,phone_3,email,mail_status,date_open,Last_tran_date,suspend_field,date_close,opt_in_out_date,case opt_in_out when 'I'then 'Opt-in' when 'O' then 'Opt-out' else null end 'opt_in_out' from vw_client_master a left outer join client_opt_in_out b on a.accno = b.acc_no collate database_default "
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster")
        Return ds
    End Function

    Protected Friend Function lfncCheckClientCode(ByVal client_code As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select name_1 from vw_client_master where accno = '" & client_code & "'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster")
        Return ds
    End Function

    Protected Friend Function lFnGetCleintOptIORecord(ByVal client_code As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select * from client_opt_in_out where acc_no = '" & client_code & "'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster")
        Return ds
    End Function

    Protected Friend Function lFnGetCleintOptIORecord(ByRef MyTrans As SqlTransaction, ByVal client_code As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "select * from client_opt_in_out where acc_no = '" & client_code & "'"
        ds = GFncRtnDS(GSCnSqlConn, lstr, "cltMaster", MyTrans)
        Return ds
    End Function

    Protected Friend Function lFnEditClientMaster(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal optIODate As DateTime, ByVal opt_IO As Char, ByVal opt_outOnOpening As Char, ByVal remark As String, ByVal updateBy As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL = "update client_opt_in_out set opt_in_out_date = '" & Format(optIODate, "yyyy/MM/dd") & "' , opt_in_out = '" & opt_IO & "' , opt_out_opening = '" & opt_outOnOpening & "' , remark = '" & remark & "', update_by = '" & updateBy & "' , update_date = getdate() where acc_no = '" & client_code & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnAddClientMaster(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal optIODate As DateTime, ByVal opt_IO As Char, ByVal opt_outOnOpening As Char, ByVal remark As String, ByVal updateBy As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL =
        " INSERT INTO client_opt_in_out " & _
        " ( " & _
        " 	acc_no, " & _
        " 	opt_in_out_date, " & _
        " 	opt_in_out, " & _
        " 	opt_out_opening, " & _
        " 	remark, " & _
        " 	update_by, " & _
        " 	update_date " & _
        " ) " & _
        " VALUES  " & _
        " ( " & _
        " 	  '" & client_code & "', " & _
        "     '" & Format(optIODate, "yyyy/MM/dd") & "' , " & _
        "     '" & opt_IO & "', " & _
        "     '" & opt_outOnOpening & "', " & _
        "     '" & remark & "', " & _
        "     '" & updateBy & "', " & _
        "     getdate() " & _
        " ) "
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFnDelClientMaster(ByRef MyTrans As SqlTransaction, ByVal client_code As String)
        Dim lstrSQL As String = ""
        lstrSQL = "delete from client_opt_in_out where acc_no = '" & client_code & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnWriteLog(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal Action As String, ByVal Log As String)
        Dim lstrSQL As String
        lstrSQL = " Insert into LogTbl (D_User, D_Date, D_Action, D_Type, D_AE, D_AC, D_O_TDate, D_OID, D_Txmonth, D_Log) values " & _
            "( '" & GStrloginID & "', GETDATE(), '" & Action & "', 'ClientOptInOut', '', '" & client_code & "', '', '', '', '" & GFncSqlQuote(Log) & "' )"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function getIsolatedPrefix(Optional ByVal MyTrans As SqlTransaction = Nothing) As DataTable
        Dim lstrSQL As String = ""

        lstrSQL = " SELECT CharValue as IsolatedPrefix FROM SystemStaticParam WHERE ParamType = 'OptInOut_IsolatedPrefix' "

        If MyTrans Is Nothing Then
            Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
        End If
    End Function
    Protected Friend Function lFncGetAddLinkedAccList(ByVal client_code As String, ByVal strAccPrefixFilter As String, Optional ByVal MyTrans As SqlTransaction = Nothing) As DataTable
        Dim lstrSQL As String =
        " DECLARE @AccNo as VARCHAR(10) " & _
        " SET @AccNo = '" & client_code & "' " & _
        " SELECT acc_no " & _
        " FROM " & _
        " ( " & _
        "         SELECT DISTINCT acc_no FROM " & _
        "         ( " & _
        "                 SELECT scm.accno AS acc_no " & _
        "                 FROM " & GStrG2BSPRODDB & ".dbo.client_master scm " & _
        "                 UNION ALL  " & _
        "                 SELECT fcm.accno AS acc_no " & _
        "                 FROM " & GStrG2BFPRODDB & ".dbo.client_master fcm " & _
        "         ) sfm " & _
        " ) secfut_master " & _
        " WHERE  " & _
        " RTRIM(acc_no) LIKE  " & _
        " CASE " & _
        "         WHEN LEN(@AccNo) > 7  " & _
        "         THEN '%' + SUBSTRING(@AccNo, 4, 5) " & _
        "         ELSE @AccNo " & _
        " END " & _
        " AND  " & _
        " ( " & _
        "         1=1 " & strAccPrefixFilter & " " & _
        " ) " & _
        " AND NOT EXISTS " & _
        " ( " & _
        "         SELECT 1 " & _
        "         FROM client_opt_in_out cio " & _
        "         WHERE  " & _
        "         RTRIM(acc_no) LIKE " & _
        "         CASE " & _
        "                 WHEN LEN(@AccNo) > 7  " & _
        "                 THEN '%' + SUBSTRING(@AccNo, 4, 5) " & _
        "                 ELSE @AccNo " & _
        "         END " & _
        "         AND  " & _
        "         ( " & _
        "                 1=1 " & strAccPrefixFilter & " " & _
        "         ) " & _
        "         AND secfut_master.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS = cio.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS " & _
        " ) "
        If MyTrans Is Nothing Then
            Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
        End If
    End Function
    Protected Friend Function lFncGetAddIsolatedAccList(ByVal client_code As String, Optional ByVal MyTrans As SqlTransaction = Nothing) As DataTable
        Dim lstrSQL As String =
        "DECLARE @AccNo as VARCHAR(10) " & _
        "SET @AccNo = '" & client_code & "' " & _
        "SELECT acc_no " & _
        "FROM " & _
        "( " & _
        "         SELECT DISTINCT acc_no FROM " & _
        "         ( " & _
        "                 SELECT scm.accno AS acc_no " & _
        "                 FROM " & GStrG2BSPRODDB & ".dbo.client_master scm " & _
        "                 UNION ALL  " & _
        "                 SELECT fcm.accno AS acc_no " & _
        "                 FROM " & GStrG2BFPRODDB & ".dbo.client_master fcm " & _
        "         ) sfm " & _
        ") secfut_master " & _
        "WHERE  " & _
        "RTRIM(acc_no) = @AccNo  " & _
        "AND NOT EXISTS " & _
        "( " & _
        "         SELECT 1 " & _
        "         FROM client_opt_in_out cio " & _
        "         WHERE  " & _
        "         RTRIM(acc_no) = @AccNo  " & _
        "         AND secfut_master.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS = cio.acc_no COLLATE Chinese_Taiwan_Stroke_CI_AS " & _
        ") "
        If MyTrans Is Nothing Then
            Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        Else
            Return GFncRtnDS(GSCnSqlConn, lstrSQL, MyTrans).Tables(0)
        End If
    End Function
    Protected Friend Function getAccPrefixFilter(ByVal client_code As String, Optional ByVal MyTrans As SqlTransaction = Nothing) As String
        Dim lstrSQL As String = ""
        Dim dtTemp As New DataTable()
        Dim lstrFilterSql As String = ""

        dtTemp = getIsolatedPrefix(MyTrans)

        If dtTemp.Rows.Count > 0 Then
            For Each row As DataRow In dtTemp.Rows
                lstrFilterSql += " AND <Acc> Not Like '" + row.Item("IsolatedPrefix") + "%' "
            Next
        End If

        Return lstrFilterSql.Replace("<Acc>", client_code)
    End Function
    Protected Friend Function lFnEditLinkedAcc(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal optIODate As DateTime, ByVal opt_IO As Char, ByVal opt_outOnOpening As Char, ByVal remark As String, ByVal updateBy As String, ByVal strAccPrefixFilter As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL =
        " DECLARE @AccNo AS VARCHAR(10)  " & _
        " SET @AccNo = '" & client_code & "' " & _
        " UPDATE client_opt_in_out " & _
        " SET opt_in_out_date = '" & Format(optIODate, "yyyy/MM/dd") & "' , " & _
        " opt_in_out = '" & opt_IO & "' , " & _
        " opt_out_opening = '" & opt_outOnOpening & "' , " & _
        " remark = '" & remark & "', " & _
        " update_by = '" & updateBy & "' , " & _
        " update_date = getdate() " & _
        " WHERE  " & _
        " ( " & _
        "        RTRIM(acc_no) LIKE  " & _
        "        CASE " & _
        "                        WHEN LEN(@AccNo) > 7  " & _
        "                        THEN '%' + SUBSTRING(@AccNo, 4, 5) " & _
        "                        ELSE @AccNo " & _
        "        END " & _
        "        AND  " & _
        "        ( " & _
        "                        1=1 " & strAccPrefixFilter & " " & _
        "        )  " & _
        " ) "
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
    Protected Friend Function lFnEditIsolatedAcc(ByRef MyTrans As SqlTransaction, ByVal client_code As String, ByVal optIODate As DateTime, ByVal opt_IO As Char, ByVal opt_outOnOpening As Char, ByVal remark As String, ByVal updateBy As String) As Long
        Dim lstrSQL As String = ""
        lstrSQL =
        " UPDATE client_opt_in_out " & _
        " SET opt_in_out_date = '" & Format(optIODate, "yyyy/MM/dd") & "' , " & _
        " opt_in_out = '" & opt_IO & "' , " & _
        " opt_out_opening = '" & opt_outOnOpening & "' , " & _
        " remark = '" & remark & "', " & _
        " update_by = '" & updateBy & "' , " & _
        " update_date = getdate() " & _
        "WHERE RTRIM(acc_no) = '" & client_code & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function
End Class
