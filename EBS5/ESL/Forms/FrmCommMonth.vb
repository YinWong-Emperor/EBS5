Imports System.Data.SqlClient
Public Class FrmCommMonth

    Dim oldMonth As String = ""

    Private Sub FrmCommMonth_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        Dim lintCnt As Integer
        For lintCnt = 1 To 12
            Me.cboMonth.Items.Add(lintCnt)
        Next
        For lintCnt = Now.Year - 10 To Now.Year + 10
            Me.cboYear.Items.Add(lintCnt)
        Next
        lsubGetMonth()
        Me.btnSave.Visible = True
        lsubEnable(False)
    End Sub

    Private Sub lsubGetMonth()
        Dim lstrMonth As String = GfncGetMonth()
        Me.cboYear.Text = Val(lstrMonth.Substring(0, 4))
        Me.cboMonth.Text = Val(lstrMonth.Substring(4, 2))
    End Sub

    Private Sub lsubEnable(ByVal lbln As Boolean)
        Me.cboMonth.Enabled = lbln
        Me.cboYear.Enabled = lbln
        Me.btnEdit.Enabled = Not lbln
        Me.btnSave.Enabled = lbln
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled Then
            lsubGetMonth()
            Me.lsubEnable(False)
            oldMonth = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If GFncCheckCommStatus(Me.Name.Trim & "." & sender.name.ToString.Trim) Then
            Return
        End If
        lsubEnable(True)
        Me.cboYear.Focus()
        oldMonth = Format(Val(Me.cboYear.Text), "0000") & Format(Val(Me.cboMonth.Text), "00")
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If GFncCheckCommStatus() Then
            Return
        End If
        Dim lstrMonth As String = Format(Val(Me.cboYear.Text), "0000") & Format(Val(Me.cboMonth.Text), "00")
        Dim lstnTrans As SqlTransaction = Nothing
        Try
            lstnTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, lstnTrans, " delete from misc_master where misc_type = 'COMMMONTH' ", 0)
            If GFncRunSQL(GSCnSqlConn, lstnTrans, " insert into misc_master (misc_type, misc_code, misc_desc) values ('COMMMONTH', '" & lstrMonth & "','') ", 0) <= 0 Then
                lstnTrans.Rollback()
                GSubShowInfo(GFncGetSysMsg(9))
                Me.cboYear.Focus()
            End If

            Dim logStr As String = ""
            If oldMonth.Trim <> lstrMonth.Trim Then
                logStr = GfncOneFieldLog("Commission Month", oldMonth, lstrMonth)
                If Not GFncFillLog(GStrloginID, "M", GDteTradeDate, "COMMMONTH", "", "", 0, lstrMonth, logStr, lstnTrans) Then
                    lstnTrans.Rollback()
                    GSubShowInfo(GFncGetSysMsg(9))
                    Me.cboYear.Focus()
                End If
            End If
            lstnTrans.Commit()
            lsubEnable(False)
            GSubShowInfo(GFncGetSysMsg(8))
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (lstnTrans IsNot Nothing) Then
                    lstnTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Me.btnEdit.Enabled = True
        oldMonth = ""
    End Sub
End Class
