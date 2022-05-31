Public Class frmCouponPlan

    Dim cls As New clsCouponPlan
    Dim selectedFunction As Integer = 0
    Dim oldCode As String = String.Empty

    Private Sub frmCouponPlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDGV()
        loadCombo()
    End Sub
    Private Sub loadDGV()
        Dim dt As DataTable
        dt = cls.FncLoadDGV()
        Me.dgvCouponPlan.DataSource = dt
        Me.dgvCouponPlan.DefaultCellStyle.BackColor = Color.Linen
        Me.dgvCouponPlan.ReadOnly = True
        'Me.txtPlanCode.BackColor = Color.Linen
    End Sub
    Private Sub loadCombo()
        Me.cmbPlanCode.Items.Clear()
        Dim dt As DataTable = cls.FncLoadCombo()
        Me.cmbPlanCode.Items.Add("")
        For Each dr As DataRow In dt.Rows
            Me.cmbPlanCode.Items.Add(GFncNoNullString(dr.Item(0)))
        Next
        dt.Clear()
    End Sub
    Private Sub dgvCouponPlan_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvCouponPlan.SelectionChanged
        If Me.dgvCouponPlan.Rows.Count > 0 Then
            Me.txtPlanCode.Text = CStr(GFncNoNullString(Me.dgvCouponPlan.CurrentRow.Cells("plan_code").Value))
            Me.ambPrice.Text = CDbl(GFncNoNullString(Me.dgvCouponPlan.CurrentRow.Cells("price").Value))
            Me.nmbTurnover.Text = CDbl(GFncNoNullString(Me.dgvCouponPlan.CurrentRow.Cells("turnover_limit").Value))
            Me.nmbGraceValue.Text = CInt(GFncNoNullString(Me.dgvCouponPlan.CurrentRow.Cells("grace_value_percentage").Value))
            Me.nmbGracePeriod.Text = CInt(GFncNoNullString(Me.dgvCouponPlan.CurrentRow.Cells("grace_period").Value))
            Me.nmbExpiry.Text = CInt(GFncNoNullString(Me.dgvCouponPlan.CurrentRow.Cells("expiry_extension_period").Value))
            'Me.txtTime.Text = CDate(GFncNoNullString(Me.dgvCouponPlan.CurrentRow.Cells("lstupddate").Value))
            'Me.txtUser.Text = CStr(GFncNoNullString(Me.dgvCouponPlan.CurrentRow.Cells("lstupdby").Value))
        Else
            cleanBox()
        End If
    End Sub
    Private Sub setValue(ByVal id As Integer)
        Me.txtPlanCode.Text = CStr(GFncNoNullString(Me.dgvCouponPlan.Rows(id).Cells("plan_code").Value))
        Me.ambPrice.Text = CDbl(GFncNoNullString(Me.dgvCouponPlan.Rows(id).Cells("price").Value))
        Me.nmbTurnover.Text = CDbl(GFncNoNullString(Me.dgvCouponPlan.Rows(id).Cells("turnover_limit").Value))
        Me.nmbGraceValue.Text = CInt(GFncNoNullString(Me.dgvCouponPlan.Rows(id).Cells("grace_value_percentage").Value))
        Me.nmbGracePeriod.Text = CInt(GFncNoNullString(Me.dgvCouponPlan.Rows(id).Cells("grace_period").Value))
        Me.nmbExpiry.Text = CInt(GFncNoNullString(Me.dgvCouponPlan.Rows(id).Cells("expiry_extension_period").Value))
        'Me.txtTime.Text = CDate(GFncNoNullString(Me.dgvCouponPlan.Rows(id).Cells("lstupddate").Value))
        'Me.txtUser.Text = CStr(GFncNoNullString(Me.dgvCouponPlan.Rows(id).Cells("lstupdby").Value))
    End Sub
    Private Sub cleanBox()
        Me.cmbPlanCode.Text = ""
        Me.txtPlanCode.Text = ""
        Me.ambPrice.Text = 0
        Me.nmbTurnover.Text = 0
        Me.nmbGraceValue.Text = 0
        Me.nmbGracePeriod.Text = 0
        Me.nmbExpiry.Text = 0
        'Me.txtTime.Text = Date.Now
        'Me.txtUser.Text = ""
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled = True Then
            cleanBox()
            setBtn(True)
            selectedFunction = 0
            oldCode = String.Empty
            If Me.dgvCouponPlan.Rows.Count > 0 Then
                Me.dgvCouponPlan.Rows(0).Selected = True
                dgvCouponPlan_SelectionChanged(Nothing, System.EventArgs.Empty)
                setValue(0)
            End If
        Else
            Me.Close()
        End If
    End Sub
    Private Sub setBtn(ByVal flag As Boolean)
        Me.txtPlanCode.Enabled = Not flag
        Me.ambPrice.Enabled = Not flag
        Me.nmbTurnover.Enabled = Not flag
        Me.nmbGraceValue.Enabled = Not flag
        Me.nmbGracePeriod.Enabled = Not flag
        Me.nmbExpiry.Enabled = Not flag
        Me.btnSave.Enabled = Not flag
        Me.cmbPlanCode.Enabled = flag
        Me.btnNew.Enabled = flag
        Me.btnDelete.Enabled = flag
        Me.btnEdit.Enabled = flag
        Me.btnSearch.Enabled = flag
        Me.dgvCouponPlan.Enabled = flag
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        setBtn(False)
        cleanBox()
        selectedFunction = 1
        'Me.txtUser.Text = Trim(GStrloginID)
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        setBtn(False)
        selectedFunction = 2
        oldCode = CStr(GFncNoNullString(Me.txtPlanCode.Text))
        Me.cmbPlanCode.Text = ""
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        setBtn(False)
        Dim op = MessageBox.Show("Confirm to delete?", "", MessageBoxButtons.YesNo)
        If op = Windows.Forms.DialogResult.Yes Then
            If cls.FncDelete(CStr(GFncNoNullString(Me.dgvCouponPlan.CurrentRow.Cells("plan_code").Value))) Then
                cleanBox()
                loadDGV()
                loadCombo()
                dgvCouponPlan_SelectionChanged(Nothing, System.EventArgs.Empty)
                MessageBox.Show("Deleted successfully")
            End If
        End If
        setBtn(True)
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Me.txtTime.Text = Date.Now
        If GFncNoNullString(Me.ambPrice.Text) = String.Empty Then
            Me.ambPrice.Text = 0
        End If
        If GFncNoNullString(Me.nmbTurnover.Text) = String.Empty Then
            Me.nmbTurnover.Text = 0
        End If
        If GFncNoNullString(Me.nmbGraceValue.Text) = String.Empty Then
            Me.nmbGraceValue.Text = 0
        End If
        If GFncNoNullString(Me.nmbGracePeriod.Text) = String.Empty Then
            Me.nmbGracePeriod.Text = 0
        End If
        If GFncNoNullString(Me.nmbExpiry.Text) = String.Empty Then
            Me.nmbExpiry.Text = 0
        End If
        If Me.txtPlanCode.Text <> String.Empty Then
            If selectedFunction = 1 Then
                Dim op = MessageBox.Show("Confirm to add?", "", MessageBoxButtons.YesNo)
                If op = Windows.Forms.DialogResult.Yes Then
                    If Not cls.FncDoubleInsert(CStr(GFncNoNullString(Me.txtPlanCode.Text))) Then
                        If cls.FncAdd(CStr(GFncNoNullString(Me.txtPlanCode.Text)), CDbl(GFncNoNullString(Me.ambPrice.Text)) * 1000, _
                                                        CDbl(GFncNoNullString(Me.nmbTurnover.Text)) * 100000000, CInt(GFncNoNullString(Me.nmbGraceValue.Text)), _
                                                        CInt(GFncNoNullString(Me.nmbGracePeriod.Text)), CInt(GFncNoNullString(Me.nmbExpiry.Text)), _
                                                        Trim(GStrloginID)) Then
                            Dim tempCode As String = CStr(GFncNoNullString(Me.txtPlanCode.Text))
                            loadDGV()
                            loadCombo()
                            Dim Idrow As Integer
                            If Me.dgvCouponPlan.Rows.Count > 0 Then
                                For Idrow = 0 To Me.dgvCouponPlan.Rows.Count - 1
                                    If GFncNoNullString(Me.dgvCouponPlan.Item("plan_code", Idrow).Value) = tempCode Then
                                        Me.dgvCouponPlan.Rows(Idrow).Selected = True
                                        dgvCouponPlan_SelectionChanged(Nothing, System.EventArgs.Empty)
                                        setValue(Idrow)
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Else
                        GSubShowInfo("Record already existed")
                        Return
                    End If
                Else
                    cleanBox()
                    If Me.dgvCouponPlan.Rows.Count > 0 Then
                        Me.dgvCouponPlan.Rows(0).Selected = True
                        dgvCouponPlan_SelectionChanged(Nothing, System.EventArgs.Empty)
                        setValue(0)
                    End If
                End If
            ElseIf selectedFunction = 2 Then
                Dim op = MessageBox.Show("Confirm to Edit?", "", MessageBoxButtons.YesNo)
                If op = Windows.Forms.DialogResult.Yes Then
                    If CStr(GFncNoNullString(Me.txtPlanCode.Text)) = oldCode Or Not cls.FncDoubleInsert(CStr(GFncNoNullString(Me.txtPlanCode.Text))) Then
                        If cls.FncEdit(CStr(GFncNoNullString(Me.txtPlanCode.Text)), CDbl(GFncNoNullString(Me.ambPrice.Text)) * 1000, _
                                                        CDbl(GFncNoNullString(Me.nmbTurnover.Text)) * 100000000, CInt(GFncNoNullString(Me.nmbGraceValue.Text)), _
                                                        CInt(GFncNoNullString(Me.nmbGracePeriod.Text)), CInt(GFncNoNullString(Me.nmbExpiry.Text)), _
                                                        Trim(GStrloginID), oldCode) Then
                            Dim tempCode As String = CStr(GFncNoNullString(Me.txtPlanCode.Text))
                            loadDGV()
                            loadCombo()
                            Dim Idrow As Integer
                            If Me.dgvCouponPlan.Rows.Count > 0 Then
                                For Idrow = 0 To Me.dgvCouponPlan.Rows.Count - 1
                                    If GFncNoNullString(Me.dgvCouponPlan.Item("plan_code", Idrow).Value) = tempCode Then
                                        Me.dgvCouponPlan.Rows(Idrow).Selected = True
                                        dgvCouponPlan_SelectionChanged(Nothing, System.EventArgs.Empty)
                                        setValue(Idrow)
                                        Exit For
                                    End If
                                Next
                            End If
                        End If
                    Else
                        GSubShowInfo("Record already existed")
                        Return
                    End If
                Else
                    cleanBox()
                    If Me.dgvCouponPlan.Rows.Count > 0 Then
                        Me.dgvCouponPlan.Rows(0).Selected = True
                        dgvCouponPlan_SelectionChanged(Nothing, System.EventArgs.Empty)
                        setValue(0)
                    End If
                End If
            End If
        Else
            GSubShowInfo("Plan code can not be empty")
            Return
        End If
        setBtn(True)
        selectedFunction = 0
        oldCode = String.Empty
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dt As DataTable
        dt = cls.FncSearch(CStr(GFncNoNullString(Me.cmbPlanCode.Text)))
        Me.dgvCouponPlan.DataSource = dt
    End Sub

End Class
