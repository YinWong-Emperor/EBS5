Public Class frmRptCCT

    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim cls As New clsRptCCT

    Private Sub DTPStart_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPStart.ValueChanged
        If Me.DTPStart.Value > Me.DTPEnd.Value Then
            Me.DTPStart.Value = CDate(DateAdd("yyyy", -1, CDate(GFncNoNullString(Me.DTPEnd.Value))))
        End If
    End Sub

    Private Sub DTPEnd_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DTPEnd.ValueChanged
        If Me.DTPEnd.Value < Me.DTPStart.Value Then
            Me.DTPStart.Value = CDate(DateAdd("yyyy", -1, CDate(GFncNoNullString(Me.DTPEnd.Value))))
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        lsubShowProcessing(True)
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        If Me.rbtPrint.Checked = True Then
            If PrintDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDialog1.PrinterSettings.PrinterName
                shtCopies = PrintDialog1.PrinterSettings.Copies
                If PrintDialog1.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDialog1.PrinterSettings.FromPage
                    intToPage = PrintDialog1.PrinterSettings.ToPage
                End If
            Else
                Exit Sub
            End If
        End If
        If Me.DTPStart.Value > Me.DTPEnd.Value Then
            MessageBox.Show("Start date can not be greater than End date", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        rpt = cls.FncGenRpt(Me.DTPStart.Value, Me.DTPEnd.Value)

        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If
        lsubShowProcessing(False)
    End Sub

    Private Sub frmRptCCT_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lsubShowProcessing(False)
    End Sub
End Class
