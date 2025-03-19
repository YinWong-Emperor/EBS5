Public Class frmNewedgeTrans

    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim cls As New clsNewedgeReport

    Private Sub frmFuturesNewedgeTrans_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim clsFR As New clsFuturesReport
        Me.cbxCounterParty.DataSource = clsFR.GetCounterParty
        Me.cbxCounterParty.ValueMember = "misc_desc"
        Me.dtpTrade.Text = Format(GDteTradeDate, "yyyy/MM/dd")
        lsubShowProcessing(False)
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        lsubShowProcessing(True)
        If Me.rbtPrint.Checked = True Then
            If PrintDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDialog1.PrinterSettings.PrinterName
                shtCopies = PrintDialog1.PrinterSettings.Copies
                If PrintDialog1.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDialog1.PrinterSettings.FromPage
                    intToPage = PrintDialog1.PrinterSettings.ToPage
                End If
            Else
                Exit Sub
            End If
        End If
        Application.DoEvents()
        'rpt = cls.FncGenTransactionReport(Format(CDate(Me.dtpTrade.Text.Trim), "yyyy/MM/dd"))
        rpt = cls.FncGenTransactionReport(Me.dtpTrade.Value, Me.cbxCounterParty.Text)

        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub
End Class
