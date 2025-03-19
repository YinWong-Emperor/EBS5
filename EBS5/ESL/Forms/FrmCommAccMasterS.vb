Imports System.Data.SqlClient

Public Class FrmCommAccMasterS

    Dim AccMaster As DataTable
    Dim AeMaster As DataTable
    Dim LoadFlag As Boolean = False
    Dim useraction As String
    Dim cls As New clscommAccMasterS


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If useraction <> "" Then
            Me.cbBatchAll.Checked = False
            useraction = ""
            ObjEnable(False)
            Me.dtgAccDetail_SelectionChanged(Nothing, System.EventArgs.Empty)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub FrmCommAccMasterS_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        LoadFlag = True
        useraction = ""
        LoadAccAeNo()
        LoadMonth()
        Me.dtgAccDetail.Visible = True
        Me.dtgDetatil_B.Visible = False
        Me.rbSrchSec.Checked = True
        Me.cboACGrp.Text = ""

        LoadFlag = False
        ObjEnable(False)
        rbSrchSec_CheckedChanged(Nothing, System.EventArgs.Empty)
        LoadAEDT()
    End Sub

    Private Sub LoadAccAeNo()
        AccMaster = cls.LoadAccNo().Tables("Acc")
        AeMaster = cls.LoadAeNo().Tables("Ae")
    End Sub

    Private Sub LoadMonth()
        Dim mxmonth As String = GfncGetMonth()
        Dim month As String = Val(mxmonth.Substring(4, 2))
        Dim year As String = mxmonth.Substring(0, 4)
        For mon As Integer = 1 To 12
            Me.cboSrchMonth.Items.Add(mon)
        Next
        For yr As Integer = Val(year) - 3 To Val(year) + 3
            Me.cboSrchYear.Items.Add(yr)
        Next

        Me.cboSrchYear.SelectedIndex = Me.cboSrchYear.FindString(year)
        Me.cboSrchMonth.SelectedIndex = Me.cboSrchMonth.FindString(month)

    End Sub

    Private Sub LoadAEDT()
        If Me.cboSrchYear.Text.Length > 0 And Me.cboSrchMonth.Text.Length > 0 Then
            Dim month As String = cboSrchYear.Text & Format(Val(cboSrchMonth.Text), "00")
            Dim type As String = ""
            Dim Acc As String = ""
            Dim AE As String = ""
            If Me.rbSrchFut.Checked Then
                type = cls.comm_type_Fut
            ElseIf Me.rbSrchSec.Checked Then
                type = cls.comm_type_Sec
            End If
            If Me.txtSrchAcc.Text.Trim.Length > 0 Then
                Acc = Me.txtSrchAcc.Text.Trim
            End If
            If Me.txtSrcAE.Text.Trim.Length > 0 Then
                AE = Me.txtSrcAE.Text.Trim
            End If
            Me.dtgAE.DataSource = cls.LoadAeByMonth(month, type, Acc, AE).Tables("ae")
            dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub cboSrchYear_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSrchYear.SelectedIndexChanged
        If LoadFlag = False And cboSrchYear.Text.Length > 0 And cboSrchMonth.Text.Length > 0 Then
            LoadAEDT()
        End If
    End Sub

    Private Sub cboSrchMonth_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboSrchMonth.SelectedIndexChanged
        If LoadFlag = False And cboSrchYear.Text.Length > 0 And cboSrchMonth.Text.Length > 0 Then
            LoadAEDT()
        End If
    End Sub

    Private Sub rbSrchSec_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchSec.CheckedChanged
        If LoadFlag = False And Me.rbSrchSec.Checked Then

            Me.cboAENo.Items.Clear()
            Dim AErow() As DataRow = AeMaster.Select("inSec=1", "ae_no asc ")
            For Each dr As DataRow In AErow
                Me.cboAENo.Items.Add(dr.Item("ae_no"))
            Next
            Me.cboAccNo.Items.Clear()
            Dim ACrow() As DataRow = AccMaster.Select("inSec=1", "acc_no asc ")
            For Each dr As DataRow In ACrow
                Me.cboAccNo.Items.Add(dr.Item("acc_no"))
            Next
            Me.ObjEnable(False)
            LoadAEDT()
        End If
    End Sub

    Private Sub rbSrchFut_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbSrchFut.CheckedChanged
        If LoadFlag = False And Me.rbSrchFut.Checked Then
            Me.cboAENo.Items.Clear()
            Dim AErow() As DataRow = AeMaster.Select("inFut=1", "ae_no asc ")
            For Each dr As DataRow In AErow
                Me.cboAENo.Items.Add(dr.Item("ae_no"))
            Next
            Me.cboAccNo.Items.Clear()
            Dim ACrow() As DataRow = AccMaster.Select("inFut=1", "acc_no asc ")
            For Each dr As DataRow In ACrow
                Me.cboAccNo.Items.Add(dr.Item("acc_no"))
            Next
            Me.ObjEnable(False)
            LoadAEDT()
        End If
    End Sub

    Private Sub dtgAE_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgAE.SelectionChanged
        If LoadFlag = False Then
            If Me.dtgAE.RowCount > 0 Then
                Dim ae As String = ""
                Dim month As String = ""
                Dim type As String = ""
                Dim Acc As String = ""

                ae = Me.dtgAE.CurrentRow.Cells("ae_no").Value.ToString.Trim
                month = cboSrchYear.Text & Format(Val(cboSrchMonth.Text), "00")
                If Me.rbSrchFut.Checked Then
                    type = cls.comm_type_Fut
                ElseIf Me.rbSrchSec.Checked Then
                    type = cls.comm_type_Sec
                End If
                If Me.txtSrchAcc.Text.Trim.Length > 0 Then
                    Acc = Me.txtSrchAcc.Text.Trim
                End If

                Me.dtgAccDetail.DataSource = cls.LoadACCByMonth(month, type, ae, Acc)
                Me.dtgAccDetail.DataMember = "acc"
                Me.dtgAccDetail_SelectionChanged(Nothing, System.EventArgs.Empty)
            Else
                LoadFlag = True
                While Me.dtgAccDetail.Rows.Count > 0
                    Me.dtgAccDetail.Rows.RemoveAt(0)
                End While
                LoadFlag = False
            End If
        End If
    End Sub


    Private Sub dtgAccDetail_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgAccDetail.SelectionChanged
        If LoadFlag = False Then
            If Me.dtgAccDetail.Rows.Count > 0 Then
                Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(Me.dtgAccDetail.CurrentRow.Cells("acc_no").Value)
                If Me.cboAccNo.SelectedIndex > 0 Then
                    Me.cboAccNo.Text = Me.cboAccNo.Items(Me.cboAccNo.SelectedIndex)
                End If
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dtgAE.CurrentRow.Cells("ae_no").Value)
                Me.txtAEName.Text = Me.dtgAE.CurrentRow.Cells("ae_name").Value
                Me.txtMonth.Text = cboSrchYear.Text & Format(Val(cboSrchMonth.Text), "00")
                Me.txtAccName.Text = Me.dtgAccDetail.CurrentRow.Cells("acc_name").Value
                Me.CheckDefault.Checked = Me.dtgAccDetail.CurrentRow.Cells("standard").Value
                If Me.dtgAccDetail.CurrentRow.Cells("Standard").Value Then
                    Me.txtMinNorAmt.Text = "0.0"
                    Me.txtMinIntAmt.Text = "0.0"
                    Me.txtMinNorRate.Text = "0.0"
                    Me.txtMinIntRate.Text = "0.0"
                Else
                    Me.txtMinNorAmt.Text = Me.dtgAccDetail.CurrentRow.Cells("minNorAmt").Value
                    Me.txtMinIntAmt.Text = Me.dtgAccDetail.CurrentRow.Cells("minIntAmt").Value
                    Me.txtMinNorRate.Text = Me.dtgAccDetail.CurrentRow.Cells("minNorRate").Value
                    Me.txtMinIntRate.Text = Me.dtgAccDetail.CurrentRow.Cells("minIntRate").Value
                End If

                'If Me.dtgAccDetail.CurrentRow.Cells("isConsolid").Value = True Then
                '    Me.rbConsolid.Checked = True
                'Else
                '    Me.rbNonConsolid.Checked = True
                'End If
                Me.CBNI.Checked = Me.dtgAccDetail.CurrentRow.Cells("isConsolid").Value
                If IsDBNull(Me.dtgAccDetail.CurrentRow.Cells("isbothfo").Value) Then
                    Me.CBFO.Checked = False
                Else
                    Me.CBFO.Checked = Me.dtgAccDetail.CurrentRow.Cells("isbothfo").Value
                End If
            Else
                EmptyField()
            End If
        End If
    End Sub

    Private Sub EmptyField()
        Me.cboAccNo.SelectedIndex = -1
        Me.txtAccName.Text = ""
        Me.cboAENo.SelectedIndex = -1
        Me.txtAEName.Text = ""
        Me.txtMonth.Text = ""
        Me.txtAccName.Text = ""
        Me.txtMinNorAmt.Text = "0.00"
        Me.txtMinIntAmt.Text = "0.00"
        Me.txtMinNorRate.Text = "0.0000"
        Me.txtMinIntRate.Text = "0.0000"
        Me.CBNI.Checked = True
        Me.CBFO.Checked = True
        Me.cbBatchAll.Checked = False
        Me.CheckDefault.Checked = False
    End Sub

    Private Sub ObjEnable(ByVal blnflag As Boolean)

        If useraction = "New" Then
            GroupBoxAcc.Enabled = True
            Me.cboAccNo.Enabled = blnflag
            Me.cboAENo.Enabled = blnflag
            Me.dtgDetatil_B.Visible = False
            Me.dtgAccDetail.Visible = True
            GroupBoxDetail.Enabled = True
            Me.cbBatchAll.Enabled = False
        ElseIf useraction = "Edit" Then
            GroupBoxAcc.Enabled = True
            Me.cboAccNo.Enabled = Not blnflag
            Me.cboAENo.Enabled = Not blnflag
            Me.dtgDetatil_B.Visible = False
            Me.dtgAccDetail.Visible = True
            GroupBoxDetail.Enabled = True
            Me.cbBatchAll.Enabled = False
        ElseIf useraction = "NewBatch" Then
            GroupBoxAcc.Enabled = True
            Me.cboAENo.Enabled = True
            Me.dtgDetatil_B.Visible = True
            Me.dtgAccDetail.Visible = False
            Me.dtgDetatil_B.Enabled = True
            GroupBoxDetail.Enabled = True
            Me.cbBatchAll.Enabled = True
        ElseIf useraction = "EditBatch" Then
            GroupBoxAcc.Enabled = False
            Me.dtgDetatil_B.Visible = True
            Me.dtgAccDetail.Visible = False
            Me.dtgDetatil_B.Enabled = True
            GroupBoxDetail.Enabled = True
            Me.cbBatchAll.Enabled = True
        ElseIf useraction = "DeleteBatch" Then
            GroupBoxDetail.Enabled = False
            GroupBoxAcc.Enabled = False
            Me.dtgDetatil_B.Visible = True
            Me.dtgAccDetail.Visible = False
            Me.dtgDetatil_B.Enabled = True
            Me.cbBatchAll.Enabled = True
        Else
            Me.cbBatchAll.Enabled = False
            GroupBoxDetail.Enabled = False
            GroupBoxAcc.Enabled = False
            Me.cboAccNo.Enabled = False
            Me.cboAENo.Enabled = False
            Me.dtgDetatil_B.Visible = False
            Me.dtgAccDetail.Visible = True
        End If
        Me.txtAccName.Enabled = False
        Me.rbSingle.Enabled = Not blnflag
        Me.rbBatch.Enabled = Not blnflag
        Me.CBNI.Enabled = blnflag
        Me.CBFO.Enabled = blnflag

        Me.txtMonth.Enabled = False
        Me.txtMinNorAmt.Enabled = blnflag
        Me.txtMinIntAmt.Enabled = blnflag
        Me.txtMinNorRate.Enabled = blnflag
        Me.txtMinIntRate.Enabled = blnflag
        Me.CBNI.Enabled = blnflag
        Me.CBFO.Enabled = blnflag

        Me.dtgAccDetail.Enabled = Not blnflag
        Me.dtgAE.Enabled = Not blnflag

        Me.rbSrchSec.Enabled = Not blnflag
        Me.rbSrchFut.Enabled = Not blnflag
        Me.cboSrchYear.Enabled = False
        Me.cboSrchMonth.Enabled = False
        Me.txtSrchAcc.Enabled = Not blnflag
        Me.txtSrcAE.Enabled = Not blnflag

        Me.btnNew.Enabled = Not blnflag
        Me.btnEdit.Enabled = Not blnflag
        Me.btnDelete.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        Me.btnSearch.Enabled = Not blnflag
        Me.btnBatchNew.Enabled = Not blnflag
        Me.btnBatchEdit.Enabled = Not blnflag
        Me.btnBatchDelete.Enabled = Not blnflag

        If Me.rbSrchFut.Checked Then
            Me.Label8.Visible = False
            Me.Label9.Visible = False
            Me.Label10.Visible = False
            Me.Label11.Visible = False
            Me.Label13.Visible = False
            Me.Label12.Visible = False
            Me.txtMinIntAmt.Visible = False
            Me.txtMinNorAmt.Visible = False
            Me.txtMinIntRate.Visible = False
            Me.txtMinNorRate.Visible = False
            Me.CheckDefault.Visible = False
            Me.CBFO.Visible = True
            Me.GroupBoxAcc.Text = "Futures and Options Account"
        Else
            Me.Label8.Visible = True
            Me.Label9.Visible = True
            Me.Label10.Visible = True
            Me.Label11.Visible = True
            Me.Label13.Visible = True
            Me.Label12.Visible = True
            Me.txtMinIntAmt.Visible = True
            Me.txtMinNorAmt.Visible = True
            Me.txtMinIntRate.Visible = True
            Me.txtMinNorRate.Visible = True
            Me.CheckDefault.Visible = True
            Me.CBFO.Visible = False
            Me.CBFO.Checked = False
            Me.GroupBoxAcc.Text = "Securities Account"
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If Me.LoadFlag = False Then
            EmptyField()
            Me.txtMonth.Text = cboSrchYear.Text & Format(Val(cboSrchMonth.Text), "00")
            'If Me.rbSingle.Checked Then
            useraction = "New"
            If Me.dtgAccDetail.Rows.Count > 0 Then
                Me.cboAccNo.SelectedIndex = Me.cboAccNo.FindString(Me.dtgAccDetail.CurrentRow.Cells("acc_no").Value)
                Me.cboAccNo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            End If
            Me.cboAccNo.Focus()
            ObjEnable(True)
            'ElseIf Me.rbBatch.Checked Then
            '    useraction = "NewBatch"
            '    Me.cbBatchAll.Checked = False
            '    If Me.dtgAE.Rows.Count > 0 Then
            '        Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dtgAE.CurrentRow.Cells("ae_no").Value)
            '        Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            '    Else
            '        Me.cboAENo.Text = ""
            '    End If
            '    'LoadBatchAdd()
            '    'Me.dtgDetatil_B.Focus()
            '    Me.cboAENo.Focus()
            '    ObjEnable(True)
            '    Me.CheckDefault.Checked = True
            'End If
        End If
    End Sub

    Private Function lfncChkSelected() As Boolean
        For row As Integer = 0 To Me.dtgDetatil_B.RowCount - 1
            If Me.dtgDetatil_B.Rows(row).Cells("update_b").Value Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim MyTrans As SqlTransaction = Nothing
        If useraction = "New" Or useraction = "Edit" Then
            If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No) Then
                Return
            End If
            Dim comm_month As String = ""
            Dim acc_no As String = ""
            Dim ae_no As String = ""
            Dim acName As String = ""
            Dim consolidateNI As Int16 = 0
            Dim consolidateFO As Int16 = 0
            Dim NorAmt As Double = 0
            Dim NorRate As Double = 0
            Dim IntAmt As Double = 0
            Dim IntRate As Double = 0
            Dim type As String = ""
            Dim isDefault As Boolean = False
            comm_month = Me.txtMonth.Text
            acc_no = Me.cboAccNo.Text
            ae_no = Me.cboAENo.Text
            acName = Me.txtAccName.Text.Trim
            NorAmt = Me.txtMinNorAmt.Text
            NorRate = Me.txtMinNorRate.Text
            IntAmt = Me.txtMinIntAmt.Text
            IntRate = Me.txtMinIntRate.Text
            isDefault = Me.CheckDefault.Checked
            If Me.CBNI.Checked Then
                consolidateNI = 1
            Else
                consolidateNI = 0
            End If
            If Me.CBFO.Checked Then
                consolidateFO = 1
            Else
                consolidateFO = 0
            End If
            If Me.rbSrchFut.Checked Then
                type = cls.comm_type_Fut
            ElseIf Me.rbSrchSec.Checked Then
                type = cls.comm_type_Sec
            End If
            If CheckFieldEmpty() Then
                Return
            End If
            If ValidACC(acc_no) = False Then
                GSubShowInfo(GFncGetSysMsg(5))
                Me.cboAccNo.Focus()
                Return
            End If
            If ValidAE(ae_no) = False Then
                GSubShowInfo(GFncGetSysMsg(31))
                Me.cboAENo.Focus()
                Return
            End If

            If (Val(NorRate) > 100) Then
                GSubShowInfo(GFncGetSysMsg(64))
                Me.txtMinNorRate.Focus()
                Return
            End If
            If (Val(IntRate) > 100) Then
                GSubShowInfo(GFncGetSysMsg(64))
                Me.txtMinIntRate.Focus()
                Return
            End If
            'check overlap
            If (cls.lFncCheckOverlap(comm_month, type, ae_no, acc_no, useraction)) And useraction <> "Edit" Then
                GSubShowInfo(GFncGetSysMsg(62))
                Me.cboAccNo.Focus()
                Return
            End If
            If GFncCheckCommStatus() Then
                Return
            End If
            Try
                MyTrans = GSCnSqlConn.BeginTransaction
                If (useraction = "New") Then
                    cls.lFncInsertACC(comm_month, type, ae_no, acc_no, consolidateNI, consolidateFO, NorAmt, NorRate, IntAmt, IntRate, isDefault, MyTrans)
                ElseIf (useraction = "Edit") Then
                    cls.lFncEditACC(comm_month, type, ae_no, acc_no, consolidateNI, consolidateFO, NorAmt, NorRate, IntAmt, IntRate, isDefault, MyTrans)
                End If
                cls.lFncInsertName(acc_no, acName, MyTrans)
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
            LoadAEDT()
            Dim i As Integer = 0
            For i = 0 To Me.dtgAE.Rows.Count - 1
                If (Me.dtgAE.Rows(i).Cells("ae_no").Value = ae_no) Then
                    Me.dtgAE.FirstDisplayedScrollingRowIndex = i
                    Me.dtgAE.Rows(i).Cells("ae_no").Selected = True
                    Exit For
                End If
            Next
            Me.dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
            For i = 0 To Me.dtgAE.Rows.Count - 1
                If (Me.dtgAccDetail.Rows(i).Cells("acc_no").Value = acc_no) Then
                    Me.dtgAccDetail.FirstDisplayedScrollingRowIndex = i
                    Me.dtgAccDetail.Rows(i).Cells("acc_no").Selected = True
                    Exit For
                End If
            Next
            'Me.dtgAccDetail_SelectionChanged(Nothing, System.EventArgs.Empty)
        ElseIf useraction = "NewBatch" Or useraction = "EditBatch" Or useraction = "DeleteBatch" Then
            If Not lfncChkSelected() Then
                GSubShowInfo(GFncGetSysMsg(80))
                Return
            End If
            If useraction = "DeleteBatch" Then
                If (GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes) Then
                    Return
                End If
            Else
                If (GSubShowYNConfirm(GFncGetSysMsg(10), MessageBoxDefaultButton.Button2) <> Windows.Forms.DialogResult.Yes) Then
                    Return
                End If
            End If

            Dim comm_month As String = ""
            Dim acc_no As String = ""
            Dim ae_no As String = ""
            Dim consolidateNI As Int16 = 0
            Dim consolidateFO As Int16 = 0
            Dim NorAmt As Double = 0
            Dim NorRate As Double = 0
            Dim IntAmt As Double = 0
            Dim IntRate As Double = 0
            Dim type As String = ""
            Dim isDefault As Boolean = False
            Dim ExistAcc As DataTable
            ae_no = Me.cboAENo.Text.Trim
            comm_month = Me.txtMonth.Text
            NorAmt = Me.txtMinNorAmt.Text
            NorRate = Me.txtMinNorRate.Text
            IntAmt = Me.txtMinIntAmt.Text
            IntRate = Me.txtMinIntRate.Text
            isDefault = Me.CheckDefault.Checked
            If Me.CBNI.Checked Then
                consolidateNI = 1
            Else
                consolidateNI = 0
            End If
            If Me.CBFO.Checked Then
                consolidateFO = 1
            Else
                consolidateFO = 0
            End If
            If ValidAE(ae_no) = False Then
                GSubShowInfo(GFncGetSysMsg(31))
                Me.cboAENo.Focus()
                Return
            End If

            If Me.rbSrchFut.Checked Then
                type = cls.comm_type_Fut
            ElseIf Me.rbSrchSec.Checked Then
                type = cls.comm_type_Sec
            End If
            If CheckFieldEmpty() Then
                Return
            End If
            If (Val(NorRate) > 100) Then
                GSubShowInfo(GFncGetSysMsg(64))
                Me.txtMinNorRate.Focus()
                Return
            End If
            If (Val(IntRate) > 100) Then
                GSubShowInfo(GFncGetSysMsg(64))
                Me.txtMinIntRate.Focus()
                Return
            End If
            'check overlap
            Dim AccRowCount As Integer = 0
            If GFncCheckCommStatus() Then
                Return
            End If
            Try
                MyTrans = GSCnSqlConn.BeginTransaction
                ExistAcc = cls.lFncExistAcc(comm_month, type, ae_no, MyTrans)
                For row As Integer = 0 To Me.dtgDetatil_B.RowCount - 1
                    If Me.dtgDetatil_B.Rows(row).Cells("Update_B").Value = True Then
                        acc_no = Me.dtgDetatil_B.Rows(row).Cells("acc_no_B").Value
                        AccRowCount = ExistAcc.Select("acc_no ='" & acc_no & "'").Length
                        If (useraction = "NewBatch") Then
                            If AccRowCount = 0 Then
                                cls.lFncInsertACC(comm_month, type, ae_no, acc_no, consolidateNI, consolidateFO, NorAmt, NorRate, IntAmt, IntRate, isDefault, MyTrans)
                            Else
                                If GSCnSqlConn.State <> ConnectionState.Closed Then
                                    If (MyTrans IsNot Nothing) Then
                                        MyTrans.Rollback()
                                    End If
                                    GSubShowInfo(GFncGetSysMsg(70))
                                    LoadAEDT()
                                    Return
                                End If
                            End If
                        ElseIf (useraction = "EditBatch") Then
                            If AccRowCount > 0 Then
                                cls.lFncEditACC(comm_month, type, ae_no, acc_no, consolidateNI, consolidateFO, NorAmt, NorRate, IntAmt, IntRate, isDefault, MyTrans)
                            Else
                                If GSCnSqlConn.State <> ConnectionState.Closed Then
                                    If (MyTrans IsNot Nothing) Then
                                        MyTrans.Rollback()
                                    End If
                                    GSubShowInfo(GFncGetSysMsg(70))
                                    LoadAEDT()
                                    Return
                                End If
                            End If
                        ElseIf (useraction = "DeleteBatch") Then
                            If AccRowCount > 0 Then
                                cls.lFncDeleteAcc(acc_no, ae_no, type, comm_month, MyTrans)
                            Else
                                If GSCnSqlConn.State <> ConnectionState.Closed Then
                                    If (MyTrans IsNot Nothing) Then
                                        MyTrans.Rollback()
                                    End If
                                    GSubShowInfo(GFncGetSysMsg(70))
                                    LoadAEDT()
                                    Return
                                End If
                            End If
                        End If
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
            LoadAEDT()
            Dim i As Integer = 0
            For i = 0 To Me.dtgAE.Rows.Count - 1
                If (Me.dtgAE.Rows(i).Cells("ae_no").Value = ae_no) Then
                    Me.dtgAE.FirstDisplayedScrollingRowIndex = i
                    Me.dtgAE.Rows(i).Cells("ae_no").Selected = True
                    Exit For
                End If
            Next
            Me.dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
        End If
        'Me.dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
        useraction = ""
        ObjEnable(False)
        GSubShowInfo(GFncGetSysMsg(8))
    End Sub


    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.LoadFlag = False Then
            If Me.dtgAccDetail.SelectedRows.Count <= 0 Then
                Return
            End If
            '   If Me.rbSingle.Checked Then
            useraction = "Edit"
            'ElseIf Me.rbBatch.Checked Then
            '    useraction = "EditBatch"
            '    Me.cboAccNo.Text = ""
            '    Me.txtAccName.Text = ""
            '    Me.cbBatchAll.Checked = False
            '    If Me.dtgAE.Rows.Count > 0 Then
            '        Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dtgAE.CurrentRow.Cells("ae_no").Value)
            '        Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            '    End If
            '    LoadBatchEdit()

            'End If
            ObjEnable(True)
            If Me.CheckDefault.Checked Then
                Me.txtMinIntAmt.Enabled = False
                Me.txtMinNorRate.Enabled = False
                Me.txtMinNorAmt.Enabled = False
                Me.txtMinIntRate.Enabled = False
            End If

        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        'If Me.rbSingle.Checked Then
        If Me.LoadFlag = False And Me.dtgAccDetail.Rows.Count <= 0 Then
            Return
        End If
        Dim MyTrans As SqlTransaction = Nothing
        Dim acc_no As String = ""
        Dim ae_no As String = ""
        Dim type As String = ""
        Dim comm_month As String = ""
        comm_month = Me.txtMonth.Text
        acc_no = Me.cboAccNo.Text
        ae_no = Me.cboAENo.Text
        If Me.rbSrchFut.Checked Then
            type = cls.comm_type_Fut
        ElseIf Me.rbSrchSec.Checked Then
            type = cls.comm_type_Sec
        End If
        If (GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes) Then
            If GFncCheckCommStatus() Then
                Return
            End If
            Try
                MyTrans = GSCnSqlConn.BeginTransaction
                cls.lFncDeleteAcc(acc_no, ae_no, type, comm_month, MyTrans)
                MyTrans.Commit()
                MyTrans = Nothing
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
        LoadAEDT()
        Dim i As Integer = 0
        For i = 0 To Me.dtgAE.Rows.Count - 1
            If (Me.dtgAE.Rows(i).Cells("ae_no").Value = ae_no) Then
                Me.dtgAE.FirstDisplayedScrollingRowIndex = i
                Me.dtgAE.Rows(i).Cells("ae_no").Selected = True
                Exit For
            End If
        Next
        Me.dtgAE_SelectionChanged(Nothing, System.EventArgs.Empty)
        'ElseIf Me.rbBatch.Checked Then
        '    useraction = "DeleteBatch"
        '    Me.cboAccNo.Text = ""
        '    Me.txtAccName.Text = ""
        '    Me.cbBatchAll.Checked = False
        '    If Me.dtgAE.Rows.Count > 0 Then
        '        Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dtgAE.CurrentRow.Cells("ae_no").Value)
        '        Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        '    End If
        '    LoadBatchEdit()
        '    ObjEnable(True)
        'End If
    End Sub

    Private Sub cboAccNo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAccNo.SelectedIndexChanged, cboAccNo.LostFocus
        If LoadFlag = False And useraction = "New" Then
            Dim AE() As DataRow
            If Me.cboAccNo.Text.Trim.Length > 0 Then
                AE = AccMaster.Select("acc_no ='" & Me.cboAccNo.Text & "' ")
                If AE.Length > 0 Then
                    If Me.rbSrchSec.Checked Then
                        Me.txtAccName.Text = AE(0).Item("acc_name_s")
                        Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(AE(0).Item("ae_no_s"))
                    Else
                        Me.txtAccName.Text = AE(0).Item("acc_name_f")
                        Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(AE(0).Item("ae_no_f"))
                    End If
                Else
                    Me.cboAENo.SelectedIndex = -1
                    Me.txtAccName.Text = ""
                End If
            Else
                Me.txtAccName.Text = ""
                Me.cboAENo.SelectedIndex = -1
            End If
            cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub cboAENo_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboAENo.SelectedIndexChanged, cboAENo.LostFocus
        If LoadFlag = False Then
            If useraction = "New" Or useraction = "NewBatch" Then
                Dim AE() As DataRow
                If Me.cboAENo.Text.Trim.Length > 0 Then
                    AE = AeMaster.Select("ae_no ='" & Me.cboAENo.Text & "' ")
                    If AE.Length > 0 Then
                        If Me.rbSrchSec.Checked Then
                            Me.txtAEName.Text = AE(0).Item("ae_name_s")
                        Else
                            Me.txtAEName.Text = AE(0).Item("ae_name_f")
                        End If
                    Else
                        Me.txtAEName.Text = ""
                    End If
                Else
                    Me.txtAEName.Text = ""
                End If
                If useraction = "NewBatch" Then
                    LoadBatchAdd()
                End If
            End If
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        If LoadFlag = False Then
            Me.LoadAEDT()
        End If
    End Sub
    Private Sub LoadBatchEdit()
        Dim tx_month As String = ""
        Dim type As String = ""
        Dim ae As String = ""
        tx_month = Me.txtMonth.Text
        If Me.rbSrchFut.Checked Then
            type = cls.comm_type_Fut
        ElseIf Me.rbSrchSec.Checked Then
            type = cls.comm_type_Sec
        End If
        If Me.dtgAE.RowCount > 0 Then
            ae = Me.dtgAE.CurrentRow.Cells("ae_no").Value.ToString.Trim
        End If
        Me.dtgDetatil_B.DataSource = cls.BatchEdit(tx_month, type, ae).Tables("BatchEdit")
        SetBatchGrid()
    End Sub

    Private Sub LoadBatchAdd()
        Dim tx_month As String = ""
        Dim type As String = ""
        Dim ae As String = ""
        tx_month = Me.txtMonth.Text
        If Me.rbSrchFut.Checked Then
            type = cls.comm_type_Fut
        ElseIf Me.rbSrchSec.Checked Then
            type = cls.comm_type_Sec
        End If
        If Me.cboAENo.Text.Trim.Length > 0 Then
            ae = Me.cboAENo.Text.Trim
        End If
        Me.dtgDetatil_B.DataSource = cls.BatchAdd(tx_month, type, ae).Tables("BatchAdd")
        SetBatchGrid()

    End Sub

    Private Sub SetBatchGrid()
        If Me.dtgDetatil_B.Rows.Count > 0 Then
            For row As Integer = 0 To dtgDetatil_B.Rows.Count - 1
                For col As Integer = 0 To dtgDetatil_B.ColumnCount - 1
                    If col = Me.dtgDetatil_B.Rows(row).Cells("Update_B").ColumnIndex Then
                        Me.dtgDetatil_B.Rows(row).Cells(col).ReadOnly = False
                        Me.dtgDetatil_B.Rows(row).Cells(col).Style.BackColor = Color.White
                    Else
                        Me.dtgDetatil_B.Rows(row).Cells(col).ReadOnly = True
                        Me.dtgDetatil_B.Rows(row).Cells(col).Style.BackColor = Color.Linen
                    End If
                Next
            Next
        End If
    End Sub

    'Private Sub dtgDetatil_B_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgDetatil_B.LostFocus
    '    If LoadFlag = False And useraction <> "" And Me.cbBatchAll.Checked = True Then
    '        If Me.dtgDetatil_B.Rows.Count > 0 Then
    '            For row As Integer = 0 To dtgDetatil_B.Rows.Count - 1
    '                If Me.dtgDetatil_B.Rows(row).Cells("Update_B").Value = False Then
    '                    Me.cbBatchAll.Checked = False
    '                    Exit For
    '                End If
    '            Next
    '        End If
    '    End If

    'End Sub


    Private Sub dtgDetatil_B_Sorted(ByVal sender As Object, ByVal e As System.EventArgs) Handles dtgDetatil_B.Sorted
        SetBatchGrid()
    End Sub

    Private Sub cbBatchAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbBatchAll.CheckedChanged
        If LoadFlag = False And (useraction = "NewBatch" Or useraction = "EditBatch" Or useraction = "DeleteBatch") Then
            If Me.cbBatchAll.Checked = True And Me.dtgDetatil_B.Rows.Count > 0 Then
                For row As Integer = 0 To dtgDetatil_B.Rows.Count - 1
                    Me.dtgDetatil_B.Rows(row).Cells("Update_B").Value = True
                Next
            ElseIf Me.cbBatchAll.Checked = False And Me.dtgDetatil_B.Rows.Count > 0 Then
                For row As Integer = 0 To dtgDetatil_B.Rows.Count - 1
                    Me.dtgDetatil_B.Rows(row).Cells("Update_B").Value = False
                Next
            End If
        End If
    End Sub

    Private Function ValidAE(ByVal AE As String) As Boolean
        If AE.Length > 0 Then
            If AeMaster.Select("ae_no='" & AE & "'").Length > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function
    Private Function ValidACC(ByVal ACC As String) As Boolean
        If ACC.Length > 0 Then
            If AccMaster.Select("acc_no='" & ACC & "'").Length > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Private Function CheckFieldEmpty() As Boolean
        Dim errormsg As String = ""
        If Me.txtMinIntRate.Text.Trim.Length <= 0 Then
            errormsg = "Min. Internet Rate,"
            Me.txtMinIntRate.Focus()
        ElseIf Me.txtMinNorRate.Text.Trim.Length <= 0 Then
            errormsg = "Min. Normal Rate,"
            Me.txtMinNorRate.Focus()
        ElseIf Me.txtMinIntAmt.Text.Trim.Length <= 0 Then
            errormsg = "Min. Internet Amt,"
            Me.txtMinIntAmt.Focus()
        ElseIf Me.txtMinNorAmt.Text.Trim.Length <= 0 Then
            errormsg = "Min. Normal Amt,"
            Me.txtMinNorAmt.Focus()
        End If
        If errormsg.Length > 1 Then
            GSubShowInfo(errormsg.Substring(0, errormsg.Length - 2) & GFncGetSysMsg(49))
            Return True
        Else
            Return False
        End If
    End Function

    Private Sub CheckDefault_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckDefault.CheckedChanged
        If useraction = "New" Or useraction = "NewBatch" _
            Or useraction = "Edit" Or useraction = "EditBatch" Then
            Me.txtMinIntAmt.Enabled = Not Me.CheckDefault.Checked
            Me.txtMinIntRate.Enabled = Not Me.CheckDefault.Checked
            Me.txtMinNorAmt.Enabled = Not Me.CheckDefault.Checked
            Me.txtMinNorRate.Enabled = Not Me.CheckDefault.Checked

            If Me.CheckDefault.Checked Then
                Me.txtMinNorAmt.Text = "0.0"
                Me.txtMinIntAmt.Text = "0.0"
                Me.txtMinNorRate.Text = "0.0"
                Me.txtMinIntRate.Text = "0.0"
            End If
        End If

    End Sub

    Private Sub btnBatchNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchNew.Click
        If Me.LoadFlag = False Then
            EmptyField()
            Me.txtMonth.Text = cboSrchYear.Text & Format(Val(cboSrchMonth.Text), "00")
            useraction = "NewBatch"
            Me.cbBatchAll.Checked = False
            If Me.dtgAE.Rows.Count > 0 Then
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dtgAE.CurrentRow.Cells("ae_no").Value)
                Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            Else
                Me.cboAENo.Text = ""
            End If
            'LoadBatchAdd()
            'Me.dtgDetatil_B.Focus()
            Me.cboAENo.Focus()
            ObjEnable(True)
            Me.CheckDefault.Checked = True
        End If
    End Sub

    Private Sub btnBatchEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchEdit.Click
        If Me.LoadFlag = False Then
            If Me.dtgAE.SelectedRows.Count <= 0 Then
                Return
            End If
            useraction = "EditBatch"
            Me.cboAccNo.Text = ""
            Me.txtAccName.Text = ""
            Me.cbBatchAll.Checked = False
            If Me.dtgAE.Rows.Count > 0 Then
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dtgAE.CurrentRow.Cells("ae_no").Value)
                Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            End If
            LoadBatchEdit()

            ObjEnable(True)
            If Me.CheckDefault.Checked Then
                Me.txtMinIntAmt.Enabled = False
                Me.txtMinNorRate.Enabled = False
                Me.txtMinNorAmt.Enabled = False
                Me.txtMinIntRate.Enabled = False
            End If
        End If
    End Sub

    Private Sub btnBatchDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatchDelete.Click
        If Me.LoadFlag = False Then
            useraction = "DeleteBatch"
            Me.cboAccNo.Text = ""
            Me.txtAccName.Text = ""
            Me.cbBatchAll.Checked = False
            If Me.dtgAE.Rows.Count > 0 Then
                Me.cboAENo.SelectedIndex = Me.cboAENo.FindString(Me.dtgAE.CurrentRow.Cells("ae_no").Value)
                Me.cboAENo_SelectedIndexChanged(Nothing, System.EventArgs.Empty)
            End If
            LoadBatchEdit()
            ObjEnable(True)
        End If
    End Sub
End Class
