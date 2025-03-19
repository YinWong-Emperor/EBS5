Public Class frmRptOPChecking

    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim cls As New clsOPChecking

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.cbxCounterParty.Text = Me.cbxCounterParty2.Text Then
            MessageBox.Show("2 Counter Party cannot be the same")
            Exit Sub
        End If

        lsubShowProcessing(True)
        Application.DoEvents()
        rpt = cls.FncGenReport(me.dtpTrade.Text, me.cbxCounterParty.Text, me.cbxCounterParty2.Text)
        frm.GSubDisplayRpt(rpt)
        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub


    Private Sub frmRptOPChecking_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpTrade.Text = Format(GDteTradeDate, "yyyy/MM/dd")
        Dim clsFR As New clsFuturesReport
        Me.cbxCounterParty.DataSource = clsFR.GetCounterParty
        Me.cbxCounterParty.ValueMember = "misc_desc"
        Me.cbxCounterParty2.DataSource = clsFR.GetCounterParty
        Me.cbxCounterParty2.ValueMember = "misc_desc"
        lsubShowProcessing(False)
    End Sub
End Class
