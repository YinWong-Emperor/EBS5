Imports System.Data.SqlClient
Imports System.IO

Public Class ClsMonthToDate

    Protected Friend Function lExptTurnoverS(ByVal fromDate As Date, ByVal toDate As Date) As Boolean

        Dim strFromDate As String = Format(fromDate, "yyyyMMdd"), strToDate As String = Format(toDate, "yyyyMMdd")

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_MonthToDate_StocksClientsTurnover", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "GStrG2BSDB", GStrG2BSDB)
        AddParameter(sqlCmd, "fromDate", strFromDate)
        AddParameter(sqlCmd, "toDate", strToDate)
        Dim ldtsData As DataSet = GFncRtnDS(sqlCmd)

        Dim strExFile As String = "Stock_Turnover_" & strFromDate & "_" & strToDate & "_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv"
        Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, AE_No, AE_Name, Turnover ")

    End Function

    Protected Friend Function lExptTurnoverF(ByVal fromDate As Date, ByVal toDate As Date) As Boolean

        Dim strFromDate As String = Format(fromDate, "yyyyMMdd"), strToDate As String = Format(toDate, "yyyyMMdd")

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_MonthToDate_FuturesClientsTurnover", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "GStrG2BFDB", GStrG2BFDB)
        AddParameter(sqlCmd, "fromDate", strFromDate)
        AddParameter(sqlCmd, "toDate", strToDate)
        Dim ldtsData As DataSet = GFncRtnDS(sqlCmd)

        Dim strExFile As String = "Futures_Turnover_" & strFromDate & "_" & strToDate & "_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv"
        Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, AE_No, Turnover ")

    End Function

    Protected Friend Function lExptNewClientS(ByVal fromDate As Date, ByVal toDate As Date) As Boolean

        Dim strFromDate As String = Format(fromDate, "yyyyMMdd"), strToDate As String = Format(toDate, "yyyyMMdd")

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_MonthToDate_StockNewClients", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "GStrG2BSDB", GStrG2BSDB)
        AddParameter(sqlCmd, "fromDate", strFromDate)
        AddParameter(sqlCmd, "toDate", strToDate)
        Dim ldtsData As DataSet = GFncRtnDS(sqlCmd)

        Dim strExFile As String = "Stock_New_Account_" & strFromDate & "_" & strToDate & "_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv"
        Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, AE_No, ID_No, Open_Date ")

    End Function

    Protected Friend Function lExptNewClientF(ByVal fromDate As Date, ByVal toDate As Date) As Boolean

        Dim strFromDate As String = Format(fromDate, "yyyyMMdd"), strToDate As String = Format(toDate, "yyyyMMdd")

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_MonthToDate_FuturesNewClients", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "GStrG2BFDB", GStrG2BFDB)
        AddParameter(sqlCmd, "fromDate", strFromDate)
        AddParameter(sqlCmd, "toDate", strToDate)
        Dim ldtsData As DataSet = GFncRtnDS(sqlCmd)

        Dim strExFile As String = "Futures_New_Account_" & strFromDate & "_" & strToDate & "_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv"
        Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, AE_No, ID_No, Open_Date ")

    End Function

    Protected Friend Function lExptMarginS(ByVal fromDate As Date, ByVal toDate As Date) As Boolean

        Dim strFromDate As String = Format(fromDate, "yyyyMMdd"), strToDate As String = Format(toDate, "yyyyMMdd")

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_MonthToDate_StockMarginIO", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "GStrG2BSDB", GStrG2BSDB)
        AddParameter(sqlCmd, "fromDate", strFromDate)
        AddParameter(sqlCmd, "toDate", strToDate)
        Dim ldtsData As DataSet = GFncRtnDS(sqlCmd)

        Dim strExFile As String = "Stock_Margin_" & strFromDate & "_" & strToDate & "_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".csv"
        Return GExportCSV(GStrExptDir, strExFile, ldtsData, " Date, Acc_No, Acc_Name, Type, Amount ")

    End Function

    Protected Friend Function lExptEIEHK(ByVal fromDate As Date, ByVal toDate As Date) As Boolean
        Dim strFromDate As String = Format(fromDate, "yyyyMMdd"), strToDate As String = Format(toDate, "yyyyMMdd")

        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_MonthToDate_EIEHK", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "GStrG2BSDB", GStrG2BSDB)

        Dim ldtsData As DataTable = GFncRtnDS(sqlCmd).Tables(0)
        Dim strExFile As String = "Stock_EIEHK_" & strFromDate & "_" & strToDate & "_" & DateTime.Now.ToString("yyyyMMddHHmmssfff") & ".xls"
        Return GExportToExcel(GStrExptDir, strExFile, ldtsData, " Acc_No, Acc_Name, AE_No, Branch, Open_Date")

    End Function



    ''' <summary>
    ''' 获取最后的交易日期，根据指定的数据库
    ''' </summary>
    ''' <param name="LiqConn">指定的数据库</param>
    ''' <returns>Date类型</returns>
    Private Function fncGetLastTradeDate(ByVal LiqConn As String) As DateTime
        Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LastTradeDate", GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure
        AddParameter(sqlCmd, "LiqConn", LiqConn)

        Return GFncRtnDS(sqlCmd).Tables(0).Rows(0).Field(Of DateTime)(0)
    End Function

    ''' <summary>
    ''' 获取[Stock]最后的交易日期，根据指定的数据库
    ''' </summary>
    Protected Friend Function funcGetLastTradeDateOfStock() As DateTime
        Return fncGetLastTradeDate(GStrG2BSDB)
    End Function

    ''' <summary>
    ''' 获取[Futures]最后的交易日期，根据指定的数据库
    ''' </summary>
    Protected Friend Function funcGetLastTradeDateOfFutures() As DateTime
        Return fncGetLastTradeDate(GStrG2BFDB)
    End Function


End Class
