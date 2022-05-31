Imports System.Data.SqlClient

Public Class ClsClientCodes


    ''' <summary>
    ''' Check client code is exist
    ''' </summary>
    ''' <returns>true for exsit</returns>
    Protected Friend Function FncIsClientCodeExist(ByVal client_code As String) As Boolean
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_CommssionAdjustStock_CheckClientCode", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "g2sbDB", GStrG2BSDB.Trim)
            AddParameter(sqlCmd, "clientCode", client_code)
            Dim ds As DataSet = GFncRtnDS(sqlCmd)

            If (ds.Tables(0).Rows.Count > 0) Then
                Return True
            Else
                Return False
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message)
            Return False
        End Try
    End Function

    ''' <summary>
    ''' Check client code length
    ''' </summary>
    ''' <returns>true for correct</returns>
    Protected Friend Function FncIsClientCodeLengthValid(ByVal client_code As String) As Boolean
        Return String.IsNullOrWhiteSpace(client_code) = False And client_code.Length = 8
    End Function


    Protected Friend Sub ShowMsg_InvalidClientCode()
        GSubShowInfo(GFncGetSysMsg(123))
    End Sub

    Protected Friend Sub ShowMsg_ClientCodeLengthLimition()
        GSubShowInfo(GFncGetSysMsg(16))
    End Sub

End Class
