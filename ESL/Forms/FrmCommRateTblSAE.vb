Imports System.Data.SqlClient

Public Class FrmCommRateTblSAE

    Dim loadAction As Boolean = True
    Dim cls As New ClsCommRateTableS
    Dim userAction As String = ""
    Dim AEMaster As DataTable

    Private Sub FrmCommRateTblSACC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        lFnLoadAEMaster()
        Me.cboAENo.SelectedIndex = -1
        Me.txtAEName.Text = ""
        Me.cboSearchYear.Focus()
        lFncLoadSearchMonth()
        lFnChangeObjectStatus(False)
        Me.lblTurnover.Text = ""
        loadAction = False
        btnSearch1_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub btnSearch1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If loadAction = False Then
            lFncLoadAeByMonth()
        End If
    End Sub

    Private Sub cboSearchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchYear.SelectedIndexChanged
        If loadAction = False Then
            lFncLoadAeByMonth()
        End If
    End Sub

    Private Sub cboSearchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchMonth.SelectedIndexChanged
        If loadAction = False Then
            lFncLoadAeByMonth()
        End If
    End Sub

    Private Sub rbSrchNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchNormal.CheckedChanged
        If rbSrchNormal.Checked = True And loadAction = False Then
            lFncLoadAeByMonth()
        End If
    End Sub

    Private Sub rbSrchInternet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchInternet.CheckedChanged
        If rbSrchInternet.Checked = True And loadAction = False Then
            lFncLoadAeByMonth()
        End If
    End Sub

    Private Sub rbSrchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAll.CheckedChanged
        If rbSrchAll.Checked = True And loadAction = False Then
            lFncLoadAeByMonth()
        End If
    End Sub
    Private Sub rbConsolidate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbConsolidate.CheckedChanged
        If rbConsolidate.Checked = True And loadAction = False Then
            lFncLoadAeByMonth()
        End If
    End Sub

    Private Sub abTurnover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles abTurnover.LostFocus
        lFnRefreshTurnover()
    End Sub

    Private Sub dgvRateList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRateList.SelectionChanged
        If loadAction = False Then
            lFncAssignField(True)
        End If
    End Sub

    Private Sub rbNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNormal.CheckedChanged
        lFnRefreshTurnover()
    End Sub

    Private Sub rbInternet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInternet.CheckedChanged
        lFnRefreshTurnover()
    End Sub

    Private Sub lFnLoadAEMaster()
        AEMaster = cls.lFncGetAllAEnoList(Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00").Trim).Tables("aeno")
    End Sub
    Private Sub lFncLoadAEno(ByVal txmonth As String)
        If loadAction = False And txmonth <> "" Then
            Me.cboAENo.Items.Clear()
            lFnLoadAEMaster()
            For Each AEdr As DataRow In AEMaster.Rows
                Me.cboAENo.Items.Add(AEdr.Item("ae_no"))
            Next
        End If
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
    '        rate_type = cls.comm_rate_nor
    '    ElseIf (Me.rbSrchInternet.Checked) Then
    '        rate_type = cls.comm_rate_int
    '    ElseIf (Me.rbConsolidate.Checked) Then
    '        rate_type = cls.comm_rate_con
    '    End If
    '    comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
    '    'If (Me.dgvAccList.Rows.Count > 0) Then
    '    '    acc_no = Me.dgvAccList.CurrentRow.Cells("acc_no").Value

    '    '    Me.dgvAEList.DataSource = cls.lFncGetAEList(comm_month, rate_type, acc_no, cls.comm_type_ae)
    '    '    Me.dgvAEList.DataMember = "aeno"

    '    '    Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(Me.dgvAccList.CurrentRow.Cells(0).Value)
    '    End If

    'End Sub

    Private Sub cboAENo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAENo.SelectedIndexChanged, cboAENo.LostFocus
        If loadAction = False Then
            If Me.cboAENo.Text.Trim.Length > 0 Then
                'Me.txtAEName.Text = Me.dgvAEList.CurrentRow.Cells("ae_name_s").Value
                Dim AEdr() As DataRow = AEMaster.Select("ae_no= '" & Me.cboAENo.Text & "'")
                If AEdr.Length > 0 Then
                    Me.txtAEName.Text = AEdr(0).Item("ae_name_s").ToString.Trim
                Else
                    Me.txtAEName.Text = ""
                End If
            Else
                Me.txtAEName.Text = ""
            End If
            If userAction = "A" Or userAction = "E" Then
                ChangeConsolid(Me.cboAENo.Text)
            End If
        End If
    End Sub

    Private Sub lFncLoadRateTable(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal ae_no As String, ByVal comm_type As String)
        Dim formatPrice As String = ""
        Me.dgvRateList.DataSource = cls.lFncGetAERateList(comm_month, rate_type, acc_no, ae_no, Nothing, Nothing, comm_type)
        Me.dgvRateList.DataMember = "rate"
        If Me.dgvAEList.RowCount > 0 Then
            Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dgvAEList.CurrentRow.Cells(0).Value)
        End If
        For i As Integer = 0 To Me.dgvRateList.Rows.Count - 1
            formatPrice = Format(Me.dgvRateList.Rows(i).Cells("turnover_from").Value, "##,###,###,##0.00")
            formatPrice = Mid("                " & formatPrice, formatPrice.Length + 1, 16)
            Me.dgvRateList.Rows(i).Cells("Turnover").Value = ">= " & formatPrice
            If (IsDBNull(Me.dgvRateList.Rows(i).Cells("turnover_to").Value) = False) Then
                formatPrice = Format(Me.dgvRateList.Rows(i).Cells("turnover_to").Value, "##,###,###,###.00")
                formatPrice = Mid("                " & formatPrice, formatPrice.Length + 1, 16)
                Me.dgvRateList.Rows(i).Cells("Turnover").Value = Me.dgvRateList.Rows(i).Cells("Turnover").Value & " and < " & _
                Format(Me.dgvRateList.Rows(i).Cells("turnover_to").Value, "##,###,###,###.00")
            End If
        Next
    End Sub

    Private Sub dgvAEList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEList.SelectionChanged
        If loadAction = False Then
            Dim comm_month As String = ""
            Dim rate_type As String = ""
            Dim acc_no As String = ""
            Dim ae_no As String = ""
            If (Me.rbSrchNormal.Checked) Then
                rate_type = "NOR"
            ElseIf (Me.rbSrchInternet.Checked) Then
                rate_type = "INT"
            ElseIf (Me.rbConsolidate.Checked) Then
                rate_type = cls.comm_rate_con
            End If
            comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
            If dgvAEList.Rows.Count > 0 Then
                ae_no = Me.dgvAEList.CurrentRow.Cells("ae_no").Value
            End If
            lFncLoadRateTable(comm_month, rate_type, acc_no, ae_no, cls.comm_type_ae)
        End If
    End Sub

    Private Sub lFncLoadAeByMonth()
        Dim lds As DataSet = Nothing
        Dim comm_month As String = ""
        Dim rate_type As String = ""
        Dim acc_no As String = ""
        Dim ae_no As String = ""
        If (Me.rbSrchNormal.Checked) Then
            rate_type = cls.comm_rate_nor
        ElseIf (Me.rbSrchInternet.Checked) Then
            rate_type = cls.comm_rate_int
        ElseIf Me.rbConsolidate.Checked Then
            rate_type = cls.comm_rate_con
        End If
        comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        lFncLoadAEno(comm_month)
        ae_no = Me.txtSrcAE.Text.Trim
        Me.dgvAEList.DataSource = cls.lFncGetAEList(comm_month, rate_type, acc_no, cls.comm_type_ae, ae_no)
        Me.dgvAEList.DataMember = "aeno"
        If (Me.dgvAEList.Rows.Count = 0) Then
            lFncAssignField(False)
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
            loadAction = True
            While (Me.dgvRateList.Rows.Count > 0)
                Me.dgvRateList.Rows.RemoveAt(0)
            End While
            loadAction = False
        Else
            Me.dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim rate_type As String = ""
        userAction = "A"
        Me.txtMonth.Text = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        lFncLoadAEno(Me.txtMonth.Text.Trim)
        If Me.dgvAEList.Rows.Count > 0 Then
            Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(dgvAEList.CurrentRow.Cells("ae_no").Value.ToString.Trim)
        Else
            Me.cboAENo.SelectedIndex = -1
        End If
        Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        If (Me.rbSrchInternet.Checked) Then
            Me.rbInternet.Checked = True
            'Me.cbConsolidate.Checked = False
            'ElseIf Me.rbConsolidate.Checked Then
            'Me.cbConsolidate.Checked = True
        Else
            Me.rbNormal.Checked = False
            'Me.cbConsolidate.Checked = True
        End If
        ChangeConsolid(Me.cboAENo.Text)
        'Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
        Me.abTurnover.Text = 0
        Me.rbTurnover.Checked = True
        lFnRefreshTurnover()
        Me.nbCommRate.Text = 0
        Me.nbBrok_rate.Text = 0
        lFnChangeObjectStatus(True)
        Me.cboAENo.Enabled = True
        Me.cboAENo.Focus()
    End Sub

    Private Sub lFnChangeObjectStatus(ByVal status As Boolean)
        Me.cboSearchYear.Enabled = False
        Me.cboSearchMonth.Enabled = False
        Me.rbSrchAll.Enabled = Not status
        Me.rbSrchInternet.Enabled = Not status
        Me.rbSrchNormal.Enabled = Not status
        Me.rbConsolidate.Enabled = Not status
        Me.btnSearch.Enabled = Not status
        Me.dgvAEList.Enabled = Not status
        Me.dgvRateList.Enabled = Not status
        Me.txtSrcAE.Enabled = Not status
        Me.cboAENo.Enabled = False
        Me.rbNormal.Enabled = status
        Me.rbInternet.Enabled = status
        Me.abTurnover.Enabled = status
        Me.rbTurnover.Enabled = status
        Me.rbCommRecd.Enabled = status
        Me.nbCommRate.Enabled = status
        Me.nbBrok_rate.Enabled = status
        Me.cbConsolidate.Enabled = False
        Me.btnNew.Enabled = Not status
        Me.btnEdit.Enabled = Not status
        Me.btnDelete.Enabled = Not status
        Me.btnSave.Enabled = status
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        userAction = "E"
        If (Me.dgvRateList.Rows.Count > 0) Then
            lFnChangeObjectStatus(True)
            ChangeConsolid(Me.cboAENo.Text)
            Me.abTurnover.Focus()
        Else
            GSubShowInfo("no record to edit")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim MyTrans As SqlTransaction = Nothing
        Dim srid As String = ""
        If userAction = "A" Or userAction = "E" Then
            If CDbl(Me.nbCommRate.Text) <> 0 And CDbl(Me.nbBrok_rate.Text) <> 0 Then
                GSubShowInfo(GFncGetSysMsg(74))
                Me.nbCommRate.Focus()
                Return
            End If
            If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                If Me.cboAENo.Text.Trim.Length <= 0 Or Not ValidateAEno(cboAENo.Text.Trim) Then
                    GSubShowInfo(GFncGetSysMsg(31))
                    Me.cboAENo.Focus()
                    Return
                End If
                Dim comm_month As String = Me.txtMonth.Text
                Dim acc_no As String = ""
                Dim ae_no As String = Me.cboAENo.Text
                Dim rate_type As String = ""
                If Me.cbConsolidate.Checked Then
                    rate_type = cls.comm_rate_con
                Else
                    If (Me.rbNormal.Checked) Then
                        rate_type = cls.comm_rate_nor
                    ElseIf (Me.rbInternet.Checked) Then
                        rate_type = cls.comm_rate_int
                    End If
                End If
                Dim range_type As String = "Turnover"
                If (Me.rbCommRecd.Checked) Then
                    range_type = "Comm. Recd"
                End If
                Dim turnover_from As String = Me.abTurnover.Text
                Dim comm_rate As String = Me.nbCommRate.Text
                Dim comm_type As String = cls.comm_type_ae
                Dim brok_rate As String = Me.nbBrok_rate.Text
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
                    range_type) = True) Then
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
                        cls.lFncInsertAERate(acc_no, ae_no, "", rate_type, turnover_from, comm_rate, brok_rate, comm_month, _
                            comm_type, MyTrans, range_type, "CommRateTblSAE")
                    ElseIf (userAction = "E") Then
                        cls.lFncModifyAERate(srid, rate_type, turnover_from, comm_rate, brok_rate, "", "", MyTrans, range_type, _
                            "CommRateTblSAE")
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
                lFncLoadAeByMonth()
                Dim i As Integer = 0
                For i = 0 To Me.dgvAEList.Rows.Count - 1
                    If (Me.dgvAEList.Rows(i).Cells(0).Value = ae_no) Then
                        Me.dgvAEList.Rows(i).Cells(1).Selected = True
                        Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                Next
                Me.dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
                For i = 0 To Me.dgvRateList.Rows.Count - 1
                    If (Me.dgvRateList.Rows(i).Cells(0).Value = srid) Then
                        Me.dgvRateList.Rows(i).Cells(1).Selected = True
                        Me.dgvRateList.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                Next
                lFncAssignField(True)
                Me.cboAENo.Enabled = False
                lFnChangeObjectStatus(False)
            Else
                Return
            End If
        End If
        userAction = ""
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
            If GFncCheckCommStatus() Then
                Return
            End If
            Try
                aeno = Me.dgvAEList.CurrentRow.Cells(0).Value
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
                GFncFillLog(GStrloginID, "D", GDteTradeDate, "CommRateTblSAE", ae, acc, srid, month, logstr, MyTrans)
                MyTrans.Commit()
                MyTrans = Nothing
                Dim comm_month As String = ""
                Dim rate_type As String = ""
                Dim acc_no As String = ""
                Dim ae_no As String = ""
                If (Me.rbSrchNormal.Checked) Then
                    rate_type = cls.comm_rate_nor
                ElseIf (Me.rbSrchInternet.Checked) Then
                    rate_type = cls.comm_rate_int
                ElseIf Me.rbConsolidate.Checked Then
                    rate_type = cls.comm_rate_con
                End If
                comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
                ae_no = Me.dgvAEList.CurrentRow.Cells("ae_no").Value
                GSubShowInfo(GFncGetSysMsg(13))
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try
            lFncLoadAeByMonth()
            Dim i As Integer = 0
            For i = 0 To Me.dgvAEList.Rows.Count - 1
                If (Me.dgvAEList.Rows(i).Cells(0).Value = aeno) Then
                    Me.dgvAEList.Rows(i).Cells(1).Selected = True
                    Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                    Exit For
                End If
            Next
            Me.dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
            If Me.dgvAEList.Rows.Count <= 0 Then
                loadAction = True
                While (Me.dgvRateList.Rows.Count > 0)
                    Me.dgvRateList.Rows.RemoveAt(0)
                End While
                loadAction = False
            End If
        End If
    End Sub

    Private Sub nbCommRate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbCommRate.LostFocus
        If (Me.nbCommRate.Text.Trim.Length = 0) Then
            Me.nbCommRate.Text = 0
        End If
    End Sub


    Private Sub lFncAssignField(ByVal status As Boolean)
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
                Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
                Me.abTurnover.Text = Format(Me.dgvRateList.CurrentRow.Cells("turnover_from").Value, "##,###,###,##0.00")
                If (IsDBNull(Me.dgvRateList.CurrentRow.Cells("turnover_to").Value) = False) Then
                    Me.lblTurnover.Text = "< " & Format(Me.dgvRateList.CurrentRow.Cells("turnover_to").Value, "##,###,###,##0.00")
                Else
                    Me.lblTurnover.Text = ""
                End If
                Me.nbCommRate.Text = Me.dgvRateList.CurrentRow.Cells("comm_rate").Value
                Me.nbBrok_rate.Text = Me.dgvRateList.CurrentRow.Cells("Brokerage_rate").Value
                If (IsNothing(Me.dgvRateList.CurrentRow.Cells("turnover_type").Value) = False) Then
                    If (Me.dgvRateList.CurrentRow.Cells("turnover_type").Value.ToString.Trim = "Comm. Recd") Then
                        Me.rbCommRecd.Checked = True
                    Else
                        Me.rbTurnover.Checked = True
                    End If
                End If
            Else
                Me.txtMonth.Text = ""
                Me.cboAENo.SelectedIndex = -1
                Me.txtAEName.Text = ""
                Me.rbNormal.Checked = True
                Me.abTurnover.Text = ""
                Me.nbCommRate.Text = ""
                Me.lblTurnover.Text = ""
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (userAction = "A") Or (userAction = "E") Then
            Me.cboAENo.Enabled = False
            lFnChangeObjectStatus(False)
            If (Me.dgvAEList.Rows.Count > 0) Then
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(GFncNoNullString(Me.dgvAEList.CurrentRow.Cells(0).Value))
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
        Dim comm_type As String = cls.comm_type_ae
        Dim lds As DataSet = Nothing
        Dim turnoverTo As String = ""
        lds = cls.lFncGetNextComm(comm_month, rate_type, acc_no, ae_no, comm_type, turnover_from)
        If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
            Me.lblTurnover.Text = ""
        Else
            Me.lblTurnover.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,##0.00")
        End If
    End Sub

    Private Sub cbConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConsolidate.CheckedChanged
        If Me.cbConsolidate.Checked Then
            Me.GroupTradeType.Visible = False
        Else
            GroupTradeType.Visible = True
        End If
    End Sub

    Private Sub txtSrcAE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrcAE.LostFocus
        If loadAction = False Then
            lFncLoadAeByMonth()
        End If
    End Sub

    Private Sub nbBrok_rate_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbBrok_rate.LostFocus
        If (Me.nbBrok_rate.Text.Trim.Length = 0) Then
            Me.nbBrok_rate.Text = 0
        End If
    End Sub

    Private Function ValidateAEno(ByVal AE As String) As Boolean
        If AE.Trim.Length > 0 Then
            If AEMaster.Select("ae_no ='" & AE & "'").Length > 0 Then
                Return True
            Else
                Return False
            End If
            Return False
        End If
    End Function

    Private Sub ChangeConsolid(ByVal ae_no As String)
        If ae_no.Length > 0 Then
            Dim AE() As DataRow = AEMaster.Select("ae_no='" & ae_no & "'")
            If AE.Length > 0 Then
                If AE(0).Item("isConsolid") Then
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

End Class
