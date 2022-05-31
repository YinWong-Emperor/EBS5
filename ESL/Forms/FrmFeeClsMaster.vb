Public Class FrmFeeClsMaster
    Dim cls As New ClsFeeClsMaster

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim dbName As String = "G2BF_UAT." & Me.txtDB.Text & ".dbo."

        If (Me.rbProd.Checked) Then
            dbName = "G2BF_RET." & Me.txtDB.Text & ".dbo."
        End If

        cls.lFncGenFeeCls(dbName)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

 
End Class
