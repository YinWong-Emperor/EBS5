Public Class frmCouponEmailList

    Dim cls As New clsCouponEmail
    Dim selectedFunction As Integer = 0
    Dim oldAcc As String = String.Empty
    Dim oldSale As String = String.Empty

    Private Sub frmCouponEmailList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDGV()
        loadCombo()
    End Sub
    Private Sub loadDGV()
        Dim dt As DataTable
        dt = cls.FncLoadDGV()
        Me.dgvEmail.DataSource = dt
        Me.dgvEmail.DefaultCellStyle.BackColor = Color.Linen
        Me.dgvEmail.ReadOnly = True
    End Sub
    Private Sub loadCombo()
        Me.cmbSAcc.Items.Clear()
        Dim dt As DataTable
        Dim dr As DataRow
        dt = cls.FncLoadCombo("account_no")
        Me.cmbSAcc.Items.Add("")
        For Each dr In dt.Rows
            Me.cmbSAcc.Items.Add(GFncNoNullString(dr.Item(0)))
        Next
        dt.Clear()
        Me.cmbSID.Items.Clear()
        dt = cls.FncLoadCombo("sales_id")
        Me.cmbSID.Items.Add("")
        For Each dr In dt.Rows
            Me.cmbSID.Items.Add(GFncNoNullString(dr.Item(0)))
        Next
        dt.Clear()
        Me.cmbAlertID.Items.Clear()
        dt = cls.FncLoadComboAlertID()
        Me.cmbAlertID.Items.Add("")
        For Each dr In dt.Rows
            If GFncNoNullString(dr.Item("type")) = "U" Then
                Me.cmbAlertID.Items.Add("U" & CInt(GFncNoNullString(dr.Item("value"))) & ": " & CInt(GFncNoNullString(dr.Item("value"))) & "% of coupon value consumed")
            ElseIf GFncNoNullString(dr.Item("type")) = "E" Then
                Me.cmbAlertID.Items.Add("E" & CInt(GFncNoNullString(dr.Item("value"))) & ": " & CInt(GFncNoNullString(dr.Item("value"))) & " days before expiry")
            End If
        Next
        dt.Clear()
    End Sub
    'Private Sub txtAlertID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlertID.TextChanged
    '    If Me.txtAlertID.Text <> String.Empty Then
    '        Me.cmbAlertID.Text = cls.FncGetAlertCombo(CInt(GFncNoNullString(Me.txtAlertID.Text)))
    '    Else
    '        Me.cmbAlertID.Text = String.Empty
    '    End If
    'End Sub
    'Private Sub cmbAlertID_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbAlertID.SelectedIndexChanged
    '    If Me.cmbAlertID.Text <> String.Empty Then
    '        If cls.FncGetAlertTxt(CStr(GFncNoNullString(Me.cmbAlertID.Text))) <> -1 Then
    '            Me.txtAlertID.Text = CInt(cls.FncGetAlertTxt(CStr(GFncNoNullString(Me.cmbAlertID.Text))))
    '        Else
    '            Me.txtAlertID.Text = String.Empty
    '        End If
    '    Else
    '        Me.txtAlertID.Text = String.Empty
    '    End If
    'End Sub
    Private Sub dgvEmail_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvEmail.SelectionChanged
        If Me.dgvEmail.Rows.Count > 0 Then
            Me.txtAcc.Text = CStr(GFncNoNullString(Me.dgvEmail.CurrentRow.Cells("account_no").Value))
            Me.txtSales.Text = CStr(GFncNoNullString(Me.dgvEmail.CurrentRow.Cells("sales_id").Value))
            'Me.txtAlertID.Text = CInt(GFncNoNullString(Me.dgvEmail.CurrentRow.Cells("alert_type_id").Value))
            'Me.cmbAlertID.Text = CStr(GFncNoNullString(Me.dgvEmail.CurrentRow.Cells("alert_type").Value))
            Dim temp As String = CStr(GFncNoNullString(Me.dgvEmail.CurrentRow.Cells("alert_type").Value))
            Dim value As Integer = CInt(temp.Substring(1, temp.Length - 1))
            If temp.Substring(0, 1) = "U" Then
                Me.cmbAlertID.Text = "U" & value & ": " & value & "% of coupon value consumed"
            else if temp.Substring(0, 1) = "E" Then
                Me.cmbAlertID.Text = "E" & value & ": " & value & " days before expiry"
            End If
            Me.txtEmail.Text = CStr(GFncNoNullString(Me.dgvEmail.CurrentRow.Cells("email_addr").Value))
            'txtAlertID_TextChanged(Nothing, System.EventArgs.Empty)
        Else
            cleanBox()
        End If
    End Sub
    Private Sub setValue(ByVal id As Integer)
        Me.txtAcc.Text = CStr(GFncNoNullString(Me.dgvEmail.Rows(id).Cells("account_no").Value))
        Me.txtSales.Text = CStr(GFncNoNullString(Me.dgvEmail.Rows(id).Cells("sales_id").Value))
        'Me.txtAlertID.Text = CInt(GFncNoNullString(Me.dgvEmail.Rows(id).Cells("alert_type_id").Value))
        'Me.cmbAlertID.Text = CStr(GFncNoNullString(Me.dgvEmail.Rows(id).Cells("alert_type").Value))
        Dim temp As String = CStr(GFncNoNullString(Me.dgvEmail.Rows(id).Cells("alert_type").Value))
        Dim value As Integer = CInt(temp.Substring(1, temp.Length - 1))
        If temp.Substring(0, 1) = "U" Then
            Me.cmbAlertID.Text = "U" & value & ": " & value & "% of coupon value consumed"
        ElseIf temp.Substring(0, 1) = "E" Then
            Me.cmbAlertID.Text = "E" & value & ": " & value & " days before expiry"
        End If
        Me.txtEmail.Text = CStr(GFncNoNullString(Me.dgvEmail.Rows(id).Cells("email_addr").Value))
        'txtAlertID_TextChanged(Nothing, System.EventArgs.Empty)
    End Sub
    Private Sub cleanBox()
        Me.txtAcc.Text = String.Empty
        Me.txtSales.Text = String.Empty
        'Me.txtAlertID.Text = String.Empty
        Me.txtEmail.Text = String.Empty
        Me.cmbSAcc.Text = String.Empty
        Me.cmbSID.Text = String.Empty
        Me.cmbAlertID.Text = String.Empty
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled = True Then
            cleanBox()
            setBtn(True)
            selectedFunction = 0
            oldAcc = String.Empty
            oldSale = String.Empty
            If Me.dgvEmail.Rows.Count > 0 Then
                Me.dgvEmail.Rows(0).Selected = True
                dgvEmail_SelectionChanged(Nothing, System.EventArgs.Empty)
                setValue(0)
            End If
        Else
            Me.Close()
        End If
    End Sub
    Private Sub setBtn(ByVal flag As Boolean)
        Me.cmbSAcc.Enabled = flag
        Me.cmbSID.Enabled = flag
        Me.txtAcc.Enabled = Not flag
        Me.txtSales.Enabled = Not flag
        Me.cmbAlertID.Enabled = Not flag
        Me.txtEmail.Enabled = Not flag
        Me.btnSave.Enabled = Not flag
        Me.btnNew.Enabled = flag
        Me.btnDelete.Enabled = flag
        Me.btnEdit.Enabled = flag
        Me.btnSearch.Enabled = flag
        Me.dgvEmail.Enabled = flag
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dt As DataTable
        dt = cls.FncSearch(CStr(GFncNoNullString(Me.cmbSAcc.Text)), CStr(GFncNoNullString(Me.cmbSID.Text)))
        Me.dgvEmail.DataSource = dt
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        setBtn(False)
        cleanBox()
        selectedFunction = 1
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        setBtn(False)
        selectedFunction = 2
        oldAcc = CStr(GFncNoNullString(Me.txtAcc.Text))
        oldSale = CStr(GFncNoNullString(Me.txtSales.Text))
        Me.cmbSAcc.Text = String.Empty
        Me.cmbSID.Text = String.Empty
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        setBtn(False)
        Dim op = MessageBox.Show("Confirm to delete?", "", MessageBoxButtons.YesNo)
        If op = Windows.Forms.DialogResult.Yes Then
            If cls.FncDelete(CStr(GFncNoNullString(Me.dgvEmail.CurrentRow.Cells("account_no").Value)), CStr(GFncNoNullString(Me.dgvEmail.CurrentRow.Cells("sales_id").Value))) Then
                cleanBox()
                loadDGV()
                loadCombo()
                dgvEmail_SelectionChanged(Nothing, System.EventArgs.Empty)
                MessageBox.Show("Deleted successfully")
            End If
        End If
        setBtn(True)
    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim alertID As Integer
        If GFncNoNullString(Me.cmbAlertID.Text) = String.Empty Then
            alertID = Nothing
        Else
            alertID = CInt(cls.FncGetAlertTxt(GFncNoNullString(Me.cmbAlertID.Text)))
        End If
        If Me.txtAcc.Text <> Nothing And Me.txtSales.Text <> String.Empty And Me.txtEmail.Text <> String.Empty Then
            If selectedFunction = 1 Then
                Dim op = MessageBox.Show("Confirm to add?", "", MessageBoxButtons.YesNo)
                If op = Windows.Forms.DialogResult.Yes Then
                    If Not cls.FncDoubleInsert(GFncNoNullString(Me.txtAcc.Text), GFncNoNullString(Me.txtSales.Text)) Then
                        If cls.FncCheckEmail(GFncNoNullString(Me.txtEmail.Text)) Then
                            If cls.FncAdd(GFncNoNullString(Me.txtAcc.Text), GFncNoNullString(Me.txtSales.Text), alertID, CStr(GFncNoNullString(Me.txtEmail.Text)), Trim(GStrloginID)) Then
                                Dim tempAcc As String = CStr(GFncNoNullString(Me.txtAcc.Text))
                                Dim tempSale As String = CStr(GFncNoNullString(Me.txtSales.Text))
                                loadDGV()
                                loadCombo()
                                Dim Idrow As Integer
                                If Me.dgvEmail.Rows.Count > 0 Then
                                    For Idrow = 0 To Me.dgvEmail.Rows.Count - 1
                                        If CStr(GFncNoNullString(Me.dgvEmail.Item("account_no", Idrow).Value)) = tempAcc And CStr(GFncNoNullString(Me.dgvEmail.Item("sales_id", Idrow).Value)) = tempSale Then
                                            Me.dgvEmail.Rows(Idrow).Selected = True
                                            dgvEmail_SelectionChanged(Nothing, System.EventArgs.Empty)
                                            setValue(Idrow)
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Else
                            GSubShowInfo("Email Address is invalid")
                            Return
                        End If
                    Else
                        GSubShowInfo("Record already existed")
                        Return
                    End If
                Else
                    cleanBox()
                    If Me.dgvEmail.Rows.Count > 0 Then
                        Me.dgvEmail.Rows(0).Selected = True
                        dgvEmail_SelectionChanged(Nothing, System.EventArgs.Empty)
                        setValue(0)
                    End If
                End If
            ElseIf selectedFunction = 2 Then
                Dim op = MessageBox.Show("Confirm to Edit?", "", MessageBoxButtons.YesNo)
                If op = Windows.Forms.DialogResult.Yes Then
                    If (CStr(GFncNoNullString(Me.txtAcc.Text)) = oldAcc And CStr(GFncNoNullString(Me.txtSales.Text)) = oldSale) Or _
                        Not cls.FncDoubleInsert(GFncNoNullString(Me.txtAcc.Text), GFncNoNullString(Me.txtSales.Text)) Then
                        If cls.FncCheckEmail(GFncNoNullString(Me.txtEmail.Text)) Then
                            If cls.FncEdit(GFncNoNullString(Me.txtAcc.Text), GFncNoNullString(Me.txtSales.Text), alertID, CStr(GFncNoNullString(Me.txtEmail.Text)), Trim(GStrloginID), oldAcc, oldSale) Then
                                Dim tempAcc As String = CStr(GFncNoNullString(Me.txtAcc.Text))
                                Dim tempSale As String = CStr(GFncNoNullString(Me.txtSales.Text))
                                loadDGV()
                                loadCombo()
                                Dim Idrow As Integer
                                If Me.dgvEmail.Rows.Count > 0 Then
                                    For Idrow = 0 To Me.dgvEmail.Rows.Count - 1
                                        If CStr(GFncNoNullString(Me.dgvEmail.Item("account_no", Idrow).Value)) = tempAcc And CStr(GFncNoNullString(Me.dgvEmail.Item("sales_id", Idrow).Value)) = tempSale Then
                                            Me.dgvEmail.Rows(Idrow).Selected = True
                                            dgvEmail_SelectionChanged(Nothing, System.EventArgs.Empty)
                                            setValue(Idrow)
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Else
                            GSubShowInfo("Email Address is invalid")
                            Return
                        End If
                    Else
                        GSubShowInfo("Record already existed")
                        Return
                    End If
                Else
                    cleanBox()
                    If Me.dgvEmail.Rows.Count > 0 Then
                        Me.dgvEmail.Rows(0).Selected = True
                        dgvEmail_SelectionChanged(Nothing, System.EventArgs.Empty)
                        setValue(0)
                    End If
                End If
            End If
        Else
            GSubShowInfo("Account No., Sales ID and Email Address can not be empty")
            Return
        End If
        setBtn(True)
        selectedFunction = 0
        oldAcc = String.Empty
        oldSale = String.Empty
    End Sub
End Class
