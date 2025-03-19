Public Class ClsCIESPerformance

    Protected Friend Function lFnGetClientCode() As DataTable
        Dim ds As New DataSet
        Dim lstr As String = "select distinct clt_code from CIES_performance_detail order by clt_code"
        ds = GFncRtnDS(GSCnLiqConn, lstr, "clt_code")
        Return ds.Tables(0)
    End Function

    Protected Friend Function lFnGetTradeDate(ByVal clt_code As String) As DataTable
        Dim ds As New DataSet
        Dim lstr As String = "select Trade_Date from CIES_performance_detail where clt_code = '" & clt_code & "' order by Trade_Date desc"
        ds = GFncRtnDS(GSCnLiqConn, lstr, "Trade_Date")
        Return ds.Tables(0)
    End Function


End Class
