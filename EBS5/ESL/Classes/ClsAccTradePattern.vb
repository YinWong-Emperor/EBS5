Imports System.IO

Public Class ClsAccTradePattern

    Protected Friend Function lFncGetClientFirstTradeDate(ByVal accno As String) As Date
        Dim lstrSQL As String = ""
        Dim ldsMinTDate As DataSet = Nothing

        lstrSQL = "select min(tdate) as min_date " & _
                    "from " & GStrG2BFDB & ".dbo.histcltradeh a " & _
                    "left join " & GStrG2BFDB & ".dbo.client_master b on a.aid = b.aid " & _
                    "where accno = '" & accno & "' "
        ldsMinTDate = GFncRtnDS(GSCnSqlConn, lstrSQL)
        If (ldsMinTDate.Tables(0).Rows.Count > 0) Then
            Return ldsMinTDate.Tables(0).Rows(0).Item("min_date")
        End If
        Return Nothing
    End Function

    Protected Friend Function lFncGetHoliday(ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim lstrSQL As String = ""

        lstrSQL = "select rtrim(mkid) as mkid, date as hdate from " & GStrG2BFDB & ".dbo.holiday_master " & _
                    "where half_day = 'N' and date >= '" & Format(FromDate, "yyyyMMdd") & _
                    "' and date <= '" & Format(ToDate, "yyyyMMdd") & "' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Function lFncGetClosePosition(ByVal accno As String, ByVal FromDate As Date, ByVal ToDate As Date) As DataTable
        Dim lstrSQL As String = ""

        lstrSQL = "select a.tdate, a.vdate, rtrim(a.otype) as otype, rtrim(c.code) as code, rtrim(c.name) as name, " & _
                    "rtrim(a.mkid) as mkid, rtrim(b.month) as month, a.qty as qty " & _
                    "from " & GStrG2BFDB & ".dbo.close_pos a " & _
                    "inner join " & GStrG2BFDB & ".dbo.contract_master b on a.ctid = b.ctid " & _
                    "inner join " & GStrG2BFDB & ".dbo.commod_master c on b.cyid = c.cyid " & _
                    "inner join " & GStrG2BFDB & ".dbo.client_master d on a.aid = d.aid " & _
                    "where d.accno = '" & accno & "' and a.tdate >= '" & Format(FromDate, "yyyyMMdd") & _
                    "' and a.tdate <= '" & Format(ToDate, "yyyyMMdd") & "' " & _
                    "union all " & _
                    "select a.tdate, dateadd(day, 1, getdate()) as vdate, rtrim(a.type), rtrim(d.code), rtrim(d.name), " & _
                    "a.mkid, a.monthcode, b.qty " & _
                    "from " & GStrG2BFDB & ".dbo.open_pos a " & _
                    "inner join " & GStrG2BFDB & ".dbo.histcltraded b on a.oid = b.oid " & _
                    "inner join " & GStrG2BFDB & ".dbo.contract_master c on a.ctid = c.ctid " & _
                    "inner join " & GStrG2BFDB & ".dbo.commod_master d on c.cyid = d.cyid " & _
                    "inner join " & GStrG2BFDB & ".dbo.client_master e on a.aid = e.aid " & _
                    "where e.accno = '" & accno & "' and a.tdate >= '" & Format(FromDate, "yyyyMMdd") & _
                    "' and a.tdate <= '" & Format(ToDate, "yyyyMMdd") & "' "
        Return GFncRtnDS(GSCnSqlConn, lstrSQL).Tables(0)
    End Function

    Protected Friend Sub InitLockDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "tdate"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "code"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "product"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "tmonth"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "buy_qty"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "sell_qty"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "mkid"
        DT.Columns.Add(Column)
    End Sub

    Protected Friend Sub InitSpreadDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.DateTime")
        Column.ColumnName = "tdate"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "code"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "product"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "buy_qty"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "sell_qty"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "mkid"
        DT.Columns.Add(Column)
    End Sub

    Protected Friend Sub InitDurationDT(ByRef DT As DataTable)
        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "code"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "product"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "tmonth"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "total_day"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.Decimal")
        Column.ColumnName = "total_qty"
        DT.Columns.Add(Column)
        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "mkid"
        DT.Columns.Add(Column)
    End Sub

    Protected Friend Sub AddLockDT(ByRef ldtLock As DataTable, ByVal FromDate As Date, ByVal ToDate As Date, _
                                   ByVal p_code As String, ByVal p_name As String, ByVal p_month As String, _
                                   ByVal mkid As String)
        Do While (FromDate <= ToDate)
            Dim ldrLock As DataRow = ldtLock.NewRow
            ldrLock("tdate") = FromDate
            ldrLock("code") = p_code
            ldrLock("product") = p_name
            ldrLock("tmonth") = p_month
            ldrLock("buy_qty") = 0
            ldrLock("sell_qty") = 0
            ldrLock("mkid") = mkid
            ldtLock.Rows.Add(ldrLock)
            FromDate = DateAdd(DateInterval.Day, 1, FromDate)
        Loop
    End Sub

    Protected Friend Sub AddSpreadDT(ByRef ldtSpread As DataTable, ByVal FromDate As Date, ByVal ToDate As Date, _
                                      ByVal p_code As String, ByVal p_name As String, ByVal mkid As String)
        Do While (FromDate <= ToDate)
            Dim ldrSpread As DataRow = ldtSpread.NewRow
            ldrSpread("tdate") = FromDate
            ldrSpread("code") = p_code
            ldrSpread("product") = p_name
            ldrSpread("buy_qty") = 0
            ldrSpread("sell_qty") = 0
            ldrSpread("mkid") = mkid
            ldtSpread.Rows.Add(ldrSpread)
            FromDate = DateAdd(DateInterval.Day, 1, FromDate)
        Loop
    End Sub

    Protected Friend Sub AddDurationDT(ByRef ldtDuration As DataTable, ByVal FromDate As Date, ByVal ToDate As Date, _
                                       ByVal p_code As String, ByVal p_name As String, ByVal p_month As String, _
                                       ByVal mkid As String)
        FromDate = DateAdd(DateInterval.Day, (FromDate.Day - 1) * -1, FromDate)
        Do While (FromDate <= ToDate)
            Dim ldrDuration As DataRow = ldtDuration.NewRow
            ldrDuration("code") = p_code
            ldrDuration("product") = p_name
            ldrDuration("tmonth") = Format(FromDate, "yyyyMM")
            ldrDuration("total_day") = 0
            ldrDuration("total_qty") = 0
            ldrDuration("mkid") = mkid
            ldtDuration.Rows.Add(ldrDuration)
            FromDate = DateAdd(DateInterval.Month, 1, FromDate)
        Loop
    End Sub

    Protected Friend Function lFncExportCSV(ByVal accno As String, ByVal FromDate As Date, _
                                            ByVal ToDate As Date, ByVal AvgCheck As Boolean, _
                                            ByVal LockCheck As Boolean, ByVal SpreadCheck As Boolean) As Boolean

        Dim DateFrom As Date = FromDate
        Dim ldtClosePosition As DataTable = Nothing
        Dim ldtHoliday As DataTable = Nothing
        Dim ldtDuration As New DataTable
        Dim ldtLock As New DataTable
        Dim ldtSpread As New DataTable
        Dim preProd As String = ""

        ldtHoliday = lFncGetHoliday(FromDate, ToDate)
        ldtClosePosition = lFncGetClosePosition(accno, FromDate, ToDate)
        Dim ldrClosePosition As DataRow() = ldtClosePosition.Select("", " mkid, code, month, tdate  ")

        If (AvgCheck) Then
            InitDurationDT(ldtDuration)
        End If
        If (LockCheck) Then
            InitLockDT(ldtLock)
        End If
        If (SpreadCheck) Then
            InitSpreadDT(ldtSpread)
        End If

        'each row
        For i As Integer = 0 To ldrClosePosition.Length - 1
            Dim open_date As Date = ldrClosePosition(i).Item("tdate")
            Dim close_date As Date = ldrClosePosition(i).Item("vdate")
            Dim buy_sell As String = ldrClosePosition(i).Item("otype")
            Dim mkid As String = ldrClosePosition(i).Item("mkid")
            Dim p_code As String = ldrClosePosition(i).Item("code")
            Dim p_name As String = ldrClosePosition(i).Item("name")
            Dim p_month As String = ldrClosePosition(i).Item("month")
            Dim qty As Decimal = ldrClosePosition(i).Item("qty")
            Dim tempDate As Date = open_date

            If (Year(open_date) = 2008 And p_code = "USCU") Then
                Debug.Print("")
            End If

            Dim hold_day As Decimal = 0
            If (close_date.Date > ToDate.Date) Then
                close_date = ToDate.Date
            End If

            'each day of that day
            Do While (tempDate <= DateAdd(DateInterval.Day, -1, close_date))
                Application.DoEvents()
                If (AvgCheck) Then
                    Dim ldrHoliday As DataRow() = ldtHoliday.Select(" mkid = '" & mkid & "' and hdate = #" & _
                                                                    Format(tempDate, "yyyy/MM/dd") & "# ")
                    If (ldrHoliday.Length <= 0) Then
                        If (tempDate.DayOfWeek <> DayOfWeek.Sunday) Then
                            hold_day = hold_day + 1
                        End If
                    End If
                End If

                If (LockCheck) Then
                    Dim ldrLock As DataRow() = ldtLock.Select(" code = '" & p_code & "' and tmonth = '" & p_month & _
                                                                "' and tdate >= #" & Format(tempDate, "yyyy/MM/dd") & " 00:00:00" & _
                                                                "# and tdate <= #" & Format(tempDate, "yyyy/MM/dd") & " 23:59:59" & "#")
                    If (ldrLock.Length <= 0) Then
                        AddLockDT(ldtLock, FromDate, ToDate, p_code, p_name, p_month, mkid)
                        ldrLock = ldtLock.Select(" code = '" & p_code & "' and tmonth = '" & p_month & _
                                                "' and tdate >= #" & Format(tempDate, "yyyy/MM/dd") & " 00:00:00" & _
                                                "# and tdate <= #" & Format(tempDate, "yyyy/MM/dd") & " 23:59:59" & "#")
                    End If
                    If (buy_sell = 1) Then
                        ldrLock(0).Item("buy_qty") = ldrLock(0).Item("buy_qty") + qty
                    Else
                        ldrLock(0).Item("sell_qty") = ldrLock(0).Item("sell_qty") + qty
                    End If
                End If

                If (SpreadCheck) Then
                    Dim ldrSpread As DataRow() = ldtSpread.Select(" code = '" & p_code & _
                                                                    "' and tdate >= #" & Format(tempDate, "yyyy/MM/dd") & " 00:00:00" & _
                                                                    "# and tdate <= #" & Format(tempDate, "yyyy/MM/dd") & " 23:59:59" & "#")
                    If (ldrSpread.Length <= 0) Then
                        AddSpreadDT(ldtSpread, FromDate, ToDate, p_code, p_name, mkid)
                        ldrSpread = ldtSpread.Select(" code = '" & p_code & _
                                                     "' and tdate >= #" & Format(tempDate, "yyyy/MM/dd") & " 00:00:00" & _
                                                     "# and tdate <= #" & Format(tempDate, "yyyy/MM/dd") & " 23:59:59" & "#")
                    End If
                    If (buy_sell = 1) Then
                        ldrSpread(0).Item("buy_qty") = ldrSpread(0).Item("buy_qty") + qty
                    Else
                        ldrSpread(0).Item("sell_qty") = ldrSpread(0).Item("sell_qty") + qty
                    End If
                End If

                tempDate = DateAdd(DateInterval.Day, 1, tempDate)
            Loop

            If (AvgCheck) Then
                Dim ldrDuration As DataRow() = ldtDuration.Select(" code = '" & p_code & "' and tmonth = '" & _
                                                                    Format(open_date, "yyyyMM") & "' ")
                If (ldrDuration.Length <= 0) Then
                    AddDurationDT(ldtDuration, FromDate, ToDate, p_code, p_name, Format(open_date, "yyyyMM"), mkid)
                    ldrDuration = ldtDuration.Select(" code = '" & p_code & "' and tmonth = '" & Format(open_date, "yyyyMM") & "' ")
                End If
                If (hold_day > 0) Then
                    ldrDuration(0).Item("total_day") = ldrDuration(0).Item("total_day") + hold_day * qty
                    ldrDuration(0).Item("total_qty") = ldrDuration(0).Item("total_qty") + qty
                End If
            End If
        Next

        If (AvgCheck) Then
            Dim strExptFilename As String = "Duration.csv"
            Dim lstrFiles() As String
            Dim lsWriter As StreamWriter
            Dim lstrColValue As String
            Dim prev_prod As String = ""
            Dim prev_day As Decimal = 0
            Dim prev_qty As Decimal = 0

            Try
                lstrFiles = System.IO.Directory.GetFiles(GStrExptDir, strExptFilename)
                For Each lstrFile As String In lstrFiles
                    Application.DoEvents()
                    System.IO.File.Delete(lstrFile)
                Next

                lsWriter = New StreamWriter(GStrExptDir & strExptFilename, False, System.Text.Encoding.GetEncoding(950))
                lstrColValue = " Code, Product, Month, Total Hold Day, Total Qty, Average Duration(day) "
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()
                Dim ldrDuration As DataRow() = ldtDuration.Select("", " code, tmonth ")
                For i As Integer = 0 To ldrDuration.Length - 1
                    Application.DoEvents()
                    Dim code As String = ldrDuration(i).Item("code")
                    Dim product As String = ldrDuration(i).Item("product")
                    Dim tmonth As String = ldrDuration(i).Item("tmonth")
                    Dim total_day As Decimal = ldrDuration(i).Item("total_day")
                    Dim total_qty As Decimal = ldrDuration(i).Item("total_qty")
                    Dim hold_avg As Decimal = 0
                    If (ldrDuration(i).Item("total_qty") <> 0) Then
                        hold_avg = ldrDuration(i).Item("total_day") / ldrDuration(i).Item("total_qty")
                    End If

                    If (prev_prod <> code) Then
                        If (prev_prod <> "") Then
                            lstrColValue = ",," & "Average"
                            lstrColValue += "," & prev_day
                            lstrColValue += "," & prev_qty
                            If (prev_qty <> 0) Then
                                lstrColValue += "," & (prev_day / prev_qty)
                            Else
                                lstrColValue += ",0"
                            End If
                            lsWriter.WriteLine(lstrColValue)
                            lsWriter.Flush()
                        End If
                        prev_prod = code
                        prev_day = total_day
                        prev_qty = total_qty
                    Else
                        prev_day = prev_day + total_day
                        prev_qty = prev_qty + total_qty
                    End If

                    lstrColValue = code
                    lstrColValue += "," & product
                    lstrColValue += "," & tmonth
                    lstrColValue += "," & total_day
                    lstrColValue += "," & total_qty
                    lstrColValue += "," & hold_avg
                    lsWriter.WriteLine(lstrColValue)
                    lsWriter.Flush()
                Next
                If (prev_prod <> "") Then
                    lstrColValue = ",," & "Average"
                    lstrColValue += "," & prev_day
                    lstrColValue += "," & prev_qty
                    If (prev_qty <> 0) Then
                        lstrColValue += "," & (prev_day / prev_qty)
                    Else
                        lstrColValue += ",0"
                    End If
                    lsWriter.WriteLine(lstrColValue)
                    lsWriter.Flush()
                End If

                lsWriter.Close()
            Catch ex As Exception
                GSubWriteErrLog(ex.Message)
            End Try
        End If

        If (LockCheck) Then
            Dim strExptFilename As String = "Lock.csv"
            Dim lstrFiles() As String
            Dim lsWriter As StreamWriter
            Dim lstrColValue As String

            Try
                lstrFiles = System.IO.Directory.GetFiles(GStrExptDir, strExptFilename)
                For Each lstrFile As String In lstrFiles
                    Application.DoEvents()
                    System.IO.File.Delete(lstrFile)
                Next

                lsWriter = New StreamWriter(GStrExptDir & strExptFilename, False, System.Text.Encoding.GetEncoding(950))
                lstrColValue = " Date, Code, Product, Month, Round Turn"
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()

                Dim ldrLock As DataRow() = ldtLock.Select("", " code, tmonth, tdate ")
                For i As Integer = 0 To ldrLock.Length - 1
                    Application.DoEvents()
                    Dim tdate As Date = ldrLock(i).Item("tdate")
                    Dim code As String = ldrLock(i).Item("code")
                    Dim product As String = ldrLock(i).Item("product")
                    Dim tmonth As String = ldrLock(i).Item("tmonth")
                    Dim buy_qty As Decimal = ldrLock(i).Item("buy_qty")
                    Dim sell_qty As Decimal = ldrLock(i).Item("sell_qty")
                    Dim mkid As Decimal = ldrLock(i).Item("mkid")
                    Dim ldrHoliday As DataRow() = ldtHoliday.Select(" mkid = '" & mkid & "' and hdate = #" & _
                                                                    Format(tdate, "yyyy/MM/dd") & "# ")

                    If (ldrHoliday.Length <= 0) Then
                        If (tdate.DayOfWeek <> DayOfWeek.Sunday) Then
                            lstrColValue = tdate
                            lstrColValue += "," & code
                            lstrColValue += "," & product
                            lstrColValue += "," & tmonth
                            If (buy_qty > sell_qty) Then
                                lstrColValue += "," & sell_qty
                            Else
                                lstrColValue += "," & buy_qty
                            End If
                            lsWriter.WriteLine(lstrColValue)
                            lsWriter.Flush()
                        End If
                    End If
                Next

                lsWriter.Close()
            Catch ex As Exception
                GSubWriteErrLog(ex.Message)
            End Try
        End If

        If (SpreadCheck) Then
            Dim strExptFilename As String = "Spread.csv"
            Dim lstrFiles() As String
            Dim lsWriter As StreamWriter
            Dim lstrColValue As String

            Try
                lstrFiles = System.IO.Directory.GetFiles(GStrExptDir, strExptFilename)
                For Each lstrFile As String In lstrFiles
                    Application.DoEvents()
                    System.IO.File.Delete(lstrFile)
                Next

                lsWriter = New StreamWriter(GStrExptDir & strExptFilename, False, System.Text.Encoding.GetEncoding(950))
                lstrColValue = " Date, Code, Product, Round Turn"
                lsWriter.WriteLine(lstrColValue)
                lsWriter.Flush()

                Dim ldrSpread As DataRow() = ldtSpread.Select("", " code, tdate ")
                For i As Integer = 0 To ldrSpread.Length - 1
                    Application.DoEvents()
                    Dim tdate As Date = ldrSpread(i).Item("tdate")
                    Dim code As String = ldrSpread(i).Item("code")
                    Dim product As String = ldrSpread(i).Item("product")
                    Dim buy_qty As Decimal = ldrSpread(i).Item("buy_qty")
                    Dim sell_qty As Decimal = ldrSpread(i).Item("sell_qty")
                    Dim mkid As Decimal = ldrSpread(i).Item("mkid")
                    Dim ldrHoliday As DataRow() = ldtHoliday.Select(" mkid = '" & mkid & "' and hdate = #" & _
                                                                    Format(tdate, "yyyy/MM/dd") & "# ")

                    If (ldrHoliday.Length <= 0) Then
                        If (tdate.DayOfWeek <> DayOfWeek.Sunday) Then
                            lstrColValue = tdate
                            lstrColValue += "," & code
                            lstrColValue += "," & product
                            If (buy_qty > sell_qty) Then
                                lstrColValue += "," & sell_qty
                            Else
                                lstrColValue += "," & buy_qty
                            End If
                            lsWriter.WriteLine(lstrColValue)
                            lsWriter.Flush()
                        End If
                    End If
                Next

                lsWriter.Close()
            Catch ex As Exception
                GSubWriteErrLog(ex.Message)
            End Try
        End If

        Return True
    End Function

End Class
