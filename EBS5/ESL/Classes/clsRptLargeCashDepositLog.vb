Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient

Public Class clsRptLargeCashDepositLog

    Dim clsRpt As New ClsReports

    Protected Friend Function genReport(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal currency As String, _
                          ByVal amtMin As Decimal, ByVal amtMax As Decimal) As ReportClass
        Dim rpt As New rptLargeCashDepositLog

        'Dim dt As DataTable = lfncGenDT(dateFrom, dateTo, currency, amount).Tables(0)

        'dt.Rows.Add(dt.Rows(0).ItemArray)

        'dt.Rows(dt.Rows.Count - 1).Item(0) = "60023288"
        'dt.Rows(dt.Rows.Count - 1).Item(0) = "60000833"
        'dt.Rows(dt.Rows.Count - 1).Item(4) = "AUS"

        'dt.Rows.Add(dt.Rows(0).ItemArray)
        'dt.Rows(dt.Rows.Count - 1).Item(0) = "40000833"
        'dt.Rows(dt.Rows.Count - 1).Item(4) = "AUS"

        'dt.Rows.Add(dt.Rows(0).ItemArray)
        'dt.Rows(dt.Rows.Count - 1).Item(0) = "D0000833"
        'dt.Rows(dt.Rows.Count - 1).Item(4) = "AUS"

        'rpt.SetDataSource(dt)


        rpt.SetDataSource(lfncGenDT(dateFrom, dateTo, currency, amtMin, amtMax).Tables(0))

        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        clsRpt.AddParam(rpt, "paraDateFrom", Format(dateFrom, "dd-MMM-yyyy"))
        clsRpt.AddParam(rpt, "paraDateTo", Format(dateTo, "dd-MMM-yyyy"))
        clsRpt.AddParam(rpt, "paraCurr", Trim(currency))
        If amtMax = 0 Then
            clsRpt.AddParam(rpt, "paraAmt", amtMin)
            clsRpt.AddParam(rpt, "paraAmtMin", "")
            clsRpt.AddParam(rpt, "paraAmtMax", "")
        Else
            clsRpt.AddParam(rpt, "paraAmt", "")
            clsRpt.AddParam(rpt, "paraAmtMin", Format(amtMin, "###,###,###,##0.00"))
            clsRpt.AddParam(rpt, "paraAmtMax", Format(amtMax, "###,###,###,##0.00"))
        End If

        Return rpt

    End Function

    Protected Friend Function lfncGetCurrency() As DataSet
        Dim ldt As DataTable = New DataTable
        Dim lstrSQL As String = "select name_s from " & GStrG2BSDB & ".dbo.currency_master"


        Return GFncRtnDS(GSCnSqlConn, lstrSQL)
    End Function

    'Protected Friend Function lfncGenDT(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal currency As String, _
    '                       ByVal amount As String) As DataSet

    '    Dim ldt As DataTable = New DataTable
    '    Dim lstrSQL As String = "select d.accno, REPLACE(CONVERT(VARCHAR(9), d.vdate, 6), ' ', '-') AS vdate, d.notes, d.amt, d.currency, e.name_1, substring(d.accno, 2, 7) as accNo_forGrouping, d.vdate as date from " & GStrG2BFDB & ".dbo.client_master e " & _
    '                            "inner join " & _
    '                            "(select b.accno, a.vdate, a.notes, a.amt, isnull(c.name_s, 'HKD') as currency " & _
    '                            "from " & _
    '                            "(select aid, cuid, vdate, notes, amt from " & GStrG2BSDB & ".dbo.histcl_fund " & _
    '                            "union all " & _
    '                            "select aid, cuid, vdate, notes, amt from  " & GStrG2BSDB & ".dbo.fund_move_client) a " & _
    '                            "inner join " & GStrG2BSDB & ".dbo.client_master b " & _
    '                            "on a.aid = b.aid " & _
    '                            "left outer join " & GStrG2BSDB & ".dbo.currency_master c " & _
    '                            "on a.cuid = c.cuid " & _
    '                            "where vdate >= '" & Format(dateFrom, "yyyy/MM/dd") & "' and vdate <= '" & Format(dateTo, "yyyy/MM/dd") & "' and a.notes like 'CASH DEP%' "

    '    If currency = "<<ALL>>" Then
    '        lstrSQL += "and amt >" & amount.Replace(",", "") & ") d on d.accno=e.accno"
    '    Else
    '        lstrSQL += "and c.name_s = '" & currency & "' and amt >" & amount.Replace(",", "") & ") d on d.accno=e.accno"
    '    End If
    '    '"and c.name_s = '" & currency & "' and amt >'" & amount & "') d on d.accno=e.accno"

    '    lstrSQL += " order by accNo_forGrouping, d.accno, d.currency, d.vdate"

    '    Return GFncRtnDS(GSCnSqlConn, lstrSQL)

    'End Function


    Protected Friend Function lfncGenDT(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal currency As String, _
                               ByVal amtMin As Decimal, ByVal amtMax As Decimal) As DataSet

        Dim ldts As DataSet = New DataSet
        Dim lstrSQL As String = "select d.accno, REPLACE(CONVERT(VARCHAR(9), d.vdate, 6), ' ', '-') AS vdate, d.notes, d.amt, d.currency, e.name_1, substring(d.accno, 2, 7) as accNo_forGrouping, d.vdate as date, 'S' as trade_type into #tmp_cash_deposit_s " & _
                                " from " & GStrG2BSDB & ".dbo.client_master e " & _
                                "inner join " & _
                                "(select b.accno, a.vdate, a.notes, a.amt, isnull(c.name_s, 'HKD') as currency " & _
                                "from " & _
                                "(select aid, cuid, vdate, notes, amt from  " & GStrG2BSDB & ".dbo.histcl_fund " & _
                                "union all " & _
                                "select aid, cuid, vdate, notes, amt from  " & GStrG2BSDB & ".dbo.fund_move_client) a " & _
                                "inner join " & GStrG2BSDB & ".dbo.client_master b " & _
                                "on a.aid = b.aid " & _
                                "left outer join  " & GStrG2BSDB & ".dbo.currency_master c " & _
                                "on a.cuid = c.cuid " & _
                                "where vdate >= '" & Format(dateFrom, "yyyy/MM/dd") & "' and vdate <= '" & Format(dateTo, "yyyy/MM/dd") & "' and a.notes like 'CASH DEP%' "



        If currency <> "<<ALL>>" Then
            lstrSQL += " and c.name_s = '" & currency & "' "
        End If
        lstrSQL += " ) d on d.accno=e.accno order by accNo_forGrouping, d.accno, d.currency, d.vdate"
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        lstrSQL = "select d.accno, REPLACE(CONVERT(VARCHAR(9), d.vdate, 6), ' ', '-') AS vdate, d.notes, d.amt, d.currency, e.name_1, substring(d.accno, 2, 7) as accNo_forGrouping, d.vdate as date, 'F' as trade_type into #tmp_cash_deposit_f " & _
                                     " from " & GStrG2BFDB & ".dbo.client_master e " & _
                                     "inner join " & _
                                     "(select b.accno, a.vdate, a.notes, a.amt, isnull(c.name_s, 'HKD') as currency " & _
                                     "from " & _
                                     "(select aid, cuid, vdate, notes, amt from  " & GStrG2BFDB & ".dbo.histcl_fund " & _
                                     "union all " & _
                                     "select aid, cuid, vdate, notes, amt from  " & GStrG2BFDB & ".dbo.fund_move_client) a " & _
                                     "inner join " & GStrG2BFDB & ".dbo.client_master b " & _
                                     "on a.aid = b.aid " & _
                                     "left outer join  " & GStrG2BFDB & ".dbo.currency_master c " & _
                                     "on a.cuid = c.cuid " & _
                                     "where vdate >= '" & Format(dateFrom, "yyyy/MM/dd") & "' and vdate <= '" & Format(dateTo, "yyyy/MM/dd") & "' and a.notes like 'CASH DEP%' "


        If currency <> "<<ALL>>" Then
            lstrSQL += " and c.name_s = '" & currency & "' "
        End If
        lstrSQL += " ) d on d.accno=e.accno order by accNo_forGrouping, d.accno, d.currency, d.vdate"
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        'lstrSQL = " select *  into #tmp_cash_deposit from ( " & _
        '            " select * from  #tmp_cash_deposit_s  " & _
        '           " union all " & _
        '            " select * from  #tmp_cash_deposit_f ) a "
        lstrSQL = " select *  into #tmp_cash_deposit from ( " & _
                    " select * from  #tmp_cash_deposit_f ) a "
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        lstrSQL = " select a.* from  #tmp_cash_deposit a " & _
                " inner join ( select accNo_forGrouping, sum(amt) as total_amt " & _
                " from #tmp_cash_deposit group by accNo_forGrouping  "

        If amtMax > 0 Then
            lstrSQL += " having sum(amt) >= " & amtMin & " and sum(amt) <=" & amtMax & ") b on a.accNo_forGrouping =  b.accNo_forGrouping "
        Else
            lstrSQL += " having sum(amt) >= " & amtMin & ")  b on a.accNo_forGrouping =  b.accNo_forGrouping  "
        End If
        lstrSQL += "  order by a.accNo_forGrouping, a.accno, a.currency, a.date"
        ldts = GFncRtnDS(GSCnSqlConn, lstrSQL)

        lstrSQL = " drop table #tmp_cash_deposit "
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        lstrSQL = " drop table #tmp_cash_deposit_s "
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        lstrSQL = " drop table #tmp_cash_deposit_f "
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        Return ldts

    End Function

End Class
