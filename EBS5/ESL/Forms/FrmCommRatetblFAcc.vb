Public Class FrmCommRatetblFAcc
    'Dim cls As New ClsCommRatetblFAcc
    'Dim LoadFlag As Boolean
    'Dim AccDT As DataTable
    'Dim AeDT As DataTable
    'Dim ProductDT As DataTable
    'Dim ActionFlag As String
    'Dim SeachMonth As String
    'Dim ObjRsid As Integer

    'Private Sub FrmCommRatetblFAcc_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    '    ActionFlag = ""
    '    LoadFlag = True
    '    txtAccName.ReadOnly = False
    '    Dim mthDT As DataTable
    '    'mthDT = cls.GetMonth(" and comm_type='ACC'")
    '    For Each mthDr As DataRow In mthDT.Rows
    '        Me.comboMonth.Items.Add(mthDr.Item(0))
    '    Next
    '    If mthDT.Rows.Count > 0 Then
    '        Me.comboMonth.Text = Me.comboMonth.Items(Me.comboMonth.Items.Count - 1)
    '    End If
    '    AccDT = cls.GetAcc()
    '    Me.comboAccNo.Items.Add("")
    '    For Each AccDr As DataRow In AccDT.Rows
    '        Me.comboAccNo.Items.Add(AccDr.Item("acc_no").ToString.Trim)
    '    Next
    '    AeDT = cls.GetAe()
    '    Me.comboAE.Items.Add("")
    '    For Each AeDr As DataRow In AeDT.Rows
    '        Me.comboAE.Items.Add(AeDr.Item("ae_no").ToString.Trim)
    '    Next
    '    ProductDT = cls.GetProduct()
    '    Me.comboProduct.Items.Add("")
    '    For Each ProdDr As DataRow In ProductDT.Rows
    '        Me.comboProduct.Items.Add(ProdDr.Item("product_code").ToString.Trim)
    '    Next
    '    For year As Integer = Now.Year - 2 To Now.Year + 1
    '        For month As Integer = 1 To 12
    '            Me.txtMonth.Items.Add(year.ToString & Format(month, "00"))
    '        Next
    '    Next

    '    ObjEnable(False)
    '    LoadFlag = False
    '    Me.btnSearch_Click(Nothing, System.EventArgs.Empty)

    'End Sub

    'Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    '    Dim condition As String = " and comm_type='ACC' "
    '    If comboMonth.Text.Length > 0 Then
    '        condition += " and comm_month ='" & Me.comboMonth.Text & "' "
    '    End If
    '    If txtSrcAcc.Text.Length > 0 Then
    '        condition += " and acc_no='" & Me.txtSrcAcc.Text & "' "
    '    End If
    '    'dtgRateTbl.DataSource = cls.EnquirySearch(condition, " acc_no asc, ae_no, prod_code asc, rate_type asc, turnover_from asc, ")
    '    If ObjRsid.ToString.Length > 0 Then
    '        lsubGoRecord()
    '    End If
    'End Sub

    'Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
    '    RefrashMonth()
    '    'Me.comboMonth.Text = cls.GetLatestMonth(" and comm_type='ACC'")
    '    Me.txtSrcAcc.Text = ""
    'End Sub

    'Private Sub comboMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboMonth.SelectedIndexChanged
    '    If LoadFlag = False And ActionFlag = "" Then
    '        btnSearch_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
    '    If ActionFlag.Length > 0 Then
    '        ActionFlag = ""
    '        ObjEnable(False)

    '        Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)
    '    Else
    '        Me.Close()
    '    End If
    'End Sub

    'Private Sub dtgRateTbl_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgRateTbl.SelectionChanged
    '    'If LoadFlag = False Then
    '    '    If dtgRateTbl.Rows.Count > 0 Then
    '    '        Me.comboAccNo.Text = Me.dtgRateTbl.CurrentRow.Cells("acc_no").Value.ToString.Trim
    '    '        Me.comboProduct.Text = Me.dtgRateTbl.CurrentRow.Cells("product_code").Value.ToString.Trim
    '    '        Me.txtMonth.Text = Me.dtgRateTbl.CurrentRow.Cells("comm_month").Value.ToString.Trim
    '    '        Me.txtTOFrom.Text = Me.dtgRateTbl.CurrentRow.Cells("turnover_from").Value.ToString.Trim
    '    '        Me.txtDayRate.Text = Me.dtgRateTbl.CurrentRow.Cells("day_rate").Value.ToString.Trim
    '    '        Me.txtNightRate.Text = Me.dtgRateTbl.CurrentRow.Cells("night_rate").Value.ToString.Trim
    '    '    End If
    '    'End If
    '    If LoadFlag = False Then
    '        If dtgRateTbl.Rows.Count > 0 Then
    '            Me.comboAccNo.Text = Me.dtgRateTbl.CurrentRow.Cells("acc_no").Value.ToString.Trim
    '            Me.comboProduct.Text = Me.dtgRateTbl.CurrentRow.Cells("product_code").Value.ToString.Trim
    '            Me.txtMonth.Text = Me.dtgRateTbl.CurrentRow.Cells("comm_month").Value.ToString.Trim
    '            Me.txtTOFrom.Text = Me.dtgRateTbl.CurrentRow.Cells("turnover_from").Value.ToString.Trim
    '            Me.txtDayRate.Text = Me.dtgRateTbl.CurrentRow.Cells("day_rate").Value.ToString.Trim
    '            Me.txtNightRate.Text = Me.dtgRateTbl.CurrentRow.Cells("night_rate").Value.ToString.Trim
    '            Me.comboAE.Text = Me.dtgRateTbl.CurrentRow.Cells("ae_no").Value.ToString.Trim
    '            Select Case Me.dtgRateTbl.CurrentRow.Cells("rate_type").Value.ToString.Trim
    '                Case "NORF"
    '                    Me.rbNormal.Checked = True
    '                    Me.RBFut.Checked = True
    '                Case "INTF"
    '                    Me.rbInternet.Checked = True
    '                    Me.RBFut.Checked = True
    '                Case "NORO"
    '                    Me.RBOption.Checked = True
    '                    Me.rbNormal.Checked = True
    '                Case "INTO"
    '                    Me.rbInternet.Checked = True
    '                    Me.RBOption.Checked = True
    '            End Select
    '        End If
    '    End If
    'End Sub

    'Private Sub comboAccNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboAccNo.SelectedIndexChanged
    '    If LoadFlag = False Then

    '        If Me.comboAccNo.Text.Length > 0 Then
    '            Dim Acc() As DataRow = AccDT.Select(" acc_no ='" & comboAccNo.Text & "'")
    '            Me.txtAccName.Text = Acc(0).Item("acc_name").ToString.Trim
    '        Else
    '            Me.txtAccName.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Sub comboProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboProduct.SelectedIndexChanged
    '    If LoadFlag = False Then
    '        If Me.comboProduct.Text.Length > 0 Then
    '            Dim Prod() As DataRow = ProductDT.Select(" product_code ='" & Me.comboProduct.Text & "'")
    '            Me.txtProductName.Text = Prod(0).Item("product_name").ToString.Trim
    '        Else
    '            Me.txtProductName.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Sub ObjEnable(ByVal blnflag As Boolean)
    '    'Me.txtSrcAcc.ReadOnly = blnflag
    '    'Me.comboMonth.Enabled = Not blnflag
    '    'Me.btnSearch.Enabled = Not blnflag
    '    'Me.btnReset.Enabled = Not blnflag
    '    'Me.dtgRateTbl.Enabled = Not blnflag
    '    'Me.txtTOFrom.ReadOnly = Not blnflag
    '    'Me.txtDayRate.ReadOnly = Not blnflag
    '    'Me.txtNightRate.ReadOnly = Not blnflag
    '    'Me.btnSave.Enabled = blnflag
    '    'Me.btnDelete.Enabled = Not blnflag
    '    'Me.btnNew.Enabled = Not blnflag
    '    'Me.btnEdit.Enabled = Not blnflag
    '    'Select Case ActionFlag
    '    '    Case "New"
    '    '        Me.comboAccNo.Enabled = blnflag
    '    '        Me.comboProduct.Enabled = blnflag
    '    '        Me.txtMonth.ReadOnly = Not blnflag
    '    '    Case "Edit"
    '    '        Me.comboAccNo.Enabled = Not blnflag
    '    '        Me.comboProduct.Enabled = Not blnflag
    '    '        Me.txtMonth.ReadOnly = blnflag
    '    '    Case Else
    '    '        Me.comboAccNo.Enabled = False
    '    '        Me.comboProduct.Enabled = False
    '    '        Me.txtMonth.ReadOnly = Not blnflag
    '    'End Select

    '    Me.txtSrcAcc.ReadOnly = blnflag
    '    Me.comboMonth.Enabled = Not blnflag
    '    Me.comboAE.Enabled = blnflag
    '    Me.rbNormal.Enabled = blnflag
    '    Me.rbInternet.Enabled = blnflag
    '    Me.RBFut.Enabled = blnflag
    '    Me.RBOption.Enabled = blnflag
    '    Me.btnSearch.Enabled = Not blnflag
    '    Me.btnReset.Enabled = Not blnflag
    '    Me.dtgRateTbl.Enabled = Not blnflag
    '    Me.txtTOFrom.ReadOnly = Not blnflag
    '    Me.txtDayRate.ReadOnly = Not blnflag
    '    Me.txtNightRate.ReadOnly = Not blnflag
    '    Me.btnSave.Enabled = blnflag
    '    Me.btnDelete.Enabled = Not blnflag
    '    Me.btnNew.Enabled = Not blnflag
    '    Me.btnEdit.Enabled = Not blnflag
    '    Select Case ActionFlag
    '        Case "New"
    '            Me.comboAccNo.Enabled = blnflag
    '            Me.comboProduct.Enabled = blnflag
    '            Me.txtMonth.Enabled = blnflag
    '        Case "Edit"
    '            Me.comboAccNo.Enabled = Not blnflag
    '            Me.comboProduct.Enabled = Not blnflag
    '            Me.txtMonth.Enabled = Not blnflag
    '        Case Else
    '            Me.comboAccNo.Enabled = False
    '            Me.comboProduct.Enabled = False
    '            Me.txtMonth.Enabled = blnflag
    '    End Select
    'End Sub

    'Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
    '    ActionFlag = "New"
    '    ObjEnable(True)
    '    EmptyField()
    '    SeachMonth = Me.comboMonth.Text
    '    Me.comboAccNo.Focus()
    'End Sub

    'Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
    '    If Me.dtgRateTbl.SelectedRows.Count > 0 Then
    '        ActionFlag = "Edit"
    '        ObjEnable(True)
    '        SeachMonth = Me.comboMonth.Text
    '        Me.txtTOFrom.Focus()
    '    End If
    'End Sub

    'Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
    '    Dim condition As String = ""
    '    Select Case ActionFlag
    '        Case "New"
    '            If Validation() = False Then
    '                Return
    '            End If
    '            If GSubShowYNConfirm(GFncGetSysMsg(40), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
    '                Return
    '            End If
    '            condition = "'" & Me.comboAccNo.Text & "', " & _
    '                                               "' ', " & _
    '                                               "' ', ' ', " & _
    '                                               "'" & Me.comboAE.Text.Trim & "', " & _
    '                                               "'" & Me.comboProduct.Text & "', " & _
    '                                               "0, " & _
    '                                               "'" & RateType() & "', " & _
    '                                               Val(Me.txtTOFrom.Text) & ", " & _
    '                                                Val(Me.txtDayRate.Text) & ", " & _
    '                                              Val(Me.txtNightRate.Text) & ", " & _
    '                                               "0, " & _
    '                                               "'" & Me.txtMonth.Text & "'," & _
    '                                               "'ACC'"
    '            ObjRsid = cls.NewRecord(condition)
    '            'condition = "'" & Me.comboAccNo.Text & "', " & _
    '            '                    "' ', ' ', ' ', " & _
    '            '                    "'" & Me.comboProduct.Text & "', " & _
    '            '                    "0, " & _
    '            '                    "' ', " & _
    '            '                    Val(Me.txtTOFrom.Text) & ", " & _
    '            '                     Val(Me.txtDayRate.Text) & ", " & _
    '            '                     Val(Me.txtNightRate.Text) & ", " & _
    '            '                    "0, " & _
    '            '                    "'" & Me.txtMonth.Text & "'," & _
    '            '                    "'ACC'"
    '            'ObjRsid = cls.NewRecord(condition)

    '            RefrashMonth()
    '            Me.comboMonth.Text = SeachMonth
    '            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
    '            ActionFlag = ""
    '            ObjEnable(False)
    '        Case "Edit"
    '            If Validation() = False Then
    '                Return
    '            End If
    '            If GSubShowYNConfirm(GFncGetSysMsg(48), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
    '                Return
    '            End If
    '            condition = " turnover_from =" & Val(Me.txtTOFrom.Text.Trim) & " , day_rate =" & Val(Me.txtDayRate.Text) & " , night_rate =" & Val(Me.txtNightRate.Text) & ", " & _
    '                                 " rate_type ='" & RateType() & "', ae_no='" & Me.comboAE.Text.Trim & "' "
    '            cls.EditRecord(condition, Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim)
    '            ObjRsid = Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim

    '            RefrashMonth()
    '            Me.comboMonth.Text = SeachMonth
    '            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
    '            ActionFlag = ""
    '            ObjEnable(False)
    '    End Select
    'End Sub

    'Private Function Validation() As Boolean
    '    Dim ErrorMsg As String = ""
    '    If Me.comboAccNo.Text.Length <= 0 Then
    '        ErrorMsg += " Account Number,"
    '    End If
    '    If Me.comboProduct.Text.Length <= 0 Then
    '        ErrorMsg += " Product,"
    '    End If
    '    If Me.txtMonth.Text.Length <= 0 Then
    '        ErrorMsg += " Month,"
    '    End If
    '    If Me.txtTOFrom.TextLength <= 0 Then
    '        ErrorMsg += " Turnover,"
    '    End If
    '    If Me.txtDayRate.TextLength <= 0 And Me.txtNightRate.TextLength <= 0 Then
    '        ErrorMsg += " Day rate & night rate,"
    '    End If
    '    If Me.comboAE.Text.Length <= 0 Then
    '        ErrorMsg += "AE code,"
    '    End If
    '    If ErrorMsg.Length = 0 Then
    '        Return True
    '    Else
    '        GSubShowInfo(ErrorMsg.Substring(0, ErrorMsg.Length - 1) & GFncGetSysMsg(49))
    '        Return False
    '    End If

    'End Function

    'Private Sub EmptyField()
    '    Me.comboAccNo.Text = ""
    '    Me.comboProduct.Text = ""
    '    Me.txtTOFrom.Text = ""
    '    Me.txtDayRate.Text = ""
    '    Me.txtNightRate.Text = ""
    '    Me.txtMonth.Text = Now.Year.ToString & Format(Now.Month, "00")
    '    Me.comboAE.Text = ""
    '    Me.rbNormal.Checked = True
    '    Me.RBFut.Checked = True
    'End Sub

    'Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    '    If Me.dtgRateTbl.SelectedRows.Count > 0 Then
    '        If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
    '            Return
    '        End If
    '        cls.DelRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim)
    '        ObjEnable(False)
    '        RefrashMonth()
    '        Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub RefrashMonth()
    '    'Dim mthDT As DataTable = cls.GetMonth(" and comm_type='ACC'")
    '    Me.comboMonth.Items.Clear()
    '    For Each mthDr As DataRow In mthDT.Rows
    '        Me.comboMonth.Items.Add(mthDr.Item(0))
    '    Next
    '    If mthDT.Rows.Count > 0 Then
    '        Me.comboMonth.Text = Me.comboMonth.Items(Me.comboMonth.Items.Count - 1)
    '    End If
    'End Sub

    'Private Sub lsubGoRecord()
    '    If ObjRsid.ToString <> "" Then
    '        For lintCnt As Integer = 0 To Me.dtgRateTbl.Rows.Count - 1
    '            If Me.dtgRateTbl.Rows(lintCnt).Cells("rsid").Value.ToString.Trim = ObjRsid Then
    '                Me.dtgRateTbl.Rows(lintCnt).Cells("acc_no").Selected = True
    '                Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)

    '                Me.dtgRateTbl.Focus()
    '                Exit For
    '            End If
    '        Next
    '        ObjRsid = 0

    '    End If
    'End Sub

    'Private Sub comboAEgp_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboAE.SelectedIndexChanged
    '    If LoadFlag = False Then
    '        If Me.comboAE.Text.Length > 0 Then
    '            Dim AE() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAE.Text & "'")
    '            Me.txtAEName.Text = AE(0).Item("ae_name").ToString.Trim
    '        Else
    '            Me.txtAEName.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Function RateType() As String
    '    If Me.RBFut.Checked Then
    '        If Me.rbNormal.Checked Then
    '            'normal fut
    '            Return "NORF"
    '        Else
    '            'internet future
    '            Return "INTF"
    '        End If
    '        'option
    '    Else
    '        If Me.rbNormal.Checked Then
    '            'Option fut
    '            Return "NORO"
    '        Else
    '            'Option future
    '            Return "INTO"
    '        End If
    '    End If
    'End Function
End Class
