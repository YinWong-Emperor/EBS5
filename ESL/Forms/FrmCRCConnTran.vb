Public Class FrmCRCConnTran

    Dim cls As New ClsCRCConnTran
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim startDate As Date
    Dim endDate As Date

    Private Sub FrmCRCConnTran_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        lsubShowProcessing(False)
        Dim lds As DataSet = Nothing
        Dim ldr As DataRow = Nothing
        lds = cls.lFncGetGroupList()
        Me.lbGroup.Items.Clear()
        For Each ldr In lds.Tables("Group").Rows
            Me.lbGroup.Items.Add(ldr("lname"))
        Next
        Me.lbGroup.SelectedIndex = 0
        getGroupClientList()
        Me.nupYear.Value = System.DateTime.Today.Year
        Me.nupMonth.Value = System.DateTime.Today.Month
        endDate = cls.FncGetEndDate()
        If endDate.Day < 5 Then
            startDate = endDate.AddMonths(-1)
            startDate = startDate.AddDays(1 - startDate.Day)
        Else
            startDate = endDate.AddDays(1 - endDate.Day)
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lbGroup_MouseClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles lbGroup.MouseClick
        getGroupClientList()
    End Sub

    Private Sub getGroupClientList()
        Dim lds As DataSet
        Dim ldr As DataRow
        lds = cls.getGroupClientList(Me.lbGroup.Text)
        Me.lbClient.Items.Clear()
        For Each ldr In lds.Tables("groupclientlist").Rows
            Me.lbClient.Items.Add(ldr("clt_code"))
        Next
        Me.lbClient.SelectedIndex = 0
        Me.lblAccCount.Text = "Total no. of Record : " & lds.Tables("groupclientlist").Rows.Count
    End Sub

    Private Sub refreshIPOList()
        Dim lds As DataSet
        lds = cls.getIPOList(Me.nupYear.Value, Me.nupMonth.Value, Me.txtClientFrom.Text, Me.txtClientTo.Text)
        Me.dtgIPO.DataSource = lds
        Me.dtgIPO.DataMember = "ipolist"
        Dim total As Decimal = 0.0
        For Each dr As DataRow In lds.Tables(0).Rows
            total += dr.Item(2)
        Next
        If total <> 0 Then
            lblIPOTotal.Text = total
        Else
            lblIPOTotal.Text = ""
        End If
    End Sub

    Private Sub btnGet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGet.Click
        refreshIPOList()
    End Sub

    Private Sub tcClient_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tcClient.SelectedIndexChanged
        If (Me.tcClient.SelectedIndex = 1) Then
            refreshIPOList()
        End If
        If (Me.tcClient.SelectedIndex <> 2) Then
            Me.txtClient.Text = ""
            Me.dpDate.Value = System.DateTime.Today
            Me.txtIPO.Text = ""
        End If
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub btnPrintLgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintLgr.Click
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
        rpt = cls.FncGenReport1(startDate, endDate, "led_bal")
        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Private Sub btnPrintAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintAva.Click
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
        rpt = cls.FncGenReport1(startDate, endDate, "ava_bal")
        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Private Sub btnExportLgr_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportLgr.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        lsubShowProcessing(True)
        Application.DoEvents()
        If cls.FncExport1(startDate, endDate, "led_bal") Then
            GSubShowInfo(GFncGetSysMsg(28))
        Else
            GSubShowInfo(GFncGetSysMsg(29))
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Private Sub btnExportAva_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportAva.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        lsubShowProcessing(True)
        Application.DoEvents()
        If cls.FncExport1(startDate, endDate, "ava_bal") Then
            GSubShowInfo(GFncGetSysMsg(28))
        Else
            GSubShowInfo(GFncGetSysMsg(29))
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Private Sub btnPrintIPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintIPO.Click
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
        rpt = cls.FncGenReport1(startDate, endDate, "ipo_loan")
        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Private Sub btnExportIPO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExportIPO.Click
        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        lsubShowProcessing(True)
        Application.DoEvents()
        If cls.FncExport1(startDate, endDate, "ipo_loan") Then
            GSubShowInfo(GFncGetSysMsg(28))
        Else
            GSubShowInfo(GFncGetSysMsg(29))
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        
        cls.delIPOList(dtgIPO.Rows(dtgIPO.CurrentRow.Index).Cells(0).Value, dtgIPO.Rows(dtgIPO.CurrentRow.Index).Cells(1).Value)
        refreshIPOList()
    End Sub

    Private Sub MyButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyButton1.Click
        If txtClient.Text.Trim = "" Then
            GSubShowInfo("Client Code is Empty.")
            txtClient.Focus()
        ElseIf txtIPO.Text.Trim = "" Then
            GSubShowInfo("IPO is Empty.")
            txtIPO.Focus()
        Else
            If cls.addIPOList(txtClient.Text, dpDate.Value, txtIPO.Text) Then
                GSubShowInfo("Save Success.")
            Else
                GSubShowInfo("Save Fail.")
            End If
        End If
    End Sub

End Class
