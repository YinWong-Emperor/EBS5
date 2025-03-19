Public Class clsRptTradeHistory

    'gen report for certain client
    Protected Friend Function genRptDt(ByVal clientCode As String) As DataTable
        'Dim strSQL As String = "select trade_date, bs, stock_code, rtrim(stkno) as stkno, " & _
        '"  qty, currency_code_set, price, (qty * price) as consideration, client_code " & _
        '" from " & GStrG2BSDB & ".dbo.view_ER_client_trade_namt_with_fee where client_code = '" & _
        'clientCode.Replace("'", "''") & "'"

        Dim strSQL As String = "select b.trade_date, b.bs, b.stock_code, rtrim(b.stkno) as stkno, " & _
                                "case when a.oid is null then b.qty else a.qty end as qty, " & _
                                "b.currency_code_set, " & _
                                "case when a.oid is null then b.price else a.price end as price, " & _
                                "(case when a.oid is null then b.qty else a.qty end " & _
                                "* case when a.oid is null then b.price else a.price end) as consideration " & _
                                "from " & GStrG2BSDB & ".dbo.view_ER_client_trade_namt_with_fee b " & _
                                "left outer join ( " & _
                                "select * from " & GStrG2BSDB & ".dbo.histcltraded " & _
                                "union all " & _
                                "select  * from " & GStrG2BSDB & ".dbo.daycltraded) a " & _
                                "on a.oid = b.oid " & _
                                "where client_code = '" & clientCode.Replace("'", "''") & "'"


        Dim dtSet As DataSet = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        Return dt

    End Function

    'gen report for all
    Protected Friend Function genRptDt_Range(ByVal clientCodeList As String) As DataTable
        'Dim strSQL As String = "select trade_date, bs, stock_code, rtrim(stkno) as stkno, " & _
        '"  qty, currency_code_set, price, (qty * price) as consideration, client_code " & _
        '" from " & GStrG2BSDB & ".dbo.view_ER_client_trade_namt_with_fee where client_code in (" & _
        'clientCodeList & ") order by client_code"

        Dim strSQL As String = "select b.trade_date, b.bs, b.stock_code, rtrim(b.stkno) as stkno, " & _
                                "case when a.oid is null then b.qty else a.qty end as qty, " & _
                                "b.currency_code_set, " & _
                                "case when a.oid is null then b.price else a.price end as price, " & _
                                "(case when a.oid is null then b.qty else a.qty end " & _
                                "* case when a.oid is null then b.price else a.price end) as consideration, b.client_code " & _
                                "from " & GStrG2BSDB & ".dbo.view_ER_client_trade_namt_with_fee b " & _
                                "left outer join ( " & _
                                "select * from " & GStrG2BSDB & ".dbo.histcltraded " & _
                                "union all " & _
                                "select  * from " & GStrG2BSDB & ".dbo.daycltradeds) a " & _
                                "on a.oid = b.oid " & _
                                "where client_code in (" & clientCodeList & ") order by client_code"

        Dim dtSet As DataSet = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        Return dt

    End Function

    Protected Friend Function getStockMaster() As DataTable
        Dim strSQL As String = "select *, rtrim(stkno) as stock_no from " & GStrG2BSDB & ".dbo.stock_master order by stkno "

        Dim dtSet As DataSet = GFncRtnDS(GSCnSqlConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        Return dt

    End Function

    Protected Friend Function getPosition(ByVal clientCode As String) As DataTable
        Dim strSQL As String = "select * from STPortfolio " & _
                    " where clt_code = '" & clientCode.Replace("'", "''") & "'" & _
                    " order by CLT_CODE, stk_code"

        Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        Return dt

    End Function

    Protected Friend Function getPosition_Range(ByVal clientCodeList As String) As DataTable
        Dim strSQL As String = "select * from STPortfolio " & _
                    " where clt_code in (" & clientCodeList & ")" & _
                    " order by CLT_CODE, stk_code"

        Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        Return dt

    End Function

    Protected Friend Function getClientName(ByVal clientCode As String) As String
        Dim strSQL As String = "select CLT_NAME" & _
        " from STCLTMASTER where CLT_CODE='" & clientCode & "'"

        Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)
        Dim lstrName As String = ""

        Dim dt As DataTable = Nothing

        If dtSet.Tables(0).Rows.Count > 0 Then
            dt = dtSet.Tables(0)
            lstrName = dt.Rows(0).Item("CLT_NAME").ToString
        End If

        Return lstrName

    End Function

    Protected Friend Function getLedgerBalance(ByVal clientCode As String) As String
        Dim result As String = ""

        Dim strSQL As String = "select DR_BAL, CR_BAL, CLT_CODE" & _
                    " from STCLTMASTER where CLT_CODE ='" & clientCode & "'"

        Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        If dt.Rows(0).Item("CR_BAL") > 0 Then
            result = dt.Rows(0).Item("CR_BAL").ToString
        ElseIf dt.Rows(0).Item("CR_BAL") = 0 AndAlso dt.Rows(0).Item("DR_BAL") > 0 Then
            result = (dt.Rows(0).Item("DR_BAL") * -1).ToString
        End If

        Return result

        'Return dt.Rows(0).Item("AVAIL_BAL").ToString

    End Function

    Protected Friend Function getLedgerBalance_Range(ByVal clientCodeList As String) As DataTable
        Dim strSQL As String = "select DR_BAL, CR_BAL, CLT_CODE" & _
                    " from STCLTMASTER where CLT_CODE in (" & clientCodeList & ")" & _
                    " order by CLT_CODE"

        Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        Return dt

    End Function


    'Protected Friend Function getClientCode() As DataTable
    '    Dim strSQL As String = "select distinct(CLT_CODE) from STCLTMASTER order by CLT_CODE"

    '    Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)

    '    Dim dt As DataTable = Nothing

    '    If dtSet IsNot Nothing Then
    '        dt = dtSet.Tables(0)
    '    End If

    '    Return dt

    'End Function

    Protected Friend Function getClientCode(Optional ByVal clinetCodeStart As String = "", Optional ByVal clientCodeEnd As String = "", Optional ByVal runCode As String = "") As DataTable
        Dim strSQL As String = ""
        If (clinetCodeStart = "" AndAlso clientCodeEnd = "" AndAlso runCode = "") Then
            strSQL = "select distinct(CLT_CODE) from STCLTMASTER order by CLT_CODE"
        ElseIf (clinetCodeStart <> "" AndAlso clientCodeEnd <> "" AndAlso runCode = "") Then
            strSQL = "select distinct(CLT_CODE) from STCLTMASTER where CLT_CODE>='" & clinetCodeStart & "' and CLT_CODE<='" & clientCodeEnd & "' order by CLT_CODE"
        ElseIf (clinetCodeStart = "" AndAlso clientCodeEnd = "" AndAlso runCode <> "") Then
            strSQL = "select distinct(CLT_CODE) from STCLTMASTER where RUN_CODE='" & runCode & "' order by CLT_CODE"
        ElseIf (clinetCodeStart <> "" AndAlso clientCodeEnd <> "" AndAlso runCode <> "") Then
            strSQL = "select distinct(CLT_CODE) from STCLTMASTER where CLT_CODE>='" & clinetCodeStart & "' and CLT_CODE<='" & clientCodeEnd & "' and RUN_CODE='" & runCode & "' order by CLT_CODE"
        End If

        Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)

        Dim dt As DataTable = Nothing

        If dtSet IsNot Nothing Then
            dt = dtSet.Tables(0)
        End If

        Return dt

    End Function

End Class
