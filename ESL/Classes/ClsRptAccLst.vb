Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRptAccLst

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncGetRunner() As DataSet
        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_AccLst_Runner", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)

            Return GFncRtnDS(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function lFncPrintAccLst(ByVal lstrRunFrm As String, _
    ByVal lstrRunTo As String, ByVal lstrType As String, ByRef isEmpty As Boolean) As ReportClass

        Dim rpt As New RptAccLst
        Dim ldtsTemp As DataSet
        Dim lstrCrit As String = ""
        Dim lstrTitle As String = ""

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_AccLst", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
            AddParameter(sqlCmd, "runFrm", lstrRunFrm.Trim)
            AddParameter(sqlCmd, "runTo", lstrRunTo.Trim)
            AddParameter(sqlCmd, "strType", lstrType.ToUpper().Trim)

            ldtsTemp = GFncRtnDS(sqlCmd)

            Select Case lstrType
                Case "MARGIN"
                    lstrTitle = " For Margin Only"
                Case "CASH"
                    lstrTitle = " For Cash Only"
                Case Else
                    lstrTitle = " For All "
            End Select

            If ldtsTemp.Tables(0).Rows.Count > 0 Then
                rpt.SetDataSource(ldtsTemp.Tables(0))
                clsRpt.AddParam(rpt, "paraTitle", lstrTitle)
                clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Else
                isEmpty = True
            End If
            If IsNothing(rpt) Then
                Return clsRpt.lfncRtnEmptyRpt("")
            Else
                Return rpt
            End If

        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try

    End Function

End Class
