Imports CrystalDecisions.Shared

Public Class FrmRptAccLst

    Dim cls As New ClsRptAccLst
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

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
        Me.RBCash.Enabled = bEnable
        Me.RBAll.Enabled = bEnable
        Me.RBMargin.Enabled = bEnable
        Me.CboFrm.Enabled = bEnable
        Me.CboTo.Enabled = bEnable

    End Sub

    Private Sub FrmRptAccLst_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmRptAccLst_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ldtsRunner As DataSet
        Dim ldtwRunner As DataRow

        ldtsRunner = cls.lFncGetRunner()
        Me.CboTo.Items.Add("")
        Me.CboFrm.Items.Add("")
        For Each ldtwRunner In ldtsRunner.Tables(0).Rows
            Me.CboFrm.Items.Add(ldtwRunner("run_code"))
            Me.CboTo.Items.Add(ldtwRunner("run_code"))
        Next
        lsubEnableForm(True)
        lsubShowProcessing(False)
        Me.RBPreview.Checked = True
        Me.RBMargin.Checked = True

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Dim lstrType As String = ""
        Dim lstrTitle As String = "ALL"
        Dim isEmpty As Boolean = False

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

        If Me.RBMargin.Checked Then
            lstrType = "MARGIN"
        End If
        If Me.RBCash.Checked Then
            lstrType = "CASH"
        End If

        If Me.radAll.Checked Then
            Me.CboFrm.Text = ""
            Me.CboTo.Text = ""
        End If

        rpt = cls.lFncPrintAccLst(Me.CboFrm.Text.Trim, Me.CboTo.Text.Trim, lstrType, isEmpty)

        If isEmpty Then
            GSubShowWarn("No Record!")
            Windows.Forms.Cursor.Current = Cursors.Default
            lsubShowProcessing(False)
            lsubEnableForm(True)
            Exit Sub
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
        lsubEnableForm(True)

    End Sub
End Class
