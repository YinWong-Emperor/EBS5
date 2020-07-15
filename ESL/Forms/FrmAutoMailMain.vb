Imports System.Data.SqlClient

Public Class FrmAutoMailMain
    Dim type As String = ""
    Dim cls As New ClsAutoMailMain

    Private Sub lFnLoadMailList()

        Me.dtgMail.DataSource = cls.lFnGetMailList()
        Me.dtgMail.DataMember = "mail"

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

    Private Sub FrmAutoMailMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lFnLoadMailList()
        Me.btnSave.Enabled = False
    End Sub

    Private Sub tcMail_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcMail.SelectedIndexChanged
        If (Me.tcMail.SelectedIndex = 0) Then
            Me.lblid.Text = ""
            Me.txt_brh_name.Text = ""
            Me.txt_brh_mgr.Text = ""
            Me.txtaeno.Text = ""
            Me.txtemail.Text = ""
            Me.txtattach.Text = ""
            type = ""
        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Me.lblid.Text = Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value
        Me.txt_brh_name.Text = Me.dtgMail.Item(1, Me.dtgMail.CurrentRow.Index).Value
        Me.txt_brh_mgr.Text = Me.dtgMail.Item(2, Me.dtgMail.CurrentRow.Index).Value
        Me.txtaeno.Text = Me.dtgMail.Item(3, Me.dtgMail.CurrentRow.Index).Value
        Me.txtemail.Text = Me.dtgMail.Item(4, Me.dtgMail.CurrentRow.Index).Value
        Me.txtattach.Text = Me.dtgMail.Item(5, Me.dtgMail.CurrentRow.Index).Value
        Me.tcMail.SelectedIndex = 1
        Me.btnSave.Enabled = True
        type = "Edit"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        Me.lblid.Text = ""
        Me.txt_brh_name.Text = ""
        Me.txt_brh_mgr.Text = ""
        Me.txtaeno.Text = ""
        Me.txtemail.Text = ""
        Me.txtattach.Text = ""
        Me.tcMail.SelectedIndex = 1
        Me.btnSave.Enabled = True
        type = "Add"
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click

        Dim MyTrans As SqlTransaction = Nothing

        If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
            Try
                MyTrans = GSCnSqlConn.BeginTransaction

                cls.lFnDeleteEmailAddr(MyTrans, Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value)
                cls.lFnWriteLog(MyTrans, Me.dtgMail.Item(0, Me.dtgMail.CurrentRow.Index).Value, Me.dtgMail.Item("aeno", Me.dtgMail.CurrentRow.Index).Value, "D", "")
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
                    cls.lFnAddEmailAddr(MyTrans, Me.txt_brh_name.Text.Trim, Me.txt_brh_mgr.Text.Trim, Me.txtaeno.Text.Trim, Me.txtemail.Text.Trim, _
                                        Me.txtattach.Text.Trim)
                    Dim id As String = cls.lFnGetLargestID(MyTrans)
                    cls.lFnWriteLog(MyTrans, id, Me.txtaeno.Text, "A", GfncGetLog(id, type, MyTrans))

                Else
                    cls.lFnWriteLog(MyTrans, Me.lblid.Text.Trim, Me.txtaeno.Text, "M", GfncGetLog(Me.lblid.Text.Trim, type, MyTrans))
                    cls.lFnEditEmailAddr(MyTrans, Me.lblid.Text.Trim, Me.txt_brh_name.Text.Trim, Me.txt_brh_mgr.Text.Trim, Me.txtaeno.Text.Trim, _
                                         Me.txtemail.Text, Me.txtattach.Text)

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

    Private Sub tcMail_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles tcMail.Selecting
        If Me.btnSave.Enabled Then
            e.Cancel = True
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
            If Me.txt_brh_name.Text.Length > 0 Then
                Log += GfncOneFieldLog("Branch_Name", Me.txt_brh_name.Text)
            End If
            If Me.txt_brh_mgr.Text.Length > 0 Then
                Log += GfncOneFieldLog("Branch_Manager", Me.txt_brh_mgr.Text)
            End If
            If Me.txtemail.Text.Length > 0 Then
                Log += GfncOneFieldLog("Email", Me.txtemail.Text)
            End If
            If Me.txtattach.Text.Length > 0 Then
                Log += GfncOneFieldLog("Attachment_Path", Me.txtattach.Text)
            End If
        ElseIf type = "Edit" Then
            Dim DT As DataTable = cls.lfncGetMailByID(eid, mytrans)

            If Me.txt_brh_name.Text <> GFncNoNullString(DT.Rows(0).Item("branch_name")) Then
                Log += GfncOneFieldLog("Branch_Name", GFncNoNullString(DT.Rows(0).Item("branch_name")), Me.txt_brh_name.Text)
            End If
            If Me.txt_brh_mgr.Text <> GFncNoNullString(DT.Rows(0).Item("branch_manager")) Then
                Log += GfncOneFieldLog("Branch_Manager", GFncNoNullString(DT.Rows(0).Item("branch_manager")), Me.txt_brh_mgr.Text)
            End If
            If Me.txtaeno.Text <> GFncNoNullString(DT.Rows(0).Item("aeno")) Then
                Log += GfncOneFieldLog("Aeno", GFncNoNullString(DT.Rows(0).Item("aeno")), Me.txtaeno.Text)
            End If
            If Me.txtemail.Text <> GFncNoNullString(DT.Rows(0).Item("email")) Then
                Log += GfncOneFieldLog("Email", GFncNoNullString(DT.Rows(0).Item("email")), Me.txtemail.Text)
            End If
            If Me.txtattach.Text <> GFncNoNullString(DT.Rows(0).Item("attachment")) Then
                Log += GfncOneFieldLog("Attachment_Path", GFncNoNullString(DT.Rows(0).Item("attachment")), Me.txtattach.Text)
            End If
        End If

        Return Log
    End Function
End Class
