Public Class FrmCommAEMaster

    Dim cls As New ClsCommAEMaster
    Dim action As String = ""
    Dim preAENo As String = ""
    Dim preMgrNo As String = ""
    Dim preMgrGrp As String = ""
    Dim ldtEmpty As DataTable = Nothing
    Dim ldtMgrGrp As DataTable = Nothing

    Private Sub FrmCommAEMaster_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
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
            Me.cbCopyYear.Items.Add(year)
        Next
        For month As Integer = 1 To 12
            Me.cboSearchMonth.Items.Add(month)
            Me.cbCopyMonth.Items.Add(month)
        Next
        'Dim MaxDate As String = cls.GetLatestMonth()
        Me.cboSearchYear.Text = MaxDate.Substring(0, 4)
        Me.cboSearchMonth.Text = Val(MaxDate.Substring(4, 2))
        Me.cbCopyYear.Text = MaxDate.Substring(0, 4)
        Me.cbCopyMonth.Text = Val(MaxDate.Substring(4, 2))
        ldtAE = cls.lFncGetAEFullList("").Tables(0)
        Me.dgvAEInfoList.DataSource = ldtAE
        For i As Integer = 0 To ldtAE.Rows.Count - 1
            Me.cboAENo.Items.Add(ldtAE.Rows(i).Item("ae_no"))
            Me.cbAEFrom.Items.Add(ldtAE.Rows(i).Item("ae_no"))
            Me.cbAETo.Items.Add(ldtAE.Rows(i).Item("ae_no"))
        Next
        ldtEmpty = cls.lFncGetAEDetail("", "", "").Tables(0)
        refreshAEList()
        Me.TabControl1.SelectedIndex = 1
    End Sub

    Private Sub cboSearchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchYear.SelectedIndexChanged
        refreshAEList()
    End Sub

    Private Sub cboSearchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchMonth.SelectedIndexChanged
        refreshAEList()
    End Sub

    Private Sub rbSrchIncentive_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchIncentive.CheckedChanged
        refreshAEList()
    End Sub

    Private Sub rbSrchBonus_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchBonus.CheckedChanged
        refreshAEList()
    End Sub

    Private Sub rbSrchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAll.CheckedChanged
        refreshAEList()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        refreshAEList()
    End Sub

    Private Sub refreshMgrGrpDT()
        Dim txmonth As String = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        ldtMgrGrp = cls.lFncGetMgrGrpList(txmonth).Tables(0)
        Me.cboMgrNo.Items.Clear()
        Dim preMgr As String = ""
        Me.cboMgrNo.Items.Add("")
        For i As Integer = 0 To ldtMgrGrp.Rows.Count - 1
            If (ldtMgrGrp.Rows(i).Item("man_no") <> preMgr) Then
                Me.cboMgrNo.Items.Add(ldtMgrGrp.Rows(i).Item("man_no"))
                preMgr = ldtMgrGrp.Rows(i).Item("man_no")
            End If
        Next
    End Sub

    Private Sub refreshAEList()
        Dim txmonth As String = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        Dim incentive_bonus As String = ""
        If (Me.rbSrchIncentive.Checked) Then
            incentive_bonus = "I"
        ElseIf (Me.rbSrchBonus.Checked) Then
            incentive_bonus = "B"
        End If
        Dim AE As String = Me.txtSrchAE.Text
        'ldtMgrGrp = cls.lFncGetMgrGrpList(txmonth).Tables(0)
        'Me.cboMgrNo.Items.Clear()
        'Dim preMgr As String = ""
        'Me.cboMgrNo.Items.Add("")
        'For i As Integer = 0 To ldtMgrGrp.Rows.Count - 1
        '    If (ldtMgrGrp.Rows(i).Item("man_no") <> preMgr) Then
        '        Me.cboMgrNo.Items.Add(ldtMgrGrp.Rows(i).Item("man_no"))
        '        preMgr = ldtMgrGrp.Rows(i).Item("man_no")
        '    End If
        'Next
        refreshMgrGrpDT()
        Me.dgvDetail.DataSource = ldtEmpty
        Me.dgvAEList.DataSource = cls.lFncGetAEList(txmonth, incentive_bonus, AE).Tables(0)
    End Sub

    Private Sub dgvAEList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEList.SelectionChanged
        If Me.dgvAEList.Rows.Count > 0 Then
            If Me.dgvAEList.SelectedCells.Count > 0 Then
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dgvAEList.CurrentRow.Cells(0).Value)
                Dim txmonth As String = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
                Dim incentive_bonus As String = ""
                If (Me.rbSrchIncentive.Checked) Then
                    incentive_bonus = "I"
                ElseIf (Me.rbSrchBonus.Checked) Then
                    incentive_bonus = "B"
                End If
                Me.dgvDetail.DataSource = cls.lFncGetAEDetail(Me.cboAENo.Text, txmonth, incentive_bonus).Tables(0)
            Else
                Me.cboAENo.SelectedIndex = -1
            End If
        Else
            Me.cboAENo.SelectedIndex = -1
        End If
    End Sub

    Private Sub dgvDetail_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetail.SelectionChanged
        If Me.dgvDetail.Rows.Count > 0 Then
            If Me.dgvDetail.SelectedCells.Count > 0 Then
                Me.txtMonth.Text = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("txmonth").Value)
                If (Me.dgvDetail.CurrentRow.Cells("sec_fut").Value = "Securities") Then
                    Me.rbSec.Checked = True
                    Me.cboMgrNo.Text = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("man_no_s").Value)
                    Me.cboMgrGrp.Text = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("man_group_s").Value)
                    If (Me.dgvDetail.CurrentRow.Cells("standard_s").Value = "Y") Then
                        Me.cbStandard.Checked = True
                    Else
                        Me.cbStandard.Checked = False
                    End If
                Else
                    Me.rbFut.Checked = True
                    Me.cboMgrNo.Text = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("man_no_f").Value)
                    Me.cboMgrGrp.Text = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("man_group_f").Value)
                    If (Me.dgvDetail.CurrentRow.Cells("standard_f").Value = "Y") Then
                        Me.cbStandard.Checked = True
                    Else
                        Me.cbStandard.Checked = False
                    End If
                End If
                If (Me.dgvDetail.CurrentRow.Cells("isConsolid").Value = "Y") Then
                    Me.cbConsolid.Checked = True
                Else
                    Me.cbConsolid.Checked = False
                End If
                If (Me.dgvDetail.CurrentRow.Cells("isFOB").Value = "Y") Then
                    Me.cbFOB.Checked = True
                Else
                    Me.cbFOB.Checked = False
                End If
                Me.txtTeam.Text = Me.dgvDetail.CurrentRow.Cells("team").Value
                Me.abNorAmt.Text = Me.dgvDetail.CurrentRow.Cells("minNorAmt").Value
                Me.nbNorRate.Text = Me.dgvDetail.CurrentRow.Cells("minNorRate").Value()
                Me.abIntAmt.Text = Me.dgvDetail.CurrentRow.Cells("minIntAmt").Value()
                Me.nbIntRate.Text = Me.dgvDetail.CurrentRow.Cells("minIntRate").Value()

                If (Me.dgvDetail.CurrentRow.Cells("incentive").Value = "Y") Then
                    Me.cbIncentive.Checked = True
                Else
                    Me.cbIncentive.Checked = False
                End If
                If (Me.dgvDetail.CurrentRow.Cells("bonus").Value = "Y") Then
                    Me.cbBonus.Checked = True
                Else
                    Me.cbBonus.Checked = False
                End If
                lSubGetAEName()
                lSubDiaplayDefault()
            Else
                Me.txtMonth.Text = ""
                Me.cboMgrNo.SelectedIndex = 0
                Me.cboMgrGrp.SelectedIndex = 0
                Me.cbIncentive.Checked = False
                Me.cbBonus.Checked = False
            End If
        Else
            Me.txtMonth.Text = ""
            Me.cboMgrNo.SelectedIndex = 0
            Me.cboMgrGrp.SelectedIndex = 0
            Me.cbIncentive.Checked = False
            Me.cbBonus.Checked = False
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        action = "A"
        preAENo = Me.cboAENo.Text
        lSubControl(True)
        Me.cboAENo.Enabled = True
        Me.rbSec.Enabled = True
        Me.rbFut.Enabled = True
        refreshMgrGrpDT()
        Me.cboAENo.SelectedIndex = 0
        Me.txtMonth.Text = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        Me.rbSec.Checked = True
        Me.txtTeam.Text = ""
        Me.cboMgrNo.SelectedIndex = 0
        Me.cboMgrGrp.SelectedIndex = 0
        Me.cbIncentive.Checked = False
        Me.cbBonus.Checked = False
        Me.cbStandard.Checked = False
        Me.cbConsolid.Checked = False
        Me.abNorAmt.Text = 0
        Me.nbNorRate.Text = 0
        Me.abIntAmt.Text = 0
        Me.nbIntRate.Text = 0
        Me.cboAENo.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If (Me.dgvDetail.Rows.Count > 0) Then
            action = "E"
            preAENo = Me.cboAENo.Text
            preMgrNo = Me.cboMgrNo.Text
            preMgrGrp = Me.cboMgrGrp.Text
            lSubControl(True)

            refreshMgrGrpDT()
            Me.cboMgrNo.Text = preMgrNo
            Me.cboMgrGrp.Text = preMgrGrp
            Me.cboMgrNo.Focus()
        Else
            GSubShowInfo(GFncGetSysMsg(56))
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim ae_no As String = ""
        Dim txmonth As String = ""
        Dim man_no As String = ""
        Dim man_group As String = ""
        Dim sec_fut As String = ""
        If Me.dgvDetail.Rows.Count > 0 Then
            If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
                If GFncCheckCommStatus() Then
                    Return
                End If
                ae_no = Me.cboAENo.Text
                txmonth = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("txmonth").Value)
                If (Me.dgvDetail.CurrentRow.Cells("sec_fut").Value = "Securities") Then
                    man_no = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("man_no_s").Value)
                    man_group = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("man_group_s").Value)
                    sec_fut = "S"
                Else
                    man_no = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("man_no_f").Value)
                    man_group = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells("man_group_f").Value)
                    sec_fut = "F"
                End If
                If (cls.lFncDeleteAE(ae_no, txmonth, man_no, man_group, sec_fut)) Then
                    preAENo = ae_no
                    refreshAEList()
                    For i As Integer = 0 To Me.dgvAEList.Rows.Count - 1
                        If (Me.dgvAEList.Rows(i).Cells(0).Value = preAENo) Then
                            Me.dgvAEList.Rows(i).Cells(0).Selected = True
                            Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                            Exit For
                        End If
                    Next
                    dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
                End If
            End If
        Else
            GSubShowInfo(GFncGetSysMsg(56))
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ae_no As String = Me.cboAENo.Text.Trim
        Dim txmonth As String = Me.txtMonth.Text.Trim
        Dim sec_fut As String = ""
        Dim team As String = Me.txtTeam.Text.Trim
        Dim man_no As String = Me.cboMgrNo.Text
        Dim man_group As String = Me.cboMgrGrp.Text
        Dim incentive As String = "0"
        Dim bonus As String = "0"
        Dim standard As String = "0"
        Dim isConsolid As String = "0"
        Dim isFOB As String = "0"
        Dim minNorAmt As Decimal = Me.abNorAmt.Text
        Dim minIntAmt As Decimal = Me.abIntAmt.Text
        Dim minNorRate As Decimal = Me.nbNorRate.Text
        Dim minIntRate As Decimal = Me.nbIntRate.Text
        If (Me.rbSec.Checked) Then
            sec_fut = "S"
        Else
            sec_fut = "F"
        End If
        If (Me.cbIncentive.Checked) Then
            incentive = "1"
        Else
            incentive = "0"
        End If
        If (Me.cbBonus.Checked) Then
            bonus = "1"
        Else
            bonus = "0"
        End If
        If (Me.cbStandard.Checked) Then
            standard = "1"
        Else
            standard = "0"
        End If
        If (Me.cbConsolid.Checked) Then
            isConsolid = "1"
        Else
            isConsolid = "0"
        End If
        If (Me.cbFOB.Checked) Then
            isFOB = "1"
        Else
            isFOB = "0"
        End If
        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            'validation
            If (Me.cboAENo.FindStringExact(ae_no) < 0) Then
                GSubShowInfo(GFncGetSysMsg(31))
                Me.cboAENo.Focus()
                Return
            End If
            If GFncCheckCommStatus() Then
                Return
            End If
            If (action = "A") Then
                If (cls.lFncIsValidAE(cboAENo.Text.Trim, sec_fut) = False) Then
                    If (sec_fut = "S") Then
                        GSubShowInfo(GFncGetSysMsg(83))
                    Else
                        GSubShowInfo(GFncGetSysMsg(84))
                    End If
                    Me.cboAENo.Focus()
                    Return
                End If
                If (cls.lFncValidate(ae_no, txmonth, man_no, man_group, sec_fut) = False) Then
                    GSubShowInfo(GFncGetSysMsg(73))
                    Me.cboMgrNo.Focus()
                    Return
                End If
                cls.lFncAddAE(ae_no, txmonth, sec_fut, team, man_no, man_group, incentive, bonus, standard, isConsolid, isFOB, minNorAmt, minIntAmt, minNorRate, minIntRate)
            ElseIf (action = "E") Then
                If ((preMgrNo <> man_no) Or (preMgrGrp <> man_group)) Then
                    If (cls.lFncValidate(ae_no, txmonth, man_no, man_group, sec_fut) = False) Then
                        GSubShowInfo(GFncGetSysMsg(73))
                        Me.cboMgrNo.Focus()
                        Return
                    End If
                End If
                'If (cls.lFncValidate(ae_no, txmonth, sec_fut) = False) Then
                '    GSubShowInfo(GFncGetSysMsg(73))
                '    Me.cboMgrNo.Focus()
                '    Return
                'End If
                cls.lFncEditAE(ae_no, txmonth, sec_fut, team, preMgrNo, preMgrGrp, man_no, man_group, incentive, bonus, standard, isConsolid, isFOB, minNorAmt, minIntAmt, minNorRate, minIntRate)
            End If
            preAENo = ae_no
            refreshAEList()
            For i As Integer = 0 To Me.dgvAEList.Rows.Count - 1
                If (Me.dgvAEList.Rows(i).Cells(0).Value = preAENo) Then
                    Me.dgvAEList.Rows(i).Cells(0).Selected = True
                    Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                    Exit For
                End If
            Next
            dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
            lSubControl(False)
            Me.cboAENo.Enabled = False
            Me.rbSec.Enabled = False
            Me.rbFut.Enabled = False
            action = ""
            preAENo = ""
            GSubShowInfo(GFncGetSysMsg(8))
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ((action = "A") Or (action = "E")) Then
            refreshAEList()
            For i As Integer = 0 To Me.dgvAEList.Rows.Count - 1
                If (Me.dgvAEList.Rows(i).Cells(0).Value = preAENo) Then
                    Me.dgvAEList.Rows(i).Cells(0).Selected = True
                    Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                    Exit For
                End If
            Next
            dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
            lSubControl(False)
            Me.cboAENo.Enabled = False
            Me.rbSec.Enabled = False
            Me.rbFut.Enabled = False
            action = ""
            preAENo = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lSubControl(ByVal flag As Boolean)
        Me.cboSearchYear.Enabled = False
        Me.cboSearchMonth.Enabled = False
        Me.rbSrchIncentive.Enabled = Not flag
        Me.rbSrchBonus.Enabled = Not flag
        Me.rbSrchAll.Enabled = Not flag
        Me.txtSrchAE.Enabled = Not flag
        Me.dgvAEList.Enabled = Not flag
        Me.dgvDetail.Enabled = Not flag
        Me.txtTeam.Enabled = flag
        Me.cbIncentive.Enabled = flag
        Me.cbBonus.Enabled = flag
        Me.cboMgrNo.Enabled = flag
        Me.cboMgrGrp.Enabled = flag
        Me.cbStandard.Enabled = flag
        Me.cbConsolid.Enabled = flag
        Me.cbFOB.Enabled = flag
        Me.abNorAmt.Enabled = flag
        Me.abIntAmt.Enabled = flag
        Me.nbNorRate.Enabled = flag
        Me.nbIntRate.Enabled = flag
        Me.btnAdd.Enabled = Not flag
        Me.btnEdit.Enabled = Not flag
        Me.btnDelete.Enabled = Not flag
        Me.btnSave.Enabled = flag
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If (Me.TabControl1.SelectedIndex = 0) Then
            Me.btnAdd.Visible = False
            Me.btnEdit.Visible = False
            Me.btnDelete.Visible = False
            Me.btnSave.Visible = False
        ElseIf (Me.TabControl1.SelectedIndex = 1) Then
            Me.btnAdd.Visible = True
            Me.btnEdit.Visible = True
            Me.btnDelete.Visible = True
            Me.btnSave.Visible = True
        ElseIf (Me.TabControl1.SelectedIndex = 2) Then
            Me.btnAdd.Visible = False
            Me.btnEdit.Visible = False
            Me.btnDelete.Visible = False
            Me.btnSave.Visible = False
            Me.cbCopyMonth.Text = Me.cboSearchMonth.Text
            Me.cbCopyYear.Text = Me.cboSearchYear.Text
            Me.rbCopySec.Checked = True
            Me.rbCopyFut.Checked = False
            Me.btnCopy.Visible = True
            Me.GroupBox3.Enabled = True
            Me.rbCopyFut.Enabled = True
            Me.rbCopySec.Enabled = True
            Me.cbAETo.Enabled = True
            Me.cbAEFrom.Enabled = True
        End If
    End Sub

    Private Sub dgvAEInfoList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEInfoList.SelectionChanged
        lSubGetAEInfo(Me.dgvAEInfoList.CurrentRow.Cells(0).Value)
    End Sub

    Private Sub btnInfoEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoEdit.Click
        lSubInfoControl(True)
    End Sub

    Private Sub btnInfoSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoSave.Click
        Dim IR56M As String = "N"
        If (Me.cbIR56M.Checked) Then
            IR56M = "Y"
        End If
        If GFncCheckCommStatus() Then
            Return
        End If
        cls.lFncSaveAE(Me.txtInfoAENo.Text, Me.txtInfoAEName.Text, Me.txtBankCode.Text, Me.txtBankAcc.Text, IR56M)
        lSubGetAEInfo(Me.dgvAEInfoList.CurrentRow.Cells(0).Value)
        lSubInfoControl(False)
    End Sub

    Private Sub btnInfoCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInfoCancel.Click
        lSubGetAEInfo(Me.dgvAEInfoList.CurrentRow.Cells(0).Value)
        lSubInfoControl(False)
    End Sub

    Private Sub lSubGetAEInfo(ByVal ae_no As String)
        Dim ldtAEInfo As DataTable = cls.lFncGetAEInfo(ae_no)
        If (ldtAEInfo.Rows.Count > 0) Then
            Me.txtInfoAENo.Text = ae_no
            Me.txtInfoAEName.Text = ldtAEInfo.Rows(0).Item("ae_name")
            Me.txtInfoAENameS.Text = ldtAEInfo.Rows(0).Item("ae_name_s")
            Me.txtInfoAENameF.Text = ldtAEInfo.Rows(0).Item("ae_name_f")
            Me.txtBankCode.Text = ldtAEInfo.Rows(0).Item("bank_code")
            Me.txtBankAcc.Text = ldtAEInfo.Rows(0).Item("bank_acc")
            If (ldtAEInfo.Rows(0).Item("IR56M_flag") = "N") Then
                Me.cbIR56M.Checked = False
            Else
                Me.cbIR56M.Checked = True
            End If
        Else
            Me.txtInfoAENo.Text = ""
            Me.txtInfoAEName.Text = ""
            Me.txtInfoAENameS.Text = ""
            Me.txtInfoAENameF.Text = ""
            Me.txtBankCode.Text = ""
            Me.txtBankAcc.Text = ""
            Me.cbIR56M.Checked = False
        End If
    End Sub

    Private Sub lSubInfoControl(ByVal flag As Boolean)
        Me.txtInfoAEName.Enabled = flag
        Me.txtBankCode.Enabled = flag
        Me.txtBankAcc.Enabled = flag
        Me.cbIR56M.Enabled = flag
        Me.txtSrchAEInfo.Enabled = Not flag
        Me.btnAEInfoSearch.Enabled = Not flag
        Me.btnInfoEdit.Enabled = Not flag
        Me.btnInfoSave.Enabled = flag
        Me.btnInfoCancel.Enabled = flag
    End Sub

    Private Sub cboMgrNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMgrNo.SelectedIndexChanged
        Dim lsqlstr As String = ""
        If (Me.rbSec.Checked) Then
            lsqlstr = " and sec_fut = 'S' "
        Else
            lsqlstr = " and sec_fut = 'F' "
        End If
        Me.cboMgrGrp.Items.Clear()
        Me.cboMgrGrp.Items.Add("")
        Dim ldrMgrGrp As DataRow() = ldtMgrGrp.Select(" man_no = '" & Me.cboMgrNo.Text & "' " & lsqlstr, " man_grp ")
        For i As Integer = 0 To ldrMgrGrp.Length - 1
            Me.cboMgrGrp.Items.Add(ldrMgrGrp(i).Item("man_grp"))
        Next
    End Sub

    Private Sub rbSec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSec.CheckedChanged
        Dim lsqlstr As String = ""
        Dim preMgrNo As String = ""
        If (Not ldtMgrGrp Is Nothing) Then
            If (Me.rbSec.Checked) Then
                lsqlstr = " sec_fut = 'S' "
            Else
                lsqlstr = " sec_fut = 'F' "
            End If
            Me.cboMgrNo.Items.Clear()
            Me.cboMgrNo.Items.Add("")
            Dim ldrMgrGrp As DataRow() = ldtMgrGrp.Select(lsqlstr, " man_no ")
            For i As Integer = 0 To ldrMgrGrp.Length - 1
                If (ldrMgrGrp(i).Item("man_no") <> preMgrNo) Then
                    Me.cboMgrNo.Items.Add(ldrMgrGrp(i).Item("man_no"))
                    preMgrNo = ldrMgrGrp(i).Item("man_no")
                End If
            Next
        End If
        lSubDiaplayDefault()
    End Sub

    Private Sub cbStandard_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbStandard.CheckedChanged
        lSubDiaplayDefault()
    End Sub
    Private Sub lSubDiaplayDefault()

        If (Me.cbStandard.Checked) Then
            Me.cbConsolid.Visible = True
            Me.lblNorRate.Visible = False
            Me.nbNorRate.Visible = False
            Me.lblNorAmt.Visible = False
            Me.abNorAmt.Visible = False
            Me.lblIntRate.Visible = False
            Me.nbIntRate.Visible = False
            Me.lblIntAmt.Visible = False
            Me.abIntAmt.Visible = False
            If (Me.rbSec.Checked) Then
                Me.cbFOB.Visible = False
            Else
                Me.cbFOB.Visible = True
            End If
        Else
            Me.cbConsolid.Visible = True
            Me.lblNorRate.Visible = True
            Me.nbNorRate.Visible = True
            Me.lblIntRate.Visible = True
            Me.nbIntRate.Visible = True
            If (Me.rbSec.Checked) Then
                Me.cbFOB.Visible = False
                Me.lblNorAmt.Visible = True
                Me.abNorAmt.Visible = True
                Me.lblIntAmt.Visible = True
                Me.abIntAmt.Visible = True
            Else
                Me.cbFOB.Visible = True
                Me.lblNorAmt.Visible = False
                Me.abNorAmt.Visible = False
                Me.lblIntAmt.Visible = False
                Me.abIntAmt.Visible = False
            End If
        End If

    End Sub

    Private Sub cboAENo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAENo.LostFocus
        Me.cboAENo.Text = Me.cboAENo.Text.ToUpper
        lSubGetAEName()
    End Sub

    Private Sub cboAENo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAENo.SelectedIndexChanged
        lSubGetAEName()
    End Sub

    Private Sub lSubGetAEName(Optional ByVal strFromTo As String = "")
        Select Case strFromTo
            Case ""
                If (Not cboAENo Is Nothing) Then
                    If (cboAENo.Text.Trim <> "") Then
                        If (Me.rbSec.Checked) Then
                            Me.txtAEName.Text = cls.lFncGetAEName(cboAENo.Text.Trim, "S")
                        Else
                            Me.txtAEName.Text = cls.lFncGetAEName(cboAENo.Text.Trim, "F")
                        End If
                    End If
                End If
            Case "From"
                If (Not Me.cbAEFrom Is Nothing) Then
                    If (Me.cbAEFrom.Text.Trim <> "") Then
                        If (Me.rbCopySec.Checked) Then
                            Me.txtAEFrom.Text = cls.lFncGetAEName(Me.cbAEFrom.Text.Trim, "S")
                        Else
                            Me.txtAEFrom.Text = cls.lFncGetAEName(Me.cbAEFrom.Text.Trim, "F")
                        End If
                    End If
                End If
            Case "To"
                If (Not Me.cbAETo Is Nothing) Then
                    If (Me.cbAETo.Text.Trim <> "") Then
                        If (Me.rbCopySec.Checked) Then
                            Me.txtAETo.Text = cls.lFncGetAEName(Me.cbAETo.Text.Trim, "S")
                        Else
                            Me.txtAETo.Text = cls.lFncGetAEName(Me.cbAETo.Text.Trim, "F")
                        End If
                    End If
                End If
        End Select
    End Sub

    Private Sub cbAETo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAETo.LostFocus
        Me.cbAETo.Text = Me.cbAETo.Text.ToUpper
        lSubGetAEName("To")
    End Sub

    Private Sub cbAETo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbAETo.SelectedIndexChanged
        lSubGetAEName("To")
    End Sub

    Private Sub cbAEFrom_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAEFrom.LostFocus
        Me.cbAEFrom.Text = Me.cbAEFrom.Text.ToUpper
        lSubGetAEName("From")
    End Sub

    Private Sub cbAEFrom_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAEFrom.SelectedIndexChanged
        lSubGetAEName("From")
    End Sub

    Private Sub btnCopy_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCopy.Click
        Dim lstrMonth = Me.cbCopyYear.Text & Format(Val(Me.cbCopyMonth.Text), "00")
        If Not cls.lFncChkAE(Me.cbAEFrom.Text.Trim, IIf(Me.rbCopySec.Checked, "S", "F"), True, lstrMonth) Then
            GSubShowInfo(GFncGetSysMsg(31))
            Me.cbAEFrom.Focus()
            Return
        End If
        If Not cls.lFncChkAE(Me.cbAETo.Text.Trim, IIf(Me.rbCopySec.Checked, "S", "F"), False, lstrMonth) Then
            GSubShowInfo(GFncGetSysMsg(31))
            Me.cbAETo.Focus()
            Return
        End If
        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            If Not cls.lFncCopyAE(Me.cbAEFrom.Text.Trim, Me.cbAETo.Text.Trim, lstrMonth, IIf(Me.rbCopySec.Checked, "S", "F")) Then
                Me.cbAEFrom.Focus()
                Return
            End If
        End If
    End Sub


    Private Sub btnAEInfoSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAEInfoSearch.Click
        Dim ldtAE As DataTable = Nothing
        ldtAE = cls.lFncGetAEFullList(Me.txtSrchAEInfo.Text).Tables(0)
        Me.dgvAEInfoList.DataSource = ldtAE
        If dgvAEInfoList.Rows.Count > 0 Then
            Me.dgvAEInfoList_SelectionChanged(Nothing, System.EventArgs.Empty)
        Else
            Me.txtInfoAENo.Text = ""
            Me.txtInfoAEName.Text = ""
            Me.txtInfoAENameS.Text = ""
            Me.txtInfoAENameF.Text = ""
            Me.txtBankCode.Text = ""
            Me.txtBankAcc.Text = ""
            Me.cbIR56M.Checked = False
        End If
    End Sub
 
End Class
