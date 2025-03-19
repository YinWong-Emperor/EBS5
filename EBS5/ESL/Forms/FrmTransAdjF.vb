Imports System.Data.SqlClient

Public Class FrmTransAdjF

    Private LoadFlag As Boolean
    Private stateFlag As String
    Private cls As New ClsTransAdjF
    Dim ProductDT As DataTable
    Dim myObj As String

    Private Sub FrmTradeAdjF_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        LoadFlag = True
        stateFlag = ""
        Dim txmonth As String = GfncGetMonth()
        Dim month As String = Val(txmonth.Substring(4, 2))
        Dim year As String = txmonth.Substring(0, 4)
        For i As Integer = 1 To 12
            Me.CboSMonth.Items.Add(i)
            Me.CboMMonth.Items.Add(i)
        Next
        For j As Integer = year - 5 To year + 5
            Me.CboSYr.Items.Add(j)
            Me.cboMYr.Items.Add(j)
        Next
        'cls.getLastTradeMonth(Me.CboSYr.Text, Me.CboSMonth.Text)
        Me.CboSMonth.Text = month
        Me.CboSYr.Text = year
        Me.CboMMonth.Text = Me.CboSMonth.Text
        Me.cboMYr.Text = Me.CboSYr.Text
        Me.CboMCallPut.Items.Add("")
        Me.CboMCallPut.Items.Add("Put")
        Me.CboMCallPut.Items.Add("Call")
        Me.CboMCcy.Items.Add("")
        Me.CboMCcy.Items.Add("HKD")
        GetProduct()
        GetAeAcCode()
        GetCCY()
        GetTradeType()
        btnEnquiry_Click(Nothing, System.EventArgs.Empty)
        LoadFlag = False
    End Sub

    Private Sub btnEnquiry_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEnquiry.Click

        Dim condition As String = ""
        Dim Acccondition As String = ""
        If Me.CboSYr.Text.Length > 0 And Me.CboSMonth.Text.Length > 0 Then
            condition += " and txmonth='" & Me.CboSYr.Text.Trim & Format(CInt(Me.CboSMonth.Text.Trim), "00") & "'"
        End If
        If Me.txtSAccno.Text.Length > 0 Then
            condition += " and accno ='" & Me.txtSAccno.Text & "'"
        End If
        If Me.txtSAeno.Text.Length > 0 Then
            condition += " and aeno ='" & Me.txtSAeno.Text & "'"
        End If
        Dim state As String = ""
        If Me.RBAdj.Checked = True Then
            state = "Adjusted"
        End If
        If Me.RBAll.Checked = True Then
            state = "All"
        End If
        If Me.RBDel.Checked = True Then
            state = "Deleted"

        End If
        dtgTrade.DataSource = cls.Search(condition, state)
        lsubGoRecord()
        'dtgTrade.DataSource = GFncRtnDS(GSCnSqlConn, query).Tables(0)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled = False Then
            Me.Close()
        Else
            stateFlag = ""
            btnSave.Enabled = False
            ObjEnable(False)
            dtgTrade_SelectionChanged(Nothing, System.EventArgs.Empty)
            lsubGoRecord()
        End If
    End Sub

    Private Sub dtgTrade_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgTrade.SelectionChanged
        If dtgTrade.SelectedRows.Count > 0 Then
            Me.CboMMonth.Text = Val(Me.dtgTrade.CurrentRow.Cells("dtgtxMonth").Value.ToString.Trim.Substring(4, 2))
            Me.cboMYr.Text = Me.dtgTrade.CurrentRow.Cells("dtgtxMonth").Value.ToString.Trim.Substring(0, 4)
            Me.CboMAccNo.Text = GFncNoNullString(Me.dtgTrade.CurrentRow.Cells("dtgaccno").Value).ToString.Trim
            Me.CboMAeno.Text = GFncNoNullString(Me.dtgTrade.CurrentRow.Cells("dtgaeno").Value).ToString.Trim
            CboMAeno_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            CboMAccNo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            Me.txtMDay_mm.Text = GFncNoNullValue(Me.dtgTrade.CurrentRow.Cells("dtgday_mm").Value)
            Me.txtMNight_mm.Text = GFncNoNullValue(Me.dtgTrade.CurrentRow.Cells("dtgnight_mm").Value)
            Me.cboMCommod.Text = GFncNoNullString(Me.dtgTrade.CurrentRow.Cells("dtgcommod").Value).Trim
            Me.CboMCallPut.Text = GFncNoNullString(Me.dtgTrade.CurrentRow.Cells("dtgCall_Put").Value).Trim
            Me.txtTotComm.Text = GFncNoNullValue(Me.dtgTrade.CurrentRow.Cells("dtgCommission_mm").Value)
            Me.txtDayComm.Text = GFncNoNullValue(Me.dtgTrade.CurrentRow.Cells("day_comm").Value)
            Me.txtNightComm.Text = GFncNoNullValue(Me.dtgTrade.CurrentRow.Cells("night_comm").Value)
            Me.CboMCcy.Text = GFncNoNullString(Me.dtgTrade.CurrentRow.Cells("dtgCCy").Value).Trim
            Me.txtMMarket.Text = GFncNoNullString(Me.dtgTrade.CurrentRow.Cells("dtgmarketname").Value).Trim
            Me.cboTradeType.Text = GFncNoNullString(Me.dtgTrade.CurrentRow.Cells("dtgTradeType").Value).Trim
            ObjEnable(False)
            Me.btnModify.Enabled = True
            Me.btnDel.Enabled = True
            If GetAdjCode(GFncNoNullString(dtgTrade.CurrentRow.Cells("dtgadjaction").Value)) = "D" Then
                Me.btnDel.Text = "Restore"
                Me.btnAdd.Enabled = False
                Me.btnModify.Enabled = False
            Else
                Me.btnDel.Text = "Delete"
            End If
        Else
            EmptyField()
            ObjEnable(False)
            Me.btnModify.Enabled = False
            Me.btnDel.Enabled = False
        End If
    End Sub

    Private Sub CboSYr_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboSYr.SelectedIndexChanged
        If Not LoadFlag Then
            If CboSYr.Text.Length > 0 And CboSMonth.Text.Length > 0 Then
                btnEnquiry_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub CboSMonth_SelectedValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboSMonth.SelectedIndexChanged
        If Not LoadFlag Then
            If CboSYr.Text.Length > 0 And CboSMonth.Text.Length > 0 Then
                btnEnquiry_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub EmptyField()
        Me.CboMMonth.Text = Me.CboSMonth.Text
        Me.cboMYr.Text = Me.CboSYr.Text
        Me.CboMAccNo.Text = ""
        Me.CboMAeno.Text = ""
        Me.cboMCommod.Text = ""
        Me.txtMDay_mm.Text = 0
        Me.txtMNight_mm.Text = 0
        Me.txtDayComm.Text = "0.0000"
        Me.txtNightComm.Text = "0.0000"
        Me.txtTotComm.Text = "0.0000"
        Me.cboMCommod.SelectedIndex = -1
        Me.txtMProductName.Text = ""
        Me.CboMCallPut.Text = ""
        Me.txtMAcName.Text = ""
        Me.TxtMAeName.Text = ""
        Me.CboMAccNo.Text = ""
        Me.CboMAeno.Text = ""
        Me.CboMCcy.Text = "HKD"
        Me.txtMMarket.Text = ""
    End Sub

    'Private Sub getLastTradeMonth(ByRef inYr As String, ByRef inMonth As String)
    '    Dim sql As String = "select max(a.txmonth)as txmonth from (select max(txmonth) as txmonth from comm_adj_f where adj_action <>'D' union select max(txmonth) as txmonth from comm_trade_f) a "
    '    Dim monthYr As DataTable = GFncRtnDS(GSCnSqlConn, sql).Tables(0)
    '    If monthYr.Rows.Count > 0 Then
    '        inYr = monthYr.Rows(0).Item(0).ToString.Substring(0, 4)
    '        inMonth = Val(monthYr.Rows(0).Item(0).ToString.Substring(4, 2))
    '    Else
    '        inYr = Now.Year
    '        inMonth = Now.Month
    '    End If

    'End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        stateFlag = "ADD"
        EmptyField()
        ObjEnable(True)
        cboMYr.Focus()
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        stateFlag = "MODIFY"
        ObjEnable(True)
        CboMAeno.Focus()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim condition As String = ""
        Dim log As String = ""
        If Not cls.ValidAeCode(Me.CboMAeno.Text.Trim) Then
            GSubShowError(GFncGetSysMsg(31))
            Return
        End If
        If Not cls.ValidAcCode(Me.CboMAccNo.Text.Trim) Then
            GSubShowError(GFncGetSysMsg(5))
            Return
        End If
        If Not cls.ValidProduct(Me.cboMCommod.Text.Trim) Then
            GSubShowError(GFncGetSysMsg(51))
            Return
        End If
        Select Case stateFlag
            Case "ADD"
                If GSubShowYNConfirm(GFncGetSysMsg(40), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                Dim NewOID As Integer = 0
                Dim callPut As Integer
                If Me.CboMCallPut.Visible Then
                    callPut = GetCallPut(Me.CboMCallPut.Text)
                Else
                    callPut = 0
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                'Dim RID As Integer = cls.GetNewRecordID()
                condition = "'" & Me.cboMYr.Text & Format(CInt(Me.CboMMonth.Text), "00") & "', '" & Me.CboMAeno.Text & "', '" & _
                    Me.TxtMAeName.Text & "', '" & Me.CboMAccNo.Text & "', '" & Me.txtMAcName.Text & "' , ' ' , '" & _
                    Me.cboMCommod.Text & "', '', '" & callPut & "', 0, '', 0, 0, 0, 0, 0, 0, " & CDbl(Me.txtTotComm.Text) & ", " & _
                    CDbl(Me.txtDayComm.Text) & ", " & CDbl(Me.txtNightComm.Text) & ", 0, 0, " & Me.txtMDay_mm.Text & ", " & _
                    Me.txtMNight_mm.Text & ", 0, '" & Me.txtMMarket.Text.Trim & "', '" & Me.CboMCcy.Text & "', getdate() , '" & _
                    GStrloginID & "', " & NewOID & ", 'A', '" & cls.GetTypeCode(Me.cboTradeType.Text) & "'"
                log = "'" & GStrloginID & "', " & "GETDATE(), 'A', 'TradeAdjF', '" & Me.CboMAeno.Text & "', '" & _
                    Me.CboMAccNo.Text & "', '', '" & Me.cboMYr.Text & Format(CInt(Me.CboMMonth.Text), "00") & "', '" & _
                    GFncSqlQuote(fncGenLog()) & "', "
                myObj = cls.AddNewRecord(condition, log)
                stateFlag = ""
                ObjEnable(False)
                btnEnquiry_Click(Nothing, System.EventArgs.Empty)
            Case "MODIFY"
                'cls.GetNewVal(dtgTrade.CurrentRow.Cells("dtgOid").Value, GFncNoNullString(dtgTrade.CurrentRow.Cells("dtgAdjaction").Value))
                If GSubShowYNConfirm(GFncGetSysMsg(39), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                '-------------------------------------------
                Dim newestValDT As DataTable = cls.GetNewestVal(Me.dtgTrade.CurrentRow.Cells("dtgoid").Value.ToString.Trim, Me.dtgTrade.CurrentRow.Cells("dtgRecordID").Value)
                If newestValDT.Rows.Count <= 0 Then
                    GSubShowError(GFncGetSysMsg(9))
                    Return
                End If
                If newestValDT.Rows(0).Item("adj_action") = "Deleted" Then 'return when it is already deleted
                    GSubShowError(GFncGetSysMsg(9))
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                '------------------------------------------
                Dim Action As String = newestValDT.Rows(0).Item("recordID")
                'If Action = "Adjusted" Or Action = "New" Then
                If Action > 0 And newestValDT.Rows(0).Item("adj_action") <> "Deleted" Then
                    condition = "txmonth = '" & Me.cboMYr.Text.Trim & Format(CInt(Me.CboMMonth.Text), "00") & "' , Aeno = '" & _
                        Me.CboMAeno.Text.Trim & "', Aename = '" & Me.TxtMAeName.Text & "', Accname1 = '" & Me.txtMAcName.Text & _
                        "', accno = '" & Me.CboMAccNo.Text.Trim & "', commod = '" & Me.cboMCommod.Text.Trim & "', day_mm = " & _
                        Me.txtMDay_mm.Text & ", night_mm = " & Me.txtMNight_mm.Text.Trim & ", tradetype = '" & _
                        cls.GetTypeCode(Me.cboTradeType.Text) & "', day_commission = " & CDbl(Me.txtDayComm.Text) & _
                        ", night_commission = " & CDbl(Me.txtNightComm.Text) & ", commission_mm = " & CDbl(Me.txtTotComm.Text)
                    log = "'" & GStrloginID & "', GETDATE(), 'M', 'TradeAdjF', '" & _
                        newestValDT.Rows(0).Item("aeno").ToString.Trim & "', '" & _
                        newestValDT.Rows(0).Item("accno").ToString.Trim & "', '', '" & _
                        newestValDT.Rows(0).Item("recordID").ToString.Trim & "', '" & _
                        newestValDT.Rows(0).Item("txmonth").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog()) & "'"
                    myObj = dtgTrade.CurrentRow.Cells("dtgrecordID").Value.ToString.Trim
                    cls.ModifyRecord(condition, dtgTrade.CurrentRow.Cells("dtgrecordID").Value, Action, log)
                End If
                If Action <= 0 Then
                    condition = "'" & Me.cboMYr.Text & Format(CInt(Me.CboMMonth.Text), "00") & "', '" & Me.CboMAeno.Text & _
                        "', '" & Me.TxtMAeName.Text.Trim & "', '" & Me.CboMAccNo.Text & "', '" & Me.txtMAcName.Text.Trim & _
                        "' , '' , '" & Me.cboMCommod.Text & "', '" & newestValDT.Rows(0).Item("mth").ToString.Trim & "', '" & _
                        GetCallPut(newestValDT.Rows(0).Item("call_put")) & "', " & _
                        newestValDT.Rows(0).Item("strike").ToString.Trim & ", '" & _
                        newestValDT.Rows(0).Item("s_price_str").ToString.Trim & "', " & newestValDT.Rows(0).Item("day_dd") & _
                        ", " & newestValDT.Rows(0).Item("night_dd") & ", " & newestValDT.Rows(0).Item("tg_dd") & ", " & _
                        newestValDT.Rows(0).Item("commission_dd") & ", " & newestValDT.Rows(0).Item("exchange_fee_dd") & ", " & _
                        newestValDT.Rows(0).Item("ae_rebate_dd") & ", " & CDbl(Me.txtTotComm.Text) & ", " & _
                        CDbl(Me.txtDayComm.Text) & ", " & CDbl(Me.txtNightComm.Text) & ", " & _
                        newestValDT.Rows(0).Item("exchange_fee_mm") & ", " & newestValDT.Rows(0).Item("ae_rebate_mm") & ", " & _
                        Me.txtMDay_mm.Text & ", " & Me.txtMNight_mm.Text & ", " & newestValDT.Rows(0).Item("tg_mm") & ", '" & _
                        newestValDT.Rows(0).Item("marketname").ToString.Trim & "', '" & _
                        newestValDT.Rows(0).Item("ccy").ToString.Trim & "',  getdate() , '" & GStrloginID & "', " & _
                        newestValDT.Rows(0).Item("oid").ToString.Trim & ", 'M','" & cls.GetTypeCode(Me.cboTradeType.Text) & "'"
                    log = "'" & GStrloginID & "', " & "GETDATE(), " & "'M', 'TradeAdjF', '" & _
                        newestValDT.Rows(0).Item("aeno").ToString.Trim & "', '" & _
                        newestValDT.Rows(0).Item("accno").ToString.Trim & "', '', '" & _
                        newestValDT.Rows(0).Item("txmonth").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog()) & "', "
                    myObj = cls.AddNewRecord(condition, log)
                End If
                stateFlag = ""
                ObjEnable(False)
                btnEnquiry_Click(Nothing, System.EventArgs.Empty)
        End Select
        Me.dtgTrade.Focus()
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        Dim log As String = ""
        Select Case Me.btnDel.Text
            Case "Delete"
                If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                '-------------------------------------------
                Dim newestValDT As DataTable = cls.GetNewestVal(Me.dtgTrade.CurrentRow.Cells("dtgoid").Value.ToString.Trim, Me.dtgTrade.CurrentRow.Cells("dtgRecordID").Value)
                If newestValDT.Rows.Count <= 0 Then
                    GSubShowError(GFncGetSysMsg(9))
                    Return
                End If
                If newestValDT.Rows(0).Item("adj_action") = "Deleted" Then 'return when it is already deleted
                    GSubShowError(GFncGetSysMsg(9))
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                '------------------------------------------
                Dim Action As String = newestValDT.Rows(0).Item("recordID")
                If newestValDT.Rows(0).Item("adj_action") <> "Deleted" Then
                    If Action > 0 Then
                        log = "'" & GStrloginID & "', " & "GETDATE(), " & "'D', " & "'TradeAdjF', '" & _
                            newestValDT.Rows(0).Item("aeno").ToString.Trim & "', '" & _
                            newestValDT.Rows(0).Item("accno").ToString.Trim & "', '', '" & newestValDT.Rows(0).Item("recordID") & _
                            "', '" & newestValDT.Rows(0).Item("txmonth").ToString.Trim & "', '" & _
                            GFncSqlQuote(GfncOneFieldLog("Adjustment action", GetAdjCode(newestValDT.Rows(0).Item("adj_action").ToString.Trim), "D")) & "'"
                        If newestValDT.Rows(0).Item("adj_action") = "New" Then
                            cls.PhysicalDel(newestValDT.Rows(0).Item("recordID"), log)
                        Else
                            If newestValDT.Rows(0).Item("adj_action") = "Adjusted" Then
                                cls.LabeledDel(newestValDT.Rows(0).Item("recordID"), log)
                            End If
                        End If
                    Else
                        'Dim RID As Integer = cls.GetNewRecordID()
                        Dim condition As String = "'" & newestValDT.Rows(0).Item("txmonth").ToString.Trim & "', '" & _
                            newestValDT.Rows(0).Item("Aeno").ToString.Trim & "', '" & _
                            newestValDT.Rows(0).Item("aename").ToString.Trim & "', '" & _
                            newestValDT.Rows(0).Item("accno").ToString.Trim & "', '" & _
                            newestValDT.Rows(0).Item("accname1").ToString.Trim & "', '" & _
                            newestValDT.Rows(0).Item("accname2").ToString.Trim & "', '" & _
                            newestValDT.Rows(0).Item("Commod").ToString.Trim & "', '" & _
                            newestValDT.Rows(0).Item("mth").ToString.Trim & "', '" & _
                            GetAdjCode(newestValDT.Rows(0).Item("call_put").ToString.Trim) & "', " & _
                            newestValDT.Rows(0).Item("strike").ToString.Trim & ", '" & _
                            newestValDT.Rows(0).Item("s_price_str").ToString.Trim & "', " & _
                            newestValDT.Rows(0).Item("day_dd") & ", " & newestValDT.Rows(0).Item("night_dd") & ", " & _
                            newestValDT.Rows(0).Item("tg_dd") & ", " & newestValDT.Rows(0).Item("commission_dd") & ", " & _
                            newestValDT.Rows(0).Item("exchange_fee_dd") & ", " & newestValDT.Rows(0).Item("ae_rebate_dd") & _
                            ", " & newestValDT.Rows(0).Item("commission_mm") & ", " & _
                            newestValDT.Rows(0).Item("exchange_fee_mm") & ", " & newestValDT.Rows(0).Item("ae_rebate_mm") & _
                            ", " & newestValDT.Rows(0).Item("day_mm") & ", " & newestValDT.Rows(0).Item("night_mm") & ", " & _
                            newestValDT.Rows(0).Item("tg_mm") & ", '" & newestValDT.Rows(0).Item("marketname").ToString.Trim & _
                            "', '" & newestValDT.Rows(0).Item("ccy").ToString.Trim & "', getdate() , '" & GStrloginID & "', " & _
                            newestValDT.Rows(0).Item("oid").ToString.Trim & ", 'D'"
                        log = "'" & GStrloginID & "', GETDATE(), 'D', 'TradeAdjF', '" & _
                            newestValDT.Rows(0).Item("aeno").ToString.Trim & "', '" & _
                            newestValDT.Rows(0).Item("accno").ToString.Trim & "', '', '" & _
                            newestValDT.Rows(0).Item("txmonth").ToString.Trim & "', '" & _
                            GFncSqlQuote(GfncOneFieldLog("Adjustment Action", "unAdj", "D")) & "', "
                        cls.AddNewRecord(condition, log)
                    End If
                    btnEnquiry_Click(Nothing, System.EventArgs.Empty)
                End If
            Case "Restore"
                'restore
                If GSubShowYNConfirm(GFncGetSysMsg(41), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                '-------------------------------------------
                Dim newestValDT As DataTable = cls.GetNewestVal(Me.dtgTrade.CurrentRow.Cells("dtgoid").Value.ToString.Trim, Me.dtgTrade.CurrentRow.Cells("dtgRecordID").Value)
                If newestValDT.Rows.Count <= 0 Then 'return when no record
                    GSubShowError(GFncGetSysMsg(38))
                    Return
                End If
                If newestValDT.Rows(0).Item("adj_action") <> "Deleted" Then 'if not deleted, cannot restore
                    GSubShowError(GFncGetSysMsg(38))
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                '------------------------------------------
                If newestValDT.Rows(0).Item("adj_action") = "Deleted" Then
                    'Dim record As String = cls.GetRestoreFlag(newestValDT.Rows(0).Item("recordID").ToString.Trim)
                    'If record.Length <= 0 Then
                    '    GSubShowInfo(GFncGetSysMsg(38))
                    'End If
                    log = "'" & GStrloginID & "', GETDATE(), 'M', 'TradeAdjF', '" & _
                        newestValDT.Rows(0).Item("aeno").ToString.Trim & "', '" & _
                        newestValDT.Rows(0).Item("accno").ToString.Trim & "', '', '" & _
                        newestValDT.Rows(0).Item("recordID").ToString.Trim & "', '" & _
                        newestValDT.Rows(0).Item("txmonth").ToString.Trim & "', '" & _
                        GFncSqlQuote(GfncOneFieldLog("adjaction", GetAdjCode(newestValDT.Rows(0).Item("adj_action")), "M")) & "'"
                    cls.RestoreDel("M", newestValDT.Rows(0).Item("recordID").ToString.Trim, log)
                    btnEnquiry_Click(Nothing, System.EventArgs.Empty)
                End If
        End Select
    End Sub

    Private Sub RBAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAll.CheckedChanged
        If Not LoadFlag Then
            If Me.CboSYr.Text.Length > 0 And Me.CboSMonth.Text.Length > 0 Then
                If RBAll.Checked = True Then
                    btnEnquiry_Click(Nothing, System.EventArgs.Empty)
                End If
            End If
        End If
    End Sub

    Private Sub RBAdj_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBAdj.CheckedChanged
        If Not LoadFlag Then
            If Me.CboSYr.Text.Length > 0 And Me.CboSMonth.Text.Length > 0 Then
                If RBAdj.Checked = True Then
                    btnEnquiry_Click(Nothing, System.EventArgs.Empty)
                End If
            End If
        End If
    End Sub

    Private Sub RBDel_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RBDel.CheckedChanged
        If Not LoadFlag Then
            If Me.CboSYr.Text.Length > 0 And Me.CboSMonth.Text.Length > 0 Then
                If RBDel.Checked = True Then
                    btnEnquiry_Click(Nothing, System.EventArgs.Empty)
                End If
            End If
        End If
    End Sub

    Private Sub ObjEnable(ByVal blnFlag As Boolean)
        Me.CboSMonth.Enabled = False
        Me.CboSYr.Enabled = False
        SearchBox.Enabled = Not blnFlag
        dtgTrade.Enabled = Not blnFlag
        CboMAeno.Enabled = blnFlag
        CboMAccNo.Enabled = blnFlag
        txtMDay_mm.Enabled = blnFlag
        txtMNight_mm.Enabled = blnFlag
        Me.txtDayComm.Enabled = blnFlag
        Me.txtNightComm.Enabled = blnFlag
        Me.txtTotComm.Enabled = False
        cboTradeType.Enabled = blnFlag
        If stateFlag = "MODIFY" Then
            cboMYr.Enabled = False
            CboMMonth.Enabled = False
            cboMCommod.Enabled = Not blnFlag
        Else
            cboMYr.Enabled = False
            CboMMonth.Enabled = False
            cboMCommod.Enabled = blnFlag
        End If
        If stateFlag = "ADD" Then
            Me.txtMMarket.Enabled = blnFlag
            Me.CboMCallPut.Enabled = blnFlag
            Me.CboMCcy.Enabled = blnFlag
        Else
            Me.txtMMarket.Enabled = False
            Me.CboMCallPut.Enabled = False
            Me.CboMCcy.Enabled = False
        End If
        btnAdd.Enabled = Not blnFlag
        btnModify.Enabled = Not blnFlag
        btnDel.Enabled = Not blnFlag
        btnSave.Enabled = blnFlag
    End Sub

    Private Function fncGenLog() As String
        Dim lstrLog As String = ""
        Select Case stateFlag
            Case "MODIFY"
                'If Me.CboMAeno.Text <> Me.dtgTrade.CurrentRow.Cells("dtgaeno").Value.ToString.Trim Then
                '    lstrLog += GfncOneFieldLog("AE No.", Me.dtgTrade.CurrentRow.Cells("dtgaeno").Value.ToString.Trim, _
                '                    Me.CboMAeno.Text)
                'End If
                'If Me.CboMAccNo.Text <> Me.dtgTrade.CurrentRow.Cells("dtgaccno").Value.ToString.Trim Then
                '    lstrLog += GfncOneFieldLog("Account No.", Me.dtgTrade.CurrentRow.Cells("dtgaccno").Value.ToString.Trim, _
                '                    Me.CboMAccNo.Text)
                'End If
                If Me.cboMCommod.Text <> Me.dtgTrade.CurrentRow.Cells("dtgCommod").Value.ToString.Trim Then
                    lstrLog += GfncOneFieldLog("Product", Me.dtgTrade.CurrentRow.Cells("dtgCommod").Value.ToString.Trim, Me.cboMCommod.Text) & " "
                End If
                If Me.txtMDay_mm.Text <> Me.dtgTrade.CurrentRow.Cells("dtgDay_mm").Value.ToString.Trim Then
                    lstrLog += GfncOneFieldLog("Day Lot", Me.dtgTrade.CurrentRow.Cells("dtgDay_mm").Value.ToString.Trim, Me.txtMDay_mm.Text) & " "
                End If
                If Me.txtMNight_mm.Text <> Me.dtgTrade.CurrentRow.Cells("dtgnight_mm").Value.ToString.Trim Then
                    lstrLog += GfncOneFieldLog("Night Lot", Me.dtgTrade.CurrentRow.Cells("dtgnight_mm").Value.ToString.Trim, Me.txtMNight_mm.Text) & " "
                End If
                'If (Me.cboMYr.Text & Format(CInt(Me.CboMMonth.Text), "00")) <> Me.dtgTrade.CurrentRow.Cells("dtgtxmonth").Value.ToString.Trim Then
                '    lstrLog += GfncOneFieldLog("txmonth", Me.dtgTrade.CurrentRow.Cells("dtgtxmonth").Value.ToString.Trim, _
                '                    (Me.cboMYr.Text & Format(CInt(Me.CboMMonth.Text), "00")))
                'End If
                If Me.cboTradeType.Text <> Me.dtgTrade.CurrentRow.Cells("dtgtradetype").Value.ToString.Trim Then
                    lstrLog += GfncOneFieldLog("Trade Type", Me.dtgTrade.CurrentRow.Cells("dtgtradetype").Value.ToString.Trim, Me.cboTradeType.Text) & " "
                End If
                If Me.txtNightComm.Text <> Me.dtgTrade.CurrentRow.Cells("night_comm").Value.ToString.Trim Then
                    lstrLog += GfncOneFieldLog("Night Commission", Me.dtgTrade.CurrentRow.Cells("night_comm").Value.ToString.Trim, Me.txtNightComm.Text) & " "
                End If
                If Me.txtDayComm.Text <> Me.dtgTrade.CurrentRow.Cells("day_comm").Value.ToString.Trim Then
                    lstrLog += GfncOneFieldLog("Day Commission", Me.dtgTrade.CurrentRow.Cells("day_comm").Value.ToString.Trim, Me.txtDayComm.Text) & " "
                End If
                If Me.txtTotComm.Text <> Me.dtgTrade.CurrentRow.Cells("dtgCommission_mm").Value.ToString.Trim Then
                    lstrLog += GfncOneFieldLog("Commission", Me.dtgTrade.CurrentRow.Cells("dtgCommission_mm").Value.ToString.Trim, Me.txtTotComm.Text) & " "
                End If
            Case "ADD"
                'If Me.CboMAeno.Text.Trim.Length > 0 Then
                '    lstrLog += GfncOneFieldLog("AE No.", Me.CboMAeno.Text.Trim)
                'End If
                'If Me.CboMAccNo.Text.Trim.Length > 0 Then
                '    lstrLog += GfncOneFieldLog("Account No.", Me.CboMAccNo.Text.Trim)
                'End If
                If Me.cboMCommod.Text.Trim.Length > 0 Then
                    lstrLog += GfncOneFieldLog("Product", Me.cboMCommod.Text.Trim) & " "
                End If
                If Me.txtMDay_mm.Text.Trim.Length > 0 Then
                    lstrLog += GfncOneFieldLog("Day Lot", Me.txtMDay_mm.Text.Trim) & " "
                End If
                If Me.txtMNight_mm.Text.Trim.Length > 0 Then
                    lstrLog += GfncOneFieldLog("Night Lot", Me.txtMNight_mm.Text.Trim) & " "
                End If
                'If Me.cboMYr.Text.Length > 0 And Me.CboMMonth.Text.Length > 0 Then
                '    lstrLog += GfncOneFieldLog("txmonth", (Me.cboMYr.Text & Format(CInt(Me.CboMMonth.Text), "00")))
                'End If
                If Me.CboMCallPut.Visible Then
                    lstrLog += GfncOneFieldLog("Put / Call", GetCallPut(Me.CboMCallPut.Text.Trim)) & " "
                End If
                If Me.CboMCcy.Text.Length > 0 Then
                    lstrLog += GfncOneFieldLog("Currency", GetCallPut(Me.CboMCcy.Text.Trim)) & " "
                End If
                If Me.txtMMarket.Text.Length > 0 Then
                    lstrLog += GfncOneFieldLog("Market", GetCallPut(Me.txtMMarket.Text.Trim)) & " "
                End If
                If Me.cboTradeType.Text.Trim.Length > 0 Then
                    lstrLog += GfncOneFieldLog("Trade Type", Me.cboTradeType.Text.Trim) & " "
                End If
                If Me.txtDayComm.Text.Trim.Length > 0 Then
                    lstrLog += GfncOneFieldLog("Day Commission", Me.txtDayComm.Text.Trim) & " "
                End If
                If Me.txtNightComm.Text.Trim.Length > 0 Then
                    lstrLog += GfncOneFieldLog("Night Commission", Me.txtNightComm.Text.Trim) & " "
                End If
                If Me.txtTotComm.Text.Trim.Length > 0 Then
                    lstrLog += GfncOneFieldLog("Commission", Me.txtTotComm.Text.Trim) & " "
                End If
        End Select
        Return lstrLog
    End Function

    Public Function GfncOneFieldLog(ByVal lstrTitle As String, ByVal lstrFm As String, Optional ByVal lstrTo As String = Nothing) As String
        If IsNothing(lstrTo) Then
            Return "[" & lstrTitle.Trim & "]='" & lstrFm.Trim & "'"
        Else
            Return "[" & lstrTitle.Trim & "]='" & lstrFm.Trim & "' To '" & lstrTo.Trim & "' "
        End If
    End Function

    Private Function GetAdjCode(ByVal inadj As String) As String
        Select Case inadj
            Case "New"
                Return "A"
            Case "Adjusted"
                Return "M"
            Case "Deleted"
                Return "D"
            Case Else
                Return ""
        End Select
    End Function

    Private Function GetCallPut(ByVal inCall As String) As Integer
        Select Case inCall
            Case "Call"
                Return "2"
            Case "Put"
                Return "1"
            Case Else
                Return "0"
        End Select
    End Function

    Private Sub lsubGoRecord()
        If myObj <> "" Then
            For lintCnt As Integer = 0 To Me.dtgTrade.Rows.Count - 1
                If Me.dtgTrade.Rows(lintCnt).Cells("dtgRecordID").Value.ToString.Trim = myObj Then
                    Me.dtgTrade.Rows(lintCnt).Cells("dtgAdjaction").Selected = True
                    dtgTrade_SelectionChanged(Nothing, System.EventArgs.Empty)

                    Me.dtgTrade.Focus()
                    Exit For
                End If
            Next
            myObj = ""
        End If
    End Sub

    Private Sub GetAeAcCode()
        Dim dt As DataTable = cls.GetAcCode()
        CboMAccNo.Items.Clear()
        For Each dr As DataRow In dt.Rows
            CboMAccNo.Items.Add(dr.Item(0).ToString.Trim)
        Next
        dt = cls.GetAeCode()
        CboMAeno.Items.Clear()
        For Each dr As DataRow In dt.Rows
            CboMAeno.Items.Add(dr.Item(0).ToString.Trim)
        Next
    End Sub

    Private Sub CboMAeno_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMAeno.SelectedValueChanged, CboMAeno.LostFocus
        If CboMAeno.Text.Length > 0 Then
            CboMAeno.Text = CboMAeno.Text.ToUpper
            TxtMAeName.Text = cls.GetAeName(CboMAeno.Text)
        Else
            TxtMAeName.Text = ""
        End If
    End Sub

    Private Sub CboMAccNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMAccNo.SelectedValueChanged, CboMAccNo.LostFocus
        If CboMAccNo.Text.Length > 0 Then
            CboMAccNo.Text = CboMAccNo.Text.ToUpper
            txtMAcName.Text = cls.GetAcName(CboMAccNo.Text)
        Else
            txtMAcName.Text = ""
        End If
    End Sub

    Private Sub GetCCY()
        'Dim dt As DataTable = cls.GetCCY().Tables(0)
        'For Each dr As DataRow In dt.Rows
        '    Me.CboMCcy.Items.Add(dr.Item(0))
        'Next
    End Sub

    Private Sub GetProduct()
        ProductDT = cls.GetProduct.Tables(0)
        If ProductDT.Rows.Count <= 0 Then
            Return
        End If
        For Each dr As DataRow In ProductDT.Rows
            cboMCommod.Items.Add(dr.Item("Product_no").ToString.Trim)
        Next
        Me.cboMCommod.Text = Me.ProductDT.Rows(0).Item("Product_no").ToString.Trim
    End Sub


    Private Sub cboMCommod_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboMCommod.SelectedIndexChanged, cboMCommod.LostFocus
        If Me.cboMCommod.Text.Length > 0 Then
            Me.cboMCommod.Text = Me.cboMCommod.Text.ToUpper
            Dim ProdDr() As DataRow = ProductDT.Select("product_no='" & Me.cboMCommod.Text & "'")
            If ProdDr.Length <= 0 Then
                Return
            End If
            Me.txtMProductName.Text = ProdDr(0).Item("product_name").ToString.Trim
            Select Case ProdDr(0).Item("type").ToString.Trim
                Case 0
                    Me.CboMCallPut.Visible = False
                    LbCallPut.Visible = False
                Case 1
                    Me.CboMCallPut.Visible = True
                    LbCallPut.Visible = True
                Case Else
                    Me.CboMCallPut.Visible = False
                    LbCallPut.Visible = False
            End Select

        End If
    End Sub

    Private Sub GetTradeType()
        Dim dt As DataTable = cls.GetTType().Tables(0)
        For Each dr As DataRow In dt.Rows
            Me.cboTradeType.Items.Add(dr.Item("type"))
        Next
    End Sub

    Private Sub CboMCcy_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMCcy.SelectedIndexChanged, CboMCcy.LostFocus
        If CboMCcy.Text.Length > 0 Then
            CboMCcy.Text = CboMCcy.Text.ToUpper
        End If
    End Sub

    Private Sub txtDayComm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtDayComm.TextChanged, txtDayComm.LostFocus
        CalTotalComm()
    End Sub

    Private Sub txtNightComm_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNightComm.TextChanged, txtNightComm.LostFocus
        CalTotalComm()
    End Sub
    Private Sub CalTotalComm()
        If txtDayComm.Text.Length > 0 And txtNightComm.Text.Length > 0 Then
            txtTotComm.Text = CDbl(txtDayComm.Text) + CDbl(txtNightComm.Text)
        Else
            txtTotComm.Text = "0.0000"
        End If
    End Sub
End Class
