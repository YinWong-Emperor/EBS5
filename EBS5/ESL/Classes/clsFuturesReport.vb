Public Class clsFuturesReport

    Protected Friend Function GetCounterParty() As DataTable
        Dim lcStrSQL As String = "Select misc_desc From misc_master Where misc_type = 'FuturesReport' And misc_code = 'CounterParty' Order By misc_desc"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function

End Class
