Public Class FrmChequePrintingDetails

    Dim cls As New ClsChequePrinting
    'Private pFormStatus As EnumFormStatus
    Private pSequence As Double
    Private pClientCode As String
    Private pClientName As String
    Private pAmount As Decimal
    Private pTxnDate As DateTime
    Private pFormOpenedMode As FormMode

    Private pOldClientCode As String

    Public Enum FormMode
        NewMode
        EditMode
        DetailMode
        '2017-11-22  针对mantisbt-6385 的修改
        DeleteMode
    End Enum



#Region "Public Function"

    Public Sub SetMode(m_mode As FormMode)
        Me.pFormOpenedMode = m_mode
        SetStatus()
    End Sub

    Public Sub Add(ByVal sequence As Integer, ByVal txnDate As DateTime)

        SetValues(sequence,
                  "",
                  "",
                  0,
                  txnDate)
    End Sub

    Public Sub Edit(
                        ByVal sequence As Integer,
                        ByVal clientCode As String,
                        ByVal clientName As String,
                        ByVal amount As Decimal,
                        ByVal txnDate As DateTime)

        Me.pOldClientCode = clientCode


        SetValues(sequence,
                  clientCode,
                  clientName,
                  amount,
                  txnDate)

    End Sub
    Public Sub Details(
                        ByVal sequence As Integer,
                        ByVal clientCode As String,
                        ByVal clientName As String,
                        ByVal amount As Decimal,
                        ByVal txnDate As DateTime)
        SetValues(sequence,
                  clientCode,
                  clientName,
                  amount,
                  txnDate)

    End Sub
    '2017-11-22  针对mantisbt-6385 的修改
    Public Sub Delete(
                        ByVal sequence As Integer,
                        ByVal clientCode As String,
                        ByVal clientName As String,
                        ByVal amount As Decimal,
                        ByVal txnDate As DateTime)
        SetValues(sequence,
                  clientCode,
                  clientName,
                  amount,
                  txnDate)

    End Sub

#End Region

#Region "Event"
    Private Sub btnCheckName_Click(sender As Object, e As EventArgs) Handles btnCheckName.Click
        If (rdb_AE.Checked) Then
            Dim strCC As String = Me.txtClientCode.Text.Trim
            If strCC = "" Then
                GSubShowWarn("Client Code can not be empty")
                Me.txtClientCode.Focus()
                Return
            End If
            Dim ccCls As New ClsAECodes
            Dim clientName As String = String.Empty
            clientName = ccCls.FncGetAEName(strCC)
            If Not String.IsNullOrEmpty(clientName.Trim) Then
                txtClientName.Text = clientName.Trim
            Else
                ccCls.ShowMsg_InvalidAECode()
            End If
            txtClientCode.Focus()
            Return
        Else
            GSubShowWarn("Only support AE search.")
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim strCC As String = Me.txtClientCode.Text.Trim
        If strCC = "" Then
            GSubShowWarn("Client Code can not be empty")
            Me.txtClientCode.Focus()
            Return
        End If

        If (rdb_AE.Checked) Then
            Dim ccCls As New ClsAECodes
            If (ccCls.FncIsAECodeLengthValid(strCC) = False) Then
                ccCls.ShowMsg_AECodeLengthLimition()
                txtClientCode.Focus()
                Return
            End If

            If Me.pFormOpenedMode = FormMode.NewMode Then
                If (ccCls.FncIsAECodeExist(strCC) = False) Then
                    ccCls.ShowMsg_InvalidAECode()
                    txtClientCode.Focus()
                    Return
                End If
            ElseIf Me.pFormOpenedMode = FormMode.EditMode Then
                If (String.Equals(strCC, Me.pOldClientCode, StringComparison.OrdinalIgnoreCase) = False And ccCls.FncIsAECodeExist(strCC) = False) Then
                    ccCls.ShowMsg_InvalidAECode()
                    txtClientCode.Focus()
                    Return
                End If
            End If
        ElseIf rdb_Client.Checked Then
            Dim ccCls As New ClsClientCodes
            If (ccCls.FncIsClientCodeLengthValid(strCC) = False) Then
                ccCls.ShowMsg_ClientCodeLengthLimition()
                txtClientCode.Focus()
                Return
            End If

            If Me.pFormOpenedMode = FormMode.NewMode Then
                If (ccCls.FncIsClientCodeExist(strCC) = False) Then
                    ccCls.ShowMsg_InvalidClientCode()
                    txtClientCode.Focus()
                    Return
                End If
            ElseIf Me.pFormOpenedMode = FormMode.EditMode Then
                If (String.Equals(strCC, Me.pOldClientCode, StringComparison.OrdinalIgnoreCase) = False And ccCls.FncIsClientCodeExist(strCC) = False) Then
                    ccCls.ShowMsg_InvalidClientCode()
                    txtClientCode.Focus()
                    Return
                End If
            End If
        Else

        End If

        If Me.txtClientName.Text.Trim = "" Then
            GSubShowWarn("Client Name can not be empty")
            Me.txtClientName.Focus()
            Return
        End If
        If Me.nudAmount.Text.Trim = "" Then
            GSubShowWarn("Amount can not be empty")
            Me.nudAmount.Focus()
            Return
        End If
        If Me.nudAmount.Value = 0 Then
            GSubShowWarn("Amount can not be zero")
            Me.nudAmount.Focus()
            Return
        End If

        pSequence = amtSequence.Text
        If (Me.pFormOpenedMode = FormMode.NewMode) Then '(pFormStatus = EnumFormStatus.New) Then
            pSequence = Nothing
        End If
        pClientCode = txtClientCode.Text.Trim
        pClientName = txtClientName.Text.Trim
        Try
            pAmount = Convert.ToDecimal(nudAmount.Text.Trim)
        Catch ex As Exception
            GSubShowWarn("Amount must be number")
            Me.nudAmount.Focus()
            Return
        End Try

        pTxnDate = dtpTxnDate.Value.Date
        If (pSequence <= 0) Then
            pSequence = cls.FncInsert(
                pSequence,
                pClientCode,
                pTxnDate,
                pAmount,
                pClientName,
                GStrloginID,
                DateTime.Now
            )
            amtSequence.Text = pSequence

        Else
            If (cls.FncUpdate(
                pSequence,
                pClientCode,
                pTxnDate,
                pAmount,
                pClientName,
                GStrloginID,
                DateTime.Now
            ) = False) Then
                Return

            End If
        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

        If Me.btnSave.Enabled And pSequence > 0 Then

        End If

        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()

    End Sub

    Private Sub btnEdit_Click(sender As Object, e As EventArgs) Handles btnEdit.Click

    End Sub

    '2017-11-22  针对mantisbt-6385 的修改
    Private Sub btnDel_Click(sender As Object, e As EventArgs) Handles btnDel.Click
        pSequence = amtSequence.Text.Trim
        pTxnDate = dtpTxnDate.Value.Date

        If GSubShowYNConfirm("Confirm to Delete?") = Windows.Forms.DialogResult.Yes Then
            If cls.FncDelete(pSequence, pTxnDate) Then
                GSubShowInfo("Deleted successfully")
                Me.DialogResult = Windows.Forms.DialogResult.OK
                Me.Close()
            End If
        End If
    End Sub
