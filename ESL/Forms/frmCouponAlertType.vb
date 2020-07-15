Public Class frmCouponAlertType

    Dim cls As New clsCouponAlertType
    Dim selectedFunction As Integer = 0
    Dim oldType As Char = Nothing
    Dim oldValue As Double = 0

    Private Sub frmCouponAlertType_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        loadDGV()
        loadCombo()
    End Sub
    Private Sub loadDGV()
        Dim dt As DataTable
        dt = cls.FncLoadDGV()
        Me.dgvAlert.DataSource = dt
        Me.dgvAlert.DefaultCellStyle.BackColor = Color.Linen
        Me.dgvAlert.ReadOnly = True
    End Sub
    Private Sub loadCombo()
        Me.cmbSearchType.Items.Clear()
        Me.cmbType.Items.Clear()
        Me.cmbSearchType.Items.Add("")
        Me.cmbSearchType.Items.Add("U (Usage)")
        Me.cmbSearchType.Items.Add("E (Expiry)")
        Me.cmbType.Items.Add("U (Usage)")
        Me.cmbType.Items.Add("E (Expiry)")
    End Sub
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dt As DataTable
        If GFncNoNullString(Me.cmbSearchType.Text) <> String.Empty Then
            dt = cls.FncSearch(CChar(GFncNoNullString(Me.cmbSearchType.Text).Substring(0, 1)))
        Else
            dt = cls.FncSearch(Nothing)
        End If

        Me.dgvAlert.DataSource = dt
    End Sub
    Private Sub dgvAlert_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvAlert.SelectionChanged
        If Me.dgvAlert.Rows.Count > 0 Then
            If CChar(GFncNoNullString(Me.dgvAlert.CurrentRow.Cells("type").Value)) = "U" Then
                Me.cmbType.Text = "U (Usage)"
            ElseIf CChar(GFncNoNullString(Me.dgvAlert.CurrentRow.Cells("type").Value)) = "E" Then
                Me.cmbType.Text = "E (Expiry)"
            End If
            Me.ambValue.Text = CDbl(GFncNoNullString(Me.dgvAlert.CurrentRow.Cells("value").Value))
        Else
            cleanBox()
        End If
    End Sub
    Private Sub setValue(ByVal id As Integer)
        If CChar(GFncNoNullString(Me.dgvAlert.CurrentRow.Cells("type").Value)) = "U" Then
            Me.cmbType.Text = "U (Usage)"
        ElseIf CChar(GFncNoNullString(Me.dgvAlert.CurrentRow.Cells("type").Value)) = "E" Then
            Me.cmbType.Text = "E (Expiry)"
        End If
        Me.ambValue.Text = CDbl(GFncNoNullString(Me.dgvAlert.Rows(id).Cells("value").Value))
    End Sub
    Private Sub cleanBox()
        Me.cmbType.Text = Nothing
        Me.ambValue.Text = 0
        Me.cmbSearchType.Text = Nothing
    End Sub
    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled = True Then
            cleanBox()
            setBtn(True)
            selectedFunction = 0
            oldType = Nothing
            oldValue = 0
            If Me.dgvAlert.Rows.Count > 0 Then
                Me.dgvAlert.Rows(0).Selected = True
                dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
                setValue(0)
            End If
        Else
            Me.Close()
        End If
    End Sub
    Private Sub setBtn(ByVal flag As Boolean)
        Me.cmbType.Enabled = Not flag
        Me.ambValue.Enabled = Not flag
        Me.btnSave.Enabled = Not flag
        Me.cmbSearchType.Enabled = flag
        Me.btnNew.Enabled = flag
        Me.btnDelete.Enabled = flag
        Me.btnEdit.Enabled = flag
        Me.btnSearch.Enabled = flag
        Me.dgvAlert.Enabled = flag
    End Sub
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        setBtn(False)
        cleanBox()
        selectedFunction = 1
    End Sub
    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        setBtn(False)
        selectedFunction = 2
        oldType = CChar(GFncNoNullString(Me.cmbType.Text).Substring(0, 1))
        oldValue = CDbl(GFncNoNullString(Me.ambValue.Text))
        Me.cmbSearchType.Text = Nothing
    End Sub
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        setBtn(False)
        Dim op = MessageBox.Show("Confirm to delete?", "", MessageBoxButtons.YesNo)
        If op = Windows.Forms.DialogResult.Yes Then
            If cls.FncDelete(Me.cmbType.Text, Me.ambValue.Text) Then
                cleanBox()
                loadDGV()
                loadCombo()
                dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
                MessageBox.Show("Deleted successfully")
            End If
        End If
        setBtn(True)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If GFncNoNullString(Me.cmbType.Text) <> Nothing And GFncNoNullString(Me.ambValue.Text) <> String.Empty Then
            If ((GFncNoNullString(Me.cmbType.Text)).Substring(0, 1) = "E" And CDbl(GFncNoNullString(Me.ambValue.Text)) >= 0 And CDbl(GFncNoNullString(Me.ambValue.Text)) <= 999) Or _
               ((GFncNoNullString(Me.cmbType.Text)).Substring(0, 1) = "U" And (CDbl(GFncNoNullString(Me.ambValue.Text)) = 50 Or CDbl(GFncNoNullString(Me.ambValue.Text)) = 70) Or CDbl(GFncNoNullString(Me.ambValue.Text)) = 90) Then
                If selectedFunction = 1 Then
                    Dim op = MessageBox.Show("Confirm to add?", "", MessageBoxButtons.YesNo)
                    If op = Windows.Forms.DialogResult.Yes Then
                        If Not cls.FncDoubleInsert(CChar(GFncNoNullString(Me.cmbType.Text).Substring(0, 1)), CDbl(GFncNoNullString(Me.ambValue.Text))) Then
                            If cls.FncAdd(CChar(GFncNoNullString(Me.cmbType.Text).Substring(0, 1)), CDbl(GFncNoNullString(Me.ambValue.Text)), Trim(GStrloginID)) Then
                                Dim tempType As String = CChar(GFncNoNullString(Me.cmbType.Text).Substring(0, 1))
                                Dim tempValue As Double = CDbl(GFncNoNullString(Me.ambValue.Text))
                                loadDGV()
                                loadCombo()
                                Dim Idrow As Integer
                                If Me.dgvAlert.Rows.Count > 0 Then
                                    For Idrow = 0 To Me.dgvAlert.Rows.Count - 1
                                        If CChar(GFncNoNullString(Me.dgvAlert.Item("type", Idrow).Value).Substring(0, 1)) = tempType And CDbl(GFncNoNullString(Me.dgvAlert.Item("value", Idrow).Value)) = tempValue Then
                                            Me.dgvAlert.Rows(Idrow).Selected = True
                                            dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
                                            setValue(Idrow)
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Else
                            GSubShowInfo("Record already existed")
                            Return
                            'cleanBox()
                            'If Me.dgvAlert.Rows.Count > 0 Then
                            '    Me.dgvAlert.Rows(0).Selected = True
                            '    dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
                            '    setValue(0)
                            'End If
                        End If
                    Else
                        cleanBox()
                        If Me.dgvAlert.Rows.Count > 0 Then
                            Me.dgvAlert.Rows(0).Selected = True
                            dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
                            setValue(0)
                        End If
                    End If
                ElseIf selectedFunction = 2 Then
                    Dim op = MessageBox.Show("Confirm to Edit?", "", MessageBoxButtons.YesNo)
                    If op = Windows.Forms.DialogResult.Yes Then
                        If (CChar(GFncNoNullString(Me.cmbType.Text).Substring(0, 1)) = oldType And CDbl(GFncNoNullString(Me.ambValue.Text)) = oldValue) Or _
                            Not cls.FncDoubleInsert(CChar(GFncNoNullString(Me.cmbType.Text).Substring(0, 1)), CDbl(GFncNoNullString(Me.ambValue.Text))) Then
                            If cls.FncEdit(CChar(GFncNoNullString(Me.cmbType.Text)), CDbl(GFncNoNullString(Me.ambValue.Text)), Trim(GStrloginID), oldType, oldValue) Then
                                Dim tempType As String = CChar(GFncNoNullString(Me.cmbType.Text).Substring(0, 1))
                                Dim tempValue As Double = CDbl(GFncNoNullString(Me.ambValue.Text))
                                loadDGV()
                                loadCombo()
                                Dim Idrow As Integer
                                If Me.dgvAlert.Rows.Count > 0 Then
                                    For Idrow = 0 To Me.dgvAlert.Rows.Count - 1
                                        If CChar(GFncNoNullString(Me.dgvAlert.Item("type", Idrow).Value).Substring(0, 1)) = tempType And CDbl(GFncNoNullString(Me.dgvAlert.Item("value", Idrow).Value)) = tempValue Then
                                            Me.dgvAlert.Rows(Idrow).Selected = True
                                            dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
                                            setValue(Idrow)
                                            Exit For
                                        End If
                                    Next
                                End If
                            End If
                        Else
                            GSubShowInfo("Record already existed")
                            Return
                            'cleanBox()
                            'If Me.dgvAlert.Rows.Count > 0 Then
                            '    Me.dgvAlert.Rows(0).Selected = True
                            '    dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
                            '    setValue(0)
                            'End If
                        End If
                    Else
                        cleanBox()
                        If Me.dgvAlert.Rows.Count > 0 Then
                            Me.dgvAlert.Rows(0).Selected = True
                            dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
                            setValue(0)
                        End If
                    End If
                End If
            Else
                Dim message As String = String.Empty
                If (GFncNoNullString(Me.cmbType.Text)).Substring(0, 1) = "E" Then
                    message = "For type ""Expiry"", value must be within the range of 0 to 999"
                ElseIf (GFncNoNullString(Me.cmbType.Text)).Substring(0, 1) = "U" Then
                    message = "For type ""Usage"", value must be 50, 70 or 90"
                End If
                GSubShowInfo("Value and type do not match." & vbCrLf & message)
                Return
                'cleanBox()
                'If Me.dgvAlert.Rows.Count > 0 Then
                '    Me.dgvAlert.Rows(0).Selected = True
                '    dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
                '    setValue(0)
                'End If
            End If
        Else
            GSubShowInfo("Neither type nor value can be empty")
            Return
            'cleanBox()
            'If Me.dgvAlert.Rows.Count > 0 Then
            '    Me.dgvAlert.Rows(0).Selected = True
            '    dgvAlert_SelectionChanged(Nothing, System.EventArgs.Empty)
            '    setValue(0)
            'End If
        End If
        setBtn(True)
        selectedFunction = 0
        oldType = Nothing
        oldValue = 0
    End Sub
End Class
