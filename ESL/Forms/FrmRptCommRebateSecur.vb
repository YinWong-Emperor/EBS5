Public Class FrmRptCommRebateSecur

    Dim cls As New clsRptCommRebateSecur
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim AEList As DataTable

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRptAeComm_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Shown
        lsubShowProcessing(False)
        Me.btnSave.Visible = False
        Dim txmonth As String = GfncGetMonth()
        Dim year As String = txmonth.Substring(0, 4)
        Dim month As String = Val(txmonth.Substring(4, 2))
        FncGetAEList()
        For i As Integer = 1 To 12
            Me.CboMonth.Items.Add(i)
        Next
        For i As Integer = Val(year) - 5 To Val(year) + 2
            Me.cboYear.Items.Add(i)
        Next
        Me.CboMonth.Text = month
        Me.cboYear.Text = year
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        If Me.cboMonth.Text.Length <= 0 Or Me.cboYear.Text.Length <= 0 Then
            Return
        End If
        If FncValidAE(Me.cboAE.Text) = False Then
            Return
        End If
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        lsubShowProcessing(True)
        Dim txmonth As String = Me.cboYear.Text & Format(Val(Me.cboMonth.Text), "00")
        Dim ae As String = ""
        Dim display As Boolean = True
        Dim range As Decimal = 0
        ae = Me.cboAE.Text
      
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
        Dim lstrSummary As String = ""
        If Me.CheckBox1.Checked Then
            lstrSummary = "AC"
        ElseIf Me.CheckBox2.Checked Then
            lstrSummary = "AE"
        End If
        rpt = cls.PrintTotalCommSRpt(txmonth, ae, range, lstrSummary, Me.txtAE.Text.ToString)
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

    Private Sub FncGetAEList()
        AEList = cls.FncGetAE()
        Me.cboAE.Items.Add("")
        For Each dr As DataRow In AEList.Rows
            Me.cboAE.Items.Add(dr.Item("ae_no"))
        Next
    End Sub

    Private Function FncValidAE(ByVal AE As String) As Boolean
        If AE.Length > 0 Then
            Dim Row As Integer = Me.cboAE.FindString(AE)
            If Row >= 0 Then
                Return True
            Else
                GSubShowInfo(GFncGetSysMsg(31))
                Return False
            End If
        Else
            Return True
        End If
    End Function

    Private Sub cboAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAE.SelectedIndexChanged, cboAE.LostFocus
        If cboAE.Text.Length > 0 Then
            Dim dr() As DataRow = AEList.Select("ae_no='" & cboAE.Text & "'")
            If dr.Length > 0 Then
                Me.txtAE.Text = dr(0).Item("ae_name_s")
            Else
                Me.txtAE.Text = ""
            End If
        Else
            txtAE.Text = ""
        End If

    End Sub
End Class

