Public Class FrmFuturesStatementLHAdj

    Private gCls As New clsFuturesStatementLHAdj
    Private gAdjAction As String = ""
    Private gSearchDate As Date = GDteTradeDate
    Private gAdjNoId As String = ""
    Private gAdjNId As String = ""

    Private Sub FrmFuturesStatementCPAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpTdate.Value = gSearchDate

        Me.cbxCounterParty.DataSource = gCls.GetCounterParty(True)
        Me.cbxCounterParty.ValueMember = "misc_desc"

        Me.cbxAdd_CounterParty.DataSource = gCls.GetCounterParty(False)
        Me.cbxAdd_CounterParty.ValueMember = "misc_desc"

        Me.cbxAdd_MonthlyDaily.Items.Add("D")
        Me.cbxAdd_MonthlyDaily.Items.Add("M")

        Me.rbShowAll.Checked = True

        SetObjMaxLength(1000)

        btnSearch_Click(Nothing, Nothing)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnAddBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBack.Click
        ClearFieldData()
        tabctrlMain.SelectedIndex = 0
    End Sub

    Private Sub btnAdjBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjBack.Click
        ClearFieldData()
        tabctrlMain.SelectedIndex = 0
    End Sub

    Private Sub btnAdjModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjModify.Click
        EnableAdjObj(True)
    End Sub

    Private Sub btnAdjSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjSave.Click
        If Not ValidateInput() Then
            Return
        End If
        If GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            ModifyAdjustment()
            tabctrlMain.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnAdjDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjDelete.Click
        If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            DeleteAdjustment()
            tabctrlMain.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        ClearFieldData()
        gAdjAction = ""
        EnableAddObj(True)
    End Sub

    Private Sub btnAddModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddModify.Click
        EnableAddObj(True)
    End Sub

    Private Sub btnAddSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSave.Click
        If Not ValidateInput() Then
            Return
        End If

        'Dim lcLiqId As String = gCls.GetLiqId(GFncNoNullString(Me.txtAdd_Product.Text))

        'If lcLiqId = "" AndAlso GFncNoNullString(Me.txtAdd_Product.Text) <> "" Then
        '    If gCls.CreateNewLiqHeader(GFncNoNullString(Me.txtAdd_Product.Text), GFncNoNullDate(Me.dtpAdd_Tdate.Value), _
        '                              GFncNoNullString(Me.txtAdd_MonthCode.Text), GFncNoNullDate(Me.dtpAdj_settleDate.Value), _
        '                               GFncNoNullString(Me.cbxAdd_MonthlyDaily.Text), GFncNoNullString(Me.cbxAdd_CounterParty.Text)) Then
        '        lcLiqId = gCls.GetLiqId(GFncNoNullString(Me.txtAdd_Product.Text))
        '    Else
        '        GSubShowWarn("Failed to insert new Liq Header!")
        '        Return
        '    End If
        'End If

        If gAdjAction = "A" Then
            If GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                ModifyAdjustment()
                tabctrlMain.SelectedIndex = 0
            End If
        Else
            If GSubShowYNConfirm(GFncGetSysMsg(47), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
                AddAdjustment()
                tabctrlMain.SelectedIndex = 0
            End If
        End If
    End Sub

    Private Sub btnAddDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDelete.Click
        If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            DeleteAdjustment()
            tabctrlMain.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.dtpTdate.Value = gSearchDate
        Dim idx As Integer = -1
        Dim dt As DataTable = QueryAdjRecord()

        Me.dgvQryResult.DataSource = dt
        If gAdjNoId = "" AndAlso gAdjNId = "" Then
            If dgvQryResult.RowCount > 0 Then
                dgvQryResult.Rows(0).Selected = True
            End If
        ElseIf gAdjNoId <> "" AndAlso gAdjNId <> "" Then
            Dim lcDrs As DataRow() = dt.Select("adjnoid=" & gAdjNoId & " and lhNid=" & gAdjNId)
            If lcDrs.Length > 0 Then
                dgvQryResult.Rows(dt.Rows.IndexOf(lcDrs(0))).Selected = True
            Else
                dgvQryResult.Rows(0).Selected = True
            End If
        ElseIf gAdjNoId <> "" Then
            Dim lcDrs As DataRow() = dt.Select("adjnoid=" & gAdjNoId)
            If lcDrs.Length > 0 Then
                dgvQryResult.Rows(dt.Rows.IndexOf(lcDrs(0))).Selected = True
            Else
                dgvQryResult.Rows(0).Selected = True
            End If
        ElseIf gAdjNId <> "" Then
            'Dim lcDrs As DataRow() = dt.Select("opnoid=" & gAdjOpId)
            'If dgvQryResult.Rows.Count - 2 > 0 Then
            '    dgvQryResult.Rows(dgvQryResult.Rows.Count - 2).Selected = True
            'Else
            '    dgvQryResult.Rows(0).Selected = True
            'End If
        End If
    End Sub

    Private Sub dgvQryResult_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvQryResult.SelectionChanged
        Try
            gAdjAction = GFncNoNullString(dgvQryResult.SelectedRows(0).Cells("qry_adjAction").Value)
            ClearFieldData()
            If gAdjAction <> "A" Then
                ShowModificationInfo(dgvQryResult.SelectedRows(0).Index)
            Else
                ShowAddInfo(dgvQryResult.SelectedRows(0).Index)
            End If

        Catch ex As Exception
            ShowModificationInfo(0)
        End Try
    End Sub

    Private Sub dgvQryResult_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvQryResult.CellDoubleClick
        ClearFieldData()
        If gAdjAction <> "A" Then
            tabctrlMain.SelectedIndex = 1
            ShowModificationInfo(e.RowIndex)
        Else
            tabctrlMain.SelectedIndex = 2
            ShowAddInfo(e.RowIndex)
        End If
    End Sub

    Private Sub tabctrlMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabctrlMain.SelectedIndexChanged
        ClearFieldData()
        If tabctrlMain.SelectedIndex = 0 Then
            EnableAdjObj(False)
            EnableAddObj(False)
            btnSearch_Click(Nothing, Nothing)
        ElseIf tabctrlMain.SelectedIndex = 1 Then
            If gAdjAction = "A" Then
                tabctrlMain.SelectedIndex = 0
            Else
                EnableAdjObj(False)
                EnableAddObj(False)
                If dgvQryResult.SelectedRows.Count > 0 Then
                    ShowModificationInfo(dgvQryResult.SelectedRows(0).Index)
                End If
            End If
        ElseIf tabctrlMain.SelectedIndex = 2 Then
            EnableAdjObj(False)
            EnableAddObj(False)
            If dgvQryResult.SelectedRows.Count > 0 Then
                ShowAddInfo(dgvQryResult.SelectedRows(0).Index)
            End If
        End If
    End Sub

    Private Sub EnableAdjObj(ByVal pEnabled As Boolean)
        Me.txtAdj_PL.Enabled = pEnabled
        Me.txtAdj_AdjRemark.Enabled = pEnabled

        Me.lblVoid.Visible = False
        Me.btnAdjDelete.Enabled = Not lblVoid.Visible
        Me.btnAdjUndoDelete.Visible = lblVoid.Visible

        Me.btnAdjModify.Enabled = (Not lblVoid.Visible And Not pEnabled)
        Me.btnAdjSave.Enabled = Not Me.btnAdjModify.Enabled
    End Sub

    Private Sub EnableAddObj(ByVal pEnabled As Boolean)
        Me.dtpAdd_Tdate.Enabled = pEnabled
        Me.txtAdd_MonthCode.Enabled = pEnabled
        Me.txtAdd_Product.Enabled = pEnabled
        Me.txtAdd_PL.Enabled = pEnabled
        Me.dtpAdd_SettleDate.Enabled = pEnabled
        Me.cbxAdd_MonthlyDaily.Enabled = pEnabled
        Me.txtAdd_ContractSize.Enabled = pEnabled
        Me.cbxAdd_CounterParty.Enabled = pEnabled
        Me.txtAdd_AdjRemark.Enabled = pEnabled

        Me.btnAdd.Enabled = Not pEnabled
        Me.btnAddSave.Enabled = pEnabled
        Me.btnAddModify.Enabled = Not pEnabled
        Me.btnAddDelete.Enabled = Not pEnabled
    End Sub

    Private Sub SetObjMaxLength(ByVal pMaxLength As Integer)
        Me.txtAdd_MonthCode.MaxLength = 4
        Me.txtAdd_AdjRemark.MaxLength = pMaxLength
        Me.txtAdj_AdjRemark.MaxLength = pMaxLength
    End Sub

    Private Sub ClearFieldData()
        Me.dtpAdj_tDate.Value = GDteTradeDate
        'Me.dtpAdj_Odate.Value = GDteTradeDate
        Me.txtAdj_MonthCode.Text = ""
        Me.cbxAdj_Product.Text = ""
        Me.txtAdj_PL.Text = ""
        'Me.dtpAdj_SettleDate.Value = GDteTradeDate
        'Me.cbxAdj_MonthlyDaily.Text = ""
        'Me.txtAdj_ContractSize.Text = ""
        'Me.cbxAdj_CounterParty.Text = ""
        Me.txtAdj_AdjRemark.Text = ""
        Me.dtpAdj_settleDate.Value = GDteTradeDate
        Me.cbxAdj_monthlyDaily.Text = ""
        Me.cbxAdj_CounterParty.Text = ""
        Me.txtAdj_contractSize.Text = ""

        Me.dtpAdd_Tdate.Value = GDteTradeDate
        Me.txtAdd_MonthCode.Text = ""
        Me.txtAdd_Product.Text = ""
        Me.txtAdd_PL.Text = ""
        Me.dtpAdd_SettleDate.Value = GDteTradeDate
        Me.cbxAdd_MonthlyDaily.Text = ""
        Me.txtAdd_ContractSize.Text = ""
        Me.cbxAdd_CounterParty.Text = ""
        Me.txtAdd_AdjRemark.Text = ""

        Me.txtAdd_LstUpdUser.Text = ""
        Me.dtpAdd_LstUpdTime.Value = GFncNoNullDate(Nothing)
        Me.txtAdj_LstUpdUser.Text = ""
        Me.dtpAdj_LstUpdTime.Value = GFncNoNullDate(Nothing)
        Me.lblAdd_LstUpdUser.Visible = False
        Me.lblAdd_LstUpdTime.Visible = False
        Me.txtAdd_LstUpdUser.Visible = False
        Me.dtpAdd_LstUpdTime.Visible = False
        Me.lblAdj_LstUpdTime.Visible = False
        Me.lblAdj_LstUpdUser.Visible = False
        Me.txtAdj_LstUpdUser.Visible = False
        Me.dtpAdj_LstUpdTime.Visible = False
    End Sub

    Private Sub ShowAddInfo(ByVal pIdx As Integer)
        Dim lcLhNId As String = ""
        Dim lcAdjNoId As String = ""
        If Not IsNothing(Me.dgvQryResult.CurrentRow) Then
            lcLhNId = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_lhnId").Value)
            lcAdjNoId = GFncNoNullString(Me.dgvQryResult.Rows(pIdx).Cells("qry_AdjNoId").Value)
        End If
        Dim dt As DataTable = Nothing

        Me.txtAdj_AdjNoId.Text = lcAdjNoId
        Me.txtAdj_LhNId.Text = lcLhNId

        If lcAdjNoId <> "" Then
            dt = gCls.GetAdjustedData(lcAdjNoId)
        End If

        If IsNothing(dt) OrElse dt.Rows.Count <= 0 Then
            Me.txtAdd_PL.Text = ""
            Me.txtAdd_AdjRemark.Text = ""
        Else

            Me.txtAdd_PL.Text = GFncNoNullValue(dt.Rows(0).Item("pl"))
            Me.txtAdd_AdjRemark.Text = GFncNoNullString(dt.Rows(0).Item("Adj_Remark"))
            Me.dtpAdd_Tdate.Value = GFncNoNullDate(dt.Rows(0).Item("tdate"))
            Me.txtAdd_MonthCode.Text = GFncNoNullString(dt.Rows(0).Item("monthcode"))
            Me.txtAdd_Product.Text = GFncNoNullString(dt.Rows(0).Item("product"))
            Me.dtpAdd_SettleDate.Value = GFncNoNullDate(dt.Rows(0).Item("settle_date"))
            Me.cbxAdd_MonthlyDaily.Text = GFncNoNullString(dt.Rows(0).Item("monthly_daily"))
            Me.cbxAdd_CounterParty.Text = GFncNoNullString(dt.Rows(0).Item("counterParty"))
            Me.txtAdd_ContractSize.Text = GFncNoNullString(dt.Rows(0).Item("contract_size"))

            Me.txtAdd_LstUpdUser.Text = GFncNoNullString(dt.Rows(0).Item("lupduser"))
            Me.dtpAdd_LstUpdTime.Value = GFncNoNullDate(dt.Rows(0).Item("lupddate"))
            If Me.txtAdd_LstUpdUser.Text <> "" Then
                Me.lblAdd_LstUpdUser.Visible = True
                Me.lblAdd_LstUpdTime.Visible = True
                Me.txtAdd_LstUpdUser.Visible = True
                Me.dtpAdd_LstUpdTime.Visible = True
            Else
                Me.lblAdd_LstUpdUser.Visible = False
                Me.lblAdd_LstUpdTime.Visible = False
                Me.txtAdd_LstUpdUser.Visible = False
                Me.dtpAdd_LstUpdTime.Visible = False
            End If
        End If
    End Sub

    Private Sub ShowModificationInfo(ByVal pIdx As Integer)
        Dim lcLhNId As String = ""
        Dim lcAdjNoId As String = ""
        If Not IsNothing(Me.dgvQryResult.CurrentRow) Then
            lcLhNId = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_lhnId").Value)
            lcAdjNoId = GFncNoNullString(Me.dgvQryResult.Rows(pIdx).Cells("qry_AdjNoId").Value)
        End If

        Dim dt_org As DataTable = Nothing
        Dim dt As DataTable = Nothing

        Me.txtAdj_AdjNoId.Text = lcAdjNoId
        Me.txtAdj_LhNId.Text = lcLhNId

        If lcLhNId <> "" Then
            dt_org = gCls.GetOrginalData(lcLhNId)
        End If
        If lcAdjNoId <> "" Then
            dt = gCls.GetAdjustedData(lcAdjNoId)
        End If


        If IsNothing(dt_org) OrElse dt_org.Rows.Count <= 0 Then

            Me.txtAdj_PL_Org.Text = ""
        Else
            Me.txtAdj_PL_Org.Text = GFncNoNullValue(dt_org.Rows(0).Item("pl"))

            Me.dtpAdj_tDate.Value = GFncNoNullDate(dt_org.Rows(0).Item("tdate"))
            Me.txtAdj_MonthCode.Text = GFncNoNullString(dt_org.Rows(0).Item("monthcode"))
            Me.cbxAdj_Product.Text = GFncNoNullString(dt_org.Rows(0).Item("product"))

            Me.dtpAdj_settleDate.Value = GFncNoNullDate(dt_org.Rows(0).Item("settle_date"))
            Me.cbxAdj_monthlyDaily.Text = GFncNoNullString(dt_org.Rows(0).Item("monthly_daily"))
            Me.cbxAdj_CounterParty.Text = GFncNoNullString(dt_org.Rows(0).Item("counterParty"))
            Me.txtAdj_contractSize.Text = GFncNoNullString(dt_org.Rows(0).Item("contract_size"))
        End If

        If IsNothing(dt) OrElse dt.Rows.Count <= 0 Then
            Me.txtAdj_PL.Text = ""
            Me.txtAdj_AdjRemark.Text = ""
        Else
            Me.txtAdj_PL.Text = GFncNoNullValue(dt.Rows(0).Item("pl"))
            Me.txtAdj_AdjRemark.Text = GFncNoNullString(dt.Rows(0).Item("adj_Remark"))
            Me.dtpAdj_tDate.Value = GFncNoNullDate(dt.Rows(0).Item("tdate"))
            Me.txtAdj_MonthCode.Text = GFncNoNullString(dt.Rows(0).Item("monthcode"))
            Me.cbxAdj_Product.Text = GFncNoNullString(dt.Rows(0).Item("product"))
            Me.dtpAdj_settleDate.Value = GFncNoNullDate(dt.Rows(0).Item("settle_date"))
            Me.cbxAdj_monthlyDaily.Text = GFncNoNullString(dt.Rows(0).Item("monthly_daily"))
            Me.cbxAdj_CounterParty.Text = GFncNoNullString(dt.Rows(0).Item("counterParty"))
            Me.txtAdj_contractSize.Text = GFncNoNullString(dt.Rows(0).Item("contract_size"))

            Me.txtAdj_LstUpdUser.Text = GFncNoNullString(dt.Rows(0).Item("lupduser"))
            Me.dtpAdj_LstUpdTime.Value = GFncNoNullDate(dt.Rows(0).Item("lupddate"))

            If Me.txtAdj_LstUpdUser.Text <> "" Then
                Me.lblAdj_LstUpdTime.Visible = True
                Me.lblAdj_LstUpdUser.Visible = True
                Me.txtAdj_LstUpdUser.Visible = True
                Me.dtpAdj_LstUpdTime.Visible = True
            Else
                Me.lblAdj_LstUpdTime.Visible = False
                Me.lblAdj_LstUpdUser.Visible = False
                Me.txtAdj_LstUpdUser.Visible = False
                Me.dtpAdj_LstUpdTime.Visible = False
            End If
        End If

        If Me.dgvQryResult.Rows.Count > 0 Then
            If GFncNoNullString(Me.dgvQryResult.Rows(pIdx).Cells("qry_adjAction").Value) = "D" Then
                Me.lblVoid.Visible = True
            Else
                Me.lblVoid.Visible = False
            End If
            Me.btnAdjDelete.Enabled = Not lblVoid.Visible
            'Me.btnAdjSave.Enabled = Not lblVoid.Visible
            Me.btnAdjModify.Enabled = (Not lblVoid.Visible And Me.btnAdjModify.Enabled)
            Me.btnAdjUndoDelete.Visible = lblVoid.Visible
        End If

        txtAdj_PL_Validated(Nothing, Nothing)
    End Sub

    Private Function ValidateInput() As Boolean

        If Me.tabctrlMain.SelectedIndex = 2 Then
            If Me.txtAdd_MonthCode.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Month Code'!")
                Return False
            End If

            If Me.txtAdd_Product.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Product'!")
                Return False
            End If

            'If Not IsNumeric(Me.txtAdd_Buy.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Buy'!")
            '    Return False
            'End If

            'If Not IsNumeric(Me.txtAdd_Sell.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Sell'!")
            '    Return False
            'End If

            'If Not IsNumeric(Me.txtAdd_Price.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Price'!")
            '    Return False
            'End If

            'If Not IsNumeric(Me.txtAdd_ClosingPrice.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Closing Price'!")
            '    Return False
            'End If

            'If Not IsNumeric(Me.txtAdd_Floating.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Floating'!")
            '    Return False
            'End If

            'If Not IsNumeric(Me.txtAdd_ContractSize.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Contract Size'!")
            '    Return False
            'End If
        Else
            If Me.txtAdj_MonthCode.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Month Code'!")
                Return False
            End If

            If Me.cbxAdj_Product.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Product'!")
                Return False
            End If

            'If Not IsNumeric(Me.txtAdj_Buy.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Buy'!")
            '    Return False
            'End If

            'If Not IsNumeric(Me.txtAdj_Sell.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Buy'!")
            '    Return False
            'End If

            'If Not IsNumeric(Me.txtAdj_Price.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Sell'!")
            '    Return False
            'End If

            'If Not IsNumeric(Me.txtAdj_ClosingPrice.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Closing Price'!")
            '    Return False
            'End If

            'If Not IsNumeric(Me.txtAdj_Floating.Text.Trim) Then
            '    GSubShowWarn("Wrong value of 'Floating'!")
            '    Return False
            'End If

            If Me.txtAdj_AdjNoId.Text = "" AndAlso Me.txtAdj_LhNId.Text = "" Then
                GSubShowWarn("No record to modify!")
                Return False
            End If
        End If

        Return True

    End Function

    Private Function AddAdjustment() As Boolean

        'Dim lcOpNoId As String = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_opNoId").Value)
        Dim lcTDate As Date = GFncNoNullDate(Me.dtpAdd_Tdate.Value)
        Dim lcMonthCode As String = GFncNoNullString(Me.txtAdd_MonthCode.Text)
        Dim lcProduct As String = GFncNoNullString(Me.txtAdd_Product.Text)
        Dim lcPL As String = GFncNoNullString(Me.txtAdd_PL.Text).Replace(",", "")
        Dim lcSettleDate As Date = GFncNoNullDate(Me.dtpAdd_SettleDate.Value)
        Dim lcMonthlyDaily As String = GFncNoNullString(Me.cbxAdd_MonthlyDaily.Text)
        Dim lcContractSize As String = GFncNoNullString(Me.txtAdd_ContractSize.Text).Replace(",", "")
        Dim lcCounterParty As String = GFncNoNullString(Me.cbxAdd_CounterParty.Text)
        Dim lcAdjRemark As String = GFncNoNullString(Me.txtAdd_AdjRemark.Text)
        Dim lcCallPut As String = ""
        Dim lcStrike As Decimal = 0.0

        'lcCallPut = GFncNoNullString(Me.cboAdd_CallPut.Text)
        'If lcCallPut <> "" Then
        '    lcCallPut = lcCallPut.Substring(0, 1)
        'End If
        'lcStrike = GFncNoNullValue(Me.txtAdd_Strike.Text)

        If gCls.InsertAdjustmentRecord(-1, "A", lcAdjRemark, lcTDate, _
            lcMonthCode, lcProduct, lcPL, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcStrike, lcCallPut) Then
            gSearchDate = lcTDate
            gAdjNoId = ""
            gAdjNId = "-1"
            GSubShowWarn(GFncGetSysMsg(8))
        Else
            GSubShowWarn(GFncGetSysMsg(9))
        End If

    End Function

    Private Function ModifyAdjustment() As Boolean

        If gCls.IsDeletedAdjustment(GFncNoNullString(Me.txtAdj_LhNId.Text), GFncNoNullString(Me.txtAdj_AdjNoId.Text)) Then
            GSubShowWarn("Record is marked delete!")
            Return False
        End If

        Dim lcAdjNoId As String = ""
        Dim lcLhNId As String = ""
        Dim lcTDate As Date
        Dim lcBuy As Decimal = 0.0
        Dim lcSell As Decimal = 0.0
        Dim lcMonthCode As String = ""
        Dim lcProduct As String = ""
        Dim lcPrice As Decimal = 0.0
        Dim lcLiqPrice As String = ""
        Dim lcPL As String = ""
        Dim lcSettleDate As Date
        Dim lcMonthlyDaily As String = ""
        Dim lcContractSize As String = ""
        Dim lcCounterParty As String = ""
        Dim lcAdjRemark As String = ""

        Dim lcLiqId As String = ""
        Dim lcCallPut As String = ""
        Dim lcStrike As Decimal = 0.0

        If gAdjAction = "A" Then
            lcAdjNoId = GFncNoNullString(Me.txtAdj_AdjNoId.Text)
            lcLhNId = "-1"
            lcTDate = GFncNoNullDate(Me.dtpAdd_Tdate.Value)
            lcMonthCode = GFncNoNullString(Me.txtAdd_MonthCode.Text)
            lcProduct = GFncNoNullString(Me.txtAdd_Product.Text)
            lcPL = GFncNoNullValue(GFncNoNullString(Me.txtAdd_PL.Text).Replace(",", ""))
            lcSettleDate = GFncNoNullDate(Me.dtpAdd_SettleDate.Value)
            lcMonthlyDaily = GFncNoNullString(Me.cbxAdd_MonthlyDaily.Text)
            lcContractSize = GFncNoNullString(Me.txtAdd_ContractSize.Text)
            lcCounterParty = GFncNoNullString(Me.cbxAdd_CounterParty.Text)
            lcAdjRemark = GFncNoNullString(Me.txtAdd_AdjRemark.Text)
        Else
            lcAdjNoId = GFncNoNullString(Me.txtAdj_AdjNoId.Text)
            lcLhNId = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_lhNId").Value)
            lcTDate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_tdate").Value)
            lcMonthCode = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_monthCode").Value)
            lcProduct = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_product").Value)
            lcPL = GFncNoNullValue(GFncNoNullString(Me.txtAdj_PL.Text).Replace(",", ""))
            lcSettleDate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_settleDate").Value)
            lcMonthlyDaily = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_monthlyDaily").Value)
            lcContractSize = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_contractSize").Value)
            lcCounterParty = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_counterParty").Value)
            lcAdjRemark = GFncNoNullString(Me.txtAdj_AdjRemark.Text)
        End If



        Dim lcTargerAdjNoId As String = gCls.CheckExistAdjustment(lcLhNId, lcAdjNoId)

        If lcTargerAdjNoId = "" Then
            If gCls.IsNewAddedAdjustment(Me.txtAdj_AdjNoId.Text) Then
                If gCls.UpdateAdjustmentRecord(lcAdjNoId, "A", lcAdjRemark, lcTDate, _
                    lcMonthCode, lcProduct, lcPL, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcStrike, lcCallPut) Then
                    gSearchDate = lcTDate
                    gAdjNoId = lcAdjNoId
                    gAdjNId = lcLhNId
                    GSubShowWarn(GFncGetSysMsg(8))
                Else
                    GSubShowWarn(GFncGetSysMsg(9))
                End If
            Else
                If gCls.InsertAdjustmentRecord(lcLhNId, "M", lcAdjRemark, lcTDate, _
                    lcMonthCode, lcProduct, lcPL, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcStrike, lcCallPut) Then
                    gSearchDate = lcTDate
                    gAdjNoId = lcAdjNoId
                    gAdjNId = lcLhNId
                    GSubShowWarn(GFncGetSysMsg(8))
                Else
                    GSubShowWarn(GFncGetSysMsg(9))
                End If
            End If

        Else
            If gCls.UpdateAdjustmentRecord(lcTargerAdjNoId, "M", lcAdjRemark, lcTDate, _
                 lcMonthCode, lcProduct, lcPL, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcStrike, lcCallPut) Then
                gSearchDate = lcTDate
                gAdjNoId = lcTargerAdjNoId
                gAdjNId = lcLhNId
                GSubShowWarn(GFncGetSysMsg(8))
            Else
                GSubShowWarn(GFncGetSysMsg(9))
            End If
        End If
    End Function

    Private Function DeleteAdjustment() As Boolean

        Dim lcLhNId As String = ""
        Dim lcTDate As Date
        Dim lcBuy As Decimal = 0.0
        Dim lcSell As Decimal = 0.0
        Dim lcMonthCode As String = ""
        Dim lcProduct As String = ""
        Dim lcPrice As Decimal = 0.0
        Dim lcLiqPrice As String = ""
        Dim lcPL As String = ""
        Dim lcSettleDate As Date
        Dim lcMonthlyDaily As String = ""
        Dim lcContractSize As String = ""
        Dim lcCounterParty As String = ""
        Dim lcAdjRemark As String = ""
        Dim lcCallPut As String = ""
        Dim lcStrike As Decimal = 0.0
        Dim lcLiqId As String = ""

        If gAdjAction = "A" Then
            lcLhNId = "-1"
            lcTDate = GFncNoNullDate(Me.dtpAdd_Tdate.Value)
            lcMonthCode = GFncNoNullString(Me.txtAdd_MonthCode.Text)
            lcProduct = GFncNoNullString(Me.txtAdd_Product.Text)
            lcPL = GFncNoNullValue(GFncNoNullString(Me.txtAdd_PL.Text).Replace(",", ""))
            lcSettleDate = GFncNoNullDate(Me.dtpAdd_SettleDate.Value)
            lcMonthlyDaily = GFncNoNullString(Me.cbxAdd_MonthlyDaily.Text)
            lcContractSize = GFncNoNullString(Me.txtAdd_ContractSize.Text)
            lcCounterParty = GFncNoNullString(Me.cbxAdd_CounterParty.Text)
            lcAdjRemark = GFncNoNullString(Me.txtAdd_AdjRemark.Text)
        Else
            lcLhNId = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_lhNId").Value)
            lcTDate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_tdate").Value)
            lcMonthCode = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_monthCode").Value)
            lcProduct = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_product").Value)
            lcPL = GFncNoNullValue(GFncNoNullString(Me.txtAdj_PL.Text).Replace(",", ""))
            lcSettleDate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_settleDate").Value)
            lcMonthlyDaily = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_monthlyDaily").Value)
            lcContractSize = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_contractSize").Value)
            lcCounterParty = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_counterParty").Value)
            lcAdjRemark = GFncNoNullString(Me.txtAdj_AdjRemark.Text)

        End If

        If Not gCls.IsNewAddedAdjustment(Me.txtAdj_AdjNoId.Text) Then
            Dim lcTargetAdjNoId As String = gCls.CheckExistAdjustment(lcLhNId, GFncNoNullString(Me.txtAdj_AdjNoId.Text))

            If lcTargetAdjNoId <> "" Then
                If gCls.UpdateAdjustmentRecord(lcTargetAdjNoId, "D", "", lcTDate, _
                 lcMonthCode, lcProduct, lcPL, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcStrike, lcCallPut) Then
                    gAdjNoId = ""
                    gAdjNId = ""
                    GSubShowWarn(GFncGetSysMsg(13))
                Else
                    GSubShowWarn(GFncGetSysMsg(14))
                End If
            Else
                If gCls.InsertAdjustmentRecord(lcLhNId, "D", "", lcTDate, _
                 lcMonthCode, lcProduct, lcPL, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcStrike, lcCallPut) Then
                    gAdjNoId = ""
                    gAdjNId = ""
                    GSubShowWarn(GFncGetSysMsg(13))
                Else
                    GSubShowWarn(GFncGetSysMsg(14))
                End If
            End If

        Else
            If gCls.DeleteAdjustmentRecord(Me.txtAdj_AdjNoId.Text) Then
                gAdjNoId = ""
                gAdjNId = ""
                GSubShowWarn(GFncGetSysMsg(13))
            Else
                GSubShowWarn(GFncGetSysMsg(14))
            End If
        End If

    End Function

    Private Function QueryAdjRecord() As DataTable
        If Me.rbAdjustedOnly.Checked Then
            Return gCls.QueryAdjRecord(Me.dtpTdate.Value, Me.cbxCounterParty.Text, clsFuturesStatementOPAdj.SearchMode.Adjusted)
        ElseIf Me.rbShowAll.Checked Then
            Return gCls.QueryAdjRecord(Me.dtpTdate.Value, Me.cbxCounterParty.Text, clsFuturesStatementOPAdj.SearchMode.All)
        ElseIf Me.rbShowNormal.Checked Then
            Return gCls.QueryAdjRecord(Me.dtpTdate.Value, Me.cbxCounterParty.Text, clsFuturesStatementOPAdj.SearchMode.Normal)
        End If
        Return Nothing
    End Function

    Private Sub txtAdj_PL_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdj_PL.Validated
        If txtAdj_PL.Text.Trim = "" Then
            txtAdj_PL.Text = 0.0
        End If
        If txtAdj_PL_Org.Text.Trim = "" Then
            txtAdj_PL_Org.Text = 0.0
        End If
        Me.txtAdj_PL_Sum.Text = GFncNoNullValue(Me.txtAdj_PL.Text) + GFncNoNullValue(txtAdj_PL_Org.Text)
    End Sub

    Private Sub btnAdjUndoDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdjUndoDelete.Click
        If GSubShowYNConfirm("Undo Delete?", MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            If gCls.DeleteAdjustmentRecord(Me.txtAdj_AdjNoId.Text) Then
                GSubShowWarn("Undo Successful")
            Else
                GSubShowWarn("Undo Fail")
            End If
        End If
        tabctrlMain.SelectedIndex = 0
    End Sub

    Private Sub txtAdd_ContractSize_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdd_ContractSize.Validated
        'If txtAdd_ContractSize.Text.Trim = "" Then
        '    txtAdd_ContractSize.Text = 0.0
        'End If

        'If CDec(txtAdd_ContractSize.Text) > 999 Then
        '    GSubShowWarn("Cannot larger than 999")
        '    txtAdd_ContractSize.Text = 0.0
        '    txtAdd_ContractSize.Focus()
        'End If
    End Sub

    Private Sub dtpTdate_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpTdate.Validated
        gSearchDate = dtpTdate.Value
    End Sub

End Class
