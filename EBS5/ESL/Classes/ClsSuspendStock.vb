Public Class ClsSuspendStock


    Protected Friend Function lFncGetAllStock() As DataSet

        Dim lstrSQL As String = ""

        lstrSQL = "SELECT stkno as Stock_Code, suspend_date as Last_Suspend_Date " & _
                    "FROM stsuspendstock ORDER BY suspend_date, stkno "

        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "Stock")

    End Function

    Protected Friend Function lFncGetStockByDate(ByVal fromDate As Date, ByVal toDate As Date) As DataSet

        Dim lstrSQL As String = ""

        lstrSQL = "SELECT stkno as Stock_Code, suspend_date as Last_Suspend_Date " & _
                    "FROM stsuspendstock WHERE suspend_date >= '" & Format(fromDate, "yyyyMMdd") & "' " & _
                    "AND suspend_date <= '" & Format(toDate, "yyyyMMdd") & "' ORDER BY suspend_date, stkno"

        Return GFncRtnDS(GSCnLiqConn, lstrSQL, "Stock")

    End Function

    Protected Friend Function lFncExptAllStock() As Boolean

        Dim strExFile As String = "G2BSSuspendStock.csv"
        Dim ldtsData As DataSet
        Dim lstrSQL As String = ""

        If (GSubShowYNConfirm("Export to " & GStrExptDir & strExFile & "?") = DialogResult.Yes) Then
            lstrSQL = "SELECT stkno as Stock_Code, suspend_date as Last_Suspend_Date " & _
                        "FROM stsuspendstock ORDER BY suspend_date, stkno "
            ldtsData = GFncRtnDS(GSCnLiqConn, lstrSQL)

            GExportCSV(GStrExptDir, strExFile, ldtsData, " Stock_Code, Last_Suspend_Date ")
        End If

    End Function

    Protected Friend Function lFncExptStockByDate(ByVal fromDate As Date, ByVal toDate As Date) As Boolean

        Dim strExFile As String = "G2BSSuspendStock.csv"
        Dim ldtsData As DataSet
        Dim lstrSQL As String = ""

        If (GSubShowYNConfirm("Export to " & GStrExptDir & strExFile & "?") = DialogResult.Yes) Then
            lstrSQL = "SELECT stkno as Stock_Code, suspend_date as Last_Suspend_Date " & _
                        "FROM stsuspendstock WHERE suspend_date >= '" & Format(fromDate, "yyyyMMdd") & "' " & _
                        "AND suspend_date <= '" & Format(toDate, "yyyyMMdd") & "' ORDER BY suspend_date, stkno"

            ldtsData = GFncRtnDS(GSCnLiqConn, lstrSQL)

            GExportCSV(GStrExptDir, strExFile, ldtsData, " Stock_Code, Last_Suspend_Date ")
        End If

    End Function

End Class
