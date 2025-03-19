Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsAccStat

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncTotalS() As ReportClass

        Dim lsqlCmd As SqlCommand = New SqlCommand("s_Rpt_AccStat_TotalS", GSCnSqlConn)
        lsqlCmd.CommandType = CommandType.StoredProcedure

        ' 参数        
        AddParameter(lsqlCmd, "g2sbDB", GStrG2BSDB)

        Return lFncGetTotal(lsqlCmd, "Securites Account Statistics")

    End Function

    Protected Friend Function lFncTotalF() As ReportClass

        Dim lsqlCmd As SqlCommand = New SqlCommand("s_Rpt_AccStat_TotalF", GSCnSqlConn)
        lsqlCmd.CommandType = CommandType.StoredProcedure

        ' 参数        
        AddParameter(lsqlCmd, "g2fbDB", GStrG2BFDB)

        Return lFncGetTotal(lsqlCmd, "Futures Account Statistics")

    End Function

    Protected Friend Function lFncActAccS(ByVal mth As Integer, ByVal day As Integer) As ReportClass

        Dim fromDate As Date
        Dim ldtsTemp As DataSet
        Dim rpt As New RptASActAC

        fromDate = GDteTradeDate
        fromDate = DateAdd(DateInterval.Month, mth * -1, fromDate)
        fromDate = DateAdd(DateInterval.Day, day * -1, fromDate)

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ActAccS", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)
        AddParameter(sqlCmd, "lastday", Format(fromDate, "yyyyMMdd"))

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then

            Dim cashCount As Integer = CInt(ldtsTemp.Tables(0).Compute("Count([accno])", " client_type = 'Cash'"))
            Dim marginCount As Integer = CInt(ldtsTemp.Tables(0).Compute("Count([accno])", " client_type = 'Margin'"))

            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraTitle", "Securites Active Account List (Margin & Cash)".ToUpper)
            clsRpt.AddParam(rpt, "paraTitle2", "A/C Having Trades within " & mth & " month(s) and " & day & " day(s).")
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraActive", "1")
            clsRpt.AddParam(rpt, "paraCashCount", cashCount.ToString)
            clsRpt.AddParam(rpt, "paraMarginCount", marginCount.ToString)
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Securites Active Account List (Margin & Cash)")
        End If

    End Function

    Protected Friend Function lFncActAccF(ByVal mth As Integer, ByVal day As Integer) As ReportClass

        Dim fromDate As Date
        Dim ldtsTemp As DataSet
        Dim rpt As New RptASActACF

        fromDate = GDteTradeDate
        fromDate = DateAdd(DateInterval.Month, mth * -1, fromDate)
        fromDate = DateAdd(DateInterval.Day, day * -1, fromDate)

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ActAccF", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2fbDB", GStrG2BFDB)
        AddParameter(sqlCmd, "lastday", Format(fromDate, "yyyyMMdd"))

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraTitle", "Futures Active Account List".ToUpper)
            clsRpt.AddParam(rpt, "paraTitle2", "A/C Having Trades within " & mth & " month(s) and " & day & " day(s).")
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraActive", "1")
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Futures Active Account List")
        End If

    End Function

    Protected Friend Function lFncNActAccS(ByVal mth As Integer, ByVal day As Integer) As ReportClass

        Dim fromDate As Date
        Dim ldtsTemp As DataSet
        Dim rpt As New RptASActAC

        fromDate = GDteTradeDate
        fromDate = DateAdd(DateInterval.Month, mth * -1, fromDate)
        fromDate = DateAdd(DateInterval.Day, day * -1, fromDate)

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ActAccS_Not", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)
        AddParameter(sqlCmd, "lastday", Format(fromDate, "yyyyMMdd"))

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then

            Dim cashCount As Integer = CInt(ldtsTemp.Tables(0).Compute("Count([accno])", " client_type = 'Cash'"))
            Dim marginCount As Integer = CInt(ldtsTemp.Tables(0).Compute("Count([accno])", " client_type = 'Margin'"))

            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraTitle", "Securites Non-Active Account List (Margin & Cash)".ToUpper)
            clsRpt.AddParam(rpt, "paraTitle2", "A/C Having No Trades within " & mth & " month(s) and " & day & " day(s).")
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraActive", "2")
            clsRpt.AddParam(rpt, "paraCashCount", cashCount.ToString)
            clsRpt.AddParam(rpt, "paraMarginCount", marginCount.ToString)
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Securites Non-Active Account List (Margin & Cash)")
        End If

    End Function

    Protected Friend Function lFncNActAccF(ByVal mth As Integer, ByVal day As Integer) As ReportClass

        Dim fromDate As Date
        Dim ldtsTemp As DataSet
        Dim rpt As New RptASActACF

        fromDate = GDteTradeDate
        fromDate = DateAdd(DateInterval.Month, mth * -1, fromDate)
        fromDate = DateAdd(DateInterval.Day, day * -1, fromDate)

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ActAccF_Not", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2fbDB", GStrG2BFDB)
        AddParameter(sqlCmd, "lastday", Format(fromDate, "yyyyMMdd"))

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraTitle", "Futures Non-Active Account List".ToUpper)
            clsRpt.AddParam(rpt, "paraTitle2", "A/C Having No Trades within " & mth & " month(s) and " & day & " day(s).")
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraActive", "2")
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Futures Non-Active Account List")
        End If

    End Function

    Protected Friend Function lFncNewAccS(ByVal fromDate As Date, ByVal toDate As Date) As ReportClass

        Dim ldtsTemp As DataSet
        Dim rpt As New RptASNewACS

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ActAccS_New", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB)
        AddParameter(sqlCmd, "fromdate", Format(fromDate, "yyyyMMdd"))
        AddParameter(sqlCmd, "todate", Format(toDate, "yyyyMMdd"))

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then

            Dim cashCount As Integer = CInt(ldtsTemp.Tables(0).Compute("Count([accno])", " acc_type = 'Cash'"))
            Dim marginCount As Integer = CInt(ldtsTemp.Tables(0).Compute("Count([accno])", " acc_type = 'Margin'"))

            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraTitle", "Securities New Account List (Margin & Cash)".ToUpper)
            clsRpt.AddParam(rpt, "paraTitle2", "A/C Opened from " & Format(fromDate, "dd/MM/yyyy") & _
                                    " to " & Format(toDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraCashCount", cashCount.ToString)
            clsRpt.AddParam(rpt, "paraMarginCount", marginCount.ToString)
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Securities New Account List (Margin & Cash)")
        End If

    End Function


    Protected Friend Function lFncNewAccF(ByVal fromDate As Date, ByVal toDate As Date) As ReportClass

        Dim ldtsTemp As DataSet
        Dim rpt As New RptASNewACF

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Rpt_ActAccF_New", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        AddParameter(sqlCmd, "g2fbDB", GStrG2BFDB)
        AddParameter(sqlCmd, "fromdate", Format(fromDate, "yyyyMMdd"))
        AddParameter(sqlCmd, "todate", Format(toDate, "yyyyMMdd"))

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraTitle", "Futures New Account List".ToUpper)
            clsRpt.AddParam(rpt, "paraTitle2", "A/C Opened from " & Format(fromDate, "dd/MM/yyyy") & _
                                    " to " & Format(toDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Futures New Account List")
        End If

    End Function

    Protected Friend Function lFncGetTotal(ByVal lsqlCmd As SqlCommand, ByVal title As String) As ReportClass

        Dim ldtsTemp As DataSet
        Dim rpt As New RptAsTotal

        lsqlCmd.Connection = GSCnSqlConn

        ldtsTemp = GFncRtnDS(lsqlCmd)
        If ldtsTemp.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp.Tables(0))
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            clsRpt.AddParam(rpt, "paraTitle", title.ToUpper)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt(title)
        End If

    End Function

End Class
