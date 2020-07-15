Public Class FrmAccTradePattern

    Dim cls As New ClsAccTradePattern
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim accno As String = Me.txtAccNo.Text
        Dim dateFrom As Date = Nothing
        Dim dateTo As Date = Nothing

        If GSubShowYNConfirm(GFncGetSysMsg(27), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
            Return
        End If
        If (accno.Trim.Length <= 0) Then
            GSubShowInfo(GFncGetSysMsg(90))
            Me.txtAccNo.Focus()
            Return
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        lsubShowProcessing(True)
        Application.DoEvents()

        If (Me.dpTDateFrom.Checked) Then
            dateFrom = Me.dpTDateFrom.Value
        Else
            dateFrom = cls.lFncGetClientFirstTradeDate(accno)
            If (IsNothing(dateFrom)) Then
                GSubShowInfo(GFncGetSysMsg(92))
                Windows.Forms.Cursor.Current = Cursors.Default
                lsubShowProcessing(False)
                Return
            End If
        End If
        If (Me.dpTDateTo.Checked) Then
            dateTo = Me.dpTDateTo.Value
        Else
            dateTo = Now()
        End If

        If cls.lFncExportCSV(Me.txtAccNo.Text, dateFrom, dateTo, Me.cbAvgPeriod.Checked, _
                             Me.cbLockPost.Checked, Me.cbSpreadLockPost.Checked) Then
            GSubShowInfo(GFncGetSysMsg(8))
        Else
            GSubShowInfo(GFncGetSysMsg(9))
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmAccTradePattern_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        lsubShowProcessing(False)
    End Sub
End Class
