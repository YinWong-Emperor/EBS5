Imports System.Data.SqlClient

Public Class FrmCommRateTblSAgp

    Dim cls As New ClsCommRateTableS
    Dim AEGroup As DataTable
    Dim AEGpConsolid As DataTable
    Dim userAction As String = ""
    Dim SelectionChange As Boolean = False

    Private Sub FrmCommRateTblSACC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        lFnLoadAEGroup()
        'lFncLoadAccNo()
        lFnLoadAENo()
        Me.cboAENo.SelectedIndex = -1
        Me.txtAEName.Text = ""
        lFncLoadSearchMonth()
        Me.cboSearchYear.Focus()
        lFnChangeObjectStatus(False)
        'lFnLoadAENoCon()
        'Me.cboAENoCon.SelectedIndex = -1
        'Me.txtAENameCon.Text = ""
        'Me.cboSearchYearCon.Focus()
        'lFnChangeObjectStatusCon(False)
        If (Me.dgvAEList.Rows.Count <= 0) Then
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
        End If
    End Sub

    'Private Sub lFncLoadAccNo()
    '    Me.cboAccNo.DataSource = cls.lFnGetAllAccNo(cls.market_sec).Tables(0)
    '    Me.cboAccNo.DisplayMember = "acc_no"
    'End Sub

    Private Sub lFnLoadAENo()
        If Me.cboSearchMonth.Text.Length > 0 And Me.cboSearchYear.Text.Length > 0 Then
            Me.cboAENo.Items.Clear()
            Dim dr() As DataRow = AEGroup.Select("txmonth ='" & Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00") & "'", "ae_no asc")
            For row As Integer = 0 To dr.Length - 1
                Me.cboAENo.Items.Add(dr(row).Item("ae_no"))
            Next
        End If
        'Me.cboAENo.DataSource = cls.lFnGetAllAENo(cls.market_sec, Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")).Tables(0)
        'Me.cboAENo.DisplayMember = "ae_no"
    End Sub

    Private Sub lFncLoadSearchMonth()
        Dim lds As String = ""
        Dim maxYear As Integer = 0
        Dim maxMonth As Integer = 0
        lds = GfncGetMonth()
        If lds.Length > 0 Then
            maxYear = lds.Substring(0, 4)
            maxMonth = Val(lds.Substring(4, 2))
        Else
            maxYear = Now.Year
            maxMonth = Now.Month - 1
        End If
        For i As Integer = maxYear - 3 To maxYear + 3
            Me.cboSearchYear.Items.Add(i)
            'Me.cboSearchYearCon.Items.Add(i)
        Next
        For j As Integer = 1 To 12
            Me.cboSearchMonth.Items.Add(j)
            'Me.cboSearchMonthCon.Items.Add(j)
        Next
        Me.cboSearchYear.SelectedIndex = Me.cboSearchYear.FindString(maxYear)
        Me.cboSearchMonth.SelectedIndex = Me.cboSearchMonth.FindString(maxMonth)
    End Sub

    Private Sub cboSearchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchYear.SelectedIndexChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub lFncLoadAccByMonth()
        Dim lds As DataSet = Nothing
        Dim comm_month As String = ""
        Dim rate_type As String = ""
        Dim ae_group As String = ""
        If Me.cboSrchAEGP.Text.Length > 0 Then
            ae_group = Me.cboSrchAEGP.Text
        End If
        If (Me.rbSrchNormal.Checked) Then
            rate_type = "NOR"
        ElseIf (Me.rbSrchInternet.Checked) Then
            rate_type = "INT"
        ElseIf Me.rbConsolidate.Checked Then
            rate_type = "CON"
        End If
        comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        ' acc_no = Me.txtSrchAccNo.Text
        'Me.dgvAccList.DataSource = cls.lFncGetAccList(comm_month, rate_type, acc_no, cls.comm_type_agp)
        'Me.dgvAccList.DataMember = "accno"
        Me.dgvAEList.DataSource = cls.lFncGetAEgroupDT(rate_type, comm_month, ae_group, cls.comm_type_agp)
        Me.dgvAEList.DataMember = "aegroup"
        lFnLoadAENo()
        If (Me.dgvAEList.Rows.Count = 0) Then
            lFncAssignField(False)
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
            While (Me.dgvRateList.Rows.Count > 0)
                SelectionChange = True
                Me.dgvRateList.Rows.RemoveAt(0)
                SelectionChange = False
            End While
        Else
            Me.dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
        End If
    End Sub

    Private Sub lFncAssignField(ByVal status As Boolean)
        If SelectionChange = False Then
            If (status = True) Then
                If (Me.dgvRateList.Rows.Count > 0) Then
                    Me.txtMonth.Text = Me.dgvRateList.CurrentRow.Cells("comm_month").Value
                    If (Me.dgvRateList.CurrentRow.Cells("misc_desc").Value = "Normal Trade") Then
                        Me.rbNormal.Checked = True
                        Me.cbConsolidate.Checked = False
                    ElseIf (Me.dgvRateList.CurrentRow.Cells("misc_desc").Value = "Internet Trade") Then
                        Me.rbInternet.Checked = True
                        Me.cbConsolidate.Checked = False
                    ElseIf (Me.dgvRateList.CurrentRow.Cells("misc_desc").Value = "Consolidate Trade") Then
                        Me.cbConsolidate.Checked = True
                    End If
                    Me.abTurnover.Text = Format(Me.dgvRateList.CurrentRow.Cells("turnover_from").Value, "##,###,###,##0.00")
                    If (IsDBNull(Me.dgvRateList.CurrentRow.Cells("turnover_to").Value) = False) Then
                        Me.lblTurnover.Text = "< " & Format(Me.dgvRateList.CurrentRow.Cells("turnover_to").Value, "##,###,###,##0.00")
                    Else
                        Me.lblTurnover.Text = ""
                    End If
                    Me.nbCommRate.Text = Me.dgvRateList.CurrentRow.Cells("comm_rate").Value()
                    Me.nbBrok_rate.Text = Me.dgvRateList.CurrentRow.Cells("Brokerage_rate").Value()
                    Me.cboAENo.Text = Me.dgvAEList.CurrentRow.Cells("ae_no").Value
                    Me.cboAEGroup.Text = Me.dgvAEList.CurrentRow.Cells("acc_group").Value
                    If cboAENo.Text <> "" Then
                        Me.txtAEName.Text = Me.dgvAEList.CurrentRow.Cells("ae_name_s").Value
                    Else
                        Me.txtAEName.Text = ""
                    End If
                    Me.btnDelete.Enabled = True
                    Me.btnEdit.Enabled = True
                Else
                    Me.btnDelete.Enabled = False
                    Me.btnEdit.Enabled = False
                End If
            Else
                Me.txtMonth.Text = ""
                'Me.cboAccNo.SelectedIndex = -1
                'Me.txtAccName.Text = ""
                Me.cboAENo.SelectedIndex = -1
                Me.txtAEName.Text = ""
                Me.rbNormal.Checked = True
                Me.abTurnover.Text = ""
                Me.nbCommRate.Text = ""
            End If
        End If
    End Sub

    Private Sub cboSearchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchMonth.SelectedIndexChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub rbSrchNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchNormal.CheckedChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub rbSrchInternet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchInternet.CheckedChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub rbSrchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAll.CheckedChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lFncLoadAccByMonth()
    End Sub

    'Private Sub dgvAccList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    lFnLoadAEList()
    'End Sub

    'Private Sub lFnLoadAEList()
    '    Dim lds As DataSet = Nothing
    '    Dim comm_month As String = ""
    '    Dim rate_type As String = ""
    '    Dim acc_no As String = ""
    '    If (Me.rbSrchNormal.Checked) Then
    '        rate_type = "NOR"
    '    ElseIf (Me.rbSrchInternet.Checked) Then
    '        rate_type = "INT"
    '    End If
    '    comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
    '    If (Me.dgvAccList.Rows.Count > 0) Then
    '        acc_no = Me.dgvAccList.CurrentRow.Cells("acc_no").Value
    '        Me.dgvAEList.DataSource = cls.lFncGetAEList(comm_month, rate_type, acc_no, cls.comm_type_agp)
    '        Me.dgvAEList.DataMember = "aeno"

    '        Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(Me.dgvAccList.CurrentRow.Cells(0).Value)
    '    End If
    'End Sub

    Private Sub dgvAEList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEList.SelectionChanged
        Dim comm_month As String = ""
        Dim rate_type As String = ""
        'Dim acc_no As String = ""
        Dim ae_no As String = ""
        Dim ae_Group As String = ""
        If Me.dgvAEList.Rows.Count > 0 Then
            If (Me.rbSrchNormal.Checked) Then
                rate_type = "NOR"
            ElseIf (Me.rbSrchInternet.Checked) Then
                rate_type = "INT"
            ElseIf Me.rbConsolidate.Checked Then
                rate_type = "CON"
            End If
            comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
            'acc_no = Me.dgvAccList.CurrentRow.Cells("acc_no").Value
            ae_no = Me.dgvAEList.CurrentRow.Cells("ae_no").Value
            ae_Group = Me.dgvAEList.CurrentRow.Cells("acc_group").Value
            lFncLoadRateTable(comm_month, rate_type, Nothing, ae_no, cls.comm_type_agp, ae_Group)
            'Else
            '    lFncLoadRateTable(comm_month, rate_type, Nothing, ae_no, cls.comm_type_agp, aeGroup)
        End If
    End Sub

    Private Sub lFncLoadRateTable(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal ae_no As String, ByVal comm_type As String, ByVal aeGroup As String)
        Dim formatPrice As String = ""
        Me.dgvRateList.DataSource = cls.lFncGetAEGRPRateList(comm_month, rate_type, ae_no, aeGroup, comm_type)
        Me.dgvRateList.DataMember = "rate"
        Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dgvAEList.CurrentRow.Cells(0).Value)
        For i As Integer = 0 To Me.dgvRateList.Rows.Count - 1
            formatPrice = Format(Me.dgvRateList.Rows(i).Cells("turnover_from").Value, "##,###,###,##0.00")
            formatPrice = Mid("                " & formatPrice, formatPrice.Length + 1, 16)
            Me.dgvRateList.Rows(i).Cells("Turnover").Value = ">= " & formatPrice
            If (IsDBNull(Me.dgvRateList.Rows(i).Cells("turnover_to").Value) = False) Then
                formatPrice = Format(Me.dgvRateList.Rows(i).Cells("turnover_to").Value, "##,###,###,##0.00")
                formatPrice = Mid("                " & formatPrice, formatPrice.Length + 1, 16)
                Me.dgvRateList.Rows(i).Cells("Turnover").Value = Me.dgvRateList.Rows(i).Cells("Turnover").Value & " and < " & _
                Format(Me.dgvRateList.Rows(i).Cells("turnover_to").Value, "##,###,###,##0.00")
            End If
        Next
    End Sub

    Private Sub dgvRateList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRateList.SelectionChanged
        lFncAssignField(True)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (userAction = "A") Or (userAction = "E") Then
            userAction = ""
            'Me.cboAccNo.Enabled = False
            Me.cboAENo.Enabled = False
            lFnChangeObjectStatus(False)
            If (Me.dgvAEList.Rows.Count > 0) Then
                ' Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(GFncNoNullString(Me.dgvAccList.CurrentRow.Cells(0).Value))
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(GFncNoNullString(Me.dgvAEList.CurrentRow.Cells(0).Value))
                lFncAssignField(True)
            Else
                lFncAssignField(False)
                Me.btnEdit.Enabled = False
                Me.btnDelete.Enabled = False
            End If
            'ElseIf userAction = "A_Con" Or userAction = "E_Con" Then
            '    userAction = ""
            '    'Me.cboAccNo.Enabled = False
            '    Me.cboAENoCon.Enabled = False

            '    lFnChangeObjectStatusCon(False)

            '    If (Me.dgvAEListCon.Rows.Count > 0) Then
            '        ' Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(GFncNoNullString(Me.dgvAccList.CurrentRow.Cells(0).Value))
            '        Me.cboAENoCon.SelectedIndex = Me.cboAENoCon.FindString(GFncNoNullString(Me.dgvAEListCon.CurrentRow.Cells(0).Value))
            '        lFncAssignFieldCon(True)
            '    Else
            '        lFncAssignFieldCon(False)
            '        Me.btnEditCon.Enabled = False
            '        Me.btnDeleteCon.Enabled = False
            '    End If
            '    ' userAction = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lFnChangeObjectStatus(ByVal status As Boolean)
        Me.cboSearchYear.Enabled = False
        Me.cboSearchMonth.Enabled = False
        Me.cboSrchAEGP.Enabled = Not status
        Me.rbSrchAll.Enabled = Not status
        Me.rbSrchInternet.Enabled = Not status
        Me.rbSrchNormal.Enabled = Not status
        'Me.txtSrchAccNo.Enabled = Not status
        Me.btnSearch.Enabled = Not status
        'Me.dgvAccList.Enabled = Not status
        Me.dgvAEList.Enabled = Not status
        Me.dgvRateList.Enabled = Not status
        Me.rbConsolidate.Enabled = Not status
        Me.cbConsolidate.Enabled = status
        Me.rbNormal.Enabled = status
        Me.rbInternet.Enabled = status
        Me.abTurnover.Enabled = status
        Me.nbCommRate.Enabled = status
        Me.nbBrok_rate.Enabled = status
        If userAction = "A" Then
            Me.cboAENo.Enabled = True
        Else
            Me.cboAENo.Enabled = False
        End If
        Me.cboAEGroup.Enabled = status
        Me.btnNew.Enabled = Not status
        Me.btnEdit.Enabled = Not status
        Me.btnDelete.Enabled = Not status
        Me.btnSave.Enabled = status
    End Sub

    'Private Sub cboAccNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Dim lds As DataSet = Nothing
    '    lds = cls.lFnGetAccName(Me.cboAccNo.Text, cls.market_sec)
    '    If (lds.Tables(0).Rows.Count > 0) Then
    '        Me.txtAccName.Text = lds.Tables(0).Rows(0).Item("acc_name_s")
    '        Me.cboAENo.Text = cls.lFncGetAENo(Me.cboAccNo.Text, Me.txtMonth.Text).Trim
    '        Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
    '        Me.txtAEGroup.Text = cls.lFncGetAEGroup(Me.cboAccNo.Text, Me.txtMonth.Text).Trim
    '    Else
    '        Me.txtAccName.Text = ""
    '        Me.cboAENo.Text = ""
    '        Me.txtAEGroup.Text = ""
    '        Me.txtAEName.Text = ""
    '    End If
    'End Sub

    Private Sub FncGetAeGroupByAE()
        Me.cboAEGroup.Items.Clear()
        Dim ldr() As DataRow = AEGpConsolid.Select("ae_no='" & cboAENo.Text.Trim & "' and txmonth= '" & Me.txtMonth.Text & "'")
        For Each dr As DataRow In ldr
            Me.cboAEGroup.Items.Add(dr.Item("ae_group"))
            Me.cboAEGroup.SelectedIndex = 0
        Next
    End Sub

    Private Sub cboAENo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAENo.SelectedIndexChanged, cboAENo.LostFocus
        If userAction = "A" Then
            Me.cboAEGroup.Text = ""
            If cboAENo.Text.Trim.Length > 0 Then
                Dim ldr() As DataRow
                ldr = AEGroup.Select("ae_no='" & cboAENo.Text.Trim & "'")
                If ldr.Length > 0 Then
                    Me.txtAEName.Text = ldr(0).Item("ae_name_s")
                Else
                    Me.txtAEName.Text = ""
                End If
                FncGetAeGroupByAE()
                Me.cboAEGroup_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            Else
                Me.txtAEName.Text = ""
                Me.cboAEGroup.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub rbNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNormal.CheckedChanged
        lFnRefreshTurnover()
    End Sub

    Private Sub rbInternet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInternet.CheckedChanged
        lFnRefreshTurnover()
    End Sub

    Private Sub lFnRefreshTurnover()
        Dim comm_month As String = Me.txtMonth.Text
        Dim acc_no As String = "" 'Me.cboAccNo.Text
        Dim ae_no As String = Me.cboAENo.Text
        Dim rate_type As String = ""
        If (Me.rbNormal.Checked) Then
            rate_type = cls.comm_rate_nor
        ElseIf (Me.rbInternet.Checked) Then
            rate_type = cls.comm_rate_int
        End If
        Dim turnover_from As String = Me.abTurnover.Text
        If (turnover_from <> "") Then
            turnover_from = CDbl(turnover_from)
        Else
            turnover_from = "0"
        End If
        Dim comm_type As String = cls.comm_type_agp
        Dim lds As DataSet = Nothing
        Dim turnoverTo As String = ""
        lds = cls.lFncGetNextComm(comm_month, rate_type, acc_no, ae_no, comm_type, turnover_from)
        If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
            Me.lblTurnover.Text = ""
        Else
            Me.lblTurnover.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,##0.00")
        End If
    End Sub

    Private Sub abTurnover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles abTurnover.LostFocus
        lFnRefreshTurnover()
    End Sub

    Private Sub nbCommRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbCommRate.LostFocus
        If (Me.nbCommRate.Text.Trim.Length = 0) Then
            Me.nbCommRate.Text = 0
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim rate_type As String = ""
        userAction = "A"
        Me.txtMonth.Text = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        If (Me.dgvAEList.Rows.Count > 0) Then
            'Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(cls.lFnGetAENo(Me.dgvAccList.CurrentRow.Cells(0).Value, cls.market_sec, Me.txtMonth.Text).Tables(0).Rows(0).Item(0).ToString)
            'Dim dt As DataTable = cls.lFnGetAENo(Me.dgvAccList.CurrentRow.Cells(0).Value, cls.market_sec, Me.txtMonth.Text)
            'If dt.Rows.Count > 0 Then
            '    Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(dt.Rows(0).Item(0).ToString)
            'Else
            '    Me.cboAENo.SelectedIndex = 0
            'End If
            'Me.cboAENo.Text = ""
            Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dgvAEList.CurrentRow.Cells("ae_no").Value)
        Else
            'Me.cboAccNo.SelectedIndex = 0
            Me.cboAENo.SelectedIndex = -1
        End If
        Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        If (Me.rbSrchInternet.Checked) Then
            Me.rbInternet.Checked = True
        Else
            Me.rbNormal.Checked = True
        End If
        'If rbConsolidate.Checked = True Then
        'Me.cbConsolidate.Checked = True
        'Else
        'Me.cbConsolidate.Checked = False
        'End If
        ChangeConsolid(Me.cboAENo.Text, Me.cboAEGroup.Text, Me.txtMonth.Text)
        Me.abTurnover.Text = 0
        lFnRefreshTurnover()
        Me.nbCommRate.Text = 0
        Me.nbBrok_rate.Text = 0
        lFnChangeObjectStatus(True)
        'Me.cboAccNo.Enabled = True
        'Me.cboAENo.Enabled = True
        Me.cboAENo.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        userAction = "E"
        If (Me.dgvRateList.Rows.Count > 0) Then
            lFnChangeObjectStatus(True)
            Dim group As String = Me.cboAEGroup.Text
            FncGetAeGroupByAE()
            Me.cboAEGroup.SelectedIndex = Me.cboAEGroup.FindString(group)
            ChangeConsolid(Me.cboAENo.Text, Me.cboAEGroup.Text, Me.txtMonth.Text)
            Me.abTurnover.Focus()
        Else
            GSubShowInfo("no record to edit")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim MyTrans As SqlTransaction = Nothing
        '        Dim lsqlstr As String = ""
        Dim srid As String = ""
        '        Dim i As Integer = 0
        If userAction = "A" Or userAction = "E" Then
            If CDbl(Me.nbBrok_rate.Text) <> 0 And CDbl(Me.nbCommRate.Text) <> 0 Then
                GSubShowInfo(GFncGetSysMsg(74))
                Me.nbCommRate.Focus()
                Return
            End If
            If CDbl(Me.nbBrok_rate.Text) > 100 Then
                GSubShowInfo(GFncGetSysMsg(64))
                Me.nbBrok_rate.Focus()
                Return
            End If
            If CDbl(Me.nbCommRate.Text) > 100 Then
                GSubShowInfo(GFncGetSysMsg(64))
                Me.nbCommRate.Focus()
                Return
            End If
            If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No) Then
                Return
            End If
            'If Me.cboAccNo.Text.Trim.Length <= 0 And cls.lFncValidAC(Me.cboAccNo.Text.Trim) Then
            '    GSubShowInfo(GFncGetSysMsg(12))
            '    Me.cboAccNo.Focus()
            '    Return
            'End If
            If Me.cboAENo.Text.Trim.Length <= 0 Then
                GSubShowInfo(GFncGetSysMsg(31))
                Me.cboAENo.Focus()
                Return
            End If
            If Me.cboAEGroup.Text.Trim.Length <= 0 Then
                GSubShowInfo(GFncGetSysMsg(50))
                Me.cboAEGroup.Focus()
                Return
            End If
            If AEGpConsolid.Select("ae_group='" & Me.cboAEGroup.Text & "' and ae_no='" & Me.cboAENo.Text & "' and txmonth='" & Me.txtMonth.Text & "'").Length <= 0 Then
                GSubShowInfo(GFncGetSysMsg(87))
                Me.cboAEGroup.Focus()
                Return
            End If
            Dim comm_month As String = Me.txtMonth.Text
            Dim acc_no As String = ""
            Dim ae_no As String = Me.cboAENo.Text
            Dim ae_group As String = Me.cboAEGroup.Text
            Dim rate_type As String = ""
            If (Me.rbNormal.Checked) Then
                rate_type = cls.comm_rate_nor
            ElseIf (Me.rbInternet.Checked) Then
                rate_type = cls.comm_rate_int
            End If
            If Me.cbConsolidate.Checked = True Then
                rate_type = cls.comm_rate_con
            End If
            Dim turnover_from As String = Me.abTurnover.Text
            Dim comm_rate As String = Me.nbCommRate.Text
            Dim comm_type As String = cls.comm_type_agp
            Dim Brok_rate As String = Me.nbBrok_rate.Text
            If (Val(Me.nbCommRate.Text) > 100) Then
                GSubShowInfo(GFncGetSysMsg(43))
                Me.nbCommRate.Focus()
                Return
            End If
            If (userAction = "E") Then
                srid = Me.dgvRateList.CurrentRow.Cells(0).Value
            End If
            'check overlap
            If (cls.lFncCheckOverlap(srid, acc_no, ae_no, rate_type, turnover_from, comm_month, Nothing, Nothing, comm_type, _
                Nothing) = True) Then
                GSubShowInfo(GFncGetSysMsg(44))
                Me.abTurnover.Focus()
                Return
            End If
            If GFncCheckCommStatus() Then
                Return
            End If
            Try
                MyTrans = GSCnSqlConn.BeginTransaction
                If (userAction = "A") Then
                    cls.lFncInsertRate(acc_no, ae_no, ae_group, rate_type, turnover_from, comm_rate, Brok_rate, comm_month, comm_type, MyTrans, "CommRateTblSAGP")
                ElseIf (userAction = "E") Then
                    cls.lFncModifyRate(srid, rate_type, turnover_from, comm_rate, Brok_rate, ae_group, "", MyTrans, "CommRateTblSAGP")
                End If
                MyTrans.Commit()
                MyTrans = Nothing
                If (srid.Length = 0) Then
                    srid = cls.lFnGetSRID()
                End If
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try
            'lFncLoadAccByMonth()
            'btnSearch_Click(Nothing, System.EventArgs.Empty)
            lFncLoadAccByMonth()
            Dim i As Integer = 0
            'For i = 0 To Me.dgvAEList.Rows.Count - 1
            '    If (Me.dgvAccList.Rows(i).Cells(0).Value = acc_no) Then
            '        Me.dgvAccList.FirstDisplayedScrollingRowIndex = i
            '        Me.dgvAccList.Rows(i).Cells(0).Selected = True
            '        Exit For
            '    End If
            'Next
            'lFnLoadAEList()
            For i = 0 To Me.dgvAEList.Rows.Count - 1
                If (Me.dgvAEList.Rows(i).Cells(0).Value = ae_no) And (Me.dgvAEList.Rows(i).Cells("acc_group").Value = ae_group) Then
                    Me.dgvAEList.Rows(i).Cells("acc_group").Selected = True
                    Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                    Exit For
                End If
            Next
            dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
            For i = 0 To Me.dgvRateList.Rows.Count - 1
                If (Me.dgvRateList.Rows(i).Cells(0).Value = srid) Then
                    Me.dgvRateList.Rows(i).Cells(1).Selected = True
                    Me.dgvRateList.FirstDisplayedScrollingRowIndex = i
                    Exit For
                End If
            Next
            lFncAssignField(True)
            'Me.cboAccNo.Enabled = False
            Me.cboAENo.Enabled = False
            userAction = ""
            lFnChangeObjectStatus(False)
            'ElseIf userAction = "A_Con" Or userAction = "E_Con" Then
            '    If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No) Then
            '        Return
            '    End If
            '    'If Me.cboAccNo.Text.Trim.Length <= 0 And cls.lFncValidAC(Me.cboAccNo.Text.Trim) Then
            '    '    GSubShowInfo(GFncGetSysMsg(12))
            '    '    Me.cboAccNo.Focus()
            '    '    Return
            '    'End If
            '    If Me.cboAENoCon.Text.Trim.Length <= 0 Then
            '        GSubShowInfo(GFncGetSysMsg(31))
            '        'Me.cboAccNo.Focus()
            '        Return
            '    End If
            '    If Me.cboAEGroupCon.Text.Trim.Length <= 0 Then
            '        GSubShowInfo(GFncGetSysMsg(50))
            '        'Me.cboAccNo.Focus()
            '        Return
            '    End If
            '    Dim comm_month As String = Me.txtMonthCon.Text
            '    Dim acc_no As String = ""
            '    Dim ae_no As String = Me.cboAENoCon.Text
            '    Dim ae_group As String = Me.cboAEGroupCon.Text
            '    Dim rate_type As String = cls.comm_rate_con
            '    Dim turnover_from As String = Me.abTurnoverCon.Text
            '    Dim comm_rate As String = Me.nbCommRateCon.Text
            '    Dim comm_type As String = cls.comm_type_agp

            '    If (Val(Me.nbCommRateCon.Text) > 100) Then
            '        GSubShowInfo(GFncGetSysMsg(43))
            '        Me.nbCommRateCon.Focus()
            '        Return
            '    End If

            '    If (userAction = "E_Con") Then
            '        srid = Me.dgvRateListCon.CurrentRow.Cells("sridCon").Value
            '    End If

            '    'check overlap
            '    If (cls.lFncCheckOverlap(srid, acc_no, ae_no, rate_type, turnover_from, comm_month, Nothing, Nothing, comm_type, Nothing) = True) Then
            '        GSubShowInfo(GFncGetSysMsg(44))
            '        Me.abTurnoverCon.Focus()
            '        Return
            '    End If

            '    Try
            '        MyTrans = GSCnSqlConn.BeginTransaction
            '        If (userAction = "A_Con") Then
            '            cls.lFncInsertRate(acc_no, ae_no, ae_group, rate_type, turnover_from, comm_rate, comm_month, comm_type, MyTrans)
            '        ElseIf (userAction = "E_Con") Then
            '            cls.lFncModifyRate(srid, rate_type, turnover_from, comm_rate, ae_group, MyTrans)
            '        End If

            '        MyTrans.Commit()
            '        MyTrans = Nothing
            '        If (srid.Length = 0) Then
            '            srid = cls.lFnGetSRID()
            '        End If
            '    Catch ex As Exception
            '        If GSCnSqlConn.State <> ConnectionState.Closed Then
            '            If (MyTrans IsNot Nothing) Then
            '                MyTrans.Rollback()
            '            End If
            '            GSubWriteErrLog(ex.Message)
            '        End If
            '    End Try

            '    lFncLoadAccByMonthCon()
            '    Dim i As Integer = 0
            '    For i = 0 To Me.dgvAEListCon.Rows.Count - 1
            '        If (Me.dgvAEListCon.Rows(i).Cells(0).Value = ae_no) Then
            '            Me.dgvAEListCon.Rows(i).Cells(1).Selected = True
            '            Me.dgvAEListCon.FirstDisplayedScrollingRowIndex = i
            '            Exit For
            '        End If
            '    Next
            '    dgvAEListCon_SelectionChanged(Nothing, System.EventArgs.Empty)

            '    For i = 0 To Me.dgvRateListCon.Rows.Count - 1
            '        If (Me.dgvRateListCon.Rows(i).Cells(0).Value = srid) Then
            '            Me.dgvRateListCon.Rows(i).Cells(1).Selected = True
            '            Me.dgvRateListCon.FirstDisplayedScrollingRowIndex = i
            '            Exit For
            '        End If
            '    Next
            '    lFncAssignFieldCon(True)
            '    Me.cboAENoCon.Enabled = False
            '    userAction = ""
            '    lFnChangeObjectStatusCon(False)
        End If
        GSubShowInfo(GFncGetSysMsg(8))
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim MyTrans As SqlTransaction = Nothing
        Dim accno As String = ""
        Dim aeno As String = ""
        If Me.dgvRateList.Rows.Count <= 0 Then
            Return
        End If
        If (GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            Try
                If GFncCheckCommStatus() Then
                    Return
                End If
                'accno = Me.dgvAccList.CurrentRow.Cells(0).Value
                aeno = Me.dgvAEList.CurrentRow.Cells(0).Value
                MyTrans = GSCnSqlConn.BeginTransaction
                Dim srid As Integer = Me.dgvRateList.CurrentRow.Cells("srid").Value
                Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_rate_s where srid = " & srid, MyTrans).Tables(0)
                cls.lFncDeleteRate(srid, MyTrans)
                Dim acc As String = ""
                Dim ae As String = ""
                Dim month As String = ""
                If oldDt.Rows.Count > 0 Then
                    acc = GFncNoNullString(oldDt.Rows(0).Item("acc_no")).Trim
                    ae = GFncNoNullString(oldDt.Rows(0).Item("ae_no")).Trim
                    month = GFncNoNullString(oldDt.Rows(0).Item("comm_month")).Trim
                End If
                Dim logstr As String = GfncOneFieldLog("SRID", srid)
                GFncFillLog(GStrloginID, "D", GDteTradeDate, "CommRateTblSAGP", ae, acc, srid, month, logstr, MyTrans)
                MyTrans.Commit()
                MyTrans = Nothing
                Dim comm_month As String = ""
                Dim rate_type As String = ""
                Dim acc_no As String = ""
                Dim ae_no As String = ""
                If (Me.rbSrchNormal.Checked) Then
                    rate_type = "NOR"
                ElseIf (Me.rbSrchInternet.Checked) Then
                    rate_type = "INT"
                End If
                comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
                'acc_no = Me.dgvAccList.CurrentRow.Cells("acc_no").Value
                ae_no = Me.dgvAEList.CurrentRow.Cells("ae_no").Value
                'lFncLoadRateTable(comm_month, rate_type, acc_no, ae_no, cls.comm_type_acc)
                'lFncLoadAccByMonth()
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                Dim i As Integer = 0
                'For i = 0 To Me.dgvAccList.Rows.Count - 1
                '    If (Me.dgvAccList.Rows(i).Cells(0).Value = accno) Then
                '        Me.dgvAccList.FirstDisplayedScrollingRowIndex = i
                '        Me.dgvAccList.Rows(i).Cells(0).Selected = True
                '        Exit For
                '    End If
                'Next
                'lFnLoadAEList()
                For i = 0 To Me.dgvAEList.Rows.Count - 1
                    If (Me.dgvAEList.Rows(i).Cells(0).Value = aeno) Then
                        Me.dgvAEList.Rows(i).Cells(1).Selected = True
                        Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                Next
                dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
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

    Private Sub lFnLoadAEGroup()
        AEGroup = cls.lFncGetALLAEGroup().Tables(0)
        AEGpConsolid = cls.lFncGetALLAEGroupList().Tables(0)
    End Sub

    '----------------------------------------------------------Consolidate---------------------------------------------------------
    'Private Sub lFnLoadAENoCon()
    '    Me.cboAENoCon.DataSource = cls.lFnGetAllAENo(cls.market_sec).Tables(0)
    '    Me.cboAENoCon.DisplayMember = "ae_no"
    'End Sub

    'Private Sub cboSearchYearCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchYearCon.SelectedIndexChanged
    '    lFncLoadAccByMonthCon()
    'End Sub

    'Private Sub lFncLoadAccByMonthCon()

    '    Dim lds As DataSet = Nothing
    '    Dim comm_month As String = ""
    '    Dim rate_type As String = cls.comm_rate_con
    '    Dim ae_group As String = ""
    '    If Me.cboSrchAEGPCon.Text.Length > 0 Then
    '        ae_group = Me.cboSrchAEGPCon.Text
    '    End If

    '    comm_month = Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00")
    '    ' acc_no = Me.txtSrchAccNo.Text

    '    'Me.dgvAccList.DataSource = cls.lFncGetAccList(comm_month, rate_type, acc_no, cls.comm_type_agp)
    '    'Me.dgvAccList.DataMember = "accno"
    '    Me.dgvAEListCon.DataSource = cls.lFncGetAEgroupDT(rate_type, comm_month, ae_group, cls.comm_type_agp)
    '    Me.dgvAEListCon.DataMember = "aegroup"
    '    If (Me.dgvAEListCon.Rows.Count = 0) Then
    '        lFncAssignFieldCon(False)
    '        Me.btnEditCon.Enabled = False
    '        Me.btnDeleteCon.Enabled = False
    '    Else
    '        Me.btnDeleteCon.Enabled = True
    '        Me.btnEditCon.Enabled = True
    '    End If

    'End Sub

    'Private Sub lFncAssignFieldCon(ByVal status As Boolean)

    '    If (status = True) Then
    '        If (Me.dgvRateListCon.Rows.Count > 0) Then
    '            Me.txtMonthCon.Text = Me.dgvRateListCon.CurrentRow.Cells("comm_monthCon").Value
    '            Me.abTurnoverCon.Text = Format(Me.dgvRateListCon.CurrentRow.Cells("turnover_fromCon").Value, "##,###,###,###.00")
    '            If (IsDBNull(Me.dgvRateListCon.CurrentRow.Cells("turnover_toCon").Value) = False) Then
    '                Me.lblTurnoverCon.Text = "< " & Format(Me.dgvRateListCon.CurrentRow.Cells("turnover_toCon").Value, "##,###,###,###.00")
    '            Else
    '                Me.lblTurnoverCon.Text = ""
    '            End If
    '            Me.nbCommRateCon.Text = Me.dgvRateListCon.CurrentRow.Cells("comm_rateCon").Value()
    '            Me.cboAEGroupCon.Text = Me.dgvAEListCon.CurrentRow.Cells("acc_groupCon").Value
    '            Me.cboAENoCon.Text = Me.dgvAEListCon.CurrentRow.Cells("ae_noCon").Value
    '            Me.txtAENameCon.Text = Me.dgvAEListCon.CurrentRow.Cells("ae_name_sCon").Value
    '            Me.btnDeleteCon.Enabled = True
    '            Me.btnEditCon.Enabled = True
    '        Else
    '            Me.btnDeleteCon.Enabled = False
    '            Me.btnEditCon.Enabled = False
    '        End If
    '    Else
    '        Me.txtMonthCon.Text = ""
    '        'Me.cboAccNo.SelectedIndex = -1
    '        'Me.txtAccName.Text = ""
    '        Me.cboAENoCon.SelectedIndex = -1
    '        Me.txtAENameCon.Text = ""
    '        Me.abTurnoverCon.Text = ""
    '        Me.nbCommRateCon.Text = ""
    '    End If

    'End Sub

    'Private Sub cboSearchMonthCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchMonthCon.SelectedIndexChanged
    '    lFncLoadAccByMonthCon()
    'End Sub

    'Private Sub btnSearchCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCon.Click
    '    lFncLoadAccByMonthCon()
    'End Sub

    'Private Sub dgvAEListCon_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEListCon.SelectionChanged
    '    If Me.dgvAEListCon.Rows.Count > 0 Then
    '        Dim comm_month As String = ""
    '        Dim rate_type As String = cls.comm_rate_con
    '        Dim ae_no As String = ""
    '        Dim aeGroup As String = ""
    '        comm_month = Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00")
    '        ae_no = Me.dgvAEListCon.CurrentRow.Cells("ae_noCon").Value
    '        aeGroup = Me.dgvAEListCon.CurrentRow.Cells("acc_groupCon").Value

    '        lFncLoadRateTableCon(comm_month, rate_type, Nothing, ae_no, cls.comm_type_agp, aeGroup)
    '    End If
    'End Sub

    'Private Sub lFncLoadRateTableCon(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
    '                            ByVal ae_no As String, ByVal comm_type As String, ByVal aeGroup As String)

    '    Dim formatPrice As String = ""

    '    Me.dgvRateListCon.DataSource = cls.lFncGetAEGRPRateList(comm_month, rate_type, ae_no, aeGroup, comm_type)
    '    Me.dgvRateListCon.DataMember = "rate"

    '    Me.cboAENoCon.SelectedIndex = Me.cboAENoCon.FindString(Me.dgvAEListCon.CurrentRow.Cells(0).Value)

    '    For i As Integer = 0 To Me.dgvRateListCon.Rows.Count - 1

    '        formatPrice = Format(Me.dgvRateListCon.Rows(i).Cells("turnover_fromCon").Value, "##,###,###,##0.00")

    '        formatPrice = Mid("                " & formatPrice, formatPrice.Length + 1, 16)
    '        Me.dgvRateListCon.Rows(i).Cells("TurnoverCon").Value = ">= " & formatPrice
    '        If (IsDBNull(Me.dgvRateListCon.Rows(i).Cells("turnover_toCon").Value) = False) Then
    '            formatPrice = Format(Me.dgvRateListCon.Rows(i).Cells("turnover_toCon").Value, "##,###,###,###.00")
    '            formatPrice = Mid("                " & formatPrice, formatPrice.Length + 1, 16)
    '            Me.dgvRateListCon.Rows(i).Cells("TurnoverCon").Value = Me.dgvRateListCon.Rows(i).Cells("TurnoverCon").Value & " and < " & _
    '            Format(Me.dgvRateListCon.Rows(i).Cells("turnover_toCon").Value, "##,###,###,###.00")
    '        End If
    '    Next

    'End Sub

    'Private Sub dgvRateListCon_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRateListCon.SelectionChanged
    '    lFncAssignFieldCon(True)
    'End Sub

    'Private Sub lFnChangeObjectStatusCon(ByVal status As Boolean)

    '    Me.cboSearchYearCon.Enabled = Not status
    '    Me.cboSearchMonthCon.Enabled = Not status
    '    Me.cboSrchAEGPCon.Enabled = Not status

    '    'Me.txtSrchAccNo.Enabled = Not status
    '    Me.btnSearchCon.Enabled = Not status
    '    'Me.dgvAccList.Enabled = Not status
    '    Me.dgvAEListCon.Enabled = Not status
    '    Me.dgvRateListCon.Enabled = Not status
    '    Me.abTurnoverCon.Enabled = status
    '    Me.nbCommRateCon.Enabled = status
    '    If userAction = "A_Con" Then
    '        Me.cboAENoCon.Enabled = True
    '    Else
    '        Me.cboAENoCon.Enabled = False
    '    End If
    '    Me.cboAEGroupCon.Enabled = status

    '    Me.btnNewCon.Enabled = Not status
    '    Me.btnEditCon.Enabled = Not status
    '    Me.btnDeleteCon.Enabled = Not status
    '    Me.btnSave.Enabled = status

    'End Sub

    'Private Sub cboAENoCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAENoCon.SelectedIndexChanged, cboAENoCon.LostFocus
    '    If userAction = "A_Con" Then
    '        Dim lds As DataSet = Nothing

    '        lds = cls.lFnGetAEName(Me.cboAENoCon.Text, cls.market_sec)
    '        If (lds.Tables(0).Rows.Count > 0) Then
    '            Me.txtAENameCon.Text = lds.Tables(0).Rows(0).Item("ae_name_s")
    '        Else
    '            Me.txtAENameCon.Text = ""
    '        End If
    '        Dim AEGPds As DataSet = cls.lFncGetAEGroup(Me.cboAENoCon.Text, Me.txtMonthCon.Text)
    '        Me.cboAEGroup.Items.Clear()
    '        If AEGPds.Tables(0).Rows.Count > 0 Then
    '            For Each dr As DataRow In AEGPds.Tables(0).Rows
    '                Me.cboAEGroupCon.Items.Add(dr.Item("ae_group_s"))
    '            Next
    '        End If
    '    End If
    'End Sub

    'Private Sub lFnRefreshTurnoverCon()

    '    Dim comm_month As String = Me.txtMonthCon.Text
    '    Dim acc_no As String = "" 'Me.cboAccNo.Text
    '    Dim ae_no As String = Me.cboAENoCon.Text
    '    Dim rate_type As String = cls.comm_rate_con
    '    Dim turnover_from As String = Me.abTurnoverCon.Text
    '    If (turnover_from <> "") Then
    '        turnover_from = CDbl(turnover_from)
    '    Else
    '        turnover_from = "0"
    '    End If
    '    Dim comm_type As String = cls.comm_type_agp
    '    Dim lds As DataSet = Nothing
    '    Dim turnoverTo As String = ""

    '    lds = cls.lFncGetNextComm(comm_month, rate_type, acc_no, ae_no, comm_type, turnover_from)
    '    If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
    '        Me.lblTurnoverCon.Text = ""
    '    Else
    '        Me.lblTurnoverCon.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,###.00")
    '    End If

    'End Sub

    'Private Sub abTurnoverCon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles abTurnoverCon.LostFocus
    '    lFnRefreshTurnoverCon()
    'End Sub

    'Private Sub nbCommRateCon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbCommRateCon.LostFocus
    '    If (Me.nbCommRateCon.Text.Trim.Length = 0) Then
    '        Me.nbCommRateCon.Text = 0
    '    End If
    'End Sub

    'Private Sub btnNewCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCon.Click

    '    Dim rate_type As String = ""

    '    userAction = "A_Con"

    '    Me.txtMonthCon.Text = Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00")
    '    If (Me.dgvAEListCon.Rows.Count > 0) Then
    '        Me.cboAENoCon.SelectedIndex = Me.cboAENoCon.FindString(Me.dgvAEListCon.CurrentRow.Cells("ae_noCon").Value)
    '    Else

    '        Me.cboAENoCon.SelectedIndex = -1
    '    End If
    '    Me.abTurnoverCon.Text = 0
    '    lFnRefreshTurnoverCon()
    '    Me.nbCommRateCon.Text = 0

    '    lFnChangeObjectStatusCon(True)
    '    'Me.cboAccNo.Enabled = True
    '    'Me.cboAENo.Enabled = True

    '    Me.cboAENoCon.Focus()

    'End Sub

    'Private Sub btnEditCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditCon.Click

    '    userAction = "E_Con"

    '    If (Me.dgvRateListCon.Rows.Count > 0) Then
    '        lFnChangeObjectStatusCon(True)
    '        Me.abTurnoverCon.Focus()
    '    Else
    '        GSubShowInfo("no record to edit")
    '    End If

    'End Sub

    'Private Sub btnDeleteCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteCon.Click

    '    Dim MyTrans As SqlTransaction = Nothing
    '    Dim accno As String = ""
    '    Dim aeno As String = ""
    '    If Me.dgvRateListCon.Rows.Count <= 0 Then
    '        Return
    '    End If

    '    If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
    '        Try
    '            'accno = Me.dgvAccList.CurrentRow.Cells(0).Value
    '            aeno = Me.dgvAEListCon.CurrentRow.Cells(0).Value
    '            MyTrans = GSCnSqlConn.BeginTransaction
    '            cls.lFncDeleteRate(Me.dgvRateListCon.CurrentRow.Cells("sridCon").Value, MyTrans)
    '            MyTrans.Commit()
    '            MyTrans = Nothing

    '            Dim comm_month As String = ""
    '            Dim rate_type As String = cls.comm_rate_con
    '            Dim acc_no As String = ""
    '            Dim ae_no As String = ""
    '            comm_month = Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00")
    '            ae_no = Me.dgvAEListCon.CurrentRow.Cells("ae_noCon").Value
    '            btnSearchCon_Click(Nothing, System.EventArgs.Empty)

    '            Dim i As Integer = 0
    '            For i = 0 To Me.dgvAEListCon.Rows.Count - 1
    '                If (Me.dgvAEListCon.Rows(i).Cells(0).Value = aeno) Then
    '                    Me.dgvAEListCon.Rows(i).Cells(1).Selected = True
    '                    Me.dgvAEListCon.FirstDisplayedScrollingRowIndex = i
    '                    Exit For
    '                End If
    '            Next
    '            dgvAEListCon_SelectionChanged(Nothing, System.EventArgs.Empty)

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
    'Private Sub lFnLoadAEGroupCon()
    '    Dim GP As DataSet = cls.lFncGetALLAEGroup(Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00"), False)
    '    Me.cboAEGroupCon.Items.Clear()
    '    Me.cboAEGroupCon.Items.Add("")
    '    For Each dr As DataRow In GP.Tables(0).Rows
    '        'Me.cboSrchAEGP.Items.Add(dr.Item("ae_group_s"))
    '        Me.cboAEGroupCon.Items.Add(dr.Item("ae_group_s"))
    '    Next
    'End Sub

    Private Sub rbConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rbConsolidate.CheckedChanged
        If rbConsolidate.Checked = True Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub cbConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConsolidate.CheckedChanged
        If Me.cbConsolidate.Checked Then
            Me.GroupTradeType.Visible = False
        Else
            GroupTradeType.Visible = True
        End If
    End Sub

    Private Sub ChangeConsolid(ByVal ae_no As String, ByVal ae_group As String, ByVal mth As String)
        If ae_no.Length > 0 And ae_group.Length > 0 And mth.Length > 0 Then
            Dim AEgp() As DataRow = AEGpConsolid.Select("ae_no='" & ae_no & "' and ae_group ='" & ae_group & "' and txmonth ='" & mth & "'")
            If AEgp.Length > 0 Then
                If AEgp(0).Item("isConsolid") Then
                    Me.cbConsolidate.Checked = True
                Else
                    Me.cbConsolidate.Checked = False
                    If userAction = "A" Then
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

    Private Sub cboAEGroup_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAEGroup.SelectedIndexChanged
        ChangeConsolid(Me.cboAENo.Text, Me.cboAEGroup.Text, Me.txtMonth.Text)
    End Sub

End Class
