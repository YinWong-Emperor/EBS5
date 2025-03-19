Public Class FrmRunnerTaxableIncomeMasterFindRecord

    '----------Members----------

    Public Delegate Function FoundAction(code As String, name As String) As Integer
    Dim FoundTargetRowAction As FoundAction


    '----------Control----------

#Region "初始化"
    Friend Sub SetFoundAction(ByRef FoundAction As FoundAction)
        Me.FoundTargetRowAction = FoundAction
    End Sub
#End Region


#Region "查找"
    Sub Search()
        If Me.FoundTargetRowAction Is Nothing Then
            Return
        End If

        Dim ret As Integer = Me.FoundTargetRowAction(Me.txtCode.Text.Trim(), Me.txtName.Text.Trim())
        If ret < 0 Then
            GSubShowInfo(GFncGetSysMsg(24))
        Else
            Me.Close()
        End If
    End Sub

#End Region

    '----------------------------

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnFind_Click(sender As Object, e As EventArgs) Handles btnFind.Click
        Search()
    End Sub

End Class
