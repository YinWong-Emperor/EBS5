Public Class frmImpFutureAndStock

    Public FrmMod As String = ""
    Private cls As New clsITA
    Private dtLog As DataTable = Nothing
    Public TDate As String = ""

    Private Sub frmImpFutureAndStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadForm(True)
    End Sub

    Private Sub loadForm(Optional ByVal loadTitle As Boolean = False)
        Dim str As String = IIf(FrmMod = "F", "Futures", "Stock Options")
        If loadTitle Then
            Me.Text = "Import " & str & " Trading Activity" & vbTab & Me.Text
        End If
        Me.lblTitle.Text = String.Format("Import {0} Trading Activity", str)
        Me.lblPeriod.Text = String.Format("Login Location Lookup Referencing Period: {0}", TDate)
        Me.dgvLog.ClearSelection()
        dtLog = cls.FncLoadTrade()
        If dtLog IsNot Nothing Then
            dtLog.Clear()
        End If
        Me.dgvLog.DataSource = dtLog
        Me.lblRecord.Text = ""
        dgvLog.Columns("UID").Visible = False
        SetControls(True)
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub ShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub SetControls(ByVal flg As Boolean, Optional ByVal save As Boolean = False)
        ShowProcessing(Not flg)
        If Not flg Then
            Cursor.Current = Cursors.WaitCursor
        Else
            Cursor.Current = Cursors.Default
        End If
        Me.btnImport.Enabled = flg
        Me.dgvLog.Enabled = True
        If save Then
            Me.btnSave.Enabled = True
            Me.btnCancel.Enabled = True
        Else
            Me.btnSave.Enabled = False
            Me.btnCancel.Enabled = flg
        End If
    End Sub

    Private Sub btnImport_Click(sender As Object, e As EventArgs) Handles btnImport.Click
        Dim ofd As New System.Windows.Forms.OpenFileDialog
        Dim msg As String = ""
        Try
            ofd.Filter = "CSV (*.CSV) |*.csv"
            If ofd.ShowDialog() = Windows.Forms.DialogResult.OK Then
                SetControls(False)
                dtLog.Clear()
                Dim fName As String = ofd.FileName
                If System.IO.File.Exists(fName) Then
                    msg = cls.FncValidateTradeInput(fName, dtLog, FrmMod)
                End If
                If msg <> "" Then
                    dtLog.Clear()
                    GSubWriteEventLog(vbCrLf & msg, GStrEPath)
                    GSubShowError("Validation failed!" & vbCrLf & "Please check the event log for detailed information.")
                    SetControls(True)
                    Return
                Else
                    Me.dgvLog.DataSource = dtLog
                    Me.lblRecord.Text = "No. of records: " & dtLog.Rows.Count
                End If
                SetControls(True, True)
            End If
        Catch ex As Exception
            GSubWriteELog(ex.Message)
            SetControls(True)
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim msg As String = ""
        If cls.FncCheckExistingLog() Then
            msg = GFncGetSysMsg(6)
        End If
        If msg <> "" Then
            Dim op = GSubShowYNConfirm(msg)
            If op = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If
        SetControls(False)
        If cls.FncInsertActivity(dtLog) Then
            loadForm()
            GSubShowInfo(GFncGetSysMsg(8))
        Else
            GSubShowInfo(GFncGetSysMsg(9))
        End If
        SetControls(True)
    End Sub
End Class
