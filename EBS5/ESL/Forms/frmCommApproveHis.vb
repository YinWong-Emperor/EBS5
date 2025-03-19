Imports System.Data.SqlClient
Public Class frmCommApproveHis

    Dim cls As New clsCommApprove
    Dim rpt As New rptCommLog
    Dim frm As New FrmRptDisplay

    Private Sub frmCommApproveHis_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setProcessing(False)
        Me.txtMonth.Text = cls.FncGetMonth()
        loadCmb()
    End Sub

    Private Sub setProcessing(ByVal flag As Boolean)
        Me.pbarPrint.Visible = flag
        Me.lblProcess.Visible = flag
    End Sub

    Private Sub loadCmb()
        Dim dt As DataTable = cls.FncGetApprovedTime(Me.txtMonth.Text.Trim)
        Me.cmbApprove.Items.Clear()
        Me.cmbApprove.Items.Add("")
        For Each dr As DataRow In dt.Rows
            Me.cmbApprove.Items.Add(Format(GFncNoNullDate(dr("d_date")), "yyyy/MM/dd HH:mm:ss"))
        Next
        Me.cmbApprove.SelectedIndex = Nothing
        Me.cmbApprove.SelectedIndex = 0
        dt = cls.FncGetAE()
        For Each dr As DataRow In dt.Rows
            Me.cmbAE.Items.Add(GFncNoNullString(dr("ae_no")).Trim)
        Next
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'If Me.cmbApprove.SelectedItem.ToString.Trim = "" Then
        '    MessageBox.Show("Approved time can not be empty!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        '    Return
        'End If
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        setProcessing(True)
        If Me.rbtPrint.Checked = True Then
            If PrintDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDialog1.PrinterSettings.PrinterName
                shtCopies = PrintDialog1.PrinterSettings.Copies
                If PrintDialog1.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDialog1.PrinterSettings.FromPage
                    intToPage = PrintDialog1.PrinterSettings.ToPage
                End If
            Else
                Exit Sub
            End If
        End If
        Application.DoEvents()
        Dim lpt As String = ""
        Dim i As Integer = Me.cmbApprove.SelectedIndex
        If i <> Me.cmbApprove.Items.Count - 1 Then
            lpt = Format(GFncNoNullDate(Me.cmbApprove.Items(i + 1).ToString.Trim), "yyyy/MM/dd HH:mm:ss")
        End If
        Dim status As String = ""
        If i = 0 Then
            status = "[Not Approved]"
        Else
            status = "[Approved on " & Me.cmbApprove.Text.Trim & "]"
        End If
        Dim dt As DataTable = cls.FncGetLogs(Me.txtMonth.Text.Trim, lpt, Me.cmbApprove.Text.Trim, Me.cmbAE.Text.Trim)
        dt.Columns.Remove("d_type")
        dt.Columns("misc_desc").ColumnName = "d_type"
        rpt = New rptCommLog
        rpt.SetDataSource(dt)
        rpt.SetParameterValue("user", GStrloginID)
        rpt.SetParameterValue("condition", "")
        rpt.SetParameterValue("status", status)
        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
        setProcessing(False)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub txtMonth_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtMonth.TextChanged
        loadCmb()
    End Sub
End Class
