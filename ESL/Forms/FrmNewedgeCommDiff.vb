Public Class FrmNewedgeCommDiff

    Dim cls As New ClsNewedgeCommDiff
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

    Private Sub DtDate_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DtDate.ValueChanged

        loadComm()

    End Sub

    Private Sub loadComm()

        lsubShowProcessing(True)
        Me.dtgProduct.DataSource = cls.lFnGetComm(Me.DtDate.Value)
        Me.dtgProduct.DataMember = "product"
        setBgColor()
        lsubShowProcessing(False)

    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)

        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub setBgColor()

        For row As Integer = 0 To Me.dtgProduct.Rows.Count() - 1
            If dtgProduct.Rows(row).Cells("cal_comm").Value <> dtgProduct.Rows(row).Cells("cap_comm").Value Or _
                dtgProduct.Rows(row).Cells("cal_clearing").Value <> dtgProduct.Rows(row).Cells("cap_clearing").Value Or _
                dtgProduct.Rows(row).Cells("cal_levy").Value <> dtgProduct.Rows(row).Cells("cap_levy").Value Then
                For col As Integer = 0 To Me.dtgProduct.ColumnCount - 1
                    Me.dtgProduct.Rows(row).Cells(col).Style.BackColor = Color.LightPink
                    Me.dtgProduct.Rows(row).Cells(col).Style.SelectionBackColor = Color.LightPink
                    Me.dtgProduct.Rows(row).Cells(col).Style.SelectionForeColor = Color.Black
                Next
            Else
                For col As Integer = 0 To Me.dtgProduct.ColumnCount - 1
                    Me.dtgProduct.Rows(row).Cells(col).Style.BackColor = Color.Linen
                    Me.dtgProduct.Rows(row).Cells(col).Style.SelectionBackColor = Color.Linen
                    Me.dtgProduct.Rows(row).Cells(col).Style.SelectionForeColor = Color.Black
                Next
            End If
        Next

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1

        lsubShowProcessing(True)
        Application.DoEvents()

        rpt = cls.lFncGetDiffRpt(Me.DtDate.Value)

        If Me.RBPrint.Checked = True Then
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

    Private Sub FrmNewedgeCommDiff_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsFR As New clsFuturesReport
        Me.cbxCounterParty.DataSource = clsFR.GetCounterParty
        Me.cbxCounterParty.ValueMember = "misc_desc"
    End Sub

    Private Sub FrmNewedgeCommDiff_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        loadComm()

    End Sub

End Class
