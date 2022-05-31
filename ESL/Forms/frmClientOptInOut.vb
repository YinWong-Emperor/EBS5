Imports System.Data.SqlClient

Public Class FrmClientOptInOut
    Dim cls As New ClsClientOptInOut
    Dim type As String = ""
    Dim EmailFlag As String
    Dim AdjEmail As String
    Dim canBeDeleted As Boolean

    Private Sub lFnLoadClientMaster()

        Me.dgvClientMaster.DataSource = cls.lFnGetClientMaster()
        Me.dgvClientMaster.DataMember = "cltMaster"

    End Sub

    Private Sub txtClientCode_Validate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAccNo.Validated
        If type = "Edit" Then
            Return
        End If

        Dim ds As DataSet = cls.lfncCheckClientCode(GFncSqlQuote(txtAccNo.Text.Trim))
        If ds.Tables(0).Rows.Count > 0 Then
            Dim ds2 As DataSet = cls.lFnGetCleintOptIORecord(GFncSqlQuote(txtAccNo.Text.Trim))
            If ds2.Tables(0).Rows.Count = 0 Then
                Me.txtName.Text = cls.lfncCheckClientCode(GFncSqlQuote(txtAccNo.Text.Trim)).Tables(0).Rows(0).Item(0).ToString().Trim()
            Else
                GSubShowInfo(GFncGetSysMsg(62))
                Me.txtAccNo.Focus()
            End If
        Else
            If Me.txtAccNo.Text <> "" Then
                GSubShowWarn(GFncGetSysMsg(123))
                Me.txtAccNo.Focus()
            End If
        End If
    End Sub

    Private Sub lFnEnableEdit(ByVal bool As Boolean)
        'txtUpdateBy.Text = GStrloginID
        txtAccNo.Enabled = False
        txtName.Enabled = False
        dtpOptIODate.Enabled = bool
        txtRemark.Enabled = bool
        btnAdd.Enabled = Not bool
        btnSave.Enabled = bool
        btnDelete.Enabled = False
        rbnOptIn.Enabled = bool
        rbnOptOut.Enabled = bool
        rbnYes.Enabled = bool
        rbnNo.Enabled = bool

        btnEdit.Enabled = False

        If type = "Add" Then
            txtAccNo.Enabled = True
            btnEdit.Enabled = False
        End If

        If type = "AddBySelect" Then
            btnEdit.Enabled = False
        End If

        'If type = "Edit" Then
        '    If canBeDeleted Then
        '        btnDelete.Enabled = True
        '    End If
        'End If

    End Sub

    Private Sub FrmClientOptInOut_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Resize
        If Me.Width >= 764 Then
            tcClientOptIOMain.Width = Me.Width - 40
            dgvClientMaster.Width = Me.Width - 75
        End If
        If Me.Height >= 358 Then
            tcClientOptIOMain.Height = Me.Height - 120
            dgvClientMaster.Height = Me.Height - 200
        End If
    End Sub

    Private Sub FrmClientOptInOut_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Shown
        lFnEnableEdit(False)
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvClientMaster.CellContentDoubleClick
        tcClientOptIOMain.SelectedIndex = 1
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        tcClientOptIOMain.SelectedIndex = 1
        rbnOptIn.Checked = False
        rbnOptOut.Checked = False
        rbnYes.Checked = False
        rbnNo.Checked = False
        type = "Add"
        txtAccNo.Text = ""
        txtName.Text = ""
        txtRemark.Text = ""
        txtUpdateBy.Text = ""

        lFnEnableEdit(True)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If tcClientOptIOMain.SelectedIndex = 1 Then
            type = ""
            lFnEnableEdit(False)
            tcClientOptIOMain.SelectedIndex = 0
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        If canBeDeleted Then
            type = "Edit"
        Else
            type = "AddBySelect"
        End If
        lFnEnableEdit(True)
        btnEdit.Enabled = False

    End Sub

    Private Sub tcselecting(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tcClientOptIOMain.SelectedIndexChanged

        If tcClientOptIOMain.SelectedIndex <> 1 Then
            canBeDeleted = False
            'btnDelete.Enabled = canBeDeleted
            lFnEnableEdit(False)
        End If

        If tcClientOptIOMain.SelectedIndex = 1 Then
            rbnOptIn.Checked = False
            rbnOptOut.Checked = False
            rbnYes.Checked = False
            rbnNo.Checked = False
            txtRemark.Text = ""
            If dgvClientMaster.Rows.Count > 0 Then
                btnEdit.Enabled = True
                txtAccNo.Text = dgvClientMaster.Item(0, dgvClientMaster.SelectedRows(0).Index).Value
                txtName.Text = dgvClientMaster.Item(1, dgvClientMaster.SelectedRows(0).Index).Value


                Dim ds As DataSet = cls.lFnGetCleintOptIORecord(GFncSqlQuote(txtAccNo.Text.Trim()))

                If ds.Tables(0).Rows.Count > 0 Then
                    canBeDeleted = True

                    dtpOptIODate.Value = ds.Tables(0).Rows(0).Item(1)
                    If ds.Tables(0).Rows(0).Item(2).ToString.Trim = "I" Then
                        rbnOptIn.Checked = True
                    ElseIf ds.Tables(0).Rows(0).Item(2).ToString.Trim = "O" Then
                        rbnOptOut.Checked = True
                    End If

                    If ds.Tables(0).Rows(0).Item(3).ToString.Trim = "Y" Then
                        rbnYes.Checked = True
                    ElseIf ds.Tables(0).Rows(0).Item(3).ToString.Trim = "N" Then
                        rbnNo.Checked = True
                    End If
                    txtRemark.Text = ds.Tables(0).Rows(0).Item(4).ToString.Trim()
                    txtUpdateBy.Text = ds.Tables(0).Rows(0).Item(5).ToString.Trim()
                Else
                    canBeDeleted = False

                End If

                ' btnDelete.Enabled = canBeDeleted


            End If

        End If

        btnDelete.Enabled = canBeDeleted



    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim MyTrans As SqlTransaction = Nothing
        Dim dtIsolatedPrefix As New DataTable()
        Dim dtMatchedAccList As New DataTable()
        Dim updatedBy As String = ""

        If txtAccNo.Text <> "" Then
            If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
                Try
                    Dim opt_IO As Char
                    Dim opt_outOnOpening As Char
                    Dim opt_IOinDataGrid As String

                    If rbnOptIn.Checked Then
                        opt_IO = "I"
                        opt_IOinDataGrid = "Opt-in"
                    ElseIf rbnOptOut.Checked Then
                        opt_IO = "O"
                        opt_IOinDataGrid = "Opt-out"
                    Else
                        GSubShowInfo(GFncGetSysMsg(121))
                        Return
                    End If

                    If rbnYes.Checked Then
                        opt_outOnOpening = "Y"
                    ElseIf rbnNo.Checked Then
                        opt_outOnOpening = "N"
                    Else
                        GSubShowInfo(GFncGetSysMsg(122))
                        Return
                    End If

                    Dim strAccPrefixFilter As String = cls.getAccPrefixFilter("acc_no")

                    Dim isLinkedPrefix As Boolean = True
                    dtIsolatedPrefix = cls.getIsolatedPrefix(MyTrans)
                    If dtIsolatedPrefix.Rows.Count > 0 Then
                        For Each row As DataRow In dtIsolatedPrefix.Rows
                            isLinkedPrefix = Not Me.txtAccNo.Text.Trim.StartsWith(row.Item("IsolatedPrefix"))
                            If (Not isLinkedPrefix) Then Exit For
                        Next
                    End If

                    If (isLinkedPrefix) Then
                        dtMatchedAccList = cls.lFncGetAddLinkedAccList(Me.txtAccNo.Text.Trim, strAccPrefixFilter)
                    Else
                        dtMatchedAccList = cls.lFncGetAddIsolatedAccList(Me.txtAccNo.Text.Trim)
                    End If

                    MyTrans = GSCnSqlConn.BeginTransaction
                    If type = "Add" Then
                        cls.lFnWriteLog(MyTrans, Me.txtAccNo.Text, "A", lfncGetLog(type, MyTrans))
                        updatedBy = GStrloginID
                    ElseIf type = "AddBySelect" Then
                        cls.lFnWriteLog(MyTrans, Me.txtAccNo.Text, "A", lfncGetLog(type, MyTrans))
                        updatedBy = txtUpdateBy.Text.Trim
                    ElseIf type = "Edit" Then
                        cls.lFnWriteLog(MyTrans, Me.txtAccNo.Text, "M", lfncGetLog(type, MyTrans))
                        updatedBy = txtUpdateBy.Text.Trim
                    End If

                    For Each row As DataRow In dtMatchedAccList.Rows
                        cls.lFnAddClientMaster(MyTrans, row.Item("acc_no").ToString().Trim, dtpOptIODate.Value, opt_IO, opt_outOnOpening, GFncSqlQuote(txtRemark.Text.Trim), updatedBy)
                    Next

                    If (isLinkedPrefix) Then
                        cls.lFnEditLinkedAcc(MyTrans, Me.txtAccNo.Text.Trim, dtpOptIODate.Value, opt_IO, opt_outOnOpening, GFncSqlQuote(txtRemark.Text.Trim), updatedBy, strAccPrefixFilter)
                    Else
                        cls.lFnEditIsolatedAcc(MyTrans, Me.txtAccNo.Text.Trim, dtpOptIODate.Value, opt_IO, opt_outOnOpening, GFncSqlQuote(txtRemark.Text.Trim), updatedBy)
                    End If

                        txtSearchAccNo.Text = txtAccNo.Text.Trim
                        txtSearchAccName.Text = ""

                    MyTrans.Commit()
                    MyTrans = Nothing
                    GSubShowInfo(GFncGetSysMsg(8))

                Catch ex As Exception

                    If GSCnSqlConn.State <> ConnectionState.Closed Then
                        If (MyTrans IsNot Nothing) Then
                            MyTrans.Rollback()
                        End If
                        GSubWriteErrLog(ex.Message)
                    End If
                End Try

                Me.dgvClientMaster.DataSource = cls.lFnSearchClientMaster(txtSearchAccNo.Text.Trim, "")
                Me.dgvClientMaster.DataMember = "cltMaster"
                type = ""
                lFnEnableEdit(False)
                Me.tcClientOptIOMain.SelectedIndex = 0

            End If
        Else
            GSubShowWarn(GFncGetSysMsg(124))
            Me.txtAccNo.Focus()
        End If

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        type = "Del"
        Dim MyTrans As SqlTransaction = Nothing
        If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
            Try
                MyTrans = GSCnSqlConn.BeginTransaction
                cls.lFnWriteLog(MyTrans, Me.txtAccNo.Text, "D", lfncGetLog(type, MyTrans))
                cls.lFnDelClientMaster(MyTrans, dgvClientMaster.Item(0, (dgvClientMaster.SelectedRows(0).Index)).Value.ToString.Trim)
                txtSearchAccNo.Text = txtAccNo.Text.Trim
                txtSearchAccName.Text = ""
                'Dim ds As DataSet = dgvClientMaster.DataSource
                'Dim dt As DataTable = ds.Tables(0)
                'dt.Rows(dgvClientMaster.SelectedRows(0).Index)("opt_in_out_date") = DBNull.Value
                'dt.Rows(dgvClientMaster.SelectedRows(0).Index)("opt_in_out") = ""
                'dt.AcceptChanges()

                MyTrans.Commit()
                MyTrans = Nothing

                GSubShowInfo(GFncGetSysMsg(8))
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    'GSubWriteErrLog(ex.Message)
                End If
            End Try

            Me.dgvClientMaster.DataSource = cls.lFnSearchClientMaster(txtSearchAccNo.Text.Trim, "")
            Me.dgvClientMaster.DataMember = "cltMaster"
            type = ""
            lFnEnableEdit(False)
            Me.tcClientOptIOMain.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Me.dgvClientMaster.DataSource = cls.lFnSearchClientMaster(txtSearchAccNo.Text.Trim, txtSearchAccName.Text.Trim)
                Me.dgvClientMaster.DataMember = "cltMaster"
    End Sub


    Private Sub checkIfInAddEditMode(ByVal sender As System.Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tcClientOptIOMain.Selecting
        If (type = "Add" Or type = "Edit" Or type = "AddBySelect") And tcClientOptIOMain.SelectedIndex <> 1 Then
            e.Cancel = True
        End If
    End Sub

    Public Function lfncGetLog(ByVal type As String, ByVal mytrans As SqlTransaction) As String
        Dim Log As String = ""
        Dim strOptInOut As String = ""
        Dim strOptOutOpening As String = ""
        If type = "Add" Then
            If Me.txtAccNo.Text.Length > 0 Then
                Log += GfncOneFieldLog("acc_no", Me.txtAccNo.Text)
            End If
            Log += GfncOneFieldLog("opt_in_out_date", Me.dtpOptIODate.Value)
            If Me.rbnOptIn.Checked = True Then
                Log += GfncOneFieldLog("opt_in_out", "Y")
            Else
                Log += GfncOneFieldLog("opt_in_out", "N")
            End If
            If Me.rbnYes.Checked = True Then
                Log += GfncOneFieldLog("opt_out_opening", "Y")
            Else
                Log += GfncOneFieldLog("opt_out_opening", "N")
            End If
            If Me.txtRemark.Text.Length > 0 Then
                Log += GfncOneFieldLog("remark", Me.txtRemark.Text)
            End If
        ElseIf type = "Edit" Then
            Dim ds As DataSet = cls.lFnGetCleintOptIORecord(mytrans, GFncSqlQuote(txtAccNo.Text.Trim()))
            If Me.dtpOptIODate.Value <> GFncNoNullString(ds.Tables(0).Rows(0).Item("opt_in_out_date")) Then
                Log += GfncOneFieldLog("opt_in_out_date", GFncNoNullString(ds.Tables(0).Rows(0).Item("opt_in_out_date")), Me.dtpOptIODate.Value)
            End If
            If Me.rbnOptIn.Checked = True Then
                strOptInOut = "I"
            Else
                strOptInOut = "O"
            End If
            If strOptInOut <> GFncNoNullString(ds.Tables(0).Rows(0).Item("opt_in_out")) Then
                Log += GfncOneFieldLog("opt_in_out", GFncNoNullString(ds.Tables(0).Rows(0).Item("opt_in_out")), strOptInOut)
            End If
            If Me.rbnYes.Checked = True Then
                strOptOutOpening = "Y"
            Else
                strOptOutOpening = "N"
            End If
            If strOptInOut <> GFncNoNullString(ds.Tables(0).Rows(0).Item("opt_out_opening")) Then
                Log += GfncOneFieldLog("opt_out_opening", GFncNoNullString(ds.Tables(0).Rows(0).Item("opt_out_opening")), strOptOutOpening)
            End If
            If Trim(Me.txtRemark.Text) <> GFncNoNullString(ds.Tables(0).Rows(0).Item("remark")) Then
                Log += GfncOneFieldLog("remark", GFncNoNullString(ds.Tables(0).Rows(0).Item("remark")), Me.txtRemark.Text)
            End If
        ElseIf type = "Del" Then
            Dim ds As DataSet = cls.lFnGetCleintOptIORecord(mytrans, GFncSqlQuote(txtAccNo.Text.Trim()))
            Log += GfncOneFieldLog("acc_no", GFncNoNullString(ds.Tables(0).Rows(0).Item("acc_no")))
            Log += GfncOneFieldLog("opt_in_out", GFncNoNullString(ds.Tables(0).Rows(0).Item("opt_in_out")))
            Log += GfncOneFieldLog("opt_in_out_date", GFncNoNullString(ds.Tables(0).Rows(0).Item("opt_in_out_date")))
            Log += GfncOneFieldLog("opt_out_opening", GFncNoNullString(ds.Tables(0).Rows(0).Item("opt_out_opening")))
            Log += GfncOneFieldLog("remark", GFncNoNullString(ds.Tables(0).Rows(0).Item("remark")))
        End If

        Return Log
    End Function

End Class
