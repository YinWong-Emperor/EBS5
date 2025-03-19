Public Class FrmCustDelConfirm

    Protected Friend gMessage As String = ""
    Protected Friend gRemark As String = ""

    Private Sub FrmCustDelConfirm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtRemark.MaxLength = 1000
        Me.lblMsg.Text = gMessage
    End Sub

    Private Sub btnYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnYes.Click
        gMessage = ""
        gRemark = Me.txtRemark.Text.Trim
        Me.DialogResult = Windows.Forms.DialogResult.Yes
        Me.Close()
    End Sub

    Private Sub btnNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNo.Click
        gMessage = ""
        gRemark = ""
        Me.DialogResult = Windows.Forms.DialogResult.No
        Me.Close()
    End Sub
End Class