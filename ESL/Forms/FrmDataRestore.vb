

Public Class FrmDataRestore

    Dim FrmTime As frmMenu
    Dim lstrFile(100) As String
    

    Private Sub FrmDataRestore_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
        End Select
    End Sub

    Private Sub FrmDataRestore_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'FrmTime = Me.MdiParent
        'FrmTime.TimChecking.Enabled = False

        Label1.Text = "Branch is " & g_branch_name
        TxtBPath.Text = GStrBPath
        lsubShowProcessing(False)
        Me.lsubFindBackupFile()
        Me.lsubSetCombo()
        Me.RdLiq.Checked = True

    End Sub

    Private Sub lsubFindBackupFile()
        Dim ldtsFile As DataSet
        Dim ldtwFile As DataRow
        Dim lstrSQL As String
        Dim lintFileUpperBound As Integer
        Dim lintFileCount As Integer = 1
        Dim lstrLastFile As String = ""
       
        Try
            lintFileUpperBound = lstrFile.GetUpperBound(0)

            Array.Clear(lstrFile, 0, 100)
            lstrSQL = " sp_get_backupfile '" & GStrBPath & "*.bak' "
            ldtsFile = GFncRtnDS(GSCnSqlConn, lstrSQL)
            If ldtsFile.Tables(0).Rows.Count > 0 Then
                For Each ldtwFile In ldtsFile.Tables(0).Rows
                    If IsDBNull(ldtwFile(0)) Then
                        Continue For
                    End If
                    If Not IsNumeric(Microsoft.VisualBasic.Left(ldtwFile(0), 6)) Then
                        Continue For
                    End If
                    If lstrLastFile <> Mid(ldtwFile(0).ToString.Trim, 1, 23) Then
                        lstrLastFile = Mid(ldtwFile(0).ToString.Trim, 1, 23)
                        If lintFileCount <= lintFileUpperBound Then
                            lstrFile(Array.IndexOf(lstrFile, Nothing)) = lstrLastFile
                            lintFileCount += 1
                        End If
                    End If
                Next
            End If
        Catch ex As Exception
            GSubShowWarn(ex.Message)
        End Try

    End Sub

    Private Sub lsubSetCombo()
        Dim lintIdx As Integer = 0
        Dim lintFrom As Integer = 0
        Dim lintTo As Integer = 0

        Me.cboFileName.Items.Clear()
        lintTo = Array.IndexOf(lstrFile, Nothing) - 1

        For lintIdx = lintFrom To lintTo
            Me.cboFileName.Items.Add(lstrFile(lintIdx))
        Next

        If Me.cboFileName.Items.Count > 0 Then

            Me.cboFileName.SelectedIndex = 0
        End If

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click

        Me.Close()

    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim lscmCommand As New SqlClient.SqlCommand
        Dim ladpAdapter As SqlClient.SqlDataAdapter
        Dim lstrSQL As String
        Dim ldtsDB As DataSet
        Dim lstrFileName As String
        lsubShowProcessing(True)
        Application.DoEvents()
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        FrmTime = Me.MdiParent
        FrmTime.TimChecking.Enabled = False
        If Me.RdAccount.Checked Then
            lstrSQL = " select * from db_information where " & _
                        " CIfChrSystem ='ESL' and CIfChrServerType = 'GL'"
        Else
            lstrSQL = " select * from db_information where " & _
                                    " CIfChrSystem ='ESL' and CIfChrServerType = 'LIQ'"
        End If
        ldtsDB = modCommon.GFncRtnDS(GSCnSqlConn, lstrSQL)
        If ldtsDB.Tables(0).Rows.Count <= 0 Then
            GSubShowWarn(GFncGetSysMsg(79))
            Return
        End If
        lstrFileName = GStrBPath.Trim & Me.cboFileName.Text.Trim & _
                                "-" & ldtsDB.Tables(0).Rows(0).Item("CIfChrServerType") & ".bak"
        Try

            Dim ldtsRestore As New DataSet
            If Me.RdAccount.Checked Then
                GSCnGLConn.ChangeDatabase("Connection")
                lscmCommand.Connection = GSCnGLConn
            Else
                GSCnLiqConn.ChangeDatabase("Connection")
                lscmCommand.Connection = GSCnLiqConn
            End If
            lstrSQL = "exec Sp_Restore_Data '" & lstrFileName & "','" & _
                        ldtsDB.Tables(0).Rows(0).Item("cifchrdatabase") & "'"
            lscmCommand.CommandText = lstrSQL
            lscmCommand.CommandTimeout = 0
            ladpAdapter = New SqlClient.SqlDataAdapter(lscmCommand)

            ladpAdapter.Fill(ldtsRestore)

            If ldtsRestore.Tables(0).Rows(0).Item(0) = "SUCCESS" Then
                GSubShowInfo(GFncGetSysMsg(78))
                End
            Else
                GSubShowWarn(GFncGetSysMsg(79))
            End If

        Catch ex As Exception
            GSubShowWarn(ex.Message)
        Finally
            lscmCommand = Nothing
            ladpAdapter = Nothing
            If Me.RdAccount.Checked Then
                GSCnGLConn.ChangeDatabase(ldtsDB.Tables(0).Rows(0).Item("cifchrdatabase"))
            Else
                GSCnLiqConn.ChangeDatabase(ldtsDB.Tables(0).Rows(0).Item("cifchrdatabase"))
            End If
            FrmTime = Me.MdiParent
            FrmTime.TimChecking.Enabled = True
            Windows.Forms.Cursor.Current = Cursors.Default
            lsubShowProcessing(False)
        End Try


    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub cboFileName_SelectedIndexChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFileName.SelectedIndexChanged
        Label4.Text = "Trade Date:  " + Mid(Me.cboFileName.Text, 1, 4) & "/" & Mid(Me.cboFileName.Text, 5, 2) & "/" & _
                       Mid(Me.cboFileName.Text, 7, 2)
    End Sub
End Class
