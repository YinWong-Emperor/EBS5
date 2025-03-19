Imports CrystalDecisions.CrystalReports.Engine



Public Class ClsRptCommScheme

    Public sortTeam As Integer = 1
    Public sortAENo As Integer = 2
    Public sortAENameS As Integer = 3
    Public sortAENameF As Integer = 4

    Dim clsRpt As New ClsReports


    Protected Friend Sub GetLatestDate(ByRef year As String, ByRef month As String)
        Dim lstrSQL As String = " select max(txmonth) as maxmonth from comm_ae_master_d"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
        If dt.Rows.Count > 0 Then
            year = CInt(dt.Rows(0).Item(0).ToString.Substring(0, 4)).ToString
            month = CInt(dt.Rows(0).Item(0).ToString.Substring(4, 2)).ToString
        Else
            year = Now.Year
            month = Now.Month - 1
        End If
    End Sub

    Protected Friend Function PrintCommSchemeRpt(ByVal txmonth As String, ByVal sortBy As Integer) As ReportClass
        Dim rpt As New ReportClass
        Dim lstrsql As String = ""
        Dim ldsAE As DataSet = Nothing
        Dim ldsRateS As DataSet = Nothing
        Dim ldsRateF As DataSet = Nothing
        'get securities account
        lstrsql = "select team, ae_no, man_no_s, man_group_s, isDefault_s into #ae_s " & _
                    "from comm_ae_master_d where txmonth = '" & txmonth & "' and isCommission_s = 1"
        GFncRunSQL(GSCnSqlConn, lstrsql, 0)
        'get futures account
        lstrsql = "select team, ae_no, man_no_f, man_group_f, isDefault_f into #ae_f " & _
                    "from comm_ae_master_d where txmonth = '" & txmonth & "' and isCommission_f = 1"
        GFncRunSQL(GSCnSqlConn, lstrsql, 0)
        If (sortBy = sortTeam) Then
            rpt = New RptCommSchemeAE
            'get join AE list
            lstrsql = "select isnull(a.team, b.team) as team, isnull(a.man_no_s, b.man_no_f) as man_no, " & _
                        "isnull(man_group_s, man_group_f) as man_group,  c.ae_no, c.ae_name_s, c.ae_name_f, " & _
                        "case when isDefault_s = 1 then 'Standard' when isDefault_s = 0 then 'get table' else '-' end as default_s, " & _
                        "case when isDefault_f = 1 then 'Standard' when isDefault_f = 0 then 'get table' else '-' end as default_f " & _
                        "from #ae_s a full join #ae_f b on a.team = b.team and a.man_no_s = b.man_no_f " & _
                        "and man_group_s = b.man_group_f and a.ae_no = b.ae_no " & _
                        "left join comm_ae_master c on  isnull(a.ae_no, b.ae_no) = c.ae_no " & _
                        "order by isnull(a.team, b.team), c.ae_no "
        Else
            rpt = New RptCommSchemeAE2
            'get join AE list
            lstrsql = "select isnull(a.team, b.team) as team, isnull(a.man_no_s, b.man_no_f) as man_no, " & _
                        "isnull(man_group_s, man_group_f) as man_group,  c.ae_no, c.ae_name_s, c.ae_name_f, " & _
                        "case when isDefault_s = 1 then 'Standard' when isDefault_s = 0 then 'get table' else '-' end as default_s, " & _
                        "case when isDefault_f = 1 then 'Standard' when isDefault_f = 0 then 'get table' else '-' end as default_f " & _
                        "from #ae_s a full join #ae_f b on a.team = b.team and a.man_no_s = b.man_no_f " & _
                        "and man_group_s = b.man_group_f and a.ae_no = b.ae_no " & _
                        "left join comm_ae_master c on  isnull(a.ae_no, b.ae_no) = c.ae_no "
            If (sortBy = sortAENo) Then
                lstrsql = lstrsql & "order by c.ae_no "
            ElseIf (sortBy = sortAENameS) Then
                lstrsql = lstrsql & "order by c.ae_name_s "
            ElseIf (sortBy = sortAENameF) Then
                lstrsql = lstrsql & "order by c.ae_name_f "
            End If
        End If
        ldsAE = GFncRtnDS(GSCnSqlConn, lstrsql, 0)
        'get securities rate
        lstrsql = "select a.ae_no, a.acc_group, a.acc_no, a.comm_type, a.rate_type, a.turnover_from, " & _
                    "min(b.turnover_from) as turnover_to, a.comm_rate, a.brokerage_rate " & _
                    "from comm_rate_s a " & _
                    "left join comm_rate_s b on a.comm_month = b.comm_month and a.comm_type = b.comm_type " & _
                    "and a.ae_no = b.ae_no and a.acc_group = b.acc_group and a.acc_no = b.acc_no " & _
                    "and a.rate_type = b.rate_type and a.turnover_from < b.turnover_from " & _
                    "where a.comm_month = '" & txmonth & "' and a.rate_type in ('CON', 'INT', 'NOR') " & _
                    "group by a.ae_no, a.acc_group, a.acc_no, a.comm_type, a.rate_type, a.turnover_from, " & _
                    "a.comm_rate, a.brokerage_rate " & _
                    "order by a.ae_no, a.acc_group, a.acc_no, a.comm_type, a.turnover_from "
        ldsRateS = GFncRtnDS(GSCnSqlConn, lstrsql, 0)
        lstrsql = "select a.ae_no, a.acc_group, a.acc_no, a.product_group, a.comm_type, a.rate_type, " & _
                    "a.turnover_from, min(b.turnover_from) as turnover_to, a.comm_rate, a.brok_per_lot " & _
                    "from comm_rate_f a left join comm_rate_f b on a.comm_month = b.comm_month " & _
                    "and a.product_group = b.product_group and a.comm_type = b.comm_type " & _
                    "and a.ae_no = b.ae_no and a.acc_group = b.acc_group and a.acc_no = b.acc_no " & _
                    "and a.rate_type = b.rate_type and a.turnover_from < b.turnover_from " & _
                    "where a.comm_month = '" & txmonth & "' " & _
                    "group by a.ae_no, a.acc_group, a.acc_no, a.product_group, a.comm_type, a.rate_type, " & _
                    "a.turnover_from, a.comm_rate, a.brok_per_lot " & _
                    "order by a.ae_no, a.acc_group, a.acc_no, a.product_group, a.comm_type, a.turnover_from  "
        ldsRateF = GFncRtnDS(GSCnSqlConn, lstrsql, 0)
        lstrsql = "drop table #ae_s "
        GFncRunSQL(GSCnSqlConn, lstrsql, 0)
        lstrsql = "drop table #ae_f "
        GFncRunSQL(GSCnSqlConn, lstrsql, 0)
        rpt.SetDataSource(ldsAE.Tables(0))
        rpt.Subreports(1).SetDataSource(ldsRateS.Tables(0))
        rpt.Subreports(0).SetDataSource(ldsRateF.Tables(0))
        clsRpt.AddParam(rpt, "paraTDate", txmonth)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        Return rpt
    End Function

End Class
