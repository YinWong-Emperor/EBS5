Public Class FrmDailyNetTrade

    Dim cls As New ClsDailyNetTrade
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnAccOverLmt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccOverLmt.Click

        rpt = cls.lFncAccOverLmt(Me.dpAcc.Value)
        frm.GSubDisplayRpt(rpt)

    End Sub

    Private Sub FrmDailyNetTrade_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dpAcc.Value = GDteTradeDate

    End Sub

End Class
