Public Class FrmRptFatcaAccountList
    Private gCls As New clsRptFatcaAccountList
    Private gClsExportFatcaAccountList As New ClsExportFatcaAccountList
    Private Sub FrmRptFatcaAccountList_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        lsubShowProcessing(False)

        Dim dtAccType As DataTable = gCls.GetAccType()
        Me.cboAccType.Items.Add("-- ALL --")
        If dtAccType.Rows.Count > 0 Then
            For i As Integer = 0 To dtAccType.Rows.Count - 1
                Me.cboAccType.Items.Add(GFncNoNullString(dtAccType.Rows(i).Item("CharValue")))
            Next
        End If
        Me.cboAccType.Text = "-- ALL --"
        cboAccType.ValueMember = "AccType"

        Dim dtFatAccType As DataTable = gCls.GetFatcaAccType()
        Me.cboFatcaAccType.Items.Add("-- ALL --")
        If dtFatAccType.Rows.Count > 0 Then
            For i As Integer = 0 To dtFatAccType.Rows.Count - 1
                Me.cboFatcaAccType.Items.Add(GFncNoNullString(dtFatAccType.Rows(i).Item("CharValue")))
            Next
        End If
        Me.cboFatcaAccType.Text = "-- ALL --"
        cboAccType.ValueMember = "FatcaAccType"

        Dim dtNature As DataTable = gCls.GetNatureS()
        Me.cboClientType.Items.Add("-- ALL --")
        If dtNature.Rows.Count > 0 Then
            For i As Integer = 0 To dtNature.Rows.Count - 1
                Me.cboClientType.Items.Add(GFncNoNullString(dtNature.Rows(i).Item("CharValue")))
            Next
        End If
        Me.cboClientType.Text = "-- ALL --"
        cboClientType.ValueMember = "ClientType"

        Dim dtAENo As DataTable = gCls.GetAeNo()
        dtAENo.Rows.InsertAt(dtAENo.NewRow, 0)
        If dtAENo.Rows.Count > 0 Then
            For i As Integer = 0 To dtAENo.Rows.Count - 1
                Me.cboAENoFrom.Items.Add(GFncNoNullString(dtAENo.Rows(i).Item("aeno")))
                Me.cboAENoTo.Items.Add(GFncNoNullString(dtAENo.Rows(i).Item("aeno")))
            Next
        End If
        cboAENoFrom.ValueMember = "AeNo"

        txtAccNoFrom.Enabled = False
        txtAccNoTo.Enabled = False
        cboAENoFrom.Enabled = False
        cboAENoTo.Enabled = False

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

    End Sub

    Private Sub chkAccNo_CheckChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAccNo.CheckedChanged
        If chkAccNo.Checked = True Then
            txtAccNoFrom.Enabled = True
            txtAccNoTo.Enabled = True

        Else
            txtAccNoFrom.Enabled = False
            txtAccNoTo.Enabled = False
            txtAccNoFrom.Text = ""
            txtAccNoTo.Text = ""
        End If
    End Sub
    Private Sub chkAENo_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAENo.CheckedChanged
        If chkAENo.Checked = True Then
            cboAENoFrom.Enabled = True
            cboAENoTo.Enabled = True
        Else
            cboAENoFrom.Enabled = False
            cboAENoTo.Enabled = False
            cboAENoFrom.SelectedIndex = -1
            cboAENoTo.SelectedIndex = -1
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim lstrSQL As String = ""
        lsubShowProcessing(True)
        Application.DoEvents()
        If Me.cboAccType.Text.Trim <> "" And Me.cboAccType.Text.Trim <> "-- ALL --" Then
            lstrSQL += " and vwcm.client_type = '" & Me.cboAccType.Text.Trim.Trim & "' "
        End If
        If Me.cboFatcaAccType.Text.Trim <> "" And Me.cboFatcaAccType.Text.Trim <> "-- ALL --" Then
            lstrSQL += " and vwcm.FATCA_acc_type = '" & Me.cboFatcaAccType.Text.Trim.Trim & "' "
        End If
        If Me.cboClientType.Text.Trim <> "" And Me.cboClientType.Text.Trim <> "-- ALL --" Then
            lstrSQL += " and vwcm.nature_s = '" & Me.cboClientType.Text.Trim.Trim & "' "
        End If
        If chkAccNo.Checked = True Then
            If Me.txtAccNoFrom.Text.Trim <> "" Then
                lstrSQL += " and vwcm.accno >= '" & Me.txtAccNoFrom.Text.Trim & "' "
            End If
            If Me.txtAccNoTo.Text.Trim <> "" Then
                lstrSQL += " and vwcm.accno <= '" & Me.txtAccNoTo.Text.Trim.Trim & "' "
            End If

        End If
        If Me.cboAENoFrom.Text.Trim <> "" Then
            lstrSQL += " and vwcm.AENo >= '" & Me.cboAENoFrom.Text.Trim.Trim & "' "
        End If
        If Me.cboAENoTo.Text.Trim <> "" Then
            lstrSQL += " and vwcm.AENo <= '" & Me.cboAENoTo.Text.Trim.Trim & "' "
        End If
        gClsExportFatcaAccountList.lFncFatcaAccountList(lstrSQL)

        lsubShowProcessing(False)
        Application.DoEvents()
    End Sub
    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub


End Class
