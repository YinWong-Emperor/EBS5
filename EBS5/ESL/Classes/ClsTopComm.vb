Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsTopComm

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncTopComm(ByVal topNo As Integer, ByVal fromDate As Date, ByVal toDate As Date, _
                                            ByVal type As String) As ReportClass


        Dim ldtsTemp As DataSet
        Dim rpt As New RptTopComm

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_TopCommS", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "topNo", topNo)
        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)
        AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
        AddParameter(sqlCmd, "fromDate", Format(fromDate, "yyyyMMdd"))
        AddParameter(sqlCmd, "toDate", Format(toDate, "yyyyMMdd"))
        AddParameter(sqlCmd, "clientType", type)

        ldtsTemp = GFncRtnDS(sqlCmd)
        If Not ldtsTemp Is Nothing Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraTitle", "SECURITIES ACCOUNT BY COMMISSION INCOME (" & type & ")")
            clsRpt.AddParam(rpt, "paraTitle2", topNo & " Topmost Client(s) Ranked By Commission Income ")
            clsRpt.AddParam(rpt, "paraFTDate", "From " & Me.changeMonth(fromDate.Month) & Format(fromDate, " yyyy") & " To " & Me.changeMonth(toDate.Month) & Format(toDate, " yyyy"))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraStock", "1")
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("SECURITIES ACCOUNT BY COMMISSION INCOME (" & type & ")")
        End If

    End Function

    Protected Friend Function lFncTopCommF(ByVal topNo As Integer, ByVal fromDate As Date, ByVal toDate As Date) As ReportClass

        Dim ldtsTemp As DataSet
        Dim rpt As New RptTopComm

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_TopCommF", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "topNo", topNo)
        AddParameter(sqlCmd, "g2fbDB", GStrG2BFDB)
        AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
        AddParameter(sqlCmd, "fromDate", Format(fromDate, "yyyyMMdd"))
        AddParameter(sqlCmd, "toDate", Format(toDate, "yyyyMMdd"))

        ldtsTemp = GFncRtnDS(sqlCmd)
        If Not ldtsTemp Is Nothing Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraTitle", "FUTURES ACCOUNT BY COMMISSION INCOME")
            clsRpt.AddParam(rpt, "paraTitle2", topNo & " TOP MOST CLIENT(S) RANKED BY COMMISSION INCOME ")
            clsRpt.AddParam(rpt, "paraFTDate", "From " & Me.changeMonth(fromDate.Month) & Format(fromDate, " yyyy") & " To " & Me.changeMonth(toDate.Month) & Format(toDate, " yyyy"))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraStock", "2")
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Futures Account By Commission Income")
        End If

    End Function

    Private Function changeMonth(ByVal intMonth As Integer) As String
        Dim strMonth As String = "Jan,Feb,Mar,Apr,May,Jun,Jul,Aug,Sep,Oct,Nov,Dec"
        Return strMonth.Split(",")(intMonth - 1)
    End Function

End Class
