Public Class FrmFuturesStatementTHAdj

    Private gCls As New clsFuturesStatementTHAdj
    Dim dgvDecimalPlacesCellStyle As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
    Private gAdjAction As String = ""
    Private gSearchDate As Date = GDteTradeDate
    Private gAdjNoId As String = ""
    Private gAdjTHId As String = ""

    Private Sub FrmFuturesStatementOPAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.dtpTdate.Value = gSearchDate

        'Me.cbxCounterParty.DataSource = gCls.GetCounterParty(True)
        'Me.cbxCounterParty.ValueMember = "misc_desc"

        Me.cbxAdd_CounterParty.DataSource = gCls.GetCounterParty(False)
        Me.cbxAdd_CounterParty.ValueMember = "misc_desc"

        Me.cbxAdd_Product.DataSource = gCls.GetProduct()
        Me.cbxAdd_Product.ValueMember = "product"

        Me.cbxAdd_Period.DataSource = gCls.GetPeriod()
        Me.cbxAdd_Period.ValueMember = "period"

        Me.cbxAdd_MonthlyDaily.Items.Add("D")
        Me.cbxAdd_MonthlyDaily.Items.Add("M")

        Me.cboAdd_CallPut.Items.Add("Call")
        Me.cboAdd_CallPut.Items.Add("Put")

        Me.rbShowAll.Checked = True

        SetObjMaxLength(1000)

        UpdateCbxCounterParty()
        UpdateCbxMonthCode()
        UpdateCbxProduct()
        UpdateCbxPrice()
        UpdateCboCallPut()
        UpdateCboStrike()

        btnSearch_Click(Nothing, Nothing)

        dgvDecimalPlacesCellStyle.Format = modGlobal.DecimalFormat
        Me.dgvQryResult.Columns.Item("qry_price").DefaultCellStyle = dgvDecimalPlacesCellStyle
        Me.dgvQryResult.Columns.Item("strike").DefaultCellStyle = dgvDecimalPlacesCellStyle
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
        Dim lcRemark As String = ""
        If GSubShowCustDelConfirm(GFncGetSysMsg(11), lcRemark, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            DeleteAdjustment(lcRemark)
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
            DeleteAdjustment("")
            tabctrlMain.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.dtpTdate.Value = gSearchDate
        Dim idx As Integer = -1
        Dim dt As DataTable = QueryAdjRecord()

        Dim lcAdjNoId As String = gAdjNoId
        Dim lcAdjTHId As String = gAdjTHId

        Me.dgvQryResult.DataSource = dt

        gAdjNoId = lcAdjNoId
        gAdjTHId = lcAdjTHId

        If gAdjNoId = "" AndAlso gAdjTHId = "" Then
            If dgvQryResult.RowCount > 0 Then
                dgvQryResult.Rows(0).Selected = True
            End If
        ElseIf gAdjNoId <> "" AndAlso gAdjTHId <> "" Then
            Dim lcDrs As DataRow() = dt.Select("adjnoid='" & gAdjNoId & "' and thtid='" & gAdjTHId & "'")
            If dt.Rows.Count > 0 Then
                If lcDrs.Length > 0 Then
                    dgvQryResult.Rows(dt.Rows.IndexOf(lcDrs(0))).Selected = True
                Else
                    dgvQryResult.Rows(0).Selected = True
                End If
            End If
        ElseIf gAdjNoId <> "" Then
            Dim lcDrs As DataRow() = dt.Select("adjnoid='" & gAdjNoId & "'")
            If dt.Rows.Count > 0 Then
                If lcDrs.Length > 0 Then
                    dgvQryResult.Rows(dt.Rows.IndexOf(lcDrs(0))).Selected = True
                Else
                    dgvQryResult.Rows(0).Selected = True
                End If
            End If
        ElseIf gAdjTHId <> "" Then
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
        Me.txtAdj_Buy.Enabled = pEnabled
        Me.txtAdj_Sell.Enabled = pEnabled
        Me.txtAdj_Price.Enabled = pEnabled
        Me.txtAdj_Comm.Enabled = pEnabled
        Me.txtAdj_Clearing.Enabled = pEnabled
        Me.txtAdj_Levy.Enabled = pEnabled
        Me.txtAdj_AdjRemark.Enabled = pEnabled

        Me.lblVoid.Visible = False
        Me.btnAdjDelete.Enabled = Not lblVoid.Visible
        Me.btnAdjUndoDelete.Visible = lblVoid.Visible

        Me.btnAdjModify.Enabled = (Not lblVoid.Visible And Not pEnabled)
        Me.btnAdjSave.Enabled = Not Me.btnAdjModify.Enabled
    End Sub

    Private Sub EnableAddObj(ByVal pEnabled As Boolean)
        Me.dtpAdd_Tdate.Enabled = pEnabled
        Me.txtAdd_Buy.Enabled = pEnabled
        Me.txtAdd_Sell.Enabled = pEnabled
        Me.txtAdd_MonthCode.Enabled = pEnabled
        Me.cbxAdd_Product.Enabled = pEnabled
        Me.txtAdd_Price.Enabled = pEnabled
        'Me.txtAdd_ClosingPrice.Enabled = pEnabled
        'Me.txtAdd_Floating.Enabled = pEnabled
        Me.txtAdd_Comm.Enabled = pEnabled
        Me.txtAdd_Clearing.Enabled = pEnabled
        Me.txtAdd_Levy.Enabled = pEnabled
        Me.cbxAdd_Period.Enabled = pEnabled

        Me.dtpAdd_SettleDate.Enabled = pEnabled
        Me.cbxAdd_MonthlyDaily.Enabled = pEnabled
        Me.txtAdd_ContractSize.Enabled = pEnabled
        Me.cbxAdd_CounterParty.Enabled = pEnabled
        Me.txtAdd_AdjRemark.Enabled = pEnabled
        Me.cboAdd_CallPut.Enabled = pEnabled
        Me.txtAdd_Strike.Enabled = pEnabled

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
        Me.txtAdj_Buy.Text = ""
        Me.txtAdj_Sell.Text = ""
        Me.txtAdj_MonthCode.Text = ""
        Me.cbxAdj_Product.Text = ""
        Me.txtAdj_Price.Text = ""
        Me.cboAdj_CallPut.Text = ""
        Me.cboAdj_Strike.Text = ""
        Me.txtAdj_Comm.Text = ""
        Me.txtAdj_Clearing.Text = ""
        'Me.dtpAdj_SettleDate.Value = GDteTradeDate
        'Me.cbxAdj_MonthlyDaily.Text = ""
        'Me.txtAdj_ContractSize.Text = ""
        'Me.cbxAdj_CounterParty.Text = ""

        Me.txtAdj_Levy.Text = ""

        Me.txtAdj_AdjRemark.Text = ""
        Me.dtpAdj_settleDate.Value = GDteTradeDate
        Me.cbxAdj_monthlyDaily.Text = ""
        Me.cbxAdj_CounterParty.Text = ""
        Me.txtAdj_contractSize.Text = ""

        Me.txtAdj_Buy_Org.Text = ""
        Me.txtAdj_Sell_Org.Text = ""
        Me.txtAdj_Price_Org.Text = ""
        Me.txtAdj_Comm_Org.Text = ""
        Me.txtAdj_Clearing_Org.Text = ""
        Me.txtAdj_Levy_Org.Text = ""
        Me.txtAdj_Buy_Sum.Text = ""
        Me.txtAdj_Sell_Sum.Text = ""
        Me.txtAdj_Price_Sum.Text = ""
        Me.txtAdj_Comm_Sum.Text = ""
        Me.txtAdj_Clearing_Sum.Text = ""
        Me.txtAdj_Levy_Sum.Text = ""

        Me.dtpAdd_Tdate.Value = GDteTradeDate
        Me.txtAdd_Buy.Text = ""
        Me.txtAdd_Sell.Text = ""
        Me.txtAdd_MonthCode.Text = ""
        Me.cbxAdd_Product.Text = ""
        Me.cbxAdd_Period.Text = ""
        Me.txtAdd_Price.Text = ""
        'Me.txtAdd_ClosingPrice.Text = ""
        'Me.txtAdd_Floating.Text = ""

        Me.txtAdd_Comm.text = ""
        Me.txtAdd_Clearing.text = ""
        Me.txtAdd_Levy.text = ""

        Me.dtpAdd_SettleDate.Value = GDteTradeDate
        Me.cbxAdd_MonthlyDaily.Text = ""
        Me.txtAdd_ContractSize.Text = ""
        Me.cbxAdd_CounterParty.Text = ""
        Me.txtAdd_AdjRemark.Text = ""
        Me.cboAdd_CallPut.Text = ""
        Me.txtAdd_Strike.Text = ""

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
        Dim lcTHTId As String = ""
        Dim lcAdjNoId As String = ""
        If Not IsNothing(Me.dgvQryResult.CurrentRow) Then
            lcTHTId = GFncNoNullString(Me.dgvQryResult.Rows(pIdx).Cells("qry_THtId").Value)
            lcAdjNoId = GFncNoNullString(Me.dgvQryResult.Rows(pIdx).Cells("qry_AdjNoId").Value)
        End If
        Dim dt As DataTable = Nothing

        Me.txtAdj_AdjNoId.Text = lcAdjNoId
        Me.txtAdj_THtId.Text = lcTHTId

        If lcAdjNoId <> "" Then
            dt = gCls.GetAdjustedData(lcAdjNoId)
        End If

        If IsNothing(dt) OrElse dt.Rows.Count <= 0 Then
            Me.txtAdd_Buy.Text = ""
            Me.txtAdd_Sell.Text = ""
            Me.txtAdd_Price.Text = ""
            'Me.txtAdd_ClosingPrice.Text = ""
            'Me.txtAdd_Floating.Text = ""

            Me.txtAdd_Comm.text = ""
            Me.txtAdd_Clearing.text = ""
            Me.txtAdd_Levy.text = ""

            Me.txtAdd_AdjRemark.Text = ""
        Else

            Me.txtAdd_Buy.Text = GFncFormatDec(GFncNoNullValue(dt.Rows(0).Item("buy")))
            Me.txtAdd_Sell.Text = GFncFormatDec(GFncNoNullValue(dt.Rows(0).Item("sell")))
            Me.txtAdd_Price.Text = GFncNoNullValue(dt.Rows(0).Item("price")).ToString(modGlobal.DecimalFormat)

            'Me.txtAdd_ClosingPrice.Text = GFncNoNullValue(dt.Rows(0).Item("closing_Price"))
            'Me.txtAdd_Floating.Text = GFncNoNullValue(dt.Rows(0).Item("floating"))
            Me.txtAdd_comm.Text = GFncNoNullValue(dt.Rows(0).Item("comm"))
            Me.txtAdd_Clearing.Text = GFncNoNullValue(dt.Rows(0).Item("clearing"))
            Me.txtAdd_Levy.Text = GFncNoNullValue(dt.Rows(0).Item("levy"))
            Me.cbxAdd_Period.Text = GFncNoNullString(dt.Rows(0).Item("period"))

            Me.txtAdd_AdjRemark.Text = GFncNoNullString(dt.Rows(0).Item("Adj_Remark"))

            Me.dtpAdd_Tdate.Value = GFncNoNullDate(dt.Rows(0).Item("tdate"))
            Me.txtAdd_MonthCode.Text = GFncNoNullString(dt.Rows(0).Item("monthcode"))
            Me.cbxAdd_Product.Text = GFncNoNullString(dt.Rows(0).Item("product"))
            Me.cboAdd_CallPut.Text = GFncNoNullString(dt.Rows(0).Item("callput"))
            Me.txtAdd_Strike.Text = GFncNoNullValue(dt.Rows(0).Item("strike")).ToString(modGlobal.DecimalFormat)

            'Me.dtpAdd_Odate.Value = GFncNoNullDate(dt.Rows(0).Item("odate"))
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

        gAdjNoId = lcAdjNoId
        gAdjTHId = lcTHTId

    End Sub

    Private Sub ShowModificationInfo(ByVal pIdx As Integer)
        Dim lcTHtId As String = ""
        Dim lcAdjNoId As String = ""
        If Not IsNothing(Me.dgvQryResult.CurrentRow) Then
            lcTHtId = GFncNoNullString(Me.dgvQryResult.Rows(pIdx).Cells("qry_THtId").Value)
            lcAdjNoId = GFncNoNullString(Me.dgvQryResult.Rows(pIdx).Cells("qry_AdjNoId").Value)
        End If

        Dim dt_org As DataTable = Nothing
        Dim dt As DataTable = Nothing

        Me.txtAdj_AdjNoId.Text = lcAdjNoId
        Me.txtAdj_THtId.Text = lcTHtId

        If lcTHtId <> "" Then
            dt_org = gCls.GetOrginalData(lcTHtId)
        End If
        If lcAdjNoId <> "" Then
            dt = gCls.GetAdjustedData(lcAdjNoId)
        End If


        If IsNothing(dt_org) OrElse dt_org.Rows.Count <= 0 Then
            Me.txtAdj_Buy_Org.Text = ""
            Me.txtAdj_Sell_Org.Text = ""
            Me.txtAdj_Price_Org.Text = ""
            Me.txtAdj_Comm_Org.Text = ""
            Me.txtAdj_Clearing_Org.Text = ""
        Else
            Me.txtAdj_Buy_Org.Text = GFncFormatDec(GFncNoNullValue(dt_org.Rows(0).Item("buy")))
            Me.txtAdj_Sell_Org.Text = GFncFormatDec(GFncNoNullValue(dt_org.Rows(0).Item("sell")))
            Me.txtAdj_Price_Org.Text = GFncNoNullValue(dt_org.Rows(0).Item("price")).ToString(modGlobal.DecimalFormat)

            Me.txtAdj_Comm_Org.Text = GFncNoNullValue(dt_org.Rows(0).Item("comm"))
            Me.txtAdj_Clearing_Org.Text = GFncNoNullValue(dt_org.Rows(0).Item("clearing"))
            Me.txtAdj_Levy_Org.Text = GFncNoNullValue(dt_org.Rows(0).Item("levy"))

            Me.cbxAdj_Period.Text = GFncNoNullString(dt_org.Rows(0).Item("period"))

            Me.dtpAdj_tDate.Value = GFncNoNullDate(dt_org.Rows(0).Item("tdate"))
            Me.txtAdj_MonthCode.Text = GFncNoNullString(dt_org.Rows(0).Item("monthcode"))
            Me.cbxAdj_Product.Text = GFncNoNullString(dt_org.Rows(0).Item("product"))
            Me.cboAdj_CallPut.Text = GFncNoNullString(dt_org.Rows(0).Item("callput"))
            Me.cboAdj_Strike.Text = GFncNoNullValue(dt_org.Rows(0).Item("strike")).ToString(modGlobal.DecimalFormat)

            'Me.dtpAdj_oDate.Value = GFncNoNullDate(dt_org.Rows(0).Item("odate"))
            Me.dtpAdj_settleDate.Value = GFncNoNullDate(dt_org.Rows(0).Item("settle_date"))
            Me.cbxAdj_monthlyDaily.Text = GFncNoNullString(dt_org.Rows(0).Item("monthly_daily"))
            Me.cbxAdj_CounterParty.Text = GFncNoNullString(dt_org.Rows(0).Item("counterParty"))
            Me.txtAdj_contractSize.Text = GFncNoNullString(dt_org.Rows(0).Item("contract_size"))
        End If

        If IsNothing(dt) OrElse dt.Rows.Count <= 0 Then
            Me.txtAdj_Buy.Text = ""
            Me.txtAdj_Sell.Text = ""
            Me.txtAdj_Price.Text = ""
            Me.txtAdj_Comm.Text = ""
            Me.txtAdj_Clearing.Text = ""
            Me.txtAdj_AdjRemark.Text = ""
        Else

            Me.txtAdj_Buy.Text = GFncFormatDec(GFncNoNullValue(dt.Rows(0).Item("buy")))
            Me.txtAdj_Sell.Text = GFncFormatDec(GFncNoNullValue(dt.Rows(0).Item("sell")))
            Me.txtAdj_Price.Text = GFncNoNullValue(dt.Rows(0).Item("price")).ToString(modGlobal.DecimalFormat)

            Me.txtAdj_Comm.Text = GFncNoNullValue(dt.Rows(0).Item("comm"))
            Me.txtAdj_Clearing.Text = GFncNoNullValue(dt.Rows(0).Item("clearing"))
            Me.txtAdj_Levy_Org.Text = GFncNoNullValue(dt.Rows(0).Item("levy"))

            Me.cbxAdj_Period.Text = GFncNoNullString(dt.Rows(0).Item("period"))

            Me.txtAdj_AdjRemark.Text = GFncNoNullString(dt.Rows(0).Item("adj_Remark"))

            Me.dtpAdj_tDate.Value = GFncNoNullDate(dt.Rows(0).Item("tdate"))
            Me.txtAdj_MonthCode.Text = GFncNoNullString(dt.Rows(0).Item("monthcode"))
            Me.cbxAdj_Product.Text = GFncNoNullString(dt.Rows(0).Item("product"))
            Me.cboAdj_CallPut.Text = GFncNoNullString(dt.Rows(0).Item("callPut"))
            Me.cboAdj_Strike.Text = GFncNoNullValue(dt.Rows(0).Item("strike")).ToString(modGlobal.DecimalFormat)

            'Me.dtpAdj_oDate.Value = GFncNoNullDate(dt.Rows(0).Item("odate"))
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

        gAdjNoId = lcAdjNoId
        gAdjTHId = lcTHtId

        txtAdj_Buy_Validated(Nothing, Nothing)
        txtAdj_Sell_Validated(Nothing, Nothing)
        txtAdj_Price_Validated(Nothing, Nothing)
        txtAdj_Comm_Validated(Nothing, Nothing)
        txtAdj_Clearing_Validated(Nothing, Nothing)
        txtAdj_Levy_Validated(Nothing, Nothing)
    End Sub

    Private Function ValidateInput() As Boolean

        If Me.tabctrlMain.SelectedIndex = 2 Then
            If Me.txtAdd_Buy.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Buy'!")
                Return False
            End If

            If Me.txtAdd_Sell.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Sell'!")
                Return False
            End If

            If Me.txtAdd_Price.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Price'!")
                Return False
            End If

            If Me.txtAdd_MonthCode.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Month Code'!")
                Return False
            End If

            If Me.cbxAdd_Product.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Product'!")
                Return False
            End If

            If Me.cboAdd_CallPut.Text.Trim = "" Then
                GSubShowWarn("No null value of 'CallPut'!")
                Return False
            End If

            If Me.txtAdd_Strike.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Strike'!")
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
            If Me.txtAdj_Buy.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Buy'!")
                Return False
            End If

            If Me.txtAdj_Sell.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Sell'!")
                Return False
            End If


            If Me.txtAdj_Price.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Price'!")
                Return False
            End If

            If Me.txtAdj_MonthCode.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Month Code'!")
                Return False
            End If

            If Me.cbxAdj_Product.Text.Trim = "" Then
                GSubShowWarn("No null value of 'Product'!")
                Return False
            End If

            'If Me.cboAdj_Strike.Text.Trim = "" Then
            '    GSubShowWarn("No null value of 'Strike'!")
            '    Return False
            'End If

            'If Me.cboAdj_CallPut.Text.Trim = "" Then
            '    GSubShowWarn("No null value of 'CallPut'!")
            '    Return False
            'End If
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

            If Me.txtAdj_AdjNoId.Text = "" AndAlso Me.txtAdj_THtId.Text = "" Then
                GSubShowWarn("No record to modify!")
                Return False
            End If
        End If

        Return True

    End Function

    Private Function AddAdjustment() As Boolean

        'Dim lcOpNoId As String = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_opNoId").Value)
        Dim lcTDate As Date = GFncNoNullDate(Me.dtpAdd_Tdate.Value)
        Dim lcBuy As Decimal = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Buy.Text).Replace(",", ""))
        Dim lcSell As Decimal = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Sell.Text).Replace(",", ""))
        Dim lcMonthCode As String = GFncNoNullString(Me.txtAdd_MonthCode.Text)
        Dim lcProduct As String = GFncNoNullString(Me.cbxAdd_Product.Text)
        Dim lcPrice As Decimal = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Price.Text).Replace(",", ""))
        Dim lcComm As String = GFncNoNullString(Me.txtAdd_comm.Text).Replace(",", "")
        Dim lcClearing As String = GFncNoNullString(Me.txtAdd_Clearing.Text).Replace(",", "")

        Dim lcLevy As String = GFncNoNullString(Me.txtAdd_Levy.Text).Replace(",", "")

        Dim lcSettleDate As Date = GFncNoNullDate(Me.dtpAdd_SettleDate.Value)
        Dim lcMonthlyDaily As String = GFncNoNullString(Me.cbxAdd_MonthlyDaily.Text)
        Dim lcContractSize As String = GFncNoNullString(Me.txtAdd_ContractSize.Text).Replace(",", "")
        Dim lcCounterParty As String = GFncNoNullString(Me.cbxAdd_CounterParty.Text)
        Dim lcAdjRemark As String = GFncNoNullString(Me.txtAdd_AdjRemark.Text)
        Dim lcCallPut As String = GFncNoNullString(Me.cboAdd_CallPut.Text)
        If lcCallPut <> "" Then
            lcCallPut = lcCallPut.Substring(0, 1)
        End If
        Dim lcStrike As Decimal = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Strike.Text).Replace(",", ""))
        Dim lcPeriod As String = GFncNoNullString(Me.cbxAdj_Period.Text)

        If gCls.InsertAdjustmentRecord(-1, "A", GFncSqlQuote(lcAdjRemark), lcTDate, lcBuy, _
            lcSell, lcMonthCode, lcProduct, lcPeriod, lcPrice, lcComm, lcClearing, lcLevy, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcCallPut, lcStrike) Then
            gSearchDate = lcTDate
            gAdjNoId = ""
            gAdjTHId = "-1"
            GSubShowWarn(GFncGetSysMsg(8))
        Else
            GSubShowWarn(GFncGetSysMsg(9))
        End If
    End Function

    Private Function ModifyAdjustment() As Boolean

        If gCls.IsDeletedAdjustment(GFncNoNullString(Me.txtAdj_THtId.Text), GFncNoNullString(Me.txtAdj_AdjNoId.Text)) Then
            GSubShowWarn("Record is marked delete!")
            Return False
        End If

        Dim lcAdjNoId As String = ""
        Dim lcTHtId As String = ""
        Dim lcTDate As Date
        Dim lcODate As Date
        Dim lcBuy As Decimal = 0.0
        Dim lcSell As Decimal = 0.0
        Dim lcMonthCode As String = ""
        Dim lcProduct As String = ""
        Dim lcPrice As Decimal = 0.0
        Dim lcComm As String = ""
        Dim lcClearing As String = ""

        Dim lcLevy As String = ""
        Dim lcPeriod As String = ""

        Dim lcSettleDate As Date
        Dim lcMonthlyDaily As String = ""
        Dim lcContractSize As String = ""
        Dim lcCounterParty As String = ""
        Dim lcAdjRemark As String = ""
        Dim lcCallPut As String = ""
        Dim lcStrike As Decimal = 0.0

        If gAdjAction = "A" Then
            lcAdjNoId = GFncNoNullString(Me.txtAdj_AdjNoId.Text)
            lcTHtId = "-1"
            lcTDate = GFncNoNullDate(Me.dtpAdd_Tdate.Value)
            'lcODate = GFncNoNullDate(Me.dtpAdd_Odate.Value)
            lcBuy = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Buy.Text).Replace(",", ""))
            lcSell = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Sell.Text).Replace(",", ""))
            lcMonthCode = GFncNoNullString(Me.txtAdd_MonthCode.Text)
            lcProduct = GFncNoNullString(Me.cbxAdd_Product.Text)
            lcPrice = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Price.Text).Replace(",", ""))
            'lcComm = GFncNoNullValue(GFncNoNullString(Me.txtAdd_ClosingPrice.Text).Replace(",", ""))
            'lcClearing = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Floating.Text).Replace(",", ""))
            lcSettleDate = GFncNoNullDate(Me.dtpAdd_SettleDate.Value)
            lcMonthlyDaily = GFncNoNullString(Me.cbxAdd_MonthlyDaily.Text)
            lcContractSize = GFncNoNullString(Me.txtAdd_ContractSize.Text).Replace(",", "")
            lcCounterParty = GFncNoNullString(Me.cbxAdd_CounterParty.Text)
            lcAdjRemark = GFncNoNullString(Me.txtAdd_AdjRemark.Text)
            lcCallPut = GFncNoNullString(Me.cboAdd_CallPut.Text)
            If lcCallPut <> "" Then
                lcCallPut = lcCallPut.Substring(0, 1)
            End If
            lcStrike = GFncNoNullString(Me.txtAdd_Strike.Text)

            lcComm = GFncNoNullValue(GFncNoNullString(Me.txtAdd_comm.Text).Replace(",", ""))
            lcClearing = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Clearing.Text).Replace(",", ""))
            lcLevy = GFncNoNullString(Me.txtAdd_Levy.Text).Replace(",", "")
            lcPeriod = GFncNoNullString(Me.cbxAdd_Period.Text)
        Else
            lcAdjNoId = GFncNoNullString(Me.txtAdj_AdjNoId.Text)
            lcTHtId = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_THtId").Value)
            lcTDate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_tdate").Value)
            lcODate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_odate").Value)
            lcBuy = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Buy.Text).Replace(",", ""))
            lcSell = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Sell.Text).Replace(",", ""))
            lcMonthCode = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_monthCode").Value)
            lcProduct = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_product").Value)
            lcPrice = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Price.Text).Replace(",", ""))
            'lcComm = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Comm.Text).Replace(",", ""))
            'lcClearing = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Clearing.Text).Replace(",", ""))
            lcSettleDate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_settleDate").Value)
            lcMonthlyDaily = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_monthlyDaily").Value)
            lcContractSize = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_contractSize").Value)
            lcCounterParty = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_counterParty").Value)

            lcComm = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Comm.Text).Replace(",", ""))
            lcClearing = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Clearing.Text).Replace(",", ""))
            lcLevy = GFncNoNullString(Me.txtAdj_Levy.Text).Replace(",", "")

            lcAdjRemark = GFncNoNullString(Me.txtAdj_AdjRemark.Text)
            lcCallPut = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("callput").Value)
            If lcCallPut <> "" Then
                lcCallPut = lcCallPut.Substring(0, 1)
            End If
            lcStrike = GFncNoNullValue(Me.dgvQryResult.CurrentRow.Cells("strike").Value)

            lcPeriod = GFncNoNullString(Me.cbxAdj_Period.Text)


        End If



        Dim lcTargerAdjNoId As String = gCls.CheckExistAdjustment(lcTHtId, lcAdjNoId)

        If lcTargerAdjNoId = "" Then
            If gCls.IsNewAddedAdjustment(Me.txtAdj_AdjNoId.Text) Then
                If gCls.UpdateAdjustmentRecord(lcAdjNoId, "A", GFncSqlQuote(lcAdjRemark), lcTDate, lcBuy, _
                    lcSell, lcMonthCode, lcProduct, lcPeriod, lcPrice, lcComm, lcClearing, lcLevy, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcCallPut, lcStrike) Then
                    gSearchDate = lcTDate
                    gAdjNoId = lcAdjNoId
                    gAdjTHId = lcTHtId
                    GSubShowWarn(GFncGetSysMsg(8))
                Else
                    GSubShowWarn(GFncGetSysMsg(9))
                End If
            Else
                If gCls.InsertAdjustmentRecord(lcTHtId, "M", GFncSqlQuote(lcAdjRemark), lcTDate, lcBuy, _
                    lcSell, lcMonthCode, lcProduct, lcPeriod, lcPrice, lcComm, lcClearing, lcLevy, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcCallPut, lcStrike) Then
                    gSearchDate = lcTDate
                    gAdjNoId = lcAdjNoId
                    gAdjTHId = lcTHtId
                    GSubShowWarn(GFncGetSysMsg(8))
                Else
                    GSubShowWarn(GFncGetSysMsg(9))
                End If
            End If

        Else
            If gCls.UpdateAdjustmentRecord(lcTargerAdjNoId, "M", GFncSqlQuote(lcAdjRemark), lcTDate, lcBuy, _
                lcSell, lcMonthCode, lcProduct, lcPeriod, lcPrice, lcComm, lcClearing, lcLevy, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcCallPut, lcStrike) Then
                gSearchDate = lcTDate
                gAdjNoId = lcTargerAdjNoId
                gAdjTHId = lcTHtId
                GSubShowWarn(GFncGetSysMsg(8))
            Else
                GSubShowWarn(GFncGetSysMsg(9))
            End If
        End If
    End Function

    Private Function DeleteAdjustment(ByVal pRemark As String) As Boolean

        Dim lcTHtId As String = ""
        Dim lcTDate As Date
        Dim lcODate As Date
        Dim lcBuy As Decimal = 0.0
        Dim lcSell As Decimal = 0.0
        Dim lcMonthCode As String = ""
        Dim lcProduct As String = ""
        Dim lcPrice As Decimal = 0.0
        Dim lcComm As String = ""
        Dim lcClearing As String = ""

        Dim lcLevy As String = ""
        Dim lcPeriod As String = ""

        Dim lcSettleDate As Date
        Dim lcMonthlyDaily As String = ""
        Dim lcContractSize As String = ""
        Dim lcCounterParty As String = ""
        Dim lcAdjRemark As String = ""
        Dim lcCallPut As String = ""
        Dim lcStrike As Decimal = 0.0
        If gAdjAction = "A" Then
            lcTHtId = "-1"
            lcTDate = GFncNoNullDate(Me.dtpAdd_Tdate.Value)
            'lcODate = GFncNoNullDate(Me.dtpAdd_Odate.Value)
            lcBuy = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Buy.Text).Replace(",", ""))
            lcSell = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Sell.Text).Replace(",", ""))
            lcMonthCode = GFncNoNullString(Me.txtAdd_MonthCode.Text)
            lcProduct = GFncNoNullString(Me.cbxAdd_Product.Text)
            lcPrice = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Price.Text).Replace(",", ""))
            'lcComm = GFncNoNullValue(GFncNoNullString(Me.txtAdd_ClosingPrice.Text).Replace(",", ""))
            'lcClearing = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Floating.Text).Replace(",", ""))
            lcSettleDate = GFncNoNullDate(Me.dtpAdd_SettleDate.Value)
            lcMonthlyDaily = GFncNoNullString(Me.cbxAdd_MonthlyDaily.Text)
            lcContractSize = GFncNoNullString(Me.txtAdd_ContractSize.Text).Replace(",", "")
            lcCounterParty = GFncNoNullString(Me.cbxAdd_CounterParty.Text)
            'lcAdjRemark = GFncNoNullString(Me.txtAdd_AdjRemark.Text)
            lcAdjRemark = pRemark
            lcCallPut = GFncNoNullString(Me.cboAdd_CallPut.Text)
            If lcCallPut <> "" Then
                lcCallPut = lcCallPut.Substring(0, 1)
            End If
            lcStrike = GFncNoNullString(Me.txtAdd_Strike.Text)

            lcComm = GFncNoNullValue(GFncNoNullString(Me.txtAdd_comm.Text).Replace(",", ""))
            lcClearing = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Clearing.Text).Replace(",", ""))
            lcLevy = GFncNoNullValue(GFncNoNullString(Me.txtAdd_Levy.Text).Replace(",", ""))
            lcPeriod = GFncNoNullString(Me.cbxAdd_Period.Text)
        Else
            lcTHtId = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_THtId").Value)
            lcTDate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_tdate").Value)
            lcODate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_odate").Value)
            lcBuy = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Buy.Text).Replace(",", ""))
            lcSell = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Sell.Text).Replace(",", ""))
            lcMonthCode = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_monthCode").Value)
            lcProduct = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_product").Value)
            lcPrice = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Price.Text).Replace(",", ""))
            'lcComm = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Comm.Text).Replace(",", ""))
            'lcClearing = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Clearing.Text).Replace(",", ""))
            lcSettleDate = GFncNoNullDate(Me.dgvQryResult.CurrentRow.Cells("qry_settleDate").Value)
            lcMonthlyDaily = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_monthlyDaily").Value)
            lcContractSize = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_contractSize").Value)
            lcCounterParty = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("qry_counterParty").Value)

            lcComm = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Comm.Text).Replace(",", ""))
            lcClearing = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Clearing.Text).Replace(",", ""))
            lcLevy = GFncNoNullValue(GFncNoNullString(Me.txtAdj_Levy.Text).Replace(",", ""))

            'lcAdjRemark = GFncNoNullString(Me.txtAdj_AdjRemark.Text)
            lcAdjRemark = pRemark
            lcCallPut = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("callput").Value)
            If lcCallPut <> "" Then
                lcCallPut = lcCallPut.Substring(0, 1)
            End If
            lcStrike = GFncNoNullString(Me.dgvQryResult.CurrentRow.Cells("strike").Value)
            lcPeriod = GFncNoNullString(Me.cbxAdj_Period.Text)
        End If

        If Not gCls.IsNewAddedAdjustment(Me.txtAdj_AdjNoId.Text) Then
            Dim lcTargetAdjNoId As String = gCls.CheckExistAdjustment(lcTHtId, GFncNoNullString(Me.txtAdj_AdjNoId.Text))

            If lcTargetAdjNoId <> "" Then
                If gCls.UpdateAdjustmentRecord(lcTargetAdjNoId, "D", GFncSqlQuote(lcAdjRemark), lcTDate, lcBuy, _
                lcSell, lcMonthCode, lcProduct, lcPeriod, lcPrice, lcComm, lcClearing, lcLevy, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcCallPut, lcStrike) Then
                    gAdjNoId = ""
                    gAdjTHId = ""
                    GSubShowWarn(GFncGetSysMsg(13))
                Else
                    GSubShowWarn(GFncGetSysMsg(14))
                End If
            Else
                If gCls.InsertAdjustmentRecord(lcTHtId, "D", GFncSqlQuote(lcAdjRemark), lcTDate, lcBuy, _
                lcSell, lcMonthCode, lcProduct, lcPeriod, lcPrice, lcComm, lcClearing, lcLevy, lcSettleDate, lcMonthlyDaily, lcContractSize, lcCounterParty, lcCallPut, lcStrike) Then
                    gAdjNoId = ""
                    gAdjTHId = ""
                    GSubShowWarn(GFncGetSysMsg(13))
                Else
                    GSubShowWarn(GFncGetSysMsg(14))
                End If
            End If

        Else
            If gCls.DeleteAdjustmentRecord(Me.txtAdj_AdjNoId.Text) Then
                gAdjNoId = ""
                gAdjTHId = ""
                GSubShowWarn(GFncGetSysMsg(13))
            Else
                GSubShowWarn(GFncGetSysMsg(14))
            End If
        End If

    End Function

    Private Function QueryAdjRecord() As DataTable
        'If Me.rbAdjustedOnly.Checked Then
        '    Return gCls.QueryAdjRecord(Me.dtpTdate.Value, Me.cbxCounterParty.Text, clsFuturesStatementOPAdj.SearchMode.Adjusted)
        'ElseIf Me.rbShowAll.Checked Then
        '    Return gCls.QueryAdjRecord(Me.dtpTdate.Value, Me.cbxCounterParty.Text, clsFuturesStatementOPAdj.SearchMode.All)
        'ElseIf Me.rbShowNormal.Checked Then
        '    Return gCls.QueryAdjRecord(Me.dtpTdate.Value, Me.cbxCounterParty.Text, clsFuturesStatementOPAdj.SearchMode.Normal)
        'End If
        'Return Nothing

        If Me.rbAdjustedOnly.Checked Then
            Return gCls.QueryAdjRecord(Me.dtpTdate.Value, Me.cbxCounterParty.Text, Me.cbxMonthCode.Text, Me.cbxProduct.Text, Me.cbxPrice.Text, clsFuturesStatementOPAdj.SearchMode.Adjusted, Me.cboCallPut.Text, Me.cboStrike.Text)
        ElseIf Me.rbShowAll.Checked Then
            Return gCls.QueryAdjRecord(Me.dtpTdate.Value, Me.cbxCounterParty.Text, Me.cbxMonthCode.Text, Me.cbxProduct.Text, Me.cbxPrice.Text, clsFuturesStatementOPAdj.SearchMode.All, Me.cboCallPut.Text, Me.cboStrike.Text)
        ElseIf Me.rbShowNormal.Checked Then
            Return gCls.QueryAdjRecord(Me.dtpTdate.Value, Me.cbxCounterParty.Text, Me.cbxMonthCode.Text, Me.cbxProduct.Text, Me.cbxPrice.Text, clsFuturesStatementOPAdj.SearchMode.Normal, Me.cboCallPut.Text, Me.cboStrike.Text)
        End If
        Return Nothing
    End Function

    Private Sub txtAdj_Buy_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdj_Buy.Validated
        If txtAdj_Buy.Text.Trim = "" Then
            txtAdj_Buy.Text = 0.0
        End If

        'If CDec(txtAdj_Buy.Text) > 999 Then
        '    GSubShowWarn("Cannot larger than 999")
        '    txtAdj_Buy.Text = 0.0
        '    txtAdj_Buy.Focus()
        'End If

        If txtAdj_Buy_Org.Text.Trim = "" Then
            txtAdj_Buy_Org.Text = 0.0
        End If
        Me.txtAdj_Buy_Sum.Text = GFncNoNullValue(Me.txtAdj_Buy.Text) + GFncNoNullValue(txtAdj_Buy_Org.Text)
    End Sub

    Private Sub txtAdj_Sell_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdj_Sell.Validated
        If txtAdj_Sell.Text.Trim = "" Then
            txtAdj_Sell.Text = 0.0
        End If

        'If CDec(txtAdj_Sell.Text) > 999 Then
        '    GSubShowWarn("Cannot larger than 999")
        '    txtAdj_Sell.Text = 0.0
        '    txtAdj_Sell.Focus()
        'End If

        If txtAdj_Sell_Org.Text.Trim = "" Then
            txtAdj_Sell_Org.Text = 0.0
        End If
        Me.txtAdj_Sell_Sum.Text = GFncNoNullValue(Me.txtAdj_Sell.Text) + GFncNoNullValue(txtAdj_Sell_Org.Text)
    End Sub

    Private Sub txtAdj_Price_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdj_Price.Validated
        If txtAdj_Price.Text.Trim = "" Then
            txtAdj_Price.Text = 0.0
        End If
        If txtAdj_Price_Org.Text.Trim = "" Then
            txtAdj_Price_Org.Text = 0.0
        End If
        Me.txtAdj_Price.Text = GFncNoNullValue(Me.txtAdj_Price.Text).ToString(modGlobal.DecimalFormat)
        Me.txtAdj_Price_Sum.Text = (GFncNoNullValue(Me.txtAdj_Price.Text) + GFncNoNullValue(txtAdj_Price_Org.Text)).ToString(modGlobal.DecimalFormat)
    End Sub

    Private Sub txtAdj_Comm_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdj_Comm.Validated
        If txtAdj_Comm.Text.Trim = "" Then
            txtAdj_Comm.Text = 0.0
        End If
        If txtAdj_Comm_Org.Text.Trim = "" Then
            txtAdj_Comm_Org.Text = 0.0
        End If
        Me.txtAdj_Comm_Sum.Text = GFncNoNullValue(Me.txtAdj_Comm.Text) + GFncNoNullValue(txtAdj_Comm_Org.Text)
    End Sub

    Private Sub txtAdj_Clearing_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdj_Clearing.Validated
        If txtAdj_Clearing.Text.Trim = "" Then
            txtAdj_Clearing.Text = 0.0
        End If
        If txtAdj_Clearing_Org.Text.Trim = "" Then
            txtAdj_Clearing_Org.Text = 0.0
        End If
        Me.txtAdj_Clearing_Sum.Text = GFncNoNullValue(Me.txtAdj_Clearing.Text) + GFncNoNullValue(txtAdj_Clearing_Org.Text)
    End Sub

    Private Sub txtAdj_Levy_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdj_Levy.Validated
        If txtAdj_Levy.Text.Trim = "" Then
            txtAdj_Levy.Text = 0.0
        End If
        If txtAdj_Levy_Org.Text.Trim = "" Then
            txtAdj_Levy_Org.Text = 0.0
        End If
        Me.txtAdj_Levy_Sum.Text = GFncNoNullValue(Me.txtAdj_Levy.Text) + GFncNoNullValue(txtAdj_Levy_Org.Text)
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

    Private Sub txtAdd_Buy_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdd_Buy.Validated
        'If txtAdd_Buy.Text.Trim = "" Then
        '    txtAdd_Buy.Text = 0.0
        'End If

        'If CDec(txtAdd_Buy.Text) > 999 Then
        '    GSubShowWarn("Cannot larger than 999")
        '    txtAdd_Buy.Text = 0.0
        '    txtAdd_Buy.Focus()
        'End If
    End Sub

    Private Sub txtAdd_Sell_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAdd_Sell.Validated
        'If txtAdd_Sell.Text.Trim = "" Then
        '    txtAdd_Sell.Text = 0.0
        'End If

        'If CDec(txtAdd_Sell.Text) > 999 Then
        '    GSubShowWarn("Cannot larger than 999")
        '    txtAdd_Sell.Text = 0.0
        '    txtAdd_Sell.Focus()
        'End If
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
        UpdateCbxCounterParty()
        UpdateCbxMonthCode()
        UpdateCbxProduct()
        UpdateCbxPrice()
        UpdateCboCallPut()
        UpdateCboStrike()
    End Sub

    Private Sub UpdateCbxCounterParty()
        Dim dt As DataTable = gCls.GetQryCounterParty(gSearchDate)
        Me.cbxCounterParty.Items.Clear()
        Me.cbxCounterParty.Items.Add("-- ALL --")
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.cbxCounterParty.Items.Add(GFncNoNullString(dt.Rows(i).Item("counterparty")))
            Next
        End If
        Me.cbxCounterParty.Text = "-- ALL --"
    End Sub

    Private Sub UpdateCbxMonthCode()
        Dim dt As DataTable = gCls.GetQryMonthCode(gSearchDate, Me.cbxCounterParty.Text)
        Me.cbxMonthCode.Items.Clear()
        Me.cbxMonthCode.Items.Add("-- ALL --")
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.cbxMonthCode.Items.Add(GFncNoNullString(dt.Rows(i).Item("monthcode")))
            Next
        End If
        Me.cbxMonthCode.Text = "-- ALL --"
    End Sub

    Private Sub UpdateCbxProduct()
        Dim dt As DataTable = gCls.GetQryProduct(gSearchDate, Me.cbxCounterParty.Text, Me.cbxMonthCode.Text)
        Me.cbxProduct.Items.Clear()
        Me.cbxProduct.Items.Add("-- ALL --")
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.cbxProduct.Items.Add(GFncNoNullString(dt.Rows(i).Item("product")))
            Next
        End If
        Me.cbxProduct.Text = "-- ALL --"
    End Sub

    Private Sub UpdateCbxPrice()
        Dim dt As DataTable = gCls.GetQryPrice(gSearchDate, Me.cbxCounterParty.Text, Me.cbxMonthCode.Text, Me.cbxProduct.Text)
        Me.cbxPrice.Items.Clear()
        Me.cbxPrice.Items.Add("-- ALL --")
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.cbxPrice.Items.Add(GFncNoNullValue(dt.Rows(i).Item("price")).ToString(modGlobal.DecimalFormat))
            Next
        End If
        Me.cbxPrice.Text = "-- ALL --"
    End Sub
    Private Sub UpdateCboCallPut()
        Dim dt As DataTable = gCls.GetQryCallPut(gSearchDate, Me.cbxCounterParty.Text, Me.cbxMonthCode.Text, Me.cbxProduct.Text)
        Me.cboCallPut.Items.Clear()
        Me.cboCallPut.Items.Add("-- ALL --")
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.cboCallPut.Items.Add(GFncNoNullString(dt.Rows(i).Item("callput")))
            Next
        End If
        Me.cboCallPut.Text = "-- ALL --"
    End Sub
    Private Sub UpdateCboStrike()
        Dim dt As DataTable = gCls.GetQryStrike(gSearchDate, Me.cbxCounterParty.Text, Me.cbxMonthCode.Text, Me.cbxProduct.Text)
        Me.cboStrike.Items.Clear()
        Me.cboStrike.Items.Add("-- ALL --")
        If dt.Rows.Count > 0 Then
            For i As Integer = 0 To dt.Rows.Count - 1
                Me.cboStrike.Items.Add(GFncNoNullValue(dt.Rows(i).Item("strike")).ToString(modGlobal.DecimalFormat))
            Next
        End If
        Me.cboStrike.Text = "-- ALL --"
    End Sub

    Private Sub cbxCounterParty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxCounterParty.SelectedIndexChanged
        UpdateCbxMonthCode()
        UpdateCbxProduct()
        UpdateCbxPrice()
        UpdateCboStrike()
        UpdateCboCallPut()
    End Sub

    Private Sub cbxMonthCode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxMonthCode.SelectedIndexChanged
        UpdateCbxProduct()
        UpdateCbxPrice()
        UpdateCboStrike()
        UpdateCboCallPut()
    End Sub

    Private Sub cbxProduct_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxProduct.SelectedIndexChanged
        UpdateCbxPrice()
        UpdateCboStrike()
        UpdateCboCallPut()
    End Sub

End Class
