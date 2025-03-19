Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmRptOverTrade
    Dim cls As New ClsRptOverTrade
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim strMode As String = "Search"

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If Me.TabControl1.SelectedIndex = 1 Then
            Me.lsubSSave()
            Return
        End If
        If Me.TabControl1.SelectedIndex = 2 Then
            Me.lsubLSave()
            Return
        End If
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim lstrType As String = ""
        Dim lstrTitle As String = ""
        Dim lstrSQL As String = ""
        Dim lstrSort As String = " run_name "
        Dim MarginCAmt As String = "1=1"

        If Me.CB1000.Checked Then
            lstrSQL += " and mc_total >= 1000 "
            lstrTitle += "  (Exclude Total Margin Call < 1000) "
        End If
        lstrSQL += " and clt_type <> 'C' "

        If Me.RBPrint.Checked = True Then
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

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lsubShowProcessing(True)
        lsubEnableForm(False)
        Application.DoEvents()

        rpt = cls.lFncPrintOT(lstrSQL, lstrSort, lstrTitle, MarginCAmt)

        If Me.RBPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf Me.RBPrint.Checked = True Then
            If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
                GSubShowInfo(GFncGetSysMsg(104))
            End If
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
        lsubEnableForm(True)
        'save criteria

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.TabControl1.SelectedIndex = 1 And Me.btnSave.Enabled Then
            Me.lsubShowSign()
            Me.lsubEnable(False)
        ElseIf Me.TabControl1.SelectedIndex = 2 And Me.btnSave.Enabled Then
            Me.lsubShowLimit()
            Me.lsubEnable_limit(False)
        Else
            Me.Close()
        End If

    End Sub
    Private Sub lsubSSave()
        If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            If cls.lFncUpdSign(Me.dgdSign) Then
                GSubShowInfo(GFncGetSysMsg(8))
                Me.lsubShowSign()
                Me.lsubEnable(False)
            Else
                GSubShowError(GFncGetSysMsg(9))
            End If
        End If
    End Sub
    Private Sub lsubLSave()
        If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            If cls.lFncUpdLimit(Me.dgdLimit) Then
                GSubShowInfo(GFncGetSysMsg(8))
                Me.lsubShowLimit()
                Me.lsubEnable_limit(False)
            Else
                GSubShowError(GFncGetSysMsg(9))
            End If
        End If

    End Sub
    Private Sub lsubShowSign()
        Dim ldtSign As DataTable = cls.lFncGetSignDT()
        Me.dgdSign.DefaultCellStyle.BackColor = Color.Linen
        Me.dgdSign.DataSource = ldtSign
    End Sub
    Private Sub lsubShowLimit()
        Dim ldtLimit As DataTable = cls.lFncGetLimitDT(Me.txtSAE.Text, Me.txtSName.Text, _
                Me.txtSGroup.Text, Me.chkZero.Checked)
        Me.dgdLimit.DefaultCellStyle.BackColor = Color.Linen
        Me.dgdLimit.DataSource = ldtLimit
    End Sub
    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        Me.btnCancel.Visible = bEnable
        Me.btnSave.Visible = bEnable
        Me.RBPreview.Enabled = bEnable
        Me.RBPrint.Enabled = bEnable
    End Sub

    Private Sub FrmRptOverTrade_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lsubShowProcessing(False)
        lsubEnableForm(True)
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedIndex = 1 Then
            Me.lsubShowSign()
            Me.lsubEnable(False)
            Me.dgdSign.Focus()
            If Me.dgdSign.RowCount > 0 Then
                Me.dgdSign.Rows(0).Cells("TITLE").Selected = True
            End If
        ElseIf Me.TabControl1.SelectedIndex = 2 Then
            lsubShowLimit()
            lsubEnable_limit(False)
        Else
            Me.btnSave.Enabled = True
        End If
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If strMode = "Modify" Then
            e.Cancel = True
        End If
    End Sub
    Private Sub lsubEnable(ByVal bln As Boolean)
        Dim lintCnt As Integer
        Me.dgdSign.ReadOnly = Not bln
        Me.dgdSign.AllowUserToAddRows = bln
        Me.btnSave.Enabled = bln
        Me.BtnUp.Enabled = Not bln
        Me.btnDown.Enabled = Not bln
        If bln Then
            strMode = "Modify"
            Me.dgdSign.SelectionMode = DataGridViewSelectionMode.CellSelect
            For lintCnt = 0 To Me.dgdSign.RowCount - 1
                Me.dgdSign.Rows(lintCnt).Cells("seq").ReadOnly = True
                Me.dgdSign.Rows(lintCnt).Cells("seq").Style.BackColor = Color.Linen
                Me.dgdSign.Rows(lintCnt).Cells("title").Style.BackColor = Color.White
                Me.dgdSign.Rows(lintCnt).Cells("sign_by").Style.BackColor = Color.White
            Next
        Else
            strMode = "Search"
            Me.dgdSign.SelectionMode = DataGridViewSelectionMode.FullRowSelect
            For lintCnt = 0 To Me.dgdSign.RowCount - 1
                Me.dgdSign.Rows(lintCnt).Cells("seq").ReadOnly = True
                Me.dgdSign.Rows(lintCnt).Cells("seq").Style.BackColor = Color.Linen
                Me.dgdSign.Rows(lintCnt).Cells("title").Style.BackColor = Color.Linen
                Me.dgdSign.Rows(lintCnt).Cells("sign_by").Style.BackColor = Color.Linen
            Next
        End If
    End Sub
    Private Sub lsubEnable_limit(ByVal bln As Boolean)
        Dim lintCnt As Integer
        Me.dgdLimit.ReadOnly = Not bln
        Me.dgdLimit.SelectionMode = DataGridViewSelectionMode.CellSelect
        Me.btnSave.Enabled = bln
        Me.btnLSearch.Enabled = Not bln
        Me.txtSGroup.Enabled = Not bln
        Me.txtSName.Enabled = Not bln
        Me.txtSAE.Enabled = Not bln
        Me.chkZero.Enabled = Not bln

        If bln Then
            strMode = "Modify"
            For lintCnt = 0 To Me.dgdLimit.RowCount - 1
                Me.dgdLimit.Rows(lintCnt).Cells("run_code").ReadOnly = True
                Me.dgdLimit.Rows(lintCnt).Cells("ae_name").ReadOnly = True
                Me.dgdLimit.Rows(lintCnt).Cells("run_code").Style.BackColor = Color.Linen
                Me.dgdLimit.Rows(lintCnt).Cells("ae_name").Style.BackColor = Color.Linen
                Me.dgdLimit.Rows(lintCnt).Cells("overtrade_group").Style.BackColor = Color.White
                Me.dgdLimit.Rows(lintCnt).Cells("overtrade_limit").Style.BackColor = Color.White
            Next
        Else
            strMode = "Search"
            For lintCnt = 0 To Me.dgdLimit.RowCount - 1
                Me.dgdLimit.Rows(lintCnt).Cells("run_code").ReadOnly = True
                Me.dgdLimit.Rows(lintCnt).Cells("ae_name").ReadOnly = True
                Me.dgdLimit.Rows(lintCnt).Cells("run_code").Style.BackColor = Color.Linen
                Me.dgdLimit.Rows(lintCnt).Cells("ae_name").Style.BackColor = Color.Linen
                Me.dgdLimit.Rows(lintCnt).Cells("overtrade_group").Style.BackColor = Color.Linen
                Me.dgdLimit.Rows(lintCnt).Cells("overtrade_limit").Style.BackColor = Color.Linen
            Next
        End If
    End Sub
    Private Sub lsubChangeRow(ByVal strUpDown As String)
        Dim lstrTitle As String
        Dim lstrSignBy As String

        If Me.dgdSign.Rows.Count > 0 Then
            If Me.dgdSign.SelectedRows.Count > 0 Then
                Dim lintIndex As Integer = Me.dgdSign.CurrentRow.Index

                lstrtitle = Me.dgdSign.Rows(lintIndex).Cells("title").Value
                lstrSignBy = Me.dgdSign.Rows(lintIndex).Cells("sign_by").Value
                If strUpDown = "UP" Then
                    If lintIndex > 0 Then
                        Me.dgdSign.Rows(lintIndex).Cells("title").Value = _
                                Me.dgdSign.Rows(lintIndex - 1).Cells("title").Value
                        Me.dgdSign.Rows(lintIndex).Cells("sign_by").Value = _
                              Me.dgdSign.Rows(lintIndex - 1).Cells("sign_by").Value
                      
                        Me.dgdSign.Rows(lintIndex - 1).Cells("title").Value = lstrTitle
                        Me.dgdSign.Rows(lintIndex - 1).Cells("sign_by").Value = lstrSignBy
                        Me.dgdSign.Rows(lintIndex - 1).Cells("sign_by").Selected = True
                    End If
                Else
                    If lintIndex < Me.dgdSign.Rows.Count - 1 Then
                        Me.dgdSign.Rows(lintIndex).Cells("title").Value = _
                            Me.dgdSign.Rows(lintIndex + 1).Cells("title").Value
                        Me.dgdSign.Rows(lintIndex).Cells("sign_by").Value = _
                              Me.dgdSign.Rows(lintIndex + 1).Cells("sign_by").Value

                        Me.dgdSign.Rows(lintIndex + 1).Cells("title").Value = lstrTitle
                        Me.dgdSign.Rows(lintIndex + 1).Cells("sign_by").Value = lstrSignBy
                        Me.dgdSign.Rows(lintIndex + 1).Cells("sign_by").Selected = True
                    End If
                End If

            End If
        End If
    End Sub
    Private Sub BtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnUp.Click
        lsubChangeRow("UP")
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        lsubChangeRow("DN")
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        Me.lsubEnable(True)
        Me.dgdSign.Focus()
        If Me.dgdSign.RowCount > 0 Then
            Me.dgdSign.Rows(0).Cells("TITLE").Selected = True
        End If
    End Sub

    Private Sub dgdSign_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgdSign.KeyDown
        If Me.dgdSign.RowCount > 1 Then
            If e.KeyCode = Keys.Delete And Not Me.dgdSign.ReadOnly Then
                If Me.dgdSign.CurrentRow.Index <> Me.dgdSign.RowCount - 1 Then
                    If Me.dgdSign.IsCurrentCellInEditMode = False Then
                        Me.dgdSign.Rows.RemoveAt(Me.dgdSign.CurrentRow.Index)
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub dgdSign_RowEnter(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgdSign.RowEnter
        If e.RowIndex = Me.dgdSign.RowCount - 1 And Not Me.dgdSign.ReadOnly Then
            Me.dgdSign.Rows(e.RowIndex).Cells("seq").ReadOnly = True
            Me.dgdSign.Rows(e.RowIndex).Cells("seq").Style.BackColor = Color.Linen
            Me.dgdSign.Rows(e.RowIndex).Cells("title").Style.BackColor = Color.White
            Me.dgdSign.Rows(e.RowIndex).Cells("sign_by").Style.BackColor = Color.White
        End If
    End Sub

    Private Sub btnLSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLSearch.Click
        lsubShowLimit()
    End Sub

    Private Sub btnLModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLModify.Click
        lsubEnable_limit(True)
    End Sub

    Private Sub dgdLimit_DataError(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewDataErrorEventArgs) Handles dgdLimit.DataError
        If e.Exception.Message <> "" Then
            GSubShowError(GFncGetSysMsg(53))
            Me.dgdLimit.Rows(e.RowIndex).Cells(e.ColumnIndex).Selected = True
            Me.dgdLimit.Focus()
            Return
        End If
       
    End Sub
End Class
