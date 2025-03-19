Imports System.Data.SqlClient

Public Class FrmCIESMaintenance
    Dim cls As New ClsCIESMaintenance
    Dim type As String = ""
    Dim EmailFlag As String
    Dim AdjEmail As String

    Private Sub lFnLoadClientMaster()

        Me.dgvClientMaster.DataSource = cls.lFnGetClientMaster()
        Me.dgvClientMaster.DataMember = "cltMaster"

        For Idrow As Integer = 0 To dgvClientMaster.RowCount - 1
            dgvClientMaster.Item("Open_deposit", Idrow).Value = Math.Round(dgvClientMaster.Item("Open_deposit", Idrow).Value, 2)
        Next

    End Sub

    Private Sub txtClientCode_Validate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtClientCode.Validated
        Dim ds As DataSet = cls.lfncCheckClientCode(Me.txtClientCode.Text)
        If ds.Tables(0).Rows.Count > 0 Then
            Me.txtName.Text = cls.lfncCheckClientCode(Me.txtClientCode.Text).Tables(0).Rows(0).Item(0)
        Else
            If Me.txtClientCode.Text <> "" Then
                GSubShowWarn("Invalid Client Code!")
                Me.txtClientCode.Focus()
            End If
        End If
    End Sub

    Private Sub lFnEnableEdit(ByVal bool As Boolean)
        txtClientCode.Enabled = False
        txtName.Enabled = False
        cbxPlanCode.Enabled = bool
        dtpInitialDate.Enabled = bool
        txtChargeRate.Enabled = bool
        txtOpenDeposit.Enabled = bool
        btnAdd.Enabled = Not bool
        btnEdit.Enabled = Not bool
        btnDelete.Enabled = Not bool
        btnSave.Enabled = bool
        If type = "Add" Then
            txtClientCode.Enabled = True
        End If
        dtpFaDate.Enabled = bool
    End Sub

    Private Sub FrmCIESMaintenance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        cbxPlanCode.DataSource = cls.lFnGetPlanCode
        cbxPlanCode.ValueMember = "misc_code"
        lFnLoadClientMaster()
        lFnEnableEdit(False)
        btnRefresh_Click(Nothing, System.EventArgs.Empty)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientMaster.CellContentDoubleClick
        tcCIESMain.SelectedIndex = 1
        'type = "Edit"
        txtClientCode.Text = dgvClientMaster.Item(0, dgvClientMaster.SelectedRows(0).Index).Value
        txtName.Text = dgvClientMaster.Item(1, dgvClientMaster.SelectedRows(0).Index).Value
        cbxPlanCode.Text = dgvClientMaster.Item(2, dgvClientMaster.SelectedRows(0).Index).Value
        dtpInitialDate.Value = dgvClientMaster.Item(3, dgvClientMaster.SelectedRows(0).Index).Value
        If dgvClientMaster.Item(4, dgvClientMaster.SelectedRows(0).Index).Value.Equals(System.DBNull.Value) Then
            txtChargeRate.Text = ""
        Else
            txtChargeRate.Text = dgvClientMaster.Item(4, dgvClientMaster.SelectedRows(0).Index).Value
        End If
        If dgvClientMaster.Item(5, dgvClientMaster.SelectedRows(0).Index).Value.Equals(System.DBNull.Value) Then
            txtOpenDeposit.Text = ""
        Else
            'txtOpenDeposit.Text = dgvClientMaster.Item(5, dgvClientMaster.SelectedRows(0).Index).Value
            txtOpenDeposit.Text = Math.Round(dgvClientMaster.Item(5, dgvClientMaster.SelectedRows(0).Index).Value, 2)
        End If

        'lFnEnableEdit(True)
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        tcCIESMain.SelectedIndex = 1
        type = "Add"
        txtClientCode.Text = ""
        txtName.Text = ""
        cbxPlanCode.Text = ""
        txtChargeRate.Text = ""
        txtOpenDeposit.Text = ""
        dtpFaDate.Value = DateTime.Today
        lFnEnableEdit(True)
        'GFncRunSQL(GSCnLiqConn, "insert into CIES_client_master (clt_code,plan_code,Init_date,Charge_rate) values ('00000009','B' , '2011/07/21',0.13)")
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If tcCIESMain.SelectedIndex = 1 Then
            type = ""
            lFnEnableEdit(False)
            tcCIESMain.SelectedIndex = 0
        ElseIf tcCIESMain.SelectedIndex = 2 Then
            If EmailFlag <> "" Then
                EnableEmail(False)
                Me.txtEmail.Text = ""
                EmailFlag = ""
                btnRefresh_Click(Nothing, System.EventArgs.Empty)
                Me.DtgMail.Focus()
            Else
                Me.Close()
            End If
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        tcCIESMain.SelectedIndex = 1
        txtClientCode.Text = dgvClientMaster.Item(0, dgvClientMaster.SelectedRows(0).Index).Value
        txtName.Text = dgvClientMaster.Item(1, dgvClientMaster.SelectedRows(0).Index).Value
        cbxPlanCode.Text = dgvClientMaster.Item(2, dgvClientMaster.SelectedRows(0).Index).Value
        dtpInitialDate.Value = dgvClientMaster.Item(3, dgvClientMaster.SelectedRows(0).Index).Value
        If dgvClientMaster.Item(4, dgvClientMaster.SelectedRows(0).Index).Value.Equals(System.DBNull.Value) Then
            txtChargeRate.Text = ""
        Else
            txtChargeRate.Text = dgvClientMaster.Item(4, dgvClientMaster.SelectedRows(0).Index).Value
        End If
        If dgvClientMaster.Item(5, dgvClientMaster.SelectedRows(0).Index).Value.Equals(System.DBNull.Value) Then
            txtOpenDeposit.Text = ""
        Else
            'txtOpenDeposit.Text = dgvClientMaster.Item(5, dgvClientMaster.SelectedRows(0).Index).Value
            txtOpenDeposit.Text = Math.Round(dgvClientMaster.Item(5, dgvClientMaster.SelectedRows(0).Index).Value, 2)
        End If
        If dgvClientMaster.Item(6, dgvClientMaster.SelectedRows(0).Index).Value.Equals(System.DBNull.Value) Then
            dtpFaDate.Value = DateTime.Today
        Else
            dtpFaDate.Value = dgvClientMaster.Item(6, dgvClientMaster.SelectedRows(0).Index).Value
        End If
        type = "Edit"
        lFnEnableEdit(True)
    End Sub

    Private Sub tcselecting(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcCIESMain.SelectedIndexChanged
        If dgvClientMaster.Rows.Count > 0 Then
            txtClientCode.Text = dgvClientMaster.Item(0, dgvClientMaster.SelectedRows(0).Index).Value
            txtName.Text = dgvClientMaster.Item(1, dgvClientMaster.SelectedRows(0).Index).Value
            cbxPlanCode.Text = dgvClientMaster.Item(2, dgvClientMaster.SelectedRows(0).Index).Value
            dtpInitialDate.Value = dgvClientMaster.Item(3, dgvClientMaster.SelectedRows(0).Index).Value
            If dgvClientMaster.Item(4, dgvClientMaster.SelectedRows(0).Index).Value.Equals(System.DBNull.Value) Then
                txtChargeRate.Text = ""
            Else
                txtChargeRate.Text = dgvClientMaster.Item(4, dgvClientMaster.SelectedRows(0).Index).Value
            End If
            If dgvClientMaster.Item(5, dgvClientMaster.SelectedRows(0).Index).Value.Equals(System.DBNull.Value) Then
                txtOpenDeposit.Text = ""
            Else
                'txtOpenDeposit.Text = dgvClientMaster.Item(5, dgvClientMaster.SelectedRows(0).Index).Value
                txtOpenDeposit.Text = Math.Round(dgvClientMaster.Item(5, dgvClientMaster.SelectedRows(0).Index).Value, 2)
            End If
            If dgvClientMaster.Item(6, dgvClientMaster.SelectedRows(0).Index).Value.Equals(System.DBNull.Value) Then
                dtpFaDate.Value = DateTime.Today
            Else
                dtpFaDate.Value = dgvClientMaster.Item(6, dgvClientMaster.SelectedRows(0).Index).Value
            End If
        End If

        If Me.tcCIESMain.SelectedIndex = 2 Then
            Me.btnAdd.Enabled = False
            Me.btnDelete.Enabled = False
            Me.btnEdit.Enabled = False
        Else
            Me.btnAdd.Enabled = True
            Me.btnDelete.Enabled = True
            Me.btnEdit.Enabled = True
        End If


    End Sub

    Private Sub tcMail_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tcCIESMain.Selecting
        If Me.btnSave.Enabled Then
            e.Cancel = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim MyTrans As SqlTransaction = Nothing
        Dim MyTrans2 As SqlTransaction = Nothing

        If Me.tcCIESMain.SelectedIndex = 2 Then
            Select Case EmailFlag
                Case "New"
                    If Me.txtEmail.Text.Length <= 0 Or EmailValidation(txtEmail.Text) = False Then
                        GSubShowInfo(GFncGetSysMsg(19))
                        Me.txtEmail.Focus()
                        Return
                    End If
                    If GSubShowYNConfirm(GFncGetSysMsg(47), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Me.txtEmail.Focus()
                        Return
                    End If
                    AdjEmail = Me.txtEmail.Text.ToLower.Trim
                    cls.EmailAdd(Me.txtEmail.Text.ToLower.Trim)
                    EnableEmail(False)
                    btnRefresh_Click(Nothing, System.EventArgs.Empty)
                    EmailFlag = ""
                    SetEmailFocus()
                    ' Me.DtgMail.Focus()

                Case "Adjust"
                    If Me.txtEmail.Text.Length <= 0 Or EmailValidation(txtEmail.Text) = False Then
                        GSubShowInfo(GFncGetSysMsg(19))
                        Me.txtEmail.Focus()
                        Return
                    End If
                    If GSubShowYNConfirm(GFncGetSysMsg(39), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                        Me.txtEmail.Focus()
                        Return
                    End If
                    cls.EmailAdjust(AdjEmail, Me.txtEmail.Text)
                    AdjEmail = Me.txtEmail.Text

                    EnableEmail(False)
                    btnRefresh_Click(Nothing, System.EventArgs.Empty)
                    EmailFlag = ""
                    SetEmailFocus()
                    'Me.DtgMail.Focus()

            End Select


        ElseIf txtClientCode.Text <> "" Then
            If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
                Try
                    MyTrans = GSCnLiqConn.BeginTransaction
                    MyTrans2 = GSCnSqlConn.BeginTransaction
                    If txtChargeRate.Text = "" Then
                        txtChargeRate.Text = "0.00"
                    End If
                    If txtOpenDeposit.Text = "" Then
                        txtOpenDeposit.Text = "0"
                    End If
                    If type = "Add" Then
                        cls.lFnWriteLog(MyTrans2, Me.txtClientCode.Text, "A", lfncGetLog(type, MyTrans))
                        cls.lFnAddClientMaster(MyTrans, Me.txtClientCode.Text.Trim, Me.cbxPlanCode.Text.Trim, Me.dtpInitialDate.Value, _
                        Me.txtChargeRate.Text.Trim, Me.txtOpenDeposit.Text.Trim, Me.dtpFaDate.Value)


                    Else
                        cls.lFnWriteLog(MyTrans2, Me.txtClientCode.Text, "M", lfncGetLog(type, MyTrans))
                        cls.lFnEditClientMaster(MyTrans, dgvClientMaster.Item(0, dgvClientMaster.SelectedRows(0).Index).Value, _
                        Me.txtClientCode.Text.Trim, Me.cbxPlanCode.Text.Trim, Me.dtpInitialDate.Value, Me.txtChargeRate.Text.Trim, _
                        Me.txtOpenDeposit.Text.Trim, Me.dtpFaDate.Value)


                    End If
                    MyTrans.Commit()
                    MyTrans = Nothing
                    MyTrans2.Commit()
                    MyTrans2 = Nothing
                    GSubShowInfo(GFncGetSysMsg(8))
                    lFnLoadClientMaster()
                Catch ex As Exception
                    If GSCnLiqConn.State <> ConnectionState.Closed Then
                        If (MyTrans IsNot Nothing) Then
                            MyTrans.Rollback()
                        End If
                        GSubWriteErrLog(ex.Message)
                    End If
                    If GSCnSqlConn.State <> ConnectionState.Closed Then
                        If (MyTrans2 IsNot Nothing) Then
                            MyTrans2.Rollback()
                        End If
                        GSubWriteErrLog(ex.Message)
                    End If
                End Try
                lFnLoadClientMaster()
                Me.btnSave.Enabled = False
                lFnEnableEdit(False)
                Me.tcCIESMain.SelectedIndex = 0
                type = ""
            End If
        Else
            GSubShowWarn("Client Code is Empty!")
            Me.txtClientCode.Focus()
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        type = "Del"
        Dim MyTrans As SqlTransaction = Nothing
        Dim MyTrans2 As SqlTransaction = Nothing
        If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
            Try
                MyTrans = GSCnLiqConn.BeginTransaction
                MyTrans2 = GSCnSqlConn.BeginTransaction
                cls.lFnWriteLog(MyTrans2, Me.txtClientCode.Text, "D", lfncGetLog(type, MyTrans))
                cls.lFnDelClientMaster(MyTrans, dgvClientMaster.Item(0, (dgvClientMaster.SelectedRows(0).Index)).Value)

                MyTrans.Commit()
                MyTrans = Nothing
                MyTrans2.Commit()
                MyTrans2 = Nothing

                GSubShowInfo(GFncGetSysMsg(8))
                lFnLoadClientMaster()
            Catch ex As Exception
                If GSCnLiqConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans2 IsNot Nothing) Then
                        MyTrans2.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try
            lFnLoadClientMaster()
            Me.btnSave.Enabled = False
            Me.tcCIESMain.SelectedIndex = 0
            type = ""
        End If
    End Sub

    Public Function lfncGetLog(ByVal type As String, ByVal mytrans As SqlTransaction) As String
        Dim Log As String = ""
        If type = "Add" Then
            If Me.txtClientCode.Text.Length > 0 Then
                Log += GfncOneFieldLog("clt_code", Me.txtClientCode.Text)
            End If
            If Me.cbxPlanCode.Text.Length > 0 Then
                Log += GfncOneFieldLog("plan_code", Me.cbxPlanCode.Text)
            End If
            Log += GfncOneFieldLog("Init_date", Me.dtpInitialDate.Text)
            If Me.txtChargeRate.Text.Length > 0 Then
                Log += GfncOneFieldLog("Charge_rate", Me.txtChargeRate.Text)
            End If
            If Me.txtOpenDeposit.Text.Length > 0 Then
                Log += GfncOneFieldLog("Open_deposit", Me.txtOpenDeposit.Text)
            End If
        ElseIf type = "Edit" Then
            Dim DT As DataTable = cls.lfncGetClientMasterByClientCode(Me.txtClientCode.Text, mytrans)

            If Me.cbxPlanCode.Text <> GFncNoNullString(DT.Rows(0).Item("plan_code")) Then
                Log += GfncOneFieldLog("plan_code", GFncNoNullString(DT.Rows(0).Item("plan_code")), Me.cbxPlanCode.Text)
            End If
            If Me.dtpInitialDate.Value <> GFncNoNullString(DT.Rows(0).Item("Init_date")) Then
                Log += GfncOneFieldLog("Init_date", GFncNoNullString(DT.Rows(0).Item("Init_date")), Me.dtpInitialDate.Value)
            End If
            If Me.txtChargeRate.Text <> GFncNoNullString(DT.Rows(0).Item("Charge_rate")) Then
                Log += GfncOneFieldLog("Charge_rate", GFncNoNullString(DT.Rows(0).Item("Charge_rate")), Me.txtChargeRate.Text)
            End If
            If Me.txtOpenDeposit.Text <> GFncNoNullString(DT.Rows(0).Item("Open_deposit")) Then
                Log += GfncOneFieldLog("Open_deposit", GFncNoNullString(DT.Rows(0).Item("Open_deposit")), Me.txtOpenDeposit.Text)
            End If
        ElseIf type = "Del" Then
            Dim DT As DataTable = cls.lfncGetClientMasterByClientCode(dgvClientMaster.Item(0, (dgvClientMaster.SelectedRows(0).Index)).Value, mytrans)
            Log += GfncOneFieldLog("clt_code", GFncNoNullString(DT.Rows(0).Item("clt_code")))
            Log += GfncOneFieldLog("plan_code", GFncNoNullString(DT.Rows(0).Item("plan_code")))
            Log += GfncOneFieldLog("Init_date", GFncNoNullString(DT.Rows(0).Item("Init_date")))
            Log += GfncOneFieldLog("Charge_rate", GFncNoNullString(DT.Rows(0).Item("Charge_rate")))
            Log += GfncOneFieldLog("Open_deposit", GFncNoNullString(DT.Rows(0).Item("Open_deposit")))
        End If

        Return Log
    End Function

    Private Sub btnAlertAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAlertAdd.Click
        EnableEmail(True)

        Me.txtEmail.Text = ""
        EmailFlag = "New"
        Me.txtEmail.Focus()
    End Sub

    Private Sub EnableEmail(ByVal blnflag As Boolean)
        Me.txtEmail.ReadOnly = Not blnflag
        Me.btnRefresh.Enabled = Not blnflag
        Me.DtgMail.Enabled = Not blnflag
        Me.btnSave.Enabled = blnflag
        Me.btnAlertAdd.Enabled = Not blnflag
        Me.btnModify.Enabled = Not blnflag
        Me.btnDel.Enabled = Not blnflag
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        EnableEmail(True)
        EmailFlag = "Adjust"
        Me.txtEmail.Focus()
        AdjEmail = Me.txtEmail.Text
    End Sub


    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        DtgMail.Focus()
        If txtEmail.Text.Length > 0 Then
            If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            cls.EmailDel(Me.txtEmail.Text.Trim)
            btnRefresh_Click(Nothing, System.EventArgs.Empty)
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        DtgMail.DataSource = cls.EmailRefresh
    End Sub

    Private Sub DtgMail_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtgMail.SelectionChanged
        If Me.DtgMail.Rows.Count > 0 Then
            Me.txtEmail.Text = Me.DtgMail.CurrentRow.Cells("dtgEmail").Value.ToString.Trim
        End If
    End Sub

    Private Function EmailValidation(ByVal Email As String) As Boolean
        If Email.Contains(" ") Or Email.Contains("@") = False Then
            Return False
        Else
            Return True
        End If

    End Function

    Private Sub SetEmailFocus()
        For i As Integer = 0 To Me.DtgMail.RowCount - 1
            If Me.DtgMail.Rows(i).Cells("dtgEmail").Value.ToString.Trim = AdjEmail Then
                DtgMail.Rows(i).Cells("dtgEmail").Selected = True
                DtgMail_SelectionChanged(Nothing, System.EventArgs.Empty)
                AdjEmail = ""
                Exit Sub
            End If
        Next

    End Sub

End Class
