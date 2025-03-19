Imports System.Data.SqlClient

Public Class FrmChgPwd

    Dim ClsUM As New ClsUserMnt
    Dim ClsLogin As New clsLogin

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        If ClsUM.IsOldPassOK(GStrloginID, TxtOldPass.Text) = False Then
            GSubShowInfo(GFncGetSysMsg(21))
        Else
            If TxtNewPass.Text <> TxtConfirmPass.Text Then
                GSubShowInfo(GFncGetSysMsg(23))
            Else
                If ClsLogin.GFncChkPwdRepeat(GStrloginID, TxtNewPass.Text) = True Then
                    GSubShowInfo(GFncGetSysMsg(26))
                Else
                    Dim MyTrans As SqlTransaction
                    MyTrans = GSCnSqlConn.BeginTransaction
                    Try
                        If GFncRunSQL(GSCnSqlConn, MyTrans, "Update User_Information set UiPassword = '" & GFncGetMd5Hash(TxtNewPass.Text) & "', uimodifydt = getdate(), uimodifyuser = '" & GStrloginID & "' where uiuserid = '" & GStrloginID & "'") > 0 Then 'And _
                            'GFncRunSQL(GSCnSqlConn, MyTrans, "Insert into password_history values ('" & GStrloginID & "',getdate(), '" & GFncGetMd5Hash(TxtNewPass.Text) & "','" & GStrloginID & "', getdate())") > 0 Then
                            MyTrans.Commit()
                            TxtNewPass.Text = ""
                            TxtConfirmPass.Text = ""
                            TxtOldPass.Text = ""
                        Else
                            MyTrans.Rollback()
                        End If
                    Catch ex As Exception
                        If GSCnSqlConn.State <> ConnectionState.Closed Then
                            MyTrans.Rollback()
                            GSubWriteErrLog(ex.Message)
                        End If
                    End Try
                End If
            End If
        End If

    End Sub

    Private Sub FrmChgPwd_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub
End Class
