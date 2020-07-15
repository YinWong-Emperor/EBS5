Public Class FrmRptAdj

    Dim cls As New ClsRptAdj
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRptAdj_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Shown
        lsubShowProcessing(False)

        numFromYear.Value = GDteTradeDate.AddMonths(-1).Year
        numToYear.Value = GDteTradeDate.Year
        numFromMonth.Value = GDteTradeDate.AddMonths(-1).Month
        numToMonth.Value = GDteTradeDate.Month

        'fillAE(cmbFromAE, cmbToAE)

    End Sub

    Private Sub fillAE(ByVal comboF As ComboBox, ByVal comboT As ComboBox)
        Dim strSQL As String = ""
        Dim dt As DataTable = Nothing

        comboF.Items.Clear()
        comboT.Items.Clear()
        dt = cls.GetRunCode().Tables(0)

        For Each row As DataRow In dt.Rows
            comboF.Items.Add(row("run_code"))
            comboT.Items.Add(row("run_code"))
        Next

        comboF.Text = ""
        comboT.Text = ""
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
        Dim isEmpty As Boolean = False

        If (cmbFromAE.Text <> "" And cmbFromAE.Text.Trim.Length < 8) Then
            cmbFromAE.Text = cmbFromAE.Text.PadLeft(8, "0")
        End If

        If (cmbToAE.Text <> "" And cmbToAE.Text.Trim.Length < 8) Then
            cmbToAE.Text = cmbToAE.Text.PadLeft(8, "0")
        End If

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
        Dim commOption As String = ""
        Dim intOption As String = ""
        Dim nonZeroIPO As Boolean = cbNZero.Checked

        If (fromDate > toDate) Then
            GSubShowWarn("Please enter a valid time range!")
            Windows.Forms.Cursor.Current = Cursors.Default
            lsubShowProcessing(False)
            Exit Sub
        End If

        If (fromDate.AddMonths(12) <= toDate) Then
            GSubShowWarn("Invalid Time Range! Maximum 12 months is allowed!")
            Windows.Forms.Cursor.Current = Cursors.Default
            lsubShowProcessing(False)
            Exit Sub
        End If

        If radCommS.Checked Then
            commOption = radCommS.Text

        ElseIf radCommF.Checked Then
            commOption = radCommF.Text

        ElseIf radInt.Checked Then
            commOption = radInt.Text
        End If

        If radPos.Checked Then
            intOption = radPos.Text

        ElseIf radNeg.Checked Then
            intOption = radNeg.Text

        ElseIf radAll.Checked Then
            intOption = radAll.Text
        End If

        rpt = cls.PrintAdjRpt(commOption, intOption, fromDate, toDate, nonZeroIPO, cmbFromAE.Text, cmbToAE.Text, isEmpty)

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If GFncCheckPostingTime() Then
            lsubShowProcessing(False)
            Return
        End If

        If isEmpty Then
            GSubShowWarn("No Record!")
            Windows.Forms.Cursor.Current = Cursors.Default
            lsubShowProcessing(False)
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
    End Sub

    Private Sub prepareExport(ByRef ds As DataSet, ByVal fromDate As Date)
        Dim dsResult As DataSet = New DataSet
        Dim dt As DataTable = dsResult.Tables.Add()
        Dim tempDate As Date = fromDate.AddDays(1 - fromDate.Day)
        Dim drNew As DataRow = Nothing

        dt.Columns.Add("Client_Code")
        For i As Integer = 1 To 12
            dt.Columns.Add(Format(tempDate, "MMM_yyyy"))
            tempDate = tempDate.AddMonths(1)
        Next
        dt.Columns.Add("Total")

        For Each dr As DataRow In ds.Tables(0).Rows
            drNew = dt.NewRow
            drNew(0) = dr(0).ToString.Trim
            For i As Integer = 0 To 11
                drNew(i + 1) = dr(3 * i + 1) + dr(3 * i + 2) + dr(3 * i + 3)
                drNew(13) = (CDec(GFncNoNullValue(drNew(13))) + _
                                (GFncNoNullValue(dr(3 * i + 1)) _
                                + GFncNoNullValue(dr(3 * i + 2)) _
                                + GFncNoNullValue(dr(3 * i + 3)))).ToString
            Next
            dt.Rows.Add(drNew)
        Next
        ds = dsResult
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Dim fromDate As Date = New Date(numFromYear.Value, numFromMonth.Value, 1)
        Dim toDate As Date = New Date(numToYear.Value, numToMonth.Value, 1)

        Dim strHeader As String = ""
        Dim dsResult As DataSet = Nothing
        Dim condition As String = ""

        Dim commOption As String = ""
        Dim intOption As String = ""
        Dim nonZeroIPO As Boolean = cbNZero.Checked

        If (fromDate > toDate) Then
            GSubShowWarn("Please enter a valid time range!")
            Windows.Forms.Cursor.Current = Cursors.Default
            lsubShowProcessing(False)
            Exit Sub
        End If

        If (fromDate.AddMonths(12) <= toDate) Then
            GSubShowWarn("Invalid Time Range! Maximum 12 months is allowed!")
            Windows.Forms.Cursor.Current = Cursors.Default
            lsubShowProcessing(False)
            Exit Sub
        End If

        If (cmbFromAE.Text <> "" And cmbFromAE.Text.Trim.Length < 8) Then
            cmbFromAE.Text = cmbFromAE.Text.PadLeft(8, "0")
        End If

        If (cmbToAE.Text <> "" And cmbToAE.Text.Trim.Length < 8) Then
            cmbToAE.Text = cmbToAE.Text.PadLeft(8, "0")
        End If

        If radCommS.Checked Then
            commOption = radCommS.Text

        ElseIf radCommF.Checked Then
            commOption = radCommF.Text

        ElseIf radInt.Checked Then
            commOption = radInt.Text
        End If

        If radPos.Checked Then
            intOption = radPos.Text

        ElseIf radNeg.Checked Then
            intOption = radPos.Text

        ElseIf radAll.Checked Then
            intOption = radAll.Text
        End If

        Dim strFileName As String = "AdjRpt_" & commOption.Replace(" ", "") & _
                                "_" & Format(fromDate, "yyyyMMdd") & _
                                "_" & Format(toDate.AddMonths(1).AddDays(-1), "yyyyMMdd") & _
                                Format(Now(), "_yyyyMMddhhmmss") & ".csv"

        dsResult = cls.GenRptCommData(commOption, intOption, fromDate, toDate, cbNZero.Checked, cmbFromAE.Text.Trim, cmbToAE.Text.Trim, True)
        prepareExport(dsResult, fromDate)

        condition = "Range from " & Format(fromDate, "yyyyMM") & _
                      " to " & Format(toDate.AddMonths(1).AddDays(-1), "yyyyMM")

        Dim headerStr As String = " Client Code, " & fromDate.ToString("MMM yyyy", New System.Globalization.CultureInfo("en-us"))

        Dim nDate As Date = fromDate
        Dim inx As Integer = 1
        While (inx < 12)
            nDate = nDate.AddMonths(1)
            headerStr &= nDate.ToString(", MMM yyyy", New System.Globalization.CultureInfo("en-us"))
            inx += 1
        End While
        headerStr &= ", Total "

        If cmbFromAE.Text <> "" And cmbFromAE.Text <> cmbToAE.Text Then
            condition &= " Client Code >= " & cmbFromAE.Text.Trim
        End If

        If cmbToAE.Text <> "" And cmbFromAE.Text <> cmbToAE.Text Then
            condition &= " Client Code <= " & cmbToAE.Text.Trim
        End If

        If cmbFromAE.Text <> "" And cmbFromAE.Text = cmbToAE.Text Then
            condition &= " Client Code = " & cmbFromAE.Text.Trim
        End If

        If GExportCSV(GStrExptDir, strFileName, dsResult, headerStr, {"Adjustment Report", condition}, "utf-8") Then
            GSubShowInfo(GFncGetSysMsg(28))
        Else
            GSubShowInfo(GFncGetSysMsg(29))
        End If
    End Sub

    Private Sub radInt_CheckedChanged(sender As Object, e As EventArgs) Handles radInt.CheckedChanged
        If Me.radInt.Checked Then
            radAll.Enabled = True
            radPos.Enabled = True
            radNeg.Enabled = True
        Else
            radAll.Enabled = False
            radPos.Enabled = False
            radNeg.Enabled = False
        End If

    End Sub
End Class
