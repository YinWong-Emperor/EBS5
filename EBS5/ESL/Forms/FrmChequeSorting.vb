Public Class FrmChequeSorting

    Public ResultSortString As String = ""

    Private Sub FrmChequeSorting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.lbAvailableKeys.SelectedIndex = 0
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Me.lbSelectedKeys.Items.Add(Me.lbAvailableKeys.SelectedItem)
        Me.lbSelectedKeys.SelectedIndex = Me.lbSelectedKeys.Items.Count - 1
        Me.lbAvailableKeys.Items.Remove(Me.lbAvailableKeys.SelectedItem)
        If Me.lbAvailableKeys.Items.Count > 0 Then
            Me.lbAvailableKeys.SelectedIndex = 0
        End If
        If Me.lbAvailableKeys.Items.Count = 0 Then
            btnAdd.Enabled = False
        End If
        btnRemove.Enabled = True
    End Sub

    Private Sub btnRemove_Click(sender As Object, e As EventArgs) Handles btnRemove.Click
        Me.lbAvailableKeys.Items.Add(Me.lbSelectedKeys.SelectedItem)
        Me.lbAvailableKeys.SelectedIndex = 0
        Me.lbSelectedKeys.Items.Remove(Me.lbSelectedKeys.SelectedItem)
        If Me.lbSelectedKeys.Items.Count > 0 Then
            Me.lbSelectedKeys.SelectedIndex = 0
        End If
        If Me.lbSelectedKeys.Items.Count = 0 Then
            btnRemove.Enabled = False
        End If
        btnAdd.Enabled = True
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
    End Sub

    Private Sub GetResultSortString()
        If Me.lbSelectedKeys.Items.Count > 0 Then
            For Each item As String In Me.lbSelectedKeys.Items
                Me.ResultSortString += "[" + item.Replace(" ", "_") + "],"
            Next
            Me.ResultSortString = Me.ResultSortString.Substring(0, Me.ResultSortString.Length - 1)
        Else
            Me.ResultSortString = ""
        End If
    End Sub


    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Me.GetResultSortString()
        Me.DialogResult = Windows.Forms.DialogResult.OK
    End Sub
End Class