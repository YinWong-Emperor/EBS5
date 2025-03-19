Public Class FrmActiveAccount

    Dim cls As New ClsActiveAccount
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click

        Dim strExFile As String = "Actvite" & Format(Me.dpFrom.Value, "yyyyMMdd") & "-" & Format(Me.dpTo.Value, "yyyyMMdd") & ".csv"


        If (Me.dpFrom.Value > Me.dpTo.Value) Then
            'GSubShowInfo(GFncGetSysMsg(16))
            Return
        End If

        If (cls.lFncPrintActAcc(Me.dpFrom.Value, Me.dpTo.Value, strExFile) = True) Then
            GSubShowInfo(GFncGetSysMsg(28))
        Else
            GSubShowInfo(GFncGetSysMsg(29))
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

End Class
