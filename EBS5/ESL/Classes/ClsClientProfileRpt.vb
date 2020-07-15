Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsClientProfileRpt

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncView(ByVal fromDate As Date, ByVal toDate As Date, ByVal condition As Integer, _
                                        ByVal client_type As Integer) As ReportClass

        Dim lstrSQL As String
        Dim ldtsTemp As DataSet
        Dim rpt As New RptClientProfileRpt
        Dim lTitle As String

        lstrSQL = "select a.accno, a.name, b.trade_volume, a.investment from ("
        If (client_type = 1) Then
            lstrSQL += "SELECT accno, name, investment FROM client "
            lTitle = "Individual Client with "
        ElseIf (client_type = 2) Then
            lstrSQL += "SELECT accno, name, investment FROM corp_client "
            lTitle = "Corporate Client with "
        Else
            lstrSQL += "SELECT accno, name, investment FROM client " & _
                        "union SELECT accno, name, investment FROM corp_client"
            lTitle = "All Client with "
        End If
        lstrSQL += ") a, (SELECT accno, SUM(net_amt) * -1 as trade_volume FROM " & GStrG2BSDB & _
                    ".dbo.View_g2b_client_trade_dt_with_comm WHERE net_amt < 0 AND tdate >= '" & Format(fromDate, "yyyyMMdd") & _
                    "' AND TDATE <= '" & Format(toDate, "yyyyMMdd") & "' GROUP BY accno) b where a.accno " & _
                    "COLLATE DATABASE_DEFAULT = b.accno and "
        If (condition = 1) Then
            lstrSQL += "trade_volume >= investment "
            lTitle += "Actual Trade >= Indicated Investment"
        Else
            lstrSQL += "trade_volume < investment "
            lTitle += "Actual Trade < Indicated Investment"
        End If
        lstrSQL += "order by a.accno"

        ldtsTemp = GFncRtnDS(GSCnBalConn, lstrSQL, 0)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraTitle1", "Trading Period: from " & Format(fromDate, "dd MMM yyyy") & " to " & Format(toDate, "dd MMM yyyy"))
            clsRpt.AddParam(rpt, "paraTitle2", lTitle)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Client Profile Report")
        End If

    End Function

End Class
