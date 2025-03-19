Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class FrmRptLog

    Dim cls As New ClsRptLog
    Dim frm As New FrmRptDisplay
    Dim log_type As DataTable

    Private Sub FrmRptLog_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        log_type = cls.gFncGetType().Tables(0)
        Me.cboLogType.DataSource = log_type
        Me.cboLogType.DisplayMember = "misc_desc"
        Me.cboLogType.SelectedIndex = 0

        lblProcess.Visible = False
        pbarProcess.Visible = False
        Me.MyDateTimePicker1.Value = Microsoft.VisualBasic.DateAndTime.Now
        Me.MyDateTimePicker2.Value = Microsoft.VisualBasic.DateAndTime.Now

        MyDateTimePicker1.Focus()

        Me.rbPreview.Checked = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim lstrPrinterName As String = ""
        Dim lstrPath As String = ""
        Dim lshrCopies As Short = 1

        Dim rpt As ReportClass = Nothing

        If Me.rbPrinter.Checked = True Then
            If printDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                lstrPrinterName = printDlg.PrinterSettings.PrinterName
                lshrCopies = printDlg.PrinterSettings.Copies
            Else
                Exit Sub
            End If
        End If

        lsubEnableProcess(True)
        lsubEnableForm(False)
        Application.DoEvents()

        Dim dr() As DataRow = log_type.Select("misc_desc = '" & Me.cboLogType.Text & "' ")
        rpt = cls.Executed_Rpt("", Me.MyDateTimePicker1.Value, Me.MyDateTimePicker2.Value, Me.txtAccNo.Text, dr(0))

        If Me.rbPreview.Checked = True Then
            lsubEnableProcess(False)
            frm.GSubDisplayRpt(rpt)
        ElseIf Me.rbPrinter.Checked = True Then
            If GFncPrintRpt(rpt, lstrPrinterName, lshrCopies) Then
                lsubEnableProcess(False)
                GSubShowInfo(GFncGetSysMsg(104))
            End If
        End If

        lsubEnableProcess(False)
        lsubEnableForm(True)

    End Sub

    Private Sub lsubEnableProcess(ByVal bEnable As Boolean)
        lblProcess.Visible = bEnable
        pbarProcess.Visible = bEnable
    End Sub

    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        MyDateTimePicker1.Enabled = bEnable
        MyDateTimePicker2.Enabled = bEnable

        Me.rbPreview.Enabled = bEnable
        Me.rbPrinter.Enabled = bEnable
        Me.btnPrint.Visible = bEnable
        Me.btnCancel.Visible = bEnable
    End Sub

End Class
