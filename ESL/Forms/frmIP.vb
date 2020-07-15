Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Public Class frmIP

    Private cls As New clsITA
    Private dtIP As DataTable = Nothing

    Private Sub frmIP_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadForm(True)
    End Sub

    Private Sub loadForm(Optional ByVal loadTitle As Boolean = False)
        If loadTitle Then
            Me.Text = "Import IP / Country Mapping Data" & vbTab & Me.Text
        End If
        Me.dtpPeriod.Format = DateTimePickerFormat.Custom
        Me.dtpPeriod.CustomFormat = "MM/yyyy"
        Me.dtpPeriod.Text = cls.FncGetRefPeriod()
        Me.dgvIP.ClearSelection()
        dtIP = cls.FncLoadIP()
        If dtIP IsNot Nothing Then
            dtIP.Clear()
        End If
        Me.dgvIP.DataSource = dtIP
        Me.lblRecord.Text = ""
        SetControls(True)
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
        Me.dtpPeriod.Enabled = flg
        Me.btnImport.Enabled = flg
        Me.dgvIP.Enabled = True
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
                dtIP.Clear()
                Dim fName As String = ofd.FileName
                If System.IO.File.Exists(fName) Then
                    msg = cls.FncValidateIPInput(fName, dtIP)
                End If
                If msg <> "" Then
                    dtIP.Clear()
                    GSubWriteEventLog(vbCrLf & msg, GStrEPath)
                    GSubShowError("Validation failed!" & vbCrLf & "Please check the event log for detailed information.")
                    SetControls(True)
                    Return
                Else
                    Me.dgvIP.DataSource = dtIP
                    Me.lblRecord.Text = "No. of records: " & dtIP.Rows.Count
                End If
                SetControls(True, True)
            End If
        Catch ex As Exception
            GSubWriteELog(ex.Message)
            SetControls(True)
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled Then
            loadForm()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim dt As DataTable = cls.FncLoadIP()
        Dim msg As String = ""
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            msg = GFncGetSysMsg(6)
        End If
        If msg <> "" Then
            Dim op = GSubShowYNConfirm(msg)
            If op = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If
        SetControls(False)
        If cls.FncInsertIPs(dtIP, GFncNoNullString(Me.dtpPeriod.Text)) Then
            loadForm()
            GSubShowInfo(GFncGetSysMsg(8))
        Else
            GSubShowInfo(GFncGetSysMsg(9))
        End If
        SetControls(True)
    End Sub
End Class
