Public Class FrmRptCommModify
    Dim DiffDT As DataTable
    Dim cls As New ClsRptCommModify
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmNewedgeDiffRpt_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Shown
        lsubShowProcessing(False)
        For i As Integer = 1 To 12
            Me.CboMonth.Items.Add(i)
        Next
        For i As Integer = Now.Year - 5 To Now.Year + 5
            Me.CboYr.Items.Add(i)
        Next
        'Me.DtDate.Text = cls.GetLatestDateComm()
        cls.GetLatestDateFut(Me.CboYr.Text, Me.CboMonth.Text)

    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1


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
        lsubShowProcessing(True)
        Application.DoEvents()
        If Me.RBTradeRpt.Checked Then
            rpt = cls.PrintCommRpt(Me.CboYr.Text & Format(CInt(Me.CboMonth.Text), "00"))
        ElseIf Me.RBTA_futRpt.Checked Then

            rpt = cls.PrintFutRpt(Me.CboYr.Text & Format(CInt(Me.CboMonth.Text), "00"))
        End If
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If Me.RBPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf Me.RBPrint.Checked = True Then
            If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
                GSubShowInfo(GFncGetSysMsg(104))
            End If
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    

   
    'Private Sub RBTradeRpt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBTradeRpt.CheckedChanged
    '    Me.DtDate.Enabled = Me.RBTradeRpt.Checked
    '    Me.CboMonth.Enabled = Me.RBTA_futRpt.Checked
    '    Me.CboYr.Enabled = Me.RBTA_futRpt.Checked
    'End Sub

End Class
