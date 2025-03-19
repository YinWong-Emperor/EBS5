Imports System.Data.SqlClient

Public Class FrmCommRatetblFutAcc

    Dim cls As New ClsCommRatetblFAcc
    Dim LoadFlag As Boolean
    Dim AccDT As DataTable
    Dim AeDT As DataTable
    Dim ProductDT As DataTable
    Dim ActionFlag As String
    Dim ObjRsid As Integer
    Dim ac As String
    Dim ae As String
    Dim prod As String
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
        C_type = "ACC"
        FutFlag = "Futures"
        LabLot_range.Text = ""
        'LabLot_rangeO.Text = ""
        ac = ""
        ae = ""
        ObjRsid = 0
        LoadFlag = True
        txtAccName.ReadOnly = False
        Dim MaxDate As String = GfncGetMonth()
        AccDT = cls.GetAccList()
        Me.comboAccNo.Items.Add("")
        'Me.comboAccNoO.Items.Add("")
        For Each AccDr As DataRow In AccDT.Rows
            Me.comboAccNo.Items.Add(AccDr.Item("acc_no").ToString.Trim)
            'Me.comboAccNoO.Items.Add(AccDr.Item("acc_no").ToString.Trim)
        Next
        AccDT = cls.GetAcc()
        AeDT = cls.GetAe()
        Me.comboAE.Items.Add("")
        For Each AeDr As DataRow In AeDT.Rows
            Me.comboAE.Items.Add(AeDr.Item("ae_no").ToString.Trim)
            'Me.comboAEO.Items.Add(AeDr.Item("ae_no").ToString.Trim)
        Next
        For year As Integer = Val(MaxDate.Substring(0, 4)) - 5 To Val(MaxDate.Substring(0, 4)) + 5
            Me.comboSrcYr.Items.Add(year)
            'Me.comboSrchYrO.Items.Add(year)
        Next
        For month As Integer = 1 To 12
            Me.comboSrcMonth.Items.Add(month)
            ' Me.comboSrchMonthO.Items.Add(month)
        Next
        Me.comboSrcYr.Text = MaxDate.Substring(0, 4)
        Me.comboSrcMonth.Text = Val(MaxDate.Substring(4, 2))
        'Me.comboSrchYrO.Text = Me.comboSrcYr.Text
        'Me.comboSrchMonthO.Text = Me.comboSrcMonth.Text
        ProductDT = cls.GetProduct()
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
        'OptObjEnable(False)
        LoadFlag = False
        FncLoadProductByMonth(Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00"))
        'FncLoadProductByMonthO(Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00"))
        Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
        'Me.dtgRateTableO.Columns("lot_rangeO").HeaderText = "Turnover Range"
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ActionFlag.Length > 0 Then
            ActionFlag = ""
            'If Me.TabControl.SelectedTab.Name = Me.s.Name Then
            Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)
            ObjEnable(False)
            'End If
            'If Me.TabControl.SelectedTab.Name = Me.TabPageOptions.Name Then
            '    Me.dtgRateTableO_SelectionChanged(Nothing, System.EventArgs.Empty)
            '    OptObjEnable(False)
            'End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim ACcondition As String = ""
        If Me.txtSrcAcc.Text.Length > 0 Then
            ACcondition += " and upper(a.acc_no) like '%" & Me.txtSrcAcc.Text & "%' "
        End If
        If Me.rbSrchAll.Checked Then
            ACcondition += " and (left(b.rate_type,3) ='INT' or left(b.rate_type,3) ='NOR' or left(b.rate_type,3) ='CON' )"
        Else
            If Me.rbSrchNormal.Checked Then
                ACcondition += " and left(b.rate_type,3) ='NOR' "
            ElseIf Me.rbSrchInternet.Checked Then
                ACcondition += " and left(b.rate_type,3) ='INT'"
            Else
                ACcondition += " and left(b.rate_type,3) ='CON'"
            End If
        End If
        If Me.rbSrchFutALL.Checked Then
            ACcondition += " and (right(b.rate_type,1) ='B' or right(b.rate_type,1) ='F' or right(b.rate_type,1) ='O') "
        ElseIf Me.rbSrchFutures.Checked Then
            ACcondition += " and right(b.rate_type,1) ='F' "
        ElseIf Me.rbSrchOptions.Checked Then
            ACcondition += " and right(b.rate_type,1) ='O' "
        ElseIf Me.rbSrchFutOpt.Checked Then
            ACcondition += " and right(b.rate_type,1) ='B' "
        End If
        If Me.txtSrcAe.Text.Trim.Length > 0 Then
            ACcondition += " and b.ae_no ='" & Me.txtSrcAe.Text & "' "
        End If
        If Me.comboSrchProd.Text.Length > 0 Then
            ACcondition += " and b.product_group= '" & Me.comboSrchProd.Text & "' "
        End If
        ACcondition += " and b.comm_type='" & C_type & "' and b.comm_month='" & Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00") & "' "
        Me.dtgAC.DataSource = cls.EnquiryACTbl(ACcondition).Tables(0)
        dtgAC_SelectionChanged(Nothing, System.EventArgs.Empty)
        lsubGoRecord()
        If dtgAC.RowCount <= 0 Then
            dtgAE.DataSource = cls.EnquiryAETbl(" and 1=0 ").Tables(0)
            dtgRateTbl.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
            EmptyField()
        Else
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
        End If
        Me.dtgAC.Focus()
    End Sub

    Private Sub dtgAC_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgAC.SelectionChanged
        If ActionFlag = "" And LoadFlag = False Then
            If dtgAC.SelectedRows.Count > 0 Then
                Dim condition As String
                condition = " and b.comm_type='" & C_type & "'"
                condition += "  and b.acc_no='" & Me.dtgAC.CurrentRow.Cells("ACNo").Value.ToString.Trim & "'"
                If Me.txtSrcAe.Text.Trim.Length > 0 Then
                    condition += " and b.ae_no ='" & Me.txtSrcAe.Text & "' "
                End If
                condition += "  and b.comm_month ='" & Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00") & "' "
                If Me.rbSrchAll.Checked Then
                    condition += " and (left(b.rate_type,3) ='INT' or left(b.rate_type,3) ='NOR' or left(b.rate_type,3) ='CON' )"
                Else
                    If Me.rbSrchNormal.Checked Then
                        condition += " and left(b.rate_type,3) ='NOR' "
                    ElseIf Me.rbSrchInternet.Checked Then
                        condition += " and left(b.rate_type,3) ='INT'"
                    Else
                        condition += " and left(b.rate_type,3) ='CON'"
                    End If
                End If
                If Me.rbSrchFutALL.Checked Then
                    condition += " and (right(b.rate_type,1) ='B' or right(b.rate_type,1) ='F' or right(b.rate_type,1) ='O') "
                ElseIf Me.rbSrchFutures.Checked Then
                    condition += " and right(b.rate_type,1) ='F' "
                ElseIf Me.rbSrchOptions.Checked Then
                    condition += " and right(b.rate_type,1) ='O' "
                ElseIf Me.rbSrchFutOpt.Checked Then
                    condition += " and right(b.rate_type,1) ='B' "
                End If
                If Me.comboSrchProd.Text.Length > 0 Then
                    condition += " and b.product_group= '" & Me.comboSrchProd.Text.ToUpper & "' "
                End If
                Me.dtgAE.DataSource = cls.EnquiryAETbl(condition).Tables(0)
                Me.comboAccNo.Text = Me.dtgAC.CurrentRow.Cells("ACNo").Value.ToString.Trim
                dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub dtgAE_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgAE.SelectionChanged
        If ActionFlag = "" And LoadFlag = False Then
            If Me.dtgAE.Rows.Count > 0 Then
                If Me.dtgAE.SelectedRows.Count > 0 Then
                    Dim condition As String = " and comm_type='" & C_type & "' and comm_month ='" & Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00") & "' "
                    condition += " and acc_no='" & Me.comboAccNo.Text & "'  and ae_no='" & Me.dtgAE.CurrentRow.Cells("AENo").Value.ToString.Trim & "' "
                    If Me.rbSrchAll.Checked Then
                        condition += " and (left(rate_type,3) ='INT' or left(rate_type,3) ='NOR' or left(rate_type,3) ='CON' )"
                    Else
                        If Me.rbSrchNormal.Checked Then
                            condition += " and left(rate_type,3) ='NOR' "
                        ElseIf Me.rbSrchInternet.Checked Then
                            condition += " and left(rate_type,3) ='INT'"
                        Else
                            condition += " and left(rate_type,3) ='CON'"
                        End If
                    End If
                    If Me.rbSrchFutALL.Checked Then
                        condition += " and (right(rate_type,1) ='B' or right(rate_type,1) ='F' or right(rate_type,1) ='O') "
                    ElseIf Me.rbSrchFutures.Checked Then
                        condition += " and right(rate_type,1) ='F' "
                    ElseIf Me.rbSrchOptions.Checked Then
                        condition += " and right(rate_type,1) ='O' "
                    ElseIf Me.rbSrchFutOpt.Checked Then
                        condition += " and right(rate_type,1) ='B' "
                    End If
                    If Me.comboSrchProd.Text.Length > 0 Then
                        condition += " and product_group= '" & Me.comboSrchProd.Text.ToUpper & "' "
                    End If
                    Me.dtgRateTbl.DataSource = cls.EnquiryRateTbl(condition, " product_group asc, comm_month asc, acc_group asc, " & _
                        "rate_type desc, turnover_from asc, ")
                End If
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
            If dtgRateTbl.Rows.Count > 0 Then
                Me.comboAccNo.Text = Me.dtgRateTbl.CurrentRow.Cells("acc_no").Value.ToString.Trim
                Me.comboProduct.Text = Me.dtgRateTbl.CurrentRow.Cells("product_group").Value.ToString.Trim
                Me.txtMonth.Text = Me.dtgRateTbl.CurrentRow.Cells("comm_month").Value.ToString.Trim
                Me.txtTOFrom.Text = Me.dtgRateTbl.CurrentRow.Cells("turnover_from").Value.ToString.Trim
                'Me.txtRate.Text = Me.dtgRateTbl.CurrentRow.Cells("rate").Value.ToString.Trim
                ' Me.txtACGp.Text = Me.dtgRateTbl.CurrentRow.Cells("acc_group").Value.ToString.Trim
                Me.comboAE.Text = Me.dtgRateTbl.CurrentRow.Cells("ae_no").Value.ToString.Trim
                'Select Case Me.dtgRateTbl.CurrentRow.Cells("rate_type").Value.ToString.Trim
                '    Case "All"
                '        Me.rbRateAll.Checked = True
                '    Case "Day"
                '        Me.rbDayRate.Checked = True
                '    Case "Overnight"
                '        Me.rbNightRate.Checked = True
                'End Select
                Select Case Me.dtgRateTbl.CurrentRow.Cells("fut_type").Value.ToString.Trim
                    Case "Futures"
                        Me.rbFutures.Checked = True
                    Case "Options"
                        Me.rbOptions.Checked = True
                    Case "Futures and Options"
                        Me.rbFutOpt.Checked = True
                End Select
                Me.txtRate.Text = Me.dtgRateTbl.CurrentRow.Cells("day_rate").Value.ToString.Trim
                Me.txtNRate.Text = Me.dtgRateTbl.CurrentRow.Cells("night_rate").Value.ToString.Trim
                Select Case Me.dtgRateTbl.CurrentRow.Cells("trade_type").Value.ToString.Trim
                    Case "Normal Trade"
                        Me.rbNormal.Checked = True
                        Me.cbConsolidate.Checked = False
                    Case "Internet Trade"
                        Me.rbInternet.Checked = True
                        Me.cbConsolidate.Checked = False
                    Case "Consolidate Trade"
                        Me.cbConsolidate.Checked = True
                End Select
                Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
                lFnRefreshTurnover()
            End If
        Else
            EmptyField()
        End If
    End Sub

    Private Sub comboAccNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboAccNo.SelectedIndexChanged, comboAccNo.LostFocus
        If LoadFlag = False Then
            If Me.comboAccNo.Text.Length > 0 Then
                Me.comboAccNo.Text = Me.comboAccNo.Text.ToUpper
                Dim Acc() As DataRow = AccDT.Select(" acc_no ='" & comboAccNo.Text & "' and txmonth='" & Me.txtMonth.Text & "'")
                If Acc.Length > 0 Then
                    Me.txtAccName.Text = Acc(0).Item("acc_name").ToString.Trim
                    Me.comboAE.Text = Acc(0).Item("ae_no").ToString.Trim
                Else
                    Acc = AccDT.Select(" acc_no ='" & comboAccNo.Text & "' ")
                    If Acc.Length > 0 Then
                        Me.txtAccName.Text = Acc(0).Item("acc_name").ToString.Trim
                    Else
                        Me.txtAccName.Text = ""
                    End If
                    Me.comboAE.Text = ""
                    'Me.txtACGp.Text = ""
                End If
            Else
                Me.txtAccName.Text = ""
                Me.comboAE.SelectedIndex = -1
                'Me.txtACGp.Text = ""
            End If
            ChangeConsolid(Me.comboAccNo.Text, Me.txtMonth.Text)
            Me.comboAE_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub comboProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboProduct.SelectedIndexChanged, comboProduct.LostFocus
        If LoadFlag = False Then
            If Me.comboProduct.Text.Length > 0 Then
                Me.comboProduct.Text = Me.comboProduct.Text.ToUpper
                '    Dim Prod() As DataRow = ProductDT.Select(" product_group ='" & Me.comboProduct.Text & "'")
                '    Me.txtProductName.Text = Prod(0).Item("product_name").ToString.Trim
                'Else
                '    Me.txtProductName.Text = ""
            End If
        End If
    End Sub

    Private Sub ObjEnable(ByVal blnflag As Boolean)
        Me.txtSrcAcc.Enabled = Not blnflag
        Me.comboSrcMonth.Enabled = False
        Me.comboSrcYr.Enabled = False
        Me.comboSrchProd.Enabled = Not blnflag
        Me.comboAE.Enabled = False
        Me.rbNormal.Enabled = blnflag
        Me.rbInternet.Enabled = blnflag
        'Me.rbDayRate.Enabled = blnflag
        'Me.rbNightRate.Enabled = blnflag
        'Me.rbRateAll.Enabled = blnflag
        Me.btnSearch.Enabled = Not blnflag
        Me.dtgRateTbl.Enabled = Not blnflag
        Me.dtgAC.Enabled = Not blnflag
        Me.dtgAE.Enabled = Not blnflag
        Me.txtTOFrom.Enabled = blnflag
        Me.txtRate.Enabled = blnflag
        Me.txtNRate.Enabled = blnflag
        'Me.txtACGp.Enabled = False
        Me.txtMonth.Enabled = False
        Me.comboAccNo.Visible = True
        Me.txtAccName.Visible = True
        Me.lblAcc.Visible = True
        Me.rbSrchFutOpt.Enabled = Not blnflag
        Me.rbSrchFutures.Enabled = Not blnflag
        Me.rbSrchOptions.Enabled = Not blnflag
        Me.rbSrchFutALL.Enabled = Not blnflag
        Me.rbFutOpt.Enabled = blnflag
        Me.rbFutures.Enabled = blnflag
        Me.rbOptions.Enabled = blnflag
        'Me.comboSrchRateType.Enabled = Not blnflag
        Me.rbSrchNormal.Enabled = Not blnflag
        Me.rbSrchInternet.Enabled = Not blnflag
        Me.rbSrchAll.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        Me.btnDelete.Enabled = Not blnflag
        Me.btnNew.Enabled = Not blnflag
        Me.btnEdit.Enabled = Not blnflag
        Me.btnBNew.Enabled = Not blnflag
        Me.btnBEdit.Enabled = Not blnflag
        Me.btnBDelete.Enabled = Not blnflag
        Me.rbSrchConsolidate.Enabled = Not blnflag
        Me.txtSrcAe.Enabled = Not blnflag
        Me.cbConsolidate.Enabled = blnflag
        Select Case ActionFlag
            Case "New", "BA"
                Me.comboAccNo.Enabled = blnflag
                Me.comboProduct.Enabled = blnflag
            Case "Edit"
                Me.comboAccNo.Enabled = Not blnflag
                Me.comboProduct.Enabled = Not blnflag
            Case Else
                Me.comboAccNo.Enabled = False
                Me.comboProduct.Enabled = False
        End Select
    End Sub

    Private Sub comboAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboAE.SelectedIndexChanged, comboAE.LostFocus
        If LoadFlag = False Then
            If Me.comboAE.Text.Length > 0 Then
                Dim AE() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAE.Text & "'")
                If AE.Length > 0 Then
                    Me.txtAEName.Text = AE(0).Item("ae_name").ToString.Trim
                Else
                    Me.txtAEName.Text = ""
                End If
            Else
                Me.txtAEName.Text = ""
            End If
        End If
    End Sub

    Private Sub comboSrcMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboSrcMonth.SelectedIndexChanged, comboSrcYr.SelectedIndexChanged
        If LoadFlag = False Then
            If comboSrcMonth.Text.Length > 0 And comboSrcYr.Text.Length > 0 Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                Me.txtMonth.Text = Me.comboSrcYr.Text.Trim & Format(Val(comboSrcMonth.Text.Trim), "00")
                Me.FncLoadProductByMonth(txtMonth.Text)
            End If
        End If
    End Sub

    '*******************************************************************Edit****************************************************************
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ActionFlag = "New"
        ObjEnable(True)
        EmptyField()
        Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
        If Me.rbSrchNormal.Checked Then
            Me.rbNormal.Checked = True
            'Me.cbConsolidate.Checked = False
        ElseIf Me.rbSrchInternet.Checked Then
            Me.rbInternet.Checked = True
            'Me.cbConsolidate.Checked = False
            'Else
            'Me.cbConsolidate.Checked = True
        End If
        'Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
        ChangeConsolid(Me.comboAccNo.Text, Me.txtMonth.Text)
        If Me.rbSrchOptions.Checked Then
            Me.rbOptions.Checked = True
        ElseIf Me.rbSrchFutures.Checked Then
            Me.rbFutures.Checked = True
        Else
            Me.rbFutOpt.Checked = True
        End If
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
        If dtgAC.Rows.Count > 0 Then
            Me.comboAccNo.Text = Me.dtgAC.CurrentRow.Cells("ACNo").Value.ToString.Trim
        End If
        If Me.comboSrchProd.Text.Length > 0 Then
            Me.comboProduct.Text = Me.comboSrchProd.Text
        End If
        comboAccNo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        lFnRefreshTurnover()
        Me.comboAccNo.Focus()
    End Sub
    Private Sub btnBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBNew.Click
        Dim rate_type As String = ""
        ActionFlag = "BA"
        Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
        If (Me.rbSrchInternet.Checked) Then
            Me.rbInternet.Checked = True
            'Me.cbConsolidate.Checked = False
            'ElseIf Me.rbSrchConsolidate.Checked Then
            'Me.cbConsolidate.Checked = True
        Else
            Me.rbNormal.Checked = True
            'Me.cbConsolidate.Checked = True
        End If
        If Me.rbSrchFutures.Checked Then
            Me.rbFutures.Checked = True
        ElseIf Me.rbSrchInternet.Checked Then
            Me.rbInternet.Checked = True
        Else
            Me.rbSrchFutOpt.Checked = True
        End If
        'Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
        Me.ChangeConsolid(Me.comboAccNo.Text, Me.txtMonth.Text)
        Me.txtTOFrom.Text = 0
        lFnRefreshTurnover()
        Me.txtRate.Text = 0
        Me.txtNRate.Text = 0
        ObjEnable(True)
        Me.comboAccNo.Enabled = True
        Me.comboAE.Enabled = True
        Me.comboAccNo.Visible = False
        Me.txtAccName.Visible = False
        Me.lblAcc.Visible = False
        Me.comboAccNo.Focus()
    End Sub

    Private Sub btnBEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBEdit.Click
        ActionFlag = "BE"
        If (Me.dtgRateTbl.Rows.Count > 0) Then
            ObjEnable(True)
            Me.comboAccNo.Visible = False
            Me.txtAccName.Visible = False
            Me.lblAcc.Visible = False
            'Me.cbConsolidate.Enabled = False
            Me.rbInternet.Enabled = False
            Me.rbNormal.Enabled = False
            Me.txtRate.Focus()
            Me.txtTOFrom.Enabled = False
            Me.ChangeConsolid(Me.comboAccNo.Text, Me.txtMonth.Text)
        Else
            GSubShowInfo("no record to edit")
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dtgRateTbl.SelectedRows.Count > 0 Then
            ActionFlag = "Edit"
            ObjEnable(True)
            Me.ChangeConsolid(Me.comboAccNo.Text, Me.txtMonth.Text)
            Me.txtTOFrom.Focus()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim condition As String = ""
        Dim log As String
        Select Case ActionFlag
            Case "New"
                If Validation() = False Then
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
                condition = "'" & Me.comboAccNo.Text & "', ' ', ' ', ' ', '" & Me.comboAE.Text.Trim & "', '" & _
                    Me.comboProduct.Text & "', 0, '" & RateType() & "', " & CDbl(Me.txtTOFrom.Text) & ", " & _
                    CDbl(Me.txtRate.Text) & ", " & CDbl(Me.txtNRate.Text) & ", 0, '" & Me.txtMonth.Text & "', '" & C_type & "' "
                'log for add only
                log = "'" & GStrloginID & "', GETDATE(), 'A', 'CommRateTblFutACC', '" & Me.comboAE.Text & "', '" & _
                    Me.comboAccNo.Text & "', '', '" & Me.txtMonth.Text & "', '" & GFncSqlQuote(fncGenLog()) & "', "
                ObjRsid = cls.NewRecord(condition, log)
                ac = Me.comboAccNo.Text
                ae = Me.comboAE.Text
                ActionFlag = ""
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                ObjEnable(False)
                Me.dtgRateTbl.Focus()
            Case "Edit"
                If Validation() = False Then
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
                condition = " turnover_from = " & CDbl(Me.txtTOFrom.Text.Trim) & ", rate_type = '" & RateType() & _
                    "', ae_no = '" & Me.comboAE.Text.Trim & "', day_rate = " & CDbl(Me.txtRate.Text) & ", night_rate = " & _
                    CDbl(Me.txtNRate.Text) & " "
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value).Tables(0)
                If dt.Rows.Count <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                log = "'" & GStrloginID & "', GETDATE(), 'M', 'CommRateTblFutACC', '" & dt.Rows(0).Item("ae_no").ToString.Trim & _
                    "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                    Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & _
                    "', '" & GFncSqlQuote(fncGenLog()) & "' "
                cls.EditRecord(condition, Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim, log)
                ObjRsid = Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim
                ac = Me.comboAccNo.Text
                ae = Me.comboAE.Text
                ActionFlag = ""
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                ObjEnable(False)
                Me.dtgRateTbl.Focus()
                'Case "NewOpt"
                '    If Validation() = False Then
                '        Return
                '    End If
                '    If Val(CDbl(Me.txtCommRateO.Text)) > 100 Then
                '        GSubShowInfo(GFncGetSysMsg(43))
                '        Return
                '    End If

                '    If GSubShowYNConfirm(GFncGetSysMsg(40), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                '        Return
                '    End If
                '    If OptValidateDuplicate() Then
                '        GSubShowInfo(GFncGetSysMsg(44))
                '        Return
                '    End If
                '    condition = "'" & Me.comboAccNoO.Text & "', " & _
                '                                        "' ', " & _
                '                                        "' ', ' ', " & _
                '                                        "'" & Me.comboAEO.Text.Trim & "', " & _
                '                                        "'" & Me.comboProductO.Text & "', " & _
                '                                        CDbl(Me.txtCommRateO.Text) & ", " & _
                '                                        "'" & RateType(FutFlag) & "', " & _
                '                                        CDbl(Me.txtTOFromO.Text) & ", " & _
                '                                        "0, " & _
                '                                        "0, " & _
                '                                        "0, " & _
                '                                        "'" & Me.txtMonthO.Text & "'," & _
                '                                                                           "'" & C_type & "'"
                '    'log for add only
                '    log = "'" & GStrloginID & "', GETDATE(), '" & "A" & "', 'CommRateTblFutACC', '" & _
                '                                                        Me.comboAEO.Text & "', '" & Me.comboAccNoO.Text & "', ' ', " & _
                '                                                         "'" & Me.txtMonthO.Text & "', '" & GFncSqlQuote(fncGenLog()) & "',"
                '    ObjRsid = cls.NewRecord(condition, log)
                '    ac = Me.comboAccNoO.Text
                '    ae = Me.comboAEO.Text
                '    ActionFlag = ""
                '    Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
                '    OptObjEnable(False)
                '    Me.dtgRateTableO.Focus()

                'Case "EditOpt"
                '    If Validation() = False Then
                '        Return
                '    End If
                '    If Val(CDbl(Me.txtCommRateO.Text)) > 100 Then
                '        GSubShowInfo(GFncGetSysMsg(43))
                '        Return
                '    End If
                '    If GSubShowYNConfirm(GFncGetSysMsg(48), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                '        Return
                '    End If
                '    If OptValidateDuplicate() Then
                '        GSubShowInfo(GFncGetSysMsg(44))
                '        Return
                '    End If
                '    condition = " turnover_from =" & CDbl(Me.txtTOFromO.Text.Trim) & ", " & _
                '                         " rate_type ='" & RateType(FutFlag) & "', ae_no='" & Me.comboAEO.Text.Trim & "', " & _
                '                         " comm_rate =" & CDbl(Me.txtCommRateO.Text) & " "

                '    Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value).Tables(0)
                '    If dt.Rows.Count <= 0 Then
                '        GSubShowInfo(GFncGetSysMsg(9))
                '        Return
                '    End If
                '    log = "'" & GStrloginID & "', GETDATE(), '" & "M" & "', 'CommRateTblFutACC', '" & _
                '                                                       dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', ' ', " & _
                '                                                       "'" & Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value & "'," & _
                '                                                       "'" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog()) & "' "
                '    cls.EditRecord(condition, Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim, log)
                '    ObjRsid = Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim
                '    ac = Me.comboAccNoO.Text
                '    ae = Me.comboAEO.Text
                '    ActionFlag = ""
                '    Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
                '    OptObjEnable(False)
                '    Me.dtgRateTableO.Focus()
            Case "BA", "BE"
                If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                    If Me.comboAE.Text.Trim.Length <= 0 Then
                        GSubShowInfo(GFncGetSysMsg(31))
                        Me.comboAE.Focus()
                        Return
                    End If
                    Dim comm_month As String = Me.txtMonth.Text
                    Dim ae_no As String = Me.comboAE.Text
                    Dim rate_type As String = ""
                    rate_type = RateType()
                    Dim turnover_from As String = Me.txtTOFrom.Text
                    Dim day_rate As String = Me.txtRate.Text
                    Dim Night_rate As String = Me.txtNRate.Text
                    Dim comm_type As String = C_type
                    Dim prod As String = Me.comboProduct.Text
                    If (Val(day_rate) > 100) Then
                        GSubShowInfo(GFncGetSysMsg(43))
                        Me.txtRate.Focus()
                        Return
                    End If
                    If (Val(Night_rate) > 100) Then
                        GSubShowInfo(GFncGetSysMsg(43))
                        Me.txtNRate.Focus()
                        Return
                    End If
                    If GFncCheckCommStatus() Then
                        Return
                    End If
                    Dim MyTrans As SqlTransaction = Nothing
                    Dim ldtAcc As DataTable = cls.lFnGetAllAccNo(comm_month, ae_no).Tables(0)
                    Try
                        MyTrans = GSCnSqlConn.BeginTransaction
                        If (ActionFlag = "BA") Then
                            cls.lFncDeleteBRate(rate_type, comm_type, prod, turnover_from, comm_month, ae_no, MyTrans)
                            For Each ldrAcc As DataRow In ldtAcc.Rows
                                Dim AC() As DataRow = AccDT.Select("acc_no = '" & ldrAcc.Item("acc_no") & "' and txmonth = '" & _
                                    comm_month & "'")
                                If AC.Length > 0 Then
                                    If AC(0).Item("isConsolid") <> Me.cbConsolidate.Checked Then
                                        If (MyTrans IsNot Nothing) Then
                                            MyTrans.Rollback()
                                        End If
                                        GSubShowInfo("Account(" & ldrAcc.Item("acc_no") & ")" & GFncGetSysMsg(85))
                                        Return
                                    End If
                                Else
                                    If (MyTrans IsNot Nothing) Then
                                        MyTrans.Rollback()
                                    End If
                                    GSubShowInfo("Account(" & ldrAcc.Item("acc_no") & ")" & GFncGetSysMsg(86))
                                    Return
                                End If
                                cls.lFncInsertRate(ldrAcc("acc_no"), ae_no, "", rate_type, prod, turnover_from, 0, day_rate, _
                                    Night_rate, comm_month, comm_type, MyTrans)
                            Next
                        ElseIf (ActionFlag = "BE") Then
                            Dim AE() As DataRow = AccDT.Select("ae_no = '" & ae_no & "' and txmonth = '" & comm_month & "'")
                            If AE.Length > 0 Then
                                For row As Integer = 0 To AE.Length - 1
                                    If AE(row).Item("isConsolid") <> Me.cbConsolidate.Checked Then
                                        If (MyTrans IsNot Nothing) Then
                                            MyTrans.Rollback()
                                        End If
                                        GSubShowInfo("Account(" & AE(row).Item("acc_no") & ")" & GFncGetSysMsg(85))
                                        Return
                                    End If
                                Next
                            End If
                            cls.lFncModifyBRate(rate_type, comm_type, prod, turnover_from, "", day_rate, Night_rate, comm_month, _
                                ae_no, MyTrans)
                            End If
                            MyTrans.Commit()
                            MyTrans = Nothing
                            If (ObjRsid = 0) Then
                                ObjRsid = cls.lFnGetRSID()
                            End If
                    Catch ex As Exception
                        If GSCnSqlConn.State <> ConnectionState.Closed Then
                            If (MyTrans IsNot Nothing) Then
                                MyTrans.Rollback()
                            End If
                            GSubWriteErrLog(ex.Message)
                        End If
                    End Try
                    ActionFlag = ""
                    Me.txtSrcAe.Text = Me.comboAE.Text
                    Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                    ObjEnable(False)
                Else
                    Return
                End If
                'Case "BAO", "BEO"
                '    If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                '        If Me.comboAEO.Text.Trim.Length <= 0 Then
                '            GSubShowInfo(GFncGetSysMsg(31))
                '            Me.comboAEO.Focus()
                '            Return
                '        End If
                '        Dim comm_month As String = Me.txtMonthO.Text
                '        Dim ae_no As String = Me.comboAEO.Text
                '        Dim rate_type As String = ""
                '        rate_type = RateType(FutFlag)

                '        Dim turnover_from As String = Me.txtTOFromO.Text
                '        Dim Comm_rate As String = Me.txtCommRateO.Text
                '        Dim comm_type As String = C_type
                '        Dim prod As String = Me.comboProductO.Text

                '        If (Val(Comm_rate) > 100) Then
                '            GSubShowInfo(GFncGetSysMsg(43))
                '            Me.txtCommRateO.Focus()
                '            Return
                '        End If
                '        Dim MyTrans As SqlTransaction
                '        Dim ldtAcc As DataTable = cls.lFnGetAllAccNo(comm_month, ae_no).Tables(0)
                '        Try
                '            MyTrans = GSCnSqlConn.BeginTransaction
                '            If (ActionFlag = "BAO") Then
                '                cls.lFncDeleteBRate(rate_type, comm_type, prod, turnover_from, comm_month, ae_no, MyTrans)
                '                For Each ldrAcc As DataRow In ldtAcc.Rows
                '                    cls.lFncInsertRate(ldrAcc("acc_no"), ae_no, "", rate_type, prod, turnover_from, Comm_rate, 0, 0, comm_month, comm_type, MyTrans)
                '                Next
                '            ElseIf (ActionFlag = "BEO") Then
                '                cls.lFncModifyBRate(rate_type, comm_type, prod, turnover_from, Comm_rate, "", "", comm_month, ae_no, MyTrans)
                '            End If
                '            MyTrans.Commit()
                '            MyTrans = Nothing
                '            If (ObjRsid = 0) Then
                '                ObjRsid = cls.lFnGetRSID()
                '            End If
                '        Catch ex As Exception
                '            If GSCnSqlConn.State <> ConnectionState.Closed Then
                '                If (MyTrans IsNot Nothing) Then
                '                    MyTrans.Rollback()
                '                End If
                '                GSubWriteErrLog(ex.Message)
                '            End If
                '        End Try
                '        ActionFlag = ""
                '        Me.txtSrchAeO.Text = Me.comboAEO.Text
                '        Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)

                '        OptObjEnable(False)
                '    Else
                '        Return
                '    End If
        End Select
    End Sub

    Private Function Validation() As Boolean
        Dim ErrorMsg As String = ""
        If ActionFlag = "New" Or ActionFlag = "Edit" Then
            If Me.comboAccNo.Text.Length <= 0 Then
                ErrorMsg += " Account,"
            End If
            If Me.comboAE.Text.Length <= 0 Then
                ErrorMsg += "A/E code,"
            End If
            If Me.comboProduct.Text.Length <= 0 Then
                ErrorMsg += " Product,"
            End If
            If Me.txtMonth.Text.Length <= 0 Then
                ErrorMsg += " Month,"
            End If
            If Me.txtTOFrom.TextLength <= 0 Then
                ErrorMsg += " Lot,"
            End If
            If Me.txtRate.TextLength <= 0 Then
                ErrorMsg += " Day Rate,"
            End If
            If Me.txtNRate.TextLength <= 0 Then
                ErrorMsg += " Night Rate,"
            End If
            'If Me.comboAE.Text.Length <= 0 Then
            '    ErrorMsg += "A/C Group,"
            'End If
        End If
        'If ActionFlag = "NewOpt" Or ActionFlag = "EditOpt" Then
        '    If Me.comboAccNoO.Text.Length <= 0 Then
        '        ErrorMsg += " Account,"
        '    End If
        '    If Me.comboAEO.Text.Length <= 0 Then
        '        ErrorMsg += "A/E code,"
        '    End If
        '    If Me.comboProductO.Text.Length <= 0 Then
        '        ErrorMsg += " Product,"
        '    End If
        '    If Me.txtMonthO.Text.Length <= 0 Then
        '        ErrorMsg += " Month,"
        '    End If
        '    If Me.txtTOFromO.TextLength <= 0 Then
        '        ErrorMsg += " Turnover,"
        '    End If
        '    If Me.txtCommRateO.TextLength <= 0 Then
        '        ErrorMsg += " Comm. Rate,"
        '    End If
        'End If
        If ErrorMsg.Length > 0 Then
            GSubShowInfo(ErrorMsg.Substring(0, ErrorMsg.Length - 1) & GFncGetSysMsg(49))
            Return False
        Else
            Dim AccDr() As DataRow = Nothing
            If ActionFlag = "New" Or ActionFlag = "Edit" Then
                AccDr = AccDT.Select("acc_no='" & Me.comboAccNo.Text.Trim & "'")
                'Else
                '    AccDr = AccDT.Select("acc_no='" & Me.comboAccNoO.Text.Trim & "'")
            End If
            If AccDr.Length <= 0 Then
                GSubShowInfo(GFncGetSysMsg(5))
                Return False
            End If
            Dim ProductDr() As DataRow = Nothing
            If ActionFlag = "New" Or ActionFlag = "Edit" Then
                ProductDr = ProductDT.Select("product_group='" & Me.comboProduct.Text & "'")
                'Else
                '    ProductDr = ProductDT.Select("product_group='" & Me.comboProductO.Text & "'")
            End If
            If ProductDr.Length <= 0 Then
                GSubShowInfo(GFncGetSysMsg(51))
                Return False
            End If
            Dim AeDr() As DataRow = Nothing
            If ActionFlag = "New" Or ActionFlag = "Edit" Then
                AeDr = AeDT.Select("ae_no='" & Me.comboAE.Text & "'")
                'Else
                '    AeDr = AeDT.Select("ae_no='" & Me.comboAEO.Text & "'")
            End If
            If AeDr.Length <= 0 Then
                GSubShowInfo(GFncGetSysMsg(31))
                Return False
            End If
            Return True
        End If
    End Function

    Private Sub EmptyField()
        If LoadFlag = False Then
            If ActionFlag <> "New" Then
                Me.comboAccNo.Text = ""
                Me.txtAccName.Text = ""
            End If
            Me.comboProduct.Text = ""
            Me.txtTOFrom.Text = 0
            Me.txtRate.Text = "0.0000"
            Me.txtNRate.Text = "0.0000"
            'Me.txtACGp.Text = ""
            Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
            Me.comboAE.Text = ""
            Me.rbNormal.Checked = True
            'Me.cbDefault.Checked = False
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
            Dim log As String = "'" & GStrloginID & "', GETDATE(), 'D', 'CommRateTblFutACC', '" & _
                dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', '', '" & _
                Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & _
                GFncSqlQuote(fncGenLog()) & "' "
            cls.DelRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim, log)
            If dtgAC.RowCount > 0 Then
                ac = Me.dtgAC.CurrentRow.Cells("ACno").Value.ToString.Trim
            End If
            ObjEnable(False)
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
        Me.dtgRateTbl.Focus()
    End Sub

    Private Function RateType() As String
        Dim type As String = ""
        If Me.cbConsolidate.Checked Then
            type += "CON"
        Else
            If Me.rbNormal.Checked Then
                type += "NOR"
            Else
                type += "INT"
            End If
        End If
        If Me.rbFutOpt.Checked Then
            type += "B"
        ElseIf Me.rbOptions.Checked Then
            type += "O"
        Else
            type += "F"
        End If
        'If (fut = "Futures" And Me.cbDefault.Checked) Or (fut = "Options" And Me.cbDefaultO.Checked) Then
        '    type = "DEF" & type
        'End If
        Return type
    End Function

    Private Sub lsubGoRecord()
        If ac <> "" Then
            'If TabControl.SelectedTab.Name = Me.s.Name Then
            For lintCnt As Integer = 0 To Me.dtgAC.RowCount - 1
                If Me.dtgAC.Rows(lintCnt).Cells("ACNo").Value.ToString.Trim = ac Then
                    Me.dtgAC.Rows(lintCnt).Cells("ACNo").Selected = True
                End If
            Next
            Me.dtgAC_SelectionChanged(Nothing, System.EventArgs.Empty)
            If ae <> "" Then
                For lintCnt As Integer = 0 To Me.dtgAE.RowCount - 1
                    If Me.dtgAE.Rows(lintCnt).Cells("AENo").Value.ToString.Trim = ae Then
                        Me.dtgAE.Rows(lintCnt).Cells("AENo").Selected = True
                    End If
                Next
                Me.dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
            End If
            If ObjRsid > 0 Then
                For lintCnt As Integer = 0 To Me.dtgRateTbl.Rows.Count - 1
                    If Me.dtgRateTbl.Rows(lintCnt).Cells("rsid").Value.ToString.Trim = ObjRsid Then
                        Me.dtgRateTbl.Rows(lintCnt).Cells("product_group").Selected = True
                        Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)

                        Me.dtgRateTbl.Focus()
                        Exit For
                    End If
                Next
            End If
            ' Else
            'For lintCnt As Integer = 0 To Me.dtgACtblO.RowCount - 1
            '    If Me.dtgACtblO.Rows(lintCnt).Cells("ACNoO").Value.ToString.Trim = ac Then
            '        Me.dtgACtblO.Rows(lintCnt).Cells("ACNoO").Selected = True
            '    End If
            'Next
            'Me.dtgACtblO_SelectionChanged(Nothing, System.EventArgs.Empty)
            'If ae <> "" Then
            '    For lintCnt As Integer = 0 To Me.dtgAetblO.RowCount - 1
            '        If Me.dtgAetblO.Rows(lintCnt).Cells("AENoO").Value.ToString.Trim = ae Then
            '            Me.dtgAetblO.Rows(lintCnt).Cells("AENoO").Selected = True
            '        End If
            '    Next
            '    Me.dtgAetblO_SelectionChanged(Nothing, System.EventArgs.Empty)
            'End If
            'If ObjRsid > 0 Then
            '    For lintCnt As Integer = 0 To Me.dtgRateTableO.Rows.Count - 1
            '        If Me.dtgRateTableO.Rows(lintCnt).Cells("rsidO").Value.ToString.Trim = ObjRsid Then
            '            Me.dtgRateTableO.Rows(lintCnt).Cells("product_groupO").Selected = True
            '            Me.dtgRateTableO_SelectionChanged(Nothing, System.EventArgs.Empty)

            '            Me.dtgRateTableO.Focus()
            '            Exit For
            '        End If
            '    Next
            'End If
            'End If
            ObjRsid = 0
            ac = ""
            ae = ""
        End If
    End Sub

    'Private Sub TabControl_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs)
    '    If Me.btnNew.Enabled = False And Me.TabControl.SelectedTab.Name <> Me.s.Name Then
    '        e.Cancel = True
    '        Return
    '    End If
    '    If (ActionFlag = "EditOpt" Or ActionFlag = "NewOpt") And Me.TabControl.SelectedTab.Name <> Me.TabPageOptions.Name Then
    '        e.Cancel = True
    '        Return
    '    End If
    '    If Me.TabControl.SelectedTab.Name = Me.s.Name Then
    '        FutFlag = "Futures"
    '        Me.comboSrcMonth.Text = Me.comboSrchMonthO.Text
    '        Me.comboSrcYr.Text = Me.comboSrchYrO.Text
    '        Me.comboSrchProd.Text = Me.comboSrchProdO.Text
    '        Me.txtSrcAcc.Text = Me.txtSrchAccO.Text
    '        'Me.cbSrchDefault.Checked = Me.cbSrchDefaultO.Checked
    '        'Me.cbSrchDefaultO_CheckedChanged(Nothing, System.EventArgs.Empty)
    '        If Me.rbSrchAllO.Checked Then
    '            Me.rbSrchAll.Checked = True
    '        Else
    '            If Me.rbSrchInternetO.Checked Then
    '                Me.rbSrchInternet.Checked = True
    '            Else
    '                Me.rbSrchNormal.Checked = True
    '            End If
    '        End If
    '        Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
    '        Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)
    '    End If
    '    If Me.TabControl.SelectedTab.Name = Me.TabPageOptions.Name Then
    '        FutFlag = "Options"
    '        Me.comboSrchMonthO.Text = Me.comboSrcMonth.Text
    '        Me.comboSrchYrO.Text = Me.comboSrcYr.Text
    '        Me.comboSrchProdO.Text = Me.comboSrchProd.Text
    '        Me.txtSrchAccO.Text = Me.txtSrcAcc.Text
    '        'Me.cbSrchDefaultO.Checked = Me.cbSrchDefault.Checked
    '        'Me.cbSrchDefault_CheckedChanged(Nothing, System.EventArgs.Empty)

    '        If Me.rbSrchAll.Checked Then
    '            Me.rbSrchAllO.Checked = True
    '        Else
    '            If Me.rbSrchInternet.Checked Then
    '                Me.rbSrchInternetO.Checked = True
    '            Else
    '                Me.rbSrchNormalO.Checked = True
    '            End If
    '        End If
    '        Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    '        Me.dtgRateTableO_SelectionChanged(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    Private Function fncGenLog() As String
        Dim lstrLog As String = ""
        Select Case ActionFlag
            Case "Edit"
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim).Tables(0)
                If dt.Rows.Count > 0 Then
                    'If Me.comboAE.Text.Trim.Length > 0 And Me.comboAE.Text.Trim <> dt.Rows(0).Item("ae_no").ToString.Trim Then
                    '    lstrLog += cls.GfncOneFieldLog("ae_no", dt.Rows(0).Item("ae_no").ToString.Trim, Me.comboAE.Text.Trim)
                    'End If
                    If Me.txtRate.Text.Trim.Length > 0 And Me.txtRate.Text.Trim <> dt.Rows(0).Item("day_rate").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Day Rate", dt.Rows(0).Item("day_rate").ToString.Trim, Me.txtRate.Text.Trim)
                    End If
                    If Me.txtNRate.Text.Trim.Length > 0 And Me.txtNRate.Text.Trim <> dt.Rows(0).Item("rsid").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Night Rate", dt.Rows(0).Item("night_rate").ToString.Trim, Me.txtNRate.Text.Trim)
                    End If

                    If Me.txtTOFrom.Text.Trim.Length > 0 And CDbl(Me.txtTOFrom.Text.Trim) <> CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim) Then
                        lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim), CDbl(Me.txtTOFrom.Text.Trim))
                    End If
                    If Me.RateType().Trim <> dt.Rows(0).Item("rate_type").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Rate Type", dt.Rows(0).Item("rate_type").ToString.Trim, RateType().Trim)
                    End If
                    'If Me.txtRate.Text.Length > 0 Then
                    '    If Me.rbDayRate.Checked And dt.Rows(0).Item("day_rate").ToString.Trim <> Me.txtRate.Text.Trim Then
                    '        lstrLog += cls.GfncOneFieldLog("Day_rate", dt.Rows(0).Item("day_rate").ToString.Trim, Me.txtRate.Text.Trim)
                    '    Else
                    '        If Me.rbNightRate.Checked And dt.Rows(0).Item("night_rate").ToString.Trim <> Me.txtRate.Text.Trim Then
                    '            lstrLog += cls.GfncOneFieldLog("Night_rate", dt.Rows(0).Item("night_rate").ToString.Trim, Me.txtRate.Text.Trim)
                    '        Else
                    '            If dt.Rows(0).Item("all_rate").ToString.Trim <> Me.txtRate.Text.Trim Then
                    '                lstrLog += cls.GfncOneFieldLog("All_rate", dt.Rows(0).Item("all_rate").ToString.Trim, Me.txtRate.Text.Trim)
                    '            End If
                    '        End If
                    '    End If
                    'End If
                End If
            Case "New"
                'If Me.comboAE.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("ae_no", Me.comboAE.Text.Trim)
                'End If
                'If Me.comboAccNo.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("Acc_no", Me.comboAccNo.Text.Trim)
                'End If
                If Me.comboProduct.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Product Group", Me.comboProduct.Text.Trim)
                End If
                If Me.txtRate.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Day Rate", Me.txtRate.Text.Trim)
                End If
                If Me.txtNRate.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Night Rate", Me.txtNRate.Text.Trim)
                End If
                '    If Me.rbRateAll.Checked Then
                '        lstrLog += cls.GfncOneFieldLog("All_rate", Me.txtRate.Text.Trim)
                '    End If
                '    If Me.rbDayRate.Checked Then
                '        lstrLog += cls.GfncOneFieldLog("Day_rate", Me.txtRate.Text.Trim)
                '    End If
                '    If Me.rbNightRate.Checked Then
                '        lstrLog += cls.GfncOneFieldLog("Night_rate", Me.txtRate.Text.Trim)
                '    End If
                'End If
                'If Me.txtMonth.Text.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("comm_month", txtMonth.Text.Trim)
                'End If
                If Me.txtTOFrom.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Turnover  From", CDbl(Me.txtTOFrom.Text.Trim))
                End If
                'If Me.txtACGp.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("Acc_group", Me.txtACGp.Text.Trim)
                'End If
                lstrLog += cls.GfncOneFieldLog("Rate Type", RateType())
                lstrLog += cls.GfncOneFieldLog("Commission Type", C_type)
                'Case "EditOpt"
                '    Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim).Tables(0)
                '    If dt.Rows.Count > 0 Then
                '        If Me.comboAEO.Text.Trim.Length > 0 And Me.comboAEO.Text.Trim <> dt.Rows(0).Item("ae_no").ToString.Trim Then
                '            lstrLog += cls.GfncOneFieldLog("ae_no", dt.Rows(0).Item("ae_no").ToString.Trim, Me.comboAEO.Text.Trim)
                '        End If
                '        'If Me.txtACGpO.Text.Trim.Length > 0 And Me.txtACGpO.Text.Trim <> dt.Rows(0).Item("acc_group").ToString.Trim Then
                '        '    lstrLog += cls.GfncOneFieldLog("Acc_group", dt.Rows(0).Item("acc_group").ToString.Trim, Me.txtACGpO.Text.Trim)
                '        'End If
                '        If Me.txtTOFromO.Text.Trim.Length > 0 And CDbl(Me.txtTOFromO.Text.Trim) <> CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim) Then
                '            lstrLog += cls.GfncOneFieldLog("Turnover_from", CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim), CDbl(Me.txtTOFromO.Text.Trim))
                '        End If
                '        If Me.RateType(FutFlag).Trim <> dt.Rows(0).Item("rate_type").ToString.Trim Then
                '            lstrLog += cls.GfncOneFieldLog("Rate_type", dt.Rows(0).Item("rate_type").ToString.Trim, RateType(FutFlag).Trim)
                '        End If
                '        If Me.txtCommRateO.Text.Length > 0 And Me.txtCommRateO.Text <> dt.Rows(0).Item("comm_rate").ToString.Trim Then
                '            lstrLog += cls.GfncOneFieldLog("Comm_rate", dt.Rows(0).Item("comm_rate").ToString.Trim, Me.txtCommRateO.Text.Trim)
                '        End If
                '    End If
                'Case "NewOpt"
                '    If Me.comboAEO.Text.Trim.Length > 0 Then
                '        lstrLog += cls.GfncOneFieldLog("ae_no", Me.comboAEO.Text.Trim)
                '    End If
                '    If Me.comboAccNoO.Text.Trim.Length > 0 Then
                '        lstrLog += cls.GfncOneFieldLog("Acc_no", Me.comboAccNoO.Text.Trim)
                '    End If
                '    If Me.comboProductO.Text.Trim.Length > 0 Then
                '        lstrLog += cls.GfncOneFieldLog("product_group", Me.comboProductO.Text.Trim)
                '    End If
                '    If Me.txtCommRateO.Text.Trim.Length > 0 Then
                '        lstrLog += cls.GfncOneFieldLog("Comm_rate", Me.txtCommRateO.Text.Trim)
                '    End If
                '    If Me.txtMonthO.Text.Length > 0 Then
                '        lstrLog += cls.GfncOneFieldLog("comm_month", txtMonthO.Text.Trim)
                '    End If
                '    If Me.txtTOFromO.Text.Trim.Length > 0 Then
                '        lstrLog += cls.GfncOneFieldLog("Turnover_from", CDbl(Me.txtTOFromO.Text.Trim))
                '    End If
                '    'If Me.txtACGpO.Text.Trim.Length > 0 Then
                '    '    lstrLog += cls.GfncOneFieldLog("Acc_group", Me.txtACGpO.Text.Trim)
                '    'End If
                '    lstrLog += cls.GfncOneFieldLog("Rate_type", RateType(FutFlag))
                '    lstrLog += cls.GfncOneFieldLog("Comm_type", C_type)
        End Select
        Return lstrLog
    End Function

    Private Function ValidateDuplicate() As Boolean
        Dim condition As String = " and acc_no = '" & Me.comboAccNo.Text.Trim & "' and ae_no = '" & Me.comboAE.Text.Trim & _
            "' and product_group = '" & Me.comboProduct.Text.Trim & "' and turnover_from = " & CDbl(Me.txtTOFrom.Text.Trim) & _
            " and comm_month = '" & Me.txtMonth.Text.Trim & "' and comm_type = '" & C_type & "' and rate_type = '" & RateType() & "' "
        If ActionFlag = "Edit" Then
            condition += " and rsid <> '" & Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim & "' "
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

    Private Sub rbSrchInternet_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchInternet.CheckedChanged
        If LoadFlag = False Then
            If Me.rbSrchInternet.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub rbSrchNormal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchNormal.CheckedChanged
        If LoadFlag = False Then
            If rbSrchNormal.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub comboSrchRateType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        If LoadFlag = False Then
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub lFnRefreshTurnover()
        Dim comm_month As String = Me.txtMonth.Text
        Dim Rtype As String = RateType()
        Dim ae_num As String = Me.comboAE.Text
        Dim acc As String = Me.comboAccNo.Text
        'Dim acgp As String = Me.txtACGp.Text
        Dim product As String = Me.comboProduct.Text
        Dim turnover As String = CDbl(Me.txtTOFrom.Text)
        Dim lds As DataSet
        Dim turnoverTo As String = ""
        lds = cls.lFncGetNextComm(comm_month, Rtype, acc, ae_num, Nothing, Nothing, Nothing, product, C_type, turnover)
        If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
            Me.LabLot_range.Text = ""
        Else
            Me.LabLot_range.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,###.00")
        End If
    End Sub

    Private Sub LabLot_range_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTOFrom.LostFocus
        lFnRefreshTurnover()
    End Sub

    Private Sub rbNormal_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbNormal.CheckedChanged
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
    ''*****************************************************************************OPTIONS**************************************************************************************
    'Private Sub btnSearchO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        Dim ACcondition As String = ""
    '        If Me.txtSrchAccO.Text.Length > 0 Then
    '            ACcondition += " and upper(a.acc_no) like '%" & Me.txtSrchAccO.Text & "%' "
    '        End If

    '        If Me.comboSrchProdO.Text.Length > 0 Then
    '            ACcondition += " and b.product_group= '" & Me.comboSrchProdO.Text & "' "
    '        End If
    '        If Me.rbSrchAllO.Checked Then
    '            ACcondition += " and (b.rate_type ='INTO' or b.rate_type ='NORO' or b.rate_type ='CONO' )"
    '        Else
    '            If Me.rbSrchNormalO.Checked Then
    '                ACcondition += " and b.rate_type ='NORO' "
    '            ElseIf Me.rbSrchInternetO.Checked Then
    '                ACcondition += " and b.rate_type ='INTO'"
    '            Else
    '                ACcondition += " and b.rate_type ='CONO'"
    '            End If
    '        End If
    '        If Me.txtSrchAeO.Text.Trim.Length > 0 Then
    '            ACcondition += " and b.ae_no ='" & Me.txtSrchAeO.Text & "' "
    '        End If
    '        ACcondition += " and b.comm_type='" & C_type & "' and b.comm_month='" & Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00") & "' "
    '        Me.dtgACtblO.DataSource = cls.EnquiryACTbl(ACcondition).Tables(0)
    '        Me.dtgACtblO_SelectionChanged(Nothing, System.EventArgs.Empty)
    '        lsubGoRecord()
    '        If dtgACtblO.RowCount <= 0 Then
    '            dtgAetblO.DataSource = cls.EnquiryAETbl(" and 1=0 ").Tables(0)
    '            Me.dtgRateTableO.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
    '            Me.btnEditO.Enabled = False
    '            Me.btnDelO.Enabled = False
    '            Me.EmptyOptField()
    '        Else
    '            If Me.dtgRateTableO.RowCount > 0 Then
    '                Me.btnEditO.Enabled = True
    '                Me.btnDelO.Enabled = True
    '            Else
    '                Me.btnEditO.Enabled = False
    '                Me.btnDelO.Enabled = False
    '                EmptyField()
    '            End If
    '        End If
    '        Me.dtgACtblO.Focus()
    '    End If
    'End Sub

    'Private Sub dtgACtblO_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ActionFlag = "" And LoadFlag = False Then
    '        If Me.dtgACtblO.SelectedRows.Count > 0 Then
    '            Dim condition As String = " and b.comm_type='" & C_type & "'"
    '            condition += "  and b.acc_no='" & Me.dtgACtblO.CurrentRow.Cells("ACNoO").Value.ToString.Trim & "'"
    '            condition += "  and b.comm_month ='" & Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00") & "' "

    '            'If Me.rbSrchAllO.Checked Then
    '            '    condition += " and (left(b.rate_type,4) ='INTO' or left(b.rate_type,4) ='NORO' or left(b.rate_type,4) ='CONO' )"
    '            'Else
    '            'If Me.rbSrchNormalO.Checked Then
    '            '    condition += " and left(b.rate_type,4) ='NORO' "
    '            'ElseIf Me.rbSrchInternetO.Checked Then
    '            '    condition += " and left(b.rate_type,4) ='INTO'"
    '            'Else
    '            '    condition += " and left(b.rate_type,4) ='CONO'"
    '            'End If
    '            'End If
    '            If Me.rbSrchAllO.Checked Then
    '                condition += " and (b.rate_type ='INTO' or b.rate_type ='NORO' or b.rate_type ='CONO' )"
    '            Else
    '                If Me.rbSrchNormalO.Checked Then
    '                    condition += " and b.rate_type ='NORO' "
    '                ElseIf Me.rbSrchInternetO.Checked Then
    '                    condition += " and b.rate_type ='INTO'"
    '                Else
    '                    condition += " and b.rate_type ='CONO'"
    '                End If
    '            End If
    '            If Me.txtSrchAeO.Text.Trim.Length > 0 Then
    '                condition += " and b.ae_no ='" & Me.txtSrchAeO.Text & "' "
    '            End If
    '            If Me.comboSrchProdO.Text.Length > 0 Then
    '                condition += " and product_group= '" & Me.comboSrchProdO.Text & "' "
    '            End If
    '            Me.dtgAetblO.DataSource = cls.EnquiryAETbl(condition).Tables(0)
    '            Me.dtgAetblO_SelectionChanged(Nothing, System.EventArgs.Empty)
    '            If dtgACtblO.RowCount > 0 Then
    '                Me.comboAccNoO.Text = Me.dtgACtblO.CurrentRow.Cells("ACNoO").Value.ToString.Trim
    '            End If
    '            dtgAetblO_SelectionChanged(Nothing, System.EventArgs.Empty)
    '        End If
    '    End If
    'End Sub

    'Private Sub dtgAetblO_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If ActionFlag = "" And LoadFlag = False Then
    '        If Me.dtgAetblO.Rows.Count > 0 Then
    '            If Me.dtgAetblO.SelectedRows.Count > 0 Then
    '                Dim condition As String = " and comm_type='" & C_type & "'"
    '                condition += " and acc_no='" & Me.comboAccNoO.Text & "'  and ae_no='" & Me.dtgAetblO.CurrentRow.Cells("AENoO").Value.ToString.Trim & "'"
    '                condition += " and comm_month ='" & Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00") & "' "
    '                If Me.rbSrchAllO.Checked Then
    '                    condition += " and ( rate_type ='INTO' or rate_type ='NORO' or rate_type ='CONO' )"
    '                Else
    '                    If Me.rbSrchNormalO.Checked Then
    '                        condition += " and rate_type ='NORO' "
    '                    ElseIf Me.rbSrchInternetO.Checked Then
    '                        condition += " and rate_type ='INTO'"
    '                    Else
    '                        condition += " and rate_type ='CONO'"
    '                    End If
    '                End If

    '                If Me.comboSrchProdO.Text.Length > 0 Then
    '                    condition += " and product_group= '" & Me.comboSrchProdO.Text & "' "
    '                End If
    '                Me.dtgRateTableO.DataSource = cls.EnquiryRateTbl(condition, " product_group asc, comm_month asc,acc_group asc, rate_type desc, turnover_from asc, ")
    '                Me.dtgRateTableO_SelectionChanged(Nothing, System.EventArgs.Empty)
    '            End If
    '        End If
    '    End If
    'End Sub

    'Private Sub dtgRateTableO_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If dtgRateTableO.Rows.Count > 0 Then
    '            Me.comboAccNoO.Text = Me.dtgRateTableO.CurrentRow.Cells("acc_noO").Value.ToString.Trim
    '            Me.comboProductO.Text = Me.dtgRateTableO.CurrentRow.Cells("product_groupO").Value.ToString.Trim
    '            Me.txtMonthO.Text = Me.dtgRateTableO.CurrentRow.Cells("comm_monthO").Value.ToString.Trim
    '            Me.txtTOFromO.Text = Me.dtgRateTableO.CurrentRow.Cells("turnover_fromO").Value.ToString.Trim
    '            Me.txtCommRateO.Text = Me.dtgRateTableO.CurrentRow.Cells("comm_rateO").Value.ToString.Trim
    '            'Me.txtACGpO.Text = Me.dtgRateTableO.CurrentRow.Cells("acc_groupO").Value.ToString.Trim
    '            Me.comboAEO.Text = Me.dtgRateTableO.CurrentRow.Cells("ae_noO").Value.ToString.Trim
    '            Select Case Me.dtgRateTableO.CurrentRow.Cells("trade_typeO").Value.ToString.Trim
    '                Case "Normal Trade"
    '                    Me.rbNormalO.Checked = True
    '                    Me.cbConsolidateO.Checked = False
    '                Case "Internet Trade"
    '                    Me.rbInternetO.Checked = True
    '                    Me.cbConsolidateO.Checked = False
    '                Case "Consolidate Trade"
    '                    Me.cbConsolidateO.Checked = True
    '            End Select
    '            Me.cbConsolidateO_CheckedChanged(Nothing, System.EventArgs.Empty)
    '            lFnRefreshTurnoverOpt()
    '        Else
    '            EmptyOptField()
    '        End If
    '    Else
    '        EmptyOptField()
    '    End If
    'End Sub

    'Private Sub btnNewO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ActionFlag = "NewOpt"
    '    OptObjEnable(True)
    '    EmptyOptField()
    '    Me.txtMonthO.Text = Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00")
    '    If Me.rbSrchNormalO.Checked Then
    '        Me.rbNormalO.Checked = True
    '        Me.cbConsolidateO.Checked = False
    '    ElseIf Me.rbSrchInternetO.Checked Then
    '        Me.rbInternetO.Checked = True
    '        Me.cbConsolidateO.Checked = False
    '    Else
    '        Me.cbConsolidateO.Checked = True
    '    End If
    '    Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
    '    If Me.dtgACtblO.Rows.Count > 0 Then
    '        Me.comboAccNoO.Text = Me.dtgACtblO.CurrentRow.Cells("ACNoO").Value.ToString.Trim
    '    Else
    '        Me.comboAccNoO.SelectedIndex = -1
    '    End If
    '    If Me.comboSrchProdO.Text.Length > 0 Then
    '        Me.comboProductO.Text = Me.comboSrchProdO.Text
    '    End If
    '    comboAccNoO_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
    '    Me.comboAccNoO.Focus()
    'End Sub

    'Private Sub btnEditO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.dtgRateTableO.SelectedRows.Count > 0 Then
    '        ActionFlag = "EditOpt"
    '        OptObjEnable(True)
    '        Me.txtTOFromO.Focus()
    '    End If
    'End Sub

    'Private Sub comboAccNoO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboAccNoO.Text.Length > 0 Then
    '            Me.comboAccNoO.Text = Me.comboAccNoO.Text.ToUpper
    '            Dim Acc() As DataRow = AccDT.Select(" acc_no ='" & comboAccNoO.Text & "' and txmonth='" & Me.txtMonthO.Text & "'")
    '            If Acc.Length > 0 Then
    '                Me.txtAccNameO.Text = Acc(0).Item("acc_name").ToString.Trim
    '                'Me.txtACGpO.Text = Acc(0).Item("acc_group_f").ToString.Trim
    '                Me.comboAEO.Text = Acc(0).Item("ae_no").ToString.Trim
    '            Else
    '                Acc = AccDT.Select(" acc_no ='" & comboAccNoO.Text & "' ")
    '                If Acc.Length > 0 Then
    '                    Me.txtAccNameO.Text = Acc(0).Item("acc_name").ToString.Trim
    '                Else
    '                    Me.txtAccNameO.Text = ""
    '                End If
    '                Me.comboAEO.Text = ""
    '                Me.txtAENameO.Text = ""
    '                'Me.txtACGpO.Text = ""
    '            End If
    '        Else
    '            Me.txtAccNameO.Text = ""
    '            Me.comboAEO.Text = ""
    '            Me.txtAENameO.Text = ""
    '            'Me.txtACGpO.Text = ""
    '        End If
    '        Me.comboAEO_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub comboProductO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboProductO.Text.Length > 0 Then
    '            Me.comboProductO.Text = Me.comboProductO.Text.ToUpper
    '            '    Dim Prod() As DataRow = ProductDT.Select(" product_group ='" & Me.comboProductO.Text & "'")
    '            '    Me.txtProductNameO.Text = Prod(0).Item("product_name").ToString.Trim
    '            'Else
    '            '    Me.txtProductNameO.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Sub comboAEO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.comboAEO.Text.Length > 0 Then
    '            Dim AE() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAEO.Text & "'")
    '            If AE.Length > 0 Then
    '                Me.txtAENameO.Text = AE(0).Item("ae_name").ToString.Trim
    '            Else
    '                Me.txtAENameO.Text = ""
    '            End If
    '        Else
    '            Me.txtAENameO.Text = ""
    '        End If
    '    End If
    'End Sub

    'Private Sub OptObjEnable(ByVal blnflag As Boolean)
    '    Me.txtSrchAccO.Enabled = Not blnflag
    '    Me.comboSrchMonthO.Enabled = Not blnflag
    '    Me.comboSrchYrO.Enabled = Not blnflag
    '    Me.comboAEO.Enabled = False
    '    Me.comboSrchProdO.Enabled = Not blnflag
    '    Me.rbNormalO.Enabled = blnflag
    '    Me.rbInternetO.Enabled = blnflag
    '    Me.btnEnquiryO.Enabled = Not blnflag
    '    Me.dtgRateTableO.Enabled = Not blnflag
    '    Me.dtgACtblO.Enabled = Not blnflag
    '    Me.dtgAetblO.Enabled = Not blnflag
    '    Me.txtTOFromO.Enabled = blnflag
    '    Me.txtCommRateO.Enabled = blnflag
    '    'Me.txtACGpO.Enabled = False
    '    Me.txtMonthO.Enabled = False
    '    Me.rbSrchConsolidateO.Enabled = Not blnflag
    '    Me.cbConsolidateO.Enabled = blnflag
    '    Me.txtSrchAeO.Enabled = Not blnflag
    '    Me.btnBDeleteO.Enabled = Not blnflag
    '    Me.btnBEditO.Enabled = Not blnflag
    '    Me.btnBNewO.Enabled = Not blnflag
    '    Me.comboAccNoO.Visible = True
    '    Me.txtAccNameO.Visible = True
    '    Me.lblAccO.Visible = True

    '    Me.rbSrchNormalO.Enabled = Not blnflag
    '    Me.rbSrchInternetO.Enabled = Not blnflag
    '    Me.rbSrchAllO.Enabled = Not blnflag
    '    Me.btnSave.Enabled = blnflag
    '    Me.btnDelO.Enabled = Not blnflag
    '    Me.btnNewO.Enabled = Not blnflag
    '    Me.btnEditO.Enabled = Not blnflag

    '    Select Case ActionFlag
    '        Case "NewOpt", "BAO"
    '            Me.comboAccNoO.Enabled = blnflag
    '            Me.comboProductO.Enabled = blnflag
    '        Case "EditOpt"
    '            Me.comboAccNoO.Enabled = Not blnflag
    '            Me.comboProductO.Enabled = Not blnflag
    '        Case Else
    '            Me.comboAccNoO.Enabled = False
    '            Me.comboProductO.Enabled = False
    '    End Select
    'End Sub


    'Private Sub btnDelO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Me.dtgRateTableO.SelectedRows.Count > 0 Then
    '        If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
    '            Return
    '        End If
    '        Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value).Tables(0)
    '        If dt.Rows.Count <= 0 Then
    '            GSubShowInfo(GFncGetSysMsg(9))
    '            Return
    '        End If
    '        Dim log As String = "'" & GStrloginID & "', GETDATE(), '" & "D" & "', 'CommRateTblFutACC', '" & _
    '                                                           dt.Rows(0).Item("ae_no").ToString.Trim & "', '" & dt.Rows(0).Item("acc_no").ToString.Trim & "', ' ', " & _
    '                                                           "'" & Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value & "'," & _
    '                                                           "'" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog()) & "' "
    '        cls.DelRecord(Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim, log)
    '        If dtgACtblO.RowCount > 0 Then
    '            ac = Me.dtgACtblO.CurrentRow.Cells("ACnoO").Value.ToString.Trim
    '        End If
    '        ObjEnable(False)
    '        Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    '        Me.dtgRateTableO.Focus()
    '    End If
    'End Sub

    'Private Function OptValidateDuplicate() As Boolean
    '    Dim condition As String = " and acc_no='" & Me.comboAccNoO.Text.Trim & "' and ae_no='" & Me.comboAEO.Text.Trim & "' " & _
    '                                                    " and product_group = '" & Me.comboProductO.Text.Trim & "' and turnover_from =" & CDbl(Me.txtTOFromO.Text.Trim) & _
    '                                                    " and comm_month ='" & Me.txtMonthO.Text.Trim & "' and comm_type='" & C_type & "' and rate_type='" & RateType(FutFlag) & "' "
    '    If ActionFlag = "EditOpt" Then
    '        condition += " and rsid<>'" & Me.dtgRateTableO.CurrentRow.Cells("rsidO").Value.ToString.Trim & "' "
    '    End If
    '    Return cls.ValidateDuplicate(condition)

    'End Function

    'Private Sub comboSrchMonthO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.FncLoadProductByMonthO(Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00"))
    '    Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    'End Sub

    'Private Sub comboSrchYrO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.FncLoadProductByMonthO(Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00"))
    '    Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    'End Sub

    'Private Sub rbSrchInternetO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If rbSrchInternetO.Checked = True Then
    '        Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub rbSrchAllO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If rbSrchAllO.Checked = True Then
    '        Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub rbSrchNormalO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If rbSrchNormalO.Checked = True Then
    '        Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub lFnRefreshTurnoverOpt()

    '    Dim comm_month As String = Me.txtMonthO.Text
    '    Dim Rtype As String = RateType(FutFlag)
    '    Dim ae_num As String = Me.comboAEO.Text
    '    Dim acc As String = Me.comboAccNoO.Text
    '    Dim product As String = Me.comboProductO.Text
    '    Dim turnover As String = CDbl(Me.txtTOFromO.Text)
    '    Dim lds As DataSet
    '    Dim turnoverTo As String = ""

    '    lds = cls.lFncGetNextComm(comm_month, Rtype, acc, ae_num, Nothing, Nothing, Nothing, product, C_type, turnover)
    '    If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
    '        Me.LabLot_rangeO.Text = ""
    '    Else
    '        Me.LabLot_rangeO.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,###.00")
    '    End If
    'End Sub

    'Private Sub LabLot_rangeO_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs)
    '    lFnRefreshTurnoverOpt()
    'End Sub

    Private Sub comboSrchProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboSrchProd.SelectedIndexChanged
        If LoadFlag = False Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    'Private Sub comboSrchProdO_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub

    'Private Sub EmptyOptField()
    '    If LoadFlag = False Then
    '        If ActionFlag <> "NewOpt" Then
    '            Me.comboAccNoO.Text = ""
    '            Me.txtAccNameO.Text = ""
    '        End If
    '        Me.comboProductO.Text = ""
    '        Me.txtTOFromO.Text = 0
    '        Me.txtCommRateO.Text = "0.0000"
    '        'Me.txtACGp.Text = ""
    '        Me.txtMonthO.Text = Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00")
    '        Me.comboAEO.Text = ""
    '        Me.rbNormalO.Checked = True
    '    End If
    'End Sub

    Private Sub rbSrchConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchConsolidate.CheckedChanged
        If LoadFlag = False Then
            If Me.rbSrchConsolidate.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub
    'Private Sub rbSrchConsolidateO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If LoadFlag = False Then
    '        If Me.rbSrchConsolidateO.Checked Then
    '            btnSearchO_Click(Nothing, System.EventArgs.Empty)
    '        End If
    '    End If
    'End Sub

    Private Sub cbConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConsolidate.CheckedChanged
        If Me.cbConsolidate.Checked Then
            Me.GroupTradeType.Visible = False
        Else
            GroupTradeType.Visible = True
        End If
    End Sub

    'Private Sub cbConsolidateO_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    If Me.cbConsolidateO.Checked Then
    '        Me.GroupTradeTypeO.Visible = False
    '    Else
    '        GroupTradeTypeO.Visible = True
    '    End If
    'End Sub

    Private Sub FncLoadProductByMonth(ByVal month As String)
        If LoadFlag = False Then
            Dim ProdDr() As DataRow
            Me.comboProduct.Items.Clear()
            Me.comboSrchProd.Items.Clear()
            If month.Length > 0 Then
                ProdDr = ProductDT.Select("txmonth ='" & month & "'", "product_group asc")
                If ProdDr.Length > 0 Then
                    Me.comboSrchProd.Items.Add("")
                    For row As Integer = 0 To ProdDr.Length - 1
                        Me.comboProduct.Items.Add(ProdDr(row).Item("product_group"))
                        Me.comboSrchProd.Items.Add(ProdDr(row).Item("product_group"))
                    Next
                End If
            End If
        End If
    End Sub

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

    Private Sub btnBDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBDelete.Click
        Dim MyTrans As SqlTransaction = Nothing
        Dim accno As String = ""
        Dim aeno As String = ""
        Dim comm_month As String = ""
        Dim lstr As String = ""
        If Me.dtgRateTbl.Rows.Count <= 0 Then
            Return
        End If
        If Me.comboAE.Text.Trim.Length <= 0 Then
            GSubShowInfo(GFncGetSysMsg(31))
            Return
        End If
        lstr = " (" & Me.comboAE.Text.Trim & " - " & Me.txtTOFrom.Text & ") "
        Dim turnover_from As String = Me.txtTOFrom.Text
        Dim comm_type As String = C_type
        Dim rate_type As String = RateType()
        Dim prod As String = Me.comboProduct.Text
        If (GSubShowYNConfirm(GFncGetSysMsg(11) & lstr, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            If GFncCheckCommStatus() Then
                Return
            End If
            Try
                aeno = Me.comboAE.Text
                comm_month = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
                MyTrans = GSCnSqlConn.BeginTransaction
                cls.lFncDeleteBRate(rate_type, comm_type, prod, turnover_from, comm_month, Me.comboAE.Text, MyTrans)
                MyTrans.Commit()
                MyTrans = Nothing
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                GSubShowInfo(GFncGetSysMsg(13))
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try
        End If
    End Sub

    'Private Sub btnBNewO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim rate_type As String = ""

    '    ActionFlag = "BAO"

    '    Me.txtMonthO.Text = Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00")
    '    If (Me.rbSrchInternetO.Checked) Then
    '        Me.rbInternetO.Checked = True
    '        Me.cbConsolidateO.Checked = False
    '    ElseIf Me.rbSrchNormal.Checked Then
    '        Me.rbNormalO.Checked = True
    '        Me.cbConsolidateO.Checked = False
    '    Else
    '        Me.cbConsolidateO.Checked = True
    '    End If
    '    Me.cbConsolidateO_CheckedChanged(Nothing, System.EventArgs.Empty)
    '    Me.txtTOFromO.Text = 0
    '    lFnRefreshTurnoverOpt()
    '    Me.txtCommRateO.Text = 0

    '    OptObjEnable(True)
    '    Me.comboAccNoO.Enabled = True
    '    Me.comboAEO.Enabled = True
    '    Me.comboAccNoO.Visible = False
    '    Me.txtAccNameO.Visible = False
    '    Me.lblAccO.Visible = False
    '    Me.comboAccNoO.Focus()
    'End Sub

    'Private Sub btnBEditO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    ActionFlag = "BEO"

    '    If (Me.dtgRateTableO.Rows.Count > 0) Then
    '        OptObjEnable(True)
    '        Me.comboAccNoO.Visible = False
    '        Me.txtAccNameO.Visible = False
    '        Me.lblAccO.Visible = False
    '        Me.cbConsolidateO.Enabled = False
    '        Me.rbInternetO.Enabled = False
    '        Me.rbNormalO.Enabled = False
    '        Me.txtCommRateO.Focus()
    '        Me.txtTOFromO.Enabled = False
    '    Else
    '        GSubShowInfo("no record to edit")
    '    End If

    'End Sub

    'Private Sub btnBDeleteO_Click(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Dim MyTrans As SqlTransaction = Nothing
    '    Dim accno As String = ""
    '    Dim aeno As String = ""
    '    Dim comm_month As String = ""
    '    Dim lstr As String = ""

    '    If Me.dtgRateTableO.Rows.Count <= 0 Then
    '        Return
    '    End If

    '    If Me.comboAEO.Text.Trim.Length <= 0 Then
    '        GSubShowInfo(GFncGetSysMsg(31))
    '        Return
    '    End If

    '    lstr = " (" & Me.comboAEO.Text.Trim & " - " & Me.txtTOFromO.Text & ") "
    '    Dim turnover_from As String = Me.txtTOFromO.Text
    '    Dim comm_type As String = C_type
    '    Dim rate_type As String = RateType(FutFlag)
    '    Dim prod As String = Me.comboProductO.Text

    '    If (GSubShowYNConfirm(GFncGetSysMsg(11) & lstr, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
    '        Try


    '            aeno = Me.comboAEO.Text
    '            comm_month = Me.comboSrchYrO.Text & Format(Val(Me.comboSrchMonthO.Text), "00")
    '            MyTrans = GSCnSqlConn.BeginTransaction
    '            cls.lFncDeleteBRate(rate_type, comm_type, prod, turnover_from, comm_month, Me.comboAEO.Text, MyTrans)
    '            MyTrans.Commit()
    '            MyTrans = Nothing

    '            Me.btnSearchO_Click(Nothing, System.EventArgs.Empty)

    '            GSubShowInfo(GFncGetSysMsg(13))

    '        Catch ex As Exception
    '            If GSCnSqlConn.State <> ConnectionState.Closed Then
    '                If (MyTrans IsNot Nothing) Then
    '                    MyTrans.Rollback()
    '                End If
    '                GSubWriteErrLog(ex.Message)
    '            End If
    '        End Try
    '    End If

    'End Sub

    Private Sub rbSrchFutOpt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchFutOpt.CheckedChanged
        If Me.rbSrchFutOpt.Checked Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchFutures_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchFutures.CheckedChanged
        If Me.rbSrchFutures.Checked Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchOptions_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchOptions.CheckedChanged
        If Me.rbSrchOptions.Checked Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchFutALL_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchFutALL.CheckedChanged
        If Me.rbSrchFutALL.Checked Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub ChangeConsolid(ByVal acc_no As String, ByVal mth As String)
        If acc_no.Length > 0 Then
            Dim AC() As DataRow = AccDT.Select("acc_no='" & acc_no & "' and txmonth='" & mth & "'")
            If AC.Length > 0 Then
                If AC(0).Item("isConsolid") Then
                    Me.cbConsolidate.Checked = True
                Else
                    Me.cbConsolidate.Checked = False
                    If ActionFlag = "New" Then
                        If Me.rbSrchInternet.Checked Then
                            Me.rbInternet.Checked = True
                        Else
                            Me.rbNormal.Checked = True
                        End If
                    End If
                End If
                Me.cbConsolidate.Enabled = False
            Else
                Me.cbConsolidate.Enabled = True
                Me.cbConsolidate.Checked = False
            End If
        Else
            Me.cbConsolidate.Enabled = True
            Me.cbConsolidate.Checked = False
        End If
        Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
    End Sub

End Class
