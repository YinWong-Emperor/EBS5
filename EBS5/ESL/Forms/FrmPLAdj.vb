Imports System.Data.sqlClient
Public Class FrmPLAdj
    Public query As String
    Public tDate As Date
    Public plAdj As Decimal
    Public plAdjCounter As Decimal
    Public counterparty As String
    Public lUpdUser As String
    Public lUpdDate As Date
    Public remarks As String
    Public publicRowIndex As Integer
    Public subjectToChanged As Byte = 0 'record for cancel to restore different initialized value   0 as unchanged  1 as add change  2 for modify change
    Public choice As Byte 'add = 0 update = 1
    Public noRowButtonHandleBoolean As Boolean = False

    Private Sub ClearFieldData()
        Me.txtTDate.Value = GDteTradeDate
        Me.txtPLAdj.Text = ""
        Me.txtPLAdjCounter.Text = ""
        Me.txtLUpdUser.Text = ""
        Me.txtLUpdDate.Text = ""
        Me.txtCounterparty.Text = ""
        Me.txtRemarks.Text = ""
        subjectToChanged = 0
    End Sub

    Private Sub btnAddBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddBack.Click
        ClearFieldData()
        tabctrlMain.SelectedIndex = 0
    End Sub

    Private Sub DataGridView_SelectionChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DataGridView.SelectionChanged
        Try
            ShowAddInfo(DataGridView.CurrentCell.RowIndex)
            Me.btnAddSave.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnAddModify.Enabled = True
            Me.btnAddDelete.Enabled = True
        Catch ex As Exception
            ClearFieldData()
            Me.btnAddSave.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnAddModify.Enabled = False
            Me.btnAddDelete.Enabled = False
            txtCounterparty.SelectedIndex = 0
        End Try
    End Sub

    Private Sub tabctrlMain_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tabctrlMain.SelectedIndexChanged

        If tabctrlMain.SelectedIndex = 0 Then
            btnSearch_Click(Nothing, Nothing)
            'ClearFieldData()
        ElseIf tabctrlMain.SelectedIndex = 1 And noRowButtonHandleBoolean = False Then ' modify
            DisableTextBox()
            Me.btnAddSave.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnAddModify.Enabled = True
            Me.btnAddDelete.Enabled = True
        ElseIf tabctrlMain.SelectedIndex = 1 And noRowButtonHandleBoolean = True Then  ' allow add only in index = 1 if no rows are found in search
            Me.btnAddSave.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnAddModify.Enabled = False
            Me.btnAddDelete.Enabled = False
        End If
        subjectToChanged = 0
    End Sub

    Private Sub DataGridView_CellDoubleClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView.CellDoubleClick
        ClearFieldData()
        tabctrlMain.SelectedIndex = 1
        choice = 1
        publicRowIndex = e.RowIndex
        ShowAddInfo(e.RowIndex)
    End Sub

    Private Sub ShowAddInfo(ByVal pIdx As Integer)

        If pIdx >= 0 Then
            txtTDate.Value = GFncNoNullDate(Me.DataGridView.Rows(pIdx).Cells("Grid_adjTDate").Value)
            txtCounterparty.Text = GFncNoNullString(Me.DataGridView.Rows(pIdx).Cells("Grid_counterparty").Value)
            txtPLAdj.Text = GFncNoNullValue(Me.DataGridView.Rows(pIdx).Cells("Grid_AdjOpnBal").Value)
            txtPLAdjCounter.Text = GFncNoNullValue(Me.DataGridView.Rows(pIdx).Cells("Grid_AdjNopnBal").Value)
            txtLUpdUser.Text = GFncNoNullString(Me.DataGridView.Rows(pIdx).Cells("Grid_lupduser").Value)
            txtLUpdDate.Text = GFncNoNullString(Me.DataGridView.Rows(pIdx).Cells("Grid_lupddate").Value)
            txtRemarks.Text = GFncNoNullString(Me.DataGridView.Rows(pIdx).Cells("Grid_AdjRemark").Value)
            'DataGrid:
            'txtRemarks.Text = GFncNoNullString(Me.DataGridView.Rows(pIdx).Cells("Grid_AdjRemark").Value)
            'Dataset:
            'txtRemarks.Text = GFncNoNullString(DataSet.Tables(0).Rows(pIdx).Item("AdjRemark"))
            DisableTextBox()
            subjectToChanged = 0
        Else
            tabctrlMain.SelectedIndex = 0
            choice = 0
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dataSet = New DataSet
        Dim searchTDate As Date
        Dim searchCounterParty, matchDate As String
        searchTDate = txtSearchTDate.Value
        matchDate = Format(searchTDate, "yyyy/M/dd")
        searchCounterParty = txtSearchCounterParty.Text

        If searchCounterParty = "All" Then
            query = "select * from Opening_balance_adj where adjTdate = '" & matchDate & "'"
        Else
            query = "select * from Opening_balance_adj where adjTdate = '" & matchDate & "' and counterparty = '" & searchCounterParty & "'"
        End If

        'Select Case searchCounterParty
        '    Case "ADM"
        '        query = "select * from Opening_balance_adj where adjTdate = '" & matchDate & "' and counterparty = 'ADM'"
        '    Case "NewEdge"
        '        query = "select * from Opening_balance_adj where adjTdate = '" & matchDate & "' and counterparty = 'NewEdge'"
        '    Case Else
        '        query = "select * from Opening_balance_adj where adjTdate = '" & matchDate & "'"
        'End Select
        dataSet = GFncRtnDS(GSCnSqlConn, query)
        DataGridView.DataSource = dataSet.Tables(0)

        If (DataGridView.Rows.Count) = 0 Then
            ClearFieldData()
            Me.btnAddSave.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnAddModify.Enabled = False
            Me.btnAddDelete.Enabled = False
            noRowButtonHandleBoolean = True
        Else
            noRowButtonHandleBoolean = False
        End If
    End Sub

    Private Sub DisableTextBox()
        Me.txtTDate.Enabled = False
        Me.txtPLAdj.Enabled = False
        Me.txtPLAdjCounter.Enabled = False
        Me.txtLUpdUser.Enabled = False
        Me.txtLUpdDate.Enabled = False
        Me.txtCounterparty.Enabled = False
        Me.txtRemarks.Enabled = False
    End Sub

    Private Sub EnableTextBox()
        Me.txtTDate.Enabled = True
        Me.txtPLAdj.Enabled = True
        Me.txtPLAdjCounter.Enabled = True
        Me.txtCounterparty.Enabled = True
        Me.txtRemarks.Enabled = True
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        EnableTextBox()
        ClearFieldData()
        choice = 0
        'disable add, delete, modify, enable save
        Me.btnAddSave.Enabled = True
        Me.btnAdd.Enabled = False
        Me.btnAddModify.Enabled = False
        Me.btnAddDelete.Enabled = False
        subjectToChanged = 1
    End Sub

    Private Sub btnAddModify_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddModify.Click
        Me.txtPLAdj.Enabled = True
        Me.txtPLAdjCounter.Enabled = True
        Me.txtRemarks.Enabled = True
        'disable add, delete, modify, enable save
        Me.btnAddSave.Enabled = True
        Me.btnAdd.Enabled = False
        Me.btnAddModify.Enabled = False
        Me.btnAddDelete.Enabled = False
        choice = 1
        subjectToChanged = 2
    End Sub

    Private Sub btnAddSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddSave.Click
        Dim correct As Boolean = True
        Dim transaction As SqlClient.SqlTransaction

        tDate = GFncNoNullDate(Me.txtTDate.Value)

        'chk for null
        If (Me.txtPLAdj.Text) = "" Then
            plAdj = 0
        Else
            plAdj = Me.txtPLAdj.Text
        End If
        If (Me.txtPLAdjCounter.Text) = "" Then
            plAdjCounter = 0
        Else
            plAdjCounter = Me.txtPLAdjCounter.Text
        End If

        counterparty = GFncNoNullString(Me.txtCounterparty.Text)
        remarks = GFncNoNullString(Me.txtRemarks.Text)
        lUpdUser = GStrloginID
        lUpdDate = Now()

        If counterparty = "" Then
            correct = False
            GSubShowWarn("Please select corresponding counterparty")
        End If

        If (correct) Then
            If choice = 0 Then ' add
                If CheckDuplication(tDate, counterparty) Then
                    If (GSubShowYNConfirm(GFncGetSysMsg(47)) = Windows.Forms.DialogResult.Yes) Then
                        query = "INSERT INTO Opening_balance_adj(adjTdate, adjOpnBal, adjNopnBal, lupduser, lupddate, counterparty, adjRemark) VALUES ('" & tDate.ToString("yyyy/MM/dd") & "'," & plAdj & "," & plAdjCounter & ", '" & lUpdUser & "', '" & lUpdDate.ToString("yyyy/MM/dd H:mm") & "', '" & counterparty & "', '" & remarks & "')"
                        transaction = GSCnSqlConn.BeginTransaction
                        Try
                            If GFncRunSQL(GSCnSqlConn, transaction, query, 0) > 0 Then
                                transaction.Commit()
                                transaction = Nothing
                            End If
                            choice = 0
                            GSubShowWarn(GFncGetSysMsg(8))
                        Catch ex As Exception
                            If GSCnLiqConn.State <> ConnectionState.Closed Then
                                If (transaction IsNot Nothing) Then
                                    transaction.Rollback()
                                End If
                                GSubWriteErrLog(ex.Message)
                            End If
                        End Try
                        tabctrlMain.SelectedIndex = 0
                    End If
                End If

            ElseIf CheckDuplication(tDate, counterparty) Then ' choice = 1 update
                If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
                    query = "UPDATE Opening_balance_adj SET adjOpnBal = " & plAdj & ", adjNopnBal = " & plAdjCounter & ", lupduser = '" & lUpdUser & "', lupddate = '" & lUpdDate.ToString("yyyy/MM/dd H:mm") & "', adjRemark = '" & remarks & "' where adjTdate = '" & tDate.ToString("yyyy/MM/dd") & "' and counterparty = '" & counterparty & "'"
                    transaction = GSCnSqlConn.BeginTransaction
                    Try
                        If GFncRunSQL(GSCnSqlConn, transaction, query, 0) > 0 Then
                            transaction.Commit()
                            transaction = Nothing
                        End If
                        choice = 0
                        GSubShowWarn(GFncGetSysMsg(8))
                    Catch ex As Exception
                        If GSCnLiqConn.State <> ConnectionState.Closed Then
                            If (transaction IsNot Nothing) Then
                                transaction.Rollback()
                            End If
                            GSubWriteErrLog(ex.Message)
                        End If
                    End Try
                    tabctrlMain.SelectedIndex = 0
                End If
            End If
        End If
    End Sub

    Private Sub btnAddDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddDelete.Click
        tDate = Me.txtTDate.Value
        counterparty = Me.txtCounterparty.Text
        Dim transaction As SqlClient.SqlTransaction

        If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
            query = "DELETE FROM Opening_balance_adj WHERE adjTdate = '" & tDate.ToString("yyyy/MM/dd") & "' and counterparty = '" & counterparty & "'"
            transaction = GSCnSqlConn.BeginTransaction
            Try
                If GFncRunSQL(GSCnSqlConn, transaction, query, 0) > 0 Then
                    transaction.Commit()
                    transaction = Nothing
                End If
                choice = 0
                GSubShowWarn(GFncGetSysMsg(13))
            Catch ex As Exception
                If GSCnLiqConn.State <> ConnectionState.Closed Then
                    If (transaction IsNot Nothing) Then
                        transaction.Rollback()
                    End If
                    GSubWriteErrLog(ex.Message)
                End If
            End Try

            ClearFieldData()
            tabctrlMain.SelectedIndex = 0
        End If
    End Sub

    Public Function CheckDuplication(ByVal validateDate As Date, ByVal validateCounterParty As String)
        Dim correct As Boolean = True
        Dim dataSet = New DataSet
        validateDate = validateDate.ToString("yyyy/MM/dd")

        If validateDate > DateValue(Now) Then
            correct = False
            GSubShowWarn("Date time is later than now")
        End If

        ' check for duplication in same day record

        If choice = 0 Then  ' modify dun need to chk
            query = "select * from Opening_balance_adj"
            dataSet = GFncRtnDS(GSCnSqlConn, query, 0)
            For Each row As DataRow In dataSet.Tables(0).Rows
                Dim primaryKey As String
                primaryKey = row.Item("adjTdate") & row.Item("counterparty")

                If (validateDate & validateCounterParty) = primaryKey Then
                    correct = False
                    GSubShowWarn("There is duplicated record in DB on the same day")
                End If
            Next row
        End If
        Return correct
    End Function

    Private Sub showAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles showAll.Click
        Dim dataSet = New DataSet
        query = "Select * from Opening_balance_adj"
        dataSet = GFncRtnDS(GSCnSqlConn, query)
        DataGridView.DataSource = dataSet.Tables(0)
        noRowButtonHandleBoolean = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        If subjectToChanged = 0 Then
            Me.Close()
        ElseIf subjectToChanged = 1 Then
            ClearFieldData()
            DisableTextBox()
            Me.btnAddSave.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnAddModify.Enabled = True
            Me.btnAddDelete.Enabled = True
        Else
            ShowAddInfo(publicRowIndex)
            Me.btnAddSave.Enabled = False
            Me.btnAdd.Enabled = True
            Me.btnAddModify.Enabled = True
            Me.btnAddDelete.Enabled = True
        End If
    End Sub

    Private Sub FrmPLAdj_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtSearchTDate.Value = GDteTradeDate
        Dim dataSet = New DataSet
        query = "Select * from Opening_balance_adj where adjTdate = '" & GDteTradeDate.ToString("yyyy/MM/dd") & "'"
        dataSet = GFncRtnDS(GSCnSqlConn, query)
        DataGridView.DataSource = dataSet.Tables(0)
        Me.txtSearchCounterParty.Items.Add("All")
        Dim clsFR As New clsFuturesReport
        For i As Integer = 0 To clsFR.GetCounterParty.Rows.Count - 1
            Me.txtSearchCounterParty.Items.Add(clsFR.GetCounterParty.Rows(i).Item("misc_desc"))
            Me.txtCounterparty.Items.Add(clsFR.GetCounterParty.Rows(i).Item("misc_desc"))
        Next
        Me.txtSearchCounterParty.SelectedIndex = 0
    End Sub
End Class
