Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports System.Globalization

Public Class clsBankList

    Protected Friend Function FncGetRepledged() As DataTable
        'Dim str As String = "SELECT DISTINCT mm.name AS MarketNm, cm.name_s AS Currency, sm.stkno, dm.code AS DepotCD, SUM(DepotQTY) AS DepotQTY, " & _
        '    "SUM(StkTradeUnset) AS StkTradeUnset, SUM(StkUnrealized) AS StkUnrealized, ISNULL(sm.price, 0) AS MarketPrice, sm.so3, sm.price_dp, " & _
        '    "sm.qty_dp FROM " & GStrG2BSDB & ".dbo.view_rpt_daily_stk_loc v, " & GStrG2BSDB & ".dbo.market_master mm, " & GStrG2BSDB & _
        '    ".dbo.stock_master sm, " & GStrG2BSDB & ".dbo.depot_master dm, " & GStrG2BSDB & ".dbo.currency_master cm WHERE " & _
        '    "mm.mkid = v.mkid AND sm.sid = v.sid AND dm.dpid = v.dpid AND cm.cuid = sm.cuid AND (DepotQTY <> 0 OR StkTradeUnset <> 0 OR " & _
        '    "StkUnrealized <> 0) and dm.code in (select distinct d_bank from banklist) and sm.stkno in (select distinct d_stock from banklist) " & _
        '    "GROUP BY mm.name, cm.name_s, sm.stkno, sm.price, sm.so3, sm.price_dp, sm.qty_dp"
        'Dim str As String = "SELECT DISTINCT mm.name AS MarketNm, cm.name_s AS Currency, sm.stkno, dm.code AS DepotCD, SUM(DepotQTY) AS DepotQTY, " & _
        '    "SUM(StkTradeUnset) AS StkTradeUnset, SUM(StkUnrealized) AS StkUnrealized, ISNULL(sm.price, 0) AS MarketPrice, sm.so3, sm.price_dp, " & _
        '    "sm.qty_dp FROM " & GStrG2BSDB & ".dbo.view_rpt_daily_stk_loc v, " & GStrG2BSDB & ".dbo.market_master mm, " & GStrG2BSDB & _
        '    ".dbo.stock_master sm, " & GStrG2BSDB & ".dbo.depot_master dm, " & GStrG2BSDB & ".dbo.currency_master cm WHERE " & _
        '    "mm.mkid = v.mkid AND sm.sid = v.sid AND dm.dpid = v.dpid AND cm.cuid = sm.cuid AND (DepotQTY <> 0 OR StkTradeUnset <> 0 OR " & _
        '    "StkUnrealized <> 0) GROUP BY mm.name, cm.name_s, sm.stkno, sm.price, sm.so3, sm.price_dp, sm.qty_dp, dm.code order by sm.stkno"
        Dim str As String = "SELECT DISTINCT mm.name AS MarketNm, cm.name_s AS Currency, sm.stkno, dm.code AS DepotCD, SUM(DepotQTY) AS DepotQTY, " & _
                   "SUM(StkTradeUnset) AS StkTradeUnset, SUM(StkUnrealized) AS StkUnrealized, ISNULL(sm.price, 0) AS MarketPrice, sm.so3, sm.price_dp, " & _
                   "sm.qty_dp FROM " & GStrG2BSDB & ".dbo.view_rpt_daily_stk_loc v, " & GStrG2BSDB & ".dbo.market_master mm, " & GStrG2BSDB & _
                   ".dbo.stock_master sm, " & GStrG2BSDB & ".dbo.depot_master dm, " & GStrG2BSDB & ".dbo.currency_master cm WHERE " & _
                   "mm.mkid = v.mkid AND sm.sid = v.sid AND dm.dpid = v.dpid AND cm.cuid = sm.cuid AND (DepotQTY <> 0 OR StkTradeUnset <> 0 OR " & _
                   "StkUnrealized <> 0) GROUP BY mm.name, cm.name_s, sm.stkno, sm.price, sm.so3, sm.price_dp, sm.qty_dp, dm.code order by sm.stkno"


        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function

    Protected Friend Function FncSearchBank(ByVal bank As String, ByVal stock As String) As DataTable
        Dim str As String = "select distinct d_bank, d_bank_name from BankList where 1 = 1 "
        If bank <> "" Then
            str &= "and d_bank like '%" & bank & "%' "
        End If
        If stock <> "" Then
            str &= "and d_stock like '%" & stock & "%' "
        End If
        str &= "order by d_bank"
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function

    Protected Friend Function FncSearchStock(ByVal bank As String) As DataTable
        Dim str As String = "select d_seq, d_stock, d_ratio from BankList where d_bank = '" & bank & "' order by d_stock"
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function

    Protected Friend Function FncGetBank() As DataTable
        Return GFncRtnDS(GSCnSqlConn, "select distinct d_bank from BankList order by d_bank").Tables(0)
    End Function

    Protected Friend Function FncGetStock() As DataTable
        'Return GFncRtnDS(GSCnLiqConn, "select distinct a.stk_code from stportfolio a left join stcltmaster b on a.clt_code = b.clt_code where " & _
        '    "b.clt_type = 'M' order by a.stk_code").Tables(0)
        Return GFncRtnDS(GSCnLiqConn, "select distinct stk_code from stportfolio order by stk_code").Tables(0)
    End Function

    Protected Friend Function FncGetStock2() As DataTable
        Dim str As String = "select distinct a.stk_code, max(c.date_ex) as date_ex from stportfolio a left join stcltmaster b on " & _
            "a.clt_code = b.clt_code inner join " & GStrG2BSDB & ".dbo.stock_master d on d.stkno = a.stk_code inner join " & GStrG2BSDB & _
            ".dbo.distribut_diary c on d.mkid = c.mkid and d.sid = c.sid where b.clt_type = 'M' and a.stk_code in (select distinct d_stock from " & _
            GStrConDB & ".dbo.BankList) and (b.cr_limit < 0 or b.cr_limit > 2) and a.net_market_value > 0 group by a.stk_code order by a.stk_code"
        Return GFncRtnDS(GSCnLiqConn, str).Tables(0)
    End Function

    Protected Friend Function FncGetBank2(ByVal stk As String) As DataTable
        Return GFncRtnDS(GSCnSqlConn, "select distinct d_bank from BankList where d_stock = '" & stk & "'").Tables(0)
    End Function

    Protected Friend Function FncGetMarketValue(ByVal stock As String, ByVal rdt As DataTable) As DataTable
        Dim bankDt As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct d_bank from banklist order by d_bank").Tables(0)
        Dim bankStr As String = ""
        For Each dr As DataRow In bankDt.Rows
            bankStr &= GFncNoNullString(dr("d_bank")).Trim & ", "
        Next
        bankStr = bankStr.Substring(0, bankStr.Length - 2)
        Dim str As String = "select a.stk_code, sum(a.net_qty) as qty, sum(a.net_market_value) as mktValue, sum(a.net_qty) as availableQty from " & _
            "stportfolio a left join stcltmaster b on a.clt_code = b.clt_code where b.clt_type = 'M' and a.net_market_value > 0 and " & _
            "a.stk_code = '" & stock & "' group by a.stk_code order by a.stk_code "
        Dim dt As DataTable = GFncRtnDS(GSCnLiqConn, str).Tables(0)
        For Each rdr As DataRow In rdt.Rows
            Dim stk As String = GFncNoNullString(rdr("stkno")).Trim
            Dim dCode As String = GFncNoNullString(rdr("DepotCD")).Trim
            If bankStr.Contains(dCode) Then
                For Each dr As DataRow In dt.Rows
                    If GFncNoNullString(dr("stk_code")).Trim = stk Then
                        dr("availableQty") = GFncNoNullValue(dr("availableQty")) - GFncNoNullValue(rdr("DepotQTY"))
                        Exit For
                    End If
                Next
            End If
        Next
        str = "select stk_code, sum(qty) as qty from repledged_stock where d_date = '" & Format(GDteTradeDate, "yyyy/MM/dd") & "' group by stk_code order by stk_code"
        Dim repledgeDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        For Each dr As DataRow In dt.Rows
            Dim stk As String = GFncNoNullString(dr("stk_code")).Trim
            For Each rdr As DataRow In repledgeDt.Rows
                If GFncNoNullString(rdr("stk_code")).Trim = stk Then
                    dr("availableQty") = GFncNoNullValue(dr("qty")) - GFncNoNullValue(rdr("qty"))
                    Exit For
                End If
            Next
        Next
        Return dt
    End Function

    Protected Friend Function FncGetRate(ByVal bank As String, ByVal stk As String) As DataTable
        Return GFncRtnDS(GSCnSqlConn, "select d_ratio from banklist where d_bank = '" & bank & "' and d_stock = '" & stk & "'").Tables(0)
    End Function

    Protected Friend Function FncCheckExist(ByVal bank As String, ByVal stock As String, Optional ByVal id As Integer = -1) As Boolean
        Dim str As String = "select * from BankList where d_bank = '" & bank & "' and d_stock = '" & stock & "'"
        If id <> -1 Then
            str &= " and d_seq <> " & id
        End If
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        If dt.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Protected Friend Function FncAdd(ByVal bank As String, ByVal name As String, ByVal stock As String, ByVal ratio As Double) As Integer
        Dim str As String = "insert into BankList (d_bank, d_bank_name, d_stock, d_ratio) values ('" & bank & "', '" & name & "', '" & stock & "', " & ratio & ")"
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, MyTrans, str) <= 0 Then
                MyTrans.Rollback()
                Return -1
            End If
            Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, "select d_seq from BankList where d_bank = '" & bank & "' and d_stock = '" & stock & "'", MyTrans).Tables(0)
            If dt.Rows.Count <= 0 Then
                MyTrans.Rollback()
                Return -1
            End If
            MyTrans.Commit()
            Return GFncNoNullValue(dt.Rows(0).Item("d_seq"))
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncInsertIntoBankList: " & ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function FncAdd2(ByVal bank As String, ByVal stock As String, ByVal ratio As Double, ByVal qty As Double, ByVal dVal As Double) As Integer
        Dim str As String = "insert into repledged_stock (stk_code, d_bank, qty, d_value, d_ratio, d_date) values ('" & stock & "', '" & bank & _
            "', " & qty & ", " & dVal & ", " & ratio & ", '" & Format(GDteTradeDate, "yyyy/MM/dd") & "')"
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, MyTrans, str) <= 0 Then
                MyTrans.Rollback()
                Return -1
            End If
            Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, "select d_seq from repledged_stock where d_bank = '" & bank & "' and stk_code = '" & _
                stock & "' and qty = " & qty & " and d_ratio = " & ratio & " and d_value = " & dVal & " and d_date = '" & _
                Format(GDteTradeDate, "yyyy/MM/dd") & "'", MyTrans).Tables(0)
            If dt.Rows.Count <= 0 Then
                MyTrans.Rollback()
                Return -1
            End If
            MyTrans.Commit()
            Return GFncNoNullValue(dt.Rows(0).Item("d_seq"))
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncInsertIntoRepledgedStock: " & ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function FncEdit(ByVal seq As Integer, ByVal name As String, ByVal stock As String, ByVal ratio As Double, ByVal bank As String) As Boolean
        Dim str As String = "update BankList set d_stock = '" & stock & "', d_ratio = " & ratio & " where d_seq = " & seq
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, MyTrans, str) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If
            If GFncRunSQL(GSCnSqlConn, MyTrans, "update BankList set d_bank_name = '" & name & "' where d_bank = '" & bank & "'") < 0 Then
                MyTrans.Rollback()
                Return False
            End If
            MyTrans.Commit()
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncModifyBankList: " & ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function FncEdit2(ByVal seq As Integer, ByVal qty As Double, ByVal amt As Double) As Boolean
        Dim str As String = "update repledged_stock set qty = " & qty & ", d_value = " & amt & " where d_seq = " & seq
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, MyTrans, str) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If
            MyTrans.Commit()
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncModifyRepledgedStock: " & ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function FncDelete(ByVal seq As Integer) As Boolean
        Dim str As String = "delete from BankList where d_seq = " & seq
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, MyTrans, str) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If
            MyTrans.Commit()
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncDeleteFromBankList: " & ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function FncDelete2(ByVal seq As Integer) As Boolean
        Dim str As String = "delete from repledged_stock where d_seq = " & seq
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            If GFncRunSQL(GSCnSqlConn, MyTrans, str) <= 0 Then
                MyTrans.Rollback()
                Return False
            End If
            MyTrans.Commit()
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog("FncDeleteFromRepledgedStock: " & ex.Message)
            End If
        End Try
    End Function

    Protected Friend Function FncGetName(ByVal bank As String) As String
        Dim dt As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct d_bank_name from BankList where d_bank = '" & bank & "'").Tables(0)
        If dt.Rows.Count > 0 Then
            Return GFncNoNullString(dt.Rows(0).Item("d_bank_name")).Trim
        Else
            Return ""
        End If
    End Function

    Protected Friend Function FncGenReport(ByVal rDt As DataTable) As ReportClass
        Dim rpt As ReportClass
        rpt = New rptRepledgeSummary
        rpt.ReportClientDocument.LocaleID = CrystalDecisions.ReportAppServer.DataDefModel.CeLocale.ceLocaleEnglishUK
        Dim dt As DataTable = New dtsRepledge.SummaryDataTable
        Dim bankstr As String = ""
        Dim bankDt As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct d_bank, d_bank_name from BankList").Tables(0)
        Dim bankCount As Integer = bankDt.Rows.Count
        Dim exDate As Date = GDteTradeDate.AddMonths(-1)
        Dim exDateDt As DataTable = Nothing
        Dim totalBank As Integer = 5
        If bankCount > 0 Then
            Dim pageCount As Integer = 0
            While bankCount > 0
                pageCount += 1
                bankCount -= totalBank
            End While
            Dim str As String = ""
            Dim bDt As DataTable = GFncRtnDS(GSCnSqlConn, "select d_bank, d_stock, cast(round(d_ratio, 999) as int) as d_ratio from BankList order by d_bank, d_stock").Tables(0)
            Dim bank1 As String = ""
            Dim bank2 As String = ""
            Dim bank3 As String = ""
            Dim bank4 As String = ""
            Dim bank5 As String = ""

            Dim bankName1 As String = ""
            Dim bankName2 As String = ""
            Dim bankName3 As String = ""
            Dim bankName4 As String = ""
            Dim bankName5 As String = ""

            bankstr = GFncNoNullString(bankDt.Rows(0).Item("d_bank")).Trim & ", "
            For i As Integer = 1 To pageCount
                Try
                    bank1 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank).Item("d_bank")).Trim
                    bankName1 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank).Item("d_bank_name")).Trim
                    If Not bankstr.Contains(bank1) Then
                        bankstr &= bank1 & ", "
                    End If
                Catch ex As Exception
                    bank1 = ""
                End Try
                Try
                    bank2 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank + 1).Item("d_bank")).Trim
                    bankName2 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank + 1).Item("d_bank_name")).Trim
                    If Not bankstr.Contains(bank2) Then
                        bankstr &= bank2 & ", "
                    End If
                Catch ex As Exception
                    bank2 = ""
                End Try
                Try
                    bank3 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank + 2).Item("d_bank")).Trim
                    bankName3 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank + 2).Item("d_bank_name")).Trim
                    If Not bankstr.Contains(bank3) Then
                        bankstr &= bank3 & ", "
                    End If
                Catch ex As Exception
                    bank3 = ""
                End Try
                Try
                    bank4 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank + 3).Item("d_bank")).Trim
                    bankName4 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank + 3).Item("d_bank_name")).Trim
                    If Not bankstr.Contains(bank4) Then
                        bankstr &= bank4 & ", "
                    End If
                Catch ex As Exception
                    bank4 = ""
                End Try
                Try
                    bank5 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank + 4).Item("d_bank")).Trim
                    bankName5 = GFncNoNullString(bankDt.Rows((i - 1) * totalBank + 4).Item("d_bank_name")).Trim
                    If Not bankstr.Contains(bank5) Then
                        bankstr &= bank5 & ", "
                    End If
                Catch ex As Exception
                    bank5 = ""
                End Try
                If i <> 1 Then
                    str &= "union "
                End If
                'str &= "(select 'Not Repledged Stocks' as type, a.stk_code as stock, sum(a.net_qty) as qty, sum(a.net_market_value) as mktValue, " & _
                '    i & " as page, '" & bank1 & "'  as bank1, 0.00 as margin1, 0.00 as ratio1, '" & bank2 & "' as bank2, 0.00 as margin2, " & _
                '    "0.00 as ratio2, '" & bank3 & "' as bank3, 0.00 as margin3, 0.00 as ratio3, '" & bank4 & "' as bank4, 0.00 as margin4, " & _
                '    "0.00 as ratio4, '0000/00/00' as exDate, 0.00 as repledgedQty, 0.00 as repledgedPrice from stportfolio a left join " & _
                '    "stcltmaster b on a.clt_code = b.clt_code where b.clt_type = 'M' and a.net_market_value > 0 and " & _
                '    "(b.cr_limit < 0 or b.cr_limit > 2) and a.stk_code in (select distinct d_stock from " & GStrConDB & ".dbo.BankList) " & _
                '    "group by a.stk_code) "

                'str &= "(select 'Not Repledged Stocks' as type, a.stk_code as stock, sum(a.net_qty) as qty, sum(a.net_market_value) as mktValue, " & _
                '    i & " as page, '" & bank1 & "'  as bank1, 0.00 as margin1, 0.00 as ratio1, '" & bank2 & "' as bank2, 0.00 as margin2, " & _
                '    "0.00 as ratio2, '" & bank3 & "' as bank3, 0.00 as margin3, 0.00 as ratio3, '" & bank4 & "' as bank4, 0.00 as margin4, " & _
                '    "0.00 as ratio4, '0000/00/00' as exDate, 0.00 as repledgedQty, 0.00 as repledgedPrice from stportfolio a left join " & _
                '    "stcltmaster b on a.clt_code = b.clt_code where b.clt_type = 'M' and a.net_market_value > 0 and b.cr_limit > 1000 " & _
                '    "and a.stk_code in (select distinct d_stock from " & GStrConDB & ".dbo.BankList) " & _
                '    "group by a.stk_code) "

                str &= "(select 'Not Repledged Stocks' as type, a.stk_code as stock, sum(a.qty) as qty, sum(a.market_value) as mktValue, " & _
                 i & " as page, '" & bank1 & "'  as bank1, '" & bankName1 & "' as bankName1, 0.00 as margin1, 0 as ratio1, '" & bank2 & "' as bank2, '" & _
                 bankName2 & "' as bankName2, 0.00 as margin2, " & "0 as ratio2, '" & bank3 & "' as bank3, '" & bankName3 & "' as bankName3, 0.00 as margin3, " & _
                 "0 as ratio3, '" & bank4 & "' as bank4, '" & bankName4 & "' as bankName4, 0.00 as margin4, " & "0 as ratio4, " & _
                 "'" & bank5 & "' as bank5, '" & bankName5 & "' as bankName5, 0.00 as margin5, " & "0 as ratio5, '' as exDate, " & _
                 "0.00 as repledgedQty, 0.00 as repledgedPrice, convert(decimal(18,3), sum(a.market_value)/sum(a.qty)) as preClose, 0.0 as availableQty " & _
                 "from stportfolio a inner join stcltmaster b on a.clt_code = b.clt_code where b.clt_type = 'M' and qty > 0 and b.cr_limit > 1000 " & _
                 "and a.stk_code in (select distinct d_stock from " & GStrConDB & ".dbo.BankList) group by a.stk_code) "

            Next
            bankstr = bankstr.Substring(0, bankstr.Length - 2)
            dt = GFncRtnDS(GSCnLiqConn, str).Tables(0)

            Dim dtSrc As DataTable = Nothing
            Dim drArray() As DataRow
            str = "select stkno, sum(a.qty) qty " & _
                    "from " & GStrG2BSDB & ".dbo.pfmaster_client a " & _
                    "inner join " & GStrG2BSDB & ".dbo.stock_master b on a.sid = b.sid " & _
                    "inner join " & GStrG2BSDB & ".dbo.client_master c on a.aid = c.aid " & _
                    "inner join " & GStrG2BSDB & ".dbo.depot_master d on a.dpid = d.dpid " & _
                    "inner join stportfolio e on e.clt_code=c.accno and e.stk_code=b.stkno " & _
                    "inner join stcltmaster f on e.clt_code = f.clt_code " & _
                    "where a.qty > 0 and d.dpid in (164,165) " & _
                    " and f.clt_type = 'M' and f.cr_limit > 1000 " & _
                    "group by stkno order by stkno"

            dtSrc = GFncRtnDS(GSCnLiqConn, str).Tables(0)

            For Each row As DataRow In dt.Rows
                Application.DoEvents()

                drArray = dtSrc.Select(String.Format("stkno='{0}'", row("stock").ToString.Trim))
                If drArray.Length > 0 Then
                    row("mktValue") = row("preClose") * drArray(0)("qty")
                    row("availableQty") = drArray(0)("qty")
                    row("Qty") = drArray(0)("qty")
                    'If row("qty") > drArray(0)("qty") Then
                    '    MessageBox.Show("error!")
                    'End If
                Else
                    row("mktValue") = 0
                    row("Qty") = 0
                    row("availableQty") = 0
                End If

            Next
            'str = "SELECT DISTINCT mm.name AS MarketNm, cm.name_s AS Currency, sm.stkno, RTRIM(sm.s_code) AS StkNm, SUM(DepotQTY) AS DepotQTY, " & _
            '    "SUM(StkTradeUnset) AS StkTradeUnset, SUM(StkUnrealized) AS StkUnrealized, ISNULL(sm.price, 0) AS MarketPrice, sm.so3, " & _
            '    "sm.price_dp, sm.qty_dp FROM " & GStrG2BSDB & ".dbo.view_rpt_daily_stk_loc v, " & GStrG2BSDB & ".dbo.market_master mm, " & _
            '    GStrG2BSDB & ".dbo.stock_master sm, " & GStrG2BSDB & ".dbo.depot_master dm, " & GStrG2BSDB & ".dbo.currency_master cm " & _
            '    "WHERE mm.mkid = v.mkid AND sm.sid = v.sid AND dm.dpid = v.dpid AND cm.cuid = sm.cuid AND (DepotQTY <> 0 OR StkTradeUnset <> 0 OR " & _
            '    "StkUnrealized <> 0) and dm.code in (select distinct d_bank from banklist) and sm.stkno in (select distinct d_stock from banklist) " & _
            '    "GROUP BY mm.name, cm.name_s, sm.stkno, sm.s_code, sm.price, sm.so3, sm.price_dp, sm.qty_dp"
            'Dim repledgeDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
            For Each rDr As DataRow In rDt.Rows
                Dim times As Integer = 0
                Dim stock As String = GFncNoNullString(rDr("stkno")).Trim
                Dim qty As Double = GFncNoNullValue(rDr("depotQTY"))
                Dim dCode As String = GFncNoNullString(rDr("DepotCD")).Trim
                If bankstr.Contains(dCode) Then
                    For Each dr As DataRow In dt.Rows
                        If GFncNoNullString(dr("stock")).Trim = stock Then
                            times += 1
                            dr("mktValue") = GFncNoNullValue(dr("mktValue"))
                            dr("repledgedQty") = GFncNoNullValue(dr("repledgedQty")) + qty
                            dr("availableQty") = GFncNoNullValue(dr("qty")) - GFncNoNullValue(dr("repledgedQty"))
                            dr("repledgedPrice") = GFncNoNullValue(rDr("MarketPrice"))
                            If times = pageCount Then
                                Exit For
                            End If
                        End If
                    Next
                End If
            Next

            'str = "select b.stkno, max(a.date_ex) as exDate from " & GStrG2BSDB & ".dbo.distribut_diary a inner join " & GStrG2BSDB & _
            '    ".dbo.stock_master b on a.mkid = b.mkid and a.sid = b.sid where b.stkno in (select distinct d_stock from banklist) group by b.stkno"
            str = "select b.stkno, max(a.date_bc) as exDate from " & GStrG2BSDB & ".dbo.distribut_diary a inner join " & GStrG2BSDB & _
                ".dbo.stock_master b on a.mkid = b.mkid and a.sid = b.sid where b.stkno in (select distinct d_stock from banklist) group by b.stkno"

            exDateDt = GFncRtnDS(GSCnSqlConn, str).Tables(0)
            For Each dr As DataRow In dt.Rows
                Dim stk As String = GFncNoNullString(dr("stock")).Trim
                For Each exDr As DataRow In exDateDt.Rows
                    If stk = GFncNoNullString(exDr("stkno")).Trim Then
                        Dim exDay As Date = GFncNoNullDate(exDr("exDate"))

                        'If exDay < exDate Then

                        If exDay >= GDteTradeDate Then
                            dr("exDate") = Format(exDay, "MM/dd/yy")
                            'Else
                            '    dr("exDate") = Nothing
                        End If
                        Exit For
                    End If
                Next
                For Each bDr As DataRow In bDt.Rows
                    Dim bank As String = GFncNoNullString(bDr("d_bank")).Trim
                    Dim stock As String = GFncNoNullString(bDr("d_stock")).Trim

                    If stock = stk Then
                        Application.DoEvents()
                        If bank = GFncNoNullString(dr("bank1")).Trim Then
                            dr("ratio1") = GFncNoNullIntValue(bDr("d_ratio"))
                            ' dr("margin1") = GFncNoNullValue(dr("mktValue")) * GFncNoNullValue(bDr("d_ratio")) / 100
                            dr("margin1") = GFncNoNullValue(dr("availableQty")) * _
                                    GFncNoNullValue(dr("preClose")) * GFncNoNullValue(bDr("d_ratio")) / 100
                        ElseIf bank = GFncNoNullString(dr("bank2")).Trim Then
                            dr("ratio2") = GFncNoNullIntValue(bDr("d_ratio"))
                            'dr("margin2") = GFncNoNullValue(dr("mktValue")) * GFncNoNullValue(bDr("d_ratio")) / 100
                            dr("margin2") = GFncNoNullValue(dr("availableQty")) * _
                                    GFncNoNullValue(dr("preClose")) * GFncNoNullValue(bDr("d_ratio")) / 100
                        ElseIf bank = GFncNoNullString(dr("bank3")).Trim Then
                            dr("ratio3") = GFncNoNullIntValue(bDr("d_ratio"))
                            'dr("margin3") = GFncNoNullValue(dr("mktValue")) * GFncNoNullValue(bDr("d_ratio")) / 100
                            dr("margin3") = GFncNoNullValue(dr("availableQty")) * _
                                    GFncNoNullValue(dr("preClose")) * GFncNoNullValue(bDr("d_ratio")) / 100
                        ElseIf bank = GFncNoNullString(dr("bank4")).Trim Then
                            dr("ratio4") = GFncNoNullIntValue(bDr("d_ratio"))
                            'dr("margin4") = GFncNoNullValue(dr("mktValue")) * GFncNoNullValue(bDr("d_ratio")) / 100
                            dr("margin4") = GFncNoNullValue(dr("availableQty")) * _
                                    GFncNoNullValue(dr("preClose")) * GFncNoNullValue(bDr("d_ratio")) / 100
                        ElseIf bank = GFncNoNullString(dr("bank5")).Trim Then
                            dr("ratio5") = GFncNoNullIntValue(bDr("d_ratio"))
                            dr("margin5") = GFncNoNullValue(dr("availableQty")) * _
                                    GFncNoNullValue(dr("preClose")) * GFncNoNullValue(bDr("d_ratio")) / 100
                        End If
                    End If
                Next
            Next



        End If
        rpt.SetDataSource(dt)
        'Dim subStr As String = "select 'Not Repledged Stocks' as type, a.clt_code as cltCode, a.clt_name as cltName, a.cr_limit as CR, " & _
        '    "b.stk_code as stock, b.net_qty as qty, b.net_market_value as mktValue, '0000/00/00' as exDate from stcltmaster a inner join stportfolio b " & _
        '    "on a.clt_code = b.clt_code where a.clt_type = 'M' and (a.cr_limit < 0 or a.cr_limit > 2) and b.net_market_value > 0 and b.stk_code in " & _
        '    "(select distinct d_stock from " & GStrConDB & ".dbo.BankList)"
        Dim subStr As String = "select 'Not Repledged Stocks' as type, a.clt_code as cltCode, a.clt_name as cltName, a.cr_limit as CR, " & _
            "b.stk_code as stock, b.net_qty as qty, b.net_market_value as mktValue, '0000/00/00' as exDate from stcltmaster a inner join stportfolio b " & _
            "on a.clt_code = b.clt_code where a.clt_type = 'M' and a.cr_limit > 1000 and b.net_market_value > 0 and b.stk_code in " & _
            "(select distinct d_stock from " & GStrConDB & ".dbo.BankList)"
        Dim subDt As DataTable = GFncRtnDS(GSCnLiqConn, subStr).Tables(0)
        For Each subDr As DataRow In subDt.Rows
            Dim stk As String = GFncNoNullString(subDr("stock")).Trim
            For Each exDr As DataRow In exDateDt.Rows
                If stk = GFncNoNullString(exDr("stkno")).Trim Then
                    Dim exDay As Date = GFncNoNullDate(exDr("exDate"))
                    If exDay <= exDate Then
                        subDr("exDate") = Format(exDay, "MM/dd/yy")
                    End If
                    Exit For
                End If
            Next
        Next
        rpt.Subreports("rptRepledge.rpt").SetDataSource(subDt)
        rpt.SetParameterValue("user", Trim(GStrloginID))
        rpt.SetParameterValue("title", "as at " & GDteTradeDate.ToString("dd MMM yyyy", CultureInfo.CreateSpecificCulture("en-US")))

        Return rpt
    End Function

    Protected Friend Function FncGenReport2(ByVal rDt As DataTable, ByVal precentage As Double) As ReportClass
        Dim rpt As ReportClass
        rpt = New rptRepledged
        Dim dt As DataTable = New dtsRepledge.repledgedDataTable
        Dim cDt As DataTable = New dtsRepledge.CRClientDataTable
        Dim str As String = ""
        Dim cr As Double = 0.0
        Dim exDate As Date = GDteTradeDate.AddMonths(-1)
        Dim bankstr As String = ""
        Dim bankDt As DataTable = GFncRtnDS(GSCnSqlConn, "select distinct d_bank from BankList").Tables(0)
        For Each dr As DataRow In bankDt.Rows
            bankstr = GFncNoNullString(dr("d_bank")).Trim & ", "
        Next
        bankstr = bankstr.Substring(0, bankstr.Length - 2)
        str = "select clt_code as cltCode, clt_name as cltName, dr_bal as CR from STCLTMASTER where clt_type = 'M' and dr_bal > 0 order by clt_code"
        cDt = GFncRtnDS(GSCnLiqConn, str).Tables(0)
        For Each dr As DataRow In cDt.Rows
            cr += GFncNoNullValue(dr("CR"))
        Next
        str = "select a.stk_code as stock, a.d_bank as bank, a.qty as repledgedQty, a.d_value as repledgedValue, " & _
            "a.d_ratio as ratio, a.d_date as repledgedDate, '" & Format(GDteTradeDate, "yyyy/MM/dd") & "' as tDate, '0000/00/00' as exDate, " & _
            "sum(c.net_market_value) as mktValue, sum(c.net_qty) as totalQty, 0.00 as repQty, 0.00 as repPrice from " & GStrConDB & _
            ".dbo.repledged_stock a inner join " & GStrConDB & ".dbo.banklist b on b.d_bank = a.d_bank inner join stportfolio c on " & _
            "c.stk_code = a.stk_code left join stcltmaster d on d.clt_code = c.clt_code where d.clt_type = 'M' and c.net_market_value > 0 and " & _
            "(d.cr_limit < 0 or d.cr_limit > 2) and a.d_date = '" & Format(GDteTradeDate, "yyyy/MM/dd") & "' group by a.stk_code, " & _
            "a.d_bank, a.qty, a.d_value, a.d_ratio, a.d_date order by a.stk_code"
        dt = GFncRtnDS(GSCnLiqConn, str).Tables(0)
        For Each rDr As DataRow In rDt.Rows
            Dim stock As String = GFncNoNullString(rDr("stkno")).Trim
            Dim qty As Double = GFncNoNullValue(rDr("depotQTY"))
            Dim dCode As String = GFncNoNullString(rDr("DepotCD")).Trim
            If bankstr.Contains(dCode) Then
                For Each dr As DataRow In dt.Rows
                    If GFncNoNullString(dr("stock")).Trim = stock Then
                        dr("repQty") = GFncNoNullValue(dr("repQty")) + qty
                        dr("repPrice") = GFncNoNullValue(rDr("MarketPrice"))
                        Exit For
                    End If
                Next
            End If
        Next
        str = "select b.stkno, max(a.date_ex) as exDate from " & GStrG2BSDB & ".dbo.distribut_diary a inner join " & GStrG2BSDB & _
                ".dbo.stock_master b on a.mkid = b.mkid and a.sid = b.sid where b.stkno in (select distinct d_stock from banklist) group by b.stkno"
        Dim exDateDt As DataTable = GFncRtnDS(GSCnSqlConn, str).Tables(0)
        For Each dr As DataRow In dt.Rows
            Dim stk As String = GFncNoNullString(dr("stock")).Trim
            For Each exDr As DataRow In exDateDt.Rows
                If stk = GFncNoNullString(exDr("stkno")).Trim Then
                    Dim exDay As Date = GFncNoNullDate(exDr("exDate"))
                    If exDay < exDate Then
                        dr("exDate") = Format(exDay, "MM/dd/yy")
                    End If
                    Exit For
                End If
            Next
        Next
        rpt.SetDataSource(dt)
        rpt.Subreports("rptRepledgedSubClient").SetDataSource(cDt)
        rpt.SetParameterValue("user", Trim(GStrloginID))
        rpt.SetParameterValue("precentage", precentage)
        rpt.SetParameterValue("TotalCr", cr)
        Return rpt
    End Function

    Protected Friend Function FncGenReport3() As ReportClass

        Dim rpt As ReportClass = New RptRepledgeDetail
        Dim dt As DataTable = Nothing
        Dim strSQL As String = ""

        strSQL = "select a.qty as d_qty, d.dpid as d_dpid, d.name as d_dp_name, " & _
                              "f.clt_type as d_clt_type, f.cr_limit as d_cr_limit, " & _
                              "b.stkno as d_stkno, c.accno as d_accno into #temp " & _
                              "from " & GStrG2BSDB & ".dbo.pfmaster_client a " & _
                              "inner join " & GStrG2BSDB & ".dbo.stock_master b on a.sid = b.sid " & _
                              "inner join " & GStrG2BSDB & ".dbo.client_master c on a.aid = c.aid " & _
                              "inner join " & GStrG2BSDB & ".dbo.depot_master d on a.dpid = d.dpid " & _
                              "inner join stportfolio e on e.clt_code=c.accno and e.stk_code=b.stkno " & _
                              "inner join stcltmaster f on e.clt_code = f.clt_code"
        GFncRunSQL(GSCnLiqConn, strSQL, 0)

        strSQL = "select d_stkno, d_accno, d_dpid, d_dp_name, d_clt_type, d_cr_limit, " & _
                        "case when " & _
                        "d_qty>0 " & _
                        "and (d_dpid=164 or d_dpid=165) " & _
                        "and d_clt_type='M' " & _
                        "and d_cr_limit>1000 " & _
                        "then d_qty " & _
                        "else 0 end as d_available_qty, " & _
                        "case when " & _
                        "not (d_qty>0 " & _
                        "and (d_dpid=164 or d_dpid=165) " & _
                        "and d_clt_type='M' " & _
                        "and d_cr_limit>1000) " & _
                        "then d_qty " & _
                        "else 0 end as d_not_available_qty " & _
                        "from #temp " & _
                        " where d_stkno in (select distinct d_stock from  " & GStrConDB & ".dbo.banklist) " & _
                        "order by d_stkno, d_accno, d_dp_name"
        dt = GFncRtnDS(GSCnLiqConn, strSQL, 0).Tables(0)

        GFncRunSQL(GSCnLiqConn, "drop table #temp")

        rpt.SetDataSource(dt)
        rpt.SetParameterValue("user", Trim(GStrloginID))
        rpt.SetParameterValue("condition", "As at " & Format(GDteTradeDate, "dd MMM yyyy") & ", Total Available Qty: dpid=164,165, Client Type=M, Credit Limit>1000")
        Return rpt
    End Function

    'Protected Friend Function FncGenerateReport()
    '    Dim rpt As ReportClass
    '    rpt = New rptRepledge
    '    Dim dt As DataTable
    '    Dim str As String = "select 'Not Repledged Stocks:' as type, a.clt_code as cltCode, a.clt_name as cltName, a.cr_limit as CR, b.stk_code as stock, " & _
    '        "b.net_qty as qty, b.net_market_value as mktValue, c.d_bank as location, c.d_ratio as ratio, c.d_ratio * b.net_market_value / 100 as margin " & _
    '        "from stcltmaster a inner join stportfolio b on a.clt_code = b.clt_code inner join " & GStrConDB & ".dbo.BankList c on b.stk_code = c.d_stock " & _
    '        "where a.clt_type = 'M' and (a.cr_limit < 0 or a.cr_limit > 2) and b.net_market_value > 0"
    '    dt = GFncRtnDS(GSCnLiqConn, str).Tables(0)
    '    rpt.SetDataSource(dt)
    '    rpt.SetParameterValue("user", Trim(GStrloginID))
    '    Return rpt
    'End Function

    Protected Friend Function FncSearch2(ByVal stock As String, ByVal bank As String, ByVal sDate As Date, ByVal eDate As Date) As DataTable
        Dim str As String = "select * from repledged_stock where d_date between '" & Format(sDate, "yyyy/MM/dd") & "' and '" & Format(eDate, "yyyy/MM/dd") & "' "
        If stock <> "" Then
            str &= "and stk_code = '" & stock & "' "
        End If
        If bank <> "" Then
            str &= "and d_bank = '" & bank & "' "
        End If
        str &= "order by d_seq"
        Return GFncRtnDS(GSCnSqlConn, str).Tables(0)
    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Protected Friend Function FncGetdata(ByVal path As String, ByRef dt As DataTable) As String
        Dim xlApp As Object = CreateObject("Excel.Application") 'Excel.Application
        Dim xlWorkBook As Object = xlApp.Workbooks.Open(path) 'Excel.Workbook
        Dim xlWorkSheet As Object = Nothing 'Excel.Worksheet
        Dim range As Object = Nothing
        Dim ECnt As Integer = Nothing
        Dim bank As String = ""
        Dim bName As String = ""
        Dim stock As String = ""
        Dim ratio As Double = 0.0
        Dim preBank As String = ""
        Dim preBName As String = ""
        Try
            For Each xlWorkSheet In xlWorkBook.Worksheets
                range = xlWorkSheet.UsedRange
                If range.columns.count >= 4 Then
                    If GFncNoNullString(range.Cells(1, 1).value).Trim.ToUpper = "BANK" Then
                        Dim dr As DataRow = dt.NewRow
                        dr("sql") = "delete from banklist"
                        dt.Rows.Add(dr)
                        dr = Nothing
                        For ECnt = 2 To range.rows.count
                            bank = GFncNoNullString(range.Cells(ECnt, 1).value).Trim
                            bName = GFncNoNullString(range.Cells(ECnt, 2).value).Trim.Replace("'", "''")
                            If bName = "" Then
                                bName = preBName
                            End If
                            If bank = "" Then
                                bank = preBank
                                bName = preBName
                            ElseIf bank <> preBank Then
                                preBank = bank
                                preBName = bName
                            End If
                            stock = GFncNoNullString(range.Cells(ECnt, 3).value).Trim
                            ratio = GFncNoNullValue(range.Cells(ECnt, 4).value)
                            dr = dt.NewRow
                            dr("sql") = "insert into banklist (d_bank, d_bank_name, d_stock, d_ratio) values ('" & bank & "', '" & _
                                bName & "', '" & stock & "', " & ratio & ")"
                            dt.Rows.Add(dr)
                            dr = Nothing
                        Next
                    Else
                        dt.Clear()
                        Return "Wrong import file format!"
                    End If
                End If
            Next xlWorkSheet
        Catch ex As Exception
            GC.Collect()
            GSubShowError(ex.Message)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            releaseObject(range)
            GSubWriteErrLog("ImportBankList: " & ex.Message & ECnt)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
        releaseObject(range)
        Return ""
    End Function

    Protected Friend Function FncRunSQL(ByVal dt As DataTable) As Boolean
        Dim myTrans As SqlTransaction = Nothing
        Try
            myTrans = GSCnSqlConn.BeginTransaction
            For Each dr As DataRow In dt.Rows
                Dim str As String = GFncNoNullString(dr("sql")).Trim
                If GFncRunSQL(GSCnSqlConn, myTrans, str) <= 0 Then
                    myTrans.Rollback()
                    Return False
                End If
            Next
            myTrans.Commit()
            Return True
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (myTrans IsNot Nothing) Then
                    myTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                Return False
            End If
        End Try
    End Function

    Protected Friend Function FncExportToExcel(ByVal path As String, ByVal filename As String) As Boolean
        Dim rtnVal As Boolean = True
        Dim strSQL As String = ""
        Dim ds As DataSet = Nothing

        Try
            strSQL = "select d_bank, d_bank_name, d_stock, d_ratio from banklist order by d_bank, d_stock, d_ratio"
            ds = GFncRtnDS(GSCnSqlConn, strSQL)

            If Not lcExportToExcel(path & "\", filename, ds, "BANK,BANK NAME,STK CODE,RATIO") Then
                rtnVal = False
                GSubWriteEventLog("Cannot export excel", GStrEPath)
            End If

        Catch ex As Exception
            rtnVal = False

            Try
                GSubWriteEventLog("Cannot export excel - " & ex.Message, GStrEPath)
            Catch ex1 As Exception
            End Try
        End Try

        Return rtnVal
    End Function

    Public Function lcExportToExcel(ByVal strExptDir As String, ByVal strExptFilename As String, _
                                ByVal ldtsData As DataSet, ByVal strHeader As String) As Boolean

        Dim xlApp As Object
        Dim xlWorkBook As Object
        Dim rowCount As Integer = 2
        Dim colCount As Integer = 1
        Dim lstrFiles() As String
        Dim ldtwData As DataRow
        Dim ldtcData As DataColumn

        Try
            lstrFiles = System.IO.Directory.GetFiles(GStrExptDir, strExptFilename)
            For Each lstrFile As String In lstrFiles
                Application.DoEvents()
                System.IO.File.Delete(lstrFile)
            Next

            xlApp = CreateObject("Excel.Application")
            xlWorkBook = xlApp.Workbooks.Add(True)

            Dim headerString As String = strHeader.Trim
            Dim val As String = ""
            colCount = 1
            Do While headerString.Length > 0
                If (InStr(headerString, ",") > 0) Then
                    val = Mid(headerString, 1, InStr(headerString, ",") - 1)
                    xlApp.cells(1, colCount).Value = val
                    headerString = Mid(headerString, InStr(headerString, ",") + 1, headerString.Length - InStr(headerString, ",")).Trim
                    colCount = colCount + 1
                Else
                    xlApp.cells(1, colCount).Value = headerString
                    headerString = ""
                End If
            Loop

            For Each ldtwData In ldtsData.Tables(0).Rows
                colCount = 1
                For Each ldtcData In ldtsData.Tables(0).Columns
                    If (ldtcData.DataType.Name = "String") Then
                        If (IsDBNull(ldtwData(ldtcData.ColumnName)) = False) Then
                            xlApp.cells(rowCount, colCount).Value = "'" & _
                                                       Trim(Replace(Replace(Replace(ldtwData(ldtcData.ColumnName), _
                                                       Chr(10), ""), Chr(12), ""), Chr(13), ""))
                        End If
                    Else
                        If (IsDBNull(ldtwData(ldtcData.ColumnName)) = False) Then
                            xlApp.cells(rowCount, colCount).Value = ldtwData(ldtcData.ColumnName)
                        End If
                    End If
                    colCount = colCount + 1
                Next
                rowCount = rowCount + 1
            Next

            xlWorkBook.SaveAs(strExptDir & strExptFilename)
            xlApp.Workbooks.Close()
            xlApp.Quit()
            xlWorkBook = Nothing
            xlApp = Nothing
            GC.Collect()

            Return True
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return False
        End Try

    End Function
End Class
