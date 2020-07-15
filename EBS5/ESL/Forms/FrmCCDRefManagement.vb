Imports System.Data.SqlClient

Public Class FrmCCDRefManagement
    Private _client_type As String
    Dim cls As New ClsCCDRefMgmt

    Public Sub SetAccNo(ByVal accNo As String)
        lblCCDRefAccountNo.Text = accNo
    End Sub

    Public Sub SetClientType(ByVal accountType As String)
        _client_type = accountType.Trim
    End Sub

    Private Sub btnCCDRefMgmtExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCDRefMgmtExit.Click
        Me.Close()
    End Sub

    Private Sub btnLinkCCDRef_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLinkCCDRef.Click

        Dim MyTrans As SqlTransaction = Nothing
        Dim dtInitCCDList As New DataTable()
        Dim dtInitAccList As New DataTable()
        Dim dtMatchedAccList As New DataTable()
        Dim dtIsolatedPrefix As New DataTable()

        Dim inputAccountNo, inputAccountType, inputCCDRef, selectedAccountNo, selectedAccountType, sourceAccountNo, sourceAccountType As String

                inputAccountNo = Me.txtAccountNo.Text.Trim
                inputAccountType = Me.cboAccountType.Text.Trim
        inputCCDRef = Me.txtCCDRef.Text.Trim
        selectedAccountNo = Me.lblCCDRefAccountNo.Text.Trim
        selectedAccountType = _client_type.Trim
        sourceAccountNo = ""
        sourceAccountType = ""

        If Not String.IsNullOrEmpty(inputCCDRef) Then
            If Not IsNumeric(inputCCDRef) Or inputCCDRef.Length <= 0 Then
                MsgBox("Input CCD is not a number")
                Return
            ElseIf Not String.IsNullOrEmpty(inputAccountNo) Or _
                Not String.IsNullOrEmpty(inputAccountType) Then
                MsgBox("Please Enter either Account or CCD Ref")
                Return
            ElseIf String.IsNullOrEmpty(inputAccountNo) And _
                String.IsNullOrEmpty(inputAccountType) And _
                Not HasRows(cls.lFnCheckCCDRefExist(inputCCDRef)) Then
                MsgBox("Input CCD do not exist")
                Return
            End If
        ElseIf String.IsNullOrEmpty(inputCCDRef) Then
            If String.IsNullOrEmpty(inputAccountNo) And _
                Not String.IsNullOrEmpty(inputAccountType) Then
                MsgBox("Missing Account No")
                Return
            ElseIf Not String.IsNullOrEmpty(inputAccountNo) And _
                String.IsNullOrEmpty(inputAccountType) Then
                MsgBox("Missing Account Type")
                Return
            ElseIf Not String.IsNullOrEmpty(inputAccountNo) And _
                Not String.IsNullOrEmpty(inputAccountType) And _
                Not HasRows(cls.lFnCheckAccountNoExistInG2B(inputAccountNo, inputAccountType)) Then
                MsgBox("Input Account do not exist in G2BS/F")
                Return
                        End If
                    End If

        Try

            dtInitAccList = cls.getInitAccList(inputAccountNo, selectedAccountNo)

            dtInitCCDList = cls.getInitCCDList(inputCCDRef, dtInitAccList)

            'Find out accounts which linked by the prefix or ccd from input/selected acc
            dtMatchedAccList = cls.getAllLinkedAccList(dtInitAccList, dtInitCCDList)

            Dim tempDr() As DataRow = Nothing

            'select source data from existing record for later insert or update
            If Not String.IsNullOrEmpty(inputAccountNo) And Not String.IsNullOrEmpty(inputAccountType) Then
                tempDr = dtMatchedAccList.Select(" isExist = 'Y' and acc_no = '" & inputAccountNo & "' and client_type = '" & inputAccountType & "' ")
            ElseIf Not String.IsNullOrEmpty(inputCCDRef) Then
                tempDr = dtMatchedAccList.Select(" isExist = 'Y' and ccd_ref =" & inputCCDRef, "acc_no DESC")
            End If

            If tempDr IsNot Nothing Then
                If tempDr.Length > 0 Then
                    sourceAccountNo = tempDr(0)("acc_no").Trim
                    sourceAccountType = tempDr(0)("client_type").Trim
                End If
            End If

            MyTrans = GSCnSqlConn.BeginTransaction

            Dim confirmMsContent As String = ""

            For Each row As DataRow In dtMatchedAccList.Rows
                If row("isExist") = "N" Then
                    If Not String.IsNullOrEmpty(sourceAccountNo) _
                        And Not String.IsNullOrEmpty(sourceAccountType) Then
                        cls.lFnInsertFromExisting(MyTrans, row.Item("acc_no"), row.Item("client_type"), sourceAccountNo, sourceAccountType)
                    Else
                        cls.lFnInsertClientMaster(MyTrans, row.Item("acc_no").Trim, row.Item("client_type").Trim)
                    End If
                End If
                confirmMsContent += "" & row.Item("acc_no") & "  " & row.Item("client_type") & Environment.NewLine
            Next

            Dim confirmMsStr As String = "Link up with following Accounts: " & Environment.NewLine
            confirmMsStr += "Account                 Type" & Environment.NewLine
            confirmMsStr += "<content>"
            confirmMsStr += "Confirm to Save?"
            confirmMsStr = confirmMsStr.Replace("<content>", confirmMsContent)

            If MsgBox(confirmMsStr, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Throw New Exception("Cancel Action")
            End If

            cls.lFnEditLinkedAcc(MyTrans, dtMatchedAccList, sourceAccountNo, sourceAccountType)

            MyTrans.Commit()
            MyTrans = Nothing
            GSubShowInfo(GFncGetSysMsg(8))

        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                If ex.Message <> "Cancel Action" Then
                    GSubWriteErrLog(ex.Message)
                End If
            End If
        End Try
    End Sub

    Private Sub txtCCDRef_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtCCDRef.PreviewKeyDown
        InvokecCDRefInputValidation()
        InvokeAccountNoFieldCheck()
    End Sub

    Private Sub txtCCDRef_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCCDRef.KeyUp
        InvokecCDRefInputValidation()
        InvokeAccountNoFieldCheck()
    End Sub

    Private Sub txtAccountNo_PreviewKeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PreviewKeyDownEventArgs) Handles txtAccountNo.PreviewKeyDown
        InvokeCCDRefCheck()
    End Sub

    Private Sub txtAccountNo_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAccountNo.KeyUp
        InvokeCCDRefCheck()
    End Sub
    Private Sub InvokeAccountNoFieldCheck()
        Dim checkAccountNoTextField As String
        checkAccountNoTextField = Me.txtAccountNo.Text.Trim

        If Not String.IsNullOrEmpty(checkAccountNoTextField) And _
            Me.txtCCDRef.Text.Trim.Length > 0 Then

            Me.txtAccountNo.Text = ""
            Me.cboAccountType.Enabled = False
        Else

            Me.txtAccountNo.Enabled = False
            Me.cboAccountType.Enabled = False
            If Me.txtCCDRef.Text = "" Then
                Me.txtAccountNo.Enabled = True
                Me.cboAccountType.Enabled = True
                Me.cboAccountType.SelectedIndex = -1
            End If
        End If
    End Sub
    Private Sub InvokecCDRefInputValidation()
        Dim checkCCDRefTextField As String
        checkCCDRefTextField = Me.txtCCDRef.Text.Trim

        Dim temp As Integer

        If Not String.IsNullOrEmpty(checkCCDRefTextField) And _
           Not Int32.TryParse(checkCCDRefTextField, temp) Then
            MsgBox("CCD Ref does not accept characters")
            Me.txtCCDRef.Text = String.Empty
        End If
    End Sub
    Private Sub InvokeCCDRefCheck()
        Dim checkCCDRefTextField As String

        checkCCDRefTextField = Me.txtCCDRef.Text.Trim

        If Not String.IsNullOrEmpty(checkCCDRefTextField) And _
            Me.txtAccountNo.Text.Trim.Length > 0 Then

            Me.txtCCDRef.Text = ""
            Me.cboAccountType.Enabled = False
        Else

            Me.txtCCDRef.Enabled = False
            Me.cboAccountType.Enabled = True
            If Me.txtAccountNo.Text = "" Then
                Me.txtCCDRef.Enabled = True
                Me.cboAccountType.SelectedIndex = -1
            End If
        End If
    End Sub

    Private Sub CreateNewCCDRef(ByVal selectAccNo As String, ByVal selectAccType As String)
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            Dim rtnCode = cls.lFnAddNewCCDRef(MyTrans, selectAccNo, selectAccType)

            If rtnCode <= 0 Then
                MsgBox("No row has been updated")
            End If

            MyTrans.Commit()
            Me.Close()

        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                MsgBox("Fail to create a new CCD Ref", MsgBoxStyle.OkOnly)
            End If
        End Try

        MyTrans = Nothing
    End Sub

    Private Sub SubmitAssignAccountNo(ByVal updateAccNo As String, ByVal updateAccType As String, ByVal refAccNo As String, ByVal refAccountType As String)

        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            Dim rtnCode = cls.lFnUpdateCCDRefGivenInputAccNoAndAccType(MyTrans, updateAccNo, updateAccType, refAccNo, refAccountType)

            If rtnCode <= 0 Then
                MsgBox("No row has been updated")
            Else
                MsgBox("Saved Successfully!")
            End If

            MyTrans.Commit()
            Me.Close()

        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                MsgBox("Fail to link CCD Ref", MsgBoxStyle.OkOnly)
            End If
        End Try

        MyTrans = Nothing
    End Sub

    Private Sub SubmitAssignCCDRef(ByVal updateAccNo As String, ByVal updateAccType As String, ByVal inputCCDRef As String)

        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            Dim rtnCode = cls.lFnUpdateCCDRefGivenInputCCDRef(MyTrans, updateAccNo, updateAccType, inputCCDRef)

            If rtnCode <= 0 Then
                MsgBox("No row has been updated")
            Else
                MsgBox("Saved Successfully!")
            End If

            MyTrans.Commit()
            Me.Close()

        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
                MsgBox("Fail to link CCD Ref", MsgBoxStyle.OkOnly)
            End If
        End Try

        MyTrans = Nothing
    End Sub

    Private Function IsExistAccountOrCCDRefNotNull(ByVal accountno As String, ByVal accountType As String) As Boolean
        Dim rtn As Boolean = False
        Dim ds As DataSet = Nothing
        ds = cls.lFnCheckAccountNoExist(accountno, accountType)

        If HasRows(ds) Then
            Dim result As Object
            result = ds.Tables(0).Rows(0).Item("ccd_ref")

            Dim rtnVal As Integer
            If Not IsDBNull(result) And result IsNot Nothing And Int32.TryParse(result.ToString, rtnVal) Then
                rtn = rtnVal > 0
            End If
        End If
        ds = Nothing
        IsExistAccountOrCCDRefNotNull = rtn
    End Function
    Private Function HasCCDRef(ByVal ccdref As String) As Boolean

        Dim rtn As Boolean = False
        Dim ds As DataSet = Nothing
        ds = cls.lFnCheckCCDRefExist(ccdref)

        If HasRows(ds) Then
            Dim result As Object
            result = ds.Tables(0).Rows(0).Item("ccdref_RC")

            Dim rtnVal As Integer
            If Not IsDBNull(result) And result IsNot Nothing And Int32.TryParse(result.ToString, rtnVal) Then
                rtn = rtnVal > 0
            End If
        End If
        ds = Nothing
        HasCCDRef = rtn
    End Function

    Private Function HasRows(ByRef ds As DataSet) As Boolean
        Dim rtn As Boolean = False
        If ds IsNot Nothing Then
            For Each dt As DataTable In ds.Tables
                If dt.Rows.Count > 0 Then
                    rtn = True
                    Exit For
                End If
            Next
        End If

        HasRows = rtn
    End Function
End Class