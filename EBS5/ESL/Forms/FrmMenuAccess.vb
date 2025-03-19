Public Class FrmMenuAccess

    Dim clsMA As New ClsMenuAccess
    Dim ldtsMA As DataSet
    Dim ldtsFnc As DataSet

    Private Sub FrmMenuAccess_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        clsMA.lSubDropTemp()
    End Sub

    Private Sub FrmMenuAccess_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If e.KeyChar = ChrW(Keys.Escape) Then
            Call btnCancel_Click("", System.EventArgs.Empty)
        End If
    End Sub

    Private Sub FrmMenuAccess_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        clsMA.lSubCreateTemp()
        clsMA.lSubGetMenu(frmMenu.MenuStrip1)

        Me.lsubControl(False, "")

        Dim ldtsAcc As DataSet = clsMA.lfncUserDS()
        Dim ldtwAcc As DataRow
        For Each ldtwAcc In ldtsAcc.Tables(0).Rows
            Me.ComboBox1.Items.Add(ldtwAcc("uiuserid"))
            Me.ComboBox2.Items.Add(ldtwAcc("uiuserid"))
        Next
        Me.btnModify.Enabled = False
        Me.btnSave.Visible = True

    End Sub

    Private Sub lsubControl(ByVal lblnflag As Boolean, ByVal lstrUserID As String)

        If Me.TabControl1.SelectedIndex = 0 Then
            If lstrUserID <> "" Then
                clsMA.lSubFindRight(lstrUserID)
            End If

            ldtsMA = clsMA.lfncMADS()
            Me.DataGridView1.DataSource = ldtsMA
            Me.DataGridView1.DataMember = "MA"

            For lintCnt As Integer = 1 To 4
                Me.DataGridView1.Columns(lintCnt).ReadOnly = True
            Next
            Me.DataGridView1.Columns(5).ReadOnly = Not lblnflag
            If Not lblnflag Then
                Me.DataGridView1.Columns(5).DefaultCellStyle.BackColor = Color.LemonChiffon
                Me.DataGridView1.Columns(5).DefaultCellStyle.SelectionBackColor = Color.LemonChiffon
            Else
                Me.DataGridView1.Columns(5).DefaultCellStyle.BackColor = Color.White
                Me.DataGridView1.Columns(5).DefaultCellStyle.SelectionBackColor = Color.White
            End If
            Me.DataGridView1.Columns(6).Visible = False
        Else
            ldtsFnc = clsMA.lfncGetFnc(lstrUserID)
            Me.dgdFnc.DataSource = ldtsFnc.Tables(0)
            Me.dgdFnc.Columns("FncAccess").ReadOnly = Not lblnflag
            If Not lblnflag Then
                Me.dgdFnc.Columns("FncAccess").DefaultCellStyle.BackColor = Color.LemonChiffon
                Me.dgdFnc.Columns("FncAccess").DefaultCellStyle.SelectionBackColor = Color.LemonChiffon
            Else
                Me.dgdFnc.Columns("FncAccess").DefaultCellStyle.BackColor = Color.White
                Me.dgdFnc.Columns("FncAccess").DefaultCellStyle.SelectionBackColor = Color.White
            End If
            If lstrUserID <> "" Then
                clsMA.lSubFindRight(lstrUserID)
            End If
        End If

        Me.btnSave.Enabled = lblnflag
        Me.btnModify.Enabled = Not lblnflag
        Me.ComboBox1.Enabled = Not lblnflag
        Me.ComboBox2.Visible = lblnflag
        Me.Label1.Visible = lblnflag
        Me.CheckBox1.Visible = lblnflag
        Me.CheckBox1.Checked = False

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled Then
            Me.lsubControl(False, Me.ComboBox1.Text.Trim)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Me.lsubControl(False, Me.ComboBox1.Text.Trim)
    End Sub

    Private Sub btnModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnModify.Click
        If Me.ComboBox1.Text.Trim <> "" Then
            Me.lsubControl(True, Me.ComboBox1.Text.Trim)
            Me.ComboBox2.Text = Me.ComboBox1.Text
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes Then
            If Me.TabControl1.SelectedIndex = 0 Then
                If clsMA.lfncSaveMA(ldtsMA, Me.ComboBox1.Text.Trim) Then
                    GSubShowInfo(GFncGetSysMsg(8))
                    Me.lsubControl(False, Me.ComboBox1.Text.Trim)
                Else
                    GSubShowInfo(GFncGetSysMsg(9))
                End If
            Else
                If clsMA.lfncSaveFnc(ldtsFnc, Me.ComboBox1.Text.Trim) Then
                    GSubShowInfo(GFncGetSysMsg(8))
                    Me.lsubControl(False, Me.ComboBox1.Text.Trim)
                Else
                    GSubShowInfo(GFncGetSysMsg(9))
                End If
            End If
        End If

    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox2.SelectedIndexChanged
        If Me.ComboBox2.Text.Trim <> "" Then
            Me.lsubControl(True, Me.ComboBox2.Text.Trim)
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Me.btnSave.Enabled Then
            If Me.TabControl1.SelectedIndex = 0 Then
                For lintIDX As Integer = 0 To Me.ldtsMA.Tables(0).Rows.Count - 1
                    If Me.CheckBox1.Checked Then
                        Me.ldtsMA.Tables(0).Rows(lintIDX).Item("menuflag") = 1
                    Else
                        Me.ldtsMA.Tables(0).Rows(lintIDX).Item("menuflag") = 0
                    End If
                Next
            Else
                For lintIDX As Integer = 0 To Me.ldtsFnc.Tables(0).Rows.Count - 1
                    If Me.CheckBox1.Checked Then
                        Me.ldtsFnc.Tables(0).Rows(lintIDX).Item("fncright") = 1
                    Else
                        Me.ldtsFnc.Tables(0).Rows(lintIDX).Item("fncright") = 0
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged

        Me.lsubControl(False, Me.ComboBox1.Text.Trim)

    End Sub

    
    Private Sub TabControl1_Selecting(ByVal sender As Object, ByVal e As System.Windows.Forms.TabControlCancelEventArgs) Handles TabControl1.Selecting
        If Me.btnSave.Enabled Then
            e.Cancel = True
        End If
    End Sub
End Class
