Public Class FrmCommRateGlobal
    Dim cls As New ClsCommRateGlobal
    Dim LoadFlag As Boolean
    Dim actionflag As String
    Dim EnqType As String

    Private Sub FrmCommRateGlobal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        LoadFlag = True
        EnqType = ""
        actionflag = ""
        LoadMonth()
        LoadFlag = False
        ObjEnable(False)
        Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub LoadMonth()
        Dim txmonth As String = GfncGetMonth()
        Dim yr As Integer = txmonth.Substring(0, 4)
        Dim mth As Integer = Val(txmonth.Substring(4, 2))
        For year As Integer = yr - 4 To yr + 4
            Me.ComboSrchYear.Items.Add(year)
            Me.comboYear.Items.Add(year)
        Next
        For mon As Integer = 1 To 12
            Me.comboMonth.Items.Add(mon)
            Me.comboSrchMonth.Items.Add(mon)
        Next
        Me.ComboSrchYear.SelectedIndex = Me.ComboSrchYear.FindString(yr)
        Me.comboSrchMonth.SelectedIndex = Me.comboSrchMonth.FindString(mth)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim condition As String = ""
        If Me.rbSrchAcc.Checked Then
            condition += " and comm_type ='ACC' "
        ElseIf Me.rbSrchAcGP.Checked Then
            condition += " and comm_type ='AGRP' "
        ElseIf Me.rbSrchAE.Checked Then
            condition += " and comm_type ='AE' "
        ElseIf Me.rbSrchMan.Checked Then
            condition += " and comm_type ='MAN' "
        Else
            condition += " and (comm_type ='ACC'  or comm_type = 'AGRP' or comm_type ='AE' or  comm_type ='MAN' ) "
        End If
        If Me.ComboSrchYear.Text.Length > 0 Then
            condition += " and txmonth='" & ComboSrchYear.Text & Format(Val(comboSrchMonth.Text), "00") & "'"
        End If
        Me.dtgGlobalRate.DataSource = cls.EnquirySearch(condition).Tables(0)
        If EnqType <> "" Then
            For row As Integer = 0 To Me.dtgGlobalRate.RowCount - 1
                If Me.dtgGlobalRate.Rows(row).Cells("comm_type").Value = EnqType Then
                    Me.dtgGlobalRate.Rows(row).Cells("txmonth").Selected = True
                    Exit For
                End If
            Next
            EnqType = ""
        End If
        dtgGlobalRate_SelectionChanged(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If actionflag <> "" Then
            actionflag = ""
            ObjEnable(False)
            'AEEnable(False)
            ManEnable(False)
            Me.dtgGlobalRate_SelectionChanged(Nothing, System.EventArgs.Empty)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub dtgGlobalRate_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgGlobalRate.SelectionChanged
        If Me.dtgGlobalRate.Rows.Count > 0 Then
            Me.txtCommIntRate.Text = Me.dtgGlobalRate.CurrentRow.Cells("CommIntRate").Value
            Me.txtcommIntRate_f.Text = Me.dtgGlobalRate.CurrentRow.Cells("commIntRate_f").Value
            Me.txtcommNorRate.Text = Me.dtgGlobalRate.CurrentRow.Cells("commNorRate").Value
            Me.txtCommNorRate_f.Text = Me.dtgGlobalRate.CurrentRow.Cells("CommNorRate_f").Value
            Me.txtMinFIntBrkRate.Text = Me.dtgGlobalRate.CurrentRow.Cells("MinFIntBrkRate").Value
            Me.txtminFNorBrkRate.Text = Me.dtgGlobalRate.CurrentRow.Cells("minFNorBrkRate").Value
            Me.txtMinIntAmt.Text = Me.dtgGlobalRate.CurrentRow.Cells("MinIntAmt").Value
            Me.txtminIntRate_s.Text = Me.dtgGlobalRate.CurrentRow.Cells("minIntRate_s").Value
            Me.txtMinNorAmt.Text = Me.dtgGlobalRate.CurrentRow.Cells("MinNorAmt").Value
            Me.txtMinNorRate_s.Text = Me.dtgGlobalRate.CurrentRow.Cells("MinNorRate_s").Value
            Me.txtMinOIntBrkRate.Text = Me.dtgGlobalRate.CurrentRow.Cells("MinOIntBrkRate").Value
            Me.txtMinONorBrkRate.Text = Me.dtgGlobalRate.CurrentRow.Cells("MinONorBrkRate").Value
            Select Case Me.dtgGlobalRate.CurrentRow.Cells("comm_type").Value
                Case "Account"
                    Me.rbACC.Checked = True
                Case "A/C Group"
                    Me.rbAGRP.Checked = True
                Case "AE"
                    Me.rbAE.Checked = True
                Case "Manager"
                    Me.rbMan.Checked = True
            End Select
            Me.comboYear.Text = Me.dtgGlobalRate.CurrentRow.Cells("txmonth").Value.ToString.Substring(0, 4)
            Me.comboMonth.Text = Val(Me.dtgGlobalRate.CurrentRow.Cells("txmonth").Value.ToString.Substring(4, 2))
            Me.btnEdit.Enabled = True
            Me.btnDelete.Enabled = True
        Else
            EmptyField()
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
        End If
    End Sub

    Private Sub rbSrchAcc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAcc.CheckedChanged
        If LoadFlag = False And Me.rbSrchAcc.Checked = True Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchAcGP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAcGP.CheckedChanged
        If LoadFlag = False And Me.rbSrchAcGP.Checked = True Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub
   
    Private Sub rbSrchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAll.CheckedChanged
        If LoadFlag = False And Me.rbSrchAll.Checked = True Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchAE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAE.CheckedChanged
        If LoadFlag = False And Me.rbSrchAE.Checked = True Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub rbSrchMan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchMan.CheckedChanged
        If LoadFlag = False And Me.rbSrchMan.Checked = True Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub ComboSrchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboSrchYear.SelectedIndexChanged
        If LoadFlag = False And Me.ComboSrchYear.Text.Length > 0 And Me.comboSrchMonth.Text.Length > 0 Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub comboSrchMonth_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles comboSrchMonth.SelectedIndexChanged
        If LoadFlag = False And Me.ComboSrchYear.Text.Length > 0 And Me.comboSrchMonth.Text.Length > 0 Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub ObjEnable(ByVal blnflag As Boolean)
        Me.ComboSrchYear.Enabled = False
        Me.comboSrchMonth.Enabled = False
        Me.rbSrchAcc.Enabled = Not blnflag
        Me.rbSrchAcGP.Enabled = Not blnflag
        Me.rbSrchAE.Enabled = Not blnflag
        Me.rbSrchMan.Enabled = Not blnflag
        Me.rbSrchAll.Enabled = Not blnflag
        Me.btnSearch.Enabled = Not blnflag
        Me.dtgGlobalRate.Enabled = Not blnflag
        If actionflag = "New" Then
            Me.comboYear.Enabled = False
            Me.comboMonth.Enabled = False
            Me.rbACC.Enabled = blnflag
            Me.rbAGRP.Enabled = blnflag
            Me.rbAE.Enabled = blnflag
            Me.rbMan.Enabled = blnflag
        Else
            Me.comboYear.Enabled = False
            Me.comboMonth.Enabled = False
            Me.rbACC.Enabled = False
            Me.rbAGRP.Enabled = False
            Me.rbAE.Enabled = False
            Me.rbMan.Enabled = False
        End If
        Me.txtMinONorBrkRate.Visible = False
        Me.txtMinOIntBrkRate.Visible = False
        Me.txtminFNorBrkRate.Visible = False
        Me.txtMinFIntBrkRate.Visible = False
        Me.txtMinONorBrkRate.Enabled = blnflag
        Me.txtMinOIntBrkRate.Enabled = blnflag
        Me.txtMinNorRate_s.Enabled = blnflag
        Me.txtMinNorAmt.Enabled = blnflag
        Me.txtminIntRate_s.Enabled = blnflag
        Me.txtMinIntAmt.Enabled = blnflag
        Me.txtminFNorBrkRate.Enabled = blnflag
        Me.txtMinFIntBrkRate.Enabled = blnflag
        Me.txtCommNorRate_f.Enabled = blnflag
        Me.txtcommNorRate.Enabled = blnflag
        Me.txtcommIntRate_f.Enabled = blnflag
        Me.txtCommIntRate.Enabled = blnflag
        Me.btnNew.Enabled = Not blnflag
        Me.btnEdit.Enabled = Not blnflag
        Me.btnDelete.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
    End Sub

    Private Sub EmptyField()
        Me.txtMinONorBrkRate.Text = "0.0000"
        Me.txtMinOIntBrkRate.Text = "0.0000"
        Me.txtMinNorRate_s.Text = "0.0000"
        Me.txtMinNorAmt.Text = "0.00"
        Me.txtminIntRate_s.Text = "0.0000"
        Me.txtMinIntAmt.Text = "0.00"
        Me.txtminFNorBrkRate.Text = "0.0000"
        Me.txtMinFIntBrkRate.Text = "0.0000"
        Me.txtCommNorRate_f.Text = "0.0000"
        Me.txtcommNorRate.Text = "0.0000"
        Me.txtcommIntRate_f.Text = "0.0000"
        Me.txtCommIntRate.Text = "0.0000"
        Me.rbACC.Checked = True
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        actionflag = "New"
        ObjEnable(True)
        EmptyField()
        If Me.rbSrchAcGP.Checked Then
            Me.rbAGRP.Checked = True
        ElseIf Me.rbSrchAE.Checked Then
            Me.rbAE.Checked = True
            'AEEnable(True)
        ElseIf Me.rbSrchMan.Checked Then
            Me.rbMan.Checked = True
            ManEnable(True)
        Else
            Me.rbACC.Checked = True
        End If
        Me.comboYear.Text = Me.ComboSrchYear.Text
        Me.comboMonth.Text = Me.comboSrchMonth.Text
        If Me.rbAE.Checked Then
            Me.rbAE_CheckedChanged(Nothing, System.EventArgs.Empty)
            'AEEnable(True)
        ElseIf Me.rbMan.Checked Then
            'ManEnable(True)
            Me.rbAMan_CheckedChanged(Nothing, System.EventArgs.Empty)
        End If
        Me.txtMinNorAmt.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dtgGlobalRate.Rows.Count > 0 Then
            actionflag = "Edit"
            ObjEnable(True)
            If Me.rbAE.Checked Then
                Me.rbAE_CheckedChanged(Nothing, System.EventArgs.Empty)
                'AEEnable(True)
            ElseIf Me.rbMan.Checked Then
                'ManEnable(True)
                Me.rbAMan_CheckedChanged(Nothing, System.EventArgs.Empty)
            End If
            Me.txtMinNorAmt.Focus()
        End If
    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim txmonth As String = ""
        'Dim type As String = ""
        txmonth = Me.comboYear.Text & Format(Val(Me.comboMonth.Text), "00")
        If Me.rbACC.Checked Then
            EnqType = "ACC"
        ElseIf Me.rbAGRP.Checked Then
            EnqType = "AGRP"
        ElseIf Me.rbAE.Checked Then
            EnqType = "AE"
        ElseIf Me.rbMan.Checked Then
            EnqType = "MAN"
        End If
        Select Case actionflag
            Case "New"
                If cls.ValidateDuplicate(txmonth, EnqType) = True Then
                    GSubShowInfo(GFncGetSysMsg(62))
                    Return
                End If
                If Not CheckField() Then
                    Return
                End If
                If GSubShowYNConfirm(GFncGetSysMsg(40), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                'If EnqType = "AE" Then
                '    Me.txtminFNorBrkRate.Text = 0
                '    Me.txtMinFIntBrkRate.Text = 0
                '    Me.txtCommNorRate_f.Text = 0
                '    Me.txtMinONorBrkRate.Text = 0
                '    Me.txtMinOIntBrkRate.Text = 0
                '    Me.txtcommIntRate_f.Text = 0
                'Else
                If EnqType = "MAN" Then
                    Me.txtminFNorBrkRate.Text = 0
                    Me.txtMinFIntBrkRate.Text = 0
                    Me.txtCommNorRate_f.Text = 0
                    Me.txtMinONorBrkRate.Text = 0
                    Me.txtMinOIntBrkRate.Text = 0
                    Me.txtcommIntRate_f.Text = 0
                    Me.txtMinNorAmt.Text = 0
                    Me.txtCommIntRate.Text = CDbl(txtcommNorRate.Text)
                    Me.txtMinIntAmt.Text = 0
                    Me.txtminIntRate_s.Text = CDbl(txtMinNorRate_s.Text)
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                cls.NewRecord(txmonth, EnqType, Me.txtMinNorAmt.Text, Me.txtMinIntAmt.Text, Me.txtMinNorRate_s.Text, _
                    Me.txtminIntRate_s.Text, Me.txtcommNorRate.Text, Me.txtCommIntRate.Text, Me.txtminFNorBrkRate.Text, _
                    Me.txtMinFIntBrkRate.Text, Me.txtMinONorBrkRate.Text, Me.txtMinOIntBrkRate.Text, Me.txtCommNorRate_f.Text, _
                    Me.txtcommIntRate_f.Text)
                Me.ComboSrchYear.Text = Me.comboYear.Text
                Me.comboSrchMonth.Text = Me.comboYear.Text
                Select Case EnqType
                    Case "ACC"
                        EnqType = "Account"
                    Case "AGRP"
                        EnqType = "A/C Group"
                    Case "AE"
                        EnqType = "AE"
                    Case "MAN"
                        EnqType = "MAN"
                End Select
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                actionflag = ""
                ObjEnable(False)
                Me.dtgGlobalRate_SelectionChanged(Nothing, System.EventArgs.Empty)
                Me.dtgGlobalRate.Focus()
            Case "Edit"
                If cls.ValidateDuplicate(txmonth, EnqType) = False Then
                    GSubShowInfo(GFncGetSysMsg(24))
                    Return
                End If
                If Not CheckField() Then
                    Return
                End If
                If GSubShowYNConfirm(GFncGetSysMsg(39), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                    Return
                End If
                'If EnqType = "AE" Then
                '    Me.txtminFNorBrkRate.Text = 0
                '    Me.txtMinFIntBrkRate.Text = 0
                '    Me.txtCommNorRate_f.Text = 0
                '    Me.txtMinONorBrkRate.Text = 0
                '    Me.txtMinOIntBrkRate.Text = 0
                '    Me.txtcommIntRate_f.Text = 0
                'Else
                If EnqType = "MAN" Then
                    Me.txtminFNorBrkRate.Text = 0
                    Me.txtMinFIntBrkRate.Text = 0
                    Me.txtCommNorRate_f.Text = 0
                    Me.txtMinONorBrkRate.Text = 0
                    Me.txtMinOIntBrkRate.Text = 0
                    Me.txtcommIntRate_f.Text = 0
                    Me.txtMinNorAmt.Text = 0
                    Me.txtCommIntRate.Text = CDbl(txtcommNorRate.Text)
                    Me.txtMinIntAmt.Text = 0
                    Me.txtminIntRate_s.Text = CDbl(Me.txtMinNorRate_s.Text)
                End If
                If GFncCheckCommStatus() Then
                    Return
                End If
                cls.EditRecord(txmonth, EnqType, Me.txtMinNorAmt.Text, Me.txtMinIntAmt.Text, Me.txtMinNorRate_s.Text, _
                    Me.txtminIntRate_s.Text, Me.txtcommNorRate.Text, Me.txtCommIntRate.Text, Me.txtminFNorBrkRate.Text, _
                    Me.txtMinFIntBrkRate.Text, Me.txtMinONorBrkRate.Text, Me.txtMinOIntBrkRate.Text, Me.txtCommNorRate_f.Text, _
                    Me.txtcommIntRate_f.Text)
                Select Case EnqType
                    Case "ACC"
                        EnqType = "Account"
                    Case "AGRP"
                        EnqType = "A/C Group"
                    Case "AE"
                        EnqType = "AE"
                    Case "MAN"
                        EnqType = "Manager"
                End Select
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
                actionflag = ""
                ObjEnable(False)
                Me.dtgGlobalRate_SelectionChanged(Nothing, System.EventArgs.Empty)
                Me.dtgGlobalRate.Focus()
        End Select
        ManEnable(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dtgGlobalRate.SelectedRows.Count > 0 Then
            If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            Dim txmonth As String = ""
            Dim type As String = ""
            txmonth = Me.comboYear.Text & Format(Val(Me.comboMonth.Text), "00")
            If Me.rbACC.Checked Then
                type = "ACC"
            ElseIf Me.rbAGRP.Checked Then
                type = "AGRP"
            ElseIf Me.rbAE.Checked Then
                type = "AE"
            ElseIf Me.rbMan.Checked Then
                type = "MAN"
            End If
            If cls.ValidateDuplicate(txmonth, type) = False Then
                GSubShowInfo(GFncGetSysMsg(24))
                Return
            End If
            If GFncCheckCommStatus() Then
                Return
            End If
            cls.DeleteRecord(txmonth, type)
            'ac = Me.dtgAC.CurrentRow.Cells("ACno").Value.ToString.Trim
            ObjEnable(False)
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
            Me.dtgGlobalRate_SelectionChanged(Nothing, System.EventArgs.Empty)
        Else
            GSubShowInfo(GFncGetSysMsg(24))
        End If
        Me.dtgGlobalRate.Focus()
    End Sub

    Private Function CheckField() As Boolean
        Dim ErrorMsg As String = ""
        If Me.rbACC.Checked = False And Me.rbAGRP.Checked = False And Me.rbAE.Checked = False And Me.rbMan.Checked = False Then
            Return False
        End If
        If Me.comboYear.Text.Length <= 0 And Me.comboMonth.Text.Length <= 0 Then
            Return False
        End If
        If Me.txtMinNorAmt.Text.Length <= 0 Then
            GSubShowInfo(lblMinNorAmt.Text & " " & GFncGetSysMsg(55))
            Me.txtMinNorAmt.Focus()
            Return False
        End If
        If Me.txtMinNorRate_s.Text.Length <= 0 Then
            GSubShowInfo(lblMinNorRate_s.Text & " " & GFncGetSysMsg(55))
            Me.txtMinNorRate_s.Focus()
            Return False
        End If
        If Me.txtcommNorRate.Text.Length <= 0 Then
            GSubShowInfo(lblcommNorRate.Text & " " & GFncGetSysMsg(55))
            Me.txtcommNorRate.Focus()
            Return False
        End If
        
        If Me.txtMinIntAmt.Text.Length <= 0 Then
            GSubShowInfo(lblMinIntAmt.Text & " " & GFncGetSysMsg(55))
            Me.txtMinIntAmt.Focus()
            Return False
        End If
        If Me.txtminIntRate_s.Text.Length <= 0 Then
            GSubShowInfo(lblminIntRate_s.Text & " " & GFncGetSysMsg(55))
            Me.txtminIntRate_s.Focus()
            Return False
        End If
        If Me.txtCommIntRate.Text.Length <= 0 Then
            GSubShowInfo(lblCommIntRate.Text & " " & GFncGetSysMsg(55))
            Me.txtCommIntRate.Focus()
            Return False
        End If
       
        If Me.txtminFNorBrkRate.Text.Length <= 0 Then
            GSubShowInfo(lblminFNorBrkRate.Text & " " & GFncGetSysMsg(55))
            Me.txtminFNorBrkRate.Focus()
            Return False
        End If
        If Me.txtMinFIntBrkRate.Text.Length <= 0 Then
            GSubShowInfo(lblMinFIntBrkRate.Text & " " & GFncGetSysMsg(55))
            Me.txtMinFIntBrkRate.Focus()
            Return False
        End If
        If Me.txtCommNorRate_f.Text.Length <= 0 Then
            GSubShowInfo(lblCommNorRate_f.Text & " " & GFncGetSysMsg(55))
            Me.txtCommNorRate_f.Focus()
            Return False
        End If

        If Me.txtMinONorBrkRate.Text.Length <= 0 Then
            GSubShowInfo(lblMinONorBrkRate.Text & " " & GFncGetSysMsg(55))
            Me.txtMinONorBrkRate.Focus()
            Return False
        End If
        If Me.txtMinOIntBrkRate.Text.Length <= 0 Then
            GSubShowInfo(lblMinOIntBrkRate.Text & " " & GFncGetSysMsg(55))
            Me.txtMinOIntBrkRate.Focus()
            Return False
        End If

        If Me.txtcommIntRate_f.Text.Length <= 0 Then
            GSubShowInfo(lblcommIntRate_f.Text & " " & GFncGetSysMsg(55))
            Me.txtcommIntRate_f.Focus()
            Return False
        End If
        Return True
    End Function

    Private Sub rbAE_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAE.CheckedChanged
        If LoadFlag = False And actionflag <> "" Then
            ManEnable(Not rbMan.Checked)
            'AEEnable(Not rbAE.Checked)
        End If
    End Sub

    Private Sub rbAGRP_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAGRP.CheckedChanged
        If LoadFlag = False And actionflag <> "" Then
            'AEEnable(Not rbAE.Checked)
            ManEnable(Not rbMan.Checked)
        End If
    End Sub

    Private Sub rbACC_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbACC.CheckedChanged
        If LoadFlag = False And actionflag <> "" Then
            'AEEnable(Not rbAE.Checked)
            ManEnable(Not rbMan.Checked)
        End If
    End Sub

    Private Sub rbAMan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMan.CheckedChanged
        If LoadFlag = False And actionflag <> "" Then
            'AEEnable(Not rbAE.Checked)
            ManEnable(Not rbMan.Checked)
        End If
    End Sub

    'Private Sub AEEnable(ByVal blnFlag As Boolean)
    '    Me.txtminFNorBrkRate.Enabled = blnFlag
    '    Me.txtMinFIntBrkRate.Enabled = blnFlag
    '    Me.txtCommNorRate_f.Enabled = blnFlag
    '    Me.txtMinONorBrkRate.Enabled = blnFlag
    '    Me.txtMinOIntBrkRate.Enabled = blnFlag
    '    Me.txtcommIntRate_f.Enabled = blnFlag
    'End Sub
    Private Sub ManEnable(ByVal blnFlag As Boolean)
        Me.txtminFNorBrkRate.Enabled = blnFlag
        Me.txtMinFIntBrkRate.Enabled = blnFlag
        Me.txtCommNorRate_f.Enabled = blnFlag
        Me.txtMinONorBrkRate.Enabled = blnFlag
        Me.txtMinOIntBrkRate.Enabled = blnFlag
        Me.txtcommIntRate_f.Enabled = blnFlag
        Me.txtMinNorAmt.Enabled = blnFlag
        Me.txtCommIntRate.Enabled = blnFlag
        Me.txtMinIntAmt.Enabled = blnFlag
        Me.txtminIntRate_s.Enabled = blnFlag
    End Sub

End Class