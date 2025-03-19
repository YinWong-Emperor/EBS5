Imports CrystalDecisions.CrystalReports.Engine
Imports System.Data.SqlClient
Imports CrystalDecisions.Shared

Public Class FrmCIESPerformance
    Dim rpt As CrystalDecisions.CrystalReports.Engine.ReportClass = Nothing
    Dim frm As New FrmRptDisplay
    Dim cls As New ClsCIESPerformance
    'Dim cls As New clsNewedgeFloatingPL

    Private Sub FrmCIESPerformance_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim clsFR As New clsFuturesReport
        'Me.cbxCounterParty.DataSource = clsFR.GetCounterParty
        'Me.cbxCounterParty.ValueMember = "misc_desc"
        'Me.dtpTrade.Text = Format(GDteTradeDate, "yyyy/MM/dd")
        lsubShowProcessing(False)
        Me.cbxClientCode.DataSource = cls.lFnGetClientCode
        Me.cbxClientCode.ValueMember = "clt_code"
        'Me.cbxTradeDate.Enabled = False
        'Me.cbxTradeDate.SelectedIndex = -1
    End Sub

    Private Sub lsubShowProcessing(ByVal blnShow As Boolean)
        pbarPrint.Visible = blnShow
        lblProcess.Visible = blnShow
    End Sub

    Private Sub cbxClientCode_Selected(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbxClientCode.SelectedIndexChanged
        Me.cbxTradeDate.Enabled = True
        Me.cbxTradeDate.DataSource = cls.lFnGetTradeDate(Me.cbxClientCode.Text.Trim)
        Me.cbxTradeDate.ValueMember = "Trade_Date"


    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
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
        rpt = FncGenReport(Me.cbxClientCode.Text, Me.cbxTradeDate.SelectedValue)

        If rbtPreview.Checked = True Then
            frm.GSubDisplayRpt(rpt)
        ElseIf rbtPrint.Checked = True Then
            GFncPrintRpt(rpt, strPrinterName)
        End If
        Windows.Forms.Cursor.Current = Cursors.Default
        lsubShowProcessing(False)
    End Sub

    Public Function FncGenReport(ByVal clientCode As String, ByVal TradeDate As Date)

        'Dim dt As DataTable = New dtsFloatingPL.MasterDataTable
        Dim rpt As New rptCIES
        Dim query As String
        Dim FundMovementDT As DataTable
        Dim OpenPositionDT As DataTable
        Dim TransactionDT As DataTable
        Dim PerformanceDT As DataTable
        Dim totalCount As Integer
        Dim ldteFrom As Date
        Dim ldteTo As Date = TradeDate

        query = "select * from CIES_performance_detail where clt_code = '" & clientCode & "' and Trade_Date = '" & Format(TradeDate, "yyyy/MM/dd") & "'"
        PerformanceDT = GFncRtnDS(GSCnLiqConn, query).Tables(0)
        If PerformanceDT.Rows.Count > 0 Then
            ldteFrom = PerformanceDT.Rows(0).Item("from_date")
        Else
            Return Nothing
        End If

        query = "select * from CIES_Fund_Movement where clt_code = '" & clientCode & "' and movement_date between '" & Format(ldteFrom, "yyyy/MM/dd") & "' and '" & Format(ldteTo, "yyyy/MM/dd") & "'"
        FundMovementDT = GFncRtnDS(GSCnLiqConn, query).Tables(0)
        totalCount = FundMovementDT.Rows.Count
        For i As Integer = 0 To totalCount - 1
            Dim dr As DataRow = FundMovementDT.NewRow
            FundMovementDT.Rows(i).Item("movement_date") = Format(FundMovementDT.Rows(i).Item("movement_date"), "yyyy/MM/dd")
        Next

        query = "select * from CIES_Open_Position where clt_code = '" & clientCode & "' and Trade_Date = '" & Format(TradeDate, "yyyy/MM/dd") & "'"
        OpenPositionDT = GFncRtnDS(GSCnLiqConn, query).Tables(0)

        query = "select * from CIES_transaction where clt_code = '" & clientCode & "' and tx_date between '" & Format(ldteFrom, "yyyy/MM/dd") & "' and '" & Format(ldteTo, "yyyy/MM/dd") & "'"
        TransactionDT = GFncRtnDS(GSCnLiqConn, query).Tables(0)

        totalCount = TransactionDT.Rows.Count
        For i As Integer = 0 To totalCount - 1
            Dim dr As DataRow = TransactionDT.NewRow
            TransactionDT.Rows(i).Item("tx_date") = Format(TransactionDT.Rows(i).Item("tx_date"), "yyyy/MM/dd")
        Next

        'MsgBox(FundMovementDT)

        'Dim performanceFee As Decimal


        'performanceFee = PerformanceDT.Rows(0).Item("Stock_value") + PerformanceDT.Rows(0).Item("Cash_balance") + PerformanceDT.Rows(0).Item("Total_Charges") + PerformanceDT.Rows(0).Item("WithDraw") - PerformanceDT.Rows(0).Item("Open_deposit")

        ' If performanceFee < 0 Then
        'performanceFee = 0
        ' Else
        ' performanceFee = performanceFee * PerformanceDT.Rows(0).Item("Charge_Rate") / 100
        'End If
        'rpt.SetDataSource(FundMovementDT)
        'rpt.SetDataSource(OpenPositionDT)
        'rpt.SetDataSource(TransactionDT)
        'rpt.SetDataSource(PerformanceDT)
        rpt.SetDataSource(New DataTable())
        rpt.Subreports("rptCIES_Fund_Movement.rpt").SetDataSource(FundMovementDT)
        rpt.Subreports("rptCIES_Opn_Position.rpt").SetDataSource(OpenPositionDT)
        rpt.Subreports("rptCIES_Transaction.rpt").SetDataSource(TransactionDT)
        rpt.Subreports("rptCIES_performance.rpt").SetDataSource(PerformanceDT)

        rpt.SetParameterValue("user", GStrloginID)
        rpt.SetParameterValue("tdate", TradeDate)
        rpt.SetParameterValue("ClientCode", clientCode)
        Return rpt
    End Function
End Class
