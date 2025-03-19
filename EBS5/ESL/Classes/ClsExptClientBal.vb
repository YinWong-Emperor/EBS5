Public Class ClsExptClientBal

    Protected Friend Function getGroupList() As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select distinct list_name as list_name from liqacclist "
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "grouplist")

        Return lds

    End Function

    Protected Friend Function getGroupClientList(ByVal groupName As String) As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select clt_code from liqacclist where list_name = '" & Trim(groupName) & "' order by seq_no"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "groupclientlist")

        Return lds

    End Function

    Protected Friend Function getSelClientList() As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select distinct clt_code as clt_code from stcltmaster order by clt_code"
        lds = GFncRtnDS(GSCnLiqConn, lstrSQL, "selclientlist")

        Return lds

    End Function

End Class
