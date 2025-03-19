Public Class FrmRptAEDetail
    Dim cls As New clsRptAEDetail
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
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
    Private Sub fillBranch(ByVal combo As ComboBox)
        Dim strSQL As String = ""
        Dim dt As DataTable = Nothing

        combo.Items.Clear()

        strSQL = "select distinct name from  " & GStrG2BSDB & ".dbo.branch_master order by Name "
        dt = GFncRtnDS(GSCnSqlConn, strSQL, 60).Tables(0)

        combo.Items.Add("")
        For Each row As DataRow In dt.Rows
            combo.Items.Add(row("name"))
        Next

        combo.Text = ""
    End Sub
    Private Sub fillTxMonth(ByVal combo As ComboBox)
        Dim strSQL As String = ""
        Dim dt As DataTable = Nothing

        combo.Items.Clear()

        strSQL = "select distinct(txmonth) from comm_ae_comm where txmonth > '0' order by txmonth desc"
        dt = GFncRtnDS(GSCnSqlConn, strSQL, 60).Tables(0)

        For Each row As DataRow In dt.Rows
            combo.Items.Add(row("txmonth"))
        Next

        combo.Text = ""
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub FrmRptCommSummary_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        lsubShowProcessing(False)
        fillAE(cmbFromAE)
        fillAE(cmbToAE)
        fillTxMonth(cmbTxMonth)
        fillBranch(Me.CboBranch)

        If Me.cmbTxMonth.Items.Count > 0 Then
            Me.cmbTxMonth.SelectedIndex = 0
        End If
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
        If Me.cmbTxMonth.SelectedIndex = 0 Then
            If GFncCheckPostingTime() Then
                lsubShowProcessing(False)
                Return
            End If
        End If

        Application.DoEvents()

        Dim tradeType As String = "PD"

        'If Me.rdbPD.Checked Then
        '    tradeType = "PD"
        'ElseIf Me.rdbITrade.Checked Then
        '    tradeType = "IT"
        'ElseIf Me.rdbOverAll.Checked Then
        '    tradeType = "ALL"
        'End If

        Dim tradeDate As String = GFncNoNullString(Me.cmbTxMonth.Text)

        If Me.radComm.Checked = True Then
            rpt = cls.PrintAEDetailRpt(cmbFromAE, cmbToAE, tradeType, tradeDate, _
                        GFncNoNullString(Me.CboBranch.Text).Trim)
        Else
            rpt = cls.PrintAEDetailICBC(cmbFromAE, cmbToAE)
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

    Private Sub FrmRptAEDetail_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub radICBC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radICBC.CheckedChanged
        If radICBC.Checked = True Then
            Me.cmbTxMonth.Enabled = False
            Me.CboBranch.Enabled = False
        Else
            Me.cmbTxMonth.Enabled = True
            Me.CboBranch.Enabled = True
        End If
    End Sub
End Class
