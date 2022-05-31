Imports System.Data.SqlClient

Public Class FrmCIESAlertMaster
    Dim type As String = ""
    Dim cls As clsCIESAlertMaster = New clsCIESAlertMaster

    'Private Sub lsubEnableForm(ByVal bEnable As Boolean)
    '    Me.btnCancel.Visible = bEnable
    '    Me.btnSave.Visible = bEnable
    '    Me.cboAECode.Enabled = bEnable
    '    Me.cboClientCodeStart.Enabled = bEnable
    '    Me.cboClientCodeEnd.Enabled = bEnable
    'End Sub

    'Private Function getAECode() As DataTable
    '    Dim strSQL As String = "select distinct(RUN_CODE) from STCLTMASTER order by RUN_CODE"

    '    Dim dtSet As DataSet = GFncRtnDS(GSCnLiqConn, strSQL, 0)

    '    Dim dt As DataTable = Nothing

    '    If dtSet IsNot Nothing Then
    '        dt = dtSet.Tables(0)
    '    End If

    '    Return dt

    'End Function

    Private Sub insertNullRow(ByRef dt As DataTable, ByVal pos As Integer)
        Dim row As DataRow = dt.NewRow
        dt.Rows.InsertAt(row, pos)
    End Sub

    Private Sub lFnLoadMailList()
        Dim ldts As DataTable = cls.lFnGetMailList().Tables(0)

        For Each row As DataRow In ldts.Rows
            row.Item("alertDate") = row.Item("alertDate").ToString.Insert(0, "T+")
            'row.Item("alertDate") = row.Item("alertDate").ToString.Replace(",", ",T+")
        Next

        Me.dtgMail.DataSource = ldts
        'Me.dtgMail.DataMember = "mail"

    End Sub

    Private Sub lsubEnableTabPage(ByVal bEnable As Boolean)
        Me.lblid.Enabled = bEnable
        Me.cboClientCodeStart.Enabled = bEnable
        Me.cboClientCodeEnd.Enabled = bEnable
        Me.txtaeno.Enabled = bEnable
        Me.txtemail_to.Enabled = bEnable
        Me.txtemail_cc.Enabled = bEnable
        For i As Integer = 0 To Me.dgvAlertDate.ColumnCount - 1
            Me.dgvAlertDate.Columns(i).ReadOnly = Not bEnable
        Next
    End Sub

    Private Sub tcMail_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcMail.SelectedIndexChanged
        If (Me.tcMail.SelectedIndex = 0) Then
            Me.lblid.Text = ""
            Me.cboClientCodeStart.Text = ""
            Me.cboClientCodeEnd.Text = ""
            Me.txtaeno.Text = ""
            Me.txtemail_to.Text = ""
            Me.txtemail_cc.Text = ""
            type = ""

            For i As Integer = 0 To Me.dgvAlertDate.RowCount - 1
                If Me.dgvAlertDate.Rows(0).IsNewRow = False Then
                    Me.dgvAlertDate.Rows.RemoveAt(0)
                End If
            Next
            Me.dgvAlertDate.ClearSelection()

        Else
            If type = "" Then
                showRecord()
                lsubEnableTabPage(False)
            End If
            Me.cboClientCodeStart.Focus()

            End If
    End Sub

    Private Sub FrmCIESAlertMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lFnLoadMailList()

        Me.btnSave.Enabled = False

        Dim cCodeDt_from As DataTable = cls.getClientCode()

        insertNullRow(cCodeDt_from, 0)

        Dim cCodeDt_to As DataTable = cCodeDt_from.Copy

        Me.cboClientCodeStart.DataSource = cCodeDt_from
        Me.cboClientCodeEnd.DataSource = cCodeDt_to

        'Dim cCodeDt_from As DataTable = GDtClientCode

        'insertNullRow(cCodeDt_from, 0)

        'Dim cCodeDt_to As DataTable = cCodeDt_from.Copy

        'Me.cboClientCodeStart.DataSource = cCodeDt_from
        'Me.cboClientCodeEnd.DataSource = cCodeDt_to

        Me.cboClientCodeStart.ValueMember = "CLT_CODE"
        Me.cboClientCodeEnd.ValueMember = "CLT_CODE"

        DirectCast(Me.dgvAlertDate.Columns("alertDate"), DataGridViewComboBoxColumn).Items.Add("")
        For i As Integer = 1 To 14
            DirectCast(Me.dgvAlertDate.Columns("alertDate"), DataGridViewComboBoxColumn).Items.Add("Trade date + " & i)
        Next

        Me.tcMail.SelectedIndex = 1
        Me.tcMail.SelectedIndex = 0

    End Sub

    Private Sub showRecord()

        Dim alertDate As String = Me.dtgMail.Item(6, Me.dtgMail.CurrentRow.Index).Value
        alertDate = alertDate.Replace("T+", "")
        alertDate = alertDate.Replace(" ", "")
        Dim alertDateArr() As String = alertDate.Split(",")

        Me.lblid.Text = Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value
        Me.cboClientCodeStart.Text = Me.dtgMail.Item(1, Me.dtgMail.CurrentRow.Index).Value
        Me.cboClientCodeEnd.Text = Me.dtgMail.Item(2, Me.dtgMail.CurrentRow.Index).Value
        Me.txtaeno.Text = Me.dtgMail.Item(3, Me.dtgMail.CurrentRow.Index).Value
        Me.txtemail_to.Text = Me.dtgMail.Item(4, Me.dtgMail.CurrentRow.Index).Value
        Me.txtemail_cc.Text = Me.dtgMail.Item(5, Me.dtgMail.CurrentRow.Index).Value

        For i As Integer = 0 To alertDateArr.Length - 1
            Me.dgvAlertDate.Rows.Add()
            DirectCast(Me.dgvAlertDate.Rows(i).Cells("alertDate"), DataGridViewComboBoxCell).Value = "Trade date + " & alertDateArr(i)
            'Me.dgvAlertDate.Rows(i).Cells("alertDate").Value = "Trade date + " & alertDateArr(i)

        Next
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        lsubEnableTabPage(True)
        showRecord()

        type = "Edit"

        Me.tcMail.SelectedIndex = 1
        Me.btnSave.Enabled = True

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If tcMail.SelectedIndex <> 0 Then
            Me.btnSave.Enabled = False
            Me.tcMail.SelectedIndex = 0
            type = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        lsubEnableTabPage(True)
        Me.lblid.Text = ""
        Me.cboClientCodeStart.Text = ""
        Me.cboClientCodeEnd.Text = ""
        Me.txtaeno.Text = ""
        Me.txtemail_to.Text = ""
        Me.txtemail_cc.Text = ""

        type = "Add"

        Me.tcMail.SelectedIndex = 1
        Me.btnSave.Enabled = True

    End Sub

    Private Sub tcMail_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tcMail.Selecting
        If Me.btnSave.Enabled Then
            e.Cancel = True
        End If
    End Sub

    Private Function checkValid(ByVal alertDate As String) As Boolean
        If Me.cboClientCodeStart.Text = "" AndAlso Me.cboClientCodeEnd.Text = "" AndAlso Me.txtaeno.Text = "" Then
            GSubShowWarn("""Client code"" and ""AE No"" cannot be null at the same time")
            Return False
        End If

        If Me.cboClientCodeStart.Text <> "" AndAlso Me.cboClientCodeEnd.Text = "" Then
            GSubShowWarn("""Client Code To"" cannot be null")
            Return False
        End If

        If Me.cboClientCodeEnd.Text <> "" AndAlso Me.cboClientCodeStart.Text = "" Then
            GSubShowWarn("""Client Code From"" cannot be null")
            Return False
        End If

        If Me.txtemail_to.Text = "" Then
            GSubShowWarn("Email cannot be null")
            Return False
        End If

        alertDate = alertDate.Replace(" ", "")
        Dim alertDateArr() As String = alertDate.Split(",")
        For i As Integer = 0 To alertDateArr.Length - 1
            For j As Integer = 0 To alertDateArr.Length - 1
                If i = j Then
                    Continue For
                End If
                If alertDateArr(i) = alertDateArr(j) Then
                    GSubShowWarn("Duplicate alert date")
                    Return False
                End If
            Next
        Next

        If Me.cboClientCodeStart.Text <> "" AndAlso Me.cboClientCodeEnd.Text <> "" AndAlso Me.txtaeno.Text <> "" Then
            Dim dt As DataTable = New DataTable
            Dim lstrSQL As String = ""

            lstrSQL = "select * from STCLTMASTER where clt_code>='" & Me.cboClientCodeStart.Text & "' and clt_code<='" & Me.cboClientCodeEnd.Text & "' and run_code='" & Me.txtaeno.Text & "'"
            dt = GFncRtnDS(GSCnLiqConn, lstrSQL, 0).Tables(0)
            If dt.Rows.Count <= 0 Then
                GSubShowInfo("No client code under AE No")
            End If
            'Return False
        End If

        Return True
    End Function

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim MyTrans As SqlTransaction = Nothing

        If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
            Try
                MyTrans = GSCnSqlConn.BeginTransaction

                cls.lFnDeleteEmailAddr(MyTrans, Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value)
                'cls.lFnWriteLog(MyTrans, Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value, Me.dtgMail.Item("aeno", Me.dtgMail.CurrentRow.Index).Value, "D", "")
                MyTrans.Commit()
                MyTrans = Nothing

                GSubShowInfo(GFncGetSysMsg(8))
                lFnLoadMailList()
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try
        End If

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim alertDate As String = ""


        For i As Integer = 0 To Me.dgvAlertDate.RowCount - 1
            If Me.dgvAlertDate.Rows(i).IsNewRow = False Then
                alertDate += Me.dgvAlertDate.Rows(i).Cells("alertDate").Value.ToString.Replace("Trade date + ", "")
                alertDate += ","
            End If
        Next

        alertDate = alertDate.Substring(0, alertDate.Length - 1)

        If checkValid(alertDate) = False Then
            Return
        End If


        Dim MyTrans As SqlTransaction = Nothing

        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            Try
                MyTrans = GSCnSqlConn.BeginTransaction

                If (Me.lblid.Text.Trim.Length = 0) Then
                    cls.lFnAddEmailAddr(MyTrans, Me.cboClientCodeStart.Text.Trim, Me.cboClientCodeEnd.Text.Trim, Me.txtaeno.Text.Trim, Me.txtemail_to.Text.Replace(" ", "").Trim, _
                                        Me.txtemail_cc.Text.Trim, alertDate)
                    'Dim id As String = cls.lFnGetLargestID(MyTrans)
                    'cls.lFnWriteLog(MyTrans, id, Me.txtaeno.Text, "A", GfncGetLog(id, type, MyTrans))

                Else
                    'cls.lFnWriteLog(MyTrans, Me.lblid.Text.Trim, Me.txtaeno.Text, "M", GfncGetLog(Me.lblid.Text.Trim, type, MyTrans))
                    cls.lFnEditEmailAddr(MyTrans, Me.lblid.Text.Trim, Me.cboClientCodeStart.Text.Trim, Me.cboClientCodeEnd.Text.Trim, Me.txtaeno.Text.Trim, _
                                         Me.txtemail_to.Text.Replace(" ", "").Trim, Me.txtemail_cc.Text, alertDate)

                End If

                MyTrans.Commit()
                MyTrans = Nothing
                GSubShowInfo(GFncGetSysMsg(8))
                lFnLoadMailList()

            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try

            lFnLoadMailList()
            Me.btnSave.Enabled = False
            Me.tcMail.SelectedIndex = 0
            type = ""

        End If

    End Sub

End Class