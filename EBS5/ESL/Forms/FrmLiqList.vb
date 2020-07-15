Imports CrystalDecisions.Shared
Imports System.IO

Public Class FrmLiqList

    Dim cls As New ClsLiqList
    Dim ldtsDetail As DataSet
    Dim ldtsTotal As DataSet
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim rad As String

    Dim frm As New FrmRptDisplay

    Private Sub FrmLiqList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ldtsRunner As DataSet = cls.lFncGetRunner()
        Dim ldtwRunner As DataRow

        cls.lFncCreateList(rad)

        Me.RBMargin.Checked = True
        Me.lsubShowProcessing(False)

        Me.CboFrm.Items.Add("")
        Me.CboTo.Items.Add("")
        Me.CBoRunFrom.Items.Add("")
        Me.CboRunTo.Items.Add("")
        For Each ldtwRunner In ldtsRunner.Tables(0).Rows
            Me.CboFrm.Items.Add(ldtwRunner("run_code"))
            Me.CboTo.Items.Add(ldtwRunner("run_code"))
            Me.CBoRunFrom.Items.Add(ldtwRunner("run_code"))
            Me.CboRunTo.Items.Add(ldtwRunner("run_code"))
        Next

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        cls.lFncCleanTempTable(rad)
        Me.Close()
    End Sub

    Private Sub lsubDisplay(ByVal lstrType As String)
        Dim tableNames As String() = New String(1) {"detail", "total"}

        ldtsDetail = cls.lFncSearch(lstrType, tableNames, rad)
        Me.DtgDetail.DataSource = ldtsDetail
        Me.DtgDetail.DataMember = "detail"
        Me.DtgTotal.DataSource = ldtsDetail
        Me.DtgTotal.DataMember = "total"

    End Sub

    Private Sub RBMargin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBMargin.CheckedChanged
        If Me.RBMargin.Checked Then
            Me.lsubDisplay("M")
        End If
    End Sub

    Private Sub RBFinance_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBFinance.CheckedChanged
        If Me.RBFinance.Checked Then
            Me.lsubDisplay("F")
        End If
    End Sub

    Private Sub RBCash_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBCash.CheckedChanged
        If Me.RBCash.Checked Then
            Me.lsubDisplay("C")
        End If
    End Sub

    Private Sub RBAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBAll.CheckedChanged
        If Me.RBAll.Checked Then
            Me.lsubDisplay("")
        End If
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim lstrType As String = ""
        Dim lstrTitle As String = ""
        Dim lstrSQL As String = ""

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

        If Me.CboFrm.Text.Trim <> "" Then
            lstrSQL += " and run_code >= '" & Me.CboFrm.Text.Trim.Trim & "' "
        End If
        If Me.CboTo.Text.Trim <> "" Then
            lstrSQL += " and run_code <= '" & Me.CboTo.Text.Trim & "' "
        End If
        If Me.CboFrm.Text.Trim <> "" Or Me.CboTo.Text.Trim <> "" Then
            lstrTitle += " " & Me.CboFrm.Text.Trim & " To " & Me.CboTo.Text.Trim & " "
        End If

        Dim isEmpty As Boolean = False
        rpt = cls.lFncPrintAccLst( _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Nothing, _
                                  Me.CboFrm.Text.Trim, _
                                  Me.CboTo.Text.Trim, _
                                  "", _
                                  "", _
                                  "", _
                                  Nothing, _
                                  "", _
                                  lstrTitle, _
                                  isEmpty, _
                                  rad)

        If isEmpty Then
            GSubShowWarn("No Record!")
            Windows.Forms.Cursor.Current = Cursors.Default
            lsubShowProcessing(False)
            lsubEnableForm(True)
            Exit Sub
        End If

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

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub


    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        Me.btnCancel.Visible = bEnable
        Me.RBPreview.Enabled = bEnable
        Me.RBPrint.Enabled = bEnable
        Me.CboFrm.Enabled = bEnable
        Me.CboTo.Enabled = bEnable
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedIndex = 1 Then
            Me.AmtCR.Text = "10,000,000"
            Me.AmtDR.Text = "10,000,000"
            Me.AmtMktMore.Text = "10,000,000"
            Me.AmtMktLess.Text = "0"
            Me.AmtDue.Text = "5,000,000"
            Me.AmtUndue.Text = "5,000,000"
            Me.AmtActRatio.Text = "60.00"
            Me.AmtMarRatio.Text = "60.00"
            Me.Amttotal.Text = "5,000,000"
            Me.AmtOverDraft.Text = "5,000,000"
            Me.AmtOSDay.Text = "1"
            Me.AmtOverDraft.Text = "5,000,000"
            Me.AmtFutures.Text = "0"
            Me.RBTypeMargin.Checked = True
            Me.RBTypeCash.Checked = False
            Me.CBcr.Checked = False
            Me.CBMktMore.Checked = False
            Me.CBMKTLess.Checked = False
            Me.CBMarRatio.Checked = False
            Me.CBLimit.Checked = False
            Me.CBDue.Checked = False
            Me.CBFutures.Checked = False
            Me.CBActRatio.Checked = False
            Me.CBClient.Checked = False
            Me.CBOSDay.Checked = False
            Me.CBOverDraft.Checked = False
            Me.CBType.Checked = False
            Me.CBTotal.Checked = False
            Me.CBRunner.Checked = False
            Me.CBUndue.Checked = False
            Me.CBName.Checked = False
        End If
        If Me.TabControl1.SelectedIndex = 2 Then
            Me.RBPreview.Checked = True
            Me.CboFrm.Text = ""
            Me.CboTo.Text = ""
            Me.CboFrm.Focus()
        End If
        If Me.TabControl1.SelectedIndex = 3 Then
            Me.txtClientName.Text = ""
            Me.txtClientCode.Text = ""
            Me.txtClientCode.Focus()
        End If
        If Me.TabControl1.SelectedIndex = 4 Then
            Me.tbExport.Text = "c:\itas\liquidation_list_" & Format(Now(), "yyyyMMddhhmmss") & ".xls"
            Me.BtnExport.Focus()
        End If
        If Me.TabControl1.SelectedIndex = 5 Then
            Me.txtFilter.Text = cls.lFncGetFilterLogic()
            Me.txtFilter.Focus()
        End If
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

    Private Sub BtnExport_Click(sender As Object, e As EventArgs) Handles BtnExport.Click
        Dim strFiles() As String
        Dim strs As String() = Me.tbExport.Text.Split("\")

        Dim strExportDir As String = "c:\itas\"
        Dim strFilename As String = strs(strs.Length - 1).Replace(".xls", ".csv").Trim()
        Dim strExcelname As String = strs(strs.Length - 1).Trim()
        Dim ldtwDetailData As DataRow
        Dim ldtsDetailData As DataSet
        Dim lsWriter As StreamWriter
        Dim lstrColValue As String

        Dim excel As Object
        Dim workbook As Object
        Dim rCnt As Integer = 2

        If GSubShowYNConfirm(GFncGetSysMsg(27) & " To " & strExportDir & strFilename) _
                = Windows.Forms.DialogResult.Yes Then

            Try
                'open file
                strFiles = System.IO.Directory.GetFiles(strExportDir, strExcelname)
                For Each strFile As String In strFiles
                    Application.DoEvents()
                    System.IO.File.Delete(strFile)
                Next
                excel = CreateObject("Excel.Application")
                workbook = excel.Workbooks.Add(True)

                strFiles = System.IO.Directory.GetFiles(strExportDir, strFilename)
                For Each strFile As String In strFiles
                    Application.DoEvents()
                    System.IO.File.Delete(strFile)
                Next

                'column header
                'lsWriter = New StreamWriter(strExportDir & strFilename)
                lsWriter = New StreamWriter(strExportDir & strFilename, False, System.Text.Encoding.GetEncoding(950))
                lstrColValue = " ae, client, dr_bal, mkt_val, mc_act_ratio, " & _
                            " margin_ratio, mc_due, undue, mc_total, os_day, net_trade, cr_limit, client_Name "
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()

                excel.cells(1, 1).Value = "ae"
                excel.cells(1, 2).Value = "client"
                excel.cells(1, 3).Value = "dr_bal"
                excel.cells(1, 4).Value = "mkt_val"
                excel.cells(1, 5).Value = "mc_act_ratio"
                excel.cells(1, 6).Value = "margin_ratio"
                excel.cells(1, 7).Value = "mc_due"
                excel.cells(1, 8).Value = "undue"
                excel.cells(1, 9).Value = "mc_total"
                excel.cells(1, 10).Value = "os_day"
                excel.cells(1, 11).Value = "net_trade"
                excel.cells(1, 12).Value = "cr_limit"
                excel.cells(1, 13).Value = "client_Name "

                'get data from database
                If Me.RBMargin.Checked Then
                    ldtsDetailData = cls.lFncGetDetail("M", rad)
                ElseIf Me.RBCash.Checked Then
                    ldtsDetailData = cls.lFncGetDetail("C", rad)
                ElseIf Me.RBFinance.Checked Then
                    ldtsDetailData = cls.lFncGetDetail("F", rad)
                Else
                    ldtsDetailData = cls.lFncGetDetail("", rad)
                End If
                'write data to file
                For Each ldtwDetailData In ldtsDetailData.Tables(0).Rows
                    lstrColValue = "=""" & ldtwDetailData("run_code") & """" & ","
                    lstrColValue += "=""" & ldtwDetailData("clt_code") & """" & ","
                    lstrColValue += ldtwDetailData("mc_dr_bal") & ","
                    lstrColValue += ldtwDetailData("mkt_value") & ","
                    lstrColValue += ldtwDetailData("mc_act_ratio") & ","
                    lstrColValue += ldtwDetailData("margin_ratio") & ","
                    lstrColValue += ldtwDetailData("mc_due") & ","
                    lstrColValue += ldtwDetailData("mc_t2") & ","
                    lstrColValue += ldtwDetailData("mc_total") & ","
                    lstrColValue += ldtwDetailData("os_day") & ","
                    lstrColValue += ldtwDetailData("net_trade") & ","
                    lstrColValue += ldtwDetailData("cr_limit") & ","
                    lstrColValue += "=""" & Replace(ldtwDetailData("clt_name"), ",", ";") & """"
                    lsWriter.WriteLine(lstrColValue)
                    lsWriter.Flush()

                    excel.cells(rCnt, 1).Value = "'" & ldtwDetailData("run_code")
                    excel.cells(rCnt, 2).Value = "'" & ldtwDetailData("clt_code")
                    excel.cells(rCnt, 3).Value = ldtwDetailData("mc_dr_bal")
                    excel.cells(rCnt, 4).Value = ldtwDetailData("mkt_value")
                    excel.cells(rCnt, 5).Value = ldtwDetailData("mc_act_ratio")
                    excel.cells(rCnt, 6).Value = ldtwDetailData("margin_ratio")
                    excel.cells(rCnt, 7).Value = ldtwDetailData("mc_due")
                    excel.cells(rCnt, 8).Value = ldtwDetailData("mc_t2")
                    excel.cells(rCnt, 9).Value = ldtwDetailData("mc_total")
                    excel.cells(rCnt, 10).Value = ldtwDetailData("os_day")
                    excel.cells(rCnt, 11).Value = ldtwDetailData("net_trade")
                    excel.cells(rCnt, 12).Value = ldtwDetailData("cr_limit")
                    excel.cells(rCnt, 13).Value = "'" & ldtwDetailData("clt_name")
                    rCnt = rCnt + 1
                Next
                lsWriter.Close()

                workbook.SaveAs(strExportDir & strExcelname)
                excel.Workbooks.Close()
                excel.Quit()
                workbook = Nothing
                excel = Nothing
                GC.Collect()

                GSubShowInfo(GFncGetSysMsg(28))
                Me.tbExport.Text = "c:\itas\liquidation_list_" & Format(Now(), "yyyyMMddhhmmss") & ".xls"
            Catch ex As Exception
                GSubWriteErrLog(ex.Message)
                GSubShowInfo(GFncGetSysMsg(29))
            End Try
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Dim lstrQuery As String = ""
        Dim ldtaDetail As DataRow()
        Dim lintCnt As Integer

        If Me.txtClientCode.Text.Trim <> "" And Me.txtClientCode.Text.Trim <> "00000000" Then
            lstrQuery = " clt_code = '" & Me.txtClientCode.Text.Trim & "' "
            If Me.txtClientName.Text.Trim <> "" Then
                lstrQuery += " and clt_name like '%" & Me.txtClientName.Text.Trim & "%' "
            End If
        ElseIf Me.txtClientName.Text.Trim <> "" Then
            lstrQuery += " clt_name like '%" & Me.txtClientName.Text.Trim & "%' "
        End If

        If lstrQuery.Trim = "" Then
            Me.txtClientCode.Focus()
            Return
        End If

        ldtaDetail = ldtsDetail.Tables(0).Select(lstrQuery)
        If ldtaDetail.Length > 0 Then
            Me.TabControl1.SelectTab(0)
            Me.DtgDetail.Focus()
            For lintCnt = 0 To Me.DtgDetail.Rows.Count - 1
                If Me.DtgDetail.Rows(lintCnt).Cells("client").Value = ldtaDetail(0).Item("clt_code") Then
                    Me.DtgDetail.Rows(lintCnt).Cells("client").Selected = True
                    Exit For
                End If
            Next
        Else
            GSubShowInfo(GFncGetSysMsg(86))
            Me.txtClientCode.Focus()
        End If
    End Sub

    Private Sub txtClientCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtClientCode.Validating
        Dim lint As Integer
        lint = Val(Replace(Me.txtClientCode.Text.Trim, " ", ""))
        Me.txtClientCode.Text = Format(lint, "00000000")
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Me.txtFilter.Enabled = True
        Me.btnEdit.Enabled = False
        Me.btnStore.Enabled = True
        Me.btnCancel2.Enabled = True
        Me.btnCancel.Enabled = False
        Me.txtFilter.Focus()
    End Sub

    Private Sub btnStore_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStore.Click
        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncValidateCondition(Me.txtFilter.Text)) Then
                If (cls.lFncSetFilterLogic(Me.txtFilter.Text) = False) Then
                    GSubShowInfo(GFncGetSysMsg(9))
                Else
                    cls.lFncCleanTempTable(rad)
                    cls.lFncCreateList(rad)

                    If Me.RBMargin.Checked Then
                        Me.lsubDisplay("M")
                    ElseIf Me.RBFinance.Checked Then
                        Me.lsubDisplay("F")
                    ElseIf Me.RBCash.Checked Then
                        Me.lsubDisplay("C")
                    ElseIf Me.RBAll.Checked Then
                        Me.lsubDisplay("")
                    End If

                    Me.txtFilter.Enabled = False
                    Me.btnEdit.Enabled = True
                    Me.btnStore.Enabled = False
                    Me.btnCancel2.Enabled = False
                    Me.btnCancel.Enabled = True
                    GSubShowInfo(GFncGetSysMsg(8))
                End If
            Else
                GSubShowInfo(GFncGetSysMsg(88))
            End If
        End If
    End Sub

    Private Sub btnCancel2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel2.Click
        Me.txtFilter.Text = cls.lFncGetFilterLogic()
        Me.txtFilter.Focus()
        Me.txtFilter.Enabled = False
        Me.btnEdit.Enabled = True
        Me.btnStore.Enabled = False
        Me.btnCancel2.Enabled = False
        Me.btnCancel.Enabled = True
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If (Me.txtFilter.Enabled) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnPrc_Click(sender As Object, e As EventArgs) Handles btnPrc.Click
        Dim lstrTitle As String = ""
        Dim lstrCltType As String = ""
        Dim isEmpty As Boolean = False

        If Me.CBcr.Checked Then
            lstrTitle += "   Credit Balance > " + Str(CDec(Me.AmtCR.Text))
        End If
        If Me.CBdr.Checked Then
            lstrTitle += "   Debit Balance > " + Str(CDec(Me.AmtDR.Text))
        End If
        If Me.CBMktMore.Checked Then
            lstrTitle += "  MKt Value > " + Str(CDec(Me.AmtMktMore.Text))
        End If
        If Me.CBMKTLess.Checked Then
            lstrTitle += "  MKt Value < " + Str(CDec(Me.AmtMktLess.Text))
        End If
        If Me.CBActRatio.Checked Then
            lstrTitle += "  Actual Ratio > " + Str(CDec(Me.AmtActRatio.Text))
        End If
        If Me.CBMarRatio.Checked Then
            lstrTitle += "  Margin Ratio > " + Str(CDec(Me.AmtMarRatio.Text))
        End If
        If Me.CBDue.Checked Then
            lstrTitle += "  Due > " + Str(CDec(Me.AmtDue.Text))
        End If
        If Me.CBUndue.Checked Then
            lstrTitle += "  Undue > " + Str(CDec(Me.AmtUndue.Text))
        End If
        If Me.CBTotal.Checked Then
            lstrTitle += "  Total > " + Str(CDec(Me.Amttotal.Text))
        End If
        If Me.CBLimit.Checked Then
            lstrTitle += "  Credit Limit > " + Str(CDec(Me.AmtLimit.Text))
        End If
        If Me.CBOverDraft.Checked Then
            lstrTitle += "  OverDraft > " + Str(CDec(Me.AmtOverDraft.Text))
        End If
        If Me.CBRunner.Checked Then
            If Me.CBoRunFrom.Text.Trim <> "" And Me.CboRunTo.Text.Trim <> "" Then
                If Me.CBoRunFrom.Text.Trim = Me.CboRunTo.Text.Trim Then
                    lstrTitle += "  Runner Code: " + Me.CBoRunFrom.Text.Trim
                Else
                    lstrTitle += "  Runner Code: " + Me.CBoRunFrom.Text.Trim + " to " + Me.CboRunTo.Text.Trim
                End If
            End If
        End If
        If Me.CBClient.Checked Then
            If Me.txtClientFrom.Text.Trim <> "" And Me.txtClientTo.Text.Trim <> "" Then
                If Me.txtClientFrom.Text.Trim = Me.txtClientTo.Text.Trim Then
                    lstrTitle += "  Client Code: " + Me.txtClientFrom.Text.Trim
                Else
                    lstrTitle += "  Client Code: " + Me.txtClientFrom.Text.Trim + " to " + Me.txtClientTo.Text.Trim
                End If
            End If
        End If
        If Me.CBName.Checked Then
            lstrTitle += "  Name = " + Me.txtName.Text.Trim
        End If
        If Me.CBOSDay.Checked Then
            'lstrSQL += " and  liq.liq_day >= " + Str(CDec(Me.AmtOSDay.Text))   os_day
            lstrTitle += "   OS day >= " + Str(CDec(Me.AmtOSDay.Text))
        End If
        If Me.CBType.Checked Then
            If Me.RBTypeMargin.Checked Then
                lstrCltType = "M"
                lstrTitle += "  (Margin Only)"
            Else
                lstrCltType = "C"
                lstrTitle += "  (Cash Only)"
            End If
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lsubShowProcessing(True)
        lsubEnableForm(False)
        Application.DoEvents()

        rpt = cls.lFncPrintAccLst( _
            IIf(Me.CBcr.Checked, CDec(Me.AmtCR.Text), Nothing), _
            IIf(Me.CBdr.Checked, CDec(Me.AmtDR.Text), Nothing), _
            IIf(Me.CBMktMore.Checked, CDec(Me.AmtMktMore.Text), Nothing), _
            IIf(Me.CBMKTLess.Checked, CDec(Me.AmtMktLess.Text), Nothing), _
            IIf(Me.CBActRatio.Checked, CDec(Me.AmtActRatio.Text), Nothing), _
            IIf(Me.CBMarRatio.Checked, CDec(Me.AmtMarRatio.Text), Nothing), _
            IIf(Me.CBDue.Checked, CDec(Me.AmtDue.Text), Nothing), _
            IIf(Me.CBUndue.Checked, CDec(Me.AmtUndue.Text), Nothing), _
            IIf(Me.CBTotal.Checked, CDec(Me.Amttotal.Text), Nothing), _
            IIf(Me.CBLimit.Checked, CDec(Me.AmtLimit.Text), Nothing), _
            IIf(Me.CBOverDraft.Checked, CDec(Me.AmtOverDraft.Text), Nothing), _
            IIf(Me.CBRunner.Checked, Me.CBoRunFrom.Text.Trim(), ""), _
            IIf(Me.CBRunner.Checked, Me.CboRunTo.Text.Trim(), ""), _
            IIf(Me.CBClient.Checked, Me.txtClientFrom.Text.Trim(), ""), _
            IIf(Me.CBClient.Checked, Me.txtClientTo.Text.Trim(), ""), _
            IIf(Me.CBName.Checked, Me.txtName.Text.Trim(), ""), _
            IIf(Me.CBOSDay.Checked, Convert.ToDecimal(Me.AmtOSDay.Text), Nothing), _
            IIf(Me.CBType.Checked, lstrCltType, ""), _
            lstrTitle, _
            isEmpty, _
            rad)

        If isEmpty Then
            GSubShowWarn("No Record!")
            Windows.Forms.Cursor.Current = Cursors.Default
            lsubShowProcessing(False)
            lsubEnableForm(True)
            Exit Sub
        End If

        frm.GSubDisplayRpt(rpt)

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
        lsubEnableForm(True)
    End Sub
End Class
