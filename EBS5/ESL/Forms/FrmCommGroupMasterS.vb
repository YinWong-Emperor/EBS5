Public Class FrmCommGroupMasterS

    Dim activePage = "S"
    Dim cls As New ClsCommGroupMaster
    Dim action As String = ""
    Dim preAENo As String = ""
    Dim preAEGroup As String = ""
    Dim ldtEmptyS As DataTable = Nothing
    Dim ldtEmptyF As DataTable = Nothing

    Private Sub FrmCommGroupMasterS_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        Dim ldtAE As DataTable = Nothing
        Dim MaxDate As String = GfncGetMonth()
        For year As Integer = MaxDate.Substring(0, 4) - 5 To MaxDate.Substring(0, 4) + 5
            Me.cboSrchYear.Items.Add(year)
        Next
        For month As Integer = 1 To 12
            Me.cboSrchMonth.Items.Add(month)
        Next
        Me.cboSrchYear.Text = MaxDate.Substring(0, 4)
        Me.cboSrchMonth.Text = Val(MaxDate.Substring(4, 2))
        ldtAE = cls.lFncGetAEFullList()
        Me.cboAENoS.Items.Add("")
        Me.cboAENoF.Items.Add("")
        For i As Integer = 0 To ldtAE.Rows.Count - 1
            Me.cboAENoS.Items.Add(ldtAE.Rows(i).Item("ae_no"))
            Me.cboAENoF.Items.Add(ldtAE.Rows(i).Item("ae_no"))
        Next
        ldtEmptyS = cls.lFncGetAEDetailS("", "")
        ldtEmptyF = cls.lFncGetAEDetailF("", "")
        refreshList()
    End Sub

    Private Sub cboSrchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSrchYear.SelectedIndexChanged
        refreshList()
    End Sub

    Private Sub cboSrchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSrchMonth.SelectedIndexChanged
        refreshList()
    End Sub

    Private Sub refreshList()
        Dim txmonth As String = Me.cboSrchYear.Text & Format(Val(Me.cboSrchMonth.Text), "00")
        If (Me.TabControl1.SelectedIndex = 0) Then
            Me.dgvAEDetailS.DataSource = ldtEmptyS
            Me.dgvAEListS.DataSource = cls.lFncGetAEListS(txmonth)
        ElseIf (Me.TabControl1.SelectedIndex = 1) Then
            Me.dgvAEDetailF.DataSource = ldtEmptyF
            Me.dgvAEListF.DataSource = cls.lFncGetAEListF(txmonth)
        End If
    End Sub

    Private Sub dgvAEList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEListS.SelectionChanged
        If Me.dgvAEListS.Rows.Count > 0 Then
            If Me.dgvAEListS.SelectedCells.Count > 0 Then
                Me.cboAENoS.SelectedIndex = Me.cboAENoS.FindString(Me.dgvAEListS.CurrentRow.Cells(0).Value)
                Dim txmonth As String = Me.cboSrchYear.Text & Format(Val(Me.cboSrchMonth.Text), "00")
                Me.dgvAEDetailS.DataSource = cls.lFncGetAEDetailS(Me.cboAENoS.Text, txmonth)
            Else
                Me.cboAENoS.SelectedIndex = -1
                Me.txtMonthS.Text = ""
            End If
        Else
            Me.cboAENoS.SelectedIndex = -1
            Me.txtMonthS.Text = ""
        End If
    End Sub

    Private Sub dgvAEListF_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEListF.SelectionChanged
        If Me.dgvAEListF.Rows.Count > 0 Then
            If Me.dgvAEListF.SelectedCells.Count > 0 Then
                Me.cboAENoF.SelectedIndex = Me.cboAENoF.FindString(Me.dgvAEListF.CurrentRow.Cells(0).Value)
                Dim txmonth As String = Me.cboSrchYear.Text & Format(Val(Me.cboSrchMonth.Text), "00")
                Me.dgvAEDetailF.DataSource = cls.lFncGetAEDetailF(Me.cboAENoF.Text, txmonth)
            Else
                Me.cboAENoF.SelectedIndex = -1
                Me.txtMonthF.Text = ""
            End If
        Else
            Me.cboAENoF.SelectedIndex = -1
            Me.txtMonthF.Text = ""
        End If
    End Sub

    Private Sub dgvAEDetailS_SelectionChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEDetailS.SelectionChanged
        If Me.dgvAEDetailS.Rows.Count > 0 Then
            If Me.dgvAEDetailS.SelectedCells.Count > 0 Then
                Me.txtAccGroupS.Text = Me.dgvAEDetailS.CurrentRow.Cells(1).Value
                Me.txtMonthS.Text = GFncNoNullString(Me.dgvAEDetailS.CurrentRow.Cells(0).Value)
                If (Me.dgvAEDetailS.CurrentRow.Cells(2).Value = "Y") Then
                    Me.cbConsolidS.Checked = True
                Else
                    Me.cbConsolidS.Checked = False
                End If
                Me.abMinConS.Text = Me.dgvAEDetailS.CurrentRow.Cells(3).Value
                Me.abMinNorS.Text = Me.dgvAEDetailS.CurrentRow.Cells(4).Value
                Me.abMinIntS.Text = Me.dgvAEDetailS.CurrentRow.Cells(5).Value
            Else
                Me.txtAccGroupS.Text = ""
                Me.txtMonthS.Text = ""
                Me.cbConsolidS.Checked = True
                Me.abMinConS.Text = ""
                Me.abMinNorS.Text = ""
                Me.abMinIntS.Text = ""
            End If
        Else
            Me.txtAccGroupS.Text = ""
            Me.txtMonthS.Text = ""
            Me.cbConsolidS.Checked = True
            Me.abMinConS.Text = ""
            Me.abMinNorS.Text = ""
            Me.abMinIntS.Text = ""
        End If
    End Sub

    Private Sub dgvAEDetailF_SelectionChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvAEDetailF.SelectionChanged
        If Me.dgvAEDetailF.Rows.Count > 0 Then
            If Me.dgvAEDetailF.SelectedCells.Count > 0 Then
                Me.txtAccGroupF.Text = Me.dgvAEDetailF.CurrentRow.Cells("ae_group_f").Value
                Me.txtMonthF.Text = GFncNoNullString(Me.dgvAEDetailF.CurrentRow.Cells("txmonthF").Value)
                If (Me.dgvAEDetailF.CurrentRow.Cells("isConsolidF").Value = "Y") Then
                    Me.cbConsolidF.Checked = True
                Else
                    Me.cbConsolidF.Checked = False
                End If
                If (Me.dgvAEDetailF.CurrentRow.Cells("BothFO").Value = "Y") Then
                    Me.cbBothFO.Checked = True
                Else
                    Me.cbBothFO.Checked = False
                End If
                Me.abMinConF.Text = Me.dgvAEDetailF.CurrentRow.Cells("MinConTOF").Value
                Me.abMinNorF.Text = Me.dgvAEDetailF.CurrentRow.Cells("MinNorTOF").Value
                Me.abMinIntF.Text = Me.dgvAEDetailF.CurrentRow.Cells("MinIntTOF").Value
            Else
                Me.txtAccGroupF.Text = ""
                Me.txtMonthF.Text = ""
                Me.cbConsolidF.Checked = True
                Me.abMinConF.Text = ""
                Me.abMinNorF.Text = ""
                Me.abMinIntF.Text = ""
            End If
        Else
            Me.txtAccGroupF.Text = ""
            Me.txtMonthF.Text = ""
            Me.cbConsolidF.Checked = True
            Me.abMinConF.Text = ""
            Me.abMinNorF.Text = ""
            Me.abMinIntF.Text = ""
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        action = "A"
        If (Me.TabControl1.SelectedIndex = 0) Then
            preAENo = Me.cboAENoS.Text
            Me.cboAENoS.Enabled = True
            Me.cboAENoS.SelectedIndex = 0
            Me.txtAccGroupS.Text = ""
            Me.txtMonthS.Text = Me.cboSrchYear.Text & Format(Val(Me.cboSrchMonth.Text), "00")
            Me.cbConsolidS.Checked = False
            Me.abMinConS.Text = 0
            Me.abMinNorS.Text = 0
            Me.abMinIntS.Text = 0
        ElseIf (Me.TabControl1.SelectedIndex = 1) Then
            preAENo = Me.cboAENoF.Text
            Me.cboAENoF.Enabled = True
            Me.cboAENoF.SelectedIndex = 0
            Me.txtAccGroupF.Text = ""
            Me.txtMonthF.Text = Me.cboSrchYear.Text & Format(Val(Me.cboSrchMonth.Text), "00")
            Me.cbConsolidF.Checked = False
            Me.cbBothFO.Checked = False
            Me.abMinConF.Text = 0
            Me.abMinNorF.Text = 0
            Me.abMinIntF.Text = 0
        End If
        lSubControl(True)
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If (Me.TabControl1.SelectedIndex = 0) Then
            If (Me.dgvAEDetailS.Rows.Count > 0) Then
                action = "E"
                preAENo = Me.cboAENoS.Text
                preAEGroup = Me.txtAccGroupS.Text
                lSubControl(True)
            Else
                GSubShowInfo(GFncGetSysMsg(56))
            End If
        ElseIf (Me.TabControl1.SelectedIndex = 1) Then
            If (Me.dgvAEDetailF.Rows.Count > 0) Then
                action = "E"
                preAENo = Me.cboAENoF.Text
                preAEGroup = Me.txtAccGroupF.Text
                lSubControl(True)
            Else
                GSubShowInfo(GFncGetSysMsg(56))
            End If
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim ae_no As String = ""
        Dim ae_group As String = ""
        Dim txmonth As String = ""
        If (Me.TabControl1.SelectedIndex = 0) Then
            If (Me.dgvAEDetailS.Rows.Count > 0) Then
                If (GSubShowYNConfirm(GFncGetSysMsg(66) & " " & GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
                    If GFncCheckCommStatus() Then
                        Return
                    End If
                    ae_no = Me.cboAENoS.Text
                    ae_group = Me.txtAccGroupS.Text
                    txmonth = GFncNoNullString(Me.dgvAEDetailS.CurrentRow.Cells(0).Value)
                    If (cls.lFncDeleteAES(ae_no, ae_group, txmonth)) Then
                        preAENo = ae_no
                        refreshList()
                        For i As Integer = 0 To Me.dgvAEListS.Rows.Count - 1
                            If (Me.dgvAEListS.Rows(i).Cells(0).Value = preAENo) Then
                                Me.dgvAEListS.Rows(i).Cells(0).Selected = True
                                Me.dgvAEListS.FirstDisplayedScrollingRowIndex = i
                                Exit For
                            End If
                        Next
                        dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
                    End If
                End If
            Else
                GSubShowInfo(GFncGetSysMsg(56))
            End If
        ElseIf (Me.TabControl1.SelectedIndex = 1) Then
            If (Me.dgvAEDetailF.Rows.Count > 0) Then
                If (GSubShowYNConfirm(GFncGetSysMsg(67) & " " & GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
                    If GFncCheckCommStatus() Then
                        Return
                    End If
                    ae_no = Me.cboAENoF.Text
                    ae_group = Me.txtAccGroupF.Text
                    txmonth = GFncNoNullString(Me.dgvAEDetailF.CurrentRow.Cells("txmonthF").Value)
                    If (cls.lFncDeleteAEF(ae_no, ae_group, txmonth)) Then
                        preAENo = ae_no
                        refreshList()
                        For i As Integer = 0 To Me.dgvAEListF.Rows.Count - 1
                            If (Me.dgvAEListF.Rows(i).Cells(0).Value = preAENo) Then
                                Me.dgvAEListF.Rows(i).Cells(0).Selected = True
                                Me.dgvAEListF.FirstDisplayedScrollingRowIndex = i
                                Exit For
                            End If
                        Next
                        dgvAEListF_SelectionChanged(Nothing, System.EventArgs.Empty)
                    End If
                End If
            Else
                GSubShowInfo(GFncGetSysMsg(56))
            End If
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ae_no As String = ""
        Dim ae_group As String = ""
        Dim txmonth As String = ""
        Dim isConsolid As String = ""
        Dim isFO As String = ""
        Dim conTO As String = ""
        Dim norTO As String = ""
        Dim intTO As String = ""
        Dim msg As String = ""
        If (Me.TabControl1.SelectedIndex = 0) Then
            ae_no = Me.cboAENoS.Text.Trim
            ae_group = Me.txtAccGroupS.Text.Trim
            txmonth = Me.txtMonthS.Text
            If (Me.cbConsolidS.Checked) Then
                isConsolid = "1"
            Else
                isConsolid = "0"
            End If
            isFO = "0"
            conTO = CStr(CDbl(Me.abMinConS.Text))
            norTO = CStr(CDbl(Me.abMinNorS.Text))
            intTO = CStr(CDbl(Me.abMinIntS.Text))
            msg = GFncGetSysMsg(10)
            If (action = "E") Then
                msg = GFncGetSysMsg(68) & " " & msg
            End If
            If (GSubShowYNConfirm(msg) = Windows.Forms.DialogResult.Yes) Then
                If (Me.cboAENoS.FindStringExact(ae_no) < 0) Then
                    GSubShowInfo(GFncGetSysMsg(31))
                    Me.cboAENoS.Focus()
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                'update db
                If (action = "A") Then
                    If (cls.lFncValidateS(ae_no, ae_group, txmonth)) Then
                        GSubShowInfo(GFncGetSysMsg(62))
                        Me.cboAENoS.Focus()
                        Return
                    End If
                    cls.lFncAddAES(ae_no, ae_group, txmonth, isConsolid, conTO, norTO, intTO)
                ElseIf (action = "E") Then
                    cls.lFncEditAES(ae_no, ae_group, preAEGroup, txmonth, isConsolid, conTO, norTO, intTO)
                End If
                'refresh form
                preAENo = ae_no
                refreshList()
                For i As Integer = 0 To Me.dgvAEListS.Rows.Count - 1
                    If (Me.dgvAEListS.Rows(i).Cells(0).Value = preAENo) Then
                        Me.dgvAEListS.Rows(i).Cells(0).Selected = True
                        Me.dgvAEListS.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                Next
                dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
                lSubControl(False)
                Me.cboAENoS.Enabled = False
                action = ""
                preAENo = ""
                GSubShowInfo(GFncGetSysMsg(8))
            End If
        ElseIf (Me.TabControl1.SelectedIndex = 1) Then
            ae_no = Me.cboAENoF.Text.Trim
            ae_group = Me.txtAccGroupF.Text.Trim
            txmonth = Me.txtMonthF.Text
            If (Me.cbConsolidF.Checked) Then
                isConsolid = "1"
            Else
                isConsolid = "0"
            End If
            If Me.cbBothFO.Checked Then
                isFO = "1"
            Else
                isFO = "0"
            End If
            conTO = CStr(Val(Me.abMinConF.Text))
            norTO = CStr(Val(Me.abMinNorF.Text))
            intTO = CStr(Val(Me.abMinIntF.Text))
            msg = GFncGetSysMsg(10)
            If (action = "E") Then
                msg = GFncGetSysMsg(69) & " " & msg
            End If
            If (GSubShowYNConfirm(msg) = Windows.Forms.DialogResult.Yes) Then
                If (Me.cboAENoF.FindStringExact(ae_no) < 0) Then
                    GSubShowInfo(GFncGetSysMsg(31))
                    Me.cboAENoF.Focus()
                    Return
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                'update db
                If (action = "A") Then
                    If (cls.lFncValidateF(ae_no, ae_group, txmonth)) Then
                        GSubShowInfo(GFncGetSysMsg(62))
                        Me.cboAENoF.Focus()
                        Return
                    End If
                    cls.lFncAddAEF(ae_no, ae_group, txmonth, isConsolid, conTO, norTO, intTO, isFO)
                ElseIf (action = "E") Then
                    cls.lFncEditAEF(ae_no, ae_group, preAEGroup, txmonth, isConsolid, conTO, norTO, intTO, isFO)
                End If
                'refresh form
                preAENo = ae_no
                refreshList()
                For i As Integer = 0 To Me.dgvAEListF.Rows.Count - 1
                    If (Me.dgvAEListF.Rows(i).Cells(0).Value = preAENo) Then
                        Me.dgvAEListF.Rows(i).Cells(0).Selected = True
                        Me.dgvAEListF.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                Next
                dgvAEListF_SelectionChanged(Nothing, System.EventArgs.Empty)
                lSubControl(False)
                Me.cboAENoF.Enabled = False
                action = ""
                preAENo = ""
                GSubShowInfo(GFncGetSysMsg(8))
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ((action = "A") Or (action = "E")) Then
            refreshList()
            If (Me.TabControl1.SelectedIndex = 0) Then
                For i As Integer = 0 To Me.dgvAEListS.Rows.Count - 1
                    If (Me.dgvAEListS.Rows(i).Cells(0).Value = preAENo) Then
                        Me.dgvAEListS.Rows(i).Cells(0).Selected = True
                        Me.dgvAEListS.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                Next
                dgvAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
            ElseIf (Me.TabControl1.SelectedIndex = 1) Then
                For i As Integer = 0 To Me.dgvAEListF.Rows.Count - 1
                    If (Me.dgvAEListF.Rows(i).Cells(0).Value = preAENo) Then
                        Me.dgvAEListF.Rows(i).Cells(0).Selected = True
                        Me.dgvAEListF.FirstDisplayedScrollingRowIndex = i
                        Exit For
                    End If
                Next
                dgvAEListF_SelectionChanged(Nothing, System.EventArgs.Empty)
            End If
            lSubControl(False)
            Me.cboAENoS.Enabled = False
            Me.cboAENoF.Enabled = False
            action = ""
            preAENo = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub lSubControl(ByVal flag As Boolean)
        Me.cboSrchYear.Enabled = False
        Me.cboSrchMonth.Enabled = False
        If (Me.TabControl1.SelectedIndex = 0) Then
            Me.dgvAEListS.Enabled = Not flag
            Me.dgvAEDetailS.Enabled = Not flag
            Me.txtAccGroupS.Enabled = flag
            Me.abMinConS.Enabled = flag
            Me.cbConsolidS.Enabled = flag
            Me.abMinNorS.Enabled = flag
            Me.abMinIntS.Enabled = flag
        ElseIf (Me.TabControl1.SelectedIndex = 1) Then
            Me.dgvAEListF.Enabled = Not flag
            Me.dgvAEDetailF.Enabled = Not flag
            Me.txtAccGroupF.Enabled = flag
            Me.abMinConF.Enabled = flag
            Me.cbConsolidF.Enabled = flag
            Me.cbBothFO.Enabled = flag
            Me.abMinNorF.Enabled = flag
            Me.abMinIntF.Enabled = flag
        End If
        Me.btnAdd.Enabled = Not flag
        Me.btnEdit.Enabled = Not flag
        Me.btnDelete.Enabled = Not flag
        Me.btnSave.Enabled = flag
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        refreshList()
    End Sub

End Class