#End Region

#Region "Private Function"
    Private Sub SetValues(ByVal sequence As Integer,
                        ByVal clientCode As String,
                        ByVal clientName As String,
                        ByVal Amount As Decimal,
                        ByVal txnDate As DateTime)

        pSequence = sequence
        pClientCode = clientCode
        pClientName = clientName
        pAmount = Amount
        pTxnDate = txnDate

        amtSequence.Text = sequence
        txtClientCode.Text = clientCode
        txtClientName.Text = clientName
        nudAmount.Text = Amount
        dtpTxnDate.Value = txnDate
    End Sub

#End Region

    '-----------

    Private Sub FrmChequePrintingDetails_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetStatus()
    End Sub

    Public Sub SetStatus()
        txtClientCode.ReadOnly = False
        txtClientName.ReadOnly = False
        dtpTxnDate.Enabled = True
        nudAmount.ReadOnly = False
        nudAmount.Controls(0).Enabled = True

        Select Case Me.pFormOpenedMode
            Case FormMode.NewMode
                btnDel.Visible = False
                btnSave.Visible = True

            Case FormMode.EditMode
                btnDel.Visible = False
                btnSave.Visible = True

            Case FormMode.DetailMode
                btnDel.Visible = False
                btnSave.Visible = False
                txtClientCode.ReadOnly = True
                txtClientName.ReadOnly = True
                dtpTxnDate.Enabled = False
                nudAmount.ReadOnly = True
                nudAmount.Controls(0).Enabled = False

            Case FormMode.DeleteMode
                btnDel.Visible = True
                btnSave.Visible = False

        End Select

        'Start P191038-715 Chris Chan
        txtClientCode.Focus()
        txtClientCode.Select()
        'End P191038-715 Chris Chan
    End Sub

    Private Sub txtClientCode_KeyDown(sender As Object, e As KeyEventArgs) Handles txtClientCode.KeyDown
        If e.KeyCode = Keys.Enter Then
            If (rdb_AE.Checked) Then
                btnCheckName.PerformClick()
            End If
        End If
    End Sub

    'Start P191038-715 Chris Chan
    Private Sub nudAmount_Enter(sender As Object, e As EventArgs) Handles nudAmount.Enter
        CType(sender, myNumericUpDown).Select(0, Me.ActiveControl.ToString().Length)
    End Sub

    Private Sub rdb_AE_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_AE.CheckedChanged
        CType(sender, RadioButton).TabStop = False
    End Sub

    Private Sub rdb_Client_CheckedChanged(sender As Object, e As EventArgs) Handles rdb_Client.CheckedChanged
        CType(sender, RadioButton).TabStop = False
    End Sub

    Private Sub rdb_AE_TabStopChanged(sender As Object, e As EventArgs) Handles rdb_AE.TabStopChanged
        CType(sender, RadioButton).TabStop = False
    End Sub

    Private Sub rdb_Client_TabStopChanged(sender As Object, e As EventArgs) Handles rdb_Client.TabStopChanged
        CType(sender, RadioButton).TabStop = False
    End Sub
    'End P191038-715 Chris Chan
End Class