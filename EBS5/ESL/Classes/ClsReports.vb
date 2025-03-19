Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine


Public Class ClsReports

    Public Sub AddParam(ByRef rpt As ReportClass, ByVal paraFldname As String, ByVal paraValue As Object)

        'set user id report parameter
        rpt.SetParameterValue(paraFldName, paraValue)

    End Sub

    Public Sub AddParam(ByRef rpt As ReportClass, ByVal paraFldname() As String, ByVal paraValue() As Object)
        Dim intCount As Integer
        'set user id report parameter
        For intCount = 0 To UBound(paraFldname)
            rpt.SetParameterValue(paraFldname(intCount), paraValue(intCount))
        Next

    End Sub

    '    Private Sub lsubSetCurrConfig(ByRef rpt As ReportClass)
    '        Dim lstrSQL As String
    '        Dim ldtsTConfig As DataSet

    '        lstrSQL = "Select * from Terms_config"

    '        ldtsTConfig = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        rpt.Database.Tables("Terms_Config").SetDataSource(ldtsTConfig.Tables(0))

    '    End Sub

    '    Private Sub lsubSetCurrConfig(ByRef rpt As ReportClass, ByVal strSubRptName As String)
    '        Dim lstrSQL As String
    '        Dim ldtsTConfig As DataSet

    '        lstrSQL = "Select * from Terms_config"

    '        ldtsTConfig = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        rpt.Subreports(strSubRptName).Database.Tables("Terms_Config").SetDataSource(ldtsTConfig.Tables(0))

    '    End Sub

    '    Public Function lFunGetAllTerms(Optional ByRef dtntrans As SqlTransaction = Nothing) As DataSet
    '        Dim lstrSQL As String
    '        Dim ldtsTerms As DataSet

    '        lstrSQL = "Select a.* from ac_terms a inner join currency b on a.d_currency = b.d_currency order by a.d_ano, a.d_currency "
    '        If IsNothing(dtntrans) Then
    '            ldtsTerms = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        Else
    '            ldtsTerms = GFncRtnDS(GSCnSqlConn, lstrSQL, dtntrans)
    '        End If

    '        Return ldtsTerms

    '    End Function

    '    Public Function lFunGetAllSales(Optional ByRef dtntrans As SqlTransaction = Nothing) As DataSet
    '        Dim lstrSQL As String
    '        Dim ldtsSales As DataSet

    '        lstrSQL = "Select * from sales order by d_sno "
    '        If IsNothing(dtntrans) Then
    '            ldtsSales = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        Else
    '            ldtsSales = GFncRtnDS(GSCnSqlConn, lstrSQL, dtntrans)
    '        End If

    '        Return ldtsSales

    '    End Function

    '    Private Function lFunGetSalesGroup(ByVal ldtsSales As DataSet, ByVal lstrSno As String) As String
    '        Dim ldtaSales() As DataRow

    '        ldtaSales = ldtsSales.Tables(0).Select(" d_sno = '" & lstrSno & "' ")
    '        If ldtaSales.Length <= 0 Then
    '            Return ""
    '        Else
    '            Return ldtaSales(0).Item("d_sgroup")
    '        End If

    '    End Function

    '    Public Function GFncPrintCLMarginCall() As ReportClass
    '        Dim rpt As New RptCLMarginCall
    '        Dim ldtsTemp As DataSet
    '        Dim lstrCrit As String = ""
    '        Dim lstrSQL As String = ""

    '        modcal.GSubCreateTmpAccTbl()
    '        modcal.GSubCreateTmpPriceTbl()

    '        modcal.GFncPrepareCutLoss()

    '        lstrSQL = "Select * from #TmpAcct order by d_ano "
    '        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        modcal.GSubDropTmpAccTbl()
    '        modcal.GSubDropTmpPriceTbl()
    '        If ldtsTemp.Tables(0).Rows.Count > 0 Then
    '            rpt.SetDataSource(ldtsTemp.Tables(0))
    '            AddParam(rpt, "paraTdate", ldtsTemp.Tables(0).Rows(0).Item("d_tdate"))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function GFncPrintOthBranchMargin() As ReportClass
    '        Dim rpt As New RptNetMarHis
    '        Dim frmDisp As New FrmRptDisplay
    '        Dim cls As New ClsReports
    '        Dim DStRpt As DataSet
    '        Dim DTbRpt As New DataTable
    '        Dim lstrCrit As String = ""
    '        Dim lstrSQL As String = ""

    '        lstrSQL = "Select (Select D_TDATE From [date]) as TDATE, a.d_ano as ANO, a.d_sname as SNAME, " & _
    '                    "b.d_sno as SNO, b.d_sname as AE_NAME, b.d_sgroup as SGRP, c.d_tdate as MAR_DATE, " & _
    '                    "Case When c.d_in_out = 'I' Then c.d_margin Else 0 End as MAR_IN, " & _
    '                    "Case When c.d_in_out = 'O' Then c.d_margin * -1 Else 0 End as MAR_OUT " & _
    '                 "From Account a inner join sales b on a.d_sno = b.d_sno inner join margin c on a.d_ano = c.d_ano " & _
    '                 "Where c.d_tdate = '" & Format(g_tdate, "yyyy/MM/dd") & "' Order by a.d_ano "

    '        DStRpt = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        DTbRpt = DStRpt.Tables(0)
    '        If DTbRpt.Rows.Count > 0 Then
    '            rpt.SetDataSource(DTbRpt)
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            lstrCrit = Format(g_tdate, "dd/MM/yyyy") & " - " & Format(g_tdate, "dd/MM/yyyy")
    '            AddParam(rpt, "paraDRange", lstrCrit)

    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function Executed_Open_Order_Rpt() As ReportClass

    '        Dim TDate As Date
    '        Dim DayNig As String
    '        Dim rpt As New RptExeOpnOrd
    '        Dim ldtsResult As DataSet

    '        'Insert statements for procedure here
    '        TDate = g_tdate
    '        'Dim RstDT As SqlDataReader
    '        Dim RtSDT As New DataSet
    '        RtSDT = GFncRtnDS(GSCnSqlConn, "Select D_DAY_NIG from [Date]")
    '        'RstDT.Read()
    '        DayNig = RtSDT.Tables(0).Rows(0).Item("D_DAY_NIG")
    '        RtSDT.Dispose()

    '        'Dim RstOrder As SqlDataReader
    '        Dim RtSOrder As New DataSet
    '        RtSOrder = GFncRtnDS(GSCnSqlConn, "select count(*) as CNT from [Order] where D_O_Date = '" & Format(TDate, "yyyy/MM/dd") & "'")
    '        'RstOrder.Read()
    '        If RtSOrder.Tables(0).Rows(0).Item("CNT") > 0 Then
    '            RtSOrder.Dispose()
    '            ldtsResult = GFncRtnDS(GSCnSqlConn, "Select D_Branch,D_Ord_no,[Order].D_ANO,Account.D_SNAME as A_SName,Sales.D_SNO," & _
    '                                        "Sales.D_SNAME as S_SName,D_Buy_Sell,D_CURRENCY,D_DAY_NIGT,D_LOTS2,D_O_PRICE,D_O_Date,'" & DayNig & "' as DayNig, " & _
    '                                        "(Select d_tdate from [date]) as t_date from [Order] left join Account on [Order].D_ano = Account.D_ano Left join Sales on [Order].D_Sno = Sales.D_Sno " & _
    '                                        "where D_O_Date = '" & Format(TDate, "yyyy/MM/dd") & "' and D_New_Liq = 'N' and D_State = 'O' order by D_Branch, D_Ord_no")


    '            'set report datasource first
    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            'set currency config
    '            lsubSetCurrConfig(rpt)

    '            'set parameter field value
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function Executed_Liq_Order_Rpt() As ReportClass

    '        Dim lstrSQL As String = ""
    '        Dim ldtsResult As DataSet
    '        Dim rpt As New RptExeLiqOrd
    '        'Insert statements for procedure here

    '        'lstrSQL = "select l.D_Branch, l.D_Ord_no,l.D_ANO, A.D_SNAME as A_SName,S.D_SNO,S.D_SGROUP,d.d_tdate as t_date," & _
    '        '        "S.D_SNAME as S_SName,l.D_Buy_Sell,l.D_CURRENCY,l.D_DAY_NIGT,l.D_LOTS,l.D_O_PRICE,l.D_O_Date," & _
    '        '        "'" & g_day_night & "' as DayNig, o.d_o_date as o_date, o.d_ord_no as o_ord_no, o.d_lots as o_lots, " & _
    '        '        "o.d_o_price as o_price from [date] d, [order] l, Account a, Sales s, " & _
    '        '        "(select * from [order] where d_state = 'L') o " & _
    '        '        "where l.d_new_liq = 'L' and l.d_state = 'O' and l.d_o_date = '" & Format(g_tdate, "yyyy/MM/dd") & "' and l.d_ord_type = o.d_op_type " & _
    '        '        "and l.d_ord_no = o.d_op_no and l.d_currency = o.d_currency and l.d_ord_type <> '" & GStrCutLossPrefix & "' " & _
    '        '        "and l.d_ano = a.d_ano and l.d_sno = s.d_sno " & _
    '        '        "order by l.d_o_date, l.d_ord_no "
    '        lstrSQL = "select l.D_Branch, l.D_Ord_no, l.D_Ord_Type, l.D_ANO, A.D_SNAME as A_SName,S.D_SNO,S.D_SGROUP,d.d_tdate as t_date," & _
    '                "S.D_SNAME as S_SName,l.D_Buy_Sell,l.D_CURRENCY,l.D_DAY_NIGT,l.D_LOTS,l.D_O_PRICE,l.D_O_Date," & _
    '                "'" & g_day_night & "' as DayNig, o.d_o_date as o_date, o.d_ord_no as o_ord_no, o.d_ord_type as o_ord_type, o.d_lots as o_lots, " & _
    '                "o.d_o_price as o_price from [date] d, [order] l, Account a, Sales s, " & _
    '                "(select * from [order] where d_state = 'L') o " & _
    '                "where l.d_new_liq = 'L' and l.d_state = 'O' and l.d_o_date = '" & Format(g_tdate, "yyyy/MM/dd") & "' and l.d_ord_type = o.d_op_type " & _
    '                "and l.d_ord_no = o.d_op_no and l.d_currency = o.d_currency " & _
    '                "and l.d_ano = a.d_ano and l.d_sno = s.d_sno " & _
    '                "order by l.d_o_date, l.d_ord_no, l.d_ord_type "


    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            'set report datasource first
    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            'set currency config
    '            lsubSetCurrConfig(rpt)

    '            'set parameter field value
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function Executed_Cutloss_Order_Rpt() As ReportClass

    '        Dim lstrSQL As String = ""
    '        Dim ldtsResult As DataSet
    '        Dim rpt As New RptExeCutLoss
    '        'Insert statements for procedure here

    '        lstrSQL = "select l.D_Branch, l.D_Ord_no,l.D_Ord_Type,l.D_ANO, A.D_SNAME as A_SName,S.D_SNO,S.D_SGROUP,d.d_tdate as t_date," & _
    '                "S.D_SNAME as S_SName,l.D_Buy_Sell,l.D_CURRENCY,l.D_DAY_NIGT,l.D_LOTS,l.D_O_PRICE,l.D_O_Date," & _
    '                "'" & g_day_night & "' as DayNig, o.d_o_date as o_date, o.d_ord_no as o_ord_no, o.d_ord_type as o_ord_type, o.d_lots as o_lots, " & _
    '                "o.d_o_price as o_price from [date] d, [order] l, Account a, Sales s, " & _
    '                "(select * from [order] where d_state = 'L') o " & _
    '                "where l.d_new_liq = 'L' and l.d_state = 'O' and l.d_o_date = '" & Format(g_tdate, "yyyy/MM/dd") & "' and l.d_ord_type = o.d_op_type " & _
    '                "and l.d_ord_no = o.d_op_no and l.d_currency = o.d_currency and l.d_ord_type = '" & GStrCutLossPrefix & "' " & _
    '                "and l.d_ano = a.d_ano and l.d_sno = s.d_sno " & _
    '                "order by l.d_o_date, l.d_ord_no "

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            'set report datasource first
    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            'set currency config
    '            lsubSetCurrConfig(rpt)

    '            'set parameter field value
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function
    '    Public Function Executed_Order_Rpt(ByVal strOrderBy As String, Optional ByVal strOrdFr As String = "", Optional ByVal strOrdTo As String = "", Optional ByVal strCurr As String = "") As ReportClass

    '        Dim lstrSQL As String = ""
    '        Dim lstrSQLHeader As String = ""
    '        Dim ldtsResult As DataSet
    '        Dim larrParaNames(1) As String
    '        Dim larrParaValues(1) As String
    '        Dim rpt As ReportClass = Nothing
    '        'Insert statements for procedure here

    '        'lstrSQL = "select l.D_Branch, l.D_Ord_no,l.D_ANO, A.D_SNAME as A_SName,S.D_SNO,d.d_tdate as t_date," & _
    '        '        "S.D_SNAME as S_SName,l.D_NEW_LIQ,l.D_Buy_Sell,l.D_CURRENCY,l.D_DAY_NIGT,l.D_LOTS,l.D_LOTS2,l.D_O_PRICE,l.D_O_Date,l.D_State," & _
    '        '        "'" & g_day_night & "' as DayNig, o.d_o_date as o_date, o.d_ord_no as o_ord_no, o.d_lots as o_lots, " & _
    '        '        "o.d_o_price as o_price from [date] d, [order] l, Account a, Sales s, " & _
    '        '        "(select * from [order] where d_state = 'L') o " & _
    '        '        "where l.d_state = 'O' and l.d_o_date = '" & Format(g_tdate, "yyyy/MM/dd") & "' and l.d_ord_type *= o.d_op_type " & _
    '        '        "and l.d_ord_no *= o.d_op_no and l.d_currency *= o.d_currency and l.d_ord_type <> '" & GStrCutLossPrefix & "' " & _
    '        '        "and l.d_ano = a.d_ano and l.d_sno = s.d_sno "
    '        lstrSQLHeader = "select l.D_Branch, l.D_Ord_no, l.D_Ord_Type, l.D_ANO, A.D_SNAME as A_SName,S.D_SNO,d.d_tdate as t_date," & _
    '                "S.D_SNAME as S_SName,l.D_NEW_LIQ,l.D_Buy_Sell,l.D_CURRENCY,l.D_DAY_NIGT,l.D_LOTS,l.D_LOTS2,l.D_O_PRICE,l.D_O_Date,l.D_State," & _
    '                "'" & g_day_night & "' as DayNig, o.d_o_date as o_date, o.d_ord_no as o_ord_no, o.d_ord_type as o_ord_type, o.d_lots as o_lots, " & _
    '                "o.d_o_price as o_price, s.d_sgroup, 0 as d_pl from [date] d, [order] l, Account a, Sales s, " & _
    '                "(select * from [order] where d_state = 'L') o " & _
    '                "where l.d_state = 'O' and l.d_o_date = '" & Format(g_tdate, "yyyy/MM/dd") & "' and " & _
    '                "l.d_ord_type *= o.d_op_type and l.d_ord_no *= o.d_op_no " & _
    '                "and l.d_currency *= o.d_currency " & _
    '                "and l.d_ano = a.d_ano and l.d_sno *= s.d_sno "

    '        Select Case UCase(strOrderBy)
    '            Case "ORDER NO"
    '                'manual cut loss order
    '                lstrSQL = lstrSQLHeader
    '                If strOrdFr.Trim <> "" Then
    '                    'lstrSQL &= " and l.d_ord_no >= " & GFncSqlQuote(strOrdFr) & " and l.d_ord_type = '' "
    '                    If IsNumeric(Left(strOrdFr.Trim, 1)) Then
    '                        lstrSQL &= " and l.d_ord_no >= " & GFncSqlQuote(strOrdFr.Trim) & " and l.d_ord_type = '' "
    '                        '                    Else
    '                        '                       lstrSQL &= " and l.d_ord_type + ltrim(str(l.d_ord_no)) >= '" & GFncSqlQuote(strOrdTo.Trim) & "' "
    '                    End If
    '                End If
    '                If strOrdTo.Trim <> "" Then
    '                    'lstrSQL &= " and l.d_ord_no <= " & GFncSqlQuote(strOrdTo) & " and l.d_ord_type = '' "
    '                    If IsNumeric(Left(strOrdTo.Trim, 1)) Then
    '                        lstrSQL &= " and l.d_ord_no <= " & GFncSqlQuote(strOrdTo.Trim) & " and l.d_ord_type = '' "
    '                        'Else
    '                        '   lstrSQL &= " and l.d_ord_type + ltrim(str(l.d_ord_no)) <= '" & GFncSqlQuote(strOrdTo.Trim) & "' "
    '                    End If
    '                End If

    '                'auto cut loss order
    '                If strOrdFr.Trim <> "" Or strOrdTo.Trim <> "" Then
    '                    If Not IsNumeric(Left(strOrdFr.Trim, 1)) And Not IsNumeric(Left(strOrdTo.Trim, 1)) Then
    '                        lstrSQL = ""
    '                    ElseIf (IsNumeric(Left(strOrdFr.Trim, 1)) And Not IsNumeric(Left(strOrdTo.Trim, 1))) Or _
    '                          (Not IsNumeric(Left(strOrdFr.Trim, 1)) And IsNumeric(Left(strOrdTo.Trim, 1))) Then
    '                        lstrSQL &= " UNION "
    '                    End If
    '                    If Not IsNumeric(Left(strOrdFr.Trim, 1)) Or Not IsNumeric(Left(strOrdTo.Trim, 1)) Then
    '                        lstrSQL &= lstrSQLHeader & " and l.d_ord_type = 'C' "
    '                        If Not IsNumeric(Left(strOrdFr.Trim, 1)) And strOrdFr.Trim.Length > 0 Then
    '                            lstrSQL &= " and l.d_ord_no <= " & GFncSqlQuote(Right(strOrdFr.Trim, strOrdFr.Trim.Length - 1)) & " "
    '                        End If
    '                        If Not IsNumeric(Left(strOrdTo.Trim, 1)) And strOrdTo.Trim.Length > 0 Then
    '                            lstrSQL &= " and l.d_ord_no <= " & GFncSqlQuote(Right(strOrdTo.Trim, strOrdTo.Trim.Length - 1)) & " "
    '                        End If
    '                    End If
    '                End If

    '                lstrSQL &= " Order by l.d_o_date, l.d_ord_type, l.d_ord_no "
    '                rpt = New RptExeMixOrd
    '            Case "CURRENCY"
    '                If strCurr.Trim <> "" Then
    '                    lstrSQL = lstrSQLHeader & " and l.d_currency = '" & strCurr.Trim & "' "
    '                End If
    '                lstrSQL &= " Order by l.d_currency, l.d_o_date, l.d_ord_type, l.d_ord_no "
    '                rpt = New RptExeMixOrdCur
    '        End Select

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            larrParaNames(0) = "paraPrintUser"
    '            larrParaValues(0) = Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")"
    '            larrParaNames(1) = "paraSortBy"
    '            larrParaValues(1) = UCase(strOrderBy)

    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            lsubSetCurrConfig(rpt)
    '            AddParam(rpt, larrParaNames, larrParaValues)
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function
    '    Public Function Executed_EXE_Order_SalesGroup_Rpt(ByVal lstrType As String, ByVal ldteFr As Date, ByVal ldteto As Date, _
    'ByVal lstrSG As String, Optional ByVal lstrSGfrom As String = "", Optional ByVal lstrSGto As String = "") As ReportClass

    '        Dim lstrSQL As String = ""
    '        Dim lstrSQLHeader As String = ""
    '        Dim ldtsResult As DataSet
    '        Dim ldtsSubResult As DataSet
    '        Dim larrParaNames(2) As String
    '        Dim larrParaValues(2) As String
    '        Dim rpt As New RptExeOrdSG
    '        Dim lstrTitle As String = lstrType

    '        'lstrSQLHeader = "select l.D_Branch, l.D_Ord_no, l.D_Ord_Type, l.D_ANO, A.D_SNAME as A_SName,S.D_SNO,d.d_tdate as t_date," & _
    '        '        "S.D_SNAME as S_SName,l.D_NEW_LIQ,l.D_Buy_Sell,l.D_CURRENCY,l.D_DAY_NIGT,l.D_LOTS,l.D_LOTS2,l.D_O_PRICE,l.D_O_Date,l.D_State," & _
    '        '        "'" & g_day_night & "' as DayNig, o.d_o_date as o_date, o.d_ord_no as o_ord_no, o.d_ord_type as o_ord_type, o.d_lots as o_lots, " & _
    '        '        "o.d_o_price as o_price from [date] d, [order] l, Account a, Sales s, " & _
    '        '        "(select * from [order] where d_state = 'L') o " & _
    '        '        "where l.d_state = 'O' and l.d_o_date = '" & Format(g_tdate, "yyyy/MM/dd") & "' and " & _
    '        '        "l.d_ord_type *= o.d_op_type and l.d_ord_no *= o.d_op_no " & _
    '        '        "and l.d_currency *= o.d_currency " & _
    '        '        "and l.d_ano = a.d_ano and l.d_sno *= s.d_sno "

    '        If ldteFr = ldteto Then
    '            lstrTitle &= "  " & Format(ldteFr, "dd MMM yyyyy")
    '        Else
    '            lstrTitle &= "  " & Format(ldteFr, "dd MMM yyyyy") & " - " & Format(ldteto, "dd MMM yyyy")
    '        End If

    '        lstrSQL = "select '" & g_branch_name & "' as D_Branch, b.d_ono as D_Ord_no, '' as D_Ord_Type, b.D_ANO, A.D_SNAME as A_SName, b.D_SNO, b.d_tdate as t_date," & _
    '                       "S.D_SNAME as S_SName,b.D_NEW_LIQ,b.D_CURRENCY,'D',b.D_e_LOTS as d_lots,b.D_e_LOTS as d_lots2, " & _
    '                       " case b.d_type when 'BS' then 'S' when 'SB' then 'B' else d_type end as d_buy_sell, " & _
    '                       " b.d_e_price as D_O_PRICE,b.D_O_Date,b.d_ord_type as D_State, o.d_o_pl as d_pl, " & _
    '                       " 'D' as DayNig, o.d_o_date as o_date, o.d_ord_no as o_ord_no, '' as o_ord_type, o.d_o_lots as o_lots, " & _
    '                       "o.d_o_price as o_price, b.d_sgroup from " & GStrMonthlyDB & ".dbo.m_eorder b left outer join Account a " & _
    '                       " on b.d_ano = a.d_ano left outer join Sales s on s.d_sno = b.d_sno left outer join " & _
    '                       GStrMonthlyDB & ".dbo.m_eorder_dtl o on b.d_ono = o.d_op_no and b.d_tdate = o.d_tdate and b.d_bcode = o.d_bcode  " & _
    '                       "where b.d_tdate between '" & Format(ldteFr, "yyyy/MM/dd") & "' and '" & _
    '                        Format(ldteto, "yyyy/MM/dd") & "' and b.d_bcode = '" & GStrBCode & "' "


    '        Select Case lstrType
    '            Case "LIQ Order"
    '                lstrSQL &= " and b.d_ord_type = 'L' "
    '            Case "NEW Order"
    '                lstrSQL &= " and b.d_ord_type = 'N' "
    '        End Select
    '        If lstrSGfrom <> "" Then
    '            lstrSQL &= " AND b.d_sgroup >= '" & lstrSGfrom.ToUpper & "' "
    '            lstrTitle &= "  Sales Group = " & lstrSGfrom.ToUpper
    '        End If
    '        If lstrSGto <> "" Then
    '            lstrSQL &= " AND b.d_sgroup <= '" & lstrSGto.ToUpper & "' "
    '            If lstrSGfrom <> "" Then
    '                lstrTitle &= " - " & lstrSGto.ToUpper
    '            Else
    '                lstrTitle &= "  Sales Group = [Top] - " & lstrSGfrom.ToUpper
    '            End If
    '        Else
    '            If lstrSGfrom <> "" Then
    '                lstrTitle &= " - [Bottom] "
    '            End If
    '        End If
    '        If lstrSG.Trim <> "" Then
    '            lstrSG = "( " & lstrSG.Trim & " ) "
    '            lstrSQL &= " and b.d_sgroup in " & lstrSG.Trim
    '        End If

    '        lstrSQL &= " order by b.d_sgroup, b.d_sno, b.d_ano, b.d_tdate, d_ono "


    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            lstrSQL = " select a.d_sno, a.d_sgroup, b.d_sname, count(a.d_ono) as total_order, sum(a.d_e_lots) as total_lots " & _
    '                        " from " & GStrMonthlyDB & ".dbo.m_eorder a left outer join sales b on a.d_sno = b.d_sno " & _
    '                        " where a.d_tdate between '" & Format(ldteFr, "yyyy/MM/dd") & "' and '" & _
    '                        Format(ldteto, "yyyy/MM/dd") & "' and a.d_bcode = '" & GStrBCode & "' "

    '            Select Case lstrType
    '                Case "LIQ Order"
    '                    lstrSQL &= " and a.d_ord_type = 'L' "
    '                Case "NEW Order"
    '                    lstrSQL &= " and a.d_ord_type = 'N' "
    '            End Select
    '            If lstrSGfrom <> "" Then
    '                lstrSQL &= " AND a.d_sgroup >= '" & lstrSGfrom.ToUpper & "' "
    '            End If
    '            If lstrSGto <> "" Then
    '                lstrSQL &= " AND a.d_sgroup <= '" & lstrSGto.ToUpper & "' "
    '            End If
    '            If lstrSG.Trim <> "" Then
    '                lstrSQL &= " and b.d_sgroup in " & lstrSG.Trim
    '            End If
    '            lstrSQL &= " group by a.d_sno, a.d_sgroup, b.d_sname order by a.d_sgroup, a.d_sno "

    '            ldtsSubResult = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '            rpt.Subreports("RptExeOrdSGSummary").SetDataSource(ldtsSubResult.Tables(0))

    '            larrParaNames(0) = "paraPrintUser"
    '            larrParaValues(0) = Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")"
    '            larrParaNames(1) = "paraSortBy"
    '            larrParaValues(1) = lstrTitle
    '            larrParaNames(2) = "paraSG"
    '            If lstrSG = "" Then
    '                larrParaValues(2) = " "
    '            Else
    '                larrParaValues(2) = Replace(lstrSG, "'", "")
    '            End If

    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            lsubSetCurrConfig(rpt)
    '            AddParam(rpt, larrParaNames, larrParaValues)
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function MARGIN_CALL_REPORT(Optional ByVal blnCallByDayEnd As Boolean = False, Optional ByRef dtnTrans As SqlTransaction = Nothing, Optional ByVal blnOrderByEM As Boolean = False) As ReportClass
    '        Dim l_em As String = ""
    '        Dim l_eq_s As Decimal = 0

    '        Dim l_mar10 As Decimal = 0
    '        Dim l_mar30 As Decimal = 0
    '        Dim l_mar70 As Decimal = 0
    '        Dim l_mar100 As Decimal = 0
    '        'weekend margin
    '        Dim l_marWE As Decimal = 0
    '        'end 20070920

    '        Dim lstrSQL As String = ""
    '        Dim ldtwAcc As DataRow
    '        Dim clsSa As New clsSales
    '        Dim lstrSGroup As String = ""
    '        Dim ldtsResult As DataSet
    '        Dim ldtwResult As DataRow
    '        Dim rpt As New RptMarginCall

    '        Dim ldtsAcc As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtsOp As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim ldtsDate As DataSet

    '        Dim ldtsTemp As DataSet
    '        Dim ldtwcTemp As DataRow()

    '        modcal.Prepare_Dataset_for_Cal(ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate, dtnTrans)

    '        Dim ldtsTerms As DataSet = Me.lFunGetAllTerms(dtnTrans)
    '        Dim ldtsSales As DataSet = Me.lFunGetAllSales(dtnTrans)

    '        lstrSQL = "CREATE TABLE [dbo].[#MAR_CALL] (" & _
    '                    "[ANO] [nvarchar](5) NOT NULL, " & _
    '                    "[SNO] [nvarchar](5) NOT NULL , " & _
    '                    "[S_GRP] [nvarchar](4) NULL DEFAULT (''), " & _
    '                    "[A_NAME] [nvarchar](40) NULL DEFAULT (''), " & _
    '                    "[AC_EQUITY] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[MAR_REQ] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[EM_RATIO] [nvarchar](20) NULL DEFAULT (''), " & _
    '                    "[PAIR_MAR] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[MAR30] [decimal] (18,2) NULL DEFAULT ((0)), " & _
    '                    "[MAR70] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                    "[MAR100] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[TDATE] [datetime] NULL, " & _
    '                    "[MARWE] [decimal](18, 2) NULL DEFAULT ((0)) " & _
    '                    ") ON [PRIMARY] "

    '        GFncRunSQL(GSCnSqlConn, dtnTrans, lstrSQL)

    '        lstrSQL = "Select * from #MAR_CALL "
    '        If Not IsNothing(dtnTrans) Then
    '            ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL, dtnTrans)
    '        Else
    '            ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        End If

    '        'lstrSQL = "DROP TABLE #MAR_CALL"
    '        'If Not IsNothing(dtnTrans) Then
    '        '    GFncRunSQL(GSCnSqlConn, dtnTrans, lstrSQL)
    '        'Else
    '        '    GFncRunSQL(GSCnSqlConn, lstrSQL)
    '        'End If

    '        If blnCallByDayEnd = True Then
    '            lstrSQL = "Delete From DAYEND_MAR_CALL Where D_TDATE = '" & Format(g_tdate, "yyyy/MM/dd") & "' "
    '            GFncRunSQL(GSCnSqlConn, dtnTrans, lstrSQL)
    '        End If

    '        If ldtsAcc.Tables(0).Rows.Count > 0 Then
    '            For Each ldtwAcc In ldtsAcc.Tables(0).Rows
    '                Application.DoEvents()

    '                define_trading_terms(ldtwAcc("D_ANO"), dtnTrans, ldtsAcc, ldtsTerms)
    '                GET_AC_STATUS(ldtwAcc("D_ANO").ToString, "Y", "N", g_int_date, dtnTrans, , ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '                l_em = 0

    '                l_eq_s = ag_status(AC_EQUITY) - (ag_status(AC_INTEREST) - ag_status(AC_LIQ_INT)) - _
    '                            (ag_status(AC_STORAGE) - ag_status(AC_LIQ_STOR))

    '                '** Begin 2004-05-18
    '                l_mar30 = ag_margin(MAR_10) - l_eq_s
    '                '** End 2004-05-18

    '                l_mar30 = IIf(l_mar30 < 0, 0, l_mar30)

    '                'weekend margin
    '                l_marWE = ag_margin(MAR_WE) - l_eq_s
    '                l_marWE = IIf(l_marWE < 0, 0, l_marWE)
    '                'end 20070920

    '                If ag_margin(MAR_NIGHT) > l_eq_s Or l_mar30 > 0 Then

    '                    l_em = E_M_RATIO(l_eq_s - ag_margin(MAR_DAY_PAIR), _
    '                            ag_margin(MAR_NIGHT) - ag_margin(MAR_DAY_PAIR)) * 100

    '                    '&& full margin requirment
    '                    l_mar100 = ag_margin(MAR_NIGHT) - l_eq_s
    '                    l_mar10 = 0
    '                    l_mar70 = 0
    '                    '&& All orders in pair
    '                    If (ag_margin(MAR_NIGHT) = ag_margin(MAR_NIGHT_PAIR)) Then
    '                        l_mar10 = l_mar100
    '                        l_mar70 = l_mar100

    '                    ElseIf ag_margin(MAR_NIGHT_PAIR) <> 0 Then
    '                        l_em = (ag_status(AC_EQUITY) - ag_margin(MAR_NIGHT_PAIR)) _
    '                                / (ag_margin(MAR_NIGHT) - ag_margin(MAR_NIGHT_PAIR)) * 100

    '                        If l_eq_s < (ag_margin(MAR_NIGHT) - ag_margin(MAR_NIGHT_PAIR)) _
    '                                * g_margin + ag_margin(MAR_NIGHT_PAIR) Then
    '                            l_mar70 = (ag_margin(MAR_NIGHT) - ag_margin(MAR_NIGHT_PAIR)) _
    '                                        * g_margin + ag_margin(MAR_NIGHT_PAIR) - l_eq_s
    '                            If l_eq_s < (ag_margin(MAR_NIGHT) - ag_margin(MAR_NIGHT_PAIR)) _
    '                                    * 0.1 + ag_margin(MAR_NIGHT_PAIR) Then
    '                                l_mar10 = (ag_margin(MAR_NIGHT) - ag_margin(MAR_NIGHT_PAIR)) _
    '                                      * 0.1 + ag_margin(MAR_NIGHT_PAIR) - l_eq_s
    '                            End If
    '                        End If

    '                    Else    '&& No pair order
    '                        If l_em < 10 Then
    '                            l_mar70 = ag_margin(MAR_NIGHT) * g_margin - l_eq_s
    '                        ElseIf l_em < 70 Then
    '                            l_mar70 = ag_margin(MAR_NIGHT) * g_margin - l_eq_s
    '                        End If
    '                    End If

    '                    'l_tmar30 += l_mar30
    '                    'l_tmar70 += l_mar70
    '                    'l_tmar100 += l_mar100

    '                    'l_em = IIf(l_em <= 0, ">>", " ") + Right(Space(8) & Format(Val(l_em), "#####0.0"), 8)
    '                    l_em = Right(Space(8) & Format(Val(l_em), "#####0.0"), 8)

    '                    If blnCallByDayEnd = True Then
    '                        lstrSQL = "Insert into DAYEND_MAR_CALL (D_TDATE, D_ANO, EQUITY, MAR_REQ, LSTUPDUSR, LSTUPDDTE) Values " & _
    '                                    "('" & Format(g_tdate, "yyyy/MM/dd") & "', '" & GFncSqlQuote(ldtwAcc("d_ano")) & "', " & _
    '                                    l_eq_s & ", " & ag_margin(MAR_NIGHT) & ", '" & GStrloginID & "', GetDate()) "
    '                        GFncRunSQL(GSCnSqlConn, dtnTrans, lstrSQL)

    '                    Else
    '                        ldtwResult = ldtsResult.Tables(0).NewRow
    '                        ldtwResult("ano") = ldtwAcc("d_ano")
    '                        ldtwResult("sno") = ldtwAcc("d_sno")
    '                        ldtwResult("s_grp") = Me.lFunGetSalesGroup(ldtsSales, ldtwAcc("d_sno"))
    '                        ldtwResult("a_name") = ldtwAcc("d_sname")
    '                        ldtwResult("ac_equity") = l_eq_s
    '                        ldtwResult("MAR_REQ") = ag_margin(MAR_NIGHT)
    '                        ldtwResult("EM_RATIO") = l_em
    '                        ldtwResult("PAIR_MAR") = ag_margin(MAR_NIGHT_PAIR)
    '                        ldtwResult("MAR30") = l_mar30
    '                        ldtwResult("MAR70") = l_mar70
    '                        ldtwResult("MAR100") = l_mar100
    '                        ldtwResult("TDATE") = g_tdate
    '                        ldtwResult("MARWE") = l_marWE
    '                        ldtsResult.Tables(0).Rows.Add(ldtwResult)
    '                    End If
    '                End If
    '            Next
    '        End If

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            If blnOrderByEM = True Then
    '                ldtwcTemp = ldtsResult.Tables(0).Select("", "[EM_RATIO] ASC, [ANO] ASC")

    '                lstrSQL = "Select * from #MAR_CALL "
    '                If Not IsNothing(dtnTrans) Then
    '                    ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, dtnTrans)
    '                Else
    '                    ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '                End If

    '                For i As Integer = 0 To ldtwcTemp.GetLength(0) - 1
    '                    ldtsTemp.Tables(0).ImportRow(ldtwcTemp(i))
    '                Next

    '                rpt.SetDataSource(ldtsTemp.Tables(0))
    '            Else
    '                rpt.SetDataSource(ldtsResult.Tables(0))
    '            End If

    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            MARGIN_CALL_REPORT = rpt
    '        Else
    '            MARGIN_CALL_REPORT = Nothing
    '        End If

    '        lstrSQL = "DROP TABLE #MAR_CALL"
    '        If Not IsNothing(dtnTrans) Then
    '            GFncRunSQL(GSCnSqlConn, dtnTrans, lstrSQL)
    '        Else
    '            GFncRunSQL(GSCnSqlConn, lstrSQL)
    '        End If


    '    End Function

    '    Public Function MARGIN_IO_REPORT() As ReportClass
    '        Dim lstrSQL As String
    '        Dim ldtsResult As DataSet
    '        Dim rpt As New RptMarginIO

    '        lstrSQL = "Select a.*, (MAR_IN - MAR_OUT) as NET, (select D_TDATE from [date]) as TDATE from (" & _
    '                    "Select ac.D_ANO as ANO, ac.D_SNAME as SNAME, ac.D_SNO as SNO, sa.D_SGROUP as SGRP, " & _
    '                    "(CASE WHEN ac.D_TRAN > 0 THEN ac.D_MARG_IN - ac.D_TRAN ELSE ac.D_MARG_IN END) as MAR_IN, " & _
    '                    "(CASE WHEN ac.D_TRAN <= 0 THEN ac.D_MARG_OUT + ac.D_TRAN ELSE ac.D_MARG_OUT END) as MAR_OUT From Account ac, SALES sa Where ac.D_SNO *= sa.D_SNO " & _
    '                    ") a Where a.MAR_IN <> 0 or a.MAR_OUT <> 0 "

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function ACCOUNT_GOLD_POS_REPORT() As ReportClass
    '        Dim lstrSQL As String
    '        Dim ldtsResult As DataSet
    '        Dim rpt As New RptACGoldPos

    '        lstrSQL = "Select a.* from (" & _
    '                    "Select D_ANO as ANO, D_SNAME as SNAME, D_G_PR_BAL as PREV_BAL, D_GOLD_IN as GOLD_IN, " & _
    '                    "D_GOLD_OUT as GOLD_OUT, (D_G_PR_BAL + D_GOLD_IN - D_GOLD_OUT) as BAL, " & _
    '                    "(Select a.D_C_PRICE from Currency a inner join [date] b on a.d_currency = b.strcalgold) as GOLD_PRICE, " & _
    '                    "(Select D_TDATE from [date]) as TDATE from Account " & _
    '                    ") a Where a.BAL <> 0 or a.GOLD_IN <> 0 or a.GOLD_OUT <> 0 "

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function PR_DETAILED_REPORT(ByVal dteStartDate As Date, ByVal dteEndDate As Date) As ReportClass
    '        Dim lstrSQL As String
    '        Dim lstrDRange As String
    '        Dim ldtsResult As DataSet
    '        Dim rpt As New RptNetMarHis

    '        lstrSQL = "Select m.D_ANO as ANO, a.D_SNAME as SNAME, a.D_SNO as SNO, " & _
    '                    "s.D_SNAME as AE_NAME, s.D_SGROUP as SGRP, m.D_TDATE as MAR_DATE, " & _
    '                    "(CASE m.D_IN_OUT WHEN 'I' THEN m.D_MARGIN ELSE 0.0 END) as MAR_IN, " & _
    '                    "(CASE m.D_IN_OUT WHEN 'O' THEN m.D_MARGIN * -1 ELSE 0.0 END) as MAR_OUT, " & _
    '                    "(Select D_TDATE from [date]) as TDATE, m.D_ISADJ as IS_ADJ From " & _
    '                    "MARGIN m, ACCOUNT a, SALES s Where m.D_ANO = a.D_ANO and a.D_SNO = s.D_SNO and " & _
    '                    "m.D_TDATE >= '" & Format(dteStartDate, "yyyy/MM/dd") & "' and " & _
    '                    "m.D_TDATE <= '" & Format(dteEndDate, "yyyy/MM/dd") & "' ORDER BY m.D_ANO "

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            lstrDRange = Format(dteStartDate, "dd/MM/yyyy") & " - " & Format(dteEndDate, "dd/MM/yyyy")
    '            AddParam(rpt, "paraDRange", lstrDRange)
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If
    '    End Function

    '    Private Function Statement_LiqOrd(ByVal strAccNoStart As String, ByVal strAccNoEnd As String, _
    '    ByVal ldtsacc As DataSet, ByVal ldtsCurr As DataSet, ByVal ldtsOrder As DataSet, ByVal ldtsOp As DataSet, _
    '    ByVal ldtsDate As DataSet, ByVal ldtsTerms As DataSet) As DataSet
    '        Dim lstrSQL As String = ""
    '        Dim ldtwAcc As DataRow
    '        Dim ldtaAcc() As DataRow
    '        Dim ldtsResult As DataSet

    '        'create temp table
    '        lstrSQL = "CREATE TABLE [dbo].[#STATE_LIQ] (" & _
    '                    "[ANO] [nvarchar](5) NOT NULL, " & _
    '                    "[CUR] [nvarchar](3) NOT NULL, " & _
    '                    "[LIQ_BUY_SELL] [nvarchar](1) NOT NULL, " & _
    '                    "[BUY_DATE] [datetime] NULL, " & _
    '                    "[BUY_PRICE] [decimal](18, 4) NULL DEFAULT ((0)), " & _
    '                    "[BUY_LOTS] [decimal](18, 1) NULL DEFAULT ((0)), " & _
    '                    "[SELL_DATE] [datetime] NULL, " & _
    '                    "[SELL_PRICE] [decimal](18, 4) NULL DEFAULT ((0)), " & _
    '                    "[SELL_LOTS] [decimal](18, 1) NULL DEFAULT ((0)), " & _
    '                    "[COMM] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                    "[PL] [decimal](18, 2) NULL DEFAULT ((0)) " & _
    '                    ") ON [PRIMARY] "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        lstrSQL = "Select * from [dbo].[#STATE_LIQ] "
    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        'drop temp table
    '        lstrSQL = "Drop Table #STATE_LIQ "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        lstrSQL = ""
    '        If UCase(strAccNoStart) <> "TOP" Then
    '            lstrSQL = " D_ANO >= '" & strAccNoStart & "' "
    '            If UCase(strAccNoEnd) <> "BOTTOM" Then
    '                lstrSQL &= " and D_ANO <= '" & strAccNoEnd & "' "
    '            End If
    '        Else
    '            If UCase(strAccNoEnd) <> "BOTTOM" Then
    '                lstrSQL = " D_ANO <= '" & strAccNoEnd & "' "
    '            End If
    '        End If

    '        ldtaAcc = ldtsacc.Tables(0).Select(lstrSQL)
    '        For Each ldtwAcc In ldtaAcc
    '            Application.DoEvents()

    '            define_trading_terms(ldtwAcc.Item("D_ANO"), , ldtsacc, ldtsTerms)

    '            Dim ldtaliq() As DataRow
    '            Dim ldtwliq As DataRow

    '            ldtaliq = ldtsOrder.Tables(0).Select(" D_ANO = '" & ldtwAcc("d_ano") & "' and D_NEW_LIQ = 'L' and D_STATE = '" & O_New & "' ")

    '            If ldtaliq.Length > 0 Then

    '                afill(ag_order, 0, O_ORDER_SIZE)
    '                afill(ag_status, 0, AC_STATUS_SIZE)
    '                afill(ag_margin, 0, MAR_SIZE)
    '                For Each ldtwliq In ldtaliq
    '                    GATHER_ORD(ldtwliq, ldtwAcc, "L", , ldtsCurr)

    '                    Dim ldtwOp As DataRow
    '                    Dim ldtaOp() As DataRow
    '                    ldtaOp = ldtsOp.Tables(0).Select(" D_ANO = '" & ldtwAcc("d_ano") & "' and D_STATE = '" & O_Liq & "' " & _
    '                                "and D_OP_NO = '" & ldtwliq("D_ORD_NO") & "' and D_OP_TYPE = '" & ldtwliq("D_ORD_TYPE") & "' ")
    '                    If ldtaOp.Length > 0 Then
    '                        For Each ldtwOp In ldtaOp
    '                            GATHER_ORD(ldtwOp, ldtwAcc, "O", , ldtsCurr)
    '                            CAL_ORDER_PROFIT("L", g_int_date, , ldtsDate, ldtsCurr)

    '                            Dim ldtwResult As DataRow
    '                            ldtwResult = ldtsResult.Tables(0).NewRow
    '                            ldtwResult("ano") = ldtwAcc("d_ano")
    '                            ldtwResult("cur") = ag_order(O_CUR)
    '                            ldtwResult("liq_buy_sell") = ldtwliq("D_BUY_SELL")

    '                            If ldtwliq("D_BUY_SELL") = "B" Then

    '                                ldtwResult("buy_date") = ag_order(O_LIQ_DATE)
    '                                ldtwResult("buy_price") = ag_order(O_C_PRICE)
    '                                ldtwResult("buy_lots") = ag_order(O_LOTS)
    '                                ldtwResult("sell_date") = ag_order(O_DATE)
    '                                ldtwResult("sell_price") = ag_order(O_O_PRICE)
    '                                ldtwResult("sell_lots") = ag_order(O_LOTS)
    '                            Else

    '                                ldtwResult("buy_date") = ag_order(O_DATE)
    '                                ldtwResult("buy_price") = ag_order(O_O_PRICE)
    '                                ldtwResult("buy_lots") = ag_order(O_LOTS)
    '                                ldtwResult("sell_date") = ag_order(O_LIQ_DATE)
    '                                ldtwResult("sell_price") = ag_order(O_C_PRICE)
    '                                ldtwResult("sell_lots") = ag_order(O_LOTS)
    '                            End If
    '                            ldtwResult("COMM") = ag_order(O_COMM)
    '                            ldtwResult("pl") = ag_order(O_PL)
    '                            ldtsResult.Tables(0).Rows.Add(ldtwResult)

    '                        Next
    '                    End If
    '                Next
    '            End If
    '        Next

    '        Return ldtsResult

    '    End Function

    '    Private Function Statement_OpenOrd(ByVal strAccNoStart As String, ByVal strAccNoEnd As String, _
    '    ByVal ldtsacc As DataSet, ByVal ldtsCurr As DataSet, ByVal ldtsOrder As DataSet, ByVal ldtsOp As DataSet, _
    '    ByVal ldtsDate As DataSet, ByVal ldtsTerms As DataSet) As DataSet

    '        Dim lstrSQL As String = ""
    '        Dim ldtwAcc As DataRow
    '        Dim ldtaAcc() As DataRow
    '        Dim clsOrd As New ClsOrder
    '        Dim ldtsResult As DataSet

    '        'create temp table
    '        lstrSQL = "CREATE TABLE [dbo].[#STATE_OPN] (" & _
    '                    "[ANO] [nvarchar](5) NOT NULL, " & _
    '                    "[CUR] [nvarchar](3) NOT NULL, " & _
    '                    "[BUY_DATE] [datetime] NULL, " & _
    '                    "[BUY_PRICE] [decimal](18, 4) NULL DEFAULT ((0)), " & _
    '                    "[BUY_LOTS] [decimal](18, 1) NULL DEFAULT ((0)), " & _
    '                    "[SELL_PRICE] [decimal](18, 4) NULL DEFAULT ((0)), " & _
    '                    "[CLOSE_PRICE] [decimal](18, 4) NULL DEFAULT ((0)), " & _
    '                    "[INTEREST] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                    "[STORAGE] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                    "[COMM] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                    "[FLOAT_PL] [decimal](18, 2) NULL DEFAULT ((0)) " & _
    '                    ") ON [PRIMARY] "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        'get result
    '        lstrSQL = "Select * from [dbo].[#STATE_OPN] "
    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        'drop temp table
    '        lstrSQL = "Drop Table #STATE_OPN "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        lstrSQL = ""
    '        If UCase(strAccNoStart) <> "TOP" Then
    '            lstrSQL = " D_ANO >= '" & strAccNoStart & "' "
    '            If UCase(strAccNoEnd) <> "BOTTOM" Then
    '                lstrSQL &= " and D_ANO <= '" & strAccNoEnd & "' "
    '            End If
    '        Else
    '            If UCase(strAccNoEnd) <> "BOTTOM" Then
    '                lstrSQL = " D_ANO <= '" & strAccNoEnd & "' "
    '            End If
    '        End If

    '        ldtaAcc = ldtsacc.Tables(0).Select(lstrSQL)
    '        For Each ldtwAcc In ldtaAcc
    '            Application.DoEvents()

    '            define_trading_terms(ldtwAcc.Item("D_ANO"), , ldtsacc, ldtsTerms)

    '            Dim ldtaOrd() As DataRow
    '            Dim ldtwOrd As DataRow
    '            ldtaOrd = ldtsOrder.Tables(0).Select(" D_ANO = '" & ldtwAcc("d_ano") & "' and D_NEW_LIQ = 'N' and " & _
    '                             "D_STATE = '" & O_New & "' and D_LOTS > 0 ")
    '            If ldtaOrd.Length > 0 Then

    '                afill(ag_order, 0, O_ORDER_SIZE)
    '                afill(ag_status, 0, AC_STATUS_SIZE)
    '                afill(ag_margin, 0, MAR_SIZE)
    '                For Each ldtwOrd In ldtaOrd
    '                    GATHER_ORD(ldtwOrd, ldtwAcc, "N", , ldtsCurr)
    '                    CAL_ORDER_PROFIT("N", g_int_date, , ldtsDate, ldtsCurr)

    '                    Dim ldtwResult As DataRow
    '                    ldtwResult = ldtsResult.Tables(0).NewRow
    '                    ldtwResult("ano") = ldtwAcc("d_ano")
    '                    ldtwResult("cur") = ag_order(O_CUR)
    '                    ldtwResult("buy_date") = ag_order(O_DATE)
    '                    If ag_order(O_BUY_SELL) = "B" Then
    '                        ldtwResult("buy_price") = ag_order(O_O_PRICE)
    '                        ldtwResult("sell_price") = 0
    '                    Else
    '                        ldtwResult("buy_price") = 0
    '                        ldtwResult("sell_price") = ag_order(O_O_PRICE)
    '                    End If
    '                    ldtwResult("buy_lots") = ag_order(O_LOTS)
    '                    ldtwResult("close_price") = ag_order(O_C_PRICE)
    '                    ldtwResult("interest") = ag_order(O_INTEREST)
    '                    ldtwResult("comm") = ag_order(O_COMM)
    '                    ldtwResult("float_pl") = ag_order(O_PL)
    '                    ldtwResult("storage") = ag_order(O_STORAGE)
    '                    ldtsResult.Tables(0).Rows.Add(ldtwResult)

    '                Next
    '            End If
    '        Next

    '        Return ldtsResult

    '    End Function

    '    Private Function Statement_ACStatus(ByVal strAccNoStart As String, ByVal strAccNoEnd As String, _
    '    ByVal ldtsacc As DataSet, ByVal ldtsCurr As DataSet, ByVal ldtsOrder As DataSet, ByVal ldtsOp As DataSet, _
    '    ByVal ldtsDate As DataSet, ByVal ldtsTerms As DataSet, ByVal ldtsSales As DataSet, ByVal ldtsOpn As DataSet, _
    '    ByVal ldtsLiq As DataSet, Optional ByVal blnPrintOther As Boolean = False) As Array
    '        Dim lstrSQL As String = ""
    '        Dim ldtwAcc As DataRow
    '        Dim ldtaAcc() As DataRow
    '        Dim clsOrd As New ClsOrder
    '        Dim ldtsResult As DataSet
    '        Dim ldtsMain As DataSet

    '        'create temp table
    '        lstrSQL = "CREATE TABLE [dbo].[#STATE_ACSTATUS] (" & _
    '                    "[ANO] [nvarchar](5) NOT NULL, " & _
    '                    "[PRE_BAL] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[BAL] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[MAR_IN] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[MAR_OUT] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[FLOAT_PL] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[GOLD_BAL_AMT] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[ADJ_COMM] [decimal] (18,2) NULL DEFAULT ((0)), " & _
    '                    "[COMM] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                    "[AC_EQUITY] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[ADJ_STORAGE] [decimal] (18,2) NULL DEFAULT ((0)), " & _
    '                    "[STORAGE] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[MAR_NIGHT] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                    "[ADJ_INT] [decimal] (18, 2) NULL DEFAULT ((0)), " & _
    '                    "[INTEREST] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                    "[EFF_MAR] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                    "[ADJ_PL] [decimal] (18, 2) NULL DEFAULT ((0)), " & _
    '                    "[PL] [decimal] (18,2) NULL DEFAULT ((0)), " & _
    '                    "[PRE_G_BAL] [decimal] (18, 2) NULL DEFAULT ((0)), " & _
    '                    "[GOLD_OUT] [decimal] (18, 2) NULL DEFAULT ((0)), " & _
    '                    "[GOLD_IN] [decimal] (18, 2) NULL DEFAULT ((0)), " & _
    '                    "[GOLD_BAL] [decimal] (18, 2) NULL DEFAULT ((0)), " & _
    '                    "[GOLD_PRICE] [decimal] (18, 2) NULL DEFAULT ((0)), " & _
    '                    ") ON [PRIMARY] "

    '        GFncRunSQL(GSCnSqlConn, lstrSQL)
    '        'get result
    '        lstrSQL = "Select * from [dbo].[#STATE_ACSTATUS] "
    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        'drop temp table
    '        lstrSQL = "Drop Table #STATE_ACSTATUS "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        lstrSQL = "Select A.D_ANO, A.D_SNAME, A.D_ADDR1, A.D_ADDR2, A.D_ADDR3, A.D_ADDR4, A.D_SNO, S.D_SGROUP, " & _
    '        "(SELECT D_TDATE FROM [DATE]) AS D_TDATE FROM ACCOUNT A, SALES S WHERE A.D_SNO *= S.D_SNO and 1 < 0 "
    '        ldtsMain = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        lstrSQL = ""
    '        If UCase(strAccNoStart) <> "TOP" Then
    '            lstrSQL = " D_ANO >= '" & strAccNoStart & "' "
    '            If UCase(strAccNoEnd) <> "BOTTOM" Then
    '                lstrSQL &= " and D_ANO <= '" & strAccNoEnd & "' "
    '            End If
    '        Else
    '            If UCase(strAccNoEnd) <> "BOTTOM" Then
    '                lstrSQL = " D_ANO <= '" & strAccNoEnd & "' "
    '            End If
    '        End If

    '        ldtaAcc = ldtsacc.Tables(0).Select(lstrSQL)
    '        For Each ldtwAcc In ldtaAcc
    '            Application.DoEvents()

    '            define_trading_terms(ldtwAcc.Item("D_ANO"), , ldtsacc, ldtsTerms)
    '            GET_AC_STATUS(ldtwAcc("d_ano"), "Y", "N", g_int_date, , , ldtsacc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '            'If ldtsOpn.Tables(0).Select(" ano = '" & ldtwAcc("d_ano") & "' ").Length > 0 Or _
    '            '    ldtsLiq.Tables(0).Select(" ano = '" & ldtwAcc("d_ano") & "' ").Length > 0 Or _
    '            '    ldtwAcc("d_gold_in") <> 0 Or ldtwAcc("d_gold_out") Or ag_status(AC_MARGIN_IO) <> 0 Then
    '            If ldtsOpn.Tables(0).Select(" ano = '" & ldtwAcc("d_ano") & "' ").Length > 0 Or _
    '                ldtsLiq.Tables(0).Select(" ano = '" & ldtwAcc("d_ano") & "' ").Length > 0 Or _
    '                ldtwAcc("d_gold_in") <> 0 Or ldtwAcc("d_gold_out") Or ag_status(AC_MARGIN_IO) <> 0 Or _
    '                blnPrintOther = True Then

    '                Dim ldtwResult As DataRow
    '                ldtwResult = ldtsResult.Tables(0).NewRow
    '                ldtwResult("ano") = ldtwAcc("d_ano")
    '                ldtwResult("PRE_BAL") = ldtwAcc("D_PR_BAL")
    '                ldtwResult("BAL") = ag_status(AC_BALANCE)
    '                ldtwResult("MAR_IN") = ldtwAcc("D_MARG_IN")
    '                ldtwResult("MAR_OUT") = ldtwAcc("D_MARG_OUT")
    '                ldtwResult("FLOAT_PL") = ag_status(AC_FLOATING)

    '                Dim ldtaGold() As DataRow = ldtsCurr.Tables(0).Select(" d_currency = '" & ldtsDate.Tables(0).Rows(0).Item("strcalgold") & "' ")
    '                If ldtaGold.Length > 0 Then
    '                    ldtwResult("GOLD_PRICE") = ldtaGold(0).Item("d_c_price")
    '                Else
    '                    ldtwResult("GOLD_PRICE") = 0
    '                End If
    '                ldtwResult("PRE_G_BAL") = ldtwAcc("D_G_PR_BAL")
    '                ldtwResult("gold_in") = ldtwAcc("D_GOLD_IN")
    '                ldtwResult("gold_out") = ldtwAcc("D_GOLD_OUT")
    '                ldtwResult("GOLD_BAL") = ldtwAcc("D_G_PR_BAL") + ldtwAcc("D_GOLD_IN") - ldtwAcc("D_GOLD_OUT")
    '                ldtwResult("GOLD_BAL_AMT") = ldtwResult("GOLD_BAL") * ldtwResult("GOLD_PRICE") * 0.9
    '                ldtwResult("ADJ_COMM") = ldtwAcc("D_ADJ_COMM")
    '                ldtwResult("COMM") = ag_status(AC_COMM)
    '                ldtwResult("AC_EQUITY") = ag_status(AC_EQUITY)
    '                ldtwResult("ADJ_STORAGE") = ldtwAcc("D_ADJ_STO")
    '                ldtwResult("STORAGE") = ag_status(AC_STORAGE)

    '                If IsDBNull(ldtwAcc("D_STATUS")) Then
    '                    ldtwResult("MAR_NIGHT") = ag_margin(MAR_NIGHT)
    '                    ldtwResult("EFF_MAR") = ag_status(AC_EQUITY) - ag_margin(MAR_NIGHT)
    '                Else
    '                    If Trim(ldtwAcc("D_STATUS")) = "" Then
    '                        ldtwResult("MAR_NIGHT") = ag_margin(MAR_NIGHT)
    '                        ldtwResult("EFF_MAR") = ag_status(AC_EQUITY) - ag_margin(MAR_NIGHT)
    '                    Else
    '                        ldtwResult("MAR_NIGHT") = 0
    '                        ldtwResult("EFF_MAR") = ag_status(AC_EQUITY)
    '                    End If
    '                End If
    '                ldtwResult("ADJ_INT") = ldtwAcc("D_ADJ_INT")
    '                ldtwResult("INTEREST") = ag_status(AC_INTEREST)
    '                ldtwResult("ADJ_PL") = ldtwAcc("D_ADJ_PL")
    '                ldtwResult("PL") = ag_status(AC_PL)
    '                ldtsResult.Tables(0).Rows.Add(ldtwResult)


    '                Dim ldtwMain As DataRow
    '                ldtwMain = ldtsMain.Tables(0).NewRow
    '                ldtwMain("d_ano") = ldtwAcc("d_ano")
    '                ldtwMain("D_SNAME") = ldtwAcc("D_SNAME")
    '                ldtwMain("D_ADDR1") = ldtwAcc("D_ADDR1")
    '                ldtwMain("D_ADDR2") = ldtwAcc("D_ADDR2")
    '                ldtwMain("D_ADDR3") = ldtwAcc("D_ADDR3")
    '                ldtwMain("D_ADDR4") = ldtwAcc("D_ADDR4")
    '                ldtwMain("d_sno") = ldtwAcc("d_sno")
    '                ldtwMain("d_sgroup") = Me.lFunGetSalesGroup(ldtsSales, ldtwAcc("d_sno"))
    '                ldtwMain("d_tdate") = g_tdate
    '                ldtsMain.Tables(0).Rows.Add(ldtwMain)

    '            End If
    '        Next

    '        Dim ldtsReturn(1) As DataSet
    '        ldtsReturn(0) = ldtsResult
    '        ldtsReturn(1) = ldtsMain

    '        Return ldtsReturn

    '    End Function

    '    Private Function Statement_Cur() As DataSet
    '        Dim lstrSQL As String = ""
    '        Dim ldtsResult As DataSet

    '        lstrSQL = "SELECT c.*, (select d_us_rate from [date]) as us_exchange, " & _
    '                    "(select d_l_intres from currency where d_currency = 'HKG') as hkg_l_interest, " & _
    '                    "(select d_s_intres from currency where d_currency = 'HKG') as hkg_s_interest, " & _
    '                    STORAGE_CHARGE & " as storage, t.US_HK_CROSS, t.description_c as description " & _
    '                    "FROM CURRENCY c, TERMS_CONFIG t WHERE c.D_CURRENCY = t.D_CURRENCY ORDER BY t.STATEMENT_ORDER "

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        Return ldtsResult
    '    End Function

    '    Public Function Print_AC_Statement(ByVal strAccNoStart As String, ByVal strAccNoEnd As String, Optional ByVal blnPrintOther As Boolean = False) As ReportClass
    '        Dim rpt As New RptStatement
    '        Dim ldtsResult As DataSet
    '        Dim ldtsLiq As DataSet
    '        Dim ldtsACStatus As DataSet
    '        Dim ldtsOpn As DataSet
    '        Dim ldtsCur As DataSet

    '        Dim ldtsTerms As DataSet = Me.lFunGetAllTerms
    '        Dim ldtsSales As DataSet = Me.lFunGetAllSales
    '        Dim ldtsAcc As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtsOp As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim ldtsDate As DataSet
    '        modcal.Prepare_Dataset_for_Cal(ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '        ldtsLiq = Statement_LiqOrd(strAccNoStart, strAccNoEnd, ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate, ldtsTerms)
    '        ldtsOpn = Statement_OpenOrd(strAccNoStart, strAccNoEnd, ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate, ldtsTerms)
    '        ldtsCur = Statement_Cur()
    '        Dim ldtaReturn(1) As DataSet
    '        ldtaReturn = Statement_ACStatus(strAccNoStart, strAccNoEnd, ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate, ldtsTerms, _
    '                                ldtsSales, ldtsOpn, ldtsLiq, blnPrintOther)
    '        ldtsResult = ldtaReturn(1)
    '        ldtsACStatus = ldtaReturn(0)

    '        If ldtsACStatus.Tables(0).Rows.Count > 0 Then
    '            rpt.Subreports("RptStateLiq").SetDataSource(ldtsLiq.Tables(0))
    '            lsubSetCurrConfig(rpt, "RptStateLiq")
    '            rpt.Subreports("RptStateAcctStatus").SetDataSource(ldtsACStatus.Tables(0))
    '            rpt.Subreports("RptStateOpn").SetDataSource(ldtsOpn.Tables(0))
    '            lsubSetCurrConfig(rpt, "RptStateOpn")
    '            rpt.Subreports("RptStateCur").SetDataSource(ldtsCur.Tables(0))

    '            rpt.SetDataSource(ldtsResult.Tables(0))

    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function
    '    Public Function Print_AC_EStatement(ByVal strAccNoStart As String, ByVal strAccNoEnd As String, Optional ByVal blnPrintOther As Boolean = False) As ReportClass
    '        Dim rpt As New RptEStatement
    '        Dim ldtsResult As DataSet
    '        Dim ldtsLiq As DataSet
    '        Dim ldtsACStatus As DataSet
    '        Dim ldtsOpn As DataSet
    '        Dim ldtsCur As DataSet

    '        Dim ldtsTerms As DataSet = Me.lFunGetAllTerms
    '        Dim ldtsSales As DataSet = Me.lFunGetAllSales
    '        Dim ldtsAcc As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtsOp As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim ldtsDate As DataSet
    '        modcal.Prepare_Dataset_for_Cal(ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '        ldtsLiq = Statement_LiqOrd(strAccNoStart, strAccNoEnd, ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate, ldtsTerms)
    '        ldtsOpn = Statement_OpenOrd(strAccNoStart, strAccNoEnd, ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate, ldtsTerms)
    '        ldtsCur = Statement_Cur()
    '        Dim ldtaReturn(1) As DataSet
    '        ldtaReturn = Statement_ACStatus(strAccNoStart, strAccNoEnd, ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate, ldtsTerms, _
    '                                ldtsSales, ldtsOpn, ldtsLiq, blnPrintOther)
    '        ldtsResult = ldtaReturn(1)
    '        ldtsACStatus = ldtaReturn(0)

    '        If ldtsACStatus.Tables(0).Rows.Count > 0 Then
    '            rpt.Subreports("RptEStateLiq").SetDataSource(ldtsLiq.Tables(0))
    '            lsubSetCurrConfig(rpt, "RptEStateLiq")
    '            rpt.Subreports("RptEStateAcctStatus").SetDataSource(ldtsACStatus.Tables(0))
    '            rpt.Subreports("RptEStateOpn").SetDataSource(ldtsOpn.Tables(0))
    '            lsubSetCurrConfig(rpt, "RptEStateOpn")
    '            rpt.Subreports("RptEStateCur").SetDataSource(ldtsCur.Tables(0))

    '            rpt.SetDataSource(ldtsResult.Tables(0))

    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function


    '    Public Function PR_SUMMARY_REPORT(ByVal dteStartDate As Date, ByVal dteEndDate As Date) As ReportClass
    '        Dim rpt As New RptNetMarHisSum
    '        Dim lstrSQL As String
    '        Dim ldtsResult As DataSet
    '        Dim lstrCriteria As String

    '        lstrSQL = "Select m.D_ANO as ANO, a.D_SNAME as SNAME, a.D_SNO as SNO, s.D_SNAME as AE_NAME, " & _
    '                    "s.D_SGROUP as SGRP, m.MAR_IN, m.MAR_OUT, (m.MAR_IN + m.MAR_OUT) as MAR_NET, " & _
    '                    "(Select D_TDATE From [date]) as TDATE " & _
    '                    "From ACCOUNT a, SALES s, " & _
    '                        "(Select D_ANO, Sum(Case D_IN_OUT When 'I' Then D_MARGIN Else 0 End) as MAR_IN, " & _
    '                        "Sum(Case D_IN_OUT When 'O' Then D_MARGIN * -1 Else 0 End) as MAR_OUT " & _
    '                        "From Margin Where D_TDATE Between '" & Format(dteStartDate, "yyyy/MM/dd") & "' and " & _
    '                        "'" & Format(dteEndDate, "yyyy/MM/dd") & "' " & _
    '                        "Group By D_ANO) m " & _
    '                    "Where a.D_ANO = m.D_ANO and a.D_SNO = s.D_SNO ORDER BY MAR_NET "

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            lstrCriteria = Format(dteStartDate, "dd/MM/yyyy") & " - " & Format(dteEndDate, "dd/MM/yyyy")
    '            AddParam(rpt, "paraDRange", lstrCriteria)
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function CONSOL() As ReportClass
    '        Dim lstrSQL As String
    '        Dim ldtwAcc As DataRow
    '        Dim rpt As New RptAccConsol
    '        Dim clsSa As New clsSales
    '        Dim ldtsResult As DataSet
    '        Dim ldtsTerms As DataSet = Me.lFunGetAllTerms
    '        Dim ldtsSales As DataSet = Me.lFunGetAllSales
    '        Dim ldtsAcc As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtsOp As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim ldtsDate As DataSet
    '        modcal.Prepare_Dataset_for_Cal(ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)


    '        If ldtsAcc.Tables(0).Rows.Count > 0 Then

    '            lstrSQL = "Create Table [dbo].[#CONSOL_RPT] (" & _
    '                        "[ANO] [NVARCHAR](5) NOT NULL, " & _
    '                        "[SNO] [NVARCHAR](5) NOT NULL, " & _
    '                        "[SGRP] [NVARCHAR](4) NOT NULL, " & _
    '                        "[PREV_BAL] [DECIMAL](18,2) NULL DEFAULT ((0)), " & _
    '                        "[MAR_IO] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                        "[ACT_PL] [DECIMAL](18,2) NULL DEFAULT ((0)), " & _
    '                        "[COMM] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                        "[INTEREST] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                        "[NEW_BAL] [decimal](18,2) NULL DEFAULT ((0)), " & _
    '                        "[FLOAT_PL] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                        "[EQUITY] [decimal](18, 2) NULL DEFAULT ((0)), " & _
    '                        ") ON [PRIMARY] "

    '            GFncRunSQL(GSCnSqlConn, lstrSQL)

    '            lstrSQL = "Select *, (Select D_TDATE From [date]) as TDATE From #CONSOL_RPT Order by ANO "
    '            ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '            For Each ldtwAcc In ldtsAcc.Tables(0).Rows
    '                Application.DoEvents()

    '                define_trading_terms(ldtwAcc("D_ANO"), , ldtsAcc, ldtsTerms)
    '                GET_AC_STATUS(ldtwAcc("D_ANO").ToString, "N", "N", g_int_date, , , ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '                If ag_status(AC_MARGIN_IO) <> 0.0 Or ag_status(AC_PL) <> 0.0 Or _
    '                    ag_status(AC_COMM) <> 0.0 Or ag_status(AC_INTEREST) <> 0.0 Or _
    '                    ag_status(AC_BALANCE) <> 0.0 Or ag_status(AC_FLOATING) <> 0.0 Or _
    '                    ag_status(AC_EQUITY) <> 0.0 Then

    '                    Dim ldtwResult As DataRow = ldtsResult.Tables(0).NewRow
    '                    ldtwResult("ano") = ldtwAcc("d_ano")
    '                    ldtwResult("sno") = ldtwAcc("d_sno")
    '                    ldtwResult("sgrp") = Me.lFunGetSalesGroup(ldtsSales, ldtwAcc("d_sno"))
    '                    ldtwResult("prev_bal") = ldtwAcc("D_PR_BAL")
    '                    ldtwResult("mar_io") = ag_status(AC_MARGIN_IO)
    '                    ldtwResult("comm") = ag_status(AC_COMM)
    '                    ldtwResult("act_pl") = ag_status(AC_PL)
    '                    ldtwResult("interest") = ag_status(AC_INTEREST)
    '                    ldtwResult("new_bal") = ag_status(AC_BALANCE)
    '                    ldtwResult("float_pl") = ag_status(AC_FLOATING)
    '                    ldtwResult("equity") = ag_status(AC_EQUITY)
    '                    ldtwResult("tdate") = g_tdate
    '                    ldtsResult.Tables(0).Rows.Add(ldtwResult)

    '                End If
    '            Next

    '            lstrSQL = "Drop Table #CONSOL_RPT "
    '            GFncRunSQL(GSCnSqlConn, lstrSQL)

    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            AddParam(rpt, "paraRecCount", CStr(ldtsResult.Tables(0).Rows.Count))

    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If
    '    End Function

    '    Public Function GENERAL() As ReportClass

    '        Dim l_ppl As Decimal = 0
    '        Dim l_tmar_in As Decimal = 0
    '        Dim l_tmar_out As Decimal = 0
    '        Dim l_tcomm As Decimal = 0
    '        Dim l_tint As Decimal = 0
    '        Dim l_tstorage As Decimal = 0
    '        Dim l_tpl As Decimal = 0
    '        Dim l_float As Decimal = 0
    '        Dim l_gold_val As Decimal = 0
    '        Dim l_overloss As Decimal = 0
    '        Dim l_rmar_in As Decimal = 0
    '        Dim l_bmar_in As Decimal = 0
    '        Dim l_bmar_out As Decimal = 0
    '        Dim l_bcomm As Decimal = 0
    '        Dim l_bint As Decimal = 0
    '        Dim l_bstorage As Decimal = 0
    '        Dim l_bpl As Decimal = 0
    '        Dim l_pgold_bal As Decimal = 0
    '        Dim l_gold_in As Decimal = 0
    '        Dim l_gold_out As Decimal = 0
    '        Dim l_acomm_no As Decimal = 0
    '        Dim l_aint_no As Decimal = 0
    '        Dim l_astor_no As Decimal = 0
    '        Dim l_apl_no As Decimal = 0
    '        Dim l_acomm As Decimal = 0
    '        Dim l_aint As Decimal = 0
    '        Dim l_astorage As Decimal = 0
    '        Dim l_apl As Decimal = 0
    '        Dim l_new_bal As Decimal = 0
    '        Dim l_gold_bal As Decimal = 0
    '        Dim l_t_in As Decimal = 0
    '        Dim l_t_out As Decimal = 0
    '        Dim l_mt_in As Decimal = 0
    '        Dim l_mt_out As Decimal = 0
    '        Dim l_rmain_in As Decimal = 0
    '        Dim l_rmar_out As Decimal = 0
    '        Dim l_nmargin As Decimal = 0
    '        Dim l_mmargin As Decimal = 0
    '        Dim l_mcomm As Decimal = 0
    '        Dim l_mint As Decimal = 0
    '        Dim l_mstorage As Decimal = 0
    '        Dim l_mpl As Decimal = 0
    '        Dim l_rpl As Decimal = 0
    '        Dim l_mrpl As Decimal = 0
    '        Dim l_mnew_bal As Decimal = 0
    '        Dim l_equity As Decimal = 0
    '        Dim l_aequity As Decimal = 0
    '        Dim l_act_float As Decimal = 0
    '        Dim l_mact_float As Decimal = 0
    '        Dim l_ttd_pl As Decimal = 0
    '        Dim l_ttm_pl As Decimal = 0

    '        '** Begin 2004/02/06
    '        Dim l_fx_pl As Decimal = 0
    '        Dim l_fx_float As Decimal = 0
    '        Dim l_fx_int As Decimal = 0
    '        Dim l_fx_comm As Decimal = 0
    '        Dim l_fx_rpl As Decimal = 0
    '        Dim l_fx_mrpl As Decimal = 0
    '        Dim l_fx_mcomm As Decimal = 0
    '        Dim l_fx_mint As Decimal = 0
    '        Dim l_fx_mpl As Decimal = 0
    '        Dim l_fx_bpl As Decimal = 0
    '        Dim l_fx_bint As Decimal = 0
    '        Dim l_fx_bcomm As Decimal = 0
    '        Dim l_afx_float As Decimal = 0
    '        Dim l_mafx_float As Decimal = 0
    '        Dim l_fxttd_pl As Decimal = 0
    '        Dim l_fxttm_pl As Decimal = 0
    '        Dim l_bu_pl As Decimal = 0
    '        Dim l_bu_float As Decimal = 0
    '        Dim l_bu_int As Decimal = 0
    '        Dim l_bu_comm As Decimal = 0
    '        Dim l_bu_rpl As Decimal = 0
    '        Dim l_bu_mrpl As Decimal = 0
    '        Dim l_bu_mcomm As Decimal = 0
    '        Dim l_bu_mint As Decimal = 0
    '        Dim l_bu_mpl As Decimal = 0
    '        Dim l_bu_bpl As Decimal = 0
    '        Dim l_bu_bint As Decimal = 0
    '        Dim l_bu_bcomm As Decimal = 0
    '        Dim l_abu_float As Decimal = 0
    '        Dim l_mabu_float As Decimal = 0
    '        Dim l_buttd_pl As Decimal = 0
    '        Dim l_buttm_pl As Decimal = 0

    '        '** End 2004/02/06

    '        Dim lstrSQL As String = ""
    '        Dim ldtsAccum As DataSet
    '        Dim ldtwAccum As DataRow
    '        Dim ldtwAcc As DataRow
    '        Dim ldtsResult As DataSet
    '        Dim rpt As New RptGeneral
    '        Dim ldecGPrice As Decimal = 0

    '        lstrSQL = "Select * from ACCUM where d_tdate = '" & Format(g_l_tdate, "yyyy/MM/dd") & "' "

    '        ldtsAccum = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        If ldtsAccum.Tables(0).Rows.Count > 0 Then
    '            ldtwAccum = ldtsAccum.Tables(0).Rows(0)
    '        Else
    '            Return Nothing
    '        End If

    '        Dim ldtsTerms As DataSet = Me.lFunGetAllTerms
    '        Dim ldtsSales As DataSet = Me.lFunGetAllSales
    '        Dim ldtsAcc As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtsOp As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim ldtsDate As DataSet
    '        modcal.Prepare_Dataset_for_Cal(ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '        For Each ldtwAcc In ldtsAcc.Tables(0).Rows                      '&& sum up the variables
    '            Application.DoEvents()

    '            '** Begin 2004-05-18
    '            define_trading_terms(ldtwAcc("D_ANO"), , ldtsAcc, ldtsTerms)
    '            '** End 2004-05-18
    '            GET_AC_STATUS(ldtwAcc("D_ANO"), "N", "N", g_int_date, , , ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)        '&& get the AE status

    '            l_ppl += ldtwAcc("D_PR_BAL")
    '            l_tmar_in += ldtwAcc("D_MARG_IN")
    '            l_tmar_out -= ldtwAcc("D_MARG_OUT")

    '            'If (ABS(ldtwAcct("D_TRAN")) <> 0) Then
    '            If ldtwAcc("D_TRAN") > 0 Then
    '                l_t_in += ldtwAcc("D_TRAN")
    '            ElseIf ldtwAcc("D_TRAN") < 0 Then
    '                l_t_out += ldtwAcc("D_TRAN")
    '            End If
    '            'End If

    '            l_tcomm += ag_status(AC_COMM)
    '            l_tint += ag_status(AC_INTEREST)
    '            l_tstorage += ag_status(AC_STORAGE)
    '            l_tpl += ag_status(AC_PL)
    '            l_float += ag_status(AC_FLOATING)
    '            l_gold_val += ag_status(AC_GOLD_VALUE)

    '            l_bmar_in += ldtwAcc("D_BF_M_IN")
    '            l_bmar_out -= ldtwAcc("D_BF_M_OUT")
    '            l_bcomm += ldtwAcc("D_BF_COMM")
    '            l_bint += ldtwAcc("D_BF_INT")
    '            l_bstorage += ldtwAcc("D_BF_STO")
    '            l_bpl += ldtwAcc("D_BF_PL")
    '            l_pgold_bal += ldtwAcc("D_G_PR_BAL")
    '            l_gold_in += ldtwAcc("D_GOLD_IN")
    '            l_gold_out += ldtwAcc("D_GOLD_OUT")

    '            '** Begin 2004/02/06
    '            l_fx_pl += ag_status(AC_FX_PL)
    '            l_fx_float += ag_status(AC_FX_FLOAT)
    '            l_fx_int += ag_status(AC_FX_INT)
    '            l_fx_comm += ag_status(AC_FX_COMM)
    '            l_bu_pl += ag_status(AC_BU_PL)
    '            l_bu_float += ag_status(AC_BU_FLOAT)
    '            l_bu_int += ag_status(AC_BU_INT)
    '            l_bu_comm += ag_status(AC_BU_COMM)

    '            l_fx_bpl += ldtwAcc("D_BF_FPL")
    '            l_fx_bcomm += ldtwAcc("D_BF_FCOMM")
    '            l_fx_bint += ldtwAcc("D_BF_FINT")
    '            l_bu_bpl += ldtwAcc("D_BF_BPL")
    '            l_bu_bcomm += ldtwAcc("D_BF_BCOMM")
    '            l_bu_bint += ldtwAcc("D_BF_BINT")
    '            '** End 2004/02/06

    '            If Math.Abs(ag_status(AC_EQUITY)) <> ag_status(AC_EQUITY) Then
    '                l_overloss += ag_status(AC_EQUITY)
    '            End If

    '            If ldtwAcc("D_ADJ_COMM") <> 0 Then
    '                l_acomm_no += 1
    '                l_acomm += ldtwAcc("D_ADJ_COMM")
    '            End If

    '            If ldtwAcc("D_ADJ_INT") <> 0 Then
    '                l_aint_no += 1
    '                l_aint += ldtwAcc("D_ADJ_INT")
    '            End If

    '            If ldtwAcc("D_ADJ_STO") <> 0 Then
    '                l_astor_no += 1
    '                l_astorage += ldtwAcc("D_ADJ_STO")
    '            End If

    '            If ldtwAcc("D_ADJ_PL") <> 0 Then
    '                l_apl_no += 1
    '                l_apl += ldtwAcc("D_ADJ_PL")
    '            End If
    '        Next

    '        l_new_bal = l_ppl + l_tmar_in + l_tmar_out + l_tcomm + l_tint + l_tstorage + l_tpl
    '        l_gold_bal = l_pgold_bal + l_gold_in - l_gold_out

    '        l_mt_in = ldtwAccum("D_M_T_IN") + l_t_in
    '        l_mt_out = ldtwAccum("D_M_T_OUT") + l_t_out
    '        l_rmar_in = l_tmar_in - l_t_in
    '        'l_bmar_in = l_bmar_in + l_rmar_in

    '        l_rmar_out = l_tmar_out - l_t_out
    '        l_nmargin = l_rmar_in + l_rmar_out
    '        'l_bmar_out = l_bmar_out + l_rmar_out
    '        l_mmargin = l_bmar_in + l_bmar_out

    '        l_mcomm = l_tcomm + l_bcomm
    '        '** Begin 2004/02/06
    '        l_fx_mcomm = l_fx_comm + l_fx_bcomm
    '        l_bu_mcomm = l_bu_comm + l_bu_bcomm
    '        '** End 2004/02/06
    '        l_mint = l_bint + l_tint
    '        '** Begin 2004/02/06
    '        l_fx_mint = l_fx_bint + l_fx_int
    '        l_bu_mint = l_bu_bint + l_bu_int
    '        '** End 2004/02/06
    '        l_mstorage = l_tstorage + l_bstorage

    '        l_mpl = l_tpl + l_bpl
    '        '** Begin 2004/02/06
    '        l_fx_mpl = l_fx_pl + l_fx_bpl
    '        l_bu_mpl = l_bu_pl + l_bu_bpl
    '        '** End 2004/02/06

    '        l_rpl = l_tcomm + l_tint + l_tstorage + l_tpl
    '        l_mrpl = l_mcomm + l_mint + l_mstorage + l_mpl

    '        '** Begin 2004/02/06
    '        l_fx_rpl = l_fx_comm + l_fx_int + l_fx_pl
    '        l_fx_mrpl = l_fx_mcomm + l_fx_mint + l_fx_mpl
    '        l_bu_rpl = l_bu_comm + l_bu_int + l_bu_pl + l_tstorage
    '        l_bu_mrpl = l_bu_mcomm + l_bu_mint + l_bu_mpl + l_mstorage
    '        '** End 2004/02/06
    '        l_mnew_bal = ldtwAccum("D_M_PR_BAL") + l_mt_in + l_mt_out + l_mmargin + l_rmar_out + l_rmar_in + l_mrpl
    '        l_equity = l_new_bal + l_float + l_gold_val
    '        l_aequity = l_equity - l_overloss
    '        l_act_float = l_float - ldtwAccum("D_PL_HK")
    '        l_mact_float = l_float - ldtwAccum("D_PL_US")
    '        l_ttd_pl = l_rpl + l_act_float
    '        l_ttm_pl = l_mrpl + l_mact_float
    '        l_afx_float = l_fx_float - ldtwAccum("D_PL_FHK")
    '        l_mafx_float = l_fx_float - ldtwAccum("D_PL_FUS")
    '        l_fxttd_pl = l_fx_rpl + l_afx_float
    '        l_fxttm_pl = l_fx_mrpl + l_mafx_float
    '        l_abu_float = l_bu_float - ldtwAccum("D_PL_BHK")
    '        l_mabu_float = l_bu_float - ldtwAccum("D_PL_BUS")
    '        l_buttd_pl = l_bu_rpl + l_abu_float
    '        l_buttm_pl = l_bu_mrpl + l_mabu_float

    '        If l_gold_bal > 0 Then
    '            ldecGPrice = l_gold_val / l_gold_bal
    '        End If

    '        lstrSQL = "SELECT " & l_ppl & " AS PREV_BAL, " & l_t_in & " AS TRAN_IN_TODAY, " & _
    '                    ldtwAccum("D_M_T_IN") & " AS TRAN_IN_BF, " & _
    '                    ldtwAccum("D_M_T_IN") + l_t_in & " AS TRAN_IN_TOTAL, " & _
    '                    l_tmar_in - l_t_in & " AS MAR_IN_TODAY, " & _
    '                    l_bmar_in & " AS MAR_IN_BF, " & _
    '                    l_tmar_in + l_bmar_in - l_t_in & " AS MAR_IN_TOTAL, " & _
    '                    l_t_out & " AS TRAN_OUT_TODAY, " & _
    '                    ldtwAccum("D_M_T_OUT") & " AS TRAN_OUT_BF, " & _
    '                    ldtwAccum("D_M_T_OUT") + l_t_out & " AS TRAN_OUT_TOTAL, " & _
    '                    l_tmar_out - l_t_out & " AS MAR_OUT_TODAY, " & _
    '                    l_bmar_out & " AS MAR_OUT_BF, " & _
    '                    l_tmar_out + l_bmar_out - l_t_out & " AS MAR_OUT_TOTAL, " & _
    '                    l_tcomm & " AS COMM_TODAY, " & _
    '                    l_bcomm & " AS COMM_BF, " & _
    '                    l_tcomm + l_bcomm & " AS COMM_TOTAL, " & _
    '                    l_tint & " AS INT_TODAY, " & _
    '                    l_bint & " AS INT_BF, " & _
    '                    l_bint + l_tint & " AS INT_TOTAL, " & _
    '                    l_tstorage & " AS STOR_TODAY, " & _
    '                    l_bstorage & " AS STOR_BF, " & _
    '                    l_tstorage + l_bstorage & " AS STOR_TOTAL, " & _
    '                    l_tpl & " AS PL_TODAY, " & _
    '                    l_bpl & " AS PL_BF, " & _
    '                    l_tpl + l_bpl & " AS PL_TOTAL, " & _
    '                    l_new_bal & " AS NEW_BAL, " & _
    '                    l_float & " AS FLOAT_PL, " & _
    '                    l_gold_val & " AS GOLD_VALUE, " & _
    '                    l_new_bal + l_float + l_gold_val & " AS EQUITY, " & _
    '                    l_overloss & " AS OVERLOSS, " & _
    '                    l_pgold_bal & " AS PREV_G_BAL, " & _
    '                    l_gold_in & " AS GOLD_IN, " & _
    '                    l_gold_out & " AS GOLD_OUT, " & _
    '                    l_gold_bal & " AS GOLD_BAL, " & _
    '                    ldecGPrice & " AS SOL_G_PRICE, " & _
    '                    l_acomm_no & " AS ADJ_NUM_COMM, " & _
    '                    l_acomm & " AS ADJ_COMM, " & _
    '                    l_aint_no & " AS ADJ_NUM_INT, " & _
    '                    l_aint & " AS ADJ_INT, " & _
    '                    l_astor_no & " AS ADJ_NUM_STOR, " & _
    '                    l_astorage & " AS ADJ_STOR, " & _
    '                    l_apl_no & " AS ADJ_NUM_PL, " & _
    '                    l_apl & " AS ADJ_PL, " & _
    '                    "'" & g_branch_name & "' AS BRANCH, " & _
    '                    "'" & g_company & "' AS COMP, " & _
    '                    "GETDATE() AS RPT_DATE, " & _
    '                    "(SELECT D_TDATE FROM [DATE]) AS TDATE, " & _
    '                    l_ppl & " AS TODAY_PREV_BAL, " & _
    '                    ldtwAccum("D_M_PR_BAL") & " AS TO_MONTH_PREV_BAL, " & _
    '                    l_t_in & " AS TODAY_TRAN_IN, " & _
    '                    l_mt_in & " AS TO_MONTH_TRAN_IN, " & _
    '                    l_t_out & " AS TODAY_TRAN_OUT, " & _
    '                    l_mt_out & " AS TO_MONTH_TRAN_OUT, " & _
    '                    "0.0  AS TODAY_OTHERS, 0.0 AS TO_MONTH_OTHERS, " & _
    '                    l_rmar_in & " AS TODAY_NETMAR_IN, " & _
    '                    l_bmar_in + l_rmar_in & " AS TO_MONTH_NETMAR_IN, " & _
    '                    l_rmar_out & " AS TODAY_NETMAR_OUT, " & _
    '                    l_nmargin & " AS TODAY_NETMAR_BAL, " & _
    '                    l_bmar_out + l_rmar_out & " AS TO_MONTH_NETMAR_OUT, " & _
    '                    l_mmargin + l_rmar_out + l_rmar_in & " AS TO_MONTH_NETMAR_BAL, " & _
    '                    l_tcomm & " AS TODAY_COMM, " & _
    '                    l_mcomm & " AS TO_MONTH_COMM, " & _
    '                    l_tint & " AS TODAY_INT, " & _
    '                    l_mint & " AS TO_MONTH_INT, " & _
    '                    l_tstorage & " AS TODAY_STOR, " & _
    '                    l_mstorage & " AS TO_MONTH_STOR, " & _
    '                    l_tpl & " AS TODAY_PL, " & _
    '                    l_mpl & " AS TO_MONTH_PL, " & _
    '                    l_new_bal & " AS TODAY_NEW_BAL, " & _
    '                    l_mnew_bal & " AS TO_MONTH_NEW_BAL, " & _
    '                    l_float & " AS TODAY_FLOAT, " & _
    '                    l_float & " AS TO_MONTH_FLOAT, " & _
    '                    l_equity & " AS TODAY_EQUITY, " & _
    '                    l_equity & " AS TO_MONTH_EQUITY, " & _
    '                    l_overloss * -1 & " AS TODAY_OL, " & _
    '                    l_overloss * -1 & " AS TO_MONTH_OL, " & _
    '                    l_aequity & " AS TODAY_EQU, " & _
    '                    l_aequity & " AS TO_MONTH_EQU, " & _
    '                    l_rpl & " AS TODAY_REAL_PL, " & _
    '                    l_mrpl & " AS TO_MONTH_REAL_PL, " & _
    '                    l_float & " AS TODAY_FLOAT_CF, " & _
    '                    l_float & " AS TO_MONTH_FLOAT_CF, " & _
    '                    ldtwAccum("D_PL_HK") & " AS TODAY_FLOAT_BF, " & _
    '                    l_act_float & " AS TODAY_FLOAT_BAL, " & _
    '                    ldtwAccum("D_PL_US") & " AS TO_MONTH_FLOAT_BF, " & _
    '                    l_mact_float & " AS TO_MONTH_FLOAT_BAL, " & _
    '                    l_ttd_pl & " AS TODAY_TOTAL_PL, " & _
    '                    l_ttm_pl & " AS TO_MONTH_TOTAL_PL, " & _
    '                    l_fx_comm & " AS TODAY_COMM_FX, " & _
    '                    l_fx_mcomm & " AS TO_MONTH_COMM_FX, " & _
    '                    l_fx_int & " AS TODAY_INT_FX, " & _
    '                    l_fx_mint & " AS TO_MONTH_INT_FX, " & _
    '                    l_fx_pl & " AS TODAY_PL_FX, " & _
    '                    l_fx_mpl & " AS TO_MONTH_PL_FX, " & _
    '                    l_fx_rpl & " AS TODAY_REAL_PL_FX, " & _
    '                    l_fx_mrpl & " AS TO_MONTH_REAL_PL_FX, " & _
    '                    l_fx_float & " AS TODAY_FLOAT_PLCF_FX, " & _
    '                    l_fx_float & " AS TO_MONTH_FLOAT_PLCF_FX, " & _
    '                    ldtwAccum("D_PL_FHK") & " AS TODAY_FLOAT_PLBF_FX, " & _
    '                    l_afx_float & " AS TODAY_FLOAT_PLBAL_FX, " & _
    '                    ldtwAccum("D_PL_FUS") & " AS TO_MONTH_FLOAT_PLBF_FX, " & _
    '                    l_mafx_float & " AS TO_MONTH_FLOAT_PLBAL_FX, " & _
    '                    l_fxttd_pl & " AS TODAY_TOTAL_PL_FX, " & _
    '                    l_fxttm_pl & " AS TO_MONTH_TOTAL_PL_FX, " & _
    '                    l_bu_comm & " AS TODAY_COMM_BU, " & _
    '                    l_bu_mcomm & " AS TO_MONTH_COMM_BU, " & _
    '                    l_bu_int & " AS TODAY_INT_BU, " & _
    '                    l_bu_mint & " AS TO_MONTH_INT_BU, " & _
    '                    l_tstorage & " AS TODAY_STOR_BU, " & _
    '                    l_mstorage & " AS TO_MONTH_STOR_BU, " & _
    '                    l_bu_pl & " AS TODAY_PL_BU, " & _
    '                    l_bu_mpl & " AS TO_MONTH_PL_BU, " & _
    '                    l_bu_rpl & " AS TODAY_REAL_PL_BU, " & _
    '                    l_bu_mrpl & " AS TO_MONTH_REAL_PL_BU, " & _
    '                    l_bu_float & " AS TODAY_FLOATCF_BU, " & _
    '                    l_bu_float & " AS TO_MONTH_FLOATCF_BU, " & _
    '                    ldtwAccum("D_PL_BHK") & " AS TODAY_FLOATBF_BU, " & _
    '                    l_abu_float & " AS TODAY_FLOATBAL_BU, " & _
    '                    ldtwAccum("D_PL_BUS") & " AS TO_MONTH_FLOATBF_BU, " & _
    '                    l_mabu_float & " AS TO_MONTH_FLOATBAL_BU, " & _
    '                    l_buttd_pl & " AS TODAY_PLBAL_BU, " & _
    '                    l_buttm_pl & " AS TO_MONTH_PLBAL_BU "

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            AddParam(rpt, "paraBrhCurr", Trim(GStrBrhCurrency))
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function PR_AC_ADJUSTMENT() As ReportClass

    '        Dim lstrSQL As String = ""
    '        Dim ldtsResult As DataSet
    '        Dim ldtsAcct As DataSet
    '        Dim ldtwAcct As DataRow
    '        Dim rpt As New RptAdjustment

    '        lstrSQL = "Select * from Account Where D_ADJ_COMM <> 0 OR D_ADJ_INT <> 0 OR " & _
    '                    "D_ADJ_STO <> 0 OR D_ADJ_PL <> 0 "

    '        ldtsAcct = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsAcct.Tables(0).Rows.Count > 0 Then
    '            lstrSQL = "Create Table [dbo].[#ADJ_RPT] (" & _
    '                        "[TDATE] [datetime] NULL, " & _
    '                        "[ANO] [nvarchar](5) NOT NULL, " & _
    '                        "[SNO] [nvarchar](5) NOT NULL, " & _
    '                        "[COMM] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[INTEREST] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[STORAGE] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[PL] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[TOTAL] [decimal](18,2) NULL DEFAULT((0)) " & _
    '                        ") ON [PRIMARY]"

    '            GFncRunSQL(GSCnSqlConn, lstrSQL)

    '            For Each ldtwAcct In ldtsAcct.Tables(0).Rows
    '                lstrSQL = "Insert into #ADJ_RPT (TDATE, ANO, SNO, COMM, INTEREST, STORAGE, PL, TOTAL) " & _
    '                            "VALUES (" & _
    '                            "'" & Format(g_tdate, "yyyy/MM/dd") & "', " & _
    '                            "'" & ldtwAcct("D_ANO") & "', " & _
    '                            "'" & ldtwAcct("D_SNO") & "', " & _
    '                            ldtwAcct("D_ADJ_COMM") & ", " & _
    '                            ldtwAcct("D_ADJ_INT") & ", " & _
    '                            ldtwAcct("D_ADJ_STO") & ", " & _
    '                            ldtwAcct("D_ADJ_PL") & ", " & _
    '                            ldtwAcct("D_ADJ_COMM") + ldtwAcct("D_ADJ_INT") + _
    '                            ldtwAcct("D_ADJ_STO") + ldtwAcct("D_ADJ_PL") & ") "
    '                GFncRunSQL(GSCnSqlConn, lstrSQL)
    '            Next

    '            lstrSQL = "Select * from #ADJ_RPT "

    '            ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '            lstrSQL = "Drop Table #ADJ_RPT "

    '            GFncRunSQL(GSCnSqlConn, lstrSQL)

    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function PR_AC_ACCUMULATION() As ReportClass
    '        Dim lstrSQL As String = ""
    '        Dim ldtsResult As DataSet
    '        Dim ldtwResult As DataRow
    '        Dim rpt As New RptAccumulation

    '        Dim ldtsTerms As DataSet = Me.lFunGetAllTerms
    '        Dim ldtsSales As DataSet = Me.lFunGetAllSales
    '        Dim ldtsAcc As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtsOp As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim ldtsDate As DataSet
    '        modcal.Prepare_Dataset_for_Cal(ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '        lstrSQL = "Select s.D_SGROUP as SGRP, s.D_SNO as SNO, a.D_ANO as ANO, " & _
    '                    "a.D_MARG_IN as MAR_IN, a.D_MARG_OUT as MAR_OUT, (a.D_MARG_IN - a.D_MARG_OUT) as MAR_NET, " & _
    '                    "0.0 as COMM, 0.0 as INTEREST, (select D_TDATE from [date]) as TDATE From SALES s, ACCOUNT a Where " & _
    '                    "s.D_SNO = a.D_SNO Order By s.D_SGROUP, s.D_SNO, a.D_ANO "

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            For Each ldtwResult In ldtsResult.Tables(0).Rows
    '                Application.DoEvents()

    '                define_trading_terms(ldtwResult("ANO"), , ldtsAcc, ldtsTerms)
    '                GET_AC_STATUS(ldtwResult("ANO"), "N", "N", g_int_date, , , ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '                ldtwResult.Item("COMM") = ag_status(AC_COMM)
    '                ldtwResult.Item("INTEREST") = ag_status(AC_INTEREST)
    '            Next

    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function PR_TITLE() As ReportClass
    '        Dim lstrSQL As String = ""
    '        Dim ldtsResult As DataSet
    '        Dim rpt As New RptTitle
    '        Dim lstrIntStatus As String = ""

    '        lstrSQL = "Select (select D_TDATE from [date]) as TDATE, C.D_CURRENCY as CUR, " & _
    '                    "C.D_VAL_DATE as VDATE, C.D_L_INTRES as LONG, C.D_S_INTRES as SHORT, " & _
    '                    "C.D_H_PRICE as HIGH, C.D_L_PRICE as LOW, C.D_C_PRICE as SETTLEMENT From " & _
    '                    "CURRENCY C, TERMS_CONFIG T Where C.D_CURRENCY = T.D_CURRENCY Order By T.TITLE_ORDER "

    '        ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If ldtsResult.Tables(0).Rows.Count > 0 Then
    '            rpt.SetDataSource(ldtsResult.Tables(0))
    '            AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '            If IsDate(g_int_date) Then
    '                lstrIntStatus = "Claim date"
    '            End If
    '            AddParam(rpt, "paraIntStatus", lstrIntStatus)
    '            AddParam(rpt, "paraIntCutDate", g_int_date)
    '            AddParam(rpt, "paraLstClaimDate", g_l_int_ca)
    '            AddParam(rpt, "paraLstCutDate", g_l_int_cu)
    '            AddParam(rpt, "paraLstTDate", g_l_tdate)
    '            AddParam(rpt, "paraUSExRate", g_us_rate)

    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function OVER_LOSS_REPORT() As ReportClass
    '        Dim lstrSQL As String = ""
    '        Dim ldtwAcc As DataRow
    '        Dim ldtsResult As DataSet
    '        Dim ldtwResult As DataRow
    '        Dim rpt As New RptOverLoss
    '        Dim l_pr_bal As Decimal
    '        Dim l_act_pl As Decimal

    '        Dim ldtsTerms As DataSet = Me.lFunGetAllTerms
    '        Dim ldtsAcc As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtsOp As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim ldtsDate As DataSet
    '        modcal.Prepare_Dataset_for_Cal(ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '        If ldtsAcc.Tables(0).Rows.Count > 0 Then
    '            lstrSQL = "CREATE TABLE [dbo].[#OVERLOSSRPT] (" & _
    '                        "[TDATE] [datetime] NULL, " & _
    '                        "[ANO] [nvarchar](5) NOT NULL, " & _
    '                        "[SNO] [nvarchar](5) NOT NULL, " & _
    '                        "[PREV_BAL] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[MAR_IO] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[ACT_PL] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[NEW_BAL] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[FLOATING] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[GOLD_VALUE] [decimal](18,2) NULL DEFAULT((0)), " & _
    '                        "[EQUITY] [decimal](18,2) NULL DEFAULT((0)) " & _
    '                        ") ON [PRIMARY] "

    '            GFncRunSQL(GSCnSqlConn, lstrSQL)

    '            lstrSQL = "Select * from #OVERLOSSRPT"

    '            ldtsResult = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '            lstrSQL = "Drop Table #OVERLOSSRPT"

    '            GFncRunSQL(GSCnSqlConn, lstrSQL)

    '            For Each ldtwAcc In ldtsAcc.Tables(0).Rows
    '                Application.DoEvents()

    '                define_trading_terms(ldtwAcc("D_ANO"), , ldtsAcc, ldtsTerms)
    '                GET_AC_STATUS(ldtwAcc("D_ANO"), "N", "N", g_int_date, , , ldtsAcc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '                If ag_status(AC_EQUITY) < 0 Then
    '                    l_pr_bal = ldtwAcc("D_PR_BAL")
    '                    l_act_pl = ag_status(AC_PL) + ag_status(AC_INTEREST) + _
    '                                ag_status(AC_COMM) + ag_status(AC_STORAGE)

    '                    ldtwResult = ldtsResult.Tables(0).NewRow
    '                    ldtwResult("tdate") = g_tdate
    '                    ldtwResult("ano") = ldtwAcc("d_ano")
    '                    ldtwResult("sno") = ldtwAcc("d_sno")
    '                    ldtwResult("prev_bal") = l_pr_bal
    '                    ldtwResult("mar_io") = ag_status(AC_MARGIN_IO)
    '                    ldtwResult("act_pl") = l_act_pl
    '                    ldtwResult("new_bal") = ag_status(AC_BALANCE)
    '                    ldtwResult("floating") = ag_status(AC_FLOATING)
    '                    ldtwResult("gold_value") = ag_status(AC_GOLD_VALUE)
    '                    ldtwResult("equity") = ag_status(AC_EQUITY)
    '                    ldtsResult.Tables(0).Rows.Add(ldtwResult)
    '                End If
    '            Next

    '            If ldtsResult.Tables(0).Rows.Count > 0 Then
    '                rpt.SetDataSource(ldtsResult.Tables(0))
    '                AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '                Return rpt
    '            Else
    '                Return Nothing
    '            End If
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    '    Public Function Executed_Position_Summary_Rpt(ByVal lstrAno As String) As ReportClass
    '        Dim rptAS As New RptPosSummary
    '        Dim ldtsacc As DataSet
    '        Dim lintCnt As Integer

    '        ldtsacc = Executed_Account_Status_Account_Rpt(lstrAno)
    '        If ldtsacc.Tables(0).Rows.Count <= 0 Then
    '            Return Nothing
    '        End If
    '        modcal.define_trading_terms(lstrAno)

    '        Dim ldtsOrder As DataSet
    '        ldtsOrder = Executed_Account_Status_OpnOrd_Rpt(ldtsacc.Tables(0).Rows(0), lstrAno)
    '        For lintCnt = 0 To ldtsOrder.Tables(0).Rows.Count - 1
    '            ldtsOrder.Tables(0).Rows(lintCnt).Item("d_interest") = 0
    '            ldtsOrder.Tables(0).Rows(lintCnt).Item("d_storage") = 0
    '        Next
    '        rptAS.Subreports.Item("RptPosOpen").SetDataSource(ldtsOrder.Tables(0))
    '        lsubSetCurrConfig(rptAS, "RptPosOpen")
    '        rptAS.Subreports.Item("RptPosLiq").SetDataSource(Executed_Account_Status_LiqOrd_Rpt(ldtsacc.Tables(0).Rows(0), lstrAno).Tables(0))
    '        lsubSetCurrConfig(rptAS, "RptPosLiq")
    '        modcal.GET_AC_STATUS(lstrAno, "Y", "N", Nothing)
    '        ag_status(AC_INTEREST) = ldtsacc.Tables(0).Rows(0).Item("D_ADJ_INT") + ag_status(AC_LIQ_INT)

    '        ag_status(AC_STORAGE) = ldtsacc.Tables(0).Rows(0).Item("D_ADJ_STO") + ag_status(AC_LIQ_STOR)

    '        ag_status(AC_BALANCE) = ldtsacc.Tables(0).Rows(0).Item("D_PR_BAL") + _
    '                                ag_status(AC_MARGIN_IO) + _
    '                                ag_status(AC_PL) + _
    '                                ag_status(AC_INTEREST) + _
    '                                ag_status(AC_COMM) + _
    '                                ag_status(AC_STORAGE)

    '        ag_status(AC_EQUITY) = ag_status(AC_BALANCE) + _
    '                               ag_status(AC_FLOATING) + _
    '                               ag_status(AC_GOLD_VALUE)

    '        rptAS.SetDataSource(ldtsacc.Tables(0))
    '        AddParam(rptAS, "ac_comm", ag_status(AC_COMM))
    '        AddParam(rptAS, "ac_storage", ag_status(AC_STORAGE))
    '        AddParam(rptAS, "ac_interest", ag_status(AC_INTEREST))
    '        AddParam(rptAS, "ac_pl", ag_status(AC_PL))
    '        AddParam(rptAS, "ac_floating", ag_status(AC_FLOATING))
    '        AddParam(rptAS, "ac_margin_io", ag_status(AC_MARGIN_IO))
    '        AddParam(rptAS, "ac_gold_value", ag_status(AC_GOLD_VALUE))
    '        AddParam(rptAS, "ac_equity", ag_status(AC_EQUITY))
    '        AddParam(rptAS, "mar_day", ag_margin(MAR_DAY))
    '        AddParam(rptAS, "mar_night", ag_margin(MAR_NIGHT))
    '        AddParam(rptAS, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '        Return rptAS

    '    End Function

    '    Public Function Executed_Account_Status_Rpt(ByVal lstrAno As String) As ReportClass

    '        Dim rptAS As New RptAccStatus
    '        Dim ldtsacc As DataSet

    '        ldtsacc = Executed_Account_Status_Account_Rpt(lstrAno)
    '        If ldtsacc.Tables(0).Rows.Count <= 0 Then
    '            Return Nothing
    '        End If
    '        define_trading_terms(lstrAno)
    '        rptAS.Subreports.Item("RptASCurrency01").SetDataSource(Executed_Account_Status_Currency_Rpt(0).Tables(0))
    '        rptAS.Subreports.Item("RptASCurrency02").SetDataSource(Executed_Account_Status_Currency_Rpt(1).Tables(0))
    '        rptAS.Subreports.Item("RptASOpnOrd").SetDataSource(Executed_Account_Status_OpnOrd_Rpt(ldtsacc.Tables(0).Rows(0), lstrAno).Tables(0))
    '        lsubSetCurrConfig(rptAS, "RptASOpnOrd")
    '        rptAS.Subreports.Item("RptASLiqOrd").SetDataSource(Executed_Account_Status_LiqOrd_Rpt(ldtsacc.Tables(0).Rows(0), lstrAno).Tables(0))
    '        lsubSetCurrConfig(rptAS, "RptASLiqOrd")

    '        modcal.GET_AC_STATUS(lstrAno, "Y", "N", Nothing)
    '        rptAS.Subreports.Item("RptASSummary").SetDataSource(Executed_Account_Status_Summary_Rpt().Tables(0))
    '        rptAS.SetDataSource(ldtsacc.Tables(0))
    '        AddParam(rptAS, "ac_comm", ag_status(AC_COMM))
    '        AddParam(rptAS, "ac_storage", ag_status(AC_STORAGE))
    '        AddParam(rptAS, "ac_interest", ag_status(AC_INTEREST))
    '        AddParam(rptAS, "ac_pl", ag_status(AC_PL))
    '        AddParam(rptAS, "ac_floating", ag_status(AC_FLOATING))
    '        AddParam(rptAS, "ac_margin_io", ag_status(AC_MARGIN_IO))
    '        AddParam(rptAS, "ac_gold_value", ag_status(AC_GOLD_VALUE))
    '        AddParam(rptAS, "ac_equity", ag_status(AC_EQUITY))
    '        AddParam(rptAS, "mar_day", ag_margin(MAR_DAY))
    '        AddParam(rptAS, "mar_night", ag_margin(MAR_NIGHT))

    '        If ag_status(AC_EQUITY) > ag_margin(MAR_DAY) Or ag_margin(MAR_DAY) = 0 Then
    '            AddParam(rptAS, "eff_ratio_day", "100.0 %")
    '        Else
    '            AddParam(rptAS, "eff_ratio_day", Format(ag_status(AC_EQUITY) / ag_margin(MAR_DAY) * 100, "##0.0 %"))
    '        End If
    '        If ag_status(AC_EQUITY) > ag_margin(MAR_NIGHT) Or ag_margin(MAR_NIGHT) = 0 Then
    '            AddParam(rptAS, "eff_ratio_night", "100.0 %")
    '        Else
    '            AddParam(rptAS, "eff_ratio_night", Format(ag_status(AC_EQUITY) / ag_margin(MAR_NIGHT) * 100, "##0.0 %"))
    '        End If
    '        AddParam(rptAS, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '        Return rptAS

    '    End Function

    '    Private Function Executed_Account_parameter_Rpt(ByVal lobjparameter, ByVal lstrname) As ParameterField
    '        Dim discreteVal As New ParameterDiscreteValue()
    '        Dim paramField As New ParameterField()

    '        discreteVal.Value = lobjparameter
    '        paramField.ParameterFieldName = lstrname
    '        paramField.CurrentValues.Add(discreteVal)
    '        Return paramField

    '    End Function
    '    Private Function Executed_Account_Status_Account_Rpt(ByVal lstrAno As String) As DataSet
    '        Dim ldtsacc As DataSet
    '        Dim lstrSQL As String
    '        Dim ldecPrice As Decimal = 0
    '        Dim ldtsGold As DataSet

    '        'lstrSQL = " select a.*, b.d_sname as d_ae_name, cast(null as datetime) as d_tdate, " & _
    '        '            " cast(null as datetime) as d_int_date, cast(0 as decimal(18,4)) as d_gold_price " & _
    '        '         " from account a inner join sales b on a.d_sno = b.d_sno " & _
    '        '            " where d_ano = '" & lstrAno & "' "
    '        lstrSQL = " select a.*, b.d_sname as d_ae_name, b.d_sgroup as d_ae_group, cast(null as datetime) as d_tdate, " & _
    '            " cast(null as datetime) as d_int_date, cast(0 as decimal(18,4)) as d_gold_price " & _
    '         " from account a inner join sales b on a.d_sno = b.d_sno " & _
    '            " where d_ano = '" & lstrAno & "' "

    '        ldtsacc = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        If ldtsacc.Tables(0).Rows.Count > 0 Then
    '            ldtsGold = Executed_Account_Status_GetGoldCurrency_Rpt()
    '            If ldtsGold.Tables(0).Rows.Count > 0 Then
    '                ldecPrice = ldtsGold.Tables(0).Rows(0).Item("d_c_price")
    '            End If
    '            ldtsacc.Tables(0).Rows(0).Item("d_gold_price") = ldecPrice
    '            ldtsacc.Tables(0).Rows(0).Item("d_tdate") = g_tdate
    '            ldtsacc.Tables(0).Rows(0).Item("d_int_date") = g_int_date
    '        End If

    '        Return ldtsacc

    '    End Function
    '    Private Function Executed_Account_Status_GetCurrency_Rpt(ByVal lstrCurrency As String) As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim lstrSQL As String

    '        lstrSQL = "select * from currency where d_currency = '" & lstrCurrency & "' "
    '        ldtsCurr = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        Return ldtsCurr

    '    End Function
    '    Private Function Executed_Account_Status_GetGoldCurrency_Rpt() As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim lstrSQL As String

    '        lstrSQL = "select a.* from currency a inner join [date] b on a.d_currency = b.strcalgold "
    '        ldtsCurr = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        Return ldtsCurr

    '    End Function
    '    Private Function Executed_Account_Status_Currency_Rpt(ByVal lintflag As Integer) As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim lstrSQL As String
    '        Dim lintcnt As Integer = 0

    '        lstrSQL = "select a.d_currency, b.d_l_intres, b.d_s_intres, b.d_val_date " & _
    '                    " from terms_config a inner join currency b on a.d_currency = b.d_currency order by opn_pos_order "
    '        ldtsCurr = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        If ldtsCurr.Tables(0).Rows.Count > 0 Then
    '            For lintcnt = 1 To ldtsCurr.Tables(0).Rows.Count
    '                If lintcnt Mod 2 = lintflag Then
    '                    ldtsCurr.Tables(0).Rows(lintcnt - 1).Delete()
    '                End If
    '            Next
    '            ldtsCurr.Tables(0).AcceptChanges()
    '        End If

    '        Return ldtsCurr

    '    End Function
    '    Private Function Executed_Account_Status_OpnOrd_Rpt(ByVal ldtwacc As DataRow, ByVal lstrAno As String) As DataSet
    '        Dim ldtsOrd As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtcOrder As DataRowCollection
    '        Dim ldtwOrder As DataRow
    '        Dim lstrSQL As String

    '        afill(ag_status, 0, AC_STATUS_SIZE)
    '        lstrSQL = " select d_o_date,  cast('' as varchar(6)) as d_order," & _
    '              " cast('' as varchar(6)) as  d_op,  cast(d_buy_sell as varchar(2)) as d_type," & _
    '                 " d_currency, d_o_price, d_c_price, d_lots, d_pl, " & _
    '                    " cast(0 as decimal(18,4)) as d_commission," & _
    '                 " cast(0 as decimal(18,4)) as d_interest, " & _
    '                 " cast(0 as decimal(18,4)) as d_storage " & _
    '                    " from [order] where 1 < 0 "
    '        ldtsOrd = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        lstrSQL = "Select * from [order] Where d_ano = '" & lstrAno & _
    '                    "' and d_state = '" & O_New & _
    '                    "' and d_new_liq = 'N' " & _
    '                    " and d_lots > 0  order by d_ano, d_o_date, d_ord_no "
    '        ldtsOrder = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        If ldtsOrder.Tables(0).Rows.Count <= 0 Then
    '            Return ldtsOrd
    '        End If
    '        ldtcOrder = ldtsOrder.Tables(0).Rows
    '        For Each ldtwOrder In ldtcOrder
    '            afill(ag_order, 0, O_ORDER_SIZE)
    '            modcal.GATHER_ORD(ldtwOrder, ldtwacc, "N")
    '            modcal.CAL_ORDER_PROFIT("N", Nothing)

    '            Dim ldtwOrd As DataRow = ldtsOrd.Tables(0).NewRow
    '            ldtwOrd("d_o_date") = ag_order(O_DATE)
    '            ldtwOrd("d_order") = Trim(Str(ag_order(O_NO))) & Trim(ag_order(O_ORD_TYPE))
    '            ldtwOrd("d_type") = ag_order(O_BUY_SELL)
    '            ldtwOrd("d_currency") = ag_order(O_CUR)
    '            ldtwOrd("d_o_price") = ag_order(O_O_PRICE)
    '            ldtwOrd("d_c_price") = ag_order(O_C_PRICE)
    '            ldtwOrd("d_lots") = ag_order(O_LOTS)
    '            ldtwOrd("d_pl") = ag_order(O_FLOATING)
    '            ldtwOrd("d_commission") = ag_order(O_COMM)
    '            ldtwOrd("d_interest") = ag_order(O_INTEREST)
    '            ldtwOrd("d_storage") = ag_order(O_STORAGE)
    '            ldtsOrd.Tables(0).Rows.Add(ldtwOrd)
    '        Next

    '        Return (ldtsOrd)

    '    End Function
    '    Private Function Executed_Account_Status_LiqOrd_Rpt(ByVal ldtwacc As DataRow, ByVal lstrAno As String) As DataSet
    '        Dim ldtsOrd As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtcOrder As DataRowCollection
    '        Dim ldtwOrder As DataRow
    '        Dim lstrSQL As String

    '        afill(ag_status, 0, AC_STATUS_SIZE)
    '        lstrSQL = " select d_o_date,  cast('' as varchar(6)) as d_order," & _
    '              " cast('' as varchar(6)) as  d_op,  cast(d_buy_sell as varchar(2)) as d_type, " & _
    '                 " d_currency, d_o_price, d_c_price, d_lots, d_pl, " & _
    '                    " cast(0 as decimal(18,4)) as d_commission," & _
    '                 " cast(0 as decimal(18,4)) as d_interest, " & _
    '                 " cast(0 as decimal(18,4)) as d_storage, d_o_date as d_op_date " & _
    '                    " from [order] where 1 < 0 "
    '        ldtsOrd = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        lstrSQL = "Select * from [order] Where d_ano = '" & lstrAno & _
    '                            "' and d_new_liq = 'L'  order by d_ano, d_o_date, d_ord_no "
    '        ldtsOrder = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        If ldtsOrder.Tables(0).Rows.Count <= 0 Then
    '            Return ldtsOrd
    '        End If
    '        ldtcOrder = ldtsOrder.Tables(0).Rows
    '        For Each ldtwOrder In ldtcOrder

    '            Dim lstrOpNo As String = ldtwOrder("d_ord_no")
    '            Dim lstrOpType As String = ldtwOrder("d_ord_type")
    '            afill(ag_order, 0, O_ORDER_SIZE)
    '            modcal.GATHER_ORD(ldtwOrder, ldtwacc, "L")

    '            Dim ldtsop As DataSet
    '            Dim ldtwop As DataRow
    '            Dim ldtcop As DataRowCollection
    '            lstrSQL = "Select * from [order] Where d_ano = '" & lstrAno & _
    '                                "' and d_op_no = '" & lstrOpNo & _
    '                                "' and d_op_type = '" & lstrOpType & _
    '                                "' and d_state = '" & O_Liq & _
    '                                "' order by d_op_no, d_o_date, d_ord_no "
    '            ldtsop = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '            ldtcop = ldtsop.Tables(0).Rows
    '            For Each ldtwop In ldtcop

    '                modcal.GATHER_ORD(ldtwop, ldtwacc, "O")

    '                modcal.CAL_ORDER_PROFIT("L", Nothing)

    '                Dim ldtwOrd As DataRow = ldtsOrd.Tables(0).NewRow
    '                ldtwOrd("d_o_date") = ag_order(O_DATE)
    '                ldtwOrd("d_order") = Trim(Str(ag_order(O_NO))) & Trim(ag_order(O_ORD_TYPE))
    '                ldtwOrd("d_op") = ag_order(O_LIQ_NO)
    '                ldtwOrd("d_type") = ag_order(O_BUY_SELL) & IIf(ag_order(O_BUY_SELL) = "B", "S", "B")
    '                ldtwOrd("d_currency") = ag_order(O_CUR)
    '                ldtwOrd("d_o_price") = ag_order(O_O_PRICE)
    '                ldtwOrd("d_c_price") = ag_order(O_C_PRICE)
    '                ldtwOrd("d_lots") = ag_order(O_LOTS)
    '                ldtwOrd("d_pl") = ag_order(O_FLOATING)
    '                ldtwOrd("d_commission") = ag_order(O_COMM)
    '                ldtwOrd("d_interest") = ag_order(O_INTEREST)
    '                ldtwOrd("d_storage") = ag_order(O_STORAGE)
    '                ldtwOrd("d_op_date") = ag_order(O_LIQ_DATE)
    '                ldtsOrd.Tables(0).Rows.Add(ldtwOrd)
    '            Next
    '        Next

    '        Return (ldtsOrd)

    '    End Function
    '    Private Function Executed_Account_Status_Summary_Rpt() As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim lstrSQL As String
    '        Dim lintCnt As Integer

    '        lstrSQL = " select a.d_currency, cast( 0 as decimal(18,4) ) as d_lot_buy," & _
    '                " cast( 0 as decimal(18,4) ) as d_lot_sell, " & _
    '                " cast( 0 as decimal(18,4) ) as d_lot_open, " & _
    '                " cast( 0 as decimal(18,4) ) as d_lot_pair, " & _
    '                " cast( 0 as decimal(18,4) ) as d_full_day, " & _
    '                " cast( 0 as decimal(18,4) ) as d_full_on, " & _
    '                " cast( 0 as decimal(18,4) ) as d_70_day, " & _
    '                " cast( 0 as decimal(18,4) ) as d_70_on, " & _
    '                " cast( '' as nvarchar(5) ) as d_ano " & _
    '                " from terms_config a inner join currency b on a.d_currency = b.d_currency where 1< 0 "
    '        ldtsCurr = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        For lintCnt = 1 To ag_par_xsize
    '            If Trim(ag_par(lintCnt, 1)) <> "" Then
    '                Dim ldtsCurrency As DataSet
    '                ldtsCurrency = Executed_Account_Status_GetCurrency_Rpt(ag_par(lintCnt, 1))
    '                Dim ldtwCurr As DataRow = ldtsCurr.Tables(0).NewRow
    '                ldtwCurr("d_currency") = ag_par(lintCnt, 1)
    '                ldtwCurr("d_lot_buy") = GFncNoNullValue(ag_par(lintCnt, 2))
    '                ldtwCurr("d_lot_sell") = GFncNoNullValue(ag_par(lintCnt, 3))
    '                ldtwCurr("d_lot_open") = Math.Abs(ag_par(lintCnt, 2) - ag_par(lintCnt, 3))
    '                ldtwCurr("d_lot_pair") = Math.Min(ag_par(lintCnt, 2), ag_par(lintCnt, 3))
    '                ldtwCurr("d_full_day") = (ldtwCurr("d_lot_pair") * GFncNoNullValue(ldtsCurrency.Tables(0).Rows(0).Item("D_DAY_MAR")) _
    '                                + ldtwCurr("d_lot_open") * GFncNoNullValue(ldtsCurrency.Tables(0).Rows(0).Item("D_DAY_MAR")))
    '                ldtwCurr("d_full_on") = (ldtwCurr("d_lot_pair") * GFncNoNullValue(ldtsCurrency.Tables(0).Rows(0).Item("D_NIG_MAR")) _
    '                                       + ldtwCurr("d_lot_open") * GFncNoNullValue(ldtsCurrency.Tables(0).Rows(0).Item("D_NIG_MAR")))
    '                ldtwCurr("d_70_day") = ldtwCurr("d_full_day") * g_margin
    '                ldtwCurr("d_70_on") = ldtwCurr("d_full_on") * g_margin
    '                ldtsCurr.Tables(0).Rows.Add(ldtwCurr)
    '            End If
    '        Next

    '        Return ldtsCurr

    '    End Function
    '    Public Function Executed_Open_Position_Table_Rpt(ByVal ldtsOrder As DataSet, _
    '    ByVal ldtsCurr As DataSet, ByVal ldtsDate As DataSet, ByVal ldtsTerms As DataSet) As DataSet
    '        Dim lstrSQL As String
    '        Dim ldtsTable As New DataSet
    '        Dim ldtaOrder() As DataRow
    '        Dim ldtwOrder As DataRow
    '        Dim ldtsacc As DataSet
    '        Dim ldtwacc As DataRow
    '        Dim ldtcacc As DataRowCollection

    '        lstrSQL = " select d_currency, cast( 0 as decimal(18,4) ) as d_lot_buy, " & _
    '         " cast( 0 as decimal(18,4) ) as d_lot_sell, " & _
    '         " cast( 0 as decimal(18,4) ) as d_lot_buy_new, " & _
    '         " cast( 0 as decimal(18,4) ) as d_lot_buy_liq, " & _
    '        " cast( 0 as decimal(18,4) ) as d_lot_sell_new, " & _
    '        " cast( 0 as decimal(18,4) ) as d_lot_sell_liq, " & _
    '        " cast( 0 as decimal(18,4) ) as d_lot_buy_bf, " & _
    '        "cast( 0 as decimal(18,4) ) as d_lot_sell_bf, " & _
    '        " cast( 0 as decimal(18,4) ) as d_lot_buy_net, " & _
    '        "cast( 0 as decimal(18,4) ) as d_lot_sell_net, " & _
    '        " cast( 0 as decimal(18,4) ) as d_avg_buy_price, " & _
    '        " cast( 0 as decimal(18,4) ) as d_avg_sell_price, " & _
    '        " cast( 0 as decimal(18,4) ) as d_floating, " & _
    '        " cast( 0 as decimal(18,4) ) as d_interest, cast(0 as decimal(18,4)) as d_commission " & _
    '         " into #OP_Table from terms_config order by opn_pos_order "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        lstrSQL = "Select distinct a.* from account a inner join [order] b on a.d_ano = b.d_ano order by a.d_ano "
    '        ldtsacc = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        'If ldtsacc.Tables(0).Rows.Count <= 0 Then
    '        '    Return Nothing
    '        'End If
    '        ldtcacc = ldtsacc.Tables(0).Rows
    '        For Each ldtwacc In ldtcacc
    '            Dim lstrAno As String = ldtwacc("d_ano")
    '            define_trading_terms(lstrAno, , ldtsacc, ldtsTerms)

    '            ldtaOrder = ldtsOrder.Tables(0).Select("d_ano = '" & lstrAno & "' and d_state = '" & O_New & "' ")
    '            For Each ldtwOrder In ldtaOrder
    '                Application.DoEvents()

    '                Dim lstrBS = ldtwOrder("d_buy_sell")
    '                Dim ldbllots = ldtwOrder("d_lots")
    '                Dim lstrNewLiq = ldtwOrder("d_new_liq")

    '                lstrSQL = "update #OP_Table set d_currency = d_currency "
    '                If ldbllots > 0 And lstrNewLiq = "N" Then
    '                    afill(ag_order, 0, O_ORDER_SIZE)
    '                    modcal.GATHER_ORD(ldtwOrder, ldtwacc, "N", , ldtsCurr)
    '                    modcal.CAL_ORDER_PROFIT("N", Nothing, , ldtsDate, ldtsCurr)
    '                    If ldtwOrder("d_currency") = "SFR" Or _
    '                        ldtwOrder("d_currency") = "CAD" Or _
    '                            ldtwOrder("d_currency") = "YEN" Then
    '                        If lstrBS = "B" Then
    '                            lstrSQL &= ", d_lot_buy_net = d_lot_buy_net + " & ldbllots
    '                            'lstrSQL &= ", d_avg_buy_price = d_avg_buy_price + " & ldbllots / ag_order(O_O_PRICE)
    '                        Else
    '                            lstrSQL &= ", d_lot_sell_net = d_lot_sell_net + " & ldbllots
    '                            'lstrSQL &= ", d_avg_sell_price = d_avg_sell_price + " & ldbllots / ag_order(O_O_PRICE)

    '                        End If
    '                    Else
    '                        If lstrBS = "B" Then
    '                            lstrSQL &= ", d_lot_buy_net = d_lot_buy_net + " & ldbllots
    '                            'lstrSQL &= ", d_avg_buy_price = d_avg_buy_price + " & ldbllots * ag_order(O_O_PRICE)
    '                        Else
    '                            lstrSQL &= ", d_lot_sell_net = d_lot_sell_net + " & ldbllots
    '                            'lstrSQL &= ", d_avg_sell_price = d_avg_sell_price + " & ldbllots * ag_order(O_O_PRICE)
    '                        End If
    '                    End If
    '                    lstrSQL &= ", d_floating = d_floating + (" & ag_order(O_FLOATING) & ") "
    '                    lstrSQL &= ", d_interest = d_interest + (" & ag_order(O_INTEREST) & ") "
    '                End If

    '                If (ldtwOrder("D_O_DATE") = g_tdate) Then
    '                    If lstrNewLiq = "N" Then
    '                        If lstrBS = "B" Then
    '                            lstrSQL &= ", d_lot_buy_new = d_lot_buy_new + " & ldtwOrder("d_lots2")
    '                        Else
    '                            lstrSQL &= ", d_lot_sell_new = d_lot_sell_new + " & ldtwOrder("d_lots2")
    '                        End If
    '                    Else
    '                        If lstrBS = "S" Then
    '                            lstrSQL &= ", d_lot_buy_liq = d_lot_buy_liq + " & ldtwOrder("d_lots2")
    '                        Else
    '                            lstrSQL &= ", d_lot_sell_liq = d_lot_sell_liq + " & ldtwOrder("d_lots2")
    '                        End If

    '                    End If
    '                End If
    '                lstrSQL &= " where d_currency = '" & ldtwOrder("d_currency") & "' "
    '                GFncRunSQL(GSCnSqlConn, lstrSQL)
    '            Next
    '        Next

    '        lstrSQL = "update #OP_Table set d_lot_buy_bf = d_lot_buy_net - d_lot_buy_new + d_lot_buy_liq " & _
    '                          ", d_lot_sell_bf = d_lot_sell_net - d_lot_sell_new + d_lot_sell_liq "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        lstrSQL = " update #op_table set d_avg_buy_price = a. avg_price " & _
    '                    " from ( select  d_currency, d_buy_sell, " & _
    '                    " case when d_currency in ('YEN', 'SFR', 'CAD') " & _
    '                    " then sum(d_lots)/ sum(d_lots / d_o_price) " & _
    '                    " when d_currency not in ('YEN', 'SFR', 'CAD') " & _
    '                    " then sum(d_lots * d_o_price)/ sum(d_lots) end as avg_price " & _
    '                    "         from [order]  " & _
    '                    " where d_state = 'O' " & _
    '                    " and d_buy_sell = 'B' " & _
    '                    " and d_new_liq = 'N' " & _
    '                    " and d_lots > 0 " & _
    '                    " group by d_currency, d_buy_sell ) a " & _
    '                    " where #op_table.d_currency = a.d_currency "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        lstrSQL = " update #op_table set d_avg_sell_price = a. avg_price " & _
    '                           " from ( select  d_currency, d_buy_sell, " & _
    '                           " case when d_currency in ('YEN', 'SFR', 'CAD') " & _
    '                           " then sum(d_lots)/ sum(d_lots / d_o_price) " & _
    '                           " when d_currency not in ('YEN', 'SFR', 'CAD') " & _
    '                           " then sum(d_lots * d_o_price)/ sum(d_lots) end as avg_price " & _
    '                           "         from [order]  " & _
    '                           " where d_state = 'O' " & _
    '                           " and d_buy_sell = 'S' " & _
    '                           " and d_new_liq = 'N' " & _
    '                           " and d_lots > 0 " & _
    '                           " group by d_currency, d_buy_sell ) a " & _
    '                           " where #op_table.d_currency = a.d_currency "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        lstrSQL = "select * from #OP_Table "
    '        ldtsTable = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        lstrSQL = "drop table #OP_Table "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        Return ldtsTable

    '    End Function
    '    Public Function Executed_Open_Position_Rpt(ByVal lstrOpt As String) As ReportClass
    '        Dim ldtsOrd As DataSet
    '        Dim ldtsacc As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtaOrder() As DataRow
    '        Dim ldtwOrder As DataRow
    '        Dim ldtwacc As DataRow
    '        Dim ldtcacc As DataRowCollection
    '        Dim lstrSQL As String
    '        Dim rptOP As New Rptopnposition
    '        Dim lstrAno As String
    '        Dim ldtsTerms As DataSet = Me.lFunGetAllTerms
    '        Dim ldtsSales As DataSet = Me.lFunGetAllSales

    '        Dim ldtsOp As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim ldtsDate As DataSet
    '        modcal.Prepare_Dataset_for_Cal(ldtsacc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '        lstrSQL = " select a.d_ano, a.d_o_date, cast('' as varchar(6)) as d_order, " & _
    '              " cast('' as varchar(6)) as  d_op, " & _
    '              " cast(a.d_buy_sell as varchar(2)) as d_type, " & _
    '            " a.d_currency, a.d_o_price, a.d_c_price, a.d_lots, a.d_pl, " & _
    '             " cast(0 as decimal(18,4)) as d_interest, " & _
    '             " cast(0 as decimal(18,4)) as d_storage, " & _
    '            " cast(0 as decimal(18,4)) as d_nec_day, " & _
    '            " cast(0 as decimal(18,4)) as d_nec_night, " & _
    '             " c.d_sno, c.d_sgroup,cast(0 as decimal(18,4)) as d_commission " & _
    '            " from [order] a inner join account b on a.d_ano = b.d_ano " & _
    '            " left outer join sales c on c.d_sno = b.d_sno where 1<=0 "
    '        ldtsOrd = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        If lstrOpt <> "TABLE" Then
    '            ldtsacc.Dispose()
    '            lstrSQL = "Select distinct b.* " & _
    '                        " from [order] a inner join account b on a.d_ano = b.d_ano " & _
    '                         " left outer join sales c on c.d_sno = b.d_sno " & _
    '                        " where a.d_state = '" & O_New & _
    '                        "' and a.d_new_liq = 'N' " & _
    '                        " and a.d_lots > 0  order by b.d_ano "
    '            ldtsacc = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '            'If ldtsacc.Tables(0).Rows.Count <= 0 Then
    '            '    Return Nothing
    '            'End If
    '            ldtcacc = ldtsacc.Tables(0).Rows
    '            For Each ldtwacc In ldtcacc
    '                lstrAno = ldtwacc("d_ano")
    '                define_trading_terms(lstrAno, , ldtsacc, ldtsTerms)
    '                modcal.GET_AC_STATUS(lstrAno, "Y", "N", Nothing, , , ldtsacc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '                ldtaOrder = ldtsOrder.Tables(0).Select("d_ano = '" & lstrAno & "' and d_state = '" & O_New & _
    '                                                    "' and d_new_liq = 'N' and d_lots > 0 ")
    '                For Each ldtwOrder In ldtaOrder
    '                    Application.DoEvents()
    '                    afill(ag_order, 0, O_ORDER_SIZE)
    '                    modcal.GATHER_ORD(ldtwOrder, ldtwacc, "N", , ldtsCurr)
    '                    modcal.CAL_ORDER_PROFIT("N", Nothing, , ldtsDate, ldtsCurr)

    '                    Dim ldtwOrd As DataRow = ldtsOrd.Tables(0).NewRow
    '                    ldtwOrd("d_ano") = ldtwacc("d_ano")
    '                    ldtwOrd("d_sno") = ldtwacc("d_sno")
    '                    ldtwOrd("d_sgroup") = Me.lFunGetSalesGroup(ldtsSales, ldtwacc("d_sno"))
    '                    ldtwOrd("d_o_date") = ag_order(O_DATE)
    '                    ldtwOrd("d_order") = Trim(Str(ag_order(O_NO))) & Trim(ag_order(O_ORD_TYPE))
    '                    ldtwOrd("d_type") = ag_order(O_BUY_SELL)
    '                    ldtwOrd("d_currency") = ag_order(O_CUR)
    '                    ldtwOrd("d_o_price") = ag_order(O_O_PRICE)
    '                    ldtwOrd("d_c_price") = ag_order(O_C_PRICE)
    '                    ldtwOrd("d_lots") = ag_order(O_LOTS)
    '                    ldtwOrd("d_pl") = ag_order(O_FLOATING)
    '                    ldtwOrd("d_interest") = ag_order(O_INTEREST)
    '                    ldtwOrd("d_storage") = ag_order(O_STORAGE)
    '                    ldtwOrd("d_nec_day") = ag_margin(MAR_DAY)
    '                    ldtwOrd("d_nec_night") = ag_margin(MAR_NIGHT)
    '                    ldtsOrd.Tables(0).Rows.Add(ldtwOrd)
    '                Next
    '            Next
    '        End If

    '        Dim ldtsTable As DataSet = Nothing
    '        If lstrOpt <> "DETAIL" Then
    '            ldtsTable = Executed_Open_Position_Table_Rpt(ldtsOrder, ldtsCurr, ldtsDate, ldtsTerms)
    '            rptOP.Subreports("RptOpenOptable").SetDataSource(ldtsTable.Tables(0))
    '            rptOP.Subreports("RptOpenOptable1").SetDataSource(ldtsTable.Tables(0))
    '            Dim ldtsTConfig As DataSet
    '            lstrSQL = "Select * from Terms_config  order by opn_pos_order  "
    '            ldtsTConfig = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '            rptOP.Subreports("RptOpenOptable1").Database.Tables("Terms_Config").SetDataSource(ldtsTConfig.Tables(0))
    '        End If
    '        rptOP.SetDataSource(ldtsOrd.Tables(0))
    '        lsubSetCurrConfig(rptOP)
    '        AddParam(rptOP, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '        AddParam(rptOP, "paraTdate", g_tdate)
    '        AddParam(rptOP, "paraDayNight", g_day_night)
    '        AddParam(rptOP, "paraOption", lstrOpt)
    '        Return rptOP

    '    End Function
    '    Public Function Executed_Liq_Position_Rpt() As ReportClass
    '        Dim ldtsOrd As DataSet
    '        Dim ldtsTable As DataSet
    '        Dim ldtatable() As DataRow
    '        Dim ldtsacc As DataSet
    '        Dim ldtsOrder As DataSet
    '        Dim ldtaOrder() As DataRow
    '        Dim ldtwOrder As DataRow
    '        Dim ldtwacc As DataRow
    '        Dim ldtcacc As DataRowCollection
    '        Dim lstrSQL As String
    '        Dim rptOP As New RptLiqPosition
    '        Dim lstrAno As String
    '        Dim ldtsTerms As DataSet = Me.lFunGetAllTerms
    '        Dim ldtsSales As DataSet = Me.lFunGetAllSales

    '        Dim ldtsOp As DataSet
    '        Dim ldtsCurr As DataSet
    '        Dim ldtsDate As DataSet
    '        modcal.Prepare_Dataset_for_Cal(ldtsacc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '        lstrSQL = " select d_currency, cast( 0 as decimal(18,4) ) as d_lot_buy, " & _
    '                " cast( 0 as decimal(18,4) ) as d_lot_sell, " & _
    '                " cast( 0 as decimal(18,4) ) as d_lot_buy_new, " & _
    '                " cast( 0 as decimal(18,4) ) as d_lot_buy_liq, " & _
    '               " cast( 0 as decimal(18,4) ) as d_lot_sell_new, " & _
    '               " cast( 0 as decimal(18,4) ) as d_lot_sell_liq, " & _
    '               " cast( 0 as decimal(18,4) ) as d_lot_buy_bf, " & _
    '               "cast( 0 as decimal(18,4) ) as d_lot_sell_bf, " & _
    '               " cast( 0 as decimal(18,4) ) as d_lot_buy_net, " & _
    '               "cast( 0 as decimal(18,4) ) as d_lot_sell_net, " & _
    '               " cast( 0 as decimal(18,4) ) as d_avg_buy_price, " & _
    '               " cast( 0 as decimal(18,4) ) as d_avg_sell_price, " & _
    '               " cast( 0 as decimal(18,4) ) as d_floating, " & _
    '               " cast( 0 as decimal(18,4) ) as d_interest, cast(0 as decimal(18,4)) as d_commission " & _
    '                " from terms_config order by opn_pos_order "
    '        ldtsTable = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        lstrSQL = " select a.d_ano, a.d_o_date, cast('' as varchar(6)) as d_order, " & _
    '              " cast('' as varchar(6)) as  d_op, " & _
    '              " cast(a.d_buy_sell as varchar(2)) as d_type, " & _
    '            " a.d_currency, a.d_o_price, a.d_c_price, a.d_lots, a.d_pl, " & _
    '             " cast(0 as decimal(18,4)) as d_interest, " & _
    '             " cast(0 as decimal(18,4)) as d_storage, " & _
    '            " cast(0 as decimal(18,4)) as d_nec_day, " & _
    '            " cast(0 as decimal(18,4)) as d_nec_night, " & _
    '             " c.d_sno, c.d_sgroup, cast(0 as decimal(18,4)) as d_commission " & _
    '            " from [order] a inner join account b on a.d_ano = b.d_ano " & _
    '            " left outer join sales c on c.d_sno = b.d_sno where 1<=0 "
    '        ldtsOrd = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        afill(ag_status, 0, AC_STATUS_SIZE)
    '        ldtsacc.Dispose()
    '        lstrSQL = "Select distinct b.* " & _
    '                    " from [order] a inner join account b on a.d_ano = b.d_ano " & _
    '                     " left outer join sales c on c.d_sno = b.d_sno " & _
    '                    " where a.d_state = '" & O_New & _
    '                    "' and a.d_new_liq = 'L' " & _
    '                    " order by b.d_ano "
    '        ldtsacc = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        If ldtsacc.Tables(0).Rows.Count <= 0 Then
    '            Return Nothing
    '        End If
    '        ldtcacc = ldtsacc.Tables(0).Rows

    '        For Each ldtwacc In ldtcacc
    '            lstrAno = ldtwacc("d_ano")
    '            define_trading_terms(lstrAno, , ldtsacc, ldtsTerms)
    '            modcal.GET_AC_STATUS(lstrAno, "Y", "N", Nothing, , , ldtsacc, ldtsCurr, ldtsOrder, ldtsOp, ldtsDate)

    '            ldtaOrder = ldtsOrder.Tables(0).Select(" d_ano = '" & lstrAno & "' and d_state = '" & O_New & _
    '                                                 "' and d_new_liq = 'L' ")
    '            For Each ldtwOrder In ldtaOrder
    '                Application.DoEvents()
    '                Dim lstrOpNo As String = ldtwOrder("d_ord_no")
    '                Dim lstrOpType As String = ldtwOrder("d_ord_type")
    '                afill(ag_order, 0, O_ORDER_SIZE)
    '                modcal.GATHER_ORD(ldtwOrder, ldtwacc, "L", , ldtsCurr)

    '                Dim ldtwop As DataRow
    '                Dim ldtaop() As DataRow

    '                ldtaop = ldtsOp.Tables(0).Select(" d_ano = '" & lstrAno & "' and d_op_no = '" & lstrOpNo & _
    '                                    "' and d_op_type = '" & lstrOpType & "' and d_state = '" & O_Liq & "' ")
    '                For Each ldtwop In ldtaop

    '                    modcal.GATHER_ORD(ldtwop, ldtwacc, "O", , ldtsCurr)

    '                    modcal.CAL_ORDER_PROFIT("L", Nothing, , ldtsDate, ldtsCurr)

    '                    Dim ldtwOrd As DataRow = ldtsOrd.Tables(0).NewRow
    '                    ldtwOrd("d_ano") = ldtwacc("d_ano")
    '                    ldtwOrd("d_sno") = ldtwacc("d_sno")
    '                    ldtwOrd("d_sgroup") = Me.lFunGetSalesGroup(ldtsSales, ldtwacc("d_sno"))
    '                    ldtwOrd("d_o_date") = ag_order(O_DATE)
    '                    ldtwOrd("d_op") = Trim(Str(ag_order(O_NO))) & Trim(ag_order(O_ORD_TYPE))
    '                    ldtwOrd("d_order") = Trim(lstrOpNo) & Trim(lstrOpType)
    '                    ldtwOrd("d_type") = IIf(ag_order(O_BUY_SELL) = "S", "SB", "BS")
    '                    ldtwOrd("d_currency") = ag_order(O_CUR)
    '                    ldtwOrd("d_o_price") = ag_order(O_O_PRICE)
    '                    ldtwOrd("d_c_price") = ag_order(O_C_PRICE)
    '                    ldtwOrd("d_lots") = ag_order(O_LOTS)
    '                    ldtwOrd("d_pl") = ag_order(O_FLOATING)
    '                    ldtwOrd("d_interest") = ag_order(O_INTEREST)
    '                    ldtwOrd("d_storage") = ag_order(O_STORAGE)
    '                    ldtwOrd("d_commission") = ag_order(O_COMM)
    '                    ldtsOrd.Tables(0).Rows.Add(ldtwOrd)

    '                    ldtatable = ldtsTable.Tables(0).Select("d_currency = '" & ag_order(O_CUR) & "' ")
    '                    If ldtatable.Length > 0 Then
    '                        If ag_order(O_BUY_SELL) = "S" Then
    '                            ldtatable(0).Item("d_lot_buy_net") += ag_order(O_LOTS)
    '                        Else
    '                            ldtatable(0).Item("d_lot_sell_net") += ag_order(O_LOTS)
    '                        End If

    '                        ldtatable(0).Item("d_interest") += ag_order(O_INTEREST)
    '                        ldtatable(0).Item("d_commission") += ag_order(O_COMM)
    '                        ldtatable(0).Item("d_floating") += ag_order(O_FLOATING)
    '                    End If
    '                Next
    '            Next
    '        Next

    '        rptOP.Subreports("RptLiqOpTable").SetDataSource(ldtsTable.Tables(0))
    '        rptOP.SetDataSource(ldtsOrd.Tables(0))
    '        lsubSetCurrConfig(rptOP)
    '        AddParam(rptOP, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '        AddParam(rptOP, "paraTdate", g_tdate)
    '        AddParam(rptOP, "paraDayNight", g_day_night)
    '        Return rptOP

    '    End Function

    '    Public Function Executed_PLWeekly_rpt(ByVal lstrFAno As String, ByVal lstrTAno As String, ByVal ldteFrom As Date, ByVal ldteTo As Date) As ReportClass
    '        Dim rptPL As New RptPLWeekly
    '        Dim ldtsPL As DataSet
    '        Dim ldtcPL As DataRowCollection
    '        Dim ldtwPL As DataRow
    '        Dim lstrSQL As String
    '        Dim lintCnt As Integer

    '        Application.DoEvents()
    '        lstrSQL = "select d_ano, d_sno, " & _
    '                    " cast(0 as decimal(18, 4)) as d_pl_1,  " & _
    '                    " cast(0 as decimal(18, 4)) as d_pl_2, " & _
    '                    " cast(0 as decimal(18, 4)) as d_pl_3, " & _
    '                    " cast(0 as decimal(18, 4)) as d_pl_4, " & _
    '                    " cast(0 as decimal(18, 4)) as d_pl_5, " & _
    '                    " cast(0 as decimal(18, 4)) as d_pl_6, " & _
    '                    " cast(0 as decimal(18, 4)) as d_dpl_1,  " & _
    '                    " cast(0 as decimal(18, 4)) as d_dpl_2, " & _
    '                    " cast(0 as decimal(18, 4)) as d_dpl_3, " & _
    '                    " cast(0 as decimal(18, 4)) as d_dpl_4, " & _
    '                    " cast(0 as decimal(18, 4)) as d_dpl_5, " & _
    '                    " cast(0 as decimal(18, 4)) as d_dpl_6, " & _
    '                    " cast(0 as decimal(18, 4)) as d_mar_in, cast(0 as decimal(18, 4)) as d_mar_out, " & _
    '                    " cast(0 as decimal(18, 4)) as d_equity  into #PL_Temp from account " & _
    '                    " where d_ano in (select d_ano from profit where d_tdate between '" & Format(ldteFrom, "yyyy/MM/dd") & _
    '                    "' and '" & Format(ldteTo, "yyyy/MM/dd") & "') "
    '        If Trim(lstrFAno) <> "" Then
    '            lstrSQL &= " and d_ano >= '" & lstrFAno & "' "
    '        Else
    '            lstrFAno = "BEGIN"
    '        End If
    '        If Trim(lstrTAno) <> "" Then
    '            lstrSQL &= " and d_ano <= '" & lstrTAno & "' "
    '        Else
    '            lstrTAno = "END"
    '        End If
    '        lstrSQL &= " order by d_ano "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)


    '        For lintCnt = 1 To 6
    '            lstrSQL = "update #pl_temp set d_pl_" & lintCnt & " = d_pl_" & lintCnt & " + d_act_pl " & _
    '                    ", d_dpl_" & lintCnt & " = d_dpl_" & lintCnt & " + d_daily_pl " & _
    '                    " from profit where #pl_temp.d_ano = profit.d_ano and " & _
    '                    " profit.d_tdate = '" & Format(DateAdd(DateInterval.Day, lintCnt - 1, ldteFrom), "yyyy/MM/dd") & "' "
    '            GFncRunSQL(GSCnSqlConn, lstrSQL)
    '            Application.DoEvents()
    '        Next

    '        lstrSQL = "update #pl_temp set d_mar_in = d_mar_in + a.d_sum_margin " & _
    '                    " from ( select d_ano, sum(d_margin) as d_sum_margin from margin " & _
    '                    " where d_in_out = 'I' " & _
    '                    " and margin.d_tdate between '" & Format(ldteFrom, "yyyy/MM/dd") & _
    '                    "' and '" & Format(ldteTo, "yyyy/MM/dd") & "' group by d_ano ) a " & _
    '                    " where #pl_temp.d_ano = a.d_ano "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)
    '        Application.DoEvents()

    '        lstrSQL = "update #pl_temp set d_mar_out = d_mar_out - a.d_sum_margin " & _
    '                    " from ( select d_ano, sum(d_margin) as d_sum_margin from margin " & _
    '                    " where d_in_out <> 'I' " & _
    '                    " and margin.d_tdate between '" & Format(ldteFrom, "yyyy/MM/dd") & _
    '                    "' and '" & Format(ldteTo, "yyyy/MM/dd") & "' group by d_ano ) a " & _
    '                    " where #pl_temp.d_ano = a.d_ano "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)
    '        Application.DoEvents()

    '        lstrSQL = "select * from #PL_Temp order by d_ano "
    '        ldtsPL = GFncRtnDS(GSCnSqlConn, lstrSQL)
    '        ldtcPL = ldtsPL.Tables(0).Rows
    '        For Each ldtwPL In ldtcPL
    '            Dim lstrAno As String = ldtwPL("d_ano")
    '            define_trading_terms(lstrAno)
    '            modcal.GET_AC_STATUS(lstrAno, "N", "N", Nothing)
    '            lstrSQL = "update #pl_temp set d_equity = " & ag_status(AC_EQUITY) & _
    '                        " where d_ano = '" & lstrAno & "' "
    '            GFncRunSQL(GSCnSqlConn, lstrSQL)
    '            Application.DoEvents()
    '        Next

    '        ldtsPL = Nothing
    '        lstrSQL = "select * from #PL_Temp order by d_ano "
    '        ldtsPL = GFncRtnDS(GSCnSqlConn, lstrSQL)

    '        lstrSQL = "drop table #PL_Temp "
    '        GFncRunSQL(GSCnSqlConn, lstrSQL)

    '        rptPL.SetDataSource(ldtsPL.Tables(0))
    '        AddParam(rptPL, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
    '        AddParam(rptPL, "paraFromAno", lstrFAno)
    '        AddParam(rptPL, "paraToAno", lstrTAno)
    '        AddParam(rptPL, "paraFromDate", ldteFrom)
    '        AddParam(rptPL, "paraToDate", ldteTo)

    '        Return rptPL

    '    End Function

    Public Function lfncRtnEmptyRpt(ByVal strRptTitle As String) As ReportClass
        Dim rpt As New RptEmpty

        AddParam(rpt, "paraPrintUser", Trim(GStrloginID) & "     (" & Trim(g_branch_name) & ")")
        AddParam(rpt, "paraRptTitle", strRptTitle)
        AddParam(rpt, "paraTDate", Now)

        Return rpt
    End Function

    '    Public Function GFncGetOrderLog(ByVal dteTDate As Date) As ReportClass
    '        Dim strSQL As String = ""
    '        Dim ds As DataSet
    '        Dim dsTerms As DataSet
    '        Dim rpt As New RptLogOrder

    '        strSQL = "Select * from L_ORDER Where d_tdate = '" & Format(dteTDate, "yyyy/MM/dd") & "' Order by d_act_date"

    '        ds = GFncRtnDS(GSCnSqlConn, strSQL)

    '        strSQL = "Select * from Terms_Config"
    '        dsTerms = GFncRtnDS(GSCnSqlConn, strSQL)

    '        If ds.Tables(0).Rows.Count > 0 Then
    '            rpt.Database.Tables("L_ORDER").SetDataSource(ds.Tables(0))
    '            rpt.Database.Tables("TERMS_CONFIG").SetDataSource(dsTerms.Tables(0))
    '            AddParam(rpt, "paraPrintUser", GStrloginID & "     (" & Trim(g_branch_name) & ")")
    '            AddParam(rpt, "paraADate", Format(dteTDate, "dd MMM yyyy"))
    '            Return rpt
    '        Else
    '            Return Nothing
    '        End If

    '    End Function

    'Please add all report ID and functions in this block
    Public Function GFncGetReport(ByVal strReportID As String, Optional ByVal dtwRepBatch As DataRow = Nothing) As ReportClass
        Dim rpt As New ReportClass

        Select Case UCase(strReportID)

            Case Else
                rpt = Nothing
        End Select

        Return rpt

    End Function

End Class
