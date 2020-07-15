Imports System.Data.SqlClient
Imports System.IO
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsLoadNewEdge

    Dim ldtconfirm As DataTable
    Dim ldtliq As DataTable
    Dim ldtOP As DataTable
    Dim ldtTemp As DataTable
    Dim totalRow As Integer = 88

    Protected Friend Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub

    Protected Friend Sub lFncCreateDataTable(ByRef dt As DataTable)
        Dim column As DataColumn
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.DateTime")
        column.ColumnName = "tdate"
        dt.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int64")
        column.ColumnName = "buy"
        dt.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Int64")
        column.ColumnName = "sell"
        dt.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "monthcode"
        dt.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "product"
        dt.Columns.Add(column)
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.Decimal")
        column.ColumnName = "price"
        dt.Columns.Add(column)
    End Sub
    Private Function lfncReturnDec(ByVal strValue As String) As Decimal
        Dim ldec As Decimal = 0

        strValue = GFncNoNullString(strValue).Trim
        If strValue = "" Then
            Return ldec
        End If
        strValue = Replace(strValue, Chr(30), "-")
        strValue = Replace(strValue, ",", "")
        
        ldec = CDec(strValue)


        Return ldec

    End Function
    Protected Friend Function lFncGetTradeDateFromDoc(ByVal filename, ByVal wordApplication) As String
        Dim word As Object = Nothing
        Dim doc As Object = Nothing
        Dim myWord As Object = Nothing
        Dim i As Integer = 1
        Dim lstr As String = ""
        Dim ldate As String = ""

        word = CreateObject("Word.Application")
        doc = CreateObject("Word.Document")

        doc = word.Documents.Open(filename)
        doc.Activate()
        For Each myWord In doc.Sentences
            If i = 6 Then
                lstr = myWord.Text
                lstr = Trim(Replace(Replace(lstr, Chr(10), ""), Chr(13), ""))
                ldate = Right(lstr, 4) & "/"
                lstr = Left(lstr, lstr.Length - 4).Trim
                ldate = ldate & lFncGetMonthNumber(Right(lstr, 3)) & "/"
                lstr = Left(lstr, lstr.Length - 3).Trim
                If (lstr.Length = 1) Then
                    ldate = ldate & "0" & lstr
                Else
                    ldate = ldate & lstr
                End If
                Try
                    Dim dateTemp As Date = CDate(ldate)
                    Return ldate
                Catch ex As Exception
                    Return ""
                Finally
                    doc = Nothing
                    word.Quit()
                    releaseObject(word)
                    releaseObject(doc)
                    releaseObject(myWord)
                End Try
                Exit For
            End If
            i = i + 1
        Next

        doc.close()
        doc = Nothing
        word.close()
        word.Quit()
        releaseObject(word)
        releaseObject(doc)
        releaseObject(myWord)
        Return ""

        'Dim word As New Microsoft.Office.Interop.Word.Application
        'Dim doc As Microsoft.Office.Interop.Word.Document = Nothing
        'Dim myWord As Microsoft.Office.Interop.Word.Range
        'Dim i As Integer = 1
        'Dim lstr As String = ""
        'Dim ldate As String = ""

        'doc = word.Documents.Open(filename)
        'doc.Activate()
        'For Each myWord In doc.Sentences
        '    If (i = 7) Then
        '        lstr = myWord.Text
        '        lstr = Trim(Replace(Replace(lstr, Chr(10), ""), Chr(13), ""))
        '        ldate = Right(lstr, 4) & "/"
        '        lstr = Left(lstr, lstr.Length - 4).Trim
        '        ldate = ldate & lFncGetMonthNumber(Right(lstr, 3)) & "/"
        '        lstr = Left(lstr, lstr.Length - 3).Trim
        '        If (lstr.Length = 1) Then
        '            ldate = ldate & "0" & lstr
        '        Else
        '            ldate = ldate & lstr
        '        End If
        '        Try
        '            Dim dateTemp As Date = CDate(ldate)
        '            Return ldate
        '        Catch ex As Exception
        '            Return ""
        '        Finally
        '            doc = Nothing
        '            word.Quit()
        '        End Try
        '        Exit For
        '    End If
        '    i = i + 1
        'Next

        'doc = Nothing
        'word.Quit()
        'Return ""

    End Function

    Protected Friend Function lFncTradeDateImported(ByVal trade_date As String, ByVal pCounterParty As String) As Boolean

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select * from newedge_emp_op where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        Return (lds.Tables(0).Rows.Count > 0)

    End Function

    Protected Friend Sub lFncDeleteImported(ByVal trade_date As String, ByVal MyTrans As SqlTransaction, ByVal pCounterParty As String)

        Dim lstrSQL As String

        lstrSQL = "delete from newedge_emp_op where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_cap_op where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_cap_op_adj where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_cap_trade_hist where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_cap_trade_hist_adj where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_cap_fee where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_content where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_cap_CP where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_cap_CP_adj where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_liq_header where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
        lstrSQL = "delete from newedge_liq_header_adj where tdate = '" & trade_date & "' and counterparty = '" & pCounterParty & "'"
        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)


    End Sub

    Protected Friend Function lFncGetEmpOP(ByVal trade_date As String) As DataTable

        Dim lstrSQL As String
        Dim lds As DataSet
        Dim mdate As String

        lstrSQL = "select max(tdate) as mdate from newedge_emp_op where tdate < '" & trade_date & "'"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        mdate = Format(CDate(GFncNoNullDate(lds.Tables(0).Rows(0).Item(0))), "yyyy/MM/dd HH:mm:ss").ToString

        lstrSQL = "select odate as tdate, buy, sell, monthcode, product, price from newedge_emp_op where tdate = '" & _
                    mdate & "' order by product, monthcode, odate"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

        Return lds.Tables(0)

    End Function

    'Protected Friend Function lFncInsertNewedgeTrade(ByVal tdate As Date, ByVal buy As Long, ByVal sell As Long, ByVal monthcode As String, _
    '    ByVal product As String, ByVal tprice As Double, ByVal MDFlag As String, ByVal settleDate As Date, ByVal MyTrans As SqlTransaction) As Boolean
    '    Dim lstrSQL As String
    '    lstrSQL = "insert into newedge_cap_trade_hist(tdate, buy, sell, monthcode, product, price, period, monthly_daily, settle_Date) values ('" & _
    '                    Format(tdate, "yyyy/MM/dd") & "', " & CStr(buy) & ", " & CStr(sell) & ", '" & monthcode & "', '" & product & "', " & _
    '                    CStr(tprice) & ", 'Electronic', '" & MDFlag & "', '" & Format(settleDate, "yyyy/MM/dd") & "')"
    '    Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    'End Function

    Protected Friend Function lFncInsertNewedgeTrade(ByVal tdate As Date, ByVal buy As Long, ByVal sell As Long, ByVal monthcode As String, _
        ByVal product As String, ByVal tprice As Double, ByVal dStrike As Double, ByVal sCallput As String, ByVal MDFlag As String, ByVal settleDate As Date, ByRef dt As DataTable) As Boolean
        Dim dr As DataRow = dt.NewRow
        dr("tdate") = CDate(tdate)
        dr("buy") = buy
        dr("sell") = sell
        dr("monthcode") = monthcode.Trim
        dr("product") = product
        dr("price") = tprice
        dr("monthly_daily") = MDFlag
        dr("settle_date") = CDate(settleDate)
        dr("seq") = dt.Rows.Count + 1
        dr("strike") = dStrike
        dr("callput") = sCallput
        dt.Rows.Add(dr)
    End Function

    Protected Friend Function lFncInsertNewedgeFeeOP(ByVal trade_date As String, ByVal monthcode As String, ByVal product As String, _
        ByVal comm As Double, ByVal clearing As Double, ByVal exchange As Double, ByVal total As Double, ByVal MyTrans As SqlTransaction, ByVal pCounterParty As String) As Boolean
        Dim lstrSQL As String
        lstrSQL = "insert into newedge_cap_fee(tdate, monthcode, product, comm, clearing, exchange, total, counterparty) values ('" & _
                    trade_date & "', '" & monthcode & "', '" & GFncSqlQuote(product) & "', " & CStr(comm) & _
                    ", " & CStr(clearing) & ", " & CStr(exchange) & ", '" & total & "', '" & pCounterParty & "')"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Friend Function lFncGetTradeData(ByVal filename As String, ByVal trade_date As String)
        Dim word As Object = Nothing
        Dim doc As Object = Nothing
        Dim myWord As Object = Nothing
        Dim i As Integer = 1
        Dim rowcount As Integer = 0
        Dim readtype As Integer = 0
        Dim MyTrans As SqlTransaction = Nothing

        Dim lstr As String = ""
        Dim mthcode As String = ""
        Dim prod As String = ""
        Dim comm As Double = 0
        Dim clearing As Double = 0
        Dim exchange As Double = 0
        Dim total As Double = 0
        Dim MDFlag As String = "M"
        Dim settleDate As Date = GFncNoNullDate("1900/01/01")
        Dim floating As Decimal = 0.0
        Dim OPDT As DataTable = New dtsNewedge.OpenPositionDataTable
        Dim LQDT As DataTable = New dtsNewedge.LiqPositionDataTable
        Dim TransDt As DataTable = New dtsNewedge.TransDataTable
        Dim LiqHeader As DataTable = New dtsNewedge.LiqHeaderDataTable
        Dim lintCnt As Integer = 0

        'remarked by king @ 15112011
        Try
            word = CreateObject("Word.Application")
            doc = CreateObject("Word.Document")
            doc = word.Documents.Open(filename)
            doc.Activate()
            ldtconfirm = New DataTable("confirmation")
            lFncCreateDataTable(ldtconfirm)
            ldtliq = New DataTable("tradedetail")
            lFncCreateDataTable(ldtliq)
            ldtOP = New DataTable("openposition")
            lFncCreateDataTable(ldtOP)
            ldtTemp = lFncGetEmpOP(trade_date).Copy
            MyTrans = GSCnSqlConn.BeginTransaction
            lFncDeleteImported(trade_date, MyTrans, "Newedge")
            For Each myWord In doc.Sentences
                lstr = myWord.Text
                lintCnt += 1
                If lintCnt = 348 Then
                    lintCnt = 348
                End If
                GSubWriteEventLog(lintCnt.ToString & " - " & lstr, "c:\esl")
                If (InStr(lstr, "C  O  N  F  I  R  M  A  T  I  O  N") > 0) Then
                    readtype = 1
                ElseIf (InStr(lstr, "P  U  R  C  H  A  S  E") > 0) Then
                    readtype = 2
                ElseIf (InStr(lstr, "O  P  E  N      P  O  S  I  T  I  O  N  S") > 0) Then
                    readtype = 3
                ElseIf (InStr(lstr, "THE FOLLOWING JOURNAL ENTRIES HAVE BEEN POSTED TO YOUR ACCOUNT") > 0) Then
                    readtype = 4
                ElseIf (InStr(lstr, "** US DOLLAR **") > 0) Then
                    Exit For
                Else
                    If (lstr.Trim.Length > 0) Then
                        Dim lvalue As String = ""
                        Dim isDate As Boolean = True
                        Dim tdate As Date = Nothing
                        Dim tbuy As Long = 0
                        Dim tsell As Long = 0
                        Dim tmonthcode As String = ""
                        Dim tproduct As String = ""
                        Dim dStrike As Double = 0
                        Dim sCallPut As String = ""
                        Dim tprice As Double = 0
                        Try
                            tdate = CDate("20" & lstr.Substring(6, 2) & "/" & lFncGetMonthNumber(lstr.Substring(3, 3)) & "/" & lstr.Substring(1, 2))
                            isDate = True
                        Catch ex As Exception
                            isDate = False
                        End Try

                        If (isDate = True) Then 'trade
                            'buy
                            If (readtype <> 4) Then
                                lvalue = lstr.Substring(20, 14)
                                If (lvalue.Trim.Length > 0) Then
                                    tbuy = CLng(lvalue)
                                Else
                                    tbuy = 0
                                End If
                                'sell
                                lvalue = lstr.Substring(35, 14)
                                If (lvalue.Trim.Length > 0) Then
                                    tsell = CLng(lvalue)
                                Else
                                    tsell = 0
                                End If
                                'desc
                                lvalue = lstr.Substring(50, 30)
                                tmonthcode = lvalue.Substring(4, 2) & lFncGetMonthNumber(lvalue.Substring(0, 3))
                                settleDate = GFncNoNullDate("1900/01/01")
                                MDFlag = "M"
                                If Not IsNumeric(tmonthcode) Then
                                    tmonthcode = lvalue.Substring(7, 2) & lFncGetMonthNumber(lvalue.Substring(3, 3))
                                    settleDate = GFncNoNullDate("20" & lvalue.Substring(7, 2) & "/" & lFncGetMonthNumber(lvalue.Substring(3, 3)) & "/" & _
                                                lvalue.Substring(0, 2))
                                    MDFlag = "D"
                                End If
                                mthcode = tmonthcode
                                tproduct = Replace(lvalue.Substring(7, 13).Trim, Chr(30), "-")
                                prod = Replace(tproduct, Chr(30), "-")
                                'price
                                lvalue = lstr.Substring(84, 11)
                                If (lvalue.Substring(9, 1) = "/") Then
                                    tprice = Math.Round(CDbl(lvalue.Substring(0, 7)) + (CInt(lvalue.Substring(8, 1)) / CInt(lvalue.Substring(10, 1)) / 100), 4)
                                Else
                                    If (lvalue.Trim.Length < 1) Then
                                        tprice = 0
                                    Else
                                        tprice = CDbl(lvalue)
                                    End If
                                End If
                                Try
                                    lvalue = lstr.Substring(99)
                                    'floating = CDec(lvalue)
                                    floating = Me.lfncReturnDec(lvalue)

                                Catch ex As Exception
                                    floating = 0.0
        End Try
                                If tprice = 2310 Then
                                    Dim a As Integer = 0
                                End If
                                'insert to data table
                                If (readtype = 1) Then
                                    lFncInsertNewedgeTrade(trade_date, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, MDFlag, settleDate, TransDt)
                                    lFncInsertToDataTable(ldtconfirm, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                    lFncInsertToDataTable(ldtTemp, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                ElseIf (readtype = 2) Then
                                    lFncInsertToDataTable(ldtliq, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                    lFncInsertToLIQDataTable(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, MDFlag, settleDate, LQDT)
                                ElseIf (readtype = 3) Then
                                    'lFncInsertNewedgeOP(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, MDFlag, settleDate, floating, MyTrans)
                                    lFncPrepareNewedgeOP(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, MDFlag, settleDate, floating, OPDT)
                                End If
                            End If

                        Else
                            'fee
                            If InStr(lstr, "COMMISSION") > 0 Then
                                comm = Math.Round(CDbl(GfncSubString(lstr, 99, 18)), 4)
                            ElseIf InStr(lstr, "CLEARING FEES") > 0 Then
                                clearing = Math.Round(CDbl(GfncSubString(lstr, 99, 18)), 4)
                            ElseIf InStr(lstr, "EXCHANGE FEES") > 0 Then
                                exchange = Math.Round(CDbl(GfncSubString(lstr, 99, 18)), 4)
                            ElseIf InStr(lstr, "CLOSE") > 0 Then
                                'Open position closing price
                                lvalue = lstr.Substring(84, 11)
                                Dim cPrice As Decimal = 0.0
                                If lvalue.Contains("/") Then
                                    cPrice = Math.Round(CDbl(lvalue.Substring(0, 7)) + (CDec(lvalue.Substring(8, 1)) / CDec(lvalue.Substring(10, 1)) / 100), 4)
                                Else
                                    cPrice = CDec(lvalue)
                                End If
                                UpdateClosingPrice(cPrice, OPDT, MyTrans, "Newedge")
                            ElseIf (InStr(lstr, "TOTAL POSTING") > 0) Then
                                total = Math.Round(CDbl(GfncSubString(lstr, 99, 18)), 4)
                                lFncInsertNewedgeFeeOP(trade_date, mthcode, prod, comm, clearing, exchange, total, MyTrans, "Newedge")
                            Else
                                Dim PL As Decimal = 0.0
                                'Liquid position PL
                                If lstr.Length > 84 Then
                                    If InStr(lstr.Substring(84), "SETTLEMENTS") > 0 Then
                                        lvalue = lstr.Substring(99)
                                        If lvalue.Contains("/") Then
                                            PL = Math.Round(CDbl(lvalue.Substring(0, 7)) + (CDec(lvalue.Substring(8, 1)) / CDec(lvalue.Substring(10, 1)) / 100), 4)
                                        Else
                                            'PL = Val(Replace(lvalue, ",", ""))
                                            PL = Me.lfncReturnDec(lvalue)
                                        End If
                                        UpdatePL(PL, LQDT, MyTrans, LiqHeader, "Newedge")
                                    End If
                                ElseIf lstr.Contains("*") And lstr.Length >= 49 And lstr.Length < 84 And readtype = 2 Then
                                    UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "Newedge")
                                End If
                            End If
                        End If
                    End If
                End If
                If (lstr.Trim.Length > 0) Then
                    rowcount = rowcount + 1
                    lFncInsertNewedgeConetent(trade_date, lstr, rowcount, MyTrans, "Newedge")
                End If
            Next
            For Each dr As DataRow In LQDT.Rows
                If GFncNoNullValue(dr("size")) = 0 Then
                    dr("size") = 1
                End If
            Next
            'insert contract_size into transaction table
            FncTransSize(OPDT, LQDT, TransDt)
            'insert transaction
            FncInsertTrans(TransDt, MyTrans, "Newedge")
            'insert open position
            FncInsertOP(OPDT, MyTrans, "Newedge")
            'insert liquid position and its header (header for storing the PL)
            FncInsertCP(LQDT, LiqHeader, MyTrans, "Newedge")
            'lFncMakeNewOP(ldtliq, ldtTemp)
            lFncUpdateComm(trade_date, MyTrans, "Newedge")

            'save open position
            'useless --- 2010/04/16
            'For i = 0 To (ldtTemp.Rows().Count - 1)
            '    If ((ldtTemp.Rows(i).Item(1) <> 0) Or (ldtTemp.Rows(i).Item(2) <> 0)) Then
            '        lFncInsertEmpOP(trade_date, ldtTemp.Rows(i).Item(0), ldtTemp.Rows(i).Item(1), ldtTemp.Rows(i).Item(2), _
            '                        ldtTemp.Rows(i).Item(3), ldtTemp.Rows(i).Item(4), ldtTemp.Rows(i).Item(5), MyTrans, "Newedge")
            '    End If
            'Next

            MyTrans.Commit()
            MyTrans = Nothing

        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
            End If
            doc.close()
            doc = Nothing
            word.Quit()
            releaseObject(word)
            releaseObject(doc)
            releaseObject(myWord)
            GSubWriteErrLog(ex.Message)
        Finally
            Try
                doc.close()
                doc = Nothing
                word.Quit()
                releaseObject(word)
                releaseObject(doc)
                releaseObject(myWord)
            Catch
            End Try
        End Try
        'end remarked


        'Dim word As New Microsoft.Office.Interop.Word.Application
        'Dim doc As Microsoft.Office.Interop.Word.Document = Nothing
        'Dim myWord As Microsoft.Office.Interop.Word.Range
        'Dim i As Integer = 1
        'Dim rowcount As Integer = 0
        'Dim readtype As Integer = 0
        'Dim MyTrans As SqlTransaction = Nothing


        'Dim lstr As String = ""
        'Dim mthcode As String = ""
        'Dim prod As String = ""
        'Dim comm As Double = 0
        'Dim clearing As Double = 0
        'Dim exchange As Double = 0
        'Dim total As Double = 0

        'Try
        '    doc = word.Documents.Open(filename)
        '    doc.Activate()

        '    ldtconfirm = New DataTable("confirmation")
        '    lFncCreateDataTable(ldtconfirm)
        '    ldtliq = New DataTable("tradedetail")
        '    lFncCreateDataTable(ldtliq)
        '    ldtOP = New DataTable("openposition")
        '    lFncCreateDataTable(ldtOP)
        '    ldtTemp = lFncGetEmpOP(trade_date).Copy

        '    MyTrans = GSCnSqlConn.BeginTransaction
        '    lFncDeleteImported(trade_date, MyTrans)

        '    For Each myWord In doc.Sentences

        '        lstr = myWord.Text

        '        If (InStr(lstr, "C  O  N  F  I  R  M  A  T  I  O  N") > 0) Then
        '            readtype = 1
        '        ElseIf (InStr(lstr, "P  U  R  C  H  A  S  E") > 0) Then
        '            readtype = 2
        '        ElseIf (InStr(lstr, "O  P  E  N      P  O  S  I  T  I  O  N  S") > 0) Then
        '            readtype = 3
        '        ElseIf (InStr(lstr, "THE FOLLOWING JOURNAL ENTRIES HAVE BEEN POSTED TO YOUR ACCOUNT") > 0) Then
        '            readtype = 4
        '        ElseIf (InStr(lstr, "** US DOLLAR **       *BASE CONVERTED TTL*") > 0) Then
        '            Exit For
        '        Else
        '            If (lstr.Trim.Length > 0) Then
        '                Dim lvalue As String = ""
        '                Dim isDate As Boolean = True
        '                Dim tdate As Date = Nothing
        '                Dim tbuy As Long = 0
        '                Dim tsell As Long = 0
        '                Dim tmonthcode As String = ""
        '                Dim tproduct As String = ""
        '                Dim tprice As Double = 0

        '                Try
        '                    tdate = CDate(lstr.Substring(6, 2) & "/" & lFncGetMonthNumber(lstr.Substring(3, 3)) & _
        '                            "/" & lstr.Substring(1, 2))
        '                    isDate = True
        '                Catch ex As Exception
        '                    isDate = False
        '                End Try

        '                If (isDate = True) Then 'trade
        '                    'buy
        '                    lvalue = lstr.Substring(20, 14)
        '                    If (lvalue.Trim.Length > 0) Then
        '                        tbuy = CLng(lvalue)
        '                    Else
        '                        tbuy = 0
        '                    End If
        '                    'sell
        '                    lvalue = lstr.Substring(35, 14)
        '                    If (lvalue.Trim.Length > 0) Then
        '                        tsell = CLng(lvalue)
        '                    Else
        '                        tsell = 0
        '                    End If
        '                    'desc
        '                    lvalue = lstr.Substring(50, 30)
        '                    tmonthcode = lvalue.Substring(4, 2) & lFncGetMonthNumber(lvalue.Substring(0, 3))
        '                    mthcode = tmonthcode
        '                    tproduct = lvalue.Substring(7, 13).Trim
        '                    prod = tproduct
        '                    'price
        '                    lvalue = lstr.Substring(84, 11)
        '                    If (lvalue.Substring(9, 1) = "/") Then
        '                        tprice = Math.Round(CDbl(lvalue.Substring(0, 7)) + (CInt(lvalue.Substring(8, 1)) / CInt(lvalue.Substring(10, 1)) / 100), 4)
        '                    Else
        '                        If (lvalue.Trim.Length < 1) Then
        '                            tprice = 0
        '                        Else
        '                            tprice = CDbl(lvalue)
        '                        End If
        '                    End If

        '                    'insert to data table
        '                    If (readtype = 1) Then
        '                        lFncInsertNewedgeTrade(tdate, tbuy, tsell, tmonthcode, tproduct, tprice, MyTrans)
        '                        lFncInsertToDataTable(ldtconfirm, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
        '                        lFncInsertToDataTable(ldtTemp, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
        '                    ElseIf (readtype = 2) Then
        '                        lFncInsertToDataTable(ldtliq, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
        '                    ElseIf (readtype = 3) Then
        '                        lFncInsertNewedgeOP(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, MyTrans)
        '                    End If
        '                Else
        '                    'fee
        '                    If (InStr(lstr, "COMMISSION") > 0) Then
        '                        comm = Math.Round(CDbl(lstr.Substring(99, 18)), 4)
        '                    ElseIf (InStr(lstr, "CLEARING FEES") > 0) Then
        '                        clearing = Math.Round(CDbl(lstr.Substring(99, 18)), 4)
        '                    ElseIf (InStr(lstr, "EXCHANGE FEES") > 0) Then
        '                        exchange = Math.Round(CDbl(lstr.Substring(99, 18)), 4)
        '                    ElseIf (InStr(lstr, "TOTAL POSTING") > 0) Then
        '                        total = Math.Round(CDbl(lstr.Substring(99, 18)), 4)

        '                        lFncInsertNewedgeFeeOP(trade_date, mthcode, prod, comm, clearing, exchange, total, MyTrans)
        '                    End If
        '                End If
        '            End If
        '        End If

        '        If (lstr.Trim.Length > 0) Then
        '            rowcount = rowcount + 1
        '            lFncInsertNewedgeConetent(trade_date, lstr, rowcount, MyTrans)
        '        End If
        '    Next

        '    lFncMakeNewOP(ldtliq, ldtTemp)
        '    lFncUpdateComm(trade_date, MyTrans)

        '    'save open position
        '    For i = 0 To (ldtTemp.Rows().Count - 1)
        '        If ((ldtTemp.Rows(i).Item(1) <> 0) Or (ldtTemp.Rows(i).Item(2) <> 0)) Then
        '            lFncInsertEmpOP(trade_date, ldtTemp.Rows(i).Item(0), ldtTemp.Rows(i).Item(1), ldtTemp.Rows(i).Item(2), _
        '                            ldtTemp.Rows(i).Item(3), ldtTemp.Rows(i).Item(4), ldtTemp.Rows(i).Item(5), MyTrans)
        '        End If
        '    Next

        '    MyTrans.Commit()
        '    MyTrans = Nothing

        'Catch ex As Exception
        '    If GSCnLiqConn.State <> ConnectionState.Closed Then
        '        If (MyTrans IsNot Nothing) Then
        '            MyTrans.Rollback()
        '        End If
        '    End If
        '    GSubWriteErrLog(ex.Message)
        'Finally
        '    Try
        '        doc = Nothing
        '        word.Quit()
        '    Catch

        '    End Try
        'End Try
        Return Nothing
    End Function

    Protected Friend Function lFncMakeNewOP(ByRef ldtliq As DataTable, ByRef ldtTemp As DataTable)
        Dim i As Integer
        Dim j As Integer
        For i = 0 To (ldtliq.Rows.Count - 1)
            Dim tbuy As Long = ldtliq.Rows(i).Item(1)
            Dim tsell As Long = ldtliq.Rows(i).Item(2)

            For j = 0 To (ldtTemp.Rows.Count - 1)
                If ((ldtliq.Rows(i).Item(0) = ldtTemp.Rows(j).Item(0)) _
                    And (ldtliq.Rows(i).Item(3).ToString.Trim() = ldtTemp.Rows(j).Item(3).ToString.Trim()) _
                    And (ldtliq.Rows(i).Item(4).ToString.Trim() = ldtTemp.Rows(j).Item(4).ToString.Trim()) _
                    And (Math.Round(ldtliq.Rows(i).Item(5), 4) = Math.Round(ldtTemp.Rows(j).Item(5), 4))) Then
                    If (tbuy <> 0) Then
                        If (tbuy <= ldtTemp.Rows(j).Item(1)) Then
                            ldtTemp.Rows(j).Item(1) = ldtTemp.Rows(j).Item(1) - tbuy
                            Exit For
                        Else
                            ldtTemp.Rows(j).Item(1) = 0
                            tbuy = tbuy - ldtTemp.Rows(j).Item(1)
                        End If
                    Else
                        If (tsell <= ldtTemp.Rows(j).Item(2)) Then
                            ldtTemp.Rows(j).Item(2) = ldtTemp.Rows(j).Item(2) - tsell
                            Exit For
                        Else
                            ldtTemp.Rows(j).Item(2) = 0
                            tsell = tsell - ldtTemp.Rows(j).Item(2)
                        End If
                    End If
                End If
            Next
        Next
        Return Nothing
    End Function

    Protected Friend Sub lFncInsertToDataTable(ByRef dt As DataTable, ByVal tdate As String, ByVal buy As Long, ByVal sell As Long, _
        ByVal monthcode As String, ByVal product As String, ByVal price As Double)
        Dim row As DataRow
        row = dt.NewRow()
        row("tdate") = tdate
        row("buy") = buy
        row("sell") = sell
        row("monthcode") = monthcode
        row("product") = product
        row("price") = price
        dt.Rows.Add(row)
    End Sub

    Protected Friend Sub lFncInsertToLIQDataTable(ByVal tdate As String, ByVal odate As Date, ByVal buy As Long, ByVal sell As Long, ByVal monthcode As String, _
        ByVal product As String, ByVal tprice As Double, ByVal dStrike As Double, ByVal sCallPut As String, ByVal MDFlag As String, ByVal settleDate As Date, ByRef dt As DataTable)
        Dim row As DataRow = Nothing
        row = dt.NewRow()
        row("tdate") = GFncNoNullDate(tdate)
        row("odate") = GFncNoNullDate(odate)
        row("buy") = buy
        row("sell") = sell
        row("monthcode") = monthcode
        row("product") = product
        row("price") = tprice
        row("strike") = dStrike
        row("callput") = sCallPut
        row("settle_date") = GFncNoNullDate(settleDate)
        row("monthly_daily") = MDFlag
        dt.Rows.Add(row)
    End Sub
    Protected Friend Sub lFncInsertToLIQDataTable(ByVal tdate As String, ByVal odate As Date, ByVal buy As Long, ByVal sell As Long, ByVal monthcode As String, _
        ByVal product As String, ByVal tprice As Double, ByVal dStrike As Double, ByVal sCallPut As String, ByVal floating As Double, ByVal MDFlag As String, ByVal settleDate As Date, ByRef dt As DataTable)
        Dim row As DataRow = Nothing
        row = dt.NewRow()
        row("tdate") = GFncNoNullDate(tdate)
        row("odate") = GFncNoNullDate(odate)
        row("buy") = buy
        row("sell") = sell
        row("monthcode") = monthcode
        row("product") = product
        row("price") = tprice
        row("strike") = dStrike
        row("callput") = sCallPut
        row("PL") = floating
        row("settle_date") = GFncNoNullDate(settleDate)
        row("monthly_daily") = MDFlag
        dt.Rows.Add(row)
    End Sub
    Protected Friend Function lFncInsertEmpOP(ByVal tdate As String, ByVal odate As Date, ByVal buy As Long, ByVal sell As Long, _
                                              ByVal monthcode As String, ByVal product As String, ByVal tprice As Double, _
                                              ByVal MyTrans As SqlTransaction, ByVal pCounterParty As String) As Boolean

        Dim lstrSQL As String

        lstrSQL = "insert into newedge_emp_op(tdate, odate, buy, sell, monthcode, product, price, counterparty) values ('" & _
                        tdate & "','" & Format(odate, "yyyy/MM/dd") & "', " & CStr(buy) & ", " & CStr(sell) & ", '" & monthcode & "', '" & product & _
                        "', " & CStr(tprice) & ", '" & pCounterParty & "')"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    'Protected Friend Function lFncInsertNewedgeOP(ByVal tdate As String, ByVal odate As Date, ByVal buy As Long, ByVal sell As Long, _
    '    ByVal monthcode As String, ByVal product As String, ByVal tprice As Double, ByVal MDFlag As String, ByVal settleDate As Date, _
    '    ByVal floating As Decimal, ByVal MyTrans As SqlTransaction) As Boolean
    '    Dim lstrSQL As String
    '    lstrSQL = "insert into newedge_cap_op(tdate, odate, buy, sell, monthcode, product, price, monthly_daily, settle_Date, floating) " & _
    '        "values ('" & tdate & "','" & Format(odate, "yyyy/MM/dd") & "', " & CStr(buy) & ", " & CStr(sell) & ", '" & monthcode & "', '" & _
    '        product & "', " & CStr(tprice) & ", '" & MDFlag & "', '" & Format(settleDate, "yyyy/MM/dd") & "', " & floating & ")"
    '    Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    'End Function

    Protected Friend Sub lFncPrepareMarexOP(ByVal tdate As String, ByVal odate As Date, ByVal buy As Long, ByVal sell As Long, _
        ByVal monthcode As String, ByVal product As String, ByVal tprice As Double, ByVal dStrike As Double, ByVal sCallPut As String, ByVal MDFlag As String, ByVal settleDate As Date, _
        ByVal floating As Decimal, ByRef OPDT As DataTable, ByRef LQDT As DataTable)
        Dim dr As DataRow = OPDT.NewRow
        dr("tdate") = GFncNoNullDate(tdate)
        dr("odate") = GFncNoNullDate(odate)
        dr("buy") = buy
        dr("sell") = sell
        dr("product") = product.Trim
        dr("monthcode") = monthcode.Trim
        dr("price") = tprice
        dr("strike") = dStrike
        dr("callput") = sCallPut
        dr("monthly_daily") = MDFlag.Trim
        dr("settle_date") = GFncNoNullDate(settleDate)
        dr("floating") = floating
        If GFncNoNullValue(dr("size")) = 0 Then
            Dim tempDr() As DataRow = LQDT.Select("product = '" & dr("product") & "' and strike = " & dr("strike") & " and callput='" & dr("callput") & "' and size > 0", "tdate desc")
            If tempDr.Length > 0 Then
                dr("size") = GFncNoNullValue(tempDr(0).Item("size"))
            Else
                If GFncNoNullValue(dr("size")) = 0 And GFncNoNullValue(dr("floating")) = 0 Then
                    tempDr = LQDT.Select("product = '" & dr("product") & "' and monthcode = '" & dr("monthcode") & "' and size > 0 and callput=''", "tdate desc")
                    If tempDr.Length > 0 Then
                        dr("size") = GFncNoNullValue(tempDr(0).Item("size"))
                    End If
                End If
            End If
        End If
        OPDT.Rows.Add(dr)
    End Sub

    Protected Friend Sub lFncPrepareNewedgeOP(ByVal tdate As String, ByVal odate As Date, ByVal buy As Long, ByVal sell As Long, _
        ByVal monthcode As String, ByVal product As String, ByVal tprice As Double, ByVal dStrike As Double, ByVal sCallPut As String, ByVal MDFlag As String, ByVal settleDate As Date, _
        ByVal floating As Decimal, ByRef OPDT As DataTable)
        Dim dr As DataRow = OPDT.NewRow
        dr("tdate") = GFncNoNullDate(tdate)
        dr("odate") = GFncNoNullDate(odate)
        dr("buy") = buy
        dr("sell") = sell
        dr("product") = product.Trim
        dr("monthcode") = monthcode.Trim
        dr("price") = tprice
        dr("strike") = dStrike
        dr("callput") = sCallPut
        dr("monthly_daily") = MDFlag.Trim
        dr("settle_date") = GFncNoNullDate(settleDate)
        dr("floating") = floating
        OPDT.Rows.Add(dr)
    End Sub

    Private Sub UpdateClosingPrice(ByVal cPrice As Decimal, ByRef dt As DataTable, ByVal mytrans As SqlTransaction, ByVal pCounterParty As String)

        ' this function need to update stock option floating PL as well because floating PL is calculating wrong in marex which its calculation is closing x contract size but the correct calculation is (open - close) x contract size

        Dim flag As Boolean = False
        For Each dr As DataRow In dt.Rows
            'If dr("product").ToString.Contains("CME  EUR STYLE CAD") And cPrice = 0.6 And dr("buy") = 2 Then
            '    Dim a = 0
            'End If

            If IsDBNull(dr("closing_price")) Then
                dr("closing_price") = cPrice
                If GFncNoNullValue(dr("closing_price")) - GFncNoNullValue(dr("price")) <> 0 Then
                    If IsDBNull(dr("size")) Then
                        If (dr("strike") <> 0 And dr("callput") <> "") Then
                            If (GFncNoNullValue(dr("closing_price")) = 0) Then
                                dr("size") = 0
                            Else
                                Dim temSize = Math.Abs((GFncNoNullValue(dr("floating")) / GFncNoNullValue(dr("closing_price"))) / IIf(GFncNoNullValue(dr("buy")) = 0, GFncNoNullValue(dr("sell")), GFncNoNullValue(dr("buy"))))

                                dr("size") = If((Math.Truncate(temSize) Mod 10 <> 0 And Math.Truncate(temSize) Mod 10 <> 5 And temSize > 10), Math.Round(temSize / 10) * 10, Math.Round(temSize))
                            End If

                        Else
                            Dim temSize = Math.Abs((GFncNoNullValue(dr("floating")) / (GFncNoNullValue(dr("closing_price")) - GFncNoNullValue(dr("price")))) / IIf(GFncNoNullValue(dr("buy")) = 0, GFncNoNullValue(dr("sell")), GFncNoNullValue(dr("buy"))))

                            dr("size") = If((Math.Truncate(temSize) Mod 10 <> 0 And Math.Truncate(temSize) Mod 10 <> 5 And temSize > 10), Math.Round(temSize / 10) * 10, Math.Round(temSize))
                        End If
                    End If

                    If GFncNoNullValue(dr("size")) < 0 Then
                        dr("size") = GFncNoNullValue(dr("size")) * -1
                    End If
                    If (dr("strike") <> 0 And dr("callput") <> "") Then ' calculate floating PL for options

                        If (dr("buy") > 0 And dr("callput") = "C") Or (dr("buy") > 0 And dr("callput") = "P") Then
                            dr("floating") = (GFncNoNullValue(dr("size")) * (GFncNoNullValue(dr("closing_price")) - GFncNoNullValue(dr("price")))) * _
                                            IIf(GFncNoNullValue(dr("buy")) = 0, GFncNoNullValue(dr("sell")), GFncNoNullValue(dr("buy")))
                        ElseIf (dr("sell") > 0 And dr("callput") = "P") Or (dr("sell") > 0 And dr("callput") = "C") Then
                            dr("floating") = (GFncNoNullValue(dr("size")) * (GFncNoNullValue(dr("closing_price")) - GFncNoNullValue(dr("price")))) * _
                                            IIf(GFncNoNullValue(dr("buy")) = 0, GFncNoNullValue(dr("sell")), GFncNoNullValue(dr("buy"))) * -1
                        End If
                    End If
                Else
                    flag = True
                End If
            End If
        Next
        If flag Then ' to handle if open - close = 0 or floatingPL is 0
            Dim rowCount As Integer = 0
            For Each dr As DataRow In dt.Rows
                rowCount += 1
                Dim product As String = GFncNoNullString(dr("product")).Trim
                Dim mCode As String = GFncNoNullString(dr("monthcode")).Trim
                If IsDBNull(dr("size")) Then
                    If rowCount > 1 And rowCount < dt.Rows.Count Then
                        If GFncNoNullString(dt.Rows(rowCount - 2).Item("product")).Trim = product And _
                            GFncNoNullString(dt.Rows(rowCount - 2).Item("monthcode")).Trim = mCode Then
                            dr("size") = dt.Rows(rowCount - 2).Item("size")
                        ElseIf GFncNoNullString(dt.Rows(rowCount).Item("product")).Trim = product And _
                            GFncNoNullString(dt.Rows(rowCount).Item("monthcode")).Trim = mCode Then
                            dr("size") = dt.Rows(rowCount).Item("size")
                        End If
                    ElseIf rowCount = 1 Then
                        If dt.Rows.Count > 1 Then
                            If GFncNoNullString(dt.Rows(rowCount).Item("product")).Trim = product And _
                                                       GFncNoNullString(dt.Rows(rowCount).Item("monthcode")).Trim = mCode Then
                                dr("size") = dt.Rows(rowCount).Item("size")
                            End If
                        End If
                    ElseIf rowCount = dt.Rows.Count Then
                        If GFncNoNullString(dt.Rows(rowCount - 2).Item("product")).Trim = product And _
                            GFncNoNullString(dt.Rows(rowCount - 2).Item("monthcode")).Trim = mCode Then
                            dr("size") = dt.Rows(rowCount - 2).Item("size")
                        End If
                    End If
                    If IsDBNull(dr("size")) Then
                        Dim str As String = "select top 1 contract_size from newedge_cap_trade_hist where product = '" & product & "' and monthcode = '" & mCode & "' and counterparty = '" & pCounterParty & "'"
                        Dim rdt As DataTable = GFncRtnDS(GSCnSqlConn, str, mytrans).Tables(0)
                        If rdt.Rows.Count > 0 Then
                            dr("size") = GFncNoNullValue(rdt.Rows(0).Item("contract_size"))
                        Else
                            str = "select top 1 contract_size from newedge_cap_trade_hist where product = '" & product & "' and counterparty = '" & pCounterParty & "'"
                            rdt = GFncRtnDS(GSCnSqlConn, str, mytrans).Tables(0)
                            If rdt.Rows.Count > 0 Then
                                dr("size") = GFncNoNullValue(rdt.Rows(0).Item("contract_size"))
                            Else
                                dr("size") = 0
                            End If

                        End If
                    End If

                    If (dr("strike") <> 0 And dr("callput") <> "") Then
                        dr("floating") = 0
                    End If
                Else
                    If GFncNoNullString(dr.Item("product")).Trim = product And
                            GFncNoNullString(dr.Item("monthcode")).Trim = mCode And
                            GFncNoNullValue(dr("closing_price")) = cPrice And
                            GFncNoNullValue(dr("closing_price")) - GFncNoNullValue(dr("price")) = 0 And
                            GFncNoNullValue(dr("strike")) <> 0 And
                            GFncNoNullString(dr("callput")) <> "" Then
                        dr("floating") = 0
                    End If
                End If
            Next
        End If
    End Sub

    Private Sub UpdatePL(ByVal PL As Decimal, ByRef dt As DataTable, ByVal mytrans As SqlTransaction, ByRef hDt As DataTable, ByVal pCounterParty As String)
        Dim totalBuy As Decimal = 0
        Dim totalSell As Decimal = 0
        Dim product As String = ""
        Dim mCode As String = ""
        Dim sDate As Date = Nothing
        Dim tdate As Date = Nothing
        Dim strike As Decimal = 0
        Dim callput As String = ""
        Dim MDFlag As String = ""
        For Each dr As DataRow In dt.Rows
            product = GFncNoNullString(dr("product")).Trim
            strike = GFncNoNullValue(dr("strike"))
            callput = GFncNoNullString(dr("callput")).Trim
            If IsDBNull(dr("size")) Then
                product = GFncNoNullString(dr("product")).Trim
                mCode = GFncNoNullString(dr("monthcode")).Trim
                sDate = GFncNoNullDate(dr("settle_date"))
                tdate = GFncNoNullDate(dr("tdate"))
                MDFlag = GFncNoNullString(dr("monthly_daily")).Trim
                'strike = GFncNoNullValue(dr("strike"))
                'callput = GFncNoNullString(dr("callput")).Trim
                Exit For
            ElseIf GFncNoNullValue(dr("size")) = 0 Then
                Dim tempDr() As DataRow = dt.Select("product = '" & product & "' and strike = " & strike & " and callput='" & callput & "' and size > 0", "")
                If tempDr.Length > 0 Then
                    dr("size") = GFncNoNullValue(tempDr(0).Item("size"))
                End If
            End If
        Next
        For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("size")) Then
                If GFncNoNullValue(dr("buy")) <> 0 Then
                    totalBuy += GFncNoNullValue(dr("price")) * GFncNoNullValue(dr("buy"))
                ElseIf GFncNoNullValue(dr("sell")) <> 0 Then
                    totalSell += GFncNoNullValue(dr("price")) * GFncNoNullValue(dr("sell"))
                End If
            End If
        Next
        Dim size As Integer = 0
        If totalSell <> totalBuy Then
            size = Math.Round(PL / (totalSell - totalBuy))
            If size < 0 Then
                size *= (-1)
            End If
        Else
            Dim str As String = "select contract_size from newedge_cap_trade_hist where product = '" & product & "' and strike = " & strike & " and callput='" & callput & "' and monthcode = '" & mCode & "' and counterparty = '" & pCounterParty & "'"
            Dim rdt As DataTable = GFncRtnDS(GSCnSqlConn, str, mytrans).Tables(0)
            If rdt.Rows.Count > 0 Then
                size = GFncNoNullString(rdt.Rows(0).Item("contract_size"))
            Else
                str = " select a.contract_size from (select contract_size, count(*) as noRec from newedge_cap_trade_hist " & _
                    "where product = 'GOLD-COMEX' and contract_size > 0 group by contract_size) a where a.noRec = (select max(b.noRec) from " & _
                    "(select contract_size, count(*) as noRec from newedge_cap_trade_hist where product = 'GOLD-COMEX' and contract_size > 0 " & _
                    "group by contract_size) b)"
                rdt = GFncRtnDS(GSCnSqlConn, str, mytrans).Tables(0)
                If rdt.Rows.Count > 0 Then
                    size = GFncNoNullString(rdt.Rows(0).Item("contract_size"))
                Else
                    Dim rDr() As DataRow = dt.Select("product = '" & product & "' and size > 0", "")
                    If rDr.Length > 0 Then
                        size = GFncNoNullString(rDr(0).Item("size"))
                    Else
                        size = 0
                    End If
                End If
            End If
        End If
        Dim ndr As DataRow = hDt.NewRow
        ndr("tdate") = GFncNoNullDate(tdate)
        ndr("product") = product
        ndr("monthcode") = mCode
        ndr("settle_date") = GFncNoNullDate(sDate)
        ndr("PL") = PL
        ndr("monthly_daily") = MDFlag
        ndr("product") = product
        ndr("strike") = strike
        ndr("callput") = callput
        ndr("size") = size
        hDt.Rows.Add(ndr)
        For Each dr As DataRow In dt.Rows
            If IsDBNull(dr("size")) Then
                dr("size") = size
            End If
        Next

    End Sub
    Private Sub OptionCloseOutUpdatePL(ByRef dt As DataTable, ByVal mytrans As SqlTransaction, ByRef hDt As DataTable, ByVal pCounterParty As String)
        Dim totalBuy As Decimal = 0
        Dim totalSell As Decimal = 0
        Dim product As String = ""
        Dim mCode As String = ""
        Dim sDate As Date = Nothing
        Dim tdate As Date = Nothing

        Dim strike As Decimal = 0
        Dim callput As String = ""

        Dim MDFlag As String = ""
        Dim PL As Decimal = 0
        Dim size As Integer = 0
        Dim index As Integer = 0
        Dim iNextRow As Integer = 0

        For Each dr As DataRow In dt.Rows

            product = GFncNoNullString(dr("product")).Trim
            If IsDBNull(dr("size")) Then

                If GFncNoNullValue(dr("strike")) <> 0 And GFncNoNullString(dr("callput")) <> "" Then
                    product = GFncNoNullString(dr("product")).Trim
                    mCode = GFncNoNullString(dr("monthcode")).Trim
                    sDate = GFncNoNullDate(dr("settle_date"))
                    tdate = GFncNoNullDate(dr("tdate"))
                    MDFlag = GFncNoNullString(dr("monthly_daily")).Trim
                    callput = GFncNoNullString(dr("callput")).Trim
                    If GFncNoNullValue(dr("price")) > 0 Then
                        size = GFncNoNullValue(dr("PL")) / GFncNoNullValue(dr("price")) / IIf(GFncNoNullValue(dr("buy")) = 0, GFncNoNullValue(dr("sell")), GFncNoNullValue(dr("buy")))
                    End If

                    strike = GFncNoNullValue(dr("strike"))

                    If size < 0 Then
                        size *= (-1)
                    End If
                    dr("size") = size

                    PL += GFncNoNullValue(dr("PL"))
                    iNextRow = index + 1
                    If (iNextRow < dt.Rows.Count) Then  ' if not end of table
                        If dt.Rows(iNextRow).Item("strike") <> strike Then

                            Dim ndr As DataRow = hDt.NewRow
                            ndr("tdate") = GFncNoNullDate(tdate)
                            ndr("product") = product
                            ndr("monthcode") = mCode
                            ndr("settle_date") = GFncNoNullDate(sDate)
                            ndr("PL") = PL
                            ndr("monthly_daily") = MDFlag
                            ndr("product") = product
                            ndr("strike") = strike
                            ndr("callput") = callput
                            ndr("size") = size
                            hDt.Rows.Add(ndr)
                            PL = 0 ' reset the PL to 0
                        End If
                    Else 'if this row is end of table
                        Dim ndr As DataRow = hDt.NewRow
                        ndr("tdate") = GFncNoNullDate(tdate)
                        ndr("product") = product
                        ndr("monthcode") = mCode
                        ndr("settle_date") = GFncNoNullDate(sDate)
                        ndr("PL") = PL
                        ndr("monthly_daily") = MDFlag
                        ndr("product") = product
                        ndr("strike") = strike
                        ndr("callput") = callput
                        ndr("size") = size
                        hDt.Rows.Add(ndr)
                    End If



                ElseIf GFncNoNullValue(dr("size")) = 0 Then
                    Dim tempDr() As DataRow = dt.Select("product = '" & product & "' and strike = " & strike & " and callput='" & callput & "' and size > 0", "")
                    If tempDr.Length > 0 Then
                        dr("size") = GFncNoNullValue(tempDr(0).Item("size"))
                    End If
                End If

            End If
            index = index + 1
        Next



    End Sub

    Protected Friend Function lFncUpdateComm(ByVal tdate As String, ByVal MyTrans As SqlTransaction, ByVal pCounterParty As String) As Boolean
        Dim lstrSQL As String
        lstrSQL = "update newedge_cap_trade_hist " & _
                        "set comm = ((case when period = 'Floor' then floor_comm else electronic_comm end) * (buy + sell)), " & _
                        "clearing = ((case when period = 'Floor' then floor_clearing else electronic_clearing end) * (buy + sell)), " & _
                        "levy = ((case when period = 'Floor' then floor_levy else electronic_levy end) * (buy + sell)) " & _
                        "from newedge_commod " & _
                        "where newedge_cap_trade_hist.product = newedge_commod.commodity " & _
                        "and tdate = '" & tdate & "' and newedge_cap_trade_hist.counterparty = '" & pCounterParty & "'"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
    End Function

    Protected Function FncInsertTrans(ByVal dt As DataTable, ByVal MyTrans As SqlTransaction, ByVal pCounterParty As String) As Boolean
        Dim str As String = ""
        For Each dr As DataRow In dt.Rows
            str = "insert into newedge_cap_trade_hist(tdate, buy, sell, monthcode, product, price, period, monthly_daily, settle_Date, contract_size, counterparty, strike, callput) values " & _
                "('" & Format(GFncNoNullDate(dr("tdate")), "yyyy/MM/dd") & "', " & GFncNoNullValue(dr("buy")) & ", " & GFncNoNullValue(dr("sell")) & ", '" & _
                GFncNoNullString(dr("monthcode")).Trim & "', '" & GFncNoNullString(GFncSqlQuote(dr("product"))).Trim & "', " & GFncNoNullValue(dr("price")) & ", 'Electronic', '" & _
                GFncNoNullString(dr("monthly_daily")).Trim & "', '" & Format(GFncNoNullDate(dr("settle_date")), "yyyy/MM/dd") & "', " & GFncNoNullValue(dr("size")) & ", '" & pCounterParty & "' , " & GFncNoNullValue(dr("strike")) & ", '" & GFncNoNullString(dr("callput")).Trim & "')"
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
        Next
    End Function

    Private Sub FncInsertOP(ByVal dt As DataTable, ByVal mytrans As SqlTransaction, ByVal pCounterParty As String)
        Dim str As String = ""
        For Each dr As DataRow In dt.Rows
            str = "insert into newedge_cap_op(tdate, odate, buy, sell, monthcode, product, price, monthly_daily, settle_Date, floating, " & _
                "closing_price, contract_size, counterparty, strike, callput) values ('" & Format(GFncNoNullDate(dr("tdate")), "yyyy/MM/dd") & "', '" & Format(GFncNoNullDate(dr("odate")), _
                "yyyy/MM/dd") & "', " & GFncNoNullValue(dr("buy")) & ", " & GFncNoNullValue(dr("sell")) & ", '" & _
                GFncNoNullString(dr("monthcode")).Trim & "', '" & GFncNoNullString(GFncSqlQuote(dr("product"))).Trim & "', " & GFncNoNullValue(dr("price")) & _
                ", '" & GFncNoNullString(dr("monthly_daily")).Trim & "', '" & Format(GFncNoNullDate(dr("settle_date")), "yyyy/MM/dd") & "', " & _
                GFncNoNullValue(dr("floating")) & ", " & GFncNoNullValue(dr("closing_price")) & ", " & GFncNoNullValue(dr("size")) & ", '" & pCounterParty & "', " & GFncNoNullValue(dr("strike")) & ", '" & GFncNoNullString(dr("callput")).Trim & "')"
            GFncRunSQL(GSCnSqlConn, mytrans, str)
        Next
    End Sub

    'private sub FncInsertLiqHeader(byval dt as DataTable, byval mytrans as SqlTransaction)

    Private Sub FncInsertCP(ByVal dt As DataTable, ByVal hDt As DataTable, ByVal mytrans As SqlTransaction, ByVal pCounterParty As String)
        Dim str As String = ""
        Dim tdate As Date = Nothing
        Dim monthcode As String = ""
        Dim sDate As Date = Nothing
        Dim MDFlag As String = ""
        Dim product As String = ""
        Dim strike As String = ""
        Dim callput As String = ""
        Dim pl As Decimal = 0.0
        Dim size As Decimal = 0.0
        Dim liqID As Integer = -1
        Dim dr() As DataRow = Nothing
        For Each hDr As DataRow In hDt.Rows

            tdate = GFncNoNullDate(hDr("tdate"))
            monthcode = GFncNoNullString(hDr("monthcode")).Trim
            sDate = GFncNoNullDate(hDr("settle_date"))
            MDFlag = GFncNoNullString(hDr("monthly_daily")).Trim
            product = GFncNoNullString(hDr("product")).Trim
            strike = GFncNoNullString(hDr("strike"))
            callput = GFncNoNullString(hDr("callput")).Trim
            pl = GFncNoNullValue(hDr("pl"))
            size = GFncNoNullValue(hDr("size"))

            str = "insert into newedge_liq_header (tdate, monthcode, settle_date, monthly_daily, product, PL, contract_size, counterparty, strike, callput) values ('" & Format(tdate, _
                "yyyy/MM/dd") & "', '" & monthcode & "', '" & Format(sDate, "yyyy/MM/dd") & "', '" & MDFlag & "', '" & product & "', " & pl & ", " & size & ", '" & pCounterParty & "', " & strike & ",'" & callput & "')"
            GFncRunSQL(GSCnSqlConn, mytrans, str)
            str = "select nid from newedge_liq_header where tdate = '" & Format(tdate, "yyyy/MM/dd") & "' and monthcode = '" & monthcode & _
                "' and settle_date = '" & Format(sDate, "yyyy/MM/dd") & "' and monthly_daily = '" & MDFlag & "' and product = '" & product & "' and PL = " & pl & " and strike = " & strike & " and callput = '" & callput & "'"
            Dim liqDt As DataTable = GFncRtnDS(GSCnSqlConn, str, mytrans).Tables(0)
            If liqDt.Rows.Count > 0 Then
                liqID = GFncNoNullValue(liqDt.Rows(0).Item("nid"))
                dr = dt.Select("tdate = '" & Format(tdate, "yyyy/MM/dd") & "' and monthcode = '" & monthcode & "' and settle_date = '" & _
                    Format(sDate, "yyyy/MM/dd") & "' and size = " & size & " and product = '" & product & "' and monthly_daily = '" & MDFlag & "' and strike=" & strike & " and callput='" & callput & "'", "")
                For i As Integer = 0 To dr.Length - 1
                    str = "insert into newedge_cap_cp(tdate, odate, buy, sell, monthcode, product, price, monthly_daily, settle_Date, contract_size, " & _
                        "liq_id, counterparty, strike, callput) values ('" & Format(GFncNoNullDate(dr(i).Item("tdate")), "yyyy/MM/dd") & "', '" & _
                        Format(GFncNoNullDate(dr(i).Item("odate")), "yyyy/MM/dd") & "', " & GFncNoNullValue(dr(i).Item("buy")) & ", " & _
                        GFncNoNullValue(dr(i).Item("sell")) & ", '" & GFncNoNullString(dr(i).Item("monthcode")).Trim & "', '" & _
                        GFncNoNullString(dr(i).Item("product")).Trim & "', " & GFncNoNullValue(dr(i).Item("price")) & ", '" & _
                        GFncNoNullString(dr(i).Item("monthly_daily")).Trim & "', '" & Format(GFncNoNullDate(dr(i).Item("settle_date")), "yyyy/MM/dd") & _
                        "', " & GFncNoNullValue(dr(i).Item("size")) & ", " & liqID & ", '" & pCounterParty & "', " & GFncNoNullString(dr(i)("strike")) & ",  '" & GFncNoNullString(dr(i)("callput")).Trim & "')"
                    'str = "insert into newedge_cap_cp(odate, buy, sell, price, liq_id) values ('" & _
                    '    Format(GFncNoNullDate(dr(i).Item("odate")), "yyyy/MM/dd") & "', " & GFncNoNullValue(dr(i).Item("buy")) & ", " & _
                    '    GFncNoNullValue(dr(i).Item("sell")) & ", " & GFncNoNullValue(dr(i).Item("price")) & ", " & liqID & ")"
                    GFncRunSQL(GSCnSqlConn, mytrans, str)
                Next
            End If

        Next
    End Sub

    Private Sub FncTransSize(ByVal opdt As DataTable, ByVal lqdt As DataTable, ByRef dt As DataTable)
        Dim tDate As Date = Nothing
        Dim monthcode As String = ""
        Dim product As String = ""
        Dim price As Decimal = 0.0
        Dim MDFlag As String = ""
        Dim sDate As Date = Nothing
        Dim opDr() As DataRow = Nothing
        Dim lqDr() As DataRow = Nothing
        For Each dr As DataRow In dt.Rows
            tDate = GFncNoNullDate(dr("tdate"))
            monthcode = GFncNoNullString(dr("monthcode")).Trim
            product = GFncNoNullString(dr("product")).Trim
            MDFlag = GFncNoNullString(dr("monthly_daily")).Trim
            sDate = GFncNoNullDate(dr("settle_date"))
            opDr = opdt.Select("tDate = '" & Format(tDate, "yyyy/MM/dd") & "' and monthcode = '" & monthcode & "' and product = '" & GFncSqlQuote(product) & _
                "' and settle_date = '" & Format(sDate, "yyyy/MM/dd") & "' and monthly_daily = '" & MDFlag & "'", "")
            lqDr = lqdt.Select("tDate = '" & Format(tDate, "yyyy/MM/dd") & "' and monthcode = '" & monthcode & "' and product = '" & GFncSqlQuote(product) & _
                "' and settle_date = '" & Format(sDate, "yyyy/MM/dd") & "' and monthly_daily = '" & MDFlag & "'", "")
            If opDr.Length > 0 Then
                dr("size") = GFncNoNullValue(opDr(0).Item("size"))
            ElseIf lqDr.Length > 0 Then
                dr("size") = GFncNoNullValue(lqDr(0).Item("size"))
            End If
        Next
    End Sub

    Protected Friend Function lFncInsertNewedgeConetent(ByVal tdate As String, ByVal content As String, _
                                                        ByVal rowcount As Integer, ByVal MyTrans As SqlTransaction, ByVal pCounterParty As String) As Boolean

        Dim lstrSQL As String

        lstrSQL = "insert into newedge_content(tdate, content, seq, counterparty) values ('" & tdate & "','" & content.TrimEnd & "', " & rowcount & ", '" & pCounterParty & "')"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFncGetTradeDateFromPDF(ByVal pContent As String())
        Dim i As Integer = 1
        Dim lstr As String = ""
        Dim ldate As String = ""

        For idx As Integer = 0 To pContent.Length - 1
            lstr = pContent(idx)
            If lstr.IndexOf("STATEMENT  DATE:  ") >= 0 Then

                lstr = Trim(Replace(Replace(lstr, Chr(10), ""), Chr(13), ""))
                lstr = Replace(lstr, "STATEMENT  DATE:  ", "")

                ldate = Right(lstr, 4) & "/"
                lstr = Left(lstr, lstr.Length - 4).Trim
                '20190228 Start
                'ldate = ldate & lFncGetMonthNumber(Left(lstr, 3)) & "/"
                'lstr = Replace(lstr, ",", "")
                'lstr = Mid(String.Copy(lstr), 5)
                If (lFncGetMonthNumber(Left(lstr, 3)) <> "") Then
                    ldate = ldate & lFncGetMonthNumber(Left(lstr, 3)) & "/"
                    lstr = Replace(lstr, ",", "")
                    lstr = Mid(String.Copy(lstr), 5)
                Else
                    lstr = Replace(lstr, ",", "")
                    ldate = ldate & lFncGetMonthNumber(Right(lstr, 3)) & "/"
                    lstr = Left(lstr, lstr.Length - 3).Trim
                End If
                '20190228 End
                If (lstr.Length = 1) Then
                    ldate = ldate & "0" & lstr
                Else
                    ldate = ldate & lstr
                End If
                Try
                    Dim dateTemp As Date = CDate(ldate)
                    Return ldate
                Catch ex As Exception
                    Return ""
                End Try
                Exit For
            End If
            i = i + 1
        Next

        Return ""
    End Function

    Protected Friend Function lFncGetTradeDataFromPDF(ByVal filename As String, ByVal trade_date As String)
        Dim lcContent As String() = GetTextFromPDF(filename)

        Dim i As Integer = 1
        Dim rowcount As Integer = 0
        Dim readtype As Integer = 0
        Dim isSkipSection As Boolean = False
        Dim MyTrans As SqlTransaction = Nothing

        Dim lstr As String = ""
        Dim mthcode As String = ""
        Dim prod As String = ""
        Dim comm As Double = 0
        Dim clearing As Double = 0
        Dim exchange As Double = 0
        Dim total As Double = 0
        Dim MDFlag As String = "M"
        Dim settleDate As Date = GFncNoNullDate("1900/01/01")
        Dim floating As Decimal = 0.0
        Dim OPDT As DataTable = New dtsNewedge.OpenPositionDataTable
        Dim LQDT As DataTable = New dtsNewedge.LiqPositionDataTable
        Dim TransDt As DataTable = New dtsNewedge.TransDataTable
        Dim LiqHeader As DataTable = New dtsNewedge.LiqHeaderDataTable
        Dim lintCnt As Integer = 0

        Try
            ldtconfirm = New DataTable("confirmation")
            lFncCreateDataTable(ldtconfirm)
            ldtliq = New DataTable("tradedetail")
            lFncCreateDataTable(ldtliq)
            ldtOP = New DataTable("openposition")
            lFncCreateDataTable(ldtOP)
            ldtTemp = lFncGetEmpOP(trade_date).Copy
            MyTrans = GSCnSqlConn.BeginTransaction
            lFncDeleteImported(trade_date, MyTrans, "ADM")
            For idx As Integer = 0 To lcContent.Length - 1
                lstr = lcContent(idx)
                lintCnt += 1

                GSubWriteEventLog(lintCnt.ToString & " - " & lstr, "c:\esl")
                If (InStr(lstr, "C  O  N  F  I  R  M  A  T  I  O  N") > 0) Then
                    readtype = 1
                    isSkipSection = False
                ElseIf (InStr(lstr, "P  U  R  C  H  A  S  E") > 0) Then
                    readtype = 2
                    isSkipSection = False
                ElseIf (InStr(lstr, "O  P  E  N      P  O  S  I  T  I  O  N  S") > 0) Then
                    readtype = 3
                    isSkipSection = False
                ElseIf (InStr(lstr, "THE FOLLOWING JOURNAL ENTRIES HAVE BEEN POSTED TO YOUR ACCOUNT") > 0) Then
                    isSkipSection = True
                ElseIf (InStr(lstr, "MEMO OPTIONS OFFSETTING INFORMATION") > 0) Then
                    isSkipSection = False
                ElseIf (InStr(lstr, "** US DOLLARS **") > 0) Then
                    Exit For
                Else
                    If (lstr.Trim.Length > 0) Then
                        Dim lvalue As String = ""
                        Dim isDate As Boolean = True
                        Dim tdate As Date = Nothing
                        Dim tbuy As Long = 0
                        Dim tsell As Long = 0
                        Dim tmonthcode As String = ""
                        Dim tproduct As String = ""
                        Dim dStrike As Double = 0
                        Dim sCallPut = ""
                        Dim tprice As Double = 0
                        Try
                            Dim lcYr, lcMon, lcDay As String
                            'e20190228 Start
                            'lcMon = lstr.Substring(1, lstr.IndexOf("/", 0) - 1)
                            'lcDay = lstr.Substring(lstr.IndexOf("/", 0) + 1, 2)
                            'lcYr = "201" & lstr.Substring(lstr.IndexOf("/", lstr.IndexOf("/", 0)) + 1, 1)
                            If (lstr.Trim.Substring(0, 7).Contains("/")) Then
                                lcMon = lstr.Substring(1, lstr.IndexOf("/", 0) - 1)
                                lcDay = lstr.Substring(lstr.IndexOf("/", 0) + 1, 2)
                                lcYr = "201" & lstr.Substring(lstr.IndexOf("/", 0) + lstr.IndexOf("/", lstr.IndexOf("/", 0)) + 1, 1)
                            Else
                                Dim lstr_sub As String
                                lstr_sub = lstr.Trim.Substring(0, 7).Trim
                                lcMon = lFncGetMonthNumber(lstr_sub.Substring(lstr_sub.Length - 5, 3))
                                lcDay = lstr_sub.Substring(0, lstr_sub.Length - 5)
                                lcYr = "20" & lstr_sub.Substring(lstr_sub.Length - 2, 2)
                            End If
                            'e20190228 End
                            tdate = CDate(lcYr & "/" & lcMon & "/" & lcDay)
                            isDate = True
                        Catch ex As Exception
                            isDate = False
                        End Try

                        If (isDate = True) Then 'trade
                            'buy
                            If (Not isSkipSection) Then
                                lvalue = lstr.Substring(20, 14)
                                If (lvalue.Trim.Length > 0) Then
                                    tbuy = CLng(lvalue)
                                Else
                                    tbuy = 0
                                End If
                                'sell
                                lvalue = lstr.Substring(35, 14)
                                If (lvalue.Trim.Length > 0) Then
                                    tsell = CLng(lvalue)
                                Else
                                    tsell = 0
                                End If
                                'desc
                                lvalue = lstr.Substring(50, 30)
                                If lvalue.Trim.StartsWith("PUT") Or lvalue.Trim.StartsWith("CALL") Then
                                    If lvalue.Trim.Contains("PUT") Then
                                        sCallPut = "P"
                                        lvalue = GfncSubString(lvalue.Trim, 3, lvalue.Length - 3).Trim
                                    Else
                                        sCallPut = "C"
                                        lvalue = GfncSubString(lvalue.Trim, 4, lvalue.Length - 4).Trim
                                    End If
                                End If
                                If IsNumeric(lvalue.Substring(0, 1)) Then
                                    tmonthcode = lvalue.Substring(7, 2) & lFncGetMonthNumber(lvalue.Substring(3, 3))
                                Else
                                    tmonthcode = lvalue.Substring(4, 2) & lFncGetMonthNumber(lvalue.Substring(0, 3))
                                End If


                                settleDate = GFncNoNullDate("1900/01/01")
                                MDFlag = "M"
                                If IsNumeric(lvalue.Substring(0, 1)) Then
                                    'If Not IsNumeric(tmonthcode) Then
                                    tmonthcode = lvalue.Substring(7, 2) & lFncGetMonthNumber(lvalue.Substring(3, 3))
                                    settleDate = GFncNoNullDate("20" & lvalue.Substring(7, 2) & "/" & lFncGetMonthNumber(lvalue.Substring(3, 3)) & "/" & _
                                                lvalue.Substring(0, 2))
                                    MDFlag = "D"
                                End If
                                mthcode = tmonthcode
                                If IsNumeric(lvalue.Substring(0, 1)) Then
                                    tproduct = lvalue.Substring(10, 14).Trim
                                Else
                                    tproduct = lvalue.Substring(7, 14).Trim
                                End If
                                prod = tproduct

                                If sCallPut = "P" Or sCallPut = "C" Then
                                    If IsNumeric(lvalue.Substring(0, 1)) Then
                                        If (IsNumeric(lvalue.Substring(24))) Then
                                            dStrike = CDbl(lvalue.Substring(24))
                                        End If
                                    Else
                                        If (IsNumeric(lvalue.Substring(21))) Then
                                            dStrike = CDbl(lvalue.Substring(21))
                                        End If
                                    End If

                                End If

                                'price
                                lvalue = lstr.Substring(84, 11)
                                If (lvalue.Substring(9, 1) = "/") Then
                                    tprice = Math.Round(CDbl(lvalue.Substring(0, 7)) + (CInt(lvalue.Substring(8, 1)) / CInt(lvalue.Substring(10, 1)) / 100), 4)
                                Else
                                    If (lvalue.Trim.Length < 1) Then
                                        tprice = 0
                                    Else
                                        tprice = CDbl(lvalue)
                                    End If
                                End If
                                Try
                                    lvalue = lstr.Substring(99)
                                    floating = CDec(lvalue.Trim())
                                Catch ex As Exception
                                    floating = 0.0
                                End Try
                                If tprice = 2310 Then
                                    Dim a As Integer = 0
                                End If
                                'insert to data table
                                If (readtype = 1) Then
                                    lFncInsertNewedgeTrade(trade_date, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, MDFlag, settleDate, TransDt)
                                    lFncInsertToDataTable(ldtconfirm, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                    lFncInsertToDataTable(ldtTemp, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                ElseIf (readtype = 2) Then
                                    lFncInsertToDataTable(ldtliq, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                    lFncInsertToLIQDataTable(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, MDFlag, settleDate, LQDT)
                                    'UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "ADM")
                                ElseIf (readtype = 3) Then
                                    'lFncInsertNewedgeOP(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, MDFlag, settleDate, floating, MyTrans)
                                    lFncPrepareNewedgeOP(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, MDFlag, settleDate, floating, OPDT)
                                End If
                            End If

                        Else
                            'fee
                            If InStr(lstr, "COMMISSION") > 0 Then
                                comm = Math.Round(CDbl(GfncSubString(lstr, 100, 18)), 4)
                            ElseIf InStr(lstr, "CLEARING FEES") > 0 Then
                                clearing = Math.Round(CDbl(GfncSubString(lstr, 100, 18)), 4)
                            ElseIf InStr(lstr, "EXCHANGE FEES") > 0 Then
                                exchange = Math.Round(CDbl(GfncSubString(lstr, 100, 18)), 4)
                            ElseIf InStr(lstr, "CLOSE") > 0 Then
                                'Open position closing price
                                lvalue = lstr.Substring(84, 11)
                                Dim cPrice As Decimal = 0.0
                                If lvalue.Contains("/") Then
                                    cPrice = Math.Round(CDbl(lvalue.Substring(0, 7)) + (CDec(lvalue.Substring(8, 1)) / CDec(lvalue.Substring(10, 1)) / 100), 4)
                                Else
                                    cPrice = CDec(lvalue)
                                End If
                                UpdateClosingPrice(cPrice, OPDT, MyTrans, "ADM")
                            ElseIf (InStr(lstr, "TOTAL POSTING") > 0) Then
                                total = Math.Round(CDbl(GfncSubString(lstr, 99, 18)), 4)
                                lFncInsertNewedgeFeeOP(trade_date, mthcode, prod, comm, clearing, exchange, total, MyTrans, "ADM")
                            Else
                                Dim PL As Decimal = 0.0
                                'Liquid position PL
                                If lstr.Length > 84 Then
                                    If InStr(lstr.Substring(60), "GROSS PROFIT OR LOSS") > 0 Then

                                        If lstr.Substring(33, 1) = "*" Or lstr.Substring(48, 1) = "*" Then

                                            'If InStr(lstr.Substring(84), "SETTLEMENTS") > 0 Then
                                            lvalue = lstr.Substring(99)
                                            PL = GetStringValueToDecimal(lvalue)
                                            UpdatePL(PL, LQDT, MyTrans, LiqHeader, "ADM")
                                        Else

                                            GSubWriteEventLog("skip related adjustment[" & lstr & "]", GStrEPath)
                                        End If
                                    ElseIf InStr(lstr.Substring(60), "GROSS DEBIT OPTION PREMIUM") > 0 Or
                                        InStr(lstr.Substring(60), "GROSS CREDIT OPTION PREMIUM") > 0 Then
                                        'Skip
                                    ElseIf InStr(lstr.Substring(60), "NET MEMO OPTION PREMIUM") > 0 Then
                                        lvalue = lstr.Substring(99)
                                        PL = GetStringValueToDecimal(lvalue)
                                        UpdatePL(PL, LQDT, MyTrans, LiqHeader, "ADM")
                                    ElseIf lstr.Contains("*") And lstr.Length >= 49 And lstr.Length <= 120 And readtype = 2 Then 'new add @18/5/2012
                                        UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "ADM") 'new add @18/5/2012
                                    End If
                                ElseIf lstr.Contains("*") And lstr.Length >= 49 And lstr.Length < 84 And readtype = 2 Then
                                    'ElseIf lstr.Contains("*") And lstr.Length >= 49 And lstr.Length <= 120 And readtype = 2 Then
                                    UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "ADM")
                                End If
                            End If
                        End If
                    End If
                End If
                If (lstr.Trim.Length > 0) Then
                    rowcount = rowcount + 1
                    lFncInsertNewedgeConetent(trade_date, lstr.Replace("'", "''"), rowcount, MyTrans, "ADM")
                End If
            Next

            'If LiqHeader.Rows.Count <= 0 Then
            '    UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "ADM")
            'End If

            For Each dr As DataRow In LQDT.Rows
                If GFncNoNullValue(dr("size")) = 0 Then
                    dr("size") = 1
                End If
            Next

            'Dim lcStrColName As String = ""
            'For j As Integer = 0 To LiqHeader.Columns.Count - 1
            '    lcStrColName &= LiqHeader.Columns(j).ColumnName
            '    If j <> LiqHeader.Columns.Count - 1 Then
            '        lcStrColName &= ","
            '    End If
            'Next
            'LiqHeader = LiqHeader.DefaultView.ToTable(True, lcStrColName.Split(","))
            'For j As Integer = 0 To LiqHeader.Rows.Count - 1
            '    If GFncNoNullValue(LiqHeader.Rows(j).Item("size")) = 0 Then
            '        LiqHeader.Rows(j).Item("size") = 1
            '    End If
            'Next


            'insert contract_size into transaction table
            FncTransSize(OPDT, LQDT, TransDt)
            'insert transaction
            FncInsertTrans(TransDt, MyTrans, "ADM")
            'insert open position
            FncInsertOP(OPDT, MyTrans, "ADM")
            'insert liquid position and its header (header for storing the PL)

            'UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "ADM")
            FncInsertCP(LQDT, LiqHeader, MyTrans, "ADM")
            'lFncMakeNewOP(ldtliq, ldtTemp)
            lFncUpdateComm(trade_date, MyTrans, "ADM")

            'save open position
            'useless --- 2010/04/16
            'For i = 0 To (ldtTemp.Rows().Count - 1)
            '    If ((ldtTemp.Rows(i).Item(1) <> 0) Or (ldtTemp.Rows(i).Item(2) <> 0)) Then
            '        lFncInsertEmpOP(trade_date, ldtTemp.Rows(i).Item(0), ldtTemp.Rows(i).Item(1), ldtTemp.Rows(i).Item(2), _
            '                        ldtTemp.Rows(i).Item(3), ldtTemp.Rows(i).Item(4), ldtTemp.Rows(i).Item(5), MyTrans, "ADM")
            '    End If
            'Next

            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
            End If
            GSubWriteErrLog(ex.Message)
        End Try

        Return Nothing
    End Function

    Private Function GetStringValueToDecimal(ByVal strString As String) As Decimal
        Dim result As Decimal = 0
        If strString.Contains("/") Then
            result = Math.Round(CDbl(strString.Substring(0, 7)) + (CDec(strString.Substring(8, 1)) / CDec(strString.Substring(10, 1)) / 100), 4)
        Else
            If strString.Contains("-") Then 'Negative value
                Try
                    result = CDec(Replace(strString, ",", ""))
                Catch ex As Exception
                    result = Val(Replace(strString, ",", "")) 'use back the old method when error 
                End Try
            Else 'Positive value
                result = Val(Replace(strString, ",", ""))
            End If
        End If
        Return result
    End Function

    Protected Friend Function GetTextFromPDF(ByVal PdfFileName As String) As String()
        Dim oReader As New iTextSharp.text.pdf.PdfReader(PdfFileName)

        Dim sOut As String = ""

        For i As Integer = 1 To oReader.NumberOfPages
            Dim its As New iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy

            sOut &= iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)

        Next

        sOut = sOut.Replace("STATEMENTS AND CONFIRMATIONS - Reports of the confirmations of orders and statements of the accounts of the Customer shall be deemed", "")
        sOut = sOut.Replace("correct and shall be conclusive and binding upon the Customer if not objected to in writing within three (3) days after transmittal to", "")
        sOut = sOut.Replace("the Customer by mail or otherwise.  Such written objection on Customer's part shall be directed to Broker's Compliance Office at", "")
        sOut = sOut.Replace("ADMIS Hong Kong Ltd. and shall be deemed received only if actually delivered or mailed by registered mail, return receipt requested.", "")
        sOut = sOut.Replace("Failure to so notify shall be deemed rectification of all actions taken by Broker or Broker's agents prior to said report being", "")
        sOut = sOut.Replace("report being furnished to Customer", "")
        sOut = sOut.Replace("                                                                                                                        ADMIS HONG KONG LIMITED", "ADMIS HONG KONG LIMITED")
        sOut = sOut.Replace("  ADMIS HONG KONG LIMITED", vbLf & "ADMIS HONG KONG LIMITED")

        Return sOut.Split(vbLf)
    End Function

    Protected Friend Function GetTextFromMarexPDF(ByVal PdfFileName As String) As String()
        Dim oReader As New iTextSharp.text.pdf.PdfReader(PdfFileName)

        Dim sOut As String = ""

        For i As Integer = 1 To oReader.NumberOfPages
            Dim its As New iTextSharp.text.pdf.parser.SimpleTextExtractionStrategy

            sOut &= iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(oReader, i, its)

        Next
        sOut = sOut.Replace("It is important that you check the statement carefully and promptly upon receipt.  This is even more important in volatile", "")
        sOut = sOut.Replace("market conditions.   Any discrepancies, differences or objections should be reported by you as soon as possible and in any", "")
        sOut = sOut.Replace("event no later than within one (1) business day of your receipt of our statement.  Your report should be made to your Account", "")
        sOut = sOut.Replace("Executive and also to our Client Services Department via email to MFLClientServices@marexspectron.com.  After one (1) business", "")
        sOut = sOut.Replace("day, this statement may be deemed by us to be correct and binding on you as conforming to your own records.", "")
        sOut = sOut.Replace("'", " ")
        Return sOut.Split(vbLf)
    End Function

    Protected Friend Function lFncGetTradeDateFromMarexPDF(ByVal pContent As String())
        Dim i As Integer = 1
        Dim lstr As String = ""
        Dim ldate As String = ""

        For idx As Integer = 0 To pContent.Length - 1
            lstr = pContent(idx)
            If lstr.IndexOf("STATEMENT DATE : ") >= 0 Then

                lstr = Trim(Replace(Replace(lstr, Chr(10), ""), Chr(13), ""))
                lstr = Replace(lstr, "STATEMENT DATE : ", "")
                ldate = "20" & lstr.Substring(6, 2) & "/" & lstr.Substring(3, 2) & "/" & lstr.Substring(0, 2)
                Try
                    Dim dateTemp As Date = CDate(ldate)
                    Return ldate
                Catch ex As Exception
                    Return ""
                End Try
                Exit For
            End If
            i = i + 1
        Next

        Return ""
    End Function

    Protected Friend Function lFncGetTradeDataFromMarexPDF(ByVal filename As String, ByVal trade_date As String)
        Dim lcContent As String() = GetTextFromMarexPDF(filename)

        Dim i As Integer = 1
        Dim rowcount As Integer = 0
        Dim readtype As Integer = 0
        Dim MyTrans As SqlTransaction = Nothing

        Dim lstr As String = ""
        Dim mthcode As String = ""
        Dim prod As String = ""
        Dim comm As Double = 0
        Dim clearing As Double = 0
        Dim exchange As Double = 0
        Dim total As Double = 0
        Dim MDFlag As String = "M"
        Dim settleDate As Date = GFncNoNullDate("1900/01/01")
        Dim floating As Decimal = 0.0
        Dim OPDT As DataTable = New dtsNewedge.OpenPositionDataTable
        Dim LQDT As DataTable = New dtsNewedge.LiqPositionDataTable
        Dim TransDt As DataTable = New dtsNewedge.TransDataTable
        Dim LiqHeader As DataTable = New dtsNewedge.LiqHeaderDataTable
        Dim lintCnt As Integer = 0
        Dim tranType As String = ""

        Try
            ldtconfirm = New DataTable("confirmation")
            lFncCreateDataTable(ldtconfirm)
            ldtliq = New DataTable("tradedetail")
            lFncCreateDataTable(ldtliq)
            ldtOP = New DataTable("openposition")
            lFncCreateDataTable(ldtOP)
            ldtTemp = lFncGetEmpOP(trade_date).Copy
            MyTrans = GSCnSqlConn.BeginTransaction
            lFncDeleteImported(trade_date, MyTrans, "Marex")
            For idx As Integer = 0 To lcContent.Length - 1
                lstr = lcContent(idx)
                lintCnt += 1

                GSubWriteEventLog(lintCnt.ToString & " - " & lstr, "c:\esl")
                If (InStr(lstr, "C  O  N  F  I  R  M  A  T  I  O  N  S") > 0) Then
                    readtype = 1
                ElseIf (InStr(lstr, "R E A L I S E D   P & L") > 0) Then
                    readtype = 2
                ElseIf (InStr(lstr, "O  P  E  N    P  O  S  I  T  I  O  N  S") > 0) Then
                    readtype = 3
                ElseIf (InStr(lstr, "J  O  U  R  N  A  L  S") > 0) Then
                    readtype = 4
                ElseIf (InStr(lstr, "O  P  T  I  O  N    C  L  O  S  E - O  U  T  S") > 0) Then
                    readtype = 5
                ElseIf (InStr(lstr, "A  C  C  O  U  N  T    S  U  M  M  A  R  Y") > 0) Then
                    Exit For
                Else
                    If (lstr.Trim.Length > 0) Then

                        If lstr.Trim = "DELETED TRADES" Then
                            tranType = lstr.Trim
                        ElseIf lstr.Trim = "BACKDATED TRADES" Then
                            tranType = lstr.Trim
                        ElseIf lstr.Trim = "NEW TRADES" Then
                            tranType = ""
                        End If

                        If tranType <> "DELETED TRADES" And tranType <> "BACKDATED TRADES" Then
                            Dim lvalue As String = ""
                            Dim isDate As Boolean = True
                            Dim tdate As Date = Nothing
                            Dim tbuy As Long = 0
                            Dim tsell As Long = 0
                            Dim tmonthcode As String = ""
                            Dim tproduct As String = ""
                            Dim dStrike As Double = 0
                            Dim sCallPut As String = ""
                            Dim sCurrency As String = ""
                            Dim tprice As Double = 0
                            Try
                                Dim lcDate As String
                                lcDate = lstr.Substring(0, 8)
                                tdate = CDate(lcDate)
                                isDate = True
                            Catch ex As Exception
                                isDate = False
                            End Try

                            If (isDate = True) Then 'trade

                                If (readtype <> 4) Then
                                    'buy
                                    lvalue = lstr.Substring(8, 7)
                                    If (lvalue.Trim.Length > 0) Then
                                        tbuy = CLng(lvalue)
                                    Else
                                        tbuy = 0
                                    End If
                                    'sell
                                    lvalue = lstr.Substring(15, 7)
                                    If (lvalue.Trim.Length > 0) Then
                                        tsell = CLng(lvalue)
                                    Else
                                        tsell = 0
                                    End If
                                    'desc
                                    lvalue = lstr.Substring(29, 30)
                                    If IsNumeric(lvalue.Substring(0, 1)) Then
                                        tmonthcode = lvalue.Substring(7, 2) & lFncGetMonthNumber(lvalue.Substring(3, 3))
                                    Else
                                        tmonthcode = lvalue.Substring(4, 2) & lFncGetMonthNumber(lvalue.Substring(0, 3))
                                    End If

                                    settleDate = GFncNoNullDate("1900/01/01")
                                    MDFlag = "M"
                                    If IsNumeric(lvalue.Substring(0, 1)) Then

                                        tmonthcode = lvalue.Substring(6, 2) & lvalue.Substring(3, 2)
                                        settleDate = GFncNoNullDate("20" & lvalue.Substring(6, 2) & "/" & lvalue.Substring(3, 2) & "/" & _
                                                    lvalue.Substring(0, 2))
                                        MDFlag = "D"

                                    End If
                                    mthcode = tmonthcode
                                    If IsNumeric(lvalue.Substring(0, 1)) Then
                                        tproduct = lvalue.Substring(9, 20).Trim
                                    Else
                                        tproduct = lvalue.Substring(7, 20).Trim
                                    End If
                                    prod = tproduct

                                    'start chun add code call/put strike
                                    Try
                                        If readtype = 1 Then
                                            lvalue = lstr.Substring(75, 10)
                                            If (lvalue.Trim.Length < 1) Then
                                                dStrike = 0
                                            Else
                                                dStrike = CDbl(lvalue)
                                            End If
                                        ElseIf readtype = 3 Then
                                            lvalue = lstr.Substring(70, 9)
                                            If (lvalue.Trim.Length < 1) Then
                                                dStrike = 0
                                            Else
                                                dStrike = CDbl(lvalue)
                                            End If
                                        ElseIf readtype = 5 Then
                                            lvalue = lstr.Substring(71, 10).Trim
                                            If (lvalue.Trim.Length < 1) Then
                                                dStrike = 0
                                            Else
                                                dStrike = CDbl(lvalue)
                                            End If
                                        End If
                                    Catch ex As Exception
                                        dStrike = 0.0
                                    End Try

                                    Try
                                        If readtype = 1 Then
                                            lvalue = lstr.Substring(24, 1).Trim
                                            If (lvalue.Trim.Length < 1) Then
                                                sCallPut = ""
                                            Else
                                                sCallPut = lvalue
                                            End If
                                        ElseIf readtype = 3 Then
                                            lvalue = lstr.Substring(79, 1).Trim
                                            If (lvalue.Trim.Length < 1) Then
                                                sCallPut = ""
                                            Else
                                                sCallPut = lvalue
                                            End If
                                        ElseIf readtype = 5 Then
                                            lvalue = lstr.Substring(24, 1).Trim
                                            If (lvalue.Trim.Length < 1) Then
                                                sCallPut = ""
                                            Else
                                                sCallPut = lvalue
                                            End If
                                        End If
                                    Catch ex As Exception
                                        sCallPut = ""
                                    End Try
                                    'end chun add code call/put strike


                                    'price
                                    Try
                                        If readtype = 1 Then
                                            lvalue = lstr.Substring(86, 10).Trim
                                            If (lvalue.Trim.Length < 1) Then
                                                tprice = 0
                                            Else
                                                tprice = CDbl(lvalue)
                                            End If
                                        ElseIf readtype = 2 Then

                                            lvalue = lstr.Substring(84, 10).Trim
                                            If (lvalue.Trim.Length < 1) Then
                                                tprice = 0
                                            Else
                                                tprice = CDbl(lvalue)
                                            End If
                                        ElseIf readtype = 3 Then

                                            lvalue = lstr.Substring(84, 10).Trim
                                            If (lvalue.Trim.Length < 1) Then
                                                tprice = 0
                                            Else
                                                tprice = CDbl(lvalue)
                                            End If
                                        ElseIf readtype = 5 Then
                                            lvalue = lstr.Substring(81, 10).Trim
                                            If (lvalue.Trim.Length < 1) Then
                                                tprice = 0
                                            Else
                                                tprice = CDbl(lvalue)
                                            End If
                                        End If

                                    Catch
                                        tprice = 0.0
                                    End Try
                                    'lvalue = lstr.Substring(81, 14) chun change for fitting the space strike and callput
                                    'If (lvalue.Substring(9, 1) = "/") Then
                                    '    tprice = Math.Round(CDbl(lvalue.Substring(0, 7)) + (CInt(lvalue.Substring(8, 1)) / CInt(lvalue.Substring(10, 1)) / 100), 4)
                                    'Else

                                    'End If
                                    Try
                                        lvalue = lstr.Substring(95, 3).Trim
                                        If (lvalue.Trim.Length < 1) Then
                                            sCurrency = ""
                                        Else
                                            sCurrency = lvalue
                                        End If

                                    Catch ex As Exception
                                        sCurrency = ""
                                    End Try

                                    Try
                                        ' for futures, the floating debit is negative; credit is positive. for options, the floating is needed to calculate in function UpdateClosingPrice() because the floating is not a real floating
                                        lvalue = lstr.Substring(99, 12).Trim
                                        If lvalue = "" Then 'positive
                                            lvalue = lstr.Substring(114)
                                            floating = CDec(lvalue)
                                        Else
                                            lvalue = lstr.Substring(99)
                                            floating = CDec(lvalue) * -1
                                        End If

                                        If readtype = 5 Then ' for option closeout
                                            lvalue = lstr.Substring(99, 12).Trim
                                            If lvalue = "" Then 'positive
                                                lvalue = lstr.Substring(115)
                                                floating = CDec(lvalue)
                                            Else
                                                lvalue = lstr.Substring(99)
                                                floating = CDec(lvalue)
                                            End If
                                        End If


                                    Catch ex As Exception
                                        floating = 0.0
                                    End Try

                                    'insert to data table
                                    If (readtype = 1) Then
                                        lFncInsertNewedgeTrade(trade_date, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, MDFlag, settleDate, TransDt)
                                        lFncInsertToDataTable(ldtconfirm, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                        lFncInsertToDataTable(ldtTemp, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                    ElseIf (readtype = 2) Then
                                        lFncInsertToDataTable(ldtliq, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                        lFncInsertToLIQDataTable(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, MDFlag, settleDate, LQDT)
                                        'UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "ADM")
                                    ElseIf (readtype = 5) Then
                                        lFncInsertToDataTable(ldtliq, tdate, tbuy, tsell, tmonthcode, tproduct, tprice)
                                        lFncInsertToLIQDataTable(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, floating, MDFlag, settleDate, LQDT)
                                        'UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "ADM")

                                    ElseIf (readtype = 3) Then
                                        'lFncInsertNewedgeOP(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, MDFlag, settleDate, floating, MyTrans)
                                        lFncPrepareMarexOP(trade_date, tdate, tbuy, tsell, tmonthcode, tproduct, tprice, dStrike, sCallPut, MDFlag, settleDate, floating, OPDT, LQDT)
                                    End If
                                End If

                            Else
                                'fee
                                If lstr.IndexOf("COMMISSION") = 29 Then 'COMMISSION
                                    If lstr.Substring(99, 15).Trim <> "" Then
                                        comm = Math.Round(CDbl(lstr.Substring(99, 15)), 4)
                                    Else
                                        comm = Math.Round(CDbl(lstr.Substring(114, 15)), 4) * -1
                                    End If
                                ElseIf InStr(lstr, "NFA FEE") > 0 Then 'CLEARING FEE
                                    'clearing = Math.Round(CDbl(lstr.Substring(99, 15)), 4)
                                    If lstr.Substring(99, 15).Trim <> "" Then
                                        clearing = Math.Round(CDbl(lstr.Substring(99, 15)), 4)
                                    Else
                                        clearing = Math.Round(CDbl(lstr.Substring(114, 15)), 4) * -1
                                    End If
                                ElseIf InStr(lstr, "EXCHANGE FEE") > 0 Then 'EXCHANGE FEE
                                    'exchange = Math.Round(CDbl(lstr.Substring(99, 15)), 4)
                                    If lstr.Substring(99, 15).Trim <> "" Then
                                        exchange = Math.Round(CDbl(lstr.Substring(99, 15)), 4)
                                    Else
                                        exchange = Math.Round(CDbl(lstr.Substring(114, 15)), 4) * -1
                                    End If
                                ElseIf InStr(lstr, "S.P.") > 0 Then 'CLOSE in OPEN POSITION 
                                    'ElseIf InStr(lstr, "CLOSE") > 0 Then
                                    '*** no yet confirmed
                                    'Open position closing price
                                    lvalue = lstr.Substring(84, 11)
                                    Dim cPrice As Decimal = 0.0
                                    If lvalue.Contains("/") Then
                                        cPrice = Math.Round(CDbl(lvalue.Substring(0, 7)) + (CDec(lvalue.Substring(8, 1)) / CDec(lvalue.Substring(10, 1)) / 100), 4)
                                    Else
                                        cPrice = CDec(lvalue)
                                    End If
                                    UpdateClosingPrice(cPrice, OPDT, MyTrans, "Marex")
                                    '***
                                ElseIf (InStr(lstr, "TOTAL COMMISSION  ") > 0) Then 'TOTAL POSTING
                                    'total = Math.Round(CDbl(lstr.Substring(99, 15)), 4)
                                    If lstr.Substring(99, 15).Trim <> "" Then
                                        total = Math.Round(CDbl(lstr.Substring(99, 15)), 4)
                                    Else
                                        total = Math.Round(CDbl(lstr.Substring(114)), 4) * -1
                                    End If
                                    lFncInsertNewedgeFeeOP(trade_date, mthcode, prod, comm, clearing, exchange, total, MyTrans, "Marex")
                                Else
                                    Dim PL As Decimal = 0.0
                                    'Liquid position PL
                                    If lstr.Length > 84 Then
                                        If InStr(lstr, "P&L FROM TRADES   ") Then
                                            'If InStr(lstr.Substring(84), "SETTLEMENTS") > 0 Then
                                            lvalue = lstr.Substring(99)

                                            'If Right(lvalue, 1) = " " Then 'Negative value
                                            If lstr.Substring(114).Trim = "" Then 'Negative value
                                                lvalue = lvalue.Trim & "-"
                                                Try
                                                    PL = CDec(Replace(lvalue, ",", ""))
                                                Catch ex As Exception
                                                    PL = Val(Replace(lvalue, ",", "")) 'use back the old method when error 
                                                End Try
                                            Else 'Positive value
                                                PL = Val(Replace(lvalue, ",", ""))

                                            End If
                                            UpdatePL(PL, LQDT, MyTrans, LiqHeader, "Marex")
                                        ElseIf lstr.Contains("*") And lstr.Length >= 21 And lstr.Length <= 120 And readtype = 2 Then 'new add @18/5/2012
                                            UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "Marex") 'new add @18/5/2012
                                        ElseIf InStr(lstr, "TOTAL P&L   ") > 0 Then
                                            OptionCloseOutUpdatePL(LQDT, MyTrans, LiqHeader, "Marex")

                                        End If
                                    ElseIf lstr.Contains("*") And lstr.Length >= 21 And lstr.Length <= 84 And readtype = 2 Then
                                        'ElseIf lstr.Contains("*") And lstr.Length >= 49 And lstr.Length <= 120 And readtype = 2 Then
                                        UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "Marex")
                                    End If
                                End If
                            End If

                        End If



                    End If
                End If
                If (lstr.Trim.Length > 0) Then
                    rowcount = rowcount + 1
                    lFncInsertNewedgeConetent(trade_date, lstr.Replace("'", "''"), rowcount, MyTrans, "Marex")
                End If
            Next

            'If LiqHeader.Rows.Count <= 0 Then
            '    UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "ADM")
            'End If

            For Each dr As DataRow In LQDT.Rows
                If GFncNoNullValue(dr("size")) = 0 Then
                    dr("size") = 1
                End If
            Next

            'Dim lcStrColName As String = ""
            'For j As Integer = 0 To LiqHeader.Columns.Count - 1
            '    lcStrColName &= LiqHeader.Columns(j).ColumnName
            '    If j <> LiqHeader.Columns.Count - 1 Then
            '        lcStrColName &= ","
            '    End If
            'Next
            'LiqHeader = LiqHeader.DefaultView.ToTable(True, lcStrColName.Split(","))
            'For j As Integer = 0 To LiqHeader.Rows.Count - 1
            '    If GFncNoNullValue(LiqHeader.Rows(j).Item("size")) = 0 Then
            '        LiqHeader.Rows(j).Item("size") = 1
            '    End If
            'Next


            'insert contract_size into transaction table
            FncTransSize(OPDT, LQDT, TransDt)
            'insert transaction
            FncInsertTrans(TransDt, MyTrans, "Marex")
            'insert open position
            FncInsertOP(OPDT, MyTrans, "Marex")
            'insert liquid position and its header (header for storing the PL)

            'UpdatePL(0.0, LQDT, MyTrans, LiqHeader, "Marex")
            FncInsertCP(LQDT, LiqHeader, MyTrans, "Marex")
            'lFncMakeNewOP(ldtliq, ldtTemp)
            lFncUpdateComm(trade_date, MyTrans, "Marex")

            'save open position
            'useless --- 2010/04/16
            'For i = 0 To (ldtTemp.Rows().Count - 1)
            '    If ((ldtTemp.Rows(i).Item(1) <> 0) Or (ldtTemp.Rows(i).Item(2) <> 0)) Then
            '        lFncInsertEmpOP(trade_date, ldtTemp.Rows(i).Item(0), ldtTemp.Rows(i).Item(1), ldtTemp.Rows(i).Item(2), _
            '                        ldtTemp.Rows(i).Item(3), ldtTemp.Rows(i).Item(4), ldtTemp.Rows(i).Item(5), MyTrans, "ADM")
            '    End If
            'Next

            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
            End If
            GSubWriteErrLog(ex.Message)
        End Try

        Return Nothing
    End Function
End Class
