Imports CrystalDecisions.CrystalReports.Engine
Public Class FrmCmmLog

    Dim cls As New clsCommLog
    Dim frm As New FrmRptDisplay

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmCmmLog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lsubEnableProcess(False)
        Me.cmbType.DataSource = cls.FncGetType
        Me.cmbType.DisplayMember = "misc_desc"
        Me.cmbUser.DataSource = cls.FncGetUser
        Me.cmbUser.DisplayMember = "uiUserID"
    End Sub

    Private Sub lsubEnableProcess(ByVal bEnable As Boolean)
        lblProcess.Visible = bEnable
        pbarProcess.Visible = bEnable
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lstrPrinterName As String = ""
        Dim lstrPath As String = ""
        Dim lshrCopies As Short = 1

        Dim rpt As ReportClass = Nothing

        If Me.rbPrinter.Checked = True Then
            If PrintDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                lstrPrinterName = PrintDialog1.PrinterSettings.PrinterName
                lshrCopies = PrintDialog1.PrinterSettings.Copies
            Else
                Exit Sub
            End If
        End If

        lsubEnableProcess(True)
        Application.DoEvents()
        Dim dt As DataTable = Me.cmbType.DataSource
        Dim dr() As DataRow = dt.Select("misc_desc = '" & Me.cmbType.Text.Trim & "'")
        Dim type As String = GFncNoNullString(dr(0).Item("misc_code")).Trim
        rpt = cls.FncGenReport(Format(Me.dtpStart.Value, "yyyy/MM/dd 00:00:00"), Format(Me.dtpEnd.Value, "yyyy/MM/dd 23:59:59"), type, Me.cmbUser.Text.Trim)
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

    End Sub
End Class
