
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class clsRptStockMonitor
    Protected Friend Sub lfncCreateTable(ByRef dtTrans As DataTable)

        dtTrans = New DataTable
        dtTrans.Columns.Add("client_id", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("order_id", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("input_date", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("input_time", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("Instr_type", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("Handler", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("BS", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("order_type", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("stock", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("MKT", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("ccy", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("price", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("QTY", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("TC", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("return_code", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("proc_status", System.Type.GetType("System.String"))

        dtTrans.Columns.Add("client_name", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("stock_no", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("LOT", System.Type.GetType("System.Decimal"))
        dtTrans.Columns.Add("match", System.Type.GetType("System.String"))

    End Sub
    Protected Friend Sub lfncCreateTable2(ByRef dtTrans As DataTable)

        dtTrans = New DataTable
        dtTrans.Columns.Add("client_id", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("order_id", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("input_date", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("input_time", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("Instr_type", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("Handler", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("BS", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("order_type", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("stock", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("MKT", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("ccy", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("price", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("QTY", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("TC", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("return_code", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("proc_status", System.Type.GetType("System.String"))

        dtTrans.Columns.Add("client_name", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("stock_no", System.Type.GetType("System.String"))
        dtTrans.Columns.Add("LOT", System.Type.GetType("System.Decimal"))
        dtTrans.Columns.Add("match", System.Type.GetType("System.String"))

    End Sub

    Protected Friend Function lsubFindResult(ByVal dt As DataTable, ByVal intDay As Int16)


        'to return client_id and stock_no with distinct date > intDay

        Dim ldtCount = New DataTable
        ldtCount.Columns.Add("client_id", System.Type.GetType("System.String"))
        ldtCount.Columns.Add("stock_no", System.Type.GetType("System.String"))
        ldtCount.Columns.Add("count", System.Type.GetType("System.Decimal"))

        Dim ldtDistinctDate = New DataTable
        ldtDistinctDate.Columns.Add("client_id", System.Type.GetType("System.String"))
        ldtDistinctDate.Columns.Add("stock_no", System.Type.GetType("System.String"))
        ldtDistinctDate.Columns.Add("input_date", System.Type.GetType("System.String"))

        Dim ldtReturn = New DataTable
        ldtReturn.Columns.Add("client_id", System.Type.GetType("System.String"))
        ldtReturn.Columns.Add("stock_no", System.Type.GetType("System.String"))


        Dim col() As String = {"client_id", "stock_no", "input_date"}
        ldtDistinctDate = dt.DefaultView.ToTable(True, col)

        Dim col2() As String = {"client_id", "stock_no"}
        ldtCount = dt.DefaultView.ToTable(True, col2)
        ldtCount.Columns.Add("count", System.Type.GetType("System.Decimal"))
        For Each ldr As DataRow In ldtDistinctDate.rows
            For Each ldr2 As DataRow In ldtCount.rows
                If ldr("client_id") = ldr2("client_id") And ldr("stock_no") = ldr2("stock_no") Then
                    If IsDBNull(ldr2("count")) Then
                        ldr2("count") = 1
                    Else
                        ldr2("count") += 1
                    End If
                End If
            Next
        Next

        For Each ldr As DataRow In ldtCount.rows
            If ldr("count") >= intDay Then
                Dim TempRow As DataRow = ldtReturn.newrow
                TempRow("client_id") = ldr("client_id")
                TempRow("stock_no") = ldr("stock_no")
                ldtReturn.rows.add(TempRow)
            End If
        Next


        Return ldtReturn


        'Dim lstrSQL As String

        'lstrSQL = "create table #tmp (client_id  nvarchar(10), tx_date  datetime, " & _
        '        " stock_no  nvarchar(10), lot  int) "

        'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        'For Each ldr As DataRow In dt.Rows


        '    lstrSQL = " insert #tmp (client_id, tx_date , " & _
        '             " stock_no, lot) values ('" & ldr("client_id") & "','" & _
        '              ldr("input_date").substring(6, 4) & "-" & _
        '              ldr("input_date").substring(3, 2) & "-" & _
        '              ldr("input_date").substring(0, 2) & _
        '               " " & ldr("input_time") & _
        '              "','" & ldr("stock_no") & "'," & ldr("lot") & ") "
        '    GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        'Next

        'Dim ldt As DataTable

        'ldt = GFncRtnDS(GSCnSqlConn, "select client_id, stock_no, count(distinct convert(varchar(10),tx_date, 111)) " & _
        '                " from #tmp " & _
        '                " group by  client_id, stock_no " & _
        '                " having count(distinct convert(varchar(10),tx_date, 111)) >= " & intDay & "  order by client_id, stock_no ", 0).Tables(0)

        'lstrSQL = " drop table #tmp "

        'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        ''Dim ldt As DataTable = dtTrans.Copy
        ''ldt.Clear()
        ''Dim ldtaDD As DataRow() = dtTrans.Select("", "stock_no,txdate")
        ''For lintCnt As Integer = 0 To ldtaDD.Length - 1
        ''    ldt.ImportRow(ldtaDD(lintCnt))
        ''Next

        'Return ldt

    End Function


    Protected Friend Function lfncSort(ByVal dt As DataTable)

        'to sort datatable by stock_no,txdate

        Dim ldt As DataTable = dt.Copy
        ldt.Clear()
        Dim ldtaDD As DataRow() = dt.Select("1=1", "stock_no,txdate")
        For lintCnt As Integer = 0 To ldtaDD.Length - 1
            ldt.ImportRow(ldtaDD(lintCnt))
        Next
        Return ldt
        'Dim lstrSQL As String

        ''lstrSQL = "create table #tmp (start_date  nvarchar(30), end_date  nvchar(30), " & _
        ''           "client_id nvchar(10), client_name nvchar(30), stock_no nchar(50), " & _
        ''          "txdate datetime,qty nvchar(10), lot int, price nvchar(10), b_s nvchar(5), " & _
        ''         "handler nvchar(10), match nvchar(5)"
        'lstrSQL = "create table #tmp (start_date  nvarchar(30), end_date  nvarchar(30), " & _
        '            "client_id nvarchar(10), client_name nvarchar(30), stock_no nvarchar(50), " & _
        '            "txdate datetime,qty nvarchar(10), lot nvarchar(10), price nvarchar(10), b_s nvarchar(5), " & _
        '            "handler nvarchar(10), match nvarchar(5))"

        'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        'For Each ldr As DataRow In dt.Rows

        '    Dim lstrdatetime As String
        '    lstrdatetime = ldr(5).ToString.Substring(7, 4) & "-" & ldr(5).ToString.Substring(4, 2) & "-" & ldr(5).ToString.Substring(1, 2) & ldr(5).ToString.Substring(11)

        '    lstrSQL = "insert #tmp values ('" & ldr(0) & "','" & ldr(1) & "','" & ldr(2) & "','" & ldr(3) & "','" & GFncSqlQuote(ldr(4)) & "','" & _
        '                ldr(5) & "','" & ldr(6) & "','" & ldr(7) & "','" & ldr(8) & "','" & ldr(9) & "','" & ldr(10) & "','" & ldr(11) & "')"
        '    GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        'Next

        'Dim ldt As New DataTable

        'ldt = GFncRtnDS(GSCnSqlConn, "select * from #tmp order by stock_no,txdate").Tables(0)

        'lstrSQL = " drop table #tmp "

        'GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

        'Return ldt

        'Dim arraydatarow() As DataRow
        'arraydatarow = dt.Select("1=1", "stock_no,txdate")
        'For Each ldr As DataRow In arraydatarow
        '    ldt.ImportRow(ldr)
        'Next
        'Return dt
    End Function

    Protected Friend Function lfncGetHSI() As DataTable

        Dim ldtsData As DataSet

        ldtsData = GFncRtnDS(GSCnSqlConn, "SELECT * from HSI_stock_master", 0)

        Return ldtsData.Tables(0)

    End Function
    Protected Friend Function lfncGetLotsInfo() As DataTable

        Dim ldtsData As DataSet

        ldtsData = GFncRtnDS(GSCnSqlConn, "SELECT stkno, lot FROM " & GStrG2BSDB & ".dbo.stock_master ", 0)

        Return ldtsData.Tables(0)

    End Function
    Protected Friend Function lfncGetName() As DataTable

        Dim ldtsData As DataSet

        ldtsData = GFncRtnDS(GSCnLiqConn, "SELECT clt_code, clt_name from stcltmaster", 0)

        Return ldtsData.Tables(0)

    End Function

    Protected Friend Function lFncSearch(ByVal strField As String, ByVal strCode As String, ByVal dt As DataTable) As DataRow

        Dim ldr() As DataRow

        ldr = dt.Select(strField & " = '" & GFncNoNullString(strCode).Trim & "' ")
        If ldr.Length > 0 Then
            Return ldr(0)
        End If

        Return Nothing

    End Function
    Protected Friend Function lfncFillZero(ByVal strStock As String) As String

        If IsDBNull(strStock) Then
            Return ""
        End If

        strStock = strStock.Trim
        Select Case strStock.Length
            Case 1
                strStock = "0000" & strStock
            Case 2
                strStock = "000" & strStock
            Case 3
                strStock = "00" & strStock
            Case 4
                strStock = "0" & strStock
        End Select

        Return strStock

    End Function
    Protected Friend Function lFncGetfile(ByVal strFile As String, ByVal strTime As String, _
    ByVal dtHSI As DataTable, ByVal dtClient As DataTable, ByVal dtStock As DataTable, _
   ByRef dtTrans As DataTable, ByVal decLot As Decimal) As Boolean
        Dim strLine As String = ""
        Dim lstrDate As String = ""
        Dim lstrFileName As String
        Dim sReader As StreamReader
        Dim lstrArr(16) As String

        ' Me.ListBox1.Items.Clear()
        lstrFileName = strFile.Substring(strFile.LastIndexOfAny("\") + 1, strFile.Length - strFile.LastIndexOfAny("\") - 1)
        If lstrFileName.Length < 8 Then
            Return False
        End If
        If Not IsNumeric(lstrFileName.Substring(0, 8)) Then
            Return False
        End If

        lstrDate = lstrFileName.Substring(6, 2) & "/" & lstrFileName.Substring(4, 2) & "/" & lstrFileName.Substring(0, 4)

        Try
            sReader = New StreamReader(strFile)
            Do While Not sReader.EndOfStream
                strLine = sReader.ReadLine()
                ' Me.ListBox1.Items.Add(strLine)
                For lint As Int16 = 0 To 15
                    lstrArr(lint) = ""
                Next
                Dim lstrTemp As String = strLine
                Dim lintstart As Integer = 0

                Dim lintidx As Int16 = 0
                Do While lstrTemp.IndexOf(",") >= 0
                    Dim lstrPart As String = lstrTemp.Substring(lintstart, lstrTemp.IndexOf(","))
                    'Me.ListBox1.Items.Add(lstrPart)
                    lstrArr(lintidx) = lstrPart
                    lintidx += 1
                    lstrTemp = lstrTemp.Substring(lstrTemp.IndexOf(",") + 1, lstrTemp.Length - lstrPart.Length - 1)
                    lintstart = 0
                Loop
                If lstrTemp.Length > 0 Then
                    'Me.ListBox1.Items.Add(lstrTemp)
                    lstrArr(lintidx) = lstrTemp
                End If
                If lstrArr(3) > strTime And lstrArr(3) <= "16:00:00" And _
                        lstrArr(2) = lstrDate And lstrArr(4) <> "Cancel Order" Then
                    Dim ldrSearch As DataRow = Nothing
                    Dim lstrStock As String = ""

                    If lstrArr(8).IndexOf(" ") > 0 Then
                        lstrStock = lstrArr(8).Substring(0, lstrArr(8).IndexOf(" "))
                    End If
                    ldrSearch = lFncSearch("hsi_stock", lstrStock, dtHSI)
                    If IsNothing(ldrSearch) Then
                        Dim ldecDefaultLot As Decimal = 0
                        Dim ldecLot As Decimal = 0
                        ldrSearch = lFncSearch("stkno", lfncFillZero(lstrStock), dtStock)
                        If Not IsNothing(ldrSearch) Then
                            ldecDefaultLot = ldrSearch("lot")
                            If ldecDefaultLot > 0 Then
                                ldecLot = Val(GFncNoNullString(lstrArr(12))) / ldecDefaultLot
                                If (ldecLot <= decLot) Then
                                    'And (ldecLot Mod 1 = 0) Then
                                    Dim ldrNew As DataRow = dtTrans.NewRow
                                    ldrNew("stock_no") = lstrStock
                                    ldrNew("lot") = ldecLot
                                    For lint As Int16 = 0 To 15
                                        Select Case lint
                                            Case 0    'client
                                                If lstrArr(lint).IndexOf(">") Then
                                                    ldrNew(lint) = lstrArr(lint).Substring(lstrArr(lint).IndexOf(">") + 1, _
                                                                lstrArr(lint).Length - lstrArr(lint).IndexOf(">") - 1).Trim
                                                Else
                                                    ldrNew(lint) = lstrArr(lint)
                                                End If
                                                ldrSearch = lFncSearch("clt_code", ldrNew(lint), dtClient)
                                                ldrNew("client_name") = ""
                                                If Not IsNothing(ldrSearch) Then
                                                    ldrNew("client_name") = ldrSearch("clt_name")
                                                End If

                                            Case Else
                                                ldrNew(lint) = lstrArr(lint)
                                        End Select
                                    Next
                                    ldrNew("match") = "*"
                                    dtTrans.Rows.Add(ldrNew)
                                End If

                            End If
                        End If
                    End If
                End If
            Loop
            sReader.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

        Return True

    End Function

    Protected Friend Function lFncGetfile2(ByVal strFile As String, ByVal strTime As String, _
   ByVal dtHSI As DataTable, ByVal dtClient As DataTable, ByVal dtStock As DataTable, _
  ByRef dtTrans2 As DataTable, ByVal decLot As Decimal) As Boolean
        Dim strLine As String = ""
        Dim lstrDate As String = ""
        Dim lstrFileName As String
        Dim sReader As StreamReader
        Dim lstrArr(16) As String

        ' Me.ListBox1.Items.Clear()
        lstrFileName = strFile.Substring(strFile.LastIndexOfAny("\") + 1, strFile.Length - strFile.LastIndexOfAny("\") - 1)
        If lstrFileName.Length < 8 Then
            Return False
        End If
        If Not IsNumeric(lstrFileName.Substring(0, 8)) Then
            Return False
        End If

        lstrDate = lstrFileName.Substring(6, 2) & "/" & lstrFileName.Substring(4, 2) & "/" & lstrFileName.Substring(0, 4)

        Try
            sReader = New StreamReader(strFile)
            Do While Not sReader.EndOfStream
                strLine = sReader.ReadLine()
                ' Me.ListBox1.Items.Add(strLine)
                For lint As Int16 = 0 To 15
                    lstrArr(lint) = ""
                Next
                Dim lstrTemp As String = strLine
                Dim lintstart As Integer = 0

                Dim lintidx As Int16 = 0
                Do While lstrTemp.IndexOf(",") >= 0
                    Dim lstrPart As String = lstrTemp.Substring(lintstart, lstrTemp.IndexOf(","))
                    'Me.ListBox1.Items.Add(lstrPart)
                    lstrArr(lintidx) = lstrPart
                    lintidx += 1
                    lstrTemp = lstrTemp.Substring(lstrTemp.IndexOf(",") + 1, lstrTemp.Length - lstrPart.Length - 1)
                    lintstart = 0
                Loop
                If lstrTemp.Length > 0 Then
                    'Me.ListBox1.Items.Add(lstrTemp)
                    lstrArr(lintidx) = lstrTemp
                End If
                'If lstrArr(3) > strTime And lstrArr(3) <= "16:00:00" And _
                'lstrArr(2) = lstrDate And lstrArr(4) <> "Cancel Order" Then
                If lstrArr(4) <> "Cancel Order" Then
                    Dim ldrSearch As DataRow = Nothing
                    Dim lstrStock As String = ""

                    If lstrArr(8).IndexOf(" ") > 0 Then
                        lstrStock = lstrArr(8).Substring(0, lstrArr(8).IndexOf(" "))
                    End If
                    ldrSearch = lFncSearch("hsi_stock", lstrStock, dtHSI)
                    If IsNothing(ldrSearch) Then
                        Dim ldecDefaultLot As Decimal = 0
                        Dim ldecLot As Decimal = 0
                        ldrSearch = lFncSearch("stkno", lfncFillZero(lstrStock), dtStock)
                        If Not IsNothing(ldrSearch) Then
                            ldecDefaultLot = ldrSearch("lot")
                            If ldecDefaultLot > 0 Then
                                Dim ldrNew As DataRow = dtTrans2.NewRow
                                ldecLot = Val(GFncNoNullString(lstrArr(12))) / ldecDefaultLot
                                If (ldecLot <= decLot) And lstrArr(3) > strTime And lstrArr(3) <= "16:00:00" And _
                                    lstrArr(2) = lstrDate And lstrArr(4) <> "Cancel Order" Then
                                    ldrNew("match") = "*"
                                Else : ldrNew("match") = ""
                                End If
                                ldrNew("stock_no") = lstrStock
                                ldrNew("lot") = ldecLot
                                For lint As Int16 = 0 To 15
                                    Select Case lint
                                        Case 0    'client
                                            If lstrArr(lint).IndexOf(">") Then
                                                ldrNew(lint) = lstrArr(lint).Substring(lstrArr(lint).IndexOf(">") + 1, _
                                                            lstrArr(lint).Length - lstrArr(lint).IndexOf(">") - 1).Trim
                                            Else
                                                ldrNew(lint) = lstrArr(lint)
                                            End If
                                            ldrSearch = lFncSearch("clt_code", ldrNew(lint), dtClient)
                                            ldrNew("client_name") = ""
                                            If Not IsNothing(ldrSearch) Then
                                                ldrNew("client_name") = ldrSearch("clt_name")
                                            End If

                                        Case Else
                                            ldrNew(lint) = lstrArr(lint)
                                    End Select
                                Next
                                dtTrans2.Rows.Add(ldrNew)
                            End If

                        End If
                    End If
                End If
                'End If
            Loop
            sReader.Close()


        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return False
        End Try

        Return True

    End Function


End Class
