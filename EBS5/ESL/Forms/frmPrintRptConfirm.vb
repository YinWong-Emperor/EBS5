Imports CrystalDecisions.Shared

Public Class frmPrintRptConfirm

    Dim lstrRptID As String = ""
    Dim cls As New ClsReports
    Dim ds As DataSet
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Public Sub GSubShowPrintConfirm(ByVal strRptID As String, ByVal strMsg As String)
        lstrRptID = strRptID
        lblQuestion.Text = strMsg
        btnClose.Focus()

        Me.ShowDialog()
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        Dim strFileName As String = ""
        Dim strFilePath As String = ""
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim lstrSQL As String = ""
        Dim ldtsRptName As DataSet
        Dim ldtwRptName As DataRow()

        If radFile.Checked = True Then
            'If txtFilePath.Text.Trim = "" Then
            '    GSubShowWarn(GFncGetSysMsg(101))
            '    txtFilePath.Focus()
            '    Exit Sub
            'Else
            '    Try
            '        strFilePath = System.IO.Path.GetDirectoryName(txtFilePath.Text.Trim)
            '        strFileName = System.IO.Path.GetFileNameWithoutExtension(txtFilePath.Text.Trim)
            '        If strFilePath = "" Or strFileName = "" Then
            '            GSubShowWarn(GFncGetSysMsg(102))
            '            txtFilePath.Focus()
            '            Exit Sub
            '        ElseIf Not GFncChkValidFileName(strFileName) Then
            '            GSubShowWarn(GFncGetSysMsg(102))
            '            txtFilePath.Focus()
            '            Exit Sub
            '        End If
            '    Catch ex As Exception
            '        GSubShowWarn(GFncGetSysMsg(102))
            '        txtFilePath.Focus()
            '        Exit Sub
            '    End Try
            'End If

        ElseIf radPrinter.Checked = True Then
            'printDlg.AllowSomePages = True
            If printDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = printDlg.PrinterSettings.PrinterName
                shtCopies = printDlg.PrinterSettings.Copies
                If printDlg.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = printDlg.PrinterSettings.FromPage
                    intToPage = printDlg.PrinterSettings.ToPage
                End If
            Else
                Exit Sub
            End If
        End If

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lsubShowProcessing(True)
        lsubEnableForm(False)
        Application.DoEvents()

        lstrSQL = "Select * from report_master"
        ldtsRptName = GFncRtnDS(GSCnSqlConn, lstrSQL)

        '20071123 moved to clsreport class
        'Select Case UCase(lstrRptID)
        '    Case "EXEOPEN"
        '        rpt = cls.Executed_Open_Order_Rpt()
        '    Case "EXELIQ"
        '        rpt = cls.Executed_Liq_Order_Rpt()
        '    Case "MARGINIO"
        '        rpt = cls.MARGIN_IO_REPORT()
        '    Case "ACGOLDPOS"
        '        rpt = cls.ACCOUNT_GOLD_POS_REPORT()
        '    Case "MARCALL"
        '        rpt = cls.MARGIN_CALL_REPORT()
        '    Case "MARCALL_EM"
        '        rpt = cls.MARGIN_CALL_REPORT(False, Nothing, True)
        '    Case "OPENDETAIL"
        '        rpt = cls.Executed_Open_Position_Rpt("DETAIL")
        '    Case "OPENTABLE"
        '        rpt = cls.Executed_Open_Position_Rpt("TABLE")
        '    Case "OPENALL"
        '        rpt = cls.Executed_Open_Position_Rpt("ALL")
        '    Case "ACCONSOL"
        '        rpt = cls.CONSOL()
        '    Case "LIQPOS"
        '        rpt = cls.Executed_Liq_Position_Rpt()
        '    Case "GENERAL"
        '        rpt = cls.GENERAL()
        '    Case "ADJUST"
        '        rpt = cls.PR_AC_ADJUSTMENT()
        '    Case "ACCUM"
        '        rpt = cls.PR_AC_ACCUMULATION()
        '    Case "TITLE"
        '        rpt = cls.PR_TITLE()
        '    Case "OVERLOSS"
        '        rpt = cls.OVER_LOSS_REPORT()
        '    Case "CUTLOSS"
        '        rpt = cls.Executed_Cutloss_Order_Rpt()
        '    Case "CLMARGINCALL"
        '        rpt = cls.GFncPrintCLMarginCall()
        '    Case "UPFRONT"
        '        rpt = clsuf.Executed_UpFront_rpt()
        '    Case "LOGORDER"
        '        rpt = cls.GFncGetOrderLog(g_tdate)
        'End Select
        rpt = cls.GFncGetReport(lstrRptID)
        '20071123 end

        ldtwRptName = ldtsRptName.Tables(0).Select("report_id = '" & lstrRptID & "'")
        If rpt Is Nothing Then
            If ldtwRptName.Length > 0 Then
                rpt = cls.lfncRtnEmptyRpt(ldtwRptName(0).Item("report_name"))
            Else
                rpt = cls.lfncRtnEmptyRpt("")
            End If
        End If

        If radPreview.Checked = True Then
            Me.Hide()
            frm.GSubDisplayRpt(rpt)
        ElseIf radPrinter.Checked = True Then
            If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
                lsubShowProcessing(False)
                GSubShowInfo(GFncGetSysMsg(104))
            End If
        ElseIf radFile.Checked = True Then
            strFilePath = GStrRptExpPath & Format(GDteTradeDate, "yyyyMMdd") & "\"
            If ldtwRptName.Length > 0 Then
                strFileName = GFncReplaceFileName(ldtwRptName(0).Item("report_name"), "_")
            Else
                strFileName = "dummy"
            End If

            If GFncExportRpt(rpt, strFilePath, strFileName) Then
                lsubShowProcessing(False)
                GSubShowInfo(GFncGetSysMsg(103))
            End If
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        Me.Close()

    End Sub

    Private Sub frmPrintRptConfirm_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub frmPrintRptConfirm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lsubShowProcessing(False)
        lsubEnableForm(True)
        radPreview.Checked = True
        radPreview.Focus()
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        btnOK.Visible = bEnable
        btnClose.Visible = bEnable
        radPreview.Enabled = bEnable
        radPrinter.Enabled = bEnable
        radFile.Enabled = bEnable
        'btnFile.Enabled = bEnable
        'txtFilePath.Enabled = False
    End Sub

    Private Sub radioBtn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radPreview.CheckedChanged, radPrinter.CheckedChanged
        'If radPreview.Checked = True Or radPrinter.Checked = True Then
        '    txtFilePath.Text = ""
        '    btnFile.Enabled = False
        'End If
    End Sub

    Private Sub radFile_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles radFile.CheckedChanged
        'If radFile.Checked = True Then
        '    btnFile.Enabled = True
        'End If
    End Sub

    Private Sub btnFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFile.Click
        saveDlg.Filter = "Portable Document Format (*.pdf)|*.pdf"
        saveDlg.DefaultExt = "pdf"
        saveDlg.Title = "Save report to file..."
        saveDlg.OverwritePrompt = True
        saveDlg.CheckPathExists = True
        saveDlg.ValidateNames = True
        If saveDlg.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtFilePath.Text = saveDlg.FileName
        End If
    End Sub

    Private Sub radPreview_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles radPreview.KeyDown
        GSubMoveNextFld(e.KeyCode)
    End Sub

    Private Sub radPrinter_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles radPrinter.KeyDown
        GSubMoveNextFld(e.KeyCode)
    End Sub

    Private Sub radFile_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles radFile.KeyDown
        GSubMoveNextFld(e.KeyCode)
    End Sub
End Class
