Imports System.Math
Imports System.Data.SqlClient
Imports Microsoft.VisualBasic.FileIO
Imports System.Globalization
Imports System.Threading
Imports System.IO

Public Class clsITA

#Region "Maintenance"

    Public Function FncLoadITAP() As DataTable
        Dim str As String = "SELECT [UID], MODULE, PARACODE, PARADESC, PARAVAL, VALTYPE, MINVAL, MAXVAL, DISPSEQ FROM SYSTEMPARAMETER WHERE ISUPDATABLE=1 ORDER BY MODULE ASC, DISPSEQ ASC"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function FncUpdateParameter(ByVal id As Integer, ByVal val As String) As Boolean
        Dim str As String = "UPDATE SYSTEMPARAMETER SET PARAVAL = '" & val.Replace("'", "''") & "', UPDATEDON = GETDATE(), UPDATEDBYID = '" & GStrloginID.Replace("'", "''") & "' WHERE [UID] = " & GFncNoNullString(id)
        Dim MyTrans As SqlTransaction = Nothing
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
            MyTrans.Commit()
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                WriteError(ex.Message)
            End If
            Return False
        End Try
        Return True
    End Function

#End Region

#Region "IP"

    Private ImportFileNameIP As String = ""

    Public Function FncGetRefPeriod(Optional ByVal defaultValue As Boolean = True, Optional ByVal DefaultFormat As String = "MM/yyyy") As String
        Dim str As String = "SELECT TOP 1 ACTIONDETAIL FROM ACTIONLOG WHERE [ACTION] = 'ImpIPMap' AND ACTIONDETAIL LIKE 'Success:%' ORDER BY CREATEDON DESC"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        Dim result As DateTime = IIf(defaultValue, GDteTradeDate, DateTime.MinValue)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            str = GFncNoNullString(ds.Tables(0).Rows(0)("ACTIONDETAIL"))
            Dim idx As Integer = str.IndexOf("Data Import for ")
            If idx > -1 Then
                str = "01/" & str.Substring(idx + "Data Import for ".Length, 7)
                Try
                    result = GFncNoNullDate(str)
                Catch ex As Exception
                End Try
            End If
        End If
        Return Format(result, DefaultFormat)
    End Function

    Public Function FncLoadIP() As DataTable
        Dim str As String = "SELECT TOP 1 [UID], FROMIP, TOIP, COUNCODE, COUNDESC FROM IPMAPPING"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function FncInsertIPs(ByVal dt As DataTable, ByVal period As String) As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim result As Boolean = True
        Dim str As String = "SELECT FROMIP, TOIP, COUNCODE, COUNDESC INTO #TempIPMapping FROM IPMAPPING WHERE 1 = 0"
        Try
            GFncRunSQL(GSCnSqlConn, str)
        Catch ex As Exception
            WriteError(ex.Message)
            Return False
        End Try
        Try
            dt.Columns.Remove("UID")
            Dim bulk As New SqlBulkCopy(GSCnSqlConn)
            bulk.DestinationTableName = "#TempIPMapping"
            bulk.BatchSize = 10000
            bulk.WriteToServer(dt)
            MyTrans = GSCnSqlConn.BeginTransaction
            str = "DELETE FROM IPMAPPING"
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
            str = "INSERT INTO IPMAPPING SELECT FROMIP, TOIP, COUNCODE, COUNDESC, GETDATE() AS CREATEDON, '" & GStrloginID.Replace("'", "''") & "' AS CREATEDBYID FROM #TempIPMapping"
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
            MyTrans.Commit()
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                WriteError(ex.Message)
            End If
            result = False
            Return False
        Finally
            Try
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    str = "DROP TABLE #TempIPMapping"
                    GFncRunSQL(GSCnSqlConn, str)
                    MyTrans = GSCnSqlConn.BeginTransaction
                    str = "INSERT INTO ACTIONLOG VALUES ('ImpIPMap', '" & IIf(result, "Success", "Fail") & ": IP / Country Mapping Data Import for " & period & " (" & ImportFileNameIP & ")', GETDATE(), '" & GStrloginID.Replace("'", "''") & "')"
                    GFncRunSQL(GSCnSqlConn, MyTrans, str)
                    MyTrans.Commit()
                End If
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    WriteError(ex.Message)
                End If
            End Try
        End Try
        Return True
    End Function

    Public Function FncValidateIPInput(ByVal fName As String, ByRef dt As DataTable) As String
        Dim msg As String = ""
        Dim idx As Integer = 1
        Dim tfp As New TextFieldParser(fName)
        ImportFileNameIP = fName.Substring(fName.LastIndexOf("\") + 1)
        tfp.HasFieldsEnclosedInQuotes = True
        tfp.Delimiters = New String() {","}
        tfp.TextFieldType = FieldType.Delimited
        dt.Columns.Add("Errors", GetType(String))
        Thread.CurrentThread.CurrentCulture = New CultureInfo(GFncGetCulture())
        Thread.CurrentThread.CurrentUICulture = New CultureInfo(GFncGetCulture())
        While Not tfp.EndOfData
            Dim Errors As String = ""
            Dim dr As DataRow = dt.NewRow
            dr("UID") = idx
            Try
                Dim val() As String = tfp.ReadFields()
                If val.Length <> 4 Then
                    Errors &= "Error: Not exact 4 columns;"
                Else
                    Dim ip As Decimal = 0
                    Dim ip2 As Decimal = 0
                    If Not IsNumeric(val(0)) Then
                        Errors &= "Column No.: 1, Error: Invalid From IP; "
                    Else
                        ip = GFncNoNullValue(val(0))
                        If ip < 0 OrElse ip > 4294967295 Then
                            Errors &= "Column No.: 1, Error: Invalid From IP; "
                        Else
                            dr("FROMIP") = ip
                        End If
                    End If
                    If Not IsNumeric(val(1)) Then
                        Errors &= "Column No.: 2, Error: Invalid To IP; "
                    Else
                        ip2 = GFncNoNullValue(val(1))
                        If ip2 < 0 OrElse ip2 > 4294967295 Then
                            Errors &= "Column No.: 2, Error: Invalid To IP; "
                        ElseIf ip2 < ip Then
                            Errors &= "Column No.: 2, Error: To IP must be bigger than From IP; "
                        Else
                            dr("TOIP") = ip2
                        End If
                    End If
                    Dim coun As String = GFncNoNullString(val(2))
                    If coun = "" Then
                        Errors &= "Column No.: 3, Error: Code cannot be empty; "
                    ElseIf coun.Length > 2 Then
                        Errors &= "Column No.: 3, Error: Code cannot be longer than 2 characters; "
                    Else
                        dr("COUNCODE") = coun
                    End If
                    coun = GFncNoNullString(val(3))
                    If coun = "" Then
                        Errors &= "Column No.: 4, Error: Country / Territory Description cannot be empty; "
                    ElseIf coun.Length > 100 Then
                        Errors &= "Column No.: 4, Error: Country / Territory Description cannot be longer than 100 characters; "
                    Else
                        dr("COUNDESC") = coun
                    End If
                End If
            Catch ex As Exception
                Errors = ex.Message
            End Try
            dr("Errors") = Errors
            dt.Rows.Add(dr)
            idx += 1
        End While
        Dim drs As DataRow() = dt.Select("1 = 1", "FROMIP")
        Dim preDr As DataRow = Nothing
        For Each dr As DataRow In drs
            If IsNumeric(dr("FROMIP")) AndAlso IsNumeric(dr("TOIP")) Then
                Dim ip1 As Decimal = GFncNoNullValue(dr("FROMIP"))
                Dim ip2 As Decimal = GFncNoNullValue(dr("TOIP"))
                If preDr IsNot Nothing Then
                    Dim preIP1 As Decimal = GFncNoNullValue(preDr("FROMIP"))
                    Dim preIP2 As Decimal = GFncNoNullValue(preDr("TOIP"))
                    If ip1 >= preIP1 AndAlso ip1 <= preIP2 Then
                        dr("Errors") = GFncNoNullString(dr("Errors")) & "Column No.: 1, Error: Overlapped From IP; "
                    End If
                    If ip2 >= preIP1 AndAlso ip2 <= preIP2 Then
                        dr("Errors") = GFncNoNullString(dr("Errors")) & "Column No.: 2, Error: Overlapped To IP; "
                    End If
                End If
            End If
            If GFncNoNullString(dr("Errors")) <> "" Then
                msg &= "Row No.: " & GFncNoNullString(dr("UID")) & ", " & GFncNoNullString(dr("Errors")) & vbCrLf
            End If
            dr("UID") = DBNull.Value
            preDr = dr
        Next
        dt.Columns.Remove("Errors")
        Return msg
    End Function

#End Region

#Region "Trade Log"

    Public ImportFileNameTrade As String = ""
    Private TradeDate As DateTime = DateTime.MinValue
    Private TradeType As String = ""
    Private DeleteTables As New List(Of String)
    Public Property IsBatch As Boolean = False

    Public Function FncLoadEmailTo(ByVal flg As Boolean) As String
        Dim str As String = String.Format("SELECT PARAVAL FROM SYSTEMPARAMETER WHERE MODULE = 'BatImpTradActy' AND PARACODE = '{0}'", IIf(flg, "SuccEmailLst", "FailEmailLst"))
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Return GFncNoNullString(ds.Tables(0).Rows(0)("PARAVAL"))
        Else
            Return ""
        End If
    End Function

    Public Function FncLoadTrade() As DataTable
        Dim str As String = "SELECT TOP 1 [UID], INVESTTYPE, ACTYDATE, USERID, ACCNO, ACTYDETAIL, ORDERNO FROM TRADEACTYLOG WHERE 1 = 0"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function FncCheckExistingLog() As Boolean
        DeleteTables = New List(Of String)
        Dim str As New List(Of String)
        str.Add("SELECT COUNT(1) AS TRADEREC FROM TRADEACTYLOG WHERE ACTYDATE LIKE '%" & String.Format("{0}, {1} {2}", TradeDate.Day.ToString().PadLeft(2, "0"), lFncGetMonthString(TradeDate.Month), TradeDate.Year) & "%' AND INVESTTYPE = '" & TradeType & "'")
        str.Add("SELECT COUNT(1) AS TRADEREC FROM TRADEACTYSUMMARY WHERE ACTYDATE BETWEEN CONVERT(datetime,'" & Format(TradeDate.Date, "MM/dd/yyyy 00:00:00") & "') AND CONVERT(datetime,'" & Format(TradeDate.Date, "MM/dd/yyyy 23:59:59") & "') AND INVESTTYPE = '" & TradeType & "'")
        str.Add("SELECT COUNT(1) AS TRADEREC FROM TRADEACTYSUMMARYARCH WHERE ACTYDATE BETWEEN CONVERT(datetime,'" & Format(TradeDate.Date, "MM/dd/yyyy 00:00:00") & "') AND CONVERT(datetime,'" & Format(TradeDate.Date, "MM/dd/yyyy 23:59:59") & "') AND INVESTTYPE = '" & TradeType & "'")
        Dim count As Decimal = 0
        For Each Sql As String In str
            Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, Sql)
            Dim temp As Decimal = 0
            If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
                temp = GFncNoNullValue(ds.Tables(0).Rows(0)("TRADEREC"))
            End If
            If Not IsBatch AndAlso temp > 0 Then
                DeleteTables.Add(Sql.Replace("SELECT COUNT(1) AS TRADEREC", "DELETE"))
            End If
            count += temp
        Next
        If count > 0 Then
            Return True
        End If
        Return False
    End Function

    Public Function FncInsertActivity(ByVal dt As DataTable, Optional FName As String = "") As Boolean
        Dim MyTrans As SqlTransaction = Nothing
        Dim result As Boolean = True
        Dim lst As List(Of String) = New List(Of String)
        Dim str As String = "SELECT INVESTTYPE, ACTYDATE, USERID, ACCNO, ACTYDETAIL, ORDERNO INTO #TempTradeActyLog FROM TRADEACTYLOG WHERE 1 = 0"
        Try
            GFncRunSQL(GSCnSqlConn, str)
            If DeleteTables.Count > 0 Then
                MyTrans = GSCnSqlConn.BeginTransaction
                For Each str In DeleteTables
                    GFncRunSQL(GSCnSqlConn, MyTrans, str)
                Next
                DeleteTables.Clear()
                MyTrans.Commit()
            End If
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                WriteError(ex.Message, FName)
            End If
            result = False
        Finally
            MyTrans = Nothing
        End Try
        Try
            If result Then
                dt.Columns.Remove("UID")
                Dim bulk As New SqlBulkCopy(GSCnSqlConn)
                bulk.DestinationTableName = "#TempTradeActyLog"
                bulk.BatchSize = 10000
                bulk.WriteToServer(dt)
                Dim InsertFields As String = "INSERT INTO TRADEACTYSUMMARY (INVESTTYPE, ACTYDATE, ACCNO, ACTY, SUPPINFO1, SUPPINFO2, CHANNEL, CREATEDON, CREATEDBYID)"
                Dim InsertInfoFieldValue As String = String.Format("GETDATE() AS CREATEDON, '{0}' AS CREATEDBYID", GStrloginID.Replace("'", "''"))
                Dim WhereClause As String = String.Format("WHERE INVESTTYPE = '{0}' AND ACTYDATE LIKE '%{1}%'", TradeType, String.Format(Format(TradeDate, "dd, {0} yyyy,"), lFncGetMonthString(TradeDate.Month)))
                Dim WhereClauseForRowNum As String = String.Format("WHERE INVESTTYPE = '{0}' AND (ACTYDATE LIKE '%{1}%' OR ACTYDATE LIKE '%{2}%')", TradeType,
                                                                      String.Format(Format(TradeDate, "dd, {0} yyyy,"), lFncGetMonthString(TradeDate.Month)),
                                                                      String.Format(Format(TradeDate.AddDays(-1), "dd, {0} yyyy,"), lFncGetMonthString(TradeDate.AddDays(-1).Month)))
                Dim WhereClauseForDate As String = String.Format("WHERE INVESTTYPE = '{0}' AND ACTYDATE BETWEEN {1} AND {2}", TradeType,
                                                                 "CONVERT(datetime, '" & TradeDate.ToString("yyyy/MM/dd 00:00:00") & "')",
                                                                 "CONVERT(datetime, '" & TradeDate.ToString("yyyy/MM/dd 23:59:59") & "')")
                Dim IPString As String = "SUBSTRING(ACTYDETAIL, CHARINDEX('ClientIP=', ACTYDETAIL) + 9, CHARINDEX(':', ACTYDETAIL, CHARINDEX('ClientIP=', ACTYDETAIL)) - CHARINDEX('ClientIP=', ACTYDETAIL) - 9)"
                Dim DateString As String = "CONVERT(datetime, STUFF(REPLACE(REPLACE(SUBSTRING(ACTYDATE, 5, 23), ', ', '/'), ' ', '/'), 12, 1, ' '))"
                Dim ChannelString As String = "CASE WHEN B.USERID = B.ACCNO THEN 'I' ELSE 'P' END AS CHANNEL"
                MyTrans = GSCnSqlConn.BeginTransaction
                'create log
                lst.Add(String.Format("INSERT INTO TRADEACTYLOG SELECT INVESTTYPE, ACTYDATE, USERID, ACCNO, ACTYDETAIL, ORDERNO, {0} FROM #TempTradeActyLog", InsertInfoFieldValue))
                'Row_Number() for SQL Server 2000
                Dim TabForRowNumSql As String = String.Format("SELECT IDENTITY(INT, 1, 1) AS UIDBYDATE, INVESTTYPE, ACTYDATE, USERID, ACCNO, ACTYDETAIL, ORDERNO INTO #TradeActyLogByDate FROM " & _
                    "TRADEACTYLOG {0} AND ACCNO <> '' AND ORDERNO <> 0 AND ACTYDETAIL NOT LIKE 'Action=Approve Cash%' AND ACTYDETAIL NOT LIKE 'Action=Reject Cash%' " & _
                    "ORDER BY {1}, UID", WhereClauseForRowNum, DateString)
                lst.Add(TabForRowNumSql)
                Dim RowNumSql As String = "SELECT *, (SELECT COUNT(1) FROM #TradeActyLogByDate TMP " & _
                    "WHERE TMP.ACCNO = RN.ACCNO AND TMP.ORDERNO = RN.ORDERNO AND TMP.UIDBYDATE <= RN.UIDBYDATE) AS ROWNUM FROM #TradeActyLogByDate RN"
                'LoginS
                lst.Add(String.Format("{0} SELECT INVESTTYPE, {2} AS ACTYDATE, USERID AS ACCNO, 'LoginS' AS ACTY, {3} AS SUPPINFO1, dbo.ConvertIpToInt({3}) AS SUPPINFO2, NULL AS CHANNEL, {4} " & _
                    "FROM TRADEACTYLOG {5} AND USERID = ACCNO AND ACTYDETAIL LIKE 'Action=User Login%, RetCode=0%'",
                    InsertFields, InsertInfoFieldValue, DateString, IPString, InsertInfoFieldValue, WhereClause))
                lst.Add(String.Format("UPDATE TRADEACTYSUMMARY SET TRADEACTYSUMMARY.SUPPINFO2 = B.COUNDESC FROM TRADEACTYSUMMARY A INNER JOIN IPMAPPING B ON " & _
                                      "A.SUPPINFO2 BETWEEN B.FROMIP AND B.TOIP {0} AND ACTY = 'LoginS'", WhereClauseForDate))
                'LoginF
                lst.Add(String.Format("{0} SELECT INVESTTYPE, {2} AS ACTYDATE, USERID AS ACCNO, 'LoginF' AS ACTY, {3} AS SUPPINFO1, dbo.ConvertIpToInt({3}) AS SUPPINFO2, NULL AS CHANNEL, {4} " & _
                    "FROM TRADEACTYLOG {5} AND ACTYDETAIL LIKE 'Action=User Login%, RetCode=-11460008%'",
                    InsertFields, InsertInfoFieldValue, DateString, IPString, InsertInfoFieldValue, WhereClause))
                lst.Add(String.Format("UPDATE TRADEACTYSUMMARY SET TRADEACTYSUMMARY.SUPPINFO2 = B.COUNDESC FROM TRADEACTYSUMMARY A INNER JOIN IPMAPPING B ON " & _
                                     "A.SUPPINFO2 BETWEEN B.FROMIP AND B.TOIP {0} AND ACTY = 'LoginF'", WhereClauseForDate))
                'AddOrd
                lst.Add(String.Format("{0} SELECT B.INVESTTYPE, {1} AS ACTYDATE, B.ACCNO, 'AddOrd' AS ACTY, NULL AS SUPPINFO1, NULL AS SUPPINFO2, {2}, {3} FROM TRADEACTYLOG A " & _
                                    "INNER JOIN ({4}) B ON A.INVESTTYPE = B.INVESTTYPE AND A.ACCNO = B.ACCNO AND A.ORDERNO = B.ORDERNO AND B.ROWNUM = 1 " & _
                                    "{5} AND A.ACTYDETAIL LIKE 'Action=Add Order, RetCode=0%Status=Working%'",
                                    InsertFields, DateString.Replace("ACTYDATE", "A.ACTYDATE"), ChannelString, InsertInfoFieldValue, RowNumSql,
                                    WhereClause.Replace("INVESTTYPE", "A.INVESTTYPE").Replace("ACTYDATE", "A.ACTYDATE")))
                'Trade
                lst.Add(String.Format("{0} SELECT B.INVESTTYPE, {1} AS ACTYDATE, B.ACCNO, 'Trade' AS ACTY, " & _
                                    "SUBSTRING(A.ACTYDETAIL, CHARINDEX('Qty=', A.ACTYDETAIL) + 4,  " & _
                                    "CASE WHEN CHARINDEX(',', A.ACTYDETAIL, CHARINDEX('Qty=', A.ACTYDETAIL)) = 0 THEN LEN(A.ACTYDETAIL) ELSE " & _
                                    "CHARINDEX(',', A.ACTYDETAIL, CHARINDEX('Qty=', A.ACTYDETAIL)) - CHARINDEX('Qty=', A.ACTYDETAIL) - 4 END) AS SUPPINFO1, " & _
                                    "NULL AS SUPPINFO2, {2}, {3} FROM TRADEACTYLOG A " & _
                                    "INNER JOIN ({4}) B ON A.INVESTTYPE = B.INVESTTYPE AND A.ACCNO = B.ACCNO AND A.ORDERNO = B.ORDERNO AND B.ROWNUM = 1 " & _
                                    "{5} AND A.ACTYDETAIL LIKE 'Action=Trade%'",
                                    InsertFields, DateString.Replace("ACTYDATE", "A.ACTYDATE"), ChannelString, InsertInfoFieldValue, RowNumSql,
                                    WhereClause.Replace("INVESTTYPE", "A.INVESTTYPE").Replace("ACTYDATE", "A.ACTYDATE")))
                For Each str In lst
                    GFncRunSQL(GSCnSqlConn, MyTrans, str)
                Next
                MyTrans.Commit()
            End If
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                WriteError(ex.Message, FName)
            End If
            result = False
            Return False
        Finally
            Try
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    str = "DROP TABLE #TempTradeActyLog"
                    GFncRunSQL(GSCnSqlConn, str)
                    str = "DROP TABLE #TradeActyLogByDate"
                    GFncRunSQL(GSCnSqlConn, str)
                    MyTrans = GSCnSqlConn.BeginTransaction
                    str = "INSERT INTO ACTIONLOG VALUES ('ImpTradActy', '" & IIf(result, "Success", "Fail") & ": " & IIf(TradeType = "F", "Futures", "Stock Options") & " Trading Activity Import for " & Format(TradeDate, "dd/MM/yyyy") & " (" & ImportFileNameTrade & ")', GETDATE(), '" & GStrloginID.Replace("'", "''") & "')"
                    GFncRunSQL(GSCnSqlConn, MyTrans, str)
                    MyTrans.Commit()
                End If
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    WriteError(ex.Message, FName)
                End If
            End Try
        End Try
        Return True
    End Function

    Public Function FncValidateTradeInput(ByVal fName As String, ByRef dt As DataTable, ByVal ImpMode As String, Optional ByRef ErrorCount As Integer = 0) As String
        TradeDate = DateTime.MinValue
        TradeType = ImpMode
        Dim msg As String = ""
        Dim idx As Integer = 1
        Dim tfp As TextFieldParser = Nothing
        Dim LogTitle As String = "Run Time: " & Format(DateTime.Now, "dd/MMM/yyyy HH:mm:ss") & ", Investment Type: " & IIf(ImpMode = "F", "Futures", "Stock Options") & ", File Name: " & ImportFileNameTrade & vbCrLf
        Try
            tfp = New TextFieldParser(fName)
            ImportFileNameTrade = fName.Substring(fName.LastIndexOf("\") + 1)
            tfp.HasFieldsEnclosedInQuotes = True
            tfp.Delimiters = New String() {","}
            tfp.TextFieldType = FieldType.Delimited
            dt.Columns.Add("Errors", GetType(String))
            Thread.CurrentThread.CurrentCulture = New CultureInfo(GFncGetCulture())
            Thread.CurrentThread.CurrentUICulture = New CultureInfo(GFncGetCulture())
            While Not tfp.EndOfData
                Dim Errors As String = ""
                Dim dr As DataRow = dt.NewRow
                dr("UID") = idx
                dr("INVESTTYPE") = ImpMode
                Try
                    Dim val() As String = tfp.ReadFields()
                    If val.Length <> 5 Then
                        Errors &= "Error: Not exact 5 columns;"
                        ErrorCount += 1
                    Else
                        Dim LogDate As DateTime = GFncNoNullDateTime(val(0))
                        If LogDate = DateTime.MinValue Then
                            Errors &= "Column No.: 1, Error: Invalid Activity Date; "
                            ErrorCount += 1
                        ElseIf TradeDate = DateTime.MinValue Then
                            TradeDate = LogDate
                            If IsBatch AndAlso FncCheckExistingLog() Then
                                msg = "Record already exists."
                                ErrorCount += 1
                                Return msg
                            End If
                        ElseIf LogDate.Date <> TradeDate.Date Then
                            Errors &= "Column No.: 1, Error: Activity Date in the log file must be identical; "
                            ErrorCount += 1
                        End If
                        dr("ACTYDATE") = val(0)
                        Dim text As String = GFncNoNullString(val(1))
                        If text.Length > 20 Then
                            Errors &= "Column No.: 2, Error: User ID cannot be longer than 20 characters; "
                            ErrorCount += 1
                        End If
                        dr("USERID") = text
                        text = GFncNoNullString(val(2))
                        If text.Length > 20 Then
                            Errors &= "Column No.: 3, Error: Account No. cannot be longer than 20 characters; "
                            ErrorCount += 1
                        End If
                        dr("ACCNO") = text
                        text = GFncNoNullString(val(3))
                        If text.Length > 2000 Then
                            Errors &= "Column No.: 4, Error: Activity Details cannot be longer than 2000 characters; "
                            ErrorCount += 1
                        End If
                        dr("ACTYDETAIL") = text
                        text = GFncNoNullString(val(4))
                        If Not IsNumeric(text) Then
                            Errors &= "Column No.: 5, Error: Order No. must be numeric; "
                            ErrorCount += 1
                        Else
                            Dim OrderNo As Decimal = GFncNoNullValue(val(4))
                            If OrderNo < 0 OrElse OrderNo > 99999999999 Then
                                Errors &= "Column No.: 5, Error: Order No. must be between 0 and 99999999999; "
                                ErrorCount += 1
                            End If
                            dr("ORDERNO") = OrderNo
                        End If
                    End If
                Catch ex As Exception
                    Errors = ex.Message
                End Try
                dr("Errors") = Errors
                If Errors <> "" Then
                    Errors = "Row No.: " & idx & ", " & Errors & vbCrLf
                    msg += Errors
                End If
                dr("UID") = DBNull.Value
                dt.Rows.Add(dr)
                idx += 1
            End While
            dt.Columns.Remove("Errors")
            If msg <> "" Then
                msg = LogTitle & msg
            End If
        Catch ex As Exception
            msg = ex.Message
        Finally
            tfp.Dispose()
            tfp.Close()
        End Try
        Return msg
    End Function

#End Region

#Region "Reports"

    Public Function FncGetValueForDropDown(ByVal vType As String) As DataTable
        Dim str As String = "SELECT * FROM VALUELIST WHERE ISACTIVE = 1 AND VALLST = '" & vType.Replace("'", "''") & "' ORDER BY DISPSEQ ASC"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function FncGetReportCriteria(ByVal rpt As String, Optional ByVal code As String = "") As DataTable
        Dim str As String = "SELECT [UID], MODULE, PARACODE, PARADESC, PARAVAL, VALTYPE, MINVAL, MAXVAL, DISPSEQ FROM SYSTEMPARAMETER WHERE MODULE = '" & _
            rpt.Replace("'", "''") & "'" & IIf(code = "", "", " AND PARACODE = '" & code.Replace("'", "''") & "'") & " ORDER BY MODULE ASC, DISPSEQ ASC"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            Return ds.Tables(0)
        Else
            Return Nothing
        End If
    End Function

    Public Function FncGetReportParameters(ByVal rpt As String, ByVal code As String, Optional ByVal defaultValue As String = "") As String
        Dim dt As DataTable = FncGetReportCriteria(rpt, code)
        Dim result As String = defaultValue
        If dt IsNot Nothing AndAlso dt.Rows.Count > 0 Then
            result = GFncNoNullString(dt.Rows(0)("PARAVAL"))
        End If
        Return result
    End Function

    Public Function FncWriteReportHeader(ByVal rpt As String, ByVal channel As String) As String
        Dim result As String = """"
        Dim temp(7) As String
        temp(0) = "Report Date"
        temp(1) = "Account No."
        temp(5) = ""
        temp(6) = ""
        temp(7) = ""
        Dim ChannelHeaders(2) As String
        If channel = "B" Then
            ChannelHeaders(0) = "Internet and Phone"
            ChannelHeaders(1) = "Internet"
            ChannelHeaders(2) = "Phone"
        ElseIf channel = "I" Then
            ChannelHeaders(0) = "Internet"
            ChannelHeaders(1) = "Phone"
            ChannelHeaders(2) = "Internet and Phone"
        ElseIf channel = "P" Then
            ChannelHeaders(0) = "Phone"
            ChannelHeaders(1) = "Internet"
            ChannelHeaders(2) = "Internet and Phone"
        End If
        Select Case rpt
            Case "RptAlt01"
                temp(2) = "Number of Orders in Report Date (Internet)"
                temp(3) = "Average Number of Orders (" & ChannelHeaders(0) & ")"
                temp(4) = "Average Number of Orders (" & ChannelHeaders(1) & ")"
                temp(5) = "Average Number of Orders (" & ChannelHeaders(2) & ")"
                temp(6) = "Trading Channel"
            Case "RptAlt02"
                temp(2) = "Number of Order Quantities in Report Date (Internet)"
                temp(3) = "Average Number of Order Quantities (" & ChannelHeaders(0) & ")"
                temp(4) = "Average Number of Order Quantities (" & ChannelHeaders(1) & ")"
                temp(5) = "Average Number of Order Quantities (" & ChannelHeaders(2) & ")"
                temp(6) = "Trading Channel"
            Case "RptAlt03"
                temp(2) = "Number of Orders in Report Date (Internet)"
                temp(3) = "Last Order Made Date (" & ChannelHeaders(0) & ")"
                temp(4) = "Last Order Made Date (" & ChannelHeaders(1) & ")"
                temp(5) = "Last Order Made Date (" & ChannelHeaders(2) & ")"
                temp(6) = "Trading Channel"
            Case "RptAlt04"
                temp(2) = "1st Login Date / Time"
                temp(3) = "IP address of 1st Login"
                temp(4) = "Country / Territory of 1st Login"
                temp(5) = "2nd Login Date / Time"
                temp(6) = "IP address of 2nd Login"
                temp(7) = "Country / Territory of 2nd Login"
            Case "RptAlt05"
                temp(2) = "Count of Login Failure"
                temp(3) = ""
                temp(4) = ""
        End Select
        result = String.Format("""{0}""", String.Join(""",""", temp.Select(Function(v) v.Replace("""", """""")).Where(Function(v) v <> "")))
        Return result
    End Function

    Public Sub WriteReportLog(ByVal TradeType As String, ByVal rpt As String, ByVal para As String, ByVal result As Boolean)
        Dim MyTrans As SqlTransaction = Nothing
        Dim str As String = "INSERT INTO ACTIONLOG VALUES ('GenerateReport', '" & IIf(result, "Success", "Fail") & ": " & IIf(TradeType = "F", "Futures", "Stock Options") & " Trading Activity Import for " & Format(TradeDate, "dd/MM/yyyy") & " (" & ImportFileNameTrade & ")', GETDATE(), '" & GStrloginID.Replace("'", "''") & "')"
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            str = "INSERT INTO ACTIONLOG VALUES ('SurveilRpt', '" & IIf(result, "Success", "Fail") & ": " & IIf(TradeType = "F", "Futures", "Stock Options") & rpt & ", (" & para & ")', GETDATE(), '" & GStrloginID.Replace("'", "''") & "')"
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
            MyTrans.Commit()
        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                WriteError(ex.Message)
            End If
        End Try
    End Sub

    Public Function FncGetReport(ByVal TradeMod As String, ByVal rpt As String, ByVal day As DateTime, ByVal channel As String) As DataTable
        Dim dt As DataTable = Nothing
        Dim PreSqls As New List(Of String)
        Dim PostSqls As New List(Of String)
        Dim MainSql As String = ""
        Dim JoinSql As String = ""
        Dim TradeDateStr As String = String.Format("'{0}' tradedate, ", String.Format(Format(day, "{0} dd, yyyy"), lFncGetMonthString(day.Month)))
        Dim ChannelStr As String = ""
        Dim AdWhereTmpt As String = " and actydate between {0} and {1}"
        Dim ChIvWhereClause1 As String = String.Format("{0} and investtype = '{1}'", IIf(channel = "B", "", " and channel = '" & channel & "'"), TradeMod)
        Dim ChIvWhereClause2 As String = ""
        Dim ChIvWhereClause3 As String = ""
        Dim IvAdWhereClause = String.Format(" and investtype = '{0}' and actydate between {1} and {2}", TradeMod,
                                            "convert(datetime, '" & day.ToString("yyyy/MM/dd 00:00:00") & "')",
                                            "convert(datetime, '" & day.ToString("yyyy/MM/dd 23:59:59") & "')")
        If channel = "B" Then
            ChannelStr = "Both"
            ChIvWhereClause2 = String.Format(" and channel = 'I' and investtype = '{0}'", TradeMod)
            ChIvWhereClause3 = String.Format(" and channel = 'P' and investtype = '{0}'", TradeMod)
        ElseIf channel = "I" Then
            ChannelStr = "Internet"
            ChIvWhereClause2 = String.Format(" and channel = 'P' and investtype = '{0}'", TradeMod)
            ChIvWhereClause3 = String.Format(" and investtype = '{0}'", TradeMod)
        ElseIf channel = "P" Then
            ChannelStr = "Phone"
            ChIvWhereClause2 = String.Format(" and channel = 'I' and investtype = '{0}'", TradeMod)
            ChIvWhereClause3 = String.Format(" and investtype = '{0}'", TradeMod)
        End If
        Select Case rpt
            Case "RptAlt01"
                Dim OrderTimes As Integer = GFncNoNullIntValue(FncGetReportParameters(rpt, "OrdRatio", "1"))
                Dim CountDays As Integer = GFncNoNullIntValue(FncGetReportParameters(rpt, "AvgForDay", "1"))
                Dim AdWhereClause As String = String.Format(AdWhereTmpt, "convert(datetime, '" & day.AddDays(CountDays * (-1)).ToString("yyyy/MM/dd 00:00:00") & "')",
                                                                    "convert(datetime, '" & day.AddDays(-1).ToString("yyyy/MM/dd 23:59:59") & "')")
                JoinSql = " left join (select accno, count(1) cnt, count(distinct dateadd(day, datediff(dd, 0, actydate), 0)) daycnt, " & _
                    "count(1)/cast(count(distinct dateadd(day, datediff(dd, 0, actydate), 0)) as numeric(10,2)) average " & _
                    "from TradeActySummary where acty = 'AddOrd'{0}{1} group by accno) {2} on a.accno = {2}.accno"
                JoinSql = String.Format("{0}{1}{2}", String.Format(JoinSql, ChIvWhereClause1, AdWhereClause, "b"),
                                           String.Format(JoinSql, ChIvWhereClause2, AdWhereClause, "c"),
                                           String.Format(JoinSql, ChIvWhereClause3, AdWhereClause, "d"))
                MainSql = String.Format("select {0}a.accno, a.cnt, isnull(b.average, 0), isnull(c.average, 0), isnull(d.average, 0), '" & ChannelStr & "' channel from " & _
                    "(select accno, count(1) cnt from TradeActySummary where acty = 'AddOrd' and channel = 'I'{1} group by accno) a{2} " & _
                    "where a.cnt > isnull(b.average, 0) * {3} order by a.accno",
                    TradeDateStr, IvAdWhereClause, JoinSql, OrderTimes)
            Case "RptAlt02"
                Dim OrderTimes As Integer = GFncNoNullIntValue(FncGetReportParameters(rpt, "QtyRatio", "1"))
                Dim CountDays As Integer = GFncNoNullIntValue(FncGetReportParameters(rpt, "AvgForDay", "1"))
                Dim AdWhereClause As String = String.Format(AdWhereTmpt, "convert(datetime, '" & day.AddDays(CountDays * (-1)).ToString("yyyy/MM/dd 00:00:00") & "')",
                                                                    "convert(datetime, '" & day.AddDays(-1).ToString("yyyy/MM/dd 23:59:59") & "')")
                JoinSql = " left join (select accno, sum(cast(suppinfo1 as numeric(10,2))) cnt, count(distinct dateadd(day, datediff(dd, 0, actydate), 0)) daycnt, " & _
                    "sum(cast(suppinfo1 as numeric(10,2)))/cast(count(distinct dateadd(day, datediff(dd, 0, actydate), 0)) as numeric(10,2)) average " & _
                    "from TradeActySummary where acty = 'Trade'{0}{1} group by accno) {2} on a.accno = {2}.accno"
                JoinSql = String.Format("{0}{1}{2}", String.Format(JoinSql, ChIvWhereClause1, AdWhereClause, "b"),
                                           String.Format(JoinSql, ChIvWhereClause2, AdWhereClause, "c"),
                                           String.Format(JoinSql, ChIvWhereClause3, AdWhereClause, "d"))
                MainSql = String.Format("select {0}a.accno, a.cnt, isnull(b.average, 0), isnull(c.average, 0), isnull(d.average, 0), '" & ChannelStr & "' channel from " & _
                    "(select accno, count(1) cnt from TradeActySummary where acty = 'Trade' and channel = 'I'{1} group by accno) a{2} " & _
                    "where a.cnt > isnull(b.average, 0) * {3} order by a.accno",
                    TradeDateStr, IvAdWhereClause, JoinSql, OrderTimes)
            Case "RptAlt03"
                Dim ResumeDays As Integer = GFncNoNullIntValue(FncGetReportParameters(rpt, "NoTradInDay", "0"))
                JoinSql = " left join (select accno, max(actydate) maxday " & _
                   "from TradeActySummary where acty = 'AddOrd'{0} and actydate < convert(datetime, '" & day.ToString("yyyy/MM/dd 00:00:00") & "') group by accno) {1} on a.accno = {1}.accno"
                JoinSql = String.Format("{0}{1}{2}", String.Format(JoinSql, ChIvWhereClause1, "b"),
                                           String.Format(JoinSql, ChIvWhereClause2, "c"),
                                           String.Format(JoinSql, ChIvWhereClause3, "d"))
                MainSql = String.Format("select {0}a.accno, a.cnt, isnull(convert(varchar, b.maxday, 120), 'n/a'), isnull(convert(varchar, c.maxday, 120), 'n/a'), isnull(convert(varchar, d.maxday, 120), 'n/a'), '" & ChannelStr & "' channel from " & _
                   "(select accno, count(1) cnt from TradeActySummary where acty = 'AddOrd' and channel = 'I'{1} group by accno) a{2} " & _
                   "where dateadd(day, {3}, {4}) > isnull(b.maxday, convert(datetime, '1900/01/01 00:00:00')) order by a.accno",
                   TradeDateStr, IvAdWhereClause, JoinSql, ResumeDays * (-1), "convert(datetime, '" & day.ToString("yyyy/MM/dd 00:00:00") & "')")
            Case "RptAlt04"
                Dim seconds As Integer = GFncNoNullIntValue(FncGetReportParameters(rpt, "TimeIntvl", "0"))
                Dim AdWhereClause1 As String = String.Format(AdWhereTmpt, "convert(datetime, '" & day.ToString("yyyy/MM/dd 00:00:00") & "')",
                                                                    "convert(datetime, '" & day.ToString("yyyy/MM/dd 23:59:59") & "')")
                Dim AdWhereClause2 As String = String.Format(AdWhereTmpt, "convert(datetime, '" & day.ToString("yyyy/MM/dd 00:00:00") & "')",
                                                                    "convert(datetime, '" & day.AddDays(1).AddSeconds(seconds - 1).ToString("yyyy/MM/dd HH:mm:ss") & "')")
                Dim IvAdWhereClause1 As String = String.Format(" and investtype = '{0}'{1}", TradeMod, AdWhereClause1)
                Dim IvAdWhereClause2 As String = String.Format(" and investtype = '{0}'{1}", TradeMod, AdWhereClause2)
                Dim TabForRowNumSql As String = "select identity(int, 1, 1) as uidbydate, investtype, actydate, accno, acty, suppinfo1, suppinfo2 into #TradeActySummaryByDate{0} from " & _
                    "TradeActySummary where acty = 'LoginS'{1} order by actydate, uid"
                PreSqls.Add(String.Format(TabForRowNumSql, "1", IvAdWhereClause1))
                PreSqls.Add(String.Format(TabForRowNumSql, "2", IvAdWhereClause2))
                Dim RowNumSql As String = "select *, (select count(1) from #TradeActySummaryByDate{0} tmp " & _
                    "where tmp.accno = rn.accno and tmp.uidbydate <= rn.uidbydate) as rownum from #TradeActySummaryByDate{0} rn"
                MainSql = String.Format("select {0}a.accno, convert(varchar, a.actydate, 120) actydate1, a.suppinfo1 ip1, a.suppinfo2 ds1, convert(varchar, b.actydate, 120) actydate2, b.suppinfo1 ip2, b.suppinfo2 ds2 from " & _
                    "({1}) a inner join ({2}) b " & _
                    "on a.accno = b.accno and a.rownum = b.rownum - 1 and dateadd(second, {3}, a.actydate) >= b.actydate and a.suppinfo2 <> b.suppinfo2 order by a.accno asc, a.rownum asc",
                    TradeDateStr, String.Format(RowNumSql, "1"), String.Format(RowNumSql, "2"), seconds)
                PostSqls.Add("drop table #TradeActySummaryByDate1")
                PostSqls.Add("drop table #TradeActySummaryByDate2")
            Case "RptAlt05"
                MainSql = String.Format("select {0}accno, count(1) cnt from TradeActySummary where acty = 'LoginF'{1} group by accno order by count(1) desc, accno asc",
                    TradeDateStr, IvAdWhereClause)
        End Select
        If PreSqls.Count > 0 Then
            For Each Str As String In PreSqls
                GFncRunSQL(GSCnSqlConn, Str)
            Next
        End If
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, MainSql)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 Then
            dt = ds.Tables(0)
        End If
        If PostSqls.Count > 0 Then
            For Each Str As String In PostSqls
                GFncRunSQL(GSCnSqlConn, Str)
            Next
        End If
        Return dt
    End Function

#End Region

#Region "Batch"

    Public EventPath As String = GStrEPath

    Public Sub WriteError(ByVal str As String, Optional ByVal FName As String = "")
        If IsBatch Then
            GSubWriteEventLog(str, EventPath, FName)
        Else
            GSubWriteELog(str)
        End If
    End Sub

    Public Function FncHouseKeep(ByVal days As Integer) As Long
        Dim MyTrans As SqlTransaction = Nothing
        Dim result As Long = 0
        Dim flag As Boolean = True
        Dim WhereClause As String = String.Format(" WHERE ACTYDATE < DATEADD(day, {0}, GETDATE())", days * (-1))
        Dim str As String = String.Format("INSERT INTO TRADEACTYSUMMARYARCH (INVESTTYPE, ACTYDATE, ACCNO, ACTY, SUPPINFO1, SUPPINFO2, CHANNEL, CREATEDON, CREATEDBYID) " & _
            "SELECT INVESTTYPE, ACTYDATE, ACCNO, ACTY, SUPPINFO1, SUPPINFO2, CHANNEL, CREATEDON, CREATEDBYID FROM TRADEACTYSUMMARY{0}", WhereClause)
        Try
            MyTrans = GSCnSqlConn.BeginTransaction
            result = GFncRunSQL(GSCnSqlConn, MyTrans, str)
            str = String.Format("DELETE FROM TRADEACTYSUMMARY{0}", WhereClause)
            GFncRunSQL(GSCnSqlConn, MyTrans, str)
            MyTrans.Commit()
        Catch ex As Exception
            flag = False
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                WriteError(ex.Message)
            End If
        Finally
            Try
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    MyTrans = GSCnSqlConn.BeginTransaction
                    str = "INSERT INTO ACTIONLOG VALUES ('Housekeep', '" & IIf(flag, "Success", "Fail") & ": Housekeep of Trading Activity Summary for data earlier than ' + CONVERT(VARCHAR, DATEADD(day, " & days * (-1) & ", GETDATE()), 103), GETDATE(), '" & GStrloginID.Replace("'", "''") & "')"
                    GFncRunSQL(GSCnSqlConn, MyTrans, str)
                    MyTrans.Commit()
                End If
            Catch ex As Exception
                If GSCnSqlConn.State <> ConnectionState.Closed Then
                    If (MyTrans IsNot Nothing) Then
                        MyTrans.Rollback()
                    End If
                    WriteError(ex.Message)
                End If
            End Try
        End Try
        Return result
    End Function

#End Region

#Region "Email"

    Public Function FncLoadEmailSndr() As String
        Dim str As String = String.Format("SELECT PARAVAL FROM SYSTEMPARAMETER WHERE MODULE = 'ESL' AND PARACODE = 'EmailSndr'")
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            Return GFncNoNullString(ds.Tables(0).Rows(0)("PARAVAL"))
        Else
            Return ""
        End If
    End Function

#End Region

End Class
