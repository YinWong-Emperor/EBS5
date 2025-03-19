Imports System.Data.SqlClient
Public Class frmCommApprove

    Dim cls As New clsCommApprove

    Private Sub frmCommApprove_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setProcessing(False)
        setBtn(False)
        setBtn(True)
        Me.txtMonth.Text = cls.FncGetMonth()
        Me.txtPosting.Text = cls.FncGetLastPostingTime(Me.txtMonth.Text.Trim)
        btnSearch_Click(Nothing, System.EventArgs.Empty)
        CheckCommMonth()
    End Sub

    Private Sub CheckStatus()
        If GFncCheckStatus() Then
            Me.txtStatus.Text = "Locked"
        Else
            Me.txtStatus.Text = "Unlocked"
        End If
    End Sub

    Private Sub setBtn(ByVal flag As Boolean)
        Me.btnLock.Enabled = flag
        Me.btnSave.Enabled = Not flag
        Me.btnCancel.Enabled = True
        Me.btnSearch.Enabled = flag
    End Sub

    Private Sub setProcessing(ByVal flag As Boolean)
        Me.pbarPrint.Visible = flag
        Me.lblProcess.Visible = flag
    End Sub

    Private Sub btnLock_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLock.Click
        SearchLog(True)
        If Not cls.FncLockFnc(Me.txtMonth.Text.Trim, Me.txtPosting.Text.Trim, Me.txtMonth.Text.Trim) Then
            MessageBox.Show("Commission functions can not be locked!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If
        CheckStatus()
        setBtn(False)
        Me.btnCancel.Text = "Unlock"
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        cls.FncUnlockFnc(Me.txtMonth.Text.Trim)
        CheckStatus()
        If Me.btnSave.Enabled Then
            Me.btnCancel.Text = "Close"
            setBtn(True)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub dgvLogs_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dgvLogs.SelectionChanged
        Try
            Dim logstr As String = GFncNoNullString(Me.dgvLogs.CurrentRow.Cells("d_log").Value).Trim
            Me.txtUser.Text = GFncNoNullString(Me.dgvLogs.CurrentRow.Cells("d_user").Value).Trim
            Me.txtLogDate.Text = Format(GFncNoNullDate(Me.dgvLogs.CurrentRow.Cells("d_date").Value), "dd/MM/yyyy HH:mm:ss")
            Me.txtTradeDate.Text = IIf(IsDBNull(Me.dgvLogs.CurrentRow.Cells("d_o_tdate").Value), "", _
                                        Format(GFncNoNullDate(Me.dgvLogs.CurrentRow.Cells("d_o_tdate").Value), "dd/MM/yyyy"))
            Me.txtAction.Text = GFncNoNullString(Me.dgvLogs.CurrentRow.Cells("d_action").Value).Trim
            Me.txtAE.Text = GFncNoNullString(Me.dgvLogs.CurrentRow.Cells("d_ae").Value).Trim
            Me.txtAccount.Text = GFncNoNullString(Me.dgvLogs.CurrentRow.Cells("d_ac").Value).Trim
            Me.txtCommMonth.Text = GFncNoNullString(Me.dgvLogs.CurrentRow.Cells("d_txmonth").Value).Trim
            Me.txtOID.Text = IIf(IsDBNull(Me.dgvLogs.CurrentRow.Cells("d_oid").Value), "", _
                                GFncNoNullString(Me.dgvLogs.CurrentRow.Cells("d_oid").Value).Trim)
            Me.txtFunction.Text = GFncNoNullString(Me.dgvLogs.CurrentRow.Cells("misc_desc").Value).Trim
            logstr = logstr.Replace("[", vbCrLf & "[")
            If logstr.IndexOf("[") <> -1 Then
                logstr = logstr.Substring(logstr.IndexOf("["))
            End If
            Me.txtLog.Text = logstr
        Catch ex As Exception
            clearDetails()
        End Try
    End Sub

    Private Sub clearDetails()
        Me.txtUser.Text = ""
        Me.txtLogDate.Text = ""
        Me.txtTradeDate.Text = ""
        Me.txtAction.Text = ""
        Me.txtAE.Text = ""
        Me.txtAccount.Text = ""
        Me.txtCommMonth.Text = ""
        Me.txtOID.Text = ""
        Me.txtFunction.Text = ""
        Me.txtLog.Text = ""
        Me.LbRecords.Text = ""
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim op = MessageBox.Show("Confirm to approve all the logs?", "", MessageBoxButtons.YesNo)
        If op = Windows.Forms.DialogResult.No Then
            Return
        End If
        setBtn(True)
        Me.btnLock.Enabled = False
        Me.btnCancel.Enabled = False
        setProcessing(True)
        Application.DoEvents()

        Dim dt As DataTable = Nothing
        Dim myTrans As SqlTransaction = Nothing
        Try
            myTrans = GSCnSqlConn.BeginTransaction
            If Not cls.FncDeleteTable(myTrans, Me.txtMonth.Text.Trim, Me.txtPosting.Text.Trim, dt) Then
                myTrans.Rollback()
                MessageBox.Show("Delete records from tables falied!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If Not cls.FncInsertData(myTrans, dt) Then
                myTrans.Rollback()
                MessageBox.Show("Insert records into tables falied!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            If Not cls.FncUpdateLPT(myTrans, Me.txtMonth.Text.Trim) Then
                myTrans.Rollback()
                MessageBox.Show("Update last posting time failed!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            cls.FncUnlockFnc(Me.txtMonth.Text.Trim, myTrans)
            myTrans.Commit()
            MessageBox.Show("Approved successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Me.btnCancel.Text = "Close"
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                myTrans.Rollback()
            End If
            GSubWriteErrLog("ApproveCommission: " & ex.Message)
        Finally
            setProcessing(False)
            setBtn(True)
        End Try
        CheckStatus()
        Me.txtMonth.Text = cls.FncGetMonth()
        Me.txtPosting.Text = cls.FncGetLastPostingTime(Me.txtMonth.Text.Trim)
        CheckCommMonth()
        SearchLog(False)
    End Sub

    Private Sub CheckCommMonth()
        If cls.FncCheckCommMonth(Me.txtMonth.Text.Trim, Me.txtPosting.Text.Trim) Then
            Me.lbMonth.Text = "Commission Month has been changed!"
            Me.lbMonth.Visible = True
        Else
            Me.lbMonth.Text = ""
            Me.lbMonth.Visible = False
        End If
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        SearchLog(True)
    End Sub

    Private Sub SearchLog(ByVal flag As Boolean)
        CheckStatus()
        Dim dt As DataTable = cls.FncGetLogs(Me.txtMonth.Text.Trim, Me.txtPosting.Text.Trim)
        If dt.Rows.Count <= 0 Then
            If flag Then
                MessageBox.Show("No log is available!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.btnLock.Enabled = False
            Me.btnPrint.Enabled = False
        End If
        Me.dgvLogs.DataSource = dt
        dgvLogs_SelectionChanged(Nothing, System.EventArgs.Empty)
        If dt.Rows.Count > 0 Then
            Me.LbRecords.Text = "Total Logs: " & Me.dgvLogs.Rows.Count
            Me.btnLock.Enabled = True
            Me.btnPrint.Enabled = True
        Else
            Me.LbRecords.Text = ""
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim dt As DataTable = cls.FncGetLogs(Me.txtMonth.Text.Trim, Me.txtPosting.Text.Trim)
        dt.Columns.Remove("d_type")
        dt.Columns("misc_desc").ColumnName = "d_type"
        Dim rpt As New rptCommLog
        rpt.SetDataSource(dt)
        rpt.SetParameterValue("user", GStrloginID)
        rpt.SetParameterValue("condition", "")
        rpt.SetParameterValue("status", "[Not Approved]")
        Dim frm As New FrmRptDisplay
        frm.GSubDisplayRpt(rpt)
    End Sub
End Class
