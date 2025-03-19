Imports System.Data.SqlClient

Public Class FrmCommRateTblSMgp

    Dim cls As New ClsCommRateTableS
    Dim ManGPDt As DataTable
    Dim userAction As String = ""
    Dim ManMaster As DataTable
    Dim SelectionChange As Boolean = False

    Private Sub FrmCommRateTblSACC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        'lFncLoadAccNo()
        'Me.cboAccNo.SelectedIndex = -1
        'Me.txtAccName.Text = ""
        'lFnLoadAENo()
        'Me.cboAENo.SelectedIndex = -1
        'Me.txtAEName.Text = ""
        lFncLoadMan()
        lFncLoadSearchMonth()
        Me.cboSearchYear.Focus()
        Me.cboManNo.Enabled = False
        lFnChangeObjectStatus(False)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        lFncLoadAccByMonth()
    End Sub

    'Private Sub dgvAccList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAccList.SelectionChanged
    '    lFnLoadAEList()
    'End Sub

    Private Sub cboSearchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchYear.SelectedIndexChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub cboSearchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchMonth.SelectedIndexChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub rbSrchNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchTurn.CheckedChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub rbSrchInternet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchBrok.CheckedChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub rbSrchRebate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchRebate.CheckedChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub rbSrchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAll.CheckedChanged
        lFncLoadAccByMonth()
    End Sub

    Private Sub abTurnover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles abTurnover.LostFocus
        lFnRefreshTurnover()
    End Sub

    Private Sub dgvRateList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRateList.SelectionChanged
        lFncAssignField(True)
    End Sub

    Private Sub rbNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbTurn.CheckedChanged
        lFnRefreshTurnover()
    End Sub

    Private Sub rbInternet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbBrok.CheckedChanged
        lFnRefreshTurnover()
    End Sub

    'Private Sub lFncLoadAccNo()
    '    Me.cboAccNo.Items.Add("")
    '    Dim accDT As DataTable = cls.lFnGetAllAccNo(cls.market_sec).Tables(0)
    '    For i As Integer = 0 To accDT.Rows.Count - 1
    '        Me.cboAccNo.Items.Add(accDT.Rows(i).Item("acc_no").ToString.Trim)
    '    Next
    'End Sub

    'Private Sub lFnLoadAENo()
    '    Me.cboAENo.Items.Add("")
    '    Dim aeDT As DataTable = cls.lFnGetAllAENo(cls.market_sec).Tables(0)
    '    For i As Integer = 0 To aeDT.Rows.Count - 1
    '        Me.cboAENo.Items.Add(aeDT.Rows(i).Item("ae_no").ToString.Trim)
    '    Next
    'End Sub

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
        Next
        For j As Integer = 1 To 12
            Me.cboSearchMonth.Items.Add(j)
        Next
        Me.cboSearchYear.SelectedIndex = Me.cboSearchYear.FindString(maxYear)
        Me.cboSearchMonth.SelectedIndex = Me.cboSearchMonth.FindString(maxMonth)
    End Sub

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

    '        Me.dgvAEList.DataSource = cls.lFncGetAEList(comm_month, rate_type, acc_no, cls.comm_type_mgp)
    '        Me.dgvAEList.DataMember = "aeno"

    '        Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(Me.dgvAccList.CurrentRow.Cells(0).Value)
    '    End If

    'End Sub

    'Private Sub cboAccNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccNo.SelectedIndexChanged, cboAccNo.LostFocus

    '    Dim lds As DataSet = Nothing

    '    lds = cls.lFnGetAccName(Me.cboAccNo.Text, cls.market_sec)
    '    If (lds.Tables(0).Rows.Count > 0) Then
    '        Me.txtAccName.Text = lds.Tables(0).Rows(0).Item("acc_name_s")
    '        Me.cboAENo.Text = cls.lFncGetAENo(Me.cboAccNo.Text, Me.txtMonth.Text)
    '        Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
    '    Else
    '        Me.txtAccName.Text = ""
    '        Me.cboAENo.Text = ""
    '        Me.txtAEName.Text = ""
    '    End If

    'End Sub

    'Private Sub cboAENo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAENo.SelectedIndexChanged, cboAENo.LostFocus

    '    Dim lds As DataSet = Nothing

    '    lds = cls.lFnGetAEName(Me.cboAENo.Text, cls.market_sec)
    '    If (lds.Tables(0).Rows.Count > 0) Then
    '        Me.txtAEName.Text = lds.Tables(0).Rows(0).Item("ae_name_s")
    '    Else
    '        Me.txtAEName.Text = ""
    '    End If

    'End Sub

    Private Sub lFncLoadRateTable(ByVal comm_month As String, ByVal rate_type As String, ByVal manno As String, _
        ByVal manGroup As String, ByVal comm_type As String)
        Dim formatPrice As String = ""
        Me.dgvRateList.DataSource = cls.lFncGetManRateList(comm_month, rate_type, manno, manGroup, comm_type, Nothing)
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
    '    lFncLoadRateTable(comm_month, rate_type, acc_no, ae_no, cls.comm_type_mgp)
    'End Sub

    Private Sub lFncLoadAccByMonth()
        Dim lds As DataSet = Nothing
        Dim comm_month As String = ""
        Dim rate_type As String = ""
        Dim man_no As String = ""
        Dim man_group As String = ""
        If (Me.rbSrchTurn.Checked) Then
            rate_type = cls.comm_rate_ManTurn
        ElseIf (Me.rbSrchBrok.Checked) Then
            rate_type = cls.comm_rate_ManBrok
        ElseIf (Me.rbSrchRebate.Checked) Then
            rate_type = cls.comm_rate_ManRebate
        End If
        comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        man_no = Me.txtSrchMan.Text
        Me.dgvManList.DataSource = cls.lFncGetManList(comm_month, rate_type, man_no, man_group, cls.comm_type_mgp, Nothing)
        Me.dgvManList.DataMember = "Manno"
        Me.lFncChangeMan(comm_month)
        If (Me.dgvManList.Rows.Count = 0) Then
            lFncAssignField(False)
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
            SelectionChange = True
            While Me.dgvRateList.Rows.Count > 0
                Me.dgvRateList.Rows.RemoveAt(0)
            End While
            SelectionChange = False
        Else
            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
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
        'If Me.rbConsolidate.Checked Then
        '    Me.cbConsolidate.Checked = True
        'Else
        '    Me.cbConsolidate.Checked = False
        If (Me.rbSrchBrok.Checked) Then
            Me.rbBrok.Checked = True
        ElseIf (Me.rbSrchRebate.Checked) Then
            Me.rbRebate.Checked = True
        Else
            Me.rbTurn.Checked = True
        End If
        'End If
        ' Me.cbConsolidate_Click(Nothing, System.EventArgs.Empty)
        Me.cboManNo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        Me.abTurnover.Text = 0
        lFnRefreshTurnover()
        Me.nbCommRate.Text = 0
        lFnChangeObjectStatus(True)
        Me.cboManNo.Enabled = True
        'Me.cboAENo.Enabled = True
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
        'Me.txtSrchAccNo.Enabled = Not status
        Me.btnSearch.Enabled = Not status
        'Me.dgvAccList.Enabled = Not status
        'Me.dgvAEList.Enabled = Not status
        Me.dgvRateList.Enabled = Not status
        Me.cboManGroup.Enabled = status
        'Me.cbConsolidate.Enabled = status
        'Me.rbConsolidate.Enabled = Not status
        'Me.cboManNo.Enabled = status
        Me.rbTurn.Enabled = status
        Me.rbBrok.Enabled = status
        Me.rbRebate.Enabled = status
        Me.abTurnover.Enabled = status
        Me.nbCommRate.Enabled = status
        Me.btnNew.Enabled = Not status
        Me.btnEdit.Enabled = Not status
        Me.btnDelete.Enabled = Not status
        Me.btnSave.Enabled = status
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        userAction = "E"
        If (Me.dgvRateList.Rows.Count > 0) Then
            lFnChangeObjectStatus(True)
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
        If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            If Me.cboManNo.Text.Trim.Length <= 0 Or ManMaster.Select("man_no = '" & cboManNo.Text & "' and txmonth = '" & _
                txtMonth.Text & "'").Length <= 0 Then
                GSubShowInfo(GFncGetSysMsg(12))
                Me.cboManNo.Focus()
                Return
            End If
            If Me.cboManGroup.Text.Trim.Length <= 0 Or ManMaster.Select("man_no = '" & cboManNo.Text & "' and txmonth = '" & _
                txtMonth.Text & "' and man_grp = '" & cboManGroup.Text & "'").Length <= 0 Then
                GSubShowInfo(GFncGetSysMsg(75))
                Me.cboManNo.Focus()
                Return
            End If
            Dim comm_month As String = Me.txtMonth.Text
            Dim acc_no As String = ""
            Dim ae_no As String = ""
            Dim rate_type As String = ""
            Dim aeGroup As String = Me.cboManGroup.Text
            Dim manno As String = Me.cboManNo.Text
            Dim mangroup As String = Me.cboManGroup.Text
            'If Me.cbConsolidate.Checked Then
            '    rate_type = cls.comm_rate_con
            'Else
            If (Me.rbTurn.Checked) Then
                rate_type = cls.comm_rate_ManTurn
            ElseIf (Me.rbBrok.Checked) Then
                rate_type = cls.comm_rate_ManBrok
            ElseIf (Me.rbRebate.Checked) Then
                rate_type = cls.comm_rate_ManRebate
            End If
            'End If
            Dim turnover_from As String = Me.abTurnover.Text
            Dim comm_rate As String = Me.nbCommRate.Text
            Dim comm_type As String = cls.comm_type_mgp
            Dim brok_rate As String = 0
            If (Val(Me.nbCommRate.Text) > 100) Then
                GSubShowInfo(GFncGetSysMsg(43))
                Me.nbCommRate.Focus()
                Return
            End If
            If (userAction = "E") Then
                srid = Me.dgvRateList.CurrentRow.Cells(0).Value
            End If
            'check overlap
            If (cls.lFncCheckOverlap(srid, acc_no, ae_no, rate_type, turnover_from, comm_month, manno, mangroup, comm_type, _
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
                    cls.lFncInsertManRate(acc_no, ae_no, aeGroup, rate_type, turnover_from, comm_rate, brok_rate, comm_month, _
                        comm_type, manno, mangroup, Nothing, "CommRateTblSMgp", MyTrans)
                ElseIf (userAction = "E") Then
                    cls.lFncModifyRate(srid, rate_type, turnover_from, comm_rate, brok_rate, aeGroup, mangroup, MyTrans, _
                        "CommRateTblSMgp")
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
            lFncLoadAccByMonth()
            Dim i As Integer = 0
            For i = 0 To Me.dgvManList.Rows.Count - 1
                If (Me.dgvManList.Rows(i).Cells("man_no").Value = manno) Then
                    Me.dgvManList.Rows(i).Cells("man_group").Selected = True
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
            GSubShowInfo(GFncGetSysMsg(8))
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
                manno = Me.dgvManList.CurrentRow.Cells("man_no").Value
                MyTrans = GSCnSqlConn.BeginTransaction
                Dim srid As Integer = GFncNoNullValue(Me.dgvRateList.CurrentRow.Cells("srid").Value)
                Dim oldDt As DataTable = GFncRtnDS(GSCnSqlConn, "select * from draft_comm_rate_s where srid = " & srid, _
                    MyTrans).Tables(0)
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
                GFncFillLog(GStrloginID, "D", GDteTradeDate, "CommRateTblSMgp", ae, acc, srid, month, logstr, MyTrans)
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
                'lFncLoadRateTable(comm_month, rate_type, acc_no, ae_no, cls.comm_type_mgp)
                lFncLoadAccByMonth()
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
                        Me.rbTurn.Checked = True
                    ElseIf (Me.dgvRateList.CurrentRow.Cells("misc_desc").Value = "Brokerage") Then
                        Me.rbBrok.Checked = True
                    ElseIf (Me.dgvRateList.CurrentRow.Cells("misc_desc").Value = "Rebate") Then
                        Me.rbRebate.Checked = True
                    End If
                    Me.abTurnover.Text = Format(Me.dgvRateList.CurrentRow.Cells("turnover_from").Value, "##,###,###,##0.00")
                    If (IsDBNull(Me.dgvRateList.CurrentRow.Cells("turnover_to").Value) = False) Then
                        Me.lblTurnover.Text = "< " & Format(Me.dgvRateList.CurrentRow.Cells("turnover_to").Value, "##,###,###,##0.00")
                    Else
                        Me.lblTurnover.Text = ""
                    End If
                    Me.nbCommRate.Text = Me.dgvRateList.CurrentRow.Cells("comm_rate").Value()
                    Me.cboManNo.Text = Me.dgvManList.CurrentRow.Cells("Man_no").Value
                    Me.txtManName.Text = GFncNoNullString(Me.dgvManList.CurrentRow.Cells("man_name").Value)
                    Me.cboManGroup.Text = GFncNoNullString(Me.dgvManList.CurrentRow.Cells("man_group").Value)
                End If
            Else
                Me.txtMonth.Text = ""
                'Me.cboAccNo.SelectedIndex = -1
                'Me.txtAccName.Text = ""
                'Me.cboAENo.SelectedIndex = -1
                'Me.txtAEName.Text = ""
                Me.rbTurn.Checked = True
                Me.abTurnover.Text = ""
                Me.nbCommRate.Text = ""
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (userAction = "A") Or (userAction = "E") Then
            'Me.cboAccNo.Enabled = False
            Me.cboManNo.Enabled = False
            lFnChangeObjectStatus(False)
            If (Me.dgvManList.Rows.Count > 0) Then
                'Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(GFncNoNullString(Me.dgvAccList.CurrentRow.Cells(0).Value))
                'Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(GFncNoNullString(Me.dgvAEList.CurrentRow.Cells(0).Value))
                Me.cboManNo.Text = GFncNoNullString(Me.dgvManList.CurrentRow.Cells(0).Value)
                lFncAssignField(True)
            Else
                lFncAssignField(False)
                Me.btnEdit.Enabled = False
                Me.btnDelete.Enabled = False
            End If
            userAction = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lFnRefreshTurnover()
        Dim comm_month As String = Me.txtMonth.Text
        Dim acc_no As String = ""
        Dim ae_no As String = ""
        Dim rate_type As String = ""
        If (Me.rbTurn.Checked) Then
            rate_type = cls.comm_rate_ManTurn
        ElseIf (Me.rbBrok.Checked) Then
            rate_type = cls.comm_rate_ManBrok
        ElseIf (Me.rbRebate.Checked) Then
            rate_type = cls.comm_rate_ManRebate
        End If
        Dim turnover_from As String = Me.abTurnover.Text
        If (turnover_from <> "") Then
            turnover_from = CDbl(turnover_from)
        Else
            turnover_from = "0"
        End If
        Dim comm_type As String = cls.comm_type_mgp
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
        If dgvManList.Rows.Count > 0 Then
            If (Me.rbSrchTurn.Checked) Then
                rateType = cls.comm_rate_ManTurn
            ElseIf (Me.rbSrchBrok.Checked) Then
                rateType = cls.comm_rate_ManBrok
            ElseIf (Me.rbSrchRebate.Checked) Then
                rateType = cls.comm_rate_ManRebate
            End If
            txmonth = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
            manno = Me.dgvManList.CurrentRow.Cells("man_no").Value.ToString.Trim
            mangp = Me.dgvManList.CurrentRow.Cells("man_group").Value.ToString.Trim
        End If
        lFncLoadRateTable(txmonth, rateType, manno, mangp, cls.comm_type_mgp)
    End Sub

    Private Sub cboManNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboManNo.SelectedIndexChanged, cboManNo.LostFocus
        If userAction <> "" Then
            If Me.cboManNo.Text.Length > 0 Then
                GetManNameByManno(Me.cboManNo.Text)
                GetManGroupByManno(Me.cboManNo.Text, Me.txtMonth.Text)
            End If
        End If
    End Sub

    Private Sub lFncLoadMan()
        ManMaster = cls.lFnGetAllManNo().Tables(0)
        ManGPDt = cls.GetManGP()
        'lFncChangeMan(Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00"))
    End Sub

    Private Sub lFncChangeMan(ByVal txmonth As String)
        If Me.cboSearchMonth.Text.Length > 0 And Me.cboSearchYear.Text.Length > 0 Then
            Me.cboManNo.Items.Clear()
            Dim Mandr() As DataRow = ManGPDt.Select("txmonth='" & txmonth & "'", "man_no asc")
            For Each dr As DataRow In Mandr
                Me.cboManNo.Items.Add(dr.Item("man_no"))
            Next
        End If
    End Sub
    Private Sub GetManGroupByManno(ByVal Manno As String, ByVal Month As String)
        Me.cboManGroup.Items.Clear()
        If Me.cboManNo.Text.Trim.Length > 0 Then
            Dim dr() As DataRow = ManMaster.Select("man_no ='" & Manno & "' and txmonth='" & Month & "'", "man_grp asc")
            For row As Integer = 0 To dr.Length - 1
                Me.cboManGroup.Items.Add(dr(row).Item("man_grp"))
            Next
        End If
    End Sub

    Private Sub GetManNameByManno(ByVal Manno As String)
        Me.txtManName.Text = ""
        If Me.cboManNo.Text.Trim.Length > 0 Then
            Dim dr() As DataRow = ManMaster.Select("man_no ='" & Manno & "'")
            If dr.Length > 0 Then
                Me.txtManName.Text = dr(0).Item("man_name")
            End If
        End If
    End Sub

End Class
