Public Class FrmDataBackup

    Dim FrmTime As frmMenu

    Private Sub FrmDataBackup_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmDataBackup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave
        FrmTime = Me.MdiParent
        FrmTime.TimChecking.Enabled = True
    End Sub

    Private Sub FrmDataBackup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        FrmTime = Me.MdiParent
        FrmTime.TimChecking.Enabled = False

        Label1.Text = "Branch is " & g_branch_name
        TxtBPath.Text = GStrBPath
        TxtFileName.Text = Format(GDteTradeDate, "yyyyMMdd") & "-" & Format(Now, "yyyyMMddHHmmss")

        lsubShowProcessing(False)
        Me.btnSave.Focus()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click

        'Dim DtRBackup As SqlClient.SqlDataReader
        Dim DtSBackup As New DataSet
        Dim lstrSQL As String = ""
        lsubShowProcessing(True)
        Application.DoEvents()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor


        If GFncBackup(TxtBPath.Text) Then
            Windows.Forms.Cursor.Current = Cursors.Default
            GSubShowInfo(GFncGetSysMsg(77))
            Me.Close()
        Else
            GSubShowWarn(GFncGetSysMsg(76))
        End If
        lsubShowProcessing(False)
        Windows.Forms.Cursor.Current = Cursors.Default

    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

End Class
