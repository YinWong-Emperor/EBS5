Public Class FrmClientMaster

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

        If GStrDisableSecuritiesButton = "Y" Then
            btnExportS.Enabled = False
        End If
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
                    If (cls.lFncExportClientMasterS(strExFile, Me.txtClientFrom.Text, Me.txtClientTo.Text, _
                        Me.comboAEFrom.Text, Me.comboAETo.Text) = True) Then
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
                        If (cls.lFncExportClientMasterF(strExFile, Me.txtClientFrom.Text, Me.txtClientTo.Text, _
    Me.comboAEFrom.Text, Me.comboAETo.Text) = True) Then
                            GSubShowInfo(GFncGetSysMsg(28))
                        Else
                            GSubShowInfo(GFncGetSysMsg(29))
                        End If
                End If
        End If

    End Sub

End Class
