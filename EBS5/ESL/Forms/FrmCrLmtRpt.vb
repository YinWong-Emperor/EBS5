Public Class FrmCrLmtRpt

    Dim cls As New ClsCrLmtRpt
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim condition As String = ""
        Dim lTitlestr As String = ""
        Dim sortBy As String = ""
        Dim clt_type As String = ""
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If (Me.txtClientFrom.Text.Length > 0) Then
            condition = condition & "and clt_code >= '" & Me.txtClientFrom.Text & "' "
            lTitlestr = lTitlestr & " Client >= " & Me.txtClientFrom.Text
        End If
        If (Me.txtClientTo.Text.Length > 0) Then
            condition = condition & "and clt_code <= '" & Me.txtClientTo.Text & "' "
            lTitlestr = lTitlestr & " Client <= " & Me.txtClientTo.Text
        End If
        If (Me.comboAEFrom.Text.Length > 0) Then
            condition = condition & "and run_code >= '" & Me.comboAEFrom.Text & "' "
            lTitlestr = lTitlestr & " A.E. >= " & Me.comboAEFrom.Text
        End If
        If (Me.comboAETo.Text.Length > 0) Then
            condition = condition & "and run_code <= '" & Me.comboAETo.Text & "' "
            lTitlestr = lTitlestr & " A.E. <= " & Me.comboAETo.Text
        End If

        If (Me.rbSortAE.Checked) Then
            sortBy = " run_code, clt_code "
            lTitlestr = lTitlestr & " order by A.E. "
        End If

        If (Me.rbSortClient.Checked) Then
            sortBy = " clt_code "
            lTitlestr = lTitlestr & " order by Client "
        End If

        If (Me.rbMargin.Checked) Then
            clt_type = "M"
        End If
        If (Me.rbCash.Checked) Then
            clt_type = "C"
        End If

        If Me.rbCSV.Checked = True Then
            If (cls.lFncExportCSV(Me.nudMth.Value, Me.nudday.Value, clt_type, condition, lTitlestr, sortBy)) Then
                GSubShowInfo(GFncGetSysMsg(28))
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
            Return
        End If

        rpt = cls.lFncGetBalSumRpt(Me.nudMth.Value, Me.nudday.Value, clt_type, condition, lTitlestr, sortBy)
        If Me.rbPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        End If
        If Me.rbPrinter.Checked = True Then
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

            If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
                GSubShowInfo(GFncGetSysMsg(104))
            End If
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub cbClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbClient.CheckedChanged
        If (Me.cbClient.Checked) Then
            Me.txtClientFrom.Enabled = True
            Me.txtClientTo.Enabled = True
        Else
            Me.txtClientFrom.Enabled = False
            Me.txtClientTo.Enabled = False
            Me.txtClientFrom.Text = ""
            Me.txtClientTo.Text = ""
        End If
    End Sub

    Private Sub cbAE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAE.CheckedChanged
        If (Me.cbAE.Checked) Then
            Me.comboAEFrom.Enabled = True
            Me.comboAETo.Enabled = True
        Else
            Me.comboAEFrom.Enabled = False
            Me.comboAETo.Enabled = False
            Me.comboAEFrom.Text = ""
            Me.comboAETo.Text = ""
            Me.comboAEFrom.SelectedIndex = -1
            Me.comboAETo.SelectedIndex = -1
        End If
    End Sub

    Private Sub FrmCrLmtRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ldsAE As DataSet

        Me.cbAE.Checked = False
        ldsAE = cls.lFncGetAECode()

        For i As Integer = 0 To ldsAE.Tables(0).Rows.Count - 1
            If (ldsAE.Tables(0).Rows(i).Item("aeno").ToString.Trim <> "") Then
                Me.comboAEFrom.Items.Add(ldsAE.Tables(0).Rows(i).Item("aeno"))
                Me.comboAETo.Items.Add(ldsAE.Tables(0).Rows(i).Item("aeno"))
            End If
        Next
    End Sub
End Class
