Imports System.Math
Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class clsRptCCT

    Protected Friend Function FncGenRpt(ByVal startDate As String, ByVal endDate As String) As ReportClass
        Dim rpt As ReportClass = New rptCCT
        Dim dt As DataTable = New dtsCCT.CCTDataTable
        Dim rateDT As DataTable
        startDate = Format(CDate(startDate), "yyyy/MM/dd 00:00:00")
        endDate = Format(CDate(endDate), "yyyy/MM/dd 23:59:59")
        'startDate = Format(CDate(startDate), "2008/04/01 00:00:00")
        'endDate = Format(CDate(endDate), "2009/09/30 23:59:59")
        Dim conStr As String = "between '" & startDate & "' and '" & endDate & "' "
        Dim str As String
        'If type Then
        '    'str = "select a.LIST_NAME as AccGroup, a.CLT_CODE as account, c.name_1 as accName, sum(b.COMM) as comm, " & _
        '    '        "c.brokerage_income as commRate, sum(d.INTerest) as interest, c.int_1 as int1, c.int_2 as int2, c.int_3 as int3, " & _
        '    '        "c.int_code as interestRate from " & GStrConDB & ".dbo.CONTRAN a inner join " & GStrG2BSDB & ".dbo.view_it_client_all c on " & _
        '    '        "a.clt_code = c.accno left join esl_liq_dev.dbo.MONTHCOMM b on a.CLT_CODE = b.accno and b.mth " & conStr & _
        '    '        "left join esl_liq_dev.dbo.MONTHINT d on a.clt_code = d.accno and d.mth " & conStr & "group by " & _
        '    '        "a.LIST_NAME, a.CLT_CODE, c.name_1, c.brokerage_income, c.int_code, c.int_1, c.int_2, c.int_3 order by a.CLT_CODE"
        '    str = "select a.LIST_NAME as AccGroup, a.CLT_CODE as account, c.name_1 as accName, sum(b.COMM) as comm, " & _
        '                        "c.brokerage_income as commRate, 0.00 as interest, c.int_1 as int1, c.int_2 as int2, c.int_3 as int3, " & _
        '                        "c.int_code as interestRate from " & GStrConDB & ".dbo.CONTRAN a inner join " & GStrG2BSDB & _
        '                        ".dbo.view_it_client_all c on a.clt_code = c.accno left join esl_liq_dev.dbo.MONTHCOMM b on " & _
        '                        "a.CLT_CODE = b.accno and b.mth " & conStr & "group by a.LIST_NAME, a.CLT_CODE, c.name_1, " & _
        '                        "c.brokerage_income, c.int_code, c.int_1, c.int_2, c.int_3 order by a.CLT_CODE"
        '    dt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        '    str = "select a.CLT_CODE as account, sum(d.INTerest) as interest from " & GStrConDB & ".dbo.CONTRAN a left join " & _
        '            "esl_liq_dev.dbo.MONTHINT d on a.clt_code = d.accno and d.mth " & conStr & "group by a.CLT_CODE order by a.CLT_CODE"
        '    rateDT = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        '    For Each dr As DataRow In dt.Rows
        '        For Each rateDr As DataRow In rateDT.Rows
        '            If dr("account").ToString.Trim = rateDr("account").ToString.Trim Then
        '                dr("interest") = GFncNoNullValue(rateDr("interest"))
        '                Exit For
        '            End If
        '        Next
        '    Next
        'Else
        '    'str = "select a.LIST_NAME as AccGroup, a.CLT_CODE as account, c.name_1 as accName, sum(b.COMM) as comm, e.name as commRate, " & _
        '    '        "sum(d.INTerest) as interest, NULL as int1, NULL as int2, NULL as int3, c.int_code as interestRate " & _
        '    '        "from " & GStrConDB & ".dbo.CONTRAN a inner join " & GStrG2BFDB & ".dbo.view_it_client_all c on a.clt_code = c.accno " & _
        '    '        "left join esl_liq_dev.dbo.MONTHCOMMF b on a.CLT_CODE = b.accno and b.mth " & conStr & _
        '    '        "left join esl_liq_dev.dbo.MONTHINT d on a.clt_code = d.accno and d.mth " & conStr & _
        '    '        "left join " & GStrG2BFDB & ".dbo.client_master f on a.clt_code = f.accno left join " & GStrG2BFDB & _
        '    '        ".dbo.client_master_f g on f.aid = g.aid left join " & GStrG2BFDB & ".dbo.fee_class e on g.fcid = e.fcid " & _
        '    '        "group by a.LIST_NAME, a.CLT_CODE, c.name_1, c.int_code, e.name order by a.CLT_CODE"
        '    str = "select a.CLT_CODE as account, sum(d.INTerest) as interest from " & GStrConDB & ".dbo.CONTRAN a left join " & _
        '                       "esl_liq_dev.dbo.MONTHINT d on a.clt_code = d.accno and d.mth " & conStr & "group by a.CLT_CODE order by a.CLT_CODE"
        '    rateDT = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        '    str = "select a.LIST_NAME as AccGroup, a.CLT_CODE as account, c.name_1 as accName, sum(b.COMM) as comm, e.name as commRate, " & _
        '            "0.00 as interest, NULL as int1, NULL as int2, NULL as int3, c.int_code as interestRate " & _
        '            "from " & GStrConDB & ".dbo.CONTRAN a inner join " & GStrG2BFDB & ".dbo.view_it_client_all c on a.clt_code = c.accno " & _
        '            "left join esl_liq_dev.dbo.MONTHCOMMF b on a.CLT_CODE = b.accno and b.mth " & conStr & _
        '            "left join " & GStrG2BFDB & ".dbo.client_master f on a.clt_code = f.accno left join " & GStrG2BFDB & _
        '            ".dbo.client_master_f g on f.aid = g.aid left join " & GStrG2BFDB & ".dbo.fee_class e on g.fcid = e.fcid " & _
        '            "group by a.LIST_NAME, a.CLT_CODE, c.name_1, c.int_code, e.name order by a.CLT_CODE"
        '    dt = GFncRtnDS(GSCnSqlConn, str, 0).Tables(0)
        '    For Each dr As DataRow In dt.Rows
        '        For Each rateDr As DataRow In rateDT.Rows
        '            If dr("account").ToString.Trim = rateDr("account").ToString.Trim Then
        '                dr("interest") = GFncNoNullValue(rateDr("interest"))
        '                Exit For
        '            End If
        '        Next
        '    Next
        'End If
        str = "select a.LIST_NAME as AccGroup, a.CLT_CODE as account, c.name_1 as accName, sum(b.comm+b.adj) as comm, " & _
                "c.brokerage_income as commRate, 0.00 as interest, c.int_1 as int1, c.int_2 as int2, c.int_3 as int3, 0.00 as comm1, " & _
                "c.int_code as interestRate, '' as commRate1 from " & GStrConDB & ".dbo.CONTRAN a left join " & GStrG2BSDB & _
                ".dbo.view_it_client_all c on a.clt_code collate database_default = c.accno collate database_default left join esl_liq.dbo.MONTHCOMM b on a.CLT_CODE collate database_default = b.accno collate database_default " & _
                "and b.mth " & conStr & "group by a.LIST_NAME, a.CLT_CODE, c.name_1, c.brokerage_income, c.int_code, c.int_1, c.int_2, " & _
                "c.int_3 order by a.CLT_CODE"
        dt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Dim dt1 As DataTable
        'str = "select a.LIST_NAME as AccGroup, a.CLT_CODE as account, c.name_1 as accName, sum(b.COMM+b.adj) as comm, e.name as commRate, " & _
        '        "c.int_code as interestRate from " & GStrConDB & ".dbo.CONTRAN a left join " & GStrG2BFDB & ".dbo.view_it_client_all c " & _
        '        "on a.clt_code = c.accno left join esl_liq_dev.dbo.MONTHCOMMF b on a.CLT_CODE = b.accno and b.mth " & conStr & _
        '        "left join " & GStrG2BFDB & ".dbo.client_master f on a.clt_code = f.accno left join " & GStrG2BFDB & _
        '        ".dbo.client_master_f g on f.aid = g.aid left join " & GStrG2BFDB & ".dbo.fee_class e on g.fcid = e.fcid " & _
        '        "group by a.LIST_NAME, a.CLT_CODE, c.name_1, c.int_code, e.name order by a.CLT_CODE"
        str = "select a.LIST_NAME as AccGroup, a.CLT_CODE as account, '' as accName, sum(b.COMM+b.adj) as comm, e.name as commRate, " & _
               "'' as interestRate from " & GStrConDB & ".dbo.CONTRAN a left join esl_liq.dbo.MONTHCOMMF b on " & _
               "a.CLT_CODE collate database_default = b.accno collate database_default and b.mth " & conStr & "left join " & GStrG2BFDB & ".dbo.client_master f on " & _
               "a.clt_code collate database_default = f.accno collate database_default left join " & GStrG2BFDB & ".dbo.client_master_f g on f.aid = g.aid left join " & _
               GStrG2BFDB & ".dbo.fee_class e on g.fcid = e.fcid " & "group by a.LIST_NAME, a.CLT_CODE, e.name order by a.CLT_CODE"
        dt1 = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Dim accDT As DataTable = GFncRtnDS(GSCnSqlConn, "select * from " & GStrG2BFDB & ".dbo.view_it_client_all order by accno").Tables(0)
        For Each dr1 As DataRow In dt1.Rows
            For Each accdr As DataRow In accDT.Rows
                If dr1("account").ToString.Trim = accdr("accno").ToString.Trim Then
                    dr1("accName") = accdr("name_1").ToString.Trim
                    dr1("interestRate") = accdr("int_code").ToString.Trim
                    Exit For
                End If
            Next
            For Each dr As DataRow In dt.Rows
                dr("comm") = GFncNoNullValue(dr("comm")) ' + GFncNoNullValue(dr("adj"))
                'dr("adj") = 0
                If dr1("account").ToString.Trim = dr("account").ToString.Trim Then
                    If GFncNoNullString(dr("AccName")).Trim = "" Then
                        dr("AccName") = GFncNoNullString(dr1("AccName")).Trim
                    End If
                    If Not IsDBNull(dr1("comm")) Then
                        dr("comm1") = GFncNoNullValue(dr1("comm")) ' + GFncNoNullValue(dr1("adj"))
                    End If
                    If Not IsDBNull(dr1("commRate")) Then
                        dr("commRate1") = GFncNoNullString(dr1("commRate")).Trim
                    End If
                    Exit For
                End If
            Next
        Next
        str = "select a.CLT_CODE as account, sum(d.INTerest+d.adj) as interest from " & GStrConDB & ".dbo.CONTRAN a left join " & _
                "esl_liq.dbo.MONTHINT d on a.clt_code collate database_default = d.accno collate database_default and d.mth " & conStr & "group by a.CLT_CODE order by a.CLT_CODE"
        rateDT = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        For Each dr As DataRow In dt.Rows
            For Each rateDr As DataRow In rateDT.Rows
                If dr("account").ToString.Trim = rateDr("account").ToString.Trim Then
                    dr("interest") = GFncNoNullValue(rateDr("interest")) '+ GFncNoNullValue(rateDr("adj"))
                    Exit For
                End If
            Next
        Next
        rpt.SetDataSource(dt)
        rpt.SetParameterValue("user", Trim(GStrloginID))
        rpt.SetParameterValue("startDate", CDate(startDate))
        rpt.SetParameterValue("endDate", CDate(endDate))
        Return rpt
    End Function
End Class
