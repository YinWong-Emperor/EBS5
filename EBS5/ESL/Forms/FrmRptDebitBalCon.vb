'Imports Excel = Microsoft.Office.Interop.Excel
Imports CrystalDecisions.Shared
Imports System.IO

Public Class FrmRptDebitBalCon
    Dim loadFlag As Boolean = True
    Dim cls As New ClsRptDebitBalCon
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim FileName As String = ""

    Private Sub FrmRptMarginCall_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmRptMarginCall_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ldtsRunner As DataSet
        Dim ldtwRunner As DataRow
        loadFlag = True
        ldtsRunner = cls.lFncGetRunner()
        Me.CboTo.Items.Add("")
        Me.CboFrm.Items.Add("")
        For Each ldtwRunner In ldtsRunner.Tables(0).Rows
            Me.CboFrm.Items.Add(ldtwRunner("run_code"))
            Me.CboTo.Items.Add(ldtwRunner("run_code"))
        Next
        lsubEnableForm(True)
        lsubShowProcessing(False)
        Me.RBPreview.Checked = True
        Me.CBExport.Checked = False
        Me.abMC_Amt.Text = Format(1000000.0, "###,###,###.##")
        Me.abDrBal.Text = Format(1000000.0, "###,###,###.##")
        FileName = "DebitBalConcentration." & Format(GDteTradeDate, "yyyyMMdd")
        Me.txtPath.Text = GStrExptDir & FileName & ".csv"
        Me.CBExportXLS.Checked = False
        Me.txtPathXLS.Text = GStrExptDir & FileName & ".xls"
        Me.txtPath.Enabled = False
        Me.txtPathXLS.Enabled = False
        loadFlag = False
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        Me.btnCancel.Visible = bEnable
        Me.btnSave.Visible = bEnable
        Me.RBPreview.Enabled = bEnable
        Me.RBPrint.Enabled = bEnable
        Me.CboFrm.Enabled = bEnable
        Me.CboTo.Enabled = bEnable
        Me.CBExport.Enabled = bEnable
        Me.CBExportXLS.Enabled = bEnable

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim lstrType As String = ""
        Dim lstrTitle As String = ""
        Dim lstrSQL As String = ""
        Dim lstrSort As String = ""
        Dim MarginCAmt As String = "1=1"

        If Me.rbMargin.Checked Then
            lstrSQL += " and CLT_type='M' "
            lstrTitle += "  (Sort by Margin Clients) "
        ElseIf Me.rbCash.Checked Then
            lstrSQL += " and CLT_type='C' "
            lstrTitle += "  (Sort by Cash Clients) "
        Else
            lstrSQL += " and (CLT_type='M' or CLT_type ='C') "
            lstrTitle += "  (Sort by Margin and Cash Clients) "
        End If

        If Me.CboFrm.Text.Trim <> "" Then
            lstrSQL += " and mst.run_code >= '" & Me.CboFrm.Text.Trim.Trim & "' "
        End If
        If Me.CboTo.Text.Trim <> "" Then
            lstrSQL += " and mst.run_code <= '" & Me.CboTo.Text.Trim & "' "
        End If
        If Me.CboFrm.Text.Trim <> "" Or Me.CboTo.Text.Trim <> "" Then
            lstrTitle += " " & Me.CboFrm.Text.Trim & " To " & Me.CboTo.Text.Trim & " "
        End If
        If Me.CBDrBal.Checked Or Me.CBMC_Amt.Checked Then
            MarginCAmt += " and (1<>1 "
            If Me.CBDrBal.Checked Then
                MarginCAmt += " or mc_dr_bal >= " & Replace(Me.abDrBal.Text, ",", "") & " "
                lstrTitle += "  (Debit Balance >= HK$" & Me.abDrBal.Text & ") "
            End If
            If Me.CBMC_Amt.Checked Then
                MarginCAmt += " or Margin_Call_Amount>=" & Replace(Me.abMC_Amt.Text, ",", "") & " "
                lstrTitle += "  (Margin Call Amount >= HK$" & Me.abMC_Amt.Text & ") "
            End If
            MarginCAmt += " ) "
        End If
        If Me.RBMarginCall.Checked Then
            lstrSort = " margin_call_amount desc "
        ElseIf Me.RBDebitBal.Checked Then
            lstrSort = "mc_dr_bal desc "
        Else
            lstrSort = " run_name "
        End If
        If Me.CBExport.Checked Or Me.CBExportXLS.Checked Then
            If GSubShowYNConfirm(GFncGetSysMsg(27), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            lsubShowProcessing(True)
            lsubEnableForm(False)
            Application.DoEvents()
            If Me.CBExport.Checked Then
                Me.lsubExport(lstrSQL, lstrSort, MarginCAmt, lstrTitle)
            End If
            If Me.CBExportXLS.Checked Then
                Me.lSubToExcel(lstrSQL, lstrSort, MarginCAmt)
            End If
            lsubShowProcessing(False)
            lsubEnableForm(True)
            GSubShowInfo(GFncGetSysMsg(28))
            Return
        End If
        If Me.RBPrint.Checked = True Then
            'printDlg.AllowSomePages = True
            If PrintDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDlg.PrinterSettings.PrinterName
                shtCopies = PrintDlg.PrinterSettings.Copies
                If PrintDlg.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDlg.PrinterSettings.FromPage
                    intToPage = PrintDlg.PrinterSettings.ToPage
                End If
            Else
                Exit Sub
            End If
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lsubShowProcessing(True)
        lsubEnableForm(False)
        Application.DoEvents()

        rpt = cls.lFncPrintMarginCall(lstrSQL, lstrSort, lstrTitle, MarginCAmt)

        If Me.RBPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf Me.RBPrint.Checked = True Then
            If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
                GSubShowInfo(GFncGetSysMsg(104))
            End If
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
        lsubEnableForm(True)

    End Sub
    Private Sub lsubExport(ByVal strQuery As String, ByVal strSort As String, ByVal MC As String, ByVal lstrTitle As String)
        Dim strFiles() As String
        Dim ldtsDetailData As DataTable
        Dim lsWriter As StreamWriter
        Dim lstrColValue As String

        Dim total_call_amount As Double = 0
        Dim total_dr_bal As Double = 0
        Dim total_cr_limit As Double = 0
        Dim total_mkt_val As Double = 0
        Dim total_margin_val As Double = 0
        Dim total_top1_mkt_val As Double = 0
        Dim total_top2_mkt_val As Double = 0
        Dim total_top3_mkt_val As Double = 0

        Try

            strFiles = System.IO.Directory.GetFiles(GStrExptDir, FileName & ".csv")
            For Each strFile As String In strFiles
                Application.DoEvents()
                System.IO.File.Delete(strFile)
            Next

            lsWriter = New StreamWriter(Me.txtPath.Text)


            lstrColValue = "EMPEROR SECURITIES LIMITED,,,,,,,,,,,,,,,,Transaction Date : " & GDteTradeDate
            lsWriter.WriteLine(lstrColValue)
            lstrColValue = "Debit Balance Concentration Report " & Replace(lstrTitle, ",", "")
            lsWriter.WriteLine(lstrColValue)

            lstrColValue = " Client, Client_Name, AE, AE_Nanme, os_day,Risk_Factor, mc_act_ratio, margin_ratio, margin_call_amount, " & _
                           " dr_bal, cr_limit, mkt_val, margin_value, top1_code, top1_mkt_val, top1_qty, top2_code, top2_mkt_val, top2_qty, " & _
                           " top3_code, top3_mkt_val, top3_qty "
            lsWriter.WriteLine(lstrColValue)
            lsWriter.Flush()
            ldtsDetailData = cls.lFncPrepareMC(strQuery, strSort, MC)
            Dim ldtaDD As DataRow() = ldtsDetailData.Select("1=1", strSort)
            For lintCnt As Integer = 0 To ldtaDD.Length - 1
                lstrColValue = "=""" & GFncNoNullString(ldtaDD(lintCnt).Item("clt_code")) & """" & ","
                lstrColValue += "=""" & Replace(ldtaDD(lintCnt).Item("clt_name"), ",", ";") & """" & ","
                lstrColValue += "=""" & ldtaDD(lintCnt).Item("run_code") & """" & ","
                lstrColValue += "=""" & Replace(GFncNoNullString(ldtaDD(lintCnt).Item("run_name")), ",", ";") & """" & ","
                lstrColValue += IIf(GFncNoNullValue(ldtaDD(lintCnt).Item("liq_day")) > 14, ">14", GFncNoNullValue(ldtaDD(lintCnt).Item("liq_day"))) & ","
                lstrColValue += ldtaDD(lintCnt).Item("Risk") & ","
                lstrColValue += ldtaDD(lintCnt).Item("mc_act_ratio") & ","
                lstrColValue += ldtaDD(lintCnt).Item("margin_ratio") & ","
                lstrColValue += ldtaDD(lintCnt).Item("margin_call_amount") & ","
                Try
                    total_call_amount += CDbl(ldtaDD(lintCnt).Item("margin_call_amount"))
                Catch ex As Exception
                End Try
                lstrColValue += ldtaDD(lintCnt).Item("mc_dr_bal") & ","
                Try
                    total_dr_bal += CDbl(ldtaDD(lintCnt).Item("mc_dr_bal"))
                Catch ex As Exception
                End Try
                lstrColValue += ldtaDD(lintCnt).Item("cr_limit") & ","
                Try
                    total_cr_limit += CDbl(ldtaDD(lintCnt).Item("cr_limit"))
                Catch ex As Exception
                End Try
                lstrColValue += ldtaDD(lintCnt).Item("mkt_value") & ","
                Try
                    total_mkt_val += CDbl(ldtaDD(lintCnt).Item("mkt_value"))
                Catch ex As Exception
                End Try
                lstrColValue += ldtaDD(lintCnt).Item("margin_value") & ","
                Try
                    total_margin_val += CDbl(ldtaDD(lintCnt).Item("margin_value"))
                Catch ex As Exception
                End Try
                lstrColValue += "=""" & GFncNoNullString(ldtaDD(lintCnt).Item("top1_stock_code")) & """" & ","
                lstrColValue += GFncNoNullValue(ldtaDD(lintCnt).Item("top1_market_value")) & ","
                lstrColValue += GFncNoNullValue(ldtaDD(lintCnt).Item("top1_stock_qty")) & ","
                Try
                    total_top1_mkt_val += CDbl(ldtaDD(lintCnt).Item("top1_market_value"))
                Catch ex As Exception
                End Try
                lstrColValue += "=""" & GFncNoNullString(ldtaDD(lintCnt).Item("top2_stock_code")) & """" & ","
                lstrColValue += GFncNoNullValue(ldtaDD(lintCnt).Item("top2_market_value")) & ","
                lstrColValue += GFncNoNullValue(ldtaDD(lintCnt).Item("top2_stock_qty")) & ","
                Try
                    total_top2_mkt_val += CDbl(ldtaDD(lintCnt).Item("top2_market_value"))
                Catch ex As Exception
                End Try
                lstrColValue += "=""" & GFncNoNullString(ldtaDD(lintCnt).Item("top3_stock_code")) & """" & ","
                lstrColValue += GFncNoNullValue(ldtaDD(lintCnt).Item("top3_market_value")) & ","
                lstrColValue += GFncNoNullValue(ldtaDD(lintCnt).Item("top3_stock_qty")) & ""
                Try
                    total_top3_mkt_val += CDbl(ldtaDD(lintCnt).Item("top3_market_value"))
                Catch ex As Exception
                End Try
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()
            Next

            lstrColValue = ",,,,,,,," & total_call_amount.ToString & "," & total_dr_bal.ToString & "," & total_cr_limit.ToString & _
                           "," & total_mkt_val.ToString & "," & total_margin_val.ToString & ",," & total_top1_mkt_val.ToString & _
                           ",,," & total_top2_mkt_val.ToString & ",,," & total_top3_mkt_val.ToString
            lsWriter.WriteLine(lstrColValue)

            lsWriter.Close()
        Catch ex As Exception
            GSubWriteELog(ex.Message)
            GSubShowInfo(GFncGetSysMsg(29))
        End Try
        'End If
    End Sub

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try
    End Sub


    Private Sub lSubToExcel(ByVal strQuery As String, ByVal strSort As String, ByVal MC As String)
        Dim strFiles() As String
        Dim xlApp As Object
        Dim xlWorkBook As Object
        Dim xlWorkSheet As Object
        Dim range As Object
        Dim MCTbl As DataTable

         MCTbl = cls.lFncPrepareMC(strQuery, strSort, MC)

        xlApp = CreateObject("Excel.Application")

        xlWorkBook = xlApp.Workbooks.Open(Application.StartupPath & "\MC_Template.xls")

        xlWorkSheet = xlWorkBook.Worksheets("Margin Call Record")

        Try
            strFiles = System.IO.Directory.GetFiles(GStrExptDir, FileName & ".xls")
            For Each strFile As String In strFiles

                System.IO.File.Delete(strFile)
            Next

            range = xlWorkSheet.UsedRange
            For row As Integer = 0 To MCTbl.Rows.Count - 1

                xlWorkSheet.Cells(row + 3, 1) = MCTbl.Rows(row).Item("RUN_Code")
                xlWorkSheet.Cells(row + 3, 2) = GFncNoNullString(MCTbl.Rows(row).Item("RUN_Name"))
                xlWorkSheet.Cells(row + 3, 3) = Format(Val(MCTbl.Rows(row).Item("CLT_Code")), "00000000")
                xlWorkSheet.Cells(row + 3, 4) = CDbl(MCTbl.Rows(row).Item("mc_act_ratio"))
                xlWorkSheet.Cells(row + 3, 5) = CDbl(MCTbl.Rows(row).Item("margin_ratio"))
                xlWorkSheet.Cells(row + 3, 6) = MCTbl.Rows(row).Item("Due_Undue")
                xlWorkSheet.Cells(row + 3, 7) = MCTbl.Rows(row).Item("Risk")
                xlWorkSheet.Cells(row + 3, 8) = MCTbl.Rows(row).Item("Margin_Call_Amount")
                xlWorkSheet.Cells(row + 3, 9) = MCTbl.Rows(row).Item("MC_DUE")
                xlWorkSheet.Cells(row + 3, 10) = MCTbl.Rows(row).Item("MC_T2")
                xlWorkSheet.Cells(row + 3, 11) = IIf(GFncNoNullValue(MCTbl.Rows(row).Item("liq_day")) > 14, ">14", GFncNoNullValue(MCTbl.Rows(row).Item("liq_day")))
                xlWorkSheet.Cells(row + 3, 12) = CDbl(MCTbl.Rows(row).Item("cr_limit")) / 1000
                xlWorkSheet.Cells(row + 3, 13) = CDbl(MCTbl.Rows(row).Item("mc_dr_bal")) / 1000
                xlWorkSheet.Cells(row + 3, 14) = CDbl(MCTbl.Rows(row).Item("mkt_value") / 1000)
                xlWorkSheet.Cells(row + 3, 15) = CDbl(MCTbl.Rows(row).Item("margin_value") / 1000)
                xlWorkSheet.Cells(row + 3, 16) = MCTbl.Rows(row).Item("Top1_stock_Code")
                xlWorkSheet.Cells(row + 3, 17) = CDbl(MCTbl.Rows(row).Item("top1_market_value")) / 1000
                xlWorkSheet.Cells(row + 3, 18) = CDbl(MCTbl.Rows(row).Item("top1_stock_qty")) / 1000
                xlWorkSheet.Cells(row + 3, 19) = MCTbl.Rows(row).Item("Top2_stock_Code")
                xlWorkSheet.Cells(row + 3, 20) = CDbl(MCTbl.Rows(row).Item("top2_market_value")) / 1000
                xlWorkSheet.Cells(row + 3, 21) = CDbl(MCTbl.Rows(row).Item("top2_stock_qty")) / 1000
                xlWorkSheet.Cells(row + 3, 22) = MCTbl.Rows(row).Item("Top3_stock_Code")
                xlWorkSheet.Cells(row + 3, 23) = CDbl(MCTbl.Rows(row).Item("top3_market_value")) / 1000
                xlWorkSheet.Cells(row + 3, 24) = CDbl(MCTbl.Rows(row).Item("top3_stock_qty")) / 1000
                If MCTbl.Rows(row).Item("Due_Undue") = "Undue" Then
                    xlWorkSheet.Cells(row + 3, 26) = "(t+1)"
                End If
                'xlWorkSheet.cells(row + 3, 7) = lFncRickFactor(CDbl(MCTbl.Rows(row).Item("mc_act_ratio")), xlWorkSheet.Cells(row + 3, 11).ToString.Trim, MCTbl.Rows(row).Item("dr_bal"))
                Application.DoEvents()
            Next

            xlWorkBook.SaveAs(Me.txtPathXLS.Text)
            xlWorkBook.Close()
            xlApp.Quit()

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            GC.Collect()
        Catch ex As Exception
            xlWorkBook.close()
            xlApp.Quit()
            GC.Collect()

            'GSubWriteELog(ex.Message)
            GSubShowInfo(GFncGetSysMsg(89))
        End Try

    End Sub

    Private Sub CBDrBal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBDrBal.CheckedChanged
        If (Me.CBDrBal.Checked) Then
            Me.abDrBal.Enabled = True
        Else
            Me.abDrBal.Enabled = False
        End If
    End Sub

    Private Sub CBMC_Amt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBMC_Amt.CheckedChanged
        If (Me.CBMC_Amt.Checked) Then
            Me.abMC_Amt.Enabled = True
        Else
            Me.abMC_Amt.Enabled = False
        End If
    End Sub
End Class
