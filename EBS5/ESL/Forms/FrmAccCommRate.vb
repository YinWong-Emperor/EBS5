Public Class FrmAccCommRate

    Dim cls As New ClsAccCommRate
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnNoAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoAcc.Click

        rpt = cls.lFncNoAcc()
        frm.GSubDisplayRpt(rpt)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnAccDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccDetail.Click

        rpt = cls.lFncAccDetails()
        frm.GSubDisplayRpt(rpt)

    End Sub
End Class
