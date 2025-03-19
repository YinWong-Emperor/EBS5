Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class clsNewedgeReport

    Public Function FncGenReport(ByVal tdate As String) As ReportClass
        Dim rpt As New rptNewedgeOpenPos
        Dim dt As DataTable = New dtsNewedge.OpenPosDataTable
        Dim str As String = ""
        str = "select a.code, a.tdate, a.sysdate, case when a.type = 1 then a.qty else 0 end as buy, case when a.type = 2 then a.qty else 0 end as sell, a.contract_size as contract_size, " & _
            "a.accno, b.product_name, a.monthcode, a.price from FuturesOP a left join futures_product_master b on b.product_code = a.code where " & _
            "a.counterparty = 'NEWEDGE' and a.sysdate = '" & tdate & "' order by a.code"
        Dim eDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        'str = "select a.buy, a.sell, a.price, b.d_code, c.product_name, a.monthcode, a.product, a.contract_size from newedge_cap_op a inner join product_mapping b on " & _
        '    "b.d_newedge_code = a.product left join futures_product_master c on c.product_code = b.d_code where a.tdate = '" & tdate & "' order by b.d_code"
        str = "select a.buy, a.sell, a.price, b.d_code, c.product_name, a.monthcode, a.product, a.contract_size from vw_cap_op a inner join product_mapping b on " & _
           "b.d_newedge_code = a.product and a.counterparty = b.d_counterparty left join futures_product_master c on c.product_code = b.d_code where a.tdate = '" & tdate & "' order by b.d_code"
        Dim nDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        Dim pCode As String = ""
        Dim pCount As Integer = 0
        Dim dr As DataRow = Nothing
        Dim nDr() As DataRow = Nothing
        Dim start As Integer = 0
        Dim fMonth As String = ""
        dr = eDt.NewRow
        dr("code") = ""
        eDt.Rows.Add(dr)
        dr = Nothing

        str = "select distinct a.code as futuresName, b.d_newedge_code as newedgeName from futuresOP a inner join product_mapping b on a.code=b.d_code"
        Dim dsTemp As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)

        For Each eDr As DataRow In eDt.Rows

            If GFncNoNullString(eDr("code")).Trim <> pCode Or GFncNoNullString(eDr("monthCode")) <> fMonth Then
                nDr = nDt.Select("d_code = '" & pCode & "' and monthcode = '" & fMonth & "'", "")
                For i As Integer = 0 To nDr.Length - 1
                    If start < dt.Rows.Count Then
                        dt.Rows(start).Item("nClient") = "NEWEDGE"
                        dt.Rows(start).Item("nBuy") = GFncNoNullValue(nDr(i).Item("buy"))
                        dt.Rows(start).Item("nSell") = GFncNoNullValue(nDr(i).Item("sell"))

                        If eDr.Item("code").ToString.Trim.Length > 0 Then
                            If eDr.Item("contract_size") > 0 Then
                                dt.Rows(start).Item("nPrice") = GFncNoNullValue(nDr(i).Item("price") / (nDr(i).Item("contract_size") / eDr.Item("contract_size")))
                            Else
                                dt.Rows(start).Item("nPrice") = GFncNoNullValue(nDr(i).Item("price"))
                            End If
                        End If

                        dt.Rows(start).Item("nName") = GFncNoNullString(nDr(i).Item("product")).Trim
                    Else
                        dr = dt.NewRow
                        dr("pCode") = pCode
                        dr("nClient") = "NEWEDGE"
                        dr("eBuy") = 0
                        dr("eSell") = 0
                        dr("nBuy") = GFncNoNullValue(nDr(i).Item("buy"))
                        dr("nSell") = GFncNoNullValue(nDr(i).Item("sell"))

                        If eDr.Item("code").ToString.Trim.Length > 0 Then
                            If eDr.Item("contract_size") > 0 Then
                                dr("nPrice") = GFncNoNullValue(nDr(i).Item("price") / (nDr(i).Item("contract_size") / eDr.Item("contract_size")))
                            Else
                                dr("nPrice") = GFncNoNullValue(nDr(i).Item("price"))
                            End If
                        End If

                        dr("tdate") = CDate(tdate)
                        dr("pName") = GFncNoNullString(nDr(i).Item("product_name")).Trim
                        dr("fMonth") = fMonth
                        dr("nName") = GFncNoNullString(nDr(i).Item("product")).Trim

                        dt.Rows.Add(dr)
                        dr = Nothing
                    End If
                    start += 1
                Next
                nDr = Nothing
                pCode = GFncNoNullString(eDr("code")).Trim
                fMonth = GFncNoNullString(eDr("monthcode")).Trim
                pCount = 0
                start = dt.Rows.Count
            End If
            If GFncNoNullString(eDr("code")).Trim = "" Then
                Exit For
            End If
            pCount += 1
            dr = dt.NewRow
            dr("pCode") = pCode
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

            dt.Rows.Add(dr)
            dr = Nothing
        Next
        For Each ndDr As DataRow In nDt.Rows
            pCode = GFncNoNullString(ndDr("d_code")).Trim
            fMonth = GFncNoNullString(ndDr("monthcode")).Trim
            nDr = dt.Select("pCode = '" & pCode & "' and fMonth = '" & fMonth & "'", "")
            If nDr.Length = 0 Then
                dr = dt.NewRow
                dr("pCode") = pCode
                dr("nClient") = "NEWEDGE"
                dr("eBuy") = 0
                dr("eSell") = 0
                dr("nBuy") = GFncNoNullValue(ndDr("buy"))
                dr("nSell") = GFncNoNullValue(ndDr("sell"))
                dr("nPrice") = GFncNoNullValue(ndDr("price"))
                dr("fMonth") = fMonth
                dr("pName") = GFncNoNullString(ndDr("product_name")).Trim
                dr("nName") = GFncNoNullString(ndDr("product")).Trim

                dt.Rows.Add(dr)
                dr = Nothing
            End If
        Next
        rpt.SetDataSource(dt)
        rpt.SetParameterValue("user", GStrloginID)
        Return rpt
    End Function

    Public Function FncGenTransactionReport(ByVal tdate As DateTime, ByVal pCounterParty As String) As ReportClass
        Dim lcCls As New clsRptFuturesStatementAdj

        Dim rpt As New rptNewedgeTrans
        rpt.ReportClientDocument.LocaleID = CrystalDecisions.ReportAppServer.DataDefModel.CeLocale.ceLocaleEnglishUK
        rpt.SetDataSource(getDtNewedgeTransaction(tdate, pCounterParty))

        Dim ldtTranAdj As DataTable = lcCls.GenTHAdjReport(tdate, pCounterParty)
        rpt.Subreports(0).SetDataSource(ldtTranAdj)

        rpt.SetParameterValue("user", GStrloginID)
        rpt.SetParameterValue("tdate", tdate)
        rpt.SetParameterValue("CounterParty", pCounterParty)
        rpt.SetParameterValue("NoofTranAdj", ldtTranAdj.Rows.Count)

        Return rpt
    End Function

    Private Function getDtNewedgeTransaction(ByVal tdate As DateTime, ByVal pCounterParty As String) As DataTable

        Dim dtFuturesTrans As DataTable = New DataTable
        Dim dtNewedgeTrans As DataTable = New DataTable
        Dim dtReturn As DataTable = New DtsNewedgeTrans.DataTable1DataTable
        Dim strSQL As String = Nothing
        Dim tempRowArray() As DataRow = Nothing
        Dim strTemp As String

        strSQL = "select a.tdate as tdate, a.code as code, b.product_name as prod_name, a.monthcode as month, " & _
           " a.settle_date as settle_date, sum(a.buy) as buy, 0 as sell, a.price as price, a.contract_size as contract_size, 'N' as checked, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
           " from futurestransaction a left outer join futures_product_master b " & _
           " on a.code=b.product_code where upper(counterparty)='" & pCounterParty & "' and sysdate='" & Format(tdate, "yyyy/MM/dd") & "' and a.buy > 0 " & _
           "group by a.tdate, a.code, b.product_name, a.monthcode, a.settle_date, a.price, a.contract_size, a.strike, a.callput " & _
           " Union all " & _
         " select a.tdate as tdate, a.code as code, b.product_name as prod_name, a.monthcode as month, " & _
                 " a.settle_date as settle_date, 0 as buy,sum(a.sell) as sell, a.price as price, a.contract_size as contract_size, 'N' as checked, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
                 " from futurestransaction a left outer join futures_product_master b " & _
                 " on a.code=b.product_code where upper(counterparty)='" & pCounterParty & "' and sysdate='" & Format(tdate, "yyyy/MM/dd") & "' and a.sell > 0 " & _
                 "group by a.tdate, a.code, b.product_name, a.monthcode, a.settle_date, a.price, a.contract_size,a.strike, a.callput "

        dtFuturesTrans = GFncRtnDS(GSCnSqlConn, strSQL).Tables(0)

        strSQL = "SELECT tdate, code, contract_size, nCode, prod_name, [month], " & _
                " settle_date, SUM(buy) AS buy, SUM(sell) AS sell, price, monthly_daily, checked, " & _
                " isadjusted, strike, callput FROM ( " & _
                " SELECT a.tdate as tdate, a.product as code, a.contract_size as contract_size, " & _
                " b.d_code as nCode, c.product_name as prod_name, a.monthcode as [month], " & _
                " a.settle_date as settle_date, " & _
                " a.buy AS buy, a.sell AS sell, " & _
                " CASE WHEN a.buy>0 THEN 1 WHEN a.sell>0 THEN 0 ELSE -1 END AS buysell, " & _
                " a.price as price, a.monthly_daily as monthly_daily, 'N' as checked, a.isadjusted, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
                " FROM vw_cap_trade_hist a LEFT OUTER JOIN product_mapping b ON a.product=b.d_newedge_code AND a.counterparty = b.d_counterparty AND b.d_isoption=1 " & _
                " LEFT OUTER JOIN futures_product_master c ON b.d_code=c.product_code " & _
                " WHERE tdate='" & Format(tdate, "yyyy/MM/dd") & "' AND a.counterparty = '" & pCounterParty & "' AND a.callput<>'' " & _
                " UNION ALL " & _
                " SELECT a.tdate as tdate, a.product as code, a.contract_size as contract_size, " & _
                " b.d_code as nCode, c.product_name as prod_name, a.monthcode as [month], " & _
                " a.settle_date as settle_date, " & _
                " a.buy AS buy, a.sell AS sell, " & _
                " CASE WHEN a.buy>0 THEN 1 WHEN a.sell>0 THEN 0 ELSE -1 END AS buysell, " & _
                " a.price as price, a.monthly_daily as monthly_daily, 'N' as checked, a.isadjusted, a.strike, CASE WHEN a.callput ='C' THEN 'Call' WHEN a.callput='P' THEN 'Put' ELSE '' END as callput " & _
                " FROM vw_cap_trade_hist a LEFT OUTER JOIN product_mapping b ON a.product=b.d_newedge_code AND a.counterparty = b.d_counterparty AND b.d_isoption=0 " & _
                " LEFT OUTER JOIN futures_product_master c ON b.d_code=c.product_code " & _
                " WHERE tdate='" & Format(tdate, "yyyy/MM/dd") & "' AND a.counterparty = '" & pCounterParty & "'  AND a.callput='' " & _
                " ) trade_hist " & _
                " GROUP BY tdate, code, contract_size, nCode, prod_name, [month]," & _
                " settle_date, price, monthly_daily, checked, isadjusted," & _
                " strike, callput, buysell"

        dtNewedgeTrans = GFncRtnDS(GSCnSqlConn, strSQL).Tables(0)

        For Each row As DataRow In dtNewedgeTrans.Rows
            Dim tempNewRow As DataRow = Nothing
            Dim tempRow As DataRow = Nothing
            strTemp = "code='" & row.Item("ncode").ToString.Trim _
                        & "' and buy=" & row.Item("buy").ToString.Trim _
                        & " and sell=" & row.Item("sell").ToString.Trim _
                        & " and (price = " & Format(row.Item("price"), "0.000000000000000") _
                        & " or price*contract_size=" & Format(row.Item("price") * row.Item("contract_size"), "0.000000000000000") _
                        & " ) and checked='N' and (strike = " & row.Item("strike") & " OR strike*contract_size  = " & row.Item("strike") * row.Item("contract_size") & ") and callput = '" & row.Item("callput").ToString.Trim & "'"
            If row.Item("monthly_daily").ToString.ToUpper = "M" Then
                strTemp += " and month='" & row.Item("month").ToString.Trim & "' "

            ElseIf row.Item("monthly_daily").ToString.ToUpper = "D" Then
                strTemp += " and settle_date='" & Format(row.Item("settle_date"), "yyyy/MM/dd") & "' "
            End If
            tempRowArray = dtFuturesTrans.Select(strTemp)

            If tempRowArray.Length > 0 Then
                tempRow = tempRowArray(0)
                tempNewRow = dtReturn.NewRow()
                tempNewRow.Item("tdate") = tempRow.Item("tdate")
                'tempNewRow.Item("accno") = tempRow.Item("accno")
                tempNewRow.Item("fprod_code") = tempRow.Item("code")
                tempNewRow.Item("fprod_name") = tempRow.Item("prod_name")
                tempNewRow.Item("fstrike") = GFncNoNullStrike(tempRow.Item("strike"))
                tempNewRow.Item("fcallput") = tempRow.Item("callput")
                If Val(tempRow.Item("month")) <> 0 Then
                    tempNewRow.Item("fmonth") = New DateTime( _
                                                                IIf( _
                                                                    Val(tempRow.Item("month").ToString.Substring(0, 2)) <= 50, _
                                                                    2000 + Val(tempRow.Item("month").ToString.Substring(0, 2)), _
                                                                    1900 + Val(tempRow.Item("month").ToString.Substring(0, 2)) _
                                                                ), _
                                                                tempRow.Item("month").ToString.Substring(2, 2), _
                                                                1 _
                                                            )
                End If

                tempNewRow.Item("fsettle_date") = tempRow.Item("settle_date")

                If Not IsDBNull(tempRow.Item("settle_date")) Then
                    tempNewRow.Item("fday") = Format(tempRow.Item("settle_date"), "dd")
                End If

                tempNewRow.Item("fbuy") = tempRow.Item("buy")
                tempNewRow.Item("fsell") = tempRow.Item("sell")
                tempNewRow.Item("fprice") = tempRow.Item("price")
                'tempNewRow.Item("tid") = row.Item("tid")
                tempNewRow.Item("nprod_name") = row.Item("code")
                tempNewRow.Item("nsettle_date") = row.Item("settle_date")
                tempNewRow.Item("monthly_daily") = row.Item("monthly_daily")
                tempNewRow.Item("isadjusted") = IIf(row.Item("isadjusted") = "Y", True, False)

                If row.Item("monthly_daily").ToString.Trim.ToUpper = "D" Then
                    If Val(row.Item("month")) <> 0 Then
                        tempNewRow.Item("nmonth") = New DateTime( _
                                                                     CDate(row.Item("settle_date")).Year, _
                                                                     CDate(row.Item("settle_date")).Month, _
                                                                     1 _
                                                                )
                    End If
                    tempNewRow.Item("nday") = Format(row.Item("settle_date"), "dd")

                ElseIf row.Item("monthly_daily").ToString.Trim.ToUpper = "M" Then
                    If Val(row.Item("month")) <> 0 Then
                        tempNewRow.Item("nmonth") = New DateTime( _
                                                                    IIf( _
                                                                        Val(row.Item("month").ToString.Substring(0, 2)) <= 50, _
                                                                        2000 + Val(row.Item("month").ToString.Substring(0, 2)), _
                                                                        1900 + Val(row.Item("month").ToString.Substring(0, 2)) _
                                                                    ), _
                                                                    row.Item("month").ToString.Substring(2, 2), _
                                                                    1 _
                                                                )
                    End If
                    tempNewRow.Item("nday") = ""
                End If

                tempNewRow.Item("nbuy") = row.Item("buy")
                tempNewRow.Item("nsell") = row.Item("sell")
                tempNewRow.Item("nprice") = row.Item("price")
                tempNewRow.Item("nstrike") = GFncNoNullStrike(row.Item("strike"))
                tempNewRow.Item("ncallput") = row.Item("callput")
                tempNewRow.Item("status") = "MATCH"
                dtReturn.Rows.Add(tempNewRow)

                row.Item("checked") = "Y"
                tempRow.Item("checked") = "Y"
            End If
        Next

        tempRowArray = dtFuturesTrans.Select("checked='N'")
        For Each row As DataRow In tempRowArray
            Dim tempNewRow As DataRow = Nothing

            tempNewRow = dtReturn.NewRow()
            tempNewRow.Item("tdate") = row.Item("tdate")
            'tempNewRow.Item("accno") = row.Item("accno")
            tempNewRow.Item("fprod_code") = row.Item("code")
            tempNewRow.Item("fprod_name") = row.Item("prod_name")
            tempNewRow.Item("fstrike") = GFncNoNullStrike(row.Item("strike"))
            tempNewRow.Item("fcallput") = row.Item("callput")
            tempNewRow.Item("nstrike") = GFncNoNullStrike(row.Item("strike"))
            tempNewRow.Item("ncallput") = row.Item("callput")

            If Val(row.Item("month").ToString.Trim) <> 0 Then
                tempNewRow.Item("fmonth") = New DateTime( _
                                                             IIf( _
                                                                 Val(row.Item("month").ToString.Substring(0, 2)) <= 50, _
                                                                 2000 + Val(row.Item("month").ToString.Substring(0, 2)), _
                                                                 1900 + Val(row.Item("month").ToString.Substring(0, 2)) _
                                                             ), _
                                                             row.Item("month").ToString.Substring(2, 2), _
                                                             1 _
                                                         )
            End If

            tempNewRow.Item("fsettle_date") = row.Item("settle_date")

            If Not IsDBNull(row.Item("settle_date")) Then
                tempNewRow.Item("fday") = Format(row.Item("settle_date"), "dd")
            End If

            tempNewRow.Item("fbuy") = row.Item("buy")
            tempNewRow.Item("fsell") = row.Item("sell")
            tempNewRow.Item("fprice") = row.Item("price")
            tempNewRow.Item("status") = "NO_NEWEDGE"
            tempNewRow.Item("isadjusted") = False

            dtReturn.Rows.Add(tempNewRow)
        Next

        tempRowArray = dtNewedgeTrans.Select("checked='N'")
        For Each row As DataRow In tempRowArray
            Dim tempNewRow As DataRow = Nothing

            tempNewRow = dtReturn.NewRow()
            tempNewRow.Item("tdate") = row.Item("tdate")
            'tempNewRow.Item("tid") = row.Item("tid")
            tempNewRow.Item("nprod_name") = row.Item("code")

            If Not IsDBNull(row.Item("settle_date")) Then
                tempNewRow.Item("nsettle_date") = row.Item("settle_date")
            End If

            tempNewRow.Item("monthly_daily") = row.Item("monthly_daily")

            If row.Item("monthly_daily").ToString.Trim.ToUpper = "D" Then
                If Val(row.Item("month").ToString.Trim) <> 0 Then
                    tempNewRow.Item("nmonth") = New DateTime( _
                                                                CDate(row.Item("settle_date")).Year, _
                                                                CDate(row.Item("settle_date")).Month, _
                                                                1 _
                                                            )
                End If
                tempNewRow.Item("nday") = Format(row.Item("settle_date"), "dd")

            ElseIf row.Item("monthly_daily").ToString.Trim.ToUpper = "M" Then
                If Val(row.Item("month").ToString.Trim) <> 0 Then
                    tempNewRow.Item("nmonth") = New DateTime( _
                                                                  IIf( _
                                                                      Val(row.Item("month").ToString.Substring(0, 2)) <= 50, _
                                                                      2000 + Val(row.Item("month").ToString.Substring(0, 2)), _
                                                                      1900 + Val(row.Item("month").ToString.Substring(0, 2)) _
                                                                  ), _
                                                                  row.Item("month").ToString.Substring(2, 2), _
                                                                  1 _
                                                              )
                End If
                tempNewRow.Item("nday") = ""
            End If

            tempNewRow.Item("nbuy") = row.Item("buy")
            tempNewRow.Item("nsell") = row.Item("sell")
            tempNewRow.Item("nprice") = row.Item("price")
            tempNewRow.Item("status") = "NO_G2BF"
            tempNewRow.Item("fprod_code") = row.Item("nCode")
            tempNewRow.Item("fstrike") = GFncNoNullStrike(row.Item("strike"))
            tempNewRow.Item("fcallput") = row.Item("callput")
            tempNewRow.Item("nstrike") = GFncNoNullStrike(row.Item("strike"))
            tempNewRow.Item("ncallput") = row.Item("callput")
            tempNewRow.Item("isadjusted") = IIf(row.Item("isadjusted") = "Y", True, False)
            dtReturn.Rows.Add(tempNewRow)
        Next

        Dim ldtData As New DataTable
        ldtData.Columns.Add("fprod_code")
        ldtData.Columns.Add("fprod_name")
        ldtData.Columns.Add("fstrike")
        ldtData.Columns.Add("fcallput")
        ldtData.Columns.Add("nprod_code")
        ldtData.Columns.Add("nstrike")
        ldtData.Columns.Add("ncallput")
        ldtData.Columns.Add("monthly_daily")
        ldtData.Columns.Add("month", System.Type.GetType(" System.DateTime"))
        ldtData.Columns.Add("day")
        ldtData.Columns.Add("price", System.Type.GetType("System.Decimal"))
        ldtData.Columns.Add("fbuy", System.Type.GetType("System.Decimal"))
        ldtData.Columns.Add("fsell", System.Type.GetType("System.Decimal"))
        ldtData.Columns.Add("nbuy", System.Type.GetType("System.Decimal"))
        ldtData.Columns.Add("nsell", System.Type.GetType("System.Decimal"))


        Dim ldrTemp() As DataRow
        ldrTemp = dtReturn.Select(" status = 'NO_G2BF' ")
        For lint As Int16 = 0 To ldrTemp.Length - 1
            Dim ldr As DataRow
            Dim lstrQuery As String = ""
            lstrQuery = " nprod_code = '" & GFncSqlQuote(ldrTemp(lint).Item("nprod_name").ToString.Trim) & "' " & _
                                                        " and monthly_daily = '" & ldrTemp(lint).Item("monthly_daily") & "' " & _
                                                        " and month = '" & Format(ldrTemp(lint).Item("nmonth"), "yyyy/MM/dd") & "' " & _
                                                        " and price = " & ldrTemp(lint).Item("nprice") & " and nstrike = " & GFncNoNullStrike(ldrTemp(lint).Item("nstrike")) & " and ncallput = '" & ldrTemp(lint).Item("ncallput").ToString.Trim & "'"
            If Not ldrTemp(lint).Item("monthly_daily") = "M" Then
                lstrQuery += " and day = '" & ldrTemp(lint).Item("nday") & "' "
            End If
            If ldrTemp(lint).Item("nbuy") > 0 Then
                lstrQuery += " and nbuy > 0 "
            Else
                lstrQuery += " and nsell > 0 "
            End If

            ldr = FncGetRow(ldtData, lstrQuery)

            If IsNothing(ldr) Then
                ldr = ldtData.NewRow
                ldr.Item("nprod_code") = ldrTemp(lint).Item("nprod_name").ToString.Trim
                ldr.Item("fprod_code") = ldrTemp(lint).Item("fprod_code").ToString.Trim
                ldr.Item("fstrike") = ldrTemp(lint).Item("fstrike").ToString.Trim
                ldr.Item("fcallput") = ldrTemp(lint).Item("fcallput").ToString.Trim
                ldr.Item("nstrike") = GFncNoNullStrike(ldrTemp(lint).Item("nstrike"))
                ldr.Item("ncallput") = ldrTemp(lint).Item("ncallput").ToString.Trim
                ldr.Item("fprod_name") = ldrTemp(lint).Item("fprod_name").ToString.Trim
                ldr.Item("monthly_daily") = ldrTemp(lint).Item("monthly_daily")
                ldr.Item("month") = ldrTemp(lint).Item("nmonth")
                ldr.Item("day") = ldrTemp(lint).Item("nday")
                ldr.Item("price") = ldrTemp(lint).Item("nprice")
                ldr.Item("nbuy") = ldrTemp(lint).Item("nbuy")
                ldr.Item("nsell") = ldrTemp(lint).Item("nsell")
                ldr.Item("fbuy") = 0
                ldr.Item("fsell") = 0
                ldtData.Rows.Add(ldr)
            Else
                ldr.Item("nbuy") += ldrTemp(lint).Item("nbuy")
                ldr.Item("nsell") += ldrTemp(lint).Item("nsell")
            End If
        Next

        For lint As Int16 = 0 To ldtData.Rows.Count - 1
            Dim ldr() As DataRow
            Dim lstrQuery As String = ""
            lstrQuery = " status = 'NO_NEWEDGE' and fprod_code = '" & _
                                       ldtData.Rows(lint).Item("fprod_code").ToString.Trim & "' " & _
                                      " and fmonth = '" & Format(ldtData.Rows(lint).Item("month"), "yyyy/MM/dd") & "' " & _
                                      " and fprice = " & ldtData.Rows(lint).Item("price") & " and fstrike = " & GFncNoNullStrike(ldtData.Rows(lint).Item("fstrike")) & " and fcallput = '" & ldtData.Rows(lint).Item("fcallput").ToString.Trim & "'"
            If Not ldrTemp(lint).Item("monthly_daily") = "M" Then
                lstrQuery += " and fday = '" & ldtData.Rows(lint).Item("day") & "' "
            End If
            If ldtData.Rows(lint).Item("nbuy") > 0 Then
                lstrQuery += " and fbuy > 0 "
            Else
                lstrQuery += " and fsell > 0 "
            End If
            ldr = dtReturn.Select(lstrQuery)
            For lintCnt As Int16 = 0 To ldr.Length - 1
                ldtData.Rows(lint).Item("fbuy") += ldr(lintCnt).Item("fbuy")
                ldtData.Rows(lint).Item("fsell") += ldr(lintCnt).Item("fsell")
                ldtData.Rows(lint).Item("fprod_name") = ldr(lintCnt).Item("fprod_name")
            Next

        Next

        For lint As Int16 = 0 To ldtData.Rows.Count - 1
            Dim ldr() As DataRow
            Dim lstrQuery As String = ""
            If ldtData.Rows(lint).Item("fbuy") <> ldtData.Rows(lint).Item("nbuy") Then
                Continue For
            End If
            If ldtData.Rows(lint).Item("fsell") <> ldtData.Rows(lint).Item("nsell") Then
                Continue For
            End If
            lstrQuery = " status = 'NO_NEWEDGE' and fprod_code = '" & _
                                     ldtData.Rows(lint).Item("fprod_code").ToString.Trim & "' " & _
                                    " and fmonth = '" & Format(ldtData.Rows(lint).Item("month"), "yyyy/MM/dd") & "' " & _
                                    " and fprice = " & ldtData.Rows(lint).Item("price") & " and fstrike = " & GFncNoNullStrike(ldtData.Rows(lint).Item("fstrike")) & " and fcallput = '" & ldtData.Rows(lint).Item("fcallput").ToString.Trim & "'"
            If Not ldrTemp(lint).Item("monthly_daily") = "M" Then
                lstrQuery += " and fday = '" & ldtData.Rows(lint).Item("day") & "' "
            End If
            If ldtData.Rows(lint).Item("nbuy") > 0 Then
                lstrQuery += " and fbuy > 0 "
            Else
                lstrQuery += " and fsell > 0 "
            End If
            ldr = dtReturn.Select(lstrQuery)
            For lintCnt As Int16 = 0 To ldr.Length - 1
                ldr(lintCnt).Item("nprod_name") = ldtData.Rows(lint).Item("nprod_code")
                ldr(lintCnt).Item("status") = "MATCH"
            Next
            lstrQuery = " status = 'NO_G2BF' and nprod_name = '" & _
                                                ldtData.Rows(lint).Item("nprod_code").ToString.Trim & "' " & _
                                               " and nmonth = '" & Format(ldtData.Rows(lint).Item("month"), "yyyy/MM/dd") & "' " & _
                                               " and nprice = " & ldtData.Rows(lint).Item("price") & " and nstrike = " & GFncNoNullStrike(ldtData.Rows(lint).Item("nstrike")) & " and ncallput = '" & ldtData.Rows(lint).Item("ncallput").ToString.Trim & "'"
            If Not ldrTemp(lint).Item("monthly_daily") = "M" Then
                lstrQuery += " and nday = '" & ldtData.Rows(lint).Item("day") & "' "
            End If
            If ldtData.Rows(lint).Item("nbuy") > 0 Then
                lstrQuery += " and nbuy > 0 "
            Else
                lstrQuery += " and nsell > 0 "
            End If
            ldr = dtReturn.Select(lstrQuery)
            For lintCnt As Int16 = 0 To ldr.Length - 1
                ldr(lintCnt).Item("fprod_name") = ldtData.Rows(lint).Item("fprod_name")
                ldr(lintCnt).Item("fmonth") = ldtData.Rows(lint).Item("month")
                ldr(lintCnt).Item("fday") = ldtData.Rows(lint).Item("day")
                ldr(lintCnt).Item("status") = "MATCH"
            Next
        Next


        Return dtReturn
    End Function

    Private Function FncGetRow(ByVal dt As DataTable, ByVal strQuery As String) As DataRow
        Dim ldr() As DataRow = Nothing

        ldr = dt.Select(strQuery)
        If ldr.Length > 0 Then
            Return ldr(0)
        Else
            Return Nothing
        End If

    End Function

    Public Function FncGenAutoMatchReport(ByVal tdate As DateTime) As ReportClass

        Dim rpt As New rptNewedgeAutoMatch

        'rpt.SetDataSource(getDtAutoMatch(tdate))

        Dim dtG2bf As DataTable = New DtsNewedgeAutoMatch.G2BFDataTable
        Dim dtNewedge As DataTable = New DtsNewedgeAutoMatch.NewedgeDataTable
        Dim dtMain As DataTable = New DtsNewedgeAutoMatch.mainDataTable

        getDtAutoMatch(tdate, dtMain, dtG2bf, dtNewedge)

        rpt.Database.Tables("main").SetDataSource(dtMain)
        rpt.Database.Tables("G2BF").SetDataSource(dtG2bf)
        rpt.Database.Tables("Newedge").SetDataSource(dtNewedge)

        'rpt.SetParameterValue("user", GStrloginID)
        'rpt.SetParameterValue("tdate", Format(tdate, "dd MMM yy"))
        Return rpt
    End Function

    Private Sub getDtAutoMatch(ByVal tradeDate As DateTime, ByRef dtMain As DataTable, ByRef dtG2BF As DataTable, ByRef dtNewedge As DataTable)
        Dim dtReturn As DataTable = New DataTable
        Dim dtG2BF_OpenPosition As DataTable
        Dim dtNewedge_OpenPosition As DataTable
        Dim strSQL As String = ""
        Dim newedgeRowArray() As DataRow
        Dim g2bfRowArray() As DataRow
        Dim newedgeRow As DataRow
        Dim g2bfRow As DataRow
        'Dim dtTemp As DataTable
        Dim newedgeNewRow As DataRow
        Dim g2bfNewRow As DataRow
        'Dim lastGroup As String = ""
        'Dim groupRow As DataRo

        'Dim dtGroupName As DataTable
        'Dim groupNameRowArray() As DataRow
        'Dim groupNameRow As daterow
        Dim groupName As String = ""

        'get open position
        strSQL = "select " _
                    & " a.code, b.product_name, a.sysdate, a.tdate, a.qty, " _
                    & " a.type, a.monthcode, a.accno, a.price, a.settle_date, 'N' as checked " _
                    & " from futuresop a left outer join futures_product_master b " _
                    & " on a.code=b.product_code where upper(a.counterparty)='NEWEDGE' " _
                    & " and a.sysdate='" & Format(tradeDate, "yyyy/MM/dd") & "'"

        dtG2BF_OpenPosition = GFncRtnDS(GSCnSqlConn, strSQL).Tables(0)

        'strSQL = "select " _
        '            & " a.noid, a.tdate, a.odate, a.buy, a.sell, a.monthcode, " _
        '            & " a.product, c.product_name, a.price, a.settle_date, a.monthly_daily, 'N' as checked " _
        '            & " from newedge_cap_op a left outer join product_mapping b " _
        '            & " on a.product=b.d_newedge_code left outer join futures_product_master c " _
        '            & " on b.d_code=c.product_code where a.tdate='" & Format(tradeDate, "yyyy/MM/dd") & "'"
        strSQL = "select " _
                            & " a.noid, a.tdate, a.odate, a.buy, a.sell, a.monthcode, " _
                            & " a.product, c.product_name, a.price, a.settle_date, a.monthly_daily, 'N' as checked " _
                            & " from vw_cap_op a left outer join product_mapping b " _
                            & " on a.product=b.d_newedge_code left outer join futures_product_master c " _
                            & " on b.d_code=c.product_code where a.tdate='" & Format(tradeDate, "yyyy/MM/dd") & "'"

        dtNewedge_OpenPosition = GFncRtnDS(GSCnSqlConn, strSQL).Tables(0)

        'get daily product
        newedgeRowArray = dtNewedge_OpenPosition.Select("monthly_daily='D' and checked='N'")
        For Each newedgeRow In newedgeRowArray

            If Not IsDBNull(newedgeRow.Item("product_name")) Then
                groupName = newedgeRow.Item("product_name").ToString.Trim & " [" & Format(newedgeRow.Item("settle_date"), "dd MMM yy") & "]"

                Dim mainNewRow As DataRow = dtMain.NewRow
                mainNewRow.Item("group_name") = groupName
                dtMain.Rows.Add(mainNewRow)

                newedgeNewRow = dtNewedge.NewRow()
                newedgeNewRow.Item("prod_code") = newedgeRow.Item("product").ToString.Trim
                newedgeNewRow.Item("prod_name") = newedgeRow.Item("product_name").ToString.Trim
                newedgeNewRow.Item("tid") = newedgeRow.Item("noid").ToString.Trim
                newedgeNewRow.Item("tdate") = newedgeRow.Item("tdate")
                newedgeNewRow.Item("odate") = newedgeRow.Item("odate")
                newedgeNewRow.Item("buy") = newedgeRow.Item("buy")
                newedgeNewRow.Item("sell") = newedgeRow.Item("sell")
                newedgeNewRow.Item("monthcode") = newedgeRow.Item("monthcode").ToString.Trim
                newedgeNewRow.Item("price") = newedgeRow.Item("price")
                newedgeNewRow.Item("settle_date") = newedgeRow.Item("settle_date")
                newedgeNewRow.Item("monthly_daily") = newedgeRow.Item("monthly_daily").ToString.Trim
                newedgeNewRow.Item("group_name") = groupName
                dtNewedge.Rows.Add(newedgeNewRow)

                newedgeRow.Item("checked") = "Y"

                g2bfRowArray = dtG2BF_OpenPosition.Select("product_name='" & newedgeRow.Item("product_name") & "' and settle_date='" & Format(newedgeRow.Item("settle_date"), "yyyy/MM/dd") & "' and checked='N'")
                For Each g2bfRow In g2bfRowArray
                    g2bfNewRow = dtG2BF.NewRow()
                    g2bfNewRow.Item("prod_code") = g2bfRow.Item("code").ToString.Trim
                    g2bfNewRow.Item("prod_name") = g2bfRow.Item("product_name").ToString.Trim
                    g2bfNewRow.Item("sysdate") = g2bfRow.Item("sysdate")
                    g2bfNewRow.Item("tdate") = g2bfRow.Item("tdate")

                    If g2bfRow.Item("type").ToString.Trim = "1" Then
                        g2bfNewRow.Item("buy") = g2bfRow.Item("qty")

                    ElseIf g2bfRow.Item("type") = "2" Then
                        g2bfNewRow.Item("sell") = g2bfRow.Item("qty")
                    End If

                    g2bfNewRow.Item("monthcode") = g2bfRow.Item("monthcode").ToString.Trim
                    g2bfNewRow.Item("accno") = g2bfRow.Item("accno").ToString.Trim
                    g2bfNewRow.Item("price") = g2bfRow.Item("price")
                    g2bfNewRow.Item("settle_date") = g2bfRow.Item("settle_date")
                    g2bfNewRow.Item("group_name") = groupName
                    dtG2BF.Rows.Add(g2bfNewRow)

                    g2bfRow.Item("checked") = "Y"
                Next
            End If
        Next

        'get monthly product
        newedgeRowArray = dtNewedge_OpenPosition.Select("monthly_daily='M' and checked='N'")
        For Each newedgeRow In newedgeRowArray

            If Not IsDBNull(newedgeRow.Item("product_name")) Then

                Dim tempDate As DateTime
                Dim tempStr As String

                tempStr = newedgeRow.Item("monthcode").ToString.Trim
                tempDate = New Date(tempStr.Substring(0, 2), tempStr.Substring(2, 2), 1)

                groupName = newedgeRow.Item("product_name").ToString.Trim & " [" & Format(tempDate, "MMM yy") & "]"

                Dim mainNewRow As DataRow = dtMain.NewRow
                mainNewRow.Item("group_name") = groupName
                dtMain.Rows.Add(mainNewRow)

                newedgeNewRow = dtNewedge.NewRow()
                newedgeNewRow.Item("prod_code") = newedgeRow.Item("product").ToString.Trim
                newedgeNewRow.Item("prod_name") = newedgeRow.Item("product_name").ToString.Trim
                newedgeNewRow.Item("tid") = newedgeRow.Item("noid")
                newedgeNewRow.Item("tdate") = newedgeRow.Item("tdate")
                newedgeNewRow.Item("odate") = newedgeRow.Item("odate")
                newedgeNewRow.Item("buy") = newedgeRow.Item("buy")
                newedgeNewRow.Item("sell") = newedgeRow.Item("sell")
                newedgeNewRow.Item("monthcode") = newedgeRow.Item("monthcode").ToString.Trim
                newedgeNewRow.Item("price") = newedgeRow.Item("price")
                newedgeNewRow.Item("settle_date") = newedgeRow.Item("settle_date")
                newedgeNewRow.Item("monthly_daily") = newedgeRow.Item("monthly_daily")
                newedgeNewRow.Item("group_name") = groupName
                dtNewedge.Rows.Add(newedgeNewRow)

                newedgeRow.Item("checked") = "Y"

                g2bfRowArray = dtG2BF_OpenPosition.Select("product_name='" & newedgeRow.Item("product_name").ToString.Trim & "' and monthcode='" & newedgeRow.Item("monthcode").ToString.Trim & "' and checked='N'")
                For Each g2bfRow In g2bfRowArray
                    g2bfNewRow = dtG2BF.NewRow()
                    g2bfNewRow.Item("prod_code") = g2bfRow.Item("code").ToString.Trim
                    g2bfNewRow.Item("prod_name") = g2bfRow.Item("product_name").ToString.Trim
                    g2bfNewRow.Item("sysdate") = g2bfRow.Item("sysdate")
                    g2bfNewRow.Item("tdate") = g2bfRow.Item("tdate")

                    If g2bfRow.Item("type").ToString.Trim = "1" Then
                        g2bfNewRow.Item("buy") = g2bfRow.Item("qty")

                    ElseIf g2bfRow.Item("type").ToString.Trim = "2" Then
                        g2bfNewRow.Item("sell") = g2bfRow.Item("qty")
                    End If

                    g2bfNewRow.Item("monthcode") = g2bfRow.Item("monthcode").ToString.Trim
                    g2bfNewRow.Item("accno") = g2bfRow.Item("accno").ToString.Trim
                    g2bfNewRow.Item("price") = g2bfRow.Item("price")
                    g2bfNewRow.Item("settle_date") = g2bfRow.Item("settle_date")
                    g2bfNewRow.Item("group_name") = groupName
                    dtG2BF.Rows.Add(g2bfNewRow)

                    g2bfRow.Item("checked") = "Y"
                Next
            End If
        Next

        newedgeRowArray = dtNewedge_OpenPosition.Select("checked='N'")
        For Each newedgeRow In newedgeRowArray
            groupName = ""

            Dim mainNewRow As DataRow = dtMain.NewRow
            mainNewRow.Item("group_name") = groupName
            dtMain.Rows.Add(mainNewRow)

            newedgeNewRow = dtNewedge.NewRow()
            newedgeNewRow.Item("prod_code") = newedgeRow.Item("product").ToString.Trim
            newedgeNewRow.Item("prod_name") = newedgeRow.Item("product_name").ToString.Trim
            newedgeNewRow.Item("tid") = newedgeRow.Item("noid").ToString.Trim
            newedgeNewRow.Item("tdate") = newedgeRow.Item("tdate")
            newedgeNewRow.Item("odate") = newedgeRow.Item("odate")
            newedgeNewRow.Item("buy") = newedgeRow.Item("buy")
            newedgeNewRow.Item("sell") = newedgeRow.Item("sell")
            newedgeNewRow.Item("monthcode") = newedgeRow.Item("monthcode").ToString.Trim
            newedgeNewRow.Item("price") = newedgeRow.Item("price")
            newedgeNewRow.Item("settle_date") = newedgeRow.Item("settle_date")
            newedgeNewRow.Item("monthly_daily") = newedgeRow.Item("monthly_daily").ToString.Trim
            newedgeNewRow.Item("group_name") = groupName
            dtNewedge.Rows.Add(newedgeNewRow)

            newedgeRow.Item("checked") = "Y"
        Next

        'get monthly product
        g2bfRowArray = dtG2BF_OpenPosition.Select("checked='N'")
        For Each g2bfRow In g2bfRowArray

            groupName = ""

            Dim mainNewRow As DataRow = dtMain.NewRow
            mainNewRow.Item("group_name") = groupName
            dtMain.Rows.Add(mainNewRow)

            g2bfNewRow = dtG2BF.NewRow()
            g2bfNewRow.Item("prod_code") = g2bfRow.Item("code").ToString.Trim
            g2bfNewRow.Item("prod_name") = g2bfRow.Item("product_name").ToString.Trim
            g2bfNewRow.Item("sysdate") = g2bfRow.Item("sysdate")
            g2bfNewRow.Item("tdate") = g2bfRow.Item("tdate")

            If g2bfRow.Item("type").ToString.Trim = "1" Then
                g2bfNewRow.Item("buy") = g2bfRow.Item("qty")

            ElseIf g2bfRow.Item("type").ToString.Trim = "2" Then
                g2bfNewRow.Item("sell") = g2bfRow.Item("qty")
            End If

            g2bfNewRow.Item("monthcode") = g2bfRow.Item("monthcode").ToString.Trim
            g2bfNewRow.Item("accno") = g2bfRow.Item("accno").ToString.Trim
            g2bfNewRow.Item("price") = g2bfRow.Item("price")
            g2bfNewRow.Item("settle_date") = g2bfRow.Item("settle_date")
            g2bfNewRow.Item("group_name") = groupName
            dtG2BF.Rows.Add(g2bfNewRow)

            g2bfRow.Item("checked") = "Y"
        Next

        Dim tempArray() As DataRow




        'check unmapped
        For Each tempMainRow As DataRow In dtMain.Rows

            tempArray = dtNewedge.Select("group_name='" & tempMainRow.Item("group_name").ToString.Trim & "'")
            For Each tempNewedgeRow As DataRow In tempArray
                tempNewedgeRow.Item("checked") = "Y"
            Next

            tempArray = dtG2BF.Select("group_name='" & tempMainRow.Item("group_name").ToString.Trim & "'")
            For Each tempG2bRow As DataRow In tempArray
                tempG2bRow.Item("checked") = "Y"
            Next
        Next

        tempArray = dtG2BF.Select("checked<>'Y'")
        For Each row As DataRow In tempArray
            row.Item("checked") = "N"
        Next

        tempArray = dtG2BF.Select("checked<>'Y'")
        For Each row As DataRow In tempArray
            row.Item("checked") = "N"
        Next
    End Sub
End Class