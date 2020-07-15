Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRptComm
    Dim clsRpt As New ClsReports

    Protected Friend Function PrintCommRpt(ByVal fromAE As ComboBox, ByVal toAE As ComboBox, ByVal fromdate As Date, ByVal todate As Date) As ReportClass
        Dim rpt As New RptComm2
        Dim condition As String = ""

        condition = "Range From " & Format(fromdate, "dd/MM/yyyy") & _
                        " To " & Format(todate.AddMonths(1).AddDays(-1), "dd/MM/yyyy")

        If fromAE.Text.Trim <> toAE.Text.Trim Then
            If fromAE.Text <> "" Then
                condition &= ", AE No. >= " & fromAE.Text.Trim
            End If

            If toAE.Text <> "" Then
                condition &= ", AE No. <= " & toAE.Text.Trim
            End If
        ElseIf fromAE.Text <> "" Then
            condition &= ", AE No. = " & fromAE.Text.Trim
        End If

        Dim dt As DataTable = genRptComm(fromAE, toAE, fromdate, todate).Tables(0)

        rpt.SetDataSource(dt)

        clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        clsRpt.AddParam(rpt, "paraTitle", condition)
        Return rpt

    End Function

    'Eddie 20180125 field named "Int.IPO" values comes from ESL_Liq_Dev.dbo.MONTHINT.IPO
    'Account source from ImportData: g2bs.dbo.view_it_client_accrue_int but set 0 for IPO
    'Can't find anywhere MONTHINT.IPO updated in EBS4 source code
    Protected Friend Function genRptComm(ByVal fromAE As ComboBox, ByVal toAE As ComboBox, ByVal fromDate As Date, ByVal toDate As Date) As DataSet

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_Comm", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)
        AddParameter(sqlCmd, "g2fbDB", GStrG2BFDB)
        AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
        AddParameter(sqlCmd, "fromDate", Format(fromDate, "yyyy-MM-dd"))
        AddParameter(sqlCmd, "toDate", Format(toDate.AddMonths(1).AddDays(-1), "yyyy-MM-dd"))
        AddParameter(sqlCmd, "fromAECode", fromAE.Text.Trim)
        AddParameter(sqlCmd, "toAECode", toAE.Text.Trim)

        Dim result As DataSet = GFncRtnDS(sqlCmd)
        Return result
    End Function
End Class
