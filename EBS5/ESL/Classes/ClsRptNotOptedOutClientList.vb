Public Class ClsRptNotOptedOutClientList
    Protected Friend Function lFnGetOptedOutClientList(ByVal targetDB As String, ByVal orderby As String) As DataSet
        Dim ds As New DataSet
        Dim lstr As String = "SELECT v.accno, v.name_1, v.name_1_c, b.name as branch_name, v.aeno, a.name as ae_name, a.email as ae_email, v.nd_addr_1,v.nd_addr_2,v.nd_addr_3,v.nd_addr_4,v.addr_1,v.addr_2,v.addr_3,v.addr_4, v.phone_1, v.phone_2, v.phone_3, v.email, v.mail_status, v.date_open, v.last_tran_date, v.suspend_field, v.date_close, c.opt_in_out_date,case c.opt_in_out when 'I'then 'Opt-in' when 'O' then 'Opt-out' else null end 'opt_in_out', c.opt_out_opening, c.update_by, c.remark FROM " & targetDB & ".dbo.view_it_client_all v inner join " & targetDB & ".dbo.ae_master a on v.aeno = a.aeno inner join " & targetDB & ".dbo.branch_master b on a.bhid = b.bhid left outer join client_opt_in_out c on v.accno = c.acc_no collate database_default where c.opt_in_out='I' or c.opt_in_out is null " & orderby

        ds = GFncRtnDS(GSCnSqlConn, lstr)
        Return ds
    End Function

    Protected Friend Function lFncExportNotOptedOutClientList(ByVal strExFile As String, ByVal targetDB As String, ByVal orderby As String) As Boolean
        Dim ds As DataSet = lFnGetOptedOutClientList(targetDB, orderby)
        Dim strTitle = "accno,name_1,name_1_c,branch_name,aeno,ae_name,ae_email,nd_addr_1,v.nd_addr_2,nd_addr_3,nd_addr_4,addr_1,addr_2,addr_3,addr_4,phone_1,phone_2, phone_3,email, mail_status, date_open, last_tran_date, suspend_field, date_close, opt_in_out_date,opt_in_out,opt_out_opening,update_by,remark"

        If Not My.Computer.FileSystem.DirectoryExists(GStrExptDir) Then
            My.Computer.FileSystem.CreateDirectory(GStrExptDir)
        End If

        Return GExportCSV(GStrExptDir, strExFile, ds, strTitle)
    End Function
End Class
