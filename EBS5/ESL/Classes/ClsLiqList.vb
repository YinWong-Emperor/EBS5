Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsLiqList

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncGetRunner() As DataSet
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LiqList_RunCode", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
            Return GFncRtnDS(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try

    End Function

    Protected Friend Function lFncSearch(ByVal cltType As String, _
                                         ByVal tables() As String, _
                                         ByVal rad As String) As DataSet
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LiqList", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "CltType", cltType)
            AddParameter(sqlCmd, "Rad", rad)

            Return GFncRtnDSTables(sqlCmd, tables)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function lFncGetDetail(ByVal lstrCltType As String, _
                                            ByVal rad As String) As DataSet
        Dim ldtsTemp As DataSet

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LiqList_Detail", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            AddParameter(sqlCmd, "lstrCltType", IIf(lstrCltType = "", DBNull.Value, lstrCltType))
            AddParameter(sqlCmd, "Rad", rad)

            ldtsTemp = GFncRtnDS(sqlCmd, "Detail")
            Return ldtsTemp
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try

    End Function

    Protected Friend Function lFncPrintAccLst( _
        ByVal amtCR As Decimal?, _
        ByVal amtDR As Decimal?, _
        ByVal amtMktMore As Decimal?, _
        ByVal amtMktLess As Decimal?, _
        ByVal amtActRatio As Decimal?, _
        ByVal amtMarRatio As Decimal?, _
        ByVal amtDue As Decimal?, _
        ByVal amtUndue As Decimal?, _
        ByVal amtTotal As Decimal?, _
        ByVal amtLimit As Decimal?, _
        ByVal amtOverDraft As Decimal?, _
        ByVal cBoRunFrom As String, _
        ByVal cBoRunTo As String, _
        ByVal clientFrom As String, _
        ByVal clientTo As String, _
        ByVal name As String, _
        ByVal amtOSDay As Decimal?, _
        ByVal lstrCltType As String, _
        ByVal lstrTitle As String, _
        ByRef isEmpty As Boolean, _
        ByVal rad As String) As ReportClass

        Dim rpt As New RptLiqLst
        Dim ldtsTemp As DataSet

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LiqList_Prc", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "amtCR", IIf(amtCR Is Nothing, DBNull.Value, amtCR))
            AddParameter(sqlCmd, "amtDR", IIf(amtDR Is Nothing, DBNull.Value, amtDR))
            AddParameter(sqlCmd, "amtMktMore", IIf(amtMktMore Is Nothing, DBNull.Value, amtMktMore))
            AddParameter(sqlCmd, "amtMktLess", IIf(amtMktLess Is Nothing, DBNull.Value, amtMktLess))
            AddParameter(sqlCmd, "amtActRatio", IIf(amtActRatio Is Nothing, DBNull.Value, amtActRatio))
            AddParameter(sqlCmd, "amtMarRatio", IIf(amtMarRatio Is Nothing, DBNull.Value, amtMarRatio))
            AddParameter(sqlCmd, "amtDue", IIf(amtDue Is Nothing, DBNull.Value, amtDue))
            AddParameter(sqlCmd, "amtUndue", IIf(amtUndue Is Nothing, DBNull.Value, amtUndue))
            AddParameter(sqlCmd, "amtTotal", IIf(amtTotal Is Nothing, DBNull.Value, amtTotal))
            AddParameter(sqlCmd, "amtLimit", IIf(amtLimit Is Nothing, DBNull.Value, amtLimit))
            AddParameter(sqlCmd, "amtOverDraft", IIf(amtOverDraft Is Nothing, DBNull.Value, amtOverDraft))
            AddParameter(sqlCmd, "cBoRunFrom", IIf(cBoRunFrom = "", DBNull.Value, cBoRunFrom))
            AddParameter(sqlCmd, "cBoRunTo", IIf(cBoRunTo = "", DBNull.Value, cBoRunTo))
            AddParameter(sqlCmd, "clientFrom", IIf(clientFrom = "", DBNull.Value, clientFrom))
            AddParameter(sqlCmd, "clientTo", IIf(clientTo = "", DBNull.Value, clientTo))
            AddParameter(sqlCmd, "name", IIf(name = "", DBNull.Value, name))
            AddParameter(sqlCmd, "amtOSDay", IIf(amtOSDay Is Nothing, DBNull.Value, amtOSDay))
            AddParameter(sqlCmd, "lstrCltType", IIf(lstrCltType = "", DBNull.Value, lstrCltType))
            AddParameter(sqlCmd, "Rad", rad)

            ldtsTemp = GFncRtnDS(sqlCmd)

            If ldtsTemp.Tables(0).Rows.Count > 0 Then
                rpt.SetDataSource(ldtsTemp.Tables(0))
                clsRpt.AddParam(rpt, "paraTDate", Format(GDteTradeDate, "dd/MM/yyyy"))
                clsRpt.AddParam(rpt, "paraHeader", "CRC SECURITIES LIQUIDATION LISTING(NEW) - (MARGIN & CASH & FINANCE)")
                clsRpt.AddParam(rpt, "paraTitle", lstrTitle)
                clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
                Return rpt
            Else
                isEmpty = True
                Return clsRpt.lfncRtnEmptyRpt("CRC SECURITIES LIQUIDATION LISTING(NEW) - (MARGIN & CASH & FINANCE)")
            End If
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try

    End Function

    Protected Friend Sub lFncCreateList(ByRef rad As String)
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LiqList_CreateList", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            Randomize()
            rad = New Random(DateTime.Now.Millisecond).Next(10000).ToString()

            AddParameter(sqlCmd, "LiqConn", GSCnLiqConn.Database.Trim)
            AddParameter(sqlCmd, "Rad", rad)

            GFncRtnDS(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
        End Try
    End Sub

    Protected Friend Sub lFncCleanTempTable(ByVal rad As String)
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LiqList_ClrTmp", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure
            AddParameter(sqlCmd, "Rad", rad)

            GFncRtnDS(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
        End Try
    End Sub

    Protected Friend Function lFncGetFilterLogic() As String
        Try
            Dim ldtsTemp As DataSet = Nothing

            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LiqList_FilterLogic", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            ldtsTemp = GFncRtnDS(sqlCmd)

            If ldtsTemp.Tables(0).Rows.Count <= 0 Then
                Return ""
            End If

            Return ldtsTemp.Tables(0).Rows(0).Item("misc_desc")
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function lFncSetFilterLogic(ByVal strsql As String) As Boolean
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Upd_LiqList_FilterLogic", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "lstrSQL", strsql)

            If GFncExecuteScalar(sqlCmd) <= 0 Then
                Return False
            End If

            Return True
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function lFncValidateCondition(ByVal criteria As String) As String
        Dim MyTrans As SqlTransaction = Nothing

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_LiqList_VadCod", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
            AddParameter(sqlCmd, "criteria", criteria)

            Dim ldtsTemp As DataSet = GFncRtnDS(sqlCmd)

            If (ldtsTemp.Tables(0).Rows.Count > 0) Then
                Return IIf(ldtsTemp.Tables(0).Rows(0)(0) = 0, False, True)
            End If

            Return False
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return False
        End Try
    End Function

End Class
