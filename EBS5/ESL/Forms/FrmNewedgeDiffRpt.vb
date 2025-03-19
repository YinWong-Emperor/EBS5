Imports CrystalDecisions.Shared
Imports System.IO


Public Class FrmNewedgeDiffRpt
    Dim DiffDT As DataTable
    Dim cls As New ClsNewedgeDiffRpt
    Dim frm As New FrmRptDisplay
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing

    Private Sub FrmNewedgeDiffRpt_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim clsFR As New clsFuturesReport
        Me.cbxCounterParty.DataSource = clsFR.GetCounterParty
        Me.cbxCounterParty.ValueMember = "misc_desc"
    End Sub



    'Private Sub DtDate_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DtDate.ValueChanged
    '    DiffDT = cls.IFncGetTable(Me.DtDate.Value)
    '    dtgProduct.DataSource = DiffDT
    '    BgColor()
    '    DtDate.Focus()
    'End Sub

    'Private Sub FrmNewedgeDiffRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load
    '    'lsubShowProcessing(False)
    '    'Me.DtDate.Value = cls.getNewestDate()

    'End Sub

    Private Sub FrmNewedgeDiffRpt_Shown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Shown
        lsubShowProcessing(False)
        Me.DtDate.Value = cls.getNewestDate()
    End Sub


    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    'Private Sub BgColor()
    '    For row As Integer = 0 To Me.dtgProduct.Rows.Count() - 1
    '        If dtgProduct.Rows(row).Cells("dtgCapBuy").Value <> dtgProduct.Rows(row).Cells("dtgEmpBuy").Value Or _
    '            dtgProduct.Rows(row).Cells("dtgCapSell").Value <> dtgProduct.Rows(row).Cells("dtgEmpSell").Value Then
    '            For col As Integer = 0 To Me.dtgProduct.ColumnCount - 1
    '                Me.dtgProduct.Rows(row).Cells(col).Style.BackColor = Color.LightPink
    '                Me.dtgProduct.Rows(row).Cells(col).Style.SelectionBackColor = Color.LightPink
    '            Next
    '        Else
    '            For col As Integer = 0 To Me.dtgProduct.ColumnCount - 1
    '                Me.dtgProduct.Rows(row).Cells(col).Style.BackColor = Color.Linen
    '                Me.dtgProduct.Rows(row).Cells(col).Style.SelectionBackColor = Color.Linen
    '                Me.dtgProduct.Rows(row).Cells(col).Style.SelectionForeColor = Color.Black
    '            Next
    '        End If
    '    Next
    'End Sub

    Private Sub btnSave_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim strPrinterName As String = ""
        Dim intFromPage As Integer = 0
        Dim intToPage As Integer = 0
        Dim shtCopies As Short = 1


        If Me.RBPrint.Checked = True Then
            'printDlg.AllowSomePages = True
            If PrintDlg.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
                strPrinterName = PrintDlg.PrinterSettings.PrinterName
                shtCopies = PrintDlg.PrinterSettings.Copies
                If PrintDlg.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
                    intFromPage = PrintDlg.PrinterSettings.FromPage
                    intToPage = PrintDlg.PrinterSettings.ToPage
                End If
            Else
                Exit Sub
            End If
        End If
        lsubShowProcessing(True)
        Application.DoEvents()

        Dim TransRptDt As DataTable = cls.IFncGetTrade(Me.DtDate.Value, Me.cbxCounterParty.Text)
        Dim TradeDiffRptDt As DataTable = cls.IFncGetTradeDiff(Me.DtDate.Value, Me.cbxCounterParty.Text).Tables(0)
        Dim CommRptDt As DataTable = cls.lFnGetComm(Me.DtDate.Value, Me.cbxCounterParty.Text)
        Dim CommDiffRptDt As DataTable = cls.lFnGetCommDiff(Me.DtDate.Value, Me.cbxCounterParty.Text).Tables(0)

        rpt = cls.lFncPrintNewedgeDiffRpt(TransRptDt, TradeDiffRptDt, CommRptDt, CommDiffRptDt, "NewEdge Difference Report", Me.DtDate.Value, Me.cbxCounterParty.Text)




        Windows.Forms.Cursor.Current = Cursors.WaitCursor



        If Me.RBPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf Me.RBPrint.Checked = True Then
            If GFncPrintRpt(rpt, strPrinterName, shtCopies, intFromPage, intToPage) Then
                GSubShowInfo(GFncGetSysMsg(104))
            End If
        End If

        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)

    End Sub



   
End Class
