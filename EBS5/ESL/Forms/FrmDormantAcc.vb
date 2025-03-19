Public Class FrmDormantAcc

    Dim cls As New ClsExportClient

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        If (cls.lFncGetDormantClient(Me.dpFrom.Value) = True) Then
            GSubShowInfo(GFncGetSysMsg(28))
        End If

    End Sub

End Class
