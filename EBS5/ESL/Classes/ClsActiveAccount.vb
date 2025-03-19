Imports System.Data.SqlClient
Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine

Public Class ClsActiveAccount

    Dim clsRpt As New ClsReports

    Protected Friend Function lFncPrintActAcc(ByVal dateFrom As Date, ByVal dateTo As Date, ByVal strExFile As String) As Boolean

        Dim loadIAsia As Boolean = False
        Dim loadAFE As Boolean = False
        Dim MyTrans As SqlTransaction = Nothing
        Dim lstrSQL As String = ""
        Dim ldtsTemp As DataSet = Nothing
        Dim fromDate As String = ""
        Dim toDate As String = ""

        If (dateFrom < Convert.ToDateTime("2005-11-04")) Then
            loadIAsia = True
            fromDate = Format(dateFrom, "yyyyMMdd")

            If (dateTo >= Convert.ToDateTime("2005-11-04")) Then
                toDate = "20051104"
            Else
                toDate = Format(dateTo, "yyyyMMdd")
            End If
        End If

        If (dateTo >= Convert.ToDateTime("2005-11-04")) Then
            loadAFE = True
            toDate = Format(dateTo, "yyyyMMdd")

            If (dateFrom < Convert.ToDateTime("2005-11-04")) Then
                fromDate = "20051104"
            Else
                fromDate = Format(dateFrom, "yyyyMMdd")
            End If
        End If

        Try
            MyTrans = GSCnLiqConn.BeginTransaction

            lstrSQL = "create table #sum_history(acc_no nvarchar(18), acc_name nvarchar(200), dt datetime) "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

            If (loadIAsia = True) Then
                lstrSQL = "INSERT INTO #sum_history(acc_no, acc_name, dt) " & _
                            "SELECT se.ACC AS ac_code, max(ac.AC_NAME) AS ac_name, max(cast(se.dt as datetime)) as dt_date " & _
                            "FROM itas_user2.itas_developers.itas_fmsedt se, itas_user2.itas_developers.itas_fmacdt ac " & _
                            "WHERE(se.ACC = ac.ACC) " & _
                            "and DT >= '" & fromDate & "' AND DT <= '" & toDate & "' " & _
                            "GROUP BY se.ACC"
                GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            End If

            If (loadAFE = True) Then
                'lstrSQL = "INSERT INTO #sum_history(acc_no, acc_name, dt) " & _
                '            "SELECT ci.client_code AS clt_code,max(ci.client_name) AS clt_name, max(ct.tdate) AS dt " & _
                '            "FROM  G2BS_RET.G2BS_RET.dbo.View_client_contact_info ci " & _
                '            "INNER JOIN G2BS_RET.G2BS_RET.dbo.View_er_ctrade_namt ct ON  ci.client_code = ct.accno " & _
                '            "INNER JOIN G2BS_RET.G2BS_RET.dbo.View_client_order_detail_all cd ON  ct.oid = cd.oid " & _
                '            "WHERE tdate >= '" & fromDate & "' and tdate <= '" & toDate & "' " & _
                '            "group by ci.client_code "
                lstrSQL = "INSERT INTO #sum_history(acc_no, acc_name, dt) " & _
                            "SELECT ci.client_code AS clt_code,max(ci.client_name) AS clt_name, max(ct.tdate) AS dt " & _
                            "FROM  " & GStrG2BSDB & ".dbo.View_client_contact_info ci " & _
                            "INNER JOIN " & GStrG2BSDB & ".dbo.View_er_ctrade_namt ct ON  ci.client_code = ct.accno " & _
                            "INNER JOIN " & GStrG2BSDB & ".dbo.View_client_order_detail_all cd ON  ct.oid = cd.oid " & _
                            "WHERE tdate >= '" & fromDate & "' and tdate <= '" & toDate & "' " & _
                            "group by ci.client_code "
                GFncRunSQL(GSCnSqlConn, lstrSQL, 0)
            End If

            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try

        lstrSQL = "SELECT acc_no, MAX(acc_name) as acc_name, MAX(dt) as last_trade_date " & _
                    "FROM #sum_history GROUP BY acc_no order by acc_no"
        ldtsTemp = GFncRtnDS(GSCnSqlConn, lstrSQL, 0)

        Try
            MyTrans = GSCnLiqConn.BeginTransaction

            lstrSQL = "drop table #sum_history "
            GFncRunSQL(GSCnSqlConn, lstrSQL, 0)

            MyTrans.Commit()
            MyTrans = Nothing
        Catch ex As Exception
            If GSCnLiqConn.State <> ConnectionState.Closed Then
                If (MyTrans IsNot Nothing) Then
                    MyTrans.Rollback()
                End If
                GSubWriteErrLog(ex.Message)
            End If
        End Try
        Return GExportCSV(GStrExptDir, strExFile, ldtsTemp, " Acc_No, Acc_Name, Last_Trade_Date ")

    End Function

End Class
