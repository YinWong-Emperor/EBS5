Public Class frmconTransMaintenanceFixedExRate
    Dim cls As New clsConTransMaintenanceFixedExRate
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay

    Private Sub frmconTransMaintenanceFixedExRate_Load(sender As Object, e As System.EventArgs) Handles MyBase.Load

        loadList()
        loadCombo()
        loadPrintPeriod()
        lsubShowProcessing(False)
    End Sub

    Private Sub loadPrintPeriod()
        Dim tempdate As Date = cls.FncGetEndPeriod()
        Dim tempdate2 As Date = cls.FncGetEndPeriod()
        tempdate2 = New Date(tempdate2.Year, tempdate2.Month, 1)
        MyDateTimePicker1.Value = tempdate2
        tempdate = New Date(tempdate.Year, tempdate.Month, tempdate.Day)
        MyDateTimePicker2.Value = tempdate

    End Sub
    Private Sub loadList()
        Dim dt As DataTable
        Me.lbGroup.Items.Clear()
        dt = cls.FncLoadGroup()
        For Each dr As DataRow In dt.Rows
            Me.lbGroup.Items.Add(dr("list_name").ToString.Trim)
        Next
        dt.Clear()
        Me.lbGroup.SetSelected(0, True)
    End Sub
    Private Sub loadCombo()
        Dim dt As DataTable
        Me.cmbClient.Items.Clear()
        Me.cmbClient.Items.Add("")
        dt = cls.FncLoadClient()
        For Each dr As DataRow In dt.Rows
            Me.cmbClient.Items.Add(dr("clt_code").ToString.Trim)
        Next
        dt.Clear()
    End Sub
    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub
    Private Sub setBtn(ByVal flag As Boolean)
        Me.btnAdd.Enabled = Not flag
        Me.btnEdit.Enabled = flag
        Me.btnNew.Enabled = flag
        Me.txtGroup.Enabled = Not flag
        Me.cmbClient.Enabled = Not flag
        Me.lbGroup.Enabled = flag
        Me.lbClient.Enabled = Not flag
        Me.btnPrint.Enabled = flag
        Me.btnSave.Enabled = Not flag
        Me.btnUP.Enabled = Not flag
        Me.btnDown.Enabled = Not flag
    End Sub
    Private Function exsitClient(ByVal client As String) As Boolean
        For i As Integer = 0 To Me.lbClient.Items.Count - 1
            If Me.lbClient.Items(i).ToString.Trim = client Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Sub lbGroup_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lbGroup.SelectedIndexChanged
        Try
            Me.txtGroup.Text = Me.lbGroup.Text.Trim
            If Me.lbGroup.Text.Trim <> "" Then
                Dim dt As DataTable
                Me.lbClient.Items.Clear()
                dt = cls.FncLoadClient(Me.lbGroup.Text.Trim)
                For Each dr As DataRow In dt.Rows
                    Me.lbClient.Items.Add(dr("clt_code").ToString.Trim)
                Next
                dt.Clear()
            End If
        Catch ex As Exception
            Me.lbClient.Items.Clear()
        End Try
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        setBtn(False)
        Me.txtGroup.Text = ""
        Me.lbClient.Items.Clear()
        Me.cmbClient.Text = ""
        Me.btnUP.Enabled = False
        Me.btnDown.Enabled = False
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        If Me.txtGroup.Text = "" Then
            MessageBox.Show("Please select a group first", "")
            Return
        End If
        setBtn(False)
        Me.txtGroup.Enabled = False
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If Me.btnSave.Enabled = True Then
            setBtn(True)
            Me.txtGroup.Text = ""
            Me.cmbClient.Text = ""
            Me.lbClient.Items.Clear()
            loadList()
        Else
            Me.Close()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim group As String = Me.txtGroup.Text.Trim
        Dim op = MessageBox.Show("Confirm to save?", "", MessageBoxButtons.YesNo)
        If op = Windows.Forms.DialogResult.No Then
            Return
        End If
        If Me.lbClient.Items.Count = 0 Then
            op = MessageBox.Show("No clients in the group, do you confirm to save?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2)
            If op = Windows.Forms.DialogResult.No Then
                Return
            End If
        End If
        If cls.FncSave(Me.txtGroup.Text, Me.lbClient) Then
            GSubShowInfo(GFncGetSysMsg(8))
        End If
        setBtn(True)
        loadList()
        For i As Integer = 0 To Me.lbGroup.Items.Count - 1
            If Me.lbGroup.Items(i).ToString.Trim = group Then
                Me.lbGroup.SetSelected(i, True)
                Exit For
            End If
        Next
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        If Me.cmbClient.Text.Trim <> "" Then
            If Not exsitClient(Me.cmbClient.Text.Trim) Then
                Me.lbClient.Items.Add(Me.cmbClient.Text.Trim)
            End If
        End If
    End Sub


    Private Sub lbClient_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lbClient.KeyUp
        If e.KeyValue = System.Windows.Forms.Keys.Delete Then
            Dim client = Me.lbClient.Text.Trim
            For i As Integer = 0 To Me.lbClient.Items.Count - 1
                If Me.lbClient.Items(i).ToString.Trim = client Then
                    Me.lbClient.Items.RemoveAt(i)
                    Exit For
                End If
            Next
        End If
    End Sub

    Private Sub BtnUp_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUP.Click
        lsubChangeRow("UP")
    End Sub

    Private Sub btnDown_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDown.Click
        lsubChangeRow("DN")
    End Sub

    Private Sub lsubChangeRow(ByVal strUpDown As String)
        If Me.lbClient.Items.Count > 0 Then
            Dim client = Me.lbClient.Text.Trim
            Dim idx As Integer
            For idx = 0 To Me.lbClient.Items.Count - 1
                If Me.lbClient.Items(idx).ToString.Trim = client Then
                    Exit For
                End If
            Next
            If strUpDown = "UP" Then
                If idx > 0 Then
                    Me.lbClient.Items(idx) = Me.lbClient.Items(idx - 1)
                    Me.lbClient.Items(idx - 1) = client
                    Me.lbClient.SetSelected(idx - 1, True)
                End If
            ElseIf strUpDown = "DN" Then
                If idx < Me.lbClient.Items.Count - 1 Then
                    Me.lbClient.Items(idx) = Me.lbClient.Items(idx + 1)
                    Me.lbClient.Items(idx + 1) = client
                    Me.lbClient.SetSelected(idx + 1, True)
                End If
            End If
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1
        Windows.Forms.Cursor.Current = Cursors.WaitCursor

        lsubShowProcessing(True)
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

        If Me.rbtAll.Checked Then
            rpt = cls.FncGenRpt(CDate(Me.MyDateTimePicker1.Text), CDate(Me.MyDateTimePicker2.Text))
        ElseIf Me.rbtCurrent.Checked Then
            rpt = cls.FncGenRpt(CDate(Me.MyDateTimePicker1.Text), CDate(Me.MyDateTimePicker2.Text), Me.lbGroup.Text.Trim)
        End If
        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub
    Private Sub MyDateTimePicker2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyDateTimePicker2.ValueChanged
        If Me.MyDateTimePicker2.Value < Me.MyDateTimePicker1.Value Then
            Me.MyDateTimePicker2.Value = Me.MyDateTimePicker1.Value
        End If
    End Sub

    Private Sub MyDateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyDateTimePicker1.ValueChanged
        If Me.MyDateTimePicker2.Value < Me.MyDateTimePicker1.Value Then
            Me.MyDateTimePicker1.Value = Me.MyDateTimePicker2.Value
        End If
    End Sub
End Class
