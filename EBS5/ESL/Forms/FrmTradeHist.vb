Public Class FrmTradeHist

    Dim lintOption As Integer

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmTradeHist_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        lintOption = 2
        Me.RBAFE.Checked = True
        Me.RBBoth.Checked = False
        Me.RBIASIA.Checked = False
        Me.DTPFrom.Value = Now
        Me.DTPTo.Value = Now
        Me.btnSave.Visible = True
        lsubShowProcessing(False)
        lsubEnableForm(True)

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cls As New ClsTradeHist

        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lsubShowProcessing(True)
        lsubEnableForm(False)

        Application.DoEvents()

        cls.lFncExport(Me.txtStock.Text.Trim, Me.DTPFrom.Value, Me.DTPTo.Value, lintOption)

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
        lsubEnableForm(True)

    End Sub

    Private Sub RBIASIA_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBIASIA.CheckedChanged
        If Me.RBIASIA.Checked Then
            lintOption = 1
        End If
    End Sub

    Private Sub RBBoth_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBBoth.CheckedChanged
        If Me.RBBoth.Checked Then
            lintOption = 3
        End If
    End Sub

    Private Sub RBAFE_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles RBAFE.CheckedChanged
        If Me.RBAFE.Checked Then
            lintOption = 2
        End If
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub


    Private Sub lsubEnableForm(ByVal bEnable As Boolean)
        Me.btnCancel.Visible = bEnable
        Me.btnSave.Visible = bEnable
        Me.RBAFE.Enabled = bEnable
        Me.RBBoth.Enabled = bEnable
        Me.RBIASIA.Enabled = bEnable
        Me.txtStock.Enabled = bEnable
        Me.DTPFrom.Enabled = bEnable
        Me.DTPTo.Enabled = bEnable
    End Sub

End Class
