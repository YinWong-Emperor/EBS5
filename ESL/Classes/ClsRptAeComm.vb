Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRptAeComm
    Dim clsRpt As New ClsReports

    'Protected Friend Sub GetLatestDate(ByRef year As String, ByRef month As String)
    '    Dim lstrSQL As String = " select max(txmonth) as maxmonth from comm_ae_comm"
    '    Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    '    If dt.Rows.Count > 0 Then
    '        year = CInt(dt.Rows(0).Item(0).ToString.Substring(0, 4)).ToString
    '        month = CInt(dt.Rows(0).Item(0).ToString.Substring(4, 2)).ToString
    '    Else
    '        year = Now.Year
    '        month = Now.Month - 1
    '    End If
    'End Sub


    Protected Friend Function PrintAECommRpt(ByVal txmonth As String) As ReportClass
        Dim rpt As New RptAeComm
        Dim lstrsql As String = "Select a.txmonth ,a.ae_no, b.ae_name, a.comm_s, a.comm_f, a.comm_o, a.comm_adj_f, " & _
            "a.comm_paid_f, a.comm_adj_s, a.comm_paid_s, a.override_comm, a.incentive_comm, a.bonus_comm from comm_ae_comm a " & _
            "left outer join comm_ae_master b on a.ae_no= b.ae_no where a.txmonth ='" & txmonth & "' order by a.ae_no"
        Dim GenstrSQL As String = "select top 1 luptdate, luptuser from comm_ae_comm where txmonth ='" & txmonth & "'"
        Dim GridDS As DataSet = GFncRtnDS(GSCnSqlConn, lstrsql, "rptComm_AE_comm")
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
