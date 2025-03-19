Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class FrmEmailAlertRecipientList
    Dim EmailFlag As String
    Dim AdjEmail As String
    Dim SelectedEmail As String
    Dim cls As ClsEmailAlertRecipientList = New ClsEmailAlertRecipientList

    Private Sub FrmEmailAgentMaster_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        GetEmailSubjectName()
    End Sub

    Private Sub GetEmailSubjectName()
        Dim DT As DataTable
        DT = cls.getEmailSubject.Tables(0)
        Me.cboEmailSubject.DataSource = DT
        Me.cboEmailSubject.DisplayMember = "EmailSubject"
        Me.cboEmailSubject.ValueMember = "ReportSchID"
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
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
        Me.btnAdd.Enabled = Not blnflag
        Me.btnModify.Enabled = Not blnflag
        Me.btnDel.Enabled = Not blnflag

        Me.cboEmailSubject.Enabled = Not blnflag
    End Sub

    Private Sub btnDel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel.Click
        DtgMail.Focus()
        If txtEmail.Text.Length > 0 Then
            If GSubShowYNConfirm(GFncGetSysMsg(11), MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.No Then
                Return
            End If
            cls.EmailDel(Me.txtEmail.Text.Trim,
                            Me.cboEmailSubject.SelectedItem("ReportSchID").ToString().Trim,
                            Me.cboEmailSubject.SelectedItem("ReportSchName").ToString().Trim)
            btnRefresh_Click(Nothing, System.EventArgs.Empty)
            SetEmailFocus()
        End If
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        If Me.DtgMail.Rows.Count > 0 Then
            EnableEmail(True)
            EmailFlag = "Adjust"
            Me.txtEmail.Focus()
            AdjEmail = Me.txtEmail.Text
        End If
    End Sub

    Private Sub btnRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRefresh.Click
        If Me.cboEmailSubject.Text.Length > 0 Then
            DtgMail.DataSource = cls.EmailRefresh(
                Me.cboEmailSubject.SelectedItem("ReportSchID").ToString().Trim,
                Me.cboEmailSubject.SelectedItem("ReportSchName").ToString().Trim)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If EmailFlag <> "" Then
            EnableEmail(False)
            Me.txtEmail.Text = ""
            EmailFlag = ""
            btnRefresh_Click(Nothing, System.EventArgs.Empty)
            Me.DtgMail.Focus()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim MyTrans As SqlTransaction = Nothing
        Dim MyTrans2 As SqlTransaction = Nothing

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
                AdjEmail = Me.txtEmail.Text.Trim
                cls.EmailAdd(Me.txtEmail.Text.Trim,
                            Me.cboEmailSubject.SelectedItem("ReportSchID").ToString().Trim,
                            Me.cboEmailSubject.SelectedItem("ReportSchName").ToString().Trim)
                EnableEmail(False)
                btnRefresh_Click(Nothing, System.EventArgs.Empty)
                EmailFlag = ""
                SetEmailFocus()

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
                cls.EmailAdjust(SelectedEmail.Trim,
                            Me.txtEmail.Text.Trim,
                            Me.cboEmailSubject.SelectedItem("ReportSchID").ToString().Trim,
                            Me.cboEmailSubject.SelectedItem("ReportSchName").ToString().Trim)
                AdjEmail = Me.txtEmail.Text

                EnableEmail(False)
                btnRefresh_Click(Nothing, System.EventArgs.Empty)
                EmailFlag = ""
                SetEmailFocus()

        End Select
    End Sub

    Public Function EmailValidation(emailAddress) As Boolean
        Dim email As New Regex("[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+(?:[A-Z]{2}|com|org|net|edu|gov|mil|biz|info|mobi|name|aero|asia|jobs|museum)\b")
        If email.IsMatch(emailAddress) Then
            Return True
        Else
            Return False
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

        If Me.DtgMail.Rows.Count = 0 Then
            Me.txtEmail.Text = ""
        End If
    End Sub

    Private Sub DtgMail_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtgMail.SelectionChanged
        If Me.DtgMail.Rows.Count > 0 Then
            Me.txtEmail.Text = Me.DtgMail.CurrentRow.Cells("dtgEmail").Value.ToString.Trim
            SelectedEmail = Me.txtEmail.Text
        End If
    End Sub

    Private Sub EmailSubject_SelectionChanged(sender As Object, e As EventArgs) Handles cboEmailSubject.SelectedIndexChanged
        btnRefresh_Click(sender, e)
        If Me.DtgMail.Rows.Count = 0 Then
            Me.txtEmail.Text = ""
        End If
    End Sub
End Class