Public Class FrmPwdNotifyS

    Dim cls As New ClsPwdNotifyS

    Private Sub FrmPwdNotifyS_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.txtAccno.Focus()
    End Sub

    'Private Sub txtAccno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccno.KeyPress
    '    If (Asc(e.KeyChar) = 13) Then
    '        getInfo()
    '    End If
    'End Sub

    Private Sub txtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress
        e.KeyChar = LCase(e.KeyChar)
    End Sub

    Private Sub btnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click
        getInfo()
    End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click

        Dim displayName As String
        Dim displaySubject As String
        Dim displayLang As String
        Dim lstrPwd As String = Me.txtPassword.Text.Trim
        Dim lstrTrade As String = ""

        If (Me.txtEmail.Text.Trim = "") Then
            GSubShowInfo(GFncGetSysMsg(19))
            Me.txtEmail.Focus()
            Return
        End If

        If (Me.cbOldPassword.Checked = False And Me.txtPassword.Text.Trim = "") Then
            GSubShowInfo(GFncGetSysMsg(21))
            Me.txtPassword.Focus()
            Return
        End If

        If (cls.validateEmail(Me.txtEmail.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(19))
            Me.txtEmail.Focus()
            Return
        End If

        If ((Me.rbNameE.Checked = False) And (Me.rbNameC.Checked = False)) Then
            GSubShowInfo(GFncGetSysMsg(30))
            Return
        End If

        If (Me.rbNameE.Checked = True) Then
            displayName = Me.rbNameE.Text
        Else
            displayName = Me.rbNameC.Text
        End If

        cls.getEmailSetting()


        If (Me.rbEng.Checked = True) Then
            displayLang = cls.strLangE
            displaySubject = My.Resources.SecPwdEmailSubE.ToString
            If Me.cbOldPassword.Checked Then
                lstrPwd = My.Resources.useOldPwdE.ToString.Trim
            End If
        ElseIf (Me.rbTran.Checked = True) Then
            displayLang = cls.strLangT
            displaySubject = My.Resources.SecPwdEmailSubT.ToString
            If Me.cbOldPassword.Checked Then
                lstrPwd = My.Resources.useOldPwdT.ToString.Trim
            End If
        Else
            displayLang = cls.strLangS
            displaySubject = My.Resources.SecPwdEmailSubS.ToString
            If Me.cbOldPassword.Checked Then
                lstrPwd = My.Resources.useOldPwdS.ToString.Trim
            End If
        End If
        If Me.rbAFE.Checked Then
            lstrTrade = cls.strTradeAFE
        ElseIf Me.rbTTL.Checked Then
            lstrTrade = cls.strTradeTTL
        Else
            lstrTrade = cls.strTradeBoth
        End If

        cls.mySendEmail(cls.emailSender, Me.txtEmail.Text.Trim, displaySubject, displayName, lstrPwd, _
                        displayLang, Me.txtAccno.Text, lstrTrade)

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        Me.txtAccno.Text = ""
        Me.rbNameE.Checked = False
        Me.rbNameE.Text = ""
        Me.rbNameC.Checked = False
        Me.rbNameC.Text = ""
        Me.txtEmail.Text = ""
        Me.txtPassword.Text = ""
        Me.rbTran.Checked = True
        Me.txtAccno.Focus()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub getInfo()

        Dim lds As DataSet = Nothing

        If (Me.txtAccno.Text.Trim = "") Then
            Me.txtAccno.Focus()
            GSubShowInfo(GFncGetSysMsg(5))
            Return
        End If

        lds = cls.getClientInfo(Me.txtAccno.Text)

        If (lds.Tables(0).Rows.Count > 0) Then
            Me.rbNameE.Text = lds.Tables(0).Rows(0).Item("name_1")
            Me.rbNameC.Text = lds.Tables(0).Rows(0).Item("name_1_c")
            Me.txtEmail.Text = lds.Tables(0).Rows(0).Item("email")
            Me.txtPassword.Focus()
        Else
            Me.rbNameE.Text = ""
            Me.rbNameC.Text = ""
            Me.txtEmail.Text = ""
            Me.txtAccno.Focus()
            GSubShowInfo(GFncGetSysMsg(24))
        End If

    End Sub


    Private Sub txtAccno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccno.Validated
        If (Me.txtAccno.Text.Trim = "") Then
            Me.rbNameE.Text = ""
            Me.rbNameC.Text = ""
            Me.txtEmail.Text = ""
        Else
            getInfo()
        End If

    End Sub

    Private Sub cbOldPassword_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbOldPassword.CheckedChanged
        If Me.cbOldPassword.Checked Then
            Me.txtPassword.Text = ""
            Me.txtPassword.Enabled = False
        Else
            Me.txtPassword.Enabled = True
        End If
    End Sub
End Class
