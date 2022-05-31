Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class clsNewedgeOpenPosition

    Public Function FncGenReport(ByVal tdate As Date, ByVal pCounterParty As String) As ReportClass
        Dim lcCls As New clsRptFuturesStatementAdj

        Dim rpt As New rptNewedgeOpenPos
        rpt.ReportClientDocument.LocaleID = CrystalDecisions.ReportAppServer.DataDefModel.CeLocale.ceLocaleEnglishUK
        Dim dt As DataTable = New dtsNewedge.OpenPosDataTable
        Dim str As String = ""
        str = "select a.code, a.tdate, a.sysdate, case when a.type = 1 then a.qty else 0 end as buy, " & _
            "case when a.type = 2 then a.qty else 0 end as sell, a.contract_size as contract_size, " & _
            "a.accno, b.product_name, a.monthcode, a.price, day(a.settle_Date) as sDay, '' as MDFlag, 0 as usedRec, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
            "from FuturesOP a left join futures_product_master b on b.product_code = a.code " & _
            "where a.counterparty = '" & pCounterParty & "' and a.sysdate = '" & Format(tdate, "yyyy-MM-dd") & "' order by a.code, a.monthcode,sDay, a.strike, a.callput "
        Dim eDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        'str = "select a.buy, a.sell, a.price, b.d_code, c.product_name, a.monthcode, a.product, a.contract_size, " & _
        '    "day(a.settle_date) as sDay, a.monthly_daily as MDFlag, 0 as usedRec " & _
        '    "from newedge_cap_op a left join product_mapping b on b.d_newedge_code = a.product and a.counterparty = b.d_counterparty " & _
        '    "left join futures_product_master c on c.product_code = b.d_code where a.tdate = '" & tdate & "' and a.counterparty = '" & pCounterParty & "' order by b.d_code, a.monthcode"
        str = "select a.buy, a.sell, a.price, b.d_code, c.product_name, a.monthcode, a.product, a.contract_size, " & _
          "day(a.settle_date) as sDay, a.monthly_daily as MDFlag, 0 as usedRec, a.isadjusted,  a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
          "from vw_cap_op a left join product_mapping b on b.d_newedge_code = a.product and a.counterparty = b.d_counterparty " & _
          "left join futures_product_master c on c.product_code = b.d_code where a.tdate = '" & Format(tdate, "yyyy-MM-dd") & "' and a.counterparty = '" & pCounterParty & "' AND b.d_isoption=1 AND a.callput <>'' " & _
            "UNION ALL " & _
            "select a.buy, a.sell, a.price, b.d_code, c.product_name, a.monthcode, a.product, a.contract_size, " & _
            "day(a.settle_date) as sDay, a.monthly_daily as MDFlag, 0 as usedRec, a.isadjusted,  a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
            "from vw_cap_op a left join product_mapping b on b.d_newedge_code = a.product and a.counterparty = b.d_counterparty " & _
            "left join futures_product_master c on c.product_code = b.d_code where a.tdate = '" & Format(tdate, "yyyy-MM-dd") & "' and a.counterparty = '" & pCounterParty & "' AND b.d_isoption=0 AND a.callput =''  order by d_code, monthcode, strike, callput "
        Dim nDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)

        Dim grossDiffSQL As String = ""
        grossDiffSQL = "SELECT " & _
                       "  COALESCE(G2.code, Ma.code) as productCode, " & _
                       "  COALESCE(G2.monthcode, Ma.monthcode) as monthCode, " & _
                       "  COALESCE(G2.strike, Ma.strike) as strike, " & _
                       "  COALESCE(G2.callput, Ma.callput) as callput, " & _
                       "  CASE " & _
                       "    WHEN (ISNULL(G2.GgrossBuy,0) - ISNULL(Ma.MgrossBuy,0)) >= (ISNULL(G2.GgrossSell,0) - ISNULL(Ma.MgrossSell,0)) THEN ABS(ISNULL(G2.GgrossBuy,0) - ISNULL(Ma.MgrossBuy,0)) " & _
                       "    WHEN (ISNULL(G2.GgrossSell,0) - ISNULL(Ma.MgrossSell,0)) > (ISNULL(G2.GgrossBuy,0) - ISNULL(Ma.MgrossBuy,0)) THEN ABS(ISNULL(G2.GgrossSell,0) - ISNULL(Ma.MgrossSell,0)) " & _
                       "  ELSE " & _
                       "    0 " & _
                       "  END as diff " & _
                       "  FROM ( " & _
                       "    SELECT " & _
                       "      OP.code, " & _
                       "      OP.monthcode, " & _
                       "      OP.strike, " & _
                       "      CASE WHEN OP.callput ='C' THEN 'Call' WHEN OP.callput='P' THEN 'Put' ELSE '' END as callput, " & _
                       "      OP.contract_size, " & _
                       "      OP.strike * OP.contract_size as unit, " & _
                       "      SUM(case WHEN OP.type = 1 then OP.qty else 0 end) as GgrossBuy, " & _
                       "      SUM(case WHEN OP.type = 2 then OP.qty else 0 end) as GgrossSell " & _
                       "    FROM  FuturesOP OP " & _
                       "    WHERE " & _
                       "      OP.sysdate = '" & Format(tdate, "yyyy-MM-dd") & "' " & _
                       "        AND OP.counterparty = '" & pCounterParty & "' " & _
                       "    Group BY " & _
                       "      OP.code, " & _
                       "      OP.monthcode, " & _
                       "      OP.strike, " & _
                       "      OP.callput, " & _
                       "      OP.contract_size " & _
                       "  ) G2	" & _
                       "FULL JOIN ( " & _
                       "  SELECT " & _
                       "    d_code as code, " & _
                       "     monthcode, " & _
                       "     strike, " & _
                       "     callput, " & _
                       "     contract_size," & _
                       "     unit, " & _
                       "     SUM(buy) as MgrossBuy, " & _
                       "     SUM(sell) as MgrossSell " & _
                       "  FROM ( " & _
                       "    SELECT " & _
                       "      vco.buy, " & _
                       "      vco.sell, " & _
                       "      pm.d_code, " & _
                       "      vco.monthcode, " & _
                       "      vco.strike, " & _
                       "      vco.contract_size, " & _
                       "      vco.strike * vco.contract_size as unit, " & _
                       "      CASE WHEN vco.callput ='C' THEN 'Call' WHEN vco.callput='P' THEN 'Put' ELSE '' END as callput  " & _
                       "    FROM " & _
                       "      vw_cap_op vco" & _
                       "    Left Join " & _
                       "      product_mapping pm " & _
                       "    ON " & _
                       "      pm.d_newedge_code = vco.product " & _
                       "        AND vco.counterparty = pm.d_counterparty " & _
                       "    WHERE " & _
                       "      vco.tdate = '" & Format(tdate, "yyyy-MM-dd") & "' " & _
                       "        AND vco.counterparty = '" & pCounterParty & "'  " & _
                       "        AND pm.d_isoption=1 " & _
                       "        AND vco.callput <>''  " & _
                       "    UNION ALL " & _
                       "    SELECT " & _
                       "      vco.buy, " & _
                       "      vco.sell, " & _
                       "      pm.d_code, " & _
                       "      vco.monthcode, " & _
                       "      vco.strike, " & _
                       "      vco.contract_size, " & _
                       "      vco.strike * vco.contract_size as unit, " & _
                       "      CASE WHEN vco.callput ='C' THEN 'Call' WHEN vco.callput='P' THEN 'Put' ELSE '' END as callput  " & _
                       "    FROM " & _
                       "      vw_cap_op vco " & _
                       "    Left Join " & _
                       "      product_mapping pm " & _
                       "    ON " & _
                       "      pm.d_newedge_code = vco.product " & _
                       "        AND vco.counterparty = pm.d_counterparty " & _
                       "    WHERE " & _
                       "      vco.tdate = '" & Format(tdate, "yyyy-MM-dd") & "' " & _
                       "        AND vco.counterparty = '" & pCounterParty & "' " & _
                       "        AND pm.d_isoption=0 AND vco.callput ='' " & _
                       "  ) OP " & _
                       "  Group BY " & _
                       "    d_code, " & _
                       "    monthcode, " & _
                       "    strike, " & _
                       "    callput, " & _
                       "    contract_size, " & _
                       "    unit " & _
                       ") Ma " & _
                       "ON " & _
                       "  G2.code = Ma.code " & _
                       "    AND G2.monthcode = Ma.monthcode " & _
                       "    AND G2.unit = Ma.unit " & _
                       "    AND G2.callput = Ma.callput "

        Dim grossDiffDataTable As DataTable = GFncRtnDS(GSCnSqlConn, grossDiffSQL).Tables(0)

        Dim pCode As String = ""
        Try
            pCode = GFncNoNullString(eDt.Rows(0).Item("code")).Trim()
        Catch ex As Exception
            pCode = ""
        End Try
        Dim pContractSize As Decimal = "0.000000"
        Try
            pContractSize = GFncNoNullValue(eDt.Rows(0).Item("contract_size"))
        Catch ex As Exception
            pContractSize = "0.000000"
        End Try
        Dim pStrike As Decimal = "0.000000"
        Try
            pStrike = GFncNoNullStrike(eDt.Rows(0).Item("strike"))
        Catch ex As Exception
            pStrike = "0.000000"
        End Try
        Dim pCallPut As String = ""
        Try
            pCallPut = GFncNoNullString(eDt.Rows(0).Item("callput")).Trim()
        Catch ex As Exception
            pCallPut = ""
        End Try
        Dim pCount As Integer = 0
        Dim dr As DataRow = Nothing
        Dim nDr() As DataRow = Nothing
        Dim start As Integer = 0
        Dim fMonth As String = ""
        Try
            fMonth = GFncNoNullString(eDt.Rows(0).Item("monthCode")).Trim()
        Catch ex As Exception
            fMonth = ""
        End Try
        Dim sDay As Integer = 0
        Try
            sDay = GFncNoNullValue(eDt.Rows(0).Item("sDay"))
        Catch ex As Exception
            sDay = 0
        End Try
        dr = eDt.NewRow
        dr("code") = ""
        eDt.Rows.Add(dr)
        dr = Nothing
        str = "select distinct a.code as futuresName, b.d_newedge_code as newedgeName from futuresOP a inner join product_mapping b on a.code=b.d_code  and a.counterparty = b.d_counterparty where a.counterparty = '" & pCounterParty & "'"
        Dim dsTemp As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        For Each eDr As DataRow In eDt.Rows
            'If GFncNoNullString(eDr("code")).Trim = "" Then
            '    Dim a As Integer = 0
            'End If
            If GFncNoNullString(eDr("code")).Trim <> pCode Or GFncNoNullString(eDr("monthCode")) <> fMonth Or GFncNoNullValue(eDr("sDay")) <> sDay Or GFncNoNullStrike(eDr("strike")) <> pStrike Or GFncNoNullString(eDr("callput")).Trim <> pCallPut Then
                nDr = nDt.Select("d_code = '" & pCode & "' and monthcode = '" & fMonth & "' and MDFlag = 'D' and sDay = " & sDay & " and (strike = " & pStrike & " OR strike*contract_size = " & pStrike * pContractSize & " ) and callput = '" & pCallPut & "'", "")
                If nDr.Length <= 0 Then
                    nDr = nDt.Select("d_code = '" & pCode & "' and monthcode = '" & fMonth & "' and MDFlag = 'M'" & " and (strike = " & pStrike & " OR strike*contract_size = " & pStrike * pContractSize & " ) and callput = '" & pCallPut & "'", "")
                End If
                If nDr.Length > 0 Then
                    For i As Integer = start To dt.Rows.Count - 1
                        dt.Rows(i).Item("MDFlag") = GFncNoNullString(nDr(0).Item("MDFlag")).Trim
                        dt.Rows(i).Item("mapped") = "T"
                    Next
                    For i As Integer = 0 To nDr.Length - 1
                        nDr(i).Item("usedRec") = 1
                    Next
                End If
                For i As Integer = 0 To nDr.Length - 1
                    If start < dt.Rows.Count Then
                        ' dt.Rows(start).Item("nClient") = "NEWEDGE"
                        dt.Rows(start).Item("nClient") = pCounterParty
                        dt.Rows(start).Item("nBuy") = GFncNoNullValue(nDr(i).Item("buy"))
                        dt.Rows(start).Item("nSell") = GFncNoNullValue(nDr(i).Item("sell"))
                        'If nDr(i).Item("product").ToString.Trim.Length > 0 Then
                        dt.Rows(start).Item("nPrice") = GFncNoNullValue(nDr(i).Item("price"))
                        'End If
                        dt.Rows(start).Item("nName") = GFncNoNullString(nDr(i).Item("product")).Trim
                        dt.Rows(start).Item("MDFlag") = GFncNoNullString(nDr(i).Item("MDFlag")).Trim
                        dt.Rows(start).Item("sDay") = sDay
                        dt.Rows(start).Item("isadjusted") = IIf(GFncNoNullString(nDr(i).Item("isadjusted")).Trim = "Y", True, False)
                        nDr(i).Item("usedRec") = 1

                    Else
                        dr = dt.NewRow
                        dr("pCode") = pCode
                        dr("pStrike") = pStrike
                        dr("pCallPut") = pCallPut
                        'dr("nClient") = "NEWEDGE"
                        dr("nClient") = pCounterParty
                        dr("eBuy") = 0
                        dr("eSell") = 0
                        dr("nBuy") = GFncNoNullValue(nDr(i).Item("buy"))
                        dr("nSell") = GFncNoNullValue(nDr(i).Item("sell"))
                        'If nDr(i).Item("product").ToString.Trim.Length > 0 Then
                        dr("nPrice") = GFncNoNullValue(nDr(i).Item("price"))
                        'End If
                        dr("tdate") = CDate(tdate)
                        dr("pName") = GFncNoNullString(nDr(i).Item("product_name")).Trim
                        dr("fMonth") = fMonth
                        dr("nName") = GFncNoNullString(nDr(i).Item("product")).Trim
                        dr("sDay") = sDay
                        dr("MDFlag") = GFncNoNullString(nDr(i).Item("MDFlag")).Trim
                        'dr("settleDate") = CDate("20" & fMonth.Substring(0, 2) & "/" & fMonth.Substring(2, 2) & "/" & sDay.ToString.PadLeft(2, "0"))
                        dr("settleDate") = CDate("20" & fMonth.Substring(0, 2) & "/" & fMonth.Substring(2, 2) & "/" & "01")
                        dr("mapped") = "T"
                        dr("isadjusted") = IIf(GFncNoNullString(nDr(i).Item("isadjusted")).Trim = "Y", True, False)
                        dt.Rows.Add(dr)
                        dr = Nothing
                        nDr(i).Item("usedRec") = 1
                    End If
                    start += 1
                Next
                nDr = Nothing
                pCode = GFncNoNullString(eDr("code")).Trim
                pStrike = GFncNoNullStrike(eDr("strike"))
                pContractSize = GFncNoNullValue(eDr("Contract_Size"))
                pCallPut = GFncNoNullString(eDr("callput")).Trim
                fMonth = GFncNoNullString(eDr("monthcode")).Trim
                sDay = GFncNoNullValue(eDr("sday"))
                pCount = 0
                start = dt.Rows.Count
            End If
            If GFncNoNullString(eDr("code")).Trim = "" Then
                Exit For
            End If
            pCount += 1
            dr = dt.NewRow
            dr("pCode") = pCode
            dr("pStrike") = pStrike
            dr("pCallPut") = pCallPut
            dr("pName") = GFncNoNullString(eDr("product_name")).Trim
            dr("eClient") = GFncNoNullString(eDr("accno")).Trim
            dr("eBuy") = GFncNoNullValue(eDr("buy"))
            dr("eSell") = GFncNoNullValue(eDr("sell"))
            dr("ePrice") = GFncNoNullValue(eDr("price"))
            dr("fMonth") = GFncNoNullString(eDr("monthcode")).Trim
            dr("nSell") = 0
            dr("nBuy") = 0
            dr("tdate") = CDate(tdate)
            dr("fMonth") = fMonth
            If dsTemp.Select("futuresName='" + pCode + "'").Length > 0 Then
                dr("nName") = dsTemp.Select("futuresName='" + pCode + "'")(0)("newedgeName")
            Else
                dr("nName") = "<Not Mapped>"
            End If
            dr("sDay") = sDay
            dr("MDFlag") = ""  'Default
            dr("mapped") = "F"
            'dr("settleDate") = CDate("20" & fMonth.Substring(0, 2) & "/" & fMonth.Substring(2, 2) & "/" & sDay.ToString.PadLeft(2, "0"))
            dr("settleDate") = CDate("20" & fMonth.Substring(0, 2) & "/" & fMonth.Substring(2, 2) & "/" & "01")
            dr("isadjusted") = False
            dt.Rows.Add(dr)
            dr = Nothing
            eDr("usedRec") = 1
        Next
        For Each ndDr As DataRow In nDt.Rows
            If GFncNoNullValue(ndDr("usedRec")) <> 1 Then
                pCode = GFncNoNullString(ndDr("d_code")).Trim
                pStrike = GFncNoNullValue(ndDr("strike"))
                pCallPut = GFncNoNullString(ndDr("callput")).Trim
                fMonth = GFncNoNullString(ndDr("monthcode")).Trim
                sDay = GFncNoNullString(ndDr("sDay")).Trim
                'nDr = dt.Select("pcode = '" & pCode & "' and fmonth = '" & fMonth & "' and MDFlag = 'D' and sDay = " & sDay, "")
                'If nDr.Length <= 0 Then
                '    nDr = dt.Select("pcode = '" & pCode & "' and fmonth = '" & fMonth & "' and MDFlag = 'M'", "")
                'End If
                'If nDr.Length = 0 Then
                dr = dt.NewRow
                dr("pCode") = IIf(pCode = "", "<Not Mapped>", pCode)
                dr("pStrike") = pStrike
                dr("pCallPut") = pCallPut
                'dr("nClient") = "NEWEDGE"
                dr("nClient") = pCounterParty
                dr("eBuy") = 0
                dr("eSell") = 0
                dr("nBuy") = GFncNoNullValue(ndDr("buy"))
                dr("nSell") = GFncNoNullValue(ndDr("sell"))
                dr("nPrice") = GFncNoNullValue(ndDr("price"))
                dr("fMonth") = fMonth
                dr("pName") = IIf(GFncNoNullString(ndDr("product_name")).Trim = "", "<Not Mapped>", GFncNoNullString(ndDr("product_name")).Trim)
                dr("nName") = GFncNoNullString(ndDr("product")).Trim
                dr("tdate") = CDate(tdate)
                dr("sDay") = sDay
                dr("MDFlag") = GFncNoNullString(ndDr("MDFlag")).Trim
                'dr("settleDate") = CDate("20" & fMonth.Substring(0, 2) & "/" & fMonth.Substring(2, 2) & "/" & sDay.ToString.PadLeft(2, "0"))
                dr("settleDate") = CDate("20" & fMonth.Substring(0, 2) & "/" & fMonth.Substring(2, 2) & "/" & "01")
                dr("mapped") = IIf(pCode = "", "F", "T")
                dr("isadjusted") = IIf(GFncNoNullString(ndDr("isadjusted")).Trim = "Y", True, False)
                dt.Rows.Add(dr)
                dr = Nothing
                'End If
            End If
        Next

        'Calculate gross difference
        Dim grossLotDiff As Double

        For Each grossDiffRow As DataRow In grossDiffDataTable.Rows
            grossLotDiff = grossDiffRow("diff")

            Dim dataRow As DataRow() = dt.Select("pCode='" & grossDiffRow("productCode") & "' AND fMonth='" & grossDiffRow("monthCode") & "' AND pStrike='" & grossDiffRow("strike") & "' AND pCallPut='" & grossDiffRow("callput") & "'")

            If dataRow.Count > 0 Then
                For i As Integer = 0 To dataRow.Count - 1
                    dataRow(i)("grossDiff") = grossLotDiff
                Next
            End If
        Next

        rpt.SetDataSource(dt)

        Dim ldtOPadj As DataTable = lcCls.GenOPAdjReport(tdate, pCounterParty)
        rpt.Subreports(0).SetDataSource(ldtOPadj)

        rpt.SetParameterValue("user", GStrloginID)
        rpt.SetParameterValue("CounterParty", pCounterParty)
        rpt.SetParameterValue("NoofOPAdj", ldtOPadj.Rows.Count)
        Return rpt
    End Function

End Class
