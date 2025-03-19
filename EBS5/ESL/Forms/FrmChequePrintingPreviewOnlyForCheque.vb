Public Class FrmChequePrintingPreviewOnlyForCheque

    'On Show
    Protected Overrides Sub OnShown(e As EventArgs)
        MyBase.OnShown(e)
    End Sub

    'Adjust controls
    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)

        Dim targetWidthFor2ndColumn As Integer = Me.DisplayRectangle.Width - SystemInformation.VerticalScrollBarWidth - (lvDatas.Columns(0).Width + lvDatas.Columns(2).Width + lvDatas.Columns(3).Width)
        lvDatas.Columns(1).Width = Math.Max(targetWidthFor2ndColumn, 250)
    End Sub

    ''' <summary>
    ''' 显示数据
    ''' </summary>
    ''' <param name="dt"></param>
    ''' <remarks></remarks>
    Public Sub ShowDatas(dt As DataTable)

        '增强检查
        If dt Is Nothing Or dt.Rows.Count <= 0 Then
            Return
        End If

        'Prevent ui refresh
        lvDatas.BeginUpdate()

        Try
            'remove old datas
            lvDatas.Items.Clear()

            'foreach to add new datas
            For Each row As DataRow In dt.Rows
                Dim current As New ListViewItem(row("client_code").ToString())
                current.SubItems.Add(row("name"))

                Dim tmp_amount As Decimal = row.Field(Of Decimal)("amount")
                current.SubItems.Add(tmp_amount.ToString("#0.00"))

                Dim tmp_txn_date As DateTime = row.Field(Of DateTime)("txn_date")
                current.SubItems.Add(tmp_txn_date.ToString("dd/MM/yyyy"))

                lvDatas.Items.Add(current)
            Next

        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
        End Try

        'Restore ui refresh
        lvDatas.EndUpdate()

    End Sub

End Class