Public Class FrmRptClientTurnover

    Private gCls As New clsRptClientTurnover
    Private gRpt As CrystalDecisions.CrystalReports.Engine.ReportClass = New rptClientTurnover
    Private gFrm As New FrmRptDisplay
    Public gFTradeDate As Date

    Private Sub FrmRptClientTurnover_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lsubShowProcessing(False)
        gCls.LoadClient(cboClientFrm, cboClientTo)
        gCls.LoadAE(cboAECodeFrm, cboAECodeTo)
        gCls.LoadExchangeCode(cboExchange)
        CheckObj(False)
        EnableObj(False)
        rbSortAvgTurnover.Checked = True
        rbPreview.Checked = True
        gFTradeDate = gCls.GetTradeDate()
        Me.dtpTrade.Value = gFTradeDate
    End Sub

    Private Sub cbClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbClient.CheckedChanged
        Me.cboClientFrm.Enabled = cbClient.Checked
        Me.cboClientTo.Enabled = cbClient.Checked
    End Sub

    Private Sub cbAECode_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAECode.CheckedChanged
        Me.cboAECodeFrm.Enabled = cbAECode.Checked
        Me.cboAECodeTo.Enabled = cbAECode.Checked
    End Sub

    Private Sub cbAvgTurnover_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAvgTurnover.CheckedChanged
        Me.txtAvgTurnover.Enabled = cbAvgTurnover.Checked
    End Sub

    Private Sub cbExchange_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbExchange.CheckedChanged
        Me.cboExchange.Enabled = cbExchange.Checked
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        lsubShowProcessing(True)
        Application.DoEvents()

        Dim PrintDialog1 As New PrintDialog
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.rbPrint.Checked = True Then
            If PrintDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDialog1.PrinterSettings.PrinterName
                shtCopies = PrintDialog1.PrinterSettings.Copies
                If PrintDialog1.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDialog1.PrinterSettings.FromPage
                    intToPage = PrintDialog1.PrinterSettings.ToPage
                End If
            Else
                lsubShowProcessing(False)
                Exit Sub
            End If
        End If

        Application.DoEvents()

        Dim lcSrc As DataTable = Nothing
        Dim lcFilteredSrc As DataTable = Nothing
        Dim lcClientFrm As String = IIf(cbClient.Checked, cboClientFrm.Text, "")
        Dim lcClientTo As String = IIf(cbClient.Checked, cboClientTo.Text, "")
        Dim lcAECodeFrm As String = IIf(cbAECode.Checked, cboAECodeFrm.Text, "")
        Dim lcAECodeTo As String = IIf(cbAECode.Checked, cboAECodeTo.Text, "")
        Dim lcAvgTurnover As String = IIf(cbAvgTurnover.Checked, txtAvgTurnover.Text, "")
        Dim lcExchange As String = IIf(cbExchange.Checked, cboExchange.Text, "")
        Dim lcOptions As String = "Options: "
        If cbClient.Checked Then
            If cboClientFrm.Text <> "" Then
                lcOptions &= "Client From: " & cboClientFrm.Text.Trim
                lcOptions &= ", "
            End If
            If cboClientTo.Text <> "" Then
                lcOptions &= "Client To: " & cboClientTo.Text.Trim
                lcOptions &= ", "
            End If
        End If
        If cbAECode.Checked Then
            If cboAECodeFrm.Text <> "" Then
                lcOptions &= "AECode From: " & cboAECodeFrm.Text.Trim
                lcOptions &= ", "
            End If
            If cboAECodeTo.Text <> "" Then
                lcOptions &= "AEcode To: " & cboAECodeTo.Text.Trim
                lcOptions &= ", "
            End If
        End If
        If cbAvgTurnover.Checked Then
            lcOptions &= "Avgerage Turnover >= " & txtAvgTurnover.Text.Trim
            lcOptions &= ", "
        End If
        If cbExchange.Checked Then
            lcOptions &= "Exchange = " & cboExchange.Text.Trim
        End If

        Dim lcCurrMonth As String = Me.dtpTrade.Value.ToString("yyyy/MM/01") & " - " & Me.dtpTrade.Value.ToString("yyyy/MM/dd")
        Dim lcPrevMonth As String = Me.dtpTrade.Value.AddMonths(-1).ToString("yyyy/MM/01") & " - " & Me.dtpTrade.Value.AddMonths(-1).ToString("yyyy/MM/") & Date.DaysInMonth(Me.dtpTrade.Value.Year, Me.dtpTrade.Value.AddMonths(-1).Month)
        Dim lcPrecPrevMonth As String = Me.dtpTrade.Value.AddMonths(-2).ToString("yyyy/MM/01") & " - " & Me.dtpTrade.Value.AddMonths(-2).ToString("yyyy/MM/") & Date.DaysInMonth(Me.dtpTrade.Value.Year, Me.dtpTrade.Value.AddMonths(-2).Month)

        Dim dt As DataTable = gCls.GetMainReport(lcClientFrm, lcClientTo, lcAECodeFrm, lcAECodeTo, lcAvgTurnover, _
                        lcExchange, lcSrc, Me.dtpTrade.Value, lcFilteredSrc)

        Dim lcSortedDv As DataView
        If Me.rbSortAvgTurnover.Checked Then
            
            lcSortedDv = dt.DefaultView
            lcSortedDv.Sort = "d_average_total desc, d_acc_no, d_ae_code, d_exchange"
            dt = lcSortedDv.ToTable

            lcOptions &= "Sort by " & rbSortAvgTurnover.Text

        ElseIf Me.rbSortClientNo.Checked Then
            lcSortedDv = dt.DefaultView
            lcSortedDv.Sort = "d_acc_no, d_ae_code, d_exchange"
            dt = lcSortedDv.ToTable

            lcOptions &= "Sort by " & rbSortClientNo.Text
        End If

        gRpt.SetDataSource(dt)
        gRpt.Subreports(1).SetDataSource(gCls.GetReportSummary(dt, Me.dtpTrade.Value, lcFilteredSrc))
        gRpt.Subreports(0).SetDataSource(gCls.GetReportCompany(lcSrc, Me.dtpTrade.Value))

        gRpt.SetParameterValue("paraPrintUser", GStrloginID)
        gRpt.SetParameterValue("paraTitle", lcOptions)
        gRpt.SetParameterValue("paraCurrMonthPeriod", lcCurrMonth)
        gRpt.SetParameterValue("paraPrevMonthPeriod", lcPrevMonth)
        gRpt.SetParameterValue("paraPrecPrevMonthPeriod", lcPrecPrevMonth)


        If rbPreview.Checked = True Then
            gFrm.GSubDisplayRpt(gRpt)
        ElseIf rbPrint.Checked = True Then
            GFncPrintRpt(gRpt, strPrinterName)
        End If

        lsubShowProcessing(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub CheckObj(ByVal pChecked As Boolean)
        cbClient.Checked = pChecked
        cbAECode.Checked = pChecked
        cbAvgTurnover.Checked = pChecked
        cbExchange.Checked = pChecked
    End Sub

    Private Sub EnableObj(ByVal pEnabled As Boolean)
        Me.cboClientFrm.Enabled = pEnabled
        Me.cboClientTo.Enabled = pEnabled
        Me.cboAECodeFrm.Enabled = pEnabled
        Me.cboAECodeTo.Enabled = pEnabled
        Me.txtAvgTurnover.Enabled = pEnabled
        Me.txtAvgTurnover.Enabled = pEnabled
        Me.cboExchange.Enabled = pEnabled
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub dtpTrade_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTrade.ValueChanged
        If Me.dtpTrade.Value > Me.gFTradeDate Then
            Me.dtpTrade.Value = Me.gFTradeDate
        End If
    End Sub
End Class
