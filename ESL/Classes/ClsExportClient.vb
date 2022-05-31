Imports System.Data.SqlClient
Imports System.IO
Public Class ClsExportClient

    Protected Friend Function lFncExportClientStock() As Boolean

        Dim strExFile As String = "clientlist.csv"
        Dim lstrSQL As String
        Dim ldtsData As DataSet


        If (GSubShowYNConfirm("Export to " & GStrExptDir & strExFile & "?") = DialogResult.Yes) Then
            lstrSQL = "SELECT RTRIM(client_code) AS accno, RTRIM(client_name)as accname, RTRIM(ae_code) as aeno, " & _
                        "RTRIM(addr_1) as addr1, RTRIM(addr_2) as addr2, RTRIM(addr_3) as addr3, RTRIM(addr_4) as addr4, " & _
                        "RTRIM(hkid) idno, RTRIM(contact_no) tel, RTRIM(name_1_c) caccname " & _
                        "FROM " & GStrG2BSDB & ".dbo.View_client_contact_info ci, " & GStrG2BSDB & ".dbo.Client_master cm " & _
                        "WHERE ci.client_code = cm.accno"
            ldtsData = GFncRtnDS(GSCnSqlConn, lstrSQL)

            Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, AE, Addr_1, Addr_2, Addr_3, Addr_4, HK_ID, Tel, Acc_Name_C ")
        End If

    End Function

    Protected Friend Function lFncExportClientFutures() As Boolean

        Dim strExFile As String = "clientlist_futures.csv"
        Dim lstrSQL As String
        Dim ldtsData As DataSet


        If (GSubShowYNConfirm("Export to " & GStrExptDir & strExFile & "?") = DialogResult.Yes) Then

            lstrSQL = "SELECT accno, name_1, aeno, addr_1, addr_2, addr_3, replace(replace(addr_4, char(12), ''), char(13), ''), br_id, phone_1 " & _
                        "FROM " & GStrG2BFDB & ".dbo.View_it_client_all " & _
                        "WHERE RTRIM(accno) != 'EMP' ORDER BY accno "
            ldtsData = GFncRtnDS(GSCnSqlConn, lstrSQL)

            Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, AE, Addr_1, Addr_2, Addr_3, Addr_4, HK_ID, Tel ")
        End If

    End Function

    Protected Friend Function lFncExportClientStockSanction() As Boolean

        Dim strExFile As String = "ESL_aml_clientlist_" + DateTime.Now.ToString("yyyyMMdd") + ".csv"
        Dim lstrSQL As String
        Dim ldtsData As DataSet


        If (GSubShowYNConfirm("Export to " & GStrExptDir & strExFile & "?") = DialogResult.Yes) Then
            lstrSQL = "SELECT RTRIM(engbranchname) AS engbranchname, RTRIM(ci.acc_no) AS accno, RTRIM(engname) as engname, CONVERT(VARCHAR(10),RTRIM(dateopen), 101) as dateopen, RTRIM(HKID) as HKID, CONVERT(VARCHAR(10),RTRIM(doy), 101) as doy, " & _
                        "cm.nationality_1 as Nationality, RTRIM(gender) as gender, suspend_field, suspend_code, date_suspend " & _
                        "FROM " & GStrG2BSDB & ".dbo.view_s_sanction ci " & _
                        "LEFT OUTER JOIN " & GStrConDB & ".dbo.client_master cm ON cm.acc_no COLLATE DATABASE_DEFAULT=ci.acc_no AND (cm.client_type='Securities' OR cm.client_type='CIES')" & _
                        "LEFT OUTER JOIN " & GStrG2BSDB & ".dbo.view_it_client_all vica ON vica.accno = ci.acc_no"

            ldtsData = GFncRtnDS(GSCnSqlConn, lstrSQL)

            'Return GExportCSV(GStrExptDir, strExFile, ldtsData, "Securities", " " & My.Resources.Branch & ", " & My.Resources.AccountNo & ", " & My.Resources.Name & ", " & My.Resources.DateOpen & ", " & My.Resources.IDPass & ", " & My.Resources.DOB & ", " & My.Resources.Nationality & ", " & My.Resources.Gender & ", " & My.Resources.suspend_field & ", " & My.Resources.suspend_code & ", " & My.Resources.date_suspend)
            Return GExportCSV(GStrExptDir, strExFile, ldtsData, " " & My.Resources.Branch & ", " & My.Resources.AccountNo & ", " & My.Resources.Name & ", " & My.Resources.DateOpen & ", " & My.Resources.IDPass & ", " & My.Resources.DOB & ", " & My.Resources.Nationality & ", " & My.Resources.Gender & ", " & My.Resources.suspend_field & ", " & My.Resources.suspend_code & ", " & My.Resources.date_suspend)
        End If

    End Function
    Protected Friend Function lFncExportClientFuturesSanction() As Boolean

        Dim strExFile As String = "EFL_aml_clientlist_" + DateTime.Now.ToString("yyyyMMdd") + ".csv"

        Dim lstrSQL As String
        Dim ldtsData As DataSet


        If (GSubShowYNConfirm("Export to " & GStrExptDir & strExFile & "?") = DialogResult.Yes) Then
            lstrSQL = "SELECT RTRIM(engbranchname) AS engbranchname, RTRIM(ci.acc_no) AS accno, RTRIM(engname) as engname, CONVERT(VARCHAR(10),RTRIM(dateopen), 101) as dateopen, RTRIM(HKID) as HKID, CONVERT(VARCHAR(10),RTRIM(doy), 101) as doy, " & _
                        "cm.nationality_1 as Nationality, RTRIM(gender) as gender,  suspend_field, suspend_code, date_close " & _
                        "FROM " & GStrG2BFDB & ".dbo.view_f_sanction ci " & _
                        "LEFT OUTER JOIN " & GStrConDB & ".dbo.client_master cm ON cm.acc_no COLLATE DATABASE_DEFAULT=ci.acc_no AND cm.client_type='Futures'" & _
                        "LEFT OUTER JOIN " & GStrG2BFDB & ".dbo.view_it_client_all vica ON vica.accno = ci.acc_no"
            ldtsData = GFncRtnDS(GSCnSqlConn, lstrSQL)

            'Return GExportCSV(GStrExptDir, strExFile, ldtsData, "Future", " " & My.Resources.Branch & ", " & My.Resources.AccountNo & ", " & My.Resources.Name & ", " & My.Resources.DateOpen & ", " & My.Resources.IDPass & ", " & My.Resources.DOB & ", " & My.Resources.Nationality & ", " & My.Resources.Gender & ", " & My.Resources.suspend_field & ", " & My.Resources.suspend_code & ", " & My.Resources.date_close)
            Return GExportCSV(GStrExptDir, strExFile, ldtsData, " " & My.Resources.Branch & ", " & My.Resources.AccountNo & ", " & My.Resources.Name & ", " & My.Resources.DateOpen & ", " & My.Resources.IDPass & ", " & My.Resources.DOB & ", " & My.Resources.Nationality & ", " & My.Resources.Gender & ", " & My.Resources.suspend_field & ", " & My.Resources.suspend_code & ", " & My.Resources.date_close)
        End If

    End Function

    Protected Friend Function lFncExportCreditLimitStock() As Boolean

        Dim strExFile As String = "credit_limit.csv"
        Dim lstrSQL As String
        Dim ldtsData As DataSet


        If (GSubShowYNConfirm("Export to " & GStrExptDir & strExFile & "?") = DialogResult.Yes) Then

            lstrSQL = "SELECT accno, name_1, aeno, credit_lmt, date_open, date_renew, suspend_field, suspend_code " & _
                        "FROM " & GStrG2BSDB & ".dbo.view_it_client_all"
            ldtsData = GFncRtnDS(GSCnSqlConn, lstrSQL)

            Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, AE, Credit_Limit, Open_Date, Renew_Date, Suspend_Field, Suspend_Code ")
        End If

    End Function

    Protected Friend Function lFncGetDormantClient(ByVal fromDate As Date) As Boolean

        Dim strExFile As String = "client_dormant_since_" & Format(fromDate, "yyyyMMdd") & ".csv"
        Dim lstrSQL As String
        Dim ldtsData As DataSet

        If (GSubShowYNConfirm("Export to " & GStrExptDir & strExFile & "?") = DialogResult.Yes) Then
            lstrSQL = "select accno into #client_list from " & GStrG2BSDB & ".dbo.view_it_client_all " & _
                        "where accno not in (select acc collate database_default from itas_user3.dbo.itas_fmsedt " & _
                        "where dt >= '" & Format(fromDate, "yyyyMMdd") & "') and accno not in (select client_code " & _
                        "from " & GStrG2BSDB & ".dbo.view_it_client_last_trade_day " & _
                        "where lastday >= '" & Format(fromDate, "yyyyMMdd") & "') " & _
                        "and accno not in (select accno from " & GStrG2BSDB & ".dbo.view_it_client_fund " & _
                        "where last_date >= '" & Format(fromDate, "yyyyMMdd") & "') and accno not in (select accno " & _
                        "from " & GStrG2BSDB & ".dbo.view_ER_client_portfolio where onhand != 0) "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "select accno, max(last_day) as last_day into #trade " & _
                        "from (SELECT client_code as accno, lastday as last_day " & _
                        "FROM " & GStrG2BSDB & ".dbo.view_it_client_last_trade_day UNION " & _
                        "SELECT acc collate database_default, cast(dt as datetime) as lastday " & _
                        "FROM itas_user3.dbo.itas_fmsedt) as tmp group by accno"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "select #client_list.accno, #trade.last_day, cf.last_date from #client_list " & _
                        "left join #trade on #client_list.accno = #trade.accno collate database_default " & _
                        "left join " & GStrG2BSDB & ".dbo.view_it_client_fund cf " & _
                        "on #client_list.accno collate database_default = cf.accno collate database_default " & _
                        "order by #client_list.accno"
            ldtsData = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "drop table #client_list"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "drop table #trade"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Last_Trade_Date, Last_Fund_Movement ")
        Else
            Return False
        End If

    End Function

End Class
