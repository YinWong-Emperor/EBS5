Imports System.Data.SqlClient
Public Class frmCoupons

    Dim cls As New clsCoupon
    Dim selectedFunction As Integer = 0
    Dim oldAcc As String = String.Empty
    Dim oldPlan As Integer = -1

    Private Sub frmCoupons_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDGV()
        loadCombo()
    End Sub
    Private Sub loadDGV()
        Dim dt As DataTable
        dt = cls.FncLoadDGV()
        Me.dgvCoupon.DataSource = dt
        Me.dgvCoupon.DefaultCellStyle.BackColor = Color.Linen
        Me.dgvCoupon.ReadOnly = True
    End Sub
    Private Sub loadCombo()
        Dim dt As DataTable
        Dim dr As DataRow
        Me.cmbSAcc.Items.Clear()
        dt = cls.FncLoadAcc()
        Me.cmbSAcc.Items.Add("")
        For Each dr In dt.Rows
            Me.cmbSAcc.Items.Add(GFncNoNullString(dr.Item(0)))
        Next
        dt.Clear()
        Me.cmbSStatus.Items.Clear()
        Me.cmbSStatus.Items.Add("")
        Me.cmbSStatus.Items.Add("Active")
        Me.cmbSStatus.Items.Add("Void")
        Me.cmbSStatus.Items.Add("Expired")
        Me.cmbSStatus.Items.Add("Exceeded")
        Me.cmbSStatus.Items.Add("Consumed")
        Me.cmbPlanCode.Items.Clear()
        Dim tempcls As New clsCouponPlan
        dt = tempcls.FncLoadCombo()
        tempcls = Nothing
        Me.cmbPlanCode.Items.Add("")
        For Each dr In dt.Rows
            Me.cmbPlanCode.Items.Add(GFncNoNullString(dr.Item(0)))
        Next
        dt.Clear()
    End Sub
    Private Sub dgvCoupon_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvCoupon.SelectionChanged
        If Me.dgvCoupon.Rows.Count > 0 Then
            Me.txtAcc.Text = CStr(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("account_no").Value))
            Me.dptPruD.Text = CDate(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("purchase_date").Value))
            Me.dtpExpD.Text = CDate(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("expiry_date").Value))
            Me.txtStatus.Text = CStr(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("status").Value))
            Me.txtPlanID.Text = CInt(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("coupon_plan_id").Value))
            Me.cmbPlanCode.Text = CStr(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("plan_code").Value))
            Me.txtCreateBy.Text = CStr(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("created_by").Value))
            Me.txtCreatTime.Text = CDate(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("creation_date").Value))
            Me.ambPrice.Text = CDbl(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("price").Value))
            Me.ambGracePeriod.Text = CInt(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("grace_period").Value))
            Me.ambLimit.Text = CDbl(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("turnover_limit").Value))
            Me.ambGVP.Text = CInt(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("grace_value_percentage").Value))
            Me.ambGV.Text = CDbl(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("grace_value").Value))
            Me.ambCVID.Text = CInt(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("coupon_value_id").Value))
            Me.ambVC.Text = CDbl(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("value_consumed").Value))
            Me.ambGVC.Text = CDbl(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("grace_value_consumed").Value))
        Else
            cleanBox()
        End If
    End Sub
    Private Sub setValue(ByVal id As Integer)
        Me.txtAcc.Text = CStr(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("account_no").Value))
        Me.dptPruD.Text = CDate(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("purchase_date").Value))
        Me.dtpExpD.Text = CDate(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("expiry_date").Value))
        Me.txtStatus.Text = CStr(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("status").Value))
        Me.txtPlanID.Text = CInt(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("coupon_plan_id").Value))
        Me.cmbPlanCode.Text = CStr(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("plan_code").Value))
        Me.txtCreateBy.Text = CStr(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("created_by").Value))
        Me.txtCreatTime.Text = CDate(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("creation_date").Value))
        Me.ambPrice.Text = CDbl(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("price").Value))
        Me.ambGracePeriod.Text = CInt(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("grace_period").Value))
        Me.ambLimit.Text = CDbl(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("turnover_limit").Value))
        Me.ambGVP.Text = CInt(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("grace_value_percentage").Value))
        Me.ambGV.Text = CDbl(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("grace_value").Value))
        Me.ambCVID.Text = CInt(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("coupon_value_id").Value))
        Me.ambVC.Text = CDbl(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("value_consumed").Value))
        Me.ambGVC.Text = CDbl(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("grace_value_consumed").Value))
        Me.ambEEP.Text = CInt(GFncNoNullString(Me.dgvCoupon.Rows(id).Cells("expiry_extension_period").Value))
    End Sub
    Private Sub cleanBox()
        Me.txtAcc.Text = String.Empty
        Me.dptPruD.Text = String.Empty
        Me.dtpExpD.Text = String.Empty
        Me.txtStatus.Text = String.Empty
        Me.txtPlanID.Text = String.Empty
        Me.cmbPlanCode.Text = String.Empty
        Me.txtCreateBy.Text = String.Empty
        Me.txtCreatTime.Text = String.Empty
        Me.ambPrice.Text = String.Empty
        Me.ambGracePeriod.Text = String.Empty
        Me.ambLimit.Text = String.Empty
        Me.ambGVP.Text = String.Empty
        Me.ambGV.Text = String.Empty
        Me.ambCVID.Text = String.Empty
        Me.ambVC.Text = String.Empty
        Me.ambGVC.Text = String.Empty
        Me.cmbSAcc.Text = String.Empty
        Me.cmbSStatus.Text = String.Empty
        Me.ambEEP.Text = String.Empty
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled = True Then
            cleanBox()
            setBtn(True)
            selectedFunction = 0
            oldAcc = String.Empty
            oldPlan = -1
            If Me.dgvCoupon.Rows.Count > 0 Then
                Me.dgvCoupon.Rows(0).Selected = True
                dgvCoupon_SelectionChanged(Nothing, System.EventArgs.Empty)
                setValue(0)
            End If
        Else
            Me.Close()
        End If
    End Sub
    Private Sub setBtn(ByVal flag As Boolean)
        Me.dptPruD.Enabled = Not flag
        Me.cmbSAcc.Enabled = flag
        Me.cmbSStatus.Enabled = flag
        Me.txtAcc.Enabled = Not flag
        Me.cmbPlanCode.Enabled = Not flag
        Me.dtpExpD.Enabled = Not flag
        Me.btnSave.Enabled = Not flag
        Me.btnNew.Enabled = flag
        Me.btnDelete.Enabled = flag
        'Me.btnEdit.Enabled = flag
        Me.btnSearch.Enabled = flag
        Me.dgvCoupon.Enabled = flag
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dt As DataTable
        dt = cls.FncSearch(CStr(GFncNoNullString(Me.cmbSAcc.Text)), CStr(GFncNoNullString(Me.cmbSStatus.Text)))
        Me.dgvCoupon.DataSource = dt
    End Sub
    Private Sub dtpExpD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpExpD.ValueChanged
        If GFncNoNullString(Me.dtpExpD.Text) <> String.Empty And GFncNoNullString(Me.dptPruD.Text) <> String.Empty Then
            If CDate(GFncNoNullString(Me.dtpExpD.Text)) < CDate(GFncNoNullString(Me.dptPruD.Text)) Then
                Me.dtpExpD.Text = CDate(DateAdd("yyyy", 1, CDate(GFncNoNullString(Me.dptPruD.Text))))
            End If
        End If
    End Sub
    Private Sub cmbPlanCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPlanCode.SelectedIndexChanged
        Dim dt As DataTable = Nothing
        If GFncNoNullString(Me.cmbPlanCode.Text) <> String.Empty Then
            dt = cls.FncGetPlan(CStr(Me.cmbPlanCode.Text))
            If dt.Rows.Count = 1 Then
                Me.txtPlanID.Text = CInt(GFncNoNullString(dt.Rows(0).Item("coupon_plan_id")))
                Me.ambPrice.Text = CDbl(GFncNoNullString(dt.Rows(0).Item("price")))
                Me.ambGracePeriod.Text = CInt(GFncNoNullString(dt.Rows(0).Item("grace_period")))
                Me.ambLimit.Text = CDbl(GFncNoNullString(dt.Rows(0).Item("turnover_limit"))) / 100000000
                Me.ambGVP.Text = CInt(GFncNoNullString(dt.Rows(0).Item("grace_value_percentage")))
                Me.ambGV.Text = CDbl(CDbl(Me.ambLimit.Text) * CInt(Me.ambGVP.Text) / 100)
                Me.ambEEP.Text = CInt(GFncNoNullString(dt.Rows(0).Item("expiry_extension_period")))
            Else
                Return
            End If
        Else
            Me.txtPlanID.Text = String.Empty
            Me.ambPrice.Text = String.Empty
            Me.ambGracePeriod.Text = String.Empty
            Me.ambLimit.Text = String.Empty
            Me.ambGVP.Text = String.Empty
            Me.ambGV.Text = String.Empty
        End If
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        setBtn(False)
        cleanBox()
        selectedFunction = 1
        Me.dptPruD.Text = CDate(Date.Today)
        Me.dtpExpD.Text = CDate(DateAdd("yyyy", 1, CDate(GFncNoNullString(Me.dptPruD.Text))))
        Me.txtCreateBy.Text = Trim(GStrloginID)
        Me.txtCreatTime.Text = CStr(Date.Now)
        Me.ambVC.Text = CDbl(0)
        Me.ambGVC.Text = CDbl(0)
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        setBtn(False)
        If GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("status").Value) = "Active" Then
            'If CDbl(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("value_consumed").Value)) = 0 Then
            Dim op = MessageBox.Show("Confirm to void?", "", MessageBoxButtons.YesNo)
            If op = Windows.Forms.DialogResult.Yes Then
                If cls.FncVoid(CStr(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("account_no").Value)), CInt(GFncNoNullString(Me.dgvCoupon.CurrentRow.Cells("coupon_plan_id").Value))) Then
                    Dim tempAcc As String = CStr(GFncNoNullString(Me.txtAcc.Text))
                    Dim tempPlan As String = CStr(GFncNoNullString(Me.cmbPlanCode.Text))
                    loadDGV()
                    loadCombo()
                    'Dim Idrow As Integer
                    'If Me.dgvCoupon.Rows.Count > 0 Then
                    '    For Idrow = 0 To Me.dgvCoupon.Rows.Count - 1
                    '        If CStr(GFncNoNullString(Me.dgvCoupon.Item("account_no", Idrow).Value)) = tempAcc And CStr(GFncNoNullString(Me.dgvCoupon.Item("plan_code", Idrow).Value)) = tempPlan Then
                    '            Me.dgvCoupon.Rows(Idrow).Selected = True
                    '            dgvCoupon_SelectionChanged(Nothing, System.EventArgs.Empty)
                    '            setValue(Idrow)
                    '            Exit For
                    '        End If
                    '    Next
                    'End If
                    dgvCoupon_SelectionChanged(Nothing, System.EventArgs.Empty)
                    GSubShowInfo("Updated successfully")
                End If
            End If
            'Else
            '   GSubShowInfo("Value consumed is greater than 0")
            'End If
        Else
            GSubShowInfo("This record can not be set to ""Void""")
        End If
        setBtn(True)
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            If GFncNoNullString(Me.txtAcc.Text) <> String.Empty And GFncNoNullString(Me.cmbPlanCode.Text) <> String.Empty Then
                If selectedFunction = 1 Then
                    Dim op = MessageBox.Show("Confirm to add?", "", MessageBoxButtons.YesNo)
                    If op = Windows.Forms.DialogResult.Yes Then
                        If Not cls.FncDoubleInsert(GFncNoNullString(Me.txtAcc.Text), CInt(GFncNoNullString(Me.txtPlanID.Text)), MyTrans) Then
                            Dim id As Integer
                            id = cls.FncInsert(CDbl(Me.ambVC.Text), CDbl(Me.ambGVC.Text), Trim(GStrloginID), MyTrans)
                            If id <> -1 Then
                                Me.ambCVID.Text = id
                            Else
                                If GSCnSqlConn.State <> ConnectionState.Closed Then
                                    If (MyTrans IsNot Nothing) Then
                                        MyTrans.Rollback()
                                    End If
                                End If
                                Return
                            End If
                            If cls.FncAdd(CInt(GFncNoNullString(Me.ambCVID.Text)), GFncNoNullString(Me.txtAcc.Text), CInt(GFncNoNullString(Me.txtPlanID.Text)), _
                                        CDbl(GFncNoNullString(Me.ambLimit.Text)) * 100000000, CInt(GFncNoNullString(Me.ambGVP.Text)), CInt(GFncNoNullString(Me.ambGracePeriod.Text)), _
                                        CInt(GFncNoNullString(Me.ambEEP.Text)), CDate(GFncNoNullString(Me.dptPruD.Text)), CDate(GFncNoNullString(Me.dtpExpD.Text)), _
                                        CDbl(GFncNoNullString(Me.ambGV.Text)) * 100000000, CDate(GFncNoNullString(Me.txtCreatTime.Text)), GFncNoNullString(Me.txtCreateBy.Text), Trim(GStrloginID), MyTrans) Then
                                MyTrans.Commit()
                                Dim tempAcc As String = CStr(GFncNoNullString(Me.txtAcc.Text))
                                Dim tempPlan As String = CStr(GFncNoNullString(Me.cmbPlanCode.Text))
                                loadDGV()
                                loadCombo()
                                Dim Idrow As Integer
                                If Me.dgvCoupon.Rows.Count > 0 Then
                                    For Idrow = 0 To Me.dgvCoupon.Rows.Count - 1
                                        If CStr(GFncNoNullString(Me.dgvCoupon.Item("account_no", Idrow).Value)) = tempAcc And CStr(GFncNoNullString(Me.dgvCoupon.Item("plan_code", Idrow).Value)) = tempPlan Then
                                            Me.dgvCoupon.Rows(Idrow).Selected = True
                                            dgvCoupon_SelectionChanged(Nothing, System.EventArgs.Empty)
                                            setValue(Idrow)
                                            Exit For
                                        End If
                                    Next
                                End If
                            Else
                                If GSCnSqlConn.State <> ConnectionState.Closed Then
                                    If (MyTrans IsNot Nothing) Then
                                        MyTrans.Rollback()
                                    End If
                                End If
                            End If
                        Else
                            If GSCnSqlConn.State <> ConnectionState.Closed Then
                                If (MyTrans IsNot Nothing) Then
                                    MyTrans.Rollback()
                                End If
                            End If
                            GSubShowInfo("Record already existed")
                            Return
                        End If
                    Else
                        cleanBox()
                        If GSCnSqlConn.State <> ConnectionState.Closed Then
                            If (MyTrans IsNot Nothing) Then
                                MyTrans.Rollback()
                            End If
                        End If
                        'cls.FncDelete(CInt(Me.ambCVID.Text))
                        If Me.dgvCoupon.Rows.Count > 0 Then
                            Me.dgvCoupon.Rows(0).Selected = True
                            dgvCoupon_SelectionChanged(Nothing, System.EventArgs.Empty)
                            setValue(0)
                        End If
                    End If
                End If
            Else
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                End If
                GSubShowInfo("Account No. and Couplan Plan Code can not be empty")
                Return
            End If
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        setBtn(True)
        selectedFunction = 0
        oldAcc = String.Empty
        oldPlan = -1
    End Sub
    Private Sub dtpPruD_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dptPruD.ValueChanged
        If GFncNoNullString(Me.dtpExpD.Text) <> String.Empty Then
            Me.dtpExpD.Text = CDate(DateAdd("yyyy", 1, CDate(GFncNoNullString(Me.dptPruD.Text))))
        End If
    End Sub
End Class
