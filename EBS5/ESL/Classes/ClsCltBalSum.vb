Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsCltBalSum

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncGetAECode() As DataSet

        Dim lstrSQL As String

        lstrSQL = "SELECT DISTINCT stcltmaster.run_code as aeno FROM stcltmaster ORDER BY stcltmaster.run_code "
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "clt")

    End Function

    Protected Friend Function lFncGetBalSum(ByVal displayField As String, _
                                    ByVal MyTrans As SqlTransaction, ByVal Dr_Bal As Double, _
                                    ByVal condition As String) As DataSet
        Dim lstrSQL As String = ""

        lstrSQL = "select clt_code, 'CLOSE' as status_type, cls_date as stop_date " & _
                    "into #clientstatus " & _
                    "FROM teststatus WHERE stop = 'Y' AND not(cls_date is null) " & _
                    "UNION all " & _
                    "select clt_code, 'SUSP' as status_type, susp_date as stop_date " & _
                    "FROM teststatus WHERE stop = 'Y' AND cls_date is null"
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
        lstrSQL = "SELECT mas.clt_code, clt_name, run_code, t1_unrealized, t2_unrealized, clt_type, " & _
                    "(dr_bal * (-1)) -t1_unrealized-t2_unrealized as ava_bal, dr_bal, cr_bal, interest, cr_limit, " & _
                    "mkt_value, mc_act_ratio, margin_value, isnull(status_type, 'ACT') as clt_status, margin_ratio " & _
                    "into #balsummary " & _
                    "FROM stcltmaster mas " & _
                    "LEFT OUTER JOIN #clientstatus st ON mas.clt_code = st.clt_code where dr_bal <> 0 " & _
                    "UNION ALL " & _
                    "SELECT mas.clt_code, clt_name, run_code, t1_unrealized, t2_unrealized, clt_type, " & _
                    "cr_bal -t1_unrealized-t2_unrealized as ava_bal, dr_bal, cr_bal, interest, cr_limit, " & _
                    "mkt_value, mc_act_ratio, margin_value, isnull(status_type, 'ACT') as clt_status, margin_ratio " & _
                    "FROM stcltmaster mas " & _
                    "LEFT OUTER JOIN #clientstatus st ON mas.clt_code = st.clt_code where cr_bal <> 0 " & _
                    "UNION ALL " & _
                    "SELECT mas.clt_code, clt_name, run_code, t1_unrealized, t2_unrealized, clt_type, " & _
                    "cr_bal -t1_unrealized-t2_unrealized as ava_bal, dr_bal, cr_bal, interest, cr_limit, " & _
                    "mkt_value, mc_act_ratio, margin_value, isnull(status_type, 'ACT') as clt_status, margin_ratio " & _
                    "FROM stcltmaster mas " & _
                    "LEFT OUTER JOIN #clientstatus st ON mas.clt_code = st.clt_code where cr_bal = 0 AND dr_bal = 0 "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        lstrSQL = "SELECT clt_code, clt_name, run_code, t1_unrealized, t2_unrealized, clt_type, ava_bal, " & _
                    "dr_bal, cr_bal, interest, cr_limit, mkt_value, mc_act_ratio, margin_value, clt_status, " & _
                    "margin_ratio, case when (cr_bal <> 0 or dr_bal <> 0) then ava_bal else 0 end as avail_bal " & _
                    "into #CltBalSum " & _
                    "FROM #balsummary WHERE clt_type in ('C', 'M')  " & condition
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        lstrSQL = "Select " & displayField & " from #CltBalSum "
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)

    End Function

    Protected Friend Function lFncGetAEBal(ByVal MyTrans As SqlTransaction, ByVal Dr_Bal As Double) As DataSet
        Dim lstrSQL As String = ""

        lstrSQL = "select isnull(b.run_code, '') as run_code, isnull(b.run_name, '') as run_name, " & _
                " isnull(b.branch_name, '') as branch_name ,  sum(a.dr_bal) as TDr_Bal " & _
                    "into #AEDrBal " & _
                    "FROM #CltBalSum a left outer join STAEMASTER b on b.run_code=a.run_code " & _
                    "group by b.run_code, b.run_name, b.branch_name "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        lstrSQL = " update #AEDrBal set run_name = misc_desc from " & GStrConDB & ".dbo.misc_master " & _
                    " where misc_type = 'CBALBRANCH' and misc_code = #AEDrbal.branch_name collate database_default  "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        lstrSQL = " update #AEDrBal set run_name = misc_desc from " & GStrConDB & ".dbo.misc_master " & _
                 " where misc_type = 'CBALAE' and misc_code = #AEDrbal.run_code collate database_default  "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        lstrSQL = "select run_code, run_Name, sum(tdr_Bal) as tdr_bal " & _
                " from #AEDrBal where TDr_Bal > " & Dr_Bal & " group by run_code, run_Name order by TDr_Bal desc "
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)

    End Function
    Protected Friend Function lfncGetTradeDate(ByVal MyTrans As SqlTransaction, ByVal strFlag As String, ByVal dteTDate As Date) As Date
        Dim lastTradeDate As String = ""
        Dim ldsTradeDate As DataSet = Nothing
        Dim lstrSQL As String
        Dim ldteDate As Date

        If strFlag = "LastTDate" Then
            ldteDate = dteTDate
        Else
            ldteDate = CDate(Format(GDteTradeDate.Year, "0000") & "/" & Format(dteTDate.Month, "00") & "/01")
        End If

        lstrSQL = "select max(tdate) as lastTradeDate " & _
                                "from " & GStrBalDB & ".dbo.acbal " & _
                                "where tdate < '" & Format(ldteDate, "yyyy/MM/dd") & "' "
        ldsTradeDate = GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)
        If ldsTradeDate.Tables(0).Rows.Count > 0 Then
            lastTradeDate = ldsTradeDate.Tables(0).Rows(0).Item("lastTradeDate")
        Else
            lastTradeDate = Now
        End If

        Return lastTradeDate

    End Function
    Protected Friend Function lFncGetGroupBal(ByVal MyTrans As SqlTransaction, ByVal Dr_Bal As Double, _
                                              ByVal lastTradeDate As Date, ByVal lastMTradeDate As Date, _
                                              ByVal groupCondition As String) As DataSet
        Dim lstrSQL As String = ""
        Dim ldsTradeDate As DataSet = Nothing


        'lstrSQL = "select run_name, sum(tdr_bal) as GPBal " & _
        '            "into #AEGrPDrBal " & _
        '            "from #AEDrBal " & _
        '            "group by run_name having sum(tdr_bal) > 0 "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        lstrSQL = "select tdate, isnull(c.run_code, '') as run_code, isnull(c.run_name, '') as run_name, " & _
                    "isnull(c.branch_name, '') as branch_name, sum(a.led_bal) * -1 as d_bal " & _
                    "into #AEGrPDrBal " & _
                    "from " & GStrBalDB & ".dbo.acbal a " & _
                    "left outer join stcltmaster b on a.accno =b.clt_code collate database_default " & _
                    "left outer join STAEMaster c on b.run_code = c.run_code " & _
                    "left outer join #clientstatus d on a.accno = d.clt_code collate database_default " & _
                    "where led_bal<0 and led_bal < " & Dr_Bal * (-1) & _
                    " and ( tdate='" & Format(GDteTradeDate, "yyyy/MM/dd") & "' " & _
                    " or tdate='" & Format(lastTradeDate, "yyyy/MM/dd") & "' " & _
                    " or tdate='" & Format(lastMTradeDate, "yyyy/MM/dd") & "') " & groupCondition & _
                    "group by tdate, c.run_name, c.run_code, c.branch_name "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        'lstrSQL = "select  isnull(c.run_code, '') as run_code, isnull(c.run_name, '') as run_name,  isnull(c.branch_name, '') as branch_name , " & _
        '                " sum(a.led_bal) * -1 as d_bal " & _
        '                "into #AEGrPDrBal " & _
        '                "from " & GStrBalDB & ".dbo.acbal a " & _
        '                "left outer join stcltmaster b on a.accno =b.clt_code collate database_default " & _
        '                "left outer join STAEMaster c on b.run_code = c.run_code " & _
        '                "where led_bal<0 and led_bal < " & Dr_Bal * (-1) & _
        '                "and tdate='" & Format(GDteTradeDate, "yyyy/MM/dd") & "' " & _
        '                "group by c.run_name, c.branch_name "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        'lstrSQL = "select isnull(c.run_code, '') as run_code, isnull(c.run_name, '') as run_name,  isnull(c.branch_name, '') as branch_name , " & _
        '               " sum(a.led_bal) * -1 as d_bal " & _
        '               "into #LastDBal " & _
        '               "from " & GStrBalDB & ".dbo.acbal a " & _
        '               "left outer join stcltmaster b on a.accno =b.clt_code collate database_default " & _
        '               "left outer join STAEMaster c on b.run_code = c.run_code " & _
        '               "where led_bal<0 and led_bal < " & Dr_Bal * (-1) & _
        '               "and tdate='" & Format(lastTradeDate, "yyyy/MM/dd") & "' " & _
        '               "group by c.run_name,  c.run_code, c.branch_name "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        'lstrSQL = "select  isnull(c.run_code, '') as run_code, isnull(c.run_name, '') as run_name,  isnull(c.branch_name, '') as branch_name , " & _
        '                    " sum(a.led_bal) * -1 as d_bal " & _
        '                    "into #LastMDBal " & _
        '                    "from " & GStrBalDB & ".dbo.acbal a " & _
        '                    "left outer join stcltmaster b on a.accno =b.clt_code collate database_default " & _
        '                    "left outer join STAEMaster c on b.run_code = c.run_code " & _
        '                    "where led_bal<0 and led_bal < " & Dr_Bal * (-1) & _
        '                    "and tdate='" & Format(lastMTradeDate, "yyyy/MM/dd") & "' " & _
        '                    "group by c.run_name, c.run_code, c.branch_name "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        lstrSQL = " update #AEGrPDrBal set run_name = misc_desc from " & GStrConDB & ".dbo.misc_master " & _
                    " where misc_type = 'CBALBRANCH' and misc_code = #AEGRPDrbal.branch_name collate database_default  "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        lstrSQL = " update #AEGrPDrBal set run_name = misc_desc from " & GStrConDB & ".dbo.misc_master " & _
                 " where misc_type = 'CBALAE' and misc_code = #AEGRPDrbal.run_code collate database_default  "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        'lstrSQL = " update  #LastDBal set run_name = misc_desc from " & GStrConDB & ".dbo.misc_master " & _
        '            " where misc_type = 'CBALBRANCH' and misc_code =  #LastDBal.branch_name collate database_default  "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        'lstrSQL = " update  #LastDBal set run_name = misc_desc from " & GStrConDB & ".dbo.misc_master " & _
        '         " where misc_type = 'CBALAE' and misc_code =  #LastDBal.run_code collate database_default  "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        'lstrSQL = " update #LastMDBal set run_name = misc_desc from " & GStrConDB & ".dbo.misc_master " & _
        '            " where misc_type = 'CBALBRANCH' and misc_code = #LastMDBal.branch_name collate database_default  "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        'lstrSQL = " update #LastMDBal set run_name = misc_desc from " & GStrConDB & ".dbo.misc_master " & _
        '         " where misc_type = 'CBALAE' and misc_code = #LastMDBal.run_code collate database_default  "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

        lstrSQL = "select c.run_name, " & _
                  " isnull(a.d_Bal,0) as GPBal, isnull(b.d_bal,0) as GPBal_L, isnull(d.d_bal,0) as GPBal_LM " & _
                    " from (select distinct run_name from #AEGrPDrBal ) c  " & _
                    " left outer join (select sum(d_bal) as d_bal, run_name from #AEGrPDrBal where tdate='" & Format(GDteTradeDate, "yyyy/MM/dd") & "' group by run_name) a " & _
                    " on a.run_name = c.run_name " & _
                    " left outer join (select sum(d_bal) as d_bal, run_name from #AEGrPDrBal where tdate='" & Format(lastTradeDate, "yyyy/MM/dd") & "' group by run_name) b " & _
                    " on b.run_name = c.run_name " & _
                     " left outer join (select sum(d_bal) as d_bal, run_name from #AEGrPDrBal where tdate='" & Format(lastMTradeDate, "yyyy/MM/dd") & "' group by run_name) d " & _
                     " on d.run_name = c.run_name " & _
                    " order by GPBal desc "

        'lstrSQL = "select a.run_name, " & _
        '        " isnull(a.GPBal,0) as GPBal, isnull(b.d_bal,0) as GPBal_L " & _
        '                    "from #AEGrPDrBal a full outer join #LastDBal b on a.run_name= b.run_name " & _
        '                    "order by a.GPBal desc "
        Return GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)
    End Function

    Protected Friend Sub lFncCleanBalSum(ByVal MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        lstrSQL = "drop table #clientstatus "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
        lstrSQL = "drop table #balsummary "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
        lstrSQL = "drop table #CltBalSum"
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    End Sub

    Protected Friend Sub lFncCleanAEBal(ByVal MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        lstrSQL = "drop table #AEDrBal "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    End Sub

    Protected Friend Sub lFncCleanGroupBal(ByVal MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""
        lstrSQL = "drop table #AEGrPDrBal "
        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
        'lstrSQL = "drop table #LastDBal "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
        'lstrSQL = "drop table #LastMDBal "
        'GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    End Sub
    Protected Sub lsubReformatName(ByRef dt As DataTable)

        For Each ldr As DataRow In dt.Rows
            Dim lstrName As String = ""
            Dim lblnUp As Boolean = True
            For lintLen As Integer = 0 To ldr("run_name").ToString.Length - 1
                If ldr("run_name").ToString.Substring(lintLen, 1) = " " Then
                    lblnUp = True
                    lstrName += ldr("run_name").ToString.Substring(lintLen, 1).ToLower
                ElseIf lblnUp Then
                    lblnUp = False
                    lstrName += ldr("run_name").ToString.Substring(lintLen, 1).ToUpper
                Else
                    lstrName += ldr("run_name").ToString.Substring(lintLen, 1).ToLower
                End If
            Next
            ldr("run_name") = lstrName
        Next

    End Sub

    Protected Friend Function lFncGetBalSumRpt(ByVal condition As String, ByVal titleStr As String, ByVal dr_Bal As Double, _
                                                ByVal blnWithSummary As Boolean, ByVal regard As String, ByVal noted1 As String, _
                                                ByVal noted2 As String, ByVal noted3 As String, ByVal endor1 As String, _
                                                ByVal endor2 As String, ByVal groupCondition As String) As ReportClass
        Dim MyTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = ""
        Dim ldtsBalSum As DataSet = Nothing
        Dim ldtsAmtAE As DataSet = Nothing
        Dim ldtsAmtGrP As DataSet = Nothing
        Dim rpt As New RptCltBalSum
        Dim ldteLTDate As Date
        Dim ldteLMTDate As Date
        Dim sParaTDate As String
        Dim sParaLTDate As String
        Dim sParaLMTDate As String
        Dim sParaShowTDate As String
        Try
            MyTrans = GSCnLiqConn.BeginTransaction
            ldteLTDate = lfncGetTradeDate(MyTrans, "LastTDate", GDteTradeDate)
            ldteLMTDate = lfncGetTradeDate(MyTrans, "LastTMDate", ldteLTDate)
            ldtsBalSum = lFncGetBalSum("*", MyTrans, dr_Bal, condition)
            ldtsAmtAE = lFncGetAEBal(MyTrans, dr_Bal)
            ldtsAmtGrP = lFncGetGroupBal(MyTrans, dr_Bal, ldteLTDate, ldteLMTDate, groupCondition)
            lFncCleanBalSum(MyTrans)
            lFncCleanAEBal(MyTrans)
            lFncCleanGroupBal(MyTrans)
            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        If ldtsBalSum.Tables(0).Rows.Count > 0 Then
            rpt.SetDataSource(ldtsBalSum.Tables(0))
            lsubReformatName(ldtsAmtAE.Tables(0))
            lsubReformatName(ldtsAmtGrP.Tables(0))
            rpt.Subreports("RptCltBalSubAE").SetDataSource(ldtsAmtAE.Tables(0))
            rpt.Subreports("RptCltBalSumSub").SetDataSource(ldtsAmtGrP.Tables(0))

            sParaTDate = GDteTradeDate.Day & " " & lFncGetMonthStringFull(GDteTradeDate.Month) & " " & GDteTradeDate.Year
            sParaLTDate = ldteLTDate.Day & " " & lFncGetMonthStringFull(ldteLTDate.Month) & " " & ldteLTDate.Year
            sParaLMTDate = ldteLMTDate.Day & " " & lFncGetMonthStringFull(ldteLMTDate.Month) & " " & ldteLMTDate.Year
            sParaShowTDate = GDteTradeDate.Day & " " & lFncGetMonthStringFull(GDteTradeDate.Month) & " " & GDteTradeDate.Year

            clsRpt.AddParam(rpt, "paraTDate", sParaTDate)
            clsRpt.AddParam(rpt, "paraLTDate", sParaLTDate)
            clsRpt.AddParam(rpt, "paraLMTDate", sParaLMTDate)
            clsRpt.AddParam(rpt, "paraShowTDate", "Trade Date: " & sParaShowTDate)
            'clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd-MMM-yy"))
            'clsRpt.AddParam(rpt, "paraLTDate", Format(ldteLTDate, "dd-MMM-yy"))
            'clsRpt.AddParam(rpt, "paraLMTDate", Format(ldteLMTDate, "dd-MMM-yy"))
            'clsRpt.AddParam(rpt, "paraShowTDate", "Trade Date: " & Format(GDteTradeDate, "dd MMMM, yyyy"))
            clsRpt.AddParam(rpt, "paraSubRptTitle", "Client Balance Summary Report for DR Balance >" & dr_Bal)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraTitle", titleStr)
            clsRpt.AddParam(rpt, "parawithsummary", blnWithSummary)
            clsRpt.AddParam(rpt, "paraRegard", regard)
            clsRpt.AddParam(rpt, "paraNoted1", noted1)
            clsRpt.AddParam(rpt, "paraNoted2", noted2)
            clsRpt.AddParam(rpt, "paraNoted3", noted3)
            clsRpt.AddParam(rpt, "paraEndor1", endor1)
            clsRpt.AddParam(rpt, "paraEndor2", endor2)
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Client Balance Summary Report")
        End If

    End Function

    Protected Friend Function lFncExportCSV(ByVal condition As String, ByVal dr_Bal As Double, ByVal groupCondition As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = " clt_type, clt_status, clt_code, clt_name, run_code, avail_bal, " & _
                                "dr_bal, cr_bal, interest, cr_limit, mkt_value, mc_act_ratio, " & _
                                "margin_value, margin_ratio "
        Dim ldtsBalSum As DataSet = Nothing
        Dim ldtsAmtAE As DataSet = Nothing
        Dim ldtsAmtGrP As DataSet = Nothing
        Dim strExFile As String = "ClientBalSum" & Format(Now(), "yyyyMMdd") & ".csv"
        Dim strExFile2 As String = "ClientBalSumAE" & Format(Now(), "yyyyMMdd") & ".csv"
        Dim strExFile3 As String = "ClientBalSumGroup" & Format(Now(), "yyyyMMdd") & ".csv"
        Dim ldteLTDate As Date
        Dim ldteLMTDate As Date
        Try
            MyTrans = GSCnLiqConn.BeginTransaction
            ldteLTDate = lfncGetTradeDate(MyTrans, "LastTDate", GDteTradeDate)
            ldteLMTDate = lfncGetTradeDate(MyTrans, "LastTMDate", ldteLTDate)
            ldtsBalSum = lFncGetBalSum("*", MyTrans, dr_Bal, condition)
            ldtsAmtAE = lFncGetAEBal(MyTrans, dr_Bal)
            ldtsAmtGrP = lFncGetGroupBal(MyTrans, dr_Bal, ldteLTDate, ldteLMTDate, groupCondition)
            lFncCleanBalSum(MyTrans)
            lFncCleanAEBal(MyTrans)
            lFncCleanGroupBal(MyTrans)
            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        If (GExportCSV(GStrExptDir, strExFile, ldtsBalSum, lstrSQL)) Then
            If (GExportCSV(GStrExptDir, strExFile2, ldtsAmtAE, " AE, Name, Dr Bal ")) Then
                If (GExportCSV(GStrExptDir, strExFile3, ldtsAmtGrP, " Group, Curr Date, Prev Date ")) Then
                    Return True
                End If
            End If
        End If
        Return False
    End Function

    'Protected Friend Function lFncGetBalSumRpt(ByVal condition As String, ByVal titleStr As String, ByVal Dr_Bal As Double) As ReportClass
    '    Dim MyTrans As SqlTransaction = Nothing
    '    Dim lstrSQL As String = ""
    '    Dim ldtsBalSum As DataSet = Nothing
    '    Dim ldtsAmtAE As DataSet = Nothing
    '    Dim ldtsAmtGrP As DataSet = Nothing
    '    Dim rpt As New RptCltBalSum

    '    Try
    '        MyTrans = GSCnLiqConn.BeginTransaction

    '        lstrSQL = "select clt_code, 'CLOSE' as status_type, cls_date as stop_date " & _
    '                     "into #clientstatus " & _
    '                     "FROM teststatus WHERE stop = 'Y' AND not(cls_date is null) " & _
    '                     "UNION all " & _
    '                     "select clt_code, 'SUSP' as status_type, susp_date as stop_date " & _
    '                     "FROM teststatus WHERE stop = 'Y' AND cls_date is null"
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    '        lstrSQL = "SELECT mas.clt_code, clt_name, run_code, t1_unrealized, t2_unrealized, clt_type, " & _
    '                    "(dr_bal * (-1)) -t1_unrealized-t2_unrealized as ava_bal, dr_bal, cr_bal, interest, cr_limit, " & _
    '                    "mkt_value, mc_act_ratio, margin_value, isnull(status_type, 'ACT') as clt_status, margin_ratio " & _
    '                    "into #balsummary " & _
    '                    "FROM stcltmaster mas " & _
    '                    "LEFT OUTER JOIN #clientstatus st ON mas.clt_code = st.clt_code where dr_bal <> 0 " & _
    '                    "UNION ALL " & _
    '                    "SELECT mas.clt_code, clt_name, run_code, t1_unrealized, t2_unrealized, clt_type, " & _
    '                    "cr_bal -t1_unrealized-t2_unrealized as ava_bal, dr_bal, cr_bal, interest, cr_limit, " & _
    '                    "mkt_value, mc_act_ratio, margin_value, isnull(status_type, 'ACT') as clt_status, margin_ratio " & _
    '                    "FROM stcltmaster mas " & _
    '                    "LEFT OUTER JOIN #clientstatus st ON mas.clt_code = st.clt_code where cr_bal <> 0 " & _
    '                    "UNION ALL " & _
    '                    "SELECT mas.clt_code, clt_name, run_code, t1_unrealized, t2_unrealized, clt_type, " & _
    '                    "cr_bal -t1_unrealized-t2_unrealized as ava_bal, dr_bal, cr_bal, interest, cr_limit, " & _
    '                    "mkt_value, mc_act_ratio, margin_value, isnull(status_type, 'ACT') as clt_status, margin_ratio " & _
    '                    "FROM stcltmaster mas " & _
    '                    "LEFT OUTER JOIN #clientstatus st ON mas.clt_code = st.clt_code where cr_bal = 0 AND dr_bal = 0 "
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

    '        'lstrSQL = "SELECT clt_code, clt_name, run_code, t1_unrealized, t2_unrealized, clt_type, ava_bal, " & _
    '        '            "dr_bal, cr_bal, interest, cr_limit, mkt_value, mc_act_ratio, margin_value, clt_status, " & _
    '        '            "margin_ratio, case when (cr_bal <> 0 or dr_bal <> 0) then ava_bal else 0 end as avail_bal " & _
    '        '            "FROM #balsummary WHERE clt_type in ('C', 'M') " & condition
    '        'ldtsBalSum = GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)

    '        lstrSQL = "SELECT clt_code, clt_name, run_code, t1_unrealized, t2_unrealized, clt_type, ava_bal, " & _
    '                    "dr_bal, cr_bal, interest, cr_limit, mkt_value, mc_act_ratio, margin_value, clt_status, " & _
    '                    "margin_ratio, case when (cr_bal <> 0 or dr_bal <> 0) then ava_bal else 0 end as avail_bal " & _
    '                    "into #CltBalSum " & _
    '                    "FROM #balsummary WHERE clt_type in ('C', 'M') " & condition
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

    '        lstrSQL = "Select * from #CltBalSum "
    '        ldtsBalSum = GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)

    '        lstrSQL = "select b.run_code, b.run_name, sum(a.dr_bal) as TDr_Bal into #AEDrBal " & _
    '                            "FROM #CltBalSum a left outer join STAEMASTER b on b.run_code=a.run_code " & _
    '                            "group by b.run_code, b.run_name "
    '        GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)

    '        lstrSQL = "select run_code, run_Name, tdr_Bal from #AEDrBal where TDr_Bal>=" & Dr_Bal & " and TDr_Bal>0 order by TDr_Bal desc "
    '        ldtsAmtAE = GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)

    '        lstrSQL = "select run_name, GPBal into #AEGrPDrBal from " & _
    '                            "(select run_name, sum(tdr_bal) as GPBal from #AEDrBal group by run_name) a " & _
    '                            "where GPBal >" & Dr_Bal & " and GPBal >0 order by GPBal desc "
    '        GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)

    '        lstrSQL = "select b.run_code, STAEMaster.run_name, a.led_bal into #lebdBal " & _
    '                            "from balance.dbo.acbal a left outer join stcltmaster b on a.accno =b.clt_code collate database_default " & _
    '                            "left outer join STAEMaster on b.run_code = STAEMaster.run_code " & _
    '                            "where led_bal<0 and tdate='" & Format(GDteTradeDate.AddDays(-1), "yyyy/MM/dd") & "' order by b.run_code "
    '        GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)

    '        lstrSQL = "select run_name, sum(led_bal)*-1 as d_bal into #LastDBal from #lebdBal group by run_name "
    '        GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)

    '        lstrSQL = "select a.run_name, a.GPBal, isnull(b.d_bal,0) as GPBal_L " & _
    '                            "from #AEGrPDrBal a left outer join #LastDBal b on a.run_name= b.run_name " & _
    '                            "order by a.GPBal desc "
    '        ldtsAmtGrP = GFncRtnDS(GSCnLiqConn, lstrSQL, MyTrans)


    '        lstrSQL = "drop table #clientstatus "
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    '        lstrSQL = "drop table #balsummary "
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    '        lstrSQL = "drop table #CltBalSum"
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    '        lstrSQL = "drop table #AEDrBal "
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    '        lstrSQL = "drop table #AEGrPDrBal "
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    '        lstrSQL = "drop table #lebdBal "
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)
    '        lstrSQL = "drop table #LastDBal "
    '        GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0)

    '        MyTrans.Commit()
    '        MyTrans = Nothing
    '    Catch ex As Exception
    '        If GSCnLiqConn.State <> ConnectionState.Closed Then
    '            If (MyTrans IsNot Nothing) Then
    '                MyTrans.Rollback()
    '            End If
    '            GSubWriteErrLog(ex.Message)
    '        End If
    '    End Try
    '    If ldtsBalSum.Tables(0).Rows.Count > 0 Then
    '        rpt.SetDataSource(ldtsBalSum.Tables(0))
    '        rpt.Subreports("RptCltBalSubAE").SetDataSource(ldtsAmtAE.Tables(0))
    '        rpt.Subreports("RptCltBalSumSub").SetDataSource(ldtsAmtGrP.Tables(0))
    '        clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
    '        clsRpt.AddParam(rpt, "paraLTDate", Format(GDteTradeDate.AddDays(-1), "dd/MM/yyyy"))
    '        clsRpt.AddParam(rpt, "paraShowTDate", "Trade Date: " & Format(GDteTradeDate, "dd MMMM, yyyy"))
    '        clsRpt.AddParam(rpt, "paraSubRptTitle", "Client Balance Summary Report for DR Balance >" & Dr_Bal)
    '        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
    '        clsRpt.AddParam(rpt, "paraTitle", titleStr)
    '        Return rpt
    '    Else
    '        Return clsRpt.lfncRtnEmptyRpt("Client Balance Summary Report")
    '    End If

    'End Function

    Protected Friend Function lFncMiscMst(ByVal isEmptySet As Boolean) As DataTable
        Dim lstrSQL As String = ""

        lstrSQL = "select misc_code, misc_desc from misc_master where misc_type = 'CltBalMaster'"
        If (isEmptySet) Then
            lstrSQL = lstrSQL & " and 1<>1"
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
    End Function

    Protected Friend Function lFncList(ByVal misc_type As String, ByVal isEmptySet As Boolean) As DataTable
        Dim lstrSQL As String = ""

        lstrSQL = "select misc_code as code, misc_desc as descpt from misc_master where misc_type = '" & misc_type & "'"
        If (isEmptySet) Then
            lstrSQL = lstrSQL & " and 1<>1"
        End If
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
    End Function

    Protected Friend Function lFncIsExist(ByVal misc_type As String, ByVal misc_code As String) As Boolean
        Dim lstrSQL As String = ""
        Dim ldsTemp As DataSet = Nothing

        lstrSQL = "select misc_code from misc_master where misc_type = '" & misc_type & "' and misc_code = '" & misc_code & "'"
        ldsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        If (ldsTemp.Tables(0).Rows.Count > 0) Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function lFncDeleteItem(ByVal misc_type As String, ByVal key As String, ByVal MyTrans As SqlTransaction) As Boolean
        Dim lstrSQL As String = ""

        lstrSQL = "delete from misc_master where misc_type = '" & misc_type & "' and misc_code = '" & key & "'"
        If (GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) > 0) Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function lFncSaveItem(ByVal misc_type As String, ByVal key As String, ByVal val As String, _
                                            ByVal MyTrans As SqlTransaction) As Boolean
        Dim lstrSQL As String = ""

        lstrSQL = "update misc_master set misc_desc = '" & val & "' where misc_type = '" & misc_type & "' and misc_code = '" & key & "'"
        If (GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) > 0) Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function lFncAddItem(ByVal misc_type As String, ByVal key As String, ByVal val As String, _
                                        ByVal MyTrans As SqlTransaction) As Boolean
        Dim lstrSQL As String = ""

        lstrSQL = "insert into misc_master(misc_type, misc_code, misc_desc) values('" & _
                    misc_type & "', '" & key & "', '" & val & "')"
        If (GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) > 0) Then
            Return True
        End If
        Return False
    End Function

    Protected Friend Function setSignature(ByVal regard As String, ByVal noted1 As String, ByVal noted2 As String, _
                                            ByVal noted3 As String, ByVal endor1 As String, ByVal endor2 As String) As Boolean
        Dim lstrSQL As String = ""
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            lstrSQL = "Update misc_master set misc_desc = '" & regard & _
                        "' where misc_type = 'CltBalSumSign' and misc_code = 'regard' "
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            lstrSQL = "Update misc_master set misc_desc = '" & noted1 & _
                        "' where misc_type = 'CltBalSumSign' and misc_code = 'noted1' "
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            lstrSQL = "Update misc_master set misc_desc = '" & noted2 & _
                        "' where misc_type = 'CltBalSumSign' and misc_code = 'noted2' "
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            lstrSQL = "Update misc_master set misc_desc = '" & noted3 & _
                        "' where misc_type = 'CltBalSumSign' and misc_code = 'noted3' "
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            lstrSQL = "Update misc_master set misc_desc = '" & endor1 & _
                        "' where misc_type = 'CltBalSumSign' and misc_code = 'endor1' "
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            lstrSQL = "Update misc_master set misc_desc = '" & endor2 & _
                        "' where misc_type = 'CltBalSumSign' and misc_code = 'endor2' "
            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If

            MyTrans.Commit()
            MyTrans = Nothing
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function getSignature() As DataTable
        Dim lstrSQL As String = ""

        lstrSQL = "select misc_code, misc_desc from misc_master where misc_type = 'CltBalSumSign'"
        Return GFncRtnDS(GSCnSqlConn, lstrSQL, 0).Tables(0)
    End Function

    Protected Friend Function lFncExportExcel(ByVal condition As String, ByVal dr_Bal As Double, _
                                              ByVal sign1 As String, ByVal sign2 As String, _
                                              ByVal sign3 As String, ByVal sign4 As String, _
                                              ByVal sign5 As String, ByVal sign6 As String, _
                                              ByVal groupCondition As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = " clt_type, clt_status, clt_code, clt_name, run_code, avail_bal, " & _
                                "dr_bal, cr_bal, interest, cr_limit, mkt_value, mc_act_ratio, " & _
                                "margin_value, margin_ratio "
        Dim ldtsBalSum As DataSet = Nothing
        Dim ldtsAmtAE As DataSet = Nothing
        Dim ldtsAmtGrP As DataSet = Nothing
        Dim strExFile As String = "ClientBalSummary" & Format(Now(), "yyyyMMdd") & ".xls"
        Dim ldteLTDate As Date
        Dim ldteLMTDate As Date
        Dim strFiles() As String

        Dim alignCentre As Integer = -4108
        Dim alignRight As Integer = -4152
        Dim edgeTop As Integer = 8
        Dim edgeBottom As Integer = 9
        Dim continuous As Integer = 1
        Dim ldouble As Integer = -4119
        Dim dot As Integer = -4118


        Try
            MyTrans = GSCnLiqConn.BeginTransaction
            ldteLTDate = lfncGetTradeDate(MyTrans, "LastTDate", GDteTradeDate)
            ldteLMTDate = lfncGetTradeDate(MyTrans, "LastTMDate", ldteLTDate)
            ldtsBalSum = lFncGetBalSum("*", MyTrans, dr_Bal, condition)
            ldtsAmtAE = lFncGetAEBal(MyTrans, dr_Bal)
            ldtsAmtGrP = lFncGetGroupBal(MyTrans, dr_Bal, ldteLTDate, ldteLMTDate, groupCondition)
            lFncCleanBalSum(MyTrans)
            lFncCleanAEBal(MyTrans)
            lFncCleanGroupBal(MyTrans)
            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        Dim xlApp As Object
        Dim xlWorkBook As Object
        Dim xlWorkSheet As Object
        Dim xlRange As Object

        xlApp = CreateObject("Excel.Application")
        xlWorkBook = xlApp.Workbooks.Add()
        xlWorkBook.Activate()
        xlApp.Visible = False
        xlWorkSheet = xlWorkBook.Worksheets(1)
        Try
            strFiles = System.IO.Directory.GetFiles(GStrExptDir, strExFile)
            For Each strFile As String In strFiles
                Application.DoEvents()
                System.IO.File.Delete(strFile)
            Next

            xlWorkSheet.Columns("A:A").ColumnWidth = 8.38
            xlWorkSheet.Columns("B:B").ColumnWidth = 22
            xlWorkSheet.Columns("C:C").ColumnWidth = 18.75
            xlWorkSheet.Columns("D:D").ColumnWidth = 14
            xlWorkSheet.Columns("E:E").ColumnWidth = 22.63
            xlWorkSheet.Columns("F:F").ColumnWidth = 17.25
            xlWorkSheet.Columns("G:G").ColumnWidth = 18.38
            xlWorkSheet.Columns("H:H").ColumnWidth = 16.38

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(1, 3), xlWorkSheet.Cells(1, 3))
            xlRange.Font.Bold = True
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Arial"
            xlWorkSheet.Cells(1, 3) = "Emperor Securities Ltd"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(1, 3), xlWorkSheet.Cells(1, 5))
            xlRange.Merge()
            xlRange.HorizontalAlignment = alignCentre

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(2, 3), xlWorkSheet.Cells(2, 3))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Arial"
            xlWorkSheet.Cells(2, 3) = "Client Balance Summary Report for DR Balance >500,000"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(2, 3), xlWorkSheet.Cells(2, 5))
            xlRange.Merge()
            xlRange.HorizontalAlignment = alignCentre

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(2, 6), xlWorkSheet.Cells(2, 6))
            xlRange.Font.Bold = True
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(2, 6) = "Transaction Date:"
            xlRange.HorizontalAlignment = alignRight

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(2, 7), xlWorkSheet.Cells(2, 7))
            xlRange.Font.Bold = True
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(2, 7) = GDteTradeDate
            xlRange.NumberFormat = "dd mmmm, yyyy;@"

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(4, 7), xlWorkSheet.Cells(4, 7))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(4, 7) = "Debit Balance"
            xlRange.HorizontalAlignment = alignCentre

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 1), xlWorkSheet.Cells(5, 1))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(5, 1) = "AE"

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 2), xlWorkSheet.Cells(5, 2))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(5, 2) = "Name"

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 3), xlWorkSheet.Cells(5, 3))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(5, 3) = "Debit Balance"
            xlRange.HorizontalAlignment = alignRight

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(5, 5))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(5, 5) = "Group"
            xlRange.HorizontalAlignment = alignCentre

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 6), xlWorkSheet.Cells(5, 6))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(5, 6) = GDteTradeDate
            xlRange.HorizontalAlignment = alignCentre
            xlRange.NumberFormat = "dd-mmm-yy;@"

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 7), xlWorkSheet.Cells(5, 7))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlRange.Font.Color = 8421504
            xlWorkSheet.Cells(5, 7) = lfncGetTradeDate(MyTrans, "LastTDate", GDteTradeDate)
            xlRange.HorizontalAlignment = alignCentre
            xlRange.NumberFormat = "dd-mmm-yy;@"

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 8), xlWorkSheet.Cells(5, 8))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlRange.Font.Color = 8421504
            xlWorkSheet.Cells(5, 8) = lfncGetTradeDate(MyTrans, "LastTMDate", ldteLTDate)
            xlRange.HorizontalAlignment = alignCentre
            xlRange.NumberFormat = "dd-mmm-yy;@"

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(4, 6), xlWorkSheet.Cells(4, 8))
            xlRange.Borders(edgeBottom).Color = 0
            xlRange.Borders(edgeBottom).LineStyle = dot
            xlRange.Borders(edgeBottom).Weight = 1

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 1), xlWorkSheet.Cells(5, 3))
            xlRange.Borders(edgeBottom).Color = 0
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(5, 5), xlWorkSheet.Cells(5, 8))
            xlRange.Borders(edgeBottom).Color = 0
            xlRange.Borders(edgeBottom).LineStyle = continuous
            xlRange.Borders(edgeBottom).Weight = 2

            Dim rowAE As Integer = 0
            For rowAE = 0 To ldtsAmtAE.Tables(0).Rows.Count - 1
                Application.DoEvents()
                xlWorkSheet.Cells(rowAE + 6, 1) = ldtsAmtAE.Tables(0).Rows(rowAE).Item("run_code").ToString.Trim
                xlWorkSheet.Cells(rowAE + 6, 2) = ldtsAmtAE.Tables(0).Rows(rowAE).Item("run_Name").ToString.Trim
                xlWorkSheet.Cells(rowAE + 6, 3) = ldtsAmtAE.Tables(0).Rows(rowAE).Item("tdr_bal")
            Next
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(rowAE + 6, 1), xlWorkSheet.Cells(rowAE + 6, 3))
            xlRange.Font.Bold = True
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(rowAE + 6, 1) = "Total"
            xlWorkSheet.Cells(rowAE + 6, 3) = "=SUM(C6:C" & rowAE + 5 & ")"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(rowAE + 6, 1), xlWorkSheet.Cells(rowAE + 6, 3))
            xlRange.Borders(edgeTop).Color = 0
            xlRange.Borders(edgeTop).LineStyle = continuous
            xlRange.Borders(edgeTop).Weight = 2
            xlRange.Borders(edgeBottom).Color = 0
            xlRange.Borders(edgeBottom).LineStyle = ldouble
            xlRange.Borders(edgeBottom).Weight = 4
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(6, 3), xlWorkSheet.Cells(rowAE + 6, 3))
            xlRange.NumberFormat = "#,##0.00_);(#,##0.00)"

            Dim rowAmt As Integer = 0
            For rowAmt = 0 To ldtsAmtGrP.Tables(0).Rows.Count - 1
                Application.DoEvents()
                xlWorkSheet.Cells(rowAmt + 6, 5) = ldtsAmtGrP.Tables(0).Rows(rowAmt).Item("run_name").ToString.Trim
                xlWorkSheet.Cells(rowAmt + 6, 6) = ldtsAmtGrP.Tables(0).Rows(rowAmt).Item("GPBal")
                xlWorkSheet.Cells(rowAmt + 6, 7) = ldtsAmtGrP.Tables(0).Rows(rowAmt).Item("GPBal_L")
                xlWorkSheet.Cells(rowAmt + 6, 8) = ldtsAmtGrP.Tables(0).Rows(rowAmt).Item("GPBal_LM")
            Next
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(6, 7), xlWorkSheet.Cells(rowAmt + 6, 8))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlRange.Font.Color = 8421504

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(rowAmt + 6, 5), xlWorkSheet.Cells(rowAmt + 6, 8))
            xlRange.Font.Bold = True
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(rowAmt + 6, 5) = "Total"
            xlWorkSheet.Cells(rowAmt + 6, 6) = "=SUM(F6:F" & rowAmt + 5 & ")"
            xlWorkSheet.Cells(rowAmt + 6, 7) = "=SUM(G6:G" & rowAmt + 5 & ")"
            xlWorkSheet.Cells(rowAmt + 6, 8) = "=SUM(H6:H" & rowAmt + 5 & ")"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(rowAmt + 6, 5), xlWorkSheet.Cells(rowAmt + 6, 8))
            xlRange.Borders(edgeTop).Color = 0
            xlRange.Borders(edgeTop).LineStyle = continuous
            xlRange.Borders(edgeTop).Weight = 2
            xlRange.Borders(edgeBottom).Color = 0
            xlRange.Borders(edgeBottom).LineStyle = ldouble
            xlRange.Borders(edgeBottom).Weight = 4
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(6, 6), xlWorkSheet.Cells(rowAE + 6, 8))
            xlRange.NumberFormat = "#,##0.00_);(#,##0.00)"

            Dim row As Integer = 0
            If (rowAE > rowAmt) Then
                row = rowAE
            Else
                row = rowAmt
            End If

            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 10, 1), xlWorkSheet.Cells(row + 10, 1))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 10, 1) = "Regards,"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 10, 4), xlWorkSheet.Cells(row + 10, 4))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 10, 4) = "Noted by:"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 10, 7), xlWorkSheet.Cells(row + 10, 7))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 10, 7) = "Noted by:"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 13, 1), xlWorkSheet.Cells(row + 13, 1))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 13, 1) = "________________"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 13, 4), xlWorkSheet.Cells(row + 13, 4))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 13, 4) = "________________"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 13, 7), xlWorkSheet.Cells(row + 13, 7))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 13, 7) = "________________"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 14, 1), xlWorkSheet.Cells(row + 14, 1))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 14, 1) = sign1
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 14, 4), xlWorkSheet.Cells(row + 14, 4))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 14, 4) = sign2
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 14, 7), xlWorkSheet.Cells(row + 14, 7))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 14, 7) = sign3
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 16, 1), xlWorkSheet.Cells(row + 16, 1))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 16, 1) = "Noted by:"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 16, 4), xlWorkSheet.Cells(row + 16, 4))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 16, 4) = "Endorsor:"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 16, 7), xlWorkSheet.Cells(row + 16, 7))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 16, 7) = "Endorsor:"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 19, 1), xlWorkSheet.Cells(row + 19, 1))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 19, 1) = "________________"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 19, 4), xlWorkSheet.Cells(row + 19, 4))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 19, 4) = "________________"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 19, 7), xlWorkSheet.Cells(row + 19, 7))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 19, 7) = "________________"
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 20, 1), xlWorkSheet.Cells(row + 20, 1))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 20, 1) = sign4
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 20, 4), xlWorkSheet.Cells(row + 20, 4))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 20, 4) = sign5
            xlRange = xlWorkSheet.Range(xlWorkSheet.Cells(row + 20, 7), xlWorkSheet.Cells(row + 20, 7))
            xlRange.Font.Size = 12
            xlRange.Font.Name = "Times New Roman"
            xlWorkSheet.Cells(row + 20, 7) = sign6

            xlWorkBook.SaveAs(GStrExptDir & strExFile)
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlWorkSheet)
            releaseObject(xlWorkBook)
            releaseObject(xlApp)
            GC.Collect()
            GC.WaitForPendingFinalizers()

            Return True
        Catch ex As Exception
            xlWorkBook.close()
            xlApp.Quit()
            GC.Collect()
            GSubWriteErrLog(ex.Message)
            'GSubShowInfo(GFncGetSysMsg(89))
        End Try

        Return False
    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

End Class
