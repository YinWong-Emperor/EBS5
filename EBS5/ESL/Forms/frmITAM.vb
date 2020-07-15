Imports System.Data.SqlClient
Imports System.Text.RegularExpressions

Public Class frmITAM

    Private cls As New clsITA

    Private Sub frmITAM_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadForm(True)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled Then
            SetControls(True)
            dgvITAP_SelectionChanged(Nothing, System.EventArgs.Empty)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub loadForm(Optional ByVal loadTitle As Boolean = False)
        If loadTitle Then
            Me.Text = "Trading Activity Parameter Maintenance" & vbTab & Me.Text
        End If
        Me.dgvITAP.ClearSelection()
        Me.dgvITAP.DataSource = cls.FncLoadITAP()
        SetControls(True)
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        SetControls(False)
    End Sub

    Private Sub SetControls(ByVal flg As Boolean)
        Me.btnSave.Enabled = Not flg
        Me.txtValue.ReadOnly = flg
        Me.ambValue.ReadOnly = flg
        Me.btnModify.Enabled = flg
        Me.dgvITAP.Enabled = flg
        Me.txtValue.Enabled = Not flg
        Me.ambValue.Enabled = Not flg
        Me.txtModule.BackColor = Color.Linen
        Me.txtDesc.BackColor = Color.Linen
        If flg Then
            Me.txtValue.BackColor = Color.Linen
            Me.ambValue.BackColor = Color.Linen
        Else
            Me.txtValue.BackColor = Color.White
            Me.ambValue.BackColor = Color.White
            If Me.txtValue.Visible Then
                Me.txtValue.Focus()
            Else
                Me.ambValue.Focus()
            End If
        End If
    End Sub

    Private Sub dgvITAP_SelectionChanged(sender As Object, e As EventArgs) Handles dgvITAP.SelectionChanged
        Dim dgvr As DataGridViewRow = Nothing
        Dim vType As String = ""
        If dgvITAP.SelectedRows IsNot Nothing AndAlso dgvITAP.SelectedRows.Count > 0 Then
            dgvr = dgvITAP.SelectedRows.Item(0)
            Me.ambID.Text = GFncNoNullIntValue(dgvr.Cells("UID").Value)
            Me.txtModule.Text = GFncNoNullString(dgvr.Cells("MODNAME").Value)
            Me.txtDesc.Text = GFncNoNullString(dgvr.Cells("PARADESC").Value)
            vType = GFncNoNullString(dgvr.Cells("VALTYPE").Value)
            Me.ambMin.Text = GFncNoNullIntValue(dgvr.Cells("MINVAL").Value)
            Me.ambMax.Text = GFncNoNullIntValue(dgvr.Cells("MAXVAL").Value)
            If vType = "N" Then
                Me.ambValue.Text = GFncNoNullIntValue(dgvr.Cells("PARAVAL").Value)
            Else
                Me.txtValue.Text = GFncNoNullString(dgvr.Cells("PARAVAL").Value)
            End If
        Else
            Me.ambID.Text = ""
            Me.txtModule.Text = ""
            Me.txtDesc.Text = ""
            vType = ""
            Me.ambMin.Text = ""
            Me.ambMax.Text = ""
            Me.ambValue.Text = ""
            Me.txtValue.Text = ""
        End If
        Me.txtType.Text = vType
        If vType = "N" Then
            Me.txtValue.Visible = False
            Me.ambValue.Visible = True
            Me.txtValue.Text = ""
            Me.ambValue.MaxLength = Me.ambMax.Text.Length
        Else
            Me.txtValue.Visible = True
            Me.ambValue.Visible = False
            Me.ambValue.Text = ""
            Me.txtValue.MaxLength = IIf(Me.ambMax.Text = "", 0, Me.ambMax.Text)
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim vType As String = GFncNoNullString(Me.txtType.Text)
        If vType = "N" Then
            If GFncNoNullString(Me.ambValue.Text) = "" Then
                MessageBox.Show(Me.lblValue.Text & " cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
            Dim value As Integer = GFncNoNullIntValue(Me.ambValue.Text)
            If value < GFncNoNullIntValue(Me.ambMin.Text) OrElse value > GFncNoNullIntValue(Me.ambMax.Text) Then
                MessageBox.Show(Me.lblValue.Text & " must be between " & Me.ambMin.Text & " and " & Me.ambMax.Text & ".", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End If
        Else
            Dim value As String = GFncNoNullString(Me.txtValue.Text)
            If value = "" Then
                MessageBox.Show(Me.lblValue.Text & " cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            Else
                Static emailRegex As New Regex("^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9]{0,61}[a-zA-Z0-9])?)*(?:,[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9]{0,61}[a-zA-Z0-9])?)*)*$")
                If Not emailRegex.IsMatch(value) Then
                    MessageBox.Show("Invalid email address.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return
                End If
            End If
        End If
        Dim op = GSubShowYNConfirm(GFncGetSysMsg(10))
        If op = Windows.Forms.DialogResult.No Then
            Return
        End If
        Dim id As Integer = GFncNoNullIntValue(Me.ambID.Text)
        If cls.FncUpdateParameter(id, IIf(vType = "N", GFncNoNullString(Me.ambValue.Text), GFncNoNullString(Me.txtValue.Text))) Then
            loadForm()
            GFncSelectDgvAfterUpdate(dgvITAP, "UID", id)
            GSubShowInfo(GFncGetSysMsg(8))
        Else
            GSubShowInfo(GFncGetSysMsg(9))
        End If
    End Sub

    Private Sub ambValue_KeyDown(sender As Object, e As KeyEventArgs) Handles ambValue.KeyDown
        If e.KeyValue = 110 OrElse e.KeyValue = 190 Then
            e.SuppressKeyPress = True
        End If
    End Sub
End Class
