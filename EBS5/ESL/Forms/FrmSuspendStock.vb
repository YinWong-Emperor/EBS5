Public Class FrmSuspendStock

    Dim cls As New ClsSuspendStock

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click

        If (rbAll.Checked = True) Then
            Me.dtgStock.DataSource = cls.lFncGetAllStock()
            Me.dtgStock.DataMember = "Stock"
        Else
            Me.dtgStock.DataSource = cls.lFncGetStockByDate(Me.dpFrom.Value, Me.dpTo.Value)
            Me.dtgStock.DataMember = "Stock"
        End If

    End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        If (rbAll.Checked = True) Then
            If (cls.lFncExptAllStock() = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
            End If
        Else
            If (cls.lFncExptStockByDate(Me.dpFrom.Value, Me.dpTo.Value) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
            End If
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub FrmSuspendStock_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.dtgStock.DataSource = cls.lFncGetAllStock()
        Me.dtgStock.DataMember = "Stock"

    End Sub

End Class
