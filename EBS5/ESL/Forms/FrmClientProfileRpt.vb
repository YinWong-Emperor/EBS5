Public Class FrmClientProfileRpt

    Dim cls As New ClsClientProfileRpt
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnView.Click

        Dim condition As Integer
        Dim client_type As Integer

        If (Me.rbactualbigger.Checked = True) Then
            condition = 1
        Else
            condition = 2
        End If

        If (Me.rbindividual.Checked = True) Then
            client_type = 1
        ElseIf (Me.rbcorporate.Checked = True) Then
            client_type = 2
        Else
            client_type = 3
        End If

        rpt = cls.lFncView(Me.dpfrom.Value, Me.dpto.Value, condition, client_type)
        frm.GSubDisplayRpt(rpt)

    End Sub

End Class
