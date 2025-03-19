Imports CrystalDecisions.Shared
Imports System.IO

Public Class FrmRptMrgCallUS
    Dim loadFlag As Boolean = True
    Dim cls As New ClsMrgCallUS
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
        Me.CB1000.Checked = True
        Me.CBExport.Checked = False
        FileName = "NewMarginCall" & Format(GDteTradeDate, "yyyyMMdd")
        Me.txtPath.Text = GStrExptDir & FileName & ".csv"
        Me.CBExportXLS.Checked = False
        Me.txtPathXLS.Text = GStrExptDir & FileName & ".xls"
        Me.txtPath.Enabled = False
        Me.txtPathXLS.Enabled = False
        loadFlag = False
        cls.lFncCreateList()
        Me.cboAndOr.Items.Add("AND")
        Me.cboAndOr.Items.Add("OR")
        Me.nbAR.Text = cls.getAR()
        Me.nbMR.Text = cls.getMR()
        Me.cboAndOr.SelectedIndex = Me.cboAndOr.FindString(cls.getAndOr)

        If GFncGetTDateUS() <> GFncGetTDate() Then
            MsgBox("US data (" & Format(GFncGetTDate, "dd/MM/yyyy") & ") not yet imported.")
        End If
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
        cls.lFncCleanTempTable()
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

        If Me.CboFrm.Text.Trim <> "" Then
            lstrSQL += " and mst.run_code >= '" & Me.CboFrm.Text.Trim.Trim & "' "
        End If
        If Me.CboTo.Text.Trim <> "" Then
            lstrSQL += " and mst.run_code <= '" & Me.CboTo.Text.Trim & "' "
        End If
        If Me.CboFrm.Text.Trim <> "" Or Me.CboTo.Text.Trim <> "" Then
            lstrTitle += " " & Me.CboFrm.Text.Trim & " To " & Me.CboTo.Text.Trim & " "
        End If
        If Me.CB1000.Checked Then
            lstrSQL += " and mc_total >= 1000 "
            lstrTitle += "  (Exclude Total Margin Call < 1000) "
        End If
        If Me.CBSellOnly.Checked Then
            'lstrSQL += " and (" & _
            '                        "(CLT_Type='M' and MC_ACT_RATIO>0.5 and margin_ratio>1.3) " & _
            '                        " or " & _
            '                        " (CLT_Type='C' and mc_due>0) " & _
            '                        " or " & _
            '                        " (CLT_Type='C' and mc_due <=0 AND MC_T2 >0  and MC_ACT_RATIO>1) " & _
            '                        " ) "
            'lstrSQL += " and (" & _
            '            " (CLT_Type='C' and mc_due>0) " & _
            '            " or (CLT_Type='C' and mc_due<=0 AND MC_T2>0  and MC_ACT_RATIO>1) " & _
            '            " or (CLT_Type='M' and mc_dr_bal>cr_limit) " & _
            '            " or (CLT_Type='M' and mc_dr_bal<=cr_limit and (mc_act_ratio>" & _
            '                    Me.nbAR.Text & " " & Me.cboAndOr.Text & " " & "margin_ratio>" & Me.nbMR.Text & ")) " & _
            '            " ) "
            lstrSQL += " and (" & _
                        " (CLT_Type='C' and mc_due>0) " & _
                        " or (CLT_Type='C' and mc_due<=0 AND MC_T2>0  and MC_ACT_RATIO>1) " & _
                        " or (CLT_Type='M' and mc_dr_bal>cr_limit) " & _
                        " or (CLT_Type='M' and mc_dr_bal<=cr_limit and (margin_ratio>" & Me.nbMR.Text & ")) " & _
                        " ) "
            lstrTitle += "  ( Sell Only ) "
        End If

        'If Me.CBSellOnly.Checked = False Then
        '    lstrSQL += " and margin_ratio >= 1.0 "
        'End If

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
                Me.lsubExport(lstrSQL, lstrSort, MarginCAmt)
            End If
            If Me.CBExportXLS.Checked Then
                Me.lSubToExcel(lstrSQL, lstrSort, MarginCAmt)
            End If
            lsubShowProcessing(False)
            lsubEnableForm(True)
            GSubShowInfo(GFncGetSysMsg(28))
            'save criteria
            If Me.CBSellOnly.Checked Then
                If (cls.setCriteria(Me.nbAR.Text, Me.cboAndOr.Text, Me.nbMR.Text) = False) Then
                    GSubShowInfo(GFncGetSysMsg(9))
                End If
            End If
            Return
        End If
        If Me.RBPrint.Checked = True Then
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
        'save criteria
        If Me.CBSellOnly.Checked Then
            If (cls.setCriteria(Me.nbAR.Text, Me.cboAndOr.Text, Me.nbMR.Text) = False) Then
                GSubShowInfo(GFncGetSysMsg(9))
            End If
        End If
    End Sub

    Private Sub lsubExport(ByVal strQuery As String, ByVal strSort As String, ByVal MC As String)
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


            lstrColValue = "EMPEROR SECURITIES LIMITED,,,,,,,,,,,,,Transaction Date : " & GDteTradeDate
            lsWriter.WriteLine(lstrColValue)
            lstrColValue = "Debit balance clients with total margin call exceed HK$1000.-"
            lsWriter.WriteLine(lstrColValue)

            lstrColValue = " Client, Client_Name, AE, AE_Name, os_day,Risk_Factor, mc_act_ratio, margin_ratio, margin_call_amount, " & _
                           " dr_bal, cr_limit, mkt_val, margin_value, top1_code, Top1_mkt_val, top2_code, Top2_mkt_val, " & _
                           " top3_code, Top3_mkt_val "
            lsWriter.WriteLine(lstrColValue)
            lsWriter.Flush()
            ldtsDetailData = cls.lFncPrepareMC(strQuery, strSort, MC)
            Dim ldtaDD As DataRow() = ldtsDetailData.Select("1=1", strSort)
            For lintCnt As Integer = 0 To ldtaDD.Length - 1
                lstrColValue = "=""" & ldtaDD(lintCnt).Item("clt_code") & """" & ","
                lstrColValue += "=""" & Replace(ldtaDD(lintCnt).Item("clt_name"), ",", ";") & """" & ","
                lstrColValue += "=""" & ldtaDD(lintCnt).Item("run_code") & """" & ","
                lstrColValue += "=""" & Replace(GFncNoNullString(ldtaDD(lintCnt).Item("run_name")), ",", ";") & """" & ","
                'lstrColValue += IIf(ldtaDD(lintCnt).Item("liq_day") > 14, ">14", ldtaDD(lintCnt).Item("liq_day")) & ","
                'lstrColValue += IIf(ldtaDD(lintCnt).Item("liq_day") > 90, ">90", ldtaDD(lintCnt).Item("liq_day")) & ","
                lstrColValue += ldtaDD(lintCnt).Item("liq_day") & ","
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
                Try
                    total_top1_mkt_val += CDbl(ldtaDD(lintCnt).Item("top1_market_value"))
                Catch ex As Exception
                End Try
                lstrColValue += "=""" & GFncNoNullString(ldtaDD(lintCnt).Item("top2_stock_code")) & """" & ","
                lstrColValue += GFncNoNullValue(ldtaDD(lintCnt).Item("top2_market_value")) & ","
                Try
                    total_top2_mkt_val += CDbl(ldtaDD(lintCnt).Item("top2_market_value"))
                Catch ex As Exception
                End Try
                lstrColValue += "=""" & GFncNoNullString(ldtaDD(lintCnt).Item("top3_stock_code")) & """" & ","
                lstrColValue += GFncNoNullValue(ldtaDD(lintCnt).Item("top3_market_value")) & ""
                Try
                    total_top3_mkt_val += CDbl(ldtaDD(lintCnt).Item("top3_market_value"))
                Catch ex As Exception
                End Try
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()
            Next

            lstrColValue = ",,,,,,,," & total_call_amount.ToString & "," & total_dr_bal.ToString & "," & total_cr_limit.ToString & _
                           "," & total_mkt_val.ToString & "," & total_margin_val.ToString & ",," & total_top1_mkt_val.ToString & _
                           ",," & total_top2_mkt_val.ToString & ",," & total_top3_mkt_val.ToString
            lsWriter.WriteLine(lstrColValue)

            lsWriter.Close()
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            GSubShowInfo(GFncGetSysMsg(29))
        End Try
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
                Application.DoEvents()
                System.IO.File.Delete(strFile)
            Next

            range = xlWorkSheet.UsedRange
            For row As Integer = 0 To MCTbl.Rows.Count - 1
                Application.DoEvents()
                xlWorkSheet.Cells(row + 3, 1) = MCTbl.Rows(row).Item("RUN_Code")
                xlWorkSheet.Cells(row + 3, 2) = MCTbl.Rows(row).Item("RUN_Name")
                xlWorkSheet.Cells(row + 3, 3) = Format(Val(MCTbl.Rows(row).Item("CLT_Code")), "00000000")
                xlWorkSheet.Cells(row + 3, 4) = CDbl(MCTbl.Rows(row).Item("mc_act_ratio"))
                xlWorkSheet.Cells(row + 3, 5) = CDbl(MCTbl.Rows(row).Item("margin_ratio"))
                xlWorkSheet.Cells(row + 3, 6) = MCTbl.Rows(row).Item("Due_Undue")
                xlWorkSheet.Cells(row + 3, 7) = MCTbl.Rows(row).Item("Risk")
                xlWorkSheet.Cells(row + 3, 8) = MCTbl.Rows(row).Item("Margin_Call_Amount")
                xlWorkSheet.Cells(row + 3, 9) = MCTbl.Rows(row).Item("MC_DUE")
                xlWorkSheet.Cells(row + 3, 10) = MCTbl.Rows(row).Item("MC_T2")
                'xlWorkSheet.Cells(row + 3, 11) = IIf(MCTbl.Rows(row).Item("liq_day") > 14, ">14", MCTbl.Rows(row).Item("liq_day"))
                xlWorkSheet.Cells(row + 3, 11) = IIf(MCTbl.Rows(row).Item("liq_day") > 90, ">90", MCTbl.Rows(row).Item("liq_day"))
                xlWorkSheet.Cells(row + 3, 12) = CDbl(MCTbl.Rows(row).Item("cr_limit")) / 1000
                xlWorkSheet.Cells(row + 3, 13) = CDbl(MCTbl.Rows(row).Item("mc_dr_bal")) / 1000
                xlWorkSheet.Cells(row + 3, 14) = CDbl(MCTbl.Rows(row).Item("mkt_value") / 1000)
                xlWorkSheet.Cells(row + 3, 15) = CDbl(MCTbl.Rows(row).Item("margin_value") / 1000)
                xlWorkSheet.Cells(row + 3, 16) = MCTbl.Rows(row).Item("Top1_stock_Code")
                xlWorkSheet.Cells(row + 3, 17) = CDbl(MCTbl.Rows(row).Item("top1_market_value")) / 1000
                xlWorkSheet.Cells(row + 3, 18) = MCTbl.Rows(row).Item("Top2_stock_Code")
                xlWorkSheet.Cells(row + 3, 19) = CDbl(MCTbl.Rows(row).Item("top2_market_value")) / 1000
                xlWorkSheet.Cells(row + 3, 20) = MCTbl.Rows(row).Item("Top3_stock_Code")
                xlWorkSheet.Cells(row + 3, 21) = CDbl(MCTbl.Rows(row).Item("top3_market_value")) / 1000
                If MCTbl.Rows(row).Item("Due_Undue") = "Undue" Then
                    xlWorkSheet.Cells(row + 3, 23) = "(t+1)"
                End If
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

            GSubShowInfo(GFncGetSysMsg(89))
        End Try

    End Sub

    Private Sub CBSellOnly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CBSellOnly.CheckedChanged
        If loadFlag = False Then
            If Me.txtPath.Text.Length > 0 Then
                If Me.CBSellOnly.Checked Then
                    Me.txtPath.Text = GStrExptDir & "NewMarginCall(Sell_Only)" & Format(GDteTradeDate, "yyyyMMdd") & ".csv"
                    FileName = "NewMarginCall(Sell_Only)" & Format(GDteTradeDate, "yyyyMMdd")
                Else
                    Me.txtPath.Text = GStrExptDir & "NewMarginCall." & Format(GDteTradeDate, "yyyyMMdd") & ".csv"
                    FileName = "NewMarginCall" & Format(GDteTradeDate, "yyyyMMdd")
                End If
            End If
            If Me.txtPathXLS.Text.Length > 0 Then
                If Me.CBSellOnly.Checked Then
                    Me.txtPathXLS.Text = GStrExptDir & "NewMarginCall(Sell_Only)" & Format(GDteTradeDate, "yyyyMMdd") & ".xls"
                    FileName = "NewMarginCall(Sell_Only)" & Format(GDteTradeDate, "yyyyMMdd")
                Else
                    Me.txtPathXLS.Text = GStrExptDir & "NewMarginCall." & Format(GDteTradeDate, "yyyyMMdd") & ".xls"
                    FileName = "NewMarginCall" & Format(GDteTradeDate, "yyyyMMdd")
                End If
            End If
            If Me.CBSellOnly.Checked Then
                Me.nbAR.Enabled = True
                Me.cboAndOr.Enabled = True
                Me.nbMR.Enabled = True
            Else
                Me.nbAR.Enabled = False
                Me.cboAndOr.Enabled = False
                Me.nbMR.Enabled = False
                Me.nbAR.Text = cls.getAR()
                Me.nbMR.Text = cls.getMR()
                Me.cboAndOr.SelectedIndex = Me.cboAndOr.FindString(cls.getAndOr)
            End If
        End If
    End Sub
End Class
