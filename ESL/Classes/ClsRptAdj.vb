Imports CrystalDecisions.CrystalReports.Engine
Imports System.Text
Imports System.Data.SqlClient

Public Class ClsRptAdj
    Dim clsRpt As New ClsReports

    Protected Friend Function PrintAdjRpt(ByVal commOption As String, ByVal intOption As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal nonZeroIPO As Boolean, ByVal fromAE As String, ByVal toAE As String, ByRef isEmpty As Boolean) As ReportClass

        Dim rpt = Nothing
        Dim condition As String = ""
        Dim paraTitle As String = ""
        Dim title_remark As String = ""

        Try
            title_remark = "Transaction Date: " & Format(GDteTradeDate, "dd/MM/yyyy")
            condition = " Range from " & fromDate.ToString("MMM yyyy", New System.Globalization.CultureInfo("en-us")) & _
                            " to " & toDate.AddMonths(1).AddDays(-1).ToString("MMM yyyy", New System.Globalization.CultureInfo("en-us"))

            If fromAE <> "" And fromAE <> toAE Then
                condition &= ", Client Code >= " & fromAE.Trim
            End If

            If toAE <> "" And fromAE <> toAE Then
                condition &= ", Client Code <= " & toAE.Trim
            End If

            If fromAE <> "" And fromAE = toAE Then
                condition &= ", Client Code = " & fromAE.Trim
            End If

            If commOption.ToLower = "stock commission" Then
                paraTitle = "SECURITIES COMMISSION ADJUSTMENT REPORT"
                rpt = New RptAdj
            Else
                If commOption.ToLower = "futures commission" Then
                    paraTitle = "FUTURES COMMISSION ADJUSTMENT REPORT"
                    rpt = New RptAdj
                Else
                    Dim intType As String = ", Stock Interest"

                    If intOption.ToLower = ">=0 only" Then
                        intType &= " >=0"
                    End If
                    If intOption.ToLower = "<0 only" Then
                        intType &= " <0"
                    End If
                    If intOption.ToLower = "all" Then
                        intType &= " All"
                    End If

                    condition = condition & intType
                    paraTitle = "SECURITIES INTEREST ADJUSTMENT REPORT"
                    rpt = New RptCommAdjInt
                End If
            End If
            'condition &= "]"

            Dim dt As DataTable = GenRptCommData(commOption, intOption, fromDate, toDate, nonZeroIPO, fromAE, toAE, False).Tables(0)

            If dt.Rows.Count = 0 Then
                isEmpty = True
            End If

            rpt.SetDataSource(dt)
            clsRpt.AddParam(rpt, "paraTitleRemark", title_remark.ToString())
            clsRpt.AddParam(rpt, "paraTitleRange", condition.ToString())
            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            clsRpt.AddParam(rpt, "paraTitle", paraTitle)
            clsRpt.AddParam(rpt, "paraFromDate", fromDate)
            Return rpt
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function GetRunCode() As DataSet

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_CommAdjRptRunCode", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)

            Return GFncRtnDS(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

    Protected Friend Function GenRptCommData(ByVal commOption As String, ByVal intOption As String, ByVal fromDate As Date, ByVal toDate As Date, ByVal nonZeroIPO As Boolean, ByVal fromAE As String, ByVal toAE As String, ByVal isPrc As Boolean) As DataSet

        Try
            Dim sqlCmd As SqlCommand = New SqlCommand("s_Get_CommAdjRpt", GSCnSqlConn)
            sqlCmd.CommandType = CommandType.StoredProcedure

            AddParameter(sqlCmd, "liqDB", GSCnLiqConn.Database.Trim)
            AddParameter(sqlCmd, "commOption", commOption.ToLower())
            AddParameter(sqlCmd, "intOption", intOption.ToLower())
            AddParameter(sqlCmd, "fromDate", fromDate)
            AddParameter(sqlCmd, "toDate", toDate)
            AddParameter(sqlCmd, "nonZero", IIf(nonZeroIPO, 1, 0))
            AddParameter(sqlCmd, "fromAE", fromAE)
            AddParameter(sqlCmd, "toAE", toAE)
            AddParameter(sqlCmd, "isPrc", IIf(isPrc, 1, 0))

            Return GFncRtnDS(sqlCmd)
        Catch ex As Exception
            GSubWriteErrLog(ex.Message, "", False)
            Return Nothing
        End Try
    End Function

End Class
