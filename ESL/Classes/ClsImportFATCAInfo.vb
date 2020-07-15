Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions

Public Class ClsImportFATCAInfo
    Protected Friend rowIndex As Integer
    Protected Friend currClientType As String
    Protected Friend currAccNo As String
    Protected Friend dtFatcaType As DataTable
    Protected Friend dtClientType As DataTable

    Protected Friend Function lFncGetFATCAInfoFromExcel(ByVal filename As String) As DataTable
        Dim xlApp As Object = CreateObject("Excel.Application") 'Excel.Application
        Dim xlWorkBook As Object = xlApp.Workbooks.Open(filename) 'Excel.Workbook
        Dim xlWorkSheet As Object = Nothing 'Excel.Worksheet
        Dim range As Object = Nothing
        'Dim ECnt As Integer = Nothing
        Dim dt As DataTable = New dtsStagingClientMaster.FATCAInfoDataTable
        Try
            xlWorkSheet = xlWorkBook.Worksheets
            If xlWorkSheet.Count >= 1 Then
                range = xlWorkSheet(1).UsedRange
                If range.columns.count >= 25 Then
                    For rowIndex = 2 To range.rows.count
                        If (Not String.IsNullOrEmpty(GFncNoNullString(range.Cells(rowIndex, 1).value).Trim)) Then
                            Dim dr As DataRow = dt.NewRow

                            dr("acc_no") = FncCheckAccountNo(range.Cells(rowIndex, 1).value).Trim
                            dr("client_type") = FncCheckClientType(range.Cells(rowIndex, 6).value).Trim
                            dr("FATCA_acc_type") = FncCheckFatcaType(range.Cells(rowIndex, 7).value)
                            dr("us_passport_holder") = FncCheckFatcaYNInput("us_passport_holder", range.Cells(rowIndex, 17).value)
                            dr("us_citizen") = FncCheckFatcaYNInput("us_citizen", range.Cells(rowIndex, 11).value)
                            dr("us_born") = FncCheckFatcaYNInput("us_born", range.Cells(rowIndex, 12).value)
                            dr("us_address") = FncCheckFatcaYNInput("us_address", range.Cells(rowIndex, 13).value)
                            dr("us_phone") = FncCheckFatcaYNInput("us_phone", range.Cells(rowIndex, 14).value)
                            dr("us_fund_transfer") = FncCheckFatcaYNInput("us_fund_transfer", range.Cells(rowIndex, 15).value)
                            dr("us_auth_person") = FncCheckFatcaYNInput("us_auth_person", range.Cells(rowIndex, 16).value)
                            dr("us_review_date") = GetFormattedDate(range.Cells(rowIndex, 19).value)
                            dr("us_tin") = GFncNoNullString(range.Cells(rowIndex, 18).value).Trim
                            dr("FATCA_Remarks") = GFncNoNullString(range.Cells(rowIndex, 20).value).Trim
                            dr("FATCA_GIIN") = GFncNoNullString(range.Cells(rowIndex, 21).value).Trim
                            dr("w8_form_signed") = FncCheckFatcaYNInput("w8_form_signed", range.Cells(rowIndex, 8).value)
                            dr("w8_form_date") = If((dr("w8_form_signed") = "Y"), GetFormattedDate(range.Cells(rowIndex, 9).value), "1900-01-01")
                            dt.Rows.Add(dr)
                        End If
                    Next
                Else
                    Throw New ArgumentException("Number of columns not match")
                End If
            Else
                Throw New ArgumentException("No sheet is found")
            End If
        Catch ex As Exception
            currAccNo = GFncNoNullString(range.Cells(rowIndex, 1).value)
            currClientType = GFncNoNullString(range.Cells(rowIndex, 6).value)
            GC.Collect()
            'GSubShowError(ex.Message)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            releaseObject(range)
            dt = Nothing
            GSubWriteErrLog(Environment.NewLine & "Error: " & ex.Message & Environment.NewLine & "In Row:" & rowIndex & " for AccNo:" & currAccNo & " and Client Type:" & currClientType)
        End Try
        xlWorkBook.Close()
        xlApp.Quit()
        releaseObject(xlApp)
        releaseObject(xlWorkBook)
        releaseObject(xlWorkSheet)
        releaseObject(range)
        Return dt
    End Function

    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
            GC.WaitForPendingFinalizers()
            GC.Collect()
            GC.WaitForPendingFinalizers()
        End Try
    End Sub

    Protected Friend Function lFncUploadData(ByVal dt As DataTable, ByVal TDate As DateTime, ByVal isImported As Boolean)
        Dim MyTrans As SqlTransaction = Nothing
        Dim counter As Integer = 0
        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            If (isImported) Then
                FncClearImportedData(MyTrans, TDate)
            End If

            For Each row As Object In dt.Rows
                lFncUploadFATCAData(row, TDate, MyTrans)
                counter += 1
            Next

            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
            End If
            GSubWriteErrLog("Insert Error in Record (Acc: " & dt(counter).Item("acc_no") & " AccType: " & dt(counter).Item("client_type") & ")  " & ex.Message)
        End Try

        Return Nothing
    End Function

    Protected Friend Function lFncUploadFATCAData(ByVal row As Object, ByVal TDate As DateTime, ByVal MyTrans As SqlTransaction) As Boolean

        Dim lstrSQL As String

        lstrSQL = "INSERT INTO [dbo].[staging_client_master] " & _
        "           ([acc_no] " & _
        "           ,[client_type] " & _
        "           ,[FATCA_acc_type] " & _
        "           ,[w8_form_signed] " & _
        "           ,[w8_form_date] " & _
        "           ,[us_passport_holder] " & _
        "           ,[us_citizen] " & _
        "           ,[us_born] " & _
        "           ,[us_address] " & _
        "           ,[us_phone] " & _
        "           ,[us_fund_transfer] " & _
        "           ,[us_auth_person] " & _
        "           ,[us_review_date] " & _
        "           ,[us_tin] " & _
        "           ,[w8_form_expiry_date] " & _
        "           ,[FATCA_Remarks] " & _
        "           ,[FATCA_GIIN] " & _
        "           ,[userID] " & _
        "           ,[TradeDate] " & _
        "           ,[LastUpdateDate]) " & _
        "     VALUES " & _
        "           ( " & _
        "           '" & row("acc_no") & "'," & _
        "           '" & row("client_type") & "'," & _
        "           '" & row("FATCA_acc_type") & "'," & _
        "           '" & row("w8_form_signed") & "'," & _
        "           '" & row("w8_form_date") & "'," & _
        "           '" & row("us_passport_holder") & "'," & _
        "           '" & row("us_citizen") & "'," & _
        "           '" & row("us_born") & "'," & _
        "           '" & row("us_address") & "'," & _
        "           '" & row("us_phone") & "'," & _
        "           '" & row("us_fund_transfer") & "'," & _
        "           '" & row("us_auth_person") & "'," & _
        "           '" & row("us_review_date") & "'," & _
        "           '" & row("us_tin") & "', " & _
        "           CASE '" & row("w8_form_signed") & "' " & _
        "                WHEN 'Y' THEN CAST(DATEPART(yyyy, DATEADD(YEAR, 3, '" & row("w8_form_date") & "')) AS varchar) + '-12-31' " & _
        "                ELSE '1900-01-01' " & _
        "           END, " & _
        "           '" & row("FATCA_Remarks").replace("'", "''") & "'," & _
        "           '" & row("FATCA_GIIN") & "'," & _
        "           '" & GStrloginID & "'," & _
        "           '" & Format(TDate, "yyyy-MM-dd") & "'," & _
        "           GETDATE() " & _
        "           )"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Function GetFormattedDate(ByVal strDate As String) As String
        Dim dateTemp As Date = Nothing
        If (String.IsNullOrEmpty(strDate)) Then
            dateTemp = CDate("1900/01/01")
        Else
            Try
                dateTemp = CDate(strDate)
            Catch ex As Exception
                dateTemp = CDate("1900/01/01")
            End Try
        End If
        Return Format(dateTemp, "yyyy-MM-dd")
    End Function

    Protected Friend Function lFncTradeDateFromDB() As DateTime
        Dim lstrSQL As String
        Dim lds As DataSet
        Dim g2bs As String() = GStrG2BSDB.Split(".")

        lstrSQL = "SELECT result FROM OPENQUERY(" & g2bs(0) & ", 'SET NOCOUNT ON; SET FMTONLY OFF; EXEC [" & g2bs(1) & "].[dbo].s_IT_GetNextTradeDate ''SEHK'',''" & Format(GDteTradeDate, "yyyy-MM-dd") & "''')"

        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

        Return lds.Tables(0).Rows(0).Item("result")
    End Function

    Protected Friend Function lFncTradeDateImported(ByVal trade_date As DateTime) As Boolean
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = " SELECT 1 FROM staging_client_master WHERE TradeDate = '" & Format(trade_date, "yyyy-MM-dd") & "' AND userID = '" & GStrloginID & "' "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)
        Return (lds.Tables(0).Rows.Count > 0)
    End Function

    Protected Friend Sub FncClearImportedData(ByVal MyTrans As SqlTransaction, ByVal trade_date As DateTime)
        Dim lstrSQL As String = ""

        lstrSQL = " DELETE FROM staging_client_master WHERE TradeDate = '" & Format(trade_date, "yyyy-MM-dd") & "' AND userID = '" & GStrloginID & "' "

        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL)
    End Sub

    Function FncGetValidFatcaType() As DataTable
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "SELECT CharValue as ValidFatcaType FROM SystemStaticParam WHERE ParamType = 'FATCAAccType' Order by CharValue"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

        Return lds.Tables(0)
    End Function

    Function FncGetValidClientType() As DataTable
        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "SELECT CharValue as ValidClientType FROM SystemStaticParam WHERE ParamType = 'ClientType' Order by CharValue"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

        Return lds.Tables(0)
    End Function

    Function FncCheckFatcaType(ByVal strObj As Object) As String
        Dim lstrClientType As String = GFncNoNullString(strObj).Trim

        Dim temRow() As DataRow = dtFatcaType.Select("ValidFatcaType='" + lstrClientType + "'")

        If (temRow.Count > 0 Or lstrClientType = "") Then
            Return temRow(0).Item("ValidFatcaType").ToString()
        Else

            Dim lstrValidType As String = ""
            For Each row As DataRow In dtFatcaType.Rows
                lstrValidType = lstrValidType + row.Item("ValidFatcaType") + ","
            Next row

            Throw New ArgumentException("Invalid FATCA type: " & lstrClientType & Environment.NewLine & "Valid Type: " & If(lstrValidType.EndsWith(","), lstrValidType.Substring(0, lstrValidType.Length - 1), lstrValidType))

        End If
    End Function

    Function FncCheckFatcaYNInput(ByVal strType As String, ByVal strObj As Object) As String
        Dim lstrYN As String = GFncNoNullString(strObj).Trim

        If lstrYN = "Y" Or lstrYN = "N" Or lstrYN = "" Then
            Return lstrYN
        Else
            Throw New ArgumentException("Invalid " & strType & ": " & lstrYN & Environment.NewLine & "It should be Y/N or empty")
        End If
    End Function

    Function FncCheckClientType(ByVal strObj As Object) As String
        Dim lstrClientType As String = GFncNoNullString(strObj).Trim

        Dim temRow() As DataRow = dtClientType.Select("ValidClientType='" + lstrClientType + "'")

        If (temRow.Count > 0 Or lstrClientType = "") Then
            Return temRow(0).Item("ValidClientType").ToString()
        Else

            Dim lstrValidType As String = ""
            For Each row As DataRow In dtClientType.Rows
                lstrValidType = lstrValidType + row.Item("ValidClientType") + ","
            Next row

            Throw New ArgumentException("Invalid Client type: " & lstrClientType & Environment.NewLine & "Valid Type: " & If(lstrValidType.EndsWith(","), lstrValidType.Substring(0, lstrValidType.Length - 1), lstrValidType))

        End If
    End Function

    Function FncCheckAccountNo(ByVal strObj As Object) As String
        Dim lstrAcc As String = GFncNoNullString(strObj).Trim

        If Regex.IsMatch(lstrAcc, "^[0-9]{8}$") Then
            Return lstrAcc
        Else
            Throw New ArgumentException("Invalid Account Number: " & lstrAcc & Environment.NewLine & "Account no. only allow 8 digit number without any special characters")
        End If
    End Function
End Class
