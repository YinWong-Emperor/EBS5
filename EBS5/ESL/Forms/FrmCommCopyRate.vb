Imports System.Data.SqlClient

Public Class FrmCommCopyRate
    Dim LoadFlag As Boolean = True
    Dim cls As New ClsCommCopyRate
    'Dim gdtAE As DataTable = Nothing
    'Dim gdtAcc As DataTable = Nothing
    Dim ActionFlag As String = ""
    Dim AdjDT As DataTable = Nothing

    Private Sub FrmCommCopyRate_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        LoadFlag = True
        LoadMonth()
        'AdjDT = cls.lFncGetAdjList().tables("adj")
        ObjEnable(False)
        LoadFlag = False
        Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub ObjEnable(ByVal blnflag As Boolean)
        Me.cboSrchMonth.Enabled = False
        Me.cboSrchYear.Enabled = False
        Me.txtSrchAcc.Enabled = Not blnflag
        Me.txtSrchAe.Enabled = Not blnflag
        Me.rbSrchAll.Enabled = Not blnflag
        Me.rbSrchInt.Enabled = Not blnflag
        Me.rbSrchNor.Enabled = Not blnflag
        Me.btnSearch.Enabled = Not blnflag
        Me.cbAll.Enabled = blnflag
        Me.btnSave.Enabled = blnflag
        Me.btnImport.Enabled = Not blnflag
    End Sub

    Private Sub LoadMonth()
        Dim month As String = GfncGetMonth()
        For mon As Integer = 1 To 12
            Me.cboSrchMonth.Items.Add(mon)
        Next
        If month = 0 Then
            For yr As Integer = Now.Year - 5 To Now.Year + 5
                Me.cboSrchYear.Items.Add(yr)
            Next
            Me.cboSrchMonth.SelectedIndex = Me.cboSrchMonth.FindString(Now.Month)
            Me.cboSrchYear.SelectedIndex = Me.cboSrchYear.FindString(Now.Year)
        Else
            For yr As Integer = CDbl(month.Substring(0, 4)) - 5 To CDbl(month.Substring(0, 4)) + 5
                Me.cboSrchYear.Items.Add(yr)
            Next
            Me.cboSrchMonth.SelectedIndex = Me.cboSrchMonth.FindString(Val(month.Substring(4, 2)))
            Me.cboSrchYear.SelectedIndex = Me.cboSrchYear.FindString(month.Substring(0, 4))
        End If
    End Sub

    'Private Sub btnAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcc.Click
    '    cls.lFncImportAcc(Me.txtAcc.Text)
    '    MessageBox.Show("imported")
    '    Me.txtAcc.Text = ""
    'End Sub

    'Private Sub btnAE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAE.Click
    '    cls.lFncImportAE(Me.txtAE.Text)
    '    MessageBox.Show("imported")
    '    Me.txtAE.Text = ""
    'End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        ActionFlag = "I"
        Dim CurrAE As String = ""
        If Me.dtgAEList.Rows.Count > 0 Then
            CurrAE = Me.dtgAEList.CurrentRow.Cells("ae_no").Value
        End If
        ObjEnable(True)
        Dim month As String = Me.cboSrchYear.Text & Format(Val(cboSrchMonth.Text), "00")
        Dim acc As String = Me.txtSrchAcc.Text
        Dim ae As String = Me.txtSrchAe.Text
        Dim TradeType As String = ""
        If Me.rbSrchNor.Checked Then
            TradeType = "NOR"
        ElseIf Me.rbSrchInt.Checked Then
            TradeType = "INT"
        End If
        Me.dtgAEList.DataSource = cls.lFncGetAeImportList(month, acc, ae, TradeType).Tables("ae")
        lFncGoRecord(CurrAE)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If ActionFlag <> "" Then
            Me.ActionFlag = ""
            ObjEnable(False)
            Dim CurrAE As String = ""
            If Me.dtgAEList.Rows.Count > 0 Then
                CurrAE = Me.dtgAEList.CurrentRow.Cells("ae_no").Value
            End If
            Me.cbAll.Checked = False
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
            lFncGoRecord(CurrAE)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If LoadFlag = False Then
            If Me.cboSrchYear.Text.Length > 0 Or Me.cboSrchMonth.Text.Length > 0 And dtgAEList.Rows.Count > 0 Then
                Dim month As String = Me.cboSrchYear.Text & Format(Val(cboSrchMonth.Text), "00")
                Dim acc As String = Me.txtSrchAcc.Text
                Dim ae As String = Me.txtSrchAe.Text
                Dim TradeType As String = ""
                If Me.rbSrchNor.Checked Then
                    TradeType = "NOR"
                ElseIf Me.rbSrchInt.Checked Then
                    TradeType = "INT"
                End If
                Me.dtgAEList.DataSource = cls.lFncLoadAEDTG(month, acc, ae, TradeType).Tables("ae")
            End If
        End If
    End Sub

    Private Sub SetDTG()
        Dim blnflag As Boolean = False
        If ActionFlag <> "" Then
            blnflag = True
        End If
        For row As Integer = 0 To Me.dtgCopyRate.Rows.Count - 1
            For col As Integer = 0 To Me.dtgCopyRate.ColumnCount - 1
                If Me.dtgCopyRate.Rows(row).Cells(col).ColumnIndex <> Me.dtgCopyRate.Columns("Edit").Index Then
                    Me.dtgCopyRate.Rows(row).Cells(col).ReadOnly = True
                    Me.dtgCopyRate.Rows(row).Cells(col).Style.BackColor = Color.Linen
                Else
                    Me.dtgCopyRate.Rows(row).Cells(col).ReadOnly = Not blnflag
                    If blnflag Then
                        Me.dtgCopyRate.Rows(row).Cells(col).Style.BackColor = Color.White
                    Else
                        Me.dtgCopyRate.Rows(row).Cells(col).Style.BackColor = Color.Linen
                        Me.dtgCopyRate.Rows(row).Cells("Edit").Value = False
                    End If
                End If
            Next
        Next
    End Sub

    Private Sub cbAll_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbAll.CheckedChanged
        For row As Integer = 0 To Me.dtgCopyRate.Rows.Count - 1
            Me.dtgCopyRate.Rows(row).Cells("Edit").Value = cbAll.Checked
        Next
    End Sub

    Private Sub dtgAEList_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgAEList.SelectionChanged
        If LoadFlag = False And Me.cboSrchYear.Text.Length > 0 And Me.cboSrchMonth.Text.Length > 0 And dtgAEList.Rows.Count > 0 Then
            Dim month As String = Me.cboSrchYear.Text & Format(Val(cboSrchMonth.Text), "00")
            Dim acc As String = Me.txtSrchAcc.Text
            Dim ae As String = Me.dtgAEList.CurrentRow.Cells("ae_no").Value
            Dim TradeType As String = ""
            If Me.rbSrchNor.Checked Then
                TradeType = "NOR"
            ElseIf Me.rbSrchInt.Checked Then
                TradeType = "INT"
            End If
            If ActionFlag = "" Then
                Me.dtgCopyRate.DataSource = cls.lFncLoadDTG(month, acc, ae, TradeType)
                'Me.dtgCopyRate.DataMember = "afe_rate_s"
            Else
                Me.dtgCopyRate.DataSource = cls.lFncLoadImportDTG(month, acc, ae, TradeType)
                'Me.dtgCopyRate.DataMember = "afe_rate_s"
            End If
            Me.dtgCopyRate.DataMember = "afe_rate_s"
            Me.cbAll.Checked = False
            SetDTG()
        End If
    End Sub

    Private Sub rbSrchNor_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchNor.CheckedChanged
        If LoadFlag = False And Me.cboSrchYear.Text.Length > 0 And Me.cboSrchMonth.Text.Length > 0 Then
            If rbSrchNor.Checked Then
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub rbSrchInt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchInt.CheckedChanged
        If LoadFlag = False And Me.cboSrchYear.Text.Length > 0 And Me.cboSrchMonth.Text.Length > 0 Then
            If rbSrchInt.Checked Then
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub rbSrchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchAll.CheckedChanged
        If LoadFlag = False And Me.cboSrchYear.Text.Length > 0 And Me.cboSrchMonth.Text.Length > 0 Then
            If rbSrchAll.Checked Then
                Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
            End If
        End If
    End Sub

    Private Sub cboSrchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSrchMonth.SelectedIndexChanged
        If LoadFlag = False And Me.cboSrchYear.Text.Length > 0 And Me.cboSrchMonth.Text.Length > 0 Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub cboSrchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSrchYear.SelectedIndexChanged, cboSrchYear.LostFocus
        If LoadFlag = False And Me.cboSrchYear.Text.Length > 0 And Me.cboSrchMonth.Text.Length > 0 Then
            Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Me.dtgAEList.Rows.Count <= 0 Then
            GSubShowInfo(GFncGetSysMsg(81))
            Return
        End If
        Dim MyTrans As SqlTransaction = Nothing
        Dim ae_no As String = ""
        If ActionFlag = "I" Then
            If (GSubShowYNConfirm(GFncGetSysMsg(82), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
                If GFncCheckCommStatus() Then
                    Return
                End If
                Dim comm_month As String = Me.cboSrchYear.Text & Format(Val(cboSrchMonth.Text), "00")
                Dim acc_no As String = ""
                ae_no = Me.dtgAEList.CurrentRow.Cells("ae_no").Value
                Dim TType As String = ""
                Try
                    MyTrans = GSCnSqlConn.BeginTransaction
                    For row As Integer = 0 To Me.dtgCopyRate.Rows.Count - 1
                        If Me.dtgCopyRate.Rows(row).Cells("Edit").Value = True Then
                            acc_no = Me.dtgCopyRate.Rows(row).Cells("accno").Value
                            Select Case Me.dtgCopyRate.Rows(row).Cells("fee_nature_name").Value.ToString.Trim
                                Case "A/E Rebate"
                                    TType = "NOR"
                                Case "A/E Rebate (i)"
                                    TType = "INT"
                            End Select
                            cls.lFncImportAcc(acc_no, ae_no, comm_month, TType, MyTrans)
                            cls.lFncImportAccToMaster(acc_no, ae_no, comm_month, TType, MyTrans)
                        End If
                    Next
                    MyTrans.Commit()
                    MyTrans = Nothing
                Catch ex As Exception
                    If GSCnSqlConn.State <> ConnectionState.Closed Then
                        If (MyTrans IsNot Nothing) Then
                            MyTrans.Rollback()
                        End If
                        GSubWriteErrLog(ex.Message)
                    End If
                End Try
            Else
                Return
            End If
        End If
        ActionFlag = ""
        ObjEnable(False)
        Me.cbAll.Checked = False
        Me.btnSearch_Click(Nothing, System.EventArgs.Empty)
        lFncGoRecord(ae_no)
        SetDTG()
        GSubShowInfo(GFncGetSysMsg(8))
    End Sub

    'Private Sub txtSrchAe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSrchAe.LostFocus
    '    If LoadFlag = False And ActionFlag = "I" Then
    '        For row As Integer = 0 To Me.dtgAEList.Rows.Count - 1
    '            If Me.dtgAEList.Rows(row).Cells("ae_no").Value = Me.txtSrchAe.Text Then
    '                Me.dtgAEList.Rows(row).Cells("ae_no").Selected = True
    '                Me.dtgAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
    '                Exit For
    '            End If
    '        Next
    '    End If
    'End Sub

    Private Sub dtgCopyRate_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgCopyRate.Sorted
        SetDTG()
    End Sub

    Private Sub lFncGoRecord(ByVal CurrAE As String)
        If CurrAE <> "" Then
            For row As Integer = 0 To Me.dtgAEList.RowCount - 1
                If dtgAEList.Rows(row).Cells("ae_no").Value = CurrAE Then
                    dtgAEList.Rows(row).Cells("ae_no").Selected = True
                    Exit For
                End If
            Next
            Me.dtgAEList_SelectionChanged(Nothing, System.EventArgs.Empty)
        End If
    End Sub
End Class
