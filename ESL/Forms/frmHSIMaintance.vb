Public Class frmHSIMaintance

    Dim cls As New ClsHSIMaintance
    Dim ldtEmpty As DataTable = Nothing
    Dim action As String = ""
    Dim gp_id As String = ""

    Private Sub frmHSIMaintance_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Dim frmName As String = Me.Name.Trim
        If GFncCheckForm(frmName) Then
            If GFncCheckStatus() Then
                Me.Text &= "     Current Lock Status: 'Locked'"
            End If
        End If
        refreshHSIList()
        lSubControl(False)
    End Sub

    Private Sub refreshHSIList()
        Dim stock_code As String = Me.txtSrchStockCode.Text
        Dim name As String = Me.txtSrchName.Text
        Me.dgvHSI.DataSource = cls.lfncGetHSI(stock_code, name)
    End Sub

    Private Sub lSubControl(ByVal flag As Boolean)
        Me.btnSearch.Enabled = Not flag
        Me.txtSrchStockCode.Enabled = Not flag
        Me.txtSrchName.Enabled = Not flag
        Me.dgvHSI.Enabled = Not flag
        Me.txtStockCode.Enabled = flag
        Me.txtName.Enabled = flag
        Me.btnAdd.Enabled = Not flag
        If (Me.dgvHSI.RowCount <= 0) Then
            Me.btnEdit.Enabled = False
            Me.btnDelete.Enabled = False
        Else
            Me.btnEdit.Enabled = Not flag
            Me.btnDelete.Enabled = Not flag
        End If
        Me.btnSave.Enabled = flag
    End Sub

    Private Sub dgvHSI_SelectionChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles dgvHSI.SelectionChanged
        If Me.dgvHSI.Rows.Count > 0 Then
            If Me.dgvHSI.SelectedCells.Count > 0 Then
                Me.txtStockCode.Text = Str(Me.dgvHSI.CurrentRow.Cells("HSI_StockCode").Value).Trim
                Me.txtName.Text = Me.dgvHSI.CurrentRow.Cells("HSI_Stock_desc").Value
            Else
                lSubAssignField(True)
            End If
        Else
            lSubAssignField(True)
        End If
    End Sub

    Private Sub txtStockCode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtStockCode.LostFocus
        Me.txtName.Text = cls.lFncGetName(txtStockCode.Text.Trim)
    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        refreshHSIList()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If (action = "A" Or action = "E") Then
            lSubControl(False)
            If action = "E" Then
                Me.txtStockCode.Enabled = True
            End If
            lSubAssignField(False)
            action = ""
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.dgvHSI.Rows.Count > 0 Then
            action = "E"
            lSubControl(True)
            Me.txtStockCode.Text = Str(Me.dgvHSI.CurrentRow.Cells("HSI_StockCode").Value).Trim
            Me.txtStockCode.Enabled = False
            Me.txtName.Focus()
        Else
            GSubShowInfo(GFncGetSysMsg(56))
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        lSubControl(True)
        lSubAssignField(True)
        action = "A"
        Me.txtSrchStockCode.Focus()
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If Me.dgvHSI.Rows.Count > 0 Then
            If (GSubShowYNConfirm(GFncGetSysMsg(11)) = Windows.Forms.DialogResult.Yes) Then
                If GFncCheckCommStatus() Then
                    Return
                End If
                Dim HSI_StockCode As Integer = Me.dgvHSI.CurrentRow.Cells("HSI_StockCode").Value
                If (cls.lFncDelete(HSI_StockCode, Me.dgvHSI.CurrentRow.Cells("HSI_Stock_desc").Value)) Then
                    refreshHSIList()
                    lSubControl(False)
                    GSubShowInfo(GFncGetSysMsg(13))
                End If
            End If
        Else
            GSubShowInfo(GFncGetSysMsg(56))
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim stock_code As String = Me.txtStockCode.Text
        Dim name As String = Me.txtName.Text()
        Dim index As Integer = Me.dgvHSI.CurrentRow.Index
        If (stock_code.Trim = "") Then
            GSubShowInfo(GFncGetSysMsg(49))
            Me.txtStockCode.Focus()
            Return
        End If
        If GFncCheckCommStatus() Then
            Return
        End If
        If (action = "A") Then
            If (cls.lFncIsOverlap(stock_code)) Then
                GSubShowInfo(GFncGetSysMsg(44))
                Me.txtStockCode.Focus()
                Return
            End If
            If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
                If (cls.lFncAdd(stock_code, name)) Then
                    Dim i As Integer
                    refreshHSIList()
                    For i = 0 To (Me.dgvHSI.Rows.Count - 1)
                        If Str(Me.dgvHSI.Rows(i).Cells("HSI_StockCode").Value).Trim = stock_code Then
                            index = i
                        End If
                    Next
                End If
            End If
        ElseIf (action = "E") Then
            If (GSubShowYNConfirm(GFncGetSysMsg(10)) = Windows.Forms.DialogResult.Yes) Then
                cls.lFncEdit(stock_code, name)
                Me.txtStockCode.Enabled = True
            End If
        End If
        refreshHSIList()
        lSubControl(False)
        lSubAssignField(False)
        action = ""
        'Me.dgvHSI.Rows(index).Selected = True
        Me.dgvHSI.CurrentCell = Me.dgvHSI.Rows(index).Cells(0)
        Me.txtStockCode.Text = Str(Me.dgvHSI.CurrentRow.Cells("HSI_StockCode").Value).Trim
        Me.txtName.Text = Me.dgvHSI.CurrentRow.Cells("HSI_Stock_desc").Value
        GSubShowInfo(GFncGetSysMsg(8))
    End Sub

    Private Sub lSubAssignField(ByVal isEmpty As Boolean)
        If (isEmpty) Then
            Me.txtStockCode.Text = ""
            Me.txtName.Text = ""
        Else
            If (Me.dgvHSI.RowCount > 0) Then
                Me.txtStockCode.Text = Me.dgvHSI.CurrentRow.Cells("HSI_StockCode").Value
                Me.txtName.Text = Me.dgvHSI.CurrentRow.Cells("HSI_Stock_desc").Value
            Else
                Me.txtStockCode.Text = ""
                Me.txtName.Text = ""
            End If
        End If
    End Sub

End Class
