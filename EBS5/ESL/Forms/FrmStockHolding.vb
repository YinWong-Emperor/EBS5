Public Class FrmStockHolding

    Dim cls As New clsStockHolding

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim withDebit As Boolean = False

        If (Me.rbMargin.Checked) Then
            withDebit = False
        Else
            withDebit = True
        End If

        If cls.lFncExptStockHoldings(withDebit) Then
            GSubShowInfo(GFncGetSysMsg(28))
        End If

    End Sub

End Class
