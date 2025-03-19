Public Class clsRptForeignMarket

    Protected Friend Function GetMarkets() As DataTable
        Dim lcStrSQL As String = "SELECT name_s FROM " & GStrG2BSDB & ".dbo.market_master "
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function

    Protected Friend Function GetThirdParty() As DataTable
        Dim lcStrSQL As String = "SELECT DISTINCT platform FROM " & GStrConDB & ".dbo.ThirdPartyAccountMaster "
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function
End Class
