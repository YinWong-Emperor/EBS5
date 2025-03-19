Public Class clsRptClientTurnover

    Protected Friend Sub LoadClient(ByRef pCombo As ComboBox, ByRef pCombo_1 As ComboBox)
        Dim lcStrSQL As String = "select distinct accno from " & GStrG2BFDB & ".dbo.client_master order by accno"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        dt.Rows.InsertAt(dt.NewRow, 0)
        Dim dt_1 As DataTable = dt.Copy
        pCombo.DataSource = dt
        pCombo_1.DataSource = dt_1
        pCombo.ValueMember = "accno"
        pCombo_1.ValueMember = "accno"
    End Sub

    Protected Friend Sub LoadAE(ByRef pCombo As ComboBox, ByRef pCombo_1 As ComboBox)
        Dim lcStrSQL As String = "select distinct aeno from " & GStrG2BFDB & ".dbo.ae_master order by aeno"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        dt.Rows.InsertAt(dt.NewRow, 0)
        Dim dt_1 As DataTable = dt.Copy
        pCombo.DataSource = dt
        pCombo_1.DataSource = dt_1
        pCombo.ValueMember = "aeno"
        pCombo_1.ValueMember = "aeno"
    End Sub

    Protected Friend Sub LoadExchangeCode(ByRef pCombo As ComboBox)
        Dim lcStrSQL As String = "select distinct name_s from " & GStrG2BFDB & ".dbo.market_master order by name_s"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        dt.Rows.Add("--ALL--")
        pCombo.DataSource = dt
        pCombo.ValueMember = "name_s"
    End Sub
    Protected Friend Function GetTradeDate() As Date
        Dim ldteTrade As Date = Now

        Dim lcStrSQL As String = ""
        lcStrSQL = " select * from " & GStrG2BFDB & ".dbo.system_parameter where cmid = '999' "
        Dim lds As DataSet = GFncRtnDS(GSCnSqlConn, lcStrSQL)
        If lds.Tables(0).Rows.Count > 0 Then
            ldteTrade = GFncNoNullDate(lds.Tables(0).Rows(0).Item("tradedate"))
        End If
        Return ldteTrade
    End Function
    Protected Friend Function GetMainReport(ByVal pClientFrm As String, ByVal pClientTo As String, ByVal pAECodeFrm As String, _
                                            ByVal pAECodeTo As String, ByVal pAvgTurnover As String, _
                                            ByVal pExchange As String, ByRef outSrc As DataTable, _
                                            ByVal dteTrade As Date, ByRef outFilteredSrc As DataTable) As DataTable
        Dim lcResult As DataTable = New DtsRptClientTurnover.DtsRptClientTurnoverDataTable
        Dim lcResult_unfiltered As DataTable = New DtsRptClientTurnover.DtsRptClientTurnoverDataTable
        Dim lcStrSQL As String = ""
        Dim lcDateFrm As Date = dteTrade.AddMonths(-2)
        Dim lcDateTo As Date = dteTrade
        Dim lcPrevMonth As Date = dteTrade.AddMonths(-1)
        Dim lcStrSelect As String = "1=1"

        Dim ldtAverage As New DataTable
        ldtAverage.Columns.Add("accno")
        ldtAverage.Columns.Add("Total_Average", GetType(Decimal))

        lcStrSQL = "select  d.accno, d.name_1 as AccName, f.aeno, f.name as AeName, " & _
                    "e.name_s as MarketCode, g.name_s as CurrencyCode, month(tdate) as TxMonth, " & _
                    " Year(tdate) as TxYear, isnull(h.last, 1) as ToHKDRate, " & _
                    "sum(isnull(c.comm, 0)) as TotalComm, sum(isnull(b.TurnoverLot, 0))as TotalLot, " & _
                    "sum(isnull(b.TurnoverAmt, 0))as TotalAmt " & _
                    "from " & GStrG2BFDB & ".dbo.view_all_tradeh a " & _
                    "left join (select oid, sum(qty) as TurnoverLot,  " & _
                    "sum(price*qty) as TurnoverAmt from " & GStrG2BFDB & ".dbo.view_all_traded  " & _
                    "group by oid) b on a.oid = b.oid " & _
                    "left join (select oid, sum(comm) as comm from " & GStrG2BFDB & _
                    ".dbo.view_total_order_fees group by oid) c on a.oid = c.oid " & _
                    "left join " & GStrG2BFDB & ".dbo.client_master d on a.aid = d.aid " & _
                    "left join " & GStrG2BFDB & ".dbo.client_master_f i on i.aid = d.aid " & _
                    "left join " & GStrG2BFDB & ".dbo.market_master e on a.mkid = e.mkid " & _
                    "left join " & GStrG2BFDB & ".dbo.ae_master f on i.aeid = f.aeid " & _
                    "left join " & GStrG2BFDB & ".dbo.currency_master g on g.cuid = a.cuid_chrg " & _
                    "left join " & GStrG2BFDB & ".dbo.currency_exchange h on h.cuid = a.cuid_chrg and h.cuid_ex = 1 " & _
                    "where tdate >= '" & lcDateFrm.ToString("yyyy/MM/01") & "' and tdate <= '" & lcDateTo.ToString("yyyy/MM/dd") & "' "
        lcStrSQL &= " and a.cmid = '999' " & _
                    " and tradetype not in ('E','V','W','Y','Z','T','U','P','Q') " & _
                    " group by d.accno, d.name_1 , f.aeno, f.name ,  " & _
                    " e.name_s , g.name_s , month(tdate),  Year(tdate), h.last " & _
                    " order by d.accno, e.name_s "

        outSrc = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        If pClientFrm <> "" Then
            lcStrSelect &= "and accno >= '" & pClientFrm.Trim & "' "
        End If
        If pClientTo <> "" Then
            lcStrSelect &= "and accno <= '" & pClientTo.Trim & "' "
        End If

        If pAECodeFrm <> "" Then
            lcStrSelect &= "and aeno >= '" & pAECodeFrm.Trim & "' "
        End If
        If pAECodeTo <> "" Then
            lcStrSelect &= "and aeno <= '" & pAECodeTo.Trim & "' "
        End If

        If pExchange <> "" AndAlso pExchange <> "--ALL--" Then
            lcStrSelect &= "and MarketCode = '" & pExchange & "' "
        End If

        Dim dt As DataTable = outSrc.Clone()
        Dim dr_arr As DataRow() = outSrc.Select(lcStrSelect)
        If dr_arr.Length > 0 Then
            For i As Integer = 0 To dr_arr.Length - 1
                dt.Rows.Add(dr_arr(i).ItemArray())
            Next
        End If

        outFilteredSrc = dt

        lcStrSQL = "select " & _
                    "b.accno, " & _
                    "sum(isnull(amt,0)*c.last) as amt, " & _
                    "month(vdate) as TxMonth, " & _
                    "Year(vdate) as TxYear " & _
                    "from " & _
                    "" & GStrG2BFDB & ".dbo.view_all_fund_move a  " & _
                    "left join " & GStrG2BFDB & ".dbo.client_master b on a.aid = b.aid " & _
                    "left join " & GStrG2BFDB & ".dbo.currency_exchange c on c.cuid = a.cuid and c.cuid_ex = 1 " & _
                    "left join " & GStrG2BFDB & ".dbo.currency_master d on d.cuid = a.cuid " & _
                    "where vdate >= '" & lcDateTo.ToString("yyyy/MM/01") & "' and vdate <= '" & lcDateTo.ToString("yyyy/MM/dd") & "' " & _
                    "and a.cmid = '999' " & _
                    "group by b.accno, month(vdate), Year(vdate) "
        Dim dt_margin As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Dim lcDr As DataRow
        For i As Integer = 0 To dt.Rows.Count - 1
            Dim tmpDrs As DataRow() = lcResult_unfiltered.Select("d_acc_no = '" & dt.Rows(i).Item("accno") & "' and d_ae_code = '" & dt.Rows(i).Item("aeno") & "' and d_exchange = '" & dt.Rows(i).Item("MarketCode") & "'")
            If tmpDrs.Length > 0 Then
                lcDr = tmpDrs(0)
            Else
                lcDr = lcResult_unfiltered.NewRow()

                lcDr("d_acc_no") = dt.Rows(i).Item("accno")
                lcDr("d_client_name") = dt.Rows(i).Item("AccName")
                lcDr("d_ae_code") = dt.Rows(i).Item("aeno")
                lcDr("d_ae_name") = dt.Rows(i).Item("AeName")
                lcDr("d_exchange") = dt.Rows(i).Item("MarketCode")
            End If



            If lcPrevMonth.Month = dt.Rows(i).Item("TxMonth") AndAlso lcPrevMonth.Year = dt.Rows(i).Item("TxYear") Then
                lcDr("d_prev_month") = GFncNoNullValue(dt.Rows(i).Item("TotalLot"))
            ElseIf lcDateFrm.Month = dt.Rows(i).Item("TxMonth") AndAlso lcDateFrm.Year = dt.Rows(i).Item("TxYear") Then
                lcDr("d_prec_prev_month") = GFncNoNullValue(dt.Rows(i).Item("TotalLot"))
            ElseIf lcDateTo.Month = dt.Rows(i).Item("TxMonth") AndAlso lcDateTo.Year = dt.Rows(i).Item("TxYear") Then
                lcDr("d_turnover_lots") = GFncNoNullValue(dt.Rows(i).Item("TotalLot"))
                lcDr("d_turnover_amt") = GFncNoNullValue(dt.Rows(i).Item("TotalAmt") * dt.Rows(i).Item("ToHKDRate")) / 1000
                lcDr("d_comm") = GFncNoNullValue(dt.Rows(i).Item("TotalComm")) * GFncNoNullValue(dt.Rows(i).Item("ToHKDRate")) / 1000
            End If

            If tmpDrs.Length <= 0 Then
                lcResult_unfiltered.Rows.Add(lcDr)
            End If

        Next

        For i As Integer = 0 To lcResult_unfiltered.Rows.Count - 1
            lcResult_unfiltered.Rows(i).Item("d_average") = (GFncNoNullValue(lcResult_unfiltered.Rows(i).Item("d_prev_month")) + GFncNoNullValue(lcResult_unfiltered.Rows(i).Item("d_prec_prev_month"))) / 2
            Dim tmpDrs As DataRow() = dt_margin.Select("accno = '" & lcResult_unfiltered.Rows(i).Item("d_acc_no") & "'")
            If tmpDrs.Length > 0 Then
                lcResult_unfiltered.Rows(i).Item("d_margin") = GFncNoNullValue(tmpDrs(0).Item("amt")) / 1000
                dt_margin.Rows.RemoveAt(dt_margin.Rows().IndexOf(tmpDrs(0)))
            End If
            tmpDrs = ldtAverage.Select("accno = '" & lcResult_unfiltered.Rows(i).Item("d_acc_no") & "'")
            If tmpDrs.Length > 0 Then
                tmpDrs(0).Item("total_Average") += lcResult_unfiltered.Rows(i).Item("d_average")
            Else
                lcDr = ldtAverage.NewRow()
                lcDr("accno") = lcResult_unfiltered.Rows(i).Item("d_acc_no")
                lcDr("total_average") = lcResult_unfiltered.Rows(i).Item("d_average")
                ldtAverage.Rows.Add(lcDr)
            End If
        Next
        For i As Integer = 0 To lcResult_unfiltered.Rows.Count - 1
            Dim tmpDrs As DataRow() = ldtAverage.Select("accno = '" & lcResult_unfiltered.Rows(i).Item("d_acc_no") & "'")
            If tmpDrs.Length > 0 Then
                lcResult_unfiltered.Rows(i).Item("d_average_total") = tmpDrs(0).Item("total_Average")
            End If
        Next

        If pAvgTurnover <> "" Then
            Dim tmpDrs As DataRow() = ldtAverage.Select("total_average >= " & pAvgTurnover)
            For lint As Int16 = 0 To tmpDrs.Length - 1
                Dim drs As DataRow() = lcResult_unfiltered.Select("d_acc_no = '" & tmpDrs(lint).Item("accno") & "' ")
                For i As Integer = 0 To drs.Length - 1
                    lcDr = lcResult.NewRow()
                    For j As Integer = 0 To lcResult.Columns.Count - 1
                        lcDr(j) = drs(i).Item(j)
                    Next
                    lcResult.Rows.Add(lcDr)
                Next
            Next
        Else
            For i As Integer = 0 To lcResult_unfiltered.Rows.Count - 1
                lcResult.Rows.Add(lcResult_unfiltered.Rows(i).ItemArray)
            Next
        End If

        Dim lcSortedDv As DataView = lcResult.DefaultView
        lcSortedDv.Sort = "d_acc_no, d_ae_code, d_exchange"

        Return lcSortedDv.ToTable()
    End Function

    Protected Friend Function GetSortedTable(ByVal pSrc As DataTable, ByVal pSortedField As String, ByVal pSortMode As String) As DataTable
        Dim lcDrs As DataRow()
        Dim lcAccNo As String = ""
        Dim lcSumAvgLots As Decimal = 0.0

        If pSortedField = "d_average" Then
            pSrc.Columns.Remove("d_sort")
            pSrc.Columns.Add("d_sort", GetType(Decimal))
        ElseIf pSortedField = "d_acc_no" Then
            pSrc.Columns.Remove("d_sort")
            pSrc.Columns.Add("d_sort", GetType(String))
        End If

        For i As Integer = 0 To pSrc.Rows.Count - 1
            If lcAccNo <> pSrc.Rows(i).Item("d_acc_no").ToString() Then
                lcDrs = pSrc.Select("d_acc_no = '" & lcAccNo & "'")
                For j As Integer = 0 To lcDrs.Length - 1
                    If pSortedField = "d_average" Then
                        lcDrs(j).Item("d_sort") = lcSumAvgLots
                    ElseIf pSortedField = "d_acc_no" Then
                        lcDrs(j).Item("d_sort") = lcAccNo
                    End If
                Next
                lcAccNo = pSrc.Rows(i).Item("d_acc_no").ToString()
                lcSumAvgLots = pSrc.Rows(i).Item("d_average")
            Else
                lcSumAvgLots += pSrc.Rows(i).Item("d_average")
            End If
        Next

        lcDrs = pSrc.Select("d_acc_no = '" & lcAccNo & "'")
        For j As Integer = 0 To lcDrs.Length - 1
            If pSortedField = "d_average" Then
                lcDrs(j).Item("d_sort") = lcSumAvgLots
            ElseIf pSortedField = "d_acc_no" Then
                lcDrs(j).Item("d_sort") = lcAccNo
            End If
        Next

        Dim lcSortedDv As DataView = pSrc.DefaultView
        lcSortedDv.Sort = "d_sort " & pSortMode & ", d_acc_no, d_ae_code, d_exchange"

        Return lcSortedDv.ToTable()
    End Function

    Protected Friend Function GetReportSummary(ByVal pSrc As DataTable, ByVal pDteTradeDate As Date, ByVal pSrc_cnt As DataTable) As DataTable
        Dim lcResult As DataTable = New DtsRptClientTurnover.DtsRptClientTurnoverSubDataTable

        Dim lcDateFrm As Date = pDteTradeDate.AddMonths(-2)
        Dim lcDateTo As Date = pDteTradeDate.AddDays(-1)
        Dim lcPrevMonth As Date = pDteTradeDate.AddMonths(-1)
        Dim lIntPrevMon As Integer = 0
        Dim lIntPrecPrevMon As Integer = 0
        Dim lIntAvg As Integer = 0
        Dim lstrAccNo As String = ""

        Dim lcDr As DataRow
        For i As Integer = 0 To pSrc.Rows.Count - 1
            Dim tmpDrs As DataRow() = lcResult.Select("d_exchange = '" & pSrc.Rows(i).Item("d_exchange") & "'")
            If tmpDrs.Length > 0 Then
                tmpDrs(0).Item("d_average") += GFncNoNullValue(pSrc.Rows(i).Item("d_average"))
                tmpDrs(0).Item("d_prev_month") += GFncNoNullValue(pSrc.Rows(i).Item("d_prev_month"))
                tmpDrs(0).Item("d_prec_prev_month") += GFncNoNullValue(pSrc.Rows(i).Item("d_prec_prev_month"))
                tmpDrs(0).Item("d_turnover_lots") += GFncNoNullValue(pSrc.Rows(i).Item("d_turnover_lots"))
                tmpDrs(0).Item("d_turnover_amt") += GFncNoNullValue(pSrc.Rows(i).Item("d_turnover_amt"))
                tmpDrs(0).Item("d_comm") += GFncNoNullValue(pSrc.Rows(i).Item("d_comm"))
                tmpDrs(0).Item("d_margin") += GFncNoNullValue(pSrc.Rows(i).Item("d_margin"))

            Else
                lcDr = lcResult.NewRow()

                lcDr("d_exchange") = pSrc.Rows(i).Item("d_exchange")

                lcDr("d_average") = GFncNoNullValue(pSrc.Rows(i).Item("d_average"))
                lcDr("d_prev_month") = GFncNoNullValue(pSrc.Rows(i).Item("d_prev_month"))
                lcDr("d_prec_prev_month") = GFncNoNullValue(pSrc.Rows(i).Item("d_prec_prev_month"))
                lcDr("d_turnover_lots") = GFncNoNullValue(pSrc.Rows(i).Item("d_turnover_lots"))
                lcDr("d_turnover_amt") = GFncNoNullValue(pSrc.Rows(i).Item("d_turnover_amt"))
                lcDr("d_comm") = GFncNoNullValue(pSrc.Rows(i).Item("d_comm"))
                lcDr("d_margin") = GFncNoNullValue(pSrc.Rows(i).Item("d_margin"))
                lcResult.Rows.Add(lcDr)
            End If
        Next

        Dim dt As DataTable = pSrc
        lstrAccNo = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If GFncNoNullValue(dt.Rows(i).Item("d_prev_month")) <> 0.0 Then
                If lstrAccNo <> dt.Rows(i).Item("d_acc_no") Then
                    lIntPrevMon += 1
                    lstrAccNo = dt.Rows(i).Item("d_acc_no")
                End If
            End If
        Next
        lstrAccNo = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If GFncNoNullValue(dt.Rows(i).Item("d_prec_prev_month")) <> 0.0 Then
                If lstrAccNo <> dt.Rows(i).Item("d_acc_no") Then
                    lIntPrecPrevMon += 1
                    lstrAccNo = dt.Rows(i).Item("d_acc_no")
                End If
            End If
        Next
        lstrAccNo = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If GFncNoNullValue(dt.Rows(i).Item("d_average")) <> 0.0 Then
                If lstrAccNo <> dt.Rows(i).Item("d_acc_no") Then
                    lIntAvg += 1
                    lstrAccNo = dt.Rows(i).Item("d_acc_no")
                End If
            End If
        Next

        ''Dim dt As DataTable = pSrc_cnt
        'lstrAccNo = ""
        'For i As Integer = 0 To dt.Rows.Count - 1
        '    If lcPrevMonth.Month = dt.Rows(i).Item("TxMonth") AndAlso lcPrevMonth.Year = dt.Rows(i).Item("TxYear") Then
        '        If lstrAccNo <> dt.Rows(i).Item("accno") Then
        '            lIntPrevMon += 1
        '            lstrAccNo = dt.Rows(i).Item("accno")
        '        End If
        '    End If
        'Next
        'lstrAccNo = ""
        'For i As Integer = 0 To dt.Rows.Count - 1
        '    If lcDateFrm.Month = dt.Rows(i).Item("TxMonth") AndAlso lcDateFrm.Year = dt.Rows(i).Item("TxYear") Then
        '        If lstrAccNo <> dt.Rows(i).Item("accno") Then
        '            lIntPrecPrevMon += 1
        '            lstrAccNo = dt.Rows(i).Item("accno")
        '        End If
        '    End If
        'Next
        'lstrAccNo = ""

        'Dim drs As DataRow() = dt.Select("(TxMonth='" & lcDateFrm.Month & "' AND TxYear='" & lcDateFrm.Year & "') OR (TxMonth='" & lcPrevMonth.Month & "' AND TxYear='" & lcPrevMonth.Year & "')")
        'Dim dt_new As DataTable = dt.Clone()
        'For i As Integer = 0 To drs.Length - 1
        '    dt_new.Rows.Add(drs(i).ItemArray)
        'Next
        'Dim dv As DataTable = dt_new.DefaultView().ToTable(True, "accno")
        'lIntAvg = dv.Rows.Count

        If lcResult.Rows.Count > 0 Then
            For i As Integer = 0 To lcResult.Rows.Count - 1
                lcResult.Rows(i).Item("d_prec_prev_month_cnt") = lIntPrecPrevMon
                lcResult.Rows(i).Item("d_prev_month_cnt") = lIntPrevMon
                lcResult.Rows(i).Item("d_average_cnt") = lIntAvg
            Next
            'lcResult.Rows(lcResult.Rows.Count - 1).Item("d_prec_prev_month_cnt") = lIntPrecPrevMon
            'lcResult.Rows(lcResult.Rows.Count - 1).Item("d_prev_month_cnt") = lIntPrevMon
            'lcResult.Rows(lcResult.Rows.Count - 1).Item("d_average_cnt") = lIntAvg
        End If

        Dim lcSortedDv As DataView = lcResult.DefaultView
        lcSortedDv.Sort = "d_exchange"

        Return lcSortedDv.ToTable()
    End Function

    Protected Friend Function GetReportCompany(ByVal pSrc As DataTable, ByVal pDteTradeDate As Date) As DataTable
        Dim lcResult As DataTable = New DtsRptClientTurnover.DtsRptClientTurnoverCompanyTotalDataTable
        Dim lcStrSQL As String = ""
        Dim lcDateFrm As Date = pDteTradeDate.AddMonths(-2)
        Dim lcDateTo As Date = pDteTradeDate.AddDays(-1)
        Dim lcPrevMonth As Date = pDteTradeDate.AddMonths(-1)


        'lcStrSQL = "select  d.accno, d.name_1 as AccName, f.aeno, f.name as AeName, " & _
        '    "e.name_s as MarketCode, g.name_s as CurrencyCode, month(tdate) as TxMonth, " & _
        '    " Year(tdate) as TxYear, isnull(h.last, 1) as ToHKDRate, " & _
        '    "sum(isnull(c.comm, 0)) as TotalComm, sum(isnull(b.TurnoverLot, 0))as TotalLot, " & _
        '    "sum(isnull(b.TurnoverAmt, 0))as TotalAmt " & _
        '    "from view_all_tradeh a " & _
        '    "left join (select oid, sum(qty) as TurnoverLot,  " & _
        '    "sum(price*qty) as TurnoverAmt from view_all_traded  " & _
        '    "group by oid) b on a.oid = b.oid " & _
        '    "left join view_total_order_fees c on a.oid = c.oid " & _
        '    "left join client_master d on c.aid = d.aid " & _
        '    "left join market_master e on c.mkid = e.mkid " & _
        '    "left join ae_master f on c.aeid = f.aeid " & _
        '    "left join currency_master g on g.cuid = a.cuid_chrg " & _
        '    "left join currency_exchange h on h.cuid = a.cuid_chrg and h.cuid_ex = 1 " & _
        '    "where tdate >= '" & lcDateFrm.ToString("yyyy/MM/01") & "' and tdate <= '" & lcDateTo.ToString("yyyy/MM/dd") & "' "
        'lcStrSQL = "and a.cmid = '999' " & _
        '            "group by d.accno, d.name_1 , f.aeno, f.name ,  " & _
        '            "e.name_s , g.name_s , month(tdate),  Year(tdate), h.last " & _
        '            "order by d.accno, e.name_s "

        'Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)
        Dim dt As DataTable = pSrc

        Dim lcDr As DataRow
        Dim lIntPrevMon As Integer = 0
        Dim lIntPrecPrevMon As Integer = 0
        Dim lIntAvg As Integer = 0
        Dim lstrAccNo As String = ""


        For i As Integer = 0 To dt.Rows.Count - 1

            Dim tmpDrs As DataRow() = lcResult.Select("d_exchange = '" & dt.Rows(i).Item("MarketCode") & "'")
            If tmpDrs.Length > 0 Then
                lcDr = tmpDrs(0)

                If lcPrevMonth.Month = dt.Rows(i).Item("TxMonth") AndAlso lcPrevMonth.Year = dt.Rows(i).Item("TxYear") Then
                    tmpDrs(0).Item("d_prev_month_lots") += GFncNoNullValue(dt.Rows(i).Item("TotalLot"))
                    'If i = 0 Then
                    '    tmpDrs(0).Item("d_prev_month_cnt") += 1
                    'Else
                    '    If dt.Rows(i).Item("accno") <> dt.Rows(i - 1).Item("accno") Then
                    '        tmpDrs(0).Item("d_prev_month_cnt") += 1
                    '    End If
                    'End If


                ElseIf lcDateFrm.Month = dt.Rows(i).Item("TxMonth") AndAlso lcDateFrm.Year = dt.Rows(i).Item("TxYear") Then
                    tmpDrs(0).Item("d_prec_prev_month_lots") += GFncNoNullValue(dt.Rows(i).Item("TotalLot"))
                    'tmpDrs(0).Item("d_prec_prev_month_cnt") += 1
                    'If i = 0 Then
                    '    tmpDrs(0).Item("d_prec_prev_month_cnt") += 1
                    'Else
                    '    If dt.Rows(i).Item("accno") <> dt.Rows(i - 1).Item("accno") Then
                    '        tmpDrs(0).Item("d_prec_prev_month_cnt") += 1
                    '    End If
                    'End If
                End If

            Else
                lcDr = lcResult.NewRow()

                lcDr("d_exchange") = dt.Rows(i).Item("MarketCode")
                lcDr("d_average_lots") = 0
                lcDr("d_prev_month_lots") = 0
                lcDr("d_prec_prev_month_lots") = 0
                lcDr("d_average_cnt") = DBNull.Value
                lcDr("d_prev_month_cnt") = 0
                lcDr("d_prec_prev_month_cnt") = 0

                If lcPrevMonth.Month = dt.Rows(i).Item("TxMonth") AndAlso lcPrevMonth.Year = dt.Rows(i).Item("TxYear") Then
                    lcDr("d_prev_month_lots") += GFncNoNullValue(dt.Rows(i).Item("TotalLot"))
                    'lcDr("d_prev_month_cnt") += 1
                ElseIf lcDateFrm.Month = dt.Rows(i).Item("TxMonth") AndAlso lcDateFrm.Year = dt.Rows(i).Item("TxYear") Then
                    lcDr("d_prec_prev_month_lots") += GFncNoNullValue(dt.Rows(i).Item("TotalLot"))
                    'lcDr("d_prec_prev_month_cnt") += 1
                End If

                lcResult.Rows.Add(lcDr)

            End If
        Next
        lstrAccNo = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If lcPrevMonth.Month = dt.Rows(i).Item("TxMonth") AndAlso lcPrevMonth.Year = dt.Rows(i).Item("TxYear") Then
                If lstrAccNo <> dt.Rows(i).Item("accno") Then
                    lIntPrevMon += 1
                    lstrAccNo = dt.Rows(i).Item("accno")
                End If
            End If
        Next
        lstrAccNo = ""
        For i As Integer = 0 To dt.Rows.Count - 1
            If lcDateFrm.Month = dt.Rows(i).Item("TxMonth") AndAlso lcDateFrm.Year = dt.Rows(i).Item("TxYear") Then
                If lstrAccNo <> dt.Rows(i).Item("accno") Then
                    lIntPrecPrevMon += 1
                    lstrAccNo = dt.Rows(i).Item("accno")
                End If
            End If
        Next
        lstrAccNo = ""
        'For i As Integer = 0 To dt.Rows.Count - 1
        '    If lcDateTo.Month = dt.Rows(i).Item("TxMonth") AndAlso lcDateTo.Year = dt.Rows(i).Item("TxYear") Then
        '        If lstrAccNo <> dt.Rows(i).Item("accno") Then
        '            lIntAvg += 1
        '            lstrAccNo = dt.Rows(i).Item("accno")
        '        End If
        '    End If
        'Next

        Dim drs As DataRow() = dt.Select("(TxMonth='" & lcDateFrm.Month & "' AND TxYear='" & lcDateFrm.Year & "') OR (TxMonth='" & lcPrevMonth.Month & "' AND TxYear='" & lcPrevMonth.Year & "')")
        Dim dt_new As DataTable = dt.Clone()
        For i As Integer = 0 To drs.Length - 1
            dt_new.Rows.Add(drs(i).ItemArray)
        Next
        Dim dv As DataTable = dt_new.DefaultView().ToTable(True, "accno")
        lIntAvg = dv.Rows.Count

        For i As Integer = 0 To lcResult.Rows.Count - 1
            If i = 0 Then
                'If lIntPrecPrevMon > lIntPrevMon Then
                '    lcResult.Rows(i).Item("d_average_cnt") = lIntPrecPrevMon
                'Else
                '    lcResult.Rows(i).Item("d_average_cnt") = lIntPrevMon
                'End If
                lcResult.Rows(i).Item("d_prec_prev_month_cnt") = lIntPrecPrevMon
                lcResult.Rows(i).Item("d_prev_month_cnt") = lIntPrevMon
                lcResult.Rows(i).Item("d_average_cnt") = lIntAvg
            End If
            lcResult.Rows(i).Item("d_average_lots") = (lcResult.Rows(i).Item("d_prev_month_lots") + lcResult.Rows(i).Item("d_prec_prev_month_lots")) / 2
            'lcResult.Rows(i).Item("d_average_cnt") = (lcResult.Rows(i).Item("d_prev_month_cnt") + lcResult.Rows(i).Item("d_prec_prev_month_cnt")) / 2
        Next

        Dim lcSortedDv As DataView = lcResult.DefaultView
        lcSortedDv.Sort = "d_exchange"

        Return lcSortedDv.ToTable()
    End Function

End Class
