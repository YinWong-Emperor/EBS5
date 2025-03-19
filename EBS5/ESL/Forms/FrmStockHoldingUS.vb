Public Class FrmStockHoldingUS

    Dim cls As New ClsStockHoldingUS

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

    Private Sub FrmStockHoldingUS_Load(sender As Object, e As EventArgs) Handles Me.Load
        If GFncGetTDateUS() <> GFncGetTDate() Then
            MsgBox("US data (" & Format(GFncGetTDate, "dd/MM/yyyy") & ") not yet imported.")
        End If
    End Sub
End Class
