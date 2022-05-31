Imports System.IO
Imports NPOI.HSSF.UserModel
Imports NPOI.HPSF
Imports NPOI.POIFS.FileSystem
Imports System.Threading
Imports System.Globalization

Public Class FrmRptTradeHistory
    Dim clsRpt As clsRptTradeHistory = New clsRptTradeHistory

    Private Sub lsubEnableProcess(ByVal bEnable As Boolean)
        lblProcess.Visible = bEnable
        pbarProcess.Visible = bEnable
        If bEnable Then pbarProcess.Value = 0
    End Sub

    Private Function isInputValid() As Boolean
        Return True
    End Function

    Private Sub FrmRptTradeHistory_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Thread.CurrentThread.CurrentCulture = New CultureInfo(GFncGetCulture())
        System.Threading.Thread.CurrentThread.CurrentUICulture = New CultureInfo(GFncGetCulture())

        'Thread.CurrentThread.CurrentCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy"

        DTPFrom.Format = DateTimePickerFormat.Custom
        DTPFrom.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern
        Me.DTPFrom.Value = Now

        DTPTo.Format = DateTimePickerFormat.Custom
        DTPTo.CustomFormat = Application.CurrentCulture.DateTimeFormat.ShortDatePattern
        Me.DTPTo.Value = Now

        Dim cCodeDt As DataTable = clsRpt.getClientCode()

        Me.cboClientCode.DataSource = cCodeDt

        'Me.cboClientCode.DataSource = GDtClientCode

        Me.cboClientCode.ValueMember = "CLT_CODE"
        Me.btnSend.Visible = False
        lsubEnableProcess(False)
        lsubEnableForm(True)
    End Sub
    Private Function lSubMakePosition(ByVal dteTX As Date, ByVal dtPosition As DataTable, _
    ByVal dtTrade As DataTable, ByVal dtStock As DataTable) As DataTable

        Dim ldt As New DataTable
        Dim ldr As DataRow

        ldt.Columns.Add("tx_date", System.Type.GetType("System.DateTime"))
        ldt.Columns.Add("stkno", System.Type.GetType("System.String"))
        ldt.Columns.Add("stock_code", System.Type.GetType("System.String"))
        ldt.Columns.Add("qty", System.Type.GetType("System.Decimal"))

        For Each ldrPosition As DataRow In dtPosition.Rows
            ldr = ldt.NewRow
            ldr("stkno") = GFncNoNullString(ldrPosition("stk_code")).Trim
            ldr("stock_code") = Me.lfncFindStockName(GFncNoNullString(ldrPosition("stk_code")).Trim, dtStock)
            ldr("qty") = GFncNoNullValue(ldrPosition("net_qty"))
            ldr("tx_date") = dteTX
            ldt.Rows.Add(ldr)
        Next

        Dim ldrTrade() As DataRow = dtTrade.Select(" tx_date >= '" & Format(dteTX, "yyyy/MM/dd") & "'", " tx_date desc ")
        Dim lblnUpdate As Boolean = False
        For lintCnt As Int16 = 0 To ldrTrade.Length - 1
            lblnUpdate = False
            For Each ldr In ldt.Rows
                If ldr("stkno").ToString.Trim = GFncNoNullString(ldrTrade(lintCnt).Item("stkno")).Trim Then
                    lblnUpdate = True
                    ldr("qty") -= GFncNoNullValue(ldrTrade(lintCnt).Item("qty"))
                End If
            Next
            If Not lblnUpdate Then
                ldr = ldt.NewRow
                ldr("stkno") = GFncNoNullString(ldrTrade(lintCnt).Item("stkno")).Trim
                ldr("stock_code") = Me.lfncFindStockName(GFncNoNullString(ldrTrade(lintCnt).Item("stkno")).Trim, dtStock)
                ldr("qty") = GFncNoNullValue(ldrTrade(lintCnt).Item("qty")) * (-1)
                ldr("tx_date") = dteTX
                ldt.Rows.Add(ldr)
            End If
        Next

        Return ldt

    End Function
    Private Function lfncFindHolding(ByVal intRow As Int16, ByVal drTrade() As DataRow, _
    ByVal dtPosition As DataTable) As Decimal

        Dim ldecHolding As Decimal = 0

        For Each ldrPosition As DataRow In dtPosition.Rows
            If GFncNoNullString(ldrPosition("stkno")).Trim = drTrade(intRow).Item("stkno") Then
                ldecHolding += GFncNoNullValue(ldrPosition("qty"))
            End If
        Next

        For lintCnt As Int16 = 0 To intRow
            If drTrade(lintCnt).Item("stkno") = drTrade(intRow).Item("stkno") Then
                ldecHolding += GFncNoNullValue(drTrade(lintCnt).Item("qty"))
            End If
        Next

        Return ldecHolding

    End Function
    Private Function lfncFindStockName(ByVal strStkno As String, _
    ByVal dtStock As DataTable) As String

        Dim ldr() As DataRow = dtStock.Select("stock_no = '" & strStkno.Trim & "' ")

        If ldr.Length > 0 Then
            Return GFncNoNullString(ldr(0).Item("name")).Trim
        End If

        Return ""

    End Function
    Private Function lfncFormatDec(ByVal dec As Decimal, _
    Optional ByVal blnWithDollar As Boolean = True) As String

        dec = GFncNoNullValue(dec)
        If blnWithDollar Then
            If dec >= 0 Then
                Return Format(Math.Abs(dec), "$###,###,###,###,##0")
            Else
                Return Format(Math.Abs(dec), "($###,###,###,###,##0)")
            End If
        Else
            If dec >= 0 Then
                Return Format(Math.Abs(dec), "###,###,###,###,##0")
            Else
                Return Format(Math.Abs(dec), "(###,###,###,###,##0)")
            End If
        End If

    End Function
    'Original, comment out by king
    'Private Sub handleExportSave(ByVal path As String)

    Private Sub handleExportSave(ByVal clientCode As String, ByVal date_from As Date, ByVal date_to As Date, _
                                Optional ByVal path As String = "", Optional ByRef result As HSSFWorkbook = Nothing, _
                                Optional ByVal dt_rpt_src As DataTable = Nothing, Optional ByVal dt_pos_src As DataTable = Nothing, _
                                Optional ByVal dt_stkMst_src As DataTable = Nothing, Optional ByVal ledgerBal As String = "")

        'added by king
        Dim isNeedAlert As Boolean = False

        Dim workbook As HSSFWorkbook = New HSSFWorkbook()
        Dim u_sheet As HSSFSheet = workbook.CreateSheet("My Sheet")

        Dim lstrClientName As String = clsRpt.getClientName(clientCode)

        'Dim sIndex As Integer = Me.cboClientCode.SelectedIndex

        'Dim clientCodeDt As DataTable = clsRpt.getClientCode

        'Dim clientCode As String = GFncNoNullString(clientCodeDt.Rows(sIndex)("CLT_CODE"))

        'comment out by king
        'Dim clientCode As String = GFncNoNullString(Me.cboClientCode.Text)

        'replace clientCode by clientCode_from by king
        Dim resultDt As DataTable = dt_rpt_src
        If IsNothing(dt_rpt_src) Then
            resultDt = clsRpt.genRptDt(clientCode)
        End If

        Dim ldtPosition As DataTable = dt_pos_src
        If IsNothing(dt_pos_src) Then
            ldtPosition = clsRpt.getPosition(clientCode)
        End If

        Dim ldtStkMst As DataTable = dt_stkMst_src
        If IsNothing(dt_stkMst_src) Then
            ldtStkMst = clsRpt.getStockMaster()
        End If

        resultDt.Columns.Add("tx_date", System.Type.GetType("System.DateTime"))
        resultDt.Columns.Add("buy_sell", System.Type.GetType("System.String"))
        resultDt.Columns.Add("New_Holding", System.Type.GetType("System.Decimal"))

        Dim lintRow As Int16 = -1
        For Each resultDr As DataRow In resultDt.Rows
            Dim strDate As String = resultDr("trade_date")
            'Dim strDay As String = strDate.Split(" ")(0)
            'Dim strMonth As String = strDate.Split(" ")(1)
            'Dim strYear As String = strDate.Split(" ")(2)

            Dim txDate As Date = CDate(strDate)
            resultDr("tx_date") = txDate

            Dim bs As String = resultDr("bs")

            If bs.ToUpper = "B" Then
                resultDr("buy_sell") = "Buy"
            ElseIf bs.ToUpper = "S" Then
                resultDr("buy_sell") = "Sell"
                resultDr("qty") = (resultDr("qty") * (-1))
                resultDr("consideration") = (resultDr("consideration") * (-1))
            End If
            resultDr("stock_code") = Me.lfncFindStockName(resultDr("stkno"), ldtStkMst)
        Next

        'replace DTPFrom.value, DTPTo.value by date_from, date_to by king
        Dim ldtPosFrom As DataTable = Me.lSubMakePosition(date_from, ldtPosition, resultDt, ldtStkMst)
        Dim ldtPosTo As DataTable = Me.lSubMakePosition(date_to.AddDays(1), ldtPosition, resultDt, ldtStkMst)

        Dim SortableView As DataView = resultDt.DefaultView
        SortableView.Sort = "tx_date asc"
        resultDt = SortableView.ToTable


        Dim rptDate As Date = Date.Now
        Dim shiftRow As Integer = 2
        Dim shiftCol As Integer = 0

        Dim maxColCnt As Integer = 5

        'replace DTPFrom.value, DTPTo.value by date_from, date_to by king
        Dim strFrmDate As String = Format(date_from, "dd MMM yyyy")
        Dim strToDate As String = Format(date_to, "dd MMM yyyy")

        Dim headerDateFont As HSSFFont = workbook.CreateFont
        Dim headerDateStyle As HSSFCellStyle = workbook.CreateCellStyle
        headerDateFont.Underline = HSSFFont.U_SINGLE
        headerDateFont.Boldweight = HSSFFont.BOLDWEIGHT_BOLD
        headerDateStyle.SetFont(headerDateFont)

        Dim headerFont As HSSFFont = workbook.CreateFont
        Dim headerStyle As HSSFCellStyle = workbook.CreateCellStyle
        headerStyle.Alignment = HSSFCellStyle.ALIGN_CENTER
        headerFont.Boldweight = HSSFFont.BOLDWEIGHT_BOLD
        headerStyle.SetFont(headerFont)

        Dim numericFont As HSSFFont = workbook.CreateFont
        Dim numericStyle As HSSFCellStyle = workbook.CreateCellStyle
        numericStyle.Alignment = HSSFCellStyle.ALIGN_RIGHT

        Dim MidFont As HSSFFont = workbook.CreateFont
        Dim MidStyle As HSSFCellStyle = workbook.CreateCellStyle
        MidStyle.Alignment = HSSFCellStyle.ALIGN_CENTER

        lintRow = 0
        Dim i As Int16
        u_sheet.CreateRow(lintRow)
        u_sheet.GetRow(lintRow).CreateCell(0).SetCellValue("PIA as at " & strFrmDate & " (Date of Formal Approval) for " & clientCode & " - " & lstrClientName)
        u_sheet.GetRow(lintRow).GetCell(0).CellStyle = headerDateStyle

        lintRow += 1
        u_sheet.CreateRow(lintRow)

        u_sheet.GetRow(lintRow).CreateCell(0).SetCellValue("Date")
        u_sheet.GetRow(lintRow).CreateCell(1).SetCellValue("")
        u_sheet.GetRow(lintRow).CreateCell(2).SetCellValue("Asset Name")
        u_sheet.GetRow(lintRow).CreateCell(3).SetCellValue("Stock Code")
        u_sheet.GetRow(lintRow).CreateCell(4).SetCellValue("Holding")

        u_sheet.SetColumnWidth(0, 10 * 256)
        u_sheet.SetColumnWidth(1, 8 * 256)
        u_sheet.SetColumnWidth(2, 50 * 256)
        u_sheet.SetColumnWidth(3, 20 * 256)
        u_sheet.SetColumnWidth(4, 20 * 256)
        u_sheet.SetColumnWidth(5, 8 * 256)
        u_sheet.SetColumnWidth(6, 20 * 256)
        u_sheet.SetColumnWidth(7, 20 * 256)
        u_sheet.SetColumnWidth(8, 20 * 256)
        u_sheet.SetColumnWidth(9, 20 * 256)

        For i = 0 To 4
            u_sheet.GetRow(lintRow).GetCell(i).CellStyle = headerStyle
        Next
        Dim lblnST As Boolean = True
        For Each ldrPosFrom As DataRow In ldtPosFrom.Rows
            If ldrPosFrom.Item("qty") <> 0 Then
                lintRow += 1
                u_sheet.CreateRow(lintRow)
                If lblnST Then
                    'replace DTPFrom.value, DTPTo.value by date_from, date_to by king
                    u_sheet.GetRow(lintRow).CreateCell(0).SetCellValue(Format(date_from, "dd-MMM-yy"))
                    lblnST = False
                End If
                u_sheet.GetRow(lintRow).CreateCell(2).SetCellValue(ldrPosFrom.Item("stock_code").ToString)
                u_sheet.GetRow(lintRow).CreateCell(3).SetCellValue(ldrPosFrom.Item("stkno").ToString)
                u_sheet.GetRow(lintRow).CreateCell(4).SetCellValue(Format(ldrPosFrom.Item("qty"), "###,###,###,###,##0"))
                u_sheet.GetRow(lintRow).GetCell(4).CellStyle = numericStyle
                u_sheet.GetRow(lintRow).GetCell(2).CellStyle = MidStyle
                u_sheet.GetRow(lintRow).GetCell(3).CellStyle = MidStyle
            End If
        Next

        lintRow += 2
        u_sheet.CreateRow(lintRow)
        u_sheet.GetRow(lintRow).CreateCell(0).SetCellValue("Transaction history from " & strFrmDate & " to " & strToDate)
        u_sheet.GetRow(lintRow).GetCell(0).CellStyle = headerDateStyle

        lintRow += 1
        u_sheet.CreateRow(lintRow)
        u_sheet.GetRow(lintRow).CreateCell(0).SetCellValue("Date")
        u_sheet.GetRow(lintRow).CreateCell(1).SetCellValue("Buy/Sell")
        u_sheet.GetRow(lintRow).CreateCell(2).SetCellValue("Asset Name")
        u_sheet.GetRow(lintRow).CreateCell(3).SetCellValue("Stock Code")
        u_sheet.GetRow(lintRow).CreateCell(4).SetCellValue("Quantity")
        u_sheet.GetRow(lintRow).CreateCell(5).SetCellValue("")
        u_sheet.GetRow(lintRow).CreateCell(6).SetCellValue("Unit price")
        u_sheet.GetRow(lintRow).CreateCell(7).SetCellValue("Consideration")
        u_sheet.GetRow(lintRow).CreateCell(8).SetCellValue("New holding")
        u_sheet.GetRow(lintRow).CreateCell(9).SetCellValue("Reinvesment deadline")

        For i = 0 To 9
            u_sheet.GetRow(lintRow).GetCell(i).CellStyle = headerStyle
        Next

        'replace DTPFrom.value, DTPTo.value by date_from, date_to by king
        Dim strFrm As String = Format(date_from, "yyyy/MM/dd")
        Dim strTo As String = Format(date_to, "yyyy/MM/dd")

        Dim resultDrs() As DataRow = resultDt.Select("tx_date >='" & strFrm & "' and tx_date <='" & strTo & "'", "tx_date, bs desc")

        Dim rowCNT As Integer = resultDrs.Length

        Dim balanceAmt As Decimal = 0
        Dim ldteDeadline As Date
        Dim extraRCnt As Integer = 0

        Dim isSellBefore As Boolean = False
        shiftRow = lintRow + 1
        i = 0
        For i = 0 To rowCNT - 1
            resultDrs(i).Item("New_Holding") = Me.lfncFindHolding(i, resultDrs, ldtPosFrom)
        Next
        For i = 0 To rowCNT - 1

            u_sheet.CreateRow(i + shiftRow + extraRCnt)

            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(0).SetCellValue(Format(GFncNoNullDate(resultDrs(i).Item("tx_date")), "dd-MMM-yy"))
            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(1).SetCellValue(resultDrs(i).Item("buy_sell").ToString)
            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(2).SetCellValue(resultDrs(i).Item("stock_code").ToString)
            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(3).SetCellValue(resultDrs(i).Item("stkno").ToString)

            u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(2).CellStyle = MidStyle
            u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(1).CellStyle = MidStyle
            u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(3).CellStyle = MidStyle

            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(4).SetCellValue(Me.lfncFormatDec(resultDrs(i).Item("qty"), False))
            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(5).SetCellValue(resultDrs(i).Item("currency_code_set"))
            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(6).SetCellValue(Format(resultDrs(i).Item("price"), "###,###,###,###,##0.000"))
            u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(5).CellStyle = MidStyle
            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(7).SetCellValue(Me.lfncFormatDec(resultDrs(i).Item("consideration")))
            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(8).SetCellValue(Format(resultDrs(i).Item("New_Holding"), "###,###,###,###,##0"))


            u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(4).CellStyle = numericStyle
            u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(6).CellStyle = numericStyle
            u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(7).CellStyle = numericStyle
            u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(8).CellStyle = numericStyle


            balanceAmt += GFncNoNullValue(resultDrs(i).Item("consideration"))

            Dim bs As String = GFncNoNullString(resultDrs(i)("bs"))

            Dim lstrSumType As String = ""
            If isSellBefore Then
                If (balanceAmt >= 0) And (bs.ToUpper = "B") Then
                    lstrSumType = "Complied"
                ElseIf balanceAmt < 0 Then
                    If i = rowCNT - 1 Then
                        lstrSumType = "Not Complied"
                    Else
                        If ldteDeadline < GFncNoNullDate(resultDrs(i + 1).Item("tx_date")) Then
                            lstrSumType = "Not Complied"
                        End If
                    End If
                End If
            End If
            If lstrSumType = "Complied" Then

                extraRCnt += 1
                u_sheet.CreateRow(i + shiftRow + extraRCnt)

                For x As Integer = 0 To 9
                    u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(x)
                Next

                Dim cellRegion As NPOI.HSSF.Util.Region = New NPOI.HSSF.Util.Region((i + shiftRow + extraRCnt), 0, (i + shiftRow + extraRCnt), 6)
                u_sheet.AddMergedRegion(cellRegion)

                Dim strRemark As String = "5.1(b)(vii) and 7.2(b) are compiled with reinvestment surplus"

                u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(0).SetCellValue(strRemark)
                u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(7).SetCellValue(Me.lfncFormatDec(balanceAmt))

                u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(7).CellStyle = numericStyle
                Dim remarkFont As HSSFFont = workbook.CreateFont
                Dim remarkStyle As HSSFCellStyle = workbook.CreateCellStyle
                remarkFont.IsItalic = True
                remarkStyle.SetFont(remarkFont)
                remarkStyle.Alignment = HSSFCellStyle.ALIGN_CENTER

                u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(0).CellStyle = remarkStyle

                balanceAmt = 0

                isSellBefore = False
            ElseIf lstrSumType = "Not Complied" Then
                extraRCnt += 1
                u_sheet.CreateRow(i + shiftRow + extraRCnt)

                For x As Integer = 0 To 9
                    u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(x)
                Next

                Dim cellRegion As NPOI.HSSF.Util.Region = New NPOI.HSSF.Util.Region((i + shiftRow + extraRCnt), 0, (i + shiftRow + extraRCnt), 6)
                u_sheet.AddMergedRegion(cellRegion)

                Dim strRemark As String = "5.1(b)(vii) and 7.2(b) are Breached with reinvestment deficits"

                u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(0).SetCellValue(strRemark)
                u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(7).SetCellValue(Me.lfncFormatDec(balanceAmt))

                u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(7).CellStyle = numericStyle
                Dim remarkFont As HSSFFont = workbook.CreateFont
                Dim remarkStyle As HSSFCellStyle = workbook.CreateCellStyle
                remarkFont.IsItalic = True
                remarkStyle.SetFont(remarkFont)
                remarkStyle.Alignment = HSSFCellStyle.ALIGN_CENTER

                u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(0).CellStyle = remarkStyle

                balanceAmt = 0

                isSellBefore = False

                'added by king
                isNeedAlert = True

            End If

            If isSellBefore = False And bs.ToUpper = "S" Then
                If Not isSellBefore Then
                    ldteDeadline = GFncNoNullDate(resultDrs(i).Item("tx_date")).AddDays(14)
                End If
                isSellBefore = True

                Dim deadLineDate As Date = GFncNoNullDate(resultDrs(i).Item("tx_date")).AddDays(14)

                u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(9).SetCellValue(Format(deadLineDate, "dd-MMM-yy"))
                u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(9).CellStyle = MidStyle
            ElseIf isSellBefore = False And bs.ToUpper = "B" And balanceAmt > 0 Then
                If i < resultDrs.Length - 1 Then
                    If GFncNoNullString(resultDrs(i + 1)("bs")).ToUpper = "S" Then
                        extraRCnt += 1
                        u_sheet.CreateRow(i + shiftRow + extraRCnt)
                        For x As Integer = 0 To 9
                            u_sheet.GetRow(i + shiftRow + extraRCnt).CreateCell(x)
                        Next
                        Dim cellRegion As NPOI.HSSF.Util.Region = New NPOI.HSSF.Util.Region((i + shiftRow + extraRCnt), 0, (i + shiftRow + extraRCnt), 6)
                        u_sheet.AddMergedRegion(cellRegion)
                        Dim strRemark As String = "************************************************"
                        u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(0).SetCellValue(strRemark)
                        Dim remarkFont As HSSFFont = workbook.CreateFont
                        Dim remarkStyle As HSSFCellStyle = workbook.CreateCellStyle
                        remarkFont.IsItalic = True
                        remarkStyle.SetFont(remarkFont)
                        remarkStyle.Alignment = HSSFCellStyle.ALIGN_CENTER

                        u_sheet.GetRow(i + shiftRow + extraRCnt).GetCell(0).CellStyle = remarkStyle
                        balanceAmt = 0
                    End If
                End If
            End If

        Next

        lintRow = i + shiftRow + extraRCnt + 2
        u_sheet.CreateRow(lintRow)
        u_sheet.GetRow(lintRow).CreateCell(0).SetCellValue("PIA as at " & strToDate & " (The Reporting Date: 3months before limit of star expire) ")
        u_sheet.GetRow(lintRow).GetCell(0).CellStyle = headerDateStyle

        lintRow += 1
        u_sheet.CreateRow(lintRow)

        u_sheet.GetRow(lintRow).CreateCell(0).SetCellValue("Date")
        u_sheet.GetRow(lintRow).CreateCell(1).SetCellValue("")
        u_sheet.GetRow(lintRow).CreateCell(2).SetCellValue("Asset Name")
        u_sheet.GetRow(lintRow).CreateCell(3).SetCellValue("Stock Code")
        u_sheet.GetRow(lintRow).CreateCell(4).SetCellValue("Holding")

        For i = 0 To 4
            u_sheet.GetRow(lintRow).GetCell(i).CellStyle = headerStyle
        Next

        lblnST = True
        For Each ldrPosTo As DataRow In ldtPosTo.Rows
            If ldrPosTo.Item("qty") <> 0 Then
                lintRow += 1
                u_sheet.CreateRow(lintRow)
                If lblnST Then
                    'replace DTPFrom.value, DTPTo.value by date_from, date_to by king
                    u_sheet.GetRow(lintRow).CreateCell(0).SetCellValue(Format(date_to, "dd-MMM-yy"))
                    lblnST = False
                End If
                u_sheet.GetRow(lintRow).CreateCell(2).SetCellValue(ldrPosTo.Item("stock_code").ToString)
                u_sheet.GetRow(lintRow).CreateCell(3).SetCellValue(ldrPosTo.Item("stkno").ToString)
                u_sheet.GetRow(lintRow).CreateCell(4).SetCellValue(Format(ldrPosTo.Item("qty"), "###,###,###,###,##0"))
                u_sheet.GetRow(lintRow).GetCell(4).CellStyle = numericStyle
                u_sheet.GetRow(lintRow).GetCell(2).CellStyle = MidStyle
                u_sheet.GetRow(lintRow).GetCell(3).CellStyle = MidStyle
            End If
        Next

        'set ledger balance
        lintRow += 2
        u_sheet.CreateRow(lintRow)
        Dim cellMergedRegion As NPOI.HSSF.Util.Region = New NPOI.HSSF.Util.Region(lintRow, 0, lintRow, 2)
        u_sheet.AddMergedRegion(cellMergedRegion)
        u_sheet.GetRow(lintRow).CreateCell(0).SetCellValue("Ledger Balance on trade date (" & GDteTradeDate & "): ")

        If ledgerBal <> "" Then
            u_sheet.GetRow(lintRow).CreateCell(3).SetCellValue(ledgerBal)
        Else
            u_sheet.GetRow(lintRow).CreateCell(3).SetCellValue(clsRpt.getLedgerBalance(clientCode))
        End If
        u_sheet.GetRow(lintRow).GetCell(3).CellStyle = numericStyle

        'add if-statement by king
        If path <> "" Then
            Dim file As FileStream = New FileStream(path, FileMode.Create)
            workbook.Write(file)
            file.Close()
            GSubShowInfo(GFncGetSysMsg(28))
        End If
        'add finished

        'added by king
        If IsNothing(result) = False Then
            result = workbook
        End If

    End Sub

    Private Sub handleSaveDialog()
        Dim MyFileSave As New System.Windows.Forms.SaveFileDialog
        Dim bExOccured As Boolean
        Dim retVal As DialogResult


        Try
            ' does not add an extension to a file name if the user omits the extension
            MyFileSave.AddExtension = True
            MyFileSave.Filter = "Excel Files (*.xls)|*.xls"

            retVal = MyFileSave.ShowDialog()
            If retVal = Windows.Forms.DialogResult.OK Then

                If MyFileSave.CheckPathExists = True Then
                    'comment out by king
                    'handleExportSave(MyFileSave.FileName)
                    handleExportSave(Me.cboClientCode.Text, Me.DTPFrom.Value, Me.DTPTo.Value, MyFileSave.FileName)
                Else
                    GSubShowInfo(GFncGetSysMsg(9))
                End If
            End If

            'Me.btnOK.Visible = False
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
            bExOccured = True
            lsubEnableProcess(False)
            Windows.Forms.Cursor.Current = Cursors.Default
            ' Me.btnOK.Visible = False
        End Try

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        If isInputValid() Then
            Application.DoEvents()
            lsubEnableProcess(True)
            lsubEnableForm(False)

            handleSaveDialog()

            lsubEnableProcess(False)
            lsubEnableForm(True)
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        Me.btnCancel.Visible = bEnable
        Me.btnSend.Visible = bEnable
        Me.btnPrint.Visible = bEnable
        Me.DTPFrom.Enabled = bEnable
        Me.DTPTo.Enabled = bEnable
        Me.cboClientCode.Enabled = bEnable
    End Sub

    Private Function checkDeficits(ByVal excelStream As HSSFWorkbook) As Boolean
        For i As Integer = 0 To excelStream.GetSheet("My Sheet").LastRowNum
            If IsNothing(excelStream.GetSheet("My Sheet").GetRow(i)) = False AndAlso IsNothing(excelStream.GetSheet("My Sheet").GetRow(i).GetCell(0)) = False _
            AndAlso excelStream.GetSheet("My Sheet").GetRow(i).GetCell(0).ToString = "5.1(b)(vii) and 7.2(b) are Breached with reinvestment deficits" Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function getStartPos(ByVal excelStream As HSSFWorkbook) As Integer
        Dim result As Integer = 0

        For i As Integer = 0 To excelStream.GetSheet("My Sheet").LastRowNum - 1
            If IsNothing(excelStream.GetSheet("My Sheet").GetRow(i)) = False AndAlso IsNothing(excelStream.GetSheet("My Sheet").GetRow(i).GetCell(0)) = False Then
                If excelStream.GetSheet("My Sheet").GetRow(i).GetCell(0).ToString.Contains("Transaction history from") = True Then
                    result = i
                End If
            End If
        Next
        Return result
    End Function

    Private Function getEndPos(ByVal excelStream As HSSFWorkbook) As Integer
        Dim result As Integer = 0

        For i As Integer = 0 To excelStream.GetSheet("My Sheet").LastRowNum - 1
            If IsNothing(excelStream.GetSheet("My Sheet").GetRow(i)) = False AndAlso IsNothing(excelStream.GetSheet("My Sheet").GetRow(i).GetCell(0)) = False Then
                If excelStream.GetSheet("My Sheet").GetRow(i).GetCell(0).ToString = "5.1(b)(vii) and 7.2(b) are Breached with reinvestment deficits" Then
                    result = i
                End If
            End If
        Next

        Return result
    End Function

    Private Function getMidPos(ByVal excelStream As HSSFWorkbook, ByVal startPos As Integer, ByVal endPos As Integer) As Integer
        Dim result As Integer = startPos

        For i As Integer = endPos - 1 To startPos Step -1
            If IsNothing(excelStream.GetSheet("My Sheet").GetRow(i).GetCell(9)) = False AndAlso excelStream.GetSheet("My Sheet").GetRow(i).GetCell(9).ToString <> "" Then
                result = i
                Exit For
            End If
        Next

        Return result
    End Function


    Private Function setAlertContent(ByVal excelStream As HSSFWorkbook, ByVal date_from As Date, ByVal date_to As Date, _
                                        ByVal clientCode As String, ByVal clientName As String) As String

        Dim startPos As Integer = 0
        Dim midPos As Integer = 0
        Dim endPos As Integer = excelStream.GetSheet("My Sheet").LastRowNum

        Dim strFrmDate As String = Format(date_from, "dd MMM yyyy")
        Dim strToDate As String = Format(date_to, "dd MMM yyyy")

        Dim content As String = ""

        startPos = getStartPos(excelStream)
        endPos = getEndPos(excelStream)

        'find the last pos of Reinvesment deadline
        midPos = getMidPos(excelStream, startPos, endPos)

        content += "<table border=1><tr><td colspan=10>"
        content += "Account No.: " & clientCode
        content += " Account Name: " & clientName
        content += "</tr></td>"
        For i As Integer = startPos To startPos + 1
            content += "<tr>"
            For j As Integer = 0 To excelStream.GetSheet("My Sheet").GetRow(i).LastCellNum - 1
                If i = startPos AndAlso j = 0 Then
                    content += "<td colspan=10>"
                Else
                    content += "<td>"
                End If
                content += excelStream.GetSheet("My Sheet").GetRow(i).GetCell(j).ToString
                content += "</td>"
            Next
            content += "</tr>"
        Next

        For i As Integer = midPos To endPos
            content += "<tr>"
            For j As Integer = 0 To excelStream.GetSheet("My Sheet").GetRow(i).LastCellNum - 1
                If excelStream.GetSheet("My Sheet").GetRow(i).GetCell(j).ToString = "" AndAlso i = endPos Then
                    Continue For
                End If

                If i = startPos AndAlso j = 0 Then
                    content += "<td colspan=10>"
                    'ElseIf i = endPos AndAlso j = 0 Then
                    '    content += "<td colspan=7 style=""text-align:center;"">"
                ElseIf excelStream.GetSheet("My Sheet").GetRow(i).GetCell(j).ToString = "5.1(b)(vii) and 7.2(b) are compiled with reinvestment surplus" _
                    OrElse excelStream.GetSheet("My Sheet").GetRow(i).GetCell(j).ToString = "************************************************" _
                    OrElse excelStream.GetSheet("My Sheet").GetRow(i).GetCell(j).ToString = "5.1(b)(vii) and 7.2(b) are Breached with reinvestment deficits" Then
                    content += "<td colspan=7 style=""text-align:center;"">"
                    'content += excelStream.GetSheet("My Sheet").GetRow(i).GetCell(j).ToString
                    content += "</td>"
                    j += 6
                    Continue For
                Else
                    content += "<td>"
                End If

                If i = endPos AndAlso j = excelStream.GetSheet("My Sheet").GetRow(i).LastCellNum - 1 Then
                    content += "<td></td>"
                End If

                content += excelStream.GetSheet("My Sheet").GetRow(i).GetCell(j).ToString
                content += "</td>"

            Next
            content += "</tr>"
        Next

        content += "<tr><td colspan=3>" & excelStream.GetSheet("My Sheet").GetRow(excelStream.GetSheet("My Sheet").LastRowNum).GetCell(0).ToString & "</td>"
        content += "<td>" & excelStream.GetSheet("My Sheet").GetRow(excelStream.GetSheet("My Sheet").LastRowNum).GetCell(3).ToString & "</td></tr>"
        content += "</table>"

        content += "</br><p></p>"
        Return content
    End Function

    Private Function getLedgerBal(ByVal rowArray() As DataRow) As String
        Dim result As String = ""

        For m As Integer = 0 To rowArray.Length - 1
            If rowArray(m).Item("CR_BAL") > 0 Then
                result = rowArray(m).Item("CR_BAL").ToString
            ElseIf rowArray(m).Item("CR_BAL") = 0 AndAlso rowArray(m).Item("DR_BAL") > 0 Then
                result = (rowArray(m).Item("DR_BAL") * -1).ToString
            End If

        Next

        Return result
    End Function

    Private Function getReportDt(ByVal dt_Header As DataTable, ByVal rowArray() As DataRow) As DataTable
        Dim result As DataTable = dt_Header

        For m As Integer = 0 To rowArray.Length - 1
            result.Rows.Add(rowArray(m).ItemArray)
        Next

        Return result
    End Function

    Private Function getPositionDt(ByVal dt_Header As DataTable, ByVal rowArray() As DataRow) As DataTable
        Dim result As DataTable = dt_Header

        For m As Integer = 0 To rowArray.Length - 1
            result.Rows.Add(rowArray(m).ItemArray)
        Next

        Return result
    End Function

    Private Function checkDateMatch(ByVal dateToCheck As Date) As Boolean
        If dateToCheck = GDteTradeDate Then
            Return True
        End If
        Return False
    End Function

    Private Sub handleSendAlert()
        Dim toDoList As DataTable = New DataTable

        'Dim date_from As Date = GDteTradeDate.AddDays(-10)
        'Dim date_to As Date = GDteTradeDate
        Dim date_from As Date = Nothing
        Dim date_to As Date = Nothing

        Dim strSQL As String
        Dim clientCode As DataTable = New DataTable
        Dim result As HSSFWorkbook = New HSSFWorkbook()
        Dim alertContent As String = ""
        Dim emailList As String = ""
        Dim dt_rpt_src_temp As DataTable = New DataTable
        Dim dt_pos_src_temp As DataTable = New DataTable
        Dim dt_stkMst_src As DataTable = clsRpt.getStockMaster()
        Dim dt_ledgerBal_src_temp As DataTable = New DataTable
        Dim cntEmail As Integer = 0

        'for test
        'date_from = date_from.AddDays(-7)
        'date_from = date_from.AddMonths(2)
        'date_from = date_from.AddYears(-1)

        'date_to = date_to.AddDays(-7)
        'date_to = date_to.AddMonths(2)
        'date_to = date_to.AddYears(-1)
        'end for test

        strSQL = "select To_email_address, from_clt_code, to_clt_code, run_code, alertDate from CIES_Alert_Master"
        toDoList = GFncRtnDS(GSCnSqlConn, strSQL, 0).Tables(0)


        For i As Integer = 0 To toDoList.Rows.Count - 1
            clientCode = clsRpt.getClientCode(toDoList.Rows(i).Item("from_clt_code"), toDoList.Rows(i).Item("to_clt_code"), toDoList.Rows(i).Item("run_code"))
            Dim clientCodeList As String = ""

            For j As Integer = 0 To clientCode.Rows.Count - 1
                clientCodeList += "'" & clientCode.Rows(j).Item("CLT_CODE") & "'"
                If (j < clientCode.Rows.Count - 1) Then
                    clientCodeList += ", "
                End If
            Next

            dt_rpt_src_temp = clsRpt.genRptDt_Range(clientCodeList)
            dt_pos_src_temp = clsRpt.getPosition_Range(clientCodeList)
            dt_ledgerBal_src_temp = clsRpt.getLedgerBalance_Range(clientCodeList)

            emailList = toDoList.Rows(i).Item("To_email_address").ToString
            For j As Integer = 0 To clientCode.Rows.Count - 1

                Dim alertDateArr() As String
                alertDateArr = toDoList.Rows(i).Item("alertDate").ToString.Split(",")

                Dim ledgerBal As String = getLedgerBal(dt_ledgerBal_src_temp.Select("CLT_CODE='" & clientCode.Rows(j).Item("CLT_CODE") & "'"))
                Dim dt_rpt_src As DataTable = getReportDt(dt_rpt_src_temp.Clone, dt_rpt_src_temp.Select("client_code='" & clientCode.Rows(j).Item("CLT_CODE") & "'"))
                Dim dt_pos_src As DataTable = getPositionDt(dt_pos_src_temp.Clone, dt_pos_src_temp.Select("CLT_CODE='" & clientCode.Rows(j).Item("CLT_CODE") & "'"))

                handleExportSave(clientCode.Rows(j).Item("CLT_CODE"), GDteTradeDate.AddDays(-14), GDteTradeDate, "", result, dt_rpt_src, dt_pos_src, dt_stkMst_src, ledgerBal)
                If (checkDeficits(result) = True) Then
                    For k As Integer = 0 To alertDateArr.Length - 1

                        Dim startPos As Integer = getStartPos(result)
                        Dim endPos As Integer = getEndPos(result)
                        Dim midPos As Integer = getMidPos(result, startPos, endPos)

                        If midPos = startPos Then
                            midPos += 2
                        End If

                        date_from = CDate(result.GetSheet("My Sheet").GetRow(midPos).GetCell(0).ToString())
                        date_to = date_from.AddDays(CInt(alertDateArr(k)))
                        'Dim dateToCheck = date_from.AddDays(CInt(alertDateArr(k)))

                        ledgerBal = getLedgerBal(dt_ledgerBal_src_temp.Select("CLT_CODE='" & clientCode.Rows(j).Item("CLT_CODE") & "'"))
                        dt_rpt_src = getReportDt(dt_rpt_src_temp.Clone, dt_rpt_src_temp.Select("client_code='" & clientCode.Rows(j).Item("CLT_CODE") & "'"))
                        dt_pos_src = getPositionDt(dt_pos_src_temp.Clone, dt_pos_src_temp.Select("CLT_CODE='" & clientCode.Rows(j).Item("CLT_CODE") & "'"))

                        handleExportSave(clientCode.Rows(j).Item("CLT_CODE"), date_from, date_to, "", result, dt_rpt_src, dt_pos_src, dt_stkMst_src, ledgerBal)
                        If (checkDeficits(result) = True AndAlso checkDateMatch(date_to) = True) Then
                            'sth to do for send email)

                            alertContent += setAlertContent(result, date_from, date_to, clientCode.Rows(j).Item("CLT_CODE"), clsRpt.getClientName(clientCode.Rows(j).Item("CLT_CODE")))

                            'alertContent += "Account No.: " & clientCode.Rows(j).Item("CLT_CODE")
                            'alertContent += setAlertContent(result, date_from, date_to)

                            'For k As Integer = 0 To 20
                            '    alertContent += alertContent
                            'Next

                            'send email one by one
                            'mySendEmail(GStrSender, emailList, "CIES Alert - " & Format(Now(), "dd/MMM/yyyy"), alertContent, GStrEIP)
                            'mySendEmail(GStrSender, emailList, "CIES Alert (" & clientCode.Rows(j).Item("CLT_CODE") & ") - " & Format(Now(), "dd/MMM/yyyy"), alertContent, "128.127.2.4")
                            'mySendEmail(GStrSender, "kingli@emperorgroup.com", "CIES Alert (" & clientCode.Rows(j).Item("CLT_CODE") & ") - T+" & alertDateArr(k) & " - " & Format(Now(), "dd/MMM/yyyy"), alertContent, "128.127.2.4")
                            mySendEmail(GStrSender, emailList, "CIES Alert (" & clientCode.Rows(j).Item("CLT_CODE") & ") - T+" & alertDateArr(k) & " - " & Format(Now(), "dd/MMM/yyyy"), alertContent, GStrEIP)
                            'mySendEmail(GStrSender, emailList, "CIES Alert (" & clientCode.Rows(j).Item("CLT_CODE") & ") - T+" & alertDateArr(k) & " - " & Format(Now(), "dd/MMM/yyyy"), alertContent, "128.127.2.4")
                            alertContent = ""
                            cntEmail += 1
                        End If
                        'send one email contain all info
                        'If j = clientCode.Rows.Count - 1 AndAlso alertContent <> "" Then
                        '    mySendEmail(GStrSender, emailList, "CIES Alert - " & Format(Now(), "dd/MMM/yyyy"), alertContent, GStrEIP)
                        '    'mySendEmail(GStrSender, emailList, "CIES Alert - " & Format(Now(), "dd/MMM/yyyy"), alertContent, "128.127.2.4")
                        '    alertContent = ""
                        'End If
                    Next

                End If
            Next
        Next

        If cntEmail = 1 Then
            GSubShowInfo(cntEmail & " email has been successfully sent.")
        ElseIf cntEmail > 1 Then
            GSubShowInfo(cntEmail & " emails have been successfully sent.")
        Else
            GSubShowInfo("No email have been sent.")
        End If

    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click
        If isInputValid() Then
            Application.DoEvents()
            lsubEnableProcess(True)
            lsubEnableForm(False)

            handleSendAlert()

            lsubEnableProcess(False)
            lsubEnableForm(True)
        End If
    End Sub
End Class
