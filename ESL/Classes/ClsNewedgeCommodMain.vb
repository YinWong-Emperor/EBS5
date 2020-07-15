Imports System.Data.SqlClient

Public Class ClsNewedgeCommodMain

    Protected Friend Function lFncGetCommodities() As DataSet

        Dim lstrSQL As String
        Dim lds As DataSet

        lstrSQL = "select cdid, ric_code, commodity, floor_comm, floor_clearing, floor_levy, electronic_comm, " & _
                  "electronic_clearing, electronic_levy from newedge_commod order by ric_code"
        lds = GFncRtnDS(GSCnSqlConn, lstrSQL, "commod")
        Return lds

    End Function

    Protected Friend Function lFncDeleteCommod(ByVal cdid As String, ByRef MyTrans As SqlTransaction) As Long

        Dim lstrSQL As String

        lstrSQL = "DELETE FROM newedge_commod where cdid = " & cdid
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFncInsertCommod(ByVal riccode As String, ByVal commod As String, ByVal commf As String, _
                                              ByVal clearingf As String, ByVal levyf As String, ByVal comme As String, _
                                              ByVal clearinge As String, ByVal levye As String, ByRef MyTrans As SqlTransaction) As Long

        Dim lstrSQL As String

        lstrSQL = "INSERT INTO newedge_commod(ric_code, commodity, floor_comm, floor_clearing, floor_levy, electronic_comm, " & _
                  "electronic_clearing, electronic_levy) values(" & _
                  "'" & riccode & "', '" & commod & "'," & commf & "," & clearingf & "," & levyf & "," & comme & "," & clearinge & _
                  "," & levye & ")"
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

    Protected Friend Function lFncUpdateCommod(ByVal cdid As String, ByVal riccode As String, ByVal commod As String, _
                                               ByVal commf As String, ByVal clearingf As String, ByVal levyf As String, _
                                               ByVal comme As String, ByVal clearinge As String, ByVal levye As String, _
                                               ByRef MyTrans As SqlTransaction) As Long

        Dim lstrSQL As String

        lstrSQL = "UPDATE newedge_commod SET ric_code = '" & riccode & "', commodity = '" & commod & _
                  "', floor_comm = " & commf & ", floor_clearing = " & clearingf & ", floor_levy = " & levyf & _
                  ", electronic_comm = " & comme & ", electronic_clearing = " & clearinge & _
                  ", electronic_levy = " & levye & " where cdid = " & cdid
        Return GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)

    End Function

End Class
