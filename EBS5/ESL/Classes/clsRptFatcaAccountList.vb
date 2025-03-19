Public Class clsRptFatcaAccountList
    Protected Friend Function GetAccType() As DataTable
        Dim lcStrSQL As String = "SELECT CharValue FROM SystemStaticParam WHERE ParamType='ClientType' ORDER BY SystemStaticParamID ASC"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function
    Protected Friend Function GetFatcaAccType() As DataTable
        Dim lcStrSQL As String = "SELECT CharValue FROM SystemStaticParam WHERE ParamType='FATCAAccType' ORDER BY SystemStaticParamID ASC"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function
    Protected Friend Function GetNatureS() As DataTable
        Dim lcStrSQL As String = "SELECT CharValue FROM SystemStaticParam WHERE ParamType='NatureS' ORDER BY SystemStaticParamID ASC"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnSqlConn, lcStrSQL).Tables(0)

        Return lcDt
    End Function


    Protected Friend Function GetAeNo() As DataTable
        Dim lcStrSQL As String = "SELECT DISTINCT stcltmaster.run_code as aeno FROM stcltmaster ORDER BY stcltmaster.run_code"
        Dim lcDt As DataTable = New DataTable

        lcDt = GFncRtnDS(GSCnLiqConn, lcStrSQL).Tables(0)

        Return lcDt

    End Function
End Class
