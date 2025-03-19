Public Class FrmExptClientBal

    Dim cls As New ClsExptClientBal

    Private Sub btnNewGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewGroup.Click

        modifyClientList()
        Me.txtGroup.Enabled = True
        Me.txtGroup.Text = ""
        Me.lbAcc.Items.Clear()

    End Sub

    Private Sub btnEditGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEditGroup.Click

        modifyClientList()
        Me.txtGroup.Enabled = False

    End Sub

    Private Sub modifyClientList()

        Me.btnNewGroup.Enabled = False
        Me.btnEditGroup.Enabled = False
        Me.lbGroup.Enabled = False
        Me.btnAddAcc.Enabled = True
        Me.txtAcc.Enabled = True
        Me.txtAcc.Text = ""
        Me.lbAcc.Enabled = True
        Me.btnUp.Enabled = True
        Me.btnDown.Enabled = True
        Me.cbSelAcc.Enabled = True
        Me.btnMove.Enabled = False
        Me.lbSelAcc.Enabled = False
        Me.btnExport.Enabled = False
        Me.btnSave.Enabled = False
        Me.btnReset.Enabled = True

    End Sub

    Private Sub getGroupList()

        Dim lds As DataSet
        Dim ldr As DataRow

        lds = cls.getGroupList()
        Me.lbGroup.Items.Clear()
        For Each ldr In lds.Tables("grouplist").Rows
            Me.lbGroup.Items.Add(ldr("list_name"))
        Next
        Me.lbGroup.SelectedIndex = 0

    End Sub

    Private Sub getGroupClientList()

        Dim lds As DataSet
        Dim ldr As DataRow

        lds = cls.getGroupClientList(Me.lbGroup.Text)
        Me.lbAcc.Items.Clear()
        For Each ldr In lds.Tables("groupclientlist").Rows
            Me.lbAcc.Items.Add(ldr("clt_code"))
        Next
        Me.lbAcc.SelectedIndex = 0

        Me.lblAccCount.Text = "Total no. of Record : " & lds.Tables("groupclientlist").Rows.Count

    End Sub

    Private Sub getSelClientList()

        Dim lds As DataSet

        lds = cls.getSelClientList()
        Me.lbSelAcc.DataSource = lds.Tables("selclientlist").DefaultView
        Me.lbSelAcc.DisplayMember = "clt_code"

        Me.lblSelAcc.Text = "Total no. of Record : " & lds.Tables("selclientlist").Rows.Count

    End Sub

    Private Sub addClient(ByVal accno As String)

        Dim i As Integer

        If (accno.Trim.Length > 0) Then
            For i = 0 To Me.lbAcc.Items.Count - 1
                If (Me.lbAcc.Items(i).ToString().Trim = accno) Then
                    Me.lbAcc.SelectedIndex = i
                    Exit Sub
                End If
            Next i
            Me.lbAcc.Items.Add(accno)
            Me.lbAcc.SelectedIndex = Me.lbAcc.Items.Count - 1
            Me.btnSave.Enabled = True
            Me.lblAccCount.Text = "Total no. of Record : " & Me.lbAcc.Items.Count
            Application.DoEvents()
            Me.txtAcc.Focus()
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnAddAcc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddAcc.Click

        If (Me.txtAcc.Text.Trim.Length > 8) Then
            Me.txtAcc.Text = Mid(Me.txtAcc.Text.Trim, 1, 8)
        Else
            Me.txtAcc.Text = Me.txtAcc.Text.Trim.PadLeft(8, "0")
        End If
        addClient(Me.txtAcc.Text)

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        'export

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'save

    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click

        resetForm()

    End Sub

    Private Sub btnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUp.Click

        If Me.lbAcc.SelectedIndex < 1 Then
            Exit Sub
        End If

        Dim i As Int16 = Me.lbAcc.SelectedIndex
        Dim s As String = Me.lbAcc.Items(i)
        Me.lbAcc.Items.RemoveAt(i)
        Me.lbAcc.Items.Insert(i - 1, s)
        Me.lbAcc.SelectedIndex = i - 1
        Me.btnSave.Enabled = True

    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click

        If Me.lbAcc.SelectedIndex > Me.lbAcc.Items.Count - 2 Or Me.lbAcc.SelectedIndex = -1 Then
            Exit Sub
        End If

        Dim i As Int16 = Me.lbAcc.SelectedIndex
        Dim s As String = Me.lbAcc.Items(i)
        Me.lbAcc.Items.RemoveAt(i)
        Me.lbAcc.Items.Insert(i + 1, s)
        Me.lbAcc.SelectedIndex = i + 1
        Me.btnSave.Enabled = True

    End Sub

    Private Sub btnMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMove.Click

        addClient(Me.lbSelAcc.Text)

    End Sub

    Private Sub resetForm()

        getGroupList()
        getGroupClientList()
        Me.btnNewGroup.Enabled = True
        Me.btnEditGroup.Enabled = True
        Me.txtGroup.Enabled = False
        Me.txtGroup.Text = Me.lbGroup.Text
        Me.lbGroup.Enabled = True
        Me.btnAddAcc.Enabled = False
        Me.txtAcc.Enabled = False
        Me.txtAcc.Text = ""
        Me.lbAcc.Enabled = True
        Me.btnUp.Enabled = False
        Me.btnDown.Enabled = False
        Me.lblAccCount.Enabled = True
        Me.cbSelAcc.Enabled = False
        Me.cbSelAcc.Checked = False
        Me.btnMove.Enabled = False
        Me.lbSelAcc.Enabled = False
        Me.lblSelAcc.Enabled = False
        Me.btnExport.Enabled = True
        Me.btnSave.Enabled = False
        Me.btnReset.Enabled = False

    End Sub

    Private Sub FrmExptClientBal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        resetForm()

    End Sub

    Private Sub lbGroup_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lbGroup.Click

        getGroupClientList()
        Me.txtGroup.Text = Me.lbGroup.Text

    End Sub

    Private Sub lbGroup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbGroup.KeyDown

        'If (e.KeyCode = Keys.Delete) Then

        '    Dim ass As String
        '    ass = "123456789"


        '    MessageBox.Show("delete")
        'End If

    End Sub

    Private Sub txtAcc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtAcc.KeyDown

        If (e.KeyCode = Keys.Enter) Then
            If (Me.txtAcc.Text.Trim.Length > 8) Then
                Me.txtAcc.Text = Mid(Me.txtAcc.Text.Trim, 1, 8)
            Else
                Me.txtAcc.Text = Me.txtAcc.Text.Trim.PadLeft(8, "0")
            End If
        End If

    End Sub
    
    Private Sub cbSelAcc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbSelAcc.CheckedChanged

        Me.lbSelAcc.Enabled = Not Me.lbSelAcc.Enabled
        Me.btnMove.Enabled = Not Me.btnMove.Enabled
        Me.lblSelAcc.Enabled = Not Me.lblSelAcc.Enabled

        If (Me.cbSelAcc.Checked = True) Then
            Me.lblSelAcc.Text = "Loading data..."
            Application.DoEvents()
            getSelClientList()
        End If

    End Sub

    Private Sub lbAcc_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbAcc.KeyDown

        If Not (Me.btnEditGroup.Enabled) Then
            If (e.KeyCode = Keys.Delete) Then
                If Me.lbAcc.SelectedIndex < 0 Then
                    Exit Sub
                End If

                Me.lbAcc.Items.RemoveAt(Me.lbAcc.SelectedIndex)
                Me.btnSave.Enabled = True
            End If
        End If

    End Sub

End Class
