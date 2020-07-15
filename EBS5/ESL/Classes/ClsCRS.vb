Imports System.Data.SqlClient
Public Class ClsCRS

    
    Protected Friend Function lFnGetCRSAccountTable(ByVal accType As String) As DataTable


        Dim ldtsTemp As DataSet
        Dim rpt As New RptAccIntClsNoAcc
        Dim scriptName As String = IIf(accType = "Securities", "s_Get_CRSAccount_20180530", "s_Get_CRSAccount_f_20180530")

        Dim sqlCmd As SqlCommand = New SqlCommand(scriptName, GSCnSqlConn)
        sqlCmd.CommandType = CommandType.StoredProcedure

        'AddParameter(sqlCmd, "g2bDB", IIf(accType = "Securities", GStrG2BSDB, GStrG2BFDB))
        AddParameter(sqlCmd, "g2bDB", frmCRS.numReturnYear.Value.ToString())

        ldtsTemp = GFncRtnDS(sqlCmd)

        If Not ldtsTemp Is Nothing Then
            Return ldtsTemp.Tables(0)

        Else
            Return Nothing
        End If

    End Function



End Class
