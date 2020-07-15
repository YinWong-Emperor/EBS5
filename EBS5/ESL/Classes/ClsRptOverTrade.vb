Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsRptOverTrade
    Dim clsRpt As New ClsReports
    Dim clsMC As New ClsRptMarginCall
    Private Sub InitDT(ByRef DT As DataTable)

        Dim Column As DataColumn

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "title"
        DT.Columns.Add(Column)

        Column = New DataColumn
        Column.DataType = System.Type.GetType("System.String")
        Column.ColumnName = "sign_by"
        DT.Columns.Add(Column)

    End Sub
    Protected Friend Function lFncUpdSign(ByVal dgd As DataGridView) As Boolean

        Dim lstrSQL As String = ""
        Dim MyTrans As SqlTransaction = Nothing


        Try
            MyTrans = GSCnSqlConn.BeginTransaction

            lstrSQL = " delete from misc_master where misc_type like 'OTSIGN%' "
            GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0)
            For lintCnt As Integer = 0 To dgd.RowCount - 2
                Dim lstrTitle As String = GFncNoNullString(dgd.Rows(lintCnt).Cells("title").Value).Trim
                Dim lstrSign As String = GFncNoNullString(dgd.Rows(lintCnt).Cells("sign_by").Value).Trim
                If Not (IsNothing(dgd.Rows(lintCnt).Cells("title").Value) Or _
                    IsNothing(dgd.Rows(lintCnt).Cells("sign_by").Value)) Then
                    lstrSQL = " insert into misc_master (misc_type, misc_code, misc_desc) " & _
                                      " values ('OTSIGN" & Format(lintCnt + 1, "00") & "', '" & _
                                     lstrTitle & "','" & lstrSign & "') "
                    If GFncRunSQL(GSCnSqlConn, MyTrans, lstrSQL, 0) <= 0 Then
                        MyTrans.Rollback()
                        Return False
                    End If
                End If
            Next

            MyTrans.Commit()
            MyTrans = Nothing
            Return True

        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

    End Function
    Protected Friend Function lFncUpdLimit(ByVal dgd As DataGridView) As Boolean

        Dim lstrSQL As String = ""
        Dim MyTrans As SqlTransaction = Nothing

        Try
            MyTrans = GSCnLiqConn.BeginTransaction

            For lintCnt As Integer = 0 To dgd.RowCount - 1
                Dim lstrOTGroup As String = GFncNoNullString(dgd.Rows(lintCnt).Cells("overtrade_group").Value).Trim
                Dim ldecOTLimit As Decimal = Val(GFncNoNullValue(dgd.Rows(lintCnt).Cells("overtrade_limit").Value))
                Dim lstrRunCode As String = GFncNoNullString(dgd.Rows(lintCnt).Cells("run_code").Value).Trim
                lstrSQL = " update staemaster set overtrade_group = '" & _
                   lstrOTGroup & "', overtrade_limit = " & ldecOTLimit & _
                    " where run_code = '" & lstrRunCode & "' "
                If GFncRunSQL(GSCnLiqConn, MyTrans, lstrSQL, 0) <= 0 Then
                    MyTrans.Rollback()
                    Return False
                End If
            Next

            MyTrans.Commit()
            MyTrans = Nothing
            Return True

        Catch ex As Exception
            If GSCnSqlConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

    End Function
    Protected Friend Function lFncGetSignDT() As DataTable

        Dim lstrSql As String
        Dim ldt As DataTable

        lstrSql = " select misc_code as title, misc_desc as sign_by, 0 as seq " & _
                " from misc_master where misc_type like 'OTSIGN%' " & _
                " order by misc_type "

        ldt = GFncRtnDS(GSCnSqlConn, lstrSql).Tables(0)

        For lintCnt As Integer = 1 To ldt.Rows.Count
            ldt.Rows(lintCnt - 1).Item("seq") = lintCnt
        Next

        Return ldt

    End Function
    Protected Friend Function lFncGetLimitDT(ByVal strAe As String, ByVal strAEName As String, _
    ByVal strGroup As String, ByVal blnZero As Boolean) As DataTable
        Dim lstrSql As String
        Dim ldt As DataTable

        lstrSql = " select run_code, run_name, overtrade_group, overtrade_limit " & _
                " from staemaster where 1=1 "
        If strAe.Trim <> "" Then
            lstrSql += " and run_code like '%" & strAe.Trim & "%' "
        End If
        If strAEName.Trim <> "" Then
            lstrSql += " and run_name like '%" & strAe.Trim & "%' "
        End If
        If strGroup.Trim <> "" Then
            lstrSql += " and overtrade_group like '%" & strGroup.Trim & "%' "
        End If
        If Not blnZero Then
            lstrSql += " and overtrade_limit > 0 "
        End If
        lstrSql += " order by run_code "
        ldt = GFncRtnDS(GSCnLiqConn, lstrSql).Tables(0)

        Return ldt

    End Function

    Protected Friend Function lFncPrintOT(ByVal strQuery As String, ByVal strSort As String, ByVal strTitle As String, ByVal MC As String) As ReportClass
        Dim rpt As New RptOverTrade
        Dim ldtsTemp As DataTable = clsMC.lFncPrepareMC(strQuery, strSort, MC)
        Dim lintCnt As Integer = 0

        Do While lintCnt <= ldtsTemp.Rows.Count - 1
            If ldtsTemp.Rows(lintCnt).Item("cr_limit") >= ldtsTemp.Rows(lintCnt).Item("mc_dr_bal") Then
                ldtsTemp.Rows.RemoveAt(lintCnt)
            Else
                lintCnt += 1
            End If
        Loop
        For lintCnt = 0 To ldtsTemp.Rows.Count - 1
            If ldtsTemp.Rows(lintCnt).Item("overtrade_group") = "" Then
                ldtsTemp.Rows(lintCnt).Item("overtrade_group") = ldtsTemp.Rows(lintCnt).Item("run_code")
            End If
        Next

        If ldtsTemp.Rows.Count > 0 Then
            rpt.SetDataSource(ldtsTemp)
            rpt.Subreports("rptSign").SetDataSource(lFncGetSignDT())

            clsRpt.AddParam(rpt, "paraTDate", GDteTradeDate)
            clsRpt.AddParam(rpt, "paraTitle", strTitle)
            clsRpt.AddParam(rpt, "paraPrintUser", Trim(GStrloginID))
            Return rpt
        Else
            Return clsRpt.lfncRtnEmptyRpt("Over Trade Report")
        End If

    End Function


End Class
