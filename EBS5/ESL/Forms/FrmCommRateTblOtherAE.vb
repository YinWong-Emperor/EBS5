Public Class FrmCommRateTblOtherAE

    Dim cls As New ClsCommRateTblOther
    Dim LoadFlag As Boolean
    Dim AccDT As DataTable
    Dim AeDT As DataTable
    Dim ProductDT As DataTable
    Dim ActionFlag As String
    Dim ObjRsid As Integer
    Dim ae As String
    Dim TabFlag As Boolean
    Dim C_type As String

    Private Sub FrmCommRateTblOtherAE_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        LoadFlag = True
        ActionFlag = ""
        C_type = "AE"
        ae = ""
        ObjRsid = 0
        ObjEnable(False)
        Me.LabLot_range.Text = ""
        AeDT = cls.GetAe()
        For Each AeDr As DataRow In AeDT.Rows
            If Not Me.comboAE.Items.Contains(GFncNoNullString(AeDr("ae_no")).Trim) Then
                Me.comboAE.Items.Add(GFncNoNullString(AeDr("ae_no")).Trim)
            End If
        Next
        FncloadDate()
        LoadFlag = False
        btnSearch_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub FncloadDate()
        Dim MaxDate As String = GfncGetMonth()
        If MaxDate.Length > 0 Then
            For year As Integer = Val(MaxDate.Substring(0, 4)) - 3 To Val(MaxDate.Substring(0, 4)) + 3
                Me.comboSrcYr.Items.Add(year)
            Next
            For month As Integer = 1 To 12
                Me.comboSrcMonth.Items.Add(month)
            Next
            Me.comboSrcYr.Text = Val(MaxDate.Substring(0, 4))
            Me.comboSrcMonth.Text = Val(MaxDate.Substring(4, 2))
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ActionFlag.Length > 0 Then
            ActionFlag = ""
            ObjEnable(False)
            Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Me.comboSrcYr.Text.Length > 0 And Me.comboSrcMonth.Text.Length > 0 Then
            Dim txmonth As String = ""
            Dim commType As String = ""
            Dim AE As String = ""
            Dim DefaultAE As Boolean = False
            txmonth = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
            If Me.rbSrchINC.Checked Then
                commType = "INC" & C_type
            ElseIf Me.rbSrchBonus.Checked Then
                commType = "BON" & C_type
            End If
            If Me.cbSrchDefault.Checked Then
                DefaultAE = True
            Else
                AE = Me.txtSrcAE.Text.Trim.ToUpper
            End If
            Me.dtgAE.DataSource = cls.SearchAE(AE, commType, txmonth, C_type, DefaultAE).Tables(0)
            'Me.dtgAE.DataMember = "aeno"
            Me.dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
            lsubGoRecord()
        End If
    End Sub

    Private Sub dtgAE_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgAE.SelectionChanged
        Dim txmonth As String = ""
        Dim commType As String = ""
        Dim AE As String = ""
        Dim formatPrice As String = ""
        Dim defaultAE As Boolean = False
        If ActionFlag = "" And LoadFlag = False Then
            If Me.dtgAE.RowCount > 0 Or Me.cbSrchDefault.Checked Then
                txmonth = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
                If Me.rbSrchINC.Checked Then
                    commType = "INC" & C_type
                ElseIf Me.rbSrchBonus.Checked Then
                    commType = "BON" & C_type
                End If
                If Me.cbSrchDefault.Checked = False Then
                    AE = Me.dtgAE.CurrentRow.Cells("AENo").Value
                End If
                defaultAE = Me.cbSrchDefault.Checked
                Me.dtgRateTbl.DataSource = cls.SearchRateOther(AE, commType, txmonth, C_type, defaultAE).Tables(0)
                For i As Integer = 0 To Me.dtgRateTbl.Rows.Count - 1
                    formatPrice = Format(Me.dtgRateTbl.Rows(i).Cells("comm_net_brok").Value, "##,###,###,##0.00")
                    formatPrice = Mid("                " & formatPrice, formatPrice.Length + 1, 16)
                    Me.dtgRateTbl.Rows(i).Cells("brok_range").Value = ">= " & formatPrice
                    If (IsDBNull(Me.dtgRateTbl.Rows(i).Cells("comm_net_brok_to").Value) = False) Then
                        formatPrice = Format(Me.dtgRateTbl.Rows(i).Cells("comm_net_brok_to").Value, "##,###,###,##0.00")
                        formatPrice = Mid("                " & formatPrice, formatPrice.Length + 1, 16)
                        Me.dtgRateTbl.Rows(i).Cells("brok_range").Value = Me.dtgRateTbl.Rows(i).Cells("brok_range").Value & " and < " & _
                        Format(Me.dtgRateTbl.Rows(i).Cells("comm_net_brok_to").Value, "##,###,###,##0.00")
                    End If
                Next
            Else
                txmonth = "-1"
                Me.dtgRateTbl.DataSource = cls.SearchRateOther(AE, commType, txmonth, C_type, defaultAE).Tables(0)
                EmptyField()
            End If

        End If
    End Sub

    Private Sub dtgRateTbl_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgRateTbl.SelectionChanged
        If LoadFlag = False Then
            If dtgRateTbl.Rows.Count > 0 And Me.dtgAE.Rows.Count > 0 Then
                Me.comboAE.Text = GFncNoNullString(Me.dtgAE.CurrentRow.Cells("AENo").Value.ToString.Trim)
                Me.txtAEName.Text = GFncNoNullString(Me.dtgAE.CurrentRow.Cells("AEName").Value.ToString.Trim)
                Me.txtRate.Text = GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_rate").Value.ToString.Trim)
                Me.txtMonth.Text = GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_month").Value.ToString.Trim)
                Me.txtTOFrom.Text = GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_net_brok").Value.ToString.Trim)
                If GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_type").Value) = "Incentive Comm." Then
                    Me.rbINC.Checked = True
                ElseIf GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_type").Value) = "Bonus Comm." Then
                    Me.rbBonus.Checked = True
                End If
                lFnRefreshTurnover()
            ElseIf Me.dtgAE.Rows.Count > 0 Then
                Me.comboAE.Text = GFncNoNullString(Me.dtgAE.CurrentRow.Cells("AENo").Value.ToString.Trim)
                Me.txtAEName.Text = GFncNoNullString(Me.dtgAE.CurrentRow.Cells("AEName").Value.ToString.Trim)
            ElseIf dtgRateTbl.Rows.Count > 0 Then
                Me.txtRate.Text = GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_rate").Value.ToString.Trim)
                Me.txtMonth.Text = GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_month").Value.ToString.Trim)
                Me.txtTOFrom.Text = GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_net_brok").Value.ToString.Trim)
                If GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_type").Value) = "Incentive Comm." Then
                    Me.rbINC.Checked = True
                ElseIf GFncNoNullString(Me.dtgRateTbl.CurrentRow.Cells("comm_type").Value) = "Bonus Comm." Then
                    Me.rbBonus.Checked = True
                End If
                lFnRefreshTurnover()
            End If
        Else
            EmptyField()
        End If
    End Sub

    Private Sub ObjEnable(ByVal blnflag As Boolean)
        'search
        Me.txtSrcAE.Enabled = Not blnflag
        Me.comboSrcMonth.Enabled = False
        Me.comboSrcYr.Enabled = False
        Me.rbSrchBonus.Enabled = Not blnflag
        Me.rbSrchINC.Enabled = Not blnflag
        Me.rbSrchAll.Enabled = Not blnflag
        Me.cbSrchDefault.Enabled = Not blnflag
        Me.btnSearch.Enabled = Not blnflag
        Me.dtgRateTbl.Enabled = Not blnflag
        Me.dtgAE.Enabled = Not blnflag
        'edit
        Me.rbINC.Enabled = blnflag
        Me.rbBonus.Enabled = blnflag
        Me.txtTOFrom.Enabled = blnflag
        Me.txtRate.Enabled = blnflag
        Me.txtMonth.Enabled = False
        Me.cbDefault.Enabled = blnflag
        'btn
        Me.btnSave.Enabled = blnflag
        Me.btnDelete.Enabled = Not blnflag
        Me.btnNew.Enabled = Not blnflag
        Me.btnEdit.Enabled = Not blnflag
        Select Case ActionFlag
            Case "New"
                Me.comboAE.Enabled = blnflag
            Case "Edit"
                Me.comboAE.Enabled = Not blnflag
            Case Else
                Me.comboAE.Enabled = False
        End Select
    End Sub

    Private Sub comboAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboAE.SelectedIndexChanged, comboAE.LostFocus
        If LoadFlag = False Then
            If Me.comboAE.Text.Length > 0 And ActionFlag = "New" Then
                Me.comboAE.Text = Me.comboAE.Text.ToUpper
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
            End If
        End If
    End Sub

    '*******************************************************************Edit****************************************************************
    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        ActionFlag = "New"
        ObjEnable(True)
        EmptyField()
        If Me.rbSrchBonus.Checked Then
            Me.rbBonus.Checked = True
        Else
            Me.rbINC.Checked = True
        End If
        Me.cbDefault.Checked = Me.cbSrchDefault.Checked
        Me.comboAE.Enabled = Not Me.cbSrchDefault.Checked
        Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ActionFlag = "Edit"
        If (Me.dtgRateTbl.Rows.Count > 0) Then
            ObjEnable(True)
            Me.cbDefault.Enabled = False
            Me.txtTOFrom.Focus()
        Else
            GSubShowInfo("no record to edit")
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim condition As String = ""
        Dim rate As Double = 0
        Dim type As String = ""
        Dim month As String = ""
        Dim brok As Double = 0
        ae = ""
        ObjRsid = 0
        If Validation() = False Then
            Return
        End If
        If comboAE.Enabled Then
            ae = comboAE.Text.Trim
        End If
        rate = Me.txtRate.Text
        If Me.rbINC.Checked Then
            If Me.cbDefault.Checked Then
                type = "DEF"
            End If
            type += "INCAE"
        ElseIf Me.rbBonus.Checked Then
            If Me.cbDefault.Checked Then
                type = "DEF"
            End If
            type += "BONAE"
        End If
        month = Me.txtMonth.Text
        brok = CDbl(Me.txtTOFrom.Text)
        Select Case ActionFlag
            Case "New"
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
                condition = "'" & ae & "', " & rate & ", '" & type & "', '" & month & "', " & brok & " "
                ObjRsid = cls.NewRecord(condition, ae.Trim, rate, type.Trim, month.Trim, brok)
                ActionFlag = ""
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                ObjEnable(False)
                Me.dtgRateTbl.Focus()
            Case "Edit"
                ObjRsid = Me.dtgRateTbl.CurrentRow.Cells("rsid").Value
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
                condition = "comm_rate=" & rate & ", comm_type ='" & type & "', comm_net_brok = " & brok '& ", ae_no  = '" & ae & "' "
                cls.EditRecord(condition, ObjRsid, rate, type.Trim, brok, ae.Trim)
                ActionFlag = ""
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                ObjEnable(False)
                Me.dtgRateTbl.Focus()
        End Select
    End Sub

    Private Function Validation() As Boolean
        Dim ErrorMsg As String = ""
        If ActionFlag = "New" Or ActionFlag = "Edit" Then
            If Me.comboAE.Text.Length <= 0 And Me.cbDefault.Checked = False Then
                ErrorMsg += "AE,"
            End If
            If Me.txtMonth.Text.Length <= 0 Then
                ErrorMsg += " Month,"
            End If
            If Me.txtTOFrom.TextLength <= 0 Then
                ErrorMsg += " Turnover,"
            End If
            If Me.txtRate.TextLength <= 0 Then
                ErrorMsg += " Comm. Rate,"
            End If
        End If
        If ErrorMsg.Length > 0 Then
            GSubShowInfo(ErrorMsg.Substring(0, ErrorMsg.Length - 1) & GFncGetSysMsg(49))
            Return False
        End If
        If Not cbDefault.Checked Then
            Dim AeDr() As DataRow
            AeDr = AeDT.Select("ae_no='" & Me.comboAE.Text & "'")
            If AeDr.Length <= 0 Then
                GSubShowInfo(GFncGetSysMsg(31))
                Me.comboAE.Focus()
                Return False
            End If
        End If
        Return True
    End Function

    Private Sub EmptyField()
        If LoadFlag = False Then
            If ActionFlag = "New" And Me.dtgAE.Rows.Count <= 0 Then
                Me.comboAE.SelectedIndex = -1
                Me.comboAE_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            End If
            Me.txtTOFrom.Text = 0
            Me.txtRate.Text = "0.0000"
            Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
            Me.rbINC.Checked = True
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
            ae = Me.dtgAE.CurrentRow.Cells("AENo").Value.ToString.Trim
            cls.DelRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim)
            ObjEnable(False)
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
        Me.dtgRateTbl.Focus()
    End Sub

    Private Sub lsubGoRecord()
        If LoadFlag = False Then
            If ae <> "" Then
                For lintCnt As Integer = 0 To Me.dtgAE.RowCount - 1
                    If Me.dtgAE.Rows(lintCnt).Cells("AENo").Value.ToString.Trim = ae Then
                        Me.dtgAE.Rows(lintCnt).Cells("AENo").Selected = True
                    End If
                Next
                Me.dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)

                If ObjRsid > 0 Then
                    For lintCnt As Integer = 0 To Me.dtgRateTbl.Rows.Count - 1
                        If Me.dtgRateTbl.Rows(lintCnt).Cells("rsid").Value.ToString.Trim = ObjRsid Then
                            Me.dtgRateTbl.Rows(lintCnt).Cells("comm_type").Selected = True
                            Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)

                            Me.dtgRateTbl.Focus()
                            Exit For
                        End If
                    Next
                End If
            End If
            ObjRsid = 0
            ae = ""
        End If
    End Sub



    'Private Function fncGenLog() As String
    '    Dim lstrLog As String = ""
    '    Select Case ActionFlag
    '        Case "Edit"
    '            '    Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim).Tables(0)
    '            '    If dt.Rows.Count > 0 Then
    '            '        If Me.comboAE.Text.Trim.Length > 0 And Me.comboAE.Text.Trim <> dt.Rows(0).Item("ae_no").ToString.Trim Then
    '            '            lstrLog += cls.GfncOneFieldLog("ae_no", dt.Rows(0).Item("ae_no").ToString.Trim, Me.comboAE.Text.Trim)
    '            '        End If
    '            '        If Me.txtRate.Text.Trim.Length > 0 And Me.txtRate.Text.Trim <> dt.Rows(0).Item("day_rate").ToString.Trim Then
    '            '            lstrLog += cls.GfncOneFieldLog("Day_rate", dt.Rows(0).Item("day_rate").ToString.Trim, Me.txtRate.Text.Trim)
    '            '        End If
    '            '        If Me.txtNRate.Text.Trim.Length > 0 And Me.txtNRate.Text.Trim <> dt.Rows(0).Item("rsid").ToString.Trim Then
    '            '            lstrLog += cls.GfncOneFieldLog("Night_rate", dt.Rows(0).Item("night_rate").ToString.Trim, Me.txtNRate.Text.Trim)
    '            '        End If

    '            '        If Me.txtTOFrom.Text.Trim.Length > 0 And CDbl(Me.txtTOFrom.Text.Trim) <> CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim) Then
    '            '            lstrLog += cls.GfncOneFieldLog("Turnover_from", CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim), CDbl(Me.txtTOFrom.Text.Trim))
    '            '        End If
    '            '        If Me.RateType(FutFlag).Trim <> dt.Rows(0).Item("rate_type").ToString.Trim Then
    '            '            lstrLog += cls.GfncOneFieldLog("Rate_type", dt.Rows(0).Item("rate_type").ToString.Trim, RateType(FutFlag).Trim)
    '            '        End If
    '            '        'If Me.txtRate.Text.Length > 0 Then
    '            '        '    If Me.rbDayRate.Checked And dt.Rows(0).Item("day_rate").ToString.Trim <> Me.txtRate.Text.Trim Then
    '            '        '        lstrLog += cls.GfncOneFieldLog("Day_rate", dt.Rows(0).Item("day_rate").ToString.Trim, Me.txtRate.Text.Trim)
    '            '        '    Else
    '            '        '        If Me.rbNightRate.Checked And dt.Rows(0).Item("night_rate").ToString.Trim <> Me.txtRate.Text.Trim Then
    '            '        '            lstrLog += cls.GfncOneFieldLog("Night_rate", dt.Rows(0).Item("night_rate").ToString.Trim, Me.txtRate.Text.Trim)
    '            '        '        Else
    '            '        '            If dt.Rows(0).Item("all_rate").ToString.Trim <> Me.txtRate.Text.Trim Then
    '            '        '                lstrLog += cls.GfncOneFieldLog("All_rate", dt.Rows(0).Item("all_rate").ToString.Trim, Me.txtRate.Text.Trim)
    '            '        '            End If
    '            '        '        End If
    '            '        '    End If
    '            '        'End If


    '            '    End If
    '            'Case "New"
    '            '    If Me.comboAE.Text.Trim.Length > 0 Then
    '            '        lstrLog += cls.GfncOneFieldLog("ae_no", Me.comboAE.Text.Trim)
    '            '    End If
    '            '    If Me.comboAccNo.Text.Trim.Length > 0 Then
    '            '        lstrLog += cls.GfncOneFieldLog("Acc_no", Me.comboAccNo.Text.Trim)
    '            '    End If
    '            '    If Me.comboProduct.Text.Trim.Length > 0 Then
    '            '        lstrLog += cls.GfncOneFieldLog("product_group", Me.comboProduct.Text.Trim)
    '            '    End If
    '            '    If Me.txtRate.Text.Trim.Length > 0 Then
    '            '        lstrLog += cls.GfncOneFieldLog("Day_rate", Me.txtRate.Text.Trim)
    '            '    End If
    '            '    If Me.txtNRate.Text.Trim.Length > 0 Then
    '            '        lstrLog += cls.GfncOneFieldLog("Night_rate", Me.txtNRate.Text.Trim)
    '            '    End If
    '            '    '    If Me.rbRateAll.Checked Then
    '            '    '        lstrLog += cls.GfncOneFieldLog("All_rate", Me.txtRate.Text.Trim)
    '            '    '    End If
    '            '    '    If Me.rbDayRate.Checked Then
    '            '    '        lstrLog += cls.GfncOneFieldLog("Day_rate", Me.txtRate.Text.Trim)
    '            '    '    End If
    '            '    '    If Me.rbNightRate.Checked Then
    '            '    '        lstrLog += cls.GfncOneFieldLog("Night_rate", Me.txtRate.Text.Trim)
    '            '    '    End If
    '            '    'End If
    '            '    If Me.txtMonth.Text.Length > 0 Then
    '            '        lstrLog += cls.GfncOneFieldLog("comm_month", txtMonth.Text.Trim)
    '            '    End If
    '            '    If Me.txtTOFrom.Text.Trim.Length > 0 Then
    '            '        lstrLog += cls.GfncOneFieldLog("Turnover_from", CDbl(Me.txtTOFrom.Text.Trim))
    '            '    End If
    '            '    'If Me.txtACGp.Text.Trim.Length > 0 Then
    '            '    '    lstrLog += cls.GfncOneFieldLog("Acc_group", Me.txtACGp.Text.Trim)
    '            '    'End If

    '            '    lstrLog += cls.GfncOneFieldLog("Rate_type", RateType(FutFlag))
    '            '    lstrLog += cls.GfncOneFieldLog("Comm_type", C_type)


    '    End Select
    '    Return lstrLog
    'End Function

    Private Function ValidateDuplicate() As Boolean
        Dim type As String = "'"
        If rbINC.Checked = True Then
            type = "INCAE"
        ElseIf rbBonus.Checked = True Then
            type = "BONAE"
        End If
        Dim condition As String = " and ae_no='" & Me.comboAE.Text.Trim & "' and comm_net_brok =" & _
            CDbl(Me.txtTOFrom.Text.Trim) & " and comm_month ='" & Me.txtMonth.Text.Trim & "' and comm_type='" & type & "' "
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

    Private Sub rbSrchINC_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchINC.CheckedChanged
        If LoadFlag = False Then
            If Me.rbSrchINC.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub rbSrchBonus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchBonus.CheckedChanged
        If LoadFlag = False Then
            If rbSrchBonus.Checked Then
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
        Dim Rtype As String = ""
        If Me.rbINC.Checked Then
            Rtype = "INCAE"
        ElseIf Me.rbBonus.Checked Then
            Rtype = "BONAE"
        End If
        Dim ae_num As String = Me.comboAE.Text
        Dim turnover As String = CDbl(Me.txtTOFrom.Text)
        Dim lds As DataSet
        Dim turnoverTo As String = ""
        lds = cls.lFncGetNextComm(comm_month, ae_num, Rtype, turnover)
        If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
            Me.LabLot_range.Text = ""
        Else
            Me.LabLot_range.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,##0.00")
        End If
    End Sub

    Private Sub LabLot_range_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTOFrom.LostFocus
        lFnRefreshTurnover()
    End Sub

    Private Sub rbBonus_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbBonus.CheckedChanged
        lFnRefreshTurnover()
    End Sub

    Private Sub cbSrchDefault_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbSrchDefault.CheckedChanged
        If cbSrchDefault.Checked Then
            Me.dtgAE.Enabled = False
            Me.txtSrcAE.Enabled = False
        Else
            Me.dtgAE.Enabled = True
            Me.txtSrcAE.Enabled = True
        End If
        Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub cbDefault_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbDefault.CheckedChanged
        If cbDefault.Checked Then
            Me.comboAE.Enabled = False
        Else
            Me.comboAE.Enabled = True
        End If
    End Sub
End Class
