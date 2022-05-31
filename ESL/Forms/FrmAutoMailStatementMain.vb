Imports System.Data.SqlClient

Public Class FrmAutoMailStatementMain
    Dim type As String = ""
    Dim cls As New ClsAutoMailStatementMain

    Private Sub lFnLoadMailList()

        Me.dtgMail.DataSource = cls.lFnGetMailList()
        Me.dtgMail.DataMember = "mail"

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If tcMail.SelectedIndex <> 0 Then
            Enable(False)
            Me.tcMail.SelectedIndex = 0
            type = ""
        Else
            Me.Close()

        End If

    End Sub

    Private Sub Enable(ByVal bool As Boolean)
        Me.lblid.Enabled = bool
        Me.txtemail.Enabled = bool
        Me.txtattach.Enabled = bool
        Me.MyCheckBox1.Enabled = bool
        Me.MyButton1.Enabled = Not bool
        Me.btnSave.Enabled = bool
    End Sub

    Private Sub FrmAutoMailMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lFnLoadMailList()
        Enable(False)
        Me.tcMail.SelectedIndex = 0
    End Sub

    Private Sub tcMail_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcMail.SelectedIndexChanged
        If (Me.tcMail.SelectedIndex = 0) Then
            Me.lblid.Text = ""
            Me.txtemail.Text = ""
            Me.txtattach.Text = ""
            type = ""
        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        type = "Edit"
        Me.tcMail.SelectedIndex = 1
        Enable(True)
        Me.lblid.Text = Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value
        Me.txtemail.Text = Me.dtgMail.Item(1, Me.dtgMail.CurrentRow.Index).Value
        Me.txtattach.Text = Me.dtgMail.Item(2, Me.dtgMail.CurrentRow.Index).Value
        Me.MyCheckBox1.Checked = Me.dtgMail.Item(3, Me.dtgMail.CurrentRow.Index).Value
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        type = "Add"
        Me.tcMail.SelectedIndex = 1
        Enable(True)
        Me.lblid.Text = ""
        Me.txtemail.Text = ""
        Me.txtattach.Text = ""
        Me.MyCheckBox1.Checked = False


    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim MyTrans As SqlTransaction = Nothing

        If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
            Try
                MyTrans = GSCnSqlConn.BeginTransaction

                cls.lFnDeleteEmailAddr(MyTrans, Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value)
                'cls.lFnWriteLog(MyTrans, Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value, Me.dtgMail.Item("attachment", Me.dtgMail.CurrentRow.Index).Value, "D")
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
        Dim MyTrans As SqlTransaction = Nothing

        If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
            Try
                MyTrans = GSCnSqlConn.BeginTransaction

                If (Me.lblid.Text.Trim.Length = 0) Then
                    cls.lFnAddEmailAddr(MyTrans, Me.txtemail.Text.Trim, Me.txtattach.Text.Trim, Me.MyCheckBox1.Checked)
                    Dim id As String = cls.lFnGetLargestID(MyTrans)
                    cls.lFnWriteLog(MyTrans, id, "A", GfncGetLog(id, type, MyTrans))

                Else
                    cls.lFnWriteLog(MyTrans, Me.lblid.Text.Trim, "M", GfncGetLog(Me.lblid.Text.Trim, type, MyTrans))
                    cls.lFnEditEmailAddr(MyTrans, Me.lblid.Text.Trim, Me.txtemail.Text, Me.txtattach.Text, Me.MyCheckBox1.Checked)

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
            Enable(False)
            'Me.tcMail.SelectedIndex = 0
            type = ""
        End If

    End Sub

    Private Sub tcMail_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tcMail.Selecting
        If Me.btnSave.Enabled Then
            e.Cancel = True
        End If
        If Not type = "Add" Then
            Me.lblid.Text = Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value
            Me.txtemail.Text = Me.dtgMail.Item(1, Me.dtgMail.CurrentRow.Index).Value
            Me.txtattach.Text = Me.dtgMail.Item(2, Me.dtgMail.CurrentRow.Index).Value
            Me.MyCheckBox1.Checked = Me.dtgMail.Item(3, Me.dtgMail.CurrentRow.Index).Value
        End If
    End Sub

    Public Function GfncOneFieldLog(ByVal lstrTitle As String, ByVal lstrFm As String, _
         Optional ByVal lstrTo As String = Nothing) As String

        If IsNothing(lstrTo) Then
            Return "[" & lstrTitle.Trim & "]='" & lstrFm.Trim & "' "
        Else
            Return "[" & lstrTitle.Trim & "]='" & lstrFm.Trim & "' To '" & lstrTo.Trim & "' "
        End If
    End Function

    Public Function GfncGetLog(ByVal eid As String, ByVal type As String, ByVal mytrans As SqlTransaction) As String
        Dim Log As String = ""
        If type = "Add" Then
            If Me.txtemail.Text.Length > 0 Then
                Log += GfncOneFieldLog("Email", Me.txtemail.Text)
            End If
            If Me.txtattach.Text.Length > 0 Then
                Log += GfncOneFieldLog("Attachment_Path", Me.txtattach.Text)
            End If
            Log += GfncOneFieldLog("Summary", Me.MyCheckBox1.Checked)
        ElseIf type = "Edit" Then
            Dim DT As DataTable = cls.lfncGetMailByID(eid, mytrans)
            If Me.txtemail.Text <> GFncNoNullString(DT.Rows(0).Item("email")) Then
                Log += GfncOneFieldLog("Email", GFncNoNullString(DT.Rows(0).Item("email")), Me.txtemail.Text)
            End If
            If Me.txtattach.Text <> GFncNoNullString(DT.Rows(0).Item("attachment")) Then
                Log += GfncOneFieldLog("Attachment_Path", GFncNoNullString(DT.Rows(0).Item("attachment")), Me.txtattach.Text)
            End If
            If Me.MyCheckBox1.Checked <> DT.Rows(0).Item("summary") Then
                Log += GfncOneFieldLog("Summary", DT.Rows(0).Item("summary"), Me.MyCheckBox1.Checked)
            End If
        End If
        Return Log
    End Function

    Private Sub dtgMail_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dtgMail.CellContentDoubleClick
        Me.lblid.Text = Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value
        Me.txtemail.Text = Me.dtgMail.Item(1, Me.dtgMail.CurrentRow.Index).Value
        Me.txtattach.Text = Me.dtgMail.Item(2, Me.dtgMail.CurrentRow.Index).Value
        Me.MyCheckBox1.Checked = Me.dtgMail.Item(3, Me.dtgMail.CurrentRow.Index).Value
        Me.tcMail.SelectedIndex = 1
    End Sub

    Private Sub MyButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton1.Click
        type = "Edit"
        Me.tcMail.SelectedIndex = 1
        Enable(True)
    End Sub
End Class
