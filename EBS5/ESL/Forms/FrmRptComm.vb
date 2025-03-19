Public Class FrmRptComm

    Dim cls As New ClsRptComm
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRptComm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Shown
        lsubShowProcessing(False)
        'Dim year As String = ""
        'Dim month As String = ""
        'Dim txmonth As String = GfncGetMonth()
        'year = Val(txmonth.Substring(0, 4))
        'month = Val(txmonth.Substring(4, 2))
        'For i As Integer = 1 To 12
        '    Me.cmbToAE.Items.Add(i)
        'Next
        'For i As Integer = Val(year) - 5 To Val(year) + 5
        '    Me.cmbFromAE.Items.Add(i)
        'Next
        'Me.cmbToAE.Text = month
        'Me.cmbFromAE.Text = year

        numFromYear.Value = GDteTradeDate.AddMonths(-1).Year
        numToYear.Value = GDteTradeDate.Year
        numFromMonth.Value = GDteTradeDate.AddMonths(-1).Month
        numToMonth.Value = GDteTradeDate.Month

        fillAE(cmbFromAE)
        fillAE(cmbToAE)

    End Sub

    Private Sub fillAE(ByVal combo As ComboBox)
        Dim strSQL As String = ""
        Dim dt As DataTable = Nothing

        combo.Items.Clear()

        strSQL = "select distinct run_code from " & GSCnLiqConn.Database.Trim & "..stcltmaster where run_code<>'' order by run_code"
        dt = GFncRtnDS(GSCnSqlConn, strSQL, 60).Tables(0)

        For Each row As DataRow In dt.Rows
            combo.Items.Add(row("run_code"))
        Next

        combo.Text = ""
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
                lsubShowProcessing(False)
                Exit Sub
            End If
        End If
        If GFncCheckPostingTime() Then
            lsubShowProcessing(False)
            Return
        End If
        Application.DoEvents()

        Dim fromDate As Date = New Date(numFromYear.Value, numFromMonth.Value, 1)
        Dim toDate As Date = New Date(numToYear.Value, numToMonth.Value, 1)

        rpt = cls.PrintCommRpt(cmbFromAE, cmbToAE, fromDate, toDate)
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

    Private Sub MyButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton1.Click

        Dim fromDate As Date = New Date(numFromYear.Value, numFromMonth.Value, 1)
        Dim toDate As Date = New Date(numToYear.Value, numToMonth.Value, 1)

        Dim strFileName As String = "CommRptByAE_" & Format(fromDate, "yyyyMMdd") & _
                                        "_" & Format(toDate.AddMonths(1).AddDays(-1), "yyyyMMdd") & "_" & Format(Date.Now, "yyyyMMddHHmmss") & ".csv"
        Dim strHeader As String = ""
        Dim dsResult As DataSet = Nothing
        Dim condition As String = ""

        dsResult = cls.genRptComm(cmbFromAE, cmbToAE, fromDate, toDate)

        condition = "Range from " & Format(fromDate, "yyyyMM") & _
                      " to " & Format(toDate.AddMonths(1).AddDays(-1), "yyyyMM")



        
        If cmbFromAE.Text.Trim <> cmbToAE.Text.Trim Then
            If cmbFromAE.Text <> "" Then
                condition &= "   AE No. >= " & cmbFromAE.Text.Trim
            End If

            If cmbToAE.Text <> "" Then
                If cmbFromAE.Text <> "" Then
                    condition &= " & "
                End If
                condition &= "  AE No. <= " & cmbToAE.Text.Trim
            End If
        ElseIf cmbFromAE.Text <> "" Then
            condition &= "  AE No. = " & cmbFromAE.Text.Trim
        End If

        Dim title As String() = New String() {"Commission Report by AE - " & condition}
        Dim header As String = "ae,accno,scomm,fcomm,iint,total,commipo,intipo"

        If GExportCSV(GStrExptDir, strFileName, dsResult, header, title, "utf-8") Then
            GSubShowInfo(GFncGetSysMsg(28))
        Else
            GSubShowInfo(GFncGetSysMsg(29))
        End If
    End Sub
End Class
