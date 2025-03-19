Imports System.Data.SqlClient

Public Class ClsAECodes

    Protected Friend Function FncGetAEName(ByVal ae_code As String) As String
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_AEName", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB.Trim)
            AddParameter(sqlCmd, "aeCode", ae_code)
            Dim ds As DataSet = GFncRtnDS(sqlCmd)

            If (ds.Tables(0).Rows.Count > 0) Then
                Return ds.Tables(0).Rows(0)("name").ToString()
            Else
                Return String.Empty
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return String.Empty
        End Try
    End Function

    Protected Friend Function FncIsAECodeExist(ByVal ae_code As String) As Boolean
        Try
            If Not (String.IsNullOrEmpty(FncGetAEName(ae_code))) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return False
        End Try
    End Function

    Protected Friend Function FncIsAECodeLengthValid(ByVal ae_code As String) As Boolean
        Return String.IsNullOrWhiteSpace(ae_code) = False And ae_code.Length >= 4
    End Function

    Protected Friend Sub ShowMsg_InvalidAECode()
        GSubShowInfo(GFncGetSysMsg(31))
    End Sub

    Protected Friend Sub ShowMsg_AECodeLengthLimition()
        GSubShowInfo(GFncGetSysMsg(140))
    End Sub

End Class
