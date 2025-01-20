Public Class FrmAccStat

    Dim cls As New ClsAccStat
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub


    Private Sub btnActAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActAcc.Click

        If Me.RBStock.Checked = True Then
            rpt = cls.lFncActAccS(Me.nudMth.Value, Me.nudday.Value)
            frm.GSubDisplayRpt(rpt)
        Else
            rpt = cls.lFncActAccF(Me.nudMth.Value, Me.nudday.Value)
            frm.GSubDisplayRpt(rpt)
        End If

    End Sub

    Private Sub btnNActAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNActAcc.Click

        If Me.RBStock.Checked = True Then
            rpt = cls.lFncNActAccS(Me.nudMth.Value, Me.nudday.Value)
            frm.GSubDisplayRpt(rpt)
        Else
            rpt = cls.lFncNActAccF(Me.nudMth.Value, Me.nudday.Value)
            frm.GSubDisplayRpt(rpt)
        End If

    End Sub

    Private Sub btnTtlAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTtlAcc.Click

        If Me.RBStock.Checked = True Then
            rpt = cls.lFncTotalS()
            frm.GSubDisplayRpt(rpt)
        Else
            rpt = cls.lFncTotalF()
            frm.GSubDisplayRpt(rpt)
        End If

    End Sub

    Private Sub btnNewAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewAcc.Click

        If Me.RBStock.Checked = True Then
            rpt = cls.lFncNewAccS(Me.dpFrom.Value, Me.dpTo.Value)
            frm.GSubDisplayRpt(rpt)
        Else
            rpt = cls.lFncNewAccF(Me.dpFrom.Value, Me.dpTo.Value)
            frm.GSubDisplayRpt(rpt)
        End If

    End Sub

    Private Sub FrmAccStat_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GStrDisableSecuritiesButton = "Y" Then
            RBFutures.Select()
            RBStock.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

    End Sub
End Class
