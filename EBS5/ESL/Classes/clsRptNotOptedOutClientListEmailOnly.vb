Public Class clsRptNotOptedOutClientListEmailOnly
    Protected Friend Function lFnGetOptedOutClientList(ByVal targetDB1 As String, ByVal targetDB2 As String) As DataSet
        Dim ds As New DataSet
        'Dim lstr As String = "SELECT v.accno, v.name_1, v.name_1_c, b.name as branch_name, v.aeno, a.name as ae_name, a.email as ae_email, v.nd_addr_1,v.nd_addr_2,v.nd_addr_3,v.nd_addr_4,v.addr_1,v.addr_2,v.addr_3,v.addr_4, v.phone_1, v.phone_2, v.phone_3, v.email, v.mail_status, v.date_open, v.last_tran_date, v.suspend_field, v.date_close, c.opt_in_out_date,case c.opt_in_out when 'I'then 'Opt-in' when 'O' then 'Opt-out' else null end 'opt_in_out', c.opt_out_opening, c.update_by, c.remark FROM " & targetDB & ".dbo.view_it_client_all v inner join " & targetDB & ".dbo.ae_master a on v.aeno = a.aeno inner join " & targetDB & ".dbo.branch_master b on a.bhid = b.bhid left outer join client_opt_in_out c on v.accno = c.acc_no collate database_default where c.opt_in_out='I' or c.opt_in_out is null "
        Dim lstr As String = ""
        lstr = lstr & "SELECT distinct v.email FROM " & targetDB1 & ".dbo.view_it_client_all v inner join " & targetDB1 & ".dbo.ae_master a on v.aeno = a.aeno inner join " & targetDB1 & ".dbo.branch_master b on a.bhid = b.bhid left outer join client_opt_in_out c on v.accno = c.acc_no collate database_default where (c.opt_in_out='I' or c.opt_in_out is null) and v.email <> '' "
        lstr = lstr & "UNION "
        lstr = lstr & "SELECT distinct v.email FROM " & targetDB2 & ".dbo.view_it_client_all v inner join " & targetDB2 & ".dbo.ae_master a on v.aeno = a.aeno inner join " & targetDB2 & ".dbo.branch_master b on a.bhid = b.bhid left outer join client_opt_in_out c on v.accno = c.acc_no collate database_default where (c.opt_in_out='I' or c.opt_in_out is null) and v.email <> '' "

        ds = GFncRtnDS(GSCnSqlConn, lstr)
        Return ds
    End Function

    Protected Friend Function lFncExportNotOptedOutClientList(ByVal strExFile As String, ByVal targetDB1 As String, ByVal targetDB2 As String) As Boolean
        Dim ds As DataSet = lFnGetOptedOutClientList(targetDB1, targetDB2)
        Dim strTitle = ""

        If Not My.Computer.FileSystem.DirectoryExists(GStrExptDir) Then
            My.Computer.FileSystem.CreateDirectory(GStrExptDir)
        End If

        Return GExportCSV(GStrExptDir, strExFile, ds, strTitle)
    End Function
End Class
