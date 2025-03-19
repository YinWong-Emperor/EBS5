Imports System.Data.SqlClient

Public Class FrmCommRatetblFutAE

    Dim cls As New ClsCommRatetblFAcc
    Dim LoadFlag As Boolean = True
    Dim AeDT As DataTable
    Dim ProductDT As DataTable
    Dim ActionFlag As String
    Dim ObjRsid As Integer
    Dim ae As String
    Dim prod As String
    Dim C_type As String

    Private Sub FrmCommRatetblFutAgp_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        ActionFlag = ""
        C_type = "AE"
        LabLot_range.Text = ""
        ae = ""
        ObjRsid = 0
        LoadFlag = True
        AeDT = cls.GetAllAe()
        Dim MaxDate As String = GfncGetMonth()
        For year As Integer = Val(MaxDate.Substring(0, 4)) - 5 To Val(MaxDate.Substring(0, 4)) + 5
            Me.comboSrcYr.Items.Add(year)
        Next
        For month As Integer = 1 To 12
            Me.comboSrcMonth.Items.Add(month)
        Next
        Me.comboSrcYr.Text = MaxDate.Substring(0, 4)
        Me.comboSrcMonth.Text = Val(MaxDate.Substring(4, 2))
        ProductDT = cls.GetProduct()
        ObjEnable(False)
        LoadFlag = False
        FncLoadProductByMonth(Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00"))
        Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ActionFlag.Length > 0 Then
            ActionFlag = ""
            Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)
            ObjEnable(False)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub LoadAeByMonth(ByVal txmonth As String)
        If LoadFlag = False Then
            If Me.comboSrcMonth.Text.Length > 0 And Me.comboSrcYr.Text.Length > 0 Then
                Me.comboAE.Items.Clear()
                Dim AeDr() As DataRow = AeDT.Select("txmonth='" & txmonth & "'", "ae_no asc")
                For row As Integer = 0 To AeDr.Length - 1
                    Me.comboAE.Items.Add(AeDr(row).Item("ae_no"))
                Next
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim ACcondition As String = ""
        If Me.rbSrchAll.Checked Then
            ACcondition += " and (left(b.rate_type,3) ='INT' or left(b.rate_type,3) ='NOR' or left(b.rate_type,3) ='CON' )"
        ElseIf Me.rbSrchNormal.Checked Then
            ACcondition += " and left(b.rate_type,3) ='NOR' "
        ElseIf Me.rbSrchInternet.Checked Then
            ACcondition += " and left(b.rate_type,3) ='INT' "
        ElseIf Me.rbSrchConsolidate.Checked Then
            ACcondition += " and left(b.rate_type,3) ='CON' "
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
        ACcondition += " and b.comm_type = '" & C_type & "' and b.comm_month = '" & _
            Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00") & "' "
        LoadAeByMonth(Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00"))
        Me.dtgAE.DataSource = cls.EnquiryAETbl(ACcondition).Tables(0)
        dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
        lsubGoRecord()
        If dtgAE.RowCount <= 0 Then
            dtgRateTbl.DataSource = cls.EnquiryRateTbl(" and 1=0 ", "")
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
            EmptyField()
        Else
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
        End If
        Me.dtgAE.Focus()
    End Sub

    Private Sub dtgAE_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgAE.SelectionChanged
        If ActionFlag = "" And LoadFlag = False Then
            If Me.dtgAE.Rows.Count > 0 Then
                If Me.dtgAE.SelectedRows.Count > 0 Then
                    Dim condition As String = " and comm_type='" & C_type & "' and comm_month ='" & Me.comboSrcYr.Text & _
                        Format(Val(Me.comboSrcMonth.Text), "00") & "' and ae_no='" & _
                        Me.dtgAE.CurrentRow.Cells("AENo").Value.ToString.Trim & "' "
                    If Me.rbSrchAll.Checked Then
                        condition += " and (left(rate_type,3) ='INT' or left(rate_type,3) ='NOR' or left(rate_type,3) ='CON' )"
                    ElseIf Me.rbSrchNormal.Checked Then
                        condition += " and left(rate_type,3) ='NOR' "
                    ElseIf Me.rbSrchInternet.Checked Then
                        condition += " and left(rate_type,3) ='INT' "
                    ElseIf Me.rbSrchConsolidate.Checked Then
                        condition += " and left(rate_type,3) ='CON' "
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
                    Me.dtgRateTbl.DataSource = cls.EnquiryRateTbl(condition, " product_group asc, comm_month asc, " & _
                        "acc_group asc, rate_type desc, turnover_from asc, ")
                End If
            End If
        End If
    End Sub

    Private Sub dtgRateTbl_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgRateTbl.SelectionChanged
        If LoadFlag = False Then
            If dtgRateTbl.Rows.Count > 0 And Me.dtgAE.Rows.Count > 0 Then
                Me.comboProduct.Text = Me.dtgRateTbl.CurrentRow.Cells("product_group").Value.ToString.Trim
                Me.txtMonth.Text = Me.dtgRateTbl.CurrentRow.Cells("comm_month").Value.ToString.Trim
                Me.txtTOFrom.Text = Me.dtgRateTbl.CurrentRow.Cells("turnover_from").Value.ToString.Trim
                Me.comboAE.Text = Me.dtgAE.CurrentRow.Cells("AENo").Value.ToString.Trim
                Me.txtAEName.Text = Me.dtgAE.CurrentRow.Cells("AEName").Value.ToString.Trim
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
                Select Case Me.dtgRateTbl.CurrentRow.Cells("fut_type").Value.ToString.Trim
                    Case "Futures and Options"
                        Me.rbFutOpt.Checked = True
                    Case "Futures"
                        Me.rbFutures.Checked = True
                    Case "Options"
                        Me.rbOptions.Checked = True
                End Select
                Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
                lFnRefreshTurnover()
            End If
        Else
            EmptyField()
        End If
    End Sub

    Private Sub comboProduct_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboProduct.SelectedIndexChanged, comboProduct.LostFocus
        If LoadFlag = False Then
            If Me.comboProduct.Text.Length > 0 Then
                Me.comboProduct.Text = Me.comboProduct.Text.ToUpper
            End If
        End If
    End Sub

    Private Sub ObjEnable(ByVal blnflag As Boolean)
        Me.comboSrcMonth.Enabled = False
        Me.comboSrcYr.Enabled = False
        Me.comboSrchProd.Enabled = Not blnflag
        Me.rbNormal.Enabled = blnflag
        Me.rbInternet.Enabled = blnflag
        Me.btnSearch.Enabled = Not blnflag
        Me.dtgRateTbl.Enabled = Not blnflag
        Me.dtgAE.Enabled = Not blnflag
        Me.txtTOFrom.Enabled = blnflag
        Me.txtRate.Enabled = blnflag
        Me.txtNRate.Enabled = blnflag
        Me.txtMonth.Enabled = False
        Me.rbFutOpt.Enabled = blnflag
        Me.rbOptions.Enabled = blnflag
        Me.rbFutures.Enabled = blnflag
        Me.rbSrchOptions.Enabled = Not blnflag
        Me.rbSrchFutures.Enabled = Not blnflag
        Me.rbSrchFutOpt.Enabled = Not blnflag
        Me.rbSrchFutALL.Enabled = Not blnflag
        Me.rbSrchNormal.Enabled = Not blnflag
        Me.rbSrchInternet.Enabled = Not blnflag
        Me.rbSrchAll.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        Me.btnDelete.Enabled = Not blnflag
        Me.btnNew.Enabled = Not blnflag
        Me.btnEdit.Enabled = Not blnflag
        Me.rbSrchConsolidate.Enabled = Not blnflag
        Me.txtSrcAe.Enabled = Not blnflag
        Me.cbConsolidate.Enabled = blnflag
        Select Case ActionFlag
            Case "New"
                Me.comboAE.Enabled = blnflag
                Me.comboProduct.Enabled = blnflag
            Case "Edit"
                Me.comboAE.Enabled = Not blnflag
                Me.comboProduct.Enabled = Not blnflag
            Case Else
                Me.comboAE.Enabled = False
                Me.comboProduct.Enabled = False
        End Select
    End Sub

    Private Sub comboAE_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboAE.SelectedIndexChanged, comboAE.LostFocus
        If LoadFlag = False And ActionFlag = "New" Then
            If Me.comboAE.Text.Length > 0 Then
                Me.comboAE.Text = Me.comboAE.Text.ToUpper
                Dim AE() As DataRow = AeDT.Select(" ae_no ='" & Me.comboAE.Text & "'")
                If AE.Length > 0 Then
                    Me.txtAEName.Text = AE(0).Item("ae_name_f").ToString.Trim
                Else
                    Me.txtAEName.Text = ""
                End If
            Else
                Me.txtAEName.Text = ""
            End If
            Me.ChangeConsolid(Me.comboAE.Text, Me.txtMonth.Text)
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
        'AeDT = cls.GetAllAe()
        ProductDT = cls.GetProduct()
        Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
        If Me.rbSrchNormal.Checked Then
            Me.rbNormal.Checked = True
            'Me.cbConsolidate.Checked = False
        Else
            Me.rbInternet.Checked = True
            'Me.cbConsolidate.Checked = False
            'Else
            'Me.cbConsolidate.Checked = True
        End If
        ChangeConsolid(Me.comboAE.Text, Me.txtMonth.Text)
        If Me.rbSrchOptions.Checked Then
            Me.rbOptions.Checked = True
        ElseIf Me.rbSrchFutures.Checked Then
            Me.rbFutures.Checked = True
        Else
            Me.rbFutOpt.Checked = True
        End If
        Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
        If dtgAE.Rows.Count > 0 Then
            Me.comboAE.SelectedIndex = Me.comboAE.FindString(Me.dtgAE.CurrentRow.Cells("AENo").Value.ToString.Trim)
        Else
            Me.comboAE.SelectedIndex = -1
        End If
        Me.comboAE_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        If Me.comboSrchProd.Text.Length > 0 Then
            Me.comboProduct.Text = Me.comboSrchProd.Text
        End If
        lFnRefreshTurnover()
        Me.comboAE.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dtgRateTbl.SelectedRows.Count > 0 Then
            ActionFlag = "Edit"
            ObjEnable(True)
            ChangeConsolid(Me.comboAE.Text, Me.txtMonth.Text)
            Me.txtTOFrom.Focus()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim condition As String = ""
        Dim log As String = ""
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
                Dim acc_no As String = ""
                condition = "'" & acc_no & "', '', '', '', '" & Me.comboAE.Text.Trim & "', '" & Me.comboProduct.Text & _
                    "', 0, '" & RateType() & "', " & CDbl(Me.txtTOFrom.Text) & ", " & CDbl(Me.txtRate.Text) & ", " & _
                    CDbl(Me.txtNRate.Text) & ", 0, '" & Me.txtMonth.Text & "', '" & C_type & "' "
                'log for add only
                log = "'" & GStrloginID & "', GETDATE(), 'A', 'CommRateTblFutAE', '" & Me.comboAE.Text & "', '" & acc_no & _
                    "', '', '" & Me.txtMonth.Text & "', '" & GFncSqlQuote(fncGenLog()) & "', "
                ObjRsid = cls.NewRecord(condition, log)
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
                If GFncCheckCommStatus() Then
                    Return
                End If
                condition = " turnover_from = " & CDbl(Me.txtTOFrom.Text.Trim) & ", rate_type = '" & RateType() & _
                    "', day_rate = " & CDbl(Me.txtRate.Text) & ", night_rate = " & CDbl(Me.txtNRate.Text) & " "
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value).Tables(0)
                If dt.Rows.Count <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(9))
                    Return
                End If
                log = "'" & GStrloginID & "', GETDATE(), '" & "M" & "', 'CommRateTblFutAE', '" & _
                    dt.Rows(0).Item("ae_no").ToString.Trim & "', '', '', '" & Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & _
                    "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog()) & "' "
                cls.EditRecord(condition, Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim, log)
                ObjRsid = Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim
                ae = Me.comboAE.Text
                ActionFlag = ""
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                ObjEnable(False)
                Me.dtgRateTbl.Focus()
        End Select
    End Sub

    Private Function Validation() As Boolean
        Dim ErrorMsg As String = ""
        If ActionFlag = "New" Or ActionFlag = "Edit" Then
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
        End If
        If ErrorMsg.Length > 0 Then
            GSubShowInfo(ErrorMsg.Substring(0, ErrorMsg.Length - 1) & GFncGetSysMsg(49))
            Return False
        Else
            'Dim AeDr() As DataRow
            If ActionFlag = "New" Or ActionFlag = "Edit" Then
                If AeDT.Select("ae_no='" & Me.comboAE.Text & "'").Length <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(31))
                    Return False
                End If
            End If
            'Dim ProductDr() As DataRow
            If ActionFlag = "New" Or ActionFlag = "Edit" Then
                If ProductDT.Select("product_group='" & Me.comboProduct.Text & "'").Length <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(51))
                    Return False
                End If
            End If
            Return True
        End If
    End Function

    Private Sub EmptyField()
        If LoadFlag = False Then
            Me.comboProduct.Text = ""
            Me.txtTOFrom.Text = 0
            Me.txtRate.Text = "0.0000"
            Me.txtNRate.Text = "0.0000"
            Me.txtMonth.Text = Me.comboSrcYr.Text & Format(Val(Me.comboSrcMonth.Text), "00")
            Me.comboAE.Text = ""
            Me.comboAE.SelectedIndex = -1
            Me.comboAE_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            Me.rbNormal.Checked = True
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
            Dim log As String = "'" & GStrloginID & "', GETDATE(), 'D', 'CommRateTblFutAE', '" & _
                dt.Rows(0).Item("ae_no").ToString.Trim & "', '', '', '" & Me.dtgRateTbl.CurrentRow.Cells("rsid").Value & _
                "', '" & dt.Rows(0).Item("comm_month").ToString.Trim & "', '" & GFncSqlQuote(fncGenLog()) & "' "
            cls.DelRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim, log)
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
        If rbFutures.Checked Then
            type += "F"
        ElseIf rbOptions.Checked Then
            type += "O"
        ElseIf rbFutOpt.Checked Then
            type += "B"
        End If
        Return type
    End Function

    Private Sub lsubGoRecord()
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
                        Me.dtgRateTbl.Rows(lintCnt).Cells("product_group").Selected = True
                        Me.dtgRateTbl_SelectionChanged(Nothing, System.EventArgs.Empty)

                        Me.dtgRateTbl.Focus()
                        Exit For
                    End If
                Next
            End If
            ObjRsid = 0
            ae = ""
        End If
    End Sub

    Private Function fncGenLog() As String
        Dim lstrLog As String = ""
        Select Case ActionFlag
            Case "Edit"
                Dim dt As DataTable = cls.GetLatestRecord(Me.dtgRateTbl.CurrentRow.Cells("rsid").Value.ToString.Trim).Tables(0)
                If dt.Rows.Count > 0 Then
                    If Me.txtRate.Text.Trim.Length > 0 And Me.txtRate.Text.Trim <> dt.Rows(0).Item("day_rate").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Day Rate", dt.Rows(0).Item("day_rate").ToString.Trim, Me.txtRate.Text.Trim) & " "
                    End If
                    If Me.txtNRate.Text.Trim.Length > 0 And Me.txtNRate.Text.Trim <> dt.Rows(0).Item("rsid").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Night Rate", dt.Rows(0).Item("night_rate").ToString.Trim, Me.txtNRate.Text.Trim) & " "
                    End If
                    If Me.txtTOFrom.Text.Trim.Length > 0 And CDbl(Me.txtTOFrom.Text.Trim) <> CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim) Then
                        lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(dt.Rows(0).Item("Turnover_from").ToString.Trim), CDbl(Me.txtTOFrom.Text.Trim)) & " "
                    End If
                    If Me.RateType().Trim <> dt.Rows(0).Item("rate_type").ToString.Trim Then
                        lstrLog += cls.GfncOneFieldLog("Rate Type", dt.Rows(0).Item("rate_type").ToString.Trim, RateType().Trim) & " "
                    End If
                End If
            Case "New"
                'If Me.comboAE.Text.Trim.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("ae_no", Me.comboAE.Text.Trim)
                'End If
                If Me.comboProduct.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Product Group", Me.comboProduct.Text.Trim) & " "
                End If
                If Me.txtRate.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Day Rate", Me.txtRate.Text.Trim) & " "
                End If
                If Me.txtNRate.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Night Rate", Me.txtNRate.Text.Trim) & " "
                End If
                'If Me.txtMonth.Text.Length > 0 Then
                '    lstrLog += cls.GfncOneFieldLog("comm_month", txtMonth.Text.Trim)
                'End If
                If Me.txtTOFrom.Text.Trim.Length > 0 Then
                    lstrLog += cls.GfncOneFieldLog("Turnover From", CDbl(Me.txtTOFrom.Text.Trim)) & " "
                End If
                lstrLog += cls.GfncOneFieldLog("Rate Type", RateType())
                lstrLog += cls.GfncOneFieldLog("Commission Type", C_type)
        End Select
        Return lstrLog
    End Function

    Private Function ValidateDuplicate() As Boolean
        Dim condition As String = " and ae_no = '" & Me.comboAE.Text.Trim & "' and product_group = '" & _
            Me.comboProduct.Text.Trim & "' and turnover_from = " & CDbl(Me.txtTOFrom.Text.Trim) & " and comm_month = '" & _
            Me.txtMonth.Text.Trim & "' and comm_type = '" & C_type & "' and rate_type = '" & RateType() & "' "
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

    Private Sub lFnRefreshTurnover()
        Dim comm_month As String = Me.txtMonth.Text
        Dim Rtype As String = RateType()
        Dim ae_num As String = Me.comboAE.Text
        Dim acc As String = ""
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

    Private Sub comboSrchProd_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboSrchProd.SelectedIndexChanged
        If LoadFlag = False Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbSrchConsolidate.CheckedChanged
        If LoadFlag = False Then
            If Me.rbSrchConsolidate.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub cbConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConsolidate.CheckedChanged
        If Me.cbConsolidate.Checked Then
            Me.GroupTradeType.Visible = False
        Else
            GroupTradeType.Visible = True
        End If
    End Sub

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

    Private Sub rbSrchFutOpt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchFutOpt.CheckedChanged
        If LoadFlag = False Then
            If Me.rbSrchFutOpt.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub rbSrchFutures_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchFutures.CheckedChanged
        If LoadFlag = False Then
            If Me.rbSrchFutures.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub rbSrchOptions_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchOptions.CheckedChanged
        If LoadFlag = False Then
            If Me.rbSrchOptions.Checked Then
                btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub ChangeConsolid(ByVal ae_no As String, ByVal mth As String)
        If ae_no.Length > 0 Then
            Dim AE() As DataRow = AeDT.Select("ae_no='" & ae_no & "' and txmonth ='" & mth & "'")
            If AE.Length > 0 Then
                If AE(0).Item("isConsolid") Then
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
                If Me.rbNormal.Checked = Me.rbInternet.Checked Then
                    Me.rbNormal.Checked = True
                End If
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
