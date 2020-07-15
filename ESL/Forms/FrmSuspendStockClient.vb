Public Class FrmSuspendStockClient

    Dim cls As New ClsSuspendStockClient
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        Dim tradeDate As Date
        tradeDate = GDteTradeDate
        rpt = cls.lFncSuspendStockClient(
                    tradeDate,
                    Trim(Me.txtStockFrom.Text),
                    Trim(Me.txtStockTo.Text),
                    Trim(Me.txtClientFrom.Text),
                    Trim(Me.txtClientTo.Text))
        frm.GSubDisplayRpt(rpt)

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

End Class
