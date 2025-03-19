Imports System.IO

Public Class FrmHSBCAutopay
    Dim cls As New ClsAutopay
    Dim ldtRecord As DataTable = Nothing
    Dim act As String = ""
    Dim prevFirstPartyAC As String = ""
    Dim prevPaymentCode As String = ""
    Dim prevFirstPartyRef As String = ""
    Dim prevVDate As Date = Now
    Dim prevDT As DataTable = Nothing
    Dim dtTDate As DataTable = Nothing
    Dim cutTime As String = "15:00:00"
    Dim dtFundOutEmptyS As DataTable = Nothing
    Dim dtFundOutEmptyF As DataTable = Nothing
    Dim prevCutTime As String = ""
    Dim prevCommAccS As String = ""
    Dim prevPayCodeS As String = ""
    Dim prevCommAccF As String = ""
    Dim prevPayCodeF As String = ""

    Private Sub dgvRecord_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRecord.SelectionChanged
        assignRecord(False)
    End Sub

    Private Sub hFieldEnable(ByVal flag As Boolean)
        Me.cboFirstPartyAC.Enabled = flag
        Me.txtPaymentCode.Enabled = flag
        Me.txtFirstPartyRef.Enabled = flag
        Me.dpVDate.Enabled = flag
    End Sub

    Private Sub rFieldEnable(ByVal flag As Boolean)
        Me.txtClientID.Enabled = flag
        Me.txtClientBankName.Enabled = flag
        Me.txtClientBankNo.Enabled = flag
        Me.txtClientBankBrh.Enabled = flag
        Me.txtClientAC.Enabled = flag
        Me.txtAmt.Enabled = flag
        Me.txtClientIDCon.Enabled = flag
        Me.txtClientRef.Enabled = flag
    End Sub

    Private Sub btnEnable(ByVal flag As Boolean)
        Me.dgvRecord.Enabled = flag
        Me.btnEditH.Enabled = flag
        Me.btnAdd.Enabled = flag
        Me.btnEdit.Enabled = flag
        Me.btnDelete.Enabled = flag
        Me.btnSave.Enabled = Not flag
        Me.btnExport.Enabled = flag
        Me.btnLoad.Enabled = flag
        If (Me.TabControl1.SelectedIndex = 0) Then
            Me.dpS.Enabled = flag
            Me.btnLoad_s.Enabled = flag
        End If
        If (Me.TabControl1.SelectedIndex = 1) Then
            Me.dpF.Enabled = flag
            Me.btnLoad_f.Enabled = flag
        End If
    End Sub

    Private Sub btnVisible(ByVal flag As Boolean)
        Me.btnLoad.Visible = flag
        Me.btnAdd.Visible = flag
        Me.btnEdit.Visible = flag
        Me.btnDelete.Visible = flag
        Me.btnSave.Visible = flag
        Me.btnExport.Visible = flag
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
        Application.DoEvents()
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ldtRecord = New DataTable
        cls.InitManagerDTF(ldtRecord)
        cls.loadArray()
        assignRecord(False)
        hFieldEnable(False)
        rFieldEnable(False)
        btnEnable(True)
        cutTime = cls.lFncGetCutTime()
        dtTDate = cls.lFncGetTDateS()
        dpS_ValueChanged(Nothing, System.EventArgs.Empty)
        dpF_ValueChanged(Nothing, System.EventArgs.Empty)
        lsubShowProcessing(False)
        dtFundOutEmptyS = cls.lFncGetFundOutS(Nothing, Nothing, True)
        dtFundOutEmptyF = cls.lFncGetFundOutF(Nothing, Nothing, True)
    End Sub

    Private Function rFieldValidation() As Boolean
        If (cls.checkAlphaNumeric(Me.txtClientID.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(46))
            Me.txtClientID.Focus()
            Return False
        End If
        If (cls.checkAlphaNumeric(Me.txtClientBankName.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(96))
            Me.txtClientBankName.Focus()
            Return False
        End If
        If (cls.checkNumeric(Me.txtClientBankNo.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(46))
            Me.txtClientBankNo.Focus()
            Return False
        End If
        If (cls.checkNumeric(Me.txtClientBankBrh.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(46))
            Me.txtClientBankBrh.Focus()
            Return False
        End If
        If (cls.checkNumeric(Me.txtClientAC.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(46))
            Me.txtClientAC.Focus()
            Return False
        End If
        If (cls.checkNumeric(Me.txtAmt.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(46))
            Me.txtAmt.Focus()
            Return False
        End If
        If (cls.checkAlphaNumeric(Me.txtClientRef.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(96))
            Me.txtClientRef.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function hFieldValidation() As Boolean
        If (cls.checkNumeric(Me.cboFirstPartyAC.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(46))
            Me.cboFirstPartyAC.Focus()
            Return False
        End If
        If (cls.checkAlphaNumeric(Me.txtPaymentCode.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(96))
            Me.txtPaymentCode.Focus()
            Return False
        End If
        If (cls.checkAlphaNumeric(Me.txtFirstPartyRef.Text) = False) Then
            GSubShowInfo(GFncGetSysMsg(96))
            Me.txtFirstPartyRef.Focus()
            Return False
        End If

        Return True
    End Function

    Private Sub assignRecord(ByVal isEmpty As Boolean)
        If (isEmpty) Then
            Me.txtClientID.Text = ""
            Me.txtClientBankName.Text = ""
            Me.txtClientBankNo.Text = ""
            Me.txtClientBankBrh.Text = ""
            Me.txtClientAC.Text = ""
            Me.txtAmt.Text = ""
            Me.txtClientIDCon.Text = ""
            Me.txtClientRef.Text = ""
        Else
            If (Me.dgvRecord.Rows.Count > 0) Then
                Me.txtClientID.Text = Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientID").Value
                Me.txtClientBankName.Text = Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientBankName").Value
                Me.txtClientBankNo.Text = Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientBankNo").Value
                Me.txtClientBankBrh.Text = Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientBankBrh").Value
                Me.txtClientAC.Text = Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientAC").Value
                Me.txtAmt.Text = Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("amt").Value
                Me.txtClientIDCon.Text = Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientIDCon").Value
                Me.txtClientRef.Text = Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientRef").Value
            End If
        End If
    End Sub

    Private Sub assignGridRecord()
        Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientID").Value = Me.txtClientID.Text
        Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientBankName").Value = Me.txtClientBankName.Text
        Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientBankNo").Value = Me.txtClientBankNo.Text
        Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientBankBrh").Value = Me.txtClientBankBrh.Text
        Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientAC").Value = Me.txtClientAC.Text
        Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("amt").Value = Me.txtAmt.Text
        Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientIDCon").Value = Me.txtClientIDCon.Text
        Me.dgvRecord.Rows(Me.dgvRecord.CurrentRow.Index).Cells("clientRef").Value = Me.txtClientRef.Text
    End Sub

    Private Sub lFncDTGSorting(ByVal Dtg As DataGridView, ByVal Col As String, ByVal Order As String)
        If Col.Length > 0 And Col <> Nothing Then
            If Order = "Ascending" Then
                Dtg.Sort(Dtg.Columns(Col), System.ComponentModel.ListSortDirection.Ascending)
            ElseIf Order = "Descending" Then
                Dtg.Sort(Dtg.Columns(Col), System.ComponentModel.ListSortDirection.Descending)
            End If
        End If
    End Sub

    Private Sub btnEditH_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditH.Click
        act = "EH"
        prevFirstPartyAC = Me.cboFirstPartyAC.Text
        prevPaymentCode = Me.txtPaymentCode.Text
        prevFirstPartyRef = Me.txtFirstPartyRef.Text
        prevVDate = Me.dpVDate.Value
        hFieldEnable(True)
        rFieldEnable(False)
        btnEnable(False)
        Me.btnEditH.Focus()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        act = "AR"
        If (Me.TabControl1.SelectedIndex = 2) Then
            assignRecord(True)
            hFieldEnable(False)
            rFieldEnable(True)
            btnEnable(False)
            Me.txtClientID.Focus()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If (Me.TabControl1.SelectedIndex = 2) Then
            If (Me.dgvRecord.Rows.Count > 0) Then
                act = "ER"
                hFieldEnable(False)
                rFieldEnable(True)
                btnEnable(False)
                Me.txtClientID.Focus()
            Else
                GSubShowInfo(GFncGetSysMsg(24))
            End If
        End If
        If (Me.TabControl1.SelectedIndex = 3) Then
            act = "ER"
            prevCutTime = Me.txtCutTime.Text
            prevCommAccS = Me.txtCommAccS.Text
            prevPayCodeS = Me.txtPayCodeS.text
            prevCommAccF = Me.txtCommAccF.Text
            prevPayCodeF = Me.txtPayCodeF.Text

            Me.txtCutTime.Enabled = True
            Me.txtCommAccS.Enabled = True
            Me.txtPayCodeS.Enabled = True
            Me.txtCommAccF.Enabled = True
            Me.txtPayCodeF.Enabled = True

            Me.btnEdit.Enabled = False
            Me.btnSave.Enabled = True
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (act = "") Then
            Me.Close()
        Else
            If (Me.TabControl1.SelectedIndex = 0) Then
                If (act = "ER") Then
                    Dim ldt As DataTable = prevDT.Copy
                    Me.dgvFundOutS.DataSource = ldt
                End If
                btnEnable(True)
            End If
            If (Me.TabControl1.SelectedIndex = 1) Then
                If (act = "ER") Then
                    Dim ldt As DataTable = prevDT.Copy
                    Me.dgvFundOutF.DataSource = ldt
                End If
                btnEnable(True)
            End If
            If (Me.TabControl1.SelectedIndex = 2) Then
                Me.cboFirstPartyAC.Text = prevFirstPartyAC
                Me.txtPaymentCode.Text = prevPaymentCode
                Me.txtFirstPartyRef.Text = prevFirstPartyRef
                Me.dpVDate.Value = prevVDate
                assignRecord(False)
                hFieldEnable(False)
                rFieldEnable(False)
                btnEnable(True)
            End If
            If (Me.TabControl1.SelectedIndex = 3) Then
                Me.txtCutTime.Text = prevCutTime
                Me.txtCommAccS.Text = prevCommAccS
                Me.txtPayCodeS.Text = prevPayCodeS
                Me.txtCommAccF.Text = prevCommAccF
                Me.txtPayCodeF.Text = prevPayCodeF
                Me.txtCutTime.Enabled = False
                Me.txtCommAccS.Enabled = False
                Me.txtPayCodeS.Enabled = False
                Me.txtCommAccF.Enabled = False
                Me.txtPayCodeF.Enabled = False
                Me.btnEdit.Enabled = True
                Me.btnSave.Enabled = False
            End If
            act = ""
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (Me.TabControl1.SelectedIndex = 2) Then
            If (Me.dgvRecord.Rows.Count > 0) Then
                If (MessageBox.Show(GFncGetSysMsg(11), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.No) Then
                    Return
                End If
                Me.dgvRecord.Rows.RemoveAt(Me.dgvRecord.CurrentRow.Index)
                If (Me.dgvRecord.Rows.Count > 0) Then
                    Me.dgvRecord.ClearSelection()
                    Me.dgvRecord.Rows(0).Cells(0).Selected = True
                    assignRecord(False)
                End If
            Else
                GSubShowInfo(GFncGetSysMsg(24))
            End If
        End If
    End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        If (Me.TabControl1.SelectedIndex = 2) Then
            Dim openFileDialog1 As New System.Windows.Forms.OpenFileDialog
            Dim strLine As String = ""
            Try
                openFileDialog1.Filter = "Text (*.txt) |*.txt"
                If (openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                    Me.cboFirstPartyAC.Items.Clear()
                    cls.GetDataFromFile(ldtRecord, openFileDialog1, Me.cboFirstPartyAC.Text, Me.txtPaymentCode.Text, _
                                        Me.txtFirstPartyRef.Text, Me.dpVDate.Value)
                    Me.dgvRecord.DataSource = ldtRecord
                End If
            Catch Ex As Exception
                MessageBox.Show(Ex.Message)
            End Try
        End If
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim GStrExptDir As String = ""
        Dim strExptFilename As String = ""
        Dim lstrFiles() As String
        Dim lsWriter As StreamWriter = Nothing
        Dim lstrColValue As String = ""
        Dim totalAmt As Decimal = 0
        Dim saveFileDialog1 As New System.Windows.Forms.SaveFileDialog

        For i As Integer = 0 To Me.dgvRecord.Rows.Count - 1
            If ((Me.dgvRecord.Rows(i).Cells("clientBankNo").Value.ToString.Trim = "") Or _
                (Me.dgvRecord.Rows(i).Cells("clientBankBrh").Value.ToString.Trim = "") Or _
                (Me.dgvRecord.Rows(i).Cells("clientAC").Value.ToString.Trim = "")) Then
                GSubShowInfo(GFncGetSysMsg(95))
                Me.dgvRecord.ClearSelection()
                Me.dgvRecord.Rows(i).Cells("clientBankNo").Selected = True
                Me.dgvRecord.FirstDisplayedScrollingRowIndex = i
                assignRecord(False)
                Return
            End If
        Next

        Try
            saveFileDialog1.Filter = "Text (*.txt) |*.txt"

            If (saveFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                GStrExptDir = saveFileDialog1.FileName.Substring(0, saveFileDialog1.FileName.LastIndexOf("\") + 1)
                strExptFilename = saveFileDialog1.FileName.Substring(saveFileDialog1.FileName.LastIndexOf("\") + 1, saveFileDialog1.FileName.Length - saveFileDialog1.FileName.LastIndexOf("\") - 1)

                lstrFiles = System.IO.Directory.GetFiles(GStrExptDir, strExptFilename)
                For Each lstrFile As String In lstrFiles
                    Application.DoEvents()
                    System.IO.File.Delete(lstrFile)
                Next

                lsWriter = New StreamWriter(GStrExptDir & strExptFilename, False, System.Text.Encoding.GetEncoding(950))

                For i As Integer = 0 To Me.dgvRecord.Rows.Count - 1
                    totalAmt = totalAmt + Me.dgvRecord.Rows(i).Cells("amt").Value
                Next

                lstrColValue = "F"
                lstrColValue = lstrColValue & Me.cboFirstPartyAC.Text.PadRight(cls.headerArray(cls.FirstPartyAccNo, cls.strSize), " ")
                lstrColValue = lstrColValue & Me.txtPaymentCode.Text.PadRight(cls.headerArray(cls.PaymentCode, cls.strSize), " ")
                lstrColValue = lstrColValue & Me.txtFirstPartyRef.Text.PadRight(cls.headerArray(cls.FirstPartyRef, cls.strSize), " ")
                lstrColValue = lstrColValue & Format(Me.dpVDate.Value, "ddMMyy")
                lstrColValue = lstrColValue & "K"
                lstrColValue = lstrColValue & "********"
                lstrColValue = lstrColValue & CStr(Me.dgvRecord.Rows.Count).PadLeft(cls.headerArray(cls.NoOfRec, cls.strSize), "0")
                lstrColValue = lstrColValue & CStr(CLng(totalAmt * 100)).PadLeft(cls.headerArray(cls.MonetaryTotal, cls.strSize), "0")
                lstrColValue = lstrColValue & "".PadRight(cls.headerArray(cls.OverflowCount, cls.strSize), " ")
                lstrColValue = lstrColValue & "".PadRight(cls.headerArray(cls.OverflowAmount, cls.strSize), " ")
                lstrColValue = lstrColValue & "".PadRight(cls.headerArray(cls.HFiller, cls.strSize), " ")
                lstrColValue = lstrColValue & "1"

                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()
                For i As Integer = 0 To Me.dgvRecord.Rows.Count - 1
                    lstrColValue = " "
                    lstrColValue = lstrColValue & Me.dgvRecord.Rows(i).Cells("clientID").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyID, cls.strSize), " ")
                    lstrColValue = lstrColValue & Me.dgvRecord.Rows(i).Cells("clientBankName").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyBankAcc, cls.strSize), " ")
                    lstrColValue = lstrColValue & Me.dgvRecord.Rows(i).Cells("clientBankNo").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyBankNo, cls.strSize), " ")
                    lstrColValue = lstrColValue & Me.dgvRecord.Rows(i).Cells("clientBankBrh").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyBranch, cls.strSize), " ")
                    lstrColValue = lstrColValue & Me.dgvRecord.Rows(i).Cells("clientAC").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyAcc, cls.strSize), " ")
                    lstrColValue = lstrColValue & CStr(CLng(Me.dgvRecord.Rows(i).Cells("amt").Value * 100)).PadLeft(10, "0")
                    lstrColValue = lstrColValue & "    "
                    lstrColValue = lstrColValue & Me.dgvRecord.Rows(i).Cells("clientIDCon").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyIDCon, cls.strSize), " ")
                    lstrColValue = lstrColValue & Me.dgvRecord.Rows(i).Cells("clientRef").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyReference, cls.strSize), " ")
                    lsWriter.WriteLine(lstrColValue)
                    lsWriter.Flush()
                Next
                lsWriter.Close()
                GSubShowInfo(GFncGetSysMsg(28))
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            lsWriter.Close()
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ((act <> "EH") And (act <> "AR") And (act <> "ER")) Then
            MessageBox.Show("Invalid action")
            Return
        End If

        If (MessageBox.Show(GFncGetSysMsg(10), "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
            If (Me.TabControl1.SelectedIndex = 2) Then
                If (act = "EH") Then
                    If (hFieldValidation()) = False Then
                        Return
                    End If
                End If
                If (act = "AR") Then
                    If (rFieldValidation()) = False Then
                        Return
                    End If
                    Dim Col As String = ""
                    Dim Sort As String = ""
                    If Me.dgvRecord.SortedColumn IsNot Nothing Then
                        Col = Me.dgvRecord.SortedColumn.Name
                        Sort = Me.dgvRecord.SortOrder.ToString()
                    End If

                    Dim ldrRecord As DataRow = ldtRecord.NewRow
                    ldrRecord("clientID") = Me.txtClientID.Text
                    ldrRecord("clientBankName") = Me.txtClientBankName.Text
                    ldrRecord("clientBankNo") = Me.txtClientBankNo.Text
                    ldrRecord("clientBankBrh") = Me.txtClientBankBrh.Text
                    ldrRecord("clientAC") = Me.txtClientAC.Text
                    ldrRecord("amt") = Me.txtAmt.Text
                    ldrRecord("clientIDCon") = Me.txtClientIDCon.Text
                    ldrRecord("clientRef") = Me.txtClientRef.Text
                    ldtRecord.Rows.Add(ldrRecord)
                    Me.dgvRecord.DataSource = ldtRecord
                    Me.dgvRecord.ClearSelection()
                    Me.dgvRecord.Rows(0).Selected = True
                    Me.dgvRecord.FirstDisplayedScrollingRowIndex = 0
                    lFncDTGSorting(dgvRecord, Col, Sort)
                End If
                If (act = "ER") Then
                    If (rFieldValidation()) = False Then
                        Return
                    End If
                    assignGridRecord()
                End If
                hFieldEnable(False)
                rFieldEnable(False)
                btnEnable(True)
                prevFirstPartyAC = Me.cboFirstPartyAC.Text
                prevPaymentCode = Me.txtPaymentCode.Text
                prevFirstPartyRef = Me.txtFirstPartyRef.Text
                prevVDate = Me.dpVDate.Value
                act = ""
            End If
            If (Me.TabControl1.SelectedIndex = 3) Then
                If (cls.lFncUpdateMisc(Me.txtCutTime.Text, Me.txtCommAccS.Text, Me.txtPayCodeS.Text, _
                                        Me.txtCommAccF.Text, Me.txtPayCodeF.Text)) Then
                    GSubShowInfo(GFncGetSysMsg(8))
                Else
                    GSubShowInfo(GFncGetSysMsg(9))
                End If
                Me.txtCutTime.Enabled = False
                Me.txtCommAccS.Enabled = False
                Me.txtPayCodeS.Enabled = False
                Me.txtCommAccF.Enabled = False
                Me.txtPayCodeF.Enabled = False
                Me.btnEdit.Enabled = True
                Me.btnSave.Enabled = False
                act = ""
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
        If (Me.TabControl1.SelectedIndex = 0) Then
            btnVisible(False)
        End If
        If (Me.TabControl1.SelectedIndex = 1) Then
            btnVisible(False)
        End If
        If (Me.TabControl1.SelectedIndex = 2) Then
            btnVisible(True)
        End If
        If (Me.TabControl1.SelectedIndex = 3) Then
            btnVisible(False)
            Me.btnEdit.Visible = True
            Me.btnSave.Visible = True
            Me.txtCutTime.Text = cls.lFncGetCutTime()
            Me.txtCommAccS.Text = cls.lFncGetCommAccS()
            Me.txtPayCodeS.Text = cls.lFncGetPayCodeS()
            Me.txtCommAccF.Text = cls.lFncGetCommAccF()
            Me.txtPayCodeF.Text = cls.lFncGetPayCodeF()
        End If
    End Sub

    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If (act <> "") Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnLoad_s_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad_s.Click
        lsubShowProcessing(True)
        Me.dgvFundOutS.DataSource = cls.lFncGetFundOutS(Me.txtDateFromS.Text & " " & Me.txtTimeFromS.Text, _
                                                        Me.txtDateToS.Text & " " & Me.txtTimeToS.Text, False)
        For i As Integer = 0 To Me.dgvFundOutS.Rows.Count - 1
            Me.dgvFundOutS.Rows(i).Cells("clt_check_s").ReadOnly = False
            Me.dgvFundOutS.Rows(i).Cells("tdate_s").ReadOnly = True
            Me.dgvFundOutS.Rows(i).Cells("clt_code_s").ReadOnly = True
            Me.dgvFundOutS.Rows(i).Cells("clt_name_s").ReadOnly = True
            Me.dgvFundOutS.Rows(i).Cells("bank_code_s").ReadOnly = True
            Me.dgvFundOutS.Rows(i).Cells("fund_out_amt_s").ReadOnly = True
            Me.dgvFundOutS.Rows(i).Cells("notes_s").ReadOnly = True
            Me.dgvFundOutS.Rows(i).Cells("is_chq_s").ReadOnly = True
        Next
        lsubShowProcessing(False)
    End Sub

    Private Sub btnLoad_f_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad_f.Click
        lsubShowProcessing(True)
        Me.dgvFundOutF.DataSource = cls.lFncGetFundOutF(Me.txtDateFromF.Text & " " & Me.txtTimeFromF.Text, _
                                                        Me.txtDateToF.Text & " " & Me.txtTimeToF.Text, False)
        For i As Integer = 0 To Me.dgvFundOutF.Rows.Count - 1
            Me.dgvFundOutF.Rows(i).Cells("clt_check_f").ReadOnly = False
            Me.dgvFundOutF.Rows(i).Cells("tdate_f").ReadOnly = True
            Me.dgvFundOutF.Rows(i).Cells("clt_code_f").ReadOnly = True
            Me.dgvFundOutF.Rows(i).Cells("clt_name_f").ReadOnly = True
            Me.dgvFundOutF.Rows(i).Cells("bank_code_f").ReadOnly = True
            Me.dgvFundOutF.Rows(i).Cells("fund_out_amt_f").ReadOnly = True
            Me.dgvFundOutF.Rows(i).Cells("notes_f").ReadOnly = True
            Me.dgvFundOutF.Rows(i).Cells("is_chq_f").ReadOnly = True
        Next
        lsubShowProcessing(False)
    End Sub

    Private Sub btnTransfer_s_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer_s.Click
        If (Me.dgvFundOutS.Rows.Count > 0) Then
            ldtRecord = New DataTable
            cls.InitManagerDTF(ldtRecord)
            For i As Integer = 0 To Me.dgvFundOutS.Rows.Count - 1
                If Not (IsDBNull(Me.dgvFundOutS.Rows(i).Cells("clt_check_s").Value)) Then
                    If (Me.dgvFundOutS.Rows(i).Cells("clt_check_s").Value = 1) Then
                        Dim ldrRecord As DataRow = ldtRecord.NewRow
                        Dim lstrBank As String = Replace(Me.dgvFundOutS.Rows(i).Cells("bank_code_s").Value, "-", "")
                        lstrBank = Replace(lstrBank, " ", "")
                        ldrRecord("clientID") = Me.dgvFundOutS.Rows(i).Cells("clt_code_s").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyID, cls.strSize)).Substring(0, cls.recordArray(cls.SecondPartyID, cls.strSize))
                        ldrRecord("clientBankName") = Me.dgvFundOutS.Rows(i).Cells("clt_name_s").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyBankAcc, cls.strSize)).Substring(0, cls.recordArray(cls.SecondPartyBankAcc, cls.strSize))
                        If lstrBank.Length <= 6 Then
                            ldrRecord("clientBankNo") = "XXX".PadRight(cls.recordArray(cls.SecondPartyBankNo, cls.strSize), " ")
                            ldrRecord("clientBankBrh") = "XXX".PadRight(cls.recordArray(cls.SecondPartyBranch, cls.strSize), " ")
                            ldrRecord("clientAC") = "XXXXXXXXX".PadRight(cls.recordArray(cls.SecondPartyAcc, cls.strSize), " ")
                        Else
                            ldrRecord("clientBankNo") = lstrBank.Substring(0, 3).PadRight(cls.recordArray(cls.SecondPartyBankNo, cls.strSize), " ")
                            ldrRecord("clientBankBrh") = lstrBank.Substring(3, 3).PadRight(cls.recordArray(cls.SecondPartyBranch, cls.strSize), " ")
                            ldrRecord("clientAC") = lstrBank.Substring(6, lstrBank.Length - 6).PadRight(cls.recordArray(cls.SecondPartyAcc, cls.strSize), " ")
                        End If
                        ldrRecord("amt") = CStr(CDbl(Me.dgvFundOutS.Rows(i).Cells("fund_out_amt_s").Value)).PadLeft(cls.recordArray(cls.Amount, cls.strSize), "0")
                        ldrRecord("clientIDCon") = "".PadRight(cls.recordArray(cls.SecondPartyIDCon, cls.strSize), " ")
                        ldrRecord("clientRef") = "".PadRight(cls.recordArray(cls.SecondPartyReference, cls.strSize), " ")
                        ldtRecord.Rows.Add(ldrRecord)
                    End If
                End If
            Next
            Me.dgvRecord.DataSource = ldtRecord
            Me.cboFirstPartyAC.Items.Clear()
            Me.cboFirstPartyAC.Text = cls.lFncGetCommAccS()
            Me.txtPaymentCode.Text = cls.lFncGetPayCodeS()
            Me.dpVDate.Value = Me.dpS.Value
            Me.TabControl1.SelectedIndex = 2
        Else
            GSubShowInfo(GFncGetSysMsg(24))
        End If
    End Sub

    Private Sub btnTransfer_f_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTransfer_f.Click
        If (Me.dgvFundOutF.Rows.Count > 0) Then
            ldtRecord = New DataTable
            cls.InitManagerDTF(ldtRecord)
            For i As Integer = 0 To Me.dgvFundOutF.Rows.Count - 1
                If Not (IsDBNull(Me.dgvFundOutF.Rows(i).Cells("clt_check_f").Value)) Then
                    If (Me.dgvFundOutF.Rows(i).Cells("clt_check_f").Value = 1) Then
                        Dim ldrRecord As DataRow = ldtRecord.NewRow
                        Dim lstrBank As String = Replace(Me.dgvFundOutF.Rows(i).Cells("bank_code_f").Value, "-", "")
                        lstrBank = Replace(lstrBank, " ", "")
                        ldrRecord("clientID") = Me.dgvFundOutF.Rows(i).Cells("clt_code_f").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyID, cls.strSize)).Substring(0, cls.recordArray(cls.SecondPartyID, cls.strSize))
                        ldrRecord("clientBankName") = Me.dgvFundOutF.Rows(i).Cells("clt_name_f").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyBankAcc, cls.strSize)).Substring(0, cls.recordArray(cls.SecondPartyBankAcc, cls.strSize))
                        If lstrBank.Length <= 6 Then
                            ldrRecord("clientBankNo") = "   ".PadRight(cls.recordArray(cls.SecondPartyBankNo, cls.strSize), " ")
                            ldrRecord("clientBankBrh") = "XXX".PadRight(cls.recordArray(cls.SecondPartyBranch, cls.strSize), " ")
                            ldrRecord("clientAC") = "XXXXXXXXX".PadRight(cls.recordArray(cls.SecondPartyAcc, cls.strSize), " ")
                        Else
                            ldrRecord("clientBankNo") = lstrBank.Substring(0, 3).PadRight(cls.recordArray(cls.SecondPartyBankNo, cls.strSize), " ")
                            ldrRecord("clientBankBrh") = lstrBank.Substring(3, 3).PadRight(cls.recordArray(cls.SecondPartyBranch, cls.strSize), " ")
                            ldrRecord("clientAC") = lstrBank.Substring(6, lstrBank.Length - 6).PadRight(cls.recordArray(cls.SecondPartyAcc, cls.strSize), " ")
                        End If

                        ldrRecord("amt") = CStr(CDbl(Me.dgvFundOutF.Rows(i).Cells("fund_out_amt_f").Value)).PadLeft(cls.recordArray(cls.Amount, cls.strSize), "0")
                        ldrRecord("clientIDCon") = "".PadRight(cls.recordArray(cls.SecondPartyIDCon, cls.strSize), " ")
                        ldrRecord("clientRef") = "".PadRight(cls.recordArray(cls.SecondPartyReference, cls.strSize), " ")
                        ldtRecord.Rows.Add(ldrRecord)
                    End If
                End If
            Next
            Me.dgvRecord.DataSource = ldtRecord
            Me.cboFirstPartyAC.Items.Clear()
            Me.cboFirstPartyAC.Text = cls.lFncGetCommAccF()
            Me.txtPaymentCode.Text = cls.lFncGetPayCodeF()
            Me.dpVDate.Value = Me.dpF.Value
            Me.TabControl1.SelectedIndex = 2
        Else
            GSubShowInfo(GFncGetSysMsg(24))
        End If
    End Sub

    Private Sub dpS_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpS.ValueChanged
        Dim prevVDate As DataRow() = dtTDate.Select(" sec_fut = 'S' and tdate < #" & Format(Me.dpS.Value, "yyyy/MM/dd") & "# ", _
                                                    " tdate desc ")
        If (prevVDate.Length > 0) Then
            Me.txtDateFromS.Text = Format(prevVDate(0).Item("tdate"), "yyyy/MM/dd")
            Me.txtTimeFromS.Text = cutTime
            Me.txtDateToS.Text = Format(Me.dpS.Value, "yyyy/MM/dd")
            Me.txtTimeToS.Text = cutTime
            ldtRecord = New DataTable
            cls.InitManagerDTF(ldtRecord)
            Me.dgvFundOutS.DataSource = dtFundOutEmptyS
        End If
    End Sub

    Private Sub dpF_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dpF.ValueChanged
        Dim prevVDate As DataRow() = dtTDate.Select(" sec_fut = 'F' and tdate < #" & Format(Me.dpF.Value, "yyyy/MM/dd") & "# ", _
                                                    " tdate desc ")
        If (prevVDate.Length > 0) Then
            Me.txtDateFromF.Text = Format(prevVDate(0).Item("tdate"), "yyyy/MM/dd")
            Me.txtTimeFromF.Text = cutTime
            Me.txtDateToF.Text = Format(Me.dpF.Value, "yyyy/MM/dd")
            Me.txtTimeToF.Text = cutTime
            ldtRecord = New DataTable
            cls.InitManagerDTF(ldtRecord)
            Me.dgvFundOutF.DataSource = dtFundOutEmptyF
        End If
    End Sub
 
End Class
