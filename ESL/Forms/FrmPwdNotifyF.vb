Public Class FrmPwdNotifyF

    Dim cls As New ClsPwdNotifyF

    Private Sub getInfo()

        Dim lds As DataSet

        If (Me.txtAccno.Text.Trim = "") Then
            GSubShowInfo(GFncGetSysMsg(5))
            Return
        End If

        lds = cls.getClientInfo(Me.txtAccno.Text)

        If (lds.Tables(0).Rows.Count > 0) Then
            Me.rbNameE.Text = lds.Tables(0).Rows(0).Item("name_1")
            Me.rbNameC.Text = lds.Tables(0).Rows(0).Item("name_1_c")
            Me.txtEmail.Text = lds.Tables(0).Rows(0).Item("email")
            Me.lblTradeCode.Text = lds.Tables(0).Rows(0).Item("tradecode")
        Else
            Me.rbNameE.Text = ""
            Me.rbNameC.Text = ""
            Me.txtEmail.Text = ""
            Me.lblTradeCode.Text = ""
            Me.txtAccno.Focus()
            GSubShowInfo(GFncGetSysMsg(24))
        End If

    End Sub

    Private Sub btnInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfo.Click

        getInfo()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        Me.txtAccno.Text = ""
        Me.rbNameE.Checked = False
        Me.rbNameE.Text = ""
        Me.rbNameC.Checked = False
        Me.rbNameC.Text = ""
        Me.txtEmail.Text = ""
        Me.lblTradeCode.Text = ""
        Me.rbHtml.Checked = False
        Me.rbText.Checked = False
        Me.rbTran.Checked = True
        Me.txtAccno.Focus()

    End Sub

    Private Sub FrmPwdNotifyF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.txtAccno.Focus()

    End Sub

    'Private Sub txtAccno_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAccno.KeyPress

    '    If (Asc(e.KeyChar) = 13) Then
    '        getInfo()
    '    End If

    'End Sub

    Private Sub btnSend_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSend.Click

        Dim displayName As String
        Dim displaySubject As String
        Dim displayFormat As String
        Dim displayLang As String

        If (Me.txtEmail.Text.Trim = "") Then
            GSubShowInfo(GFncGetSysMsg(19))
            Me.txtEmail.Focus()
            Return
        End If

        If (cls.validateEmail(Me.txtEmail.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(19))
            Me.txtEmail.Focus()
            Return
        End If

        If ((cls.isErrorDomain(Me.txtEmail.Text) = True) And (Me.rbHtml.Checked = True)) Then
            GSubShowInfo(GFncGetSysMsg(20))
            Me.txtEmail.Focus()
            Return
        End If


        If ((Me.rbHtml.Checked = False) And (Me.rbText.Checked = False)) Then
            GSubShowInfo(GFncGetSysMsg(25))
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

        If (Me.rbHtml.Checked = True) Then
            displayFormat = cls.displayhtml
        Else
            displayFormat = cls.displaytext
        End If

        If (Me.rbEng.Checked = True) Then
            displayLang = cls.strLangE
            displaySubject = My.Resources.pwdEmailSubE.ToString
        ElseIf (Me.rbTran.Checked = True) Then
            displayLang = cls.strLangT
            displaySubject = My.Resources.pwdEmailSubT.ToString
        Else
            displayLang = cls.strLangS
            displaySubject = My.Resources.pwdEmailSubS.ToString
        End If

        cls.mySendEmail(cls.emailSender, Me.txtEmail.Text, displaySubject, displayName, Me.lblTradeCode.Text, displayFormat, _
                        displayLang, Me.txtAccno.Text)

    End Sub

    Private Sub txtEmail_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEmail.KeyPress

        e.KeyChar = LCase(e.KeyChar)

    End Sub

    Private Sub txtAccno_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtAccno.Validated
        If Me.txtAccno.Text.Trim = "" Then
            Me.rbNameE.Text = ""
            Me.rbNameC.Text = ""
            Me.txtEmail.Text = ""
            Me.lblTradeCode.Text = ""
        Else
            getInfo()
        End If

    End Sub
End Class
