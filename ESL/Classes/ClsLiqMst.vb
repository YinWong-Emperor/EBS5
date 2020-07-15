Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsLiqMst

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncGetRunner() As DataSet
        Dim lstrSQL As String

        lstrSQL = "SELECT DISTINCT stcltmaster.run_code FROM stcltmaster, stcltliq " & _
                " WHERE stcltmaster.clt_code = stcltliq.clt_code " & _
                " and stcltliq.liq_day > 0 ORDER BY stcltmaster.run_code"

        Return GFncRtnDS(GSCnLiqConn, lstrSQL)

    End Function

    Protected Friend Function lFncGetDetail(ByVal lstrType As String) As DataSet
        Dim lstrSQL As String = ""

        lstrSQL = "SELECT mst.run_code, mst.clt_code, mst.mc_dr_bal, mst.mkt_value,  " & _
            " str(mst.mc_act_ratio, 10, 2) + ' %' as aratio, str(mst.margin_ratio, 10, 2) + ' %' as mratio, " & _
            " mst.mc_due, mst.mc_t2, " & _
            " mst.mc_total, mst.os_day, mst.net_trade, mst.cr_limit,  " & _
            " mst.clt_name " & _
            " FROM stcltmaster mst, stcltliq liq " & _
            " where mst.clt_code = liq.clt_code " & _
            " AND liq.liq_day > 0 "

        If lstrType <> "" Then
            lstrSQL += " and mst.clt_type = '" & lstrType & "' "
        Else
            lstrSQL += " and mst.clt_type in ('M', 'F', 'C') "
        End If

        lstrSQL += " ORDER BY mst.clt_code "

        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "Detail")

    End Function
    Protected Friend Function lFncGetFBDetail(ByVal lstrType As String) As DataSet
        Dim lstrSQL As String = ""

        lstrSQL = "SELECT mst.run_code, mst.clt_code, mst.mc_dr_bal, mst.mkt_value,  " & _
            " str(mst.mc_act_ratio, 10, 2) + ' %' as aratio, str(mst.margin_ratio, 10, 2) + ' %' as mratio, " & _
            " mst.mc_due, mst.mc_t2, " & _
            " mst.mc_total, mst.os_day, mst.net_trade, mst.cr_limit,  " & _
            " mst.clt_name " & _
            " FROM stcltmaster mst, stcltliqfb liq " & _
            " where mst.clt_code = liq.clt_code " & _
            " AND liq.liq_day > 0 "

        If lstrType <> "" Then
            lstrSQL += " and mst.clt_type = '" & lstrType & "' "
        Else
            lstrSQL += " and mst.clt_type in ('M', 'F', 'C') "
        End If

        lstrSQL += " ORDER BY mst.clt_code "

        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "Detail")

    End Function

    Protected Friend Function lFncGetDetailData(ByVal lstrType As String) As DataSet
        Dim lstrSQL As String = ""

        lstrSQL = "SELECT mst.* " & _
            " FROM stcltmaster mst, stcltliq liq " & _
            " where mst.clt_code = liq.clt_code " & _
            " AND liq.liq_day > 0 "

        If lstrType <> "" Then
            lstrSQL += " and mst.clt_type = '" & lstrType & "' "
        Else
            lstrSQL += " and mst.clt_type in ('M', 'F', 'C') "
        End If

        lstrSQL += " ORDER BY mst.clt_code "

        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "Detail")

    End Function
    Protected Friend Function lFncGetFBDetailData(ByVal lstrType As String) As DataSet
        Dim lstrSQL As String = ""

        lstrSQL = "SELECT mst.* " & _
            " FROM stcltmaster mst, stcltliqfb liq " & _
            " where mst.clt_code = liq.clt_code " & _
            " AND liq.liq_day > 0 "

        If lstrType <> "" Then
            lstrSQL += " and mst.clt_type = '" & lstrType & "' "
        Else
            lstrSQL += " and mst.clt_type in ('M', 'F', 'C') "
        End If

        lstrSQL += " ORDER BY mst.clt_code "

        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "Detail")

    End Function
    Protected Friend Function lFncGetTotal(ByVal lstrtype) As DataSet
        Dim lstrSQL As String

        lstrSQL = "SELECT 'Total' as ttl_desc, count(*) as ttl_rec, " & _
            " sum(mst.mc_dr_bal) as s_mc_dr_bal, sum(mst.mkt_value) as s_mkt_value,  " & _
            "  sum(mst.mc_due) as s_mc_due, sum(mst.mc_t2) as s_mc_t2, " & _
            " sum(mst.mc_total) as s_mc_total, sum(mst.net_trade) as s_net_trade " & _
            " FROM stcltmaster mst, stcltliq liq " & _
            " where mst.clt_code = liq.clt_code " & _
            " AND liq.liq_day > 0 "

        If lstrtype <> "" Then
            lstrSQL += " and mst.clt_type = '" & lstrtype & "' "
        Else
            lstrSQL += " and mst.clt_type in ('M', 'F', 'C') "
        End If


        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "Total")

    End Function
    Protected Friend Function lFncGetFBTotal(ByVal lstrtype) As DataSet
        Dim lstrSQL As String

        lstrSQL = "SELECT 'Total' as ttl_desc, count(*) as ttl_rec, " & _
            " sum(mst.mc_dr_bal) as s_mc_dr_bal, sum(mst.mkt_value) as s_mkt_value,  " & _
            "  sum(mst.mc_due) as s_mc_due, sum(mst.mc_t2) as s_mc_t2, " & _
            " sum(mst.mc_total) as s_mc_total, sum(mst.net_trade) as s_net_trade " & _
            " FROM stcltmaster mst, stcltliqfb liq " & _
            " where mst.clt_code = liq.clt_code " & _
            " AND liq.liq_day > 0 "

        If lstrtype <> "" Then
            lstrSQL += " and mst.clt_type = '" & lstrtype & "' "
        Else
            lstrSQL += " and mst.clt_type in ('M', 'F', 'C') "
        End If


        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "Total")

    End Function
    Protected Friend Function lFncPrintAccLst(ByVal lstrQuery As String, _
     ByVal lstrTitle As String) As ReportClass
        Dim rpt As New RptLiqLst
        Dim ldtsTemp As DataSet
        Dim lstrCrit As String = ""
        Dim lstrSQL As String = ""

        lstrSQL = "SELECT  *,case when liq.liq_day is null then 0 else liq.liq_day end liq_day " & _
                " FROM stcltmaster mst inner JOIN  stcltliq liq ON  mst.clt_code = liq.clt_code " & _
                " and liq.liq_day > 0 WHERE 1=1 "
        lstrSQL += lstrQuery
        lstrSQL += " ORDER BY mst.run_code, mst.clt_type DESC, mst.mc_act_ratio desc, mst.clt_code "

        ldtsTemp = GFncRtnDS(GSCnLiqConn, lstrSQL)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraHeader", "CRC Securities Liquidation Listing - (Margin & Cash & Finance)")
            clsRpt.AddParam(rpt, "paraTitle", lstrTitle)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("CRC Securities Liquidation Listing - (Margin & Cash & Finance)")
        End If

    End Function
    Protected Friend Function lFncPrintAccFBLst(ByVal lstrQuery As String, _
        ByVal lstrTitle As String) As ReportClass
        Dim rpt As New RptLiqFBLst
        Dim ldtsTemp As DataSet
        Dim lstrCrit As String = ""
        Dim lstrSQL As String = ""

        lstrSQL = "SELECT  *,case when liq.liq_day is null then 0 else liq.liq_day end liq_day " & _
                " FROM stcltmaster mst inner JOIN  stcltliqfb liq ON  mst.clt_code = liq.clt_code " & _
                " and liq.liq_day > 0 WHERE 1=1 "
        lstrSQL += lstrQuery
        lstrSQL += " ORDER BY mst.run_code, mst.clt_type DESC, mst.mc_act_ratio desc, mst.clt_code "

        ldtsTemp = GFncRtnDS(GSCnLiqConn, lstrSQL)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraTitle", lstrTitle)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("CRC Security Liquidation FeedBack Listing - (Margin & Cash & Finance)")
        End If

    End Function

End Class
