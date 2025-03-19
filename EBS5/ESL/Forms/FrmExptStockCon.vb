Public Class FrmExptStockCon

    Dim cls As New ClsExptStockCon
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnExptStockCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExptStockCon.Click

        Dim strExFile As String = "stock_concentration_" + Format(Me.dpStock.Value, "yyyyMMdd") + ".csv"

        If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncExptStockCon(Me.dpStock.Value, strExFile) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub FrmExptStockCon_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dpStock.Value = GDteTradeDate

    End Sub

End Class
