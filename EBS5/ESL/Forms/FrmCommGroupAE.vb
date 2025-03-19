Public Class FrmCommGroupAE

    Dim cls As New ClsCommGroupAE
    Dim ldtEmpty As DataTable = Nothing
    Dim action As String = ""
    Dim gp_id As String = ""

    Private Sub FrmCommGroupAE_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        Dim ldtAE As DataTable = Nothing
        Dim MaxDate As String = GfncGetMonth()
        For year As Integer = Val(MaxDate.Substring(0, 4)) - 5 To Val(MaxDate.Substring(0, 4)) + 5
            Me.cboSearchYear.Items.Add(year)
        Next
        For month As Integer = 1 To 12
            Me.cboSearchMonth.Items.Add(month)
        Next
        Me.cboSearchYear.Text = MaxDate.Substring(0, 4)
        Me.cboSearchMonth.Text = Val(MaxDate.Substring(4, 2))
        ldtAE = cls.lFncGetAEFullList("").Tables(0)
        For i As Integer = 0 To ldtAE.Rows.Count - 1
            Me.cboAENo.Items.Add(ldtAE.Rows(i).Item("ae_no"))
        Next
        ldtEmpty = cls.lFncGetGroup("", "", "")
        refreshAEList()
        lSubControl(False)
    End Sub

    Private Sub refreshAEList()
        Dim txmonth As String = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        Dim ae_no As String = Me.txtSrchAE.Text
        Dim group As String = Me.txtSrchGroup.Text
        Me.dgvGroup.DataSource = cls.lFncGetGroup(txmonth, ae_no, group)
    End Sub

    Private Sub dgvGroup_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvGroup.SelectionChanged
        If Me.dgvGroup.Rows.Count > 0 Then
            If Me.dgvGroup.SelectedCells.Count > 0 Then
                lSubAssignField(False)
            Else
                lSubAssignField(True)
            End If
        Else
           lSubAssignField(True)
        End If
    End Sub

    Private Sub cboAENo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAENo.LostFocus
        Me.txtAEName.Text = cls.lFncGetAEName(cboAENo.Text.Trim)
    End Sub

    Private Sub cboAENo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAENo.SelectedIndexChanged
        Me.txtAEName.Text = cls.lFncGetAEName(cboAENo.Text.Trim)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        refreshAEList()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        action = "A"
        lSubControl(True)
        lSubAssignField(True)
        Me.cboAENo.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvGroup.Rows.Count > 0 Then
            action = "E"
            lSubControl(True)
            gp_id = Me.dgvGroup.CurrentRow.Cells("gpid").Value
            Me.cboAENo.Focus()
        Else
            GSubShowInfo(GFncGetSysMsg(56))
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvGroup.Rows.Count > 0 Then
            If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
                If GFncCheckCommStatus() Then
                    Return
                End If
                Dim gpid As Integer = Me.dgvGroup.CurrentRow.Cells("gpid").Value
                If (cls.lFncDeleteAE(gpid, Me.txtMonth.Text.Trim, Me.txtGroup.Text.Trim, Me.cboAENo.Text.Trim, Me.cbSpecial.Checked, Me.cbConsolid.Checked)) Then
                    refreshAEList()
                    lSubControl(False)
                    GSubShowInfo(GFncGetSysMsg(13))
                End If
            End If
        Else
            GSubShowInfo(GFncGetSysMsg(56))
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ae_no As String = Me.cboAENo.Text.Trim
        Dim txmonth As String = Me.txtMonth.Text.Trim
        Dim group_ae As String = Me.txtGroup.Text
        Dim isSpecial As String = "0"
        Dim isConsolid As String = "0"
        If (Me.cbSpecial.Checked) Then
            isSpecial = "1"
        End If
        If (Me.cbConsolid.Checked) Then
            isConsolid = "1"
        End If
        If (group_ae.Trim = "") Then
            GSubShowInfo(GFncGetSysMsg(87))
            Me.txtGroup.Focus()
            Return
        End If
        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncIsValidAE(ae_no)) Then
                GSubShowInfo(GFncGetSysMsg(83))
                Me.cboAENo.Focus()
                Return
            End If
            If GFncCheckCommStatus() Then
                Return
            End If
            If (action = "A") Then
                If (cls.lFncIsAEOverlap(txmonth, ae_no, group_ae)) Then
                    GSubShowInfo(GFncGetSysMsg(44))
                    Me.cboAENo.Focus()
                    Return
                End If
                cls.lFncAddAE(ae_no, txmonth, group_ae, isSpecial, isConsolid)
            ElseIf (action = "E") Then
                If (cls.lFncIsAEOverlap(txmonth, ae_no, group_ae, gp_id)) Then
                    GSubShowInfo(GFncGetSysMsg(44))
                    Me.cboAENo.Focus()
                    Return
                End If
                cls.lFncEditAE(gp_id, ae_no, group_ae, isSpecial, isConsolid, txmonth)
            End If
            refreshAEList()
            If (gp_id.Length = 0) Then
                gp_id = cls.lFnGetGPID()
            End If
            For i As Integer = 0 To Me.dgvGroup.Rows.Count - 1
                If (Me.dgvGroup.Rows(i).Cells("gpid").Value = gp_id) Then
                    Me.dgvGroup.Rows(i).Cells("txmonth").Selected = True
                    Me.dgvGroup.FirstDisplayedScrollingRowIndex = i
                    Exit For
                End If
            Next
            lSubControl(False)
            lSubAssignField(False)
            action = ""
            gp_id = ""
            GSubShowInfo(GFncGetSysMsg(8))
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (action = "A" Or action = "E") Then
            lSubControl(False)
            lSubAssignField(False)
            action = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lSubAssignField(ByVal isEmpty As Boolean)
        If (isEmpty) Then
            Me.txtMonth.Text = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
            Me.cboAENo.SelectedIndex = -1
            Me.txtGroup.Text = ""
            Me.cbSpecial.Checked = False
            Me.cbConsolid.Checked = False
        Else
            If (Me.dgvGroup.RowCount > 0) Then
                Me.txtMonth.Text = GFncNoNullString(Me.dgvGroup.CurrentRow.Cells("txmonth").Value)
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dgvGroup.CurrentRow.Cells("ae_no").Value)
                Me.txtGroup.Text = Me.dgvGroup.CurrentRow.Cells("group_ae").Value
                If (Me.dgvGroup.CurrentRow.Cells("calSpecial").Value = "Y") Then
                    Me.cbSpecial.Checked = True
                Else
                    Me.cbSpecial.Checked = False
                End If
                If (Me.dgvGroup.CurrentRow.Cells("isConsolid").Value = "Y") Then
                    Me.cbConsolid.Checked = True
                Else
                    Me.cbConsolid.Checked = False
                End If
            Else
                Me.txtMonth.Text = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
                Me.cboAENo.SelectedIndex = -1
                Me.txtGroup.Text = ""
                Me.cbSpecial.Checked = False
                Me.cbConsolid.Checked = False
            End If
        End If
    End Sub

    Private Sub lSubControl(ByVal flag As Boolean)
        Me.cboSearchYear.Enabled = False
        Me.cboSearchMonth.Enabled = False
        Me.txtSrchAE.Enabled = Not flag
        Me.txtSrchGroup.Enabled = Not flag
        Me.dgvGroup.Enabled = Not flag
        Me.cboAENo.Enabled = flag
        Me.txtGroup.Enabled = flag
        Me.cbSpecial.Enabled = flag
        Me.cbConsolid.Enabled = flag
        Me.btnAdd.Enabled = Not flag
        If (Me.dgvGroup.RowCount <= 0) Then
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
        Else
            Me.btnEdit.Enabled = Not flag
            Me.btnDelete.Enabled = Not flag
        End If
        Me.btnSave.Enabled = flag
    End Sub
End Class
