Imports System.Data.SqlClient
Imports System.IO
Imports System.Text.RegularExpressions
Imports System.Text.RegularExpressions.Regex

Public Class ClsImportCRSInfo
    Protected Friend rowIndex As Integer
    Protected Friend currClientType As String
    Protected Friend currAccNo As String

    Protected Friend Function lFncGetCRSInfoFromExcel(ByVal filename As String) As DataTable
        Dim xlApp As Object = CreateObject("Excel.Application") 'Excel.Application
        Dim xlWorkBook As Object = xlApp.Workbooks.Open(filename) 'Excel.Workbook
        Dim xlWorkSheet As Object = Nothing 'Excel.Worksheet
        Dim range As Object = Nothing
        'Dim ECnt As Integer = Nothing
        Dim dt As DataTable = New DataTable("NEXT-OSS")
        Dim column As DataColumn
        ' Create first column and add to the DataTable.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "accno_org"
        column.AutoIncrement = False
        column.ReadOnly = False
        column.Unique = False
        dt.Columns.Add(column)

        ' Create second column and add to the DataTable.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "accno_map"
        column.AutoIncrement = False
        column.ReadOnly = False
        column.Unique = False
        dt.Columns.Add(column)

        ' Create third column.
        column = New DataColumn()
        column.DataType = System.Type.GetType("System.String")
        column.ColumnName = "cfbal"
        column.AutoIncrement = False
        column.ReadOnly = False
        column.Unique = False
        dt.Columns.Add(column)

        Try
            xlWorkSheet = xlWorkBook.Worksheets
            If xlWorkSheet.Count >= 1 Then
                range = xlWorkSheet(1).UsedRange
                If range.columns.count >= 13 Then
                    If range.Cells(1, 1).value.ToString.Trim = "Client Code" Then
                    Else
                        FrmImportCRSInfo.runFnc("Missing Client Code")
                        MessageBox.Show("Missing Client Code", "NEXT-OSS Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Throw New ArgumentException("Number of columns not match")
                    End If
                    If range.Cells(1, 13).value.ToString.Trim = "C/F" Then
                    Else
                        FrmImportCRSInfo.runFnc("Missing C/F")
                        MessageBox.Show("Missing C/F", "NEXT-OSS Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        Throw New ArgumentException("Number of columns not match")
                    End If
                    For rowIndex = 2 To range.rows.count
                        If IsEigitDigit(range.Cells(rowIndex, 1).value.Trim.Substring(0, 8)) And IsDollarAmount(range.Cells(rowIndex, 13).value) Then
                        Else
                            FrmImportCRSInfo.runFnc("Datatype Error: In Row: " & rowIndex)
                            MessageBox.Show("Datatype Error: In Row: " & rowIndex, "NEXT-OSS Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                            Throw New ArgumentException("Datatype Error")
                        End If
                        If (Not String.IsNullOrEmpty(GFncNoNullString(range.Cells(rowIndex, 1).value).Trim)) Then
                            Dim dr As DataRow = dt.NewRow
                            dr("accno_org") = range.Cells(rowIndex, 1).value.Trim.Substring(0, 8)
                            dr("accno_map") = "800" & range.Cells(rowIndex, 1).value.Trim.Substring(3, 5)
                            dr("cfbal") = range.Cells(rowIndex, 13).value
                            dt.Rows.Add(dr)
                        End If
                        FrmImportCRSInfo.runFnc(range.Cells(rowIndex, 1).value.ToString.Trim.Substring(0, 8) & " handled")
                    Next
                Else
                    FrmImportCRSInfo.runFnc("Number of columns not match")
                    MessageBox.Show("Number of columns not match", "NEXT-OSS Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    Throw New ArgumentException("Number of columns not match")
                End If
            Else
                FrmImportCRSInfo.runFnc("No sheet is found")
                MessageBox.Show("No sheet is found", "NEXT-OSS Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Throw New ArgumentException("No sheet is found")
            End If
        Catch ex As Exception
            currAccNo = GFncNoNullString(range.Cells(rowIndex, 1).value)
            GC.Collect()
            'GSubShowError(ex.Message)
            xlWorkBook.Close()
            xlApp.Quit()
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            releaseObject(range)
            dt = Nothing
            'GSubWriteELog(Environment.NewLine & "Error: " & ex.Message & Environment.NewLine & "In Row:" & rowIndex & " for AccNo:" & currAccNo)
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

    Protected Friend Function lFncUploadData(ByVal dt As DataTable, ByVal isImported As Boolean)
        Dim MyTrans As SqlTransaction = Nothing
        Dim counter As Integer = 0
        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            If (isImported) Then
                FncClearImportedData(MyTrans)
            End If

            For Each row As Object In dt.Rows
                lFncUploadSOData(row, MyTrans)
                counter += 1
            Next

            lFncUploadActionLog(MyTrans)

            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
            End If
            GSubWriteELog("Insert Error in Record (Acc: " & dt(counter).Item("accno_org") & " " & ex.Message)
        End Try

        Return Nothing
    End Function

    Protected Friend Function lFncUploadSOData(ByVal row As Object, ByVal MyTrans As SqlTransaction) As Boolean

        Dim lstrSQL As String

        lstrSQL = "INSERT INTO [dbo].[temp_stock_option_bal] " & _
        "           ([accno_org] " & _
        "           ,[accno_map] " & _
        "           ,[cfbal] " & _
        "           ,[tdate]) " & _
        "     VALUES " & _
        "           ( " & _
        "           '" & row("accno_org") & "'," & _
        "           '" & row("accno_map") & "'," & _
        "           '" & row("cfbal") & "'," & _
        "           GETDATE() " & _
        "           )"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFncUploadActionLog(ByVal MyTrans As SqlTransaction) As Boolean

        Dim lstrSQL As String

        lstrSQL = "INSERT INTO [dbo].[ACTIONLOG] VALUES ('ImportCRSInfo', 'ImportCRSInfo', GETDATE(), '" & GStrloginID.Replace("'", "''") & "')"

        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Public Function FncGetActionLog() As String
        Dim str As String = "SELECT TOP 1 CreatedById, CreatedOn FROM ACTIONLOG WHERE [ACTION] = 'ImportCRSInfo' ORDER BY CREATEDON DESC"
        Dim ds As DataSet = GFncRtnDS(GSCnSqlConn, str)
        Dim result As String = ""
        If ds IsNot Nothing AndAlso ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
            result = GFncNoNullString(ds.Tables(0).Rows(0)("CreatedById")) & " on " & GFncNoNullString(ds.Tables(0).Rows(0)("CreatedOn"))
        End If
        Return result
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

    Protected Friend Sub FncClearImportedData(ByVal MyTrans As SqlTransaction)
        Dim lstrSQL As String = ""

        lstrSQL = " DELETE FROM temp_stock_option_bal"

        GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL)
    End Sub

    Function IsEigitDigit(ByVal eigitdigit As String) As Boolean
        Static eigitdigitExpression As New Regex("^[0-9]{8}$")
        Return eigitdigitExpression.IsMatch(eigitdigit)
    End Function

    Function IsDollarAmount(ByVal dollaramount As String) As Boolean
        Static dollaramountExpression As New Regex("^[0-9]+(\.[0-9]{0,2})?$")
        Return dollaramountExpression.IsMatch(dollaramount)
    End Function

    Function IsCountryCode(ByVal countrycode As String) As Boolean
        Static countrycodeExpression As New Regex("^[A-Z]{2}$")
        Return countrycodeExpression.IsMatch(countrycode)
    End Function

End Class
