Public Class FrmRptFuturesStatementAdj

    Dim gRpt As CrystalDecisions.CrystalReports.Engine.ReportClass = New rptFuturesStatementAdj
    Private gCls As New clsRptFuturesStatementAdj
    Dim gClsRpt As New ClsReports
    Private gFrm As New FrmRptDisplay

    Private Sub FrmRptFuturesStatementAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpTdate.Value = GDteTradeDate
        Me.cbxCounterParty.DataSource = gCls.GetCounterParty(True)
        Me.cbxCounterParty.ValueMember = "misc_desc"

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        gRpt.ReportClientDocument.LocaleID = CrystalDecisions.ReportAppServer.DataDefModel.CeLocale.ceLocaleEnglishUK

        Dim clsRpt As New ClsReports
        Dim dt_cp As DataTable = gCls.GenCPAdjReport(Me.dtpTdate.Value, Me.cbxCounterParty.Text)
        Dim dt_op As DataTable = gCls.GenOPAdjReport(Me.dtpTdate.Value, Me.cbxCounterParty.Text)
        Dim dt_th As DataTable = gCls.GenTHAdjReport(Me.dtpTdate.Value, Me.cbxCounterParty.Text)

        'gRpt.SetDataSource(gCls.GenCPAdjReport(Me.dtpTdate.Value, Me.cbxCounterParty.Text))
        gRpt.Subreports(0).SetDataSource(dt_cp)
        gRpt.Subreports(1).SetDataSource(dt_op)
        gRpt.Subreports(2).SetDataSource(dt_th)

        clsRpt.AddParam(gRpt, "paraPrintUser", Trim(GStrloginID))
        clsRpt.AddParam(gRpt, "paraTDate", Me.dtpTdate.Value)
        clsRpt.AddParam(gRpt, "paraCounterParty", Trim(Me.cbxCounterParty.Text))

        gFrm.GSubDisplayRpt(gRpt)

    End Sub
End Class
