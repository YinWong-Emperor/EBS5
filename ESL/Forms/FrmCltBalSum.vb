Imports System.Data.SqlClient

Public Class FrmCltBalSum
    Dim cls As New ClsCltBalSum
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim act As String = ""

    Private Sub FrmCltBalSum_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ldsAE As DataSet

        Me.cbAE.Checked = False
        ldsAE = cls.lFncGetAECode()

        For i As Integer = 0 To ldsAE.Tables(0).Rows.Count - 1
            If (ldsAE.Tables(0).Rows(i).Item("aeno").ToString.Trim <> "") Then
                Me.comboAEFrom.Items.Add(ldsAE.Tables(0).Rows(i).Item("aeno"))
                Me.comboAETo.Items.Add(ldsAE.Tables(0).Rows(i).Item("aeno"))
            End If
        Next

        buttonVisible(True)

        Dim ldsSign As DataTable
        ldsSign = cls.getSignature()
        For i As Integer = 0 To ldsSign.Rows.Count - 1
            If (ldsSign.Rows(i).Item("misc_code") = "regard") Then
                Me.txtRegard.Text = ldsSign.Rows(i).Item("misc_desc")
            End If
            If (ldsSign.Rows(i).Item("misc_code") = "noted1") Then
                Me.txtNoted1.Text = ldsSign.Rows(i).Item("misc_desc")
            End If
            If (ldsSign.Rows(i).Item("misc_code") = "noted2") Then
                Me.txtNoted2.Text = ldsSign.Rows(i).Item("misc_desc")
            End If
            If (ldsSign.Rows(i).Item("misc_code") = "noted3") Then
                Me.txtNoted3.Text = ldsSign.Rows(i).Item("misc_desc")
            End If
            If (ldsSign.Rows(i).Item("misc_code") = "endor1") Then
                Me.txtEndor1.Text = ldsSign.Rows(i).Item("misc_desc")
            End If
            If (ldsSign.Rows(i).Item("misc_code") = "endor2") Then
                Me.txtEndor2.Text = ldsSign.Rows(i).Item("misc_desc")
            End If
        Next
    End Sub

    Private Sub cbClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbClient.CheckedChanged

        If Me.cbClient.Checked = True Then
            Me.txtClientFrom.Enabled = True
            Me.txtClientTo.Enabled = True
            Me.txtClientFrom.Focus()
        Else
            Me.txtClientFrom.Enabled = False
            Me.txtClientTo.Enabled = False
            Me.txtClientFrom.Text = ""
            Me.txtClientTo.Text = ""
        End If

    End Sub

    Private Sub cbAE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAE.CheckedChanged

        If Me.cbAE.Checked = True Then
            Me.comboAEFrom.Enabled = True
            Me.comboAETo.Enabled = True
            Me.comboAEFrom.Focus()
        Else
            Me.comboAEFrom.Enabled = False
            Me.comboAETo.Enabled = False
            Me.comboAEFrom.SelectedIndex = -1
            Me.comboAETo.SelectedIndex = -1
        End If

    End Sub

    Private Sub cbActualRatio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbActualRatio.CheckedChanged

        If Me.cbActualRatio.Checked = True Then
            Me.txtAR.Enabled = True
            Me.txtAR.Focus()
        Else
            Me.txtAR.Enabled = False
            Me.txtAR.Text = ""
        End If

    End Sub

    Private Sub cbDRBal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbDRBal.CheckedChanged

        If Me.cbDRBal.Checked = True Then
            Me.txtDR.Enabled = True
            Me.txtDR.Focus()
        Else
            Me.txtDR.Enabled = False
            Me.txtDR.Text = ""
        End If

    End Sub

    Private Sub txtClientFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClientFrom.LostFocus

        Dim accnolength As Integer = 8
        Dim clientNo As String

        clientNo = Me.txtClientFrom.Text.Trim

        If (clientNo.Length > 0) And (clientNo.Length < accnolength) Then
            Dim i As Integer

            i = clientNo.Length
            Do Until i = accnolength
                clientNo = "0" & clientNo
                i = i + 1
            Loop

            Me.txtClientFrom.Text = clientNo
        End If

    End Sub

    Private Sub txtClientTo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtClientTo.LostFocus

        Dim accnolength As Integer = 8
        Dim clientNo As String

        clientNo = Me.txtClientTo.Text.Trim

        If (clientNo.Length > 0) And (clientNo.Length < accnolength) Then
            Dim i As Integer

            i = clientNo.Length
            Do Until i = accnolength
                clientNo = "0" & clientNo
                i = i + 1
            Loop

            Me.txtClientTo.Text = clientNo
        End If

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim lSQLstr As String = ""
        Dim lTitlestr As String = ""
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim Dr_Bal As Double = 0
        Dim lSQLGroupStr As String = ""


        If (Me.txtClientFrom.Text.Length > 0) Then
            lSQLGroupStr = lSQLGroupStr & "and b.clt_code >= '" & Me.txtClientFrom.Text & "' "
            lSQLstr = lSQLstr & "and clt_code >= '" & Me.txtClientFrom.Text & "' "
            lTitlestr = lTitlestr & " Client >= " & Me.txtClientFrom.Text
        End If
        If (Me.txtClientTo.Text.Length > 0) Then
            lSQLGroupStr = lSQLGroupStr & "and b.clt_code <= '" & Me.txtClientTo.Text & "' "
            lSQLstr = lSQLstr & "and clt_code <= '" & Me.txtClientTo.Text & "' "
            lTitlestr = lTitlestr & " Client <= " & Me.txtClientTo.Text
        End If
        If (Me.comboAEFrom.Text.Length > 0) Then
            lSQLGroupStr = lSQLGroupStr & "and b.run_code >= '" & Me.comboAEFrom.Text & "' "
            lSQLstr = lSQLstr & "and run_code >= '" & Me.comboAEFrom.Text & "' "
            lTitlestr = lTitlestr & " A.E. >= " & Me.comboAEFrom.Text
        End If
        If (Me.comboAETo.Text.Length > 0) Then
            lSQLGroupStr = lSQLGroupStr & "and b.run_code <= '" & Me.comboAETo.Text & "' "
            lSQLstr = lSQLstr & "and run_code <= '" & Me.comboAETo.Text & "' "
            lTitlestr = lTitlestr & " A.E. <= " & Me.comboAETo.Text
        End If
        If (Me.txtAR.Text.Length > 0) Then
            lSQLstr = lSQLstr & "and mc_act_ratio > " & Me.txtAR.Text & " "
            lTitlestr = lTitlestr & " Actual Ratio > " & Me.txtAR.Text
        End If
        If (Me.txtDR.Text.Length > 0) Then
            lSQLstr = lSQLstr & "and dr_bal > " & Me.txtDR.Text & " "
            lTitlestr = lTitlestr & " DR Balance > " & Me.txtDR.Text
            Dr_Bal = Me.txtDR.Text
        End If
        If (Me.cbSuspended.Checked = False) Then
            lSQLGroupStr = lSQLGroupStr & "and isnull(status_type,'') <> 'SUSP' "
            lSQLstr = lSQLstr & "and clt_status <> 'SUSP' "
        Else
            lTitlestr = lTitlestr & " Include Susp A/C "
        End If
        If (Me.cbClosed.Checked = False) Then
            lSQLGroupStr = lSQLGroupStr & "and isnull(status_type,'') <> 'CLOSE' "
            lSQLstr = lSQLstr & "and clt_status <> 'CLOSE' "
        Else
            lTitlestr = lTitlestr & " Include Closed A/C "
        End If
        If (Me.cbAllZero.Checked = False) Then
            lSQLstr = lSQLstr & "and not (ava_bal = 0 and cr_bal = 0 and dr_bal = 0 and interest = 0) "
        Else
            lTitlestr = lTitlestr & " Include All Zero "
        End If

        If (Me.rbSortClient.Checked) Then
            lSQLstr = lSQLstr & "order by clt_code "
            lTitlestr = lTitlestr & "  Sort By Client Code "
        ElseIf (Me.rbSortAE.Checked) Then
            lSQLstr = lSQLstr & "order by run_code, clt_code "
            lTitlestr = lTitlestr & " Sort By A.E. + Client Code "
        ElseIf (Me.rbSortDrBal.Checked) Then
            lSQLstr = lSQLstr & "order by dr_bal desc, margin_ratio desc "
            lTitlestr = lTitlestr & " Sort By DR Balance "
        End If

        If Me.rbPrinter.Checked = True Then
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

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        If (Me.rbExcel.Checked) Then
            If (cls.lFncExportExcel(lSQLstr, Dr_Bal, Me.txtRegard.Text, Me.txtNoted1.Text, _
                                    Me.txtNoted2.Text, Me.txtNoted3.Text, Me.txtEndor1.Text, _
                                    Me.txtEndor2.Text, lSQLGroupStr)) Then
                GSubShowInfo(GFncGetSysMsg(28))
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
            'If (cls.lFncExportCSV(lSQLstr, Dr_Bal) = True) Then
            '    GSubShowInfo(GFncGetSysMsg(28))
            'Else
            '    GSubShowInfo(GFncGetSysMsg(29))
            'End If
        Else
            rpt = cls.lFncGetBalSumRpt(lSQLstr, lTitlestr, Dr_Bal, Me.cbSummary.Checked, Me.txtRegard.Text, _
                                        Me.txtNoted1.Text, Me.txtNoted2.Text, Me.txtNoted3.Text, _
                                        Me.txtEndor1.Text, Me.txtEndor2.Text, lSQLGroupStr)
            If Me.rbPreview.Checked = True Then
                frm.GSubDisplayRpt(rpt)
            ElseIf Me.rbPrinter.Checked = True Then
                If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
                    GSubShowInfo(GFncGetSysMsg(104))
                End If
            End If
        End If

        cls.setSignature(Me.txtRegard.Text, Me.txtNoted1.Text, Me.txtNoted2.Text, _
                        Me.txtNoted3.Text, Me.txtEndor1.Text, Me.txtEndor2.Text)

        Windows.Forms.Cursor.Current = Cursors.Default
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If (Me.btnEdit.Enabled = False) Then
            e.Cancel = True
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedIndex = 0 Then
            If (Me.dgvMiscList.RowCount > 0) Then
                Me.dgvMiscValue.DataSource = cls.lFncList(Me.dgvMiscList.CurrentRow.Cells("misc_code").Value, True)
                Me.dgvMiscList.DataSource = cls.lFncMiscMst(True)
            End If
            buttonVisible(True)
        End If
        If Me.TabControl1.SelectedIndex = 1 Then
            Me.dgvMiscList.DataSource = cls.lFncMiscMst(False)
            buttonVisible(False)
            buttonEnable(True)
        End If
        If Me.TabControl1.SelectedIndex = 2 Then
            If (Me.dgvMiscList.RowCount > 0) Then
                Me.dgvMiscValue.DataSource = cls.lFncList(Me.dgvMiscList.CurrentRow.Cells("misc_code").Value, True)
                Me.dgvMiscList.DataSource = cls.lFncMiscMst(True)
            End If
            buttonVisible(True)
            Me.btnPrint.Visible = False
        End If
    End Sub

    Private Sub dgvMiscList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMiscList.SelectionChanged
        refreshGrid()
    End Sub

    Private Sub dgvMiscValue_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvMiscValue.SelectionChanged
        assignValue(Me.dgvMiscValue.CurrentRow.Cells("code").Value, Me.dgvMiscValue.CurrentRow.Cells("descpt").Value)
    End Sub

    Private Sub assignValue(ByVal code As String, ByVal descpt As String)
        Me.txtName.Text = code
        Me.txtDisplay.Text = descpt
    End Sub

    Private Sub refreshGrid()
        Me.dgvMiscValue.DataSource = cls.lFncList(Me.dgvMiscList.CurrentRow.Cells("misc_code").Value, False)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        act = "A"
        assignValue("", "")
        buttonEnable(False)
        Me.txtName.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        act = "E"
        buttonEnable(False)
        Me.txtName.Enabled = False
        Me.txtName.Focus()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim MyTrans As SqlTransaction = Nothing
        Dim key As String = ""
        If Me.dgvMiscValue.Rows.Count <= 0 Then
            Return
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            Try
                key = Me.dgvMiscValue.CurrentRow.Cells("code").Value
                MyTrans = GSCnSqlConn.BeginTransaction

                cls.lFncDeleteItem(Me.dgvMiscList.CurrentRow.Cells("misc_code").Value, _
                                    Me.dgvMiscValue.CurrentRow.Cells("code").Value, MyTrans)

                MyTrans.Commit()
                MyTrans = Nothing
                refreshGrid()
                GSubShowInfo(GFncGetSysMsg(13))
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim MyTrans As SqlTransaction = Nothing
        Dim misc_type As String = Me.dgvMiscList.CurrentRow.Cells("misc_code").Value
        Dim misc_code As String = Me.txtName.Text
        Dim misc_val As String = Me.txtDisplay.Text

        If (misc_code.Trim.Length = 0) Then
            GSubShowInfo(GFncGetSysMsg(53))
            Me.txtName.Focus()
            Return
        End If
        If (misc_val.Trim.Length = 0) Then
            GSubShowInfo(GFncGetSysMsg(53))
            Me.txtDisplay.Focus()
            Return
        End If
        If (act = "A") Then
            If (cls.lFncIsExist(Me.dgvMiscList.CurrentRow.Cells("misc_code").Value, Me.txtName.Text)) Then
                GSubShowInfo(GFncGetSysMsg(62))
                Me.txtName.Focus()
                Return
            End If
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            Try
                MyTrans = GSCnSqlConn.BeginTransaction
                If (act = "A") Then
                    cls.lFncAddItem(misc_type, misc_code, misc_val, MyTrans)
                End If
                If (act = "E") Then
                    cls.lFncSaveItem(misc_type, misc_code, misc_val, MyTrans)
                End If
                MyTrans.Commit()
                MyTrans = Nothing
                refreshGrid()
                buttonEnable(True)
                GSubShowInfo(GFncGetSysMsg(8))
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (Me.btnEdit.Enabled = False) Then
            assignValue(Me.dgvMiscValue.CurrentRow.Cells("code").Value, Me.dgvMiscValue.CurrentRow.Cells("descpt").Value)
            buttonEnable(True)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub buttonVisible(ByVal flag As Boolean)
        Me.btnPrint.Visible = flag
        Me.btnAdd.Visible = Not flag
        Me.btnEdit.Visible = Not flag
        Me.btnDelete.Visible = Not flag
        Me.btnSave.Visible = Not flag
    End Sub

    Private Sub buttonEnable(ByVal flag As Boolean)
        Me.dgvMiscList.Enabled = flag
        Me.dgvMiscValue.Enabled = flag
        Me.btnAdd.Enabled = flag
        Me.btnEdit.Enabled = flag
        Me.btnDelete.Enabled = flag
        Me.btnSave.Enabled = Not flag
        Me.txtName.Enabled = Not flag
        Me.txtDisplay.Enabled = Not flag
    End Sub

End Class
