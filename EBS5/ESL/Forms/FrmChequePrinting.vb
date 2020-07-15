Public Class FrmChequePrinting

    Dim cls As New ClsChequePrinting
    Private peFormStatus As EnumFormStatus
    Private pbIsGridSelected As Boolean = False
    Dim frmDetail As New FrmChequePrintingDetails

    ' model
    Dim currentSequence As Decimal
    Dim currentTxnDate As String

    Private Sub FrmChequePrinting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        SetStatus(EnumFormStatus.Search)
        Me.dgv_Binding()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled Then
            SetStatus(EnumFormStatus.Search)
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        Dim last = From k In dgvClientCheque.Rows.Cast(Of DataGridViewRow)()
                   Group k By Sequence = k.Cells("Sequence") Into g = Group, sp = Max(k.Cells("Sequence"))
                   Select sp
        Dim rowNum As Integer
        For Each c As DataGridViewTextBoxCell In last
            rowNum = c.Value
        Next

        frmDetail.Add(rowNum + 1, Me.dtpTxnDate.Value)
        frmDetail.SetMode(FrmChequePrintingDetails.FormMode.NewMode)
        frmDetail.ShowDialog()

        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Or frmDetail.DialogResult = Windows.Forms.DialogResult.Cancel Then
            Me.dgv_Binding()
        End If

    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        frmDetail.Edit(
            GetDgvSelectedValue("Sequence"),
            GetDgvSelectedString("ClientCode"),
            GetDgvSelectedString("CName"),
            GetDgvSelectedValue("Amount"),
            GetDgvSelectedString("TxnDate")
        )
        frmDetail.SetMode(FrmChequePrintingDetails.FormMode.EditMode)
        frmDetail.ShowDialog()
        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.dgv_Binding()
        End If
    End Sub

    Private Function GetDgvSelectedString(ByVal columnName As String) As String
        Return GFncNoNullString(Me.dgvClientCheque.CurrentRow.Cells(columnName).Value).Trim
    End Function

    Private Function GetDgvSelectedValue(ByVal columnName As String) As Decimal
        Return GFncNoNullValue(GetDgvSelectedString(columnName))
    End Function
    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        frmDetail.Delete(
            GetDgvSelectedValue("Sequence"),
            GetDgvSelectedString("ClientCode"),
            GetDgvSelectedString("CName"),
            GetDgvSelectedValue("Amount"),
            GetDgvSelectedString("TxnDate")
        )
        frmDetail.SetMode(FrmChequePrintingDetails.FormMode.DeleteMode)
        frmDetail.ShowDialog()
        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.dgv_Binding()
        End If

    End Sub

    Private Sub SetStatus(ByVal status As EnumFormStatus)
        peFormStatus = status

        ' 设置搜索状态
        dtpTxnDate.Enabled = status = EnumFormStatus.Search
        btnPrev.Enabled = status = EnumFormStatus.Search
        btnNext.Enabled = status = EnumFormStatus.Search

        ' 设置编辑状态
        dgvClientCheque.Enabled = status = EnumFormStatus.Search

        ' 设置按钮状态
        Me.btnNew.Enabled = status = EnumFormStatus.Search
        Me.btnEdit.Enabled = status = EnumFormStatus.Search And pbIsGridSelected
        Me.btnDelete.Enabled = status = EnumFormStatus.Search And pbIsGridSelected
        Me.btnDetails.Enabled = status = EnumFormStatus.Search And pbIsGridSelected
        Me.btnSort.Enabled = status = EnumFormStatus.Search
        Me.btnCancel.Enabled = status = EnumFormStatus.Details Or status = EnumFormStatus.Search Or status = EnumFormStatus.New Or status = EnumFormStatus.Edit
        Me.btnSave.Enabled = status = EnumFormStatus.New Or status = EnumFormStatus.Edit

    End Sub

    Private Sub dgvClientCheque_SelectionChanged(sender As Object, e As EventArgs) Handles dgvClientCheque.SelectionChanged
        pbIsGridSelected = Not Me.dgvClientCheque.CurrentRow Is Nothing
        SetStatus(EnumFormStatus.Search)
    End Sub

    Private Sub dgvClientCheque_DataSourceChanged(sender As Object, e As EventArgs) Handles dgvClientCheque.DataSourceChanged
        pbIsGridSelected = Not Me.dgvClientCheque.CurrentRow Is Nothing
        SetStatus(EnumFormStatus.Search)
    End Sub

#Region "Search"

    Private Sub btnPrev_Click(sender As Object, e As EventArgs) Handles btnPrev.Click
        Me.dtpTxnDate.Value = Me.dtpTxnDate.Value.AddDays(-1)
        Me.dgv_Binding()
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Me.dtpTxnDate.Value = Me.dtpTxnDate.Value.AddDays(1)
        Me.dgv_Binding()
    End Sub

    Private Sub dgv_Binding(Optional ByVal orderby As String = "")

        'List
        If orderby = "" Then
            orderby = "Sequence"
        End If

        Dim dt As DataTable = cls.FncSearch(Me.dtpTxnDate.Value.Date, orderby)
        Me.dgvClientCheque.AutoGenerateColumns = False
        Me.dgvClientCheque.DataSource = dt

    End Sub

#End Region

#Region "Sorting"

    Private Sub btnSort_Click(sender As Object, e As EventArgs) Handles btnSort.Click
        Dim frmDialog As FrmChequeSorting = New FrmChequeSorting()
        frmDialog.ShowDialog()
        If frmDialog.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.dgv_Binding(frmDialog.ResultSortString)
        End If
        frmDialog.Dispose()
    End Sub

#End Region

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Dim plnFrm As FrmChequePrintingPrints = New FrmChequePrintingPrints()
        plnFrm.SetTargetDate(Me.dtpTxnDate.Value)
        plnFrm.ShowDialog(Me)
    End Sub

    Private Sub btnDetails_Click(sender As Object, e As EventArgs) Handles btnDetails.Click
        frmDetail.Details(
            GetDgvSelectedValue("Sequence"),
            GetDgvSelectedString("ClientCode"),
            GetDgvSelectedString("CName"),
            GetDgvSelectedValue("Amount"),
            GetDgvSelectedString("TxnDate")
        )
        frmDetail.SetMode(FrmChequePrintingDetails.FormMode.DetailMode)
        frmDetail.ShowDialog()
        If frmDetail.DialogResult = Windows.Forms.DialogResult.OK Then
            Me.dgv_Binding()
        End If
    End Sub


    Private Sub dtpTxnDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpTxnDate.ValueChanged
        ' 用ValueChanged事件控制检索（试过用回车事件不好控制）
        Me.dgv_Binding()
    End Sub
End Class