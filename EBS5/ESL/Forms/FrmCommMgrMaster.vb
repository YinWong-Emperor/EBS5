Public Class FrmCommMgrMaster

    Dim cls As New ClsCommMgrMaster
    Dim action As String = ""
    Dim preMgrNo As String = ""
    Dim preMgrGrp As String = ""
    Dim ldtEmpty As DataTable = Nothing

    Private Sub FrmCommMgrMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        Dim ldtMgr As DataTable = Nothing
        Dim MaxDate As String = GfncGetMonth()
        For year As Integer = MaxDate.Substring(0, 4) - 5 To MaxDate.Substring(0, 4) + 5
            Me.cboSearchYear.Items.Add(year)
        Next
        For month As Integer = 1 To 12
            Me.cboSearchMonth.Items.Add(month)
        Next
        Me.cboSearchYear.Text = MaxDate.Substring(0, 4)
        Me.cboSearchMonth.Text = Val(MaxDate.Substring(4, 2))
        'ldtMgr = cls.lFncGetAEFullList()
        'For i As Integer = 0 To ldtMgr.Rows.Count - 1
        '    Me.cboMgrNo.Items.Add(ldtMgr.Rows(i).Item("ae_no"))
        'Next
        ldtEmpty = cls.lFncGetMgrDetail("", "", "")
        refreshList()
    End Sub

    Private Sub cboSearchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchYear.SelectedIndexChanged
        refreshList()
    End Sub

    Private Sub cboSearchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchMonth.SelectedIndexChanged
        refreshList()
    End Sub

    Private Sub refreshList()
        Dim txmonth As String = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        Me.dgvDetail.DataSource = ldtEmpty
        Me.dgvManList.DataSource = cls.lFncGetMgrList(txmonth)
    End Sub

    Private Sub dgvManList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvManList.SelectionChanged
        If Me.dgvManList.Rows.Count > 0 Then
            If Me.dgvManList.SelectedCells.Count > 0 Then
                Me.txtMgrNo.Text = Me.dgvManList.CurrentRow.Cells(0).Value
                Me.txtMgrGrp.Text = Me.dgvManList.CurrentRow.Cells(1).Value
                Dim txmonth As String = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
                Me.dgvDetail.DataSource = cls.lFncGetMgrDetail(Me.txtMgrNo.Text, Me.txtMgrGrp.Text, txmonth)
            Else
                Me.txtMgrNo.Text = ""
                Me.txtMgrGrp.Text = ""
                Me.txtMonth.Text = ""
            End If
        Else
            Me.txtMgrNo.Text = ""
            Me.txtMgrGrp.Text = ""
            Me.txtMonth.Text = ""
        End If
    End Sub

    Private Sub dgvDetail_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvDetail.SelectionChanged
        If Me.dgvDetail.Rows.Count > 0 Then
            If Me.dgvDetail.SelectedCells.Count > 0 Then
                Me.txtMonth.Text = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells(0).Value)
                If (Me.dgvDetail.CurrentRow.Cells(1).Value = "Y") Then
                    Me.cbStandard.Checked = True
                Else
                    Me.cbStandard.Checked = False
                End If
                If (Me.dgvDetail.CurrentRow.Cells(2).Value <> "") Then
                    Me.rbSec.Checked = True
                    If (Me.dgvDetail.CurrentRow.Cells(2).Value = "Turnover") Then
                        Me.rbTurnover.Checked = True
                    ElseIf (Me.dgvDetail.CurrentRow.Cells(2).Value = "Brokerage") Then
                        Me.rbBrokerage.Checked = True
                    ElseIf (Me.dgvDetail.CurrentRow.Cells(2).Value = "Rebate") Then
                        Me.rbRebate.Checked = True
                    End If
                Else
                    Me.rbFut.Checked = True
                    If (Me.dgvDetail.CurrentRow.Cells(3).Value = "Turnover") Then
                        Me.rbTurnover.Checked = True
                    ElseIf (Me.dgvDetail.CurrentRow.Cells(3).Value = "Brokerage") Then
                        Me.rbBrokerage.Checked = True
                    ElseIf (Me.dgvDetail.CurrentRow.Cells(3).Value = "Rebate") Then
                        Me.rbRebate.Checked = True
                    End If
                End If
            Else
                Me.txtMonth.Text = ""
                Me.rbTurnover.Checked = True
                Me.rbSec.Checked = True
            End If
        Else
            Me.txtMonth.Text = ""
            Me.rbTurnover.Checked = True
            Me.rbSec.Checked = True
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        action = "A"
        preMgrNo = Me.txtMgrNo.Text
        preMgrGrp = Me.txtMgrGrp.Text
        lSubControl(True)
        Me.txtMgrNo.Enabled = True
        Me.txtMgrGrp.Enabled = True
        Me.rbSec.Enabled = True
        Me.rbFut.Enabled = True
        Me.txtMgrNo.Text = ""
        Me.txtMgrGrp.Text = ""
        Me.txtMonth.Text = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        Me.rbSec.Checked = True
        Me.cbStandard.Checked = False
        Me.rbTurnover.Checked = True
        Me.txtMgrNo.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If (Me.dgvDetail.Rows.Count > 0) Then
            action = "E"
            preMgrNo = Me.txtMgrNo.Text
            preMgrGrp = Me.txtMgrGrp.Text
            lSubControl(True)
            Me.rbSec.Focus()
        Else
            GSubShowInfo(GFncGetSysMsg(56))
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim mgr_no As String = ""
        Dim mgr_grp As String = ""
        Dim txmonth As String = ""
        Dim sec_fut As String = ""
        If Me.dgvDetail.Rows.Count > 0 Then
            If (GSubShowYNConfirm(GFncGetSysMsg(65) & " " & GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
                If GFncCheckCommStatus() Then
                    Return
                End If
                mgr_no = Me.txtMgrNo.Text
                mgr_grp = Me.txtMgrGrp.Text
                txmonth = GFncNoNullString(Me.dgvDetail.CurrentRow.Cells(0).Value)
                If (Me.rbSec.Checked) Then
                    sec_fut = "S"
                Else
                    sec_fut = "F"
                End If
                If (cls.lFncDeleteMgr(mgr_no, mgr_grp, txmonth, sec_fut)) Then
                    refreshList()
                    For i As Integer = 0 To Me.dgvManList.Rows.Count - 1
                        If ((Me.dgvManList.Rows(i).Cells(0).Value = mgr_no) And (Me.dgvManList.Rows(i).Cells(1).Value = mgr_grp)) Then
                            Me.dgvManList.Rows(i).Cells(0).Selected = True
                            Me.dgvManList.FirstDisplayedScrollingRowIndex = i
                            Exit For
                        End If
                    Next
                    dgvManList_SelectionChanged(Nothing, System.EventArgs.Empty)
                End If
            End If
        Else
            GSubShowInfo(GFncGetSysMsg(56))
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim mgr_no As String = Me.txtMgrNo.Text.Trim
        Dim mgr_grp As String = Me.txtMgrGrp.Text.Trim
        Dim txmonth As String = Me.txtMonth.Text
        Dim turnoverS_flag As String = "0"
        Dim brokerageS_flag As String = "0"
        Dim rebateS_flag As String = "0"
        Dim turnoverF_flag As String = "0"
        Dim brokerageF_flag As String = "0"
        Dim rebateF_flag As String = "0"
        Dim isDefaultS As String = "0"
        Dim isDefaultF As String = "0"
        Dim sec_fut As String = ""
        If (Me.rbSec.Checked) Then
            If (Me.rbTurnover.Checked) Then
                turnoverS_flag = "1"
            ElseIf (Me.rbBrokerage.Checked) Then
                brokerageS_flag = "1"
            ElseIf (Me.rbRebate.Checked) Then
                rebateS_flag = "1"
            End If
            If (Me.cbStandard.Checked) Then
                isDefaultS = "1"
            End If
            sec_fut = "S"
        Else
            If (Me.rbTurnover.Checked) Then
                turnoverF_flag = "1"
            ElseIf (Me.rbBrokerage.Checked) Then
                brokerageF_flag = "1"
            ElseIf (Me.rbRebate.Checked) Then
                rebateF_flag = "1"
            End If
            If (Me.cbStandard.Checked) Then
                isDefaultF = "1"
            End If
            sec_fut = "F"
        End If
        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            'validation
            If (mgr_no.Length <= 0) Then
                GSubShowInfo(GFncGetSysMsg(52))
                Me.txtMgrNo.Focus()
                Return
            End If
            If (cls.lFncIsAE(mgr_no) = False) Then
                If (GSubShowYNConfirm(GFncGetSysMsg(71)) = Windows.Forms.DialogResult.No) Then
                    Me.txtMgrNo.Focus()
                    Return
                End If
            End If
            'update db
            If GFncCheckCommStatus() Then
                Return
            End If
            If (action = "A") Then
                If (cls.lFncValidate(mgr_no, mgr_grp, txmonth, sec_fut) = False) Then
                    GSubShowInfo(GFncGetSysMsg(62))
                    Me.txtMgrNo.Focus()
                    Return
                End If
                cls.lFncAddMgr(mgr_no, mgr_grp, txmonth, turnoverS_flag, brokerageS_flag, rebateS_flag, turnoverF_flag, _
                                brokerageF_flag, rebateF_flag, isDefaultS, isDefaultF)
            ElseIf (action = "E") Then
                cls.lFncEditMgr(mgr_no, mgr_grp, txmonth, turnoverS_flag, brokerageS_flag, rebateS_flag, turnoverF_flag, _
                                brokerageF_flag, rebateF_flag, isDefaultS, isDefaultF, sec_fut)
            End If
            'refresh form
            preMgrNo = mgr_no
            preMgrGrp = mgr_grp
            refreshList()
            For i As Integer = 0 To Me.dgvManList.Rows.Count - 1
                If ((Me.dgvManList.Rows(i).Cells(0).Value = preMgrNo) And (Me.dgvManList.Rows(i).Cells(1).Value = preMgrGrp)) Then
                    Me.dgvManList.Rows(i).Cells(0).Selected = True
                    Me.dgvManList.FirstDisplayedScrollingRowIndex = i
                    Exit For
                End If
            Next
            dgvManList_SelectionChanged(Nothing, System.EventArgs.Empty)
            lSubControl(False)
            Me.txtMgrNo.Enabled = False
            Me.txtMgrGrp.Enabled = False
            Me.rbSec.Enabled = False
            Me.rbFut.Enabled = False
            action = ""
            preMgrNo = ""
            GSubShowInfo(GFncGetSysMsg(8))
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ((action = "A") Or (action = "E")) Then
            refreshList()
            For i As Integer = 0 To Me.dgvManList.Rows.Count - 1
                If ((Me.dgvManList.Rows(i).Cells(0).Value = preMgrNo) And (Me.dgvManList.Rows(i).Cells(1).Value = preMgrGrp)) Then
                    Me.dgvManList.Rows(i).Cells(0).Selected = True
                    Me.dgvManList.FirstDisplayedScrollingRowIndex = i
                    Exit For
                End If
            Next
            dgvManList_SelectionChanged(Nothing, System.EventArgs.Empty)
            lSubControl(False)
            Me.txtMgrNo.Enabled = False
            Me.txtMgrGrp.Enabled = False
            Me.rbSec.Enabled = False
            Me.rbFut.Enabled = False
            action = ""
            preMgrNo = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lSubControl(ByVal flag As Boolean)
        Me.cboSearchYear.Enabled = False
        Me.cboSearchMonth.Enabled = False
        Me.dgvManList.Enabled = Not flag
        Me.dgvDetail.Enabled = Not flag
        'Me.rbSec.Enabled = flag
        'Me.rbFut.Enabled = flag
        Me.cbStandard.Enabled = flag
        Me.rbTurnover.Enabled = flag
        Me.rbBrokerage.Enabled = flag
        Me.rbRebate.Enabled = flag
        Me.btnAdd.Enabled = Not flag
        Me.btnEdit.Enabled = Not flag
        Me.btnDelete.Enabled = Not flag
        Me.btnSave.Enabled = flag
    End Sub

End Class
