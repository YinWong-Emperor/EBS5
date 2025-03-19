Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsCrLmtRpt
    Dim clsRpt As New ClsReports

    Protected Friend Function lFncGetAEBal(ByVal mth As Integer, ByVal day As Integer, ByVal cltType As String, _
                                            ByVal condition As String, ByVal sort As String) As DataSet
        Dim fromDate As Date = Now
        Dim lstrSQL As String = ""

        fromDate = GDteTradeDate
        fromDate = DateAdd(DateInterval.Month, mth * -1, fromDate)
        fromDate = DateAdd(DateInterval.Day, day * -1, fromDate)
        If (cltType.Trim.Length > 0) Then
            lstrSQL = "and clt_type = '" & cltType & "' "
        End If

        lstrSQL = "select a.clt_code, a.clt_name, case when a.clt_type = 'C' then 'Cash' else 'Margin' end as clt_type, " & _
            "a.run_code, a.lastTradeDate, a.cr_limit, a.net_trade_limit, isnull(a.curr_mth_turnover,0) as curr_mth_turnover, " & _
            "isnull(a.prev_mth_turnover,0) as prev_mth_turnover, " & _
            "isnull(case when a.prev_mth_turnover=0 then case when a.curr_mth_turnover=0 then 0 else 999 end " & _
            "else (a.curr_mth_turnover - a.prev_mth_turnover)*100/a.prev_mth_turnover end,0) as mthChange,  " & _
            "isnull(a.curr_year_turnover,0) as curr_year_turnover, isnull(a.prev_year_turnover,0) as prev_year_turnover, " & _
            "case when b.suspend_field = 'Yes' and b.date_close is Null then 'S' " & _
            "when b.suspend_field = 'Yes' and b.date_close is not Null then 'C' else '' end as status " & _
            "from STCLTMASTER a left join (select distinct accno, suspend_field, date_close from " & _
            GStrG2BSDB & ".dbo.view_it_client_all) b on a.clt_code = b. accno " & _
            "where 1=1 " & lstrSQL & condition
        If mth > 0 Or (mth = 0 And day > 0) Then
            lstrSQL = lstrSQL & " and lastTradeDate >= '" & Format(fromDate, "yyyyMMdd") & "'"
        End If
        lstrSQL = lstrSQL & " order by " & sort
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, 0)
    End Function

    Protected Friend Function lFncGetBalSumRpt(ByVal mth As Integer, ByVal day As Integer, ByVal cltType As String, _
                                                ByVal condition As String, ByVal lTitle As String, ByVal sort As String) As ReportClass
        Dim lstrSQL As String = ""
        Dim ldtsBalSum As DataSet = Nothing
        Dim rpt As New RptCrLmtRpt
        'Dim tradeDate As Date = Now
        'Dim tmpDate As Date = Now
        Dim tradeDate As Date = GDteTradeDate
        Dim tmpDate As Date = GDteTradeDate
        Dim prevY As String = ""
        Dim currY As String = ""
        Dim prevM As String = ""
        Dim currM As String = ""
        Dim rTitle As String = "Client Account Statistics"

        ldtsBalSum = lFncGetAEBal(mth, day, cltType, condition, sort)

        If ldtsBalSum.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsBalSum.Tables(0))
            tradeDate = GDteTradeDate
            'If (Month(tradeDate) >= 11) Then
            prevY = "01/01/" & Format(tradeDate.AddYears(-1), "yy") & "-31/12/" & Format(tradeDate.AddYears(-1), "yy")
            currY = "01/01/" & Format(tradeDate, "yy") & "-" & Format(tradeDate, "dd/MM/yy")
            'Else
            '    prevY = "01/01/" & Format(tradeDate.AddYears(-2), "yy") & "-31/10/" & Format(tradeDate.AddYears(-1), "yy")
            '    currY = "01/01/" & Format(tradeDate.AddYears(-1), "yy") & "-" & Format(tradeDate, "dd/MM/yy")
            'End If
            tmpDate = tradeDate.AddDays(tradeDate.Day * -1)
            prevM = "01/" & Format(tmpDate, "MM/yy") & "-" & Format(tmpDate, "dd/MM/yy")
            currM = "01/" & Format(tradeDate, "MM/yy") & "-" & Format(tradeDate, "dd/MM/yy")

            clsRpt.AddParam(rpt, "paraPrevY", prevY)
            clsRpt.AddParam(rpt, "paraCurrY", currY)
            clsRpt.AddParam(rpt, "paraPrevM", prevM)
            clsRpt.AddParam(rpt, "paraCurrM", currM)
            clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
            If (cltType = "M") Then
                rTitle = rTitle & " - Margin Client Only"
            End If
            If (cltType = "C") Then
                rTitle = rTitle & " - Cash Client Only"
            End If
            clsRpt.AddParam(rpt, "paraTitle", rTitle)
            clsRpt.AddParam(rpt, "paraTitle2", "A/C having trades within " & mth & " month(s) and " & day & " day(s) " & lTitle)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Client Account Statistics - A/C having trades within " & mth & " month(s) and " & day & " day(s) " & lTitle)
        End If

    End Function

    Protected Friend Function lFncGetAECode() As DataSet

        Dim lstrSQL As String

        lstrSQL = "SELECT DISTINCT stcltmaster.run_code as aeno FROM stcltmaster ORDER BY stcltmaster.run_code "
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "clt")

    End Function

    Protected Friend Function lFncExportCSV(ByVal mth As Integer, ByVal day As Integer, ByVal cltType As String, _
                                            ByVal condition As String, ByVal lTitle As String, ByVal sort As String) As Boolean
        Dim ldtsBalSum As DataSet = Nothing
        Dim strExFile As String = "CltAccStat" & Format(GDteTradeDate, "yyyyMMdd") & ".csv"
        Dim strHeader As String = " Client No, Client Name, Client Type, AE No, Last Trade Date, Credit Limit, " & _
                                    "Net Trade Limit, Curr. Month Turnover, Prev. Month Turnover, +/- %,  " & _
                                    "Curr Year Turnover, Prev Year Turnover, Status "

        ldtsBalSum = lFncGetAEBal(mth, day, cltType, condition, sort)
        Return GExportCSV(GStrExptDir, strExFile, ldtsBalSum, strHeader)
    End Function

End Class
