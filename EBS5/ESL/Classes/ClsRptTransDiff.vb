Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRptTransDiff
    Dim clsRpt As New ClsReports

    Protected Friend Function PrintCommRpt(ByVal inMonth As String) As ReportClass
        Dim query As String
        Dim ldtsTemp As DataSet
        Dim rpt As New RptTransAdjDiff_s

        query = "select a.oid, a.aeno as Aae, isnull(b.aeno,'') as ae,  isnull(b.txmonth, a.txmonth) as txmonth, a.accno as Aaccno, isnull(b.accno,'') as accno, a.qty as Aqty, isnull(b.qty,0) as qty," & _
                    " a.grossamt as Agrossamt, isnull(b.grossamt,0) as grossamt, a.commission as Acommission, isnull(b.commission,0) as commission, isnull(a.tdate, b.tdate) as tdate, " & _
                    " a.comm_rate as Acomm_rate, isnull(b.comm_rate,0) as comm_rate, case when a.tradetype=4 then 'Internet' else 'Normal' end Atradetype, isnull(b.tradetype,'') as  tradetype, case when a.adj_action='A' then 'New' when a.adj_action='M' then 'Modify' when a.adj_action='D' then 'Deleted' end adjaction " & _
                    " from comm_adj_s a left outer join view_comm_trade_s b on a.oid=b.oid where (a.adj_action='M' or a.adj_action='A' or a.adj_action ='D') and a.txmonth='" & inMonth & "' order by accno asc, b.tdate asc"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, query)
        rpt.SetDataSource(ldtsTemp.Tables(0))
        clsRpt.AddParam(rpt, "paraTDate", lFncGetMonthString(CInt(inMonth.Substring(4, 2))) & " " & inMonth.Substring(0, 4))
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        Return rpt
    End Function

    Protected Friend Function PrintFutRpt(ByVal inMonth As String) As ReportClass
        Dim query As String
        Dim ldtsTemp As DataSet
        Dim rpt As New RptTransAdjDiff_f
        query = "Select a.oid, isnull(b.mth,'') as mth, case when isnull(b.call_put,0)=0 then '' when isnull(b.call_put,0)=1 then 'Put' when isnull(b.call_put,0)=2 then 'Call' end as call_put," & _
                    " isnull(b.marketname,'') as marketname, isnull(b.ccy,'') as ccy, isnull(b.strike,0) as strike, a.aeno as Aae, isnull(b.aeno,'') as ae," & _
                    " a.txmonth as Atxmonth, isnull(b.txmonth, '') as txmonth, a.accno as Aaccno, isnull(b.accno,'') as accno," & _
                    " a.commod as Acommod, isnull(b.commod,0) as commod, a.day_mm as Aday_mm,  isnull(b.day_mm,0) as day_mm," & _
                    " isnull(b.night_mm,0) as night_mm, a.night_mm as Anight_mm," & _
                    " case when a.adj_action='A' then 'New' when a.adj_action='M' then 'Adjusted' when adj_action='D' then 'Deleted' end adjaction" & _
                    " from comm_adj_f a left outer join comm_trade_f b on a.oid=b.oid " & _
                    " where (a.adj_action='M' or a.adj_action='A' or a.adj_action ='D') and a.txmonth='" & inMonth & "' order by accno"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, query)
        rpt.SetDataSource(ldtsTemp.Tables(0))
        clsRpt.AddParam(rpt, "paraTDate", lFncGetMonthString(CInt(inMonth.Substring(4, 2))) & " " & inMonth.Substring(0, 4))
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        Return rpt
    End Function

    Protected Friend Function GetLatestDateComm() As Date
        Dim sql As String = " select max(tdate) as tdate from comm_adj_s "

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, sql, 0).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item("tdate")
        Else
            Return Now.Date
        End If
    End Function

    Protected Friend Sub GetLatestDateFut(ByRef inYr As String, ByRef inMon As String)
        Dim sql As String = " select max(txmonth) as txmonth from comm_adj_f "

        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, sql, 0).Tables(0)
        If dt.Rows.Count > 0 Then
            inYr = dt.Rows(0).Item("txmonth").ToString.Trim.Substring(0, 4)
            inMon = CInt(dt.Rows(0).Item("txmonth").ToString.Trim.Substring(4, 2))
        Else
            inYr = Now.Year
            inMon = Now.Month
        End If
    End Sub

End Class
