Public Class FrmAccIntCls

    Dim cls As New ClsAccIntCls
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnNoAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNoAcc.Click

        rpt = cls.lFncNoAcc()
        frm.GSubDisplayRpt(rpt)

    End Sub

    Private Sub btnAccDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccDetail.Click

        rpt = cls.lFncAccDetail()
        frm.GSubDisplayRpt(rpt)

    End Sub

    Private Sub btnAccDetailEpt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccDetailEpt.Click

        Dim strExFile As String = "ClientList_Int_Class_" & Format(Date.Now, "yyyyMMddHHmmss") & ".csv"

        If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncAccDetailEpt(strExFile) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If

    End Sub

End Class
