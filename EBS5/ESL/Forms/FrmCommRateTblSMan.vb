Imports System.Data.SqlClient

Public Class FrmCommRateTblSMan

    Dim cls As New ClsCommRateTableS
    Dim userAction As String = ""
    Dim ManagerType As String
    Dim loadflag As Boolean
    Dim ManMaster As DataTable
    Dim SelectionChange As Boolean = False

    Private Sub FrmCommRateTblSACC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        loadflag = True
        ManagerType = "Turnover"
        'lFncLoadAccNo()
        'Me.cboAccNo.SelectedIndex = -1
        'Me.txtAccName.Text = ""
        'lFnLoadAENo()
        'Me.cboAENo.SelectedIndex = -1
        'Me.txtAEName.Text = ""
        lFncLoadSearchMonth()
        Me.cboSearchYear.Focus()
        lFncLoadMan()
        Me.cboManNo.Enabled = False
        lFnChangeObjectStatus(False)
        'Me.cboManNoBg.Enabled = False
        'lFnChangeObjectStatusBg(False)
        Me.lblTurnover.Text = ""
        Me.loadflag = False
        'lFncLoadAccByMonth()
        btnSearch_Click(Nothing, System.EventArgs.Empty)
        'Me.lfncChangeDefaultStatus(False)
        'Me.lFncChangeGridDefault(False)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If Not loadflag Then
            'if Not Me.cbSrchDefault.Checked Then
            lFncLoadAccByMonth()
            'Else
            '    lFncLoadDefByMonth()
            'End If
        End If
    End Sub

    Private Sub cboSearchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchYear.SelectedIndexChanged
        If Not loadflag Then
            'lFncLoadAccByMonth()
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub cboSearchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchMonth.SelectedIndexChanged
        If Not loadflag Then
            'lFncLoadAccByMonth()
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchTurn_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchTurn.CheckedChanged
        If Not loadflag And rbSrchTurn.Checked Then
            'lFncLoadAccByMonth()
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub
    Private Sub rbSrchBrok_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchBrok.CheckedChanged
        If Not loadflag And rbSrchBrok.Checked Then
            'lFncLoadAccByMonth()
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub
    Private Sub rbSrchRebate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchRebate.CheckedChanged
        If Not loadflag And rbSrchRebate.Checked Then
            'lFncLoadAccByMonth()
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAll.CheckedChanged
        If Not loadflag And rbSrchAll.Checked Then
            'lFncLoadAccByMonth()
            btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    'Private Sub cbSrchDefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If Not loadflag Then
    '        'lFncLoadAccByMonth()
    '        btnSearch_Click(Nothing, System.EventArgs.Empty)
    '        lFncChangeGridDefault(Me.cbSrchDefault.Checked)
    '        Me.GroupBoxSrchRateType.Enabled = Not Me.cbSrchDefault.Checked
    '        Me.txtSrchMan.Enabled = Not Me.cbSrchDefault.Checked
    '        Me.cbDefault.Checked = Me.cbSrchDefault.Checked
    '        Me.cbDefault_CheckedChanged(Nothing, System.EventArgs.Empty)
    '    End If
    'End Sub
    'Private Sub lFncChangeGridDefault(ByVal status As Boolean)
    '    If Not loadflag Then
    '        'Me.dgvRateList.Columns("Brokerage_rate").Visible = status
    '        'Me.dgvRateList.Columns("turnover").Visible = Not status
    '        'If status Then
    '        '    Me.dgvRateList.Columns("comm_rate").HeaderText = "Turnover Rate (%)"
    '        'Else
    '        '    Me.dgvRateList.Columns("comm_rate").HeaderText = "Comm. Rate (%)"
    '        'End If
    '        Me.dtgDefault.Visible = status
    '        Me.dgvRateList.Visible = Not status
    '    End If
    'End Sub

    Private Sub abTurnover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles abTurnover.LostFocus
        lFnRefreshTurnover()
    End Sub

    Private Sub dgvRateList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRateList.SelectionChanged
        lFncAssignField(True)
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
            'Me.cboSearchYearBg.Items.Add(i)
        Next
        For j As Integer = 1 To 12
            Me.cboSearchMonth.Items.Add(j)
            'Me.cboSearchMonthBg.Items.Add(j)
        Next
        Me.cboSearchYear.SelectedIndex = Me.cboSearchYear.FindString(maxYear)
        '   Me.cboSearchYearBg.SelectedIndex = Me.cboSearchYear.FindString(maxYear)
        Me.cboSearchMonth.SelectedIndex = Me.cboSearchMonth.FindString(maxMonth)
        '  Me.cboSearchMonthBg.SelectedIndex = Me.cboSearchMonth.FindString(maxMonth)
    End Sub

    Private Sub lFncLoadRateTable(ByVal comm_month As String, ByVal rate_type As String, ByVal manno As String, _
        ByVal manGroup As String, ByVal comm_type As String, ByVal turnoverType As String)
        Dim formatPrice As String = ""
        Me.dgvRateList.DataSource = cls.lFncGetManRateList(comm_month, rate_type, manno, manGroup, comm_type, turnoverType)
        Me.dgvRateList.DataMember = "rate"
        'Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dgvAEList.CurrentRow.Cells(0).Value)
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
        Me.dgvRateList_SelectionChanged(Nothing, System.EventArgs.Empty)
    End Sub

    'Private Sub dgvAEList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEList.SelectionChanged
    '    Dim comm_month As String = ""
    '    Dim rate_type As String = ""
    '    Dim acc_no As String = ""
    '    Dim ae_no As String = ""
    '    If (Me.rbSrchNormal.Checked) Then
    '        rate_type = "NOR"
    '    ElseIf (Me.rbSrchInternet.Checked) Then
    '        rate_type = "INT"
    '    End If
    '    comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
    '    acc_no = Me.dgvAccList.CurrentRow.Cells("acc_no").Value
    '    ae_no = Me.dgvAEList.CurrentRow.Cells("ae_no").Value
    '    lFncLoadRateTable(comm_month, rate_type, acc_no, ae_no, cls.comm_type_man)
    'End Sub

    Private Sub lFncLoadAccByMonth()
        Dim lds As DataSet = Nothing
        Dim comm_month As String = ""
        Dim rate_type As String = ""
        Dim man_no As String = ""
        Dim man_group As String = ""
        Dim turnoverType As String = ""
        Dim DefVal As Boolean = False
        If Me.rbSrchBrok.Checked Then
            rate_type = cls.comm_rate_ManBrok
        ElseIf Me.rbSrchTurn.Checked Then
            rate_type = cls.comm_rate_ManTurn
        ElseIf Me.rbSrchRebate.Checked Then
            rate_type = cls.comm_rate_ManRebate
        End If
        comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        man_no = Me.txtSrchMan.Text
        'DefVal = Me.cbSrchDefault.Checked
        'turnoverType = ManagerType
        Me.dgvManList.DataSource = cls.lFncGetManList(comm_month, rate_type, man_no, man_group, cls.comm_type_man, turnoverType)
        Me.dgvManList.DataMember = "Manno"
        Me.dgvManList_SelectionChanged(Nothing, System.EventArgs.Empty)
        lFncChangeMan(comm_month)
        If (Me.dgvManList.Rows.Count = 0) Then
            lFncAssignField(False)
            SelectionChange = True
            While dgvRateList.Rows.Count > 0
                Me.dgvRateList.Rows.RemoveAt(0)
            End While
            SelectionChange = False
            'Me.btnEdit.Enabled = False
            'Me.btnDelete.Enabled = False
        Else
            'Me.btnDelete.Enabled = True
            'Me.btnEdit.Enabled = True
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim rate_type As String = ""
        userAction = "A"
        Me.cboManNo.Enabled = True
        Me.txtMonth.Text = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        If (Me.dgvManList.Rows.Count > 0) Then
            Me.cboManNo.Text = Me.dgvManList.CurrentRow.Cells("man_no").Value
        Else
            Me.cboManNo.SelectedIndex = -1
        End If
        If (Me.rbSrchBrok.Checked) Then
            Me.rbBrokerage.Checked = True
        ElseIf Me.rbSrchRebate.Checked Then
            Me.rbRebate.Checked = True
        Else
            Me.rbTurnover.Checked = True
        End If
        'If Me.rbConsolidate.Checked = True Then
        '    Me.cbConsolidate.Checked = True
        'Else
        '    Me.cbConsolidate.Checked = False
        'End If
        'Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
        Me.abTurnover.Text = 0
        lFnRefreshTurnover()
        Me.nbCommRate.Text = 0
        'Me.nbBrok_rate.Text = 0
        lFnChangeObjectStatus(True)
        Me.cboManNo.Enabled = True
        'Me.cboAENo.Enabled = True
        'Me.cbDefault_CheckedChanged(Nothing, System.EventArgs.Empty)
        Me.cboManNo.Focus()
    End Sub

    Private Sub lFnChangeObjectStatus(ByVal status As Boolean)
        Me.cboSearchYear.Enabled = False
        Me.cboSearchMonth.Enabled = False
        Me.rbSrchAll.Enabled = Not status
        Me.rbSrchBrok.Enabled = Not status
        Me.rbSrchTurn.Enabled = Not status
        Me.rbSrchRebate.Enabled = Not status
        Me.txtSrchMan.Enabled = Not status
        'Me.cbSrchDefault.Enabled = Not status
        'Me.txtSrchAccNo.Enabled = Not status
        Me.btnSearch.Enabled = Not status
        'Me.dgvAccList.Enabled = Not status
        'Me.dgvAEList.Enabled = Not status
        Me.dgvManList.Enabled = Not status
        Me.dgvRateList.Enabled = Not status
        Me.cboManNo.Enabled = status
        'Me.rbConsolidate.Enabled = Not status
        'Me.cbConsolidate.Enabled = status
        'Me.cboManNo.Enabled = status
        Me.rbBrokerage.Enabled = status
        Me.rbTurnover.Enabled = status
        Me.rbRebate.Enabled = status
        Me.abTurnover.Enabled = status
        Me.nbCommRate.Enabled = status
        'Me.nbBrok_rate.Enabled = status
        'Me.cbDefault.Enabled = False
        Me.btnNew.Enabled = Not status
        Me.btnEdit.Enabled = Not status
        Me.btnDelete.Enabled = Not status
        Me.btnSave.Enabled = status
    End Sub

    'Private Sub lfncChangeDefaultStatus(ByVal status As Boolean)
    '    Me.nbBrok_rate.Visible = status
    '    Me.lblBrok.Visible = status
    '    Me.lblpercent.Visible = status
    '    If userAction = "A" Then
    '        Me.cboManNo.Enabled = Not status
    '        GroupBoxRateType.Enabled = Not status
    '        Me.abTurnover.Enabled = Not status
    '    Else
    '        Me.abTurnover.Enabled = False
    '        Me.cboManNo.Enabled = False
    '        GroupBoxRateType.Enabled = False
    '    End If
    '    If status Then
    '        Me.lblCommRate.Text = "Turnover Rate"
    '    Else
    '        Me.lblCommRate.Text = "Comm. Rate"
    '    End If
    'End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        userAction = "E"
        If (Me.dgvRateList.Rows.Count > 0) Then
            lFnChangeObjectStatus(True)
            'Me.cbDefault.Enabled = False
            'Me.lfncChangeDefaultStatus(Me.cbDefault.Checked)
            Me.abTurnover.Focus()
            'ElseIf (Me.dtgDefault.Rows.Count > 0 And Me.dtgDefault.Visible = True) Then
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
            If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                If (Me.cboManNo.Text.Trim.Length <= 0 Or ManMaster.Select("man_no='" & Me.cboManNo.Text.Trim & _
                    "' and txmonth='" & Me.txtMonth.Text & "'").Length <= 0) Then
                    GSubShowInfo(GFncGetSysMsg(12))
                    Me.cboManNo.Focus()
                    Return
                End If
                Dim comm_month As String = Me.txtMonth.Text
                Dim acc_no As String = ""
                Dim ae_no As String = ""
                Dim rate_type As String = ""
                Dim aeGroup As String = ""
                Dim manno As String = Me.cboManNo.Text
                Dim mangroup As String = ""
                Dim turnoverType As String = ManagerType
                Dim turnover_from As String = 0
                'If Me.cbConsolidate.Checked Then
                '    rate_type = cls.comm_rate_con
                'Else
                'If Me.cbDefault.Checked Then
                '    rate_type = cls.comm_rate_ManDef
                'Else
                If (Me.rbBrokerage.Checked) Then
                    rate_type = cls.comm_rate_ManBrok
                ElseIf (Me.rbTurnover.Checked) Then
                    rate_type = cls.comm_rate_ManTurn
                ElseIf (Me.rbRebate.Checked) Then
                    rate_type = cls.comm_rate_ManRebate
                End If
                turnover_from = Me.abTurnover.Text
                'End If
                'End If
                'rate_type = cls.comm_rate_ManTurn
                Dim comm_rate As String = Me.nbCommRate.Text
                Dim comm_type As String = cls.comm_type_man
                Dim brok_rate As String = 0
                If (Val(Me.nbCommRate.Text) > 100) Then
                    GSubShowInfo(GFncGetSysMsg(64))
                    Me.nbCommRate.Focus()
                    Return
                End If
                'If (Val(brok_rate.Text) > 100 And Me.cbDefault.Checked) Then
                '    GSubShowInfo(GFncGetSysMsg(64))
                '    Me.nbBrok_rate.Focus()
                '    Return
                'End If
                If (userAction = "E") Then
                    srid = Me.dgvRateList.CurrentRow.Cells(0).Value
                End If
                'check overlap
                If (cls.lFncCheckOverlap(srid, acc_no, ae_no, rate_type, turnover_from, comm_month, manno, mangroup, comm_type, _
                    turnoverType) = True) Then
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
                        cls.lFncInsertManRate(acc_no, ae_no, aeGroup, rate_type, turnover_from, comm_rate, brok_rate, _
                            comm_month, comm_type, manno, mangroup, turnoverType, "CommRateTblSMgr", MyTrans)
                    ElseIf (userAction = "E") Then
                        cls.lFncModifyRate(srid, rate_type, turnover_from, comm_rate, brok_rate, aeGroup, mangroup, MyTrans, _
                            "CommRateTblSMgr")
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
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                Dim i As Integer = 0
                For i = 0 To Me.dgvManList.Rows.Count - 1
                    If (Me.dgvManList.Rows(i).Cells("man_no").Value = manno) Then
                        Me.dgvManList.Rows(i).Cells(1).Selected = True
                        Me.dgvManList.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                Next
                Me.dgvManList_SelectionChanged(Nothing, System.EventArgs.Empty)
                For i = 0 To Me.dgvRateList.Rows.Count - 1
                    If (Me.dgvRateList.Rows(i).Cells(0).Value = srid) Then
                        Me.dgvRateList.Rows(i).Cells(1).Selected = True
                        Me.dgvRateList.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                Next
                lFncAssignField(True)
                Me.cboManNo.Enabled = False
                lFnChangeObjectStatus(False)
                userAction = ""
                'Me.cbSrchDefault_CheckedChanged(Nothing, System.EventArgs.Empty)
                GSubShowInfo(GFncGetSysMsg(8))
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim MyTrans As SqlTransaction = Nothing
        'Dim accno As String = ""
        'Dim aeno As String = ""
        Dim manno As String = ""
        If Me.dgvRateList.Rows.Count <= 0 Then
            Return
        End If
        If (GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            If GFncCheckCommStatus() Then
                Return
            End If
            Try
                'accno = Me.dgvAccList.CurrentRow.Cells(0).Value
                'aeno = Me.dgvAEList.CurrentRow.Cells(0).Value
                If dgvManList.Rows.Count > 0 Then
                    manno = Me.dgvManList.CurrentRow.Cells("man_no").Value
                End If
                MyTrans = GSCnSqlConn.BeginTransaction
                Dim srid As Integer = GFncNoNullValue(Me.dgvRateList.CurrentRow.Cells("srid").Value)
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
                GFncFillLog(GStrloginID, "D", GDteTradeDate, "CommRateTblSMgr", ae, acc, srid, month, logstr, MyTrans)
                MyTrans.Commit()
                MyTrans = Nothing
                'Dim comm_month As String = ""
                'Dim rate_type As String = ""
                ''Dim acc_no As String = ""
                ''Dim ae_no As String = ""
                'If (Me.rbSrchNormal.Checked) Then
                '    rate_type = "NOR"
                'ElseIf (Me.rbSrchInternet.Checked) Then
                '    rate_type = "INT"
                'End If
                'comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
                ''acc_no = Me.dgvAccList.CurrentRow.Cells("acc_no").Value
                'ae_no = Me.dgvAEList.CurrentRow.Cells("ae_no").Value
                'lFncLoadRateTable(comm_month, rate_type, acc_no, ae_no, cls.comm_type_man)
                'lFncLoadAccByMonth()
                btnSearch_Click(Nothing, System.EventArgs.Empty)
                Dim i As Integer = 0
                For i = 0 To Me.dgvManList.Rows.Count - 1
                    If (Me.dgvManList.Rows(i).Cells(0).Value = manno) Then
                        Me.dgvManList.FirstDisplayedScrollingRowIndex = i
                        Me.dgvManList.Rows(i).Cells(0).Selected = True
                        Exit For
                    End If
                Next
                Me.dgvManList_SelectionChanged(Nothing, System.EventArgs.Empty)
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

    Private Sub nbCommRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbCommRate.LostFocus
        If (Me.nbCommRate.Text.Trim.Length = 0) Then
            Me.nbCommRate.Text = 0
        End If
    End Sub


    Private Sub lFncAssignField(ByVal status As Boolean)
        If SelectionChange = False Then
            If (status = True) Then
                If (Me.dgvRateList.Rows.Count > 0) Then
                    Me.txtMonth.Text = Me.dgvRateList.CurrentRow.Cells("comm_month").Value
                    If (Me.dgvRateList.CurrentRow.Cells("misc_desc").Value = "Turnover") Then
                        Me.rbTurnover.Checked = True
                        'Me.cbDefault.Checked = False
                    ElseIf (Me.dgvRateList.CurrentRow.Cells("misc_desc").Value = "Brokerage") Then
                        Me.rbBrokerage.Checked = True
                        'Me.cbDefault.Checked = False
                        'ElseIf (Me.dgvRateList.CurrentRow.Cells("misc_desc").Value = "Default") Then
                        'Me.cbDefault.Checked = True
                    ElseIf (Me.dgvRateList.CurrentRow.Cells("misc_desc").Value = "Rebate") Then
                        Me.rbRebate.Checked = True
                    End If
                    'Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
                    Me.abTurnover.Text = Format(Me.dgvRateList.CurrentRow.Cells("turnover_from").Value, "##,###,###,##0.00")
                    If (IsDBNull(Me.dgvRateList.CurrentRow.Cells("turnover_to").Value) = False) Then
                        Me.lblTurnover.Text = "< " & Format(Me.dgvRateList.CurrentRow.Cells("turnover_to").Value, "##,###,###,##0.00")
                    Else
                        Me.lblTurnover.Text = ""
                    End If
                    Me.nbCommRate.Text = Me.dgvRateList.CurrentRow.Cells("comm_rate").Value()
                    'Me.nbBrok_rate.Text = Me.dgvRateList.CurrentRow.Cells("brokerage_rate").Value()
                    If Me.dgvManList.Rows.Count > 0 Then
                        Me.cboManNo.Text = Me.dgvManList.CurrentRow.Cells("Man_no").Value
                        Me.txtManName.Text = GFncNoNullString(Me.dgvManList.CurrentRow.Cells("man_name").Value)
                    Else
                        Me.cboManNo.Text = ""
                        Me.txtManName.Text = ""
                    End If
                    'ElseIf (Me.dtgDefault.Rows.Count > 0 And Me.cbSrchDefault.Checked) Then
                    '    Me.txtMonth.Text = Me.dtgDefault.CurrentRow.Cells("txmonth").Value
                    '    Me.cboManNo.Text = ""
                    '    Me.txtManName.Text = ""
                    '    Me.abTurnover.Text = 0
                    '    Me.nbCommRate.Text = Me.dtgDefault.CurrentRow.Cells("MinNorRate_s").Value()
                    '    Me.nbBrok_rate.Text = Me.dtgDefault.CurrentRow.Cells("commNorRate").Value()
                Else
                    Me.txtMonth.Text = ""
                    Me.cboManNo.Text = ""
                    Me.txtManName.Text = ""
                    Me.abTurnover.Text = ""
                    Me.nbCommRate.Text = ""
                    'Me.nbBrok_rate.Text = ""
                End If
            Else
                Me.txtMonth.Text = ""
                'Me.cboAccNo.SelectedIndex = -1
                'Me.txtAccName.Text = ""
                Me.cboManNo.Text = ""
                Me.txtManName.Text = ""
                'Me.rbNormal.Checked = True
                Me.abTurnover.Text = ""
                Me.nbCommRate.Text = ""
                'Me.nbBrok_rate.Text = ""
                'Me.cbConsolidate.Checked = False
            End If
            'Me.cbDefault_CheckedChanged(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (userAction = "A") Or (userAction = "E") Then
            'Me.cboAccNo.Enabled = False
            Me.cboManNo.Enabled = False
            lFnChangeObjectStatus(False)
            If Me.dgvRateList.Rows.Count > 0 Then
                If (Me.dgvManList.Rows.Count > 0) Then
                    'Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(GFncNoNullString(Me.dgvAccList.CurrentRow.Cells(0).Value))
                    'Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(GFncNoNullString(Me.dgvAEList.CurrentRow.Cells(0).Value))
                    Me.cboManNo.Text = GFncNoNullString(Me.dgvManList.CurrentRow.Cells(0).Value)
                End If
                lFncAssignField(True)
            Else
                lFncAssignField(False)
            End If
            userAction = ""
            'ElseIf (userAction = "A_Bg") Or (userAction = "E_Bg") Then
            '    Me.cboManNoBg.Enabled = False

            '    lFnChangeObjectStatusBg(False)

            '    If (Me.dgvManListBg.Rows.Count > 0) Then
            '        'Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(GFncNoNullString(Me.dgvAccList.CurrentRow.Cells(0).Value))
            '        'Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(GFncNoNullString(Me.dgvAEList.CurrentRow.Cells(0).Value))
            '        Me.cboManNoBg.Text = GFncNoNullString(Me.dgvManListBg.CurrentRow.Cells(0).Value)
            '        lFncAssignFieldBg(True)
            '    Else
            '        lFncAssignFieldBg(False)
            '        Me.btnEditBg.Enabled = False
            '        Me.btnDeleteBg.Enabled = False
            '    End If
            '    userAction = ""
            ' Me.cbSrchDefault_CheckedChanged(Nothing, System.EventArgs.Empty)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lFnRefreshTurnover()
        Dim comm_month As String = Me.txtMonth.Text
        Dim acc_no As String = ""
        Dim ae_no As String = ""
        Dim rate_type As String = ""
        If (Me.rbBrokerage.Checked) Then
            rate_type = cls.comm_rate_ManBrok
        ElseIf (Me.rbTurnover.Checked) Then
            rate_type = cls.comm_rate_ManTurn
        ElseIf (Me.rbRebate.Checked) Then
            rate_type = cls.comm_rate_ManRebate
        End If
        'rate_type = cls.comm_rate_ManTurn
        Dim turnover_from As String = Me.abTurnover.Text
        If (turnover_from <> "") Then
            turnover_from = CDbl(turnover_from)
        Else
            turnover_from = "0"
        End If
        Dim comm_type As String = cls.comm_type_man
        Dim lds As DataSet = Nothing
        Dim turnoverTo As String = ""

        lds = cls.lFncGetNextManComm(comm_month, rate_type, acc_no, ae_no, comm_type, turnover_from)
        If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
            Me.lblTurnover.Text = ""
        Else
            Me.lblTurnover.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,##0.00")
        End If
    End Sub

    Private Sub dgvManList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvManList.SelectionChanged
        Dim txmonth As String = ""
        Dim rateType As String = ""
        Dim manno As String = ""
        Dim mangp As String = ""
        If loadflag = False Then
            If dgvManList.Rows.Count > 0 Then
                'If Not Me.cbSrchDefault.Checked Then
                If (Me.rbSrchBrok.Checked) Then
                    rateType = cls.comm_rate_ManBrok
                ElseIf (Me.rbSrchTurn.Checked) Then
                    rateType = cls.comm_rate_ManTurn
                ElseIf (Me.rbSrchRebate.Checked) Then
                    rateType = cls.comm_rate_ManRebate
                End If
                'Else
                '    rateType = cls.comm_rate_ManDef
                'End If
                txmonth = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
                If dgvManList.Rows.Count > 0 Then
                    If Me.dgvManList.CurrentRow.Cells("man_no").Value <> Nothing Then
                        manno = Me.dgvManList.CurrentRow.Cells("man_no").Value.ToString.Trim
                    End If
                End If
            End If
        End If
        lFncLoadRateTable(txmonth, rateType, manno, mangp, cls.comm_type_man, ManagerType)
    End Sub

    Private Sub cboManNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManNo.SelectedIndexChanged, cboManNo.LostFocus
        If loadflag = False And userAction = "A" Then
            Dim ManDr() As DataRow = ManMaster.Select("man_no='" & Me.cboManNo.Text & "'")
            If ManDr.Length > 0 Then
                Me.txtManName.Text = ManDr(0).Item("man_name")
            Else
                Me.txtManName.Text = ""
            End If
        End If
    End Sub

    Private Sub lFncLoadMan()
        ManMaster = cls.lFnGetAllManNo().Tables(0)
        'Me.cboManNo.Items.Add("")
        'For Each dr As DataRow In dt.Rows
        '    Me.cboManNo.Items.Add(dr.Item("man_no").ToString.Trim)
        '    'Me.cboManNoBg.Items.Add(dr.Item("man_no").ToString.Trim)
        'Next
        lFncChangeMan(Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00"))
    End Sub

    Private Sub lFncChangeMan(ByVal txmonth As String)
        If Me.cboSearchMonth.Text.Length > 0 And Me.cboSearchYear.Text.Length > 0 Then
            Me.cboManNo.Items.Clear()
            Dim Mandr() As DataRow = ManMaster.Select("txmonth='" & txmonth & "' and man_grp =''", "man_no asc")
            For Each dr As DataRow In Mandr
                Me.cboManNo.Items.Add(dr.Item("man_no"))
            Next
        End If
    End Sub

    'Private Sub cbDefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    If loadflag = False Then
    '        lfncChangeDefaultStatus(Me.cbDefault.Checked)
    '    End If
    'End Sub

    'Private Sub lFncLoadDefByMonth()
    '    Dim lds As DataSet = Nothing
    '    Dim comm_month As String = ""
    '    Dim rate_type As String = ""
    '    Dim man_no As String = ""
    '    Dim man_group As String = ""
    '    Dim turnoverType As String = ""
    '    Dim DefVal As Boolean = False
    '    comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
    '    man_no = Me.txtSrchMan.Text
    '    DefVal = Me.cbSrchDefault.Checked
    '    'turnoverType = ManagerType
    '    lFncChangeGridDefault(DefVal)
    '    Me.dgvManList.DataSource = cls.lFncGetManList(comm_month, rate_type, man_no, man_group, cls.comm_type_man, turnoverType, DefVal)
    '    Me.dgvManList.DataMember = "Manno"
    '    Me.dtgDefault.DataSource = cls.GetDefDT(comm_month)
    '    Me.dgvRateList_SelectionChanged(Nothing, System.EventArgs.Empty)
    '    Me.cboManNo.Text = ""
    '    Me.txtManName.Text = ""
    '    lFncChangeMan(comm_month)
    '    lfncChangeDefaultStatus(False)
    '    'If (Me.dgvRateList.Rows.Count = 0) Then
    '    'lFncAssignField(False)
    '    '    Me.btnEdit.Enabled = False
    '    '    Me.btnDelete.Enabled = False
    '    'Else
    '    '    Me.btnDelete.Enabled = True
    '    '    Me.btnEdit.Enabled = True
    '    'End If
    'End Sub

    'Private Sub dtgDefault_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs)
    '    lFncAssignField(True)
    'End Sub

End Class
