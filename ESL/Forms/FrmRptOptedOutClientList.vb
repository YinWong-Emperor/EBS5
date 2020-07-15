Public Class FrmRptOptedOutClientList
    Private cls As New ClsRptOptedOutClientList
    Private rpt As CrystalDecisions.CrystalReports.Engine.ReportClass
    Private frm As New FrmRptDisplay

    'Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
    '    Dim orderBy As String = ""
    '    Dim targetDB As String = ""

    '    If rbG2bf.Checked = True Then
    '        targetDB = GStrG2BFDB
    '    ElseIf rbG2bs.Checked = True Then
    '        targetDB = GStrG2BSDB
    '    End If

    '    If rbBrancdAndAE.Checked = True Then
    '        orderBy = "order by branch_name,v.aeno"
    '    ElseIf rbAccNo.Checked = True Then
    '        orderBy = "order by accno"
    '    End If


    '    Dim ds As DataSet = cls.lFnGetOptedOutClientList(targetDB, orderBy)

    '    Application.DoEvents()

    '    Dim PrintDialog1 As New PrintDialog
    '    Dim strPrinterName As String = ""
    '    Dim intFromPage As Integer = 0
    '    Dim intToPage As Integer = 0
    '    Dim shtCopies As Short = 1

    '    Windows.Forms.Cursor.Current = Cursors.WaitCursor

    '    If PrintDialog1.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '        strPrinterName = PrintDialog1.PrinterSettings.PrinterName
    '        shtCopies = PrintDialog1.PrinterSettings.Copies
    '        If PrintDialog1.PrinterSettings.PrintRange = Printing.PrintRange.SomePages Then
    '            intFromPage = PrintDialog1.PrinterSettings.FromPage
    '            intToPage = PrintDialog1.PrinterSettings.ToPage
    '        End If
    '        Dim dt As DataTable = ds.Tables(0)
    '        Dim strRptTitle = "Opted-Out Client List"
    '        Dim strRptID = "NotOptedOutClientList"

    '        rpt = New RptOptedOutClientList

    '        rpt.SetDataSource(dt)
    '        rpt.SetParameterValue("paraTitle", strRptTitle)
    '        rpt.SetParameterValue("paraPrintUser", GStrloginID)
    '        rpt.SetParameterValue("paraRptID", strRptID)
    '        GFncPrintRpt(rpt, strPrinterName)

    '    End If

    '    Application.DoEvents()




    'End Sub

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click

        Dim orderBy As String = ""
        Dim targetDB As String = ""
        Dim strExFile As String = "OptedOutClientList"

        If rbG2bf.Checked = True Then
            'targetDB = GStrG2BFDB
            targetDB = GStrG2BFPRODDB
            strExFile = "OptedOutClientList_g2bf.csv"
        ElseIf rbG2bs.Checked = True Then
            'targetDB = GStrG2BSDB
            targetDB = GStrG2BSPRODDB
            strExFile = "OptedOutClientList_g2bs.csv"
        End If

        If rbBrancdAndAE.Checked = True Then
            orderBy = "order by branch_name,v.aeno"
        ElseIf rbAccNo.Checked = True Then
            orderBy = "order by accno"
        End If

        If (GSubShowYNConfirm(GFncGetSysMsg(27) & GFncGetSysMsg(1) & GStrExptDir & strExFile) = Windows.Forms.DialogResult.Yes) Then
            If (cls.lFncExportNotOptedOutClientList(strExFile, targetDB, orderBy) = True) Then
                GSubShowInfo(GFncGetSysMsg(28))
            Else
                GSubShowInfo(GFncGetSysMsg(29))
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub FrmRptOptedOutClientList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        rbG2bf.Checked = True
        rbBrancdAndAE.Checked = True
    End Sub
End Class