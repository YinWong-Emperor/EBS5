Public Class FrmStockHldgSummaryMain

    Dim cls As New ClsRptStocklHldgSummary

    Private Sub Button_add_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_add.Click
        If cls.validate(MyTextbox1.Text.Trim) Then
            If Not MyListBox2.Items.Contains(MyTextbox1.Text.Trim) Then
                MyListBox2.Items.Add(MyTextbox1.Text.Trim)
                Disable_button()
            Else
                GSubShowInfo("Duplicate Client ID!")
            End If
        Else
            GSubShowInfo("Invalid Client ID!")
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lsubEnableProcess(ByVal bEnable As Boolean)
        lblProcess.Visible = bEnable
        pbarProcess.Visible = bEnable
    End Sub

    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        Me.btnSave.Visible = bEnable
        Me.btnCancel.Visible = bEnable
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        Dim clientID() As String
        'lsubEnableProcess(True)
        'If printDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
        If GSubShowYNConfirm("Confirm?", MessageBoxDefaultButton.Button2) = Windows.Forms.DialogResult.Yes Then
            lsubEnableForm(False)
            Application.DoEvents()


            ReDim clientID(0 To MyListBox2.Items.Count - 1)
            Dim i As Integer
            For i = 0 To MyListBox2.Items.Count - 1
                clientID(i) = MyListBox2.Items.Item(i)
            Next
            If cls.Save_Client_List(clientID) Then
                GSubShowInfo("Save Success!")
            Else
                GSubShowInfo("Save Failure!")
            End If


            'lsubEnableProcess(False)
            lsubEnableForm(True)

        End If

    End Sub

    Private Sub Button_reload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_reload.Click
        Dim ldtsTemp As DataSet = cls.Load_Saved_List()
        Dim i As Integer
        MyListBox2.Items.Clear()
        For i = 0 To (ldtsTemp.Tables(0).Rows.Count - 1)
            MyListBox2.Items.Add(ldtsTemp.Tables(0).Rows(i).Item(0))
        Next
        Disable_button()
    End Sub

    Private Sub Button_delete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_delete.Click
        Dim index As Integer = MyListBox2.SelectedIndex
        MyListBox2.Items.Remove(MyListBox2.SelectedItem)
        If MyListBox2.Items.Count > index Then
            MyListBox2.SelectedItem = MyListBox2.Items(index)
        ElseIf MyListBox2.Items.Count = index And Not index = 0 Then
            MyListBox2.SelectedItem = MyListBox2.Items(index - 1)
        End If
        Disable_button()
    End Sub

    Private Sub Button_delete_all_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button_delete_all.Click
        Dim int As Integer
        Dim index As Integer = MyListBox2.Items.Count - 1
        For int = 0 To index
            MyListBox2.Items.RemoveAt(0)
        Next
        Disable_button()
    End Sub
    Private Sub MyListBox2_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyListBox2.SelectedIndexChanged
        Disable_button()
    End Sub
    Private Sub Disable_button()
        If MyListBox2.Items.Count <= 0 Then
            Button_delete.Enabled = False
            Button_delete_all.Enabled = False
        ElseIf Not MyListBox2.SelectedIndex = -1 Then
            Button_delete.Enabled = True
            Button_delete_all.Enabled = True
        Else
            Button_delete.Enabled = False
            Button_delete_all.Enabled = True
        End If
    End Sub

    Private Sub FrmStockHldgSummaryMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ldtsTemp As DataSet = cls.Load_Saved_List()
        Dim i As Integer
        For i = 0 To (ldtsTemp.Tables(0).Rows.Count - 1)
            MyListBox2.Items.Add(ldtsTemp.Tables(0).Rows(i).Item(0))
        Next
        Disable_button()
        lsubEnableProcess(False)
        lsubEnableForm(True)
    End Sub
End Class
