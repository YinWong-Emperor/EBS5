Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsSuspendStockClient

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncSuspendStockClient(ByVal tradeDate As Date,
                                                     ByVal stockFrom As String,
                                                     ByVal stockTo As String,
                                                     ByVal clientFrom As String,
                                                     ByVal clientTo As String) As ReportClass

        Dim ldtsTemp As DataSet
        Dim rpt As New RptSuspendStockClient

        Dim balanceDB As String
        Dim liqDB As String
        balanceDB = GSubGetESLDB("BAL")
        liqDB = GSubGetESLDB("LIQ")

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_SuspendStockClient", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "balanceDB", balanceDB)
        AddParameter(sqlCmd, "liqDB", liqDB)
        AddParameter(sqlCmd, "tradeDate", tradeDate)
        AddParameter(sqlCmd, "stockFrom", stockFrom)
        AddParameter(sqlCmd, "stockTo", stockTo)
        AddParameter(sqlCmd, "clientFrom", clientFrom)
        AddParameter(sqlCmd, "clientTo", clientTo)

        ldtsTemp = GFncRtnDS(sqlCmd)

        'If ldtsTemp.Tables(0).Rows.Count > 0 Then
        rpt.SetDataSource(ldtsTemp.Tables(0))
        clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        Return rpt
        'Else
        '    Return clsRpt.lfncRtnEmptyRpt("Suspend Stock Client Report")
        'End If

    End Function

End Class
