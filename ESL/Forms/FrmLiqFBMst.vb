Imports CrystalDecisions.Shared
Imports System.IO


Public Class FrmLiqFBMst

    Dim cls As New ClsLiqMst
    Dim ldtsDetail As DataSet
    Dim ldtsTotal As DataSet
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub FrmLiqFBMst_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ldtsRunner As DataSet = cls.lFncGetRunner()
        Dim ldtwRunner As DataRow

        Me.RBMargin.Checked = True
        Me.lsubShowProcessing(False)

        Me.CboFrm.Items.Add("")
        Me.CboTo.Items.Add("")
        Me.CBoRunFrom.Items.Add("")
        Me.CboRunTo.Items.Add("")
        For Each ldtwRunner In ldtsRunner.Tables(0).Rows
            Me.CboFrm.Items.Add(ldtwRunner("run_code"))
            Me.CboTo.Items.Add(ldtwRunner("run_code"))
            Me.CBoRunFrom.Items.Add(ldtwRunner("run_code"))
            Me.CboRunTo.Items.Add(ldtwRunner("run_code"))
        Next

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lsubDisplay(ByVal lstrType As String)
        ldtsDetail = cls.lFncGetFBDetail(lstrType)
        ldtsTotal = cls.lFncGetFBTotal(lstrType)

        Me.DtgDetail.DataSource = ldtsDetail
        Me.DtgDetail.DataMember = "Detail"
        Me.DtgTotal.DataSource = ldtsTotal
        Me.DtgTotal.DataMember = "Total"

    End Sub

    Private Sub RBMargin_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBMargin.CheckedChanged
        If Me.RBMargin.Checked Then
            Me.lsubDisplay("M")
        End If
    End Sub

    Private Sub RBFinance_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBFinance.CheckedChanged
        If Me.RBFinance.Checked Then
            Me.lsubDisplay("F")
        End If
    End Sub

    Private Sub RBCash_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBCash.CheckedChanged
        If Me.RBCash.Checked Then
            Me.lsubDisplay("C")
        End If
    End Sub

    Private Sub RBAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBAll.CheckedChanged
        If Me.RBAll.Checked Then
            Me.lsubDisplay("")
        End If
    End Sub


    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim lstrType As String = ""
        Dim lstrTitle As String = ""
        Dim lstrSQL As String = ""

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

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lsubShowProcessing(True)
        lsubEnableForm(False)
        Application.DoEvents()

        If Me.CboFrm.Text.Trim <> "" Then
            lstrSQL += " and run_code >= '" & Me.CboFrm.Text.Trim.Trim & "' "
        End If
        If Me.CboTo.Text.Trim <> "" Then
            lstrSQL += " and run_code <= '" & Me.CboTo.Text.Trim & "' "
        End If
        If Me.CboFrm.Text.Trim <> "" Or Me.CboTo.Text.Trim <> "" Then
            lstrTitle += " " & Me.CboFrm.Text.Trim & " To " & Me.CboTo.Text.Trim & " "
        End If
        rpt = cls.lFncPrintAccFBLst(lstrSQL, lstrTitle)

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

    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub


    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        Me.btnCancel.Visible = bEnable
        Me.RBPreview.Enabled = bEnable
        Me.RBPrint.Enabled = bEnable
        Me.CboFrm.Enabled = bEnable
        Me.CboTo.Enabled = bEnable
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If Me.TabControl1.SelectedIndex = 1 Then
            Me.AmtCR.Text = "10,000,000"
            Me.AmtDR.Text = "10,000,000"
            Me.AmtMktMore.Text = "10,000,000"
            Me.AmtMktLess.Text = "0"
            Me.AmtDue.Text = "5,000,000"
            Me.AmtUndue.Text = "5,000,000"
            Me.AmtActRatio.Text = "60.00"
            Me.AmtMarRatio.Text = "60.00"
            Me.Amttotal.Text = "5,000,000"
            Me.AmtOverDraft.Text = "5,000,000"
            Me.AmtOSDay.Text = "1"
            Me.AmtOverDraft.Text = "5,000,000"
            Me.AmtFutures.Text = "0"
            Me.RBTypeMargin.Checked = True
            Me.RBTypeCash.Checked = False
            Me.CBcr.Checked = False
            Me.CBMktMore.Checked = False
            Me.CBMKTLess.Checked = False
            Me.CBMarRatio.Checked = False
            Me.CBLimit.Checked = False
            Me.CBDue.Checked = False
            Me.CBFutures.Checked = False
            Me.CBActRatio.Checked = False
            Me.CBClient.Checked = False
            Me.CBOSDay.Checked = False
            Me.CBOverDraft.Checked = False
            Me.CBType.Checked = False
            Me.CBTotal.Checked = False
            Me.CBRunner.Checked = False
            Me.CBUndue.Checked = False
            Me.CBName.Checked = False
        End If
        If Me.TabControl1.SelectedIndex = 2 Then
            Me.RBPreview.Checked = True
            Me.CboFrm.Text = ""
            Me.CboTo.Text = ""
            Me.CboFrm.Focus()
        End If
        If Me.TabControl1.SelectedIndex = 3 Then
            Me.txtClientName.Text = ""
            Me.txtClientCode.Text = ""
            Me.txtClientCode.Focus()
        End If
        If Me.TabControl1.SelectedIndex = 4 Then
            Me.MyTextbox1.Text = "c:\itas\liquidation_FBlist.csv"
            Me.MyButton2.Focus()
        End If
    End Sub

    Private Sub MyButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton1.Click
        Dim lstrSQL As String = ""
        Dim lstrTitle As String = ""

        If Me.CBcr.Checked Then
            lstrSQL += " and  cr_bal > " & Str(CDec(Me.AmtCR.Text))
            lstrTitle += "   Credit Balance > " + Str(CDec(Me.AmtCR.Text))
        End If
        If Me.CBdr.Checked Then
            lstrSQL += " and  dr_bal > " + Str(CDec(Me.AmtDR.Text))
            lstrTitle += "   Debit Balance > " + Str(CDec(Me.AmtDR.Text))
        End If
        If Me.CBMktMore.Checked Then
            lstrSQL += " and  mkt_value > " + Str(CDec(Me.AmtMktMore.Text))
            lstrTitle += "  MKt Value > " + Str(CDec(Me.AmtMktMore.Text))
        End If
        If Me.CBMKTLess.Checked Then
            lstrSQL += " and  mkt_value < " + Str(CDec(Me.AmtMktLess.Text))
            lstrTitle += "  MKt Value < " + Str(CDec(Me.AmtMktLess.Text))
        End If
        If Me.CBActRatio.Checked Then
            lstrSQL += " and  mc_act_ratio * 100 > " + Str(CDec(Me.AmtActRatio.Text))
            lstrTitle += "  Actual Ratio > " + Str(CDec(Me.AmtActRatio.Text))
        End If
        If Me.CBMarRatio.Checked Then
            lstrSQL += " and  margin_ratio * 100 > " + Str(CDec(Me.AmtMarRatio.Text))
            lstrTitle += "  Margin Ratio > " + Str(CDec(Me.AmtMarRatio.Text))
        End If
        If Me.CBDue.Checked Then
            lstrSQL += " and  mc_due > " + Str(CDec(Me.AmtDue.Text))
            lstrTitle += "  Due > " + Str(CDec(Me.AmtDue.Text))
        End If
        If Me.CBUndue.Checked Then
            lstrSQL += " and  mc_total - mc_due > " + Str(CDec(Me.AmtUndue.Text))
            lstrTitle += "  Undue > " + Str(CDec(Me.AmtUndue.Text))
        End If
        If Me.CBTotal.Checked Then
            lstrSQL += " and  mc_total > " + Str(CDec(Me.Amttotal.Text))
            lstrTitle += "  Total > " + Str(CDec(Me.Amttotal.Text))
        End If
        If Me.CBLimit.Checked Then
            lstrSQL += " and  cr_limit > " + Str(CDec(Me.AmtLimit.Text))
            lstrTitle += "  Credit Limit > " + Str(CDec(Me.AmtLimit.Text))
        End If
        If Me.CBOverDraft.Checked Then
            lstrSQL += " and  mc_overdraft > " + Str(CDec(Me.AmtOverDraft.Text))
            lstrTitle += "  OverDraft > " + Str(CDec(Me.AmtOverDraft.Text))
        End If
        If Me.CBRunner.Checked Then
            If Me.CBoRunFrom.Text.Trim <> "" Then
                lstrSQL += " and  run_code >= '" + Me.CBoRunFrom.Text.Trim + "' "
            End If
            If Me.CboRunTo.Text.Trim <> "" Then
                lstrSQL += " and  run_code <= '" + Me.CboRunTo.Text.Trim + "' "
            End If
            lstrTitle += "  (" + Me.CBoRunFrom.Text.Trim + " To " + Me.CboRunTo.Text.Trim + ") "
        End If
        If Me.CBClient.Checked Then
            If Me.txtClientFrom.Text.Trim <> "" Then
                lstrSQL += " and  mst.clt_code >= '" + Me.txtClientFrom.Text.Trim + "' "
            End If
            If Me.txtClientTo.Text.Trim <> "" Then
                lstrSQL += " and  mst.clt_code <= '" + Me.txtClientTo.Text.Trim + "' "
            End If
            lstrTitle += "  (" + Me.txtClientFrom.Text.Trim + " To " + Me.txtClientTo.Text.Trim + ") "
        End If
        If Me.CBName.Checked Then
            lstrSQL += " and  UPPER(clt_name) like '%" + Me.txtName.Text.Trim + "%' "
            lstrTitle += "  Name = " + Me.txtName.Text.Trim
        End If
        If Me.CBOSDay.Checked Then
            lstrSQL += " and  liq.liq_day >= " + Str(CDec(Me.AmtOSDay.Text))
            lstrTitle += "   OS day >= " + Str(CDec(Me.AmtOSDay.Text))
        End If
        If Me.CBType.Checked Then
            If Me.RBTypeMargin.Checked Then
                lstrSQL += " and  clt_type = 'M' "
                lstrTitle += "  (Margin Only)"
            Else
                lstrSQL += " and  clt_type = 'C' "
                lstrTitle += "  (Cash Only)"
            End If
        Else
            lstrSQL += " and  clt_type in ('M', 'C') "
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lsubShowProcessing(True)
        lsubEnableForm(False)
        Application.DoEvents()

        rpt = cls.lFncPrintAccFBLst(lstrSQL, lstrTitle)
        frm.GSubDisplayRpt(rpt)

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
        lsubEnableForm(True)


    End Sub

    Private Sub MyButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton2.Click
        Dim strFiles() As String
        Dim ldtwDetailData As DataRow
        Dim ldtsDetailData As DataSet
        Dim lsWriter As StreamWriter
        Dim lstrColValue As String
        If GSubShowYNConfirm(GFncGetSysMsg(27) & " To c:\itas\liquidation_FBlist.csv") _
                = Windows.Forms.DialogResult.Yes Then

            Try

                strFiles = System.IO.Directory.GetFiles("c:\itas\", "liquidation_FBlist.csv")
                For Each strFile As String In strFiles
                    Application.DoEvents()
                    System.IO.File.Delete(strFile)
                Next

                lsWriter = New StreamWriter("c:\itas\liquidation_FBlist.csv")
                lstrColValue = " AE, Client, dr_bal, mkt_val, mc_act_ratio, " & _
                            " margin_ratio, mc_due, undue, mc_total, os_day, net_trade, cr_limit, Client_Name "
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()
                If Me.RBMargin.Checked Then
                    ldtsDetailData = cls.lFncGetFBDetailData("M")
                ElseIf Me.RBCash.Checked Then
                    ldtsDetailData = cls.lFncGetFBDetailData("C")
                ElseIf Me.RBFinance.Checked Then
                    ldtsDetailData = cls.lFncGetFBDetailData("F")
                Else
                    ldtsDetailData = cls.lFncGetFBDetailData("")
                End If
                For Each ldtwDetailData In ldtsDetailData.Tables(0).Rows
                    lstrColValue = "=""" & ldtwDetailData("run_code") & """" & ","
                    lstrColValue += "=""" & ldtwDetailData("clt_code") & """" & ","
                    lstrColValue += ldtwDetailData("mc_dr_bal") & ","
                    lstrColValue += ldtwDetailData("mkt_value") & ","
                    lstrColValue += ldtwDetailData("mc_act_ratio") & ","
                    lstrColValue += ldtwDetailData("margin_ratio") & ","
                    lstrColValue += ldtwDetailData("mc_due") & ","
                    lstrColValue += ldtwDetailData("mc_t2") & ","
                    lstrColValue += ldtwDetailData("mc_total") & ","
                    lstrColValue += ldtwDetailData("os_day") & ","
                    lstrColValue += ldtwDetailData("net_trade") & ","
                    lstrColValue += ldtwDetailData("cr_limit") & ","
                    lstrColValue += "=""" & Replace(ldtwDetailData("clt_name"), ",", ";") & """"
                    lsWriter.WriteLine(lstrColValue)
                    lsWriter.Flush()
                Next
                lsWriter.Close()
                GSubShowInfo(GFncGetSysMsg(28))

            Catch ex As Exception
                GSubWriteErrLog(ex.Message)
                GSubShowInfo(GFncGetSysMsg(29))
            End Try
        End If
    End Sub

    Private Sub MyButton3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton3.Click
        Dim lstrQuery As String = ""
        Dim ldtaDetail As DataRow()
        Dim lintCnt As Integer

        If Me.txtClientCode.Text.Trim <> "" And Me.txtClientCode.Text.Trim <> "00000000" Then
            lstrQuery = " clt_code = '" & Me.txtClientCode.Text.Trim & "' "
            If Me.txtClientName.Text.Trim <> "" Then
                lstrQuery += " and clt_name like '%" & Me.txtClientName.Text.Trim & "%' "
            End If
        ElseIf Me.txtClientName.Text.Trim <> "" Then
            lstrQuery += " clt_name like '%" & Me.txtClientName.Text.Trim & "%' "
        End If

        If lstrQuery.Trim = "" Then
            Me.txtClientCode.Focus()
            Return
        End If

        ldtaDetail = ldtsDetail.Tables(0).Select(lstrQuery)
        If ldtaDetail.Length > 0 Then
            Me.TabControl1.SelectTab(0)
            Me.DtgDetail.Focus()
            For lintCnt = 0 To Me.DtgDetail.Rows.Count - 1
                If Me.DtgDetail.Rows(lintCnt).Cells("client").Value = ldtaDetail(0).Item("clt_code") Then
                    Me.DtgDetail.Rows(lintCnt).Cells("client").Selected = True
                    Exit For
                End If
            Next
        Else
            GSubShowInfo(GFncGetSysMsg(86))
            Me.txtClientCode.Focus()
        End If


    End Sub


    Private Sub txtClientCode_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles txtClientCode.Validating
        Dim lint As Integer
        lint = Val(Replace(Me.txtClientCode.Text.Trim, " ", ""))
        Me.txtClientCode.Text = Format(lint, "00000000")
    End Sub

End Class
