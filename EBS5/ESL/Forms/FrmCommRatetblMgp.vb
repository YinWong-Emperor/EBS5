Public Class FrmCommRatetblMgp

    Dim cls As New ClsCommRatetblFAcc
    Dim LoadFlag As Boolean
    Dim ManDT As DataTable
    Dim ManGPDt As DataTable
    'Dim ProductDT As DataTable
    Dim ActionFlag As String
    Dim ObjRsid As Integer
    Dim Man As String
    Dim ManGp As String
    Dim TabFlag As Boolean
    Dim FutFlag As String
    Dim C_type As String

    Private Sub FrmCommRatetblFutAgp_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        ActionFlag = ""
        C_type = "MGRP"
        FutFlag = "Futures"
        LabLot_range.Text = ""
        LabLot_rangeO.Text = ""
        Man = ""
        ManGp = ""
        ManDT = cls.GetMan()
        ManGPDt = cls.GetManGP()
        For Each ManDr As DataRow In ManDT.Rows
            Me.comboManNo.Items.Add(ManDr.Item("man_no").ToString.Trim)
            Me.comboManNoO.Items.Add(ManDr.Item("man_no").ToString.Trim)
        Next
        ObjRsid = 0
        LoadFlag = True
        'txtAccName.ReadOnly = False
        'AccDT = cls.GetAcc()
        'Me.comboAccNo.Items.Add("")
        'Me.comboAccNoO.Items.Add("")
        'For Each AccDr As DataRow In AccDT.Rows
        '    'Me.comboAccNo.Items.Add(AccDr.Item("acc_no").ToString.Trim)
        '    Me.comboAccNoO.Items.Add(AccDr.Item("acc_no").ToString.Trim)
        'Next
        'AeDT = cls.GetAe()
        'Me.comboAE.Items.Add("")
        'For Each AeDr As DataRow In AeDT.Rows
        '    Me.comboAE.Items.Add(AeDr.Item("ae_no").ToString.Trim)
        '    Me.comboAEO.Items.Add(AeDr.Item("ae_no").ToString.Trim)
        'Next
        Dim MaxDate As String = GfncGetMonth()
        For year As Integer = Val(MaxDate.Substring(0, 4)) - 5 To Val(MaxDate.Substring(0, 4)) + 5
            Me.comboSrcYr.Items.Add(year)
            Me.comboSrchYrO.Items.Add(year)
        Next
        For month As Integer = 1 To 12
            Me.comboSrcMonth.Items.Add(month)
            Me.comboSrchMonthO.Items.Add(month)
        Next
        Me.comboSrcYr.Text = MaxDate.Substring(0, 4)
        Me.comboSrcMonth.Text = Val(MaxDate.Substring(4, 2))
        Me.comboSrchYrO.Text = Me.comboSrcYr.Text
        Me.comboSrchMonthO.Text = Me.comboSrcMonth.Text
        'Me.comboSrchRateType.Items.Add("")
        'Me.comboSrchRateType.Items.Add("Day Trade")
        'Me.comboSrchRateType.Items.Add("Overnight Trade")
        'Me.comboSrchRateType.Items.Add("All Trade")
        'ProductDT = cls.GetProduct()
        'Me.comboProduct.Items.Add("")
        'Me.comboProductO.Items.Add("")
        'Me.comboSrchProd.Items.Add("")
        'Me.comboSrchProdO.Items.Add("")
        'For Each ProdDr As DataRow In ProductDT.Rows
        '    Me.comboProduct.Items.Add(ProdDr.Item("product_group").ToString.Trim)
        '    Me.comboSrchProd.Items.Add(ProdDr.Item("product_group").ToString.Trim)
        'Next
        'Dim OptProdDT As DataTable = cls.GetProduct()
        'For Each optProdDr As DataRow In OptProdDT.Rows
        '    Me.comboProductO.Items.Add(optProdDr.Item("product_group").ToString.Trim)
        '    Me.comboSrchProdO.Items.Add(optProdDr.Item("product_group").ToString.Trim)
        'Next
        ObjEnable(False)
        OptObjEnable(False)
        LoadFlag = False
        'Me.FncLoadProductByMonth(Me.comboSrcYr.Text.Trim & Format(Val(Me.comboSrcMonth.Text.Trim), "00"))
        'Me.FncLoadProductByMonthO(Me.comboSrchYrO.Text.Trim & Format(Val(Me.comboSrchMonthO.Text.Trim), "00"))
        Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
        Me.dtgRateTableO.Columns("lot_rangeO").HeaderText = "Turnover Range"
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ActionFlag.Length > 0 Then
            ActionFlag = ""
            If Me.TabControl.SelectedTab.Name = Me.TabRateTbl.Name Then
                Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)
                ObjEnable(False)
            End If
            If Me.TabControl.SelectedTab.Name = Me.TabPageOptions.Name Then
                Me.dtgRateTableO_SelectionChanged(Nothing, System.EventArgs.Empty)
                OptObjEnable(False)
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim ACcondition As String = ""
        'If Me.txtSrcAcc.Text.Length > 0 Then
        '    ACcondition += " and upper(a.acc_no) like '%" & Me.txtSrcAcc.Text & "%' "
        'End If
        If Me.txtSrchMan.Text.Length > 0 Then
            ACcondition += " and upper(b.man_no) like '%" & Me.txtSrchMan.Text.ToUpper & "%' "
        End If
        'Select Case Me.comboSrchRateType.Text
        '    Case "All Trade"
        '        ACcondition += " and right(b.rate_type,2) ='AL'"
        '    Case "Overnight Trade"
        '        ACcondition += " and right(b.rate_type,2) ='ON'"
        '    Case "Day Trade"
        '        ACcondition += " and right(b.rate_type,2) ='DA'"
        'End Select
        If Me.rbSrchAll.Checked Then
            ACcondition += " and (b.rate_type ='BROKF' or b.rate_type ='TURNF' or b.rate_type ='REBATEF'   )"
        Else
            If Me.rbSrchTurn.Checked Then
                ACcondition += " and rate_type ='TURNF' "
            ElseIf Me.rbSrchBrok.Checked Then
                ACcondition += " and rate_type ='BROKF'"
                '    Else
                '        ACcondition += " and left(b.rate_type,4) ='CONF'"
            ElseIf Me.rbSrchRebate.Checked Then
                ACcondition += " and rate_type ='REBATEF'"
            End If
        End If
            'ACcondition += " and left(b.rate_type,5) ='TURNF'"
        'If Me.comboSrchProd.Text.Length > 0 Then
        '    ACcondition += " and b.product_group= '" & Me.comboSrchProd.Text & "' "
        'End If
        ACcondition += " and b.comm_type='" & C_type & "' and b.comm_month='" & Me.comboSrcYr.Text & _
            Format(Val(Me.comboSrcMonth.Text), "00") & "' "
        Me.dtgMan.DataSource = cls.EnquiryManTbl(ACcondition).Tables(0)
        Me.dtgMan_SelectionChanged(Nothing, System.EventArgs.Empty)
        lsubGoRecord()
        If Me.dtgMan.RowCount <= 0 Then
            'dtgAE.DataSource = cls.EnquiryAETbl(" and 1=0 ").Tables(0)
            dtgRateTbl.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
            'Me.dtgMan.DataSource = cls.EnquiryManTbl(" and 1=0 ").Tables(0)
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
            EmptyField()
        Else
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
        End If
        Me.dtgMan.Focus()
    End Sub

    'Private Sub dtgAC_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ActionFlag = "" And LoadFlag = False Then
    '        If dtgAC.SelectedRows.Count > 0 Then
    '            Dim condition As String = " and b.comm_type='" & C_type & "'  and b.acc_no='" & Me.dtgAC.CurrentRow.Cells("ACNo").Value.ToString.Trim & "'  and b.comm_month ='" & Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00") & "' "
    '            Select Case Me.comboSrchRateType.Text
    '                Case "All Trade"
    '                    condition += " and right(b.rate_type,2) ='AL'"
    '                Case "Overnight Trade"
    '                    condition += " and right(b.rate_type,2) ='ON'"
    '                Case "Day Trade"
    '                    condition += " and right(b.rate_type,2) ='DA'"
    '            End Select
    '            If Me.rbSrchAll.Checked Then
    '                condition += " and (left(b.rate_type,4) ='INTF' or left(b.rate_type,4) ='NORF' )"
    '            Else
    '                If Me.rbSrchNormal.Checked Then
    '                    condition += " and left(b.rate_type,4) ='NORF' "
    '                Else
    '                    condition += " and left(b.rate_type,4) ='INTF'"
    '                End If
    '            End If
    '            If Me.comboSrchProd.Text.Length > 0 Then
    '                condition += " and b.product_group= '" & Me.comboSrchProd.Text.ToUpper & "' "
    '            End If
    '            If Me.txtSrchMan.Text.Length > 0 Then
    '                condition += " and upper(b.man_no) like '%" & Me.txtSrchMan.Text.Trim.ToUpper & "%' "
    '            End If
    '            Me.comboAccNo.Text = Me.dtgAC.CurrentRow.Cells("ACNo").Value.ToString.Trim
    '            Me.dtgAE.DataSource = cls.EnquiryAETbl(condition).Tables(0)
    '            dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
    '        End If
    '    End If
    'End Sub

    'Private Sub dtgAE_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ActionFlag = "" And LoadFlag = False Then
    '        If Me.dtgAE.Rows.Count > 0 Then
    '            If Me.dtgAE.SelectedRows.Count > 0 Then
    '                Dim condition As String = " and b.comm_type='" & C_type & "' and b.acc_no='" & Me.comboAccNo.Text & "'  and b.ae_no='" & Me.dtgAE.CurrentRow.Cells("AENo").Value.ToString.Trim & "' and b.comm_month ='" & Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00") & "' "
    '                If Me.txtSrchMan.Text.Length > 0 Then
    '                    condition += " and upper(b.man_no) like '%" & Me.txtSrchMan.Text.Trim.ToUpper & "%' "
    '                End If
    '                Select Case Me.comboSrchRateType.Text
    '                    Case "All Trade"
    '                        condition += " and right(b.rate_type,2) ='AL'"
    '                    Case "Overnight Trade"
    '                        condition += " and right(b.rate_type,2) ='ON'"
    '                    Case "Day Trade"
    '                        condition += " and right(b.rate_type,2) ='DA'"
    '                End Select
    '                If Me.rbSrchAll.Checked Then
    '                    condition += " and (left(b.rate_type,4) ='INTF' or left(b.rate_type,4) ='NORF' )"
    '                Else
    '                    If Me.rbSrchNormal.Checked Then
    '                        condition += " and left(b.rate_type,4) ='NORF' "
    '                    Else
    '                        condition += " and left(b.rate_type,4) ='INTF'"
    '                    End If
    '                End If
    '                If Me.comboSrchProd.Text.Length > 0 Then
    '                    condition += " and b.product_group= '" & Me.comboSrchProd.Text.ToUpper & "' "
    '                End If
    '                Me.comboAE.Text = Me.dtgAE.CurrentRow.Cells("AENo").Value.ToString.Trim
    '                Me.dtgMan.DataSource = cls.EnquiryManTbl(condition).Tables(0)
    '            End If
    '        Else
    '            Me.dtgRateTbl.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
    '            Me.btnEdit.Enabled = False
    '            Me.btnDelete.Enabled = False
    '            EmptyField()
    '        End If
    '    End If
    'End Sub

    Private Sub dtgMan_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgMan.SelectionChanged
        If ActionFlag = "" And LoadFlag = False Then
            If Me.dtgMan.Rows.Count > 0 Then
                If Me.dtgMan.SelectedRows.Count > 0 Then
                    Dim condition As String = " and comm_type='" & C_type & "' and comm_month ='" & Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00") & "' "
                    condition += " and man_no= '" & Me.dtgMan.CurrentRow.Cells("ManNo").Value.ToString.Trim & "' and man_group ='" & Me.dtgMan.CurrentRow.Cells("ManGroup").Value.ToString.Trim & "' "

                    If Me.rbSrchAll.Checked Then
                        condition += " and (rate_type ='BROKF' or rate_type ='TURNF' or rate_type ='REBATEF')"
                    Else
                        If Me.rbSrchBrok.Checked Then
                            condition += " and rate_type ='BROKF' "
                        ElseIf Me.rbSrchTurn.Checked Then
                            condition += " and rate_type ='TURNF' "
                        ElseIf Me.rbSrchRebate.Checked Then
                            condition += " and rate_type ='REBATEF'"
                        End If
                    End If
                    'If Me.comboSrchProd.Text.Length > 0 Then
                    '    condition += " and product_group= '" & Me.comboSrchProd.Text.ToUpper & "' "
                    'End If
                    Me.dtgRateTbl.DataSource = cls.EnquiryRateTbl(condition, " product_group asc, comm_month asc,acc_group asc, rate_type desc, turnover_from asc, ")
                End If
            Else
                Me.dtgRateTbl.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
                Me.btnEdit.Enabled = False
                Me.btnDelete.Enabled = False
                EmptyField()
            End If
        End If
    End Sub
    'Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim Mth As String = cls.GetLatestMonth(" and comm_type='" & C_type & "'")
    '    Me.comboSrcMonth.Text = Val(Mth.Substring(4, 2))
    '    Me.comboSrcYr.Text = Val(Mth.Substring(0, 4))
    '    Me.txtSrcAcc.Text = ""
    'End Sub

    Private Sub dtgRateTbl_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgRateTbl.SelectionChanged
        If LoadFlag = False Then
            If dtgRateTbl.Rows.Count > 0 And Me.dtgMan.Rows.Count > 0 Then
                'Me.comboAccNo.Text = Me.dtgRateTbl.CurrentRow.Cells("acc_no").Value.ToString.Trim
                'Me.comboProduct.Text = Me.dtgRateTbl.CurrentRow.Cells("product_group").Value.ToString.Trim
                Me.txtMonth.Text = Me.dtgRateTbl.CurrentRow.Cells("comm_month").Value.ToString.Trim
                Me.txtTOFrom.Text = Me.dtgRateTbl.CurrentRow.Cells("turnover_from").Value.ToString.Trim
                Me.txtRate.Text = Me.dtgRateTbl.CurrentRow.Cells("rate").Value.ToString.Trim
                'Me.txtNRate.Text = Me.dtgRateTbl.CurrentRow.Cells("night_rate").Value.ToString.Trim
                Me.comboManNo.Text = Me.dtgMan.CurrentRow.Cells("ManNo").Value.ToString.Trim
                Me.txtManName.Text = Me.dtgMan.CurrentRow.Cells("ManName").Value.ToString.Trim
                Me.comboManGroup.Text = Me.dtgMan.CurrentRow.Cells("ManGroup").Value.ToString.Trim
                'Me.comboAE.Text = Me.dtgRateTbl.CurrentRow.Cells("ae_no").Value.ToString.Trim
                'Me.txtManGroup.Text = Me.dtgRateTbl.CurrentRow.Cells("man_group").Value.ToString.Trim

                'Select Case Me.dtgRateTbl.CurrentRow.Cells("rate_type").Value.ToString.Trim
                '    Case "All"
                '        Me.rbRateAll.Checked = True
                '    Case "Day"
                '        Me.rbDayRate.Checked = True
                '    Case "Overnight"
                '        Me.rbNightRate.Checked = True
                'End Select
                'Select Case Me.dtgRateTbl.CurrentRow.Cells("fut_type").Value.ToString.Trim
                '    Case "Futures"
                '        Me.RBFut.Checked = True
                '    Case "Option"
                '        Me.RBOption.Checked = True
                'End Select
                Select Case Me.dtgRateTbl.CurrentRow.Cells("trade_type").Value.ToString.Trim
                    Case "Brokerage"
                        Me.rbBrokerage.Checked = True
                    Case "Turnover"
                        Me.rbTurnover.Checked = True
                    Case "Rebate"
                        Me.rbRebate.Checked = True
                End Select
                '                Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
                'If Me.dtgRateTbl.CurrentRow.Cells("lot_range").Value.ToString.Trim.Contains("and") Then
                '    Me.LabLot_range.Text = " and " & Me.dtgRateTbl.CurrentRow.Cells("lot_range").Value.ToString.Trim.Trim.Substring(dtgRateTbl.CurrentRow.Cells("lot_range").Value.ToString.Trim.IndexOf("<"))
                'Else
                '    Me.LabLot_range.Text = ""
                'End If
                lFnRefreshTurnover()
            End If
        Else
            EmptyField()
        End If
    End Sub

    'Private Sub comboAccNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboAccNo.Text.Length > 0 Then
    '            Me.comboAccNo.Text = Me.comboAccNo.Text.ToUpper
    '            Dim Acc() As DataRow = AccDT.Select(" acc_no ='" & comboAccNo.Text & "' and txmonth= '" & Me.txtMonth.Text & "'")
    '            If Acc.Length > 0 Then
    '                Me.txtAccName.Text = Acc(0).Item("acc_name").ToString.Trim
    '                'Me.txtACGp.Text = Acc(0).Item("acc_group_f").ToString.Trim
    '                'Me.comboAE.Text = cls.GetAeByAcc(Me.comboAccNo.Text)
    '                Me.comboAE.Text = Acc(0).Item("ae_no").ToString.Trim
    '                Me.txtManNo.Text = Acc(0).Item("man_no").ToString.Trim
    '                If comboAE.Text.Length > 0 Then
    '                    Dim ae() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAE.Text & "' and txmonth= '" & Me.txtMonth.Text & "'")
    '                    If ae.Length > 0 Then
    '                        Me.txtManGroup.Text = ae(0).Item("man_group").ToString.Trim
    '                    Else
    '                        Me.txtManGroup.Text = ""
    '                    End If
    '                End If
    '            Else
    '                Acc = AccDT.Select(" acc_no ='" & comboAccNo.Text & "'")
    '                If Acc.Length > 0 Then
    '                    Me.txtAccName.Text = Acc(0).Item("acc_name").ToString.Trim
    '                Else
    '                    Me.txtAccName.Text = ""
    '                End If
    '                Me.comboAE.Text = ""
    '                Me.txtManNo.Text = ""
    '                Me.txtManName.Text = ""
    '                'Me.txtACGp.Text = ""
    '                Me.txtManGroup.Text = ""
    '            End If
    '        Else
    '            Me.txtAccName.Text = ""
    '            Me.comboAE.Text = ""
    '            Me.txtManNo.Text = ""
    '            Me.txtManName.Text = ""
    '            'Me.txtACGp.Text = ""
    '            Me.txtManGroup.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Sub comboProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboProduct.Text.Length > 0 Then
    '            Me.comboProduct.Text = Me.comboProduct.Text.ToUpper
    '            '    Dim Prod() As DataRow = ProductDT.Select(" product_group ='" & Me.comboProduct.Text & "'")
    '            '    If Prod.Length > 0 Then
    '            '        Me.txtProductName.Text = Prod(0).Item("product_name").ToString.Trim
    '            '    Else
    '            '        Me.txtProductName.Text = ""
    '            '    End If
    '            'Else
    '            '    Me.txtProductName.Text = ""
    '        End If
    '    End If
    'End Sub

    Private Sub ObjEnable(ByVal blnflag As Boolean)
        'Me.txtSrcAcc.Enabled = Not blnflag
        Me.txtSrchMan.Enabled = Not blnflag
        Me.comboSrcMonth.Enabled = False
        Me.comboSrcYr.Enabled = False
        'Me.comboSrchProd.Enabled = Not blnflag
        'Me.comboAE.Enabled = False
        Me.rbBrokerage.Enabled = blnflag
        Me.rbTurnover.Enabled = blnflag
        Me.rbRebate.Enabled = blnflag
        'Me.rbDayRate.Enabled = blnflag
        'Me.rbNightRate.Enabled = blnflag
        'Me.rbRateAll.Enabled = blnflag
        Me.btnSearch.Enabled = Not blnflag
        Me.dtgRateTbl.Enabled = Not blnflag
        'Me.dtgAC.Enabled = Not blnflag
        'Me.dtgAE.Enabled = Not blnflag
        Me.txtTOFrom.Enabled = blnflag
        Me.txtRate.Enabled = blnflag
        'Me.txtNRate.Enabled = blnflag
        Me.comboManGroup.Enabled = blnflag
        Me.txtManName.Enabled = False
        Me.txtMonth.Enabled = False
        'Me.comboSrchRateType.Enabled = Not blnflag
        Me.rbSrchBrok.Enabled = Not blnflag
        Me.rbSrchTurn.Enabled = Not blnflag
        Me.rbSrchRebate.Enabled = Not blnflag
        Me.rbSrchAll.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        Me.btnDelete.Enabled = Not blnflag
        Me.btnNew.Enabled = Not blnflag
        Me.btnEdit.Enabled = Not blnflag
        'Me.cbConsolidate.Enabled = blnflag
        'Me.rbSrchConsolidate.Enabled = Not blnflag

        Select Case ActionFlag
            Case "New"
                Me.comboManNo.Enabled = blnflag
                'Me.comboAccNo.Enabled = blnflag
                'Me.comboProduct.Enabled = blnflag
            Case "Edit"
                'Me.comboAccNo.Enabled = Not blnflag
                Me.comboManNo.Enabled = Not blnflag
                'Me.comboProduct.Enabled = Not blnflag
            Case Else
                'Me.comboAccNo.Enabled = False
                Me.comboManNo.Enabled = False
                'Me.comboProduct.Enabled = False
        End Select
    End Sub

    'Private Sub comboAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboAE.Text.Length > 0 Then
    '            Dim AE() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAE.Text & "'")
    '            If AE.Length > 0 Then
    '                Me.txtAEName.Text = AE(0).Item("ae_name").ToString.Trim
    '                Me.txtManNo.Text = AE(0).Item("man_no").ToString.Trim
    '            Else
    '                Me.txtManNo.Text = ""
    '                Me.txtAEName.Text = ""
    '            End If
    '        Else
    '            Me.txtManNo.Text = ""
    '            Me.txtAEName.Text = ""
    '        End If
    '    End If
    'End Sub

    Private Sub comboSrcMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboSrcMonth.SelectedIndexChanged, comboSrcYr.SelectedIndexChanged
        If LoadFlag = False Then
            If comboSrcMonth.Text.Length > 0 And comboSrcYr.Text.Length > 0 Then
                'Me.FncLoadProductByMonth(Me.comboSrcYr.Text.Trim & Format(Val(Me.comboSrcMonth.Text.Trim), "00"))
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                Me.txtMonth.Text = Me.comboSrcYr.Text.Trim & Format(Val(comboSrcMonth.Text.Trim), "00")
            End If
        End If
    End Sub

    Private Sub comboManNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboManNo.SelectedIndexChanged, comboManNo.LostFocus
        If LoadFlag = False Then
            If ActionFlag <> "" Then
                If Me.comboManNo.Text.Length > 0 Then
                    Me.comboManGroup.Text = ""
                    Me.comboManNo.Text = Me.comboManNo.Text.ToUpper
                    Dim Manrow() As DataRow = ManDT.Select(" man_no = '" & Me.comboManNo.Text.Trim & "'")
                    If Manrow.Length > 0 Then
                        Me.txtManName.Text = Manrow(0).Item("man_name").ToString.Trim
                    Else
                        Me.comboManGroup.Items.Clear()
                        Me.txtManName.Text = ""
                        Me.comboManGroup.Text = ""
                    End If
                    Me.comboManGroup.Text = ""
                    FncLoadManGroupByMan()
                Else
                    Me.txtManName.Text = ""
                    Me.comboManGroup.Text = ""
                End If
            End If
        End If
    End Sub

    '*******************************************************************Edit****************************************************************
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ActionFlag = "New"
        ObjEnable(True)
        EmptyField()
        Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
        If Me.rbSrchTurn.Checked Or Me.rbSrchAll.Checked Then
            Me.rbTurnover.Checked = True
        ElseIf Me.rbSrchBrok.Checked Then
            Me.rbBrokerage.Checked = True
        ElseIf Me.rbSrchRebate.Checked Then
            Me.rbRebate.Checked = True
        End If
        '        Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
        'If dtgAC.Rows.Count > 0 Then
        '    Me.comboAccNo.Text = Me.dtgAC.CurrentRow.Cells("ACNo").Value.ToString.Trim
        'End If
        'If Me.comboSrchProd.Text.Length > 0 Then
        '    Me.comboProduct.Text = Me.comboSrchProd.Text
        'End If
        comboManNo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        lFnRefreshTurnover()
        Me.comboManNo.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dtgRateTbl.SelectedRows.Count > 0 Then
            ActionFlag = "Edit"
            ObjEnable(True)
            FncLoadManGroupByMan()
            Me.txtTOFrom.Focus()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim condition As String = ""
        Dim log As String
        If Validation() = False Then
            Return
        End If
        Select Case ActionFlag
            Case "New"
                If Me.ValidManager(Me.comboManNo.Text) = False Or Me.ManDT.Select("man_no='" & Me.comboManNo.Text & "'").Length <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(52))
                    Return
                End If
                If Val(CDbl(Me.txtRate.Text)) > 100 Then
                    GSubShowInfo(GFncGetSysMsg(43))
                    Return
                End If
                If GSubShowYNConfirm(GFncGetSysMsg(40), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                If ValidateDuplicate() Then
                    GSubShowInfo(GFncGetSysMsg(44))
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                condition = "'', '', '" & Me.comboManNo.Text & "', '" & Me.comboManGroup.Text.Trim & "', '', '', 0, '" & _
                    RateType(FutFlag) & "', " & CDbl(Me.txtTOFrom.Text) & ", " & CDbl(Me.txtRate.Text) & ", 0, 0, '" & _
                    Me.txtMonth.Text & "', '" & C_type & "'"
                'log for add only
                log = "'" & GStrloginID & "', GETDATE(), '" & "A" & "', 'CommRateTblFMgp', ' ', '" & "', ' ', '" & Me.txtMonth.Text & "', '" & _
                        GFncSqlQuote(fncGenLog()) & "',"
                ObjRsid = cls.NewRecord(condition, log)
                Man = Me.comboManNo.Text.Trim
                ManGp = Me.comboManGroup.Text.Trim
                ActionFlag = ""
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                ObjEnable(False)
                Me.dtgRateTbl.Focus()
            Case "Edit"
                If Me.ValidManager(Me.comboManNo.Text) = False Then
                    GSubShowInfo(GFncGetSysMsg(52))
                    Return
                End If
                If Val(CDbl(Me.txtRate.Text)) > 100 Then
                    GSubShowInfo(GFncGetSysMsg(43))
                    Return
                End If
                If GSubShowYNConfirm(GFncGetSysMsg(48), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                If ValidateDuplicate() Then
                    GSubShowInfo(GFncGetSysMsg(44))
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                condition = " turnover_from =" & CDbl(Me.txtTOFrom.Text.Trim) & ", rate_type ='" & RateType(FutFlag) & _
                    "', man_no='" & Me.comboManNo.Text.Trim & "', man_group ='" & Me.comboManGroup.Text.Trim & "', day_rate =" & _
                    CDbl(Me.txtRate.Text) & " "
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value).Tables(0)
                If dt.Rows.Count <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    Return
                End If
                log = "'" & GStrloginID & "', GETDATE(), '" & "M" & "', 'CommRateTblFMgp', '" & _
                    dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                    Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & _
                    "', '" & GFncSqlQuote(fncGenLog()) & "' "
                cls.EditRecord(condition, Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim, log)
                ObjRsid = Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim
                Man = Me.comboManNo.Text.Trim
                ManGp = Me.comboManGroup.Text.Trim
                ActionFlag = ""
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                ObjEnable(False)
                Me.dtgRateTbl.Focus()
            Case "NewOpt"
                If Me.ValidManager(Me.comboManNoO.Text) = False Or _
                    Me.ManDT.Select("man_no='" & Me.comboManNoO.Text & "'").Length <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(52))
                    Return
                End If
                If Val(CDbl(Me.txtCommRateO.Text)) > 100 Then
                    GSubShowInfo(GFncGetSysMsg(43))
                    Return
                End If
                If GSubShowYNConfirm(GFncGetSysMsg(40), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                If OptValidateDuplicate() Then
                    GSubShowInfo(GFncGetSysMsg(44))
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                condition = "'', '', '" & Me.comboManNoO.Text.Trim & "', '" & Me.comboManGroupO.Text.Trim & "', '', '', " & _
                    CDbl(Me.txtCommRateO.Text) & ", '" & RateType(FutFlag) & "', " & CDbl(Me.txtTOFromO.Text) & ", 0, 0, 0, '" & _
                    Me.txtMonthO.Text & "', '" & C_type & "'"
                'log for add only
                log = "'" & GStrloginID & "', GETDATE(), 'A', 'CommRateTblFMgp', '', '', '', '" & Me.txtMonthO.Text & "', '" & _
                    GFncSqlQuote(fncGenLog()) & "',"
                ObjRsid = cls.NewRecord(condition, log)
                'ac = Me.comboAccNoO.Text
                'ae = Me.comboAEO.Text
                Man = Me.comboManNoO.Text.Trim
                ManGp = Me.comboManGroupO.Text.Trim
                ActionFlag = ""
                Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
                OptObjEnable(False)
                Me.dtgRateTableO.Focus()
            Case "EditOpt"
                If Me.ValidManager(Me.comboManNoO.Text) = False Then
                    GSubShowInfo(GFncGetSysMsg(52))
                    Return
                End If
                If Val(CDbl(Me.txtCommRateO.Text)) > 100 Then
                    GSubShowInfo(GFncGetSysMsg(43))
                    Return
                End If
                If GSubShowYNConfirm(GFncGetSysMsg(48), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                If OptValidateDuplicate() Then
                    GSubShowInfo(GFncGetSysMsg(44))
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                condition = " turnover_from = " & CDbl(Me.txtTOFromO.Text.Trim) & ", rate_type = '" & RateType(FutFlag) & _
                    "', man_no = '" & Me.comboManNoO.Text.Trim & "', comm_rate = " & CDbl(Me.txtCommRateO.Text) & _
                    ", man_group = '" & Me.comboManGroupO.Text.Trim & "' "
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value).Tables(0)
                If dt.Rows.Count <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    Return
                End If
                log = "'" & GStrloginID & "', GETDATE(), '" & "M" & "', 'CommRateTblFMgp', '" & _
                    dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                    Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & _
                    "', '" & GFncSqlQuote(fncGenLog()) & "' "
                cls.EditRecord(condition, Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim, log)
                ObjRsid = Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim
                Man = Me.comboManNoO.Text.Trim
                ManGp = Me.comboManGroupO.Text.Trim
                ActionFlag = ""
                Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
                OptObjEnable(False)
                Me.dtgRateTableO.Focus()
        End Select
    End Sub

    Private Function Validation() As Boolean
        Dim ErrorMsg As String = ""
        If ActionFlag = "New" Or ActionFlag = "Edit" Then
            'If Me.comboAccNo.Text.Length <= 0 Then
            '    ErrorMsg += " Account,"
            'End If
            'If Me.comboAE.Text.Length <= 0 Then
            '    ErrorMsg += "A/E code,"
            'End If
            'If Me.comboProduct.Text.Length <= 0 Then
            '    ErrorMsg += " Product,"
            'End If
            If Me.txtMonth.Text.Length <= 0 Then
                ErrorMsg += " Month,"
            End If
            If Me.txtTOFrom.TextLength <= 0 Then
                ErrorMsg += " Lot,"
            End If
            If Me.txtRate.TextLength <= 0 Then
                ErrorMsg += "Day Rate,"
            End If
            'If Me.txtNRate.TextLength <= 0 Then
            '    ErrorMsg += "Night Rate,"
            'End If
            'If Me.comboAE.Text.Length <= 0 Then
            '    ErrorMsg += "A/C Group,"
            'End If
        End If
        If ActionFlag = "NewOpt" Or ActionFlag = "EditOpt" Then
            'If Me.comboAccNoO.Text.Length <= 0 Then
            '    ErrorMsg += " Account,"
            'End If
            'If Me.comboAEO.Text.Length <= 0 Then
            '    ErrorMsg += "A/E code,"
            'End If
            'If Me.comboProductO.Text.Length <= 0 Then
            '    ErrorMsg += " Product,"
            'End If
            If Me.txtMonthO.Text.Length <= 0 Then
                ErrorMsg += " Month,"
            End If
            If Me.txtTOFromO.TextLength <= 0 Then
                ErrorMsg += " Turnover,"
            End If
            If Me.txtCommRateO.TextLength <= 0 Then
                ErrorMsg += " Comm. Rate,"
            End If
        End If
        If ErrorMsg.Length > 0 Then
            GSubShowInfo(ErrorMsg.Substring(0, ErrorMsg.Length - 1) & GFncGetSysMsg(49))
            Return False
        Else
            'Dim AccDr() As DataRow
            'If ActionFlag = "New" Or ActionFlag = "Edit" Then
            '    AccDr = AccDT.Select("acc_no='" & Me.comboAccNo.Text.Trim & "'")
            'Else
            '    AccDr = AccDT.Select("acc_no='" & Me.comboAccNoO.Text.Trim & "'")
            'End If
            'If AccDr.Length <= 0 Then
            '    GSubShowInfo(GFncGetSysMsg(5))
            '    Return False
            'End If
            'Dim ProductDr() As DataRow
            'If ActionFlag = "New" Or ActionFlag = "Edit" Then
            '    ProductDr = ProductDT.Select("product_group='" & Me.comboProduct.Text & "'")
            'Else
            '    ProductDr = ProductDT.Select("product_group='" & Me.comboProductO.Text & "'")
            'End If

            'If ProductDr.Length <= 0 Then
            '    GSubShowInfo(GFncGetSysMsg(51))
            '    Return False
            'End If
            'Dim AeDr() As DataRow
            'If ActionFlag = "New" Or ActionFlag = "Edit" Then
            '    AeDr = AeDT.Select("ae_no='" & Me.comboAE.Text & "'")
            'Else
            '    AeDr = AeDT.Select("ae_no='" & Me.comboAEO.Text & "'")
            'End If
            'If AeDr.Length <= 0 Then
            '    GSubShowInfo(GFncGetSysMsg(31))
            '    Return False
            'End If
            Return True
        End If
    End Function

    Private Sub EmptyField()
        If LoadFlag = False Then
            If ActionFlag <> "New" Then
                Me.comboManNo.SelectedIndex = -1
            End If
            Me.comboManNo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            Me.comboManGroup.Text = ""
            'Me.comboProduct.Text = ""
            Me.txtTOFrom.Text = 0
            Me.txtRate.Text = "0.0000"
            'Me.txtNRate.Text = "0.0000"
            Me.txtManName.Text = ""
            Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
            Me.rbTurnover.Checked = True
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dtgRateTbl.SelectedRows.Count > 0 Then
            If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value).Tables(0)
            If dt.Rows.Count <= 0 Then
                GSubShowInfo(GFncGetSysMsg(9))
                Return
            End If
            If GFncCheckCommStatus() Then
                Return
            End If
            'Dim log As String = "'" & GStrloginID & "', GETDATE(), '" & "D" & "', 'CommRateTblFMgp', '" & _
            '                                                   dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', ' ', " & _
            '                                                   "'" & Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & "'," & _
            '                                                   "'" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog()) & "' "
            '2010-01-13
            Dim log As String = "'" & GStrloginID & "', GETDATE(), '" & "D" & "', 'CommRateTblFMgp', '" & _
                dt.Rows(0).Item("man_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & _
                GFncSqlQuote(fncGenLog()) & " " & _
                GFncSqlQuote(cls.GfncOneFieldLog("Manager No.", dt.Rows(0).Item("man_no").ToString.Trim)) & "' "
            cls.DelRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim, log)
            'ac = Me.dtgAC.CurrentRow.Cells("ACno").Value.ToString.Trim
            ObjEnable(False)
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
            Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)
        End If
        Me.dtgRateTbl.Focus()
    End Sub

    Private Function RateType(ByVal fut As String) As String
        Dim type As String = ""
        If (fut = "Futures" And Me.rbBrokerage.Checked) Or (fut = "Options" And Me.rbBrokO.Checked) Then
            type += "BROK"
        ElseIf (fut = "Futures" And Me.rbTurnover.Checked) Or (fut = "Options" And Me.rbTurnO.Checked) Then
            type += "TURN"
        Else
            type += "REBATE"
        End If

        If fut = "Futures" Then
            type += "F"
        Else
            type += "O"
        End If
        Return type
    End Function

    Private Sub lsubGoRecord()
        If Man <> "" Then
            If TabControl.SelectedTab.Name = Me.TabRateTbl.Name Then
                For lintCnt As Integer = 0 To Me.dtgMan.RowCount - 1
                    If Me.dtgMan.Rows(lintCnt).Cells("ManNo").Value.ToString.Trim = Man And Me.dtgMan.Rows(lintCnt).Cells("ManGroup").Value.ToString.Trim = ManGp Then
                        Me.dtgMan.Rows(lintCnt).Cells("ManGroup").Selected = True
                        Exit For
                    End If
                Next
                Me.dtgMan_SelectionChanged(Nothing, System.EventArgs.Empty)

                If ObjRsid > 0 Then
                    For lintCnt As Integer = 0 To Me.dtgRateTbl.Rows.Count - 1
                        If Me.dtgRateTbl.Rows(lintCnt).Cells("rsid").Value.ToString.Trim = ObjRsid Then
                            Me.dtgRateTbl.Rows(lintCnt).Cells("rate").Selected = True
                            Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)

                            Me.dtgRateTbl.Focus()
                            Exit For
                        End If
                    Next
                End If
            Else
                'For lintCnt As Integer = 0 To Me.dtgACtblO.RowCount - 1
                '    If Me.dtgACtblO.Rows(lintCnt).Cells("ACNoO").Value.ToString.Trim = ac Then
                '        Me.dtgACtblO.Rows(lintCnt).Cells("ACNoO").Selected = True
                '    End If
                'Next
                'Me.dtgACtblO_SelectionChanged(Nothing, System.EventArgs.Empty)
                If Man <> "" Then
                    For lintCnt As Integer = 0 To Me.dtgManO.RowCount - 1
                        If Me.dtgManO.Rows(lintCnt).Cells("ManNoO").Value.ToString.Trim = Man And Me.dtgManO.Rows(lintCnt).Cells("ManGroupO").Value.ToString.Trim = ManGp Then
                            Me.dtgManO.Rows(lintCnt).Cells("ManNoO").Selected = True
                            Exit For
                        End If
                    Next
                    Me.dtgManO_SelectionChanged(Nothing, System.EventArgs.Empty)
                End If
                If ObjRsid > 0 Then
                    For lintCnt As Integer = 0 To Me.dtgRateTableO.Rows.Count - 1
                        If Me.dtgRateTableO.Rows(lintCnt).Cells("rsidO").Value.ToString.Trim = ObjRsid Then
                            Me.dtgRateTableO.Rows(lintCnt).Cells("comm_rateO").Selected = True
                            Me.dtgRateTableO_SelectionChanged(Nothing, System.EventArgs.Empty)

                            Me.dtgRateTableO.Focus()
                            Exit For
                        End If
                    Next
                End If
            End If
            ObjRsid = 0
            Man = ""
        End If
    End Sub

    Private Sub TabControl_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl.Selecting
        If Me.btnNew.Enabled = False And Me.TabControl.SelectedTab.Name <> Me.TabRateTbl.Name Then
            e.Cancel = True
            Return
        End If
        If (ActionFlag = "EditOpt" Or ActionFlag = "NewOpt") And Me.TabControl.SelectedTab.Name <> Me.TabPageOptions.Name Then
            e.Cancel = True
            Return
        End If
        If Me.TabControl.SelectedTab.Name = Me.TabRateTbl.Name Then
            FutFlag = "Futures"
            Me.comboSrcMonth.Text = Me.comboSrchMonthO.Text
            Me.comboSrcYr.Text = Me.comboSrchYrO.Text
            Me.txtSrchMan.Text = Me.txtSrchManO.Text
            If Me.rbSrchAllO.Checked Then
                Me.rbSrchAll.Checked = True
            ElseIf Me.rbSrchBrokO.Checked Then
                Me.rbSrchBrok.Checked = True
            ElseIf Me.rbSrchRebateO.Checked Then
                Me.rbSrchRebate.Checked = True
            Else
                Me.rbTurnover.Checked = True
            End If

            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
        If Me.TabControl.SelectedTab.Name = Me.TabPageOptions.Name Then
            FutFlag = "Options"
            Me.comboSrchMonthO.Text = Me.comboSrcMonth.Text
            Me.comboSrchYrO.Text = Me.comboSrcYr.Text
            Me.txtSrchManO.Text = Me.txtSrchMan.Text
            If Me.rbSrchAll.Checked Then
                Me.rbSrchAllO.Checked = True
            ElseIf Me.rbSrchBrok.Checked Then
                Me.rbSrchBrokO.Checked = True
            ElseIf Me.rbSrchRebate.Checked Then
                Me.rbSrchRebateO.Checked = True
            Else
                Me.rbSrchTurnO.Checked = True
            End If
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Function fncGenLog() As String
        Dim lstrLog As String = ""
        Select Case ActionFlag
            Case "Edit"
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim).Tables(0)
                If dt.Rows.Count > 0 Then
                    'If Me.comboAE.Text.Trim.Length > 0 And Me.comboAE.Text.Trim <> dt.Rows(0).Item("ae_no").ToString.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("ae_no", dt.Rows(0).Item("ae_no").ToString.Trim, Me.comboAE.Text.Trim)
                    'End If
                    'If Me.txtRate.Text.Trim.Length > 0 And Me.txtRate.Text.Trim <> dt.Rows(0).Item("day_rate").ToString.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("Day_rate", dt.Rows(0).Item("day_rate").ToString.Trim, Me.txtRate.Text.Trim)
                    'End If
                    'If Me.txtNightRate.Text.Trim.Length > 0 And Me.txtNightRate.Text.Trim <> dt.Rows(0).Item("rsid").ToString.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("Night_rate", dt.Rows(0).Item("night_rate").ToString.Trim, Me.txtNightRate.Text.Trim)
                    'End If
                    If Me.comboManNo.Text.Trim.Length > 0 And Me.comboManNo.Text.Trim <> dt.Rows(0).Item("man_no").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Manager No.", dt.Rows(0).Item("man_no").ToString.Trim, Me.comboManNo.Text.Trim) & " "
                    End If
                    If Me.txtTOFrom.Text.Trim.Length > 0 And CDbl(Me.txtTOFrom.Text.Trim) <> CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim) Then
                        lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim), CDbl(Me.txtTOFrom.Text.Trim)) & " "
                    End If
                    If Me.RateType(FutFlag).Trim <> dt.Rows(0).Item("rate_type").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Rate Type", dt.Rows(0).Item("rate_type").ToString.Trim, RateType(FutFlag).Trim) & " "
                    End If
                    If Me.txtRate.Text.Length > 0 And dt.Rows(0).Item("day_rate").ToString.Trim <> Me.txtRate.Text.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Day Rate", dt.Rows(0).Item("day_rate").ToString.Trim, Me.txtRate.Text.Trim) & " "
                    End If
                    'If Me.txtNRate.Text.Length > 0 And dt.Rows(0).Item("night_rate").ToString.Trim <> Me.txtNRate.Text.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("Night_rate", dt.Rows(0).Item("night_rate").ToString.Trim, Me.txtNRate.Text.Trim)

                    'End If
                End If
            Case "New"
                'If Me.comboAE.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("ae_no", Me.comboAE.Text.Trim)
                'End If
                'If Me.comboAccNo.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("Acc_no", Me.comboAccNo.Text.Trim)
                'End If
                'If Me.comboProduct.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("product_group", Me.comboProduct.Text.Trim)
                'End If
                If Me.txtRate.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Day Rate", Me.txtRate.Text.Trim) & " "
                End If
                'If Me.txtNRate.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("Night_rate", Me.txtNRate.Text.Trim)
                'End If

                'If Me.txtMonth.Text.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("comm_month", txtMonth.Text.Trim)
                'End If
                If Me.txtTOFrom.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(Me.txtTOFrom.Text.Trim)) & " "
                End If
                If Me.comboManNo.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Manager No.", Me.comboManNo.Text.Trim) & " "
                End If
                lstrLog += cls.GfncOneFieldLog("Rate Type", RateType(FutFlag)) & " "
                lstrLog += cls.GfncOneFieldLog("Commission Type", C_type) & " "
            Case "EditOpt"
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim).Tables(0)
                If dt.Rows.Count > 0 Then
                    'If Me.comboAEO.Text.Trim.Length > 0 And Me.comboAEO.Text.Trim <> dt.Rows(0).Item("ae_no").ToString.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("ae_no", dt.Rows(0).Item("ae_no").ToString.Trim, Me.comboAEO.Text.Trim)
                    'End If
                    If Me.comboManNoO.Text.Trim.Length > 0 And Me.comboManNoO.Text.Trim <> dt.Rows(0).Item("man_no").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Manager No.", dt.Rows(0).Item("man_no").ToString.Trim, Me.comboManNoO.Text.Trim) & " "
                    End If
                    If Me.txtTOFromO.Text.Trim.Length > 0 And CDbl(Me.txtTOFromO.Text.Trim) <> CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim) Then
                        lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim), CDbl(Me.txtTOFromO.Text.Trim)) & " "
                    End If
                    If Me.RateType(FutFlag).Trim <> dt.Rows(0).Item("rate_type").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Rate Type", dt.Rows(0).Item("rate_type").ToString.Trim, RateType(FutFlag).Trim) & " "
                    End If
                    If Me.txtCommRateO.Text.Length > 0 And Me.txtCommRateO.Text <> dt.Rows(0).Item("comm_rate").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Commission Rate", dt.Rows(0).Item("comm_rate").ToString.Trim, Me.txtCommRateO.Text.Trim) & " "
                    End If
                End If
            Case "NewOpt"
                'If Me.comboAEO.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("ae_no", Me.comboAEO.Text.Trim)
                'End If
                'If Me.comboAccNoO.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("Acc_no", Me.comboAccNoO.Text.Trim)
                'End If
                'If Me.comboProductO.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("product_group", Me.comboProductO.Text.Trim)
                'End If
                If Me.txtCommRateO.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Commission Rate", Me.txtCommRateO.Text.Trim) & " "
                End If
                'If Me.txtMonthO.Text.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("Comm_month", txtMonthO.Text.Trim)
                'End If
                If Me.txtTOFromO.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(Me.txtTOFromO.Text.Trim)) & " "
                End If
                If Me.comboManNoO.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Manager No.", Me.comboManNoO.Text.Trim) & " "
                End If
                lstrLog += cls.GfncOneFieldLog("Rate Type", RateType(FutFlag)) & " "
                lstrLog += cls.GfncOneFieldLog("Commission Type", C_type) & " "
        End Select
        Return lstrLog
    End Function

    Private Function ValidateDuplicate() As Boolean
        Dim condition As String = " and man_no='" & Me.comboManNo.Text.Trim & "' and turnover_from =" & _
            CDbl(Me.txtTOFrom.Text.Trim) & " and comm_month ='" & Me.txtMonth.Text.Trim & "' and comm_type='" & C_type & _
            "' and rate_type='" & RateType(FutFlag) & "' "
        If ActionFlag = "Edit" Then
            condition += " and rsid<>'" & Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim & "' "
        End If
        Return cls.ValidateDuplicate(condition)
    End Function


    Private Sub rbSrchAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchAll.CheckedChanged
        If LoadFlag = False And rbSrchAll.Checked Then
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchBrok_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchBrok.CheckedChanged
        If LoadFlag = False And Me.rbSrchBrok.Checked Then
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchRebate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchRebate.CheckedChanged
        If LoadFlag = False And Me.rbSrchRebate.Checked Then
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchNormal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchTurn.CheckedChanged
        If LoadFlag = False And Me.rbSrchTurn.Checked Then
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    'Private Sub comboSrchRateType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        btnSearch_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    Private Sub lFnRefreshTurnover()
        Dim comm_month As String = Me.txtMonth.Text
        Dim Rtype As String = RateType(FutFlag)
        Dim ae_num As String = ""
        Dim acc As String = ""
        Dim product As String = ""
        Dim turnover As String = CDbl(Me.txtTOFrom.Text)
        Dim manNo As String = Me.comboManNo.Text
        Dim lds As DataSet
        Dim turnoverTo As String = ""
        lds = cls.lFncGetNextComm(comm_month, Rtype, acc, ae_num, Nothing, manNo, Nothing, product, C_type, turnover)
        If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
            Me.LabLot_range.Text = ""
        Else
            Me.LabLot_range.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,###.00")
        End If
    End Sub

    Private Sub LabLot_range_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTOFrom.LostFocus
        lFnRefreshTurnover()
    End Sub

    'Private Sub rbNormal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    lFnRefreshTurnover()

    'End Sub

    'Private Sub rbDayRate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If rbDayRate.Checked Then
    '        lFnRefreshTurnover()
    '    End If
    'End Sub

    'Private Sub rbNightRate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If rbNightRate.Checked Then
    '        lFnRefreshTurnover()
    '    End If
    'End Sub

    'Private Sub rbRateAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If rbRateAll.Checked Then
    '        lFnRefreshTurnover()
    '    End If
    'End Sub
    ''*****************************************************************************OPTIONS**************************************************************************************
    Private Sub btnSearchO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEnquiryO.Click
        If LoadFlag = False Then
            Dim ACcondition As String = ""
            'If Me.txtSrchAccO.Text.Length > 0 Then
            '    ACcondition += " and upper(a.acc_no) like '%" & Me.txtSrchAccO.Text & "%' "
            'End If
            'If Me.comboSrchProdO.Text.Length > 0 Then
            '    ACcondition += " and b.product_group= '" & Me.comboSrchProdO.Text & "' "
            'End If
            If Me.txtSrchManO.Text.Length > 0 Then
                ACcondition += " and upper(b.man_no) like '%" & Me.txtSrchManO.Text.ToUpper & "%' "
            End If
            If Me.rbSrchAllO.Checked Then
                ACcondition += " and (b.rate_type ='BROKO' or b.rate_type ='TURNO' or b.rate_type ='REBATEO')"
            Else
                If Me.rbSrchBrokO.Checked Then
                    ACcondition += " and b.rate_type ='BROKO' "
                ElseIf Me.rbSrchTurnO.Checked Then
                    ACcondition += " and b.rate_type ='TURNO' "
                ElseIf Me.rbSrchRebateO.Checked Then
                    ACcondition += " and b.rate_type ='REBATEO' "
                End If
            End If
            ACcondition &= " and b.comm_type='" & C_type & "' and b.comm_month='" & _
                Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00") & "' "
            Me.dtgManO.DataSource = cls.EnquiryManTbl(ACcondition).Tables(0)
            lsubGoRecord()
            If dtgManO.RowCount <= 0 Then
                'dtgAetblO.DataSource = cls.EnquiryAETbl(" and 1=0 ").Tables(0)
                Me.dtgRateTableO.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
                'Me.dtgManO.DataSource = cls.EnquiryManTbl(" and 1=0 ").Tables(0)
                Me.btnEdit.Enabled = False
                Me.btnDelete.Enabled = False
                EmptyOptField()
            Else
                Me.btnEdit.Enabled = True
                Me.btnDelete.Enabled = True
            End If
            Me.dtgManO.Focus()
        End If
    End Sub

    'Private Sub dtgACtblO_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ActionFlag = "" And LoadFlag = False Then
    '        If Me.dtgACtblO.SelectedRows.Count > 0 Then
    '            Dim condition As String = " and b.comm_type='" & C_type & "'  and b.acc_no='" & Me.dtgACtblO.CurrentRow.Cells("ACNoO").Value.ToString.Trim & "'  and b.comm_month ='" & Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00") & "' "

    '            If Me.rbSrchAllO.Checked Then
    '                condition += " and (left(b.rate_type,4) ='INTO' or left(b.rate_type,4) ='NORO' )"
    '            Else
    '                If Me.rbSrchNormalO.Checked Then
    '                    condition += " and left(b.rate_type,4) ='NORO' "
    '                Else
    '                    condition += " and left(b.rate_type,4) ='INTO'"
    '                End If
    '            End If
    '            If Me.txtSrchManO.Text.Length > 0 Then
    '                condition += " and upper(b.man_no) like '%" & Me.txtSrchManO.Text.ToUpper & "%' "
    '            End If
    '            If Me.comboSrchProdO.Text.Length > 0 Then
    '                condition += " and b.product_group= '" & Me.comboSrchProdO.Text & "' "
    '            End If
    '            Me.comboAccNoO.Text = Me.dtgACtblO.CurrentRow.Cells("ACNoO").Value.ToString.Trim
    '            Me.dtgAetblO.DataSource = cls.EnquiryAETbl(condition).Tables(0)

    '            dtgAetblO_SelectionChanged(Nothing, System.EventArgs.Empty)
    '        End If
    '    End If
    'End Sub

    'Private Sub dtgAetblO_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ActionFlag = "" And LoadFlag = False Then
    '        If Me.dtgAetblO.Rows.Count > 0 Then
    '            If Me.dtgAetblO.SelectedRows.Count > 0 Then
    '                Dim condition As String = " and b.comm_type='" & C_type & "' and b.acc_no='" & Me.comboAccNoO.Text & "'  and b.ae_no='" & Me.dtgAetblO.CurrentRow.Cells("AENoO").Value.ToString.Trim & "' and b.comm_month ='" & Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00") & "' "
    '                If Me.txtSrchManO.Text.Length > 0 Then
    '                    condition += " and upper(b.man_no) like '%" & Me.txtSrchManO.Text.ToUpper & "%' "
    '                End If
    '                If Me.rbSrchAllO.Checked Then
    '                    condition += " and (left(b.rate_type,4) ='INTO' or left(b.rate_type,4) ='NORO' )"
    '                Else
    '                    If Me.rbSrchNormalO.Checked Then
    '                        condition += " and left(b.rate_type,4) ='NORO' "
    '                    Else
    '                        condition += " and left(b.rate_type,4) ='INTO'"
    '                    End If
    '                End If
    '                If Me.comboSrchProdO.Text.Length > 0 Then
    '                    condition += " and b.product_group= '" & Me.comboSrchProdO.Text & "' "
    '                End If
    '                Me.comboAEO.Text = Me.dtgAetblO.CurrentRow.Cells("AENoO").Value.ToString.Trim
    '                Me.dtgManO.DataSource = cls.EnquiryManTbl(condition).Tables(0)
    '            End If
    '        Else
    '            Me.dtgRateTableO.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
    '            Me.btnEditO.Enabled = False
    '            Me.btnDelO.Enabled = False
    '            EmptyOptField()
    '        End If
    '    End If
    'End Sub

    Private Sub dtgManO_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgManO.SelectionChanged
        If ActionFlag = "" And LoadFlag = False Then
            If Me.dtgManO.Rows.Count > 0 Then
                If Me.dtgManO.SelectedRows.Count > 0 Then
                    Dim condition As String = " and comm_type='" & C_type & "' and comm_month ='" & Me.comboSrchYrO.Text & _
                        Format(Val(Me.comboSrchMonthO.Text), "00") & "' "
                    condition &= " and man_no= '" & Me.dtgManO.CurrentRow.Cells("ManNoO").Value & "' and  man_group= '" & _
                        Me.dtgManO.CurrentRow.Cells("ManGroupO").Value & "' "
                    If Me.rbSrchAllO.Checked Then
                        condition += " and (rate_type ='BROKO' or rate_type ='TURNO' or rate_type ='REBATEO' )"
                    Else
                        If Me.rbSrchBrokO.Checked Then
                            condition += " and rate_type ='BROKO' "
                        ElseIf Me.rbSrchTurnO.Checked Then
                            condition += " and rate_type ='TURNO'"
                        ElseIf Me.rbSrchRebateO.Checked Then
                            condition += " and rate_type ='REBATEO'"
                        End If
                    End If
                    'If Me.comboSrchProdO.Text.Length > 0 Then
                    '    condition += " and product_group= '" & Me.comboSrchProdO.Text.ToUpper & "' "
                    'End If
                    Me.dtgRateTableO.DataSource = cls.EnquiryRateTbl(condition, " product_group asc, comm_month asc, " & _
                        "acc_group asc, rate_type desc, turnover_from asc, ")
                End If
        Else
            Me.dtgRateTableO.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
            Me.btnEditO.Enabled = False
            Me.btnDelO.Enabled = False
            EmptyOptField()
        End If
        End If
    End Sub

    Private Sub dtgRateTableO_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgRateTableO.SelectionChanged
        If LoadFlag = False Then
            If dtgRateTableO.Rows.Count > 0 And dtgManO.Rows.Count > 0 Then
                'Me.comboAccNoO.Text = Me.dtgRateTableO.CurrentRow.Cells("acc_noO").Value.ToString.Trim
                'Me.comboProductO.Text = Me.dtgRateTableO.CurrentRow.Cells("product_groupO").Value.ToString.Trim
                Me.txtMonthO.Text = Me.dtgRateTableO.CurrentRow.Cells("comm_monthO").Value.ToString.Trim
                Me.txtTOFromO.Text = Me.dtgRateTableO.CurrentRow.Cells("turnover_fromO").Value.ToString.Trim
                Me.txtCommRateO.Text = Me.dtgRateTableO.CurrentRow.Cells("comm_rateO").Value.ToString.Trim
                Me.comboManNoO.Text = Me.dtgManO.CurrentRow.Cells("ManNoO").Value.ToString.Trim
                Me.comboManGroupO.Text = Me.dtgManO.CurrentRow.Cells("ManGroupO").Value.ToString.Trim
                Me.txtManNameO.Text = Me.dtgManO.CurrentRow.Cells("ManNameO").Value.ToString.Trim
                Select Case Me.dtgRateTableO.CurrentRow.Cells("trade_typeO").Value.ToString.Trim
                    Case "Brokerage"
                        Me.rbBrokO.Checked = True
                    Case "Turnover"
                        Me.rbTurnO.Checked = True
                    Case "Rebate"
                        Me.rbRebateO.Checked = True
                End Select
                lFnRefreshTurnoverOpt()
            End If
        Else
            EmptyOptField()
        End If
    End Sub

    Private Sub btnNewO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewO.Click
        ActionFlag = "NewOpt"
        OptObjEnable(True)
        EmptyOptField()
        Me.txtMonthO.Text = Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00")
        If Me.rbSrchTurnO.Checked Or Me.rbSrchAllO.Checked Then
            Me.rbTurnO.Checked = True
        ElseIf Me.rbSrchBrokO.Checked Then
            Me.rbBrokO.Checked = True
        ElseIf Me.rbSrchRebateO.Checked Then
            Me.rbRebateO.Checked = True
        End If
        'Me.cbConsolidateO_CheckedChanged(Nothing, System.EventArgs.Empty)
        'If Me.dtgACtblO.Rows.Count > 0 Then
        '    Me.comboAccNoO.Text = Me.dtgACtblO.CurrentRow.Cells("ACNoO").Value.ToString.Trim
        'Else
        '    Me.comboAccNoO.Text = ""
        'End If
        'If Me.comboSrchProdO.Text.Length > 0 Then
        '    Me.comboProductO.Text = Me.comboSrchProdO.Text
        'End If
        comboManNoO_SelectedIndexChanged(Nothing, System.EventArgs.Empty)

        Me.comboManNoO.Focus()
    End Sub

    Private Sub btnEditO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditO.Click
        If Me.dtgRateTableO.SelectedRows.Count > 0 Then
            ActionFlag = "EditOpt"
            OptObjEnable(True)
            FncLoadManGroupByManO()
            Me.txtTOFromO.Focus()
        End If
    End Sub

    'Private Sub comboAccNoO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboAccNoO.Text.Length > 0 Then
    '            Me.comboAccNoO.Text = Me.comboAccNoO.Text.ToUpper
    '            Dim Acc() As DataRow = AccDT.Select(" acc_no ='" & comboAccNoO.Text & "' and txmonth= '" & Me.txtMonthO.Text & "'")
    '            If Acc.Length > 0 Then
    '                Me.txtAccNameO.Text = Acc(0).Item("acc_name").ToString.Trim
    '                'Me.txtACGpO.Text = Acc(0).Item("acc_group_f").ToString.Trim
    '                Me.comboAEO.Text = Acc(0).Item("ae_no").ToString.Trim
    '                Me.comboManNoO.Text = Acc(0).Item("man_no").ToString.Trim
    '                ' Me.txtManGroupO.Text = Acc(0).Item("man_group_f").ToString.Trim
    '                If comboAEO.Text.Length > 0 Then
    '                    Dim ae() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAEO.Text & "' and txmonth= '" & Me.txtMonthO.Text & "'")
    '                    If ae.Length > 0 Then
    '                        Me.txtManGroupO.Text = ae(0).Item("man_group").ToString.Trim
    '                    Else
    '                        Me.txtManGroupO.Text = ""
    '                    End If
    '                End If
    '            Else
    '                Acc = AccDT.Select(" acc_no ='" & comboAccNoO.Text & "'")
    '                If Acc.Length > 0 Then
    '                    Me.txtAccNameO.Text = Acc(0).Item("acc_name").ToString.Trim
    '                Else
    '                    Me.txtAccNameO.Text = ""
    '                End If
    '                Me.comboAEO.Text = ""
    '                Me.comboManNoO.Text = ""
    '                Me.txtManNameO.Text = ""
    '                Me.txtManGroupO.Text = ""
    '            End If
    '        Else
    '            Me.txtAccNameO.Text = ""
    '            Me.comboManNoO.Text = ""
    '            Me.txtManNameO.Text = ""
    '            Me.txtManGroupO.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Sub comboProductO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboProductO.Text.Length > 0 Then
    '            Me.comboProductO.Text = Me.comboProductO.Text.ToUpper
    '            '    Dim Prod() As DataRow = ProductDT.Select(" product_group ='" & Me.comboProductO.Text & "'")
    '            '    If Prod.Length > 0 Then
    '            '        Me.txtProductNameO.Text = Prod(0).Item("product_name").ToString.Trim
    '            '    Else
    '            '        Me.txtProductNameO.Text = ""
    '            '    End If

    '            'Else
    '            '    Me.txtProductNameO.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Sub comboAEO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboAEO.Text.Length > 0 Then
    '            Dim AE() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAEO.Text & "'")
    '            Me.txtAENameO.Text = AE(0).Item("ae_name").ToString.Trim
    '            Me.comboManNoO.Text = AE(0).Item("man_no").ToString.Trim
    '        Else
    '            Me.comboManNoO.Text = ""
    '            Me.txtAENameO.Text = ""
    '        End If
    '    End If
    'End Sub

    Private Sub OptObjEnable(ByVal blnflag As Boolean)
        'Me.txtSrchAccO.Enabled = Not blnflag
        Me.txtSrchManO.Enabled = Not blnflag
        Me.comboSrchMonthO.Enabled = False
        Me.comboSrchYrO.Enabled = False
        'Me.comboAEO.Enabled = False
        'Me.comboSrchProdO.Enabled = Not blnflag
        Me.rbBrokO.Enabled = blnflag
        Me.rbTurnO.Enabled = blnflag
        Me.rbRebateO.Enabled = blnflag
        Me.btnEnquiryO.Enabled = Not blnflag
        Me.dtgRateTableO.Enabled = Not blnflag
        'Me.dtgACtblO.Enabled = Not blnflag
        'Me.dtgAetblO.Enabled = Not blnflag
        Me.txtTOFromO.Enabled = blnflag
        Me.txtCommRateO.Enabled = blnflag
        Me.comboManNoO.Enabled = False
        Me.txtMonthO.Enabled = False
        Me.txtManNameO.Enabled = False
        Me.comboManGroupO.Enabled = blnflag
        Me.rbSrchTurnO.Enabled = Not blnflag
        Me.rbSrchBrokO.Enabled = Not blnflag
        Me.rbSrchRebateO.Enabled = Not blnflag
        Me.rbSrchAllO.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        Me.btnDelO.Enabled = Not blnflag
        Me.btnNewO.Enabled = Not blnflag
        Me.btnEditO.Enabled = Not blnflag
        'Me.cbConsolidateO.Enabled = blnflag
        'Me.rbSrchConsolidateO.Enabled = Not blnflag
        Select Case ActionFlag
            Case "NewOpt"
                Me.comboManNoO.Enabled = blnflag
                'Me.comboAccNoO.Enabled = blnflag
                'Me.comboProductO.Enabled = blnflag
            Case "EditOpt"
                Me.comboManNoO.Enabled = Not blnflag
                'Me.comboAccNoO.Enabled = Not blnflag
                'Me.comboProductO.Enabled = Not blnflag
            Case Else
                'Me.comboAccNoO.Enabled = False
                Me.comboManNoO.Enabled = False
                'Me.comboProductO.Enabled = False
        End Select
    End Sub


    Private Sub btnDelO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelO.Click
        If Me.dtgRateTableO.SelectedRows.Count > 0 Then
            If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value).Tables(0)
            If dt.Rows.Count <= 0 Then
                GSubShowInfo(GFncGetSysMsg(9))
                Return
            End If
            If GFncCheckCommStatus() Then
                Return
            End If
            Dim log As String = "'" & GStrloginID & "', GETDATE(), '" & "D" & "', 'CommRateTblFMgp', '" & _
                dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & _
                "', '" & GFncSqlQuote(fncGenLog()) & " " & _
                GFncSqlQuote(cls.GfncOneFieldLog("Manager No.", dt.Rows(0).Item("man_no").ToString.Trim)) & "' "
            cls.DelRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim, log)
            'ac = Me.dtgACtbl.CurrentRow.Cells("ACnoO").Value.ToString.Trim
            ObjEnable(False)
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
            Me.dtgRateTableO.Focus()
        End If
    End Sub

    Private Function OptValidateDuplicate() As Boolean
        Dim condition As String = " and man_no = '" & Me.comboManNoO.Text.Trim & "' and turnover_from = " & _
            CDbl(Me.txtTOFromO.Text.Trim) & " and comm_month = '" & Me.txtMonthO.Text.Trim & "' and comm_type = '" & C_type & _
            "' and rate_type = '" & RateType(FutFlag) & "' "
        If ActionFlag = "EditOpt" Then
            condition += " and rsid<>'" & Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim & "' "
        End If
        Return cls.ValidateDuplicate(condition)
    End Function

    Private Sub comboSrchMonthO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboSrchMonthO.SelectedIndexChanged
        'Me.FncLoadProductByMonthO(Me.comboSrchYrO.Text.Trim & Format(Val(Me.comboSrchMonthO.Text.Trim), "00"))
        Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub comboSrchYrO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboSrchYrO.SelectedIndexChanged
        'Me.FncLoadProductByMonthO(Me.comboSrchYrO.Text.Trim & Format(Val(Me.comboSrchMonthO.Text.Trim), "00"))
        Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub rbSrchBrokO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchBrokO.CheckedChanged
        If rbSrchBrokO.Checked = True And LoadFlag = False Then
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchRebateO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchRebateO.CheckedChanged
        If rbSrchRebateO.Checked = True And LoadFlag = False Then
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchAllO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchAllO.CheckedChanged
        If rbSrchAllO.Checked = True And LoadFlag = False Then
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchTurnO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchTurnO.CheckedChanged
        If rbSrchTurnO.Checked = True And LoadFlag = False Then
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub lFnRefreshTurnoverOpt()
        Dim comm_month As String = Me.txtMonthO.Text
        Dim Rtype As String = RateType(FutFlag)
        Dim ae_num As String = ""
        Dim acc As String = ""
        Dim product As String = ""
        Dim turnover As String = CDbl(Me.txtTOFromO.Text)
        Dim manno As String = Me.comboManNoO.Text
        Dim lds As DataSet
        Dim turnoverTo As String = ""
        lds = cls.lFncGetNextComm(comm_month, Rtype, acc, ae_num, Nothing, manno, Nothing, product, C_type, turnover)
        If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
            Me.LabLot_rangeO.Text = ""
        Else
            Me.LabLot_rangeO.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,###.00")
        End If
    End Sub

    Private Sub LabLot_rangeO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTOFromO.LostFocus
        lFnRefreshTurnoverOpt()
    End Sub

    Private Sub comboSrchProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If LoadFlag = False Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub comboSrchProdO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If LoadFlag = False Then
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub EmptyOptField()
        If LoadFlag = False Then
            If ActionFlag <> "NewOpt" Then
                'Me.comboAccNoO.Text = ""
                'Me.txtAccNameO.Text = ""
                Me.comboManNoO.Text = ""
                Me.comboManGroupO.Text = ""
            End If
            Me.comboManNoO_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            Me.comboManGroupO.Text = ""
            'Me.comboProductO.Text = ""
            Me.txtTOFromO.Text = 0
            Me.txtCommRateO.Text = "0.0000"
            'Me.txtACGp.Text = ""
            Me.txtMonthO.Text = Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00")
            'Me.comboAEO.Text = ""
            Me.rbTurnO.Checked = True
        End If
    End Sub

    Private Sub comboManNoO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboManNoO.SelectedIndexChanged, comboManNo.LostFocus
        If LoadFlag = False Then
            If ActionFlag <> "" Then
                If Me.comboManNoO.Text.Length > 0 Then
                    Me.comboManGroupO.Text = ""
                    Dim ManO() As DataRow = ManDT.Select(" man_no = '" & Me.comboManNoO.Text.Trim & "'")
                    If ManO.Length > 0 Then
                        Me.txtManNameO.Text = ManO(0).Item("man_name").ToString.Trim
                    Else
                        Me.comboManGroupO.Items.Clear()
                        Me.txtManNameO.Text = ""
                        Me.comboManGroupO.Text = ""
                    End If
                    FncLoadManGroupByManO()
                Else
                    Me.txtManNameO.Text = ""
                    Me.comboManGroupO.Text = ""
                End If
            End If
        End If
    End Sub

    Private Function ValidManager(ByVal Manno As String) As Boolean
        If Manno.Length > 0 Then
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub GetManGroupByManno(ByVal Manno As String, ByVal Month As String)
        Me.comboManGroup.Items.Clear()
        If Me.comboManNo.Text.Trim.Length > 0 Then
            Dim dr() As DataRow = ManGPDt.Select("man_no ='" & Manno & "' and txmonth='" & Month & "'", "man_group asc")
            For row As Integer = 0 To dr.Length - 1
                Me.comboManGroup.Items.Add(dr(row).Item("man_group"))
            Next
        End If
    End Sub

    Private Sub GetManGroupByMannoO(ByVal Manno As String, ByVal Month As String)
        Me.comboManGroupO.Items.Clear()
        If Me.comboManNoO.Text.Trim.Length > 0 Then
            Dim dr() As DataRow = ManGPDt.Select("man_no ='" & Manno & "' and txmonth='" & Month & "'", "man_group asc")
            For row As Integer = 0 To dr.Length - 1
                Me.comboManGroupO.Items.Add(dr(row).Item("man_group"))
            Next
        End If
    End Sub

    'Private Sub rbSrchConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.rbSrchConsolidate.Checked Then
    '            btnSearch_Click(Nothing, System.EventArgs.Empty)
    '        End If
    '    End If
    'End Sub
    'Private Sub rbSrchConsolidateO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.rbSrchConsolidateO.Checked Then
    '            btnSearchO_Click(Nothing, System.EventArgs.Empty)
    '        End If
    '    End If
    'End Sub

    'Private Sub cbConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.cbConsolidate.Checked Then
    '        Me.GroupTradeType.Visible = False
    '    Else
    '        GroupTradeType.Visible = True
    '    End If
    'End Sub

    'Private Sub cbConsolidateO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.cbConsolidateO.Checked Then
    '        Me.GroupTradeTypeO.Visible = False
    '    Else
    '        GroupTradeTypeO.Visible = True
    '    End If
    'End Sub

    'Private Sub FncLoadProductByMonth(ByVal month As String)
    '    If LoadFlag = False Then

    '        Dim ProdDr() As DataRow
    '        Me.comboProduct.Items.Clear()
    '        Me.comboSrchProd.Items.Clear()
    '        If month.Length > 0 Then
    '            ProdDr = ProductDT.Select("txmonth ='" & month & "'", "product_group asc")
    '            If ProdDr.Length > 0 Then
    '                Me.comboSrchProd.Items.Add("")
    '                For row As Integer = 0 To ProdDr.Length - 1
    '                    Me.comboProduct.Items.Add(ProdDr(row).Item("product_group"))
    '                    Me.comboSrchProd.Items.Add(ProdDr(row).Item("product_group"))
    '                Next
    '            End If
    '        End If
    '    End If
    'End Sub
    'Private Sub FncLoadProductByMonthO(ByVal month As String)
    '    If LoadFlag = False Then
    '        Dim ProdDr() As DataRow
    '        Me.comboProductO.Items.Clear()
    '        Me.comboSrchProdO.Items.Clear()
    '        If month.Length > 0 Then
    '            ProdDr = ProductDT.Select("txmonth ='" & month & "'", "product_group asc")
    '            If ProdDr.Length > 0 Then
    '                Me.comboSrchProdO.Items.Add("")
    '                For row As Integer = 0 To ProdDr.Length - 1
    '                    Me.comboProductO.Items.Add(ProdDr(row).Item("product_group"))
    '                    Me.comboSrchProdO.Items.Add(ProdDr(row).Item("product_group"))
    '                Next
    '            End If

    '        End If
    '    End If
    'End Sub

    Private Sub FncLoadManGroupByMan()
        Me.comboManGroup.Items.Clear()
        Dim Gp() As DataRow = ManGPDt.Select("man_no ='" & Me.comboManNo.Text & "' and txmonth='" & Me.txtMonth.Text & "'", "man_group")
        For Each dr As DataRow In Gp
            Me.comboManGroup.Items.Add(dr.Item("man_group"))
            Me.comboManGroup.SelectedIndex = 0
        Next
    End Sub

    Private Sub FncLoadManGroupByManO()
        Me.comboManGroupO.Items.Clear()
        Dim Gp() As DataRow = ManGPDt.Select("man_no ='" & Me.comboManNoO.Text & "' and txmonth='" & Me.txtMonthO.Text & "'", "man_group")
        For Each dr As DataRow In Gp
            Me.comboManGroupO.Items.Add(dr.Item("man_group"))
            Me.comboManGroupO.SelectedIndex = 0
        Next
    End Sub

End Class
