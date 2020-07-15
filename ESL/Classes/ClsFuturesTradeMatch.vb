Public Class ClsFuturesTradeMatch

    Protected Friend Function lFncCreateTempTable()
        Dim lstrSQL As String = "CREATE TABLE #OpenPosition(monthcode nvarchar(4), descrpt nvarchar(30), longshort nvarchar(1), qty float)"
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
        Return Nothing
    End Function


    Protected Friend Function lFncInsertData(ByRef ldtComfirm As DataTable, ByVal action As String, _
                                             ByVal qty As Double, ByVal ldescrpt As String, ByVal monthcode As String) As Boolean

        'Dim ldr As DataRow

        'ldr = ldtComfirm.NewRow
        'ldr("action") = action
        'ldr("qty") = qty
        'ldr("ldescrpt") = ldescrpt
        'ldtComfirm.Rows.Add(ldr)

        Dim lstrSQL As String = ""

        lstrSQL = "Insert into #OpenPosition(longshort, qty, descrpt, monthcode) values ('" & action & "', " & CStr(qty) & ", '" & ldescrpt & "', '" & monthcode & "')"
        GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

    End Function

    Protected Friend Function lFncDropTempTable()
        Dim lstrSQL As String = "DROP TABLE #OpenPosition"
        Try
            lstrSQL = "DROP TABLE #OpenPosition"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "DROP TABLE #frontend"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            lstrSQL = "DROP TABLE #backend"
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
        Catch ex As Exception
        End Try
        Return Nothing
    End Function

    Protected Friend Function lFncGetMonth(ByVal month As String) As String
        Select Case month.ToUpper
            Case "JAN"
                Return "01"
            Case "FEB"
                Return "02"
            Case "MAR"
                Return "03"
            Case "APR"
                Return "04"
            Case "MAY"
                Return "05"
            Case "JUN"
                Return "06"
            Case "JUL"
                Return "07"
            Case "AUG"
                Return "08"
            Case "SEP"
                Return "09"
            Case "OCT"
                Return "10"
            Case "NOV"
                Return "11"
            Case "DEC"
                Return "12"
        End Select
        Return ""
    End Function
End Class
