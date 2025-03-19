Imports CrystalDecisions.CrystalReports.Engine

Public Class clsRptCommCommAdj
    Dim clsRpt As New ClsReports

    'Protected Friend Sub GetLatestDate(ByRef year As String, ByRef month As String)
    '    Dim lstrSQL As String = " select max(txmonth) as maxmonth from comm_comm_adj"
    '    Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    '    If dt.Rows.Count > 0 Then
    '        year = CInt(dt.Rows(0).Item(0).ToString.Substring(0, 4)).ToString
    '        month = CInt(dt.Rows(0).Item(0).ToString.Substring(4, 2)).ToString
    '    Else
    '        year = Now.Year
    '        month = Now.Month - 1
    '    End If
    'End Sub


    Protected Friend Function PrintCommAdjRpt(ByVal txmonth As String) As ReportClass
        Dim rpt As New RptCommCommAdj
        Dim lstrsql As String = "select a.ae_no, b.ae_name, a.adj_amt, a.reason, a.cjid, " & _
            "case a.SecFut when 'F' then 'Futures' when 'S' then 'Securities' end SecFut from comm_comm_adj a left outer join " & _
            "comm_ae_master b on a.ae_no=b.ae_no where a.txmonth ='" & txmonth & "' order by a.ae_no, a.cjid asc"
        Dim GenstrSQL As String = "select top 1 luptdate, luptuser from comm_ae_comm where txmonth ='" & txmonth & "'"
        Dim GridDS As DataSet = GFncRtnDS(GSCnSqlConn, lstrsql, "rptComm_comm_adj")
        Dim GenDS As DataSet = GFncRtnDS(GSCnSqlConn, GenstrSQL)
        rpt.SetDataSource(GridDS)
        clsRpt.AddParam(rpt, "paraTDate", txmonth)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        If GenDS.Tables(0).Rows.Count > 0 Then
            clsRpt.AddParam(rpt, "paraGenPerson", GenDS.Tables(0).Rows(0).Item("luptuser").ToString)
            clsRpt.AddParam(rpt, "paraGenTime", Format(GenDS.Tables(0).Rows(0).Item("luptdate"), "yyyy/MM/dd h:mm:ss"))
        Else
            clsRpt.AddParam(rpt, "paraGenPerson", "")
            clsRpt.AddParam(rpt, "paraGenTime", "")
        End If
        Return rpt
    End Function

End Class
