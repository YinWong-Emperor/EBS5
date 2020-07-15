Public Class FrmRptCommAEDetail
    Dim cls As New ClsRptCommAEDetail
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRptCommAEDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lFncLoadMonth()
        lsubShowProcessing(False)
    End Sub

    Private Sub lFncLoadMonth()
        Dim yr As Integer
        Dim mon As Integer
        Dim txmonth As String = GfncGetMonth()
        yr = txmonth.Substring(0, 4)
        mon = Val(txmonth.Substring(4, 2))

        For inYr As Integer = yr - 5 To yr + 2
            Me.cboYear.Items.Add(inYr)
        Next

        For inMon As Integer = 1 To 12
            Me.cboMonth.Items.Add(inMon)
        Next

        Me.cboYear.SelectedIndex = Me.cboYear.FindString(yr)
        Me.cboMonth.SelectedIndex = Me.cboMonth.FindString(mon)

    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnShow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnShow.Click
        Dim txmonth As String
        Dim ldtDetail As New DataTable
        lsubShowProcessing(True)
        txmonth = Me.cboYear.Text & Format(Val(cboMonth.Text), "00")
        If rbSec.Checked Then
            ldtDetail = cls.lFncCalTotalComm(txmonth)
        ElseIf rbFut.Checked Then
            ldtDetail = cls.lfncParpareTODTF(txmonth)
            'ElseIf rbOther.Checked Then
            '    ldtDetail = cls.lfncCalOther(Me.cboMonth.Text, ldtComm)
        ElseIf rbMan.Checked Then
            ldtDetail = cls.lfncParpareMan(txmonth)
        End If
        Me.DtgData.DataSource = ldtDetail
        lsubShowProcessing(False)
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim txmonth As String
        Dim ldtDetail As New DataTable
        lsubShowProcessing(True)
        txmonth = Me.cboYear.Text & Format(Val(cboMonth.Text), "00")
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
        If rbSec.Checked Then
            rpt = cls.PrintTotalCommSRpt(txmonth)
        ElseIf rbFut.Checked Then
            rpt = cls.PrintTotalCommFRpt(txmonth)
        ElseIf rbMan.Checked Then
            rpt = cls.PrintTotalCommMRpt(txmonth)
        End If
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
