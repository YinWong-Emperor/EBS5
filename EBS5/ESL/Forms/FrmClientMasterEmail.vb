Public Class FrmClientMasterMail

    Dim cls As New ClsClientMaster

    Private Sub FrmClientMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ldsDetail As DataSet
        Dim ldsDetail2 As DataSet

        ldsDetail = cls.lFncGetAECode()
        ldsDetail2 = cls.lFncGetAECode()
        Me.comboAEFrom.DataSource = ldsDetail.Tables("clt")
        Me.comboAEFrom.DisplayMember = "aeno"
        Me.comboAETo.DataSource = ldsDetail2.Tables("clt")
        Me.comboAETo.DisplayMember = "aeno"
        Me.lbSuspendCode.DataSource = cls.lFncGetSuspendCode().Tables(0)
        Me.lbSuspendCode.DisplayMember = "misc_desc"
        Me.cbOpen.Checked = True
        Me.cbOpen.Checked = False
        Me.cbClose.Checked = True
        Me.cbClose.Checked = False
        Me.cbActiveClient.Checked = True
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub cbClient_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbClient.CheckedChanged

        If (Me.cbClient.Checked = True) Then
            Me.txtClientFrom.Enabled = True
            Me.txtClientTo.Enabled = True
            Me.txtClientFrom.Focus()
        Else
            Me.txtClientFrom.Enabled = False
            Me.txtClientTo.Enabled = False
            Me.txtClientFrom.Text = ""
            Me.txtClientTo.Text = ""
        End If

    End Sub

    Private Sub cbAE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAE.CheckedChanged

        If (Me.cbAE.Checked = True) Then
            Me.comboAEFrom.Enabled = True
            Me.comboAETo.Enabled = True
            Me.comboAEFrom.Focus()
        Else
            Me.comboAEFrom.Enabled = False
            Me.comboAETo.Enabled = False
            Me.comboAEFrom.SelectedIndex = 0
            Me.comboAETo.SelectedIndex = 0
        End If

    End Sub

    Private Function lIsValidClient() As Boolean

        If (Me.cbClient.Checked = True) Then
            If (Me.txtClientFrom.Text.Trim.Length > 0 And Me.txtClientTo.Text.Trim.Length > 0) Then
                If (Me.txtClientTo.Text < Me.txtClientFrom.Text) Then
                    GSubShowInfo(GFncGetSysMsg(5))
                    Me.txtClientFrom.Focus()
                    Return False
                End If
            End If
        End If

        Return True

    End Function

    Private Function lIsValidAE() As Boolean

        If (Me.cbAE.Checked = True) Then
            If (Me.comboAEFrom.Text.Trim.Length > 0 And Me.comboAETo.Text.Trim.Length > 0) Then
                If (Me.comboAETo.Text < Me.comboAEFrom.Text) Then
                    GSubShowInfo(GFncGetSysMsg(31))
                    Me.comboAEFrom.Focus()
                    Return False
                End If
            End If
        End If

        Return True

    End Function

    Private Sub btnExportS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportS.Click

        Dim strExFile As String = "clientmasterg2bs.csv"

        If (lIsValidClient() = True And lIsValidClient() = True) Then
            If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
                Dim lstrFormDate As String = ""
                Dim lstrToDate As String = ""
                Dim lstrFromCloseDate As String = ""
                Dim lstrToCloseDate As String = ""
                Dim lstrAEFrom As String = ""
                Dim lstrAETo As String = ""
                If Me.cbOpen.Checked Then
                    lstrFormDate = Format(Me.dtpFrom.Value, "yyyy/MM/dd")
                    lstrToDate = Format(Me.dtpTo.Value, "yyyy/MM/dd")
                End If
                If Me.cbClose.Checked Then
                    lstrFromCloseDate = Format(Me.dtpFrom2.Value, "yyyy/MM/dd")
                    lstrToCloseDate = Format(Me.dtpTo2.Value, "yyyy/MM/dd")
                End If
                If Me.cbAE.Checked Then
                    lstrAEFrom = Me.comboAEFrom.Text
                    lstrAETo = Me.comboAETo.Text
                End If
                If (cls.lFncExportClientMasterSMail(strExFile, Me.txtClientFrom.Text, Me.txtClientTo.Text, _
                   lstrAEFrom, lstrAETo, lstrFormDate, lstrToDate, lstrFromCloseDate, lstrToCloseDate, Me.cbActiveClient.Checked) = True) Then
                    GSubShowInfo(GFncGetSysMsg(28))
                Else
                    GSubShowInfo(GFncGetSysMsg(29))
                End If
            End If
        End If

    End Sub

    Private Sub btnExportF_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportF.Click

        Dim strExFile As String = "clientmasterg2bf.csv"

        If (lIsValidClient() = True And lIsValidClient() = True) Then
            If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
                Dim lstrFormDate As String = ""
                Dim lstrToDate As String = ""
                Dim lstrFromCloseDate As String = ""
                Dim lstrToCloseDate As String = ""
                Dim lstrAEFrom As String = ""
                Dim lstrAETo As String = ""
                If Me.cbOpen.Checked Then
                    lstrFormDate = Format(Me.dtpFrom.Value, "yyyy/MM/dd")
                    lstrToDate = Format(Me.dtpTo.Value, "yyyy/MM/dd")
                End If
                If Me.cbClose.Checked Then
                    lstrFromCloseDate = Format(Me.dtpFrom2.Value, "yyyy/MM/dd")
                    lstrToCloseDate = Format(Me.dtpTo2.Value, "yyyy/MM/dd")
                End If
                If Me.cbAE.Checked Then
                    lstrAEFrom = Me.comboAEFrom.Text
                    lstrAETo = Me.comboAETo.Text
                End If
                If (cls.lFncExportClientMasterFmail(strExFile, Me.txtClientFrom.Text, Me.txtClientTo.Text, _
                    lstrAEFrom,lstrAETo, lstrFormDate, lstrToDate, lstrFromCloseDate, lstrToCloseDate, Me.cbActiveClient.Checked) = True) Then
                    GSubShowInfo(GFncGetSysMsg(28))
                Else
                    GSubShowInfo(GFncGetSysMsg(29))
                End If
            End If
        End If

    End Sub

    Private Sub cbOpen_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbOpen.CheckedChanged
        If (Me.cbOpen.Checked = True) Then
            Me.dtpFrom.Enabled = True
            Me.dtpTo.Enabled = True
            Me.dtpFrom.Focus()
        Else
            Me.dtpFrom.Enabled = False
            Me.dtpTo.Enabled = False
            Me.dtpFrom.Value = GDteTradeDate
            Me.dtpTo.Value = GDteTradeDate
        End If
    End Sub

    Private Sub cbClose_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbClose.CheckedChanged
        If (Me.cbClose.Checked = True) Then
            Me.cbActiveClient.Checked = False
            Me.cbActiveClient.Enabled = False
            Me.dtpFrom2.Enabled = True
            Me.dtpTo2.Enabled = True
            Me.lbSuspendCode.Enabled = True
            Me.dtpFrom2.Focus()
        Else
            Me.lbSuspendCode.Enabled = False
            Me.cbActiveClient.Enabled = True
            Me.dtpFrom2.Enabled = False
            Me.dtpTo2.Enabled = False
            Me.dtpFrom2.Value = GDteTradeDate
            Me.dtpTo2.Value = GDteTradeDate
        End If
    End Sub

End Class
