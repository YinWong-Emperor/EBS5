Public Class FrmRptCommCommAdj

    Dim cls As New clsRptCommCommAdj
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRptCommCommAdj_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Shown
        lsubShowProcessing(False)
        Dim txmonth As String = GfncGetMonth()
        Dim year As String = txmonth.Substring(0, 4)
        Dim month As String = Val(txmonth.Substring(4, 2))
        For i As Integer = 1 To 12
            Me.CboMonth.Items.Add(i)
        Next
        For i As Integer = Val(year) - 5 To Val(year) + 5
            Me.CboYear.Items.Add(i)
        Next
        Me.CboMonth.Text = month
        Me.CboYear.Text = year
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        lsubShowProcessing(True)
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
        If GFncCheckPostingTime() Then
            lsubShowProcessing(False)
            Return
        End If
        Application.DoEvents()
        rpt = cls.PrintCommAdjRpt(Me.CboYear.Text & Format(CInt(Me.CboMonth.Text), "00"))
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If GFncCheckPostingTime() Then
            lsubShowProcessing(False)
            Return
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
    End Sub

End Class
