Public Class FrmRptDisplay

    Private Sub FrmRptDisplay_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

        GBlnFormOpen = False

    End Sub

    Private Sub FrmRptDisplay_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        CrystalReportViewer1.ReportSource = Nothing
    End Sub

    Private Sub FrmRptDisplay_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.Escape Then
            Me.Close()
        End If
    End Sub

    Private Sub FrmRptDisplay_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        GBlnFormOpen = True
        Me.KeyPreview = True

    End Sub

    'display report without parameter field
    Public Sub GSubDisplayRpt(ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportClass)

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        'CrystalReportViewer1.ShowExportButton = False
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Show()

        Windows.Forms.Cursor.Current = Cursors.Default

        Me.ShowDialog()

    End Sub

    'display report without parameter field
    Public Sub GSubDisplayRpt(ByVal dtsRpt As DataSet, ByRef rpt As CrystalDecisions.CrystalReports.Engine.ReportClass)

        Dim DTbRpt As New DataTable

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        DTbRpt = dtsRpt.Tables(0)
        rpt.SetDataSource(DTbRpt)
        CrystalReportViewer1.ShowExportButton = False
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Show()

        Windows.Forms.Cursor.Current = Cursors.Default
        Me.ShowDialog()

    End Sub

    'display report with single/multiple parameter fields by using parafields collection
    Public Sub GSubDisplayRpt(ByVal dtsRpt As DataSet, ByRef rpt As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal paraFlds As CrystalDecisions.Shared.ParameterFields)

        Dim DTbRpt As New DataTable

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        DTbRpt = dtsRpt.Tables(0)
        rpt.SetDataSource(DTbRpt)
        CrystalReportViewer1.ShowExportButton = False
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.ParameterFieldInfo = paraFlds
        CrystalReportViewer1.Show()

        Windows.Forms.Cursor.Current = Cursors.Default
        Me.ShowDialog()

    End Sub

    'display report with single parameter field
    Public Sub GSubDisplayRpt(ByVal dtsRpt As DataSet, ByRef rpt As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal paraFldName As String, ByVal paraValue As Object)

        Dim DTbRpt As New DataTable

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        DTbRpt = dtsRpt.Tables(0)
        rpt.SetDataSource(DTbRpt)
        rpt.SetParameterValue(paraFldName, paraValue)
        CrystalReportViewer1.ShowExportButton = False
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Show()

        Windows.Forms.Cursor.Current = Cursors.Default
        Me.ShowDialog()

    End Sub

    'display report with multiple parameter fields by using array
    Public Sub GSubDisplayRpt(ByVal dtsRpt As DataSet, ByRef rpt As CrystalDecisions.CrystalReports.Engine.ReportClass, ByVal paraFldNames() As String, ByVal paraValues() As Object)

        Dim DTbRpt As New DataTable
        Dim intCount As Integer

        Windows.Forms.Cursor.Current = Cursors.WaitCursor
        DTbRpt = dtsRpt.Tables(0)
        rpt.SetDataSource(DTbRpt)
        For intCount = 0 To UBound(paraFldNames)
            rpt.SetParameterValue(paraFldNames(intCount), paraValues(intCount))
        Next
        CrystalReportViewer1.ShowExportButton = False
        CrystalReportViewer1.ReportSource = rpt
        CrystalReportViewer1.Show()

        Windows.Forms.Cursor.Current = Cursors.Default
        Me.ShowDialog()

    End Sub

    'Public Sub GSubDisplayRptWithSubRpt(ByVal dtsRpt() As DataSet, ByVal rptName() As String, ByVal dtsRptMain As DataSet, ByVal rpt As CrystalDecisions.CrystalReports.Engine.ReportClass)

    '    Dim DTbRpt As New DataTable
    '    Dim i As Integer = 0

    '    Windows.Forms.Cursor.Current = Cursors.WaitCursor
    '    DTbRpt = dtsRptMain.Tables(0)
    '    rpt.SetDataSource(DTbRpt)

    '    For i = 0 To UBound(rptName)
    '        DTbRpt = dtsRpt(i).Tables(0)
    '        rpt.Subreports.Item("RptASCurrency.rpt").SetDataSource(DTbRpt)
    '        lrpt.SetDataSource(DTbRpt)
    '    Next

    '    CrystalReportViewer1.ReportSource = rpt
    '    CrystalReportViewer1.Show()

    '    Windows.Forms.Cursor.Current = Cursors.Default
    '    Me.ShowDialog()

    'End Sub

End Class