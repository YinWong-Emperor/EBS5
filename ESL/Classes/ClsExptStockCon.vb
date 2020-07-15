Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports System.IO

Public Class ClsExptStockCon

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncExptStockCon(ByVal selectDate As Date, ByVal strExFile As String) As Boolean

        Dim ldtsData As DataSet

        ldtsData = GFncRtnDS(GSCnBalConn, "SELECT accno, tdate, stock_code, qty, percentage, market_value " & _
                            "FROM stockconcentration WHERE tdate='" & Format(selectDate, "yyyyMMdd") & _
                            "' ORDER BY stock_code, accno", 0)

        Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Trade_Date, Stock_Code, Qty, Percentage, Market_value ")

    End Function

End Class
