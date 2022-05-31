Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRptTransAdj
    Dim clsRpt As New ClsReports

    Protected Friend Sub GetLatestDate(ByRef inYr As String, ByRef inMon As String)
        Dim query As String = " select max(a.txmonth) as txmonth  from (select max(txmonth)as txmonth from comm_adj_f " & _
                                            "union select max(txmonth)as txmonth from comm_adj_s " & _
                                            "union select max(txmonth)as txmonth from comm_trade_f " & _
                                            "union select max(txmonth)as txmonth from view_comm_trade_s ) a"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If dt.Rows.Count > 0 Then
            inYr = CInt(dt.Rows(0).Item(0).ToString.Substring(0, 4)).ToString
            inMon = CInt(dt.Rows(0).Item(0).ToString.Substring(4, 2)).ToString
        Else
            inYr = Now.Year
            inMon = Now.Month - 1
        End If
    End Sub

    Protected Friend Function PrintTranSRpt(ByVal inTxmonth As String) As ReportClass
        Dim rpt As New RptTransAdjS

        Dim GridDT As New DataTable
        InitTranSDT(GridDT)
        'Dim query As String = "select * from comm_adj_s  where txmonth ='" & inTxmonth & "'"
        Dim query As String = "select accname, accno, acct, Adj_Action, ae, aename, aeno, comm_rate, commission, " & _
                                "grossamt, lastupddate, lastupduser, oid, price, qty, stk, stkname, stkno, tdate, " & _
                                "case when tradetype = '4' then 'Internet' else 'Normal' end as tradetype, txmonth, " & _
                                " rebate=0 " & _
                                "from comm_adj_s  where txmonth ='" & inTxmonth & "'"
        Dim AdjDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        'query = "select * from view_comm_trade_s where txmonth ='" & inTxmonth & "' order by tdate desc, oid asc "
        query = "select txmonth, aeno, aename, accno, accname, tdate, oid, stkno, stkname, avgprice, qty, grossamt, " & _
                    "commission, comm_rate, case when tradetype = '4' then 'Internet' else 'Normal' end as tradetype, " & _
                    "rebate from view_comm_trade_s where txmonth ='" & inTxmonth & "' order by tdate desc, oid asc "
        Dim ViewDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select ae_no, isnull(ae_name_s,'') as  aename from comm_ae_master"
        Dim AeDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select acc_no,  isnull(acc_name_s, '') as acname from comm_acc_master"
        Dim AcDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        Dim AdjDr() As DataRow
        Dim GridDr As DataRow
        Dim AeDr() As DataRow
        Dim AcDr() As DataRow

        For Each dr As DataRow In ViewDT.Rows
            AdjDr = AdjDT.Select("oid ='" & dr.Item("oid") & "' and adj_action<>'A' ")
            If AdjDr.Length > 0 Then
                If AdjDr(0).Item("adj_action") <> "D" Then
                    'show adj records
                    GridDr = GridDT.NewRow
                    GridDr.Item("oid") = AdjDr(0).Item("oid")
                    GridDr.Item("txmonth") = AdjDr(0).Item("txmonth")
                    GridDr.Item("aeno") = AdjDr(0).Item("aeno")
                    GridDr.Item("accno") = AdjDr(0).Item("accno")
                    GridDr.Item("tdate") = AdjDr(0).Item("tdate")
                    GridDr.Item("stk") = AdjDr(0).Item("stk")
                    GridDr.Item("avgprice") = AdjDr(0).Item("price")
                    GridDr.Item("qty") = AdjDr(0).Item("qty")
                    GridDr.Item("grossamt") = AdjDr(0).Item("grossamt")
                    GridDr.Item("comm") = AdjDr(0).Item("commission")
                    GridDr.Item("comm_rate") = AdjDr(0).Item("comm_rate")
                    GridDr.Item("ttype") = GetTradeType(AdjDr(0).Item("tradetype"))
                    'GridDr.Item("adj_action") = "Adjusted"
                    GridDr.Item("Rebate") = AdjDr(0).Item("rebate")

                    AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        GridDr.Item("aename") = AdjDr(0).Item("ae").ToString.Trim
                    End If
                    AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        GridDr.Item("accname") = AdjDr(0).Item("acct").ToString.Trim
                    End If
                    GridDr.Item("stkname") = AdjDr(0).Item("stkname")
                    GridDT.Rows.Add(GridDr)
                End If
            Else
                'show unAdj record
                GridDr = GridDT.NewRow
                GridDr.Item("oid") = dr.Item("oid")
                GridDr.Item("txmonth") = dr.Item("txmonth")
                GridDr.Item("aeno") = dr.Item("aeno").ToString.Trim
                GridDr.Item("accno") = dr.Item("accno").ToString.Trim
                GridDr.Item("tdate") = dr.Item("tdate")
                GridDr.Item("stk") = dr.Item("stkno")
                GridDr.Item("avgprice") = dr.Item("avgprice")
                GridDr.Item("qty") = dr.Item("qty")
                GridDr.Item("grossamt") = dr.Item("grossamt")
                GridDr.Item("comm") = dr.Item("commission")
                GridDr.Item("comm_rate") = dr.Item("comm_rate")
                GridDr.Item("ttype") = dr.Item("tradetype")
                GridDr.Item("Rebate") = dr.Item("Rebate")
                'GridDr.Item("adj_action") = ""
                AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
                If AeDr.Length > 0 Then
                    GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                Else
                    GridDr.Item("aename") = dr.Item("aename").ToString.Trim
                End If
                AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
                If AcDr.Length > 0 Then
                    GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
                Else
                    GridDr.Item("accname") = dr.Item("accname").ToString.Trim
                End If
                GridDr.Item("stkname") = dr.Item("stkname")
                GridDT.Rows.Add(GridDr)
            End If

        Next
        AdjDr = AdjDT.Select("adj_action='A'")
        For Each dr As DataRow In AdjDr
            GridDr = GridDT.NewRow
            GridDr.Item("oid") = dr.Item("oid")
            GridDr.Item("txmonth") = dr.Item("txmonth")
            GridDr.Item("aeno") = dr.Item("aeno")
            GridDr.Item("accno") = dr.Item("accno")
            GridDr.Item("tdate") = dr.Item("tdate")
            GridDr.Item("stk") = dr.Item("stk")
            GridDr.Item("avgprice") = dr.Item("price")
            GridDr.Item("qty") = dr.Item("qty")
            GridDr.Item("grossamt") = dr.Item("grossamt")
            GridDr.Item("comm") = dr.Item("commission")
            GridDr.Item("comm_rate") = dr.Item("comm_rate")
            GridDr.Item("ttype") = GetTradeType(dr.Item("tradetype"))
            GridDr.Item("Rebate") = dr.Item("rebate")
            'GridDr.Item("adj_action") = "New"
            AeDr = AeDT.Select("ae_no='" & GridDr.Item("aeno") & "'")
            If AeDr.Length > 0 Then
                GridDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
            Else
                GridDr.Item("aename") = dr.Item("ae").ToString.Trim
            End If
            AcDr = AcDT.Select("acc_no='" & GridDr.Item("accno") & "'")
            If AcDr.Length > 0 Then
                GridDr.Item("accname") = AcDr(0).Item("acname").ToString.Trim
            Else
                GridDr.Item("accname") = dr.Item("acct").ToString.Trim
            End If
            'GridDr.Item("aename") = GetAeName(GFncNoNullString(dr.Item("aeno")))
            'GridDr.Item("accname") = GetAcName(GFncNoNullString(dr.Item("accno")))
            GridDr.Item("stkname") = dr.Item("stkname")
            GridDT.Rows.Add(GridDr)
        Next

        rpt.SetDataSource(GridDT)
        clsRpt.AddParam(rpt, "paraTDate", inTxmonth)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))

        Return rpt
    End Function

    Private Sub InitTranSDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.String")
        'Column.ColumnName = "adj_action"
        'DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "oid"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "txmonth"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aeno"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aename"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accno"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accname"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "tdate"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "stk"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "stkname"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "avgprice"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "qty"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "grossamt"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "comm_rate"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ttype"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "Rebate"
        DT.Columns.Add(Column)
    End Sub

    Protected Friend Function PrintTranFRpt(ByVal inMonth As String) As ReportClass
        Dim rpt As New RptTransAdjF
        Dim RptDT As New DataTable
        Dim AdjDr() As DataRow
        Dim AeDr() As DataRow
        Dim AcDr() As DataRow
        Dim TradeDr As DataRow
        InitAdjFDT(RptDT)

        'Dim query As String = "select * from comm_adj_f where 1=1 and txmonth='" & inMonth & "' order by accno asc, mth asc"
        Dim query As String = "select accname1, accname2, accno, adj_action, ae_rebate_dd, ae_rebate_mm, aename, aeno, " & _
                                "call_put, ccy, commission_dd, commission_mm, commod, day_commission, day_dd, day_mm, " & _
                                "exchange_fee_dd, exchange_fee_mm, i_day_commission, i_day_mm, i_night_commission, " & _
                                "i_night_mm, lastupddate, lastupduser, marketname, mth, night_commission, night_dd, " & _
                                "night_mm, oid, recordID, s_price_str, strike, tg_dd, tg_mm, " & _
                                "case when tradetype = '3' then 'Internet' else 'Normal' end as tradetype, " & _
                                "txmonth from comm_adj_f where 1=1 and txmonth='" & inMonth & "' order by accno asc, mth asc"
        Dim AdjDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        'query = "select * from comm_trade_f where 1=1 and txmonth='" & inMonth & "'  order by txmonth desc, aeno asc, accno asc"
        query = "select accname1, accname2, accno, ae_rebate_dd, ae_rebate_mm, aename, aeno, call_put, ccy, " & _
                "commission_dd, commission_mm, commod, day_commission, day_dd, day_mm, exchange_fee_dd, exchange_fee_mm, " & _
                "i_day_commission, i_day_mm, i_night_commission, i_night_mm, lastupddate, lastupduser, marketname, mth, " & _
                "night_commission, night_dd, night_mm, oid, s_price_str, strike, tg_dd, tg_mm, " & _
                "case when tradetype = '3' then 'Internet' else 'Normal' end as tradetype, txmonth " & _
                "from comm_trade_f where txmonth='" & inMonth & "'  order by txmonth desc, aeno asc, accno asc"
        Dim OrgDt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select ae_no, isnull(ae_name, isnull(ae_name_f, '')) as aename from comm_ae_master"
        Dim AeDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        query = "select acc_no, isnull(acc_name, isnull(acc_name_f, '')) as acname from comm_acc_master"
        Dim AcDT As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)

        For Each dr As DataRow In OrgDt.Rows
            AdjDr = AdjDT.Select("oid =" & dr.Item("oid"))
            If AdjDr.Length > 0 Then
                If GFncNoNullString(AdjDr(0).Item("adj_action")) = "M" Then
                    TradeDr = RptDT.NewRow
                    'TradeDr.Item("adj_action") = "Adjusted"
                    TradeDr.Item("txmonth") = AdjDr(0).Item("txmonth").ToString.Trim
                    TradeDr.Item("aeno") = AdjDr(0).Item("aeno").ToString.Trim
                    AeDr = AeDT.Select("ae_no='" & TradeDr.Item("aeno") & "'")
                    If AeDr.Length > 0 Then
                        TradeDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                    Else
                        TradeDr.Item("aename") = AdjDr(0).Item("aename").ToString.Trim
                    End If
                    TradeDr.Item("accno") = AdjDr(0).Item("accno").ToString.Trim
                    AcDr = AcDT.Select("acc_no='" & TradeDr.Item("accno") & "'")
                    If AcDr.Length > 0 Then
                        TradeDr.Item("accname1") = AcDr(0).Item("acname").ToString.Trim
                    Else
                        TradeDr.Item("accname1") = AdjDr(0).Item("accname1").ToString.Trim
                    End If

                    TradeDr.Item("accname2") = AdjDr(0).Item("accname2").ToString.Trim
                    TradeDr.Item("commod") = AdjDr(0).Item("commod").ToString.Trim
                    TradeDr.Item("mth") = AdjDr(0).Item("mth").ToString.Trim
                    TradeDr.Item("call_put") = ReturnCallPutString(AdjDr(0).Item("call_put").ToString.Trim)
                    TradeDr.Item("strike") = AdjDr(0).Item("strike").ToString.Trim
                    TradeDr.Item("s_price_str") = AdjDr(0).Item("s_price_str").ToString.Trim
                    TradeDr.Item("commission_mm") = AdjDr(0).Item("commission_mm")
                    TradeDr.Item("exchange_fee_mm") = AdjDr(0).Item("exchange_fee_mm")
                    TradeDr.Item("ae_rebate_mm") = AdjDr(0).Item("ae_rebate_mm")
                    TradeDr.Item("day_mm") = AdjDr(0).Item("day_mm")
                    TradeDr.Item("night_mm") = AdjDr(0).Item("night_mm")
                    TradeDr.Item("tg_mm") = AdjDr(0).Item("tg_mm")
                    TradeDr.Item("ccy") = AdjDr(0).Item("ccy").ToString.Trim
                    TradeDr.Item("marketname") = AdjDr(0).Item("marketname").ToString.Trim
                    'TradeDr.Item("commission_dd") = AdjDr(0).Item("commission_dd")
                    'TradeDr.Item("exchange_fee_dd") = AdjDr(0).Item("exchange_fee_dd")
                    'TradeDr.Item("ae_rebate_dd") = AdjDr(0).Item("ae_rebate_dd")
                    'TradeDr.Item("day_dd") = AdjDr(0).Item("day_dd")
                    'TradeDr.Item("night_dd") = AdjDr(0).Item("night_dd")
                    'TradeDr.Item("tg_dd") = AdjDr(0).Item("tg_dd")
                    'TradeDr.Item("recordID") = AdjDr(0).Item("recordID")
                    TradeDr.Item("tradetype") = AdjDr(0).Item("tradetype").ToString.Trim
                    RptDT.Rows.Add(TradeDr)
                End If
            Else
                TradeDr = RptDT.NewRow
                TradeDr.Item("txmonth") = dr.Item("txmonth").ToString.Trim
                TradeDr.Item("aeno") = dr.Item("aeno").ToString.Trim
                AeDr = AeDT.Select("ae_no='" & TradeDr.Item("aeno") & "'")
                If AeDr.Length > 0 Then
                    TradeDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
                Else
                    TradeDr.Item("aename") = dr.Item("aename").ToString.Trim
                End If

                TradeDr.Item("accno") = dr.Item("accno").ToString.Trim
                AcDr = AcDT.Select("acc_no='" & TradeDr.Item("accno") & "'")
                If AcDr.Length > 0 Then
                    TradeDr.Item("accname1") = AcDr(0).Item("acname").ToString.Trim
                Else

                    TradeDr.Item("accname1") = dr.Item("accname1").ToString.Trim
                End If

                TradeDr.Item("accname2") = dr.Item("accname2").ToString.Trim
                TradeDr.Item("commod") = dr.Item("commod").ToString.Trim
                TradeDr.Item("mth") = dr.Item("mth").ToString.Trim
                TradeDr.Item("call_put") = ReturnCallPutString(dr.Item("call_put").ToString.Trim)
                TradeDr.Item("strike") = dr.Item("strike").ToString.Trim
                TradeDr.Item("s_price_str") = dr.Item("s_price_str").ToString.Trim
                TradeDr.Item("commission_mm") = dr.Item("commission_mm")
                TradeDr.Item("exchange_fee_mm") = dr.Item("exchange_fee_mm")
                TradeDr.Item("ae_rebate_mm") = dr.Item("ae_rebate_mm")
                TradeDr.Item("day_mm") = dr.Item("day_mm")
                TradeDr.Item("night_mm") = dr.Item("night_mm")
                TradeDr.Item("tg_mm") = dr.Item("tg_mm")
                TradeDr.Item("ccy") = dr.Item("ccy").ToString.Trim
                TradeDr.Item("marketname") = dr.Item("marketname").ToString.Trim
                'TradeDr.Item("commission_dd") = dr.Item("commission_dd")
                'TradeDr.Item("exchange_fee_dd") = dr.Item("exchange_fee_dd")
                'TradeDr.Item("ae_rebate_dd") = dr.Item("ae_rebate_dd")
                'TradeDr.Item("day_dd") = dr.Item("day_dd").ToString.Trim
                'TradeDr.Item("night_dd") = dr.Item("night_dd").ToString.Trim
                'TradeDr.Item("tg_dd") = dr.Item("tg_dd").ToString.Trim
                'TradeDr.Item("recordID") = -1
                TradeDr.Item("tradetype") = dr.Item("tradetype").ToString.Trim
                RptDT.Rows.Add(TradeDr)
            End If
        Next
        AdjDr = AdjDT.Select("oid =0")
        For Each dr As DataRow In AdjDr
            TradeDr = RptDT.NewRow
            'If dr.Item("adj_action") = "A" Then
            '    TradeDr.Item("adj_action") = "New"
            'End If
            TradeDr.Item("txmonth") = dr.Item("txmonth").ToString.Trim
            TradeDr.Item("aeno") = dr.Item("aeno").ToString.Trim
            AeDr = AeDT.Select("ae_no='" & TradeDr.Item("aeno") & "'")
            If AeDr.Length > 0 Then
                TradeDr.Item("aename") = AeDr(0).Item("aename").ToString.Trim
            Else
                TradeDr.Item("aename") = dr.Item("aename").ToString.Trim
            End If

            TradeDr.Item("accno") = dr.Item("accno").ToString.Trim
            AcDr = AcDT.Select("acc_no='" & TradeDr.Item("accno") & "'")
            If AcDr.Length > 0 Then
                TradeDr.Item("accname1") = AcDr(0).Item("acname").ToString.Trim
            Else

                TradeDr.Item("accname1") = dr.Item("accname1").ToString.Trim
            End If
            TradeDr.Item("accname2") = dr.Item("accname2").ToString.Trim
            TradeDr.Item("commod") = dr.Item("commod").ToString.Trim
            TradeDr.Item("mth") = dr.Item("mth").ToString.Trim
            TradeDr.Item("call_put") = ReturnCallPutString(dr.Item("call_put").ToString.Trim)
            TradeDr.Item("strike") = dr.Item("strike").ToString.Trim
            TradeDr.Item("s_price_str") = dr.Item("s_price_str").ToString.Trim
            TradeDr.Item("commission_mm") = dr.Item("commission_mm")
            TradeDr.Item("exchange_fee_mm") = dr.Item("exchange_fee_mm")
            TradeDr.Item("ae_rebate_mm") = dr.Item("ae_rebate_mm")
            TradeDr.Item("day_mm") = dr.Item("day_mm")
            TradeDr.Item("night_mm") = dr.Item("night_mm")
            TradeDr.Item("tg_mm") = dr.Item("tg_mm")
            TradeDr.Item("ccy") = dr.Item("ccy").ToString.Trim
            TradeDr.Item("marketname") = dr.Item("marketname").ToString.Trim
            'TradeDr.Item("commission_dd") = dr.Item("commission_dd")
            'TradeDr.Item("exchange_fee_dd") = dr.Item("exchange_fee_dd")
            'TradeDr.Item("ae_rebate_dd") = dr.Item("ae_rebate_dd")
            'TradeDr.Item("day_dd") = dr.Item("day_dd").ToString.Trim
            'TradeDr.Item("night_dd") = dr.Item("night_dd").ToString.Trim
            'TradeDr.Item("tg_dd") = dr.Item("tg_dd").ToString.Trim
            'TradeDr.Item("recordID") = dr.Item("recordID").ToString.Trim
            TradeDr.Item("tradetype") = dr.Item("tradetype").ToString.Trim
            RptDT.Rows.Add(TradeDr)
        Next

        rpt.SetDataSource(RptDT)
        clsRpt.AddParam(rpt, "paraTDate", inMonth)
        clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
        Return rpt
    End Function

    Private Sub InitAdjFDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "txmonth"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aeno"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "aename"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accno"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accname1"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "accname2"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "commod"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "mth"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "call_put"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "strike"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "s_price_str"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "commission_mm"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "exchange_fee_mm"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "ae_rebate_mm"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "day_mm"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "night_mm"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Int32")
        Column.ColumnName = "tg_mm"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "ccy"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "marketname"
        DT.Columns.Add(Column)

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.String")
        'Column.ColumnName = "oid"
        'DT.Columns.Add(Column)

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.Decimal")
        'Column.ColumnName = "commission_dd"
        'DT.Columns.Add(Column)

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.Decimal")
        'Column.ColumnName = "exchange_fee_dd"
        'DT.Columns.Add(Column)

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.Int32")
        'Column.ColumnName = "ae_rebate_dd"
        'DT.Columns.Add(Column)

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.Int32")
        'Column.ColumnName = "day_dd"
        'DT.Columns.Add(Column)

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.Int32")
        'Column.ColumnName = "night_dd"
        'DT.Columns.Add(Column)

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.Int32")
        'Column.ColumnName = "tg_dd"
        'DT.Columns.Add(Column)

        'Column = New DataColumn
        'Column.DataType = System.Type.GetType("System.Int32")
        'Column.ColumnName = "recordID"
        'DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "tradetype"
        DT.Columns.Add(Column)
    End Sub

    Private Function GetTradeType(ByVal inVal As String) As String
        'If inVal = "4" Then
        '    Return "I-trade"
        'Else
        '    Return "Normal"
        'End If
        Dim query As String = " select misc_desc from misc_master where misc_type='TranAdjSTType' and misc_code='" & inVal & "'"
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, query).Tables(0)
        If dt.Rows.Count > 0 Then
            Return dt.Rows(0).Item(0)
        Else
            Return ""
        End If
    End Function

    Private Function ReturnCallPutString(ByVal inCall As String) As String
        Select Case inCall
            Case "2"
                Return "Call"
            Case "1"
                Return "Put"
            Case Else
                Return ""
        End Select
    End Function

End Class
