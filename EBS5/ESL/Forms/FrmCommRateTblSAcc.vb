Imports System.Data.SqlClient

Public Class FrmCommRateTblSACC

    Dim cls As New ClsCommRateTableS
    Dim userAction As String = ""
    Dim loadAction As Boolean
    Dim AccDT As DataTable
    Dim aeDT As DataTable

    Private Sub FrmCommRateTblSACC_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        loadAction = True
        'lFncLoadAccNo()
        'lFncLoadAccNoCon()
        Me.cboAccNo.SelectedIndex = -1
        'Me.cboAccNoCon.SelectedIndex = -1
        Me.txtAccName.Text = ""
        'Me.txtAccNameCon.Text = ""
        'lFnLoadAENo()
        'lFnLoadAENoCon()
        Me.cboAENo.SelectedIndex = -1
        'Me.cboAENoCon.SelectedIndex = -1
        'Me.txtAENameCon.Text = ""
        Me.txtAEName.Text = ""
        'lFncLoadSearchMonthcon()
        Me.cboSearchYear.Focus()
        lFncLoadSearchMonth()
        lFnChangeObjectStatus(False)
        Me.lblTurnover.Text = ""
        loadAction = False
        btnSearch1_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub btnSearch1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If loadAction = False Then
            lFncLoadAccByMonth()
        End If
    End Sub

    Private Sub dgvAccList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAccList.SelectionChanged
        If loadAction = False Then
            lFnLoadAEList()
        End If
    End Sub

    Private Sub cboSearchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchYear.SelectedIndexChanged
        If loadAction = False Then
            lFncLoadAccByMonth()
        End If
    End Sub

    Private Sub cboSearchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchMonth.SelectedIndexChanged
        If loadAction = False Then
            lFncLoadAccByMonth()
        End If
    End Sub

    Private Sub rbSrchNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchNormal.CheckedChanged
        If rbSrchNormal.Checked = True And loadAction = False Then
            lFncLoadAccByMonth()
        End If
    End Sub

    Private Sub rbSrchInternet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchInternet.CheckedChanged
        If rbSrchInternet.Checked = True And loadAction = False Then
            lFncLoadAccByMonth()
        End If
    End Sub

    Private Sub rbSrchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAll.CheckedChanged
        If rbSrchAll.Checked = True And loadAction = False Then
            lFncLoadAccByMonth()
        End If
    End Sub
    Private Sub rbConsolidate_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbConsolidate.CheckedChanged
        If rbConsolidate.Checked = True And loadAction = False Then
            lFncLoadAccByMonth()
        End If
    End Sub

    Private Sub abTurnover_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles abTurnover.LostFocus
        lFnRefreshTurnover()
    End Sub

    Private Sub dgvRateList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRateList.SelectionChanged
        lFncAssignField(True)
    End Sub

    Private Sub rbNormal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbNormal.CheckedChanged
        lFnRefreshTurnover()
    End Sub

    Private Sub rbInternet_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbInternet.CheckedChanged
        lFnRefreshTurnover()
    End Sub

    Private Sub lFncLoadAccNo(ByVal strMonth As String)
        AccDT = cls.lFnGetAllAccNo(strMonth).Tables(0)
        Me.cboAccNo.Items.Clear()
        For i As Integer = 0 To AccDT.Rows.Count - 1
            Me.cboAccNo.Items.Add(AccDT.Rows(i).Item("acc_no").ToString.Trim)
        Next
    End Sub

    Private Sub lFnLoadAENo()
        ' Me.cboAENo.Items.Add("")
        Dim comm_month As String = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        aeDT = cls.lFnGetAllAENo(cls.market_sec, comm_month).Tables(0)
        'For i As Integer = 0 To aeDT.Rows.Count - 1
        '    Me.cboAENo.Items.Add(aeDT.Rows(i).Item("ae_no").ToString.Trim)
        'Next
        Me.cboAENo.DataSource = aeDT
        Me.cboAENo.DisplayMember = "ae_no"
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
            maxMonth = Now.Month
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

    Private Sub lFnLoadAEList()
        Dim lds As DataSet = Nothing
        Dim comm_month As String = ""
        Dim rate_type As String = ""
        Dim acc_no As String = ""
        If (Me.rbSrchNormal.Checked) Then
            rate_type = cls.comm_rate_nor
        ElseIf (Me.rbSrchInternet.Checked) Then
            rate_type = cls.comm_rate_int
        ElseIf (Me.rbConsolidate.Checked) Then
            rate_type = cls.comm_rate_con
        End If
        comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        If (Me.dgvAccList.Rows.Count > 0) Then
            acc_no = Me.dgvAccList.CurrentRow.Cells("acc_no").Value
            Me.dgvAEList.DataSource = cls.lFncGetAEList(comm_month, rate_type, acc_no, cls.comm_type_acc)
            Me.dgvAEList.DataMember = "aeno"
            Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(Me.dgvAccList.CurrentRow.Cells(0).Value)
        End If
    End Sub

    Private Sub cboAccNo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccNo.SelectedIndexChanged, cboAccNo.LostFocus
        Dim ldr() As DataRow
        ldr = AccDT.Select("acc_no ='" & Me.cboAccNo.Text & "' ")
        If (ldr.Length > 0) Then
            Me.txtAccName.Text = ldr(0).Item("acc_name_s")
            Me.cboAENo.Text = cls.lFncGetAENo(Me.cboAccNo.Text, Me.txtMonth.Text)
            Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        Else
            Me.txtAccName.Text = ""
            Me.cboAENo.Text = ""
            Me.txtAEName.Text = ""
        End If
        If userAction = "A" Or userAction = "E" Then
            ChangeConsolid(Me.cboAccNo.Text)
        End If
    End Sub

    Private Sub cboAENo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAENo.SelectedIndexChanged, cboAENo.LostFocus
        Dim lds As DataSet = Nothing
        lds = cls.lFnGetAEName(Me.cboAENo.Text, cls.market_sec)
        If (lds.Tables(0).Rows.Count > 0) Then
            Me.txtAEName.Text = lds.Tables(0).Rows(0).Item("ae_name_s")
        Else
            Me.txtAEName.Text = ""
        End If
        'If userAction = "BA" Or userAction = "BE" Then
        'ChangeAEConsolid(Me.cboAENo.Text)
        'End If
    End Sub

    Private Sub lFncLoadRateTable(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
        ByVal ae_no As String, ByVal comm_type As String)
        Dim formatPrice As String = ""
        Me.dgvRateList.DataSource = cls.lFncGetRateList(comm_month, rate_type, acc_no, ae_no, Nothing, Nothing, comm_type)
        Me.dgvRateList.DataMember = "rate"
        Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dgvAEList.CurrentRow.Cells(0).Value)
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
            acc_no = Me.dgvAccList.CurrentRow.Cells("acc_no").Value
            ae_no = Me.dgvAEList.CurrentRow.Cells("ae_no").Value
            lFncLoadRateTable(comm_month, rate_type, acc_no, ae_no, cls.comm_type_acc)
        End If
    End Sub

    Private Sub lFncLoadAccByMonth()
        Dim lds As DataSet = Nothing
        Dim comm_month As String = ""
        Dim rate_type As String = ""
        Dim acc_no As String = ""
        Dim ae_no As String
        If (Me.rbSrchNormal.Checked) Then
            rate_type = cls.comm_rate_nor
        ElseIf (Me.rbSrchInternet.Checked) Then
            rate_type = cls.comm_rate_int
        ElseIf Me.rbConsolidate.Checked Then
            rate_type = cls.comm_rate_con
        End If
        comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        lFncLoadAccNo(comm_month)
        lFnLoadAENo()
        acc_no = Me.txtSrchAccNo.Text.Trim
        ae_no = Me.txtSrcAE.Text.Trim
        Me.dgvAccList.DataSource = cls.lFncGetAccList(comm_month, rate_type, acc_no, cls.comm_type_acc, ae_no)
        Me.dgvAccList.DataMember = "accno"
        If (Me.dgvAccList.Rows.Count = 0) Then
            lFncAssignField(False)
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
            loadAction = True
            While (dgvAEList.Rows.Count > 0)
                Me.dgvAEList.Rows.RemoveAt(0)
            End While
            While (Me.dgvRateList.Rows.Count > 0)
                Me.dgvRateList.Rows.RemoveAt(0)
            End While
            loadAction = False
        Else
            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim rate_type As String = ""
        userAction = "A"
        Me.txtMonth.Text = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        lFncLoadAccNo(Me.txtMonth.Text)
        If (Me.dgvAccList.Rows.Count > 0) Then
            Dim dt As DataTable = cls.lFnGetAENo(Me.dgvAccList.CurrentRow.Cells(0).Value, cls.market_sec, Me.txtMonth.Text)
            If dt.Rows.Count > 0 Then
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(dt.Rows(0).Item(0).ToString)
            Else
                Me.cboAENo.SelectedIndex = 0
            End If
            'Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(cls.lFnGetAENo(Me.dgvAccList.CurrentRow.Cells(0).Value, cls.market_sec, Me.txtMonth.Text).Tables(0).Rows(0).Item(0).ToString)
        Else
            Me.cboAccNo.SelectedIndex = -1
            Me.cboAENo.SelectedIndex = -1
        End If
        If (Me.rbSrchInternet.Checked) Then
            Me.rbInternet.Checked = True
            'Me.cbConsolidate.Checked = False
            'ElseIf Me.rbConsolidate.Checked Then
            'Me.cbConsolidate.Checked = True
        Else
            Me.rbNormal.Checked = False
            'Me.cbConsolidate.Checked = True
        End If
        ChangeConsolid(Me.cboAccNo.Text)
        'Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
        Me.abTurnover.Text = 0
        lFnRefreshTurnover()
        Me.nbCommRate.Text = 0
        Me.nbBrok_rate.Text = 0
        lFnChangeObjectStatus(True)
        Me.cboAccNo.Enabled = True
        'Me.cboAENo.Enabled = True
        Me.cboAccNo.Focus()
    End Sub

    Private Sub lFnChangeObjectStatus(ByVal status As Boolean)
        Me.cboSearchYear.Enabled = False
        Me.cboSearchMonth.Enabled = False
        Me.rbSrchAll.Enabled = Not status
        Me.rbSrchInternet.Enabled = Not status
        Me.rbSrchNormal.Enabled = Not status
        Me.rbConsolidate.Enabled = Not status
        Me.txtSrchAccNo.Enabled = Not status
        Me.btnSearch.Enabled = Not status
        Me.dgvAccList.Enabled = Not status
        Me.dgvAEList.Enabled = Not status
        Me.dgvRateList.Enabled = Not status
        Me.txtSrcAE.Enabled = Not status
        Me.cboAccNo.Visible = True
        Me.txtAccName.Visible = True
        Me.lblAcc.Visible = True
        Me.cboAENo.Enabled = False
        Me.rbNormal.Enabled = status
        Me.rbInternet.Enabled = status
        Me.abTurnover.Enabled = status
        Me.nbCommRate.Enabled = status
        Me.nbBrok_rate.Enabled = status
        If userAction = "BA" Or userAction = "BE" Then
            Me.cbConsolidate.Enabled = status
        Else
            Me.cbConsolidate.Enabled = False
        End If
        Me.btnNew.Enabled = Not status
        Me.btnEdit.Enabled = Not status
        Me.btnDelete.Enabled = Not status
        Me.btnBDelete.Enabled = Not status
        Me.btnSave.Enabled = status
        Me.btnBEdit.Enabled = Not status
        Me.btnBNew.Enabled = Not status
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        userAction = "E"
        If (Me.dgvRateList.Rows.Count > 0) Then
            lFnChangeObjectStatus(True)
            ChangeConsolid(Me.cboAccNo.Text)
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
                If Me.cboAccNo.Text.Trim.Length <= 0 And cls.lFncValidAC(Me.cboAccNo.Text.Trim) Then
                    GSubShowInfo(GFncGetSysMsg(12))
                    Me.cboAccNo.Focus()
                    Return
                End If
                If Me.cboAENo.Text.Trim.Length <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(31))
                    Me.cboAccNo.Focus()
                    Return
                End If
                Dim comm_month As String = Me.txtMonth.Text
                Dim acc_no As String = Me.cboAccNo.Text
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

                Dim turnover_from As String = Me.abTurnover.Text
                Dim comm_rate As String = Me.nbCommRate.Text
                Dim comm_type As String = cls.comm_type_acc
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
                If cls.lFncCheckOverlap(srid, acc_no, ae_no, rate_type, turnover_from, comm_month, Nothing, Nothing, comm_type, _
                    Nothing) = True Then
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
                        cls.lFncInsertRate(acc_no, ae_no, "", rate_type, turnover_from, comm_rate, brok_rate, comm_month, _
                            comm_type, MyTrans, "CommRateTblSACC")
                    ElseIf (userAction = "E") Then
                        cls.lFncModifyRate(srid, rate_type, turnover_from, comm_rate, brok_rate, "", "", MyTrans, _
                            "CommRateTblSACC")
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
                For i = 0 To Me.dgvAccList.Rows.Count - 1
                    If (Me.dgvAccList.Rows(i).Cells(0).Value = acc_no) Then
                        Me.dgvAccList.FirstDisplayedScrollingRowIndex = i
                        Me.dgvAccList.Rows(i).Cells(0).Selected = True
                        Exit For
                    End If
                Next
                lFnLoadAEList()
                If (i < Me.dgvAccList.Rows.Count) Then
                    For i = 0 To Me.dgvAEList.Rows.Count - 1
                        If (Me.dgvAEList.Rows(i).Cells(0).Value = ae_no) Then
                            Me.dgvAEList.Rows(i).Cells(1).Selected = True
                            Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                            Exit For
                        End If
                    Next

                    For i = 0 To Me.dgvRateList.Rows.Count - 1
                        If (Me.dgvRateList.Rows(i).Cells(0).Value = srid) Then
                            Me.dgvRateList.Rows(i).Cells(1).Selected = True
                            Me.dgvRateList.FirstDisplayedScrollingRowIndex = i
                            Exit For
                        End If
                    Next
                    lFncAssignField(True)
                End If
                Me.cboAccNo.Enabled = False
                Me.cboAENo.Enabled = False
                lFnChangeObjectStatus(False)
            Else
                Return
            End If
        ElseIf userAction = "BA" Or userAction = "BE" Then
            If CDbl(Me.nbCommRate.Text) <> 0 And CDbl(Me.nbBrok_rate.Text) <> 0 Then
                GSubShowInfo(GFncGetSysMsg(74))
                Me.nbCommRate.Focus()
                Return
            End If
            If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                If Me.cboAENo.Text.Trim.Length <= 0 Then
                    GSubShowInfo(GFncGetSysMsg(31))
                    Me.cboAccNo.Focus()
                    Return
                End If
                Dim comm_month As String = Me.txtMonth.Text
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
                Dim turnover_from As String = Me.abTurnover.Text
                Dim comm_rate As String = Me.nbCommRate.Text
                Dim comm_type As String = cls.comm_type_acc
                Dim brok_rate As String = Me.nbBrok_rate.Text

                If (Val(Me.nbCommRate.Text) > 100) Then
                    GSubShowInfo(GFncGetSysMsg(43))
                    Me.nbCommRate.Focus()
                    Return
                End If
                aeDT = cls.lFnGetAllAENo(cls.market_sec, comm_month).Tables(0)
                'If (userAction = "E") Then
                '    srid = Me.dgvRateList.CurrentRow.Cells(0).Value
                'End If

                'check overlap
                'If (cls.lFncCheckOverlap(srid, acc_no, ae_no, rate_type, turnover_from, comm_month, Nothing, Nothing, comm_type, Nothing) = True) Then
                '    GSubShowInfo(GFncGetSysMsg(44))
                '    Me.abTurnover.Focus()
                '    Return
                'End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                Dim ldtAcc As DataTable = cls.lFnGetAllAccNo(comm_month, Me.cboAENo.Text).Tables(0)
                Try
                    MyTrans = GSCnSqlConn.BeginTransaction
                    If (userAction = "BA") Then
                        cls.lFncDeleteBRate(rate_type, comm_type, turnover_from, comm_month, ae_no, MyTrans)
                        For Each ldrAcc As DataRow In ldtAcc.Rows
                            Dim AC() As DataRow = AccDT.Select("acc_no='" & ldrAcc.Item("acc_no") & "'")
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
                            cls.lFncInsertRate(ldrAcc.Item("acc_no"), ae_no, "", rate_type, turnover_from, comm_rate, brok_rate, comm_month, comm_type, MyTrans, "CommRateTblSACC")
                        Next
                    ElseIf (userAction = "BE") Then
                        cls.lFncModifyBRate(rate_type, comm_type, turnover_from, comm_rate, brok_rate, comm_month, Me.cboAENo.Text, MyTrans)
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

                Me.txtSrcAE.Text = Me.cboAENo.Text
                lFncLoadAccByMonth()
                'Dim i As Integer = 0
                'For i = 0 To Me.dgvAccList.Rows.Count - 1
                '    If (Me.dgvAccList.Rows(i).Cells(0).Value = acc_no) Then
                '        Me.dgvAccList.FirstDisplayedScrollingRowIndex = i
                '        Me.dgvAccList.Rows(i).Cells(0).Selected = True
                '        Exit For
                '    End If
                'Next
                'lFnLoadAEList()

                'If (i < Me.dgvAccList.Rows.Count) Then
                '    For i = 0 To Me.dgvAEList.Rows.Count - 1
                '        If (Me.dgvAEList.Rows(i).Cells(0).Value = ae_no) Then
                '            Me.dgvAEList.Rows(i).Cells(1).Selected = True
                '            Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                '            Exit For
                '        End If
                '    Next

                '    For i = 0 To Me.dgvRateList.Rows.Count - 1
                '        If (Me.dgvRateList.Rows(i).Cells(0).Value = srid) Then
                '            Me.dgvRateList.Rows(i).Cells(1).Selected = True
                '            Me.dgvRateList.FirstDisplayedScrollingRowIndex = i
                '            Exit For
                '        End If
                '    Next
                'lFncAssignField(True)
                'End If

                'Me.cboAccNo.Enabled = False
                'Me.cboAENo.Enabled = False
                lFnChangeObjectStatus(False)
            Else
                Return
            End If
            'ElseIf (userAction = "A_Con" Or userAction = "E_Con") Then

            '    If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            '        If Me.cboAccNoCon.Text.Trim.Length <= 0 And cls.lFncValidAC(Me.cboAccNoCon.Text.Trim) Then
            '            GSubShowInfo(GFncGetSysMsg(12))
            '            Me.cboAccNoCon.Focus()
            '            Return
            '        End If
            '        If Me.cboAENoCon.Text.Trim.Length <= 0 Then
            '            GSubShowInfo(GFncGetSysMsg(31))
            '            Me.cboAccNoCon.Focus()
            '            Return
            '        End If
            '        Dim comm_month As String = Me.txtmonthCon.Text
            '        Dim acc_no As String = Me.cboAccNoCon.Text
            '        Dim ae_no As String = Me.cboAENoCon.Text
            '        Dim rate_type As String = ""
            '        rate_type = cls.comm_rate_con

            '        Dim turnover_from As String = Me.abTurnoverCon.Text
            '        Dim comm_rate As String = Me.nbCommRateCon.Text
            '        Dim comm_type As String = cls.comm_type_acc

            '        If (Val(Me.nbCommRateCon.Text) > 100) Then
            '            GSubShowInfo(GFncGetSysMsg(43))
            '            Me.nbCommRateCon.Focus()
            '            Return
            '        End If

            '        If (userAction = "E_Con") Then
            '            srid = Me.dgvRateListCon.CurrentRow.Cells(0).Value
            '        End If

            '        'check overlap
            '        If (cls.lFncCheckOverlap(srid, acc_no, ae_no, rate_type, turnover_from, comm_month, Nothing, Nothing, comm_type, Nothing) = True) Then
            '            GSubShowInfo(GFncGetSysMsg(44))
            '            Me.abTurnoverCon.Focus()
            '            Return
            '        End If

            '        Try
            '            MyTrans = GSCnSqlConn.BeginTransaction
            '            If (userAction = "A_Con") Then
            '                cls.lFncInsertRate(acc_no, ae_no, "", rate_type, turnover_from, comm_rate, comm_month, comm_type, MyTrans)
            '            ElseIf (userAction = "E_Con") Then
            '                cls.lFncModifyRate(srid, rate_type, turnover_from, comm_rate, "", MyTrans)
            '            End If
            '            MyTrans.Commit()
            '            MyTrans = Nothing
            '            If (srid.Length = 0) Then
            '                srid = cls.lFnGetSRID()
            '            End If
            '        Catch ex As Exception
            '            If GSCnSqlConn.State <> ConnectionState.Closed Then
            '                If (MyTrans IsNot Nothing) Then
            '                    MyTrans.Rollback()
            '                End If
            '                GSubWriteErrLog(ex.Message)
            '            End If
            '        End Try

            '        lFncLoadAccByMonthCon()

            '        Dim i As Integer = 0
            '        For i = 0 To Me.dgvAccListCon.Rows.Count - 1
            '            If (Me.dgvAccListCon.Rows(i).Cells(0).Value = acc_no) Then
            '                Me.dgvAccListCon.FirstDisplayedScrollingRowIndex = i
            '                Me.dgvAccListCon.Rows(i).Cells(0).Selected = True
            '                Exit For
            '            End If
            '        Next
            '        lFnLoadAEListCon()

            '        If (i < Me.dgvAccListCon.Rows.Count) Then
            '            For i = 0 To Me.dgvAEListCon.Rows.Count - 1
            '                If (Me.dgvAEListCon.Rows(i).Cells(0).Value = ae_no) Then
            '                    Me.dgvAEListCon.Rows(i).Cells(1).Selected = True
            '                    Me.dgvAEListCon.FirstDisplayedScrollingRowIndex = i
            '                    Exit For
            '                End If
            '            Next

            '            For i = 0 To Me.dgvRateListCon.Rows.Count - 1
            '                If (Me.dgvRateListCon.Rows(i).Cells(0).Value = srid) Then
            '                    Me.dgvRateListCon.Rows(i).Cells(1).Selected = True
            '                    Me.dgvRateListCon.FirstDisplayedScrollingRowIndex = i
            '                    Exit For
            '                End If
            '            Next
            '            lFncAssignFieldCon(True)
            '        End If

            '        Me.cboAccNoCon.Enabled = False
            '        Me.cboAENoCon.Enabled = False
            '        lFnChangeObjectStatusCon(False)
            '    End If
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
                accno = Me.dgvAccList.CurrentRow.Cells(0).Value
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
                GFncFillLog(GStrloginID, "D", GDteTradeDate, "CommRateTblSACC", ae, acc, srid, month, logstr, MyTrans)
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
                acc_no = Me.dgvAccList.CurrentRow.Cells("acc_no").Value
                ae_no = Me.dgvAEList.CurrentRow.Cells("ae_no").Value
                'lFncLoadRateTable(comm_month, rate_type, acc_no, ae_no, cls.comm_type_acc)
                lFncLoadAccByMonth()
                Dim i As Integer = 0
                For i = 0 To Me.dgvAccList.Rows.Count - 1
                    If (Me.dgvAccList.Rows(i).Cells(0).Value = accno) Then
                        Me.dgvAccList.FirstDisplayedScrollingRowIndex = i
                        Me.dgvAccList.Rows(i).Cells(0).Selected = True
                        Exit For
                    End If
                Next
                lFnLoadAEList()
                If (i < Me.dgvAccList.Rows.Count) Then
                    For i = 0 To Me.dgvAEList.Rows.Count - 1
                        If (Me.dgvAEList.Rows(i).Cells(0).Value = aeno) Then
                            Me.dgvAEList.Rows(i).Cells(1).Selected = True
                            Me.dgvAEList.FirstDisplayedScrollingRowIndex = i
                            Exit For
                        End If
                    Next
                End If
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
                If dgvAccList.Rows.Count > 0 Then
                    Me.cboAccNo.Text = Me.dgvAccList.CurrentRow.Cells("acc_no").Value.ToString
                    Me.txtAccName.Text = Me.dgvAccList.CurrentRow.Cells("acc_name_s").Value.ToString
                End If
                If dgvAEList.Rows.Count > 0 Then
                    Me.cboAENo.Text = GFncNoNullString(Me.dgvAEList.CurrentRow.Cells("ae_no").Value)
                    Me.txtAEName.Text = GFncNoNullString(Me.dgvAEList.CurrentRow.Cells("ae_name_s").Value)
                End If
            End If
        Else
            Me.txtMonth.Text = ""
            Me.cboAccNo.SelectedIndex = -1
            Me.txtAccName.Text = ""
            Me.cboAENo.SelectedIndex = -1
            Me.txtAEName.Text = ""
            Me.rbNormal.Checked = True
            Me.abTurnover.Text = ""
            Me.nbCommRate.Text = ""
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (userAction = "A") Or (userAction = "E") Or _
        (userAction = "BE") Or (userAction = "BA") Then
            Me.cboAccNo.Enabled = False
            Me.cboAENo.Enabled = False
            lFnChangeObjectStatus(False)
            If (Me.dgvAccList.Rows.Count > 0) Then
                Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(GFncNoNullString(Me.dgvAccList.CurrentRow.Cells(0).Value))
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(GFncNoNullString(Me.dgvAEList.CurrentRow.Cells(0).Value))
                lFncAssignField(True)
            Else
                lFncAssignField(False)
                Me.btnEdit.Enabled = False
                Me.btnDelete.Enabled = False
            End If
            userAction = ""
            'ElseIf (userAction = "A_Con" Or userAction = "E_Con") Then

            '    Me.cboAccNoCon.Enabled = False
            '    Me.cboAENoCon.Enabled = False

            '    lFnChangeObjectStatusCon(False)

            '    If (Me.dgvAccListCon.Rows.Count > 0) Then
            '        Me.cboAccNoCon.SelectedIndex = Me.cboAccNoCon.FindString(GFncNoNullString(Me.dgvAccListCon.CurrentRow.Cells(0).Value))
            '        Me.cboAENoCon.SelectedIndex = Me.cboAENo.FindString(GFncNoNullString(Me.dgvAEListCon.CurrentRow.Cells(0).Value))
            '        lFncAssignFieldCon(True)
            '    Else
            '        lFncAssignFieldCon(False)
            '        Me.btnEditCon.Enabled = False
            '        Me.btnDeleteCon.Enabled = False
            '    End If

            '    userAction = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lFnRefreshTurnover()
        Dim comm_month As String = Me.txtMonth.Text
        Dim acc_no As String = Me.cboAccNo.Text
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
        Dim comm_type As String = cls.comm_type_acc
        Dim lds As DataSet = Nothing
        Dim turnoverTo As String = ""

        lds = cls.lFncGetNextComm(comm_month, rate_type, acc_no, ae_no, comm_type, turnover_from)
        If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
            Me.lblTurnover.Text = ""
        Else
            Me.lblTurnover.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,##0.00")
        End If
    End Sub

    '-------------------------------------------------Consolidate ----------------------------------------------------------------

    'Private Sub btnSearchCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchCon.Click
    '    lFncLoadAccByMonthCon()
    'End Sub

    'Private Sub dgvAccListCon_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAccListCon.SelectionChanged
    '    lFnLoadAEListCon()
    'End Sub

    'Private Sub cboSearchYearCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchYearCon.SelectedIndexChanged
    '    lFncLoadAccByMonthCon()
    'End Sub

    'Private Sub cboSearchMonthCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSearchMonthCon.SelectedIndexChanged
    '    lFncLoadAccByMonthCon()
    'End Sub

    'Private Sub rbSrchNormalCon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    lFncLoadAccByMonthCon()
    'End Sub

    'Private Sub rbSrchInternetCon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    lFncLoadAccByMonthCon()
    'End Sub

    'Private Sub rbSrchAllCon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    lFncLoadAccByMonthCon()
    'End Sub

    'Private Sub abTurnoverCon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles abTurnoverCon.LostFocus
    '    lFnRefreshTurnoverCon()
    'End Sub

    'Private Sub dgvRateListCon_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRateListCon.SelectionChanged
    '    lFncAssignFieldCon(True)
    'End Sub

    'Private Sub rbNormalCon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    lFnRefreshTurnoverCon()
    'End Sub

    'Private Sub rbInternetCon_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    lFnRefreshTurnoverCon()
    'End Sub

    'Private Sub lFncLoadAccNoCon()
    '    Me.cboAccNoCon.Items.Add("")
    '    Dim accDT As DataTable = cls.lFnGetAllAccNo(cls.market_sec).Tables(0)
    '    For i As Integer = 0 To accDT.Rows.Count - 1
    '        Me.cboAccNoCon.Items.Add(accDT.Rows(i).Item("acc_no").ToString.Trim)
    '    Next
    'End Sub

    'Private Sub lFnLoadAENoCon()
    '    Me.cboAENoCon.Items.Add("")
    '    Dim aeDT As DataTable = cls.lFnGetAllAENo(cls.market_sec).Tables(0)
    '    For i As Integer = 0 To aeDT.Rows.Count - 1
    '        Me.cboAENoCon.Items.Add(aeDT.Rows(i).Item("ae_no").ToString.Trim)
    '    Next
    'End Sub

    'Private Sub lFncLoadSearchMonthCon()

    '    Dim lds As DataSet = Nothing
    '    Dim maxYear As Integer = 0
    '    Dim maxMonth As Integer = 0

    '    lds = cls.lFncGetCommMonth(cls.comm_type_acc)
    '    If GFncNoNullString(lds.Tables(0).Rows(0).Item(0)).Trim <> "" Then
    '        maxYear = Val(lds.Tables(0).Rows(0).Item("mmth").ToString.Substring(0, 4))
    '        maxMonth = Val(lds.Tables(0).Rows(0).Item("mmth").ToString.Substring(4, 2))
    '    Else
    '        maxYear = Now.Year
    '        maxMonth = Now.Month - 1
    '    End If
    '    For i As Integer = maxYear - 3 To maxYear + 3
    '        Me.cboSearchYearCon.Items.Add(i)
    '    Next
    '    For j As Integer = 1 To 12
    '        Me.cboSearchMonthCon.Items.Add(j)
    '    Next

    '    Me.cboSearchYearCon.SelectedIndex = Me.cboSearchYearCon.FindString(maxYear)
    '    Me.cboSearchMonthCon.SelectedIndex = Me.cboSearchMonthCon.FindString(maxMonth)

    'End Sub

    'Private Sub lFnLoadAEListCon()

    '    Dim lds As DataSet = Nothing
    '    Dim comm_month As String = ""
    '    Dim rate_type As String = cls.comm_rate_con
    '    Dim acc_no As String = ""

    '    comm_month = Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00")
    '    If (Me.dgvAccListCon.Rows.Count > 0) Then
    '        acc_no = Me.dgvAccListCon.CurrentRow.Cells("acc_noCon").Value

    '        Me.dgvAEListCon.DataSource = cls.lFncGetAEList(comm_month, rate_type, acc_no, cls.comm_type_acc)
    '        Me.dgvAEListCon.DataMember = "aeno"

    '        Me.cboAccNoCon.SelectedIndex = Me.cboAccNoCon.FindString(Me.dgvAccListCon.CurrentRow.Cells(0).Value)
    '    End If

    'End Sub

    'Private Sub cboAccNoCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAccNoCon.SelectedIndexChanged, cboAccNoCon.LostFocus

    '    Dim lds As DataSet = Nothing

    '    lds = cls.lFnGetAccName(Me.cboAccNoCon.Text, cls.market_sec)
    '    If (lds.Tables(0).Rows.Count > 0) Then
    '        Me.txtAccNameCon.Text = lds.Tables(0).Rows(0).Item("acc_name_s")
    '        Me.cboAENoCon.Text = cls.lFncGetAENo(Me.cboAccNoCon.Text, Me.txtmonthCon.Text)
    '        Me.cboAENoCon_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
    '    Else
    '        Me.txtAccNameCon.Text = ""
    '        Me.cboAENoCon.Text = ""
    '        Me.txtAENameCon.Text = ""
    '    End If

    'End Sub

    'Private Sub cboAENoCon_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboAENoCon.SelectedIndexChanged, cboAENoCon.LostFocus

    '    Dim lds As DataSet = Nothing

    '    lds = cls.lFnGetAEName(Me.cboAENoCon.Text, cls.market_sec)
    '    If (lds.Tables(0).Rows.Count > 0) Then
    '        Me.txtAENameCon.Text = lds.Tables(0).Rows(0).Item("ae_name_s")
    '    Else
    '        Me.txtAENameCon.Text = ""
    '    End If

    'End Sub

    'Private Sub lFncLoadRateTableCon(ByVal comm_month As String, ByVal rate_type As String, ByVal acc_no As String, _
    '                                ByVal ae_no As String, ByVal comm_type As String)

    '    Dim formatPrice As String = ""

    '    Me.dgvRateListCon.DataSource = cls.lFncGetRateList(comm_month, rate_type, acc_no, ae_no, Nothing, Nothing, comm_type)
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

    'Private Sub dgvAEListCon_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEListCon.SelectionChanged

    '    Dim comm_month As String = ""
    '    Dim rate_type As String = cls.comm_rate_con
    '    Dim acc_no As String = ""
    '    Dim ae_no As String = ""

    '    comm_month = Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00")
    '    acc_no = Me.dgvAccListCon.CurrentRow.Cells("acc_noCon").Value
    '    ae_no = Me.dgvAEListCon.CurrentRow.Cells("ae_noCon").Value

    '    lFncLoadRateTableCon(comm_month, rate_type, acc_no, ae_no, cls.comm_type_acc)

    'End Sub

    'Private Sub lFncLoadAccByMonthCon()

    '    Dim lds As DataSet = Nothing
    '    Dim comm_month As String = ""
    '    Dim rate_type As String = cls.comm_rate_con
    '    Dim acc_no As String = ""


    '    comm_month = Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00")
    '    acc_no = Me.txtSrchAccNoCon.Text

    '    Me.dgvAccListCon.DataSource = cls.lFncGetAccList(comm_month, rate_type, acc_no, cls.comm_type_acc)
    '    Me.dgvAccListCon.DataMember = "accno"

    '    If (Me.dgvAccListCon.Rows.Count = 0) Then
    '        lFncAssignFieldCon(False)
    '        Me.btnEditCon.Enabled = False
    '        Me.btnDeleteCon.Enabled = False
    '    Else
    '        Me.btnDeleteCon.Enabled = True
    '        Me.btnEditCon.Enabled = True
    '    End If

    'End Sub

    'Private Sub btnNewCon_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewCon.Click

    '    Dim rate_type As String = ""

    '    userAction = "A_Con"

    '    Me.txtmonthCon.Text = Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00")
    '    If (Me.dgvAccListCon.Rows.Count > 0) Then
    '        Dim dt As DataTable = cls.lFnGetAENo(Me.dgvAccListCon.CurrentRow.Cells(0).Value, cls.market_sec, Me.txtmonthCon.Text)
    '        If dt.Rows.Count > 0 Then
    '            Me.cboAENoCon.SelectedIndex = Me.cboAENoCon.FindString(dt.Rows(0).Item(0).ToString)
    '        Else
    '            Me.cboAENoCon.SelectedIndex = 0
    '        End If
    '        'Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(cls.lFnGetAENo(Me.dgvAccList.CurrentRow.Cells(0).Value, cls.market_sec, Me.txtMonth.Text).Tables(0).Rows(0).Item(0).ToString)
    '    Else
    '        Me.cboAccNoCon.SelectedIndex = 0
    '        Me.cboAENoCon.SelectedIndex = 0
    '    End If
    '    Me.abTurnoverCon.Text = 0
    '    lFnRefreshTurnoverCon()
    '    Me.nbCommRateCon.Text = 0

    '    lFnChangeObjectStatusCon(True)
    '    Me.cboAccNoCon.Enabled = True
    '    'Me.cboAENo.Enabled = True

    '    Me.cboAccNoCon.Focus()

    'End Sub

    'Private Sub lFnChangeObjectStatusCon(ByVal status As Boolean)

    '    Me.cboSearchYearCon.Enabled = Not status
    '    Me.cboSearchMonthCon.Enabled = Not status

    '    Me.txtSrchAccNoCon.Enabled = Not status
    '    Me.btnSearchCon.Enabled = Not status
    '    Me.dgvAccListCon.Enabled = Not status
    '    Me.dgvAEListCon.Enabled = Not status
    '    Me.dgvRateListCon.Enabled = Not status

    '    Me.abTurnoverCon.Enabled = status
    '    Me.nbCommRateCon.Enabled = status

    '    Me.btnNewCon.Enabled = Not status
    '    Me.btnEditCon.Enabled = Not status
    '    Me.btnDeleteCon.Enabled = Not status
    '    Me.btnSave.Enabled = status

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

    '    If (GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
    '        Try
    '            accno = Me.dgvAccListCon.CurrentRow.Cells(0).Value
    '            aeno = Me.dgvAEListCon.CurrentRow.Cells(0).Value
    '            MyTrans = GSCnSqlConn.BeginTransaction
    '            cls.lFncDeleteRate(Me.dgvRateListCon.CurrentRow.Cells("sridCon").Value, MyTrans)
    '            MyTrans.Commit()
    '            MyTrans = Nothing

    '            Dim comm_month As String = ""
    '            Dim rate_type As String = ""
    '            Dim acc_no As String = ""
    '            Dim ae_no As String = ""


    '            comm_month = Me.cboSearchYearCon.Text & Format(Val(Me.cboSearchMonthCon.Text), "00")
    '            acc_no = Me.dgvAccListCon.CurrentRow.Cells("acc_noCon").Value
    '            ae_no = Me.dgvAEListCon.CurrentRow.Cells("ae_noCon").Value

    '            'lFncLoadRateTable(comm_month, rate_type, acc_no, ae_no, cls.comm_type_acc)
    '            lFncLoadAccByMonthCon()

    '            Dim i As Integer = 0
    '            For i = 0 To Me.dgvAccListCon.Rows.Count - 1
    '                If (Me.dgvAccListCon.Rows(i).Cells(0).Value = accno) Then
    '                    Me.dgvAccListCon.FirstDisplayedScrollingRowIndex = i
    '                    Me.dgvAccListCon.Rows(i).Cells(0).Selected = True
    '                    Exit For
    '                End If
    '            Next
    '            lFnLoadAEListCon()

    '            If (i < Me.dgvAccListCon.Rows.Count) Then
    '                For i = 0 To Me.dgvAEListCon.Rows.Count - 1
    '                    If (Me.dgvAEListCon.Rows(i).Cells(0).Value = aeno) Then
    '                        Me.dgvAEListCon.Rows(i).Cells(1).Selected = True
    '                        Me.dgvAEListCon.FirstDisplayedScrollingRowIndex = i
    '                        Exit For
    '                    End If
    '                Next
    '            End If

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

    'Private Sub nbCommRateCon_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles nbCommRateCon.LostFocus

    '    If (Me.nbCommRateCon.Text.Trim.Length = 0) Then
    '        Me.nbCommRateCon.Text = 0
    '    End If

    'End Sub

    'Private Sub lFncAssignFieldCon(ByVal status As Boolean)

    '    If (status = True) Then
    '        If (Me.dgvRateListCon.Rows.Count > 0) Then
    '            Me.txtmonthCon.Text = Me.dgvRateListCon.CurrentRow.Cells("comm_monthCon").Value

    '            Me.abTurnoverCon.Text = Format(Me.dgvRateListCon.CurrentRow.Cells("turnover_fromCon").Value, "##,###,###,###.00")
    '            If (IsDBNull(Me.dgvRateListCon.CurrentRow.Cells("turnover_toCon").Value) = False) Then
    '                Me.lblTurnoverCon.Text = "< " & Format(Me.dgvRateListCon.CurrentRow.Cells("turnover_toCon").Value, "##,###,###,###.00")
    '            Else
    '                Me.lblTurnoverCon.Text = ""
    '            End If
    '            Me.nbCommRateCon.Text = Me.dgvRateListCon.CurrentRow.Cells("comm_rateCon").Value
    '            Me.cboAccNoCon.Text = Me.dgvAccListCon.CurrentRow.Cells("acc_noCon").Value.ToString
    '            Me.txtAccNameCon.Text = Me.dgvAccListCon.CurrentRow.Cells("acc_name_sCon").Value.ToString


    '        End If
    '    Else
    '        Me.txtmonthCon.Text = ""
    '        Me.cboAccNoCon.SelectedIndex = -1
    '        Me.txtAccNameCon.Text = ""
    '        Me.cboAENoCon.SelectedIndex = -1
    '        Me.txtAENameCon.Text = ""
    '        Me.abTurnoverCon.Text = ""
    '        Me.nbCommRateCon.Text = ""

    '    End If

    'End Sub

    'Private Sub lFnRefreshTurnoverCon()

    '    Dim comm_month As String = Me.txtmonthCon.Text
    '    Dim acc_no As String = Me.cboAccNoCon.Text
    '    Dim ae_no As String = Me.cboAENoCon.Text
    '    Dim rate_type As String = ""

    '    Dim turnover_from As String = Me.abTurnoverCon.Text
    '    If (turnover_from <> "") Then
    '        turnover_from = CDbl(turnover_from)
    '    Else
    '        turnover_from = "0"
    '    End If
    '    Dim comm_type As String = cls.comm_type_acc
    '    Dim lds As DataSet = Nothing
    '    Dim turnoverTo As String = ""

    '    lds = cls.lFncGetNextComm(comm_month, rate_type, acc_no, ae_no, comm_type, turnover_from)
    '    If (IsDBNull(lds.Tables(0).Rows(0).Item("mt"))) Then
    '        Me.lblTurnoverCon.Text = ""
    '    Else
    '        Me.lblTurnoverCon.Text = "< " & Format(lds.Tables(0).Rows(0).Item("mt"), "##,###,###,###.00")
    '    End If

    'End Sub

    Private Sub cbConsolidate_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbConsolidate.CheckedChanged
        If Me.cbConsolidate.Checked Then
            Me.GroupTradeType.Visible = False
        Else
            GroupTradeType.Visible = True
        End If
    End Sub

    Private Sub txtSrcAE_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrcAE.LostFocus
        If loadAction = False Then
            lFncLoadAccByMonth()
        End If
    End Sub


    Private Sub btnBNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBNew.Click
        Dim rate_type As String = ""

        userAction = "BA"

        Me.txtMonth.Text = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
        If (Me.rbSrchInternet.Checked) Then
            Me.rbInternet.Checked = True
            Me.cbConsolidate.Checked = False
        ElseIf Me.rbConsolidate.Checked Then
            Me.cbConsolidate.Checked = True
        Else
            Me.rbNormal.Checked = True
            Me.cbConsolidate.Checked = False
        End If
        'Me.ChangeAEConsolid(Me.cboAENo.Text)
        Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
        Me.abTurnover.Text = 0
        lFnRefreshTurnover()
        Me.nbCommRate.Text = 0

        lFnChangeObjectStatus(True)
        'Me.cboAccNo.Enabled = True
        Me.cboAENo.Enabled = True
        Me.cboAccNo.Visible = False
        Me.txtAccName.Visible = False
        Me.lblAcc.Visible = False

        Me.cboAccNo.Focus()
    End Sub

    Private Sub btnBEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBEdit.Click
        userAction = "BE"
        If (Me.dgvRateList.Rows.Count > 0) Then
            lFnChangeObjectStatus(True)
            Me.cboAccNo.Visible = False
            Me.txtAccName.Visible = False
            Me.lblAcc.Visible = False
            Me.cbConsolidate.Enabled = False
            Me.rbInternet.Enabled = False
            Me.rbNormal.Enabled = False
            Me.nbCommRate.Focus()
            Me.abTurnover.Enabled = False
            'ChangeAEConsolid(Me.cboAENo.Text)
        Else
            GSubShowInfo("no record to edit")
        End If
    End Sub

    Private Sub btnBDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBDelete.Click
        Dim MyTrans As SqlTransaction = Nothing
        Dim accno As String = ""
        Dim aeno As String = ""
        Dim comm_month As String = ""
        Dim lstr As String = ""
        If Me.dgvRateList.Rows.Count <= 0 Then
            Return
        End If

        If Me.cboAENo.Text.Trim.Length <= 0 Then
            GSubShowInfo(GFncGetSysMsg(31))
            Return
        End If
        lstr = " (" & Me.cboAENo.Text.Trim & " - " & Me.abTurnover.Text
        Dim turnover_from As String = Me.abTurnover.Text
        Dim comm_type As String = cls.comm_type_acc
        Dim rate_type As String = ""
        If Me.cbConsolidate.Checked Then
            rate_type = cls.comm_rate_con
            lstr += " - Consolidate )"
        Else
            If (Me.rbNormal.Checked) Then
                rate_type = cls.comm_rate_nor
                lstr += " - Normal )"
            ElseIf (Me.rbInternet.Checked) Then
                rate_type = cls.comm_rate_int
                lstr += " - Internet )"
            End If
        End If
        If (GSubShowYNConfirm(GFncGetSysMsg(11) & lstr, MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            If GFncCheckCommStatus() Then
                Return
            End If
            Try
                aeno = Me.cboAENo.Text
                comm_month = Me.cboSearchYear.Text & Format(Val(Me.cboSearchMonth.Text), "00")
                MyTrans = GSCnSqlConn.BeginTransaction
                cls.lFncDeleteBRate(rate_type, comm_type, turnover_from, comm_month, Me.cboAENo.Text, MyTrans)
                MyTrans.Commit()
                MyTrans = Nothing
                lFncLoadAccByMonth()
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

    Private Sub ChangeConsolid(ByVal acc_no As String)
        If acc_no.Length > 0 Then
            Dim AC() As DataRow = AccDT.Select("acc_no='" & acc_no & "'")
            If AC.Length > 0 Then
                If AC(0).Item("isConsolid") Then
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

    'Private Sub ChangeAEConsolid(ByVal AE_no As String)
    '    If AE_no.Length > 0 Then
    '        Dim AE() As DataRow = aeDT.Select("ae_no='" & AE_no & "'")
    '        If AE.Length > 0 Then
    '            If AE(0).Item("isConsolid") Then
    '                Me.cbConsolidate.Checked = True
    '            Else
    '                Me.cbConsolidate.Checked = False
    '                If Me.rbSrchInternet.Checked Then
    '                    Me.rbInternet.Checked = True
    '                Else
    '                    Me.rbNormal.Checked = True
    '                End If
    '            End If
    '            Me.cbConsolidate.Enabled = False
    '        Else
    '            Me.cbConsolidate.Enabled = True
    '            Me.cbConsolidate.Checked = False
    '        End If
    '    Else
    '        Me.cbConsolidate.Enabled = True
    '        Me.cbConsolidate.Checked = False
    '    End If
    '    Me.cbConsolidate_CheckedChanged(Nothing, System.EventArgs.Empty)
    'End Sub

End Class