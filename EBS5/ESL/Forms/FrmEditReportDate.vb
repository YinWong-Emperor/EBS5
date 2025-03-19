Public Class FrmEditReportDate
    Dim cls As ClsEditReportDate = New ClsEditReportDate

    Private Sub FrmEditReportDate_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GetRptDtl()
    End Sub

    Private Sub GetRptDtl()
        Dim DT As DataTable
        DT = cls.getReportDtl.Tables(0)
        cboEmailSubject.DataSource = DT
        cboEmailSubject.ValueMember = "ReportSchID"
        cboEmailSubject.DisplayMember = "Title"

        Dim RptID As String = cboEmailSubject.SelectedItem("ReportSchID").ToString

        Dim rows() As DataRow = DT.Select("ReportSchID='" + RptID + "'")
        Dim PrvDate As DateTime = DateTime.Parse(rows(0).Item("PreviousTradeDate").ToString())
        Dim CurDate As DateTime = DateTime.Parse(rows(0).Item("CurrentTradeDate").ToString())
        Dim NxtDate As DateTime = DateTime.Parse(rows(0).Item("NextTradeDate").ToString())
        PrvTradeDate.Value = PrvDate
        CurTradeDate.Value = CurDate
        NxtTradeDate.Value = NxtDate

        If RptID = "RPT_0001" Then
            TradeDateInd.Text = "(T Date)"

        Else
            TradeDateInd.Text = "(T Date - 1)"
        End If

        PrvTradeDate.Enabled = False
        CurTradeDate.Enabled = False
        NxtTradeDate.Enabled = False
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub EmailSubject_Changed(sender As Object, e As EventArgs) Handles cboEmailSubject.SelectedIndexChanged
        Dim DT As DataTable
        DT = cls.getReportDtl.Tables(0)

        Dim RptID As String = cboEmailSubject.SelectedItem("ReportSchID").ToString
        Dim rows() As DataRow = DT.Select("ReportSchID='" + RptID + "'")
        Dim PrvDate As DateTime = DateTime.Parse(rows(0).Item("PreviousTradeDate").ToString())
        Dim CurDate As DateTime = DateTime.Parse(rows(0).Item("CurrentTradeDate").ToString())
        Dim NxtDate As DateTime = DateTime.Parse(rows(0).Item("NextTradeDate").ToString())

        PrvTradeDate.Value = PrvDate
        CurTradeDate.Value = CurDate
        NxtTradeDate.Value = NxtDate

        If RptID = "RPT_0001" Then
            TradeDateInd.Text = "(T Date)"

        Else
            TradeDateInd.Text = "(T Date - 1)"
        End If

        PrvTradeDate.Enabled = False
        CurTradeDate.Enabled = False
        NxtTradeDate.Enabled = False
        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub TradeDate_Save(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim RptID As String = cboEmailSubject.SelectedItem("ReportSchID").ToString
        Dim PrDate As String = PrvTradeDate.Value.ToString("yyyyMMdd")
        Dim CrDate As String = CurTradeDate.Value.ToString("yyyyMMdd")
        Dim NxDate As String = NxtTradeDate.Value.ToString("yyyyMMdd")

        cls.EditTradeDate(RptID, PrDate, CrDate, NxDate)

        PrvTradeDate.Enabled = False
        CurTradeDate.Enabled = False
        NxtTradeDate.Enabled = False
        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False

    End Sub

    Private Sub Click_Exit(sender As Object, e As EventArgs) Handles btnExit.Click
        Close()
    End Sub

    Private Sub Click_Cancel(sender As Object, e As EventArgs) Handles btnCancel.Click
        'GSubShowInfo("The change you made has been cancelled!")
        'Dim idx As Integer = cboEmailSubject.SelectedIndex
        'GetRptDtl()

        Dim DT As DataTable
        DT = cls.getReportDtl.Tables(0)
        Dim RptID As String = cboEmailSubject.SelectedItem("ReportSchID").ToString
        Dim rows() As DataRow = DT.Select("ReportSchID='" + RptID + "'")
        Dim PrvDate As DateTime = DateTime.Parse(rows(0).Item("PreviousTradeDate").ToString())
        Dim CurDate As DateTime = DateTime.Parse(rows(0).Item("CurrentTradeDate").ToString())
        Dim NxtDate As DateTime = DateTime.Parse(rows(0).Item("NextTradeDate").ToString())

        PrvTradeDate.Value = PrvDate
        CurTradeDate.Value = CurDate
        NxtTradeDate.Value = NxtDate

        If RptID = "RPT_0001" Then
            TradeDateInd.Text = "(T Date)"

        Else
            TradeDateInd.Text = "(T Date - 1)"
        End If
        PrvTradeDate.Enabled = False
        CurTradeDate.Enabled = False
        NxtTradeDate.Enabled = False
        btnEdit.Enabled = True
        btnSave.Enabled = False
        btnCancel.Enabled = False
    End Sub

    Private Sub Click_Edit(sender As Object, e As EventArgs) Handles btnEdit.Click
        PrvTradeDate.Enabled = True
        CurTradeDate.Enabled = True
        NxtTradeDate.Enabled = True
        btnEdit.Enabled = False
        btnSave.Enabled = True
        btnCancel.Enabled = True

    End Sub
End Class