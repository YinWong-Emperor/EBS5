Public Class frmBaseSrh

    Private Sub btnClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub frmBaseSrh_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        GSubSetControlMoveNext(Me)
        GSubSetTextBoxGotFocus(Me)
        Me.KeyPreview = True
    End Sub
End Class