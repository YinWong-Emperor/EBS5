Imports System.Data.SqlClient

Public Class FrmUserMain

    Dim ClsUM As New ClsUserMnt
    Dim ClsLogin As New clsLogin
    Dim lstrStatus As String = ""

    Private Sub FrmUserMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        GBlnFormOpen = False

    End Sub

    Private Sub RdbUserInfo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbUserInfo.CheckedChanged

        If RdbUserInfo.Checked = True Then
            RdbPass.Checked = False
            GBxUserMain.Enabled = True
            GBxPassword.Enabled = False
        Else
            RdbUserInfo.Checked = False
            GBxUserMain.Enabled = False
            GBxPassword.Enabled = True
        End If

    End Sub

    Private Sub RdbPass_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdbPass.CheckedChanged

        If RdbUserInfo.Checked = True Then
            RdbPass.Checked = False
            GBxUserMain.Enabled = True
            GBxPassword.Enabled = False
        Else
            RdbUserInfo.Checked = False
            GBxUserMain.Enabled = False
            GBxPassword.Enabled = True
        End If

        If ClsUM.GFncUserType(GStrloginID) = "User" Then
            TxtOldPass.Enabled = True
        Else
            TxtOldPass.Enabled = False
        End If

    End Sub

    Private Sub FrmUserMain_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress

        If lstrStatus = "Menu" Then
            If e.KeyChar = ChrW(Keys.Escape) Then
                Call btnCancel_Click("", System.EventArgs.Empty)
            End If
        Else
            e.Handled = True
            Select Case e.KeyChar
                Case ChrW(Keys.NumPad1), ChrW(Keys.D1)
                    Call NewToolStripMenuItem_Click("", System.EventArgs.Empty)
                Case ChrW(Keys.NumPad2), ChrW(Keys.D2)
                    Call ModifyStripMenuItem_Click("", System.EventArgs.Empty)
                Case ChrW(Keys.NumPad3), ChrW(Keys.D3)
                    Call DeleteToolStripMenuItem_Click("", System.EventArgs.Empty)
                Case ChrW(Keys.NumPad4), ChrW(Keys.D4)
                    Call PasswordToolStripMenuItem_Click("", System.EventArgs.Empty)
                Case ChrW(Keys.NumPad5), ChrW(Keys.D5), ChrW(Keys.Escape)
                    Me.Close()
            End Select
        End If

    End Sub

    Private Sub FrmUserMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ldtsUser As DataSet
        Dim ldtwUser As DataRow
        
        ldtsUser = modCommon.GFncRtnDS(GSCnSqlConn, "Select UiUserId from USer_information order by UiUserID")
        CboUserID.Items.Clear()

        For Each ldtwUser In ldtsUser.Tables(0).Rows
            CboUserID.Items.Add(ldtwUser.Item("UiUserId"))
        Next

        ldtsUser.Dispose()

        TxtLastName.Enabled = False
        TxtFirstName.Enabled = False
        TxtTitle.Enabled = False

        Me.btnCancel.Enabled = False
        Me.btnSave.Enabled = False
        Me.DTPExpiry.Enabled = False
        Me.RdbPass.Enabled = False
        Me.RdbUserInfo.Enabled = False
        Me.ChkActive.Enabled = False
        Me.ChkChgPwd.Enabled = False

        Me.CboUserID.Focus()

    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click

        Me.Close()

    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click

        lstrStatus = "Menu"
        TxtUserID.Visible = True
        Me.MnuUser.Enabled = False
        Me.CboUserID.Visible = False
        TxtLastName.Enabled = True
        TxtFirstName.Enabled = True
        TxtTitle.Enabled = True
        CboDept.Enabled = True
        CboUserType.Enabled = True
        RdbUserInfo.Enabled = False
        RdbPass.Enabled = False
        GBxPassword.Enabled = True
        TxtOldPass.Enabled = False
        Me.btnSave.Enabled = True
        Me.btnCancel.Enabled = True
        Me.ChkActive.Enabled = True
        Me.ChkChgPwd.Enabled = True

        TxtLastName.Text = ""
        TxtFirstName.Text = ""
        TxtTitle.Text = ""
        TxtUserID.Text = ""
        Me.TxtOldPass.Text = ""
        Me.TxtNewPass.Text = ""

        Me.DTPExpiry.Enabled = True
        DTPExpiry.Value = DateAdd(DateInterval.Day, 30, Now)

        TxtUserID.Focus()


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        lstrStatus = ""
        Me.RdbUserInfo.Checked = True
        Me.RdbPass.Checked = False
        Me.MnuUser.Enabled = True
        Me.GBxPassword.Enabled = False
        Me.GBxUserMain.Enabled = False
        Me.btnCancel.Enabled = False
        Me.btnSave.Enabled = False
        Call ResetForm()

        Me.CboUserID.Focus()

    End Sub

    Private Sub CboUserID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboUserID.SelectedIndexChanged

        Dim ldtsUser As DataSet
        Dim ldtwUser As DataRow
        ldtsUser = modCommon.GFncRtnDS(GSCnSqlConn, "Select * from User_Information where UiUSerid = '" & CboUserID.Text & "'")
        If ldtsUser.Tables(0).Rows.Count > 0 Then
            ldtwUser = ldtsUser.Tables(0).Rows(0)

            TxtLastName.Text = ldtwUser.Item("UiLastName")
            TxtFirstName.Text = ldtwUser.Item("UiFirstName")
            TxtTitle.Text = ldtwUser.Item("UiTitle")
            DTPExpiry.Value = ldtwUser.Item("UiExpire")
            CboUserType.Text = ldtwUser.Item("UiUserType")
            Me.ChkChgPwd.Checked = ldtwUser.Item("UifChgPwd")
            Me.ChkActive.Checked = ldtwUser.Item("Uiactive")
            Me.CboDept.Text = ldtwUser.Item("uideptcode")
        End If


    End Sub

    Private Sub ModifyStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ModifyStripMenuItem.Click

        If Me.CboUserID.Text.Trim = "" Then
            GSubShowInfo(GFncGetSysMsg(86))
            Return
        End If
        lstrStatus = "Menu"

        Me.RdbUserInfo.Checked = True
        MnuUser.Enabled = False
        TxtLastName.Enabled = True
        TxtFirstName.Enabled = True
        TxtTitle.Enabled = True
        TxtUserID.Visible = False
        CboDept.Enabled = True
        CboUserType.Enabled = True
        Me.ChkActive.Enabled = True
        Me.ChkChgPwd.Enabled = True
        Me.DTPExpiry.Enabled = True
        Me.btnSave.Enabled = True
        Me.btnCancel.Enabled = True
        Me.CboUserID.Enabled = False

        Me.DTPExpiry.Focus()

    End Sub

    Private Sub DeleteToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteToolStripMenuItem.Click
        If Me.CboUserID.Text.Trim = "" Then
            GSubShowInfo(GFncGetSysMsg(86))
            Return
        End If
        lstrStatus = "Menu"

        MnuUser.Enabled = False
        TxtLastName.Enabled = False
        TxtFirstName.Enabled = False
        TxtTitle.Enabled = False
        TxtUserID.Visible = False
        CboDept.Enabled = False
        CboUserType.Enabled = False
        Me.CboUserID.Enabled = False
        Me.btnSave.Enabled = False
        Me.btnCancel.Enabled = False

        Me.btnSave_Click("", System.EventArgs.Empty)
        Me.btnCancel_Click("", System.EventArgs.Empty)

    End Sub

    Private Sub ResetForm()


        RdbUserInfo.Checked = True
        RdbPass.Checked = False
        Me.CboUserID.Enabled = True

        GBxUserMain.Enabled = True
        GBxPassword.Enabled = False

        Me.ChkActive.Enabled = False
        Me.ChkChgPwd.Enabled = False

        TxtLastName.Enabled = False
        TxtLastName.Text = ""
        TxtFirstName.Enabled = False
        TxtFirstName.Text = ""
        TxtTitle.Enabled = False
        TxtTitle.Text = ""
        TxtUserID.Visible = False
        Me.DTPExpiry.Enabled = False
        CboUserID.Visible = True
        TxtUserID.Text = ""
        Me.TxtOldPass.Text = ""
        Me.TxtNewPass.Text = ""
        Me.TxtConfirmPass.Text = ""
        Me.CboDept.Text = ""
        Me.CboUserType.Text = ""
        CboDept.Enabled = False
        CboUserType.Enabled = False

        If Me.CboUserID.Text.Trim <> "" Then
            CboUserID_SelectedIndexChanged("", System.EventArgs.Empty)
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lstrSQL As String

        If TxtUserID.Visible = True Then
            If ClsUM.IsUserExist(TxtUserID.Text) = True Then
                GSubShowInfo(GFncGetSysMsg(7))
                Return
            End If
            If TxtNewPass.Text.Length < 6 Then
                GSubShowInfo("Please enter password contains at least 6 characters!")
                Exit Sub
            End If
            If Me.TxtNewPass.Text <> Me.TxtConfirmPass.Text Then
                GSubShowInfo(GFncGetSysMsg(23))
                Return
            End If
            If ClsLogin.GFncChkPwdRepeat(CboUserID.Text, TxtNewPass.Text) = True Then
                GSubShowInfo(GFncGetSysMsg(26))
                Return
            End If
            If GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes Then
                Dim MyTrans As SqlTransaction
                MyTrans = GSCnSqlConn.BeginTransaction
                Try
                    lstrSQL = "Insert into User_Information (uiuserid, uipassword, uilastname, uifirstname, " & _
                            " uideptcode, uititle, uinooftry, uiActive,uiFChgPwd ,uiCreateDt ,uiCreateUser ,uiModifyDt " & _
                            ",uiModifyUser,uiExpire,uiUserType ) values ('" & _
                        TxtUserID.Text & "','" & GFncGetMd5Hash(TxtNewPass.Text) & _
                        "','" & GFncSqlQuote(TxtLastName.Text) & "','" & GFncSqlQuote(TxtFirstName.Text) & _
                        "','" & GFncSqlQuote(CboDept.Text) & "','" & GFncSqlQuote(TxtTitle.Text) & _
                        "',0,1," & IIf(ChkChgPwd.Checked = True, 1, 0) & ",getdate(),'" & GStrloginID & _
                        "',getdate(),'" & GStrloginID & "','" & Format(DTPExpiry.Value, "MM/dd/yyyy") & _
                        "','" & CboUserType.Text & "')"

                    If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL) > 0 Then
                        MyTrans.Commit()
                        GSubShowInfo(GFncGetSysMsg(8))
                        Call FrmUserMain_Load("", System.EventArgs.Empty)
                        Me.CboUserID.Text = Me.TxtUserID.Text
                        Call btnCancel_Click("", System.EventArgs.Empty)
                        Return
                    Else
                        MyTrans.Rollback()
                        GSubShowInfo(GFncGetSysMsg(9))
                    End If
                Catch ex As Exception
                    If GSCnSqlConn.State <> ConnectionState.Closed Then
                        MyTrans.Rollback()
                    End If
                End Try
            End If
        Else
            If TxtLastName.Enabled = False And TxtNewPass.Enabled = False Then
                If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                    Dim MyTrans As SqlTransaction
                    MyTrans = GSCnSqlConn.BeginTransaction
                    Try
                        If GFncRunSQL(GSCnSqlConn, MyTrans, "Delete from User_Information where uiuserid = '" & CboUserID.Text & "'") > 0 Then
                            MyTrans.Commit()
                            GSubShowInfo(GFncGetSysMsg(13))
                            Me.MnuUser.Enabled = True
                            Call FrmUserMain_Load("", System.EventArgs.Empty)
                            Me.CboUserID.Text = ""
                            Return
                        Else
                            MyTrans.Rollback()
                            GSubShowInfo(GFncGetSysMsg(14))
                        End If
                    Catch ex As Exception
                        If GSCnSqlConn.State <> ConnectionState.Closed Then
                            MyTrans.Rollback()
                            GSubWriteErrLog(ex.Message)
                        End If
                    End Try
                End If
            Else
                If RdbUserInfo.Checked = True And RdbPass.Checked = False Then
                    If GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes Then
                        Dim MyTrans As SqlTransaction
                        MyTrans = GSCnSqlConn.BeginTransaction
                        Try
                            lstrSQL = "Update User_Information set UiLastName = '" & GFncSqlQuote(TxtLastName.Text) & _
                                "', UiFirstName = '" & GFncSqlQuote(TxtFirstName.Text) & "', UIdeptcode = '" & GFncSqlQuote(CboDept.Text) & _
                                "', Uititle = '" & GFncSqlQuote(TxtTitle.Text) & "', uiexpire = '" & Format(DTPExpiry.Value, "MM/dd/yyyy") & _
                                "', uifchgpwd = " & IIf(ChkChgPwd.Checked = True, 1, 0) & _
                                ", uiactive = " & IIf(ChkActive.Checked = True, 1, 0) & _
                                ", uimodifydt = getdate(), uimodifyuser = '" & GStrloginID & "', uiusertype = '" & _
                                CboUserType.Text & "' where uiuserid = '" & CboUserID.Text & "'"
                            If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL) > 0 Then
                                MyTrans.Commit()
                                GSubShowInfo(GFncGetSysMsg(8))
                                Call btnCancel_Click("", System.EventArgs.Empty)
                                Return
                            Else
                                MyTrans.Rollback()
                                GSubShowInfo(GFncGetSysMsg(9))
                            End If
                        Catch ex As Exception
                            If GSCnSqlConn.State <> ConnectionState.Closed Then
                                MyTrans.Rollback()
                                GSubWriteErrLog(ex.Message)
                            End If
                        End Try
                    End If
                Else
                    If RdbUserInfo.Checked = False And RdbPass.Checked = True Then
                        'If ClsUM.GFncUserType(GStrloginID) = "User" Then
                        '    If ClsUM.IsOldPassOK(CboUserID.Text, TxtOldPass.Text) = False Then
                        '        GSubShowInfo(GFncGetSysMsg(21))
                        '    Else
                        '        If TxtNewPass.Text <> TxtConfirmPass.Text Then
                        '            GSubShowInfo(GFncGetSysMsg(23))
                        '        Else
                        '            If ClsLogin.GFncChkPwdRepeat(CboUserID.Text, TxtNewPass.Text) = True Then
                        '                GSubShowInfo(GFncGetSysMsg(26))
                        '            Else
                        '                Dim MyTrans As SqlTransaction
                        '                MyTrans = GSCnSqlConn.BeginTransaction
                        '                Try
                        '                    If GFncRunSQL(GSCnSqlConn, MyTrans, "Update User_Information set UiPassword = '" & GFncGetMd5Hash(TxtNewPass.Text) & "', uimodifydt = getdate(), uimodifyuser = '" & GStrloginID & "' where uiuserid = '" & CboUserID.Text & "'") > 0 And _
                        '                       GFncRunSQL(GSCnSqlConn, MyTrans, "Insert into password_history values ('" & CboUserID.Text & "',getdate(), '" & GFncGetMd5Hash(TxtNewPass.Text) & "','" & GStrloginID & "', getdate())") > 0 Then
                        '                        MyTrans.Commit()
                        '                        Me.MnuUser.Enabled = True
                        '                        Call ResetForm()
                        '                    Else
                        '                        MyTrans.Rollback()
                        '                    End If
                        '                Catch ex As Exception
                        '                    If GSCnSqlConn.State <> ConnectionState.Closed Then
                        '                        MyTrans.Rollback()
                        '                        GSubWriteErrLog(ex.Message)
                        '                    End If
                        '                End Try
                        '            End If
                        '        End If
                        '    End If
                        'Else
                        If TxtNewPass.Text <> TxtConfirmPass.Text Then
                            GSubShowInfo(GFncGetSysMsg(23))
                            Return
                        End If
                        If ClsLogin.GFncChkPwdRepeat(CboUserID.Text, TxtNewPass.Text) = True Then
                            GSubShowInfo(GFncGetSysMsg(26))
                            Return
                        End If
                        If GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes Then
                            Dim MyTrans As SqlTransaction
                            MyTrans = GSCnSqlConn.BeginTransaction
                            Try
                                lstrSQL = "Update User_Information set UiPassword = '" & GFncGetMd5Hash(TxtNewPass.Text) & _
                                            "', uimodifydt = getdate(), uimodifyuser = '" & GStrloginID & _
                                             "' where uiuserid = '" & CboUserID.Text & "'"
                                If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL) <= 0 Then
                                    MyTrans.Rollback()
                                    GSubShowInfo(GFncGetSysMsg(9))
                                    Return
                                End If

                                ''lstrSQL = "Insert into password_history (PwHChrUserID,PwHDtmChangeDate,PwHChrPassword, " & _
                                '        " lstupdusr,lstupddte) values ('" & CboUserID.Text & "',getdate(), '" & _
                                '        GFncGetMd5Hash(TxtNewPass.Text) & "','" & GStrloginID & "', getdate())"
                                'If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL) > 0 Then
                                MyTrans.Commit()
                                GSubShowInfo(GFncGetSysMsg(8))
                                Call btnCancel_Click("", System.EventArgs.Empty)
                                Return
                                'Else
                                '    MyTrans.Rollback()
                                '    GSubShowInfo(GFncGetSysMsg(9))
                                'End If
                            Catch ex As Exception
                                If GSCnSqlConn.State <> ConnectionState.Closed Then
                                    MyTrans.Rollback()
                                    GSubWriteErrLog(ex.Message)
                                End If
                            End Try
                        End If
                        'End If
                    End If
                End If
            End If
        End If

    End Sub

   
    Private Sub PasswordToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PasswordToolStripMenuItem.Click
        If Me.CboUserID.Text.Trim = "" Then
            GSubShowInfo(GFncGetSysMsg(86))
            Return
        End If
        lstrStatus = "Menu"

        Me.TxtOldPass.Text = ""
        Me.TxtNewPass.Text = ""
        Me.TxtConfirmPass.Text = ""
        MnuUser.Enabled = False

        Me.GBxPassword.Enabled = True
        Me.btnSave.Enabled = True
        Me.btnCancel.Enabled = True

        Me.RdbPass.Checked = True
        Me.CboUserID.Enabled = False
        Me.TxtOldPass.Focus()

    End Sub
End Class
