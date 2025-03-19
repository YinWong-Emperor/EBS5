Public Class FrmCommRatetblFMan

    Dim cls As New ClsCommRatetblFAcc
    Dim LoadFlag As Boolean
    Dim ManDT As DataTable
    'Dim ProductDT As DataTable
    Dim ActionFlag As String
    Dim ObjRsid As Integer
    Dim Turnover As String
    Dim Man As String
    Dim TabFlag As Boolean
    Dim FutFlag As String
    Dim C_type As String

    Private Sub FrmCommRatetblFMan_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        ActionFlag = ""
        Turnover = "Turnover"
        C_type = "MAN"
        FutFlag = "Futures"
        LabLot_range.Text = ""
        LabLot_rangeO.Text = ""
        Man = ""
        ManDT = cls.GetMan()
        Dim MaxDate As String = GfncGetMonth()
        Me.comboManNo.Items.Add("")
        Me.comboManNoO.Items.Add("")
        For Each ManDr As DataRow In ManDT.Rows
            Me.comboManNo.Items.Add(ManDr.Item("man_no").ToString.Trim)
            Me.comboManNoO.Items.Add(ManDr.Item("man_no").ToString.Trim)
        Next
        ObjRsid = 0
        LoadFlag = True
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
        If Me.txtSrchMan.Text.Length > 0 Then
            ACcondition += " and upper(b.man_no) like '%" & Me.txtSrchMan.Text.ToUpper & "%' "
        End If
        If Me.rbSrchAll.Checked Then
            ACcondition += " and (b.rate_type ='TURNF' or b.rate_type ='BROKF' or b.rate_type ='REBATEF' )"
        Else
            If Me.rbSrchBrok.Checked Then
                ACcondition += " and b.rate_type ='BROKF' "
            ElseIf Me.rbSrchTurn.Checked Then
                ACcondition += " and b.rate_type ='TURNF'"
            ElseIf Me.rbSrchRebate.Checked Then
                ACcondition += " and b.rate_type ='REBATEF'"
            End If
        End If
        'If Me.comboSrchProd.Text.Length > 0 Then
        '    ACcondition += " and b.product_group= '" & Me.comboSrchProd.Text & "' "
        'End If
        ACcondition += " and b.comm_type='" & C_type & "' and b.comm_month='" & Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00") & "' "
        Me.dtgMan.DataSource = cls.EnquiryManTbl(ACcondition).Tables(0)
        lsubGoRecord()
        If dtgMan.RowCount <= 0 Then
            dtgRateTbl.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
            Me.dtgMan.DataSource = cls.EnquiryManTbl(" and 1=0 ").Tables(0)
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
            EmptyField()
        Else
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
        End If
        Me.dtgMan.Focus()
    End Sub

    Private Sub dtgMan_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgMan.SelectionChanged
        If ActionFlag = "" And LoadFlag = False Then
            If Me.dtgMan.Rows.Count > 0 Then
                If Me.dtgMan.SelectedRows.Count > 0 Then
                    Dim condition As String = " and comm_type='" & C_type & "' and comm_month ='" & Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00") & "' "
                    'If Me.txtSrchMan.Text.Length > 0 Then
                    '    condition += " and upper(man_no) like '%" & Me.txtSrchMan.Text.Trim.ToUpper & "%' "
                    'End If
               
                    If Me.rbSrchAll.Checked Then
                        condition += " and (rate_type ='TURNF' or rate_type ='BROKF' or rate_type ='REBATEF')"
                    Else
                        If Me.rbSrchBrok.Checked Then
                            condition += " and rate_type ='BROKF' "
                        ElseIf Me.rbSrchTurn.Checked Then
                            condition += " and rate_type ='TURNF'"
                        ElseIf Me.rbSrchTurn.Checked Then
                            condition += " and rate_type ='REBATEF'"
                        End If
                    End If
                    'If Me.comboSrchProd.Text.Length > 0 Then
                    '    condition += " and product_group= '" & Me.comboSrchProd.Text.ToUpper & "' "
                    'End If
                    'If Turnover <> Nothing Then
                    '    condition += " and Turnover_type='" & Turnover & "' "
                    'End If
                    condition += " and man_no='" & Me.dtgMan.CurrentRow.Cells("ManNo").Value.ToString.Trim & "' "
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

    Private Sub dtgRateTbl_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgRateTbl.SelectionChanged
        If LoadFlag = False Then
            If dtgRateTbl.Rows.Count > 0 And dtgMan.Rows.Count > 0 Then
                'Me.comboAccNo.Text = Me.dtgRateTbl.CurrentRow.Cells("acc_no").Value.ToString.Trim
                'Me.comboProduct.Text = Me.dtgRateTbl.CurrentRow.Cells("product_group").Value.ToString.Trim
                Me.txtMonth.Text = Me.dtgRateTbl.CurrentRow.Cells("comm_month").Value.ToString.Trim
                Me.txtTOFrom.Text = Me.dtgRateTbl.CurrentRow.Cells("turnover_from").Value.ToString.Trim
                Me.txtRate.Text = Me.dtgRateTbl.CurrentRow.Cells("day_rate").Value.ToString.Trim
                'Me.txtNrate.Text = Me.dtgRateTbl.CurrentRow.Cells("night_rate").Value.ToString.Trim
                Me.comboManNo.Text = Me.dtgRateTbl.CurrentRow.Cells("man_no").Value.ToString.Trim
                Me.txtManName.Text = Me.dtgMan.CurrentRow.Cells("ManName").Value.ToString.Trim
                'Me.comboAE.Text = Me.dtgRateTbl.CurrentRow.Cells("ae_no").Value.ToString.Trim
                'Select Case Me.dtgRateTbl.CurrentRow.Cells("fut_type").Value.ToString.Trim
                '    Case "Futures"
                '        Me.RBFut.Checked = True
                '    Case "Option"
                '        Me.RBOption.Checked = True
                'End Select
                Select Case Me.dtgRateTbl.CurrentRow.Cells("trade_type").Value.ToString.Trim
                    Case "Brokerage"
                        Me.rbBrok.Checked = True
                    Case "Turnover"
                        Me.rbTurn.Checked = True
                    Case "Rebate"
                        Me.rbRebate.Checked = True
                End Select
                ' Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
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
    '            Dim Acc() As DataRow = AccDT.Select(" acc_no ='" & comboAccNo.Text & "' and txmonth='" & Me.txtMonth.Text & "'")
    '            If Acc.Length > 0 Then
    '                Me.txtAccName.Text = Acc(0).Item("acc_name").ToString.Trim
    '                'Me.txtACGp.Text = Acc(0).Item("acc_group_f").ToString.Trim
    '                Me.comboAE.Text = Acc(0).Item("ae_no").ToString.Trim
    '                Me.txtManNo.Text = Acc(0).Item("man_no").ToString.Trim
    '            Else
    '                Acc = AccDT.Select(" acc_no ='" & comboAccNo.Text & "' ")
    '                If Acc.Length > 0 Then
    '                    Me.txtAccName.Text = Acc(0).Item("acc_name").ToString.Trim
    '                Else
    '                    Me.txtAccName.Text = ""
    '                End If
    '                Me.comboAE.Text = ""
    '                Me.txtManName.Text = ""
    '                Me.txtManNo.Text = ""
    '                'Me.txtACGp.Text = ""
    '            End If
    '        Else
    '            Me.txtAccName.Text = ""
    '            Me.comboAE.Text = ""
    '            Me.txtManName.Text = ""
    '            Me.txtManNo.Text = ""
    '            'Me.txtACGp.Text = ""
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
        Me.rbBrok.Enabled = blnflag
        Me.rbTurn.Enabled = blnflag
        Me.rbRebate.Enabled = blnflag
        Me.btnSearch.Enabled = Not blnflag
        Me.dtgRateTbl.Enabled = Not blnflag
        'Me.dtgAC.Enabled = Not blnflag
        Me.dtgMan.Enabled = Not blnflag
        Me.txtTOFrom.Enabled = blnflag
        Me.txtRate.Enabled = blnflag
        'Me.txtNrate.Enabled = blnflag
        ' Me.comboManNo.Enabled = False
        Me.txtManName.Enabled = False
        Me.txtMonth.Enabled = False
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
                'Me.comboProduct.Enabled = blnflag
            Case "Edit"
                Me.comboManNo.Enabled = Not blnflag
                'Me.comboProduct.Enabled = Not blnflag
            Case Else
                Me.comboManNo.Enabled = False
                'Me.comboProduct.Enabled = False
        End Select
    End Sub

    'Private Sub comboAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboAcc.Text.Length > 0 Then
    '            Dim AE() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAE.Text & "'")
    '            Me.txtAEName.Text = AE(0).Item("ae_name").ToString.Trim
    '            'Me.txtManNo.Text = AE(0).Item("man_no").ToString.Trim
    '        Else
    '            'Me.txtManNo.Text = ""
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
            If Me.comboManNo.Text.Length > 0 Then
                Dim Manrow() As DataRow = ManDT.Select(" man_no = '" & Me.comboManNo.Text.Trim & "'")
                If Manrow.Length > 0 Then
                    Me.txtManName.Text = Manrow(0).Item("man_name").ToString.Trim
                Else
                    Me.txtManName.Text = ""
                End If
            Else
                Me.txtManName.Text = ""
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
            Me.rbTurn.Checked = True
        ElseIf Me.rbSrchBrok.Checked Then
            Me.rbBrok.Checked = True
        ElseIf Me.rbSrchRebate.Checked Then
            Me.rbRebate.Checked = True
        End If
        'Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
        'Select Case comboSrchRateType.Text
        '    Case "Day Trade"
        '        Me.rbDayRate.Checked = True
        '    Case "Overnight Trade"
        '        Me.rbNightRate.Checked = True
        '    Case "All Trade"
        '        Me.rbRateAll.Checked = True
        '    Case Else
        '        Me.rbDayRate.Checked = True
        'End Select
        If dtgMan.Rows.Count > 0 Then
            Me.comboManNo.Text = Me.dtgMan.CurrentRow.Cells("ManNo").Value.ToString.Trim
        End If
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
                If Me.ValidManager(Me.comboManNo.Text) = False Then
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
                condition = "'', '', '" & Me.comboManNo.Text.Trim & "', '', '', '', 0, '" & RateType(FutFlag) & "', " & _
                    CDbl(Me.txtTOFrom.Text) & ", " & CDbl(Me.txtRate.Text) & ", 0, 0, '" & Me.txtMonth.Text & "', '" & C_type & "'"
                'log for add only
                log = "'" & GStrloginID & "', GETDATE(), 'A', 'CommRateTblFMan', '', '', '', '" & Me.txtMonth.Text & "', '" & _
                        GFncSqlQuote(fncGenLog()) & "', "
                ObjRsid = cls.NewRecord(condition, log)
                'ac = Me.comboAccNo.Text
                'ae = Me.comboAE.Text
                Man = Me.comboManNo.Text.Trim
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
                condition = " turnover_from =" & CDbl(Me.txtTOFrom.Text.Trim) & ", man_no='" & Me.comboManNo.Text.Trim & "', " & _
                    " day_rate =" & CDbl(Me.txtRate.Text) & ", rate_type ='" & RateType(FutFlag) & "' "
                'condition += "night_rate =" & CDbl(Me.txtNrate.Text) & ", "
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value).Tables(0)
                If dt.Rows.Count <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    Return
                End If
                log = "'" & GStrloginID & "', GETDATE(), '" & "M" & "', 'CommRateTblFMan', '" & _
                    dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                    Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & _
                    "', '" & GFncSqlQuote(fncGenLog()) & "' "
                cls.EditRecord(condition, Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim, log)
                ObjRsid = Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim
                'ac = Me.comboAccNo.Text
                'ae = Me.comboAE.Text
                Man = Me.comboManNo.Text.Trim
                ActionFlag = ""
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                ObjEnable(False)
                Me.dtgRateTbl.Focus()
            Case "NewOpt"
                If Me.ValidManager(Me.comboManNoO.Text) = False Then
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
                condition = "'', '', '" & Me.comboManNoO.Text.Trim & "', '', '', '', " & CDbl(Me.txtCommRateO.Text) & ", '" & _
                    RateType(FutFlag) & "', " & CDbl(Me.txtTOFromO.Text) & ", 0, 0, 0, '" & Me.txtMonthO.Text & "', '" & C_type & "'"
                'log for add only
                log = "'" & GStrloginID & "', GETDATE(), 'A', 'CommRateTblFMan', '', '', '', '" & Me.txtMonthO.Text & "', '" & _
                        GFncSqlQuote(fncGenLog()) & "', "
                ObjRsid = cls.NewRecord(condition, log)
                'ac = Me.txtManNoO.Text
                'ae = Me.comboAEO.Text
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
                condition = " turnover_from = " & CDbl(Me.txtTOFromO.Text.Trim) & ",  man_no = '" & Me.comboManNoO.Text.Trim & _
                    "', comm_rate = " & CDbl(Me.txtCommRateO.Text) & ", rate_type = '" & RateType(FutFlag) & "' "
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value).Tables(0)
                If dt.Rows.Count <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    Return
                End If
                log = "'" & GStrloginID & "', GETDATE(), '" & "M" & "', 'CommRateTblFMan', '" & _
                    dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                    Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & _
                    "', '" & GFncSqlQuote(fncGenLog()) & "' "
                cls.EditRecord(condition, Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim, log)
                ObjRsid = Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim
                'ac = Me.comboAccNoO.Text
                'ae = Me.comboAEO.Text
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
                ErrorMsg += " Rate,"
            End If
            If Me.comboManNo.Text.Length <= 0 Then
                ErrorMsg += "Manager,"
            End If
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
            If Me.comboManNoO.Text.Length <= 0 Then
                ErrorMsg += "Manager,"
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
                Me.comboManNo.Text = ""
                Me.txtManName.Text = ""
            End If
            'Me.comboProduct.Text = ""
            Me.txtTOFrom.Text = 0
            Me.txtRate.Text = "0.0000"
            'Me.txtNrate.Text = "0.0000"
            'Me.comboManNo.Text = ""
            'Me.txtManName.Text = ""
            Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
            'Me.comboAE.Text = ""
            Me.rbTurn.Checked = True
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
            'Dim log As String = "'" & GStrloginID & "', GETDATE(), '" & "D" & "', 'CommRateTblFMan', '" & _
            '                                                   dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', ' ', " & _
            '                                                   "'" & Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & "'," & _
            '                                                   "'" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog()) & "' "
            '2010-01-13
            Dim log As String = "'" & GStrloginID & "', GETDATE(), '" & "D" & "', 'CommRateTblFMan', '" & _
                dt.Rows(0).Item("man_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & _
                GFncSqlQuote(fncGenLog()) & " " & _
                GFncSqlQuote(cls.GfncOneFieldLog("Manager No.", dt.Rows(0).Item("man_no").ToString.Trim)) & "' "
            cls.DelRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim, log)
            'ac = Me.dtgAC.CurrentRow.Cells("ACno").Value.ToString.Trim
            ObjEnable(False)
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
        Me.dtgRateTbl.Focus()
    End Sub

    Private Function RateType(ByVal fut As String) As String
        Dim type As String = ""
        If (fut = "Futures" And Me.rbTurn.Checked) Or (fut = "Options" And Me.rbTurnO.Checked) Then
            type += "TURN"
        ElseIf (fut = "Futures" And Me.rbBrok.Checked) Or (fut = "Options" And Me.rbBrokO.Checked) Then
            type += "BROK"
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
                'For lintCnt As Integer = 0 To Me.dtgAC.RowCount - 1
                '    If Me.dtgAC.Rows(lintCnt).Cells("ACNo").Value.ToString.Trim = ac Then
                '        Me.dtgAC.Rows(lintCnt).Cells("ACNo").Selected = True
                '    End If
                'Next
                'Me.dtgAC_SelectionChanged(Nothing, System.EventArgs.Empty)
                'If ae <> "" Then
                '    For lintCnt As Integer = 0 To Me.dtgAE.RowCount - 1
                '        If Me.dtgAE.Rows(lintCnt).Cells("AENo").Value.ToString.Trim = ae Then
                '            Me.dtgAE.Rows(lintCnt).Cells("AENo").Selected = True
                '        End If
                '    Next
                '    Me.dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
                'End If
                For lintCnt As Integer = 0 To Me.dtgMan.RowCount - 1
                    If Me.dtgMan.Rows(lintCnt).Cells("ManNo").Value.ToString.Trim = Man Then
                        Me.dtgMan.Rows(lintCnt).Cells("ManNo").Selected = True
                    End If
                Next
                Me.dtgMan_SelectionChanged(Nothing, System.EventArgs.Empty)
                If ObjRsid > 0 Then
                    For lintCnt As Integer = 0 To Me.dtgRateTbl.Rows.Count - 1
                        If Me.dtgRateTbl.Rows(lintCnt).Cells("rsid").Value.ToString.Trim = ObjRsid Then
                            Me.dtgRateTbl.Rows(lintCnt).Cells("day_rate").Selected = True
                            Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)

                            Me.dtgRateTbl.Focus()
                            Exit For
                        End If
                    Next
                End If
            ElseIf TabControl.SelectedTab.Name = Me.TabPageOptions.Name Then
                For lintCnt As Integer = 0 To Me.dtgManO.RowCount - 1
                    If Me.dtgManO.Rows(lintCnt).Cells("ManNoO").Value.ToString.Trim = Man Then
                        Me.dtgManO.Rows(lintCnt).Cells("ManNoO").Selected = True
                    End If
                Next
                Me.dtgManO_SelectionChanged(Nothing, System.EventArgs.Empty)
                'End If
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
            Turnover = "Turnover"
            Me.comboSrcMonth.Text = Me.comboSrchMonthO.Text
            Me.comboSrcYr.Text = Me.comboSrchYrO.Text
            'Me.comboSrchProd.Text = Me.comboSrchProdO.Text
            Me.txtSrchMan.Text = Me.txtSrchManO.Text
            If Me.rbSrchAllO.Checked Then
                Me.rbSrchAll.Checked = True
            ElseIf Me.rbSrchBrokO.Checked Then
                Me.rbSrchBrok.Checked = True
            ElseIf Me.rbSrchRebateO.Checked Then
                Me.rbSrchRebate.Checked = True
            Else
                Me.rbTurn.Checked = True
            End If
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
            Return
        End If
        If Me.TabControl.SelectedTab.Name = Me.TabPageOptions.Name Then
            FutFlag = "Options"
            Turnover = "Turnover"
            Me.comboSrchMonthO.Text = Me.comboSrcMonth.Text
            Me.comboSrchYrO.Text = Me.comboSrcYr.Text
            'Me.comboSrchProdO.Text = Me.comboSrchProd.Text
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
            Return
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
                        lstrLog += cls.GfncOneFieldLog("Manager No.", dt.Rows(0).Item("man_no").ToString.Trim, Me.comboManNo.Text.Trim)
                    End If
                    If Me.txtTOFrom.Text.Trim.Length > 0 And CDbl(Me.txtTOFrom.Text.Trim) <> CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim) Then
                        lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim), CDbl(Me.txtTOFrom.Text.Trim))
                    End If
                    'If Me.RateType(FutFlag).Trim <> dt.Rows(0).Item("rate_type").ToString.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("Rate_type", dt.Rows(0).Item("rate_type").ToString.Trim, RateType(FutFlag).Trim)
                    'End If
                    If Me.txtRate.Text.Trim.Length > 0 And dt.Rows(0).Item("day_rate").ToString.Trim <> Me.txtRate.Text.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Day Rate", dt.Rows(0).Item("day_rate").ToString.Trim, Me.txtRate.Text.Trim)
                    End If
                    'If Me.txtRate.Text.Trim.Length > 0 And dt.Rows(0).Item("night_rate").ToString.Trim <> Me.txtNrate.Text.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("Night_rate", dt.Rows(0).Item("night_rate").ToString.Trim, Me.txtNrate.Text.Trim)
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
                    lstrLog += cls.GfncOneFieldLog("Day Rate", Me.txtRate.Text.Trim)
                End If
                'If Me.txtNrate.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("Night_rate", Me.txtNrate.Text.Trim)
                'End If
                'If Me.txtMonth.Text.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("comm_month", txtMonth.Text.Trim)
                'End If
                If Me.txtTOFrom.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(Me.txtTOFrom.Text.Trim))
                End If
                If Me.comboManNo.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Manager No.", Me.comboManNo.Text.Trim)
                End If
                lstrLog += cls.GfncOneFieldLog("Rate Type", RateType(FutFlag))
                lstrLog += cls.GfncOneFieldLog("Commission Type", C_type)
            Case "EditOpt"
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim).Tables(0)
                If dt.Rows.Count > 0 Then
                    'If Me.comboAEO.Text.Trim.Length > 0 And Me.comboAEO.Text.Trim <> dt.Rows(0).Item("ae_no").ToString.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("ae_no", dt.Rows(0).Item("ae_no").ToString.Trim, Me.comboAEO.Text.Trim)
                    'End If
                    If Me.comboManNoO.Text.Trim.Length > 0 And Me.comboManNo.Text.Trim <> dt.Rows(0).Item("man_no").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Manager No.", dt.Rows(0).Item("man_no").ToString.Trim, Me.comboManNo.Text.Trim)
                    End If
                    If Me.txtTOFromO.Text.Trim.Length > 0 And CDbl(Me.txtTOFromO.Text.Trim) <> CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim) Then
                        lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim), CDbl(Me.txtTOFromO.Text.Trim))
                    End If
                    'If Me.RateType(FutFlag).Trim <> dt.Rows(0).Item("rate_type").ToString.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("Rate_type", dt.Rows(0).Item("rate_type").ToString.Trim, RateType(FutFlag).Trim)
                    'End If
                    If Me.txtCommRateO.Text.Length > 0 And Me.txtCommRateO.Text <> dt.Rows(0).Item("comm_rate").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Commission Rate", dt.Rows(0).Item("comm_rate").ToString.Trim, Me.txtCommRateO.Text.Trim)
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
                    lstrLog += cls.GfncOneFieldLog("Commission Rate", Me.txtCommRateO.Text.Trim)
                End If
                'If Me.txtMonthO.Text.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("Commission Month", txtMonthO.Text.Trim)
                'End If
                If Me.txtTOFromO.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(Me.txtTOFromO.Text.Trim))
                End If
                If Me.comboManNoO.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Manager No.", Me.comboManNo.Text.Trim)
                End If
                'lstrLog += cls.GfncOneFieldLog("Rate_type", RateType(FutFlag))
                lstrLog += cls.GfncOneFieldLog("Commission Type", C_type)
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
        If LoadFlag = False Then
            If rbSrchAll.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub rbSrchRebate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchRebate.CheckedChanged
        If LoadFlag = False Then
            If rbSrchRebate.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub rbSrchBrok_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchBrok.CheckedChanged
        If LoadFlag = False Then
            If Me.rbSrchBrok.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub rbSrchTurn_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchTurn.CheckedChanged
        If LoadFlag = False Then
            If rbSrchTurn.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
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

    Private Sub rbNormal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        lFnRefreshTurnover()
    End Sub

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
    ''*****************************************************************************Turnover OPTIONS**************************************************************************************
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
                ACcondition += " and ( b.rate_type ='TURNO' or b.rate_type ='BROKO' or b.rate_type ='REBATEO' )"
            Else
                If Me.rbSrchBrokO.Checked Then
                    ACcondition += " and b.rate_type ='BROKO' "
                ElseIf Me.rbSrchTurnO.Checked Then
                    ACcondition += " and b.rate_type ='TURNO'"
                ElseIf Me.rbSrchRebateO.Checked Then
                    ACcondition += " and b.rate_type ='REBATEO'"
                End If
            End If
            ACcondition += " and b.comm_type= '" & C_type & "' and b.comm_month = '" & Me.comboSrchYrO.Text & _
                Format(Val(Me.comboSrchMonthO.Text), "00") & "' "
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
                    Dim condition As String = " and comm_type = '" & C_type & "' and comm_month = '" & Me.comboSrchYrO.Text & _
                        Format(Val(Me.comboSrchMonthO.Text), "00") & "' "
                    'If Me.txtSrchManO.Text.Length > 0 Then
                    '    condition += " and upper(man_no) like '%" & Me.txtSrchMan.Text.Trim.ToUpper & "%' "
                    'End If
                    If Me.rbSrchAllO.Checked Then
                        condition += " and (rate_type ='BROKO' or rate_type ='TURNO' or rate_type ='REBATEO')"
                    Else
                        If Me.rbSrchBrokO.Checked Then
                            condition += " and rate_type ='BROKO' "
                        ElseIf Me.rbTurnO.Checked Then
                            condition += " and rate_type ='TURNO'"
                        ElseIf Me.rbRebateO.Checked Then
                            condition += " and rate_type ='REBATEO'"
                        End If
                    End If
                    'If Me.comboSrchProdO.Text.Length > 0 Then
                    '    condition += " and product_group= '" & Me.comboSrchProdO.Text.ToUpper & "' "
                    'End If
                    'If Turnover.Length > 0 Then
                    '    condition += " and Turnover_type='" & Turnover & "' "
                    'End If
                    condition += " and man_no ='" & Me.dtgManO.CurrentRow.Cells("ManNoO").Value.ToString.Trim & "' "
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
            If dtgRateTableO.Rows.Count > 0 Then
                'Me.comboAccNoO.Text = Me.dtgRateTableO.CurrentRow.Cells("acc_noO").Value.ToString.Trim
                'Me.comboProductO.Text = Me.dtgRateTableO.CurrentRow.Cells("product_groupO").Value.ToString.Trim
                Me.txtMonthO.Text = Me.dtgRateTableO.CurrentRow.Cells("comm_monthO").Value.ToString.Trim
                Me.txtTOFromO.Text = Me.dtgRateTableO.CurrentRow.Cells("turnover_fromO").Value.ToString.Trim
                Me.txtCommRateO.Text = Me.dtgRateTableO.CurrentRow.Cells("comm_rateO").Value.ToString.Trim
                Me.comboManNoO.Text = Me.dtgRateTableO.CurrentRow.Cells("man_noO").Value.ToString.Trim
                If dtgManO.Rows.Count > 0 Then
                    Me.txtManNameO.Text = Me.dtgManO.CurrentRow.Cells("ManNameO").Value.ToString.Trim
                End If
                'Me.comboAEO.Text = Me.dtgRateTableO.CurrentRow.Cells("ae_noO").Value.ToString.Trim
                Select Case Me.dtgRateTableO.CurrentRow.Cells("trade_typeO").Value.ToString.Trim
                    Case "Brokerage"
                        Me.rbBrokO.Checked = True
                    Case "Turnover"
                        Me.rbTurnO.Checked = True
                    Case "Rebate"
                        Me.rbRebateO.Checked = True
                End Select
                'Me.cbConsolidateO_CheckedChanged(Nothing, System.EventArgs.Empty)
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
        If Me.dtgManO.Rows.Count > 0 Then
            Me.comboManNoO.Text = Me.dtgManO.CurrentRow.Cells("ManNoO").Value.ToString.Trim
        Else
            Me.comboManNoO.Text = ""
        End If
        'If Me.comboSrchProdO.Text.Length > 0 Then
        '    Me.comboProductO.Text = Me.comboSrchProdO.Text
        'End If
        Me.comboManNoO_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        Me.comboManNoO.Focus()
    End Sub

    Private Sub btnEditO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditO.Click
        If Me.dtgRateTableO.SelectedRows.Count > 0 Then
            ActionFlag = "EditOpt"
            OptObjEnable(True)
            Me.txtTOFromO.Focus()
        End If
    End Sub

    'Private Sub comboAccNoO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboAccNoO.Text.Length > 0 Then
    '            Me.comboAccNoO.Text = Me.comboAccNoO.Text.ToUpper
    '            Dim Acc() As DataRow = AccDT.Select(" acc_no ='" & comboAccNoO.Text & "' and txmonth ='" & Me.txtMonthO.Text & "'")
    '            If Acc.Length > 0 Then
    '                Me.txtAccNameO.Text = Acc(0).Item("acc_name").ToString.Trim
    '                'Me.txtACGpO.Text = Acc(0).Item("acc_group_f").ToString.Trim
    '                Me.comboAEO.Text = Acc(0).Item("ae_no").ToString.Trim
    '                Me.txtManNoO.Text = Acc(0).Item("man_no").ToString.Trim
    '            Else
    '                Acc = AccDT.Select(" acc_no ='" & comboAccNoO.Text & "'")
    '                If Acc.Length > 0 Then
    '                    Me.txtAccNameO.Text = Acc(0).Item("acc_name").ToString.Trim
    '                Else
    '                    Me.txtAccNameO.Text = ""
    '                End If
    '                Me.txtManNameO.Text = ""
    '                Me.comboAEO.Text = ""
    '                Me.txtManNoO.Text = ""
    '            End If
    '        Else
    '            Me.txtManNameO.Text = ""
    '            Me.txtAccNameO.Text = ""
    '            Me.txtManNoO.Text = ""
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
    '            'Me.txtManNoO.Text = AE(0).Item("man_no").ToString.Trim
    '        Else
    '            'Me.txtManNoO.Text = ""
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
        Me.dtgManO.Enabled = Not blnflag
        Me.txtTOFromO.Enabled = blnflag
        Me.txtCommRateO.Enabled = blnflag
        'Me.cbConsolidateO.Enabled = blnflag
        'Me.rbSrchConsolidateO.Enabled = Not blnflag
        Me.txtMonthO.Enabled = False
        'Me.txtManNoO.Enabled = False
        Me.txtManNameO.Enabled = False
        Me.rbSrchBrokO.Enabled = Not blnflag
        Me.rbSrchTurnO.Enabled = Not blnflag
        Me.rbSrchRebateO.Enabled = Not blnflag
        Me.rbSrchAllO.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        Me.btnDelO.Enabled = Not blnflag
        Me.btnNewO.Enabled = Not blnflag
        Me.btnEditO.Enabled = Not blnflag
        Select Case ActionFlag
            Case "NewOpt"
                Me.comboManNoO.Enabled = blnflag
                'Me.comboProductO.Enabled = blnflag
            Case "EditOpt"
                Me.comboManNoO.Enabled = Not blnflag
                'Me.comboProductO.Enabled = Not blnflag
            Case Else
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
            Dim log As String = "'" & GStrloginID & "', GETDATE(), 'D', 'CommRateTblFMan', '" & _
                dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & _
                "', '" & GFncSqlQuote(fncGenLog()) & " " & _
                GFncSqlQuote(cls.GfncOneFieldLog("Manager No.", dt.Rows(0).Item("man_no").ToString.Trim)) & "' "
            cls.DelRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim, log)
            'ac = Me.dtgACtblO.CurrentRow.Cells("ACnoO").Value.ToString.Trim
            Me.OptObjEnable(False)
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
            Me.dtgRateTableO.Focus()
        End If
    End Sub

    Private Function OptValidateDuplicate() As Boolean
        Dim condition As String = " and man_no = '" & Me.comboManNoO.Text.Trim & "' and turnover_from = " & _
            CDbl(Me.txtTOFromO.Text.Trim) & " and comm_month = '" & Me.txtMonthO.Text.Trim & "' and comm_type = '" & C_type & _
            "' and rate_type = '" & RateType(FutFlag) & "' "
        If ActionFlag = "EditOpt" Then
            condition += " and rsid <> '" & Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim & "' "
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
        If Me.rbSrchBrokO.Checked = True Then
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchRebateO_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchRebateO.CheckedChanged
        If Me.rbSrchRebateO.Checked = True Then
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchAllO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchAllO.CheckedChanged
        If rbSrchAllO.Checked = True Then
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchTurnO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchTurnO.CheckedChanged
        If rbSrchTurnO.Checked = True Then
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
            'Me.FncLoadProductByMonthO(Me.comboSrchYrO.Text.Trim & Format(Val(Me.comboSrchMonthO.Text.Trim), "00"))
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub comboSrchProdO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If LoadFlag = False Then
            'Me.FncLoadProductByMonthO(Me.comboSrchYrO.Text.Trim & Format(Val(Me.comboSrchMonthO.Text.Trim), "00"))
            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub EmptyOptField()
        If LoadFlag = False Then
            If ActionFlag <> "NewOpt" Then
                Me.comboManNoO.Text = ""
                Me.txtManNameO.Text = ""
            End If
            'Me.comboProductO.Text = ""
            Me.txtTOFromO.Text = 0
            Me.txtCommRateO.Text = "0.0000"
            'Me.txtACGp.Text = ""
            Me.txtMonthO.Text = Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00")
            'Me.comboAEO.Text = ""
            'Me.rbNormalO.Checked = True
        End If
    End Sub

    Private Sub comboManNoO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboManNoO.SelectedIndexChanged, comboManNoO.LostFocus
        If LoadFlag = False Then
            If Me.comboManNoO.Text.Length > 0 Then
                Dim ManO() As DataRow = ManDT.Select(" man_no = '" & Me.comboManNoO.Text.Trim & "'")
                If ManO.Length > 0 Then
                    Me.txtManNameO.Text = ManO(0).Item("man_name").ToString.Trim
                Else
                    Me.txtManNameO.Text = ""
                End If
            Else
                Me.txtManNameO.Text = ""
            End If
        End If
    End Sub

    Private Function ValidManager(ByVal Manno As String) As Boolean
        If Manno.Length > 0 Then
            Return cls.ValidateManager(Manno)
        Else
            Return False
        End If
    End Function

    'Private Sub rbSrchConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.rbSrchConsolidate.Checked Then
    '            btnSearch_Click(Nothing, System.EventArgs.Empty)
    '        End If
    '    End If
    'End Sub
    'Private Sub rbSrchConsolidateO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchConsolidateO.CheckedChanged
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

    'Private Sub cbConsolidateO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConsolidateO.CheckedChanged
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
    ''---------------------------------------------------------------------Brokerage Futures----------------------------------------------------------------------
    'Private Sub btnSearchFutBg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        Dim ACcondition As String = ""
    '        If Me.comboSrchProdFutBg.Text.Length > 0 Then
    '            ACcondition += " and b.product_group= '" & Me.comboSrchProdFutBg.Text & "' "
    '        End If
    '        If Me.txtSrchManFutBg.Text.Length > 0 Then
    '            ACcondition += " and upper(b.man_no) like '%" & Me.txtSrchManFutBg.Text.ToUpper & "%' "
    '        End If
    '        If Me.rbSrchAllFutBg.Checked Then
    '            ACcondition += " and (b.rate_type ='INTO' or b.rate_type ='NORO' )"
    '        Else
    '            If Me.rbSrchNormalFutBg.Checked Then
    '                ACcondition += " and b.rate_type ='NORO' "
    '            Else
    '                ACcondition += " and b.rate_type ='INTO'"
    '            End If
    '        End If
    '        If Turnover <> Nothing Then
    '            ACcondition += " and Turnover_type='" & Turnover & "' "
    '        End If
    '        ACcondition += " and b.comm_type='" & C_type & "' and b.comm_month='" & Me.comboSrchYrFutBg.Text & Format(Val(Me.comboSrchMonthFutBg.Text), "00") & "' "
    '        Me.dtgManFutBg.DataSource = cls.EnquiryManTbl(ACcondition).Tables(0)
    '        lsubGoRecord()
    '        If dtgManFutBg.RowCount <= 0 Then
    '            'dtgAetblO.DataSource = cls.EnquiryAETbl(" and 1=0 ").Tables(0)
    '            Me.dtgRateTableFutBg.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
    '            'Me.dtgManO.DataSource = cls.EnquiryManTbl(" and 1=0 ").Tables(0)
    '            Me.btnEditFutBg.Enabled = False
    '            Me.btnDelFutBg.Enabled = False
    '            EmptyFieldFutBg()
    '        Else
    '            Me.btnEditFutBg.Enabled = True
    '            Me.btnDelFutBg.Enabled = True
    '        End If
    '        Me.dtgManFutBg.Focus()
    '    End If
    'End Sub

    'Private Sub dtgManFutBg_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ActionFlag = "" And LoadFlag = False Then
    '        If Me.dtgManFutBg.Rows.Count > 0 Then
    '            If Me.dtgManFutBg.SelectedRows.Count > 0 Then
    '                Dim condition As String = " and comm_type='" & C_type & "' and comm_month ='" & Me.comboSrchYrFutBg.Text & Format(Val(Me.comboSrchMonthFutBg.Text), "00") & "' "
    '                'If Me.txtSrchManO.Text.Length > 0 Then
    '                '    condition += " and upper(man_no) like '%" & Me.txtSrchMan.Text.Trim.ToUpper & "%' "
    '                'End If
    '                If Me.rbSrchAllFutBg.Checked Then
    '                    condition += " and (left(rate_type,4) ='INTO' or left(rate_type,4) ='NORO' )"
    '                Else
    '                    If Me.rbSrchNormalFutBg.Checked Then
    '                        condition += " and left(rate_type,4) ='NORO' "
    '                    Else
    '                        condition += " and left(rate_type,4) ='INTO'"
    '                    End If
    '                End If
    '                If Me.comboSrchProdFutBg.Text.Length > 0 Then
    '                    condition += " and product_group= '" & Me.comboSrchProdO.Text.ToUpper & "' "
    '                End If
    '                If Turnover <> Nothing Then
    '                    condition += " and Turnover_type='" & Turnover & "' "
    '                End If
    '                condition += " and man_no ='" & Me.dtgManFutBg.CurrentRow.Cells("ManNoO").Value.ToString.Trim & "' "
    '                Me.dtgRateTableFutBg.DataSource = cls.EnquiryRateTbl(condition, " product_group asc, comm_month asc,acc_group asc, rate_type desc, turnover_from asc, ")
    '            End If
    '        Else
    '            Me.dtgRateTableFutBg.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
    '            Me.btnEditFutBg.Enabled = False
    '            Me.btnDelFutBg.Enabled = False
    '            EmptyOptField()
    '        End If
    '    End If
    'End Sub

    'Private Sub dtgRateTableFutBg_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If dtgRateTableFutBg.Rows.Count > 0 Then
    '            'Me.comboAccNoO.Text = Me.dtgRateTableO.CurrentRow.Cells("acc_noO").Value.ToString.Trim
    '            Me.comboProductFutBg.Text = Me.dtgRateTableFutBg.CurrentRow.Cells("product_groupO").Value.ToString.Trim
    '            Me.txtMonthFutBg.Text = Me.dtgRateTableFutBg.CurrentRow.Cells("comm_monthO").Value.ToString.Trim
    '            Me.txtTOFromFutBg.Text = Me.dtgRateTableFutBg.CurrentRow.Cells("turnover_fromO").Value.ToString.Trim
    '            Me.txtCommRateFutBg.Text = Me.dtgRateTableFutBg.CurrentRow.Cells("rateO").Value.ToString.Trim
    '            Me.comboManNoFutBg.Text = Me.dtgRateTableFutBg.CurrentRow.Cells("man_noO").Value.ToString.Trim
    '            If dtgManFutBg.Rows.Count > 0 Then
    '                Me.txtManNameFutBg.Text = Me.dtgManFutBg.CurrentRow.Cells("ManNameO").Value.ToString.Trim
    '            End If
    '            'Me.comboAEO.Text = Me.dtgRateTableO.CurrentRow.Cells("ae_noO").Value.ToString.Trim
    '            Select Case Me.dtgRateTableFutBg.CurrentRow.Cells("trade_typeO").Value.ToString.Trim
    '                Case "Normal"
    '                    Me.rbNormalFutBg.Checked = True
    '                Case "Internet"
    '                    Me.rbInternetFutBg.Checked = True
    '            End Select
    '            lFnRefreshTurnoverFutBg()
    '        End If
    '    Else
    '        EmptyFieldFutBg()
    '    End If
    'End Sub

    'Private Sub btnNewFutBg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ActionFlag = "NewFutBg"
    '    OptObjEnable(True)
    '    EmptyFieldFutBg()
    '    Me.txtMonthFutBg.Text = Me.comboSrchYrFutBg.Text & Format(Val(Me.comboSrchMonthFutBg.Text), "00")
    '    If Me.rbSrchNormalFutBg.Checked Or Me.rbSrchAllFutBg.Checked Then
    '        Me.rbNormalFutBg.Checked = True
    '    Else
    '        Me.rbInternetFutBg.Checked = True
    '    End If
    '    If Me.dtgManFutBg.Rows.Count > 0 Then
    '        Me.comboManNoFutBg.Text = Me.dtgManFutBg.CurrentRow.Cells("ManNoO").Value.ToString.Trim
    '    Else
    '        Me.comboManNoFutBg.Text = ""
    '    End If
    '    If Me.comboSrchProdFutBg.Text.Length > 0 Then
    '        Me.comboProductFutBg.Text = Me.comboSrchProdFutBg.Text
    '    End If
    '    Me.comboManNoFutBg_SelectedIndexChanged(Nothing, System.EventArgs.Empty)

    '    Me.comboManNoFutBg.Focus()
    'End Sub

    'Private Sub btnEditFutBg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditO.Click
    '    If Me.dtgRateTableFutBg.SelectedRows.Count > 0 Then
    '        ActionFlag = "EditOpt"
    '        ObjEnableFutBg(True)
    '        Me.txtTOFromFutBg.Focus()
    '    End If
    'End Sub

    'Private Sub comboProductFutBg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboProductFutBg.Text.Length > 0 Then
    '            Me.comboProductFutBg.Text = Me.comboProductFutBg.Text.ToUpper
    '            Dim Prod() As DataRow = ProductDT.Select(" product_group ='" & Me.comboProductFutBg.Text & "'")
    '            If Prod.Length > 0 Then
    '                Me.txtProductNameFutBg.Text = Prod(0).Item("product_name").ToString.Trim
    '            Else
    '                Me.txtProductNameFutBg.Text = ""
    '            End If

    '        Else
    '            Me.txtProductNameFutBg.Text = ""
    '        End If
    '    End If
    'End Sub

    ''Private Sub comboAEO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    ''    If LoadFlag = False Then
    ''        If Me.comboAEO.Text.Length > 0 Then
    ''            Dim AE() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAEO.Text & "'")
    ''            Me.txtAENameO.Text = AE(0).Item("ae_name").ToString.Trim
    ''            'Me.txtManNoO.Text = AE(0).Item("man_no").ToString.Trim
    ''        Else
    ''            'Me.txtManNoO.Text = ""
    ''            Me.txtAENameO.Text = ""
    ''        End If
    ''    End If
    ''End Sub

    'Private Sub ObjEnableFutBg(ByVal blnflag As Boolean)
    '    'Me.txtSrchAccO.Enabled = Not blnflag
    '    Me.txtSrchManFutBg.Enabled = Not blnflag
    '    Me.comboSrchMonthFutBg.Enabled = Not blnflag
    '    Me.comboSrchYrFutBg.Enabled = Not blnflag
    '    'Me.comboAEO.Enabled = False
    '    Me.comboSrchProdFutBg.Enabled = Not blnflag
    '    Me.rbNormalFutBg.Enabled = blnflag
    '    Me.rbInternetFutBg.Enabled = blnflag
    '    Me.btnEnquiryFutBg.Enabled = Not blnflag
    '    Me.dtgRateTableFutBg.Enabled = Not blnflag
    '    'Me.dtgACtblO.Enabled = Not blnflag
    '    'Me.dtgAetblO.Enabled = Not blnflag
    '    Me.txtTOFromFutBg.Enabled = blnflag
    '    Me.txtCommRateFutBg.Enabled = blnflag

    '    Me.txtMonthFutBg.Enabled = False
    '    'Me.txtManNoO.Enabled = False
    '    Me.txtManNameFutBg.Enabled = False

    '    Me.rbSrchNormalFutBg.Enabled = Not blnflag
    '    Me.rbSrchInternetFutBg.Enabled = Not blnflag
    '    Me.rbSrchAllFutBg.Enabled = Not blnflag
    '    Me.btnSave.Enabled = blnflag
    '    Me.btnDelFutBg.Enabled = Not blnflag
    '    Me.btnNewFutBg.Enabled = Not blnflag
    '    Me.btnEditFutBg.Enabled = Not blnflag

    '    Select Case ActionFlag
    '        Case "NewFutBg"
    '            Me.comboManNoFutBg.Enabled = blnflag
    '            Me.comboProductFutBg.Enabled = blnflag
    '        Case "EditFutBg"
    '            Me.comboManNoFutBg.Enabled = Not blnflag
    '            Me.comboProductFutBg.Enabled = Not blnflag
    '        Case Else
    '            Me.comboManNoFutBg.Enabled = False
    '            Me.comboProductFutBg.Enabled = False
    '    End Select
    'End Sub


    'Private Sub btnDelFutBg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.dtgRateTableFutBg.SelectedRows.Count > 0 Then
    '        If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
    '            Return
    '        End If
    '        Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTableFutBg.CurrentRow.Cells("rsidO").Value).Tables(0)
    '        If dt.Rows.Count <= 0 Then
    '            GSubShowInfo(GFncGetSysMsg(9))
    '            Return
    '        End If
    '        Dim log As String = "'" & GStrloginID & "', GETDATE(), '" & "D" & "', 'CommRateTblFMan', '" & _
    '                                                           dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', ' ', " & _
    '                                                           "'" & Me.dtgRateTableFutBg.CurrentRow.Cells("rsidO").Value & "'," & _
    '                                                           "'" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog()) & "' "
    '        cls.DelRecord(Me.dtgRateTableFutBg.CurrentRow.Cells("rsidO").Value.ToString.Trim, log)
    '        'ac = Me.dtgACtblO.CurrentRow.Cells("ACnoO").Value.ToString.Trim
    '        ObjEnableFutBg(False)
    '        Me.btnSearchFutBg_Click(Nothing, System.EventArgs.Empty)
    '        Me.dtgRateTableFutBg.Focus()
    '    End If
    'End Sub

    'Private Function ValidateDuplicateFutBg() As Boolean
    '    Dim condition As String = " and man_no='" & Me.comboManNoFutBg.Text.Trim & "' " & _
    '                                                    " and product_group = '" & Me.comboProductFutBg.Text.Trim & "' and turnover_from =" & CDbl(Me.txtTOFromFutBg.Text.Trim) & _
    '                                                    " and comm_month ='" & Me.txtMonthFutBg.Text.Trim & "' and comm_type='" & C_type & "' and rate_type='" & RateType(FutFlag) & "' "
    '    If Turnover <> Nothing Then
    '        condition += " and turnover_type ='" & Turnover & "'"
    '    End If
    '    If ActionFlag = "EditFutBg" Then
    '        condition += " and rsid<>'" & Me.dtgRateTableFutBg.CurrentRow.Cells("rsidO").Value.ToString.Trim & "' "
    '    End If
    '    Return cls.ValidateDuplicate(condition)

    'End Function

    'Private Sub comboSrchMonthFutBg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.btnSearchFutBg_Click(Nothing, System.EventArgs.Empty)
    'End Sub

    'Private Sub comboSrchYrFutBg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.btnSearchFutBg_Click(Nothing, System.EventArgs.Empty)
    'End Sub

    'Private Sub rbSrchInternetFutBg_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If rbSrchInternetFutBg.Checked = True Then
    '        Me.btnSearchFutBg_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub rbSrchAllFutBg_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If rbSrchAllFutBg.Checked = True Then
    '        Me.btnSearchFutBg_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub rbSrchNormalFutBg_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If rbSrchNormalFutBg.Checked = True Then
    '        Me.btnSearchFutBg_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub lFnRefreshTurnoverFutBg()

    '    Dim comm_month As String = Me.txtMonthFutBg.Text
    '    Dim Rtype As String = RateType(FutFlag)
    '    Dim ae_num As String = ""
    '    Dim acc As String = ""

    '    Dim product As String = Me.comboProductFutBg.Text
    '    Dim turnover As String = CDbl(Me.txtTOFromFutBg.Text)
    '    Dim manno As String = Me.comboManNoFutBg.Text
    '    Dim lds As DataSet
    '    Dim turnoverTo As String = ""

    '    lds = cls.lFncGetNextComm(comm_month, Rtype, acc, ae_num, Nothing, manno, Nothing, product, C_type, turnover)
    '    If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
    '        Me.LabLot_rangeFutBg.Text = ""
    '    Else
    '        Me.LabLot_rangeFutBg.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,###.00")
    '    End If
    'End Sub

    'Private Sub LabLot_rangeFutBg_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    lFnRefreshTurnoverFutBg()
    'End Sub

    'Private Sub comboSrchProdFutBg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        Me.btnSearchFutBg_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub EmptyFieldFutBg()
    '    If LoadFlag = False Then
    '        If ActionFlag <> "NewOpt" Then
    '            Me.comboManNoFutBg.Text = ""
    '            Me.txtManNameFutBg.Text = ""
    '        End If
    '        Me.comboProductFutBg.Text = ""
    '        Me.txtTOFromFutBg.Text = 0
    '        Me.txtCommRateFutBg.Text = "0.0000"
    '        'Me.txtACGp.Text = ""
    '        Me.txtMonthFutBg.Text = Me.comboSrchYrFutBg.Text & Format(Val(Me.comboSrchMonthFutBg.Text), "00")
    '        'Me.comboAEO.Text = ""
    '        Me.rbNormalFutBg.Checked = True
    '    End If
    'End Sub


    'Private Sub comboManNoFutBg_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboManNoFutBg.Text.Length > 0 Then
    '            Dim ManFutBg() As DataRow = ManDT.Select(" man_no = '" & Me.comboManNoFutBg.Text.Trim & "'")
    '            If ManFutBg.Length > 0 Then
    '                Me.txtManNameFutBg.Text = ManFutBg(0).Item("man_name").ToString.Trim
    '            Else
    '                Me.txtManNameFutBg.Text = ""
    '            End If
    '        Else
    '            Me.txtManNameFutBg.Text = ""
    '        End If
    '    End If
    'End Sub

End Class

