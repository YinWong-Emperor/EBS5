Imports System.IO

Public Class FrmAutopay

    Dim cls As New ClsAutopay

    Dim ldtRecord As New DataTable

    Dim act As String = ""
    Dim prevFirstPartyAC As String = ""
    Dim prevPaymentCode As String = ""
    Dim prevFirstPartyRef As String = ""
    Dim prevVDate As Date = Now

    Private Sub dgvRecord_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvRecord.SelectionChanged
        assignRecord(False)
    End Sub

    Private Sub hFieldEnable(ByVal flag As Boolean)
        Me.txtFirstPartyAC.Enabled = flag
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
        Me.btnLoadFile.Enabled = flag
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cls.InitManagerDTF(ldtRecord)
        cls.loadArray()
        assignRecord(False)
        hFieldEnable(False)
        rFieldEnable(False)
        btnEnable(True)
    End Sub

    Private Function rFieldValidation() As Boolean
        If (cls.checkAlphaNumeric(Me.txtClientID.Text) = False) Then
            MessageBox.Show("Client ID should be alphanumeric")
            Me.txtClientID.Focus()
            Return False
        End If
        If (cls.checkAlphaNumeric(Me.txtClientBankName.Text) = False) Then
            MessageBox.Show("Invalid Client Bank Name should be alphanumeric")
            Me.txtClientBankName.Focus()
            Return False
        End If
        If (cls.checkNumeric(Me.txtClientBankNo.Text) = False) Then
            MessageBox.Show(" Client Bank Number should be numeric")
            Me.txtClientBankNo.Focus()
            Return False
        End If
        If (cls.checkNumeric(Me.txtClientBankBrh.Text) = False) Then
            MessageBox.Show("Client Bank Branch should be numeric")
            Me.txtClientBankBrh.Focus()
            Return False
        End If
        If (cls.checkNumeric(Me.txtClientAC.Text) = False) Then
            MessageBox.Show("Client Account should be numeric")
            Me.txtClientAC.Focus()
            Return False
        End If
        If (cls.checkNumeric(Me.txtAmt.Text) = False) Then
            MessageBox.Show("Amount should be numeric")
            Me.txtAmt.Focus()
            Return False
        End If
        If (cls.checkAlphaNumeric(Me.txtClientRef.Text) = False) Then
            MessageBox.Show("Client Ref should be alphanumeric")
            Me.txtClientRef.Focus()
            Return False
        End If

        Return True
    End Function

    Private Function hFieldValidation() As Boolean
        If (cls.checkNumeric(Me.txtFirstPartyAC.Text) = False) Then
            MessageBox.Show("Company Account should be numeric")
            Me.txtFirstPartyAC.Focus()
            Return False
        End If
        If (cls.checkAlphaNumeric(Me.txtPaymentCode.Text) = False) Then
            MessageBox.Show("Payment Code should be alphanumeric")
            Me.txtPaymentCode.Focus()
            Return False
        End If
        If (cls.checkAlphaNumeric(Me.txtFirstPartyRef.Text) = False) Then
            MessageBox.Show("Company Reference should be alphanumeric")
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
        prevFirstPartyAC = Me.txtFirstPartyAC.Text
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
        assignRecord(True)
        hFieldEnable(False)
        rFieldEnable(True)
        btnEnable(False)
        Me.txtClientID.Focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If (Me.dgvRecord.Rows.Count > 0) Then
            act = "ER"
            hFieldEnable(False)
            rFieldEnable(True)
            btnEnable(False)
            Me.txtClientID.Focus()
        Else
            MessageBox.Show("Nothing to edit")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (Me.dgvRecord.Enabled) Then
            Me.Close()
        Else
            Me.txtFirstPartyAC.Text = prevFirstPartyAC
            Me.txtPaymentCode.Text = prevPaymentCode
            Me.txtFirstPartyRef.Text = prevFirstPartyRef
            Me.dpVDate.Value = prevVDate
            assignRecord(False)
            hFieldEnable(False)
            rFieldEnable(False)
            btnEnable(True)
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (Me.dgvRecord.Rows.Count > 0) Then
            Me.dgvRecord.Rows.RemoveAt(Me.dgvRecord.CurrentRow.Index)
            If (Me.dgvRecord.Rows.Count > 0) Then
                Me.dgvRecord.ClearSelection()
                Me.dgvRecord.Rows(0).Cells(0).Selected = True
                assignRecord(False)
            End If
        Else
            MessageBox.Show("Nothing to delete")
        End If
    End Sub

    Private Sub btnLoadFile_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoadFile.Click
        Dim openFileDialog1 As New System.Windows.Forms.OpenFileDialog
        Dim strLine As String = ""
        Try
            openFileDialog1.Filter = "Text (*.txt) |*.txt"
            If (openFileDialog1.ShowDialog() = Windows.Forms.DialogResult.OK) Then
                cls.GetDataFromFile(ldtRecord, openFileDialog1, Me.txtFirstPartyAC.Text, Me.txtPaymentCode.Text, _
                                    Me.txtFirstPartyRef.Text, Me.dpVDate.Value)
                Me.dgvRecord.DataSource = ldtRecord
            End If
        Catch Ex As Exception
            MessageBox.Show(Ex.Message)
        End Try
    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim GStrExptDir As String = ""
        Dim strExptFilename As String = ""
        Dim lstrFiles() As String
        Dim lsWriter As StreamWriter
        Dim lstrColValue As String
        Dim totalAmt As Decimal = 0
        Dim saveFileDialog1 As New System.Windows.Forms.SaveFileDialog

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

                For i As Integer = 0 To Me.dgvRecord.Rows.Count - 1
                    totalAmt = totalAmt + Me.dgvRecord.Rows(i).Cells("amt").Value
                Next

                lsWriter = New StreamWriter(GStrExptDir & strExptFilename, False, System.Text.Encoding.GetEncoding(950))
                lstrColValue = "F"
                lstrColValue = lstrColValue & Me.txtFirstPartyAC.Text.PadRight(cls.headerArray(cls.FirstPartyAccNo, cls.strSize), " ")
                lstrColValue = lstrColValue & Me.txtPaymentCode.Text.PadRight(cls.headerArray(cls.PaymentCode, cls.strSize), " ")
                lstrColValue = lstrColValue & Me.txtFirstPartyRef.Text.PadRight(cls.headerArray(cls.FirstPartyRef, cls.strSize), " ")
                lstrColValue = lstrColValue & Format(Me.dpVDate.Value, "ddMMyy")
                lstrColValue = lstrColValue & "K"
                lstrColValue = lstrColValue & "********"
                lstrColValue = lstrColValue & CStr(Me.dgvRecord.Rows.Count).PadLeft(cls.headerArray(cls.NoOfRec, cls.strSize), "0")
                lstrColValue = lstrColValue & CStr(CInt(totalAmt * 100)).PadLeft(cls.headerArray(cls.MonetaryTotal, cls.strSize), "0")
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
                    lstrColValue = lstrColValue & CStr(CInt(Me.dgvRecord.Rows(i).Cells("amt").Value * 100)).PadLeft(10, "0")
                    lstrColValue = lstrColValue & "    "
                    lstrColValue = lstrColValue & Me.dgvRecord.Rows(i).Cells("clientIDCon").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyIDCon, cls.strSize), " ")
                    lstrColValue = lstrColValue & Me.dgvRecord.Rows(i).Cells("clientRef").Value.ToString.PadRight(cls.recordArray(cls.SecondPartyReference, cls.strSize), " ")
                    lsWriter.WriteLine(lstrColValue)
                    lsWriter.Flush()
                Next
                lsWriter.Close()
                MessageBox.Show("Sucessfully export to " & GStrExptDir & strExptFilename)
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If ((act <> "EH") And (act <> "AR") And (act <> "ER")) Then
            MessageBox.Show("Invalid action")
            Return
        End If

        If (MessageBox.Show("Confirm to save?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) = Windows.Forms.DialogResult.Yes) Then
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
            prevFirstPartyAC = Me.txtFirstPartyAC.Text
            prevPaymentCode = Me.txtPaymentCode.Text
            prevFirstPartyRef = Me.txtFirstPartyRef.Text
            prevVDate = Me.dpVDate.Value
            Return
        End If
    End Sub

End Class
