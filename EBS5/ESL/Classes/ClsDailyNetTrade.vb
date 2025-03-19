Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsDailyNetTrade

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncAccOverLmt(ByVal selectDate As Date) As ReportClass

        Dim lstrSQL As String
        Dim ldtsTemp As DataSet
        Dim rpt As New RptDailyNetTrade

        lstrSQL = "select cm.accno, name_1, credit_lmt,  SUM(Net_amt) * -1 as net_trade " & _
                    "from " & GStrG2BSDB & ".dbo.view_it_client_all cm, " & GStrG2BSDB & ".dbo.View_g2b_client_trade_dt_with_comm ct " & _
                    "where cm.accno=ct.accno and client_type='Margin' and tdate='" & Format(selectDate, "yyyyMMdd") & "' " & _
                    "group by cm.accno, name_1, credit_lmt having (SUM(Net_amt) * -1) > credit_lmt " & _
                    "order by cm.accno"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Daily Net Trade Report (List of Margin A/C over Credit Limit)")
        End If

    End Function

End Class
